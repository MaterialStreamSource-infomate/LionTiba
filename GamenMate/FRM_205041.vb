'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】在庫ﾒﾝﾃﾅﾝｽ子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_205041

#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mintButtonMode As Integer                 'ﾎﾞﾀﾝﾓｰﾄﾞ
    Protected mstrFTRK_BUF_NO As String                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Protected mstrFTRK_BUF_ARRAY As String              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
    Protected mstrFPALLET_ID As String                  'ﾊﾟﾚｯﾄID
    Protected mstrFLOT_NO_STOCK As String               '在庫ﾛｯﾄ№

    Private mstrFHINMEI_CD As String                    '品名ｺｰﾄﾞ

    'ﾃｰﾌﾞﾙｸﾗｽ
    Dim mobjTRST_STOCK As TBL_TRST_STOCK        '在庫情報
    Dim mobjTPRG_TRK_BUF As TBL_TPRG_TRK_BUF    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    Dim mobjTMST_TRK As TBL_TMST_TRK            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ


#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' =======================================
    ''' <summary>ﾎﾞﾀﾝﾓｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userButtonMode() As Integer
        Get
            Return mintButtonMode
        End Get
        Set(ByVal Value As Integer)
            mintButtonMode = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</summary>
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
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFTRK_BUF_ARRAY() As String
        Get
            Return mstrFTRK_BUF_ARRAY
        End Get
        Set(ByVal value As String)
            mstrFTRK_BUF_ARRAY = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾊﾟﾚｯﾄID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFPALLET_ID() As String
        Get
            Return mstrFPALLET_ID
        End Get
        Set(ByVal value As String)
            mstrFPALLET_ID = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>在庫ﾛｯﾄ№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFLOT_NO_STOCK() As String
        Get
            Return mstrFLOT_NO_STOCK
        End Get
        Set(ByVal value As String)
            mstrFLOT_NO_STOCK = value
        End Set
    End Property

#End Region
#Region "　ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_205041_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub FRM_205041_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  実行ﾎﾞﾀﾝｸﾘｯｸ                             "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdZikkou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZikkou.Click
        Try

            Call cmdZikkou_ClickProcess()

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

        Dim strFREASON_KUBUN As String = ""      '作業種別

        '**********************************************************
        ' 在庫情報の特定
        '**********************************************************
        mobjTRST_STOCK = New TBL_TRST_STOCK(gobjOwner, gobjDb, Nothing)
        If IsNull(mstrFPALLET_ID) = False Then
            '(ﾊﾟﾚｯﾄIDある場合）
            mobjTRST_STOCK.FPALLET_ID = mstrFPALLET_ID                 'ﾊﾟﾚｯﾄID

            mobjTRST_STOCK.FLOT_NO_STOCK = mstrFLOT_NO_STOCK           '在庫ﾛｯﾄ№

            If mobjTRST_STOCK.GET_TRST_STOCK_COUNT < 2 Then
                '(複数件なければ)
                mobjTRST_STOCK.GET_TRST_STOCK(False)
            End If
        End If


        '**********************************************************
        ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
        '**********************************************************
        mobjTPRG_TRK_BUF = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
        mobjTPRG_TRK_BUF.FTRK_BUF_NO = mstrFTRK_BUF_NO           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        mobjTPRG_TRK_BUF.FTRK_BUF_ARRAY = mstrFTRK_BUF_ARRAY     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        mobjTPRG_TRK_BUF.GET_TPRG_TRK_BUF(False)


        '**********************************************************
        ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀの特定
        '**********************************************************
        mobjTMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
        mobjTMST_TRK.FTRK_BUF_NO = mstrFTRK_BUF_NO           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        mobjTMST_TRK.GET_TMST_TRK(False)


        '**********************************************************
        ' 実行ﾎﾞﾀﾝ                  ｾｯﾄ
        '**********************************************************
        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)
                cmdZikkou.Text = "追加"
            Case BUTTONMODE_UPDATE
                '(変更の場合)
                cmdZikkou.Text = "変更"
            Case BUTTONMODE_DELETE
                '(削除の場合)
                cmdZikkou.Text = "削除"
        End Select


        '**********************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        '===================================
        ' 引当状態ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboFRES_KIND, False, mobjTPRG_TRK_BUF.FRES_KIND)

        '===================================
        ' 禁止設定ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboFREMOVE_KIND, False, mobjTPRG_TRK_BUF.FREMOVE_KIND)

        '===================================
        ' 棚形状種別ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboFRAC_FORM, True, mobjTPRG_TRK_BUF.FRAC_FORM)

        '===================================
        ' 棚ﾌﾞﾛｯｸ状態ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboXTANA_BLOCK_STS, False, mobjTPRG_TRK_BUF.XTANA_BLOCK_STS)


        '===================================
        ' 品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = mobjTRST_STOCK.FHINMEI_CD
        cboFHINMEI_CD.HinmeiVisible = False
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)

        '===================================
        ' 入庫区分ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboFIN_KUBUN, True, mobjTRST_STOCK.FIN_KUBUN)

        '===================================
        ' 保留区分ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboFHORYU_KUBUN, True, mobjTRST_STOCK.FHORYU_KUBUN)

        '===================================
        ' 搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(Me.Name, Me.cboFST_FM, True, mobjTRST_STOCK.FST_FM)

        '===================================
        ' 生産ﾗｲﾝ№ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboMsterSetup("XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", cboXPROD_LINE, True, mobjTRST_STOCK.XPROD_LINE)

        '===================================
        ' ﾒｰｶｰｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call cboXMAKER_CD_Setup(cboXMAKER_CD, True, mobjTRST_STOCK.XMAKER_CD)

        '===================================
        ' 検査区分ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboXKENSA_KUBUN, True, mobjTRST_STOCK.XKENSA_KUBUN)

        '===================================
        ' 検品区分ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboXKENPIN_KUBUN, True, mobjTRST_STOCK.XKENPIN_KUBUN)


        '**********************************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ                 ｾｯﾄ
        '**********************************************************
        lblFRAC_RETU.Text = TO_STRING(mobjTPRG_TRK_BUF.FRAC_RETU)               '列
        lblFRAC_REN.Text = TO_STRING(mobjTPRG_TRK_BUF.FRAC_REN)                 '連
        lblFRAC_DAN.Text = TO_STRING(mobjTPRG_TRK_BUF.FRAC_DAN)                 '段
        lblFRAC_EDA.Text = TO_STRING(mobjTPRG_TRK_BUF.FRAC_EDA)                 '段

        txtFRAC_BUNRUI.Text = TO_STRING(mobjTPRG_TRK_BUF.FRAC_BUNRUI)           '棚分類
        txtXTANA_BLOCK.Text = TO_STRING(mobjTPRG_TRK_BUF.XTANA_BLOCK)           '棚ﾌﾞﾛｯｸ
        txtXTANA_BLOCK_DTL.Text = TO_STRING(mobjTPRG_TRK_BUF.XTANA_BLOCK_DTL)   '棚ﾌﾞﾛｯｸ詳細
        txtFLOT_NO.Text = TO_STRING(mobjTRST_STOCK.FLOT_NO)                     'ﾛｯﾄ№

        '数量
        If IsNull(mobjTRST_STOCK.FTR_VOL) = False Then
            '(入力ある場合)
            txtFTR_VOL.Value = TO_STRING(TO_DECIMAL(mobjTRST_STOCK.FTR_VOL))
        Else
            txtFTR_VOL.Value = ""
        End If


        '**********************************************************
        ' 日付型ﾃｷｽﾄﾎﾞｯｸｽ           ｾｯﾄ
        '**********************************************************
        '===================================
        'ﾊﾞｯﾌｧ入日時
        '===================================
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/03 在庫発生日時
        If IsNull(mobjTRST_STOCK.XRAC_IN_DT) = True Then
            '(値がない場合)
            dtpXRAC_IN_DT.cmpMDateTimePicker_D.Value = Now
            dtpXRAC_IN_DT.cmpMDateTimePicker_T.Value = Now
        Else
            '(値がある場合)
            dtpXRAC_IN_DT.cmpMDateTimePicker_D.Value = mobjTRST_STOCK.XRAC_IN_DT
            dtpXRAC_IN_DT.cmpMDateTimePicker_T.Value = mobjTRST_STOCK.XRAC_IN_DT
        End If
        'If IsNull(mobjTPRG_TRK_BUF.FBUF_IN_DT) = True Then
        '    '(値がない場合)
        '    dtpFBUF_IN_DT.cmpMDateTimePicker_D.Value = Now
        '    dtpFBUF_IN_DT.cmpMDateTimePicker_T.Value = Now
        'Else
        '    '(値がある場合)
        '    dtpFBUF_IN_DT.cmpMDateTimePicker_D.Value = mobjTPRG_TRK_BUF.FBUF_IN_DT
        '    dtpFBUF_IN_DT.cmpMDateTimePicker_T.Value = mobjTPRG_TRK_BUF.FBUF_IN_DT
        'End If
        '↑↑↑↑↑↑************************************************************************************************************

        '===================================
        '在庫発生日時
        '===================================
        If IsNull(mobjTRST_STOCK.FARRIVE_DT) = True Then
            '(値がない場合)
            dtpFARRIVE_DT.cmpMDateTimePicker_D.Value = Now
            dtpFARRIVE_DT.cmpMDateTimePicker_T.Value = Now
        Else
            '(値がある場合)

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:H.Okumura 2013/07/01 開始日時ﾁｪｯｸ
            Dim MinDate As Date
            MinDate = "1753/01/01 00:00:00"

            If mobjTRST_STOCK.FARRIVE_DT < MinDate Then
                dtpFARRIVE_DT.cmpMDateTimePicker_D.Value = Now
                dtpFARRIVE_DT.cmpMDateTimePicker_T.Value = Now
            Else
                dtpFARRIVE_DT.cmpMDateTimePicker_D.Value = mobjTRST_STOCK.FARRIVE_DT
                dtpFARRIVE_DT.cmpMDateTimePicker_T.Value = mobjTRST_STOCK.FARRIVE_DT
            End If

            '↑↑↑↑↑↑************************************************************************************************************

            ''dtpFARRIVE_DT.cmpMDateTimePicker_D.Value = mobjTRST_STOCK.FARRIVE_DT
            ''dtpFARRIVE_DT.cmpMDateTimePicker_T.Value = mobjTRST_STOCK.FARRIVE_DT
        End If

        '**********************************************************
        ' ｺﾝﾄﾛｰﾙﾏｽｸ処理
        '**********************************************************
        Call ControlEnable()


        '**********************************************************
        ' ｺﾝﾄﾛｰﾙ初期化
        '**********************************************************
        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)

                txtFTR_VOL.Text = ""                                    '搬送管理量(数量)
                dtpFARRIVE_DT.cmpMDateTimePicker_D.Value = Now          '在庫発生日時
                dtpFARRIVE_DT.cmpMDateTimePicker_T.Value = Now          '在庫発生日時
                dtpXRAC_IN_DT.cmpMDateTimePicker_D.Value = Now          'ﾊﾞｯﾌｧ入日時
                dtpXRAC_IN_DT.cmpMDateTimePicker_T.Value = Now          'ﾊﾞｯﾌｧ入日時

            Case BUTTONMODE_UPDATE
                '(変更の場合）

                If TO_STRING(mobjTPRG_TRK_BUF.FRES_KIND) <> TO_STRING(FRES_KIND_SZAIKO) Then
                    '(在庫棚でなければ)
                    txtFTR_VOL.Text = ""                                    '搬送管理量(数量)
                    dtpFARRIVE_DT.cmpMDateTimePicker_D.Value = Now          '在庫発生日時
                    dtpFARRIVE_DT.cmpMDateTimePicker_T.Value = Now          '在庫発生日時
                    dtpXRAC_IN_DT.cmpMDateTimePicker_D.Value = Now          'ﾊﾞｯﾌｧ入日時
                    dtpXRAC_IN_DT.cmpMDateTimePicker_T.Value = Now          'ﾊﾞｯﾌｧ入日時

                End If

        End Select



        If TO_INTEGER(mobjTMST_TRK.FBUF_KIND) <> FBUF_KIND_SASRS Then
            '(倉庫以外の場合)
            cboFREMOVE_KIND.Enabled = False                         '禁止設定 操作不可
            cboFRAC_FORM.Enabled = False                            '棚形状種別 操作不可
        End If

        cmdCancel.Focus()

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
        cboFRES_KIND.Dispose()                              '引当状態
        cboFREMOVE_KIND.Dispose()                           '禁止設定
        cboFRAC_FORM.Dispose()                              '棚形状種別
        dtpXRAC_IN_DT.cmpMDateTimePicker_D.Dispose()        'ﾊﾞｯﾌｧ入日時
        dtpXRAC_IN_DT.cmpMDateTimePicker_T.Dispose()
        txtFRAC_BUNRUI.Dispose()                            '棚分類
        txtXTANA_BLOCK.Dispose()                            '棚ﾌﾞﾛｯｸ
        txtXTANA_BLOCK_DTL.Dispose()                        '棚ﾌﾞﾛｯｸ詳細
        cboXTANA_BLOCK_STS.Dispose()                        '棚ﾌﾞﾛｯｸ状態
        cboFHINMEI_CD.Dispose()                             '品名ｺｰﾄﾞ
        txtFLOT_NO.Dispose()                                'ﾛｯﾄ№
        txtFTR_VOL.Dispose()                                '数量
        dtpFARRIVE_DT.cmpMDateTimePicker_D.Dispose()        '在庫発生日時
        dtpFARRIVE_DT.cmpMDateTimePicker_T.Dispose()
        cboFIN_KUBUN.Dispose()                              '入庫区分
        cboFHORYU_KUBUN.Dispose()                           '保留区分
        cboFST_FM.Dispose()                                 '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        cboXPROD_LINE.Dispose()                             '生産ﾗｲﾝ№
        cboXKENSA_KUBUN.Dispose()                           '検査区分
        cboXKENPIN_KUBUN.Dispose()                          '検品区分


    End Sub
#End Region
#Region "  実行         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 実行         ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_ClickProcess()

        '********************************************************************
        ' 品名記号取得
        '********************************************************************
        If cboFHINMEI_CD.Text <> "" Then

            If IsNumeric(cboFHINMEI_CD.Text.Substring(0, 1)) Then
                '(品名ｺｰﾄﾞの場合)
                Dim intRet As Integer
                Dim objTBL_TMST_ITEM As TBL_TMST_ITEM
                objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                objTBL_TMST_ITEM.XHINMEI_CD = cboFHINMEI_CD.Text
                intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
                If intRet = RetCode.OK Then
                    '(値がある時)
                    mstrFHINMEI_CD = objTBL_TMST_ITEM.FHINMEI_CD        '品名記号
                End If

            Else
                '(品名記号の場合)
                mstrFHINMEI_CD = cboFHINMEI_CD.Text
            End If
        End If

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck() = False Then

            Exit Sub
        End If


        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        Call SendSocket01()


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
    Protected Overridable Function InputCheck() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Dim intRet As RetCode
        Dim strMsg As String = ""


        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)

                '========================================
                '入庫日時
                '========================================
                If dtpXRAC_IN_DT.userDateTimeText = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_26, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '品名ｺｰﾄﾞ
                '========================================
                If cboFHINMEI_CD.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_03, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                Dim strFHINMEI As String = ""
                Dim decFNUM_IN_PALLET As Decimal = 0

                Dim objTMST_ITEM As TBL_TMST_ITEM                       '品目ﾏｽﾀ
                objTMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                objTMST_ITEM.FHINMEI_CD = mstrFHINMEI_CD                 '品名ｺｰﾄﾞ
                intRet = objTMST_ITEM.GET_TMST_ITEM(False)

                If intRet = RetCode.OK Then
                    '(品名ｺｰﾄﾞ存在する時)
                    strFHINMEI = objTMST_ITEM.FHINMEI
                    decFNUM_IN_PALLET = objTMST_ITEM.FNUM_IN_PALLET
                Else
                    '(品名ｺｰﾄﾞが存在しない時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If


                '========================================
                'ﾛｯﾄ№
                '========================================
                If txtFLOT_NO.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_06, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If


                '' ''**********************************************************
                '' '' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
                '' ''**********************************************************
                ' ''Dim objTPRG_TRK_BUF_ARY As TBL_TPRG_TRK_BUF                                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                ' ''objTPRG_TRK_BUF_ARY = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
                ' ''objTPRG_TRK_BUF_ARY.XTANA_BLOCK = TO_STRING(txtXTANA_BLOCK.Text)            '棚ﾌﾞﾛｯｸ
                ' ''intRet = objTPRG_TRK_BUF_ARY.GET_TPRG_TRK_BUF_ANY
                ' ''If intRet = RetCode.OK Then
                ' ''    For Each objTPRG_TRK_BUF As TBL_TPRG_TRK_BUF In objTPRG_TRK_BUF_ARY.ARYME
                ' ''        '(ﾙｰﾌﾟ:取得した件数)

                ' ''        If IsNull(objTPRG_TRK_BUF.FPALLET_ID) = False Then
                ' ''            '(ﾊﾟﾚｯﾄIDがNULLでないとき)

                ' ''            '**********************************************************
                ' ''            ' 在庫情報の特定
                ' ''            '**********************************************************
                ' ''            Dim objTRST_STOCK As TBL_TRST_STOCK                                 '在庫情報
                ' ''            objTRST_STOCK = New TBL_TRST_STOCK(gobjOwner, gobjDb, Nothing)
                ' ''            objTRST_STOCK.FPALLET_ID = TO_STRING(objTPRG_TRK_BUF.FPALLET_ID)    'ﾊﾟﾚｯﾄID
                ' ''            intRet = objTRST_STOCK.GET_TRST_STOCK
                ' ''            If intRet = RetCode.OK Then

                ' ''                If Not (objTRST_STOCK.FHINMEI_CD = TO_STRING(cboFHINMEI_CD.Text) And _
                ' ''                   objTRST_STOCK.FLOT_NO = TO_STRING(txtFLOT_NO.Text)) Then
                ' ''                    '(品名ｺｰﾄﾞが異なる、かつﾛｯﾄ№が異なるとき)
                ' ''                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_24, _
                ' ''                                                     PopupFormType.Ok, _
                ' ''                                                     PopupIconType.Information)
                ' ''                    Exit Select

                ' ''                End If

                ' ''            End If

                ' ''        End If

                ' ''    Next

                ' ''End If


                '========================================
                '数量
                '========================================
                If (txtFTR_VOL.Value = "") Or (TO_DECIMAL(txtFTR_VOL.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FTR_VOL_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If
                If IsNumeric(txtFTR_VOL.Value) = False Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM200000_13 & vbCrLf & FRM_MSG_FTR_VOL_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                If TO_DECIMAL(txtFTR_VOL.Value) > decFNUM_IN_PALLET Then
                    '(PL毎積載数より大きい時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_07, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If


                If TO_DECIMAL(txtFTR_VOL.Value) < CHECK_VALUE_FTR_VOL_MIN Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM200000_12 & vbCrLf & FRM_MSG_FTR_VOL_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If
                If CHECK_VALUE_FTR_VOL_MAX < TO_DECIMAL(txtFTR_VOL.Value) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM200000_11 & vbCrLf & FRM_MSG_FTR_VOL_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '在庫発生日時
                '========================================
                If dtpFARRIVE_DT.userDateTimeText = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_27, _
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
                '生産ﾗｲﾝNo.
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


            Case BUTTONMODE_UPDATE
                '(変更の場合)

                If mintButtonMode = BUTTONMODE_UPDATE And mobjTPRG_TRK_BUF.FRES_KIND = FRES_KIND_SAKI Then
                    '(変更で空棚の場合)

                    '========================================
                    '棚形状種別 ﾁｪｯｸ
                    '========================================
                    If TO_INTEGER(mobjTMST_TRK.FBUF_KIND) = FBUF_KIND_SASRS Then
                        '(自動倉庫の時)
                        If TO_STRING(cboFRAC_FORM.SelectedValue.ToString) = "" Then
                            '(棚形状種別が選択されていないとき)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_18, _
                                              PopupFormType.Ok, _
                                              PopupIconType.Information)
                            Exit Select
                        End If
                    End If


                    '========================================
                    '棚分類
                    '========================================
                    If txtFRAC_BUNRUI.Text = "" Then
                        '（入力無しの場合）
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_25, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If


                    '========================================
                    '棚ﾌﾞﾛｯｸ
                    '========================================
                    If txtXTANA_BLOCK.Text = "" Then
                        '（入力無しの場合）
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_21, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If


                    '========================================
                    '棚ﾌﾞﾛｯｸ詳細
                    '========================================
                    If txtXTANA_BLOCK_DTL.Text = "" Then
                        '（入力無しの場合）
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_22, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If

                    '========================================
                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ 重複ﾁｪｯｸ
                    '========================================
                    If (mobjTPRG_TRK_BUF.XTANA_BLOCK = TO_STRING(txtXTANA_BLOCK.Text)) And _
                       (mobjTPRG_TRK_BUF.XTANA_BLOCK_DTL = TO_STRING(txtXTANA_BLOCK_DTL.Text)) Then
                        '(棚ﾌﾞﾛｯｸ、棚ﾌﾞﾛｯｸ詳細が変更ない時)
                    Else
                        '(棚ﾌﾞﾛｯｸ、棚ﾌﾞﾛｯｸ詳細のどれか変更ある時)
                        '**********************************************************
                        ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
                        '**********************************************************
                        Dim objTPRG_TRK_BUF As TBL_TPRG_TRK_BUF                                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                        objTPRG_TRK_BUF = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
                        objTPRG_TRK_BUF.XTANA_BLOCK = TO_STRING(txtXTANA_BLOCK.Text)            '棚ﾌﾞﾛｯｸ
                        objTPRG_TRK_BUF.XTANA_BLOCK_DTL = TO_STRING(txtXTANA_BLOCK_DTL.Text)    '棚ﾌﾞﾛｯｸ詳細
                        If objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_COUNT > 0 Then
                            '(存在した時)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_23, _
                                              PopupFormType.Ok, _
                                              PopupIconType.Information)
                            Exit Select
                        End If

                    End If

                Else
                    '(変更で在庫棚の場合)

                    '========================================
                    '入庫日時
                    '========================================
                    If dtpXRAC_IN_DT.userDateTimeText = "" Then
                        '（入力無しの場合）
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_26, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If

                    '========================================
                    '品名ｺｰﾄﾞ
                    '========================================
                    If cboFHINMEI_CD.Text = "" Then
                        '（入力無しの場合）
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_03, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If

                    Dim strFHINMEI_CD As String = TO_STRING(cboFHINMEI_CD.Text)
                    Dim strFHINMEI As String = ""
                    Dim decFNUM_IN_PALLET As Decimal = 0

                    Dim objTMST_ITEM As TBL_TMST_ITEM                       '品目ﾏｽﾀ
                    objTMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                    objTMST_ITEM.FHINMEI_CD = mstrFHINMEI_CD                 '品名ｺｰﾄﾞ
                    intRet = objTMST_ITEM.GET_TMST_ITEM(False)

                    If intRet = RetCode.OK Then
                        '(品名ｺｰﾄﾞ存在する時)
                        strFHINMEI = objTMST_ITEM.FHINMEI
                        decFNUM_IN_PALLET = objTMST_ITEM.FNUM_IN_PALLET
                    Else
                        '(品名ｺｰﾄﾞが存在しない時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_02, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If


                    '========================================
                    'ﾛｯﾄ№
                    '========================================
                    If txtFLOT_NO.Text = "" Then
                        '（入力無しの場合）
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_06, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If


                    '' ''========================================
                    '' ''在庫情報 重複ﾁｪｯｸ
                    '' ''========================================
                    ' ''If (mobjTRST_STOCK.FHINMEI_CD = TO_STRING(cboFHINMEI_CD.Text)) And _
                    ' ''   (mobjTRST_STOCK.FLOT_NO = TO_STRING(txtFLOT_NO.Text)) Then
                    ' ''    '(品名ｺｰﾄﾞ、ﾛｯﾄ№が変更ない時)
                    ' ''Else
                    ' ''    '(品名ｺｰﾄﾞ、ﾛｯﾄ№のどれか変更ある時)
                    ' ''    '**********************************************************
                    ' ''    ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
                    ' ''    '**********************************************************
                    ' ''    Dim objTPRG_TRK_BUF_ARY As TBL_TPRG_TRK_BUF                                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                    ' ''    objTPRG_TRK_BUF_ARY = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
                    ' ''    objTPRG_TRK_BUF_ARY.XTANA_BLOCK = TO_STRING(txtXTANA_BLOCK.Text)            '棚ﾌﾞﾛｯｸ
                    ' ''    intRet = objTPRG_TRK_BUF_ARY.GET_TPRG_TRK_BUF_ANY
                    ' ''    If intRet = RetCode.OK Then
                    ' ''        For Each objTPRG_TRK_BUF As TBL_TPRG_TRK_BUF In objTPRG_TRK_BUF_ARY.ARYME
                    ' ''            '(ﾙｰﾌﾟ:取得した件数)

                    ' ''            If objTPRG_TRK_BUF.XTANA_BLOCK_DTL <> TO_STRING(txtXTANA_BLOCK_DTL.Text) Then
                    ' ''                '(棚ﾌﾞﾛｯｸ詳細が異なるとき)

                    ' ''                If IsNull(objTPRG_TRK_BUF.FPALLET_ID) = False Then
                    ' ''                    '(ﾊﾟﾚｯﾄIDがNULLでないとき)

                    ' ''                    '**********************************************************
                    ' ''                    ' 在庫情報の特定
                    ' ''                    '**********************************************************
                    ' ''                    Dim objTRST_STOCK As TBL_TRST_STOCK                                 '在庫情報
                    ' ''                    objTRST_STOCK = New TBL_TRST_STOCK(gobjOwner, gobjDb, Nothing)
                    ' ''                    objTRST_STOCK.FPALLET_ID = TO_STRING(objTPRG_TRK_BUF.FPALLET_ID)    'ﾊﾟﾚｯﾄID
                    ' ''                    intRet = objTRST_STOCK.GET_TRST_STOCK
                    ' ''                    If intRet = RetCode.OK Then

                    ' ''                        If Not (objTRST_STOCK.FHINMEI_CD = TO_STRING(cboFHINMEI_CD.Text) And _
                    ' ''                           objTRST_STOCK.FLOT_NO = TO_STRING(txtFLOT_NO.Text)) Then
                    ' ''                            '(品名ｺｰﾄﾞが異なる、かつﾛｯﾄ№が異なるとき)
                    ' ''                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_24, _
                    ' ''                                                             PopupFormType.Ok, _
                    ' ''                                                             PopupIconType.Information)
                    ' ''                            Exit Select

                    ' ''                        End If

                    ' ''                    End If

                    ' ''                End If

                    ' ''            End If

                    ' ''        Next

                    ' ''    End If

                    ' ''End If


                    '========================================
                    '数量
                    '========================================
                    If (txtFTR_VOL.Value = "") Or (TO_DECIMAL(txtFTR_VOL.Value) = 0) Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FTR_VOL_MSG_01, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If
                    If IsNumeric(txtFTR_VOL.Value) = False Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM200000_13 & vbCrLf & FRM_MSG_FTR_VOL_MSG_01, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If


                    If TO_DECIMAL(txtFTR_VOL.Value) > decFNUM_IN_PALLET Then
                        '(PL毎積載数より大きい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_07, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If


                    If TO_DECIMAL(txtFTR_VOL.Value) < CHECK_VALUE_FTR_VOL_MIN Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM200000_12 & vbCrLf & FRM_MSG_FTR_VOL_MSG_01, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If
                    If CHECK_VALUE_FTR_VOL_MAX < TO_DECIMAL(txtFTR_VOL.Value) Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM200000_11 & vbCrLf & FRM_MSG_FTR_VOL_MSG_01, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If

                    '========================================
                    '在庫発生日時
                    '========================================
                    If dtpFARRIVE_DT.userDateTimeText = "" Then
                        '（入力無しの場合）
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205041_27, _
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
                    '生産ﾗｲﾝNo.
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
                    '検品区分
                    '========================================
                    If cboXKENPIN_KUBUN.Text = "" Then
                        '（入力無しの場合）
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_XKENPIN_KUBUN, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If

                End If


                blnCheckErr = False


            Case BUTTONMODE_DELETE
                '(削除の場合)

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
#Region "　ｺﾝﾄﾛｰﾙﾏｽｸ処理　                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾄﾛｰﾙﾏｽｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ControlEnable()

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)

                cboFRES_KIND.Enabled = False            '引当状態
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:H.Okumura 2013/05/17 禁止設定変更
                cboFREMOVE_KIND.Enabled = True         '禁止設定

                '↑↑↑↑↑↑************************************************************************************************************

                cboFRAC_FORM.Enabled = False            '棚形状種別
                dtpXRAC_IN_DT.Enabled = True            'ﾊﾞｯﾌｧ入日時
                txtFRAC_BUNRUI.Enabled = False           '棚分類
                txtXTANA_BLOCK.Enabled = False           '棚ﾌﾞﾛｯｸ
                txtXTANA_BLOCK_DTL.Enabled = False       '棚ﾌﾞﾛｯｸ詳細
                cboXTANA_BLOCK_STS.Enabled = True       '棚ﾌﾞﾛｯｸ状態
                cboFHINMEI_CD.Enabled = True            '品名ｺｰﾄﾞ
                txtFLOT_NO.Enabled = True               'ﾛｯﾄ№
                txtFTR_VOL.Enabled = True               '数量
                dtpFARRIVE_DT.Enabled = True            '在庫発生日時
                cboFIN_KUBUN.Enabled = True             '入庫区分
                cboFHORYU_KUBUN.Enabled = True          '保留区分
                cboFST_FM.Enabled = True                '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                cboXPROD_LINE.Enabled = True            '生産ﾗｲﾝ№
                cboXKENSA_KUBUN.Enabled = True          '検査区分
                cboXKENPIN_KUBUN.Enabled = True         '検品区分
                cboXMAKER_CD.Enabled = True             'ﾒｰｶｰｺｰﾄﾞ

                lblFBUF_IN_DT_VISIBLE.Visible = False           'ﾊﾞｯﾌｧ入日時(年月日)
                lblFBUF_IN_TM_VISIBLE.Visible = False           'ﾊﾞｯﾌｧ入日時(時間)
                lblFRAC_BUNRUI_VISIBLE.Visible = False          '棚分類
                lblXTANA_BLOCK_VISIBLE.Visible = False          '棚ﾌﾞﾛｯｸ
                lblXTANA_BLOCK_DTL_VISIBLE.Visible = False      '棚ﾌﾞﾛｯｸ詳細
                lblXTANA_BLOCK_STS_VISIBL.Visible = False       '棚ﾌﾞﾛｯｸ状態
                lblFHINMEI_CD_VISIBLE.Visible = False           '品名ｺｰﾄﾞ
                lblFLOT_NO_VISIBL.Visible = False               'ﾛｯﾄ№
                lblFTR_VOL_VISIBLE.Visible = False              '数量
                lblFARRIVE_DT_VISIBLE.Visible = False           '在庫発生日時(年月日)
                lblFARRIVE_TM_VISIBLE.Visible = False           '在庫発生日時(時間)
                lblFIN_KUBUN_VISIBLE.Visible = False            '入庫区分
                lblFHORYU_KUBUN_VISIBLE.Visible = False         '保留区分
                lblFST_FM_VISIBLE.Visible = False               '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                lblXPROD_LINE_VISIBLE.Visible = False           '生産ﾗｲﾝ№
                lblXKENSA_KUBUN_VISIBLE.Visible = False         '検査区分
                lblXKENPIN_KUBUN_VISIBLE.Visible = False        '検品区分
                lblXMAKER_CD_VISIBLE.Visible = False            'ﾒｰｶｰｺｰﾄﾞ

                Exit Select


            Case BUTTONMODE_UPDATE
                '(変更の場合)

                If (mobjTPRG_TRK_BUF.FRES_KIND = FRES_KIND_SAKI) Or _
                   (mobjTPRG_TRK_BUF.FRES_KIND = FRES_KIND_SRSV_TRNS_IN) Then
                    '(空棚、搬入予約の場合)

                    cboFRES_KIND.Enabled = False            '引当状態
                    cboFREMOVE_KIND.Enabled = True         '禁止設定
                    cboFRAC_FORM.Enabled = False            '棚形状種別
                    dtpXRAC_IN_DT.Enabled = False            'ﾊﾞｯﾌｧ入日時
                    txtFRAC_BUNRUI.Enabled = False           '棚分類
                    txtXTANA_BLOCK.Enabled = False           '棚ﾌﾞﾛｯｸ
                    txtXTANA_BLOCK_DTL.Enabled = False       '棚ﾌﾞﾛｯｸ詳細
                    cboXTANA_BLOCK_STS.Enabled = False       '棚ﾌﾞﾛｯｸ状態
                    cboFHINMEI_CD.Enabled = False            '品名ｺｰﾄﾞ
                    txtFLOT_NO.Enabled = False               'ﾛｯﾄ№
                    txtFTR_VOL.Enabled = False               '数量
                    dtpFARRIVE_DT.Enabled = False            '在庫発生日時
                    cboFIN_KUBUN.Enabled = False             '入庫区分
                    cboFHORYU_KUBUN.Enabled = False          '保留区分
                    cboFST_FM.Enabled = False                '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    cboXPROD_LINE.Enabled = False            '生産ﾗｲﾝ№
                    cboXKENSA_KUBUN.Enabled = False          '検査区分
                    cboXKENPIN_KUBUN.Enabled = False         '検品区分
                    cboXMAKER_CD.Enabled = False             'ﾒｰｶｰｺｰﾄﾞ

                    lblFBUF_IN_DT_VISIBLE.Visible = True           'ﾊﾞｯﾌｧ入日時(年月日)
                    lblFBUF_IN_TM_VISIBLE.Visible = True           'ﾊﾞｯﾌｧ入日時(時間)
                    lblFRAC_BUNRUI_VISIBLE.Visible = False          '棚分類
                    lblXTANA_BLOCK_VISIBLE.Visible = False          '棚ﾌﾞﾛｯｸ
                    lblXTANA_BLOCK_DTL_VISIBLE.Visible = False      '棚ﾌﾞﾛｯｸ詳細
                    lblXTANA_BLOCK_STS_VISIBL.Visible = True       '棚ﾌﾞﾛｯｸ状態
                    lblFHINMEI_CD_VISIBLE.Visible = True           '品名ｺｰﾄﾞ
                    lblFLOT_NO_VISIBL.Visible = True               'ﾛｯﾄ№
                    lblFTR_VOL_VISIBLE.Visible = True              '数量
                    lblFARRIVE_DT_VISIBLE.Visible = True           '在庫発生日時(年月日)
                    lblFARRIVE_TM_VISIBLE.Visible = True           '在庫発生日時(時間)
                    lblFIN_KUBUN_VISIBLE.Visible = True            '入庫区分
                    lblFHORYU_KUBUN_VISIBLE.Visible = True         '保留区分
                    lblFST_FM_VISIBLE.Visible = True               '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    lblXPROD_LINE_VISIBLE.Visible = True           '生産ﾗｲﾝ№
                    lblXKENSA_KUBUN_VISIBLE.Visible = True         '検査区分
                    lblXKENPIN_KUBUN_VISIBLE.Visible = True        '検品区分
                    lblXMAKER_CD_VISIBLE.Visible = True            'ﾒｰｶｰｺｰﾄﾞ

                Else
                    '(在庫棚の場合)

                    cboFRES_KIND.Enabled = False            '引当状態
                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:H.Okumura 2013/05/17 禁止設定変更
                    cboFREMOVE_KIND.Enabled = True         '禁止設定

                    '↑↑↑↑↑↑************************************************************************************************************
                    cboFRAC_FORM.Enabled = False            '棚形状種別
                    dtpXRAC_IN_DT.Enabled = True            'ﾊﾞｯﾌｧ入日時
                    txtFRAC_BUNRUI.Enabled = False           '棚分類
                    txtXTANA_BLOCK.Enabled = False           '棚ﾌﾞﾛｯｸ
                    txtXTANA_BLOCK_DTL.Enabled = False       '棚ﾌﾞﾛｯｸ詳細
                    cboXTANA_BLOCK_STS.Enabled = True       '棚ﾌﾞﾛｯｸ状態
                    cboFHINMEI_CD.Enabled = True            '品名ｺｰﾄﾞ
                    txtFLOT_NO.Enabled = True               'ﾛｯﾄ№
                    txtFTR_VOL.Enabled = True               '数量
                    dtpFARRIVE_DT.Enabled = True            '在庫発生日時
                    cboFIN_KUBUN.Enabled = True             '入庫区分
                    cboFHORYU_KUBUN.Enabled = True          '保留区分
                    cboFST_FM.Enabled = True                '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    cboXPROD_LINE.Enabled = True            '生産ﾗｲﾝ№
                    cboXKENSA_KUBUN.Enabled = True          '検査区分
                    cboXKENPIN_KUBUN.Enabled = True         '検品区分
                    cboXMAKER_CD.Enabled = True             'ﾒｰｶｰｺｰﾄﾞ

                    lblFBUF_IN_DT_VISIBLE.Visible = False           'ﾊﾞｯﾌｧ入日時(年月日)
                    lblFBUF_IN_TM_VISIBLE.Visible = False           'ﾊﾞｯﾌｧ入日時(時間)
                    lblFRAC_BUNRUI_VISIBLE.Visible = False          '棚分類
                    lblXTANA_BLOCK_VISIBLE.Visible = False          '棚ﾌﾞﾛｯｸ
                    lblXTANA_BLOCK_DTL_VISIBLE.Visible = False      '棚ﾌﾞﾛｯｸ詳細
                    lblXTANA_BLOCK_STS_VISIBL.Visible = False       '棚ﾌﾞﾛｯｸ状態
                    lblFHINMEI_CD_VISIBLE.Visible = False           '品名ｺｰﾄﾞ
                    lblFLOT_NO_VISIBL.Visible = False               'ﾛｯﾄ№
                    lblFTR_VOL_VISIBLE.Visible = False              '数量
                    lblFARRIVE_DT_VISIBLE.Visible = False           '在庫発生日時(年月日)
                    lblFARRIVE_TM_VISIBLE.Visible = False           '在庫発生日時(時間)
                    lblFIN_KUBUN_VISIBLE.Visible = False            '入庫区分
                    lblFHORYU_KUBUN_VISIBLE.Visible = False         '保留区分
                    lblFST_FM_VISIBLE.Visible = False               '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    lblXPROD_LINE_VISIBLE.Visible = False           '生産ﾗｲﾝ№
                    lblXKENSA_KUBUN_VISIBLE.Visible = False         '検査区分
                    lblXKENPIN_KUBUN_VISIBLE.Visible = False        '検品区分
                    lblXMAKER_CD_VISIBLE.Visible = False            'ﾒｰｶｰｺｰﾄﾞ

                End If


                Exit Select


            Case BUTTONMODE_DELETE
                '(削除の場合)

                cboFRES_KIND.Enabled = False            '引当状態
                cboFREMOVE_KIND.Enabled = False         '禁止設定
                cboFRAC_FORM.Enabled = False            '棚形状種別
                dtpXRAC_IN_DT.Enabled = False            'ﾊﾞｯﾌｧ入日時
                txtFRAC_BUNRUI.Enabled = False           '棚分類
                txtXTANA_BLOCK.Enabled = False           '棚ﾌﾞﾛｯｸ
                txtXTANA_BLOCK_DTL.Enabled = False       '棚ﾌﾞﾛｯｸ詳細
                cboXTANA_BLOCK_STS.Enabled = False       '棚ﾌﾞﾛｯｸ状態
                cboFHINMEI_CD.Enabled = False            '品名ｺｰﾄﾞ
                txtFLOT_NO.Enabled = False               'ﾛｯﾄ№
                txtFTR_VOL.Enabled = False               '数量
                dtpFARRIVE_DT.Enabled = False            '在庫発生日時
                cboFIN_KUBUN.Enabled = False             '入庫区分
                cboFHORYU_KUBUN.Enabled = False          '保留区分
                cboFST_FM.Enabled = False                '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                cboXPROD_LINE.Enabled = False            '生産ﾗｲﾝ№
                cboXKENSA_KUBUN.Enabled = False          '検査区分
                cboXKENPIN_KUBUN.Enabled = False         '検品区分
                cboXMAKER_CD.Enabled = False             'ﾒｰｶｰｺｰﾄﾞ

                lblFBUF_IN_DT_VISIBLE.Visible = False           'ﾊﾞｯﾌｧ入日時(年月日)
                lblFBUF_IN_TM_VISIBLE.Visible = False           'ﾊﾞｯﾌｧ入日時(時間)
                lblFRAC_BUNRUI_VISIBLE.Visible = False          '棚分類
                lblXTANA_BLOCK_VISIBLE.Visible = False          '棚ﾌﾞﾛｯｸ
                lblXTANA_BLOCK_DTL_VISIBLE.Visible = False      '棚ﾌﾞﾛｯｸ詳細
                lblXTANA_BLOCK_STS_VISIBL.Visible = False       '棚ﾌﾞﾛｯｸ状態
                lblFHINMEI_CD_VISIBLE.Visible = False           '品名ｺｰﾄﾞ
                lblFLOT_NO_VISIBL.Visible = False               'ﾛｯﾄ№
                lblFTR_VOL_VISIBLE.Visible = False              '数量
                lblFARRIVE_DT_VISIBLE.Visible = False           '在庫発生日時(年月日)
                lblFARRIVE_TM_VISIBLE.Visible = False           '在庫発生日時(時間)
                lblFIN_KUBUN_VISIBLE.Visible = False            '入庫区分
                lblFHORYU_KUBUN_VISIBLE.Visible = False         '保留区分
                lblFST_FM_VISIBLE.Visible = False               '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                lblXPROD_LINE_VISIBLE.Visible = False           '生産ﾗｲﾝ№
                lblXKENSA_KUBUN_VISIBLE.Visible = False         '検査区分
                lblXKENPIN_KUBUN_VISIBLE.Visible = False        '検品区分
                lblXMAKER_CD_VISIBLE.Visible = False            'ﾒｰｶｰｺｰﾄﾞ

        End Select

    End Sub
#End Region
#Region "  ｿｹｯﾄ送信                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket01()


        'Dim intRet As RetCode


        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= cmdZikkou.Text & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If


        '********************************************************************
        '日付文字列作成
        '********************************************************************
        Dim strFARRIVE_DTDate As String                             '在庫発生日時
        strFARRIVE_DTDate = dtpFARRIVE_DT.userDateTimeText
        Dim strFBUF_IN_DTDate As String                             'ﾊﾞｯﾌｧ入日時
        strFBUF_IN_DTDate = dtpXRAC_IN_DT.userDateTimeText

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        Dim strDIR_KUBUN As String = ""                             '処理区分
        Dim strFBUF_NO As String = ""                               'ﾊﾞｯﾌｧ№
        Dim strFBUF_ARRAY As String = ""                            'ﾊﾞｯﾌｧ配列№
        Dim strFREMOVE_KIND As String = ""                          '禁止棚設定
        Dim strFRAC_FORM As String = ""                             '棚形状種別
        Dim strFRES_KIND As String = ""                             '引当状態
        Dim strFHINMEI_CD As String = ""                            '品名ｺｰﾄﾞ
        Dim strFLOT_NO As String = ""                               'ﾛｯﾄ№
        Dim strFARRIVE_DT As String = ""                            '在庫発生日時
        Dim strFIN_KUBUN As String = ""                             '入庫区分
        Dim strFHORYU_KUBUN As String = ""                          '保留区分
        Dim strFST_FM As String = ""                                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        Dim strFTR_VOL As String = ""                               '数量
        Dim strPALLET_ID As String                                  'ﾊﾟﾚｯﾄID
        Dim strFLOT_NO_STOCK As String                              '在庫ﾛｯﾄ№
        Dim strFHASU_FLAG As String = ""                            '端数ﾌﾗｸﾞ
        Dim strFRAC_BUNRUI As String = ""                           '棚分類
        Dim strFBUF_IN_DT As String = ""                            'ﾊﾞｯﾌｧ入日時

        '**********************************************************************************************
        '↓↓↓ｼｽﾃﾑ固有

        Dim strXTANA_BLOCK As String = ""                           '棚ﾌﾞﾛｯｸ
        Dim strXTANA_BLOCK_DTL As String = ""                       '棚ﾌﾞﾛｯｸ詳細
        Dim strXTANA_BLOCK_STS As String = ""                       '棚ﾌﾞﾛｯｸ状態
        Dim strXPROD_LINE As String = ""                            '生産ﾗｲﾝ№
        Dim strXKENSA_KUBUN As String = ""                          '検査区分
        Dim strXKENPIN_KUBUN As String = ""                         '検品区分
        Dim strXMAKER_CD As String = ""                             'ﾒｰｶｰｺｰﾄﾞ

        '↑↑↑ｼｽﾃﾑ固有
        '**********************************************************************************************


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ


        If (mintButtonMode = BUTTONMODE_UPDATE) And (mobjTPRG_TRK_BUF.FRES_KIND = FRES_KIND_SAKI) Then
            '(変更で空棚の場合）
            strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK             '処理区分
        Else
            '(以外の時)
            strDIR_KUBUN = TO_STRING(mintButtonMode)                        '処理区分
        End If

        strFBUF_NO = mstrFTRK_BUF_NO                                        'ﾊﾞｯﾌｧ№
        strFBUF_ARRAY = mstrFTRK_BUF_ARRAY                                  'ﾊﾞｯﾌｧ配列№
        strFREMOVE_KIND = TO_STRING(cboFREMOVE_KIND.SelectedValue)          '禁止棚設定
        strFRAC_FORM = TO_STRING(cboFRAC_FORM.SelectedValue)                '棚形状種別
        strFRES_KIND = TO_STRING(cboFRES_KIND.SelectedValue)                '引当状態
        strFHINMEI_CD = TO_STRING(mstrFHINMEI_CD)                           '品名ｺｰﾄﾞ 
        strFLOT_NO = TO_STRING(txtFLOT_NO.Text)                             'ﾛｯﾄ№ 
        strFARRIVE_DT = strFARRIVE_DTDate                                   '在庫発生日時
        strFIN_KUBUN = TO_STRING(cboFIN_KUBUN.SelectedValue)                '入庫区分
        strFHORYU_KUBUN = TO_STRING(cboFHORYU_KUBUN.SelectedValue)          '保留区分
        strFST_FM = TO_STRING(cboFST_FM.SelectedValue)                      '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strFTR_VOL = TO_STRING(TO_DECIMAL(txtFTR_VOL.Text))                 '数量
        strPALLET_ID = mstrFPALLET_ID                                       'ﾊﾟﾚｯﾄID
        strFLOT_NO_STOCK = mstrFLOT_NO_STOCK                                '在庫ﾛｯﾄ№
        'strFRAC_BUNRUI = TO_STRING(mobjTPRG_TRK_BUF.FRAC_BUNRUI)            '棚分類
        strFRAC_BUNRUI = TO_STRING(txtFRAC_BUNRUI.Text)                     '棚分類
        If strDIR_KUBUN <> FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK Then
            strFBUF_IN_DT = strFBUF_IN_DTDate                               'ﾊﾞｯﾌｧ入日時
        End If

        '**********************************************************************************************
        '↓↓↓ｼｽﾃﾑ固有

        strXTANA_BLOCK = TO_STRING(txtXTANA_BLOCK.Text)                     '棚ﾌﾞﾛｯｸ
        strXTANA_BLOCK_DTL = TO_STRING(txtXTANA_BLOCK_DTL.Text)             '棚ﾌﾞﾛｯｸ詳細
        strXTANA_BLOCK_STS = TO_STRING(cboXTANA_BLOCK_STS.SelectedValue)    '棚ﾌﾞﾛｯｸ状態
        strXPROD_LINE = TO_STRING(cboXPROD_LINE.Text)                       '生産ﾗｲﾝ№
        strXKENSA_KUBUN = TO_STRING(cboXKENSA_KUBUN.SelectedValue)          '検査区分
        strXKENPIN_KUBUN = TO_STRING(cboXKENPIN_KUBUN.SelectedValue)        '検品区分
        strXMAKER_CD = TO_STRING(cboXMAKER_CD.Text)                         'ﾒｰｶｰｺｰﾄﾞ

        '↑↑↑ｼｽﾃﾑ固有
        '**********************************************************************************************


        '========================================
        '品名ﾏｽﾀ 特定
        '========================================
        If mintButtonMode = BUTTONMODE_UPDATE And mobjTPRG_TRK_BUF.FRES_KIND = FRES_KIND_SAKI Then
            '(変更で空棚の場合)
            strFHASU_FLAG = ""

        Else
            '(実棚の時)
            Dim objTMST_ITEM As New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)       '品名ﾏｽﾀ
            objTMST_ITEM.FHINMEI_CD = strFHINMEI_CD                                 '品名ｺｰﾄﾞ
            udtRet = objTMST_ITEM.GET_TMST_ITEM(False)                              '特定

            If objTMST_ITEM.FNUM_IN_PALLET = TO_DECIMAL(strFTR_VOL) Then
                '(ﾊﾟﾚｯﾄ積載数と同じとき)
                strFHASU_FLAG = FHASU_FLAG_SMANSU
            Else
                '(ﾊﾟﾚｯﾄ積載数以下のとき)
                strFHASU_FLAG = FHASU_FLAG_SHASU
            End If
        End If


        objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO)                 'ﾊﾞｯﾌｧ№
        objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY)           'ﾊﾞｯﾌｧ配列№
        objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
        objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
        objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態
        objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
        objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
        objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
        objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
        objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
        objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTelegram.SETIN_DATA("DSPTR_VOL", strFTR_VOL)                     '搬送管理量
        objTelegram.SETIN_DATA("DSPTR_RES_VOL", FTR_RES_VOL_SKOTEI)         '搬送引当量
        objTelegram.SETIN_DATA("DSPPALLET_ID", strPALLET_ID)                'ﾊﾟﾚｯﾄID
        objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
        objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
        objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類
        objTelegram.SETIN_DATA("DSPBUF_IN_DT", strFBUF_IN_DT)               'ﾊﾞｯﾌｧ入日時

        '**********************************************************************************************
        '↓↓↓ｼｽﾃﾑ固有
        objTelegram.SETIN_DATA("XDSPTANA_BLOCK", strXTANA_BLOCK)            '棚ﾌﾞﾛｯｸ
        objTelegram.SETIN_DATA("XDSPTANA_BLOCK_DTL", strXTANA_BLOCK_DTL)    '棚ﾌﾞﾛｯｸ詳細
        objTelegram.SETIN_DATA("XDSPTANA_BLOCK_STS", strXTANA_BLOCK_STS)    '棚ﾌﾞﾛｯｸ詳細
        objTelegram.SETIN_DATA("XDSPPROD_LINE", strXPROD_LINE)              '生産ﾗｲﾝ№
        objTelegram.SETIN_DATA("XDSPKENSA_KUBUN", strXKENSA_KUBUN)          '検査区分
        objTelegram.SETIN_DATA("XDSPKENPIN_KUBUN", strXKENPIN_KUBUN)        '検品区分
        objTelegram.SETIN_DATA("XDSPRAC_IN_DT", strFBUF_IN_DT)              '入庫日時=ﾊﾞｯﾌｧ入日時と同じ
        objTelegram.SETIN_DATA("XDSPMAKER_CD", strXMAKER_CD)                'ﾒｰｶｰｺｰﾄﾞ
        '↑↑↑ｼｽﾃﾑ固有
        '**********************************************************************************************


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = FRM_MSG_FRM205041_01
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
                Me.Dispose()
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
                SubItem2 = TO_STRING(objRow("XMAKER_CD"))

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
