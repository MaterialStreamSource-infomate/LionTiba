'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zOK_Cancel     �߯�߱��߉��(�w�}�����s�����ޯ������)
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports              "

Imports GamenMate.clsComFuncFRM

#End Region

Public Class FRM_100104

#Region "  ���ʕϐ�             ��`"

    '�����è�ϐ�
    Private mblnFormRetCheck As CheckState             '�w�}�����s�����L��

#End Region

#Region "  �����è              ��`"

    Public ReadOnly Property userCheck() As CheckState
        Get
            Return mblnFormRetCheck
        End Get
    End Property
#End Region

#Region "�@�������g�۰�ޏ���        "
    ''' <summary>
    ''' �������g�۰�ޏ���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FRM_100104_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            mblnFormRetCheck = chkPrint.CheckState

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
    
End Class
