'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｸﾗｲｱﾝﾄ返答処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports UserProcess
Imports MateCommon.clsConst
Imports MateCommon
Imports JobCommon
#End Region

Public Class ClientAnswer
    Implements IDisposable

#Region "  共通変数"
    Private threadId As Integer                         'ｽﾚｯﾄﾞID
    Private Owner As ManagerMain                        'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ
    Private mobjDb As clsConn                           'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ
    Private mobjDbLog As clsConn                        'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)
    Private handler As Socket                           '返信用ｿｹｯﾄ情報
    Private allDone As New ManualResetEvent(False)      'ｽﾚｯﾄﾞ状態
    Private msgRecv As String                           '受信ﾒｯｾｰｼﾞ
    Private disposed As Boolean = False                 'ﾃﾞｨｽﾎﾟｰｽﾞFlag
#End Region

#Region "  委譲"
    '開始時、終了時の処理委譲
    Private objOnClientAnswerStart As ClientAnswerStart
    Private objOnClientAnswerEnd As ClientAnswerEnd
    Public Delegate Sub ClientAnswerStart(ByVal ClientAnswerObject As ClientAnswer, ByVal ClientAnswerTHread As Thread)
    Public Delegate Sub ClientAnswerEnd(ByVal ClientAnswerObject As ClientAnswer, ByVal ClientAnswerTHread As Thread)
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
    ''' <summary>Property OnClientAnswerStart</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OnClientAnswerStart( _
       ) As ClientAnswerStart
        Get
            Return objOnClientAnswerStart
        End Get
        Set(ByVal Value As ClientAnswerStart)
            objOnClientAnswerStart = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>Property OnClientAnswerEnd</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OnClientAnswerEnd( _
      ) As ClientAnswerEnd
        Get
            Return objOnClientAnswerEnd
        End Get
        Set(ByVal Value As ClientAnswerEnd)
            objOnClientAnswerEnd = Value
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
    ''' <param name="objDbLog">DB接続ｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)</param>
    ''' <param name="objSock">ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="cmdRecv">受信ﾒｯｾｰｼﾞ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As ManagerMain, ByVal objDb As clsConn, ByVal objDbLog As clsConn, ByVal objSock As Socket, ByVal cmdRecv As String)
        Try
            'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ定義
            Owner = objOwner
            mobjDb = objDb
            mobjDbLog = objDbLog
            handler = objSock
            msgRecv = cmdRecv
        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

#Region "  ﾃﾞｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｽﾄﾗｸﾀ"
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

                    'ｵﾌﾞｼﾞｪｸﾄ開放
                    Owner = Nothing
                    mobjDb = Nothing
                    mobjDbLog = Nothing
                    handler = Nothing
                    allDone = Nothing
                    msgRecv = Nothing
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

#Region "  ｸﾗｲｱﾝﾄ受信処理開始                           (Public  Start)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾗｲｱﾝﾄ受信処理開始
    ''' </summary>
    ''' <param name="state">ｽﾃｰﾀｽｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Start(ByVal state As Object)
        Try
            '開始時処理委譲
            If Not objOnClientAnswerStart Is Nothing Then objOnClientAnswerStart.Invoke(Me, Thread.CurrentThread)

            '送信ﾃﾞｰﾀ
            Dim content As [String] = [String].Empty

            'ｸﾗｲｱﾝﾄへ返信
            Dim objCmd As New cmd_manage(Me, mobjDb, mobjDbLog)
            objCmd.ExecCmd(msgRecv, content)

            'ｸﾗｲｱﾝﾄへ返信
            Send(handler, content)

            objCmd = Nothing

            '終了時処理委譲
            If Not objOnClientAnswerEnd Is Nothing Then objOnClientAnswerEnd.Invoke(Me, Thread.CurrentThread)
        Catch e As Exception
            ComError(e)
        End Try

    End Sub
#End Region

#Region "  返信処理                                     (Private Send)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 返信処理
    ''' </summary>
    ''' <param name="objHandler">ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="data">送信ﾒｯｾｰｼﾞ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Send(ByVal objHandler As Socket, ByVal data As [String])
        Try
            'ﾊﾞｲﾄ配列に変換
            Dim byteData As Byte() = Encoding.Default.GetBytes(data)

            '接続されている Socket にﾃﾞｰﾀを非同期的に送信
            objHandler.BeginSend(byteData, 0, byteData.Length, 0, New AsyncCallback(AddressOf SendCallback), objHandler)
        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

#Region "  非同期送信の完了時に呼び出されるｺｰﾙﾊﾞｯｸ      (Private Send)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 非同期送信の完了時に呼び出されるｺｰﾙﾊﾞｯｸ
    ''' </summary>
    ''' <param name="ar">非同期操作のｽﾃｰﾀｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendCallback(ByVal ar As IAsyncResult)
        Try
            'ｽﾃｰﾄｵﾌﾞｼﾞｪｸﾄ取り出し
            Dim objHandler As Socket = CType(ar.AsyncState, Socket)

            '保留中の非同期送信を終了
            Dim bytesSent As Integer = objHandler.EndSend(ar)

            objHandler.Shutdown(SocketShutdown.Both)
            objHandler.Close()
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

#Region "                                  (Public  AddToLog)"
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
