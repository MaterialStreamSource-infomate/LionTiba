'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】担当者ﾏｽﾀﾒﾝﾃﾅﾝｽ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_206020

#Region "　共通変数　                               "

    '検索条件用構造体
    ''Private mudtSEARCH_ITEM As New SEARCH_ITEM

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FUSER_ID                'ﾕｰｻﾞｰﾏｽﾀ       .ﾕｰｻﾞｰID
        ''FLOGIN_ID               'ﾕｰｻﾞｰﾏｽﾀ       .ﾛｸﾞｲﾝID
        FUSER_NAME              'ﾕｰｻﾞｰﾏｽﾀ       .ﾕｰｻﾞｰ名
        FPASS_WORD              'ﾕｰｻﾞｰﾏｽﾀ       .ﾊﾟｽﾜｰﾄﾞ
        ''FPASS_ORVER             'ﾊﾟｽﾜｰﾄﾞ有効期限(ﾊﾟｽﾜｰﾄﾞ更新日時+TPRG_SYS_HEN.ﾊﾟｽﾜｰﾄﾞ有効期限超過日数)
        ''XUserIdValidFrom        'ﾕｰｻﾞﾏｽﾀ        .ｱｶｳﾝﾄ有効期間_FROM
        ''XUserIdValidTo          'ﾕｰｻﾞﾏｽﾀ        .ｱｶｳﾝﾄ有効期限_TO
        FENTRY_DT               'ﾕｰｻﾞｰﾏｽﾀ       .登録日時
        FUPDATE_DT              'ﾕｰｻﾞｰﾏｽﾀ       .更新日時
        ''FENTRY_USER_ID          'ﾕｰｻﾞｰﾏｽﾀ       .登録ﾕｰｻﾞｰID
        FUSER_ATEST             'ﾕｰｻﾞｰﾏｽﾀ       .ﾕｰｻﾞｰ認証状況
        FUSER_ATEST_Dsp         'ﾕｰｻﾞｰﾏｽﾀ       .ﾕｰｻﾞｰ認証状況(表示用)
        FWARNING_COUNT          'ﾕｰｻﾞｰﾏｽﾀ       .不正ｱｸｾｽ回数

        MAXCOL

    End Enum

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        PASS_RESET_Click                'ﾊﾟｽﾜｰﾄﾞﾘｾｯﾄﾎﾞﾀﾝｸﾘｯｸ時
        SearchBtn_Click                 '検索ﾎﾞﾀﾝｸﾘｯｸ時
        AddBtn_Click                    '追加ﾎﾞﾀﾝｸﾘｯｸ時
        UpdateBtn_Click                 '変更ﾎﾞﾀﾝｸﾘｯｸ時
        DeleteBtn_Click                 '削除ﾎﾞﾀﾝｸﾘｯｸ時

    End Enum

#End Region
#Region "　ｲﾍﾞﾝﾄ                                    "

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

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)


    End Sub
#End Region
#Region "  F1(ﾊﾟｽﾜｰﾄﾞﾘｾｯﾄ)  ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(ﾊﾟｽﾜｰﾄﾞﾘｾｯﾄ) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.PASS_RESET_Click) = False Then

            Exit Sub

        End If

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udeRet As PopupFormType
        udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206020_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> PopupFormType.Ok Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If SendSocket01() = False Then Exit Sub


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
#Region "  F4(追加)　ﾎﾞﾀﾝ押下処理　                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(追加) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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
        If IsNull(gobjFRM_206021) = False Then
            gobjFRM_206021.Close()
            gobjFRM_206021.Dispose()
            gobjFRM_206021 = Nothing
        End If
        gobjFRM_206021 = New FRM_206021
        Call SetProperty(BUTTONMODE_ADD)                                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_206021.userButtonMode = BUTTONMODE_ADD     'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_206021.ShowDialog()            '展開
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
#Region "  F5(変更)　ﾎﾞﾀﾝ押下処理　                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5(変更) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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
        If IsNull(gobjFRM_206021) = False Then
            gobjFRM_206021.Close()
            gobjFRM_206021.Dispose()
            gobjFRM_206021 = Nothing
        End If
        gobjFRM_206021 = New FRM_206021
        Call SetProperty(BUTTONMODE_UPDATE)                                 'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_206021.userButtonMode = BUTTONMODE_UPDATE     'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_206021.ShowDialog()            '展開
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
#Region "  F6(削除)　ﾎﾞﾀﾝ押下処理　                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F6(削除) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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
        If IsNull(gobjFRM_206021) = False Then
            gobjFRM_206021.Close()
            gobjFRM_206021.Dispose()
            gobjFRM_206021 = Nothing
        End If
        gobjFRM_206021 = New FRM_206021
        Call SetProperty(BUTTONMODE_DELETE)                                 'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_206021.userButtonMode = BUTTONMODE_DELETE     'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_206021.ShowDialog()            '展開
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
#Region "  F8(戻る)  ﾎﾞﾀﾝ押下処理　                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8(戻る) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F8Process()

        '******************************************
        ' 画面遷移
        '******************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_206000, Me)

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
            Case menmCheckCase.PASS_RESET_Click
                '(ﾊﾟｽﾜｰﾄﾞﾘｾｯﾄﾎﾞﾀﾝｸﾘｯｸ時)

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

            Case menmCheckCase.SearchBtn_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)


                blnCheckErr = False

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

        '********************************************************************
        ' ﾊﾟｽﾜｰﾄﾞ超過日数取得
        '********************************************************************
        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(gobjOwner, gobjDb, Nothing)
        'Dim intSPASS_ORVER As Integer = TO_INTEGER(objTPRG_SYS_HEN.SPASS_ORVER)

        Dim strSQL As String                    'SQL文

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TMST_USER.FUSER_ID "             'ﾕｰｻﾞｰﾏｽﾀ       .ﾕｰｻﾞｰID
        strSQL &= vbCrLf & "  , TMST_USER.FUSER_NAME "           'ﾕｰｻﾞｰﾏｽﾀ       .ﾕｰｻﾞｰ名

        strSQL &= vbCrLf & "  , CASE "
        strSQL &= vbCrLf & "    WHEN TMST_USER.FPASS_WORD IS NULL THEN '' "          'ﾕｰｻﾞｰﾏｽﾀ       .ﾊﾟｽﾜｰﾄﾞ
        strSQL &= vbCrLf & "    ELSE '******' "
        strSQL &= vbCrLf & "    END "

        'strSQL &= vbCrLf & "  , ( CASE WHEN NOT(TMST_USER.FPASS_WORDUP_DT IS NULL) THEN "  'ﾊﾟｽﾜｰﾄﾞ有効期限(ﾊﾟｽﾜｰﾄﾞ更新日時+TPRG_SYS_HEN.ﾊﾟｽﾜｰﾄﾞ有効期限超過日数)
        ''strSQL &= vbCrLf & "                TMST_USER.FPASS_WORDUP_DT + " & intSPASS_ORVER & " "
        'strSQL &= vbCrLf & "           ELSE NULL END "
        'strSQL &= vbCrLf & "    ) AS FPASS_ORVER "

        strSQL &= vbCrLf & "  , TMST_USER.FENTRY_DT "           'ﾕｰｻﾞｰﾏｽﾀ       .登録日時
        strSQL &= vbCrLf & "  , TMST_USER.FUPDATE_DT "          'ﾕｰｻﾞｰﾏｽﾀ       .更新日時
        strSQL &= vbCrLf & "  , TMST_USER.FUSER_ATEST "         'ﾕｰｻﾞｰﾏｽﾀ       .ﾕｰｻﾞｰ認証状況
        strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP "            'ﾕｰｻﾞｰﾏｽﾀ       .ﾕｰｻﾞｰ認証状況(表示用)
        strSQL &= vbCrLf & "  , TMST_USER.FWARNING_COUNT "      'ﾕｰｻﾞｰﾏｽﾀ       .不正ｱｸｾｽ回数
        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TMST_USER "                     'ﾕｰｻﾞｰﾏｽﾀ
        strSQL &= vbCrLf & "   ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TMST_USER", "FUSER_ATEST")
        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TMST_USER", "FUSER_ATEST")
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
#Region "  ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <param name="intBtnMode"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty(ByVal intBtnMode As Integer)

        If intBtnMode = BUTTONMODE_ADD Then
            '(追加のとき)
            gobjFRM_206021.userFUSER_ID = ""                 'ﾕｰｻﾞｰID
            gobjFRM_206021.userFLOGIN_ID = ""                'ﾛｸﾞｲﾝID
            gobjFRM_206021.userFUSER_NAME = ""               'ﾕｰｻﾞｰ名

        ElseIf intBtnMode = BUTTONMODE_UPDATE Then
            '(変更のとき)
            gobjFRM_206021.userFUSER_ID = TO_STRING(grdList.Item(menmListCol.FUSER_ID, grdList.SelectedRows(0).Index).Value)                  'ﾕｰｻﾞｰID
            gobjFRM_206021.userFUSER_NAME = TO_STRING(grdList.Item(menmListCol.FUSER_NAME, grdList.SelectedRows(0).Index).Value)              'ﾕｰｻﾞｰ名

        Else
            '(削除のとき)
            gobjFRM_206021.userFUSER_ID = TO_STRING(grdList.Item(menmListCol.FUSER_ID, grdList.SelectedRows(0).Index).Value)                  'ﾕｰｻﾞｰID
            gobjFRM_206021.userFUSER_NAME = TO_STRING(grdList.Item(menmListCol.FUSER_NAME, grdList.SelectedRows(0).Index).Value)              'ﾕｰｻﾞｰ名

        End If

    End Sub

#End Region
#Region "  ｿｹｯﾄ送信                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SendSocket01() As Boolean

        Dim blnRet As Boolean = False

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strMAINTE_USER_ID As String = ""         'ﾒﾝﾃﾅﾝｽﾕｰｻﾞｰID
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200702              'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        strMAINTE_USER_ID = TO_STRING(grdList.Item(menmListCol.FUSER_ID, grdList.SelectedRows(0).Index).Value)      'ﾒﾝﾃﾅﾝｽﾕｰｻﾞｰID
        objTelegram.SETIN_DATA("DSPMAINTE_USER_ID", strMAINTE_USER_ID)                'ﾒﾝﾃﾅﾝｽﾕｰｻﾞｰID


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = FRM_MSG_FRM206020_02
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            End If
        End If

        Return blnRet

    End Function
#End Region

End Class
