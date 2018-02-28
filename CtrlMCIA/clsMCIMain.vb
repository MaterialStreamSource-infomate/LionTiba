'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】MCIﾒｲﾝｸﾗｽ(安川PLC通信)
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
    Private mobjPLC As ComPLCYaskawa.clsPLC             '安川PLCｵﾌﾞｼﾞｪｸﾄ
    Private mobjEQSendTelBuff As TBL_TLIF_TRNS_SEND     '電文送信ﾊﾞｯﾌｧ
    'Private mobjEQSendResBuff As TBL_TLIF_TRNS_SEND    '応答電文送信ﾊﾞｯﾌｧ
    Private mobjGetTelegram As clsGetTelegram           '電文用ﾃｷｽﾄ取得ｸﾗｽ
    Private mobjAryTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL     '設備状況


    '==================================================
    '内部変数
    '==================================================
    'ﾚｼﾞｽﾀ関係
    Private mintNRegD(REG_MAX) As Integer                   'Dﾚｼﾞｽﾀ値配列
    Private mintBRegD(REG_MAX) As Integer                   'Dﾚｼﾞｽﾀ値配列(前回値)
    Private mintRegDBuff(REG_MAX) As Object                 'Dﾚｼﾞｽﾀ値配列(書込ｴﾘｱﾊﾞｯﾌｧ)
    Private mblnConnect As Boolean                          '接続ﾌﾗｸﾞ
    Private mblnOnline As Boolean                           'ｵﾝﾗｲﾝﾌﾗｸﾞ
    Private mdtmConnectBefore As Date                       '最終接続確認日付時間
    Private mdtmBeforeOnline As Date                        '前回ｵﾝﾗｲﾝﾁｪｯｸ時間

    'その他
    Private mintSendCount As Integer            '再送信回数
    Private mdtmBeforeRecvTime As Date          '前回受信日時
    Private mdtmBeforeSendTime As Date          '前回送信日時
    Private mstrRecvTelBuff As String           '受信ﾊﾞｯﾌｧ
    Private mintResponsWait As Integer          '応答待ちﾌﾗｸﾞ
    Private mdtmBeforeConnTime As Date          '前回接続日時
    'Private mblnConnect As Boolean              'ｿｹｯﾄ接続ﾌﾗｸﾞ
    Private mdtmEQ_Send02Timer_Before As Date   '前回定周期問い合わせ時間02


    Private Const REG_START As Integer = 40001
    Private Const REG_MAX As Integer = REG_START + REG_COUNT_MAX
    Private Const REG_COUNT_MAX As Integer = 65535

    '==================================================
    'Config
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
    Private mintEQ_Send02Timer As Integer           '定周期問い合わせ周期02(ms)

    'その他
    Private mintPLCSlaveAdrs As Integer             '通信対象となるPLCのｽﾚｰﾌﾞｱﾄﾞﾚｽ
    Private mintConnectTimer As Integer             '再接続周期 (ms)


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
            If IsNotNull(mobjPLC) Then mobjPLC.intDebugFlag = Value 'ｼﾘｱﾙ通信ｸﾗｽ
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
                'ｵﾝﾗｲﾝﾁｪｯｸ
                '*****************************************************
                Call MCIA_200004()
                If mblnOnline = False Then Exit Sub


                '*****************************************************
                'ﾚｼﾞｽﾀ読込
                '*****************************************************
                Call UpdateReadArray()      '読込ﾚｼﾞｽﾀ配列更新
                If mblnConnect = False Then Exit Sub


                '*****************************************************
                'ｲﾍﾞﾝﾄ通知処理
                '*****************************************************
                Call MCIA_200001()


                '*****************************************************
                'ﾚｼﾞｽﾀ値配列(前回値)へｺﾋﾟｰ
                '*****************************************************
                Call CopyRegR()


                '*****************************************************
                'DB送信ﾊﾞｯﾌｧ検索 & 電文送信     処理
                '*****************************************************
                Call MCIA_100001(True)
                'Call WriteArrayWrite()      '書込ﾚｼﾞｽﾀ配列書込み


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
#Region "  ﾒｲﾝ処理_Backup       "
    ''''*******************************************************************************************************************
    '''' <summary>
    '''' ﾒｲﾝ処理
    '''' </summary>
    '''' <remarks></remarks>
    ''''*******************************************************************************************************************
    'Public Overridable Sub Main()
    '    Try
    '        mobjDb.BeginTrans()     'ﾄﾗﾝｻﾞｸｼｮﾝ開始
    '        Try
    '            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


    '            '*****************************************************
    '            '色々初期化
    '            '*****************************************************
    '            mdtmNow = Now


    '            '*****************************************************
    '            'DB送信ﾊﾞｯﾌｧ検索 & 電文送信     処理
    '            '*****************************************************
    '            Call MCIA_100001(True)


    '            '*****************************************************
    '            '電文受信確認
    '            '*****************************************************
    '            Dim strRecvText As String = ""          '受信電文
    '            Call RecvDataEQ(strRecvText)


    '            ''*****************************************************
    '            ''電文受信       処理
    '            ''*****************************************************
    '            'Call MCIA_100002(strRecvText)


    '            '*****************************************************
    '            'ｻｰﾊﾞへｿｹｯﾄ送信
    '            '*****************************************************
    '            Call MCI_000001()


    '        Catch ex As Exception
    '            Call ComError(ex)

    '        Finally
    '            mobjDb.Commit()     'ｺﾐｯﾄ

    '        End Try
    '    Catch ex As Exception
    '        Call ComError(ex)

    '    End Try
    'End Sub
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
        Dim intRet As RetCode


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
        Dim objConfig As New clsConnectConfig(CONFIG_MCIA)                              'Configﾌｧｲﾙ接続ｸﾗｽ生成

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
        'その他
        mintPLCSlaveAdrs = TO_INTEGER(objConfig.GET_INFO(GKEY_MCI_PLCSLAVEADRS))        '通信対象となるPLCのｽﾚｰﾌﾞｱﾄﾞﾚｽ
        mintConnectTimer = TO_INTEGER(objConfig.GET_INFO(GKEY_MCI_CONNECT_TIMER))       '再接続周期 (ms)
        mintEQ_Send02Timer = TO_INTEGER(objConfig.GET_INFO(GKEY_MCI_EQ_SEND02_TIMER))   'RTNﾄﾗｯｷﾝｸﾞ問い合わせ周期(ms)


        '****************************************************
        '安川PLC通信ｸﾗｽ     生成
        '****************************************************
        mobjPLC = New ComPLCYaskawa.clsPLC(mobjOwner)               '安川PLC通信ｸﾗｽ
        mobjPLC.strCOMRecvPort = mstrCOMRecvPort                    'ﾎﾟｰﾄ番号
        mobjPLC.intCOMRecvBaud = mintCOMRecvBaud                    '通信速度
        mobjPLC.strCOMRecvParity = mstrCOMRecvParity                'ﾊﾟﾘﾃｨ
        mobjPLC.intCOMRecvDataLength = mintCOMRecvDataLength        'ﾃﾞｰﾀ長
        mobjPLC.strCOMRecvStopBit = mstrCOMRecvStopBit              'ｽﾄｯﾌﾟﾋﾞｯﾄ長
        mobjPLC.intCOMCodePage = mintCOMCodePage                    '通信に使用するﾃｷｽﾄのｺｰﾄﾞ  (932:ShiftJIS)
        mobjPLC.strCOMComName = mstrCOMComName                      '通信名
        mobjPLC.intSendTimeout = mintSendTimeout                    '送信ﾀｲﾑｱｳﾄ(ms)
        mobjPLC.intSendRetry = mintSendRetry                        '送信ﾘﾄﾗｲ回数
        mobjPLC.intDebugFlag = mintDebugFlag                        'ﾃﾞﾊﾞｯｸﾞﾌﾗｸﾞ
        mobjPLC.Open()                                              '通信確立


        '****************************************************
        'MCIｲﾍﾞﾝﾄ通知ﾏｽﾀ        取得
        '****************************************************
        Dim strSQL As String = ""
        strSQL &= " SELECT "
        strSQL &= "    * "
        strSQL &= " FROM "
        strSQL &= "    TSTS_EQ_CTRL "
        strSQL &= " WHERE "
        strSQL &= "       SUBSTR(FEQ_ID_LOCAL, 1, 3) = 'Y" & MID_SJIS(mstrFEQ_ID, 7, 2) & "' "
        strSQL &= "   AND XEVENT_FLAG = " & TO_STRING(XEVENT_FLAG_JON)
        strSQL &= " ORDER BY "
        strSQL &= "    FEQ_ID_LOCAL "
        mobjAryTSTS_EQ_CTRL = New TBL_TSTS_EQ_CTRL(mobjOwner, mobjDb, mobjDbLog)
        mobjAryTSTS_EQ_CTRL.USER_SQL = strSQL
        intRet = mobjAryTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL_USER()
        If intRet <> RetCode.OK Then
            '(見つからなかった場合)
            Throw New Exception(ERRMSG_NOTFOUND_TSTS_EQ_CTRL)
        End If


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
    Public Sub AddToManyLog(ByVal strMsg_1 As String)

        If intDebugFlag = 0 Then
            mobjOwner.AddToManyLog(strMsg_1)
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
        mobjPLC.strCOMRecvPort = mstrCOMRecvPort                    'ﾎﾟｰﾄ番号
        mobjPLC.intCOMRecvBaud = mintCOMRecvBaud                    '通信速度
        mobjPLC.strCOMRecvParity = mstrCOMRecvParity                'ﾊﾟﾘﾃｨ
        mobjPLC.intCOMRecvDataLength = mintCOMRecvDataLength        'ﾃﾞｰﾀ長
        mobjPLC.strCOMRecvStopBit = mstrCOMRecvStopBit              'ｽﾄｯﾌﾟﾋﾞｯﾄ長
        mobjPLC.intCOMCodePage = mintCOMCodePage                    '通信に使用するﾃｷｽﾄのｺｰﾄﾞ  (932:ShiftJIS)
        mobjPLC.strCOMComName = mstrCOMComName                      '通信名
        mobjPLC.Open()                                              '通信確立


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
            mobjPLC.Close()                                          '通信確立


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
        Dim intReturn As ComPLCYaskawa.clsPLC.RetCode = ComPLCYaskawa.clsPLC.RetCode.NG                   '関数戻値


        '***************************************
        'ﾚｼﾞｽﾀ読込
        '***************************************
        intReturn = mobjPLC.AreaRead(bytSlaveAdrs, intAdrs, intSize, intData)           '配列取得


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


        '***************************************
        'ﾚｼﾞｽﾀ書込
        '***************************************
        intReturn = mobjPLC.AreaWrite(bytSlaveAdrs, intAdrs, intData)               '配列取得


        Return intReturn
    End Function
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
        Try
            Dim udtRet As RetCode



            '*****************************************************
            '応答ﾌﾗｸﾞﾁｪｯｸ
            '*****************************************************
            If mintResponsWait = FLAG_ON Then
                '(応答ﾌﾗｸﾞ = ON の場合)
                Exit Sub
            End If


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
            '==========================================
            '【設備状態】   ｵﾝﾗｲﾝ確認
            '==========================================
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(mobjOwner, mobjDb, mobjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID = mstrFEQ_ID                 'MCIｺﾈｸｼｮﾝ
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(False)             '取得
            If TO_INTEGER(objTSTS_EQ_CTRL.FEQ_CUT_STS) = FLAG_OFF _
               And TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS) = FEQ_STS_SMCI_ONLINE Then
                '(「MCI」 = 「ｵﾝﾗｲﾝ」の場合)

                objTLIF_TRNS_SEND.FEQ_ID = mstrFEQ_ID
                udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_LATEST_ANY()      '送信ﾊﾞｯﾌｧ検索
                'udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_LATEST()      '送信ﾊﾞｯﾌｧ検索
                If udtRet <> RetCode.OK Then
                    '(送信ﾊﾞｯﾌｧにﾃﾞｰﾀがない場合)
                    Exit Sub            '脱出
                End If

            Else
                '(「MCI」 = 「ｵﾌﾗｲﾝ」の場合)

                objTLIF_TRNS_SEND.FEQ_ID = mstrFEQ_ID
                udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_LATEST_FOFFLINE_FLAG()       '送信ﾊﾞｯﾌｧ検索(ｵﾌﾗｲﾝﾌﾗｸﾞ=FLAG_ONのみ)
                If udtRet <> RetCode.OK Then
                    '(送信ﾊﾞｯﾌｧにﾃﾞｰﾀがない場合)
                    Exit Sub            '脱出
                End If
            End If
            'Call SetSendBuff(objTLIF_TRNS_SEND)


            '*****************************************************
            'IDによって分岐 & ﾃｷｽﾄ送信
            '*****************************************************
            For ii As Integer = LBound(objTLIF_TRNS_SEND.ARYME) To UBound(objTLIF_TRNS_SEND.ARYME)
                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ件数)


                Dim objTempTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND = objTLIF_TRNS_SEND.ARYME(ii)
                Dim strTelegram As String = ""          '送信電文
                Call SetSendBuff(objTempTLIF_TRNS_SEND)
                Select Case objTempTLIF_TRNS_SEND.FCOMMAND_ID
                    Case FCOMMAND_ID_SONLINE             'ｵﾝﾗｲﾝ要求
                        udtRet = ID01Process(objTempTLIF_TRNS_SEND, strTelegram)

                    Case FCOMMAND_ID_SOFFLINE            'ｵﾌﾗｲﾝ要求
                        udtRet = ID02Process(objTempTLIF_TRNS_SEND, strTelegram)

                    Case FCOMMAND_ID_SWRITE_REG_WORD
                        '(ﾚｼｽﾞﾀ書込要求(ﾜｰﾄﾞ対応))
                        udtRet = ID0101Process(objTempTLIF_TRNS_SEND)

                    Case FCOMMAND_ID_SWRITE_REG_BIT
                        '(ﾚｼｽﾞﾀ書込要求(ﾋﾞｯﾄ対応))
                        udtRet = ID0102Process(objTempTLIF_TRNS_SEND)

                    Case FCOMMAND_ID_JREAD_REG_ALL
                        '(ﾚｼｽﾞﾀ読込要求(全ﾚｼﾞｽﾀ))
                        udtRet = ID0201Process(objTempTLIF_TRNS_SEND)

                    Case FCOMMAND_ID_SSQL                'SQL実行
                        udtRet = IDSQLProcess(objTempTLIF_TRNS_SEND)
                        Exit Sub

                    Case Else                           'その他
                        udtRet = IDZZProcess(objTempTLIF_TRNS_SEND, strTelegram)

                End Select


                '*****************************************************
                '電文送信
                '*****************************************************
                If udtRet = RetCode.OK And strTelegram <> "" Then
                    udtRet = SendDataEQ(strTelegram, objTLIF_TRNS_SEND)    '電文送信
                    mintSendCount = 1                                       '送信回数(一回目)
                End If


                '*****************************************************
                'ﾃｷｽﾄ送信結果により処理変更
                '*****************************************************
                '共通
                Select Case udtRet
                    Case RetCode.OK
                        '=========================================
                        '正常
                        '=========================================
                        Select Case objTempTLIF_TRNS_SEND.FTEXT_ID
                            Case "xxxx"
                                '(応答ありの場合)
                                Call UpdateSendFPROGRESS(FPROGRESS_SACT)             '搬送制御送信ｲﾝﾀｰﾌｪｰｽ.通信状態      ｾｯﾄ
                                'mblnSockSend = True                                 'ｿｹｯﾄ送信ﾌﾗｸﾞ
                                mintResponsWait = FLAG_ON                           '応答待ちﾌﾗｸﾞ                       ｾｯﾄ
                            Case Else
                                '(応答なしの場合)
                                Call UpdateSendFPROGRESS(FPROGRESS_SEND)             '搬送制御送信ｲﾝﾀｰﾌｪｰｽ.通信状態      ｾｯﾄ
                                mblnSockSend = True                                 'ｿｹｯﾄ送信ﾌﾗｸﾞ
                                mintResponsWait = FLAG_OFF                          '応答待ちﾌﾗｸﾞ                       ｾｯﾄ
                                Call InitializeDBReadTimer()                        '続けてDB検索処理
                        End Select

                    Case Else
                        '=========================================
                        '異常
                        '=========================================
                        Call UpdateSendFPROGRESS(FPROGRESS_SERR_MCI)         '搬送制御送信ｲﾝﾀｰﾌｪｰｽ.通信状態      ｾｯﾄ
                        mintResponsWait = FLAG_OFF                          '応答待ちﾌﾗｸﾞ                       ｾｯﾄ
                        '' ''Call SeqNoSendUpdate()                         'ｼｰｹﾝｽNo + 1                        ｾｯﾄ
                        Call mobjEQSendTelBuff.CLEAR_PROPERTY()            '送信ﾊﾞｯﾌｧ                          削除

                        'ﾛｸﾞ出力
                        Dim strMessage As String = ""
                        strMessage &= "ｴﾗｰが発生した為、次のﾚｺｰﾄﾞの処理は実行出来ませんでした。"
                        strMessage &= "[登録№:" & objTempTLIF_TRNS_SEND.FENTRY_NO & "]"
                        strMessage &= "[設備ID:" & objTempTLIF_TRNS_SEND.FEQ_ID & "]"
                        strMessage &= "[ｺﾏﾝﾄﾞID:" & objTempTLIF_TRNS_SEND.FCOMMAND_ID & "]"
                        strMessage &= "[ﾊﾟﾗﾒｰﾀ1:" & objTempTLIF_TRNS_SEND.FDENBUN_PRM1 & "]"
                        strMessage &= "[ﾊﾟﾗﾒｰﾀ2:" & objTempTLIF_TRNS_SEND.FDENBUN_PRM2 & "]"
                        strMessage &= "[ﾊﾟﾗﾒｰﾀ3:" & objTempTLIF_TRNS_SEND.FDENBUN_PRM3 & "]"
                        strMessage &= "[ﾊﾟﾗﾒｰﾀ4:" & objTempTLIF_TRNS_SEND.FDENBUN_PRM4 & "]"
                        strMessage &= "[ﾊﾟﾗﾒｰﾀ5:" & objTempTLIF_TRNS_SEND.FDENBUN_PRM5 & "]"
                        Call AddToLog(strMessage)

                End Select


            Next


        Catch ex As Exception
            ComError(ex)

        End Try
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
            Dim objTel As New clsTelegram(CONFIG_TELEGRAM_MCV)
            objTel.FORMAT_ID = FORMAT_MCV_000                   'ﾌｫｰﾏｯﾄ名ｾｯﾄ    (特に何でも良い)
            objTel.TELEGRAM_PARTITION = strRecvText             '分割する電文ｾｯﾄ
            objTel.PARTITION()                                  '電文分割


            '*****************************************************
            '【設備通信ﾛｸﾞ】             追加
            '*****************************************************
            Dim strFTEXT_ID As String = ""                   'ﾃｷｽﾄID
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

#Region "  MCIA_200001  ｲﾍﾞﾝﾄ通知               処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｲﾍﾞﾝﾄ通知
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_200001()
        Try


            '*****************************************************
            '設備状況更新01
            '*****************************************************
            For Each objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL In mobjAryTSTS_EQ_CTRL.ARYME
                '(ﾙｰﾌﾟ:ﾁｪｯｸするﾚｼﾞｽﾀ数)
                Call InsertLIF_TRNS_RECV_FCOMMAND_ID_SEVENT(objTSTS_EQ_CTRL)
            Next


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  MCIA_200004  ｵﾝﾗｲﾝﾁｪｯｸ               処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｵﾝﾗｲﾝﾁｪｯｸ
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_200004()
        Try
            Dim blnOnlineBefore As Boolean = mblnOnline


            '*****************************************************
            'ﾀｲﾑｱｳﾄﾁｪｯｸ
            '*****************************************************
            '検索時間からﾁｪｯｸ
            Dim objDiff As TimeSpan = mdtmBeforeOnline.AddMilliseconds(mintDBReadTimer) - Now
            If 0 < objDiff.TotalMilliseconds Then
                Exit Sub
            End If
            mdtmBeforeOnline = Now


            '*****************************************************
            '【設備状態】   ｵﾝﾗｲﾝ確認
            '*****************************************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(mobjOwner, mobjDb, mobjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID = mstrFEQ_ID                 '設備ID
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                  '取得
            If TO_INTEGER(objTSTS_EQ_CTRL.FEQ_CUT_STS) = FLAG_OFF _
               And TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS) = FLAG_ON Then
                '(「MCI」 = 「ｵﾝﾗｲﾝ」の場合)


                '*****************************************************
                'ｵﾝﾗｲﾝﾌﾗｸﾞ設定
                '*****************************************************
                mblnOnline = True


                If blnOnlineBefore <> mblnOnline Then
                    '(前回値と違っていた場合)


                    ''*****************************************************
                    ''再接続
                    ''*****************************************************
                    'Call ConnectRetry()


                    '*****************************************************
                    '読込,書込ﾚｼﾞｽﾀ配列更新
                    '*****************************************************
                    Call UpdateReadArray()      '読込ﾚｼﾞｽﾀ配列更新
                    Call UpdateWriteArray()     '書込ﾚｼﾞｽﾀ配列更新
                    If mblnConnect = False Then
                        mblnOnline = False
                        Exit Sub
                    End If


                    '*****************************************************
                    'ﾚｼﾞｽﾀ配列初期化
                    '*****************************************************
                    If mintDebugFlag = FLAG_OFF Then
                        For ii As Integer = REG_START To REG_MAX

                            '0と1を反転させる
                            Dim strTemp As String = Change10To2(mintNRegD(ii), 16)
                            strTemp = Replace(strTemp, "0", "X")
                            strTemp = Replace(strTemp, "1", "0")
                            strTemp = Replace(strTemp, "X", "1")
                            mintNRegD(ii) = Change2To10(strTemp)

                        Next
                    End If


                    '*****************************************************
                    'ﾚｼﾞｽﾀ配列初期化
                    '*****************************************************
                    For ii As Integer = LBound(mintBRegD) To UBound(mintBRegD)
                        mintBRegD(ii) = mintNRegD(ii)
                    Next


                End If


            Else
                '(「MCI」 = 「ｵﾌﾗｲﾝ」の場合)


                '*****************************************************
                'ｵﾝﾗｲﾝﾌﾗｸﾞ設定
                '*****************************************************
                mblnOnline = False


            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region


#Region "  ｲﾍﾞﾝﾄ通知                            処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｲﾍﾞﾝﾄ通知
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">ﾁｪｯｸするｱﾄﾞﾚｽ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub InsertLIF_TRNS_RECV_FCOMMAND_ID_SEVENT(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Try
            Dim strAddress As String = objTSTS_EQ_CTRL.FEQ_ID_LOCAL
            Dim intRet As RetCode = RetCode.NG


            '****************************************************
            '前回値と同じ場合はExit
            '****************************************************
            If ReadRegister(strAddress, mintBRegD) = ReadRegister(strAddress, mintNRegD) Then Exit Sub


            '****************************************************
            '搬送制御受信IF追加
            '****************************************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)
            objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                           '設備ID
            objTLIF_TRNS_RECV.FCOMMAND_ID = FCOMMAND_ID_SEVENT              'ｺﾏﾝﾄﾞID
            objTLIF_TRNS_RECV.FDENBUN_PRM1 = objTSTS_EQ_CTRL.FEQ_ID         'ｲﾍﾞﾝﾄのあった設備ID
            objTLIF_TRNS_RECV.FDENBUN_PRM2 = ReadRegister(strAddress, mintNRegD)    '値
            objTLIF_TRNS_RECV.FDENBUN_PRM3 = DEFAULT_STRING                         '電文ﾊﾟﾗﾒｰﾀ3
            objTLIF_TRNS_RECV.FDENBUN_PRM4 = DEFAULT_STRING                         '電文ﾊﾟﾗﾒｰﾀ4
            objTLIF_TRNS_RECV.FDENBUN_PRM5 = DEFAULT_STRING                         '電文ﾊﾟﾗﾒｰﾀ5
            objTLIF_TRNS_RECV.FDENBUN_PRM6 = DEFAULT_STRING                         '電文ﾊﾟﾗﾒｰﾀ6
            objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SEND                            '進捗状態
            '' ''      objTLIF_TRNS_RECV.FRES_CD_EQ = FORMAT_PLC_RES_CD_OK             '設備応答ｺｰﾄﾞ
            objTLIF_TRNS_RECV.FENTRY_DT = Now                                       '登録日時
            objTLIF_TRNS_RECV.FUPDATE_DT = Now                                      '更新日時
            objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()                              '追加
            mblnSockSend = True                                                     'ｿｹｯﾄ送信ﾌﾗｸﾞ


            '****************************************************
            '設備通信ﾛｸﾞ        追加
            '****************************************************
            Call InsertTLOG_EQ02(objTSTS_EQ_CTRL)


            '****************************************************
            'ﾛｸﾞ出力
            '****************************************************
            If Not ( _
                       objTSTS_EQ_CTRL.XEVENT_LOG_KUBUN = XEVENT_LOG_KUBUN_TRK_RTN01 _
                    Or objTSTS_EQ_CTRL.XEVENT_LOG_KUBUN = XEVENT_LOG_KUBUN_TRK_RTN02 _
                    ) Then
                '(RTNﾄﾗｯｷﾝｸﾞ関係じゃない場合)
                Call AddToLog(MCIC_MSG_1051 _
                              & "[前回値" & strAddress & ":" & ReadRegister(strAddress, mintBRegD) & "]" _
                              & "[今回値" & strAddress & ":" & ReadRegister(strAddress, mintNRegD) & "]" _
                              )
            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region


#Region "  ﾚｼﾞｽﾀ配列ﾃﾞｰﾀ読込み                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾚｼﾞｽﾀ配列ﾃﾞｰﾀ読込み
    ''' </summary>
    ''' <param name="strAddress">
    ''' ｱﾄﾞﾚｽ指定  [書式:ASS_B999999_X]
    '''                  A     →PLC指定部       (Y:安川PLC　　　M:三菱PLC)
    '''                  SS    →ｽﾚｰﾌﾞｱﾄﾞﾚｽ指定部(SW01:01、SW02:02、SW03:03、SW04:04、SW05:05、SW04A:06、MELSEC:FF)
    '''                  B     →ﾃﾞﾊﾞｲｽ区分      (今回は未使用)
    '''                  999999→ｱﾄﾞﾚｽ指定部     (40001～105536)
    '''                  XX    →ﾋﾞｯﾄ指定部      (10進数)    ※ｵﾌﾟｼｮﾝ指定
    ''' </param>
    ''' <param name="intRegD">
    ''' 読み込む配列を指定
    ''' </param>
    ''' <returns>読込み値</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function ReadRegister(ByVal strAddress As String _
                               , Optional ByVal intRegD() As Integer = Nothing _
                               ) As Integer
        Try
            Dim strMsg As String = ""


            '************************
            '初期設定
            '************************
            If IsNull(intRegD) = True Then intRegD = mintNRegD


            '************************
            '各設定値の特定
            '************************
            Dim strPartRegType As String                            'ﾚｼﾞｽﾀ区分指定部
            Dim intPartAddress As Nullable(Of Integer) = Nothing    'ｱﾄﾞﾚｽ指定部
            Dim intPartBit As Nullable(Of Integer) = Nothing        'ﾋﾞｯﾄ指定部
            strPartRegType = Mid(strAddress, 5, 1)
            intPartAddress = CInt(Mid(strAddress, 6, 6))
            If Len(strAddress) >= 12 Then
                '(ﾋﾞｯﾄ指定がある場合)
                Try
                    intPartBit = CInt(Mid(strAddress, 13, 2))
                    'intPartBit = Convert.ToInt32(Mid(strAddress, 8, 1), 16)
                Catch ex As Exception
                    strMsg = "引数が不正です。[ﾋﾞｯﾄ指定値異常  設備ID:" & strAddress & "]"
                    Throw New Exception(strMsg)
                End Try
            End If


            '************************
            '事前ﾁｪｯｸ
            '************************
            'If strPartRegType <> DEVICE_READ Then
            '    '(ﾚｼﾞｽﾀ区分指定部が不正の場合)
            '    strMsg = "引数が不正です。[ﾚｼﾞｽﾀ区分指定異常  設備ID:" & strAddress & "]"
            '    Throw New Exception(strMsg)
            If IsNothing(intPartAddress) = True Then
                '(ｱﾄﾞﾚｽ指定部が指定無しの場合)
                strMsg = "引数が不正です。[ｱﾄﾞﾚｽ指定無し異常  設備ID:" & strAddress & "]"
                Throw New Exception(strMsg)
            End If


            '************************
            '配列ﾃﾞｰﾀを特定
            '************************
            Dim intGetData As Integer
            intGetData = intRegD(intPartAddress)


            '************************
            'ﾋﾞｯﾄﾃﾞｰﾀを特定
            '************************
            If IsNothing(intPartBit) = False Then
                '(ﾋﾞｯﾄ指定が有る場合)
                Dim strTemp As String
                strTemp = Convert.ToString(intGetData, 2)
                If Len(strTemp) < 16 Then
                    Dim ii As Integer
                    For ii = 1 To 16 - Len(strTemp)
                        strTemp = "0" & strTemp
                    Next
                End If
                intGetData = Mid(strTemp, 16 - CInt(intPartBit), 1)
            End If


            Return intGetData

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function
#End Region
#Region "  ﾚｼﾞｽﾀ配列ﾃﾞｰﾀ書込み                      "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾚｼﾞｽﾀ配列ﾃﾞｰﾀ書込み
    ''' </summary>
    ''' <param name="strAddress">
    ''' ｱﾄﾞﾚｽ指定  [書式:ASS_B999999_X]
    '''                  A     →PLC指定部       (Y:安川PLC　　　M:三菱PLC)
    '''                  SS    →ｽﾚｰﾌﾞｱﾄﾞﾚｽ指定部(SW01:01、SW02:02、SW03:03、SW04:04、SW05:05、SW04A:06、MELSEC:FF)
    '''                  B     →ﾃﾞﾊﾞｲｽ区分      (今回は未使用)
    '''                  999999→ｱﾄﾞﾚｽ指定部     (40001～105536)
    '''                  XX    →ﾋﾞｯﾄ指定部      (10進数)    ※ｵﾌﾟｼｮﾝ指定
    ''' </param>
    ''' <param name="intWriteValue">書込み値</param>
    ''' <param name="strLogMsg">ﾛｸﾞ出力用ﾒｯｾｰｼﾞ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub WriteRegister(ByVal strAddress As String _
                           , ByVal intWriteValue As Integer _
                           , Optional ByVal strLogMsg As String = MCIC_MSG_1002 _
                           )
        Try
            Dim strMsg As String = ""


            '************************
            '各設定値の特定
            '************************
            Dim strPartRegType As String                            'ﾚｼﾞｽﾀ区分指定部
            Dim intPartAddress As Nullable(Of Integer) = Nothing    'ｱﾄﾞﾚｽ指定部
            Dim intPartBit As Nullable(Of Integer) = Nothing        'ﾋﾞｯﾄ指定部
            strPartRegType = Mid(strAddress, 5, 1)
            intPartAddress = CInt(Mid(strAddress, 6, 6))
            If Len(strAddress) >= 12 Then
                '(ﾋﾞｯﾄ指定がある場合)
                Try
                    intPartBit = CInt(Mid(strAddress, 13, 2))
                    'intPartBit = Convert.ToInt32(Mid(strAddress, 8, 1), 16)
                Catch ex As Exception
                    strMsg = "引数が不正です。[ﾋﾞｯﾄ指定値異常  設備ID:" & strAddress & "]"
                    Throw New Exception(strMsg)
                End Try
            End If


            '************************
            '事前ﾁｪｯｸ
            '************************
            'If strPartRegType <> DEVICE_WRITE Then
            '    '(ﾚｼﾞｽﾀ区分指定部が不正の場合)
            '    strMsg = "引数が不正です。[ﾚｼﾞｽﾀ区分指定異常  設備ID:" & strAddress & "]"
            '    Throw New Exception(strMsg)
            If IsNothing(intPartAddress) = True Then
                '(ｱﾄﾞﾚｽ指定部が指定無しの場合)
                strMsg = "引数が不正です。[ｱﾄﾞﾚｽ指定無し異常  設備ID:" & strAddress & "]"
                Throw New Exception(strMsg)
            ElseIf CInt(intPartAddress) < 1 And 100 < CInt(intPartAddress) Then
                '(ｱﾄﾞﾚｽ指定部が指定無しの場合)
                strMsg = "引数が不正です。[ｱﾄﾞﾚｽ指定無し異常  設備ID:" & strAddress & "]"
                Throw New Exception(strMsg)
            ElseIf IsNothing(intPartBit) = False Then
                '(ﾋﾞｯﾄ指定有りの場合)
                If (CInt(intWriteValue) <> 0) And (CInt(intWriteValue) <> 1) Then
                    '(設定値が不正な場合)
                    strMsg = "引数が不正です。[設定値異常  設備ID:" & strAddress & "]"
                    Throw New Exception(strMsg)
                End If
            End If


            '************************
            '値書込み
            '(配列)
            '************************
            Dim intTemp01 As Integer = ReadRegister(strAddress)   '変更前
            Dim intTemp02(0) As Integer                           '変更後
            If IsNothing(intPartBit) = True Then
                '(整数設定の場合)
                intTemp02(0) = intWriteValue
            Else
                '(ﾋﾞｯﾄ設定の場合)
                If intWriteValue = 1 Then
                    '(ON設定の場合)
                    intTemp02(0) = mintNRegD(CInt(intPartAddress)) Or 2 ^ CInt(intPartBit)
                Else
                    '(OFF設定の場合)
                    intTemp02(0) = mintNRegD(CInt(intPartAddress)) And Not (2 ^ CInt(intPartBit))
                End If
            End If
            mintNRegD(CInt(intPartAddress)) = intTemp02(0)
            'If IsNotNull(strLogMsg) Then
            '    If ReadRegister(strAddress) <> intTemp01 Then
            '        Call AddToLog(strLogMsg & "[ｱﾄﾞﾚｽ:" & strAddress & "][値:" & CStr(intWriteValue) & "]")
            '    End If
            'End If


            '***************************************
            'ﾚｼﾞｽﾀ書込
            '***************************************
            Dim intRetPLC As ComPLCYaskawa.clsPLC.RetCode
            intRetPLC = mobjPLC.AreaWrite(mintPLCSlaveAdrs, intPartAddress, intTemp02)               '配列取得
            If intRetPLC <> ComPLCYaskawa.clsPLC.RetCode.OK Then
                '(失敗した場合)
                Throw New Exception(MCIC_MSG_1007 _
                                    & "[ｽﾚｰﾌﾞｱﾄﾞﾚｽ:" & TO_STRING(mintPLCSlaveAdrs) & "]" _
                                    & "[開始ﾚｼﾞｽﾀ:" & TO_STRING(intPartAddress) & "]" _
                                    & "[値:" & TO_STRING(intTemp02(0)) & "]" _
                                    )
            End If


            ''************************
            ''値書込み
            ''(配列)
            ''************************
            'Dim intTemp As Integer = ReadRegister(strAddress)   '一時保管
            'If IsNothing(intPartBit) = True Then
            '    '(整数設定の場合)
            '    mintNRegD(CInt(intPartAddress)) = intWriteValue
            'Else
            '    '(ﾋﾞｯﾄ設定の場合)
            '    If intWriteValue = 1 Then
            '        '(ON設定の場合)
            '        mintNRegD(CInt(intPartAddress)) = mintNRegD(CInt(intPartAddress)) Or 2 ^ CInt(intPartBit)
            '    Else
            '        '(OFF設定の場合)
            '        mintNRegD(CInt(intPartAddress)) = mintNRegD(CInt(intPartAddress)) And Not (2 ^ CInt(intPartBit))
            '    End If
            'End If
            'If IsNotNull(strLogMsg) Then
            '    If ReadRegister(strAddress) <> intTemp Then
            '        Call AddToLog(strLogMsg & "[ｱﾄﾞﾚｽ:" & strAddress & "][値:" & CStr(intWriteValue) & "]")
            '    End If
            'End If


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub
#End Region
#Region "  ﾚｼﾞｽﾀ配列ｺﾋﾟｰ                            "
    Private Sub CopyRegR()

        Call Array.Copy(mintNRegD, REG_START, mintBRegD, REG_START, REG_COUNT_MAX + 1)

    End Sub
#End Region
#Region "  読込ﾚｼﾞｽﾀ配列更新            (対象となる全ﾚｼﾞｽﾀ)     "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 読込ﾚｼﾞｽﾀ配列更新            (対象となる全ﾚｼﾞｽﾀ)
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub UpdateReadArray()
        Try
            Dim intStartAdrs As Integer             '読込むﾚｼﾞｽﾀの開始位置
            Dim intReadCount As Integer             '読込むﾚｼﾞｽﾀ数
            'Dim intRet As ComPLCYaskawa.clsPLC.RetCode      '戻り値
            Dim objDiff As TimeSpan                 '時間差分


            '****************************************************
            'ﾀｲﾑｱｳﾄﾁｪｯｸ
            '****************************************************
            If mblnConnect = False Then
                '(接続ｴﾗｰの場合)
                objDiff = mdtmConnectBefore.AddMilliseconds(mintConnectTimer) - Now
                If objDiff.TotalMilliseconds < 0 Then
                    '(再接続ﾀｲﾑｱｳﾄの場合)


                    ''*****************************************************
                    ''再接続処理(実験の結果、不要と判明したが、一応処理する)
                    ''*****************************************************
                    'Call ConnectRetry()
                    mdtmConnectBefore = Now
                    'If mblnConnect = False Then Exit Sub


                Else
                    '(再接続ﾀｲﾑｱｳﾄしていない場合)
                    Exit Sub
                End If

            End If


            '******************************************************************************
            'ﾀｲﾏｰ処理
            '******************************************************************************
            objDiff = mdtmEQ_SendTimer_Before.AddMilliseconds(mintEQ_SendTimer) - Now
            If 0 < objDiff.TotalMilliseconds Then
                Exit Sub
            End If
            mdtmEQ_SendTimer_Before = Now


            '******************************************************************************
            'ﾚｼﾞｽﾀ読込
            '******************************************************************************
            '================================================
            '048001～048125
            '================================================
            intStartAdrs = 48001
            intReadCount = 125
            Call UpdateReadPartArray(intStartAdrs, intReadCount)

            '================================================
            '048126～048250
            '================================================
            Select Case mstrFEQ_ID
                Case FEQ_ID_JSYS0001, FEQ_ID_JSYS0003, FEQ_ID_JSYS0005, FEQ_ID_JSYS0006
                    '(必要な設備だけ取得)
                    intStartAdrs = 48126
                    intReadCount = 125
                    Call UpdateReadPartArray(intStartAdrs, intReadCount)
            End Select

            '================================================
            '048251～048369
            '================================================
            Select Case mstrFEQ_ID
                Case FEQ_ID_JSYS0001, FEQ_ID_JSYS0005
                    '(必要な設備だけ取得)
                    intStartAdrs = 48251
                    intReadCount = 119
                    Call UpdateReadPartArray(intStartAdrs, intReadCount)
            End Select

            '================================================
            '048401～048522
            '================================================
            intStartAdrs = 48401
            intReadCount = 122
            Call UpdateReadPartArray(intStartAdrs, intReadCount)

            '================================================
            '048601～048642
            '================================================
            Select Case mstrFEQ_ID
                Case FEQ_ID_JSYS0001, FEQ_ID_JSYS0005
                    '(必要な設備だけ取得)
                    intStartAdrs = 48601
                    intReadCount = 42
                    Call UpdateReadPartArray(intStartAdrs, intReadCount)
            End Select

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/13 日報変更(RTN稼働時間取得)
            '================================================
            '048601～048642
            '================================================
            Select Case mstrFEQ_ID
                Case FEQ_ID_JSYS0002, FEQ_ID_JSYS0004
                    '(必要な設備だけ取得)
                    intStartAdrs = 48601
                    intReadCount = 3
                    Call UpdateReadPartArray(intStartAdrs, intReadCount)
            End Select
            'JobMate:S.Ouchi 2013/11/13 日報変更(RTN稼働時間取得)
            '↑↑↑↑↑↑************************************************************************************************************

            '================================================
            '049001～049007
            '================================================
            Select Case mstrFEQ_ID
                Case FEQ_ID_JSYS0005
                    '(必要な設備だけ取得)
                    intStartAdrs = 49001
                    intReadCount = 7
                    Call UpdateReadPartArray(intStartAdrs, intReadCount)
            End Select

            '******************************************************************************
            'ﾀｲﾏｰ処理02
            '******************************************************************************
            objDiff = mdtmEQ_Send02Timer_Before.AddMilliseconds(mintEQ_Send02Timer) - Now
            If 0 < objDiff.TotalMilliseconds Then
                Exit Sub
            End If
            mdtmEQ_Send02Timer_Before = Now


            '******************************************************************************
            'ﾚｼﾞｽﾀ読込02
            '******************************************************************************
            '================================================
            '040601～040725
            '================================================
            intStartAdrs = 40601
            intReadCount = 125
            Call UpdateReadPartArray(intStartAdrs, intReadCount)

            '================================================
            '040726～040850
            '================================================
            intStartAdrs = 40726
            intReadCount = 125
            Call UpdateReadPartArray(intStartAdrs, intReadCount)

            '================================================
            '040851～040939
            '================================================
            intStartAdrs = 40851
            intReadCount = 89
            Call UpdateReadPartArray(intStartAdrs, intReadCount)

            '================================================
            '041001～041125
            '041126～041250
            '041251～041280
            '041371～041495
            '041496～041620
            '041621～041650
            '================================================
            Select Case mstrFEQ_ID
                Case FEQ_ID_JSYS0001, FEQ_ID_JSYS0005
                    '(必要な設備だけ取得)

                    '================================================
                    '041001～041125
                    '================================================
                    intStartAdrs = 41001
                    intReadCount = 125
                    Call UpdateReadPartArray(intStartAdrs, intReadCount)

                    '================================================
                    '041126～041250
                    '================================================
                    intStartAdrs = 41126
                    intReadCount = 125
                    Call UpdateReadPartArray(intStartAdrs, intReadCount)

                    '================================================
                    '041251～041280
                    '================================================
                    intStartAdrs = 41251
                    intReadCount = 30
                    Call UpdateReadPartArray(intStartAdrs, intReadCount)

                    '================================================
                    '041371～041495
                    '================================================
                    intStartAdrs = 41371
                    intReadCount = 125
                    Call UpdateReadPartArray(intStartAdrs, intReadCount)

                    '================================================
                    '041496～041620
                    '================================================
                    intStartAdrs = 41496
                    intReadCount = 125
                    Call UpdateReadPartArray(intStartAdrs, intReadCount)

                    '================================================
                    '041621～041650
                    '================================================
                    intStartAdrs = 41621
                    intReadCount = 30
                    Call UpdateReadPartArray(intStartAdrs, intReadCount)

            End Select


            mblnConnect = True
        Catch ex As Exception
            mblnConnect = False
            Call ComError(ex)
        End Try
    End Sub
#End Region
#Region "  読込ﾚｼﾞｽﾀ配列更新            (指定したﾚｼﾞｽﾀ)         "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 読込ﾚｼﾞｽﾀ配列更新            (指定したﾚｼﾞｽﾀ)
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub UpdateReadPartArray(ByVal intAdrs As Integer _
                                  , ByVal intSize As Integer _
                                  )
        Dim intTemp() As Integer = Nothing               'ﾚｼﾞｽﾀ値一時保管
        Dim intRet As ComPLCYaskawa.clsPLC.RetCode      '戻り値


        '***************************************
        'ﾚｼﾞｽﾀ読込
        '***************************************
        intRet = mobjPLC.AreaRead(mintPLCSlaveAdrs, intAdrs, intSize, intTemp)        '配列取得
        If intRet = ComPLCYaskawa.clsPLC.RetCode.OK Then
            '(成功の場合)

            Call Array.Copy(intTemp, 0, mintNRegD, intAdrs, intTemp.Length)

            'For ii As Integer = LBound(objTemp) To UBound(objTemp)
            '    '(ﾙｰﾌﾟ:読込ﾚｼﾞｽﾀの数)
            '    mintNRegD(intAdrs + ii) = objTemp(ii)
            'Next
        Else
            '(失敗の場合)
            Throw New Exception(MCIC_MSG_1001 _
                                & "[ｽﾚｰﾌﾞｱﾄﾞﾚｽ:" & TO_STRING(mintPLCSlaveAdrs) & "]" _
                                & "[開始ﾚｼﾞｽﾀ:" & TO_STRING(intAdrs) & "]" _
                                & "[取得個数:" & TO_STRING(intSize) & "]" _
                                )
        End If

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2016/08/18 ﾊﾟﾌｫｰﾏﾝｽ改善 ↓↓↓↓↓↓
        Application.DoEvents()
        'JobMate:S.Ouchi 2016/08/18 ﾊﾟﾌｫｰﾏﾝｽ改善 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************

    End Sub
#End Region
#Region "  書込ﾚｼﾞｽﾀ配列更新                        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 書込ﾚｼﾞｽﾀ配列更新
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub UpdateWriteArray()
        'Try
        '    Dim objTemp As Object = Nothing         'ﾚｼﾞｽﾀ値一時保管
        '    Dim blnRet As Boolean                   '戻り値


        '    '***************************************
        '    'ﾚｼﾞｽﾀ読込
        '    '***************************************
        '    blnRet = mobjFAEngine.ReadVal(mstrTagPath02, objTemp)        '配列取得
        '    If blnRet = True Then
        '        '(成功の場合)
        '        For ii As Integer = LBound(objTemp) To UBound(objTemp)
        '            '(ﾙｰﾌﾟ:読込ﾚｼﾞｽﾀの数)
        '            mintNRegD(ii + REGR_ADRS_WRITE_HEAD) = objTemp(ii)
        '        Next
        '    Else
        '        '(失敗の場合)
        '        Throw New Exception(MCIC_MSG_1001 _
        '                            & "[FA-Engineｴﾗｰｺｰﾄﾞ:" & mobjFAEngine.ErrCode & "]" _
        '                            & "[FA-Engineｴﾗｰﾒｯｾｰｼﾞ:" & mobjFAEngine.ErrMessage & "]" _
        '                            )
        '    End If


        '    mblnConnect = True
        'Catch ex As Exception
        '    mblnConnect = False
        '    Call ComError(ex)
        'End Try
    End Sub
#End Region
#Region "  書込ﾚｼﾞｽﾀ配列書込み                      "
    ''''*******************************************************************************************************************
    '''' <summary>
    '''' 書込ﾚｼﾞｽﾀ配列書込み
    '''' </summary>
    '''' <remarks></remarks>
    ''''*******************************************************************************************************************
    'Private Sub WriteArrayWrite()
    '    Try
    '        Dim objRegDWrite(REGR_ADRS_WRITE_LEN) As Object     '書込ﾚｼﾞｽﾀ配列
    '        Dim blnRet As Boolean                               '戻り値


    '        '************************
    '        '書込ﾚｼﾞｽﾀ値配列作成(配列ｺﾋﾟｰ)
    '        '************************
    '        Array.Copy(mintNRegD _
    '                 , REGR_ADRS_WRITE_HEAD _
    '                 , objRegDWrite _
    '                 , LBound(objRegDWrite) _
    '                 , REGR_ADRS_WRITE_LEN _
    '                 )


    '        Dim objDiff As TimeSpan = mdtmBeforeWrite.AddMilliseconds(mintConnectTimer) - Now
    '        If ArrayCompare(objRegDWrite, mintRegRBuff) = False _
    '           Or objDiff.TotalMilliseconds < 0 _
    '           Then
    '            '(前回書込配列と違う場合、もしくは一定時間経過した場合)


    '            '***************************************
    '            'ﾚｼﾞｽﾀ書込
    '            '***************************************
    '            blnRet = mobjFAEngine.WriteVal(mstrTagPath02, objRegDWrite)        '配列取得
    '            mdtmBeforeWrite = Now
    '            If blnRet = True Then
    '                '(成功の場合)

    '                'ﾊﾞｯﾌｧにｺﾋﾟｰ
    '                Array.Copy(mintNRegD _
    '                         , REGR_ADRS_WRITE_HEAD _
    '                         , mintRegRBuff _
    '                         , LBound(mintRegRBuff) _
    '                         , REGR_ADRS_WRITE_LEN _
    '                         )

    '            Else
    '                '(失敗の場合)
    '                Throw New Exception(MCIC_MSG_1007 _
    '                                    & "[FA-Engineｴﾗｰｺｰﾄﾞ:" & mobjFAEngine.ErrCode & "]" _
    '                                    & "[FA-Engineｴﾗｰﾒｯｾｰｼﾞ:" & mobjFAEngine.ErrMessage & "]" _
    '                                    )
    '            End If


    '        End If


    '    Catch ex As Exception
    '        mblnConnect = False
    '        Call ComError(ex)
    '    End Try
    'End Sub
#End Region


#Region "  【設備通信ﾛｸﾞ】受信ﾛｸﾞ追加     処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 【設備通信ﾛｸﾞ】受信ﾛｸﾞ追加
    ''' </summary>
    ''' <param name="strFTEXT_ID">ﾃｷｽﾄID</param>
    ''' <param name="strFDENBUN">通信電文</param>
    ''' <param name="strFRES_CD_EQ">設備応答ｺｰﾄﾞ</param>
    ''' <param name="strXEQ_ID_WRITE">設備ID</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddDBRecvLog_LOG(ByVal strFTEXT_ID As String _
                              , ByVal strFDENBUN As String _
                              , ByVal strFRES_CD_EQ As String _
                              , Optional ByVal strXEQ_ID_WRITE As String = Nothing _
                                )

        '========================================
        'DBﾛｸﾞ出力
        '========================================
        Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)
        objTLOG_EQ.FLOG_NO = "1"                            'ﾛｸﾞNo
        objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '設備ID
        objTLOG_EQ.FHASSEI_DT = mdtmNow                     '発生日時
        objTLOG_EQ.FDIRECTION = FDIRECTION_SRECV             '方向
        objTLOG_EQ.FTEXT_ID = strFTEXT_ID                   'ﾃｷｽﾄID
        objTLOG_EQ.FDENBUN = strFDENBUN                     '通信ﾃｷｽﾄ
        objTLOG_EQ.FRES_CD_EQ = strFRES_CD_EQ               '応答ｺｰﾄﾞ
        objTLOG_EQ.XEQ_ID_WRITE = strXEQ_ID_WRITE           '設備ID
        objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '追加


    End Sub
#End Region
#Region "  【設備通信ﾛｸﾞ】送信ﾛｸﾞ追加     処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 【設備通信ﾛｸﾞ】送信ﾛｸﾞ追加
    ''' </summary>
    ''' <param name="strFTEXT_ID">ﾃｷｽﾄID</param>
    ''' <param name="strFDENBUN">通信電文</param>
    ''' <param name="strFRES_CD_EQ">設備応答ｺｰﾄﾞ</param>
    ''' <param name="strXEQ_ID_WRITE">設備ID</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddDBSendLog_LOG(ByVal strFTEXT_ID As String _
                              , ByVal strFDENBUN As String _
                              , ByVal strFRES_CD_EQ As String _
                              , Optional ByVal strXEQ_ID_WRITE As String = Nothing _
                                )

        '========================================
        'DBﾛｸﾞ出力
        '========================================
        Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)
        objTLOG_EQ.FLOG_NO = "1"                            'ﾛｸﾞNo
        objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '設備ID
        objTLOG_EQ.FHASSEI_DT = mdtmNow                     '発生日時
        objTLOG_EQ.FDIRECTION = FDIRECTION_SSEND            '方向
        objTLOG_EQ.FTEXT_ID = strFTEXT_ID                   'ﾃｷｽﾄID
        objTLOG_EQ.FDENBUN = strFDENBUN                     '通信ﾃｷｽﾄ
        objTLOG_EQ.FRES_CD_EQ = strFRES_CD_EQ               '応答ｺｰﾄﾞ
        objTLOG_EQ.XEQ_ID_WRITE = strXEQ_ID_WRITE           '設備ID
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
#Region "  ID:0101      ﾚｼｽﾞﾀ書込要求(ﾜｰﾄﾞ対応)             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾚｼｽﾞﾀ書込要求(ﾜｰﾄﾞ対応)
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">送信するﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <returns>正常終了の有無</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function ID0101Process(ByRef objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND) As RetCode
        Try
            '' ''Dim intRet As RetCode


            '*****************************************************
            '設備状況       取得
            '*****************************************************
            Dim strAryFEQ_ID() As String = Split(objTLIF_TRNS_SEND.FDENBUN_PRM1, ",")
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(mobjOwner, mobjDb, mobjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID = strAryFEQ_ID(0)                    '設備ID
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                          '取得


            '*****************************************************
            'ﾋﾞｯﾄ処理(実際)
            '*****************************************************
            Dim intPartAddress As Integer = CInt(Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 6, 6))       'ｱﾄﾞﾚｽ指定部
            Dim strAryData() As String = Split(objTLIF_TRNS_SEND.FDENBUN_PRM2, ",")             '書込ﾃﾞｰﾀ
            Dim intAryData(UBound(strAryData)) As Integer                                       '書込ﾃﾞｰﾀ
            '書込ﾃﾞｰﾀを数値型へ変換
            For ii As Integer = 0 To UBound(strAryData)
                '(ﾙｰﾌﾟ:書込むﾃﾞｰﾀ数)
                intAryData(ii) = TO_INTEGER(strAryData(ii))
            Next
            'Call Array.Copy(strData, 0, intData, 0, strData.Length)                             '書込ﾃﾞｰﾀを数値型にｺﾋﾟｰ


            '***************************************
            'ﾚｼﾞｽﾀ書込
            '***************************************
            Dim intRetPLC As ComPLCYaskawa.clsPLC.RetCode
            intRetPLC = mobjPLC.AreaWrite(mintPLCSlaveAdrs, intPartAddress, intAryData)          '配列取得
            If intRetPLC <> ComPLCYaskawa.clsPLC.RetCode.OK Then
                '(失敗した場合)
                Throw New Exception(MCIC_MSG_1007 _
                                    & "[ｽﾚｰﾌﾞｱﾄﾞﾚｽ:" & TO_STRING(mintPLCSlaveAdrs) & "]" _
                                    & "[開始ﾚｼﾞｽﾀ:" & TO_STRING(intPartAddress) & "]" _
                                    & "[値:" & TO_STRING(objTLIF_TRNS_SEND.FDENBUN_PRM2) & "]" _
                                    )
            End If
            Call AddToLog(MCIC_MSG_1031 & "[設備ID:" & objTLIF_TRNS_SEND.FDENBUN_PRM1 & "][値:" & CStr(objTLIF_TRNS_SEND.FDENBUN_PRM2) & "]")


            '*****************************************************
            '搬送送信IF更新
            '*****************************************************
            objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SEND                     '進捗状態
            objTLIF_TRNS_SEND.FUPDATE_DT = Now                              '更新日時
            objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()                       '更新


            '*****************************************************
            '設備通信ﾛｸﾞ            出力
            '*****************************************************
            Call InsertTLOG_EQ01(objTLIF_TRNS_SEND _
                               , strAryFEQ_ID _
                               , strAryData _
                               )



            Return RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
#Region "  ID:0102      ﾚｼｽﾞﾀ書込要求(ﾋﾞｯﾄ対応)             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾚｼｽﾞﾀ書込要求(ﾋﾞｯﾄ対応)
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">送信するﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <returns>正常終了の有無</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function ID0102Process(ByRef objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND) As RetCode
        Try
            '' ''Dim intRet As RetCode


            '*****************************************************
            '設備状況       取得
            '*****************************************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(mobjOwner, mobjDb, mobjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID = objTLIF_TRNS_SEND.FDENBUN_PRM1     '設備ID
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                          '取得


            '*****************************************************
            'ﾋﾞｯﾄ処理(実際はﾜｰﾄﾞでも大丈夫)
            '*****************************************************
            Call WriteRegister(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, objTLIF_TRNS_SEND.FDENBUN_PRM2)
            Call AddToLog(MCIC_MSG_1031 & "[設備ID:" & objTLIF_TRNS_SEND.FDENBUN_PRM1 & "][値:" & CStr(objTLIF_TRNS_SEND.FDENBUN_PRM2) & "]")


            '*****************************************************
            '搬送送信IF更新
            '*****************************************************
            objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SEND                     '進捗状態
            objTLIF_TRNS_SEND.FUPDATE_DT = Now                              '更新日時
            objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()                       '更新


            Return RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
#Region "  ID:0201      ﾚｼｽﾞﾀ読込要求(全ﾚｼﾞｽﾀ)              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾚｼｽﾞﾀ読込要求(全ﾚｼﾞｽﾀ)
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">送信するﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <returns>正常終了の有無</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function ID0201Process(ByRef objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND) As RetCode
        Try
            '' ''Dim intRet As RetCode


            '*****************************************************
            'ﾚｼﾞｽﾀ読込
            '*****************************************************
            mdtmEQ_SendTimer_Before = Now.AddMilliseconds(-mintEQ_SendTimer - 10000)  'ﾀｲﾏｰ判定があるので、その対応
            Call UpdateReadArray()      '読込ﾚｼﾞｽﾀ配列更新


            Return RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
    '↑↑↑↑↑↑送信処理
    '***********************************************

#Region "  【設備通信ﾛｸﾞ】ﾛｸﾞ追加(書込処理)             処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 【設備通信ﾛｸﾞ】ﾛｸﾞ追加(書込処理)             処理
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">搬送制御送信IF</param>
    ''' <param name="strAryFEQ_ID">設備ID</param>
    ''' <param name="strAryData">書込みﾃﾞｰﾀ</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub InsertTLOG_EQ01(ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND _
                             , ByVal strAryFEQ_ID() As String _
                             , ByVal strAryData() As String _
                             )
        Dim strFDENBUN As String = ""           '通信電文


        '********************************************
        '設備状況           取得
        '********************************************
        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(mobjOwner, mobjDb, mobjDbLog)
        objTSTS_EQ_CTRL.FEQ_ID = strAryFEQ_ID(0)            '設備ID
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                  '取得


        '********************************************
        'ﾛｸﾞ出力文字列      作成
        '********************************************
        Select Case objTLIF_TRNS_SEND.FTEXT_ID
            Case FTEXT_ID_JW_IN _
               , FTEXT_ID_JW_OUT _
               , FTEXT_ID_JW_TRNS _
               , FTEXT_ID_JW_MAINTE_INOUT
                '(搬送系の場合)

                '====================================================
                '値を設定
                '====================================================
                Dim strAryTempData(5) As String
                If UBound(strAryData) = 5 Then
                    '(6ﾜｰﾄﾞ分の場合は全てｺﾋﾟｰ)
                    Call Array.Copy(strAryData, 0, strAryTempData, 0, strAryData.Length)
                Else
                    '(6ﾜｰﾄﾞ分の場合は出庫)
                    strAryTempData(0) = strAryData(0)
                    strAryTempData(1) = strAryData(1)
                    strAryTempData(2) = strAryData(2)
                    strAryTempData(3) = "0"
                    strAryTempData(4) = "0"
                    strAryTempData(5) = "0"
                End If

                '====================================================
                '設備状態     →  搬送指示ﾃﾞｰﾀ
                '====================================================
                Dim intAryBunkai() As Integer = Nothing     '分解ﾃﾞｰﾀ
                Call GetHansouSiziData(strAryTempData, intAryBunkai)
                strFDENBUN &= "[入庫ﾓｰﾄﾞ  (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.InMode_01)), 5) & "]"
                strFDENBUN &= "[出庫ﾓｰﾄﾞ  (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.OutMode_01)), 5) & "]"
                strFDENBUN &= "[ﾍﾟｱ搬送   (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.PairHansou_01)), 5) & "]"
                strFDENBUN &= "[ﾌｫｰｸ2     (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork2_01)), 5) & "]"
                strFDENBUN &= "[ﾌｫｰｸ1     (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork1_01)), 5) & "]"
                strFDENBUN &= "[L/S番号   (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.LSNo_01)), 5) & "]"
                strFDENBUN &= "[ﾀﾞﾌﾞﾙﾘｰﾁ  (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.DoubleReach_01)), 5) & "]"
                strFDENBUN &= "[列        (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Retu_01)), 5) & "]"
                strFDENBUN &= "[号機      (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Gouki_01)), 5) & "]"
                strFDENBUN &= "[連        (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Ren_01)), 5) & "]"
                strFDENBUN &= "[ENDﾌﾗｸﾞ   (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.EndFlag_01)), 5) & "]"
                strFDENBUN &= "[入棚再設定(1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.IritanaRetry_01)), 5) & "]"
                strFDENBUN &= "[段        (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Dan_01)), 5) & "]"
                strFDENBUN &= "[ｱﾄﾞﾚｽ     (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Addrs_01)), 5) & "]"

                strFDENBUN &= "[入庫ﾓｰﾄﾞ  (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.InMode_02)), 5) & "]"
                strFDENBUN &= "[出庫ﾓｰﾄﾞ  (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.OutMode_02)), 5) & "]"
                strFDENBUN &= "[ﾍﾟｱ搬送   (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.PairHansou_02)), 5) & "]"
                strFDENBUN &= "[ﾌｫｰｸ2     (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork2_02)), 5) & "]"
                strFDENBUN &= "[ﾌｫｰｸ1     (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork1_02)), 5) & "]"
                strFDENBUN &= "[L/S番号   (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.LSNo_02)), 5) & "]"
                strFDENBUN &= "[ﾀﾞﾌﾞﾙﾘｰﾁ  (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.DoubleReach_02)), 5) & "]"
                strFDENBUN &= "[列        (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Retu_02)), 5) & "]"
                strFDENBUN &= "[号機      (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Gouki_02)), 5) & "]"
                strFDENBUN &= "[連        (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Ren_02)), 5) & "]"
                strFDENBUN &= "[ENDﾌﾗｸﾞ   (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.EndFlag_02)), 5) & "]"
                strFDENBUN &= "[入棚再設定(2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.IritanaRetry_02)), 5) & "]"
                strFDENBUN &= "[段        (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Dan_02)), 5) & "]"
                strFDENBUN &= "[ｱﾄﾞﾚｽ     (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Addrs_02)), 5) & "]"


                'Case FTEXT_ID_JW_MAINTE_INOUT
                '    '(入出庫ﾒﾝﾃﾅﾝｽの場合)

                '    '====================================================
                '    '値を設定
                '    '====================================================
                '    Dim strAryTempData(5) As String
                '    If UBound(strAryData) = 5 Then
                '        '(6ﾜｰﾄﾞ分の場合は全てｺﾋﾟｰ)
                '        Call Array.Copy(strAryData, 0, strAryTempData, 0, strAryData.Length)
                '    Else
                '        '(6ﾜｰﾄﾞ分の場合は出庫)
                '        strAryTempData(0) = strAryData(0)
                '        strAryTempData(1) = strAryData(1)
                '        strAryTempData(2) = strAryData(2)
                '        strAryTempData(3) = "0"
                '        strAryTempData(4) = "0"
                '        strAryTempData(5) = "0"
                '    End If

                '    '====================================================
                '    '設備状態     →  搬送指示ﾃﾞｰﾀ
                '    '====================================================
                '    Dim intAryBunkai() As Integer = Nothing     '分解ﾃﾞｰﾀ
                '    Call GetHansouSiziData(strAryTempData, intAryBunkai)
                '    strFDENBUN &= "[入庫ﾓｰﾄﾞ  (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.InMode_01)), 5) & "]"
                '    strFDENBUN &= "[出庫ﾓｰﾄﾞ  (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.OutMode_01)), 5) & "]"
                '    strFDENBUN &= "[ﾍﾟｱ搬送   (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.PairHansou_01)), 5) & "]"
                '    strFDENBUN &= "[ﾌｫｰｸ2     (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork2_01)), 5) & "]"
                '    strFDENBUN &= "[ﾌｫｰｸ1     (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork1_01)), 5) & "]"
                '    strFDENBUN &= "[L/S番号   (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.LSNo_01)), 5) & "]"
                '    strFDENBUN &= "[ﾀﾞﾌﾞﾙﾘｰﾁ  (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.DoubleReach_01)), 5) & "]"
                '    strFDENBUN &= "[列        (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Retu_01)), 5) & "]"
                '    strFDENBUN &= "[号機      (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Gouki_01)), 5) & "]"
                '    strFDENBUN &= "[連        (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Ren_01)), 5) & "]"
                '    strFDENBUN &= "[ENDﾌﾗｸﾞ   (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.EndFlag_01)), 5) & "]"
                '    strFDENBUN &= "[入棚再設定(1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.IritanaRetry_01)), 5) & "]"
                '    strFDENBUN &= "[段        (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Dan_01)), 5) & "]"
                '    strFDENBUN &= "[ｱﾄﾞﾚｽ     (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Addrs_01)), 5) & "]"

                '    '' ''strFDENBUN &= "[入庫ﾓｰﾄﾞ  (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.InMode_02)), 5) & "]"
                '    '' ''strFDENBUN &= "[出庫ﾓｰﾄﾞ  (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.OutMode_02)), 5) & "]"
                '    '' ''strFDENBUN &= "[ﾍﾟｱ搬送   (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.PairHansou_02)), 5) & "]"
                '    '' ''strFDENBUN &= "[ﾌｫｰｸ2     (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork2_02)), 5) & "]"
                '    '' ''strFDENBUN &= "[ﾌｫｰｸ1     (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork1_02)), 5) & "]"
                '    '' ''strFDENBUN &= "[L/S番号   (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.LSNo_02)), 5) & "]"
                '    '' ''strFDENBUN &= "[ﾀﾞﾌﾞﾙﾘｰﾁ  (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.DoubleReach_02)), 5) & "]"
                '    '' ''strFDENBUN &= "[列        (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Retu_02)), 5) & "]"
                '    '' ''strFDENBUN &= "[号機      (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Gouki_02)), 5) & "]"
                '    '' ''strFDENBUN &= "[連        (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Ren_02)), 5) & "]"
                '    '' ''strFDENBUN &= "[ENDﾌﾗｸﾞ   (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.EndFlag_02)), 5) & "]"
                '    '' ''strFDENBUN &= "[入棚再設定(2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.IritanaRetry_02)), 5) & "]"
                '    '' ''strFDENBUN &= "[段        (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Dan_02)), 5) & "]"
                '    '' ''strFDENBUN &= "[ｱﾄﾞﾚｽ     (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Addrs_02)), 5) & "]"


            Case FTEXT_ID_JW_MAINTE_RTN
                '(RTNﾄﾗｯｷﾝｸﾞの場合)

                '====================================================
                '設備状態     →  搬送指示ﾃﾞｰﾀ
                '====================================================
                Dim intAryBunkai() As Integer = Nothing     '分解ﾃﾞｰﾀ
                Call GetPLCRTNData(strAryData, intAryBunkai)
                strFDENBUN &= "[入庫ﾓｰﾄﾞ     :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.InMode)), 5) & "]"
                strFDENBUN &= "[出庫ﾓｰﾄﾞ     :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.OutMode)), 5) & "]"
                strFDENBUN &= "[ﾍﾟｱ搬送      :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.PairHansou)), 5) & "]"
                strFDENBUN &= "[ﾌｫｰｸ2        :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Fork2)), 5) & "]"
                strFDENBUN &= "[ﾌｫｰｸ1        :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Fork1)), 5) & "]"
                strFDENBUN &= "[L/S番号      :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.LSNo)), 5) & "]"
                strFDENBUN &= "[ﾀﾞﾌﾞﾙﾘｰﾁ     :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.DoubleReach)), 5) & "]"
                strFDENBUN &= "[列           :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Retu)), 5) & "]"
                strFDENBUN &= "[号機         :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Gouki)), 5) & "]"
                strFDENBUN &= "[連           :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Ren)), 5) & "]"
                strFDENBUN &= "[ENDﾌﾗｸﾞ      :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.EndFlag)), 5) & "]"
                strFDENBUN &= "[入棚再設定   :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.IritanaRetry)), 5) & "]"
                strFDENBUN &= "[段           :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Dan)), 5) & "]"
                strFDENBUN &= "[ｱﾄﾞﾚｽ        :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Addrs)), 5) & "]"
                strFDENBUN &= "[子           :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Ko)), 5) & "]"
                strFDENBUN &= "[親           :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Oya)), 5) & "]"
                strFDENBUN &= "[在籍         :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Zaiseki)), 5) & "]"


            Case FTEXT_ID_JW_MAINTE_YOTEI
                '(出庫予定数ﾒﾝﾃﾅﾝｽの場合)

                strFDENBUN &= "[出庫予定数ﾒﾝﾃﾅﾝｽ   :" & SPC_PAD_RIGHT_SJIS(TO_STRING(strAryData(0)), 5) & "]"

            Case FTEXT_ID_JW_MAINTE_GENZAI
                '(出庫現在数ﾒﾝﾃﾅﾝｽの場合)

                strFDENBUN &= "[出庫現在数ﾒﾝﾃﾅﾝｽ   :" & SPC_PAD_RIGHT_SJIS(TO_STRING(strAryData(0)), 5) & "]"

            Case FTEXT_ID_JW_YOTEI
                '(到着予定数の場合)

                strFDENBUN &= "[到着予定数         :" & SPC_PAD_RIGHT_SJIS(TO_STRING(strAryData(0)), 5) & "]"

            Case FTEXT_ID_JW_CV_YOUTO
                '(ｺﾝﾍﾞﾔ用途の場合)

                strFDENBUN &= "[ｺﾝﾍﾞﾔ用途設定]"

            Case FTEXT_ID_JW_KADOU_RESET
                '(稼働時間ﾘｾｯﾄの場合)

                strFDENBUN &= "[稼働時間ﾘｾｯﾄ]"

            Case FTEXT_ID_JW_ETC
                '(その他の場合)

                strFDENBUN &= "[書込][" & objTSTS_EQ_CTRL.FEQ_NAME & ":" & SPC_PAD_RIGHT_SJIS(TO_STRING(strAryData(0)), 5) & "]"

            Case Else
                '(その他)
                strFDENBUN &= "ﾃｷｽﾄIDが入っていません。"

        End Select


        '********************************************
        'ﾛｸﾞ出力
        '********************************************
        Call AddToLog(MCIC_MSG_1031 & strFDENBUN)


        '********************************************
        '設備通信ﾛｸﾞ        追加
        '********************************************
        Call AddDBSendLog_LOG(objTLIF_TRNS_SEND.FTEXT_ID _
                            , strFDENBUN _
                            , "" _
                            , objTSTS_EQ_CTRL.FEQ_ID _
                            )


    End Sub
#End Region
#Region "  【設備通信ﾛｸﾞ】ﾛｸﾞ追加(ｲﾍﾞﾝﾄ通知処理)        処理"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 【設備通信ﾛｸﾞ】ﾛｸﾞ追加(ｲﾍﾞﾝﾄ通知処理)        処理
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">設備状況</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub InsertTLOG_EQ02(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Dim strFDENBUN As String = ""           '通信電文
        Dim strFTEXT_ID As String = ""


        '********************************************
        'ﾛｸﾞ出力文字列      作成
        '********************************************
        Select Case TO_INTEGER(objTSTS_EQ_CTRL.XEVENT_LOG_KUBUN)
            Case XEVENT_LOG_KUBUN_EVENT
                '(ｲﾍﾞﾝﾄ通知ﾛｸﾞの場合)
                strFTEXT_ID = FTEXT_ID_JR_EVENT         'ﾃｷｽﾄID

                '====================================================
                '値を設定
                '====================================================
                strFDENBUN &= "[設備名称:" & objTSTS_EQ_CTRL.FEQ_NAME & "]"
                strFDENBUN &= "[設備状態:" & ReadRegister(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, mintNRegD) & "]"

            Case XEVENT_LOG_KUBUN_TRK_INOUT01
                '(入出庫ﾄﾗｯｷﾝｸﾞの場合)
                strFTEXT_ID = FTEXT_ID_JR_TRK_INOUT       'ﾃｷｽﾄID

                '====================================================
                'ﾄﾗｯｷﾝｸﾞ用のﾛｰｶﾙ設備IDを取得
                '====================================================
                Dim strFEQ_ID_LOCAL(5) As String
                Dim intAdrs As Integer = TO_INTEGER(Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 6, 6))
                strFEQ_ID_LOCAL(0) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs + 0, 6)
                strFEQ_ID_LOCAL(1) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs + 1, 6)
                strFEQ_ID_LOCAL(2) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs + 2, 6)
                strFEQ_ID_LOCAL(3) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs + 3, 6)
                strFEQ_ID_LOCAL(4) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs + 4, 6)
                strFEQ_ID_LOCAL(5) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs + 5, 6)

                '====================================================
                '設備状態           取得
                '====================================================
                Dim strFEQ_STS(5) As String     '設備状態
                strFEQ_STS(0) = ReadRegister(strFEQ_ID_LOCAL(0), mintNRegD)
                strFEQ_STS(1) = ReadRegister(strFEQ_ID_LOCAL(1), mintNRegD)
                strFEQ_STS(2) = ReadRegister(strFEQ_ID_LOCAL(2), mintNRegD)
                strFEQ_STS(3) = ReadRegister(strFEQ_ID_LOCAL(3), mintNRegD)
                strFEQ_STS(4) = ReadRegister(strFEQ_ID_LOCAL(4), mintNRegD)
                strFEQ_STS(5) = ReadRegister(strFEQ_ID_LOCAL(5), mintNRegD)

                '====================================================
                '設備状態     →  搬送指示ﾃﾞｰﾀ
                '====================================================
                Dim intAryBunkai() As Integer = Nothing     '分解ﾃﾞｰﾀ
                Call GetHansouSiziData(strFEQ_STS, intAryBunkai)
                strFDENBUN &= "[入庫ﾓｰﾄﾞ  (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.InMode_01)), 5) & "]"
                strFDENBUN &= "[出庫ﾓｰﾄﾞ  (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.OutMode_01)), 5) & "]"
                strFDENBUN &= "[ﾍﾟｱ搬送   (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.PairHansou_01)), 5) & "]"
                strFDENBUN &= "[ﾌｫｰｸ2     (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork2_01)), 5) & "]"
                strFDENBUN &= "[ﾌｫｰｸ1     (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork1_01)), 5) & "]"
                strFDENBUN &= "[L/S番号   (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.LSNo_01)), 5) & "]"
                strFDENBUN &= "[ﾀﾞﾌﾞﾙﾘｰﾁ  (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.DoubleReach_01)), 5) & "]"
                strFDENBUN &= "[列        (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Retu_01)), 5) & "]"
                strFDENBUN &= "[号機      (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Gouki_01)), 5) & "]"
                strFDENBUN &= "[連        (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Ren_01)), 5) & "]"
                strFDENBUN &= "[ENDﾌﾗｸﾞ   (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.EndFlag_01)), 5) & "]"
                strFDENBUN &= "[入棚再設定(1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.IritanaRetry_01)), 5) & "]"
                strFDENBUN &= "[段        (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Dan_01)), 5) & "]"
                strFDENBUN &= "[ｱﾄﾞﾚｽ     (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Addrs_01)), 5) & "]"

                strFDENBUN &= "[入庫ﾓｰﾄﾞ  (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.InMode_02)), 5) & "]"
                strFDENBUN &= "[出庫ﾓｰﾄﾞ  (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.OutMode_02)), 5) & "]"
                strFDENBUN &= "[ﾍﾟｱ搬送   (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.PairHansou_02)), 5) & "]"
                strFDENBUN &= "[ﾌｫｰｸ2     (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork2_02)), 5) & "]"
                strFDENBUN &= "[ﾌｫｰｸ1     (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork1_02)), 5) & "]"
                strFDENBUN &= "[L/S番号   (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.LSNo_02)), 5) & "]"
                strFDENBUN &= "[ﾀﾞﾌﾞﾙﾘｰﾁ  (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.DoubleReach_02)), 5) & "]"
                strFDENBUN &= "[列        (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Retu_02)), 5) & "]"
                strFDENBUN &= "[号機      (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Gouki_02)), 5) & "]"
                strFDENBUN &= "[連        (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Ren_02)), 5) & "]"
                strFDENBUN &= "[ENDﾌﾗｸﾞ   (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.EndFlag_02)), 5) & "]"
                strFDENBUN &= "[入棚再設定(2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.IritanaRetry_02)), 5) & "]"
                strFDENBUN &= "[段        (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Dan_02)), 5) & "]"
                strFDENBUN &= "[ｱﾄﾞﾚｽ     (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Addrs_02)), 5) & "]"

                '====================================================
                'ﾛｸﾞ出力
                '====================================================
                Call AddToLog(MCIC_MSG_1051 & strFDENBUN)

            Case XEVENT_LOG_KUBUN_TRK_INOUT02
                '(入出庫ﾄﾗｯｷﾝｸﾞの場合)
                strFTEXT_ID = FTEXT_ID_JR_TRK_INOUT       'ﾃｷｽﾄID

                '====================================================
                'ﾄﾗｯｷﾝｸﾞ用のﾛｰｶﾙ設備IDを取得
                '====================================================
                Dim strFEQ_ID_LOCAL(5) As String
                Dim intAdrs As Integer = TO_INTEGER(Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 6, 6))
                strFEQ_ID_LOCAL(0) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs - 3, 6)
                strFEQ_ID_LOCAL(1) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs - 2, 6)
                strFEQ_ID_LOCAL(2) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs - 1, 6)
                strFEQ_ID_LOCAL(3) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs + 0, 6)
                strFEQ_ID_LOCAL(4) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs + 1, 6)
                strFEQ_ID_LOCAL(5) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs + 2, 6)

                '====================================================
                '設備状態           取得
                '====================================================
                Dim strFEQ_STS(5) As String     '設備状態
                strFEQ_STS(0) = ReadRegister(strFEQ_ID_LOCAL(0), mintNRegD)
                strFEQ_STS(1) = ReadRegister(strFEQ_ID_LOCAL(1), mintNRegD)
                strFEQ_STS(2) = ReadRegister(strFEQ_ID_LOCAL(2), mintNRegD)
                strFEQ_STS(3) = ReadRegister(strFEQ_ID_LOCAL(3), mintNRegD)
                strFEQ_STS(4) = ReadRegister(strFEQ_ID_LOCAL(4), mintNRegD)
                strFEQ_STS(5) = ReadRegister(strFEQ_ID_LOCAL(5), mintNRegD)

                '====================================================
                '設備状態     →  搬送指示ﾃﾞｰﾀ
                '====================================================
                Dim intAryBunkai() As Integer = Nothing     '分解ﾃﾞｰﾀ
                Call GetHansouSiziData(strFEQ_STS, intAryBunkai)
                strFDENBUN &= "[入庫ﾓｰﾄﾞ  (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.InMode_01)), 5) & "]"
                strFDENBUN &= "[出庫ﾓｰﾄﾞ  (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.OutMode_01)), 5) & "]"
                strFDENBUN &= "[ﾍﾟｱ搬送   (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.PairHansou_01)), 5) & "]"
                strFDENBUN &= "[ﾌｫｰｸ2     (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork2_01)), 5) & "]"
                strFDENBUN &= "[ﾌｫｰｸ1     (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork1_01)), 5) & "]"
                strFDENBUN &= "[L/S番号   (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.LSNo_01)), 5) & "]"
                strFDENBUN &= "[ﾀﾞﾌﾞﾙﾘｰﾁ  (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.DoubleReach_01)), 5) & "]"
                strFDENBUN &= "[列        (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Retu_01)), 5) & "]"
                strFDENBUN &= "[号機      (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Gouki_01)), 5) & "]"
                strFDENBUN &= "[連        (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Ren_01)), 5) & "]"
                strFDENBUN &= "[ENDﾌﾗｸﾞ   (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.EndFlag_01)), 5) & "]"
                strFDENBUN &= "[入棚再設定(1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.IritanaRetry_01)), 5) & "]"
                strFDENBUN &= "[段        (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Dan_01)), 5) & "]"
                strFDENBUN &= "[ｱﾄﾞﾚｽ     (1):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Addrs_01)), 5) & "]"

                strFDENBUN &= "[入庫ﾓｰﾄﾞ  (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.InMode_02)), 5) & "]"
                strFDENBUN &= "[出庫ﾓｰﾄﾞ  (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.OutMode_02)), 5) & "]"
                strFDENBUN &= "[ﾍﾟｱ搬送   (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.PairHansou_02)), 5) & "]"
                strFDENBUN &= "[ﾌｫｰｸ2     (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork2_02)), 5) & "]"
                strFDENBUN &= "[ﾌｫｰｸ1     (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Fork1_02)), 5) & "]"
                strFDENBUN &= "[L/S番号   (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.LSNo_02)), 5) & "]"
                strFDENBUN &= "[ﾀﾞﾌﾞﾙﾘｰﾁ  (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.DoubleReach_02)), 5) & "]"
                strFDENBUN &= "[列        (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Retu_02)), 5) & "]"
                strFDENBUN &= "[号機      (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Gouki_02)), 5) & "]"
                strFDENBUN &= "[連        (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Ren_02)), 5) & "]"
                strFDENBUN &= "[ENDﾌﾗｸﾞ   (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.EndFlag_02)), 5) & "]"
                strFDENBUN &= "[入棚再設定(2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.IritanaRetry_02)), 5) & "]"
                strFDENBUN &= "[段        (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Dan_02)), 5) & "]"
                strFDENBUN &= "[ｱﾄﾞﾚｽ     (2):" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(HansouSiziArray.Addrs_02)), 5) & "]"

                '====================================================
                'ﾛｸﾞ出力
                '====================================================
                Call AddToLog(MCIC_MSG_1051 & strFDENBUN)

                'Case XEVENT_LOG_KUBUN_TRK_RTN
                '    '(RTNﾄﾗｯｷﾝｸﾞの場合)
                '    strFTEXT_ID = FTEXT_ID_JR_TRK_RTN       'ﾃｷｽﾄID

                '    '====================================================
                '    'RTNﾄﾗｯｷﾝｸﾞ用の設備IDを取得
                '    '====================================================
                '    Dim strFEQ_ID_LOCAL(3) As String
                '    Dim intAdrs As Integer = TO_INTEGER(Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 6, 6))
                '    strFEQ_ID_LOCAL(0) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs + 0, 6)
                '    strFEQ_ID_LOCAL(1) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs + 1, 6)
                '    strFEQ_ID_LOCAL(2) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs + 2, 6)
                '    strFEQ_ID_LOCAL(3) = Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 5) & ZERO_PAD(intAdrs + 3, 6)

                '    '====================================================
                '    '設備状態           取得
                '    '====================================================
                '    Dim strFEQ_STS(3) As String     '設備状態
                '    strFEQ_STS(0) = ReadRegister(strFEQ_ID_LOCAL(0), mintNRegD)
                '    strFEQ_STS(1) = ReadRegister(strFEQ_ID_LOCAL(1), mintNRegD)
                '    strFEQ_STS(2) = ReadRegister(strFEQ_ID_LOCAL(2), mintNRegD)
                '    strFEQ_STS(3) = ReadRegister(strFEQ_ID_LOCAL(3), mintNRegD)

                '    '====================================================
                '    '設備状態     →  搬送指示ﾃﾞｰﾀ
                '    '====================================================
                '    Dim intAryBunkai() As Integer = Nothing     '分解ﾃﾞｰﾀ
                '    Call GetPLCRTNData(strFEQ_STS, intAryBunkai)
                '    strFDENBUN &= "[入庫ﾓｰﾄﾞ     :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.InMode)), 5) & "]"
                '    strFDENBUN &= "[出庫ﾓｰﾄﾞ     :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.OutMode)), 5) & "]"
                '    strFDENBUN &= "[ﾍﾟｱ搬送      :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.PairHansou)), 5) & "]"
                '    strFDENBUN &= "[ﾌｫｰｸ2        :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Fork2)), 5) & "]"
                '    strFDENBUN &= "[ﾌｫｰｸ1        :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Fork1)), 5) & "]"
                '    strFDENBUN &= "[L/S番号      :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.LSNo)), 5) & "]"
                '    strFDENBUN &= "[ﾀﾞﾌﾞﾙﾘｰﾁ     :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.DoubleReach)), 5) & "]"
                '    strFDENBUN &= "[列           :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Retu)), 5) & "]"
                '    strFDENBUN &= "[号機         :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Gouki)), 5) & "]"
                '    strFDENBUN &= "[連           :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Ren)), 5) & "]"
                '    strFDENBUN &= "[ENDﾌﾗｸﾞ      :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.EndFlag)), 5) & "]"
                '    strFDENBUN &= "[入棚再設定   :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.IritanaRetry)), 5) & "]"
                '    strFDENBUN &= "[段           :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Dan)), 5) & "]"
                '    strFDENBUN &= "[ｱﾄﾞﾚｽ        :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Addrs)), 5) & "]"
                '    strFDENBUN &= "[子           :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Ko)), 5) & "]"
                '    strFDENBUN &= "[親           :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Oya)), 5) & "]"
                '    strFDENBUN &= "[在籍         :" & SPC_PAD_RIGHT_SJIS(TO_STRING(intAryBunkai(RTNSiziArray.Zaiseki)), 5) & "]"

                '    '====================================================
                '    'ﾛｸﾞ出力
                '    '====================================================
                '    Call AddToLog(MCIC_MSG_1051 & strFDENBUN)

            Case Else
                '(その他)
                Exit Sub

        End Select


        '********************************************
        '設備通信ﾛｸﾞ        追加
        '********************************************
        Call AddDBRecvLog_LOG(strFTEXT_ID _
                            , strFDENBUN _
                            , "" _
                            , objTSTS_EQ_CTRL.FEQ_ID _
                            )


    End Sub
#End Region


End Class
