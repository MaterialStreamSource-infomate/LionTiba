'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】緊急時入庫登録画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_305070
#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    '選択されたｸﾞﾘｯﾄﾞﾘｽﾄの配列

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        KinkyuuBtn_Click                 '緊急登録ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FTRK_BUF_NO         ' 生産入庫設定状態  .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(非表示)
        FBUF_NAME           ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(入庫ST)
        XHINMEI_CD          ' 品目ﾏｽﾀ           .品名記号
        FHINMEI_CD          ' 生産入庫設定状態  .品目ｺｰﾄﾞ
        FHINMEI             ' 品目ﾏｽﾀ           .品名
        XPROD_LINE          ' 生産入庫設定状態  .生産ﾗｲﾝNo
        XPROD_LINE_NAME     ' 生産ﾗｲﾝﾏｽﾀ        .生産ﾗｲﾝ名
        XKINKYU_BUF_TO      ' 生産入庫設定状態  .緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(非表示)
        XKINKYU_BUF_TO_NAME ' 生産入庫設定状態  .緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(出庫ST)
        XRESULT_NUM       ' 生産入庫設定状態  .緊急時実績数

        MAXCOL

    End Enum

#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　ﾀｲﾏｰ ｲﾍﾞﾝﾄ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾀｲﾏｰ ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr305070_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr305070.Tick

        Call tmr305070_TickProcess()

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

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListDisplaySub(grdList)

        tmr305070.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS311050_001))
        tmr305070.Enabled = True

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
        grdList.Dispose()

    End Sub
#End Region

#Region "  F1(緊急登録)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(緊急登録) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()

        tmr305070.Enabled = False

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.KinkyuuBtn_Click) = False Then
            tmr305070.Enabled = True
            Exit Sub
        End If

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_305071) = False Then
            gobjFRM_305071.Close()
            gobjFRM_305071.Dispose()
            gobjFRM_305071 = Nothing
        End If
        gobjFRM_305071 = New FRM_305071
        Call SetProperty()                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_305071.ShowDialog()            '画面表示
        If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
            '(ｷｬﾝｾﾙ時)
            tmr305070.Enabled = True
            Exit Sub
        End If

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)

        tmr305070.Enabled = True

    End Sub
#End Region

#Region "　入力ﾁｪｯｸ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case

            Case menmCheckCase.KinkyuuBtn_Click
                '(緊急登録ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ｴﾘｱ選択ﾁｪｯｸ
                '==========================
                If grdList.SelectedRows.Count < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                '==========================
                ' ｸﾚｰﾝ切離状態ﾁｪｯｸ
                '==========================
                If CheckAllCrane_CUT_STS = False Then
                    Call gobjComFuncFRM.DisplayPopup("クレーンが切離されていません。", PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                '==========================
                ' 連続入庫設定確認
                '==========================
                If TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, grdList.SelectedRows(0).Index).Value) = "" Then
                    Call gobjComFuncFRM.DisplayPopup("連続入庫の設定がされていない入庫STです。", PopupFormType.Ok, PopupIconType.Information)
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

#Region "　ｸﾞﾘｯﾄﾞ表示　                             "
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
        strSQL &= vbCrLf & "       XSTS_PRODUCT_IN.FTRK_BUF_NO "                '生産入庫設定状態   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        strSQL &= vbCrLf & "     , TMST_TRK.FBUF_NAME "                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ    .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(入庫ST)
        strSQL &= vbCrLf & "     , TMST_ITEM.XHINMEI_CD "                       '品目ﾏｽﾀ            .品名記号
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FHINMEI_CD "                 '生産入庫設定状態   .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                          '品目ﾏｽﾀ            .品名
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XPROD_LINE "                 '生産入庫設定状態   .生産ﾗｲﾝNo.
        strSQL &= vbCrLf & "     , XMST_PROD_LINE.XPROD_LINE_NAME "             '生産ﾗｲﾝﾏｽﾀ         .生産ﾗｲﾝ名
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XKINKYU_BUF_TO "             '生産入庫設定状態   .緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(非表示)
        strSQL &= vbCrLf & "     , TMST_TRK_TO.FBUF_NAME "                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ    .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(出庫ST)
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XRESULT_NUM "                '生産入庫設定状態   .緊急時実績数

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_PRODUCT_IN "                   '【生産入庫設定状態】
        strSQL &= vbCrLf & "  , TMST_TRK "                          '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ】
        strSQL &= vbCrLf & "  , TMST_ITEM "                         '【品目ﾏｽﾀ】
        strSQL &= vbCrLf & "  , XMST_PROD_LINE "                    '【生産ﾗｲﾝﾏｽﾀ】
        strSQL &= vbCrLf & "  , TMST_TRK TMST_TRK_TO "              '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ】(出庫ST表示用)

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件
        strSQL &= vbCrLf & "    AND XSTS_PRODUCT_IN.FTRK_BUF_NO >= 2000 "                           '2階のｺﾝﾍﾞﾔのみ表示
        strSQL &= vbCrLf & "    AND XSTS_PRODUCT_IN.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "    AND XSTS_PRODUCT_IN.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "    AND XSTS_PRODUCT_IN.XPROD_LINE = XMST_PROD_LINE.XPROD_LINE(+) "
        strSQL &= vbCrLf & "    AND XSTS_PRODUCT_IN.XKINKYU_BUF_TO = TMST_TRK_TO.FTRK_BUF_NO(+) "

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & " XSTS_PRODUCT_IN.FGRID_DISPLAYINDEX "
        strSQL &= vbCrLf


        '*******************************************
        '表示前のﾘｽﾄ選択記憶
        '*******************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置     記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶

        If grdList.SelectedCells.Count = 0 Then
            intSelectRow = -1               'ﾘｽﾄの行
            intSelectCol = -1               'ﾘｽﾄの列
        Else
            intSelectRow = grdList.SelectedCells(0).RowIndex             'ﾘｽﾄの行
            intSelectCol = grdList.SelectedCells(0).ColumnIndex          'ﾘｽﾄの列
        End If

        objPoint.X = grdList.HorizontalScrollingOffset           'ｽｸﾛｰﾙﾊﾞｰ位置　横
        objPoint.Y = grdList.FirstDisplayedScrollingRowIndex     'ｽｸﾛｰﾙﾊﾞｰ位置　縦

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, strSQL, True)

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, intSelectRow, intSelectCol, objPoint)       'ｸﾞﾘｯﾄﾞ選択処理

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

#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(詳細)　                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty()

        gobjFRM_305071.userFTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value)          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        ' ''gobjFRM_305071.userFTRK_BUF_NO_Disp = TO_STRING(grdList.Item(menmListCol.FBUF_NAME, grdList.SelectedRows(0).Index).Value)       '入庫ST
        ' ''gobjFRM_305071.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, grdList.SelectedRows(0).Index).Value)            '品名記号
        ' ''gobjFRM_305071.userFHINMEI = TO_STRING(grdList.Item(menmListCol.FHINMEI, grdList.SelectedRows(0).Index).Value)                  '品名
        ' ''gobjFRM_305071.userXPROD_LINE = TO_STRING(grdList.Item(menmListCol.XPROD_LINE, grdList.SelectedRows(0).Index).Value)            '生産ﾗｲﾝNo.
        ' ''gobjFRM_305071.userXPROD_LINE_NAME = TO_STRING(grdList.Item(menmListCol.XPROD_LINE_NAME, grdList.SelectedRows(0).Index).Value)  '生産ﾗｲﾝ名

        If TO_STRING(grdList.Item(menmListCol.XKINKYU_BUF_TO, grdList.SelectedRows(0).Index).Value) <> "" Then
            '(登録済の場合)
            ' ''gobjFRM_305071.userXKINKYU_BUF_TO = TO_STRING(grdList.Item(menmListCol.XKINKYU_BUF_TO, grdList.SelectedRows(0).Index).Value)            '緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            ' ''gobjFRM_305071.userXKINKYU_BUF_TO_Disp = TO_STRING(grdList.Item(menmListCol.XKINKYU_BUF_TO_NAME, grdList.SelectedRows(0).Index).Value)  '出庫ST
            gobjFRM_305071.userSET_FLAG = True                                                                                                      '登録済ﾌﾗｸﾞ

        Else
            '(未登録の場合)
            gobjFRM_305071.userSET_FLAG = False                                                                                                     '登録済ﾌﾗｸﾞ
        End If

    End Sub
#End Region

#Region "　ｸﾚｰﾝ切離状態ﾁｪｯｸ　                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾚｰﾝ切離状態ﾁｪｯｸ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function CheckAllCrane_CUT_STS() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = False       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT 
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TSTS_CRANE.FEQ_ID "                 'ｸﾚｰﾝ状態.  設備ID
        strSQL &= vbCrLf & "  , TSTS_EQ_CTRL.FEQ_NAME "             '設備状況.  設備名
        strSQL &= vbCrLf & "  , TSTS_EQ_CTRL.FEQ_CUT_STS "          '設備状況.  切離状態
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TSTS_CRANE "                        '【ｸﾚｰﾝ状態】
        strSQL &= vbCrLf & "  , TSTS_EQ_CTRL "                      '【設備状況】

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        TSTS_CRANE.FEQ_ID = TSTS_EQ_CTRL.FEQ_ID(+) "

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    TSTS_CRANE.FEQ_ID "

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TSTS_EQ_CTRL"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                If TO_STRING(objRow("FEQ_CUT_STS")) = TO_STRING(FEQ_CUT_STS_SON) Then
                    '(切離状態)

                ElseIf TO_STRING(objRow("FEQ_CUT_STS")) = TO_STRING(FEQ_CUT_STS_SOFF) Then
                    '(切離状態ではない場合)
                    blnCheckErr = True
                    Exit For
                End If
            Next
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

#Region "  表示更新ﾀｲﾏｰ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面更新ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr305070_TickProcess()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region

End Class
