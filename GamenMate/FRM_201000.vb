'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zҲ��ƭ����
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_201000

#Region "�@���ʕϐ��@                           "

    Private mFlag_Form_Load As Boolean = True           '��ʓW�J�׸�

#End Region
#Region "  ����ā@                              "
#Region "  �����޳�  ���݉��� �����             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����޳�  ���݉��� �����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Call cmdClose_ClickProccess()

    End Sub
#End Region
#End Region
#Region "�@̫��۰��                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '**********************************************************
        ' ���ݖ��擾
        '**********************************************************
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd01)      '�������
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd02)      '����ݽ�ƭ�
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd03)      '���o�ɋƖ��ƭ�
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd04)      '��������ݽ�ƭ�
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd05)      '�⍇���ƭ�
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd06)      '�ޯ������ƭ�


        '**********************************************************
        ' �J���җp���ݐݒ�
        '**********************************************************
        If TO_NUMBER(gcstrDEGUB_FLG) = 9 Then
            cmdDevelopment.Visible = True
        Else
            cmdDevelopment.Visible = False
        End If

        mFlag_Form_Load = False

    End Sub
#End Region
#Region "�@��������د�                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��������د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_202000, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@����ݽ�ƭ��د�                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ����ݽ�ƭ��د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_205000, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@���o�ɋƖ��ƭ��د�                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���o�ɋƖ��ƭ��د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_203000, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@��������ݽ�ƭ��د�                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��������ݽ�ƭ��د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207000, Me)
        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "�@�⍇���ƭ��د�                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �⍇���ƭ��د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204000, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@�ޯ������ƭ��د�                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ޯ������ƭ��د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '*����ż* Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_308000, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  �����޳�  ���݉��������@             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����޳�  ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_ClickProccess()

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
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200004           '̫�ϯĖ����
        Call gobjComFuncFRM.SockSendServer01(objTelegram)                                  '���đ��M

        '������������************************************************************************************************************
        'JobMate:A.Noto 2012/06/13 �����޳ݏ����ǉ�

        ''*******************************************************
        ''�����޳�or��ʸ۰�ޏ���
        ''*******************************************************
        'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_100001, Me)

        '*******************************************************
        '�����޳�or��ʸ۰�ޏ���
        '*******************************************************
        Dim intShutDownFlg As Integer
        Try
            intShutDownFlg = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS200000_001))
        Catch ex As Exception
            '(���ѕϐ��擾�Ŵװ���o���ꍇ)
            gobjComFuncFRM.ComError_frm(ex)
            intShutDownFlg = FLAG_OFF
        End Try

        If intShutDownFlg = FLAG_ON Then
            '(�����޳��׸ނ�ON�̏ꍇ)

            '----------------------------------------
            ' �����޳�
            '----------------------------------------
            Call PubF_ShutDown()            ' �����޳�

        Else
            '(�����޳��׸ނ�ON�ȊO�̏ꍇ)

            '----------------------------------------
            ' ��ʸ۰��
            '----------------------------------------
            If IsNull(gobjFRM_201000) = False Then
                gobjFRM_201000.Close()
                gobjFRM_201000.Dispose()
                gobjFRM_201000 = Nothing
            End If
            Me.Close()
            Me.Dispose()

        End If
        '������������************************************************************************************************************

    End Sub
#End Region
    '������������************************************************************************************************************
    'JobMate:A.Noto 2012/06/13 �����޳ݏ����ǉ�
#Region "  �����޳�         ����                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����޳ݏ���
    ''' </summary>
    ''' <returns>����FTrue     �ُ�FFalse</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function PubF_ShutDown() As Boolean
        Dim flags As Shutdown.ShutdownFlag

        PubF_ShutDown = False

        Try

            flags = Shutdown.ShutdownFlag.Shutdown

            ' EWX_FORCEIFHUNG
            '�n���O�A�b�v�����v���O�������I��
            flags = flags Or _
                        Shutdown.ShutdownFlag.ForceIfHung

            ' �V���b�g�_�E�������s
            Shutdown.ExitWindows(flags)

            PubF_ShutDown = True

        Catch ex As Exception
            Throw ex
        Finally
            If IsNull(flags) = False Then
                flags = Nothing
            End If
            If IsNull(flags) = False Then
                flags = Nothing
            End If
        End Try
    End Function
#End Region
    '������������************************************************************************************************************

#Region "�@�J����°ٸد�                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �J����°ٸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdDevelopment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim objFRM_299000 As FRM_299000
            objFRM_299000 = New FRM_299000
            objFRM_299000.Show()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

End Class
