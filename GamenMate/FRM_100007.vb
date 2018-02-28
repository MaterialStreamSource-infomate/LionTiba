'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�߽ܰ�ފm�F���
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports      "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports UserProcess
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_100007

#Region "  ���ʕϐ��@                               "

    '�����è
    Private mudtFormRet As RetPopup         '�߯�߱���̫��    �ߒl

#End Region
#Region "  �����è��`�@                            "
    ''' =======================================
    ''' <summary>�߯�߱���̫�іߒl</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property userRet() As RetPopup
        Get
            Return mudtFormRet
        End Get
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
    Private Sub cmdZikkou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZikkou.Click
        Try

            Call cmdZikkou_ClickProcess()

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
#Region "  �߽ܰ�� KeyDown�����                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �߽ܰ�� KeyDown�����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtFPASS_WORD_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFPASS_WORD.KeyDown
        Try

            If e.KeyCode = Windows.Forms.Keys.Enter Then
                cmdZikkou.Focus()
            End If

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

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
        ' հ�ްϽ��擾
        '*******************************************************
        Dim objTMST_USER As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)
        objTMST_USER.FUSER_ID = gcstrFUSER_ID
        objTMST_USER.GET_TMST_USER(False)


        '*******************************************************
        ' �����ݒ�
        '*******************************************************
        txtFLOGIN_ID.Enabled = False
        txtFLOGIN_ID.Text = objTMST_USER.FUSER_ID           'հ�޺���
        lblFUSER_NAME.Text = objTMST_USER.FUSER_NAME        'հ�ޖ�


    End Sub
#End Region
#Region "  �m�F         ���݉�������                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �m�F ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_ClickProcess()


        '********************************************************************
        '��������
        '********************************************************************
        If InputCheck() = False Then

            Exit Sub
        End If


        '********************************************************************
        '���đ��M
        '********************************************************************
        Call SendSock01()


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

        mudtFormRet = RetPopup.Cancel
        Me.Close()

    End Sub
#End Region
#Region "�@���������@                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��������
    ''' </summary>
    ''' <returns>������������</returns>
    ''' <remarks>True :������������ False:�����������s</remarks>
    ''' *******************************************************************************************************************
    Private Function InputCheck() As Boolean

        Dim blnReturn As Boolean = False        '���֐��ߒl
        Dim blnCheckErr As Boolean = True       '�����װ�׸�

        Select Case ""
            Case Else

                If txtFPASS_WORD.Text = "" Then
                    '(�߽ܰ�ނ����ݸ�̂Ƃ�)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_07, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Err)
                    blnCheckErr = True
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
#Region "  ���đ��M                                 "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ���đ��M
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub SendSock01()


        '*******************************************************
        '���đ��M����
        '*******************************************************
        Dim strRET_STATE As String = ""                 '�����ð��
        Dim udtSckSendRET As clsSocketClient.RetCode    '���đ��M�߂�l
        udtSckSendRET = gobjComFuncFRM.SendSockLogin(txtFLOGIN_ID.Text _
                                     , txtFPASS_WORD.Text _
                                     , strRET_STATE _
                                     )
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(���M�ł����ꍇ)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(����I���̏ꍇ)

                Me.DialogResult = Windows.Forms.DialogResult.OK
                mudtFormRet = RetPopup.OK

                Me.Close()
                '' ''Me.Dispose()

            Else
                '(�������ُ�I�������ꍇ)
                txtFPASS_WORD.Text = ""
                txtFPASS_WORD.Focus()
            End If
        ElseIf udtSckSendRET = clsSocketClient.RetCode.ReceiveTimeOut Then
            '(��ѱ�Ă̏ꍇ)
        Else
            '(���̑��̏ꍇ)
            txtFPASS_WORD.Text = ""
            txtFPASS_WORD.Focus()
        End If


    End Sub
#End Region

End Class
