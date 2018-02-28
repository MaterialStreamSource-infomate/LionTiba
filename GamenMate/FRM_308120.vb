'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】引当情報問合せ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_308120

#Region "　共通変数　                               "

    Protected mudtSEARCH_ITEM As New stcSEARCH_ITEM     '検索条件用構造体

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ
    Private mFlag_GRID_CLEAR As Boolean = True          'ｸﾞﾘｯﾄﾞｸﾘｱ済みﾌﾗｸﾞ

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        FTRK_BUF_NO                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ       .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        FBUF_NAME                   'ﾄﾗｯｷﾝｸﾞﾏｽﾀ         .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        FHINMEI_CD                  '出荷計画詳細       .品名ｺｰﾄﾞ
        FHINMEI                     '出荷計画詳細       .品名
        XSEIZOU_DT                  '在庫情報_仮1       .製造年月日
        XHINSHITU_STS               '出荷計画詳細       .品質ｽﾃｰﾀｽ
        XHINSHITU_STS_DSP           '出荷計画詳細       .品質ｽﾃｰﾀｽ(表示用)
        XSYUKKA_VOL                 '出荷計画詳細       .出荷数(C/S数)
        XHIKIATE_VOL                '在庫引当情報_仮1   .引当C/S数

        MAXCOL                 'ｸﾞﾘｯﾄﾞの列数の最大値
    End Enum

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        SearchBtn_Click             '検索ﾎﾞﾀﾝｸﾘｯｸ時
        DtlBtn_Click                '詳細ﾎﾞﾀﾝｸﾘｯｸ
        AllDtlBtn_Click             '全詳細ﾎﾞﾀﾝｸﾘｯｸ
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Protected Structure stcSEARCH_ITEM
        Dim FPLACE_CD As String                 '保管場所
        Dim FHINMEI_CD As String                '品名ｺｰﾄﾞ
        Dim XSEIZOU_DT As String                '製造年月日
        Dim XHINSHITU_STS As String             '品質ｽﾃｰﾀｽ
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2012/12/10 詳細情報で品目集計情報を見るようにする
        Dim HINMOK_SUM As String                '品目集計
        '↑↑↑↑↑↑************************************************************************************************************

    End Structure
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　保管場所ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 保管場所ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFPLACE_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPLACE_CD.SelectedIndexChanged
        Try


            If mFlag_Form_Load = False Then

                '===================================
                '引当情報問合せ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
                '===================================
                'Call MakeHikiateToiawase_cboFHINMEI_CD(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), cboFHINMEI_CD, True)         '品名ｺｰﾄﾞ

                cboFHINMEI_CD.conn = gobjDb                 '品名ｺｰﾄﾞ
                cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
                cboFHINMEI_CD.Text = ""
                'cboFHINMEI_CD.TableName = "TRST_STOCK"
                cboFHINMEI_CD.TableName = "XRST_STOCK_K1"
                cboFHINMEI_CD.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT
                cboFHINMEI_CD.ComboBoxType = GamenCommon.cmpCboFHINMEI_CD.HINMEI_CBO_TYPE.SpecifiedAndMasterData
                cboFHINMEI_CD.HinmeiVisible = False
                If TO_STRING(cboFPLACE_CD.SelectedValue.ToString) <> CBO_ALL_VALUE Then
                    '(全検索以外の場合)
                    ReDim cboFHINMEI_CD.FTRK_BUF_NO(0)                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№指定
                    cboFHINMEI_CD.FTRK_BUF_NO(0) = TO_STRING(cboFPLACE_CD.SelectedValue.ToString)
                Else
                    '(全検索の場合)
                    ReDim cboFHINMEI_CD.FTRK_BUF_NO(21)                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№指定
                    cboFHINMEI_CD.FTRK_BUF_NO(0) = FTRK_BUF_NO_J9000
                    cboFHINMEI_CD.FTRK_BUF_NO(1) = FTRK_BUF_NO_J8000
                    cboFHINMEI_CD.FTRK_BUF_NO(2) = FTRK_BUF_NO_J8001
                    cboFHINMEI_CD.FTRK_BUF_NO(3) = FTRK_BUF_NO_J8002
                    cboFHINMEI_CD.FTRK_BUF_NO(4) = FTRK_BUF_NO_J8100
                    cboFHINMEI_CD.FTRK_BUF_NO(5) = FTRK_BUF_NO_J8101
                    cboFHINMEI_CD.FTRK_BUF_NO(6) = FTRK_BUF_NO_J8102
                    cboFHINMEI_CD.FTRK_BUF_NO(7) = FTRK_BUF_NO_J8103
                    cboFHINMEI_CD.FTRK_BUF_NO(8) = FTRK_BUF_NO_J8104
                    cboFHINMEI_CD.FTRK_BUF_NO(9) = FTRK_BUF_NO_J8105
                    cboFHINMEI_CD.FTRK_BUF_NO(10) = FTRK_BUF_NO_J8106
                    cboFHINMEI_CD.FTRK_BUF_NO(11) = FTRK_BUF_NO_J8107
                    cboFHINMEI_CD.FTRK_BUF_NO(12) = FTRK_BUF_NO_J8108
                    cboFHINMEI_CD.FTRK_BUF_NO(13) = FTRK_BUF_NO_J8109
                    cboFHINMEI_CD.FTRK_BUF_NO(14) = FTRK_BUF_NO_J8201
                    cboFHINMEI_CD.FTRK_BUF_NO(15) = FTRK_BUF_NO_J8202
                    cboFHINMEI_CD.FTRK_BUF_NO(16) = FTRK_BUF_NO_J8203
                    cboFHINMEI_CD.FTRK_BUF_NO(17) = FTRK_BUF_NO_J8204
                    cboFHINMEI_CD.FTRK_BUF_NO(18) = FTRK_BUF_NO_J8205
                    cboFHINMEI_CD.FTRK_BUF_NO(19) = FTRK_BUF_NO_J8206
                    cboFHINMEI_CD.FTRK_BUF_NO(20) = FTRK_BUF_NO_J8207
                    cboFHINMEI_CD.FTRK_BUF_NO(21) = FTRK_BUF_NO_J8208

                End If
                cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)          '品名ｺｰﾄﾞ


                Call MakeHikiateToiawase_cboXSEIZOU_DT(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), cboFHINMEI_CD.Text, cboXSEIZOU_DT, True)         '製造年月日
                'Call MakeHikiateToiawase_cboXHINSHITU_STS(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), cboXHINSHITU_STS, True)   '品質ｽﾃｰﾀｽ
                cboXHINSHITU_STS.SelectedIndex = -1

                If mFlag_GRID_CLEAR = False Then
                    '(ｸﾞﾘｯﾄﾞ表示ありの時)
                    '*********************************************
                    ' ｸﾞﾘｯﾄﾞ表示
                    '*********************************************
                    grdList.Columns.Clear()
                    Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
                    Call grdListSetup()

                    mFlag_GRID_CLEAR = True
                End If

            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
    '↓↓↓↓ 2012.11.28 16:00 H.Morita 検索範囲の絞込み
#Region "　品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ   "
    '* 2012/11/29 10:00 H.Morita ﾃｷｽﾄ変更時対応 * Private Sub cboFHINMEI_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFHINMEI_CD.SelectedIndexChanged
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFHINMEI_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFHINMEI_CD.TextChanged
        Try


            If mFlag_Form_Load = False Then

                '===================================
                '引当情報問合せ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
                '===================================
                Call MakeHikiateToiawase_cboXSEIZOU_DT(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), cboFHINMEI_CD.Text, cboXSEIZOU_DT, True)         '製造年月日

                cboXHINSHITU_STS.SelectedIndex = -1

                If mFlag_GRID_CLEAR = False Then
                    '(ｸﾞﾘｯﾄﾞ表示ありの時)
                    '*********************************************
                    ' ｸﾞﾘｯﾄﾞ表示
                    '*********************************************
                    grdList.Columns.Clear()
                    Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
                    Call grdListSetup()

                    mFlag_GRID_CLEAR = True
                End If

            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
    '↑↑↑↑ 2012.11.28 16:00 H.Morita 検索範囲の絞込み
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    Public Overrides Sub InitializeChild()


        '*********************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽ初期設定
        '*********************************************
        '===================================
        '保管場所                   ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFPLACE_CD, True)


        '===================================
        '引当情報問合せ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = ""
        'cboFHINMEI_CD.TableName = "TRST_STOCK"
        cboFHINMEI_CD.TableName = "XRST_STOCK_K1"
        cboFHINMEI_CD.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT
        cboFHINMEI_CD.ComboBoxType = GamenCommon.cmpCboFHINMEI_CD.HINMEI_CBO_TYPE.SpecifiedAndMasterData
        cboFHINMEI_CD.HinmeiVisible = False
        ReDim cboFHINMEI_CD.FTRK_BUF_NO(21)                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№指定
        cboFHINMEI_CD.FTRK_BUF_NO(0) = FTRK_BUF_NO_J9000
        cboFHINMEI_CD.FTRK_BUF_NO(1) = FTRK_BUF_NO_J8000
        cboFHINMEI_CD.FTRK_BUF_NO(2) = FTRK_BUF_NO_J8001
        cboFHINMEI_CD.FTRK_BUF_NO(3) = FTRK_BUF_NO_J8002
        cboFHINMEI_CD.FTRK_BUF_NO(4) = FTRK_BUF_NO_J8100
        cboFHINMEI_CD.FTRK_BUF_NO(5) = FTRK_BUF_NO_J8101
        cboFHINMEI_CD.FTRK_BUF_NO(6) = FTRK_BUF_NO_J8102
        cboFHINMEI_CD.FTRK_BUF_NO(7) = FTRK_BUF_NO_J8103
        cboFHINMEI_CD.FTRK_BUF_NO(8) = FTRK_BUF_NO_J8104
        cboFHINMEI_CD.FTRK_BUF_NO(9) = FTRK_BUF_NO_J8105
        cboFHINMEI_CD.FTRK_BUF_NO(10) = FTRK_BUF_NO_J8106
        cboFHINMEI_CD.FTRK_BUF_NO(11) = FTRK_BUF_NO_J8107
        cboFHINMEI_CD.FTRK_BUF_NO(12) = FTRK_BUF_NO_J8108
        cboFHINMEI_CD.FTRK_BUF_NO(13) = FTRK_BUF_NO_J8109
        cboFHINMEI_CD.FTRK_BUF_NO(14) = FTRK_BUF_NO_J8201
        cboFHINMEI_CD.FTRK_BUF_NO(15) = FTRK_BUF_NO_J8202
        cboFHINMEI_CD.FTRK_BUF_NO(16) = FTRK_BUF_NO_J8203
        cboFHINMEI_CD.FTRK_BUF_NO(17) = FTRK_BUF_NO_J8204
        cboFHINMEI_CD.FTRK_BUF_NO(18) = FTRK_BUF_NO_J8205
        cboFHINMEI_CD.FTRK_BUF_NO(19) = FTRK_BUF_NO_J8206
        cboFHINMEI_CD.FTRK_BUF_NO(20) = FTRK_BUF_NO_J8207
        cboFHINMEI_CD.FTRK_BUF_NO(21) = FTRK_BUF_NO_J8208
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)          '品名ｺｰﾄﾞ

        Call MakeHikiateToiawase_cboXSEIZOU_DT(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), cboFHINMEI_CD.Text, cboXSEIZOU_DT, True)         '製造年月日

        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXHINSHITU_STS, True)       '品質ｽﾃｰﾀｽ

        lblFHINMEI.Text = ""           '品名

        chkHINMOK_SUM.Checked = False           '品目集計

        '*********************************************
        ' ﾘｽﾄ表示
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)    'ｸﾞﾘｯﾄﾞ初期設定 
        Call grdListSetup()


        mFlag_Form_Load = False


    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                               "
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        cboFPLACE_CD.Dispose()            '保管場所
        cboFHINMEI_CD.Dispose()           '品名ｺｰﾄﾞ
        cboXSEIZOU_DT.Dispose()           '製造年月日
        cboXHINSHITU_STS.Dispose()        '品質ｽﾃｰﾀｽ
        chkHINMOK_SUM.Dispose()           '品目集計
        grdList.Dispose()                 'ｸﾞﾘｯﾄﾞ

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
        If IsNull(gobjFRM_308121) = False Then
            gobjFRM_308121.Close()
            gobjFRM_308121.Dispose()
            gobjFRM_308121 = Nothing
        End If

        '********************************************************************
        ' 詳細 ﾌｫｰﾑ展開
        '********************************************************************
        gobjFRM_308121 = New FRM_308121                             'ｵﾌﾞｼﾞｪｸﾄ作成

        Call SetProperty(gobjFRM_308121, menmCheckCase.DtlBtn_Click)                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        Call gobjFRM_308121.ShowDialog()        '画面表示

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
        If IsNull(gobjFRM_308121) = False Then
            gobjFRM_308121.Close()
            gobjFRM_308121.Dispose()
            gobjFRM_308121 = Nothing
        End If

        '********************************************************************
        ' 追加/変更ﾌｫｰﾑ展開
        '********************************************************************
        gobjFRM_308121 = New FRM_308121                             'ｵﾌﾞｼﾞｪｸﾄ作成

        Call SetProperty(gobjFRM_308121, menmCheckCase.AllDtlBtn_Click)                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        Call gobjFRM_308121.ShowDialog()        '画面表示


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
#Region "  F8  ﾎﾞﾀﾝ押下処理　                       "
    '*******************************************************************************************************************
    '【機能】F8  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F8Process()

        '******************************************
        ' 画面遷移
        '******************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204000, Me)

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
        mudtSEARCH_ITEM.FPLACE_CD = TO_STRING(cboFPLACE_CD.SelectedValue)                   '保管場所
        mudtSEARCH_ITEM.FHINMEI_CD = cboFHINMEI_CD.Text                                     '品名ｺｰﾄﾞ
        mudtSEARCH_ITEM.XSEIZOU_DT = TO_STRING(cboXSEIZOU_DT.SelectedValue)                 '製造年月日
        mudtSEARCH_ITEM.XHINSHITU_STS = TO_STRING(cboXHINSHITU_STS.SelectedValue)           '品質ｽﾃｰﾀｽ

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2012/12/10 詳細情報で品目集計情報を見るようにする
        If chkHINMOK_SUM.Checked = False Then
            '(品目集計でない時)
            mudtSEARCH_ITEM.HINMOK_SUM = False          '品目集計
        Else
            '(品目集計の時)
            mudtSEARCH_ITEM.HINMOK_SUM = True           '品目集計
        End If
        '↑↑↑↑↑↑************************************************************************************************************


    End Sub
#End Region
#Region "　ﾘｽﾄ表示　                                "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()


        Dim strSQL As String                        'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""

        If chkHINMOK_SUM.Checked = True Then
            '(品目集計の時)
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "        FTRK_BUF_NO "                                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(非表示)
            strSQL &= vbCrLf & "      , FBUF_NAME "                                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
            strSQL &= vbCrLf & "      , FHINMEI_CD "                                        '出荷計画詳細   .品名ｺｰﾄﾞ
            strSQL &= vbCrLf & "      , FHINMEI "                                           '出荷計画詳細   .品名

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:A.Noto 2012/12/10 在庫情報を結合
            'strSQL &= vbCrLf & "      , MAX(XSEIZOU_DT)        AS XSEIZOU_DT "              '出荷計画詳細   .製造年月日
            'strSQL &= vbCrLf & "      , MAX(XHINSHITU_STS)     AS XHINSHITU_STS "           '出荷計画詳細   .品質ｽﾃｰﾀｽ
            'strSQL &= vbCrLf & "      , MAX(XHINSHITU_STS_DSP) AS XHINSHITU_STS_DSP "       '出荷計画詳細   .品質ｽﾃｰﾀｽ(表示用)
            strSQL &= vbCrLf & "      , ''     AS XSEIZOU_DT "              '出荷計画詳細   .製造年月日
            strSQL &= vbCrLf & "      , ''     AS XHINSHITU_STS "           '出荷計画詳細   .品質ｽﾃｰﾀｽ
            strSQL &= vbCrLf & "      , ''     AS XHINSHITU_STS_DSP "       '出荷計画詳細   .品質ｽﾃｰﾀｽ(表示用)
            '↑↑↑↑↑↑************************************************************************************************************

            strSQL &= vbCrLf & "      , SUM(XSYUKKA_VOL)       AS XSYUKKA_VOL "             '出荷計画詳細   .出荷数(C/S数)
            strSQL &= vbCrLf & "      , SUM(XHIKIATE_VOL)      AS XHIKIATE_VOL "            '在庫引当情報   .引当C/S数
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & " ( "
        End If


        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2012/12/10 在庫情報を結合
        strSQL &= vbCrLf & "  SELECT "
        strSQL &= vbCrLf & "         A.FTRK_BUF_NO "
        strSQL &= vbCrLf & "       , A.FBUF_NAME "
        strSQL &= vbCrLf & "       , A.FHINMEI_CD "
        strSQL &= vbCrLf & "       , A.FHINMEI "
        strSQL &= vbCrLf & "       , A.XSEIZOU_DT "
        strSQL &= vbCrLf & "       , A.XHINSHITU_STS "
        strSQL &= vbCrLf & "       , A.XHINSHITU_STS_DSP "
        strSQL &= vbCrLf & "       , B.B1 AS XSYUKKA_VOL "
        strSQL &= vbCrLf & "       , A.XHIKIATE_VOL AS XHIKIATE_VOL "
        strSQL &= vbCrLf & "   FROM "
        strSQL &= vbCrLf & "      ( "
        '↑↑↑↑↑↑************************************************************************************************************

        strSQL &= vbCrLf & "  SELECT "
        strSQL &= vbCrLf & "         FTRK_BUF_NO "
        strSQL &= vbCrLf & "       , FBUF_NAME "
        strSQL &= vbCrLf & "       , FHINMEI_CD "
        strSQL &= vbCrLf & "       , FHINMEI "
        strSQL &= vbCrLf & "       , XSEIZOU_DT "
        strSQL &= vbCrLf & "       , XHINSHITU_STS "
        strSQL &= vbCrLf & "       , XHINSHITU_STS_DSP "
        strSQL &= vbCrLf & "       , SUM(XSYUKKA_VOL) AS XSYUKKA_VOL "
        strSQL &= vbCrLf & "       , SUM(XHIKIATE_VOL) AS XHIKIATE_VOL "
        strSQL &= vbCrLf & "  FROM "
        strSQL &= vbCrLf & "   ("
        strSQL &= vbCrLf & "    SELECT "
        strSQL &= vbCrLf & "           TPRG_TRK_BUF.FTRK_BUF_NO "
        strSQL &= vbCrLf & "         , TMST_TRK.FBUF_NAME "
        strSQL &= vbCrLf & "         , XPLN_OUT_DTL.FHINMEI_CD "
        strSQL &= vbCrLf & "         , XPLN_OUT_DTL.FHINMEI "
        strSQL &= vbCrLf & "         , ( "
        strSQL &= vbCrLf & "            SELECT "
        strSQL &= vbCrLf & "               XRST_STOCK_K1.XSEIZOU_DT "
        strSQL &= vbCrLf & "  		    FROM "
        strSQL &= vbCrLf & "       	       XRST_STOCK_K1 "
        strSQL &= vbCrLf & " 	        WHERE 0 = 0 "
        strSQL &= vbCrLf & "       	     AND XSTS_HIKIATE_K1.FPALLET_ID        = XRST_STOCK_K1.FPALLET_ID "
        strSQL &= vbCrLf & "             AND XSTS_HIKIATE_K1.FLOT_NO_STOCK     = XRST_STOCK_K1.FLOT_NO_STOCK "
        strSQL &= vbCrLf & "           ) AS XSEIZOU_DT "
        strSQL &= vbCrLf & "         , XPLN_OUT_DTL.XHINSHITU_STS "
        strSQL &= vbCrLf & "         , HASH01.FGAMEN_DISP AS XHINSHITU_STS_DSP "
        strSQL &= vbCrLf & "         , ( "
        strSQL &= vbCrLf & " 		    SELECT "
        strSQL &= vbCrLf & "         	   XRST_STOCK_K1.FTR_VOL "
        strSQL &= vbCrLf & "  		    FROM "
        strSQL &= vbCrLf & "       	       XRST_STOCK_K1 "
        strSQL &= vbCrLf & " 	        WHERE 0 = 0 "
        strSQL &= vbCrLf & "       	     AND XSTS_HIKIATE_K1.FPALLET_ID        = XRST_STOCK_K1.FPALLET_ID "
        strSQL &= vbCrLf & "             AND XSTS_HIKIATE_K1.FLOT_NO_STOCK     = XRST_STOCK_K1.FLOT_NO_STOCK "
        strSQL &= vbCrLf & "           ) AS XSYUKKA_VOL "
        strSQL &= vbCrLf & "         , SUM(XSTS_HIKIATE_K1.FTR_VOL) AS XHIKIATE_VOL "
        strSQL &= vbCrLf & "         , XSTS_HIKIATE_K1.FPALLET_ID "
        strSQL &= vbCrLf & "         , XSTS_HIKIATE_K1.FLOT_NO_STOCK "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "       XPLN_OUT_DTL "
        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
        strSQL &= vbCrLf & "     , TMST_TRK "
        strSQL &= vbCrLf & "     , (SELECT * FROM TDSP_DISP WHERE FTABLE_NAME = 'XPLN_OUT_DTL' AND FFIELD_NAME = 'XHINSHITU_STS') HASH01 "

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & "    WHERE 0 = 0 "
        strSQL &= vbCrLf & "       AND XPLN_OUT_DTL.FPLAN_KEY            = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
        strSQL &= vbCrLf & "       AND XSTS_HIKIATE_K1.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "       AND TPRG_TRK_BUF.FTRK_BUF_NO          = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "       AND XPLN_OUT_DTL.XPROGRESS_OUT        = " & XPROGRESS_OUT_JHIKIATE
        strSQL &= vbCrLf & "       AND HASH01.FDISP_VALUE(+)             = XPLN_OUT_DTL.XHINSHITU_STS "

        '----------------------------------------------
        '保管場所
        '----------------------------------------------
        If mudtSEARCH_ITEM.FPLACE_CD <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = '" & mudtSEARCH_ITEM.FPLACE_CD & "' "
        Else
            '(全検索の場合)
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO IN(" & FTRK_BUF_NO_J9000 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8000 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8001 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8002 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8100 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8101 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8102 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8103 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8104 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8105 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8106 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8107 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8108 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8109 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8201 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8202 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8203 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8204 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8205 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8206 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8207 & ", "
            strSQL &= vbCrLf & "                                      " & FTRK_BUF_NO_J8208 & ") "
        End If

        '----------------------------------------------
        '品目ｺｰﾄﾞ
        '----------------------------------------------
        If mudtSEARCH_ITEM.FHINMEI_CD <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT_DTL.FHINMEI_CD LIKE '" & mudtSEARCH_ITEM.FHINMEI_CD & "%' "
        End If


        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & "   GROUP BY "
        strSQL &= vbCrLf & "         TPRG_TRK_BUF.FTRK_BUF_NO "
        strSQL &= vbCrLf & "       , TMST_TRK.FBUF_NAME "
        strSQL &= vbCrLf & "       , XPLN_OUT_DTL.FHINMEI_CD "
        strSQL &= vbCrLf & "       , XPLN_OUT_DTL.FHINMEI "
        strSQL &= vbCrLf & "       , XPLN_OUT_DTL.XHINSHITU_STS "
        strSQL &= vbCrLf & "       , HASH01.FGAMEN_DISP "
        strSQL &= vbCrLf & "       , XSTS_HIKIATE_K1.FPALLET_ID "
        strSQL &= vbCrLf & "       , XSTS_HIKIATE_K1.FLOT_NO_STOCK "
        strSQL &= vbCrLf & " ) "


        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & "  WHERE 0 = 0 "

        
        If chkHINMOK_SUM.Checked = False Then
            '(通常表示の時)
            '----------------------------------------------
            '製造年月日
            '----------------------------------------------
            If mudtSEARCH_ITEM.XSEIZOU_DT <> CBO_ALL_VALUE Then
                '(全検索以外の場合)
                'strSQL &= vbCrLf & "      AND XRST_STOCK_K1.XSEIZOU_DT = TO_DATE('" & mudtSEARCH_ITEM.XSEIZOU_DT & "','YYYY/MM/DD HH24:MI:SS')"
                strSQL &= vbCrLf & "      AND XSEIZOU_DT = TO_DATE('" & mudtSEARCH_ITEM.XSEIZOU_DT & "','YYYY/MM/DD HH24:MI:SS')"
            End If


            '----------------------------------------------
            '品質ｽﾃｰﾀｽ
            '----------------------------------------------
            If mudtSEARCH_ITEM.XHINSHITU_STS <> CBO_ALL_VALUE Then
                '(全検索以外の場合)
                'strSQL &= vbCrLf & "      AND XPLN_OUT_DTL.XHINSHITU_STS = " & mudtSEARCH_ITEM.XHINSHITU_STS
                strSQL &= vbCrLf & "      AND XHINSHITU_STS = " & mudtSEARCH_ITEM.XHINSHITU_STS
            End If
        End If


        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & "  GROUP BY "
        strSQL &= vbCrLf & "         FTRK_BUF_NO "
        strSQL &= vbCrLf & "       , FBUF_NAME "
        strSQL &= vbCrLf & "       , FHINMEI_CD "
        strSQL &= vbCrLf & "       , FHINMEI "
        strSQL &= vbCrLf & "       , XSEIZOU_DT "
        strSQL &= vbCrLf & "       , XHINSHITU_STS "
        strSQL &= vbCrLf & "       , XHINSHITU_STS_DSP "

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2012/12/10 在庫情報を結合
        strSQL &= vbCrLf & "   ) A "

        strSQL &= vbCrLf & "  ,("
        strSQL &= vbCrLf & "    SELECT "
        strSQL &= vbCrLf & "           SUM(TRST_STOCK.FTR_VOL) AS B1 "
        strSQL &= vbCrLf & "         , TRST_STOCK.FHINMEI_CD "
        strSQL &= vbCrLf & "         , TRST_STOCK.XSEIZOU_DT "
        strSQL &= vbCrLf & "         , TRST_STOCK.XHINSHITU_STS "
        strSQL &= vbCrLf & "         , TPRG_TRK_BUF.FTRK_BUF_NO "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "       TRST_STOCK "
        strSQL &= vbCrLf & "       ,TPRG_TRK_BUF "
        strSQL &= vbCrLf & "    WHERE 0 = 0 "
        strSQL &= vbCrLf & "      AND TRST_STOCK.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID "
        strSQL &= vbCrLf & "   GROUP BY "
        strSQL &= vbCrLf & "         TRST_STOCK.FHINMEI_CD "
        strSQL &= vbCrLf & "       , TRST_STOCK.XSEIZOU_DT "
        strSQL &= vbCrLf & "       , TRST_STOCK.XHINSHITU_STS "
        strSQL &= vbCrLf & "       , TPRG_TRK_BUF.FTRK_BUF_NO "
        strSQL &= vbCrLf & " ) B"
        '↑↑↑↑↑↑************************************************************************************************************

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2012/12/10 在庫情報を結合
        strSQL &= vbCrLf & "    WHERE 0 = 0 "
        strSQL &= vbCrLf & "      AND A.FHINMEI_CD = B.FHINMEI_CD "
        strSQL &= vbCrLf & "      AND A.XSEIZOU_DT = B.XSEIZOU_DT "
        strSQL &= vbCrLf & "      AND A.XHINSHITU_STS = B.XHINSHITU_STS "
        strSQL &= vbCrLf & "      AND A.FTRK_BUF_NO = B.FTRK_BUF_NO "
        '↑↑↑↑↑↑************************************************************************************************************




        If chkHINMOK_SUM.Checked = True Then
            '(品目集計の時)
            '============================================================
            'GROUP BY
            '============================================================
            strSQL &= vbCrLf & "  ) "
            strSQL &= vbCrLf & "  GROUP BY "
            strSQL &= vbCrLf & "        FTRK_BUF_NO "                                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(非表示)
            strSQL &= vbCrLf & "      , FBUF_NAME "                                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
            strSQL &= vbCrLf & "      , FHINMEI_CD "                                        '出荷計画詳細   .品名ｺｰﾄﾞ
            strSQL &= vbCrLf & "      , FHINMEI "                                           '出荷計画詳細   .品名
        End If

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, _
                                strSQL, _
                                True)

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理

        mFlag_GRID_CLEAR = False        'ｸﾞﾘｯﾄﾞ表示あり


    End Sub
#End Region
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
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)
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
#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(詳細)　                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty(ByVal objForm As FRM_308121, ByVal enmCheckCase As menmCheckCase)

        '*MH* objForm.userOWNER = Me                           'ｵｰﾅｰﾌｫｰﾑ
        Dim intRow As Integer

        Select Case enmCheckCase
            Case menmCheckCase.DtlBtn_Click
                '(詳細展開)
                intRow = grdList.SelectedRows(0).Index

                objForm.userFPLACE_CD = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, intRow).Value)              '保管場所
                objForm.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, intRow).Value)              '品名ｺｰﾄﾞ

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:A.Noto 2012/12/10 詳細情報で品目集計情報を見るようにする
                'objForm.userXSEIZOU_DT = TO_STRING(grdList.Item(menmListCol.XSEIZOU_DT, intRow).Value)              '製造年月日
                'objForm.userXHINSHITU_STS = TO_STRING(grdList.Item(menmListCol.XHINSHITU_STS, intRow).Value)        '品質ｽﾃｰﾀｽ
                If mudtSEARCH_ITEM.HINMOK_SUM = False Then
                    '(品目集計でないとき)
                    objForm.userXSEIZOU_DT = TO_STRING(grdList.Item(menmListCol.XSEIZOU_DT, intRow).Value)              '製造年月日
                    objForm.userXHINSHITU_STS = TO_STRING(grdList.Item(menmListCol.XHINSHITU_STS, intRow).Value)        '品質ｽﾃｰﾀｽ
                End If
                '↑↑↑↑↑↑************************************************************************************************************

            Case menmCheckCase.AllDtlBtn_Click
                '(全詳細展開)
                objForm.userFPLACE_CD = mudtSEARCH_ITEM.FPLACE_CD                                                   '保管場所
                objForm.userFHINMEI_CD = mudtSEARCH_ITEM.FHINMEI_CD                                                 '品名ｺｰﾄﾞ
                objForm.userXSEIZOU_DT = mudtSEARCH_ITEM.XSEIZOU_DT                                                 '製造年月日
                objForm.userXHINSHITU_STS = mudtSEARCH_ITEM.XHINSHITU_STS                                           '品質ｽﾃｰﾀｽ

        End Select


    End Sub
#End Region

End Class
