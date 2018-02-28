'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】MCIﾒｲﾝｸﾗｽ(車輌ｺﾝﾄﾛｰﾗ通信)
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports  "
Imports JobCommon
Imports MateCommon.clsConst
Imports MateCommon
Imports UserProcess
Imports spi.WinSAM
Imports spi.WinSAM.Data
#End Region

Public Class clsMCIMain

#Region "  共通変数02           "

    '==================================================
    '共通ｵﾌﾞｼﾞｪｸﾄ
    '==================================================
    Private mobjWinSAM As spi.WinSAM.WsNETAPI           'WsNETAPIクラス
    'Private mobjSockClient As clsSocketClient           'ｿｹｯﾄ通信ｸﾗｽ(ｸﾗｲｱﾝﾄ)
    'Private mobjSockListener As clsSocketListener       'ｿｹｯﾄ通信ｸﾗｽ(ﾘｽﾅｰ)
    Private mobjEQSendTelBuff As TBL_TLIF_TRNS_SEND    '電文送信ﾊﾞｯﾌｧ
    'Private mobjEQSendResBuff As TBL_TLIF_TRNS_SEND    '応答電文送信ﾊﾞｯﾌｧ
    Private mobjGetTelegram As clsGetTelegram           '電文用ﾃｷｽﾄ取得ｸﾗｽ

    '==================================================
    '内部変数
    '==================================================
    'EQへのｿｹｯﾄ用
    Private mstrEQSockSendAddress As String        'EQ送信先ｱﾄﾞﾚｽ
    Private mintEQSockSendPort As Integer          'EQ送信先ﾎﾟｰﾄNo
    Private mintEQSockSendTimeOut As Integer       'EQ応答ｿｹｯﾄ待機時間 (ms)
    Private mintEQSockETXSendTimeOut As Integer    'EQ定周期ETXｿｹｯﾄ送信時間 (ms)
    Private mintEQSockETXRecvTimeOut As Integer    'EQ定周期ETXｿｹｯﾄ受信時間 (ms)
    Private mintEQSockSendRetry As Integer         'EQ送信ﾘﾄﾗｲ回数(回)
    Private mintEQSockConnTimeOut As Integer       'EQｺﾈｸｼｮﾝ ﾘﾄﾗｲﾀｲﾑｱｳﾄ(ms)
    'EQからのｿｹｯﾄ用
    Private mintEQSockRecvPort As Integer          'EQ受信ﾎﾟｰﾄNo
    'EQ電文受信用
    Private mintEQTelegramInforStartPosition As Integer     '「長さ情報」が入っている位置
    Private mintEQTelegramInforLength As Integer            '「長さ情報」の桁数
    Private mintEQTelegramHeaderLength As Integer           'ﾍｯﾀﾞｰ部分の桁数

    'WinSAM用
    Private mstrWinSAMOpenPipeName As String        'ｵｰﾌﾟﾝPIPE名
    Private mstrWinSAMSendTermName As String        '送信端末名


    'その他
    Private mintSendCount As Integer            '再送信回数
    Private mdtmBeforeRecvTime As Date          '前回受信日時
    Private mdtmBeforeSendTime As Date          '前回送信日時
    Private mbytRecvTelBuffClient() As Byte     'ｿｹｯﾄ受信ﾊﾞｯﾌｧ(ｸﾗｲｱﾝﾄ)
    Private mbytRecvTelBuffListener() As Byte   'ｿｹｯﾄ受信ﾊﾞｯﾌｧ(ﾘｽﾅｰ)
    Private mintResponsWait As Integer          '応答待ちﾌﾗｸﾞ
    Private mdtmBeforeConnTime As Date          '前回接続日時
    'Private mblnConnect As Boolean              'ｿｹｯﾄ接続ﾌﾗｸﾞ
    'Private mintSockRecvMode As Integer         'ｿｹｯﾄ受信ﾓｰﾄﾞ


    '==================================================
    '固定値
    '==================================================
    Public Const MAX_LEN As Integer = 3000      'USTの設定で3000となっている


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
    Private mintSendSleep As Integer                '通信ﾘｾｯﾄ時のｽﾘｰﾌﾟ時間(ms)  連続してﾘｾｯﾄを行わない為
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
            'mobjSockClient.intDebugFlag = Value                   'ｿｹｯﾄ通信ｸﾗｽ
            'mobjSockListener.intDebugFlag = Value                 'ｿｹｯﾄ通信ｸﾗｽ
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
                'DB送信ﾊﾞｯﾌｧ検索 & 電文送信     処理
                '*****************************************************
                Call MCIA_100001()


                '*****************************************************
                '電文受信確認
                '*****************************************************
                Dim strRecvText As String = ""          '受信電文
                Dim strFDENBUN_PRM1 As String = Nothing '電文ﾊﾟﾗﾒｰﾀ1
                Dim strFDENBUN_PRM2 As String = Nothing '電文ﾊﾟﾗﾒｰﾀ2
                Call RecvDataEQLintener(strRecvText, strFDENBUN_PRM1, strFDENBUN_PRM2)


                '*****************************************************
                '電文受信       処理
                '*****************************************************
                Call MCIA_100002(strRecvText, strFDENBUN_PRM1, strFDENBUN_PRM2)


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
            mbytRecvTelBuffClient = Nothing                     'ｿｹｯﾄ受信ﾊﾞｯﾌｧ(ｸﾗｲｱﾝﾄ)
            mbytRecvTelBuffListener = Nothing                   'ｿｹｯﾄ受信ﾊﾞｯﾌｧ(ﾘｽﾅｰ)
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
        'mobjEQSendResBuff = New TBL_TLIF_TRNS_SEND(mobjOwner, Nothing, Nothing)    '応答電文送信ﾊﾞｯﾌｧ
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
        mintSendSleep = TO_STRING(objConfig.GET_INFO(GKEY_MCI_SEND_SLEEP))                          '通信ﾘｾｯﾄ時のｽﾘｰﾌﾟ時間(ms)  連続してﾘｾｯﾄを行わない為


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
        'EQへのｿｹｯﾄ用
        mstrEQSockSendAddress = TO_STRING(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_ADDRESS))                  'EQ送信先ｱﾄﾞﾚｽ
        mintEQSockSendPort = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_PORT))                       'EQ送信先ﾎﾟｰﾄNo
        mintEQSockSendTimeOut = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_TIME_OUT))                'EQ応答ｿｹｯﾄ待機時間 (ms)
        mintEQSockSendRetry = TO_STRING(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_RETRY))                      'EQ送信ﾘﾄﾗｲ回数(回)
        mintEQSockConnTimeOut = TO_STRING(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_CONN_TIME_OUT))            'EQｺﾈｸｼｮﾝ ﾘﾄﾗｲﾀｲﾑｱｳﾄ(ms)
        'EQからのｿｹｯﾄ用
        mintEQSockRecvPort = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_SOCK_RECV_PORT))                       'EQ受信ﾎﾟｰﾄNo
        'EQ電文受信用
        mintEQTelegramInforStartPosition = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_TELEGRAM_INFOR_START_POSITION))        '「長さ情報」が入っている位置
        mintEQTelegramInforLength = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_TELEGRAM_INFOR_LENGTH))                       '「長さ情報」の桁数
        mintEQTelegramHeaderLength = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_TELEGRAM_HEADER_LENGTH))                     'ﾍｯﾀﾞｰ部分の桁数
        'WinSAM用
        mstrWinSAMOpenPipeName = TO_STRING(objConfig.GET_INFO(GKEY_WINSAM_OPEN_PIPE_NAME))        'ｵｰﾌﾟﾝPIPE名
        mstrWinSAMSendTermName = TO_STRING(objConfig.GET_INFO(GKEY_WINSAM_SEND_TERM_NAME))        '送信端末名


        '****************************************************
        'ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ   ｾｯﾄ
        '****************************************************
        'mobjSockClient = New clsSocketClient(mobjOwner)
        'mobjSockListener = New clsSocketListener(mobjOwner)
        'mobjSockClient.strAddress = mstrEQSockSendAddress
        'mobjSockClient.intPortNo = mintEQSockSendPort
        'mobjSockClient.Connect()


        '****************************************************
        'WinSAM         定義
        '****************************************************
        mobjWinSAM = New spi.WinSAM.WsNETAPI()
        Try
            Dim intWinRet As Integer                            'WinSAM戻値
            Dim strSock As New System.Text.StringBuilder(256)   'ﾊﾟｲﾌﾟ名
            Dim bytOpenMode As Byte = WsWSID.SYNOUT             'ﾓｰﾄﾞ

            '// nsp_open:WinSAMとの入出力を開始します。
            '// パラメータ
            '//   inpath
            '//     WinSAMからのデーターを受信するパイプ名を指定します。
            '//     これはWinSAMシステム定義で指定した 「入力用名前付きパイプ」か
            '//     非同期出力で指定した「非同期完了受信パイプ名」と同一でなければなりません。
            '//     本プロセスが受信を行わない（出力専用）場合は、nullを入力することができます。
            '//   mode
            '//     出力モードを設定します。（引数値：WsWSID.NONOUT,WsWSID.SYNOUT,WsWSID.ASYOUT)
            '// 戻り値
            '//   リトライにより継続可能なエラー番号
            intWinRet = mobjWinSAM.nsp_open(strSock.Append(mstrWinSAMOpenPipeName), bytOpenMode)
            If intWinRet <> WsWSRC.NORMAL Then     '// 復帰情報：正常終了(0)以外
                Call AddToLog("nsp_open に失敗しました。RC =" & Str(intWinRet) & " : 詳細コード =" + Str(mobjWinSAM.ns_GetLastError))
            Else
                Call AddToLog("nsp_open が成功しました。")
            End If
        Catch ex As Exception
            Call ComError(ex)
        End Try


        '↑↑↑↑固有部分
        '**********************************************************************************************************************


        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:N.Dounoshita 2012/06/27 毎回ｵｰﾌﾟﾝｸﾛｰｽﾞ処理による修正

        '****************************************************
        '通信ｵｰﾌﾟﾝ
        '****************************************************
        'Call OpenClient()
        'Call OpenListener()

        '↑↑↑↑↑↑************************************************************************************************************


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
#Region "  通信ｵｰﾌﾟﾝ(ｿｹｯﾄｸﾗｲｱﾝﾄ)            "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 通信ｵｰﾌﾟﾝ
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub OpenClient()


        ''****************************************************
        ''ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ   ｾｯﾄ
        ''****************************************************
        'mobjSockClient.strAddress = mstrEQSockSendAddress
        'mobjSockClient.intPortNo = mintEQSockSendPort
        'mobjSockClient.Connect()
        'If mobjSockClient.udtRet = clsSocketClient.RetCode.OK Then
        '    'mblnConnect = True
        '    Call AddToLog(MCIA_MSG_001)
        'Else
        '    'mblnConnect = False
        '    Call AddToLog(MCIA_MSG_003)
        '    Call ErrorAdd(mstrFMSG_ID_ERR_USER, ERR_MSG_01, MCIA_MSG_003)
        '    Call StopCommunication()
        'End If


    End Sub
#End Region
#Region "  通信ｸﾛｰｽﾞ(ｿｹｯﾄｸﾗｲｱﾝﾄ)            "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 通信ｸﾛｰｽﾞ
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub CloseClient()
        Try


            ''****************************************************
            ''ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ   ｾｯﾄ
            ''****************************************************
            'mobjSockClient.ShutDown()
            'Call AddToLog(MCIA_MSG_002)


            '****************************************************
            'WinSAM         ｸﾛｰｽﾞ
            '****************************************************
            '// nsp_close:WinSAMとの入出力を終了します。
            '// 戻り値
            '//   リトライにより継続可能なエラー番号
            Dim intWinRet As Integer                                    'WinSAM戻値
            intWinRet = mobjWinSAM.nsp_close()
            If intWinRet = WsWSRC.NORMAL Then     '// 復帰情報：正常終了(0)
                Call AddToLog("nsp_close 処理が正常に終了しました。")
            Else
                Call AddToLog("nsp_close エラー RC =" & Str(intWinRet) & " : 詳細コード = " & Str(mobjWinSAM.ns_GetLastError))
            End If


        Catch ex As Exception
            'NOP(失敗しても特に問題なし)
        End Try
    End Sub
#End Region
#Region "  通信ｵｰﾌﾟﾝ(ｿｹｯﾄﾘｽﾅｰ)              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 通信ｵｰﾌﾟﾝ
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub OpenListener()


        ''****************************************************
        ''ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ   ｾｯﾄ
        ''****************************************************
        'mobjSockListener.intPortNo = mintEQSockRecvPort
        'mobjSockListener.Listen()
        'If mobjSockListener.udtRET = clsSocketListener.RetCode.OK Then
        '    'mblnConnect = True
        '    Call AddToLog(MCIA_MSG_006)
        'Else
        '    'mblnConnect = False
        '    Call AddToLog(MCIA_MSG_008)
        '    Call ErrorAdd(mstrFMSG_ID_ERR_USER, ERR_MSG_01, MCIA_MSG_008)
        '    Call StopCommunication()
        'End If


    End Sub
#End Region
#Region "  通信ｸﾛｰｽﾞ(ｿｹｯﾄﾘｽﾅｰ)              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 通信ｸﾛｰｽﾞ
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub CloseListener()
        Try


            ''****************************************************
            ''ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ   ｾｯﾄ
            ''****************************************************
            'mobjSockListener.Shutdown()
            'Call AddToLog(MCIA_MSG_007)


        Catch ex As Exception
            'NOP(失敗しても特に問題なし)
        End Try
    End Sub
#End Region

#Region "  ﾃﾞｰﾀ送信(ｿｹｯﾄｸﾗｲｱﾝﾄ)             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ送信(ｿｹｯﾄｸﾗｲｱﾝﾄ)
    ''' </summary>
    ''' <param name="strSendText">送信ﾃｷｽﾄ</param>
    ''' <param name="objTLIF_TRNS_SEND">搬送制御送信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <returns>正常終了の有無</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function SendDataEQClient(ByVal strSendText As String _
                                   , ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND _
                                   ) As RetCode
        'Try
        '    Dim intRet As RetCode = RetCode.OK


        '    '*****************************************************
        '    '受信ﾊﾞｯﾌｧ初期化
        '    '*****************************************************
        '    mbytRecvTelBuffClient = Nothing         'ｿｹｯﾄ受信ﾊﾞｯﾌｧ(ｸﾗｲｱﾝﾄ)


        '    '*****************************************************
        '    '連続して送信出来ない為Sleep
        '    '*****************************************************
        '    If 0 < mintSendSleep Then
        '        '(ｽﾘｰﾌﾟ時間がｾｯﾄされている場合)

        '        Dim objDiff As TimeSpan = mdtmBeforeRecvTime.AddMilliseconds(mintSendSleep) - Now
        '        'Dim objDiff As TimeSpan = mdtmBeforeSendTime.AddMilliseconds(mintSendSleep) - Now
        '        If 0 < objDiff.TotalMilliseconds Then
        '            Call Threading.Thread.Sleep(objDiff.TotalMilliseconds)
        '        End If

        '    End If


        '    '*****************************************************
        '    'ﾃｷｽﾄﾃﾞｰﾀ送信
        '    '*****************************************************
        '    For II As Integer = 1 To mintEQSockSendRetry
        '        '(ﾙｰﾌﾟ:ﾘﾄﾗｲ回数)

        '        mobjSockClient.bytSendText = mobjGetTelegram.MakeTelegramDataLength101(strSendText, mintEQTelegramInforLength)

        '        Try
        '            mdtmBeforeSendTime = Now                                        '前回送信日時   ｾｯﾄ
        '            Call OpenClient()
        '            mobjSockClient.Send()
        '            If mobjSockClient.udtRet = clsSocketClient.RetCode.OK Then Exit For
        '        Catch ex As Exception
        '        End Try
        '    Next
        '    If mobjSockClient.udtRet = clsSocketClient.RetCode.OK Then
        '        '(成功した場合)
        '    Else
        '        '(失敗した場合)
        '        Call AddToLog(MCIA_MSG_022 & strSendText)
        '        intRet = RetCode.NG
        '        Return intRet
        '    End If


        '    '*****************************************************
        '    'ﾛｸﾞ出力
        '    '*****************************************************
        '    '===========================================
        '    'ﾃｷｽﾄﾛｸﾞ追加
        '    '===========================================
        '    Call AddToLog(MCIA_MSG_021 & strSendText)

        '    '===========================================
        '    'ﾃｷｽﾄID取得
        '    '===========================================
        '    Dim strFTEXT_ID As String = ""
        '    strFTEXT_ID = MID_SJIS(strSendText, 1, 16)

        '    '===========================================
        '    '設備通信ﾛｸﾞ追加
        '    '===========================================
        '    Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)   '設備通信ﾛｸﾞ
        '    objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '設備ID
        '    objTLOG_EQ.FHASSEI_DT = Now                         '発生日時
        '    objTLOG_EQ.FDIRECTION = FDIRECTION_SSEND             '方向
        '    objTLOG_EQ.FTEXT_ID = objTLIF_TRNS_SEND.FTEXT_ID    'ﾃｷｽﾄID
        '    objTLOG_EQ.FTRNS_SERIAL = DEFAULT_STRING            '搬送ｼﾘｱﾙ№
        '    objTLOG_EQ.FPALLET_ID = DEFAULT_STRING              'ﾊﾟﾚｯﾄID
        '    objTLOG_EQ.FDENBUN = strSendText                    '通信電文
        '    objTLOG_EQ.FRES_CD_EQ = DEFAULT_STRING              '設備応答ｺｰﾄﾞ
        '    objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '追加


        '    Return intRet
        'Catch ex As Exception
        '    Call ComError(ex)
        '    Return RetCode.NG

        'End Try
    End Function
#End Region
#Region "  ﾃﾞｰﾀ受信(ｿｹｯﾄｸﾗｲｱﾝﾄ)             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ受信(ｿｹｯﾄｸﾗｲｱﾝﾄ)
    ''' </summary>
    ''' <param name="strRecvText">受信ﾃｷｽﾄ</param>
    ''' <remarks>正常終了の有無</remarks>
    '''*******************************************************************************************************************
    Public Sub RecvDataEQClient(ByRef strRecvText As String)


        ''****************************************
        ''ｿｹｯﾄ受信
        ''****************************************
        'If mobjSockClient.blnIsConnect = False Then Exit Sub
        'mobjSockClient.Receive()


        ''****************************************
        ''電文部分を抽出 & ｿｹｯﾄ受信ﾊﾞｯﾌｧ更新
        ''****************************************
        'If IsNotNull(mobjSockClient.bytRecvText) Then
        '    '(電文を受信した場合)

        '    '****************************************
        '    'ｿｹｯﾄ受信ﾊﾞｯﾌｧに結合
        '    '****************************************
        '    If IsNull(mbytRecvTelBuffClient) Then
        '        mbytRecvTelBuffClient = mobjSockClient.bytRecvText
        '    Else
        '        ReDim Preserve mbytRecvTelBuffClient(mbytRecvTelBuffClient.Length + mobjSockClient.bytRecvText.Length - 1)
        '        mobjSockClient.bytRecvText.CopyTo(mbytRecvTelBuffClient, mbytRecvTelBuffClient.Length)
        '    End If


        '    '****************************************
        '    '電文部分を抽出 & ｿｹｯﾄ受信ﾊﾞｯﾌｧ更新
        '    '****************************************
        '    strRecvText = mobjGetTelegram.GetTelegramDataLength101(mbytRecvTelBuffClient _
        '                                                         , mintEQTelegramInforLength _
        '                                                         )
        '    If IsNotNull(strRecvText) Then
        '        Call AddToLog(MCIA_MSG_011 & strRecvText) '電文取得ﾛｸﾞ出力
        '    End If

        'End If


    End Sub
#End Region
#Region "  ﾃﾞｰﾀ送信(ｿｹｯﾄﾘｽﾅｰ)               "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ送信(ｿｹｯﾄﾘｽﾅｰ)
    ''' </summary>
    ''' <param name="strSendText">送信ﾃｷｽﾄ</param>
    ''' <returns>正常終了の有無</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function SendDataEQLintener(ByVal strSendText As String _
                                     , ByVal strFTEXT_ID As String _
                                     ) As RetCode
        Try
            Dim intRet As RetCode = RetCode.OK


            '*****************************************************
            '送信電文ﾊﾞｲﾄ配列作成
            '*****************************************************
            Dim strArySendText() As String = Split(strSendText, "_")
            Dim bytArySendText(UBound(strArySendText)) As Byte
            For ii As Integer = 0 To UBound(strArySendText)
                bytArySendText(ii) = Change16To10(strArySendText(ii))
            Next


            '*****************************************************
            'ﾃｷｽﾄﾃﾞｰﾀ送信
            '*****************************************************
            Dim intWinRet As Integer                                    'WinSAM戻値
            Dim destpid As New System.Text.StringBuilder(32)            '入力パイプ識別名
            Dim originpid As New System.Text.StringBuilder(32)          '相手先端末名
            Dim cpathname As New System.Text.StringBuilder(128)         '完了ﾃﾞｰﾀを入力する名前付きﾊﾟｲﾌﾟ名称
            Dim objwsiData As New spi.WinSAM.Data.WsNETData(bytArySendText.Length)      '取得ﾃﾞｰﾀ
            objwsiData.Command = 0
            objwsiData.Control = 0
            objwsiData.Flow = 0
            objwsiData.Echo.Append("1111")
            objwsiData.Length = bytArySendText.Length
            For ii As Integer = 0 To UBound(bytArySendText)
                '(ﾙｰﾌﾟ:ﾃﾞｰﾀ)
                objwsiData.Data(ii) = bytArySendText(ii)
            Next

            '// nsp_aout:端末非同期出力処理
            '// パラメータ
            '//   destpid
            '//     [IN] データを出力する相手先端末名称を指定します。
            '//   originpid
            '//     [IN] 出力データの発信元の名前を指定します。
            '//   oData
            '//     [IN] WsNETDataクラス。送信データーおよび送信データーの特性
            '//   compap
            '//     [IN] 完了情報を受信するパイプ名
            '// 戻り値
            '//   [IN] リトライにより継続可能なエラー番号
            '//
            intWinRet = mobjWinSAM.nsp_sout(destpid.Append(mstrWinSAMSendTermName), originpid.Append("aaa"), objwsiData)
            'intWinRet = mobjWinSAM.nsp_aout(destpid.Append("term1"), originpid.Append("aaa"), objwsiData, cpathname)
            If intWinRet = WsWSRC.NORMAL Then     '// 復帰情報：正常終了(0)以外
                '(正常完了)
                If objwsiData.TosID <> 0 Then Call AddToLog("nsp_sout 処理に失敗しました。TosID =" & Str(objwsiData.TosID) & " : 詳細コード =" & Str(mobjWinSAM.ns_GetLastError))
                Dim bEtype As Byte
                Dim bEtos As Byte
                Dim nEno As Short
                mobjWinSAM.ns_GetErrInfo(bEtype, bEtos, nEno)
                Call AddToLog("詳細コード ; Type = " & Change10To16(bEtype, 2) & " Tos = " & Change10To16(bEtos, 2) & " No = " & Str(nEno))
            Else
                '(異常完了)
                Call AddToLog("nsp_sout 処理に失敗しました。RC =" & Str(intWinRet) & " : 詳細コード =" & Str(mobjWinSAM.ns_GetLastError))
            End If


            '*****************************************************
            'ﾛｸﾞ出力
            '*****************************************************
            '===========================================
            'ﾃｷｽﾄﾛｸﾞ追加
            '===========================================
            Call AddToLog(MCIA_MSG_021 & strSendText)

            ''===========================================
            ''ﾃｷｽﾄID取得
            ''===========================================
            'Dim strFTEXT_ID As String = ""
            'strFTEXT_ID = FTEXT_ID_JS_CARD01

            '===========================================
            '設備通信ﾛｸﾞ追加
            '===========================================
            Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)   '設備通信ﾛｸﾞ
            objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '設備ID
            objTLOG_EQ.FHASSEI_DT = Now                         '発生日時
            objTLOG_EQ.FDIRECTION = FDIRECTION_SSEND            '方向
            objTLOG_EQ.FTEXT_ID = strFTEXT_ID                   'ﾃｷｽﾄID
            objTLOG_EQ.FTRNS_SERIAL = DEFAULT_STRING            '搬送ｼﾘｱﾙ№
            objTLOG_EQ.FPALLET_ID = DEFAULT_STRING              'ﾊﾟﾚｯﾄID
            objTLOG_EQ.FDENBUN = strSendText                    '通信電文
            objTLOG_EQ.FRES_CD_EQ = DEFAULT_STRING              '設備応答ｺｰﾄﾞ
            objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '追加


            Return intRet
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
#Region "  ﾃﾞｰﾀ送信(ｿｹｯﾄﾘｽﾅｰ)_Backup        "
    '''''''*******************************************************************************************************************
    ''''''' <summary>
    ''''''' ﾃﾞｰﾀ送信(ｿｹｯﾄﾘｽﾅｰ)
    ''''''' </summary>
    ''''''' <param name="strSendText">送信ﾃｷｽﾄ</param>
    ''''''' <param name="objTLIF_TRNS_SEND">搬送制御送信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''''''' <returns>正常終了の有無</returns>
    ''''''' <remarks></remarks>
    '''''''*******************************************************************************************************************
    '' ''Public Function SendDataEQLintener(ByVal strSendText As String _
    '' ''                                 , ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND _
    '' ''                                 ) As RetCode
    '' ''    'Try
    '' ''    '    Dim intRet As RetCode = RetCode.OK


    '' ''    '    '*****************************************************
    '' ''    '    '連続して送信出来ない為Sleep
    '' ''    '    '*****************************************************
    '' ''    '    If 0 < mintSendSleep Then
    '' ''    '        '(ｽﾘｰﾌﾟ時間がｾｯﾄされている場合)

    '' ''    '        Dim objDiff As TimeSpan = mdtmBeforeRecvTime.AddMilliseconds(mintSendSleep) - Now
    '' ''    '        'Dim objDiff As TimeSpan = mdtmBeforeSendTime.AddMilliseconds(mintSendSleep) - Now
    '' ''    '        If 0 < objDiff.TotalMilliseconds Then
    '' ''    '            Call Threading.Thread.Sleep(objDiff.TotalMilliseconds)
    '' ''    '        End If

    '' ''    '    End If


    '' ''    '    '*****************************************************
    '' ''    '    'ﾃｷｽﾄﾃﾞｰﾀ送信
    '' ''    '    '*****************************************************
    '' ''    '    For II As Integer = 1 To mintEQSockSendRetry
    '' ''    '        '(ﾙｰﾌﾟ:ﾘﾄﾗｲ回数)

    '' ''    '        mobjSockListener.bytSendText = mobjGetTelegram.MakeTelegramDataLength101(strSendText, mintEQTelegramInforLength)

    '' ''    '        Try
    '' ''    '            mdtmBeforeSendTime = Now                                        '前回送信日時   ｾｯﾄ
    '' ''    '            mobjSockListener.Send()
    '' ''    '            If mobjSockListener.udtRET = clsSocketListener.RetCode.OK Then Exit For
    '' ''    '        Catch ex As Exception
    '' ''    '        End Try
    '' ''    '    Next
    '' ''    '    If mobjSockListener.udtRET = clsSocketListener.RetCode.OK Then
    '' ''    '        '(成功した場合)
    '' ''    '    Else
    '' ''    '        '(失敗した場合)
    '' ''    '        Call AddToLog(MCIA_MSG_022 & strSendText)
    '' ''    '        intRet = RetCode.NG
    '' ''    '        Return intRet
    '' ''    '    End If


    '' ''    '    '*****************************************************
    '' ''    '    'ﾛｸﾞ出力
    '' ''    '    '*****************************************************
    '' ''    '    '===========================================
    '' ''    '    'ﾃｷｽﾄﾛｸﾞ追加
    '' ''    '    '===========================================
    '' ''    '    Call AddToLog(MCIA_MSG_021 & strSendText)

    '' ''    '    '===========================================
    '' ''    '    'ﾃｷｽﾄID取得
    '' ''    '    '===========================================
    '' ''    '    Dim strFTEXT_ID As String = ""
    '' ''    '    strFTEXT_ID = MID_SJIS(strSendText, 1, 16)

    '' ''    '    '===========================================
    '' ''    '    '設備通信ﾛｸﾞ追加
    '' ''    '    '===========================================
    '' ''    '    Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)   '設備通信ﾛｸﾞ
    '' ''    '    objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '設備ID
    '' ''    '    objTLOG_EQ.FHASSEI_DT = Now                         '発生日時
    '' ''    '    objTLOG_EQ.FDIRECTION = FDIRECTION_SSEND             '方向
    '' ''    '    objTLOG_EQ.FTEXT_ID = objTLIF_TRNS_SEND.FTEXT_ID    'ﾃｷｽﾄID
    '' ''    '    objTLOG_EQ.FTRNS_SERIAL = DEFAULT_STRING            '搬送ｼﾘｱﾙ№
    '' ''    '    objTLOG_EQ.FPALLET_ID = DEFAULT_STRING              'ﾊﾟﾚｯﾄID
    '' ''    '    objTLOG_EQ.FDENBUN = strSendText                    '通信電文
    '' ''    '    objTLOG_EQ.FRES_CD_EQ = DEFAULT_STRING              '設備応答ｺｰﾄﾞ
    '' ''    '    objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '追加


    '' ''    '    Return intRet
    '' ''    'Catch ex As Exception
    '' ''    '    Call ComError(ex)
    '' ''    '    Return RetCode.NG

    '' ''    'End Try
    '' ''End Function
#End Region
#Region "  ﾃﾞｰﾀ受信(ｿｹｯﾄﾘｽﾅｰ)               "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ受信(ｿｹｯﾄﾘｽﾅｰ)
    ''' </summary>
    ''' <param name="strRecvText">受信ﾃｷｽﾄ</param>
    ''' <remarks>正常終了の有無</remarks>
    '''*******************************************************************************************************************
    Public Sub RecvDataEQLintener(ByRef strRecvText As String _
                                , ByRef strFDENBUN_PRM1 As String _
                                , ByRef strFDENBUN_PRM2 As String _
                                )


        '****************************************
        'ｿｹｯﾄ受信
        '****************************************
        Dim intWinRet As Integer                                    'WinSAM戻値
        Dim destpid As New System.Text.StringBuilder(32)            '入力パイプ識別名
        Dim originpid As New System.Text.StringBuilder(32)          '相手先端末名
        Dim objwsiData As New spi.WinSAM.Data.WsNETData(MAX_LEN)    '取得ﾃﾞｰﾀ

        '// nsp_input:プロセスが端末からの入力データまたは、非同期出力時の
        '// 出力完了データをWinSAMから読み込む処理。
        '// パラメータ
        '//   destpid
        '//     [OUT]データを出力する相手先端末名称を指定します。
        '//   originpid
        '//     [OUT] 出力データの発信元の名前を指定します。
        '//   iData
        '//     [OUT] WsNETTermDataクラス。受信データーおよび受信データーの特性
        '//   WSec
        '//     待ち時間
        '// 戻り値
        '//   リトライにより継続可能なエラー番号
        intWinRet = mobjWinSAM.nsp_input(destpid, originpid, objwsiData, 1)


        '****************************************
        '電文部分を抽出 & ｿｹｯﾄ受信ﾊﾞｯﾌｧ更新
        '****************************************
        If intWinRet = WsWSRC.NORMAL Then
            '(電文を受信した場合)

            If 0 < objwsiData.Length Then
                '(ﾃﾞｰﾀを受信した場合)


                ''****************************************
                ''ｿｹｯﾄ受信ﾊﾞｯﾌｧに結合
                ''****************************************
                'If IsNull(mbytRecvTelBuffListener) Then
                '    mbytRecvTelBuffListener = mobjSockListener.bytRecvText
                'Else
                '    ReDim Preserve mbytRecvTelBuffListener(mbytRecvTelBuffListener.Length + mobjSockListener.bytRecvText.Length - 1)
                '    mobjSockListener.bytRecvText.CopyTo(mbytRecvTelBuffListener, mbytRecvTelBuffListener.Length - 1)
                'End If


                '****************************************
                '電文部分を抽出 & ｿｹｯﾄ受信ﾊﾞｯﾌｧ更新
                '****************************************
                Dim bytAryData(objwsiData.Length - 1) As Byte
                For ii As Integer = 0 To UBound(bytAryData)
                    bytAryData(ii) = objwsiData.Data(ii)
                Next
                strRecvText = mobjGetTelegram.GetTelegramDataLength101(bytAryData _
                                                                     , strFDENBUN_PRM1 _
                                                                     , strFDENBUN_PRM2 _
                                                                     )
                'strRecvText = mobjGetTelegram.GetTelegramDataLength101(mbytRecvTelBuffListener _
                '                                                     , strFDENBUN_PRM1 _
                '                                                     , strFDENBUN_PRM2 _
                '                                                     )
                If IsNotNull(strRecvText) Then
                    Call AddToLog(MCIA_MSG_011 & strRecvText) '電文取得ﾛｸﾞ出力
                End If


            Else
                '(ﾃﾞｰﾀを受信していない場合)
                Call AddToLog("nsp_inputでｲﾍﾞﾝﾄを受信しましたが、ﾃﾞｰﾀは受信しませんでした。")
            End If

        ElseIf intWinRet = WsWSRC.TIMEOUT Then     '// 復帰情報：タイムアウト(10)
            '(ﾀｲﾑｱｳﾄ)
            'NOP
        Else
            '(その他)
            Call AddToLog("nsp_inputが失敗しました。RC =" + Str(intWinRet) + " 詳細コード =" + Str(mobjWinSAM.ns_GetLastError))
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
    Private Sub MCIA_100001()
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
            'ﾀｲﾏｰ処理
            '*****************************************************
            Dim objDiff As TimeSpan = mdtmBeforeDBTime.AddMilliseconds(mintDBReadTimer) - Now
            If 0 < objDiff.TotalMilliseconds Then
                Exit Sub
            End If
            mdtmBeforeDBTime = Now


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
                udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_LATEST()      '送信ﾊﾞｯﾌｧ検索
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
            If IsNotNull(strTelegram) Then
                udtRet = SendDataEQLintener(strTelegram, objTLIF_TRNS_SEND.FTEXT_ID)
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
                    Select Case objTLIF_TRNS_SEND.FTEXT_ID
                        Case "aa" _
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
                    strMessage &= "[登録№:" & objTLIF_TRNS_SEND.FENTRY_NO & "]"
                    strMessage &= "[設備ID:" & objTLIF_TRNS_SEND.FEQ_ID & "]"
                    strMessage &= "[ｺﾏﾝﾄﾞID:" & objTLIF_TRNS_SEND.FCOMMAND_ID & "]"
                    strMessage &= "[ﾊﾟﾗﾒｰﾀ1:" & objTLIF_TRNS_SEND.FDENBUN_PRM1 & "]"
                    strMessage &= "[ﾊﾟﾗﾒｰﾀ2:" & objTLIF_TRNS_SEND.FDENBUN_PRM2 & "]"
                    strMessage &= "[ﾊﾟﾗﾒｰﾀ3:" & objTLIF_TRNS_SEND.FDENBUN_PRM3 & "]"
                    strMessage &= "[ﾊﾟﾗﾒｰﾀ4:" & objTLIF_TRNS_SEND.FDENBUN_PRM4 & "]"
                    strMessage &= "[ﾊﾟﾗﾒｰﾀ5:" & objTLIF_TRNS_SEND.FDENBUN_PRM5 & "]"
                    Call AddToLog(strMessage)

            End Select


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
    Private Sub MCIA_100002(ByVal strRecvText As String _
                          , ByVal strFDENBUN_PRM1 As String _
                          , ByVal strFDENBUN_PRM2 As String _
                          )
        Try
            'Dim intRet As RetCode
            Dim strMsg As String = ""       'ﾒｯｾｰｼﾞ
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(mobjOwner, mobjDb, mobjDbLog)


            '*****************************************************
            '受信電文有無ﾁｪｯｸ
            '*****************************************************
            If strRecvText = "" Then Exit Sub
            mdtmBeforeRecvTime = Now


            '*****************************************************
            '【設備通信ﾛｸﾞ】             追加
            '*****************************************************
            Dim strFTEXT_ID As String = FTEXT_ID_JR_CARD      'ﾃｷｽﾄID
            Call AddDBRecvLog_LOG(strFTEXT_ID _
                                , strRecvText _
                                , "" _
                                )


            '*****************************************************
            '【搬送制御送受信ｲﾝﾀｰﾌｪｰｽ】   追加
            '*****************************************************
            Dim intFRES_CD_EQ As String = ""                    '搬送制御受信IFﾃｰﾌﾞﾙに追加する設備応答ｺｰﾄﾞ
            'Dim strFDENBUN_PRM1 As String = Nothing             '電文ﾊﾟﾗﾒｰﾀ1
            'Dim strFDENBUN_PRM2 As String = Nothing             '電文ﾊﾟﾗﾒｰﾀ2
            Call AddDBRecvLIF_TRNS_RECV(FCOMMAND_ID_SOT _
                                      , strRecvText _
                                      , strFTEXT_ID _
                                      , FPROGRESS_SEND _
                                      , intFRES_CD_EQ _
                                      , strFDENBUN_PRM1 _
                                      , strFDENBUN_PRM2 _
                                      )


            ' '' '' '' '' ''*******************************************************
            ' '' '' '' '' ''返信電文                       作成
            ' '' '' '' '' ''*******************************************************
            '' '' '' '' ''Dim strSendText As String = ""
            '' '' '' '' ''strSendText = MakeReturnTelegram(strRecvText _
            '' '' '' '' ''                               , strFDENBUN_PRM1 _
            '' '' '' '' ''                               , strFDENBUN_PRM2 _
            '' '' '' '' ''                               )
            ' '' '' '' '' ''Dim strAryRecvText() As String = Split(strRecvText, "_")
            ' '' '' '' '' ''Dim strSendText As String
            ' '' '' '' '' ''strSendText = objTPRG_SYS_HEN.SJ000000_031
            ' '' '' '' '' ''strSendText &= "_" & "f1"       '制御ｺｰﾄﾞ
            ' '' '' '' '' ''strSendText &= "_" & "f0"       '制御ｺｰﾄﾞ
            ' '' '' '' '' ''strSendText &= "_" & strAryRecvText(18)       'ｶｰﾄﾞ交換機区分
            ' '' '' '' '' ''strSendText &= "_" & strAryRecvText(19)       'ｶｰﾄﾞ交換機区分
            ' '' '' '' '' ''strSendText &= "_" & strAryRecvText(20)       'ｶｰﾄﾞﾘｰﾀﾞ区分
            ' '' '' '' '' ''strSendText &= "_" & strAryRecvText(21)       'ｶｰﾄﾞﾘｰﾀﾞ区分
            ' '' '' '' '' ''strSendText &= "_" & "f0"       '応答ﾌﾗｸﾞ
            ' '' '' '' '' ''strSendText &= "_" & "f1"       '応答ﾌﾗｸﾞ
            ' '' '' '' '' ''For ii As Integer = 1 To 56 : strSendText &= "_" & "40" : Next      '予備
            ' '' '' '' '' ''strSendText &= "_" & "c6"       'BCC??
            ' '' '' '' '' ''strSendText &= "_" & "83"       'BCC??


            ' '' '' '' '' ''*******************************************************
            ' '' '' '' '' ''返信
            ' '' '' '' '' ''*******************************************************
            '' '' '' '' ''If IsNotNull(strSendText) Then
            '' '' '' '' ''    intRet = SendDataEQLintener(strSendText)
            '' '' '' '' ''End If

            '' '' '' '' '' ''If strFDENBUN_PRM1 = CAR_SYUBETU_REQ Then
            '' '' '' '' '' ''    intRet = SendDataEQLintener(objTPRG_SYS_HEN.SJ000000_031)
            '' '' '' '' '' ''Else
            '' '' '' '' '' ''    intRet = SendDataEQLintener(objTPRG_SYS_HEN.SJ000000_032)
            '' '' '' '' '' ''End If


        Catch ex As Exception
            ComError(ex)

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
        objTLOG_EQ.FHASSEI_DT = mdtmNow                     '発生日時
        objTLOG_EQ.FDIRECTION = FDIRECTION_SRECV             '方向
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



#Region "  返信電文作成                                 "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 返信電文作成
    ''' </summary>
    ''' <param name="strRecvText">正常に受信できたﾃﾞｰﾀ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function MakeReturnTelegram(ByVal strRecvText As String _
                                      , ByVal strFDENBUN_PRM1 As String _
                                      , ByVal strFDENBUN_PRM2 As String _
                                      ) _
                                      As String
        'Dim intRet As RetCode
        Dim strMsg As String = ""       'ﾒｯｾｰｼﾞ


        '**************************************************
        '初期設定
        '**************************************************
        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(mobjOwner, mobjDb, mobjDbLog)
        Dim strAryRecvText() As String = Split(strRecvText, "_")    '受信電文
        Dim strSendText As String = ""                              '送信電文


        '**************************************************
        '応答ﾌﾗｸﾞ               作成
        '**************************************************
        Dim strRetFlag As String = ""
        Select Case strFDENBUN_PRM2
            Case "01", "02", "04", "08", "10", "20", "40", "80"
                '(入構時)
                '(接車時)
                '(出構時)

                strRetFlag = MakeReturnTelegramRetFlag(strRecvText, strFDENBUN_PRM1, strFDENBUN_PRM2)

            Case Else
                '(その他の場合)

                Return ""

        End Select


        '**************************************************
        '送信電文               作成
        '**************************************************
        'strSendText = objTPRG_SYS_HEN.SJ000000_031
        'strSendText &= "_" & "00"       '??
        'strSendText &= "_" & "00"       '??
        strSendText = "f1"              '制御ｺｰﾄﾞ
        strSendText &= "_" & "f0"       '制御ｺｰﾄﾞ
        strSendText &= "_" & strAryRecvText(2)        'ｶｰﾄﾞ交換機区分
        strSendText &= "_" & strAryRecvText(3)        'ｶｰﾄﾞ交換機区分
        strSendText &= "_" & strAryRecvText(4)        'ｶｰﾄﾞﾘｰﾀﾞ区分
        strSendText &= "_" & strAryRecvText(5)        'ｶｰﾄﾞﾘｰﾀﾞ区分
        strSendText &= strRetFlag                     '応答ﾌﾗｸﾞ
        For ii As Integer = 1 To 56 : strSendText &= "_" & "40" : Next      '予備
        'strSendText &= "_" & "c6"       'BCC??
        'strSendText &= "_" & "83"       'BCC??


        '**************************************************
        '送信電文               設定
        '**************************************************
        Return strSendText


    End Function
#End Region
#Region "  返信電文作成(接車時の応答ﾌﾗｸﾞ作成)           "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 返信電文作成(接車時の応答ﾌﾗｸﾞ作成)
    ''' </summary>
    ''' <param name="strRecvText">正常に受信できたﾃﾞｰﾀ</param>
    ''' <returns>応答ﾌﾗｸﾞ</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function MakeReturnTelegramRetFlag(ByVal strRecvText As String _
                                             , ByVal strFDENBUN_PRM1 As String _
                                             , ByVal strFDENBUN_PRM2 As String _
                                             ) _
                                             As String
        Dim intRet As RetCode
        Dim strMsg As String = ""       'ﾒｯｾｰｼﾞ



        '**************************************************
        '初期設定
        '**************************************************
        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(mobjOwner, mobjDb, mobjDbLog)
        Dim strRetFlag As String = "_c5_c5"         '応答ﾌﾗｸﾞ


        '**************************************************
        '車輌ﾏｽﾀ                取得
        '**************************************************
        Dim objMST_SYARYOU As New TBL_XMST_SYARYOU(mobjOwner, mobjDb, mobjDbLog)
        objMST_SYARYOU.XCARD_NO = strFDENBUN_PRM1           'ｶｰﾄﾞ№
        intRet = objMST_SYARYOU.GET_XMST_SYARYOU(False)     '取得
        If intRet = RetCode.OK Then
            '(見つかった場合)

            If TO_INTEGER(objMST_SYARYOU.XLOADER_POSSIBLE) = FLAG_ON Then
                '(ﾛｰﾀﾞ対応の場合)


                '**************************************************
                '入構処理(未入構ﾃﾞｰﾀ有り)
                '**************************************************
                Dim strSQL As String                'SQL文
                Dim objAryXPLN_OUT As New TBL_XPLN_OUT(mobjOwner, mobjDb, mobjDbLog)
                strSQL = ""
                strSQL &= vbCrLf & "SELECT"
                strSQL &= vbCrLf & "    *"
                strSQL &= vbCrLf & " FROM"
                strSQL &= vbCrLf & "    XPLN_OUT"       '出荷指示詳細
                strSQL &= vbCrLf & " WHERE"
                strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '車輌番号
                strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS <= " & TO_STRING(XSYUKKA_STS_JOUT)             '出荷状況(出庫済)
                strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS >= " & TO_STRING(XSYUKKA_STS_JNON)             '出荷状況(受付済)
                strSQL &= vbCrLf & " ORDER BY"
                strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D"                                                     '出荷日
                strSQL &= vbCrLf & "   ,XPLN_OUT.XUNKOU_NO"                                                     '倉庫別運行№
                strSQL &= vbCrLf & "   ,XPLN_OUT.XHENSEI_NO"                                                    '編成№
                strSQL &= vbCrLf & "   ,XPLN_OUT.XDENPYOU_NO"                                                   '伝票№
                strSQL &= vbCrLf
                objAryXPLN_OUT.USER_SQL = strSQL
                intRet = objAryXPLN_OUT.GET_XPLN_OUT_USER()
                If intRet = RetCode.OK Then
                    '(見つかった場合)


                    Select Case strFDENBUN_PRM2
                        Case "01"
                            '**************************************************
                            '(入構時)
                            '**************************************************
                            If XSYUKKA_STS_JNON = objAryXPLN_OUT.ARYME(0).XSYUKKA_STS Then
                                '(入構前の場合)
                                strRetFlag = "_f0_f1"
                            Else
                                '(入構前じゃない場合)
                                strMsg = "入構不可の進捗の為、入構出来ません。[ｶｰﾄﾞ№:" & strFDENBUN_PRM1 & "][ﾊﾞｰｽ№:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][ｶｰﾄﾞﾘｰﾀﾞ区分:" & strFDENBUN_PRM2 & "][出荷状況:" & TO_STRING(objAryXPLN_OUT.ARYME(0).XSYUKKA_STS) & "]"
                            End If


                        Case "02"
                            '**************************************************
                            '(出構時)
                            '**************************************************
                            If XSYUKKA_STS_JREQ <= objAryXPLN_OUT.ARYME(0).XSYUKKA_STS And objAryXPLN_OUT.ARYME(0).XSYUKKA_STS <= XSYUKKA_STS_JOUT Then
                                '(出構前の場合)
                                strRetFlag = "_f0_f4"
                            Else
                                '(出構前じゃない場合)
                                strMsg = "出構不可の進捗の為、出構出来ません。[ｶｰﾄﾞ№:" & strFDENBUN_PRM1 & "][ﾊﾞｰｽ№:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][ｶｰﾄﾞﾘｰﾀﾞ区分:" & strFDENBUN_PRM2 & "][出荷状況:" & TO_STRING(objAryXPLN_OUT.ARYME(0).XSYUKKA_STS) & "]"
                            End If


                        Case "04", "08", "10", "20", "40", "80"
                            '**************************************************
                            '(接車時)
                            '**************************************************
                            '**************************************************
                            'ﾊﾞｰｽの特定
                            '**************************************************
                            Dim strXBERTH_NO As String = ""
                            Select Case strFDENBUN_PRM2
                                Case "04" : strXBERTH_NO = XBERTH_NO_JX01
                                Case "08" : strXBERTH_NO = XBERTH_NO_JX02
                                Case "10" : strXBERTH_NO = XBERTH_NO_JX03
                                Case "20" : strXBERTH_NO = XBERTH_NO_JX04
                                Case "40" : strXBERTH_NO = XBERTH_NO_JX05
                                Case "80" : strXBERTH_NO = XBERTH_NO_JX06
                            End Select


                            If objAryXPLN_OUT.ARYME(0).XBERTH_NO = strXBERTH_NO Then
                                '(ﾊﾞｰｽ№が一致している場合)
                                If XSYUKKA_STS_JREQ <= objAryXPLN_OUT.ARYME(0).XSYUKKA_STS And objAryXPLN_OUT.ARYME(0).XSYUKKA_STS <= XSYUKKA_STS_JOUT Then
                                    '(正常の場合)
                                    strRetFlag = "_f0_f5"
                                Else
                                    '(異常の場合)
                                    strMsg = "接車不可の進捗の為、接車出来ません。[ｶｰﾄﾞ№:" & strFDENBUN_PRM1 & "][ﾊﾞｰｽ№:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][ｶｰﾄﾞﾘｰﾀﾞ区分:" & strFDENBUN_PRM2 & "][出荷状況:" & TO_STRING(objAryXPLN_OUT.ARYME(0).XSYUKKA_STS) & "]"
                                End If
                            Else
                                '(ﾊﾞｰｽ№が一致していない場合)
                                strMsg = "ﾊﾞｰｽ№が一致していません。[ｶｰﾄﾞ№:" & strFDENBUN_PRM1 & "][ﾊﾞｰｽ№:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][ｶｰﾄﾞﾘｰﾀﾞ区分:" & strFDENBUN_PRM2 & "]"
                            End If


                    End Select


                Else
                    '(見つからなかった場合)
                    strMsg = "出荷指示が存在しません。[ｶｰﾄﾞ№:" & strFDENBUN_PRM1 & "]"
                End If


            Else
                '(ﾛｰﾀﾞ未対応の場合)
                strMsg = "ﾛｰﾀﾞに対応していない車輛受付が行われました。[ｶｰﾄﾞ№:" & strFDENBUN_PRM1 & "]"
            End If


        Else
            '(見つからない場合)
            strMsg = "車輌ﾏｽﾀが見つかりません。[ｶｰﾄﾞ№:" & strFDENBUN_PRM1 & "]"
        End If
        If IsNotNull(strMsg) Then
            Call ErrorAdd(mstrFMSG_ID_ERR_USER, strMsg)
        End If


        '**************************************************
        '送信電文               設定
        '**************************************************
        Return strRetFlag


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

            mbytRecvTelBuffClient = Nothing                          'ｿｹｯﾄ受信ﾊﾞｯﾌｧ(ｸﾗｲｱﾝﾄ)
            mbytRecvTelBuffListener = Nothing                        'ｿｹｯﾄ受信ﾊﾞｯﾌｧ(ﾘｽﾅｰ)


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
