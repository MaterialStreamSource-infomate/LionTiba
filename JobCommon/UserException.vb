'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
' �y�@�\�zհ�޴װ�׽
' �y�쐬�zSIT
'**********************************************************************************************
Public Class UserException
    Inherits Exception

    Public Sub New(ByVal Message As String)
        MyBase.New(Message)
    End Sub
End Class
