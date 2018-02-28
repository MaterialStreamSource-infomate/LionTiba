'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｼｽﾃﾑﾓﾆﾀ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_202000

#Region "　共通変数　                           "
    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol
        No                   'ﾅﾝﾊﾞｰ
        FEQ_ID               '設備状況.設備ID
        FEQ_NAME             '設備状況.設備名称
        FEQ_STS              '画面設備状態表示､ﾏｽﾀ.画面表示用名称
        FEQ_CUT_KUBUN        '設備状況.切離可否
        DATA05               'Data05

        MAXCOL
    End Enum

    ''' <summary>入力ﾁｪｯｸ</summary>
    Enum menmCheckCase
        AllStart_Click                  '一斉起動
        AllStop_Click                   '一斉停止
    End Enum

#End Region
#Region "　ｲﾍﾞﾝﾄ　                              "
#Region "  設備状態取得用   ﾀｲﾏｰ                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 設備状態取得用 ﾀｲﾏｰ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr202000_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr202000.Tick
        Try

            tmr202000.Enabled = False

            '**************************************************
            ' 設備状態取得ﾀｲﾏｰ処理
            '**************************************************
            Call tmr202000_TickProcess()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmr202000.Enabled = True

        End Try
    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞｼｮｰﾄｶｯﾄﾒﾆｭｰ　ｵｰﾌﾟﾝ             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞｼｮｰﾄｶｯﾄﾒﾆｭｰｵｰﾌﾟﾝ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ContextMenuStrip1_Opening1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Try

            '********************************************************************
            ' ｸﾞﾘｯﾄﾞｼｮｰﾄｶｯﾄﾒﾆｭｰ　表示処理
            '********************************************************************
            Call ContextMenuStrip1_Disp(e)

        Catch ex As Exception
            ComError(ex)

        End Try

    End Sub

#End Region
#Region "　ｼｮｰﾄｶｯﾄ　　切離し                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｮｰﾄｶｯﾄ　切離し
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_Kiri.Click
        Try

            '**************************************************
            ' 設備切離し要求
            '**************************************************
            If SendSocket01(FORMAT_DSP_CUTOFF_DSPDIR_KUBUN_CUT_ON) = True Then
                '(送信が成功した時)


                '*******************************************************
                'ｸﾞﾘｯﾄﾞ表示処理
                '*******************************************************
                Call grdListDisplaySub(grdList)

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub

#End Region
#Region "　ｼｮｰﾄｶｯﾄ　　復帰                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｮｰﾄｶｯﾄ　復帰
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MenuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_Hukki.Click
        Try

            '**************************************************
            ' 設備切離し要求
            '**************************************************
            If SendSocket01(FORMAT_DSP_CUTOFF_DSPDIR_KUBUN_CUT_OFF) = True Then
                '(送信が成功した時)


                '*******************************************************
                'ｸﾞﾘｯﾄﾞ表示処理
                '*******************************************************
                Call grdListDisplaySub(grdList)

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub

#End Region
#Region "  ﾃﾞｰﾀｸﾞﾘｯﾄﾞｾﾙﾏｳｽﾀﾞｳﾝｲﾍﾞﾝﾄ             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞｾﾙﾏｳｽﾀﾞｳﾝｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdList.CellMouseDown
        Try
            Call grdList_CellMouseDownProcess(sender, e)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃﾞｰﾀｸﾞﾘｯﾄﾞｾﾙﾏｳｽｱｯﾌﾟｲﾍﾞﾝﾄ             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞｾﾙﾏｳｽｱｯﾌﾟｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdList.CellMouseUp
        Try
            Call grdList_CellMouseDownProcess(sender, e)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                               "
    '*******************************************************************************************************************
    '【機能】ﾌｫｰﾑｱｸﾃｨﾌﾞ時ｲﾍﾞﾝﾄ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_202000_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.ActiveControl = Nothing          'ﾃﾞﾌｫﾙﾄﾌｫｰｶｽの無効化

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()


        '**********************************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '**********************************************************
        grdList.ScrollBars = ScrollBars.Vertical
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        grdList.MyBeseDoubleBuffered = True


        '**********************************************************
        ' 表示更新
        '**********************************************************
        Call tmr202000_TickProcess()

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                           "
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
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F1(空棚詳細表示)     ﾎﾞﾀﾝ押下処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()

        tmr202000.Enabled = False

        '******************************************
        ' 画面遷移
        '******************************************
        If IsNull(gobjFRM_302001) = False Then
            gobjFRM_302001.Close()
            gobjFRM_302001.Dispose()
            gobjFRM_302001 = Nothing
        End If

        gobjFRM_302001 = New FRM_302001
        gobjFRM_302001.ShowDialog()

        tmr202000.Enabled = True

    End Sub
#End Region
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/04 CW6追加対応 ↓↓↓↓↓↓
#Region "  F2(生産ﾗｲﾝﾓﾆﾀ)     ﾎﾞﾀﾝ押下処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F2ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F2Process()

        ''******************************************
        '' 画面遷移
        ''******************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_302010, Me)
        Me.Close()

    End Sub
#End Region
    'JobMate:S.Ouchi 2015/07/04 CW6追加対応 ↑↑↑↑↑↑
    '↑↑↑↑↑↑************************************************************************************************************
#Region "　空棚数を取得、表示        処理　     "
    '''***************************************************************************************************************
    ''' <summary>
    ''' 空棚数を取得、表示
    ''' </summary>
    ''' <param name="objLabel">空棚数を取得、表示するﾗﾍﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="strFRAC_FORM">棚形状種別</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Private Sub akiTanaDisplay(ByVal objLabel As Windows.Forms.Label _
                             , Optional ByVal strFRAC_FORM As String = "")

        Dim strSQL As String                        'SQL文

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    COUNT(*) AS CNT "
        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/04/24 ﾌﾞﾛｯｸ単位で取得
        '============================================================
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ副問合せ
        '============================================================
        strSQL &= vbCrLf & "    ("
        strSQL &= vbCrLf & "    SELECT "
        strSQL &= vbCrLf & "      TPRG_TRK_BUF.XTANA_BLOCK "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FRAC_FORM) AS FRAC_FORM "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FTRNS_ADDRESS) AS FTRNS_ADDRESS "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FRES_KIND) AS FRES_KIND "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FREMOVE_KIND) AS FREMOVE_KIND "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FTRK_BUF_NO) AS FTRK_BUF_NO "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FRAC_RETU) AS FRAC_RETU "
        strSQL &= vbCrLf & "    FROM TPRG_TRK_BUF "
        strSQL &= vbCrLf & "    WHERE 1 = 1 "
        strSQL &= vbCrLf & "    GROUP BY TPRG_TRK_BUF.XTANA_BLOCK"
        strSQL &= vbCrLf & "    ) TPRG_TRK_BUF "

        'strSQL &= vbCrLf & "    TPRG_TRK_BUF "                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & " ,  TMST_CRANE "                          'ｸﾚｰﾝﾏｽﾀ
        strSQL &= vbCrLf & " ,  TSTS_EQ_CTRL "                        '設備状況
        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "      1 = 1 "
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FRES_KIND    = " & FRES_KIND_SAKI                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.引当状態 が 0:空棚 のﾚｺｰﾄﾞを抽出
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FREMOVE_KIND = " & FREMOVE_KIND_SNORMAL          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.禁止有無 が 0:無   のﾚｺｰﾄﾞを抽出
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FTRK_BUF_NO  = " & FTRK_BUF_NO_J9000             '自動倉庫
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FRAC_RETU   >= TMST_CRANE.FCRANE_ROW1(+) "       '列1
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FRAC_RETU   <= TMST_CRANE.FCRANE_ROW2(+) "       '列2
        strSQL &= vbCrLf & "  AND TMST_CRANE.FEQ_ID         = TSTS_EQ_CTRL.FEQ_ID(+) "          '設備ID
        strSQL &= vbCrLf & "  AND TSTS_EQ_CTRL.FEQ_CUT_STS  = " & FEQ_CUT_STS_SOFF              '切離状態 = 通常
        strSQL &= vbCrLf & "  AND TSTS_EQ_CTRL.FEQ_STS      = " & FEQ_STS_JINOUTMODE_OUT        '設備状態 = 運転中
        If strFRAC_FORM <> CBO_ALL_VALUE Then
            '(棚形状種別が指定されている場合)
            strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FRAC_FORM = " & strFRAC_FORM                 '棚形状種別
        Else
            '(棚形状種別が指定されていない場合)
            strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FRAC_FORM IN (" & FRAC_FORM_JHIGH_TANA       '棚形状種別
            strSQL &= vbCrLf & "                               , " & FRAC_FORM_JNORMAL_TANA
            strSQL &= vbCrLf & "                                ) "
        End If


        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        gobjDb.SQL = strSQL
        strDataSetName = "TPRG_TRK_BUF"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        objRow = objDataSet.Tables(strDataSetName).Rows(0)
        objLabel.Text = TO_INTEGER(objRow("CNT"))

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示　                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataTable As New GamenCommon.clsGridDataTable05      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TSTS_EQ_CTRL.FEQ_ID "                                 '設備状況.設備ID
        strSQL &= vbCrLf & "   ,TSTS_EQ_CTRL.FEQ_NAME "                               '設備状況.設備名称
        strSQL &= vbCrLf & "   ,NVL(TDSP_EQ_STS.FSTS_NAME, TSTS_EQ_CTRL.FEQ_STS) AS FSTS_NAME "  '画面設備状態表示ﾏｽﾀ.画面表示用名称
        strSQL &= vbCrLf & "   ,TSTS_EQ_CTRL.FEQ_CUT_KUBUN "                          '設備状況.切離可否
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TSTS_EQ_CTRL "                                        '設備状況
        strSQL &= vbCrLf & "   ,TDSP_EQ_STS "                                         '画面設備状態表示ﾏｽﾀ
        strSQL &= vbCrLf & "   ,TDSP_CTRL "                                         '画面設備状態表示ﾏｽﾀ ※修正1　(追加)

        '============================================================
        'WHERE
        '============================================================
        '----------------------------
        'ﾃｰﾌﾞﾙ結合
        '----------------------------
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_ID = TDSP_CTRL.FCTRL_VALUE "                   '設備ID 　　　と 画面ｺﾝﾄﾛｰﾙﾏｽﾀ 　　　の 設備ID 　を 内部結合
        strSQL &= vbCrLf & "    AND TDSP_CTRL.FDISP_ID = '" & Me.Name & "'"                         '画面ｺﾝﾄﾛｰﾙﾏｽﾀの DISPID が   一致         のもの
        strSQL &= vbCrLf & "    AND TDSP_CTRL.FCTRL_ID = '" & grdList.Name & "'"                    '画面ｺﾝﾄﾛｰﾙﾏｽﾀの CTRLNAME が 一致         のもの
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_DSP_KUBUN = TDSP_EQ_STS.FEQ_DSP_KUBUN(+) "     '設備ID 　　　と 画面設備状態表示ﾏｽﾀ の 画面設備表示区分 　を 外部結合
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_STS = TDSP_EQ_STS.FEQ_STS(+) "                 '設備状況 　　と 画面設備状態表示ﾏｽﾀ の 設備状態 を 外部結合
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_CUT_STS = TDSP_EQ_STS.FEQ_CUT_STS(+) "         '設備切離有無 と 画面設備状態表示ﾏｽﾀ の 切離有無 を 外部結合

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "   TDSP_CTRL.FCTRL_ORDER "                              'ｺﾝﾄﾛｰﾙﾏｽﾀ.ｵｰﾀﾞｰ(昇順)
        strSQL &= vbCrLf & " , TSTS_EQ_CTRL.FEQ_ID "                                '設備状況.設備ID(昇順)


        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        gobjDb.SQL = strSQL
        strDataSetName = "TDSP_EQ_STS"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            Dim ii As Integer = 1
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                objDataTable.userAddRowDataSet(TO_STRING(ii), TO_STRING(objRow("FEQ_ID")), TO_STRING(objRow("FEQ_NAME")), TO_STRING(objRow("FSTS_NAME")), TO_STRING(objRow("FEQ_CUT_KUBUN")))
                ii += 1
            Next
        End If


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置     記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶
        Call gobjComFuncFRM.GridDisplay(objDataTable, _
                         grdList, _
                         intSelectRow, _
                         intSelectCol, _
                         objPoint)
        objDataSet = Nothing


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()                                                 'ｸﾞﾘｯﾄﾞ表示設定


        '********************************************************************
        '「異常」文字色変更
        '********************************************************************
        For ii As Integer = 0 To grdList.RowCount - 1
            '(ﾙｰﾌﾟ:明細行分)
            If (grdList.Item(menmListCol.FEQ_STS, grdList.Rows(ii).Index).Value = "異常") Then
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.FEQ_STS, grdList.Rows(ii).Index).Style.ForeColor = Color.Red
            ElseIf (grdList.Item(menmListCol.FEQ_STS, grdList.Rows(ii).Index).Value = "切離中") Then
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.FEQ_STS, grdList.Rows(ii).Index).Style.ForeColor = Color.OrangeRed
            End If

            'If (grdList.Item(menmListCol.FEQ_ID, grdList.Rows(ii).Index).Value = FEQ_ID_JSYS0091) And _
            '   (grdList.Item(menmListCol.FEQ_STS, grdList.Rows(ii).Index).Value = "ｵﾌﾗｲﾝ") Then
            '    '(MCV運転ﾓｰﾄﾞがｵﾌﾗｲﾝの時)
            '    grdList.Item(menmListCol.FEQ_STS, grdList.Rows(ii).Index).Style.ForeColor = Color.Red
            'End If

        Next


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ選択
        '********************************************************************
        grdList.HorizontalScrollingOffset = objPoint.X               'ｽｸﾛｰﾙﾊﾞｰ位置　横
        If 0 <= objPoint.Y Then
            grdList.FirstDisplayedScrollingRowIndex = objPoint.Y     'ｽｸﾛｰﾙﾊﾞｰ位置　縦
        End If
        Call gobjComFuncFRM.GridSelect(grdList, intSelectRow, intSelectCol, objPoint)      'ｸﾞﾘｯﾄﾞ選択処理

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定　                     "
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
        'ｸﾞﾘｯﾄﾞ列の並替ﾓｰﾄﾞ変更
        '************************************************
        Call gobjComFuncFRM.GridSortModeSet(grdList, DataGridViewColumnSortMode.NotSortable)
        grdList.Columns(menmListCol.FEQ_STS).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill        '列幅自動調節
        grdList.AllowUserToResizeColumns = False

    End Sub
#End Region
#Region "  設備状態取得ﾀｲﾏｰ処理                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 設備状態取得ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr202000_TickProcess()


        '**********************************************************
        ' ﾗﾍﾞﾙ背景色変更処理
        '**********************************************************
        Call AlterLabelColorAll()


        '**********************************************************
        ' 空棚数を取得、表示処理
        '**********************************************************
        Call akiTanaDisplay(lblTAKATANA_NUM, FRAC_FORM_JHIGH_TANA)                  '高棚
        Call akiTanaDisplay(lblHIKUTANA_NUM, FRAC_FORM_JNORMAL_TANA)                '低棚
        Call akiTanaDisplay(lblKEI_NUM)                                             '計


        '**********************************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '**********************************************************
        'grdList.ScrollBars = ScrollBars.None
        Call grdListDisplaySub(grdList)
        'grdList.ScrollBars = ScrollBars.Both

        '**********************************************************
        ' ﾀｲﾏｰ設定
        '**********************************************************
        tmr202000.Enabled = False
        tmr202000.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS202000_001))
        tmr202000.Enabled = True


    End Sub
#End Region
#Region "　ﾗﾍﾞﾙ背景色変更　                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾗﾍﾞﾙ背景色変更
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub AlterLabelColorAll()

        '**************************************************
        '単独系の背景色変更
        '**************************************************
        ' ''Call gobjComFuncFRM.AlterLabelColor(lblCRANE1, Me.Name, LBL_DSPTYPE.NO_DSP)                 'ｸﾚｰﾝ1号機
        ' ''Call gobjComFuncFRM.AlterLabelColor(lblCRANE2, Me.Name, LBL_DSPTYPE.NO_DSP)                 'ｸﾚｰﾝ2号機
        ' ''Call gobjComFuncFRM.AlterLabelColor(lblCRANE3, Me.Name, LBL_DSPTYPE.NO_DSP)                 'ｸﾚｰﾝ3号機
        ' ''Call gobjComFuncFRM.AlterLabelColor(lblCRANE4, Me.Name, LBL_DSPTYPE.NO_DSP)                 'ｸﾚｰﾝ4号機
        ' ''Call gobjComFuncFRM.AlterLabelColor(lblCRANE5, Me.Name, LBL_DSPTYPE.NO_DSP)                 'ｸﾚｰﾝ5号機
        ' ''Call gobjComFuncFRM.AlterLabelColor(lblCRANE6, Me.Name, LBL_DSPTYPE.NO_DSP)                 'ｸﾚｰﾝ6号機
        ' ''Call gobjComFuncFRM.AlterLabelColor(lblCRANE7, Me.Name, LBL_DSPTYPE.NO_DSP)                 'ｸﾚｰﾝ7号機
        ' ''Call gobjComFuncFRM.AlterLabelColor(lblCRANE8, Me.Name, LBL_DSPTYPE.NO_DSP)                 'ｸﾚｰﾝ8号機
        ' ''Call gobjComFuncFRM.AlterLabelColor(lblCRANE9, Me.Name, LBL_DSPTYPE.NO_DSP)                 'ｸﾚｰﾝ9号機
        ' ''Call gobjComFuncFRM.AlterLabelColor(lblCRANE10, Me.Name, LBL_DSPTYPE.NO_DSP)                'ｸﾚｰﾝ10号機
        ' ''Call gobjComFuncFRM.AlterLabelColor(lblCRANE11, Me.Name, LBL_DSPTYPE.NO_DSP)                'ｸﾚｰﾝ11号機
        ' ''Call gobjComFuncFRM.AlterLabelColor(lblCRANE12, Me.Name, LBL_DSPTYPE.NO_DSP)                'ｸﾚｰﾝ12号機
        ' ''Call gobjComFuncFRM.AlterLabelColor(lblCRANE13, Me.Name, LBL_DSPTYPE.NO_DSP)                'ｸﾚｰﾝ13号機
        ' ''Call gobjComFuncFRM.AlterLabelColor(lblCRANE14, Me.Name, LBL_DSPTYPE.NO_DSP)                'ｸﾚｰﾝ14号機

        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:A.NOTO 2013/04/25  ﾗﾍﾞﾙ背景色変更(ｸﾞﾙｰﾌﾟ)を追加
        'SystemMate:H.Okumura 2013/07/08  設備状態の判定方法を変更
        Call gobjComFuncFRM.AlterLabelColorGroup(lblCRANE1, Me.Name, LBL_DSPTYPE.NO_DSP)            'ｸﾚｰﾝ1号機
        Call gobjComFuncFRM.AlterLabelColorGroup(lblCRANE2, Me.Name, LBL_DSPTYPE.NO_DSP)            'ｸﾚｰﾝ2号機
        Call gobjComFuncFRM.AlterLabelColorGroup(lblCRANE3, Me.Name, LBL_DSPTYPE.NO_DSP)            'ｸﾚｰﾝ3号機
        Call gobjComFuncFRM.AlterLabelColorGroup(lblCRANE4, Me.Name, LBL_DSPTYPE.NO_DSP)            'ｸﾚｰﾝ4号機
        Call gobjComFuncFRM.AlterLabelColorGroup(lblCRANE5, Me.Name, LBL_DSPTYPE.NO_DSP)            'ｸﾚｰﾝ5号機
        Call gobjComFuncFRM.AlterLabelColorGroup(lblCRANE6, Me.Name, LBL_DSPTYPE.NO_DSP)            'ｸﾚｰﾝ6号機
        Call gobjComFuncFRM.AlterLabelColorGroup(lblCRANE7, Me.Name, LBL_DSPTYPE.NO_DSP)            'ｸﾚｰﾝ7号機
        Call gobjComFuncFRM.AlterLabelColorGroup(lblCRANE8, Me.Name, LBL_DSPTYPE.NO_DSP)            'ｸﾚｰﾝ8号機
        Call gobjComFuncFRM.AlterLabelColorGroup(lblCRANE9, Me.Name, LBL_DSPTYPE.NO_DSP)            'ｸﾚｰﾝ9号機
        Call gobjComFuncFRM.AlterLabelColorGroup(lblCRANE10, Me.Name, LBL_DSPTYPE.NO_DSP)           'ｸﾚｰﾝ10号機
        Call gobjComFuncFRM.AlterLabelColorGroup(lblCRANE11, Me.Name, LBL_DSPTYPE.NO_DSP)           'ｸﾚｰﾝ11号機
        Call gobjComFuncFRM.AlterLabelColorGroup(lblCRANE12, Me.Name, LBL_DSPTYPE.NO_DSP)           'ｸﾚｰﾝ12号機
        Call gobjComFuncFRM.AlterLabelColorGroup(lblCRANE13, Me.Name, LBL_DSPTYPE.NO_DSP)           'ｸﾚｰﾝ13号機
        Call gobjComFuncFRM.AlterLabelColorGroup(lblCRANE14, Me.Name, LBL_DSPTYPE.NO_DSP)           'ｸﾚｰﾝ14号機
        '↑↑↑↑↑↑************************************************************************************************************

        Call gobjComFuncFRM.AlterLabelColorGroup(lblRTN1F, Me.Name, LBL_DSPTYPE.NO_DSP)             '1F_RTN
        Call gobjComFuncFRM.AlterLabelColorGroup(lblTANA1F, Me.Name, LBL_DSPTYPE.NO_DSP)            '1F_入出棚ｺﾝﾍﾞﾔ
        Call gobjComFuncFRM.AlterLabelColorGroup(lblSYUKKA1F, Me.Name, LBL_DSPTYPE.NO_DSP)          '1F_出荷ｺﾝﾍﾞﾔ
        Call gobjComFuncFRM.AlterLabelColorGroup(lblGAIBU, Me.Name, LBL_DSPTYPE.NO_DSP)             '1F_外部入出庫ｺﾝﾍﾞﾔ
        Call gobjComFuncFRM.AlterLabelColorGroup(lblTRUCK, Me.Name, LBL_DSPTYPE.NO_DSP)             '1F_ﾄﾗｯｸﾛｰﾀﾞ

        Call gobjComFuncFRM.AlterLabelColorGroup(lblRTN2F, Me.Name, LBL_DSPTYPE.NO_DSP)             '2F_RTN
        Call gobjComFuncFRM.AlterLabelColorGroup(lblTANA2F, Me.Name, LBL_DSPTYPE.NO_DSP)            '2F_入出棚ｺﾝﾍﾞﾔ
        Call gobjComFuncFRM.AlterLabelColorGroup(lblDCV, Me.Name, LBL_DSPTYPE.NO_DSP)               '2F_Dｺﾝﾍﾞﾔ

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞｼｮｰﾄｶｯﾄﾒﾆｭｰ　表示処理          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞｼｮｰﾄｶｯﾄﾒﾆｭｰ　表示処理
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ContextMenuStrip1_Disp(ByVal e As System.ComponentModel.CancelEventArgs)


        '********************************************************************
        'ﾘｽﾄ選択ﾁｪｯｸ
        '********************************************************************
        If grdList.SelectedRows.Count < 1 Then
            '(ﾘｽﾄが選択されていない場合)
            e.Cancel = True
            Exit Sub
        End If


        '********************************************************************
        'ｸﾞﾘｯﾄﾞｼｮｰﾄｶｯﾄﾒﾆｭｰ　表示設定
        '********************************************************************
        Select Case grdList.Item(menmListCol.FEQ_CUT_KUBUN, grdList.SelectedRows(0).Index).Value
            '(切離可否判断)

            Case FEQ_CUT_KUBUN_SNG
                '(不可の場合)

                e.Cancel = True

            Case FEQ_CUT_KUBUN_SOK
                '(可の場合)

                '============================================
                'ﾒﾆｭｰｱｲﾃﾑ表示設定
                '============================================
                Menu_Kiri.Visible = True                 '「切離し」         表示
                Menu_Hukki.Visible = True                '「復帰」　         表示

        End Select

    End Sub

#End Region
#Region "  ｿｹｯﾄ送信01(設備切離し)               "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信01(設備切離し)
    ''' </summary>
    ''' <param name="intCutSts">切離状態</param>
    ''' <returns>True:送信成功  False:送信失敗</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function SendSocket01(ByVal intCutSts As Integer) As Boolean
        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ


        ' '' ''*******************************************************
        ' '' ''確認ﾒｯｾｰｼﾞ
        ' '' ''*******************************************************
        '' ''Dim udtRet As RetPopup
        '' ''Dim strMsg As String
        '' ''strMsg = ""
        '' ''If intCutSts = FORMAT_DSP_CUTOFF_DSPDIR_KUBUN_CUT_ON Then
        '' ''    '(切離しの場合)
        '' ''    strMsg = "切離ししてもよろしいですか？"
        '' ''ElseIf intCutSts = FORMAT_DSP_CUTOFF_DSPDIR_KUBUN_CUT_OFF Then
        '' ''    '(復帰の場合)
        '' ''    strMsg = "復帰してもよろしいですか？"
        '' ''End If

        '' ''udtRet = gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        '' ''If udtRet <> RetPopup.OK Then
        '' ''    Exit Function
        '' ''End If

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strEQ_ID As String
        strEQ_ID = TO_STRING(grdList.Item(menmListCol.FEQ_ID, grdList.SelectedRows(0).Index).Value)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200201                   'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPEQ_ID", strEQ_ID)                                '設備ID
        objTelegram.SETIN_DATA("DSPEQ_CUT_STS", TO_STRING(intCutSts))               '切離状態


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                 'ｴﾗｰﾒｯｾｰｼﾞ

        If intCutSts = FORMAT_DSP_CUTOFF_DSPDIR_KUBUN_CUT_OFF Then
            strErrMsg = FRM_MSG_FRM202000_01
        ElseIf intCutSts = FORMAT_DSP_CUTOFF_DSPDIR_KUBUN_CUT_ON Then
            strErrMsg = FRM_MSG_FRM202000_02
        End If

        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnCheckErr = False
            End If
        End If

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
#Region "  ｿｹｯﾄ送信03(空出庫対応ｿｹｯﾄ)           "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <param name="strFEQ_ID">ｸﾚｰﾝID</param>
    ''' <param name="strFPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function SendSocket03(ByVal strFEQ_ID As String, ByVal strFPALLET_ID As String) As Boolean

        Dim blnRet As Boolean = False

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= FRM_MSG_FRM202000_15
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest, , "空出庫対応操作")
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strXSIZI_KUBUN As String = ""       '指示区分(行先変更"01"、手動払い出し"03"、空出庫"12")
        Dim strFTRK_BUF_NO As String = ""       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        Dim strFTRK_BUF_ARRAY As String = ""    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列
        Dim strST_OUT As String = ""            '出庫先ST(未使用)
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200202          'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        strXSIZI_KUBUN = TO_STRING(FORMAT_DSP_DSPSIZI_KUBUN_EMPTY)          '指示区分

        objTelegram.SETIN_DATA("DSPSIZI_KUBUN", strXSIZI_KUBUN)         '指示区分
        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFTRK_BUF_NO)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFTRK_BUF_ARRAY)   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列
        objTelegram.SETIN_DATA("DSPST_OUT", strST_OUT)                  '出庫ST
        objTelegram.SETIN_DATA("DSPEQ_ID", strFEQ_ID)                   '設備ID
        objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)           'ﾊﾟﾚｯﾄID

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                         'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = FRM_MSG_FRM202000_16
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            End If
        End If

        Return blnRet

    End Function
#End Region
#Region "  ﾃﾞｰﾀｸﾞﾘｯﾄﾞﾏｳｽﾀﾞｳﾝ処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞﾏｳｽﾀﾞｳﾝ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_CellMouseDownProcess(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)


        If e.Button = MouseButtons.Right Then
            '(右ｸﾘｯｸの場合)


            '********************************************************************
            '選択ｾﾙを変更する
            '********************************************************************
            If e.ColumnIndex >= 1 And e.RowIndex >= 1 Then
                '(ﾍｯﾀﾞ以外のｾﾙの場合)
                grdList.ClearSelection()
                grdList.Item(e.ColumnIndex, e.RowIndex).Selected = True
            End If

        End If


    End Sub
#End Region
#Region "　ｸﾚｰﾝﾗﾍﾞﾙｸﾘｯｸ処理                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾚｰﾝﾗﾍﾞﾙｸﾘｯｸ処理
    ''' </summary>
    ''' <param name="strCraneID"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub RMLabelClick(ByVal strCraneID As String, ByVal strTrkBufNo As String)

        '**********************************************************
        'ｸﾚｰﾝ状態取得
        '**********************************************************
        Dim objTBL_TSTS_CRANE As New TBL_TSTS_CRANE(gobjOwner, gobjDb, Nothing)
        objTBL_TSTS_CRANE.FEQ_ID = strCraneID               'ｸﾚｰﾝID
        Call objTBL_TSTS_CRANE.GET_TSTS_CRANE(False)
        If TO_STRING(objTBL_TSTS_CRANE.FCOMP_KUBUN) = TO_STRING(FCOMP_KUBUN_SNIJUU) Then
            '(二重搬入の場合)

            Dim strFPALLET_ID As String = ""     'ﾊﾟﾚｯﾄID
            If GetUnusual_PALLET_ID(strCraneID, objTBL_TSTS_CRANE.FCOMP_KUBUN, strFPALLET_ID) = False Then
                Exit Sub
            End If

            '======================================
            '二重格納対応操作画面表示
            '======================================
            If IsNull(gobjFRM_202001) = False Then
                gobjFRM_202001.Close()
                gobjFRM_202001.Dispose()
                gobjFRM_202001 = Nothing
            End If

            gobjFRM_202001 = New FRM_202001
            gobjFRM_202001.userFEQ_ID = TO_STRING(objTBL_TSTS_CRANE.FEQ_ID)         'ｸﾚｰﾝ番号
            gobjFRM_202001.userFPALLET_ID = strFPALLET_ID                           'ﾊﾟﾚｯﾄID
            gobjFRM_202001.userFTRK_BUF_NO = strTrkBufNo                            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            gobjFRM_202001.userGamenMode = GAMENMODE_NIJYU                          '画面ﾓｰﾄﾞ

            Dim intRet As DialogResult
            intRet = gobjFRM_202001.ShowDialog()            '展開
            gobjFRM_202001.Dispose()
            gobjFRM_202001 = Nothing
            If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
                '(ｷｬﾝｾﾙ時)
                Exit Sub
            End If

        ElseIf TO_STRING(objTBL_TSTS_CRANE.FCOMP_KUBUN) = TO_STRING(FCOMP_KUBUN_SKARA) Then
            '(空出庫の場合)

            Dim strFPALLET_ID As String = ""     'ﾊﾟﾚｯﾄID
            If GetUnusual_PALLET_ID(strCraneID, objTBL_TSTS_CRANE.FCOMP_KUBUN, strFPALLET_ID) = False Then
                Exit Sub
            End If

            '======================================
            'ｿｹｯﾄ送信
            '======================================
            If SendSocket03(strCraneID, strFPALLET_ID) = False Then
                Exit Sub
            End If

        ElseIf TO_STRING(objTBL_TSTS_CRANE.FCOMP_KUBUN) = TO_STRING(FCOMP_KUBUN_SNISUGATA) Then
            '(荷姿不一致の場合)

            Dim strFPALLET_ID As String = ""     'ﾊﾟﾚｯﾄID
            If GetUnusual_PALLET_ID(strCraneID, objTBL_TSTS_CRANE.FCOMP_KUBUN, strFPALLET_ID) = False Then
                Exit Sub
            End If

            '======================================
            '荷姿不一致対応操作画面表示
            '======================================
            If IsNull(gobjFRM_202001) = False Then
                gobjFRM_202001.Close()
                gobjFRM_202001.Dispose()
                gobjFRM_202001 = Nothing
            End If

            gobjFRM_202001 = New FRM_202001
            gobjFRM_202001.userFEQ_ID = TO_STRING(objTBL_TSTS_CRANE.FEQ_ID)         'ｸﾚｰﾝ番号
            gobjFRM_202001.userFPALLET_ID = strFPALLET_ID                           'ﾊﾟﾚｯﾄID
            gobjFRM_202001.userFTRK_BUF_NO = strTrkBufNo                            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            gobjFRM_202001.userGamenMode = GAMENMODE_FUICCHI                        '画面ﾓｰﾄﾞ

            Dim intRet As DialogResult
            intRet = gobjFRM_202001.ShowDialog()            '展開
            gobjFRM_202001.Dispose()
            gobjFRM_202001 = Nothing
            If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
                '(ｷｬﾝｾﾙ時)
                Exit Sub
            End If

        Else
            '(通常状態の場合)
            Exit Sub
        End If

        '**********************************************************
        ' ﾗﾍﾞﾙ背景色変更処理
        '**********************************************************
        Call AlterLabelColorAll()

    End Sub
#End Region

End Class
