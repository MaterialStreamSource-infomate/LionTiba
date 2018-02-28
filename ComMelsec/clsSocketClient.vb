'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｿｹｯﾄ送信ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text

Public Class clsSocketClient

#Region "  共通変数、共通定数"

    '***********************************************************************************************
    '共通変数
    '***********************************************************************************************
    'ﾌﾟﾛﾊﾟﾃｨ変数
    Protected mobjOwner As Object             'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Protected mstrAddress As String           '送信先ｱﾄﾞﾚｽ
    Protected mintPortNo As Integer           '送信先ﾎﾟｰﾄNo
    Protected mstrSendText As String          '送信ﾃｷｽﾄ
    Protected mstrRecvText As String          '受信ﾃｷｽﾄ（応答ｿｹｯﾄ）
    Protected mbytSendText() As Byte          '送信ﾊﾞｲﾄ配列
    Protected mbytRecvText() As Byte          '受信ﾊﾞｲﾄ配列
    Protected mudtRET As RetCode              '処理結果
    Private mintCodePage As Integer             '通信に使用するﾃｷｽﾄのｺｰﾄﾞ
    Private mintDebugFlag As Integer            'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
    Private mblnIsConnect As Boolean            'ｿｹｯﾄ接続ﾌﾗｸﾞ
    Private mintTimeOut As Integer              'ﾀｲﾑｱｳﾄ時間（ms）

    'その他
    Protected mobjSocket As Socket            '常時接続用ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ
    Protected mobjEncode As Encoding          'ｴﾝｺｰﾄﾞ


    '***********************************************************************************************
    '共通定数
    '***********************************************************************************************
    '列挙体
    Public Enum RetCode
        OK = 1                      '正常終了
        NG = 2                      'ﾌﾟﾛｸﾞﾗﾑ上でのｴﾗｰ
        ReceiveTimeOut = 3          'ﾀｲﾑｱｳﾄ
        ConnectError = 4            '接続ｴﾗｰ
        PropertyError = 5           'ﾌﾟﾛﾊﾟﾃｨｴﾗｰ
    End Enum


#End Region

#Region "  ﾌﾟﾛﾊﾟﾃｨ"

    ''' =======================================
    ''' <summary>送信先ｱﾄﾞﾚｽ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strAddress() As String
        Get
            Return mstrAddress
        End Get
        Set(ByVal Value As String)
            mstrAddress = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>送信先ﾎﾟｰﾄNo</summary>
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

    '' ''Public Property intTimeOut() As Integer
    '' ''    Get
    '' ''        Return mintTimeOut
    '' ''    End Get
    '' ''    Set(ByVal Value As Integer)
    '' ''        mintTimeOut = Value
    '' ''    End Set
    '' ''End Property

    ''' =======================================
    ''' <summary>処理結果</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property udtRet() As RetCode
        Get
            Return mudtRET
        End Get
    End Property

    '' ''Public Property strLogFileName() As String
    '' ''    Get
    '' ''        Return mstrLOGFILE_NAME
    '' ''    End Get
    '' ''    Set(ByVal Value As String)
    '' ''        mstrLOGFILE_NAME = Value
    '' ''    End Set
    '' ''End Property

    '' ''Public Property strLogFileNameOld() As String
    '' ''    Get
    '' ''        Return mstrLOGFILE_NAME_OLD
    '' ''    End Get
    '' ''    Set(ByVal Value As String)
    '' ''        mstrLOGFILE_NAME_OLD = Value
    '' ''    End Set
    '' ''End Property

    '' ''Public Property intLogFileSize() As Integer
    '' ''    Get
    '' ''        Return mintLOGFILE_SIZE
    '' ''    End Get
    '' ''    Set(ByVal Value As Integer)
    '' ''        mintLOGFILE_SIZE = Value
    '' ''    End Set
    '' ''End Property

    '' ''Public Property blnReceiveFlag() As Boolean
    '' ''    Get
    '' ''        Return mblnReceiveFlag
    '' ''    End Get
    '' ''    Set(ByVal Value As Boolean)
    '' ''        mblnReceiveFlag = Value
    '' ''    End Set
    '' ''End Property

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

    ''' =======================================
    ''' <summary>ｿｹｯﾄ接続ﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property blnIsConnect() As Boolean
        Get
            Return mblnIsConnect
        End Get
        '' ''Set(ByVal Value As Integer)
        '' ''    mintLogWrite = Value
        '' ''End Set
    End Property

    ''' =======================================
    ''' <summary>
    ''' ﾀｲﾑｱｳﾄ時間(ms)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intTimeOut() As Integer
        Get
            Return mintTimeOut
        End Get
        Set(ByVal Value As Integer)
            mintTimeOut = Value
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
        Try

            '***************************************
            ' 色々初期化
            '***************************************
            mstrAddress = ""            '送信先ｱﾄﾞﾚｽ
            mintPortNo = -1            '送信先ﾎﾟｰﾄNo
            mstrSendText = ""          '送信ﾃｷｽﾄ
            mbytSendText = Nothing     '送信ﾊﾞｲﾄ配列
            mbytRecvText = Nothing     '受信ﾊﾞｲﾄ配列

            '' ''mblnReceiveFlag = False                            '応答ｿｹｯﾄ待機ﾌﾗｸﾞ
            '' ''mintTimeOut = 5000                                 'ﾀｲﾑｱｳﾄ時間（ms）
            mudtRET = RetCode.OK                                '処理結果
            '' ''mstrLOGFILE_NAME = LOGFILE_NAME_DEFAULT             'ﾛｸﾞﾌｧｲﾙ名
            '' ''mstrLOGFILE_NAME_OLD = LOGFILE_NAME_OLD_DEFAULT     'ﾛｸﾞﾌｧｲﾙ名_Back
            '' ''mintLOGFILE_SIZE = LOGFILE_SIZE_DEFAULT             'ﾛｸﾞﾌｧｲﾙｻｲｽﾞ
            mobjEncode = Encoding.Default                        'ｴﾝｺｰﾄﾞ
            mobjOwner = objOwner                                'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ


            '***************************************
            ' ﾛｸﾞ書込みｸﾗｽ生成
            '***************************************
            '' ''mobjLogWrite = New clsWriteLog
            '' ''mobjLogWrite.clspFileName = mstrLOGFILE_NAME         'ﾌｧｲﾙ名         ｾｯﾄ
            '' ''mobjLogWrite.clspCopyFile = mstrLOGFILE_NAME_OLD     'ﾌｧｲﾙ名(古い)   ｾｯﾄ
            '' ''mobjLogWrite.clspMaxSize = mintLOGFILE_SIZE          '最大ﾌｧｲﾙｻｲｽﾞ   ｾｯﾄ


        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region

#Region "  接続　　                             処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 接続　処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Connect()
        Try
            Dim dtmNow As Date = Now            '現在時刻
            Dim objIpAddress As IPAddress          'IPｱﾄﾞﾚｽ取得
            'Dim localEndPoint As New IPEndPoint(Dns.Resolve(mstrADDRESS).AddressList(0), _
            '                                    mintPORT_NO)                               'IPｱﾄﾞﾚｽ、PORT 設定
            Dim localEndPoint As IPEndPoint                                                 'IPｱﾄﾞﾚｽ、PORT 設定


            '*************************************************
            'EndPoint取得
            '*************************************************
            Try
                objIpAddress = IPAddress.Parse(mstrAddress)
            Catch ex As FormatException
                'こっちでうまい事いく事がある
                objIpAddress = Dns.GetHostEntry(mstrAddress).AddressList(0)
            End Try

            localEndPoint = New IPEndPoint(objIpAddress, _
                                                   mintPortNo)

            ' '' ''*************************************************
            ' '' ''ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            ' '' ''*************************************************
            '' ''If mstrAddress = "" Or _
            '' ''   mintPortNo = -1 Then
            '' ''    mudtRET = RetCode.PropertyError
            '' ''    Exit Sub
            '' ''End If


            '*************************************************
            'ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ生成
            '*************************************************
            mobjSocket = New Socket(AddressFamily.InterNetwork, _
                                   SocketType.Stream, _
                                   ProtocolType.Tcp)


            '*************************************************
            'ｻｰﾊﾞｰ接続
            '*************************************************
            Try
                '===================================
                '接続
                '===================================
                mobjSocket.Connect(localEndPoint)            '接続
                If mobjSocket.Connected = False Then         '接続の確認
                    Throw New Exception("接続に失敗しました。")
                End If

            Catch ex As Exception
                '===================================
                'ﾛｸﾞ出力
                '===================================
                Dim strMessage As String = ""
                strMessage &= ex.Message
                strMessage &= "  ﾎﾟｰﾄNo：" & mintPortNo
                strMessage &= "  ｱﾄﾞﾚｽ：" & mstrAddress
                Call AddToLog(strMessage)

                '===================================
                '脱出
                '===================================
                mudtRET = RetCode.ConnectError
                mblnIsConnect = False
                Exit Sub

            End Try


            mblnIsConnect = True
            mudtRET = RetCode.OK
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
    Public Sub ShutDown()
        Try

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2015/08/24 CW6追加対応 ↓↓↓↓↓↓
            If IsNothing(mobjSocket) = False Then
                'JobMate:S.Ouchi 2015/08/24 CW6追加対応 ↑↑↑↑↑↑
                '↑↑↑↑↑↑************************************************************************************************************

                '*************************************************
                'ｻｰﾊﾞｰ切断
                '*************************************************
                mobjSocket.Shutdown(SocketShutdown.Both)
                mobjSocket.Close()

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2015/08/24 CW6追加対応 ↓↓↓↓↓↓
            End If
            'JobMate:S.Ouchi 2015/08/24 CW6追加対応 ↑↑↑↑↑↑
            '↑↑↑↑↑↑************************************************************************************************************


            mudtRET = RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Throw ex

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2015/08/24 CW6追加対応 ↓↓↓↓↓↓
        Finally
            mobjSocket = Nothing
            'JobMate:S.Ouchi 2015/08/24 CW6追加対応 ↑↑↑↑↑↑
            '↑↑↑↑↑↑************************************************************************************************************

        End Try
        mblnIsConnect = False
    End Sub
#End Region

#Region "  ｿｹｯﾄ送信(常時接続用)  　　           処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Send()
        Try
            Dim intRet As Integer
            Dim BufferSend() As Byte           '送信用ﾊﾞｯﾌｧ


            '*************************************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '*************************************************
            If IsNull(mstrSendText) And IsNull(mbytSendText) Then
                mudtRET = RetCode.PropertyError
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
            intRet = mobjSocket.Send(BufferSend _
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

                intRet = mobjSocket.Send(BufferSend, _
                                         0, _
                                         BufferSend.Length, _
                                         SocketFlags.None)              '送信


                ii += 1
                Call AddToLog("一度でｿｹｯﾄを送信出来なかった為、分割して送りました。　" & ii & "回目   ﾎﾟｰﾄNo:" & mintPortNo)
                If 100 <= ii Then Throw New Exception(ii & "回分割して送信しても、送信出来ませんでした")
            End While


            mudtRET = RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            mblnIsConnect = False
            Throw ex

        End Try
    End Sub
#End Region

#Region "  ｿｹｯﾄ受信(常時接続用)                 処理"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】intByte    ：取得するﾊﾞｲﾄ数（-1以下の時は全ﾊﾞｲﾄ数を取得）ﾃﾞﾌｫﾙﾄ = -1
    '【戻値】なし
    '*******************************************************************************************************************
    Public Function Receive(Optional ByVal intByte As Integer = -1) As RetCode
        Try
            Dim Buffer_Recv() As Byte           '受信用ﾊﾞｯﾌｧ
            Dim lngAvailable As Long
            Dim dtmTimeOut As Date
            Dim lngStAvailable As Long

            '*************************************************
            ' 色々初期化
            '*************************************************
            mstrRecvText = ""
            mbytRecvText = Nothing

            '*************************************************
            '受信
            '*************************************************
            lngAvailable = mobjSocket.Available
            dtmTimeOut = DateAdd(DateInterval.Second, mintTimeOut, Now)
            While lngAvailable = 0 And dtmTimeOut > Now
                lngAvailable = mobjSocket.Available
                System.Threading.Thread.Sleep(10)
            End While

            lngStAvailable = lngAvailable

            If mobjSocket.Available = 0 Then
                'ﾀｲﾑｱｳﾄ
                Throw New Exception("受信ﾀｲﾑｱｳﾄ")
            End If

            '==========================================
            ' 受信ﾊﾞｲﾄ数ｾｯﾄ
            '==========================================
            mstrRecvText = ""
            Dim intGetByte As Integer       '受信ﾊﾞｲﾄ数ｾｯﾄ

            While mobjSocket.Available > 0
                Select Case intByte < 0
                    Case True
                        intGetByte = mobjSocket.Available
                    Case False
                        Select Case mobjSocket.Available < intByte
                            Case True
                                intGetByte = mobjSocket.Available
                            Case False
                                intGetByte = intByte
                        End Select
                End Select

                ReDim Buffer_Recv(intGetByte - 1)
                mobjSocket.Receive(Buffer_Recv, _
                                   0, _
                                   intGetByte, _
                                   SocketFlags.None)                        '受信
                '----------------------
                'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(ﾊﾞｲﾄ)
                '----------------------
                If IsNull(mbytRecvText) Then
                    mbytRecvText = Buffer_Recv                                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
                Else
                    ReDim Preserve mbytRecvText(UBound(mbytRecvText) + Buffer_Recv.Length)                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
                    Array.Copy(Buffer_Recv, 0, mbytRecvText, UBound(mbytRecvText) + 1, Buffer_Recv.Length)  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
                End If
                '----------------------
                'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(文字列)
                '----------------------
                mstrRecvText &= mobjEncode.GetString(Buffer_Recv)            'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
                System.Threading.Thread.Sleep(10)
            End While
            Receive = RetCode.OK

        Catch ex As Exception
            Receive = RetCode.NG
            ' ''Call ComError(ex)
            ' ''Throw New Exception(ex.Message)

        End Try
    End Function
#End Region


#Region "  ｿｹｯﾄ送信(毎回接続、切断する画面用)   処理"
    ' '' '' ''*******************************************************************************************************************
    ' '' '' ''【機能】ｿｹｯﾄ送信処理
    ' '' '' ''【引数】
    ' '' '' ''【戻値】なし
    ' '' '' ''*******************************************************************************************************************
    '' '' ''Public Sub SendSock()
    '' '' ''    Try
    '' '' ''        Dim intRet As Integer
    '' '' ''        Dim dtmNow As Date = Now            '現在時刻
    '' '' ''        Dim Buffer_Send() As Byte           '送信用ﾊﾞｯﾌｧ
    '' '' ''        Dim Buffer_Recv() As Byte           '受信用ﾊﾞｯﾌｧ
    '' '' ''        Dim objIpAddress As IPAddress          'IPｱﾄﾞﾚｽ取得
    '' '' ''        'Dim localEndPoint As New IPEndPoint(Dns.Resolve(mstrADDRESS).AddressList(0), _
    '' '' ''        '                                    mintPORT_NO)                               'IPｱﾄﾞﾚｽ、PORT 設定
    '' '' ''        Dim localEndPoint As IPEndPoint                                                 'IPｱﾄﾞﾚｽ、PORT 設定
    '' '' ''        Dim objSocket As Socket = New Socket(AddressFamily.InterNetwork, _
    '' '' ''                                             SocketType.Stream, _
    '' '' ''                                             ProtocolType.Tcp)


    '' '' ''        '*************************************************
    '' '' ''        'EndPoint取得
    '' '' ''        '*************************************************
    '' '' ''        Try
    '' '' ''            objIpAddress = IPAddress.Parse(mstrAddress)
    '' '' ''        Catch ex As FormatException
    '' '' ''            Dim oLog As New clsWriteLog
    '' '' ''            oLog.WriteLog("IPｱﾄﾞﾚｽ Parse 異常 [" & ex.Message & "]")
    '' '' ''            objIpAddress = Dns.GetHostEntry(mstrAddress).AddressList(0)
    '' '' ''        End Try

    '' '' ''        localEndPoint = New IPEndPoint(objIpAddress, _
    '' '' ''                                               mintPortNo)

    '' '' ''        '*************************************************
    '' '' ''        'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
    '' '' ''        '*************************************************
    '' '' ''        If mstrAddress = "" Or _
    '' '' ''           mintPortNo = -1 Or _
    '' '' ''           mstrSendText = "" Then
    '' '' ''            mudtRET = RetCode.PropertyError
    '' '' ''            Exit Sub
    '' '' ''        End If


    '' '' ''        '*************************************************
    '' '' ''        'ｻｰﾊﾞｰ接続
    '' '' ''        '*************************************************
    '' '' ''        Try
    '' '' ''            objSocket.Connect(localEndPoint)            '接続
    '' '' ''            If objSocket.Connected = False Then         '接続の確認
    '' '' ''                Throw New Exception
    '' '' ''            End If
    '' '' ''        Catch ex As Exception
    '' '' ''            mudtRET = RetCode.ConnectError
    '' '' ''            Exit Sub
    '' '' ''        End Try


    '' '' ''        '*************************************************
    '' '' ''        '送信
    '' '' ''        '*************************************************
    '' '' ''        Buffer_Send = StringToByte(mstrSendText)
    '' '' ''        intRet = objSocket.Send(Buffer_Send, _
    '' '' ''                                0, _
    '' '' ''                                Buffer_Send.Length, _
    '' '' ''                                SocketFlags.None)               '送信


    '' '' ''        '*************************************************
    '' '' ''        '受信
    '' '' ''        '*************************************************
    '' '' ''        If mblnReceiveFlag = True Then

    '' '' ''            While objSocket.Available = 0
    '' '' ''                If DateAdd(DateInterval.Second, CInt(mintTimeOut / 1000), dtmNow) < Now Then
    '' '' ''                    mudtRET = RetCode.ReceiveTimeOut
    '' '' ''                    Exit Sub
    '' '' ''                End If
    '' '' ''                System.Threading.Thread.Sleep(100)
    '' '' ''            End While

    '' '' ''            ReDim Buffer_Recv(objSocket.Available)
    '' '' ''            objSocket.Receive(Buffer_Recv, _
    '' '' ''                              0, _
    '' '' ''                              objSocket.Available, _
    '' '' ''                              SocketFlags.None)                         '受信
    '' '' ''            mstrRecvText = mobjEncode.GetString(Buffer_Recv)           'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    '' '' ''            AddToLog(mstrRecvText)                    'ﾛｸﾞ書込み

    '' '' ''        End If


    '' '' ''        '*************************************************
    '' '' ''        'ｻｰﾊﾞｰ切断
    '' '' ''        '*************************************************
    '' '' ''        objSocket.Shutdown(SocketShutdown.Both)
    '' '' ''        objSocket.Close()


    '' '' ''        mudtRET = RetCode.OK
    '' '' ''    Catch ex As Exception
    '' '' ''        Call ComError(ex)

    '' '' ''    End Try
    '' '' ''End Sub
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
    Protected Sub ComError(ByVal objException As Exception)

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
            Me.AddToLog(objException.Message & "," & strStackTrace(ii))
        Next


        mudtRET = RetCode.NG
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
#Region "  ﾛｸﾞ書き込み処理(ﾃﾞﾊﾞｯｸﾞ用)       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書き込み処理(ﾃﾞﾊﾞｯｸﾞ用)
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToDebugLog(ByVal strMsg_1 As String)

        If intDebugFlag = 1 Then
            mobjOwner.AddToLog(strMsg_1)
        End If

    End Sub
#End Region

End Class
