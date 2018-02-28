'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出荷作業状況画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_308020

#Region "　共通変数　                               "

    Protected mudtSEARCH_ITEM As New stcSEARCH_ITEM     '検索条件用構造体

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        XSYUKKA_NO                          '出荷計画.          出荷№(非表示)
        '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        'XPLN_OUT_ID                         '出荷計画.          出荷計画ID(非表示)
        XPLN_DTL_NO                         '出荷計画詳細.      出荷明細№(非表示)
        '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        XSYUKKA_DT                          '出荷計画.          出荷日(非表示)
        XCAR_NO_WARITUKE                    '出荷計画.          受付車番(非表示)
        XCAR_NO_EDA_WARITUKE                '出荷計画.          枝番(非表示)
        '↓↓↓↓ 2012.11.28 13:30 H.Morita 配送先名の表示
        'XNYUKA_JIGYOU_CD                    '出荷計画.          配送先ｺｰﾄﾞ(非表示)
        'XNYUKA_JIGYOU_NM                    '出荷計画.          配送先(非表示)
        '↑↑↑↑ 2012.11.28 13:30 H.Morita 配送先名の表示
        XORDER_NO                           '出荷計画.          発注№
        FHINMEI_CD                          '出荷計画詳細.      品名ｺｰﾄﾞ
        FHINMEI                             '出荷計画詳細.      品名
        XSEIZOU_DT                          '出荷実績.          製造年月日
        FTRK_BUF_NO                         '出荷実績.          出庫場所
        FBUF_NAME                           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.   出庫場所(表示用)
        XSYUKKA_VOL                         '出荷計画詳細.      出荷数(SUM値)
        XSYUKKO_VOL                         '出荷計画詳細.      出庫数(SUM値)
        XSYUKKA_KENPIN_VOL                  '出荷検品実績ﾛｸﾞ.   検品数(SUM値)
        XSYUKKA_STS                         '                   出荷状況(SUM出荷数 - SUM検品数)
        XSYUKKA_STS_DSP                     '                   出荷状況(SUM出荷数 - SUM検品数) (表示用)
        '↓↓↓↓ 2012.11.28 13:30 H.Morita 配送先名の表示
        XNYUKA_JIGYOU_CD                    '出荷計画.          配送先ｺｰﾄﾞ(非表示)
        XNYUKA_JIGYOU_NM                    '出荷計画.          配送先(非表示)
        '↑↑↑↑ 2012.11.28 13:30 H.Morita 配送先名の表示
        XKENPIN_FLAG                        '出荷実績.          検品済みﾌﾗｸﾞ(非表示)

        MAXCOL                              'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        DtlBtn_Click                '詳細ﾎﾞﾀﾝｸﾘｯｸ
        BerthKaihouBtn_Click        'ﾊﾞｰｽ解放ﾎﾞﾀﾝｸﾘｯｸ
        ManualKenpinBtn_Click       'ﾏﾆｭｱﾙ検品ﾎﾞﾀﾝｸﾘｯｸ
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Protected Structure stcSEARCH_ITEM
        Dim XCAR_NO_DAIHYOU As String                   '代表車番
        Dim XCAR_NO_EDA_DAIHYOU As String               '代表車番枝番
    End Structure
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　表示更新    ﾀｲﾏ　                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示更新    ﾀｲﾏ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr308020_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr308020.Tick
        Try

            tmr308020.Enabled = False

            '**************************************************
            ' 表示更新処理
            '**************************************************
            Call tmr308020_TickProcess()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmr308020.Enabled = True

        End Try
    End Sub
#End Region
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    Public Overrides Sub InitializeChild()


        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        lblXBERTH_NO.Text = gstrXBERTH_NO
        lblXCAR_NO_WARITUKE.Text = gstrXCAR_NO_DAIHYOU      '代表車番
        '*DEL 2012.11.28 13:30 H.Morita 配送先名をｸﾞﾘｯﾄﾞ上に表示に変更 * lblXNYUKA_JIGYOU_NM.Text = ""                


        '*********************************************
        ' ﾘｽﾄ表示
        '*********************************************
        '↓↓↓↓ 2012.11.28 13:30 H.Morita 配送先名の表示
        'grdList.ScrollBars = ScrollBars.Vertical
        grdList.ScrollBars = ScrollBars.Both
        '↑↑↑↑ 2012.11.28 13:30 H.Morita 配送先名の表示

        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)    'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)

        '↓↓↓↓ 2012.11.28 13:30 H.Morita 配送先名をｸﾞﾘｯﾄﾞ上に表示に変更 
        'If grdList.RowCount > 0 Then
        '    '(ｸﾞﾘｯﾄﾞ表示あり)
        '    lblXNYUKA_JIGYOU_NM.Text = TO_STRING(grdList.Item(menmListCol.XNYUKA_JIGYOU_NM, 0).Value)             '配送先
        'End If
        '↑↑↑↑ 2012.11.28 13:30 H.Morita 配送先名をｸﾞﾘｯﾄﾞ上に表示に変更 

        '**********************************************************
        ' ﾀｲﾏｰ設定
        '**********************************************************
        tmr308020.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS308020_001))
        tmr308020.Enabled = True


        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                               "
    Public Overrides Sub CloseChild()

        tmr308020.Enabled = False

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        lblXBERTH_NO.Dispose()              'ﾊﾞｰｽ№
        lblXCAR_NO_WARITUKE.Dispose()       '受付車番
        '*DEL 2012.11.28 13:30 H.Morita 配送先名をｸﾞﾘｯﾄﾞ上に表示に変更 * lblXNYUKA_JIGYOU_NM.Dispose()       '配送先/出荷先
        grdList.Dispose()                   'ｸﾞﾘｯﾄﾞ
        tmr308020.Dispose()                 'ﾀｲﾏ

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
        If IsNull(gobjFRM_308021) = False Then
            gobjFRM_308021.Close()
            gobjFRM_308021.Dispose()
            gobjFRM_308021 = Nothing
        End If

        '********************************************************************
        ' 詳細画面ﾌｫｰﾑ展開
        '********************************************************************
        gobjFRM_308021 = New FRM_308021                             'ｵﾌﾞｼﾞｪｸﾄ作成

        Call SetProperty(gobjFRM_308021)        'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        Call gobjFRM_308021.ShowDialog()        '画面表示


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
#Region "  F5(ﾊﾞｰｽ解放)       ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F5  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F5Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.BerthKaihouBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        tmr308020.Enabled = False

        If SendSocket01() = False Then
            tmr308020.Enabled = True
            Exit Sub
        End If


        '******************************************
        ' 画面遷移
        '******************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_308010, Me)

        tmr308020.Dispose()
        Me.Dispose()
        Me.Close()

    End Sub
#End Region
#Region "  F6(ﾏﾆｭｱﾙ検品)      ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F6  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F6Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.ManualKenpinBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '↓↓↓ 2012/11/08 19:30 
        ''********************************************************************
        '' ﾏﾆｭｱﾙ検品画面ﾌｫｰﾑ展開
        ''********************************************************************
        ''ｵﾌﾞｼﾞｪｸﾄNothingﾁｪｯｸ
        'If IsNull(gobjFRM_308030) = False Then
        '    gobjFRM_308030.Close()
        '    gobjFRM_308030.Dispose()
        '    gobjFRM_308030 = Nothing
        'End If

        'gobjFRM_308030 = New FRM_308030                             'ｵﾌﾞｼﾞｪｸﾄ作成

        'Call SetProperty2(gobjFRM_308030)       'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        'Call gobjFRM_308030.ShowDialog()        '画面表示


        '********************************************************************
        ' ﾏﾆｭｱﾙ検品画面ﾌｫｰﾑ展開
        '********************************************************************
        'ｵﾌﾞｼﾞｪｸﾄNothingﾁｪｯｸ
        If IsNull(gobjFRM_308160) = False Then
            gobjFRM_308160.Close()
            gobjFRM_308160.Dispose()
            gobjFRM_308160 = Nothing
        End If

        gobjFRM_308160 = New FRM_308160                             'ｵﾌﾞｼﾞｪｸﾄ作成

        Call SetProperty3(gobjFRM_308160)       'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        Call gobjFRM_308160.ShowDialog()        '画面表示
        '↑↑↑ 2012/11/08 19:30 


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
        mudtSEARCH_ITEM.XCAR_NO_DAIHYOU = gstrXCAR_NO_DAIHYOU            '代表車番
        mudtSEARCH_ITEM.XCAR_NO_EDA_DAIHYOU = gstrXCAR_NO_EDA_DAIHYOU    '代表車番枝番

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
        strSQL &= vbCrLf & "    XSYUKKA_NO "
        '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        'strSQL &= vbCrLf & "  , XPLN_OUT_ID "
        strSQL &= vbCrLf & "  , XPLN_DTL_NO "
        '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        strSQL &= vbCrLf & "  , XSYUKKA_DT_DSP "
        strSQL &= vbCrLf & "  , XCAR_NO_WARITUKE "
        strSQL &= vbCrLf & "  , XCAR_NO_EDA_WARITUKE "
        '↓↓↓↓ 2012.11.28 13:30 H.Morita 配送先名の表示
        'strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_CD "
        'strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_NM "
        '↑↑↑↑ 2012.11.28 13:30 H.Morita 配送先名の表示
        strSQL &= vbCrLf & "  , XORDER_NO "
        strSQL &= vbCrLf & "  , FHINMEI_CD "
        strSQL &= vbCrLf & "  , FHINMEI "
        strSQL &= vbCrLf & "  , XSEIZOU_DT "
        strSQL &= vbCrLf & "  , FTRK_BUF_NO "
        strSQL &= vbCrLf & "  , FBUF_NAME "
        strSQL &= vbCrLf & "  , SYUKKA_SU "
        strSQL &= vbCrLf & "  , SYUKKO_SU "
        strSQL &= vbCrLf & "  , KENPIN_SU"
        strSQL &= vbCrLf & "  , XSYUKKA_STS "
        strSQL &= vbCrLf & "  , CASE WHEN XSYUKKA_STS = '4' THEN '強制完了' "
        strSQL &= vbCrLf & "         WHEN XSYUKKA_STS = '1' THEN '出庫中' "
        strSQL &= vbCrLf & "         WHEN XSYUKKA_STS = '3' THEN '検品完了' "
        strSQL &= vbCrLf & "         ELSE '検品中' "
        strSQL &= vbCrLf & "    END AS XSYUKKA_STS_DSP "
        '↓↓↓↓ 2012.11.28 13:30 H.Morita 配送先名の表示
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_CD "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_NM "
        '↑↑↑↑ 2012.11.28 13:30 H.Morita 配送先名の表示
        strSQL &= vbCrLf & "  FROM "
        strSQL &= vbCrLf & "  ("

        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    XSYUKKA_NO "
        '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        'strSQL &= vbCrLf & "  , XPLN_OUT_ID "
        strSQL &= vbCrLf & "  , XPLN_DTL_NO "
        '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        strSQL &= vbCrLf & "  , XSYUKKA_DT_DSP "
        strSQL &= vbCrLf & "  , XCAR_NO_WARITUKE "
        strSQL &= vbCrLf & "  , XCAR_NO_EDA_WARITUKE "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_CD "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_NM "
        strSQL &= vbCrLf & "  , XORDER_NO "
        strSQL &= vbCrLf & "  , FHINMEI_CD "
        strSQL &= vbCrLf & "  , FHINMEI "
        strSQL &= vbCrLf & "  , XSEIZOU_DT "
        strSQL &= vbCrLf & "  , FTRK_BUF_NO "
        strSQL &= vbCrLf & "  , FBUF_NAME "
        strSQL &= vbCrLf & "  , SUM(SYUKKA_SU)   AS SYUKKA_SU "
        strSQL &= vbCrLf & "  , SUM(SYUKKO_SU)   AS SYUKKO_SU "
        strSQL &= vbCrLf & "  , SUM(KENPIN_SU)   AS KENPIN_SU "
        strSQL &= vbCrLf & "  , MIN(XSYUKKA_STS) AS XSYUKKA_STS "
        strSQL &= vbCrLf & "  , ''               AS XSYUKKA_STS_DSP "
        strSQL &= vbCrLf & "  FROM "
        strSQL &= vbCrLf & "  ("

        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    XSYUKKA_NO "
        '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        'strSQL &= vbCrLf & "  , XPLN_OUT_ID "
        strSQL &= vbCrLf & "  , XPLN_DTL_NO "
        '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        strSQL &= vbCrLf & "  , XSYUKKA_DT_DSP "
        strSQL &= vbCrLf & "  , XCAR_NO_WARITUKE "
        strSQL &= vbCrLf & "  , XCAR_NO_EDA_WARITUKE "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_CD "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_NM "
        strSQL &= vbCrLf & "  , XORDER_NO "
        strSQL &= vbCrLf & "  , FHINMEI_CD "
        strSQL &= vbCrLf & "  , FHINMEI "
        strSQL &= vbCrLf & "  , XSEIZOU_DT "
        strSQL &= vbCrLf & "  , FTRK_BUF_NO "
        strSQL &= vbCrLf & "  , FBUF_NAME "
        strSQL &= vbCrLf & "  , SYUKKA_SU "
        strSQL &= vbCrLf & "  , SYUKKO_SU "
        strSQL &= vbCrLf & "  , KENPIN_SU"
        strSQL &= vbCrLf & "  , CASE WHEN XKENPIN_FLAG = " & XKENPIN_FLAG_JKYOUSEI & " THEN '4' "
        strSQL &= vbCrLf & "         WHEN ((SYUKKA_SU - SYUKKO_SU) > 0 ) AND (FTRK_BUF_NO NOT IN (" & FTRK_BUF_NO_J8000 & ", " & FTRK_BUF_NO_J8001 & ", " & FTRK_BUF_NO_J8002 & ")) THEN '1' "
        strSQL &= vbCrLf & "         WHEN XKENPIN_FLAG = " & XKENPIN_FLAG_JON & " THEN '3' "
        strSQL &= vbCrLf & "         ELSE '2' "
        strSQL &= vbCrLf & "    END AS XSYUKKA_STS "
        'strSQL &= vbCrLf & "  , CASE WHEN XKENPIN_FLAG = " & XKENPIN_FLAG_JKYOUSEI & " THEN '強制完了' "
        'strSQL &= vbCrLf & "         WHEN ((SYUKKA_SU - SYUKKO_SU)  > 0) AND (FTRK_BUF_NO NOT IN (" & FTRK_BUF_NO_J8000 & ", " & FTRK_BUF_NO_J8001 & ", " & FTRK_BUF_NO_J8002 & ")) THEN '出庫中' "
        'strSQL &= vbCrLf & "         WHEN XKENPIN_FLAG = " & XKENPIN_FLAG_JON & " THEN '検品完了' "
        'strSQL &= vbCrLf & "         ELSE '検品中' "
        'strSQL &= vbCrLf & "    END AS XSYUKKA_STS_DSP "
        strSQL &= vbCrLf & "  , '' AS XSYUKKA_STS_DSP "
        strSQL &= vbCrLf & "  , XKENPIN_FLAG "
        strSQL &= vbCrLf & "  FROM "
        strSQL &= vbCrLf & "  ("

        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    XSYUKKA_NO "
        '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        'strSQL &= vbCrLf & "  , XPLN_OUT_ID "
        strSQL &= vbCrLf & "  , XPLN_DTL_NO "
        '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        strSQL &= vbCrLf & "  , XSYUKKA_DT_DSP "
        strSQL &= vbCrLf & "  , XCAR_NO_WARITUKE "
        strSQL &= vbCrLf & "  , XCAR_NO_EDA_WARITUKE "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_CD "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_NM "
        strSQL &= vbCrLf & "  , XORDER_NO "
        strSQL &= vbCrLf & "  , FHINMEI_CD "
        strSQL &= vbCrLf & "  , FHINMEI "
        strSQL &= vbCrLf & "  , XSEIZOU_DT "
        strSQL &= vbCrLf & "  , FTRK_BUF_NO "
        strSQL &= vbCrLf & "  , FBUF_NAME "
        strSQL &= vbCrLf & "  , SYUKKA_SU "
        strSQL &= vbCrLf & "  , (SYUKKO_SU + KENPIN_SU) AS SYUKKO_SU "
        strSQL &= vbCrLf & "  , KENPIN_SU"
        strSQL &= vbCrLf & "  , XSYUKKA_STS "
        strSQL &= vbCrLf & "  , XSYUKKA_STS_DSP "
        strSQL &= vbCrLf & "  , XKENPIN_FLAG "
        strSQL &= vbCrLf & "  FROM "
        strSQL &= vbCrLf & "  ("
        strSQL &= vbCrLf & "   SELECT "
        strSQL &= vbCrLf & "      XSYUKKA_NO "
        '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        'strSQL &= vbCrLf & "    , XPLN_OUT_ID "
        strSQL &= vbCrLf & "    , XPLN_DTL_NO "
        '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        strSQL &= vbCrLf & "    , XSYUKKA_DT_DSP "
        strSQL &= vbCrLf & "    , XCAR_NO_WARITUKE "
        strSQL &= vbCrLf & "    , XCAR_NO_EDA_WARITUKE "
        strSQL &= vbCrLf & "    , XNYUKA_JIGYOU_CD "
        strSQL &= vbCrLf & "    , XNYUKA_JIGYOU_NM "
        strSQL &= vbCrLf & "    , XORDER_NO "
        strSQL &= vbCrLf & "    , FHINMEI_CD "
        strSQL &= vbCrLf & "    , FHINMEI "
        strSQL &= vbCrLf & "    , XSEIZOU_DT "
        strSQL &= vbCrLf & "    , FTRK_BUF_NO "
        strSQL &= vbCrLf & "    , FBUF_NAME "
        strSQL &= vbCrLf & "    , SUM(SYUKKA_SU) AS SYUKKA_SU"
        strSQL &= vbCrLf & "    , SUM(NVL(SYUKKO_SU, 0)) AS SYUKKO_SU"
        strSQL &= vbCrLf & "    , SUM(KENPIN_SU) AS KENPIN_SU"
        strSQL &= vbCrLf & "    , XSYUKKA_STS "
        strSQL &= vbCrLf & "    , XSYUKKA_STS_DSP "
        strSQL &= vbCrLf & "    , XKENPIN_FLAG "
        strSQL &= vbCrLf & "   FROM "
        strSQL &= vbCrLf & "   ("
        strSQL &= vbCrLf & "    SELECT "
        strSQL &= vbCrLf & "       XPLN_OUT.XSYUKKA_NO "
        '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        'strSQL &= vbCrLf & "     , XPLN_OUT.XPLN_OUT_ID "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XPLN_DTL_NO "
        '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        strSQL &= vbCrLf & "     , TO_DATE(XPLN_OUT.XSYUKKA_DT, 'YYYY/MM/DD') AS XSYUKKA_DT_DSP "
        strSQL &= vbCrLf & "     , XPLN_OUT.XCAR_NO_WARITUKE "
        strSQL &= vbCrLf & "     , XPLN_OUT.XCAR_NO_EDA_WARITUKE "
        strSQL &= vbCrLf & "     , XPLN_OUT.XNYUKA_JIGYOU_CD "
        strSQL &= vbCrLf & "     , XPLN_OUT.XNYUKA_JIGYOU_NM "
        strSQL &= vbCrLf & "     , XPLN_OUT.XORDER_NO "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.FHINMEI_CD "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.FHINMEI "
        strSQL &= vbCrLf & "     , XRST_OUT.XSEIZOU_DT "
        'strSQL &= vbCrLf & "     , XRST_OUT.FPALLET_ID "
        strSQL &= vbCrLf & "     , NVL(XRST_OUT.XPALLET_ID_CHECK, XRST_OUT.XPALLET_ID_KARI) "
        strSQL &= vbCrLf & "     , XRST_OUT.FTRK_BUF_NO "
        strSQL &= vbCrLf & "     , TMST_TRK.FBUF_NAME "
        strSQL &= vbCrLf & "     , TMST_TRK.XTRK_BUF_NO_OUT_HIRA"
        strSQL &= vbCrLf & "     , NVL(TMST_TRK.XTRK_BUF_NO_OUT_HIRA,TMST_TRK.FTRK_BUF_NO) AS FTRK_BUF_NO_HERE"
        strSQL &= vbCrLf & "     , XRST_OUT.FTR_VOL  AS SYUKKA_SU "
        strSQL &= vbCrLf & "     , ("
        strSQL &= vbCrLf & "        CASE XRST_OUT.FTRK_BUF_NO "
        strSQL &= vbCrLf & "         WHEN " & FTRK_BUF_NO_J8000 & " THEN "
        strSQL &= vbCrLf & "           (SELECT "
        strSQL &= vbCrLf & "             TSTS_HIKIATE.FTR_VOL "
        strSQL &= vbCrLf & "           FROM "
        strSQL &= vbCrLf & "             TSTS_HIKIATE "
        strSQL &= vbCrLf & "           WHERE (0 = 0) "
        strSQL &= vbCrLf & "             AND XPLN_OUT_DTL.FPLAN_KEY = TSTS_HIKIATE.FPLAN_KEY "
        'strSQL &= vbCrLf & "             AND XRST_OUT.FPALLET_ID    = TSTS_HIKIATE.FPALLET_ID ) "
        strSQL &= vbCrLf & "             AND NVL(XRST_OUT.XPALLET_ID_CHECK, XRST_OUT.XPALLET_ID_KARI) = TSTS_HIKIATE.FPALLET_ID ) "
        strSQL &= vbCrLf & "         ELSE "
        strSQL &= vbCrLf & "           (SELECT "
        strSQL &= vbCrLf & "              NVL(SUM(TRST_STOCK.FTR_RES_VOL), 0)"
        strSQL &= vbCrLf & "           FROM "
        strSQL &= vbCrLf & "              TRST_STOCK "
        strSQL &= vbCrLf & "            , TPRG_TRK_BUF "
        strSQL &= vbCrLf & "           WHERE (0 = 0) "
        'strSQL &= vbCrLf & "            AND XRST_OUT.FPALLET_ID     = TPRG_TRK_BUF.FPALLET_ID "
        strSQL &= vbCrLf & "            AND NVL(XRST_OUT.XPALLET_ID_CHECK, XRST_OUT.XPALLET_ID_KARI) = TPRG_TRK_BUF.FPALLET_ID "
        strSQL &= vbCrLf & "            AND NVL(TMST_TRK.XTRK_BUF_NO_OUT_HIRA,TMST_TRK.FTRK_BUF_NO)  = TPRG_TRK_BUF.FTRK_BUF_NO "
        strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FPALLET_ID = TRST_STOCK.FPALLET_ID ) "
        strSQL &= vbCrLf & "        END)                        AS SYUKKO_SU "
        strSQL &= vbCrLf & "     , XRST_OUT.XSYUKKA_KENPIN_VOL  AS KENPIN_SU"
        strSQL &= vbCrLf & "     , ''                           AS XSYUKKA_STS "
        strSQL &= vbCrLf & "     , ''                           AS XSYUKKA_STS_DSP "
        strSQL &= vbCrLf & "     , XRST_OUT.XKENPIN_FLAG "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "       XPLN_OUT "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
        strSQL &= vbCrLf & "     , XRST_OUT "
        strSQL &= vbCrLf & "     , TMST_TRK "
        strSQL &= vbCrLf & "    WHERE  0 = 0 "
        strSQL &= vbCrLf & "       AND XPLN_OUT.XSYUKKA_NO       = XPLN_OUT_DTL.XSYUKKA_NO(+) "
        strSQL &= vbCrLf & "       AND XPLN_OUT_DTL.XSYUKKA_NO   = XRST_OUT.XSYUKKA_NO(+) "
        strSQL &= vbCrLf & "       AND XPLN_OUT_DTL.XPLN_DTL_NO  = XRST_OUT.XPLN_DTL_NO(+) "
        strSQL &= vbCrLf & "       AND XRST_OUT.FTRK_BUF_NO      = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "       AND XRST_OUT.FTRK_BUF_NO    IN(" & FTRK_BUF_NO_J1
        strSQL &= vbCrLf & "                                    , " & FTRK_BUF_NO_J2
        strSQL &= vbCrLf & "                                    , " & FTRK_BUF_NO_J3
        strSQL &= vbCrLf & "                                    , " & FTRK_BUF_NO_J4
        strSQL &= vbCrLf & "                                    , " & FTRK_BUF_NO_J5
        strSQL &= vbCrLf & "                                    , " & FTRK_BUF_NO_J6
        strSQL &= vbCrLf & "                                    , " & FTRK_BUF_NO_J7
        strSQL &= vbCrLf & "                                    , " & FTRK_BUF_NO_J8
        strSQL &= vbCrLf & "                                    , " & FTRK_BUF_NO_J8000
        strSQL &= vbCrLf & "                                     ) "

        'strSQL &= vbCrLf & "      AND XPLN_OUT.XWARITUKE_DT = ( "
        strSQL &= vbCrLf & "      AND XPLN_OUT.XWARITUKE_DT IN ( "
        'strSQL &= vbCrLf & "                                   SELECT "
        ''strSQL &= vbCrLf & "                                      MAX(XPLN_OUT.XWARITUKE_DT) "
        'strSQL &= vbCrLf & "                                      XPLN_OUT.XWARITUKE_DT "
        'strSQL &= vbCrLf & "                                   FROM "
        'strSQL &= vbCrLf & "                                      XPLN_OUT "
        'strSQL &= vbCrLf & "                                   WHERE 1 = 1 "
        ''strSQL &= vbCrLf & "                                    AND XPLN_OUT.XCAR_NO_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_WARITUKE & "' "
        ''strSQL &= vbCrLf & "                                    AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE & "' "
        'strSQL &= vbCrLf & "                                    AND XPLN_OUT.XCAR_NO_DAIHYOU = '" & mudtSEARCH_ITEM.XCAR_NO_DAIHYOU & "' "
        'strSQL &= vbCrLf & "                                    AND XPLN_OUT.XCAR_NO_EDA_DAIHYOU = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_DAIHYOU & "' "

        strSQL &= vbCrLf & "                                   SELECT "
        strSQL &= vbCrLf & "                                        XWARITUKE_DT "
        strSQL &= vbCrLf & "                                   FROM "
        strSQL &= vbCrLf & "                                       ( "
        strSQL &= vbCrLf & "                                        SELECT "
        strSQL &= vbCrLf & "                                           XPLN_OUT.XCAR_NO_EDA_WARITUKE "
        strSQL &= vbCrLf & "                                         , MAX(XPLN_OUT.XWARITUKE_DT) AS XWARITUKE_DT "
        strSQL &= vbCrLf & "                                        FROM "
        strSQL &= vbCrLf & "                                           XPLN_OUT "
        strSQL &= vbCrLf & "                                        WHERE 1 = 1 "
        strSQL &= vbCrLf & "                                          AND XPLN_OUT.XCAR_NO_DAIHYOU     = '" & mudtSEARCH_ITEM.XCAR_NO_DAIHYOU & "' "
        strSQL &= vbCrLf & "                                          AND XPLN_OUT.XCAR_NO_EDA_DAIHYOU = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_DAIHYOU & "' "
        strSQL &= vbCrLf & "                                        GROUP BY "
        strSQL &= vbCrLf & "                                           XPLN_OUT.XCAR_NO_EDA_WARITUKE "
        strSQL &= vbCrLf & "                                       ) AA "

        strSQL &= vbCrLf & "                                  ) "

        '----------------------------------------------
        '代表車番
        '----------------------------------------------
        'If mudtSEARCH_ITEM.XCAR_NO_WARITUKE <> CBO_ALL_VALUE Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_WARITUKE & "' "
        'End If
        If mudtSEARCH_ITEM.XCAR_NO_DAIHYOU <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_DAIHYOU = '" & mudtSEARCH_ITEM.XCAR_NO_DAIHYOU & "' "
        End If

        '----------------------------------------------
        '代表車番枝番
        '----------------------------------------------
        'If mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE <> CBO_ALL_VALUE Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE & "' "
        'End If
        If mudtSEARCH_ITEM.XCAR_NO_EDA_DAIHYOU <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_EDA_DAIHYOU = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_DAIHYOU & "' "
        End If

        strSQL &= vbCrLf & "  ) A "
        strSQL &= vbCrLf & "  GROUP BY "
        strSQL &= vbCrLf & "    XSYUKKA_NO "
        '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        'strSQL &= vbCrLf & "  , XPLN_OUT_ID "
        strSQL &= vbCrLf & "  , XPLN_DTL_NO "
        '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        strSQL &= vbCrLf & "  , XSYUKKA_DT_DSP "
        strSQL &= vbCrLf & "  , XCAR_NO_WARITUKE "
        strSQL &= vbCrLf & "  , XCAR_NO_EDA_WARITUKE "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_CD "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_NM "
        strSQL &= vbCrLf & "  , XORDER_NO "
        strSQL &= vbCrLf & "  , FHINMEI_CD "
        strSQL &= vbCrLf & "  , FHINMEI "
        strSQL &= vbCrLf & "  , XSEIZOU_DT "
        strSQL &= vbCrLf & "  , FTRK_BUF_NO "
        strSQL &= vbCrLf & "  , FBUF_NAME "
        strSQL &= vbCrLf & "  , XSYUKKA_STS "
        strSQL &= vbCrLf & "  , XSYUKKA_STS_DSP "
        strSQL &= vbCrLf & "  , XKENPIN_FLAG "
        strSQL &= vbCrLf & " ) B "
        strSQL &= vbCrLf & " ) C "
        strSQL &= vbCrLf & " ) D "
        strSQL &= vbCrLf & "  GROUP BY "
        strSQL &= vbCrLf & "    XSYUKKA_NO "
        '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        'strSQL &= vbCrLf & "  , XPLN_OUT_ID "
        strSQL &= vbCrLf & "  , XPLN_DTL_NO "
        '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        strSQL &= vbCrLf & "  , XSYUKKA_DT_DSP "
        strSQL &= vbCrLf & "  , XCAR_NO_WARITUKE "
        strSQL &= vbCrLf & "  , XCAR_NO_EDA_WARITUKE "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_CD "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_NM "
        strSQL &= vbCrLf & "  , XORDER_NO "
        strSQL &= vbCrLf & "  , FHINMEI_CD "
        strSQL &= vbCrLf & "  , FHINMEI "
        strSQL &= vbCrLf & "  , XSEIZOU_DT "
        strSQL &= vbCrLf & "  , FTRK_BUF_NO "
        strSQL &= vbCrLf & "  , FBUF_NAME "
        strSQL &= vbCrLf & "  , XSYUKKA_STS_DSP "
        strSQL &= vbCrLf & " ) E "


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置      記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶

        '*******************************************
        '表示前のﾘｽﾄ選択記憶
        '*******************************************
        If grdList.SelectedCells.Count = 0 Then
            intSelectRow = -1               'ﾘｽﾄの行
            intSelectCol = -1               'ﾘｽﾄの列
        Else
            intSelectRow = grdList.SelectedCells(0).RowIndex             'ﾘｽﾄの行
            intSelectCol = grdList.SelectedCells(0).ColumnIndex          'ﾘｽﾄの列
        End If

        Dim intScrollX, intScrollY As Integer
        intScrollX = grdList.HorizontalScrollingOffset           'ｽｸﾛｰﾙﾊﾞｰ位置　横
        intScrollY = grdList.FirstDisplayedScrollingRowIndex     'ｽｸﾛｰﾙﾊﾞｰ位置　縦

        Try
            objPoint = Nothing
            objPoint = New Point(intScrollX, intScrollY)    'ｽｸﾛｰﾙﾊﾞｰ位置　
        Catch ex As Exception
            intSelectRow = -1                  'ﾘｽﾄの行
            intSelectCol = -1                  'ﾘｽﾄの列
            objPoint = New Point(0, 0)         'ｽｸﾛｰﾙﾊﾞｰ位置　
        End Try

        Call gobjComFuncFRM.TblDataGridDisplay(grdList, strSQL, False, intSelectRow, intSelectCol, objPoint)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()

        If grdList.RowCount > 0 Then
            '(表示ﾃﾞｰﾀありの時)
            grdList.HorizontalScrollingOffset = objPoint.X               'ｽｸﾛｰﾙﾊﾞｰ位置　横
            If 0 <= objPoint.Y Then
                grdList.FirstDisplayedScrollingRowIndex = objPoint.Y     'ｽｸﾛｰﾙﾊﾞｰ位置　縦
            End If
            Call gobjComFuncFRM.GridSelect(grdList, intSelectRow, 7, objPoint)                'ｸﾞﾘｯﾄﾞ選択処理
        Else
            '(表示ﾃﾞｰﾀなしの時)
            Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)       'ｸﾞﾘｯﾄﾞ選択処理
        End If

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

        'grdList.MultiSelect = False
        'grdList.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        grdList.MyBeseDoubleBuffered = True                                                                 'ちらつき防止

        For Each objColum As DataGridViewColumn In grdList.Columns
            objColum.SortMode = DataGridViewColumnSortMode.NotSortable                                      '列の並替禁止
        Next

        '↓↓↓↓ 2012.11.28 13:30 H.Morita 配送先名の表示
        'grdList.Columns(menmListCol.XSYUKKA_STS).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill         '列幅自動調節
        'grdList.AllowUserToResizeColumns = False                                                            '列のｻｲｽﾞ変更禁止
        '↑↑↑↑ 2012.11.28 13:30 H.Morita 配送先名の表示


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


            Case menmCheckCase.BerthKaihouBtn_Click
                '(ﾊﾞｰｽ解放ﾎﾞﾀﾝｸﾘｯｸ時)


                '===============================================================================
                ' 出荷状況が、未[自動倉庫から搬出予約あり]、出庫中の時は、ﾊﾞｰｽ開放できないﾁｪｯｸ
                '===============================================================================
                Dim strSQL As String                    'SQL文

                Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
                Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
                Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

                '-----------------------
                '抽出SQL作成
                '-----------------------
                strSQL = ""
                strSQL &= vbCrLf & " SELECT "
                strSQL &= vbCrLf & "       XRST_OUT.XSYUKKA_NO "                        '出荷実績.   出荷№(非表示)
                strSQL &= vbCrLf & "     , XRST_OUT.XPLN_DTL_NO "                       '出荷実績.   計画明細№(非表示)
                strSQL &= vbCrLf & "     , XRST_OUT.FHINMEI_CD "                        '出荷実績.   品名ｺｰﾄﾞ
                strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                          '品目ﾏｽﾀ.    品名
                strSQL &= vbCrLf & "     , XRST_OUT.XSEIZOU_DT "                        '出荷実績.   製造年月日
                strSQL &= vbCrLf & "     , XRST_OUT.XLINE_NO "                          '出荷実績.   ﾗｲﾝ№
                strSQL &= vbCrLf & "     , XRST_OUT.XPALLET_NO "                        '出荷実績.   ﾊﾟﾚｯﾄ№
                strSQL &= vbCrLf & "     , XRST_OUT.XKENPIN_FLAG "                      '出荷実績.   検品済ﾌﾗｸﾞ
                strSQL &= vbCrLf & "     , (CASE XRST_OUT.XKENPIN_FLAG"
                strSQL &= vbCrLf & "          WHEN " & XKENPIN_FLAG_JON & " THEN '検品完了'"
                strSQL &= vbCrLf & "          WHEN " & XKENPIN_FLAG_JKYOUSEI & " THEN '強制完了'"
                strSQL &= vbCrLf & "          ELSE "
                strSQL &= vbCrLf & "           (CASE TPRG_TRK_BUF.FTRK_BUF_NO"
                strSQL &= vbCrLf & "             WHEN " & FTRK_BUF_NO_J2002 & " THEN '出庫中' "
                strSQL &= vbCrLf & "             WHEN NVL(TMST_TRK.XTRK_BUF_NO_OUT_HIRA, TMST_TRK.FTRK_BUF_NO) THEN '出庫完' "
                strSQL &= vbCrLf & "             ELSE '未' "
                strSQL &= vbCrLf & "            END) "
                strSQL &= vbCrLf & "        END) AS XSYUKKA_STS_DSP "                  '            出荷状況(表示用)

                strSQL &= vbCrLf & "     , (CASE XRST_OUT.XKENPIN_FLAG"
                strSQL &= vbCrLf & "          WHEN " & XKENPIN_FLAG_JON & " THEN '3'"
                strSQL &= vbCrLf & "          WHEN " & XKENPIN_FLAG_JKYOUSEI & " THEN '4'"
                strSQL &= vbCrLf & "          ELSE "
                strSQL &= vbCrLf & "           (CASE TPRG_TRK_BUF.FTRK_BUF_NO"
                strSQL &= vbCrLf & "             WHEN " & FTRK_BUF_NO_J2002 & " THEN '1' "
                strSQL &= vbCrLf & "             WHEN NVL(TMST_TRK.XTRK_BUF_NO_OUT_HIRA, TMST_TRK.FTRK_BUF_NO) THEN '2' "
                strSQL &= vbCrLf & "             ELSE '0' "
                strSQL &= vbCrLf & "            END) "
                strSQL &= vbCrLf & "        END) AS XSYUKKA_STS "                       '            出荷状況

                strSQL &= vbCrLf & "     , XRST_OUT.XSYUKKA_KENPIN_VOL "                '出荷実績.   出荷検品数(非表示)

                '============================================================
                'FROM
                '============================================================
                strSQL &= vbCrLf & " FROM "
                strSQL &= vbCrLf & "       XPLN_OUT "
                strSQL &= vbCrLf & "     , XRST_OUT "
                strSQL &= vbCrLf & "     , TMST_ITEM "
                strSQL &= vbCrLf & "     , TMST_TRK "
                strSQL &= vbCrLf & "     , TPRG_TRK_BUF "

                '============================================================
                'WHERE
                '============================================================
                strSQL &= vbCrLf & " WHERE 0 = 0 "
                strSQL &= vbCrLf & "     AND XRST_OUT.FHINMEI_CD  = TMST_ITEM.FHINMEI_CD(+) "         '品名ｺｰﾄﾞ
                strSQL &= vbCrLf & "     AND XRST_OUT.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
                'strSQL &= vbCrLf & "     AND XRST_OUT.FPALLET_ID  = TPRG_TRK_BUF.FPALLET_ID(+) "
                strSQL &= vbCrLf & "     AND NVL(XRST_OUT.XPALLET_ID_CHECK, XRST_OUT.XPALLET_ID_KARI) = TPRG_TRK_BUF.FPALLET_ID(+) "
                strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO  = XRST_OUT.XSYUKKA_NO "             '出荷№
                strSQL &= vbCrLf & "     AND XRST_OUT.FTRK_BUF_NO    IN(" & FTRK_BUF_NO_J1
                strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J2
                strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J3
                strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J4
                strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J5
                strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J6
                strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J7
                strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8
                strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8000
                strSQL &= vbCrLf & "                                   ) "

                'strSQL &= vbCrLf & "      AND XPLN_OUT.XWARITUKE_DT = ( "
                strSQL &= vbCrLf & "      AND XPLN_OUT.XWARITUKE_DT IN ( "
                'strSQL &= vbCrLf & "                                   SELECT "
                ''strSQL &= vbCrLf & "                                      MAX(XPLN_OUT.XWARITUKE_DT) "
                'strSQL &= vbCrLf & "                                      XPLN_OUT.XWARITUKE_DT "
                'strSQL &= vbCrLf & "                                   FROM "
                'strSQL &= vbCrLf & "                                      XPLN_OUT "
                'strSQL &= vbCrLf & "                                   WHERE 1 = 1 "
                ''strSQL &= vbCrLf & "                                    AND XPLN_OUT.XCAR_NO_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_WARITUKE & "' "
                ''strSQL &= vbCrLf & "                                    AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE & "' "
                'strSQL &= vbCrLf & "                                    AND XPLN_OUT.XCAR_NO_DAIHYOU = '" & mudtSEARCH_ITEM.XCAR_NO_DAIHYOU & "' "
                'strSQL &= vbCrLf & "                                    AND XPLN_OUT.XCAR_NO_EDA_DAIHYOU = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_DAIHYOU & "' "

                strSQL &= vbCrLf & "                                   SELECT "
                strSQL &= vbCrLf & "                                        XWARITUKE_DT "
                strSQL &= vbCrLf & "                                   FROM "
                strSQL &= vbCrLf & "                                       ( "
                strSQL &= vbCrLf & "                                        SELECT "
                strSQL &= vbCrLf & "                                           XPLN_OUT.XCAR_NO_EDA_WARITUKE "
                strSQL &= vbCrLf & "                                         , MAX(XPLN_OUT.XWARITUKE_DT) AS XWARITUKE_DT "
                strSQL &= vbCrLf & "                                        FROM "
                strSQL &= vbCrLf & "                                           XPLN_OUT "
                strSQL &= vbCrLf & "                                        WHERE 1 = 1 "
                strSQL &= vbCrLf & "                                          AND XPLN_OUT.XCAR_NO_DAIHYOU     = '" & mudtSEARCH_ITEM.XCAR_NO_DAIHYOU & "' "
                strSQL &= vbCrLf & "                                          AND XPLN_OUT.XCAR_NO_EDA_DAIHYOU = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_DAIHYOU & "' "
                strSQL &= vbCrLf & "                                        GROUP BY "
                strSQL &= vbCrLf & "                                           XPLN_OUT.XCAR_NO_EDA_WARITUKE "
                strSQL &= vbCrLf & "                                       ) AA "

                strSQL &= vbCrLf & "                                  ) "

                '----------------------------------------------
                '代表車番
                '----------------------------------------------
                'If mudtSEARCH_ITEM.XCAR_NO_WARITUKE <> CBO_ALL_VALUE Then
                '    '(全検索以外の場合)
                '    strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_WARITUKE & "' "
                'End If
                If mudtSEARCH_ITEM.XCAR_NO_DAIHYOU <> CBO_ALL_VALUE Then
                    '(全検索以外の場合)
                    strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_DAIHYOU = '" & mudtSEARCH_ITEM.XCAR_NO_DAIHYOU & "' "
                End If

                '----------------------------------------------
                '代表車版枝番
                '----------------------------------------------
                'If mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE <> CBO_ALL_VALUE Then
                '    '(全検索以外の場合)
                '    strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE & "' "
                'End If
                If mudtSEARCH_ITEM.XCAR_NO_EDA_DAIHYOU <> CBO_ALL_VALUE Then
                    '(全検索以外の場合)
                    strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_EDA_DAIHYOU = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_DAIHYOU & "' "
                End If

                '-----------------------
                '抽出
                '-----------------------
                gobjDb.SQL = strSQL
                objDataSet.Clear()
                strDataSetName = "XRST_OUT"
                gobjDb.GetDataSet(strDataSetName, objDataSet)

                If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                    '(読めたとき)
                    For Each objRow In objDataSet.Tables(strDataSetName).Rows

                        '↓↓↓↓↓ H.Morita 2012.11.01 ﾄﾗｯｷﾝｸﾞﾒﾝﾃで削除したときに、出庫中でも、ﾊﾞｰｽ解放できるようにする対応。ﾁｪｯｸを外す
                        'If (TO_STRING(objRow("XSYUKKA_STS")) = "0") Or _
                        '   (TO_STRING(objRow("XSYUKKA_STS")) = "1") Then
                        '    '(出荷状況が、未[自動倉庫から搬出予約あり]、出庫中の時)
                        '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308020_06, PopupFormType.Ok, PopupIconType.Information)
                        '    blnCheckErr = True
                        '    Exit Select
                        'End If
                        '↑↑↑↑↑ H.Morita 2012.11.01 ﾄﾗｯｷﾝｸﾞﾒﾝﾃで削除したときに、出庫中でも、ﾊﾞｰｽ解放できるようにする対応。ﾁｪｯｸを外す

                    Next
                End If


                '================================================
                'ﾊﾞｰｽ平置き場に在庫なければ、ﾊﾞｰｽ開放可能のﾁｪｯｸ
                '================================================
                Dim objTMST_TRK As New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ
                objTMST_TRK.FTRK_BUF_NO = gstrXBERTH_NO                                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(ﾊﾞｰｽ№)
                objTMST_TRK.GET_TMST_TRK(True)

                Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
                objTPRG_TRK_BUF.FTRK_BUF_NO = objTMST_TRK.XTRK_BUF_NO_OUT_HIRA                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(ﾊﾞﾗ平置き場)
                objTPRG_TRK_BUF.FRES_KIND = FRES_KIND_SZAIKO                                  '引当状態 = 「実在庫」
                If objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_COUNT() > 0 Then
                    '(読めた時。ﾊﾞｰｽ平置きに在庫がある時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308020_07, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                blnCheckErr = False



            Case menmCheckCase.ManualKenpinBtn_Click
                '(ﾏﾆｭｱﾙ検品ﾎﾞﾀﾝｸﾘｯｸ時)

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
                '出荷状況 ﾁｪｯｸ
                '==========================
                If TO_STRING(grdList.Item(menmListCol.XSYUKKA_STS, grdList.SelectedRows(0).Index).Value) = "1" Then
                    '(出庫中の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308020_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If

                If TO_STRING(grdList.Item(menmListCol.XSYUKKA_STS, grdList.SelectedRows(0).Index).Value) = "3" Then
                    '(検品完了の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308020_02, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If

                If TO_STRING(grdList.Item(menmListCol.XSYUKKA_STS, grdList.SelectedRows(0).Index).Value) = "4" Then
                    '(強制完了の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308020_03, PopupFormType.Ok, PopupIconType.Information)
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
    Private Sub SetProperty(ByVal objForm As FRM_308021)

        objForm.userXBERTH_NO = gstrXBERTH_NO                                                                                                 'ﾊﾞｰｽ№
        objForm.userXSYUKKA_NO = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NO, grdList.SelectedRows(0).Index).Value)                         '出荷№
        '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        objForm.userXPLN_DTL_NO = TO_STRING(grdList.Item(menmListCol.XPLN_DTL_NO, grdList.SelectedRows(0).Index).Value)                       '出荷明細№
        '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        objForm.userXCAR_NO_WARITUKE = TO_STRING(grdList.Item(menmListCol.XCAR_NO_WARITUKE, grdList.SelectedRows(0).Index).Value)             '受付車番
        objForm.userXCAR_NO_EDA_WARITUKE = TO_STRING(grdList.Item(menmListCol.XCAR_NO_EDA_WARITUKE, grdList.SelectedRows(0).Index).Value)     '枝番
        objForm.userXNYUKA_JIGYOU_NM = TO_STRING(grdList.Item(menmListCol.XNYUKA_JIGYOU_NM, grdList.SelectedRows(0).Index).Value)             '配送先

        objForm.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, grdList.SelectedRows(0).Index).Value)                                                                                              'ﾊﾞｰｽ№
        objForm.userFTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value)                                                                                              'ﾊﾞｰｽ№
        objForm.userXSEIZOU_DT = TO_STRING(grdList.Item(menmListCol.XSEIZOU_DT, grdList.SelectedRows(0).Index).Value)                                                                                              'ﾊﾞｰｽ№

    End Sub
#End Region
#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(ﾏﾆｭｱﾙ検品(旧 FRM_308030))     "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty2(ByVal objForm As FRM_308030)

        objForm.userFTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(出庫場所)
        objForm.userFBUF_NAME = TO_STRING(grdList.Item(menmListCol.FBUF_NAME, grdList.SelectedRows(0).Index).Value)     '出庫場所
        objForm.userXSYUKKA_NO = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NO, grdList.SelectedRows(0).Index).Value)   '出荷№
        objForm.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, grdList.SelectedRows(0).Index).Value)   '品名ｺｰﾄﾞ
        objForm.userXSEIZOU_DT = TO_STRING(grdList.Item(menmListCol.XSEIZOU_DT, grdList.SelectedRows(0).Index).Value)   '製造年月日
        objForm.userXCAR_NO_WARITUKE = TO_STRING(grdList.Item(menmListCol.XCAR_NO_WARITUKE, grdList.SelectedRows(0).Index).Value)          '受付車番
        objForm.userXCAR_NO_EDA_WARITUKE = TO_STRING(grdList.Item(menmListCol.XCAR_NO_EDA_WARITUKE, grdList.SelectedRows(0).Index).Value)  '受付車番枝番

    End Sub
#End Region
#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(ﾏﾆｭｱﾙ検品(FRM_308160))        "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty3(ByVal objForm As FRM_308160)

        objForm.userFTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(出庫場所)
        objForm.userFBUF_NAME = TO_STRING(grdList.Item(menmListCol.FBUF_NAME, grdList.SelectedRows(0).Index).Value)     '出庫場所
        objForm.userXSYUKKA_NO = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NO, grdList.SelectedRows(0).Index).Value)   '出荷№
        '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        objForm.userXPLN_DTL_NO = TO_STRING(grdList.Item(menmListCol.XPLN_DTL_NO, grdList.SelectedRows(0).Index).Value) '出荷明細№
        '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        objForm.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, grdList.SelectedRows(0).Index).Value)   '品名ｺｰﾄﾞ
        objForm.userXSEIZOU_DT = TO_STRING(grdList.Item(menmListCol.XSEIZOU_DT, grdList.SelectedRows(0).Index).Value)   '製造年月日
        objForm.userXCAR_NO_WARITUKE = TO_STRING(grdList.Item(menmListCol.XCAR_NO_WARITUKE, grdList.SelectedRows(0).Index).Value)          '受付車番
        objForm.userXCAR_NO_EDA_WARITUKE = TO_STRING(grdList.Item(menmListCol.XCAR_NO_EDA_WARITUKE, grdList.SelectedRows(0).Index).Value)  '受付車番枝番

    End Sub
#End Region

#Region "  表示更新ﾀｲﾏｰ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示更新ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr308020_TickProcess()

        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region

#Region "  ｿｹｯﾄ送信01 (ﾊﾞｰｽ解放)                  　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function SendSocket01() As Boolean

        Dim blnRet As Boolean = False

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308020_04, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        ''********************************************************************
        '' ﾃﾞｰﾀｾｯﾄ
        ''********************************************************************

        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        Dim strDSPTRK_BUF_NO As String = ""                'ﾊﾞｯﾌｬ№

        strDSPTRK_BUF_NO = gstrXBERTH_NO                   'ﾊﾞｯﾌｬ№

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400705       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strDSPTRK_BUF_NO)        'ﾊﾞｯﾌｬ№  

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                        'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = FRM_MSG_FRM308020_05
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            Else
                '(処理が異常終了した場合)
                strErrMsg = FRM_MSG_FRM308020_05
                Call gobjComFuncFRM.DisplayPopup(strErrMsg, PopupFormType.Ok, PopupIconType.Err)
            End If
        End If

        Return blnRet

    End Function
#End Region

End Class
