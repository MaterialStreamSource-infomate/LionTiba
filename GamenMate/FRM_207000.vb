'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z��������ݽ�ƭ����
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports                              "
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_207000

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
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd01)      '���ڰ���۸�
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd02)      '���Ѵװ۸�
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd03)      '�ݔ��ُ�۸�
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd04)      '�ݔ��ʐM۸�
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd05)      'ү���ޗ���
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd06)      '���ђ萔����ݽ

    End Sub
#End Region
#Region "�@���ڰ���۸޸د�                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ڰ���۸޸د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207010, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@���Ѵװ۸޸د�                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���Ѵװ۸޸د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207020, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@�ݔ��ُ�۸޸د�                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ݔ��ُ�۸޸د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207030, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@�ݔ��ʐM۸޸د�                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ݔ��ʐM۸޸د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207040, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@ү���ޗ���د�                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ү���ޗ���د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207050, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "�@���ђ萔����ݽ�د�                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ђ萔����ݽ�د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207060, Me)
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
