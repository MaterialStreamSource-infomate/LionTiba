'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_207010

#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        LOG_NO                          'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.       ﾛｸﾞ№
        HASSEI_DT                       'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.       発生日時
        USER_NAME                       'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.       ﾕｰｻﾞｰ名
        TERM_NAME                       'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.       作業端末
        SYORI_NAME                      'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.       処理名
        REASON                          'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.       理由
        FLOG_DATA_OPE                   'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.       ｵﾍﾟﾚｰｼｮﾝﾛｸﾞﾃﾞｰﾀ

        MAXCOL

    End Enum

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        SearchBtn_Click                 '検索ﾎﾞﾀﾝｸﾘｯｸ時
        DetailBtn_Click                 '詳細表示ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    ''' <summary>検索条件</summary>
    Private Structure SEARCH_ITEM
        Dim KIKAN_FROM As String        '期間(FROM)
        Dim KIKAN_TO As String          '期間(TO)
        Dim FUSER_ID As String          '作業者
        Dim FTERM_ID As String          '操作端末
        Dim FSYORI_ID As String         '作業内容

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
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                               "
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
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()


        '****************************************
        '期間           ｾｯﾄ
        '****************************************
        Call gobjComFuncFRM.dtpKikanFromToSetup(dtpFrom, dtpTo)


        '**********************************************************
        ' 作業者ｺﾝﾎﾞﾎﾞｯｸｽ                 ｾｯﾄ
        '**********************************************************
        Call gobjComFuncFRM.cboMsterSetup("TMST_USER", "FUSER_NAME", "FUSER_ID", "FUSER_ID", cboFUSER_ID, True)

        lblFUSER_NAME_DSP.Text = ""

        '**********************************************************
        ' 操作端末ｺﾝﾎﾞﾎﾞｯｸｽ                 ｾｯﾄ
        '**********************************************************
        Call gobjComFuncFRM.cboMsterSetup("TDSP_TERM", "FTERM_ID", "FTERM_NAME", "FTERM_ID", cboFTERM_ID)


        '**********************************************************
        ' 作業内容ｺﾝﾎﾞﾎﾞｯｸｽ                 ｾｯﾄ
        '**********************************************************
        Call cboSyoriIdSetup(cboContent, True)                           '作業内容


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        mFlag_Form_Load = False

    End Sub
#End Region
#Region "  F1(検索)  ﾎﾞﾀﾝ押下処理　                 "
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
        Call SearchItem_Set()


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "  F4(詳細表示)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(詳細表示) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.DetailBtn_Click) = False Then
            Exit Sub
        End If


        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_207011) = False Then
            gobjFRM_207011.Close()
            gobjFRM_207011.Dispose()
            gobjFRM_207011 = Nothing
        End If

        gobjFRM_207011 = New FRM_207011

        Call SetProperty()      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_207011.ShowDialog()            '展開


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
        dtpFrom.Dispose()
        dtpTo.Dispose()
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ

    End Sub
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
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

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
#Region "　構造体ｾｯﾄ　                              "
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

        '===============================================
        '作業者
        '===============================================
        mudtSEARCH_ITEM.FUSER_ID = TO_STRING(cboFUSER_ID.Text)

        '===============================================
        '操作端末
        '===============================================
        mudtSEARCH_ITEM.FTERM_ID = TO_STRING(cboFTERM_ID.SelectedValue)

        '===============================================
        '作業内容
        '===============================================
        mudtSEARCH_ITEM.FSYORI_ID = TO_STRING(cboContent.SelectedValue)


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        Dim strSQL As String                    'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TLOG_OPE.FLOG_NO "          'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.       ﾛｸﾞ№
        strSQL &= vbCrLf & "  , TLOG_OPE.FHASSEI_DT "       'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.       発生日時
        strSQL &= vbCrLf & "  , TLOG_OPE.FUSER_NAME "       'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.       ﾕｰｻﾞｰ名
        strSQL &= vbCrLf & "  , TLOG_OPE.FTERM_NAME "       'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.       端末名
        strSQL &= vbCrLf & "  , TLOG_OPE.FSYORI_NAME "      'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.       作業内容　
        strSQL &= vbCrLf & "  , TLOG_OPE.FREASON "          'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.       理由
        strSQL &= vbCrLf & "  , TLOG_OPE.FLOG_DATA_OPE "    'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.       ｵﾍﾟﾚｰｼｮﾝﾛｸﾞﾃﾞｰﾀ
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TLOG_OPE "              'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ
        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件
        '----------------------------
        'ﾛｸﾞ発生日時
        '----------------------------
        If mudtSEARCH_ITEM.KIKAN_FROM <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_OPE.FHASSEI_DT >= TO_DATE('" & mudtSEARCH_ITEM.KIKAN_FROM & "','YYYY/MM/DD HH24:MI:SS')"          'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.     発生日時
        End If
        If mudtSEARCH_ITEM.KIKAN_TO <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_OPE.FHASSEI_DT <= TO_DATE('" & mudtSEARCH_ITEM.KIKAN_TO & "','YYYY/MM/DD HH24:MI:SS')"            'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.     発生日時
        End If
        '----------------------------
        '作業者
        '----------------------------
        If mudtSEARCH_ITEM.FUSER_ID <> CBO_ALL_VALUE Then
            strSQL &= vbCrLf & "    AND TLOG_OPE.FUSER_ID = '" & mudtSEARCH_ITEM.FUSER_ID & "' "               'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.     作業者
        End If
        '----------------------------
        '操作端末
        '----------------------------
        If mudtSEARCH_ITEM.FTERM_ID <> CBO_ALL_VALUE Then
            strSQL &= vbCrLf & "    AND TLOG_OPE.FTERM_ID = '" & mudtSEARCH_ITEM.FTERM_ID & "' "             '作業履歴.     端末ID
        End If
        '----------------------------
        '作業内容
        '----------------------------
        If mudtSEARCH_ITEM.FSYORI_ID <> CBO_ALL_VALUE Then
            strSQL &= vbCrLf & "    AND TLOG_OPE.FSYORI_ID = '" & mudtSEARCH_ITEM.FSYORI_ID & "' "           'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.     処理ID
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
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)       'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定　                         "
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


    End Sub
#End Region
#Region "　作業内容ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 作業内容ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ
    ''' </summary>
    ''' <param name="cboControl">作成するｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ（ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値（ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列（ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboSyoriIdSetup(ByRef cboControl As Windows.Forms.ComboBox, _
                                Optional ByVal blnAllFlag As Boolean = True, _
                                Optional ByVal objDefault As Object = Nothing, _
                                Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                               )
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("ID", GetType(String))
        objComboTable.Columns.Add("NAME", GetType(String))


        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************
        cboControl.Items.Clear()
        If blnAllFlag = True Then
            '(AllﾌﾗｸﾞがTRUEの場合)
            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '   【TLOG_OPE】
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT DISTINCT "
        strSQL &= vbCrLf & "    FSYORI_ID "                                 '作業ID
        strSQL &= vbCrLf & "  , FCOMMENT "                                  'ｺﾒﾝﾄ
        strSQL &= vbCrLf & " FROM TPRG_TIMER "                              'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ
        strSQL &= vbCrLf & " WHERE 1 = 1 "
        strSQL &= vbCrLf & "    AND (FLOG_OPE_FLAG IS NULL OR FLOG_OPE_FLAG <> 0 OR FEVD_OPE_FLAG = 1)"
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    FSYORI_ID "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TLOG_OPE"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("FCOMMENT"))
                Dim subItem2 As String
                subItem2 = TO_STRING(objRow("FSYORI_ID"))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = subItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

                If IsNull(objDefault) = False Then
                    If TO_STRING(objDefault) = subItem2 Then
                        strSearch = SubItem1
                    End If
                End If

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)
            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)
        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)
            Call gobjComFuncFRM.cboSelectValue(cboControl, strSearch)
        End If


    End Sub
#End Region
#Region "  作業履歴詳細画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 作業履歴詳細画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty()


        '======================================
        '作業履歴詳細画面ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '======================================
        gobjFRM_207011.userFLOG_NO = TO_STRING(grdList.Item(menmListCol.LOG_NO, grdList.SelectedRows(0).Index).Value)   'ﾛｸﾞ№


    End Sub
#End Region

End Class
