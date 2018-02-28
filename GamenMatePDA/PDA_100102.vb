'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】OK　          ﾎﾟｯﾌﾟｱｯﾌﾟ画面
' 【作成】SIT
'**********************************************************************************************

#Region " Imports               "
Imports GamenMatePDA.clsComFuncPDA
Imports System.Media
#End Region

Public Class PDA_100102

#Region "  「OK」       ﾎﾞﾀﾝｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 「OK」ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try

            Call cmdOKProc()

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)

        End Try
    End Sub
#End Region

    Private Sub cmdOK_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmdOK.KeyPress
        lblMsg.Focus()
    End Sub

    Private Sub PDA_100102_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMsg.Focus()
        SystemSounds.Exclamation.Play()
    End Sub

End Class
