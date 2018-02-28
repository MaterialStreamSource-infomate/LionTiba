'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】Melsec通信ｸﾗｽ
' 【作成】2005/10/18　KSH/N.Dounoshita　Rev 0.00　初版
'**********************************************************************************************

Public Class clsMelsec

#Region "  共通変数 "

    '==================================================
    '共通変数
    '==================================================
    Private mobjOwner As Object                                 'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Private mobjSocketClient As clsSocketClient                 'ｿｹｯﾄｸﾗｲｱﾝﾄ   ｵﾌﾞｼﾞｪｸﾄ
    Private mobjASCII As clsASCII                               'ASCIIｺｰﾄﾞ文字ｸﾗｽ

    '==================================================
    'ﾌﾟﾛﾊﾟﾃｨ変数
    '==================================================
    Private mstrSockMelSendAddress As String        '送信先ｱﾄﾞﾚｽ
    Private mintSockMelSendPort As Integer          '送信先ﾎﾟｰﾄNo
    Private mintSockRetry As Integer                '送信ﾘﾄﾗｲ回数(回)
    Private mintSockTimeOut As Integer              'ﾀｲﾑｱｳﾄ時間(秒)
    Private mintACPUTimer As Integer                'ACPU監視ﾀｲﾏ
    'その他
    Private mintDebugFlag As Integer                'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ

    '==================================================
    '列挙体
    '==================================================
    Public Enum RetCode
        OK = 1                      '正常終了
        NG = 2                      'ﾌﾟﾛｸﾞﾗﾑ上でのｴﾗｰ
        ResNothing = 3              'PLCから応答が返って来ない
    End Enum

    Public Enum RegType
        D = 1       'ﾃﾞｰﾀﾚｼﾞｽﾀ
        W = 2       'ﾘﾝｸﾚｼﾞｽﾀ
        R = 3       'ﾌｧｲﾙﾚｼﾞｽﾀ
        TN = 4      'ﾀｲﾏ現在値
        TS = 5      'ﾀｲﾏ接点
        TC = 6      'ﾀｲﾏｺｲﾙ
        CN = 7      'ｶｳﾝﾀ現在値
        CS = 8      'ｶｳﾝﾀ接点
        CC = 9      'ｶｳﾝﾀｺｲﾙ
        X = 10      '入力
        Y = 11      '出力
        M = 12      '内部ﾘﾚｰ
        B = 13      'ﾘﾝｸﾘﾚｰ
        F = 14      'ｱﾅﾝｼｪｰﾀ
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
#Region "  ﾌﾟﾛﾊﾟﾃｨ"

    Public Property strSockMelSendAddress() As String
        Get
            Return mstrSockMelSendAddress
        End Get
        Set(ByVal Value As String)
            mstrSockMelSendAddress = Value
        End Set
    End Property

    Public Property intSockMelSendPort() As Integer
        Get
            Return mintSockMelSendPort
        End Get
        Set(ByVal Value As Integer)
            mintSockMelSendPort = Value
        End Set
    End Property

    Public Property intSockRetry() As Integer
        Get
            Return mintSockRetry
        End Get
        Set(ByVal Value As Integer)
            mintSockRetry = Value
        End Set
    End Property

    Public Property intSockTimeOut() As Integer
        Get
            Return mintSockTimeOut
        End Get
        Set(ByVal Value As Integer)
            mintSockTimeOut = Value
        End Set
    End Property

    Public Property intACPUTimer() As Integer
        Get
            Return mintACPUTimer
        End Get
        Set(ByVal Value As Integer)
            mintACPUTimer = Value
        End Set
    End Property

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
            If IsNotNull(mobjSocketClient) Then mobjSocketClient.intDebugFlag = Value 'ｼﾘｱﾙ通信ｸﾗｽ
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
        mobjOwner = objOwner                    'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
        mobjASCII = New clsASCII()              'ASCIIｺｰﾄﾞ文字ｸﾗｽ
        mstrSockMelSendAddress = ""             '送信先ｱﾄﾞﾚｽ
        mintSockMelSendPort = 0                 '送信先ﾎﾟｰﾄNo
        mintSockRetry = 0                       '送信ﾘﾄﾗｲ回数(回)
        mintSockTimeOut = 10                    'ﾀｲﾑｱｳﾄ時間(秒)
        mintACPUTimer = 2560                    'ACPU監視ﾀｲﾏ
        mintDebugFlag = 0                       'ﾛｸﾞ書込ﾌﾗｸﾞ


    End Sub
#End Region

#Region "  ﾚｼﾞｽﾀ読込み(ﾜｰﾄﾞ単位)"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[IN ]intNetNo       ﾈｯﾄﾜｰｸ番号
    '        [IN ]intPlcNo       PC番号
    '        [IN ]udtREG_TYPE    ﾚｼﾞｽﾀﾀｲﾌﾟ
    '        [IN ]strAdrs        先頭ﾚｼﾞｽﾀ
    '        [IN ]intSize        読込みﾜｰﾄﾞ数
    '        [OUT]intData()      ﾃﾞｰﾀ値
    '*******************************************************************************************************************
    Public Function AreaRead(ByVal intNetNo As Integer _
                           , ByVal intPlcNo As Integer _
                           , ByVal udtREG_TYPE As RegType _
                           , ByVal strAdrs As String _
                           , ByVal intSize As Integer _
                           , ByRef intData() As Integer _
                             ) _
                             As RetCode


        Dim strSendText As String       '送信用ﾃｷｽﾄ
        Dim lngLoop As Long             'ﾙｰﾌﾟ用
        Dim blnBit As Boolean           'ﾘﾚｰ:True、ﾚｼﾞｽﾀ:False
        Dim intResSize As Integer       '応答ﾃﾞｰﾀ数

        '*****************************************************
        '送信ﾃｷｽﾄ用へ変換
        '*****************************************************
        '===========================================
        'ﾍｯﾀﾞ(TCP/IP、UDP/IP側で付加)
        '===========================================
        '===========================================
        'ｻﾌﾞﾍｯﾀﾞ(QnA互換3Eﾌﾚｰﾑ:ASCIIｺｰﾄﾞで交信する場合、5000固定)
        '===========================================
        Dim strSubHead As String = "5000"

        '===========================================
        'ﾈｯﾄﾜｰｸ番号
        '===========================================
        Dim strNetNo As String = ""
        If intNetNo = &H0 Or intPlcNo = &HFE Or (&H1 <= intNetNo And intNetNo <= &HEF) Then
            '(正常の場合)
            strNetNo = Change10To16(intNetNo, 2)
        Else
            '(異常の場合)
            Throw New Exception("ﾈｯﾄﾜｰｸ番号異常:" & CStr(intNetNo))
        End If

        '===========================================
        'PC番号
        '===========================================
        Dim strPlcNo As String = ""             'PC番号
        If intPlcNo = &HFF Or intPlcNo = &H7D Or intPlcNo = &H7E Or (&H1 <= intPlcNo And intPlcNo <= &H78) Then
            '(正常の場合)
            strPlcNo = Change10To16(intPlcNo, 2)
        Else
            '(異常の場合)
            Throw New Exception("PC番号異常:" & CStr(intPlcNo))
        End If

        '===========================================
        'I/O番号 要求先ﾕﾆｯﾄ
        '===========================================
        Dim strIO As String = "03FF"

        '===========================================
        '局番号 要求先ﾕﾆｯﾄ
        '===========================================
        Dim strKyoku As String = "00"

        '===========================================
        'ACPU監視ﾀｲﾏ
        '===========================================
        Dim strACPUTimer As String = ZERO_PAD(mintACPUTimer, 4)

        '===========================================
        'ｺﾏﾝﾄﾞ、ｻﾌﾞｺﾏﾝﾄﾞ
        '===========================================
        Dim strCommand As String = "0401"       'ｺﾏﾝﾄﾞ(一括読込み)
        Dim strSubCommand As String = ""
        Select Case udtREG_TYPE
            Case RegType.D, RegType.W, RegType.R, RegType.TN, RegType.CN
                strSubCommand = "0000"          'ｻﾌﾞｺﾏﾝﾄﾞ(ﾜｰﾄﾞ単位)
                blnBit = False
            Case Else
                strSubCommand = "0001"          'ｻﾌﾞｺﾏﾝﾄﾞ(ﾋﾞｯﾄ単位)
                blnBit = True
        End Select


        '===========================================
        'ﾃﾞﾊﾞｲｽｺｰﾄﾞ
        '===========================================
        Dim strREG_TYPE As String = ""
        Select Case udtREG_TYPE
            Case RegType.D : strREG_TYPE = "D*"       'ﾃﾞｰﾀﾚｼﾞｽﾀ
            Case RegType.W : strREG_TYPE = "W*"       'ﾘﾝｸﾚｼﾞｽﾀ
            Case RegType.R : strREG_TYPE = "R*"       'ﾌｧｲﾙﾚｼﾞｽﾀ
            Case RegType.TS : strREG_TYPE = "TS"      'ﾀｲﾏ接点
            Case RegType.TC : strREG_TYPE = "TC"      'ﾀｲﾏｺｲﾙ
            Case RegType.TN : strREG_TYPE = "TN"      'ﾀｲﾏ現在値
            Case RegType.CS : strREG_TYPE = "CS"      'ｶｳﾝﾀ接点
            Case RegType.CC : strREG_TYPE = "CC"      'ｶｳﾝﾀｺｲﾙ
            Case RegType.CN : strREG_TYPE = "CN"      'ｶｳﾝﾀ現在値
            Case RegType.X : strREG_TYPE = "X*"       '入力
            Case RegType.Y : strREG_TYPE = "Y*"       '出力
            Case RegType.M : strREG_TYPE = "M*"       '内部ﾘﾚｰ
            Case RegType.B : strREG_TYPE = "B*"       'ﾘﾝｸﾘﾚｰ
            Case RegType.F : strREG_TYPE = "F*"       'ｱﾅﾝｼｪｰﾀ
        End Select

        '===========================================
        '先頭ﾃﾞﾊﾞｲｽ番号(ﾚｼﾞｽﾀｱﾄﾞﾚｽ)
        '===========================================
        Dim strAdrsSend As String = ZERO_PAD(strAdrs, 6)

        '===========================================
        'ﾃﾞﾊﾞｲｽ点数
        '===========================================
        Dim strSize As String = Change10To16(intSize, 4)

        '===========================================
        '要求ﾃﾞｰﾀ長
        '===========================================
        Dim strLength As String = ""    '要求ﾃﾞｰﾀ長
        strLength &= strACPUTimer       'CPU監視ﾀｲﾏ
        strLength &= strCommand         'ｺﾏﾝﾄﾞ
        strLength &= strSubCommand      'ｻﾌﾞｺﾏﾝﾄﾞ
        strLength &= strREG_TYPE        'ﾃﾞﾊﾞｲｽｺｰﾄﾞ
        strLength &= strAdrsSend        '先頭ﾃﾞﾊﾞｲｽ
        strLength &= strSize            'ﾃﾞﾊﾞｲｽ点数
        strLength = Change10To16(Len(strLength), 4)         '要求ﾃﾞｰﾀ長(CPU監視ﾀｲﾏの項目から要求ﾃﾞｰﾀ部の最後のﾊﾞｲﾄまでのﾊﾞｲﾄｻｲｽﾞ)

        '*****************************************************
        'ﾃｷｽﾄ作成ﾃﾞｰﾀﾌｫｰﾏｯﾄ(QnA互換3Eﾌﾚｰﾑ)
        '*****************************************************
        strSendText = ""
        strSendText &= strSubHead       'ｻﾌﾞﾍｯﾀﾞ(QnA互換3Eﾌﾚｰﾑ:ASCIIｺｰﾄﾞで交信する場合、5000固定)
        strSendText &= strNetNo         'ﾈｯﾄﾜｰｸ番号
        strSendText &= strPlcNo         'PC番号
        strSendText &= strIO            'I/O番号 要求先ﾕﾆｯﾄ
        strSendText &= strKyoku         '局番号 要求先ﾕﾆｯﾄ
        strSendText &= strLength        '要求ﾃﾞｰﾀ長
        strSendText &= strACPUTimer     'ACPU監視ﾀｲﾏ
        strSendText &= strCommand       'ｺﾏﾝﾄﾞ
        strSendText &= strSubCommand    'ｻﾌﾞｺﾏﾝﾄﾞ
        strSendText &= strREG_TYPE      'ﾃﾞﾊﾞｲｽｺｰﾄﾞ
        strSendText &= strAdrsSend      '先頭ﾃﾞﾊﾞｲｽ番号(ﾚｼﾞｽﾀｱﾄﾞﾚｽ)
        strSendText &= strSize          'ﾃﾞﾊﾞｲｽ点数

        '全て大文字に変換
        strSendText = strSendText.ToUpper

        '*****************************************************
        'ｿｹｯﾄ送信
        '*****************************************************
        Dim lngRetry As Long = 0
Retry:
        mobjSocketClient.strSendText = strSendText
        mobjSocketClient.Send()

        '*****************************************************
        'ｿｹｯﾄ受信
        '*****************************************************
        Dim strRecv As String
        Dim strErrCode As String

        System.Threading.Thread.Sleep(4)

        If mobjSocketClient.Receive(-1) = RetCode.NG Then
            lngRetry += 1
            If lngRetry >= mintSockRetry Then
                Throw New Exception("ﾘﾄﾗｲ回数ｵｰﾊﾞｰ")
            End If
            GoTo Retry
        Else
            strRecv = mobjSocketClient.strRecvText

            strErrCode = Mid(strRecv, 19, 4)        'ｴﾗｺｰﾄﾞ

            '*****************************************************
            '受信電文 展開
            '*****************************************************
            strSubHead = Mid(strRecv, 1, 4)         'ｻﾌﾞﾍｯﾀﾞ
            strNetNo = Mid(strRecv, 5, 2)           'ﾈｯﾄﾜｰｸ番号
            strPlcNo = Mid(strRecv, 7, 2)           'PC番号
            strIO = Mid(strRecv, 9, 4)              'I/O番号 要求先ﾕﾆｯﾄ
            strKyoku = Mid(strRecv, 13, 2)          '局番号 要求先ﾕﾆｯﾄ
            strLength = Mid(strRecv, 15, 4)         '応答ﾃﾞｰﾀ長
            If blnBit Then
                intResSize = (Change16To10(strLength) - 4)
            Else
                intResSize = (Change16To10(strLength) - 4) / 4
            End If

            If strErrCode <> "0000" Then
                '(異常の場合)
                strNetNo = Mid(strRecv, 23, 2)          'ﾈｯﾄﾜｰｸ番号
                strPlcNo = Mid(strRecv, 25, 2)          'PC番号
                strIO = Mid(strRecv, 27, 4)             'I/O番号 要求先ﾕﾆｯﾄ
                strKyoku = Mid(strRecv, 31, 2)          '局番号 要求先ﾕﾆｯﾄ
                strCommand = Mid(strRecv, 33, 4)        'ｺﾏﾝﾄﾞ
                strSubCommand = Mid(strRecv, 37, 4)     'ｻﾌﾞｺﾏﾝﾄﾞ
                Throw New Exception("異常終了:" & strErrCode)
            Else
                '(正常の場合)
                If intResSize <> intSize Then
                    lngRetry += 1
                    If lngRetry >= mintSockRetry Then
                        Throw New Exception("ﾘﾄﾗｲ回数ｵｰﾊﾞｰ")
                    End If
                    GoTo Retry
                End If

                For lngLoop = 0 To intSize - 1
                    If blnBit = True Then
                        '(ﾘﾚｰの場合)
                        intData(lngLoop) = Change16To10(Mid(strRecv, lngLoop * 1 + 23, 1))
                    Else
                        '(ﾚｼﾞｽﾀの場合)
                        intData(lngLoop) = Change16To10(Mid(strRecv, lngLoop * 4 + 23, 4))
                    End If
                Next lngLoop
            End If

        End If

    End Function
#End Region
#Region "  ﾚｼﾞｽﾀ書込み(ﾜｰﾄﾞ単位)"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[IN ]intNetNo       ﾈｯﾄﾜｰｸ番号
    '        [IN ]intPlcNo       PC番号
    '        [IN ]strREG_TYPE    ﾚｼﾞｽﾀﾀｲﾌﾟ
    '        [IN ]strAdrs        先頭ﾚｼﾞｽﾀ
    '        [IN ]intSize        書込みﾜｰﾄﾞ数
    '        [OUT]intData()      ﾃﾞｰﾀ値
    '*******************************************************************************************************************
    Public Function AreaWrite(ByVal intNetNo As Integer _
                           , ByVal intPlcNo As Integer _
                           , ByVal udtREG_TYPE As RegType _
                           , ByVal strAdrs As String _
                           , ByVal intSize As Integer _
                           , ByRef intData() As Integer _
                             ) _
                              As RetCode

        Dim strSendText As String       '送信用ﾃｷｽﾄ
        Dim lngLoop As Long             'ﾙｰﾌﾟ用
        Dim blnBit As Boolean           'ﾘﾚｰ:True、ﾚｼﾞｽﾀ:False
        Dim intResSize As Integer       '応答ﾃﾞｰﾀ数

        '*****************************************************
        '送信ﾃｷｽﾄ用へ変換
        '*****************************************************
        '===========================================
        'ﾍｯﾀﾞ(TCP/IP、UDP/IP側で付加)
        '===========================================
        '===========================================
        'ｻﾌﾞﾍｯﾀﾞ(QnA互換3Eﾌﾚｰﾑ:ASCIIｺｰﾄﾞで交信する場合、5000固定)
        '===========================================
        Dim strSubHead As String = "5000"

        '===========================================
        'ﾈｯﾄﾜｰｸ番号
        '===========================================
        Dim strNetNo As String = ""
        If intNetNo = &H0 Or intPlcNo = &HFE Or (&H1 <= intNetNo And intNetNo <= &HEF) Then
            '(正常の場合)
            strNetNo = Change10To16(intNetNo, 2)
        Else
            '(異常の場合)
            Throw New Exception("ﾈｯﾄﾜｰｸ番号異常:" & CStr(intNetNo))
        End If

        '===========================================
        'PC番号
        '===========================================
        Dim strPlcNo As String = ""             'PC番号
        If intPlcNo = &HFF Or intPlcNo = &H7D Or intPlcNo = &H7E Or (&H1 <= intPlcNo And intPlcNo <= &H78) Then
            '(正常の場合)
            strPlcNo = Change10To16(intPlcNo, 2)
        Else
            '(異常の場合)
            Throw New Exception("PC番号異常:" & CStr(intPlcNo))
        End If

        '===========================================
        'I/O番号 要求先ﾕﾆｯﾄ
        '===========================================
        Dim strIO As String = "03FF"

        '===========================================
        '局番号 要求先ﾕﾆｯﾄ
        '===========================================
        Dim strKyoku As String = "00"

        '===========================================
        'ACPU監視ﾀｲﾏ
        '===========================================
        Dim strACPUTimer As String = ZERO_PAD(mintACPUTimer, 4)

        '===========================================
        'ｺﾏﾝﾄﾞ、ｻﾌﾞｺﾏﾝﾄﾞ
        '===========================================
        Dim strCommand As String = "1401"       'ｺﾏﾝﾄﾞ(一括書込み)
        Dim strSubCommand As String = ""
        Select Case udtREG_TYPE
            Case RegType.D, RegType.W, RegType.R, RegType.TN, RegType.CN
                strSubCommand = "0000"          'ｻﾌﾞｺﾏﾝﾄﾞ(ﾜｰﾄﾞ単位)
                blnBit = False
            Case Else
                strSubCommand = "0001"          'ｻﾌﾞｺﾏﾝﾄﾞ(ﾋﾞｯﾄ単位)
                blnBit = True
        End Select

        '===========================================
        'ﾃﾞﾊﾞｲｽｺｰﾄﾞ
        '===========================================
        Dim strREG_TYPE As String = ""
        Select Case udtREG_TYPE
            Case RegType.D : strREG_TYPE = "D*"       'ﾃﾞｰﾀﾚｼﾞｽﾀ
            Case RegType.W : strREG_TYPE = "W*"       'ﾘﾝｸﾚｼﾞｽﾀ
            Case RegType.R : strREG_TYPE = "R*"       'ﾌｧｲﾙﾚｼﾞｽﾀ
            Case RegType.TS : strREG_TYPE = "TS"      'ﾀｲﾏ接点
            Case RegType.TC : strREG_TYPE = "TC"      'ﾀｲﾏｺｲﾙ
            Case RegType.TN : strREG_TYPE = "TN"      'ﾀｲﾏ現在値
            Case RegType.CS : strREG_TYPE = "CS"      'ｶｳﾝﾀ接点
            Case RegType.CC : strREG_TYPE = "CC"      'ｶｳﾝﾀｺｲﾙ
            Case RegType.CN : strREG_TYPE = "CN"      'ｶｳﾝﾀ現在値
            Case RegType.X : strREG_TYPE = "X*"       '入力
            Case RegType.Y : strREG_TYPE = "Y*"       '出力
            Case RegType.M : strREG_TYPE = "M*"       '内部ﾘﾚｰ
            Case RegType.B : strREG_TYPE = "B*"       'ﾘﾝｸﾘﾚｰ
            Case RegType.F : strREG_TYPE = "F*"       'ｱﾅﾝｼｪｰﾀ
        End Select

        '===========================================
        '先頭ﾃﾞﾊﾞｲｽ番号(ﾚｼﾞｽﾀｱﾄﾞﾚｽ)
        '===========================================
        Dim strAdrsSend As String = ZERO_PAD(strAdrs, 6)

        '===========================================
        'ﾃﾞﾊﾞｲｽ点数
        '===========================================
        Dim strSize As String = Change10To16(intSize, 4)

        '===========================================
        '要求ﾃﾞｰﾀ(指定ﾃﾞﾊﾞｲｽ点数分のﾃﾞｰﾀ)
        '===========================================
        Dim strData As String = ""
        For lngLoop = 1 To intSize
            If blnBit Then
                '(ﾘﾚｰの場合)
                strData &= Change10To16(intData(lngLoop - 1), 1)
            Else
                '(ﾚｼﾞｽﾀの場合)
                strData &= Change10To16(intData(lngLoop - 1), 4)
            End If
        Next

        '===========================================
        '要求ﾃﾞｰﾀ長
        '===========================================
        Dim strLength As String = ""    '要求ﾃﾞｰﾀ長
        strLength &= strACPUTimer       'CPU監視ﾀｲﾏ
        strLength &= strCommand         'ｺﾏﾝﾄﾞ
        strLength &= strSubCommand      'ｻﾌﾞｺﾏﾝﾄﾞ
        strLength &= strREG_TYPE        'ﾃﾞﾊﾞｲｽｺｰﾄﾞ
        strLength &= strAdrsSend        '先頭ﾃﾞﾊﾞｲｽ
        strLength &= strSize            'ﾃﾞﾊﾞｲｽ点数
        strLength &= strData            '要求ﾃﾞｰﾀ
        strLength = Change10To16(Len(strLength), 4)         '要求ﾃﾞｰﾀ長(CPU監視ﾀｲﾏの項目から要求ﾃﾞｰﾀ部の最後のﾊﾞｲﾄまでのﾊﾞｲﾄｻｲｽﾞ)

        '*****************************************************
        'ﾃｷｽﾄ作成ﾃﾞｰﾀﾌｫｰﾏｯﾄ(QnA互換3Eﾌﾚｰﾑ)
        '*****************************************************
        strSendText = ""
        strSendText &= strSubHead       'ｻﾌﾞﾍｯﾀﾞ(QnA互換3Eﾌﾚｰﾑ:ASCIIｺｰﾄﾞで交信する場合、5000固定)
        strSendText &= strNetNo         'ﾈｯﾄﾜｰｸ番号
        strSendText &= strPlcNo         'PC番号
        strSendText &= strIO            'I/O番号 要求先ﾕﾆｯﾄ
        strSendText &= strKyoku         '局番号 要求先ﾕﾆｯﾄ
        strSendText &= strLength        '要求ﾃﾞｰﾀ長
        strSendText &= strACPUTimer     'ACPU監視ﾀｲﾏ
        strSendText &= strCommand       'ｺﾏﾝﾄﾞ
        strSendText &= strSubCommand    'ｻﾌﾞｺﾏﾝﾄﾞ
        strSendText &= strREG_TYPE      'ﾃﾞﾊﾞｲｽｺｰﾄﾞ
        strSendText &= strAdrsSend      '先頭ﾃﾞﾊﾞｲｽ番号(ﾚｼﾞｽﾀｱﾄﾞﾚｽ)
        strSendText &= strSize          'ﾃﾞﾊﾞｲｽ点数
        strSendText &= strData       '要求ﾃﾞｰﾀ(指定ﾃﾞﾊﾞｲｽ点数分のﾃﾞｰﾀ)

        '全て大文字に変換
        strSendText = strSendText.ToUpper

        '*****************************************************
        'ｿｹｯﾄ送信
        '*****************************************************
        Dim lngRetry As Long = 0
Retry:
        mobjSocketClient.strSendText = strSendText
        mobjSocketClient.Send()

        '*****************************************************
        'ｿｹｯﾄ受信
        '*****************************************************
        Dim strRecv As String
        Dim strErrCode As String

        System.Threading.Thread.Sleep(4)

        If mobjSocketClient.Receive(-1) = RetCode.NG Then
            lngRetry += 1
            If lngRetry >= mintSockRetry Then
                Throw New Exception("ﾘﾄﾗｲ回数ｵｰﾊﾞｰ")
            End If
            GoTo Retry
        Else
            strRecv = mobjSocketClient.strRecvText

            strErrCode = Mid(strRecv, 19, 4)        'ｴﾗｺｰﾄﾞ

            '*****************************************************
            '受信電文 展開
            '*****************************************************
            strSubHead = Mid(strRecv, 1, 4)         'ｻﾌﾞﾍｯﾀﾞ
            strNetNo = Mid(strRecv, 5, 2)           'ﾈｯﾄﾜｰｸ番号
            strPlcNo = Mid(strRecv, 7, 2)           'PC番号
            strIO = Mid(strRecv, 9, 4)              'I/O番号 要求先ﾕﾆｯﾄ
            strKyoku = Mid(strRecv, 13, 2)          '局番号 要求先ﾕﾆｯﾄ
            strLength = Mid(strRecv, 15, 4)         '応答ﾃﾞｰﾀ長
            intResSize = (Change16To10(strLength) - 4)

            If strErrCode <> "0000" Then
                '(異常の場合)
                strNetNo = Mid(strRecv, 23, 2)          'ﾈｯﾄﾜｰｸ番号
                strPlcNo = Mid(strRecv, 25, 2)          'PC番号
                strIO = Mid(strRecv, 27, 4)             'I/O番号 要求先ﾕﾆｯﾄ
                strKyoku = Mid(strRecv, 31, 2)          '局番号 要求先ﾕﾆｯﾄ
                strCommand = Mid(strRecv, 33, 4)        'ｺﾏﾝﾄﾞ
                strSubCommand = Mid(strRecv, 37, 4)     'ｻﾌﾞｺﾏﾝﾄﾞ
                Throw New Exception("異常終了:" & strErrCode)
            Else
                '(正常の場合)
                If intResSize <> 0 Then
                    lngRetry += 1
                    If lngRetry >= mintSockRetry Then
                        Throw New Exception("ﾘﾄﾗｲ回数ｵｰﾊﾞｰ")
                    End If
                    GoTo Retry
                End If
            End If

        End If

    End Function
#End Region
    'AJ71E71
#Region "  ﾚｼﾞｽﾀ読込み(ﾜｰﾄﾞ単位)"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾚｼﾞｽﾀ読込み AJ71E71(ﾜｰﾄﾞ単位)
    ''' </summary>
    ''' <param name="intPlcNo">PC番号</param>
    ''' <param name="udtREG_TYPE">ﾚｼﾞｽﾀﾀｲﾌﾟ</param>
    ''' <param name="intAdrs">先頭ﾚｼﾞｽﾀ</param>
    ''' <param name="intSize">読込みﾜｰﾄﾞ数</param>
    ''' <param name="intData">ﾃﾞｰﾀ値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function AreaReadAJ71E71(ByVal intPlcNo As Integer _
                                  , ByVal udtREG_TYPE As RegType _
                                  , ByVal intAdrs As Integer _
                                  , ByVal intSize As Integer _
                                  , ByRef intData() As Integer _
                                    ) _
                                    As ComMelsec.clsMelsec.RetCode
        Dim intReturn As ComMelsec.clsMelsec.RetCode = RetCode.NG           '関数戻値


        '*****************************************************
        '再接続
        '*****************************************************
        Try
            Call Close()
        Catch ex As Exception
            Call ComError(ex)
        End Try
        Try
            Call Open()
        Catch ex As Exception
            Call ComError(ex)
        End Try


        '*****************************************************
        '初期設定
        '*****************************************************
        Dim strSendTel() As Byte = Nothing      '送信用電文
        Dim strRecvTel() As Byte = Nothing      '受信用電文
        Dim intRecvTelLength As Integer = 2 + (intSize * 2)     '受信電文長
        ReDim intData(intSize - 1)                              '初期化
        Dim strACPUTimer As String = Change10To16(mintACPUTimer, 4)     'ACPU監視ﾀｲﾏ(16進数)
        Dim strAdrs16 As String = Change10To16(intAdrs, 8)              '先頭ﾚｼﾞｽﾀ
        Call AddToDebugLog(MSG_701 & "[PC番号:" & TO_STRING(intPlcNo) & "][ﾚｼﾞｽﾀﾀｲﾌﾟ:" & udtREG_TYPE & "][先頭ﾚｼﾞｽﾀ:" & intAdrs & "][読込みﾜｰﾄﾞ数:" & TO_STRING(intSize) & "]")


        '*****************************************************
        '入力ﾁｪｯｸ
        '*****************************************************
        If Not (0 <= intSize And intSize <= 256) Then
            '【備考】0の場合は、256を意味する
            Throw New Exception("読込みﾜｰﾄﾞ数の指定が不正です。[読込みﾜｰﾄﾞ数:" & TO_STRING(intSize) & "]")
        End If


        '*****************************************************
        '送信ﾃｷｽﾄ用へ変換
        '*****************************************************
        '===========================================
        '電文作成
        '===========================================
        ReDim strSendTel(11)
        strSendTel(0) = 1                                       'ｻﾌﾞﾍｯﾀﾞ(1固定)
        strSendTel(1) = intPlcNo                                'PC番号
        strSendTel(2) = Change16To10(Mid(strACPUTimer, 1, 2))   'ACPU監視ﾀｲﾏｰ
        strSendTel(3) = Change16To10(Mid(strACPUTimer, 3, 2))   'ACPU監視ﾀｲﾏｰ
        strSendTel(4) = Change16To10(Mid(strAdrs16, 7, 2))      '先頭ﾚｼﾞｽﾀ
        strSendTel(5) = Change16To10(Mid(strAdrs16, 5, 2))      '先頭ﾚｼﾞｽﾀ
        strSendTel(6) = Change16To10(Mid(strAdrs16, 3, 2))      '先頭ﾚｼﾞｽﾀ
        strSendTel(7) = Change16To10(Mid(strAdrs16, 1, 2))      '先頭ﾚｼﾞｽﾀ
        'strSendTel(8) =   'ﾃﾞﾊﾞｲｽｺｰﾄﾞ
        'strSendTel(9) =   'ﾃﾞﾊﾞｲｽｺｰﾄﾞ
        strSendTel(10) = IIf(intSize = 256, 0, intSize)         'ﾃﾞﾊﾞｲｽ点数
        strSendTel(11) = 0                                      '0固定

        '===========================================
        'ﾃﾞﾊﾞｲｽｺｰﾄﾞ
        '===========================================
        Dim strREG_TYPE As String = ""
        Select Case udtREG_TYPE
            Case RegType.D : strSendTel(9) = &H44 : strSendTel(8) = &H20    'ﾃﾞｰﾀﾚｼﾞｽﾀ
            Case RegType.W : strSendTel(9) = &H57 : strSendTel(8) = &H20    'ﾘﾝｸﾚｼﾞｽﾀ
            Case RegType.R : strSendTel(9) = &H52 : strSendTel(8) = &H20    'ﾌｧｲﾙﾚｼﾞｽﾀ
            Case RegType.TN : strSendTel(9) = &H54 : strSendTel(8) = &H4E   'ﾀｲﾏ現在値
            Case RegType.TS : strSendTel(9) = &H54 : strSendTel(8) = &H53   'ﾀｲﾏ接点
            Case RegType.TC : strSendTel(9) = &H54 : strSendTel(8) = &H43   'ﾀｲﾏｺｲﾙ
            Case RegType.CN : strSendTel(9) = &H43 : strSendTel(8) = &H4E   'ｶｳﾝﾀ現在値
            Case RegType.CS : strSendTel(9) = &H43 : strSendTel(8) = &H53   'ｶｳﾝﾀ接点
            Case RegType.CC : strSendTel(9) = &H43 : strSendTel(8) = &H43   'ｶｳﾝﾀｺｲﾙ
            Case RegType.X : strSendTel(9) = &H58 : strSendTel(8) = &H20    '入力
            Case RegType.Y : strSendTel(9) = &H59 : strSendTel(8) = &H20    '出力
            Case RegType.M : strSendTel(9) = &H4D : strSendTel(8) = &H20    '内部ﾘﾚｰ
            Case RegType.B : strSendTel(9) = &H42 : strSendTel(8) = &H20    'ﾘﾝｸﾘﾚｰ
            Case RegType.F : strSendTel(9) = &H46 : strSendTel(8) = &H20    'ｱﾅﾝｼｪｰﾀ
        End Select


        '**********************************************************************************************************
        '**********************************************************************************************************
        '電文送信
        '**********************************************************************************************************
        '**********************************************************************************************************
        Dim intSendCount As Integer = 0         '再送信回数
        Dim dtmBeforeSendTime As Date           '前回送信日時
        'Dim blnRecvSuccess As Boolean = False   '電文受信成功ﾌﾗｸﾞ
        mobjSocketClient.bytSendText = strSendTel
        While intSendCount <= mintSockRetry
            '(ﾙｰﾌﾟ:ﾘﾄﾗｲｵｰﾊﾞｰするまで)


            '*****************************************************
            'ﾘﾄﾗｲｵｰﾊﾞｰ      判定
            '*****************************************************
            If intSendCount = mintSockRetry Then
                '(ﾘﾄﾗｲｵｰﾊﾞｰの場合)
                Call AddToDebugLog(MSG_012)
                Exit While
            End If


            '*****************************************************
            '電文送信
            '*****************************************************
            mobjSocketClient.Send()     '電文送信
            intSendCount += 1           '再送信回数
            dtmBeforeSendTime = Now     '前回送信日時
            Call AddToDebugLog(MSG_501 & mobjASCII.GetLogString16(mobjSocketClient.bytSendText))


            '*****************************************************
            '電文受信
            '*****************************************************
            While True
                '(ﾙｰﾌﾟ:電文受信 or ﾀｲﾑｱｳﾄ)

                '============================================
                '電文受信
                '============================================
                mobjSocketClient.Receive(-1)           '電文受信
                If IsNotNull(mobjSocketClient.bytRecvText) Then
                    '(電文を受信した場合)

                    '============================================
                    '受信電文を配列に追加
                    '============================================
                    If IsNull(strRecvTel) Then
                        ReDim strRecvTel(UBound(mobjSocketClient.bytRecvText))
                        strRecvTel = mobjSocketClient.bytRecvText
                    Else
                        Dim intTemp As Integer = UBound(strRecvTel) + 1     'ｺﾋﾟｰを開始する位置
                        ReDim Preserve strRecvTel(UBound(strRecvTel) + mobjSocketClient.bytRecvText.Length)
                        Array.Copy(mobjSocketClient.bytRecvText, 0, strRecvTel, intTemp, mobjSocketClient.bytRecvText.Length)
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


                End If

                ''============================================
                ''ﾀｲﾑｱｳﾄ判定
                ''============================================
                'Dim objDiff As TimeSpan = dtmBeforeSendTime.AddMilliseconds(mintSendTimeout) - Now
                'If 0 < objDiff.TotalMilliseconds Then
                '    Continue While
                'Else
                '    Call AddToDebugLog(MSG_011)
                '    Exit While
                'End If


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
                'ｻﾌﾞﾍｯﾀﾞﾁｪｯｸ
                '========================================
                If 0 <= UBound(strRecvTel) Then
                    '(ｻﾌﾞﾍｯﾀﾞ数が入っていた場合)
                    If Not (&H81 = strRecvTel(0)) Then
                        Call AddToLog("ｻﾌﾞﾍｯﾀﾞ異常[正常:" & TO_STRING(&H81) & "]" _
                                               & "[受信:" & strRecvTel(0) & "]")
                        blnTelErr = True
                    End If
                Else
                    '(ｻﾌﾞﾍｯﾀﾞ数が入っていない場合)
                    Call AddToLog("ｻﾌﾞﾍｯﾀﾞ異常。ﾃﾞｰﾀが入っていません。")
                    blnTelErr = True
                End If

                '========================================
                '終了ｺｰﾄﾞ
                '========================================
                If 1 <= UBound(strRecvTel) Then
                    '(終了ｺｰﾄﾞが入っていた場合)
                    If Not (&H0 = strRecvTel(1)) Then
                        Call AddToLog("終了ｺｰﾄﾞ異常[正常:" & TO_STRING(&H0) & "]" _
                                                & "[受信:" & strRecvTel(1) & "]")
                        blnTelErr = True
                    End If
                Else
                    '(終了ｺｰﾄﾞが入っていない場合)
                    Call AddToLog("終了ｺｰﾄﾞ異常。ﾃﾞｰﾀが入っていません。")
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
                    intData(ii) = (strRecvTel(3 + (ii * 2)) * 256) + strRecvTel(2 + (ii * 2))
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
    ''' <param name="intPlcNo">PC番号</param>
    ''' <param name="udtREG_TYPE">ﾚｼﾞｽﾀﾀｲﾌﾟ</param>
    ''' <param name="intAdrs">先頭ﾚｼﾞｽﾀ</param>
    ''' <param name="intSize">書込みﾜｰﾄﾞ数</param>
    ''' <param name="intData">ﾃﾞｰﾀ値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function AreaWriteAJ71E71(ByVal intPlcNo As Integer _
                                   , ByVal udtREG_TYPE As RegType _
                                   , ByVal intAdrs As String _
                                   , ByVal intSize As Integer _
                                   , ByVal intData() As Integer _
                                     ) _
                                    As ComMelsec.clsMelsec.RetCode
        Dim intReturn As ComMelsec.clsMelsec.RetCode = RetCode.NG           '関数戻値


        '*****************************************************
        '再接続
        '*****************************************************
        Try
            Call Close()
        Catch ex As Exception
            Call ComError(ex)
        End Try
        Try
            Call Open()
        Catch ex As Exception
            Call ComError(ex)
        End Try


        '*****************************************************
        '初期設定
        '*****************************************************
        Dim strSendTel() As Byte = Nothing      '送信用電文
        Dim strRecvTel() As Byte = Nothing      '受信用電文
        Dim intSendTelLength As Integer = 12 + (intSize * 2)    '受信電文長
        ''''''''''Dim intSendTelLength As Integer = 11 + (intSize * 2)    '受信電文長
        Dim strACPUTimer As String = Change10To16(mintACPUTimer, 4)     'ACPU監視ﾀｲﾏ(16進数)
        Dim strAdrs16 As String = Change10To16(intAdrs, 8)              '先頭ﾚｼﾞｽﾀ
        Call AddToDebugLog(MSG_701 & "[PC番号:" & TO_STRING(intPlcNo) & "][ﾚｼﾞｽﾀﾀｲﾌﾟ:" & udtREG_TYPE & "][先頭ﾚｼﾞｽﾀ:" & intAdrs & "][読込みﾜｰﾄﾞ数:" & TO_STRING(intSize) & "]")


        '*****************************************************
        '入力ﾁｪｯｸ
        '*****************************************************
        If Not (0 <= intSize And intSize <= 256) Then
            '【備考】0の場合は、256を意味する
            Throw New Exception("読込みﾜｰﾄﾞ数の指定が不正です。[読込みﾜｰﾄﾞ数:" & TO_STRING(intSize) & "]")
        End If


        '*****************************************************
        '送信ﾃｷｽﾄ用へ変換
        '*****************************************************
        '===========================================
        '電文作成
        '===========================================
        ReDim strSendTel(intSendTelLength)
        strSendTel(0) = 3                                       'ｻﾌﾞﾍｯﾀﾞ(1固定)
        strSendTel(1) = intPlcNo                                'PC番号
        strSendTel(2) = Change16To10(Mid(strACPUTimer, 1, 2))   'ACPU監視ﾀｲﾏｰ
        strSendTel(3) = Change16To10(Mid(strACPUTimer, 3, 2))   'ACPU監視ﾀｲﾏｰ
        strSendTel(4) = Change16To10(Mid(strAdrs16, 7, 2))      '先頭ﾚｼﾞｽﾀ
        strSendTel(5) = Change16To10(Mid(strAdrs16, 5, 2))      '先頭ﾚｼﾞｽﾀ
        strSendTel(6) = Change16To10(Mid(strAdrs16, 3, 2))      '先頭ﾚｼﾞｽﾀ
        strSendTel(7) = Change16To10(Mid(strAdrs16, 1, 2))      '先頭ﾚｼﾞｽﾀ
        'strSendTel(8) =   'ﾃﾞﾊﾞｲｽｺｰﾄﾞ
        'strSendTel(9) =   'ﾃﾞﾊﾞｲｽｺｰﾄﾞ
        strSendTel(10) = IIf(intSize = 256, 0, intSize)         'ﾃﾞﾊﾞｲｽ点数
        strSendTel(11) = 0                                      '0固定

        '===========================================
        'ﾃﾞﾊﾞｲｽｺｰﾄﾞ
        '===========================================
        Dim strREG_TYPE As String = ""
        Select Case udtREG_TYPE
            Case RegType.D : strSendTel(9) = &H44 : strSendTel(8) = &H20    'ﾃﾞｰﾀﾚｼﾞｽﾀ
            Case RegType.W : strSendTel(9) = &H57 : strSendTel(8) = &H20    'ﾘﾝｸﾚｼﾞｽﾀ
            Case RegType.R : strSendTel(9) = &H52 : strSendTel(8) = &H20    'ﾌｧｲﾙﾚｼﾞｽﾀ
            Case RegType.TN : strSendTel(9) = &H54 : strSendTel(8) = &H4E   'ﾀｲﾏ現在値
            Case RegType.TS : strSendTel(9) = &H54 : strSendTel(8) = &H53   'ﾀｲﾏ接点
            Case RegType.TC : strSendTel(9) = &H54 : strSendTel(8) = &H43   'ﾀｲﾏｺｲﾙ
            Case RegType.CN : strSendTel(9) = &H43 : strSendTel(8) = &H4E   'ｶｳﾝﾀ現在値
            Case RegType.CS : strSendTel(9) = &H43 : strSendTel(8) = &H53   'ｶｳﾝﾀ接点
            Case RegType.CC : strSendTel(9) = &H43 : strSendTel(8) = &H43   'ｶｳﾝﾀｺｲﾙ
            Case RegType.X : strSendTel(9) = &H58 : strSendTel(8) = &H20    '入力
            Case RegType.Y : strSendTel(9) = &H59 : strSendTel(8) = &H20    '出力
            Case RegType.M : strSendTel(9) = &H4D : strSendTel(8) = &H20    '内部ﾘﾚｰ
            Case RegType.B : strSendTel(9) = &H42 : strSendTel(8) = &H20    'ﾘﾝｸﾘﾚｰ
            Case RegType.F : strSendTel(9) = &H46 : strSendTel(8) = &H20    'ｱﾅﾝｼｪｰﾀ
        End Select

        '===========================================
        '書込みﾃﾞｰﾀ
        '===========================================
        For ii As Integer = 0 To intData.Length - 1
            '(ﾙｰﾌﾟ:書込ﾃﾞｰﾀ数)
            strSendTel(12 + (ii * 2) + 1) = intData(ii) \ 256
            strSendTel(12 + (ii * 2)) = intData(ii) Mod 256
        Next


        '**********************************************************************************************************
        '**********************************************************************************************************
        '電文送信
        '**********************************************************************************************************
        '**********************************************************************************************************
        Dim intSendCount As Integer = 0         '再送信回数
        Dim dtmBeforeSendTime As Date           '前回送信日時
        'Dim blnRecvSuccess As Boolean = False   '電文受信成功ﾌﾗｸﾞ
        mobjSocketClient.bytSendText = strSendTel
        While intSendCount <= mintSockRetry
            '(ﾙｰﾌﾟ:ﾘﾄﾗｲｵｰﾊﾞｰするまで)


            '*****************************************************
            'ﾘﾄﾗｲｵｰﾊﾞｰ      判定
            '*****************************************************
            If intSendCount = mintSockRetry Then
                '(ﾘﾄﾗｲｵｰﾊﾞｰの場合)
                Call AddToDebugLog(MSG_012)
                Exit While
            End If


            '*****************************************************
            '電文送信
            '*****************************************************
            mobjSocketClient.Send()     '電文送信
            intSendCount += 1           '再送信回数
            dtmBeforeSendTime = Now     '前回送信日時
            Call AddToDebugLog(MSG_501 & mobjASCII.GetLogString16(mobjSocketClient.bytSendText))


            '*****************************************************
            '電文受信
            '*****************************************************
            While True
                '(ﾙｰﾌﾟ:電文受信 or ﾀｲﾑｱｳﾄ)

                '============================================
                '電文受信
                '============================================
                mobjSocketClient.Receive(-1)           '電文受信
                If IsNotNull(mobjSocketClient.bytRecvText) Then
                    '(電文を受信した場合)

                    '============================================
                    '受信電文を配列に追加
                    '============================================
                    If IsNull(strRecvTel) Then
                        ReDim strRecvTel(UBound(mobjSocketClient.bytRecvText))
                        strRecvTel = mobjSocketClient.bytRecvText
                    Else
                        Dim intTemp As Integer = UBound(strRecvTel) + 1     'ｺﾋﾟｰを開始する位置
                        ReDim Preserve strRecvTel(UBound(strRecvTel) + mobjSocketClient.bytRecvText.Length)
                        Array.Copy(mobjSocketClient.bytRecvText, 0, strRecvTel, intTemp, mobjSocketClient.bytRecvText.Length)
                    End If
                    Call AddToDebugLog(MSG_602 & mobjASCII.GetLogString16(strRecvTel))


                    '============================================
                    '電文長判定
                    '============================================
                    If 2 <= strRecvTel.Length Then
                        '(必要ﾊﾞｲﾄ受信した場合)
                        Exit While
                    End If
                    System.Threading.Thread.Sleep(50)


                End If

                '============================================
                'ﾀｲﾑｱｳﾄ判定
                'ｿｹｯﾄ受信処理の中でﾀｲﾑｱｳﾄ判定を行っている
                '============================================
                Exit While
                'Dim objDiff As TimeSpan = dtmBeforeSendTime.AddMilliseconds(mintSendTimeout) - Now
                'If 0 < objDiff.TotalMilliseconds Then
                '    Continue While
                'Else
                '    Call AddToDebugLog(MSG_011)
                '    Exit While
                'End If


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
                If Not (2 = strRecvTel.Length) Then
                    Call AddToLog("受信電文長異常[正常長:" & "2" & "]" _
                                              & "[受信長:" & strRecvTel.Length & "]")
                    blnTelErr = True
                End If

                '========================================
                'ｻﾌﾞﾍｯﾀﾞﾁｪｯｸ
                '========================================
                If 0 <= UBound(strRecvTel) Then
                    '(ｻﾌﾞﾍｯﾀﾞ数が入っていた場合)
                    If Not (&H83 = strRecvTel(0)) Then
                        Call AddToLog("ｻﾌﾞﾍｯﾀﾞ異常[正常:" & TO_STRING(&H83) & "]" _
                                               & "[受信:" & strRecvTel(0) & "]")
                        blnTelErr = True
                    End If
                Else
                    '(ｻﾌﾞﾍｯﾀﾞ数が入っていない場合)
                    Call AddToLog("ｻﾌﾞﾍｯﾀﾞ異常。ﾃﾞｰﾀが入っていません。")
                    blnTelErr = True
                End If

                '========================================
                '終了ｺｰﾄﾞ
                '========================================
                If 1 <= UBound(strRecvTel) Then
                    '(終了ｺｰﾄﾞが入っていた場合)
                    If Not (&H0 = strRecvTel(1)) Then
                        Call AddToLog("終了ｺｰﾄﾞ異常[正常:" & TO_STRING(&H0) & "]" _
                                                & "[受信:" & strRecvTel(1) & "]")
                        blnTelErr = True
                    End If
                Else
                    '(終了ｺｰﾄﾞが入っていない場合)
                    Call AddToLog("終了ｺｰﾄﾞ異常。ﾃﾞｰﾀが入っていません。")
                    blnTelErr = True
                End If

            End If


            '*****************************************************
            'ﾚｼﾞｽﾀ値ｾｯﾄ
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
        If IsNothing(mobjSocketClient) = True Then
            '(ｿｹｯﾄｸﾗｲｱﾝﾄｵﾌﾞｼﾞｪｸﾄが存在しなかった場合)
            mobjSocketClient = New clsSocketClient(mobjOwner)
        End If
        mobjSocketClient.strAddress = mstrSockMelSendAddress        '送信先ｱﾄﾞﾚｽ
        mobjSocketClient.intPortNo = mintSockMelSendPort            '送信先ﾎﾟｰﾄNo
        mobjSocketClient.intTimeOut = mintSockTimeOut               'ﾀｲﾑｱｳﾄ時間(秒)
        mobjSocketClient.Connect()                                  '接続
        If mobjSocketClient.udtRet <> clsSocketClient.RetCode.OK Then
            Throw New Exception("通信ｵｰﾌﾟﾝ異常:" & mobjSocketClient.udtRet)
        End If


    End Sub
#End Region
#Region "  通信ｸﾛｰｽﾞ            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】なし
    '*******************************************************************************************************************
    Public Sub Close()


        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2015/08/24 CW6追加対応 ↓↓↓↓↓↓
        Try
            'JobMate:S.Ouchi 2015/08/24 CW6追加対応 ↑↑↑↑↑↑
            If IsNothing(mobjSocketClient) = False Then
                '↑↑↑↑↑↑************************************************************************************************************

                mobjSocketClient.ShutDown()

                '↓↓↓↓↓↓************************************************************************************************************
            End If
            'JobMate:S.Ouchi 2015/08/24 CW6追加対応 ↓↓↓↓↓↓
        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        Finally
            mobjSocketClient = Nothing
        End Try
        'JobMate:S.Ouchi 2015/08/24 CW6追加対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************

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

        If intDebugFlag = 0 Then
            mobjOwner.AddToManyLog(strMsg_1)
        End If

    End Sub
#End Region

End Class
