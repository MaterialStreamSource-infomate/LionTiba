'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�⍇���ƭ����
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports                              "
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_204000

#Region "  ����ā@                              "
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
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd01)      '�݌ɖ⍇��
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd02)      '��Ɨ���⍇��
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd03)      '���o�Ɏ��і⍇��

    End Sub
#End Region

#Region "�@�݌ɖ⍇���د�                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �݌ɖ⍇���د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204010, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@��Ɨ���⍇���د�                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��Ɨ���⍇���د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204050, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@���o�Ɏ��і⍇���د�                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���o�Ɏ��і⍇���د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204030, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

#Region "  F8  ���݉��������@                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8 ���݉�������
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
