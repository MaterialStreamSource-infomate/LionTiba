'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】搬送設備送信読込処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_020151
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
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
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Dim ii As Integer                       'ｶｳﾝﾀ
        Try
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 'ｼｽﾃﾑ変数


            '************************
            '搬送制御送信IF読込み
            '************************
            Dim strENTRY_NO(0) As String        '登録No
            Dim strEQ_ID(0) As String           '設備ID
            intRet = Get_TrnsSend(strENTRY_NO, strEQ_ID)
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                Return RetCode.OK
            End If


            ''************************
            ''初期処理
            ''************************
            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            For ii = LBound(strENTRY_NO) + 1 To UBound(strENTRY_NO)
                '(ﾙｰﾌﾟ:未処理指示)

                '************************
                '搬送制御送信IFの特定
                '************************
                Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '搬送制御受信IFｸﾗｽ
                objTLIF_TRNS_SEND.FENTRY_NO = strENTRY_NO(ii)                           '登録No
                objTLIF_TRNS_SEND.FEQ_ID = strEQ_ID(ii)                                 '設備ID
                intRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND(True)                     '特定

                Try


                    '******************************
                    '応答受信による分岐処理
                    '******************************
                    Select Case objTLIF_TRNS_SEND.FCOMMAND_ID
                        Case FCOMMAND_ID_SONLINE
                            '(ｵﾝﾗｲﾝ要求)
                            AddToLog("■受付:ｵﾝﾗｲﾝ要求応答受信", "", LogType.INFO)
                            If TO_INTEGER(objTLIF_TRNS_SEND.FRES_CD_EQ) = 0 Then
                                '(正常応答の場合)
                                Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL, objTLIF_TRNS_SEND.FEQ_ID)
                                objTSTS_EQ_CTRL.FEQ_CUT_STS = FEQ_CUT_STS_SOFF          '切離状態
                                objTSTS_EQ_CTRL.FUPDATE_DT = Now                        '更新日時
                                objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()                   '更新
                            End If
                        Case FCOMMAND_ID_SOFFLINE
                            '(ｵﾌﾗｲﾝ要求)
                            If TO_INTEGER(objTLIF_TRNS_SEND.FRES_CD_EQ) = 0 Then
                                '(正常応答の場合)
                                AddToLog("■受付:ｵﾌﾗｲﾝ要求応答受信", "", LogType.INFO)
                                Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL, objTLIF_TRNS_SEND.FEQ_ID)
                                objTSTS_EQ_CTRL.FEQ_CUT_STS = FEQ_CUT_STS_SON           '切離状態
                                objTSTS_EQ_CTRL.FUPDATE_DT = Now                        '更新日時
                                objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()                   '更新
                            End If

                        Case Else

                            Select Case objTLIF_TRNS_SEND.FEQ_ID
                                Case FEQ_ID_JSYS0000
                                Case FEQ_ID_JSYS0001
                                Case FEQ_ID_JSYS0002
                                Case FEQ_ID_JSYS0003
                                Case FEQ_ID_JSYS0004
                                Case FEQ_ID_JSYS0005
                                Case FEQ_ID_JSYS0006
                            End Select


                    End Select


                    '******************************
                    '応答ｺｰﾄﾞﾁｪｯｸ
                    '******************************
                    Dim objTMST_RES_CD_EQ As New TBL_TMST_RES_CD_EQ(Owner, ObjDb, ObjDbLog)     '応答ｺｰﾄﾞ処理ﾏｽﾀｸﾗｽ
                    objTMST_RES_CD_EQ.FEQ_ID = objTLIF_TRNS_SEND.FEQ_ID                         '設備ID
                    objTMST_RES_CD_EQ.FDIRECTION = FDIRECTION_SSEND                             '方向
                    If IsNull(objTLIF_TRNS_SEND.FRES_CD_EQ) = True Then
                        objTMST_RES_CD_EQ.FRES_CD_EQ = FRES_CD_EQ_SMCI_OK                       '設備応答ｺｰﾄﾞ
                    Else
                        objTMST_RES_CD_EQ.FRES_CD_EQ = objTLIF_TRNS_SEND.FRES_CD_EQ             '設備応答ｺｰﾄﾞ
                    End If
                    intRet = objTMST_RES_CD_EQ.GET_TMST_RES_CD_EQ(False)
                    If intRet = RetCode.OK Then
                        '(見つかった場合)

                        '========================
                        'ﾒｯｾｰｼﾞ出力
                        '========================
                        If TO_INTEGER(objTMST_RES_CD_EQ.FMSG_FLAG) = FLAG_ON Then
                            '(ﾒｯｾｰｼﾞﾛｸﾞ出力ﾌﾗｸﾞがONの場合)
                            Select Case objTLIF_TRNS_SEND.FEQ_ID
                                Case FEQ_ID_JSYS0000 : Call AddToMsgLog(Now, FMSG_ID_J6003, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "応答ｺｰﾄﾞ(ﾏﾃｽﾄ→MELSEC):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0001 : Call AddToMsgLog(Now, FMSG_ID_J6103, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "応答ｺｰﾄﾞ(ﾏﾃｽﾄ→SW01  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0002 : Call AddToMsgLog(Now, FMSG_ID_J6203, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "応答ｺｰﾄﾞ(ﾏﾃｽﾄ→SW02  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0003 : Call AddToMsgLog(Now, FMSG_ID_J6303, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "応答ｺｰﾄﾞ(ﾏﾃｽﾄ→SW03  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0004 : Call AddToMsgLog(Now, FMSG_ID_J6403, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "応答ｺｰﾄﾞ(ﾏﾃｽﾄ→SW04  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0005 : Call AddToMsgLog(Now, FMSG_ID_J6503, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "応答ｺｰﾄﾞ(ﾏﾃｽﾄ→SW05  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0006 : Call AddToMsgLog(Now, FMSG_ID_J6603, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "応答ｺｰﾄﾞ(ﾏﾃｽﾄ→SW04A ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
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
                            objTSTS_EQ_CTRL.FEQ_ID = objTLIF_TRNS_SEND.FEQ_ID                       '設備ID
                            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)          '特定
                            objTSTS_EQ_CTRL.FEQ_CUT_STS = FLAG_ON           '切離状態
                            objTSTS_EQ_CTRL.FUPDATE_DT = Now                '更新日時
                            objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()           '更新

                            '========================
                            '搬送制御送信IFの更新
                            '========================
                            objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_STRY    '進捗状態
                            objTLIF_TRNS_SEND.FRES_CD_EQ = DEFAULT_STRING   '設備応答ｺｰﾄﾞ
                            objTLIF_TRNS_SEND.FUPDATE_DT = Now              '更新日時
                            objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()       '更新

                        End If


                    Else
                        '(見つからなかった場合)

                        '========================
                        'ﾒｯｾｰｼﾞ出力
                        '========================
                        Select Case objTLIF_TRNS_SEND.FEQ_ID
                            '↓↓↓↓↓↓************************************************************************************************************
                            'SystemMate:N.Dounoshita 2011/11/22 ﾒｯｾｰｼﾞを変更
                            Case FEQ_ID_JSYS0000 : Call AddToMsgLog(Now, FMSG_ID_J6003, "異常応答ｺｰﾄﾞ送信。", "応答ｺｰﾄﾞ(ﾏﾃｽﾄ→MELSEC):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0001 : Call AddToMsgLog(Now, FMSG_ID_J6103, "異常応答ｺｰﾄﾞ送信。", "応答ｺｰﾄﾞ(ﾏﾃｽﾄ→SW01  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0002 : Call AddToMsgLog(Now, FMSG_ID_J6203, "異常応答ｺｰﾄﾞ送信。", "応答ｺｰﾄﾞ(ﾏﾃｽﾄ→SW02  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0003 : Call AddToMsgLog(Now, FMSG_ID_J6303, "異常応答ｺｰﾄﾞ送信。", "応答ｺｰﾄﾞ(ﾏﾃｽﾄ→SW03  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0004 : Call AddToMsgLog(Now, FMSG_ID_J6403, "異常応答ｺｰﾄﾞ送信。", "応答ｺｰﾄﾞ(ﾏﾃｽﾄ→SW04  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0005 : Call AddToMsgLog(Now, FMSG_ID_J6503, "異常応答ｺｰﾄﾞ送信。", "応答ｺｰﾄﾞ(ﾏﾃｽﾄ→SW05  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0006 : Call AddToMsgLog(Now, FMSG_ID_J6603, "異常応答ｺｰﾄﾞ送信。", "応答ｺｰﾄﾞ(ﾏﾃｽﾄ→SW04A ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                'Case FEQ_ID_SYS0001 : Call AddToMsgLog(Now, FMSG_ID_J6103, "不明な応答ｺｰﾄﾞを受信しました。", "応答ｺｰﾄﾞ:" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                'Case FEQ_ID_SYS0002 : Call AddToMsgLog(Now, FMSG_ID_J6203, "不明な応答ｺｰﾄﾞを受信しました。", "応答ｺｰﾄﾞ:" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                'Case FEQ_ID_SYS0003 : Call AddToMsgLog(Now, FMSG_ID_J6303, "不明な応答ｺｰﾄﾞを受信しました。", "応答ｺｰﾄﾞ:" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                '↑↑↑↑↑↑************************************************************************************************************
                        End Select


                        '↓↓↓↓↓↓************************************************************************************************************
                        'SystemMate:N.Dounoshita 2012/05/24  応答ｺｰﾄﾞが異常の時は、「応答ｺｰﾄﾞ不明時ｵﾌﾗｲﾝ切替ﾌﾗｸﾞ」の判定が行われるように修正

                        If TO_DECIMAL(objTPRG_SYS_HEN.SS000000_020) = FLAG_ON Then

                            '========================
                            '設備状況の更新
                            '========================
                            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     '設備状況ｸﾗｽ
                            objTSTS_EQ_CTRL.FEQ_ID = objTLIF_TRNS_SEND.FEQ_ID                       '設備ID
                            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                                      '特定
                            objTSTS_EQ_CTRL.FEQ_CUT_STS = FLAG_ON           '切離状態
                            objTSTS_EQ_CTRL.FUPDATE_DT = Now                '更新日時
                            objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()           '更新

                        End If

                        '↑↑↑↑↑↑************************************************************************************************************


                        '========================
                        '搬送制御送信IFの更新
                        '========================
                        objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_STRY     '進捗状態
                        objTLIF_TRNS_SEND.FRES_CD_EQ = DEFAULT_STRING   '設備応答ｺｰﾄﾞ
                        objTLIF_TRNS_SEND.FUPDATE_DT = Now              '更新日時
                        objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()       '更新


                    End If


                    '========================
                    '設備切離
                    '========================
                    If TO_INTEGER(objTLIF_TRNS_SEND.FPROGRESS) = FPROGRESS_STIMEOUT Or _
                       TO_INTEGER(objTLIF_TRNS_SEND.FPROGRESS) = FPROGRESS_SERR_MCI Or _
                       TO_INTEGER(objTLIF_TRNS_SEND.FPROGRESS) = FPROGRESS_SERR_SVR _
                       Then
                        '(通信異常の場合)

                        Select Case objTLIF_TRNS_SEND.FEQ_ID
                            Case FEQ_ID_JSYS0000 : Call AddToMsgLog(Now, FMSG_ID_J6003, "通信ﾌﾟﾛｸﾞﾗﾑ、もしくはｻｰﾊﾞﾌﾟﾛｾｽでｴﾗｰが発生しました。")
                            Case FEQ_ID_JSYS0001 : Call AddToMsgLog(Now, FMSG_ID_J6103, "通信ﾌﾟﾛｸﾞﾗﾑ、もしくはｻｰﾊﾞﾌﾟﾛｾｽでｴﾗｰが発生しました。")
                            Case FEQ_ID_JSYS0002 : Call AddToMsgLog(Now, FMSG_ID_J6203, "通信ﾌﾟﾛｸﾞﾗﾑ、もしくはｻｰﾊﾞﾌﾟﾛｾｽでｴﾗｰが発生しました。")
                            Case FEQ_ID_JSYS0003 : Call AddToMsgLog(Now, FMSG_ID_J6303, "通信ﾌﾟﾛｸﾞﾗﾑ、もしくはｻｰﾊﾞﾌﾟﾛｾｽでｴﾗｰが発生しました。")
                            Case FEQ_ID_JSYS0004 : Call AddToMsgLog(Now, FMSG_ID_J6403, "通信ﾌﾟﾛｸﾞﾗﾑ、もしくはｻｰﾊﾞﾌﾟﾛｾｽでｴﾗｰが発生しました。")
                            Case FEQ_ID_JSYS0005 : Call AddToMsgLog(Now, FMSG_ID_J6503, "通信ﾌﾟﾛｸﾞﾗﾑ、もしくはｻｰﾊﾞﾌﾟﾛｾｽでｴﾗｰが発生しました。")
                            Case FEQ_ID_JSYS0006 : Call AddToMsgLog(Now, FMSG_ID_J6603, "通信ﾌﾟﾛｸﾞﾗﾑ、もしくはｻｰﾊﾞﾌﾟﾛｾｽでｴﾗｰが発生しました。")
                        End Select


                        If TO_DECIMAL(objTPRG_SYS_HEN.SS000000_016) = FLAG_ON Then

                            '========================
                            '設備状況の更新
                            '========================
                            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     '設備状況ｸﾗｽ
                            objTSTS_EQ_CTRL.FEQ_ID = objTLIF_TRNS_SEND.FEQ_ID                       '設備ID
                            intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)                         '特定
                            objTSTS_EQ_CTRL.FEQ_CUT_STS = FLAG_ON           '切離状態
                            objTSTS_EQ_CTRL.FUPDATE_DT = Now                '更新日時
                            objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()           '更新

                        End If

                        If TO_DECIMAL(objTPRG_SYS_HEN.SS000000_017) <> FLAG_ON Then
                            '========================
                            '搬送制御送信IFの更新
                            '========================
                            objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_STRY     '進捗状態
                            objTLIF_TRNS_SEND.FRES_CD_EQ = DEFAULT_STRING   '設備応答ｺｰﾄﾞ
                            objTLIF_TRNS_SEND.FUPDATE_DT = Now              '更新日時
                            objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()       '更新
                        End If

                    End If


                    '************************
                    '搬送制御送信IFの削除
                    '************************
                    If TO_INTEGER(objTLIF_TRNS_SEND.FPROGRESS) <> FPROGRESS_STRY Then
                        '(進捗状態が再送信待ちになっていない場合)
                        objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND()       '削除
                    End If


                Catch ex As UserException
                    Call ComUser(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                    ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SERR_SVR     '進捗状態(異常)
                    objTLIF_TRNS_SEND.FUPDATE_DT = Now                  '更新日時
                    objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()           '更新
                Catch ex As Exception
                    Call ComError(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                    ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SERR_SVR     '進捗状態(異常)
                    objTLIF_TRNS_SEND.FUPDATE_DT = Now                  '更新日時
                    objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()           '更新
                Finally
                    ObjDb.Commit()      'ｺﾐｯﾄ
                    ObjDb.BeginTrans()  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                End Try
            Next


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
#Region "  搬送制御送信IF読込み                                                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 搬送制御送信IF読込み
    ''' </summary>
    ''' <param name="strEntry_no">登録No(配列)</param>
    ''' <param name="strEQ_ID">登録No(配列)</param>
    ''' <returns>OK/NotFound</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Get_TrnsSend(ByRef strEntry_no() As String, ByRef strEQ_ID() As String) As RetCode
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
            strSQL &= vbCrLf & "    FENTRY_NO"                  '登録No
            strSQL &= vbCrLf & "  , FEQ_ID"                     '設備ID
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TLIF_TRNS_SEND "            '搬送制御送信IF
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FPROGRESS <> " & FPROGRESS_SNON      '進捗状態
            strSQL &= vbCrLf & "    AND FPROGRESS <> " & FPROGRESS_SACT      '進捗状態
            strSQL &= vbCrLf & "    AND FPROGRESS <> " & FPROGRESS_STRY      '進捗状態
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    FENTRY_NO"                  '登録No
            strSQL &= vbCrLf


            '************************
            '抽出
            '************************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TLIF_TRNS_SEND"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For ii = 1 To objDataSet.Tables(strDataSetName).Rows.Count
                    objRow = objDataSet.Tables(strDataSetName).Rows(ii - 1)
                    ReDim Preserve strEntry_no(ii)
                    strEntry_no(ii) = TO_STRING(objRow("FENTRY_NO"))    '登録No
                    ReDim Preserve strEQ_ID(ii)
                    strEQ_ID(ii) = TO_STRING(objRow("FEQ_ID"))          '設備ID
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

    'MCV
#Region "  MCV電文送信処理  [ID:B7      (入出庫ﾓｰﾄﾞ切替指示)]                                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' MCV電文送信処理  [ID:B7      (入出庫ﾓｰﾄﾞ切替指示)]
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">搬送制御送信IFﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function MCVTelRecvB7(ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND) As RetCode
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '************************
            '初期処理
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART & "[MCV][入出庫ﾓｰﾄﾞ切替指示]  [送信電文:" & objTLIF_TRNS_SEND.FDENBUN & "]")


            '*****************************************************
            '受信電文分解
            '*****************************************************
            Dim objTel As New clsTelegram(CONFIG_TELEGRAM_MCV)
            objTel.FORMAT_ID = FORMAT_MCV_B7                        'ﾌｫｰﾏｯﾄ名ｾｯﾄ
            objTel.TELEGRAM_PARTITION = objTLIF_TRNS_SEND.FDENBUN   '分割する電文ｾｯﾄ
            objTel.PARTITION()                                      '電文分割
            Dim strMCVPOINT_NO As String = Trim(objTel.SELECT_DATA("MCVPOINT_NO"))          'ﾎﾟｲﾝﾄ№
            Dim strMCVMODE_SIZI As String = Trim(objTel.SELECT_DATA("MCVMODE_SIZI"))        'ﾓｰﾄﾞ指示


            '*****************************************************
            '設備状況       取得
            '*****************************************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID_LOCAL = strMCVPOINT_NO       'ﾛｰｶﾙ設備ID
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                  '取得


            '*****************************************************
            '要求ﾌﾗｸﾞ       更新
            '*****************************************************
            Call Set_FEQ_REQ_STS(objTSTS_EQ_CTRL.FEQ_ID, FEQ_REQ_STS_SOFF)                  '要求ﾌﾗｸﾞOFF


            '*****************************************************
            '設備応答ｺｰﾄﾞ   設定 
            '*****************************************************
            Call Set_XSTS_EQ_CTRL_DTL_FRES_CD_EQ(objTSTS_EQ_CTRL.FEQ_ID, objTLIF_TRNS_SEND.FRES_CD_EQ)      '設備状況詳細     設備応答ｺｰﾄﾞ設定 


            '************************
            '正常完了
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL)


            Return RetCode.OK
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
