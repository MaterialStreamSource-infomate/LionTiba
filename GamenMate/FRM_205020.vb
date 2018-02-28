'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾄﾗｯｷﾝｸﾞﾒﾝﾃﾅﾝｽ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_205020

#Region "　共通変数　                                   "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ
    Private mblnFlag_AllSearch As Boolean = True                '全検索ﾌﾗｸﾞ

    Private mstrTrackingBufferNo As String = ""                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo格納変数
    Private Color_BackColor_Ok As Color = Color.GreenYellow      'ｸﾞﾘｯﾄﾞ展開時の色替え
    Private Color_BackColor_No As Color = Color.White            'ｸﾞﾘｯﾄﾞ展開時の色替え
    Private Color_Selection_Ok As Color = Color.DarkGreen        'ｸﾞﾘｯﾄﾞ選択時の色替え
    Private Color_Selection_No As Color = Color.LightGray        'ｸﾞﾘｯﾄﾞ選択時の色替え

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        OneSearch_Click        '検索ﾎﾞﾀﾝｸﾘｯｸ時
        AllSearch_Click        '全検索ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FTRK_BUF_NO                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.           ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
        FBUF_NAME                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.        　 ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        PALLET_CNT                  'ﾊﾟﾚｯﾄ数(ﾄﾗｯｷﾝｸﾞ存在有無)
        COLOR_CHANGE                '色変えﾌﾗｸﾞ

        MAXCOL

    End Enum

#End Region
#Region "　ｲﾍﾞﾝﾄ　                                      "
#Region "　搬送中ﾄﾗｯｷﾝｸﾞﾘｽﾄ     選択変更ｲﾍﾞﾝﾄ　         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 搬送中ﾄﾗｯｷﾝｸﾞﾘｽﾄ 選択変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList01.SelectionChanged
        Try
            If mFlag_Form_Load = False Then

                '****************************************
                ' 在席ﾄﾗｯｷﾝｸﾞﾘｽﾄ 選択変更処理
                '****************************************
                Call grdListChangeColor_Selection(grdList01)
                If 0 < grdList01.SelectedRows.Count Then
                    txtList01.Text = grdList01.SelectedRows(0).Index
                Else
                    txtList01.Text = -1
                End If

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　在籍ﾄﾗｯｷﾝｸﾞﾘｽﾄ       選択変更ｲﾍﾞﾝﾄ　         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在籍ﾄﾗｯｷﾝｸﾞﾘｽﾄ 選択変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList02_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList02.SelectionChanged
        Try
            If mFlag_Form_Load = False Then

                '****************************************
                ' 在席ﾄﾗｯｷﾝｸﾞﾘｽﾄ 選択変更処理
                '****************************************
                Call grdListChangeColor_Selection(grdList02)
                If 0 < grdList02.SelectedRows.Count Then
                    txtList02.Text = grdList02.SelectedRows(0).Index
                Else
                    txtList02.Text = -1
                End If

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑﾀﾞﾌﾞﾙｸﾘｯｸ　ｲﾍﾞﾝﾄ　                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄの選択解除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_205020_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        Try
            grdList01.ClearSelection()
            grdList02.ClearSelection()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ﾀｲﾏｰ ﾀｲﾑｱｯﾌﾟ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾀｲﾏｰ ﾀｲﾑｱｯﾌﾟ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr205020_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr205020.Tick
        Try

            tmr205020.Enabled = False
            mFlag_Form_Load = True

            '*********************************************
            ' ｸﾞﾘｯﾄﾞ表示
            '*********************************************
            'grdList01.ScrollBars = ScrollBars.None
            'grdList02.ScrollBars = ScrollBars.None
            Call grdListDisplay(grdList01, TO_INTEGER(txtList01.Text))
            Call grdListDisplay(grdList02, TO_INTEGER(txtList02.Text))
            'grdList01.ScrollBars = ScrollBars.Both
            'grdList02.ScrollBars = ScrollBars.Both

        Catch ex As Exception
            ComError(ex)
        Finally
            mFlag_Form_Load = False
            tmr205020.Enabled = True

        End Try

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                                   "
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
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()


        '**********************************************************
        ' 
        '**********************************************************
        txtList01.Text = -1
        txtList01.Visible = False
        txtList02.Text = -1
        txtList02.Visible = False

        '**********************************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '**********************************************************
        grdList01.AllowUserToAddRows = False                                              '行追加             許可設定
        grdList02.AllowUserToAddRows = False                                              '行追加             許可設定
        '======================================
        '搬送中ｸﾞﾘｯﾄﾞ
        '======================================
        Call gobjComFuncFRM.FlexGridInitialize(grdList01, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListDisplay(grdList01)
        grdList01.Font = New Font("ＭＳ ゴシック", 13, FontStyle.Bold)                 'ﾌｫﾝﾄ設定

        '======================================
        '在籍ﾄﾗｯｷﾝｸﾞ
        '======================================
        Call gobjComFuncFRM.FlexGridInitialize(grdList02, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListDisplay(grdList02)
        grdList02.Font = New Font("ＭＳ ゴシック", 13, FontStyle.Bold)                 'ﾌｫﾝﾄ設定

        tmr205020.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS205020_001))
        tmr205020.Enabled = True

        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                                   "
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
        grdList01.Dispose()               'ｸﾞﾘｯﾄﾞ
        grdList02.Dispose()               'ｸﾞﾘｯﾄﾞ
        tmr205020.Dispose()

    End Sub
#End Region
#Region "  F4(詳細)  ﾎﾞﾀﾝ押下処理　                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(詳細) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        '**************************************
        '入力ﾁｪｯｸ
        '**************************************
        If InputCheck(menmCheckCase.OneSearch_Click) = False Then Exit Sub


        '*************************************
        '画面展開
        '*************************************
        MainteDtl_Open(menmCheckCase.OneSearch_Click)


        '*************************************
        '画面更新
        '*************************************
        tmr205020_Tick(Nothing, Nothing)


    End Sub
#End Region
#Region "  F5(全詳細)  ﾎﾞﾀﾝ押下処理　                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5(全詳細) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F5Process()

        '**************************************
        '入力ﾁｪｯｸ
        '**************************************
        If InputCheck(menmCheckCase.AllSearch_Click) = False Then Exit Sub


        '*************************************
        '画面展開
        '*************************************
        MainteDtl_Open(menmCheckCase.AllSearch_Click)


        '*************************************
        '画面更新
        '*************************************
        tmr205020_Tick(Nothing, Nothing)


    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                                   "
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

        Dim blnSTTrack As Boolean = False

        Select Case udtCheck_Case

            Case menmCheckCase.OneSearch_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)

                'ｴﾘｱ選択ﾁｪｯｸ
                If TO_INTEGER(txtList01.Text) = -1 And TO_INTEGER(txtList02.Text) = -1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205020_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                '選択ｴﾘｱﾄﾗｯｷﾝｸﾞ存在ﾁｪｯｸ(List01)
                If TO_INTEGER(txtList01.Text) <> -1 Then
                    If grdList01.Rows(TO_INTEGER(txtList01.Text)).DefaultCellStyle.BackColor = Color_BackColor_No Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205020_02, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If
                End If

                '選択ｴﾘｱﾄﾗｯｷﾝｸﾞ存在ﾁｪｯｸ(List02)
                If TO_INTEGER(txtList02.Text) <> -1 Then
                    If grdList02.Rows(TO_INTEGER(txtList02.Text)).DefaultCellStyle.BackColor = Color_BackColor_No Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205020_02, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If
                End If

                blnCheckErr = False

            Case menmCheckCase.AllSearch_Click
                '(全検索ﾎﾞﾀﾝｸﾘｯｸ時)
                Dim blnExistTRK As Boolean = False

                'ｴﾘｱﾄﾗｯｷﾝｸﾞ存在ﾁｪｯｸ(List01)
                For ii As Integer = 0 To grdList01.Rows.Count - 1
                    If grdList01.Rows(ii).DefaultCellStyle.BackColor = Color_BackColor_Ok Then
                        blnExistTRK = True
                        'Exit For
                    End If
                Next

                'ｴﾘｱﾄﾗｯｷﾝｸﾞ存在ﾁｪｯｸ(List02)
                For ii As Integer = 0 To grdList02.Rows.Count - 1
                    If grdList02.Rows(ii).DefaultCellStyle.BackColor = Color_BackColor_Ok Then
                        blnExistTRK = True
                        'Exit For
                    End If
                Next

                If blnExistTRK = False Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205020_02, PopupFormType.Ok, PopupIconType.Information)
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
#Region "  搬送中、STﾄﾗｯｷﾝｸﾞ ｸﾞﾘｯﾄﾞ表示　               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 搬送中ﾄﾗｯｷﾝｸﾞ ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <param name="grdControl">ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ</param>
    ''' <param name="intIdx"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay(ByVal grdControl As GamenCommon.cmpMDataGrid, Optional ByVal intIdx As Integer = -1)

        Dim strSQL As String                            'SQL文
        Dim objDataSet2 As New DataSet
        Dim objDataTable As New GamenCommon.clsGridDataTable05      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ
        Dim intGouki As Integer                         '号機のｶｳﾝﾄ
        objDataTable.Clear()
        intGouki = 1

        '********************************************************************
        ' DB情報取得
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & "      TDSP_CTRL.FCTRL_VALUE"
        strSQL &= vbCrLf & "     ,TDSP_DISP.FGAMEN_DISP"
        strSQL &= vbCrLf & "     ,'0' AS PALLET_CNT"
        strSQL &= vbCrLf & "     ,'0' AS COLOR_CHANGE"
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "      TDSP_CTRL"
        strSQL &= vbCrLf & "     ,TDSP_DISP"
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "       1 = 1"
        strSQL &= vbCrLf & "   AND TDSP_CTRL.FDISP_ID    = '" & TO_STRING(Me.Name) & "'"
        strSQL &= vbCrLf & "   AND TDSP_CTRL.FCTRL_ID  = '" & TO_STRING(grdControl.Name) & "'"
        strSQL &= vbCrLf & "   AND TDSP_CTRL.FCTRL_VALUE = TDSP_DISP.FDISP_VALUE"
        strSQL &= vbCrLf & "   AND TDSP_CTRL.FTABLE_NAME = TDSP_DISP.FTABLE_NAME"
        strSQL &= vbCrLf & "   AND TDSP_CTRL.FFIELD_NAME = TDSP_DISP.FFIELD_NAME"
        strSQL &= vbCrLf & " ORDER BY"
        strSQL &= vbCrLf & "       TDSP_CTRL.FCTRL_ORDER"

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        gobjDb.SQL = strSQL
        strDataSetName = "TPRG_TRK_BUF"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置      記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶
        Call gobjComFuncFRM.GridDisplay(objDataSet.Tables(strDataSetName), _
                         grdControl, _
                         intSelectRow, _
                         intSelectCol, _
                         objPoint)
        objDataSet = Nothing


        '********************************************************************
        'ﾊﾟﾚｯﾄ数ｾｯﾄ
        '********************************************************************
        For ii As Integer = 0 To grdControl.Rows.Count - 1
            '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行数)

            strSQL = ""
            strSQL &= vbCrLf & " SELECT"
            strSQL &= vbCrLf & "      COUNT(TPRG_TRK_BUF.FPALLET_ID) AS PALLET_CNT"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "      TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE 1 = 1"
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO IN (" & TO_STRING(grdControl.Item(menmListCol.FTRK_BUF_NO, ii).Value) & ")"
            strSQL &= vbCrLf & "      AND NOT (     TPRG_TRK_BUF.FTRK_BUF_NO IN ("
            strSQL &= vbCrLf & "                                                 SELECT FTRK_BUF_NO FROM TMST_TRK WHERE FBUF_KIND IN (" & FBUF_KIND_SASRS & ", " & FBUF_KIND_SHIRA & ")"
            strSQL &= vbCrLf & "                                                 )"
            strSQL &= vbCrLf & "                AND TPRG_TRK_BUF.FRES_KIND = " & FRES_KIND_SZAIKO & ") "
            Dim objDataSet02 As New DataSet           'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）
            Dim strDataSetName02 As String            'ﾃﾞｰﾀｾｯﾄ名
            gobjDb.SQL = strSQL
            strDataSetName02 = "TPRG_TRK_BUF"
            objDataSet02.Clear()
            gobjDb.GetDataSet(strDataSetName02, objDataSet02)
            grdControl.Item(menmListCol.PALLET_CNT, ii).Value = TO_INTEGER(objDataSet02.Tables(strDataSetName02).Rows(0)("PALLET_CNT"))

        Next


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup(grdControl)
        grdControl.HorizontalScrollingOffset = objPoint.X               'ｽｸﾛｰﾙﾊﾞｰ位置　横
        If 0 <= objPoint.Y Then
            grdControl.FirstDisplayedScrollingRowIndex = objPoint.Y     'ｽｸﾛｰﾙﾊﾞｰ位置　縦
        End If
        Call gobjComFuncFRM.GridSelect(grdControl, intIdx, 1, objPoint)                'ｸﾞﾘｯﾄﾞ選択処理


        '--------------------------------------------------------------------
        '選択状態の色変え
        '--------------------------------------------------------------------
        If 0 < grdControl.SelectedRows.Count Then
            If 1 <= TO_INTEGER(grdControl.Item(menmListCol.PALLET_CNT, grdControl.SelectedRows(0).Index).Value) Then
                grdControl.DefaultCellStyle.SelectionBackColor = Color_Selection_Ok
            Else
                grdControl.DefaultCellStyle.SelectionBackColor = Color_Selection_No

            End If
        End If

        For Each objColum As DataGridViewColumn In grdControl.Columns
            objColum.SortMode = DataGridViewColumnSortMode.NotSortable                  '列の並替禁止
        Next

        grdControl.MyBeseDoubleBuffered = True                                          'ちらつき防止

    End Sub
#End Region
#Region "  搬送中、在席ﾄﾗｯｷﾝｸﾞ ｸﾞﾘｯﾄﾞ表示設定           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 搬送中ﾄﾗｯｷﾝｸﾞ ｸﾞﾘｯﾄﾞ表示設定
    ''' </summary>
    ''' <param name="grdControl">ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup(ByVal grdControl As GamenCommon.cmpMDataGrid)


        '=========================================
        'ﾍｯﾀﾞｰ表示変更
        '=========================================
        Dim strTrk_Buf_Name As String = ""      'ﾊﾞｯﾌｧ№名
        Select Case grdControl.Name
            Case grdList01.Name
                '(左のｸﾞﾘｯﾄﾞの場合)
                strTrk_Buf_Name = "搬送中トラッキング"
            Case grdList02.Name
                '(右のｸﾞﾘｯﾄﾞの場合)
                strTrk_Buf_Name = "ＳＴトラッキング"
        End Select
        grdControl.Columns(menmListCol.FTRK_BUF_NO).HeaderText = "バッファ"         '非表示 
        grdControl.Columns(menmListCol.FBUF_NAME).HeaderText = strTrk_Buf_Name
        grdControl.Columns(menmListCol.PALLET_CNT).HeaderText = "カウント"          '非表示
        grdControl.Columns(menmListCol.COLOR_CHANGE).HeaderText = "色変えﾌﾗｸﾞ"      '非表示

        '=========================================
        'ﾍｯﾀﾞｰ部配置変更
        '=========================================
        grdControl.Columns(menmListCol.FBUF_NAME).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        '=========================================
        'ﾃﾞｰﾀ部配置変更
        '=========================================
        grdControl.Columns(menmListCol.FBUF_NAME).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        '=========================================
        '列幅調整
        '=========================================
        '非表示
        grdControl.Columns(menmListCol.FTRK_BUF_NO).Width = 0
        grdControl.Columns(menmListCol.FTRK_BUF_NO).Visible = False
        grdControl.Columns(menmListCol.PALLET_CNT).Width = 0
        grdControl.Columns(menmListCol.PALLET_CNT).Visible = False
        grdControl.Columns(menmListCol.COLOR_CHANGE).Width = 0
        grdControl.Columns(menmListCol.COLOR_CHANGE).Visible = False
        '列幅自動調節
        grdControl.Columns(menmListCol.FBUF_NAME).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        '=========================================
        '表示ﾌｫｰﾏｯﾄ
        '=========================================
        '特になし

        '=========================================
        '行の高さ
        '=========================================
        For ii As Integer = 0 To grdControl.Rows.Count - 1
            grdControl.Rows(ii).Height = GRID_HEIGHT_TITLE_DBL
        Next

        '=========================================
        '行の色変え
        '=========================================
        Call grdListChangeColor(grdControl)

    End Sub
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞのﾃﾞｰﾀ有無でｸﾞﾘｯﾄﾞ色変え              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞのﾃﾞｰﾀ有無でｸﾞﾘｯﾄﾞ色変え
    ''' </summary>
    ''' <param name="grdList"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListChangeColor(ByRef grdList As GamenCommon.cmpMDataGrid)


        For intLoop As Integer = 0 To grdList.Rows.Count - 1

            If 1 <= TO_INTEGER(grdList.Item(menmListCol.PALLET_CNT, intLoop).Value) Then
                grdList.Rows(intLoop).DefaultCellStyle.BackColor = Color_BackColor_Ok
            Else
                grdList.Rows(intLoop).DefaultCellStyle.BackColor = Color_BackColor_No
            End If

        Next

    End Sub
#End Region
#Region "  選択変更時のｸﾞﾘｯﾄﾞ色変え                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 選択変更時のｸﾞﾘｯﾄﾞ色変え
    ''' </summary>
    ''' <param name="grdList"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListChangeColor_Selection(ByRef grdList As GamenCommon.cmpMDataGrid)

        If mFlag_Form_Load = True Then Exit Sub
        If grdList.SelectedRows.Count < 1 Then Exit Sub

        If 1 <= TO_INTEGER(grdList.Item(menmListCol.PALLET_CNT, grdList.SelectedRows(0).Index).Value) Then
            grdList.DefaultCellStyle.SelectionBackColor = Color_Selection_Ok

        Else
            grdList.DefaultCellStyle.SelectionBackColor = Color_Selection_No
            mstrTrackingBufferNo = ""

        End If

        ' 選択されていない方の、選択状態を解除
        If grdList Is grdList01 Then
            Call grdList02.ClearSelection()
            txtList02.Text = -1

        Else
            Call grdList01.ClearSelection()
            txtList01.Text = -1

        End If

    End Sub
#End Region
#Region "　ﾒﾝﾃﾅﾝｽ詳細画面展開　                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒﾝﾃﾅﾝｽ詳細画面展開
    ''' </summary>
    ''' <param name="udtCheck_Case"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MainteDtl_Open(ByVal udtCheck_Case As menmCheckCase)

        '******************************************
        ' 画面遷移
        '******************************************
        If IsNull(gobjFRM_205030) = False Then
            gobjFRM_205030.Close()
            gobjFRM_205030.Dispose()
            gobjFRM_205030 = Nothing
        End If

        gobjFRM_205030 = New FRM_205030

        If udtCheck_Case = menmCheckCase.AllSearch_Click Then
            gobjFRM_205030.userTRK_BUF_NO = DSP_MNT_GRD_ALL
        ElseIf TO_INTEGER(txtList01.Text) <> -1 Then
            gobjFRM_205030.userTRK_BUF_NO = TO_STRING(grdList01.Item(menmListCol.FTRK_BUF_NO, TO_INTEGER(txtList01.Text)).Value)      'grdList01のﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№を渡す。
        ElseIf TO_INTEGER(txtList02.Text) <> -1 Then
            gobjFRM_205030.userTRK_BUF_NO = TO_STRING(grdList02.Item(menmListCol.FTRK_BUF_NO, TO_INTEGER(txtList02.Text)).Value)      'grdList02のﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№を渡す。
        End If

        gobjFRM_205030.ShowDialog()

    End Sub
#End Region

End Class
