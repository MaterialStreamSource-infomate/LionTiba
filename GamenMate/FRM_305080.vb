'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】ﾊﾞｰｽ割付ｺﾝﾍﾞﾔ設定画面
' 【作成】SIT
'**********************************************************************************************
#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
Imports GamenCommon
#End Region
Public Class FRM_305080
#Region "　共通変数　                                   "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ
    Private mblnFlag_AllSearch As Boolean = True                '全検索ﾌﾗｸﾞ

    Private Color_BackColor_Ok As Color = Color.White               'ｸﾞﾘｯﾄﾞ展開時の色替え
    Private Color_Selection_Ok As Color = Color.DarkGreen           'ｸﾞﾘｯﾄﾞ選択時の色替え

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        SETTEI_Click            '設定ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        XBERTH_NAME                 'ﾊﾞｰｽ名称
        XBERTH_GROUP                '出荷ﾊﾞｰｽ状況.          ﾊﾞｰｽｸﾞﾙｰﾌﾟ(CVｸﾞﾙｰﾌﾟ)
        XBERTH_NO                   '出荷ﾊﾞｰｽ状況.        　ﾊﾞｰｽNo.
        XBERTH_HOUKOU               '出荷ﾊﾞｰｽ状況.          積込方向
        XBERTH_HOUKOU_Disp          '出荷ﾊﾞｰｽ状況.          積込方向(表示用)

        DATA05                      '未使用

        MAXCOL

    End Enum

#End Region
#Region "　ｲﾍﾞﾝﾄ　                                      "
#Region "　左ｸﾞﾘｯﾄﾞ     選択変更ｲﾍﾞﾝﾄ　                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 左ｸﾞﾘｯﾄﾞ     選択変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList01.SelectionChanged
        Try
            If mFlag_Form_Load = False Then

                '' ''===================================
                '' '' 設定ﾓｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
                '' ''===================================
                ' ''Call gobjComFuncFRM.cboSetup(Me.Name, Me.cboXCONVYOR_YOUTO, True)


                '****************************************
                ' 左ｸﾞﾘｯﾄﾞ 選択変更処理
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
#Region "　右ｸﾞﾘｯﾄﾞ     選択変更ｲﾍﾞﾝﾄ　                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 右ｸﾞﾘｯﾄﾞ       選択変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList02_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList02.SelectionChanged
        Try
            If mFlag_Form_Load = False Then

                '' ''===================================
                '' '' 設定ﾓｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
                '' ''===================================
                ' ''Call gobjComFuncFRM.cboSetup(Me.Name, Me.cboXCONVYOR_YOUTO, True)

                '****************************************
                ' 右ｸﾞﾘｯﾄﾞ 選択変更処理
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
    Private Sub FRM_305080_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
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
    Private Sub tmr305080_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr305080.Tick
        Try

            tmr305080.Enabled = False
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
            tmr305080.Enabled = True

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
        'CVｸﾞﾙｰﾌﾟ ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        Call Make_cboXBERTH_GROUP()

        '**********************************************************
        '積込方向 ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        Call gobjComFuncFRM.cboSetup(Me.Name, cboXTUMI_HOUKOU, False)

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
        '左ｸﾞﾘｯﾄﾞ
        '======================================
        'Call gobjComFuncFRM.FlexGridInitialize(grdList01, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call gobjComFuncFRM.FlexGridInitialize(grdList01, 1, 0)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListDisplay(grdList01)
        grdList01.Font = New Font("ＭＳ ゴシック", 13, FontStyle.Bold)                 'ﾌｫﾝﾄ設定

        '======================================
        '右ｸﾞﾘｯﾄﾞ
        '======================================
        Call gobjComFuncFRM.FlexGridInitialize(grdList02, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call gobjComFuncFRM.FlexGridInitialize(grdList02, 1, 0)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListDisplay(grdList02)
        grdList02.Font = New Font("ＭＳ ゴシック", 13, FontStyle.Bold)                 'ﾌｫﾝﾄ設定

        tmr305080.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS305080_001))
        tmr305080.Enabled = True

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
        tmr305080.Dispose()

    End Sub
#End Region
#Region "  F4(設定)  ﾎﾞﾀﾝ押下処理　                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(設定) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        '**************************************
        '入力ﾁｪｯｸ
        '**************************************
        If InputCheck(menmCheckCase.SETTEI_Click) = False Then Exit Sub


        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        Call SendSocket01()


        '*************************************
        '画面更新
        '*************************************
        tmr305080_Tick(Nothing, Nothing)


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

            Case menmCheckCase.SETTEI_Click
                '(設定ﾎﾞﾀﾝｸﾘｯｸ時)

                '========================================
                'ｸﾞﾘｯﾄﾞ選択ﾁｪｯｸ
                '========================================
                If TO_INTEGER(txtList01.Text) = -1 And TO_INTEGER(txtList02.Text) = -1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305050_01, PopupFormType.Ok, PopupIconType.Information)
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

#Region "  ｺﾝﾍﾞﾔ ｸﾞﾘｯﾄﾞ表示　                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾍﾞﾔ ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <param name="grdControl">ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ</param>
    ''' <param name="intIdx"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay(ByVal grdControl As GamenCommon.cmpMDataGrid, Optional ByVal intIdx As Integer = -1)

        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataTable As New clsGridDataTable05      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ
        objDataTable.Clear()

        Try

            '********************************************************************
            ' DB情報取得
            '********************************************************************
            strSQL = ""
            strSQL &= vbCrLf & " SELECT"
            strSQL &= vbCrLf & "      TDSP_CTRL.FCTRL_VALUE"
            strSQL &= vbCrLf & "     ,TDSP_DISP.FGAMEN_DISP"
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
            strDataSetName = "TDSP_CTRL"
            objDataSet.Clear()
            gobjDb.GetDataSet(strDataSetName, objDataSet)

            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For Each objRow In objDataSet.Tables(strDataSetName).Rows

                    '********************************************************************
                    ' 出荷ｺﾝﾍﾞﾔ状況取得
                    '********************************************************************
                    Dim objXSTS_BERTH As New TBL_XSTS_BERTH(gobjOwner, gobjDb, Nothing)
                    objXSTS_BERTH.XBERTH_NO = TO_STRING(objRow("FCTRL_VALUE"))                  'ﾊﾞｰｽNo        ｾｯﾄ
                    objXSTS_BERTH.GET_XSTS_BERTH(True)                                          '情報取得

                    '**********************************
                    ' 積込方向
                    '**********************************
                    Dim strXTUMI_HOUKOU_DISP As String = ""            '積込方向
                    Select Case objXSTS_BERTH.XTUMI_HOUKOU
                        Case XTUMI_HOUKOU_JBACK
                            '(後積のとき)
                            strXTUMI_HOUKOU_DISP = "後積"

                        Case XTUMI_HOUKOU_JSIDE
                            '(片横積のとき)
                            strXTUMI_HOUKOU_DISP = "片横積"

                        Case XTUMI_HOUKOU_JWING
                            '(両横積のとき)
                            strXTUMI_HOUKOU_DISP = "両横積"

                        Case XTUMI_HOUKOU_JALL
                            '(ALLのとき)
                            strXTUMI_HOUKOU_DISP = "ALL"

                    End Select

                    objDataTable.userAddRowDataSet(TO_STRING(objRow("FGAMEN_DISP")), _
                                                   TO_STRING(objXSTS_BERTH.XBERTH_GROUP), _
                                                   TO_STRING(objXSTS_BERTH.XBERTH_NO), _
                                                   TO_STRING(objXSTS_BERTH.XTUMI_HOUKOU), _
                                                   strXTUMI_HOUKOU_DISP _
                                                   )
                Next

            End If


            '*******************************************
            '表示前のﾘｽﾄ選択記憶
            '*******************************************
            Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置      記憶
            Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
            Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶

            If grdControl.SelectedCells.Count = 0 Then
                intSelectRow = -1               'ﾘｽﾄの行
                intSelectCol = -1               'ﾘｽﾄの列
            Else
                intSelectRow = grdControl.SelectedCells(0).RowIndex             'ﾘｽﾄの行
                intSelectCol = grdControl.SelectedCells(0).ColumnIndex          'ﾘｽﾄの列
            End If

            objPoint.X = grdControl.HorizontalScrollingOffset           'ｽｸﾛｰﾙﾊﾞｰ位置　横
            objPoint.Y = grdControl.FirstDisplayedScrollingRowIndex     'ｽｸﾛｰﾙﾊﾞｰ位置　縦


            '********************************************************************
            'ｸﾞﾘｯﾄﾞ表示
            '********************************************************************
            grdControl.DataSource = objDataTable


            '********************************************************************
            'ｸﾞﾘｯﾄﾞ表示設定
            '********************************************************************
            Call grdListSetup(grdControl)
            grdControl.HorizontalScrollingOffset = objPoint.X               'ｽｸﾛｰﾙﾊﾞｰ位置　横
            If 0 <= objPoint.Y Then
                grdControl.FirstDisplayedScrollingRowIndex = objPoint.Y     'ｽｸﾛｰﾙﾊﾞｰ位置　縦
            End If
            Call gobjComFuncFRM.GridSelect(grdControl, intSelectRow, 1, objPoint)    'ｸﾞﾘｯﾄﾞ選択処理


            '--------------------------------------------------------------------
            '選択状態の色変え
            '--------------------------------------------------------------------
            If 0 < grdControl.SelectedRows.Count Then
                grdControl.DefaultCellStyle.SelectionBackColor = Color_Selection_Ok
            End If

            For Each objColum As DataGridViewColumn In grdControl.Columns
                objColum.SortMode = DataGridViewColumnSortMode.NotSortable                  '列の並替禁止
            Next

            grdControl.MyBeseDoubleBuffered = True                                          'ちらつき防止

        Catch ex As Exception
            ex.Message.ToString()
        End Try

    End Sub
#End Region
#Region "  ｺﾝﾍﾞﾔ ｸﾞﾘｯﾄﾞ表示設定                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾍﾞﾔ ｸﾞﾘｯﾄﾞ表示設定
    ''' </summary>
    ''' <param name="grdControl">ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup(ByVal grdControl As GamenCommon.cmpMDataGrid)


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdControl)


        '************************************************
        'ｸﾞﾘｯﾄﾞ列の並替ﾓｰﾄﾞ変更
        '************************************************
        Call gobjComFuncFRM.GridSortModeSet(grdControl, DataGridViewColumnSortMode.NotSortable)
        grdControl.Columns(menmListCol.XBERTH_HOUKOU_Disp).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill   '列幅自動調整
        grdControl.AllowUserToResizeColumns = False


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

            grdList.Rows(intLoop).DefaultCellStyle.BackColor = Color_BackColor_Ok

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


        grdList.DefaultCellStyle.SelectionBackColor = Color_Selection_Ok


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

#Region "  ｿｹｯﾄ送信01                                   "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信01
    ''' </summary>
    ''' <returns>True:送信成功  False:送信失敗</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function SendSocket01() As Boolean
        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        Dim strXBERTH_NAME As String = ""
        If TO_INTEGER(txtList01.Text) <> -1 Then
            strXBERTH_NAME = TO_STRING(grdList01.Item(menmListCol.XBERTH_NAME, TO_INTEGER(txtList01.Text)).Value)
        ElseIf TO_INTEGER(txtList02.Text) <> -1 Then
            strXBERTH_NAME = TO_STRING(grdList02.Item(menmListCol.XBERTH_NAME, TO_INTEGER(txtList02.Text)).Value)
        End If
        strMessage = ""
        strMessage &= strXBERTH_NAME & "を"
        strMessage &= TO_STRING(cboXTUMI_HOUKOU.Text) & "としてよろしいですか？"
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
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
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400204          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        Dim strXBERTH_NO As String = ""                     'ﾊﾞｰｽ№
        Dim strXBERTH_GROUP As String = ""                  'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
        Dim strXTUMI_HOUKOU As String = ""                  '積込方向


        If TO_INTEGER(txtList01.Text) <> -1 Then
            strXBERTH_NO = TO_STRING(grdList01.Item(menmListCol.XBERTH_NO, TO_INTEGER(txtList01.Text)).Value)
        ElseIf TO_INTEGER(txtList02.Text) <> -1 Then
            strXBERTH_NO = TO_STRING(grdList02.Item(menmListCol.XBERTH_NO, TO_INTEGER(txtList02.Text)).Value)
        End If

        strXTUMI_HOUKOU = TO_STRING(cboXTUMI_HOUKOU.SelectedValue)

        strXBERTH_GROUP = TO_STRING(cboXBERTH_GROUP.Text)


        objTelegram.SETIN_DATA("XDSPBERTH_NO", strXBERTH_NO)                'ﾊﾞｰｽNo    ｾｯﾄ
        objTelegram.SETIN_DATA("XDSPBERTH_GROUP", strXBERTH_GROUP)          'ﾊﾞｰｽｸﾞﾙｰﾌﾟ    ｾｯﾄ
        objTelegram.SETIN_DATA("XDSPTUMI_HOUKOU", strXTUMI_HOUKOU)       '積込方向    ｾｯﾄ

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                 'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = FRM_MSG_FRM305050_03
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

#Region "  CVｸﾞﾙｰﾌﾟ ｺﾝﾎﾞﾎﾞｯｸｽ作成                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' CVｸﾞﾙｰﾌﾟ ｺﾝﾎﾞﾎﾞｯｸｽ作成
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Make_cboXBERTH_GROUP()

        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        cboXBERTH_GROUP.Items.Clear()                   '初期化
        cboXBERTH_GROUP.Items.Add("")

        Try
            '********************************************************************
            ' DB情報取得
            '********************************************************************
            strSQL = ""
            strSQL &= vbCrLf & " SELECT DISTINCT "
            strSQL &= vbCrLf & "      XSTS_CONVEYOR.XBERTH_GROUP"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "      XSTS_CONVEYOR "
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "      XSTS_CONVEYOR.XBERTH_GROUP"


            '********************************************************************
            'ﾃﾞｰﾀｾｯﾄ取得
            '********************************************************************
            Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）
            Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
            gobjDb.SQL = strSQL
            strDataSetName = "XSTS_CONVEYOR"
            objDataSet.Clear()
            gobjDb.GetDataSet(strDataSetName, objDataSet)

            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For Each objRow In objDataSet.Tables(strDataSetName).Rows
                    If TO_INTEGER(objRow("XBERTH_GROUP")) >= 0 Then
                        '(0以上のみ追加)
                        cboXBERTH_GROUP.Items.Add(TO_STRING(objRow("XBERTH_GROUP")))
                    End If
                Next
            End If

        Catch ex As Exception
            ex.Message.ToString()
        End Try

    End Sub

#End Region

End Class
