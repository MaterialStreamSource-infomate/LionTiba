'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】入出庫実績画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                                      "
Imports MateCommon
Imports MateCommon.clsConst
Imports MateCommon.mdlComFunc
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_299003

#Region "　共通変数　                                   "

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FLOG_NO             'INOUT実績.         ﾛｸﾞ№
        FLOT_NO_STOCK       'INOUT実績.         在庫ﾛｯﾄ№
        FRESULT_DT          'INOUT実績.         実績日時
        FPALLET_ID          'INOUT実績.         ﾊﾟﾚｯﾄID
        FBUF_FM             'INOUT実績.         元ﾊﾞｯﾌｧ№
        FARRAY_FM           'INOUT実績.         元配列№
        FBUF_TO             'INOUT実績.         先ﾊﾞｯﾌｧ№
        FARRAY_TO           'INOUT実績.         先配列№
        FINOUT_STS          'INOUT実績.         IN/OUT
        FSAGYOU_KIND        'INOUT実績.         作業種別
        FDISP_ADDRESS_FM    'INOUT実績.         FM表記用ｱﾄﾞﾚｽ
        FDISP_ADDRESS_TO    'INOUT実績.         TO表記用ｱﾄﾞﾚｽ
        FDISPLOG_ADDRESS_FM 'INOUT実績.         FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        FDISPLOG_ADDRESS_TO 'INOUT実績.         TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        FHINMEI_CD          'INOUT実績.         品名ｺｰﾄﾞ
        FLOT_NO             'INOUT実績.         ﾛｯﾄ№
        FARRIVE_DT          'INOUT実績.         在庫発生日時
        FIN_KUBUN           'INOUT実績.         入庫区分
        FSEIHIN_KUBUN       'INOUT実績.         製品区分
        FZAIKO_KUBUN        'INOUT実績.         在庫区分
        FST_FM              'INOUT実績.         元ｽﾃｰｼｮﾝ№
        FTR_VOL             'INOUT実績.         搬送管理量
        FTR_RES_VOL         'INOUT実績.         搬送引当量
        FTRNS_SERIAL        'INOUT実績.         搬送ｼﾘｱﾙ№
        FUSER_ID             'INOUT実績.         ﾕｰｻﾞｰID
        '**********************************************************************************************
        '↓↓↓ｼｽﾃﾑ固有
        FFORM               'INOUT実績.         型式
        FGOUKI              'INOUT実績.         号機
        '↑↑↑ｼｽﾃﾑ固有
        '**********************************************************************************************

        MAXCOL

    End Enum

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        SearchBtn_Click         '検索ﾎﾞﾀﾝｸﾘｯｸ時
        PrintBtn_Click          '印刷ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義　                                 "
    ''' <summary>検索条件</summary>
    Private Structure SEARCH_ITEM
        Dim KIKAN_FROM As String        '期間(FROM)
        Dim KIKAN_TO As String          '期間(TO)
        Dim FPALLET_ID As String        'ﾊﾟﾚｯﾄID
        Dim FINOUT_STS As String        '動作
        Dim FBUF_FM As String           'FROM
        Dim FBUF_TO As String           'TO
    End Structure
#End Region
#Region "　ｲﾍﾞﾝﾄ                                        "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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
#Region "　ﾊﾟﾚｯﾄIDﾎﾞﾀﾝ                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾟﾚｯﾄIDﾎﾞﾀﾝ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdPalletID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPalletID.Click
        Try
            Call cmdPalletIDProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　閉じるﾎﾞﾀﾝ                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 閉じるﾎﾞﾀﾝ
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
        cmdDisp.Enabled = True      '表示ﾎﾞﾀﾝ
        cmdPalletID.Enabled = True  'ﾊﾟﾚｯﾄIDﾎﾞﾀﾝ
        cmdClose.Enabled = True     '閉じるﾎﾞﾀﾝ

        '**********************************************************
        ' 期間                      ｾｯﾄ
        '**********************************************************
        Call dtpKikanFromToSetup(dtpKikanFromDate, _
                              dtpKikanFromTime, _
                              dtpKikanToDate, _
                              dtpKikanToTime)

        '**********************************************************
        ' 動作ｺﾝﾎﾞ                  ｾｯﾄ
        '**********************************************************
        Call cboDefaultMake("FRM_204010", cboFINOUT_STS)

        '**********************************************************
        ' FROM-TOｺﾝﾎﾞ               ｾｯﾄ
        '**********************************************************
        Call cboDspSTMake(cboFROM)
        Call cboDspSTMake(cboTO)

        '**********************************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ                 ｾｯﾄ
        '**********************************************************
        txtPallet_ID.Text = ""          'ﾊﾟﾚｯﾄID

        '****************************************
        ' ﾁｪｯｸﾘｽﾄﾎﾞｯｸｽ
        '****************************************
        Call chckLstBoxSetUp(chckLstColDsp)

        '****************************************
        'ｸﾞﾘｯﾄﾞ初期設定
        '****************************************
        grdList.ColumnCount = menmListCol.MAXCOL
        Call grdListSetup(grdList)


    End Sub
#End Region
#Region "　ﾌｫｰﾑｸﾛｰｽﾞ処理                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｸﾛｰｽﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormClose()

    End Sub
#End Region
#Region "　表示ﾎﾞﾀﾝｸﾘｯｸ処理                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示ﾎﾞﾀﾝｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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
#Region "　ﾊﾟﾚｯﾄIDﾎﾞﾀﾝｸﾘｯｸ処理                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾟﾚｯﾄIDﾎﾞﾀﾝｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdPalletIDProcess()

        '**********************************
        'ﾊﾟﾚｯﾄIDｾｯﾄ
        '**********************************
        If grdList.SelectedRows.Count > 0 Then
            '(ｾﾙ選択がある場合)
            Dim objSelectedRow As DataGridViewRow
            objSelectedRow = grdList.SelectedRows(0)
            txtPallet_ID.Text = CStr(objSelectedRow.Cells(menmListCol.FPALLET_ID).Value)
        End If

    End Sub
#End Region
#Region "　閉じるﾎﾞﾀﾝｸﾘｯｸ処理                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 閉じるﾎﾞﾀﾝｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCloseProcess()

        '**********************************
        '画面終了
        '**********************************
        Me.Close()

    End Sub
#End Region
#Region "　ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay()

        Dim strSQL As String                        'SQL文
        Dim blnDispOkFlg As Boolean = True          '表示するかどうかのﾌﾗｸﾞ
        Dim intDspRows As Integer

        '(ﾘｽﾄ表示最大件数500)
        intDspRows = 500

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     TLOG_INOUT_FULL.FLOG_NO "                      'INOUT実績.         ﾛｸﾞ№
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FLOT_NO_STOCK "                'INOUT実績.         在庫ﾛｯﾄ№
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FRESULT_DT "                   'INOUT実績.         実績日時
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FPALLET_ID "                   'INOUT実績.         ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FBUF_FM "                      'INOUT実績.         元ﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FARRAY_FM "                    'INOUT実績.         元配列№
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FBUF_TO "                      'INOUT実績.         先ﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FARRAY_TO "                    'INOUT実績.         先配列№
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FINOUT_STS "                   'INOUT実績.         IN/OUT
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FSAGYOU_KIND "                 'INOUT実績.         作業種別
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FDISP_ADDRESS_FM "             'INOUT実績.         FM表記用ｱﾄﾞﾚｽ
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FDISP_ADDRESS_TO "             'INOUT実績.         TO表記用ｱﾄﾞﾚｽ
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FDISPLOG_ADDRESS_FM "          'INOUT実績.         FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FDISPLOG_ADDRESS_TO "          'INOUT実績.         TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FHINMEI_CD "                   'INOUT実績.         品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FLOT_NO "                      'INOUT実績.         ﾛｯﾄ№
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FARRIVE_DT "                   'INOUT実績.         在庫発生日時
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FIN_KUBUN "                    'INOUT実績.         入庫区分
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FSEIHIN_KUBUN "                'INOUT実績.         製品区分
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FZAIKO_KUBUN "                 'INOUT実績.         在庫区分
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FST_FM "                       'INOUT実績.         元ｽﾃｰｼｮﾝ№
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FTR_VOL "                      'INOUT実績.         搬送管理量
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FTR_RES_VOL "                  'INOUT実績.         搬送引当量
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FTRNS_SERIAL "                 'INOUT実績.         搬送ｼﾘｱﾙ№
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FUSER_ID "                      'INOUT実績.         ﾕｰｻﾞｰID
        '**********************************************************************************************
        '↓↓↓ｼｽﾃﾑ固有
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FFORM "                        'INOUT実績.         型式
        strSQL &= vbCrLf & "   , TLOG_INOUT_FULL.FGOUKI "                       'INOUT実績.         号機
        '↑↑↑ｼｽﾃﾑ固有
        '**********************************************************************************************

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        '------------------------------------
        'SELECT
        '------------------------------------
        strSQL &= vbCrLf & "   ( SELECT "
        strSQL &= vbCrLf & "        ROW_NUMBER() "
        strSQL &= vbCrLf & "              OVER( ORDER BY TLOG_INOUT.FLOG_NO DESC ) AS REC"
        strSQL &= vbCrLf & "      , TLOG_INOUT.* "             'INOUT実績.         すべて
        '------------------------------------
        'FROM
        '------------------------------------
        strSQL &= vbCrLf & "     FROM "
        strSQL &= vbCrLf & "        TLOG_INOUT  "

        '------------------------------------
        'WHERE
        '------------------------------------
        strSQL &= vbCrLf & "     WHERE 1 = 1 "

        '----------------------------
        ' INOUT実績.期間 範囲指定 
        '----------------------------
        If mudtSEARCH_ITEM.KIKAN_FROM <> "" Then
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FRESULT_DT >= TO_DATE('" & mudtSEARCH_ITEM.KIKAN_FROM & "','YYYY/MM/DD HH24:MI:SS')"
        End If
        If mudtSEARCH_ITEM.KIKAN_TO <> "" Then
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FRESULT_DT <= TO_DATE('" & mudtSEARCH_ITEM.KIKAN_TO & "','YYYY/MM/DD HH24:MI:SS')"
        End If

        '-----------------------------
        'ﾊﾟﾚｯﾄID
        '-----------------------------
        If mudtSEARCH_ITEM.FPALLET_ID <> "" Then
            '(ﾊﾟﾚｯﾄ№に何も入力されている場合)
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FPALLET_ID = '" & mudtSEARCH_ITEM.FPALLET_ID & "' "       'ﾊﾟﾚｯﾄ№
        End If
        '-----------------------------
        'IN/OUT(動作)
        '-----------------------------
        If mudtSEARCH_ITEM.FINOUT_STS <> CBO_ALL_VALUE Then
            '(動作に何も入力されている場合)
            If mudtSEARCH_ITEM.FINOUT_STS = CONBOITEM_INOUT Then
                '(動作で"入出庫"が選択された場合)
                strSQL &= vbCrLf & "        AND (   TLOG_INOUT.FINOUT_STS = " & FINOUT_STS_SIN_END
                strSQL &= vbCrLf & "             OR TLOG_INOUT.FINOUT_STS = " & FINOUT_STS_SOUT_START
                strSQL &= vbCrLf & "             OR TLOG_INOUT.FINOUT_STS = " & FINOUT_STS_SMENTE_ADD
                strSQL &= vbCrLf & "             OR TLOG_INOUT.FINOUT_STS = " & FINOUT_STS_SMENTE_DELETE
                strSQL &= vbCrLf & "            ) "

                '入出庫関連の動作を表示
                '表示ログ： 入庫完了
                '           出庫指示
                '           メンテナンス追加
                '           メンテナンス削除

            Else
                '(動作でその他が選択された場合)
                strSQL &= vbCrLf & "        AND TLOG_INOUT.FINOUT_STS = '" & mudtSEARCH_ITEM.FINOUT_STS & "' "         'IN/OUT

            End If

        End If
        '-----------------------------
        'FROM ST
        '-----------------------------
        If mudtSEARCH_ITEM.FBUF_FM <> CBO_ALL_VALUE Then
            '(FROM STが入力されている場合)
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FBUF_FM = '" & mudtSEARCH_ITEM.FBUF_FM & "' "       'FROM ST
        End If
        '-----------------------------
        'TO ST
        '-----------------------------
        If mudtSEARCH_ITEM.FBUF_TO <> CBO_ALL_VALUE Then
            '(FROM STが入力されている場合)
            strSQL &= vbCrLf & "        AND TLOG_INOUT.FBUF_TO = '" & mudtSEARCH_ITEM.FBUF_TO & "' "           'TO ST
        End If

        strSQL &= vbCrLf & "   ) TLOG_INOUT_FULL "

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND TLOG_INOUT_FULL.REC <= " & intDspRows

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    TLOG_INOUT_FULL.FLOG_NO DESC "           'INOUT実績.ﾛｸﾞ


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
        strDataSetName = "TLOG_INOUT"
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
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示設定
    ''' </summary>
    ''' <param name="objGrid">設定するｸﾞﾘｯﾄﾞｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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
        objGrid.Columns(menmListCol.FLOG_NO).HeaderText = "ﾛｸﾞ№"                             'INOUT実績.         ﾛｸﾞ№
        objGrid.Columns(menmListCol.FLOT_NO_STOCK).HeaderText = "在庫ﾛｯﾄ№"                   'INOUT実績.         在庫ﾛｯﾄ№
        objGrid.Columns(menmListCol.FRESULT_DT).HeaderText = "実績日時"                       'INOUT実績.         実績日時
        objGrid.Columns(menmListCol.FPALLET_ID).HeaderText = "ﾊﾟﾚｯﾄID"                        'INOUT実績.         ﾊﾟﾚｯﾄID
        objGrid.Columns(menmListCol.FBUF_FM).HeaderText = "元ﾊﾞｯﾌｧ№"                         'INOUT実績.         元ﾊﾞｯﾌｧ№
        objGrid.Columns(menmListCol.FARRAY_FM).HeaderText = "元配列№"                        'INOUT実績.         元配列№
        objGrid.Columns(menmListCol.FBUF_TO).HeaderText = "先ﾊﾞｯﾌｧ№"                         'INOUT実績.         先ﾊﾞｯﾌｧ№
        objGrid.Columns(menmListCol.FARRAY_TO).HeaderText = "先配列№"                        'INOUT実績.         先配列№
        objGrid.Columns(menmListCol.FINOUT_STS).HeaderText = "IN/OUT"                         'INOUT実績.         IN/OUT
        objGrid.Columns(menmListCol.FSAGYOU_KIND).HeaderText = "作業種別"                     'INOUT実績.         作業種別
        objGrid.Columns(menmListCol.FDISP_ADDRESS_FM).HeaderText = "FM表記用ｱﾄﾞﾚｽ"            'INOUT実績.         FM表記用ｱﾄﾞﾚｽ
        objGrid.Columns(menmListCol.FDISP_ADDRESS_TO).HeaderText = "TO表記用ｱﾄﾞﾚｽ"            'INOUT実績.         TO表記用ｱﾄﾞﾚｽ
        objGrid.Columns(menmListCol.FDISPLOG_ADDRESS_FM).HeaderText = "FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用"   'INOUT実績.         FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        objGrid.Columns(menmListCol.FDISPLOG_ADDRESS_TO).HeaderText = "TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用"   'INOUT実績.         TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        objGrid.Columns(menmListCol.FHINMEI_CD).HeaderText = "品名ｺｰﾄﾞ"                       'INOUT実績.         品名ｺｰﾄﾞ
        objGrid.Columns(menmListCol.FLOT_NO).HeaderText = "ﾛｯﾄ№"                             'INOUT実績.         ﾛｯﾄ№
        objGrid.Columns(menmListCol.FARRIVE_DT).HeaderText = "在庫発生日時"                   'INOUT実績.         在庫発生日時
        objGrid.Columns(menmListCol.FIN_KUBUN).HeaderText = "入庫区分"                        'INOUT実績.         入庫区分
        objGrid.Columns(menmListCol.FSEIHIN_KUBUN).HeaderText = "製品区分"                    'INOUT実績.         製品区分
        objGrid.Columns(menmListCol.FZAIKO_KUBUN).HeaderText = "在庫区分"                     'INOUT実績.         在庫区分
        objGrid.Columns(menmListCol.FST_FM).HeaderText = "元ｽﾃｰｼｮﾝ№"                         'INOUT実績.         元ｽﾃｰｼｮﾝ№
        objGrid.Columns(menmListCol.FTR_VOL).HeaderText = "搬送管理量"                        'INOUT実績.         搬送管理量
        objGrid.Columns(menmListCol.FTR_RES_VOL).HeaderText = "搬送引当量"                    'INOUT実績.         搬送引当量
        objGrid.Columns(menmListCol.FTRNS_SERIAL).HeaderText = "搬送ｼﾘｱﾙ№"                   'INOUT実績.         搬送ｼﾘｱﾙ№
        objGrid.Columns(menmListCol.FUSER_ID).HeaderText = "ﾕｰｻﾞｰID"                        'INOUT実績.         ﾕｰｻﾞｰID
        objGrid.Columns(menmListCol.FFORM).HeaderText = "型式"                                'INOUT実績.         型式
        objGrid.Columns(menmListCol.FGOUKI).HeaderText = "号機"                               'INOUT実績.         号機

        '***********************
        '列ﾍｯﾀﾞ部配置変更
        '***********************
        objGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        '***********************
        'ﾃﾞｰﾀ部配置変更
        '***********************
        objGrid.Columns(menmListCol.FLOG_NO).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                   'INOUT実績.         ﾛｸﾞ№
        objGrid.Columns(menmListCol.FLOT_NO_STOCK).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft             'INOUT実績.         在庫ﾛｯﾄ№
        objGrid.Columns(menmListCol.FRESULT_DT).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter              'INOUT実績.         実績日時
        objGrid.Columns(menmListCol.FPALLET_ID).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                'INOUT実績.         ﾊﾟﾚｯﾄID
        objGrid.Columns(menmListCol.FBUF_FM).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight                  'INOUT実績.         元ﾊﾞｯﾌｧ№
        objGrid.Columns(menmListCol.FARRAY_FM).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight                'INOUT実績.         元配列№
        objGrid.Columns(menmListCol.FBUF_TO).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight                  'INOUT実績.         先ﾊﾞｯﾌｧ№
        objGrid.Columns(menmListCol.FARRAY_TO).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight                'INOUT実績.         先配列№
        objGrid.Columns(menmListCol.FINOUT_STS).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                'INOUT実績.         IN/OUT
        objGrid.Columns(menmListCol.FSAGYOU_KIND).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft              'INOUT実績.         作業種別
        objGrid.Columns(menmListCol.FDISP_ADDRESS_FM).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft          'INOUT実績.         FM表記用ｱﾄﾞﾚｽ
        objGrid.Columns(menmListCol.FDISP_ADDRESS_TO).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft          'INOUT実績.         TO表記用ｱﾄﾞﾚｽ
        objGrid.Columns(menmListCol.FDISPLOG_ADDRESS_FM).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft       'INOUT実績.         FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        objGrid.Columns(menmListCol.FDISPLOG_ADDRESS_TO).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft       'INOUT実績.         TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        objGrid.Columns(menmListCol.FHINMEI_CD).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                'INOUT実績.         品名ｺｰﾄﾞ
        objGrid.Columns(menmListCol.FLOT_NO).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                   'INOUT実績.         ﾛｯﾄ№
        objGrid.Columns(menmListCol.FARRIVE_DT).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter              'INOUT実績.         在庫発生日時
        objGrid.Columns(menmListCol.FIN_KUBUN).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                 'INOUT実績.         入庫区分
        objGrid.Columns(menmListCol.FSEIHIN_KUBUN).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft             'INOUT実績.         製品区分
        objGrid.Columns(menmListCol.FZAIKO_KUBUN).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft              'INOUT実績.         在庫区分
        objGrid.Columns(menmListCol.FST_FM).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight                   'INOUT実績.         元ｽﾃｰｼｮﾝ№
        objGrid.Columns(menmListCol.FTR_VOL).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight                  'INOUT実績.         搬送管理量
        objGrid.Columns(menmListCol.FTR_RES_VOL).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight              'INOUT実績.         搬送引当量
        objGrid.Columns(menmListCol.FTRNS_SERIAL).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft              'INOUT実績.         搬送ｼﾘｱﾙ№
        objGrid.Columns(menmListCol.FUSER_ID).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                   'INOUT実績.         ﾕｰｻﾞｰID
        objGrid.Columns(menmListCol.FFORM).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                     'INOUT実績.         型式
        objGrid.Columns(menmListCol.FGOUKI).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft                    'INOUT実績.         号機

        '***********************
        '非表示
        '***********************
        ''objGrid.Columns(menmListCol.Data04).Visible = False
        ''objGrid.Columns(menmListCol.Data05).Visible = False
        For intII As Integer = 0 To menmListCol.MAXCOL - 1
            '(列分ﾙｰﾌﾟ)
            objGrid.Columns(intII).Visible = False
        Next
        For intJJ As Integer = 0 To chckLstColDsp.CheckedIndices.Count - 1
            '(ﾁｪｯｸ分ﾙｰﾌﾟ)
            grdList.Columns(chckLstColDsp.CheckedIndices.Item(intJJ)).Visible = True
        Next

        '***********************
        '列幅調整
        '***********************
        objGrid.Columns(menmListCol.FLOG_NO).Width = 110                'INOUT実績.         ﾛｸﾞ№
        objGrid.Columns(menmListCol.FLOT_NO_STOCK).Width = 110          'INOUT実績.         在庫ﾛｯﾄ№
        objGrid.Columns(menmListCol.FRESULT_DT).Width = 120             'INOUT実績.         実績日時
        objGrid.Columns(menmListCol.FPALLET_ID).Width = 120             'INOUT実績.         ﾊﾟﾚｯﾄID
        objGrid.Columns(menmListCol.FBUF_FM).Width = 100                'INOUT実績.         元ﾊﾞｯﾌｧ№
        objGrid.Columns(menmListCol.FARRAY_FM).Width = 100              'INOUT実績.         元配列№
        objGrid.Columns(menmListCol.FBUF_TO).Width = 100                'INOUT実績.         先ﾊﾞｯﾌｧ№
        objGrid.Columns(menmListCol.FARRAY_TO).Width = 100              'INOUT実績.         先配列№
        objGrid.Columns(menmListCol.FINOUT_STS).Width = 100             'INOUT実績.         IN/OUT
        objGrid.Columns(menmListCol.FSAGYOU_KIND).Width = 100           'INOUT実績.         作業種別
        objGrid.Columns(menmListCol.FDISP_ADDRESS_FM).Width = 100       'INOUT実績.         FM表記用ｱﾄﾞﾚｽ
        objGrid.Columns(menmListCol.FDISP_ADDRESS_TO).Width = 100       'INOUT実績.         TO表記用ｱﾄﾞﾚｽ
        objGrid.Columns(menmListCol.FDISPLOG_ADDRESS_FM).Width = 100    'INOUT実績.         FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        objGrid.Columns(menmListCol.FDISPLOG_ADDRESS_TO).Width = 100    'INOUT実績.         TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        objGrid.Columns(menmListCol.FHINMEI_CD).Width = 100             'INOUT実績.         品名ｺｰﾄﾞ
        objGrid.Columns(menmListCol.FLOT_NO).Width = 100                'INOUT実績.         ﾛｯﾄ№
        objGrid.Columns(menmListCol.FARRIVE_DT).Width = 120             'INOUT実績.         在庫発生日時
        objGrid.Columns(menmListCol.FIN_KUBUN).Width = 100              'INOUT実績.         入庫区分
        objGrid.Columns(menmListCol.FSEIHIN_KUBUN).Width = 100          'INOUT実績.         製品区分
        objGrid.Columns(menmListCol.FZAIKO_KUBUN).Width = 100           'INOUT実績.         在庫区分
        objGrid.Columns(menmListCol.FST_FM).Width = 100                 'INOUT実績.         元ｽﾃｰｼｮﾝ№
        objGrid.Columns(menmListCol.FTR_VOL).Width = 100                'INOUT実績.         搬送管理量
        objGrid.Columns(menmListCol.FTR_RES_VOL).Width = 100            'INOUT実績.         搬送引当量
        objGrid.Columns(menmListCol.FTRNS_SERIAL).Width = 100           'INOUT実績.         搬送ｼﾘｱﾙ№
        objGrid.Columns(menmListCol.FUSER_ID).Width = 100                'INOUT実績.         ﾕｰｻﾞｰID
        objGrid.Columns(menmListCol.FFORM).Width = 100                  'INOUT実績.         型式
        objGrid.Columns(menmListCol.FGOUKI).Width = 100                 'INOUT実績.         号機


        ' ''***********************
        ' ''編集ﾛｯｸ
        ' ''***********************
        ''objGrid.Columns(menmListCol.ItemName).ReadOnly = True
        ''objGrid.Columns(menmListCol.Data).ReadOnly = False
        ''objGrid.Columns(menmListCol.Item).ReadOnly = True
        ''objGrid.Columns(menmListCol.Size).ReadOnly = True

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

#Region "  構造体ｾｯﾄ                                    "
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
        '期間(FROM)
        '===============================================
        mudtSEARCH_ITEM.KIKAN_FROM = TO_STRING(dtpKikanFromDate.Text & " " & dtpKikanFromTime.Text)    '期間(FROM)

        '===============================================
        '期間(TO)
        '===============================================
        mudtSEARCH_ITEM.KIKAN_TO = TO_STRING(dtpKikanToDate.Text & " " & dtpKikanToTime.Text)          '期間(TO)

        '===============================================
        ' ﾊﾟﾚｯﾄID
        '===============================================
        mudtSEARCH_ITEM.FPALLET_ID = TO_STRING(txtPallet_ID.Text)

        '===============================================
        ' 動作
        '===============================================
        mudtSEARCH_ITEM.FINOUT_STS = TO_STRING(cboFINOUT_STS.SelectedValue)

        '===============================================
        'FROM ST
        '===============================================
        mudtSEARCH_ITEM.FBUF_FM = TO_STRING(cboFROM.SelectedValue)

        '===============================================
        'TO ST
        '===============================================
        mudtSEARCH_ITEM.FBUF_TO = TO_STRING(cboTO.SelectedValue)


    End Sub
#End Region
#Region "　期間設定                                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 期間設定
    ''' </summary>
    ''' <param name="dtpFromDate">開始日付</param>
    ''' <param name="dtpFromTime">開始時間</param>
    ''' <param name="dtpToDate">終了日付</param>
    ''' <param name="dtpToTime">終了時間</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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
#Region "　ｺﾝﾎﾞﾎﾞｯｸｽ作成(標準)                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽ作成(標準)
    ''' </summary>
    ''' <param name="strDispID"></param>
    ''' <param name="objCbo"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboDefaultMake(ByVal strDispID As String, ByRef objCbo As System.Windows.Forms.ComboBox)

        objCbo.Items.Clear()

        Dim strDisp As String = ""                          'ｺﾝﾎﾞﾎﾞｯｸｽ表示ﾃﾞｰﾀ
        Dim strData As String = ""                          'ｺﾝﾎﾞﾎﾞｯｸｽ内部ﾃﾞｰﾀ
        Dim strSQL As String                                'SQL文
        Dim lngCnt As Long = 0              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim clsList(0) As GamenCommon.clsCboData        'ｺﾝﾎﾞ用配列

        '選択なし行追加
        clsList(0) = New GamenCommon.clsCboData("", CBO_ALL_VALUE)

        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '   【DSP_CTRL】
        '*******************************************************
        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & "    TDSP_DISP.FGAMEN_DISP FGAMEN_DISP "          '画面表示ﾏｽﾀ.   表示用名称
        strSQL &= vbCrLf & "  , TDSP_DISP.FDISP_VALUE FDISP_VALUE "          '画面表示ﾏｽﾀ.   設定値
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TDSP_CTRL LEFT OUTER JOIN "       '画面表示ﾏｽﾀ     (外部結合
        strSQL &= vbCrLf & "    TDSP_DISP ON "                    '画面ｺﾝﾄﾛｰﾙﾏｽﾀ   (外部結合
        strSQL &= vbCrLf & "           TDSP_CTRL.FTABLE_NAME = TDSP_DISP.FTABLE_NAME "     '外部結合   ﾃｰﾌﾞﾙ名
        strSQL &= vbCrLf & "       AND TDSP_CTRL.FFIELD_NAME = TDSP_DISP.FFIELD_NAME "     '外部結合   ﾌｨｰﾙﾄﾞ名
        strSQL &= vbCrLf & "       AND TDSP_CTRL.FCTRL_VALUE = TDSP_DISP.FDISP_VALUE "     '外部結合   設定値
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        TDSP_CTRL.FDISP_ID = '" & TO_STRING(strDispID) & "'"                    '画面ID
        strSQL &= vbCrLf & "    AND TDSP_CTRL.FCTRL_ID = '" & TO_STRING(objCbo.Name) & "'"            'ｺﾝﾄﾛｰﾙ名
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    TDSP_CTRL.FCTRL_ORDER "    '画面ｺﾝﾄﾛｰﾙﾏｽﾀ. 順番
        strSQL &= vbCrLf

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        gobjDb.SQL = strSQL
        strDataSetName = "TDSP_CTRL"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        Dim objRow As DataRow
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                lngCnt = lngCnt + 1
                ReDim Preserve clsList(lngCnt)
                If IsDBNull(objRow("FGAMEN_DISP")) = True Or IsDBNull(objRow("FDISP_VALUE")) = True Then
                    clsList(lngCnt) = New GamenCommon.clsCboData("", "")
                Else
                    clsList(lngCnt) = New GamenCommon.clsCboData(CStr(objRow("FGAMEN_DISP")), CStr(objRow("FDISP_VALUE")))
                End If


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
#Region "　ｺﾝﾎﾞﾎﾞｯｸｽ作成(ST)                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽ作成(ST)
    ''' </summary>
    ''' <param name="objCbo"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboDspSTMake(ByRef objCbo As System.Windows.Forms.ComboBox)

        objCbo.Items.Clear()

        Dim strDisp As String = ""                          'ｺﾝﾎﾞﾎﾞｯｸｽ表示ﾃﾞｰﾀ
        Dim strData As String = ""                          'ｺﾝﾎﾞﾎﾞｯｸｽ内部ﾃﾞｰﾀ
        Dim strSQL As String                                'SQL文
        Dim lngCnt As Long = 0                              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim clsList(0) As GamenCommon.clsCboData            'ｺﾝﾎﾞ用配列

        '選択なし行追加
        clsList(0) = New GamenCommon.clsCboData("", CBO_ALL_VALUE)

        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '   【TMST_TRK】
        '*******************************************************
        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT DISTINCT "
        strSQL &= vbCrLf & "    FTRK_BUF_NO "                                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "  , FBUF_NAME "                                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        strSQL &= vbCrLf & " FROM TMST_TRK "                                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    FTRK_BUF_NO "
        strSQL &= vbCrLf


        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        gobjDb.SQL = strSQL
        strDataSetName = "TMST_TRK"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        Dim objRow As DataRow
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                lngCnt = lngCnt + 1
                ReDim Preserve clsList(lngCnt)
                clsList(lngCnt) = New GamenCommon.clsCboData(CStr(objRow("FBUF_NAME")), CStr(objRow("FTRK_BUF_NO")))

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
#Region "　ﾁｪｯｸﾘｽﾄﾎﾞｯｸｽ設定処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾁｪｯｸﾘｽﾄﾎﾞｯｸｽ設定処理 
    ''' </summary>
    ''' <param name="ctlChckLstBox"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub chckLstBoxSetUp(ByVal ctlChckLstBox As CheckedListBox)
        '****************************************
        '初期設定
        '****************************************
        ctlChckLstBox.Items.Clear()
        Dim blnChck(0 To menmListCol.MAXCOL - 1) As Boolean    'ﾁｪｯｸﾌﾗｸﾞ
        blnChck(menmListCol.FLOG_NO) = False                    'ﾛｸﾞ№
        blnChck(menmListCol.FLOT_NO_STOCK) = False              '在庫ﾛｯﾄ№
        blnChck(menmListCol.FRESULT_DT) = True                  '実績日時
        blnChck(menmListCol.FPALLET_ID) = True                  'ﾊﾟﾚｯﾄID
        blnChck(menmListCol.FBUF_FM) = False                    '元ﾊﾞｯﾌｧ№
        blnChck(menmListCol.FARRAY_FM) = False                  '元配列№
        blnChck(menmListCol.FBUF_TO) = False                    '先ﾊﾞｯﾌｧ№
        blnChck(menmListCol.FARRAY_TO) = False                  '先配列№
        blnChck(menmListCol.FINOUT_STS) = True                  'IN/OUT
        blnChck(menmListCol.FSAGYOU_KIND) = False               '作業種別
        blnChck(menmListCol.FDISP_ADDRESS_FM) = True            'FM表記用ｱﾄﾞﾚｽ
        blnChck(menmListCol.FDISP_ADDRESS_TO) = True            'TO表記用ｱﾄﾞﾚｽ
        blnChck(menmListCol.FDISPLOG_ADDRESS_FM) = True         'FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        blnChck(menmListCol.FDISPLOG_ADDRESS_TO) = True         'TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        blnChck(menmListCol.FHINMEI_CD) = False                 '品名ｺｰﾄﾞ
        blnChck(menmListCol.FLOT_NO) = False                    'ﾛｯﾄ№
        blnChck(menmListCol.FARRIVE_DT) = True                  '在庫発生日時
        blnChck(menmListCol.FIN_KUBUN) = False                  '入庫区分
        blnChck(menmListCol.FSEIHIN_KUBUN) = False              '製品区分
        blnChck(menmListCol.FZAIKO_KUBUN) = False               '在庫区分
        blnChck(menmListCol.FST_FM) = False                     '元ｽﾃｰｼｮﾝ№
        blnChck(menmListCol.FTR_VOL) = False                    '搬送管理量
        blnChck(menmListCol.FTR_RES_VOL) = False                '搬送引当量
        blnChck(menmListCol.FTRNS_SERIAL) = False               '搬送ｼﾘｱﾙ№
        blnChck(menmListCol.FUSER_ID) = False                    'ﾕｰｻﾞｰID
        blnChck(menmListCol.FFORM) = True                       '型式
        blnChck(menmListCol.FGOUKI) = True                      '号機

        ctlChckLstBox.Items.Add("ﾛｸﾞ№", blnChck(menmListCol.FLOG_NO))
        ctlChckLstBox.Items.Add("在庫ﾛｯﾄ№", blnChck(menmListCol.FLOT_NO_STOCK))
        ctlChckLstBox.Items.Add("実績日時", blnChck(menmListCol.FRESULT_DT))
        ctlChckLstBox.Items.Add("ﾊﾟﾚｯﾄID", blnChck(menmListCol.FPALLET_ID))
        ctlChckLstBox.Items.Add("元ﾊﾞｯﾌｧ№", blnChck(menmListCol.FBUF_FM))
        ctlChckLstBox.Items.Add("元配列№", blnChck(menmListCol.FARRAY_FM))
        ctlChckLstBox.Items.Add("先ﾊﾞｯﾌｧ№", blnChck(menmListCol.FBUF_TO))
        ctlChckLstBox.Items.Add("先配列№", blnChck(menmListCol.FARRAY_TO))
        ctlChckLstBox.Items.Add("IN/OUT", blnChck(menmListCol.FINOUT_STS))
        ctlChckLstBox.Items.Add("作業種別", blnChck(menmListCol.FSAGYOU_KIND))
        ctlChckLstBox.Items.Add("FM表記用ｱﾄﾞﾚｽ", blnChck(menmListCol.FDISP_ADDRESS_FM))
        ctlChckLstBox.Items.Add("TO表記用ｱﾄﾞﾚｽ", blnChck(menmListCol.FDISP_ADDRESS_TO))
        ctlChckLstBox.Items.Add("FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用", blnChck(menmListCol.FDISPLOG_ADDRESS_FM))
        ctlChckLstBox.Items.Add("TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用", blnChck(menmListCol.FDISPLOG_ADDRESS_TO))
        ctlChckLstBox.Items.Add("品名ｺｰﾄﾞ", blnChck(menmListCol.FHINMEI_CD))
        ctlChckLstBox.Items.Add("ﾛｯﾄ№", blnChck(menmListCol.FLOT_NO))
        ctlChckLstBox.Items.Add("在庫発生日時", blnChck(menmListCol.FARRIVE_DT))
        ctlChckLstBox.Items.Add("入庫区分", blnChck(menmListCol.FIN_KUBUN))
        ctlChckLstBox.Items.Add("製品区分", blnChck(menmListCol.FSEIHIN_KUBUN))
        ctlChckLstBox.Items.Add("在庫区分", blnChck(menmListCol.FZAIKO_KUBUN))
        ctlChckLstBox.Items.Add("元ｽﾃｰｼｮﾝ№", blnChck(menmListCol.FST_FM))
        ctlChckLstBox.Items.Add("搬送管理量", blnChck(menmListCol.FTR_VOL))
        ctlChckLstBox.Items.Add("搬送引当量", blnChck(menmListCol.FTR_RES_VOL))
        ctlChckLstBox.Items.Add("搬送ｼﾘｱﾙ№", blnChck(menmListCol.FTRNS_SERIAL))
        ctlChckLstBox.Items.Add("ﾕｰｻﾞｰID", blnChck(menmListCol.FUSER_ID))
        ctlChckLstBox.Items.Add("型式", blnChck(menmListCol.FFORM))
        ctlChckLstBox.Items.Add("号機", blnChck(menmListCol.FGOUKI))

    End Sub
#End Region
#Region "　表示件数ﾁｪｯｸ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示件数ﾁｪｯｸ 
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <param name="blnDspOkFlg"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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