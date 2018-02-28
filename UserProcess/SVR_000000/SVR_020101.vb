'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】搬送設備受信読込処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_020101
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
        Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Dim ii As Integer                       'ｶｳﾝﾀ
        Try

            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 'ｼｽﾃﾑ変数


            '************************
            '定周期処理
            '************************
            Call ProcessTimer01()


            '************************
            '搬送制御受信IF読込み
            '************************
            Dim objTLIF_TRNS_RECV_Array(0) As TBL_TLIF_TRNS_RECV        '搬送制御受信IFｸﾗｽ
            intRet = Get_TrnsRecv(objTLIF_TRNS_RECV_Array)
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                Return RetCode.OK
            End If


            ''************************
            ''初期処理
            ''************************
            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            For ii = LBound(objTLIF_TRNS_RECV_Array) To UBound(objTLIF_TRNS_RECV_Array)
                '(ﾙｰﾌﾟ:未処理指示)

                '************************
                '搬送制御受信IFの特定
                '************************
                Dim objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV                 '搬送制御受信IFｸﾗｽ
                objTLIF_TRNS_RECV = objTLIF_TRNS_RECV_Array(ii)

                Try

                    '******************************
                    '応答ｺｰﾄﾞﾁｪｯｸ
                    '******************************
                    Dim objTMST_RES_CD_EQ As New TBL_TMST_RES_CD_EQ(Owner, ObjDb, ObjDbLog) '応答ｺｰﾄﾞ処理ﾏｽﾀｸﾗｽ
                    objTMST_RES_CD_EQ.FEQ_ID = objTLIF_TRNS_RECV.FEQ_ID                     '設備ID
                    objTMST_RES_CD_EQ.FDIRECTION = FDIRECTION_SRECV                         '方向
                    If IsNull(objTLIF_TRNS_RECV.FRES_CD_EQ) = True Then
                        objTMST_RES_CD_EQ.FRES_CD_EQ = FRES_CD_EQ_SMCI_OK                   '設備応答ｺｰﾄﾞ
                    Else
                        objTMST_RES_CD_EQ.FRES_CD_EQ = objTLIF_TRNS_RECV.FRES_CD_EQ         '設備応答ｺｰﾄﾞ
                    End If
                    intRet = objTMST_RES_CD_EQ.GET_TMST_RES_CD_EQ(False)
                    If intRet = RetCode.OK Then
                        '(見つかった場合)

                        '========================
                        'ﾒｯｾｰｼﾞ出力
                        '========================
                        If TO_INTEGER(objTMST_RES_CD_EQ.FMSG_FLAG) = FLAG_ON Then
                            '(ﾒｯｾｰｼﾞﾛｸﾞ出力ﾌﾗｸﾞがONの場合)
                            Select Case objTLIF_TRNS_RECV.FEQ_ID
                                Case FEQ_ID_JSYS0000 : Call AddToMsgLog(Now, FMSG_ID_J6003, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "応答ｺｰﾄﾞ(MELSEC→ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0001 : Call AddToMsgLog(Now, FMSG_ID_J6103, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "応答ｺｰﾄﾞ(SW01  →ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0002 : Call AddToMsgLog(Now, FMSG_ID_J6203, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "応答ｺｰﾄﾞ(SW02  →ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0003 : Call AddToMsgLog(Now, FMSG_ID_J6303, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "応答ｺｰﾄﾞ(SW03  →ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0004 : Call AddToMsgLog(Now, FMSG_ID_J6403, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "応答ｺｰﾄﾞ(SW04  →ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0005 : Call AddToMsgLog(Now, FMSG_ID_J6503, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "応答ｺｰﾄﾞ(SW05  →ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0006 : Call AddToMsgLog(Now, FMSG_ID_J6603, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "応答ｺｰﾄﾞ(SW04A →ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                    '↓↓↓↓↓↓************************************************************************************************************
                                    'JobMate:S.Ouchi 2015/06/25 CW6追加対応 ↓↓↓↓↓↓
                                Case FEQ_ID_JSYS0007 : Call AddToMsgLog(Now, FMSG_ID_J6703, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "応答ｺｰﾄﾞ(SW06  →ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                    'JobMate:S.Ouchi 2015/06/25 CW6追加対応 ↑↑↑↑↑↑
                                    '↑↑↑↑↑↑************************************************************************************************************
                            End Select
                        End If

                        '========================
                        '設備切離
                        '========================
                        If TO_INTEGER(objTMST_RES_CD_EQ.FCUT_FLAG) = FLAG_ON Then
                            '(設備切離ﾌﾗｸﾞがONの場合)

                            '========================
                            '設備状況の更新
                            '========================
                            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     '設備状況ｸﾗｽ
                            objTSTS_EQ_CTRL.FEQ_ID = objTLIF_TRNS_RECV.FEQ_ID                       '設備ID
                            intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(False)                        '特定
                            If intRet = RetCode.NotFound Then
                                '(見つからない場合)
                                strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]"
                                Throw New UserException(strMsg)
                            End If
                            objTSTS_EQ_CTRL.FEQ_CUT_STS = FLAG_ON           '切離状態
                            objTSTS_EQ_CTRL.FUPDATE_DT = Now                '更新日時
                            objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()           '更新

                            '========================
                            '搬送制御送信IFの更新
                            '========================
                            objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_STRY     '進捗状態
                            objTLIF_TRNS_RECV.FRES_CD_EQ = DEFAULT_STRING   '設備応答ｺｰﾄﾞ
                            objTLIF_TRNS_RECV.FUPDATE_DT = Now              '更新日時
                            objTLIF_TRNS_RECV.UPDATE_TLIF_TRNS_RECV()       '更新

                        End If


                    Else
                        '(見つからなかった場合)

                        '========================
                        'ﾒｯｾｰｼﾞ出力
                        '========================
                        Select Case objTLIF_TRNS_RECV.FEQ_ID
                            Case FEQ_ID_JSYS0000 : Call AddToMsgLog(Now, FMSG_ID_J6003, "異常応答ｺｰﾄﾞ受信。", "応答ｺｰﾄﾞ(MELSEC→ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0001 : Call AddToMsgLog(Now, FMSG_ID_J6103, "異常応答ｺｰﾄﾞ受信。", "応答ｺｰﾄﾞ(SW01  →ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0002 : Call AddToMsgLog(Now, FMSG_ID_J6203, "異常応答ｺｰﾄﾞ受信。", "応答ｺｰﾄﾞ(SW02  →ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0003 : Call AddToMsgLog(Now, FMSG_ID_J6303, "異常応答ｺｰﾄﾞ受信。", "応答ｺｰﾄﾞ(SW03  →ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0004 : Call AddToMsgLog(Now, FMSG_ID_J6403, "異常応答ｺｰﾄﾞ受信。", "応答ｺｰﾄﾞ(SW04  →ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0005 : Call AddToMsgLog(Now, FMSG_ID_J6503, "異常応答ｺｰﾄﾞ受信。", "応答ｺｰﾄﾞ(SW05  →ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0006 : Call AddToMsgLog(Now, FMSG_ID_J6603, "異常応答ｺｰﾄﾞ受信。", "応答ｺｰﾄﾞ(SW04A →ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                '↓↓↓↓↓↓************************************************************************************************************
                                'JobMate:S.Ouchi 2015/06/25 CW6追加対応 ↓↓↓↓↓↓
                            Case FEQ_ID_JSYS0007 : Call AddToMsgLog(Now, FMSG_ID_J6703, "異常応答ｺｰﾄﾞ受信。", "応答ｺｰﾄﾞ(SW06 →ﾏﾃｽﾄ):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                'JobMate:S.Ouchi 2015/06/25 CW6追加対応 ↑↑↑↑↑↑
                                '↑↑↑↑↑↑************************************************************************************************************
                        End Select


                        '========================
                        '搬送制御送信IFの削除
                        '========================
                        objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV()       '削除

                    End If


                    '************************
                    '電文分解
                    '************************
                    Dim objTelegram As clsTelegram                                              '受信電文分解
                    objTelegram = Nothing
                    DenbunBunkai(objTLIF_TRNS_RECV, objTelegram)


                    '************************
                    '搬送制御受信処理実行
                    '************************
                    Dim blnRetry As Boolean = False     'ﾘﾄﾗｲﾌﾗｸﾞ
                    Call Command_Junction(objTLIF_TRNS_RECV _
                                        , objTelegram _
                                        , blnRetry _
                                        )


                    '************************
                    '搬送制御受信IFの削除
                    '************************
                    If blnRetry = False Then
                        '(ﾘﾄﾗｲしない場合)
                        objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV()           '削除
                    Else
                        '(ﾘﾄﾗｲする場合)
                        ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                        ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    End If


                Catch ex As RollBackException
                    ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                    ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV()           '削除
                Catch ex As UserException
                    Call ComUser(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                    ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SERR_SVR     '進捗状態(異常)
                    objTLIF_TRNS_RECV.FUPDATE_DT = Now                  '更新日時
                    objTLIF_TRNS_RECV.UPDATE_TLIF_TRNS_RECV()           '更新
                Catch ex As Exception
                    Call ComError(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                    ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SERR_SVR     '進捗状態(異常)
                    objTLIF_TRNS_RECV.FUPDATE_DT = Now                  '更新日時
                    objTLIF_TRNS_RECV.UPDATE_TLIF_TRNS_RECV()           '更新
                Finally
                    ObjDb.Commit()      'ｺﾐｯﾄ
                    ObjDb.BeginTrans()  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                End Try
            Next


            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S020151)                           '起動


            ''************************
            ''正常完了
            ''************************
            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, KOTEI_TRNS_END_NORMAL)
            Return RetCode.OK

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        End Try
    End Function
#End Region
#Region "  搬送制御受信IF読込み                                                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 搬送制御受信IF読込み
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">登録No(配列)</param>
    ''' <returns>OK/NotFound</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Get_TrnsRecv(ByRef objTLIF_TRNS_RECV() As TBL_TLIF_TRNS_RECV) As RetCode
        Try
            Dim strSQL As String                'SQL文
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim ii As Integer                   'ｶｳﾝﾀ


            '************************
            '抽出SQL作成
            '************************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    FENTRY_NO "                 '登録No
            strSQL &= vbCrLf & "   ,FEQ_ID "                    '設備ID
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TLIF_TRNS_RECV "            '搬送制御受信IF
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FPROGRESS = '" & FPROGRESS_SEND & "'"    '進捗状態(未実施)
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    FENTRY_NO"                  '登録No
            strSQL &= vbCrLf


            '************************
            '抽出
            '************************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TLIF_TRNS_RECV"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For ii = 0 To objDataSet.Tables(strDataSetName).Rows.Count - 1
                    objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                    ReDim Preserve objTLIF_TRNS_RECV(ii)
                    objTLIF_TRNS_RECV(ii) = New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog)
                    objTLIF_TRNS_RECV(ii).FENTRY_NO = TO_STRING(objRow("FENTRY_NO"))    '登録No
                    objTLIF_TRNS_RECV(ii).FEQ_ID = TO_STRING(objRow("FEQ_ID"))          '設備ID
                    objTLIF_TRNS_RECV(ii).GET_TLIF_TRNS_RECV(False)                     '特定
                Next
                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


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
    '↓↓↓ｼｽﾃﾑ固有

#Region "  電文分割処理                                                                         "
    ''' <summary>
    ''' 電文分割処理
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">電文分割ﾌｫｰﾏｯﾄ</param>
    ''' <param name="objTelegram">受信電文ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    Private Sub DenbunBunkai(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                         , ByRef objTelegram As clsTelegram)
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


        Catch ex As ContinueForException
            Throw New ContinueForException()
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ｺﾏﾝﾄﾞ分岐処理                                                                        "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｺﾏﾝﾄﾞ分岐処理
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">電文分割ﾌｫｰﾏｯﾄ</param>
    ''' <param name="objTelegram">受信電文ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="blnRetry">ﾘﾄﾗｲﾌﾗｸﾞ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub Command_Junction(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                               , ByRef objTelegram As clsTelegram _
                               , ByRef blnRetry As Boolean _
                               )
        'Private Sub Command_Junction(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
        '                           , ByRef objTelegram As clsTelegram)


        Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            Select Case objTLIF_TRNS_RECV.FCOMMAND_ID
                Case FCOMMAND_ID_SIN_END
                    '(入庫完了)
                    AddToLog("■受付:入庫完了", "", LogType.INFO)

                    Dim objCommand As New SVR_010102(Owner, ObjDb, ObjDbLog)
                    objCommand.FPALLET_ID = objTLIF_TRNS_RECV.FPALLET_ID
                    objCommand.FINOUT_STS = FINOUT_STS_SIN_END
                    Call objCommand.ExecCmdFunction()
                    intRet = RetCode.OK


                Case FCOMMAND_ID_SOUT_END
                    '(出庫完了)
                    AddToLog("■受付:出庫完了", "", LogType.INFO)

                    Dim objCommand As New SVR_010202(Owner, ObjDb, ObjDbLog)
                    objCommand.FPALLET_ID = objTLIF_TRNS_RECV.FPALLET_ID
                    objCommand.FINOUT_STS = FINOUT_STS_SOUT_END
                    Call objCommand.ExecCmdFunction()
                    intRet = RetCode.OK


                Case FCOMMAND_ID_SCUT_EQ
                    '(設備切離し要求)

                    Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     '設備状況ｸﾗｽ
                    objTSTS_EQ_CTRL.FEQ_ID = objTLIF_TRNS_RECV.FDENBUN_PRM1                 '設備ID
                    objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(False)                                 '取得
                    objTSTS_EQ_CTRL.FEQ_CUT_STS = FEQ_CUT_STS_SON                           '切離状態
                    objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()                                   '更新


                Case FCOMMAND_ID_SEVENT
                    '(ｲﾍﾞﾝﾄ通知)

                    AddToLog("■受付:ｲﾍﾞﾝﾄ通知受付", "", LogType.INFO)
                    intRet = FCOMMAND_ID_EVENTProcess(objTLIF_TRNS_RECV)


                Case FCOMMAND_ID_SADD_MSG
                    AddToMsgLog(Now, objTLIF_TRNS_RECV.FDENBUN_PRM1, _
                                     objTLIF_TRNS_RECV.FDENBUN_PRM2, _
                                     objTLIF_TRNS_RECV.FDENBUN_PRM3, _
                                     objTLIF_TRNS_RECV.FDENBUN_PRM4, _
                                     objTLIF_TRNS_RECV.FDENBUN_PRM5, _
                                     objTLIF_TRNS_RECV.FDENBUN_PRM6)


                Case FCOMMAND_ID_SSQL
                    '(SQL実行)


                    'Case FCOMMAND_ID_JMCV_000
                    '    '(ﾃﾞｰﾀﾘﾝｸ確立_MCV)

                    '    intRet = MCVTelRecv000(objTLIF_TRNS_RECV)

                    'Case FCOMMAND_ID_JMCV_999
                    '    '(ﾃﾞｰﾀﾘﾝｸ切断_MCV)

                    '    intRet = MCVTelRecv999(objTLIF_TRNS_RECV)

                Case FCOMMAND_ID_SOT
                    '(その他)

                    Select Case objTLIF_TRNS_RECV.FEQ_ID
                        Case FEQ_ID_JSYS0101
                            '(SHIPからの電文の場合)

                            Select Case objTLIF_TRNS_RECV.FTEXT_ID
                                Case FTEXT_ID_JR_CARD                       '読込_ｶｰﾄﾞﾘｰﾀﾞ読込
                                    intRet = CARTelRecvJR_CARD_SendRetTel(objTLIF_TRNS_RECV)
                                    intRet = CARTelRecvJR_CARD(objTLIF_TRNS_RECV)
                                Case Else
                                    '(ｺﾏﾝﾄﾞIDが不明な場合)
                                    strMsg = ERRMSG_NOTFOUND_COMMAND_ID & "[設備ID:" & objTLIF_TRNS_RECV.FEQ_ID & "][ｺﾏﾝﾄﾞID:" & TO_STRING(objTLIF_TRNS_RECV.FCOMMAND_ID) & "][ﾃｷｽﾄID:" & objTLIF_TRNS_RECV.FTEXT_ID & "]"
                                    AddToMsgLog(Now, FMSG_ID_S9001, strMsg)
                                    intRet = RetCode.NG

                            End Select

                        Case Else
                            '(設備IDが不明な場合)
                            strMsg = ERRMSG_NOTFOUND_COMMAND_ID & "[設備ID:" & objTLIF_TRNS_RECV.FEQ_ID & "][ｺﾏﾝﾄﾞID:" & TO_STRING(objTLIF_TRNS_RECV.FCOMMAND_ID) & "]"
                            AddToMsgLog(Now, FMSG_ID_S9001, strMsg)
                            intRet = RetCode.NG
                    End Select

                Case Else
                    '(ｺﾏﾝﾄﾞIDが不明な場合)
                    strMsg = ERRMSG_NOTFOUND_COMMAND_ID & "[設備ID:" & objTLIF_TRNS_RECV.FEQ_ID & "][ｺﾏﾝﾄﾞID:" & TO_STRING(objTLIF_TRNS_RECV.FCOMMAND_ID) & "]"
                    AddToMsgLog(Now, FMSG_ID_S9001, strMsg)
                    intRet = RetCode.NG
            End Select


        Catch ex As ContinueForException
            Throw New ContinueForException()
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region

#Region "  ｲﾍﾞﾝﾄ通知処理                                                                        "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｲﾍﾞﾝﾄ通知処理
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">搬送制御受信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function FCOMMAND_ID_EVENTProcess(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV) As RetCode
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ


            '************************
            '設備状況の特定
            '************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID = objTLIF_TRNS_RECV.FDENBUN_PRM1
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()


            '************************
            '初期処理
            '************************
            If Not ( _
                       objTSTS_EQ_CTRL.XEVENT_LOG_KUBUN = XEVENT_LOG_KUBUN_TRK_RTN01 _
                    Or objTSTS_EQ_CTRL.XEVENT_LOG_KUBUN = XEVENT_LOG_KUBUN_TRK_RTN02 _
                    ) Then
                '(RTNﾄﾗｯｷﾝｸﾞ関係じゃない場合)
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART & "ｲﾍﾞﾝﾄ通知受信  [ﾊﾟﾗﾒｰﾀ1:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "]" _
                                                                                                                  & "[ﾊﾟﾗﾒｰﾀ2:" & objTLIF_TRNS_RECV.FDENBUN_PRM2 & "]" _
                                                                                                                  & "[ﾊﾟﾗﾒｰﾀ3:" & objTLIF_TRNS_RECV.FDENBUN_PRM3 & "]" _
                                                                                                                  )
            End If


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/08/16 特殊処理


            '**************************************
            '出庫搬送完了判定
            '**************************************
            Call HanteiOutTrnsEndLoader(objTSTS_EQ_CTRL, objTLIF_TRNS_RECV)


            '↑↑↑↑↑↑************************************************************************************************************


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:YAMAMOTO 2017/08/11 1F包材出庫対応 ↓↓↓↓↓↓
            'D43,D93入庫要求OFF検知でﾄﾗｯｷﾝｸﾞ解放
            '****************************************************************************
            Call UpdateXSTS_ITF(objTLIF_TRNS_RECV, objTSTS_EQ_CTRL)
            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '設備状態の更新
            '************************
            If Right(objTLIF_TRNS_RECV.FDENBUN_PRM1, 3) = "_IN" Then
                '↓↓↓↓↓↓************************************************************************************************************
                '2017/07/29 特殊処理　infomate 入出庫ﾓｰﾄﾞ編集
                objTSTS_EQ_CTRL.FEQ_STS = IIf(objTLIF_TRNS_RECV.FDENBUN_PRM2 = "0", "1", "0")       '設備状態
                objTSTS_EQ_CTRL.FUPDATE_DT = Now                                '更新日時
                objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()                           '更新
                '↑↑↑↑↑↑************************************************************************************************************
            Else
                objTSTS_EQ_CTRL.FEQ_STS = objTLIF_TRNS_RECV.FDENBUN_PRM2        '設備状態
                'objTSTS_EQ_CTRL.FEQ_STOP_CD = objTLIF_TRNS_RECV.FDENBUN_PRM3    '停止ｺｰﾄﾞ
                objTSTS_EQ_CTRL.FUPDATE_DT = Now                                '更新日時
                objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()                           '更新
            End If




            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/03/22 特殊処理


            '**************************************
            '入庫完了判定
            '**************************************
            Call HanteiInEnd(objTSTS_EQ_CTRL)


            '**************************************
            '出庫完了判定
            '**************************************
            Call HanteiOutEnd(objTSTS_EQ_CTRL)


            '**************************************
            '出庫搬送完了判定
            '**************************************
            Call HanteiOutTrnsEnd(objTSTS_EQ_CTRL)


            '**************************************
            '積込完了判定
            '**************************************
            Call HanteiTumiEnd(objTSTS_EQ_CTRL)


            '**************************************
            '入庫搬送元ﾄﾗｯｷﾝｸﾞの解放
            '**************************************
            Call HanteiInTrnsKaihou(objTSTS_EQ_CTRL)


            '**************************************
            'ｴﾗｰｺｰﾄﾞを設備異常ﾛｸﾞに登録
            '**************************************
            Call InsertTLOG_EQ_ERROR_ErrorCode(objTLIF_TRNS_RECV, objTSTS_EQ_CTRL)


            '****************************************************************************
            'D45出庫要求数を包材出庫設定状態(D45)ﾃｰﾌﾞﾙに更新
            '****************************************************************************
            Call UpdateXSTS_WRAPPING_MATERIAL_D45(objTLIF_TRNS_RECV, objTSTS_EQ_CTRL)

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:YAMAMOTO 2017/04/11 1F包材出庫対応 ↓↓↓↓↓↓
            '****************************************************************************
            '1F出庫要求数を包材出庫設定状態(1F)ﾃｰﾌﾞﾙに更新
            '****************************************************************************
            Call UpdateXSTS_WRAPPING_MATERIAL_1F(objTLIF_TRNS_RECV, objTSTS_EQ_CTRL)
            'JobMate:YAMAMOTO 2017/04/111F包材出庫対応 ↑↑↑↑↑↑
            '↑↑↑↑↑↑************************************************************************************************************




            '****************************************************************************
            'ﾄﾗｯｸﾛｰﾀﾞﾓｰﾄﾞﾘｸｴｽﾄ処理、ﾄﾗｯｸﾛｰﾀﾞﾓｰﾄﾞ受信完了処理
            '****************************************************************************
            Call UpdateLoaderModeON(objTSTS_EQ_CTRL)
            Call UpdateLoaderModeOFF(objTSTS_EQ_CTRL)


            '**************************************
            '要求状態ﾘｾｯﾄ
            '**************************************
            If Mid(objTSTS_EQ_CTRL.FEQ_ID, 1, 8) = "JOTHMFF_" Then
                '(MELSECの場合)
                objTSTS_EQ_CTRL.FEQ_REQ_STS = FEQ_REQ_STS_SOFF              '要求状態
                objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()                       '更新
            End If


            '↑↑↑↑↑↑************************************************************************************************************


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2015/07/15 CW6追加対応 ↓↓↓↓↓↓
            If objTLIF_TRNS_RECV.FEQ_ID = FEQ_ID_JSYS0007 Then
                Call CW6_Status_Change(objTLIF_TRNS_RECV, objTSTS_EQ_CTRL)
            End If
            'JobMate:S.Ouchi 2015/07/15 CW6追加対応 ↑↑↑↑↑↑
            '↑↑↑↑↑↑************************************************************************************************************


            Select Case objTSTS_EQ_CTRL.FEQ_ID
                Case FEQ_ID_JOTHY05_X048501 _
                   , FEQ_ID_JOTHY05_X048502 _
                   , FEQ_ID_JOTHY05_X048503 _
                   , FEQ_ID_JOTHY05_X048504 _
                   , FEQ_ID_JOTHY05_X048505 _
                   , FEQ_ID_JOTHY05_X048506 _
                   , FEQ_ID_JOTHY05_X048507 _
                   , FEQ_ID_JOTHY05_X048508 _
                   , FEQ_ID_JOTHY05_X048509 _
                   , FEQ_ID_JOTHY05_X048510 _
                   , FEQ_ID_JOTHY05_X048511 _
                   , FEQ_ID_JOTHY05_X048512 _
                   , FEQ_ID_JOTHY05_X048513 _
                   , FEQ_ID_JOTHY05_X048514
                Case Else
                    '(まだ設備異常ﾛｸﾞを出力していない場合)


                    '************************
                    '設備停止要因ﾏｽﾀの特定
                    '************************
                    Dim intErrCount As Integer
                    Dim objTMST_EQ_ERROR_Now As New TBL_TMST_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '設備停止要因ﾏｽﾀ
                    objTMST_EQ_ERROR_Now.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '設備ID
                    objTMST_EQ_ERROR_Now.FEQ_STS = objTLIF_TRNS_RECV.FDENBUN_PRM2                   '設備状態
                    intErrCount = objTMST_EQ_ERROR_Now.GET_TMST_EQ_ERROR_COUNT()                    '特定
                    If 1 <= intErrCount Then
                        '(異常 の場合)

                        '====================
                        '設備異常ﾛｸﾞ登録
                        '====================
                        Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '設備異常ﾛｸﾞ
                        objTLOG_EQ_ERROR.FHASSEI_DT = objTLIF_TRNS_RECV.FENTRY_DT                   '発生日時
                        objTLOG_EQ_ERROR.FHUKKI_DT = DEFAULT_DATE                                   '復旧日時
                        objTLOG_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '設備ID
                        objTLOG_EQ_ERROR.FEQ_STS = objTLIF_TRNS_RECV.FDENBUN_PRM2                   '設備状態
                        objTLOG_EQ_ERROR.FEQ_STOP_CD = objTLIF_TRNS_RECV.FDENBUN_PRM3               '停止ｺｰﾄﾞ
                        objTLOG_EQ_ERROR.ADD_TLOG_EQ_ERROR_SEQ()                                    '登録

                        '====================
                        'ﾒｯｾｰｼﾞ履歴書き込み
                        '====================
                        Call AddToMsgLog(Now, FMSG_ID_S0104, "[設備名称:" & objTSTS_EQ_CTRL.FEQ_NAME & "]")

                    Else
                        '(正常 の場合)

                        '====================
                        '設備異常ﾛｸﾞ更新
                        '====================
                        Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '設備異常ﾛｸﾞ
                        objTLOG_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '設備ID
                        objTLOG_EQ_ERROR.FHUKKI_DT = objTLIF_TRNS_RECV.FENTRY_DT                    '復旧日時
                        objTLOG_EQ_ERROR.UPDATE_TLOG_EQ_ERROR_FEQ_ID()                              '登録

                    End If


            End Select


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/08/18 特殊処理


            '**************************************
            'ﾛｰｶﾙ異常ﾗﾝﾌﾟ(JOTHMFF_D000104_12)更新
            '**************************************
            Call UpdateLocalErrLamp(objTSTS_EQ_CTRL)


            '↑↑↑↑↑↑************************************************************************************************************


            If Not ( _
                       objTSTS_EQ_CTRL.XEVENT_LOG_KUBUN = XEVENT_LOG_KUBUN_TRK_RTN01 _
                    Or objTSTS_EQ_CTRL.XEVENT_LOG_KUBUN = XEVENT_LOG_KUBUN_TRK_RTN02 _
                    ) Then
                '(RTNﾄﾗｯｷﾝｸﾞ関係じゃない場合)


                '************************
                '次処理起動
                '************************
                If Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 1) = "Y" Then
                    '(安川PLCの場合)
                    objTPRG_TIMER.KIDOU_ON(FSYORI_ID_J310101)       '起動
                End If


                '************************
                '正常完了
                '************************
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL)


            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
            'Return RetCode.NG
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
            'Return RetCode.NG
        End Try
    End Function
#End Region
#Region "  汎用定周期処理(ﾓｰﾄﾞ切り替えﾀｲﾑｱｳﾄ処理)                                               "
    '''**********************************************************************************************
    ''' <summary>
    ''' 汎用定周期処理(ﾓｰﾄﾞ切り替えﾀｲﾑｱｳﾄ処理)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function ProcessTimer01() As RetCode
        Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '************************
            '設備状況の特定
            '************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            objTSTS_EQ_CTRL.FEQ_KUBUN = FEQ_KUBUN_SMOD                          '設備区分
            objTSTS_EQ_CTRL.FEQ_REQ_STS = FEQ_REQ_STS_SMODE_ON                  '要求状態
            intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL_ANY()                     '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                Return RetCode.OK
            End If


            For ii As Integer = LBound(objTSTS_EQ_CTRL.ARYME) To UBound(objTSTS_EQ_CTRL.ARYME)
                '(ﾙｰﾌﾟ:ﾓｰﾄﾞ切替中のﾚｺｰﾄﾞ数)


                '************************
                'ﾀｲﾑｱｳﾄﾁｪｯｸ
                '************************
                Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)
                If CDate(objTSTS_EQ_CTRL.ARYME(ii).FUPDATE_DT).AddSeconds(objTPRG_SYS_HEN.SS000000_007) <= Now Then
                    '(ﾀｲﾑｱｳﾄの場合)

                    '************************
                    '設備状況の更新
                    '************************
                    objTSTS_EQ_CTRL.ARYME(ii).FEQ_REQ_STS = FEQ_REQ_STS_SOFF   '設備状態
                    objTSTS_EQ_CTRL.ARYME(ii).FUPDATE_DT = Now                '更新日時
                    objTSTS_EQ_CTRL.ARYME(ii).UPDATE_TSTS_EQ_CTRL()           '更新

                    '************************
                    'ﾒｯｾｰｼﾞﾛｸﾞ追加
                    '************************
                    strMsg = "ﾓｰﾄﾞ切り替えﾀｲﾑｱｳﾄ[ｽﾃｰｼｮﾝ:" & objTSTS_EQ_CTRL.ARYME(ii).FEQ_NAME & "]"
                    Select Case objTSTS_EQ_CTRL.ARYME(ii).FEQ_ID
                        'Case FEQ_ID_JMOD0165, FEQ_ID_JMOD0170, FEQ_ID_JMOD0184, FEQ_ID_JMOD0186 : Call AddToMsgLog(Now, FMSG_ID_J6303, strMsg)
                        Case Else : Call AddToMsgLog(Now, FMSG_ID_J6303, strMsg)
                    End Select

                End If

            Next


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

    'ｸﾚｰﾝ状態更新
#Region "  ｸﾚｰﾝ状態更新処理                                                                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｸﾚｰﾝ状態更新処理
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">搬送制御受信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <param name="objTPRG_TRK_BUF_RELAY">移動中ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ</param>
    ''' <param name="strFCOMP_KUBUN">異常ｺｰﾄﾞ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateXSTS_CRANEProcess(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                                      , ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                                      , ByVal strFCOMP_KUBUN As String _
                                      )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            If IsNull(objTPRG_TRK_BUF_RELAY) Then Exit Sub


            '************************
            '設備状況       取得
            '************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL, objTPRG_TRK_BUF_RELAY.FEQ_ID)


            '************************
            '色々ﾁｪｯｸ
            '************************
            Select Case strFCOMP_KUBUN
                Case FCOMP_KUBUN_SNIJUU
                    Call AddToMsgLog(Now, FMSG_ID_S0103, objTSTS_EQ_CTRL.FEQ_NAME)
                Case FCOMP_KUBUN_SKARA
                    Call AddToMsgLog(Now, FMSG_ID_S0105, objTSTS_EQ_CTRL.FEQ_NAME)
                    'Case Else
                    '    Exit Sub
            End Select


            '************************
            'ｸﾚｰﾝ状態更新
            '************************
            '取得
            Dim objTSTS_CRANE As New TBL_TSTS_CRANE(Owner, ObjDb, ObjDbLog)
            objTSTS_CRANE.FEQ_ID = objTPRG_TRK_BUF_RELAY.FEQ_ID '設備ID
            objTSTS_CRANE.GET_TSTS_CRANE()                      '特定
            '更新
            objTSTS_CRANE.FCOMP_KUBUN = TO_INTEGER_NULLABLE(strFCOMP_KUBUN)      '完了区分
            objTSTS_CRANE.FDENBUN = objTLIF_TRNS_RECV.FDENBUN       '通信電文
            objTSTS_CRANE.FUPDATE_DT = Now                          '更新日時
            objTSTS_CRANE.UPDATE_TSTS_CRANE()                       '更新


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region


    '設備状況、設備異常ﾛｸﾞの更新
#Region "  設備状況、設備異常ﾛｸﾞの更新                                                          "
    '''**********************************************************************************************
    ''' <summary>
    ''' 設備状況、設備異常ﾛｸﾞの更新
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">搬送制御受信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <param name="strFEQ_ID">設備ID</param>
    ''' <param name="strFEQ_STS">設備状態</param>
    ''' <param name="strFEQ_STOP_CD">停止要因ｺｰﾄﾞ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateTSTS_EQ_CTRL_TLOG_EQ_ERRORProcess(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                                                      , ByVal strFEQ_ID As String _
                                                      , ByVal strFEQ_STS As String _
                                                      , ByVal strFEQ_STOP_CD As String _
                                                        )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '************************
            '設備状況の特定
            '************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID      '設備ID
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()      '取得
            If TO_STRING(objTSTS_EQ_CTRL.FEQ_STS) = TO_STRING(strFEQ_STS) And TO_STRING(objTSTS_EQ_CTRL.FEQ_STOP_CD) = TO_STRING(strFEQ_STOP_CD) Then
                '(変化がない場合)
                Exit Sub
            End If


            '************************
            '設備状態の更新
            '************************
            objTSTS_EQ_CTRL.FEQ_STS = strFEQ_STS            '設備状態
            objTSTS_EQ_CTRL.FEQ_STOP_CD = strFEQ_STOP_CD    '停止要因ｺｰﾄﾞ
            objTSTS_EQ_CTRL.FUPDATE_DT = Now                '更新日時
            objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()           '更新


            '************************
            '設備停止要因ﾏｽﾀの特定
            '************************
            Dim intErrCount As Integer
            Dim objTMST_EQ_STOP As New TBL_TMST_EQ_STOP(Owner, ObjDb, ObjDbLog)       '設備停止要因ﾏｽﾀ
            objTMST_EQ_STOP.FEQ_STOP_KUBUN = objTSTS_EQ_CTRL.FEQ_STOP_KUBUN           '設備停止要因区分
            objTMST_EQ_STOP.FEQ_STS = strFEQ_STS                                      '設備状態
            intErrCount = objTMST_EQ_STOP.GET_TMST_EQ_STOP_COUNT()                    '特定
            If 1 <= intErrCount Then
                '(異常 の場合)

                '====================
                '設備異常ﾛｸﾞ登録
                '====================
                Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '設備異常ﾛｸﾞ
                objTLOG_EQ_ERROR.FHASSEI_DT = objTLIF_TRNS_RECV.FENTRY_DT                   '発生日時
                objTLOG_EQ_ERROR.FHUKKI_DT = DEFAULT_DATE                                   '復旧日時
                objTLOG_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '設備ID
                objTLOG_EQ_ERROR.FEQ_STS = objTSTS_EQ_CTRL.FEQ_STS                          '設備状態
                objTLOG_EQ_ERROR.FEQ_STOP_CD = objTSTS_EQ_CTRL.FEQ_STOP_CD                  '停止要因ｺｰﾄﾞ
                objTLOG_EQ_ERROR.ADD_TLOG_EQ_ERROR_SEQ()                                    '登録

                '====================
                'ﾒｯｾｰｼﾞ履歴書き込み
                '====================
                Call AddToMsgLog(Now, FMSG_ID_S0104, "[設備名称:" & objTSTS_EQ_CTRL.FEQ_NAME & "]")

            Else
                '(正常 の場合)

                '====================
                '設備異常ﾛｸﾞ更新
                '====================
                Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '設備異常ﾛｸﾞ
                objTLOG_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '設備ID
                objTLOG_EQ_ERROR.FHUKKI_DT = objTLIF_TRNS_RECV.FENTRY_DT                    '復旧日時
                objTLOG_EQ_ERROR.UPDATE_TLOG_EQ_ERROR_FEQ_ID()                              '登録

            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region


    'PLC系
#Region "  入庫完了判定                                                                         "
    '''**********************************************************************************************
    ''' <summary>
    ''' 入庫完了判定
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub HanteiInEnd(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '**************************************
            'ﾁｪｯｸ
            '**************************************
            If objTSTS_EQ_CTRL.FEQ_STS = FLAG_ON Then Exit Sub


            '**************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ        取得
            '**************************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.XEQ_ID_IRI_YOUKYU = objTSTS_EQ_CTRL.FEQ_ID      '入棚入庫要求設備ID
            intRet = objTMST_TRK.GET_TMST_TRK(False)                    '取得
            If intRet = RetCode.OK Then
                '(搬送完了 or 入庫完了 の場合)


                '**************************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ           取得
                '**************************************
                Dim objTPRG_TRK_BUF_RELAY01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                Select Case objTMST_TRK.XLS_NO
                    Case XLS_NO_1F : objTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3101    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    Case XLS_NO_2F : objTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3102    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                End Select
                objTPRG_TRK_BUF_RELAY01.FTR_FM = objTMST_TRK.FTRK_BUF_NO        '搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                intRet = objTPRG_TRK_BUF_RELAY01.GET_TPRG_TRK_BUF_FIFO()        '取得
                If intRet = RetCode.OK Then
                    '(見つかった場合)


                    '**************************************
                    '搬送指示QUE        取得
                    '**************************************
                    Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                    objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID       'ﾊﾟﾚｯﾄID
                    objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                                  '取得


                    '**************************************
                    '入庫完了(1ﾊﾟﾚｯﾄ目)
                    '**************************************
                    Dim objSVR_010102_01 As New SVR_010102(Owner, ObjDb, ObjDbLog)
                    objSVR_010102_01.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID   'ﾊﾟﾚｯﾄID
                    objSVR_010102_01.FINOUT_STS = FINOUT_STS_SIN_END                   'IN/OUT
                    Call objSVR_010102_01.ExecCmdFunction()


                    '**************************************
                    '入庫完了(2ﾊﾟﾚｯﾄ目)
                    '**************************************
                    If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                        Dim objSVR_010102_02 As New SVR_010102(Owner, ObjDb, ObjDbLog)
                        objSVR_010102_02.FPALLET_ID = objTPLN_CARRY_QUE.XPALLET_ID_AITE    'ﾊﾟﾚｯﾄID
                        objSVR_010102_02.FINOUT_STS = FINOUT_STS_SIN_END                   'IN/OUT
                        Call objSVR_010102_02.ExecCmdFunction()
                    End If


                End If


            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  入庫完了判定_PLCﾄﾗｯｷﾝｸﾞもﾁｪｯｸするﾊﾞｰｼﾞｮﾝ(何故か、2013/09/22に急遽対応しなくなってしまった。)         "
    ''''**********************************************************************************************
    '''' <summary>
    '''' 入庫完了判定
    '''' </summary>
    '''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ</param>
    '''' <remarks></remarks>
    ''''**********************************************************************************************
    'Private Sub HanteiInEnd(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
    '    Dim intRet As RetCode                   '戻り値
    '    'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
    '    Try


    '        ''**************************************
    '        ''ﾁｪｯｸ
    '        ''**************************************
    '        'If objTSTS_EQ_CTRL.FEQ_STS = FLAG_ON Then Exit Sub


    '        '**************************************
    '        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ        取得
    '        '**************************************
    '        Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
    '        objTMST_TRK.XEQ_ID_IRI_YOUKYU = objTSTS_EQ_CTRL.FEQ_ID      '入棚入庫要求設備ID
    '        intRet = objTMST_TRK.GET_TMST_TRK(False)                    '取得
    '        If intRet <> RetCode.OK Then
    '            '(見つからない場合)
    '            objTMST_TRK.CLEAR_PROPERTY()
    '            objTMST_TRK.WHERE = "   AND ("                                                                          'PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ01
    '            objTMST_TRK.WHERE &= "           INSTR( XADRS_PLCTRK05, '" & objTSTS_EQ_CTRL.FEQ_ID & "' ) > 0"         'PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ01
    '            objTMST_TRK.WHERE &= "       OR  INSTR( XADRS_PLCTRK04, '" & objTSTS_EQ_CTRL.FEQ_ID & "' ) > 0"         'PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ01
    '            objTMST_TRK.WHERE &= "       ) "                                                                        'PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ01
    '            intRet = objTMST_TRK.GET_TMST_TRK(False)                    '取得
    '        End If
    '        If intRet = RetCode.OK Then
    '            '(搬送完了 or 入庫完了 の場合)


    '            '**************************************
    '            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(1PL目)        取得
    '            '**************************************
    '            Dim objTPRG_TRK_BUF_RELAY01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '            Select Case objTMST_TRK.XLS_NO
    '                Case XLS_NO_1F : objTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3101    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '                Case XLS_NO_2F : objTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3102    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '            End Select
    '            objTPRG_TRK_BUF_RELAY01.FTR_FM = objTMST_TRK.FTRK_BUF_NO        '搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '            intRet = objTPRG_TRK_BUF_RELAY01.GET_TPRG_TRK_BUF_FIFO()        '取得
    '            If intRet = RetCode.OK Then
    '                '(見つかった場合)


    '                '**************************************
    '                '搬送指示QUE        取得
    '                '**************************************
    '                Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
    '                objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID       'ﾊﾟﾚｯﾄID
    '                objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                                  '取得


    '                '**************************************
    '                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(1PL目倉庫予約)    取得
    '                '**************************************
    '                Dim objTPRG_TRK_BUF_ASRS01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '                objTPRG_TRK_BUF_ASRS01.FTRK_BUF_NO = FTRK_BUF_NO_J9000                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '                objTPRG_TRK_BUF_ASRS01.FRSV_PALLET = objTPRG_TRK_BUF_RELAY01.FPALLET_ID     '仮引当ﾊﾟﾚｯﾄID
    '                objTPRG_TRK_BUF_ASRS01.GET_TPRG_TRK_BUF()                                   '取得


    '                '**************************************
    '                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(2PL目)        取得
    '                '**************************************
    '                Dim objTPRG_TRK_BUF_ASRS02 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '                If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
    '                    objTPRG_TRK_BUF_ASRS02.FTRK_BUF_NO = FTRK_BUF_NO_J9000                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '                    objTPRG_TRK_BUF_ASRS02.FRSV_PALLET = objTPLN_CARRY_QUE.XPALLET_ID_AITE      '仮引当ﾊﾟﾚｯﾄID
    '                    objTPRG_TRK_BUF_ASRS02.GET_TPRG_TRK_BUF()                                   '取得
    '                End If


    '                '****************************************************************************
    '                'PLCﾄﾗｯｷﾝｸﾞから無くなったかﾁｪｯｸ
    '                '****************************************************************************
    '                '==============================================
    '                '設備状況(入庫指示ｱﾄﾞﾚｽ)    取得
    '                '設備状況(PLCﾄﾗｯｷﾝｸﾞ01)     取得
    '                '設備状況(PLCﾄﾗｯｷﾝｸﾞ02)     取得
    '                '==============================================
    '                Dim strFEQ_ID_XADRS_IN() As String = Split(objTMST_TRK.XADRS_IN, ",")
    '                Dim strFEQ_ID_PLCTRK05() As String = Split(objTMST_TRK.XADRS_PLCTRK05, ",")
    '                Dim strFEQ_ID_PLCTRK04() As String = Split(objTMST_TRK.XADRS_PLCTRK04, ",")
    '                Dim objTSTS_EQ_CTRL_XADRS_IN(UBound(strFEQ_ID_XADRS_IN)) As TBL_TSTS_EQ_CTRL
    '                Dim objTSTS_EQ_CTRL_PLCTRK05(UBound(strFEQ_ID_PLCTRK05)) As TBL_TSTS_EQ_CTRL
    '                Dim objTSTS_EQ_CTRL_PLCTRK04(UBound(strFEQ_ID_PLCTRK04)) As TBL_TSTS_EQ_CTRL
    '                Dim strFEQ_STS_XADRS_IN(UBound(strFEQ_ID_XADRS_IN)) As String       '設備状態
    '                Dim strFEQ_STS_PLCTRK05(UBound(strFEQ_ID_PLCTRK05)) As String       '設備状態
    '                Dim strFEQ_STS_PLCTRK04(UBound(strFEQ_ID_PLCTRK04)) As String       '設備状態
    '                For ii As Integer = 0 To UBound(strFEQ_ID_XADRS_IN)
    '                    '(ﾙｰﾌﾟ:PLCﾄﾗｯｷﾝｸﾞ数)
    '                    objTSTS_EQ_CTRL_XADRS_IN(ii) = New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
    '                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_XADRS_IN(ii), strFEQ_ID_XADRS_IN(ii))
    '                    strFEQ_STS_XADRS_IN(ii) = objTSTS_EQ_CTRL_XADRS_IN(ii).FEQ_STS
    '                Next
    '                For ii As Integer = 0 To UBound(strFEQ_ID_PLCTRK05)
    '                    '(ﾙｰﾌﾟ:PLCﾄﾗｯｷﾝｸﾞ数)
    '                    objTSTS_EQ_CTRL_PLCTRK05(ii) = New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
    '                    objTSTS_EQ_CTRL_PLCTRK04(ii) = New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
    '                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_PLCTRK05(ii), strFEQ_ID_PLCTRK05(ii))
    '                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_PLCTRK04(ii), strFEQ_ID_PLCTRK04(ii))
    '                    strFEQ_STS_PLCTRK05(ii) = objTSTS_EQ_CTRL_PLCTRK05(ii).FEQ_STS
    '                    strFEQ_STS_PLCTRK04(ii) = objTSTS_EQ_CTRL_PLCTRK04(ii).FEQ_STS
    '                Next

    '                '==============================================
    '                '設備状況(入庫指示ｱﾄﾞﾚｽ)    分解
    '                '設備状況(PLCﾄﾗｯｷﾝｸﾞ01)     分解
    '                '設備状況(PLCﾄﾗｯｷﾝｸﾞ02)     分解
    '                '==============================================
    '                Dim intAryBunkai00() As Integer = Nothing     '分解ﾃﾞｰﾀ
    '                Dim intAryBunkai01() As Integer = Nothing     '分解ﾃﾞｰﾀ
    '                Dim intAryBunkai02() As Integer = Nothing     '分解ﾃﾞｰﾀ
    '                Call GetHansouSiziData(strFEQ_STS_XADRS_IN, intAryBunkai00)
    '                Call GetPLCRTNData(strFEQ_STS_PLCTRK05, intAryBunkai01)
    '                Call GetPLCRTNData(strFEQ_STS_PLCTRK04, intAryBunkai02)

    '                '==============================================
    '                '設備状況(入庫指示ｱﾄﾞﾚｽ)    ﾁｪｯｸ
    '                '==============================================
    '                Dim blnTrkFound As Boolean = False
    '                If objTPRG_TRK_BUF_ASRS01.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai00(HansouSiziArray.Retu_01), intAryBunkai00(HansouSiziArray.Gouki_01), False) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_REN = intAryBunkai00(HansouSiziArray.Ren_01) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_DAN = intAryBunkai00(HansouSiziArray.Dan_01) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_EDA = intAryBunkai00(HansouSiziArray.DoubleReach_01) _
    '                   Then
    '                    '(一致するﾄﾗｯｷﾝｸﾞが見つかった場合)
    '                    blnTrkFound = True
    '                End If
    '                If objTPRG_TRK_BUF_ASRS01.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai00(HansouSiziArray.Retu_02), intAryBunkai00(HansouSiziArray.Gouki_02), False) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_REN = intAryBunkai00(HansouSiziArray.Ren_02) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_DAN = intAryBunkai00(HansouSiziArray.Dan_02) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_EDA = intAryBunkai00(HansouSiziArray.DoubleReach_02) _
    '                   Then
    '                    '(一致するﾄﾗｯｷﾝｸﾞが見つかった場合)
    '                    blnTrkFound = True
    '                End If
    '                If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
    '                    '(2PL目が存在している場合)
    '                    If objTPRG_TRK_BUF_ASRS02.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai00(HansouSiziArray.Retu_01), intAryBunkai00(HansouSiziArray.Gouki_01), False) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_REN = intAryBunkai00(HansouSiziArray.Ren_01) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_DAN = intAryBunkai00(HansouSiziArray.Dan_01) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_EDA = intAryBunkai00(HansouSiziArray.DoubleReach_01) _
    '                       Then
    '                        '(一致するﾄﾗｯｷﾝｸﾞが見つかった場合)
    '                        blnTrkFound = True
    '                    End If
    '                    If objTPRG_TRK_BUF_ASRS02.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai00(HansouSiziArray.Retu_02), intAryBunkai00(HansouSiziArray.Gouki_02), False) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_REN = intAryBunkai00(HansouSiziArray.Ren_02) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_DAN = intAryBunkai00(HansouSiziArray.Dan_02) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_EDA = intAryBunkai00(HansouSiziArray.DoubleReach_02) _
    '                       Then
    '                        '(一致するﾄﾗｯｷﾝｸﾞが見つかった場合)
    '                        blnTrkFound = True
    '                    End If
    '                End If

    '                '==============================================
    '                '設備状況(PLCﾄﾗｯｷﾝｸﾞ)       ﾁｪｯｸ
    '                '==============================================
    '                If objTPRG_TRK_BUF_ASRS01.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai01(RTNSiziArray.Retu), intAryBunkai01(RTNSiziArray.Gouki), False) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_REN = intAryBunkai01(RTNSiziArray.Ren) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_DAN = intAryBunkai01(RTNSiziArray.Dan) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_EDA = intAryBunkai01(RTNSiziArray.DoubleReach) _
    '                   Then
    '                    '(一致するﾄﾗｯｷﾝｸﾞが見つかった場合)
    '                    blnTrkFound = True
    '                End If
    '                If objTPRG_TRK_BUF_ASRS01.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai02(RTNSiziArray.Retu), intAryBunkai02(RTNSiziArray.Gouki), False) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_REN = intAryBunkai02(RTNSiziArray.Ren) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_DAN = intAryBunkai02(RTNSiziArray.Dan) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_EDA = intAryBunkai02(RTNSiziArray.DoubleReach) _
    '                   Then
    '                    '(一致するﾄﾗｯｷﾝｸﾞが見つかった場合)
    '                    blnTrkFound = True
    '                End If
    '                If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
    '                    '(2PL目が存在している場合)
    '                    If objTPRG_TRK_BUF_ASRS02.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai01(RTNSiziArray.Retu), intAryBunkai01(RTNSiziArray.Gouki), False) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_REN = intAryBunkai01(RTNSiziArray.Ren) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_DAN = intAryBunkai01(RTNSiziArray.Dan) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_EDA = intAryBunkai01(RTNSiziArray.DoubleReach) _
    '                       Then
    '                        '(一致するﾄﾗｯｷﾝｸﾞが見つかった場合)
    '                        blnTrkFound = True
    '                    End If
    '                    If objTPRG_TRK_BUF_ASRS02.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai02(RTNSiziArray.Retu), intAryBunkai02(RTNSiziArray.Gouki), False) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_REN = intAryBunkai02(RTNSiziArray.Ren) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_DAN = intAryBunkai02(RTNSiziArray.Dan) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_EDA = intAryBunkai02(RTNSiziArray.DoubleReach) _
    '                       Then
    '                        '(一致するﾄﾗｯｷﾝｸﾞが見つかった場合)
    '                        blnTrkFound = True
    '                    End If
    '                End If


    '                If blnTrkFound = False Then
    '                    '(PLC内に入庫中ﾄﾗｯｷﾝｸﾞが見つからなかったら)


    '                    '**************************************
    '                    '入庫完了(1ﾊﾟﾚｯﾄ目)
    '                    '**************************************
    '                    Dim objSVR_010102_01 As New SVR_010102(Owner, ObjDb, ObjDbLog)
    '                    objSVR_010102_01.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID   'ﾊﾟﾚｯﾄID
    '                    objSVR_010102_01.FINOUT_STS = FINOUT_STS_SIN_END                   'IN/OUT
    '                    Call objSVR_010102_01.ExecCmdFunction()


    '                    '**************************************
    '                    '入庫完了(2ﾊﾟﾚｯﾄ目)
    '                    '**************************************
    '                    If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
    '                        Dim objSVR_010102_02 As New SVR_010102(Owner, ObjDb, ObjDbLog)
    '                        objSVR_010102_02.FPALLET_ID = objTPLN_CARRY_QUE.XPALLET_ID_AITE    'ﾊﾟﾚｯﾄID
    '                        objSVR_010102_02.FINOUT_STS = FINOUT_STS_SIN_END                   'IN/OUT
    '                        Call objSVR_010102_02.ExecCmdFunction()
    '                    End If


    '                End If


    '            End If


    '        End If


    '    Catch ex As UserException
    '        Call ComUser(ex, MeSyoriID)
    '        Throw New UserException(ex.Message)
    '    Catch ex As Exception
    '        Call ComError(ex, MeSyoriID)
    '        Throw New Exception(ex.Message)
    '    End Try
    'End Sub
#End Region
#Region "  出庫完了判定                                                                         "
    '''**********************************************************************************************
    ''' <summary>
    ''' 出庫完了判定
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub HanteiOutEnd(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '**************************************
            'ﾁｪｯｸ
            '**************************************
            If objTSTS_EQ_CTRL.FEQ_STS = FLAG_OFF Then Exit Sub


            '**************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ        取得
            '**************************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.XEQ_ID_OUT_BUF = objTSTS_EQ_CTRL.FEQ_ID         '出棚ﾊﾞｯﾌｧ空設備ID
            intRet = objTMST_TRK.GET_TMST_TRK(False)                    '取得
            If intRet = RetCode.OK Then
                '(出庫完了の場合)


                '**************************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ           取得
                '**************************************
                Dim objTPRG_TRK_BUF_RELAY01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                Select Case objTMST_TRK.XLS_NO
                    Case XLS_NO_1F : objTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3201    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    Case XLS_NO_2F : objTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3202    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                End Select
                objTPRG_TRK_BUF_RELAY01.FRSV_BUF_TO = objTMST_TRK.FTRK_BUF_NO   'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                intRet = objTPRG_TRK_BUF_RELAY01.GET_TPRG_TRK_BUF_FIFO()        '取得
                If intRet = RetCode.OK Then
                    '(見つかった場合)


                    '**************************************
                    '搬送指示QUE        取得
                    '**************************************
                    Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                    objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID       'ﾊﾟﾚｯﾄID
                    objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                                  '取得


                    '**************************************
                    '出庫完了(1ﾊﾟﾚｯﾄ目)
                    '**************************************
                    Dim objSVR_010202_01 As New SVR_010202(Owner, ObjDb, ObjDbLog)
                    objSVR_010202_01.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID   'ﾊﾟﾚｯﾄID
                    objSVR_010202_01.FINOUT_STS = FINOUT_STS_SOUT_END                  'IN/OUT
                    Call objSVR_010202_01.ExecCmdFunction()


                    '**************************************
                    '出庫完了(2ﾊﾟﾚｯﾄ目)
                    '**************************************
                    If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                        Dim objSVR_010202_02 As New SVR_010202(Owner, ObjDb, ObjDbLog)
                        objSVR_010202_02.FPALLET_ID = objTPLN_CARRY_QUE.XPALLET_ID_AITE    'ﾊﾟﾚｯﾄID
                        objSVR_010202_02.FINOUT_STS = FINOUT_STS_SOUT_END                  'IN/OUT
                        Call objSVR_010202_02.ExecCmdFunction()
                    End If


                End If


            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  出庫搬送完了判定                                                                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' 出庫搬送完了判定
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub HanteiOutTrnsEnd(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '**************************************
            'ﾁｪｯｸ
            '**************************************
            If objTSTS_EQ_CTRL.FEQ_STS = FLAG_OFF Then Exit Sub


            '****************************************************************************
            '****************************************************************************
            'ﾙｰﾌﾟ01
            '出庫先ST数
            '****************************************************************************
            '****************************************************************************
            '**************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ        取得
            '**************************************
            Dim objAryTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objAryTMST_TRK.XEQ_ID_OUT_END = objTSTS_EQ_CTRL.FEQ_ID      '出庫完了設備ID
            intRet = objAryTMST_TRK.GET_TMST_TRK_ANY                    '取得
            If intRet = RetCode.OK Then
                '(出庫搬送完了の場合)
                For Each objTMST_TRK As TBL_TMST_TRK In objAryTMST_TRK.ARYME
                    '(ﾙｰﾌﾟ:該当するﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ数)


                    '****************************************************************************
                    '****************************************************************************
                    'ﾙｰﾌﾟ02
                    '出庫搬送中ﾄﾗｯｷﾝｸﾞ数
                    '****************************************************************************
                    '****************************************************************************
                    '**************************************
                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(出庫搬送中)       取得
                    '**************************************
                    Dim intCountEnd As Integer = 0
                    Dim objAryTPRG_TRK_BUF_RELAY01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    Select Case objTMST_TRK.XLS_NO
                        Case XLS_NO_1F : objAryTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3401    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        Case XLS_NO_2F : objAryTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3402    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    End Select
                    objAryTPRG_TRK_BUF_RELAY01.FTR_TO = objTMST_TRK.FTRK_BUF_NO        '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    intRet = objAryTPRG_TRK_BUF_RELAY01.GET_TPRG_TRK_BUF_FIFO(True)    '取得
                    If intRet = RetCode.OK Then
                        '(見つかった場合)
                        For Each objTPRG_TRK_BUF_RELAY01 As TBL_TPRG_TRK_BUF In objAryTPRG_TRK_BUF_RELAY01.ARYME
                            '(ﾙｰﾌﾟ:搬送中のﾄﾗｯｷﾝｸﾞ数)


                            '**************************************
                            '搬送完了
                            '**************************************
                            Dim objSVR_010302_01 As New SVR_010302(Owner, ObjDb, ObjDbLog)
                            objSVR_010302_01.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID   'ﾊﾟﾚｯﾄID
                            objSVR_010302_01.FINOUT_STS = FINOUT_STS_SRELAY_END                'IN/OUT
                            Call objSVR_010302_01.ExecCmdFunction()


                            intCountEnd += 1
                        Next
                    End If


                    '**************************************
                    '到着予定数         送信
                    '到着予定数をﾘｾｯﾄ
                    '予定数ﾁｪｯｸ
                    '**************************************
                    If IsNotNull(objTMST_TRK.XADRS_YOTEI01) Then
                        '(予定数がある場合)


                        '**************************************
                        '予定数ﾁｪｯｸ
                        '**************************************
                        If IsNull(objTMST_TRK.XADRS_YOTEI02) Then
                            '(ﾄﾗｯｸﾛｰﾀﾞじゃない場合)

                            '===================================
                            '予定数取得
                            '===================================
                            Dim objTSTS_EQ_CTRL_YOTEI01 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_YOTEI01, objTMST_TRK.XADRS_YOTEI01)

                            '===================================
                            'ﾒｯｾｰｼﾞﾛｸﾞ      出力
                            '===================================
                            If intCountEnd <> TO_INTEGER(objTSTS_EQ_CTRL_YOTEI01.FEQ_STS) Then
                                Call AddToMsgLog(Now, FMSG_ID_J4002, "ﾄﾗｯｷﾝｸﾞﾃﾞｰﾀを確認して、強制完了等の操作を行って下さい。" _
                                                                   , "[出庫搬送先:" & objTMST_TRK.FBUF_NAME & "][予定数:" & objTSTS_EQ_CTRL_YOTEI01.FEQ_STS & "][出庫搬送完了数:" & intCountEnd & "]" _
                                                                   )
                            End If

                            '’↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
                            '’2017/08/26 現地修正　加算したときに古いDBの値が残るため事前にDBを更新する
                            '' ※予定数クリア時DBも更新するように変更                                      
                            '’D81-85　　2909 
                            '' D45  2037
                            '' C01-C04
                            'Dim blnReset As Boolean = False
                            'Select Case objTMST_TRK.FTRK_BUF_NO
                            '    Case 2909, 2908, 2907, 2906, 2905 '’D81-85　
                            '        blnReset = True
                            '    Case 2037   '' D45  2037
                            '        blnReset = True
                            '    Case 1171, 1172, 1173, 1174 '' C01-C04
                            '        blnReset = True
                            'End Select

                            'If blnReset Then
                            '    objTSTS_EQ_CTRL_YOTEI01.FEQ_STS = 0
                            '    objTSTS_EQ_CTRL_YOTEI01.UPDATE_TSTS_EQ_CTRL()
                            'End If
                            '’↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

                        End If



                        '**************************************
                        '到着予定数         送信
                        '到着予定数をﾘｾｯﾄ
                        '**************************************
                        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                        objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         'ｺﾏﾝﾄﾞID
                        objSVR_190001.FPALLET_ID = ""                                   'ﾊﾟﾚｯﾄID
                        objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
                        Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK.FTRK_BUF_NO _
                                                              , 0 _
                                                              , 0 _
                        )




                    End If


                    ' '' ''**************************************
                    ' '' ''ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(何かしら出庫中)   取得
                    ' '' ''**************************************
                    '' ''Dim intCountOut As Integer = 0      'まだ出庫搬送完了していないﾄﾗｯｷﾝｸﾞ数
                    '' ''Dim objAryTPRG_TRK_BUF_RELAY02 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    '' ''objAryTPRG_TRK_BUF_RELAY02.FTR_TO = objTMST_TRK.FTRK_BUF_NO        '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    '' ''intRet = objAryTPRG_TRK_BUF_RELAY02.GET_TPRG_TRK_BUF_FIFO(True)    '取得
                    '' ''If intRet = RetCode.OK Then
                    '' ''    '(見つかった場合)
                    '' ''    For Each objTPRG_TRK_BUF_RELAY02 As TBL_TPRG_TRK_BUF In objAryTPRG_TRK_BUF_RELAY02.ARYME
                    '' ''        '(ﾙｰﾌﾟ:搬送中のﾄﾗｯｷﾝｸﾞ数)


                    '' ''        '**************************************
                    '' ''        '搬送完了
                    '' ''        '**************************************
                    '' ''        Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                    '' ''        objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_RELAY02.FPALLET_ID   'ﾊﾟﾚｯﾄID
                    '' ''        intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)                '取得
                    '' ''        If intRet = RetCode.OK Then
                    '' ''            '(見つかった場合)
                    '' ''            If objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS <> FCARRYQUE_DIR_STS_JTAIKI Then
                    '' ''                '(待機状態以外の場合)
                    '' ''                intCountOut += 1
                    '' ''            End If
                    '' ''        End If


                    '' ''    Next
                    '' ''End If


                    ' '' ''**************************************
                    ' '' ''到着予定数         送信
                    ' '' ''**************************************
                    '' ''If 0 < intCountOut Then
                    '' ''    '(出庫搬送完了していないﾄﾗｯｷﾝｸﾞがあった場合)
                    '' ''    If IsNotNull(objTMST_TRK.XADRS_YOTEI01) Then
                    '' ''        '(予定数がある場合)
                    '' ''        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                    '' ''        objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         'ｺﾏﾝﾄﾞID
                    '' ''        objSVR_190001.FPALLET_ID = ""                                   'ﾊﾟﾚｯﾄID
                    '' ''        objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
                    '' ''        Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK.FTRK_BUF_NO _
                    '' ''                                              , 0 _
                    '' ''                                              , 0 _
                    '' ''                                              )
                    '' ''    End If
                    '' ''End If


                Next

            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  出庫搬送完了判定(ﾄﾗｯｸﾛｰﾀﾞ用)                                                         "
    '''**********************************************************************************************
    ''' <summary>
    ''' 出庫搬送完了判定(ﾄﾗｯｸﾛｰﾀﾞ用)
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <param name="objTLIF_TRNS_RECV">搬送制御受信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub HanteiOutTrnsEndLoader(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL _
                                     , ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                                     )
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '**************************************
            'ﾁｪｯｸ
            '**************************************
            If objTLIF_TRNS_RECV.FDENBUN_PRM2 = FLAG_OFF Then Exit Sub


            '**************************************
            '出庫搬送完了数         取得
            '**************************************
            Dim intTrnsEndLoader As Integer = TO_INTEGER(objTLIF_TRNS_RECV.FDENBUN_PRM2) - TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)
            If intTrnsEndLoader <= 0 Then Exit Sub


            '****************************************************************************
            '****************************************************************************
            'ﾙｰﾌﾟ01
            '出庫先ST数
            '****************************************************************************
            '****************************************************************************
            '**************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ        取得
            '**************************************
            Dim objAryTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objAryTMST_TRK.XADRS_PALLET01 = objTSTS_EQ_CTRL.FEQ_ID      'ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01
            intRet = objAryTMST_TRK.GET_TMST_TRK_ANY                    '取得
            If intRet <> RetCode.OK Then
                '(見つからなかった場合)
                objAryTMST_TRK.CLEAR_PROPERTY()
                objAryTMST_TRK.XADRS_PALLET02 = objTSTS_EQ_CTRL.FEQ_ID      'ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02
                intRet = objAryTMST_TRK.GET_TMST_TRK_ANY                    '取得
                If intRet <> RetCode.OK Then
                    '(見つからなかった場合)
                    Exit Sub
                End If
            End If
            'If objAryTMST_TRK.ARYME.Length <= 1 Then Exit Sub
            If IsNull(objAryTMST_TRK.ARYME(0).XADRS_PALLET02) Then
                '(ﾄﾗｯｸﾛｰﾀﾞ、D41、D42以外の場合)
                Exit Sub
            End If


            Dim intCountTrnsEndLoader As Integer = 0        '出庫搬送完了のｶｳﾝﾄ
            For Each objTMST_TRK As TBL_TMST_TRK In objAryTMST_TRK.ARYME
                '(ﾙｰﾌﾟ:該当するﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ数)


                '****************************************************************************
                '****************************************************************************
                'ﾙｰﾌﾟ02
                '出庫搬送中ﾄﾗｯｷﾝｸﾞ数
                '****************************************************************************
                '****************************************************************************
                '**************************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ           取得
                '**************************************
                Dim objAryTPRG_TRK_BUF_RELAY01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                Select Case objTMST_TRK.XLS_NO
                    Case XLS_NO_1F : objAryTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3401    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    Case XLS_NO_2F : objAryTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3402    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                End Select
                objAryTPRG_TRK_BUF_RELAY01.FTR_TO = objTMST_TRK.FTRK_BUF_NO        '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                intRet = objAryTPRG_TRK_BUF_RELAY01.GET_TPRG_TRK_BUF_FIFO(True)    '取得
                If intRet = RetCode.OK Then
                    '(見つかった場合)
                    For Each objTPRG_TRK_BUF_RELAY01 As TBL_TPRG_TRK_BUF In objAryTPRG_TRK_BUF_RELAY01.ARYME
                        '(ﾙｰﾌﾟ:搬送中のﾄﾗｯｷﾝｸﾞ数)


                        '**************************************
                        '搬送完了
                        '**************************************
                        Dim objSVR_010302_01 As New SVR_010302(Owner, ObjDb, ObjDbLog)
                        objSVR_010302_01.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID   'ﾊﾟﾚｯﾄID
                        objSVR_010302_01.FINOUT_STS = FINOUT_STS_SRELAY_END                'IN/OUT
                        Call objSVR_010302_01.ExecCmdFunction()


                        '**************************************
                        '搬送完了するｶｳﾝﾄ           判定
                        '**************************************
                        intCountTrnsEndLoader += 1
                        If intTrnsEndLoader <= intCountTrnsEndLoader Then Exit For


                    Next
                End If


                If intTrnsEndLoader <= intCountTrnsEndLoader Then Exit For
            Next


            '************************************************
            'ﾒｯｾｰｼﾞﾛｸﾞ              追加
            '************************************************
            If Not (intTrnsEndLoader <= intCountTrnsEndLoader) Then
                If objTSTS_EQ_CTRL.FEQ_ID = FEQ_ID_JOTHY04_X048405 Or objTSTS_EQ_CTRL.FEQ_ID = FEQ_ID_JOTHY04_X048406 Then
                    Dim strMsg01 As String
                    Dim strMsg02 As String
                    strMsg01 = "D41orD42の出庫搬送完了を受信しましたが、出庫搬送完了させるﾄﾗｯｷﾝｸﾞが見つかりませんでした。"
                    strMsg02 = "[設備名称:" & objTSTS_EQ_CTRL.FEQ_NAME & "]"
                    strMsg02 &= "[設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]"
                    strMsg02 &= "[ﾊﾟﾚｯﾄ数:" & objTLIF_TRNS_RECV.FDENBUN_PRM2 & "]"
                    Call AddToMsgLog(Now, FMSG_ID_J4001, strMsg01, strMsg02)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & strMsg01 & strMsg02)
                End If
            End If


            If Not (objTSTS_EQ_CTRL.FEQ_ID = FEQ_ID_JOTHY04_X048405 Or objTSTS_EQ_CTRL.FEQ_ID = FEQ_ID_JOTHY04_X048406) Then
                '(D41、D42以外の場合)


                '************************************************
                '設備状況           取得
                '************************************************
                Dim objTSTS_EQ_CTRL_YOTEI01 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                Dim objTSTS_EQ_CTRL_YOTEI02 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                Dim objTSTS_EQ_CTRL_PALLET01 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                Dim objTSTS_EQ_CTRL_PALLET02 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_YOTEI01, objAryTMST_TRK.ARYME(0).XADRS_YOTEI01)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_YOTEI02, objAryTMST_TRK.ARYME(0).XADRS_YOTEI02)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_PALLET01, objAryTMST_TRK.ARYME(0).XADRS_PALLET01)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_PALLET02, objAryTMST_TRK.ARYME(0).XADRS_PALLET02)


                Dim intYoteiSum As Integer = TO_INTEGER(objTSTS_EQ_CTRL_YOTEI01.FEQ_STS) + TO_INTEGER(objTSTS_EQ_CTRL_YOTEI02.FEQ_STS)                          '予定数
                Dim intPalletSum As Integer = TO_INTEGER(objTSTS_EQ_CTRL_PALLET01.FEQ_STS) + TO_INTEGER(objTSTS_EQ_CTRL_PALLET02.FEQ_STS) + intTrnsEndLoader    'ﾊﾟﾚｯﾄ数合計
                If intYoteiSum <= intPalletSum Then
                    '(全ての搬送が完了した場合)


                    '**************************************
                    '到着予定数         送信
                    '到着予定数をﾘｾｯﾄ
                    '**************************************
                    If IsNotNull(objAryTMST_TRK.ARYME(0).XADRS_YOTEI01) Then
                        '(予定数がある場合)
                        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                        objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         'ｺﾏﾝﾄﾞID
                        objSVR_190001.FPALLET_ID = ""                                   'ﾊﾟﾚｯﾄID
                        objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
                        Call objSVR_190001.SendYasukawa_IDYotei(objAryTMST_TRK.ARYME(0).FTRK_BUF_NO _
                                                              , 0 _
                                                              , 0 _
                                                              )
                    End If


                End If


            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  積込完了判定                                                                         "
    '''**********************************************************************************************
    ''' <summary>
    ''' 積込完了判定
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub HanteiTumiEnd(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '**************************************
            'ﾁｪｯｸ
            '**************************************
            If objTSTS_EQ_CTRL.FEQ_STS = FLAG_OFF Then Exit Sub


            '**************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ            取得
            '**************************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.XEQ_ID_B_TUMIEND = objTSTS_EQ_CTRL.FEQ_ID       '設備ID
            intRet = objTMST_TRK.GET_TMST_TRK(False)                    '取得
            If intRet <> RetCode.OK Then Exit Sub


            '**************************************
            '出荷ｺﾝﾍﾞﾔ状況              取得
            '**************************************
            Dim objXSTS_CONVEYOR As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)
            objXSTS_CONVEYOR.XSTNO = objTMST_TRK.FTRK_BUF_NO        'STNo.
            objXSTS_CONVEYOR.GET_XSTS_CONVEYOR()                    '取得


            '**************************************
            '出荷ﾊﾞｰｽ状況               取得
            '**************************************
            Dim blnTumiEnd As Boolean = False       '積込完了処理ﾌﾗｸﾞ
            Dim objAryXSTS_BERTH As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)
            objAryXSTS_BERTH.XBERTH_GROUP = objXSTS_CONVEYOR.XBERTH_GROUP   'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
            intRet = objAryXSTS_BERTH.GET_XSTS_BERTH_ANY()                  '取得
            If intRet = RetCode.OK Then
                For Each objXSTS_BERTH As TBL_XSTS_BERTH In objAryXSTS_BERTH.ARYME
                    '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)

                    If IsNotNull(objXSTS_BERTH.XSYUKKA_D) And IsNotNull(objXSTS_BERTH.XHENSEI_NO) Then
                        '(出荷日、編成№がｾｯﾄされている場合)


                        '************************************************
                        '出荷指示詳細(ﾁｪｯｸ用)           取得
                        '積込完了可能な計画か否かをﾁｪｯｸ
                        '************************************************
                        Dim blnXSYUKKA_STS_DTL_JALL As Boolean = False          '全品出庫判定
                        Dim objAryXPLN_OUT_DTL_Check As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
                        objAryXPLN_OUT_DTL_Check.XSYUKKA_D = objXSTS_BERTH.XSYUKKA_D                '出荷日
                        objAryXPLN_OUT_DTL_Check.XHENSEI_NO_OYA = objXSTS_BERTH.XHENSEI_NO          '親編成No.
                        intRet = objAryXPLN_OUT_DTL_Check.GET_XPLN_OUT_DTL_ANY()                    '取得
                        If intRet <> RetCode.OK Then Throw New System.Exception(ERRMSG_NOTFOUND_XPLN_OUT & "[出荷日:" & objAryXPLN_OUT_DTL_Check.XSYUKKA_D & "][親編成No.:" & objAryXPLN_OUT_DTL_Check.XHENSEI_NO_OYA & "]")
                        For ii As Integer = 0 To UBound(objAryXPLN_OUT_DTL_Check.ARYME)
                            '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)

                            '=====================================
                            '出荷状況詳細       ﾁｪｯｸ
                            '=====================================
                            If objAryXPLN_OUT_DTL_Check.ARYME(ii).XSYUKKA_STS_DTL <> XSYUKKA_STS_DTL_JALL Then
                                '(出荷状況詳細 <> 出庫済 の場合)
                                Exit For
                            End If
                            If UBound(objAryXPLN_OUT_DTL_Check.ARYME) <= ii Then
                                blnXSYUKKA_STS_DTL_JALL = True
                            End If

                        Next


                        If blnXSYUKKA_STS_DTL_JALL = True Then
                            '(全品出庫の場合)


                            '****************************************
                            '積込完了
                            '****************************************
                            Call TumikomiKanryou(objXSTS_BERTH.XBERTH_NO _
                                               , objXSTS_BERTH.XSYUKKA_D _
                                               , objXSTS_BERTH.XHENSEI_NO _
                                               )
                            blnTumiEnd = True


                        Else
                            '(全品出庫じゃない場合)

                            Call AddToMsgLog(Now, FMSG_ID_S9001, "積込完了ﾎﾞﾀﾝを受信しましたが、全品出庫完了していない為、積込完了処理は実行しませんでした。。[ﾊﾞｰｽｸﾞﾙｰﾌﾟ:" & objAryXSTS_BERTH.XBERTH_GROUP & "]")

                        End If


                    End If

                Next
            End If
            If blnTumiEnd = False Then AddToMsgLog(Now, FMSG_ID_S9001, "積込完了ﾎﾞﾀﾝを受信しましたが、積込完了するﾊﾞｰｽが見つかりませんでした。[ﾊﾞｰｽｸﾞﾙｰﾌﾟ:" & objAryXSTS_BERTH.XBERTH_GROUP & "]")


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  入庫搬送元ﾄﾗｯｷﾝｸﾞの解放                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' 入庫搬送元ﾄﾗｯｷﾝｸﾞの解放
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub HanteiInTrnsKaihou(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '**************************************
            'ﾁｪｯｸ
            '**************************************
            If objTSTS_EQ_CTRL.FEQ_STS = FLAG_ON Then Exit Sub


            '**************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ        取得
            '**************************************
            Dim strSQL As String = ""
            Dim objAryTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "    * "
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "    TMST_TRK "
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "        XEQ_ID_IN_FR   = '" & TO_STRING(objTSTS_EQ_CTRL.FEQ_ID) & "'"
            strSQL &= vbCrLf & "    OR  XEQ_ID_IN_BK   = '" & TO_STRING(objTSTS_EQ_CTRL.FEQ_ID) & "'"
            strSQL &= vbCrLf & "    OR  XEQ_ID_HASU_FR = '" & TO_STRING(objTSTS_EQ_CTRL.FEQ_ID) & "'"
            strSQL &= vbCrLf & "    OR  XEQ_ID_HASU_BK = '" & TO_STRING(objTSTS_EQ_CTRL.FEQ_ID) & "'"
            strSQL &= vbCrLf & "  "
            objAryTMST_TRK.USER_SQL = strSQL                     'SQL文
            intRet = objAryTMST_TRK.GET_TMST_TRK_USER()         '取得
            If intRet = RetCode.OK Then
                '(見つかった場合)
                If 1 < objAryTMST_TRK.ARYME.Length Then Throw New Exception("取得したﾚｺｰﾄﾞ数が不正。定義ﾐｽしています。[設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]")
                For Each objTMST_TRK As TBL_TMST_TRK In objAryTMST_TRK.ARYME
                    '(ﾙｰﾌﾟ:1回)


                    '************************************************
                    '設備状況           取得
                    '************************************************
                    Dim objTSTS_EQ_CTRL_IN_FR As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)           '入庫要求前 設備ID
                    Dim objTSTS_EQ_CTRL_IN_BK As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)           '入庫要求後 設備ID
                    Dim objTSTS_EQ_CTRL_HASU_FR As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)         '端数前     設備ID
                    Dim objTSTS_EQ_CTRL_HASU_BK As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)         '端数後     設備ID
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IN_FR, objTMST_TRK.XEQ_ID_IN_FR)               '入庫要求前 設備ID
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IN_BK, objTMST_TRK.XEQ_ID_IN_BK)               '入庫要求後 設備ID
                    If IsNotNull(objTMST_TRK.XEQ_ID_HASU_FR) Then
                        Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_HASU_FR, objTMST_TRK.XEQ_ID_HASU_FR)       '端数前     設備ID
                    Else
                        objTSTS_EQ_CTRL_HASU_FR.FEQ_STS = 0
                    End If
                    If IsNotNull(objTMST_TRK.XEQ_ID_HASU_BK) Then
                        Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_HASU_BK, objTMST_TRK.XEQ_ID_HASU_BK)       '端数後     設備ID
                    Else
                        objTSTS_EQ_CTRL_HASU_BK.FEQ_STS = 0
                    End If


                    '************************************************
                    '設備状態           ﾁｪｯｸ
                    '************************************************
                    If Not ( _
                               objTSTS_EQ_CTRL_IN_FR.FEQ_STS = FEQ_STS_SAGC_ZAIKA_OF _
                           And objTSTS_EQ_CTRL_IN_BK.FEQ_STS = FEQ_STS_SAGC_ZAIKA_OF _
                           And objTSTS_EQ_CTRL_HASU_FR.FEQ_STS = FEQ_STS_SAGC_ZAIKA_OF _
                           And objTSTS_EQ_CTRL_HASU_BK.FEQ_STS = FEQ_STS_SAGC_ZAIKA_OF _
                           ) _
                        Then
                        '(全ての載荷がOFFされていない場合)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                         FLOG_DATA_TRN_SEND_NORMAL _
                                         & "全ての載荷がOFFでない為、搬送元STﾄﾗｯｷﾝｸﾞの解放は行わない。" _
                                         & "[設備ID(入庫要求前):" & TO_STRING(objTSTS_EQ_CTRL_IN_FR.FEQ_ID) & "   設備状態:" & objTSTS_EQ_CTRL_IN_FR.FEQ_STS & "]" _
                                         & "[設備ID(入庫要求後):" & TO_STRING(objTSTS_EQ_CTRL_IN_BK.FEQ_ID) & "   設備状態:" & objTSTS_EQ_CTRL_IN_BK.FEQ_STS & "]" _
                                         & "[設備ID(端数前):" & TO_STRING(objTSTS_EQ_CTRL_HASU_FR.FEQ_ID) & "   設備状態:" & objTSTS_EQ_CTRL_HASU_FR.FEQ_STS & "]" _
                                         & "[設備ID(端数後):" & TO_STRING(objTSTS_EQ_CTRL_HASU_BK.FEQ_ID) & "   設備状態:" & objTSTS_EQ_CTRL_HASU_BK.FEQ_STS & "]" _
                                         )
                        Continue For
                    End If

                    ''D43,D93は解放しない　@2017/08/02 @YAMAMOTO
                    If objTMST_TRK.FTRK_BUF_NO <> 2051 And objTMST_TRK.FTRK_BUF_NO <> 2901 Then

                        '**************************************
                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(FM)           解放
                        '**************************************
                        Dim objAryTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        strSQL = ""
                        strSQL &= vbCrLf & " SELECT "
                        strSQL &= vbCrLf & "    * "
                        strSQL &= vbCrLf & " FROM "
                        strSQL &= vbCrLf & "    TPRG_TRK_BUF "
                        strSQL &= vbCrLf & " WHERE "
                        strSQL &= vbCrLf & "        FRES_KIND = " & TO_STRING(FRES_KIND_SRSV_TRNS_IN)
                        strSQL &= vbCrLf & "    AND FTRK_BUF_NO = " & TO_STRING(objTMST_TRK.FTRK_BUF_NO)
                        strSQL &= vbCrLf & "    AND FRSV_PALLET IS NOT NULL "
                        strSQL &= vbCrLf & "  "
                        objAryTPRG_TRK_BUF_FM.USER_SQL = strSQL                     'SQL文
                        intRet = objAryTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF_USER()      '取得
                        If intRet = RetCode.OK Then
                            For Each objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF In objAryTPRG_TRK_BUF_FM.ARYME
                                '(ﾙｰﾌﾟ:解放するﾄﾗｯｷﾝｸﾞ数)
                                objTPRG_TRK_BUF_FM.CLEAR_TPRG_TRK_BUF()      '解放
                            Next
                        End If

                    End If
                Next
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  ｴﾗｰｺｰﾄﾞを設備異常ﾛｸﾞに登録                                                           "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｴﾗｰｺｰﾄﾞを設備異常ﾛｸﾞに登録
    ''' ﾋﾞｯﾄｴﾗｰの設備異常ﾛｸﾞは、別箇所で追加しているので、ｸﾚｰﾝのｴﾗｰｺｰﾄﾞのみこちらで登録
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">搬送制御受信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub InsertTLOG_EQ_ERROR_ErrorCode(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                                            , ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL _
                                            )
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '**************************************
            '更新する設備ID(ｸﾚｰﾝ)       取得
            '**************************************
            Dim strFEQ_ID As String = ""
            Select Case objTSTS_EQ_CTRL.FEQ_ID
                Case FEQ_ID_JOTHY05_X048501 : strFEQ_ID = FEQ_ID_JCRN0001
                Case FEQ_ID_JOTHY05_X048502 : strFEQ_ID = FEQ_ID_JCRN0002
                Case FEQ_ID_JOTHY05_X048503 : strFEQ_ID = FEQ_ID_JCRN0003
                Case FEQ_ID_JOTHY05_X048504 : strFEQ_ID = FEQ_ID_JCRN0004
                Case FEQ_ID_JOTHY05_X048505 : strFEQ_ID = FEQ_ID_JCRN0005
                Case FEQ_ID_JOTHY05_X048506 : strFEQ_ID = FEQ_ID_JCRN0006
                Case FEQ_ID_JOTHY05_X048507 : strFEQ_ID = FEQ_ID_JCRN0007
                Case FEQ_ID_JOTHY05_X048508 : strFEQ_ID = FEQ_ID_JCRN0008
                Case FEQ_ID_JOTHY05_X048509 : strFEQ_ID = FEQ_ID_JCRN0009
                Case FEQ_ID_JOTHY05_X048510 : strFEQ_ID = FEQ_ID_JCRN0010
                Case FEQ_ID_JOTHY05_X048511 : strFEQ_ID = FEQ_ID_JCRN0011
                Case FEQ_ID_JOTHY05_X048512 : strFEQ_ID = FEQ_ID_JCRN0012
                Case FEQ_ID_JOTHY05_X048513 : strFEQ_ID = FEQ_ID_JCRN0013
                Case FEQ_ID_JOTHY05_X048514 : strFEQ_ID = FEQ_ID_JCRN0014
                Case Else : Exit Sub
            End Select


            '************************
            'MDD用ｴﾗｰｺｰﾄﾞに変換
            '************************
            Dim strMDDErrCode As String = GetMDDErrCodeFromPLCErrCode(objTLIF_TRNS_RECV.FDENBUN_PRM2)


            '************************
            '設備停止要因ﾏｽﾀの特定
            '************************
            Dim objTMST_EQ_ERROR As New TBL_TMST_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '設備停止要因ﾏｽﾀ
            objTMST_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '設備ID
            objTMST_EQ_ERROR.FEQ_STS = strMDDErrCode                                    '設備状態
            intRet = objTMST_EQ_ERROR.GET_TMST_EQ_ERROR(False)                          '特定


            If objTSTS_EQ_CTRL.FEQ_STS <> 0 Then
                '(異常 の場合)

                '====================
                '設備異常ﾛｸﾞ登録
                '====================
                Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '設備異常ﾛｸﾞ
                objTLOG_EQ_ERROR.FHASSEI_DT = objTLIF_TRNS_RECV.FENTRY_DT                   '発生日時
                objTLOG_EQ_ERROR.FHUKKI_DT = DEFAULT_DATE                                   '復旧日時
                objTLOG_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '設備ID
                objTLOG_EQ_ERROR.FEQ_STS = strMDDErrCode                                    '設備状態
                objTLOG_EQ_ERROR.FEQ_STOP_CD = objTLIF_TRNS_RECV.FDENBUN_PRM3               '停止ｺｰﾄﾞ
                objTLOG_EQ_ERROR.ADD_TLOG_EQ_ERROR_SEQ()                                    '登録

                '====================
                'ｸﾚｰﾝ状態       更新
                '====================
                If IsNotNull(strFEQ_ID) Then Call Set_FEQ_STS(strFEQ_ID, FEQ_STS_JCRN_IJOU)

                '====================
                'ﾒｯｾｰｼﾞ履歴書き込み
                '====================
                Call AddToMsgLog(Now, FMSG_ID_S0104, "[設備名称:" & objTSTS_EQ_CTRL.FEQ_NAME & ":" & strMDDErrCode & "][ｴﾗｰ名称:" & objTMST_EQ_ERROR.FEQ_STOP_NAME & "]")

            Else
                '(正常 の場合)

                '====================
                '設備異常ﾛｸﾞ更新
                '====================
                Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '設備異常ﾛｸﾞ
                objTLOG_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '設備ID
                objTLOG_EQ_ERROR.FHUKKI_DT = objTLIF_TRNS_RECV.FENTRY_DT                    '復旧日時
                objTLOG_EQ_ERROR.UPDATE_TLOG_EQ_ERROR_FEQ_ID()                              '登録

                '====================
                'ｸﾚｰﾝ状態       更新
                '====================
                If IsNotNull(strFEQ_ID) Then Call Set_FEQ_STS(strFEQ_ID, FEQ_STS_JCRN_UNTEN)

            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  D45出庫要求数を包材出庫設定状態(D45)ﾃｰﾌﾞﾙに更新                                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' D45出庫要求数を包材出庫設定状態(D45)ﾃｰﾌﾞﾙに更新
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">搬送制御受信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateXSTS_WRAPPING_MATERIAL_D45(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                                               , ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL _
                                               )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


        '**************************************
        'ﾁｪｯｸ
        '**************************************
        Select Case objTSTS_EQ_CTRL.FEQ_ID
            Case FEQ_ID_JOTHY05_X049001 _
               , FEQ_ID_JOTHY05_X049002 _
               , FEQ_ID_JOTHY05_X049003 _
               , FEQ_ID_JOTHY05_X049004 _
               , FEQ_ID_JOTHY05_X049005 _
               , FEQ_ID_JOTHY05_X049006 _
               , FEQ_ID_JOTHY05_X049007 _
                '(ｴﾗｰｺｰﾄﾞの場合)
                'NOP
            Case Else
                Exit Sub
        End Select


        '************************************************
        '包材出庫設定状態(D45)          取得
        '************************************************
        Dim objXSTS_WRAPPING_MATERIAL_D45 As New TBL_XSTS_WRAPPING_MATERIAL_D45(Owner, ObjDb, ObjDbLog)
        objXSTS_WRAPPING_MATERIAL_D45.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID               '設備ID
        objXSTS_WRAPPING_MATERIAL_D45.GET_XSTS_WRAPPING_MATERIAL_D45()                '取得


        '************************************************
        '包材出庫設定状態(D45)          更新
        '************************************************
        objXSTS_WRAPPING_MATERIAL_D45.XPLAN_NUM = objTSTS_EQ_CTRL.FEQ_STS       '計画数量
        'objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM = 0                           '実績数量
        objXSTS_WRAPPING_MATERIAL_D45.UPDATE_XSTS_WRAPPING_MATERIAL_D45()       '更新


    End Sub
#End Region

#Region "  1F出庫要求数を包材出庫設定状態(1F)ﾃｰﾌﾞﾙに更新                                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' 1F出庫要求数を包材出庫設定状態(1F)ﾃｰﾌﾞﾙに更新
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">搬送制御受信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateXSTS_WRAPPING_MATERIAL_1F(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                                               , ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL _
                                               )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Dim intFlag As Integer = FLAG_OFF
        Dim strOUTOU_ID As String
        '**************************************
        'ﾁｪｯｸ
        '**************************************
        Select Case Mid(objTSTS_EQ_CTRL.FEQ_ID, 1, 16)
            Case "JOTHY03_X048291_", "JOTHY03_X048292_", "JOTHY04_X048291_", "JOTHY04_X048292_", "JOTHY06_X048291_", "JOTHY06_X048292_"
                strOUTOU_ID = Mid(objTSTS_EQ_CTRL.FEQ_ID, 1, 18)
                strOUTOU_ID = strOUTOU_ID.Replace("X04829", "X04849")
                '(ｴﾗｰｺｰﾄﾞの場合)
                'NOP
            Case Else
                Exit Sub
        End Select


        '************************************************
        '包材出庫設定状態(1F)          取得
        '************************************************
        Dim objXSTS_WRAPPING_MATERIAL_1F As New TBL_XSTS_WRAPPING_MATERIAL_1F(Owner, ObjDb, ObjDbLog)
        objXSTS_WRAPPING_MATERIAL_1F.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID               '設備ID
        objXSTS_WRAPPING_MATERIAL_1F.GET_XSTS_WRAPPING_MATERIAL_1F()                '取得

        If objTLIF_TRNS_RECV.FDENBUN_PRM2 = FLAG_ON Then
            ''1.OFF→ONの場合
            ''・計画に出庫PL設定枚数を加算する()
            objXSTS_WRAPPING_MATERIAL_1F.XPLAN_NUM = TO_INTEGER(objXSTS_WRAPPING_MATERIAL_1F.XPLAN_NUM) + TO_INTEGER(objXSTS_WRAPPING_MATERIAL_1F.XOUT_PALLET_NUM)       '計画数量
            objXSTS_WRAPPING_MATERIAL_1F.UPDATE_XSTS_WRAPPING_MATERIAL_1F()       '更新
            ''・返答ﾌﾗｸﾞON()
            intFlag = FLAG_ON
            ''・ONしたﾌﾗｸﾞの設備状態を更新()
        Else
            ''・返答ﾌﾗｸﾞOFF()
            intFlag = FLAG_OFF
        End If

        '************************************************
        'PLCﾒﾝﾃﾅﾝｽ
        '************************************************
        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(strOUTOU_ID, "JW_MAINTE_YOTEI", intFlag.ToString)
        

        ''・ON/OFFしたﾌﾗｸﾞの設備状態を更新()
        Dim objTSTS_EQ_CTRL2 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        objTSTS_EQ_CTRL2.FEQ_ID = strOUTOU_ID
        objTSTS_EQ_CTRL2.GET_TSTS_EQ_CTRL(False)
        '更新
        objTSTS_EQ_CTRL2.FEQ_STS = intFlag
        objTSTS_EQ_CTRL2.UPDATE_TSTS_EQ_CTRL()

    End Sub
#End Region

#Region "  D43,D93入庫要求OFF時ﾄﾗｯｷﾝｸﾞ解放                                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' D43,D93入庫要求OFF時ﾄﾗｯｷﾝｸﾞ解放
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">搬送制御受信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateXSTS_ITF(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                                               , ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL _
                                               )
        Dim intRet As Integer
        Dim intBufNo As Integer = 0
        Dim strSQL As String

        '**************************************
        'ﾁｪｯｸ
        '**************************************
        Select Case objTSTS_EQ_CTRL.FEQ_ID
            Case "JOTHMFF_D000003_04", "JOTHMFF_D000003_05"
                intBufNo = 2051
            Case "JOTHMFF_D000005_00", "JOTHMFF_D000005_01"
                intBufNo = 2901
            Case Else
                Exit Sub
        End Select

        If objTSTS_EQ_CTRL.FEQ_STS = FLAG_OFF Then Exit Sub

        If objTLIF_TRNS_RECV.FDENBUN_PRM2 = FLAG_ON Then Exit Sub

        '**************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(FM)           解放
        '**************************************
        Dim objAryTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    * "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TPRG_TRK_BUF "
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        FRES_KIND = " & TO_STRING(FRES_KIND_SRSV_TRNS_IN)
        strSQL &= vbCrLf & "    AND FTRK_BUF_NO = " & TO_STRING(intBufNo)
        strSQL &= vbCrLf & "    AND FRSV_PALLET IS NOT NULL "
        strSQL &= vbCrLf & "  "
        objAryTPRG_TRK_BUF_FM.USER_SQL = strSQL                     'SQL文
        intRet = objAryTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF_USER()      '取得
        If intRet = RetCode.OK Then
            For Each objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF In objAryTPRG_TRK_BUF_FM.ARYME
                '(ﾙｰﾌﾟ:解放するﾄﾗｯｷﾝｸﾞ数)
                objTPRG_TRK_BUF_FM.CLEAR_TPRG_TRK_BUF()      '解放
            Next
        End If

    End Sub
#End Region

#Region "  ﾛｰｶﾙ異常ﾗﾝﾌﾟ(JOTHMFF_D000104_12)更新                                                 "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾛｰｶﾙ異常ﾗﾝﾌﾟ(JOTHMFF_D000104_12)更新
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateLocalErrLamp(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '****************************************
            '設備異常ﾛｸﾞ            取得
            '****************************************
            Dim intCount As Integer = 0
            Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)
            objTLOG_EQ_ERROR.WHERE = "    AND FHUKKI_DT IS NULL "   '条件
            intCount = objTLOG_EQ_ERROR.GET_TLOG_EQ_ERROR_COUNT()   '件数取得


            '****************************************
            '設備異常ﾛｸﾞ            取得
            '****************************************
            Dim objTSTS_EQ_CTRL_Lamp As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            objTSTS_EQ_CTRL_Lamp.FEQ_ID = FEQ_ID_JOTHMFF_D000104_12     '設備ID
            objTSTS_EQ_CTRL_Lamp.GET_TSTS_EQ_CTRL()                     '取得


            '****************************************
            'ﾛｰｶﾙ異常ﾗﾝﾌﾟ(JOTHMFF_D000104_12)更新
            '****************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            If 0 = intCount Then
                '(異常なしの場合)
                If objTSTS_EQ_CTRL_Lamp.FEQ_STS <> 0 Then
                    Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000104_12, FTEXT_ID_JW_ETC, 0)
                End If
            Else
                '(異常ありの場合)
                If objTSTS_EQ_CTRL_Lamp.FEQ_STS <> 1 Then
                    Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000104_12, FTEXT_ID_JW_ETC, 1)
                End If
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  ﾄﾗｯｸﾛｰﾀﾞﾓｰﾄﾞﾘｸｴｽﾄ処理                                                                "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｸﾛｰﾀﾞﾓｰﾄﾞﾘｸｴｽﾄ処理、ﾄﾗｯｸﾛｰﾀﾞﾓｰﾄﾞ受信完了処理
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateLoaderModeON(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '**************************************
            'ﾁｪｯｸ
            '**************************************
            If objTSTS_EQ_CTRL.FEQ_STS <> FLAG_ON Then Exit Sub


            '****************************************
            'ﾁｪｯｸ
            '****************************************
            Dim strAdrsMode As String = ""          '書込ｱﾄﾞﾚｽ(ﾓｰﾄﾞ)
            Dim strAdrsBit As String = ""           '書込ｱﾄﾞﾚｽ(ﾋﾞｯﾄ)
            Dim strFEQ_ID_Kidou01 As String = ""    'ﾊﾞｰｽ起動中ﾋﾞｯﾄ01
            Dim strFEQ_ID_Kidou02 As String = ""    'ﾊﾞｰｽ起動中ﾋﾞｯﾄ02
            Dim strFEQ_ID_Kidou03 As String = ""    'ﾊﾞｰｽ起動中ﾋﾞｯﾄ03
            Select Case objTSTS_EQ_CTRL.FEQ_ID
                Case FEQ_ID_JOTHMFF_D000032_07
                    '(ﾛｰﾀﾞ1号機の場合)
                    strAdrsMode = FEQ_ID_JOTHMFF_D000105                '書込ｱﾄﾞﾚｽ(ﾓｰﾄﾞ)
                    strAdrsBit = FEQ_ID_JOTHMFF_D000105_07              '書込ｱﾄﾞﾚｽ(ﾋﾞｯﾄ)
                    strFEQ_ID_Kidou01 = FEQ_ID_JOTHMFF_D000025_15       'ﾊﾞｰｽ起動中ﾋﾞｯﾄ01
                    strFEQ_ID_Kidou02 = FEQ_ID_JOTHMFF_D000025_14       'ﾊﾞｰｽ起動中ﾋﾞｯﾄ02
                    strFEQ_ID_Kidou03 = FEQ_ID_JOTHMFF_D000025_13       'ﾊﾞｰｽ起動中ﾋﾞｯﾄ03
                Case FEQ_ID_JOTHMFF_D000032_06
                    '(ﾛｰﾀﾞ2号機の場合)
                    strAdrsMode = FEQ_ID_JOTHMFF_D000106                '書込ｱﾄﾞﾚｽ(ﾓｰﾄﾞ)
                    strAdrsBit = FEQ_ID_JOTHMFF_D000106_07              '書込ｱﾄﾞﾚｽ(ﾋﾞｯﾄ)
                    strFEQ_ID_Kidou01 = FEQ_ID_JOTHMFF_D000025_12       'ﾊﾞｰｽ起動中ﾋﾞｯﾄ01
                    strFEQ_ID_Kidou02 = FEQ_ID_JOTHMFF_D000025_11       'ﾊﾞｰｽ起動中ﾋﾞｯﾄ02
                    strFEQ_ID_Kidou03 = FEQ_ID_JOTHMFF_D000025_10       'ﾊﾞｰｽ起動中ﾋﾞｯﾄ03
                Case Else : Exit Sub
            End Select


            '*************************************************
            '設備状況           取得
            '*************************************************
            Dim objTSTS_EQ_CTRL_Kidou01 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     'ﾊﾞｰｽ起動中ﾋﾞｯﾄ01
            Dim objTSTS_EQ_CTRL_Kidou02 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     'ﾊﾞｰｽ起動中ﾋﾞｯﾄ02
            Dim objTSTS_EQ_CTRL_Kidou03 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     'ﾊﾞｰｽ起動中ﾋﾞｯﾄ03
            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_Kidou01, strFEQ_ID_Kidou01)
            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_Kidou02, strFEQ_ID_Kidou02)
            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_Kidou03, strFEQ_ID_Kidou03)


            '*************************************************
            'ﾁｪｯｸ
            '*************************************************
            Dim objTSTS_EQ_CTRL_KidouOn As TBL_TSTS_EQ_CTRL
            If TO_INTEGER(objTSTS_EQ_CTRL_Kidou01.FEQ_STS) + TO_INTEGER(objTSTS_EQ_CTRL_Kidou02.FEQ_STS) + TO_INTEGER(objTSTS_EQ_CTRL_Kidou03.FEQ_STS) = 1 Then
                '(どれか1個だけONの場合)

                If TO_INTEGER(objTSTS_EQ_CTRL_Kidou01.FEQ_STS) = FLAG_ON Then
                    objTSTS_EQ_CTRL_KidouOn = objTSTS_EQ_CTRL_Kidou01
                ElseIf TO_INTEGER(objTSTS_EQ_CTRL_Kidou02.FEQ_STS) = FLAG_ON Then
                    objTSTS_EQ_CTRL_KidouOn = objTSTS_EQ_CTRL_Kidou02
                ElseIf TO_INTEGER(objTSTS_EQ_CTRL_Kidou03.FEQ_STS) = FLAG_ON Then
                    objTSTS_EQ_CTRL_KidouOn = objTSTS_EQ_CTRL_Kidou03
                Else
                    Throw New Exception("ﾄﾗｯｸﾛｰﾀﾞﾓｰﾄﾞﾘｸｴｽﾄを受信しましたが、ﾊﾞｰｽ起動中ONのﾊﾞｰｽが存在しません。[" & objTSTS_EQ_CTRL.FEQ_NAME & "]")
                End If

            Else
                '(どれか1個だけONじゃない場合)

                Throw New Exception("ﾄﾗｯｸﾛｰﾀﾞﾓｰﾄﾞﾘｸｴｽﾄを受信しましたが、ﾊﾞｰｽ起動中ONを特定出来ません。" _
                                  & "[" & objTSTS_EQ_CTRL.FEQ_NAME & "]" _
                                  & "[" & objTSTS_EQ_CTRL_Kidou01.FEQ_NAME & ":" & TO_STRING(objTSTS_EQ_CTRL_Kidou01.FEQ_STS) & "]" _
                                  & "[" & objTSTS_EQ_CTRL_Kidou02.FEQ_NAME & ":" & TO_STRING(objTSTS_EQ_CTRL_Kidou02.FEQ_STS) & "]" _
                                  & "[" & objTSTS_EQ_CTRL_Kidou03.FEQ_NAME & ":" & TO_STRING(objTSTS_EQ_CTRL_Kidou03.FEQ_STS) & "]" _
                                  )

            End If


            '*************************************************
            'ﾊﾞｰｽの特定
            '*************************************************
            Dim strXBERTH_NO As String = ""
            Select Case objTSTS_EQ_CTRL_KidouOn.FEQ_ID
                Case FEQ_ID_JOTHMFF_D000025_15 : strXBERTH_NO = XBERTH_NO_JX01
                Case FEQ_ID_JOTHMFF_D000025_14 : strXBERTH_NO = XBERTH_NO_JX02
                Case FEQ_ID_JOTHMFF_D000025_13 : strXBERTH_NO = XBERTH_NO_JX03
                Case FEQ_ID_JOTHMFF_D000025_12 : strXBERTH_NO = XBERTH_NO_JX04
                Case FEQ_ID_JOTHMFF_D000025_11 : strXBERTH_NO = XBERTH_NO_JX05
                Case FEQ_ID_JOTHMFF_D000025_10 : strXBERTH_NO = XBERTH_NO_JX06
            End Select


            '*************************************************
            '出荷ﾊﾞｰｽ状況       取得
            '*************************************************
            Dim intXSYARYOU_NO As Nullable(Of Integer) = Nothing           '車輌番号
            Dim objXSTS_BERTH As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)
            objXSTS_BERTH.XBERTH_NO = strXBERTH_NO  'ﾊﾞｰｽNo.
            objXSTS_BERTH.GET_XSTS_BERTH()          '取得
            If IsNotNull(objXSTS_BERTH.XSYUKKA_D) And IsNotNull(objXSTS_BERTH.XHENSEI_NO) Then
                '(車輌が割り付いている場合)


                '*************************************************
                '出荷指示               取得
                '*************************************************
                Dim objAryXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
                objAryXPLN_OUT.XSYUKKA_D = objXSTS_BERTH.XSYUKKA_D          '出荷日
                objAryXPLN_OUT.XHENSEI_NO = objXSTS_BERTH.XHENSEI_NO        '編成No.
                intRet = objAryXPLN_OUT.GET_XPLN_OUT_ANY()                  '取得
                If intRet = RetCode.OK Then
                    intXSYARYOU_NO = objAryXPLN_OUT.ARYME(0).XSYARYOU_NO    '車輌番号       ｾｯﾄ
                Else
                    Throw New Exception("ﾄﾗｯｸﾛｰﾀﾞﾓｰﾄﾞﾘｸｴｽﾄを受信しましたが、出荷指示から車輌を特定出来ません。[出荷日:" & Format(objXSTS_BERTH.XSYUKKA_D, DATE_FORMAT_02) & "][編成№:" & objXSTS_BERTH.XHENSEI_NO & "]")
                End If


            Else
                '(車輌が割り付いていない場合)

                Throw New Exception("ﾄﾗｯｸﾛｰﾀﾞﾓｰﾄﾞﾘｸｴｽﾄを受信しましたが、ﾊﾞｰｽ起動中ONのﾊﾞｰｽに車輌が割り付いていません。" _
                                  & "[" & objXSTS_BERTH.XBERTH_NO & "]" _
                                  & "[" & objTSTS_EQ_CTRL_Kidou01.FEQ_NAME & ":" & TO_STRING(objTSTS_EQ_CTRL_Kidou01.FEQ_STS) & "]" _
                                  & "[" & objTSTS_EQ_CTRL_Kidou02.FEQ_NAME & ":" & TO_STRING(objTSTS_EQ_CTRL_Kidou02.FEQ_STS) & "]" _
                                  & "[" & objTSTS_EQ_CTRL_Kidou03.FEQ_NAME & ":" & TO_STRING(objTSTS_EQ_CTRL_Kidou03.FEQ_STS) & "]" _
                                  )

            End If


            '*************************************************
            '車輌ﾏｽﾀ            取得
            '*************************************************
            Dim objXMST_SYARYOU As New TBL_XMST_SYARYOU(Owner, ObjDb, ObjDbLog)
            objXMST_SYARYOU.XSYARYOU_NO = intXSYARYOU_NO        '車輌番号
            objXMST_SYARYOU.GET_XMST_SYARYOU()                  '取得
            If IsNotNull(objXMST_SYARYOU.XSYARYOU_MODE) Then
                '(ﾃﾞｰﾀがｾｯﾄされていた場合)


                '****************************************
                'Melsec       ﾛｰﾀﾞｰﾓｰﾄﾞ     書込
                '****************************************
                Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                Call objSVR_190001.SendYasukawa_IDLoaderMode(TO_INTEGER(objXMST_SYARYOU.XSYARYOU_MODE), strAdrsMode, 0)
                Call objSVR_190001.SendYasukawa_IDLoaderMode(TO_INTEGER(objXMST_SYARYOU.XSYARYOU_MODE), strAdrsMode, 1)
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(strAdrsBit, FTEXT_ID_JW_ETC, FLAG_ON)


            Else
                '(ﾃﾞｰﾀがｾｯﾄされていない場合)
                Throw New Exception("ﾄﾗｯｸﾛｰﾀﾞﾓｰﾄﾞﾘｸｴｽﾄを受信しましたが、ﾄﾗｯｸが割り付いてないか、車輌ﾏｽﾀにﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)が定義されていません。[設備名称:" & objTSTS_EQ_CTRL.FEQ_NAME & "][車輌番号:" & TO_STRING(objXMST_SYARYOU.XSYARYOU_NO) & "]")
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  ﾄﾗｯｸﾛｰﾀﾞﾓｰﾄﾞ受信完了処理                                                             "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｸﾛｰﾀﾞﾓｰﾄﾞﾘｸｴｽﾄ処理、ﾄﾗｯｸﾛｰﾀﾞﾓｰﾄﾞ受信完了処理
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateLoaderModeOFF(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '**************************************
            'ﾁｪｯｸ
            '**************************************
            If objTSTS_EQ_CTRL.FEQ_STS <> FLAG_ON Then Exit Sub


            '****************************************
            'ﾁｪｯｸ
            '****************************************
            Dim strAdrsBit As String = ""           '書込ｱﾄﾞﾚｽ(ﾋﾞｯﾄ)
            Select Case objTSTS_EQ_CTRL.FEQ_ID
                Case FEQ_ID_JOTHMFF_D000032_15
                    '(ﾛｰﾀﾞ1号機の場合)
                    strAdrsBit = FEQ_ID_JOTHMFF_D000105_07              '書込ｱﾄﾞﾚｽ(ﾋﾞｯﾄ)
                Case FEQ_ID_JOTHMFF_D000032_14
                    '(ﾛｰﾀﾞ2号機の場合)
                    strAdrsBit = FEQ_ID_JOTHMFF_D000106_07              '書込ｱﾄﾞﾚｽ(ﾋﾞｯﾄ)
                Case Else : Exit Sub
            End Select


            '****************************************
            'Melsec       ﾛｰﾀﾞｰﾓｰﾄﾞ     書込ﾌﾗｸﾞOFF
            '****************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(strAdrsBit, FTEXT_ID_JW_ETC, FLAG_OFF)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region



    '車輌ｺﾝﾄﾛｰﾗ系
#Region "  読込_ｶｰﾄﾞﾘｰﾀﾞ読込(出荷指示更新)                                                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' 読込_ｶｰﾄﾞﾘｰﾀﾞ読込
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">搬送制御受信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function CARTelRecvJR_CARD(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV) As RetCode
        Dim intRet As RetCode                   '戻り値


        '-------------------    
        'ﾁｪｯｸ
        '-------------------    
        If TO_STRING(objTLIF_TRNS_RECV.FDENBUN_PRM1) = "000000" Then Return RetCode.OK


        '-------------------    
        '初期設定
        '-------------------    
        Dim strSQL As String                    'SQL文
        Dim objPLN_OUT_ARY As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)


        '-------------------    
        '(車輌ﾏｽﾀ)
        '-------------------    
        Dim intRetCode_SYARYOU As RetCode                                   '戻り値
        Dim objMST_SYARYOU As New TBL_XMST_SYARYOU(Owner, ObjDb, ObjDbLog)  '車輌ﾏｽﾀｸﾗｽ
        objMST_SYARYOU.XCARD_NO = objTLIF_TRNS_RECV.FDENBUN_PRM1            'ｶｰﾄﾞ番号
        intRetCode_SYARYOU = objMST_SYARYOU.GET_XMST_SYARYOU(False)         '既存ﾃﾞｰﾀ読込
        If intRetCode_SYARYOU = RetCode.NotFound Then
            Call AddToMsgLog(Now, FMSG_ID_J5003, "車輌ﾏｽﾀ該当ﾃﾞｰﾀ無し ｶｰﾄﾞ№=[" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "]")
            Return RetCode.NG
        End If
        If TO_INTEGER(objMST_SYARYOU.XLOADER_POSSIBLE) <> FLAG_ON Then
            Call AddToMsgLog(Now, FMSG_ID_J5003, "ﾛｰﾀﾞに対応していない車輌受付が行われました。 車輌番号=[" & TO_STRING(objMST_SYARYOU.XSYARYOU_NO) & "]")
            Return RetCode.NG
        End If


        If objTLIF_TRNS_RECV.FDENBUN_PRM2 = "01" Then
            '(入構時)


            '-------------------    
            '入構処理(未入構ﾃﾞｰﾀ有り)
            '-------------------
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XPLN_OUT"       '出荷指示詳細
            strSQL &= vbCrLf & " WHERE"
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2014/01/20 ﾛｰﾀﾞﾊﾞｰｽ 同一車両№＆同時受付対応
            '' ''strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '車輌番号
            '' ''strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS <= " & TO_STRING(XSYUKKA_STS_JOUT)             '出荷状況(出庫済)
            '' ''strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS >= " & TO_STRING(XSYUKKA_STS_JNON)             '出荷状況(受付済)
            strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '車輌番号
            strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS <= " & TO_STRING(XSYUKKA_STS_JOUT)             '出荷状況(出庫済)
            strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS >= " & TO_STRING(XSYUKKA_STS_JNON)             '出荷状況(受付済)
            strSQL &= vbCrLf & "    AND(XPLN_OUT.XBERTH_NO IS NULL"
            strSQL &= vbCrLf & "     OR XPLN_OUT.XBERTH_NO IN ('" & XBERTH_NO_JX01 & "'," & _
                                                              "'" & XBERTH_NO_JX02 & "'," & _
                                                              "'" & XBERTH_NO_JX03 & "'," & _
                                                              "'" & XBERTH_NO_JX04 & "'," & _
                                                              "'" & XBERTH_NO_JX05 & "'," & _
                                                              "'" & XBERTH_NO_JX06 & "'))"                  'ﾊﾞｰｽ№(ﾛｰﾀﾞﾊﾞｰｽ)
            'JobMate:S.Ouchi 2014/01/20 ﾛｰﾀﾞﾊﾞｰｽ 同一車両№＆同時受付対応
            '↑↑↑↑↑↑************************************************************************************************************
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D"                                                     '出荷日
            strSQL &= vbCrLf & "   ,XPLN_OUT.XUNKOU_NO"                                                     '倉庫別運行№
            strSQL &= vbCrLf & "   ,XPLN_OUT.XHENSEI_NO"                                                    '編成№
            strSQL &= vbCrLf & "   ,XPLN_OUT.XDENPYOU_NO"                                                   '伝票№
            strSQL &= vbCrLf

            objPLN_OUT_ARY.USER_SQL = strSQL
            intRet = objPLN_OUT_ARY.GET_XPLN_OUT_USER()
            If intRet = RetCode.OK Then


                '******************************
                '出荷状況ﾁｪｯｸ
                '******************************
                For Each objPLN_OUT As TBL_XPLN_OUT In objPLN_OUT_ARY.ARYME
                    If objPLN_OUT.XSYUKKA_STS <> XSYUKKA_STS_JNON Then
                        Call AddToMsgLog(Now, FMSG_ID_J5003, "既に同じ車輌番号の出荷指示が実行されています。[車輌番号:" & TO_STRING(objMST_SYARYOU.XSYARYOU_NO) & "]")
                        Return RetCode.NG
                    End If
                Next


                '******************************
                '出荷状況更新
                '******************************
                Dim dtmXSYUKKA_D As Nullable(Of Date)                                       '出荷日
                Dim strXHENSEI_NO As String = ""                                            '編成№
                For Each objPLN_OUT As TBL_XPLN_OUT In objPLN_OUT_ARY.ARYME
                    If IsNull(dtmXSYUKKA_D) = True And strXHENSEI_NO = "" Then
                        dtmXSYUKKA_D = objPLN_OUT.XSYUKKA_D
                        strXHENSEI_NO = objPLN_OUT.XHENSEI_NO
                    Else
                        If dtmXSYUKKA_D <> objPLN_OUT.XSYUKKA_D Or _
                           strXHENSEI_NO <> objPLN_OUT.XHENSEI_NO Then
                            Exit For
                        End If
                    End If

                    '-------------------
                    '出荷指示更新(受付済)
                    '-------------------
                    objPLN_OUT.XTUMI_HOUKOU = XTUMI_HOUKOU_JBACK                            '積込方向(後積)
                    objPLN_OUT.XTUMI_HOUHOU = XTUMI_HOUHOU_JL                               '積込方法(ﾛｰﾀﾞ積)
                    If objTLIF_TRNS_RECV.FDENBUN_PRM2 = CAR_SYUBETU_REQ Then
                        objPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JREQ                               '出荷状況(受付済)
                    End If
                    objPLN_OUT.XSYARYOU_ENTRY_DT = Now                                      '車輌受付日時
                    objPLN_OUT.XSYUKKA_DIR_DT = Now                                         '出荷指示日時
                    objPLN_OUT.XHENSEI_NO_OYA = objPLN_OUT.XHENSEI_NO                       '親編成№
                    objPLN_OUT.UPDATE_XPLN_OUT()
                Next


            ElseIf intRet = RetCode.NotFound Then
                Call AddToMsgLog(Now, FMSG_ID_J5003, "出荷指示が存在しません。[車輌番号:" & TO_STRING(objMST_SYARYOU.XSYARYOU_NO) & "]")
                Return RetCode.NG
            End If


        ElseIf objTLIF_TRNS_RECV.FDENBUN_PRM2 = "02" Then
            '(出構時)


            '--------------------------------------
            '--------------------------------------
            '出荷指示読込
            '--------------------------------------
            '--------------------------------------
            '-------------------    
            '出構処理(出庫済ﾃﾞｰﾀ有り)
            '-------------------
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XPLN_OUT"       '出荷指示詳細
            strSQL &= vbCrLf & " WHERE"
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2014/01/20 ﾛｰﾀﾞﾊﾞｰｽ 同一車両№＆同時受付対応
            '' ''strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '車輌番号
            '' ''strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS = " & TO_STRING(XSYUKKA_STS_JOUT)              '出荷状況(出庫済)
            strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '車輌番号
            strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS = " & TO_STRING(XSYUKKA_STS_JOUT)              '出荷状況(出庫済)
            strSQL &= vbCrLf & "    AND XPLN_OUT.XBERTH_NO IN ('" & XBERTH_NO_JX01 & "'," & _
                                                              "'" & XBERTH_NO_JX02 & "'," & _
                                                              "'" & XBERTH_NO_JX03 & "'," & _
                                                              "'" & XBERTH_NO_JX04 & "'," & _
                                                              "'" & XBERTH_NO_JX05 & "'," & _
                                                              "'" & XBERTH_NO_JX06 & "')"                   'ﾊﾞｰｽ№(ﾛｰﾀﾞﾊﾞｰｽ)
            'JobMate:S.Ouchi 2014/01/20 ﾛｰﾀﾞﾊﾞｰｽ 同一車両№＆同時受付対応
            '↑↑↑↑↑↑************************************************************************************************************
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D"                                                     '出荷日
            strSQL &= vbCrLf & "   ,XPLN_OUT.XUNKOU_NO"                                                     '倉庫別運行№
            strSQL &= vbCrLf & "   ,XPLN_OUT.XHENSEI_NO"                                                    '編成№
            strSQL &= vbCrLf & "   ,XPLN_OUT.XDENPYOU_NO"                                                   '伝票№
            strSQL &= vbCrLf

            objPLN_OUT_ARY.USER_SQL = strSQL
            intRet = objPLN_OUT_ARY.GET_XPLN_OUT_USER()
            If intRet = RetCode.OK Then
                For Each objPLN_OUT As TBL_XPLN_OUT In objPLN_OUT_ARY.ARYME
                    '****************************************
                    '積込完了
                    '****************************************
                    Call TumikomiKanryou(objPLN_OUT.XBERTH_NO _
                                       , objPLN_OUT.XSYUKKA_D _
                                       , objPLN_OUT.XHENSEI_NO_OYA _
                                       )
                    Exit For
                Next


                Return RetCode.OK
            End If


        End If


        Return RetCode.OK
    End Function
#End Region
#Region "  読込_ｶｰﾄﾞﾘｰﾀﾞ読込(応答電文送信)                                                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' 読込_ｶｰﾄﾞﾘｰﾀﾞ読込(応答電文送信)
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">搬送制御受信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function CARTelRecvJR_CARD_SendRetTel(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV) As RetCode
        Try

            'Dim intRet As RetCode                   '戻り値


            '**************************************************
            '初期設定
            '**************************************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)
            Dim strAryRecvText() As String = Split(objTLIF_TRNS_RECV.FDENBUN, "_")    '受信電文
            Dim strSendText As String = ""                              '送信電文


            '**************************************************
            '応答ﾌﾗｸﾞ               作成
            '**************************************************
            Dim strRetFlag As String = ""
            Select Case objTLIF_TRNS_RECV.FDENBUN_PRM2
                Case "01", "02", "04", "08", "10", "20", "40", "80"
                    '(入構時)
                    '(接車時)
                    '(出構時)

                    strRetFlag = MakeReturnTelegramRetFlag(objTLIF_TRNS_RECV)

                Case Else
                    '(その他の場合)

                    Return ""

            End Select


            '**************************************************
            '車輌ｺﾝﾄﾛｰﾗ   ｶｰﾄﾞﾘｰﾀﾞ読込応答
            '**************************************************
            'strSendText = objTPRG_SYS_HEN.SJ000000_031
            'strSendText &= "_" & "00"       '??
            'strSendText &= "_" & "00"       '??
            strSendText = "f1"              '制御ｺｰﾄﾞ
            strSendText &= "_" & "f0"       '制御ｺｰﾄﾞ
            strSendText &= "_" & strAryRecvText(2)        'ｶｰﾄﾞ交換機区分
            strSendText &= "_" & strAryRecvText(3)        'ｶｰﾄﾞ交換機区分
            strSendText &= "_" & strAryRecvText(4)        'ｶｰﾄﾞﾘｰﾀﾞ区分
            strSendText &= "_" & strAryRecvText(5)        'ｶｰﾄﾞﾘｰﾀﾞ区分
            strSendText &= strRetFlag                     '応答ﾌﾗｸﾞ
            For ii As Integer = 1 To 56 : strSendText &= "_" & "40" : Next      '予備
            'strSendText &= "_" & "c6"       'BCC??
            'strSendText &= "_" & "83"       'BCC??


            '**************************************************
            '車輌ｺﾝﾄﾛｰﾗ   ｶｰﾄﾞﾘｰﾀﾞ読込応答
            '**************************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            objSVR_190001.SendCar_IDJS_CARD01(strSendText)


            '**************************************************
            'ｶｰﾄﾞﾘｰﾀﾞ読取完了ﾋﾞｯﾄ           ON
            '**************************************************
            If strRetFlag <> "_c5_c5" Then
                '(ｴﾗｰ以外の場合)
                Select Case objTLIF_TRNS_RECV.FDENBUN_PRM2
                    Case "01" : Call objSVR_190001.SendCar_IDJS_CARD02()
                    Case "04" : Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_15, FTEXT_ID_JW_ETC, FLAG_ON) ': Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_15, FTEXT_ID_JW_ETC, FLAG_ON)
                    Case "08" : Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_14, FTEXT_ID_JW_ETC, FLAG_ON) ': Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_14, FTEXT_ID_JW_ETC, FLAG_ON)
                    Case "10" : Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_13, FTEXT_ID_JW_ETC, FLAG_ON) ': Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_13, FTEXT_ID_JW_ETC, FLAG_ON)
                    Case "20" : Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_12, FTEXT_ID_JW_ETC, FLAG_ON) ': Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_12, FTEXT_ID_JW_ETC, FLAG_ON)
                    Case "40" : Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_11, FTEXT_ID_JW_ETC, FLAG_ON) ': Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_11, FTEXT_ID_JW_ETC, FLAG_ON)
                    Case "80" : Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_10, FTEXT_ID_JW_ETC, FLAG_ON) ': Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_10, FTEXT_ID_JW_ETC, FLAG_ON)
                End Select
            End If


            Return RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG
        End Try
    End Function
#End Region
#Region "  読込_ｶｰﾄﾞﾘｰﾀﾞ読込(応答電文送信)(ｻﾌﾞ関数)                                             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 読込_ｶｰﾄﾞﾘｰﾀﾞ読込(応答電文送信)(ｻﾌﾞ関数)
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">搬送制御受信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <returns>応答ﾌﾗｸﾞ</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function MakeReturnTelegramRetFlag(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV) As String
        Dim intRet As RetCode
        Dim strMsg As String = ""       'ﾒｯｾｰｼﾞ



        '**************************************************
        '初期設定
        '**************************************************
        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)
        Dim strRetFlag As String = "_c5_c5"         '応答ﾌﾗｸﾞ


        '**************************************************
        '車輌ﾏｽﾀ                取得
        '**************************************************
        Dim objMST_SYARYOU As New TBL_XMST_SYARYOU(Owner, ObjDb, ObjDbLog)
        objMST_SYARYOU.XCARD_NO = objTLIF_TRNS_RECV.FDENBUN_PRM1           'ｶｰﾄﾞ№
        intRet = objMST_SYARYOU.GET_XMST_SYARYOU(False)     '取得
        If intRet = RetCode.OK Then
            '(見つかった場合)

            If TO_INTEGER(objMST_SYARYOU.XLOADER_POSSIBLE) = FLAG_ON Then
                '(ﾛｰﾀﾞ対応の場合)


                '**************************************************
                '入構処理(未入構ﾃﾞｰﾀ有り)
                '**************************************************
                Dim strSQL As String                'SQL文
                Dim objAryXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2014/01/20 ﾛｰﾀﾞﾊﾞｰｽ 同一車両№＆同時受付対応
                '' ''strSQL = ""
                '' ''strSQL &= vbCrLf & "SELECT"
                '' ''strSQL &= vbCrLf & "    *"
                '' ''strSQL &= vbCrLf & " FROM"
                '' ''strSQL &= vbCrLf & "    XPLN_OUT"       '出荷指示詳細
                '' ''strSQL &= vbCrLf & " WHERE"
                '' ''strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '車輌番号
                '' ''strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS <= " & TO_STRING(XSYUKKA_STS_JOUT)             '出荷状況(出庫済)
                '' ''strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS >= " & TO_STRING(XSYUKKA_STS_JNON)             '出荷状況(受付済)
                '' ''strSQL &= vbCrLf & " ORDER BY"
                '' ''strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D"                                                     '出荷日
                '' ''strSQL &= vbCrLf & "   ,XPLN_OUT.XUNKOU_NO"                                                     '倉庫別運行№
                '' ''strSQL &= vbCrLf & "   ,XPLN_OUT.XHENSEI_NO"                                                    '編成№
                '' ''strSQL &= vbCrLf & "   ,XPLN_OUT.XDENPYOU_NO"                                                   '伝票№
                '' ''strSQL &= vbCrLf
                strSQL = ""
                strSQL &= vbCrLf & "SELECT"
                strSQL &= vbCrLf & "    *"
                strSQL &= vbCrLf & " FROM"
                strSQL &= vbCrLf & "    XPLN_OUT"       '出荷指示詳細
                strSQL &= vbCrLf & " WHERE"
                If objTLIF_TRNS_RECV.FDENBUN_PRM2 = "01" Then
                    strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '車輌番号
                    strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS <= " & TO_STRING(XSYUKKA_STS_JOUT)             '出荷状況(出庫済)
                    strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS >= " & TO_STRING(XSYUKKA_STS_JNON)             '出荷状況(受付済)
                    strSQL &= vbCrLf & "    AND(XPLN_OUT.XBERTH_NO IS NULL"
                    strSQL &= vbCrLf & "     OR XPLN_OUT.XBERTH_NO IN ('" & XBERTH_NO_JX01 & "'," & _
                                                                      "'" & XBERTH_NO_JX02 & "'," & _
                                                                      "'" & XBERTH_NO_JX03 & "'," & _
                                                                      "'" & XBERTH_NO_JX04 & "'," & _
                                                                      "'" & XBERTH_NO_JX05 & "'," & _
                                                                      "'" & XBERTH_NO_JX06 & "'))"                  'ﾊﾞｰｽ№(ﾛｰﾀﾞﾊﾞｰｽ)
                Else
                    strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '車輌番号
                    strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS <= " & TO_STRING(XSYUKKA_STS_JOUT)             '出荷状況(出庫済)
                    strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS >= " & TO_STRING(XSYUKKA_STS_JNON)             '出荷状況(受付済)
                    strSQL &= vbCrLf & "    AND XPLN_OUT.XBERTH_NO IN ('" & XBERTH_NO_JX01 & "'," & _
                                                                      "'" & XBERTH_NO_JX02 & "'," & _
                                                                      "'" & XBERTH_NO_JX03 & "'," & _
                                                                      "'" & XBERTH_NO_JX04 & "'," & _
                                                                      "'" & XBERTH_NO_JX05 & "'," & _
                                                                      "'" & XBERTH_NO_JX06 & "')"                   'ﾊﾞｰｽ№(ﾛｰﾀﾞﾊﾞｰｽ)
                End If
                strSQL &= vbCrLf & " ORDER BY"
                strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D"                                                     '出荷日
                strSQL &= vbCrLf & "   ,XPLN_OUT.XUNKOU_NO"                                                     '倉庫別運行№
                strSQL &= vbCrLf & "   ,XPLN_OUT.XHENSEI_NO"                                                    '編成№
                strSQL &= vbCrLf & "   ,XPLN_OUT.XDENPYOU_NO"                                                   '伝票№
                strSQL &= vbCrLf
                'JobMate:S.Ouchi 2014/01/20 ﾛｰﾀﾞﾊﾞｰｽ 同一車両№＆同時受付対応
                '↑↑↑↑↑↑************************************************************************************************************
                objAryXPLN_OUT.USER_SQL = strSQL
                intRet = objAryXPLN_OUT.GET_XPLN_OUT_USER()
                If intRet = RetCode.OK Then
                    '(見つかった場合)


                    Select Case objTLIF_TRNS_RECV.FDENBUN_PRM2
                        Case "01"
                            '**************************************************
                            '(入構時)
                            '**************************************************
                            If XSYUKKA_STS_JNON = objAryXPLN_OUT.ARYME(0).XSYUKKA_STS Then
                                '(入構前の場合)
                                strRetFlag = "_f0_f1"
                            Else
                                '(入構前じゃない場合)
                                strMsg = "入構不可の進捗の為、入構出来ません。[ｶｰﾄﾞ№:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "][ﾊﾞｰｽ№:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][ｶｰﾄﾞﾘｰﾀﾞ区分:" & objTLIF_TRNS_RECV.FDENBUN_PRM2 & "][出荷状況:" & TO_STRING(objAryXPLN_OUT.ARYME(0).XSYUKKA_STS) & "]"
                            End If


                        Case "02"
                            '**************************************************
                            '(出構時)
                            '**************************************************
                            If XSYUKKA_STS_JREQ <= objAryXPLN_OUT.ARYME(0).XSYUKKA_STS And objAryXPLN_OUT.ARYME(0).XSYUKKA_STS <= XSYUKKA_STS_JOUT Then
                                '(出構前の場合)
                                strRetFlag = "_f0_f4"
                            Else
                                '(出構前じゃない場合)
                                strMsg = "出構不可の進捗の為、出構出来ません。[ｶｰﾄﾞ№:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "][ﾊﾞｰｽ№:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][ｶｰﾄﾞﾘｰﾀﾞ区分:" & objTLIF_TRNS_RECV.FDENBUN_PRM2 & "][出荷状況:" & TO_STRING(objAryXPLN_OUT.ARYME(0).XSYUKKA_STS) & "]"
                            End If


                        Case "04", "08", "10", "20", "40", "80"
                            '**************************************************
                            '(接車時)
                            '**************************************************
                            '**************************************************
                            'ﾊﾞｰｽの特定
                            '**************************************************
                            Dim strXBERTH_NO As String = ""
                            Select Case objTLIF_TRNS_RECV.FDENBUN_PRM2
                                Case "04" : strXBERTH_NO = XBERTH_NO_JX01
                                Case "08" : strXBERTH_NO = XBERTH_NO_JX02
                                Case "10" : strXBERTH_NO = XBERTH_NO_JX03
                                Case "20" : strXBERTH_NO = XBERTH_NO_JX04
                                Case "40" : strXBERTH_NO = XBERTH_NO_JX05
                                Case "80" : strXBERTH_NO = XBERTH_NO_JX06
                            End Select


                            If objAryXPLN_OUT.ARYME(0).XBERTH_NO = strXBERTH_NO Then
                                '(ﾊﾞｰｽ№が一致している場合)
                                If XSYUKKA_STS_JREQ <= objAryXPLN_OUT.ARYME(0).XSYUKKA_STS And objAryXPLN_OUT.ARYME(0).XSYUKKA_STS <= XSYUKKA_STS_JOUT Then
                                    '(正常の場合)
                                    strRetFlag = "_f0_f5"
                                Else
                                    '(異常の場合)
                                    strMsg = "接車不可の進捗の為、接車出来ません。[ｶｰﾄﾞ№:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "][ﾊﾞｰｽ№:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][ｶｰﾄﾞﾘｰﾀﾞ区分:" & objTLIF_TRNS_RECV.FDENBUN_PRM2 & "][出荷状況:" & TO_STRING(objAryXPLN_OUT.ARYME(0).XSYUKKA_STS) & "]"
                                End If
                            Else
                                '(ﾊﾞｰｽ№が一致していない場合)
                                strMsg = "ﾊﾞｰｽ№が一致していません。[ｶｰﾄﾞ№:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "][ﾊﾞｰｽ№:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][ｶｰﾄﾞﾘｰﾀﾞ区分:" & objTLIF_TRNS_RECV.FDENBUN_PRM2 & "]"
                            End If


                    End Select


                Else
                    '(見つからなかった場合)
                    strMsg = "出荷指示が存在しません。[ｶｰﾄﾞ№:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "]"
                End If


            Else
                '(ﾛｰﾀﾞ未対応の場合)
                strMsg = "ﾛｰﾀﾞに対応していない車輌受付が行われました。[ｶｰﾄﾞ№:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "]"
            End If


        Else
            '(見つからない場合)
            strMsg = "車輌ﾏｽﾀが見つかりません。[ｶｰﾄﾞ№:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "]"
        End If
        If IsNotNull(strMsg) Then
            Call AddToMsgLog(Now, FMSG_ID_J5003, strMsg)
        End If


        '**************************************************
        '送信電文               設定
        '**************************************************
        Return strRetFlag


    End Function
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/15 CW6追加対応 ↓↓↓↓↓↓
#Region "  CW6関連設備状態更新検知処理                                                          "
    ''' <summary>
    ''' CW6関連設備状態更新検知処理
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">搬送制御受信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    Private Sub CW6_Status_Change(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV, ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Try
            Dim intRet As RetCode
            Dim objXMST_DPL_PL As New TBL_XMST_DPL_PL(Owner, ObjDb, ObjDbLog)

            '************************************************************************
            '起動状態設定
            '************************************************************************
            '************************************************
            '起動ANS(D5514[Bit00]～) 設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_KIDO = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '起動ANS(D5514[Bit00]～) 状態変化処理(起動状態設定)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.KidouStatusCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            'ｵﾝﾗｲﾝANS(D5514[Bit01]～) 設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_ONLN = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                'ｵﾝﾗｲﾝANS(D5514[Bit01]～) 状態変化処理(起動状態設定)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.KidouStatusCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            'ｵﾌﾗｲﾝANS(D5514[Bit02]～) 設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_OFLN = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                'ｵﾌﾗｲﾝANS(D5514[Bit02]～) 状態変化処理(起動状態設定)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.KidouStatusCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '積付ﾊﾟﾀｰﾝ設定一致(D5514[Bit05]～) 設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_PLPT = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '積付ﾊﾟﾀｰﾝ設定一致(D5514[Bit05]～) 状態変化処理(起動状態設定)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.KidouStatusCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '起動可能(D5514[Bit06]～) 設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_REDY = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '起動可能(D5514[Bit06]～) 状態変化処理(起動状態設定)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.KidouStatusCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '終了要求(D5514[Bit07]～) 設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_SYRY = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '終了要求(D5514[Bit07]～) 状態変化処理(起動状態設定)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.KidouStatusCheck(objXMST_DPL_PL)

                Exit Sub
            End If



            '************************************************************************
            'ｸﾘｱ判定処理
            '************************************************************************
            '************************************************
            'ﾃﾞｰﾀｸﾘｱ(D5500[Bit03]～)    設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_STCL = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                'ﾃﾞｰﾀｸﾘｱ(D5500[Bit03]～) 状態変化処理(ｸﾘｱ判定処理)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '生産ﾊﾟﾚｯﾄ数(D5063～)       設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_PL = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '生産ﾊﾟﾚｯﾄ数(D5063～) 状態変化処理(ｸﾘｱ判定処理)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '端数ﾃﾞｰﾀ(D5064～)       設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_HASU = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '端数ﾃﾞｰﾀ(D5064～) 状態変化処理(ｸﾘｱ判定処理)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            'ﾄﾗﾌﾞﾙ時間(時)(D5065～) 設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_TRBL_HH = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                'ﾄﾗﾌﾞﾙ時間(時)(D5065～) 状態変化処理(ｸﾘｱ判定処理)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            'ﾄﾗﾌﾞﾙ時間(分)(D5066～) 設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_TRBL_MM = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                'ﾄﾗﾌﾞﾙ時間(分)(D5066～) 状態変化処理(ｸﾘｱ判定処理)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            'ﾄﾗﾌﾞﾙ時間(秒)(D5067～) 設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_TRBL_SS = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                'ﾄﾗﾌﾞﾙ時間(秒)(D5067～) 状態変化処理(ｸﾘｱ判定処理)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            'ﾄﾗﾌﾞﾙ件数(D5068～) 設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_TRBL = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                'ﾄﾗﾌﾞﾙ件数(D5068～) 状態変化処理(ｸﾘｱ判定処理)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '積付数(D5069～) 設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_COUNT = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '積付数(D5069～) 状態変化処理(ｸﾘｱ判定処理)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '運転時間(時)(D5201～) 設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_KADOU_HH = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '運転時間(時)(D5201～) 状態変化処理(ｸﾘｱ判定処理)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '運転時間(分)(D5202～) 設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_KADOU_MM = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '運転時間(分)(D5202～) 状態変化処理(ｸﾘｱ判定処理)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '運転時間(秒)(D5203～) 設備ID判定
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_KADOU_SS = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '運転時間(秒)(D5203～) 状態変化処理(ｸﾘｱ判定処理)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
    'JobMate:S.Ouchi 2015/07/15 CW6追加対応 ↑↑↑↑↑↑
    '↑↑↑↑↑↑************************************************************************************************************

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************



End Class
