'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】日締め処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_340002
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0         '端末ID
    Private Const DSPUSER_ID As Integer = 1         'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2          '理由

#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ用)</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  ﾒｲﾝ処理                                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
        Dim strDenbunDtl(0) As String         '電文分解配列
        Dim strDenbunDtlName(0) As String     '電文分解名称配列
        Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        'Dim intRet As RetCode                 '戻り値
        Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        Try


            '************************
            '初期処理
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            If IsNull(strDenbunDtl(DSPUSER_ID)) Then strDenbunDtl(DSPUSER_ID) = FUSER_ID_SKOTEI
            If IsNull(strDenbunDtl(DSPTERM_ID)) Then strDenbunDtl(DSPTERM_ID) = FTERM_ID_SKOTEI
            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call CheckBeforeAct(strDenbunDtl)


            If strMSG_RECV = DEFAULT_STRING Then
                '(日替検知からの起動の場合)

                '----------------
                'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
                '----------------
                If mdtmACTION_DATE = DEFAULT_DATE Then
                    strMsg = ERRMSG_ERR_PROPERTY & "[動作日時]"
                    Throw New System.Exception(strMsg)
                End If

            Else
                '(画面からの起動の場合)

                '----------------
                '動作日時ｾｯﾄ
                '----------------
                mdtmACTION_DATE = Now

            End If


            '************************
            '初期処理
            '************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)


            '************************
            '操業日の特定
            '************************
            Dim dtmSOUGYOU_D As Date
            If Format(mdtmACTION_DATE, "HH:mm") > Format(objTPRG_SYS_HEN.SJ000000_011, "HH:mm") Then
                '(ｼｽﾃﾑ時刻 > 締め時刻の場合)
                dtmSOUGYOU_D = Format(mdtmACTION_DATE, "yyyy/MM/dd")
            Else
                '(ｼｽﾃﾑ時刻 <= 締め時刻の場合)
                dtmSOUGYOU_D = Format(mdtmACTION_DATE, "yyyy/MM/dd")
                dtmSOUGYOU_D = DateAdd(DateInterval.Day, -1, dtmSOUGYOU_D)
            End If


            '************************
            '在庫日報の登録
            '************************
            Call Add_XRPT_ZAIKO(dtmSOUGYOU_D, dtmACTION_DATE)


            '************************
            '生産実績日報の登録
            '************************
            Call Add_XRPT_PRODUCT_IN(dtmSOUGYOU_D, dtmACTION_DATE)


            '************************
            '設備停止履歴の更新
            '************************
            Call Add_XRST_EQ_ERROR(dtmSOUGYOU_D, dtmACTION_DATE)


            '************************
            '設備稼動履歴の更新
            '************************
            Call Update_XRST_EQ_RUN(dtmSOUGYOU_D)


            '************************
            '操業履歴の更新
            '************************
            Call Update_XRST_SOUGYOU(dtmSOUGYOU_D, dtmACTION_DATE)


            Try

                '************************
                'Excel日報出力
                '************************
                Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                Call objSVR_190001.SendOther_IDOther(FCOMMAND_ID_JEXCEL_NIPPOU, Format(dtmSOUGYOU_D, DATE_FORMAT_02))
                'Call MakeExcelNippou(dtmSOUGYOU_D)
                'Call Shell(objTPRG_SYS_HEN.SJ000000_024 & " " & CMD_STRING01_EXCEL_NIPPOU & " " & Format(dtmSOUGYOU_D, DATE_FORMAT_02), AppWinStyle.NormalFocus)


                '************************
                'Excel月報出力
                '************************
                If Format(dtmSOUGYOU_D, "MM") <> Format(dtmACTION_DATE, "MM") Then
                    Call objSVR_190001.SendOther_IDOther(FCOMMAND_ID_JEXCEL_GEPPOU, Format(dtmSOUGYOU_D, DATE_FORMAT_02))
                    'Call MakeExcelGeppou(dtmSOUGYOU_D)
                    'Call Shell(objTPRG_SYS_HEN.SJ000000_024 & " " & CMD_STRING01_EXCEL_GEPPOU & " " & Format(dtmSOUGYOU_D, DATE_FORMAT_02), AppWinStyle.NormalFocus)
                End If


            Catch ex As Exception
                Call ComError(ex, MeSyoriID)
            End Try


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2015/08/17 CW6追加対応 ↓↓↓↓↓↓
            Try
                '************************
                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況の更新
                '************************
                Call Update_XSTS_XMST_DPL_PL()
            Catch ex As Exception
                Call ComError(ex, MeSyoriID)
            End Try
            'JobMate:S.Ouchi 2015/08/17 CW6追加対応 ↑↑↑↑↑↑
            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '正常完了
            '************************
            Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
            Return RetCode.OK


        Catch ex As UserException
            Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ex.Message)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
            Call ComUser(ex, MeSyoriID)
            Return RetCode.NG
        Catch ex As Exception
            Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ERRMSG_DISP_ERR)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
            Call ComError(ex, MeSyoriID)
            Return RetCode.NG
        End Try
    End Function
#End Region
#Region "  事前ﾁｪｯｸ                                                                             "
    '''**********************************************************************************************
    ''' <summary>
    ''' 事前ﾁｪｯｸ
    ''' </summary>
    ''' <param name="strDenbunDtl">電文内容構造体</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub CheckBeforeAct(ByVal strDenbunDtl() As String)
        Try
            'Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '************************
            '値漏れﾁｪｯｸ
            '************************
            If 1 = 1 Then
            ElseIf strDenbunDtl(DSPTERM_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[端末ID]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPUSER_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[ﾕｰｻﾞｰID]"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    'ﾌﾟﾛﾊﾟﾃｨ
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義"
    Private mdtmACTION_DATE As Date                 '動作日時
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    Public Property dtmACTION_DATE() As Date
        Get
            Return mdtmACTION_DATE
        End Get
        Set(ByVal Value As Date)
            mdtmACTION_DATE = Value
        End Set
    End Property
#End Region

    '関数
#Region "  在庫日報登録                                             "
    '==============================================================================================
    '【機能】在庫日報登録
    '【引数】[IN ] dtmSOUGYOU_D         :操業日
    '        [IN ] dtmACTION_DATE       :動作日時
    '【戻値】無し
    '==============================================================================================
    Private Sub Add_XRPT_ZAIKO(ByVal dtmSOUGYOU_D As Date, ByVal dtmACTION_DATE As Date)
        Dim strSQL As String                'SQL文
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim ii As Integer                   'ｶｳﾝﾀ


        '-------------------
        '既存在庫日報の削除
        '-------------------
        Dim objXRPT_ZAIKO_Delete As New TBL_XRPT_ZAIKO(Owner, ObjDb, ObjDbLog)  '在庫日報ｸﾗｽ
        objXRPT_ZAIKO_Delete.XSOUGYOU_DT = dtmSOUGYOU_D                        '操業日
        objXRPT_ZAIKO_Delete.DELETE_XRPT_ZAIKO_ANY()                           '削除


        '-------------------
        '在庫情報の抽出
        '-------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & "    TPRG_TRK_BUF.FTRK_BUF_NO              AS FTRK_BUF_NO"           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
        strSQL &= vbCrLf & "   ,TRST_STOCK.FHINMEI_CD                 AS FHINMEI_CD"            '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   ,SUM(TRST_STOCK.FTR_VOL)               AS XSTOCK_KOSOU"          '在庫数
        strSQL &= vbCrLf & "   ,COUNT(TRST_STOCK.FPALLET_ID)          AS XSTOCK_PL"             'ﾊﾟﾚｯﾄ数
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    TRST_STOCK"
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF"
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "    TRST_STOCK.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID"    'ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & " GROUP BY"
        strSQL &= vbCrLf & "    TPRG_TRK_BUF.FTRK_BUF_NO"              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
        strSQL &= vbCrLf & "   ,TRST_STOCK.FHINMEI_CD"                 '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & " ORDER BY"
        strSQL &= vbCrLf & "    TPRG_TRK_BUF.FTRK_BUF_NO"              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
        strSQL &= vbCrLf & "   ,TRST_STOCK.FHINMEI_CD"                 '品名ｺｰﾄﾞ
        strSQL &= vbCrLf
        ObjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "ADD_STOCK"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If 1 <= objDataSet.Tables(strDataSetName).Rows.Count Then
            For ii = 0 To objDataSet.Tables(strDataSetName).Rows.Count - 1
                '(ﾙｰﾌﾟ:登録在庫数)

                '-------------------
                '在庫日報の登録
                '-------------------
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                Dim objXRPT_ZAIKO_ADD As New TBL_XRPT_ZAIKO(Owner, ObjDb, ObjDbLog)     '在庫日報ｸﾗｽ
                objXRPT_ZAIKO_ADD.XSOUGYOU_DT = dtmSOUGYOU_D                            '操業日
                objXRPT_ZAIKO_ADD.FTRK_BUF_NO = TO_NUMBER(objRow("FTRK_BUF_NO"))        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
                objXRPT_ZAIKO_ADD.FHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))          '品名ｺｰﾄﾞ
                objXRPT_ZAIKO_ADD.XSTOCK_KOSOU = TO_NUMBER(objRow("XSTOCK_KOSOU"))      'ﾊﾟﾚｯﾄ数
                objXRPT_ZAIKO_ADD.XSTOCK_PL = TO_NUMBER(objRow("XSTOCK_PL"))            '在庫数
                objXRPT_ZAIKO_ADD.ADD_XRPT_ZAIKO()                                      '登録

            Next
        End If



    End Sub
#End Region
#Region "  生産実績日報登録                                         "
    '==============================================================================================
    '【機能】生産実績日報登録
    '【引数】[IN ] dtmSOUGYOU_D         :操業日
    '        [IN ] dtmACTION_DATE       :動作日時
    '【戻値】無し
    '==============================================================================================
    Private Sub Add_XRPT_PRODUCT_IN(ByVal dtmSOUGYOU_D As Date, ByVal dtmACTION_DATE As Date)
        Dim strSQL As String                'SQL文
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim ii As Integer                   'ｶｳﾝﾀ


        '-------------------
        '生産実績日報の削除
        '-------------------
        Dim XRPT_PRODUCT_IN_Delete As New TBL_XRPT_PRODUCT_IN(Owner, ObjDb, ObjDbLog)
        XRPT_PRODUCT_IN_Delete.XSOUGYOU_DT = dtmSOUGYOU_D       '操業日
        XRPT_PRODUCT_IN_Delete.DELETE_XRPT_PRODUCT_IN_ANY()     '削除


        '-----------------------
        '生産入庫設定状態の抽出
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & "    XRST_PRODUCT_IN.XPROD_LINE              AS XPROD_LINE"        '生産ﾗｲﾝ№
        strSQL &= vbCrLf & "   ,XRST_PRODUCT_IN.FHINMEI_CD              AS FHINMEI_CD"        '品目ｺｰﾄﾞ
        strSQL &= vbCrLf & "   ,SUM(XRST_PRODUCT_IN.FTR_VOL)            AS XSTOCK_KOSOU"      '在庫数
        strSQL &= vbCrLf & "   ,COUNT(XRST_PRODUCT_IN.FPALLET_ID)       AS XSTOCK_PL"         '在庫ﾊﾟﾚｯﾄ数
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    XRST_PRODUCT_IN"
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "     1 = 1 "
        strSQL &= vbCrLf & "     AND XSOUGYOU_DT = TO_DATE('" & Format(dtmSOUGYOU_D, DATE_FORMAT_03) & "','YYYY/MM/DD HH24:MI:SS')"  '操業日
        strSQL &= vbCrLf & " GROUP BY"
        strSQL &= vbCrLf & "    XRST_PRODUCT_IN.XPROD_LINE "        '生産ﾗｲﾝ№
        strSQL &= vbCrLf & "   ,XRST_PRODUCT_IN.FHINMEI_CD "        '品目ｺｰﾄﾞ
        strSQL &= vbCrLf & " ORDER BY"
        strSQL &= vbCrLf & "    XRST_PRODUCT_IN.XPROD_LINE "        '生産ﾗｲﾝ№
        strSQL &= vbCrLf & "   ,XRST_PRODUCT_IN.FHINMEI_CD "        '品目ｺｰﾄﾞ
        strSQL &= vbCrLf
        ObjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "STS_PRODUCT_IN"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If 1 <= objDataSet.Tables(strDataSetName).Rows.Count Then
            For ii = 0 To objDataSet.Tables(strDataSetName).Rows.Count - 1
                '(ﾙｰﾌﾟ:生産入庫設定数)

                '-------------------
                '生産実績日報の登録
                '-------------------
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                Dim objRPT_RST_PRODUCT_Add As New TBL_XRPT_PRODUCT_IN(Owner, ObjDb, ObjDbLog)  '生産実績日報ｸﾗｽ
                objRPT_RST_PRODUCT_Add.XSOUGYOU_DT = dtmSOUGYOU_D                              '操業日
                objRPT_RST_PRODUCT_Add.XPROD_LINE = TO_STRING(objRow("XPROD_LINE"))            '生産ﾗｲﾝ№
                objRPT_RST_PRODUCT_Add.FHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))            '品目ｺｰﾄﾞ
                objRPT_RST_PRODUCT_Add.XSTOCK_KOSOU = TO_DECIMAL(objRow("XSTOCK_KOSOU"))       '在庫数
                objRPT_RST_PRODUCT_Add.XSTOCK_PL = TO_INTEGER(objRow("XSTOCK_PL"))             '在庫ﾊﾟﾚｯﾄ数
                objRPT_RST_PRODUCT_Add.ADD_XRPT_PRODUCT_IN()                                   '登録

            Next
        End If


    End Sub
#End Region
#Region "  設備停止履歴更新                                         "
    '==============================================================================================
    '【機能】設備停止履歴更新
    '【引数】[IN ] dtmSOUGYOU_D         :操業日
    '        [IN ] dtmACTION_DATE       :動作日時
    '【戻値】無し
    '==============================================================================================
    Private Sub Add_XRST_EQ_ERROR(ByVal dtmSOUGYOU_D As Date, ByVal dtmACTION_DATE As Date)
        Dim strSQL As String                'SQL文
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim ii As Integer                   'ｶｳﾝﾀ


        '************************************************
        '操業履歴                   取得
        '************************************************
        Dim objXRST_SOUGYOU As New TBL_XRST_SOUGYOU(Owner, ObjDb, ObjDbLog)
        objXRST_SOUGYOU.GET_XRST_SOUGYOU_XRST_SOUGYOU_MAX()


        '************************
        '設備異常ﾛｸﾞ        取得
        '************************
        strSQL = ""
        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & "    * "
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    TLOG_EQ_ERROR "
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        NOT EXISTS "
        strSQL &= vbCrLf & "                 ( "
        strSQL &= vbCrLf & "                  SELECT "
        strSQL &= vbCrLf & "                     * "
        strSQL &= vbCrLf & "                  FROM "
        strSQL &= vbCrLf & "                     XRST_EQ_ERROR "
        strSQL &= vbCrLf & "                  WHERE "
        strSQL &= vbCrLf & "                     XRST_EQ_ERROR.FLOG_NO = TLOG_EQ_ERROR.FLOG_NO "
        strSQL &= vbCrLf & "                 ) "
        strSQL &= vbCrLf & " ORDER BY"
        strSQL &= vbCrLf & "    FLOG_NO"        'ﾛｸﾞ№
        strSQL &= vbCrLf
        ObjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TLOG_EQ_ERROR"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If 1 <= objDataSet.Tables(strDataSetName).Rows.Count Then
            For ii = 0 To objDataSet.Tables(strDataSetName).Rows.Count - 1
                '(ﾙｰﾌﾟ:生産入庫設定数)


                '************************************************
                '初期設定
                '************************************************
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)


                '************************************************
                '発生日時、復旧日時、停止時間(分)       計算
                '************************************************
                Dim dtmFHASSEI_DT As Date               '発生日時
                Dim dtmFHUKKI_DT As Date                '復旧日時
                Dim objDiff_XTEISI_JIKAN As TimeSpan    '停止時間(分)
                If IsNotNull(objRow("FHASSEI_DT")) Then dtmFHASSEI_DT = objRow("FHASSEI_DT") Else dtmFHASSEI_DT = objXRST_SOUGYOU.XSOUGYOU_DT
                If IsNotNull(objRow("FHUKKI_DT")) Then dtmFHUKKI_DT = objRow("FHUKKI_DT") Else dtmFHUKKI_DT = dtmACTION_DATE
                objDiff_XTEISI_JIKAN = dtmFHUKKI_DT - dtmFHASSEI_DT


                '************************
                '設備停止履歴   登録
                '************************
                Dim objXRST_EQ_ERROR As New TBL_XRST_EQ_ERROR(Owner, ObjDb, ObjDbLog)
                objXRST_EQ_ERROR.FLOG_NO = TO_STRING(objRow("FLOG_NO"))                     'ﾛｸﾞ№
                objXRST_EQ_ERROR.FEQ_ID = TO_STRING(objRow("FEQ_ID"))                       '設備ID
                objXRST_EQ_ERROR.XSOUGYOU_DT = dtmSOUGYOU_D                                 '操業日
                objXRST_EQ_ERROR.FHASSEI_DT = dtmFHASSEI_DT                                 '発生日時
                objXRST_EQ_ERROR.FHUKKI_DT = dtmFHUKKI_DT                                   '復旧日時
                objXRST_EQ_ERROR.XTEISI_JIKAN = objDiff_XTEISI_JIKAN.TotalMinutes           '停止時間(分)
                objXRST_EQ_ERROR.FEQ_STS = TO_STRING(objRow("FEQ_STS"))                     '設備状態
                objXRST_EQ_ERROR.FEQ_STOP_CD = TO_STRING(objRow("FEQ_STOP_CD"))             '停止要因ｺｰﾄﾞ
                objXRST_EQ_ERROR.ADD_XRST_EQ_ERROR()                                        '追加


            Next
        End If


    End Sub
#End Region
#Region "  設備稼動履歴更新                                         "
    '==============================================================================================
    '【機能】設備稼動履歴更新
    '【引数】[IN ] dtmACTION_DATE       :動作日時
    '【戻値】無し
    '==============================================================================================
    Private Sub Update_XRST_EQ_RUN(ByVal dtmSOUGYOU_D As Date)
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        '************************************************
        '設備稼働履歴           取得
        '************************************************
        Dim intCount As Integer
        Dim objXRST_EQ_RUN As New TBL_XRST_EQ_RUN(Owner, ObjDb, ObjDbLog)
        objXRST_EQ_RUN.XSOUGYOU_DT = dtmSOUGYOU_D           '操業日
        intCount = objXRST_EQ_RUN.GET_XRST_EQ_RUN_COUNT     '取得
        If 0 < intCount Then
            Exit Sub
        End If


        '************************************************
        '設備稼働履歴           追加
        '************************************************
        For jj As Integer = 1 To 6
            '(JOTHY01_～JOTHY06_)

            Select Case jj
                Case 1, 5
                Case Else : Continue For
            End Select

            For ii As Integer = 1 To 42
                '(JOTHY01_X048601～JOTHY01_X048642)


                '************************************************
                '設備ID             作成
                '************************************************
                Dim strFEQ_ID As String = ""
                strFEQ_ID &= "JOTHY"
                strFEQ_ID &= ZERO_PAD(jj, 2)
                strFEQ_ID &= "_X0486"
                strFEQ_ID &= ZERO_PAD(ii, 2)


                '************************************************
                '設備状況(稼働時間)         取得
                '************************************************
                Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID      '設備ID
                objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()


                '************************************************
                '設備稼働履歴           追加
                '************************************************
                objXRST_EQ_RUN.CLEAR_PROPERTY()
                objXRST_EQ_RUN.XSOUGYOU_DT = dtmSOUGYOU_D           '操業日
                objXRST_EQ_RUN.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID      '設備ID
                objXRST_EQ_RUN.FEQ_STS = objTSTS_EQ_CTRL.FEQ_STS    '設備状態
                objXRST_EQ_RUN.ADD_XRST_EQ_RUN()                    '追加


            Next


        Next


        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/11/13 日報変更(RTN稼働時間取得)
        Dim objTSTS_EQ_CTRL_WK As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        Dim objXRST_EQ_RUN_WK As New TBL_XRST_EQ_RUN(Owner, ObjDb, ObjDbLog)
        Dim strEQ_ID_RTN() As String = {"JOTHY02_X048601", "JOTHY02_X048602", "JOTHY02_X048603", _
                                        "JOTHY04_X048601", "JOTHY04_X048602", "JOTHY04_X048603"}
        For Each strFEQ_ID As String In strEQ_ID_RTN
            '************************************************
            '設備状況(稼働時間)         取得
            '************************************************
            objTSTS_EQ_CTRL_WK.CLEAR_PROPERTY()
            objTSTS_EQ_CTRL_WK.FEQ_ID = strFEQ_ID                   '設備ID
            objTSTS_EQ_CTRL_WK.GET_TSTS_EQ_CTRL()

            '************************************************
            '設備稼働履歴           追加
            '************************************************
            objXRST_EQ_RUN_WK.CLEAR_PROPERTY()
            objXRST_EQ_RUN_WK.XSOUGYOU_DT = dtmSOUGYOU_D            '操業日
            objXRST_EQ_RUN_WK.FEQ_ID = objTSTS_EQ_CTRL_WK.FEQ_ID    '設備ID
            objXRST_EQ_RUN_WK.FEQ_STS = objTSTS_EQ_CTRL_WK.FEQ_STS  '設備状態
            objXRST_EQ_RUN_WK.ADD_XRST_EQ_RUN()                     '追加
        Next
        'JobMate:S.Ouchi 2013/11/13 日報変更(RTN稼働時間取得)
        '↑↑↑↑↑↑************************************************************************************************************


        '************************************************
        'PLCﾒﾝﾃﾅﾝｽ
        '************************************************
        Dim strXSEND_DATA As String = "0"
        For ii As Integer = 1 To 41 : strXSEND_DATA &= ",0" : Next
        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
        Call objSVR_190001.SendYasukawaMelsec_IDMainteWord(FEQ_ID_JOTHY01_X048601, FTEXT_ID_JW_KADOU_RESET, strXSEND_DATA)
        Call objSVR_190001.SendYasukawaMelsec_IDMainteWord(FEQ_ID_JOTHY05_X048601, FTEXT_ID_JW_KADOU_RESET, strXSEND_DATA)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/11/13 日報変更(RTN稼働時間取得)
        Call objSVR_190001.SendYasukawaMelsec_IDMainteWord("JOTHY02_X048601", FTEXT_ID_JW_KADOU_RESET, "0,0,0")
        Call objSVR_190001.SendYasukawaMelsec_IDMainteWord("JOTHY04_X048601", FTEXT_ID_JW_KADOU_RESET, "0,0,0")
        'JobMate:S.Ouchi 2013/11/13 日報変更(RTN稼働時間取得)
        '↑↑↑↑↑↑************************************************************************************************************


    End Sub
#End Region
#Region "  操業履歴更新                                             "
    '==============================================================================================
    '【機能】設備稼動履歴更新
    '【引数】[IN ] dtmACTION_DATE       :動作日時
    '【戻値】無し
    '==============================================================================================
    Private Sub Update_XRST_SOUGYOU(ByVal dtmSOUGYOU_D As Date, ByVal dtmACTION_DATE As Date)
        Dim strSQL As String                'SQL文
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ


        '************************************************
        '出庫終了日時           取得
        '************************************************
        Dim dtmXSYUKKO_END_DT As Nullable(Of Date)
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & "    MAX(XSYUKKA_RESULT_DT)              AS XSYUKKA_RESULT_DT"       '出荷実績日時
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    XRST_OUT_DTL"
        strSQL &= vbCrLf
        ObjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XRST_OUT_DTL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If 1 <= objDataSet.Tables(strDataSetName).Rows.Count Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            dtmXSYUKKO_END_DT = TO_DATE_NULLABLE(objRow(0))
        End If


        '************************************************
        '翌日ﾃﾞｰﾀ転送           取得
        '************************************************
        Dim dtmXDATA_TENSOU_DT As Nullable(Of Date) = Nothing
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & "    MAX(FENTRY_DT)              AS FENTRY_DT"           '登録日時
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    XPLN_OUT"
        strSQL &= vbCrLf
        ObjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If 1 <= objDataSet.Tables(strDataSetName).Rows.Count Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            dtmXDATA_TENSOU_DT = TO_DATE_NULLABLE(objRow(0))
        End If


        '************************************************
        '操業履歴       更新
        '************************************************
        Dim objXRST_SOUGYOU As New TBL_XRST_SOUGYOU(Owner, ObjDb, ObjDbLog) '操業履歴ｸﾗｽ
        objXRST_SOUGYOU.GET_XRST_SOUGYOU_XRST_SOUGYOU_MAX()                 '取得
        If IsNull(objXRST_SOUGYOU.XEND_DT) Then
            objXRST_SOUGYOU.XEND_DT = dtmACTION_DATE                    '操業終了日時
        End If
        If IsNull(objXRST_SOUGYOU.XSYUKKA_END_DT) Then
            objXRST_SOUGYOU.XSYUKKA_END_DT = dtmACTION_DATE             '出荷終了日時
        End If
        If IsNull(objXRST_SOUGYOU.XSYUKKO_END_DT) Then
            objXRST_SOUGYOU.XSYUKKO_END_DT = dtmXSYUKKO_END_DT          '出庫終了日時
        End If
        If IsNull(objXRST_SOUGYOU.XDATA_TENSOU_DT) Then
            objXRST_SOUGYOU.XDATA_TENSOU_DT = dtmXDATA_TENSOU_DT        '翌日ﾃﾞｰﾀ転送
        End If

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/11/13 日報変更
        Dim intAKI_BLK As Integer
        intAKI_BLK = akiTanaDisplay()
        objXRST_SOUGYOU.XTANA_BLOCK_AKI = intAKI_BLK                    '空棚ﾌﾞﾛｯｸ数
        'JobMate:S.Ouchi 2013/11/13 日報変更
        '↑↑↑↑↑↑************************************************************************************************************

        objXRST_SOUGYOU.UPDATE_XRST_SOUGYOU()       '更新


    End Sub
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/11/13 日報変更
#Region "　空ﾌﾞﾛｯｸ数を取得               　     "
    '''***************************************************************************************************************
    ''' <summary>
    ''' 空ﾌﾞﾛｯｸ数を取得
    ''' </summary>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Private Function akiTanaDisplay() As Integer

        Dim strSQL As String                        'SQL文

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    COUNT(*) AS CNT "
        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "

        '============================================================
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ副問合せ
        '============================================================
        strSQL &= vbCrLf & "    ("
        strSQL &= vbCrLf & "    SELECT "
        strSQL &= vbCrLf & "      TPRG_TRK_BUF.XTANA_BLOCK "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FRAC_FORM) AS FRAC_FORM "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FTRNS_ADDRESS) AS FTRNS_ADDRESS "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FRES_KIND) AS FRES_KIND "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FREMOVE_KIND) AS FREMOVE_KIND "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FTRK_BUF_NO) AS FTRK_BUF_NO "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FRAC_RETU) AS FRAC_RETU "
        strSQL &= vbCrLf & "    FROM TPRG_TRK_BUF "
        strSQL &= vbCrLf & "    WHERE 1 = 1 "
        strSQL &= vbCrLf & "    GROUP BY TPRG_TRK_BUF.XTANA_BLOCK"
        strSQL &= vbCrLf & "    ) TPRG_TRK_BUF "

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "      1 = 1 "
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FRES_KIND    = " & FRES_KIND_SAKI                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.引当状態 が 0:空棚 のﾚｺｰﾄﾞを抽出
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FREMOVE_KIND = " & FREMOVE_KIND_SNORMAL          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.禁止有無 が 0:無   のﾚｺｰﾄﾞを抽出
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FTRK_BUF_NO  = " & FTRK_BUF_NO_J9000             '自動倉庫

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        ObjDb.SQL = strSQL
        strDataSetName = "TPRG_TRK_BUF"
        objDataSet.Clear()
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        objRow = objDataSet.Tables(strDataSetName).Rows(0)

        Return TO_INTEGER(objRow("CNT"))

    End Function
#End Region
    'JobMate:S.Ouchi 2013/11/13 日報変更
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2015/08/17 CW6追加対応 ↓↓↓↓↓↓
#Region "  ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況更新                                    "
    '==============================================================================================
    '【機能】ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況更新
    '【引数】無し
    '【戻値】無し
    '==============================================================================================
    Private Sub Update_XSTS_XMST_DPL_PL()
        Dim intRet As RetCode

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ
        '************************************************
        Dim objXMST_DPL_PL_BASE As New TBL_XMST_DPL_PL(Owner, ObjDb, ObjDbLog)
        objXMST_DPL_PL_BASE.GET_XMST_DPL_PL_ANY()
        intRet = objXMST_DPL_PL_BASE.GET_XMST_DPL_PL_ANY
        If intRet = RetCode.OK Then
            For Each objXMST_DPL_PL As TBL_XMST_DPL_PL In objXMST_DPL_PL_BASE.ARYME
                '************************************************
                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況
                '************************************************
                Dim objXSTS_DPL_PL As New TBL_XSTS_DPL_PL(Owner, ObjDb, ObjDbLog)
                objXSTS_DPL_PL.XDPL_PL_NO = objXMST_DPL_PL.XDPL_PL_NO
                objXSTS_DPL_PL.GET_XSTS_DPL_PL()

                If TO_INTEGER(objXSTS_DPL_PL.XDPL_PL_STS) = XDPL_PL_STS_TEISI Then
                    '************************************************
                    '開始時刻 及び 終了時刻 ｸﾘｱ
                    '************************************************
                    objXSTS_DPL_PL.XSTART_DT = DEFAULT_DATE
                    objXSTS_DPL_PL.XEND_DT = DEFAULT_DATE
                    objXSTS_DPL_PL.UPDATE_XSTS_DPL_PL()
                End If
            Next
        End If

    End Sub
#End Region
    'JobMate:S.Ouchi 2015/08/17 CW6追加対応 ↑↑↑↑↑↑
    '↑↑↑↑↑↑************************************************************************************************************

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
