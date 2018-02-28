'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾕｰｻﾞ処理分岐
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Text
Imports System.Threading
Imports MateCommon
Imports MateCommon.clsConst
Imports MateCommon.mdlComFunc
Imports JobCommon
#End Region

Public Class cmd_manage

#Region "  共通変数"
    Private Owner As Object                 'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ
    Private mobjDb As clsConn               'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ
    Private mobjDbLog As clsConn            'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)
    Private blnAutoFlg As Boolean           '自動処理ﾌﾗｸﾞ
#End Region

#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    ''' =======================================
    ''' <summary>自動処理ﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property AutoFlg( _
    ) As Boolean
        Get
            Return blnAutoFlg
        End Get
        Set(ByVal Value As Boolean)
            blnAutoFlg = Value
        End Set
    End Property
#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅーｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DB接続ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DB接続ｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        Try
            'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ定義
            Owner = objOwner
            mobjDb = objDb
            mobjDbLog = objDbLog
            blnAutoFlg = False
        Catch ex As Exception
            ComError(ex)
            Throw New System.Exception(ex.Message)
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
        Close()
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
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

#Region "  ｺﾏﾝﾄﾞ分岐処理          (Public  ExecCmd)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾏﾝﾄﾞ分岐処理
    ''' </summary>
    ''' <param name="msgRecv">受信ﾒｯｾｰｼﾞ</param>
    ''' <param name="msgSend">返答ﾒｯｾｰｼﾞ</param>
    ''' <returns>0:OK 1:NG 2:NotFound</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecCmd(ByVal msgRecv As String, ByRef msgSend As String) As Integer
        Try
            Dim requestInitialOwnership As Boolean = True
            Dim mutexWasCreated As Boolean
            Dim rtn As RetCode = RetCode.NG


            '************************
            '排他処理
            '************************
            Dim objMtx As New Mutex(requestInitialOwnership, "ExecCmd", mutexWasCreated)


            Try

                '************************
                '排他待ち処理
                '************************
                If Not (requestInitialOwnership And mutexWasCreated) Then
                    objMtx.WaitOne()
                End If


                '************************
                'ｺﾏﾝﾄﾞIDの特定
                '************************
                Dim strCmdNo As String
                objTelegramRecvDSP.FORMAT_ID = "DSP_000000"                 'ﾌｫｰﾏｯﾄ名ｾｯﾄ
                objTelegramRecvDSP.TELEGRAM_PARTITION = msgRecv             '分割する電文ｾｯﾄ
                objTelegramRecvDSP.PARTITION()                              '電文分割
                strCmdNo = objTelegramRecvDSP.SELECT_HEADER("DSPCMD_ID")


                If blnAutoFlg = False And Val(strCmdNo) <> 0 Then
                    '(ｺﾏﾝﾄﾞ処理の場合)

                    '************************
                    'ｺﾏﾝﾄﾞ処理
                    '************************
                    Dim objCmdJnc As New cmd_junction(Owner, mobjDb, mobjDbLog)
                    objCmdJnc.ExecCmd(msgRecv, msgSend)




                ElseIf ConfigFile.TimerAdvEnable <> FLAG_OFF Then
                    '(定周期処理の場合)

                    Dim strSQL As String            'SQL文
                    Dim intRetSQL As Integer        'SQL実行戻り値
                    Dim dtmNow As DateTime = Now    '現在時刻
                    Dim intLoopCnt As Integer = 0   'ﾙｰﾌﾟｶｳﾝﾀ
                    Dim intDataCnt As Integer = 0   '処理件数
                    Dim intRet As RetCode = RetCode.NG
                    Dim ds1 As New DataSet          'ﾃﾞｰﾀｾｯﾄ
                    Dim oRow As DataRow             '１ﾚｺｰﾄﾞ分のﾃﾞｰﾀ


                    Dim blnFirstFlg As Boolean = True   '初回処理フラグ

                    '最大10回まで連続実行
                    While (blnFirstFlg = True) Or _
                          (intDataCnt > 0 And intLoopCnt <= 10)
                        '(ﾙｰﾌﾟ:処理するﾚｺｰﾄﾞがなくなるまで)


                        '************************
                        '定周期処理取得SQL作成
                        '************************
                        strSQL = "SELECT * FROM "
                        If ConfigFile.DBKind = DB_KIND_SQLSERVER Then
                            '(SQLSERVERの場合)
                            strSQL &= vbCrLf & ""
                        End If
                        strSQL &= vbCrLf & "TPRG_TIMER "
                        strSQL &= vbCrLf & "WHERE "
                        strSQL &= vbCrLf & "   ( "
                        strSQL &= vbCrLf & "   FTIME_OUT_SEC <> 0 "
                        strSQL &= vbCrLf & "   AND "
                        strSQL &= vbCrLf & "   ( "
                        strSQL &= vbCrLf & "   FYUKOU_FLAG = 1 "
                        If ConfigFile.DBKind = DB_KIND_ORACLE Then
                            '(ORACLEの場合)
                            strSQL &= vbCrLf & "   AND TO_DATE('" & Format(dtmNow, "yyyy/MM/dd HH:mm:ss") & "', 'YYYY/MM/DD HH24:MI:SS') - FLAST_DT > (FTIME_OUT_SEC / 86400) "
                        ElseIf ConfigFile.DBKind = DB_KIND_SQLSERVER Then
                            '(SQLSERVERの場合)
                            strSQL &= vbCrLf & "   AND '" & Format(dtmNow, "yyyy/MM/dd HH:mm:ss") & "' - FLAST_DT > (FTIME_OUT_SEC / 86400) "
                        End If
                        strSQL &= vbCrLf & "   ) "

                        '定刻処理対応
                        If ConfigFile.DBKind = DB_KIND_ORACLE Then
                            strSQL &= vbCrLf & "   OR (FEXEC_DT IS NOT NULL "
                            strSQL &= vbCrLf & "   AND TO_CHAR(FEXEC_DT, 'HH24:MI:SS') <= TO_CHAR(SYSDATE, 'HH24:MI:SS')"
                            strSQL &= vbCrLf & "   AND TO_CHAR(FLAST_DT, 'YYYY/MM/DD HH24:MI:SS') < TO_CHAR(SYSDATE, 'YYYY/MM/DD') || ' ' || TO_CHAR(FEXEC_DT, 'HH24:MI:SS')"
                            strSQL &= vbCrLf & "   ) "
                            strSQL &= vbCrLf & "   OR (FEXEC_DT IS NOT NULL "
                            strSQL &= vbCrLf & "   AND TO_CHAR(SYSDATE, 'HH24:MI:SS') < TO_CHAR(FEXEC_DT, 'HH24:MI:SS')"
                            strSQL &= vbCrLf & "   AND TO_CHAR(FLAST_DT, 'YYYY/MM/DD HH24:MI:SS') < TO_CHAR(SYSDATE - 1, 'YYYY/MM/DD') || ' ' || TO_CHAR(FEXEC_DT, 'HH24:MI:SS')"
                            strSQL &= vbCrLf & "   ) "
                        End If

                        strSQL &= vbCrLf & "   OR FKIDOU_FLAG = 1 "
                        strSQL &= vbCrLf & "   ) "
                        strSQL &= vbCrLf & "ORDER BY FRANK DESC,FRANK_DTL DESC,FSYORI_ID ASC "


                        '************************
                        '抽出
                        '************************
                        ds1.Clear()
                        mobjDb.SQL = strSQL
                        mobjDb.GetDataSet("TPRG_TIMER", ds1)


                        '************************
                        'ﾄﾗﾝｻﾞｸｼｮﾝ処理開始
                        '************************
                        mobjDb.BeginTrans()
                        intRet = RetCode.NG


                        Try

                            '************************
                            '定周期管理更新SQL作成
                            '************************
                            strSQL = "UPDATE "
                            If ConfigFile.DBKind = DB_KIND_SQLSERVER Then
                                '(SQLSERVERの場合)
                                strSQL &= vbCrLf & ""
                            End If
                            strSQL &= vbCrLf & "TPRG_TIMER "
                            strSQL &= vbCrLf & "SET "
                            strSQL &= vbCrLf & "FKIDOU_FLAG = 0 "                     '起動ﾌﾗｸﾞOFF
                            If ConfigFile.DBKind = DB_KIND_ORACLE Then
                                '(ORACLEの場合)
                                strSQL &= vbCrLf & "," & "FLAST_DT = TO_DATE('" & Format(dtmNow, "yyyy/MM/dd HH:mm:ss") & "', 'YYYY/MM/DD HH24:MI:SS') "      '更新日時
                            ElseIf ConfigFile.DBKind = DB_KIND_SQLSERVER Then
                                '(SQLSERVERの場合)
                                strSQL &= vbCrLf & "," & "FLAST_DT = '" & Format(dtmNow, "yyyy/MM/dd HH:mm:ss") & "' "      '更新日時
                            End If

                            strSQL &= vbCrLf & "WHERE "
                            strSQL &= vbCrLf & "   ( "
                            strSQL &= vbCrLf & "   FTIME_OUT_SEC <> 0 "
                            strSQL &= vbCrLf & "   AND "
                            strSQL &= vbCrLf & "   ( "
                            strSQL &= vbCrLf & "   FYUKOU_FLAG = 1 "
                            If ConfigFile.DBKind = DB_KIND_ORACLE Then
                                '(ORACLEの場合)
                                strSQL &= vbCrLf & "   AND TO_DATE('" & Format(dtmNow, "yyyy/MM/dd HH:mm:ss") & "', 'YYYY/MM/DD HH24:MI:SS') - FLAST_DT > (FTIME_OUT_SEC / 86400) "
                            ElseIf ConfigFile.DBKind = DB_KIND_SQLSERVER Then
                                '(SQLSERVERの場合)
                                strSQL &= vbCrLf & "   AND '" & Format(dtmNow, "yyyy/MM/dd HH:mm:ss") & "' - FLAST_DT > (FTIME_OUT_SEC / 86400) "
                            End If

                            strSQL &= vbCrLf & "   ) OR ("
                            strSQL &= vbCrLf & "   FYUKOU_FLAG = 1 "
                            If ConfigFile.DBKind = DB_KIND_ORACLE Then
                                '(ORACLEの場合)
                                strSQL &= vbCrLf & "   AND TO_DATE('" & Format(dtmNow, "yyyy/MM/dd HH:mm:ss") & "', 'YYYY/MM/DD HH24:MI:SS') < FLAST_DT "
                            ElseIf ConfigFile.DBKind = DB_KIND_SQLSERVER Then
                                '(SQLSERVERの場合)
                                strSQL &= vbCrLf & "   AND '" & Format(dtmNow, "yyyy/MM/dd HH:mm:ss") & "' < FLAST_DT "
                            End If
                            strSQL &= vbCrLf & "   ) "

                            '定刻処理対応
                            If ConfigFile.DBKind = DB_KIND_ORACLE Then
                                strSQL &= vbCrLf & "   OR (FEXEC_DT IS NOT NULL "
                                strSQL &= vbCrLf & "   AND TO_CHAR(FEXEC_DT, 'HH24:MI:SS') <= TO_CHAR(SYSDATE, 'HH24:MI:SS')"
                                strSQL &= vbCrLf & "   AND TO_CHAR(FLAST_DT, 'YYYY/MM/DD HH24:MI:SS') < TO_CHAR(SYSDATE, 'YYYY/MM/DD') || ' ' || TO_CHAR(FEXEC_DT, 'HH24:MI:SS')"
                                strSQL &= vbCrLf & "   ) "
                                strSQL &= vbCrLf & "   OR (FEXEC_DT IS NOT NULL "
                                strSQL &= vbCrLf & "   AND TO_CHAR(SYSDATE, 'HH24:MI:SS') < TO_CHAR(FEXEC_DT, 'HH24:MI:SS')"
                                strSQL &= vbCrLf & "   AND TO_CHAR(FLAST_DT, 'YYYY/MM/DD HH24:MI:SS') < TO_CHAR(SYSDATE - 1, 'YYYY/MM/DD') || ' ' || TO_CHAR(FEXEC_DT, 'HH24:MI:SS')"
                                strSQL &= vbCrLf & "   ) "
                            End If

                            strSQL &= vbCrLf & "   OR FKIDOU_FLAG = 1 "
                            strSQL &= vbCrLf & "   ) "


                            '************************
                            '更新
                            '************************
                            intRetSQL = mobjDb.Execute(strSQL)
                            If intRetSQL < 0 Then
                                Throw New System.Exception(mobjDb.ErrMsg.ToString & "【" & strSQL & "】")
                            End If
                            intRet = RetCode.OK


                        Catch e As Exception
                            ComError(e)
                            Throw New System.Exception(e.Message)
                        Finally
                            If intRet = RetCode.OK Then
                                '************************
                                'ｺﾐｯﾄ処理
                                '************************
                                mobjDb.Commit()
                            Else
                                '************************
                                '異常時はﾛｰﾙﾊﾞｯｸ処理
                                '************************
                                mobjDb.RollBack()
                            End If
                        End Try


                        '************************
                        '定周期ｺﾏﾝﾄﾞ処理
                        '************************
                        If ds1.Tables("TPRG_TIMER").Rows.Count > 0 Then
                            '(定周期処理が存在する場合)
                            For Each oRow In ds1.Tables("TPRG_TIMER").Rows
                                '(ﾙｰﾌﾟ:定周期処理数)

                                Dim msgRecvDmy As String = ""               '受信ﾒｯｾｰｼﾞ(ﾀﾞﾐｰ)
                                Dim msgSendDmy As String = ""               '送信ﾒｯｾｰｼﾞ(ﾀﾞﾐｰ)
                                msgRecvDmy = TO_STRING(oRow("FSOCKET_MSG"))      'ﾒｯｾｰｼﾞID取得
                                If msgRecvDmy <> DEFAULT_STRING Then
                                    '(ﾒｯｾｰｼﾞIDが存在する場合)
                                    msgRecv = ""
                                    If msgRecvDmy <> "" Then
                                        'ｸﾗｲｱﾝﾄへ返信
                                        Dim objCmdJnc As New cmd_junction(Me, mobjDb, mobjDbLog)
                                        objCmdJnc.ExecCmd(msgRecvDmy, msgSendDmy)
                                    End If
                                End If

                            Next
                        End If

                        blnFirstFlg = False                                 '初回処理フラグ
                        intDataCnt = ds1.Tables("TPRG_TIMER").Rows.Count    '処理件数
                        intLoopCnt += 1                                     'ﾙｰﾌﾟｶｳﾝﾀ
                    End While

                End If

            Catch ex As Exception
                ComError(ex)
                Throw New System.Exception(ex.Message)
                rtn = RetCode.NG
            Finally
                '************************
                '排他処理開放
                '************************
                objMtx.ReleaseMutex()
            End Try


            Return rtn
        Catch ex As Exception
            ComError(ex)
            Return RetCode.NG
        End Try
    End Function
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
    ''' <param name="intType">ﾒｯｾｰｼﾞ区分    0:情報 1:ﾕｰｻﾞｴﾗｰ 2:ｼｽﾃﾑｴﾗｰ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg As String, ByVal strProd As String, ByVal intType As LogType)
        Try
            If Owner Is Nothing = False Then
                Owner.AddToLog(strMsg, strProd, intType)
            End If
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
