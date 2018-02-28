#Region "  Imports"
Imports System.Xml
#End Region

Public Class clsConfigReader
    '==================================================================
    '   Private変数
    '==================================================================
    Private msFile As String

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Configﾌｧｲﾙ名
    ''' </summary>
    ''' <param name="sFile"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal sFile As String)
        Try
            msFile = sFile
        Catch e As Exception
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

#Region "  Configﾌｧｲﾙ情報の取得             (Private GetConfigProfile)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Configﾌｧｲﾙ情報の取得
    ''' </summary>
    ''' <param name="sKey">キー名</param>
    ''' <returns>取得文字列</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetConfigProfile(ByVal sKey As String) As String
        Try
            Dim strRet As String = ""
            Dim reader As XmlNodeReader = Nothing
            Dim strNode As String

            strNode = ""
            '構成ファイルをXML DOMに読み込む
            Dim doc As New XmlDocument
            doc.Load(msFile)

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

            Return strRet
        Catch e As Exception
            Throw New System.Exception(e.Message)
        End Try
    End Function
#End Region

End Class
