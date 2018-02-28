'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｿｹｯﾄ送受信処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports System.Runtime.Remoting.Lifetime
Imports System.Security.Permissions
#End Region

Public Class SendRecv
    Inherits MarshalByRefObject
    Implements IDisposable

#Region "  共通変数"
    Private Owner As ManagerMain                            'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ
    Private mobjDb As clsConn                               'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ
    Private mobjDbLog As clsConn                            'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)追加
    Private data As String = Nothing                        '受信ﾃﾞｰﾀ
    Private allDone As New ManualResetEvent(False)          'ｽﾚｯﾄﾞ状態
    Private _isCancelled As Boolean = False                 '中止ﾌﾗｸﾞ
    Private _isEnded As Boolean = False                     '終了ﾌﾗｸﾞ
    Private _threadID As Integer = 0                        'ｽﾚｯﾄﾞID
    Private endCounter As Integer = 0                       'ｽﾚｯﾄﾞ終了ｶｳﾝﾀ
    Private _threadListLock As New ReaderWriterLock         'ﾛｯｸ定義
    Private _threadList As New Hashtable                    '実行中ｽﾚｯﾄﾞﾘｽﾄ
    Private _activeClientAnswerList As New ArrayList        '実行中ｽﾚｯﾄﾞﾘｽﾄ
    Private disposed As Boolean = False                     'ﾃﾞｨｽﾎﾟｰｽﾞFlag
#End Region

#Region "  委譲"
    '開始時、終了時の処理委譲
    Private objOnSendRecvStart As SendRecvStart
    Private objOnSendRecvEnd As SendRecvEnd
    Public Delegate Sub SendRecvStart(ByVal SendRecvObject As SendRecv, ByVal SendRecvTHread As Thread)
    Public Delegate Sub SendRecvEnd(ByVal SendRecvObject As SendRecv, ByVal SendRecvTHread As Thread)
#End Region

#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    ''' =======================================
    ''' <summary>Property OnSendRecvStart</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OnSendRecvStart( _
       ) As SendRecvStart
        Get
            Return objOnSendRecvStart
        End Get
        Set(ByVal Value As SendRecvStart)
            objOnSendRecvStart = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>Property    OnSendRecvEnd</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OnSendRecvEnd( _
      ) As SendRecvEnd
        Get
            Return objOnSendRecvEnd
        End Get
        Set(ByVal Value As SendRecvEnd)
            objOnSendRecvEnd = Value
        End Set
    End Property
#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objOra">DB接続ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objOraLog">DB接続ｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As ManagerMain, ByVal objOra As clsConn, ByVal objOraLog As clsConn)
        Try
            'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ定義
            Owner = objOwner
            mobjDb = objOra
            mobjDbLog = objOraLog
        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

#Region "  "
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

#Region "  ﾒｯｾｰｼﾞ受信・返答処理開始                     (Public  Start)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｯｾｰｼﾞ受信・返答処理開始
    ''' </summary>
    ''' <param name="state">ｽﾃｰﾀｽｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Start(ByVal state As Object)
        Try
            '開始時処理委譲
            If Not objOnSendRecvStart Is Nothing Then objOnSendRecvStart.Invoke(Me, Thread.CurrentThread)

            'IPアドレス , PORT 設定
            Dim localEndPoint As New IPEndPoint(IPAddress.Any, ConfigFile.ListenerPort_DISP)

            'TCP/IP socket 初期化
            Dim listener As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

            'エンドポイントと関連付
            listener.Bind(localEndPoint)

            '保留中の接続のキューの最大長
            listener.Listen(ConfigFile.ListenerQue)

            While Not _isCancelled
                ' ｲﾍﾞﾝﾄの状態を非ｼｸﾞﾅﾙ状態に設定
                allDone.Reset()

                ' 受信接続の試行を受け入れる非同期操作を開始
                listener.BeginAccept(New AsyncCallback(AddressOf AcceptCallback), listener)

                ' ｼｸﾞﾅﾙを受信するまで現在のｽﾚｯﾄﾞをブﾛｯｸ
                allDone.WaitOne()
            End While

            '終了時処理委譲
            If Not objOnSendRecvEnd Is Nothing Then objOnSendRecvEnd.Invoke(Me, Thread.CurrentThread)

            '終了ﾌﾗｸﾞ設定
            _isEnded = True
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  受信処理                                     (Public  AcceptCallback)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 受信処理
    ''' </summary>
    ''' <param name="ar">非同期操作のｽﾃｰﾀｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AcceptCallback(ByVal ar As IAsyncResult)
        Try
            'ｲﾍﾞﾝﾄの状態をｼｸﾞﾅﾙ状態に設定
            allDone.Set()

            '受信接続の試行を非同期的に受け入れ、新しい Socket を作成
            Dim listener As Socket = CType(ar.AsyncState, Socket)
            Dim handler As Socket = listener.EndAccept(ar)

            'ｽﾃｰﾄｵﾌﾞｼﾞｪｸﾄ設定
            Dim state As New StateObject
            state.workSocket = handler

            '接続されている Socket からの非同期のﾃﾞｰﾀ受信を開始
            handler.BeginReceive(state.buffer, 0, state.BufferSize, 0, New AsyncCallback(AddressOf ReadCallback), state)
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  非同期受信の完了時に呼び出されるｺｰﾙﾊﾞｯｸ      (Public  ReadCallback)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 非同期受信の完了時に呼び出されるｺｰﾙﾊﾞｯｸ
    ''' </summary>
    ''' <param name="ar">非同期操作のｽﾃｰﾀｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ReadCallback(ByVal ar As IAsyncResult)
        Try
            Dim content As [String] = [String].Empty

            'ｽﾃｰﾄｵﾌﾞｼﾞｪｸﾄ取り出し
            Dim state As StateObject = CType(ar.AsyncState, StateObject)
            Dim handler As Socket = state.workSocket

            'ｸﾗｲｱﾝﾄからのﾃﾞｰﾀを読み込む
            Dim bytesRead As Integer = handler.EndReceive(ar)

            If bytesRead > 0 Then
                'コードページに対してエンコードされるﾊﾞｲﾄ配列の変換
                state.sb.Append(Encoding.Default.GetString(state.buffer, 0, bytesRead))

                '文字列変換
                content = state.sb.ToString()

                If Integer.MaxValue = _threadID Then
                    _threadID = 1
                Else
                    _threadID += 1
                End If
                Dim objClAns As New ClientAnswer(Owner, mobjDb, mobjDbLog, handler, content)
                objClAns.OnClientAnswerStart = AddressOf ClientAnswerStart
                objClAns.OnClientAnswerEnd = AddressOf ClientAnswerEnd
                objClAns.Id = _threadID
                objClAns.Go()
            End If
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  ｽﾚｯﾄﾞ生成元に開始を通知                      (Public  ClientAnswerStart)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｽﾚｯﾄﾞ生成元に開始を通知
    ''' </summary>
    ''' <param name="ClientAnswerObject">返答ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="ClientAnswerTHread">返答ｽﾚｯﾄﾞｽﾃｰﾀｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ClientAnswerStart(ByVal ClientAnswerObject As ClientAnswer, ByVal ClientAnswerTHread As Thread)
        Try
            '書込ﾛｯｸを取得


            _threadListLock.AcquireWriterLock(-1)

            'ｽﾚｯﾄﾞﾘｽﾄに登録
            Try
                _threadList.Add(ClientAnswerTHread.GetHashCode, ClientAnswerObject.Id)
            Catch
                _threadList.Item(ClientAnswerTHread.GetHashCode) = ClientAnswerObject.Id
            End Try
            _activeClientAnswerList.Add(ClientAnswerObject)

            '書込ﾛｯｸを解除
            _threadListLock.ReleaseWriterLock()
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  ｽﾚｯﾄﾞ生成元に終了を通知                      (Public  ClientAnswerEnd)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｽﾚｯﾄﾞ生成元に終了を通知
    ''' </summary>
    ''' <param name="ClientAnswerObject">返答ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="ClientAnswerTHread">返答ｽﾚｯﾄﾞｽﾃｰﾀｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ClientAnswerEnd(ByVal ClientAnswerObject As ClientAnswer, ByVal ClientAnswerTHread As Thread)
        Try
            '書込ﾛｯｸを取得


            _threadListLock.AcquireWriterLock(-1)

            'ｽﾚｯﾄﾞﾘｽﾄから削除
            _threadList.Remove(ClientAnswerTHread.GetHashCode)
            _activeClientAnswerList.Remove(ClientAnswerObject)

            '書込ﾛｯｸを解除
            _threadListLock.ReleaseWriterLock()
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

#Region "  ｽﾚｯﾄﾞ終了判定                                (Public  CheckAllComplete)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｽﾚｯﾄﾞ終了判定
    ''' </summary>
    ''' <returns>True : 終了  False : 未終了</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function CheckAllComplete() As Boolean
        Try
            Dim objClAns As ClientAnswer
            Dim blnRet As Boolean = True

            '読込ﾛｯｸを取得
            _threadListLock.AcquireReaderLock(-1)

            For Each objClAns In _activeClientAnswerList
                If objClAns.Id <> 0 Then
                    blnRet = False
                    Exit For
                End If
            Next

            '読込ﾛｯｸを開放
            _threadListLock.ReleaseReaderLock()

            Return blnRet
        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Function
#End Region

#Region "  ｴﾗｰ時共通ﾓｼﾞｭｰﾙ                              (Public  ComError)"
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

#Region "  ﾛｸﾞ書き込み処理                              (Public  AddToLog)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書き込み処理
    ''' </summary>
    ''' <param name="strMsg">ﾛｸﾞ書込ﾒｯｾｰｼﾞ</param>
    ''' <param name="strProd"></param>
    ''' <param name="intType">ﾒｯｾｰｼﾞ区分 0:情報 1:ﾕｰｻﾞｴﾗｰ 2:ｼｽﾃﾑｴﾗｰ</param>
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
