'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】印字用ﾃﾞｰﾀﾃｰﾌﾞﾙ
' 【作成】SIT
'**********************************************************************************************

Public Class clsGridDataTable10
    Inherits DataTable

#Region "  ｺﾝｽﾄﾗｸﾀ      "
    Public Sub New()
        MyBase.new()     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装

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

#Region "  ﾃﾞｰﾀｾｯﾄへ一行ﾃﾞｰﾀ追加"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｾｯﾄへ一行ﾃﾞｰﾀ追加
    ''' </summary>
    ''' <param name="strData00">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ00</param>
    ''' <param name="strData01">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ02</param>
    ''' <param name="strData02">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ03</param>
    ''' <param name="strData03">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ04</param>
    ''' <param name="strData04">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ05</param>
    ''' <param name="strData05">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ06</param>
    ''' <param name="strData06">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ06</param>
    ''' <param name="strData07">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ07</param>
    ''' <param name="strData08">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ08</param>
    ''' <param name="strData09">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ09</param>
    ''' <param name="strData10">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ10</param>
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
