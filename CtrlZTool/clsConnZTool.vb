'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【機能】ｺﾈｸﾄｸﾗｽ
'         SQL文ﾛｸﾞを出力させるようにｵｰﾊﾞｰﾗｲﾄﾞした。
'
' 【作成】2012/02/22  KSH N.Dounoshita      Rev 0.00
'**********************************************************************************************

Public Class clsConnZTool
    Inherits JobCommon.clsConn

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="intConnectRtryCnt">DB再接続ﾘﾄﾗｲ回数(1はﾘﾄﾗｲなし)※省略時は1</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(Optional ByVal intConnectRtryCnt As Integer = 1)
        MyBase.new(intConnectRtryCnt)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <param name="objOwner">オーナオブジェクト定義</param>
    ''' <param name="intConnectRtryCnt">DB再接続ﾘﾄﾗｲ回数(1はﾘﾄﾗｲなし)※省略時は1</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, Optional ByVal intConnectRtryCnt As Integer = 1)
        MyBase.new(objOwner, intConnectRtryCnt)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  Execute"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 引数またはSQLプロパティに設定されたSQLを実行
    ''' </summary>
    ''' <param name="strSQL">SQL文 （省略時、SQLプロパティ設定されたSQLを実行</param>
    ''' <returns>正常時 処理件数(処理無し 0)/ 異常時 -1</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function Execute(Optional ByVal strSQL As String = "") As Integer


        '*******************************************************
        '初期処理
        '*******************************************************
        Dim dtmNow01 As Date = Now


        '*******************************************************
        '親ｸﾗｽ処理
        '*******************************************************
        Dim intRet As Integer     ' 汎用戻値
        intRet = MyBase.Execute(strSQL)


        '*******************************************************
        'ﾛｸﾞ出力
        '*******************************************************
        Dim objDiff As TimeSpan = Now - dtmNow01
        Call AddToLog(strSQL & vbCrLf & ";")
        Call AddToLog("[処理時間:" & CStr(CDec(objDiff.TotalMilliseconds / 1000)) & "]")


        Return intRet
    End Function
#End Region

End Class
