﻿'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_306090

#Region "　共通変数　                           "

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol
        XDPL_PL_NO                  'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ.	    ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        XDPL_PL_NAME                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ.      ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
        FHINMEI_CD                  'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ.      品目ｺｰﾄﾞ
        FHINMEI                     '品名ﾏｽﾀ.               品名
        XDPL_PL_PTN                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ.      ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
        XDPL_PL_PTN_COMMENT         'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ.      ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝｺﾒﾝﾄ

        MAXCOL

    End Enum

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        AddBtn_Click                    '追加ﾎﾞﾀﾝｸﾘｯｸ時
        UpdateBtn_Click                 '変更ﾎﾞﾀﾝｸﾘｯｸ時
        DeleteBtn_Click                 '削除ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                           "
    '検索条件
    Private Structure SEARCH_ITEM
        Dim XDPL_PL_NO As String        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
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
        If IsNull(gobjFRM_306091) = False Then
            gobjFRM_306091.Close()
            gobjFRM_306091.Dispose()
            gobjFRM_306091 = Nothing
        End If
        gobjFRM_306091 = New FRM_306091
        Call SetProperty(BUTTONMODE_ADD)                   'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_306091.userButtonMode = BUTTONMODE_ADD     'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_306091.ShowDialog()            '展開
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
        If IsNull(gobjFRM_306091) = False Then
            gobjFRM_306091.Close()
            gobjFRM_306091.Dispose()
            gobjFRM_306091 = Nothing
        End If
        gobjFRM_306091 = New FRM_306091
        Call SetProperty(BUTTONMODE_UPDATE)                                 'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_306091.userButtonMode = BUTTONMODE_UPDATE     'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_306091.ShowDialog()            '展開
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
        If IsNull(gobjFRM_306091) = False Then
            gobjFRM_306091.Close()
            gobjFRM_306091.Dispose()
            gobjFRM_306091 = Nothing
        End If
        gobjFRM_306091 = New FRM_306091
        Call SetProperty(BUTTONMODE_DELETE)                                 'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_306091.userButtonMode = BUTTONMODE_DELETE     'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_306091.ShowDialog()            '展開
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
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                           "
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ

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
        ' ''===============================================
        ' '' 生産ﾗｲﾝ№
        ' ''===============================================
        ''mudtSEARCH_ITEM.XPROD_LINE = TO_STRING(cboXPROD_LINE.Text)

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
        strSQL &= vbCrLf & "     XMST_DPL_PL_PTN.XDPL_PL_NO "                       'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ. ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        strSQL &= vbCrLf & "   , XMST_DPL_PL.XDPL_PL_NAME "                         'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ.      ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
        strSQL &= vbCrLf & "   , XMST_DPL_PL_PTN.FHINMEI_CD "                       'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ. 品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , TMST_ITEM.FHINMEI "                                '品目ﾏｽﾀ.               品名
        strSQL &= vbCrLf & "   , XMST_DPL_PL_PTN.XDPL_PL_PTN "                      'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ.      ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
        strSQL &= vbCrLf & "   , XMST_DPL_PL_PTN.XDPL_PL_PTN_COMMENT "              'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ.      ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝｺﾒﾝﾄ

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     XMST_DPL_PL_PTN "                                  'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ
        strSQL &= vbCrLf & "    ,TMST_ITEM "                                        '品目ﾏｽﾀ
        strSQL &= vbCrLf & "    ,XMST_DPL_PL "                                      'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ


        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 1 = 1 "          '必ず通る条件
        strSQL &= vbCrLf & "   AND XMST_DPL_PL_PTN.FHINMEI_CD  = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "   AND XMST_DPL_PL_PTN.XDPL_PL_NO  = XMST_DPL_PL.XDPL_PL_NO(+) "


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
            gobjFRM_306091.userXDPL_PL_NO = Nothing             'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
            gobjFRM_306091.userFHINMEI_CD = Nothing             '品名ｺｰﾄﾞ
            gobjFRM_306091.userXDPL_PL_PTN = Nothing            'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
            gobjFRM_306091.userXDPL_PL_PTN_COMMENT = Nothing    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝｺﾒﾝﾄ

        ElseIf intBtnMode = BUTTONMODE_UPDATE Then
            '(変更のとき)
            intRow = grdList.SelectedRows(0).Index
            gobjFRM_306091.userXDPL_PL_NO = TO_STRING(grdList.Item(menmListCol.XDPL_PL_NO, intRow).Value)                   'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
            gobjFRM_306091.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, intRow).Value)                   '品名ｺｰﾄﾞ
            gobjFRM_306091.userXDPL_PL_PTN = TO_STRING(grdList.Item(menmListCol.XDPL_PL_PTN, intRow).Value)                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
            gobjFRM_306091.userXDPL_PL_PTN_COMMENT = TO_STRING(grdList.Item(menmListCol.XDPL_PL_PTN_COMMENT, intRow).Value) 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝｺﾒﾝﾄ

        Else
            '(削除のとき)
            intRow = grdList.SelectedRows(0).Index
            gobjFRM_306091.userXDPL_PL_NO = TO_STRING(grdList.Item(menmListCol.XDPL_PL_NO, intRow).Value)                   'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
            gobjFRM_306091.userXDPL_PL_NO = TO_STRING(grdList.Item(menmListCol.XDPL_PL_NO, intRow).Value)                   'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
            gobjFRM_306091.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, intRow).Value)                   '品名ｺｰﾄﾞ
            gobjFRM_306091.userXDPL_PL_PTN = TO_STRING(grdList.Item(menmListCol.XDPL_PL_PTN, intRow).Value)                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
            gobjFRM_306091.userXDPL_PL_PTN_COMMENT = TO_STRING(grdList.Item(menmListCol.XDPL_PL_PTN_COMMENT, intRow).Value) 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝｺﾒﾝﾄ

        End If


    End Sub
#End Region

End Class
