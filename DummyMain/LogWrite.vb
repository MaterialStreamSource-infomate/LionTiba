'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 2004
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾛｸﾞ登録処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports MateCommon.clsConst
#End Region

Public Class LogWrite

#Region "  ﾛｸﾞ書込み処理          (Public  AddToLog)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込み処理
    ''' </summary>
    ''' <param name="strMsg">ﾛｸﾞ書込ﾒｯｾｰｼﾞ</param>
    ''' <param name="strProd"></param>
    ''' <param name="intType">ﾒｯｾｰｼﾞ区分 0:情報 1:ﾕｰｻﾞｰｴﾗｰ 2:ｼｽﾃﾑｴﾗｰ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg As String, ByVal strProd As String, ByVal intType As LogType)
        'ｺﾝｿｰﾙに内容を表示
        Console.WriteLine(Format(Now, "yyyy/MM/dd HH:mm:ss.ffffff ") & strProd & strMsg)
    End Sub
#End Region

End Class
