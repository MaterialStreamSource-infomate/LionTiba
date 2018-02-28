'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾋﾟｯｷﾝｸﾞﾘｽﾄ再発行画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_308110

#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM
    Private mudtSEARCH_ITEM2 As New SEARCH_ITEM2    'ﾘｽﾄ用


    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol

        XHIKIATE_DT             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時
        XHIKIATE_DT_DSP         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(表示用)
        XSYUKKA_DT              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日
        XSYUKKA_DT_DSP          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(表示用)
        XNYUKA_JIGYOU_CD        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ
        XNYUKA_JIGYOU_NM        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所名
        XORDER_NO               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№

        XCAR_NO                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        車番
        XCAR_NO_WARITUKE        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        受付車番
        XCAR_NO_EDA_WARITUKE    'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        受付車番枝番
        XIDOU_CD                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        移動手段ｺｰﾄﾞ
        XARRIVAL_DT             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        到着日
        XGYOSHA_CD              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        業者ｺｰﾄﾞ

        MAXCOL

    End Enum


    ''' <summary>ｸﾞﾘｯﾄﾞ項目(ﾋﾟｯｷﾝｸﾞﾘｽﾄ全体用)</summary>
    Enum menmListCol2

        XHIKIATE_DT             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(非表示)
        XSYUKKA_DT              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(非表示)
        XCAR_NO_WARITUKE        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番
        XCAR_NO_EDA_WARITUKE    'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番枝番
        XNYUKA_JIGYOU_CD        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ(非表示)
        XNYUKA_JIGYOU_NM        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所名
        '↓↓↓↓ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        XORDER_NO               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№
        '↑↑↑↑ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        FHINMEI                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名
        FHINMEI_CD              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名ｺｰﾄﾞ
        XSEIZOU_DT              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        製造年月日

        XHIKIATE_VOL            'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        引当数
        XPRINT_PL_NUM           'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        PL
        XPRINT_BARA_DAN_NUM     'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        段
        XPRINT_BARA_NUM         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        C/S
        XHINSHITU_STS           'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(非表示)
        XHINSHITU_STS_DSP       'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(表示用)
        FTRK_BUF_NO             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示)
        FBUF_NAME               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称(保管場所)

        MAXCOL

    End Enum


    ''' <summary>ｸﾞﾘｯﾄﾞ項目(ﾋﾟｯｷﾝｸﾞﾘｽﾄ用)</summary>
    Enum menmListCol3

        XHIKIATE_DT             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(非表示)
        XHIKIATE_DT_DSP         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(表示用)(非表示)
        XSYUKKA_DT              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(非表示)
        XSYUKKA_DT_DSP          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(表示用)
        XCAR_NO_WARITUKE        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番
        XCAR_NO_EDA_WARITUKE    'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番枝番
        XNYUKA_JIGYOU_CD        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ(非表示)
        XNYUKA_JIGYOU_NM        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所名
        XORDER_NO               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№
        XIDOU_CD                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        移動手段ｺｰﾄﾞ(非表示)
        XIDOU_NM                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        移動手段名
        FTRK_BUF_NO             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示)
        FBUF_NAME               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称(保管場所)

        FHINMEI_CD              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名ｺｰﾄﾞ
        FHINMEI                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名
        XSEIZOU_DT              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        製造年月日
        XHIKIATE_VOL            'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        引当数
        XPRINT_PL_NUM           'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        PL
        XPRINT_BARA_DAN_NUM     'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        段
        XPRINT_BARA_NUM         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        C/S
        XWEIGHT                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        重量
        XSYUKKA_KAHI            'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷可否(非表示)
        XSYUKKA_KAHI_DSP        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷可否(表示用)
        XHINSHITU_STS           'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(非表示)
        XHINSHITU_STS_DSP       'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(表示用)
        FDECIMAL_POINT          '品目ﾏｽﾀ.           小数点以下有効桁数

        MAXCOL

    End Enum


    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        SearchBtn_Click         '検索ﾎﾞﾀﾝｸﾘｯｸ時
        PrintBtn_Click          'ﾘｽﾄ出力ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義　                             "
    ''' <summary>検索条件</summary>
    Private Structure SEARCH_ITEM
        Dim XSYUKKA_DT As String            '出荷日
        Dim XORDER_NO As String             '発注№
        Dim XCAR_NO_WARITUKE As String      '受付車番
        Dim XCAR_NO_EDA_WARITUKE As String  '受付車番枝番
        Dim XNYUKA_JIGYOU_CD As String      '配送先ｺｰﾄﾞ
        Dim XIDOU_CD As String              '移動手段ｺｰﾄﾞ
        Dim XGYOSHA_CD As String            '業者ｺｰﾄﾞ
    End Structure

    ''' <summary>検索条件(ﾘｽﾄ用)</summary>
    Private Structure SEARCH_ITEM2
        Dim XHIKIATE_DT As String           '出荷引当日時
        Dim XSYUKKA_DT As String            '出荷日
        Dim XORDER_NO As String             '発注№
        Dim XCAR_NO_WARITUKE As String      '受付車番
        Dim XCAR_NO_EDA_WARITUKE As String  '受付車番枝番
        Dim XNYUKA_JIGYOU_CD As String      '配送先ｺｰﾄﾞ
        Dim XNYUKA_JIGYOU_NM As String      '配送先名
        Dim XIDOU_CD As String              '移動手段ｺｰﾄﾞ
        Dim XGYOSHA_CD As String            '業者ｺｰﾄﾞ
    End Structure
#End Region
#Region "　ｲﾍﾞﾝﾄ　                                  "
#Region "　配送先ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 配送先ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboXNYUKA_JIGYOU_CD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboXNYUKA_JIGYOU_CD.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                lblXNYUKA_JIGYOU_NM.Text = TO_STRING(cboXNYUKA_JIGYOU_CD.SelectedValue.ToString)      '配送先名

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
        ' ﾋﾟｯｷﾝｸﾞﾘｽﾄ再発行  各ｺﾝﾎﾞ(ｾｯﾄ)
        '****************************************
        dtpXSYUKKA_DT.cmpMDateTimePicker_D.Value = Now
        Call MakePickingList_cboXORDER_NO(cboXORDER_NO, True)
        Call MakePickingList_cboXNYUKA_JIGYOU_CD(cboXNYUKA_JIGYOU_CD, True)
        Call MakePickingList_cboXIDOU_CD(cboXIDOU_CD, True)
        Call MakePickingList_cboXGYOSHA_CD(cboXGYOSHA_CD, True)


        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        lblXNYUKA_JIGYOU_NM.Text = ""          '配送先名
        txtXCAR_NO_WARITUKE.Text = ""                   '受付車番
        txtXCAR_NO_EDA_WARITUKE.Text = ""               '受付車番枝番


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        Call gobjComFuncFRM.FlexGridInitialize(grdList2, 1, menmListCol2.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup2()

        Call gobjComFuncFRM.FlexGridInitialize(grdList3, 1, menmListCol3.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup3()


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
        dtpXSYUKKA_DT.Dispose()          '出荷日
        cboXORDER_NO.Dispose()           '発注№
        cboXNYUKA_JIGYOU_CD.Dispose()    '配送先ｺｰﾄﾞ
        cboXIDOU_CD.Dispose()            '移動手段ｺｰﾄﾞ
        cboXGYOSHA_CD.Dispose()          '業者ｺｰﾄﾞ
        txtXCAR_NO_WARITUKE.Dispose()             '受付車番
        txtXCAR_NO_EDA_WARITUKE.Dispose()         '受付車番枝番
        grdList.Dispose()                'ｸﾞﾘｯﾄﾞ
        grdList2.Dispose()               'ｸﾞﾘｯﾄﾞ
        grdList3.Dispose()               'ｸﾞﾘｯﾄﾞ

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
#Region "  F4(ﾘｽﾄ出力)      ﾎﾞﾀﾝ押下処理　          "
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
        If InputCheck(menmCheckCase.PrintBtn_Click) = False Then
            Exit Sub
        End If

        '*********************************************
        ' ﾘｽﾄ出力
        '*********************************************
        Call printOut()

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
        mudtSEARCH_ITEM.XSYUKKA_DT = Format(dtpXSYUKKA_DT.cmpMDateTimePicker_D.Value, "yyyyMMdd")     '出荷日
        mudtSEARCH_ITEM.XORDER_NO = TO_STRING(cboXORDER_NO.SelectedValue.ToString)       '発注№
        mudtSEARCH_ITEM.XCAR_NO_WARITUKE = txtXCAR_NO_WARITUKE.Text                      '受付車番
        mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE = txtXCAR_NO_EDA_WARITUKE.Text              '受付車番枝番
        mudtSEARCH_ITEM.XNYUKA_JIGYOU_CD = cboXNYUKA_JIGYOU_CD.Text                      '配送先ｺｰﾄﾞ
        mudtSEARCH_ITEM.XIDOU_CD = TO_STRING(cboXIDOU_CD.SelectedValue.ToString)         '移動手段ｺｰﾄﾞ
        mudtSEARCH_ITEM.XGYOSHA_CD = TO_STRING(cboXGYOSHA_CD.SelectedValue.ToString)     '業者ｺｰﾄﾞ


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
        strSQL &= vbCrLf & " SELECT DISTINCT"
        strSQL &= vbCrLf & "     XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT "                       'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時
        strSQL &= vbCrLf & "   , TO_CHAR(XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT, 'YYYY/MM/DD') AS XHIKIATE_DT_DSP "     'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(表示用)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSYUKKA_DT "                        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日
        strSQL &= vbCrLf & "   , TO_CHAR(TO_DATE(XPLN_SYUKKA_PICK_PRINT.XSYUKKA_DT, 'YYYY/MM/DD'), 'YYYY/MM/DD') AS XSYUKKA_DT_DSP "       'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(表示用)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD "                  'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_NM "                  'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所名
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XORDER_NO "                         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№

        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO "                           'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        車番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE "                  'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE "              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番枝番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XIDOU_CD "                          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        移動手段ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , TO_DATE(XPLN_SYUKKA_PICK_PRINT.XARRIVAL_DT, 'YYYY/MM/DD') "    'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        到着日
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XGYOSHA_CD "                        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        業者ｺｰﾄﾞ


        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_PICK_PRINT "                         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ情報

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & "     WHERE 0 = 0 "

        '-----------------------------
        '出荷日
        '-----------------------------
        If mudtSEARCH_ITEM.XSYUKKA_DT <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            'strSQL &= vbCrLf & "        AND TO_CHAR(XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT, 'yyyyMMdd') = '" & mudtSEARCH_ITEM.XSYUKKA_DT & "' "
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XSYUKKA_DT = '" & mudtSEARCH_ITEM.XSYUKKA_DT & "' "
        End If

        '----------------------------
        '発注№ 
        '----------------------------
        If mudtSEARCH_ITEM.XORDER_NO <> "" Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XORDER_NO = '" & mudtSEARCH_ITEM.XORDER_NO & "' "
        End If

        '-----------------------------
        '受付車番
        '-----------------------------
        If mudtSEARCH_ITEM.XCAR_NO_WARITUKE <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_WARITUKE & "' "
        End If

        '-----------------------------
        '受付車番枝番
        '-----------------------------
        If mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE & "' "
        End If

        '-----------------------------
        '配送先ｺｰﾄﾞ
        '-----------------------------
        If mudtSEARCH_ITEM.XNYUKA_JIGYOU_CD <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD = '" & mudtSEARCH_ITEM.XNYUKA_JIGYOU_CD & "' "
        End If

        '-----------------------------
        '移動手段ｺｰﾄﾞ
        '-----------------------------
        If mudtSEARCH_ITEM.XIDOU_CD <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XIDOU_CD = '" & mudtSEARCH_ITEM.XIDOU_CD & "' "
        End If

        '-----------------------------
        '業者ｺｰﾄﾞ
        '-----------------------------
        If mudtSEARCH_ITEM.XGYOSHA_CD <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XGYOSHA_CD = '" & mudtSEARCH_ITEM.XGYOSHA_CD & "' "
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

        'grdList.MultiSelect = True
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

                blnCheckErr = False

            Case menmCheckCase.PrintBtn_Click
                '(ﾘｽﾄ出力ﾎﾞﾀﾝｸﾘｯｸ時)

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

#Region "  構造体ｾｯﾄ(ﾘｽﾄ用)                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set2()

        '********************************************************************
        '構造体に値をｾｯﾄ
        '********************************************************************
        mudtSEARCH_ITEM2.XHIKIATE_DT = TO_STRING(grdList.Item(menmListCol.XHIKIATE_DT, grdList.SelectedRows(0).Index).Value)             '出荷引当日時
        mudtSEARCH_ITEM2.XSYUKKA_DT = TO_STRING(grdList.Item(menmListCol.XSYUKKA_DT, grdList.SelectedRows(0).Index).Value)               '出荷日
        mudtSEARCH_ITEM2.XORDER_NO = TO_STRING(grdList.Item(menmListCol.XORDER_NO, grdList.SelectedRows(0).Index).Value)                 '発注№
        mudtSEARCH_ITEM2.XCAR_NO_WARITUKE = TO_STRING(grdList.Item(menmListCol.XCAR_NO_WARITUKE, grdList.SelectedRows(0).Index).Value)            '受付車番
        mudtSEARCH_ITEM2.XCAR_NO_EDA_WARITUKE = TO_STRING(grdList.Item(menmListCol.XCAR_NO_EDA_WARITUKE, grdList.SelectedRows(0).Index).Value)    '受付車番枝番
        mudtSEARCH_ITEM2.XNYUKA_JIGYOU_CD = TO_STRING(grdList.Item(menmListCol.XNYUKA_JIGYOU_CD, grdList.SelectedRows(0).Index).Value)   '配送先ｺｰﾄﾞ
        mudtSEARCH_ITEM2.XNYUKA_JIGYOU_NM = TO_STRING(grdList.Item(menmListCol.XNYUKA_JIGYOU_NM, grdList.SelectedRows(0).Index).Value)   '配送先名
        mudtSEARCH_ITEM2.XIDOU_CD = TO_STRING(grdList.Item(menmListCol.XIDOU_CD, grdList.SelectedRows(0).Index).Value)                   '移動手段ｺｰﾄﾞ
        mudtSEARCH_ITEM2.XGYOSHA_CD = TO_STRING(grdList.Item(menmListCol.XGYOSHA_CD, grdList.SelectedRows(0).Index).Value)               '業者ｺｰﾄﾞ

    End Sub
#End Region

#Region "  印刷処理                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 印刷処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub printOut()

        '*********************************************
        ' 構造体ｾｯﾄ(ﾘｽﾄ用)
        '*********************************************
        Call SearchItem_Set2()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub2(grdList2)
        Call grdListDisplaySub3(grdList3)


        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        If (grdList2.RowCount > 0) Or _
           (grdList3.RowCount > 0) Then
            '(印刷ﾃﾞｰﾀありの時)
            Dim udeRet As PopupFormType
            udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_PRINT_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
            If udeRet <> PopupFormType.Ok Then
                Exit Sub
            End If
        End If


        '*********************************************
        ' ﾘｽﾄ出力
        '*********************************************
        If grdList2.RowCount > 0 Then
            '(印刷ﾃﾞｰﾀありの時)
            Call printOut01()       'ﾋﾟｯｷﾝｸﾞﾘｽﾄ全体
        End If

        If grdList3.RowCount > 0 Then
            '(印刷ﾃﾞｰﾀありの時)
            Call printOut02()       'ﾋﾟｯｷﾝｸﾞﾘｽﾄ
        End If

    End Sub
#End Region

#Region "　ﾘｽﾄ表示(ﾋﾟｯｷﾝｸﾞﾘｽﾄ全体)                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild2()

        Dim strSQL As String                        'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT "               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSYUKKA_DT "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE "      'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番枝番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_NM "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所名
        '↓↓↓↓ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XORDER_NO "                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№
        '↑↑↑↑ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI "                   'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI_CD "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSEIZOU_DT "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        製造年月日

        strSQL &= vbCrLf & "   , SUM(XPLN_SYUKKA_PICK_PRINT.XHIKIATE_VOL) "         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        引当数
        strSQL &= vbCrLf & "   , SUM(XPLN_SYUKKA_PICK_PRINT.XPRINT_PL_NUM) "        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        PL
        strSQL &= vbCrLf & "   , SUM(XPLN_SYUKKA_PICK_PRINT.XPRINT_BARA_DAN_NUM) "  'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        段
        strSQL &= vbCrLf & "   , SUM(XPLN_SYUKKA_PICK_PRINT.XPRINT_BARA_NUM) "      'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        C/S
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XHINSHITU_STS "             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(非表示)
        strSQL &= vbCrLf & "   , HASH01.FGAMEN_DISP AS XHINSHITU_STS_DSP "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FTRK_BUF_NO "               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示)
        strSQL &= vbCrLf & "   , TMST_TRK.FBUF_NAME "                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称(保管場所)

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_PICK_PRINT "                         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ情報
        strSQL &= vbCrLf & "   , TMST_TRK "                                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XPLN_SYUKKA_PICK_PRINT", "XHINSHITU_STS")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "   AND XPLN_SYUKKA_PICK_PRINT.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XPLN_SYUKKA_PICK_PRINT", "XHINSHITU_STS")
        'strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.FTRK_BUF_NO IN ("
        'strSQL &= vbCrLf & FTRK_BUF_NO_J8000 & ", "
        'strSQL &= vbCrLf & FTRK_BUF_NO_J8001 & ", "
        'strSQL &= vbCrLf & FTRK_BUF_NO_J8100 & ", " & FTRK_BUF_NO_J8101 & ", " _
        '                 & FTRK_BUF_NO_J8102 & ", " & FTRK_BUF_NO_J8103 & ", " _
        '                 & FTRK_BUF_NO_J8104 & ", " & FTRK_BUF_NO_J8105 & ", " _
        '                 & FTRK_BUF_NO_J8106 & ", " & FTRK_BUF_NO_J8107 & ", " _
        '                 & FTRK_BUF_NO_J8108 & ", " & FTRK_BUF_NO_J8109
        'strSQL &= vbCrLf & ") "

        '-----------------------------
        '出荷引当日時
        '-----------------------------
        If mudtSEARCH_ITEM2.XHIKIATE_DT <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT = TO_DATE('" & mudtSEARCH_ITEM2.XHIKIATE_DT & "', 'YYYY/MM/DD HH24:MI:SS') "
        End If

        '-----------------------------
        '受付車番
        '-----------------------------
        If mudtSEARCH_ITEM2.XCAR_NO_WARITUKE <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE = '" & mudtSEARCH_ITEM2.XCAR_NO_WARITUKE & "' "
        End If

        '-----------------------------
        '受付車番枝番
        '-----------------------------
        If mudtSEARCH_ITEM2.XCAR_NO_EDA_WARITUKE <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE = '" & mudtSEARCH_ITEM2.XCAR_NO_EDA_WARITUKE & "' "
        End If

        '-----------------------------
        '配送先ｺｰﾄﾞ
        '-----------------------------
        If mudtSEARCH_ITEM2.XNYUKA_JIGYOU_CD <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD = '" & mudtSEARCH_ITEM2.XNYUKA_JIGYOU_CD & "' "
        End If


        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT "               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSYUKKA_DT "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE "      'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番枝番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_NM "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所名
        '↓↓↓↓ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XORDER_NO "                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№
        '↑↑↑↑ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI "                   'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI_CD "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSEIZOU_DT "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        製造年月日
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XHINSHITU_STS "             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(非表示)
        strSQL &= vbCrLf & "   , HASH01.FGAMEN_DISP "                               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FTRK_BUF_NO "               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示)
        strSQL &= vbCrLf & "   , TMST_TRK.FBUF_NAME "                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称(保管場所)


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT "               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSYUKKA_DT "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE "      'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番枝番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ(非表示)
        '↓↓↓↓ 2012.11.28 13:30 H.Morita 出力順の不具合修正
        'strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_NM "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所名
        'strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI "                   'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名
        '↑↑↑↑ 2012.11.28 13:30 H.Morita 出力順の不具合修正
        '↓↓↓↓ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XORDER_NO "                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№
        '↑↑↑↑ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI_CD "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSEIZOU_DT "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        製造年月日
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList2, strSQL, False)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup2()
        Call gobjComFuncFRM.GridSelect(grdList2, -1, 1, Nothing)        'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "  ﾘｽﾄ表示設定(ﾋﾟｯｷﾝｸﾞﾘｽﾄ全体)              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示設定
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup2()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList2)

        'grdList.MultiSelect = True
        'grdList.AllowUserToResizeColumns = False

    End Sub
#End Region
#Region "　印刷処理(ﾋﾟｯｷﾝｸﾞﾘｽﾄ全体）                "
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
        Dim objCR As New PRT_308041_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try

            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))

            ''受付車番
            'Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", mudtSEARCH_ITEM2.XCAR_NO_WARITUKE & _
            '                                              "-" & mudtSEARCH_ITEM2.XCAR_NO_EDA_WARITUKE)

            'Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", mudtSEARCH_ITEM2.XNYUKA_JIGYOU_NM)  '配送先

            Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", "")     '受付車番枝番(未使用)
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", "")     '配送先(未使用)


            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList2.Rows.Count - 1

                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

                objDataRow.Data14 = grdList2.Item(menmListCol2.XCAR_NO_WARITUKE, ii).FormattedValue _
                            & "-" & grdList2.Item(menmListCol2.XCAR_NO_EDA_WARITUKE, ii).FormattedValue       '(ﾍｯﾀﾞｰ)受付車番-受付車番枝番
                objDataRow.Data15 = grdList2.Item(menmListCol2.XNYUKA_JIGYOU_NM, ii).FormattedValue           '(ﾍｯﾀﾞｰ)入荷事業所ｺｰﾄﾞ

                objDataRow.Data00 = grdList2.Item(menmListCol2.XHIKIATE_DT, ii).FormattedValue                '出荷引当日時
                objDataRow.Data01 = grdList2.Item(menmListCol2.XCAR_NO_WARITUKE, ii).FormattedValue           '割付車番
                objDataRow.Data02 = grdList2.Item(menmListCol2.XCAR_NO_EDA_WARITUKE, ii).FormattedValue       '割付車番枝番
                objDataRow.Data03 = grdList2.Item(menmListCol2.XNYUKA_JIGYOU_CD, ii).FormattedValue           '入荷事業所ｺｰﾄﾞ

                objDataRow.Data04 = ii + 1                                                                    '№
                '↓↓↓↓ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
                objDataRow.Data16 = grdList2.Item(menmListCol2.XORDER_NO, ii).FormattedValue                  '発注№
                '↑↑↑↑ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
                objDataRow.Data05 = grdList2.Item(menmListCol2.FHINMEI_CD, ii).FormattedValue                 '品名ｺｰﾄﾞ
                objDataRow.Data06 = grdList2.Item(menmListCol2.FHINMEI, ii).FormattedValue                    '品名
                objDataRow.Data07 = grdList2.Item(menmListCol2.XSEIZOU_DT, ii).FormattedValue                 '製造年月日
                objDataRow.Data09 = grdList2.Item(menmListCol2.XHIKIATE_VOL, ii).FormattedValue               '引当数
                objDataRow.Data10 = grdList2.Item(menmListCol2.XPRINT_PL_NUM, ii).FormattedValue              'PL
                objDataRow.Data11 = grdList2.Item(menmListCol2.XPRINT_BARA_DAN_NUM, ii).FormattedValue        '段
                objDataRow.Data12 = grdList2.Item(menmListCol2.XPRINT_BARA_NUM, ii).FormattedValue            'C/S

                objDataRow.Data08 = grdList2.Item(menmListCol2.XHINSHITU_STS_DSP, ii).FormattedValue          '品質ｽﾃｰﾀｽ
                objDataRow.Data13 = grdList2.Item(menmListCol2.FBUF_NAME, ii).FormattedValue                  '保管場所

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

#Region "　ﾘｽﾄ表示(ﾋﾟｯｷﾝｸﾞﾘｽﾄ)                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild3()

        Dim strSQL As String                        'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT "                                               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(非表示)
        strSQL &= vbCrLf & "   , TO_CHAR(XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT, 'YYYY/MM/DD') AS XHIKIATE_DT_DSP "     'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(表示用)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSYUKKA_DT "                                                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(非表示)
        strSQL &= vbCrLf & "   , TO_CHAR(TO_DATE(XPLN_SYUKKA_PICK_PRINT.XSYUKKA_DT, 'YYYY/MM/DD'), 'YYYY/MM/DD') AS XSYUKKA_DT_DSP "       'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(表示用)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE "                                          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE "                                      'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番枝番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD "                                          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_NM "                                          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所名
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XORDER_NO "                                                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XIDOU_CD "                                                  'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        移動手段ｺｰﾄﾞ(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XIDOU_NM "                                                  'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        移動手段名

        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FTRK_BUF_NO "                                               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示)
        strSQL &= vbCrLf & "   , TMST_TRK.FBUF_NAME "                                                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称(保管場所)

        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI_CD "                                                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI "                                                   'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名
        strSQL &= vbCrLf & "   , TO_CHAR(XPLN_SYUKKA_PICK_PRINT.XSEIZOU_DT, 'YYYY/MM/DD') "                         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        製造年月日
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XHIKIATE_VOL "                                              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        引当数
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XPRINT_PL_NUM "                                             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        PL
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XPRINT_BARA_DAN_NUM "                                       'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        段
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XPRINT_BARA_NUM "                                           'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        C/S
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XWEIGHT "                                                   'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        重量
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSYUKKA_KAHI "                                              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷可否(非表示)
        strSQL &= vbCrLf & "   , HASH01.FGAMEN_DISP AS XSYUKKA_KAHI_DSP "                                           'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷可否(表示用)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XHINSHITU_STS "                                             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(非表示)
        strSQL &= vbCrLf & "   , HASH02.FGAMEN_DISP AS XHINSHITU_STS_DSP "                                          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "   , TMST_ITEM.FDECIMAL_POINT "                                                         '品目ﾏｽﾀ.           小数点以下有効桁数


        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XPLN_SYUKKA_PICK_PRINT "                         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ情報
        strSQL &= vbCrLf & "  , TMST_TRK "                                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ
        strSQL &= vbCrLf & "  , TMST_ITEM "                                      '品目ﾏｽﾀ
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XPLN_SYUKKA_PICK_PRINT", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "XPLN_SYUKKA_PICK_PRINT", "XHINSHITU_STS")


        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "    AND XPLN_SYUKKA_PICK_PRINT.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "    AND XPLN_SYUKKA_PICK_PRINT.FHINMEI_CD  = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XPLN_SYUKKA_PICK_PRINT", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "XPLN_SYUKKA_PICK_PRINT", "XHINSHITU_STS")
        strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.FTRK_BUF_NO IN ("
        strSQL &= vbCrLf & FTRK_BUF_NO_J8000 & ", "
        strSQL &= vbCrLf & FTRK_BUF_NO_J8001 & ", "
        strSQL &= vbCrLf & FTRK_BUF_NO_J8100 & ", " & FTRK_BUF_NO_J8101 & ", " _
                         & FTRK_BUF_NO_J8102 & ", " & FTRK_BUF_NO_J8103 & ", " _
                         & FTRK_BUF_NO_J8104 & ", " & FTRK_BUF_NO_J8105 & ", " _
                         & FTRK_BUF_NO_J8106 & ", " & FTRK_BUF_NO_J8107 & ", " _
                         & FTRK_BUF_NO_J8108 & ", " & FTRK_BUF_NO_J8109
        strSQL &= vbCrLf & ") "


        '-----------------------------
        '出荷引当日時
        '-----------------------------
        If mudtSEARCH_ITEM2.XSYUKKA_DT <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT = TO_DATE('" & mudtSEARCH_ITEM2.XHIKIATE_DT & "', 'YYYY/MM/DD HH24:MI:SS') "
        End If

        '-----------------------------
        '発注№
        '-----------------------------
        If mudtSEARCH_ITEM2.XORDER_NO <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XORDER_NO = '" & mudtSEARCH_ITEM2.XORDER_NO & "' "
        End If

        '-----------------------------
        '受付車番
        '-----------------------------
        If mudtSEARCH_ITEM2.XCAR_NO_WARITUKE <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE = '" & mudtSEARCH_ITEM2.XCAR_NO_WARITUKE & "' "
        End If

        '-----------------------------
        '受付車番枝番
        '-----------------------------
        If mudtSEARCH_ITEM2.XCAR_NO_EDA_WARITUKE <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE = '" & mudtSEARCH_ITEM2.XCAR_NO_EDA_WARITUKE & "' "
        End If

        '-----------------------------
        '配送先ｺｰﾄﾞ
        '-----------------------------
        If mudtSEARCH_ITEM2.XNYUKA_JIGYOU_CD <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD = '" & mudtSEARCH_ITEM2.XNYUKA_JIGYOU_CD & "' "
        End If

        '-----------------------------
        '移動手段ｺｰﾄﾞ
        '-----------------------------
        If mudtSEARCH_ITEM2.XIDOU_CD <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XIDOU_CD = '" & mudtSEARCH_ITEM2.XIDOU_CD & "' "
        End If

        '-----------------------------
        '業者ｺｰﾄﾞ
        '-----------------------------
        If mudtSEARCH_ITEM2.XGYOSHA_CD <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XGYOSHA_CD = '" & mudtSEARCH_ITEM2.XGYOSHA_CD & "' "
        End If


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT "                                               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSYUKKA_DT "                                                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE "                                          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        車番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE "                                      'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        車番枝番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD "                                          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XORDER_NO "                                                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XIDOU_CD "                                                  'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        移動手段ｺｰﾄﾞ(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FTRK_BUF_NO "                                               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI_CD "                                                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSEIZOU_DT "                                                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        製造年月日
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList3, strSQL, False)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup3()
        Call gobjComFuncFRM.GridSelect(grdList3, -1, 1, Nothing)        'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "  ﾘｽﾄ表示設定(ﾋﾟｯｷﾝｸﾞﾘｽﾄ)                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示設定
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup3()

        '************************************************
        '重量小数点表示
        '************************************************
        Call gobjComFuncFRM.GridFTR_VOLChange01(grdList3, menmListCol3.XWEIGHT, menmListCol3.FDECIMAL_POINT)


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList3)

        'grdList.MultiSelect = True
        'grdList.AllowUserToResizeColumns = False

    End Sub
#End Region
#Region "　印刷処理(ﾋﾟｯｷﾝｸﾞﾘｽﾄ）                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub printOut02()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_308041_02          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try

            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))

            Dim strFTRK_BUF_NO_OLD As String = ""       '旧ｷｰ
            Dim intRec_Cnt As Integer = 0               'ﾚｺｰﾄﾞｶｳﾝﾄ

            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList3.Rows.Count - 1

                If ii = 0 Then
                    '(1回目の時)
                    'Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", grdList3.Item(menmListCol3.XNYUKA_JIGYOU_NM, ii).FormattedValue)  '配送先
                    ''Call gobjComFuncFRM.ChangeCRText(objCR, "crText03", grdList3.Item(menmListCol3.XHIKIATE_DT_DSP, ii).FormattedValue)   '出荷日
                    'Call gobjComFuncFRM.ChangeCRText(objCR, "crText03", grdList3.Item(menmListCol3.XSYUKKA_DT_DSP, ii).FormattedValue)    '出荷日
                    'Call gobjComFuncFRM.ChangeCRText(objCR, "crText05", grdList3.Item(menmListCol3.XIDOU_NM, ii).FormattedValue)          '移動手段
                    'Call gobjComFuncFRM.ChangeCRText(objCR, "crText06", grdList3.Item(menmListCol3.XCAR_NO_WARITUKE, ii).FormattedValue & "-" & _
                    '                                                    grdList3.Item(menmListCol3.XCAR_NO_EDA_WARITUKE, ii).FormattedValue)       '受付車番
                    Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", "")  '配送先
                    Call gobjComFuncFRM.ChangeCRText(objCR, "crText03", "")  '出荷日
                    Call gobjComFuncFRM.ChangeCRText(objCR, "crText05", "")  '移動手段
                    Call gobjComFuncFRM.ChangeCRText(objCR, "crText06", "")  '受付車番-受付車番枝番
                End If


                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

                objDataRow.Data19 = grdList3.Item(menmListCol3.FBUF_NAME, ii).FormattedValue            '保管場所
                objDataRow.Data20 = grdList3.Item(menmListCol3.XORDER_NO, ii).FormattedValue            '発注№
                objDataRow.Data21 = grdList3.Item(menmListCol3.XCAR_NO_WARITUKE, ii).FormattedValue & "-" & _
                                    grdList3.Item(menmListCol3.XCAR_NO_EDA_WARITUKE, ii).FormattedValue '受付車番-受付車番枝番
                objDataRow.Data22 = grdList3.Item(menmListCol3.XNYUKA_JIGYOU_NM, ii).FormattedValue     '配送先
                objDataRow.Data23 = grdList3.Item(menmListCol3.XSYUKKA_DT_DSP, ii).FormattedValue       '出荷日
                objDataRow.Data24 = grdList3.Item(menmListCol3.XIDOU_NM, ii).FormattedValue             '移動手段

                objDataRow.Data00 = grdList3.Item(menmListCol3.XHIKIATE_DT, ii).FormattedValue          '出荷引当日時
                objDataRow.Data01 = grdList3.Item(menmListCol3.XCAR_NO_WARITUKE, ii).FormattedValue     '割付車番
                objDataRow.Data02 = grdList3.Item(menmListCol3.XCAR_NO_EDA_WARITUKE, ii).FormattedValue '割付車番枝番
                objDataRow.Data03 = grdList3.Item(menmListCol3.XNYUKA_JIGYOU_CD, ii).FormattedValue     '入荷事業所ｺｰﾄﾞ
                objDataRow.Data04 = grdList3.Item(menmListCol3.XORDER_NO, ii).FormattedValue            '発注№
                objDataRow.Data05 = grdList3.Item(menmListCol3.XIDOU_CD, ii).FormattedValue             '移動手段ｺｰﾄﾞ

                objDataRow.Data07 = grdList3.Item(menmListCol3.FTRK_BUF_NO, ii).FormattedValue          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№

                If strFTRK_BUF_NO_OLD <> grdList3.Item(menmListCol3.FTRK_BUF_NO, ii).FormattedValue Then
                    '(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№が異なるとき)
                    strFTRK_BUF_NO_OLD = grdList3.Item(menmListCol3.FTRK_BUF_NO, ii).FormattedValue
                    intRec_Cnt = 1
                Else
                    '(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№が同じのとき)
                    intRec_Cnt += 1
                End If
                objDataRow.Data08 = intRec_Cnt                                                          '№

                objDataRow.Data09 = grdList3.Item(menmListCol3.FHINMEI_CD, ii).FormattedValue           '品名ｺｰﾄﾞ
                objDataRow.Data10 = grdList3.Item(menmListCol3.FHINMEI, ii).FormattedValue              '品名
                objDataRow.Data16 = grdList3.Item(menmListCol3.XSEIZOU_DT, ii).FormattedValue           '製造年月日
                objDataRow.Data11 = grdList3.Item(menmListCol3.XHIKIATE_VOL, ii).FormattedValue         '引当数(C/S)
                objDataRow.Data12 = grdList3.Item(menmListCol3.XPRINT_PL_NUM, ii).FormattedValue        'PL

                '↓↓↓↓ 2012.11.28 13:30 H.Morita
                If TO_INTEGER(grdList3.Item(menmListCol3.XPRINT_BARA_DAN_NUM, ii).FormattedValue) = 0 Then
                    '(段がｾﾞﾛの時)
                    objDataRow.Data13 = ""                                                                  '段
                Else
                    '(段に値がある時)
                    objDataRow.Data13 = grdList3.Item(menmListCol3.XPRINT_BARA_DAN_NUM, ii).FormattedValue  '段
                End If
                '↑↑↑↑ 2012.11.28 13:30 H.Morita

                '↓↓↓↓ 2012.11.28 13:30 H.Morita
                If TO_INTEGER(grdList3.Item(menmListCol3.XPRINT_BARA_NUM, ii).FormattedValue) = 0 Then
                    '(C/Sがｾﾞﾛの時)
                    objDataRow.Data14 = ""                                                                  'C/S
                Else
                    '(C/Sに値がある時)
                    objDataRow.Data14 = grdList3.Item(menmListCol3.XPRINT_BARA_NUM, ii).FormattedValue      'C/S
                End If
                '↑↑↑↑ 2012.11.28 13:30 H.Morita

                objDataRow.Data15 = grdList3.Item(menmListCol3.XWEIGHT, ii).FormattedValue              '重量
                objDataRow.Data17 = grdList3.Item(menmListCol3.XSYUKKA_KAHI_DSP, ii).FormattedValue     '出荷可否
                objDataRow.Data18 = grdList3.Item(menmListCol3.XHINSHITU_STS_DSP, ii).FormattedValue    '品質ｽﾃｰﾀｽ

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
