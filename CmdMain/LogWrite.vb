'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾛｸﾞ登録処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Net
Imports System.Text
Imports System.Threading
Imports MateCommon.clsConst
Imports MateCommon
Imports MateCommon.mdlComFunc
Imports JobCommon
#End Region

Public Class LogWrite

#Region "  共通変数"
    Private Owner As Object                                 'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ
    Private mobjDb As clsConn                               'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ

    Private Const LEN_PROC_CD As Integer = 1024              'ﾌｨｰﾙﾄﾞ文字数判定
    Private Const LEN_LOG_DATA As Integer = 1024             'ﾌｨｰﾙﾄﾞ文字数判定

#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DB接続ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn)
        Try
            'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ定義
            Owner = objOwner
            mobjDb = objDb
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
        'ｵﾌﾞｼﾞｪｸﾄ開放
        Owner = Nothing
        mobjDb = Nothing
    End Sub
#End Region

#Region "  ﾛｸﾞ書込み処理                (Public  AddToLog)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込み処理
    ''' </summary>
    ''' <param name="strMsg">ﾛｸﾞ書込ﾒｯｾｰｼﾞ</param>
    ''' <param name="strProd"></param>
    ''' <param name="intType">ﾒｯｾｰｼﾞ区分    0:情報 1:ﾕｰｻﾞｴﾗｰ 2:ｼｽﾃﾑｴﾗｰ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function AddToLog(ByVal strMsg As String, ByVal strProd As String, ByVal intType As LogType) As Integer
        Try

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:Dou 2014/07/09 この箇所でﾃﾞｯﾄﾞﾛｯｸがかかっている疑いがかかったので、ｺﾒﾝﾄｱｳﾄ

            'Dim strPROC_CD As String            '処理ｺｰﾄﾞ
            'Dim strLOG_DATA As String           '異常内容

            '↑↑↑↑↑↑************************************************************************************************************


            '****************************
            'ﾛｸﾞ書込処理(上位ﾓｼﾞｭｰﾙ伝達)
            '****************************
            AddToLogUP(strMsg, strProd, intType)


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:Dou 2014/07/09 この箇所でﾃﾞｯﾄﾞﾛｯｸがかかっている疑いがかかったので、ｺﾒﾝﾄｱｳﾄ

            'If mobjDb Is Nothing = False Then
            '    Select Case intType
            '        Case LogType.SERR, LogType.UERR
            '            '(ｼｽﾃﾑｴﾗｰ/ﾕｰｻﾞｰｴﾗｰの場合)


            '            '************************
            '            'Insert情報の初期化
            '            '************************
            '            strPROC_CD = SQL_ITEM(strProd, LEN_PROC_CD)             '処理ｺｰﾄﾞ
            '            strLOG_DATA = SQL_ITEM(strMsg, LEN_LOG_DATA)            '異常内容


            '            '***********************
            '            'ｼｽﾃﾑｴﾗｰﾛｸﾞの登録
            '            '***********************
            '            Dim objTLOG_SYS As New UserProcess.TBL_TLOG_SYS(Owner, mobjDb, mobjDb)  'ｼｽﾃﾑｴﾗｰﾛｸﾞ
            '            objTLOG_SYS.FHASSEI_DT = Now                        '発生日時
            '            objTLOG_SYS.FPROC_CD = strPROC_CD                   '処理ｺｰﾄﾞ
            '            objTLOG_SYS.FLOG_DATA = strLOG_DATA                 '異常内容
            '            objTLOG_SYS.FLOG_KIND = TO_STRING(intType)          'ﾛｸﾞ種別
            '            objTLOG_SYS.ADD_TLOG_SYS_SEQ()                      '登録


            '    End Select
            'End If

            '↑↑↑↑↑↑************************************************************************************************************

            Return RetCode.OK
        Catch ex As Exception
            ComError(ex)
            Return RetCode.NG
        End Try
    End Function
#End Region

#Region "  ｴﾗｰ時共通ﾓｼﾞｭｰﾙ              (Private ComError)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ時共通ﾓｼﾞｭｰﾙ
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
            AddToLogUP(strMsg, strProd, LogType.SERR)
        Catch ex As Exception
            'NOP(Error 処理中の Error 回避)
        End Try
    End Sub
#End Region

#Region "  ﾛｸﾞ書込み処理                (Public  AddToLogUP)"
    '**********************************************************************************************
    '【引数】[IN] strMsg        ：
    '　　　　[IN] intType       ：
    '**********************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込み処理
    ''' </summary>
    ''' <param name="strMsg">ﾛｸﾞ書込ﾒｯｾｰｼﾞ</param>
    ''' <param name="strProd"></param>
    ''' <param name="intType">ﾒｯｾｰｼﾞ区分 0:情報 1:ﾕｰｻﾞｴﾗｰ 2:ｼｽﾃﾑｴﾗｰ</param>
    ''' <remarks></remarks>
    Public Sub AddToLogUP(ByVal strMsg As String, ByVal strProd As String, ByVal intType As LogType)
        Try
            If Owner Is Nothing = False Then
                Owner.AddToLog(strMsg, strProd, intType)
            End If
        Catch e As Exception
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

End Class
