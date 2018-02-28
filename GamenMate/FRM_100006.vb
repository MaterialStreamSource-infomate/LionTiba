'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾊﾟｽﾜｰﾄﾞ変更画面
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports      "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports UserProcess
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_100006

#Region "  共通変数　                               "
    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrFUSER_ID As String             'ﾕｰｻﾞｰID
    Protected mstrFUSER_NAME As String           'ﾕｰｻﾞｰ名
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' =======================================
    ''' <summary>ﾕｰｻﾞｰID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFUSER_ID() As String
        Get
            Return mstrFUSER_ID
        End Get
        Set(ByVal value As String)
            mstrFUSER_ID = value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ﾕｰｻﾞｰ名</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFUSER_NAME() As String
        Get
            Return mstrFUSER_NAME
        End Get
        Set(ByVal value As String)
            mstrFUSER_NAME = value
        End Set

    End Property
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_100006_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call frmLoad()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "　変更ﾎﾞﾀﾝ押下                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 変更ﾎﾞﾀﾝ押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChange.Click

        Try

            Call cmdChange_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#Region "　ｷｬﾝｾﾙﾎﾞﾀﾝ押下                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙﾎﾞﾀﾝ押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try

            Call cmdCancel_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ処理                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmLoad()

        '*******************************************************
        ' 初期設定
        '*******************************************************
        txtFLOGIN_ID.Enabled = False
        txtFLOGIN_ID.Text = mstrFUSER_ID           'ﾕｰｻﾞｺｰﾄﾞ
        lblFUSER_NAME.Text = mstrFUSER_NAME        'ﾕｰｻﾞ名

    End Sub
#End Region
#Region "  変更         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 変更 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdChange_ClickProcess()

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
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function InputCheck() As Boolean

        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(gobjOwner, gobjDb, Nothing)     'ｼｽﾃﾑ変数

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case ""
            Case Else
                If txtFPASS_WORD.Text <> txtReFPASS_WORD.Text Then
                    '(ﾊﾟｽﾜｰﾄﾞとﾊﾟｽﾜｰﾄﾞ再入力の入力値が異なるとき)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_06, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Err)
                    blnCheckErr = True
                    Exit Select

                End If

                If txtFPASS_WORD.Text = "" Then
                    '(ﾊﾟｽﾜｰﾄﾞがﾌﾞﾗﾝｸのとき)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_07, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Err)
                    blnCheckErr = True
                    Exit Select

                End If

                If txtReFPASS_WORD.Text = "" Then
                    '(ﾊﾟｽﾜｰﾄﾞ再入力がﾌﾞﾗﾝｸのとき)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_07, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Err)
                    blnCheckErr = True
                    Exit Select

                End If

                If txtReFPASS_WORD.Text = txtFLOGIN_ID.Text _
               And objTPRG_SYS_HEN.SS000000_014 = FLAG_ON _
               Then
                    '(ﾊﾟｽﾜｰﾄﾞとﾕｰｻﾞIDが同じとき)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_16, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Err)
                    blnCheckErr = True
                    Exit Select
                End If

                If gcintPASSWORD_KETA > 0 Then
                    '(ﾊﾟｽﾜｰﾄﾞ最小桁数が0より大きいとき)
                    If (txtFPASS_WORD.Text).Length < gcintPASSWORD_KETA Then
                        '(ﾊﾟｽﾜｰﾄﾞが6文字より小さいとき)
                        Call gobjComFuncFRM.DisplayPopup(String.Format(FRM_MSG_FRM100001_12, gcintPASSWORD_KETA), _
                                        PopupFormType.Ok, _
                                        PopupIconType.Err)
                        blnCheckErr = True
                        Exit Select
                    End If
                End If

                If gcintPASSWORD_ENG = FLAG_ON Then
                    '(ﾊﾟｽﾜｰﾄﾞ英字ﾁｪｯｸﾌﾗｸﾞがONのとき)
                    If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[A-Za-z]") = False Then
                        '(ﾊﾟｽﾜｰﾄﾞに英字が含まれていないとき)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_13, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Err)
                        blnCheckErr = True
                        Exit Select
                    End If
                End If

                If gcintPASSWORD_NUM = FLAG_ON Then
                    '(ﾊﾟｽﾜｰﾄﾞ数字ﾁｪｯｸﾌﾗｸﾞがONのとき)
                    If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[0-9]") = False Then
                        '(ﾊﾟｽﾜｰﾄﾞに数字が含まれていないとき)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_14, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Err)
                        blnCheckErr = True
                        Exit Select
                    End If
                End If

                If gcintPASSWORD_KIGO = FLAG_ON Then
                    '(ﾊﾟｽﾜｰﾄﾞ記号ﾁｪｯｸﾌﾗｸﾞがONのとき)
                    If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[^a-zA-Z0-9]") = False Then
                        '(ﾊﾟｽﾜｰﾄﾞに記号が含まれていないとき)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_15, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Err)
                        blnCheckErr = True
                        Exit Select
                    End If
                End If

                If gcintPASSWORD_DAISHO = FLAG_ON Then
                    '(ﾊﾟｽﾜｰﾄﾞ大文字小文字ﾁｪｯｸﾌﾗｸﾞがONのとき)
                    If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[A-Z]") = False Then
                        '(ﾊﾟｽﾜｰﾄﾞに大文字が含まれていないとき)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_17, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Err)
                        txtFPASS_WORD.Focus()
                        Exit Function
                    End If

                    If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[a-z]") = False Then
                        '(ﾊﾟｽﾜｰﾄﾞに小文字が含まれていないとき)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_18, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Err)
                        txtFPASS_WORD.Focus()
                        Exit Function
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
    Private Sub SendSocket01()

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        Dim strDSPLOGIN_ID As String = ""           'ﾛｸﾞｲﾝﾕｰｻﾞｰID
        Dim strPASSWORD As String = ""              'ﾊﾟｽﾜｰﾄﾞ


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200003              'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        strDSPLOGIN_ID = TO_STRING(txtFLOGIN_ID.Text)       'ﾛｸﾞｲﾝﾕｰｻﾞｰID
        strPASSWORD = TO_STRING(txtFPASS_WORD.Text)         'ﾊﾟｽﾜｰﾄﾞ

        objTelegram.SETIN_DATA("DSPLOGIN_ID", strDSPLOGIN_ID)           'ﾛｸﾞｲﾝﾕｰｻﾞｰID
        objTelegram.SETIN_DATA("DSPPASS_WORD", strPASSWORD)             'ﾊﾟｽﾜｰﾄﾞ


        Dim strRET_STATE As String = ""                 '応答ｽﾃｰﾀｽ
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = FRM_MSG_FRM100001_08

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
