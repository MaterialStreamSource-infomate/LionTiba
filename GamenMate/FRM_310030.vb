'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】包材出庫登録画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_310030
#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        RefreshBtn_Click                    '再表示
        OUTSetBtn_Click                     '出庫登録
    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FTRK_BUF_NO                         '包材出庫登録.       ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        FTRK_BUF_NO_Disp                    '包材出庫登録.       ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.(表示)
        XHINMEI_CD                          '包材出庫登録.       品名ｺｰﾄﾞ
        FHINMEI_CD                          '包材出庫登録.       品名記号
        FHINMEI                             '包材出庫登録.       品名
        MAKER_CD                            '包材出庫登録.       ﾒｰｶｰｺｰﾄﾞ
        MAKER                               '包材出庫登録.       ﾒｰｶｰ名
        PLAN_NUM                            '包材出庫登録.       計画PL数
        STOCK_NUM                           '包材出庫登録.       在庫PL数
        RESULT_NUM                          '包材出庫登録.       出庫済PL数
        START_DT                            '包材出庫登録.       開始時間

        DSPEQ_ID                            '包材出庫登録.       設備ID
        PROD_LINE                           '包材出庫登録.       生産ﾗｲﾝNo.
        PROGRESS                            '包材出庫登録.       進捗状態
        GRID_DISPLAYINDEX                   '包材出庫登録.       表示順序

        DATA15
        DATA16
        DATA17
        DATA18
        DATA19
        DATA20

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
#Region "  F2(出庫登録)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F2(出庫登録) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F2Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.OUTSetBtn_Click) = False Then
            Exit Sub
        End If

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_310031) = False Then
            gobjFRM_310031.Close()
            gobjFRM_310031.Dispose()
            gobjFRM_310031 = Nothing
        End If

        gobjFRM_310031 = New FRM_310031

        Call SetProperty()      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_310031.ShowDialog()            '展開

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
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/04 CW6追加対応 ↓↓↓↓↓↓
#Region "  F3(生産ﾗｲﾝﾓﾆﾀ)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F3(生産ﾗｲﾝﾓﾆﾀ) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F3Process()

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


            Case menmCheckCase.OUTSetBtn_Click
                '(出庫登録ﾎﾞﾀﾝｸﾘｯｸ時)

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
#Region "  包材出庫登録画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 包材出庫登録画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty()

        Dim intFPROGRESS As Integer = -1
        intFPROGRESS = TO_INTEGER(grdList.Item(menmListCol.PROGRESS, grdList.SelectedRows(0).Index).Value)

        '共通ﾃﾞｰﾀ
        gobjFRM_310031.userFTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value)                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        ' ''gobjFRM_310031.userFTRK_BUF_NO_Disp = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO_Disp, grdList.SelectedRows(0).Index).Value)        '出庫ST
        ' ''gobjFRM_310031.userFEQ_ID = TO_STRING(grdList.Item(menmListCol.DSPEQ_ID, grdList.SelectedRows(0).Index).Value)                          '設備ID
        ' ''gobjFRM_310031.userDSPGRID_DISPLAYINDEX = TO_STRING(grdList.Item(menmListCol.GRID_DISPLAYINDEX, grdList.SelectedRows(0).Index).Value)   '表示順序
        ' ''gobjFRM_310031.userSTOCK_NUM = TO_STRING(grdList.Item(menmListCol.STOCK_NUM, grdList.SelectedRows(0).Index).Value)                 '在庫PL数
        ' ''gobjFRM_310031.userFPROGRESS = intFPROGRESS         '進捗状況

        ' ''If intFPROGRESS = XPROGRESS_NON Then
        ' ''    '(未作業の場合)

        ' ''ElseIf intFPROGRESS = XPROGRESS_START Then
        ' ''    '(開始状態の場合)
        ' ''    gobjFRM_310031.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, grdList.SelectedRows(0).Index).Value)                '品名記号
        ' ''    gobjFRM_310031.userFHINMEI = TO_STRING(grdList.Item(menmListCol.FHINMEI, grdList.SelectedRows(0).Index).Value)                      '品名
        ' ''    gobjFRM_310031.userMAKER_CD = TO_STRING(grdList.Item(menmListCol.MAKER_CD, grdList.SelectedRows(0).Index).Value)                    'ﾒｰｶｰｺｰﾄﾞ
        ' ''    gobjFRM_310031.userMAKER_NAME = TO_STRING(grdList.Item(menmListCol.MAKER, grdList.SelectedRows(0).Index).Value)                     'ﾒｰｶｰ名
        ' ''    gobjFRM_310031.userPLAN_NUM = TO_STRING(grdList.Item(menmListCol.PLAN_NUM, grdList.SelectedRows(0).Index).Value)                    '計画PL数
        ' ''    gobjFRM_310031.userRESULT_NUM = TO_STRING(grdList.Item(menmListCol.RESULT_NUM, grdList.SelectedRows(0).Index).Value)                '実績PL数
        ' ''    gobjFRM_310031.userXPROD_LINE = TO_STRING(grdList.Item(menmListCol.PROD_LINE, grdList.SelectedRows(0).Index).Value)                 '生産ﾗｲﾝNo.

        ' ''ElseIf intFPROGRESS = XPROGRESS_END Then
        ' ''    '(終了状態の場合)

        ' ''End If

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

        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objRow2 As DataRow                          '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim strDataSetName2 As String
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）
        Dim objDataSet2 As New DataSet

        Dim objDataTable As New GamenCommon.clsGridDataTable20      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        '============================================================
        'SELECT 包材出庫設定状態
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "       XSTS_WRAPPING_MATERIAL.FTRK_BUF_NO"              '包材出庫設定状態      .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.(非表示)
        strSQL &= vbCrLf & "     , TMST_TRK.FBUF_NAME"                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ       .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        strSQL &= vbCrLf & "     , TMST_ITEM.XHINMEI_CD "                           '品目ﾏｽﾀ               .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL.FHINMEI_CD "              '包材出庫設定状態      .品名記号
        strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                              '品目ﾏｽﾀ               .品名
        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL.XMAKER_CD "               '包材出庫設定状態      .ﾒｰｶｰｺｰﾄﾞ
        strSQL &= vbCrLf & "     , XMST_WRAPPING_MAKER.XMAKER_NAME "                '包材ﾒｰｶｰﾏｽﾀ           .ﾒｰｶ名
        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL.XPLAN_NUM "               '包材出庫設定状態      .計画PL数
        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL.XRESULT_NUM "             '包材出庫設定状態      .出庫済PL数
        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL.XSTART_DT "               '包材出庫設定状態      .登録日時

        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL.FEQ_ID "                  '包材出庫設定状態      .設備ID(非表示)
        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL.XPROD_LINE "              '包材出庫設定状態      .生産ﾗｲﾝNo.(非表示)
        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL.XPROGRESS "               '包材出庫設定状態      .進捗状態(非表示)
        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL.FGRID_DISPLAYINDEX "      '包材出庫設定状態      .ｸﾞﾘｯﾄﾞ列表示順序(非表示)


        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_WRAPPING_MATERIAL "        '【包材出庫設定状態】
        strSQL &= vbCrLf & "  , TMST_TRK "                      '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ】
        strSQL &= vbCrLf & "  , TMST_ITEM "                     '【品目ﾏｽﾀ】
        strSQL &= vbCrLf & "  , XMST_WRAPPING_MAKER "           '【包材ﾒｰｶｰﾏｽﾀ】

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件
        strSQL &= vbCrLf & "    AND XSTS_WRAPPING_MATERIAL.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "    AND XSTS_WRAPPING_MATERIAL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "    AND XSTS_WRAPPING_MATERIAL.XMAKER_CD = XMST_WRAPPING_MAKER.XMAKER_CD(+) "

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    XSTS_WRAPPING_MATERIAL.FGRID_DISPLAYINDEX"          '包材出庫設定状態      .ｸﾞﾘｯﾄﾞ列表示順序

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XSTS_WRAPPING_MATERIAL"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                '********************************************************************
                ' ﾃﾞｰﾀ取得
                '********************************************************************
                Dim FTRK_BUF_NO As String = ""                  '包材出庫設定状態      .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
                Dim FBUF_NAME As String = ""                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ       .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
                Dim XHINMEI_CD As String = ""                   '品目ﾏｽﾀ               .品名ｺｰﾄﾞ
                Dim FHINMEI_CD As String = ""                   '包材出庫設定状態      .品名記号
                Dim FHINMEI As String = ""                      '品目ﾏｽﾀ               .品名
                Dim XMAKER_CD As String = ""                    '包材出庫設定状態      .ﾒｰｶｰｺｰﾄﾞ
                Dim XMAKER_NAME As String = ""                  '包材ﾒｰｶｰﾏｽﾀ           .ﾒｰｶ名
                Dim XPLAN_NUM As String = ""                    '包材出庫設定状態      .計画PL数
                Dim XRESULT_NUM As String = ""                  '包材出庫設定状態      .出庫済PL数
                Dim XSTART_DT As String = ""                    '包材出庫設定状態      .登録日時
                Dim FEQ_ID As String = ""                       '包材出庫設定状態      .設備ID(非表示)
                Dim XPROD_LINE As String = ""                   '包材出庫設定状態      .生産ﾗｲﾝNo.(非表示)
                Dim XPROGRESS As String = ""                    '包材出庫設定状態      .進捗状態(非表示)
                Dim FGRID_DISPLAYINDEX As String = ""           '包材出庫設定状態      .ｸﾞﾘｯﾄﾞ列表示順序(非表示)

                FTRK_BUF_NO = TO_STRING(objRow("FTRK_BUF_NO"))
                FBUF_NAME = TO_STRING(objRow("FBUF_NAME"))
                XHINMEI_CD = TO_STRING(objRow("XHINMEI_CD"))
                FHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))
                FHINMEI = TO_STRING(objRow("FHINMEI"))
                XMAKER_CD = TO_STRING(objRow("XMAKER_CD"))
                XMAKER_NAME = TO_STRING(objRow("XMAKER_NAME"))
                XPLAN_NUM = TO_STRING(objRow("XPLAN_NUM"))
                XRESULT_NUM = TO_STRING(objRow("XRESULT_NUM"))
                If TO_STRING(objRow("XSTART_DT")) <> "" Then
                    XSTART_DT = Format(objRow("XSTART_DT"), "yyyy/MM/dd HH:mm:ss")
                End If
                FEQ_ID = TO_STRING(objRow("FEQ_ID"))
                XPROD_LINE = TO_STRING(objRow("XPROD_LINE"))
                XPROGRESS = TO_STRING(objRow("XPROGRESS"))
                FGRID_DISPLAYINDEX = TO_STRING(objRow("FGRID_DISPLAYINDEX"))


                Dim strZaiko_PL As String = ""               '在庫PL数

                If FHINMEI_CD <> "" Then
                    '(包材出庫設定が設定されている場合)

                    '********************************************************************
                    ' 在庫情報より在庫PL数算出
                    ' SQL文作成
                    '********************************************************************
                    '在庫情報から総在庫数取得(ﾒｰｶｰｺｰﾄﾞ含む)
                    strSQL = ""
                    strSQL &= vbCrLf & "  SELECT     "
                    strSQL &= vbCrLf & "      Count(*) ZAIKO_PL  "
                    strSQL &= vbCrLf & "  FROM "
                    strSQL &= vbCrLf & "      TRST_STOCK "                          '在庫情報
                    strSQL &= vbCrLf & "    , TPRG_TRK_BUF "                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
                    strSQL &= vbCrLf & "    , TMST_CRANE "                          'ｸﾚｰﾝﾏｽﾀ
                    strSQL &= vbCrLf & "    , TSTS_EQ_CTRL "                        '設備状況
                    strSQL &= vbCrLf & "  WHERE "
                    strSQL &= vbCrLf & "        1 = 1"
                    strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID "
                    strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRAC_RETU   >= TMST_CRANE.FCRANE_ROW1(+) "         '列1
                    strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRAC_RETU   <= TMST_CRANE.FCRANE_ROW2(+) "         '列2
                    strSQL &= vbCrLf & "    AND TMST_CRANE.FEQ_ID         = TSTS_EQ_CTRL.FEQ_ID(+) "            '設備ID

                    strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_CUT_STS  = " & FEQ_CUT_STS_SOFF                '切離状態 = 通常
                    strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_STS      = " & FEQ_STS_JINOUTMODE_OUT          '設備状態 = 運転中
                    strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRES_KIND    = " & FRES_KIND_SZAIKO                '在庫棚のみ
                    strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FREMOVE_KIND = " & FREMOVE_KIND_SNORMAL            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.禁止有無 が 0:無   のﾚｺｰﾄﾞを抽出
                    strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO  = " & FTRK_BUF_NO_J9000               '自動倉庫
                    strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD     = '" & FHINMEI_CD & "' "              '品名ｺｰﾄﾞ
                    If XMAKER_CD <> "" Then                                                                     'ﾒｰｶｰｺｰﾄﾞ
                        strSQL &= vbCrLf & "  AND TRST_STOCK.XMAKER_CD = '" & XMAKER_CD & "' "
                    End If


                    '-----------------------
                    '抽出
                    '-----------------------
                    objDataSet2.Clear()
                    gobjDb.SQL = strSQL
                    objDataSet2.Clear()
                    strDataSetName2 = "TRST_STOCK_SUM"
                    gobjDb.GetDataSet(strDataSetName2, objDataSet2)

                    If objDataSet2.Tables(strDataSetName2).Rows.Count > 0 Then
                        For Each objRow2 In objDataSet2.Tables(strDataSetName2).Rows
                            strZaiko_PL = TO_STRING(objRow2("ZAIKO_PL")) '在庫総数

                        Next
                    End If

                Else
                    '(包材出庫設定が設定されていない場合)
                    strZaiko_PL = ""
                End If

                '********************************************************************
                ' ｸﾞﾘｯﾄﾞ表示用ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙに追加
                '********************************************************************
                objDataTable.userAddRowDataSet(FTRK_BUF_NO, _
                                               FBUF_NAME, _
                                               XHINMEI_CD, _
                                               FHINMEI_CD, _
                                               FHINMEI, _
                                               XMAKER_CD, _
                                               XMAKER_NAME, _
                                               XPLAN_NUM, _
                                               strZaiko_PL, _
                                               XRESULT_NUM, _
                                               XSTART_DT, _
                                               FEQ_ID, _
                                               XPROD_LINE, _
                                               XPROGRESS, _
                                               FGRID_DISPLAYINDEX, _
                                              )

            Next
        End If

        '********************************************************************
        ' ｸﾞﾘｯﾄﾞへ出力
        '********************************************************************
        Call gobjComFuncFRM.GridDisplay(objDataTable, _
                                        grdList _
                                        )
        objDataTable = Nothing

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()                'ｸﾞﾘｯﾄﾞ表示設定

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

End Class
