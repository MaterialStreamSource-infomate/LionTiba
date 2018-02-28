'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】在庫問合せ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_204010

#Region "　共通変数　                               "

    Protected mudtSEARCH_ITEM As New stcSEARCH_ITEM     '検索条件用構造体

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ
    Private mFlag_Disp_Grid As Boolean = False          'ｸﾞﾘｯﾄﾞ表示ありﾌﾗｸﾞ

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/11/06 在庫ﾘｽﾄでの在庫ｴﾘｱの表示
    Private mGoukeiPL As Decimal = 0
    Private mGoukeiCS As Decimal = 0
    'JobMate:S.Ouchi 2013/11/06 在庫ﾘｽﾄでの在庫ｴﾘｱの表示
    '↑↑↑↑↑↑************************************************************************************************************

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        FTRK_BUF_NO                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        FBUF_NAME                   'ﾄﾗｯｷﾝｸﾞﾏｽﾀ     .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(在庫ｴﾘｱ)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/05 順番変更
        XHINMEI_CD                  '在庫情報       .品目ｺｰﾄﾞ(品名記号)
        FHINMEI_CD                  '在庫情報       .品名ｺｰﾄﾞ
        '↑↑↑↑↑↑************************************************************************************************************
        FHINMEI                     '品目ﾏｽﾀ        .品名
        XPROD_LINE                  '在庫情報       .生産ﾗｲﾝ№
        XPROD_LINE_DSP              '在庫情報       .生産ﾗｲﾝ№(表示用)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
        XMAKER_CD                   '在庫情報       .ﾒｰｶｰｺｰﾄﾞ
        'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
        '↑↑↑↑↑↑************************************************************************************************************
        XPL_SU                      '               .PL数
        XCS_SU                      '               .C/S数
        XARTICLE_TYPE_CODE          '在庫情報       .商品区分
        XARTICLE_TYPE_CODE_DSP      '在庫情報       .商品区分(表示用)
        XKENSA_KUBUN                '在庫情報       .検査区分
        XKENSA_KUBUN_DSP            '在庫情報       .検査区分(表示用)
        FHORYU_KUBUN                '在庫情報       .保留区分
        FHORYU_KUBUN_DSP            '在庫情報       .保留区分(表示用)
        XKENPIN_KUBUN               '在庫情報       .検品区分
        XKENPIN_KUBUN_DSP           '在庫情報       .検品区分(表示用)
        FIN_KUBUN                   '在庫情報       .入庫区分
        FIN_KUBUN_DSP               '在庫情報       .入庫区分(表示用)

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/07/01 ｸﾞﾘｯﾄﾞを固定数に変更

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
        '' ''DATA19                      '未使用
        'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
        '↑↑↑↑↑↑************************************************************************************************************

        DATA20                      '未使用
        '↑↑↑↑↑↑************************************************************************************************************

        MAXCOL                 'ｸﾞﾘｯﾄﾞの列数の最大値
    End Enum

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        SearchBtn_Click             '検索ﾎﾞﾀﾝｸﾘｯｸ時
        DtlBtn_Click                '詳細ﾎﾞﾀﾝｸﾘｯｸ
        AllDtlBtn_Click             '全詳細ﾎﾞﾀﾝｸﾘｯｸ
        Print_Click                 '印刷ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Protected Structure stcSEARCH_ITEM
        Dim FPLACE_CD As String                 '在庫ｴﾘｱ
        Dim FPLACE_NM As String                 '在庫ｴﾘｱ名
        Dim FHINMEI_CD As String                '品名ｺｰﾄﾞ
        Dim FHINMEI As String                   '品名
        Dim ARRIVE_DT_FROM As String            '期間(FROM)
        Dim ARRIVE_DT_TO As String              '期間(TO)
        Dim XPROD_LINE As String                '生産ﾗｲﾝ№
        Dim XPROD_LINE_NM As String             '生産ﾗｲﾝ№名称
        Dim FEQ_ID_CRANE As String              'ｸﾚｰﾝ設備ID
        Dim XARTICLE_TYPE_CODE As String        '商品区分
        Dim XARTICLE_TYPE_CODE_NM As String     '商品区分名称
        Dim XKENSA_KUBUN As String              '検査区分
        Dim XKENSA_KUBUN_NM As String           '検査区分名称
        Dim FHORYU_KUBUN As String              '保留区分
        Dim FHORYU_KUBUN_NM As String           '保留区分名称
        Dim CRANE_NAME As String                'ｸﾚｰﾝ名
    End Structure
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　在庫ｴﾘｱｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在庫ｴﾘｱｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFPLACE_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPLACE_CD.SelectedIndexChanged
        'Try


        '    If mFlag_Form_Load = False Then

        '        '===================================
        '        '在庫問合せ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '        '===================================
        '        cboFHINMEI_CD.Text = ""         '品名ｺｰﾄﾞ

        '        cboFHINMEI_CD.conn = gobjDb
        '        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        '        cboFHINMEI_CD.Text = ""
        '        cboFHINMEI_CD.TableName = "TRST_STOCK"
        '        cboFHINMEI_CD.ComboBoxType = GamenCommon.cmpCboFHINMEI_CD.HINMEI_CBO_TYPE.SpecifiedAndMasterData
        '        cboFHINMEI_CD.HinmeiVisible = False

        '        If TO_STRING(cboFPLACE_CD.SelectedValue.ToString) <> CBO_ALL_VALUE Then
        '            '(全検索以外の場合)
        '            ReDim cboFHINMEI_CD.FTRK_BUF_NO(0)                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№指定
        '            cboFHINMEI_CD.FTRK_BUF_NO(0) = TO_STRING(cboFPLACE_CD.SelectedValue.ToString)
        '        Else
        '            '(全検索の場合)
        '            ReDim cboFHINMEI_CD.FTRK_BUF_NO(21)                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№指定
        '            cboFHINMEI_CD.FTRK_BUF_NO(0) = FTRK_BUF_NO_J9000

        '        End If

        '        cboFHINMEI_CD.FRES_KIND = FRES_KIND_SZAIKO                                             '引当状態 = 「在庫棚」
        '        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)                                     '品名ｺｰﾄﾞ

        '        If mFlag_Disp_Grid = True Then
        '            '(ｸﾞﾘｯﾄﾞ表示ありの時)

        '            '*********************************************
        '            ' ｸﾞﾘｯﾄﾞ表示
        '            '*********************************************
        '            grdList.Columns.Clear()
        '            Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        '            Call grdListSetup()

        '            mFlag_Disp_Grid = False          'ｸﾞﾘｯﾄﾞ表示ありﾌﾗｸﾞ

        '        End If

        '    End If


        'Catch ex As Exception
        '    ComError(ex)

        'End Try
    End Sub
#End Region
#Region "　品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ   "
    '''' *******************************************************************************************************************
    '''' <summary>
    '''' 品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    '''' *******************************************************************************************************************
    'Private Sub cboFHINMEI_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFHINMEI_CD.SelectedIndexChanged
    '    Try

    '        If mFlag_Form_Load = False Then

    '            If mFlag_Disp_Grid = True Then
    '                '(ｸﾞﾘｯﾄﾞ表示ありの時)

    '                '*********************************************
    '                ' ｸﾞﾘｯﾄﾞ表示
    '                '*********************************************
    '                grdList.Columns.Clear()
    '                Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
    '                Call grdListSetup()

    '                mFlag_Disp_Grid = False          'ｸﾞﾘｯﾄﾞ表示ありﾌﾗｸﾞ

    '            End If

    '        End If

    '    Catch ex As Exception
    '        ComError(ex)

    '    End Try
    'End Sub
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


        '*********************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽ初期設定
        '*********************************************
        '===================================
        '在庫ｴﾘｱ                   ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFPLACE_CD, True)


        '===================================
        '在庫問合せ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = ""
        cboFHINMEI_CD.HinmeiVisible = False
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)

        ''cboFHINMEI_CD.conn = gobjDb
        ''cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        ''cboFHINMEI_CD.Text = ""
        ''cboFHINMEI_CD.TableName = "TRST_STOCK"
        ''cboFHINMEI_CD.ComboBoxType = GamenCommon.cmpCboFHINMEI_CD.HINMEI_CBO_TYPE.SpecifiedAndMasterData
        ''cboFHINMEI_CD.HinmeiVisible = False
        ''ReDim cboFHINMEI_CD.FTRK_BUF_NO(0)                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№指定
        ''cboFHINMEI_CD.FTRK_BUF_NO(0) = FTRK_BUF_NO_J9000
        ''cboFHINMEI_CD.FRES_KIND = FRES_KIND_SZAIKO                                             '引当状態 = 「在庫棚」
        ''cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)                                     '品名ｺｰﾄﾞ

        '****************************************
        '期間           ｾｯﾄ
        '****************************************
        Call gobjComFuncFRM.dtpKikanFromToSetup(dtpFrom, dtpTo)

        dtpFrom.userChecked = False     'FROMのﾁｪｯｸも外す


        '===================================
        '生産ﾗｲﾝ№ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboMsterSetup("XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", cboXPROD_LINE, True)

        '===================================
        'ｸﾚｰﾝｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboCRANE, True)

        '===================================
        '商品区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXARTICLE_TYPE_CODE, True)

        '===================================
        '検査区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXKENSA_KUBUN, True)

        '===================================
        '保留区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFHORYU_KUBUN, True)


        lblFHINMEI.Text = ""           '品名


        '*********************************************
        ' ﾘｽﾄ表示
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)    'ｸﾞﾘｯﾄﾞ初期設定  検索、在庫ﾘｽﾄ用
        Call grdListSetup()

        mFlag_Form_Load = False
        mFlag_Disp_Grid = False          'ｸﾞﾘｯﾄﾞ表示ありﾌﾗｸﾞ

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        cboFPLACE_CD.Dispose()              '在庫ｴﾘｱ
        cboFHINMEI_CD.Dispose()             '品名ｺｰﾄﾞ
        dtpFrom.Dispose()                   '入庫日from
        dtpTo.Dispose()                     '入庫日to
        cboXPROD_LINE.Dispose()             '生産ﾗｲﾝ№
        cboXKENSA_KUBUN.Dispose()           '検査区分
        cboFHORYU_KUBUN.Dispose()           '保留区分
        grdList.Dispose()                   'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F1(検索)           ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F1  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F1Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SearchBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)


    End Sub
#End Region
#Region "  F4(詳細)           ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F4  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F4Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.DtlBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        'ｵﾌﾞｼﾞｪｸﾄNothingﾁｪｯｸ
        If IsNull(gobjFRM_204020) = False Then
            gobjFRM_204020.Close()
            gobjFRM_204020.Dispose()
            gobjFRM_204020 = Nothing
        End If

        '********************************************************************
        ' 追加/変更ﾌｫｰﾑ展開
        '********************************************************************
        gobjFRM_204020 = New FRM_204020                             'ｵﾌﾞｼﾞｪｸﾄ作成

        Call SetProperty(gobjFRM_204020, menmCheckCase.DtlBtn_Click)                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        Call gobjFRM_204020.ShowDialog()        '画面表示

        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "  F5(全詳細)         ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F5  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F5Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.AllDtlBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        'ｵﾌﾞｼﾞｪｸﾄNothingﾁｪｯｸ
        If IsNull(gobjFRM_204020) = False Then
            gobjFRM_204020.Close()
            gobjFRM_204020.Dispose()
            gobjFRM_204020 = Nothing
        End If

        '********************************************************************
        ' 追加/変更ﾌｫｰﾑ展開
        '********************************************************************
        gobjFRM_204020 = New FRM_204020                             'ｵﾌﾞｼﾞｪｸﾄ作成

        Call SetProperty(gobjFRM_204020, menmCheckCase.AllDtlBtn_Click)                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        Call gobjFRM_204020.ShowDialog()        '画面表示


        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "  F6(在庫ﾘｽﾄ)        ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F6  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F6Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SearchBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

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
        Call printOut01()


    End Sub
#End Region
#Region "　構造体ｾｯﾄ　                              "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SearchItem_Set()

        '********************************************************************
        '構造体に値をｾｯﾄ
        '********************************************************************
        mudtSEARCH_ITEM.FPLACE_CD = TO_STRING(cboFPLACE_CD.SelectedValue)                   '在庫ｴﾘｱ
        mudtSEARCH_ITEM.FPLACE_NM = cboFPLACE_CD.Text                                       '在庫ｴﾘｱ名
        mudtSEARCH_ITEM.FHINMEI_CD = cboFHINMEI_CD.Text                                     '品名ｺｰﾄﾞ
        mudtSEARCH_ITEM.FHINMEI = lblFHINMEI.Text                                           '品名
        mudtSEARCH_ITEM.XPROD_LINE = cboXPROD_LINE.Text                                     '生産ﾗｲﾝ№
        mudtSEARCH_ITEM.XPROD_LINE_NM = TO_STRING(cboXPROD_LINE.SelectedValue)              '生産ﾗｲﾝ№名称
        mudtSEARCH_ITEM.FEQ_ID_CRANE = TO_STRING(cboCRANE.SelectedValue)                    'ｸﾚｰﾝ
        mudtSEARCH_ITEM.XARTICLE_TYPE_CODE = TO_STRING(cboXARTICLE_TYPE_CODE.SelectedValue) '商品区分
        mudtSEARCH_ITEM.XARTICLE_TYPE_CODE_NM = cboXARTICLE_TYPE_CODE.Text                  '商品区分名称
        mudtSEARCH_ITEM.XKENSA_KUBUN = TO_STRING(cboXKENSA_KUBUN.SelectedValue)             '検査区分
        mudtSEARCH_ITEM.XKENSA_KUBUN_NM = cboXKENSA_KUBUN.Text                              '検査区分名称
        mudtSEARCH_ITEM.FHORYU_KUBUN = TO_STRING(cboFHORYU_KUBUN.SelectedValue)             '保留区分
        mudtSEARCH_ITEM.FHORYU_KUBUN_NM = cboFHORYU_KUBUN.Text                              '保留区分名称

        '===============================================
        '入庫日(FROM)
        '===============================================
        If dtpFrom.userDispChecked = True Then
            'mudtSEARCH_ITEM.ARRIVE_DT_FROM = Format(TO_DATE(dtpFrom.userDateTimeText), "yyyy/MM/dd")   '期間FROM
            'mudtSEARCH_ITEM.ARRIVE_DT_FROM = mudtSEARCH_ITEM.ARRIVE_DT_FROM & " 00:00:00"
            mudtSEARCH_ITEM.ARRIVE_DT_FROM = dtpFrom.userDateTimeText   '期間FROM
        Else
            mudtSEARCH_ITEM.ARRIVE_DT_FROM = ""
        End If

        '===============================================
        '入庫日(TO)
        '===============================================
        If dtpTo.userDispChecked = True Then
            'mudtSEARCH_ITEM.ARRIVE_DT_TO = Format(TO_DATE(dtpTo.userDateTimeText), "yyyy/MM/dd")   '期間TO
            'mudtSEARCH_ITEM.ARRIVE_DT_TO = mudtSEARCH_ITEM.ARRIVE_DT_TO & " 23:59:59"
            mudtSEARCH_ITEM.ARRIVE_DT_TO = dtpTo.userDateTimeText       '期間TO
        Else
            mudtSEARCH_ITEM.ARRIVE_DT_TO = ""
        End If

        mudtSEARCH_ITEM.CRANE_NAME = cboCRANE.Text

    End Sub
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:H.Okumura 2013/07/01 品目集計に対応ver.
#Region "　ﾘｽﾄ表示(品目集計に対応ver.)              "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        '-----------------------
        'ｸﾞﾘｯﾄﾞ項目
        '-----------------------
        Dim strFTRK_BUF_NO As String                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        Dim strFBUF_NAME As String                  'ﾄﾗｯｷﾝｸﾞﾏｽﾀ     .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(在庫ｴﾘｱ)
        Dim strXHINMEI_CD As String                 '在庫情報       .品目ｺｰﾄﾞ(品名記号)
        Dim strFHINMEI_CD As String                 '在庫情報       .品名ｺｰﾄﾞ
        Dim strFHINMEI As String                    '品目ﾏｽﾀ        .品名
        Dim strXPROD_LINE As String                 '在庫情報       .生産ﾗｲﾝ№
        Dim strXPROD_LINE_DSP As String             '在庫情報       .生産ﾗｲﾝ№(表示用)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
        Dim strXMAKER_CD As String                  '在庫情報       .ﾒｰｶｰｺｰﾄﾞ
        'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
        '↑↑↑↑↑↑************************************************************************************************************
        Dim strXARTICLE_TYPE_CODE As String         '在庫情報       .商品区分
        Dim strXARTICLE_TYPE_CODE_DSP As String     '在庫情報       .商品区分(表示用)
        Dim strXKENSA_KUBUN As String               '在庫情報       .検査区分
        Dim strXKENSA_KUBUN_DSP As String           '在庫情報       .検査区分(表示用)
        Dim strFHORYU_KUBUN As String               '在庫情報       .保留区分
        Dim strFHORYU_KUBUN_DSP As String           '在庫情報       .保留区分(表示用)
        Dim strXKENPIN_KUBUN As String              '在庫情報       .検品区分
        Dim strXKENPIN_KUBUN_DSP As String          '在庫情報       .検品区分(表示用)
        Dim strFIN_KUBUN As String                  '在庫情報       .入庫区分
        Dim strFIN_KUBUN_DSP As String              '在庫情報       .入庫区分(表示用)
        Dim strXPL_SU As String                     '               .PL数
        Dim strXCS_SU As String                     '               .C/S数


        Dim strSQL As String                        'SQL文
        Dim objRow As DataRow                       '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet               'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        Dim objDataTable As New GamenCommon.clsGridDataTable20      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ


        '********************************************************************
        ' 品目集計かどうかでSQL変更
        '********************************************************************
        If chkHINMEI_CD.Checked = False Then
            '(通常検索)

            '============================================================
            'SELECT
            '============================================================
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "        TPRG_TRK_BUF.FTRK_BUF_NO "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(非表示)
            strSQL &= vbCrLf & "      , TMST_TRK.FBUF_NAME "                                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:H.Okumura 2013/06/05 ｸﾞﾘｯﾄﾞ項目変更
            strSQL &= vbCrLf & "      , TMST_ITEM.XHINMEI_CD "                                  '品目ﾏｽﾀ        .品名記号
            strSQL &= vbCrLf & "      , TRST_STOCK.FHINMEI_CD "                                 '在庫情報       .品名ｺｰﾄﾞ
            '↑↑↑↑↑↑************************************************************************************************************
            strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI "                                     '品目ﾏｽﾀ        .品名
            strSQL &= vbCrLf & "      , TRST_STOCK.XPROD_LINE "                                 '在庫情報       .生産ﾗｲﾝ№
            strSQL &= vbCrLf & "      , HASH01.XPROD_LINE_NAME AS XPROD_LINE_DSP "              '在庫情報       .生産ﾗｲﾝ№(表示用)

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
            strSQL &= vbCrLf & "      , TRST_STOCK.XMAKER_CD "                                  '在庫情報       .ﾒｰｶｰｺｰﾄﾞ
            'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
            '↑↑↑↑↑↑************************************************************************************************************

            strSQL &= vbCrLf & "      , COUNT(0) AS XPL_SU "                                    '               .PL数
            strSQL &= vbCrLf & "      , SUM(TRST_STOCK.FTR_VOL) AS XCS_SU "                     '               .C/S数
            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:H.Okumura 2013/06/11 ｸﾞﾘｯﾄﾞ項目変更
            strSQL &= vbCrLf & "      , TMST_ITEM.XARTICLE_TYPE_CODE "                          '品目ﾏｽﾀ        .商品区分
            strSQL &= vbCrLf & "      , HASH02.FGAMEN_DISP AS XARTICLE_TYPE_CODE_DSP "          '品目ﾏｽﾀ        .商品区分(表示用)
            '↑↑↑↑↑↑************************************************************************************************************
            strSQL &= vbCrLf & "      , TRST_STOCK.XKENSA_KUBUN "                               '在庫情報       .検査区分
            strSQL &= vbCrLf & "      , HASH03.FGAMEN_DISP AS XKENSA_KUBUN_DSP "                '在庫情報       .検査区分(表示用)
            strSQL &= vbCrLf & "      , TRST_STOCK.FHORYU_KUBUN "                               '在庫情報       .保留区分
            strSQL &= vbCrLf & "      , HASH04.FGAMEN_DISP AS FHORYU_KUBUN_DSP "                '在庫情報       .保留区分(表示用)
            strSQL &= vbCrLf & "      , TRST_STOCK.XKENPIN_KUBUN "                              '在庫情報       .検品区分
            strSQL &= vbCrLf & "      , HASH05.FGAMEN_DISP AS XKENPIN_KUBUN_DSP "               '在庫情報       .検品区分(表示用)
            strSQL &= vbCrLf & "      , TRST_STOCK.FIN_KUBUN "                                  '在庫情報       .入庫区分
            strSQL &= vbCrLf & "      , HASH06.FGAMEN_DISP AS FIN_KUBUN_DSP "                   '在庫情報       .入庫区分(表示用)
            

            '============================================================
            'FROM
            '============================================================
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "        TPRG_TRK_BUF "
            strSQL &= vbCrLf & "      , TMST_TRK "
            strSQL &= vbCrLf & "      , TRST_STOCK "
            strSQL &= vbCrLf & "      , TMST_ITEM "
            strSQL &= vbCrLf & "      , " & gobjComFuncFRM.GetSQLHashTableFrom02("HASH01", "XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", "TRST_STOCK", "XPROD_LINE")
            strSQL &= vbCrLf & "      , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TMST_ITEM", "XARTICLE_TYPE_CODE")
            strSQL &= vbCrLf & "      , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TRST_STOCK", "XKENSA_KUBUN")
            strSQL &= vbCrLf & "      , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "TRST_STOCK", "FHORYU_KUBUN")
            strSQL &= vbCrLf & "      , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH05", "TRST_STOCK", "XKENPIN_KUBUN")
            strSQL &= vbCrLf & "      , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH06", "TRST_STOCK", "FIN_KUBUN")


            '============================================================
            'WHERE
            '============================================================
            strSQL &= vbCrLf & " WHERE 0 = 0 "
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FRES_KIND = " & FRES_KIND_SZAIKO                '引当状態：在庫
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FPALLET_ID = TRST_STOCK.FPALLET_ID(+) "
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
            strSQL &= vbCrLf & "      AND TRST_STOCK.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
            strSQL &= vbCrLf & "      AND " & gobjComFuncFRM.GetSQLHashTableWhere02("HASH01", "XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", "TRST_STOCK", "XPROD_LINE")
            strSQL &= vbCrLf & "      AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TMST_ITEM", "XARTICLE_TYPE_CODE")
            strSQL &= vbCrLf & "      AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TRST_STOCK", "XKENSA_KUBUN")
            strSQL &= vbCrLf & "      AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "TRST_STOCK", "FHORYU_KUBUN")
            strSQL &= vbCrLf & "      AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH05", "TRST_STOCK", "XKENPIN_KUBUN")
            strSQL &= vbCrLf & "      AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH06", "TRST_STOCK", "FIN_KUBUN")

            '----------------------------------------------
            '在庫ｴﾘｱ
            '----------------------------------------------
            If mudtSEARCH_ITEM.FPLACE_CD <> CBO_ALL_VALUE Then
                '(全検索以外の場合)
                strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = '" & mudtSEARCH_ITEM.FPLACE_CD & "' "
            Else
                '(全検索の場合)
                strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO IN('" & FTRK_BUF_NO_J9000 & "','" & FTRK_BUF_NO_J9100 & "','" & FTRK_BUF_NO_J9200 & "') "
            End If

            '----------------------------
            '品名ｺｰﾄﾞ
            '----------------------------
            If mudtSEARCH_ITEM.FHINMEI_CD <> "" Then
                If IsNumeric(mudtSEARCH_ITEM.FHINMEI_CD.Substring(0, 1)) Then
                    '(品名ｺｰﾄﾞ)
                    strSQL &= vbCrLf & "    AND TMST_ITEM.XHINMEI_CD = '" & mudtSEARCH_ITEM.FHINMEI_CD & "' "
                Else
                    '(品名記号)
                    strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = '" & mudtSEARCH_ITEM.FHINMEI_CD & "' "
                End If

            End If

            '----------------------------
            '入庫日
            '----------------------------
            If mudtSEARCH_ITEM.ARRIVE_DT_FROM <> "" Then
                strSQL &= vbCrLf & "    AND TRST_STOCK.FARRIVE_DT >= TO_DATE('" & mudtSEARCH_ITEM.ARRIVE_DT_FROM & "','YYYY/MM/DD HH24:MI:SS')"
            End If
            If mudtSEARCH_ITEM.ARRIVE_DT_TO <> "" Then
                strSQL &= vbCrLf & "    AND TRST_STOCK.FARRIVE_DT <= TO_DATE('" & mudtSEARCH_ITEM.ARRIVE_DT_TO & "','YYYY/MM/DD HH24:MI:SS')"
            End If

            '----------------------------
            '生産ﾗｲﾝNo.
            '----------------------------
            If mudtSEARCH_ITEM.XPROD_LINE <> "" Then
                strSQL &= vbCrLf & "    AND TRST_STOCK.XPROD_LINE = '" & mudtSEARCH_ITEM.XPROD_LINE & "' "
            End If

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:H.Okumura 2013/06/11 ｸﾚｰﾝ追加
            '----------------------------
            'ｸﾚｰﾝ
            '----------------------------
            If mudtSEARCH_ITEM.FEQ_ID_CRANE <> "" Then
                '(全検索以外の場合)

                '**********************************************************
                ' 対象列の特定
                '**********************************************************
                Dim objTBL_TMST_CRANE As New TBL_TMST_CRANE(gobjOwner, gobjDb, Nothing)
                objTBL_TMST_CRANE.FEQ_ID = mudtSEARCH_ITEM.FEQ_ID_CRANE   '設備ID
                objTBL_TMST_CRANE.GET_TMST_CRANE(False)

                Dim strRETU1 As String = TO_STRING(objTBL_TMST_CRANE.FCRANE_ROW1)   '列1
                Dim strRETU2 As String = TO_STRING(objTBL_TMST_CRANE.FCRANE_ROW2)   '列2

                strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRAC_RETU IN ( " & strRETU1 & ", " & strRETU2 & ") "

                objTBL_TMST_CRANE.Close()

            End If
            '↑↑↑↑↑↑************************************************************************************************************

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:H.Okumura 2013/06/05 商品区分追加
            '----------------------------
            '商品区分
            '----------------------------
            If mudtSEARCH_ITEM.XARTICLE_TYPE_CODE <> "" Then
                '(全検索以外の場合)
                strSQL &= vbCrLf & "    AND TMST_ITEM.XARTICLE_TYPE_CODE = " & mudtSEARCH_ITEM.XARTICLE_TYPE_CODE
            End If
            '↑↑↑↑↑↑************************************************************************************************************

            '----------------------------
            '検査区分
            '----------------------------
            If mudtSEARCH_ITEM.XKENSA_KUBUN <> "" Then
                '(全検索以外の場合)
                strSQL &= vbCrLf & "    AND TRST_STOCK.XKENSA_KUBUN = " & mudtSEARCH_ITEM.XKENSA_KUBUN
            End If

            '----------------------------
            '保留区分
            '----------------------------
            If mudtSEARCH_ITEM.FHORYU_KUBUN <> "" Then
                '(全検索以外の場合)
                strSQL &= vbCrLf & "    AND TRST_STOCK.FHORYU_KUBUN = " & mudtSEARCH_ITEM.FHORYU_KUBUN
            End If

            '============================================================
            'GROUP BY
            '============================================================
            strSQL &= vbCrLf & "  GROUP BY "
            strSQL &= vbCrLf & "        TPRG_TRK_BUF.FTRK_BUF_NO "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(非表示)
            strSQL &= vbCrLf & "      , TMST_TRK.FBUF_NAME "                                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
            strSQL &= vbCrLf & "      , TRST_STOCK.FHINMEI_CD "                                 '在庫情報       .品名ｺｰﾄﾞ
            strSQL &= vbCrLf & "      , TMST_ITEM.XHINMEI_CD "                                  '品目ﾏｽﾀ        .品名記号
            strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI "                                     '品目ﾏｽﾀ        .品名
            strSQL &= vbCrLf & "      , TRST_STOCK.XPROD_LINE "                                 '在庫情報       .生産ﾗｲﾝ№
            strSQL &= vbCrLf & "      , HASH01.XPROD_LINE_NAME "                                '在庫情報       .生産ﾗｲﾝ№(表示用)
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
            strSQL &= vbCrLf & "      , TRST_STOCK.XMAKER_CD "                                  '在庫情報       .ﾒｰｶｰｺｰﾄﾞ
            'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
            '↑↑↑↑↑↑************************************************************************************************************
            strSQL &= vbCrLf & "      , TMST_ITEM.XARTICLE_TYPE_CODE "                          '品目ﾏｽﾀ        .商品区分
            strSQL &= vbCrLf & "      , HASH02.FGAMEN_DISP "                                    '品目ﾏｽﾀ        .商品区分(表示用)
            strSQL &= vbCrLf & "      , TRST_STOCK.XKENSA_KUBUN "                               '在庫情報       .検査区分
            strSQL &= vbCrLf & "      , HASH03.FGAMEN_DISP "                                    '在庫情報       .検査区分(表示用)
            strSQL &= vbCrLf & "      , TRST_STOCK.FHORYU_KUBUN "                               '在庫情報       .保留区分
            strSQL &= vbCrLf & "      , HASH04.FGAMEN_DISP "                                    '在庫情報       .保留区分(表示用)
            strSQL &= vbCrLf & "      , TRST_STOCK.XKENPIN_KUBUN "                              '在庫情報       .検品区分
            strSQL &= vbCrLf & "      , HASH05.FGAMEN_DISP  "                                   '在庫情報       .検品区分(表示用)
            strSQL &= vbCrLf & "      , TRST_STOCK.FIN_KUBUN "                                  '在庫情報       .入庫区分
            strSQL &= vbCrLf & "      , HASH06.FGAMEN_DISP  "                                   '在庫情報       .入庫区分(表示用)

            '============================================================
            'ORDER BY
            '============================================================
            strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)

            '-----------------------
            '抽出
            '-----------------------
            gobjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TRST_STOCK"
            gobjDb.GetDataSet(strDataSetName, objDataSet)

            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For Each objRow In objDataSet.Tables(strDataSetName).Rows

                    '********************************************************************
                    ' ﾃﾞｰﾀ取得
                    '********************************************************************
                    strFTRK_BUF_NO = TO_STRING(objRow("FTRK_BUF_NO"))
                    strFBUF_NAME = TO_STRING(objRow("FBUF_NAME"))
                    strXHINMEI_CD = TO_STRING(objRow("XHINMEI_CD"))
                    strFHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))
                    strFHINMEI = TO_STRING(objRow("FHINMEI"))
                    strXPROD_LINE = TO_STRING(objRow("XPROD_LINE"))
                    strXPROD_LINE_DSP = TO_STRING(objRow("XPROD_LINE_DSP"))
                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
                    strXMAKER_CD = TO_STRING(objRow("XMAKER_CD"))
                    'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
                    '↑↑↑↑↑↑************************************************************************************************************
                    strXARTICLE_TYPE_CODE = TO_STRING(objRow("XARTICLE_TYPE_CODE"))
                    strXARTICLE_TYPE_CODE_DSP = TO_STRING(objRow("XARTICLE_TYPE_CODE_DSP"))
                    strXKENSA_KUBUN = TO_STRING(objRow("XKENSA_KUBUN"))
                    strXKENSA_KUBUN_DSP = TO_STRING(objRow("XKENSA_KUBUN_DSP"))
                    strFHORYU_KUBUN = TO_STRING(objRow("FHORYU_KUBUN"))
                    strFHORYU_KUBUN_DSP = TO_STRING(objRow("FHORYU_KUBUN_DSP"))
                    strXKENPIN_KUBUN = TO_STRING(objRow("XKENPIN_KUBUN"))
                    strXKENPIN_KUBUN_DSP = TO_STRING(objRow("XKENPIN_KUBUN_DSP"))
                    strFIN_KUBUN = TO_STRING(objRow("FIN_KUBUN"))
                    strFIN_KUBUN_DSP = TO_STRING(objRow("FIN_KUBUN_DSP"))
                    strXPL_SU = TO_STRING(objRow("XPL_SU"))
                    strXCS_SU = TO_STRING(objRow("XCS_SU"))

                    '********************************************************************
                    ' ｸﾞﾘｯﾄﾞ表示用ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙに追加
                    '********************************************************************
                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
                    '' ''objDataTable.userAddRowDataSet(strFTRK_BUF_NO, _
                    '' ''                               strFBUF_NAME, _
                    '' ''                               strXHINMEI_CD, _
                    '' ''                               strFHINMEI_CD, _
                    '' ''                               strFHINMEI, _
                    '' ''                               strXPROD_LINE, _
                    '' ''                               strXPROD_LINE_DSP, _
                    '' ''                               strXPL_SU, _
                    '' ''                               strXCS_SU, _
                    '' ''                               strXARTICLE_TYPE_CODE, _
                    '' ''                               strXARTICLE_TYPE_CODE_DSP, _
                    '' ''                               strXKENSA_KUBUN, _
                    '' ''                               strXKENSA_KUBUN_DSP, _
                    '' ''                               strFHORYU_KUBUN, _
                    '' ''                               strFHORYU_KUBUN_DSP, _
                    '' ''                               strXKENPIN_KUBUN, _
                    '' ''                               strXKENPIN_KUBUN_DSP, _
                    '' ''                               strFIN_KUBUN, _
                    '' ''                               strFIN_KUBUN_DSP _
                    '' ''                               )
                    objDataTable.userAddRowDataSet(strFTRK_BUF_NO, _
                                                   strFBUF_NAME, _
                                                   strXHINMEI_CD, _
                                                   strFHINMEI_CD, _
                                                   strFHINMEI, _
                                                   strXPROD_LINE, _
                                                   strXPROD_LINE_DSP, _
                                                   strXMAKER_CD, _
                                                   strXPL_SU, _
                                                   strXCS_SU, _
                                                   strXARTICLE_TYPE_CODE, _
                                                   strXARTICLE_TYPE_CODE_DSP, _
                                                   strXKENSA_KUBUN, _
                                                   strXKENSA_KUBUN_DSP, _
                                                   strFHORYU_KUBUN, _
                                                   strFHORYU_KUBUN_DSP, _
                                                   strXKENPIN_KUBUN, _
                                                   strXKENPIN_KUBUN_DSP, _
                                                   strFIN_KUBUN, _
                                                   strFIN_KUBUN_DSP _
                                                   )
                    'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
                    '↑↑↑↑↑↑************************************************************************************************************
                Next


            Else
                '(0件の場合)
                gobjComFuncFRM.DisplayPopup(FRM_MSG_GRIDDISPLAY_02, PopupFormType.Ok, PopupIconType.Information)
            End If

        Else
            '(品目集計の場合)

            '============================================================
            'SELECT
            '============================================================
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "        TMST_ITEM.XHINMEI_CD "                                  '品目ﾏｽﾀ        .品名記号
            strSQL &= vbCrLf & "      , TRST_STOCK.FHINMEI_CD "                                 '在庫情報       .品名ｺｰﾄﾞ
            strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI "                                     '品目ﾏｽﾀ        .品名
            strSQL &= vbCrLf & "      , TMST_ITEM.XARTICLE_TYPE_CODE "                          '品目ﾏｽﾀ        .商品区分
            strSQL &= vbCrLf & "      , HASH02.FGAMEN_DISP AS XARTICLE_TYPE_CODE_DSP "          '品目ﾏｽﾀ        .商品区分(表示用)
            strSQL &= vbCrLf & "      , COUNT(0) AS XPL_SU "                                    '               .PL数
            strSQL &= vbCrLf & "      , SUM(TRST_STOCK.FTR_VOL) AS XCS_SU "                     '               .C/S数
            If mudtSEARCH_ITEM.FPLACE_CD <> CBO_ALL_VALUE Then
                strSQL &= vbCrLf & "      , TPRG_TRK_BUF.FTRK_BUF_NO "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(非表示)
                strSQL &= vbCrLf & "      , TMST_TRK.FBUF_NAME "                                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
            End If
            '============================================================
            'FROM
            '============================================================
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "        TPRG_TRK_BUF "
            strSQL &= vbCrLf & "      , TMST_TRK "
            strSQL &= vbCrLf & "      , TRST_STOCK "
            strSQL &= vbCrLf & "      , TMST_ITEM "
            strSQL &= vbCrLf & "      , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TMST_ITEM", "XARTICLE_TYPE_CODE")

            '============================================================
            'WHERE
            '============================================================
            strSQL &= vbCrLf & " WHERE 0 = 0 "
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FPALLET_ID = TRST_STOCK.FPALLET_ID(+) "
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
            strSQL &= vbCrLf & "      AND TRST_STOCK.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FRES_KIND = " & FRES_KIND_SZAIKO                '引当状態：在庫
            strSQL &= vbCrLf & "      AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TMST_ITEM", "XARTICLE_TYPE_CODE")

            '----------------------------------------------
            '在庫ｴﾘｱ
            '----------------------------------------------
            If mudtSEARCH_ITEM.FPLACE_CD <> CBO_ALL_VALUE Then
                '(全検索以外の場合)
                strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = '" & mudtSEARCH_ITEM.FPLACE_CD & "' "
            Else
                '(全検索の場合)
                strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO IN('" & FTRK_BUF_NO_J9000 & "','" & FTRK_BUF_NO_J9100 & "','" & FTRK_BUF_NO_J9200 & "') "
            End If

            '----------------------------
            '品名ｺｰﾄﾞ
            '----------------------------
            If mudtSEARCH_ITEM.FHINMEI_CD <> "" Then
                If IsNumeric(mudtSEARCH_ITEM.FHINMEI_CD.Substring(0, 1)) Then
                    '(品名ｺｰﾄﾞ)
                    strSQL &= vbCrLf & "    AND TMST_ITEM.XHINMEI_CD = '" & mudtSEARCH_ITEM.FHINMEI_CD & "' "
                Else
                    '(品名記号)
                    strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = '" & mudtSEARCH_ITEM.FHINMEI_CD & "' "
                End If

            End If

            '----------------------------
            '入庫日
            '----------------------------
            If mudtSEARCH_ITEM.ARRIVE_DT_FROM <> "" Then
                strSQL &= vbCrLf & "    AND TRST_STOCK.FARRIVE_DT >= TO_DATE('" & mudtSEARCH_ITEM.ARRIVE_DT_FROM & "','YYYY/MM/DD HH24:MI:SS')"
            End If
            If mudtSEARCH_ITEM.ARRIVE_DT_TO <> "" Then
                strSQL &= vbCrLf & "    AND TRST_STOCK.FARRIVE_DT <= TO_DATE('" & mudtSEARCH_ITEM.ARRIVE_DT_TO & "','YYYY/MM/DD HH24:MI:SS')"
            End If

            '----------------------------
            'ｸﾚｰﾝ
            '----------------------------
            If mudtSEARCH_ITEM.FEQ_ID_CRANE <> "" Then
                '(全検索以外の場合)

                '**********************************************************
                ' 対象列の特定
                '**********************************************************
                Dim objTBL_TMST_CRANE As New TBL_TMST_CRANE(gobjOwner, gobjDb, Nothing)
                objTBL_TMST_CRANE.FEQ_ID = mudtSEARCH_ITEM.FEQ_ID_CRANE   '設備ID
                objTBL_TMST_CRANE.GET_TMST_CRANE(False)

                Dim strRETU1 As String = TO_STRING(objTBL_TMST_CRANE.FCRANE_ROW1)   '列1
                Dim strRETU2 As String = TO_STRING(objTBL_TMST_CRANE.FCRANE_ROW2)   '列2

                strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRAC_RETU IN ( " & strRETU1 & ", " & strRETU2 & ") "

                objTBL_TMST_CRANE.Close()

            End If

            '----------------------------
            '商品区分
            '----------------------------
            If mudtSEARCH_ITEM.XARTICLE_TYPE_CODE <> "" Then
                '(全検索以外の場合)
                strSQL &= vbCrLf & "    AND TMST_ITEM.XARTICLE_TYPE_CODE = " & mudtSEARCH_ITEM.XARTICLE_TYPE_CODE
            End If

            '----------------------------
            '検査区分
            '----------------------------
            If mudtSEARCH_ITEM.XKENSA_KUBUN <> "" Then
                '(全検索以外の場合)
                strSQL &= vbCrLf & "    AND TRST_STOCK.XKENSA_KUBUN = " & mudtSEARCH_ITEM.XKENSA_KUBUN
            End If

            '----------------------------
            '保留区分
            '----------------------------
            If mudtSEARCH_ITEM.FHORYU_KUBUN <> "" Then
                '(全検索以外の場合)
                strSQL &= vbCrLf & "    AND TRST_STOCK.FHORYU_KUBUN = " & mudtSEARCH_ITEM.FHORYU_KUBUN
            End If

            '============================================================
            'GROUP BY
            '============================================================
            strSQL &= vbCrLf & "  GROUP BY "
            strSQL &= vbCrLf & "        TRST_STOCK.FHINMEI_CD "                                 '在庫情報       .品名ｺｰﾄﾞ
            strSQL &= vbCrLf & "      , TMST_ITEM.XHINMEI_CD "                                  '品目ﾏｽﾀ        .品名記号
            strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI "                                     '品目ﾏｽﾀ        .品名
            strSQL &= vbCrLf & "      , TMST_ITEM.XARTICLE_TYPE_CODE "                          '品目ﾏｽﾀ        .商品区分
            strSQL &= vbCrLf & "      , HASH02.FGAMEN_DISP "                                    '品目ﾏｽﾀ        .商品区分(表示用)
            If mudtSEARCH_ITEM.FPLACE_CD <> CBO_ALL_VALUE Then
                strSQL &= vbCrLf & "      , TPRG_TRK_BUF.FTRK_BUF_NO "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(非表示)
                strSQL &= vbCrLf & "      , TMST_TRK.FBUF_NAME "                                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
            End If

            '============================================================
            'ORDER BY
            '============================================================
            strSQL &= vbCrLf & " ORDER BY  "
            If mudtSEARCH_ITEM.FPLACE_CD <> CBO_ALL_VALUE Then
                strSQL &= vbCrLf & "        TPRG_TRK_BUF.FTRK_BUF_NO "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                strSQL &= vbCrLf & "      , TMST_ITEM.XHINMEI_CD "                                  '品目ﾏｽﾀ        .品名記号
                strSQL &= vbCrLf & "      , TRST_STOCK.FHINMEI_CD "                                 '在庫情報       .品名ｺｰﾄﾞ
            Else
                strSQL &= vbCrLf & "        TMST_ITEM.XHINMEI_CD "                                  '品目ﾏｽﾀ        .品名記号
                strSQL &= vbCrLf & "      , TRST_STOCK.FHINMEI_CD "                                 '在庫情報       .品名ｺｰﾄﾞ
            End If


            '-----------------------
            '抽出
            '-----------------------
            gobjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TRST_STOCK"
            gobjDb.GetDataSet(strDataSetName, objDataSet)

            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For Each objRow In objDataSet.Tables(strDataSetName).Rows

                    '********************************************************************
                    ' ﾃﾞｰﾀ取得
                    '********************************************************************
                    If mudtSEARCH_ITEM.FPLACE_CD <> CBO_ALL_VALUE Then
                        strFTRK_BUF_NO = TO_STRING(objRow("FTRK_BUF_NO"))
                        strFBUF_NAME = TO_STRING(objRow("FBUF_NAME"))
                    Else
                        strFTRK_BUF_NO = ""
                        strFBUF_NAME = ""
                    End If

                    strXHINMEI_CD = TO_STRING(objRow("XHINMEI_CD"))
                    strFHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))
                    strFHINMEI = TO_STRING(objRow("FHINMEI"))
                    strXPL_SU = TO_STRING(objRow("XPL_SU"))
                    strXCS_SU = TO_STRING(objRow("XCS_SU"))
                    strXARTICLE_TYPE_CODE = TO_STRING(objRow("XARTICLE_TYPE_CODE"))
                    strXARTICLE_TYPE_CODE_DSP = TO_STRING(objRow("XARTICLE_TYPE_CODE_DSP"))

                    '********************************************************************
                    ' ｸﾞﾘｯﾄﾞ表示用ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙに追加
                    '********************************************************************
                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
                    '' ''objDataTable.userAddRowDataSet(strFTRK_BUF_NO, _
                    '' ''                               strFBUF_NAME, _
                    '' ''                               strXHINMEI_CD, _
                    '' ''                               strFHINMEI_CD, _
                    '' ''                               strFHINMEI, _
                    '' ''                               "", _
                    '' ''                               "", _
                    '' ''                               strXPL_SU, _
                    '' ''                               strXCS_SU, _
                    '' ''                               strXARTICLE_TYPE_CODE, _
                    '' ''                               strXARTICLE_TYPE_CODE_DSP, _
                    '' ''                               "", _
                    '' ''                               "", _
                    '' ''                               "", _
                    '' ''                               "", _
                    '' ''                               "", _
                    '' ''                               "", _
                    '' ''                               "", _
                    '' ''                               "" _
                    '' ''                               )
                    objDataTable.userAddRowDataSet(strFTRK_BUF_NO, _
                                                   strFBUF_NAME, _
                                                   strXHINMEI_CD, _
                                                   strFHINMEI_CD, _
                                                   strFHINMEI, _
                                                   "", _
                                                   "", _
                                                   "", _
                                                   strXPL_SU, _
                                                   strXCS_SU, _
                                                   strXARTICLE_TYPE_CODE, _
                                                   strXARTICLE_TYPE_CODE_DSP, _
                                                   "", _
                                                   "", _
                                                   "", _
                                                   "", _
                                                   "", _
                                                   "", _
                                                   "", _
                                                   "" _
                                                   )
                    'JobMate:S.Ouchi 2013/10/31 在庫問合せ画面 ﾒｰｶｰｺｰﾄﾞ表示
                    '↑↑↑↑↑↑************************************************************************************************************
                Next

            Else
                '(0件の場合)
                gobjComFuncFRM.DisplayPopup(FRM_MSG_GRIDDISPLAY_02, PopupFormType.Ok, PopupIconType.Information)

            End If

        End If




        '********************************************************************
        ' ｸﾞﾘｯﾄﾞへ出力
        '********************************************************************
        Call gobjComFuncFRM.GridDisplay(objDataTable, _
                         grdList, _
                         )
        objDataTable = Nothing

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理

        mFlag_Disp_Grid = True          'ｸﾞﾘｯﾄﾞ表示ありﾌﾗｸﾞ

    End Sub
#End Region
    '↑↑↑↑↑↑************************************************************************************************************

#Region "  ﾘｽﾄ表示設定　                            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub grdListSetup()

        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)         '検索、在庫ﾘｽﾄ 時
        'grdList.AllowUserToResizeColumns = False

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Public Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.SearchBtn_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.DtlBtn_Click
                '(詳細ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ選択ﾁｪｯｸ
                '==========================
                If grdList.SelectedRows.Count < 1 Then
                    '(ﾘｽﾄが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If


                blnCheckErr = False


            Case menmCheckCase.AllDtlBtn_Click
                '(全詳細ﾎﾞﾀﾝｸﾘｯｸ時)


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
#Region "　印刷処理(在庫ﾘｽﾄ）                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub printOut01()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_204010_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try

            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            '================================
            ' ﾃﾞｰﾀ取得
            '================================
            Dim strFHINMEI_CD As String = ""                    '品名記号
            Dim strXHINMEI_CD As String = ""                    '品名ｺｰﾄﾞ
            Dim objTBL_TMST_ITEM As TBL_TMST_ITEM = Nothing     '品名ﾏｽﾀ
            Dim intRet As Integer

            If mudtSEARCH_ITEM.FHINMEI_CD <> "" Then
                If IsNumeric(mudtSEARCH_ITEM.FHINMEI_CD.Substring(0, 1)) Then
                    '(品名ｺｰﾄﾞの場合)
                    strXHINMEI_CD = mudtSEARCH_ITEM.FHINMEI_CD

                    objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                    objTBL_TMST_ITEM.XHINMEI_CD = strXHINMEI_CD
                    intRet = objTBL_TMST_ITEM.GET_TMST_ITEM()
                    If intRet = RetCode.OK Then
                        strFHINMEI_CD = objTBL_TMST_ITEM.FHINMEI_CD
                    End If

                Else
                    '(品名記号の場合)
                    strFHINMEI_CD = mudtSEARCH_ITEM.FHINMEI_CD

                    objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                    objTBL_TMST_ITEM.FHINMEI_CD = strFHINMEI_CD
                    intRet = objTBL_TMST_ITEM.GET_TMST_ITEM()
                    If intRet = RetCode.OK Then
                        strXHINMEI_CD = objTBL_TMST_ITEM.XHINMEI_CD
                    End If
                End If

            End If

            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/06 在庫ﾘｽﾄでの在庫ｴﾘｱの表示
            '' ''Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", mudtSEARCH_ITEM.FPLACE_NM)                  '在庫ｴﾘｱ
            If mudtSEARCH_ITEM.FPLACE_NM = "" Then
                Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", "自動倉庫、平置、検品エリア")           '在庫ｴﾘｱ
            Else
                Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", mudtSEARCH_ITEM.FPLACE_NM)              '在庫ｴﾘｱ
            End If
            'JobMate:S.Ouchi 2013/11/06 在庫ﾘｽﾄでの在庫ｴﾘｱの表示
            '↑↑↑↑↑↑************************************************************************************************************
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", strXHINMEI_CD)                              '品名ｺｰﾄﾞ
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText03", mudtSEARCH_ITEM.FHINMEI)                    '品名
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText04", strFHINMEI_CD)                              '品名記号
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText05", mudtSEARCH_ITEM.ARRIVE_DT_FROM)             '在庫発生日時
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText06", mudtSEARCH_ITEM.ARRIVE_DT_TO)
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText07", mudtSEARCH_ITEM.XPROD_LINE)                 '生産ﾗｲﾝNo.
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText08", mudtSEARCH_ITEM.CRANE_NAME)                 'ｸﾚｰﾝ
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText09", mudtSEARCH_ITEM.XARTICLE_TYPE_CODE_NM)      '商品区分
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText10", mudtSEARCH_ITEM.XKENSA_KUBUN_NM)            '検査区分
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText11", mudtSEARCH_ITEM.FHORYU_KUBUN_NM)            '保留区分

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/06 在庫ﾘｽﾄでの在庫ｴﾘｱの表示
            mGoukeiPL = 0                                                                           '合計 PL数
            mGoukeiCS = 0                                                                           '合計 C/S数
            'JobMate:S.Ouchi 2013/11/06 在庫ﾘｽﾄでの在庫ｴﾘｱの表示
            '↑↑↑↑↑↑************************************************************************************************************

            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList.Rows.Count - 1

                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

                objDataRow.Data00 = grdList.Item(menmListCol.FBUF_NAME, ii).FormattedValue          '在庫ｴﾘｱ
                objDataRow.Data01 = grdList.Item(menmListCol.XHINMEI_CD, ii).FormattedValue         '品名ｺｰﾄﾞ
                objDataRow.Data02 = grdList.Item(menmListCol.FHINMEI_CD, ii).FormattedValue         '品名記号
                objDataRow.Data03 = grdList.Item(menmListCol.FHINMEI, ii).FormattedValue            '品名
                objDataRow.Data04 = grdList.Item(menmListCol.XPROD_LINE_DSP, ii).FormattedValue     '生産ﾗｲﾝ№
                objDataRow.Data05 = grdList.Item(menmListCol.XKENSA_KUBUN_DSP, ii).FormattedValue   '検査区分
                objDataRow.Data06 = grdList.Item(menmListCol.FHORYU_KUBUN_DSP, ii).FormattedValue   '保留区分
                objDataRow.Data07 = grdList.Item(menmListCol.XKENPIN_KUBUN_DSP, ii).FormattedValue  '検品区分
                objDataRow.Data08 = grdList.Item(menmListCol.FIN_KUBUN_DSP, ii).FormattedValue      '入庫区分
                objDataRow.Data09 = grdList.Item(menmListCol.XPL_SU, ii).FormattedValue             'PL数
                objDataRow.Data10 = grdList.Item(menmListCol.XCS_SU, ii).FormattedValue             'C/S数

                objDataRow.EndEdit()

                objDataSet.DataTable01.Rows.Add(objDataRow)

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2013/11/06 在庫ﾘｽﾄでの在庫ｴﾘｱの表示
                mGoukeiPL += TO_DECIMAL(grdList.Item(menmListCol.XPL_SU, ii).FormattedValue)        '合計 PL数
                mGoukeiCS += TO_DECIMAL(grdList.Item(menmListCol.XCS_SU, ii).FormattedValue)        '合計 C/S数
                'JobMate:S.Ouchi 2013/11/06 在庫ﾘｽﾄでの在庫ｴﾘｱの表示
                '↑↑↑↑↑↑************************************************************************************************************
            Next

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/06 在庫ﾘｽﾄでの在庫ｴﾘｱの表示
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText12", TO_STRING(mGoukeiPL))               '合計 PL数
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText13", TO_STRING(mGoukeiCS))               '合計 C/S数
            'JobMate:S.Ouchi 2013/11/06 在庫ﾘｽﾄでの在庫ｴﾘｱの表示
            '↑↑↑↑↑↑************************************************************************************************************

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
#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(詳細)　                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty(ByVal objForm As FRM_204020, ByVal enmCheckCase As menmCheckCase)

        objForm.userOWNER = Me                           'ｵｰﾅｰﾌｫｰﾑ
        Dim intRow As Integer

        Select Case enmCheckCase
            Case menmCheckCase.DtlBtn_Click
                '(詳細展開)
                intRow = grdList.SelectedRows(0).Index

                objForm.userFPLACE_CD = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, intRow).Value)                              '在庫ｴﾘｱ
                objForm.userFPLACE_NM = TO_STRING(grdList.Item(menmListCol.FBUF_NAME, intRow).Value)                                '在庫ｴﾘｱ名
                objForm.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, intRow).Value)                              '品名ｺｰﾄﾞ
                objForm.userFHINMEI = TO_STRING(grdList.Item(menmListCol.FHINMEI, intRow).Value)                                    '品名
                objForm.userXPROD_LINE = TO_STRING(grdList.Item(menmListCol.XPROD_LINE, intRow).Value)                              '生産ﾗｲﾝ№
                objForm.userXPROD_LINE_NM = TO_STRING(grdList.Item(menmListCol.XPROD_LINE_DSP, intRow).Value)                       '生産ﾗｲﾝ№名称
                objForm.userXARTICLE_TYPE_CODE = TO_STRING(grdList.Item(menmListCol.XARTICLE_TYPE_CODE, intRow).Value)              '商品区分
                objForm.userXARTICLE_TYPE_CODE_NM = TO_STRING(grdList.Item(menmListCol.XARTICLE_TYPE_CODE_DSP, intRow).Value)       '商品区分名称
                objForm.userXKENSA_KUBUN = TO_STRING(grdList.Item(menmListCol.XKENSA_KUBUN, intRow).Value)                          '検査区分
                objForm.userXKENSA_KUBUN_NM = TO_STRING(grdList.Item(menmListCol.XKENSA_KUBUN_DSP, intRow).Value)                   '検査区分名称
                objForm.userFHORYU_KUBUN = TO_STRING(grdList.Item(menmListCol.FHORYU_KUBUN, intRow).Value)                          '保留区分
                objForm.userFHORYU_KUBUN_NM = TO_STRING(grdList.Item(menmListCol.FHORYU_KUBUN_DSP, intRow).Value)                   '保留区分名称
                objForm.userXKENPIN_KUBUN = TO_STRING(grdList.Item(menmListCol.XKENPIN_KUBUN, intRow).Value)                        '検品区分
                objForm.userFIN_KUBUN = TO_STRING(grdList.Item(menmListCol.FIN_KUBUN, intRow).Value)                                '入庫区分

                '===============================================
                '入庫日(FROM)
                '===============================================
                If dtpFrom.userDispChecked = True Then
                    'objForm.userFARRIVE_DT_FROM = Format(TO_DATE(dtpFrom.userDateTimeText), "yyyy/MM/dd")   '期間FROM
                    'objForm.userFARRIVE_DT_FROM = objForm.userFARRIVE_DT_FROM & " 00:00:00"
                    objForm.userFARRIVE_DT_FROM = mudtSEARCH_ITEM.ARRIVE_DT_FROM   '期間FROM
                Else
                    objForm.userFARRIVE_DT_FROM = ""
                End If

                '===============================================
                '入庫日(TO)
                '===============================================
                If dtpTo.userDispChecked = True Then
                    'objForm.userFARRIVE_DT_TO = Format(TO_DATE(dtpTo.userDateTimeText), "yyyy/MM/dd")   '期間TO
                    'objForm.userFARRIVE_DT_TO = objForm.userFARRIVE_DT_TO & " 23:59:59"
                    objForm.userFARRIVE_DT_TO = mudtSEARCH_ITEM.ARRIVE_DT_TO       '期間TO
                Else
                    objForm.userFARRIVE_DT_TO = ""
                End If

                objForm.userCRANE = mudtSEARCH_ITEM.CRANE_NAME                                                                      'ｸﾚｰﾝ名
                objForm.userFEQ_ID_CRANE = mudtSEARCH_ITEM.FEQ_ID_CRANE                                             'ｸﾚｰﾝ設備ID

            Case menmCheckCase.AllDtlBtn_Click
                '(全詳細展開)
                objForm.userFPLACE_CD = mudtSEARCH_ITEM.FPLACE_CD                                                   '在庫ｴﾘｱ
                objForm.userFPLACE_NM = mudtSEARCH_ITEM.FPLACE_NM                                                   '在庫ｴﾘｱ名
                objForm.userFHINMEI_CD = mudtSEARCH_ITEM.FHINMEI_CD                                                 '品名ｺｰﾄﾞ
                objForm.userFHINMEI = mudtSEARCH_ITEM.FHINMEI                                                       '品名
                objForm.userXPROD_LINE = mudtSEARCH_ITEM.XPROD_LINE                                                 '生産ﾗｲﾝ№
                objForm.userXPROD_LINE_NM = mudtSEARCH_ITEM.XPROD_LINE_NM                                           '生産ﾗｲﾝ№名称
                objForm.userFEQ_ID_CRANE = mudtSEARCH_ITEM.FEQ_ID_CRANE                                             'ｸﾚｰﾝ設備ID
                objForm.userXARTICLE_TYPE_CODE = mudtSEARCH_ITEM.XARTICLE_TYPE_CODE                                 '商品区分
                objForm.userXARTICLE_TYPE_CODE_NM = mudtSEARCH_ITEM.XARTICLE_TYPE_CODE_NM                           '商品区分名称
                objForm.userXKENSA_KUBUN = mudtSEARCH_ITEM.XKENSA_KUBUN                                             '検査区分
                objForm.userXKENSA_KUBUN_NM = mudtSEARCH_ITEM.XKENSA_KUBUN_NM                                       '検査区分名称
                objForm.userFHORYU_KUBUN = mudtSEARCH_ITEM.FHORYU_KUBUN                                             '保留区分
                objForm.userFHORYU_KUBUN_NM = mudtSEARCH_ITEM.FHORYU_KUBUN_NM                                       '保留区分名称


                '===============================================
                '入庫日(FROM)
                '===============================================
                If dtpFrom.userDispChecked = True Then
                    'objForm.userFARRIVE_DT_FROM = Format(TO_DATE(dtpFrom.userDateTimeText), "yyyy/MM/dd")   '期間FROM
                    'objForm.userFARRIVE_DT_FROM = objForm.userFARRIVE_DT_FROM & " 00:00:00"
                    objForm.userFARRIVE_DT_FROM = mudtSEARCH_ITEM.ARRIVE_DT_FROM   '期間FROM
                Else
                    objForm.userFARRIVE_DT_FROM = ""
                End If

                '===============================================
                '入庫日(TO)
                '===============================================
                If dtpTo.userDispChecked = True Then
                    'objForm.userFARRIVE_DT_TO = Format(TO_DATE(dtpTo.userDateTimeText), "yyyy/MM/dd")   '期間TO
                    'objForm.userFARRIVE_DT_TO = objForm.userFARRIVE_DT_TO & " 23:59:59"
                    objForm.userFARRIVE_DT_TO = mudtSEARCH_ITEM.ARRIVE_DT_TO       '期間TO
                Else
                    objForm.userFARRIVE_DT_TO = ""
                End If

                objForm.userCRANE = mudtSEARCH_ITEM.CRANE_NAME                                                                      'ｸﾚｰﾝ名

        End Select


    End Sub
#End Region




    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:H.Okumura 2013/07/01 品目集計に対応ver. 変更前
#Region "　ﾘｽﾄ表示　                                "
    '' ''*******************************************************************************************************************
    '' ''【機能】同上
    '' ''【引数】
    '' ''【戻値】
    '' ''*******************************************************************************************************************
    ' ''Public Overrides Sub grdListDisplayChild()

    ' ''    Dim strSQL As String                        'SQL文

    ' ''    '********************************************************************
    ' ''    ' SQL文作成
    ' ''    '********************************************************************
    ' ''    '============================================================
    ' ''    'SELECT
    ' ''    '============================================================
    ' ''    strSQL = ""
    ' ''    strSQL &= vbCrLf & " SELECT "
    ' ''    strSQL &= vbCrLf & "        TPRG_TRK_BUF.FTRK_BUF_NO "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(非表示)
    ' ''    strSQL &= vbCrLf & "      , TMST_TRK.FBUF_NAME "                                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
    ' ''    '↓↓↓↓↓↓************************************************************************************************************
    ' ''    'SystemMate:H.Okumura 2013/06/05 ｸﾞﾘｯﾄﾞ項目変更
    ' ''    strSQL &= vbCrLf & "      , TMST_ITEM.XHINMEI_CD "                                  '品目ﾏｽﾀ        .品名記号
    ' ''    strSQL &= vbCrLf & "      , TRST_STOCK.FHINMEI_CD "                                 '在庫情報       .品名ｺｰﾄﾞ
    ' ''    '↑↑↑↑↑↑************************************************************************************************************
    ' ''    strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI "                                     '品目ﾏｽﾀ        .品名
    ' ''    strSQL &= vbCrLf & "      , TRST_STOCK.XPROD_LINE "                                 '在庫情報       .生産ﾗｲﾝ№
    ' ''    strSQL &= vbCrLf & "      , HASH01.XPROD_LINE_NAME AS XPROD_LINE_DSP "              '在庫情報       .生産ﾗｲﾝ№(表示用)
    ' ''    '↓↓↓↓↓↓************************************************************************************************************
    ' ''    'SystemMate:H.Okumura 2013/06/11 ｸﾞﾘｯﾄﾞ項目変更
    ' ''    strSQL &= vbCrLf & "      , TMST_ITEM.XARTICLE_TYPE_CODE "                          '品目ﾏｽﾀ        .商品区分
    ' ''    strSQL &= vbCrLf & "      , HASH02.FGAMEN_DISP AS XARTICLE_TYPE_CODE_DSP "          '品目ﾏｽﾀ        .商品区分(表示用)
    ' ''    '↑↑↑↑↑↑************************************************************************************************************
    ' ''    strSQL &= vbCrLf & "      , TRST_STOCK.XKENSA_KUBUN "                               '在庫情報       .検査区分
    ' ''    strSQL &= vbCrLf & "      , HASH03.FGAMEN_DISP AS XKENSA_KUBUN_DSP "                '在庫情報       .検査区分(表示用)
    ' ''    strSQL &= vbCrLf & "      , TRST_STOCK.FHORYU_KUBUN "                               '在庫情報       .保留区分
    ' ''    strSQL &= vbCrLf & "      , HASH04.FGAMEN_DISP AS FHORYU_KUBUN_DSP "                '在庫情報       .保留区分(表示用)
    ' ''    strSQL &= vbCrLf & "      , TRST_STOCK.XKENPIN_KUBUN "                              '在庫情報       .検品区分
    ' ''    strSQL &= vbCrLf & "      , HASH05.FGAMEN_DISP AS XKENPIN_KUBUN_DSP "               '在庫情報       .検品区分(表示用)
    ' ''    strSQL &= vbCrLf & "      , TRST_STOCK.FIN_KUBUN "                                  '在庫情報       .入庫区分
    ' ''    strSQL &= vbCrLf & "      , HASH06.FGAMEN_DISP AS FIN_KUBUN_DSP "                   '在庫情報       .入庫区分(表示用)
    ' ''    strSQL &= vbCrLf & "      , COUNT(0) AS XPL_SU "                                    '               .PL数
    ' ''    strSQL &= vbCrLf & "      , SUM(TRST_STOCK.FTR_VOL) AS XCS_SU "                     '               .C/S数

    ' ''    '============================================================
    ' ''    'FROM
    ' ''    '============================================================
    ' ''    strSQL &= vbCrLf & " FROM "
    ' ''    strSQL &= vbCrLf & "        TPRG_TRK_BUF "
    ' ''    strSQL &= vbCrLf & "      , TMST_TRK "
    ' ''    strSQL &= vbCrLf & "      , TRST_STOCK "
    ' ''    strSQL &= vbCrLf & "      , TMST_ITEM "
    ' ''    strSQL &= vbCrLf & "      , " & gobjComFuncFRM.GetSQLHashTableFrom02("HASH01", "XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", "TRST_STOCK", "XPROD_LINE")
    ' ''    strSQL &= vbCrLf & "      , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TMST_ITEM", "XARTICLE_TYPE_CODE")
    ' ''    strSQL &= vbCrLf & "      , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TRST_STOCK", "XKENSA_KUBUN")
    ' ''    strSQL &= vbCrLf & "      , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "TRST_STOCK", "FHORYU_KUBUN")
    ' ''    strSQL &= vbCrLf & "      , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH05", "TRST_STOCK", "XKENPIN_KUBUN")
    ' ''    strSQL &= vbCrLf & "      , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH06", "TRST_STOCK", "FIN_KUBUN")


    ' ''    '============================================================
    ' ''    'WHERE
    ' ''    '============================================================
    ' ''    strSQL &= vbCrLf & " WHERE 0 = 0 "
    ' ''    strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FPALLET_ID = TRST_STOCK.FPALLET_ID(+) "
    ' ''    strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
    ' ''    strSQL &= vbCrLf & "      AND TRST_STOCK.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
    ' ''    strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FRES_KIND = " & FRES_KIND_SZAIKO                '引当状態：在庫
    ' ''    strSQL &= vbCrLf & "      AND " & gobjComFuncFRM.GetSQLHashTableWhere02("HASH01", "XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", "TRST_STOCK", "XPROD_LINE")
    ' ''    strSQL &= vbCrLf & "      AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TMST_ITEM", "XARTICLE_TYPE_CODE")
    ' ''    strSQL &= vbCrLf & "      AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TRST_STOCK", "XKENSA_KUBUN")
    ' ''    strSQL &= vbCrLf & "      AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "TRST_STOCK", "FHORYU_KUBUN")
    ' ''    strSQL &= vbCrLf & "      AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH05", "TRST_STOCK", "XKENPIN_KUBUN")
    ' ''    strSQL &= vbCrLf & "      AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH06", "TRST_STOCK", "FIN_KUBUN")


    ' ''    '----------------------------------------------
    ' ''    '在庫ｴﾘｱ
    ' ''    '----------------------------------------------
    ' ''    If mudtSEARCH_ITEM.FPLACE_CD <> CBO_ALL_VALUE Then
    ' ''        '(全検索以外の場合)
    ' ''        strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = '" & mudtSEARCH_ITEM.FPLACE_CD & "' "
    ' ''    Else
    ' ''        '(全検索の場合)
    ' ''        strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO IN('" & FTRK_BUF_NO_J9000 & "','" & FTRK_BUF_NO_J9100 & "','" & FTRK_BUF_NO_J9200 & "') "
    ' ''    End If

    ' ''    '----------------------------
    ' ''    '品名ｺｰﾄﾞ
    ' ''    '----------------------------
    ' ''    If mudtSEARCH_ITEM.FHINMEI_CD <> "" Then
    ' ''        If IsNumeric(mudtSEARCH_ITEM.FHINMEI_CD.Substring(0, 1)) Then
    ' ''            '(品名ｺｰﾄﾞ)
    ' ''            strSQL &= vbCrLf & "    AND TMST_ITEM.XHINMEI_CD LIKE '" & mudtSEARCH_ITEM.FHINMEI_CD & "%' "
    ' ''        Else
    ' ''            '(品名記号)
    ' ''            strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD LIKE '" & mudtSEARCH_ITEM.FHINMEI_CD & "%' "
    ' ''        End If

    ' ''    End If

    ' ''    '----------------------------
    ' ''    '入庫日
    ' ''    '----------------------------
    ' ''    If mudtSEARCH_ITEM.ARRIVE_DT_FROM <> "" Then
    ' ''        strSQL &= vbCrLf & "    AND TRST_STOCK.FARRIVE_DT >= TO_DATE('" & mudtSEARCH_ITEM.ARRIVE_DT_FROM & "','YYYY/MM/DD HH24:MI:SS')"
    ' ''    End If
    ' ''    If mudtSEARCH_ITEM.ARRIVE_DT_TO <> "" Then
    ' ''        strSQL &= vbCrLf & "    AND TRST_STOCK.FARRIVE_DT <= TO_DATE('" & mudtSEARCH_ITEM.ARRIVE_DT_TO & "','YYYY/MM/DD HH24:MI:SS')"
    ' ''    End If

    ' ''    '----------------------------
    ' ''    '生産ﾗｲﾝNo.
    ' ''    '----------------------------
    ' ''    If mudtSEARCH_ITEM.XPROD_LINE <> "" Then
    ' ''        strSQL &= vbCrLf & "    AND TRST_STOCK.XPROD_LINE = '" & mudtSEARCH_ITEM.XPROD_LINE & "' "
    ' ''    End If

    ' ''    '↓↓↓↓↓↓************************************************************************************************************
    ' ''    'JobMate:H.Okumura 2013/06/11 ｸﾚｰﾝ追加
    ' ''    '----------------------------
    ' ''    'ｸﾚｰﾝ
    ' ''    '----------------------------
    ' ''    If mudtSEARCH_ITEM.FEQ_ID_CRANE <> "" Then
    ' ''        '(全検索以外の場合)

    ' ''        '**********************************************************
    ' ''        ' 対象列の特定
    ' ''        '**********************************************************
    ' ''        Dim objTBL_TMST_CRANE As New TBL_TMST_CRANE(gobjOwner, gobjDb, Nothing)
    ' ''        objTBL_TMST_CRANE.FEQ_ID = mudtSEARCH_ITEM.FEQ_ID_CRANE   '設備ID
    ' ''        objTBL_TMST_CRANE.GET_TMST_CRANE(False)

    ' ''        Dim strRETU1 As String = TO_STRING(objTBL_TMST_CRANE.FCRANE_ROW1)   '列1
    ' ''        Dim strRETU2 As String = TO_STRING(objTBL_TMST_CRANE.FCRANE_ROW2)   '列2

    ' ''        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRAC_RETU IN ( " & strRETU1 & ", " & strRETU2 & ") "

    ' ''        objTBL_TMST_CRANE.Close()

    ' ''    End If
    ' ''    '↑↑↑↑↑↑************************************************************************************************************




    ' ''    '↓↓↓↓↓↓************************************************************************************************************
    ' ''    'JobMate:H.Okumura 2013/06/05 商品区分追加
    ' ''    '----------------------------
    ' ''    '商品区分
    ' ''    '----------------------------
    ' ''    If mudtSEARCH_ITEM.XARTICLE_TYPE_CODE <> "" Then
    ' ''        '(全検索以外の場合)
    ' ''        strSQL &= vbCrLf & "    AND TMST_ITEM.XARTICLE_TYPE_CODE = " & mudtSEARCH_ITEM.XARTICLE_TYPE_CODE
    ' ''    End If
    ' ''    '↑↑↑↑↑↑************************************************************************************************************

    ' ''    '----------------------------
    ' ''    '検査区分
    ' ''    '----------------------------
    ' ''    If mudtSEARCH_ITEM.XKENSA_KUBUN <> "" Then
    ' ''        '(全検索以外の場合)
    ' ''        strSQL &= vbCrLf & "    AND TRST_STOCK.XKENSA_KUBUN = " & mudtSEARCH_ITEM.XKENSA_KUBUN
    ' ''    End If

    ' ''    '----------------------------
    ' ''    '保留区分
    ' ''    '----------------------------
    ' ''    If mudtSEARCH_ITEM.FHORYU_KUBUN <> "" Then
    ' ''        '(全検索以外の場合)
    ' ''        strSQL &= vbCrLf & "    AND TRST_STOCK.FHORYU_KUBUN = " & mudtSEARCH_ITEM.FHORYU_KUBUN
    ' ''    End If


    ' ''    '============================================================
    ' ''    'GROUP BY
    ' ''    '============================================================
    ' ''    strSQL &= vbCrLf & "  GROUP BY "
    ' ''    strSQL &= vbCrLf & "        TPRG_TRK_BUF.FTRK_BUF_NO "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(非表示)
    ' ''    strSQL &= vbCrLf & "      , TMST_TRK.FBUF_NAME "                                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
    ' ''    strSQL &= vbCrLf & "      , TRST_STOCK.FHINMEI_CD "                                 '在庫情報       .品名ｺｰﾄﾞ
    ' ''    strSQL &= vbCrLf & "      , TMST_ITEM.XHINMEI_CD "                                  '品目ﾏｽﾀ        .品名記号
    ' ''    strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI "                                     '品目ﾏｽﾀ        .品名
    ' ''    strSQL &= vbCrLf & "      , TRST_STOCK.XPROD_LINE "                                 '在庫情報       .生産ﾗｲﾝ№
    ' ''    strSQL &= vbCrLf & "      , HASH01.XPROD_LINE_NAME "                                '在庫情報       .生産ﾗｲﾝ№(表示用)
    ' ''    strSQL &= vbCrLf & "      , TMST_ITEM.XARTICLE_TYPE_CODE "                          '品目ﾏｽﾀ        .商品区分
    ' ''    strSQL &= vbCrLf & "      , HASH02.FGAMEN_DISP "                                    '品目ﾏｽﾀ        .商品区分(表示用)
    ' ''    strSQL &= vbCrLf & "      , TRST_STOCK.XKENSA_KUBUN "                               '在庫情報       .検査区分
    ' ''    strSQL &= vbCrLf & "      , HASH03.FGAMEN_DISP "                                    '在庫情報       .検査区分(表示用)
    ' ''    strSQL &= vbCrLf & "      , TRST_STOCK.FHORYU_KUBUN "                               '在庫情報       .保留区分
    ' ''    strSQL &= vbCrLf & "      , HASH04.FGAMEN_DISP "                                    '在庫情報       .保留区分(表示用)
    ' ''    strSQL &= vbCrLf & "      , TRST_STOCK.XKENPIN_KUBUN "                              '在庫情報       .検品区分
    ' ''    strSQL &= vbCrLf & "      , HASH05.FGAMEN_DISP  "                                   '在庫情報       .検品区分(表示用)
    ' ''    strSQL &= vbCrLf & "      , TRST_STOCK.FIN_KUBUN "                                  '在庫情報       .入庫区分
    ' ''    strSQL &= vbCrLf & "      , HASH06.FGAMEN_DISP  "                                   '在庫情報       .入庫区分(表示用)


    ' ''    '============================================================
    ' ''    'ORDER BY
    ' ''    '============================================================
    ' ''    strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)



    ' ''    '********************************************************************
    ' ''    'ｸﾞﾘｯﾄﾞ表示
    ' ''    '********************************************************************
    ' ''    Call gobjComFuncFRM.TblDataGridDisplay(grdList, _
    ' ''                            strSQL, _
    ' ''                            True)

    ' ''    '********************************************************************
    ' ''    'ｸﾞﾘｯﾄﾞ表示設定
    ' ''    '********************************************************************
    ' ''    Call grdListSetup()
    ' ''    Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理


    ' ''    mFlag_Disp_Grid = True          'ｸﾞﾘｯﾄﾞ表示ありﾌﾗｸﾞ

    ' ''End Sub
#End Region
    '↑↑↑↑↑↑************************************************************************************************************
End Class
