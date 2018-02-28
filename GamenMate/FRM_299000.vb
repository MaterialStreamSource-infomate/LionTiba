'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�J���җpҲ��ƭ�
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports"
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports System.Threading
#End Region

Public Class FRM_299000

    '**********************************************************************************************
    '���������ы���
#Region "  ����                   �د�    "
    ''' **********************************************************************************************
    ''' <summary>
    ''' ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' **********************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
#End Region
#Region "  ��ݻ޸���۸�             �د�    "
    ''' **********************************************************************************************   ''' <summary>
    ''' ��ݻ޸���۸� �د�
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
#Region "  ���đ��M°�              �د�    "
    ''' **********************************************************************************************
    ''' <summary>
    ''' ���đ��M°� �د�
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
#Region "  ���Ď�M°�              �د�    "
    ''' **********************************************************************************************
    ''' <summary>
    ''' ���Ď�M°� �د� 
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
#Region "  DB����ݽ°�°�           �د�    "
    ''' **********************************************************************************************
    ''' <summary>
    ''' DB����ݽ°�°� �د� 
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
#Region "�@���o�Ɏ���               �د�    "
    ''' **********************************************************************************************
    ''' <summary>
    ''' ���o�Ɏ��� �د�
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
#Region "�@�݌Ɉڍs°�              �د�    "
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
#Region "�@�i��Ͻ��ڍs°�           �د�    "
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
#Region "�@���u���݌Ɉڍs°�        �د�    "
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


#Region "  ���Ď�M°ٕ\���گ��                 "
    ''' **********************************************************************************************
    ''' <summary>
    '''  ���Ď�M°ٕ\���گ�� 
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


    '���������ы���
    '**********************************************************************************************


    '**********************************************************************************************
    '���������ьŗL

    '���������ьŗL
    '**********************************************************************************************


End Class