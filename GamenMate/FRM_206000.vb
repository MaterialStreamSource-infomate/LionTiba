'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zϽ�����ݽ�ƭ����
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports                              "
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_206000

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
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd01)      '���i�i��Ͻ�����ݽ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd02)      '���쌠��Ͻ�����ݽ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd03)      '�����i��Ͻ�����ݽ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd04)      '���RϽ�����ݽ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd05)      '��ޕi��Ͻ�����ݽ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd06)      '�S����Ͻ�����ݽ


    End Sub
#End Region

#Region "�@���i�i��Ͻ�����ݽ�د�    �@�@�@�@    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���i�i��Ͻ�����ݽ�د� 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_FRM_306010, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@���쌠��Ͻ�����ݽ�د�    �@�@�@�@    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���쌠��Ͻ�����ݽ�د� 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_FRM_206030, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@�����i��Ͻ�����ݽ�د�    �@�@�@�@    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����i��Ͻ�����ݽ�د� 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_FRM_206010, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@���RϽ�����ݽ�د�    �@�@�@�@        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���RϽ�����ݽ�د� 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_FRM_206040, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@��ޕi��Ͻ�����ݽ�د�    �@�@�@�@    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ޕi��Ͻ�����ݽ�د� 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_FRM_306030, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@�S����Ͻ�����ݽ�د�    �@�@�@�@      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �S����Ͻ�����ݽ�د� 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_FRM_206020, Me)
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
        'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_FRM_201000, Me)

    End Sub
#End Region

End Class
