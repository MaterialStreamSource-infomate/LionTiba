'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出荷詳細状況画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_308021

#Region "　共通変数　                               "

    Protected mudtSEARCH_ITEM As New stcSEARCH_ITEM     '検索条件用構造体

    Private mstrXSYUKKA_NO As String               '出荷№
    '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
    Private mstrXPLN_DTL_NO As String              '出荷明細№
    '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
    Private mstrXBERTH_NO As String                'ﾊﾞｰｽ№
    Private mstrXCAR_NO_WARITUKE As String         '受付車番
    Private mstrXCAR_NO_EDA_WARITUKE As String     '枝番
    Private mstrXNYUKA_JIGYOU_NM As String         '配送先
    Private mstrFHINMEI_CD As String               '品名ｺｰﾄﾞ
    Private mstrFTRK_BUF_NO As String              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
    Private mstrXSEIZOU_DT As String               '製造年月日


    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        XSYUKKA_NO                  '出荷実績.   出荷№
        XPLN_DTL_NO                 '出荷実績.   計画明細№(非表示)
        FHINMEI_CD                  '出荷実績.   品名ｺｰﾄﾞ
        FHINMEI                     '品目ﾏｽﾀｰ.   品名
        XSEIZOU_DT                  '出荷実績.   製造年月日
        XLINE_NO                    '出荷実績.   ﾗｲﾝ№
        XPALLET_NO                  '出荷実績.   ﾊﾟﾚｯﾄ№
        XKENPIN_FLAG                '出荷実績.   検品済ﾌﾗｸﾞ
        XKENPIN_FLAG_DSP            '出荷実績.   検品済ﾌﾗｸﾞ(表示用)
        XSYUKKA_KENPIN_VOL          '出荷実績.   出荷検品数(非表示)

        MAXCOL                      'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum


#End Region
#Region "  構造体定義                               "
    '検索条件
    Protected Structure stcSEARCH_ITEM
        Dim FHINMIE_CD As String                    '品名ｺｰﾄﾞ
        Dim FTRK_BUF_NO As String                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        Dim XSEIZOU_DT As String                    '製造年月日
    End Structure
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ                                  "
    '======================================
    ' 出荷№
    '======================================
    Public Property userXSYUKKA_NO() As String
        Get
            Return mstrXSYUKKA_NO
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_NO = value
        End Set
    End Property

    '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
    '======================================
    ' 出荷明細№
    '======================================
    Public Property userXPLN_DTL_NO() As String
        Get
            Return mstrXPLN_DTL_NO
        End Get
        Set(ByVal value As String)
            mstrXPLN_DTL_NO = value
        End Set
    End Property
    '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応

    '======================================
    ' ﾊﾞｰｽ№
    '======================================
    Public Property userXBERTH_NO() As String
        Get
            Return mstrXBERTH_NO
        End Get
        Set(ByVal value As String)
            mstrXBERTH_NO = value
        End Set
    End Property

    '======================================
    ' 受付車番
    '======================================
    Public Property userXCAR_NO_WARITUKE() As String
        Get
            Return mstrXCAR_NO_WARITUKE
        End Get
        Set(ByVal value As String)
            mstrXCAR_NO_WARITUKE = value
        End Set
    End Property

    '======================================
    ' 枝番
    '======================================
    Public Property userXCAR_NO_EDA_WARITUKE() As String
        Get
            Return mstrXCAR_NO_EDA_WARITUKE
        End Get
        Set(ByVal value As String)
            mstrXCAR_NO_EDA_WARITUKE = value
        End Set
    End Property

    '======================================
    ' 配送先
    '======================================
    Public Property userXNYUKA_JIGYOU_NM() As String
        Get
            Return mstrXNYUKA_JIGYOU_NM
        End Get
        Set(ByVal value As String)
            mstrXNYUKA_JIGYOU_NM = value
        End Set
    End Property

    '======================================
    ' 品名ｺｰﾄﾞ
    '======================================
    Public Property userFHINMEI_CD() As String
        Get
            Return mstrFHINMEI_CD
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD = value
        End Set
    End Property

    '======================================
    ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
    '======================================
    Public Property userFTRK_BUF_NO() As String
        Get
            Return mstrFTRK_BUF_NO
        End Get
        Set(ByVal value As String)
            mstrFTRK_BUF_NO = value
        End Set
    End Property

    '======================================
    ' 製造年月日
    '======================================
    Public Property userXSEIZOU_DT() As String
        Get
            Return mstrXSEIZOU_DT
        End Get
        Set(ByVal value As String)
            mstrXSEIZOU_DT = value
        End Set
    End Property

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
    Private Sub tmr308021_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr308021.Tick
        Try

            tmr308021.Enabled = False

            '**************************************************
            ' 表示更新処理
            '**************************************************
            Call tmr308021_TickProcess()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmr308021.Enabled = True

        End Try
    End Sub
#End Region
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    Public Overrides Sub InitializeChild()

        '**********************************************************
        ' ﾎﾞﾀﾝﾏｽｸ設定
        '**********************************************************
        '*NH* CmdEnabledChange(cmdLogo, False)        'ﾂﾘｰﾎﾞﾀﾝ
        Call CmdEnabledChangeMenu()                             'Menuﾎﾞﾀﾝ全般
        Call CmdEnabledChange(cmdClose, False)                  'ﾛｸﾞｵﾌﾎﾞﾀﾝ
        Call CmdEnabledChange(cmdMsgChk, False)                 'ｱﾅｼｴｰﾀﾎﾞﾀﾝ

        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        lblXBERTH_NO.Text = mstrXBERTH_NO                   '出荷日
        lblCAR_NO_WARITUKE.Text = mstrXCAR_NO_WARITUKE      '受付車番
        lblXNYUKA_JIGYOU_NM.Text = mstrXNYUKA_JIGYOU_NM     '配送先

        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        grdList.ScrollBars = ScrollBars.Vertical
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListDisplaySub(grdList)

        '**********************************************************
        ' ﾀｲﾏｰ設定
        '**********************************************************
        tmr308021.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS308021_001))
        tmr308021.Enabled = True

        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                               "
    Public Overrides Sub CloseChild()

        tmr308021.Enabled = False

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ
        tmr308021.Dispose()             'ﾀｲﾏ

    End Sub
#End Region
#Region "  F8  ﾎﾞﾀﾝ押下処理　                       "
    '*******************************************************************************************************************
    '【機能】F8  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F8Process()

        Me.Close()

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
        mudtSEARCH_ITEM.FHINMIE_CD = mstrFHINMEI_CD              '品名ｺｰﾄﾞ
        mudtSEARCH_ITEM.FTRK_BUF_NO = mstrFTRK_BUF_NO            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        mudtSEARCH_ITEM.XSEIZOU_DT = mstrXSEIZOU_DT              '製造年月日

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
        strSQL &= vbCrLf & "           (CASE "
        strSQL &= vbCrLf & "             WHEN XRST_OUT.FTRK_BUF_NO     = " & FTRK_BUF_NO_J8000 & " THEN '出庫完' "
        strSQL &= vbCrLf & "             WHEN TPRG_TRK_BUF.FTRK_BUF_NO = " & FTRK_BUF_NO_J2002 & " THEN '出庫中' "
        strSQL &= vbCrLf & "             WHEN TPRG_TRK_BUF.FTRK_BUF_NO = NVL(TMST_TRK.XTRK_BUF_NO_OUT_HIRA, TMST_TRK.FTRK_BUF_NO) THEN '出庫完' "
        strSQL &= vbCrLf & "             ELSE '未' "
        strSQL &= vbCrLf & "            END) "
        strSQL &= vbCrLf & "        END) AS XKENPIN_FLAG_DSP "                  '出荷実績.   検品済ﾌﾗｸﾞ(表示用)
        strSQL &= vbCrLf & "     , XRST_OUT.XSYUKKA_KENPIN_VOL "                '出荷実績.   出荷検品数(非表示)

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "       XRST_OUT "
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
        strSQL &= vbCrLf & "     AND XRST_OUT.XSYUKKA_NO  = '" & mstrXSYUKKA_NO & "' "       '出荷№
        '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        strSQL &= vbCrLf & "     AND XRST_OUT.XPLN_DTL_NO = '" & mstrXPLN_DTL_NO & "' "       '出荷明細№
        '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応

        '----------------------------------------------
        '品名ｺｰﾄﾞ
        '----------------------------------------------
        If mudtSEARCH_ITEM.FHINMIE_CD <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "     AND XRST_OUT.FHINMEI_CD  = '" & mudtSEARCH_ITEM.FHINMIE_CD & "' "         '品名ｺｰﾄﾞ
        End If

        '----------------------------------------------
        '出庫場所
        '----------------------------------------------
        If mudtSEARCH_ITEM.FTRK_BUF_NO <> CBO_ALL_VALUE Then
            '(全検索以外の場合)

            'If mudtSEARCH_ITEM.FTRK_BUF_NO = FTRK_BUF_NO_J8000 Then
            '    '(ﾊﾞﾗ平置きの場合)
            '    strSQL &= vbCrLf & "     AND XRST_OUT.FTRK_BUF_NO     = " & FTRK_BUF_NO_J8000
            'Else
            '    '(ﾊﾞｰｽの場合)
            '    strSQL &= vbCrLf & "     AND XRST_OUT.FTRK_BUF_NO    IN(" & FTRK_BUF_NO_J1
            '    strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J2
            '    strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J3
            '    strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J4
            '    strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J5
            '    strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J6
            '    strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J7
            '    strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8
            '    strSQL &= vbCrLf & "                                   ) "
            'End If

            strSQL &= vbCrLf & "     AND XRST_OUT.FTRK_BUF_NO     = " & mudtSEARCH_ITEM.FTRK_BUF_NO

        End If

        '----------------------------------------------
        '製造年月日
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSEIZOU_DT <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "     AND XRST_OUT.XSEIZOU_DT = TO_DATE('" & mudtSEARCH_ITEM.XSEIZOU_DT & " 00:00:00','YYYY/MM/DD HH24:MI:SS')"
        End If


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        'Call gobjComFuncFRM.TblDataGridDisplay(grdList, _
        '                        strSQL, _
        '                        False)

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
        'Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理

        If grdList.RowCount > 0 Then
            '(表示ﾃﾞｰﾀありの時)
            grdList.HorizontalScrollingOffset = objPoint.X               'ｽｸﾛｰﾙﾊﾞｰ位置　横
            If 0 <= objPoint.Y Then
                grdList.FirstDisplayedScrollingRowIndex = objPoint.Y     'ｽｸﾛｰﾙﾊﾞｰ位置　縦
            End If
            Call gobjComFuncFRM.GridSelect(grdList, intSelectRow, 2, objPoint)                'ｸﾞﾘｯﾄﾞ選択処理
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

        grdList.MyBeseDoubleBuffered = True                                                                 'ちらつき防止

        For Each objColum As DataGridViewColumn In grdList.Columns
            objColum.SortMode = DataGridViewColumnSortMode.NotSortable                                      '列の並替禁止
        Next

        grdList.AllowUserToResizeColumns = False                                                            '列のｻｲｽﾞ変更禁止

    End Sub
#End Region
#Region "  表示更新ﾀｲﾏｰ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示更新ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr308021_TickProcess()

        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region

End Class
