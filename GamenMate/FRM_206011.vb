'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】品名ﾏｽﾀﾒﾝﾃﾅﾝｽ子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_206011

#Region "  共通変数　                           "

    Private mFlag_Form_Load As Boolean = True       '画面展開ﾌﾗｸﾞ

    'ﾃｰﾌﾞﾙｸﾗｽ
    Dim mobjTMST_ITEM As TBL_TMST_ITEM              '品名ﾏｽﾀ

    'ﾌﾟﾛﾊﾟﾃｨ
    Dim mintButtonMode As Integer                   'ﾎﾞﾀﾝﾓｰﾄﾞ
    Private mstrFHINMEI_CD As String                '品名ｺｰﾄﾞ

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                        "
    ' ﾎﾞﾀﾝﾓｰﾄﾞ
    Public Property userButtonMode() As Integer
        Get
            Return mintButtonMode
        End Get
        Set(ByVal Value As Integer)
            mintButtonMode = Value
        End Set
    End Property

    '品名ｺｰﾄﾞ
    Public Property userFHINMEI_CD() As String
        Get
            Return mstrFHINMEI_CD
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD = value
        End Set
    End Property
#End Region
#Region "  ｲﾍﾞﾝﾄ                                "
#Region " ﾌｫｰﾑﾛｰﾄﾞ                              "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_206011_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " ﾌｫｰﾑｱﾝﾛｰﾄﾞ                            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_206011_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  実行ﾎﾞﾀﾝｸﾘｯｸ                         "
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
#Region "　ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                   "
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
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                           "
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
#Region "  ﾌｫｰﾑﾛｰﾄﾞ     処理                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub LoadProcess()

        '**********************************************************
        ' 品目ﾏｽﾀ情報の特定
        '**********************************************************
        mobjTMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
        If IsNull(mstrFHINMEI_CD) = False Then
            mobjTMST_ITEM.FHINMEI_CD = mstrFHINMEI_CD               '品番
            mobjTMST_ITEM.GET_TMST_ITEM(False)
        End If


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
        ' 棚形状種別ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboFRAC_FORM, True, mobjTMST_ITEM.FRAC_FORM)
        ' 品目種別ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboXARTICLE_TYPE_CODE, True, mobjTMST_ITEM.XARTICLE_TYPE_CODE)
        ' 空棚引当ﾀｲﾌﾟｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboXIN_RES_TYPE, True, mobjTMST_ITEM.XIN_RES_TYPE)


        '**********************************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ                 ｾｯﾄ
        '**********************************************************
        txtXHINMEI_CD.Text = TO_STRING(mobjTMST_ITEM.XHINMEI_CD)                    '品名ｺｰﾄﾞ
        txtFHINMEI_CD.Text = TO_STRING(mstrFHINMEI_CD)                              '品名記号
        txtFHINMEI.Text = TO_STRING(mobjTMST_ITEM.FHINMEI)                          '品名
        txtFNUM_IN_PALLET.Value = TO_STRING(mobjTMST_ITEM.FNUM_IN_PALLET)           'PL毎積載量(ﾊﾟﾚｯﾄ積付数)
        txtXPLANE_PACK_NUMBER.Text = TO_STRING(mobjTMST_ITEM.XPLANE_PACK_NUMBER)    '平面梱数
        txtXWEIGHT_IN_CASE.Text = TO_STRING(mobjTMST_ITEM.XWEIGHT_IN_CASE)          '梱重量
        txtXHEIGHT_IN_CASE.Text = TO_STRING(mobjTMST_ITEM.XHEIGHT_IN_CASE)          '梱高さ
        txtXWEIGHT_IN_PALLET.Text = TO_STRING(mobjTMST_ITEM.XWEIGHT_IN_PALLET)      'ﾊﾟﾚｯﾄあたりの重量(1PL当重量)
        txtXDAN_IN_PALLET.Text = TO_STRING(mobjTMST_ITEM.XDAN_IN_PALLET)            '1ﾊﾟﾚｯﾄの段数(1PL当段数)
        txtXHEIGHT_IN_PALLET.Text = TO_STRING(mobjTMST_ITEM.XHEIGHT_IN_PALLET)      'ﾊﾟﾚｯﾄ高さ(1PL当高さ)

        txtXSUB_CD.Text = TO_STRING(mobjTMST_ITEM.XSUB_CD)                          'ｻﾌﾞｺｰﾄﾞ
        txtXITF_CD.Text = TO_STRING(mobjTMST_ITEM.XITF_CD)                          'ITFｺｰﾄﾞ
        txtXJAN_CD.Text = TO_STRING(mobjTMST_ITEM.XJAN_CD)                          'JANｺｰﾄﾞ
        txtXMAKER_CD.Text = TO_STRING(mobjTMST_ITEM.XMAKER_CD)                      'ﾒｰｶｰｺｰﾄﾞ

        '===================================
        ' ｺﾝﾄﾛｰﾙﾏｽｸ処理
        '===================================
        Call ControlEnable()


        mFlag_Form_Load = False


    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub ClosingProcess()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        txtFHINMEI_CD.Dispose()
        txtXHINMEI_CD.Dispose()
        txtFHINMEI.Dispose()
        txtFNUM_IN_PALLET.Dispose()
        txtXPLANE_PACK_NUMBER.Dispose()
        txtXWEIGHT_IN_CASE.Dispose()
        txtXHEIGHT_IN_CASE.Dispose()
        txtXWEIGHT_IN_PALLET.Dispose()
        txtXDAN_IN_PALLET.Dispose()
        txtXHEIGHT_IN_PALLET.Dispose()
        txtXSUB_CD.Dispose()
        txtXITF_CD.Dispose()
        txtXJAN_CD.Dispose()
        txtXMAKER_CD.Dispose()

        cboFRAC_FORM.Dispose()
        cboXARTICLE_TYPE_CODE.Dispose()
        cboXIN_RES_TYPE.Dispose()

    End Sub
#End Region
#Region "  実行         ﾎﾞﾀﾝ押下処理            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdZikkou_ClickProcess()

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
#Region "　ｷｬﾝｾﾙ        ﾎﾞﾀﾝ押下処理            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        Me.Close()

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                           "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Protected Overridable Function InputCheck() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)

                '========================================
                '品名ｺｰﾄﾞ
                '========================================
                If txtXHINMEI_CD.Text.Trim = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '品名記号
                '========================================
                If txtFHINMEI_CD.Text.Trim = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_09, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '品名記号重複ﾁｪｯｸ
                '========================================
                Dim objTMST_ITEM As New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)       '品名ﾏｽﾀ
                Dim intRet As Integer
                objTMST_ITEM.FHINMEI_CD = txtFHINMEI_CD.Text                            '品名ｺｰﾄﾞ
                intRet = objTMST_ITEM.GET_TMST_ITEM(False)                              '特定
                If intRet = RetCode.OK Then
                    '(入力された品名記号が登録されている場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD_MSG_07, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If
                Dim intCount As Integer = 0
                objTMST_ITEM.CLEAR_PROPERTY()
                objTMST_ITEM.XHINMEI_CD = txtXHINMEI_CD.Text                            '品名ｺｰﾄﾞ
                intCount = objTMST_ITEM.GET_TMST_ITEM_COUNT
                If 0 < intCount Then
                    '(品名ﾏｽﾀが存在した場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD_MSG_03, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '品名記号内容ﾁｪｯｸ
                '========================================
                If IsNumeric(txtFHINMEI_CD.Text.Substring(0, 1)) = True Then
                    '(1文字目が数値の場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD_MSG_08, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '品名
                '========================================
                If txtFHINMEI.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                'PL毎積載数(ﾊﾟﾚｯﾄ積付数)
                '========================================
                If (txtFNUM_IN_PALLET.Value = "") Or _
                   (TO_DECIMAL(txtFNUM_IN_PALLET.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '棚形状種別
                '========================================
                If cboFRAC_FORM.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_08, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '品目種別
                '========================================
                If cboXARTICLE_TYPE_CODE.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_03, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '平面梱数
                '========================================
                If (txtXPLANE_PACK_NUMBER.Value = "") Or _
                   (TO_DECIMAL(txtXPLANE_PACK_NUMBER.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_04, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '梱重量
                '========================================
                If (txtXWEIGHT_IN_CASE.Value = "") Or _
                   (TO_DECIMAL(txtXWEIGHT_IN_CASE.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_10, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '梱高さ
                '========================================
                If (txtXHEIGHT_IN_CASE.Value = "") Or _
                   (TO_DECIMAL(txtXHEIGHT_IN_CASE.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_11, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '1PL当重量
                '========================================
                If (txtXWEIGHT_IN_PALLET.Value = "") Or _
                   (TO_DECIMAL(txtXWEIGHT_IN_PALLET.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_12, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '1PL当段数
                '========================================
                If (txtXDAN_IN_PALLET.Value = "") Or _
                   (TO_DECIMAL(txtXDAN_IN_PALLET.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_13, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '1PL当高さ
                '========================================
                If (txtXHEIGHT_IN_PALLET.Value = "") Or _
                   (TO_DECIMAL(txtXHEIGHT_IN_PALLET.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_14, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '' ''========================================
                '' ''ｻﾌﾞｺｰﾄﾞ
                '' ''========================================
                ' ''If (txtXSUB_CD.Value = "") Then
                ' ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_15, _
                ' ''                      PopupFormType.Ok, _
                ' ''                      PopupIconType.Information)
                ' ''    Exit Select
                ' ''End If

                '' ''========================================
                '' ''ITFｺｰﾄﾞ
                '' ''========================================
                ' ''If (txtXITF_CD.Text.Trim = "") Then
                ' ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_16, _
                ' ''                      PopupFormType.Ok, _
                ' ''                      PopupIconType.Information)
                ' ''    Exit Select
                ' ''End If

                '' ''========================================
                '' ''JANｺｰﾄﾞ
                '' ''========================================
                ' ''If (txtXJAN_CD.Text.Trim = "") Then
                ' ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_17, _
                ' ''                      PopupFormType.Ok, _
                ' ''                      PopupIconType.Information)
                ' ''    Exit Select
                ' ''End If

                '========================================
                '空棚引当ﾀｲﾌﾟ
                '========================================
                If cboXIN_RES_TYPE.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_20, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                blnCheckErr = False


            Case BUTTONMODE_UPDATE
                '(変更の場合)

                '========================================
                '品名
                '========================================
                If txtFHINMEI.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                'PL毎積載数(ﾊﾟﾚｯﾄ積付数)
                '========================================
                If (txtFNUM_IN_PALLET.Value = "") Or _
                   (TO_DECIMAL(txtFNUM_IN_PALLET.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '棚形状種別
                '========================================
                If cboFRAC_FORM.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_08, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '品目種別
                '========================================
                If cboXARTICLE_TYPE_CODE.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_03, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '平面梱数
                '========================================
                If (txtXPLANE_PACK_NUMBER.Value = "") Or _
                   (TO_DECIMAL(txtXPLANE_PACK_NUMBER.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_04, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '梱重量
                '========================================
                If (txtXWEIGHT_IN_CASE.Value = "") Or _
                   (TO_DECIMAL(txtXWEIGHT_IN_CASE.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_10, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '梱高さ
                '========================================
                If (txtXHEIGHT_IN_CASE.Value = "") Or _
                   (TO_DECIMAL(txtXHEIGHT_IN_CASE.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_11, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '1PL当重量
                '========================================
                If (txtXWEIGHT_IN_PALLET.Value = "") Or _
                   (TO_DECIMAL(txtXWEIGHT_IN_PALLET.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_12, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '1PL当段数
                '========================================
                If (txtXDAN_IN_PALLET.Value = "") Or _
                   (TO_DECIMAL(txtXDAN_IN_PALLET.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_13, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '1PL当高さ
                '========================================
                If (txtXHEIGHT_IN_PALLET.Value = "") Or _
                   (TO_DECIMAL(txtXHEIGHT_IN_PALLET.Value) = 0) Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_14, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '' ''========================================
                '' ''ｻﾌﾞｺｰﾄﾞ
                '' ''========================================
                ' ''If (txtXSUB_CD.Value = "") Then
                ' ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_15, _
                ' ''                      PopupFormType.Ok, _
                ' ''                      PopupIconType.Information)
                ' ''    Exit Select
                ' ''End If

                '' ''========================================
                '' ''ITFｺｰﾄﾞ
                '' ''========================================
                ' ''If (txtXITF_CD.Text.Trim = "") Then
                ' ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_16, _
                ' ''                      PopupFormType.Ok, _
                ' ''                      PopupIconType.Information)
                ' ''    Exit Select
                ' ''End If

                '' ''========================================
                '' ''JANｺｰﾄﾞ
                '' ''========================================
                ' ''If (txtXJAN_CD.Text.Trim = "") Then
                ' ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_17, _
                ' ''                      PopupFormType.Ok, _
                ' ''                      PopupIconType.Information)
                ' ''    Exit Select
                ' ''End If

                '========================================
                '空棚引当ﾀｲﾌﾟ
                '========================================
                If cboXIN_RES_TYPE.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206011_20, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
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
#Region "　ｺﾝﾄﾛｰﾙﾏｽｸ処理　                      "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub ControlEnable()

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)

                txtFHINMEI_CD.Enabled = True                    '品名ｺｰﾄﾞ
                txtXHINMEI_CD.Enabled = True                    '品名記号
                txtFHINMEI.Enabled = True                       '品名
                txtFNUM_IN_PALLET.Enabled = True                'PL毎積載数(ﾊﾟﾚｯﾄ積付数)
                txtXPLANE_PACK_NUMBER.Enabled = True            '平面梱数
                txtXWEIGHT_IN_CASE.Enabled = True               '梱重量
                txtXHEIGHT_IN_CASE.Enabled = True               '梱高さ
                txtXWEIGHT_IN_PALLET.Enabled = True             'ﾊﾟﾚｯﾄあたりの重量(1PL当重量)
                txtXDAN_IN_PALLET.Enabled = True                '1ﾊﾟﾚｯﾄの段数(1PL当段数)
                txtXHEIGHT_IN_PALLET.Enabled = True             'ﾊﾟﾚｯﾄ高さ(1PL当高さ)
                txtXSUB_CD.Enabled = True                       'ｻﾌﾞｺｰﾄﾞ
                txtXITF_CD.Enabled = True                       'ITFｺｰﾄﾞ
                txtXJAN_CD.Enabled = True                       'JANｺｰﾄﾞ
                'txtXMAKER_CD.Text = True                        'ﾒｰｶｰｺｰﾄﾞ
                cboFRAC_FORM.Enabled = True                     '棚形状種別
                cboXARTICLE_TYPE_CODE.Enabled = True            '品目種別
                cboXIN_RES_TYPE.Enabled = True                  '空棚引当ﾀｲﾌﾟ

                Exit Select

            Case BUTTONMODE_UPDATE
                '(変更の場合)

                txtFHINMEI_CD.Enabled = False                   '品名ｺｰﾄﾞ
                txtXHINMEI_CD.Enabled = False                   '品名記号
                txtFHINMEI.Enabled = True                       '品名
                txtFNUM_IN_PALLET.Enabled = True                'PL毎積載数(ﾊﾟﾚｯﾄ積付数)
                txtXPLANE_PACK_NUMBER.Enabled = True            '平面梱数
                txtXWEIGHT_IN_CASE.Enabled = True               '梱重量
                txtXHEIGHT_IN_CASE.Enabled = True               '梱高さ
                txtXWEIGHT_IN_PALLET.Enabled = True             'ﾊﾟﾚｯﾄあたりの重量(1PL当重量)
                txtXDAN_IN_PALLET.Enabled = True                '1ﾊﾟﾚｯﾄの段数(1PL当段数)
                txtXHEIGHT_IN_PALLET.Enabled = True             'ﾊﾟﾚｯﾄ高さ(1PL当高さ)
                txtXSUB_CD.Enabled = True                       'ｻﾌﾞｺｰﾄﾞ
                txtXITF_CD.Enabled = True                       'ITFｺｰﾄﾞ
                txtXJAN_CD.Enabled = True                       'JANｺｰﾄﾞ
                'txtXMAKER_CD.Text = True                        'ﾒｰｶｰｺｰﾄﾞ
                cboFRAC_FORM.Enabled = True                     '棚形状種別
                cboXARTICLE_TYPE_CODE.Enabled = True            '品目種別
                cboXIN_RES_TYPE.Enabled = True                  '空棚引当ﾀｲﾌﾟ

                Exit Select

            Case BUTTONMODE_DELETE
                '(削除の場合)

                txtFHINMEI_CD.Enabled = False                   '品名ｺｰﾄﾞ
                txtXHINMEI_CD.Enabled = False                   '品名記号
                txtFHINMEI.Enabled = False                      '品名
                txtFNUM_IN_PALLET.Enabled = False               'PL毎積載数(ﾊﾟﾚｯﾄ積付数)
                txtXPLANE_PACK_NUMBER.Enabled = False           '平面梱数
                txtXWEIGHT_IN_CASE.Enabled = False              '梱重量
                txtXHEIGHT_IN_CASE.Enabled = False              '梱高さ
                txtXWEIGHT_IN_PALLET.Enabled = False            'ﾊﾟﾚｯﾄあたりの重量(1PL当重量)
                txtXDAN_IN_PALLET.Enabled = False               '1ﾊﾟﾚｯﾄの段数(1PL当段数)
                txtXHEIGHT_IN_PALLET.Enabled = False            'ﾊﾟﾚｯﾄ高さ(1PL当高さ)
                txtXSUB_CD.Enabled = False                      'ｻﾌﾞｺｰﾄﾞ
                txtXITF_CD.Enabled = False                      'ITFｺｰﾄﾞ
                txtXJAN_CD.Enabled = False                      'JANｺｰﾄﾞ
                'txtXMAKER_CD.Text = False                       'ﾒｰｶｰｺｰﾄﾞ
                cboFRAC_FORM.Enabled = False                    '棚形状種別
                cboXARTICLE_TYPE_CODE.Enabled = False           '品目種別
                cboXIN_RES_TYPE.Enabled = False                 '空棚引当ﾀｲﾌﾟ

                Exit Select

        End Select

    End Sub
#End Region
#Region "  ｿｹｯﾄ送信                             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub SendSocket01()


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


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strDIR_KUBUN As String = ""             '処理区分
        Dim strXHINMEI_CD As String = ""            '品名ｺｰﾄﾞ
        Dim strFHINMEI_CD As String = ""            '品名記号
        Dim strFHINMEI As String = ""               '品名
        Dim strFNUM_IN_PALLET As String = ""        'PL毎積載数(ﾊﾟﾚｯﾄ積付数)
        Dim strFRAC_FORM As String = ""             '棚形状種別
        Dim strXPLANE_PACK_NUMBER As String = ""    '平面梱数
        Dim strXWEIGHT_IN_CASE As String = ""       '梱重量
        Dim strXHEIGHT_IN_CASE As String = ""       '梱高さ
        Dim strXWEIGHT_IN_PALLET As String = ""     'ﾊﾟﾚｯﾄあたりの重量(1PL当重量)
        Dim strXDAN_IN_PALLET As String = ""        '1ﾊﾟﾚｯﾄの段数(1PL当段数)
        Dim strXHEIGHT_IN_PALLET As String = ""     'ﾊﾟﾚｯﾄ高さ(1PL当高さ)
        Dim strXARTICLE_TYPE_CODE As String = ""    '品目種別
        Dim strXSUB_CD As String = ""               'ｻﾌﾞｺｰﾄﾞ
        Dim strXITF_CD As String = ""               'ITFｺｰﾄﾞ
        Dim strXJAN_CD As String = ""               'JANｺｰﾄﾞ
        Dim strXMAKER_CD As String = ""             'ﾒｰｶｰｺｰﾄﾞ
        Dim strXIN_RES_TYPE As String = ""          '空棚引当ﾀｲﾌﾟ


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S201901                  'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        strXHINMEI_CD = TO_STRING(txtXHINMEI_CD.Text)                               '品名ｺｰﾄﾞ
        strFHINMEI_CD = TO_STRING(txtFHINMEI_CD.Text)                               '品名記号
        strFHINMEI = TO_STRING(txtFHINMEI.Text)                                     '品名
        strFNUM_IN_PALLET = TO_STRING(txtFNUM_IN_PALLET.Value)                      'PL毎積載数(ﾊﾟﾚｯﾄ積付数)
        strFRAC_FORM = TO_STRING(cboFRAC_FORM.SelectedValue)                        '棚形状種別
        strXPLANE_PACK_NUMBER = TO_STRING(txtXPLANE_PACK_NUMBER.Text)               '平面梱数
        strXWEIGHT_IN_CASE = TO_STRING(txtXWEIGHT_IN_CASE.Text)                     '梱重量
        strXHEIGHT_IN_CASE = TO_STRING(txtXHEIGHT_IN_CASE.Text)                     '梱高さ
        strXWEIGHT_IN_PALLET = TO_STRING(txtXWEIGHT_IN_PALLET.Text)                 'ﾊﾟﾚｯﾄあたりの重量(1PL当重量)
        strXDAN_IN_PALLET = TO_STRING(txtXDAN_IN_PALLET.Text)                       '1ﾊﾟﾚｯﾄの段数(1PL当段数)
        strXHEIGHT_IN_PALLET = TO_STRING(txtXHEIGHT_IN_PALLET.Text)                 'ﾊﾟﾚｯﾄ高さ(1PL当高さ)
        strXARTICLE_TYPE_CODE = TO_STRING(cboXARTICLE_TYPE_CODE.SelectedValue)      '品目種別
        strXSUB_CD = TO_STRING(txtXSUB_CD.Text)                                     'ｻﾌﾞｺｰﾄﾞ
        strXITF_CD = TO_STRING(txtXITF_CD.Text)                                     'ITFｺｰﾄﾞ
        strXJAN_CD = TO_STRING(txtXJAN_CD.Text)                                     'JANｺｰﾄﾞ
        strXMAKER_CD = TO_STRING(txtXMAKER_CD.Text)                                 'ﾒｰｶｰｺｰﾄﾞ
        strXIN_RES_TYPE = TO_STRING(cboXIN_RES_TYPE.SelectedValue)                  '空棚引当ﾀｲﾌﾟ

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)
                strDIR_KUBUN = TO_STRING(BUTTONMODE_ADD)            '指示区分
            Case BUTTONMODE_UPDATE
                '(変更の場合)
                strDIR_KUBUN = TO_STRING(BUTTONMODE_UPDATE)         '指示区分
            Case BUTTONMODE_DELETE
                '(削除の場合)
                strDIR_KUBUN = TO_STRING(BUTTONMODE_DELETE)         '指示区分
        End Select

        objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                        '指示区分
        objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)                       '品名ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPHINMEI_CD", strXHINMEI_CD)                      '品名記号
        objTelegram.SETIN_DATA("DSPHINMEI", strFHINMEI)                             '品名
        objTelegram.SETIN_DATA("DSPNUM_IN_PALLET", strFNUM_IN_PALLET)               'PL毎積載数(ﾊﾟﾚｯﾄ積付数)
        objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                         '棚形状種別
        objTelegram.SETIN_DATA("XDSPPLANE_PACK_NUMBER", strXPLANE_PACK_NUMBER)      '平面梱数
        objTelegram.SETIN_DATA("XDSPWEIGHT_IN_CASE", strXWEIGHT_IN_CASE)            '梱重量
        objTelegram.SETIN_DATA("XDSPHEIGHT_IN_CASE", strXHEIGHT_IN_CASE)            '梱高さ
        objTelegram.SETIN_DATA("XDSPWEIGHT_IN_PALLET", strXWEIGHT_IN_PALLET)        'ﾊﾟﾚｯﾄあたりの重量(1PL当重量)
        objTelegram.SETIN_DATA("XDSPDAN_IN_PALLET", strXDAN_IN_PALLET)              '1ﾊﾟﾚｯﾄの段数(1PL当段数)
        objTelegram.SETIN_DATA("XDSPHEIGHT_IN_PALLET", strXHEIGHT_IN_PALLET)        'ﾊﾟﾚｯﾄ高さ(1PL当高さ)
        objTelegram.SETIN_DATA("XDSPARTICLE_TYPE_CODE", strXARTICLE_TYPE_CODE)      '品目種別
        objTelegram.SETIN_DATA("XDSPSUB_CD", strXSUB_CD)                            'ｻﾌﾞｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPITF_CD", strXITF_CD)                            'ITFｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPJAN_CD", strXJAN_CD)                            'JANｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPMAKER_CD", strXMAKER_CD)                        'ﾒｰｶｰｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPIN_RES_TYPE", strXIN_RES_TYPE)                  '空棚引当ﾀｲﾌﾟ

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                   'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = cmdZikkou.Text & FRM_MSG_FRM200000_14
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

End Class
