'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z���R�I�����
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports                                  "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_100201

#Region "  ���ʕϐ��@                               "

    Private mFlag_Form_Load As Boolean = True                   '��ʓW�J�׸�

    '�����è
    Private mstrFREASON_KUBUN As String     '���R�敪
    Private mstrFREASON As String           '���R
    Private mudtFormRet As RetPopup         '�߯�߱���̫��    �ߒl

#End Region
#Region "  �����è��`�@                            "
    ''' =======================================
    ''' <summary>���R�敪</summary>
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
    ''' <summary>���R</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property userFREASON() As String
        Get
            Return mstrFREASON
        End Get
    End Property

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
#Region " ̫��۰��                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_100201_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " ̫�ѱ�۰��                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫�ѱ�۰��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_100201_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  ���s���ݸد�                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���s���ݸد�
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
#Region "�@��ݾ�   �@���݉���                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ݾ� ���݉���
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
#Region "  ̫��۰��     ����                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��     ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LoadProcess()



        '**********************************************************
        '�����ޯ����ı���
        '**********************************************************
        Call gobjComFuncFRM.cboFREASON_CDSetup(Me.Name, Me.cboFREASON_CD, mstrFREASON_KUBUN, True)


        mFlag_Form_Load = False


    End Sub
#End Region
#Region "�@̫�ѱ�۰��   ����                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫�ѱ�۰��   ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ClosingProcess()


        '******************************************
        ' ���۰ق̊J��
        '******************************************
        cboFREASON_CD.Dispose()
        cboFREASON_CD = Nothing


    End Sub
#End Region
#Region "  ���s         ���݉�������                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���s ���݉�������
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
        '�۰��
        '********************************************************************
        mstrFREASON = cboFREASON_CD.Text
        Me.Close()


    End Sub
#End Region
#Region "�@��ݾ�        ���݉�������                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ݾ�        ���݉������� 
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
    Protected Overridable Function InputCheck() As Boolean

        Dim blnReturn As Boolean = False        '���֐��ߒl
        Dim blnCheckErr As Boolean = False       '�����װ�׸�

        '========================================
        '���R
        '========================================
        If cboFREASON_CD.Text = "" Then
            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FREASON_CD_MSG_01, _
                              PopupFormType.Ok, _
                              PopupIconType.Information)

            blnCheckErr = True

        End If


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

End Class
