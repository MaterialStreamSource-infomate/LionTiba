'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zMCI��Ű��޼ު��
' �y�쐬�zSIT
'**********************************************************************************************

Imports MateCommon
Imports MateCommon.clsConst


Public Class clsOwner_FRM_299004

    Private mobjfrmMCI As FRM_299004            'Ҳ�̫��

#Region "  �����è��`"
    ''' <summary>
    ''' ��Ű̫��
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

#Region "  ۸ޏ�������1"
    Public Sub AddToLog(ByVal strMsg As String, _
                        ByVal strProd As String, _
                        ByVal intType As Integer)

        Call mobjfrmMCI.AddToLog(strMsg & Space(5) & strProd)


    End Sub
#End Region

#Region "  ۸ޏ�������2"
    ''' ****************************************************************************************
    ''' <summary>
    ''' ۸ޏ�������2
    ''' </summary>
    ''' <param name="strMsg_1">ү����1</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)

        Call mobjfrmMCI.AddToLog(strMsg_1)

    End Sub
#End Region

End Class
