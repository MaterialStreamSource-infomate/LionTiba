'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】MCIﾒｲﾝｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports  "
Imports JobCommon
Imports MateCommon.clsConst
Imports MateCommon
Imports UserProcess
#End Region

Public Class clsMCIMain

#Region "  共通変数02           "

    '==================================================
    '共通ｵﾌﾞｼﾞｪｸﾄ
    '==================================================
    Friend mobjSerial As clsMcvSerial                   'MCV通信ｵﾌﾞｼﾞｪｸﾄ
    Private mobjEQSendTelBuff As TBL_TLIF_TRNS_SEND     '電文送信ﾊﾞｯﾌｧ
    Private mobjEQSendResBuff As TBL_TLIF_TRNS_SEND     '応答電文送信ﾊﾞｯﾌｧ
    Private mobjGetTelegram As clsGetTelegram           '電文用ﾃｷｽﾄ取得ｸﾗｽ

    '==================================================
    '内部変数
    '==================================================
    'EQｼﾘｱﾙ通信用(送信用)
    Private mstrCOMSendPort As String               'ﾎﾟｰﾄ番号
    Private mintCOMSendBaud As Integer              '通信速度
    Private mstrCOMSendParity As String             'ﾊﾟﾘﾃｨ
    Private mintCOMSendDataLength As Integer        'ﾃﾞｰﾀ長
    Private mstrCOMSendStopBit As String            'ｽﾄｯﾌﾟﾋﾞｯﾄ長
    Private mstrCOMSendArrayHeader As String        '受信ﾍｯﾀﾞｰ
    Private mstrCOMSendArrayTerminator As String    '受信ﾀｰﾐﾈｰﾀ
    'EQｼﾘｱﾙ通信用(受信用)
    Private mstrCOMRecvPort As String               'ﾎﾟｰﾄ番号
    Private mintCOMRecvBaud As Integer              '通信速度
    Private mstrCOMRecvParity As String             'ﾊﾟﾘﾃｨ
    Private mintCOMRecvDataLength As Integer        'ﾃﾞｰﾀ長
    Private mstrCOMRecvStopBit As String            'ｽﾄｯﾌﾟﾋﾞｯﾄ長
    Private mstrCOMRecvArrayHeader As String        '受信ﾍｯﾀﾞｰ
    Private mstrCOMRecvArrayTerminator As String    '受信ﾀｰﾐﾈｰﾀ
    'EQｼﾘｱﾙ通信用(その他)
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




    '↓↓↓MCV用

    '複数MCVの時に対応
    Private mFHENSU_IDAbnormal As String     '異常ﾌﾗｸﾞ
    Private mFHENSU_IDSeqNoSend As String    '送信ｼｰｹﾝｽ№
    Private mFHENSU_IDSeqNoRecv As String    '受信ｼｰｹﾝｽ№
    Private mstrTelConfigPath As String      'Configﾌｧｲﾙﾊﾟｽ
    Private mstrONLINE_ID As String          'ﾃﾞｰﾀﾘﾝｸ確立ID
    Private mstrOFLINE_ID As String          'ﾃﾞｰﾀﾘﾝｸ切断ID

    'その他
    Friend mblnCutFlag As Boolean            'ﾃﾞｰﾀﾘﾝｸ切断ﾌﾗｸﾞ


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
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
    Private mdtmEQ_SendTimer_Before As Date         '前回定周期問い合わせ時間
    Private mstrEQ_SendTimerTel_Before As String    '前回定周期問い合わせ電文
    '↑↑↑↑↑↑************************************************************************************************************

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
            mobjSerial.intDebugFlag = Value                 'ｼﾘｱﾙ通信ｸﾗｽ
            mobjGetTelegram.intDebugFlag = mintDebugFlag    '電文用ﾃｷｽﾄ取得ｸﾗｽ
        End Set
    End Property
#End Region

#Region "  ﾒｲﾝ処理              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
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
                'ｼﾘｱﾙ通信ﾃﾞｰﾀ           受信
                '*****************************************************
                Dim strReceiveData As String = ""       '正常に受信できたﾃﾞｰﾀ
                Dim strResponsCode As String = ""       '応答ｺｰﾄﾞ
                mobjSerial.ReceiveText(strReceiveData, _
                                       strResponsCode, _
                                       clsMcvSerial.SerialKind.Recv)
                If strReceiveData <> "" Then AddToLog(MCIA_MSG_011 & strReceiveData) '電文取得ﾛｸﾞ出力


                '*****************************************************
                'ｼﾘｱﾙ通信応答           処理
                '*****************************************************
                Call MCIA_100201(strReceiveData, strResponsCode)         'ﾘｱﾙ通信応答処理


                '*****************************************************
                'DB送信ﾊﾞｯﾌｧ検索 & 電文送信     処理
                '*****************************************************
                Call MCIA_100001(True)


                '*****************************************************
                'ｼﾘｱﾙ通信応答電文       確認
                '*****************************************************
                Dim strResponsData As String = ""       '正常に受信できたﾃﾞｰﾀ
                Dim strResponsCode2 As String = ""      '応答ｺｰﾄﾞ
                mobjSerial.ReceiveText(strResponsData, _
                                       strResponsCode2, _
                                       clsMcvSerial.SerialKind.Send)
                If strResponsData <> "" Then Call AddToLog(MCIA_MSG_RES011 & strResponsData) '電文取得ﾛｸﾞ出力


                '*****************************************************
                'ｼﾘｱﾙ通信応答受信       処理
                '*****************************************************
                Call MCIA_100202(strResponsData, strResponsCode2)                    'ｼﾘｱﾙ通信応答受信処理


                '*****************************************************
                'ｻｰﾊﾞへｿｹｯﾄ送信
                '*****************************************************
                Call MCI_000001()


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
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ(主にﾛｸﾞ書込みに使用)</param>
    ''' <param name="objDb">ｵﾗｸﾙ接続ｸﾗｽ(通常用)</param>
    ''' <param name="objDbLog">ｵﾗｸﾙ接続ｸﾗｽ(ﾛｸﾞ用)</param>
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
            mstrRecvTelBuff = ""                                '受信ﾊﾞｯﾌｧ
            mdtmNow = Now


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
    ''' 初期化処理
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
        mobjEQSendResBuff = New TBL_TLIF_TRNS_SEND(mobjOwner, Nothing, Nothing)    '応答電文送信ﾊﾞｯﾌｧ
        mdtmBeforeConnTime = Now                        '前回接続日時
        mobjGetTelegram = New clsGetTelegram(mobjOwner) '電文用ﾃｷｽﾄ取得ｸﾗｽ


        '*****************************************************
        'Configﾌｧｲﾙ情報取得(標準部分)
        '*****************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MCIC)                              'Configﾌｧｲﾙ接続ｸﾗｽ生成

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
        'EQｼﾘｱﾙ通信用(送信用)
        mstrCOMSendPort = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_SEND_PORT))                    'ﾎﾟｰﾄ番号
        mintCOMSendBaud = TO_NUMBER(objConfig.GET_INFO(GKEY_EQ_COM_SEND_BAUD))                    '通信速度
        mstrCOMSendParity = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_SEND_PARITY))                'ﾊﾟﾘﾃｨ
        mintCOMSendDataLength = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_SEND_DATALENGTH))        'ﾃﾞｰﾀ長
        mstrCOMSendStopBit = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_SEND_STOPBIT))              'ｽﾄｯﾌﾟﾋﾞｯﾄ長
        'EQｼﾘｱﾙ通信用(受信用)
        mstrCOMRecvPort = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_PORT))                    'ﾎﾟｰﾄ番号
        mintCOMRecvBaud = TO_NUMBER(objConfig.GET_INFO(GKEY_EQ_COM_RECV_BAUD))                    '通信速度
        mstrCOMRecvParity = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_PARITY))                'ﾊﾟﾘﾃｨ
        mintCOMRecvDataLength = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_DATALENGTH))        'ﾃﾞｰﾀ長
        mstrCOMRecvStopBit = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_STOPBIT))              'ｽﾄｯﾌﾟﾋﾞｯﾄ長
        'EQｼﾘｱﾙ通信用(その他)
        mintCOMCodePage = TO_NUMBER(objConfig.GET_INFO(GKEY_EQ_COM_CODEPAGE))                     '通信に使用するﾃｷｽﾄのｺｰﾄﾞ  (932:ShiftJIS)
        mstrCOMComName = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_COMNAME))                       '通信名


        '****************************************************
        'ｼﾘｱﾙ通信ｵﾌﾞｼﾞｪｸﾄ       ｾｯﾄ
        '****************************************************
        mobjSerial = New clsMcvSerial(mobjOwner)                     'ｼﾘｱﾙ通信ｵﾌﾞｼﾞｪｸﾄ
        'EQｼﾘｱﾙ通信用(送信用)
        mobjSerial.strSendPort = mstrCOMSendPort                     'ﾎﾟｰﾄ番号
        mobjSerial.intSendBaud = mintCOMSendBaud                     '通信速度
        mobjSerial.strSendParity = mstrCOMSendParity                 'ﾊﾟﾘﾃｨ
        mobjSerial.intSendDataLength = mintCOMSendDataLength         'ﾃﾞｰﾀ長
        mobjSerial.strSendStopBit = mstrCOMSendStopBit               'ｽﾄｯﾌﾟﾋﾞｯﾄ長
        'EQｼﾘｱﾙ通信用(受信用)
        mobjSerial.strRecvPort = mstrCOMRecvPort                     'ﾎﾟｰﾄ番号
        mobjSerial.intRecvBaud = mintCOMRecvBaud                     '通信速度
        mobjSerial.strRecvParity = mstrCOMRecvParity                 'ﾊﾟﾘﾃｨ
        mobjSerial.intRecvDataLength = mintCOMRecvDataLength         'ﾃﾞｰﾀ長
        mobjSerial.strRecvStopBit = mstrCOMRecvStopBit               'ｽﾄｯﾌﾟﾋﾞｯﾄ長
        'EQｼﾘｱﾙ通信用(その他)
        mobjSerial.intCodePage = mintCOMCodePage                     '通信に使用するﾃｷｽﾄのｺｰﾄﾞ  (932:ShiftJIS)
        mobjSerial.intBCCUseFlag = FLAG_OFF                          'BCC使用ﾌﾗｸﾞ       (0:使用しない　　1:使用する)
        mobjSerial.Open()                                            '通信確立


        '*****************************************************
        ' MCV32,33判別
        '*****************************************************
        Select Case mstrFEQ_ID
            Case FEQ_ID_JSYS0003
                mFHENSU_IDAbnormal = FHENSU_ID_JSJ100000_001           '異常ﾌﾗｸﾞ
                mFHENSU_IDSeqNoSend = FHENSU_ID_JSJ100000_002          '送信ｼｰｹﾝｽ№
                mFHENSU_IDSeqNoRecv = FHENSU_ID_JSJ100000_003          '受信ｼｰｹﾝｽ№
                mstrTelConfigPath = CONFIG_TELEGRAM_MCV                'Configのﾊﾟｽ
                mstrONLINE_ID = FCOMMAND_ID_JMCV_000                   'ﾃﾞｰﾀﾘﾝｸ確立ID
                mstrOFLINE_ID = FCOMMAND_ID_JMCV_999                   'ﾃﾞｰﾀﾘﾝｸ切断ID

                'Case FEQ_ID_MCV_C33
                '    mFHENSU_IDAbnormal = FHENSU_ID_MCV33_ABNORMAL           '異常ﾌﾗｸﾞ
                '    mFHENSU_IDSeqNoSend = FHENSU_ID_MCV33_SEQNO_SEND        '送信ｼｰｹﾝｽ№
                '    mFHENSU_IDSeqNoRecv = FHENSU_ID_MCV33_SEQNO_RECV        '受信ｼｰｹﾝｽ№
                '    mstrTelConfigPath = CONFIG_TELEGRAM_MCV33               'Configのﾊﾟｽ
                '    mstrONLINE_ID = FCOMMAND_ID_MCV_000_33                  'ﾃﾞｰﾀﾘﾝｸ確立ID
                '    mstrOFLINE_ID = FCOMMAND_ID_MCV_999_33                  'ﾃﾞｰﾀﾘﾝｸ切断ID

        End Select


        '↑↑↑↑固有部分
        '**********************************************************************************************************************


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
    ''' <param name="objException">ｴﾗｰException</param>
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


            '*****************************************************
            '通信ｴﾗｰ追加
            '*****************************************************
            Call ErrorAdd(mstrFMSG_ID_ERR_SYS, ERR_MSG_01, objException.Message)


        Catch ex2 As Exception
            'NOP
        End Try
    End Sub
#End Region
#Region "  ﾒｯｾｰｼﾞﾛｸﾞ追加                    "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾒｯｾｰｼﾞﾛｸﾞ追加
    ''' </summary>
    ''' <param name="strFMSG_ID">ﾒｯｾｰｼﾞID</param>
    ''' <param name="strFMSG_PRM1">ﾊﾟﾗﾒｰﾀ1</param>
    ''' <param name="strFMSG_PRM2">ﾊﾟﾗﾒｰﾀ2</param>
    ''' <param name="strFMSG_PRM3">ﾊﾟﾗﾒｰﾀ3</param>
    ''' <param name="strFMSG_PRM4">ﾊﾟﾗﾒｰﾀ4</param>
    ''' <param name="strFMSG_PRM5">ﾊﾟﾗﾒｰﾀ5</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub ErrorAdd(ByVal strFMSG_ID As String _
                       , ByVal strFMSG_PRM1 As String _
                       , Optional ByVal strFMSG_PRM2 As String = Nothing _
                       , Optional ByVal strFMSG_PRM3 As String = Nothing _
                       , Optional ByVal strFMSG_PRM4 As String = Nothing _
                       , Optional ByVal strFMSG_PRM5 As String = Nothing _
                         )
        Try


            '***********************************
            'ﾃｷｽﾄ変換
            '***********************************
            strFMSG_PRM1 = SQL_ITEM(strFMSG_PRM1, 254)       'ﾊﾟﾗﾒｰﾀ1
            strFMSG_PRM2 = SQL_ITEM(strFMSG_PRM2, 254)       'ﾊﾟﾗﾒｰﾀ2
            strFMSG_PRM3 = SQL_ITEM(strFMSG_PRM3, 254)       'ﾊﾟﾗﾒｰﾀ3
            strFMSG_PRM4 = SQL_ITEM(strFMSG_PRM4, 254)       'ﾊﾟﾗﾒｰﾀ4
            strFMSG_PRM5 = SQL_ITEM(strFMSG_PRM4, 254)       'ﾊﾟﾗﾒｰﾀ5


            '***********************************
            'ﾛｸﾞ出力
            '***********************************
            Dim strMsg As String
            strMsg = ""
            strMsg &= strFMSG_PRM1
            If IsNull(strFMSG_PRM2) = False Then strMsg &= Space(10) & strFMSG_PRM2
            If IsNull(strFMSG_PRM3) = False Then strMsg &= Space(10) & strFMSG_PRM3
            If IsNull(strFMSG_PRM4) = False Then strMsg &= Space(10) & strFMSG_PRM4
            If IsNull(strFMSG_PRM5) = False Then strMsg &= Space(10) & strFMSG_PRM5
            Call AddToLog(strMsg)


            '***********************************
            '搬送制御受信IF 追加
            '***********************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)
            objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                           '設備ID
            objTLIF_TRNS_RECV.FCOMMAND_ID = FCOMMAND_ID_SADD_MSG             'ｺﾏﾝﾄﾞID
            objTLIF_TRNS_RECV.FDENBUN_PRM1 = strFMSG_ID                     'ﾒｯｾｰｼﾞID
            objTLIF_TRNS_RECV.FDENBUN_PRM2 = strFMSG_PRM1                   'ﾊﾟﾗﾒｰﾀ1
            objTLIF_TRNS_RECV.FDENBUN_PRM3 = strFMSG_PRM2                   'ﾊﾟﾗﾒｰﾀ2
            objTLIF_TRNS_RECV.FDENBUN_PRM4 = strFMSG_PRM3                   'ﾊﾟﾗﾒｰﾀ3
            objTLIF_TRNS_RECV.FDENBUN_PRM5 = strFMSG_PRM4                   'ﾊﾟﾗﾒｰﾀ4
            objTLIF_TRNS_RECV.FDENBUN_PRM6 = strFMSG_PRM5                   'ﾊﾟﾗﾒｰﾀ5
            objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SEND                     '進捗状態
            '' ''      objTLIF_TRNS_RECV.FRES_CD_EQ = FORMAT_PLC_RES_CD_OK             '設備応答ｺｰﾄﾞ
            objTLIF_TRNS_RECV.FENTRY_DT = Now                               '登録日時
            objTLIF_TRNS_RECV.FUPDATE_DT = Now                              '更新日時
            objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()                      '追加
            mblnSockSend = True                                             'ｿｹｯﾄ送信ﾌﾗｸﾞ


        Catch ex As Exception
            'NOP
        End Try
    End Sub
#End Region
#Region "  通信ｽﾄｯﾌﾟ                        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 通信ｽﾄｯﾌﾟ
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub StopCommunication()
        Try


            '***********************************
            'ﾛｸﾞ出力
            '***********************************
            Dim strMsg As String
            strMsg = ""
            strMsg &= "通信ｽﾄｯﾌﾟ。"
            Call AddToLog(strMsg)


            '***********************************
            '搬送制御受信IF 追加
            '***********************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)
            objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                           '設備ID
            objTLIF_TRNS_RECV.FCOMMAND_ID = FCOMMAND_ID_SCUT_EQ              'ｺﾏﾝﾄﾞID
            objTLIF_TRNS_RECV.FDENBUN_PRM1 = mstrFEQ_ID                     'ﾒｯｾｰｼﾞID
            objTLIF_TRNS_RECV.FDENBUN_PRM2 = Nothing                        'ﾊﾟﾗﾒｰﾀ1
            objTLIF_TRNS_RECV.FDENBUN_PRM3 = Nothing                        'ﾊﾟﾗﾒｰﾀ2
            objTLIF_TRNS_RECV.FDENBUN_PRM4 = Nothing                        'ﾊﾟﾗﾒｰﾀ3
            objTLIF_TRNS_RECV.FDENBUN_PRM5 = Nothing                        'ﾊﾟﾗﾒｰﾀ4
            objTLIF_TRNS_RECV.FDENBUN_PRM6 = Nothing                        'ﾊﾟﾗﾒｰﾀ5
            objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SEND                     '進捗状態
            '' ''      objTLIF_TRNS_RECV.FRES_CD_EQ = FORMAT_PLC_RES_CD_OK             '設備応答ｺｰﾄﾞ
            objTLIF_TRNS_RECV.FENTRY_DT = Now                               '登録日時
            objTLIF_TRNS_RECV.FUPDATE_DT = Now                              '更新日時
            objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()                      '追加
            mblnSockSend = True                                             'ｿｹｯﾄ送信ﾌﾗｸﾞ


        Catch ex As Exception
            'NOP
        End Try
    End Sub
#End Region
#Region "  MCI_000001  ｻｰﾊﾞへｿｹｯﾄ送信       "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｻｰﾊﾞへｿｹｯﾄ送信
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCI_000001()
        Try

            '*****************************************************
            'ｻｰﾊﾞへｿｹｯﾄ送信
            '*****************************************************
            If mstrSvrSockSendFlag = FLAG_ON Then
                '(Configのｿｹｯﾄ送信ﾌﾗｸﾞが立っている場合)
                If mblnSockSend = True Then
                    '(ｿｹｯﾄ送信ﾌﾗｸﾞが立っている場合)
                    mobjDb.Commit()                                             'ｺﾐｯﾄ
                    mobjDb.BeginTrans()                                         'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
                    objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S210001   'ﾌｫｰﾏｯﾄ名ｾｯﾄ
                    Call mobjSockSvr.SockSendServer(objTelegram)                'ｿｹｯﾄ送信
                    mblnSockSend = False                                        'ｿｹｯﾄ送信ﾌﾗｸﾞ
                    mblnSockEnd = True                                          'ｿｹｯﾄ送信完了ﾌﾗｸﾞ
                    '' ''Call AddToLog("ｿｹｯﾄ送信**********************************************************************************")
                End If

            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ID:99    SQL実行                 "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ID:99    SQL実行
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">搬送制御送信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <returns>正常終了の有無</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function IDSQLProcess(ByRef objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND) As RetCode
        Try
            Dim intRetSQL As Integer    'SQL実行戻り値


            '***********************
            'SQL実行
            '***********************
            Try
                intRetSQL = mobjDb.Execute(objTLIF_TRNS_SEND.FDENBUN_PRM6)
            Catch ex As Exception
                intRetSQL = -1
            End Try
            If intRetSQL <> -1 Then
                '(SQL実行正常)

                '*******************************************
                '搬送送信IF更新
                '*******************************************
                objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SEND                     '進捗状態
                objTLIF_TRNS_SEND.FUPDATE_DT = Now                              '更新日時
                objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()                       '更新

            Else
                '(SQL実行ｴﾗｰ)

                '*******************************************
                '搬送送信IF更新
                '*******************************************
                objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SERR_MCI                 '進捗状態
                objTLIF_TRNS_SEND.FUPDATE_DT = Now                              '更新日時
                objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()                       '更新

            End If


            '*******************************************
            'ﾛｸﾞ出力
            '*******************************************
            Call AddToLog(MCI_MESSAGE_01 & objTLIF_TRNS_SEND.FDENBUN_PRM6)


            Return RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region

#Region "  続けてDB検索処理                 "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 続けてDB検索処理
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub InitializeDBReadTimer()
        Dim dtmTemp As Date
        mdtmBeforeDBTime = dtmTemp
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


    '*******************
    'Public
    '*******************
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
    ''' ﾃﾞｰﾀ送信
    ''' </summary>
    ''' <param name="strSendText">送信ﾃｷｽﾄ</param>
    ''' <param name="objTLIF_TRNS_SEND">搬送制御送信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <returns>正常終了の有無</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function SendData(ByVal strSendText As String _
                           , ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND _
                           ) As RetCode
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
            mobjSerial.Send(strSendText, _
                            clsMcvSerial.SerialKind.Send)


            '*****************************************************
            '再送信用ﾃﾞｰﾀ     ｾｯﾄ
            '*****************************************************
            mobjEQSendTelBuff.FDENBUN = strSendText        '再送信用ﾃｷｽﾄﾊﾞｯﾌｧ
            mdtmBeforeSendTime = Now                        '前回送信日時


            '*****************************************************
            'ﾛｸﾞ出力
            '*****************************************************
            '===========================================
            'ﾃｷｽﾄﾛｸﾞ追加
            '===========================================
            Call AddToLog(MCIA_MSG_021 & strSendText)

            '===========================================
            'ﾃｷｽﾄID取得
            '===========================================
            Dim strFTEXT_ID As String = ""
            strFTEXT_ID = MID_SJIS(strSendText, 1, 16)

            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
            If mobjEQSendTelBuff.FENTRY_NO <> FENTRY_NO_SMCI_MYSELF Then
                '↑↑↑↑↑↑************************************************************************************************************
                Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)   '設備通信ﾛｸﾞ
                objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '設備ID
                objTLOG_EQ.FHASSEI_DT = Now                         '発生日時
                objTLOG_EQ.FDIRECTION = FDIRECTION_SSEND            '方向
                Select Case mobjEQSendTelBuff.FCOMMAND_ID
                    Case FCOMMAND_ID_SONLINE : objTLOG_EQ.FTEXT_ID = FTEXT_ID_JMCV_000      'ﾃｷｽﾄID
                    Case FCOMMAND_ID_SOFFLINE : objTLOG_EQ.FTEXT_ID = FTEXT_ID_JMCV_999     'ﾃｷｽﾄID
                    Case Else : objTLOG_EQ.FTEXT_ID = objTLIF_TRNS_SEND.FTEXT_ID            'ﾃｷｽﾄID
                End Select
                objTLOG_EQ.FTRNS_SERIAL = DEFAULT_STRING            '搬送ｼﾘｱﾙ№
                objTLOG_EQ.FPALLET_ID = DEFAULT_STRING              'ﾊﾟﾚｯﾄID
                objTLOG_EQ.FDENBUN = strSendText                    '通信電文
                objTLOG_EQ.FRES_CD_EQ = DEFAULT_STRING              '設備応答ｺｰﾄﾞ
                objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '追加
                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
            End If
            '↑↑↑↑↑↑************************************************************************************************************


            Return intRet
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
#Region "  ﾃﾞｰﾀ受信(今回未使用)             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ受信
    ''' </summary>
    ''' <param name="strRecvText">受信ﾃｷｽﾄ</param>
    ''' <remarks>正常終了の有無</remarks>
    '''*******************************************************************************************************************
    Public Sub RecvDataEQ(ByRef strRecvText As String)


        ''****************************************
        ''電文受信
        ''****************************************
        'mobjSerial.Receive()


        ''****************************************
        ''電文部分を抽出 & 受信ﾊﾞｯﾌｧ更新
        ''****************************************
        'If IsNotNull(mobjSerial.strRecvText) Then
        '    '(電文を受信した場合)


        '    '****************************************
        '    '受信ﾊﾞｯﾌｧに結合
        '    '****************************************
        '    If IsNull(mstrRecvTelBuff) Then
        '        mstrRecvTelBuff = mobjSerial.strRecvText
        '    Else
        '        mstrRecvTelBuff &= mobjSerial.strRecvText
        '    End If


        '    '****************************************
        '    '電文部分を抽出 & 受信ﾊﾞｯﾌｧ更新
        '    '****************************************
        '    strRecvText = mobjGetTelegram.GetTelegramSTXETX(mstrRecvTelBuff)
        '    If IsNotNull(strRecvText) Then
        '        Call AddToLog(MCIA_MSG_011 & strRecvText) '電文取得ﾛｸﾞ出力
        '    End If

        'End If


    End Sub
#End Region
#Region "  応答ﾃﾞｰﾀ送信                     "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】strSendText    ：送信ﾃｷｽﾄ
    '【戻値】正常終了の有無
    '*******************************************************************************************************************
    Public Sub SendResponsData(ByVal strSendText As String)


        '*****************************************************
        '連続して送信出来ない為Sleep
        '*****************************************************
        Threading.Thread.Sleep(mintSendSleep)


        '*****************************************************
        'ﾃｷｽﾄﾃﾞｰﾀ送信
        '*****************************************************
        mobjSerial.Send(strSendText, _
                        clsMcvSerial.SerialKind.Recv)


        '*****************************************************
        '応答電文ﾊﾞｯﾌｧにｾｯﾄ
        '*****************************************************
        mobjEQSendResBuff.FDENBUN = strSendText


        '*****************************************************
        'ﾛｸﾞ出力
        '*****************************************************
        '===========================================
        'ﾃｷｽﾄﾛｸﾞ追加
        '===========================================
        Call AddToLog(MCIA_MSG_RES021 & strSendText)

        '===========================================
        'ﾃｷｽﾄID取得
        '===========================================
        Dim strFTEXT_ID As String = ""
        strFTEXT_ID = MID_SJIS(strSendText, 1, 16)

        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
        If mobjEQSendTelBuff.FENTRY_NO <> FENTRY_NO_SMCI_MYSELF Then
            '↑↑↑↑↑↑************************************************************************************************************
            Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)   '設備通信ﾛｸﾞ
            objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '設備ID
            objTLOG_EQ.FHASSEI_DT = Now                         '発生日時
            objTLOG_EQ.FDIRECTION = FDIRECTION_SSEND             '方向
            objTLOG_EQ.FTEXT_ID = FTEXT_ID_SRE                  'ﾃｷｽﾄID
            objTLOG_EQ.FTRNS_SERIAL = DEFAULT_STRING            '搬送ｼﾘｱﾙ№
            objTLOG_EQ.FPALLET_ID = DEFAULT_STRING              'ﾊﾟﾚｯﾄID
            objTLOG_EQ.FDENBUN = strSendText                    '通信電文
            objTLOG_EQ.FRES_CD_EQ = DEFAULT_STRING              '設備応答ｺｰﾄﾞ
            objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '追加
            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
        End If
        '↑↑↑↑↑↑************************************************************************************************************


    End Sub
#End Region

    'ｼｰｹﾝｽ№関係
#Region "  送信ｼｰｹﾝｽNo + 1"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】なし
    '*******************************************************************************************************************
    Public Sub SeqNoSendUpdate()

        '*****************************************************
        '送信用SeqNo  + 1
        '*****************************************************
        Dim intSeqPlus1 As Integer = SeqNoPlus1(GetSYS_HEN(mFHENSU_IDSeqNoSend))
        Call SetSYS_HEN(mFHENSU_IDSeqNoSend, intSeqPlus1)

    End Sub
#End Region
#Region "  受信ｼｰｹﾝｽNo + 1"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】なし
    '*******************************************************************************************************************
    Public Sub SeqNoRecvUpdate()

        '*****************************************************
        '送信用SeqNo  + 1
        '*****************************************************
        Dim intSeqPlus1 As Integer = SeqNoPlus1(GetSYS_HEN(mFHENSU_IDSeqNoRecv))
        Call SetSYS_HEN(mFHENSU_IDSeqNoRecv, intSeqPlus1)

    End Sub
#End Region
#Region "  送信ｼｰｹﾝｽNo - 1"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】なし
    '*******************************************************************************************************************
    Public Sub SeqNoSendUpdateMinus()

        '*****************************************************
        '送信用SeqNo  - 1
        '*****************************************************
        Dim intSeqMinus1 As Integer = SeqNoMinus1(GetSYS_HEN(mFHENSU_IDSeqNoSend))
        Call SetSYS_HEN(mFHENSU_IDSeqNoSend, intSeqMinus1)

    End Sub
#End Region
#Region "  受信ｼｰｹﾝｽNo - 1"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】なし
    '*******************************************************************************************************************
    Public Sub SeqNoRecvUpdateMinus()

        '*****************************************************
        '送信用SeqNo  - 1
        '*****************************************************
        Dim intSeqMinus1 As Integer = SeqNoMinus1(GetSYS_HEN(mFHENSU_IDSeqNoRecv))
        Call SetSYS_HEN(mFHENSU_IDSeqNoRecv, intSeqMinus1)

    End Sub
#End Region
#Region "  ｼｰｹﾝｽNo + 1          処理"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ IN ]intSeqNo         ：+ 1 するｼｰｹﾝｽNo
    '【戻値】+ 1 した値
    '*******************************************************************************************************************
    Public Function SeqNoPlus1(ByVal intSeqNo As Integer) As Integer
        Dim intRet As Integer

        Select Case intSeqNo
            Case 255
                intRet = 1
            Case Else
                intRet = intSeqNo + 1
        End Select

        Return (intRet)
    End Function
#End Region
#Region "  ｼｰｹﾝｽNo - 1          処理"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ IN ]intSeqNo         ：- 1 するｼｰｹﾝｽNo
    '【戻値】+ 1 した値
    '*******************************************************************************************************************
    Public Function SeqNoMinus1(ByVal intSeqNo As Integer) As Integer
        Dim intRet As Integer

        Select Case intSeqNo
            Case 1
                intRet = 255
            Case Else
                intRet = intSeqNo - 1
        End Select

        Return (intRet)
    End Function
#End Region


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
    Private Sub MCIA_100002(ByVal strRecvText As String)
        Try
            Dim strMsg As String = ""       'ﾒｯｾｰｼﾞ


            '*****************************************************
            '受信電文有無ﾁｪｯｸ
            '*****************************************************
            If strRecvText = "" Then Exit Sub
            mdtmBeforeRecvTime = Now


            '*****************************************************
            '受信電文分解
            '*****************************************************
            Dim objTel As New clsTelegram(mstrTelConfigPath)
            objTel.FORMAT_ID = FORMAT_BCR_01                    'ﾌｫｰﾏｯﾄ名ｾｯﾄ    (特に何でも良い)
            objTel.TELEGRAM_PARTITION = strRecvText             '分割する電文ｾｯﾄ
            objTel.PARTITION()                                  '電文分割


            '*****************************************************
            '【設備通信ﾛｸﾞ】             追加
            '*****************************************************
            Dim strFTEXT_ID As String = FTEXT_ID_JBCR_01     'ﾃｷｽﾄID
            Dim blnLogAdd As Boolean = True                  '受信電文をﾛｸﾞ出力したか否かのﾌﾗｸﾞ
            ''↓↓↓↓↓↓************************************************************************************************************
            ''SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
            'If mobjEQSendTelBuff.FTEXT_ID <> FTEXT_ID_JLC_05 Or mstrEQ_SendTimerTel_Before <> strRecvText Then
            '    If mobjEQSendTelBuff.FTEXT_ID = FTEXT_ID_JLC_05 Then
            '        Call AddDBRecvLog_LOG(FTEXT_ID_JLC_05_00 _
            '                            , strRecvText _
            '                            , "" _
            '                            )
            '    Else
            '        '↑↑↑↑↑↑************************************************************************************************************

            Call AddDBRecvLog_LOG(strFTEXT_ID _
                                , strRecvText _
                                , "" _
                                )

            '        '↓↓↓↓↓↓************************************************************************************************************
            '        'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
            '    End If
            '    If mobjEQSendTelBuff.FTEXT_ID = FTEXT_ID_JLC_05 Then mstrEQ_SendTimerTel_Before = strRecvText
            'Else
            '    blnLogAdd = False
            'End If
            ''↑↑↑↑↑↑************************************************************************************************************



            Dim intFRES_CD_EQ As String = ""                    '搬送制御受信IFﾃｰﾌﾞﾙに追加する設備応答ｺｰﾄﾞ
            Dim strFDENBUN_PRM1 As String = Nothing             '電文ﾊﾟﾗﾒｰﾀ1
            Dim strFDENBUN_PRM2 As String = Nothing             '電文ﾊﾟﾗﾒｰﾀ2
            Select Case strFTEXT_ID
                Case "******************************" '電文受信のみなので、この処理は通らない
                    '(応答電文受信の場合)


                    '*****************************************************
                    '搬送制御受信IFﾃｰﾌﾞﾙに追加する設備応答ｺｰﾄﾞ  取得
                    '*****************************************************
                    intFRES_CD_EQ = GetFRES_CD_EQ(strRecvText)


                    '*****************************************************
                    '【搬送制御送信ｲﾝﾀｰﾌｪｰｽ】   更新
                    '*****************************************************
                    If mobjEQSendTelBuff.FENTRY_NO <> "" Then
                        Call UpdateSendFPROGRESS(FPROGRESS_SEND, intFRES_CD_EQ)      '通信状態変更
                        strFDENBUN_PRM1 = mobjEQSendTelBuff.FTEXT_ID    '電文ﾊﾟﾗﾒｰﾀ1
                        strFDENBUN_PRM2 = mobjEQSendTelBuff.FDENBUN     '電文ﾊﾟﾗﾒｰﾀ2
                    End If


                    '*****************************************************
                    '通信状態を送信可能状態にする
                    '*****************************************************
                    mintResponsWait = FLAG_OFF                  '応答待ちﾌﾗｸﾞ   ｾｯﾄ
                    mintSendCount = 0                           '再送信回数
                    mobjEQSendTelBuff.CLEAR_PROPERTY()         '前回送信DB情報削除
                    Call InitializeDBReadTimer()                '続けてDB検索処理


                Case Else
                    '(通常の電文受信の場合)

                    'NOP

            End Select


            '*****************************************************
            '【搬送制御送受信ｲﾝﾀｰﾌｪｰｽ】   追加
            '*****************************************************
            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
            If blnLogAdd = True Then
                '↑↑↑↑↑↑************************************************************************************************************

                Call AddDBRecvLIF_TRNS_RECV(FCOMMAND_ID_SOT _
                                              , strRecvText _
                                              , strFTEXT_ID _
                                              , FPROGRESS_SEND _
                                              , intFRES_CD_EQ _
                                              , strFDENBUN_PRM1 _
                                              , strFDENBUN_PRM2 _
                                              )

                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
            End If
            '↑↑↑↑↑↑************************************************************************************************************


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  MCIA_100011  応答電文ﾀｲﾑｱｳﾄﾁｪｯｸ      処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾀｲﾑｱｳﾄﾁｪｯｸ
    ''' </summary>
    ''' <param name="strRET_CD">受信した応答ｺｰﾄﾞ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_100011(ByVal strRET_CD As String)
        Try


            '*****************************************************
            '応答ﾌﾗｸﾞﾁｪｯｸ
            '*****************************************************
            If mintResponsWait = FLAG_OFF Then Exit Sub


            If mintSendCount < mintSendRetry Then
                '(ﾘﾄﾗｲの場合)


                '*****************************************************
                'ﾘﾄﾗｲ送信
                '*****************************************************
                Dim udtRet As RetCode
                udtRet = SendData(mobjEQSendTelBuff.FDENBUN, mobjEQSendTelBuff)    '電文送信
                mintSendCount += 1


            Else
                '(ﾘﾄﾗｲｵｰﾊﾞｰの場合)


                '*****************************************************
                'ﾘﾄﾗｲｵｰﾊﾞｰ
                'ﾀｲﾑｱｳﾄ処理
                '*****************************************************
                '========================================
                '【搬送制御送信ｲﾝﾀｰﾌｪｰｽ】   更新
                '========================================
                If mobjEQSendTelBuff.FENTRY_NO <> "" Then
                    '(ｻｰﾊﾞからの電文の場合)
                    Call UpdateSendFPROGRESS(FPROGRESS_STIMEOUT)        '通信状態変更
                    Call UpdateSendFRES_CD_EQ(strRET_CD)                '応答ｺｰﾄﾞ追加
                End If
                If IsNull(strRET_CD) Then
                    Call AddToLog(MCIA_MSG_031)
                    Call ErrorAdd(mstrFMSG_ID_ERR_USER, ERR_MSG_01, MCIA_MSG_031)
                End If

                '========================================
                '通信ﾎｰﾙﾄﾞ
                '========================================
                Call CommunicationHold()


            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region

#Region "  MCIA_100001  DB検索 & 電文送信        処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' DB検索 ＆ 電文送信
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_100001(ByVal blnCheck As Boolean)
        Try
            Dim udtRet As RetCode

            '*****************************************************
            '応答ﾌﾗｸﾞﾁｪｯｸ
            '*****************************************************
            If mintResponsWait = FLAG_ON Then
                '(応答ﾌﾗｸﾞ = ON の場合)
                Exit Sub
            End If


            '*****************************************************
            'ﾀｲﾑｱｳﾄﾁｪｯｸ
            '*****************************************************
            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
            If blnCheck = True Then
                '↑↑↑↑↑↑************************************************************************************************************


                '*****************************************************
                'ﾀｲﾏｰ処理
                '*****************************************************
                Dim objDiff As TimeSpan = mdtmBeforeDBTime.AddMilliseconds(mintDBReadTimer) - Now
                If 0 < objDiff.TotalMilliseconds Then
                    Exit Sub
                End If
                mdtmBeforeDBTime = Now


                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
            End If
            '↑↑↑↑↑↑************************************************************************************************************


            '********************************************************************************
            '進捗状態 = 異常終了　もしくは、設備応答ｺｰﾄﾞ <> 「00」のﾚｺｰﾄﾞ検索
            '********************************************************************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(mobjOwner, mobjDb, mobjDbLog)
            objTLIF_TRNS_SEND.FEQ_ID = mstrFEQ_ID                           '設備ID
            udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_ERROR_RECORD()    '進捗状態 = 異常終了　もしくは、設備応答ｺｰﾄﾞ <> 「00」のﾚｺｰﾄﾞ検索
            If udtRet = RetCode.OK Then
                Call AddToLog("送信異常したﾚｺｰﾄﾞが存在する為、送信処理は行いません。")
                Exit Sub
            End If
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)
            objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                           '設備ID
            udtRet = objTLIF_TRNS_RECV.GET_TLIF_TRNS_RECV_ERROR_RECORD()    '通信ｴﾗｰﾚｺｰﾄﾞ検索
            If udtRet = RetCode.OK Then
                Call AddToLog("異常応答ｺｰﾄﾞのﾚｺｰﾄﾞが存在する為、送信処理は行いません。")
                Exit Sub
            End If


            '*****************************************************
            '送信ﾊﾞｯﾌｧ      (通信状態 = 送信中 → 未実施)ﾚｺｰﾄﾞ更新
            '*****************************************************
            Call Update_INTCOMM_STS_ACT()


            '*****************************************************
            '送信ﾊﾞｯﾌｧ検索
            '*****************************************************
            If GetSYS_HEN(mFHENSU_IDAbnormal) = FLAG_OFF Then
                '(通信異常でない場合)

                '==========================================
                '【設備状態】   ｵﾝﾗｲﾝ確認
                '==========================================
                Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(mobjOwner, mobjDb, mobjDbLog)
                objTSTS_EQ_CTRL.FEQ_ID = mstrFEQ_ID                 'MCVｺﾈｸｼｮﾝ
                objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                  '取得
                If objTSTS_EQ_CTRL.FEQ_CUT_STS = FLAG_OFF _
                   And objTSTS_EQ_CTRL.FEQ_STS = FEQ_STS_SMCI_ONLINE Then
                    '(「MCV」 = 「ｵﾝﾗｲﾝ」の場合)

                    objTLIF_TRNS_SEND.FEQ_ID = mstrFEQ_ID
                    udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_LATEST()      '送信ﾊﾞｯﾌｧ検索
                    If udtRet <> RetCode.OK Then
                        '(送信ﾊﾞｯﾌｧにﾃﾞｰﾀがない場合)
                        Exit Sub            '脱出
                    End If

                Else
                    '(「MCV」 = 「ｵﾌﾗｲﾝ」の場合)

                    objTLIF_TRNS_SEND.FEQ_ID = mstrFEQ_ID
                    udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_LATEST_FOFFLINE_FLAG()       '送信ﾊﾞｯﾌｧ検索(ｵﾌﾗｲﾝﾌﾗｸﾞ=FLAG_ONのみ)
                    If udtRet <> RetCode.OK Then
                        '(送信ﾊﾞｯﾌｧにﾃﾞｰﾀがない場合)
                        Exit Sub            '脱出
                    End If
                End If

            End If
            Call SetSendBuff(objTLIF_TRNS_SEND)


            '*****************************************************
            'IDによって分岐 & ﾃｷｽﾄ送信
            '*****************************************************
            Dim strTelegram As String = ""          '送信電文
            Select Case objTLIF_TRNS_SEND.FCOMMAND_ID
                Case FCOMMAND_ID_SONLINE             'ｵﾝﾗｲﾝ要求
                    udtRet = ID01Process(objTLIF_TRNS_SEND, strTelegram)

                Case FCOMMAND_ID_SOFFLINE            'ｵﾌﾗｲﾝ要求
                    udtRet = ID02Process(objTLIF_TRNS_SEND, strTelegram)

                Case FCOMMAND_ID_SSQL                'SQL実行
                    udtRet = IDSQLProcess(objTLIF_TRNS_SEND)
                    Exit Sub

                Case Else                           'その他
                    udtRet = IDZZProcess(objTLIF_TRNS_SEND, strTelegram)

            End Select


            '*****************************************************
            '電文送信
            '*****************************************************
            If udtRet = RetCode.OK Then
                udtRet = SendData(strTelegram, objTLIF_TRNS_SEND)       '電文送信
                mintSendCount = 1                                       '送信回数(一回目)
            End If


            '*****************************************************
            'ﾃｷｽﾄ送信結果により処理変更
            '*****************************************************
            '共通
            mdtmBeforeSendTime = Now                                        '前回送信日時   ｾｯﾄ

            Select Case udtRet
                Case RetCode.OK
                    '=========================================
                    '正常
                    '=========================================
                    Call UpdateSendFPROGRESS(FPROGRESS_SACT)            '搬送制御送信ｲﾝﾀｰﾌｪｰｽ.通信状態      ｾｯﾄ
                    mintResponsWait = FLAG_ON                           '応答待ちﾌﾗｸﾞ                       ｾｯﾄ
                    Call SeqNoSendUpdate()                              'ｼｰｹﾝｽNo + 1                        ｾｯﾄ

                Case Else
                    '=========================================
                    '異常
                    '=========================================
                    Call UpdateSendFPROGRESS(FPROGRESS_SERR_MCI)        '搬送制御送信ｲﾝﾀｰﾌｪｰｽ.通信状態      ｾｯﾄ
                    mintResponsWait = FLAG_OFF                          '応答待ちﾌﾗｸﾞ                       ｾｯﾄ
                    '' ''Call SeqNoSendUpdate()                         'ｼｰｹﾝｽNo + 1                        ｾｯﾄ
                    Call mobjEQSendTelBuff.CLEAR_PROPERTY()             '送信ﾊﾞｯﾌｧ                          削除

            End Select


        Catch ex As Exception
            Me.ComError(ex)

        End Try
    End Sub
#End Region
#Region "  MCIA_100201  ｼﾘｱﾙ通信電文受信         処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｼﾘｱﾙ通信電文受信
    ''' </summary>
    ''' <param name="strGetData">正常に受信できたﾃﾞｰﾀ</param>
    ''' <param name="strResponsCode">応答ｺｰﾄﾞ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_100201(ByVal strGetData As String _
                          , ByVal strResponsCode As String _
                          )
        Try


            '*****************************************************
            'ｼﾘｱﾙ通信   受信電文分解
            '*****************************************************
            If strGetData = "" Then
                '(受信電文が存在しなかった場合)
                Exit Sub
            End If


            ' '' ''*****************************************************
            ' '' ''ﾃﾞｰﾀﾘﾝｸ切断時は、ﾃﾞｰﾀﾘﾝｸ確立しか受け付けない
            ' '' ''*****************************************************
            '' ''If mblnCutFlag = True _
            '' ''   And strGetData <> MCV_ID_DIR_ONLINE Then
            '' ''    Exit Sub
            '' ''End If


            '*****************************************************
            'ｼﾘｱﾙ通信   受信電文分解
            '*****************************************************
            Dim objTel As New clsTelegram(mstrTelConfigPath)
            objTel.FORMAT_ID = mstrONLINE_ID                   'ﾌｫｰﾏｯﾄ名ｾｯﾄ    (特に何でも良い)
            objTel.TELEGRAM_PARTITION = strGetData             '分割する電文ｾｯﾄ
            objTel.PARTITION()                                 '電文分割


            '*****************************************************
            '正常に電文受信出来たかﾁｪｯｸ
            '*****************************************************
            If strResponsCode <> FRES_CD_EQ_SMCV_OK Then
                Call ReceiveDustProcess(strGetData, strResponsCode)

                Exit Sub
            End If


            '*****************************************************
            '【設備通信ﾛｸﾞ】受信ﾛｸﾞ追加
            '*****************************************************
            If strGetData = MCV_ID_DIR_ONLINE Or strGetData = MCV_ID_DIR_OFFLINE Then
                Call AddDBRecvLog_LOG(FORMAT_MCV & strGetData _
                                    , strGetData _
                                    , strResponsCode _
                                    )
            Else
                Call AddDBRecvLog_LOG(FORMAT_MCV & objTel.SELECT_HEADER("MCVID") _
                                    , strGetData _
                                    , strResponsCode _
                                    )
            End If


            '*****************************************************
            'ｼｰｹﾝｽNo  ﾁｪｯｸ
            '*****************************************************
            If strResponsCode = FRES_CD_EQ_SMCV_OK Then     '正常に受信していなかったら意味がない為

                Dim strRecvSeqNo As String          '受信したｼｰｹﾝｽNo
                strRecvSeqNo = TO_STRING(objTel.SELECT_HEADER("MCVSEQ_NO"))
                If strRecvSeqNo <> MCV_ID_DIR_ONLINE _
                   And strRecvSeqNo <> MCV_ID_DIR_OFFLINE _
                   And strRecvSeqNo <> MCV_ID_DIR_TEL_READ_ERR _
                   And strRecvSeqNo <> MCV_ID_DIR_RES_READ_ERR Then

                    'ｼｰｹﾝｽNoﾁｪｯｸ不要の為、ｺﾒﾝﾄ化*********************************
                    If TO_NUMBER(strRecvSeqNo) = SeqNoMinus1(GetSYS_HEN(mFHENSU_IDSeqNoRecv)) Then
                        '(前回と同じｼｰｹﾝｽ№の場合)
                        strResponsCode = FRES_CD_EQ_SMCV_ER_ALREADY          '受信済みｴﾗｰ
                    ElseIf TO_NUMBER(strRecvSeqNo) <> GetSYS_HEN(mFHENSU_IDSeqNoRecv) Then
                        '(ｼｰｹﾝｽ№ｴﾗｰの場合)
                        strResponsCode = FRES_CD_EQ_SMCV_ER_SEQNO            'SEQ順序ｴﾗｰ
                        Call AddToLog("ｼｰｹﾝｽ№ｴﾗｰ[期待値:" & GetSYS_HEN(mFHENSU_IDSeqNoRecv) & "][取得値:" & TO_NUMBER(strRecvSeqNo) & "]")
                    End If
                    'ｼｰｹﾝｽNoﾁｪｯｸ不要の為、ｺﾒﾝﾄ化*********************************

                End If

                'ｼｰｹﾝｽNo = 「000」を受信したら、ｼｰｹﾝｽNoをﾘｾｯﾄする
                If strRecvSeqNo = MCV_ID_DIR_ONLINE Then
                    SetSYS_HEN(mFHENSU_IDSeqNoRecv, 0)
                End If
            End If


            '*****************************************************
            'ID によって分岐
            '*****************************************************
            Dim strTRNS_SERIAL_NO_1 As String = ""
            Dim strPALLET_ID1 As String = ""
            Dim strResponsText As String = ""
            Dim strCMD_ID As String = objTel.SELECT_HEADER("MCVID")     'ｺﾏﾝﾄﾞID

            Select Case FORMAT_MCV & strCMD_ID
                Case FTEXT_ID_JMCV_000 _
                   , FTEXT_ID_JMCV_999 _
                   , FTEXT_ID_JMCV_A1 _
                   , FTEXT_ID_JMCV_A2 _
                   , FTEXT_ID_JMCV_A3 _
                   , FTEXT_ID_JMCV_A4 _
                   , FTEXT_ID_JMCV_B1 _
                   , FTEXT_ID_JMCV_B2 _
                   , FTEXT_ID_JMCV_B3 _
                   , FTEXT_ID_JMCV_B4 _
                   , FTEXT_ID_JMCV_B5 _
                   , FTEXT_ID_JMCV_B6 _
                   , FTEXT_ID_JMCV_B7 _
                   , FTEXT_ID_JMCV_B8 _
                   , FTEXT_ID_JMCV_B9 _
                   , FTEXT_ID_JMCV_BA _
                   , FTEXT_ID_JMCV_C1 _
                   , FTEXT_ID_JMCV_C2 _
                   , FTEXT_ID_JMCV_C3 _
                   , FTEXT_ID_JMCV_C4 _
                   , FTEXT_ID_JMCV_C5 _
                   , FTEXT_ID_JMCV_C6 _
                   , FTEXT_ID_JMCV_C7 _
                   , FTEXT_ID_JMCV_C8 _
                   , FTEXT_ID_JMCV_D1 _
                   , FTEXT_ID_JMCV_D2


                    '*****************************************************
                    '応答電文作成
                    '*****************************************************
                    strResponsText = ""
                    strResponsText &= objTel.SELECT_HEADER("MCVSEQ_NO")     'ｼｰｹﾝｽNo
                    strResponsText &= strResponsCode                         '応答ｺｰﾄﾞ


                    'Case FCOMMAND_ID_MCV_A1                             '状態報告A1
                    '    Call A1Process(strGetData, strResponsCode, strTRNS_SERIAL_NO_1, strPALLET_ID1, strResponsText)

                    'Case FCOMMAND_ID_MCV_A2                             '状態報告A2
                    '    Call A2Process(strGetData, strResponsCode, strTRNS_SERIAL_NO_1, strPALLET_ID1, strResponsText)

                    'Case FCOMMAND_ID_MCV_C1                             '搬送完了報告1
                    '    Call C1Process(strGetData, strResponsCode, strTRNS_SERIAL_NO_1, strPALLET_ID1, strResponsText)

                    'Case FCOMMAND_ID_MCV_C2                             '搬送完了報告2
                    '    Call C2Process(strGetData, strResponsCode, strTRNS_SERIAL_NO_1, strPALLET_ID1, strResponsText)

                    'Case FCOMMAND_ID_MCV_C3                             '製品PL到着報告
                    '    Call C3Process(strGetData, strResponsCode, strTRNS_SERIAL_NO_1, strPALLET_ID1, strResponsText)

                    'Case FCOMMAND_ID_MCV_C4                             'ｷｬﾝｾﾙ報告
                    '    Call C4Process(strGetData, strResponsCode, strTRNS_SERIAL_NO_1, strPALLET_ID1, strResponsText)

                    'Case FCOMMAND_ID_MCV_C5                             '再検済PL到着報告
                    '    Call C5Process(strGetData, strResponsCode, strTRNS_SERIAL_NO_1, strPALLET_ID1, strResponsText)

                Case Else                                           '不正なID
                    Dim strRecvSeqNo As String          '受信したｼｰｹﾝｽNo
                    strRecvSeqNo = TO_STRING(objTel.SELECT_HEADER("MCVSEQ_NO"))
                    Select Case strRecvSeqNo
                        Case MCV_ID_DIR_ONLINE          'ﾃﾞｰﾀﾘﾝｸ確立
                            Call Receive000Process(strGetData, strResponsCode)
                            Exit Sub

                        Case MCV_ID_DIR_OFFLINE         'ﾃﾞｰﾀﾘﾝｸ切断
                            Call Receive999Process(strGetData, strResponsCode)
                            Exit Sub

                        Case MCV_ID_DIR_TEL_READ_ERR, MCV_ID_DIR_RES_READ_ERR   '再送信要求
                            Call Receive777Process(strGetData, strResponsCode)
                            Exit Sub

                        Case Else
                            Call XXProcess(strGetData, strResponsCode)
                            Exit Sub

                    End Select

            End Select


            '*****************************************************
            '応答電文送信
            '*****************************************************
            Call SendResponsData(strResponsText)


            '**********************************************************************************************************
            '**********************************************************************************************************
            '【搬送制御送受信ｲﾝﾀｰﾌｪｰｽ】   追加
            '    複数電文がまとめて送信されてくる事がるので、IDで電文長を判断して、分割する
            '**********************************************************************************************************
            '**********************************************************************************************************
            Dim strWork01GetData As String = strGetData         '正常に受信できたﾃﾞｰﾀ(作業用)
            Dim strWork02GetData As String = ""                 '分割した後の電文
            While 3 < GET_BYTE_LENGTH_STRING(strWork01GetData)
                '(ﾙｰﾌﾟ:全ての電文を処理するまで)

                '===========================================
                '電文を切り出す
                '===========================================
                Dim strWorkCMD_ID As String = MID_SJIS(strWork01GetData, 4, 2)  'ｺﾏﾝﾄﾞID
                Dim blnCMD_IDErr As String = False                              'ｺﾏﾝﾄﾞIDｴﾗｰﾌﾗｸﾞ
                Select Case FORMAT_MCV & strWorkCMD_ID
                    Case FTEXT_ID_JMCV_A1 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 84)
                    Case FTEXT_ID_JMCV_A2 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 32)
                    Case FTEXT_ID_JMCV_A3 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 10)
                    Case FTEXT_ID_JMCV_A4 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 10)
                    Case FTEXT_ID_JMCV_C1 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 21)
                    Case FTEXT_ID_JMCV_C2 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 21)
                    Case FTEXT_ID_JMCV_C3 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 21)
                        'Case FTEXT_ID_JMCV_C4 : strWork02GetData = MID_SJIS(strWork01GetData, 1, )
                    Case FTEXT_ID_JMCV_C5 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 21)
                    Case FTEXT_ID_JMCV_C6 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 13)
                    Case FTEXT_ID_JMCV_C7 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 22)
                    Case FTEXT_ID_JMCV_C8 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 18)
                    Case FTEXT_ID_JMCV_D1 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 8)
                    Case FTEXT_ID_JMCV_D2 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 8)
                    Case Else
                        '(予想外のﾃｷｽﾄ電文だった場合)
                        strWork02GetData = strWork01GetData
                        blnCMD_IDErr = True
                End Select

                '===========================================
                '【搬送制御送受信ｲﾝﾀｰﾌｪｰｽ】   追加
                '===========================================
                Dim strFDENBUN_PRM1 As String = ""             '電文ﾊﾟﾗﾒｰﾀ1
                Dim strFDENBUN_PRM2 As String = ""             '電文ﾊﾟﾗﾒｰﾀ2
                Call AddDBRecvLIF_TRNS_RECV(FCOMMAND_ID_SOT _
                                          , strWork02GetData _
                                          , FORMAT_MCV & strWorkCMD_ID _
                                          , FPROGRESS_SEND _
                                          , strResponsCode _
                                          , strFDENBUN_PRM1 _
                                          , strFDENBUN_PRM2 _
                                          )

                '===========================================
                '次の分割用電文作成
                '===========================================
                If blnCMD_IDErr = False Then
                    '(ｺﾏﾝﾄﾞID正常の場合)
                    strWork01GetData = MID_SJIS(strGetData, 1, 3) & MID_SJIS(strWork01GetData, GET_BYTE_LENGTH_STRING(strWork02GetData) + 1)
                Else
                    '(ｺﾏﾝﾄﾞID異常の場合)
                    '常にこっちの処理を行えば良いかもしれないが、電文の中にｺﾏﾝﾄﾞIDが偶然入ってしまうと、正常な切り取り作業が行いので、こっちはあくまで非常時用

                    '次のｺﾏﾝﾄﾞIDを検索
                    Dim intAryPos(12) As Integer
                    intAryPos(0) = InStr(6, strWork01GetData, "A1")
                    intAryPos(1) = InStr(6, strWork01GetData, "A2")
                    intAryPos(2) = InStr(6, strWork01GetData, "A3")
                    intAryPos(3) = InStr(6, strWork01GetData, "A4")
                    intAryPos(4) = InStr(6, strWork01GetData, "C1")
                    intAryPos(5) = InStr(6, strWork01GetData, "C2")
                    intAryPos(6) = InStr(6, strWork01GetData, "C3")
                    intAryPos(7) = InStr(6, strWork01GetData, "C5")
                    intAryPos(8) = InStr(6, strWork01GetData, "C6")
                    intAryPos(9) = InStr(6, strWork01GetData, "C7")
                    intAryPos(10) = InStr(6, strWork01GetData, "C8")
                    intAryPos(11) = InStr(6, strWork01GetData, "D1")
                    intAryPos(12) = InStr(6, strWork01GetData, "D2")

                    '次の電文の開始位置を取得
                    Dim intPosNext As Integer = 0      '次の電文の開始位置
                    For Each intPos As Integer In intAryPos
                        '(ﾙｰﾌﾟ:判明しているｺﾏﾝﾄﾞIDの数)

                        If intPos = 0 Then Continue For
                        If intPosNext = 0 Then
                            intPosNext = intPos
                        Else
                            If intPos < intPosNext Then
                                intPosNext = intPos
                            End If
                        End If

                    Next
                    If intPosNext = 0 Then Exit While

                    '次の電文を取得
                    strWork01GetData = MID_SJIS(strGetData, 1, 3) & MID_SJIS(strWork01GetData, intPosNext)

                End If


            End While

            'Dim strFDENBUN_PRM1 As String = ""             '電文ﾊﾟﾗﾒｰﾀ1
            'Dim strFDENBUN_PRM2 As String = ""             '電文ﾊﾟﾗﾒｰﾀ2
            'Call AddDBRecvLIF_TRNS_RECV(FCOMMAND_ID_SOT _
            '                          , strGetData _
            '                          , FORMAT_MCV & strCMD_ID _
            '                          , FPROGRESS_SEND _
            '                          , strResponsCode _
            '                          , strFDENBUN_PRM1 _
            '                          , strFDENBUN_PRM2 _
            '                          )


            ''*****************************************************
            ''【MCV通信ﾛｸﾞ】             追加
            ''*****************************************************
            ''受信電文ﾛｸﾞ
            'Call AddDBRecvLog_LOG_MCV(strCMD_ID, _
            '                          strGetData, _
            '                          strResponsCode, _
            '                          strTRNS_SERIAL_NO_1, _
            '                          strPALLET_ID1 _
            '                          )
            ''応答電文ﾛｸﾞ
            'Call AddDBSendResponsLog_LOG_MCV(FCOMMAND_ID_JMCV_RESPONS, _
            '                                 strResponsText, _
            '                                 strResponsCode, _
            '                                 "", _
            '                                 "" _
            '                                 )


            '*****************************************************
            '受信用SeqNo    更新
            '*****************************************************
            If strResponsCode = FRES_CD_EQ_SMCV_OK Then
                Call SeqNoRecvUpdate()              '受信ｼｰｹﾝｽNo + 1
                ''mintRecvSEQNo = intSeqNo_Recv       '受信したｼｰｹﾝｽNoに変更
            End If


        Catch ex As Exception
            Me.ComError(ex)

        End Try
    End Sub
#End Region
#Region "  MCIA_100202  ｼﾘｱﾙ通信応答受信         処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｼﾘｱﾙ通信応答受信
    ''' </summary>
    ''' <param name="strGetData">正常に受信できたﾃﾞｰﾀ</param>
    ''' <param name="strResponsCode">応答ｺｰﾄﾞ(使用していない)</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_100202(ByVal strGetData As String _
                          , ByVal strResponsCode As String _
                          )
        Try

            '*****************************************************
            '応答ﾌﾗｸﾞﾁｪｯｸ
            '*****************************************************
            If mintResponsWait = FLAG_OFF Then
                '(応答ﾌﾗｸﾞ = OFF の場合)
                Exit Sub
            End If


            '*****************************************************
            '応答電文有無ﾁｪｯｸ
            '*****************************************************
            Select Case strGetData
                Case ""
                    '=========================================
                    '応答電文なし    (脱出)
                    '=========================================
                    Call MCV_Respons_Nothing()
                    Exit Sub
                Case Else
                    '何もしない
            End Select


            '*****************************************************
            'ｼﾘｱﾙ通信   受信電文分解
            '*****************************************************
            Dim objTel As New clsTelegram(mstrTelConfigPath)
            Dim strRET_CD As String                             '応答ｺｰﾄﾞ
            objTel.FORMAT_ID = mstrONLINE_ID                    'ﾌｫｰﾏｯﾄ名ｾｯﾄ    (特に何でも良い)
            objTel.TELEGRAM_PARTITION = strGetData              '分割する電文ｾｯﾄ
            objTel.PARTITION()                                  '電文分割
            strRET_CD = TO_STRING(objTel.SELECT_HEADER("MCVID"))    '応答ｺｰﾄﾞ


            '*****************************************************
            '【設備通信ﾛｸﾞ】受信ﾛｸﾞ追加
            '*****************************************************
            Call AddDBRecvLog_LOG(FCOMMAND_ID_JMCV_RESPONS _
                                , strGetData _
                                , strResponsCode _
                                )


            '*****************************************************
            '正常に電文を受信出来たかﾁｪｯｸ
            '*****************************************************
            If strResponsCode <> FRES_CD_EQ_SMCV_OK Then
                '==========================================
                '応答電文再送信要求   (脱出)
                '==========================================
                Call MCV_Respons_Dust()

                '' '' ''Dim str777Text As String        '再送信要求ﾃｷｽﾄ
                '' '' ''str777Text = ""
                '' '' ''str777Text &= "777"             '再送信要求ﾃｷｽﾄ
                '' '' ''Call SendDataMCV(str777Text)

                Exit Sub
            End If


            '*****************************************************
            'ｼｰｹﾝｽNo    ﾁｪｯｸ
            '*****************************************************
            If mobjEQSendTelBuff.FDENBUN <> MCV_ID_DIR_ONLINE _
               And mobjEQSendTelBuff.FDENBUN <> MCV_ID_DIR_OFFLINE Then

                Dim intSeqNo_Recv As Integer = TO_NUMBER(objTel.SELECT_HEADER("MCVSEQ_NO"))    '受信したｼｰｹﾝｽNo
                Select Case intSeqNo_Recv
                    Case SeqNoMinus1(GetSYS_HEN(mFHENSU_IDSeqNoSend))
                        '何もしない

                    Case 0
                        '何もしない

                    Case 999
                        '何もしない

                    Case 777, 888
                        '=========================================
                        '応答ｺｰﾄﾞ = 異常
                        '=========================================
                        Call MCIA_100011(strRET_CD)
                        Exit Sub
                        '' '' ''Case 0
                        '' '' ''    mintRecvSEQNo = 1

                    Case Else
                        '=========================================
                        'ｼｰｹﾝｽNo異常
                        '=========================================
                        Call MCIA_100011(strRET_CD)
                        Exit Sub

                End Select
            End If


            '*****************************************************
            '応答ｺｰﾄﾞ       ﾁｪｯｸ
            '*****************************************************
            Select Case strRET_CD
                Case FRES_CD_EQ_SMCV_OK
                    '' ''Case FRES_CD_EQ_MCV_OK, FRES_CD_EQ_MCV_ER_SEQNO, FRES_CD_EQ_MCV_ER_ALREADY
                    '=========================================
                    '応答ｺｰﾄﾞ = 正常
                    '=========================================
                    Call MCV_Respons_OK(strRET_CD)


                Case Else
                    '=========================================
                    '応答ｺｰﾄﾞ = 異常
                    '=========================================
                    Call MCIA_100011(strRET_CD)


            End Select


        Catch ex As Exception
            Me.ComError(ex)

        End Try
    End Sub
#End Region

    '応答ｺｰﾄﾞ         ID処理
#Region "  正常             受信"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】strRET_CD      ：受信した応答ｺｰﾄﾞ
    '【戻値】
    '*******************************************************************************************************************
    Private Sub MCV_Respons_OK(ByVal strRET_CD As String)

        '*****************************************************
        '【搬送制御送信ｲﾝﾀｰﾌｪｰｽ】   更新
        '*****************************************************
        If mobjEQSendTelBuff.FENTRY_NO <> "" Then
            Call UpdateSendFPROGRESS(FPROGRESS_SEND)    '通信状態変更
            Call UpdateSendFRES_CD_EQ(strRET_CD)        '応答ｺｰﾄﾞ追加
        End If


        '*****************************************************
        '通信状態を送信可能状態にする
        '*****************************************************
        mintResponsWait = FLAG_OFF                  '応答待ちﾌﾗｸﾞ   ｾｯﾄ
        mintSendCount = 0                           '再送信回数
        mobjEQSendTelBuff.CLEAR_PROPERTY()          '前回送信DB情報削除
        SetSYS_HEN(mFHENSU_IDAbnormal, FLAG_OFF)    '異常ﾌﾗｸﾞ(Trueの時は、"000"しか送信しない)


    End Sub
#End Region
#Region "  応答なし         受信"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub MCV_Respons_Nothing()


        '*****************************************************
        'ﾀｲﾑｱｳﾄﾁｪｯｸ
        '*****************************************************
        If 0 < mintSendTimeout Then
            '(EQ応答ｿｹｯﾄ待機時間がｾｯﾄされている場合)

            Dim objDiff As TimeSpan = mdtmBeforeSendTime.AddMilliseconds(mintSendTimeout) - Now
            If 0 < objDiff.TotalMilliseconds Then
                Exit Sub
            End If

        End If


        '*****************************************************
        '再送信処理
        '*****************************************************
        Call MCIA_100011("")


    End Sub
#End Region
#Region "  文字化け電文     受信"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub MCV_Respons_Dust()

        '*****************************************************
        'ﾊﾞｯﾌｧに「777」を挿入して、再送信
        '*****************************************************
        mobjEQSendTelBuff.FCOMMAND_ID = MCV_ID_DIR_TEL_READ_ERR
        mobjEQSendTelBuff.FDENBUN = MCV_ID_DIR_TEL_READ_ERR

        Call MCIA_100011("")


    End Sub
#End Region
#Region "  ｼｰｹﾝｽNo異常      受信"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】strRET_CD      ：受信した応答ｺｰﾄﾞ
    '【戻値】
    '*******************************************************************************************************************
    Private Sub MCV_Respons_SEQNoError(ByVal strRET_CD As String)

        '*****************************************************
        '【搬送制御送信ｲﾝﾀｰﾌｪｰｽ】   更新
        '*****************************************************
        If mobjEQSendTelBuff.FENTRY_NO <> "" Then
            Call UpdateSendFPROGRESS(FPROGRESS_SNON)        '通信状態変更
        End If


        '*****************************************************
        '通信状態を送信可能状態にする
        '*****************************************************
        mintResponsWait = FLAG_OFF                  '応答待ちﾌﾗｸﾞ   ｾｯﾄ
        mintSendCount = 0                           '再送信回数
        SetSYS_HEN(mFHENSU_IDAbnormal, FLAG_OFF)    '異常ﾌﾗｸﾞ(Trueの時は、"000"しか送信しない)
        mobjEQSendTelBuff.CLEAR_PROPERTY()          '前回送信DB情報削除


        '*****************************************************
        'ﾃﾞｰﾀﾘﾝｸ確立電文を送信ﾊﾞｯﾌｧに追加
        '*****************************************************
        Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(mobjOwner, mobjDb, mobjDbLog)   '搬送制御送信IFｸﾗｽ
        objTLIF_TRNS_SEND.FCOMMAND_ID = MCV_ID_DIR_ONLINE       'ｺﾏﾝﾄﾞID        :ﾃﾞｰﾀﾘﾝｸ確立
        objTLIF_TRNS_SEND.FDENBUN = MCV_ID_DIR_ONLINE           '通信ﾃｷｽﾄ
        objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SNON            '通信状態
        objTLIF_TRNS_SEND.FENTRY_DT = mdtmNow                   '登録日時
        objTLIF_TRNS_SEND.FUPDATE_DT = mdtmNow                  '更新日時
        objTLIF_TRNS_SEND.ADD_TLIF_TRNS_SEND_SEQ()              '登録

    End Sub
#End Region


#Region "  000 ﾃﾞｰﾀﾘﾝｸ確立              受信    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ IN ]strGetData       ：正常に受信できたﾃﾞｰﾀ
    '        [ IN ]strResponsCode   ：応答ｺｰﾄﾞ
    '【戻値】
    '*******************************************************************************************************************
    Private Sub Receive000Process(ByVal strGetData As String, _
                                  ByVal strResponsCode As String)
        Try

            '*****************************************************
            '初期化
            '*****************************************************
            Call SetSYS_HEN(mFHENSU_IDSeqNoRecv, 1)
            mblnCutFlag = False


            '*****************************************************
            '【搬送制御受信ｲﾝﾀｰﾌｪｰｽ】   追加
            '*****************************************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)       '搬送制御送信IFｸﾗｽ
            objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                       '設備ID
            objTLIF_TRNS_RECV.FCOMMAND_ID = FCOMMAND_ID_JMCV_000        'ｺﾏﾝﾄﾞID    :ﾃﾞｰﾀﾘﾝｸ切断
            objTLIF_TRNS_RECV.FTEXT_ID = FTEXT_ID_JMCV_000              'ﾃｷｽﾄID
            objTLIF_TRNS_RECV.FDENBUN = strGetData                      '通信ﾃｷｽﾄ
            objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SEND                '進捗状態
            objTLIF_TRNS_RECV.FRES_CD_EQ = FRES_CD_EQ_SMCV_OK           '設備応答ｺｰﾄﾞ
            objTLIF_TRNS_RECV.FENTRY_DT = mdtmNow                       '登録日時
            objTLIF_TRNS_RECV.FUPDATE_DT = mdtmNow                      '更新日時
            objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()                  '登録


            '*****************************************************
            '応答電文作成 & 送信
            '*****************************************************
            Dim strResponsText As String            '応答ﾃｷｽﾄ
            strResponsText = ""
            strResponsText &= MCV_ID_DIR_ONLINE     'ﾃﾞｰﾀﾘﾝｸ確立
            strResponsText &= FRES_CD_EQ_SMCV_OK     '応答ｺｰﾄﾞ
            Call SendResponsData(strResponsText)


            ''*****************************************************
            ''MCV通信ﾛｸﾞ                 受信電文追加
            ''*****************************************************
            ''受信電文ﾛｸﾞ
            'Call AddDBRecvLog_LOG_MCV(MCV_ID_DIR_ONLINE, _
            '                          MCV_ID_DIR_ONLINE, _
            '                          strResponsCode _
            '                          )
            ''応答電文ﾛｸﾞ
            'Call AddDBSendResponsLog_LOG_MCV(FCOMMAND_ID_JMCV_RESPONS, _
            '                                 strResponsText, _
            '                                 strResponsCode _
            '                                 )


        Catch ex As Exception
            Call AddToLog(MCIA_MSG_ERR_002 & "[" & strGetData & "]")
            Me.ComError(ex)
            strResponsCode = FRES_CD_EQ_SMCV_ER_FORMAT       '応答ｺｰﾄﾞ
            Dim strResponsText As String                    '応答ﾃｷｽﾄ
            strResponsText = ""
            strResponsText &= Mid(strGetData, 1, 3)         'ｼｰｹﾝｽ№
            strResponsText &= FRES_CD_EQ_SMCV_ER_FORMAT      '応答ｺｰﾄﾞ
            Call SendResponsData(strResponsText)

        End Try
    End Sub
#End Region
#Region "  999 ﾃﾞｰﾀﾘﾝｸ切断              受信    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ IN ]strGetData       ：正常に受信できたﾃﾞｰﾀ
    '        [ IN ]strResponsCode   ：応答ｺｰﾄﾞ
    '【戻値】
    '*******************************************************************************************************************
    Private Sub Receive999Process(ByVal strGetData As String, _
                                  ByVal strResponsCode As String)
        Try

            '*****************************************************
            '初期化
            '*****************************************************
            Call SetSYS_HEN(mFHENSU_IDSeqNoRecv, 1)
            mblnCutFlag = True


            '*****************************************************
            '【搬送制御受信ｲﾝﾀｰﾌｪｰｽ】   追加
            '*****************************************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)       '搬送制御送信IFｸﾗｽ
            objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                   '設備ID
            objTLIF_TRNS_RECV.FCOMMAND_ID = FCOMMAND_ID_JMCV_999    'ｺﾏﾝﾄﾞID    :ﾃﾞｰﾀﾘﾝｸ切断
            objTLIF_TRNS_RECV.FTEXT_ID = FTEXT_ID_JMCV_999          'ﾃｷｽﾄID
            objTLIF_TRNS_RECV.FDENBUN = strGetData                  '通信ﾃｷｽﾄ
            objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SEND            '通信状態
            objTLIF_TRNS_RECV.FRES_CD_EQ = FRES_CD_EQ_SMCV_OK       '設備応答ｺｰﾄﾞ
            objTLIF_TRNS_RECV.FENTRY_DT = mdtmNow                   '登録日時
            objTLIF_TRNS_RECV.FUPDATE_DT = mdtmNow                  '更新日時
            objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()              '登録


            '*****************************************************
            '応答電文作成 & 送信
            '*****************************************************
            Dim strResponsText As String            '応答ﾃｷｽﾄ
            strResponsText = ""
            strResponsText &= MCV_ID_DIR_OFFLINE    'ﾃﾞｰﾀﾘﾝｸ確立
            strResponsText &= FRES_CD_EQ_SMCV_OK    '応答ｺｰﾄﾞ
            Call SendResponsData(strResponsText)


            ''*****************************************************
            ''MCV通信ﾛｸﾞ                 受信電文追加
            ''*****************************************************
            ''受信電文ﾛｸﾞ
            'Call AddDBRecvLog_LOG_MCV(MCV_ID_DIR_OFFLINE, _
            '                          MCV_ID_DIR_OFFLINE, _
            '                          strResponsCode _
            '                          )
            ''応答電文ﾛｸﾞ
            'Call AddDBSendResponsLog_LOG_MCV(FCOMMAND_ID_JMCV_RESPONS, _
            '                                 strResponsText, _
            '                                 strResponsCode _
            '                                 )


        Catch ex As Exception
            Call AddToLog(MCIA_MSG_ERR_002 & "[" & strGetData & "]")
            Me.ComError(ex)
            strResponsCode = FRES_CD_EQ_SMCV_ER_FORMAT      '応答ｺｰﾄﾞ
            Dim strResponsText As String                    '応答ﾃｷｽﾄ
            strResponsText = ""
            strResponsText &= Mid(strGetData, 1, 3)         'ｼｰｹﾝｽ№
            strResponsText &= FRES_CD_EQ_SMCV_ER_FORMAT     '応答ｺｰﾄﾞ
            Call SendResponsData(strResponsText)

        End Try
    End Sub
#End Region
#Region "  777 送信側応答受信ｴﾗｰ        受信    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ IN ]strGetData       ：正常に受信できたﾃﾞｰﾀ
    '        [ IN ]strResponsCode   ：応答ｺｰﾄﾞ
    '【戻値】
    '*******************************************************************************************************************
    Private Sub Receive777Process(ByVal strGetData As String, _
                                  ByVal strResponsCode As String)
        Try

            '*****************************************************
            '応答電文作成 & 送信
            '*****************************************************
            Call SendResponsData(mobjEQSendResBuff.FDENBUN)


            ''*****************************************************
            ''MCV通信ﾛｸﾞ                 受信電文追加
            ''*****************************************************
            ''受信電文ﾛｸﾞ
            'Call AddDBRecvLog_LOG_MCV(MCV_ID_DIR_TEL_READ_ERR, _
            '                          MCV_ID_DIR_TEL_READ_ERR, _
            '                          strResponsCode _
            '                          )
            ''応答電文ﾛｸﾞ
            'Call AddDBSendResponsLog_LOG_MCV(FCOMMAND_ID_JMCV_RESPONS, _
            '                                 mobjEQSendResBuff.FDENBUN, _
            '                                 strResponsCode _
            '                                 )


        Catch ex As Exception
            Call AddToLog(MCIA_MSG_ERR_002 & "[" & strGetData & "]")
            Me.ComError(ex)
            strResponsCode = FRES_CD_EQ_SMCV_ER_FORMAT      '応答ｺｰﾄﾞ
            Dim strResponsText As String                    '応答ﾃｷｽﾄ
            strResponsText = ""
            strResponsText &= Mid(strGetData, 1, 3)         'ｼｰｹﾝｽ№
            strResponsText &= FRES_CD_EQ_SMCV_ER_FORMAT     '応答ｺｰﾄﾞ
            Call SendResponsData(strResponsText)

        End Try
    End Sub
#End Region
#Region "  888 文字化け電文受信         受信    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ IN ]strGetData       ：正常に受信できたﾃﾞｰﾀ
    '        [ IN ]strResponsCode   ：応答ｺｰﾄﾞ
    '【戻値】
    '*******************************************************************************************************************
    Private Sub ReceiveDustProcess(ByVal strGetData As String, _
                                   ByVal strResponsCode As String)
        Try

            '*****************************************************
            '応答電文送信
            '*****************************************************
            Call SendResponsData(MCV_ID_DIR_RES_READ_ERR)


            ''*****************************************************
            ''MCV通信ﾛｸﾞ                 受信電文追加
            ''*****************************************************
            ''受信電文ﾛｸﾞ
            'Call AddDBRecvLog_LOG_MCV(MCV_ID_DIR_RES_READ_ERR, _
            '                          strGetData, _
            '                          strResponsCode _
            '                          )
            ''応答電文ﾛｸﾞ
            'Call AddDBSendResponsLog_LOG_MCV(FCOMMAND_ID_JMCV_RESPONS, _
            '                                 MCV_ID_DIR_RES_READ_ERR, _
            '                                 strResponsCode _
            '                                 )


        Catch ex As Exception
            Call AddToLog(MCIA_MSG_ERR_002 & "[" & strGetData & "]")
            Me.ComError(ex)
            strResponsCode = FRES_CD_EQ_SMCV_ER_FORMAT      '応答ｺｰﾄﾞ
            Dim strResponsText As String                    '応答ﾃｷｽﾄ
            strResponsText = ""
            strResponsText &= Mid(strGetData, 1, 3)         'ｼｰｹﾝｽ№
            strResponsText &= FRES_CD_EQ_SMCV_ER_FORMAT     '応答ｺｰﾄﾞ
            Call SendResponsData(strResponsText)

        End Try
    End Sub
#End Region
#Region "  XX  不正ID電文受信           受信    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[ IN ]strGetData       ：正常に受信できたﾃﾞｰﾀ
    '        [ IN ]strResponsCode   ：応答ｺｰﾄﾞ
    '【戻値】
    '*******************************************************************************************************************
    Private Sub XXProcess(ByVal strGetData As String, _
                          ByVal strResponsCode As String)
        Try

            '*****************************************************
            '受信電文分解
            '*****************************************************
            Dim objTel As New clsTelegram(mstrTelConfigPath)
            objTel.FORMAT_ID = FORMAT_MCV_A1                    'ﾌｫｰﾏｯﾄ名ｾｯﾄ        (何でも良い)
            '' ''objTel.FORMAT_ID = MCV_ID_DIR_ONLINE                'ﾌｫｰﾏｯﾄ名ｾｯﾄ        (何でも良い)
            objTel.TELEGRAM_PARTITION = strGetData              '分割する電文ｾｯﾄ
            objTel.PARTITION()                                  '電文分割


            '*****************************************************
            '応答電文作成
            '*****************************************************
            Dim strResponsText As String            '応答ﾃｷｽﾄ
            strResponsCode = IIf(strResponsCode = FRES_CD_EQ_SMCV_OK, FRES_CD_EQ_SMCV_ER_ID, strResponsCode)
            strResponsText = ""
            strResponsText &= objTel.SELECT_HEADER("MCVSEQ_NO")  'ｼｰｹﾝｽNo
            strResponsText &= strResponsCode                         '応答ｺｰﾄﾞ


            '*****************************************************
            '応答電文送信
            '*****************************************************
            Call SendResponsData(strResponsText)


            ''*****************************************************
            ''MCV通信ﾛｸﾞ                 受信電文追加
            ''*****************************************************
            ''受信電文ﾛｸﾞ
            'Call AddDBRecvLog_LOG_MCV(objTel.SELECT_HEADER("MCVID"), _
            '                          strGetData, _
            '                          strResponsCode _
            '                          )
            ''応答電文ﾛｸﾞ
            'Call AddDBSendResponsLog_LOG_MCV(FCOMMAND_ID_JMCV_RESPONS, _
            '                                 strResponsText, _
            '                                 strResponsCode _
            '                                 )


        Catch ex As Exception
            Call AddToLog(MCIA_MSG_ERR_002 & "[" & strGetData & "]")
            Me.ComError(ex)
            strResponsCode = FRES_CD_EQ_SMCV_ER_FORMAT      '応答ｺｰﾄﾞ
            Dim strResponsText As String                    '応答ﾃｷｽﾄ
            strResponsText = ""
            strResponsText &= Mid(strGetData, 1, 3)         'ｼｰｹﾝｽ№
            strResponsText &= FRES_CD_EQ_SMCV_ER_FORMAT      '応答ｺｰﾄﾞ
            Call SendResponsData(strResponsText)

        End Try
    End Sub
#End Region




#Region "  【設備通信ﾛｸﾞ】受信ﾛｸﾞ追加     処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 【設備通信ﾛｸﾞ】受信ﾛｸﾞ追加
    ''' </summary>
    ''' <param name="strFTEXT_ID">ﾃｷｽﾄID</param>
    ''' <param name="strFDENBUN">通信電文</param>
    ''' <param name="strFRES_CD_EQ">設備応答ｺｰﾄﾞ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddDBRecvLog_LOG(ByVal strFTEXT_ID As String _
                              , ByVal strFDENBUN As String _
                              , ByVal strFRES_CD_EQ As String _
                                )

        '========================================
        'DBﾛｸﾞ出力
        '========================================
        Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)
        objTLOG_EQ.FLOG_NO = "1"                            'ﾛｸﾞNo
        objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '設備ID
        objTLOG_EQ.FHASSEI_DT = Now                         '発生日時
        objTLOG_EQ.FDIRECTION = FDIRECTION_SRECV            '方向
        objTLOG_EQ.FTEXT_ID = strFTEXT_ID                   'ﾃｷｽﾄID
        objTLOG_EQ.FDENBUN = strFDENBUN                     '通信ﾃｷｽﾄ
        objTLOG_EQ.FRES_CD_EQ = strFRES_CD_EQ               '応答ｺｰﾄﾞ
        objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '追加


    End Sub
#End Region
#Region "  【搬送制御送信ｲﾝﾀｰﾌｪｰｽ】(通信状態 = 通信中)ﾚｺｰﾄﾞ更新  処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 【搬送制御送信ｲﾝﾀｰﾌｪｰｽ】(通信状態 = 通信中)ﾚｺｰﾄﾞ更新
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub Update_INTCOMM_STS_ACT()
        Dim udtRet As RetCode       '戻値


        '*****************************************************
        '送信ﾊﾞｯﾌｧ検索(通信状態 = 通信中)
        '*****************************************************
        Do
            '(ﾙｰﾌﾟ：(通信状態 = 通信中)のﾚｺｰﾄﾞ数)

            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(mobjOwner, mobjDb, mobjDbLog)
            objTLIF_TRNS_SEND.FEQ_ID = mstrFEQ_ID                               '設備ID
            udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_INTCOMM_STS_ACT()     '送信ﾊﾞｯﾌｧ検索(通信状態 = 通信中)

            If udtRet = RetCode.OK Then
                '(通信開始,通信終了がない かつ 通信異常でない場合)

                '====================================
                '通信状態 = 処理済　更新
                '====================================
                objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SNON                 '通信状態 = 未実施
                objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()                   '更新

                '====================================
                'ﾛｸﾞ出力
                '====================================
                Dim strMessage As String = ""
                strMessage &= "送信中のﾚｺｰﾄﾞが存在した為、再送信します。"
                strMessage &= "       登録No：" & objTLIF_TRNS_SEND.FENTRY_NO
                strMessage &= "      ｺﾏﾝﾄﾞID：" & objTLIF_TRNS_SEND.FCOMMAND_ID
                strMessage &= "     通信ﾃｷｽﾄ：" & objTLIF_TRNS_SEND.FDENBUN
                Call AddToLog(strMessage)

            End If

        Loop While udtRet = RetCode.OK


    End Sub
#End Region
#Region "  【搬送制御送信ｲﾝﾀｰﾌｪｰｽ】進捗状態　      更新処理(送信時用)"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 【搬送制御送信ｲﾝﾀｰﾌｪｰｽ】進捗状態　      更新処理(送信時用)
    ''' </summary>
    ''' <param name="intFPROGRESS">設定する進捗状態</param>
    ''' <param name="strFRES_CD_EQ">設定する設備応答ｺｰﾄﾞ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub UpdateSendFPROGRESS(ByVal intFPROGRESS As Integer _
                                  , Optional ByVal strFRES_CD_EQ As String = Nothing _
                                   )
        Try

            '*****************************************************
            '【搬送制御送信ｲﾝﾀｰﾌｪｰｽ】   更新
            '*****************************************************
            If mobjEQSendTelBuff.FENTRY_NO <> "" And mobjEQSendTelBuff.FENTRY_NO <> FENTRY_NO_SMCI_MYSELF Then
                Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(mobjOwner, mobjDb, mobjDbLog)
                objTLIF_TRNS_SEND.FENTRY_NO = mobjEQSendTelBuff.FENTRY_NO      '登録No     ｾｯﾄ
                objTLIF_TRNS_SEND.FEQ_ID = mobjEQSendTelBuff.FEQ_ID            '設備ID
                objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND(False)                     '情報取得

                objTLIF_TRNS_SEND.FPROGRESS = intFPROGRESS      '進捗状態
                objTLIF_TRNS_SEND.FRES_CD_EQ = strFRES_CD_EQ    '設備応答ｺｰﾄﾞ
                objTLIF_TRNS_SEND.FUPDATE_DT = mdtmNow          '更新日時
                objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()       '更新
            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  【搬送制御送信ｲﾝﾀｰﾌｪｰｽ】設備応答ｺｰﾄﾞ    更新処理(送信時用)"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 【搬送制御送信ｲﾝﾀｰﾌｪｰｽ】設備応答ｺｰﾄﾞ    更新処理(送信時用)
    ''' </summary>
    ''' <param name="strFRES_CD_EQ">設定する設備応答ｺｰﾄﾞ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub UpdateSendFRES_CD_EQ(ByVal strFRES_CD_EQ As String)
        Try

            '*****************************************************
            '【搬送制御送信ｲﾝﾀｰﾌｪｰｽ】   更新
            '*****************************************************
            If mobjEQSendTelBuff.FENTRY_NO <> "" And mobjEQSendTelBuff.FENTRY_NO <> FENTRY_NO_SMCI_MYSELF Then
                Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(mobjOwner, mobjDb, mobjDbLog)
                objTLIF_TRNS_SEND.FENTRY_NO = mobjEQSendTelBuff.FENTRY_NO      '登録No     ｾｯﾄ
                objTLIF_TRNS_SEND.FEQ_ID = mobjEQSendTelBuff.FEQ_ID            '設備ID
                objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND(False)                     '情報取得

                objTLIF_TRNS_SEND.FRES_CD_EQ = strFRES_CD_EQ    '設備応答ｺｰﾄﾞ
                objTLIF_TRNS_SEND.FUPDATE_DT = mdtmNow          '更新日時
                objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()       '更新
            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  【搬送制御受信ｲﾝﾀｰﾌｪｰｽ】追加         処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 【搬送制御受信ｲﾝﾀｰﾌｪｰｽ】追加
    ''' </summary>
    ''' <param name="strFCOMMAND_ID">ｺﾏﾝﾄﾞID</param>
    ''' <param name="strFDENBUN">通信電文</param>
    ''' <param name="strFTEXT_ID">ﾃｷｽﾄID</param>
    ''' <param name="intFPROGRESS">進捗状態</param>
    ''' <param name="intFRES_CD_EQ">設備応答ｺｰﾄﾞ</param>
    ''' <param name="strFDENBUN_PRM1">電文ﾊﾟﾗﾒｰﾀ1</param>
    ''' <param name="strFDENBUN_PRM2">電文ﾊﾟﾗﾒｰﾀ2</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddDBRecvLIF_TRNS_RECV(ByVal strFCOMMAND_ID As String _
                                    , ByVal strFDENBUN As String _
                                    , ByVal strFTEXT_ID As String _
                                    , ByVal intFPROGRESS As String _
                                    , ByVal intFRES_CD_EQ As String _
                                    , ByVal strFDENBUN_PRM1 As String _
                                    , ByVal strFDENBUN_PRM2 As String _
                                      )

        '*****************************************************
        '【搬送制御受信ｲﾝﾀｰﾌｪｰｽ】         追加
        '*****************************************************
        Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)
        objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                   '設備ID
        objTLIF_TRNS_RECV.FCOMMAND_ID = strFCOMMAND_ID          'ｺﾏﾝﾄﾞID
        objTLIF_TRNS_RECV.FTEXT_ID = strFTEXT_ID                'ﾃｷｽﾄID
        objTLIF_TRNS_RECV.FDENBUN_PRM1 = strFDENBUN_PRM1        '電文ﾊﾟﾗﾒｰﾀ1
        objTLIF_TRNS_RECV.FDENBUN_PRM2 = strFDENBUN_PRM2        '電文ﾊﾟﾗﾒｰﾀ2
        objTLIF_TRNS_RECV.FDENBUN = strFDENBUN                  '通信ﾃｷｽﾄ
        objTLIF_TRNS_RECV.FPROGRESS = intFPROGRESS              '進捗状態
        objTLIF_TRNS_RECV.FRES_CD_EQ = intFRES_CD_EQ            '設備応答ｺｰﾄﾞ
        objTLIF_TRNS_RECV.FENTRY_DT = mdtmNow                   '登録日時
        objTLIF_TRNS_RECV.FUPDATE_DT = mdtmNow                  '更新日時
        objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()              '更新
        mblnSockSend = True                                     'ｿｹｯﾄ送信ﾌﾗｸﾞ


    End Sub
#End Region
#Region "  電文送信ﾊﾞｯﾌｧｵﾌﾞｼﾞｪｸﾄにｾｯﾄ           処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 電文送信ﾊﾞｯﾌｧｵﾌﾞｼﾞｪｸﾄにﾃﾞｰﾀｾｯﾄ
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">搬送制御送信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub SetSendBuff(ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND)

        mobjEQSendTelBuff.CLEAR_PROPERTY()
        mobjEQSendTelBuff.FENTRY_NO = objTLIF_TRNS_SEND.FENTRY_NO                  '登録№
        mobjEQSendTelBuff.FEQ_ID = objTLIF_TRNS_SEND.FEQ_ID                        '設備ID
        mobjEQSendTelBuff.FCOMMAND_ID = objTLIF_TRNS_SEND.FCOMMAND_ID              'ｺﾏﾝﾄﾞID
        mobjEQSendTelBuff.FPALLET_ID = objTLIF_TRNS_SEND.FPALLET_ID                'ﾊﾟﾚｯﾄID
        mobjEQSendTelBuff.FTEXT_ID = objTLIF_TRNS_SEND.FTEXT_ID                    'ﾃｷｽﾄID
        mobjEQSendTelBuff.FDENBUN_PRM1 = objTLIF_TRNS_SEND.FDENBUN_PRM1            '電文ﾊﾟﾗﾒｰﾀ1
        mobjEQSendTelBuff.FDENBUN_PRM2 = objTLIF_TRNS_SEND.FDENBUN_PRM2            '電文ﾊﾟﾗﾒｰﾀ2
        mobjEQSendTelBuff.FDENBUN_PRM3 = objTLIF_TRNS_SEND.FDENBUN_PRM3            '電文ﾊﾟﾗﾒｰﾀ3
        mobjEQSendTelBuff.FDENBUN_PRM4 = objTLIF_TRNS_SEND.FDENBUN_PRM4            '電文ﾊﾟﾗﾒｰﾀ4
        mobjEQSendTelBuff.FDENBUN_PRM5 = objTLIF_TRNS_SEND.FDENBUN_PRM5            '電文ﾊﾟﾗﾒｰﾀ5
        mobjEQSendTelBuff.FDENBUN_PRM6 = objTLIF_TRNS_SEND.FDENBUN_PRM6            '電文ﾊﾟﾗﾒｰﾀ6
        mobjEQSendTelBuff.FTRNS_SERIAL = objTLIF_TRNS_SEND.FTRNS_SERIAL            '搬送ｼﾘｱﾙ№(MCｷｰ)
        mobjEQSendTelBuff.FPRIORITY = objTLIF_TRNS_SEND.FPRIORITY                  '優先ﾚﾍﾞﾙ
        mobjEQSendTelBuff.FDENBUN = objTLIF_TRNS_SEND.FDENBUN                      '通信電文
        mobjEQSendTelBuff.FPROGRESS = objTLIF_TRNS_SEND.FPROGRESS                  '進捗状態
        mobjEQSendTelBuff.FRES_CD_EQ = objTLIF_TRNS_SEND.FRES_CD_EQ                '設備応答ｺｰﾄﾞ
        mobjEQSendTelBuff.FOFFLINE_FLAG = objTLIF_TRNS_SEND.FOFFLINE_FLAG          'ｵﾌﾗｲﾝ送信ﾌﾗｸﾞ
        mobjEQSendTelBuff.FENTRY_DT = objTLIF_TRNS_SEND.FENTRY_DT                  '登録日時
        mobjEQSendTelBuff.FUPDATE_DT = objTLIF_TRNS_SEND.FUPDATE_DT                '更新日時

    End Sub
#End Region
#Region "  応答ｺｰﾄﾞが正常か異常か判断               "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 応答ｺｰﾄﾞが正常か異常か判断
    ''' </summary>
    ''' <param name="strRecvText">正常に受信できたﾃﾞｰﾀ</param>
    ''' <returns>搬送制御受信IFﾃｰﾌﾞﾙに追加する設備応答ｺｰﾄﾞ</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function GetFRES_CD_EQ(ByVal strRecvText As String) As String
        Dim strReturn As String = "0"


        ''*****************************************************
        ''受信電文分解
        ''*****************************************************
        'Dim objTel As New clsTelegram(CONFIG_TELEGRAM_BZ)
        'objTel.FORMAT_ID = FORMAT_BZ_HOSTNZ                 'ﾌｫｰﾏｯﾄ名ｾｯﾄ    (特に何でも良い)
        'objTel.TELEGRAM_PARTITION = strRecvText             '分割する電文ｾｯﾄ
        'objTel.PARTITION()                                  '電文分割


        'Dim strFTEXT_ID As String = MakeFTEXT_ID(objTel)      'ﾃｷｽﾄID
        'Select Case strFTEXT_ID
        '    Case FTEXT_ID_JBZ_HOSTNZ _
        '       , FTEXT_ID_JBZ_HOSTSK0 _
        '       , FTEXT_ID_JBZ_HOSTSYU _
        '       , FTEXT_ID_JBZ_HOSTZT
        '        '(応答電文の場合)


        '        strReturn = TO_STRING(objTel.SELECT_HEADER("BZERR_CD"))

        '        Return strReturn
        '    Case Else
        '        '(ありえないが、一応)

        '        Return strReturn
        'End Select


        Return strReturn
    End Function
#End Region
#Region "  通信ﾎｰﾙﾄﾞ        処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 通信ﾎｰﾙﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub CommunicationHold()

        '========================================
        '通信ﾎｰﾙﾄﾞ
        '========================================
        mobjEQSendTelBuff.CLEAR_PROPERTY()         '再送信用ﾃｷｽﾄﾊﾞｯﾌｧ
        mintResponsWait = FLAG_OFF                  '応答待ちﾌﾗｸﾞ   ｾｯﾄ
        mintSendCount = 0                           '再送信回数

    End Sub
#End Region



    '***********************************************
    '↓↓↓↓↓↓送信処理
#Region "  ID:01    ｵﾝﾗｲﾝ要求           送信"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ID:01    ｵﾝﾗｲﾝ要求送信
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">搬送制御送信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <param name="strTelegram">送信する電文</param>
    ''' <returns>正常終了の有無</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function ID01Process(ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND, _
                                 ByRef strTelegram As String _
                                 ) _
                                 As RetCode
        Try
            Dim udtRet As RetCode


            ''*****************************************************
            ''ｺﾏﾝﾄﾞIDｾｯﾄ
            ''*****************************************************
            'mobjEQSendTelBuff.LOG_FCOMMAND_ID = MCV_ID_DIR_ONLINE


            '*****************************************************
            '電文作成
            '*****************************************************
            strTelegram = ""
            strTelegram &= MCV_ID_DIR_ONLINE


            '*****************************************************
            '色々初期化
            '*****************************************************
            Call SetSYS_HEN(mFHENSU_IDSeqNoSend, 0)     '送信ｼｰｹﾝｽNo = 0


            Return udtRet
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
#Region "  ID:02    ｵﾌﾗｲﾝ要求           送信"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ID:02    ｵﾌﾗｲﾝ要求送信
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">搬送制御送信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <param name="strTelegram">送信する電文</param>
    ''' <returns>正常終了の有無</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function ID02Process(ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND, _
                                 ByRef strTelegram As String _
                                 ) _
                                 As RetCode
        Try
            Dim udtRet As RetCode


            ''*****************************************************
            ''ｺﾏﾝﾄﾞIDｾｯﾄ
            ''*****************************************************
            'mobjEQSendTelBuff.LOG_FCOMMAND_ID = MCV_ID_DIR_OFFLINE


            '*****************************************************
            '電文作成
            '*****************************************************
            strTelegram = ""
            strTelegram &= MCV_ID_DIR_OFFLINE


            '*****************************************************
            '色々初期化
            '*****************************************************
            Call SetSYS_HEN(mFHENSU_IDSeqNoSend, 1) 'ｼｰｹﾝｽNo = 1


            Return udtRet
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
#Region "  ID:**    電文送信            送信"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ID:**    電文送信
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">搬送制御送信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <param name="strTelegram">送信する電文</param>
    ''' <returns>正常終了の有無</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function IDZZProcess(ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND, _
                                 ByRef strTelegram As String _
                                 ) _
                                 As RetCode
        Try


            '*****************************************************
            '電文作成
            '*****************************************************
            strTelegram = ""
            strTelegram &= ZERO_PAD(GetSYS_HEN(mFHENSU_IDSeqNoSend), 3)
            strTelegram &= MID_SJIS(objTLIF_TRNS_SEND.FDENBUN, 4)


            Return RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
    '↑↑↑↑↑↑送信処理
    '***********************************************


End Class
