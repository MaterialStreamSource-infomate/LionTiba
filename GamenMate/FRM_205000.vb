'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z����ݽ�ƭ����
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports                              "
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_205000

#Region "  ����ā@                              "
#End Region
#Region "�@̫��۰�ށ@�@�@�@�@�@�@�@�@           "
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
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd01)      '��ײݐݒ�
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd02)      '�ׯ�ݸ�����ݽ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd03)      '�݌�����ݽ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd04)      '�݌ɏƍ�
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd05)      '�I�������

    End Sub
#End Region

#Region "�@��ײݐݒ�د��@�@�@�@�@              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ײݐݒ�د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_205010, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@�ׯ�ݸ�����ݽ�د��@�@�@�@�@          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸ�����ݽ�د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_205020, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@�݌�����ݽ�د��@�@�@�@�@             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �݌�����ݽ�د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_205040, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@�݌ɏƍ��د��@�@�@�@�@               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �݌ɏƍ��د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305010, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@�I������Ƹد��@�@�@�@               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �I������Ƹد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '*����ż* Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305020, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

#Region "  F8  ���݉��������@�@�@�@�@           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8  ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F8Process()

        '******************************************
        ' ��ʑJ��
        '******************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_201000, Me)

    End Sub
#End Region

End Class
