'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�߽ܰ�ޕύX���
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports      "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports UserProcess
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_100006

#Region "  ���ʕϐ��@                               "
    '�����è
    Protected mstrFUSER_ID As String             'հ�ްID
    Protected mstrFUSER_NAME As String           'հ�ް��
#End Region
#Region "  �����è��`�@                            "
    ''' =======================================
    ''' <summary>հ�ްID</summary>
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
    ''' <summary>հ�ް��</summary>
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
#Region "  �����                                    "
#Region "�@̫��۰��                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
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
#Region "�@�ύX���݉���                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ύX���݉���
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
#Region "�@��ݾ����݉���                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ݾ����݉���
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
#Region "  ̫��۰�ޏ���                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰�ޏ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmLoad()

        '*******************************************************
        ' �����ݒ�
        '*******************************************************
        txtFLOGIN_ID.Enabled = False
        txtFLOGIN_ID.Text = mstrFUSER_ID           'հ�޺���
        lblFUSER_NAME.Text = mstrFUSER_NAME        'հ�ޖ�

    End Sub
#End Region
#Region "  �ύX         ���݉�������                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ύX ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdChange_ClickProcess()

        '********************************************************************
        '��������
        '********************************************************************
        If InputCheck() = False Then

            Exit Sub
        End If


        '********************************************************************
        '���đ��M����
        '********************************************************************
        Call SendSocket01()



    End Sub
#End Region
#Region "�@��ݾ�        ���݉�������                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ݾ� ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        Me.Close()

    End Sub
#End Region
#Region "�@���������@                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��������
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function InputCheck() As Boolean

        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(gobjOwner, gobjDb, Nothing)     '���ѕϐ�

        Dim blnReturn As Boolean = False        '���֐��ߒl
        Dim blnCheckErr As Boolean = True       '�����װ�׸�

        Select Case ""
            Case Else
                If txtFPASS_WORD.Text <> txtReFPASS_WORD.Text Then
                    '(�߽ܰ�ނ��߽ܰ�ލē��͂̓��͒l���قȂ�Ƃ�)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_06, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Err)
                    blnCheckErr = True
                    Exit Select

                End If

                If txtFPASS_WORD.Text = "" Then
                    '(�߽ܰ�ނ����ݸ�̂Ƃ�)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_07, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Err)
                    blnCheckErr = True
                    Exit Select

                End If

                If txtReFPASS_WORD.Text = "" Then
                    '(�߽ܰ�ލē��͂����ݸ�̂Ƃ�)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_07, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Err)
                    blnCheckErr = True
                    Exit Select

                End If

                If txtReFPASS_WORD.Text = txtFLOGIN_ID.Text _
               And objTPRG_SYS_HEN.SS000000_014 = FLAG_ON _
               Then
                    '(�߽ܰ�ނ�հ��ID�������Ƃ�)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_16, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Err)
                    blnCheckErr = True
                    Exit Select
                End If

                If gcintPASSWORD_KETA > 0 Then
                    '(�߽ܰ�ލŏ�������0���傫���Ƃ�)
                    If (txtFPASS_WORD.Text).Length < gcintPASSWORD_KETA Then
                        '(�߽ܰ�ނ�6������菬�����Ƃ�)
                        Call gobjComFuncFRM.DisplayPopup(String.Format(FRM_MSG_FRM100001_12, gcintPASSWORD_KETA), _
                                        PopupFormType.Ok, _
                                        PopupIconType.Err)
                        blnCheckErr = True
                        Exit Select
                    End If
                End If

                If gcintPASSWORD_ENG = FLAG_ON Then
                    '(�߽ܰ�މp�������׸ނ�ON�̂Ƃ�)
                    If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[A-Za-z]") = False Then
                        '(�߽ܰ�ނɉp�����܂܂�Ă��Ȃ��Ƃ�)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_13, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Err)
                        blnCheckErr = True
                        Exit Select
                    End If
                End If

                If gcintPASSWORD_NUM = FLAG_ON Then
                    '(�߽ܰ�ސ��������׸ނ�ON�̂Ƃ�)
                    If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[0-9]") = False Then
                        '(�߽ܰ�ނɐ������܂܂�Ă��Ȃ��Ƃ�)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_14, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Err)
                        blnCheckErr = True
                        Exit Select
                    End If
                End If

                If gcintPASSWORD_KIGO = FLAG_ON Then
                    '(�߽ܰ�ދL�������׸ނ�ON�̂Ƃ�)
                    If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[^a-zA-Z0-9]") = False Then
                        '(�߽ܰ�ނɋL�����܂܂�Ă��Ȃ��Ƃ�)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_15, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Err)
                        blnCheckErr = True
                        Exit Select
                    End If
                End If

                If gcintPASSWORD_DAISHO = FLAG_ON Then
                    '(�߽ܰ�ޑ啶�������������׸ނ�ON�̂Ƃ�)
                    If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[A-Z]") = False Then
                        '(�߽ܰ�ނɑ啶�����܂܂�Ă��Ȃ��Ƃ�)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_17, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Err)
                        txtFPASS_WORD.Focus()
                        Exit Function
                    End If

                    If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[a-z]") = False Then
                        '(�߽ܰ�ނɏ��������܂܂�Ă��Ȃ��Ƃ�)
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
            '(�����Ɉ�������������)
            blnReturn = False
        Else
            '(�����Ɉ���������Ȃ�������)
            blnReturn = True
        End If

        Return blnReturn

    End Function
#End Region
#Region "  ���đ��M                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���đ��M
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket01()

        '*******************************************************
        '���đ��M����
        '*******************************************************
        '========================================
        ' �ϐ��錾
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        Dim strDSPLOGIN_ID As String = ""           '۸޲�հ�ްID
        Dim strPASSWORD As String = ""              '�߽ܰ��


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200003              '̫�ϯĖ����

        strDSPLOGIN_ID = TO_STRING(txtFLOGIN_ID.Text)       '۸޲�հ�ްID
        strPASSWORD = TO_STRING(txtFPASS_WORD.Text)         '�߽ܰ��

        objTelegram.SETIN_DATA("DSPLOGIN_ID", strDSPLOGIN_ID)           '۸޲�հ�ްID
        objTelegram.SETIN_DATA("DSPPASS_WORD", strPASSWORD)             '�߽ܰ��


        Dim strRET_STATE As String = ""                 '�����ð��
        Dim udtSckSendRET As clsSocketClient.RetCode   '���đ��M�߂�l
        Dim strErrMsg As String                 '�װү����

        strErrMsg = FRM_MSG_FRM100001_08

        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   '���đ��M
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(���M�ł����ꍇ)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(����I���̏ꍇ)
                Me.DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()
                Me.Dispose()

            End If
        End If

    End Sub
#End Region

End Class
