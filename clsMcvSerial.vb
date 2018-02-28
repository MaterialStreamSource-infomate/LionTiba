'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】MCV通信ｸﾗｽ
' 【作成】2006/05/30  KSH  Rev 0.00
'**********************************************************************************************

Imports MateCommon.clsConst
Imports MateCommon
Imports System.IO.Ports

Public Class clsMcvSerial

#Region "  共通変数 "

    '==================================================
    '共通ｵﾌﾞｼﾞｪｸﾄ
    '==================================================
    Friend mobjOwner As Object                   'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Friend mobjSend As SerialPort                'ｼﾘｱﾙﾎﾟｰﾄ通信ｸﾗｽ（送信用）
    Friend mobjRecv As SerialPort                'ｼﾘｱﾙﾎﾟｰﾄ通信ｸﾗｽ（受信用）
    Private mbytRecvData() As Byte                  'ｼﾘｱﾙ受信ﾃﾞｰﾀ格納ﾊﾞｯﾌｧ(受信ﾎﾟｰﾄ)
    Private mbytResponsData() As Byte               'ｼﾘｱﾙ受信ﾃﾞｰﾀ格納ﾊﾞｯﾌｧ(送信ﾎﾟｰﾄ)


    '==================================================
    'ﾌﾟﾛﾊﾟﾃｨ変数
    '==================================================
    '受信用COM設定
    Private mstrRecvPort As String                   'ﾎﾟｰﾄ番号              
    Private mintRecvBaud As Integer                  '通信速度              
    Private mstrRecvParity As String                 'ﾊﾟﾘﾃｨ                 
    Private mintRecvDataLength As Integer            'ﾃﾞｰﾀ長                
    Private mstrRecvStopBit As String                'ｽﾄｯﾌﾟﾋﾞｯﾄ長           
    Private mstrRecvCheckInterval As String          '割り込みﾁｪｯｸ間隔(ms)  
    Private mstrRecvTimeOut As String                'ﾀｲﾑｱｳﾄ時間(秒)  
    Private mstrRecvEndString As String              '終端文字列ｺｰﾄﾞ(10進)
    '送信用COM設定
    Private mstrSendPort As String                   'ﾎﾟｰﾄ番号              
    Private mintSendBaud As Integer                  '通信速度              
    Private mstrSendParity As String                 'ﾊﾟﾘﾃｨ                 
    Private mintSendDataLength As Integer            'ﾃﾞｰﾀ長                
    Private mstrSendStopBit As String                'ｽﾄｯﾌﾟﾋﾞｯﾄ長           
    Private mstrSendCheckInterval As String          '割り込みﾁｪｯｸ間隔(ms)  
    Private mstrSendTimeOut As String                'ﾀｲﾑｱｳﾄ時間(秒)  
    Private mstrSendEndString As String              '終端文字列ｺｰﾄﾞ(10進)
    'その他
    Private mintCodePage As Integer                  '通信に使用するﾃｷｽﾄのｺｰﾄﾞ
    Private mintBCCUseFlag As Integer                'BCC使用ﾌﾗｸﾞ       (0:使用しない　　1:使用する)
    Private mintDebugFlag As Integer                 'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ


    '==================================================
    'その他
    '==================================================
    '232C制御文字（文字列に変換）
    Friend mstrSTX As String                         '(文字型) ﾃｷｽﾄ開始
    Friend mstrETX As String                         '(文字型) ﾃｷｽﾄ終了
    Friend mbytSTX() As Byte                         '(文字型) ﾃｷｽﾄ開始
    Friend mbytETX() As Byte                         '(文字型) ﾃｷｽﾄ終了


    'ｼﾘｱﾙﾎﾟｰﾄ種別
    Public Enum SerialKind
        Recv        '受信用
        Send        '送信用
    End Enum


    '==================================================
    '固定値
    '==================================================
    Private Const FRES_CD_EQ_MCV_OK As String = "00"                            '正常
    Private Const FRES_CD_EQ_MCV_ER_STX As String = "01"                        'STX抜け
    Private Const FRES_CD_EQ_MCV_ER_OVER As String = "03"                       '受信文字ｵｰﾊﾞｰ
    Private Const FRES_CD_EQ_MCV_ER_HARD As String = "05"                       'ﾊｰﾄﾞｴﾗｰ
    Private Const FRES_CD_EQ_MCV_ER_ALREADY As String = "08"                    'SEQ受信済みｴﾗｰ
    Private Const FRES_CD_EQ_MCV_ER_SEQNO As String = "09"                      'SEQ順序ｴﾗｰ
    Private Const FRES_CD_EQ_MCV_ER_ID As String = "10"                         'IDｴﾗｰ
    Private Const FRES_CD_EQ_MCV_ER_RANGE As String = "11"                      'ﾃﾞｰﾀ範囲ｴﾗｰ
    Private Const FRES_CD_EQ_MCV_ER_BCC As String = "11"                        'BCCｴﾗｰ
    Private Const FRES_CD_EQ_MCV_ER_FORMAT As String = "12"                     'ﾌｫｰﾏｯﾄｴﾗｰ
    Private Const FRES_CD_EQ_MCV_ER_SERIAL As String = "51"                     '搬送ｼﾘｱﾙNoｴﾗｰ

    Private Const MESSAGE_02 As String = "ｺﾞﾐﾃﾞｰﾀ取得 　     :"
    Private Const MESSAGE_03 As String = "電文受信           :"
    Private Const MESSAGE_04 As String = "電文送信           :"
    Private Const MESSAGE_05 As String = "応答電文受信       :"
    Private Const MESSAGE_06 As String = "応答電文送信       :"
    Private Const MESSAGE_07 As String = "異常応答受信       :"
    Private Const MESSAGE_08 As String = "BCC受信            :"
    Private Const MESSAGE_09 As String = "BCC送信            :"
    Private Const MESSAGE_11 As String = "BCCｴﾗｰ             :"
    Private Const MESSAGE_12 As String = "現在ﾊﾞｯﾌｧ(追加後)  :"
    Private Const MESSAGE_13 As String = "現在ﾊﾞｯﾌｧ(削除後)  :"
    Private Const MESSAGE_21 As String = "受信ﾊﾞｯﾌｧｸﾘｱ(PG)   :"
    Private Const MESSAGE_22 As String = "受信ﾊﾞｯﾌｧｸﾘｱ(COM)  :"

    Private Const STX = &H2                         '(数値型) ﾃｷｽﾄ開始
    Private Const ETX = &H3                         '(数値型) ﾃｷｽﾄ終了
    Private Const STXDISP As String = "[STX]"       '(文字型) ﾃｷｽﾄ開始
    Private Const ETXDISP As String = "[ETX]"       '(文字型) ﾃｷｽﾄ終了

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ"

    Protected ReadOnly Property objRecv() As Object
        Get
            Return mobjRecv
        End Get
        ' ''Set(ByVal Value As Object)
        ' ''    mobjRecv = Value
        ' ''End Set
    End Property

    Protected ReadOnly Property objSend() As Object
        Get
            Return mobjSend
        End Get
        ' ''Set(ByVal Value As Object)
        ' ''    mobjSend = Value
        ' ''End Set
    End Property


    Public Property strRecvPort() As String
        Get
            Return mstrRecvPort
        End Get
        Set(ByVal Value As String)
            mstrRecvPort = Value
        End Set
    End Property

    Public Property intRecvBaud() As Integer
        Get
            Return mintRecvBaud
        End Get
        Set(ByVal Value As Integer)
            mintRecvBaud = Value
        End Set
    End Property

    Public Property strRecvParity() As String
        Get
            Return mstrRecvParity
        End Get
        Set(ByVal Value As String)
            mstrRecvParity = Value
        End Set
    End Property

    Public Property intRecvDataLength() As Integer
        Get
            Return mintRecvDataLength
        End Get
        Set(ByVal Value As Integer)
            mintRecvDataLength = Value
        End Set
    End Property

    Public Property strRecvStopBit() As String
        Get
            Return mstrRecvStopBit
        End Get
        Set(ByVal Value As String)
            mstrRecvStopBit = Value
        End Set
    End Property

    Public Property strRecvCheckInterval() As String
        Get
            Return mstrRecvCheckInterval
        End Get
        Set(ByVal Value As String)
            mstrRecvCheckInterval = Value
        End Set
    End Property

    Public Property strRecvTimeOut() As String
        Get
            Return mstrRecvTimeOut
        End Get
        Set(ByVal Value As String)
            mstrRecvTimeOut = Value
        End Set
    End Property

    Public Property strRecvEndString() As String
        Get
            Return mstrRecvEndString
        End Get
        Set(ByVal Value As String)
            mstrRecvEndString = Value
        End Set
    End Property

    Public Property strSendPort() As String
        Get
            Return mstrSendPort
        End Get
        Set(ByVal Value As String)
            mstrSendPort = Value
        End Set
    End Property

    Public Property intSendBaud() As Integer
        Get
            Return mintSendBaud
        End Get
        Set(ByVal Value As Integer)
            mintSendBaud = Value
        End Set
    End Property

    Public Property strSendParity() As String
        Get
            Return mstrSendParity
        End Get
        Set(ByVal Value As String)
            mstrSendParity = Value
        End Set
    End Property

    Public Property intSendDataLength() As Integer
        Get
            Return mintSendDataLength
        End Get
        Set(ByVal Value As Integer)
            mintSendDataLength = Value
        End Set
    End Property

    Public Property strSendStopBit() As String
        Get
            Return mstrSendStopBit
        End Get
        Set(ByVal Value As String)
            mstrSendStopBit = Value
        End Set
    End Property

    Public Property strSendCheckInterval() As String
        Get
            Return mstrSendCheckInterval
        End Get
        Set(ByVal Value As String)
            mstrSendCheckInterval = Value
        End Set
    End Property

    Public Property strSendTimeOut() As String
        Get
            Return mstrSendTimeOut
        End Get
        Set(ByVal Value As String)
            mstrSendTimeOut = Value
        End Set
    End Property

    Public Property strSendEndString() As String
        Get
            Return mstrSendEndString
        End Get
        Set(ByVal Value As String)
            mstrSendEndString = Value
        End Set
    End Property

    Public Property intCodePage() As Integer
        Get
            Return mintCodePage
        End Get
        Set(ByVal Value As Integer)
            mintCodePage = Value
        End Set
    End Property

    Public Property intBCCUseFlag() As Integer
        Get
            Return mintBCCUseFlag
        End Get
        Set(ByVal Value As Integer)
            mintBCCUseFlag = Value
        End Set
    End Property

    Protected ReadOnly Property bytSTX() As Byte()
        Get
            Return mbytSTX
        End Get
        ' ''Set(ByVal Value As Object)
        ' ''    mobjRecv = Value
        ' ''End Set
    End Property

    Protected ReadOnly Property bytETX() As Byte()
        Get
            Return mbytETX
        End Get
        ' ''Set(ByVal Value As Object)
        ' ''    mobjRecv = Value
        ' ''End Set
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
#Region "  ｺﾝｽﾄﾗｸﾀ  "
    Public Sub New(ByVal objOwner As Object)


        '*****************************************************
        '色々初期化
        '*****************************************************
        mobjOwner = objOwner                                'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ


        '*****************************************************
        'ETX、STX設定
        '*****************************************************
        mbytSTX = System.Text.Encoding.GetEncoding(mintCodePage).GetBytes(Chr(STX)) '(文字型) ﾃｷｽﾄ開始
        mbytETX = System.Text.Encoding.GetEncoding(mintCodePage).GetBytes(Chr(ETX)) '(文字型) ﾃｷｽﾄ終了
        mstrSTX = System.Text.Encoding.GetEncoding(mintCodePage).GetString(mbytSTX)  '(文字型) ﾃｷｽﾄ開始
        mstrETX = System.Text.Encoding.GetEncoding(mintCodePage).GetString(mbytETX)  '(文字型) ﾃｷｽﾄ終了


    End Sub
#End Region
#Region "  送信ﾒｿｯﾄﾞ"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ IN ]strSendText     ：送信するﾃｷｽﾄﾃﾞｰﾀ
    '　　　　[ IN ]udtSerial       ：送信ﾎﾟｰﾄ、受信ﾎﾟｰﾄの使用区別
    '【戻値】ﾌﾟﾛｸﾞﾗﾑ正常完了の有無
    '*******************************************************************************************************************
    Public Sub Send(ByVal strSendText As String, _
                    ByVal udtSerial As SerialKind)

        '*****************************************************
        '受信用ﾎﾟｰﾄか送信用ﾎﾟｰﾄか選択
        '*****************************************************
        Dim objSerialPort As SerialPort = Nothing       '使用するｼﾘｱﾙﾎﾟｰﾄ
        Select Case udtSerial
            Case SerialKind.Recv
                objSerialPort = mobjRecv

            Case SerialKind.Send
                objSerialPort = mobjSend

        End Select


        '*****************************************************
        'ﾊﾞｲﾄに変換
        '*****************************************************
        Dim bytData() As Byte
        bytData = StringToByte(strSendText)
        'ETX を付ける
        ReDim Preserve bytData(UBound(bytData) + 1)
        bytData(UBound(bytData)) = mbytETX(0)


        '*****************************************************
        'BCC    ｾｯﾄ
        '*****************************************************
        Dim bytBCC(0) As Byte
        If mintBCCUseFlag = FLAG_ON Then
            bytBCC(0) = CreateBCC(bytData)                 'BCC取得
            Call AddToLog(MESSAGE_09 & bytBCC(0))
        End If


        '*****************************************************
        '送信
        '*****************************************************
        objSerialPort.Write(mbytSTX, 0, mbytSTX.Length)         'STX
        objSerialPort.Write(bytData, 0, bytData.Length)         '電文 + ETX
        If mintBCCUseFlag = FLAG_ON Then
            objSerialPort.Write(bytBCC, 0, bytBCC.Length)       'BCC
        End If


    End Sub
#End Region
#Region "  受信ﾒｿｯﾄﾞ"

#Region "  ﾌﾟﾛﾄｺﾙによって分岐"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ OUT ]strReceiveData  ：正常に受信できたﾃﾞｰﾀ
    '        [ OUT ]strResponsCode  ：応答ｺｰﾄﾞ
    '        [ IN  ]udtSerial       ：受信ﾎﾟｰﾄ or 送信ﾎﾟｰﾄ
    '【戻値】なし
    '*******************************************************************************************************************
    Public Sub ReceiveText(ByRef strReceiveData As String, _
                           ByRef strResponsCode As String, _
                           ByVal udtSerial As SerialKind)


        '*****************************************************
        '受信用ﾎﾟｰﾄか送信用ﾎﾟｰﾄか選択
        '*****************************************************
        Dim objSerialPort As SerialPort = Nothing       '使用するｼﾘｱﾙﾎﾟｰﾄ
        Select Case udtSerial
            Case SerialKind.Recv
                objSerialPort = mobjRecv

            Case SerialKind.Send
                objSerialPort = mobjSend

        End Select


        '*****************************************************
        'BCCﾁｪｯｸ有無選択
        '*****************************************************
        Select Case mintBCCUseFlag
            Case FLAG_ON
                '(BCC有)
                '=============================================
                '受信用ﾎﾟｰﾄか送信用ﾎﾟｰﾄか選択
                '=============================================
                Select Case udtSerial
                    Case SerialKind.Recv
                        Call ReceiveTextMainBCC(strReceiveData, _
                                                strResponsCode, _
                                                mobjRecv, _
                                                mbytRecvData _
                                                )
                    Case SerialKind.Send
                        Call ReceiveTextMainBCC(strReceiveData, _
                                                strResponsCode, _
                                                mobjSend, _
                                                mbytResponsData _
                                                )
                End Select

            Case FLAG_OFF
                '(BCC無)
                '=============================================
                '受信用ﾎﾟｰﾄか送信用ﾎﾟｰﾄか選択
                '=============================================
                Select Case udtSerial
                    Case SerialKind.Recv
                        Call ReceiveTextMainBCCNothing(strReceiveData, _
                                                       strResponsCode, _
                                                       mobjRecv, _
                                                       mbytRecvData _
                                                       )
                    Case SerialKind.Send
                        Call ReceiveTextMainBCCNothing(strReceiveData, _
                                                       strResponsCode, _
                                                       mobjSend, _
                                                       mbytResponsData _
                                                       )
                End Select

            Case Else
                '(その他)
                '=============================================
                'ｴﾗｰ
                '=============================================
                Throw New Exception("BCC有無が設定されていません。")

        End Select


    End Sub
#End Region
#Region "  ｼﾘｱﾙ通信受信ﾃｷｽﾄ取得(BCC有)"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ OUT ]strReceiveData  ：正常に受信できたﾃﾞｰﾀ
    '        [ OUT ]strResponsCode  ：応答ｺｰﾄﾞ
    '        [ OUT ]objSerialPort   ：使用するｼﾘｱﾙﾎﾟｰﾄ
    '        [ OUT ]bytBuffer       ：使用する受信格納ﾊﾞｯﾌｧ
    '【戻値】なし
    '*******************************************************************************************************************
    Public Sub ReceiveTextMainBCC(ByRef strReceiveData As String, _
                                  ByRef strResponsCode As String, _
                                  ByRef objSerialPort As SerialPort, _
                                  ByRef bytBuffer() As Byte)
        Dim strMessage As String        'ﾛｸﾞ用表示ﾒｯｾｰｼﾞ
        strResponsCode = FRES_CD_EQ_MCV_OK


        '*****************************************************
        '受信ﾃﾞｰﾀを、ﾊﾞｲﾄ配列ﾊﾞｯﾌｧに追加
        '*****************************************************
        '' '' ''Dim bytRead(128) As Byte
        Dim bytRead(512) As Byte
        If objSerialPort.BytesToRead > 0 Then
            Dim intGetbyte As Integer       '取得ﾊﾞｲﾄ数
            intGetbyte = objSerialPort.Read(bytRead, 0, bytRead.Length)      'ﾃﾞｰﾀ取得
            For ii As Integer = 0 To intGetbyte - 1
                If IsNull(bytBuffer) Then
                    ReDim Preserve bytBuffer(0)
                Else
                    ReDim Preserve bytBuffer(UBound(bytBuffer) + 1)
                End If
                bytBuffer(UBound(bytBuffer)) = bytRead(ii)
            Next

            'ﾊﾞｯﾌｧﾛｸﾞ出力
            strMessage = ""
            strMessage &= MESSAGE_12
            strMessage &= ByteToString(bytBuffer)
            Call AddToLog(strMessage)
        End If


        '*****************************************************
        '正常なﾃﾞｰﾀを取得
        '*****************************************************
        'ﾃﾞｰﾀﾁｪｯｸ
        If IsNull(bytBuffer) Then Exit Sub

        'STXの位置検索
        Dim intSTXPlace As Integer
        Dim blnSTXFound As Boolean = False
        For intSTXPlace = LBound(bytBuffer) To UBound(bytBuffer)
            '(ﾙｰﾌﾟ:STXが見つかるまで)
            If bytBuffer(intSTXPlace) <> mbytSTX(0) Then Continue For

            blnSTXFound = True
            Exit For
        Next

        'ETXの位置検索
        Dim intETXPlace As Integer
        Dim blnETXFound As Boolean = False
        For intETXPlace = LBound(bytBuffer) To UBound(bytBuffer)
            '(ﾙｰﾌﾟ:ETXが見つかるまで)
            If bytBuffer(intETXPlace).ToString <> mbytETX(0) Then Continue For

            blnETXFound = True
            Exit For
        Next

        '====================================================
        'STXが先頭にない場合、ｺﾞﾐと判断し削除
        '====================================================
        If intSTXPlace <> 0 Then
            '-----------------------------------
            'ｺﾞﾐﾃﾞｰﾀ            取得
            'STX以降のﾃﾞｰﾀ      取得
            '-----------------------------------
            Dim bytDust(intSTXPlace - 1) As Byte                            'ｺﾞﾐﾃﾞｰﾀ
            Dim bytNotDust(UBound(bytBuffer) - intSTXPlace) As Byte      'ｺﾞﾐじゃないﾃﾞｰﾀの一時保管(STX以降のﾃﾞｰﾀ)
            For ii As Integer = LBound(bytBuffer) To UBound(bytBuffer)
                '(ﾙｰﾌﾟ:全てのﾊﾞｯﾌｧﾃﾞｰﾀ)

                If ii < intSTXPlace Then
                    bytDust(ii) = bytBuffer(ii)                      'ｺﾞﾐﾃﾞｰﾀ取得
                Else
                    bytNotDust(ii - intSTXPlace) = bytBuffer(ii)     'STX以降のﾃﾞｰﾀ取得
                End If
            Next

            'ｺﾞﾐﾃﾞｰﾀ取得ﾛｸﾞ出力
            strMessage = ""
            strMessage &= MESSAGE_02
            strMessage &= ByteToString(bytDust)
            Call AddToLog(strMessage)

            'ｺﾞﾐﾃﾞｰﾀ削除
            ReDim Preserve bytBuffer(UBound(bytNotDust))
            For ii As Integer = LBound(bytNotDust) To UBound(bytNotDust)
                '(ﾙｰﾌﾟ:全てのﾃﾞｰﾀ)
                bytBuffer(ii) = bytNotDust(ii)
            Next

            strResponsCode = FRES_CD_EQ_MCV_ER_STX              'STX抜け
            strReceiveData = ByteToString(bytDust)              '一応受信ﾃﾞｰﾀとする
        End If

        '====================================================
        'STX、ETX が存在する場合、ﾃﾞｰﾀ取得
        '====================================================
        If intSTXPlace = 0 _
           And blnSTXFound = True _
           And blnETXFound = True _
           And intETXPlace < UBound(bytBuffer) Then

            '-----------------------------------
            '電文取得
            '-----------------------------------
            Dim bytGetData(intETXPlace - intSTXPlace - 1) As Byte      '受信するﾃﾞｰﾀを格納(STXは含めず、ETXは含む)
            Dim bytBCC As Byte
            For ii As Integer = intSTXPlace + 1 To intETXPlace + 1
                '(ﾙｰﾌﾟ:[STX]から[ETX]+1 まで)

                If ii = intETXPlace + 1 Then
                    bytBCC = bytBuffer(ii)                   'BCC取得
                Else
                    bytGetData(ii - 1) = bytBuffer(ii)       '受信するﾃﾞｰﾀ格納
                End If
            Next

            '-----------------------------------
            'BCCﾁｪｯｸ
            '-----------------------------------
            Call AddToLog(MESSAGE_08 & bytBCC)
            If bytBCC <> CreateBCC(bytGetData) Then         'BCC取得
                'BCCｴﾗｰﾛｸﾞ出力
                strMessage = ""
                strMessage &= MESSAGE_11 & bytBCC
                Call AddToLog(strMessage)
                strResponsCode = FRES_CD_EQ_MCV_ER_BCC
            End If
            '-----------------------------------
            '文字数ﾁｪｯｸ
            '-----------------------------------
            If bytGetData.Length > 510 Then
                strResponsCode = FRES_CD_EQ_MCV_ER_OVER
            End If


            '-----------------------------------
            '取得した電文以降のﾃﾞｰﾀを取得
            '-----------------------------------
            Dim bytBackETX(UBound(bytBuffer) - intETXPlace - 2) As Byte        '取得した電文以降のﾃﾞｰﾀを取得
            Dim intCount As Integer = 0     'bytBackETX用のｶｳﾝﾀ

            For ii As Integer = intETXPlace + 2 To UBound(bytBuffer)
                '(ﾙｰﾌﾟ:[ETX]+2 以降)

                bytBackETX(intCount) = bytBuffer(ii)
                intCount += 1
            Next

            '-----------------------------------
            'ｼﾘｱﾙ受信ﾃﾞｰﾀ格納ﾊﾞｯﾌｧを更新
            '-----------------------------------
            If UBound(bytGetData) + 2 = UBound(bytBuffer) Then
                '(ﾊﾞｯﾌｧﾃﾞｰﾀと受信ﾃﾞｰﾀが一緒の時)
                bytBuffer = Nothing
            Else
                '(ﾊﾞｯﾌｧﾃﾞｰﾀと受信ﾃﾞｰﾀが違う時)
                ReDim Preserve bytBuffer(UBound(bytBackETX))
                For ii As Integer = LBound(bytBackETX) To UBound(bytBackETX)
                    '(ﾙｰﾌﾟ:全てのﾃﾞｰﾀ)
                    bytBuffer(ii) = bytBackETX(ii)
                Next
            End If
            'ﾛｸﾞ出力
            strMessage = ""
            strMessage &= MESSAGE_13
            strMessage &= ByteToString(bytBuffer)
            Call AddToLog(strMessage)


            '*****************************************************
            '正常に受信できたﾃﾞｰﾀを設定
            '*****************************************************
            ReDim Preserve bytGetData(UBound(bytGetData) - 1)   'ETX 削除
            strReceiveData = ByteToString(bytGetData)           '受信ﾃﾞｰﾀ


        End If


    End Sub
#End Region
#Region "  ｼﾘｱﾙ通信受信ﾃｷｽﾄ取得(BCC無)"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ OUT ]strReceiveData  ：正常に受信できたﾃﾞｰﾀ
    '        [ OUT ]strResponsCode  ：応答ｺｰﾄﾞ
    '        [ OUT ]objSerialPort   ：使用するｼﾘｱﾙﾎﾟｰﾄ
    '        [ OUT ]bytBuffer       ：使用する受信格納ﾊﾞｯﾌｧ
    '【戻値】なし
    '*******************************************************************************************************************
    Public Sub ReceiveTextMainBCCNothing(ByRef strReceiveData As String, _
                                         ByRef strResponsCode As String, _
                                         ByRef objSerialPort As SerialPort, _
                                         ByRef bytBuffer() As Byte)
        Dim strMessage As String        'ﾛｸﾞ用表示ﾒｯｾｰｼﾞ
        strResponsCode = FRES_CD_EQ_MCV_OK


        '*****************************************************
        '受信ﾃﾞｰﾀを、ﾊﾞｲﾄ配列ﾊﾞｯﾌｧに追加
        '*****************************************************
        '' '' ''Dim bytRead(128) As Byte
        Dim bytRead(512) As Byte
        If objSerialPort.BytesToRead > 0 Then
            Dim intGetbyte As Integer       '取得ﾊﾞｲﾄ数
            intGetbyte = objSerialPort.Read(bytRead, 0, bytRead.Length)      'ﾃﾞｰﾀ取得
            For ii As Integer = 0 To intGetbyte - 1
                If IsNull(bytBuffer) Then
                    ReDim Preserve bytBuffer(0)
                Else
                    ReDim Preserve bytBuffer(UBound(bytBuffer) + 1)
                End If
                bytBuffer(UBound(bytBuffer)) = bytRead(ii)
            Next

            'ﾊﾞｯﾌｧﾛｸﾞ出力
            strMessage = ""
            strMessage &= MESSAGE_12
            strMessage &= ByteToString(bytBuffer)
            Call AddToLog(strMessage)
        End If


        '*****************************************************
        '正常なﾃﾞｰﾀを取得
        '*****************************************************
        'ﾃﾞｰﾀﾁｪｯｸ
        If IsNull(bytBuffer) Then Exit Sub

        'STXの位置検索
        Dim intSTXPlace As Integer
        Dim blnSTXFound As Boolean = False
        For intSTXPlace = LBound(bytBuffer) To UBound(bytBuffer)
            '(ﾙｰﾌﾟ:STXが見つかるまで)
            If bytBuffer(intSTXPlace) <> mbytSTX(0) Then Continue For

            blnSTXFound = True
            Exit For
        Next

        'ETXの位置検索
        Dim intETXPlace As Integer
        Dim blnETXFound As Boolean = False
        For intETXPlace = LBound(bytBuffer) To UBound(bytBuffer)
            '(ﾙｰﾌﾟ:ETXが見つかるまで)
            If bytBuffer(intETXPlace).ToString <> mbytETX(0) Then Continue For

            blnETXFound = True
            Exit For
        Next

        '====================================================
        'STXが先頭にない場合、ｺﾞﾐと判断し削除
        '====================================================
        If intSTXPlace <> 0 Then
            '-----------------------------------
            'ｺﾞﾐﾃﾞｰﾀ            取得
            'STX以降のﾃﾞｰﾀ      取得
            '-----------------------------------
            Dim bytDust(intSTXPlace - 1) As Byte                            'ｺﾞﾐﾃﾞｰﾀ
            Dim bytNotDust(UBound(bytBuffer) - intSTXPlace) As Byte      'ｺﾞﾐじゃないﾃﾞｰﾀの一時保管(STX以降のﾃﾞｰﾀ)
            For ii As Integer = LBound(bytBuffer) To UBound(bytBuffer)
                '(ﾙｰﾌﾟ:全てのﾊﾞｯﾌｧﾃﾞｰﾀ)

                If ii < intSTXPlace Then
                    bytDust(ii) = bytBuffer(ii)                      'ｺﾞﾐﾃﾞｰﾀ取得
                Else
                    bytNotDust(ii - intSTXPlace) = bytBuffer(ii)     'STX以降のﾃﾞｰﾀ取得
                End If
            Next

            'ｺﾞﾐﾃﾞｰﾀ取得ﾛｸﾞ出力
            strMessage = ""
            strMessage &= MESSAGE_02
            strMessage &= ByteToString(bytDust)
            Call AddToLog(strMessage)

            'ｺﾞﾐﾃﾞｰﾀ削除
            ReDim Preserve bytBuffer(UBound(bytNotDust))
            For ii As Integer = LBound(bytNotDust) To UBound(bytNotDust)
                '(ﾙｰﾌﾟ:全てのﾃﾞｰﾀ)
                bytBuffer(ii) = bytNotDust(ii)
            Next

            strResponsCode = FRES_CD_EQ_MCV_ER_STX              'STX抜け
            strReceiveData = ByteToString(bytDust)              '一応受信ﾃﾞｰﾀとする
        End If

        '====================================================
        'STX、ETX が存在する場合、ﾃﾞｰﾀ取得
        '====================================================
        If intSTXPlace = 0 _
           And blnSTXFound = True _
           And blnETXFound = True Then

            '-----------------------------------
            '電文取得
            '-----------------------------------
            Dim bytGetData(intETXPlace - intSTXPlace - 1) As Byte      '受信するﾃﾞｰﾀを格納(STXは含めず、ETXは含む)
            For ii As Integer = intSTXPlace + 1 To intETXPlace
                '(ﾙｰﾌﾟ:[STX]から[ETX] まで)
                bytGetData(ii - 1) = bytBuffer(ii)       '受信するﾃﾞｰﾀ格納
            Next

            '-----------------------------------
            '文字数ﾁｪｯｸ
            '-----------------------------------
            If bytGetData.Length > 510 Then
                strResponsCode = FRES_CD_EQ_MCV_ER_OVER
            End If


            '-----------------------------------
            '取得した電文以降のﾃﾞｰﾀを取得
            '-----------------------------------
            Dim bytBackETX(UBound(bytBuffer) - intETXPlace - 1) As Byte        '取得した電文以降のﾃﾞｰﾀを取得
            Dim intCount As Integer = 0     'bytBackETX用のｶｳﾝﾀ

            For ii As Integer = intETXPlace + 1 To UBound(bytBuffer)
                '(ﾙｰﾌﾟ:[ETX]+1 以降)

                bytBackETX(intCount) = bytBuffer(ii)
                intCount += 1
            Next

            '-----------------------------------
            'ｼﾘｱﾙ受信ﾃﾞｰﾀ格納ﾊﾞｯﾌｧを更新
            '-----------------------------------
            If UBound(bytGetData) + 1 = UBound(bytBuffer) Then      'bytGetDataにはSTXは含まれない為+1となる
                '(ﾊﾞｯﾌｧﾃﾞｰﾀと受信ﾃﾞｰﾀが一緒の時)
                bytBuffer = Nothing
            Else
                '(ﾊﾞｯﾌｧﾃﾞｰﾀと受信ﾃﾞｰﾀが違う時)
                ReDim Preserve bytBuffer(UBound(bytBackETX))
                For ii As Integer = LBound(bytBackETX) To UBound(bytBackETX)
                    '(ﾙｰﾌﾟ:全てのﾃﾞｰﾀ)
                    bytBuffer(ii) = bytBackETX(ii)
                Next
            End If
            'ﾛｸﾞ出力
            strMessage = ""
            strMessage &= MESSAGE_13
            strMessage &= ByteToString(bytBuffer)
            Call AddToLog(strMessage)



            '*****************************************************
            '正常に受信できたﾃﾞｰﾀを設定
            '*****************************************************
            ReDim Preserve bytGetData(UBound(bytGetData) - 1)   'ETX 削除
            strReceiveData = ByteToString(bytGetData)           '受信ﾃﾞｰﾀ


        End If


    End Sub
#End Region

#End Region
#Region "  通信ｵｰﾌﾟﾝ"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '　　　　
    '【戻値】
    '*******************************************************************************************************************
    Public Sub Open()


        '*****************************************************
        'ｼﾘｱﾙ通信ｾｯﾄｱｯﾌﾟ
        '*****************************************************
        '=====================================
        '受信用COM
        '=====================================
        If IsNull(mobjRecv) Then
            If mstrRecvPort <> "" Then
                '(ﾌﾟﾛﾊﾟﾃｨｾｯﾄされていた場合)
                mobjRecv = New SerialPort(mstrRecvPort, _
                                            mintRecvBaud, _
                                            mstrRecvParity, _
                                            mintRecvDataLength, _
                                            mstrRecvStopBit)
                mobjRecv.Open()                                                     '通信ｵｰﾌﾟﾝ
                mobjRecv.Encoding = System.Text.Encoding.GetEncoding(mintCodePage)  'ｴﾝｺｰﾄﾞ設定
            End If
        End If

        '=====================================
        '送信用COM
        '=====================================
        If IsNull(mobjSend) Then
            If mstrSendPort <> "" Then
                '(ﾌﾟﾛﾊﾟﾃｨｾｯﾄされていた場合)
                mobjSend = New SerialPort(mstrSendPort, _
                                                mintSendBaud, _
                                                mstrSendParity, _
                                                mintSendDataLength, _
                                                mstrSendStopBit)
                mobjSend.Open()                                                     '通信ｵｰﾌﾟﾝ
                mobjSend.Encoding = System.Text.Encoding.GetEncoding(mintCodePage)  'ｴﾝｺｰﾄﾞ設定
            End If
        End If


    End Sub
#End Region
#Region "  通信ｸﾛｰｽﾞ"
    Public Sub Close()

        '受信用
        If IsNull(mobjRecv) = False Then
            mobjRecv.Close()       '通信ｸﾛｰｽﾞ
            mobjRecv.Dispose()
            mobjRecv = Nothing
        End If

        '送信用
        If IsNull(mobjSend) = False Then
            mobjSend.Close()       '通信ｸﾛｰｽﾞ
            mobjSend.Dispose()
            mobjSend = Nothing
        End If

    End Sub
#End Region


#Region "  ﾛｸﾞ書き込み処理"
    Public Sub AddToLog(ByVal strMsg_1 As String)

        strMsg_1 = Replace(strMsg_1, mstrSTX, STXDISP)
        strMsg_1 = Replace(strMsg_1, mstrETX, ETXDISP)
        mobjOwner.AddToLog(strMsg_1)

    End Sub
#End Region
#Region "  ﾊﾞｲﾄ配列 → 文字列"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ IN ]bytData()        ：変換するﾊﾞｲﾄ配列
    '【戻値】変換した文字列
    '*******************************************************************************************************************
    Public Function ByteToString(ByVal bytData() As Byte) As String
        Dim strRet As String


        If IsNull(bytData) Then
            strRet = ""
        Else
            strRet = System.Text.Encoding.GetEncoding(mintCodePage).GetString(bytData, 0, bytData.Length)
        End If


        Return (strRet)
    End Function
#End Region
#Region "  文字列 → ﾊﾞｲﾄ配列"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ IN ]strData          ：変換する文字列
    '【戻値】変換したﾊﾞｲﾄ配列
    '*******************************************************************************************************************
    Public Function StringToByte(ByVal strData As String) As Byte()

        Dim bytRet() As Byte
        bytRet = System.Text.Encoding.GetEncoding(mintCodePage).GetBytes(strData)


        Return (bytRet)
    End Function
#End Region
#Region "  BCC作成"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ IN ]bytData()          ：BCCを作成する文字列
    '【戻値】変換したﾊﾞｲﾄ配列
    '*******************************************************************************************************************
    Protected Function CreateBCC(ByVal bytData() As Byte) As Byte
        Dim bytBCC As Byte = 0

        '*****************************************************
        'BCCを取得
        '*****************************************************
        For ii As Integer = 0 To UBound(bytData)
            '(ﾙｰﾌﾟ:ﾊﾞｲﾄ配列の数だけ)

            bytBCC = bytBCC Xor bytData(ii)
        Next


        Return (bytBCC)
    End Function
#End Region

End Class
