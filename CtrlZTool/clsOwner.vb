'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】画面用ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "imports"
Imports MateCommon.clsConst
Imports MateCommon
#End Region

Public Class clsOwner

#Region "  ﾛｸﾞ書込処理  (ｻｰﾊﾞｰ処理用)"
    ''' ****************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込処理  (ｻｰﾊﾞｰ処理用)
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

#Region "  ﾛｸﾞ書込処理  (画面用)"
    ''' ****************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込処理(画面用)
    ''' </summary>
    ''' <param name="strMsg_1">ﾒｯｾｰｼﾞ1</param>
    ''' <param name="udtErrorType">ｴﾗｰﾀｲﾌﾟ</param>
    ''' <param name="strMsg_3">ﾒｯｾｰｼﾞ3</param>
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
