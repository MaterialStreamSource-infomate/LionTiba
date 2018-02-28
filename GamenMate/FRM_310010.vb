'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】生産入庫登録画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_310010
#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        RefreshBtn_Click                '再表示
        SeisanNyukoBtn_Click            '開始終了設定
        HasuuBtn_Click                  '端数生産入庫設定
    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FTRK_BUF_NO                     '生産入庫設定.       ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        FTRK_BUF_NO_Disp                '生産入庫設定.       ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.(表示)
        XHINMEI_CD                      '生産入庫設定.       品名ｺｰﾄﾞ
        HINMEI_CD                       '生産入庫設定.       品名記号
        HINMEI                          '生産入庫設定.       品名
        PROD_LINE                       '生産入庫設定.       生産ﾗｲﾝNo.
        PROD_LINE_Disp                  '生産入庫設定.       生産ﾗｲﾝNo.(表示)
        START_DT                        '生産入庫設定.       開始時間

        RESULT_NUM                      '生産入庫設定.       入庫数
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
        RESULT_NUM_CASE                 '生産入庫設定.       入庫梱数
        'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
        '↑↑↑↑↑↑************************************************************************************************************

        DSPEQ_ID                        '生産入庫設定.       設備ID
        PROGRESS                        '生産入庫設定.       進捗状態
        GRID_DISPLAYINDEX               '生産入庫設定.       表示順序

        FARRIVE_DT                      '生産入庫設定.       在庫発生日時
        XMAKER_CD                       '生産入庫設定.       ﾒｰｶｰｺｰﾄﾞ
        FIN_KUBUN                       '生産入庫設定.       入庫区分
        FIN_KUBUN_Disp                  '生産入庫設定.       入庫区分(表示)
        FHORYU_KUBUN                    '生産入庫設定.       保留区分
        FHORYU_KUBUN_Disp               '生産入庫設定.       保留区分(表示)
        XKENSA_KUBUN                    '生産入庫設定.       検査区分
        XKENSA_KUBUN_Disp               '生産入庫設定.       検査区分(表示)
        XKENPIN_KUBUN                   '生産入庫設定.       検品区分
        XKENPIN_KUBUN_Disp              '生産入庫設定.       検品区分(表示)


        MAXCOL

    End Enum

#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                               "
    '*******************************************************************************************************************
    '【機能】ﾌｫｰﾑｱｸﾃｨﾌﾞ時ｲﾍﾞﾝﾄ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_310010_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
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
        'grdList.MultiSelect = True                                              '複数行選択
        Call grdListSetup()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)

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
#Region "  F1(再表示)  ﾎﾞﾀﾝ押下処理　               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(再表示) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.RefreshBtn_Click) = False Then
            Exit Sub
        End If

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "  F2(開始終了設定)  ﾎﾞﾀﾝ押下処理           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F2(開始終了) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F2Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SeisanNyukoBtn_Click) = False Then
            Exit Sub
        End If

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_310011) = False Then
            gobjFRM_310011.Close()
            gobjFRM_310011.Dispose()
            gobjFRM_310011 = Nothing
        End If

        gobjFRM_310011 = New FRM_310011

        Call SetProperty()      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_310011.ShowDialog()            '展開

        If intRet = Windows.Forms.DialogResult.Cancel Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "  F3(端数生産入庫設定)  ﾎﾞﾀﾝ押下処理　     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F3(端数生産入庫設定) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F3Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.HasuuBtn_Click) = False Then
            Exit Sub
        End If

        ' '' ''******************************************
        ' '' '' 画面遷移
        ' '' ''******************************************
        ' ''Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_310020, Me)

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_310020) = False Then
            gobjFRM_310020.Close()
            gobjFRM_310020.Dispose()
            gobjFRM_310020 = Nothing
        End If

        gobjFRM_310020 = New FRM_310020

        Call SetProperty2()      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_310020.ShowDialog()            '展開

        If intRet = Windows.Forms.DialogResult.Cancel Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If

    End Sub
#End Region
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/04 CW6追加対応 ↓↓↓↓↓↓
#Region "  F4(生産ﾗｲﾝﾓﾆﾀ)  ﾎﾞﾀﾝ押下処理　     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(生産ﾗｲﾝﾓﾆﾀ) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        ''******************************************
        '' 画面遷移
        ''******************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_302010, Me)
        Me.Close()

    End Sub
#End Region
    'JobMate:S.Ouchi 2015/07/04 CW6追加対応 ↑↑↑↑↑↑
    '↑↑↑↑↑↑************************************************************************************************************

#Region "　入力ﾁｪｯｸ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <param name="udtCheck_Case">[IN ]入力ﾁｪｯｸ判別</param>
    ''' <returns>True/False</returns>
    ''' <remarks>戻値 = True :入力ﾁｪｯｸ成功/False:入力ﾁｪｯｸ失敗</remarks>
    ''' *******************************************************************************************************************
    Public Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        Select Case udtCheck_Case
            Case menmCheckCase.RefreshBtn_Click
                '(表示更新ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False


            Case menmCheckCase.SeisanNyukoBtn_Click
                '(開始終了設定ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ選択ﾁｪｯｸ
                '==========================
                If grdList.SelectedRows.Count <= 0 Then
                    '(ﾘｽﾄが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If


                blnCheckErr = False

            Case menmCheckCase.HasuuBtn_Click
                '(端数生産入庫設定ﾎﾞﾀﾝｸﾘｯｸ時)

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
#Region "  開始/終了設定画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 開始/終了設定画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty()
        Dim intXPROGRESS As Integer = -1
        intXPROGRESS = TO_INTEGER(grdList.Item(menmListCol.PROGRESS, grdList.SelectedRows(0).Index).Value)

        '共通ﾃﾞｰﾀ
        gobjFRM_310011.userFTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value)                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        ' ''gobjFRM_310011.userFTRK_BUF_NO_Disp = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO_Disp, grdList.SelectedRows(0).Index).Value)        '入庫ST
        ' ''gobjFRM_310011.userFEQ_ID = TO_STRING(grdList.Item(menmListCol.DSPEQ_ID, grdList.SelectedRows(0).Index).Value)                          '設備ID
        ' ''gobjFRM_310011.userDSPGRID_DISPLAYINDEX = TO_STRING(grdList.Item(menmListCol.GRID_DISPLAYINDEX, grdList.SelectedRows(0).Index).Value)   '表示順序

        ' ''gobjFRM_310011.userXPROGRESS = intXPROGRESS         '進捗状況

        ' ''If intXPROGRESS = XPROGRESS_NON Then
        ' ''    '(未作業の場合)

        ' ''ElseIf intXPROGRESS = XPROGRESS_START Then
        ' ''    '(開始状態の場合)
        ' ''    gobjFRM_310011.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.HINMEI_CD, grdList.SelectedRows(0).Index).Value)                     '品名ｺｰﾄﾞ
        ' ''    gobjFRM_310011.userFHINMEI = TO_STRING(grdList.Item(menmListCol.HINMEI, grdList.SelectedRows(0).Index).Value)                           '品名
        ' ''    gobjFRM_310011.userXPROD_LINE = TO_STRING(grdList.Item(menmListCol.PROD_LINE, grdList.SelectedRows(0).Index).Value)                     '生産ﾗｲﾝNo.
        ' ''    gobjFRM_310011.userXPROD_LINE_Disp = TO_STRING(grdList.Item(menmListCol.PROD_LINE_Disp, grdList.SelectedRows(0).Index).Value)           '生産ﾗｲﾝNo.(表示用)

        ' ''    gobjFRM_310011.userFARRIVE_DT = TO_STRING(grdList.Item(menmListCol.FARRIVE_DT, grdList.SelectedRows(0).Index).Value)                    '在庫発生日時
        ' ''    gobjFRM_310011.userXMAKER_CD = TO_STRING(grdList.Item(menmListCol.XMAKER_CD, grdList.SelectedRows(0).Index).Value)                      'ﾒｰｶｰｺｰﾄﾞ
        ' ''    gobjFRM_310011.userXKENSA_KUBUN = TO_STRING(grdList.Item(menmListCol.XKENSA_KUBUN, grdList.SelectedRows(0).Index).Value)                '検査区分
        ' ''    gobjFRM_310011.userXKENSA_KUBUN_Disp = TO_STRING(grdList.Item(menmListCol.XKENSA_KUBUN_Disp, grdList.SelectedRows(0).Index).Value)      '検査区分(表示用)
        ' ''    gobjFRM_310011.userFHORYU_KUBUN = TO_STRING(grdList.Item(menmListCol.FHORYU_KUBUN, grdList.SelectedRows(0).Index).Value)                '保留区分
        ' ''    gobjFRM_310011.userFHORYU_KUBUN_Disp = TO_STRING(grdList.Item(menmListCol.FHORYU_KUBUN_Disp, grdList.SelectedRows(0).Index).Value)      '保留区分(表示用)
        ' ''    gobjFRM_310011.userFIN_KUBUN = TO_STRING(grdList.Item(menmListCol.FIN_KUBUN, grdList.SelectedRows(0).Index).Value)                      '入庫区分
        ' ''    gobjFRM_310011.userFIN_KUBUN_Disp = TO_STRING(grdList.Item(menmListCol.FIN_KUBUN_Disp, grdList.SelectedRows(0).Index).Value)            '入庫区分(表示用)
        ' ''    gobjFRM_310011.userXKENPIN_KUBUN = TO_STRING(grdList.Item(menmListCol.XKENPIN_KUBUN, grdList.SelectedRows(0).Index).Value)              '検品区分
        ' ''    gobjFRM_310011.userXKENPIN_KUBUN_Disp = TO_STRING(grdList.Item(menmListCol.XKENPIN_KUBUN_Disp, grdList.SelectedRows(0).Index).Value)    '検品区分(表示用)


        ' ''ElseIf intXPROGRESS = XPROGRESS_END Then
        ' ''    '(終了状態の場合)

        ' ''End If

    End Sub

#End Region
#Region "  端数生産入庫設定画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 端数生産入庫設定画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty2()
        gobjFRM_310020.userMenuFlg = False
        gobjFRM_310020.userFTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value)                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
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

        Dim strSQL As String = ""                       'SQL文

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "       XSTS_PRODUCT_IN.FTRK_BUF_NO"                  '生産入庫設定状態      .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        strSQL &= vbCrLf & "     , TMST_TRK.FBUF_NAME"                           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ       .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(表示用)
        strSQL &= vbCrLf & "     , TMST_ITEM.XHINMEI_CD "                        '品目ﾏｽﾀ               .品目ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FHINMEI_CD "                  '生産入庫設定状態      .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                           '品目ﾏｽﾀ               .品名
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XPROD_LINE"                   '生産入庫設定状態      .生産ﾗｲﾝNo.
        strSQL &= vbCrLf & "     , XMST_PROD_LINE.XPROD_LINE_NAME"               '生産ﾗｲﾝﾏｽﾀ            .生産ﾗｲﾝ名称
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XSTART_DT"                    '生産入庫設定状態      .開始日時

        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XRESULT_NUM"                   '生産入庫設定状態      .入庫数
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XRESULT_NUM_CASE"            '生産入庫設定状態      .入庫梱数
        'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
        '↑↑↑↑↑↑************************************************************************************************************

        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FEQ_ID "                      '生産入庫設定状態      .設備ID
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XPROGRESS "                   '生産入庫設定状態      .進捗状態
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FGRID_DISPLAYINDEX "          '生産入庫設定状態      .ｸﾞﾘｯﾄﾞ列表示順序

        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FARRIVE_DT "                  '生産入庫設定状態      .在庫発生日時
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XMAKER_CD "                   '生産入庫設定状態      .ﾒｰｶｰｺｰﾄﾞ
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XKENSA_KUBUN "                '生産入庫設定状態      .検査区分
        strSQL &= vbCrLf & "     , HASH03.FGAMEN_DISP AS XKENSA_KUBUN_DSP "      '生産入庫設定状態      .検査区分(表示用)
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FHORYU_KUBUN "                '生産入庫設定状態      .保留区分
        strSQL &= vbCrLf & "     , HASH02.FGAMEN_DISP AS FHORYU_KUBUN_DSP "      '生産入庫設定状態      .保留区分(表示用)
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FIN_KUBUN "                   '生産入庫設定状態      .入庫区分
        strSQL &= vbCrLf & "     , HASH01.FGAMEN_DISP AS FIN_KUBUN_DSP "         '生産入庫設定状態      .入庫区分(表示用)
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XKENPIN_KUBUN "               '生産入庫設定状態      .検品区分
        strSQL &= vbCrLf & "     , HASH04.FGAMEN_DISP AS XKENPIN_KUBUN_DSP "     '生産入庫設定状態      .検品区分(表示用)



        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_PRODUCT_IN "               '【生産入庫設定状態】
        strSQL &= vbCrLf & "  , TMST_TRK "                      '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ】
        strSQL &= vbCrLf & "  , TMST_ITEM "                     '【品目ﾏｽﾀ】
        strSQL &= vbCrLf & "  , XMST_PROD_LINE "                '【生産ﾗｲﾝﾏｽﾀ】
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XSTS_PRODUCT_IN", "FIN_KUBUN")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "XSTS_PRODUCT_IN", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "XSTS_PRODUCT_IN", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "XSTS_PRODUCT_IN", "XKENPIN_KUBUN")


        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件
        strSQL &= vbCrLf & "    AND XSTS_PRODUCT_IN.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "    AND XSTS_PRODUCT_IN.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "    AND XSTS_PRODUCT_IN.XPROD_LINE = XMST_PROD_LINE.XPROD_LINE(+) "
        'strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID NOT IN( "                             '在庫棚(未引当)
        'strSQL &= vbCrLf & "                (SELECT FPALLET_ID FROM XSTS_HIKIATE_K1) "
        'strSQL &= vbCrLf & "                                    ) "
        'strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID NOT IN( "                             '在庫棚(未引当)
        'strSQL &= vbCrLf & "                (SELECT FPALLET_ID FROM TSTS_HIKIATE) "
        'strSQL &= vbCrLf & "                                    ) "
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XSTS_PRODUCT_IN", "FIN_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "XSTS_PRODUCT_IN", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "XSTS_PRODUCT_IN", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "XSTS_PRODUCT_IN", "XKENPIN_KUBUN")


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

        'grdList.Columns(menmListCol.DENBUN).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill   '列幅自動調整


    End Sub
#End Region
End Class
