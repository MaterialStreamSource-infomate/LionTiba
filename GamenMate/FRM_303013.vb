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

Public Class FRM_303013

#Region "　共通変数　                           "
    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrFTRK_BUF_NO As String                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
    Protected mstrFTRK_BUF_NO_Disp As String            '入庫ST
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                        "
    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFTRK_BUF_NO() As String
        Get
            Return mstrFTRK_BUF_NO
        End Get
        Set(ByVal value As String)
            mstrFTRK_BUF_NO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>入庫ST</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFTRK_BUF_NO_Disp() As String
        Get
            Return mstrFTRK_BUF_NO_Disp
        End Get
        Set(ByVal value As String)
            mstrFTRK_BUF_NO_Disp = value
        End Set
    End Property
#End Region

#Region "　ｲﾍﾞﾝﾄ　                              "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_303013_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    Private Sub FRM_303013_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
        '入庫ST ｾｯﾄ
        '**********************************************************
        lblIN_ST.Text = mstrFTRK_BUF_NO_Disp

        '**********************************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '**********************************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList01, 1, 0)  'ｸﾞﾘｯﾄﾞ初期設定

        Call grdListDisplay_TRK(grdList01)


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
#Region "  ｸﾞﾘｯﾄﾞ表示(入庫STﾄﾗｯｷﾝｸﾞ)　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示(入庫STﾄﾗｯｷﾝｸﾞ)
    ''' </summary>
    ''' <param name="grdControl">ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay_TRK(ByVal grdControl As GamenCommon.cmpMDataGrid)

        Dim strSQL As String                                        'SQL文
        Dim strTRK_BUF_WAIT As String                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(入庫待ち)

        '********************************************************************
        ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(入庫待ち)算出
        '********************************************************************
        If 1000 <= TO_INTEGER(mstrFTRK_BUF_NO) And TO_INTEGER(mstrFTRK_BUF_NO) < 2000 Then
            strTRK_BUF_WAIT = TO_STRING(mstrFTRK_BUF_NO + 3000)
        ElseIf 2000 <= TO_INTEGER(mstrFTRK_BUF_NO) And TO_INTEGER(mstrFTRK_BUF_NO) < 3000 Then
            strTRK_BUF_WAIT = TO_STRING(mstrFTRK_BUF_NO + 3000)
        Else
            strTRK_BUF_WAIT = ""
        End If

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TMST_ITEM.XHINMEI_CD "                                  '品目ﾏｽﾀ.           品名ｺｰﾄﾞ(正式品名ｺｰﾄﾞ)
        strSQL &= vbCrLf & "   ,TMST_ITEM.FHINMEI_CD "                                  '品目ﾏｽﾀ.           品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   ,TMST_ITEM.FHINMEI "                                     '品目ﾏｽﾀ.           品名
        strSQL &= vbCrLf & "   ,TRST_STOCK.XPROD_LINE "                                 '在庫情報.          生産ﾗｲﾝ№
        strSQL &= vbCrLf & "   ,TRST_STOCK.XMAKER_CD "                                  '在庫情報.          ﾒｰｶ-ｺｰﾄﾞ
        strSQL &= vbCrLf & "   ,TRST_STOCK.XKENSA_KUBUN "                               '在庫情報.          検査区分
        strSQL &= vbCrLf & "   ,HASH03.FGAMEN_DISP AS XKENSA_KUBUN_DSP "                '在庫情報.          検査区分(表示用)
        strSQL &= vbCrLf & "   ,TRST_STOCK.FIN_KUBUN "                                  '在庫情報.          入庫区分
        strSQL &= vbCrLf & "   ,HASH01.FGAMEN_DISP AS FIN_KUBUN_DSP "                   '在庫情報.          入庫区分(表示用)
        strSQL &= vbCrLf & "   ,TRST_STOCK.FHORYU_KUBUN "                               '在庫情報.          保留区分
        strSQL &= vbCrLf & "   ,HASH02.FGAMEN_DISP AS FHORYU_KUBUN_DSP "                '在庫情報.          保留区分(表示用)
        strSQL &= vbCrLf & "   ,TRST_STOCK.XKENPIN_KUBUN "                              '在庫情報.          検品区分
        strSQL &= vbCrLf & "   ,HASH04.FGAMEN_DISP AS XKENPIN_KUBUN_DSP "               '在庫情報.          検品区分(表示用)
        strSQL &= vbCrLf & "   ,TRST_STOCK.FTR_VOL "                                    '在庫情報.          搬送管理量
        strSQL &= vbCrLf & "   ,TRST_STOCK.FPALLET_ID AS FPALLET_ID"                    '在庫情報.          ﾊﾟﾚｯﾄID

        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TPRG_TRK_BUF "                                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        strSQL &= vbCrLf & "   ,TRST_STOCK "                                            '在庫情報
        strSQL &= vbCrLf & "   ,TMST_ITEM "                                             '品目ﾏｽﾀ
        strSQL &= vbCrLf & "   ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TRST_STOCK", "FIN_KUBUN")
        strSQL &= vbCrLf & "   ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "   ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TRST_STOCK", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "   ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "TRST_STOCK", "XKENPIN_KUBUN")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        If strTRK_BUF_WAIT = "" Then
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO IN (" & mstrFTRK_BUF_NO & ")"
        Else
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO IN (" & mstrFTRK_BUF_NO & ", " & strTRK_BUF_WAIT & ")"
        End If
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID = TRST_STOCK.FPALLET_ID "   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ と 在庫情報 の ﾊﾟﾚｯﾄID を 結合
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID IS NOT NULL "               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.ﾊﾟﾚｯﾄID NULL以外 を 指定
        strSQL &= vbCrLf & "    AND TMST_ITEM.FHINMEI_CD(+) = TRST_STOCK.FHINMEI_CD "   '品目ﾏｽﾀ と 在庫情報 の 品目ｺｰﾄﾞ を 外部結合
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TRST_STOCK", "FIN_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TRST_STOCK", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "TRST_STOCK", "XKENPIN_KUBUN")



        '============================================================
        'RTN指示済みﾃﾞｰﾀと連結
        '============================================================
        strSQL &= vbCrLf & " UNION ALL "



        '============================================================
        'SELECT
        '============================================================
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TMST_ITEM.XHINMEI_CD "                                  '品目ﾏｽﾀ.           品名ｺｰﾄﾞ(正式品名ｺｰﾄﾞ)
        strSQL &= vbCrLf & "   ,TMST_ITEM.FHINMEI_CD "                                  '品目ﾏｽﾀ.           品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   ,TMST_ITEM.FHINMEI "                                     '品目ﾏｽﾀ.           品名
        strSQL &= vbCrLf & "   ,TRST_STOCK.XPROD_LINE "                                 '在庫情報.          生産ﾗｲﾝ№
        strSQL &= vbCrLf & "   ,TRST_STOCK.XMAKER_CD "                                  '在庫情報.          ﾒｰｶ-ｺｰﾄﾞ
        strSQL &= vbCrLf & "   ,TRST_STOCK.XKENSA_KUBUN "                               '在庫情報.          検査区分
        strSQL &= vbCrLf & "   ,HASH03.FGAMEN_DISP AS XKENSA_KUBUN_DSP "                '在庫情報.          検査区分(表示用)
        strSQL &= vbCrLf & "   ,TRST_STOCK.FIN_KUBUN "                                  '在庫情報.          入庫区分
        strSQL &= vbCrLf & "   ,HASH01.FGAMEN_DISP AS FIN_KUBUN_DSP "                   '在庫情報.          入庫区分(表示用)
        strSQL &= vbCrLf & "   ,TRST_STOCK.FHORYU_KUBUN "                               '在庫情報.          保留区分
        strSQL &= vbCrLf & "   ,HASH02.FGAMEN_DISP AS FHORYU_KUBUN_DSP "                '在庫情報.          保留区分(表示用)
        strSQL &= vbCrLf & "   ,TRST_STOCK.XKENPIN_KUBUN "                              '在庫情報.          検品区分
        strSQL &= vbCrLf & "   ,HASH04.FGAMEN_DISP AS XKENPIN_KUBUN_DSP "               '在庫情報.          検品区分(表示用)
        strSQL &= vbCrLf & "   ,TRST_STOCK.FTR_VOL "                                    '在庫情報.          搬送管理量
        strSQL &= vbCrLf & "   ,TRST_STOCK.FPALLET_ID AS FPALLET_ID"                    '在庫情報.          ﾊﾟﾚｯﾄID

        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TPRG_TRK_BUF "                                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        strSQL &= vbCrLf & "   ,TRST_STOCK "                                            '在庫情報
        strSQL &= vbCrLf & "   ,TMST_ITEM "                                             '品目ﾏｽﾀ
        strSQL &= vbCrLf & "   ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TRST_STOCK", "FIN_KUBUN")
        strSQL &= vbCrLf & "   ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "   ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TRST_STOCK", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "   ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "TRST_STOCK", "XKENPIN_KUBUN")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO IN (" & mstrFTRK_BUF_NO & ")"
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRSV_PALLET = TRST_STOCK.FPALLET_ID "  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ と 在庫情報 の ﾊﾟﾚｯﾄID を 結合
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID IS NULL "                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.ﾊﾟﾚｯﾄID NULL を 指定
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRSV_PALLET IS NOT NULL "              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.仮引当ﾊﾟﾚｯﾄID NULL以外 を 指定
        strSQL &= vbCrLf & "    AND TMST_ITEM.FHINMEI_CD(+) = TRST_STOCK.FHINMEI_CD "   '品目ﾏｽﾀ と 在庫情報 の 品目ｺｰﾄﾞ を 外部結合
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TRST_STOCK", "FIN_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TRST_STOCK", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "TRST_STOCK", "XKENPIN_KUBUN")


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    FPALLET_ID"                                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.ﾊﾟﾚｯﾄID

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList01, _
                                strSQL, _
                                True)

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

    End Sub
#End Region

End Class