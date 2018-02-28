'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�󎚗p�ް�ð���
' �y�쐬�zSIT
'**********************************************************************************************

Public Class clsGridDataTable05
    Inherits DataTable

#Region "  �ݽ�׸�      "
    Public Sub New()
        MyBase.new()     '�e�׽�̺ݽ�׸�������

        Me.Columns.Add("Data00")
        Me.Columns.Add("Data01")
        Me.Columns.Add("Data02")
        Me.Columns.Add("Data03")
        Me.Columns.Add("Data04")
        Me.Columns.Add("Data05")
    End Sub
#End Region

#Region "  �ް���Ăֈ�s�ް��ǉ�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���Ăֈ�s�ް��ǉ�
    ''' </summary>
    ''' <param name="strData00">�ް���Ăɾ�Ă���÷���ް�00</param>
    ''' <param name="strData01">�ް���Ăɾ�Ă���÷���ް�01</param>
    ''' <param name="strData02">�ް���Ăɾ�Ă���÷���ް�02</param>
    ''' <param name="strData03">�ް���Ăɾ�Ă���÷���ް�03</param>
    ''' <param name="strData04">�ް���Ăɾ�Ă���÷���ް�04</param>
    ''' <param name="strData05">�ް���Ăɾ�Ă���÷���ް�05</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub userAddRowDataSet(Optional ByVal strData00 As String = "", _
                                 Optional ByVal strData01 As String = "", _
                                 Optional ByVal strData02 As String = "", _
                                 Optional ByVal strData03 As String = "", _
                                 Optional ByVal strData04 As String = "", _
                                 Optional ByVal strData05 As String = "" _
                                 )

        Dim objDataRow As DataRow = Me.NewRow

        objDataRow.BeginEdit()
        objDataRow("Data00") = strData00
        objDataRow("Data01") = strData01
        objDataRow("Data02") = strData02
        objDataRow("Data03") = strData03
        objDataRow("Data04") = strData04
        objDataRow("Data05") = strData05
        objDataRow.EndEdit()

        Me.Rows.Add(objDataRow)

    End Sub
#End Region

End Class
