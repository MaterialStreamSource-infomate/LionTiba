'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｼｽﾃﾑ定数ﾒﾝﾃﾅﾝｽ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_207060

#Region "  共通変数　                           "

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        ChangeBtn_Click         '変更ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

    Enum menmListCol
        FHENSU_ID               'ｼｽﾃﾑ変数.         変数ID
        FHENSU_NAME             'ｼｽﾃﾑ変数.         変数名称
        FHENSU_KIND_Dsp         'ｼｽﾃﾑ変数.         ﾃﾞｰﾀ種別
        FHENSU_INT              'ｼｽﾃﾑ変数.         整数ﾃﾞｰﾀ
        FHENSU_REAL             'ｼｽﾃﾑ変数.         実数ﾃﾞｰﾀ
        FHENSU_CHAR             'ｼｽﾃﾑ変数.         文字ﾃﾞｰﾀ
        FHENSU_DATE             'ｼｽﾃﾑ変数.         日時ﾃﾞｰﾀ

        FHENSU_KIND             'ｼｽﾃﾑ変数.         ﾃﾞｰﾀ種別

        MAXCOL

    End Enum

#End Region
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
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                             "
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
        grdList.ImeMode = Windows.Forms.ImeMode.Disable        'ｸﾞﾘｯﾄﾞIMEMODE
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()


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
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F4(変更)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(変更) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()


        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.ChangeBtn_Click) = False Then

            Exit Sub

        End If


        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_207061) = False Then
            gobjFRM_207061.Close()
            gobjFRM_207061.Dispose()
            gobjFRM_207061 = Nothing
        End If

        gobjFRM_207061 = New FRM_207061
        gobjFRM_207061.userOWNER = Me               '定数ID
        gobjFRM_207061.userSTRHENSU_ID = TO_STRING(grdList.Item(menmListCol.FHENSU_ID, grdList.SelectedRows(0).Index).Value)               '定数ID
        gobjFRM_207061.userSTRHENSU_NAME = TO_STRING(grdList.Item(menmListCol.FHENSU_NAME, grdList.SelectedRows(0).Index).Value)           '定数項目名称
        gobjFRM_207061.userINTHENSU_KIND = TO_STRING(grdList.Item(menmListCol.FHENSU_KIND, grdList.SelectedRows(0).Index).Value)           'ﾃﾞｰﾀ種別
        gobjFRM_207061.userINTHENSU_INT = TO_STRING(grdList.Item(menmListCol.FHENSU_INT, grdList.SelectedRows(0).Index).Value)             '定数整数ﾃﾞｰﾀ
        gobjFRM_207061.userINTHENSU_REAL = TO_STRING(grdList.Item(menmListCol.FHENSU_REAL, grdList.SelectedRows(0).Index).Value)           '定数実数ﾃﾞｰﾀ
        gobjFRM_207061.userSTRHENSU_CHAR = TO_STRING(grdList.Item(menmListCol.FHENSU_CHAR, grdList.SelectedRows(0).Index).Value)           '定数文字ﾃﾞｰﾀ
        gobjFRM_207061.userDTMHENSU_DATE = TO_DATE_NULLABLE(grdList.Item(menmListCol.FHENSU_DATE, grdList.SelectedRows(0).Index).Value)    '定数日時ﾃﾞｰﾀ
        gobjFRM_207061.ShowDialog()


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置     記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶


        '*******************************************
        '表示前のﾘｽﾄ選択記憶
        '*******************************************
        If grdList.SelectedCells.Count = 0 Then
            intSelectRow = -1               'ﾘｽﾄの行
            intSelectCol = -1               'ﾘｽﾄの列
        Else
            intSelectRow = grdList.SelectedCells(0).RowIndex             'ﾘｽﾄの行
            intSelectCol = grdList.SelectedCells(0).ColumnIndex          'ﾘｽﾄの列
        End If

        objPoint.X = grdList.HorizontalScrollingOffset           'ｽｸﾛｰﾙﾊﾞｰ位置　横
        objPoint.Y = grdList.FirstDisplayedScrollingRowIndex     'ｽｸﾛｰﾙﾊﾞｰ位置　縦


        grdList.blnDBUpdate = False

        Call grdListDisplaySub(grdList)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()                                                 'ｸﾞﾘｯﾄﾞ表示設定
        grdList.HorizontalScrollingOffset = objPoint.X               'ｽｸﾛｰﾙﾊﾞｰ位置　横
        If 0 <= objPoint.Y Then
            grdList.FirstDisplayedScrollingRowIndex = objPoint.Y     'ｽｸﾛｰﾙﾊﾞｰ位置　縦
        End If
        Call gobjComFuncFRM.GridSelect(grdList, intSelectRow, intSelectCol, objPoint)      'ｸﾞﾘｯﾄﾞ選択処理


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
            Case menmCheckCase.ChangeBtn_Click


                '********************************************************************
                '入力ﾁｪｯｸ
                '********************************************************************
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
#Region "  ｸﾞﾘｯﾄﾞ表示　                         "
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
        strSQL &= vbCrLf & "    FHENSU_ID "             'ｼｽﾃﾑ変数.  定数ID
        strSQL &= vbCrLf & "  , FHENSU_NAME "           'ｼｽﾃﾑ変数.  定数項目名称
        strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP AS FHENSU_KIND_Dsp "           'ｼｽﾃﾑ変数.  ﾃﾞｰﾀ種別
        strSQL &= vbCrLf & "  , FHENSU_INT "            'ｼｽﾃﾑ変数.  定数整数ﾃﾞｰﾀ
        strSQL &= vbCrLf & "  , FHENSU_REAL "           'ｼｽﾃﾑ変数.  定数実数ﾃﾞｰﾀ
        strSQL &= vbCrLf & "  , FHENSU_CHAR "           'ｼｽﾃﾑ変数.  定数文字ﾃﾞｰﾀ
        strSQL &= vbCrLf & "  , FHENSU_DATE "           'ｼｽﾃﾑ変数.  定数日時ﾃﾞｰﾀ
        strSQL &= vbCrLf & "  , FHENSU_KIND "           'ｼｽﾃﾑ変数.  ﾃﾞｰﾀ種別
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TPRG_SYS_HEN "          '【ｼｽﾃﾑ変数】
        strSQL &= vbCrLf & "     ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TPRG_SYS_HEN", "FHENSU_KIND")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "    FHENSU_FLAG = " & FHENSU_FLAG_SON
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TPRG_SYS_HEN", "FHENSU_KIND")

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf


        '*******************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '*******************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, strSQL, True)


        '*******************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '*******************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ表示設定　                     "
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

End Class
