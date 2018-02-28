'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾀﾞﾐｰﾒｲﾝ処理（ｺﾝｿｰﾙ出力）
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports CmdMain
Imports System.Threading
Imports System.Windows.Forms
Imports MateCommon.clsConst
#End Region

Module DummyMain

#Region "  共通変数"
    Dim objLogWrite As New LogWrite
    Dim objManagerMain As New ManagerMain(objLogWrite)
#End Region

#Region "  ﾀﾞﾐｰﾒｲﾝ[ｺﾝｿｰﾙ表示]       (Main)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾀﾞﾐｰﾒｲﾝ[ｺﾝｿｰﾙ表示]
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Sub Main()
        Try
            Dim blnEndFlag As Boolean = False

            AddToLog("DummyMain 開始", "", LogType.INFO)
            objManagerMain.Start()

            While Not blnEndFlag
                'AddToLog("終了するには、end と入力して Enter キーを押します...", "", LogType.INFO)
                'Dim NewCulture As String = Console.ReadLine()

                Application.DoEvents()
                System.Threading.Thread.Sleep(1000)
                'If String.Compare(NewCulture, "end", True) = 0 And NewCulture <> "" Then blnEndFlag = True
            End While

            objManagerMain.Cancel()
            AddToLog("DummyMain 終了", "", LogType.INFO)
            End
        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

#Region "  ｴﾗｰ時 共通ﾓｼﾞｭｰﾙ         (ComError)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ時 共通ﾓｼﾞｭｰﾙ 
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
#End Region

#Region "  ﾛｸﾞ書込み処理            (AddToLog)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込み処理
    ''' </summary>
    ''' <param name="strMsg">ログ書込メッセージ</param>
    ''' <param name="strProd"></param>
    ''' <param name="intType">メッセージ区分 0:情報 1:ユーザエラー 2:システムエラー</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg As String, ByVal strProd As String, ByVal intType As LogType)
        Try
            objLogWrite.AddToLog(strMsg, strProd, intType)
        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

End Module
