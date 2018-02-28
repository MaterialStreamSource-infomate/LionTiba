'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】入庫設定画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports GamenCommon.clsComFuncGMN
Imports UserProcess
#End Region

Public Class FRM_303010

#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    Private mudtSEARCH_ITEM As stcSEARCH_ITEM           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№引当用構造体 親
    'Private mudtSEARCH_ITEM_KO As New stcSEARCH_ITEM    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№引当用構造体 子

    Private mintPL_VOL As Integer                       'ﾌﾙﾊﾟﾚｯﾄ数

    Private mintHASUU_VOL As Integer                    '端量梱数

    Private mblnContinueEnable As Boolean               '連続入庫設定可能ﾌﾗｸﾞ

    Protected mintXPROGRESS As Integer                  '進捗状況
    Protected mstrFEQ_ID As String                      '設備ID
    Protected mintDSPGRID_DISPLAYINDEX As Integer       '表示順序
    Protected mstrXTRK_BUF_NO_CONV As String            'ｺﾝﾍﾞﾔ関連付け
    Protected mstrFHINMEI_CD As String                  '品名ｺｰﾄﾞ

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        NyukoBtn_Click              '入庫
        ContinueBtn_Click           '連続入庫設定
    End Enum

#End Region
#Region "  構造体定義　                             "
    ''' <summary>検索条件</summary>
    Private Structure stcSEARCH_ITEM
        Dim FTRK_BUF_NO As String   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        Dim FRAC_RETU As String     '列
        Dim FRAC_REN As String      '連
        Dim FRAC_DAN As String      '段
        Dim FRAC_EDA() As String    '空 枝
    End Structure

#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　在庫ｴﾘｱｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ      ｲﾍﾞﾝﾄ     "
    Private Sub cboFTRK_BUF_NO__ZAIKO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO_ZAIKO.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                '===================================
                ' 初期化
                '===================================
                cboFHINMEI_CD.Text = ""             '品名ｺｰﾄﾞ
                Dim dtmNow As Date = Now            '現在日時
                dtpFARRIVE_DT.cmpMDateTimePicker_D.Value = dtmNow
                dtpFARRIVE_DT.userChecked = False
                cboXPROD_LINE.SelectedIndex = -1
                cboXKENSA_KUBUN.SelectedIndex = 0
                cboFIN_KUBUN.SelectedIndex = 0
                cboXMAKER_CD.SelectedIndex = 0
                cboFHORYU_KUBUN.SelectedIndex = 0
                cboXKENPIN_KUBUN.SelectedIndex = 0

                If TO_STRING(cboFTRK_BUF_NO_ZAIKO.SelectedValue) = FTRK_BUF_NO_J9000 Then
                    '(自動倉庫の場合)
                    cboFTRK_BUF_NO_NYUUKO.Enabled = True            '入庫ST

                    If rbtnXDSPIN_SITEI_BLOCK.Checked = False Then
                        'MakeTanabanCombo(True)
                        rbtnXDSPIN_SITEI_BLOCK.Enabled = True           '棚指定
                        rbtnXDSPIN_SITEI_None.Checked = True
                    End If


                ElseIf TO_STRING(cboFTRK_BUF_NO_ZAIKO.SelectedValue) = FTRK_BUF_NO_J9100 Or _
                       TO_STRING(cboFTRK_BUF_NO_ZAIKO.SelectedValue) = FTRK_BUF_NO_J9200 Then
                    '(平置き、検品ｴﾘｱの場合)
                    cboFTRK_BUF_NO_NYUUKO.SelectedIndex = -1        '入庫ST
                    cboFTRK_BUF_NO_NYUUKO.Enabled = False

                    rbtnXDSPIN_SITEI_None.Checked = True            '棚指定
                    rbtnXDSPIN_SITEI_BLOCK.Enabled = False

                End If

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region

#Region "　入庫STｺﾝﾎﾞﾎﾞｯｸｽﾌｫｰｶｽ           ｲﾍﾞﾝﾄ     "
    Private Sub cboFTRK_BUF_NO_NYUUKO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO_NYUUKO.GotFocus
        tmr303010.Enabled = False   'ﾀｲﾏｰ停止
    End Sub
#End Region
#Region "　入庫STｺﾝﾎﾞﾎﾞｯｸｽﾌｫｰｶｽﾛｽﾄ        ｲﾍﾞﾝﾄ     "
    Private Sub cboFTRK_BUF_NO_NYUUKO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO_NYUUKO.LostFocus
        Call tmr303010_TickProcess()    'ﾀｲﾏｰ処理
        tmr303010.Enabled = True        'ﾀｲﾏｰ再開
    End Sub
#End Region
#Region "　入庫STｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ     "
    Private Sub cboFTRK_BUF_NO_NYUUKO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO_NYUUKO.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                '===================================
                ' 初期化
                '===================================
                cboFHINMEI_CD.Text = ""             '品名ｺｰﾄﾞ
                Dim dtmNow As Date = Now            '現在日時
                dtpFARRIVE_DT.cmpMDateTimePicker_D.Value = dtmNow
                dtpFARRIVE_DT.userChecked = False
                cboXPROD_LINE.SelectedIndex = -1
                cboXKENSA_KUBUN.SelectedIndex = 0
                cboFIN_KUBUN.SelectedIndex = 0
                cboXMAKER_CD.SelectedIndex = 0
                cboFHORYU_KUBUN.SelectedIndex = 0
                cboXKENPIN_KUBUN.SelectedIndex = 0

                '===================================
                ' 入出庫ﾓｰﾄﾞ 表示
                '===================================
                Dim intSelect As Integer
                intSelect = TO_INTEGER(cboFTRK_BUF_NO_NYUUKO.SelectedValue)

                Select Case intSelect
                    Case FTRK_BUF_NO_J2038, FTRK_BUF_NO_J1171, FTRK_BUF_NO_J1172, FTRK_BUF_NO_J1173, FTRK_BUF_NO_J1174
                        lblSTMode.Visible = True

                    Case Else
                        lblSTMode.Visible = False

                End Select

                '===================================
                ' 連続入庫設定の確認
                '===================================
                Call CheckContinueState(intSelect)

            End If

        Catch ex As Exception
            ComError(ex)

        End Try

    End Sub
#End Region
#Region "　ﾓｰﾄﾞ更新    ﾀｲﾏ　                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾓｰﾄﾞ更新    ﾀｲﾏ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr303010_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr303010.Tick
        Try

            tmr303010.Enabled = False

            '**************************************************
            ' ﾓｰﾄﾞ取得ﾀｲﾏｰ処理
            '**************************************************
            Call tmr303010_TickProcess()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmr303010.Enabled = True

        End Try
    End Sub
#End Region
#Region "　入庫種別 ﾗｼﾞｵﾎﾞﾀﾝ選択ﾁｪﾝｼﾞ     ｲﾍﾞﾝﾄ     "
    ' ''    ''' *******************************************************************************************************************
    ' ''    ''' <summary>
    ' ''    ''' 入庫種別 ﾗｼﾞｵﾎﾞﾀﾝ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ      
    ' ''    ''' </summary>
    ' ''    ''' <param name="sender"></param>
    ' ''    ''' <param name="e"></param>
    ' ''    ''' <remarks></remarks>
    ' ''    ''' *******************************************************************************************************************
    ' ''    Private Sub rbtnXDSPIN_KIND_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnXDSPIN_KIND_PAIR.CheckedChanged, rbtnXDSPIN_KIND_SINGLE.CheckedChanged
    ' ''        Try

    ' ''            If mFlag_Form_Load = False Then

    ' ''                If DirectCast(sender, RadioButton).Checked = True Then

    ' ''                    If rbtnXDSPIN_KIND_PAIR.Checked = True Then         'ﾍﾟｱ入庫
    ' ''                        txtFTR_VOL_KO.Text = ""
    ' ''                        txtFTR_VOL_KO.Enabled = True
    ' ''                        cboXKENSA_KUBUN_KO.SelectedIndex = 0
    ' ''                        cboXKENSA_KUBUN_KO.Enabled = True
    ' ''                        cboFHORYU_KUBUN_KO.SelectedIndex = 0
    ' ''                        cboFHORYU_KUBUN_KO.Enabled = True

    ' ''                        If rbtnXDSPIN_SITEI_BLOCK.Checked = True Then
    ' ''                            MakeTanabanCombo(True)
    ' ''                        ElseIf rbtnXDSPIN_SITEI_TANTAI.Checked = True Then
    ' ''                            MakeTanabanCombo_TANTAI(True)
    ' ''                        End If

    ' ''                    ElseIf rbtnXDSPIN_KIND_SINGLE.Checked = True Then   'ｼﾝｸﾞﾙ入庫
    ' ''                        txtFTR_VOL_KO.Text = ""
    ' ''                        txtFTR_VOL_KO.Enabled = False
    ' ''                        cboXKENSA_KUBUN_KO.SelectedIndex = -1
    ' ''                        cboXKENSA_KUBUN_KO.Enabled = False
    ' ''                        cboFHORYU_KUBUN_KO.SelectedIndex = -1
    ' ''                        cboFHORYU_KUBUN_KO.Enabled = False

    ' ''                        If rbtnXDSPIN_SITEI_BLOCK.Checked = True Then
    ' ''                            MakeTanabanCombo(False)
    ' ''                        ElseIf rbtnXDSPIN_SITEI_TANTAI.Checked = True Then
    ' ''                            MakeTanabanCombo_TANTAI(False)
    ' ''                        End If

    ' ''                    End If
    ' ''                End If

    ' ''            End If

    ' ''        Catch ex As Exception
    ' ''            ComError(ex)

    ' ''        End Try
    ' ''    End Sub
#End Region
#Region "　入庫指定 ﾗｼﾞｵﾎﾞﾀﾝ選択ﾁｪﾝｼﾞ     ｲﾍﾞﾝﾄ     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入庫指定 ﾗｼﾞｵﾎﾞﾀﾝ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ      
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub rbtnXDSPIN_SITEI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnXDSPIN_SITEI_BLOCK.CheckedChanged, rbtnXDSPIN_SITEI_None.CheckedChanged
        Try

            If mFlag_Form_Load = False Then

                If DirectCast(sender, RadioButton).Checked = True Then

                    If rbtnXDSPIN_SITEI_BLOCK.Checked = True Then           '棚ﾌﾞﾛｯｸ指定
                        MakeTanabanCombo(True)

                    ElseIf rbtnXDSPIN_SITEI_None.Checked = True Then        '棚指定なし
                        cboFRAC_RETU.SelectedIndex = -1
                        cboFRAC_REN.SelectedIndex = -1
                        cboFRAC_DAN.SelectedIndex = -1
                        'cboFRAC_EDA.SelectedIndex = -1
                        cboFRAC_RETU.Enabled = False
                        cboFRAC_REN.Enabled = False
                        cboFRAC_DAN.Enabled = False
                        'cboFRAC_EDA.Enabled = False

                    End If
                End If

            End If

        Catch ex As Exception
            ComError(ex)

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
    Private Sub FRM_303010_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
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

        '===================================
        '在庫ｴﾘｱ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(Me.Name, cboFTRK_BUF_NO_ZAIKO, False, -1)

        '===================================
        '入庫ST ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================

        Call gobjComFuncFRM.cboSetup(Me.Name, cboFTRK_BUF_NO_NYUUKO, False, -1)

        lblSTMode.Text = ""                          '入庫ST・状態
        lblSTMode.BackColor = gcModeColor_Black

        '===================================
        '棚番ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        'Call MakeTanabanCombo(True)

        '===================================
        '品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = ""
        cboFHINMEI_CD.HinmeiVisible = False
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)

        '===================================
        ' 期間初期化
        '===================================
        Dim dtmNow As Date = Now            '現在日時
        dtpFARRIVE_DT.cmpMDateTimePicker_D.Value = dtmNow
        dtpFARRIVE_DT.userChecked = False

        '===================================
        '生産ﾗｲﾝNo.ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboMsterSetup("XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", cboXPROD_LINE, False, -1)

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

        '**************************************************
        ' ﾓｰﾄﾞ取得ﾀｲﾏｰ処理
        '**************************************************
        Call tmr303010_TickProcess()

        '**********************************************************
        ' ﾀｲﾏｰ設定
        '**********************************************************
        tmr303010.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS303010_001))
        tmr303010.Enabled = True

        '**********************************************************
        ' 連続入庫設定
        '**********************************************************
        mblnContinueEnable = False


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
        cboFTRK_BUF_NO_NYUUKO.Dispose()           '入庫ST
        lblSTMode.Dispose()
        rbtnXDSPIN_SITEI_BLOCK.Dispose()
        cboFRAC_RETU.Dispose()
        cboFRAC_REN.Dispose()
        cboFRAC_DAN.Dispose()
        'cboFRAC_EDA.Dispose()
        cboFHINMEI_CD.Dispose()
        lblFHINMEI.Dispose()
        cboXPROD_LINE.Dispose()
        cboXKENSA_KUBUN.Dispose()
        cboFHORYU_KUBUN.Dispose()

    End Sub
#End Region
#Region "  F1(入庫)         ﾎﾞﾀﾝ押下処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(入庫)     ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.NyukoBtn_Click) = False Then
            Exit Sub
        End If

        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_303011) = False Then
            gobjFRM_303011.Close()
            gobjFRM_303011.Dispose()
            gobjFRM_303011 = Nothing
        End If

        gobjFRM_303011 = New FRM_303011

        Call SetProperty()      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_303011.ShowDialog()            '展開

        If intRet = Windows.Forms.DialogResult.Cancel Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If











        '' ''*********************************************
        '' '' 構造体ｾｯﾄ
        '' ''*********************************************
        ' ''Call SearchItem_Set()

        '' ''********************************************************************
        '' ''ｿｹｯﾄ送信処理
        '' ''********************************************************************
        ' ''If SendSocket02_TE() = False Then
        ' ''    Exit Sub
        ' ''End If

    End Sub
#End Region
#Region "  F2(連続入庫設定) ﾎﾞﾀﾝ押下処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F2(連続入庫設定)     ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F2Process()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.ContinueBtn_Click) = False Then
            Exit Sub
        End If

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_303012) = False Then
            gobjFRM_303012.Close()
            gobjFRM_303012.Dispose()
            gobjFRM_303012 = Nothing
        End If

        gobjFRM_303012 = New FRM_303012

        Call SetProperty2()      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_303012.ShowDialog()            '展開

        If intRet = Windows.Forms.DialogResult.Cancel Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If

    End Sub
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/10/17 設定済ﾃﾞｰﾀ表示
#Region "  F3(設定済ﾃﾞｰﾀ表示) ﾎﾞﾀﾝ押下処理          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F3(設定済ﾃﾞｰﾀ表示)   ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F3Process()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        '========================================
        '入庫ST
        '========================================
        If cboFTRK_BUF_NO_NYUUKO.Text = "" Then
            '(選択なしの場合)
            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FTRK_BUF_NO_NYUUKO, _
                            PopupFormType.Ok, _
                            PopupIconType.Information)
            Exit Sub
        End If

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_303013) = False Then
            gobjFRM_303013.Close()
            gobjFRM_303013.Dispose()
            gobjFRM_303013 = Nothing
        End If

        gobjFRM_303013 = New FRM_303013

        Call SetProperty3()      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_303013.ShowDialog()            '展開

        If intRet = Windows.Forms.DialogResult.Cancel Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If

    End Sub
#End Region
    'JobMate:S.Ouchi 2013/10/17 設定済ﾃﾞｰﾀ表示
    '↑↑↑↑↑↑************************************************************************************************************

#Region "　構造体ｾｯﾄ　                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set()

        '***********************************************
        '検索条件をｾｯﾄ
        '***********************************************
        If rbtnXDSPIN_SITEI_BLOCK.Checked = True Then
            '(棚ﾌﾞﾛｯｸ指定の場合)
            mudtSEARCH_ITEM.FRAC_RETU = TO_STRING(cboFRAC_RETU.SelectedValue.ToString)              '列
            mudtSEARCH_ITEM.FRAC_REN = TO_STRING(cboFRAC_REN.SelectedValue.ToString)                '連
            mudtSEARCH_ITEM.FRAC_DAN = TO_STRING(cboFRAC_DAN.SelectedValue.ToString)                '段
            'mudtSEARCH_ITEM.FRAC_EDA = TO_STRING(cboFRAC_EDA.SelectedValue.ToString)                '枝
        Else
            mudtSEARCH_ITEM.FRAC_RETU = ""                                                         '列
            mudtSEARCH_ITEM.FRAC_REN = ""                                                          '連
            mudtSEARCH_ITEM.FRAC_DAN = ""                                                          '段
            'mudtSEARCH_ITEM.FRAC_EDA = ""                                                          '枝
        End If

        If TO_STRING(cboFTRK_BUF_NO_ZAIKO.SelectedValue) = FTRK_BUF_NO_J9000 Then
            mudtSEARCH_ITEM.FTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue.ToString)              '保管場所(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№) 
        Else
            mudtSEARCH_ITEM.FTRK_BUF_NO = ""
        End If

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Public Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        'Dim intRet As RetCode
        Dim strMsg As String = ""

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        Select Case udtCheck_Case
            Case menmCheckCase.NyukoBtn_Click
                '(入庫ﾎﾞﾀﾝｸﾘｯｸ時)

                ''↓↓↓↓↓↓************************************************************************************************************
                ''JobMate:H.Okumura 2013/06/04 子画面でも確認
                '===================================
                ' 連続入庫設定の確認
                '===================================
                If CheckContinueState(cboFTRK_BUF_NO_NYUUKO.SelectedValue) = True Then
                    '(連続入庫中の場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303010_32, _
                                                    PopupFormType.Ok, _
                                                    PopupIconType.Information)
                    Exit Select
                End If
                ''↑↑↑↑↑↑************************************************************************************************************

                '========================================
                '在庫ｴﾘｱ
                '========================================
                If cboFTRK_BUF_NO_ZAIKO.Text = "" Then
                    '(選択なしの場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303010_28, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Information)
                    Exit Select

                End If

                '========================================
                '入庫ST
                '========================================
                If cboFTRK_BUF_NO_ZAIKO.SelectedValue = FTRK_BUF_NO_J9000 Then
                    '(自動倉庫の場合)

                    If cboFTRK_BUF_NO_NYUUKO.Text = "" Then
                        '(選択なしの場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FTRK_BUF_NO_NYUUKO, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Information)
                        Exit Select

                    End If
                End If


                '========================================
                '棚指定
                '========================================
                If rbtnXDSPIN_SITEI_BLOCK.Checked = True Then
                    '(棚ﾌﾞﾛｯｸ指定の場合)
                    If cboFRAC_RETU.Text = "" Or _
                        cboFRAC_REN.Text = "" Or _
                        cboFRAC_DAN.Text = "" Then
                        '(列連段が空の場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303010_33, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Information)
                        Exit Select

                    End If
                End If

                '========================================
                '品名ｺｰﾄﾞ
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

                'Dim decFNUM_IN_PALLET As Decimal = 0        'PL毎積載数

                'Dim objTMST_ITEM As New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)       '品名ﾏｽﾀ
                'objTMST_ITEM.FHINMEI_CD = cboFHINMEI_CD.Text                            '品名ｺｰﾄﾞ
                'intRet = objTMST_ITEM.GET_TMST_ITEM(False)                              '特定
                'If intRet <> RetCode.OK Then
                '    '(読めなかった時)
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303010_19, _
                '                      PopupFormType.Ok, _
                '                      PopupIconType.Information)
                '    Exit Select
                'Else
                '    '(読めた時)
                '    decFNUM_IN_PALLET = objTMST_ITEM.FNUM_IN_PALLET
                'End If

                '' ''========================================
                '' ''在庫発生日時
                '' ''========================================
                ' ''If dtpFARRIVE_DT.userDateTimeText = "" Then
                ' ''    '（入力無しの場合）
                ' ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FARRIVE_DT_MSG_01, _
                ' ''                      PopupFormType.Ok, _
                ' ''                      PopupIconType.Information)
                ' ''    Exit Select
                ' ''End If

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
                'ﾒｰｶｰｺｰﾄﾞ
                '========================================
                '(ﾁｪｯｸ不要)
                ' ''If txtXMAKER_CD.Text = "" Then
                ' ''    '（入力無しの場合）
                ' ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303010_23, _
                ' ''                      PopupFormType.Ok, _
                ' ''                      PopupIconType.Information)
                ' ''    Exit Select
                ' ''End If


                ' ''========================================
                ' ''積数
                ' ''========================================
                ' ''親
                ''If (txtFTR_VOL.Value = "") Or (TO_DECIMAL(txtFTR_VOL.Value) = 0) Then
                ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303010_11, _
                ''                      PopupFormType.Ok, _
                ''                      PopupIconType.Information)
                ''    Exit Select
                ''End If
                ''If IsNumeric(txtFTR_VOL.Value) = False Then
                ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM200000_13 & vbCrLf & FRM_MSG_FTR_VOL_MSG_01, _
                ''                      PopupFormType.Ok, _
                ''                      PopupIconType.Information)
                ''    Exit Select
                ''End If


                ''If TO_DECIMAL(txtFTR_VOL.Value) > decFNUM_IN_PALLET Then
                ''    '(PL毎積載数より大きい時)
                ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303010_20, _
                ''                      PopupFormType.Ok, _
                ''                      PopupIconType.Information)
                ''    Exit Select
                ''End If



                If cboFTRK_BUF_NO_ZAIKO.SelectedValue = FTRK_BUF_NO_J9000 Then
                    '(自動倉庫の場合)

                    ' ''========================================
                    ' ''空棚ﾁｪｯｸ
                    ' ''========================================
                    ''If rbtnXDSPIN_SITEI_BLOCK.Checked = True Then
                    ''    '(棚ﾌﾞﾛｯｸ指定の場合)

                    ''    '↓↓↓↓↓↓************************************************************************************************************
                    ''    'SystemMate:H.Okumura 2013/04/08 入庫不可ﾁｪｯｸは後日行う



                    ''End If

                    '==========================
                    '設備状態ﾁｪｯｸ
                    '==========================
                    If gobjComFuncFRM.CheckFEQ_STS(TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue), FEQ_STS_JINOUTMODE_IN, FRM_MSG_SYS_ERROR_30, FEQ_STS_JINOUTMODE_IN) = False Then
                        blnCheckErr = True
                        Exit Select
                    End If

                End If

                '' ''↓↓↓↓↓↓************************************************************************************************************
                '' ''JobMate:N.Dounoshita 2012/12/26 載荷ﾁｪｯｸ追加

                '' ''==========================
                '' ''載荷ﾁｪｯｸ
                '' ''==========================
                ' ''If gobjComFuncFRM.CheckXEQ_ID_STN(TO_STRING(cboFTRK_BUF_NO.SelectedValue)) Then
                ' ''    blnCheckErr = True
                ' ''    Exit Select
                ' ''End If

                '' ''↑↑↑↑↑↑************************************************************************************************************

                blnCheckErr = False

            Case menmCheckCase.ContinueBtn_Click
                '(連続入庫ﾎﾞﾀﾝ ｸﾘｯｸ)

                '===================================
                ' 連続入庫設定の確認
                '===================================
                If CheckContinueState(cboFTRK_BUF_NO_NYUUKO.SelectedValue) = False Then
                    '(通常の場合)

                    '========================================
                    ' 連続入庫対応ST
                    '========================================
                    If mblnContinueEnable = False Then
                        '(連続入庫STではない場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303010_29, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Information)
                        Exit Select
                    End If

                    '========================================
                    '在庫ｴﾘｱ
                    '========================================
                    If cboFTRK_BUF_NO_ZAIKO.Text = "" Then
                        '(選択なしの場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303010_28, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Information)
                        Exit Select

                    End If

                    If cboFTRK_BUF_NO_ZAIKO.SelectedValue <> FTRK_BUF_NO_J9000 Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303010_31, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Information)
                        Exit Select
                    End If

                    '========================================
                    '入庫ST
                    '========================================
                    If cboFTRK_BUF_NO_NYUUKO.Text = "" Then
                        '(選択なしの場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FTRK_BUF_NO_NYUUKO, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Information)
                        Exit Select

                    End If

                    '========================================
                    '棚指定
                    '========================================
                    If rbtnXDSPIN_SITEI_BLOCK.Checked = True Then
                        '(棚ﾌﾞﾛｯｸ指定の場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303010_30, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Information)
                        Exit Select

                    End If

                    '========================================
                    '品名ｺｰﾄﾞ
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

                Else
                    '(連続入庫中の場合)


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

#Region "  ｿｹｯﾄ送信02  手入力                       "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function SendSocket02_TE() As Boolean

        ' ''Dim blnReturn As Boolean = False        '自関数戻値
        ' ''Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        ' ''Dim strMsg As String = ""

        '' ''*******************************************************
        '' ''確認ﾒｯｾｰｼﾞ
        '' ''*******************************************************
        ' ''Dim udtRet As RetPopup
        ' ''strMsg = ""
        ' ''strMsg &= FRM_MSG_FRM303010_05
        ' ''udtRet = gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        ' ''If udtRet <> RetPopup.OK Then
        ' ''    Exit Function
        ' ''End If

        '' ''********************************************************************
        '' '' 入庫設定ﾃﾞｰﾀ
        '' ''********************************************************************
        '' ''Dim udtNYUUKO_STOCK() As NYUUKO_DATA = Nothing      '送信電文用構造体
        ' ''Dim strSndTlgrm() As String = Nothing               '送信電文文字列
        ' ''Dim intHairetu As Integer = 0                       '配列数

        ' ''Dim strDSPST_FM = ""                                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        ' ''Dim strDSPST_TO = ""                                '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        ' ''Dim strDSPPALLET_ID = ""                            'ﾊﾟﾚｯﾄID
        ' ''Dim strDSPLOT_NO_STOCK = ""                         '在庫ﾛｯﾄ№
        ' ''Dim strDSPHINMEI_CD = ""                            '品名ｺｰﾄﾞ
        ' ''Dim strDSPTR_VOL = ""                               '搬送管理量
        ' ''Dim strXDSPIN_KIND = ""                             '入庫種別
        ' ''Dim strXDSPIN_SITEI = ""                            '入庫指定
        ' ''Dim strDSPARRIVE_DT = ""                            '在庫発生日時
        ' ''Dim strXDSPPROD_LINE = ""                           '生産ﾗｲﾝ№
        ' ''Dim strXMAKER_CD = ""                               'ﾒｰｶｰｺｰﾄﾞ
        ' ''Dim strXDSPKENSA_KUBUN = ""                         '検査区分
        ' ''Dim strDSPHORYU_KUBUN = ""                          '保留区分
        ' ''Dim strDSPIN_KUBUN = ""                             '入庫区分
        ' ''Dim strXDSPKENPIN_KUBUN = ""                        '検品区分
        ' ''Dim strXDSPTANA_BLOCK = ""                          '棚ﾌﾞﾛｯｸ

        ' ''Dim strDSPTR_VOL_HASUU = ""                         '端数
        ' ''Dim blnHASUUFlag As Boolean = False                 '端数ﾌﾗｸﾞ

        ' ''Dim blnPareFlag As Boolean = False                  'ﾍﾟｱ入庫ﾌﾗｸﾞ

        ' ''Dim intALL_PL_Count As Integer = 0                  '搬送ﾊﾟﾚｯﾄ数

        '' ''Dim strXADRS_YOTEI = ""                            '予定数ｱﾄﾞﾚｽ
        '' ''Dim strOUTST_NO As String = ""                     'ｽﾃｰｼｮﾝID

        '' ''********************************************************************
        '' '' ﾊﾟﾚｯﾄ+端数ﾃﾞｰﾀｾｯﾄ 
        '' ''********************************************************************
        ' ''mintPL_VOL = TO_INTEGER(txtPL_VOL.Text)
        ' ''mintHASUU_VOL = TO_INTEGER(txtHASUU_VOL.Text)
        ' ''If mintHASUU_VOL = 0 Then
        ' ''    blnHASUUFlag = False        '端数無
        ' ''    intALL_PL_Count = mintPL_VOL
        ' ''Else
        ' ''    blnHASUUFlag = True         '端数有
        ' ''    intALL_PL_Count = mintPL_VOL + 1
        ' ''End If

        '' ''**********************************************************
        '' '' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀの特定  (搬送元ST特定)
        '' ''**********************************************************
        ' ''Dim intRet As RetCode
        ' ''Dim objTMST_TRK As TBL_TMST_TRK                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        ' ''objTMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
        ' ''objTMST_TRK.FTRK_BUF_NO = mudtSEARCH_ITEM.FTRK_BUF_NO       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        ' ''intRet = objTMST_TRK.GET_TMST_TRK(False)
        ' ''If intRet = RetCode.OK Then
        ' ''    '(読めたとき)
        ' ''    If IsNull(objTMST_TRK.XTRK_BUF_NO_CONV) = False Then
        ' ''        '(値がある時)
        ' ''        strDSPST_FM = objTMST_TRK.XTRK_BUF_NO_CONV          '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        ' ''    Else
        ' ''        '(値がない時)
        ' ''        strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀに、搬送元STが見つかりませんでした。" & _
        ' ''                 "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & mudtSEARCH_ITEM.FTRK_BUF_NO & "]"
        ' ''        Throw New System.Exception(strMsg)
        ' ''    End If
        ' ''Else
        ' ''    '(読めなかった時)
        ' ''    strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀに、搬送元STが見つかりませんでした。" & _
        ' ''             "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & mudtSEARCH_ITEM.FTRK_BUF_NO & "]"
        ' ''    Throw New System.Exception(strMsg)
        ' ''End If

        '' ''**********************************************************
        '' '' 共通入庫設定ﾃﾞｰﾀｾｯﾄ
        '' ''**********************************************************
        ' ''strDSPST_TO = TO_STRING(cboFTRK_BUF_NO_ZAIKO.SelectedValue)         '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№

        ' ''strDSPPALLET_ID = ""                                                'ﾊﾟﾚｯﾄID
        ' ''strDSPLOT_NO_STOCK = ""                                             '在庫ﾛｯﾄ№
        ' ''strDSPHINMEI_CD = TO_STRING(cboFHINMEI_CD.Text)                     '品名ｺｰﾄﾞ


        ' ''If rbtnXDSPIN_SITEI_BLOCK.Checked = True Then                       '入庫指定
        ' ''    strXDSPIN_SITEI = TO_STRING(XDSPIN_SITEI_TANA_BLOCK)            '棚ﾌﾞﾛｯｸ指定
        ' ''ElseIf rbtnXDSPIN_SITEI_None.Checked = True Then
        ' ''    strXDSPIN_SITEI = TO_STRING(XDSPIN_SITEI_NON)                   '棚ﾌﾞﾛｯｸ指定
        ' ''End If

        ' ''strDSPARRIVE_DT = dtpFARRIVE_DT.userDateTimeText                    '在庫発生日時
        ' ''strXDSPPROD_LINE = TO_STRING(cboXPROD_LINE.SelectedValue)           '生産ﾗｲﾝ№
        ' ''strXMAKER_CD = TO_STRING(txtXMAKER_CD.Text)                         'ﾒｰｶｰｺｰﾄﾞ
        ' ''strXDSPKENSA_KUBUN = TO_STRING(cboXKENSA_KUBUN.SelectedValue)       '検査区分
        ' ''strDSPHORYU_KUBUN = TO_STRING(cboFHORYU_KUBUN.SelectedValue)        '保留区分
        ' ''strDSPIN_KUBUN = TO_STRING(cboFIN_KUBUN.SelectedValue)              '入庫区分
        ' ''strXDSPKENPIN_KUBUN = TO_STRING(cboXKENPIN_KUBUN.SelectedValue)     '検品区分
        ' ''strDSPTR_VOL_HASUU = TO_STRING(txtHASUU_VOL.Text)                   '端量梱数

        '' ''**********************************************************
        '' '' 棚ﾌﾞﾛｯｸの特定 
        '' ''**********************************************************
        ' ''If rbtnXDSPIN_SITEI_None.Checked = False Then

        ' ''    Dim intRet2 As RetCode
        ' ''    Dim objTBL_TPRG_TRK_BUF As TBL_TPRG_TRK_BUF
        ' ''    objTBL_TPRG_TRK_BUF = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
        ' ''    objTBL_TPRG_TRK_BUF.FRAC_RETU = mudtSEARCH_ITEM.FRAC_RETU           '列
        ' ''    objTBL_TPRG_TRK_BUF.FRAC_REN = mudtSEARCH_ITEM.FRAC_REN             '連
        ' ''    objTBL_TPRG_TRK_BUF.FRAC_DAN = mudtSEARCH_ITEM.FRAC_DAN             '段
        ' ''    objTBL_TPRG_TRK_BUF.FRAC_EDA = "0"                                  '枝

        ' ''    intRet2 = objTBL_TPRG_TRK_BUF.GET_TPRG_TRK_BUF(False)
        ' ''    If intRet2 = RetCode.OK Then
        ' ''        '(値がある時)
        ' ''        strXDSPTANA_BLOCK = objTBL_TPRG_TRK_BUF.XTANA_BLOCK        '棚ﾌﾞﾛｯｸ
        ' ''    Else
        ' ''        '(読めなかった時)
        ' ''        strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧに、棚ﾌﾞﾛｯｸが見つかりませんでした。" & _
        ' ''                 "[棚番:" & mudtSEARCH_ITEM.FRAC_RETU & "-" & mudtSEARCH_ITEM.FRAC_REN & "-" & mudtSEARCH_ITEM.FRAC_DAN & "]"
        ' ''        Throw New System.Exception(strMsg)
        ' ''    End If

        ' ''Else
        ' ''    strXDSPTANA_BLOCK = ""

        ' ''End If

        '' ''**********************************************************
        '' '' 搬送管理量の特定
        '' ''**********************************************************
        ' ''Dim intRet3 As RetCode
        ' ''Dim objTBL_TMST_ITEM As TBL_TMST_ITEM
        ' ''objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
        ' ''objTBL_TMST_ITEM.FHINMEI_CD = TO_STRING(cboFHINMEI_CD.SelectedValue)        '品名ｺｰﾄﾞ
        ' ''intRet3 = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
        ' ''If intRet3 = RetCode.OK Then
        ' ''    '(値がある時)
        ' ''    strDSPTR_VOL = objTBL_TMST_ITEM.FNUM_IN_PALLET        'PL毎積載数
        ' ''Else
        ' ''    '(読めなかった時)
        ' ''    strMsg = "品目ﾏｽﾀに、PL毎積載数が見つかりませんでした。" & _
        ' ''             "[品目ｺｰﾄﾞ:" & TO_STRING(cboFHINMEI_CD.SelectedValue) & "]"
        ' ''    Throw New System.Exception(strMsg)
        ' ''End If


        ' '' '' ''**********************************************************
        ' '' '' '' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定  (搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№特定)
        ' '' '' ''**********************************************************
        '' '' ''Dim intRet2 As RetCode
        '' '' ''Dim objTBL_TPRG_TRK_BUF As TBL_TPRG_TRK_BUF                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ

        '' '' ''If rbtnXDSPIN_SITEI_None.Checked = True Then
        '' '' ''    '(棚指定なしの場合)
        '' '' ''    strXDPST_TO_ARRAY01 = ""
        '' '' ''    strXDPST_TO_ARRAY02 = ""

        '' '' ''Else

        '' '' ''    objTBL_TPRG_TRK_BUF = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)

        '' '' ''    objTBL_TPRG_TRK_BUF.FRAC_RETU = mudtSEARCH_ITEM.FRAC_RETU           '列
        '' '' ''    objTBL_TPRG_TRK_BUF.FRAC_REN = mudtSEARCH_ITEM.FRAC_REN             '連
        '' '' ''    objTBL_TPRG_TRK_BUF.FRAC_DAN = mudtSEARCH_ITEM.FRAC_DAN             '段
        '' '' ''    objTBL_TPRG_TRK_BUF.FRAC_EDA = mudtSEARCH_ITEM.FRAC_EDA             '枝

        '' '' ''    intRet2 = objTBL_TPRG_TRK_BUF.GET_TPRG_TRK_BUF(False)
        '' '' ''    If intRet2 = RetCode.OK Then
        '' '' ''        '(値がある時)
        '' '' ''        strXDPST_TO_ARRAY01 = objTBL_TPRG_TRK_BUF.FTRK_BUF_ARRAY        '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列No.01 
        '' '' ''    Else
        '' '' ''        '(読めなかった時)
        '' '' ''        strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧに、搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№が見つかりませんでした。" & _
        '' '' ''                 "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & mudtSEARCH_ITEM.FTRK_BUF_NO & "]"
        '' '' ''        Throw New System.Exception(strMsg)
        '' '' ''    End If
        '' '' ''End If



        '' ''********************************************************************
        '' '' 入庫設定用 電文作成
        '' ''********************************************************************
        '' ''送信電文
        ' ''ReDim strSndTlgrm(0)

        ' ''For ii As Integer = 1 To intALL_PL_Count Step 2
        ' ''    '(ﾊﾟﾚｯﾄ数分ﾙｰﾌﾟ)
        ' ''    If ii + 1 <= intALL_PL_Count Then
        ' ''        blnPareFlag = True
        ' ''    Else
        ' ''        blnPareFlag = False
        ' ''    End If


        ' ''    '配列再定義
        ' ''    ReDim Preserve strSndTlgrm(0 To intHairetu)         '送信電文文字列

        ' ''    Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

        ' ''    objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400001

        ' ''    objTelegramSub.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegramSub.FORMAT_ID, 6)) 'ｺﾏﾝﾄﾞID
        ' ''    objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                           '端末ID
        ' ''    objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                           '担当者ｺｰﾄﾞ

        ' ''    objTelegramSub.SETIN_DATA("DSPST_FM", strDSPST_FM)                  '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        ' ''    objTelegramSub.SETIN_DATA("DSPST_TO", strDSPST_TO)                  '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        ' ''    objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)          'ﾊﾟﾚｯﾄID
        ' ''    objTelegramSub.SETIN_DATA("DSPLOT_NO_STOCK", strDSPLOT_NO_STOCK)    '在庫ﾛｯﾄ№

        ' ''    If blnPareFlag = True Then
        ' ''        objTelegramSub.SETIN_DATA("DSPSAGYOU_KIND", TO_STRING(FSAGYOU_KIND_J53))      '作業種別 ﾛｰｶﾙ入庫(ﾍﾟｱ)
        ' ''    Else
        ' ''        objTelegramSub.SETIN_DATA("DSPSAGYOU_KIND", TO_STRING(FSAGYOU_KIND_J54))      '作業種別 ﾛｰｶﾙ入庫(ｼﾝｸﾞﾙ)
        ' ''    End If
        ' ''    objTelegramSub.SETIN_DATA("DSPHINMEI_CD", strDSPHINMEI_CD)          '品名ｺｰﾄﾞ

        ' ''    If blnHASUUFlag = True Then
        ' ''        '(端数がある場合)
        ' ''        If ii <> intALL_PL_Count Then
        ' ''            objTelegramSub.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL)        '搬送管理量
        ' ''        Else
        ' ''            objTelegramSub.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL_HASUU)  '搬送管理量 端数
        ' ''        End If

        ' ''    Else
        ' ''        objTelegramSub.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL)            '搬送管理量

        ' ''    End If


        ' ''    If blnPareFlag = True Then
        ' ''        objTelegramSub.SETIN_DATA("XDSPIN_KIND", 1)                     '入庫種別
        ' ''    Else
        ' ''        objTelegramSub.SETIN_DATA("XDSPIN_KIND", 0)                     '入庫種別
        ' ''    End If

        ' ''    objTelegramSub.SETIN_DATA("XDSPIN_SITEI", strXDSPIN_SITEI)          '入庫指定

        ' ''    objTelegramSub.SETIN_DATA("DSPARRIVE_DT", strDSPARRIVE_DT)          '在庫発生日時
        ' ''    objTelegramSub.SETIN_DATA("XDSPPROD_LINE", strXDSPPROD_LINE)        '生産ﾗｲﾝ№
        ' ''    objTelegramSub.SETIN_DATA("XDSPMAKER_CD", strXMAKER_CD)             'ﾒｰｶｰｺｰﾄﾞ
        ' ''    objTelegramSub.SETIN_DATA("XDSPKENSA_KUBUN", strXDSPKENSA_KUBUN)    '検査区分
        ' ''    objTelegramSub.SETIN_DATA("DSPHORYU_KUBUN", strDSPHORYU_KUBUN)      '保留区分
        ' ''    objTelegramSub.SETIN_DATA("DSPIN_KUBUN", strDSPIN_KUBUN)            '入庫区分
        ' ''    objTelegramSub.SETIN_DATA("XDSPKENPIN_KUBUN", strXDSPKENPIN_KUBUN)  '検品区分

        ' ''    If blnPareFlag = True Then
        ' ''        '(ﾍﾟｱ入庫の場合)
        ' ''        If blnHASUUFlag = True Then
        ' ''            '(端数がある場合)
        ' ''            If ii + 1 <> intALL_PL_Count Then
        ' ''                objTelegramSub.SETIN_DATA("XDSPTR_VOL_KO", strDSPTR_VOL)        '搬送管理量(子)
        ' ''            Else
        ' ''                objTelegramSub.SETIN_DATA("XDSPTR_VOL_KO", strDSPTR_VOL_HASUU)  '搬送管理量(子) 端数
        ' ''            End If

        ' ''        Else
        ' ''            objTelegramSub.SETIN_DATA("XDSPTR_VOL_KO", strDSPTR_VOL)            '搬送管理量(子)

        ' ''        End If


        ' ''    End If

        ' ''    objTelegramSub.SETIN_DATA("XDSPTANA_BLOCK", strXDSPTANA_BLOCK)      '棚ﾌﾞﾛｯｸ


        ' ''    objTelegramSub.MAKE_TELEGRAM()
        ' ''    strSndTlgrm(intHairetu) = objTelegramSub.TELEGRAM_MAKED             '送信電文

        ' ''    intHairetu = intHairetu + 1
        ' ''Next

        ' '' '' ''********************************************************************
        ' '' '' '' 入庫設定端数用 電文作成
        ' '' '' ''********************************************************************
        '' '' ''If blnHASUUFlag = True Then
        '' '' ''    '(端数がある場合)
        '' '' ''    ReDim Preserve strSndTlgrm(0 To intHairetu)         '送信電文文字列

        '' '' ''    Dim objTelegramHasuu As New clsTelegram(CONFIG_TELEGRAM_DSP)
        '' '' ''    objTelegramHasuu.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400001
        '' '' ''    objTelegramHasuu.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegramHasuu.FORMAT_ID, 6)) 'ｺﾏﾝﾄﾞID
        '' '' ''    objTelegramHasuu.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                           '端末ID
        '' '' ''    objTelegramHasuu.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                           '担当者ｺｰﾄﾞ

        '' '' ''    objTelegramHasuu.SETIN_DATA("DSPST_FM", strDSPST_FM)                  '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        '' '' ''    objTelegramHasuu.SETIN_DATA("DSPST_TO", strDSPST_TO)                  '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        '' '' ''    objTelegramHasuu.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)          'ﾊﾟﾚｯﾄID
        '' '' ''    objTelegramHasuu.SETIN_DATA("DSPLOT_NO_STOCK", strDSPLOT_NO_STOCK)    '在庫ﾛｯﾄ№
        '' '' ''    objTelegramHasuu.SETIN_DATA("DSPSAGYOU_KIND", strDSPSAGYOU_KIND)      '作業種別
        '' '' ''    objTelegramHasuu.SETIN_DATA("DSPHINMEI_CD", strDSPHINMEI_CD)          '品名ｺｰﾄﾞ

        '' '' ''    objTelegramHasuu.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL_HASUU)          '搬送管理量

        '' '' ''    objTelegramHasuu.SETIN_DATA("XDSPIN_KIND", 0)                         '入庫種別

        '' '' ''    objTelegramHasuu.SETIN_DATA("XDSPIN_SITEI", strXDSPIN_SITEI)          '入庫指定

        '' '' ''    objTelegramHasuu.SETIN_DATA("DSPARRIVE_DT", strDSPARRIVE_DT)          '在庫発生日時
        '' '' ''    objTelegramHasuu.SETIN_DATA("XDSPPROD_LINE", strXDSPPROD_LINE)        '生産ﾗｲﾝ№
        '' '' ''    objTelegramHasuu.SETIN_DATA("XDSPMAKER_CD", strXMAKER_CD)             'ﾒｰｶｰｺｰﾄﾞ
        '' '' ''    objTelegramHasuu.SETIN_DATA("XDSPKENSA_KUBUN", strXDSPKENSA_KUBUN)    '検査区分
        '' '' ''    objTelegramHasuu.SETIN_DATA("DSPHORYU_KUBUN", strDSPHORYU_KUBUN)      '保留区分
        '' '' ''    objTelegramHasuu.SETIN_DATA("DSPIN_KUBUN", strDSPIN_KUBUN)            '入庫区分
        '' '' ''    objTelegramHasuu.SETIN_DATA("XDSPKENPIN_KUBUN", strXDSPKENPIN_KUBUN)  '検品区分

        '' '' ''    objTelegramHasuu.SETIN_DATA("XDSPTANA_BLOCK", strXDSPTANA_BLOCK)    '棚ﾌﾞﾛｯｸ


        '' '' ''    objTelegramHasuu.MAKE_TELEGRAM()
        '' '' ''    strSndTlgrm(intHairetu) = objTelegramHasuu.TELEGRAM_MAKED             '送信電文

        '' '' ''End If

        '' ''********************************************************************
        '' '' ｿｹｯﾄ送信処理
        '' ''********************************************************************
        ' ''Dim strRetState() As String = Nothing               '出庫処理戻りｽﾃｰﾀｽ
        ' ''Dim strErrMsg As String = ""                        'ｴﾗｰﾒｯｾｰｼﾞ
        ' ''Dim udtSckSendRET As clsSocketClient.RetCode        'ｿｹｯﾄ送信戻り値
        ' ''Dim strRET_STATE As String = ""

        ' ''Dim objTelegramNull As New clsTelegram(CONFIG_TELEGRAM_DSP)
        ' ''objTelegramNull.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400001

        '' ''=====================================
        '' ''複数ｿｹｯﾄ処理
        '' ''=====================================
        ' ''strErrMsg = FRM_MSG_FRM303010_06
        ' ''udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegramNull, strSndTlgrm, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        ' ''If udtSckSendRET = clsSocketClient.RetCode.OK Then
        ' ''    '(送信できた場合)
        ' ''    If strRET_STATE = ID_RETURN_RET_STATE_OK Then
        ' ''        '(正常終了の場合)
        ' ''        blnCheckErr = False
        ' ''    End If
        ' ''End If

        ' ''If blnCheckErr = True Then
        ' ''    '(ﾁｪｯｸに引っかかった時)
        ' ''    blnReturn = False
        ' ''Else
        ' ''    '(ﾁｪｯｸに引っかからなかった時)
        ' ''    blnReturn = True
        ' ''End If

        ' ''Return blnReturn

    End Function
#End Region

#Region "  入庫設定画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入庫設定画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty()

        '**********************************************************
        ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀの特定  (搬送元ST特定)
        '**********************************************************
        If cboFTRK_BUF_NO_ZAIKO.SelectedValue = FTRK_BUF_NO_J9000 Then
            '(自動倉庫の場合)

            Dim strMsg As String
            Dim intRet As RetCode
            Dim objTMST_TRK As TBL_TMST_TRK                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
            objTMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
            objTMST_TRK.FTRK_BUF_NO = mudtSEARCH_ITEM.FTRK_BUF_NO       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            intRet = objTMST_TRK.GET_TMST_TRK(False)
            If intRet = RetCode.OK Then
                '(読めたとき)
                If IsNull(objTMST_TRK.XTRK_BUF_NO_CONV) = False Then
                    '(値がある時)
                    mstrXTRK_BUF_NO_CONV = objTMST_TRK.XTRK_BUF_NO_CONV          '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
                Else
                    '(値がない時)
                    strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀに、搬送元STが見つかりませんでした。" & _
                             "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & mudtSEARCH_ITEM.FTRK_BUF_NO & "]"
                    Throw New System.Exception(strMsg)
                End If
            Else
                '(読めなかった時)
                strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀに、搬送元STが見つかりませんでした。" & _
                         "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & mudtSEARCH_ITEM.FTRK_BUF_NO & "]"
                Throw New System.Exception(strMsg)
            End If

            gobjFRM_303011.userST_FM = mstrXTRK_BUF_NO_CONV                                             '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            gobjFRM_303011.userST_TO = TO_STRING(cboFTRK_BUF_NO_ZAIKO.SelectedValue)                    '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            gobjFRM_303011.userFTRK_BUF_NO_Nyuko = TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue)       '入庫STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            gobjFRM_303011.userFTRK_BUF_NO_Disp = cboFTRK_BUF_NO_NYUUKO.Text                            'ST名
            gobjFRM_303011.userPALLET_ID = ""                                                           'ﾊﾟﾚｯﾄID
            gobjFRM_303011.userLOT_NO_STOCK = ""                                                        '在庫ﾛｯﾄ№
            gobjFRM_303011.userFHINMEI_CD = TO_STRING(cboFHINMEI_CD.Text)                               '品名ｺｰﾄﾞ
            gobjFRM_303011.userFHINMEI = TO_STRING(lblFHINMEI.Text)                                     '品名

            If rbtnXDSPIN_SITEI_BLOCK.Checked = True Then                                               '入庫指定
                '(棚ﾌﾞﾛｯｸ指定)
                gobjFRM_303011.userIN_SITEI = TO_STRING(XDSPIN_SITEI_TANA_BLOCK)
            ElseIf rbtnXDSPIN_SITEI_None.Checked = True Then
                '(棚指定なし)
                gobjFRM_303011.userIN_SITEI = TO_STRING(XDSPIN_SITEI_NON)
            End If

            If dtpFARRIVE_DT.userChecked = True Then                                                    '在庫発生日時
                gobjFRM_303011.userARRIVE_DT = dtpFARRIVE_DT.userDateTimeText
            Else
                gobjFRM_303011.userARRIVE_DT = ""
            End If

            gobjFRM_303011.userPROD_LINE = TO_STRING(cboXPROD_LINE.Text)                                '生産ﾗｲﾝ№
            gobjFRM_303011.userMAKER_CD = TO_STRING(cboXMAKER_CD.Text)                                  'ﾒｰｶｰｺｰﾄﾞ
            gobjFRM_303011.userKENSA_KUBUN = TO_STRING(cboXKENSA_KUBUN.SelectedValue)                   '検査区分
            gobjFRM_303011.userHORYU_KUBUN = TO_STRING(cboFHORYU_KUBUN.SelectedValue)                   '保留区分
            gobjFRM_303011.userIN_KUBUN = TO_STRING(cboFIN_KUBUN.SelectedValue)                         '入庫区分
            gobjFRM_303011.userKENPIN_KUBUN = TO_STRING(cboXKENPIN_KUBUN.SelectedValue)                 '検品区分

            gobjFRM_303011.userFRAC_RETU = mudtSEARCH_ITEM.FRAC_RETU                                    '列
            gobjFRM_303011.userFRAC_REN = mudtSEARCH_ITEM.FRAC_REN                                      '連
            gobjFRM_303011.userFRAC_DAN = mudtSEARCH_ITEM.FRAC_DAN                                      '段


        ElseIf cboFTRK_BUF_NO_ZAIKO.SelectedValue = FTRK_BUF_NO_J9100 Or _
                cboFTRK_BUF_NO_ZAIKO.SelectedValue = FTRK_BUF_NO_J9200 Then
            '(平置き、検品ｴﾘｱの場合)

            gobjFRM_303011.userST_FM = ""                                                               '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            gobjFRM_303011.userST_TO = TO_STRING(cboFTRK_BUF_NO_ZAIKO.SelectedValue)                    '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            gobjFRM_303011.userFTRK_BUF_NO_Nyuko = ""                                                   '入庫STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            gobjFRM_303011.userFTRK_BUF_NO_Disp = cboFTRK_BUF_NO_ZAIKO.Text                             'ST名
            gobjFRM_303011.userPALLET_ID = ""                                                           'ﾊﾟﾚｯﾄID
            gobjFRM_303011.userLOT_NO_STOCK = ""                                                        '在庫ﾛｯﾄ№
            gobjFRM_303011.userFHINMEI_CD = TO_STRING(cboFHINMEI_CD.Text)                               '品名ｺｰﾄﾞ
            gobjFRM_303011.userFHINMEI = TO_STRING(lblFHINMEI.Text)                                     '品名
            gobjFRM_303011.userIN_SITEI = TO_STRING(XDSPIN_SITEI_NON)                                   '入庫指定

            If dtpFARRIVE_DT.userChecked = True Then                                                    '在庫発生日時
                gobjFRM_303011.userARRIVE_DT = dtpFARRIVE_DT.userDateTimeText
            Else
                gobjFRM_303011.userARRIVE_DT = ""
            End If

            gobjFRM_303011.userPROD_LINE = TO_STRING(cboXPROD_LINE.Text)                                '生産ﾗｲﾝ№
            gobjFRM_303011.userMAKER_CD = TO_STRING(cboXMAKER_CD.Text)                                  'ﾒｰｶｰｺｰﾄﾞ
            gobjFRM_303011.userKENSA_KUBUN = TO_STRING(cboXKENSA_KUBUN.SelectedValue)                   '検査区分
            gobjFRM_303011.userHORYU_KUBUN = TO_STRING(cboFHORYU_KUBUN.SelectedValue)                   '保留区分
            gobjFRM_303011.userIN_KUBUN = TO_STRING(cboFIN_KUBUN.SelectedValue)                         '入庫区分
            gobjFRM_303011.userKENPIN_KUBUN = TO_STRING(cboXKENPIN_KUBUN.SelectedValue)                 '検品区分

            gobjFRM_303011.userFRAC_RETU = ""                                                           '列
            gobjFRM_303011.userFRAC_REN = ""                                                            '連
            gobjFRM_303011.userFRAC_DAN = ""                                                            '段


        End If

    End Sub

#End Region
#Region "  連続入庫設定画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 連続入庫設定画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty2()

        '===================================
        ' 連続入庫設定の確認
        '===================================
        If CheckContinueState(cboFTRK_BUF_NO_NYUUKO.SelectedValue) = False Then
            gobjFRM_303012.userXPROD_LINE = TO_STRING(cboXPROD_LINE.Text)                                           '生産ﾗｲﾝNo.
            gobjFRM_303012.userXMAKER_CD = TO_STRING(cboXMAKER_CD.Text)                                             'ﾒｰｶｰｺｰﾄﾞ
            gobjFRM_303012.userXKENSA_KUBUN = TO_STRING(cboXKENSA_KUBUN.SelectedValue.ToString)                     '検査区分
            gobjFRM_303012.userFHORYU_KUBUN = TO_STRING(cboFHORYU_KUBUN.SelectedValue.ToString)                     '保留区分
            gobjFRM_303012.userFIN_KUBUN = TO_STRING(cboFIN_KUBUN.SelectedValue.ToString)                           '入庫区分
            gobjFRM_303012.userXKENPIN_KUBUN = TO_STRING(cboXKENPIN_KUBUN.SelectedValue.ToString)                   '検品区分
            If dtpFARRIVE_DT.userChecked = True Then                                                                '在庫発生日時
                gobjFRM_303012.userFARRIVE_DT = dtpFARRIVE_DT.userDateTimeText
            Else
                gobjFRM_303012.userFARRIVE_DT = ""
            End If

        End If

        gobjFRM_303012.userFTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue.ToString)                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        gobjFRM_303012.userFTRK_BUF_NO_Disp = TO_STRING(cboFTRK_BUF_NO_NYUUKO.Text)                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.(表示用)
        gobjFRM_303012.userFHINMEI_CD = TO_STRING(cboFHINMEI_CD.Text)                                           '品名ｺｰﾄﾞ
        gobjFRM_303012.userFHINMEI = TO_STRING(lblFHINMEI.Text)                                                 '品名
        gobjFRM_303012.userFEQ_ID = mstrFEQ_ID                                                                  '設備ID
        gobjFRM_303012.userXPROGRESS = mintXPROGRESS                                                            '進捗状況
        gobjFRM_303012.userDSPGRID_DISPLAYINDEX = mintDSPGRID_DISPLAYINDEX                                      '表示順序

    End Sub

#End Region
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/10/17 設定済ﾃﾞｰﾀ表示
#Region "  設定済ﾃﾞｰﾀ表示画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 設定済ﾃﾞｰﾀ表示画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty3()

        '===================================
        ' 入庫ST情報ｾｯﾄ
        '===================================
        gobjFRM_303013.userFTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue.ToString)                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        gobjFRM_303013.userFTRK_BUF_NO_Disp = TO_STRING(cboFTRK_BUF_NO_NYUUKO.Text)                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.(表示用)

    End Sub

#End Region
    'JobMate:S.Ouchi 2013/10/17 設定済ﾃﾞｰﾀ表示
    '↑↑↑↑↑↑************************************************************************************************************


#Region "  ﾓｰﾄﾞ取得ﾀｲﾏｰ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 設備状態取得ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr303010_TickProcess()

        '**********************************************************
        ' ﾗﾍﾞﾙ背景色変更処理
        '**********************************************************
        Call gobjComFuncFRM.AlterLabelColorMOD_TIBA(lblSTMode, TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue), LBL_DSPTYPE.STSNAME)

        '**********************************************************
        ' 連続入庫状態取得
        '**********************************************************
        Call CheckContinueState(TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue))

    End Sub
#End Region
#Region "　列連段ｺﾝﾎﾞ作成処理                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 列連段ｺﾝﾎﾞ作成処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MakeTanabanCombo(ByVal blnSingle As Boolean)

        '**********************************************************
        ' 自動倉庫の棚番を取得
        '**********************************************************
        cboFRAC_RETU.Enabled = True     '列
        cboFRAC_REN.Enabled = True      '連
        cboFRAC_DAN.Enabled = True      '段

        Call gobjComFuncFRM.InitRetuRenDanEda_TrkBufNo(FTRK_BUF_NO_J9000.ToString _
              , cboFRAC_RETU _
              , cboFRAC_REN _
              , cboFRAC_DAN _
              , Nothing _
              , blnSingle _
              )


        cboFRAC_RETU.SelectedIndex = 0     '列
        cboFRAC_REN.SelectedIndex = 0      '連
        cboFRAC_DAN.SelectedIndex = 0      '段


    End Sub
#End Region
#Region "　列連段枝ｺﾝﾎﾞ作成処理                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 列連段枝ｺﾝﾎﾞ作成処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MakeTanabanCombo_EDA(ByVal blnSingle As Boolean)

        '' ''**********************************************************
        '' '' 自動倉庫の棚番を取得
        '' ''**********************************************************
        ' ''cboFRAC_RETU.Enabled = True     '列
        ' ''cboFRAC_REN.Enabled = True      '連
        ' ''cboFRAC_DAN.Enabled = True      '段
        ' ''cboFRAC_EDA.Enabled = True      '枝

        ' ''Call gobjComFuncFRM.InitRetuRenDan_TrkBufNo_FRM303010(FTRK_BUF_NO_J9000.ToString _
        ' ''      , cboFRAC_RETU _
        ' ''      , cboFRAC_REN _
        ' ''      , cboFRAC_DAN _
        ' ''      , cboFRAC_EDA _
        ' ''      , blnSingle _
        ' ''      )


        ' ''cboFRAC_RETU.SelectedIndex = 0   '列
        ' ''cboFRAC_REN.SelectedIndex = 0    '連
        ' ''cboFRAC_DAN.SelectedIndex = 0    '段
        ' ''cboFRAC_EDA.SelectedIndex = 0    '枝

    End Sub
#End Region

#Region "　連続入庫設定確認                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 連続入庫設定確認
    ''' </summary>
    ''' <param name="strFTRK_BUF_NO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function CheckContinueState(ByVal strFTRK_BUF_NO As String) As Boolean

        Dim blnReturn As Boolean                 '値有無ﾌﾗｸﾞ
        blnReturn = False

        mblnContinueEnable = False              '連続入庫不可ST

        Dim strFARRIVEDT As String = ""           '在庫発生日時
        Dim strXPROD_LINE As String = ""           '生産ﾗｲﾝNo.
        Dim strXKENSA_KUBUN As String = ""       '検査区分
        Dim strFIN_KUBUN As String = ""   '入庫区分
        Dim strXMAKER_CD As String = ""         'ﾒｰｶｰｺｰﾄﾞ
        Dim strFHORYU_KUBUN As String = ""      '保留区分
        Dim strXKENPIN_KUBUN As String = ""   '検品区分


        '**********************************************************
        ' 生産入庫設定を取得
        '**********************************************************
        Dim intRet As RetCode
        Dim objTBL_XSTS_PRODUCT_IN As TBL_XSTS_PRODUCT_IN                               '生産入庫設定状態
        objTBL_XSTS_PRODUCT_IN = New TBL_XSTS_PRODUCT_IN(gobjOwner, gobjDb, Nothing)
        objTBL_XSTS_PRODUCT_IN.FTRK_BUF_NO = strFTRK_BUF_NO                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        intRet = objTBL_XSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN(False)
        If intRet = RetCode.OK Then
            '(ﾃﾞｰﾀ有り)
            mstrFEQ_ID = objTBL_XSTS_PRODUCT_IN.FEQ_ID
            mintXPROGRESS = objTBL_XSTS_PRODUCT_IN.XPROGRESS
            mintDSPGRID_DISPLAYINDEX = objTBL_XSTS_PRODUCT_IN.FGRID_DISPLAYINDEX


            If IsNull(objTBL_XSTS_PRODUCT_IN.FHINMEI_CD) = False Then
                '(品名ｺｰﾄﾞ設定時)
                mstrFHINMEI_CD = objTBL_XSTS_PRODUCT_IN.FHINMEI_CD
                strFARRIVEDT = TO_STRING(objTBL_XSTS_PRODUCT_IN.FARRIVE_DT)
                strXPROD_LINE = TO_STRING(objTBL_XSTS_PRODUCT_IN.XPROD_LINE)
                strXKENSA_KUBUN = TO_STRING(objTBL_XSTS_PRODUCT_IN.XKENSA_KUBUN)
                strFIN_KUBUN = TO_STRING(objTBL_XSTS_PRODUCT_IN.FIN_KUBUN)
                strXMAKER_CD = TO_STRING(objTBL_XSTS_PRODUCT_IN.XMAKER_CD)
                strFHORYU_KUBUN = TO_STRING(objTBL_XSTS_PRODUCT_IN.FHORYU_KUBUN)
                strXKENPIN_KUBUN = TO_STRING(objTBL_XSTS_PRODUCT_IN.XKENPIN_KUBUN)
                blnReturn = True      '連続入庫中
            End If

            mblnContinueEnable = True           '連続入庫可能ST
        End If


        '**********************************************************
        ' ｺﾝﾄﾛｰﾙの設定
        '**********************************************************
        If blnReturn = False Then
            '(通常状態)
            lblContinue.Visible = False                     '連続入庫中
            If TO_STRING(cboFTRK_BUF_NO_ZAIKO.SelectedValue) = FTRK_BUF_NO_J9000 Then   '棚ﾌﾞﾛｯｸ
                rbtnXDSPIN_SITEI_BLOCK.Enabled = True
            Else
                rbtnXDSPIN_SITEI_BLOCK.Enabled = False
            End If
            If cboFHINMEI_CD.Enabled = False Then           '品名ｺｰﾄﾞ
                cboFHINMEI_CD.Enabled = True
                cboFHINMEI_CD.Text = ""
            End If
            If dtpFARRIVE_DT.Enabled = False Then           '在庫発生日時
                dtpFARRIVE_DT.Enabled = True
                Dim dtmNow As Date = Now
                dtpFARRIVE_DT.cmpMDateTimePicker_D.Value = dtmNow
                dtpFARRIVE_DT.userChecked = False
            End If
            If cboXPROD_LINE.Enabled = False Then           '生産ﾗｲﾝNo.
                cboXPROD_LINE.Enabled = True
                cboXPROD_LINE.SelectedIndex = -1
            End If
            If cboXKENSA_KUBUN.Enabled = False Then         '検査区分
                cboXKENSA_KUBUN.Enabled = True
                cboXKENSA_KUBUN.SelectedIndex = 0
            End If
            If cboFIN_KUBUN.Enabled = False Then            '入庫区分
                cboFIN_KUBUN.Enabled = True
                cboFIN_KUBUN.SelectedIndex = 0
            End If
            If cboXMAKER_CD.Enabled = False Then            'ﾒｰｶｰｺｰﾄﾞ
                cboXMAKER_CD.Enabled = True
                cboXMAKER_CD.SelectedIndex = 0
            End If
            If cboFHORYU_KUBUN.Enabled = False Then         '保留区分
                cboFHORYU_KUBUN.Enabled = True
                cboFHORYU_KUBUN.SelectedIndex = 0
            End If
            If cboXKENPIN_KUBUN.Enabled = False Then        '検品区分
                cboXKENPIN_KUBUN.Enabled = True
                cboXKENPIN_KUBUN.SelectedIndex = 0
            End If

        Else
            '(連続入庫状態)
            lblContinue.Visible = True                      '連続入庫中
            rbtnXDSPIN_SITEI_None.Checked = True            '棚指定なし
            rbtnXDSPIN_SITEI_BLOCK.Enabled = False          '棚ﾌﾞﾛｯｸ
            cboFHINMEI_CD.Text = mstrFHINMEI_CD             '品名ｺｰﾄﾞ
            cboFHINMEI_CD.Enabled = False
            If strFARRIVEDT <> "" Then
                Dim dtmVal As Date = strFARRIVEDT               '在庫発生日時
                dtpFARRIVE_DT.cmpMDateTimePicker_D.Value = dtmVal
            End If
            dtpFARRIVE_DT.userChecked = False
            dtpFARRIVE_DT.Enabled = False
            If strXPROD_LINE <> "" Then
                cboXPROD_LINE.Text = strXPROD_LINE     '生産ﾗｲﾝNo.
                Dim i As Integer = 0
                For i = 0 To cboXPROD_LINE.Items.Count - 1
                    Dim XPROD_LINE As String
                    XPROD_LINE = TO_STRING(cboXPROD_LINE.Items(i)("NAME").ToString)
                    If XPROD_LINE = strXPROD_LINE Then
                        cboXPROD_LINE.SelectedIndex = i
                    End If
                Next

            End If
            cboXPROD_LINE.Enabled = False
            If strXKENSA_KUBUN <> "" Then
                cboXKENSA_KUBUN.SelectedValue = strXKENSA_KUBUN '検査区分
            End If
            cboXKENSA_KUBUN.Enabled = False
            If strFIN_KUBUN <> "" Then
                cboFIN_KUBUN.SelectedValue = strFIN_KUBUN       '入庫区分
            End If
            cboFIN_KUBUN.Enabled = False
            If strXMAKER_CD <> "" Then
                cboXMAKER_CD.SelectedValue = strXMAKER_CD       'ﾒｰｶｰｺｰﾄﾞ
            End If
            cboXMAKER_CD.Enabled = False
            If strFHORYU_KUBUN <> "" Then
                cboFHORYU_KUBUN.SelectedValue = strFHORYU_KUBUN '保留区分
            End If
            cboFHORYU_KUBUN.Enabled = False
            If strXKENPIN_KUBUN <> "" Then
                cboXKENPIN_KUBUN.SelectedValue = strXKENPIN_KUBUN '検品区分
            End If
            cboXKENPIN_KUBUN.Enabled = False

        End If

        CheckContinueState = blnReturn

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
                SubItem2 = TO_STRING(objRow("XMAKER_CD"))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = SubItem2

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
