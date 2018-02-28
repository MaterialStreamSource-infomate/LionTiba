'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】設備通信ﾛｸﾞ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_207040

#Region "　共通変数　                           "

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    ''' <summary>ﾌｫｰﾑﾛｰﾄﾞ完了ﾌﾗｸﾞ</summary>
    Private mblnFormLoadedFlg As Boolean = False

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        HASSEI_DT                       '設備通信ﾛｸﾞ.       発生日時　 
        DIRECTION                       '設備通信ﾛｸﾞ.       方向
        DIRECTION_disp                  '設備通信ﾛｸﾞ.       方向(表示用)
        TEXT_ID                         '設備通信ﾛｸﾞ.       ﾃｷｽﾄID
        TEXT_ID_disp                    '設備通信ﾛｸﾞ.       ﾃｷｽﾄID(表示用)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/04/10 設備ID追加
        XEQ_ID_WRITE                    '設備通信ﾛｸﾞ.       書込設備ID
        FEQ_NAME                        '設備状況.          設備名称
        '↑↑↑↑↑↑************************************************************************************************************
        DENBUN                          '設備通信ﾛｸﾞ.       通信ﾃｷｽﾄ
        EQ_ID                           '設備通信ﾛｸﾞ.       処理ID
        FLOG_NO                         '設備通信ﾛｸﾞ.       ﾛｸﾞ№

        MAXCOL

    End Enum

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        SearchBtn_Click                 '検索ﾎﾞﾀﾝｸﾘｯｸ時
        List_DoubleClick                'ｸﾞﾘｯﾄﾞのﾘｽﾄﾀﾞﾌﾞﾙｸﾘｯｸ時
        CarryClearBtn_Click             '搬送ｸﾘｱｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義　                         "

    ''' <summary>検索条件</summary>
    Private Structure SEARCH_ITEM
        Dim FEQ_ID As String            '通信対象
        Dim KIKAN_FROM As String        '期間(FROM)
        Dim KIKAN_TO As String          '期間(TO)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/05/16 検索条件追加
        Dim FDIRECTION As String        '方向
        Dim FTEXT_ID As String          'ﾃｷｽﾄID
        Dim FEQ_NAME As String          '設備名称
        '↑↑↑↑↑↑************************************************************************************************************
    End Structure
#End Region
#Region "　ｲﾍﾞﾝﾄ　                              "
#Region "　ｸﾞﾘｯﾄﾞﾀﾞﾌﾞﾙｸﾘｯｸ(電文詳細展開)    ｲﾍﾞﾝﾄ　"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞﾀﾞﾌﾞﾙｸﾘｯｸ(電文詳細展開) ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.DoubleClick

        Try

            '********************************************************************
            '入力ﾁｪｯｸ
            '********************************************************************
            If InputCheck(menmCheckCase.List_DoubleClick) = False Then
                Exit Sub
            End If


            Select Case TO_STRING(grdList.Item(menmListCol.TEXT_ID, grdList.SelectedRows(0).Index).Value)
                Case FTEXT_ID_JR_EVENT, FTEXT_ID_JR_TRK_INOUT, FTEXT_ID_JR_TRK_RTN, FTEXT_ID_JW_IN, FTEXT_ID_JW_MAINTE_GENZAI, _
                     FTEXT_ID_JW_MAINTE_INOUT, FTEXT_ID_JW_MAINTE_RTN, FTEXT_ID_JW_MAINTE_YOTEI, FTEXT_ID_JW_OUT, FTEXT_ID_JW_TRNS, FTEXT_ID_JW_YOTEI, FTEXT_ID_SRE, FTEXT_ID_JR_CARD, FTEXT_ID_JS_CARD01, FTEXT_ID_JS_CARD02

                    '*********************************************
                    ' 電文詳細表示
                    '*********************************************
                    Call grdList_SelectedIndexChangedProcess()

                Case Else
                    '何もしない

            End Select


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
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()


        '**********************************************************
        ' 通信対象           ｾｯﾄ
        '**********************************************************
        Call gobjComFuncFRM.cboSetup(Me.Name, cboFEQ_ID, True)


        '****************************************
        '期間           ｾｯﾄ
        '****************************************
        Call gobjComFuncFRM.dtpKikanFromToSetup(dtpFrom, dtpTo)

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/05/16 検索条件追加

        '****************************************
        '方向           ｾｯﾄ
        '****************************************
        Call gobjComFuncFRM.cboSetup(Me.Name, cboFDIRECTION, True)

        '****************************************
        'ﾃｷｽﾄID           ｾｯﾄ
        '****************************************
        Call gobjComFuncFRM.cboSetup(Me.Name, cboFTEXT_ID, True)

        '****************************************
        '設備名称      ｾｯﾄ
        '****************************************

        cboFEQ_NAME.Items.Add("")

        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ
        Dim strSQL As String = ""

        '********************************************************************
        ' ｺﾈｸｼｮﾝの確認
        '********************************************************************
        If IsNull(gobjDb) = True Then
            'ｺﾈｸｼｮﾝがｾｯﾄされていない場合は終了
            Return
        End If

        '********************************************************************
        ' SQL文
        '********************************************************************
        strSQL = ""
        '(Select句)
        strSQL &= vbCrLf & " SELECT DISTINCT "
        strSQL &= vbCrLf & "     TSTS_EQ_CTRL.FEQ_NAME "                            '設備状況       .設備名
        '(From句)
        strSQL &= vbCrLf & " FROM   "
        strSQL &= vbCrLf & "     TSTS_EQ_CTRL "                                     '【設備状況】
        '(Where句)
        'strSQL &= vbCrLf & " WHERE  "
        'strSQL &= vbCrLf & "     TMST_ITEM.XMAKER_CD = XMST_WRAPPING_MAKER.XMAKER_CD(+) "
        '(Order)
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     TSTS_EQ_CTRL.FEQ_NAME "

        '********************************************************************
        ' 実行
        '********************************************************************
        gobjDb.SQL = strSQL

        objDataSet.Clear()
        gobjDb.GetDataSet("TSTS_EQ_CTRL", objDataSet)

        If objDataSet.Tables("TSTS_EQ_CTRL").Rows.Count > 0 Then
            Dim ii As Integer

            For ii = 0 To objDataSet.Tables("TSTS_EQ_CTRL").Rows.Count - 1
                cboFEQ_NAME.Items.Add(TO_STRING(objDataSet.Tables("TSTS_EQ_CTRL").Rows(ii).Item("FEQ_NAME")))
            Next

        End If



        '↑↑↑↑↑↑************************************************************************************************************

        '**********************************************************
        ' ｺﾝﾄﾛｰﾙ初期設定
        '**********************************************************
        chkStateFlg.Checked = False
        chkStateFlg.Visible = False


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        'ﾛｰﾄﾞ完了ﾌﾗｸﾞ更新
        mblnFormLoadedFlg = True        'ﾛｰﾄﾞ完了


    End Sub
#End Region
#Region "  F1(検索)  ﾎﾞﾀﾝ押下処理　             "
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
        Call SeachItem_Set()


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)

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
        cboFEQ_ID.Dispose()            '通信対象ｺﾝﾎﾞﾎﾞｯｸｽ
        dtpFrom.Dispose()
        dtpTo.Dispose()
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                           "
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

                '==========================
                '通信対象  選択ﾁｪｯｸ
                '==========================
                'If TO_STRING(cboFEQ_ID.SelectedValue.ToString) = CBO_ALL_VALUE _
                '    Or IsNull(TO_STRING(cboFEQ_ID.SelectedValue.ToString)) = True Then
                '    '(ﾗｲﾝ№が選択されていない場合)
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM207040_01, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select
                'End If


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

            Case menmCheckCase.List_DoubleClick
                '(ｸﾞﾘｯﾄﾞのﾘｽﾄﾀﾞﾌﾞﾙｸﾘｯｸ時)

                '*******************************************************
                '入力ﾁｪｯｸ
                '*******************************************************
                If grdList.SelectedRows.Count < 1 Then
                    Exit Select
                End If

                ''*******************************************************
                ''設備IDﾁｪｯｸ
                ''*******************************************************
                'Dim strEQ_ID = TO_STRING(grdList.Item(menmListCol.EQ_ID, grdList.SelectedRows(0).Index).Value)            '設備ID
                'If (strEQ_ID = FEQ_ID_JSYS0001) Or _
                '   (strEQ_ID = FEQ_ID_JSYS0002) Then
                '    '(SHIP、PLSのときは詳細画面に展開しない)
                '    Exit Select
                'End If

                blnCheckErr = False

            Case menmCheckCase.CarryClearBtn_Click
                '(搬送ｸﾘｱｸﾘｯｸ時)

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
#Region "　構造体ｾｯﾄ　                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SeachItem_Set()


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
        '通信対象
        '===============================================
        mudtSEARCH_ITEM.FEQ_ID = TO_STRING(cboFEQ_ID.SelectedValue.ToString)

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/05/16 検索条件追加

        '===============================================
        '方向
        '===============================================
        If cboFDIRECTION.SelectedValue <> "" Then
            mudtSEARCH_ITEM.FDIRECTION = TO_STRING(cboFDIRECTION.SelectedValue.ToString)
        Else
            mudtSEARCH_ITEM.FDIRECTION = ""
        End If

        '===============================================
        'ﾃｷｽﾄID
        '===============================================
        If cboFTEXT_ID.SelectedValue <> "" Then
            mudtSEARCH_ITEM.FTEXT_ID = TO_STRING(cboFTEXT_ID.SelectedValue.ToString)
        Else
            mudtSEARCH_ITEM.FTEXT_ID = ""
        End If

        '===============================================
        '設備名称
        '===============================================
        mudtSEARCH_ITEM.FEQ_NAME = cboFEQ_NAME.Text

        '↑↑↑↑↑↑************************************************************************************************************


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

        Dim strSQL As String = ""                       'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TLOG_EQ.FHASSEI_DT "                    '設備通信ﾛｸﾞ.        発生日時
        strSQL &= vbCrLf & "  , TLOG_EQ.FDIRECTION "                    '設備通信ﾛｸﾞ.　　　　方向
        strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP "                    '設備通信ﾛｸﾞ.        方向(表示用)
        strSQL &= vbCrLf & "  , TLOG_EQ.FTEXT_ID "                      '設備通信ﾛｸﾞ.        ﾃｷｽﾄID
        strSQL &= vbCrLf & "  , HASH02.FGAMEN_DISP "                    '設備通信ﾛｸﾞ.        ﾃｷｽﾄID(表示用)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/04/10 設備ID追加
        strSQL &= vbCrLf & "  , TLOG_EQ.XEQ_ID_WRITE "                  '設備通信ﾛｸﾞ.　　　　書込設備ID
        strSQL &= vbCrLf & "  , TSTS_EQ_CTRL.FEQ_NAME "                 '設備状況.　　　　   設備名称
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "  , TLOG_EQ.FDENBUN "                       '設備通信ﾛｸﾞ.    　　通信ﾃｷｽﾄ　
        strSQL &= vbCrLf & "  , TLOG_EQ.FEQ_ID "                        '設備通信ﾛｸﾞ.        設備ID
        strSQL &= vbCrLf & "  , TLOG_EQ.FLOG_NO "                       '設備通信ﾛｸﾞ.        ﾛｸﾞ№
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TLOG_EQ "                               '【設備通信ﾛｸﾞ】
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/04/10 設備ID追加
        strSQL &= vbCrLf & "   ,TSTS_EQ_CTRL "                          '【設備状況】
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "     ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TLOG_EQ", "FDIRECTION")
        strSQL &= vbCrLf & "     ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TLOG_EQ", "FTEXT_ID")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/04/10 設備ID追加
        strSQL &= vbCrLf & "    AND TLOG_EQ.XEQ_ID_WRITE = TSTS_EQ_CTRL.FEQ_ID(+) "
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TLOG_EQ", "FDIRECTION")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TLOG_EQ", "FTEXT_ID")
        If mudtSEARCH_ITEM.FEQ_ID <> CBO_ALL_VALUE Then
            strSQL &= vbCrLf & "    AND TLOG_EQ.FEQ_ID = '" & mudtSEARCH_ITEM.FEQ_ID & "'"       '設備通信ﾛｸﾞ.     設備ID
        End If

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/05/16 検索条件追加
        If mudtSEARCH_ITEM.FDIRECTION <> CBO_ALL_VALUE Then
            strSQL &= vbCrLf & "    AND TLOG_EQ.FDIRECTION = '" & mudtSEARCH_ITEM.FDIRECTION & "'"      '設備通信ﾛｸﾞ.     方向
        End If

        If mudtSEARCH_ITEM.FTEXT_ID <> CBO_ALL_VALUE Then
            strSQL &= vbCrLf & "    AND TLOG_EQ.FTEXT_ID = '" & mudtSEARCH_ITEM.FTEXT_ID & "'"          '設備通信ﾛｸﾞ.     ﾃｷｽﾄID
        End If

        If mudtSEARCH_ITEM.FEQ_NAME <> CBO_ALL_VALUE Then
            strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_NAME = '" & mudtSEARCH_ITEM.FEQ_NAME & "'"     '設備通信ﾛｸﾞ.     設備名称
        End If

        '↑↑↑↑↑↑************************************************************************************************************

        '----------------------------
        'ﾛｸﾞ発生日時
        '----------------------------
        If mudtSEARCH_ITEM.KIKAN_FROM <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_EQ.FHASSEI_DT >= TO_DATE('" & mudtSEARCH_ITEM.KIKAN_FROM & "','YYYY/MM/DD HH24:MI:SS')"          '設備通信ﾛｸﾞ.     発生日時
        End If
        If mudtSEARCH_ITEM.KIKAN_TO <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_EQ.FHASSEI_DT <= TO_DATE('" & mudtSEARCH_ITEM.KIKAN_TO & "','YYYY/MM/DD HH24:MI:SS')"            '設備通信ﾛｸﾞ.     発生日時
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

        'grdList.Columns(menmListCol.DENBUN).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill   '列幅自動調整


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ選択処理　                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ選択処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_SelectedIndexChangedProcess()

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_207041) = False Then
            gobjFRM_207041.Close()
            gobjFRM_207041.Dispose()
            gobjFRM_207041 = Nothing
        End If

        gobjFRM_207041 = New FRM_207041

        gobjFRM_207041.userOWNER = Me
        gobjFRM_207041.userEQ_ID = TO_STRING(grdList.Item(menmListCol.EQ_ID, grdList.SelectedRows(0).Index).Value)            '設備ID
        gobjFRM_207041.userDIRECTION = TO_STRING(grdList.Item(menmListCol.DIRECTION, grdList.SelectedRows(0).Index).Value)    '方向
        gobjFRM_207041.userTEXT_ID = TO_STRING(grdList.Item(menmListCol.TEXT_ID, grdList.SelectedRows(0).Index).Value)        'ﾃｷｽﾄID
        gobjFRM_207041.userDENBUN = TO_STRING(grdList.Item(menmListCol.DENBUN, grdList.SelectedRows(0).Index).Value)          '電文

        gobjFRM_207041.ShowDialog()

    End Sub
#End Region

End Class
