'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' ÅyñºèÃÅzœ√ÿ±ŸΩƒÿ∞—ïWèÄã@î\
' Åyã@î\ÅzWait     ŒﬂØÃﬂ±ØÃﬂâÊñ 
' ÅyçÏê¨ÅzSIT
'**********************************************************************************************

#Region "Å@Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_100004

#Region "Å@≤Õﬁ›ƒ                                Å@  "
#Region "Å@Ã´∞—€∞ƒﬁÅ@                               "
    '*******************************************************************************************************************
    'Åyã@î\ÅzìØè„
    'Åyà¯êîÅz
    'ÅyñﬂílÅz
    '*******************************************************************************************************************
    Private Sub FRM_100004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "Å@Ã´∞—±›€∞ƒﬁÅ@                             "
    '*******************************************************************************************************************
    'Åyã@î\ÅzìØè„
    'Åyà¯êîÅz
    'ÅyñﬂílÅz
    '*******************************************************************************************************************
    Private Sub FRM_100004_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "Å@Ã´∞—€∞ƒﬁ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Ã´∞—€∞ƒﬁ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub LoadProcess()

    End Sub
#End Region
#Region "Å@Ã´∞—±›€∞ƒﬁ                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Ã´∞—±›€∞ƒﬁ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ClosingProcess()

        '******************************************
        ' ∫›ƒ€∞ŸÇÃäJï˙
        '******************************************
  
    End Sub
#End Region

End Class