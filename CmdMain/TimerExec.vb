'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】定周期実行処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Timers
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports System.Runtime.Remoting.Lifetime
Imports System.Security.Permissions
#End Region

Public Class TimerExec
    Inherits MarshalByRefObject
    Implements IDisposable

#Region "  共通変数"
    Private Owner As ManagerMain                            'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ
    Private mobjDb As clsConn                               'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ
    Private mobjDbLog As clsConn                            'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)追加
    Private allDone As New ManualResetEvent(False)          'ｽﾚｯﾄﾞ状態
    Private _isCancelled As Boolean = False                 '中止ﾌﾗｸﾞ
    Private _isEnded As Boolean = False                     '終了ﾌﾗｸﾞ
    Private _threadID As Integer = 0                        'ｽﾚｯﾄﾞID
    Private endCounter As Integer = 0                       'ｽﾚｯﾄﾞ終了ｶｳﾝﾀ
    Private _threadListLock As New ReaderWriterLock         'ﾛｯｸ定義
    Private _threadList As New Hashtable                    '実行中ｽﾚｯﾄﾞﾘｽﾄ
    Private _activeClientAnswerList As New ArrayList        '実行中ｽﾚｯﾄﾞﾘｽﾄ
    Private disposed As Boolean = False                     'ﾃﾞｨｽﾎﾟｰｽﾞFlag
    Private objTimer As New System.Timers.Timer()           'ﾀｲﾏｰｵﾌﾞｼﾞｪｸﾄ
#End Region

#Region "  委譲"
    '開始時、終了時の処理委譲
    Private objOnTimerExecStart As TimerExecStart
    Private objOnTimerExecEnd As TimerExecEnd
    Public Delegate Sub TimerExecStart(ByVal SendRecvObject As TimerExec, ByVal SendRecvTHread As Thread)
    Public Delegate Sub TimerExecEnd(ByVal SendRecvObject As TimerExec, ByVal SendRecvTHread As Thread)
#End Region

#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    ''' =======================================
    ''' <summary>Property OnTimerExecStart</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OnTimerExecStart( _
      ) As TimerExecStart
        Get
            Return objOnTimerExecStart
        End Get
        Set(ByVal Value As TimerExecStart)
            objOnTimerExecStart = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>Property    OnTimerExecEnd</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OnTimerExecEnd( _
       ) As TimerExecEnd
        Get
            Return objOnTimerExecEnd
        End Get
        Set(ByVal Value As TimerExecEnd)
            objOnTimerExecEnd = Value
        End Set
    End Property
#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DB接続ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DB接続ｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)追加</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As ManagerMain, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        Try
            'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ定義
            Owner = objOwner
            mobjDb = objDb
            mobjDbLog = objDbLog
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
                    'ｽﾚｯﾄﾞ状態開放
                    allDone.Close()

                    '中止ﾌﾗｸﾞ設定
                    _isCancelled = True

                    'ｲﾍﾞﾝﾄの状態をｼｸﾞﾅﾙ状態に設定
                    allDone.Set()

                    'ｽﾚｯﾄﾞが終了するまで待機
                    endCounter = 0
                    While (Not _isEnded) And (CheckAllComplete() = False)
                        Thread.Sleep(ConfigFile.ThreadEndTimer)
                        endCounter += 1
                        If endCounter >= ConfigFile.ThreadEndCount Then Exit While '一定時間返答がない場合は強制的に終了

                    End While

                    'ｵﾌﾞｼﾞｪｸﾄ開放
                    Owner = Nothing
                    mobjDb = Nothing
                    mobjDbLog = Nothing
                    _threadList = Nothing
                    _activeClientAnswerList = Nothing
                    _threadListLock = Nothing
                    allDone = Nothing

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

#Region "  ｽﾚｯﾄﾞ開始                (Public  Go)"
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

#Region "  定時処理開始             (Public  Start)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 定時処理開始
    ''' </summary>
    ''' <param name="state">ｽﾃｰﾀｽｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Start(ByVal state As Object)
        Try
            'Dim intCnt As Integer       '定周期処理設定数

            '開始時処理委譲
            If Not objOnTimerExecStart Is Nothing Then objOnTimerExecStart.Invoke(Me, Thread.CurrentThread)

            '定周期処理起動
            AddHandler objTimer.Elapsed, New ElapsedEventHandler(AddressOf mtmr_tick)
            objTimer.Interval = ConfigFile.TimerAdvIntvl * 1000
            objTimer.AutoReset = True
            objTimer.Enabled = True

            '終了時処理委譲
            If Not objOnTimerExecEnd Is Nothing Then objOnTimerExecEnd.Invoke(Me, Thread.CurrentThread)

            '終了ﾌﾗｸﾞ設定
            _isEnded = True
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  ﾀｲﾏｰ割り込み処理         (Private mtmr_Timer)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾀｲﾏｰ割り込み処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub mtmr_tick(ByVal sender As Object, ByVal e As ElapsedEventArgs)
        Try
            'ﾀｲﾏｰ停止
            objTimer.Stop()

            Dim objAutoCmd As New AutoCmdExec(Owner, mobjDb, mobjDbLog, 0)

            If Integer.MaxValue = _threadID Then
                _threadID = 1
            Else
                _threadID += 1
            End If

            objAutoCmd.OnAutoCmdExecStart = AddressOf AutoCmdExecStart
            objAutoCmd.OnAutoCmdExecEnd = AddressOf AutoCmdExecEnd
            objAutoCmd.Id = _threadID
            objAutoCmd.Go()

            'ｶﾞﾍﾞｰｼﾞｺﾚｸｼｮﾝ
            GC.Collect()

            'ﾀｲﾏｰ起動
            objTimer.Start()

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

#Region "  ｽﾚｯﾄﾞ生成元に開始を通知  (Public  AutoCmdExecStart)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｽﾚｯﾄﾞ生成元に開始を通知
    ''' </summary>
    ''' <param name="AutoCmdExecObject">自動実行ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="AutoCmdExecTHread">自動実行ｽﾚｯﾄﾞｽﾃｰﾀｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AutoCmdExecStart(ByVal AutoCmdExecObject As AutoCmdExec, ByVal AutoCmdExecTHread As Thread)
        Try
            '書込ﾛｯｸを取得
            _threadListLock.AcquireWriterLock(-1)

            'ｽﾚｯﾄﾞﾘｽﾄに登録
            Try
                _threadList.Add(AutoCmdExecTHread.GetHashCode, AutoCmdExecObject.Id)
            Catch
                _threadList.Item(AutoCmdExecTHread.GetHashCode) = AutoCmdExecObject.Id
            End Try
            _activeClientAnswerList.Add(AutoCmdExecObject)

            '書込ﾛｯｸを解除
            _threadListLock.ReleaseWriterLock()
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  ｽﾚｯﾄﾞ生成元に終了を通知  (Public  AutoCmdExecEnd)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｽﾚｯﾄﾞ生成元に終了を通知
    ''' </summary>
    ''' <param name="AutoCmdExecObject">自動実行ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="AutoCmdExecTHread">自動実行ｽﾚｯﾄﾞｽﾃｰﾀｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AutoCmdExecEnd(ByVal AutoCmdExecObject As AutoCmdExec, ByVal AutoCmdExecTHread As Thread)
        Try
            '書込ﾛｯｸを取得
            _threadListLock.AcquireWriterLock(-1)

            'ｽﾚｯﾄﾞﾘｽﾄから削除
            _threadList.Remove(AutoCmdExecTHread.GetHashCode)
            _activeClientAnswerList.Remove(AutoCmdExecObject)

            '書込ﾛｯｸを解除
            _threadListLock.ReleaseWriterLock()
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  ｽﾚｯﾄﾞ強制終了            (Public  Cancel)"
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

#Region "  ｽﾚｯﾄﾞ終了判定            (Private CheckAllComplete)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｽﾚｯﾄﾞ終了判定
    ''' </summary>
    ''' <returns>True : 終了  False : 未終了</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function CheckAllComplete() As Boolean
        Dim strType As String = ""
        Try
            Dim objClAns As ClientAnswer
            Dim objAtCmd As AutoCmdExec
            Dim objObject As Object
            Dim blnRet As Boolean = True

            '読込ﾛｯｸを取得
            _threadListLock.AcquireReaderLock(-1)

            Try
                For Each objObject In _activeClientAnswerList
                    strType = objObject.GetType.ToString
                    If strType = "CmdMain.ClientAnswer" Then
                        objClAns = objObject
                        If objClAns.Id <> 0 Then
                            blnRet = False
                            objClAns.Dispose()
                            Exit For
                        End If
                        objClAns.Dispose()
                    ElseIf strType = "CmdMain.AutoCmdExec" Then
                        objAtCmd = objObject
                        If objAtCmd.Id <> 0 Then
                            blnRet = False
                            objAtCmd.Dispose()
                            Exit For
                        End If
                        objAtCmd.Dispose()
                    End If
                Next
            Finally
                objClAns = Nothing
                objAtCmd = Nothing
                objObject = Nothing
            End Try

            '読込ﾛｯｸを開放
            _threadListLock.ReleaseReaderLock()

            Return blnRet
        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Function
#End Region

#Region "  ｴﾗｰ時 共通ﾓｼﾞｭｰﾙ         (Private ComError)"
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

#Region "  ﾛｸﾞ書込み処理            (Public  AddToLog)"
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
            If Owner Is Nothing = False Then
                Owner.AddToLog(strMsg, strProd, intType)
            End If
        Catch e As Exception
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

End Class
