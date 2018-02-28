'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】棚状態問合せ
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
Imports GamenCommon
#End Region

Public Class FRM_304070

#Region "　定数    　                       "

    ''' <summary>製品</summary>
    Private Const GRID_DSP_ARTICLE_J01 As String = "●"             '製品
    ''' <summary>包材</summary>
    Private Const GRID_DSP_ARTICLE_J03 As String = "▲"             '包材
    ''' <summary>中間品</summary>
    Private Const GRID_DSP_ARTICLE_J02 As String = "▼"             '中間品
    ''' <summary>その他</summary>
    Private Const GRID_DSP_ARTICLE_J09 As String = "■"             'その他
    ''' <summary>製品(保留)</summary>
    Private Const GRID_DSP_ARTICLE_J01_HORYU As String = "○"       '製品(保留)
    ''' <summary>包材(保留)</summary>
    Private Const GRID_DSP_ARTICLE_J03_HORYU As String = "△"       '包材(保留)
    ''' <summary>中間品(保留)</summary>
    Private Const GRID_DSP_ARTICLE_J02_HORYU As String = "▽"       '中間品(保留)
    ''' <summary>その他(保留)</summary>
    Private Const GRID_DSP_ARTICLE_J09_HORYU As String = "□"       'その他(保留)
    ''' <summary>空棚</summary>
    Private Const GRID_DSP_RES_KIND_SAKI As String = ""             '空棚
    ''' <summary>禁止棚</summary>
    Private Const GRID_DSP_REMOVE_KIND_SON As String = "×"         '禁止棚
    ''' <summary>無効棚</summary>
    Private Const GRID_DSP_REMOVE_KIND_SNON As String = "－"        '無効棚
    ''' <summary>予約棚</summary>
    Private Const GRID_DSP_RES_KIND_SRSV_TRNS_IN As String = "★"   '予約棚

#End Region
#Region "　共通変数　                       "

    ''' <summary>ﾃﾞﾌｫﾙﾄｶﾗｰ ｸﾞﾘｯﾄﾞﾀｲﾄﾙ</summary>
    Private DEFAULT_COLOR_GRID_TITLE_BACKCOLOR As Color = Color.FromArgb(32, 32, 234)
    ''' <summary>ﾃﾞﾌｫﾙﾄｶﾗｰ ｸﾞﾘｯﾄﾞﾀｲﾄﾙ文字</summary>
    Private DEFAULT_COLOR_GRID_TITLE_FONT As Color = Color.FromArgb(255, 241, 15)
    ''' <summary>ﾃﾞﾌｫﾙﾄｶﾗｰ ｸﾞﾘｯﾄﾞ背景</summary>
    Private DEFAULT_COLOR_GRID_BACKCOLOR As Color = Color.White
    ''' <summary>ﾃﾞﾌｫﾙﾄｶﾗｰ ｸﾞﾘｯﾄﾞ枠線</summary>
    Private DEFAULT_COLOR_GRID_BORDER As Color = Color.Gray
    ''' <summary>ﾃﾞﾌｫﾙﾄｶﾗｰ 文字</summary>
    Private DEFAULT_COLOR_GRID_DSP_FONT As Color = Color.Black


    ''' <summary>製品</summary>
    Private mCOLOR_ARTICLE_J01 As Color
    ''' <summary>包材</summary>
    Private mCOLOR_ARTICLE_J03 As Color
    ''' <summary>中間品</summary>
    Private mCOLOR_ARTICLE_J02 As Color
    ''' <summary>その他</summary>
    Private mCOLOR_ARTICLE_J09 As Color
    ''' <summary>製品(保留)</summary>
    Private mCOLOR_ARTICLE_J01_HORYU As Color
    ''' <summary>包材(保留)</summary>
    Private mCOLOR_ARTICLE_J03_HORYU As Color
    ''' <summary>中間品(保留)</summary>
    Private mCOLOR_ARTICLE_J02_HORYU As Color
    ''' <summary>その他(保留)</summary>
    Private mCOLOR_ARTICLE_J09_HORYU As Color
    ''' <summary>禁止棚</summary>
    Private mCOLOR_REMOVE_KIND_SON As Color
    ''' <summary>無効棚</summary>
    Private mCOLOR_REMOVE_KIND_SNON As Color
    ''' <summary>予約棚</summary>
    Private mCOLOR_RES_KIND_SRSV_TRNS_IN As Color

    ''' <summary>ｸﾞﾘｯﾄﾞ背景</summary>
    Private mCOLOR_GRID_BACKGROUND As Color
    ''' <summary>ｸﾞﾘｯﾄﾞ枠線</summary>
    Private mCOLOR_GRID_BORDER As Color
    ''' <summary>ｸﾞﾘｯﾄﾞﾀｲﾄﾙ背景</summary>
    Private mCOLOR_GRID_TITLE_BACKGROUND As Color
    ''' <summary>ｸﾞﾘｯﾄﾞﾀｲﾄﾙ文字</summary>
    Private mCOLOR_GRID_TITLE_FONT As Color


    Private mudtSEARCH_ITEM As New stcSEARCH_ITEM           '検索条件用構造体
    Private mudtSEARCH_ITEM2 As New stcSEARCH_ITEM2         '検索条件用構造体

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        REN1_F                        '連1_F
        REN1_B                        '連1_B
        REN2_F                        '連2_F
        REN2_B                        '連2_B
        REN3_F                        '連3_F
        REN3_B                        '連3_B
        REN4_F                        '連4_F
        REN4_B                        '連4_B
        REN5_F                        '連5_F
        REN5_B                        '連5_B
        REN6_F                        '連6_F
        REN6_B                        '連6_B
        REN7_F                        '連7_F
        REN7_B                        '連7_B
        REN8_F                        '連8_F
        REN8_B                        '連8_B
        REN9_F                        '連9_F
        REN9_B                        '連9_B
        REN10_F                       '連10_F
        REN10_B                       '連10_B
        REN11_F                       '連11_F
        REN11_B                       '連11_B
        REN12_F                       '連12_F
        REN12_B                       '連12_B
        REN13_F                       '連13_F
        REN13_B                       '連13_B
        REN14_F                       '連14_F
        REN14_B                       '連14_B
        REN15_F                       '連15_F
        REN15_B                       '連15_B
        REN16_F                       '連16_F
        REN16_B                       '連16_B
        REN17_F                       '連17_F
        REN17_B                       '連17_B
        REN18_F                       '連18_F
        REN18_B                       '連18_B
        REN19_F                       '連19_F
        REN19_B                       '連19_B
        REN20_F                       '連20_F
        REN20_B                       '連20_B
        REN21_F                       '連21_F
        REN21_B                       '連21_B
        REN22_F                       '連22_F
        REN22_B                       '連22_B
        REN23_F                       '連23_F
        REN23_B                       '連23_B
        REN24_F                       '連24_F
        REN24_B                       '連24_B
        REN25_F                       '連25_F
        REN25_B                       '連25_B
        REN26_F                       '連26_F
        REN26_B                       '連26_B
        REN27_F                       '連27_F
        REN27_B                       '連27_B
        REN28_F                       '連28_F
        REN28_B                       '連28_B
        REN29_F                       '連29_F
        REN29_B                       '連29_B
        REN30_F                       '連30_F
        REN30_B                       '連30_B
        REN31_F                       '連31_F
        REN31_B                       '連31_B
        REN32_F                       '連32_F
        REN32_B                       '連32_B

        MAXCOL                      'ｸﾞﾘｯﾄﾞの列数の最大値
    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol2
        FTRK_BUF_NO                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        FTRK_BUF_ARRAY              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              配列№
        FLOT_NO_STOCK               '在庫情報.                  在庫ﾛｯﾄ№
        FRAC_RETU                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚列
        FRAC_REN                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚連
        FRAC_DAN                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚段
        FRAC_EDA                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              枝番
        FDISP_ADDRESS               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              表記用ｱﾄﾞﾚｽ
        XHINMEI_CD                  '品目ﾏｽﾀ.                   品目ｺｰﾄﾞ
        FHINMEI_CD                  '在庫情報.                  品名ｺｰﾄﾞ(品名記号)
        FHINMEI                     '品目ﾏｽﾀ.                   品名
        XPROD_LINE                  '在庫情報.                  生産ﾗｲﾝ№
        XPROD_LINE_DSP              '在庫情報.                  生産ﾗｲﾝ№   (表示用)
        FTR_VOL                     '在庫情報.                  搬送管理量(数量)
        FARRIVE_DT                  '在庫情報.                  在庫発生日時
        XARTICLE_TYPE_CODE          '品目ﾏｽﾀ.                   商品区分
        XARTICLE_TYPE_CODE_DSP      '品目ﾏｽﾀ.                   商品区分(表示用)
        XKENSA_KUBUN                '在庫情報.                  検査区分
        XKENSA_KUBUN_DSP            '在庫情報.                  検査区分(表示用)
        FHORYU_KUBUN                '在庫情報.                  保留区分
        FHORYU_KUBUN_DSP            '在庫情報.                  保留区分(表示用)
        XKENPIN_KUBUN               '在庫情報.                  検品区分
        XKENPIN_KUBUN_DSP           '在庫情報.                  検品区分(表示用)
        FIN_KUBUN                   '在庫情報.                  入庫区分
        FIN_KUBUN_DSP               '在庫情報.                  入庫区分(表示用)
        XMAKER_CD                   '在庫情報.			        ﾒｰｶ-ｺｰﾄﾞ
        FLOT_NO                     '在庫情報.                  ﾛｯﾄ№
        FPALLET_ID                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              ﾊﾟﾚｯﾄID
        FRES_KIND                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              引当状態
        FRES_KIND_DSP               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              引当状態(表示用)

        MAXCOL                      'ｸﾞﾘｯﾄﾞの列数の最大値
    End Enum

#End Region
#Region "  構造体定義　                     "
    ''' <summary>検索条件</summary>
    Private Structure stcSEARCH_ITEM
        Dim FTRK_BUF_NO As String   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        Dim FRAC_RETU As String     '列
    End Structure

    ''' <summary>検索条件</summary>
    Private Structure stcSEARCH_ITEM2
        Dim FTRK_BUF_NO As String   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        Dim FRAC_RETU As String     '列
        Dim FRAC_REN As String      '連
        Dim FRAC_DAN As String      '段
        Dim FRAC_EDA As String      '枝

    End Structure

#End Region
#Region "　ｲﾍﾞﾝﾄ　                          "
#Region "　ﾀﾌﾞｺﾝﾄﾛｰﾙ ﾀﾌﾞﾁｪﾝｼﾞｲﾍﾞﾝﾄ　        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾀﾌﾞｺﾝﾄﾛｰﾙ ﾀﾌﾞﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tbcTRK_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbcTRK.SelectedIndexChanged
        Try
            If mFlag_Form_Load = False Then

                Call tbcTRK_TabIndexChangeProcess()

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ ｾﾚｸﾄﾁｪﾝｼﾞｲﾍﾞﾝﾄ　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ ｾﾚｸﾄﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.SelectionChanged
        Try
            If mFlag_Form_Load = False Then

                Call grdList_SelChangeProcess()

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                       "
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
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '場所がない為、時間非表示
        lblTime.Visible = False

        tbcTRK.SelectedIndex = 0                                '1列目選択

        '*********************************************
        ' 色取得
        '*********************************************
        Call getColor()
        'ﾗﾍﾞﾙ色設定
        Me.lblARTICLE_J01.ForeColor = mCOLOR_ARTICLE_J01                        '製品
        Me.lblARTICLE_J03.ForeColor = mCOLOR_ARTICLE_J03                        '包材
        Me.lblARTICLE_J02.ForeColor = mCOLOR_ARTICLE_J02                        '中間品
        Me.lblARTICLE_J09.ForeColor = mCOLOR_ARTICLE_J09                        'その他
        Me.lblARTICLE_J01_HORYU.ForeColor = mCOLOR_ARTICLE_J01_HORYU            '製品(保留)
        Me.lblARTICLE_J03_HORYU.ForeColor = mCOLOR_ARTICLE_J03_HORYU            '包材(保留)
        Me.lblARTICLE_J02_HORYU.ForeColor = mCOLOR_ARTICLE_J02_HORYU            '中間品(保留)
        Me.lblARTICLE_J09_HORYU.ForeColor = mCOLOR_ARTICLE_J09_HORYU            'その他(保留)
        Me.lblREMOVE_KIND_SNON.ForeColor = mCOLOR_REMOVE_KIND_SNON              '禁止棚
        Me.lblREMOVE_KIND_SON.ForeColor = mCOLOR_REMOVE_KIND_SON                '無効棚
        Me.lblRES_KIND_SRSV_TRNS_IN.ForeColor = mCOLOR_RES_KIND_SRSV_TRNS_IN    '予約棚

        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListDisplaySub(grdList)

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化(詳細)
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList2, 1, menmListCol2.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup2()

        '**********************************************************
        ' ｺﾝﾄﾛｰﾙ初期化
        '**********************************************************
        mFlag_Form_Load = False


    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                       "
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
        grdList.Dispose()                   'ｸﾞﾘｯﾄﾞ
        grdList2.Dispose()                  'ｸﾞﾘｯﾄﾞ
        txtFRES_KIND.Dispose()              '棚状態ﾃｷｽﾄ

    End Sub
#End Region
#Region "  F1(再表示)   ﾎﾞﾀﾝ押下処理        "
    '*******************************************************************************************************************
    '【機能】F1  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F1Process()

        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示(詳細)
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList2, 1, menmListCol2.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup2()

        '棚状態
        Me.lblFRES_KIND.Text = ""

    End Sub
#End Region
#Region "　構造体ｾｯﾄ(一覧)　                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set()

        '***********************************************
        '検索条件をｾｯﾄ
        '***********************************************
        mudtSEARCH_ITEM.FTRK_BUF_NO = FTRK_BUF_NO_J9000             '保管場所(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№)
        mudtSEARCH_ITEM.FRAC_RETU = tbcTRK.SelectedTab.Tag          '列

    End Sub
#End Region
#Region "　構造体ｾｯﾄ(詳細)　                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set2()

        '***********************************************
        '検索条件をｾｯﾄ
        '***********************************************
        mudtSEARCH_ITEM2.FTRK_BUF_NO = FTRK_BUF_NO_J9000            '保管場所(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№)
        mudtSEARCH_ITEM2.FRAC_RETU = tbcTRK.SelectedTab.Tag         '列

        Dim intDan As Integer = 12 - grdList.SelectedCells(0).RowIndex
        mudtSEARCH_ITEM2.FRAC_DAN = intDan.ToString                 '段

        Dim intRen As Integer = Math.Floor(grdList.SelectedCells(0).ColumnIndex / 2) + 1
        Dim intEda As Integer = grdList.SelectedCells(0).ColumnIndex Mod 2

        mudtSEARCH_ITEM2.FRAC_REN = intRen.ToString                 '連
        mudtSEARCH_ITEM2.FRAC_EDA = intEda.ToString                 '枝
    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示(一覧)                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        Dim strSQL As String                        'SQL文
        Dim objDataSet As New DataSet               'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow                       '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataTable As New clsGridDataTable70  'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        '********************************************************************
        ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ取得
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     TPRG_TRK_BUF.FRAC_RETU "               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚列
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FRAC_REN "                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚連
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FRAC_DAN "                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚段
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FRAC_EDA "                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚枝番
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FRES_KIND "               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              引当状態
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FREMOVE_KIND "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              禁止有無
        strSQL &= vbCrLf & "   , TRST_STOCK.FHORYU_KUBUN "              '在庫情報.                  保留区分
        strSQL &= vbCrLf & "   , TMST_ITEM.XARTICLE_TYPE_CODE "         '品目ﾏｽﾀ.                   品目種別(商品区分)

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TPRG_TRK_BUF "         '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ】
        strSQL &= vbCrLf & "   , TRST_STOCK "           '【在庫情報】
        strSQL &= vbCrLf & "   , TMST_ITEM "            '【品目ﾏｽﾀ】

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO = '" & TO_STRING(mudtSEARCH_ITEM.FTRK_BUF_NO) & "' "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FPALLET_ID  = TRST_STOCK.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TRST_STOCK.FHINMEI_CD  = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FRAC_RETU = " & TO_STRING(mudtSEARCH_ITEM.FRAC_RETU) & " "

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     TPRG_TRK_BUF.FRAC_RETU "           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚列
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FRAC_DAN DESC "       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚段
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FRAC_REN "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚連
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FRAC_EDA "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚枝番
        strSQL &= vbCrLf



        '============================================================
        '抽出
        '============================================================
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TPRG_TRK_BUF"
        gobjDb.GetDataSet(strDataSetName, objDataSet)


        Dim strGrdDspData(70) As String                     '表示ﾃﾞｰﾀ格納
        Dim intCnt As Integer = 0
        Dim strTempDan As String = ""
        Dim strDan As String = ""

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            'ﾃﾞｰﾀがあるとき
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                strTempDan = TO_STRING(objRow("FRAC_DAN"))
                If strDan = "" Then strDan = strTempDan

                If strDan <> strTempDan Then
                    '段が切り替わった場合
                    Call addRowDataSet(objDataTable, strGrdDspData)     '行追加
                    intCnt = 0
                    ReDim strGrdDspData(70)
                    strDan = strTempDan
                End If

                '------------------------------------------------------------
                '禁止有無
                '------------------------------------------------------------
                If TO_INTEGER(objRow("FREMOVE_KIND")) = FREMOVE_KIND_SON Then
                    '(禁止棚の場合)
                    strGrdDspData(intCnt) = GRID_DSP_REMOVE_KIND_SON
                ElseIf TO_INTEGER(objRow("FREMOVE_KIND")) = FREMOVE_KIND_SNON Then
                    '(無効棚の場合)
                    strGrdDspData(intCnt) = GRID_DSP_REMOVE_KIND_SNON
                Else
                    '(以外の場合)
                    '------------------------------------------------------------
                    '引当状態
                    '------------------------------------------------------------
                    If TO_INTEGER(objRow("FRES_KIND")) = FRES_KIND_SAKI Then
                        '(空棚の場合)
                        strGrdDspData(intCnt) = GRID_DSP_RES_KIND_SAKI
                    ElseIf TO_INTEGER(objRow("FRES_KIND")) = FRES_KIND_SRSV_TRNS_IN Then
                        '(予約棚の場合)
                        strGrdDspData(intCnt) = GRID_DSP_RES_KIND_SRSV_TRNS_IN
                    Else
                        '(以外の場合)
                        '------------------------------------------------------------
                        '保留区分＋品目種別
                        '------------------------------------------------------------
                        If TO_INTEGER(objRow("FHORYU_KUBUN")) = FHORYU_KUBUN_SHORYU Then
                            Select Case TO_INTEGER(objRow("XARTICLE_TYPE_CODE"))
                                Case XARTICLE_TYPE_CODE_J01
                                    '(製品)
                                    strGrdDspData(intCnt) = GRID_DSP_ARTICLE_J01_HORYU
                                Case XARTICLE_TYPE_CODE_J03
                                    '(包材)
                                    strGrdDspData(intCnt) = GRID_DSP_ARTICLE_J03_HORYU
                                Case XARTICLE_TYPE_CODE_J02
                                    '(中間品)
                                    strGrdDspData(intCnt) = GRID_DSP_ARTICLE_J02_HORYU
                                Case Else
                                    '(その他)
                                    strGrdDspData(intCnt) = GRID_DSP_ARTICLE_J09_HORYU
                            End Select
                        Else
                            Select Case TO_INTEGER(objRow("XARTICLE_TYPE_CODE"))
                                Case XARTICLE_TYPE_CODE_J01
                                    '(製品)
                                    strGrdDspData(intCnt) = GRID_DSP_ARTICLE_J01
                                Case XARTICLE_TYPE_CODE_J03
                                    '(包材)
                                    strGrdDspData(intCnt) = GRID_DSP_ARTICLE_J03
                                Case XARTICLE_TYPE_CODE_J02
                                    '(中間品)
                                    strGrdDspData(intCnt) = GRID_DSP_ARTICLE_J02
                                Case Else
                                    '(その他)
                                    strGrdDspData(intCnt) = GRID_DSP_ARTICLE_J09
                            End Select
                        End If
                    End If
                End If

                intCnt += 1
            Next

        End If

        Call addRowDataSet(objDataTable, strGrdDspData)     '最後の行を追加

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        grdList.Columns.Clear()
        Call gobjComFuncFRM.GridDisplay(objDataTable, grdList, True)
        objDataTable = Nothing

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)       'ｸﾞﾘｯﾄﾞ選択処理

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定(一覧)　           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup()

        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)

        '************************************************
        '行の高さ
        '************************************************
        If grdList.Rows.Count > 0 Then
            '(行があるとき)
            For ii As Integer = 0 To grdList.Rows.Count - 1
                grdList.Rows(ii).Height = 30
            Next
        End If

        '************************************************
        '列の背景色
        '************************************************
        If grdList.Rows.Count > 0 Then
            '(行があるとき)
            Dim chgFlg As Boolean = True
            For ii As Integer = 0 To grdList.Columns.Count - 1
                '4列単位で設定
                If (ii Mod 4) = 0 Then chgFlg = Not chgFlg
                If chgFlg = True Then
                    grdList.Columns(ii).DefaultCellStyle.BackColor = mCOLOR_GRID_BACKGROUND
                End If
            Next
        End If

        '************************************************
        '標準設定から変更
        '************************************************
        grdList.Font = New Font("ＭＳ ゴシック", 7, FontStyle.Bold)                 'ﾌｫﾝﾄ設定
        grdList.SelectionMode = DataGridViewSelectionMode.CellSelect                '選択ﾓｰﾄﾞ

        Call gobjComFuncFRM.GridSortModeSet(grdList, DataGridViewColumnSortMode.NotSortable)    '列の並替禁止

        grdList.MyBeseDoubleBuffered = True                                          'ちらつき防止

        grdList.AllowUserToResizeColumns = False                                    '列幅変更禁止
        grdList.AllowUserToOrderColumns = False                                     '列の移動禁止
        grdList.ColumnHeadersVisible = False                                        '列ﾍｯﾀﾞｰ非表示
        grdList.ScrollBars = ScrollBars.None                                        'ｽｸﾛｰﾙﾊﾞｰなし
        grdList.ReadOnly = True                                                     '読み取り専用

        '************************************************
        '色変更
        '************************************************
        'grdList.DefaultCellStyle.BackColor = mCOLOR_GRID_BACKGROUND                 ' ｸﾞﾘｯﾄﾞ背景色
        grdList.GridColor = mCOLOR_GRID_BORDER                                      ' ｸﾞﾘｯﾄﾞ枠線
        Call grdListSetTitleColor()                                                 ' ｸﾞﾘｯﾄﾞﾀｲﾄﾙ　色変更
        Call grdListSetCellColor()                                                  ' ｸﾞﾘｯﾄﾞｾﾙ文字色変更

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示(詳細)                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
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
        strSQL &= vbCrLf & "       TPRG_TRK_BUF.FTRK_BUF_NO "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FTRK_BUF_ARRAY "                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              配列№
        strSQL &= vbCrLf & "     , TRST_STOCK.FLOT_NO_STOCK "                       '在庫情報.                  在庫ﾛｯﾄ№
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_RETU "                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚列
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_REN "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚連
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_DAN "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚段
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_EDA "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              枝番
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FDISP_ADDRESS "                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              表記用ｱﾄﾞﾚｽ
        strSQL &= vbCrLf & "     , TMST_ITEM.XHINMEI_CD "                           '品目ﾏｽﾀ.                   品目ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , TRST_STOCK.FHINMEI_CD "                          '在庫情報.                  品名ｺｰﾄﾞ(品名記号)
        strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                              '品目ﾏｽﾀ.                   品名
        strSQL &= vbCrLf & "     , TRST_STOCK.XPROD_LINE "                          '在庫情報.                  生産ﾗｲﾝ№
        strSQL &= vbCrLf & "     , HASH01.XPROD_LINE_NAME AS XPROD_LINE_DSP "       '在庫情報.                  生産ﾗｲﾝ№   (表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.FTR_VOL "                             '在庫情報.                  搬送管理量(数量)
        strSQL &= vbCrLf & "     , TRST_STOCK.FARRIVE_DT "                          '在庫情報.                  在庫発生日時
        strSQL &= vbCrLf & "     , TMST_ITEM.XARTICLE_TYPE_CODE "                   '品目ﾏｽﾀ.                   商品区分
        strSQL &= vbCrLf & "     , HASH02.FGAMEN_DISP AS XARTICLE_TYPE_CODE_DSP "   '品目ﾏｽﾀ.                   商品区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.XKENSA_KUBUN "                        '在庫情報.                  検査区分
        strSQL &= vbCrLf & "     , HASH03.FGAMEN_DISP AS XKENSA_KUBUN_DSP "         '在庫情報.                  検査区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.FHORYU_KUBUN "                        '在庫情報.                  保留区分
        strSQL &= vbCrLf & "     , HASH04.FGAMEN_DISP AS FHORYU_KUBUN_DSP "         '在庫情報.                  保留区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.XKENPIN_KUBUN "                       '在庫情報.                  検品区分
        strSQL &= vbCrLf & "     , HASH05.FGAMEN_DISP AS XKENPIN_KUBUN_DSP "        '在庫情報.                  検品区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.FIN_KUBUN "                           '在庫情報.                  入庫区分
        strSQL &= vbCrLf & "     , HASH06.FGAMEN_DISP AS FIN_KUBUN_DSP "            '在庫情報.                  入庫区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.XMAKER_CD "                           '在庫情報.			        ﾒｰｶ-ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , TRST_STOCK.FLOT_NO "                             '在庫情報.                  ﾛｯﾄ№
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FPALLET_ID "                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRES_KIND "                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              引当状態
        strSQL &= vbCrLf & "     , HASH07.FGAMEN_DISP AS FRES_KIND_DSP "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              引当状態(表示用)

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "       TPRG_TRK_BUF "
        strSQL &= vbCrLf & "     , TMST_TRK "
        strSQL &= vbCrLf & "     , TRST_STOCK "
        strSQL &= vbCrLf & "     , TMST_ITEM "
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom02("HASH01", "XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", "TRST_STOCK", "XPROD_LINE")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TMST_ITEM", "XARTICLE_TYPE_CODE")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TRST_STOCK", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH05", "TRST_STOCK", "XKENPIN_KUBUN")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH06", "TRST_STOCK", "FIN_KUBUN")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH07", "TPRG_TRK_BUF", "FRES_KIND")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FPALLET_ID = TRST_STOCK.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TRST_STOCK.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "     AND TMST_TRK.FTRK_BUF_NO = TPRG_TRK_BUF.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere02("HASH01", "XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", "TRST_STOCK", "XPROD_LINE")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TMST_ITEM", "XARTICLE_TYPE_CODE")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TRST_STOCK", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH05", "TRST_STOCK", "XKENPIN_KUBUN")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH06", "TRST_STOCK", "FIN_KUBUN")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH07", "TPRG_TRK_BUF", "FRES_KIND")

        '----------------------------------------------
        '保管場所
        '----------------------------------------------
        strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = '" & TO_STRING(mudtSEARCH_ITEM2.FTRK_BUF_NO) & "' "

        '----------------------------------------------
        '列
        '----------------------------------------------
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRAC_RETU IN ( " & TO_STRING(mudtSEARCH_ITEM2.FRAC_RETU) & ") "

        '----------------------------------------------
        '連
        '----------------------------------------------
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRAC_REN IN ( " & TO_STRING(mudtSEARCH_ITEM2.FRAC_REN) & ") "

        '----------------------------------------------
        '段
        '----------------------------------------------
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRAC_DAN IN ( " & TO_STRING(mudtSEARCH_ITEM2.FRAC_DAN) & ") "

        '----------------------------------------------
        '枝番
        '----------------------------------------------
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRAC_EDA IN ( " & TO_STRING(mudtSEARCH_ITEM2.FRAC_EDA) & ") "

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList2)
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList2, strSQL, True)

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup2()
        Call gobjComFuncFRM.GridSelect(grdList2, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理


        '棚状態ｾｯﾄ
        txtFRES_KIND.Text = TO_STRING(grdList2.Item(menmListCol2.FRES_KIND_DSP, 0).Value)
        lblFRES_KIND.Text = TO_STRING(grdList2.Item(menmListCol2.FRES_KIND_DSP, 0).Value)

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定(詳細)             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup2()

        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList2)

    End Sub
#End Region
#Region "  ﾀﾌﾞ ｲﾝﾃﾞｯｸｽﾁｪﾝｼﾞ                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ ｾﾚｸﾄﾁｪﾝｼﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tbcTRK_TabIndexChangeProcess()

        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示(詳細)
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList2, 1, menmListCol2.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup2()

        '棚状態
        Me.lblFRES_KIND.Text = ""

    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ ｾﾚｸﾄﾁｪﾝｼﾞ                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ ｾﾚｸﾄﾁｪﾝｼﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_SelChangeProcess()

        If grdList.SelectedCells.Count < 1 Then Exit Sub

        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set2()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub2(grdList2)

    End Sub
#End Region
#Region "  ﾃﾞｰﾀｾｯﾄへ一行ﾃﾞｰﾀ追加            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｾｯﾄへ一行ﾃﾞｰﾀ追加
    ''' </summary>
    ''' <param name="strData">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃﾞｰﾀ配列</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub addRowDataSet(ByRef objDataTable As clsGridDataTable70, ByVal strData As String())

        ReDim Preserve strData(70)

        objDataTable.userAddRowDataSet( _
                                        strData(0) _
                                      , strData(1) _
                                      , strData(2) _
                                      , strData(3) _
                                      , strData(4) _
                                      , strData(5) _
                                      , strData(6) _
                                      , strData(7) _
                                      , strData(8) _
                                      , strData(9) _
                                      , strData(10) _
                                      , strData(11) _
                                      , strData(12) _
                                      , strData(13) _
                                      , strData(14) _
                                      , strData(15) _
                                      , strData(16) _
                                      , strData(17) _
                                      , strData(18) _
                                      , strData(19) _
                                      , strData(20) _
                                      , strData(21) _
                                      , strData(22) _
                                      , strData(23) _
                                      , strData(24) _
                                      , strData(25) _
                                      , strData(26) _
                                      , strData(27) _
                                      , strData(28) _
                                      , strData(29) _
                                      , strData(30) _
                                      , strData(31) _
                                      , strData(32) _
                                      , strData(33) _
                                      , strData(34) _
                                      , strData(35) _
                                      , strData(36) _
                                      , strData(37) _
                                      , strData(38) _
                                      , strData(39) _
                                      , strData(40) _
                                      , strData(41) _
                                      , strData(42) _
                                      , strData(43) _
                                      , strData(44) _
                                      , strData(45) _
                                      , strData(46) _
                                      , strData(47) _
                                      , strData(48) _
                                      , strData(49) _
                                      , strData(50) _
                                      , strData(51) _
                                      , strData(52) _
                                      , strData(53) _
                                      , strData(54) _
                                      , strData(55) _
                                      , strData(56) _
                                      , strData(57) _
                                      , strData(58) _
                                      , strData(59) _
                                      , strData(60) _
                                      , strData(61) _
                                      , strData(62) _
                                      , strData(63) _
                                      , strData(64) _
                                      , strData(65) _
                                      , strData(66) _
                                      , strData(67) _
                                      , strData(68) _
                                      , strData(69) _
                                      , strData(70) _
                                       )


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞﾀｲﾄﾙ  色変更　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞﾀｲﾄﾙ  色変更
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetTitleColor()

        Dim objLABEL As Control

        For Each objLABEL In pnlGridLst.Controls

            If objLABEL.GetType Is GetType(Label) Then

                objLABEL.BackColor = mCOLOR_GRID_TITLE_BACKGROUND
                objLABEL.ForeColor = mCOLOR_GRID_TITLE_FONT

            End If

        Next
    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞｾﾙ　文字色変更　           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｾﾙ　文字色変更
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetCellColor()


        '************************************************
        '色変更
        '************************************************
        If grdList.Rows.Count > 0 Then
            '(行があるとき)
            For ii As Integer = 0 To grdList.Rows.Count - 1
                For jj As Integer = 0 To grdList.Columns.Count - 1
                    If IsNull(grdList.Item(jj, ii).Value) = False Then
                        '(値がある場合)
                        Select Case grdList.Item(jj, ii).Value
                            Case GRID_DSP_ARTICLE_J01
                                '(製品)
                                grdList.Item(jj, ii).Style.ForeColor = mCOLOR_ARTICLE_J01

                            Case GRID_DSP_ARTICLE_J03
                                '(包材)
                                grdList.Item(jj, ii).Style.ForeColor = mCOLOR_ARTICLE_J03

                            Case GRID_DSP_ARTICLE_J02
                                '(中間品)
                                grdList.Item(jj, ii).Style.ForeColor = mCOLOR_ARTICLE_J02

                            Case GRID_DSP_ARTICLE_J09
                                '(その他)
                                grdList.Item(jj, ii).Style.ForeColor = mCOLOR_ARTICLE_J09

                            Case GRID_DSP_ARTICLE_J01_HORYU
                                '(製品(保留))
                                grdList.Item(jj, ii).Style.ForeColor = mCOLOR_ARTICLE_J01_HORYU

                            Case GRID_DSP_ARTICLE_J03_HORYU
                                '(包材(保留))
                                grdList.Item(jj, ii).Style.ForeColor = mCOLOR_ARTICLE_J03_HORYU

                            Case GRID_DSP_ARTICLE_J02_HORYU
                                '(中間品(保留))
                                grdList.Item(jj, ii).Style.ForeColor = mCOLOR_ARTICLE_J02_HORYU

                            Case GRID_DSP_ARTICLE_J09_HORYU
                                '(その他(保留))
                                grdList.Item(jj, ii).Style.ForeColor = mCOLOR_ARTICLE_J09_HORYU

                            Case GRID_DSP_REMOVE_KIND_SON
                                '(禁止棚)
                                grdList.Item(jj, ii).Style.ForeColor = mCOLOR_REMOVE_KIND_SON

                            Case GRID_DSP_REMOVE_KIND_SNON
                                '(無効棚)
                                grdList.Item(jj, ii).Style.ForeColor = mCOLOR_REMOVE_KIND_SNON

                            Case GRID_DSP_RES_KIND_SRSV_TRNS_IN
                                '(予約棚)
                                grdList.Item(jj, ii).Style.ForeColor = mCOLOR_RES_KIND_SRSV_TRNS_IN

                        End Select
                    End If
                Next
            Next
        End If


    End Sub
#End Region
#Region "　色取得　                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 色取得
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub getColor()

        '************************************************
        '色設定
        '************************************************
        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(gobjOwner, gobjDb, Nothing)                 'ｼｽﾃﾑ変数ｸﾗｽ
        Dim strColor As String = ""

        '製品
        mCOLOR_ARTICLE_J01 = DEFAULT_COLOR_GRID_DSP_FONT
        strColor = objTPRG_SYS_HEN.GJ304070_101
        If String.IsNullOrEmpty(strColor) = False Then mCOLOR_ARTICLE_J01 = ColorTranslator.FromHtml(strColor)

        '包材
        mCOLOR_ARTICLE_J03 = DEFAULT_COLOR_GRID_DSP_FONT
        strColor = objTPRG_SYS_HEN.GJ304070_103
        If String.IsNullOrEmpty(strColor) = False Then mCOLOR_ARTICLE_J03 = ColorTranslator.FromHtml(strColor)

        '中間品
        mCOLOR_ARTICLE_J02 = DEFAULT_COLOR_GRID_DSP_FONT
        strColor = objTPRG_SYS_HEN.GJ304070_110
        If String.IsNullOrEmpty(strColor) = False Then mCOLOR_ARTICLE_J02 = ColorTranslator.FromHtml(strColor)

        'その他
        mCOLOR_ARTICLE_J09 = DEFAULT_COLOR_GRID_DSP_FONT
        strColor = objTPRG_SYS_HEN.GJ304070_105
        If String.IsNullOrEmpty(strColor) = False Then mCOLOR_ARTICLE_J09 = ColorTranslator.FromHtml(strColor)

        '製品(保留)
        mCOLOR_ARTICLE_J01_HORYU = DEFAULT_COLOR_GRID_DSP_FONT
        strColor = objTPRG_SYS_HEN.GJ304070_102
        If String.IsNullOrEmpty(strColor) = False Then mCOLOR_ARTICLE_J01_HORYU = ColorTranslator.FromHtml(strColor)

        '包材(保留)
        mCOLOR_ARTICLE_J03_HORYU = DEFAULT_COLOR_GRID_DSP_FONT
        strColor = objTPRG_SYS_HEN.GJ304070_104
        If String.IsNullOrEmpty(strColor) = False Then mCOLOR_ARTICLE_J03_HORYU = ColorTranslator.FromHtml(strColor)

        '中間品(保留)
        mCOLOR_ARTICLE_J02_HORYU = DEFAULT_COLOR_GRID_DSP_FONT
        strColor = objTPRG_SYS_HEN.GJ304070_111
        If String.IsNullOrEmpty(strColor) = False Then mCOLOR_ARTICLE_J02_HORYU = ColorTranslator.FromHtml(strColor)

        'その他(保留)
        mCOLOR_ARTICLE_J09_HORYU = DEFAULT_COLOR_GRID_DSP_FONT
        strColor = objTPRG_SYS_HEN.GJ304070_106
        If String.IsNullOrEmpty(strColor) = False Then mCOLOR_ARTICLE_J09_HORYU = ColorTranslator.FromHtml(strColor)

        '禁止棚
        mCOLOR_REMOVE_KIND_SON = DEFAULT_COLOR_GRID_DSP_FONT
        strColor = objTPRG_SYS_HEN.GJ304070_107
        If String.IsNullOrEmpty(strColor) = False Then mCOLOR_REMOVE_KIND_SON = ColorTranslator.FromHtml(strColor)

        '無効棚
        mCOLOR_REMOVE_KIND_SNON = DEFAULT_COLOR_GRID_DSP_FONT
        strColor = objTPRG_SYS_HEN.GJ304070_108
        If String.IsNullOrEmpty(strColor) = False Then mCOLOR_REMOVE_KIND_SNON = ColorTranslator.FromHtml(strColor)

        '予約棚
        mCOLOR_RES_KIND_SRSV_TRNS_IN = DEFAULT_COLOR_GRID_DSP_FONT
        strColor = objTPRG_SYS_HEN.GJ304070_109
        If String.IsNullOrEmpty(strColor) = False Then mCOLOR_RES_KIND_SRSV_TRNS_IN = ColorTranslator.FromHtml(strColor)



        'ｸﾞﾘｯﾄﾞ背景
        mCOLOR_GRID_BACKGROUND = DEFAULT_COLOR_GRID_BACKCOLOR
        strColor = objTPRG_SYS_HEN.GJ304070_001
        If String.IsNullOrEmpty(strColor) = False Then mCOLOR_GRID_BACKGROUND = ColorTranslator.FromHtml(strColor)

        'ｸﾞﾘｯﾄﾞ枠線
        mCOLOR_GRID_BORDER = DEFAULT_COLOR_GRID_BORDER
        strColor = objTPRG_SYS_HEN.GJ304070_002
        If String.IsNullOrEmpty(strColor) = False Then mCOLOR_GRID_BORDER = ColorTranslator.FromHtml(strColor)

        'ｸﾞﾘｯﾄﾞﾀｲﾄﾙ背景
        mCOLOR_GRID_TITLE_BACKGROUND = DEFAULT_COLOR_GRID_TITLE_BACKCOLOR
        strColor = objTPRG_SYS_HEN.GJ304070_011
        If String.IsNullOrEmpty(strColor) = False Then mCOLOR_GRID_TITLE_BACKGROUND = ColorTranslator.FromHtml(strColor)

        'ｸﾞﾘｯﾄﾞﾀｲﾄﾙ文字
        mCOLOR_GRID_TITLE_FONT = DEFAULT_COLOR_GRID_TITLE_FONT
        strColor = objTPRG_SYS_HEN.GJ304070_012
        If String.IsNullOrEmpty(strColor) = False Then mCOLOR_GRID_TITLE_FONT = ColorTranslator.FromHtml(strColor)


    End Sub
#End Region

End Class
