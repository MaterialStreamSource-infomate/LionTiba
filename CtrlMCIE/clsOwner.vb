'**********************************************************************************************
' Copyright(C)SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zMCI��Ű��޼ު��
' �y�쐬�zSIT
'**********************************************************************************************

Imports MateCommon
Imports MateCommon.clsConst


Public Class clsOwner

    Private mobjfrmMCI As frmMCI            'Ҳ�̫��

#Region "  �����è��`"
    Public Property STRENTRY_NO() As frmMCI
        Get
            Return mobjfrmMCI
        End Get
        Set(ByVal Value As frmMCI)
            mobjfrmMCI = Value
        End Set
    End Property
#End Region

#Region "  ۸ޏ�������1"
    ''' ****************************************************************************************
    ''' <summary>
    ''' ۸ޏ�������1
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

#Region "  ۸ޏ�������2"
    ''' ****************************************************************************************
    ''' <summary>
    ''' ۸ޏ�������2
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)

        Call gobjMCI.AddToLog(strMsg_1)

    End Sub
#End Region

End Class
