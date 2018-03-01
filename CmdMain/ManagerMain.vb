'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｻｰﾊﾞﾌﾟﾛｾｽ　ﾒｲﾝ処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports System.Threading
Imports System.Net.Sockets
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports UserProcess
Imports System.Runtime.Remoting.Lifetime
Imports System.Security.Permissions
#End Region

Public Class ManagerMain
    Inherits MarshalByRefObject
    Implements IDisposable

#Region "  共通変数"
    Private objSendRecv As SendRecv                     'ﾒｯｾｰｼﾞ送受信ｵﾌﾞｼﾞｪｸﾄ
    Private objTimerExec As TimerExec                   '定周期処理
    Private objOnTimeExec As OnTimeExec                 '定時処理
    Private Owner As Object                             'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ
    Private mobjDb As clsConn                           'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ
    Private mobjDbLog As clsConn                        'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書込み用)
    Private objLog As LogWrite                          'ﾛｸﾞ書込みｵﾌﾞｼﾞｪｸﾄ
    Private _threadListLock As New ReaderWriterLock     'ﾛｯｸ定義
    'Private mobjSocketSend_FA As clsSocketSend
    Private disposed As Boolean = False                 'ﾃﾞｨｽﾎﾟｰｽﾞFlag
#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object)
        Try
            'ｶﾚﾝﾄﾃﾞｨﾚｸﾄﾘ設定
            System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory)

            'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ定義
            Owner = objOwner
            mobjDb = New clsConn

            'ﾛｸﾞ書込みｵﾌﾞｼﾞｪｸﾄ定義
            mobjDbLog = New clsConn
            objLog = New LogWrite(Owner, mobjDbLog)

            'Configﾌｧｲﾙ読込み
            ConfigFile = New clsConfigFileRead(CONFIG_FILE)
            ConfigFile.clsmALLGetPrivateProfile()
        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

#Region "  ﾃﾞｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｽﾄﾗｸﾀ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overrides Sub Finalize()
        'ｸﾛｰｽﾞ処理
        Call Dispose(False)
    End Sub
#End Region

#Region "  ﾃﾞｨｽﾎﾟｰｽﾞ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｨｽﾎﾟｰｽﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Call Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｨｽﾎﾟｰｽﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposed Then
            If disposing Then
                Try
                    'ﾒｯｾｰｼﾞ受信・返答処理終了
                    If Not objSendRecv Is Nothing Then
                        objSendRecv.Dispose()
                        objSendRecv = Nothing
                    End If

                    '定周期処理終了
                    If Not objTimerExec Is Nothing Then
                        objTimerExec.Dispose()
                        objTimerExec = Nothing
                    End If

                    '定時処理終了
                    If Not objOnTimeExec Is Nothing Then
                        objOnTimeExec.Dispose()
                        objOnTimeExec = Nothing
                    End If

                    'Oracleｱｸｾｽｵﾌﾞｼﾞｪｸﾄ開放
                    If Not mobjDb Is Nothing Then
                        mobjDb.Disconnect()
                        mobjDb = Nothing
                    End If

                    'Oracleｱｸｾｽｵﾌﾞｼﾞｪｸﾄ開放(ﾛｸﾞ書込み用)
                    If Not mobjDbLog Is Nothing Then
                        mobjDbLog.Disconnect()
                        mobjDbLog = Nothing
                    End If

                    'ｵﾌﾞｼﾞｪｸﾄ開放
                    Owner = Nothing
                    ConfigFile = Nothing
                    objLog = Nothing
                    _threadListLock = Nothing

                Catch e As Exception
                    ComError(e)
                End Try
            End If
        End If
        disposed = True
    End Sub
#End Region

#Region "  ｵﾌﾞｼﾞｪｸﾄ有効期間定義"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｵﾌﾞｼﾞｪｸﾄ有効期間定義
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    <SecurityPermissionAttribute(SecurityAction.LinkDemand, _
                                 Flags:=SecurityPermissionFlag.Infrastructure)> _
    Public Overrides Function InitializeLifetimeService() As Object
        Dim lease As ILease = CType(MyBase.InitializeLifetimeService(), ILease)
        If lease.CurrentState = LeaseState.Initial Then
            lease.InitialLeaseTime = TimeSpan.Zero
        End If
        Return lease
    End Function
#End Region

#Region "  ｸﾛｰｽﾞ処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾛｰｽﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Close()
        Call Dispose()
    End Sub
#End Region

#Region "  ｻｰﾊﾞﾌﾟﾛｾｽ ﾒｲﾝ処理開始                (Public  Start)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｻｰﾊﾞﾌﾟﾛｾｽ ﾒｲﾝ処理開始
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Start()
        Try

            objTelegramRecvDSP = New clsTelegram(CONFIG_TELEGRAM_DSP)   '画面受信用電文
            objTelegramSendDSP = New clsTelegram(CONFIG_TELEGRAM_DSP)   '画面送信用電文

            'DBｸｾｽｵﾌﾞｼﾞｪｸﾄ接続
            Dim blnRet As Boolean
            blnRet = False
            mobjDb.ConnectString = ConfigFile.DBConnectString
            Do While blnRet = False
                blnRet = mobjDb.Connect()
            Loop


            'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ接続(ﾛｸﾞ書込み用)
            blnRet = False
            mobjDbLog.ConnectString = ConfigFile.DBConnectString
            Do While blnRet = False
                blnRet = mobjDbLog.Connect()
            Loop

            '起動時実行処理
            mobjDb.BeginTrans()
            Dim rtn As Integer = RetCode.NG
            Try
                Dim msgRecv As String = ""                                  '受信ﾒｯｾｰｼﾞ(ﾀﾞﾐｰ)
                Dim msgSend As String = ""                                  '送信ﾒｯｾｰｼﾞ(ﾀﾞﾐｰ)
                Dim objCmd As New SVR_000001(Me, mobjDb, mobjDbLog)
                rtn = objCmd.ExecCmd(msgRecv, msgSend)
            Catch ex As Exception
                ComError(ex)
                Throw New System.Exception(ex.Message)
            Finally
                If rtn = RetCode.NG Then
                    '(異常終了の場合)
                    mobjDb.RollBack()
                    AddToLog("cmdNo=[000000] 異常終了", "", LogType.INFO)
                Else
                    '(正常終了の場合)
                    Try
                        mobjDb.Commit()
                    Catch ex As Exception
                        Throw New Exception("【ｺﾐｯﾄ失敗】" & ex.Message)
                    End Try
                    AddToLog("cmdNo=[000000] 正常終了", "", LogType.INFO)
                End If
            End Try

            'ﾒｯｾｰｼﾞ受信・返答処理
            objSendRecv = New SendRecv(Me, mobjDb, mobjDbLog)
            objSendRecv.OnSendRecvStart = AddressOf Me.SendRecvStart
            objSendRecv.OnSendRecvEnd = AddressOf Me.SendRecvEnd
            objSendRecv.Go()

            '定周期処理
            objTimerExec = New TimerExec(Me, mobjDb, mobjDbLog)
            objTimerExec.OnTimerExecStart = AddressOf Me.TimerExecStart
            objTimerExec.OnTimerExecEnd = AddressOf Me.TimerExecEnd
            objTimerExec.Go()

            '定時処理
            objOnTimeExec = New OnTimeExec(Me, mobjDb, mobjDbLog)
            objOnTimeExec.OnOnTimeExecStart = AddressOf Me.OnTimeExecStart
            objOnTimeExec.OnOnTimeExecEnd = AddressOf Me.OnTimeExecEnd
            objOnTimeExec.Go()

            'Call Conn_FA()

        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

#Region "  ﾒｯｾｰｼﾞ受信・応答処理 開始検知        (Public  SendRecvStart)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｯｾｰｼﾞ受信・応答処理 開始検知
    ''' </summary>
    ''' <param name="SendRecvObject">送受信ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="SendRecvTHread">送受信ｽﾚｯﾄﾞｽﾃｰﾀｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub SendRecvStart(ByVal SendRecvObject As SendRecv, ByVal SendRecvTHread As Thread)
        Try
            '書込ﾛｯｸを取得
            _threadListLock.AcquireWriterLock(-1)

            'ﾛｸﾞ書き込み
            AddToLog("SendRecv ｽﾚｯﾄﾞ開始 ID=[" & SendRecvTHread.GetHashCode.ToString & "]", "", LogType.INFO)

            '書込ﾛｯｸを開放
            _threadListLock.ReleaseWriterLock()
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  ﾒｯｾｰｼﾞ受信・返答処理 終了検知        (Public  SendRecvEnd)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｯｾｰｼﾞ受信・返答処理 終了検知
    ''' </summary>
    ''' <param name="SendRecvObject">送受信ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="SendRecvTHread">送受信ｽﾚｯﾄﾞｽﾃｰﾀｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub SendRecvEnd(ByVal SendRecvObject As SendRecv, ByVal SendRecvTHread As Thread)
        Try
            '書込ﾛｯｸを取得
            _threadListLock.AcquireWriterLock(-1)

            'ﾛｸﾞ書き込み
            AddToLog("SendRecv ｽﾚｯﾄﾞ終了 ID=[" & SendRecvTHread.GetHashCode.ToString & "]", "", LogType.INFO)

            '書込ﾛｯｸを開放
            _threadListLock.ReleaseWriterLock()
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  定周期処理  開始検知                 (Public  TimerExecStart)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 定周期処理  開始検知
    ''' </summary>
    ''' <param name="TimerExecObject">定周期ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="TimerExecTHread">定周期ｽﾚｯﾄﾞｽﾃｰﾀｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub TimerExecStart(ByVal TimerExecObject As TimerExec, ByVal TimerExecTHread As Thread)
        Try
            '書込ﾛｯｸを取得
            _threadListLock.AcquireWriterLock(-1)

            'ﾛｸﾞ書き込み
            AddToLog("TimerExec ｽﾚｯﾄﾞ開始 ID=[" & TimerExecTHread.GetHashCode.ToString & "]", "", LogType.INFO)

            '書込ﾛｯｸを開放
            _threadListLock.ReleaseWriterLock()
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  定周期処理  終了検知                 (Public  TimerExecEnd)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 定周期処理  終了検知
    ''' </summary>
    ''' <param name="TimerExecObject">定周期ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="TimerExecTHread">定周期ｽﾚｯﾄﾞｽﾃｰﾀｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub TimerExecEnd(ByVal TimerExecObject As TimerExec, ByVal TimerExecTHread As Thread)
        Try
            '書込ﾛｯｸを取得
            _threadListLock.AcquireWriterLock(-1)

            'ﾛｸﾞ書き込み
            AddToLog("TimerExec ｽﾚｯﾄﾞ終了 ID=[" & TimerExecTHread.GetHashCode.ToString & "]", "", LogType.INFO)

            '書込ﾛｯｸを開放
            _threadListLock.ReleaseWriterLock()
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  定周期処理  開始検知                 (Public  OnTimeExecStart)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 定周期処理  開始検知
    ''' </summary>
    ''' <param name="OnTimeExecObject">定時ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="OnTimeExecTHread">定時ｽﾚｯﾄﾞｽﾃｰﾀｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub OnTimeExecStart(ByVal OnTimeExecObject As OnTimeExec, ByVal OnTimeExecTHread As Thread)
        Try
            '書込ﾛｯｸを取得
            _threadListLock.AcquireWriterLock(-1)

            'ﾛｸﾞ書き込み
            AddToLog("OnTimeExec ｽﾚｯﾄﾞ開始 ID=[" & OnTimeExecTHread.GetHashCode.ToString & "]", "", LogType.INFO)

            '書込ﾛｯｸを開放
            _threadListLock.ReleaseWriterLock()
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  定周期処理  終了検知                 (Public  OnTimeExecEnd)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 定周期処理  終了検知
    ''' </summary>
    ''' <param name="OnTimeExecObject">定時ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="OnTimeExecTHread">定時ｽﾚｯﾄﾞｽﾃｰﾀｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub OnTimeExecEnd(ByVal OnTimeExecObject As OnTimeExec, ByVal OnTimeExecTHread As Thread)
        Try
            '書込ﾛｯｸを取得
            _threadListLock.AcquireWriterLock(-1)

            'ﾛｸﾞ書き込み
            AddToLog("OnTimeExec ｽﾚｯﾄﾞ終了 ID=[" & OnTimeExecTHread.GetHashCode.ToString & "]", "", LogType.INFO)

            '書込ﾛｯｸを開放
            _threadListLock.ReleaseWriterLock()
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  ｽﾚｯﾄﾞ強制終了                        (Public  Cancel)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｽﾚｯﾄﾞ強制終了
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Cancel()
        Try
            'ｸﾛｰｽﾞ処理
            Call Close()
        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

#Region "  ｴﾗｰ時共通ﾓｼﾞｭｰﾙ                      (Private ComError)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ時共通ﾓｼﾞｭｰﾙ 
    ''' </summary>
    ''' <param name="e">例外の基本ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="strFunc"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ComError(ByVal e As Exception, Optional ByVal strFunc As String = "")
        Try
            Dim strMsg As String = ""
            Dim strProd As String = ""
            strProd &= "Src=[" & CType(CType(e.TargetSite, System.Reflection.MethodBase).ReflectedType, System.Type).FullName
            strProd &= "." & CType(e.TargetSite, System.Reflection.MethodBase).Name & "]"
            If strFunc <> "" Then
                strProd &= " Fnc=[" & strFunc & "]"
            End If
            strMsg &= "Msg=[" & e.Message & "]"
            AddToLog(strMsg, strProd, LogType.SERR)
        Catch ex As Exception
            'NOP(Error 処理中の Error 回避)
        End Try
    End Sub
#End Region

#Region "  ﾛｸﾞ書込み処理                        (Public  AddToLog)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込み処理
    ''' </summary>
    ''' <param name="strMsg">ﾛｸﾞ書込ﾒｯｾｰｼﾞ</param>
    ''' <param name="strProd"></param>
    ''' <param name="intType">ﾒｯｾｰｼﾞ区分    0:情報 1:ﾕｰｻﾞｴﾗｰ 2:ｼｽﾃﾑｴﾗｰ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg As String, ByVal strProd As String, ByVal intType As LogType)
        Try
            objLog.AddToLog(strMsg, strProd, intType)
        Catch e As Exception
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

End Class
