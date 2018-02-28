'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】入庫設定画面 子画面 入庫設定
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_303011
#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrST_FM As String                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
    Protected mstrST_TO As String                       '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
    Protected mstrPALLET_ID As String                   'ﾊﾟﾚｯﾄID
    Protected mstrLOT_NO_STOCK As String                '在庫ﾛｯﾄ№
    Protected mstrTR_VOL As String                      '搬送管理量
    Protected mstrIN_KIND As String                     '入庫種別
    Protected mstrIN_SITEI As String                    '入庫指定
    Protected mstrARRIVE_DT As String                   '在庫発生日時
    Protected mstrPROD_LINE As String                   '生産ﾗｲﾝ№
    Protected mstrMAKER_CD As String                    'ﾒｰｶｰｺｰﾄﾞ
    Protected mstrKENSA_KUBUN As String                 '検査区分
    Protected mstrHORYU_KUBUN As String                 '保留区分
    Protected mstrIN_KUBUN As String                    '入庫区分
    Protected mstrKENPIN_KUBUN As String                '検品区分
    Protected mstrTANA_BLOCK As String                  '棚ﾌﾞﾛｯｸ

    Protected mstrFRAC_RETU As String                   '列
    Protected mstrFRAC_REN As String                    '連
    Protected mstrFRAC_DAN As String                    '段

    Protected mstrFTRK_BUF_NO_Disp As String            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.(表示用)
    Protected mstrFHINMEI_CD As String                  '品名ｺｰﾄﾞ(表示用)
    Protected mstrFHINMEI As String                     '品名(表示用)

    Protected mstrFTRK_BUF_NO_Nyuko As String           '入庫ST ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.

    Private mintFNUM_IN_PL As Integer                   'PL毎積載量

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        NyuukoSet_Click                 '入庫設定
        CancelBtn_Click                 'ｷｬﾝｾﾙ
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "

    ''' =======================================
    ''' <summary>搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userST_FM() As String
        Get
            Return mstrST_FM
        End Get
        Set(ByVal value As String)
            mstrST_FM = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userST_TO() As String
        Get
            Return mstrST_TO
        End Get
        Set(ByVal value As String)
            mstrST_TO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾊﾟﾚｯﾄID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPALLET_ID() As String
        Get
            Return mstrPALLET_ID
        End Get
        Set(ByVal value As String)
            mstrPALLET_ID = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>在庫ﾛｯﾄNo.</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userLOT_NO_STOCK() As String
        Get
            Return mstrLOT_NO_STOCK
        End Get
        Set(ByVal value As String)
            mstrLOT_NO_STOCK = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>搬送管理量</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userTR_VOLD() As String
        Get
            Return mstrTR_VOL
        End Get
        Set(ByVal value As String)
            mstrTR_VOL = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>入庫種別</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userIN_KIND() As String
        Get
            Return mstrIN_KIND
        End Get
        Set(ByVal value As String)
            mstrIN_KIND = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>入庫指定</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userIN_SITEI() As String
        Get
            Return mstrIN_SITEI
        End Get
        Set(ByVal value As String)
            mstrIN_SITEI = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>在庫発生日時</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userARRIVE_DT() As String
        Get
            Return mstrARRIVE_DT
        End Get
        Set(ByVal value As String)
            mstrARRIVE_DT = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>生産ﾗｲﾝNo.</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPROD_LINE() As String
        Get
            Return mstrPROD_LINE
        End Get
        Set(ByVal value As String)
            mstrPROD_LINE = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾒｰｶｰｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userMAKER_CD() As String
        Get
            Return mstrMAKER_CD
        End Get
        Set(ByVal value As String)
            mstrMAKER_CD = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>検査区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userKENSA_KUBUN() As String
        Get
            Return mstrKENSA_KUBUN
        End Get
        Set(ByVal value As String)
            mstrKENSA_KUBUN = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>保留区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userHORYU_KUBUN() As String
        Get
            Return mstrHORYU_KUBUN
        End Get
        Set(ByVal value As String)
            mstrHORYU_KUBUN = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>入庫区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userIN_KUBUN() As String
        Get
            Return mstrIN_KUBUN
        End Get
        Set(ByVal value As String)
            mstrIN_KUBUN = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>検品区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userKENPIN_KUBUN() As String
        Get
            Return mstrKENPIN_KUBUN
        End Get
        Set(ByVal value As String)
            mstrKENPIN_KUBUN = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>棚ﾌﾞﾛｯｸ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userTANA_BLOCK() As String
        Get
            Return mstrTANA_BLOCK
        End Get
        Set(ByVal value As String)
            mstrTANA_BLOCK = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>列</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFRAC_RETU() As String
        Get
            Return mstrFRAC_RETU
        End Get
        Set(ByVal value As String)
            mstrFRAC_RETU = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>連</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFRAC_REN() As String
        Get
            Return mstrFRAC_REN
        End Get
        Set(ByVal value As String)
            mstrFRAC_REN = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>段</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFRAC_DAN() As String
        Get
            Return mstrFRAC_DAN
        End Get
        Set(ByVal value As String)
            mstrFRAC_DAN = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>入庫ST(表示用)</summary>
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

    ''' =======================================
    ''' <summary>品名ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHINMEI_CD() As String
        Get
            Return mstrFHINMEI_CD
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>品名(表示用)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHINMEI() As String
        Get
            Return mstrFHINMEI
        End Get
        Set(ByVal value As String)
            mstrFHINMEI = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>入庫ST ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFTRK_BUF_NO_Nyuko() As String
        Get
            Return mstrFTRK_BUF_NO_Nyuko
        End Get
        Set(ByVal value As String)
            mstrFTRK_BUF_NO_Nyuko = value
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
    Private Sub FRM_303011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub FRM_303011_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　入庫設定   　ﾎﾞﾀﾝ押下                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdNyuukoSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNyuukoSet.Click
        Try

            Call cmdNyuukoSet_ClickProcess()


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
    Private Sub FRM_303011_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
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

        If mstrST_TO = FTRK_BUF_NO_J9000 Then
            '(在庫ｴﾘｱが自動倉庫の場合)

            '===================================
            '入庫ST ｾｯﾄ
            '===================================
            lblST_NAME.Text = "入庫ST:"

            ' ''txtFULL_PL.Visible = False
            ' ''cboFULL_PL.Visible = True

        ElseIf mstrST_TO = FTRK_BUF_NO_J9100 Or _
                mstrST_TO = FTRK_BUF_NO_J9200 Then
            '(在庫ｴﾘｱが平置き or 検品の場合)

            '===================================
            '入庫ST ｾｯﾄ
            '===================================
            lblST_NAME.Text = "在庫ｴﾘｱ:"

            ' ''txtFULL_PL.Visible = True
            ' ''cboFULL_PL.Visible = False

        End If

        '===================================
        'ST名 ｾｯﾄ
        '===================================
        lblST_VALUE.Text = mstrFTRK_BUF_NO_Disp

        '===================================
        '品名ｺｰﾄﾞ ｾｯﾄ
        '===================================
        lblFHINMEI_CD.Text = mstrFHINMEI_CD

        '===================================
        '品名 ｾｯﾄ
        '===================================
        lblFHINMEI.Text = mstrFHINMEI

        '' ''===================================
        '' '' ﾌﾙﾊﾟﾚｯﾄ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '' ''===================================
        ' ''Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFULL_PL, True)


        '********************************************************************
        ' 品目情報取得
        '********************************************************************
        Dim intRet As Integer
        Dim objTBL_TMST_ITEM As TBL_TMST_ITEM

        If IsNumeric(mstrFHINMEI_CD.Substring(0, 1)) Then
            '(品名ｺｰﾄﾞの場合)
            objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
            objTBL_TMST_ITEM.XHINMEI_CD = mstrFHINMEI_CD
            intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
            If intRet = RetCode.OK Then
                '(値がある時)
                mstrFHINMEI_CD = objTBL_TMST_ITEM.FHINMEI_CD        '品名記号
                mintFNUM_IN_PL = objTBL_TMST_ITEM.FNUM_IN_PALLET    'PL毎積載数
            End If

        Else
            '(品名記号の場合)
            objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
            objTBL_TMST_ITEM.FHINMEI_CD = mstrFHINMEI_CD
            intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
            If intRet = RetCode.OK Then
                '(値がある時)
                mintFNUM_IN_PL = objTBL_TMST_ITEM.FNUM_IN_PALLET    'PL毎積載数
            End If
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
        lblST_VALUE.Dispose()
        lblFHINMEI_CD.Dispose()
        lblFHINMEI.Dispose()
        txtHASUU_VOL.Dispose()
        txtFULL_PL.Dispose()
        ' ''cboFULL_PL.Dispose()

    End Sub
#End Region

#Region "　入庫設定        ﾎﾞﾀﾝ押下処理             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入庫設定 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdNyuukoSet_ClickProcess()

        '' ''********************************************************************
        '' '' 品名記号取得
        '' ''********************************************************************
        ' ''If IsNumeric(mstrFHINMEI_CD.Substring(0, 1)) Then
        ' ''    '(品名ｺｰﾄﾞの場合)
        ' ''    Dim intRet As Integer
        ' ''    Dim objTBL_TMST_ITEM As TBL_TMST_ITEM
        ' ''    objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
        ' ''    objTBL_TMST_ITEM.XHINMEI_CD = mstrFHINMEI_CD
        ' ''    intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
        ' ''    If intRet = RetCode.OK Then
        ' ''        '(値がある時)
        ' ''        mstrFHINMEI_CD = objTBL_TMST_ITEM.FHINMEI_CD        '品名記号
        ' ''    End If
        ' ''End If

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.NyuukoSet_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If mstrST_TO = FTRK_BUF_NO_J9000 Then
            '(自動倉庫の場合)
            If SendSocket02_TE1() = False Then
                Exit Sub
            End If

        ElseIf mstrST_TO = FTRK_BUF_NO_J9100 Or _
                mstrST_TO = FTRK_BUF_NO_J9200 Then
            '(平置き or 検品ｴﾘｱの場合)
            If SendSocket02_TE2() = False Then
                Exit Sub
            End If

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
            Case menmCheckCase.NyuukoSet_Click
                '(入庫設定の場合)

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:Dou 2014/07/02 入庫設定のﾊﾟﾚｯﾄ数の制限

                '========================================
                'PL数ﾁｪｯｸ
                '========================================
                Dim intLimit As Integer = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGJ303010_001)
                If TO_INTEGER(txtHASUU_VOL.Text) = 0 Then
                    '(端数が設定されていない場合)
                    If intLimit < TO_INTEGER(txtFULL_PL.Text) Then
                        '(上限を超えていた場合)
                        Dim strMsg As String
                        strMsg = Replace(FRM_MSG_FRM303011_08, "@@", TO_STRING(intLimit))
                        Call gobjComFuncFRM.DisplayPopup(strMsg, _
                                                         PopupFormType.Ok, _
                                                         PopupIconType.Information)
                        Exit Select
                    End If
                Else
                    '(端数が設定されている場合)
                    If intLimit - 1 < TO_INTEGER(txtFULL_PL.Text) Then
                        '(上限を超えていた場合)
                        Dim strMsg As String
                        strMsg = Replace(FRM_MSG_FRM303011_08, "@@", TO_STRING(intLimit))
                        Call gobjComFuncFRM.DisplayPopup(strMsg, _
                                                         PopupFormType.Ok, _
                                                         PopupIconType.Information)
                        Exit Select
                    End If
                End If

                '↑↑↑↑↑↑************************************************************************************************************


                '========================================
                '端量梱数
                '========================================
                If txtHASUU_VOL.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303011_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                If TO_DECIMAL(txtHASUU_VOL.Value) > mintFNUM_IN_PL Then
                    '(PL毎積載数より大きい時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303011_06, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If


                '========================================
                'ﾌﾙﾊﾟﾚｯﾄ
                '========================================
                If txtFULL_PL.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303011_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '搬送ﾊﾟﾚｯﾄ数
                '========================================
                If mstrST_TO = FTRK_BUF_NO_J9000 Then
                    '（自動倉庫の場合）
                    ' ''If TO_INTEGER(txtHASUU_VOL.Text) = 0 And _
                    ' ''    cboFULL_PL.SelectedIndex = 2 Then
                    ' ''    '(端数0、ﾊﾟﾚｯﾄ無しの場合)
                    ' ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303011_03, _
                    ' ''                      PopupFormType.Ok, _
                    ' ''                      PopupIconType.Information)
                    ' ''    Exit Select
                    ' ''End If

                    If TO_INTEGER(txtHASUU_VOL.Text) = 0 Then
                        If TO_INTEGER(txtFULL_PL.Text) = 0 Then
                            '(端数0、ﾊﾟﾚｯﾄ0の場合)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303011_03, _
                                              PopupFormType.Ok, _
                                              PopupIconType.Information)
                            Exit Select

                        ElseIf TO_INTEGER(txtFULL_PL.Text) > 40 Then
                            '(端数0、ﾊﾟﾚｯﾄが40より多い場合)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303011_07, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Information)
                            Exit Select

                        End If

                    Else

                        If TO_INTEGER(txtFULL_PL.Text) > 39 Then
                            '(端数有り、ﾊﾟﾚｯﾄが3より多い場合)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303011_07, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Information)
                            Exit Select
                        End If

                    End If

                ElseIf mstrST_TO = FTRK_BUF_NO_J9100 Or _
                        mstrST_TO = FTRK_BUF_NO_J9200 Then
                    '（平置き、検品ｴﾘｱの場合）

                    If TO_INTEGER(txtHASUU_VOL.Text) = 0 And _
                       TO_INTEGER(txtFULL_PL.Text) = 0 Then
                        '(端数0、ﾊﾟﾚｯﾄ0の場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303011_03, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If

                End If


                '************************************************
                'ﾄﾗｯｷﾝｸﾞ            ﾁｪｯｸ
                '************************************************
                If mstrST_TO = FTRK_BUF_NO_J9000 Then

                    Dim intCountZaiko As Integer = 0
                    Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)

                    '=======================================
                    '入庫ST ﾄﾗｯｷﾝｸﾞ
                    '=======================================
                    objTPRG_TRK_BUF.FTRK_BUF_NO = mstrFTRK_BUF_NO_Nyuko                 '入庫ST ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    intCountZaiko = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_COUNT_ZAIKO()      '取得
                    If intCountZaiko <> 0 Then
                        '(何かしらのﾄﾗｯｷﾝｸﾞがある場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303011_04, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Information)
                        Exit Select
                    End If

                    '=======================================
                    'ｺﾝﾍﾞﾔ関連付け ﾄﾗｯｷﾝｸﾞ
                    '=======================================
                    intCountZaiko = 0
                    objTPRG_TRK_BUF.CLEAR_PROPERTY()
                    objTPRG_TRK_BUF.FTRK_BUF_NO = mstrST_FM                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    intCountZaiko = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_COUNT_ZAIKO()      '取得
                    If intCountZaiko <> 0 Then
                        '(何かしらのﾄﾗｯｷﾝｸﾞがある場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303011_04, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Information)
                        Exit Select
                    End If

                End If

                '************************************************
                ' 連続入庫設定        ﾁｪｯｸ
                '************************************************
                If mstrST_TO = FTRK_BUF_NO_J9000 Then
                    If CheckContinueState(mstrFTRK_BUF_NO_Nyuko) = True Then
                        '(連続入庫設定中の場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303011_05, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Information)
                        Exit Select
                    End If
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

#Region "  ｿｹｯﾄ送信02 (自動倉庫)                  "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function SendSocket02_TE1() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Dim strMsg As String = ""

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        strMsg = ""
        strMsg &= FRM_MSG_FRM303010_05
        udtRet = gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If

        '********************************************************************
        ' 入庫設定ﾃﾞｰﾀ
        '********************************************************************
        Dim strSndTlgrm() As String = Nothing               '送信電文文字列
        Dim intHairetu As Integer = 0                       '配列数

        Dim strDSPST_FM = ""                                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        Dim strDSPST_TO = ""                                '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        Dim strDSPPALLET_ID = ""                            'ﾊﾟﾚｯﾄID
        Dim strDSPLOT_NO_STOCK = ""                         '在庫ﾛｯﾄ№
        Dim strDSPHINMEI_CD = ""                            '品名ｺｰﾄﾞ
        Dim strDSPTR_VOL = ""                               '搬送管理量
        Dim strXDSPIN_KIND = ""                             '入庫種別
        Dim strXDSPIN_SITEI = ""                            '入庫指定
        Dim strDSPARRIVE_DT = ""                            '在庫発生日時
        Dim strXDSPPROD_LINE = ""                           '生産ﾗｲﾝ№
        Dim strXMAKER_CD = ""                               'ﾒｰｶｰｺｰﾄﾞ
        Dim strXDSPKENSA_KUBUN = ""                         '検査区分
        Dim strDSPHORYU_KUBUN = ""                          '保留区分
        Dim strDSPIN_KUBUN = ""                             '入庫区分
        Dim strXDSPKENPIN_KUBUN = ""                        '検品区分
        Dim strXDSPTANA_BLOCK = ""                          '棚ﾌﾞﾛｯｸ

        Dim strDSPTR_VOL_HASUU = ""                         '端数
        Dim blnHASUUFlag As Boolean = False                 '端数ﾌﾗｸﾞ

        Dim blnPareFlag As Boolean = False                  'ﾍﾟｱ入庫ﾌﾗｸﾞ

        Dim intALL_PL_Count As Integer = 0                  '搬送ﾊﾟﾚｯﾄ数

        Dim intPL_VOL As Integer
        Dim intHASUU_VOL As Integer

        '********************************************************************
        ' ﾊﾟﾚｯﾄ+端数ﾃﾞｰﾀｾｯﾄ 
        '********************************************************************
        'If cboFULL_PL.SelectedValue = 0 Then
        '    intPL_VOL = 1
        'Else
        '    intPL_VOL = 0
        'End If
        intPL_VOL = TO_INTEGER(txtFULL_PL.Text)

        intHASUU_VOL = TO_INTEGER(txtHASUU_VOL.Text)

        If intHASUU_VOL = 0 Then
            blnHASUUFlag = False        '端数無
            intALL_PL_Count = intPL_VOL
        Else
            blnHASUUFlag = True         '端数有
            intALL_PL_Count = intPL_VOL + 1
        End If

        '**********************************************************
        ' 共通入庫設定ﾃﾞｰﾀｾｯﾄ
        '**********************************************************
        strDSPST_FM = mstrST_FM                 '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        strDSPST_TO = mstrST_TO                 '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№

        strDSPPALLET_ID = ""                    'ﾊﾟﾚｯﾄID
        strDSPLOT_NO_STOCK = ""                 '在庫ﾛｯﾄ№
        strDSPHINMEI_CD = mstrFHINMEI_CD        '品名ｺｰﾄﾞ

        strXDSPIN_SITEI = mstrIN_SITEI          '棚ﾌﾞﾛｯｸ指定

        strDSPARRIVE_DT = mstrARRIVE_DT         '在庫発生日時

        strXDSPPROD_LINE = mstrPROD_LINE        '生産ﾗｲﾝ№
        strXMAKER_CD = mstrMAKER_CD             'ﾒｰｶｰｺｰﾄﾞ
        strXDSPKENSA_KUBUN = mstrKENSA_KUBUN    '検査区分
        strDSPHORYU_KUBUN = mstrHORYU_KUBUN     '保留区分
        strDSPIN_KUBUN = mstrIN_KUBUN           '入庫区分
        strXDSPKENPIN_KUBUN = mstrKENPIN_KUBUN  '検品区分
        strDSPTR_VOL_HASUU = intHASUU_VOL       '端量梱数

        '**********************************************************
        ' 棚ﾌﾞﾛｯｸの特定 
        '**********************************************************
        If strXDSPIN_SITEI = 1 Then

            Dim intRet2 As RetCode
            Dim objTBL_TPRG_TRK_BUF As TBL_TPRG_TRK_BUF
            objTBL_TPRG_TRK_BUF = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
            objTBL_TPRG_TRK_BUF.FRAC_RETU = mstrFRAC_RETU           '列
            objTBL_TPRG_TRK_BUF.FRAC_REN = mstrFRAC_REN             '連
            objTBL_TPRG_TRK_BUF.FRAC_DAN = mstrFRAC_DAN             '段
            objTBL_TPRG_TRK_BUF.FRAC_EDA = "0"                      '枝

            intRet2 = objTBL_TPRG_TRK_BUF.GET_TPRG_TRK_BUF(False)
            If intRet2 = RetCode.OK Then
                '(値がある時)
                strXDSPTANA_BLOCK = objTBL_TPRG_TRK_BUF.XTANA_BLOCK        '棚ﾌﾞﾛｯｸ
            Else
                '(読めなかった時)
                strMsg = "ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧに、棚ﾌﾞﾛｯｸが見つかりませんでした。" & _
                         "[棚番:" & mstrFRAC_RETU & "-" & mstrFRAC_REN & "-" & mstrFRAC_DAN & "]"
                Throw New System.Exception(strMsg)
            End If

        Else
            strXDSPTANA_BLOCK = ""

        End If

        '**********************************************************
        ' 搬送管理量の特定
        '**********************************************************
        Dim intRet3 As RetCode
        Dim objTBL_TMST_ITEM As TBL_TMST_ITEM
        objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
        objTBL_TMST_ITEM.FHINMEI_CD = strDSPHINMEI_CD        '品名ｺｰﾄﾞ
        intRet3 = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
        If intRet3 = RetCode.OK Then
            '(値がある時)
            strDSPTR_VOL = objTBL_TMST_ITEM.FNUM_IN_PALLET        'PL毎積載数
        Else
            '(読めなかった時)
            strMsg = "品目ﾏｽﾀに、PL毎積載数が見つかりませんでした。" & _
                     "[品目ｺｰﾄﾞ:" & strDSPHINMEI_CD & "]"
            Throw New System.Exception(strMsg)
        End If


        '********************************************************************
        ' 入庫設定用 電文作成
        '********************************************************************
        '送信電文
        ReDim strSndTlgrm(0)

        For ii As Integer = 1 To intALL_PL_Count Step 2
            '(ﾊﾟﾚｯﾄ数分ﾙｰﾌﾟ)
            If ii + 1 <= intALL_PL_Count Then
                blnPareFlag = True
            Else
                blnPareFlag = False
            End If


            '配列再定義
            ReDim Preserve strSndTlgrm(0 To intHairetu)         '送信電文文字列

            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400001

            objTelegramSub.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegramSub.FORMAT_ID, 6)) 'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                           '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                           '担当者ｺｰﾄﾞ

            objTelegramSub.SETIN_DATA("DSPST_FM", strDSPST_FM)                  '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            objTelegramSub.SETIN_DATA("DSPST_TO", strDSPST_TO)                  '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)          'ﾊﾟﾚｯﾄID
            objTelegramSub.SETIN_DATA("DSPLOT_NO_STOCK", strDSPLOT_NO_STOCK)    '在庫ﾛｯﾄ№

            If blnPareFlag = True Then
                objTelegramSub.SETIN_DATA("DSPSAGYOU_KIND", TO_STRING(FSAGYOU_KIND_J53))      '作業種別 ﾛｰｶﾙ入庫(ﾍﾟｱ)
            Else
                objTelegramSub.SETIN_DATA("DSPSAGYOU_KIND", TO_STRING(FSAGYOU_KIND_J54))      '作業種別 ﾛｰｶﾙ入庫(ｼﾝｸﾞﾙ)
            End If
            objTelegramSub.SETIN_DATA("DSPHINMEI_CD", strDSPHINMEI_CD)          '品名ｺｰﾄﾞ

            If blnHASUUFlag = True Then
                '(端数がある場合)
                If ii <> intALL_PL_Count Then
                    objTelegramSub.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL)        '搬送管理量
                Else
                    objTelegramSub.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL_HASUU)  '搬送管理量 端数
                End If

            Else
                objTelegramSub.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL)            '搬送管理量

            End If


            If blnPareFlag = True Then
                objTelegramSub.SETIN_DATA("XDSPIN_KIND", 1)                     '入庫種別
            Else
                objTelegramSub.SETIN_DATA("XDSPIN_KIND", 0)                     '入庫種別
            End If

            objTelegramSub.SETIN_DATA("XDSPIN_SITEI", strXDSPIN_SITEI)          '入庫指定

            objTelegramSub.SETIN_DATA("DSPARRIVE_DT", strDSPARRIVE_DT)          '在庫発生日時
            objTelegramSub.SETIN_DATA("XDSPPROD_LINE", strXDSPPROD_LINE)        '生産ﾗｲﾝ№
            objTelegramSub.SETIN_DATA("XDSPMAKER_CD", strXMAKER_CD)             'ﾒｰｶｰｺｰﾄﾞ
            objTelegramSub.SETIN_DATA("XDSPKENSA_KUBUN", strXDSPKENSA_KUBUN)    '検査区分
            objTelegramSub.SETIN_DATA("DSPHORYU_KUBUN", strDSPHORYU_KUBUN)      '保留区分
            objTelegramSub.SETIN_DATA("DSPIN_KUBUN", strDSPIN_KUBUN)            '入庫区分
            objTelegramSub.SETIN_DATA("XDSPKENPIN_KUBUN", strXDSPKENPIN_KUBUN)  '検品区分

            If blnPareFlag = True Then
                '(ﾍﾟｱ入庫の場合)
                If blnHASUUFlag = True Then
                    '(端数がある場合)
                    If ii + 1 <> intALL_PL_Count Then
                        objTelegramSub.SETIN_DATA("XDSPTR_VOL_KO", strDSPTR_VOL)        '搬送管理量(子)
                    Else
                        objTelegramSub.SETIN_DATA("XDSPTR_VOL_KO", strDSPTR_VOL_HASUU)  '搬送管理量(子) 端数
                    End If

                Else
                    objTelegramSub.SETIN_DATA("XDSPTR_VOL_KO", strDSPTR_VOL)            '搬送管理量(子)

                End If


            End If

            objTelegramSub.SETIN_DATA("XDSPTANA_BLOCK", strXDSPTANA_BLOCK)      '棚ﾌﾞﾛｯｸ


            objTelegramSub.MAKE_TELEGRAM()
            strSndTlgrm(intHairetu) = objTelegramSub.TELEGRAM_MAKED             '送信電文

            intHairetu = intHairetu + 1
        Next


        '********************************************************************
        ' ｿｹｯﾄ送信処理
        '********************************************************************
        Dim strRetState() As String = Nothing               '出庫処理戻りｽﾃｰﾀｽ
        Dim strErrMsg As String = ""                        'ｴﾗｰﾒｯｾｰｼﾞ
        Dim udtSckSendRET As clsSocketClient.RetCode        'ｿｹｯﾄ送信戻り値
        Dim strRET_STATE As String = ""

        Dim objTelegramNull As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegramNull.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400001

        '=====================================
        '複数ｿｹｯﾄ処理
        '=====================================
        strErrMsg = FRM_MSG_FRM303010_06
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegramNull, strSndTlgrm, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
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

#Region "  ｿｹｯﾄ送信02 (平置き or 検品ｴﾘｱ)             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function SendSocket02_TE2() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Dim strMsg As String = ""

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        strMsg = ""
        strMsg &= FRM_MSG_FRM303010_05
        udtRet = gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If

        '********************************************************************
        ' 入庫設定ﾃﾞｰﾀ
        '********************************************************************
        Dim strSndTlgrm() As String = Nothing               '送信電文文字列
        Dim intHairetu As Integer = 0                       '配列数

        Dim strDSPST_FM = ""                                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        Dim strDSPST_TO = ""                                '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        Dim strDSPPALLET_ID = ""                            'ﾊﾟﾚｯﾄID
        Dim strDSPLOT_NO_STOCK = ""                         '在庫ﾛｯﾄ№
        Dim strDSPHINMEI_CD = ""                            '品名ｺｰﾄﾞ
        Dim strDSPTR_VOL = ""                               '搬送管理量
        Dim strXDSPIN_KIND = ""                             '入庫種別
        Dim strXDSPIN_SITEI = ""                            '入庫指定
        Dim strDSPARRIVE_DT = ""                            '在庫発生日時
        Dim strXDSPPROD_LINE = ""                           '生産ﾗｲﾝ№
        Dim strXMAKER_CD = ""                               'ﾒｰｶｰｺｰﾄﾞ
        Dim strXDSPKENSA_KUBUN = ""                         '検査区分
        Dim strDSPHORYU_KUBUN = ""                          '保留区分
        Dim strDSPIN_KUBUN = ""                             '入庫区分
        Dim strXDSPKENPIN_KUBUN = ""                        '検品区分
        Dim strXDSPTANA_BLOCK = ""                          '棚ﾌﾞﾛｯｸ

        Dim intFULL_PL_Count As Integer = 0                 'ﾌﾙﾊﾟﾚｯﾄ数
        Dim intHASUU_VOL As Integer                         '端数

        '********************************************************************
        ' ﾊﾟﾚｯﾄ数+端数ﾃﾞｰﾀｾｯﾄ 
        '********************************************************************
        intFULL_PL_Count = TO_INTEGER(txtFULL_PL.Text)
        intHASUU_VOL = TO_INTEGER(txtHASUU_VOL.Text)

        '**********************************************************
        ' 共通入庫設定ﾃﾞｰﾀｾｯﾄ
        '**********************************************************
        strDSPST_FM = mstrST_FM                 '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        strDSPST_TO = mstrST_TO                 '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        strDSPPALLET_ID = ""                    'ﾊﾟﾚｯﾄID
        strDSPLOT_NO_STOCK = ""                 '在庫ﾛｯﾄ№
        strDSPHINMEI_CD = mstrFHINMEI_CD        '品名ｺｰﾄﾞ
        strXDSPIN_SITEI = mstrIN_SITEI          '棚ﾌﾞﾛｯｸ指定
        strDSPARRIVE_DT = mstrARRIVE_DT         '在庫発生日時
        strXDSPPROD_LINE = mstrPROD_LINE        '生産ﾗｲﾝ№
        strXMAKER_CD = mstrMAKER_CD             'ﾒｰｶｰｺｰﾄﾞ
        strXDSPKENSA_KUBUN = mstrKENSA_KUBUN    '検査区分
        strDSPHORYU_KUBUN = mstrHORYU_KUBUN     '保留区分
        strDSPIN_KUBUN = mstrIN_KUBUN           '入庫区分
        strXDSPKENPIN_KUBUN = mstrKENPIN_KUBUN  '検品区分
        strXDSPTANA_BLOCK = ""                  '棚ﾌﾞﾛｯｸ


        '**********************************************************
        ' 搬送管理量の特定
        '**********************************************************
        Dim intRet3 As RetCode
        Dim objTBL_TMST_ITEM As TBL_TMST_ITEM
        objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
        objTBL_TMST_ITEM.FHINMEI_CD = strDSPHINMEI_CD        '品名ｺｰﾄﾞ
        intRet3 = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
        If intRet3 = RetCode.OK Then
            '(値がある時)
            strDSPTR_VOL = objTBL_TMST_ITEM.FNUM_IN_PALLET        'PL毎積載数
        Else
            '(読めなかった時)
            strMsg = "品目ﾏｽﾀに、PL毎積載数が見つかりませんでした。" & _
                     "[品目ｺｰﾄﾞ:" & strDSPHINMEI_CD & "]"
            Throw New System.Exception(strMsg)
        End If


        '********************************************************************
        ' 入庫設定用 電文作成
        '********************************************************************
        '送信電文
        ReDim strSndTlgrm(0)

        For ii As Integer = 1 To intFULL_PL_Count
            '(ﾊﾟﾚｯﾄ数分ﾙｰﾌﾟ)

            '配列再定義
            ReDim Preserve strSndTlgrm(0 To intHairetu)         '送信電文文字列

            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400001

            objTelegramSub.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegramSub.FORMAT_ID, 6)) 'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                           '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                           '担当者ｺｰﾄﾞ

            objTelegramSub.SETIN_DATA("DSPST_FM", strDSPST_FM)                          '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            objTelegramSub.SETIN_DATA("DSPST_TO", strDSPST_TO)                          '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)                  'ﾊﾟﾚｯﾄID
            objTelegramSub.SETIN_DATA("DSPLOT_NO_STOCK", strDSPLOT_NO_STOCK)            '在庫ﾛｯﾄ№
            objTelegramSub.SETIN_DATA("DSPSAGYOU_KIND", TO_STRING(FSAGYOU_KIND_J54))    '作業種別 ﾛｰｶﾙ入庫(ｼﾝｸﾞﾙ)
            objTelegramSub.SETIN_DATA("DSPHINMEI_CD", strDSPHINMEI_CD)                  '品名ｺｰﾄﾞ
            objTelegramSub.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL)                        '搬送管理量
            objTelegramSub.SETIN_DATA("XDSPIN_KIND", TO_STRING(XDSPIN_KIND_SINGLE))     '入庫種別
            objTelegramSub.SETIN_DATA("XDSPIN_SITEI", strXDSPIN_SITEI)                  '入庫指定
            objTelegramSub.SETIN_DATA("DSPARRIVE_DT", strDSPARRIVE_DT)                  '在庫発生日時
            objTelegramSub.SETIN_DATA("XDSPPROD_LINE", strXDSPPROD_LINE)                '生産ﾗｲﾝ№
            objTelegramSub.SETIN_DATA("XDSPMAKER_CD", strXMAKER_CD)                     'ﾒｰｶｰｺｰﾄﾞ
            objTelegramSub.SETIN_DATA("XDSPKENSA_KUBUN", strXDSPKENSA_KUBUN)            '検査区分
            objTelegramSub.SETIN_DATA("DSPHORYU_KUBUN", strDSPHORYU_KUBUN)              '保留区分
            objTelegramSub.SETIN_DATA("DSPIN_KUBUN", strDSPIN_KUBUN)                    '入庫区分
            objTelegramSub.SETIN_DATA("XDSPKENPIN_KUBUN", strXDSPKENPIN_KUBUN)          '検品区分
            objTelegramSub.SETIN_DATA("XDSPTANA_BLOCK", strXDSPTANA_BLOCK)              '棚ﾌﾞﾛｯｸ

            objTelegramSub.MAKE_TELEGRAM()
            strSndTlgrm(intHairetu) = objTelegramSub.TELEGRAM_MAKED             '送信電文

            intHairetu = intHairetu + 1
        Next


        '********************************************************************
        ' 入庫設定端数用 電文作成
        '********************************************************************
        If intHASUU_VOL > 0 Then
            '(端数がある場合)

            '配列再定義
            ReDim Preserve strSndTlgrm(0 To intHairetu)         '送信電文文字列

            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400001

            objTelegramSub.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegramSub.FORMAT_ID, 6)) 'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                           '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                           '担当者ｺｰﾄﾞ

            objTelegramSub.SETIN_DATA("DSPST_FM", strDSPST_FM)                          '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            objTelegramSub.SETIN_DATA("DSPST_TO", strDSPST_TO)                          '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)                  'ﾊﾟﾚｯﾄID
            objTelegramSub.SETIN_DATA("DSPLOT_NO_STOCK", strDSPLOT_NO_STOCK)            '在庫ﾛｯﾄ№
            objTelegramSub.SETIN_DATA("DSPSAGYOU_KIND", TO_STRING(FSAGYOU_KIND_J54))    '作業種別 ﾛｰｶﾙ入庫(ｼﾝｸﾞﾙ)
            objTelegramSub.SETIN_DATA("DSPHINMEI_CD", strDSPHINMEI_CD)                  '品名ｺｰﾄﾞ
            objTelegramSub.SETIN_DATA("DSPTR_VOL", TO_STRING(intHASUU_VOL))             '搬送管理量
            objTelegramSub.SETIN_DATA("XDSPIN_KIND", TO_STRING(XDSPIN_KIND_SINGLE))     '入庫種別
            objTelegramSub.SETIN_DATA("XDSPIN_SITEI", strXDSPIN_SITEI)                  '入庫指定
            objTelegramSub.SETIN_DATA("DSPARRIVE_DT", strDSPARRIVE_DT)                  '在庫発生日時
            objTelegramSub.SETIN_DATA("XDSPPROD_LINE", strXDSPPROD_LINE)                '生産ﾗｲﾝ№
            objTelegramSub.SETIN_DATA("XDSPMAKER_CD", strXMAKER_CD)                     'ﾒｰｶｰｺｰﾄﾞ
            objTelegramSub.SETIN_DATA("XDSPKENSA_KUBUN", strXDSPKENSA_KUBUN)            '検査区分
            objTelegramSub.SETIN_DATA("DSPHORYU_KUBUN", strDSPHORYU_KUBUN)              '保留区分
            objTelegramSub.SETIN_DATA("DSPIN_KUBUN", strDSPIN_KUBUN)                    '入庫区分
            objTelegramSub.SETIN_DATA("XDSPKENPIN_KUBUN", strXDSPKENPIN_KUBUN)          '検品区分
            objTelegramSub.SETIN_DATA("XDSPTANA_BLOCK", strXDSPTANA_BLOCK)              '棚ﾌﾞﾛｯｸ

            objTelegramSub.MAKE_TELEGRAM()
            strSndTlgrm(intHairetu) = objTelegramSub.TELEGRAM_MAKED             '送信電文

        End If

        '********************************************************************
        ' ｿｹｯﾄ送信処理
        '********************************************************************
        Dim strRetState() As String = Nothing               '出庫処理戻りｽﾃｰﾀｽ
        Dim strErrMsg As String = ""                        'ｴﾗｰﾒｯｾｰｼﾞ
        Dim udtSckSendRET As clsSocketClient.RetCode        'ｿｹｯﾄ送信戻り値
        Dim strRET_STATE As String = ""

        Dim objTelegramNull As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegramNull.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400001

        '=====================================
        '複数ｿｹｯﾄ処理
        '=====================================
        strErrMsg = FRM_MSG_FRM303010_06
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegramNull, strSndTlgrm, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
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
            If IsNull(objTBL_XSTS_PRODUCT_IN.FHINMEI_CD) = False Then
                '(品名ｺｰﾄﾞ設定時)
                blnReturn = True      '連続入庫中
            End If
        End If

        CheckContinueState = blnReturn

    End Function
#End Region

End Class
