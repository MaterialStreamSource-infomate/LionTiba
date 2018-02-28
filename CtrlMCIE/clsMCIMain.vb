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
    Private mobjSerial As clsSerial                     'ｼﾘｱﾙ通信ｵﾌﾞｼﾞｪｸﾄ
    Private mobjEQSendTelBuff As TBL_TLIF_TRNS_SEND     '電文送信ﾊﾞｯﾌｧ
    'Private mobjEQSendResBuff As TBL_TLIF_TRNS_SEND    '応答電文送信ﾊﾞｯﾌｧ
    Private mobjGetTelegram As clsGetTelegram           '電文用ﾃｷｽﾄ取得ｸﾗｽ

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

#End Region

    '***********************************************
    '↓↓↓↓↓↓毎回必要
#Region "  共通変数             "

    '==================================================
    '共通ｵﾌﾞｼﾞｪｸﾄ
    '==================================================
    Private mobjOwner As Object                                 'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    'Private mobjDb As clsConn                                   'ｵﾗｸﾙ接続ｵﾌﾞｼﾞｪｸﾄ
    'Private mobjDbLog As clsConn                                'ｵﾗｸﾙ接続ｵﾌﾞｼﾞｪｸﾄ
    'Private mobjTPRG_SYS_HEN As TBL_TPRG_SYS_HEN                'ｼｽﾃﾑ変数
    'Private mobjSockSvr As clsSocketToServer                    'ｻｰﾊﾞｰへｿｹｯﾄ送信ｸﾗｽ
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
            'mobjDb.BeginTrans()     'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            Try
                'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


                '*****************************************************
                '色々初期化
                '*****************************************************
                mdtmNow = Now


                '*****************************************************
                'DB送信ﾊﾞｯﾌｧ検索 & 電文送信     処理
                '*****************************************************
                Call MCIA_100001(True)


                '*****************************************************
                '電文受信確認
                '*****************************************************
                Dim strRecvText As String = ""          '受信電文
                Call RecvDataEQ(strRecvText)


                ''*****************************************************
                ''電文受信       処理
                ''*****************************************************
                'Call MCIA_100002(strRecvText)


                '*****************************************************
                'ｻｰﾊﾞへｿｹｯﾄ送信
                '*****************************************************
                Call MCI_000001()


            Catch ex As Exception
                Call ComError(ex)

            Finally
                'mobjDb.Commit()     'ｺﾐｯﾄ

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


            ''*****************************************************
            '' ｵﾗｸﾙ接続
            ''*****************************************************
            'mobjDb = objDb
            'mobjDbLog = objDbLog


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


        ''*****************************************************
        '' 【ｼｽﾃﾑ変数】     接続ｸﾗｽ作成
        ''*****************************************************
        'mobjTPRG_SYS_HEN = New TBL_TPRG_SYS_HEN(mobjOwner, mobjDb, mobjDbLog)


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
        Dim objConfig As New clsConnectConfig(CONFIG_MCIE)                              'Configﾌｧｲﾙ接続ｸﾗｽ生成

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


        ''*****************************************************
        ''ｻｰﾊﾞｰｿｹｯﾄ送信ｵﾌﾞｼﾞｪｸﾄ  生成
        ''*****************************************************
        'mobjSockSvr = New clsSocketToServer(mobjOwner)
        'mobjSockSvr.objOwner = mobjOwner                        'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
        'mobjSockSvr.strTermID = mstrSvrSockSendTermID           'ｻｰﾊﾞ端末ID
        'mobjSockSvr.strEmpCD = mstrSvrSockSendUserID            'ｻｰﾊﾞﾕｰｻﾞｰID
        'mobjSockSvr.strAddress = mstrSvrSockSendAddress         'ｻｰﾊﾞ送信先ｱﾄﾞﾚｽ
        'mobjSockSvr.intPortNo = mintSvrSockSendPort             'ｻｰﾊﾞ送信先ﾎﾟｰﾄNo
        'mobjSockSvr.intTimeout = mintSvrSockSendTimeOut         'ｻｰﾊﾞ応答ｿｹｯﾄ待機時間
        'mobjSockSvr.strTelFilePath = CONFIG_TELEGRAM_DSP        '読み込む定義ﾌｧｲﾙのﾊﾟｽ


        '**********************************************************************************************************************
        '↓↓↓↓固有部分


        '*****************************************************
        'ﾃﾞﾘﾐﾀ設定
        '*****************************************************
        mobjGetTelegram.strSTX = mobjASCII.strSTX
        mobjGetTelegram.strETX = mobjASCII.strETX


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


            ''***********************************
            ''搬送制御受信IF 追加
            ''***********************************
            'Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)
            'objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                           '設備ID
            'objTLIF_TRNS_RECV.FCOMMAND_ID = FCOMMAND_ID_SADD_MSG             'ｺﾏﾝﾄﾞID
            'objTLIF_TRNS_RECV.FDENBUN_PRM1 = strFMSG_ID                     'ﾒｯｾｰｼﾞID
            'objTLIF_TRNS_RECV.FDENBUN_PRM2 = strFMSG_PRM1                   'ﾊﾟﾗﾒｰﾀ1
            'objTLIF_TRNS_RECV.FDENBUN_PRM3 = strFMSG_PRM2                   'ﾊﾟﾗﾒｰﾀ2
            'objTLIF_TRNS_RECV.FDENBUN_PRM4 = strFMSG_PRM3                   'ﾊﾟﾗﾒｰﾀ3
            'objTLIF_TRNS_RECV.FDENBUN_PRM5 = strFMSG_PRM4                   'ﾊﾟﾗﾒｰﾀ4
            'objTLIF_TRNS_RECV.FDENBUN_PRM6 = strFMSG_PRM5                   'ﾊﾟﾗﾒｰﾀ5
            'objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SEND                     '進捗状態
            ' '' ''      objTLIF_TRNS_RECV.FRES_CD_EQ = FORMAT_PLC_RES_CD_OK             '設備応答ｺｰﾄﾞ
            'objTLIF_TRNS_RECV.FENTRY_DT = Now                               '登録日時
            'objTLIF_TRNS_RECV.FUPDATE_DT = Now                              '更新日時
            'objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()                      '追加
            'mblnSockSend = True                                             'ｿｹｯﾄ送信ﾌﾗｸﾞ


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


            ''***********************************
            ''搬送制御受信IF 追加
            ''***********************************
            'Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)
            'objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                           '設備ID
            'objTLIF_TRNS_RECV.FCOMMAND_ID = FCOMMAND_ID_SCUT_EQ              'ｺﾏﾝﾄﾞID
            'objTLIF_TRNS_RECV.FDENBUN_PRM1 = mstrFEQ_ID                     'ﾒｯｾｰｼﾞID
            'objTLIF_TRNS_RECV.FDENBUN_PRM2 = Nothing                        'ﾊﾟﾗﾒｰﾀ1
            'objTLIF_TRNS_RECV.FDENBUN_PRM3 = Nothing                        'ﾊﾟﾗﾒｰﾀ2
            'objTLIF_TRNS_RECV.FDENBUN_PRM4 = Nothing                        'ﾊﾟﾗﾒｰﾀ3
            'objTLIF_TRNS_RECV.FDENBUN_PRM5 = Nothing                        'ﾊﾟﾗﾒｰﾀ4
            'objTLIF_TRNS_RECV.FDENBUN_PRM6 = Nothing                        'ﾊﾟﾗﾒｰﾀ5
            'objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SEND                     '進捗状態
            ' '' ''      objTLIF_TRNS_RECV.FRES_CD_EQ = FORMAT_PLC_RES_CD_OK             '設備応答ｺｰﾄﾞ
            'objTLIF_TRNS_RECV.FENTRY_DT = Now                               '登録日時
            'objTLIF_TRNS_RECV.FUPDATE_DT = Now                              '更新日時
            'objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()                      '追加
            'mblnSockSend = True                                             'ｿｹｯﾄ送信ﾌﾗｸﾞ


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
                    'mobjDb.Commit()                                             'ｺﾐｯﾄ
                    'mobjDb.BeginTrans()                                         'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
                    objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S210001   'ﾌｫｰﾏｯﾄ名ｾｯﾄ
                    'Call mobjSockSvr.SockSendServer(objTelegram)                'ｿｹｯﾄ送信
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
    ''' ﾃﾞｰﾀ送信
    ''' </summary>
    ''' <param name="strSendText">送信ﾃｷｽﾄ</param>
    ''' <param name="objTLIF_TRNS_SEND">搬送制御送信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <returns>正常終了の有無</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function SendDataEQ(ByVal strSendText As String _
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
            Dim blnSendSuccess As Boolean = False       '電文送信成功ﾌﾗｸﾞ
            For II As Integer = 1 To mintSendRetry
                '(ﾙｰﾌﾟ:ﾘﾄﾗｲ回数)

                mobjSerial.bytSendText = mobjGetTelegram.MakeTelegramSTXETXBCC01(strSendText)

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

            '===========================================
            'ﾃｷｽﾄID取得
            '===========================================
            Dim strFTEXT_ID As String = ""
            strFTEXT_ID = MID_SJIS(strSendText, 1, 16)

            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
            If mobjEQSendTelBuff.FENTRY_NO <> FENTRY_NO_SMCI_MYSELF Then
                '↑↑↑↑↑↑************************************************************************************************************
                'Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)   '設備通信ﾛｸﾞ
                'objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '設備ID
                'objTLOG_EQ.FHASSEI_DT = Now                         '発生日時
                'objTLOG_EQ.FDIRECTION = FDIRECTION_SSEND             '方向
                'objTLOG_EQ.FTEXT_ID = objTLIF_TRNS_SEND.FTEXT_ID    'ﾃｷｽﾄID
                'objTLOG_EQ.FTRNS_SERIAL = DEFAULT_STRING            '搬送ｼﾘｱﾙ№
                'objTLOG_EQ.FPALLET_ID = DEFAULT_STRING              'ﾊﾟﾚｯﾄID
                'objTLOG_EQ.FDENBUN = strSendText                    '通信電文
                'objTLOG_EQ.FRES_CD_EQ = DEFAULT_STRING              '設備応答ｺｰﾄﾞ
                'objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '追加
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
        '電文受信
        '****************************************
        mobjSerial.Receive()


        '****************************************
        '電文部分を抽出 & 受信ﾊﾞｯﾌｧ更新
        '****************************************
        If IsNotNull(mobjSerial.strRecvText) Then
            '(電文を受信した場合)


            '****************************************
            '受信ﾊﾞｯﾌｧに結合
            '****************************************
            If IsNull(mstrRecvTelBuff) Then
                mstrRecvTelBuff = mobjSerial.strRecvText
            Else
                mstrRecvTelBuff &= mobjSerial.strRecvText
            End If


            '****************************************
            '電文部分を抽出 & 受信ﾊﾞｯﾌｧ更新
            '****************************************
            Call AddToDebugLog(MCIA_MSG_011 & mobjASCII.GetLogString(mstrRecvTelBuff))
            mstrRecvTelBuff = ""
            'strRecvText = mobjGetTelegram.GetTelegramSTXETX(mstrRecvTelBuff)
            'If IsNotNull(strRecvText) Then
            '    Call AddToLog(MCIA_MSG_011 & strRecvText) '電文取得ﾛｸﾞ出力
            'End If

        End If


    End Sub
#End Region



    '*******************
    'Private
    '*******************
#Region "  MCIA_100001  DB検索 & 電文送信       処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' DB検索 ＆ 電文送信
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_100001(ByVal blnCheck As Boolean)
        'Private Sub MCIA_100001()
        'Try
        '    Dim udtRet As RetCode



        '    '*****************************************************
        '    '応答ﾌﾗｸﾞﾁｪｯｸ
        '    '*****************************************************
        '    If mintResponsWait = FLAG_ON Then
        '        '(応答ﾌﾗｸﾞ = ON の場合)
        '        Exit Sub
        '    End If


        '    '↓↓↓↓↓↓************************************************************************************************************
        '    'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
        '    If blnCheck = True Then
        '        '↑↑↑↑↑↑************************************************************************************************************


        '        '*****************************************************
        '        'ﾀｲﾏｰ処理
        '        '*****************************************************
        '        Dim objDiff As TimeSpan = mdtmBeforeDBTime.AddMilliseconds(mintDBReadTimer) - Now
        '        If 0 < objDiff.TotalMilliseconds Then
        '            Exit Sub
        '        End If
        '        mdtmBeforeDBTime = Now


        '        '↓↓↓↓↓↓************************************************************************************************************
        '        'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
        '    End If
        '    '↑↑↑↑↑↑************************************************************************************************************


        '    '*****************************************************
        '    '電文送信
        '    '*****************************************************
        '    If udtRet = RetCode.OK And strTelegram <> "" Then
        '        udtRet = SendDataEQ(strTelegram, objTLIF_TRNS_SEND)    '電文送信
        '        mintSendCount = 1                                       '送信回数(一回目)
        '    End If


        '    '*****************************************************
        '    'ﾃｷｽﾄ送信結果により処理変更
        '    '*****************************************************
        '    '共通
        '    Select Case udtRet
        '        Case RetCode.OK
        '            '=========================================
        '            '正常
        '            '=========================================
        '            Select Case objTLIF_TRNS_SEND.FTEXT_ID
        '                Case "xxxx" 
        '                    '(応答ありの場合)
        '                    Call UpdateSendFPROGRESS(FPROGRESS_SACT)             '搬送制御送信ｲﾝﾀｰﾌｪｰｽ.通信状態      ｾｯﾄ
        '                    'mblnSockSend = True                                 'ｿｹｯﾄ送信ﾌﾗｸﾞ
        '                    mintResponsWait = FLAG_ON                           '応答待ちﾌﾗｸﾞ                       ｾｯﾄ
        '                Case Else
        '                    '(応答なしの場合)
        '                    Call UpdateSendFPROGRESS(FPROGRESS_SEND)             '搬送制御送信ｲﾝﾀｰﾌｪｰｽ.通信状態      ｾｯﾄ
        '                    mblnSockSend = True                                 'ｿｹｯﾄ送信ﾌﾗｸﾞ
        '                    mintResponsWait = FLAG_OFF                          '応答待ちﾌﾗｸﾞ                       ｾｯﾄ
        '                    Call InitializeDBReadTimer()                        '続けてDB検索処理
        '            End Select

        '        Case Else
        '            '=========================================
        '            '異常
        '            '=========================================
        '            Call UpdateSendFPROGRESS(FPROGRESS_SERR_MCI)         '搬送制御送信ｲﾝﾀｰﾌｪｰｽ.通信状態      ｾｯﾄ
        '            mintResponsWait = FLAG_OFF                          '応答待ちﾌﾗｸﾞ                       ｾｯﾄ
        '            '' ''Call SeqNoSendUpdate()                         'ｼｰｹﾝｽNo + 1                        ｾｯﾄ
        '            Call mobjEQSendTelBuff.CLEAR_PROPERTY()            '送信ﾊﾞｯﾌｧ                          削除

        '            'ﾛｸﾞ出力
        '            Dim strMessage As String = ""
        '            strMessage &= "ｴﾗｰが発生した為、次のﾚｺｰﾄﾞの処理は実行出来ませんでした。"
        '            strMessage &= "[登録№:" & objTLIF_TRNS_SEND.FENTRY_NO & "]"
        '            strMessage &= "[設備ID:" & objTLIF_TRNS_SEND.FEQ_ID & "]"
        '            strMessage &= "[ｺﾏﾝﾄﾞID:" & objTLIF_TRNS_SEND.FCOMMAND_ID & "]"
        '            strMessage &= "[ﾊﾟﾗﾒｰﾀ1:" & objTLIF_TRNS_SEND.FDENBUN_PRM1 & "]"
        '            strMessage &= "[ﾊﾟﾗﾒｰﾀ2:" & objTLIF_TRNS_SEND.FDENBUN_PRM2 & "]"
        '            strMessage &= "[ﾊﾟﾗﾒｰﾀ3:" & objTLIF_TRNS_SEND.FDENBUN_PRM3 & "]"
        '            strMessage &= "[ﾊﾟﾗﾒｰﾀ4:" & objTLIF_TRNS_SEND.FDENBUN_PRM4 & "]"
        '            strMessage &= "[ﾊﾟﾗﾒｰﾀ5:" & objTLIF_TRNS_SEND.FDENBUN_PRM5 & "]"
        '            Call AddToLog(strMessage)

        '    End Select


        'Catch ex As Exception
        '    ComError(ex)

        'End Try
    End Sub
#End Region
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
            Dim objTel As New clsTelegram(CONFIG_TELEGRAM_BCR)
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

            'Call AddDBRecvLog_LOG(strFTEXT_ID _
            '                    , strRecvText _
            '                    , "" _
            '                    )

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


            ''*****************************************************
            ''【搬送制御送受信ｲﾝﾀｰﾌｪｰｽ】   追加
            ''*****************************************************
            ''↓↓↓↓↓↓************************************************************************************************************
            ''SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
            'If blnLogAdd = True Then
            '    '↑↑↑↑↑↑************************************************************************************************************

            '    Call AddDBRecvLIF_TRNS_RECV(FCOMMAND_ID_SOT _
            '                                  , strRecvText _
            '                                  , strFTEXT_ID _
            '                                  , FPROGRESS_SEND _
            '                                  , intFRES_CD_EQ _
            '                                  , strFDENBUN_PRM1 _
            '                                  , strFDENBUN_PRM2 _
            '                                  )

            '    '↓↓↓↓↓↓************************************************************************************************************
            '    'SystemMate:N.Dounoshita 2012/05/08  定周期問い合わせの標準化
            'End If
            ''↑↑↑↑↑↑************************************************************************************************************


        Catch ex As Exception
            ComError(ex)

        End Try
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

            mstrRecvTelBuff = ""                    '受信ﾊﾞｯﾌｧ


            Return RetCode.OK
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


            ''*****************************************************
            ''ﾍｯﾀﾞ部分作成
            ''*****************************************************
            'Dim strHeader As String = ""
            'strHeader = GetSendHeaderText(objTLIF_TRNS_SEND)


            ''*****************************************************
            ''電文作成
            ''*****************************************************
            'strTelegram = ""
            'strTelegram &= strHeader
            'strTelegram &= TO_STRING(GetSYS_HEN(FHENSU_ID_MCIA_END_KUBUN))


            Return RetCode.OK
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
            strTelegram &= objTLIF_TRNS_SEND.FDENBUN


            Return RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
    '↑↑↑↑↑↑送信処理
    '    '***********************************************


End Class
