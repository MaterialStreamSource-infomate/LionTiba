'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zWait     �߯�߱��߉��
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_100004

#Region "�@�����                                �@  "
#Region "�@̫��۰�ށ@                               "
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z
    '�y�ߒl�z
    '*******************************************************************************************************************
    Private Sub FRM_100004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "�@̫�ѱ�۰�ށ@                             "
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z
    '�y�ߒl�z
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
#Region "�@̫��۰��                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub LoadProcess()

    End Sub
#End Region
#Region "�@̫�ѱ�۰��                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫�ѱ�۰��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ClosingProcess()

        '******************************************
        ' ���۰ق̊J��
        '******************************************
  
    End Sub
#End Region

End Class