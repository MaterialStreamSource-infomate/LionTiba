'**********************************************************************************************
' Copyright(C)SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】Exeｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
' 【作成】SIT
'**********************************************************************************************

Imports MateCommon
Imports MateCommon.clsConst


Public Class clsOwner

#Region "  ﾛｸﾞ書込処理1"
    ''' ****************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込処理1
    ''' </summary>
    ''' <param name="strMsg"></param>
    ''' <param name="strProd"></param>
    ''' <param name="intType"></param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub AddToLog(ByVal strMsg As String, _
                        ByVal strProd As String, _
                        ByVal intType As Integer)

        Call gobjExe.AddToLog(strMsg & Space(5) & strProd)


    End Sub
#End Region

#Region "  ﾛｸﾞ書込処理2"
    ''' ****************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込処理2
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)

        Call gobjExe.AddToLog(strMsg_1)

    End Sub
#End Region

End Class
