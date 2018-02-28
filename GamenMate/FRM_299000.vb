'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】開発者用ﾒｲﾝﾒﾆｭｰ
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports"
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports System.Threading
#End Region

Public Class FRM_299000

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  閉じる                   ｸﾘｯｸ    "
    ''' **********************************************************************************************
    ''' <summary>
    ''' 閉じる ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' **********************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
#End Region
#Region "  ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ             ｸﾘｯｸ    "
    ''' **********************************************************************************************   ''' <summary>
    ''' ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' ********************************************************************************************** ''' <remarks></remarks>
    Private Sub cmdFRM_299001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFRM_299001.Click
        Try
            Dim objForm As FRM_299001
            objForm = New FRM_299001
            objForm.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
#Region "  ｿｹｯﾄ送信ﾂｰﾙ              ｸﾘｯｸ    "
    ''' **********************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信ﾂｰﾙ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' **********************************************************************************************
    Private Sub cmdFRM_299002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFRM_299002.Click
        Try
            Dim objForm As FRM_299002
            objForm = New FRM_299002
            objForm.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
#Region "  ｿｹｯﾄ受信ﾂｰﾙ              ｸﾘｯｸ    "
    ''' **********************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ受信ﾂｰﾙ ｸﾘｯｸ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' **********************************************************************************************
    Private Sub cmdFRM_299004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFRM_299004.Click
        Try
            Dim objThread As New Thread(New ThreadStart(AddressOf ShowFRM_299004))
            objThread.IsBackground = True
            objThread.Start()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
#Region "  DBﾒﾝﾃﾅﾝｽﾂｰﾙﾂｰﾙ           ｸﾘｯｸ    "
    ''' **********************************************************************************************
    ''' <summary>
    ''' DBﾒﾝﾃﾅﾝｽﾂｰﾙﾂｰﾙ ｸﾘｯｸ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' **********************************************************************************************
    Private Sub cmdFRM_299010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFRM_299010.Click
        Try
            Dim objForm As FRM_299010
            objForm = New FRM_299010
            objForm.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
#Region "　入出庫実績               ｸﾘｯｸ    "
    ''' **********************************************************************************************
    ''' <summary>
    ''' 入出庫実績 ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' **********************************************************************************************
    Private Sub cmdFRM_299003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFRM_299003.Click
        Try
            Dim objForm As FRM_299003
            objForm = New FRM_299003
            objForm.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
#Region "　在庫移行ﾂｰﾙ              ｸﾘｯｸ    "
    Private Sub cmdFRM_299005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFRM_299005.Click
        Try
            Dim objForm As FRM_299005
            objForm = New FRM_299005
            objForm.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
#Region "　品目ﾏｽﾀ移行ﾂｰﾙ           ｸﾘｯｸ    "
    Private Sub cmdFRM_299006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFRM_299006.Click
        Try
            Dim objForm As FRM_299006
            objForm = New FRM_299006
            objForm.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
#Region "　平置き在庫移行ﾂｰﾙ        ｸﾘｯｸ    "
    Private Sub cmdFRM_299007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFRM_299007.Click
        Try
            Dim objForm As FRM_299007
            objForm = New FRM_299007
            objForm.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region


#Region "  ｿｹｯﾄ受信ﾂｰﾙ表示ｽﾚｯﾄﾞ                 "
    ''' **********************************************************************************************
    ''' <summary>
    '''  ｿｹｯﾄ受信ﾂｰﾙ表示ｽﾚｯﾄﾞ 
    ''' </summary>
    ''' <remarks></remarks>
    ''' **********************************************************************************************
    Private Sub ShowFRM_299004()
        Try

            Dim objForm As FRM_299004
            objForm = New FRM_299004
            objForm.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
#End Region


    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************


End Class