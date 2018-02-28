'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�󎚗p�ް�ð���
' �y�쐬�zSIT
'**********************************************************************************************

Public Class clsGridDataTable10
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
        Me.Columns.Add("Data06")
        Me.Columns.Add("Data07")
        Me.Columns.Add("Data08")
        Me.Columns.Add("Data09")
        Me.Columns.Add("Data10")

    End Sub
#End Region

#Region "  �ް���Ăֈ�s�ް��ǉ�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���Ăֈ�s�ް��ǉ�
    ''' </summary>
    ''' <param name="strData00">�ް���Ăɾ�Ă���÷���ް�00</param>
    ''' <param name="strData01">�ް���Ăɾ�Ă���÷���ް�02</param>
    ''' <param name="strData02">�ް���Ăɾ�Ă���÷���ް�03</param>
    ''' <param name="strData03">�ް���Ăɾ�Ă���÷���ް�04</param>
    ''' <param name="strData04">�ް���Ăɾ�Ă���÷���ް�05</param>
    ''' <param name="strData05">�ް���Ăɾ�Ă���÷���ް�06</param>
    ''' <param name="strData06">�ް���Ăɾ�Ă���÷���ް�06</param>
    ''' <param name="strData07">�ް���Ăɾ�Ă���÷���ް�07</param>
    ''' <param name="strData08">�ް���Ăɾ�Ă���÷���ް�08</param>
    ''' <param name="strData09">�ް���Ăɾ�Ă���÷���ް�09</param>
    ''' <param name="strData10">�ް���Ăɾ�Ă���÷���ް�10</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub userAddRowDataSet(Optional ByVal strData00 As String = "", _
                                 Optional ByVal strData01 As String = "", _
                                 Optional ByVal strData02 As String = "", _
                                 Optional ByVal strData03 As String = "", _
                                 Optional ByVal strData04 As String = "", _
                                 Optional ByVal strData05 As String = "", _
                                 Optional ByVal strData06 As String = "", _
                                 Optional ByVal strData07 As String = "", _
                                 Optional ByVal strData08 As String = "", _
                                 Optional ByVal strData09 As String = "", _
                                 Optional ByVal strData10 As String = "" _
                                 )

        Dim objDataRow As DataRow = Me.NewRow

        objDataRow.BeginEdit()
        objDataRow("Data00") = strData00
        objDataRow("Data01") = strData01
        objDataRow("Data02") = strData02
        objDataRow("Data03") = strData03
        objDataRow("Data04") = strData04
        objDataRow("Data05") = strData05
        objDataRow("Data06") = strData06
        objDataRow("Data07") = strData07
        objDataRow("Data08") = strData08
        objDataRow("Data09") = strData09
        objDataRow("Data10") = strData10
        objDataRow.EndEdit()

        Me.Rows.Add(objDataRow)

    End Sub
#End Region

End Class
