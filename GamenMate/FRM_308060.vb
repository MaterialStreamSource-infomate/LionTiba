'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】製品移動出荷指示問合せ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_308060

#Region "　共通変数　                               "

    Protected mudtSEARCH_ITEM As New stcSEARCH_ITEM     '検索条件用構造体

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        XSYUKKA_NO                          '出荷計画.      出荷№
        XPLN_OUT_ID                         '出荷計画.      出荷計画ID(非表示)
        XORDER_NO                           '出荷計画.      発注№
        XSYUKKA_DT                          '出荷計画.      出荷日
        XNYUKA_JIGYOU_CD                    '出荷計画.      入荷事業所ｺｰﾄﾞ
        XNYUKA_JIGYOU_NM                    '出荷計画.      入荷事業所名
        XIDOU_CD                            '出荷計画.      移動手段ｺｰﾄﾞ
        XIDOU_NM                            '出荷計画.      移動手段名
        XGYOSHA_CD                          '出荷計画.      業者ｺｰﾄﾞ
        XGYOSHA_NM                          '出荷計画.      業者名
        XCASE_SUM                           '出荷計画.      箱数合計
        XTEISEI_SLIP_NO                     '出荷計画.      被訂正伝票№
        XARRIVAL_DT                         '出荷計画.      到着日
        XARRIVAL_TIME                       '出荷計画.      到着時間
        XCAR_NO                             '出荷計画.      車番
        XPROGRESS_OUT                       '出荷計画.      進捗状態
        XPROGRESS_OUT_DSP                   '出荷計画.      進捗状態(表示用)

        MAXCOL                              'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        SearchBtn_Click             '検索ﾎﾞﾀﾝｸﾘｯｸ時
        DtlBtn_Click                '詳細ﾎﾞﾀﾝｸﾘｯｸ
        DelBtn_Click                '削除ﾎﾞﾀﾝｸﾘｯｸ
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Protected Structure stcSEARCH_ITEM
        Dim XSYUKKA_NO As String                         '出荷№
        Dim XSYUKKA_DT As String                         '出荷日
        Dim XNYUKA_JIGYOU_CD As String                   '入荷事業所ｺｰﾄﾞ(配送先ｺｰﾄﾞ)
        Dim XIDOU_CD As String                           '移動手段ｺｰﾄﾞ
        Dim XGYOSHA_CD As String                         '業者ｺｰﾄﾞ
    End Structure
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "  出荷№ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ         ｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出荷№ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboXSYUKKA_NO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboXSYUKKA_NO.SelectedIndexChanged
        Try


            If mFlag_Form_Load = False Then


                '===================================
                '出荷日                     ｾｯﾄ
                '===================================
                Call MakeSeihinIdoSyutukaSijiToiawase_cboXSYUKKA_DT(TO_STRING(cboXSYUKKA_NO.SelectedValue.ToString), XPLN_OUT_ID_JSEIHIN, cboXSYUKKA_DT, True)

                '===================================
                '配送先ｺｰﾄﾞ                 ｾｯﾄ
                '===================================
                Call MakeSeihinIdoSyutukaSijiToiawase_cboXNYUKA_JIGYOU_CD(TO_STRING(cboXSYUKKA_NO.SelectedValue.ToString), XPLN_OUT_ID_JSEIHIN, cboXNYUKA_JIGYOU_CD, True)

                lblXNYUKA_JIGYOU_NM.Text = ""           '配送先名

                '===================================
                '移動手段ｺｰﾄﾞ               ｾｯﾄ
                '===================================
                Call MakeSeihinIdoSyutukaSijiToiawase_cboXIDOU_CD(TO_STRING(cboXSYUKKA_NO.SelectedValue.ToString), XPLN_OUT_ID_JSEIHIN, cboXIDOU_CD, True)

                '===================================
                '業者ｺｰﾄﾞ                   ｾｯﾄ
                '===================================
                Call MakeSeihinIdoSyutukaSijiToiawase_cboXGYOSHA_CD(TO_STRING(cboXSYUKKA_NO.SelectedValue.ToString), XPLN_OUT_ID_JSEIHIN, cboXGYOSHA_CD, True)

                '*TODO* '*********************************************
                '' ｸﾞﾘｯﾄﾞ表示
                ''*********************************************
                'grdList.Columns.Clear()
                'Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
                'Call grdListSetup()

            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　配送先ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ     ｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 配送先ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboXNYUKA_JIGYOU_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboXNYUKA_JIGYOU_CD.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                lblXNYUKA_JIGYOU_NM.Text = TO_STRING(cboXNYUKA_JIGYOU_CD.SelectedValue)

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    Public Overrides Sub InitializeChild()


        '*********************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽ初期設定
        '*********************************************
        '===================================
        '出荷№                     ｾｯﾄ
        '===================================
        Call MakeSeihinIdoSyutukaSijiToiawase_cboXSYUKKA_NO(cboXSYUKKA_NO, XPLN_OUT_ID_JSEIHIN, True)

        '===================================
        '出荷日                     ｾｯﾄ
        '===================================
        Call MakeSeihinIdoSyutukaSijiToiawase_cboXSYUKKA_DT(TO_STRING(cboXSYUKKA_NO.SelectedValue.ToString), XPLN_OUT_ID_JSEIHIN, cboXSYUKKA_DT, True)


        '===================================
        '配送先ｺｰﾄﾞ                 ｾｯﾄ
        '===================================
        Call MakeSeihinIdoSyutukaSijiToiawase_cboXNYUKA_JIGYOU_CD(TO_STRING(cboXSYUKKA_NO.SelectedValue.ToString), XPLN_OUT_ID_JSEIHIN, cboXNYUKA_JIGYOU_CD, True)

        lblXNYUKA_JIGYOU_NM.Text = ""           '配送先名

        '===================================
        '移動手段ｺｰﾄﾞ               ｾｯﾄ
        '===================================
        Call MakeSeihinIdoSyutukaSijiToiawase_cboXIDOU_CD(TO_STRING(cboXSYUKKA_NO.SelectedValue.ToString), XPLN_OUT_ID_JSEIHIN, cboXIDOU_CD, True)
      
        '===================================
        '業者ｺｰﾄﾞ                   ｾｯﾄ
        '===================================
        Call MakeSeihinIdoSyutukaSijiToiawase_cboXGYOSHA_CD(TO_STRING(cboXSYUKKA_NO.SelectedValue.ToString), XPLN_OUT_ID_JSEIHIN, cboXGYOSHA_CD, True)


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
        cboXSYUKKA_NO.Dispose()          '出荷№
        cboXSYUKKA_DT.Dispose()          '出荷日
        cboXNYUKA_JIGYOU_CD.Dispose()    '配送先ｺｰﾄﾞ
        cboXIDOU_CD.Dispose()            '移動手段ｺｰﾄﾞ
        cboXGYOSHA_CD.Dispose()          '業者ｺｰﾄﾞ
        grdList.Dispose()                'ｸﾞﾘｯﾄﾞ

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
#Region "  F4(詳細表示)       ﾎﾞﾀﾝ押下処理          "
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
        If IsNull(gobjFRM_308061) = False Then
            gobjFRM_308061.Close()
            gobjFRM_308061.Dispose()
            gobjFRM_308061 = Nothing
        End If

        '********************************************************************
        ' 詳細画面ﾌｫｰﾑ展開
        '********************************************************************
        gobjFRM_308061 = New FRM_308061                             'ｵﾌﾞｼﾞｪｸﾄ作成

        Call SetProperty(gobjFRM_308061, menmCheckCase.DtlBtn_Click)                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        Call gobjFRM_308061.ShowDialog()        '画面表示


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
#Region "  F5(削除)           ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F5  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F5Process()


        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.DelBtn_Click) = False Then
            Exit Sub
        End If

        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()


        If Socket01() = False Then                   '削除
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
        mudtSEARCH_ITEM.XSYUKKA_NO = TO_STRING(cboXSYUKKA_NO.SelectedValue)                        '出荷№
        mudtSEARCH_ITEM.XSYUKKA_DT = TO_STRING(cboXSYUKKA_DT.SelectedValue)                        '出荷日
        mudtSEARCH_ITEM.XNYUKA_JIGYOU_CD = cboXNYUKA_JIGYOU_CD.Text                                '入荷事業所ｺｰﾄﾞ(配送先ｺｰﾄﾞ)
        mudtSEARCH_ITEM.XIDOU_CD = TO_STRING(cboXIDOU_CD.SelectedValue)                            '移動手段ｺｰﾄﾞ
        mudtSEARCH_ITEM.XGYOSHA_CD = TO_STRING(cboXGYOSHA_CD.SelectedValue)                        '業者ｺｰﾄﾞ

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
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "        XPLN_OUT.XSYUKKA_NO "                          '出荷計画.      出荷№
        strSQL &= vbCrLf & "      , XPLN_OUT.XPLN_OUT_ID "                         '出荷計画.      出荷計画ID(非表示)
        strSQL &= vbCrLf & "      , XPLN_OUT.XORDER_NO "                           '出荷計画.      発注№"
        strSQL &= vbCrLf & "      , TO_DATE(XPLN_OUT.XSYUKKA_DT, 'YYYY/MM/DD') "   '出荷計画.      出荷日
        strSQL &= vbCrLf & "      , XPLN_OUT.XNYUKA_JIGYOU_CD "                    '出荷計画.      入荷事業所ｺｰﾄﾞ
        strSQL &= vbCrLf & "      , XPLN_OUT.XNYUKA_JIGYOU_NM "                    '出荷計画.      入荷事業所名
        strSQL &= vbCrLf & "      , XPLN_OUT.XIDOU_CD "                            '出荷計画.      移動手段ｺｰﾄﾞ
        strSQL &= vbCrLf & "      , XPLN_OUT.XIDOU_NM "                            '出荷計画.      移動手段名
        strSQL &= vbCrLf & "      , XPLN_OUT.XGYOSHA_CD "                          '出荷計画.      業者ｺｰﾄﾞ
        strSQL &= vbCrLf & "      , XPLN_OUT.XGYOSHA_NM "                          '出荷計画.      業者名
        strSQL &= vbCrLf & "      , XPLN_OUT.XCASE_SUM "                           '出荷計画.      箱数合計
        strSQL &= vbCrLf & "      , XPLN_OUT.XTEISEI_SLIP_NO "                     '出荷計画.      被訂正伝票№
        strSQL &= vbCrLf & "      , TO_DATE(XPLN_OUT.XARRIVAL_DT, 'YYYY/MM/DD') "  '出荷計画.      到着日
        'strSQL &= vbCrLf & "      , XPLN_OUT.XARRIVAL_TIME "                       '出荷計画.      到着時間
        strSQL &= vbCrLf & "      , (SUBSTR(LPAD(XPLN_OUT.XARRIVAL_TIME, 6, '0'), 1, 2) || ':' "        '出荷計画.      到着時間
        strSQL &= vbCrLf & "      || SUBSTR(LPAD(XPLN_OUT.XARRIVAL_TIME, 6, '0'), 3, 2) || ':' "
        strSQL &= vbCrLf & "      || SUBSTR(LPAD(XPLN_OUT.XARRIVAL_TIME, 6, '0'), 5, 2)) AS XARRIVAL_TIME "
        strSQL &= vbCrLf & "      , XPLN_OUT.XCAR_NO "                             '出荷計画.      車番
        strSQL &= vbCrLf & "      , XPLN_OUT.XPROGRESS_OUT AS XPROGRESS_OUT "      '出荷計画.      進捗状態
        strSQL &= vbCrLf & "      , HASH01.FGAMEN_DISP AS XPROGRESS_OUT_OUT "      '出荷計画.      進捗状態(表示用)

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "        XPLN_OUT "
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XPLN_OUT", "XPROGRESS_OUT")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "    AND XPLN_OUT.XPLN_OUT_ID = " & XPLN_OUT_ID_JSEIHIN                                      '製品移動出荷計画
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XPLN_OUT", "XPROGRESS_OUT")

        '----------------------------------------------
        '出荷№
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSYUKKA_NO <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XSYUKKA_NO = '" & mudtSEARCH_ITEM.XSYUKKA_NO & "' "
        End If

        '----------------------------------------------
        '出荷日
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSYUKKA_DT <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XSYUKKA_DT = '" & mudtSEARCH_ITEM.XSYUKKA_DT & "' "
        End If

        '----------------------------------------------
        '配送先ｺｰﾄﾞ
        '----------------------------------------------
        If mudtSEARCH_ITEM.XNYUKA_JIGYOU_CD <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XNYUKA_JIGYOU_CD = '" & mudtSEARCH_ITEM.XNYUKA_JIGYOU_CD & "' "
        End If

        '----------------------------------------------
        '移動手段ｺｰﾄﾞ
        '----------------------------------------------
        If mudtSEARCH_ITEM.XIDOU_CD <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XIDOU_CD = '" & mudtSEARCH_ITEM.XIDOU_CD & "' "
        End If

        '----------------------------------------------
        '業者ｺｰﾄﾞ
        '----------------------------------------------
        If mudtSEARCH_ITEM.XGYOSHA_CD <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XGYOSHA_CD = '" & mudtSEARCH_ITEM.XGYOSHA_CD & "' "
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

                '============================================
                '保管場所ﾁｪｯｸ
                '============================================
                'If TO_STRING(cboFPLACE_CD.SelectedValue.ToString) = CBO_ALL_VALUE _
                '    Or IsNull(TO_STRING(cboFPLACE_CD.SelectedValue.ToString)) = True Then
                '    '(ｵﾌﾞｼﾞｪｸﾄがない場合)
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM204010_02, PopupFormType.Ok, PopupIconType.Information)
                '    Exit Select
                'End If

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

            Case menmCheckCase.DelBtn_Click
                '(削除ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ選択ﾁｪｯｸ
                '==========================
                If grdList.SelectedRows.Count < 1 Then
                    '(ﾘｽﾄが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If

                '==========================
                '進捗状態ﾁｪｯｸ
                '==========================
                If TO_STRING(grdList.Item(menmListCol.XPROGRESS_OUT, grdList.SelectedRows(0).Index).Value) <> XPROGRESS_OUT_JNONE Then
                    '(進捗状態が0(未)でない時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308060_03, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

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
#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(詳細)　                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty(ByVal objForm As FRM_308061, ByVal enmCheckCase As menmCheckCase)

        objForm.userSYUKKA_NO = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NO, grdList.SelectedRows(0).Index).Value)                '出荷№
        '出荷日
        objForm.userSYUKKA_DT = Mid(TO_STRING(grdList.Item(menmListCol.XSYUKKA_DT, grdList.SelectedRows(0).Index).Value), 1, 4) & _
                                Mid(TO_STRING(grdList.Item(menmListCol.XSYUKKA_DT, grdList.SelectedRows(0).Index).Value), 6, 2) & _
                                Mid(TO_STRING(grdList.Item(menmListCol.XSYUKKA_DT, grdList.SelectedRows(0).Index).Value), 9, 2)

    End Sub
#End Region
#Region "  ｿｹｯﾄ送信(削除)                         　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function Socket01() As Boolean

        Dim blnRet As Boolean = False

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308060_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        ''********************************************************************
        '' 製品移動出荷計画更新ﾃﾞｰﾀｾｯﾄ
        ''********************************************************************
        Dim strDSPDIR_KUBUN As String = ""                      '処理区分
        Dim strXDSPSYUKKA_NO As String = ""                     '出荷№


        strDSPDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_DELETE       '処理区分(削除)
        strXDSPSYUKKA_NO = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NO, grdList.SelectedRows(0).Index).Value)         '出荷№


        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegram = New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400201
        
        objTelegram.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegram.FORMAT_ID, 6))          'ｺﾏﾝﾄﾞID
        objTelegram.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                                 '端末ID
        objTelegram.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                                 '担当者ｺｰﾄﾞ

        objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDSPDIR_KUBUN)                 '処理区分
        objTelegram.SETIN_DATA("XDSPSYUKKA_NO", strXDSPSYUKKA_NO)               '移動出荷№


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                        'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = FRM_MSG_FRM308060_02
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            Else
                '(処理が異常終了した場合)
                strErrMsg = FRM_MSG_FRM308060_02
                Call gobjComFuncFRM.DisplayPopup(strErrMsg, PopupFormType.Ok, PopupIconType.Err)
            End If
        End If

        Return blnRet

    End Function
#End Region

End Class
