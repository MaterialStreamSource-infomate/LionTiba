'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z��ʗp��Ű��޼ު�ĸ׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "imports"
Imports MateCommon.clsConst
Imports MateCommon
#End Region

Public Class clsOwner

#Region "  ۸ޏ�������  (���ް�����p)"
    ''' ****************************************************************************************
    ''' <summary>
    ''' ۸ޏ�������  (���ް�����p)
    ''' </summary>
    ''' <param name="strMsg"></param>
    ''' <param name="strProd"></param>
    ''' <param name="intType"></param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub AddToLog(ByVal strMsg As String, _
                        ByVal strProd As String, _
                        ByVal intType As Integer)

        Call clsComFuncFRM.AddToLog_frm(strMsg, _
                                      AddToLog_D_ErrorType.PROGRAM_ERROR, _
                                      strProd)


    End Sub
#End Region

#Region "  ۸ޏ�������  (��ʗp)"
    ''' ****************************************************************************************
    ''' <summary>
    ''' ۸ޏ�������(��ʗp)
    ''' </summary>
    ''' <param name="strMsg_1">ү����1</param>
    ''' <param name="udtErrorType">�װ����</param>
    ''' <param name="strMsg_3">ү����3</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String, _
                        Optional ByVal udtErrorType As AddToLog_D_ErrorType = AddToLog_D_ErrorType.USER_LOG, _
                        Optional ByVal strMsg_3 As String = "")

        Call clsComFuncFRM.AddToLog_frm(strMsg_1, _
                                      udtErrorType, _
                                      strMsg_3)


    End Sub
#End Region

End Class
