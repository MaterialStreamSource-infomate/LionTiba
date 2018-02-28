'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z����۸޲ݐݒ���
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports      "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports UserProcess
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_100005

#Region "�@���ʕϐ�                         "

    '�����è�p
    Private mudtAfkRet As AFKFrmRetType             '۸޵�/۸޵�

    '���������ꍇ����
    Enum menmCheckCase
        OK_Click                'OK���ݸد�
        PASS_CHANGE_Click       '�߽ܰ�ޕύX���ݸد�
    End Enum

    Protected mblnClose As Boolean      '�۰�ދ����׸�


#End Region
#Region "�@�����è                          "
    ''' <summary>��ʖߒl(۸޵�/����۸޵�)</summary>
    Public ReadOnly Property AFKFORMRET() As AFKFrmRetType
        Get
            Return mudtAfkRet
        End Get
    End Property
#End Region
#Region "  �����                            "
#Region "�@̫��۰��                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_100005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call frmLoad()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region

#Region "  ۸޲����݉���                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۸޲����݉���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        Try

            cmdLogin_Proc()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "�@����۸ޱ�����݉���               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ����۸ޱ�����݉���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdLogoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogoff.Click
        Try

            cmdLogoff_Proc()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "�@�ύX���݉���                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ύX���݉��� 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdPassChng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPassChng.Click
        Try

            cmdPassChng_Proc()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "�@�߽ܰ�ޓ���              KeyDown "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �߽ܰ�ޓ��� KeyDown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtPassCd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFPASS_WORD.KeyDown
        Try

            If e.KeyCode = Windows.Forms.Keys.Enter Then
                cmdLogin.Focus()
            End If

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  ̫�Ѹ۰��                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫�Ѹ۰��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_100005_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try


            '****************************************
            '�۰�ޏ���
            '****************************************
            If mblnClose = False Then
                '=================================
                '�۰�ނ��Ȃ�
                '=================================
                e.Cancel = True

            End If


        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ̫��۰�ޏ���                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰�ޏ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmLoad()
        Dim intRet As RetCode           '�ߒl�p


        '*******************************************************
        'հ�ްID�擾
        '*******************************************************
        Dim objTMST_USER As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)
        objTMST_USER.FUSER_ID = gcstrFUSER_ID               'հ�ްID
        intRet = objTMST_USER.GET_TMST_USER(True)           '�擾


        '*******************************************************
        ' �����ݒ�
        '*******************************************************
        txtFLOGIN_ID.Enabled = False
        txtFLOGIN_ID.Text = objTMST_USER.FUSER_ID       '���[�U�R�[�h
        lblEmpName.Text = gcstrFUSER_NAME               '���[�U��
        mblnClose = False                               '�۰�ދ����׸�

        cmdPassChng.Enabled = False
        cmdPassChng.Visible = False



    End Sub
#End Region
#Region "  ۸޲�            ���݉�������    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۸޲� ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdLogin_Proc()


        '****************************************************
        '��������
        '****************************************************
        If InputCheck(menmCheckCase.OK_Click) = False Then
            Exit Sub

        End If


        '********************************************************************
        '���đ��M����(�߽ܰ�ޓo�^����)
        '********************************************************************
        Call SendSocket01()


    End Sub
#End Region
#Region "�@����۸޵�        ���݉�������    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ����۸޵� ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdLogoff_Proc()

        Dim udeRet As RetPopup

        '*******************************************************
        '�m�Fү����
        '*******************************************************
        udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_SHUTDOWN, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> RetPopup.OK Then
            Exit Sub
        End If


        '*******************************************************
        '���đ��M����
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200006           '̫�ϯĖ����
        Call gobjComFuncFRM.SockSendServer01(objTelegram)                                  '���đ��M


        '۸޵̂��
        mudtAfkRet = AFKFrmRetType.LogOff

        '��ʸ۰��
        mblnClose = True
        Me.Close()

    End Sub
#End Region
#Region "�@�ύX             ���݉�������    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ύX ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdPassChng_Proc()

        Try

            '****************************************************
            '��������
            '****************************************************
            If InputCheck(menmCheckCase.PASS_CHANGE_Click) = False Then
                Exit Try
            End If


            '****************************************************
            '�߽ܰ�ޕύX��ʕ\��
            '****************************************************
            gobjFRM_100006 = Nothing
            gobjFRM_100006 = New FRM_100006     '�߽ܰ�ޕύX���

            Call SetProperty()                                  '�����è���


            '****************************************************
            '�ύX/��ݾ�����
            '****************************************************
            Dim intRtn As DialogResult

            gobjFRM_100006.ShowDialog()

            If intRtn = System.Windows.Forms.DialogResult.Cancel = True Then
                '(��ݾَ�)
                Exit Sub
            End If

            txtFPASS_WORD.Text = ""

        Catch ex As Exception
            gobjFRM_100006.Dispose()
            gobjFRM_100006 = Nothing
            Throw ex

        End Try

    End Sub
#End Region
#Region "�@���������@                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��������
    ''' </summary>
    ''' <param name="udtCheck_Case">������������</param>
    ''' <returns>True:������������  False:�����������s</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '���֐��ߒl
        Dim blnCheckErr As Boolean = True       '�����װ�׸�

        Dim intRet As Integer       '�ߒl�p
        Dim objTMST_USER As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)

        Select Case udtCheck_Case
            Case menmCheckCase.OK_Click
                '(OK���ݸد���)

                If txtFPASS_WORD.Text = "" Then
                    '(�߽ܰ�ނ����ݸ�̂Ƃ�)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_07, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Err)
                    Exit Function
                End If

                blnCheckErr = False

            Case menmCheckCase.PASS_CHANGE_Click
                '(�߽ܰ�ޕύX���ݸد���)

                '**********************************************************
                ' �߽ܰ������
                ' հ�ް�������َ擾
                '   �yհ�ްϽ��z
                '**********************************************************
                '==================================
                ' �߽ܰ�޹ޯ�
                '==================================
                Dim objTMST_USER_CHANGE As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)
                objTMST_USER_CHANGE.FUSER_ID = txtFLOGIN_ID.Text            'հ��ID
                intRet = objTMST_USER_CHANGE.GET_TMST_USER_FLOGIN_ID()      '���擾
                If intRet = RetCode.OK Then
                    '==================================
                    ' �߽ܰ������
                    '==================================
                    If txtFPASS_WORD.Text <> objTMST_USER_CHANGE.FPASS_WORD Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_01, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Err)
                        Exit Select
                    End If
                    '==================================
                    ' ۯ���������
                    '==================================
                    If IsNull(objTMST_USER_CHANGE.FLOCK_DT) = False Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_05, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Err)
                        Exit Select
                    End If
                Else
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Err)
                    Exit Select
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
#Region "  �߽ܰ�ޕύX��ʂ������è���      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �߽ܰ�ޕύX��ʂ������è���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty()

        gobjFRM_100006.userFUSER_ID = TO_STRING(txtFLOGIN_ID.Text)                   'հ�ްID
        gobjFRM_100006.userFUSER_NAME = TO_STRING(lblEmpName.Text)               'հ�ް��

    End Sub

#End Region
#Region "  ���đ��M                         "
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


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200002              '̫�ϯĖ����

        strDSPLOGIN_ID = TO_STRING(txtFLOGIN_ID.Text)       '۸޲�հ�ްID
        strPASSWORD = TO_STRING(txtFPASS_WORD.Text)         '�߽ܰ��

        objTelegram.SETIN_DATA("DSPLOGIN_ID", strDSPLOGIN_ID)       '۸޲�հ�ްID
        objTelegram.SETIN_DATA("DSPPASS_WORD", strPASSWORD)         '�߽ܰ��


        Dim strRET_STATE As String = ""                 '�����ð��
        Dim udtSckSendRET As clsSocketClient.RetCode   '���đ��M�߂�l

        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE)   '���đ��M
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(���M�ł����ꍇ)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(����I���̏ꍇ)

                '۸޵݂��
                mudtAfkRet = AFKFrmRetType.LogOn

                '��ʸ۰��
                mblnClose = True
                Me.Close()

            Else
                txtFPASS_WORD.Text = ""
                txtFPASS_WORD.Focus()
            End If
        Else
            txtFPASS_WORD.Text = ""
            txtFPASS_WORD.Focus()
        End If

    End Sub
#End Region

End Class