'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】通信ﾀﾞﾐｰﾒｲﾝｸﾗｽ              (KSH用ﾃﾞﾊﾞｯｸﾞﾂｰﾙです)
' 【作成】2006/05/30  SIT  Rev 0.00
'**********************************************************************************************

#Region "  Imports  "
Imports JobCommon
Imports MateCommon.clsConst
Imports MateCommon
Imports UserProcess
#End Region

Public Class clsMCIMainDummy

#Region "  共通変数02           "

    Private mobjSock As clsSocketListener               'ｿｹｯﾄﾘｽﾅｰｸﾗｽ
    Private mobjMCIMain As CtrlMCIG.clsMCIMain          '本当の通信ﾌﾟﾛｸﾞﾗﾑｸﾗｽ
    Private mobjGetTelegram As clsGetTelegram           '電文用ﾃｷｽﾄ取得ｸﾗｽ

    'AGCへのｿｹｯﾄ用
    Private mstrAGCSockSendAddress As String        'AGC送信先ｱﾄﾞﾚｽ
    Private mintAGCSockSendPort As Integer          'AGC送信先ﾎﾟｰﾄNo
    Private mintAGCSockSendTimeOut As Integer       'AGC応答ｿｹｯﾄ待機時間
    Private mintAGCSockETXSendTimeOut As Integer    'AGC定周期ETXｿｹｯﾄ送信時間 (ms)
    Private mintAGCSockETXRecvTimeOut As Integer    'AGC定周期ETXｿｹｯﾄ受信時間 (ms)
    'EQ電文受信用
    Private mintEQTelegramInforStartPosition As Integer     '「長さ情報」が入っている位置
    Private mintEQTelegramInforLength As Integer            '「長さ情報」の桁数
    Private mintEQTelegramHeaderLength As Integer           'ﾍｯﾀﾞｰ部分の桁数

    Private mintSendCount As Integer          '再送信回数
    Private mdtmBeforeRecvTime As Date        '前回受信日時
    Private mdtmBeforeSendTime As Date        '前回送信日時
    Private mdtmBeforeETXSendTime As Date     '前回ETX送信日時
    Private mdtmBeforeETXRecvTime As Date     '前回ETX受信日時
    Private mstrRecvTelBuff As String         'ｿｹｯﾄ受信ﾊﾞｯﾌｧ
    Private mblnIsConnect As Boolean          'ｿｹｯﾄ接続ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Private mintSendSEQNo As Integer        '送信SEQ№
    Private mintRecvSEQNo As Integer        '受信SEQ№

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ02            "

    ''' =======================================
    ''' <summary>送信SEQ№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intSendSEQNo() As Integer
        Get
            Return mintSendSEQNo
        End Get
        Set(ByVal Value As Integer)
            mintSendSEQNo = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>受信SEQ№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intRecvSEQNo() As Integer
        Get
            Return mintRecvSEQNo
        End Get
        Set(ByVal Value As Integer)
            mintRecvSEQNo = Value
        End Set
    End Property

#End Region

    '***********************************************
    '↓↓↓↓↓↓毎回必要
#Region "  共通変数             "

    '==================================================
    '共通ｵﾌﾞｼﾞｪｸﾄ
    '==================================================
    Private mobjOwner As Object                                 'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Private mobjDb As clsConn                                   'ｵﾗｸﾙ接続ｵﾌﾞｼﾞｪｸﾄ
    Private mobjDbLog As clsConn                                'ｵﾗｸﾙ接続ｵﾌﾞｼﾞｪｸﾄ
    Private mobjTPRG_SYS_HEN As TBL_TPRG_SYS_HEN                'ｼｽﾃﾑ変数
    Private mobjSockSvr As clsSocketToServer                    'ｻｰﾊﾞｰへｿｹｯﾄ送信ｸﾗｽ
    Private mobjASCII As clsASCII                               'ASCIIｺｰﾄﾞ文字ｸﾗｽ

    '==================================================
    '内部変数
    '==================================================
    Private mdtmNow As Date                     '現在日時
    Private mdtmBeforeDBTime As Date            '前回DB検索時間
    Private mblnSockSend As Boolean             'ｿｹｯﾄ送信ﾌﾗｸﾞ
    Private mblnSockEnd As Boolean              'ｿｹｯﾄ送信完了ﾌﾗｸﾞ

    '==================================================
    'Configﾌｧｲﾙ情報
    '==================================================
    'ｻｰﾊﾞｰへのｿｹｯﾄ用
    Private mstrSvrSockSendAddress As String        'ｻｰﾊﾞ送信先ｱﾄﾞﾚｽ
    Private mintSvrSockSendPort As Integer          'ｻｰﾊﾞ送信先ﾎﾟｰﾄNo
    Private mintSvrSockSendTimeOut As Integer       'ｻｰﾊﾞ応答ｿｹｯﾄ待機時間
    Private mstrSvrSockSendTermID As String         'ｻｰﾊﾞ端末ID
    Private mstrSvrSockSendUserID As String         'ｻｰﾊﾞﾕｰｻﾞｰID
    Private mstrSvrSockSendFlag As String           'ｻｰﾊﾞｿｹｯﾄ送信ﾌﾗｸﾞ
    'その他
    Private mintDBReadTimer As Integer              '送信ﾊﾞｯﾌｧﾃｰﾌﾞﾙを検索する周期 (秒)
    Private mstrFEQ_ID As String                    '制御PC区分
    Private mstrFMSG_ID_ERR_SYS As String           'ｼｽﾃﾑｴﾗｰ  時のﾒｯｾｰｼﾞID
    Private mstrFMSG_ID_ERR_USER As String          'ﾕｰｻﾞｰｴﾗｰ 時のﾒｯｾｰｼﾞID
    Private mintResetSleep As Integer               '通信ﾘｾｯﾄ時のｽﾘｰﾌﾟ時間(ms)  連続してﾘｾｯﾄを行わない為
    Private mintDebugFlag As Integer                'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ

    '==================================================
    '固定値
    '==================================================
    Private Const ERR_MSG_01 As String = "ｼｽﾃﾑｴﾗｰ発生。"

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ              "

    Public Property intDebugFlag() As Integer
        Get
            Return mintDebugFlag
        End Get
        Set(ByVal Value As Integer)
            mintDebugFlag = Value
            mobjSock.intDebugFlag = Value
        End Set
    End Property

#End Region

#Region "  ﾒｲﾝ処理              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub Main()
        Try
            mobjDb.BeginTrans()     'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            Try
                'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


                '*****************************************************
                '色々初期化
                '*****************************************************
                mdtmNow = Now


                '*****************************************************
                '電文受信
                '*****************************************************
                Dim strRecvText As String = ""          '受信電文
                Call RecvDataVAGC(strRecvText)


                '*****************************************************
                'ALC電文受信処理
                '*****************************************************
                Call MCIA_900002(strRecvText)


            Catch ex As Exception
                Call ComError(ex)
                mblnIsConnect = False

            Finally
                mobjDb.Commit()     'ｺﾐｯﾄ

            End Try
        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ  (主にﾛｸﾞ書込みに使用)</param>
    ''' <param name="objDb">ｵﾗｸﾙ接続ｸﾗｽ   (通常用)</param>
    ''' <param name="objDbLog">ｵﾗｸﾙ接続ｸﾗｽ   (ﾛｸﾞ用)</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, _
                   ByVal objDb As clsConn, _
                   ByVal objDbLog As clsConn _
                   )
        Try

            '*****************************************************
            '色々初期化
            '*****************************************************
            mobjOwner = objOwner                                'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
            mdtmBeforeDBTime = Now                              '前回DB検索時間
            mstrRecvTelBuff = ""                                'ｿｹｯﾄ受信ﾊﾞｯﾌｧ
            mdtmNow = Now
            mobjMCIMain = New CtrlMCIG.clsMCIMain(objOwner, objDb, objDbLog)    '本当の通信ﾌﾟﾛｸﾞﾗﾑｸﾗｽ

            '*****************************************************
            ' ｵﾗｸﾙ接続
            '*****************************************************
            mobjDb = objDb
            mobjDbLog = objDbLog


        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region
#Region "  初期化               "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Initialize()


        '*****************************************************
        ' 【ｼｽﾃﾑ変数】     接続ｸﾗｽ作成
        '*****************************************************
        mobjTPRG_SYS_HEN = New TBL_TPRG_SYS_HEN(mobjOwner, mobjDb, mobjDbLog)


        '*****************************************************
        '色々初期化
        '*****************************************************
        mintSendCount = 0                               'ﾘﾄﾗｲ回数
        mdtmBeforeRecvTime = Now                        '前回受信日時
        mdtmBeforeSendTime = Now                        '前回送信日時
        '' ''mdtmBeforeETXSendTime = Now                     '前回ETX送信日時(初期値)
        mdtmBeforeETXRecvTime = Now.AddSeconds(5)       '前回ETX受信日時(5秒加算)
        mobjASCII = New clsASCII()              'ASCIIｺｰﾄﾞ文字ｸﾗｽ
        mblnIsConnect = True                    'ｿｹｯﾄ接続ﾌﾗｸﾞ
        mobjGetTelegram = New clsGetTelegram(mobjOwner) '電文用ﾃｷｽﾄ取得ｸﾗｽ


        '*****************************************************
        'Configﾌｧｲﾙ情報取得(標準部分)
        '*****************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MCIA_DUMMY)                                     'Configﾌｧｲﾙ接続ｸﾗｽ生成

        'ｻｰﾊﾞｰｿｹｯﾄ用
        mstrSvrSockSendAddress = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_ADDRESS))              'ｻｰﾊﾞ送信先ｱﾄﾞﾚｽ
        mintSvrSockSendPort = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_PORT))                    'ｻｰﾊﾞ送信先ﾎﾟｰﾄNo
        mintSvrSockSendTimeOut = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_TIME_OUT))             'ｻｰﾊﾞ応答ｿｹｯﾄ待機時間
        mstrSvrSockSendTermID = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_TERM_ID))               'ｻｰﾊﾞ端末ID
        mstrSvrSockSendUserID = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_USER_ID))               'ｻｰﾊﾞﾕｰｻﾞｰID
        'その他
        mintDBReadTimer = TO_INTEGER(objConfig.GET_INFO(GKEY_MCI_DB_READ_TIMER))                    '送信ﾊﾞｯﾌｧﾃｰﾌﾞﾙを検索する周期
        mstrFEQ_ID = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FEQ_ID))                                 'MCI区別
        mstrFMSG_ID_ERR_SYS = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FMSG_ID_ERR_SYS))               'ｼｽﾃﾑｴﾗｰ  時のﾒｯｾｰｼﾞID
        mstrFMSG_ID_ERR_USER = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FMSG_ID_ERR_USER))             'ﾕｰｻﾞｰｴﾗｰ 時のﾒｯｾｰｼﾞID
        mintResetSleep = TO_STRING(objConfig.GET_INFO(GKEY_MCI_SEND_SLEEP))                         '通信ﾘｾｯﾄ時のｽﾘｰﾌﾟ時間(ms)  連続してﾘｾｯﾄを行わない為


        '**********************************************************************************************************************
        '↓↓↓↓固有部分


        '*****************************************************
        'ﾃﾞﾘﾐﾀ設定
        '*****************************************************
        mobjGetTelegram.strSTX = mobjASCII.strSTX
        mobjGetTelegram.strETX = mobjASCII.strETX & mobjASCII.strCR


        '*****************************************************
        'Configﾌｧｲﾙ情報取得(固有部分)
        '*****************************************************
        'AGCへのｿｹｯﾄ用
        mstrAGCSockSendAddress = TO_STRING(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_ADDRESS))                  'AGC送信先ｱﾄﾞﾚｽ
        mintAGCSockSendPort = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_PORT))                       'AGC送信先ﾎﾟｰﾄNo
        mintAGCSockSendTimeOut = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_TIME_OUT))                'AGC応答ｿｹｯﾄ待機時間
        'EQ電文受信用
        mintEQTelegramInforStartPosition = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_TELEGRAM_INFOR_START_POSITION))        '「長さ情報」が入っている位置
        mintEQTelegramInforLength = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_TELEGRAM_INFOR_LENGTH))                       '「長さ情報」の桁数
        mintEQTelegramHeaderLength = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_TELEGRAM_HEADER_LENGTH))                     'ﾍｯﾀﾞｰ部分の桁数


        '****************************************************
        'ﾀﾞｲﾌｸｿｹｯﾄ通信ｸﾗｽ初期化
        '****************************************************
        mobjSock = New clsSocketListener(mobjOwner)
        mobjSock.intPortNo = mintAGCSockSendPort
        mobjSock.intDebugFlag = mintDebugFlag


        '*****************************************************
        'ﾃﾞﾘﾐﾀ設定
        '*****************************************************
        mobjGetTelegram.strSTX = mobjASCII.strSTX
        mobjGetTelegram.strETX = mobjASCII.strETX & mobjASCII.strCR


        '↑↑↑↑固有部分
        '**********************************************************************************************************************


        '****************************************************
        '通信ｵｰﾌﾟﾝ
        '****************************************************
        Call Open()


        '*****************************************************
        ' ｿｹｯﾄ接続待機の為のﾀﾞﾐｰﾙｰﾌﾟ
        '*****************************************************
        Dim dtmTemp As Date = Now
        While True
            If dtmTemp.AddSeconds(1) < Now Then
                Exit While
            End If
        End While


    End Sub
#End Region

#Region "  ﾛｸﾞ書き込み処理                  "
    '''*******************************************************************************************************************
    ''' <summary>
    '''  ﾛｸﾞ書き込み処理
    ''' </summary>
    ''' <param name="strMsg_1"></param>
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
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddToDebugLog(ByVal strMsg_1 As String)

        If intDebugFlag = 1 Then
            mobjOwner.AddToLog(strMsg_1)
        End If

    End Sub
#End Region
#Region "  ｴﾗｰ処理                          "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="objException"></param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub ComError(ByVal objException As Exception)
        Try


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


        Catch ex2 As Exception
            'NOP
        End Try
    End Sub
#End Region
#Region "  ｼｽﾃﾑ変数取得                     "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｼｽﾃﾑ変数取得
    ''' </summary>
    ''' <param name="strITEM_ID">変数ID</param>
    ''' <returns>ｼｽﾃﾑ変数取得値</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function GetSYS_HEN(ByVal strITEM_ID As String) As Object

        Dim objReturn As Object         '関数戻値
        Dim udtRet As RetCode           '戻値
        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(mobjOwner, mobjDb, mobjDbLog)
        objTPRG_SYS_HEN.FHENSU_ID = strITEM_ID              '変数ID
        udtRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN_OBJ()     '情報取得
        If udtRet <> RetCode.OK Then
            Throw New Exception("ｼｽﾃﾑ変数取得ｴﾗｰ")
        End If
        objReturn = objTPRG_SYS_HEN.OBJGET_DATA


        Return (objReturn)
    End Function
#End Region
#Region "  ｼｽﾃﾑ変数変更                     "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｼｽﾃﾑ変数変更
    ''' </summary>
    ''' <param name="strITEM_ID">変数ID</param>
    ''' <param name="objSetData">変更ﾃﾞｰﾀ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub SetSYS_HEN(ByVal strITEM_ID As String, _
                          ByVal objSetData As Object _
                          )

        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(mobjOwner, mobjDb, mobjDbLog)
        objTPRG_SYS_HEN.FHENSU_ID = strITEM_ID              '変数ID
        objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(False)             '情報取得
        objTPRG_SYS_HEN.OBJCHANGE_DATA = objSetData         '変更ﾃﾞｰﾀ
        objTPRG_SYS_HEN.UPDATE_TPRG_SYS_HEN_OBJ()           '変更処理


    End Sub
#End Region
    '↑↑↑↑↑↑毎回必要
    '***********************************************


    '***********************************************
    '↓↓↓↓↓↓送信処理
    '↑↑↑↑↑↑送信処理
    '***********************************************
    '↓↓↓↓↓↓受信処理
    '↑↑↑↑↑↑受信処理
    '***********************************************
    '↓↓↓↓↓↓接続確認処理


    '↑↑↑↑↑↑接続確認処理
    '***********************************************

#Region "  通信ｵｰﾌﾟﾝ            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 通信ｵｰﾌﾟﾝ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Open()
        mobjSock.intPortNo = mintAGCSockSendPort         'ﾎﾟｰﾄNo
        mobjSock.Listen()                                '待機
    End Sub
#End Region
#Region "  通信ｸﾛｰｽﾞ            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 通信ｸﾛｰｽﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Close()
        mobjSock.Shutdown()
    End Sub
#End Region
#Region "  ﾃﾞｰﾀ送信             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ送信
    ''' </summary>
    ''' <param name="strSendText">送信ﾃｷｽﾄ</param>
    ''' <returns>正常終了の有無</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SendDataVAGC(ByVal strSendText As String) As RetCode

        'ｿｹｯﾄ送信
        mobjSock.strSendText = strSendText
        mobjSock.Send()

        'ﾛｸﾞ出力
        Call AddToLog(MCIA_MSG_021 & strSendText)   'ﾛｸﾞ出力
        mdtmBeforeETXSendTime = Now

    End Function
#End Region
#Region "  ﾃﾞｰﾀ受信             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ受信
    ''' </summary>
    ''' <param name="strRecvText">受信ﾃｷｽﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub RecvDataVAGC(ByRef strRecvText As String)


        '****************************************
        'ｿｹｯﾄ受信
        '****************************************
        mobjSock.Receive()



        '****************************************
        'ｿｹｯﾄ受信ﾊﾞｯﾌｧに結合
        '****************************************
        mstrRecvTelBuff &= mobjSock.strRecvText


        '****************************************
        '電文部分を抽出 & ｿｹｯﾄ受信ﾊﾞｯﾌｧ更新
        '****************************************
        If IsNotNull(mobjSock.strRecvText) Then
            '(電文を受信した場合)

            strRecvText = mobjGetTelegram.GetTelegramDataLength01(mstrRecvTelBuff _
                                                                , mintEQTelegramInforStartPosition _
                                                                , mintEQTelegramInforLength _
                                                                )

            If IsNotNull(strRecvText) Then
                Call AddToLog(MCIA_MSG_011 & strRecvText) '電文取得ﾛｸﾞ出力
            End If

        End If


    End Sub
#End Region



    '*******************
    'Public
    '*******************



    '*******************
    'Private
    '*******************
#Region "  MCIA_100002  電文受信                処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 電文受信処理
    ''' </summary>
    ''' <param name="strRecvText">正常に受信できたﾃﾞｰﾀ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_900002(ByVal strRecvText As String)
        'Try


        '    '*****************************************************
        '    '受信電文有無ﾁｪｯｸ
        '    '*****************************************************
        '    If strRecvText = "" Then Exit Sub
        '    mdtmBeforeETXRecvTime = Now


        '    '*****************************************************
        '    '受信電文分解
        '    '*****************************************************
        '    Dim objTel As New clsTelegram(CONFIG_TELEGRAM_BZ)
        '    objTel.FORMAT_ID = FORMAT_BZ_HOSTNZ                 'ﾌｫｰﾏｯﾄ名ｾｯﾄ    (特に何でも良い)
        '    objTel.TELEGRAM_PARTITION = strRecvText             '分割する電文ｾｯﾄ
        '    objTel.PARTITION()                                  '電文分割


        '    If gobjMCIToServer.chkResponseAuto.Checked = True Then
        '        '(自動応答の場合)


        '        'Select Case FORMAT_BZ & Trim(objTel.SELECT_HEADER("BZMACHINE_NO")) & Trim(objTel.SELECT_HEADER("BZDATA_KIND_CD"))
        '        '    Case FORMAT_BZ_PR10NYU : Call SendResponseBZ_etc(strRecvText)       '入庫実績
        '        '        'Case FORMAT_BZ_PR10SK0 : Call SendResponseBZ_etc(strRecvText)       '出庫計画受領応答
        '        '    Case FORMAT_BZ_PR10SYU : Call SendResponseBZ_etc(strRecvText)       '出庫実績
        '        '    Case FORMAT_BZ_PR10ZT : Call SendResponseBZ_PR10ZT(strRecvText)     '在庫問合せ
        '        'End Select


        '    End If


        'Catch ex As Exception
        '    ComError(ex)

        'End Try
    End Sub
#End Region



End Class
