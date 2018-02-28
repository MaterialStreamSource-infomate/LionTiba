'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】OK_Cancel     ﾎﾟｯﾌﾟｱｯﾌﾟ画面(指図書発行ﾁｪｯｸﾎﾞｯｸｽあり)
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports              "

Imports GamenMate.clsComFuncFRM

#End Region

Public Class FRM_100104

#Region "  共通変数             定義"

    'ﾌﾟﾛﾊﾟﾃｨ変数
    Private mblnFormRetCheck As CheckState             '指図書発行ﾁｪｯｸ有無

#End Region

#Region "  ﾌﾟﾛﾊﾟﾃｨ              定義"

    Public ReadOnly Property userCheck() As CheckState
        Get
            Return mblnFormRetCheck
        End Get
    End Property
#End Region

#Region "　自分自身ｸﾛｰｽﾞ処理        "
    ''' <summary>
    ''' 自分自身ｸﾛｰｽﾞ処理
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
