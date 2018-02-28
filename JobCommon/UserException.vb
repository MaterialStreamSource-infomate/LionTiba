'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
' Åyã@î\Åz’∞ªﬁ¥◊∞∏◊Ω
' ÅyçÏê¨ÅzSIT
'**********************************************************************************************
Public Class UserException
    Inherits Exception

    Public Sub New(ByVal Message As String)
        MyBase.New(Message)
    End Sub
End Class
