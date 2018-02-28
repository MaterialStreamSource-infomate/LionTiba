'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】MCIﾒｲﾝｸﾗｽ(ｻｰﾊﾞ自動再起動)
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

    Private mstrBatchFilePath As String                    'ｻｰﾊﾞ再起動ﾊﾞｯﾁﾌｧｲﾙ

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
                Dim strSQL As String                'SQL文
                Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
                Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
                Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
                mdtmNow = Now


                '************************************************
                'ﾛｸﾞ出力
                '************************************************
                Call AddToLog("ﾁｪｯｸ。")


                '************************************************
                'ｼｽﾃﾑ変数           取得
                '************************************************
                Dim intTimOut As Integer = 0
                Try
                    intTimOut = GetSYS_HEN(FHENSU_ID_SSJ000000_061)
                Catch ex As Exception
                    ComError(ex)
                End Try


                '************************************************
                'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ       取得
                '************************************************
                strSQL = ""
                strSQL &= vbCrLf & "SELECT "
                strSQL &= vbCrLf & "    MAX(FLAST_DT) FLAST_DT "
                strSQL &= vbCrLf & " FROM "
                strSQL &= vbCrLf & "    TPRG_TIMER "
                strSQL &= vbCrLf

                mobjDb.SQL = strSQL
                objDataSet.Clear()
                strDataSetName = "TPRG_TIMER"
                mobjDb.GetDataSet(strDataSetName, objDataSet)
                If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                    objRow = objDataSet.Tables(strDataSetName).Rows(0)


                    '************************************************
                    'ﾀｲﾑｱｳﾄ         判定
                    '************************************************
                    Dim dtmFHASSEI_DT As Date = TO_DATE(objRow("FLAST_DT"))
                    If intTimOut < DateDiff(DateInterval.Second, dtmFHASSEI_DT, Now) Then
                        '(ﾀｲﾑｱｳﾄした場合)
                        Call Shell(mstrBatchFilePath)
                        Call AddToLog("ｻｰﾊﾞ再起動ﾊﾞｯﾁﾌｧｲﾙを実行しました。")
                        Call ErrorAdd(FMSG_ID_S9003, "")
                    Else
                        '(ﾀｲﾑｱｳﾄしていない場合)
                        'NOP
                    End If


                End If


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
        mobjASCII = New clsASCII()              'ASCIIｺｰﾄﾞ文字ｸﾗｽ


        '*****************************************************
        'Configﾌｧｲﾙ情報取得(標準部分)
        '*****************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_SVRRESTART)                                    'Configﾌｧｲﾙ接続ｸﾗｽ生成

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

        mstrBatchFilePath = TO_STRING(objConfig.GET_INFO(GKEY_MCI_BATCH_FILE_PATH))             'ｻｰﾊﾞ再起動ﾊﾞｯﾁﾌｧｲﾙ

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


        Catch ex As Exception
            'NOP(失敗しても特に問題なし)
        End Try
    End Sub
#End Region







End Class
