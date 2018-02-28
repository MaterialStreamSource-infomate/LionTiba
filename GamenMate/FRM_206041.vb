'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】理由ﾏｽﾀﾒﾝﾃﾅﾝｽ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_206041

#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrFREASON_CD As String                  '理由ｺｰﾄﾞ
    Protected mstrFREASON_KUBUN As String               '作業種別ｺｰﾄﾞ
    Protected mstrFREASON As String                     '理由

    Dim mintButtonMode As Integer                       'ﾎﾞﾀﾝﾓｰﾄﾞ

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' =======================================
    ''' <summary>理由ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFREASON_CD() As String
        Get
            Return mstrFREASON_CD
        End Get
        Set(ByVal value As String)
            mstrFREASON_CD = value
        End Set
    End Property
    ''' =======================================
    ''' <summary>作業種別ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFREASON_KUBUN() As String
        Get
            Return mstrFREASON_KUBUN
        End Get
        Set(ByVal value As String)
            mstrFREASON_KUBUN = value
        End Set
    End Property
    ''' =======================================
    ''' <summary>理由</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFREASON() As String
        Get
            Return mstrFREASON
        End Get
        Set(ByVal value As String)
            mstrFREASON = value
        End Set
    End Property
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

#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region " ﾌｫｰﾑﾛｰﾄﾞ                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_206011_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " ﾌｫｰﾑｱﾝﾛｰﾄﾞ                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_206011_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " 実行ﾎﾞﾀﾝｸﾘｯｸ                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 実行ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZikkou.Click
        Try

            Call cmdZikkou_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                        "
    '''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ ﾎﾞﾀﾝ押下
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
#Region "  ﾌｫｰﾑﾛｰﾄﾞ     処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 処理 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LoadProcess()

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
        ' ﾃｷｽﾄﾎﾞｯｸｽ                 ｾｯﾄ
        '**********************************************************
        txtOperationCD.Text = mstrFREASON_KUBUN                             '作業種別ｺｰﾄﾞ
        txtReasonCD.Text = Mid(mstrFREASON_CD, 3)                           '理由ｺｰﾄﾞ
        txtReason.Text = mstrFREASON                                        '理由


        '===================================
        ' ｺﾝﾄﾛｰﾙﾏｽｸ処理
        '===================================
        Call ControlEnable()


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
#Region "  実行         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 実行 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)
                '========================================
                '理由ｺｰﾄﾞ
                '========================================
                If txtReasonCD.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FREASON_CD_MSG_03, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If
                If txtReasonCD.Text.Length <> 6 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206041_05, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If
                '========================================
                '理由
                '========================================
                If txtReason.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FREASON_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '理由ｺｰﾄﾞ重複ﾁｪｯｸ
                '========================================
                Dim objTMST_REASON As New TBL_TMST_REASON(gobjOwner, gobjDb, Nothing)           '理由ﾏｽﾀ
                Dim intRet As Integer
                objTMST_REASON.FREASON_CD = txtOperationCD.Text & txtReasonCD.Text              '理由ｺｰﾄﾞ
                intRet = objTMST_REASON.GET_TMST_REASON(False)                                  '特定
                If intRet = RetCode.OK Then
                    '(入力された理由ｺｰﾄﾞが登録されている場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206041_04, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select

                End If


                blnCheckErr = False

            Case BUTTONMODE_UPDATE
                '(変更の場合)
                '========================================
                '理由
                '========================================
                If txtReason.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FREASON_MSG_01, _
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
                txtOperationCD.Enabled = False                  '作業種別ｺｰﾄﾞ
                txtReasonCD.Enabled = True                      '理由ｺｰﾄﾞ
                txtReason.Enabled = True                        '理由

                Exit Select

            Case BUTTONMODE_UPDATE
                '(変更の場合)
                txtOperationCD.Enabled = False                  '作業種別ｺｰﾄﾞ
                txtReasonCD.Enabled = False                     '理由ｺｰﾄﾞ
                txtReason.Enabled = True                        '理由

                Exit Select

            Case BUTTONMODE_DELETE
                '(削除の場合)
                txtOperationCD.Enabled = False                  '作業種別ｺｰﾄﾞ
                txtReasonCD.Enabled = False                     '理由ｺｰﾄﾞ
                txtReason.Enabled = False                       '理由

                Exit Select

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

        Dim strDIR_KUBUN As String = ""         '処理区分
        Dim strREASON_CD As String = ""         '理由ｺｰﾄﾞ
        Dim strOperation_CD As String = ""      '作業種別
        Dim strREASON As String = ""            '理由
        Dim strREASON_2 As String = ""          '理由(理由ﾏｽﾀ登録ﾃﾞｰﾀ)


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200901              'ﾌｫｰﾏｯﾄ名ｾｯﾄ

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

        strREASON_CD = TO_STRING(txtOperationCD.Text & txtReasonCD.Text)                    '理由ｺｰﾄﾞ
        strOperation_CD = TO_STRING(txtOperationCD.Text)                                    '作業種別
        strREASON_2 = TO_STRING(txtReason.Text)                                               '理由

        objTelegram.SETIN_HEADER("DSPREASON", strREASON)                    '理由
        objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
        objTelegram.SETIN_DATA("DSPREASON_CD", strREASON_CD)                '理由ｺｰﾄﾞ
        objTelegram.SETIN_DATA("DSPREASON_KUBUN", strOperation_CD)          '作業種別
        objTelegram.SETIN_DATA("DSPREASON", strREASON_2)                    '理由


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                         'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = FRM_MSG_FRM206041_01
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
