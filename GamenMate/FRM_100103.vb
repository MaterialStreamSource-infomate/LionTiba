'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zOK_Cancel     �߯�߱��߉��
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports              "

Imports GamenMate.clsComFuncFRM

#End Region

Public Class FRM_100103

#Region "  �uOK�v       ���ݸد�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �uOK�v���ݸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try

            Call cmdOKProc()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  �uCancel�v   ���ݸد�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �uCancel�v���ݸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try

            Call cmdCancelProc()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region

End Class
