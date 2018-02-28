'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】生産入庫設定子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region
Public Class FRM_310011
#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrFTRK_BUF_NO As String                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.

    Private mstrFTRK_BUF_NO_Disp As String              '入庫ST
    Private mstrFHINMEI_CD As String                    '品名記号
    Private mstrFHINMEI As String                       '品名
    Private mstrXPROD_LINE As String                    '生産ﾗｲﾝNo.
    Private mstrXPROD_LINE_Disp As String               '生産ﾗｲﾝNo.(表示用)
    Private mintXPROGRESS As Integer                    '進捗状況
    Private mstrFEQ_ID As String                        '設備ID
    Private mintDSPGRID_DISPLAYINDEX As Integer         '表示順序

    Private mstrFARRIVE_DT As String                    '在庫発生日時
    Private mstrFIN_KUBUN As String                     '入庫区分
    Private mstrFIN_KUBUN_Disp As String                '入庫区分(表示用)
    Private mstrFHORYU_KUBUN As String                  '保留区分
    Private mstrFHORYU_KUBUN_Disp As String             '保留区分(表示用)
    Private mstrXKENSA_KUBUN As String                  '検査区分
    Private mstrXKENSA_KUBUN_Disp As String             '検査区分(表示用)
    Private mstrXKENPIN_KUBUN As String                 '検品区分
    Private mstrXKENPIN_KUBUN_Disp As String            '検品区分(表示用)
    Private mstrXMAKER_CD As String                     'ﾒｰｶｰｺｰﾄﾞ
    Private mstrXKINKYU_BUF_TO As String                '緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        IN_StartBtn_Click               '生産開始
        IN_EndBtn_Click                 '生産終了
        CancelBtn_Click                 'ｷｬﾝｾﾙ
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "

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

    '''''' =======================================
    '''''' <summary>入庫ST</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userFTRK_BUF_NO_Disp() As String
    ' ''    Get
    ' ''        Return mstrFTRK_BUF_NO_Disp
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrFTRK_BUF_NO_Disp = value
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
    '''''' <summary>生産ﾗｲﾝNo.</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userXPROD_LINE() As String
    ' ''    Get
    ' ''        Return mstrXPROD_LINE
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXPROD_LINE = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>生産ﾗｲﾝNo.(表示用)</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userXPROD_LINE_Disp() As String
    ' ''    Get
    ' ''        Return mstrXPROD_LINE_Disp
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXPROD_LINE_Disp = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>進捗状況</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userXPROGRESS() As Integer
    ' ''    Get
    ' ''        Return mintXPROGRESS
    ' ''    End Get
    ' ''    Set(ByVal value As Integer)
    ' ''        mintXPROGRESS = value
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
    '''''' <summary>在庫発生日時</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userFARRIVE_DT() As String
    ' ''    Get
    ' ''        Return mstrFARRIVE_DT
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrFARRIVE_DT = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>入庫区分</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userFIN_KUBUN() As Integer
    ' ''    Get
    ' ''        Return mintFIN_KUBUN
    ' ''    End Get
    ' ''    Set(ByVal value As Integer)
    ' ''        mintFIN_KUBUN = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>入庫区分(表示用)</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userFIN_KUBUN_Disp() As String
    ' ''    Get
    ' ''        Return mstrFIN_KUBUN_Disp
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrFIN_KUBUN_Disp = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>保留区分</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userFHORYU_KUBUN() As Integer
    ' ''    Get
    ' ''        Return mintFHORYU_KUBUN
    ' ''    End Get
    ' ''    Set(ByVal value As Integer)
    ' ''        mintFHORYU_KUBUN = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>保留区分(表示用)</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userFHORYU_KUBUN_Disp() As String
    ' ''    Get
    ' ''        Return mstrFHORYU_KUBUN_Disp
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrFHORYU_KUBUN_Disp = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>検査区分</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userXKENSA_KUBUN() As String
    ' ''    Get
    ' ''        Return mstrXKENSA_KUBUN
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXKENSA_KUBUN = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>検査区分(表示用)</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userXKENSA_KUBUN_Disp() As String
    ' ''    Get
    ' ''        Return mstrXKENSA_KUBUN_Disp
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXKENSA_KUBUN_Disp = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>検品区分</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userXKENPIN_KUBUN() As String
    ' ''    Get
    ' ''        Return mstrXKENPIN_KUBUN
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXKENPIN_KUBUN = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>検品区分(表示用)</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userXKENPIN_KUBUN_Disp() As String
    ' ''    Get
    ' ''        Return mstrXKENPIN_KUBUN_Disp
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXKENPIN_KUBUN_Disp = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>ﾒｰｶｰｺｰﾄﾞ</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userXMAKER_CD() As String
    ' ''    Get
    ' ''        Return mstrXMAKER_CD
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXMAKER_CD = value
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
    Private Sub FRM_310011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub FRM_310011_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　生産開始   　ﾎﾞﾀﾝ押下                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdIN_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIN_Start.Click
        Try

            Call cmdIN_Start_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　生産終了   　ﾎﾞﾀﾝ押下                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdIN_End_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIN_End.Click
        Try

            Call cmdIN_End_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ      　ﾎﾞﾀﾝ押下                    "
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
#Region "　生産ﾗｲﾝNo.   選択処理                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cboXPROD_LINE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboXPROD_LINE.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then
                '===================================
                ' 生産ﾗｲﾝNo. ﾃﾞﾌｫﾙﾄ値 取得
                '===================================
                If cboXPROD_LINE.Text <> "" Then
                    Call GetDefault_XPROD_LINE(cboXPROD_LINE.Text)
                End If

            End If

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                               "
    '*******************************************************************************************************************
    '【機能】ﾌｫｰﾑｱｸﾃｨﾌﾞ時ｲﾍﾞﾝﾄ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_310011_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
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
        '生産入庫設定状態取得
        '===================================
        Dim strSQL As String                        'SQL文
        Dim objRow As DataRow                       '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet               'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "       XSTS_PRODUCT_IN.FTRK_BUF_NO"                 '生産入庫設定状態      .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        strSQL &= vbCrLf & "     , TMST_TRK.FBUF_NAME"                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ       .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(表示用)
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FHINMEI_CD "                 '生産入庫設定状態      .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                          '品目ﾏｽﾀ               .品名
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XPROD_LINE"                  '生産入庫設定状態      .生産ﾗｲﾝNo.
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XPROGRESS "                  '生産入庫設定状態      .進捗状態
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FEQ_ID "                     '生産入庫設定状態      .設備ID
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FGRID_DISPLAYINDEX "         '生産入庫設定状態      .ｸﾞﾘｯﾄﾞ列表示順序
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FARRIVE_DT "                 '生産入庫設定状態      .在庫発生日時
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XMAKER_CD "                  '生産入庫設定状態      .ﾒｰｶｰｺｰﾄﾞ
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XKENSA_KUBUN "               '生産入庫設定状態      .検査区分
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FHORYU_KUBUN "               '生産入庫設定状態      .保留区分
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FIN_KUBUN "                  '生産入庫設定状態      .入庫区分
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XKENPIN_KUBUN "              '生産入庫設定状態      .検品区分
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XKINKYU_BUF_TO "             '生産入庫設定状態      .緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_PRODUCT_IN "                               '【生産入庫設定状態】
        strSQL &= vbCrLf & "  , TMST_TRK "                                      '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ】
        strSQL &= vbCrLf & "  , TMST_ITEM "                                     '【品目ﾏｽﾀ】

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        XSTS_PRODUCT_IN.FTRK_BUF_NO = '" & mstrFTRK_BUF_NO & "' "       '生産入庫設定状態 を ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo. で特定
        strSQL &= vbCrLf & "    AND XSTS_PRODUCT_IN.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "    AND XSTS_PRODUCT_IN.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XSTS_PRODUCT_IN"
        gobjDb.GetDataSet(strDataSetName, objDataSet)


        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                mstrFTRK_BUF_NO_Disp = TO_STRING(objRow("FBUF_NAME"))                       '入庫ST
                mstrFHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))                            '品名記号
                mstrFHINMEI = TO_STRING(objRow("FHINMEI"))                                  '品名
                mstrXPROD_LINE = TO_STRING(objRow("XPROD_LINE"))                            '生産ﾗｲﾝNo.
                mintXPROGRESS = TO_STRING(objRow("XPROGRESS"))                              '進捗状況
                mstrFEQ_ID = TO_STRING(objRow("FEQ_ID"))                                    '設備ID
                mintDSPGRID_DISPLAYINDEX = TO_STRING(objRow("FGRID_DISPLAYINDEX"))          '表示順序
                mstrFARRIVE_DT = TO_STRING(objRow("FARRIVE_DT"))                            '在庫発生日時
                mstrFIN_KUBUN = TO_STRING(objRow("FIN_KUBUN"))                              '入庫区分
                mstrFHORYU_KUBUN = TO_STRING(objRow("FHORYU_KUBUN"))                        '保留区分
                mstrXKENSA_KUBUN = TO_STRING(objRow("XKENSA_KUBUN"))                        '検査区分
                mstrXKENPIN_KUBUN = TO_STRING(objRow("XKENPIN_KUBUN"))                      '検品区分
                mstrXMAKER_CD = TO_STRING(objRow("XMAKER_CD"))                              'ﾒｰｶｰｺｰﾄﾞ
                mstrXKINKYU_BUF_TO = TO_STRING(objRow("XKINKYU_BUF_TO"))                    '緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№

            Next
        End If



        '===================================
        '入庫ST ｾｯﾄ
        '===================================
        lblIN_ST.Text = mstrFTRK_BUF_NO_Disp

        '===================================
        '進捗状態の確認
        '===================================
        If mintXPROGRESS = XPROGRESS_NON Then
            '(未登録の場合)

            '===================================
            '品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
            '===================================
            cboFHINMEI_CD.conn = gobjDb
            cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
            cboFHINMEI_CD.Text = ""
            cboFHINMEI_CD.HinmeiVisible = False
            cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)

            '===================================
            '生産ﾗｲﾝNo.ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
            '===================================
            Call gobjComFuncFRM.cboMsterSetup("XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", cboXPROD_LINE, False, -1)

            '' ''===================================
            '' ''生産開始
            '' ''===================================
            ' ''cmdIN_Start.Enabled = True
            ' ''cmdIN_End.Enabled = False

            '===================================
            '在庫発生日時  ｾｯﾄ
            '===================================
            Dim dtmNow As Date = Now            '現在日時
            dtpFARRIVE_DT.cmpMDateTimePicker_D.Value = dtmNow
            dtpFARRIVE_DT.userChecked = False

            '===================================
            'ﾒｰｶｰｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
            '===================================
            Call cboXMAKER_CD_Setup(cboXMAKER_CD)

            '===================================
            '検査区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
            '===================================
            Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXKENSA_KUBUN, False)

            '===================================
            '保留区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
            '===================================
            Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFHORYU_KUBUN, False)

            '===================================
            '入庫区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
            '===================================
            Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFIN_KUBUN, False)

            '===================================
            '検品区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
            '===================================
            Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXKENPIN_KUBUN, False)

            '' ''===================================
            '' '' 生産ﾗｲﾝNo. ﾃﾞﾌｫﾙﾄ値 設定
            '' ''===================================
            ' ''Call GetDefault_XPROD_LINE(cboXPROD_LINE.Text)


        ElseIf mintXPROGRESS = XPROGRESS_START Then
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
            '生産ﾗｲﾝNo.ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
            '===================================
            If mstrXPROD_LINE <> "" Then
                cboXPROD_LINE.Items.Add(mstrXPROD_LINE)
                cboXPROD_LINE.SelectedIndex = 0
            End If
            cboXPROD_LINE.Enabled = False

            ' ''===================================
            ' ''生産終了
            ' ''===================================
            ''cmdIN_Start.Enabled = False
            ''cmdIN_End.Enabled = True

            '===================================
            '在庫発生日時  ｾｯﾄ
            '===================================
            If mstrFARRIVE_DT <> "" Then
                '(設定有り)
                Dim dtmArrive As Date = mstrFARRIVE_DT
                dtpFARRIVE_DT.cmpMDateTimePicker_D.Value = Format(dtmArrive, "yyyy/MM/dd HH:mm:ss")
                dtpFARRIVE_DT.cmpMDateTimePicker_T.Value = Format(dtmArrive, "yyyy/MM/dd HH:mm:ss")
                dtpFARRIVE_DT.Enabled = False
            Else
                '(設定なし)
                dtpFARRIVE_DT.userChecked = False
                dtpFARRIVE_DT.Enabled = False
            End If

            '===================================
            'ﾒｰｶｰｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
            '===================================
            Call cboXMAKER_CD_Setup(cboXMAKER_CD)
            If mstrXMAKER_CD <> "" Then
                cboXMAKER_CD.Text = mstrXMAKER_CD
            End If
            cboXMAKER_CD.Enabled = False

            '===================================
            '検査区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
            '===================================
            Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXKENSA_KUBUN, False, mstrXKENSA_KUBUN)
            cboXKENSA_KUBUN.Enabled = False

            '===================================
            '保留区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
            '===================================
            Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFHORYU_KUBUN, False, mstrFHORYU_KUBUN)
            cboFHORYU_KUBUN.Enabled = False

            '===================================
            '入庫区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
            '===================================
            Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFIN_KUBUN, False, mstrFIN_KUBUN)
            cboFIN_KUBUN.Enabled = False

            '===================================
            '検品区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
            '===================================
            Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXKENPIN_KUBUN, False, mstrXKENPIN_KUBUN)
            cboXKENPIN_KUBUN.Enabled = False

        ElseIf mintXPROGRESS = XPROGRESS_END Then
            '(終了済の場合)

            '===================================
            '品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
            '===================================
            cboFHINMEI_CD.conn = gobjDb
            cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
            cboFHINMEI_CD.Text = ""
            cboFHINMEI_CD.HinmeiVisible = False
            cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)

            '===================================
            '生産ﾗｲﾝNo.ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
            '===================================
            Call gobjComFuncFRM.cboMsterSetup("XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", cboXPROD_LINE, False, -1)

            ' ''===================================
            ' ''生産開始
            ' ''===================================
            ''cmdIN_Start.Enabled = True
            ''cmdIN_End.Enabled = False

            '===================================
            '在庫発生日時  ｾｯﾄ
            '===================================
            Dim dtmNow As Date = Now            '現在日時
            dtpFARRIVE_DT.cmpMDateTimePicker_D.Value = dtmNow
            dtpFARRIVE_DT.userChecked = False

            '===================================
            'ﾒｰｶｰｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
            '===================================
            Call cboXMAKER_CD_Setup(cboXMAKER_CD)

            '===================================
            '検索区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
            '===================================
            Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXKENSA_KUBUN, False)

            '===================================
            '保留区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
            '===================================
            Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFHORYU_KUBUN, False)

            '===================================
            '入庫区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
            '===================================
            Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFIN_KUBUN, False)

            '===================================
            '検品区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
            '===================================
            Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXKENPIN_KUBUN, False)

            '' ''===================================
            '' '' 生産ﾗｲﾝNo. ﾃﾞﾌｫﾙﾄ値 取得
            '' ''===================================
            ' ''Call GetDefault_XPROD_LINE(cboXPROD_LINE.Text)

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


    End Sub
#End Region
#Region "　生産開始        ﾎﾞﾀﾝ押下処理             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 生産開始 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdIN_Start_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.IN_StartBtn_Click) = False Then
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
#Region "　生産終了        ﾎﾞﾀﾝ押下処理             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 生産終了 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdIN_End_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.IN_EndBtn_Click) = False Then
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
#Region "　ｷｬﾝｾﾙ           ﾎﾞﾀﾝ押下処理             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.CancelBtn_Click) = False Then
            Exit Sub
        End If

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
            Case menmCheckCase.IN_StartBtn_Click
                '(生産開始の場合)

                '========================================
                '進捗状況
                '========================================
                If mintXPROGRESS = XPROGRESS_START Then
                    '（開始状態の場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM310011_01, _
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

                '========================================
                '生産ﾗｲﾝ№
                '========================================
                If cboXPROD_LINE.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_XPROD_LINE, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '検査区分
                '========================================
                If cboXKENSA_KUBUN.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_XKENSA_KUBUN, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '入庫区分
                '========================================
                If cboFIN_KUBUN.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FIN_KUBUN, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '保留区分
                '========================================
                If cboFHORYU_KUBUN.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHORYU_KUBUN, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '検品区分
                '========================================
                If cboXKENPIN_KUBUN.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_XKENPIN_KUBUN, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If


                blnCheckErr = False

            Case menmCheckCase.IN_EndBtn_Click
                '(生産終了の場合)

                '========================================
                '進捗状況
                '========================================
                If mintXPROGRESS = XPROGRESS_NON Or mintXPROGRESS = XPROGRESS_END Then
                    '（終了状態の場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM310011_02, _
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

#Region "  ｿｹｯﾄ送信(生産入庫開始)                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信(生産入庫開始)
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
        strMessage &= "生産入庫を開始" & FRM_MSG_FRM200000_01
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

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400002    'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", mstrFTRK_BUF_NO)                                'ﾊﾞｯﾌｧNo.
        objTelegram.SETIN_DATA("DSPEQ_ID", mstrFEQ_ID)                                          '設備ID
        objTelegram.SETIN_DATA("XDSPPROD_LINE", TO_STRING(cboXPROD_LINE.SelectedValue))         '生産ﾗｲﾝNo. 
        objTelegram.SETIN_DATA("DSPHINMEI_CD", DSPHINMEI_CD)                                    '品名ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPSTART_DT", Format(datNow, "yyyy/MM/dd HH:mm:ss"))           '開始日時
        objTelegram.SETIN_DATA("XDSPEND_DT", "")                                                '終了日時
        objTelegram.SETIN_DATA("XDSPPROGRESS", TO_STRING(XPROGRESS_START))                      '進捗状況
        objTelegram.SETIN_DATA("DSPGRID_DISPLAYINDEX", TO_STRING(mintDSPGRID_DISPLAYINDEX))     '表示順序
        If dtpFARRIVE_DT.userDispChecked = True Then                                            '在庫発生日時
            '(選択有り)
            objTelegram.SETIN_DATA("DSPARRIVE_DT", dtpFARRIVE_DT.userDateTimeText)
        Else
            '(選択なし)
            objTelegram.SETIN_DATA("DSPARRIVE_DT", "")
        End If
        objTelegram.SETIN_DATA("DSPIN_KUBUN", TO_STRING(cboFIN_KUBUN.SelectedValue))            '入庫区分
        objTelegram.SETIN_DATA("DSPHORYU_KUBUN", TO_STRING(cboFHORYU_KUBUN.SelectedValue))      '保留区分
        objTelegram.SETIN_DATA("XDSPKENSA_KUBUN", TO_STRING(cboXKENSA_KUBUN.SelectedValue))     '検査区分
        objTelegram.SETIN_DATA("XDSPKENPIN_KUBUN", TO_STRING(cboXKENPIN_KUBUN.SelectedValue))   '検品区分
        objTelegram.SETIN_DATA("XDSPMAKER_CD", cboXMAKER_CD.Text)                               'ﾒｰｶｰｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPKINKYU_BUF_TO", mstrXKINKYU_BUF_TO)                         '緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        objTelegram.SETIN_DATA("XDSPRESULT_NUM", "0")                                           '緊急時実績数
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
        objTelegram.SETIN_DATA("XDSPRESULT_NUM_CASE", "0")                                      '緊急時実績数(梱数)
        'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
        '↑↑↑↑↑↑************************************************************************************************************


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
#Region "  ｿｹｯﾄ送信(生産入庫終了)                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信(生産入庫終了)
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
        strMessage &= "生産入庫を終了" & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim datNow As Date = DateTime.Now

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400002    'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", mstrFTRK_BUF_NO)                            'ﾊﾞｯﾌｧNo.
        objTelegram.SETIN_DATA("DSPEQ_ID", mstrFEQ_ID)                                      '設備ID
        objTelegram.SETIN_DATA("XDSPPROD_LINE", "")                                         '生産ﾗｲﾝNo. 
        objTelegram.SETIN_DATA("DSPHINMEI_CD", "")                                          '品名ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPSTART_DT", "")                                          '開始日時
        objTelegram.SETIN_DATA("XDSPEND_DT", Format(datNow, "yyyy/MM/dd HH:mm:ss"))         '終了日時
        objTelegram.SETIN_DATA("XDSPPROGRESS", TO_STRING(XPROGRESS_END))                    '進捗状況
        objTelegram.SETIN_DATA("DSPGRID_DISPLAYINDEX", TO_STRING(mintDSPGRID_DISPLAYINDEX)) '表示順序
        objTelegram.SETIN_DATA("DSPARRIVE_DT", "")                                          '在庫発生日時
        objTelegram.SETIN_DATA("DSPIN_KUBUN", "")                                           '入庫区分
        objTelegram.SETIN_DATA("DSPHORYU_KUBUN", "")                                        '保留区分
        objTelegram.SETIN_DATA("XDSPKENSA_KUBUN", "")                                       '検査区分
        objTelegram.SETIN_DATA("XDSPKENPIN_KUBUN", "")                                      '検品区分
        objTelegram.SETIN_DATA("XDSPMAKER_CD", "")                                          'ﾒｰｶｰｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPKINKYU_BUF_TO", mstrXKINKYU_BUF_TO)                     '緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        objTelegram.SETIN_DATA("XDSPRESULT_NUM", "")                                        '緊急時実績数
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
        objTelegram.SETIN_DATA("XDSPRESULT_NUM_CASE", "")                                   '緊急時実績数(梱数)
        'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
        '↑↑↑↑↑↑************************************************************************************************************

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

#Region "　生産ﾗｲﾝNo. ﾃﾞﾌｫﾙﾄ値 取得             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 生産ﾗｲﾝNo. ﾃﾞﾌｫﾙﾄ値 取得
    ''' </summary>
    ''' <param name="XPROD_LINE">生産ﾗｲﾝNo.</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub GetDefault_XPROD_LINE(ByVal XPROD_LINE As String)

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
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     XMST_PROD_LINE.FIN_KUBUN "                         '生産ﾗｲﾝﾏｽﾀ     .入庫区分
        strSQL &= vbCrLf & "   , XMST_PROD_LINE.FHINMEI_CD "                        '生産ﾗｲﾝﾏｽﾀ     .品名記号
        strSQL &= vbCrLf & "   , XMST_PROD_LINE.XPROD_LINE "                        '生産ﾗｲﾝﾏｽﾀ     .生産ﾗｲﾝNo.
        '(From句)
        strSQL &= vbCrLf & " FROM   "
        strSQL &= vbCrLf & "     XMST_PROD_LINE "                                        '【生産ﾗｲﾝﾏｽﾀ】
        '(Where句)
        strSQL &= vbCrLf & " WHERE  "
        strSQL &= vbCrLf & "     XMST_PROD_LINE.XPROD_LINE = '" & XPROD_LINE & "' "

        '********************************************************************
        ' 実行
        '********************************************************************
        gobjDb.SQL = strSQL

        objDataSet.Clear()
        gobjDb.GetDataSet("XMST_PROD_LINE", objDataSet)

        If objDataSet.Tables("XMST_PROD_LINE").Rows.Count >= 0 Then
            '(ﾃﾞﾌｫﾙﾄ値が取得できた場合)
            Dim intFIN_KUBUN As Integer
            intFIN_KUBUN = TO_STRING(objDataSet.Tables("XMST_PROD_LINE").Rows(0).Item("FIN_KUBUN"))
            cboFIN_KUBUN.SelectedValue = intFIN_KUBUN

            If cboFHINMEI_CD.Text = "" Then
                '(未入力時)
                Dim strFHINMEI_CD As String
                strFHINMEI_CD = TO_STRING(objDataSet.Tables("XMST_PROD_LINE").Rows(0).Item("FHINMEI_CD"))
                If strFHINMEI_CD <> "" Then
                    cboFHINMEI_CD.SelectedValue = TO_STRING(strFHINMEI_CD)
                End If
            End If
        End If

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
