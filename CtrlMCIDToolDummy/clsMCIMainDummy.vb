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


    '==================================================
    '共通ｵﾌﾞｼﾞｪｸﾄ
    '==================================================
    Private mobjSerial As clsSerial                     'ｼﾘｱﾙ通信ｵﾌﾞｼﾞｪｸﾄ
    Private mobjEQSendTelBuff As TBL_TLIF_TRNS_SEND     '電文送信ﾊﾞｯﾌｧ
    'Private mobjEQSendResBuff As TBL_TLIF_TRNS_SEND    '応答電文送信ﾊﾞｯﾌｧ
    Private mobjGetTelegram As clsGetTelegram           '電文用ﾃｷｽﾄ取得ｸﾗｽ
    Private mobjMCIMain As CtrlMCID.clsMCIMain          '本当の通信ﾌﾟﾛｸﾞﾗﾑｸﾗｽ

    '==================================================
    '内部変数
    '==================================================
    '受信用COM設定
    Private mstrCOMRecvPort As String               'ﾎﾟｰﾄ番号
    Private mintCOMRecvBaud As Integer              '通信速度
    Private mstrCOMRecvParity As String             'ﾊﾟﾘﾃｨ
    Private mintCOMRecvDataLength As Integer        'ﾃﾞｰﾀ長
    Private mstrCOMRecvStopBit As String            'ｽﾄｯﾌﾟﾋﾞｯﾄ長
    Private mstrCOMRecvArrayHeader As String        '受信ﾍｯﾀﾞｰ
    Private mstrCOMRecvArrayTerminator As String    '受信ﾀｰﾐﾈｰﾀ
    Private mintCOMCodePage As Integer              '通信に使用するﾃｷｽﾄのｺｰﾄﾞ  (932:ShiftJIS)
    Private mstrCOMComName As String                '通信名

    'その他
    Private mintSendCount As Integer            '再送信回数
    Private mdtmBeforeRecvTime As Date          '前回受信日時
    Private mdtmBeforeSendTime As Date          '前回送信日時
    Private mstrRecvTelBuff As String           '受信ﾊﾞｯﾌｧ
    Private mintResponsWait As Integer          '応答待ちﾌﾗｸﾞ
    Private mdtmBeforeConnTime As Date          '前回接続日時
    'Private mblnConnect As Boolean              'ｿｹｯﾄ接続ﾌﾗｸﾞ
    Private mintSockRecvMode As Integer         'ｿｹｯﾄ受信ﾓｰﾄﾞ


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
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
    Private mintEQ_SendTimer As Integer             '定周期問い合わせ周期(ms)
    '↑↑↑↑↑↑************************************************************************************************************
    Private mintSendSleep As Integer                '通信ﾘｾｯﾄ時のｽﾘｰﾌﾟ時間(ms)  連続してﾘｾｯﾄを行わない為
    Private mintSendTimeout As Integer              '送信ﾀｲﾑｱｳﾄ(ms)
    Private mintSendRetry As Integer                '送信ﾘﾄﾗｲ回数
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
            mobjSerial.intDebugFlag = Value
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
                Call RecvDataEQ(strRecvText)


                '*****************************************************
                'ALC電文受信処理
                '*****************************************************
                Call MCIA_900002(strRecvText)


            Catch ex As Exception
                Call ComError(ex)

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
            mobjMCIMain = New CtrlMCID.clsMCIMain(objOwner, objDb, objDbLog)    '本当の通信ﾌﾟﾛｸﾞﾗﾑｸﾗｽ

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
        mobjASCII = New clsASCII()              'ASCIIｺｰﾄﾞ文字ｸﾗｽ
        mobjEQSendTelBuff = New TBL_TLIF_TRNS_SEND(mobjOwner, Nothing, Nothing)    '電文送信ﾊﾞｯﾌｧ
        'mobjEQSendResBuff = New TBL_TLIF_TRNS_SEND(mobjOwner, Nothing, Nothing)    '応答電文送信ﾊﾞｯﾌｧ
        mdtmBeforeConnTime = Now                        '前回接続日時
        mobjGetTelegram = New clsGetTelegram(mobjOwner) '電文用ﾃｷｽﾄ取得ｸﾗｽ


        '*****************************************************
        'Configﾌｧｲﾙ情報取得(標準部分)
        '*****************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MCID_DUMMY)                                    'Configﾌｧｲﾙ接続ｸﾗｽ生成

        'ｻｰﾊﾞｰｿｹｯﾄ用
        mstrSvrSockSendAddress = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_ADDRESS))              'ｻｰﾊﾞ送信先ｱﾄﾞﾚｽ
        mintSvrSockSendPort = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_PORT))                    'ｻｰﾊﾞ送信先ﾎﾟｰﾄNo
        mintSvrSockSendTimeOut = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_TIME_OUT))             'ｻｰﾊﾞ応答ｿｹｯﾄ待機時間
        mstrSvrSockSendTermID = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_TERM_ID))               'ｻｰﾊﾞ端末ID
        mstrSvrSockSendUserID = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_USER_ID))               'ｻｰﾊﾞﾕｰｻﾞｰID
        mstrSvrSockSendFlag = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_FLAG))                    'ｻｰﾊﾞｿｹｯﾄ送信ﾌﾗｸﾞ
        'その他
        mintDBReadTimer = TO_INTEGER(objConfig.GET_INFO(GKEY_MCI_DB_READ_TIMER))                    '送信ﾊﾞｯﾌｧﾃｰﾌﾞﾙを検索する周期
        mstrFEQ_ID = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FEQ_ID))                                 'MCI区別
        mstrFMSG_ID_ERR_SYS = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FMSG_ID_ERR_SYS))               'ｼｽﾃﾑｴﾗｰ  時のﾒｯｾｰｼﾞID
        mstrFMSG_ID_ERR_USER = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FMSG_ID_ERR_USER))             'ﾕｰｻﾞｰｴﾗｰ 時のﾒｯｾｰｼﾞID
        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
        mintEQ_SendTimer = TO_INTEGER(objConfig.GET_INFO(GKEY_MCI_EQ_SEND_TIMER))                   '定周期問い合わせ周期(ms)
        '↑↑↑↑↑↑************************************************************************************************************
        mintSendSleep = TO_STRING(objConfig.GET_INFO(GKEY_MCI_SEND_SLEEP))                          '通信ﾘｾｯﾄ時のｽﾘｰﾌﾟ時間(ms)  連続してﾘｾｯﾄを行わない為
        mintSendTimeout = TO_STRING(objConfig.GET_INFO(GKEY_MCI_SEND_TIMEOUT))                      '送信ﾀｲﾑｱｳﾄ(ms)
        mintSendRetry = TO_STRING(objConfig.GET_INFO(GKEY_MCI_SEND_RETRY))                          '送信ﾘﾄﾗｲ回数


        '*****************************************************
        'ｻｰﾊﾞｰｿｹｯﾄ送信ｵﾌﾞｼﾞｪｸﾄ  生成
        '*****************************************************
        mobjSockSvr = New clsSocketToServer(mobjOwner)
        mobjSockSvr.objOwner = mobjOwner                        'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
        mobjSockSvr.strTermID = mstrSvrSockSendTermID           'ｻｰﾊﾞ端末ID
        mobjSockSvr.strEmpCD = mstrSvrSockSendUserID            'ｻｰﾊﾞﾕｰｻﾞｰID
        mobjSockSvr.strAddress = mstrSvrSockSendAddress         'ｻｰﾊﾞ送信先ｱﾄﾞﾚｽ
        mobjSockSvr.intPortNo = mintSvrSockSendPort             'ｻｰﾊﾞ送信先ﾎﾟｰﾄNo
        mobjSockSvr.intTimeout = mintSvrSockSendTimeOut         'ｻｰﾊﾞ応答ｿｹｯﾄ待機時間
        mobjSockSvr.strTelFilePath = CONFIG_TELEGRAM_DSP        '読み込む定義ﾌｧｲﾙのﾊﾟｽ


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
        '受信用COM設定
        mstrCOMRecvPort = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_PORT))                    'ﾎﾟｰﾄ番号
        mintCOMRecvBaud = TO_NUMBER(objConfig.GET_INFO(GKEY_EQ_COM_RECV_BAUD))                    '通信速度
        mstrCOMRecvParity = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_PARITY))                'ﾊﾟﾘﾃｨ
        mintCOMRecvDataLength = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_DATALENGTH))        'ﾃﾞｰﾀ長
        mstrCOMRecvStopBit = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_STOPBIT))              'ｽﾄｯﾌﾟﾋﾞｯﾄ長
        mintCOMCodePage = TO_NUMBER(objConfig.GET_INFO(GKEY_EQ_COM_CODEPAGE))                     '通信に使用するﾃｷｽﾄのｺｰﾄﾞ  (932:ShiftJIS)
        mstrCOMComName = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_COMNAME))                       '通信名


        '****************************************************
        'ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ   ｾｯﾄ
        '****************************************************
        mobjSerial = New clsSerial(mobjOwner)                        'ｼﾘｱﾙ通信ｵﾌﾞｼﾞｪｸﾄ
        mobjSerial.strRecvPort = mstrCOMRecvPort                     'ﾎﾟｰﾄ番号
        mobjSerial.intRecvBaud = mintCOMRecvBaud                     '通信速度
        mobjSerial.strRecvParity = mstrCOMRecvParity                 'ﾊﾟﾘﾃｨ
        mobjSerial.intRecvDataLength = mintCOMRecvDataLength         'ﾃﾞｰﾀ長
        mobjSerial.strRecvStopBit = mstrCOMRecvStopBit               'ｽﾄｯﾌﾟﾋﾞｯﾄ長
        mobjSerial.intCodePage = mintCOMCodePage                     '通信に使用するﾃｷｽﾄのｺｰﾄﾞ  (932:ShiftJIS)
        mobjSerial.strComName = mstrCOMComName                       '通信名
        mobjSerial.Open()                                            '通信確立


        '↑↑↑↑固有部分
        '**********************************************************************************************************************


        ''****************************************************
        ''通信ｵｰﾌﾟﾝ
        ''****************************************************
        'Call Open()


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

#Region "  通信ｵｰﾌﾟﾝ                        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 通信ｵｰﾌﾟﾝ
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Open()


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
#Region "  通信ｸﾛｰｽﾞ                        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 通信ｸﾛｰｽﾞ
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Close()
        Try


            '****************************************************
            'ｼﾘｱﾙ通信ｵﾌﾞｼﾞｪｸﾄ       ｸﾛｰｽﾞ
            '****************************************************
            mobjSerial.Close()                                          '通信確立


        Catch ex As Exception
            'NOP(失敗しても特に問題なし)
        End Try
    End Sub
#End Region

#Region "  ﾃﾞｰﾀ送信                         "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ送信(ｿｹｯﾄﾘｽﾅｰ)
    ''' </summary>
    ''' <param name="strSendText">送信ﾃｷｽﾄ</param>
    ''' <returns>正常終了の有無</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function SendDataEQ(ByVal strSendText As String) As RetCode
        Try
            Dim intRet As RetCode = RetCode.OK


            '*****************************************************
            '連続して送信出来ない為Sleep
            '*****************************************************
            If 0 < mintSendSleep Then
                '(ｽﾘｰﾌﾟ時間がｾｯﾄされている場合)

                Dim objDiff As TimeSpan = mdtmBeforeSendTime.AddMilliseconds(mintSendSleep) - Now
                If 0 < objDiff.TotalMilliseconds Then
                    Call Threading.Thread.Sleep(objDiff.TotalMilliseconds)
                End If

            End If


            '*****************************************************
            'ﾃｷｽﾄﾃﾞｰﾀ送信
            '*****************************************************
            Dim blnSendSuccess As Boolean = False       '電文送信成功ﾌﾗｸﾞ
            For II As Integer = 1 To mintSendRetry
                '(ﾙｰﾌﾟ:ﾘﾄﾗｲ回数)

                mobjSerial.strSendText = strSendText
                'mobjSerial.strSendText = mobjGetTelegram.MakeTelegramSTXETX(strSendText)

                Try
                    mobjSerial.Send()
                    blnSendSuccess = True
                    Exit For
                Catch ex As Exception
                End Try
            Next
            If blnSendSuccess = True Then
                '(成功した場合)
            Else
                '(失敗した場合)
                Call AddToLog(MCIA_MSG_022 & strSendText)
                intRet = RetCode.NG
                Return intRet
            End If


            '*****************************************************
            'ﾛｸﾞ出力
            '*****************************************************
            '===========================================
            'ﾃｷｽﾄﾛｸﾞ追加
            '===========================================
            Call AddToLog(MCIA_MSG_021 & strSendText)


            Return intRet
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
#Region "  ﾃﾞｰﾀ受信                         "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ受信
    ''' </summary>
    ''' <param name="strRecvText">受信ﾃｷｽﾄ</param>
    ''' <remarks>正常終了の有無</remarks>
    '''*******************************************************************************************************************
    Public Sub RecvDataEQ(ByRef strRecvText As String)


        '****************************************
        'ｿｹｯﾄ受信
        '****************************************
        mobjSerial.Receive()


        '****************************************
        '電文部分を抽出 & ｿｹｯﾄ受信ﾊﾞｯﾌｧ更新
        '****************************************
        If IsNotNull(mobjSerial.strRecvText) Then
            '(電文を受信した場合)


            '****************************************
            'ｿｹｯﾄ受信ﾊﾞｯﾌｧに結合
            '****************************************
            If IsNull(mstrRecvTelBuff) Then
                mstrRecvTelBuff = mobjSerial.strRecvText
            Else
                mstrRecvTelBuff &= mobjSerial.strRecvText
            End If


            '****************************************
            '電文部分を抽出 & ｿｹｯﾄ受信ﾊﾞｯﾌｧ更新
            '****************************************
            strRecvText = mobjGetTelegram.GetTelegramSTXETX(mstrRecvTelBuff)
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
        Try




        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region

End Class
