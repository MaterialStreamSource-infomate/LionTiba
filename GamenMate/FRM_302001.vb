'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】空棚詳細画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_302001

#Region "　共通変数　                           "

    Enum menmListCol
        FRAC_RETU           '列
        TAKA_TANA           '空棚・高棚
        HYOJYUN_TANA_       '空棚・標準棚
        KINSI_TANA          '禁止棚

        MAXCOL

    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞｿｰﾄ用</summary>
    ''' <remarks></remarks>
    Enum menmSortNo
        RAC_Hight = 1
        RAC_Noramal = 2
        RAC_Total
    End Enum

#End Region
#Region "　ｲﾍﾞﾝﾄ　                              "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_302001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ　                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_302001_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　閉じる   ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 閉じる ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try

            Call cmdClose_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LoadProcess()

        '**********************************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '**********************************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList01, 1, 0)  'ｸﾞﾘｯﾄﾞ初期設定
        Call gobjComFuncFRM.FlexGridInitialize(grdList02, 1, 0)  'ｸﾞﾘｯﾄﾞ初期設定

        Call grdListDisplay_SUM(grdList01)
        Call grdListDisplay_CRANE(grdList02)


    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ処理                       "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub ClosingProcess()

        '**********************************************************
        ' ｺﾝﾄﾛｰﾙ開放
        '**********************************************************
        grdList01.Dispose()

    End Sub
#End Region
#Region "　閉じる   　ﾎﾞﾀﾝ押下処理　            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 閉じる ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_ClickProcess()

        Me.Close()

    End Sub

#End Region
#Region "  ｸﾞﾘｯﾄﾞ表示(総合計)　                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示(総合計)
    ''' </summary>
    ''' <param name="grdControl">ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay_SUM(ByVal grdControl As GamenCommon.cmpMDataGrid)

        Dim strSQL As String                                        'SQL文
        Dim objRow As DataRow                                       '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataTable As New GamenCommon.clsGridDataTable05      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        For intII As Integer = 2 To 1 Step -1
            '(ﾙｰﾌﾟ:2:高棚,1:標準)
            Dim intFRAC_FORM As Integer = 0
            Dim strFRAC_FORM_NAME As String = ""

            Select Case intII
                Case 1
                    '(1:標準のとき)
                    intFRAC_FORM = FRAC_FORM_JNORMAL_TANA
                    strFRAC_FORM_NAME = "標準"
                Case 2
                    '(2:高棚のとき)
                    intFRAC_FORM = FRAC_FORM_JHIGH_TANA
                    strFRAC_FORM_NAME = "高棚"
            End Select

            '********************************************************************
            ' SQL文作成
            '********************************************************************
            '============================================================
            'SELECT
            '============================================================
            strSQL = ""
            strSQL &= vbCrLf & "     SELECT "
            strSQL &= vbCrLf & "        MAX(TPRG_TRK_BUF.FRAC_FORM) AS FRAC_FORM "                             '棚形状種別
            strSQL &= vbCrLf & "      , SUM( CASE WHEN FRES_KIND = " & FRES_KIND_SAKI & " AND FREMOVE_KIND = " & FREMOVE_KIND_SNORMAL & " THEN 1 "
            strSQL &= vbCrLf & "                  ELSE 0 "
            strSQL &= vbCrLf & "             END ) AS AKI_CNT "                 '空棚数
            strSQL &= vbCrLf & "      , SUM( CASE WHEN FREMOVE_KIND = " & FREMOVE_KIND_SON & " THEN 1 "
            strSQL &= vbCrLf & "                  ELSE 0 "
            strSQL &= vbCrLf & "             END ) AS REMOVE_CNT "              '禁止棚数
            '============================================================
            'FROM
            '============================================================
            strSQL &= vbCrLf & "     FROM "
            strSQL &= vbCrLf & "        TPRG_TRK_BUF "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            strSQL &= vbCrLf & "     ,  TMST_CRANE "                                'ｸﾚｰﾝﾏｽﾀ
            strSQL &= vbCrLf & "     ,  TSTS_EQ_CTRL "                              '設備状況
            '============================================================
            'WHERE
            '============================================================
            strSQL &= vbCrLf & "     WHERE 1 = 1 "
            strSQL &= vbCrLf & "       AND TPRG_TRK_BUF.FTRK_BUF_NO = " & FTRK_BUF_NO_J9000             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.ﾊﾞｯﾌｧ№
            strSQL &= vbCrLf & "       AND TPRG_TRK_BUF.FRAC_RETU   >= TMST_CRANE.FCRANE_ROW1(+) "      '列1
            strSQL &= vbCrLf & "       AND TPRG_TRK_BUF.FRAC_RETU   <= TMST_CRANE.FCRANE_ROW2(+) "      '列2
            strSQL &= vbCrLf & "       AND TMST_CRANE.FEQ_ID         = TSTS_EQ_CTRL.FEQ_ID(+) "         '設備ID
            strSQL &= vbCrLf & "       AND TSTS_EQ_CTRL.FEQ_CUT_STS  = " & FEQ_CUT_STS_SOFF             '切離状態 = 通常
            strSQL &= vbCrLf & "       AND TSTS_EQ_CTRL.FEQ_STS      = " & FEQ_STS_JINOUTMODE_OUT       '設備状態 = 運転中
            strSQL &= vbCrLf & "       AND TPRG_TRK_BUF.FRAC_FORM = " & intFRAC_FORM                    '棚形状種別
            strSQL &= vbCrLf

            '********************************************************************
            'ﾃﾞｰﾀｾｯﾄ取得
            '********************************************************************
            Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
            gobjDb.SQL = strSQL
            strDataSetName = "TPRG_TRK_BUF"
            objDataSet.Clear()
            gobjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For Each objRow In objDataSet.Tables(strDataSetName).Rows

                    '**********************************************************
                    ' 空ﾌﾞﾛｯｸ数取得
                    '**********************************************************
                    Dim intTANA_AKI As Integer = 0
                    intTANA_AKI = GetAkiBLOCKCnt(intFRAC_FORM)


                    '**********************************************************
                    ' ｸﾞﾘｯﾄﾞに追加
                    '**********************************************************
                    objDataTable.userAddRowDataSet(IIf(IsNull(TO_STRING(objRow("FRAC_FORM"))), 0, TO_STRING(objRow("FRAC_FORM"))), _
                                                   strFRAC_FORM_NAME, _
                                                   intTANA_AKI, _
                                                   IIf(IsNull(TO_STRING(objRow("AKI_CNT"))), 0, TO_STRING(objRow("AKI_CNT"))), _
                                                   IIf(IsNull(TO_STRING(objRow("REMOVE_CNT"))), 0, TO_STRING(objRow("REMOVE_CNT"))))

                Next
            End If

        Next


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        grdControl.DataSource = objDataTable

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup(grdControl)
        Call gobjComFuncFRM.GridSelect(grdControl, -1, -1, Nothing)       'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ表示(ｸﾚｰﾝ)　                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示(ｸﾚｰﾝ)
    ''' </summary>
    ''' <param name="grdControl">ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay_CRANE(ByVal grdControl As GamenCommon.cmpMDataGrid)

        Dim intRet As RetCode                                       '戻り値
        Dim strSQL As String                                        'SQL文
        Dim objRow As DataRow                                       '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataTable As New GamenCommon.clsGridDataTable05      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ


        '********************************************************************
        ' ｸﾚｰﾝﾏｽﾀの特定
        '********************************************************************
        Dim intII As Integer = 0
        Dim objTMST_CRANE_ARY As New TBL_TMST_CRANE(gobjOwner, gobjDb, Nothing)
        objTMST_CRANE_ARY.ORDER_BY = "FEQ_ID ASC "
        objTMST_CRANE_ARY.GET_TMST_CRANE_ANY()  '特定
        If intRet = RetCode.OK Then
            For Each objTMST_CRANE As TBL_TMST_CRANE In objTMST_CRANE_ARY.ARYME
                '(ﾙｰﾌﾟ:ｸﾚｰﾝ数)

                intII += 1

                '********************************************************************
                ' SQL文作成
                '********************************************************************
                '============================================================
                'SELECT
                '============================================================
                strSQL = ""
                strSQL &= vbCrLf & "     SELECT "
                strSQL &= vbCrLf & "        MIN(TPRG_TRK_BUF.FRAC_RETU) AS FRAC_RETU "                             '棚形状種別
                strSQL &= vbCrLf & "      , SUM( CASE WHEN FRES_KIND = " & FRES_KIND_SAKI & " AND FREMOVE_KIND = " & FREMOVE_KIND_SNORMAL & " THEN 1 "
                strSQL &= vbCrLf & "                  ELSE 0 "
                strSQL &= vbCrLf & "             END ) AS AKI_CNT "                 '空棚数
                strSQL &= vbCrLf & "      , SUM( CASE WHEN FREMOVE_KIND = " & FREMOVE_KIND_SON & " THEN 1 "
                strSQL &= vbCrLf & "                  ELSE 0 "
                strSQL &= vbCrLf & "             END ) AS REMOVE_CNT "              '禁止棚数
                '============================================================
                'FROM
                '============================================================
                strSQL &= vbCrLf & "     FROM "
                strSQL &= vbCrLf & "        TPRG_TRK_BUF "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                strSQL &= vbCrLf & "     ,  TMST_CRANE "                                'ｸﾚｰﾝﾏｽﾀ
                strSQL &= vbCrLf & "     ,  TSTS_EQ_CTRL "                              '設備状況
                '============================================================
                'WHERE
                '============================================================
                strSQL &= vbCrLf & "     WHERE 1 = 1 "                                  '< 結合条件／抽出条件 >
                strSQL &= vbCrLf & "       AND TPRG_TRK_BUF.FTRK_BUF_NO = " & FTRK_BUF_NO_J9000             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.ﾊﾞｯﾌｧ№
                strSQL &= vbCrLf & "       AND TPRG_TRK_BUF.FRAC_RETU   >= TMST_CRANE.FCRANE_ROW1(+) "      '列1
                strSQL &= vbCrLf & "       AND TPRG_TRK_BUF.FRAC_RETU   <= TMST_CRANE.FCRANE_ROW2(+) "      '列2
                strSQL &= vbCrLf & "       AND TMST_CRANE.FEQ_ID         = TSTS_EQ_CTRL.FEQ_ID(+) "         '設備ID
                strSQL &= vbCrLf & "       AND TSTS_EQ_CTRL.FEQ_CUT_STS  = " & FEQ_CUT_STS_SOFF             '切離状態 = 通常
                strSQL &= vbCrLf & "       AND TSTS_EQ_CTRL.FEQ_STS      = " & FEQ_STS_JINOUTMODE_OUT       '設備状態 = 運転中
                strSQL &= vbCrLf & "       AND TPRG_TRK_BUF.FRAC_RETU >= " & objTMST_CRANE.FCRANE_ROW1      'ｸﾚｰﾝ対象列指定
                strSQL &= vbCrLf & "       AND TPRG_TRK_BUF.FRAC_RETU <= " & objTMST_CRANE.FCRANE_ROW2      'ｸﾚｰﾝ対象列指定
                strSQL &= vbCrLf

                '********************************************************************
                'ﾃﾞｰﾀｾｯﾄ取得
                '********************************************************************
                Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
                Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
                gobjDb.SQL = strSQL
                strDataSetName = "TPRG_TRK_BUF"
                objDataSet.Clear()
                gobjDb.GetDataSet(strDataSetName, objDataSet)
                If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                    For Each objRow In objDataSet.Tables(strDataSetName).Rows

                        '**********************************************************
                        ' 空ﾌﾞﾛｯｸ数取得
                        '**********************************************************
                        Dim intTANA_AKI As Integer = 0
                        intTANA_AKI = GetAkiBLOCKCnt("", objTMST_CRANE)


                        '**********************************************************
                        ' ｸﾞﾘｯﾄﾞに追加
                        '**********************************************************
                        objDataTable.userAddRowDataSet("", _
                                                       intII & "号機", _
                                                       intTANA_AKI, _
                                                       IIf(IsNull(TO_STRING(objRow("AKI_CNT"))), 0, TO_STRING(objRow("AKI_CNT"))), _
                                                       IIf(IsNull(TO_STRING(objRow("REMOVE_CNT"))), 0, TO_STRING(objRow("REMOVE_CNT"))))

                    Next
                End If

            Next
        End If

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        grdControl.DataSource = objDataTable

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup(grdControl)
        Call gobjComFuncFRM.GridSelect(grdControl, -1, -1, Nothing)       'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定　                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定
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


    End Sub
#End Region
#Region "　棚ﾌﾞﾛｯｸ取得        処理　            "
    '''***************************************************************************************************************
    ''' <summary>
    ''' 棚ﾌﾞﾛｯｸ取得        処理
    ''' </summary>
    ''' <param name="strFRAC_FORM">棚形状種別</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Private Function GetAkiBLOCKCnt(Optional ByVal strFRAC_FORM As String = "", _
                                    Optional ByVal objTMST_CRANE As TBL_TMST_CRANE = Nothing) As Integer

        Dim strSQL As String                        'SQL文

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    COUNT(*) AS CNT "
        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        '============================================================
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ副問合せ
        '============================================================
        strSQL &= vbCrLf & "    ("
        strSQL &= vbCrLf & "    SELECT "
        strSQL &= vbCrLf & "      TPRG_TRK_BUF.XTANA_BLOCK "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FRAC_FORM) AS FRAC_FORM "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FTRNS_ADDRESS) AS FTRNS_ADDRESS "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FRES_KIND) AS FRES_KIND "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FREMOVE_KIND) AS FREMOVE_KIND "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FTRK_BUF_NO) AS FTRK_BUF_NO "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FRAC_RETU) AS FRAC_RETU "
        strSQL &= vbCrLf & "    FROM TPRG_TRK_BUF "
        strSQL &= vbCrLf & "    WHERE 1 = 1 "
        strSQL &= vbCrLf & "    GROUP BY TPRG_TRK_BUF.XTANA_BLOCK"
        strSQL &= vbCrLf & "    ) TPRG_TRK_BUF "                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        strSQL &= vbCrLf & " ,  TMST_CRANE "                            'ｸﾚｰﾝﾏｽﾀ
        strSQL &= vbCrLf & " ,  TSTS_EQ_CTRL "                          '設備状況
        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "      1 = 1 "
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FRES_KIND    = " & FRES_KIND_SAKI                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.引当状態 が 0:空棚 のﾚｺｰﾄﾞを抽出
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FREMOVE_KIND = " & FREMOVE_KIND_SNORMAL          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.禁止有無 が 0:無   のﾚｺｰﾄﾞを抽出
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FTRK_BUF_NO  = " & FTRK_BUF_NO_J9000             '自動倉庫
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FRAC_RETU   >= TMST_CRANE.FCRANE_ROW1(+) "       '列1
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FRAC_RETU   <= TMST_CRANE.FCRANE_ROW2(+) "       '列2
        strSQL &= vbCrLf & "  AND TMST_CRANE.FEQ_ID         = TSTS_EQ_CTRL.FEQ_ID(+) "          '設備ID
        strSQL &= vbCrLf & "  AND TSTS_EQ_CTRL.FEQ_CUT_STS  = " & FEQ_CUT_STS_SOFF              '切離状態 = 通常
        strSQL &= vbCrLf & "  AND TSTS_EQ_CTRL.FEQ_STS      = " & FEQ_STS_JINOUTMODE_OUT        '設備状態 = 運転中
        If strFRAC_FORM <> CBO_ALL_VALUE Then
            '(棚形状種別が指定されている場合)
            strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FRAC_FORM = " & strFRAC_FORM                     '棚形状種別
        End If
        If IsNotNull(objTMST_CRANE) = True Then
            '(ｸﾚｰﾝﾏｽﾀが指定されている場合)
            strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FRAC_RETU >= " & objTMST_CRANE.FCRANE_ROW1           'ｸﾚｰﾝ対象列指定
            strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FRAC_RETU <= " & objTMST_CRANE.FCRANE_ROW2           'ｸﾚｰﾝ対象列指定
        End If
        strSQL &= vbCrLf

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        gobjDb.SQL = strSQL
        strDataSetName = "TPRG_TRK_BUF"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        objRow = objDataSet.Tables(strDataSetName).Rows(0)

        Return TO_INTEGER(objRow("CNT"))

    End Function
#End Region

End Class
