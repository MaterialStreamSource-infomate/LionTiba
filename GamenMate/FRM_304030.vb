'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾛｯﾄ追跡問合せ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_304030

#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM


    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol

        FHINMEI_CD              '出荷実績.          品名ｺｰﾄﾞ
        XSEIZOU_DT              '出荷実績.          製造年月日
        XLINE_NO                '出荷実績.          ﾗｲﾝ№
        XPALLET_NO              '出荷実績.          ﾊﾟﾚｯﾄ№
        XASRS_IN_DT             '出荷実績.          入庫日時
        XSYUKKA_KENPIN_VOL      '出荷実績.          出荷検品数(数量)
        FTRK_BUF_NO             '出荷実績.          ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(出庫場所)
        FBUF_NAME               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名(出庫場所)
        XCAR_NO_WARITUKE        '出荷計画.          割付け車番
        XCAR_NO_EDA_WARITUKE    '出荷計画.          割付け車番枝番
        XSYUKKA_NO              '出荷実績.          出荷№
        XSYUKKA_DT              '出荷計画.          出荷日
        XARRIVAL_DT             '出荷計画.          到着日
        XNYUKA_JIGYOU_CD        '出荷計画.          入荷事業所ｺｰﾄﾞ(配送先ｺｰﾄﾞ)
        XNYUKA_JIGYOU_NM        '出荷計画.          入荷事業所名(配送先名)
        XIDOU_CD                '出荷計画.          移動手段ｺｰﾄﾞ(輸送手段)

        MAXCOL

    End Enum

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        SearchBtn_Click         '検索ﾎﾞﾀﾝｸﾘｯｸ時
        CsvOutBtn_Click         'CSV出力ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義　                             "
    ''' <summary>検索条件</summary>
    Private Structure SEARCH_ITEM
        Dim FHINMEI_CD As String            '品名ｺｰﾄﾞ
        Dim XSEIZOU_DT As String            '製造年月日
        Dim XLINE_NO As String              'ﾗｲﾝ№
        Dim XPALLET_NO_FM As String         'ﾊﾟﾚｯﾄ№ FROM
        Dim XPALLET_NO_TO As String         'ﾊﾟﾚｯﾄ№ TO
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

                '**********************************************************
                ' 製造年月日ｺﾝﾎﾞ                  ｾｯﾄ
                '**********************************************************
                Call MakeLotTuisekiToiawase_cboXSEIZOU_DT(cboFHINMEI_CD.Text, cboXSEIZOU_DT, True)

                '**********************************************************
                ' ﾗｲﾝ№ｺﾝﾎﾞ                  ｾｯﾄ
                '**********************************************************
                Call MakeLotTuisekiToiawase_cboXLINE_NO(cboFHINMEI_CD.Text, cboXLINE_NO, True)

                '*********************************************
                ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
                '*********************************************
                txtXPALLET_NO_FM.Text = ""    'ﾊﾟﾚｯﾄ№ FROM
                txtXPALLET_NO_TO.Text = ""    'ﾊﾟﾚｯﾄ№ TO

                '*********************************************
                ' ｸﾞﾘｯﾄﾞ表示
                '*********************************************
                grdList.Columns.Clear()
                Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
                Call grdListSetup()

            End If

        Catch ex As Exception
            ComError(ex)
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
        ' 品名ｺｰﾄﾞｺﾝﾎﾞ         ｾｯﾄ
        '****************************************
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = ""
        cboFHINMEI_CD.HinmeiVisible = False
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)

        '**********************************************************
        ' 製造年月日ｺﾝﾎﾞ                  ｾｯﾄ
        '**********************************************************
        Call MakeLotTuisekiToiawase_cboXSEIZOU_DT(cboFHINMEI_CD.Text, cboXSEIZOU_DT, True)

        '**********************************************************
        ' ﾗｲﾝ№ｺﾝﾎﾞ                  ｾｯﾄ
        '**********************************************************
        Call MakeLotTuisekiToiawase_cboXLINE_NO(cboFHINMEI_CD.Text, cboXLINE_NO, True)


        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        lblFHINMEI.Text = ""          '品名
        txtXPALLET_NO_FM.Text = ""    'ﾊﾟﾚｯﾄ№ FROM
        txtXPALLET_NO_TO.Text = ""    'ﾊﾟﾚｯﾄ№ TO


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
        cboFHINMEI_CD.Dispose()          '品名ｺｰﾄﾞ
        cboXSEIZOU_DT.Dispose()          '製造年月日
        cboXLINE_NO.Dispose()            'ﾗｲﾝ№
        txtXPALLET_NO_FM.Dispose()       'ﾊﾟﾚｯﾄ№ FROM
        txtXPALLET_NO_TO.Dispose()       'ﾊﾟﾚｯﾄ№ TO
        grdList.Dispose()                'ｸﾞﾘｯﾄﾞ

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
#Region "  F4(CSV出力)      ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

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


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.CsvOutBtn_Click) = False Then
            Exit Sub
        End If

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udeRet As PopupFormType
        udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_PRINT_03, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> PopupFormType.Ok Then
            Exit Sub
        End If

        '*********************************************
        ' CSV出力
        '*********************************************
        Call CSV_Out()

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
        ' 品名ｺｰﾄﾞ
        '===============================================
        mudtSEARCH_ITEM.FHINMEI_CD = cboFHINMEI_CD.Text

        '===============================================
        ' 製造年月日
        '===============================================
        mudtSEARCH_ITEM.XSEIZOU_DT = TO_STRING(cboXSEIZOU_DT.SelectedValue.ToString)

        '===============================================
        ' ﾗｲﾝ№
        '===============================================
        mudtSEARCH_ITEM.XLINE_NO = TO_STRING(cboXLINE_NO.SelectedValue.ToString)

        '===============================================
        ' ﾊﾟﾚｯﾄ№
        '===============================================
        mudtSEARCH_ITEM.XPALLET_NO_FM = txtXPALLET_NO_FM.Text
        mudtSEARCH_ITEM.XPALLET_NO_TO = txtXPALLET_NO_TO.Text

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
        strSQL &= vbCrLf & "     XRST_OUT.FHINMEI_CD "                              '出荷実績.          品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XRST_OUT.XSEIZOU_DT "                              '出荷実績.          製造年月日
        strSQL &= vbCrLf & "   , XRST_OUT.XLINE_NO "                                '出荷実績.          ﾗｲﾝ№
        strSQL &= vbCrLf & "   , XRST_OUT.XPALLET_NO "                              '出荷実績.          ﾊﾟﾚｯﾄ№
        strSQL &= vbCrLf & "   , XRST_OUT.XASRS_IN_DT "                             '出荷実績.          入庫日時
        strSQL &= vbCrLf & "   , XRST_OUT.XSYUKKA_KENPIN_VOL "                      '出荷実績.          出荷検品数(数量)
        strSQL &= vbCrLf & "   , XRST_OUT.FTRK_BUF_NO "                             '出荷実績.          ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(出庫場所)
        strSQL &= vbCrLf & "   , TMST_TRK.FBUF_NAME "                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名(出庫場所)
        strSQL &= vbCrLf & "   , XPLN_OUT.XCAR_NO_WARITUKE "                        '出荷計画.          割付け車番
        strSQL &= vbCrLf & "   , XPLN_OUT.XCAR_NO_EDA_WARITUKE "                    '出荷計画.          割付け車番枝番
        strSQL &= vbCrLf & "   , XRST_OUT.XSYUKKA_NO "                              '出荷実績.          出荷№
        strSQL &= vbCrLf & "   , TO_DATE(XPLN_OUT.XSYUKKA_DT, 'YYYY/MM/DD') "       '出荷計画.          出荷日
        strSQL &= vbCrLf & "   , TO_DATE(XPLN_OUT.XARRIVAL_DT, 'YYYY/MM/DD') "      '出荷計画.          到着日
        strSQL &= vbCrLf & "   , XPLN_OUT.XNYUKA_JIGYOU_CD "                        '出荷計画.          入荷事業所ｺｰﾄﾞ(配送先ｺｰﾄﾞ)
        strSQL &= vbCrLf & "   , XPLN_OUT.XNYUKA_JIGYOU_NM "                        '出荷計画.          入荷事業所名(配送先名)
        strSQL &= vbCrLf & "   , XPLN_OUT.XIDOU_CD "                                '出荷計画.          移動手段ｺｰﾄﾞ(輸送手段)

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     XRST_OUT "                                 '出荷実績
        strSQL &= vbCrLf & "   , XPLN_OUT "                                 '出荷計画
        strSQL &= vbCrLf & "   , TMST_TRK "                                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & "     WHERE 0 = 0 "
        strSQL &= vbCrLf & "   AND XRST_OUT.XSYUKKA_NO  = XPLN_OUT.XSYUKKA_NO(+) "
        strSQL &= vbCrLf & "   AND XRST_OUT.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "   AND XRST_OUT.XLINE_NO <> '###' "             '* 2012.11.29 10:40 H.Morita ###を除く *

        '-----------------------------
        '品名ｺｰﾄﾞ
        '-----------------------------
        If mudtSEARCH_ITEM.FHINMEI_CD <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XRST_OUT.FHINMEI_CD LIKE '" & mudtSEARCH_ITEM.FHINMEI_CD & "%' "
        End If

        '----------------------------
        ' 製造年月日 
        '----------------------------
        If mudtSEARCH_ITEM.XSEIZOU_DT <> "" Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XRST_OUT.XSEIZOU_DT = TO_DATE('" & mudtSEARCH_ITEM.XSEIZOU_DT & "','YYYY/MM/DD')"
        End If

        '-----------------------------
        'ﾗｲﾝ№
        '-----------------------------
        If mudtSEARCH_ITEM.XLINE_NO <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            '↓↓↓↓ 2012.12.07 13:00 H.Morita 文字型、数値型を考慮する
            'strSQL &= vbCrLf & "        AND XRST_OUT.XLINE_NO = " & mudtSEARCH_ITEM.XLINE_NO
            strSQL &= vbCrLf & "        AND XRST_OUT.XLINE_NO = '" & mudtSEARCH_ITEM.XLINE_NO & "' "
            '↑↑↑↑ 2012.12.07 13:00 H.Morita 文字型、数値型を考慮する
        End If

        '-----------------------------
        'ﾊﾟﾚｯﾄ№ FROM
        '-----------------------------
        If mudtSEARCH_ITEM.XPALLET_NO_FM <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XRST_OUT.XPALLET_NO >= '" & mudtSEARCH_ITEM.XPALLET_NO_FM & "' "
        End If

        '-----------------------------
        'ﾊﾟﾚｯﾄ№ TO
        '-----------------------------
        If mudtSEARCH_ITEM.XPALLET_NO_TO <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XRST_OUT.XPALLET_NO <= '" & mudtSEARCH_ITEM.XPALLET_NO_TO & "' "
        End If


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

                '==========================
                '品名ｺｰﾄﾞ  選択ﾁｪｯｸ
                '==========================
                If cboFHINMEI_CD.Text = "" Then
                    '(品名ｺｰﾄﾞが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM304030_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                '==========================
                '製造年月日  選択ﾁｪｯｸ
                '==========================
                If TO_STRING(cboXSEIZOU_DT.SelectedValue.ToString) = CBO_ALL_VALUE _
                    Or IsNull(TO_STRING(cboXSEIZOU_DT.SelectedValue.ToString)) = True Then
                    '(品名ｺｰﾄﾞが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM304030_02, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                '==========================
                'ﾊﾟﾚｯﾄ№  FROM,TO 大小ﾁｪｯｸ
                '==========================
                If (txtXPALLET_NO_FM.Text <> "") And _
                   (txtXPALLET_NO_TO.Text <> "") Then
                    If (txtXPALLET_NO_FM.Text > txtXPALLET_NO_TO.Text) Then
                        '(ﾊﾟﾚｯﾄ№の大小が間違っている場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM304030_03, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If
                End If

                blnCheckErr = False

            Case menmCheckCase.CsvOutBtn_Click
                '(CSV出力ﾎﾞﾀﾝｸﾘｯｸ時)

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
#Region "　CSV出力                                  "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub CSV_Out()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        Try

            '******************************************
            'ﾌｧｲﾙ名     取得
            '******************************************
            Dim strFile As String = TO_STRING(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGJ304030_001))

            '******************************************
            'ﾃﾞｰﾀ部     ﾍｯﾀﾞ表示名ｾｯﾄ
            '******************************************
            Dim strDataHeaderName_Ary(11) As String
            strDataHeaderName_Ary(0) = "ﾗｲﾝ№"
            strDataHeaderName_Ary(1) = "ﾊﾟﾚｯﾄ№"
            strDataHeaderName_Ary(2) = "入庫日時"
            strDataHeaderName_Ary(3) = "数量"
            strDataHeaderName_Ary(4) = "出庫場所"
            strDataHeaderName_Ary(5) = "受付車番"
            strDataHeaderName_Ary(6) = "枝番"
            strDataHeaderName_Ary(7) = "出荷№"
            strDataHeaderName_Ary(8) = "出荷日"
            strDataHeaderName_Ary(9) = "到着日"
            strDataHeaderName_Ary(10) = "配送先名"
            strDataHeaderName_Ary(11) = "輸送手段"


            '******************************************
            'ﾃﾞｰﾀ部     ｶﾗﾑ名ｾｯﾄ
            '******************************************
            Dim intDataColumnIdx_Ary(11) As Integer
            intDataColumnIdx_Ary(0) = menmListCol.XLINE_NO
            intDataColumnIdx_Ary(1) = menmListCol.XPALLET_NO
            intDataColumnIdx_Ary(2) = menmListCol.XASRS_IN_DT
            intDataColumnIdx_Ary(3) = menmListCol.XSYUKKA_KENPIN_VOL
            intDataColumnIdx_Ary(4) = menmListCol.FBUF_NAME
            intDataColumnIdx_Ary(5) = menmListCol.XCAR_NO_WARITUKE
            intDataColumnIdx_Ary(6) = menmListCol.XCAR_NO_EDA_WARITUKE
            intDataColumnIdx_Ary(7) = menmListCol.XSYUKKA_NO
            intDataColumnIdx_Ary(8) = menmListCol.XSYUKKA_DT
            intDataColumnIdx_Ary(9) = menmListCol.XARRIVAL_DT
            intDataColumnIdx_Ary(10) = menmListCol.XNYUKA_JIGYOU_NM
            intDataColumnIdx_Ary(11) = menmListCol.XIDOU_CD


            '******************************************
            'CSVﾌｧｲﾙ出力
            '******************************************
            Call MakeCSV(grdList _
                        , TO_STRING(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGJ000000_001)) _
                        , strFile _
                        , "" _
                        , strDataHeaderName_Ary _
                        , intDataColumnIdx_Ary _
                        )


        Catch ex As Exception
            Throw ex

        Finally
            Call gobjComFuncFRM.WaitFormClose()                    ' Waitﾌｫｰﾑ削除

        End Try

    End Sub
#End Region

End Class