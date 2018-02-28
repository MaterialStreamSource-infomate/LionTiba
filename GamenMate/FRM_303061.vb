'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】倉替え設定子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_303061

#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Public mstrFPALLET_ID() As String       'ﾊﾟﾚｯﾄID
    Public mstrFTRK_BUF_NO_FM As String     '倉替え元
    Public mstrFTRK_BUF_NO_TO As String     '倉替え先

    Public mstrFTRK_BUF_NM_FM As String     '移動元
    Public mstrFTRK_BUF_NM_TO As String     '移動先
    Public mstrFHINMEI_CD As String         '品名ｺｰﾄﾞ
    Public mstrFHINMEI As String            '品名
    Public mstrXSEIZOU_DT As String         '製造年月日
    Public mstrXLINE_NO As String           'ﾗｲﾝ№
    Public mstrXSYUKKA_KAHI As String       '出荷可否
    Public mstrXHINSHITU_STS As String      '品質ｽﾃｰﾀｽ
    Public mstrFHORYU_KUBUN As String       '保留区分
    Public mstrXSYUKKA_KAHI_DSP As String   '出荷可否(表示用)
    Public mstrXHINSHITU_STS_DSP As String  '品質ｽﾃｰﾀｽ(表示用)
    Public mstrFHORYU_KUBUN_DSP As String   '保留区分(表示用)


    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol
        FPALLET_ID                  '在庫情報.          ﾊﾟﾚｯﾄID(非表示)
        FHINMEI_CD                  '在庫情報.          品名ｺｰﾄﾞ
        FHINMEI                     '品目ﾏｽﾀ.           品名
        XSEIZOU_DT                  '在庫情報.          製造年月日
        XLINE_NO                    '在庫情報.          ﾗｲﾝ№
        XSYUKKA_KAHI                '在庫情報.          出荷可否(非表示)
        XSYUKKA_KAHI_DSP            '在庫情報.          出荷可否(表示用)
        XHINSHITU_STS               '在庫情報.          品質ｽﾃｰﾀｽ(非表示)
        XHINSHITU_STS_DSP           '在庫情報.          品質ｽﾃｰﾀｽ(表示用)
        FHORYU_KUBUN                '在庫情報.          保留区分(非表示)
        FHORYU_KUBUN_DSP            '在庫情報.          保留区分(表示用)
        FTR_VOL                     '在庫情報.          搬送管理量(数量)
        FDISP_ADDRESS               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾛｹｰｼｮﾝ

        MAXCOL

    End Enum

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        OutReg_Click                    '倉替え設定ﾎﾞﾀﾝｸﾘｯｸ時
        List_Click                      'ﾘｽﾄﾎﾞﾀﾝｸﾘｯｸ時
        STModeBtn_Click                 'ﾓｰﾄﾞ切替ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    ''ｿｹｯﾄ送信情報
    'Private Structure STOCK_DATA
    '    Dim DSPPALLET_ID As String      'ﾊﾟﾚｯﾄID
    '    Dim DSPSYUKKA_KAHI As String    '出荷可否
    'End Structure
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' ======================================
    ''' <summary>ﾊﾟﾚｯﾄID</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userPALLET_ID() As String()
        Get
            Return mstrFPALLET_ID
        End Get
        Set(ByVal value As String())
            mstrFPALLET_ID = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>倉替え元</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userFTRK_BUF_NO_FM() As String
        Get
            Return mstrFTRK_BUF_NO_FM
        End Get
        Set(ByVal value As String)
            mstrFTRK_BUF_NO_FM = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>倉替え先</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userFTRK_BUF_NO_TO() As String
        Get
            Return mstrFTRK_BUF_NO_TO
        End Get
        Set(ByVal value As String)
            mstrFTRK_BUF_NO_TO = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>移動元</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userFTRK_BUF_NM_FM() As String
        Get
            Return mstrFTRK_BUF_NM_FM
        End Get
        Set(ByVal value As String)
            mstrFTRK_BUF_NM_FM = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>移動先</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userFTRK_BUF_NM_TO() As String
        Get
            Return mstrFTRK_BUF_NM_TO
        End Get
        Set(ByVal value As String)
            mstrFTRK_BUF_NM_TO = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>品名ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userFHINMEI_CD() As String
        Get
            Return mstrFHINMEI_CD
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>品名</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userFHINMEI() As String
        Get
            Return mstrFHINMEI
        End Get
        Set(ByVal value As String)
            mstrFHINMEI = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>製造年月日</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXSEIZOU_DT() As String
        Get
            Return mstrXSEIZOU_DT
        End Get
        Set(ByVal value As String)
            mstrXSEIZOU_DT = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>ﾗｲﾝ№</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXLINE_NO() As String
        Get
            Return mstrXLINE_NO
        End Get
        Set(ByVal value As String)
            mstrXLINE_NO = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>出荷可否</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXSYUKKA_KAHI() As String
        Get
            Return mstrXSYUKKA_KAHI
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_KAHI = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>品質ｽﾃｰﾀｽ</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXHINSHITU_STS() As String
        Get
            Return mstrXHINSHITU_STS
        End Get
        Set(ByVal value As String)
            mstrXHINSHITU_STS = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>保留区分</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userFHORYU_KUBUN() As String
        Get
            Return mstrFHORYU_KUBUN
        End Get
        Set(ByVal value As String)
            mstrFHORYU_KUBUN = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>出荷可否(表示用)</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXSYUKKA_KAHI_DSP() As String
        Get
            Return mstrXSYUKKA_KAHI_DSP
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_KAHI_DSP = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>品質ｽﾃｰﾀｽ(表示用)</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXHINSHITU_STS_DSP() As String
        Get
            Return mstrXHINSHITU_STS_DSP
        End Get
        Set(ByVal value As String)
            mstrXHINSHITU_STS_DSP = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>保留区分(表示用)</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userFHORYU_KUBUN_DSP() As String
        Get
            Return mstrFHORYU_KUBUN_DSP
        End Get
        Set(ByVal value As String)
            mstrFHORYU_KUBUN_DSP = value
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
    Private Sub FRM_303061_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub FRM_303061_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " 実行ﾎﾞﾀﾝｸﾘｯｸ                              "
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
#Region " 印刷ﾎﾞﾀﾝｸﾘｯｸ                              "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdList.Click
        Try

            Call cmdList_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                        "
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
#Region "　台車№ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 台車№ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFTRK_BUF_NO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                If cboFTRK_BUF_NO.Enabled = False Then
                    '(台車№ｺﾝﾎﾞ無効の時）
                    btnSTMode.Text = ""                        '台車・状態
                    btnSTMode.BackColor = gcModeColor_Black
                Else
                    '(台車№ｺﾝﾎﾞ有効の時）
                    '**********************************************************
                    ' ﾗﾍﾞﾙ設定
                    '**********************************************************
                    tmr303061.Enabled = False
                    Call gobjComFuncFRM.AlterButtonColorMOD(btnSTMode, TO_STRING(cboFTRK_BUF_NO.SelectedValue), LBL_DSPTYPE.STSNAME)
                    tmr303061.Enabled = True
                End If

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
    Private Sub tmr303061_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr303061.Tick
        Try

            tmr303061.Enabled = False

            '**************************************************
            ' ﾓｰﾄﾞ取得ﾀｲﾏｰ処理
            '**************************************************
            Call tmr303061_TickProcess()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmr303061.Enabled = True

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

        '**********************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        '===================================
        '出庫ST ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(Me.Name, cboFTRK_BUF_NO, True)

        btnSTMode.Text = ""                          '出庫ST・状態
        btnSTMode.BackColor = gcModeColor_Black

        '===================================
        '理由 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call cboFREASONSetup(cboFREASON, True, FREASON_KUBUN_JKURAGAE)     '理由

        '*********************************************
        ' ﾃｷｽﾄ ｺﾝﾄﾛｰﾙ 初期値設定
        '*********************************************
        If userFTRK_BUF_NO_FM = FTRK_BUF_NO_J9000 Then
            '(移動元が自動倉庫の時)
            lblCOMMENT.Text = FRM_MSG_FRM303061_01
            lblSyukoST.Visible = True
            cboFTRK_BUF_NO.Visible = True
            btnSTMode.Visible = True
        Else
            '(移動元が平置きの時)
            lblCOMMENT.Text = FRM_MSG_FRM303061_02
            lblSyukoST.Visible = False
            cboFTRK_BUF_NO.Visible = False
            btnSTMode.Visible = False
        End If

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        If userFTRK_BUF_NO_FM = FTRK_BUF_NO_J9000 Then
            '(移動元が自動倉庫の時)
            '**************************************************
            ' ﾓｰﾄﾞ取得ﾀｲﾏｰ処理
            '**************************************************
            Call tmr303061_TickProcess()

            '**********************************************************
            ' ﾀｲﾏｰ設定
            '**********************************************************
            tmr303061.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS303061_001))
            tmr303061.Enabled = True

        Else
            '(移動元が平置きの時)
            tmr303061.Enabled = False

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
        cboFREASON.Dispose()

    End Sub
#End Region
#Region "  実行         ﾎﾞﾀﾝ押下処理                "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdZikkou_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.OutReg_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        tmr303061.Enabled = False

        If SendSocket02() = False Then
            '(ｷｬﾝｾﾙの時)
            If userFTRK_BUF_NO_FM = FTRK_BUF_NO_J9000 Then
                '(移動元が自動倉庫の時)
                tmr303061.Enabled = True
            End If
            Exit Sub
        End If

        Me.Close()

    End Sub
#End Region
#Region "  印刷         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cmdList_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.List_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udeRet As PopupFormType
        udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_PRINT_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> PopupFormType.Ok Then
            Exit Sub
        End If

        '**********************************************************
        ' grid充填
        '**********************************************************
        Call grdListDisplay()

        '*******************************************************
        '印刷処理
        '*******************************************************
        Call PrintOutProcess()

    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ        ﾎﾞﾀﾝ押下処理                "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        tmr303061.Enabled = False
        tmr303061.Dispose()
        Me.Close()

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.OutReg_Click
                '(倉替え設定ﾎﾞﾀﾝｸﾘｯｸ時)

                'Dim intRet As RetCode
                Dim strMsg As String = ""

                '==========================
                '出庫ST  選択ﾁｪｯｸ
                '==========================
                If TO_STRING(cboFTRK_BUF_NO.SelectedValue.ToString) = CBO_ALL_VALUE _
                    Or IsNull(TO_STRING(cboFTRK_BUF_NO.SelectedValue.ToString)) = True Then
                    '(出庫STが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303061_11, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If



                If userFTRK_BUF_NO_FM = FTRK_BUF_NO_J9000 Then
                    '(移動元が自動倉庫の時)

                    '*********************************************
                    'ｸﾚｰﾝ状態ﾁｪｯｸ
                    '*********************************************
                    For ii As Integer = LBound(mstrFPALLET_ID) To UBound(mstrFPALLET_ID)
                        '(ﾙｰﾌﾟ:選択された行数)
                        Dim strFPALLET_ID As String = mstrFPALLET_ID(ii)
                        If gobjComFuncFRM.CheckOutTrkBufNo(strFPALLET_ID) = False Then
                            blnCheckErr = True
                            Exit Select
                        End If

                    Next


                    '*********************************************
                    'STﾓｰﾄﾞ ﾁｪｯｸ
                    '*********************************************
                    If gobjComFuncFRM.CheckFEQ_STS(TO_STRING(cboFTRK_BUF_NO.SelectedValue), FEQ_STS_JINOUTMODE_OUT, FRM_MSG_SYS_ERROR_27, FEQ_STS_JINOUTMODE_OUT) = False Then
                        '(STﾓｰﾄﾞがｴﾗｰの時)
                        blnCheckErr = True
                        Exit Select
                    End If

                End If


                '**********************************************************
                ' 引当処理中確認
                '**********************************************************
                If gobjComFuncFRM.KariHikiate_Syukko_Chk() = False Then
                    '(仮引当処理中の時)
                    blnCheckErr = True
                    Exit Select
                End If


                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:A.Noto 2012/12/05 理由の入力ﾁｪｯｸ
                '========================================
                '理由
                '========================================
                If cboFREASON.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303061_12, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If
                '↑↑↑↑↑↑************************************************************************************************************


                blnCheckErr = False


            Case menmCheckCase.STModeBtn_Click
                '(ﾓｰﾄﾞ切替ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                '出庫ST  選択ﾁｪｯｸ
                '==========================
                If TO_STRING(cboFTRK_BUF_NO.SelectedValue.ToString) = CBO_ALL_VALUE _
                    Or IsNull(TO_STRING(cboFTRK_BUF_NO.SelectedValue.ToString)) = True Then
                    '(出庫STが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303061_11, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                'Dim strSTMode As String = ""        '設備状態
                'strSTMode = gobjComFuncFRM.GetFEQ_STS(TO_STRING(cboFTRK_BUF_NO.SelectedValue))
                Dim intST_RtnCd As Integer = gobjComFuncFRM.GetFEQ_STS(TO_STRING(cboFTRK_BUF_NO.SelectedValue), True, False, True)
                If (intST_RtnCd <> 1) And (intST_RtnCd <> 2) Then
                    '(設備状態が変更できないとき)
                    blnCheckErr = True
                    Exit Select
                End If

                'If strSTMode = "" Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303061_04, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select
                'End If

                blnCheckErr = False


            Case menmCheckCase.List_Click
                '(ﾘｽﾄﾎﾞﾀﾝｸﾘｯｸ時)

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
#Region "  ｿｹｯﾄ送信02 (倉替え設定)                　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function SendSocket02() As Boolean

        Dim blnReturn As Boolean = False

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303061_09, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Return blnReturn
        End If


        '*******************************************************
        'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加する電文配列作成
        '*******************************************************
        Dim strSendTel() As String = Nothing

        For ii As Integer = LBound(mstrFPALLET_ID) To UBound(mstrFPALLET_ID)
            '(展開元画面の行分ﾙｰﾌﾟ)

            If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)

            '*******************************************************
            ' 電文作成
            '*******************************************************
            '========================================
            ' 変数宣言
            '========================================
            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
            Dim strDSPPALLET_ID As String = ""               'ﾊﾟﾚｯﾄID
            Dim strDSPLOT_NO_STOCK As String = ""            '在庫ﾛｯﾄ№

            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400501       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

            Dim strDSPCMD_ID As String = ""
            strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
            'ﾍｯﾀﾞﾃﾞｰﾀ
            objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'ﾕｰｻﾞID

            'ﾃﾞｰﾀ
            strDSPPALLET_ID = mstrFPALLET_ID(ii)                                'ﾊﾟﾚｯﾄID
            objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)          'ﾊﾟﾚｯﾄID

            objTelegramSub.MAKE_TELEGRAM()

            strSendTel(UBound(strSendTel)) = objTelegramSub.TELEGRAM_MAKED

        Next


        '*******************************************************
        ' 電文作成
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strDSPST_FM As String = ""        '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        Dim strDSPST_OUT As String = ""       '出庫先ST
        Dim strDSPTR_TO As String = ""        '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        Dim strDSPREASON As String = ""       '理由
        Dim strDSPSAGYOU_KIND As String = ""  '作業種別

        strDSPST_FM = mstrFTRK_BUF_NO_FM                        '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        If userFTRK_BUF_NO_FM = FTRK_BUF_NO_J9000 Then
            '(移動元が自動倉庫の時)
            strDSPST_OUT = TO_STRING(cboFTRK_BUF_NO.SelectedValue)  '出庫先ST
        Else
            '(移動元が平置きの時)
            strDSPST_OUT = ""                                       '出庫先ST
        End If

        strDSPTR_TO = mstrFTRK_BUF_NO_TO                        '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        strDSPREASON = cboFREASON.Text                          '理由


        strDSPSAGYOU_KIND = FSAGYOU_KIND_JOUT_KURA                  '倉換え出庫


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400501      'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_HEADER("DSPREASON", strDSPREASON)            '理由

        objTelegram.SETIN_DATA("DSPST_FM", strDSPST_FM)        '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        objTelegram.SETIN_DATA("DSPST_OUT", strDSPST_OUT)      '出庫先ST
        objTelegram.SETIN_DATA("DSPTR_TO", strDSPTR_TO)        '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        objTelegram.SETIN_DATA("DSPPALLET_ID", "")             'ﾊﾟﾚｯﾄID
        objTelegram.SETIN_DATA("DSPSAGYOU_KIND", strDSPSAGYOU_KIND)      '作業種別

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                    'ｴﾗｰﾒｯｾｰｼﾞ
        strErrMsg = FRM_MSG_FRM303061_10
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegram, strSendTel, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnReturn = True
            End If
        End If

        Return blnReturn

    End Function
#End Region

#Region "  ﾓｰﾄﾞ取得ﾀｲﾏｰ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 設備状態取得ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr303061_TickProcess()

        '**********************************************************
        ' ﾗﾍﾞﾙ背景色変更処理
        '**********************************************************
        Call gobjComFuncFRM.AlterButtonColorMOD(btnSTMode, TO_STRING(cboFTRK_BUF_NO.SelectedValue), LBL_DSPTYPE.STSNAME)

    End Sub
#End Region
#Region "  ﾓｰﾄﾞ切替ﾎﾞﾀﾝ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾓｰﾄﾞ切替ﾎﾞﾀﾝ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub btnSTMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSTMode.Click

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.STModeBtn_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If gobjComFuncFRM.STModeChange(TO_STRING(cboFTRK_BUF_NO.SelectedValue)) = False Then
            Exit Sub
        End If

    End Sub
#End Region

#Region "　ｸﾞﾘｯﾄﾞ表示(ﾘｽﾄ)                          "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Sub grdListDisplay()

        Dim strSQL As String                    'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    TRST_STOCK.FPALLET_ID "                     '在庫情報.          ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "  , TRST_STOCK.FHINMEI_CD "                     '在庫情報.          品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , TMST_ITEM.FHINMEI "                         '品目ﾏｽﾀ.           品名
        strSQL &= vbCrLf & "  , TRST_STOCK.XSEIZOU_DT "                     '在庫情報.          製造年月日
        strSQL &= vbCrLf & "  , TRST_STOCK.XLINE_NO "                       '在庫情報.          ﾗｲﾝ№
        strSQL &= vbCrLf & "  , TRST_STOCK.XSYUKKA_KAHI "                   '在庫情報.          出荷可否
        strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP AS XSYUKKA_KAHI_DSP "    '在庫情報.          出荷可否(表示用)
        strSQL &= vbCrLf & "  , TRST_STOCK.XHINSHITU_STS "                  '在庫情報.          品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "  , HASH02.FGAMEN_DISP AS XHINSHITU_STS_DSP "   '在庫情報.          品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "  , TRST_STOCK.FHORYU_KUBUN "                   '在庫情報.          保留区分
        strSQL &= vbCrLf & "  , HASH03.FGAMEN_DISP AS FHORYU_KUBUN_DSP "    '在庫情報.          保留区分(表示用)
        strSQL &= vbCrLf & "  , TRST_STOCK.FTR_VOL "                        '在庫情報.          搬送管理量(数量)
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF.FDISP_ADDRESS "                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾛｹｰｼｮﾝ

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TPRG_TRK_BUF "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        strSQL &= vbCrLf & "  , TRST_STOCK "                            '在庫情報
        strSQL &= vbCrLf & "  , TMST_ITEM "                             '品目ﾏｽﾀ
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TRST_STOCK", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TRST_STOCK", "XHINSHITU_STS")
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TRST_STOCK", "FHORYU_KUBUN")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 1 = 1  "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID  = TRST_STOCK.FPALLET_ID(+) "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRES_KIND = " & TO_STRING(FRES_KIND_SZAIKO)      '引当状態 = 「在庫棚」
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TRST_STOCK", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TRST_STOCK", "XHINSHITU_STS")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TRST_STOCK", "FHORYU_KUBUN")

        '----------------------------------------------
        'ﾊﾟﾚｯﾄID
        '----------------------------------------------
        strSQL &= vbCrLf & "      AND TRST_STOCK.FPALLET_ID IN ("
        For ii As Integer = LBound(mstrFPALLET_ID) To UBound(mstrFPALLET_ID)
            '(展開元画面の行分ﾙｰﾌﾟ)
            If ii = LBound(mstrFPALLET_ID) Then
                '(最初)
                strSQL &= vbCrLf & "'" & mstrFPALLET_ID(ii) & "'"
            Else
                '(2つめ以降)
                strSQL &= vbCrLf & ", '" & mstrFPALLET_ID(ii) & "'"
            End If
        Next
        strSQL &= vbCrLf & ") "

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
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub grdListSetup()

        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)

        grdList.MultiSelect = True
        'grdList.AllowUserToResizeColumns = False

    End Sub
#End Region
#Region "　印刷処理　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 印刷処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub PrintOutProcess()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_303061_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try

            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))         '発行日時

            Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", mstrFTRK_BUF_NM_FM)  '移動元
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", mstrFTRK_BUF_NM_TO)  '移動先
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText03", mstrFHINMEI_CD)      '品名ｺｰﾄﾞ
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText04", mstrFHINMEI)         '品名
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText05", mstrXSEIZOU_DT)      '製造年月日
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText06", mstrXLINE_NO)        'ﾗｲﾝ№
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText07", mstrXSYUKKA_KAHI_DSP)    '出荷可否
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText08", mstrXHINSHITU_STS_DSP)   '品質ｽﾃｰﾀｽ
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText09", mstrFHORYU_KUBUN_DSP)    '保留区分

            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList.Rows.Count - 1
                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

                objDataRow.Data00 = grdList.Item(menmListCol.FHINMEI_CD, ii).FormattedValue            '棚卸しﾘｽﾄ.  品名ｺｰﾄﾞ
                objDataRow.Data01 = grdList.Item(menmListCol.FHINMEI, ii).FormattedValue               '棚卸しﾘｽﾄ.  品名
                objDataRow.Data02 = grdList.Item(menmListCol.XSEIZOU_DT, ii).FormattedValue            '棚卸しﾘｽﾄ.  製造年月日
                objDataRow.Data03 = grdList.Item(menmListCol.XLINE_NO, ii).FormattedValue              '棚卸しﾘｽﾄ.  ﾗｲﾝ№
                objDataRow.Data04 = grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, ii).FormattedValue      '棚卸しﾘｽﾄ.  出荷可否
                objDataRow.Data05 = grdList.Item(menmListCol.XHINSHITU_STS_DSP, ii).FormattedValue     '棚卸しﾘｽﾄ.  品質ｽﾃｰﾀｽ
                objDataRow.Data06 = grdList.Item(menmListCol.FHORYU_KUBUN_DSP, ii).FormattedValue      '棚卸しﾘｽﾄ.  保留区分
                objDataRow.Data07 = grdList.Item(menmListCol.FTR_VOL, ii).FormattedValue               '棚卸しﾘｽﾄ.  C/S数
                objDataRow.Data08 = grdList.Item(menmListCol.FDISP_ADDRESS, ii).FormattedValue         '棚卸しﾘｽﾄ.  ﾛｹｰｼｮﾝ

                objDataRow.EndEdit()

                objDataSet.DataTable01.Rows.Add(objDataRow)

            Next

            '***********************************************
            ' ｸﾘｽﾀﾙﾚﾎﾟｰﾄにﾃﾞｰﾀｾｯﾄをｾｯﾄ
            '***********************************************
            objCR.SetDataSource(objDataSet)

            '***********************************************
            ' 印字
            '***********************************************
            Call gobjComFuncFRM.CRPrint(objCR)

        Catch ex As Exception
            Throw ex

        Finally
            'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
            objCR.Dispose()
            objCR = Nothing
            'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
            objDataSet.Dispose()
            objDataSet = Nothing

            Call gobjComFuncFRM.WaitFormClose()                    ' Waitﾌｫｰﾑ削除

        End Try

    End Sub
#End Region

End Class
