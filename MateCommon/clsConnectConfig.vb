'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zConfiģ�ِڑ��׽
' �y�쐬�zSIT
'**********************************************************************************************

Imports System.Xml

Public Class clsConnectConfig

    Private mstrFileName As String           '�ڑ�����̧�ٖ�

#Region "  �ݽ�׸�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ݽ�׸�
    ''' </summary>
    ''' <param name="strFileName">�ڑ�����̧�ٖ�</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal strFileName As String)
        mstrFileName = strFileName
    End Sub
#End Region

#Region "  Confiģ�ق���A���擾"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Confiģ�ق���A���擾
    ''' </summary>
    ''' <param name="sKey">�������鷰</param>
    ''' <returns>Confiģ�ق���擾����������</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GET_INFO(ByVal sKey As String) As String

        Dim strRet As String = ""
        Dim reader As XmlNodeReader = Nothing
        Dim strNode As String


        strNode = ""
        '�\���t�@�C����XML DOM�ɓǂݍ���
        Dim doc As XmlDocument = New XmlDocument
        doc.Load(mstrFileName)

        '�m�[�h��T��
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
