'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】自動実行処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports UserProcess
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
#End Region

Public Class AutoCmdExec
    Implements IDisposable

#Region "  共通変数"
    Private threadId As Integer                         'ｽﾚｯﾄﾞID
    Private Owner As ManagerMain                        'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ
    Private mobjDb As clsConn                           'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ
    Private mobjDbLog As clsConn                        'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)
    Private CmdNo As Integer                            '実行ｺﾏﾝﾄﾞNo.
    Private RcvDt As String                             '実行ﾒｯｾｰｼﾞ
    Private msgRecv As String                           '受信ﾒｯｾｰｼﾞ(ﾀﾞﾐｰ)
    Private msgSend As String                           '送信ﾒｯｾｰｼﾞ(ﾀﾞﾐｰ)
    Private disposed As Boolean = False                 'ﾃﾞｨｽﾎﾟｰｽﾞFlag
#End Region

#Region "  委譲"
    '開始時、終了時の処理委譲
    Private objOnAutoCmdExecStart As AutoCmdExecStart
    Private objOnAutoCmdExecEnd As AutoCmdExecEnd
    Public Delegate Sub AutoCmdExecStart(ByVal AutoCmdExecObject As AutoCmdExec, ByVal AutoCmdExecTHread As Thread)
    Public Delegate Sub AutoCmdExecEnd(ByVal AutoCmdExecObject As AutoCmdExec, ByVal AutoCmdExecTHread As Thread)
#End Region

#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    ''' =======================================
    ''' <summary>Property ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property Id( _
        ) As Integer
        Get
            Return threadId
        End Get
        Set(ByVal Value As Integer)
            threadId = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>Property OnAutoCmdExecStart</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OnAutoCmdExecStart( _
       ) As AutoCmdExecStart
        Get
            Return objOnAutoCmdExecStart
        End Get
        Set(ByVal Value As AutoCmdExecStart)
            objOnAutoCmdExecStart = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>Property    OnAutoCmdExecEnd</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OnAutoCmdExecEnd( _
       ) As AutoCmdExecEnd
        Get
            Return objOnAutoCmdExecEnd
        End Get
        Set(ByVal Value As AutoCmdExecEnd)
            objOnAutoCmdExecEnd = Value
        End Set
    End Property
#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DB接続ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DB接続ｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)追加</param>
    ''' <param name="intCmd">ﾒｯｾｰｼﾞID　No</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As ManagerMain, ByVal objDb As clsConn, ByVal objDbLog As clsConn, ByVal intCmd As Integer)
        Try
            'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ定義
            Owner = objOwner
            mobjDb = objDb
            mobjDbLog = objDbLog
            CmdNo = intCmd
            RcvDt = ""
        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Sub
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DB接続ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DB接続ｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)追加</param>
    ''' <param name="strRcv">ﾒｯｾｰｼﾞID　No</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As ManagerMain, ByVal objDb As clsConn, ByVal objDbLog As clsConn, ByVal strRcv As String)
        Try
            'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ定義
            Owner = objOwner
            mobjDb = objDb
            mobjDbLog = objDbLog
            CmdNo = 0
            RcvDt = strRcv
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
    ''' <param name="disposing"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposed Then
            If disposing Then
                Try
                    'ｵﾌﾞｼﾞｪｸﾄ開放
                    Owner = Nothing
                    mobjDb = Nothing
                    mobjDbLog = Nothing
                Catch e As Exception
                    ComError(e)
                End Try
            End If
        End If
        disposed = True
    End Sub
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

#Region "  ｽﾚｯﾄﾞ開始                                    (Public  Go)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｽﾚｯﾄﾞ開始
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Go()
        Try
            'ｽﾚｯﾄﾞﾌﾟｰﾙ登録
            ThreadPool.QueueUserWorkItem(AddressOf Me.Start)
        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

#Region "  自動実行処理開始                             (Public  Start)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 自動実行処理開始
    ''' </summary>
    ''' <param name="state">ｽﾃｰﾀｽｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Start(ByVal state As Object)
        Try
            '開始時処理委譲
            If Not objOnAutoCmdExecStart Is Nothing Then objOnAutoCmdExecStart.Invoke(Me, Thread.CurrentThread)

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2015/11/04 メモリリーク＆コマンドタイムアウト対応 ↓↓↓↓↓↓
            Dim requestInitialOwnership As Boolean = True
            Dim mutexWasCreated As Boolean
            '************************
            '排他処理
            '************************
            Dim objMtx As New Mutex(requestInitialOwnership, "AutoCmdExec", mutexWasCreated)
            Try
                '************************
                '排他待ち処理
                '************************
                If Not (requestInitialOwnership And mutexWasCreated) Then
                    Exit Try
                End If
                'JobMate:S.Ouchi 2015/11/04 メモリリーク＆コマンドタイムアウト対応 ↑↑↑↑↑↑
                '↑↑↑↑↑↑************************************************************************************************************

                'ﾀﾞﾐｰ受信ﾒｯｾｰｼﾞ作成
                msgRecv = ""
                Dim objCmd As New cmd_manage(Me, mobjDb, mobjDbLog)
                objCmd.ExecCmd(msgRecv, msgSend)
                objCmd = Nothing
                GC.Collect()

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2015/11/04 メモリリーク＆コマンドタイムアウト対応 ↓↓↓↓↓↓
            Catch ex As Exception
                ComError(ex)
                Throw New System.Exception(ex.Message)
            Finally
                '************************
                '排他処理開放
                '************************
                If mutexWasCreated Then
                    objMtx.ReleaseMutex()
                End If
            End Try
            'JobMate:S.Ouchi 2015/11/04 メモリリーク＆コマンドタイムアウト対応 ↑↑↑↑↑↑
            '↑↑↑↑↑↑************************************************************************************************************

            '終了時処理委譲
            If Not objOnAutoCmdExecEnd Is Nothing Then objOnAutoCmdExecEnd.Invoke(Me, Thread.CurrentThread)
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  ｽﾚｯﾄﾞ強制終了                                (Public  Cancel)"
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

#Region "  ｴﾗｰ時共通ﾓｼﾞｭｰﾙ                              (Private ComError)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ時 共通ﾓｼﾞｭｰﾙ
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

#Region "  ﾛｸﾞ書込み処理                                (Public  AddToLog)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込み処理
    ''' </summary>
    ''' <param name="strMsg">ﾛｸﾞ書込ﾒｯｾｰｼﾞ</param>
    ''' <param name="strProd"></param>
    ''' <param name="intType">ｯｾｰｼﾞ区分 0:情報 1:ﾕｰｻﾞｴﾗｰ 2:ｼｽﾃﾑｴﾗｰ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg As String, ByVal strProd As String, ByVal intType As LogType)
        Try
            If Owner Is Nothing = False Then
                Owner.AddToLog(strMsg, strProd, intType)
            End If
        Catch e As Exception
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

End Class
