'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                                      "
Imports MateCommon
Imports MateCommon.clsConst
Imports MateCommon.mdlComFunc
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_299001

#Region "　共通変数　                                   "

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

#Region "  列挙体　                                     "
    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        Search_Click        '検索ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FLOG_NO_CYCLIC                  'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ｻｲｸﾘｯｸﾛｸﾞ№
        FHASSEI_DT                      'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      発生日時
        FUSER_ID                         'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾕｰｻﾞｰID
        FTERM_ID                        'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      端末ID
        FSYORI_ID                       'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      処理ID
        FMSG_PRM1                       'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾊﾟﾗﾒｰﾀ1
        FMSG_PRM2                       'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾊﾟﾗﾒｰﾀ2
        FMSG_PRM3                       'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾊﾟﾗﾒｰﾀ3
        FMSG_PRM4                       'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾊﾟﾗﾒｰﾀ4
        FMSG_PRM5                       'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾊﾟﾗﾒｰﾀ5
        FLOG_DATA_TRN                   'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞﾃﾞｰﾀ

        MAXCOL

    End Enum

#End Region

#End Region
#Region "  構造体定義                                   "
    ''' <summary>検索条件</summary>
    Private Structure SEARCH_ITEM
        Dim FHASSEI_DT_FROM As String           '発生日時(FROM)
        Dim FHASSEI_DT_TO As String             '発生日時(TO)
        Dim FUSER_ID As String                   'ﾕｰｻﾞｰID
        Dim FTERM_ID As String                  '端末ID
        Dim FSYORI_ID As String                 '処理ID
        Dim FMSG_PRM1 As String                 'ﾊﾟﾗﾒｰﾀ1
        Dim FMSG_PRM2 As String                 'ﾊﾟﾗﾒｰﾀ2
        Dim FMSG_PRM3 As String                 'ﾊﾟﾗﾒｰﾀ3
        Dim FMSG_PRM4 As String                 'ﾊﾟﾗﾒｰﾀ4
        Dim FMSG_PRM5 As String                 'ﾊﾟﾗﾒｰﾀ5
        Dim FLOG_DATA_TRN As String             'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞﾃﾞｰﾀ

    End Structure
#End Region
#Region "　ｲﾍﾞﾝﾄ                                        "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_299001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call FormLoad()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_299001_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Call FormClose()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　表示ﾎﾞﾀﾝ                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示ﾎﾞﾀﾝ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdDisp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisp.Click
        Try
            Call cmdDispProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　閉じるﾎﾞﾀﾝ                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' じるﾎﾞﾀﾝ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try
            Call cmdCloseProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#End Region

#Region "  ﾌｫｰﾑﾛｰﾄﾞ処理                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormLoad()

        '****************************************
        'ﾎﾞﾀﾝEnable
        '****************************************
        cmdDisp.Enabled = True    '表示ﾎﾞﾀﾝ
        cmdClose.Enabled = True    '閉じるﾎﾞﾀﾝ

        '****************************************
        '期間           ｾｯﾄ
        '****************************************
        Call dtpKikanFromToSetup(dtpDate_From, dtpTime_From, dtpDate_To, dtpTime_To)

        '****************************************
        'ﾕｰｻﾞｰIDｺﾝﾎﾞ ｾｯﾄ
        '****************************************
        Call cboEnpMake(cboFUSER_ID)

        '****************************************
        '端末IDｺﾝﾎﾞ     ｾｯﾄ
        '****************************************
        Call cboTermMake(cboFTERM_ID)

        '****************************************
        '処理IDｺﾝﾎﾞ     ｾｯﾄ
        '****************************************
        Call cboSyoriMake(cboFSYORI_ID)

        '****************************************
        'ｸﾞﾘｯﾄﾞ初期設定
        '****************************************
        grdList.ColumnCount = menmListCol.MAXCOL
        Call grdListSetup(grdList)

    End Sub
#End Region
#Region "　ﾌｫｰﾑｸﾛｰｽﾞ処理                                "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｸﾛｰｽﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub FormClose()

    End Sub
#End Region
#Region "　表示ﾎﾞﾀﾝｸﾘｯｸ処理                             "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' 表示ﾎﾞﾀﾝｸﾘｯｸ処理 
    ''' </summary>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub cmdDispProcess()

        '**********************************
        '構造体ｾｯﾄ
        '**********************************
        Call SearchItem_Set()

        '**********************************
        'ｸﾞﾘｯﾄﾞ表示
        '**********************************
        Call grdListDisplay()

    End Sub
#End Region
#Region "　閉じるﾎﾞﾀﾝｸﾘｯｸ処理                           "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' 閉じるﾎﾞﾀﾝｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub cmdCloseProcess()

        '**********************************
        '画面終了
        '**********************************
        Me.Close()

    End Sub
#End Region
#Region "　ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示　                             "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub grdListDisplay()

        Dim strSQL As String                        'SQL文
        Dim blnDispOkFlg As Boolean = True          '表示するかどうかのﾌﾗｸﾞ

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     TLOG_TRNS.FLOG_NO_CYCLIC "                                 'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ｻｲｸﾘｯｸﾛｸﾞ№
        strSQL &= vbCrLf & "   , TO_CHAR(TLOG_TRNS.FHASSEI_DT,'YYYY/MM/DD HH24:MI:SS') "    'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      発生日時
        strSQL &= vbCrLf & "   , TLOG_TRNS.FUSER_ID "                                        'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾕｰｻﾞｰID
        strSQL &= vbCrLf & "   , TLOG_TRNS.FTERM_ID "                                       'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      端末ID
        strSQL &= vbCrLf & "   , TLOG_TRNS.FSYORI_ID "                                      'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      処理ID
        strSQL &= vbCrLf & "   , TLOG_TRNS.FMSG_PRM1 "                                      'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾊﾟﾗﾒｰﾀ1
        strSQL &= vbCrLf & "   , TLOG_TRNS.FMSG_PRM2 "                                      'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾊﾟﾗﾒｰﾀ2
        strSQL &= vbCrLf & "   , TLOG_TRNS.FMSG_PRM3 "                                      'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾊﾟﾗﾒｰﾀ3
        strSQL &= vbCrLf & "   , TLOG_TRNS.FMSG_PRM4 "                                      'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾊﾟﾗﾒｰﾀ4
        strSQL &= vbCrLf & "   , TLOG_TRNS.FMSG_PRM5 "                                      'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾊﾟﾗﾒｰﾀ5
        strSQL &= vbCrLf & "   , TLOG_TRNS.FLOG_DATA_TRN "                                  'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞﾃﾞｰﾀ
        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TLOG_TRNS "
        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        '--------------------------
        '期間
        '--------------------------
        'FROM
        If mudtSEARCH_ITEM.FHASSEI_DT_FROM <> "" And IsDate(mudtSEARCH_ITEM.FHASSEI_DT_FROM) Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FHASSEI_DT >= TO_DATE('" & mudtSEARCH_ITEM.FHASSEI_DT_FROM & "','YYYY/MM/DD HH24:MI:SS')"          'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.     発生日時
        End If
        'TO
        If mudtSEARCH_ITEM.FHASSEI_DT_TO <> "" And IsDate(mudtSEARCH_ITEM.FHASSEI_DT_TO) Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FHASSEI_DT <= TO_DATE('" & mudtSEARCH_ITEM.FHASSEI_DT_TO & "','YYYY/MM/DD HH24:MI:SS')"            'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.     発生日時
        End If
        '--------------------------
        'ﾕｰｻﾞｰID
        '--------------------------
        If mudtSEARCH_ITEM.FUSER_ID <> "" And mudtSEARCH_ITEM.FUSER_ID <> CBO_ALL_VALUE Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FUSER_ID = '" & mudtSEARCH_ITEM.FUSER_ID & "' "
        End If
        '--------------------------
        '端末ID
        '--------------------------
        If mudtSEARCH_ITEM.FTERM_ID <> "" And mudtSEARCH_ITEM.FTERM_ID <> CBO_ALL_VALUE Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FTERM_ID = '" & mudtSEARCH_ITEM.FTERM_ID & "' "
        End If
        '--------------------------
        '処理ID
        '--------------------------
        If mudtSEARCH_ITEM.FSYORI_ID <> "" And mudtSEARCH_ITEM.FSYORI_ID <> CBO_ALL_VALUE Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FSYORI_ID = '" & mudtSEARCH_ITEM.FSYORI_ID & "' "
        End If
        '--------------------------
        'ﾒｯｾｰｼﾞﾊﾟﾗﾒｰﾀ1～5
        '--------------------------
        If mudtSEARCH_ITEM.FMSG_PRM1 <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FMSG_PRM1 LIKE '%" & mudtSEARCH_ITEM.FMSG_PRM1 & "%' "
        End If
        If mudtSEARCH_ITEM.FMSG_PRM2 <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FMSG_PRM2 LIKE '%" & mudtSEARCH_ITEM.FMSG_PRM2 & "%' "
        End If
        If mudtSEARCH_ITEM.FMSG_PRM3 <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FMSG_PRM3 LIKE '%" & mudtSEARCH_ITEM.FMSG_PRM3 & "%' "
        End If
        If mudtSEARCH_ITEM.FMSG_PRM4 <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FMSG_PRM4 LIKE '%" & mudtSEARCH_ITEM.FMSG_PRM4 & "%' "
        End If
        If mudtSEARCH_ITEM.FMSG_PRM5 <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FMSG_PRM5 LIKE '%" & mudtSEARCH_ITEM.FMSG_PRM5 & "%' "
        End If
        '--------------------------
        'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞﾃﾞｰﾀ
        '--------------------------
        If mudtSEARCH_ITEM.FLOG_DATA_TRN <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_TRNS.FLOG_DATA_TRN LIKE '%" & mudtSEARCH_ITEM.FLOG_DATA_TRN & "%' "
        End If


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     TLOG_TRNS.FHASSEI_DT DESC "              'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      発生日時(降順)
        strSQL &= vbCrLf & "   , TLOG_TRNS.FLOG_NO_CYCLIC "                         'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ｻｲｸﾘｯｸﾛｸﾞ№(昇順)
        strSQL &= vbCrLf

        '============================================================
        '表示件数ﾁｪｯｸ
        '============================================================
        '表示件数ﾁｪｯｸ処理(件数が多い場合はﾒｯｾｰｼﾞ表示)
        Call ChckDataCount(strSQL, blnDispOkFlg)
        '表示判別ﾌﾗｸﾞがFalseの場合は表示しない。
        If blnDispOkFlg = False Then
            Exit Sub
        End If

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        gobjDb.SQL = strSQL
        strDataSetName = "TLOG_TRNS"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        grdList.Columns.Clear()
        'ﾃﾞｰﾀｿｰｽｸﾘｱ
        If IsNull(grdList.DataSource) = False Then
            grdList.DataSource.Rows.Clear()
            grdList.DataSource.Dispose()
            grdList.DataSource = Nothing
        End If
        grdList.DataSource = objDataSet.Tables(strDataSetName)
        objDataSet = Nothing

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup(grdList)


    End Sub
#End Region
#Region "　ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示設定                           "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示設定
    ''' </summary>
    ''' <param name="objGrid">設定するｸﾞﾘｯﾄﾞｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub grdListSetup(ByRef objGrid As DataGridView)

        '***********************
        '初期設定
        '***********************
        objGrid.RowHeadersVisible = False                                   '行ﾍｯﾀﾞｰ表示        許可設定
        objGrid.AllowUserToResizeColumns = True                             '列のｻｲｽﾞ変更       許可設定
        objGrid.MultiSelect = False                                         '複数ｾﾙ同時選択     許可設定
        objGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect     '選択ﾓｰﾄﾞ
        objGrid.AllowUserToAddRows = False                                  '行追加             許可設定
        objGrid.AllowUserToDeleteRows = False                               '行削除             許可設定
        objGrid.AllowUserToResizeRows = False                               '行ｻｲｽﾞ変更         許可設定
        objGrid.AllowUserToOrderColumns = False                             '列移動             許可設定
        For Each objColum As DataGridViewColumn In objGrid.Columns
            objColum.SortMode = DataGridViewColumnSortMode.Programmatic     '列の並替禁止
        Next
        objGrid.ReadOnly = True                                             'ｸﾞﾘｯﾄﾞ読取専用設定

        '***********************
        'ﾍｯﾀﾞｰ表示変更
        '***********************
        objGrid.Columns(menmListCol.FLOG_NO_CYCLIC).HeaderText = "ｻｲｸﾘｯｸﾛｸﾞ№"                'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ｻｲｸﾘｯｸﾛｸﾞ№
        objGrid.Columns(menmListCol.FHASSEI_DT).HeaderText = "発生日時"                       'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      発生日時
        objGrid.Columns(menmListCol.FUSER_ID).HeaderText = "ﾕｰｻﾞｰID"                        'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾕｰｻﾞｰID
        objGrid.Columns(menmListCol.FTERM_ID).HeaderText = "端末ID"                           'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      端末ID
        objGrid.Columns(menmListCol.FSYORI_ID).HeaderText = "処理ID"                          'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      処理ID
        objGrid.Columns(menmListCol.FMSG_PRM1).HeaderText = "ﾊﾟﾗﾒｰﾀ1"                         'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾊﾟﾗﾒｰﾀ1
        objGrid.Columns(menmListCol.FMSG_PRM2).HeaderText = "ﾊﾟﾗﾒｰﾀ2"                         'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾊﾟﾗﾒｰﾀ2
        objGrid.Columns(menmListCol.FMSG_PRM3).HeaderText = "ﾊﾟﾗﾒｰﾀ3"                         'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾊﾟﾗﾒｰﾀ3
        objGrid.Columns(menmListCol.FMSG_PRM4).HeaderText = "ﾊﾟﾗﾒｰﾀ4"                         'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾊﾟﾗﾒｰﾀ4
        objGrid.Columns(menmListCol.FMSG_PRM5).HeaderText = "ﾊﾟﾗﾒｰﾀ5"                         'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾊﾟﾗﾒｰﾀ5
        objGrid.Columns(menmListCol.FLOG_DATA_TRN).HeaderText = "ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞﾃﾞｰﾀ"            'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ.      ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞﾃﾞｰﾀ

        '***********************
        'ﾃﾞｰﾀ部配置変更
        '***********************
        objGrid.Columns(menmListCol.FLOG_NO_CYCLIC).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FHASSEI_DT).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FUSER_ID).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FTERM_ID).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FSYORI_ID).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FMSG_PRM1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FMSG_PRM2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FMSG_PRM3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FMSG_PRM4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FMSG_PRM5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.FLOG_DATA_TRN).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        '***********************
        '非表示
        '***********************
        ''objGrid.Columns(menmListCol.Data04).Visible = False
        ''objGrid.Columns(menmListCol.Data05).Visible = False

        '***********************
        '列幅調整
        '***********************
        objGrid.Columns(menmListCol.FLOG_NO_CYCLIC).Width = 100
        objGrid.Columns(menmListCol.FHASSEI_DT).Width = 120
        objGrid.Columns(menmListCol.FUSER_ID).Width = 100
        objGrid.Columns(menmListCol.FTERM_ID).Width = 100
        objGrid.Columns(menmListCol.FSYORI_ID).Width = 100
        objGrid.Columns(menmListCol.FMSG_PRM1).Width = 150
        objGrid.Columns(menmListCol.FMSG_PRM2).Width = 150
        objGrid.Columns(menmListCol.FMSG_PRM3).Width = 150
        objGrid.Columns(menmListCol.FMSG_PRM4).Width = 150
        objGrid.Columns(menmListCol.FMSG_PRM5).Width = 150
        objGrid.Columns(menmListCol.FLOG_DATA_TRN).Width = 300

        ' ''***********************
        ' ''編集ﾛｯｸ
        ' ''***********************
        ''objGrid.Columns(menmListCol.ItemName).ReadOnly = True
        ''objGrid.Columns(menmListCol.Data).ReadOnly = False
        ''objGrid.Columns(menmListCol.Item).ReadOnly = True
        ''objGrid.Columns(menmListCol.Size).ReadOnly = True

        '***********************
        'ｸﾞﾘｯﾄﾞ色替え
        '***********************
        Call grdListChangeColor(grdList)

        '***********************
        '初期選択
        '***********************
        Try
            'ﾃﾞｰﾀが表示されない場合もある為
            objGrid(-1, -1).Selected = True
        Catch ex As Exception
        End Try

    End Sub
#End Region
#Region "　表示件数ﾁｪｯｸ                                 "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' 表示件数ﾁｪｯｸ
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <param name="blnDspOkFlg"></param>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub ChckDataCount(ByVal strSQL As String, _
                              ByRef blnDspOkFlg As Boolean)

        Dim strCountSQL As String
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim lngDataRowCount As Long = 0         'ﾃﾞｰﾀ数
        Dim lngChckRows As Long = 100000         '比較件数

        strCountSQL = ""
        strCountSQL &= vbCrLf & " SELECT "
        strCountSQL &= vbCrLf & "      COUNT(*) AS ROW_COUNT "
        strCountSQL &= vbCrLf & " FROM "
        strCountSQL &= vbCrLf & "      ( "
        strCountSQL &= vbCrLf & strSQL
        strCountSQL &= vbCrLf & "      )"


        gobjDb.SQL = strCountSQL
        strDataSetName = "CountDataRow"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        lngDataRowCount = CLng(objDataSet.Tables(strDataSetName).Rows(0).Item("ROW_COUNT"))
        objDataSet.Dispose()
        objDataSet = Nothing

        '表示件数ﾁｪｯｸ
        If lngChckRows < lngDataRowCount Then
            '(設定数値よりも取得件数が多い場合)
            Dim strMsg As String
            Dim udtMsgRet As DialogResult

            '表示するかのﾒｯｾｰｼﾞ表示
            strMsg = "件数が" & CStr(lngChckRows) & "を超えています。" & vbCrLf & "表示しますか？"
            udtMsgRet = _
                MessageBox.Show(strMsg, "ﾒｯｾｰｼﾞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            'YES/NOの分岐処理
            If udtMsgRet = Windows.Forms.DialogResult.Yes Then
                '(Yesﾎﾞﾀﾝが押された場合)
                blnDspOkFlg = True          '表示判断ﾌﾗｸﾞ=TURE
            Else
                '(その他)
                blnDspOkFlg = False         '表示判別ﾌﾗｸﾞ=FALSE
            End If
        End If

    End Sub
#End Region
#Region "　期間設定                                     "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' 期間設定
    ''' </summary>
    ''' <param name="dtpFromDate">開始日付</param>
    ''' <param name="dtpFromTime">開始時間</param>
    ''' <param name="dtpToDate">終了日付</param>
    ''' <param name="dtpToTime">終了時間</param>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub dtpKikanFromToSetup(ByRef dtpFromDate As System.Windows.Forms.DateTimePicker, _
                                    ByRef dtpFromTime As System.Windows.Forms.DateTimePicker, _
                                    ByRef dtpToDate As System.Windows.Forms.DateTimePicker, _
                                    ByRef dtpToTime As System.Windows.Forms.DateTimePicker)
        Dim dtmFrom As Date                 'From 日時
        '' ''Dim dtmTo As Date                   'To   日時
        Dim dtmNow As Date = Now            '現在日時

        '*********************************************
        ' 期間初期化
        '*********************************************
        dtmFrom = DateAdd(DateInterval.Minute, _
                          Val("-" & gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_008)), _
                          dtmNow)


        dtpFromDate.Value = dtmFrom
        dtpFromTime.Value = dtmFrom
        dtpToDate.Value = dtpToDate.MaxDate
        dtpToTime.Value = dtpToDate.MaxDate

    End Sub
#End Region
#Region "　ｺﾝﾎﾞﾎﾞｯｸｽ作成(ﾕｰｻﾞｰID)                    "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽ作成(ﾕｰｻﾞｰID)
    ''' </summary>
    ''' <param name="objCbo"></param>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub cboEnpMake(ByRef objCbo As System.Windows.Forms.ComboBox)

        objCbo.Items.Clear()

        Dim strDisp As String = ""                          'ｺﾝﾎﾞﾎﾞｯｸｽ表示ﾃﾞｰﾀ
        Dim strData As String = ""                          'ｺﾝﾎﾞﾎﾞｯｸｽ内部ﾃﾞｰﾀ
        Dim strSQL As String                                'SQL文
        Dim lngCnt As Long = 0                              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim clsList(0) As GamenCommon.clsCboData            'ｺﾝﾎﾞ用配列

        '選択なし行追加
        clsList(0) = New GamenCommon.clsCboData("", CBO_ALL_VALUE)

        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     FUSER_ID "
        strSQL &= vbCrLf & "   , FUSER_NAME "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TMST_USER "
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     FUSER_ID "

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        gobjDb.SQL = strSQL
        strDataSetName = "TMST_USER"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        Dim objRow As DataRow
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                lngCnt = lngCnt + 1
                ReDim Preserve clsList(lngCnt)
                clsList(lngCnt) = New GamenCommon.clsCboData(CStr(objRow("FUSER_ID")), CStr(objRow("FUSER_ID")))

            Next
        End If

        objCbo.DataSource = clsList

        objCbo.ValueMember = "Value"
        objCbo.DisplayMember = "Disp"

        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ1行目選択設定
        '*******************************************************
        objCbo.SelectedIndex = 0


    End Sub
#End Region
#Region "　ｺﾝﾎﾞﾎﾞｯｸｽ作成(端末ID)                        "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽ作成(端末ID)
    ''' </summary>
    ''' <param name="objCbo"></param>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub cboTermMake(ByRef objCbo As System.Windows.Forms.ComboBox)

        objCbo.Items.Clear()

        Dim strDisp As String = ""                          'ｺﾝﾎﾞﾎﾞｯｸｽ表示ﾃﾞｰﾀ
        Dim strData As String = ""                          'ｺﾝﾎﾞﾎﾞｯｸｽ内部ﾃﾞｰﾀ
        Dim strSQL As String                                'SQL文
        Dim lngCnt As Long = 0                              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim clsList(0) As GamenCommon.clsCboData            'ｺﾝﾎﾞ用配列

        '選択なし行追加
        clsList(0) = New GamenCommon.clsCboData("", CBO_ALL_VALUE)

        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     FTERM_ID "
        strSQL &= vbCrLf & "   , FTERM_NAME "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TDSP_TERM "
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     FTERM_ID "

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        gobjDb.SQL = strSQL
        strDataSetName = "TDSP_TERM"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        Dim objRow As DataRow
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                lngCnt = lngCnt + 1
                ReDim Preserve clsList(lngCnt)
                clsList(lngCnt) = New GamenCommon.clsCboData(CStr(objRow("FTERM_ID")), CStr(objRow("FTERM_ID")))

            Next
        End If

        objCbo.DataSource = clsList

        objCbo.ValueMember = "Value"
        objCbo.DisplayMember = "Disp"

        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ1行目選択設定
        '*******************************************************
        objCbo.SelectedIndex = 0


    End Sub
#End Region
#Region "　ｺﾝﾎﾞﾎﾞｯｸｽ作成(処理ID)                        "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽ作成(処理ID)
    ''' </summary>
    ''' <param name="objCbo"></param>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub cboSyoriMake(ByRef objCbo As System.Windows.Forms.ComboBox)

        objCbo.Items.Clear()

        Dim strDisp As String = ""                          'ｺﾝﾎﾞﾎﾞｯｸｽ表示ﾃﾞｰﾀ
        Dim strData As String = ""                          'ｺﾝﾎﾞﾎﾞｯｸｽ内部ﾃﾞｰﾀ
        Dim strSQL As String                                'SQL文
        Dim lngCnt As Long = 0                              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim clsList(0) As GamenCommon.clsCboData            'ｺﾝﾎﾞ用配列

        '選択なし行追加
        clsList(0) = New GamenCommon.clsCboData("", CBO_ALL_VALUE)

        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     FSYORI_ID "
        strSQL &= vbCrLf & "   , FCOMMENT "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TPRG_TIMER "
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     FSYORI_ID "

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        gobjDb.SQL = strSQL
        strDataSetName = "TPRG_TIMER"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        Dim objRow As DataRow
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                lngCnt = lngCnt + 1
                ReDim Preserve clsList(lngCnt)
                clsList(lngCnt) = New GamenCommon.clsCboData(CStr(objRow("FCOMMENT")), CStr(objRow("FSYORI_ID")))

            Next
        End If

        objCbo.DataSource = clsList

        objCbo.ValueMember = "Value"
        objCbo.DisplayMember = "Disp"

        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ1行目選択設定
        '*******************************************************
        objCbo.SelectedIndex = 0


    End Sub
#End Region

#Region "　構造体ｾｯﾄ　                                  "
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
        mudtSEARCH_ITEM.FHASSEI_DT_FROM = TO_STRING(dtpDate_From.Text & " " & dtpTime_From.Text)    '期間(FROM)
        mudtSEARCH_ITEM.FHASSEI_DT_TO = TO_STRING(dtpDate_To.Text & " " & dtpTime_To.Text)          '期間(TO)
        mudtSEARCH_ITEM.FUSER_ID = TO_STRING(cboFUSER_ID.SelectedValue)                               'ﾕｰｻﾞｰID
        mudtSEARCH_ITEM.FTERM_ID = TO_STRING(cboFTERM_ID.SelectedValue)                             '端末ID
        mudtSEARCH_ITEM.FSYORI_ID = TO_STRING(cboFSYORI_ID.SelectedValue)                           '処理ID
        mudtSEARCH_ITEM.FMSG_PRM1 = TO_STRING(txtFMSG_PRM1.Text)                                    'ﾒｯｾｰｼﾞﾊﾟﾗﾒｰﾀ1
        mudtSEARCH_ITEM.FMSG_PRM2 = TO_STRING(txtFMSG_PRM2.Text)                                    'ﾒｯｾｰｼﾞﾊﾟﾗﾒｰﾀ2
        mudtSEARCH_ITEM.FMSG_PRM3 = TO_STRING(txtFMSG_PRM3.Text)                                    'ﾒｯｾｰｼﾞﾊﾟﾗﾒｰﾀ3
        mudtSEARCH_ITEM.FMSG_PRM4 = TO_STRING(txtFMSG_PRM4.Text)                                    'ﾒｯｾｰｼﾞﾊﾟﾗﾒｰﾀ4
        mudtSEARCH_ITEM.FMSG_PRM5 = TO_STRING(txtFMSG_PRM5.Text)                                    'ﾒｯｾｰｼﾞﾊﾟﾗﾒｰﾀ5
        mudtSEARCH_ITEM.FLOG_DATA_TRN = TO_STRING(txtFLOG_DATA_TRNS_Srch.Text)                      'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞﾃﾞｰﾀ

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示時の色替え                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示時の色替え
    ''' </summary>
    ''' <param name="grdList">ｸﾞﾘｯﾄﾞ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListChangeColor(ByRef grdList As Windows.Forms.DataGridView)

        Dim strLogDataTrn As String     'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞﾃﾞｰﾀ
        Dim intCntCol As Integer           '行ｶｳﾝﾄ用
        Dim objTxtBox As Windows.Forms.TextBox
        Dim objColor As Color
        Dim intCntColor As Integer

        For lngCnt As Long = 0 To grdList.Rows.Count - 1
            strLogDataTrn = ""

            'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞﾃﾞｰﾀ取得
            strLogDataTrn = _
                grdList.Rows(lngCnt).Cells(menmListCol.FLOG_DATA_TRN).Value.ToString()


            For intCntColor = 1 To 4

                objTxtBox = Nothing
                objColor = Nothing

                Select Case intCntColor
                    Case 1
                        objTxtBox = txtLOG_DATA_Color4
                        objColor = Color.DeepSkyBlue
                    Case 2
                        objTxtBox = txtLOG_DATA_Color3
                        objColor = Color.Lime
                    Case 3
                        objTxtBox = txtLOG_DATA_Color2
                        objColor = Color.Yellow
                    Case 4
                        objTxtBox = txtLOG_DATA_Color1
                        objColor = Color.Red
                End Select

                If objTxtBox.Text <> "" Then
                    '(ﾃｷｽﾄが入力されている場合)

                    '-------------------------------
                    'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞﾃﾞｰﾀの文字列検索
                    '-------------------------------
                    If strLogDataTrn.IndexOf(objTxtBox.Text) >= 0 Then
                        '文字列が含まれている場合
                        For intCntCol = 0 To grdList.Columns.Count - 1
                            grdList.Rows(lngCnt).Cells(intCntCol).Style.BackColor = objColor    '色替え
                        Next
                    End If
                End If
            Next
        Next

    End Sub
#End Region
#Region "　ｴﾗｰ処理                                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="objException">ｴｸｾﾌﾟｼｮﾝ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ComError(ByVal objException As Exception)
        Try
            MsgBox(objException.Message)
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class