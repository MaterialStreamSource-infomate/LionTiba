'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTDn 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｻｰﾊﾞﾌﾟﾛｾｽ　ﾒｲﾝ処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports System.Text
Imports MateCommon.clsConst
Imports CmdMain
#End Region

Public Class MaterialStream

    Private objLogWrite As New LogWrite
    Private objManagerMain As New ManagerMain(objLogWrite)

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' サービスを開始するコードをここに追加します。このメソッドによって、
        ' サービスが正しく実行されるようになります
        AddToLog("ServiceMain 開始", "", LogType.INFO)
        objManagerMain.Start()
    End Sub

    Protected Overrides Sub OnStop()
        ' サービスを停止するのに必要な終了処理を実行するコードをここに追加します。
        objManagerMain.Cancel()
        AddToLog("ServiceMain 終了", "", LogType.INFO)
    End Sub


    ''' *******************************************************************************************************************
    ''' <summary>
    ''' エラー時 共通モジュール
    ''' </summary>
    ''' <param name="e">例外の基本オブジェクト</param>
    ''' <param name="strFunc"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ComError(ByVal e As Exception, Optional ByVal strFunc As String = "")
        Try
            Dim strMsg As String = ""
            Dim strProd As String = ""
            strProd &= "Src=[" & CType(CType(e.TargetSite, System.Reflection.MethodBase).ReflectedType, System.Type).FullName
            strProd &= "." & CType(e.TargetSite, System.Reflection.MethodBase).Name & "]"
            If strFunc <> "" Then
                strProd &= " Fnc=[" & strFunc & "]"
            End If
            strMsg &= "Msg=[" & e.Message & "]"
            AddToLog(strMsg, strProd, LogType.SERR)
        Catch ex As Exception
            'NOP(Error 処理中の Error 回避)
        End Try
    End Sub

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
        Try
            'Windows イベントに登録
            'Dim objEvtLog As New EventLog
            'objEvtLog.Source = "MaterialStream"
            'Select Case intType
            '    Case LogType.LogInfo
            '        objEvtLog.WriteEntry(strMsg, EventLogEntryType.Information)
            '    Case LogType.LogSerr
            '        objEvtLog.WriteEntry(strMsg, EventLogEntryType.Error)
            '    Case LogType.LogUerr
            '        objEvtLog.WriteEntry(strMsg, EventLogEntryType.Warning)
            'End Select
            objLogWrite.AddToLog(strMsg, strProd, intType)
        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Sub

End Class
