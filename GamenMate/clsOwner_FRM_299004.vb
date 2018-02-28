'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' ÅyñºèÃÅzœ√ÿ±ŸΩƒÿ∞—ïWèÄã@î\
' Åyã@î\ÅzMCIµ∞≈∞µÃﬁºﬁ™∏ƒ
' ÅyçÏê¨ÅzSIT
'**********************************************************************************************

Imports MateCommon
Imports MateCommon.clsConst


Public Class clsOwner_FRM_299004

    Private mobjfrmMCI As FRM_299004            '“≤›Ã´∞—

#Region "  Ãﬂ€ ﬂ√®íËã`"
    ''' <summary>
    ''' µ∞≈∞Ã´∞—
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property objOwnerForm() As FRM_299004
        Get
            Return mobjfrmMCI
        End Get
        Set(ByVal Value As FRM_299004)
            mobjfrmMCI = Value
        End Set
    End Property
#End Region

#Region "  €∏ﬁèëçûèàóù1"
    Public Sub AddToLog(ByVal strMsg As String, _
                        ByVal strProd As String, _
                        ByVal intType As Integer)

        Call mobjfrmMCI.AddToLog(strMsg & Space(5) & strProd)


    End Sub
#End Region

#Region "  €∏ﬁèëçûèàóù2"
    ''' ****************************************************************************************
    ''' <summary>
    ''' €∏ﬁèëçûèàóù2
    ''' </summary>
    ''' <param name="strMsg_1">“Øæ∞ºﬁ1</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)

        Call mobjfrmMCI.AddToLog(strMsg_1)

    End Sub
#End Region

End Class
