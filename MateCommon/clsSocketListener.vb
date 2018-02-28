'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｿｹｯﾄﾘｽﾅｰｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

Imports MateCommon.clsConst
Imports MateCommon
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class clsSocketListener

#Region "  共通変数、共通定数"

    '***********************************************************************************************
    '共通変数
    '***********************************************************************************************
    'ﾌﾟﾛﾊﾟﾃｨ変数
    Private mobjOwner As Object                 'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Private mintPortNo As Integer               '受信待ﾎﾟｰﾄNo
    Private mstrSendText As String              '送信ﾃｷｽﾄ
    Private mstrRecvText As String              '受信ﾃｷｽﾄ
    Private mbytSendText() As Byte              '送信ﾊﾞｲﾄ配列
    Private mbytRecvText() As Byte              '受信ﾊﾞｲﾄ配列
    Private mintRET As RetCode                  '処理結果
    Private mintBackLog As Integer              '保留中の接続のｷｭｰの最大長
    Private mudtConnection As Connection_Status '接続されているかどうかのｽﾃｰﾀｽ
    Private mintCodePage As Integer             '通信に使用するﾃｷｽﾄのｺｰﾄﾞ
    Private mintDebugFlag As Integer            'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ

    'ｿｹｯﾄ
    Private mobjSocket As Socket                '常時待機用ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ
    Private mobjConnSocket As Socket            '新しく作成された接続に対して新しい Socket を作成


    '***********************************************************************************************
    '共通定数
    '***********************************************************************************************
    Private Const LOGFILE_NAME_DEFAULT As String = "clsSocketRecv.log"              '『ﾃﾞﾌｫﾙﾄ』ﾛｸﾞﾌｧｲﾙ名
    Private Const LOGFILE_NAME_OLD_DEFAULT As String = "clsSocketRecv_OLD.log"      '『ﾃﾞﾌｫﾙﾄ』ﾛｸﾞﾌｧｲﾙ名_OLD
    Private Const LOGFILE_SIZE_DEFAULT As Integer = 5000000                         '『ﾃﾞﾌｫﾙﾄ』ﾛｸﾞﾌｧｲﾙｻｲｽﾞ
    Private Const BACKLOG_DEFAULT As Integer = 100                                  '『ﾃﾞﾌｫﾙﾄ』保留中の接続のｷｭｰの最大長
    Private Const TIMEOUT_DEFAULT As Integer = 5000                                 '『ﾃﾞﾌｫﾙﾄ』ﾀｲﾑｱｳﾄ時間（ms）

    '列挙体
    Public Enum RetCode
        OK = 1                      '正常終了
        NG = 2                      'ﾌﾟﾛｸﾞﾗﾑ上でのｴﾗｰ
        ReceiveTimeOut = 3          'ﾀｲﾑｱｳﾄ
        ConnectError = 4            '接続ｴﾗｰ
        PropertyError = 5           'ﾌﾟﾛﾊﾟﾃｨｴﾗｰ
        RecvConnNothing = 6         '接続ｿｹｯﾄなし
        RecvDataNothing = 7         '受信ﾊﾞｯﾌｧなし
        RecvConnNew = 8             'ｿｹｯﾄ接続初期化
    End Enum

    Public Enum Connection_Status
        YES = 1                     '接続されている
        NO = 2                      '接続されていない
    End Enum

#End Region

#Region "  ﾌﾟﾛﾊﾟﾃｨ"

    ''' =======================================
    ''' <summary>受信待ﾎﾟｰﾄNoc</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intPortNo() As Integer
        Get
            Return mintPortNo
        End Get
        Set(ByVal Value As Integer)
            mintPortNo = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>送信ﾃｷｽﾄ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strSendText() As String
        Get
            Return mstrSendText
        End Get
        Set(ByVal Value As String)
            mstrSendText = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>受信ﾃｷｽﾄ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strRecvText() As String
        Get
            Return mstrRecvText
        End Get
        '''''Set(ByVal Value As String)
        '''''    mstrRECV_TEXT = Value
        '''''End Set
    End Property

    ''' =======================================
    ''' <summary>送信ﾊﾞｲﾄ配列</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property bytSendText() As Byte()
        Get
            Return mbytSendText
        End Get
        Set(ByVal Value As Byte())
            mbytSendText = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>受信ﾊﾞｲﾄ配列</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property bytRecvText() As Byte()
        Get
            Return mbytRecvText
        End Get
        '''''Set(ByVal Value As String)
        '''''    mstrRECV_TEXT = Value
        '''''End Set
    End Property

    ''' =======================================
    ''' <summary>処理結果</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property udtRET() As RetCode
        Get
            Return mintRET
        End Get
        ''Set(ByVal Value As RetCode)
        ''    mintRET = Value
        ''End Set
    End Property

    '' '' ''Public Property strLogFileName() As String
    '' '' ''    Get
    '' '' ''        Return mstrLOGFILE_NAME
    '' '' ''    End Get
    '' '' ''    Set(ByVal Value As String)
    '' '' ''        mstrLOGFILE_NAME = Value
    '' '' ''    End Set
    '' '' ''End Property

    '' '' ''Public Property strLogFileNameOld() As String
    '' '' ''    Get
    '' '' ''        Return mstrLOGFILE_NAME_OLD
    '' '' ''    End Get
    '' '' ''    Set(ByVal Value As String)
    '' '' ''        mstrLOGFILE_NAME_OLD = Value
    '' '' ''    End Set
    '' '' ''End Property

    '' '' ''Public Property intLogFileSize() As Integer
    '' '' ''    Get
    '' '' ''        Return mintLOGFILE_SIZE
    '' '' ''    End Get
    '' '' ''    Set(ByVal Value As Integer)
    '' '' ''        mintLOGFILE_SIZE = Value
    '' '' ''    End Set
    '' '' ''End Property

    ''' =======================================
    ''' <summary>保留中の接続のｷｭｰの最大長</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intBackLog() As Integer
        Get
            Return mintBackLog
        End Get
        Set(ByVal Value As Integer)
            mintBackLog = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>接続されているかどうかのｽﾃｰﾀｽ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property udtConnection() As Connection_Status
        Get
            Return mudtConnection
        End Get
        Set(ByVal Value As Connection_Status)
            mudtConnection = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>通信に使用するﾃｷｽﾄのｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intCodePage() As Integer
        Get
            Return mintCodePage
        End Get
        Set(ByVal Value As Integer)
            mintCodePage = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intDebugFlag() As Integer
        Get
            Return mintDebugFlag
        End Get
        Set(ByVal Value As Integer)
            mintDebugFlag = Value
        End Set
    End Property

#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object)

        ''MyBase.New()

        Try

            '***************************************
            ' 色々初期化
            '***************************************
            mintPortNo = -1            '送信先ﾎﾟｰﾄNo
            mstrSendText = ""          '送信ﾃｷｽﾄ
            mbytSendText = Nothing     '送信ﾊﾞｲﾄ配列
            mbytRecvText = Nothing     '受信ﾊﾞｲﾄ配列
            mintRET = RetCode.OK                                '処理結果
            mintBackLog = BACKLOG_DEFAULT                       '保留中の接続のｷｭｰの最大長
            mudtConnection = Connection_Status.NO               '接続されているかどうかのｽﾃｰﾀｽ
            mobjOwner = objOwner                                'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ


            mintRET = RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region

#Region "  待機　　                             処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 待機　処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Listen()
        Try

            '*************************************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '*************************************************
            If mintPortNo = -1 Then
                mintRET = RetCode.PropertyError
                Throw New Exception("ﾌﾟﾛﾊﾟﾃｨｴﾗｰ")

            End If


            '*************************************************
            'EndPoint取得
            '*************************************************
            Dim localEndPoint As IPEndPoint                                 'IPｱﾄﾞﾚｽ、PORT 設定
            localEndPoint = New IPEndPoint(IPAddress.Any, _
                                           mintPortNo)


            '*************************************************
            ' 受信用ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ        生成
            '*************************************************
            mobjSocket = New Socket(AddressFamily.InterNetwork, _
                                    SocketType.Stream, _
                                    ProtocolType.Tcp)                   'TCP/IP socket 初期化
            mobjSocket.Bind(localEndPoint)                              'ｴﾝﾄﾞﾎﾟｲﾝﾄと関連付
            mobjSocket.Listen(Val(mintBackLog))                         '保留中の接続のｷｭｰの最大長


            '*************************************************
            ' ﾛｸﾞ出力
            '*************************************************
            Call AddToLog("ﾘｽﾅｰﾎﾟｰﾄを開設しました   ﾎﾟｰﾄNo:" & mintPortNo)


            mintRET = RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region

#Region "  切断　　                             処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 切断　処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Shutdown()
        Try

            '*************************************************
            '切断
            '*************************************************
            '===================================
            '常時待機用ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ
            '===================================
            If IsNothing(mobjSocket) = False Then
                '''''mobjSocket.Shutdown(SocketShutdown.Receive)
                mobjSocket.Close()
            End If

            '===================================================
            '新しく作成された接続に対して新しい Socket を作成
            '===================================================
            If IsNothing(mobjConnSocket) = False Then
                mobjConnSocket.Shutdown(SocketShutdown.Receive)
                mobjConnSocket.Close()
            End If

            mobjSocket = Nothing
            mobjConnSocket = Nothing


            '*************************************************
            ' 接続ﾌﾗｸﾞ = ｵﾌ
            '*************************************************
            mudtConnection = Connection_Status.NO


            '*************************************************
            ' ﾛｸﾞ出力
            '*************************************************
            Call AddToLog("ﾘｽﾅｰﾎﾟｰﾄを切断しました   ﾎﾟｰﾄNo:" & mintPortNo)


            mintRET = RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region

#Region "  ｿｹｯﾄﾃﾞｰﾀ取得                         処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 「mobjSocket」がﾈｯﾄﾜｰｸから受信したﾃﾞｰﾀを取得します
    ''' </summary>
    ''' <param name="intByte">取得するﾊﾞｲﾄ数（-1以下の時は全ﾊﾞｲﾄ数を取得）ﾃﾞﾌｫﾙﾄ = -1</param>
    ''' <remarks>【注意】###########必ず読んで下さい！############################
    '''                  ｸﾗｲｱﾝﾄから接続された時、前回の接続情報はすべて破棄されます！
    '''                  複数ｸﾗｲｱﾝﾄからの接続に対しては、動作は保障出来ません！
    '''                  ###########必ず読んで下さい！############################
    ''' </remarks>
    ''' *******************************************************************************************************************
    Public Sub Receive(Optional ByVal intByte As Integer = -1)
        Try
            '*************************************************
            ' 色々初期化
            '*************************************************
            mstrRecvText = ""
            mbytRecvText = Nothing


            '*************************************************
            ' ｸﾗｲｱﾝﾄからの接続確認
            '*************************************************
            Select Case mudtConnection
                Case Connection_Status.YES
                    If mobjSocket.Poll(0, SelectMode.SelectRead) = True Then
                        '=============================================================
                        ' 新しく作成された接続に対して新しい Socket を作成
                        '=============================================================
                        mobjConnSocket.Shutdown(SocketShutdown.Both)
                        mobjConnSocket.Close()
                        mobjConnSocket = Nothing
                        mobjConnSocket = mobjSocket.Accept()
                        AddToLog("新しい接続を確認しました  ﾎﾟｰﾄNo:" & mintPortNo)      'ﾛｸﾞ書込み
                        mintRET = RetCode.RecvConnNew
                        Exit Sub
                    End If

                Case Connection_Status.NO
                    If mobjSocket.Poll(0, SelectMode.SelectRead) = True Then
                        mudtConnection = Connection_Status.YES
                    Else
                        mintRET = RetCode.RecvConnNothing
                        Exit Sub
                    End If

                    '=============================================================
                    ' 新しく作成された接続に対して新しい Socket を作成
                    '=============================================================
                    mobjConnSocket = mobjSocket.Accept()
                    AddToLog("接続を確認しました  ﾎﾟｰﾄNo:" & mintPortNo)                    'ﾛｸﾞ書込み
                    mintRET = RetCode.RecvConnNew
                    Exit Sub

            End Select


            '*************************************************
            ' 受信ﾃﾞｰﾀをﾃｷｽﾄ化
            ' 「RECV_TEXT」ﾌﾟﾛﾊﾟﾃｨにｾｯﾄ
            '*************************************************
            While mobjConnSocket.Available = 0
                mintRET = RetCode.RecvDataNothing
                Exit Sub
            End While

            '==========================================
            ' 受信ﾊﾞｲﾄ数ｾｯﾄ
            '==========================================
            Dim intGetByte As Integer       '受信ﾊﾞｲﾄ数ｾｯﾄ
            Select Case intByte < 0
                Case True
                    intGetByte = mobjConnSocket.Available
                Case False
                    Select Case mobjConnSocket.Available < intByte
                        Case True
                            intGetByte = mobjConnSocket.Available
                        Case False
                            intGetByte = intByte
                    End Select
            End Select


            '==========================================
            ' ﾃﾞｰﾀ受信
            '==========================================
            Dim Buffer_Recv() As Byte           '受信用ﾊﾞｯﾌｧ
            ReDim Buffer_Recv(intGetByte - 1)
            mobjConnSocket.Receive(Buffer_Recv, _
                                   0, _
                                   intGetByte, _
                                   SocketFlags.None)                    '受信
            mbytRecvText = Buffer_Recv                              'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
            mstrRecvText = ByteToString(Buffer_Recv)                'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ


            mintRET = RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region

#Region "  ｿｹｯﾄﾃﾞｰﾀ送信                         処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄﾃﾞｰﾀ送信 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Send()
        Try
            Dim intRet As Integer
            Dim BufferSend() As Byte           '送信用ﾊﾞｯﾌｧ


            '*************************************************
            '事前ﾁｪｯｸ
            '*************************************************
            If IsNothing(mobjConnSocket) = True Then
                mintRET = RetCode.ConnectError
                Call AddToLog("ｿｹｯﾄ接続ｴﾗｰ。現在接続されているｿｹｯﾄはありません。")
                Exit Sub
            End If


            '*************************************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '*************************************************
            If IsNull(mstrSendText) And IsNull(mbytSendText) Then
                mintRET = RetCode.PropertyError
                Call AddToLog("送信ﾃｷｽﾄﾌﾟﾛﾊﾟﾃｨにﾃｷｽﾄがｾｯﾄされていません。送信ﾃｷｽﾄﾌﾟﾛﾊﾟﾃｨに送信ﾃｷｽﾄをｾｯﾄして下さい。")
                Exit Sub
            End If


            '*************************************************
            '送信
            '*************************************************
            If IsNotNull(mbytSendText) Then
                BufferSend = mbytSendText
            Else
                BufferSend = StringToByte(mstrSendText)
            End If
            '送信
            intRet = mobjConnSocket.Send(BufferSend _
                                       , 0 _
                                       , BufferSend.Length _
                                       , SocketFlags.None _
                                       )


            '*************************************************
            '送信出来なかった分のｿｹｯﾄ送信
            '*************************************************
            Dim ii As Integer = 0          'ﾙｰﾌﾟのｶｳﾝﾀ
            While intRet <> BufferSend.Length
                Dim BufferSend2() As Byte = BufferSend              '送信用ﾊﾞｯﾌｧ作成用ﾊﾞｯﾌｧ
                ReDim BufferSend(UBound(BufferSend2) - intRet)      '送信用ﾊﾞｯﾌｧ初期化

                'ｿｹｯﾄ送信失敗したﾊﾞｲﾄ配列作成
                Array.Copy(BufferSend2, _
                           intRet, _
                           BufferSend, _
                           0, _
                           BufferSend2.Length - intRet _
                           )

                intRet = mobjConnSocket.Send(BufferSend, _
                                             0, _
                                             BufferSend.Length, _
                                             SocketFlags.None)              '送信


                ii += 1
                Call AddToLog("一度でｿｹｯﾄを送信出来なかった為、分割して送りました。　" & ii & "回目   ﾎﾟｰﾄNo:" & mintPortNo)
                If 100 <= ii Then Throw New Exception(ii & "回分割して送信しても、送信出来ませんでした")
            End While


            mintRET = RetCode.OK
        Catch ex As SocketException
            Call AddToLog(ex.Message & "   ﾎﾟｰﾄNo:" & mintPortNo)
            mintRET = RetCode.NG

        Catch ex As ArgumentNullException
            Call AddToLog(ex.Message & "   ﾎﾟｰﾄNo:" & mintPortNo)
            mintRET = RetCode.NG

        Catch ex As ArgumentOutOfRangeException
            Call AddToLog(ex.Message & "   ﾎﾟｰﾄNo:" & mintPortNo)
            mintRET = RetCode.NG

        Catch ex As ObjectDisposedException
            Call AddToLog(ex.Message & "   ﾎﾟｰﾄNo:" & mintPortNo)
            mintRET = RetCode.NG

        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region


#Region "  ﾊﾞｲﾄ配列 → 文字列"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｲﾄ配列 → 文字列
    ''' </summary>
    ''' <param name="bytData">変換するﾊﾞｲﾄ配列</param>
    ''' <returns>変換した文字列</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ByteToString(ByVal bytData() As Byte) As String
        Dim strRet As String

        strRet = Text.Encoding.GetEncoding(mintCodePage).GetString(bytData, 0, bytData.Length)

        Return (strRet)
    End Function
#End Region

#Region "  文字列 → ﾊﾞｲﾄ配列"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 文字列 → ﾊﾞｲﾄ配列
    ''' </summary>
    ''' <param name="strData">変換する文字列</param>
    ''' <returns>変換したﾊﾞｲﾄ配列</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function StringToByte(ByVal strData As String) As Byte()

        Dim bytRet() As Byte
        bytRet = Text.Encoding.GetEncoding(mintCodePage).GetBytes(strData)

        Return (bytRet)
    End Function
#End Region

#Region "  ｴﾗｰ処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="objException"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ComError(ByVal objException As Exception)

        '*****************************************************
        'ﾃｷｽﾄ生成
        '*****************************************************
        Dim strTemp As String
        Dim strStackTrace(0) As String
        strTemp = Replace(objException.StackTrace, ",", "，")       '半角ｶﾝﾏを全角ｶﾝﾏに変換
        strStackTrace = Split(strTemp, vbCrLf)

        '*****************************************************
        ' ﾛｸﾞ書込み
        '*****************************************************
        For ii As Integer = LBound(strStackTrace) To UBound(strStackTrace)
            AddToLog(objException.Message & "," & strStackTrace(ii))
        Next


        mintRET = RetCode.NG
    End Sub
#End Region

#Region "  ﾛｸﾞ書き込み処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書き込み処理
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)

        mobjOwner.AddToLog(strMsg_1)

    End Sub
#End Region

End Class
