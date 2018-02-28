'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】在庫ﾒﾝﾃﾅﾝｽ子画面(禁止棚一括設定)
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_205042

#Region "  共通変数　                               "

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrFTRK_BUF_NO As String                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№


    'ﾃｰﾌﾞﾙｸﾗｽ
    Dim mobjTMST_TRK As TBL_TMST_TRK            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        Setutei_Click         '禁止設定ﾎﾞﾀﾝｸﾘｯｸ時
        Kaijyo_Click          '禁止解除ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum


#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "

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

#End Region
#Region "　ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_205042_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub FRM_205042_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  禁止設定ﾎﾞﾀﾝｸﾘｯｸ                         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdSetutei_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetutei.Click
        Try

            Call cmdSetutei_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  禁止解除ﾎﾞﾀﾝｸﾘｯｸ                         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdKaijyo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKaijyo.Click
        Try

            Call cmdKaijyo_ClickProcess()

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
#Region "　列 FROM ﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ              "
    Private Sub txtRETU_FM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRETU_S.GotFocus
        Try
            chkRETU.Checked = True
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　連 FROM ﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ              "
    Private Sub txtREN_FM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREN_S.GotFocus
        Try
            chkREN.Checked = True
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　段 FROM ﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ              "
    Private Sub txtDAN_FM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDAN_S.GotFocus
        Try
            chkDAN.Checked = True
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　列 TO ﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ                "
    Private Sub txtRETU_TO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRETU_E.GotFocus
        Try
            chkRETU.Checked = True
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　連 TO ﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ                "
    Private Sub txtREN_TO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREN_E.GotFocus
        Try
            chkREN.Checked = True
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　段 TO ﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ                "
    Private Sub txtDAN_TO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDAN_E.GotFocus
        Try
            chkDAN.Checked = True
        Catch ex As Exception
            ComError(ex)
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
        ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀの特定
        '**********************************************************
        mobjTMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
        mobjTMST_TRK.FTRK_BUF_NO = mstrFTRK_BUF_NO           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        mobjTMST_TRK.GET_TMST_TRK(False)


        '**********************************************************
        ' ｺﾝﾄﾛｰﾙ初期化
        '**********************************************************
        chkRETU.Checked = False
        chkREN.Checked = False
        chkDAN.Checked = False

        txtRETU_S.Text = ""
        txtRETU_E.Text = ""
        txtREN_S.Text = ""
        txtREN_E.Text = ""
        txtDAN_S.Text = ""
        txtDAN_E.Text = ""


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
        chkRETU.Dispose()
        chkREN.Dispose()
        chkDAN.Dispose()
        txtRETU_S.Dispose()
        txtRETU_E.Dispose()
        txtREN_S.Dispose()
        txtREN_E.Dispose()
        txtDAN_S.Dispose()
        txtDAN_E.Dispose()

    End Sub
#End Region
#Region "  禁止設定     ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 禁止設定         ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSetutei_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Setutei_Click) = False Then
            Exit Sub
        End If


        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        Call SendSocket01(FREMOVE_KIND_SON)


    End Sub
#End Region
#Region "  禁止解除     ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 禁止解除         ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdKaijyo_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Kaijyo_Click) = False Then
            Exit Sub
        End If


        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        Call SendSocket01(FREMOVE_KIND_SNORMAL)


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
    ''' <param name="udtCheck_Case">[IN ]入力ﾁｪｯｸ判別</param>
    ''' <returns>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        'Select Case udtCheck_Case
        '    Case menmCheckCase.Setutei_Click
        '        '(禁止設定ﾎﾞﾀﾝｸﾘｯｸ時)
        Select Case "A"
            Case "A"

                If (chkRETU.Checked = False) And _
                   (chkREN.Checked = False) And _
                   (chkDAN.Checked = False) Then
                    '(選択が無い時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_05, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                If chkRETU.Checked = True Then
                    '(列が選択されている時)

                    If txtRETU_S.Text = "" Then
                        '(開始列が入力ない時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_06, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    If TO_INTEGER(txtRETU_S.Text) < 0 Then
                        '(開始列が0より小さい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_15, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    If TO_INTEGER(txtRETU_S.Text) > TO_INTEGER(mobjTMST_TRK.FRAC_RETU_MAX) Then
                        '(開始列が最大列より大きい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_15, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If


                    If txtRETU_E.Text = "" Then
                        '(終了列が入力ない時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_07, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    If TO_INTEGER(txtRETU_E.Text) < 0 Then
                        '(終了列が0より小さい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_16, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    If TO_INTEGER(txtRETU_E.Text) > TO_INTEGER(mobjTMST_TRK.FRAC_RETU_MAX) Then
                        '(終了列が最大列より大きい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_16, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    If TO_INTEGER(txtRETU_S.Text) > TO_INTEGER(txtRETU_E.Text) Then
                        '(開始列が終了列より大きい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_08, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                End If



                If chkREN.Checked = True Then
                    '(連が選択されている時)

                    If txtREN_S.Text = "" Then
                        '(開始連が入力ない時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_09, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    If TO_INTEGER(txtREN_S.Text) < 0 Then
                        '(開始連が0より小さい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_17, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    If TO_INTEGER(txtREN_S.Text) > TO_INTEGER(mobjTMST_TRK.FRAC_REN_MAX) Then
                        '(開始連が最大連より大きい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_17, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If


                    If txtREN_E.Text = "" Then
                        '(終了連が入力ない時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_10, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    If TO_INTEGER(txtREN_E.Text) < 0 Then
                        '(終了連が0より小さい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_18, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    If TO_INTEGER(txtREN_E.Text) > TO_INTEGER(mobjTMST_TRK.FRAC_REN_MAX) Then
                        '(終了連が最大連より大きい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_18, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    If TO_INTEGER(txtREN_S.Text) > TO_INTEGER(txtREN_E.Text) Then
                        '(開始連が終了連より大きい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_11, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                End If



                If chkDAN.Checked = True Then
                    '(段が選択されている時)

                    If txtDAN_S.Text = "" Then
                        '(開始段が入力ない時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_12, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    If TO_INTEGER(txtDAN_S.Text) < 0 Then
                        '(開始段が0より小さい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_19, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    If TO_INTEGER(txtDAN_S.Text) > TO_INTEGER(mobjTMST_TRK.FRAC_DAN_MAX) Then
                        '(開始段が最大段より大きい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_19, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If


                    If txtDAN_E.Text = "" Then
                        '(終了段が入力ない時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_13, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    If TO_INTEGER(txtDAN_E.Text) < 0 Then
                        '(終了段が0より小さい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_20, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    If TO_INTEGER(txtDAN_E.Text) > TO_INTEGER(mobjTMST_TRK.FRAC_DAN_MAX) Then
                        '(終了段が最大段より大きい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_20, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    If TO_INTEGER(txtDAN_S.Text) > TO_INTEGER(txtDAN_E.Text) Then
                        '(開始段が終了段より大きい時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205042_14, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

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
#Region "  ｿｹｯﾄ送信                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket01(ByVal strFREMOVE_KIND As String)

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        If strFREMOVE_KIND = FREMOVE_KIND_SON Then
            '(禁止設定の時)
            strMessage &= FRM_MSG_FRM205042_01
        Else
            '(禁止解除の時)
            strMessage &= FRM_MSG_FRM205042_03
        End If
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

        Dim strREMOVE_KIND As String = ""                           '禁止棚設定
        Dim strRETU_FROM As String = ""                             '列FROM
        Dim strRETU_TO As String = ""                               '列TO
        Dim strREN_FROM As String = ""                              '連FROM
        Dim strREN_TO As String = ""                                '連TO
        Dim strDAN_FROM As String = ""                              '段FROM
        Dim strDAN_TO As String = ""                                '段TO


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ


        strREMOVE_KIND = strFREMOVE_KIND                            '禁止棚設定
        If chkRETU.Checked = True Then
            '(列がある時)
            strRETU_FROM = txtRETU_S.Text                           '列FROM
            strRETU_TO = txtRETU_E.Text                             '列TO
        End If
        If chkREN.Checked = True Then
            '(連がある時)
            strREN_FROM = txtREN_S.Text                             '連FROM
            strREN_TO = txtREN_E.Text                               '連TO
        End If
        If chkDAN.Checked = True Then
            '(段がある時)
            strDAN_FROM = txtDAN_S.Text                             '段FROM
            strDAN_TO = txtDAN_E.Text                               '段TO
        End If


        objTelegram.SETIN_DATA("DSPREMOVE_KIND", strREMOVE_KIND)            '禁止棚設定
        objTelegram.SETIN_DATA("XDSPRAC_RETU_FROM", strRETU_FROM)           '列FROM
        objTelegram.SETIN_DATA("XDSPRAC_RETU_TO", strRETU_TO)               '列TO
        objTelegram.SETIN_DATA("XDSPRAC_REN_FROM", strREN_FROM)             '連FROM
        objTelegram.SETIN_DATA("XDSPRAC_REN_TO", strREN_TO)                 '連TO
        objTelegram.SETIN_DATA("XDSPRAC_DAN_FROM", strDAN_FROM)             '段FROM
        objTelegram.SETIN_DATA("XDSPRAC_DAN_TO", strDAN_TO)                 '段TO


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

        If strFREMOVE_KIND = FREMOVE_KIND_SON Then
            '(禁止設定の時)
            strErrMsg = FRM_MSG_FRM205042_02
        Else
            '(禁止解除の時)
            strErrMsg = FRM_MSG_FRM205042_04
        End If
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
