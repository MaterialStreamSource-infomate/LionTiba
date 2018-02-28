'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】D45包材出庫登録子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region
Public Class FRM_310041
#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrXPROD_LINE As String                  '生産ﾗｲﾝNo.

    Private mstrXPROD_LINE_NAME As String               '生産ﾗｲﾝ名
    Private mstrFHINMEI_CD As String                    '品名記号
    Private mstrFHINMEI As String                       '品名
    Private mstrXMAKER_CD As String                     'ﾒｰｶｰｺｰﾄﾞ
    Private mstrXMAKER_NAME As String                   'ﾒｰｶｰ名
    Private mstrXRESULT_NUM As String                   '実績PL数
    Private mintFPROGRESS As Integer                    '進捗状況
    Private mstrFEQ_ID As String                        '設備ID
    Private mstrFTRK_BUF_NO As String                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
    Private mstrFGRID_DISPLAYINDEX As String            '表示順序

    Private mstrSTOCK_NUM As String                     '在庫PL数

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        Out_SetBtn_Click               '出庫登録
        Out_ResetBtn_Click             '登録解除
        CancelBtn_Click                'ｷｬﾝｾﾙ
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "


    '''''' =======================================
    '''''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userFTRK_BUF_NO() As String
    ' ''    Get
    ' ''        Return mstrFTRK_BUF_NO
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrFTRK_BUF_NO = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>品名ｺｰﾄﾞ</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userFHINMEI_CD() As String
    ' ''    Get
    ' ''        Return mstrFHINMEI_CD
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrFHINMEI_CD = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>品名</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userFHINMEI() As String
    ' ''    Get
    ' ''        Return mstrFHINMEI
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrFHINMEI = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>ﾒｰｶｰｺｰﾄﾞ</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userMAKER_CD() As String
    ' ''    Get
    ' ''        Return mstrMAKER_CD
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrMAKER_CD = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>ﾒｰｶｰ名</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userMAKER_NAME() As String
    ' ''    Get
    ' ''        Return mstrMAKER_NAME
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrMAKER_NAME = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>実績PL数</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userRESULT_NUM() As String
    ' ''    Get
    ' ''        Return mstrRESULT_NUM
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrRESULT_NUM = value
    ' ''    End Set
    ' ''End Property

    ''' =======================================
    ''' <summary>生産ﾗｲﾝNo.</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXPROD_LINE() As String
        Get
            Return mstrXPROD_LINE
        End Get
        Set(ByVal value As String)
            mstrXPROD_LINE = value
        End Set
    End Property

    '''''' =======================================
    '''''' <summary>生産ﾗｲﾝ名</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userXPROD_LINE_NAME() As String
    ' ''    Get
    ' ''        Return mstrXPROD_LINE_NAME
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXPROD_LINE_NAME = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>進捗状況</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userFPROGRESS() As Integer
    ' ''    Get
    ' ''        Return mintFPROGRESS
    ' ''    End Get
    ' ''    Set(ByVal value As Integer)
    ' ''        mintFPROGRESS = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>設備ID</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userFEQ_ID() As String
    ' ''    Get
    ' ''        Return mstrFEQ_ID
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrFEQ_ID = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>表示順序</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userDSPGRID_DISPLAYINDEX() As Integer
    ' ''    Get
    ' ''        Return mintDSPGRID_DISPLAYINDEX
    ' ''    End Get
    ' ''    Set(ByVal value As Integer)
    ' ''        mintDSPGRID_DISPLAYINDEX = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>在庫PL数</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userSTOCK_NUM() As String
    ' ''    Get
    ' ''        Return mstrSTOCK_NUM
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrSTOCK_NUM = value
    ' ''    End Set
    ' ''End Property

#End Region
#Region "　ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_310031_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ　                             "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_310031_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　出庫登録   　ﾎﾞﾀﾝ押下                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdOUT_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOUT_Set.Click
        Try

            Call cmdOUT_Set_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　登録解除   　ﾎﾞﾀﾝ押下                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdOUT_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOUT_Cancel.Click
        Try

            Call cmdOUT_Cancel_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try

            Call cmdCancel_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region

#Region "　品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ   ﾃｷｽﾄﾁｪﾝｼﾞ            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cboFHINMEI_CD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFHINMEI_CD.TextChanged

        If mFlag_Form_Load = False Then

            '********************************************************************
            ' ﾒｰｶｰ名,生産ﾗｲﾝNo.の取得
            '********************************************************************
            Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ
            Dim strSQL As String = ""

            '********************************************************************
            ' ｺﾈｸｼｮﾝの確認
            '********************************************************************
            If IsNull(gobjDb) = True Then
                'ｺﾈｸｼｮﾝがｾｯﾄされていない場合は終了
                Return
            End If

            '********************************************************************
            ' SQL文
            '********************************************************************
            strSQL = ""
            '(Select句)
            strSQL &= vbCrLf & " SELECT DISTINCT "
            strSQL &= vbCrLf & "     TMST_ITEM.FHINMEI_CD "                             '品目ﾏｽﾀ        .品名ｺｰﾄﾞ
            strSQL &= vbCrLf & "   , TMST_ITEM.XMAKER_CD "                              '品目ﾏｽﾀ        .ﾒｰｶｰｺｰﾄﾞ
            strSQL &= vbCrLf & "   , XMST_WRAPPING_MAKER.XMAKER_NAME "                  '包材ﾒｰｶｰﾏｽﾀ    .ﾒｰｶｰ名
            '(From句)
            strSQL &= vbCrLf & " FROM   "
            strSQL &= vbCrLf & "     TMST_ITEM "                                        '【品目ﾏｽﾀ】
            strSQL &= vbCrLf & "   , XMST_WRAPPING_MAKER "                              '【包材ﾒｰｶｰﾏｽﾀ】
            '(Where句)
            strSQL &= vbCrLf & " WHERE  "
            strSQL &= vbCrLf & "     TMST_ITEM.XMAKER_CD = XMST_WRAPPING_MAKER.XMAKER_CD(+) "
            strSQL &= vbCrLf & " AND TMST_ITEM.FHINMEI_CD = '" & cboFHINMEI_CD.Text & "' "

            '********************************************************************
            ' 実行
            '********************************************************************
            gobjDb.SQL = strSQL

            objDataSet.Clear()
            gobjDb.GetDataSet("WRAPPING_OUT", objDataSet)

            If objDataSet.Tables("WRAPPING_OUT").Rows.Count <= 0 Then
                '(ﾒｰｶｰ名が取得できなかった場合)
                lblMAKER_NAME.Text = ""
                mstrXMAKER_CD = ""
            Else
                '(ﾒｰｶｰ名が取得できた場合)
                lblMAKER_NAME.Text = TO_STRING(objDataSet.Tables("WRAPPING_OUT").Rows(0).Item("XMAKER_NAME"))
                mstrXMAKER_CD = TO_STRING(objDataSet.Tables("WRAPPING_OUT").Rows(0).Item("XMAKER_CD"))
            End If


            Call ZAIKO_PL_Refresh() '在庫数表示

        End If

    End Sub
#End Region
#Region "　ﾒｰｶｰｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ   ﾃｷｽﾄﾁｪﾝｼﾞ            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cboXMAKER_CD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboXMAKER_CD.TextChanged

        If mFlag_Form_Load = False Then

            lblMAKER_NAME.Text = TO_STRING(cboXMAKER_CD.SelectedValue)

            Call ZAIKO_PL_Refresh() '在庫数表示

        End If

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
#Region "  ﾌｫｰﾑﾛｰﾄﾞ     処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LoadProcess()

        '===================================
        '包材出庫設定状態(D45)取得
        '===================================
        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）
        Dim objRow2 As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName2 As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet2 As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        Dim strDEFAULT_FHINMEI_CD As String = ""         'ﾃﾞﾌｫﾙﾄ品名記号

        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "       XSTS_WRAPPING_MATERIAL_D45.XPROD_LINE "              '包材出庫設定状態(D45)      .生産ﾗｲﾝNo.(非表示)
        strSQL &= vbCrLf & "     , XMST_PROD_LINE_D45.XPROD_LINE_NAME "                 '生産ﾗｲﾝﾏｽﾀ(D45)            .生産ﾗｲﾝ名
        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL_D45.FHINMEI_CD "              '包材出庫設定状態(D45)      .品名記号
        strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                                  '品目ﾏｽﾀ                    .品名
        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL_D45.XMAKER_CD "               '包材出庫設定状態(D45)      .ﾒｰｶｰｺｰﾄﾞ
        strSQL &= vbCrLf & "     , XMST_WRAPPING_MAKER.XMAKER_NAME "                    '包材ﾒｰｶｰﾏｽﾀ                .ﾒｰｶ名

        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL_D45.FTRK_BUF_NO"              '包材出庫設定状態(D45)      .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.(非表示)
        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL_D45.FEQ_ID "                  '包材出庫設定状態(D45)      .設備ID(非表示)
        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL_D45.XPROGRESS "               '包材出庫設定状態(D45)      .進捗状態(非表示)
        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL_D45.FGRID_DISPLAYINDEX "      '包材出庫設定状態(D45)      .ｸﾞﾘｯﾄﾞ列表示順序(非表示)

        strSQL &= vbCrLf & "     , XMST_PROD_LINE_D45.FHINMEI_CD DEFAULT_FHINMEI_CD "   '生産ﾗｲﾝﾏｽﾀ(D45)            .品名記号

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_WRAPPING_MATERIAL_D45 "    '【包材出庫設定状態(D45)】
        strSQL &= vbCrLf & "  , XMST_PROD_LINE_D45 "            '【生産ﾗｲﾝﾏｽﾀ(D45)】
        strSQL &= vbCrLf & "  , TMST_ITEM "                     '【品目ﾏｽﾀ】
        strSQL &= vbCrLf & "  , XMST_WRAPPING_MAKER "           '【包材ﾒｰｶｰﾏｽﾀ】

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件
        strSQL &= vbCrLf & "    AND XSTS_WRAPPING_MATERIAL_D45.XPROD_LINE = '" & mstrXPROD_LINE & "' "
        strSQL &= vbCrLf & "    AND XSTS_WRAPPING_MATERIAL_D45.XPROD_LINE = XMST_PROD_LINE_D45.XPROD_LINE(+) "
        strSQL &= vbCrLf & "    AND XSTS_WRAPPING_MATERIAL_D45.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "    AND XSTS_WRAPPING_MATERIAL_D45.XMAKER_CD = XMST_WRAPPING_MAKER.XMAKER_CD(+) "

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XSTS_WRAPPING_MATERIAL_D45"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                '********************************************************************
                ' ﾃﾞｰﾀ取得
                '********************************************************************
                mstrXPROD_LINE = TO_STRING(objRow("XPROD_LINE"))
                mstrXPROD_LINE_NAME = TO_STRING(objRow("XPROD_LINE_NAME"))
                mstrFHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))
                mstrFHINMEI = TO_STRING(objRow("FHINMEI"))
                mstrXMAKER_CD = TO_STRING(objRow("XMAKER_CD"))
                mstrXMAKER_NAME = TO_STRING(objRow("XMAKER_NAME"))
                mstrFTRK_BUF_NO = TO_STRING(objRow("FTRK_BUF_NO"))
                mstrFEQ_ID = TO_STRING(objRow("FEQ_ID"))
                mintFPROGRESS = TO_INTEGER(objRow("XPROGRESS"))
                mstrFGRID_DISPLAYINDEX = TO_STRING(objRow("FGRID_DISPLAYINDEX"))

                strDEFAULT_FHINMEI_CD = TO_STRING(objRow("DEFAULT_FHINMEI_CD"))


                If mstrFHINMEI_CD <> "" Then
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
                    strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD     = '" & mstrFHINMEI_CD & "' "              '品名ｺｰﾄﾞ
                    If mstrXMAKER_CD <> "" Then                                                                     'ﾒｰｶｰｺｰﾄﾞ
                        strSQL &= vbCrLf & "  AND TRST_STOCK.XMAKER_CD = '" & mstrXMAKER_CD & "' "
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
                            mstrSTOCK_NUM = TO_STRING(objRow2("ZAIKO_PL")) '在庫総数

                        Next
                    End If

                Else
                    '(包材出庫設定が設定されていない場合)
                    mstrSTOCK_NUM = ""
                End If

            Next
        End If

        '===================================
        '生産ﾗｲﾝ名 ｾｯﾄ
        '===================================
        lblPROD_LINE_NAME.Text = mstrXPROD_LINE_NAME

        '===================================
        '在庫PL数 ｾｯﾄ
        '===================================
        lblSTOCK_VOL.Text = mstrSTOCK_NUM

        '===================================
        '進捗状態の確認
        '===================================
        If mintFPROGRESS = XPROGRESS_NON Then
            '(未登録の場合)
            '===================================
            '品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
            '===================================
            cboFHINMEI_CD.conn = gobjDb
            cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
            cboFHINMEI_CD.Text = ""
            cboFHINMEI_CD.HinmeiVisible = False
            cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)
            cboFHINMEI_CD.Text = strDEFAULT_FHINMEI_CD

            '===================================
            'ﾒｰｶｰｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
            '===================================
            Call cboXMAKER_CD_Setup(cboXMAKER_CD)

            '===================================
            'ﾒｰｶｰ名 ｾｯﾄ
            '===================================
            lblMAKER_NAME.Text = ""

        ElseIf mintFPROGRESS = XPROGRESS_START Then
            '(登録済の場合)
            '===================================
            '品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
            '===================================
            cboFHINMEI_CD.Enabled = False
            cboFHINMEI_CD.Text = mstrFHINMEI_CD

            '===================================
            '品名 ｾｯﾄ
            '===================================
            lblFHINMEI.Text = mstrFHINMEI

            '===================================
            'ﾒｰｶｰｺｰﾄﾞ ｾｯﾄ
            '===================================
            Call cboXMAKER_CD_Setup(cboXMAKER_CD)
            If mstrXMAKER_CD <> "" Then
                cboXMAKER_CD.Text = mstrXMAKER_CD
            End If
            cboXMAKER_CD.Enabled = False

            '===================================
            'ﾒｰｶｰ名 ｾｯﾄ
            '===================================
            lblMAKER_NAME.Text = mstrXMAKER_NAME

        ElseIf mintFPROGRESS = XPROGRESS_END Then
            '(終了済の場合)
            '===================================
            '品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
            '===================================
            cboFHINMEI_CD.conn = gobjDb
            cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
            cboFHINMEI_CD.Text = ""
            cboFHINMEI_CD.HinmeiVisible = False
            cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)
            cboFHINMEI_CD.Text = strDEFAULT_FHINMEI_CD

            '===================================
            'ﾒｰｶｰｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
            '===================================
            Call cboXMAKER_CD_Setup(cboXMAKER_CD)

            '===================================
            'ﾒｰｶｰ名 ｾｯﾄ
            '===================================
            lblMAKER_NAME.Text = ""

        End If

        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ClosingProcess()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        lblPROD_LINE_NAME.Dispose()
        cboFHINMEI_CD.Dispose()
        lblFHINMEI.Dispose()
        lblMAKER_NAME.Dispose()

        cmdOUT_Set.Dispose()
        cmdOUT_Cancel.Dispose()
        cmdCancel.Dispose()

    End Sub
#End Region
#Region "　出庫登録        ﾎﾞﾀﾝ押下処理             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出庫登録 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdOUT_Set_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Out_SetBtn_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If SendSocket01() = False Then
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
#End Region
#Region "　登録解除        ﾎﾞﾀﾝ押下処理             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 登録解除 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdOUT_Cancel_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Out_ResetBtn_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If SendSocket02() = False Then
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ        ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
#End Region

#Region "　入力ﾁｪｯｸ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <returns>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.Out_SetBtn_Click
                '(出庫登録の場合)

                '========================================
                '進捗状況
                '========================================
                If mintFPROGRESS = XPROGRESS_START Then
                    '（開始状態の場合）
                    Call gobjComFuncFRM.DisplayPopup("既に登録済のため、出庫登録出来ません。", _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '品名記号
                '========================================
                If cboFHINMEI_CD.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                If cboFHINMEI_CD.FIND_FLAG = False Then
                    '(該当品目なしの場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                blnCheckErr = False

            Case menmCheckCase.Out_ResetBtn_Click
                '(登録解除の場合)
                '========================================
                '進捗状況
                '========================================
                If mintFPROGRESS = XPROGRESS_NON Or mintFPROGRESS = XPROGRESS_END Then
                    '（終了状態の場合）
                    Call gobjComFuncFRM.DisplayPopup("未登録状態のため、登録解除出来ません。", _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                blnCheckErr = False

            Case menmCheckCase.CancelBtn_Click
                '(ｷｬﾝｾﾙの場合)

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


#Region "  ｿｹｯﾄ送信(出庫登録)                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信(出庫登録)
    ''' </summary>
    ''' <returns>True :送信成功 False:送信失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SendSocket01() As Boolean
        Dim blnReturn As Boolean = False    '自関数戻値
        Dim blnCheckErr As Boolean = True   'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= "出庫登録" & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If

        '********************************************************************
        ' 品名記号取得
        '********************************************************************
        Dim DSPHINMEI_CD As String = ""

        If IsNumeric(cboFHINMEI_CD.Text.Substring(0, 1)) Then
            '(品名ｺｰﾄﾞの場合)
            Dim intRet As Integer
            Dim objTBL_TMST_ITEM As TBL_TMST_ITEM
            objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
            objTBL_TMST_ITEM.XHINMEI_CD = cboFHINMEI_CD.Text
            intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
            If intRet = RetCode.OK Then
                '(値がある時)
                DSPHINMEI_CD = objTBL_TMST_ITEM.FHINMEI_CD        '品名記号
            End If

        Else
            DSPHINMEI_CD = cboFHINMEI_CD.Text

        End If

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim datNow As Date = DateTime.Now

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400203    'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("XDSPPROD_LINE", mstrXPROD_LINE)                             '生産ﾗｲﾝNo. 
        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", mstrFTRK_BUF_NO)                            'ﾊﾞｯﾌｧNo.
        'objTelegram.SETIN_DATA("DSPEQ_ID", mstrFEQ_ID)                                      '設備ID(未使用)
        objTelegram.SETIN_DATA("DSPHINMEI_CD", DSPHINMEI_CD)                                '品名ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPMAKER_CD", TO_STRING(cboXMAKER_CD.Text))                'ﾒｰｶｰｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPSTART_DT", Format(datNow, "yyyy/MM/dd HH:mm:ss"))       '開始日時
        objTelegram.SETIN_DATA("XDSPEND_DT", "")                                            '終了日時
        'objTelegram.SETIN_DATA("XDSPPLAN_NUM", "")                                          '計画数量(未使用)
        objTelegram.SETIN_DATA("XDSPRESULT_NUM", "0")                                       '実績数量
        objTelegram.SETIN_DATA("XDSPPROGRESS", TO_STRING(XPROGRESS_START))                  '進捗状況
        objTelegram.SETIN_DATA("DSPGRID_DISPLAYINDEX", TO_STRING(mstrFGRID_DISPLAYINDEX))   '表示順序

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = ""
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
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

#Region "  ｿｹｯﾄ送信(登録解除)                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信(出庫解除)
    ''' </summary>
    ''' <returns>True :送信成功 False:送信失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SendSocket02() As Boolean
        Dim blnReturn As Boolean = False    '自関数戻値
        Dim blnCheckErr As Boolean = True   'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= "登録解除" & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim datNow As Date = DateTime.Now

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400203    'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("XDSPPROD_LINE", mstrXPROD_LINE)                             '生産ﾗｲﾝNo. 
        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", mstrFTRK_BUF_NO)                            'ﾊﾞｯﾌｧNo.
        'objTelegram.SETIN_DATA("DSPEQ_ID", mstrFEQ_ID)                                      '設備ID(未使用)
        objTelegram.SETIN_DATA("DSPHINMEI_CD", "")                                          '品名ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPMAKER_CD", "")                                          'ﾒｰｶｰｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPSTART_DT", "")                                          '開始日時
        objTelegram.SETIN_DATA("XDSPEND_DT", Format(datNow, "yyyy/MM/dd HH:mm:ss"))         '終了日時
        'objTelegram.SETIN_DATA("XDSPPLAN_NUM", "0")                                         '計画数量(未使用)
        objTelegram.SETIN_DATA("XDSPRESULT_NUM", "0")                                       '実績数量
        objTelegram.SETIN_DATA("XDSPPROGRESS", TO_STRING(XPROGRESS_END))                    '進捗状況
        objTelegram.SETIN_DATA("DSPGRID_DISPLAYINDEX", TO_STRING(mstrFGRID_DISPLAYINDEX))   '表示順序

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = ""
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
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

#Region "　在庫数 表示更新                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在庫数 表示更新
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ZAIKO_PL_Refresh()

        Dim strFHINMEI_CD As String = ""    '品名ｺｰﾄﾞ
        Dim strXMAKER_CD As String = ""     'ﾒｰｶｰｺｰﾄﾞ

        '********************************************************************
        ' 品名記号確認
        '********************************************************************
        If cboFHINMEI_CD.Text = "" Then
            '(品名記号が未選択)
            lblSTOCK_VOL.Text = ""
            Exit Sub
        End If


        '********************************************************************
        ' 品名記号取得
        '********************************************************************
        If IsNumeric(cboFHINMEI_CD.Text.Substring(0, 1)) Then
            '(品名ｺｰﾄﾞの場合)
            Dim intRet As Integer
            Dim objTBL_TMST_ITEM As TBL_TMST_ITEM
            objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
            objTBL_TMST_ITEM.XHINMEI_CD = cboFHINMEI_CD.Text
            intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
            If intRet = RetCode.OK Then
                '(値がある時)
                strFHINMEI_CD = objTBL_TMST_ITEM.FHINMEI_CD        '品名記号
            End If

        Else
            '(品名記号の場合)
            strFHINMEI_CD = cboFHINMEI_CD.Text

        End If


        'ﾒｰｶｺｰﾄﾞ
        strXMAKER_CD = cboXMAKER_CD.Text


        '===================================
        '在庫PL数 取得
        '===================================
        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        '********************************************************************
        ' 在庫情報より在庫PL数算出
        ' SQL文作成
        '********************************************************************
        '在庫情報から総在庫数取得(ﾒｰｶｰｺｰﾄﾞ含む)
        strSQL = ""
        strSQL &= vbCrLf & "  SELECT     "
        strSQL &= vbCrLf & "      Count(*) ZAIKO_PL  "
        strSQL &= vbCrLf & "  FROM "
        strSQL &= vbCrLf & "      TRST_STOCK "
        strSQL &= vbCrLf & "    , TPRG_TRK_BUF "
        strSQL &= vbCrLf & "  WHERE "
        strSQL &= vbCrLf & "        1 = 1"
        strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRES_KIND = " & FRES_KIND_SZAIKO               '在庫棚のみ
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FREMOVE_KIND = " & FREMOVE_KIND_SNORMAL        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.禁止有無 が 0:無   のﾚｺｰﾄﾞを抽出
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO  = " & FTRK_BUF_NO_J9000           '自動倉庫
        strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = '" & strFHINMEI_CD & "' "           '品名ｺｰﾄﾞ
        If strXMAKER_CD <> "" Then                                                              'ﾒｰｶｰｺｰﾄﾞ
            strSQL &= vbCrLf & "  AND TRST_STOCK.XMAKER_CD = '" & strXMAKER_CD & "' "
        End If

        '-----------------------
        '抽出
        '-----------------------
        objDataSet.Clear()
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TRST_STOCK_SUM"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                mstrSTOCK_NUM = TO_STRING(objRow("ZAIKO_PL")) '在庫総数
            Next
        End If


        'ﾗﾍﾞﾙ表示
        lblSTOCK_VOL.Text = TO_STRING(mstrSTOCK_NUM)

    End Sub

#End Region

#Region "　ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ (ﾒｰｶｰｺｰﾄﾞ)  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ (ﾒｰｶｰｺｰﾄﾞ)
    ''' </summary>
    ''' <param name="cboControl">作成するｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値                                    （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cboXMAKER_CD_Setup(ByRef cboControl As Windows.Forms.ComboBox _
                   , Optional ByVal blnAllFlag As Boolean = True _
                   , Optional ByVal objDefault As Object = Nothing _
                   , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                     )
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))

        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then
            '(AllﾌﾗｸﾞがTRUEの場合)
            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        ' 包材ﾒｰｶﾏｽﾀ 取得
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "        XMAKER_CD "                 '包材ﾒｰｶﾏｽﾀ   .ﾒｰｶｰｺｰﾄﾞ
        strSQL &= vbCrLf & "   ,    XMAKER_NAME "               '包材ﾒｰｶﾏｽﾀ   .ﾒｰｶｰ名
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "        XMST_WRAPPING_MAKER "       '[包材ﾒｰｶﾏｽﾀ]
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "        XMAKER_CD "                 '包材ﾒｰｶﾏｽﾀ   .ﾒｰｶｰｺｰﾄﾞ

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XMST_WRAPPING_MAKER"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                'ｱｲﾃﾑｾｯﾄ
                cboControl.Items.Add(TO_STRING(objRow("XMAKER_CD")))

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("XMAKER_CD"))
                Dim SubItem2 As String
                subItem2 = TO_STRING(objRow("XMAKER_NAME"))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = subItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"

        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)
            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)

        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)
            Call gobjComFuncFRM.cboSelectValue(cboControl, objDefault)

        End If

    End Sub
#End Region

End Class
