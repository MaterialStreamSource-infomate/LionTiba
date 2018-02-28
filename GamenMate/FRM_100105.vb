'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】YES_NO     ﾎﾟｯﾌﾟｱｯﾌﾟ画面
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports              "

Imports GamenMate.clsComFuncFRM

#End Region

Public Class FRM_100105

#Region "  「OK」       ﾎﾞﾀﾝｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 「OK」ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdYES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdYES.Click
        Try

            Call cmdOKProc()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  「Cancel」   ﾎﾞﾀﾝｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 「Cancel」ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdNO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNO.Click
        Try

            Call cmdCancelProc()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region


End Class
