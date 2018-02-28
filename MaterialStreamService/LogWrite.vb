'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾛｸﾞ登録処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports System.Diagnostics
Imports MateCommon.clsConst
#End Region

Public Class LogWrite

#Region "  ﾛｸﾞ書込み処理          (Public  AddToLog)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ログ書き込み処理
    ''' </summary>
    ''' <param name="strMsg">ログ書込メッセージ</param>
    ''' <param name="strProd"></param>
    ''' <param name="intType">メッセージ区分    0:情報 1:ユーザエラー 2:システムエラー</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg As String, ByVal strProd As String, ByVal intType As LogType)
        '2004/11/29 ↓↓↓ ログ書込み機能を ManagerMain に移動
        'Windows イベントに登録
        'Dim objEvtLog As New EventLog
        'objEvtLog.Source = "MaterialStream"
        'objEvtLog.WriteEntry(strMsg, EventLogEntryType.Information)
        '2004/11/29 ↑↑↑ ログ書込み機能を ManagerMain に移動
    End Sub
#End Region

End Class
