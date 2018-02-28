'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�߯�߱��߉�ʐe̫��
' �y�쐬�zSIT
'**********************************************************************************************

#Region "Imports                    "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_100101

#Region "  ���ʕϐ�             ��`"

    '�����è�ϐ�
    Private mudtFormRet As RetPopup             '�������݂������ꂽ���́A̫�т̖ߒl
    Private mudtIconType As PopupIconType       '�\�����݂�����

#End Region
#Region "  �����è              ��`"

    Public ReadOnly Property userRet() As RetPopup
        Get
            Return mudtFormRet
        End Get
    End Property

    Public Property userIconType() As PopupIconType
        Get
            Return mudtIconType
        End Get
        Set(ByVal Value As PopupIconType)

            mudtIconType = Value

            ''''''-----------------------
            ''''''�߸����ޯ�����
            ''''''-----------------------
            '''''Try
            '''''    Select Case Value
            '''''        Case INTMSG_BOX_TYPE.INFO
            '''''            pctIcon.Image = Image.FromFile(POPUP_IMAGE_INFOR)
            '''''        Case INTMSG_BOX_TYPE.CONFIR
            '''''            pctIcon.Image = Image.FromFile(POPUP_IMAGE_QUEST)
            '''''        Case INTMSG_BOX_TYPE.ERR
            '''''            pctIcon.Image = Image.FromFile(POPUP_IMAGE_ERROR)
            '''''    End Select
            '''''Catch ex As Exception
            '''''    gobjComFuncFRM.ComError_frm(ex)

            '''''End Try

        End Set
    End Property

#End Region
#Region "  �u�n�j�v���ݸد�     ����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �u�n�j�v���ݸد� ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Sub cmdOKProc()
        Try

            mudtFormRet = RetPopup.OK
            Me.DialogResult = Windows.Forms.DialogResult.OK   '���g��\���i��\�����Ă��邾���j

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  �u��ݾفv���ݸد�    ����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �u��ݾفv���ݸد� ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Sub cmdCancelProc()
        Try

            mudtFormRet = RetPopup.Cancel
            Me.DialogResult = Windows.Forms.DialogResult.Cancel   '���g��\���i��\�����Ă��邾���j
            'Me.Close()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  ̫��۰��             ����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰�� ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Friend Sub frmLoad()
        Try
            '**************************************************
            '���۰پ��
            '**************************************************
            '--------------------------------
            '�߸����ޯ��    ���
            '--------------------------------
            Select Case mudtIconType
                Case PopupIconType.Information
                    pctIcon.Image = Image.FromFile(POPUP_IMAGE_INFOR)
                Case PopupIconType.Quest
                    pctIcon.Image = Image.FromFile(POPUP_IMAGE_QUEST)
                Case PopupIconType.Err
                    pctIcon.Image = Image.FromFile(POPUP_IMAGE_ERROR)
            End Select


        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  �����                    "

#Region "  ̫��۰��             �����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰�� �����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmPopup_01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call frmLoad()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/07/25  ������Ŏ�̫�т���Ԏ�O�ŕ\��������B���\�b�Ԃ̑ҋ@��Ԓ��ɸد�������ShowDialog���Ă���ɂ�������炸�A̫�т����ɕ\������Ă��܂��̂ł��̑Ή�
#Region "  ��ϰ1(������Ŏ��g����Ԏ�O�ɕ\��)  "
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Me.Focus()
        Catch ex As Exception
            Call ComError(ex)
        End Try
    End Sub
#End Region
    '������������************************************************************************************************************

#End Region
#Region "  ���g����ݏ���            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���g����ݏ��� 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MeOpen()

        '*************************************************
        ' ��ʏ������i�e��ʏ����j
        '*************************************************
        Call frmLoad()

        '*************************************************
        ' ������
        '*************************************************
        Me.Opacity = 100


    End Sub
#End Region
#Region "  ���g�۰�ޏ���            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���g�۰�ޏ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MeClose()

        ''''''*************************************************
        '''''' ���g�̸۰�ޏ���
        ''''''*************************************************
        '''''mblnClose = True                         ' �۰�ދ����׸�
        '''''Me.Close()
        '''''Me.Dispose()

        '*************************************************
        ' ���ُ�����
        '*************************************************
        lblMsg.Text = ""


        '*************************************************
        ' ������
        '*************************************************
        Me.Opacity = 0


    End Sub
#End Region

End Class