'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】車両ﾏｽﾀ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_306020

#Region "　共通変数　                           "

    ''検索条件用構造体
    'Private mudtSEARCH_ITEM As New SEARCH_ITEM

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol
        XSYARYOU_NO                     '車輌ﾏｽﾀ.			車輌番号
        XTUMI_HOUKOU                    '車輌ﾏｽﾀ.			積込方向
        XTUMI_HOUKOU_DISP               '車輌ﾏｽﾀ.			積込方向(表示用)
        XTUMI_HOUHOU                    '車輌ﾏｽﾀ.			積込方法
        XTUMI_HOUHOU_DISP               '車輌ﾏｽﾀ.			積込方法(表示用)
        XNOT_USER                       '車輌ﾏｽﾀ.			未使用区分
        XNOT_USER_DISP                  '車輌ﾏｽﾀ.			未使用区分(表示用)
        FENTRY_DT                       '車輌ﾏｽﾀ.			登録日時
        XCARD_NO                        '車輌ﾏｽﾀ.			ｶｰﾄﾞNo.
        XSYASYU_KBN                     '車輌ﾏｽﾀ.			車種区分
        XSYASYU_KBN_DISP                '車輌ﾏｽﾀ.			車種区分(表示用)
        XSYASYU_COMMENT                 '車輌ﾏｽﾀ.			車種ｺﾒﾝﾄ
        XGYOUSYA_CD                     '車輌ﾏｽﾀ.			業者ｺｰﾄﾞ
        XGYOUSYA_NAME                   '業者ﾏｽﾀ.			業者名
        XLOADER_POSSIBLE                '車輌ﾏｽﾀ.           ﾛｰﾀﾞ対応
        XLOADER_POSSIBLE_DISP           '車輌ﾏｽﾀ.           ﾛｰﾀﾞ対応(表示用)
        XSYARYOU_MODE                   '車輌ﾏｽﾀ.           ﾛｰﾀﾞﾓｰﾄﾞ

        MAXCOL

    End Enum

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        AddBtn_Click                    '追加ﾎﾞﾀﾝｸﾘｯｸ時
        UpdateBtn_Click                 '変更ﾎﾞﾀﾝｸﾘｯｸ時
        DeleteBtn_Click                 '削除ﾎﾞﾀﾝｸﾘｯｸ時
        Print_Click                     '印刷ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                           "
    '検索条件
    Private Structure SEARCH_ITEM
        Dim XSYARYOU_NO As String        '車輌番号
    End Structure
#End Region
#Region "　ｲﾍﾞﾝﾄ　                              "
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                           "
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
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                             "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                           "
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region

#Region "  F4(追加)　ﾎﾞﾀﾝ押下処理　             "
    '*******************************************************************************************************************
    '【機能】F4  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F4Process()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.AddBtn_Click) = False Then

            Exit Sub

        End If


        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_306021) = False Then
            gobjFRM_306021.Close()
            gobjFRM_306021.Dispose()
            gobjFRM_306021 = Nothing
        End If
        gobjFRM_306021 = New FRM_306021
        Call SetProperty(BUTTONMODE_ADD)                   'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_306021.userButtonMode = BUTTONMODE_ADD     'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_306021.ShowDialog()            '展開
        If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If

        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList)


    End Sub
#End Region
#Region "  F5(変更)　ﾎﾞﾀﾝ押下処理　             "
    '*******************************************************************************************************************
    '【機能】F5  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F5Process()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.UpdateBtn_Click) = False Then

            Exit Sub

        End If


        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_306021) = False Then
            gobjFRM_306021.Close()
            gobjFRM_306021.Dispose()
            gobjFRM_306021 = Nothing
        End If
        gobjFRM_306021 = New FRM_306021
        Call SetProperty(BUTTONMODE_UPDATE)                     'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_306021.userButtonMode = BUTTONMODE_UPDATE       'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_306021.ShowDialog()            '展開
        If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If


        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList)


    End Sub
#End Region
#Region "  F6(削除)　ﾎﾞﾀﾝ押下処理　             "
    '*******************************************************************************************************************
    '【機能】F6  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F6Process()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.DeleteBtn_Click) = False Then

            Exit Sub

        End If

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_306021) = False Then
            gobjFRM_306021.Close()
            gobjFRM_306021.Dispose()
            gobjFRM_306021 = Nothing
        End If
        gobjFRM_306021 = New FRM_306021
        Call SetProperty(BUTTONMODE_DELETE)                                 'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_306021.userButtonMode = BUTTONMODE_DELETE     'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_306021.ShowDialog()            '展開
        If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If


        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList)


    End Sub
#End Region
#Region "  F7(印刷)  ﾎﾞﾀﾝ押下処理               "
    '*******************************************************************************************************************
    '【機能】F7  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F7Process()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Print_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udeRet As PopupFormType
        udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_PRINT_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> PopupFormType.Ok Then
            Exit Sub
        End If

        '*******************************************************
        '印刷処理
        '*******************************************************
        Call printOut()


    End Sub
#End Region

#Region "　入力ﾁｪｯｸ　                           "
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
            Case menmCheckCase.AddBtn_Click
                '(追加ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.UpdateBtn_Click
                '(変更ﾎﾞﾀﾝｸﾘｯｸ時)

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

            Case menmCheckCase.DeleteBtn_Click
                '(削除ﾎﾞﾀﾝｸﾘｯｸ時)

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

            Case menmCheckCase.Print_Click
                '(印刷ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ　表示ﾃﾞｰﾀﾁｪｯｸ
                '==========================
                If grdList.Rows.Count <= 0 Then
                    '(ﾃﾞｰﾀが一行もない場合)
                    Exit Function
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
#Region "　構造体ｾｯﾄ　                          "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SearchItem_Set()

        ' ''********************************************************************
        ' ''構造体に値をｾｯﾄ
        ' ''********************************************************************

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示　                         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
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
        strSQL &= vbCrLf & "     XMST_SYARYOU.XSYARYOU_NO "                             '車輌ﾏｽﾀ.			車輌番号
        strSQL &= vbCrLf & "   , XMST_SYARYOU.XTUMI_HOUKOU "                            '車輌ﾏｽﾀ.			積込方向
        strSQL &= vbCrLf & "   , HASH01.FGAMEN_DISP AS XTUMI_HOUKOU_DSP "               '車輌ﾏｽﾀ.           積込方向(表示用)
        strSQL &= vbCrLf & "   , XMST_SYARYOU.XTUMI_HOUHOU "                            '車輌ﾏｽﾀ.			積込方法
        strSQL &= vbCrLf & "   , HASH02.FGAMEN_DISP AS XTUMI_HOUHOU_DSP "               '車輌ﾏｽﾀ.           積込方法(表示用)
        strSQL &= vbCrLf & "   , XMST_SYARYOU.XNOT_USER "                               '車輌ﾏｽﾀ.			未使用区分
        strSQL &= vbCrLf & "   , HASH03.FGAMEN_DISP AS XNOT_USER_DSP "                  '車輌ﾏｽﾀ.           未使用区分(表示用)
        strSQL &= vbCrLf & "   , XMST_SYARYOU.FENTRY_DT "                               '車輌ﾏｽﾀ.           登録日時
        strSQL &= vbCrLf & "   , XMST_SYARYOU.XCARD_NO "                                '車輌ﾏｽﾀ.			ｶｰﾄﾞNo.
        strSQL &= vbCrLf & "   , XMST_SYARYOU.XSYASYU_KBN "                             '車輌ﾏｽﾀ.			車種区分
        strSQL &= vbCrLf & "   , XMST_SYASYU.XSYASYU_NAME "                             '輸送手段ﾏｽﾀ.       車種名
        strSQL &= vbCrLf & "   , XMST_SYARYOU.XSYASYU_COMMENT "                         '車輌ﾏｽﾀ.			車種ｺﾒﾝﾄ
        strSQL &= vbCrLf & "   , XMST_SYARYOU.XGYOUSYA_CD "                             '車輌ﾏｽﾀ.			業者ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XMST_GYOUSYA.XGYOUSYA_NAME "                           '車輌ﾏｽﾀ.			業者名
        strSQL &= vbCrLf & "   , XMST_SYARYOU.XLOADER_POSSIBLE "                        '車輌ﾏｽﾀ.			ﾛｰﾀﾞ対応
        strSQL &= vbCrLf & "   , HASH04.FGAMEN_DISP AS XLOADER_POSSIBLE_DSP "           '車輌ﾏｽﾀ.           ﾛｰﾀﾞ対応(表示用)    ※2013/06/17 h.okumura 未完成
        strSQL &= vbCrLf & "   , XMST_SYARYOU.XSYARYOU_MODE "                           '車輌ﾏｽﾀ.			ﾛｰﾀﾞﾓｰﾄﾞ

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     XMST_SYARYOU "                                      '車輌ﾏｽﾀ
        strSQL &= vbCrLf & "   , XMST_GYOUSYA "                                      '業者ﾏｽﾀ
        strSQL &= vbCrLf & "   , XMST_SYASYU "                                       '輸送手段ﾏｽﾀ
        strSQL &= vbCrLf & "   , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XMST_SYARYOU", "XTUMI_HOUKOU")     '積込方向
        strSQL &= vbCrLf & "   , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "XMST_SYARYOU", "XTUMI_HOUHOU")     '積込方法
        strSQL &= vbCrLf & "   , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "XMST_SYARYOU", "XNOT_USER")        '未使用区分
        strSQL &= vbCrLf & "   , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "XMST_SYARYOU", "XLOADER_POSSIBLE") 'ﾛｰﾀﾞ対応 ※2013/06/17 h.okumura 未完成

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 1 = 1 "          '必ず通る条件
        strSQL &= vbCrLf & "   AND XMST_SYARYOU.XGYOUSYA_CD = XMST_GYOUSYA.XGYOUSYA_CD(+) "
        strSQL &= vbCrLf & "   AND XMST_SYARYOU.XSYASYU_KBN = XMST_SYASYU.XSYASYU_KBN(+) "
        strSQL &= vbCrLf & "   AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XMST_SYARYOU", "XTUMI_HOUKOU")  '積込方向
        strSQL &= vbCrLf & "   AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "XMST_SYARYOU", "XTUMI_HOUHOU")  '積込方法
        strSQL &= vbCrLf & "   AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "XMST_SYARYOU", "XNOT_USER")     '未使用区分
        strSQL &= vbCrLf & "   AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "XMST_SYARYOU", "XLOADER_POSSIBLE")   'ﾛｰﾀﾞ対応 ※2013/06/17 h.okumura 未完成

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

    End Sub
#End Region
#Region "  ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】 
    '*******************************************************************************************************************
    Private Sub SetProperty(ByVal intBtnMode As Integer)

        Dim intRow As Integer = 0

        If intBtnMode = BUTTONMODE_ADD Then
            '(追加のとき)
            gobjFRM_306021.userXSYARYOU_NO = Nothing             '車輌番号

        ElseIf intBtnMode = BUTTONMODE_UPDATE Then
            '(変更のとき)
            intRow = grdList.SelectedRows(0).Index
            gobjFRM_306021.userXSYARYOU_NO = TO_STRING(grdList.Item(menmListCol.XSYARYOU_NO, intRow).Value)     '車輌番号

        Else
            '(削除のとき)
            intRow = grdList.SelectedRows(0).Index
            gobjFRM_306021.userXSYARYOU_NO = TO_STRING(grdList.Item(menmListCol.XSYARYOU_NO, intRow).Value)     '車輌番号

        End If


    End Sub
#End Region
#Region "　印刷処理　                           "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub printOut()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_306020_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try

            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))     '発行日時

            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList.Rows.Count - 1
                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

                '*明細項目(表示)    
                objDataRow.Data00 = grdList.Item(menmListCol.XSYARYOU_NO, ii).FormattedValue                '車輌番号
                objDataRow.Data01 = grdList.Item(menmListCol.XTUMI_HOUKOU_DISP, ii).FormattedValue          '積込方向(表示用)
                objDataRow.Data02 = grdList.Item(menmListCol.XTUMI_HOUHOU_DISP, ii).FormattedValue          '積込方法(表示用)
                objDataRow.Data03 = grdList.Item(menmListCol.XNOT_USER_DISP, ii).FormattedValue             '未使用区分(表示用)
                objDataRow.Data04 = grdList.Item(menmListCol.XCARD_NO, ii).FormattedValue                   'ｶｰﾄﾞNo.
                objDataRow.Data05 = grdList.Item(menmListCol.XSYASYU_KBN, ii).FormattedValue                '車種区分
                objDataRow.Data06 = grdList.Item(menmListCol.XGYOUSYA_CD, ii).FormattedValue                '業者ｺｰﾄﾞ
                objDataRow.Data07 = grdList.Item(menmListCol.XGYOUSYA_NAME, ii).FormattedValue              '業者名
                objDataRow.Data08 = grdList.Item(menmListCol.XLOADER_POSSIBLE_DISP, ii).FormattedValue      'ﾛｰﾀﾞ対応(表示用)
                objDataRow.Data09 = grdList.Item(menmListCol.XSYARYOU_MODE, ii).FormattedValue              'ﾛｰﾀﾞﾓｰﾄﾞ
                objDataRow.Data10 = grdList.Item(menmListCol.XSYASYU_COMMENT, ii).FormattedValue            '車種ｺﾒﾝﾄ

                objDataRow.EndEdit()

                objDataSet.DataTable01.Rows.Add(objDataRow)

            Next

            '***********************************************
            ' ｸﾘｽﾀﾙﾚﾎﾟｰﾄにﾃﾞｰﾀｾｯﾄをｾｯﾄ
            '***********************************************
            objCR.SetDataSource(objDataSet)

            '***********************************************
            ' 印字
            '***********************************************
            Call gobjComFuncFRM.CRPrint(objCR)

        Catch ex As Exception
            Throw ex

        Finally
            'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
            objCR.Dispose()
            objCR = Nothing
            'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
            objDataSet.Dispose()
            objDataSet = Nothing

            Call gobjComFuncFRM.WaitFormClose()                    ' Waitﾌｫｰﾑ削除

        End Try

    End Sub
#End Region

End Class
