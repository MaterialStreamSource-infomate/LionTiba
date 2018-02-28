'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】入出庫実績問合せ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_204030

#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    '選択されたﾛｸﾞ№の配列
    Public mstrFLOG_NO() As String = Nothing


    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FLOG_NO             '(非表示)INOUT実績. ﾛｸﾞ№
        FRESULT_DT          'INOUT実績.         実績日時(入庫/出庫時刻)
        FINOUT_STS          'INOUT実績.         IN/OUT(動作)
        FINOUT_STS_Dsp      'INOUT実績.         IN/OUT(動作)(表示用)
        FDISPLOG_ADDRESS_FM 'INOUT実績.         FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用(FROM)
        FDISPLOG_ADDRESS_TO 'INOUT実績.         TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用(TO)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/05/16 表記用ｱﾄﾞﾚｽ追加
        FDISP_ADDRESS       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ       表記用ｱﾄﾞﾚｽ
        '↑↑↑↑↑↑************************************************************************************************************
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/05 順番変更
        XHINMEI_CD          '品目ﾏｽﾀ.           品目ｺｰﾄﾞ
        FHINMEI_CD          'INOUT実績.         品名ｺｰﾄﾞ(品名記号)
        '↑↑↑↑↑↑************************************************************************************************************
        FHINMEI             'INOUT実績.         品名
        XRAC_IN_DT          'INOUT実績.         入庫日時
        XPROD_LINE          'INOUT実績.         生産ﾗｲﾝ№
        XPROD_LINE_DSP      'INOUT実績.         生産ﾗｲﾝ№(表示用)
        XKENSA_KUBUN        'INOUT実績.         検査区分
        XKENSA_KUBUN_DSP    'INOUT実績.         検査区分(表示用)
        FHORYU_KUBUN        'INOUT実績.         保留区分
        FHORYU_KUBUN_DSP    'INOUT実績.         保留区分(表示用)
        XKENPIN_KUBUN       'INOUT実績.         検品区分
        XKENPIN_KUBUN_DSP   'INOUT実績.         検品区分(表示用)
        FTR_VOL             'INOUT実績.         搬送管理量(積込数)
        FPALLET_ID          'INOUT実績.         ﾊﾟﾚｯﾄID
        FARRIVE_DT          'INOUT実績.         在庫発生日時
        FLOT_NO             'INOUT実績.         ﾛｯﾄNo.

        MAXCOL

    End Enum

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        SearchBtn_Click         '検索ﾎﾞﾀﾝｸﾘｯｸ時
        Print_Click             '印刷ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義　                             "

    ''' <summary>検索条件</summary>
    Private Structure SEARCH_ITEM

        Dim KIKAN_FROM As String            '期間(FROM)
        Dim KIKAN_TO As String              '期間(TO)
        Dim FHINMEI_CD As String            '品名ｺｰﾄﾞ
        Dim FHINMEI As String               '品名
        Dim FARRIVE_DT_FROM As String       '在庫発生日時(FROM)
        Dim FARRIVE_DT_TO As String         '在庫発生日時(TO)
        Dim FINOUT_STS As String            '動作
        Dim FINOUT_STS_NM As String         '動作(名称)
        Dim FBUF_FM As String               'FROM
        Dim FBUF_FM_NM As String            'FROM(名称)
        Dim FBUF_TO As String               'TO
        Dim FBUF_TO_NM As String            'TO(名称)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/04 生産ﾗｲﾝNo.追加
        Dim XPROD_LINE As String            '生産ﾗｲﾝNo.
        '↑↑↑↑↑↑************************************************************************************************************
    End Structure
#End Region
#Region "　ｲﾍﾞﾝﾄ　                                  "
#Region "　品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ   "
    'Private Sub cboFHINMEI_CD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFHINMEI_CD.SelectedIndexChanged
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFHINMEI_CD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFHINMEI_CD.LostFocus
        Try

            If mFlag_Form_Load = False Then

                ''*********************************************
                '' ﾎﾞｯｸｽ再設定
                ''*********************************************
                'Call MakeInOutToiawase_cboXSEIZOU_DT(cboFHINMEI_CD.Text, cboXSEIZOU_DT, True)

            End If

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾘｽﾄ          選択範囲変更ｲﾍﾞﾝﾄ           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ          選択範囲変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.SelectionChanged
        Try

            Call grdList_ClickProcess()

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                           "
    '*******************************************************************************************************************
    '【機能】ﾌｫｰﾑｱｸﾃｨﾌﾞ時ｲﾍﾞﾝﾄ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.ActiveControl = Nothing          'ﾃﾞﾌｫﾙﾄﾌｫｰｶｽの無効化

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()


        '****************************************
        '期間           ｾｯﾄ
        '****************************************
        Call gobjComFuncFRM.dtpKikanFromToSetup(dtpFrom, dtpTo)


        '****************************************
        ' 品名ｺｰﾄﾞｺﾝﾎﾞ         ｾｯﾄ
        '****************************************
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = ""
        cboFHINMEI_CD.HinmeiVisible = False
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)

        '**********************************************************
        ' 在庫発生日時ｺﾝﾎﾞ                  ｾｯﾄ
        '**********************************************************
        Call gobjComFuncFRM.dtpKikanFromToSetup(dtpFARRIVE_DT_From, dtpFARRIVE_DT_To)
        dtpFARRIVE_DT_From.userChecked = False
        dtpFARRIVE_DT_To.userChecked = False

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/03/28 仕様が定まっていないため未定義

        '**********************************************************
        ' 動作ｺﾝﾎﾞ                  ｾｯﾄ
        '**********************************************************
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFINOUT_STS)


        '**********************************************************
        ' FROM-TOｺﾝﾎﾞ               ｾｯﾄ
        '**********************************************************
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFROM)
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboTO)

        '↑↑↑↑↑↑************************************************************************************************************

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/04 生産ﾗｲﾝNo.追加
        '===================================
        '生産ﾗｲﾝNo.ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboMsterSetup("XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", cboXPROD_LINE, False, -1)
        '↑↑↑↑↑↑************************************************************************************************************

        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        lblFHINMEI.Text = ""       '品名


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()


        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        dtpFrom.Dispose()               'FROM期間
        dtpTo.Dispose()                 'TO期間
        cboFHINMEI_CD.Dispose()          '品名ｺｰﾄﾞ
        'cboXSEIZOU_DT.Dispose()          '製造年月日
        dtpFARRIVE_DT_From.Dispose()    '在庫発生年月日FROM
        dtpFARRIVE_DT_To.Dispose()      '在庫発生年月日TO
        cboFINOUT_STS.Dispose()         '動作ｺﾝﾎﾞ
        cboFROM.Dispose()               'FROM ST ｺﾝﾎﾞ
        cboTO.Dispose()                 'TO ST ｺﾝﾎﾞ
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F1(検索)         ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SearchBtn_Click) = False Then
            Exit Sub
        End If


        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)


    End Sub
#End Region
#Region "  F6(印刷)         ﾎﾞﾀﾝ押下処理            "
    '*******************************************************************************************************************
    '【機能】F6  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F6Process()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Print_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udeRet As PopupFormType
        udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_PRINT_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> PopupFormType.Ok Then
            Exit Sub
        End If

        '*******************************************************
        '印刷処理
        '*******************************************************
        Call printOut()


    End Sub
#End Region
#Region "  F8(戻る)         ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F8Process()

        '******************************************
        ' 画面遷移
        '******************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204000, Me)

    End Sub
#End Region
#Region "  ﾘｽﾄ              ｸﾘｯｸ処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ              ｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_ClickProcess()


        '*********************************************
        '入出庫実績・同一ﾛｸﾞ№のｸﾞﾘｯﾄﾞ表示の複数選択処理
        '*********************************************
        Call gobjComFuncFRM.GridInOutLogSelect(grdList, mstrFLOG_NO, menmListCol.FLOG_NO)


    End Sub
#End Region
#Region "  構造体ｾｯﾄ                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set()

        '********************************************************************
        '構造体に値をｾｯﾄ
        '********************************************************************
        '===============================================
        '期間(FROM)
        '===============================================
        If dtpFrom.userDispChecked = True Then
            mudtSEARCH_ITEM.KIKAN_FROM = dtpFrom.userDateTimeText       '期間FROM
        Else
            mudtSEARCH_ITEM.KIKAN_FROM = ""
        End If

        '===============================================
        '期間(TO)
        '===============================================
        If dtpTo.userDispChecked = True Then
            mudtSEARCH_ITEM.KIKAN_TO = dtpTo.userDateTimeText           '期間TO
        Else
            mudtSEARCH_ITEM.KIKAN_TO = ""
        End If

        '===============================================
        ' 品名ｺｰﾄﾞ
        '===============================================
        mudtSEARCH_ITEM.FHINMEI_CD = cboFHINMEI_CD.Text
        mudtSEARCH_ITEM.FHINMEI = lblFHINMEI.Text

        '===============================================
        ' 在庫発生日時(FROM)
        '===============================================
        If dtpFARRIVE_DT_From.userDispChecked = True Then
            mudtSEARCH_ITEM.FARRIVE_DT_FROM = dtpFARRIVE_DT_From.userDateTimeText       '在庫発生日時FROM
        Else
            mudtSEARCH_ITEM.FARRIVE_DT_FROM = ""
        End If

        '===============================================
        ' 在庫発生日時(TO)
        '===============================================
        If dtpFARRIVE_DT_To.userDispChecked = True Then
            mudtSEARCH_ITEM.FARRIVE_DT_TO = dtpFARRIVE_DT_To.userDateTimeText           '在庫発生日時TO
        Else
            mudtSEARCH_ITEM.FARRIVE_DT_TO = ""
        End If

        '===============================================
        ' 動作
        '===============================================
        mudtSEARCH_ITEM.FINOUT_STS = TO_STRING(cboFINOUT_STS.SelectedValue.ToString)
        mudtSEARCH_ITEM.FINOUT_STS_NM = cboFINOUT_STS.Text

        '===============================================
        'FROM ST
        '===============================================
        mudtSEARCH_ITEM.FBUF_FM = TO_STRING(cboFROM.SelectedValue.ToString)
        mudtSEARCH_ITEM.FBUF_FM_NM = cboFROM.Text

        '===============================================
        'TO ST
        '===============================================
        mudtSEARCH_ITEM.FBUF_TO = TO_STRING(cboTO.SelectedValue.ToString)
        mudtSEARCH_ITEM.FBUF_TO_NM = cboTO.Text


        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/04 生産ﾗｲﾝNo.追加
        '===============================================
        '生産ﾗｲﾝNo.
        '===============================================
        If cboXPROD_LINE.Text <> "" Then
            mudtSEARCH_ITEM.XPROD_LINE = TO_STRING(cboXPROD_LINE.Text)
        Else
            mudtSEARCH_ITEM.XPROD_LINE = ""
        End If
        '↑↑↑↑↑↑************************************************************************************************************

    End Sub
#End Region
#Region "　ﾘｽﾄ表示　                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        Dim strSQL As String                        'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     TLOG_INOUT.FLOG_NO "                                   'INOUT実績.         ﾛｸﾞ№
        strSQL &= vbCrLf & "   , TLOG_INOUT.FRESULT_DT "                                'INOUT実績.         実績日時(入庫/出庫時刻)
        strSQL &= vbCrLf & "   , TLOG_INOUT.FINOUT_STS "                                'INOUT実績.         IN/OUT(動作)
        strSQL &= vbCrLf & "   , HASH01.FGAMEN_DISP AS FINOUT_STS_Dsp "                 'INOUT実績.         IN/OUT(動作)(表示用)
        strSQL &= vbCrLf & "   , TLOG_INOUT.FDISP_ADDRESS_FM "                          'INOUT実績.         FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用(FROM)
        strSQL &= vbCrLf & "   , TLOG_INOUT.FDISP_ADDRESS_TO "                          'INOUT実績.         TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用(TO)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/05/16 表記用ｱﾄﾞﾚｽ追加
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FDISP_ADDRESS "                            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      表示用ｱﾄﾞﾚｽ
        '↑↑↑↑↑↑************************************************************************************************************
        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:H.Okumura 2013/06/05 ｸﾞﾘｯﾄﾞ項目変更
        strSQL &= vbCrLf & "   , TMST_ITEM.XHINMEI_CD "                                 '品目ﾏｽﾀ.           品名記号
        strSQL &= vbCrLf & "   , TLOG_INOUT.FHINMEI_CD "                                'INOUT実績.         品名ｺｰﾄﾞ
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "   , TLOG_INOUT.FHINMEI "                                   'INOUT実績.         品名
        strSQL &= vbCrLf & "   , TLOG_INOUT.XRAC_IN_DT "                                'INOUT実績.         入庫日時
        strSQL &= vbCrLf & "   , TLOG_INOUT.XPROD_LINE "                                'INOUT実績.         生産ﾗｲﾝ№
        strSQL &= vbCrLf & "   , HASH02.XPROD_LINE_NAME AS XPROD_LINE_DSP "             'INOUT実績.         生産ﾗｲﾝ№(表示用)
        strSQL &= vbCrLf & "   , TLOG_INOUT.XKENSA_KUBUN "                              'INOUT実績.         検査区分
        strSQL &= vbCrLf & "   , HASH03.FGAMEN_DISP AS XKENSA_KUBUN_DSP "               'INOUT実績.         検査区分(表示用)
        strSQL &= vbCrLf & "   , TLOG_INOUT.FHORYU_KUBUN "                              'INOUT実績.         保留区分
        strSQL &= vbCrLf & "   , HASH04.FGAMEN_DISP AS FHORYU_KUBUN_DSP "               'INOUT実績.         保留区分(表示用)
        strSQL &= vbCrLf & "   , TLOG_INOUT.XKENPIN_KUBUN "                             'INOUT実績.         検品区分
        strSQL &= vbCrLf & "   , HASH05.FGAMEN_DISP AS XKENPIN_KUBUN_DSP "              'INOUT実績.         検品区分(表示用)
        strSQL &= vbCrLf & "   , TLOG_INOUT.FTR_VOL "                                   'INOUT実績.         搬送管理量(積込数)
        strSQL &= vbCrLf & "   , TLOG_INOUT.FPALLET_ID "                                'INOUT実績.         ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "   , TLOG_INOUT.FARRIVE_DT "                                'INOUT実績.         在庫発生日時
        strSQL &= vbCrLf & "   , TLOG_INOUT.FLOT_NO "                                   'INOUT実績.         ﾛｯﾄNo.


        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TLOG_INOUT "                       'INOUT実績
        strSQL &= vbCrLf & "   , TMST_ITEM "                        '品目ﾏｽﾀ
        strSQL &= vbCrLf & "   ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TLOG_INOUT", "FINOUT_STS")
        strSQL &= vbCrLf & "   ," & gobjComFuncFRM.GetSQLHashTableFrom02("HASH02", "XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", "TLOG_INOUT", "XPROD_LINE")
        strSQL &= vbCrLf & "   ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TLOG_INOUT", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "   ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "TLOG_INOUT", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "   ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH05", "TLOG_INOUT", "XKENPIN_KUBUN")
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/05/16 表記用ｱﾄﾞﾚｽ追加
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF "                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        '↑↑↑↑↑↑************************************************************************************************************

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & "     WHERE 0 = 0 "
        strSQL &= vbCrLf & "         AND TLOG_INOUT.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "         AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TLOG_INOUT", "FINOUT_STS")
        strSQL &= vbCrLf & "         AND " & gobjComFuncFRM.GetSQLHashTableWhere02("HASH02", "XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", "TLOG_INOUT", "XPROD_LINE")
        strSQL &= vbCrLf & "         AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TLOG_INOUT", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "         AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "TLOG_INOUT", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "         AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH05", "TLOG_INOUT", "XKENPIN_KUBUN")
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/05/16 表記用ｱﾄﾞﾚｽ追加
        strSQL &= vbCrLf & "         AND TLOG_INOUT.XTRK_BUF_NO_IN = TPRG_TRK_BUF.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "         AND TLOG_INOUT.XTRK_BUF_ARRAY_IN = TPRG_TRK_BUF.FTRK_BUF_ARRAY(+) "

        '↑↑↑↑↑↑************************************************************************************************************


        '----------------------------
        ' INOUT実績.期間 範囲指定 
        '----------------------------
        If mudtSEARCH_ITEM.KIKAN_FROM <> "" Then
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FRESULT_DT >= TO_DATE('" & mudtSEARCH_ITEM.KIKAN_FROM & "','YYYY/MM/DD HH24:MI:SS')"
        End If
        If mudtSEARCH_ITEM.KIKAN_TO <> "" Then
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FRESULT_DT <= TO_DATE('" & mudtSEARCH_ITEM.KIKAN_TO & "','YYYY/MM/DD HH24:MI:SS')"
        End If

        '----------------------------
        '品名ｺｰﾄﾞ
        '----------------------------
        If mudtSEARCH_ITEM.FHINMEI_CD <> CBO_ALL_VALUE Then
            '(品名ｺｰﾄﾞに何か入力されている場合)
            If IsNumeric(mudtSEARCH_ITEM.FHINMEI_CD.Substring(0, 1)) Then
                '(品名ｺｰﾄﾞ)
                strSQL &= vbCrLf & "    AND TMST_ITEM.XHINMEI_CD = '" & mudtSEARCH_ITEM.FHINMEI_CD & "' "
            Else
                '(品名記号)
                strSQL &= vbCrLf & "        AND TLOG_INOUT.FHINMEI_CD = '" & mudtSEARCH_ITEM.FHINMEI_CD & "' "      'INOUT実績.     品名ｺｰﾄﾞ
            End If

        End If

        '-----------------------------
        '在庫発生日時
        '-----------------------------
        If mudtSEARCH_ITEM.FARRIVE_DT_FROM <> "" Then
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FARRIVE_DT >= TO_DATE('" & mudtSEARCH_ITEM.FARRIVE_DT_FROM & "','YYYY/MM/DD HH24:MI:SS')"
        End If
        If mudtSEARCH_ITEM.FARRIVE_DT_TO <> "" Then
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FARRIVE_DT <= TO_DATE('" & mudtSEARCH_ITEM.FARRIVE_DT_TO & "','YYYY/MM/DD HH24:MI:SS')"
        End If

        '-----------------------------
        'IN/OUT(動作)
        '-----------------------------
        If mudtSEARCH_ITEM.FINOUT_STS <> CBO_ALL_VALUE Then
            '(動作に何か入力されている場合)
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FINOUT_STS = '" & mudtSEARCH_ITEM.FINOUT_STS & "' "          'INOUT実績.     IN/OUT
        End If

        '-----------------------------
        'FROM ST
        '-----------------------------
        If mudtSEARCH_ITEM.FBUF_FM <> CBO_ALL_VALUE Then
            '(FROM STが入力されている場合)
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FBUF_FM IN (" & mudtSEARCH_ITEM.FBUF_FM & ")"                'INOUT実績.     FROM ST
        End If

        '-----------------------------
        'TO ST
        '-----------------------------
        If mudtSEARCH_ITEM.FBUF_TO <> CBO_ALL_VALUE Then
            '(TO STが入力されている場合)
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FBUF_TO IN (" & mudtSEARCH_ITEM.FBUF_TO & ")"                'INOUT実績.     TO ST
        End If

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/04 生産ﾗｲﾝNo.追加
        '-----------------------------
        '生産ﾗｲﾝNo.
        '-----------------------------
        If mudtSEARCH_ITEM.XPROD_LINE <> CBO_ALL_VALUE Then
            '(TO STが入力されている場合)
            strSQL &= vbCrLf & "        AND TLOG_INOUT.XPROD_LINE = '" & mudtSEARCH_ITEM.XPROD_LINE & "' "          'INOUT実績.     生産ﾗｲﾝNo.
        End If
        '↑↑↑↑↑↑************************************************************************************************************


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, strSQL, True)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, 1, Nothing)        'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "  ﾘｽﾄ表示設定　                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示設定
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)

        grdList.MultiSelect = True
        'grdList.AllowUserToResizeColumns = False

    End Sub
#End Region
#Region "  入力ﾁｪｯｸ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <param name="udtCheck_Case">[ IN  ] 入力ﾁｪｯｸ判別</param>
    ''' <returns>True :入力ﾁｪｯｸ成功 / False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True      'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ


        Select Case udtCheck_Case
            Case menmCheckCase.SearchBtn_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)

                '********************************************************************
                '日付文字列作成
                '********************************************************************
                If dtpFrom.userDispChecked <> False And dtpTo.userDispChecked <> False Then
                    '(FROM,TOの日時ｺﾝﾎﾞにﾁｪｯｸが付いているとき)

                    Dim strFrom As String                   'From
                    Dim strTo As String                     'To
                    strFrom = dtpFrom.userDateTimeText
                    strTo = dtpTo.userDateTimeText

                    '********************************************************************
                    '入力ﾁｪｯｸ
                    '********************************************************************
                    '==========================
                    '期間
                    '==========================
                    If CDate(strFrom) > CDate(strTo) Then
                        ' 期間の大小関係
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_DTP_KIKAN_TIME_02, PopupFormType.Ok, PopupIconType.Information)
                        Exit Select
                    End If

                End If

                blnCheckErr = False

            Case menmCheckCase.Print_Click
                '(在庫ﾘｽﾄﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ　表示ﾃﾞｰﾀﾁｪｯｸ
                '==========================
                If grdList.Rows.Count <= 0 Then
                    '(ﾃﾞｰﾀが一行もない場合)
                    Exit Function
                End If

                blnCheckErr = False
        End Select


        If blnCheckErr = True Then
            '(ﾁｪｯｸに引っかかった時)
            blnReturn = False
        Else
            '(ﾁｪｯｸに引っかからなかった時)
            blnReturn = True
        End If

        Return blnReturn

    End Function
#End Region
#Region "　印刷処理　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub printOut()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_204030_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try

            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))     '発行日時

            Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", mudtSEARCH_ITEM.KIKAN_FROM)         '期間(FROM)
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", mudtSEARCH_ITEM.KIKAN_TO)           '期間(TO)
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText03", mudtSEARCH_ITEM.FHINMEI_CD)         '品名ｺｰﾄﾞ
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText04", mudtSEARCH_ITEM.FHINMEI)            '品名
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText05", mudtSEARCH_ITEM.FARRIVE_DT_FROM)    '在庫発生日時
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText06", mudtSEARCH_ITEM.FARRIVE_DT_TO)
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText07", mudtSEARCH_ITEM.FBUF_FM_NM)         'FROM ST
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText08", mudtSEARCH_ITEM.FBUF_TO_NM)         'TO ST
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText09", mudtSEARCH_ITEM.FINOUT_STS_NM)      '動作
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText10", mudtSEARCH_ITEM.XPROD_LINE)         '生産ﾗｲﾝNo.


            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList.Rows.Count - 1
                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

                '*明細項目(表示)
                objDataRow.Data00 = grdList.Item(menmListCol.FRESULT_DT, ii).FormattedValue             '入庫/出庫時刻
                objDataRow.Data01 = grdList.Item(menmListCol.FINOUT_STS_Dsp, ii).FormattedValue         '動作
                objDataRow.Data02 = grdList.Item(menmListCol.FDISPLOG_ADDRESS_FM, ii).FormattedValue    'FROM
                objDataRow.Data03 = grdList.Item(menmListCol.FDISPLOG_ADDRESS_TO, ii).FormattedValue    'TO
                objDataRow.Data04 = grdList.Item(menmListCol.FHINMEI_CD, ii).FormattedValue             '品名記号
                objDataRow.Data05 = grdList.Item(menmListCol.FHINMEI, ii).FormattedValue                '品名
                objDataRow.Data06 = grdList.Item(menmListCol.FLOT_NO, ii).FormattedValue                'ﾛｯﾄ№
                objDataRow.Data07 = grdList.Item(menmListCol.XPROD_LINE, ii).FormattedValue             '生産ﾗｲﾝNo.
                objDataRow.Data08 = grdList.Item(menmListCol.FTR_VOL, ii).FormattedValue                '数量

                objDataRow.EndEdit()

                objDataSet.DataTable01.Rows.Add(objDataRow)

            Next

            '***********************************************
            ' ｸﾘｽﾀﾙﾚﾎﾟｰﾄにﾃﾞｰﾀｾｯﾄをｾｯﾄ
            '***********************************************
            objCR.SetDataSource(objDataSet)

            '***********************************************
            ' 印字
            '***********************************************
            Call gobjComFuncFRM.CRPrint(objCR)

        Catch ex As Exception
            Throw ex

        Finally
            'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
            objCR.Dispose()
            objCR = Nothing
            'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
            objDataSet.Dispose()
            objDataSet = Nothing

            Call gobjComFuncFRM.WaitFormClose()                    ' Waitﾌｫｰﾑ削除

        End Try

    End Sub
#End Region

End Class
