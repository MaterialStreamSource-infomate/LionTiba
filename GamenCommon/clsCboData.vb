'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' y–¼ÌzÏÃØ±Ù½ÄØ°Ñ•W€‹@”\
' y‹@”\z‹¤’ÊŠÖ”
' yì¬zSIT
'**********************************************************************************************


Public Class clsCboData

#Region "  ÌßÛÊßÃ¨•Ï”              "
    ''' <summary>ÌßÛÊßÃ¨•Ï”</summary>
    Private mstrDisp As String
    Private mstrValue As String
    Public Const DISPLAYMEMBER As String = "Disp"
    Public Const VALUEMEMBER As String = "Value"
#End Region
#Region "  ÌßÛÊßÃ¨’è‹`              "
    ''' <summary>ÌßÛÊßÃ¨’è‹`</summary>
    Public Property Disp() As String
        Get
            Return mstrDisp
        End Get
        Set(ByVal Value As String)
            mstrDisp = Value
        End Set
    End Property
    Public Property Value() As String
        Get
            Return mstrValue
        End Get
        Set(ByVal Value As String)
            mstrValue = Value
        End Set
    End Property
#End Region
#Region "  ºİ½Ä×¸À                  "
    ''' <summary>ºİ½Ä×¸À</summary>
    Public Sub New(ByVal strDisp As String, ByVal strValue As String)
        mstrDisp = strDisp
        mstrValue = strValue
    End Sub
#End Region
#Region "  ToString‚Ìµ°ÊŞ°×²ÄŞ      "
    ''' <summary>ToString‚Ìµ°ÊŞ°×²Ä</summary>
    Public Overrides Function ToString() As String
        Return mstrDisp
    End Function
#End Region

End Class
