'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' ÅyñºèÃÅzœ√ÿ±ŸΩƒÿ∞—ïWèÄã@î\
' Åyã@î\ÅzOKÅ@          ŒﬂØÃﬂ±ØÃﬂâÊñ 
' ÅyçÏê¨ÅzSIT
'**********************************************************************************************


#Region "Imports                "
Imports GamenMate.clsComFuncFRM
Imports System.Media
#End Region

Public Class FRM_100102

#Region "  ÅuOKÅv       Œﬁ¿›∏ÿØ∏"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ÅuOKÅvŒﬁ¿›∏ÿØ∏
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

    Private Sub cmdOK_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmdOK.KeyPress
        lblMsg.Focus()
    End Sub

    Private Sub FRM_100102_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMsg.Focus()
        SystemSounds.Exclamation.Play()
    End Sub

End Class
