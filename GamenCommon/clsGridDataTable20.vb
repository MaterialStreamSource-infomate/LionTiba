'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�󎚗p�ް�ð���
' �y�쐬�zSIT
'**********************************************************************************************

Public Class clsGridDataTable20
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
        Me.Columns.Add("Data11")
        Me.Columns.Add("Data12")
        Me.Columns.Add("Data13")
        Me.Columns.Add("Data14")
        Me.Columns.Add("Data15")
        Me.Columns.Add("Data16")
        Me.Columns.Add("Data17")
        Me.Columns.Add("Data18")
        Me.Columns.Add("Data19")
        Me.Columns.Add("Data20")

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
    ''' <param name="strData11">�ް���Ăɾ�Ă���÷���ް�11</param>
    ''' <param name="strData12">�ް���Ăɾ�Ă���÷���ް�12</param>
    ''' <param name="strData13">�ް���Ăɾ�Ă���÷���ް�13</param>
    ''' <param name="strData14">�ް���Ăɾ�Ă���÷���ް�14</param>
    ''' <param name="strData15">�ް���Ăɾ�Ă���÷���ް�15</param>
    ''' <param name="strData16">�ް���Ăɾ�Ă���÷���ް�16</param>
    ''' <param name="strData17">�ް���Ăɾ�Ă���÷���ް�17</param>
    ''' <param name="strData18">�ް���Ăɾ�Ă���÷���ް�18</param>
    ''' <param name="strData19">�ް���Ăɾ�Ă���÷���ް�19</param>
    ''' <param name="strData20">�ް���Ăɾ�Ă���÷���ް�20</param>
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
                                 Optional ByVal strData10 As String = "", _
                                 Optional ByVal strData11 As String = "", _
                                 Optional ByVal strData12 As String = "", _
                                 Optional ByVal strData13 As String = "", _
                                 Optional ByVal strData14 As String = "", _
                                 Optional ByVal strData15 As String = "", _
                                 Optional ByVal strData16 As String = "", _
                                 Optional ByVal strData17 As String = "", _
                                 Optional ByVal strData18 As String = "", _
                                 Optional ByVal strData19 As String = "", _
                                 Optional ByVal strData20 As String = "" _
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
        objDataRow("Data11") = strData11
        objDataRow("Data12") = strData12
        objDataRow("Data13") = strData13
        objDataRow("Data14") = strData14
        objDataRow("Data15") = strData15
        objDataRow("Data16") = strData16
        objDataRow("Data17") = strData17
        objDataRow("Data18") = strData18
        objDataRow("Data19") = strData19
        objDataRow("Data20") = strData20
        objDataRow.EndEdit()

        Me.Rows.Add(objDataRow)

    End Sub
#End Region

End Class
