'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】変更履歴問合せ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_204070

#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    Private mblnGridDisplayingFlg As Boolean = False        '上ｸﾞﾘｯﾄﾞ表示中ﾌﾗｸﾞ

    Private mudtSEARCH_ITEM As New stcSEARCH_ITEM             '検索条件用構造体(上ｸﾞﾘｯﾄﾞ)
    Private mudtSEARCH_ITEM_VA As New stcSEARCH_ITEM_VA       '検索条件用構造体(下ｸﾞﾘｯﾄﾞ)

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FHASSEI_DT          '変更履歴       .発生日時
        FUSER_ID            '変更履歴       .ﾕｰｻﾞｰID
        FUSER_NAME          '変更履歴       .ﾕｰｻﾞｰ名
        FTERM_NAME          '変更履歴       .操作端末
        FREASON             '変更履歴       .変更理由
        FSYORI_ID           '変更履歴       .処理ID
        FLOG_NO             '変更履歴       .ﾛｸﾞ№

        MAXCOL                 'ｸﾞﾘｯﾄﾞの列数の最大値
    End Enum

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        SearchBtn_Click         '検索ﾎﾞﾀﾝｸﾘｯｸ
        DetailBtn_Click         '詳細表示ﾎﾞﾀﾝｸﾘｯｸ時
        PrintBtn_Click          '印刷ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    ''' <summary>検索条件(上ｸﾞﾘｯﾄﾞ)</summary>
    Private Structure stcSEARCH_ITEM
        Dim FSYORI_ID As String         '変更履歴情報
        Dim FUSER_ID As String          '変更者
        Dim KIKAN_FROM As String        '期間(FROM)
        Dim KIKAN_TO As String          '期間(TO)
    End Structure

    ''' <summary>検索条件(下ｸﾞﾘｯﾄﾞ)</summary>
    Private Structure stcSEARCH_ITEM_VA
        Dim FSYORI_ID As String        '処理ID
        Dim FLOG_NO As String          'ﾛｸﾞ№
    End Structure

#End Region
#Region "　ｲﾍﾞﾝﾄ　                                  "
#Region "　作業者ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 作業者ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFUSER_ID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFUSER_ID.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                '*********************************************
                ' 作業者名　表示
                '*********************************************
                lblFUSER_NAME_DSP.Text = gobjComFuncFRM.Get_FUSER_NAME(TO_STRING(cboFUSER_ID.Text))

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞｾﾚｸﾄﾁｪﾝｼﾞ              ｲﾍﾞﾝﾄ       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞｾﾚｸﾄﾁｪﾝｼﾞ ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.SelectionChanged
        Try

            If mblnGridDisplayingFlg = True Then Exit Try

            If grdList.SelectedRows.Count = 0 Then Exit Try

            If grdList.SelectedRows.Count >= 1 Then
                '(選択行番号が1以上の場合 かつ 選択行のみ変更の場合)

                '********************************************************************
                '入力ﾁｪｯｸ
                '********************************************************************
                If InputCheck(menmCheckCase.DetailBtn_Click) = False Then
                    Exit Sub
                End If

                '*********************************************
                ' 構造体ｾｯﾄ
                '*********************************************
                Call SearchItem_Set(menmCheckCase.DetailBtn_Click)

                '*********************************************
                ' ｸﾞﾘｯﾄﾞ表示
                '*********************************************
                Call grdListDisplay()

            Else
                '(選択行番号が1未満の場合 かつ 選択行のみ変更の場合)

                '*********************************************
                ' ｸﾞﾘｯﾄﾞ2初期設定
                '*********************************************
                Call gobjComFuncFRM.FlexGridInitialize(grdList2, 1, 1)                     'ｸﾞﾘｯﾄﾞ初期設定

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ2ｾﾚｸﾄﾁｪﾝｼﾞ(Before)     ｲﾍﾞﾝﾄ       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ2ｾﾚｸﾄﾁｪﾝｼﾞ(Before) ｲﾍﾞﾝﾄ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList2.SelectionChanged
        Try

            grdList2.ClearSelection()

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


        '**********************************************************
        ' 変更履歴情報ｺﾝﾎﾞ            ｾｯﾄ
        '**********************************************************
        gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFSYORI_ID, False)


        '**********************************************************
        ' 変更者ｺﾝﾎﾞ            ｾｯﾄ
        '**********************************************************
        Call gobjComFuncFRM.cboMsterSetup("TMST_USER", "FUSER_NAME", "FUSER_ID", "FUSER_ID", cboFUSER_ID)
        lblFUSER_NAME_DSP.Text = ""


        '**********************************************************
        ' 期間                      ｾｯﾄ
        '**********************************************************
        Call gobjComFuncFRM.dtpKikanFromToSetup(dtpFrom, dtpTo)

        '**********************************************************
        ' ﾘｽﾄﾗﾍﾞﾙの初期化
        '**********************************************************
        'lblLst.BackColor = Color.FromArgb(128, 128, 255)
        lblLst.BackColor = Color.FromArgb(32, 32, 224)
        lblLst.Font = New Font("ＭＳ ゴシック", 11.25, FontStyle.Bold)                  'ﾌｫﾝﾄ設定
        lblLst.ForeColor = Color.Yellow                                                 'ﾌｫﾝﾄｶﾗｰ
        lblLst.Text = "項目名"

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 0, menmListCol.MAXCOL)     'ｸﾞﾘｯﾄﾞ初期設定
        Call gobjComFuncFRM.FlexGridInitialize(grdList2, 0, 1)                     'ｸﾞﾘｯﾄﾞ初期設定
        grdList2.Columns(0).Width = grdList2.Width - 5              '列幅調節
        grdList2.RowHeadersWidth = 100
        grdList2.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grdList2.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(128, 128, 255)
        grdList2.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(32, 32, 224)
        grdList2.RowHeadersDefaultCellStyle.Font = New Font("ＭＳ ゴシック", 11.25, FontStyle.Bold)                  'ﾌｫﾝﾄ設定
        grdList2.RowHeadersDefaultCellStyle.ForeColor = Color.Yellow                                                 'ﾌｫﾝﾄｶﾗｰ
        grdList2.RowHeadersVisible = False
        lblLst.Visible = False

        Call grdListSetup()

        mFlag_Form_Load = False

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
        cboFSYORI_ID.Dispose()          '変更履歴情報
        cboFUSER_ID.Dispose()           '変更者ｺｰﾄﾞ
        dtpFrom.Dispose()               'FROM期間
        dtpTo.Dispose()                 'TO期間
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ
        grdList2.Dispose()              'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F1(検索)         ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(検索) ﾎﾞﾀﾝ押下処理
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
        Call SearchItem_Set(menmCheckCase.SearchBtn_Click)


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)
        '------------------------------
        'ｸﾞﾘｯﾄﾞ2の初期化処理
        grdList2.ColumnCount = 0
        grdList2.RowCount = 0
        grdList2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Call gobjComFuncFRM.FlexGridInitialize(grdList2, 0, 1)                     'ｸﾞﾘｯﾄﾞ(下)初期設定
        grdList2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        grdList2.RowHeadersVisible = False
        lblLst.Visible = False


    End Sub
#End Region
#Region "  F8(戻る)         ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8(戻る) ﾎﾞﾀﾝ押下処理
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
#Region "　構造体ｾｯﾄ　                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set(ByVal udtCheck_Case As menmCheckCase)

        '********************************************************************
        '構造体に値をｾｯﾄ
        '********************************************************************
        Select Case udtCheck_Case
            Case menmCheckCase.SearchBtn_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)
                '===============================================
                ' 変更履歴情報
                '===============================================
                mudtSEARCH_ITEM.FSYORI_ID = TO_STRING(cboFSYORI_ID.SelectedValue)

                '===============================================
                ' 変更者
                '===============================================
                mudtSEARCH_ITEM.FUSER_ID = TO_STRING(cboFUSER_ID.Text)

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

            Case menmCheckCase.DetailBtn_Click
                '(詳細ﾎﾞﾀﾝｸﾘｯｸ時)

                Dim intSelRow As Integer = grdList.SelectedRows(0).Index

                '===============================================
                '処理ID
                '===============================================
                mudtSEARCH_ITEM_VA.FSYORI_ID = TO_STRING(grdList.Item(menmListCol.FSYORI_ID, intSelRow).Value)          '処理ID

                '===============================================
                'ﾛｸﾞ№
                '===============================================
                mudtSEARCH_ITEM_VA.FLOG_NO = TO_STRING(grdList.Item(menmListCol.FLOG_NO, intSelRow).Value)              'ﾛｸﾞ№

        End Select


    End Sub
#End Region
#Region "　ﾘｽﾄ表示(上)　                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示(上)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        mblnGridDisplayingFlg = True

        Dim strSQL As String                        'SQL文
        Dim strSQLSearch As String              '検索条件部分


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     TEVD_TBLCHANGE.FHASSEI_DT "                '変更履歴       .発生日時
        strSQL &= vbCrLf & "   , TEVD_TBLCHANGE.FUSER_ID "                  '変更履歴       .ﾕｰｻﾞｰID
        strSQL &= vbCrLf & "   , TEVD_TBLCHANGE.FUSER_NAME "                '変更履歴       .ﾕｰｻﾞｰ名
        strSQL &= vbCrLf & "   , TEVD_TBLCHANGE.FTERM_NAME "                '変更履歴       .操作端末
        strSQL &= vbCrLf & "   , TEVD_TBLCHANGE.FREASON "                   '変更履歴       .変更理由
        strSQL &= vbCrLf & "   , TEVD_TBLCHANGE.FSYORI_ID "                 '変更履歴       .処理ID
        strSQL &= vbCrLf & "   , TEVD_TBLCHANGE.FLOG_NO "                   '変更履歴       .ﾛｸﾞ№
        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TEVD_TBLCHANGE "                    '変更履歴ﾏｽﾀ

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & "     WHERE 0 = 0 "
        strSQLSearch = GetSQLSearch()
        strSQL &= strSQLSearch

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

        mblnGridDisplayingFlg = False

        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "　ﾘｽﾄ表示(下)　                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示(下)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay()

        Dim strSQL As String                    'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "     TEVD_TBLCHANGE_DTL.FTABLE_NAME "                   '変更履歴詳細.         ﾃｰﾌﾞﾙ名
        strSQL &= vbCrLf & "   , TEVD_TBLCHANGE_DTL.FSYORI_ID "                     '変更履歴詳細.         処理ID
        strSQL &= vbCrLf & "   , TEVD_TBLCHANGE_DTL.FLOG_NO "                       '変更履歴詳細.         ﾛｸﾞ№
        strSQL &= vbCrLf & "   , TEVD_TBLCHANGE_DTL.FFIELD_NAME "                   '変更履歴詳細.         ﾌｨｰﾙﾄﾞ名
        strSQL &= vbCrLf & "   , TEVD_TBLCHANGE_DTL.FVALUE_BEFORE "                 '変更履歴詳細.         更新前情報
        strSQL &= vbCrLf & "   , TEVD_TBLCHANGE_DTL.FVALUE_AFTER "                  '変更履歴詳細.         更新後情報
        strSQL &= vbCrLf & "   , TMST_TBLCHANGE.FGAMEN_DISP "                       '変更履歴表示ﾏｽﾀ.      表示用名称
        strSQL &= vbCrLf & "   , TMST_TBLCHANGE.FWIDTH_CELL "                       '変更履歴表示ﾏｽﾀ.      ｾﾙ幅
        strSQL &= vbCrLf & "   , TMST_TBLCHANGE.FTEXT_ALIGN "                       '変更履歴表示ﾏｽﾀ.      ﾃｷｽﾄ配置位置
        strSQL &= vbCrLf & "   , TMST_TBLCHANGE.FDISP_FORMAT "                      '変更履歴表示ﾏｽﾀ.      表示ﾌｫｰﾏｯﾄ
        strSQL &= vbCrLf & "   , TMST_TBLCHANGE.FDATA_TYPE "                        '変更履歴表示ﾏｽﾀ.      ﾃﾞｰﾀﾀｲﾌﾟ

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TEVD_TBLCHANGE_DTL "                                '変更履歴とﾃｰﾌﾞﾙ変更履歴表示ﾏｽﾀ
        strSQL &= vbCrLf & "   , TMST_TBLCHANGE "

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        0 = 0 "         '必ず通る条件
        strSQL &= vbCrLf & "    AND TEVD_TBLCHANGE_DTL.FTABLE_NAME = TMST_TBLCHANGE.FTABLE_NAME "   'ﾃｰﾌﾞﾙ名で内部結合
        strSQL &= vbCrLf & "    AND TEVD_TBLCHANGE_DTL.FFIELD_NAME = TMST_TBLCHANGE.FFIELD_NAME  "  'ﾌｨｰﾙﾄﾞ名で内部結合
        strSQL &= vbCrLf & "    AND TEVD_TBLCHANGE_DTL.FSYORI_ID = TMST_TBLCHANGE.FSYORI_ID  "      '処理IDで内部結合
        '----------------------------
        ' 処理ID
        '----------------------------
        strSQL &= vbCrLf & "    AND TEVD_TBLCHANGE_DTL.FSYORI_ID = '" & mudtSEARCH_ITEM_VA.FSYORI_ID & "' "     '処理ID
        '----------------------------
        ' ﾛｸﾞ№
        '----------------------------
        strSQL &= vbCrLf & "    AND TEVD_TBLCHANGE_DTL.FLOG_NO = '" & mudtSEARCH_ITEM_VA.FLOG_NO & "' "              'ﾛｸﾞ№
        '----------------------------
        ' 詳細一覧表示ﾌﾗｸﾞ
        '----------------------------
        strSQL &= vbCrLf & "    AND TMST_TBLCHANGE.FDTLDSP_FLAG = '" & FLAG_ON & "' "                   '詳細一覧表示ﾌﾗｸﾞ = 1

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    TMST_TBLCHANGE.FORDER "                             '変更履歴表示ﾏｽﾀ.      表示順
        strSQL &= vbCrLf


        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        gobjDb.SQL = strSQL
        strDataSetName = "TEVD_TBLCHANGE_DTL"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        Dim objPoint As Point = Nothing




        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(取得ﾃﾞｰﾀが存在する場合)

            'ﾘｽﾄﾗﾍﾞﾙ表示設定
            lblLst.Visible = True

            '=======================================
            'ｽｸﾛｰﾙﾊﾞｰ位置保持(ﾘｽﾄ選択処理で使用)
            '=======================================
            objPoint = New Point(grdList2.HorizontalScrollingOffset, grdList2.FirstDisplayedScrollingRowIndex)

            Try
                '*********************************************
                ' ｸﾞﾘｯﾄﾞ2設定
                '*********************************************
                'grdList2.Cols.Fixed = 1
                Call gobjComFuncFRM.FlexGridInitialize(grdList2, 3, objDataSet.Tables(strDataSetName).Rows.Count)                     'ｸﾞﾘｯﾄﾞ初期設定
                grdList2.RowCount = 2
                grdList2.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                ''grdList2.Columns(0).Frozen = True
                ''grdList2.Columns(0).DefaultCellStyle.BackColor = Color.FromArgb(128, 128, 255) '列ﾍｯﾀﾞ色調整
                ''grdList2.Columns(0).DefaultCellStyle.ForeColor = Color.Yellow

                grdList2.RowHeadersVisible = True
                grdList2.Rows(0).HeaderCell.Value = "変更前"
                grdList2.Rows(1).HeaderCell.Value = "変更後"

                ''Call grdListDispSetup(0, _
                ''                      "項目名", _
                ''                      "", _
                ''                      "", _
                ''                      "変更前", _
                ''                      "変更後", _
                ''                      100, _
                ''                      32, _
                ''                      "", _
                ''                      FDATA_TYPE_VARCHAR)         '列ﾍｯﾀﾞ設定


                ''Dim intII As Integer = 1
                Dim intII As Integer = 0
                For Each objRow In objDataSet.Tables(strDataSetName).Rows

                    '**********************************************************************************
                    ' ﾃﾞｰﾀ取得
                    '**********************************************************************************
                    Dim strFGAMEN_DISP As String = TO_STRING(objRow("FGAMEN_DISP"))     '表示用名称
                    Dim strFTABLE_NAME As String = TO_STRING(objRow("FTABLE_NAME"))     'ﾃｰﾌﾞﾙ名
                    Dim strFFIELD_NAME As String = TO_STRING(objRow("FFIELD_NAME"))     'ﾌｨｰﾙﾄﾞ名
                    Dim strFVALUE_BEFORE As String = TO_STRING(objRow("FVALUE_BEFORE")) '更新前情報
                    Dim strFVALUE_AFTER As String = TO_STRING(objRow("FVALUE_AFTER"))   '更新後情報
                    Dim strFWIDTH_CELL As String = TO_STRING(objRow("FWIDTH_CELL"))     'ｾﾙ幅
                    Dim intFTEXT_ALIGN As Integer = TO_INTEGER(objRow("FTEXT_ALIGN"))   'ﾃｷｽﾄ配置位置
                    Dim strFDISP_FORMAT As String = TO_STRING(objRow("FDISP_FORMAT"))   '表示ﾌｫｰﾏｯﾄ
                    Dim intFDATA_TYPE As Integer = TO_INTEGER(objRow("FDATA_TYPE"))     'ﾃﾞｰﾀﾀｲﾌﾟ


                    '********************************************************************
                    'ｸﾞﾘｯﾄﾞ表示設定
                    '********************************************************************
                    Call grdListDispSetup(intII, _
                                          strFGAMEN_DISP, _
                                          strFTABLE_NAME, _
                                          strFFIELD_NAME, _
                                          strFVALUE_BEFORE, _
                                          strFVALUE_AFTER, _
                                          strFWIDTH_CELL, _
                                          intFTEXT_ALIGN, _
                                          strFDISP_FORMAT, _
                                          intFDATA_TYPE)
                    intII += 1

                Next


                '********************************************************************
                '列の並替禁止
                '********************************************************************
                For Each objColum As DataGridViewColumn In grdList2.Columns
                    objColum.SortMode = DataGridViewColumnSortMode.NotSortable                    '列の並替禁止
                Next


            Catch ex As Exception
                Throw ex

            End Try

        End If

        Call gobjComFuncFRM.GridSelect(grdList2, -1, -1, objPoint)      'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "  ﾘｽﾄ表示設定(上)　                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示設定(上)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)


    End Sub
#End Region
#Region "  ﾘｽﾄ表示設定(下)　                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示設定(下)
    ''' </summary>
    ''' <param name="intColNo">列番号</param>
    ''' <param name="strGamenDisp">表示用列名称</param>
    ''' <param name="strTableName">ﾃｰﾌﾞﾙ名</param>
    ''' <param name="strFieldName">ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strValueBefore">更新前情報</param>
    ''' <param name="strValueAfter">更新後情報</param>
    ''' <param name="strWidthCell">ｾﾙ幅</param>
    ''' <param name="intTextAlign">ﾃｷｽﾄ配置位置</param>
    ''' <param name="strDispFormat">表示ﾌｫｰﾏｯﾄ</param>
    ''' <param name="intDataType">表示ﾌｫｰﾏｯﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDispSetup(ByVal intColNo As Integer, _
                                 ByVal strGamenDisp As String, _
                                 ByVal strTableName As String, _
                                 ByVal strFieldName As String, _
                                 ByVal strValueBefore As String, _
                                 ByVal strValueAfter As String, _
                                 ByVal strWidthCell As String, _
                                 ByVal intTextAlign As Integer, _
                                 ByVal strDispFormat As String, _
                                 ByVal intDataType As Integer)

        '=========================================
        'ﾍｯﾀﾞｰ表示変更
        '=========================================
        grdList2.Columns(intColNo).HeaderText = strGamenDisp.Replace(REPLACE_STRING_01, vbCrLf)


        '=========================================
        'ﾍｯﾀﾞｰ部配置変更
        '=========================================
        grdList2.Columns(intColNo).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter


        '=========================================
        'ﾃﾞｰﾀ部配置変更
        '=========================================
        grdList2.Columns(intColNo).DefaultCellStyle.Alignment = intTextAlign


        '=========================================
        '列幅調整
        '=========================================
        grdList2.Columns(intColNo).Width = strWidthCell


        '=========================================
        'ﾃﾞｰﾀｾｯﾄ
        '=========================================
        If strDispFormat <> "" Then
            '(ﾌｫｰﾏｯﾄがｾｯﾄされている場合)
            Select Case intDataType
                Case FDATA_TYPE_SDATE
                    '(日付型の場合)
                    grdList2.Item(intColNo, 0).Value = Format(TO_DATE_NULLABLE(strValueBefore), strDispFormat)           '変更前
                    grdList2.Item(intColNo, 1).Value = Format(TO_DATE_NULLABLE(strValueAfter), strDispFormat)            '変更後
                Case FDATA_TYPE_SNUMBER
                    '(数値型の場合)
                    grdList2.Item(intColNo, 0).Value = Format(TO_INTEGER_NULLABLE(strValueBefore), strDispFormat)        '変更前
                    grdList2.Item(intColNo, 1).Value = Format(TO_INTEGER_NULLABLE(strValueAfter), strDispFormat)         '変更後
                Case FDATA_TYPE_SVARCHAR
                    '(文字列型の場合)
                    grdList2.Item(intColNo, 0).Value = Format(strValueBefore, strDispFormat)         '変更前
                    grdList2.Item(intColNo, 1).Value = Format(strValueAfter, strDispFormat)          '変更後
                Case Else
                    '(その他の場合)
                    grdList2.Item(intColNo, 0).Value = strValueBefore           '変更前
                    grdList2.Item(intColNo, 1).Value = strValueAfter            '変更後
            End Select
        Else
            '(ﾌｫｰﾏｯﾄがｾｯﾄされていない場合)

            '=========================================
            '表示用ﾃﾞｰﾀ取得
            '=========================================
            grdList2.Item(intColNo, 0).Value = gobjComFuncFRM.GetTDSP_DISP(strTableName, strFieldName, strValueBefore)           '変更前
            grdList2.Item(intColNo, 1).Value = gobjComFuncFRM.GetTDSP_DISP(strTableName, strFieldName, strValueAfter)            '変更後


        End If

    End Sub
#End Region
#Region "　SQL文作成(条件部分)                      "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' SQL文作成(条件部分)
    ''' </summary>
    ''' <returns>SQL文(条件部分)</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function GetSQLSearch() As String
        Dim strSQL As String = ""

        '----------------------------
        ' 変更履歴情報
        '----------------------------
        If mudtSEARCH_ITEM.FSYORI_ID <> CBO_ALL_VALUE Then
            If mudtSEARCH_ITEM.FSYORI_ID = FSYORI_ID_S200701 Then
                '(担当者ﾏｽﾀﾒﾝﾃﾅﾝｽのとき)
                strSQL &= vbCrLf & "    AND TEVD_TBLCHANGE.FSYORI_ID IN ( '" & FSYORI_ID_S200701 & "') "    '変更履歴       .処理ID
            ElseIf mudtSEARCH_ITEM.FSYORI_ID = FSYORI_ID_S200401 Then
                '(在庫ﾒﾝﾃﾅﾝｽのとき)
                strSQL &= vbCrLf & "    AND TEVD_TBLCHANGE.FSYORI_ID IN ( '" & FSYORI_ID_S200401 & "') "    '変更履歴       .処理ID
            Else
                '(それ以外のとき)
                strSQL &= vbCrLf & "    AND TEVD_TBLCHANGE.FSYORI_ID = '" & mudtSEARCH_ITEM.FSYORI_ID & "' "     '変更履歴       .処理ID
            End If
        End If

        '----------------------------
        ' 変更者
        '----------------------------
        If mudtSEARCH_ITEM.FUSER_ID <> CBO_ALL_VALUE Then
            strSQL &= vbCrLf & "    AND TEVD_TBLCHANGE.FUSER_ID = '" & mudtSEARCH_ITEM.FUSER_ID & "' "           '変更履歴       .ﾕｰｻﾞｰID
        End If
        '----------------------------
        ' 期間 範囲指定 
        '----------------------------
        If mudtSEARCH_ITEM.KIKAN_FROM <> "" Then
            strSQL &= vbCrLf & "        AND TEVD_TBLCHANGE.FHASSEI_DT >= TO_DATE('" & mudtSEARCH_ITEM.KIKAN_FROM & "','YYYY/MM/DD HH24:MI:SS')"
        End If
        If mudtSEARCH_ITEM.KIKAN_TO <> "" Then
            strSQL &= vbCrLf & "        AND TEVD_TBLCHANGE.FHASSEI_DT <= TO_DATE('" & mudtSEARCH_ITEM.KIKAN_TO & "','YYYY/MM/DD HH24:MI:SS')"
        End If


        Return strSQL
    End Function
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <param name="udtCheck_Case">入力ﾁｪｯｸ判別</param>
    ''' <returns>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

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

            Case menmCheckCase.DetailBtn_Click
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

End Class
