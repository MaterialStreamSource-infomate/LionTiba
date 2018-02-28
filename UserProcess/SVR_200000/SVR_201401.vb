'**********************************************************************************************
' SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】棚卸し作業登録
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_201401
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0         '端末ID
    Private Const DSPUSER_ID As Integer = 1         'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2          '理由
    Private Const DSPPLAN_KEY As Integer = 3        'ｵｰﾀﾞ№
    Private Const DSPPLACE_SRCH As Integer = 4      '検索条件保管場所
    Private Const DSPAREA_SRCH As Integer = 5       '検索条件ｴﾘｱ
    Private Const DSPHINMEI_CD_SRCH As Integer = 6  '検索条件品名ｺｰﾄﾞ
    Private Const DSPDISP_ADDRESS As Integer = 7    '表記用ｱﾄﾞﾚｽ
    Private Const DSPHINMEI_CD As Integer = 8       '品名ｺｰﾄﾞ
    Private Const DSPLOT_NO As Integer = 9          'ﾛｯﾄ№
    Private Const DSPSTOCK_NUM As Integer = 10      '現在庫数量
    Private Const DSPSTOCK_KOSOU As Integer = 11    '現在庫個装数
    Private Const DSPSTOCK_HASU As Integer = 12     '現在庫端数
    Private Const XDSPLOT_NO_FM As Integer = 13     'Fmﾛｯﾄ№
    Private Const XDSPLOT_NO_TO As Integer = 14     'Toﾛｯﾄ№
    Private Const XDSPRAC_RETU_FM As Integer = 15   'Fm列
    Private Const XDSPRAC_REN_FM As Integer = 16    'Fm連
    Private Const XDSPRAC_DAN_FM As Integer = 17    'Fm段
    Private Const XDSPRAC_RETU_TO As Integer = 18   'To列
    Private Const XDSPRAC_REN_TO As Integer = 19    'To連
    Private Const XDSPRAC_DAN_TO As Integer = 20    'To段
    Private Const DSPTR_TO As Integer = 21          '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private Const DSPPALLET_ID As Integer = 22      'ﾊﾟﾚｯﾄID

#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ 
    ''' </summary>
    ''' <param name="objOwner"></param>
    ''' <param name="objDb"></param>
    ''' <param name="objDbLog"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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
        Dim strDenbunDtl(0) As String           '電文分解配列
        Dim strDenbunDtlName(0) As String       '電文分解名称配列
        Dim strDenbunInfo As String = ""        '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        Try
            'Dim intRet As RetCode                   '戻り値
            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            ''************************
            ''初期処理
            ''************************
            'Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            'Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            'Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            'Call Check_BeforeAct(strDenbunDtl)


            ''************************
            ''ｽﾃｰｼｮﾝﾏｽﾀの特定
            ''************************
            'Dim objTMST_ST As New TBL_TMST_ST(Owner, ObjDb, ObjDbLog)       'ｽﾃｰｼｮﾝﾏｽﾀｸﾗｽ
            'objTMST_ST.FTRK_BUF_NO = strDenbunDtl(DSPTR_TO)                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            'intRet = objTMST_ST.GET_TMST_ST(True)                           '特定


            ''************************
            ''設備状況の特定
            ''************************
            'Dim objTSTS_EQ_CTRL_WK As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            ''objTSTS_EQ_CTRL_WK.FEQ_ID = ConvSTN_to_MOD(objTMST_ST.FEQ_ID)      'ｽﾃｰｼｮﾝ設備ID→ｽﾃｰｼｮﾝ出庫ﾓｰﾄﾞ設備ID
            'intRet = objTSTS_EQ_CTRL_WK.GET_TSTS_EQ_CTRL(True)

            'If objTSTS_EQ_CTRL_WK.FEQ_STS <> FEQ_STS_INOUTMODE_OUT Then
            '    '(設備状態が入庫ﾓｰﾄﾞのとき)
            '    strMsg = FRM_MSG_FRM100001_23
            '    Throw New UserException(strMsg)
            'End If


            ''************************
            ''棚卸し作業初期化
            ''************************
            ''棚卸し作業
            'Dim objTPLN_INVENTORY_Delete As New TBL_TPLN_INVENTORY(Owner, ObjDb, ObjDbLog)
            'objTPLN_INVENTORY_Delete.FPLAN_KEY = strDenbunDtl(DSPTR_TO)             '計画ｷｰ
            'objTPLN_INVENTORY_Delete.DELETE_TPLN_INVENTORY()                        'ﾚｺｰﾄﾞ削除
            ''棚卸し作業詳細
            'Dim objTPLN_INVENTORY_DTL_Delete As New TBL_TPLN_INVENTORY_DTL(Owner, ObjDb, ObjDbLog)
            'objTPLN_INVENTORY_DTL_Delete.FPLAN_KEY = strDenbunDtl(DSPTR_TO)         '計画ｷｰ
            'objTPLN_INVENTORY_DTL_Delete.DELETE_TPLN_INVENTORY_DTL_FPLAN_KEY()      'ﾚｺｰﾄﾞ削除


            ''************************
            ''棚卸し作業特定
            ''************************
            'Dim objTPLN_INVENTORY As New TBL_TPLN_INVENTORY(Owner, ObjDb, ObjDbLog)
            'objTPLN_INVENTORY.FPLAN_KEY = strDenbunDtl(DSPTR_TO)
            'intRet = objTPLN_INVENTORY.GET_TPLN_INVENTORY(False)
            'If intRet = RetCode.OK Then
            '    '(見つかった場合)
            '    strMsg = "棚卸し作業ﾃｰﾌﾞﾙの初期化に失敗しました。"
            '    Throw New UserException(strMsg)
            'Else
            '    '(見つからなかった場合)

            '    objTPLN_INVENTORY.FPLAN_KEY = strDenbunDtl(DSPTR_TO)                '計画ｷｰ
            '    objTPLN_INVENTORY.FPLACE_CD = strDenbunDtl(DSPPLACE_SRCH)           '保管場所ｺｰﾄﾞ
            '    objTPLN_INVENTORY.FAREA_CD = strDenbunDtl(DSPAREA_SRCH)             'ｴﾘｱｺｰﾄﾞ
            '    objTPLN_INVENTORY.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD_SRCH)      '品名ｺｰﾄﾞ
            '    objTPLN_INVENTORY.FPROGRESS_PLNINV = FPROGRESS_PLNINV_SACT           '進捗状態(棚卸し)

            '    objTPLN_INVENTORY.FLOT_NO_FM = TO_STRING_NULLABLE(strDenbunDtl(XDSPLOT_NO_FM))          'Fmﾛｯﾄ№
            '    objTPLN_INVENTORY.FLOT_NO_TO = TO_STRING_NULLABLE(strDenbunDtl(XDSPLOT_NO_TO))          'Toﾛｯﾄ№
            '    objTPLN_INVENTORY.FRAC_RETU_FM = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPRAC_RETU_FM))     'Fm列
            '    objTPLN_INVENTORY.FRAC_REN_FM = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPRAC_REN_FM))       'Fm連
            '    objTPLN_INVENTORY.FRAC_DAN_FM = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPRAC_DAN_FM))       'Fm段
            '    objTPLN_INVENTORY.FRAC_RETU_TO = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPRAC_RETU_TO))     'To列
            '    objTPLN_INVENTORY.FRAC_REN_TO = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPRAC_REN_TO))       'To連
            '    objTPLN_INVENTORY.FRAC_DAN_TO = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPRAC_DAN_TO))       'To段
            '    objTPLN_INVENTORY.FTR_TO = TO_INTEGER_NULLABLE(strDenbunDtl(DSPTR_TO))                  '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            '    objTPLN_INVENTORY.FTERM_ID = TO_STRING_NULLABLE(strDenbunDtl(DSPTERM_ID))               '端末ID
            '    objTPLN_INVENTORY.FUSER_ID = TO_STRING_NULLABLE(strDenbunDtl(DSPUSER_ID))               'ﾕｰｻﾞｰID
            '    objTPLN_INVENTORY.FEXEC_DT = Now                                                        '実行時間
            '    objTPLN_INVENTORY.ADD_TPLN_INVENTORY()

            'End If


            ''************************
            ''ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ取得
            ''************************
            'Dim objTPRG_PARAM_TBL As New TBL_TPRG_PARAM_TBL(Owner, ObjDb, ObjDbLog) 'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ
            'objTPRG_PARAM_TBL.FPARA_ID = strDenbunDtl(DSPTERM_ID)       'ﾊﾟﾗﾒｰﾀID
            'intRet = objTPRG_PARAM_TBL.GET_TPRG_PARAM_TBL_FPARA_ID()    '特定
            'If intRet = RetCode.OK Then
            '    For ii As Integer = LBound(objTPRG_PARAM_TBL.ARYME) To UBound(objTPRG_PARAM_TBL.ARYME)
            '        '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


            '        '************************
            '        '電文分解
            '        '************************
            '        Dim objTel As New clsTelegram(CONFIG_TELEGRAM_DSP)  '受信用電文
            '        objTel.FORMAT_ID = MeDSPID                          'ﾌｫｰﾏｯﾄ名ｾｯﾄ
            '        objTel.TELEGRAM_PARTITION = objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA      '分割する電文ｾｯﾄ
            '        objTel.PARTITION()                                  '電文分割


            '        '************************
            '        '棚卸し作業特定
            '        '************************
            '        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            '        objTPRG_TRK_BUF.FPALLET_ID = Trim(objTel.SELECT_DATA("DSPPALLET_ID"))       'ﾊﾟﾚｯﾄID
            '        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)


            '        '************************
            '        '棚卸し作業詳細登録
            '        '************************
            '        Dim objTPLN_INVENTORY_DTL As New TBL_TPLN_INVENTORY_DTL(Owner, ObjDb, ObjDbLog)
            '        objTPLN_INVENTORY_DTL.FPLAN_KEY = objTPLN_INVENTORY.FPLAN_KEY                       '計画ｷｰ
            '        objTPLN_INVENTORY_DTL.FPALLET_ID = Trim(objTel.SELECT_DATA("DSPPALLET_ID"))         'ﾊﾟﾚｯﾄID
            '        intRet = objTPLN_INVENTORY_DTL.GET_TPLN_INVENTORY_DTL(False)
            '        If intRet <> RetCode.OK Then
            '            objTPLN_INVENTORY_DTL.FDISP_ADDRESS = Trim(objTel.SELECT_DATA("DSPDISP_ADDRESS"))   '表記用ｱﾄﾞﾚｽ
            '            objTPLN_INVENTORY_DTL.FHINMEI_CD = Trim(objTel.SELECT_DATA("DSPHINMEI_CD"))         '品名ｺｰﾄﾞ
            '            objTPLN_INVENTORY_DTL.FLOT_NO = Trim(objTel.SELECT_DATA("DSPLOT_NO"))               'ﾛｯﾄ№
            '            objTPLN_INVENTORY_DTL.FSTOCK_NUM = TO_INTEGER(Trim(objTel.SELECT_DATA("DSPSTOCK_NUM")))         '現在庫数量         (今回未使用)
            '            objTPLN_INVENTORY_DTL.FSTOCK_KOSOU = TO_INTEGER(Trim(objTel.SELECT_DATA("DSPSTOCK_KOSOU")))     '現在庫個装数       (今回未使用)
            '            objTPLN_INVENTORY_DTL.FSTOCK_HASU = TO_INTEGER(Trim(objTel.SELECT_DATA("DSPSTOCK_HASU")))       '現在庫端数数       (今回未使用)
            '            objTPLN_INVENTORY_DTL.FINVENTORY_NUM = DEFAULT_INTEGER                              '棚卸し実績数量
            '            objTPLN_INVENTORY_DTL.FINVENTORY_KOSOU = DEFAULT_INTEGER                            '棚卸し実績個装数
            '            objTPLN_INVENTORY_DTL.FINVENTORY_HASU = DEFAULT_INTEGER                             '棚卸し実績端数数
            '            objTPLN_INVENTORY_DTL.FPROGRESS_PLNINVDTL = FPROGRESS_PLNINVDTL_SNON                 '進捗状態(棚卸し詳細)
            '            objTPLN_INVENTORY_DTL.FTRNS_START_DT = Now                                          '搬送開始日時
            '            'objTPLN_INVENTORY_DTL.XINV_CHECK_DT = Nothing                                       '棚卸し確認日時
            '            objTPLN_INVENTORY_DTL.FTRNS_END_DT = Nothing                                        '搬送完了日時
            '            objTPLN_INVENTORY_DTL.ADD_TPLN_INVENTORY_DTL()





            '        End If



            '    Next
            'End If
            'objTPRG_PARAM_TBL.ARYME_CLEAR()


            ''************************
            ''正常完了
            ''************************
            'Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
            'Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
            'Return RetCode.OK


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
    Private Sub Check_BeforeAct(ByVal strDenbunDtl() As String)
        Try
            'Dim intRet As Integer                   '戻り値
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
            ElseIf strDenbunDtl(DSPPLAN_KEY) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[ｵｰﾀﾞ№]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPPLACE_SRCH) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[検索条件保管場所]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPAREA_SRCH) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[検索条件ｴﾘｱ]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPHINMEI_CD_SRCH) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[検索条件品名ｺｰﾄﾞ]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPDISP_ADDRESS) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[表記用ｱﾄﾞﾚｽ]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPHINMEI_CD) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[品名ｺｰﾄﾞ]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPLOT_NO) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[ﾛｯﾄ№]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPSTOCK_NUM) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[現在庫数量]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPSTOCK_KOSOU) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[現在庫個装数]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPSTOCK_HASU) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[現在庫端数]"
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

End Class
