'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【機能】ｼﾘｱﾙ通信ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

Imports System.IO.Ports

Public Class clsSerial

#Region "  共通変数、共通定数               "

    '***********************************************************************************************
    '共通変数
    '***********************************************************************************************
    Private mobjSerial As SerialPort        'ｼﾘｱﾙﾎﾟｰﾄ
    Private mobjOwner As Object             'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Private mobjEncode As System.Text.Encoding      'ｴﾝｺｰﾄﾞ

    'ﾌﾟﾛﾊﾟﾃｨ変数
    Private mstrRecvPort As String                  'ﾎﾟｰﾄ番号
    Private mintRecvBaud As Integer                 '通信速度
    Private mstrRecvParity As String                'ﾊﾟﾘﾃｨ
    Private mintRecvDataLength As Integer           'ﾃﾞｰﾀ長
    Private mstrRecvStopBit As String               'ｽﾄｯﾌﾟﾋﾞｯﾄ長
    Private mstrComName As String                   '通信名     複数ﾎﾟｰﾄ使用する場合、ここで判別する
    Private mintCodePage As Integer                 '通信に使用するﾃｷｽﾄのｺｰﾄﾞ
    Private mstrSendText As String                  '送信ﾃｷｽﾄ
    Private mstrRecvText As String                  '受信ﾃｷｽﾄ
    Private mbytSendText() As Byte                  '送信ﾊﾞｲﾄ配列
    Private mbytRecvText() As Byte                  '受信ﾊﾞｲﾄ配列
    Private mintDebugFlag As Integer                'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ


#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ                          "

    ''' =======================================
    ''' <summary>ﾎﾟｰﾄ番号</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strRecvPort() As String
        Get
            Return mstrRecvPort
        End Get
        Set(ByVal Value As String)
            mstrRecvPort = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>通信速度</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intRecvBaud() As Integer
        Get
            Return mintRecvBaud
        End Get
        Set(ByVal Value As Integer)
            mintRecvBaud = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾊﾟﾘﾃｨ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strRecvParity() As String
        Get
            Return mstrRecvParity
        End Get
        Set(ByVal Value As String)
            mstrRecvParity = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾃﾞｰﾀ長</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intRecvDataLength() As Integer
        Get
            Return mintRecvDataLength
        End Get
        Set(ByVal Value As Integer)
            mintRecvDataLength = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ｽﾄｯﾌﾟﾋﾞｯﾄ長</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strRecvStopBit() As String
        Get
            Return mstrRecvStopBit
        End Get
        Set(ByVal Value As String)
            mstrRecvStopBit = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>送信ﾃｷｽﾄ</summary>
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
    ''' <summary>送信ﾃｷｽﾄ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strComName() As String
        Get
            Return mstrComName
        End Get
        Set(ByVal Value As String)
            mstrComName = Value
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

#Region "  ｺﾝｽﾄﾗｸﾀ                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object)


        '*****************************************************
        '色々初期化
        '*****************************************************
        mobjOwner = objOwner                                'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
        mobjEncode = System.Text.Encoding.Default           'ｴﾝｺｰﾄﾞ
        mstrSendText = ""          '送信ﾃｷｽﾄ
        mstrRecvText = ""          '受信ﾃｷｽﾄ
        mbytSendText = Nothing     '送信ﾊﾞｲﾄ配列
        mbytRecvText = Nothing     '受信ﾊﾞｲﾄ配列


    End Sub
#End Region
#Region "  通信ｵｰﾌﾟﾝ                        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 通信ｵｰﾌﾟﾝ
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Open()


        '*****************************************************
        'ｼﾘｱﾙ通信ｾｯﾄｱｯﾌﾟ
        '*****************************************************
        If IsNothing(mobjSerial) Then
            mobjSerial = New SerialPort(mstrRecvPort, _
                                        mintRecvBaud, _
                                        mstrRecvParity, _
                                        mintRecvDataLength, _
                                        mstrRecvStopBit)
        End If


        '通信ｵｰﾌﾟﾝ
        mobjSerial.Open()

        'ｴﾝｺｰﾄﾞ設定
        mobjSerial.Encoding = System.Text.Encoding.GetEncoding(mintCodePage)


    End Sub
#End Region
#Region "  通信ｸﾛｰｽﾞ                        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 通信ｸﾛｰｽﾞ
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Close()

        mobjSerial.Close()       '通信ｸﾛｰｽﾞ
        mobjSerial.Dispose()
        mobjSerial = Nothing

    End Sub
#End Region
#Region "  送信ﾒｿｯﾄﾞ                        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 送信ﾒｿｯﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Send()
        Dim BufferSend() As Byte           '送信用ﾊﾞｯﾌｧ


        '*************************************************
        'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
        '*************************************************
        If IsNull(mstrSendText) And IsNull(mbytSendText) Then
            Throw New Exception("送信ﾃｷｽﾄﾌﾟﾛﾊﾟﾃｨにﾃｷｽﾄがｾｯﾄされていません。送信ﾃｷｽﾄﾌﾟﾛﾊﾟﾃｨに送信ﾃｷｽﾄをｾｯﾄして下さい。")
        End If


        '*****************************************************
        'ﾊﾞｲﾄに変換
        '*****************************************************
        If IsNotNull(mbytSendText) Then
            BufferSend = mbytSendText
        Else
            BufferSend = StringToByte(mstrSendText)
        End If


        '*****************************************************
        '送信
        '*****************************************************
        mobjSerial.Write(BufferSend, 0, BufferSend.Length)         '電文 + ETX


    End Sub
#End Region
#Region "  受信ﾒｿｯﾄﾞ                        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 受信ﾒｿｯﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Receive()
        mbytRecvText = Nothing
        mstrRecvText = ""


        '*****************************************************
        '受信ﾃﾞｰﾀを、ﾊﾞｲﾄ配列ﾊﾞｯﾌｧに追加
        '*****************************************************
        Dim bytRead(512) As Byte
        If mobjSerial.BytesToRead > 0 Then
            Dim intGetbyte As Integer       '取得ﾊﾞｲﾄ数
            Dim bytGetbyte(0) As Byte       '取得したﾊﾞｲﾄ配列
            intGetbyte = mobjSerial.Read(bytRead, 0, bytRead.Length)    'ﾃﾞｰﾀ取得
            For ii As Integer = 0 To intGetbyte - 1
                ReDim Preserve bytGetbyte(ii)
                bytGetbyte(ii) = bytRead(ii)
            Next

            mbytRecvText = bytGetbyte                           'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
            mstrRecvText = ByteToString(bytGetbyte)             'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ


        End If


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
