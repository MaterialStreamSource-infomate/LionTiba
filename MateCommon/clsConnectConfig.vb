'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】Configﾌｧｲﾙ接続ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

Imports System.Xml

Public Class clsConnectConfig

    Private mstrFileName As String           '接続するﾌｧｲﾙ名

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="strFileName">接続するﾌｧｲﾙ名</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal strFileName As String)
        mstrFileName = strFileName
    End Sub
#End Region

#Region "  Configﾌｧｲﾙから、情報取得"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Configﾌｧｲﾙから、情報取得
    ''' </summary>
    ''' <param name="sKey">検索するｷｰ</param>
    ''' <returns>Configﾌｧｲﾙから取得した文字列</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GET_INFO(ByVal sKey As String) As String

        Dim strRet As String = ""
        Dim reader As XmlNodeReader = Nothing
        Dim strNode As String


        strNode = ""
        '構成ファイルをXML DOMに読み込む
        Dim doc As XmlDocument = New XmlDocument
        doc.Load(mstrFileName)

        'ノードを探す
        Dim n As XmlNode
        For Each n In doc("configuration")("appSettings")
            If n.Name = "add" Then
                If n.Attributes.GetNamedItem("key").Value = sKey Then
                    strRet = n.Attributes.GetNamedItem("value").Value
                    Exit For
                End If
            End If
        Next


        Return (strRet)
    End Function
#End Region

End Class
