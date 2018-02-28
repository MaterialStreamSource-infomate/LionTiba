'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾃｰﾌﾞﾙ削除処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
Imports System.Threading
Imports System.Runtime.Remoting.Lifetime
#End Region

Public Class SVR_040001
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner"></param>
    ''' <param name="objDb"></param>
    ''' <param name="objDbLog"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  ﾒｲﾝ処理                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Function
#End Region



#Region "  ｽﾚｯﾄﾞ起動                                                                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 定期削除ｽﾚｯﾄﾞ起動
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecThreadStart() As Integer
        Try
            Dim objThread As New Threading.Thread(AddressOf Me.ExecThread)
            objThread.Start()

            Return RetCode.OK

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region
#Region "  ｽﾚｯﾄﾞ処理                                                                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｰﾌﾞﾙ削除処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ExecThread()
        Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        '↓↓↓↓↓↓************************************************************************************************************
        'Checked SystemMate:N.Dounoshita 2011/10/25 ｽﾚｯﾄﾞ用DB接続方法の修正
        'Dim mobjDb As clsConn                   'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ
        'Dim mobjDbLog As clsConn                'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書込み用)
        '↑↑↑↑↑↑************************************************************************************************************
        Dim requestInitialOwnership As Boolean = True
        Dim mutexWasCreated As Boolean
        Try

            '排他処理
            Dim objMtx As New Mutex(requestInitialOwnership, MUTEX_NAME_SVR_040001, mutexWasCreated)

            '排他待ち処理
            If Not (requestInitialOwnership And mutexWasCreated) Then
                objMtx.WaitOne()
            End If
            Try

                '↓↓↓↓↓↓************************************************************************************************************
                'Checked SystemMate:N.Dounoshita 2011/10/25 ｽﾚｯﾄﾞ用DB接続方法の修正

                '************************************
                'ｽﾚｯﾄﾞ用DB接続ｵﾌﾞｼﾞｪｸﾄの生成
                '************************************
                Call GetclsConnThreadConnect()

                ''DBｸｾｽｵﾌﾞｼﾞｪｸﾄ接続
                'Dim blnRet As Boolean
                'blnRet = False
                'mobjDb = New clsConn
                'mobjDb.ConnectString = ConfigFile.DBConnectString
                'blnRet = mobjDb.Connect()
                'If blnRet = False Then
                '    Throw New UserException(ERRMSG_DB_CONN)
                'End If
                'mobjDb.BeginTrans()

                ''DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ接続(ﾛｸﾞ書込み用)
                'blnRet = False
                'mobjDbLog = New clsConn
                'mobjDbLog.ConnectString = ConfigFile.DBConnectString
                'blnRet = mobjDbLog.Connect()
                'If blnRet = False Then
                '    Throw New UserException(ERRMSG_DB_CONN)
                'End If

                '↑↑↑↑↑↑************************************************************************************************************



                '************************
                '初期処理
                '************************
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


                '************************
                '定期削除ﾏｽﾀ読込み
                '************************
                Dim objTMST_DELETE_BASE As New TBL_TMST_DELETE(Owner, ObjDb, ObjDbLog)   '定期削除ﾏｽﾀｸﾗｽ
                intRet = Get_PlanDelete(objTMST_DELETE_BASE)

                If intRet = RetCode.OK Then
                    For Each objTMST_DELETE As TBL_TMST_DELETE In objTMST_DELETE_BASE.ARYME
                        '(ﾙｰﾌﾟ:ﾃｰﾌﾞﾙ名数)

                        Try
                            Dim strSQL As String        'SQL文
                            Dim intRetSQL As Integer    'SQL実行戻り値


                            '************************
                            '削除SQL作成
                            '************************
                            strSQL = ""
                            strSQL &= vbCrLf & "DELETE"
                            strSQL &= vbCrLf & " FROM"
                            strSQL &= vbCrLf & "    " & objTMST_DELETE.FTABLE_NAME
                            strSQL &= vbCrLf & " WHERE"
                            If TO_NUMBER(objTMST_DELETE.FDELETE_KUBUN) = FDELETE_KUBUN_SDAY Then
                                '(経過日数削除の場合)
                                If ConfigFile.DBKind = DB_KIND_ORACLE Then
                                    '(ORACLEの場合)
                                    strSQL &= vbCrLf & "    " & objTMST_DELETE.FDELETE_FIELD & " < TO_DATE('" & Format(DateAdd(DateInterval.Day, 0 - TO_NUMBER(objTMST_DELETE.FDELETE_VALUE), Now), "yyyy/MM/dd") & "','YYYY/MM/DD')"
                                ElseIf ConfigFile.DBKind = DB_KIND_SQLSERVER Then
                                    '(SQLSERVERの場合)
                                    strSQL &= vbCrLf & "    " & objTMST_DELETE.FDELETE_FIELD & " < '" & Format(DateAdd(DateInterval.Day, 0 - TO_NUMBER(objTMST_DELETE.FDELETE_VALUE), Now), "yyyy/MM/dd") & "'"
                                End If
                            ElseIf TO_NUMBER(objTMST_DELETE.FDELETE_KUBUN) = FDELETE_KUBUN_SVALUE Then
                                '(ｽﾃｰﾀｽ削除の場合)
                                strSQL &= vbCrLf & "    " & TO_STRING(objTMST_DELETE.FDELETE_FIELD) & " = " & TO_STRING(objTMST_DELETE.FDELETE_VALUE)
                            End If


                            '↓↓↓↓↓↓************************************************************************************************************
                            'SystemMate:A.Noto 2012/04/28  ﾃﾞｰﾀ削除条件項目を追加
                            If IsNotNull(objTMST_DELETE.FDELETE_KUBUN02) Then
                                '(削除区分02がNULLでないとき)
                                If TO_NUMBER(objTMST_DELETE.FDELETE_KUBUN02) = FDELETE_KUBUN_SDAY Then
                                    '(経過日数削除の場合)
                                    If ConfigFile.DBKind = DB_KIND_ORACLE Then
                                        '(ORACLEの場合)
                                        strSQL &= vbCrLf & " AND " & objTMST_DELETE.FDELETE_FIELD02 & " < TO_DATE('" & Format(DateAdd(DateInterval.Day, 0 - TO_NUMBER(objTMST_DELETE.FDELETE_VALUE02), Now), "yyyy/MM/dd") & "','YYYY/MM/DD')"
                                    ElseIf ConfigFile.DBKind = DB_KIND_SQLSERVER Then
                                        '(SQLSERVERの場合)
                                        strSQL &= vbCrLf & " AND " & objTMST_DELETE.FDELETE_FIELD02 & " < '" & Format(DateAdd(DateInterval.Day, 0 - TO_NUMBER(objTMST_DELETE.FDELETE_VALUE02), Now), "yyyy/MM/dd") & "'"
                                    End If
                                ElseIf TO_NUMBER(objTMST_DELETE.FDELETE_KUBUN02) = FDELETE_KUBUN_SVALUE Then
                                    '(ｽﾃｰﾀｽ削除の場合)
                                    strSQL &= vbCrLf & " AND " & TO_STRING(objTMST_DELETE.FDELETE_FIELD02) & " = " & TO_STRING(objTMST_DELETE.FDELETE_VALUE02)
                                End If
                            End If
                            '↑↑↑↑↑↑************************************************************************************************************


                            strSQL &= vbCrLf


                            '************************
                            '削除処理
                            '************************
                            intRetSQL = ObjDb.Execute(strSQL)
                            If intRetSQL = -1 Then
                                '(SQLｴﾗｰ)
                                strSQL = Replace(strSQL, vbCrLf, "")
                                strMsg = ObjDb.ErrMsg & "【" & strSQL & "】"
                                strMsg = ERRMSG_ERR_DELETE & strMsg
                                Throw New System.Exception(strMsg)
                            End If



                        Catch ex As UserException
                            Call ComUser(ex, MeSyoriID)
                            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ﾃｰﾌﾞﾙ名:" & TO_STRING(objTMST_DELETE.FTABLE_NAME) & "  ,削除区分:" & TO_STRING(objTMST_DELETE.FDELETE_KUBUN) & "]")
                            ObjDb.RollBack()                                   'ﾛｰﾙﾊﾞｯｸ
                            ObjDb.BeginTrans()                                 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                        Catch ex As Exception
                            Call ComError(ex, MeSyoriID)
                            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ﾃｰﾌﾞﾙ名:" & TO_STRING(objTMST_DELETE.FTABLE_NAME) & "  ,削除区分:" & TO_STRING(objTMST_DELETE.FDELETE_KUBUN) & "]")
                            ObjDb.RollBack()                                   'ﾛｰﾙﾊﾞｯｸ
                            ObjDb.BeginTrans()                                 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                        Finally
                            ObjDb.Commit()     'ｺﾐｯﾄ
                            ObjDb.BeginTrans() 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                        End Try
                    Next
                    objTMST_DELETE_BASE.ARYME_CLEAR()


                    '************************************************
                    '関連するｺﾞﾐﾚｺｰﾄﾞ削除(ｼｽﾃﾑ共通)
                    '************************************************
                    Call DeleteScrap()


                    '************************************************
                    '関連するｺﾞﾐﾚｺｰﾄﾞ削除(ｼｽﾃﾑ固有)
                    '************************************************
                    Call DeleteScrapSpecial()


                End If


                '************************
                '正常完了
                '************************
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL)


            Finally
                '排他処理開放
                objMtx.ReleaseMutex()

                '↓↓↓↓↓↓************************************************************************************************************
                'Checked SystemMate:N.Dounoshita 2011/10/25 ｽﾚｯﾄﾞ用DB接続方法の修正

                '************************************
                'ｽﾚｯﾄﾞ用DB接続ｵﾌﾞｼﾞｪｸﾄの開放
                '************************************
                Call DeleteclsConnThreadConnect()

                '↑↑↑↑↑↑************************************************************************************************************
            End Try


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region

#Region "  定期削除ﾏｽﾀ読込み                                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 定期削除ﾏｽﾀ読込み
    ''' </summary>
    ''' <param name="objTMST_DELETE">ﾃｰﾌﾞﾙ名(配列)</param>
    ''' <returns>OK/NotFound</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Get_PlanDelete(ByVal objTMST_DELETE As TBL_TMST_DELETE) As RetCode
        Try
            Dim strSQL As String                'SQL文
            'Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            'Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            'Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            'Dim ii As Integer                   'ｶｳﾝﾀ


            '************************
            '抽出SQL作成
            '************************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TMST_DELETE"
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    FTABLE_NAME"            'ﾃｰﾌﾞﾙ名
            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:A.Noto 2012/04/28  ﾊﾞｸﾞ修正
            'strSQL &= vbCrLf & "   ,FDELETE_KUBUN"    '削除区分
            strSQL &= vbCrLf & "   ,FCONDITION_SERIAL"      '条件連番
            '↑↑↑↑↑↑************************************************************************************************************

            strSQL &= vbCrLf


            '************************
            '抽出
            '************************
            objTMST_DELETE.USER_SQL = strSQL
            Return objTMST_DELETE.GET_TMST_DELETE_USER()


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  関連するｺﾞﾐﾚｺｰﾄﾞ削除(ｼｽﾃﾑ共通)                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 関連するｺﾞﾐﾚｺｰﾄﾞ削除(ｼｽﾃﾑ共通)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function DeleteScrap() As RetCode
        'Private Function DeleteSpecial() As RetCode
        Try


            Try
                '========================
                '作業履歴詳細ﾃｰﾌﾞﾙ
                '========================
                Dim objTEVD_OPE_DTL As New TBL_TEVD_OPE_DTL(Owner, ObjDb, ObjDbLog)
                objTEVD_OPE_DTL.DELETE_TEVD_OPE_DTL_SCRAP()

            Catch ex As UserException
                Call ComUser(ex, MeSyoriID)
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ﾃｰﾌﾞﾙ名:TEVD_OPE_DTL]")
                ObjDb.RollBack()                                   'ﾛｰﾙﾊﾞｯｸ
                ObjDb.BeginTrans()                                 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            Catch ex As Exception
                Call ComError(ex, MeSyoriID)
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ﾃｰﾌﾞﾙ名:TEVD_OPE_DTL]")
                ObjDb.RollBack()                                   'ﾛｰﾙﾊﾞｯｸ
                ObjDb.BeginTrans()                                 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            Finally
                ObjDb.Commit()     'ｺﾐｯﾄ
                ObjDb.BeginTrans() 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            End Try


            Try
                '========================
                'ﾃｰﾌﾞﾙ変更履歴詳細ﾃｰﾌﾞﾙ
                '========================
                Dim objTEVD_TBLCHANGE_DTL As New TBL_TEVD_TBLCHANGE_DTL(Owner, ObjDb, ObjDbLog)
                objTEVD_TBLCHANGE_DTL.DELETE_TEVD_TBLCHANGE_DTL_SCRAP()

            Catch ex As UserException
                Call ComUser(ex, MeSyoriID)
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ﾃｰﾌﾞﾙ名:TEVD_TBLCHANGE_DTL]")
                ObjDb.RollBack()                                   'ﾛｰﾙﾊﾞｯｸ
                ObjDb.BeginTrans()                                 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            Catch ex As Exception
                Call ComError(ex, MeSyoriID)
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ﾃｰﾌﾞﾙ名:TEVD_TBLCHANGE_DTL]")
                ObjDb.RollBack()                                   'ﾛｰﾙﾊﾞｯｸ
                ObjDb.BeginTrans()                                 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            Finally
                ObjDb.Commit()     'ｺﾐｯﾄ
                ObjDb.BeginTrans() 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            End Try


            Try
                '========================
                'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ詳細ﾃｰﾌﾞﾙ
                '========================
                Dim objTLOG_OPE_DTL As New TBL_TLOG_OPE_DTL(Owner, ObjDb, ObjDbLog)
                objTLOG_OPE_DTL.DELETE_TLOG_OPE_DTL_SCRAP()

            Catch ex As UserException
                Call ComUser(ex, MeSyoriID)
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ﾃｰﾌﾞﾙ名:TLOG_OPE_DTL]")
                ObjDb.RollBack()                                   'ﾛｰﾙﾊﾞｯｸ
                ObjDb.BeginTrans()                                 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            Catch ex As Exception
                Call ComError(ex, MeSyoriID)
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ﾃｰﾌﾞﾙ名:TLOG_OPE_DTL]")
                ObjDb.RollBack()                                   'ﾛｰﾙﾊﾞｯｸ
                ObjDb.BeginTrans()                                 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            Finally
                ObjDb.Commit()     'ｺﾐｯﾄ
                ObjDb.BeginTrans() 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            End Try


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:A.Noto 2012/07/05 ｶｺﾞﾒ那須では未使用

            'Try
            '    '========================
            '    'ﾎｽﾄ在庫照合詳細ﾃｰﾌﾞﾙ
            '    '========================
            '    Dim objTLOG_CHECK_HOST_DTL As New TBL_TLOG_CHECK_HOST_DTL(Owner, ObjDb, ObjDbLog)
            '    objTLOG_CHECK_HOST_DTL.DELETE_TLOG_CHECK_HOST_DTL_SCRAP()

            'Catch ex As UserException
            '    Call ComUser(ex, MeSyoriID)
            '    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ﾃｰﾌﾞﾙ名:TLOG_CHECK_HOST_DTL]")
            '    ObjDb.RollBack()                                   'ﾛｰﾙﾊﾞｯｸ
            '    ObjDb.BeginTrans()                                 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            'Catch ex As Exception
            '    Call ComError(ex, MeSyoriID)
            '    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ﾃｰﾌﾞﾙ名:TLOG_CHECK_HOST_DTL]")
            '    ObjDb.RollBack()                                   'ﾛｰﾙﾊﾞｯｸ
            '    ObjDb.BeginTrans()                                 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            'Finally
            '    ObjDb.Commit()     'ｺﾐｯﾄ
            '    ObjDb.BeginTrans() 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            'End Try


            'Try
            '    '========================
            '    'ﾛｯﾄﾏｽﾀﾃｰﾌﾞﾙ
            '    '========================
            '    Dim objTMST_LOT As New TBL_TMST_LOT(Owner, ObjDb, ObjDbLog)
            '    objTMST_LOT.DELETE_TMST_LOT_SCRAP()

            'Catch ex As UserException
            '    Call ComUser(ex, MeSyoriID)
            '    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ﾃｰﾌﾞﾙ名:TMST_LOT]")
            '    ObjDb.RollBack()                                   'ﾛｰﾙﾊﾞｯｸ
            '    ObjDb.BeginTrans()                                 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            'Catch ex As Exception
            '    Call ComError(ex, MeSyoriID)
            '    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [ﾃｰﾌﾞﾙ名:TMST_LOT]")
            '    ObjDb.RollBack()                                   'ﾛｰﾙﾊﾞｯｸ
            '    ObjDb.BeginTrans()                                 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            'Finally
            '    ObjDb.Commit()     'ｺﾐｯﾄ
            '    ObjDb.BeginTrans() 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            'End Try
            '↑↑↑↑↑↑************************************************************************************************************


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
#Region "  関連するｺﾞﾐﾚｺｰﾄﾞ削除(ｼｽﾃﾑ固有)                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 関連するｺﾞﾐﾚｺｰﾄﾞ削除(ｼｽﾃﾑ固有)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function DeleteScrapSpecial() As RetCode
        Try







        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
