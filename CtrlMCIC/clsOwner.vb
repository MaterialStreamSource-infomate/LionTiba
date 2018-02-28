'**********************************************************************************************
' Copyright(C)SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' ÅyñºèÃÅzœ√ÿ±ŸΩƒÿ∞—ïWèÄã@î\
' Åyã@î\ÅzMCIµ∞≈∞µÃﬁºﬁ™∏ƒ
' ÅyçÏê¨ÅzSIT
'**********************************************************************************************

Imports MateCommon
Imports MateCommon.clsConst


Public Class clsOwner

    Private mobjfrmMCI As frmMCI            '“≤›Ã´∞—

#Region "  Ãﬂ€ ﬂ√®íËã`"
    Public Property STRENTRY_NO() As frmMCI
        Get
            Return mobjfrmMCI
        End Get
        Set(ByVal Value As frmMCI)
            mobjfrmMCI = Value
        End Set
    End Property
#End Region

#Region "  €∏ﬁèëçûèàóù1"
    ''' ****************************************************************************************
    ''' <summary>
    ''' €∏ﬁèëçûèàóù1
    ''' </summary>
    ''' <param name="strMsg"></param>
    ''' <param name="strProd"></param>
    ''' <param name="intType"></param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub AddToLog(ByVal strMsg As String, _
                        ByVal strProd As String, _
                        ByVal intType As Integer)

        Call gobjMCI.AddToLog(strMsg & Space(5) & strProd)


    End Sub
#End Region

#Region "  €∏ﬁèëçûèàóù2"
    ''' ****************************************************************************************
    ''' <summary>
    ''' €∏ﬁèëçûèàóù2
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)

        Call gobjMCI.AddToLog(strMsg_1)

    End Sub
#End Region

End Class
