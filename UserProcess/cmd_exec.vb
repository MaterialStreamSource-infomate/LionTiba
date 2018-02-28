'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】自動実行処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports UserProcess
Imports MateCommon
Imports MateCommon.clsConst
Imports MateCommon.mdlComFunc
Imports JobCommon
#End Region

Public Class cmd_exec

#Region "  共通変数"
    Private Owner As Object                             'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ
    Private mobjDb As clsConn                           'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ
    Private mobjDbLog As clsConn                        'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)追加
    Private CmdNo As Integer                            '実行ｺﾏﾝﾄﾞNo.
    Private RcvDt As String                             '実行ﾒｯｾｰｼﾞ
    Private msgRecv As String                           '受信ﾒｯｾｰｼﾞ(ﾀﾞﾐｰ)
    Private msgSend As String                           '送信ﾒｯｾｰｼﾞ(ﾀﾞﾐｰ)
#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅーｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DB接続ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DB接続ｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)</param>
    ''' <param name="intCmd"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn, ByVal intCmd As Integer)
        Try
            'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ定義
            Owner = objOwner
            mobjDb = objDb
            mobjDbLog = objDbLog
            CmdNo = intCmd
            RcvDt = ""
        Catch ex As Exception
            ComError(ex)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅーｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DB接続ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DB接続ｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)追加</param>
    ''' <param name="strRcv"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn, ByVal strRcv As String)
        Try
            'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ定義
            Owner = objOwner
            mobjDb = objDb
            mobjDbLog = objDbLog
            CmdNo = 0
            RcvDt = strRcv
        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

#Region "  ﾃﾞｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｽﾄﾗｸﾀ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overrides Sub Finalize()
        'クローズ処理


        Call Close()
    End Sub
#End Region

#Region "  ｸﾛｰｽﾞ処理              (Public  Close)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾛｰｽﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Close()
        Try
            'ｵﾌﾞｼﾞｪｸﾄ開放
            Owner = Nothing
            mobjDb = Nothing
            mobjDbLog = Nothing
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  ｽﾚｯﾄﾞ開始                (Public  Go)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｽﾚｯﾄﾞ開始 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Go()
        Try
            'スレッドプール登録
            ThreadPool.QueueUserWorkItem(AddressOf Me.Start)
        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

#Region "  自動実行処理開始         (Public  Start)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 自動実行処理開始
    ''' </summary>
    ''' <param name="state">ｽﾃｰﾀｽｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Start(ByVal state As Object)
        Try
            'ﾀﾞﾐｰ受信ﾒｯｾｰｼﾞ作成
            msgRecv = ""
            If CmdNo <> 0 And RcvDt = "" Then
                msgRecv = ""
                msgRecv &= Space(4)                                     'SEQNO部分（ｽﾍﾟｰｽ）


                msgRecv &= Right("00" & Trim(Str(CmdNo)), 2)            'ID
                msgRecv &= Space(14)                                    'ID区分、HC、MHS送信時間
                msgRecv &= Space(232)                                   'DATA部分


            ElseIf CmdNo = 0 And RcvDt <> "" Then
                msgRecv = RcvDt
                msgRecv += StrDup(252, " ")
            End If

            If msgRecv <> "" Then
                'ｸﾗｲｱﾝﾄへ返信
                Dim objCmd As New cmd_manage(Me, mobjDb, mobjDbLog)
                objCmd.ExecCmd(msgRecv, msgSend)
            End If
        Catch e As Exception
            ComError(e)
        End Try
    End Sub
#End Region

#Region "  ｽﾚｯﾄﾞ強制終了            (Public  Cancel)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｽﾚｯﾄﾞ強制終了
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Cancel()
        Try
            'クローズ処理


            Call Close()
        Catch e As Exception
            ComError(e)
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

#Region "  ｴﾗｰ時 共通ﾓｼﾞｭｰﾙ       (Private ComError)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ時 共通ﾓｼﾞｭｰﾙ
    ''' </summary>
    ''' <param name="e">例外の基本ｵﾌﾞｼﾞｪｸﾄ</param>
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

#Region "  ﾛｸﾞ書込み処理          (Public  AddToLog)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込み処理
    ''' </summary>
    ''' <param name="strMsg">ﾛｸﾞ書込ﾒｯｾｰｼﾞ</param>
    ''' <param name="strProd"></param>
    ''' <param name="intType">ﾒｯｾｰｼﾞ区分    0:情報 1:ユーザエラー 2:システムエラー</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg As String, ByVal strProd As String, ByVal intType As LogType)
        Try
            If Owner Is Nothing = False Then
                Owner.AddToLog(strMsg, strProd, intType)
            End If
        Catch e As Exception
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
