'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】安川PLC通信ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

Public Class clsPLC

#Region "  共通変数         "

    '==================================================
    '共通変数
    '==================================================
    Private mobjOwner As Object                                 'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Private mobjSerial As clsSerial                             'ｿｹｯﾄｸﾗｲｱﾝﾄ   ｵﾌﾞｼﾞｪｸﾄ
    Private mobjASCII As clsASCII                               'ASCIIｺｰﾄﾞ文字ｸﾗｽ

    '==================================================
    'ﾌﾟﾛﾊﾟﾃｨ変数
    '==================================================
    '受信用COM設定
    Private mstrCOMRecvPort As String               'ﾎﾟｰﾄ番号
    Private mintCOMRecvBaud As Integer              '通信速度
    Private mstrCOMRecvParity As String             'ﾊﾟﾘﾃｨ
    Private mintCOMRecvDataLength As Integer        'ﾃﾞｰﾀ長
    Private mstrCOMRecvStopBit As String            'ｽﾄｯﾌﾟﾋﾞｯﾄ長
    Private mintCOMCodePage As Integer              '通信に使用するﾃｷｽﾄのｺｰﾄﾞ  (932:ShiftJIS)
    Private mstrCOMComName As String                '通信名
    Private mintSendTimeout As Integer              '送信ﾀｲﾑｱｳﾄ(ms)
    Private mintSendRetry As Integer                '送信ﾘﾄﾗｲ回数
    'その他
    Private mintDebugFlag As Integer                'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ

    '==================================================
    '列挙体
    '==================================================
    Public Enum RetCode
        OK = 0          'OK
        NG = 1          'NG
        NotFound = 2    '見つからない
        NotEnough = 3   '満たさない
        RollBack = 4
        ResNothing = 99 'PLCから応答が返って来ない
    End Enum

    '==================================================
    '固定値
    '==================================================
    Private Const MSG_001 As String = "ｺﾈｸｼｮﾝ接続完了。"
    Private Const MSG_002 As String = "ｺﾈｸｼｮﾝ切断完了。"
    Private Const MSG_003 As String = "ｺﾈｸｼｮﾝ接続失敗。"
    Private Const MSG_011 As String = "受信ﾀｲﾑｱｳﾄ。"
    Private Const MSG_012 As String = "送信ﾘﾄﾗｲｵｰﾊﾞｰ。"

    Private Const MSG_101 As String = "ｺﾞﾐﾃﾞｰﾀ取得 　     :"
    Private Const MSG_102 As String = "受信ﾊﾞｲﾄ数ｵｰﾊﾞｰ 　 :"

    Private Const MSG_501 As String = "電文送信           :"

    Private Const MSG_601 As String = "電文受信           :"
    Private Const MSG_602 As String = "受信ﾊﾞｯﾌｧ(追加後)  :"
    Private Const MSG_603 As String = "受信ﾊﾞｯﾌｧ(削除後)  :"

    Private Const MSG_701 As String = "ﾚｼﾞｽﾀ読込          :"
    Private Const MSG_711 As String = "ﾚｼﾞｽﾀ書込          :"

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ          "

    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Property intDebugFlag() As Integer
        Get
            Return mintDebugFlag
        End Get
        Set(ByVal Value As Integer)
            mintDebugFlag = Value
            If IsNotNull(mobjSerial) Then mobjSerial.intDebugFlag = Value 'ｼﾘｱﾙ通信ｸﾗｽ
        End Set
    End Property

    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾎﾟｰﾄ番号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Property strCOMRecvPort() As String
        Get
            Return mstrCOMRecvPort
        End Get
        Set(ByVal Value As String)
            mstrCOMRecvPort = Value
        End Set
    End Property

    '''*******************************************************************************************************************
    ''' <summary>
    ''' 通信速度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Property intCOMRecvBaud() As Integer
        Get
            Return mintCOMRecvBaud
        End Get
        Set(ByVal Value As Integer)
            mintCOMRecvBaud = Value
        End Set
    End Property

    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾟﾘﾃｨ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Property strCOMRecvParity() As String
        Get
            Return mstrCOMRecvParity
        End Get
        Set(ByVal Value As String)
            mstrCOMRecvParity = Value
        End Set
    End Property

    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ長
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Property intCOMRecvDataLength() As Integer
        Get
            Return mintCOMRecvDataLength
        End Get
        Set(ByVal Value As Integer)
            mintCOMRecvDataLength = Value
        End Set
    End Property

    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｽﾄｯﾌﾟﾋﾞｯﾄ長
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Property strCOMRecvStopBit() As String
        Get
            Return mstrCOMRecvStopBit
        End Get
        Set(ByVal Value As String)
            mstrCOMRecvStopBit = Value
        End Set
    End Property

    '''*******************************************************************************************************************
    ''' <summary>
    ''' 通信に使用するﾃｷｽﾄのｺｰﾄﾞ  (932:ShiftJIS)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Property intCOMCodePage() As Integer
        Get
            Return mintCOMCodePage
        End Get
        Set(ByVal Value As Integer)
            mintCOMCodePage = Value
        End Set
    End Property

    '''*******************************************************************************************************************
    ''' <summary>
    ''' 通信名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Property strCOMComName() As String
        Get
            Return mstrCOMComName
        End Get
        Set(ByVal Value As String)
            mstrCOMComName = Value
        End Set
    End Property

    '''*******************************************************************************************************************
    ''' <summary>
    ''' 送信ﾀｲﾑｱｳﾄ(ms)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Property intSendTimeout() As Integer
        Get
            Return mintSendTimeout
        End Get
        Set(ByVal Value As Integer)
            mintSendTimeout = Value
        End Set
    End Property

    '''*******************************************************************************************************************
    ''' <summary>
    ''' 送信ﾘﾄﾗｲ回数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Property intSendRetry() As Integer
        Get
            Return mintSendRetry
        End Get
        Set(ByVal Value As Integer)
            mintSendRetry = Value
        End Set
    End Property

#End Region


#Region "  ｺﾝｽﾄﾗｸﾀ              "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】objOwner       ：ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ  (主にﾛｸﾞ書込みに使用)
    '【戻値】なし
    '*******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object)

        '*****************************************************
        '色々初期化
        '*****************************************************
        '======================================
        'ｵﾌﾞｼﾞｪｸﾄ
        '======================================
        mobjOwner = objOwner                    'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
        mobjASCII = New clsASCII()              'ASCIIｺｰﾄﾞ文字ｸﾗｽ

        '======================================
        'ﾌﾟﾛﾊﾟﾃｨ
        '======================================
        '受信用COM設定
        mstrCOMRecvPort = ""            'ﾎﾟｰﾄ番号
        mintCOMRecvBaud = 0             '通信速度
        mstrCOMRecvParity = ""          'ﾊﾟﾘﾃｨ
        mintCOMRecvDataLength = 0       'ﾃﾞｰﾀ長
        mstrCOMRecvStopBit = ""         'ｽﾄｯﾌﾟﾋﾞｯﾄ長
        mintCOMCodePage = 0             '通信に使用するﾃｷｽﾄのｺｰﾄﾞ  (932:ShiftJIS)
        mstrCOMComName = ""             '通信名
        mintSendTimeout = 10000         '送信ﾀｲﾑｱｳﾄ(ms)
        mintSendRetry = 3               '送信ﾘﾄﾗｲ回数
        'その他
        mintDebugFlag = 0               'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ


    End Sub
#End Region

#Region "  ﾚｼﾞｽﾀ読込み(ﾜｰﾄﾞ単位)"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾚｼﾞｽﾀ読込み(ﾜｰﾄﾞ単位)
    ''' </summary>
    ''' <param name="bytSlaveAdrs">
    ''' ｽﾚｰﾌﾞｱﾄﾞﾚｽ
    ''' </param>
    ''' <param name="intAdrs">
    ''' 最初の保持ﾚｼﾞｽﾀ番号-40001
    ''' 例えば、40108を取得した場合は、「40108-40001=107」で、107をｾｯﾄする。
    ''' </param>
    ''' <param name="intSize">
    ''' 取得したいﾚｼﾞｽﾀ個数
    ''' 1～125
    ''' </param>
    ''' <param name="intData">
    ''' 取得したﾃﾞｰﾀを配列でｾｯﾄする
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function AreaRead(ByVal bytSlaveAdrs As Byte _
                           , ByVal intAdrs As Integer _
                           , ByVal intSize As Integer _
                           , ByRef intData() As Integer _
                             ) _
                             As ComPLCYaskawa.clsPLC.RetCode
        Dim intReturn As RetCode = RetCode.NG           '関数戻値


        '*****************************************************
        '初期設定
        '*****************************************************
        Dim strSendTel() As Byte = Nothing      '送信用電文
        Dim strRecvTel() As Byte = Nothing      '受信用電文
        Dim intRecvTelLength As Integer = 5 + (intSize * 2)     '受信電文長
        Dim intSendAdrs As Integer = intAdrs - 40001            '電文送信用ｱﾄﾞﾚｽ
        ReDim intData(intSize - 1)                              '初期化
        Call AddToDebugLog(MSG_701 & "[ｽﾚｰﾌﾞｱﾄﾞﾚｽ:" & TO_STRING(bytSlaveAdrs) & "][先頭保持ｱﾄﾞﾚｽ:" & TO_STRING(intAdrs) & "][取得個数:" & TO_STRING(intSize) & "]")


        '*****************************************************
        '入力ﾁｪｯｸ
        '*****************************************************
        If Not (40001 <= intAdrs And intAdrs <= (40001 + 65535)) Then
            Throw New Exception("取得するｱﾄﾞﾚｽの指定が不正です。[ｱﾄﾞﾚｽ:" & TO_STRING(intAdrs) & "]")
        ElseIf Not (1 <= intSize And intSize <= 125) Then
            Throw New Exception("取得したいﾚｼﾞｽﾀ個数の指定が不正です。[ﾚｼﾞｽﾀ個数:" & TO_STRING(intSize) & "]")
        End If


        '*****************************************************
        '送信ﾃｷｽﾄ用へ変換
        '*****************************************************
        '===========================================
        'CRC抜きの電文作成
        '===========================================
        ReDim strSendTel(5)
        strSendTel(0) = bytSlaveAdrs                   'ｱﾄﾞﾚｽ
        strSendTel(1) = 3                              'ﾌｧﾝｸｼｮﾝ(03固定)
        strSendTel(2) = intSendAdrs \ 256              '開始番号
        strSendTel(3) = intSendAdrs Mod 256            '開始番号
        strSendTel(4) = 0                              '個数(1～125しか受け付けないので、0固定)
        strSendTel(5) = intSize                        '個数

        '===========================================
        'CRC作成を付加
        '===========================================
        Call AddCRC(strSendTel)


        '**********************************************************************************************************
        '**********************************************************************************************************
        '電文送信
        '**********************************************************************************************************
        '**********************************************************************************************************
        Dim intSendCount As Integer = 0         '再送信回数
        Dim dtmBeforeSendTime As Date           '前回送信日時
        'Dim blnRecvSuccess As Boolean = False   '電文受信成功ﾌﾗｸﾞ
        mobjSerial.bytSendText = strSendTel
        While intSendCount <= mintSendRetry
            '(ﾙｰﾌﾟ:ﾘﾄﾗｲｵｰﾊﾞｰするまで)


            '*****************************************************
            'ﾘﾄﾗｲｵｰﾊﾞｰ      判定
            '*****************************************************
            If intSendCount = mintSendRetry Then
                '(ﾘﾄﾗｲｵｰﾊﾞｰの場合)
                Call AddToDebugLog(MSG_012)
                Exit While
            End If


            '*****************************************************
            '電文送信
            '*****************************************************
            mobjSerial.Send()           '電文送信
            intSendCount += 1           '再送信回数
            dtmBeforeSendTime = Now     '前回送信日時
            Call AddToDebugLog(MSG_501 & mobjASCII.GetLogString16(mobjSerial.bytSendText))
            System.Threading.Thread.Sleep(300)

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2016/08/18 ﾊﾟﾌｫｰﾏﾝｽ改善 ↓↓↓↓↓↓
            System.Windows.Forms.Application.DoEvents()
            'JobMate:S.Ouchi 2016/08/18 ﾊﾟﾌｫｰﾏﾝｽ改善 ↑↑↑↑↑↑
            '↑↑↑↑↑↑************************************************************************************************************

            '*****************************************************
            '電文受信
            '*****************************************************
            While True
                '(ﾙｰﾌﾟ:電文受信 or ﾀｲﾑｱｳﾄ)

                '============================================
                '電文受信
                '============================================
                mobjSerial.Receive()           '電文受信
                If IsNotNull(mobjSerial.bytRecvText) Then
                    '(電文を受信した場合)

                    '============================================
                    '受信電文を配列に追加
                    '============================================
                    If IsNull(strRecvTel) Then
                        ReDim strRecvTel(UBound(mobjSerial.bytRecvText))
                        strRecvTel = mobjSerial.bytRecvText
                    Else
                        Dim intTemp As Integer = UBound(strRecvTel) + 1     'ｺﾋﾟｰを開始する位置
                        ReDim Preserve strRecvTel(UBound(strRecvTel) + mobjSerial.bytRecvText.Length)
                        Array.Copy(mobjSerial.bytRecvText, 0, strRecvTel, intTemp, mobjSerial.bytRecvText.Length)
                    End If
                    Call AddToDebugLog(MSG_602 & mobjASCII.GetLogString16(strRecvTel))


                    '============================================
                    '電文長判定
                    '============================================
                    If intRecvTelLength <= strRecvTel.Length Then
                        '(必要ﾊﾞｲﾄ受信した場合)
                        Exit While
                    End If
                    System.Threading.Thread.Sleep(50)

                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2016/08/18 ﾊﾟﾌｫｰﾏﾝｽ改善 ↓↓↓↓↓↓
                    System.Windows.Forms.Application.DoEvents()
                    'JobMate:S.Ouchi 2016/08/18 ﾊﾟﾌｫｰﾏﾝｽ改善 ↑↑↑↑↑↑
                    '↑↑↑↑↑↑************************************************************************************************************

                End If

                '============================================
                'ﾀｲﾑｱｳﾄ判定
                '============================================
                Dim objDiff As TimeSpan = dtmBeforeSendTime.AddMilliseconds(mintSendTimeout) - Now
                If 0 < objDiff.TotalMilliseconds Then
                    Continue While
                Else
                    Call AddToDebugLog(MSG_011)
                    Exit While
                End If


            End While


            '*****************************************************
            '電文判定
            '*****************************************************
            Dim blnTelErr As Boolean = False        '電文受信ｴﾗｰﾌﾗｸﾞ
            If IsNull(strRecvTel) Then
                '(電文受信していない場合)
                blnTelErr = True
            Else
                '(電文受信している場合)

                '========================================
                'ﾛｸﾞ出力
                '========================================
                Call AddToDebugLog(MSG_601 & mobjASCII.GetLogString16(strRecvTel))

                '========================================
                '電文長ﾁｪｯｸ
                '========================================
                If Not (intRecvTelLength = strRecvTel.Length) Then
                    Call AddToLog("受信電文長異常[正常長:" & intRecvTelLength & "]" _
                                              & "[受信長:" & strRecvTel.Length & "]")
                    blnTelErr = True
                End If

                '========================================
                'ｽﾚｰﾌﾞｱﾄﾞﾚｽﾁｪｯｸ
                '========================================
                If IsNotNull(strRecvTel) Then
                    '(ﾃﾞｰﾀ数が入っていた場合)
                    If Not (bytSlaveAdrs = strRecvTel(0)) Then
                        Call AddToLog("ｽﾚｰﾌﾞｱﾄﾞﾚｽ異常[正常:" & bytSlaveAdrs & "]" _
                                                  & "[受信:" & strRecvTel(0) & "]")
                        blnTelErr = True
                    End If
                Else
                    '(ﾃﾞｰﾀ数が入っていない場合)
                    Call AddToLog("ｽﾚｰﾌﾞｱﾄﾞﾚｽ異常。ﾃﾞｰﾀが入っていません。")
                    blnTelErr = True
                End If

                '========================================
                'ﾌｧﾝｸｼｮﾝｺｰﾄﾞﾁｪｯｸ
                '========================================
                If 1 <= UBound(strRecvTel) Then
                    '(ﾃﾞｰﾀ数が入っていた場合)
                    If Not (3 = strRecvTel(1)) Then
                        Call AddToLog("ﾌｧﾝｸｼｮﾝｺｰﾄﾞ異常[正常:" & "3" & "]" _
                                                   & "[受信:" & strRecvTel(1) & "]")
                        blnTelErr = True
                    End If
                Else
                    '(ﾃﾞｰﾀ数が入っていない場合)
                    Call AddToLog("ﾌｧﾝｸｼｮﾝｺｰﾄﾞ異常。ﾃﾞｰﾀが入っていません。")
                    blnTelErr = True
                End If

                '========================================
                'ﾃﾞｰﾀ数ﾁｪｯｸ
                '========================================
                If 2 <= UBound(strRecvTel) Then
                    '(ﾃﾞｰﾀ数が入っていた場合)
                    If Not (intSize * 2 = strRecvTel(2)) Then
                        Call AddToLog("受信電文ﾃﾞｰﾀ数異常[正常長:" & intSize & "]" _
                                                      & "[受信長:" & strRecvTel(3) & "]")
                        blnTelErr = True
                    End If
                Else
                    '(ﾃﾞｰﾀ数が入っていない場合)
                    Call AddToLog("受信電文ﾃﾞｰﾀ数異常。ﾃﾞｰﾀが入っていません。")
                    blnTelErr = True
                End If

                '========================================
                'CRCﾁｪｯｸ
                '========================================
                Dim bytCRCRecv(1) As Byte                   'CRC
                Dim bytTemp(strRecvTel.Length - 3) As Byte  'CRC作成用ﾃﾝﾎﾟﾗﾘ
                Array.Copy(strRecvTel, 0, bytTemp, 0, bytTemp.Length)
                Call MakeCRC(bytTemp, bytCRCRecv)
                If Not (bytCRCRecv(0) = strRecvTel(UBound(strRecvTel) - 1) And bytCRCRecv(1) = strRecvTel(UBound(strRecvTel) - 0)) Then
                    Call AddToLog("受信電文CRC異常[正常CRC:" & Change10To16(bytCRCRecv(0), 2) & Change10To16(bytCRCRecv(1), 2) & "]" _
                                               & "[受信CRC:" & Change10To16(strRecvTel(UBound(strRecvTel) - 1), 2) & Change10To16(strRecvTel(UBound(strRecvTel) - 0), 2) & "]")
                    blnTelErr = True
                End If

            End If


            '*****************************************************
            'ﾚｼﾞｽﾀ値ｾｯﾄ
            '*****************************************************
            If blnTelErr = False Then
                '(正常電文の場合)
                For ii As Integer = 0 To intSize - 1
                    '(ﾙｰﾌﾟ:取得したいﾚｼﾞｽﾀ数)
                    intData(ii) = (strRecvTel(3 + (ii * 2)) * 256) + strRecvTel(4 + (ii * 2))
                Next
                intReturn = RetCode.OK
                Exit While
            Else
                '(異常電文の場合)
                strRecvTel = Nothing
            End If


        End While


        Return intReturn
    End Function
#End Region
#Region "  ﾚｼﾞｽﾀ書込み(ﾜｰﾄﾞ単位)"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾚｼﾞｽﾀ書込み(ﾜｰﾄﾞ単位)
    ''' </summary>
    ''' <param name="bytSlaveAdrs">
    ''' ｽﾚｰﾌﾞｱﾄﾞﾚｽ
    ''' </param>
    ''' <param name="intAdrs">
    ''' 最初の保持ﾚｼﾞｽﾀ番号-40001
    ''' 例えば、40108を取得した場合は、「40108-40001=107」で、107をｾｯﾄする。
    ''' </param>
    ''' <param name="intData">
    ''' 取得したﾃﾞｰﾀを配列でｾｯﾄする
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function AreaWrite(ByVal bytSlaveAdrs As Byte _
                            , ByVal intAdrs As Integer _
                            , ByVal intData() As Integer _
                              ) _
                              As ComPLCYaskawa.clsPLC.RetCode
        Dim intReturn As ComPLCYaskawa.clsPLC.RetCode = RetCode.NG                   '関数戻値


        '*****************************************************
        '初期設定
        '*****************************************************
        Dim strSendTel() As Byte = Nothing      '送信用電文
        Dim strRecvTel() As Byte = Nothing      '受信用電文
        Dim intSendAdrs As Integer = intAdrs - 40001            '電文送信用ｱﾄﾞﾚｽ
        Call AddToDebugLog(MSG_711 & "[ｽﾚｰﾌﾞｱﾄﾞﾚｽ:" & TO_STRING(bytSlaveAdrs) & "][先頭保持ｱﾄﾞﾚｽ:" & TO_STRING(intAdrs) & "][取得個数:" & TO_STRING(intData.Length) & "]")


        '*****************************************************
        '入力ﾁｪｯｸ
        '*****************************************************
        If Not (40001 <= intAdrs And intAdrs <= (40001 + 65535)) Then
            Throw New Exception("取得するｱﾄﾞﾚｽの指定が不正です。[ｱﾄﾞﾚｽ:" & TO_STRING(intAdrs) & "]")
        ElseIf Not (1 <= intData.Length And intData.Length <= 100) Then
            Throw New Exception("取得したいﾚｼﾞｽﾀ個数の指定が不正です。[ﾚｼﾞｽﾀ個数:" & TO_STRING(intData.Length) & "]")
        End If


        '*****************************************************
        '送信ﾃｷｽﾄ用へ変換
        '*****************************************************
        '===========================================
        'CRC抜きの電文作成
        '===========================================
        ReDim strSendTel(6 + (intData.Length * 2))
        strSendTel(0) = bytSlaveAdrs                   'ｱﾄﾞﾚｽ
        strSendTel(1) = 16                             'ﾌｧﾝｸｼｮﾝ(03固定)
        strSendTel(2) = intSendAdrs \ 256              '開始番号
        strSendTel(3) = intSendAdrs Mod 256            '開始番号
        strSendTel(4) = 0                              '個数(1～100しか受け付けないので、0固定)
        strSendTel(5) = intData.Length                 '個数
        strSendTel(6) = intData.Length * 2             '書込みﾃﾞｰﾀ数
        For ii As Integer = 0 To intData.Length - 1
            '(ﾙｰﾌﾟ:書込ﾃﾞｰﾀ数)
            strSendTel(7 + (ii * 2)) = intData(ii) \ 256
            strSendTel(7 + (ii * 2) + 1) = intData(ii) Mod 256
        Next

        '===========================================
        'CRC作成を付加
        '===========================================
        Call AddCRC(strSendTel)


        '**********************************************************************************************************
        '**********************************************************************************************************
        '電文送信
        '**********************************************************************************************************
        '**********************************************************************************************************
        Dim intSendCount As Integer = 0         '再送信回数
        Dim dtmBeforeSendTime As Date           '前回送信日時
        'Dim blnRecvSuccess As Boolean = False   '電文受信成功ﾌﾗｸﾞ
        mobjSerial.bytSendText = strSendTel
        While intSendCount <= mintSendRetry
            '(ﾙｰﾌﾟ:ﾘﾄﾗｲｵｰﾊﾞｰするまで)


            '*****************************************************
            'ﾘﾄﾗｲｵｰﾊﾞｰ      判定
            '*****************************************************
            If intSendCount = mintSendRetry Then
                '(ﾘﾄﾗｲｵｰﾊﾞｰの場合)
                Call AddToDebugLog(MSG_012)
                Exit While
            End If


            '*****************************************************
            '電文送信
            '*****************************************************
            mobjSerial.Send()           '電文送信
            intSendCount += 1           '再送信回数
            dtmBeforeSendTime = Now     '前回送信日時
            Call AddToDebugLog(MSG_501 & mobjASCII.GetLogString16(mobjSerial.bytSendText))


            '*****************************************************
            '電文受信
            '*****************************************************
            While True
                '(ﾙｰﾌﾟ:電文受信 or ﾀｲﾑｱｳﾄ)

                '============================================
                '電文受信
                '============================================
                mobjSerial.Receive()           '電文受信
                If IsNotNull(mobjSerial.bytRecvText) Then
                    '(電文を受信した場合)

                    '============================================
                    '受信電文を配列に追加
                    '============================================
                    If IsNull(strRecvTel) Then
                        ReDim strRecvTel(UBound(mobjSerial.bytRecvText))
                        strRecvTel = mobjSerial.bytRecvText
                    Else
                        Dim intTemp As Integer = UBound(strRecvTel) + 1     'ｺﾋﾟｰを開始する位置
                        ReDim Preserve strRecvTel(UBound(strRecvTel) + mobjSerial.bytRecvText.Length)
                        Array.Copy(mobjSerial.bytRecvText, 0, strRecvTel, intTemp, mobjSerial.bytRecvText.Length)
                    End If
                    Call AddToDebugLog(MSG_602 & mobjASCII.GetLogString16(strRecvTel))


                    '============================================
                    '電文長判定
                    '============================================
                    If 8 <= strRecvTel.Length Then
                        '(必要ﾊﾞｲﾄ受信した場合)
                        Exit While
                    End If
                    System.Threading.Thread.Sleep(10)

                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2016/08/18 ﾊﾟﾌｫｰﾏﾝｽ改善 ↓↓↓↓↓↓
                    System.Windows.Forms.Application.DoEvents()
                    'JobMate:S.Ouchi 2016/08/18 ﾊﾟﾌｫｰﾏﾝｽ改善 ↑↑↑↑↑↑
                    '↑↑↑↑↑↑************************************************************************************************************

                End If

                '============================================
                'ﾀｲﾑｱｳﾄ判定
                '============================================
                Dim objDiff As TimeSpan = dtmBeforeSendTime.AddMilliseconds(mintSendTimeout) - Now
                If 0 < objDiff.TotalMilliseconds Then
                    Continue While
                Else
                    Call AddToDebugLog(MSG_011)
                    Exit While
                End If


            End While


            '*****************************************************
            '電文判定
            '*****************************************************
            Dim blnTelErr As Boolean = False        '電文受信ｴﾗｰﾌﾗｸﾞ
            If IsNull(strRecvTel) Then
                '(電文受信していない場合)
                blnTelErr = True
            Else
                '(電文受信している場合)

                '========================================
                'ﾛｸﾞ出力
                '========================================
                Call AddToDebugLog(MSG_601 & mobjASCII.GetLogString16(strRecvTel))

                '========================================
                '電文長ﾁｪｯｸ
                '========================================
                If Not (8 = strRecvTel.Length) Then
                    Call AddToLog("受信電文長異常[正常長:" & "8" & "]" _
                                              & "[受信長:" & strRecvTel.Length & "]")
                    blnTelErr = True
                End If

                '========================================
                'ｽﾚｰﾌﾞｱﾄﾞﾚｽﾁｪｯｸ
                '========================================
                If IsNotNull(strRecvTel) Then
                    '(ﾃﾞｰﾀ数が入っていた場合)
                    If Not (bytSlaveAdrs = strRecvTel(0)) Then
                        Call AddToLog("ｽﾚｰﾌﾞｱﾄﾞﾚｽ異常[正常:" & bytSlaveAdrs & "]" _
                                                  & "[受信:" & strRecvTel(0) & "]")
                        blnTelErr = True
                    End If
                Else
                    '(ﾃﾞｰﾀ数が入っていない場合)
                    Call AddToLog("ｽﾚｰﾌﾞｱﾄﾞﾚｽ異常。ﾃﾞｰﾀが入っていません。")
                    blnTelErr = True
                End If

                '========================================
                'ﾌｧﾝｸｼｮﾝｺｰﾄﾞﾁｪｯｸ
                '========================================
                If 1 <= UBound(strRecvTel) Then
                    '(ﾃﾞｰﾀ数が入っていた場合)
                    If Not (16 = strRecvTel(1)) Then
                        Call AddToLog("ﾌｧﾝｸｼｮﾝｺｰﾄﾞ異常[正常:" & "16" & "]" _
                                                   & "[受信:" & strRecvTel(1) & "]")
                        blnTelErr = True
                    End If
                Else
                    '(ﾃﾞｰﾀ数が入っていない場合)
                    Call AddToLog("ﾌｧﾝｸｼｮﾝｺｰﾄﾞ異常。ﾃﾞｰﾀが入っていません。")
                    blnTelErr = True
                End If

                '========================================
                'ﾚｼﾞｽﾀｱﾄﾞﾚｽﾁｪｯｸ
                '========================================
                If 5 <= UBound(strRecvTel) Then
                    '(ﾃﾞｰﾀ数が入っていた場合)
                    If (Not (intSendAdrs = (256 * strRecvTel(2)) + strRecvTel(3))) Then
                        Call AddToLog("ﾚｼﾞｽﾀｱﾄﾞﾚｽ異常[正常:" & intSendAdrs & "]" _
                                                  & "[受信:" & TO_STRING((256 * strRecvTel(4)) + strRecvTel(5)) & "]")
                        blnTelErr = True
                    End If
                Else
                    '(ﾃﾞｰﾀ数が入っていない場合)
                    Call AddToLog("ﾚｼﾞｽﾀｱﾄﾞﾚｽ異常。ﾃﾞｰﾀが入っていません。")
                    blnTelErr = True
                End If

                '========================================
                'ﾃﾞｰﾀ数ﾁｪｯｸ
                '========================================
                If 5 <= UBound(strRecvTel) Then
                    '(ﾃﾞｰﾀ数が入っていた場合)
                    If Not (intData.Length = strRecvTel(5)) Then
                        Call AddToLog("受信電文ﾃﾞｰﾀ数異常[正常長:" & intData.Length & "]" _
                                                      & "[受信長:" & strRecvTel(5) & "]")
                        blnTelErr = True
                    End If
                Else
                    '(ﾃﾞｰﾀ数が入っていない場合)
                    Call AddToLog("受信電文ﾃﾞｰﾀ数異常。ﾃﾞｰﾀが入っていません。")
                    blnTelErr = True
                End If

                '========================================
                'CRCﾁｪｯｸ
                '========================================
                Dim bytCRCRecv(1) As Byte                   'CRC
                Dim bytTemp(strRecvTel.Length - 3) As Byte  'CRC作成用ﾃﾝﾎﾟﾗﾘ
                Array.Copy(strRecvTel, 0, bytTemp, 0, bytTemp.Length)
                Call MakeCRC(bytTemp, bytCRCRecv)
                If Not (bytCRCRecv(0) = strRecvTel(UBound(strRecvTel) - 1) And bytCRCRecv(1) = strRecvTel(UBound(strRecvTel) - 0)) Then
                    Call AddToLog("受信電文CRC異常[正常CRC:" & Change10To16(bytCRCRecv(0), 2) & Change10To16(bytCRCRecv(1), 2) & "]" _
                                               & "[受信CRC:" & Change10To16(strRecvTel(UBound(strRecvTel) - 1), 2) & Change10To16(strRecvTel(UBound(strRecvTel) - 0), 2) & "]")
                    blnTelErr = True
                End If

            End If


            '*****************************************************
            '電文受信判定
            '*****************************************************
            If blnTelErr = False Then
                '(正常電文の場合)
                intReturn = RetCode.OK
                Exit While
            Else
                '(異常電文の場合)
                strRecvTel = Nothing
            End If


        End While


        Return intReturn
    End Function
#End Region
#Region "  通信ｵｰﾌﾟﾝ            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】なし
    '*******************************************************************************************************************
    Public Sub Open()


        '****************************************************
        'ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ       作成
        '****************************************************
        If IsNothing(mobjSerial) = True Then
            '(ｿｹｯﾄｸﾗｲｱﾝﾄｵﾌﾞｼﾞｪｸﾄが存在しなかった場合)
            mobjSerial = New clsSerial(mobjOwner)
        End If


        '****************************************************
        'ｼﾘｱﾙ通信ｵﾌﾞｼﾞｪｸﾄ       ｵｰﾌﾟﾝ
        '****************************************************
        mobjSerial.strRecvPort = mstrCOMRecvPort                     'ﾎﾟｰﾄ番号
        mobjSerial.intRecvBaud = mintCOMRecvBaud                     '通信速度
        mobjSerial.strRecvParity = mstrCOMRecvParity                 'ﾊﾟﾘﾃｨ
        mobjSerial.intRecvDataLength = mintCOMRecvDataLength         'ﾃﾞｰﾀ長
        mobjSerial.strRecvStopBit = mstrCOMRecvStopBit               'ｽﾄｯﾌﾟﾋﾞｯﾄ長
        mobjSerial.intCodePage = mintCOMCodePage                     '通信に使用するﾃｷｽﾄのｺｰﾄﾞ  (932:ShiftJIS)
        mobjSerial.strComName = mstrCOMComName                       '通信名
        mobjSerial.Open()                                            '通信確立


    End Sub
#End Region
#Region "  通信ｸﾛｰｽﾞ            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】なし
    '*******************************************************************************************************************
    Public Sub Close()


        mobjSerial.Close()


    End Sub
#End Region

#Region "  CRC作成を付加        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' CRC作成を付加
    ''' </summary>
    ''' <param name="strSendTel">送信電文</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddCRC(ByRef strSendTel() As Byte)


        '*****************************************************
        'CRC取得
        '*****************************************************
        Dim bytCRCSend(1) As Byte
        Call MakeCRC(strSendTel, bytCRCSend)


        '*****************************************************
        'CRCを配列に追加
        '*****************************************************
        ReDim Preserve strSendTel(UBound(strSendTel) + 2)
        strSendTel(UBound(strSendTel) - 1) = bytCRCSend(0)
        strSendTel(UBound(strSendTel) - 0) = bytCRCSend(1)


    End Sub
#End Region
#Region "  CRC作成              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' CRC作成
    ''' </summary>
    ''' <param name="strSendTel">送信電文</param>
    ''' <param name="bytCRC">CRC</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub MakeCRC(ByVal strSendTel() As Byte _
                     , ByRef bytCRC() As Byte _
                     )
        ReDim bytCRC(1)     '初期化


        '****************************************************
        'CRC        作成
        '****************************************************
        Dim shrKotei As UShort = 40961              '固定値(1010 0000 0000 0001)
        Dim shrCRC As UShort = UShort.MaxValue      'CRC
        For ii As Integer = 0 To UBound(strSendTel)
            '(ﾙｰﾌﾟ:ﾊﾞｲﾄ配列の数だけ)

            '=======================================
            '電文と仮CRCとのXor
            '=======================================
            shrCRC = shrCRC Xor strSendTel(ii)


            For jj As Integer = 1 To 8
                '(ﾙｰﾌﾟ:上位8ﾋﾞｯﾄ(実際には下位8ﾋﾞｯﾄ))


                If Microsoft.VisualBasic.Right(Change10To2(shrCRC, 16), 1) = "0" Then
                    '(0の場合)

                    '=======================================
                    '右ｼﾌﾄ
                    '2で割ると右ｼﾌﾄする
                    '=======================================
                    shrCRC = shrCRC \ 2

                Else
                    '(1の場合)

                    '=======================================
                    '右ｼﾌﾄ
                    '2で割ると右ｼﾌﾄする
                    '=======================================
                    shrCRC = shrCRC \ 2

                    '=======================================
                    '固定値と仮CRCとのXor
                    '=======================================
                    shrCRC = shrCRC Xor shrKotei

                End If


            Next

        Next


        '****************************************************
        '引数にｾｯﾄ
        '****************************************************
        bytCRC(0) = shrCRC Mod 256
        bytCRC(1) = shrCRC \ 256


    End Sub
#End Region


#Region "  ｴﾗｰ処理"
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


        Throw New Exception(objException.Message)
    End Sub
#End Region
#Region "  ﾛｸﾞ書き込み処理                  "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書き込み処理
    ''' </summary>
    ''' <param name="strMsg_1">ﾛｸﾞﾃｷｽﾄ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)

        mobjOwner.AddToLog(strMsg_1)

    End Sub
#End Region
#Region "  ﾛｸﾞ書き込み処理(ﾃﾞﾊﾞｯｸﾞ用)       "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書き込み処理(ﾃﾞﾊﾞｯｸﾞ用)
    ''' </summary>
    ''' <param name="strMsg_1">ﾛｸﾞﾃｷｽﾄ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddToDebugLog(ByVal strMsg_1 As String)

        If mintDebugFlag = 0 Then
            mobjOwner.AddToManyLog(strMsg_1)
        End If

    End Sub
#End Region

End Class
