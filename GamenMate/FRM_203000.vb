'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z���o�ɋƖ��ƭ����
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports                              "
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_203000

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
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd01)      '�o�Ɍv��
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd02)      '�o�ɊJ�n�ݒ�
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd03)      '�⍇���o�ɐݒ�
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd04)      '�z�֍�Ǝw��
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd05)      '�����Ɛݒ�

    End Sub
#End Region
#Region "�@�o�Ɍv��د�  �@     �@              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �o�Ɍv��د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303010, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@�o�ɊJ�n�ݒ�د�                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �o�ɊJ�n�ݒ�د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '*����ż* Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303030, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@�⍇���o�ɐݒ�د�     �@            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �⍇���o�ɐݒ�د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '*����ż* Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303040, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@�z�֍�Ǝw���د� �@                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �z�֍�Ǝw���د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '*����ż* Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303060, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

#Region "  F8  ���݉��������@                   "
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
