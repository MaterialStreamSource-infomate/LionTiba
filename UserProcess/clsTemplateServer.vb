'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｻｰﾊﾞｰﾌﾟﾛｾｽ用ﾃﾝﾌﾟﾚｰﾄ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                                  "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon

Imports System.IO

#End Region

Public Class clsTemplateServer
    Inherits clsTemplate


#Region "  ｸﾗｽ内部処理用変数定義                                                                    "

    '処理名等
    Public MeSyoriID As String = Me.GetType.Name.ToString                                  '処理ID
    Public MeDSPID As String = FORMAT_DSP_PRI & Replace(MeSyoriID, FORMAT_DSP_DELCMD, "")  'ｿｹｯﾄID

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0         '端末ID
    Private Const DSPUSER_ID As Integer = 1         'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2          '理由

    Private Const DSPTRK_BUF_NO As Integer = 3      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№


#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                                  "
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
        MyBase.new(objOwner, objDb, objDbLog)   '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  ｺﾏﾝﾄﾞ実行処理[実装はｻﾌﾞｸﾗｽ]                                                              "
    '**********************************************************************************************
    '【機能】
    '【引数】[IN] msgRecv       ：受信ﾒｯｾｰｼﾞ
    '　　　　[OUT]msgSend       ：返答ﾒｯｾｰｼﾞ
    '【戻値】0:OK 1:NG 2:NotFound
    '**********************************************************************************************
    ''' <summary>
    ''' ｺﾏﾝﾄﾞ実行処理(実装はｻﾌﾞｸﾗｽにて行う)
    ''' </summary>
    ''' <param name="msgRecv"></param>
    ''' <param name="msgSend"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function ExecCmd(ByVal msgRecv As String, ByRef msgSend As String) As RetCode

    End Function
#End Region
#Region "  ｺﾏﾝﾄﾞ実行処理[ﾄﾗﾝｻﾞｸｼｮﾝ処理付き]                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾏﾝﾄﾞ実行処理[ﾄﾗﾝｻﾞｸｼｮﾝ処理付き](実装はｻﾌﾞｸﾗｽにて行う)
    ''' </summary>
    ''' <param name="msgRecv">受信ﾒｯｾｰｼﾞ</param>
    ''' <param name="msgSend">返答ﾒｯｾｰｼﾞ</param>
    ''' <returns>0:OK 1:NG 2:NotFound</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Function ExecCmdTrans(ByVal msgRecv As String, ByRef msgSend As String) As Integer
        Dim rtn As Integer = RetCode.NG


        '************************
        'ﾄﾗﾝｻﾞｸｼｮﾝ開始
        '************************
        ObjDb.BeginTrans()

        Try
            rtn = ExecCmd(msgRecv, msgSend)

        Catch ex As Exception
            ComError(ex)
            Throw New System.Exception(ex.Message)

        Finally
            If rtn = RetCode.NG Then
                '(異常終了の場合)
                '************************
                'ﾛｰﾙﾊﾞｯｸ
                '************************
                ObjDb.RollBack()

            Else
                '(正常終了の場合)
                '************************
                'ｺﾐｯﾄ
                '************************
                Try
                    ObjDb.Commit()
                Catch ex As Exception
                    Throw New Exception("【ｺﾐｯﾄ失敗】" & ex.Message)
                End Try

            End If
        End Try

        Return rtn

    End Function
#End Region
#Region "  ｴﾗｰ時 共通ﾓｼﾞｭｰﾙ                                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ時 共通ﾓｼﾞｭｰﾙ
    ''' </summary>
    ''' <param name="e">例外の基本ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="strFunc"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub ComError(ByVal e As Exception, Optional ByVal strFunc As String = "")
        Try

            '***********************
            'ｼｽﾃﾑｴﾗｰ登録
            '***********************
            Dim st As StackTrace = New StackTrace(e, True)
            Dim strMsg As String = ""   'ﾒｯｾｰｼﾞ
            Dim strProd As String = ""
            strProd &= "Src="
            For ii As Integer = 0 To st.FrameCount - 1
                strProd &= "["
                strProd &= st.GetFrame(ii).GetFileName
                strProd &= "." & st.GetFrame(ii).GetFileLineNumber()
                strProd &= "]"
            Next

            If strFunc <> "" Then
                strFunc = " Fnc=[" & strFunc & "]"
            End If
            strMsg &= "Msg=[" & e.Message & "]"
            Call AddToLog(strMsg, strProd & strFunc, LogType.SERR)


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:Dou 2014/07/29 この箇所でﾃﾞｯﾄﾞﾛｯｸがかかっている疑いがかかったので、ｺﾒﾝﾄｱｳﾄ
            '                       ｺﾒﾝﾄｱｳﾄしたら、ｼｽﾃﾑｴﾗｰﾛｸﾞが出力されなくなったので、ｼｽﾃﾑｴﾗｰﾛｸﾞ追加処理を追加


            Dim strPROC_CD As String            '処理ｺｰﾄﾞ
            Dim strLOG_DATA As String           '異常内容

            '************************
            'Insert情報の初期化
            '************************
            Const LEN_PROC_CD As Integer = 1024              'ﾌｨｰﾙﾄﾞ文字数判定
            Const LEN_LOG_DATA As Integer = 1024             'ﾌｨｰﾙﾄﾞ文字数判定
            strPROC_CD = SQL_ITEM(strProd, LEN_PROC_CD)             '処理ｺｰﾄﾞ
            strLOG_DATA = SQL_ITEM(strMsg, LEN_LOG_DATA)            '異常内容


            '***********************
            'ｼｽﾃﾑｴﾗｰﾛｸﾞの登録
            '***********************
            Dim objTLOG_SYS As New UserProcess.TBL_TLOG_SYS(Owner, ObjDbLog, ObjDbLog)  'ｼｽﾃﾑｴﾗｰﾛｸﾞ
            objTLOG_SYS.FHASSEI_DT = Now                        '発生日時
            objTLOG_SYS.FPROC_CD = strPROC_CD                   '処理ｺｰﾄﾞ
            objTLOG_SYS.FLOG_DATA = strLOG_DATA                 '異常内容
            objTLOG_SYS.FLOG_KIND = TO_STRING(LogType.SERR)          'ﾛｸﾞ種別
            objTLOG_SYS.ADD_TLOG_SYS_SEQ()                      '登録


            '↑↑↑↑↑↑************************************************************************************************************


            '***********************
            '指示ﾌﾗｸﾞﾁｪｯｸ
            '***********************
            Dim strSQL As String            'SQL文
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim intDEBUG_FLAG As Integer    'ﾌﾗｸﾞ値
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_SYS_HEN"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FHENSU_ID = '" & TO_STRING(FHENSU_ID_SSS000000_004) & "'"
            strSQL &= vbCrLf
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_SYS_HEN"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                intDEBUG_FLAG = TO_INTEGER(objRow("FHENSU_INT"))                       '整数ﾃﾞｰﾀ
                If intDEBUG_FLAG = FLAG_ON Then
                    Call AddToMsgLog(Now, FMSG_ID_S9000, strProd, strMsg)
                End If
            End If


        Catch ex As UserException
            'NOP(Error 処理中の Error 回避)
        Catch ex As Exception
            'NOP(Error 処理中の Error 回避)
        End Try
    End Sub
#End Region
#Region "  ﾕｰｻﾞｰｴﾗｰ時 共通ﾓｼﾞｭｰﾙ                                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾕｰｻﾞｰｴﾗｰ時 共通ﾓｼﾞｭｰﾙ
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="strFunc"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub ComUser(ByVal e As UserException, Optional ByVal strFunc As String = "")
        Try

            '***********************
            '初期ﾁｪｯｸ
            '***********************
            If e.blnAddLog = False Then Exit Sub

            '***********************
            'ｼｽﾃﾑｴﾗｰ登録
            '***********************
            Dim st As StackTrace = New StackTrace(e, True)
            Dim strMsg As String = ""   'ﾒｯｾｰｼﾞ
            Dim strProd As String = ""
            strProd &= "Src="
            For ii As Integer = 0 To st.FrameCount - 1
                strProd &= "["
                strProd &= st.GetFrame(ii).GetFileName
                strProd &= "." & st.GetFrame(ii).GetFileLineNumber()
                strProd &= "]"
            Next

            If strFunc <> "" Then
                strFunc = " Fnc=[" & strFunc & "]"
            End If
            strMsg &= "Msg=[" & e.Message & "]"
            Call AddToLog(strMsg, strProd & strFunc, LogType.SERR)


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:Dou 2014/07/29 この箇所でﾃﾞｯﾄﾞﾛｯｸがかかっている疑いがかかったので、ｺﾒﾝﾄｱｳﾄ
            '                       ｺﾒﾝﾄｱｳﾄしたら、ｼｽﾃﾑｴﾗｰﾛｸﾞが出力されなくなったので、ｼｽﾃﾑｴﾗｰﾛｸﾞ追加処理を追加


            Dim strPROC_CD As String            '処理ｺｰﾄﾞ
            Dim strLOG_DATA As String           '異常内容

            '************************
            'Insert情報の初期化
            '************************
            Const LEN_PROC_CD As Integer = 1024              'ﾌｨｰﾙﾄﾞ文字数判定
            Const LEN_LOG_DATA As Integer = 1024             'ﾌｨｰﾙﾄﾞ文字数判定
            strPROC_CD = SQL_ITEM(strProd, LEN_PROC_CD)             '処理ｺｰﾄﾞ
            strLOG_DATA = SQL_ITEM(strMsg, LEN_LOG_DATA)            '異常内容



            '***********************
            'ｼｽﾃﾑｴﾗｰﾛｸﾞの登録
            '***********************
            Dim objTLOG_SYS As New UserProcess.TBL_TLOG_SYS(Owner, ObjDbLog, ObjDbLog)  'ｼｽﾃﾑｴﾗｰﾛｸﾞ
            objTLOG_SYS.FHASSEI_DT = Now                        '発生日時
            objTLOG_SYS.FPROC_CD = strPROC_CD                   '処理ｺｰﾄﾞ
            objTLOG_SYS.FLOG_DATA = strLOG_DATA                 '異常内容
            objTLOG_SYS.FLOG_KIND = TO_STRING(LogType.SERR)          'ﾛｸﾞ種別
            objTLOG_SYS.ADD_TLOG_SYS_SEQ()                      '登録


            '↑↑↑↑↑↑************************************************************************************************************


            '***********************
            '指示ﾌﾗｸﾞﾁｪｯｸ
            '***********************
            Dim strSQL As String            'SQL文
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim intDEBUG_FLAG As Integer    'ﾌﾗｸﾞ値
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_SYS_HEN"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FHENSU_ID = '" & TO_STRING(FHENSU_ID_SSS000000_004) & "'"
            strSQL &= vbCrLf
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_SYS_HEN"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                intDEBUG_FLAG = TO_NUMBER(objRow("FHENSU_INT"))                       '整数ﾃﾞｰﾀ
                If intDEBUG_FLAG = FLAG_ON Then
                    Call AddToMsgLog(Now, FMSG_ID_S9001, strProd, strMsg)
                End If
            End If


        Catch ex As UserException
            'NOP(Error 処理中の Error 回避)
        Catch ex As Exception
            'NOP(Error 処理中の Error 回避)
        End Try
    End Sub
#End Region
#Region "  ﾛｸﾞ書き込み                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書き込み処理
    ''' </summary>
    ''' <param name="strMsg">ﾛｸﾞ書込ﾒｯｾｰｼﾞ</param>
    ''' <param name="strProd"></param>
    ''' <param name="intType">ﾒｯｾｰｼﾞ区分    0:情報 1:ﾕｰｻﾞｰｴﾗｰ 2:ｼｽﾃﾑｴﾗｰ</param>
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
#Region "  ﾒｯｾｰｼﾞ履歴書き込み                                                                       "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾒｯｾｰｼﾞ履歴書き込み処理
    ''' </summary>
    ''' <param name="dtmACTION_DATE">発生日時</param>
    ''' <param name="strMSG_ID">ﾒｯｾｰｼﾞID</param>
    ''' <param name="strPrm1">ﾊﾟﾗﾒｰﾀ1</param>
    ''' <param name="strPrm2">ﾊﾟﾗﾒｰﾀ2</param>
    ''' <param name="strPrm3">ﾊﾟﾗﾒｰﾀ3</param>
    ''' <param name="strPrm4">ﾊﾟﾗﾒｰﾀ4</param>
    ''' <param name="strPrm5">ﾊﾟﾗﾒｰﾀ5</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub AddToMsgLog(ByVal dtmACTION_DATE As Date, _
                           ByVal strMSG_ID As String, _
                           Optional ByVal strPrm1 As String = "", _
                           Optional ByVal strPrm2 As String = "", _
                           Optional ByVal strPrm3 As String = "", _
                           Optional ByVal strPrm4 As String = "", _
                           Optional ByVal strPrm5 As String = "")
        Try

            Dim strSQL As String                'SQL文
            'Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim intRet As RetCode = RetCode.OK  '関数戻り値
            'Dim intRetSQL As Integer            'SQL実行戻り値
            'Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ


            '***********************
            '未確認同一ﾒｯｾｰｼﾞﾁｪｯｸ
            '***********************
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TLOG_MESSAGE"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FMSG_ID = '" & strMSG_ID & "'"               'ﾒｯｾｰｼﾞID
            strSQL &= vbCrLf & "    AND FLOG_CHECK_FLAG = " & TO_STRING(FLAG_OFF)   '確認ﾌﾗｸﾞ
            If strPrm1 <> "" Then
                strSQL &= vbCrLf & "    AND FMSG_PRM1 = '" & SQL_ITEM(strPrm1, LOGMSG_SYS_PRM_FLD_SIZE) & "'"
            Else
                strSQL &= vbCrLf & "    AND FMSG_PRM1 IS NULL"
            End If
            If strPrm2 <> "" Then
                strSQL &= vbCrLf & "    AND FMSG_PRM2 = '" & SQL_ITEM(strPrm2, LOGMSG_SYS_PRM_FLD_SIZE) & "'"
            Else
                strSQL &= vbCrLf & "    AND FMSG_PRM2 IS NULL"
            End If
            If strPrm3 <> "" Then
                strSQL &= vbCrLf & "    AND FMSG_PRM3 = '" & SQL_ITEM(strPrm3, LOGMSG_SYS_PRM_FLD_SIZE) & "'"
            Else
                strSQL &= vbCrLf & "    AND FMSG_PRM3 IS NULL"
            End If
            If strPrm4 <> "" Then
                strSQL &= vbCrLf & "    AND FMSG_PRM4 = '" & SQL_ITEM(strPrm4, LOGMSG_SYS_PRM_FLD_SIZE) & "'"
            Else
                strSQL &= vbCrLf & "    AND FMSG_PRM4 IS NULL"
            End If
            If strPrm5 <> "" Then
                strSQL &= vbCrLf & "    AND FMSG_PRM5 = '" & SQL_ITEM(strPrm5, LOGMSG_SYS_PRM_FLD_SIZE) & "'"
            Else
                strSQL &= vbCrLf & "    AND FMSG_PRM5 IS NULL"
            End If
            strSQL &= vbCrLf
            ObjDbLog.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TLOG_MESSAGE"
            ObjDbLog.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '(同一未確認ﾒｯｾｰｼﾞ有の場合)
                Exit Try
            End If


            '***********************
            'ﾛｸﾞの登録
            '***********************
            Dim objTLOG_MESSAGE As New TBL_TLOG_MESSAGE(Owner, ObjDbLog, ObjDbLog)      'ﾒｯｾｰｼﾞﾛｸﾞﾃｰﾌﾞﾙｸﾗｽ
            objTLOG_MESSAGE.FMSG_ID = strMSG_ID                                         'ﾒｯｾｰｼﾞID
            objTLOG_MESSAGE.FLOG_CHECK_FLAG = FLAG_OFF                                  '確認ﾌﾗｸﾞ
            objTLOG_MESSAGE.FHASSEI_DT = dtmACTION_DATE                                 '発生日時
            objTLOG_MESSAGE.FLOG_CHECK_DT = DEFAULT_DATE                                '確認日時
            objTLOG_MESSAGE.FUSER_ID = DEFAULT_STRING                                    'ﾕｰｻﾞｰID
            objTLOG_MESSAGE.FMSG_PRM1 = SQL_ITEM(strPrm1, LOGMSG_SYS_PRM_FLD_SIZE)      'ﾊﾟﾗﾒｰﾀ1
            objTLOG_MESSAGE.FMSG_PRM2 = SQL_ITEM(strPrm2, LOGMSG_SYS_PRM_FLD_SIZE)      'ﾊﾟﾗﾒｰﾀ2
            objTLOG_MESSAGE.FMSG_PRM3 = SQL_ITEM(strPrm3, LOGMSG_SYS_PRM_FLD_SIZE)      'ﾊﾟﾗﾒｰﾀ3
            objTLOG_MESSAGE.FMSG_PRM4 = SQL_ITEM(strPrm4, LOGMSG_SYS_PRM_FLD_SIZE)      'ﾊﾟﾗﾒｰﾀ4
            objTLOG_MESSAGE.FMSG_PRM5 = SQL_ITEM(strPrm5, LOGMSG_SYS_PRM_FLD_SIZE)      'ﾊﾟﾗﾒｰﾀ5
            objTLOG_MESSAGE.ADD_TLOG_MESSAGE_SEQ()                                      '登録


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/09/05 異常ﾋﾞｯﾄ更新


            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_J340011)                           '起動


            '↑↑↑↑↑↑************************************************************************************************************


        Catch ex As UserException
            'NOP(Error 処理中の Error 回避)
        Catch ex As Exception
            'NOP(Error 処理中の Error 回避)
        End Try
    End Sub
#End Region
#Region "  ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ書き込み                                                                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ書き込み処理
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <param name="strDenbunDtlName">電文分解名称配列</param>
    ''' <param name="strSYORI_ID">処理ID</param>
    ''' <param name="strFLOG_DATA_OPE">ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ.  ｵﾍﾟﾚｰｼｮﾝﾛｸﾞﾃﾞｰﾀ</param>
    ''' <param name="strFMSG_PRM1">ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ. ﾊﾟﾗﾒｰﾀ1</param>
    ''' <param name="strFMSG_PRM2">ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ. ﾊﾟﾗﾒｰﾀ2</param>
    ''' <param name="strFMSG_PRM3">ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ. ﾊﾟﾗﾒｰﾀ3</param>
    ''' <param name="strFMSG_PRM4">ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ. ﾊﾟﾗﾒｰﾀ4</param>
    ''' <param name="strFMSG_PRM5">ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ. ﾊﾟﾗﾒｰﾀ5</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToOpeLog(ByVal strDenbunDtl() As String _
                         , ByVal strDenbunDtlName() As String _
                         , ByVal strSYORI_ID As String _
                         , ByVal strFLOG_DATA_OPE As String _
                         , Optional ByVal strFMSG_PRM1 As String = Nothing _
                         , Optional ByVal strFMSG_PRM2 As String = Nothing _
                         , Optional ByVal strFMSG_PRM3 As String = Nothing _
                         , Optional ByVal strFMSG_PRM4 As String = Nothing _
                         , Optional ByVal strFMSG_PRM5 As String = Nothing _
                           )
        Try


            '***********************
            '端末ﾏｽﾀの特定
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)     '端末ﾏｽﾀ
            objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '端末ID     ｾｯﾄ
            Call objTDSP_TERM.GET_TDSP_TERM(False)              '特定


            '***********************
            'ﾕｰｻﾞｰﾏｽﾀの特定
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)       '端末ﾏｽﾀ
            objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)                    'ﾕｰｻﾞｰID
            Try
                '(ﾛｸﾞｲﾝの時は、ﾕｰｻﾞｰが特定出来ない場合がある為)
                Call objTMST_USER.GET_TMST_USER(False)  '特定
            Catch ex As Exception
            End Try


            '***********************
            '処理ﾏｽﾀの特定
            '***********************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理
            objTPRG_TIMER.FSYORI_ID = strSYORI_ID   '処理ID
            objTPRG_TIMER.GET_TPRG_TIMER(False)     '特定


            '***********************
            'ﾛｸﾞ登録判定
            '***********************
            'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ
            Dim blnLogOpe As Boolean = True                     'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ  登録
            If IsNull(objTPRG_TIMER.FLOG_OPE_FLAG) = False Then
                If TO_DECIMAL(objTPRG_TIMER.FLOG_OPE_FLAG) = FLAG_OFF Then
                    blnLogOpe = False
                End If
            End If
            'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ
            Dim blnLogTrn As Boolean = True                     'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ   登録
            If IsNull(objTPRG_TIMER.FLOG_TRN_FLAG) = False Then
                If TO_DECIMAL(objTPRG_TIMER.FLOG_TRN_FLAG) = FLAG_OFF Then
                    blnLogTrn = False
                End If
            End If
            '作業履歴
            Dim blnEvdOpe As Boolean = False                    '作業履歴     登録しない
            If IsNull(objTPRG_TIMER.FEVD_OPE_FLAG) = False Then
                If TO_DECIMAL(objTPRG_TIMER.FEVD_OPE_FLAG) = FLAG_ON Then
                    blnEvdOpe = True
                End If
            End If


            '***********************
            'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ
            '***********************
            If blnLogOpe = True Then
                '***********************
                'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞの登録
                '***********************
                Dim objTLOG_OPE As New TBL_TLOG_OPE(Owner, ObjDbLog, ObjDbLog)          'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞｸﾗｽ
                objTLOG_OPE.FHASSEI_DT = Now                        '発生日時
                objTLOG_OPE.FTERM_ID = strDenbunDtl(DSPTERM_ID)     '端末ID
                objTLOG_OPE.FTERM_NAME = objTDSP_TERM.FTERM_NAME    '端末名
                objTLOG_OPE.FUSER_ID = strDenbunDtl(DSPUSER_ID)     'ﾕｰｻﾞｰID
                objTLOG_OPE.FUSER_NAME = objTMST_USER.FUSER_NAME    'ﾕｰｻﾞｰ名
                objTLOG_OPE.FSYORI_ID = strSYORI_ID                 '処理ID
                objTLOG_OPE.FSYORI_NAME = objTPRG_TIMER.FCOMMENT    '処理名
                objTLOG_OPE.FREASON_CD = Nothing                    '理由ｺｰﾄﾞ
                objTLOG_OPE.FREASON = strDenbunDtl(2)                    '理由
                objTLOG_OPE.FLOG_DATA_OPE = strFLOG_DATA_OPE        'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞﾃﾞｰﾀ
                objTLOG_OPE.ADD_TLOG_OPE_SEQ()                      '登録


                '**************************************
                'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ詳細の登録
                '**************************************
                Dim objTLOG_OPE_DTL As New TBL_TLOG_OPE_DTL(Owner, ObjDbLog, ObjDbLog)                  'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ詳細ｸﾗｽ
                objTLOG_OPE_DTL.FLOG_NO = objTLOG_OPE.FLOG_NO                                           'ﾛｸﾞ№
                For ii As Integer = 3 To UBound(strDenbunDtl)
                    '(ﾙｰﾌﾟ:ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ詳細数)

                    objTLOG_OPE_DTL.FORDER = ii - 1                             '表示順
                    objTLOG_OPE_DTL.FDENBUN_ITEM_NAME = strDenbunDtlName(ii)    '電文ｱｲﾃﾑ名称
                    objTLOG_OPE_DTL.FDENBUN_ITEM_DATA = strDenbunDtl(ii)        '電文ｱｲﾃﾑﾃﾞｰﾀ
                    objTLOG_OPE_DTL.ADD_TLOG_OPE_DTL()                          '追加

                Next
            End If


            '***********************
            '作業履歴
            '***********************
            If blnEvdOpe = True Then
                '***********************
                '作業履歴の登録
                '***********************
                Dim objTEVD_OPE As New TBL_TEVD_OPE(Owner, ObjDbLog, ObjDbLog)  '作業履歴ｸﾗｽ
                objTEVD_OPE.FHASSEI_DT = Now                                    '発生日時
                objTEVD_OPE.FTERM_ID = strDenbunDtl(DSPTERM_ID)                 '端末ID
                objTEVD_OPE.FTERM_NAME = objTDSP_TERM.FTERM_NAME                '端末名
                objTEVD_OPE.FUSER_ID = strDenbunDtl(DSPUSER_ID)                 'ﾕｰｻﾞｰID
                objTEVD_OPE.FUSER_NAME = objTMST_USER.FUSER_NAME                'ﾕｰｻﾞｰ名
                objTEVD_OPE.FSYORI_ID = strSYORI_ID                             '処理ID
                objTEVD_OPE.FSYORI_NAME = objTPRG_TIMER.FCOMMENT                '処理名
                objTEVD_OPE.FREASON_CD = Nothing                                '理由ｺｰﾄﾞ
                objTEVD_OPE.FREASON = strDenbunDtl(2)                           '理由
                objTEVD_OPE.FLOG_DATA_OPE = strFLOG_DATA_OPE                    'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞﾃﾞｰﾀ
                objTEVD_OPE.ADD_TEVD_OPE_SEQ()                                  '登録


                '**************************************
                '作業履歴詳細の登録
                '**************************************
                Dim objTEVD_OPE_DTL As New TBL_TEVD_OPE_DTL(Owner, ObjDbLog, ObjDbLog)                  'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ詳細ｸﾗｽ
                objTEVD_OPE_DTL.FLOG_NO = objTEVD_OPE.FLOG_NO                                           'ﾛｸﾞ№
                For ii As Integer = 3 To UBound(strDenbunDtl)
                    '(ﾙｰﾌﾟ:ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ詳細数)

                    objTEVD_OPE_DTL.FORDER = ii - 1                             '表示順
                    objTEVD_OPE_DTL.FDENBUN_ITEM_NAME = strDenbunDtlName(ii)    '電文ｱｲﾃﾑ名称
                    objTEVD_OPE_DTL.FDENBUN_ITEM_DATA = strDenbunDtl(ii)        '電文ｱｲﾃﾑﾃﾞｰﾀ
                    objTEVD_OPE_DTL.ADD_TEVD_OPE_DTL()                          '追加

                Next
            End If


            '***********************
            'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞの追加
            '***********************
            If blnLogTrn = True Then
                Dim strDenbunInfo As String = ""        '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
                Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
                Call AddToTrnLog(strDenbunDtl(DSPUSER_ID) _
                               , strDenbunDtl(DSPTERM_ID) _
                               , strSYORI_ID _
                               , strFLOG_DATA_OPE & strDenbunInfo _
                               , strFMSG_PRM1 _
                               , strFMSG_PRM2 _
                               , strFMSG_PRM3 _
                               , strFMSG_PRM4 _
                               , strFMSG_PRM5 _
                                 )

            End If


        Catch ex As Exception
            'NOP(Error 処理中の Error 回避)
        End Try
    End Sub
#End Region
#Region "  ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ書き込み                                                                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ書き込み処理
    ''' </summary>
    ''' <param name="strFUSER_ID">ﾕｰｻﾞｰID</param>
    ''' <param name="strFTERM_ID">端末ID</param>
    ''' <param name="strFSYORI_ID">処理ID</param>
    ''' <param name="strFSAGYOU_DTL">作業詳細</param>
    ''' <param name="strFMSG_PRM1">ﾊﾟﾗﾒｰﾀ1</param>
    ''' <param name="strFMSG_PRM2">ﾊﾟﾗﾒｰﾀ2</param>
    ''' <param name="strFMSG_PRM3">ﾊﾟﾗﾒｰﾀ3</param>
    ''' <param name="strFMSG_PRM4">ﾊﾟﾗﾒｰﾀ4</param>
    ''' <param name="strFMSG_PRM5">ﾊﾟﾗﾒｰﾀ5</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToTrnLog(ByVal strFUSER_ID As String _
                         , ByVal strFTERM_ID As String _
                         , ByVal strFSYORI_ID As String _
                         , ByVal strFSAGYOU_DTL As String _
                         , Optional ByVal strFMSG_PRM1 As String = Nothing _
                         , Optional ByVal strFMSG_PRM2 As String = Nothing _
                         , Optional ByVal strFMSG_PRM3 As String = Nothing _
                         , Optional ByVal strFMSG_PRM4 As String = Nothing _
                         , Optional ByVal strFMSG_PRM5 As String = Nothing _
                           )
        Try


            '***********************
            'ﾛｸﾞの登録
            '***********************
            Dim objTLOG_TRNS As New TBL_TLOG_TRNS(Owner, ObjDbLog, ObjDbLog)                    'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞｸﾗｽ
            objTLOG_TRNS.FHASSEI_DT = Now                                                       '発生日時
            objTLOG_TRNS.FUSER_ID = strFUSER_ID                                                   'ﾕｰｻﾞｰID
            objTLOG_TRNS.FTERM_ID = strFTERM_ID                                                 '端末ID
            objTLOG_TRNS.FSYORI_ID = strFSYORI_ID                                               '処理ID
            objTLOG_TRNS.FMSG_PRM1 = strFMSG_PRM1                                               'ﾊﾟﾗﾒｰﾀ1
            objTLOG_TRNS.FMSG_PRM2 = strFMSG_PRM2                                               'ﾊﾟﾗﾒｰﾀ2
            objTLOG_TRNS.FMSG_PRM3 = strFMSG_PRM3                                               'ﾊﾟﾗﾒｰﾀ3
            objTLOG_TRNS.FMSG_PRM4 = strFMSG_PRM4                                               'ﾊﾟﾗﾒｰﾀ4
            objTLOG_TRNS.FMSG_PRM5 = strFMSG_PRM5                                               'ﾊﾟﾗﾒｰﾀ5
            objTLOG_TRNS.FLOG_DATA_TRN = SQL_ITEM(strFSAGYOU_DTL, LOGTRN_FSAGYOU_DTL_FLD_SIZE)  'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞﾃﾞｰﾀ
            objTLOG_TRNS.ADD_TLOG_TRNS_SEQ()                                                    '登録


        Catch ex As Exception
            'NOP(Error 処理中の Error 回避)
        End Try
    End Sub

#End Region
#Region "  ﾃﾞﾊﾞｯｸﾞﾛｸﾞ書き込み                                                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞﾊﾞｯｸﾞﾛｸﾞ書き込み処理
    ''' </summary>
    ''' <param name="strFUSER_ID">ﾕｰｻﾞｰID</param>
    ''' <param name="strFTERM_ID">端末ID</param>
    ''' <param name="strFSYORI_ID">処理ID</param>
    ''' <param name="strFSAGYOU_DTL">作業詳細</param>
    ''' <param name="strFMSG_PRM1">ﾊﾟﾗﾒｰﾀ1</param>
    ''' <param name="strFMSG_PRM2">ﾊﾟﾗﾒｰﾀ2</param>
    ''' <param name="strFMSG_PRM3">ﾊﾟﾗﾒｰﾀ3</param>
    ''' <param name="strFMSG_PRM4">ﾊﾟﾗﾒｰﾀ4</param>
    ''' <param name="strFMSG_PRM5">ﾊﾟﾗﾒｰﾀ5</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToDebugLog(ByVal strFUSER_ID As String _
                           , ByVal strFTERM_ID As String _
                           , ByVal strFSYORI_ID As String _
                           , ByVal strFSAGYOU_DTL As String _
                           , Optional ByVal strFMSG_PRM1 As String = Nothing _
                           , Optional ByVal strFMSG_PRM2 As String = Nothing _
                           , Optional ByVal strFMSG_PRM3 As String = Nothing _
                           , Optional ByVal strFMSG_PRM4 As String = Nothing _
                           , Optional ByVal strFMSG_PRM5 As String = Nothing _
                             )
        Try


            '***********************
            'ｼｽﾃﾑ変数の特定
            '***********************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 'ｼｽﾃﾑ変数
            If objTPRG_SYS_HEN.SS000000_008 = FLAG_OFF Then
                '(ﾃﾞﾊﾞｯｸﾞﾛｸﾞ登録ﾌﾗｸﾞがONになっていない場合)
                Exit Try
            End If


            '********************************
            'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ書き込み処理
            '********************************
            Call AddToTrnLog(strFUSER_ID _
                           , strFTERM_ID _
                           , strFSYORI_ID _
                           , strFSAGYOU_DTL _
                           , strFMSG_PRM1 _
                           , strFMSG_PRM2 _
                           , strFMSG_PRM3 _
                           , strFMSG_PRM4 _
                           , strFMSG_PRM5 _
                             )


        Catch ex As Exception
            'NOP(Error 処理中の Error 回避)
        End Try
    End Sub
#End Region
#Region "  ﾒｯｾｰｼﾞ変換                                                                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｯｾｰｼﾞ変換
    ''' </summary>
    ''' <param name="strMSG_ID">ﾒｯｾｰｼﾞID</param>
    ''' <returns>ﾒｯｾｰｼﾞ変換後ﾃﾞｰﾀ</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Change_Message(ByVal strMSG_ID As String) As String
        Try
            Dim objTMST_MESSAGE As New TBL_TMST_MESSAGE(Owner, ObjDb, ObjDbLog)
            Dim intRet As Integer
            Change_Message = ""
            objTMST_MESSAGE.FMSG_ID = strMSG_ID
            intRet = objTMST_MESSAGE.GET_TMST_MESSAGE(False)
            If intRet = RetCode.OK Then
                Return (objTMST_MESSAGE.FMSG_NAIYOU)
            Else
                Return (strMSG_ID)
            End If
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region

#Region "  画面応答ﾒｯｾｰｼﾞ作成（初期設定）                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面応答ﾒｯｾｰｼﾞ作成（初期設定）
    ''' </summary>
    ''' <param name="objTelegramSend">電文作成、分割ｸﾗｽ</param>
    ''' <param name="msgSend">送信文字列</param>
    ''' <remarks>文字列変換後ﾃﾞｰﾀ</remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeMessageGamenIni(ByRef objTelegramSend As clsTelegram _
                                 , ByRef msgSend As String _
                                   )
        Try
            '□送信電文初期化
            objTelegramSend.FORMAT_ID = FORMAT_DSP_RETURN                                       'ﾌｫｰﾏｯﾄ名   :ｿｹｯﾄ返信
            objTelegramSend.SETIN_DATA("DSPRET_STATE", ID_RETURN_RET_STATE_NG)                  'ﾃﾞｰﾀｾｯﾄ    :応答ｽﾃｰﾀｽ
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE_EXIST", ID_RETURN_RET_MESSAGE_EXIST_YES) 'ﾃﾞｰﾀｾｯﾄ    :応答ﾒｯｾｰｼﾞ有無
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE", Me.Change_Message(FMSG_ID_S9000))       'ﾃﾞｰﾀｾｯﾄ    :応答ﾒｯｾｰｼﾞ
            objTelegramSend.SETIN_DATA("DSPRET_DATA_SYUBETU", ID_RETURN_RET_DATA_SYUBETU)       'ﾃﾞｰﾀｾｯﾄ    :応答ﾃﾞｰﾀ種別
            objTelegramSend.SETIN_DATA("DSPRET_DATA", ID_RETURN_RET_DATA)                       'ﾃﾞｰﾀｾｯﾄ    :応答ﾃﾞｰﾀ
            objTelegramSend.MAKE_TELEGRAM()                                                     '電文作成
            msgSend = objTelegramSend.TELEGRAM_MAKED


        Catch ex As Exception
            Throw ex

        End Try
    End Sub
#End Region
#Region "  画面応答ﾒｯｾｰｼﾞ作成（正常応答）                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面応答ﾒｯｾｰｼﾞ作成（正常応答）
    ''' </summary>
    ''' <param name="objTelegramSend">電文作成、分割ｸﾗｽ</param>
    ''' <param name="msgSend">送信文字列</param>
    ''' <param name="strDataSyubetu"></param>
    ''' <param name="strData"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeMessageGamenOK(ByRef objTelegramSend As clsTelegram _
                                , ByRef msgSend As String _
                                , Optional ByVal strDataSyubetu As String = ID_RETURN_RET_DATA_SYUBETU _
                                , Optional ByVal strData As String = ID_RETURN_RET_DATA _
                                  )
        Try
            '□送信電文初期化
            objTelegramSend.FORMAT_ID = FORMAT_DSP_RETURN                                       'ﾌｫｰﾏｯﾄ名   :ｿｹｯﾄ返信
            objTelegramSend.SETIN_DATA("DSPRET_STATE", ID_RETURN_RET_STATE_OK)                  'ﾃﾞｰﾀｾｯﾄ    :応答ｽﾃｰﾀｽ
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE_EXIST", ID_RETURN_RET_MESSAGE_EXIST_NO)  'ﾃﾞｰﾀｾｯﾄ    :応答ﾒｯｾｰｼﾞ有無
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE", "")                                    'ﾃﾞｰﾀｾｯﾄ    :応答ﾒｯｾｰｼﾞ
            objTelegramSend.SETIN_DATA("DSPRET_DATA_SYUBETU", strDataSyubetu)                   'ﾃﾞｰﾀｾｯﾄ    :応答ﾃﾞｰﾀ種別
            objTelegramSend.SETIN_DATA("DSPRET_DATA", strData)                                  'ﾃﾞｰﾀｾｯﾄ    :応答ﾃﾞｰﾀ
            objTelegramSend.MAKE_TELEGRAM()                                                     '電文作成
            msgSend = objTelegramSend.TELEGRAM_MAKED


        Catch ex As Exception
            Throw ex

        End Try
    End Sub
#End Region
#Region "  画面応答ﾒｯｾｰｼﾞ作成（ﾒｯｾｰｼﾞ応答）                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面応答ﾒｯｾｰｼﾞ作成（ﾒｯｾｰｼﾞ応答）
    ''' </summary>
    ''' <param name="objTelegramSend">電文作成、分割ｸﾗｽ</param>
    ''' <param name="msgSend">送信文字列</param>
    ''' <param name="strRetMessage">応答ﾒｯｾｰｼﾞ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeMessageGamenMessage(ByRef objTelegramSend As clsTelegram _
                                , ByRef msgSend As String _
                                , ByVal strRetMessage As String _
                                  )
        Try
            '□送信電文初期化
            objTelegramSend.FORMAT_ID = FORMAT_DSP_RETURN                                       'ﾌｫｰﾏｯﾄ名   :ｿｹｯﾄ返信
            objTelegramSend.SETIN_DATA("DSPRET_STATE", ID_RETURN_RET_STATE_OK)                  'ﾃﾞｰﾀｾｯﾄ    :応答ｽﾃｰﾀｽ
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE_EXIST", ID_RETURN_RET_MESSAGE_EXIST_YES) 'ﾃﾞｰﾀｾｯﾄ    :応答ﾒｯｾｰｼﾞ有無
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE", strRetMessage)                         'ﾃﾞｰﾀｾｯﾄ    :応答ﾒｯｾｰｼﾞ
            objTelegramSend.SETIN_DATA("DSPRET_DATA_SYUBETU", ID_RETURN_RET_DATA_SYUBETU)       'ﾃﾞｰﾀｾｯﾄ    :応答ﾃﾞｰﾀ種別
            objTelegramSend.SETIN_DATA("DSPRET_DATA", ID_RETURN_RET_DATA)                       'ﾃﾞｰﾀｾｯﾄ    :応答ﾃﾞｰﾀ
            objTelegramSend.MAKE_TELEGRAM()                                                     '電文作成
            msgSend = objTelegramSend.TELEGRAM_MAKED


        Catch ex As Exception
            Throw ex

        End Try
    End Sub
#End Region
#Region "  画面応答ﾒｯｾｰｼﾞ作成（ｴﾗｰ応答）                                                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面応答ﾒｯｾｰｼﾞ作成（ｴﾗｰ応答）
    ''' </summary>
    ''' <param name="objTelegramSend">電文作成、分割ｸﾗｽ</param>
    ''' <param name="msgSend">送信文字列</param>
    ''' <param name="strRetMessage">応答ﾒｯｾｰｼﾞ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeMessageGamenNG(ByRef objTelegramSend As clsTelegram _
                                , ByRef msgSend As String _
                                , ByVal strRetMessage As String _
                                  )
        Try
            strRetMessage &= vbCrLf & "操作に失敗しました。"


            '□送信電文初期化
            objTelegramSend.FORMAT_ID = FORMAT_DSP_RETURN                                       'ﾌｫｰﾏｯﾄ名   :ｿｹｯﾄ返信
            objTelegramSend.SETIN_DATA("DSPRET_STATE", ID_RETURN_RET_STATE_NG)                  'ﾃﾞｰﾀｾｯﾄ    :応答ｽﾃｰﾀｽ
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE_EXIST", ID_RETURN_RET_MESSAGE_EXIST_YES) 'ﾃﾞｰﾀｾｯﾄ    :応答ﾒｯｾｰｼﾞ有無
            objTelegramSend.SETIN_DATA("DSPRET_MESSAGE", strRetMessage)                         'ﾃﾞｰﾀｾｯﾄ    :応答ﾒｯｾｰｼﾞ
            objTelegramSend.SETIN_DATA("DSPRET_DATA_SYUBETU", ID_RETURN_RET_DATA_SYUBETU)       'ﾃﾞｰﾀｾｯﾄ    :応答ﾃﾞｰﾀ種別
            objTelegramSend.SETIN_DATA("DSPRET_DATA", ID_RETURN_RET_DATA)                       'ﾃﾞｰﾀｾｯﾄ    :応答ﾃﾞｰﾀ
            objTelegramSend.MAKE_TELEGRAM()                                                     '電文作成
            msgSend = objTelegramSend.TELEGRAM_MAKED


        Catch ex As Exception
            Throw ex

        End Try
    End Sub
#End Region
#Region "  電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列生成                                                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列生成
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <param name="strDenbunDtlName">電文分解名称配列</param>
    ''' <param name="strDenbunInfo">電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeLogDataDenbun(ByVal strDenbunDtl() As String _
                               , ByVal strDenbunDtlName() As String _
                               , ByRef strDenbunInfo As String _
                                 )
        Try

            strDenbunInfo = ""
            For ii As Integer = LBound(strDenbunDtl) To UBound(strDenbunDtl)
                '(ﾙｰﾌﾟ:ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ詳細数)

                strDenbunInfo &= "["
                strDenbunInfo &= strDenbunDtlName(ii)    '電文ｱｲﾃﾑ名称
                strDenbunInfo &= ":"
                strDenbunInfo &= strDenbunDtl(ii)        '電文ｱｲﾃﾑﾃﾞｰﾀ
                strDenbunInfo &= "]"

            Next


        Catch ex As UserException
            Call ComUser(ex)
            Throw ex
        Catch ex As Exception
            Call ComError(ex)
            Throw ex
        End Try

    End Sub

#End Region
#Region "  ｿｹｯﾄ受信処理初期設定                                                                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ受信処理初期設定
    ''' </summary>
    ''' <param name="strDenbunDtl">分解結果配列</param>
    ''' <param name="strDenbunDtlName">分解結果名称配列</param>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <param name="objTelegramRecv">受信電文ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objTelegramSend">送信電文ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub DivDenbun(ByRef strDenbunDtl() As String _
                       , ByRef strDenbunDtlName() As String _
                       , ByVal strMSG_RECV As String _
                       , ByRef strMSG_SEND As String _
                       , ByVal objTelegramRecv As clsTelegram _
                       , ByRef objTelegramSend As clsTelegram _
                         )
        Try


            '************************
            '送信電文初期化
            '************************
            Call MakeMessageGamenIni(objTelegramSend, strMSG_SEND)


            '************************
            '受信電文分解
            '************************
            objTelegramRecv.FORMAT_ID = MeDSPID                         'ﾌｫｰﾏｯﾄ名ｾｯﾄ
            objTelegramRecv.TELEGRAM_PARTITION = strMSG_RECV            '分割する電文ｾｯﾄ
            objTelegramRecv.PARTITION()                                 '電文分割


            '************************
            '電文分解
            '************************
            Call AnalysisDenbun(strDenbunDtl _
                              , strDenbunDtlName _
                              , objTelegramRecv _
                              )


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ｿｹｯﾄ受信処理初期設定(HDT)                                                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ受信処理初期設定(HDT)
    ''' </summary>
    ''' <param name="strSOCK_FORMAT">電文分割ﾌｫｰﾏｯﾄ</param>
    ''' <param name="strDenbunDtl">分解結果配列</param>
    ''' <param name="strDenbunDtlName">分解結果名称配列</param>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <param name="objTelegramRecv">受信電文ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objTelegramSend">送信電文ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub DivDenbunHDT(ByVal strSOCK_FORMAT As String _
                        , ByRef strDenbunDtl() As String _
                        , ByRef strDenbunDtlName() As String _
                        , ByVal strMSG_RECV As String _
                        , ByRef strMSG_SEND As String _
                        , ByVal objTelegramRecv As clsTelegram _
                        , ByRef objTelegramSend As clsTelegram _
                          )
        Try


            '************************
            '受信電文分解
            '************************
            objTelegramRecv.FORMAT_ID = strSOCK_FORMAT                  'ﾌｫｰﾏｯﾄ名ｾｯﾄ
            objTelegramRecv.TELEGRAM_PARTITION = strMSG_RECV            '分割する電文ｾｯﾄ
            objTelegramRecv.PARTITION()                                 '電文分割


            '************************
            '送信電文初期化（ﾌｫｰﾏｯﾄは受信電文と同じ）
            '************************
            objTelegramSend.FORMAT_ID = strSOCK_FORMAT                  'ﾌｫｰﾏｯﾄ名ｾｯﾄ
            objTelegramSend.TELEGRAM_PARTITION = strMSG_RECV            '分割する電文ｾｯﾄ
            objTelegramSend.PARTITION()                                 '電文分割


            '************************
            '電文分解
            '************************
            Call AnalysisDenbunHDT(strDenbunDtl _
                              , strDenbunDtlName _
                              , objTelegramRecv _
                              )


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  電文分解                                                                                 "
    '''**********************************************************************************************
    ''' <summary>
    ''' 電文分解
    ''' </summary>
    ''' <param name="strDenbunDtl">分解結果配列</param>
    ''' <param name="strDenbunDtlName">分解結果名称配列</param>
    ''' <param name="objTelegramRecv">受信電文ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub AnalysisDenbun(ByRef strDenbunDtl() As String _
                            , ByRef strDenbunDtlName() As String _
                            , ByVal objTelegramRecv As clsTelegram _
                              )
        Try


            '*************************************************
            'Config取得
            '*************************************************
            Dim objDocument As New System.Xml.XmlDocument       'XMLﾄﾞｷｭﾒﾝﾄ
            Dim objNode As System.Xml.XmlNode                   'XMLﾉｰﾄﾞ
            Dim ii As Integer = -2                              'ｶｳﾝﾀ(ｺﾏﾝﾄﾞID対策)
            objDocument.Load(CONFIG_TELEGRAM_DSP)               'ﾃﾞｰﾀﾛｰﾄﾞ

            '==============================================
            'ﾍｯﾀﾞｰ部分
            '==============================================
            For Each objNode In objDocument(XML_NODE_CONFIG)(XML_NODE_HEADER)
                '(ﾙｰﾌﾟ:ﾉｰﾄﾞ数)

                If objNode.Name = XML_NODE_ADD Then
                    '(ﾃﾞｰﾀ定義の場合)
                    Dim strItem As String = ""          'ｱｲﾃﾑ名
                    strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
                    ii += 1
                    If ii < 0 Then Continue For 'ｺﾏﾝﾄﾞID対策
                    ReDim Preserve strDenbunDtl(ii)
                    strDenbunDtl(ii) = Trim(objTelegramRecv.SELECT_HEADER(strItem))
                End If
                If objNode.NodeType = Xml.XmlNodeType.Comment Then
                    If ii < 0 Then Continue For 'ｺﾏﾝﾄﾞID対策
                    Dim strItemName As String = ""      'ｱｲﾃﾑ名称
                    strItemName = objNode.Value
                    ReDim Preserve strDenbunDtlName(ii)
                    strDenbunDtlName(ii) = Trim(strItemName)
                End If

            Next

            '==============================================
            'ﾃﾞｰﾀ部分
            '==============================================
            For Each objNode In objDocument(XML_NODE_CONFIG)(XML_NODE_ID_PREFIX & objTelegramRecv.FORMAT_ID)
                '(ﾙｰﾌﾟ:ﾉｰﾄﾞ数)

                If objNode.Name = XML_NODE_ADD Then
                    '(ﾃﾞｰﾀ定義の場合)
                    Dim strItem As String = ""          'ｱｲﾃﾑ名
                    strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
                    ii += 1
                    ReDim Preserve strDenbunDtl(ii)
                    strDenbunDtl(ii) = Trim(objTelegramRecv.SELECT_DATA(strItem))
                End If
                If objNode.NodeType = Xml.XmlNodeType.Comment Then
                    Dim strItemName As String = ""      'ｱｲﾃﾑ名称
                    strItemName = objNode.Value
                    ReDim Preserve strDenbunDtlName(ii)
                    strDenbunDtlName(ii) = Trim(strItemName)
                End If

            Next


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  電文分解(HDT)                                                                            "
    '''**********************************************************************************************
    ''' <summary>
    ''' 電文分解
    ''' </summary>
    ''' <param name="strDenbunDtl">分解結果配列</param>
    ''' <param name="strDenbunDtlName">分解結果名称配列</param>
    ''' <param name="objTelegramRecv">受信電文ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub AnalysisDenbunHDT(ByRef strDenbunDtl() As String _
                            , ByRef strDenbunDtlName() As String _
                            , ByVal objTelegramRecv As clsTelegram _
                              )
        Try


            '*************************************************
            'Config取得
            '*************************************************
            Dim objDocument As New System.Xml.XmlDocument       'XMLﾄﾞｷｭﾒﾝﾄ
            Dim objNode As System.Xml.XmlNode                   'XMLﾉｰﾄﾞ
            Dim ii As Integer = -2                              'ｶｳﾝﾀ(ｺﾏﾝﾄﾞID対策)
            objDocument.Load(CONFIG_TELEGRAM_HDT)               'ﾃﾞｰﾀﾛｰﾄﾞ

            '==============================================
            'ﾍｯﾀﾞｰ部分
            '==============================================
            For Each objNode In objDocument(XML_NODE_CONFIG)(XML_NODE_HEADER)
                '(ﾙｰﾌﾟ:ﾉｰﾄﾞ数)

                If objNode.Name = XML_NODE_ADD Then
                    '(ﾃﾞｰﾀ定義の場合)
                    Dim strItem As String = ""          'ｱｲﾃﾑ名
                    strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
                    ii += 1
                    If ii < 0 Then Continue For 'ｺﾏﾝﾄﾞID対策
                    ReDim Preserve strDenbunDtl(ii)
                    strDenbunDtl(ii) = Trim(objTelegramRecv.SELECT_HEADER(strItem))
                    If ii > 1 Then Exit For '応答ｽﾃｰﾀｽ以降対策
                End If
                If objNode.NodeType = Xml.XmlNodeType.Comment Then
                    If ii < 0 Then Continue For 'ｺﾏﾝﾄﾞID対策
                    Dim strItemName As String = ""      'ｱｲﾃﾑ名称
                    strItemName = objNode.Value
                    ReDim Preserve strDenbunDtlName(ii)
                    strDenbunDtlName(ii) = Trim(strItemName)
                    If ii > 1 Then Exit For '応答ｽﾃｰﾀｽ以降対策
                End If

            Next

            '==============================================
            'ﾃﾞｰﾀ部分
            '==============================================
            For Each objNode In objDocument(XML_NODE_CONFIG)(XML_NODE_ID_PREFIX & objTelegramRecv.FORMAT_ID)
                '(ﾙｰﾌﾟ:ﾉｰﾄﾞ数)

                If objNode.Name = XML_NODE_ADD Then
                    '(ﾃﾞｰﾀ定義の場合)
                    Dim strItem As String = ""          'ｱｲﾃﾑ名
                    strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
                    ii += 1
                    ReDim Preserve strDenbunDtl(ii)
                    strDenbunDtl(ii) = Trim(objTelegramRecv.SELECT_DATA(strItem))
                End If
                If objNode.NodeType = Xml.XmlNodeType.Comment Then
                    Dim strItemName As String = ""      'ｱｲﾃﾑ名称
                    strItemName = objNode.Value
                    ReDim Preserve strDenbunDtlName(ii)
                    strDenbunDtlName(ii) = Trim(strItemName)
                End If

            Next


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  表示用名称取得                                                                           "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 表示用名称取得
    ''' </summary>
    ''' <param name="strFTABLE_NAME">画面表示ﾏｽﾀ.ﾃｰﾌﾞﾙ名</param>
    ''' <param name="strFFIELD_NAME">画面表示ﾏｽﾀ.ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strFDISP_VALUE">画面表示ﾏｽﾀ.画面表示設定値</param>
    ''' <returns>画面表示ﾏｽﾀ.表示用名称</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function GetTDSP_DISP(ByVal strFTABLE_NAME As String _
                               , ByVal strFFIELD_NAME As String _
                               , ByVal strFDISP_VALUE As String _
                               ) _
                               As Object

        Dim objTDSP_DISP As New TBL_TDSP_DISP(Owner, ObjDb, ObjDbLog)
        Dim objRerutn As Object
        Dim intRet As RetCode
        '' ''Dim strMsg As String


        '*******************************************************
        ' ｼｽﾃﾑ変数取得
        '*******************************************************
        If IsNull(strFTABLE_NAME) = False _
           And IsNull(strFFIELD_NAME) = False _
           And IsNull(strFDISP_VALUE) = False _
           Then
            '(値が設定されている場合)

            objTDSP_DISP.FTABLE_NAME = strFTABLE_NAME       'ﾃｰﾌﾞﾙ名
            objTDSP_DISP.FFIELD_NAME = strFFIELD_NAME       'ﾌｨｰﾙﾄﾞ名
            objTDSP_DISP.FDISP_VALUE = strFDISP_VALUE       '画面表示設定値
            intRet = objTDSP_DISP.GET_TDSP_DISP(False)      '取得
            If intRet = RetCode.OK Then
                '(見つかった場合)
                objRerutn = objTDSP_DISP.FGAMEN_DISP        '表示用名称
            Else
                '(見つからなかった場合)
                objRerutn = strFDISP_VALUE
            End If

        Else
            '(値が設定されていない場合)

            objRerutn = strFDISP_VALUE

        End If

        Return objRerutn
    End Function
#End Region
#Region "　設備状況     取得                                                                        "
    '''***************************************************************************************************************
    ''' <summary>
    ''' 設備状況取得
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">設備状況ﾃｰﾌﾞﾙｸﾗｽ(ｲﾝｽﾀﾝｽ化された状態)</param>
    ''' <param name="strFEQ_ID">設備ID</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub IniTSTS_EQ_CTRL(ByRef objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL _
                             , ByVal strFEQ_ID As String _
                             )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '設備ID
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)              '特定


    End Sub
#End Region
#Region "　設備状況     設備状態設定                                                                "
    '''***************************************************************************************************************
    ''' <summary>
    ''' 設備状況     設備状態設定
    ''' </summary>
    ''' <param name="strFEQ_ID">設備ID</param>
    ''' <param name="strFEQ_STS">設備状態</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub Set_FEQ_STS(ByVal strFEQ_ID As String, ByVal strFEQ_STS As String)
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ

        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '設備ID
        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)     '特定

        objTSTS_EQ_CTRL.FEQ_STS = strFEQ_STS
        objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()


    End Sub
#End Region
#Region "　設備状況     要求状態設定                                                                "
    '''***************************************************************************************************************
    ''' <summary>
    ''' 設備状況     要求状態設定
    ''' </summary>
    ''' <param name="strFEQ_ID">設備ID</param>
    ''' <param name="intFEQ_REQ_STS">切り離し状態</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub Set_FEQ_REQ_STS(ByVal strFEQ_ID As String, ByVal intFEQ_REQ_STS As Integer)
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ

        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '設備ID
        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)     '特定

        objTSTS_EQ_CTRL.FEQ_REQ_STS = intFEQ_REQ_STS
        objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()


    End Sub
#End Region
#Region "　設備状況     切離状態取得                                                                "
    '''***************************************************************************************************************
    ''' <summary>
    ''' 設備状況     切離状態取得
    ''' </summary>
    ''' <param name="strFEQ_ID">設備ID</param>
    ''' <returns>設備状態</returns>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Function Get_EQ_CUT_STS(ByVal strFEQ_ID As String) As Integer
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ

        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '設備ID
        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)     '特定

        Return objTSTS_EQ_CTRL.FEQ_CUT_STS

    End Function
#End Region
#Region "　設備状況     切離状態設定                                                                "
    '''***************************************************************************************************************
    ''' <summary>
    ''' 設備状況     切離状態設定
    ''' </summary>
    ''' <param name="strFEQ_ID">設備ID</param>
    ''' <param name="intFEQ_CUT_STS">切り離し状態</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub Set_EQ_CUT_STS(ByVal strFEQ_ID As String, ByVal intFEQ_CUT_STS As Integer)
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ

        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '設備ID
        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)     '特定

        objTSTS_EQ_CTRL.FEQ_CUT_STS = intFEQ_CUT_STS
        objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()


    End Sub
#End Region
#Region "　設備状況     停止要因ｺｰﾄﾞ設定                                                            "
    '''***************************************************************************************************************
    ''' <summary>
    ''' 設備状況     停止要因ｺｰﾄﾞ設定
    ''' </summary>
    ''' <param name="strFEQ_ID">設備ID</param>
    ''' <param name="strFEQ_STOP_CD">停止要因ｺｰﾄﾞ</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub Set_FEQ_STOP_CD(ByVal strFEQ_ID As String, ByVal strFEQ_STOP_CD As String)
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ

        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '設備ID
        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)     '特定

        objTSTS_EQ_CTRL.FEQ_STOP_CD = strFEQ_STOP_CD
        objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()


    End Sub
#End Region
#Region "　設備状況詳細     設備応答ｺｰﾄﾞ設定                                                        "
    '''***************************************************************************************************************
    ''' <summary>
    ''' 設備状況詳細     設備応答ｺｰﾄﾞ設定
    ''' </summary>
    ''' <param name="strFEQ_ID">設備ID</param>
    ''' <param name="strFRES_CD_EQ">設備応答ｺｰﾄﾞ</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub Set_XSTS_EQ_CTRL_DTL_FRES_CD_EQ(ByVal strFEQ_ID As String, ByVal strFRES_CD_EQ As String)
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


        'Dim objXSTS_EQ_CTRL_DTL As New TBL_XSTS_EQ_CTRL_DTL(Owner, ObjDb, ObjDbLog)
        'objXSTS_EQ_CTRL_DTL.FEQ_ID = strFEQ_ID                      '設備ID
        'intRet = objXSTS_EQ_CTRL_DTL.GET_XSTS_EQ_CTRL_DTL(True)     '特定

        'objXSTS_EQ_CTRL_DTL.FRES_CD_EQ = strFRES_CD_EQ
        'objXSTS_EQ_CTRL_DTL.UPDATE_XSTS_EQ_CTRL_DTL()


    End Sub
#End Region


#Region "  在庫情報                 追加                                                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''   在庫情報                 追加
    ''' </summary>
    ''' <param name="objTRST_STOCK">在庫情報ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <param name="strFHINMEI_CD">品目ｺｰﾄﾞ</param>
    ''' <param name="strFLOT_NO">ﾛｯﾄ№</param>
    ''' <param name="dtmFARRIVE_DT">在庫発生日時</param>
    ''' <param name="intFHORYU_KUBUN">保留区分</param>
    ''' <param name="decFTR_VOL">搬送管理量</param>
    ''' <param name="decFTR_RES_VOL">搬送引当量</param>
    ''' <param name="dtmFUPDATE_DT">更新日時</param>
    ''' <param name="strXPROD_LINE">生産ﾗｲﾝ№</param>
    ''' <param name="strXKENSA_KUBUN">検査区分</param>
    ''' <param name="strXKENPIN_KUBUN">検品区分</param>
    ''' <param name="strXMAKER_CD">ﾒｰｶｺｰﾄﾞ</param>
    ''' <param name="intFST_FM">搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub TRST_STOCKAddProcess(ByRef objTRST_STOCK As TBL_TRST_STOCK _
                                  , ByVal strFHINMEI_CD As String _
                                  , ByVal strFLOT_NO As String _
                                  , ByVal dtmFARRIVE_DT As Nullable(Of Date) _
                                  , ByVal intFIN_KUBUN As Nullable(Of Integer) _
                                  , ByVal intFHORYU_KUBUN As Nullable(Of Integer) _
                                  , ByVal decFTR_VOL As Nullable(Of Decimal) _
                                  , ByVal decFTR_RES_VOL As Nullable(Of Decimal) _
                                  , ByVal dtmFUPDATE_DT As Nullable(Of Date) _
                                  , ByVal strXPROD_LINE As String _
                                  , ByVal strXKENSA_KUBUN As String _
                                  , ByVal strXKENPIN_KUBUN As String _
                                  , ByVal strXMAKER_CD As String _
                                  , ByVal intFST_FM As Nullable(Of Integer) _
                                  )
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        '*****************************************************
        '在庫情報                 重複ﾁｪｯｸ
        '*****************************************************
        'NOP


        '*****************************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ        取得
        '*****************************************************
        Dim intFST_FM_Temp As Nullable(Of Integer) = intFST_FM          '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        If IsNotNull(intFST_FM) Then
            '(何かしら値がｾｯﾄされている場合)
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.XTRK_BUF_NO_CONV = intFST_FM                'ｺﾝﾍﾞﾔ関連付け
            objTMST_TRK.GET_TMST_TRK(False)                         '取得
            If IsNotNull(objTMST_TRK.FTRK_BUF_NO) Then
                intFST_FM_Temp = objTMST_TRK.FTRK_BUF_NO            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            End If
        End If



        '*****************************************************
        '在庫情報           追加
        '*****************************************************
        objTRST_STOCK.FHINMEI_CD = strFHINMEI_CD                '品目ｺｰﾄﾞ
        objTRST_STOCK.FLOT_NO = strFLOT_NO                      'ﾛｯﾄ№
        objTRST_STOCK.FARRIVE_DT = dtmFARRIVE_DT                '在庫発生日時
        objTRST_STOCK.FIN_KUBUN = intFIN_KUBUN                  '入庫区分
        'objTRST_STOCK.FSEIHIN_KUBUN = intFSEIHIN_KUBUN          '製品区分
        'objTRST_STOCK.FZAIKO_KUBUN = intFZAIKO_KUBUN            '在庫区分
        objTRST_STOCK.FHORYU_KUBUN = intFHORYU_KUBUN            '保留区分
        objTRST_STOCK.FST_FM = intFST_FM_Temp                   '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTRST_STOCK.FTR_VOL = decFTR_VOL                      '搬送管理量
        objTRST_STOCK.FTR_RES_VOL = decFTR_RES_VOL              '搬送引当量
        objTRST_STOCK.FUPDATE_DT = dtmFUPDATE_DT                '更新日時
        'objTRST_STOCK.FHASU_FLAG = intFHASU_FLAG                '端数ﾌﾗｸﾞ
        'objTRST_STOCK.FLABEL_ID = strFLABEL_ID                  'ﾗﾍﾞﾙID
        'objTRST_STOCK.FSYUKKA_TO_CD = strFSYUKKA_TO_CD          '出荷先ｺｰﾄﾞ
        'objTRST_STOCK.FSYUKKA_TO_NAME = strFSYUKKA_TO_NAME      '出荷先名称
        objTRST_STOCK.XPROD_LINE = strXPROD_LINE                '生産ﾗｲﾝ№
        objTRST_STOCK.XKENSA_KUBUN = strXKENSA_KUBUN            '検査区分
        objTRST_STOCK.XKENPIN_KUBUN = strXKENPIN_KUBUN          '検品区分
        objTRST_STOCK.XMAKER_CD = strXMAKER_CD                  'ﾒｰｶｺｰﾄﾞ
        objTRST_STOCK.ADD_TRST_STOCK_ALL()                      '登録


    End Sub
#End Region
#Region "  ﾓｰﾄﾞ切替処理                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾓｰﾄﾞ切替処理
    ''' </summary>
    ''' <param name="strDSPEQ_ID">設備ID</param>
    ''' <param name="strDSPMODE">ﾓｰﾄﾞ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ModeChangeProcess(ByVal strDSPEQ_ID As String _
                               , ByVal strDSPMODE As String _
                                 )
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        Dim dtmNow As Date = Now
        Try

            '↓↓↓↓↓↓************************************************************************************************************
            'Checked Comment:A.Noto 2013/03/21 ﾌﾟﾛｸﾞﾗﾑ整理時のｺﾒﾝﾄｱｳﾄ

            ''************************
            ''初期設定
            ''************************
            'Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog) '設備状況ｸﾗｽ
            'Dim strSendFEQ_ID As String = FEQ_ID_JSYS0002      '通信する設備


            ''************************
            ''設備状況の特定
            ''************************
            'Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog) '設備状況ｸﾗｽ
            'objTSTS_EQ_CTRL.FEQ_ID = strDSPEQ_ID                                '設備ID
            'intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)                     '特定


            ''************************
            ''設備状況の更新
            ''************************
            'objTSTS_EQ_CTRL.FEQ_REQ_STS = FEQ_REQ_STS_SMODE_ON  '要求状態
            'objTSTS_EQ_CTRL.FUPDATE_DT = dtmNow                 '更新日時
            'objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()               '更新


            ''************************
            ''設備状況詳細   取得
            ''************************
            'Dim objXSTS_EQ_CTRL_DTL As New TBL_XSTS_EQ_CTRL_DTL(Owner, ObjDb, ObjDbLog) '設備状況詳細ｸﾗｽ
            'objXSTS_EQ_CTRL_DTL.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID
            'intRet = objXSTS_EQ_CTRL_DTL.GET_XSTS_EQ_CTRL_DTL(False)
            'If intRet = RetCode.NotFound Then
            '    '(見つからない場合)
            '    strMsg = ERRMSG_NOTFOUND_XSTS_EQ_CTRL_DTL & "[設備ID:" & objXSTS_EQ_CTRL_DTL.FEQ_ID & "]"
            '    Throw New UserException(strMsg)
            'End If


            ''************************
            ''設備状況詳細   更新
            ''************************
            'objXSTS_EQ_CTRL_DTL.FRES_CD_EQ = Nothing
            'objXSTS_EQ_CTRL_DTL.FUPDATE_DT = dtmNow
            'objXSTS_EQ_CTRL_DTL.UPDATE_XSTS_EQ_CTRL_DTL()
            '↑↑↑↑↑↑************************************************************************************************************

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞ,在庫情報,その他ﾊﾟﾚｯﾄに関係する情報全て削除                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞ,在庫情報,その他ﾊﾟﾚｯﾄに関係する情報全て削除
    ''' </summary>
    ''' <param name="strPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ClearDustProcess(ByVal strPALLET_ID As String)

        Try
            Dim intRet As RetCode                   '戻り値
            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '************************
            '在庫ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF.FPALLET_ID = strPALLET_ID                               'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)                         '特定


            '************************
            '在庫引当情報の特定
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '在庫引当情報
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID                               'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '特定
            If intRet = RetCode.OK Then
                '(見つかった場合)


                '************************
                '在庫引当情報の削除
                '************************
                objTSTS_HIKIATE = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)  '在庫引当情報ｸﾗｽ
                objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID
                objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()       '削除


            End If


            '************************
            '予約ﾊﾞｯﾌｧの解放
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = strPALLET_ID                          'ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                         '解放


            '************************
            '搬送指示QUEの削除
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '搬送指示QUE
            objTPLN_CARRY_QUE.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)                    '特定
            If intRet = RetCode.OK Then
                '(見つかった場合)
                objTPLN_CARRY_QUE.DELETE_TPLN_CARRY_QUE()   '削除
            End If


            '************************
            '搬送制御送信IFの削除
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '搬送制御送信IFｸﾗｽ
            objTLIF_TRNS_SEND.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '削除


            '************************
            'ｼﾘｱﾙ関連付け削除
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)       'ｼﾘｱﾙ関連付けｸﾗｽ
            objTPRG_SERIAL.FPALLET_ID = strPALLET_ID                                'ﾊﾟﾚｯﾄID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                     '削除


            '************************
            '搬送制御受信IFの削除
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '搬送制御受信IFｸﾗｽ
            objTLIF_TRNS_RECV.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV_PALLET()                        '削除


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region


    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/10/19  空棚引当に、ｺﾝﾍﾞｱの切離しも条件に追加。切離しされていたら、空棚引当の対象としない。
#Region "  ｺﾝﾍﾞｱ切離ﾁｪｯｸ            (SVR_100201)                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾍﾞｱ切離ﾁｪｯｸ
    ''' </summary>
    ''' <param name="strFEQ_ID_CRANE">ｸﾚｰﾝ設備ID</param>
    ''' <param name="intFBUF_FM">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(FM)</param>
    ''' <param name="intFBUF_TO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(TO)</param>
    ''' <returns>True:ｺﾝﾍﾞｱ切離有             False:ｺﾝﾍﾞｱ切離無</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SVR_100201_CheckTMST_CNV_CRANE(ByVal strFEQ_ID_CRANE As String _
                                                 , ByVal intFBUF_FM As Nullable(Of Integer) _
                                                 , ByVal intFBUF_TO As Nullable(Of Integer) _
                                                 ) _
                                                 As Boolean
        Dim blnReturn As Boolean = False
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Dim intRet As RetCode                   '戻り値


        '************************************************
        'ﾁｪｯｸ
        '************************************************
        If IsNull(intFBUF_FM) Then Return blnReturn


        '************************************************
        'ｺﾝﾍﾞｱｸﾚｰﾝﾏｽﾀ       取得
        '************************************************
        Dim objTMST_CNV_CRANE_Ary As New TBL_TMST_CNV_CRANE(Owner, ObjDb, ObjDbLog)
        objTMST_CNV_CRANE_Ary.FEQ_ID_CRANE = strFEQ_ID_CRANE                'ｸﾚｰﾝ設備ID
        objTMST_CNV_CRANE_Ary.FINOUT_KUBUN = FINOUT_KUBUN_SIN               '入出庫区分
        intRet = objTMST_CNV_CRANE_Ary.GET_TMST_CNV_CRANE_ANY()
        If intRet = RetCode.OK Then
            '(見つかった場合)
            For Each objTMST_CNV_CRANE As TBL_TMST_CNV_CRANE In objTMST_CNV_CRANE_Ary.ARYME
                '(ﾙｰﾌﾟ:対象となるｺﾝﾍﾞｱ数)


                '************************************************
                'ﾁｪｯｸ
                '************************************************
                If objTMST_CNV_CRANE.FEQ_CUT_STS = FEQ_CUT_STS_SCHECK_OFF Then Continue For


                '************************************************
                '搬送起動判定ﾏｽﾀ            取得
                '************************************************
                Dim objTMST_CHECK_EQ As New TBL_TMST_CHECK_EQ(Owner, ObjDb, ObjDbLog)
                objTMST_CHECK_EQ.FBUF_FM = intFBUF_FM                                   '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTMST_CHECK_EQ.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                        '元ｸﾚｰﾝ設備ID
                objTMST_CHECK_EQ.FBUF_TO = intFBUF_TO                                   '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTMST_CHECK_EQ.FEQ_ID_CRANE_TO = objTMST_CNV_CRANE.FEQ_ID_CRANE       '先ｸﾚｰﾝ設備ID
                objTMST_CHECK_EQ.FCHECK_EQ_ID = objTMST_CNV_CRANE.FEQ_ID_CNV            '判定設備ID
                intRet = objTMST_CHECK_EQ.GET_TMST_CHECK_EQ(False)
                If intRet <> RetCode.OK Then
                    '(見つからなかった場合)
                    Continue For
                End If


                '************************************************
                '設備状況                   取得
                '************************************************
                Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL, objTMST_CNV_CRANE.FEQ_ID_CNV)


                '************************************************
                '判定ﾁｪｯｸ
                '************************************************
                If objTSTS_EQ_CTRL.FEQ_CUT_STS <> objTMST_CNV_CRANE.FEQ_CUT_STS Then
                    '(切離ﾁｪｯｸがｴﾗｰの場合)
                    blnReturn = True
                    Exit For
                End If


            Next

        End If


        Return blnReturn
    End Function
#End Region
    '↑↑↑↑↑↑************************************************************************************************************
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/10/20  在庫引当に、ｺﾝﾍﾞｱの切離しも条件に追加。切離しされていたら、在庫引当の対象としない。
#Region "  ｺﾝﾍﾞｱ切離ﾁｪｯｸ            (SVR_100202)                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾍﾞｱ切離ﾁｪｯｸ
    ''' </summary>
    ''' <param name="strFPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <param name="intFBUF_FM">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(FM)</param>
    ''' <param name="intFBUF_TO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(TO)</param>
    ''' <returns>True:ｺﾝﾍﾞｱ切離有             False:ｺﾝﾍﾞｱ切離無</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SVR_100202_CheckTMST_CNV_CRANE(ByVal strFPALLET_ID As String _
                                                 , ByVal intFBUF_FM As Nullable(Of Integer) _
                                                 , ByVal intFBUF_TO As Nullable(Of Integer) _
                                                 ) _
                                                 As Boolean
        Dim blnReturn As Boolean = False
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Dim intRet As RetCode                   '戻り値


        '************************************************
        'ﾁｪｯｸ
        '************************************************
        If IsNull(intFBUF_TO) Then Return blnReturn


        '************************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ        取得
        '自動倉庫以外の場合は、ﾁｪｯｸなし
        '************************************************
        Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        objTMST_TRK.FTRK_BUF_NO = intFBUF_FM
        objTMST_TRK.GET_TMST_TRK()
        If objTMST_TRK.FBUF_KIND <> FBUF_KIND_SASRS Then
            '(自動倉庫以外の場合)
            Return blnReturn
        End If


        '************************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(棚)       取得
        '************************************************
        Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        objTPRG_TRK_BUF_ASRS.FPALLET_ID = strFPALLET_ID
        objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()


        '************************************************
        'ｸﾚｰﾝﾏｽﾀ                特定
        '************************************************
        Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)
        objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO        'ﾊﾞｯﾌｧ№
        objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU         '列
        intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                           '特定
        If intRet = RetCode.NotFound Then
            '(見つからない場合)
            strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
            Throw New UserException(strMsg)
        End If



        '************************************************
        'ｺﾝﾍﾞｱｸﾚｰﾝﾏｽﾀ       取得
        '************************************************
        Dim objTMST_CNV_CRANE_Ary As New TBL_TMST_CNV_CRANE(Owner, ObjDb, ObjDbLog)
        objTMST_CNV_CRANE_Ary.FEQ_ID_CRANE = objTMST_CRANE.FEQ_ID           'ｸﾚｰﾝ設備ID
        objTMST_CNV_CRANE_Ary.FINOUT_KUBUN = FINOUT_KUBUN_SOUT              '入出庫区分
        intRet = objTMST_CNV_CRANE_Ary.GET_TMST_CNV_CRANE_ANY()
        If intRet = RetCode.OK Then
            '(見つかった場合)
            For Each objTMST_CNV_CRANE As TBL_TMST_CNV_CRANE In objTMST_CNV_CRANE_Ary.ARYME
                '(ﾙｰﾌﾟ:対象となるｺﾝﾍﾞｱ数)


                '************************************************
                'ﾁｪｯｸ
                '************************************************
                If objTMST_CNV_CRANE.FEQ_CUT_STS = FEQ_CUT_STS_SCHECK_OFF Then Continue For


                '************************************************
                '搬送起動判定ﾏｽﾀ            取得
                '************************************************
                Dim objTMST_CHECK_EQ As New TBL_TMST_CHECK_EQ(Owner, ObjDb, ObjDbLog)
                objTMST_CHECK_EQ.FBUF_FM = intFBUF_FM                                   '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTMST_CHECK_EQ.FEQ_ID_CRANE_FM = objTMST_CNV_CRANE.FEQ_ID_CRANE       '元ｸﾚｰﾝ設備ID
                objTMST_CHECK_EQ.FBUF_TO = intFBUF_TO                                   '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTMST_CHECK_EQ.FEQ_ID_CRANE_TO = FEQ_ID_SKOTEI                        '先ｸﾚｰﾝ設備ID
                objTMST_CHECK_EQ.FCHECK_EQ_ID = objTMST_CNV_CRANE.FEQ_ID_CNV            '判定設備ID
                intRet = objTMST_CHECK_EQ.GET_TMST_CHECK_EQ(False)
                If intRet <> RetCode.OK Then
                    '(見つからなかった場合)
                    Continue For
                End If


                '************************************************
                '設備状況                   取得
                '************************************************
                Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL, objTMST_CNV_CRANE.FEQ_ID_CNV)


                '************************************************
                '判定ﾁｪｯｸ
                '************************************************
                If objTSTS_EQ_CTRL.FEQ_CUT_STS <> objTMST_CNV_CRANE.FEQ_CUT_STS Then
                    '(切離ﾁｪｯｸがｴﾗｰの場合)
                    blnReturn = True
                    Exit For
                End If


            Next

        End If


        Return blnReturn
    End Function
#End Region
    '↑↑↑↑↑↑************************************************************************************************************

#Region "  出庫指示引当処理01           (SVR_010002)                                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出庫指示引当処理             (SVR_010002)
    ''' </summary>
    ''' <param name="objTMST_CRANE">ｸﾚｰﾝﾏｽﾀ</param>
    ''' <param name="intLoopCount01">2次ﾙｰﾌﾟｶｳﾝﾄ</param>
    ''' <param name="intLoopCount02">3次ﾙｰﾌﾟｶｳﾝﾄ</param>
    ''' <param name="blnCheckASRS_OUT">ｸﾚｰﾝに対し、出庫指示しているか否かをﾁｪｯｸするか否か</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SVR_010002_Process01(ByVal objTMST_CRANE As TBL_TMST_CRANE _
                                       , ByRef intLoopCount01 As Integer _
                                       , ByRef intLoopCount02 As Integer _
                                       , Optional ByVal blnCheckASRS_OUT As Boolean = True _
                                       ) As RetCode
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            ''************************
            ''初期処理
            ''************************
            'Dim dtmNow01 As Date = Now
            'Dim intLoopCount01 As Integer = 0
            'Dim intLoopCount02 As Integer = 0
            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            '************************************************************************************************************************************************************************
            '************************************************************************************************************************************************************************
            'ｸﾚｰﾝﾏｽﾀ        取得
            'ｸﾚｰﾝ毎にﾙｰﾌﾟ(1次)(SVR_010002からの起動の場合に限る)
            '************************************************************************************************************************************************************************
            '************************************************************************************************************************************************************************
            '************************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ﾁｪｯｸ用)       取得
            'ｸﾚｰﾝに対し、出庫指示が送信されているか否かをﾁｪｯｸ
            '************************************************
            If blnCheckASRS_OUT = True Then
                '(ﾁｪｯｸする場合)

                Dim blnASRS_OUT As Boolean = False      '出庫ﾄﾗｯｷﾝｸﾞ存在ﾌﾗｸﾞ
                Dim objTPRG_TRK_BUF_ASRS_CHECK As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_ASRS_CHECK.FTRK_BUF_NO = objTMST_CRANE.FTRK_BUF_NO          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_ASRS_CHECK.objTMST_CRANE = objTMST_CRANE                    'ｸﾚｰﾝﾏｽﾀ
                intRet = objTPRG_TRK_BUF_ASRS_CHECK.GET_TPRG_TRK_BUF_RESERVE_RAC(True)      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [入出庫予約棚]
                If intRet = RetCode.OK Then
                    For ii As Integer = 0 To UBound(objTPRG_TRK_BUF_ASRS_CHECK.ARYME)
                        '(ﾙｰﾌﾟ:入出庫予約棚数)

                        If objTPRG_TRK_BUF_ASRS_CHECK.ARYME(ii).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Then
                            '(搬出予約の場合)
                            blnASRS_OUT = True
                            Continue For
                        End If

                    Next
                End If
                If blnASRS_OUT = True Then Return RetCode.OK

            End If


            '************************************************************************************************************************************************************************
            '************************************************************************************************************************************************************************
            'ﾊﾞｰｽ数だけ出庫指示
            'ﾊﾞｰｽ毎にﾙｰﾌﾟ(2次)
            '************************************************************************************************************************************************************************
            '************************************************************************************************************************************************************************
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2012/12/21 処理時間がかかり、ﾌﾘｰｽﾞする現象を修正
            '                                出庫する可能性がある全てのSTを配列にｾｯﾄするように修正


            '************************************************
            'SQL文          作成
            '************************************************
            Dim strSQL As String = ""           'SQL文
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim strAryFTRK_BUF_NO_BERTH() As String
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "    TPRG_TRK_BUF.FTR_TO AS FTR_TO"
            strSQL &= vbCrLf & "   ,MAX(TPLN_CARRY_QUE.FPRIORITY) AS FPRIORITY"
            strSQL &= vbCrLf & "   ,MIN(TPLN_CARRY_QUE.FCARRYQUE_D) AS FCARRYQUE_D"
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE "
            strSQL &= vbCrLf & "   ,TPRG_TRK_BUF "
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "    1 = 1 "
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID "               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧと結合
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FCARRYQUE_DIR_STS = " & FCARRYQUE_DIR_STS_SNON & ""  '搬送指示QUE    .搬送指示状況
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FCARRYQUE_KUBUN IN (" & FCARRYQUE_KUBUN_SOUT & ") "  '搬送指示QUE    .指示区分
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FEQ_ID = '" & objTMST_CRANE.FEQ_ID & "' "            '搬送指示QUE    .設備ID
            strSQL &= vbCrLf & " GROUP BY "
            strSQL &= vbCrLf & "    TPRG_TRK_BUF.FTR_TO "
            strSQL &= vbCrLf & " ORDER BY "
            strSQL &= vbCrLf & "    FPRIORITY DESC "
            strSQL &= vbCrLf & "   ,FCARRYQUE_D "
            strSQL &= vbCrLf & ""
            'strSQL &= vbCrLf & " SELECT DISTINCT "
            'strSQL &= vbCrLf & "    FBUF_TO "
            'strSQL &= vbCrLf & " FROM  "
            'strSQL &= vbCrLf & "    TMST_ROUTE "
            'strSQL &= vbCrLf & " WHERE "
            'strSQL &= vbCrLf & "        1 = 1 "
            'strSQL &= vbCrLf & "    AND FBUF_FM = " & FTRK_BUF_NO_J9000
            'strSQL &= vbCrLf & " ORDER BY "
            'strSQL &= vbCrLf & "    FBUF_TO "
            'strSQL &= vbCrLf & ""


            '************************************************
            'ﾃﾞｰﾀ           取得
            '************************************************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                ReDim Preserve strAryFTRK_BUF_NO_BERTH(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                For kk As Integer = LBound(strAryFTRK_BUF_NO_BERTH) To UBound(strAryFTRK_BUF_NO_BERTH)
                    strAryFTRK_BUF_NO_BERTH(kk) = objDataSet.Tables(strDataSetName).Rows(kk)("FTR_TO")
                Next kk
            Else
                Return RetCode.OK
                'Throw New UserException(ERRMSG_NOTFOUND_TMST_ROUTE & "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FTRK_BUF_NO_J9000 & "]")
            End If



            'Dim strAryFTRK_BUF_NO_BERTH(8) As String
            'strAryFTRK_BUF_NO_BERTH(0) = FTRK_BUF_NO_J1
            'strAryFTRK_BUF_NO_BERTH(1) = FTRK_BUF_NO_J2
            'strAryFTRK_BUF_NO_BERTH(2) = FTRK_BUF_NO_J3
            'strAryFTRK_BUF_NO_BERTH(3) = FTRK_BUF_NO_J4
            'strAryFTRK_BUF_NO_BERTH(4) = FTRK_BUF_NO_J5
            'strAryFTRK_BUF_NO_BERTH(5) = FTRK_BUF_NO_J6
            'strAryFTRK_BUF_NO_BERTH(6) = FTRK_BUF_NO_J7
            'strAryFTRK_BUF_NO_BERTH(7) = FTRK_BUF_NO_J8
            'strAryFTRK_BUF_NO_BERTH(8) = ""

            '↑↑↑↑↑↑************************************************************************************************************

            For ii As Integer = 0 To UBound(strAryFTRK_BUF_NO_BERTH)
                '(ﾙｰﾌﾟ:1～8番ﾊﾞｰｽとその他)


                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:N.Dounoshita 2012/12/21 処理時間がかかり、ﾌﾘｰｽﾞする現象を修正
                '                                出庫する可能性がある全てのSTを配列にｾｯﾄするように修正

                ''************************************************
                ''ﾊﾞｰｽ以外のﾊﾟﾀｰﾝの条件文字列作成
                ''************************************************
                'If ii = UBound(strAryFTRK_BUF_NO_BERTH) Then
                '    For jj As Integer = 0 To UBound(strAryFTRK_BUF_NO_BERTH) - 1
                '        If jj = 0 Then
                '            strAryFTRK_BUF_NO_BERTH(ii) = strAryFTRK_BUF_NO_BERTH(jj)
                '        Else
                '            strAryFTRK_BUF_NO_BERTH(ii) &= ", " & strAryFTRK_BUF_NO_BERTH(jj)
                '        End If
                '    Next
                'End If

                '↑↑↑↑↑↑************************************************************************************************************


                intLoopCount01 += 1
                '************************
                '搬送指示QUE        取得
                '************************
                Dim objAryTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                objAryTPLN_CARRY_QUE.FEQ_ID = objTMST_CRANE.FEQ_ID                      '設備ID
                objAryTPLN_CARRY_QUE.FTR_TO = strAryFTRK_BUF_NO_BERTH(ii)                     '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:N.Dounoshita 2012/12/21 処理時間がかかり、ﾌﾘｰｽﾞする現象を修正
                '                                出庫する可能性がある全てのSTを配列にｾｯﾄするように修正

                intRet = objAryTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_SEND_OUT_FTR_TO(WhereMode.IN_Mode)         '取得

                'If ii <> UBound(strAryFTRK_BUF_NO_BERTH) Then
                '    intRet = objAryTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_SEND_OUT_FTR_TO(WhereMode.IN_Mode)         '取得
                'Else
                '    intRet = objAryTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_SEND_OUT_FTR_TO(WhereMode.NOTIN_Mode)      '取得
                'End If

                '↑↑↑↑↑↑************************************************************************************************************

                If intRet <> RetCode.OK Then
                    '(搬送指示QUEにﾚｺｰﾄﾞがなかった場合)
                    Continue For
                End If


                ''************************
                ''搬送指示QUE        取得
                ''************************
                'Dim objAryTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                'objAryTPLN_CARRY_QUE.FCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SOUT             '指示区分
                'objAryTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON         '搬送指示状況
                'objAryTPLN_CARRY_QUE.FEQ_ID = objTMST_CRANE.FEQ_ID                      '設備ID
                'objAryTPLN_CARRY_QUE.ORDER_BY = "   FPRIORITY DESC"                     '並び
                'objAryTPLN_CARRY_QUE.ORDER_BY &= ", FCARRYQUE_D "                       '並び
                'objAryTPLN_CARRY_QUE.ORDER_BY &= ", FCARRYQUE_ORDER "                   '並び
                'intRet = objAryTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_ANY()                  '取得
                'If intRet <> RetCode.OK Then
                '    '(搬送指示QUEにﾚｺｰﾄﾞがなかった場合)
                '    Continue For
                'End If


                '************************************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ﾊﾞｰｽ)         取得
                '************************************************
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:N.Dounoshita 2012/12/21 処理時間がかかり、ﾌﾘｰｽﾞする現象を修正
                '                                出庫する可能性がある全てのSTを配列にｾｯﾄするように修正
                'If ii <> UBound(strAryFTRK_BUF_NO_BERTH) Then
                '    '(ﾊﾞｰｽの場合)
                '↑↑↑↑↑↑************************************************************************************************************

                Dim objTPRG_TRK_BUF_BERTH As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_BERTH.FTRK_BUF_NO = strAryFTRK_BUF_NO_BERTH(ii)           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                intRet = objTPRG_TRK_BUF_BERTH.GET_TPRG_TRK_BUF_AKI_HIRA()                '取得
                If intRet <> RetCode.OK Then
                    '(空きﾊﾞｯﾌｧがなかった場合)
                    Continue For
                End If

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:N.Dounoshita 2012/12/21 処理時間がかかり、ﾌﾘｰｽﾞする現象を修正
                '                                出庫する可能性がある全てのSTを配列にｾｯﾄするように修正
                'End If
                '↑↑↑↑↑↑************************************************************************************************************


                '************************************************************************************************************************************************************************
                '************************************************************************************************************************************************************************
                '出庫指示
                '出庫指示数だけにﾙｰﾌﾟ(3次)
                '************************************************************************************************************************************************************************
                '************************************************************************************************************************************************************************
                Dim blnSizi As Boolean = False      '出庫指示実行ﾌﾗｸﾞ
                For Each objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE In objAryTPLN_CARRY_QUE.ARYME
                    '(ﾙｰﾌﾟ:ｸﾚｰﾝ毎の搬送指示QUEのﾚｺｰﾄﾞ数)
                    intLoopCount02 += 1


                    Try


                        '************************
                        '出庫指示処理
                        '************************
                        Dim objSVR_010201 As New SVR_010201(Owner, ObjDb, ObjDbLog) '出庫指示ｸﾗｽ
                        objSVR_010201.TPLN_CARRY_QUE = objTPLN_CARRY_QUE            '搬送指示QUE
                        intRet = objSVR_010201.ExecCmdFunction()
                        If intRet = RetCode.OK Then
                            '(出庫指示された場合)


                            blnSizi = True
                            '↓↓↓↓↓↓************************************************************************************************************
                            'SystemMate:N.Dounoshita 2012/08/15  完了報告が受信しない場合、自動で完了させるが、自動で完了させると搬送指示QUEにﾚｺｰﾄﾞがなくなり、ｴﾗｰとなるのでその対策
                            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)
                            If intRet = RetCode.OK Then
                                '↑↑↑↑↑↑************************************************************************************************************
                                objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND
                                objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()
                                '↓↓↓↓↓↓************************************************************************************************************
                                'SystemMate:N.Dounoshita 2012/08/15  完了報告が受信しない場合、自動で完了させるが、自動で完了させると搬送指示QUEにﾚｺｰﾄﾞがなくなり、ｴﾗｰとなるのでその対策
                            End If
                            '↑↑↑↑↑↑************************************************************************************************************


                            Exit For
                        End If


                    Catch ex As ContinueForException
                        ObjDb.RollBack()        'ﾛｰﾙﾊﾞｯｸ
                        ObjDb.BeginTrans()      'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    Catch ex As UserException
                        Call ComUser(ex, MeSyoriID)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                        ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                        ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    Catch ex As Exception
                        Call ComError(ex, MeSyoriID)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                        ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                        ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    Finally
                        ObjDb.Commit()      'ｺﾐｯﾄ
                        ObjDb.BeginTrans()  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    End Try


                    '************************************************************************************************************************
                    'ｸﾚｰﾝID、行き先STが同じﾄﾗｯｷﾝｸﾞであれば、全て同じﾁｪｯｸのはずなので、最初のﾄﾗｯｷﾝｸﾞだけ処理すれば良い。
                    '最初のﾄﾗｯｷﾝｸﾞが出庫出来なければ、その後も全て出庫出来ないはずだという考え。
                    '************************************************************************************************************************
                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:N.Dounoshita 2012/12/21 処理時間がかかり、ﾌﾘｰｽﾞする現象を修正
                    '                                出庫する可能性がある全てのSTを配列にｾｯﾄするように修正
                    Exit For
                    'If ii <> UBound(strAryFTRK_BUF_NO_BERTH) Then Exit For
                    '↑↑↑↑↑↑************************************************************************************************************


                Next
                If blnSizi = True Then Exit For


            Next


            ''************************
            ''正常完了
            ''************************
            'Dim objDiff As TimeSpan = Now - dtmNow01
            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
            '                 FLOG_DATA_TRN_SEND_NORMAL _
            '                 & "[処理時間:" & TO_STRING(TO_DECIMAL(objDiff.TotalMilliseconds / 1000)) & "]" _
            '                 & "[ﾙｰﾌﾟ回数01:" & TO_STRING(intLoopCount01) & "]" _
            '                 & "[ﾙｰﾌﾟ回数02:" & TO_STRING(intLoopCount02) & "]" _
            '                 )


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


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '変更履歴
#Region "  変更履歴詳細追加(TMST_ITEM)                                                              "
    '''****************************************************************************************************
    ''' <summary>
    ''' 変更履歴詳細追加
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <param name="MeSyoriID">処理ID</param>
    ''' <param name="objTMST_ITEM_Before">品名ﾏｽﾀ更新前ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objTMST_ITEM_After">品名ﾏｽﾀ更新後ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    '''****************************************************************************************************
    Public Sub Add_TEVD_TBLCHANGE_DTL_TMST_ITEM(ByVal strDenbunDtl() As String _
                                              , ByVal MeSyoriID As String _
                                              , ByVal objTMST_ITEM_Before As TBL_TMST_ITEM _
                                              , ByVal objTMST_ITEM_After As TBL_TMST_ITEM _
                                              )
        Try
            'Dim intRet As RetCode
            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ

            '***********************
            '端末ﾏｽﾀの特定
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)
            objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '端末ID     ｾｯﾄ
            Call objTDSP_TERM.GET_TDSP_TERM(False)              '特定


            '***********************
            'ﾕｰｻﾞｰﾏｽﾀの特定
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)    'ﾕｰｻﾞｰID
            Call objTMST_USER.GET_TMST_USER(False)              '特定

            '***********************
            '単位ﾏｽﾀの特定
            '***********************
            Dim objTMST_UNIT_Before As New TBL_TMST_UNIT(Owner, ObjDb, ObjDbLog)
            Dim objTMST_UNIT_After As New TBL_TMST_UNIT(Owner, ObjDb, ObjDbLog)
            objTMST_UNIT_Before.FTANI = objTMST_ITEM_Before.FTANI
            objTMST_UNIT_After.FTANI = objTMST_ITEM_After.FTANI
            If Not (TO_STRING(objTMST_UNIT_Before.FTANI) Is Nothing) Or TO_STRING(objTMST_UNIT_Before.FTANI) <> "" Then
                Call objTMST_UNIT_Before.GET_TMST_UNIT(False)
            End If
            If Not (TO_STRING(objTMST_UNIT_After.FTANI) Is Nothing) Or TO_STRING(objTMST_UNIT_After.FTANI) <> "" Then
                Call objTMST_UNIT_After.GET_TMST_UNIT(False)
            End If


            '**************************************
            'ﾃｰﾌﾞﾙ変更履歴      追加
            '**************************************
            Dim objTEVD_TBLCHANGE As New TBL_TEVD_TBLCHANGE(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE.FLOG_NO = 0                               'ﾛｸﾞ№
            objTEVD_TBLCHANGE.FSYORI_ID = MeSyoriID                     '処理ID
            objTEVD_TBLCHANGE.FHASSEI_DT = Now                          '発生日時
            objTEVD_TBLCHANGE.FTERM_ID = objTDSP_TERM.FTERM_ID          '端末ID
            objTEVD_TBLCHANGE.FTERM_NAME = objTDSP_TERM.FTERM_NAME      '端末名
            objTEVD_TBLCHANGE.FUSER_ID = objTMST_USER.FUSER_ID        'ﾕｰｻﾞｰID
            objTEVD_TBLCHANGE.FUSER_NAME = objTMST_USER.FUSER_NAME      'ﾕｰｻﾞｰ名
            objTEVD_TBLCHANGE.FREASON_CD = Nothing                      '理由ｺｰﾄﾞ
            objTEVD_TBLCHANGE.FREASON = strDenbunDtl(DSPREASON)         '理由
            Call objTEVD_TBLCHANGE.ADD_TEVD_TBLCHANGE_SEQ()             '追加


            '**************************************
            'ﾃｰﾌﾞﾙ変更履歴詳細  追加
            '**************************************
            Dim objTEVD_TBLCHANGE_DTL As New TBL_TEVD_TBLCHANGE_DTL(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE_DTL.FLOG_NO = objTEVD_TBLCHANGE.FLOG_NO               'ﾛｸﾞ№
            objTEVD_TBLCHANGE_DTL.FSYORI_ID = objTEVD_TBLCHANGE.FSYORI_ID           '処理ID
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TMST_ITEM"                         'ﾃｰﾌﾞﾙ名

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FHINMEI_CD"                                            'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FHINMEI_CD)             '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FHINMEI_CD)               '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FHINMEI"                                               'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FHINMEI)                '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FHINMEI)                  '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加


            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FNUM_IN_CASE"                                          'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FNUM_IN_CASE)           '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FNUM_IN_CASE)             '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTANI"                                                 'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FTANI)                  '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FTANI)                    '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDECIMAL_POINT"                                        'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FDECIMAL_POINT)         '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FDECIMAL_POINT)           '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FNUM_IN_PALLET"                                        'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FNUM_IN_PALLET)         '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FNUM_IN_PALLET)           '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FZAIKO_KUBUN"                                          'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FZAIKO_KUBUN)           '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FZAIKO_KUBUN)             '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRAC_FORM"                                             'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FRAC_FORM)              '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FRAC_FORM)                '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_DT"                                             'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FENTRY_DT)              '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FENTRY_DT)                '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_USER_ID"                                        'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FENTRY_USER_ID)         '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FENTRY_USER_ID)           '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_USER_NAME"                                      'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FENTRY_USER_NAME)       '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FENTRY_USER_NAME)         '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_TERM_ID"                                        'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FENTRY_TERM_ID)         '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FENTRY_TERM_ID)           '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_DT"                                            'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FUPDATE_DT)             '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FUPDATE_DT)               '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_USER_ID"                                       'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FUPDATE_USER_ID)        '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FUPDATE_USER_ID)          '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_USER_NAME"                                     'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FUPDATE_USER_NAME)      '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FUPDATE_USER_NAME)        '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_TERM_ID"                                       'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FUPDATE_TERM_ID)        '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FUPDATE_TERM_ID)          '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加



        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  変更履歴詳細追加(TMST_USER)                                                              "
    '''****************************************************************************************************
    ''' <summary>
    ''' 変更履歴詳細追加
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <param name="MeSyoriID">処理ID</param>
    ''' <param name="objTMST_USER_Before">更新前ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objTMST_USER_DSP_Before">更新前ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objTMST_USER_After">更新後ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objTMST_USER_DSP_After">更新後ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    '''****************************************************************************************************
    Public Sub Add_TEVD_TBLCHANGE_DTL_TMST_USER(ByVal strDenbunDtl() As String _
                                              , ByVal MeSyoriID As String _
                                              , ByVal objTMST_USER_Before As TBL_TMST_USER _
                                              , ByVal objTMST_USER_DSP_Before As TBL_TMST_USER_DSP _
                                              , ByVal objTMST_USER_After As TBL_TMST_USER _
                                              , ByVal objTMST_USER_DSP_After As TBL_TMST_USER_DSP _
                                              )
        Try
            '' ''Dim intRet As RetCode
            '' ''Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            Dim strYuukou As String = "○"          '有効表示
            Dim strMukou As String = "×"           '無効表示


            '***********************
            '端末ﾏｽﾀの特定
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)
            If IsNull(strDenbunDtl(DSPTERM_ID)) = False Then
                objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '端末ID     ｾｯﾄ
                Call objTDSP_TERM.GET_TDSP_TERM(False)              '特定
            End If

            '***********************
            'ﾕｰｻﾞｰﾏｽﾀの特定
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            If IsNull(strDenbunDtl(DSPUSER_ID)) = False Then
                objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)    'ﾕｰｻﾞｰID
                Call objTMST_USER.GET_TMST_USER(False)              '特定
            End If

            '**************************************
            'ﾃｰﾌﾞﾙ変更履歴      追加
            '**************************************
            Dim objTEVD_TBLCHANGE As New TBL_TEVD_TBLCHANGE(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE.FLOG_NO = 0                               'ﾛｸﾞ№
            objTEVD_TBLCHANGE.FSYORI_ID = MeSyoriID                     '処理ID
            objTEVD_TBLCHANGE.FHASSEI_DT = Now                          '発生日時
            objTEVD_TBLCHANGE.FTERM_ID = objTDSP_TERM.FTERM_ID          '端末ID
            objTEVD_TBLCHANGE.FTERM_NAME = objTDSP_TERM.FTERM_NAME      '端末名
            objTEVD_TBLCHANGE.FUSER_ID = objTMST_USER.FUSER_ID          'ﾕｰｻﾞｰID
            objTEVD_TBLCHANGE.FUSER_NAME = objTMST_USER.FUSER_NAME      'ﾕｰｻﾞｰ名
            objTEVD_TBLCHANGE.FREASON_CD = Nothing                      '理由ｺｰﾄﾞ
            objTEVD_TBLCHANGE.FREASON = strDenbunDtl(DSPREASON)         '理由
            Call objTEVD_TBLCHANGE.ADD_TEVD_TBLCHANGE_SEQ()             '追加


            '**************************************
            '更新前ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄの初期化
            '**************************************
            If IsNull(objTMST_USER_Before) Then
                objTMST_USER_Before = New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            End If
            If IsNull(objTMST_USER_After) Then
                objTMST_USER_After = New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            End If


            '**************************************
            'ﾃｰﾌﾞﾙ変更履歴詳細  追加
            '**************************************
            '===========================
            'ﾕｰｻﾞｰﾏｽﾀ
            '===========================
            Dim objTEVD_TBLCHANGE_DTL As New TBL_TEVD_TBLCHANGE_DTL(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE_DTL.FLOG_NO = objTEVD_TBLCHANGE.FLOG_NO               'ﾛｸﾞ№
            objTEVD_TBLCHANGE_DTL.FSYORI_ID = objTEVD_TBLCHANGE.FSYORI_ID           '処理ID
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TMST_USER"                         'ﾃｰﾌﾞﾙ名

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUSER_ID"                                                  'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FUSER_ID)                   '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FUSER_ID)                     '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FPASS_WORD"                                                'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FPASS_WORD)                 '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FPASS_WORD)                   '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUSER_NAME"                                                'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FUSER_NAME)                 '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FUSER_NAME)                   '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FLOGIN_ID"                                                 'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FLOGIN_ID)                  '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FLOGIN_ID)                    '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FPASS_WORDUP_DT"                                           'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FPASS_WORDUP_DT)            '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FPASS_WORDUP_DT)              '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUSER_ATEST"                                               'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FUSER_ATEST)                '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FUSER_ATEST)                  '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FWARNING_COUNT"                                            'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FWARNING_COUNT)             '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FWARNING_COUNT)               '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FLOCK_DT"                                                  'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FLOCK_DT)                   '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FLOCK_DT)                     '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_DT"                                                 'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FENTRY_DT)                  '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FENTRY_DT)                    '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_USER_ID"                                            'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FENTRY_USER_ID)             '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FENTRY_USER_ID)               '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_USER_NAME"                                          'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FENTRY_USER_NAME)           '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FENTRY_USER_NAME)             '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_TERM_ID"                                            'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FENTRY_TERM_ID)             '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FENTRY_TERM_ID)               '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_DT"                                                'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FUPDATE_DT)                 '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FUPDATE_DT)                   '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_USER_ID"                                           'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FUPDATE_USER_ID)            '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FUPDATE_USER_ID)              '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_USER_NAME"                                         'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FUPDATE_USER_NAME)          '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FUPDATE_USER_NAME)            '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_TERM_ID"                                           'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_USER_Before.FUPDATE_TERM_ID)            '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_USER_After.FUPDATE_TERM_ID)              '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            '===========================
            'ﾕｰｻﾞｰ操作ﾏｽﾀ
            '===========================
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TMST_USER_DSP"                                         'ﾃｰﾌﾞﾙ名
            Dim objTMST_USER_DSP As New TBL_TMST_USER_DSP(Owner, ObjDb, ObjDbLog)
            For ii As Integer = 1 To 5
                '(ﾙｰﾌﾟ:ﾃﾞｰﾀ数)

                objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUSER_DSP_LEVEL" & ii                                  'ﾌｨｰﾙﾄﾞ名

                objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = ""
                If IsNull(objTMST_USER_DSP_Before) = False Then
                    '(ﾃﾞｰﾀがある場合)

                    objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = strMukou                  '更新前情報
                    For jj As Integer = 0 To UBound(objTMST_USER_DSP_Before.ARYME)
                        '(ﾙｰﾌﾟ:ﾃﾞｰﾀ数)
                        If objTMST_USER_DSP_Before.ARYME(jj).FUSER_DSP_LEVEL = ii Then
                            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = strYuukou         '更新前情報
                            Exit For
                        End If
                    Next

                End If

                objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = ""
                If IsNull(objTMST_USER_DSP_After) = False Then
                    '(ﾃﾞｰﾀがある場合)

                    objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = strMukou                  '更新後情報
                    For jj As Integer = 0 To UBound(objTMST_USER_DSP_After.ARYME)
                        '(ﾙｰﾌﾟ:ﾃﾞｰﾀ数)
                        If objTMST_USER_DSP_After.ARYME(jj).FUSER_DSP_LEVEL = ii Then
                            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = strYuukou           '更新後情報
                            Exit For
                        End If
                    Next

                End If

                Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            Next


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  変更履歴詳細追加(TRST_STOCK)                                                             "
    '''****************************************************************************************************
    ''' <summary>
    ''' 変更履歴詳細追加
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <param name="MeSyoriID">処理ID</param>
    ''' <param name="objTPRG_TRK_BUF_Before">更新前ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objTRST_STOCK_Before">更新前ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objTPRG_TRK_BUF_After">更新後ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objTRST_STOCK_After">更新後ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    '''****************************************************************************************************
    Public Sub Add_TEVD_TBLCHANGE_DTL_TRST_STOCK(ByVal strDenbunDtl() As String _
                                               , ByVal MeSyoriID As String _
                                               , ByVal objTPRG_TRK_BUF_Before As TBL_TPRG_TRK_BUF _
                                               , ByVal objTRST_STOCK_Before As TBL_TRST_STOCK _
                                               , ByVal objTPRG_TRK_BUF_After As TBL_TPRG_TRK_BUF _
                                               , ByVal objTRST_STOCK_After As TBL_TRST_STOCK _
                                               )
        Try
            '' ''Dim intRet As RetCode
            '' ''Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '***********************
            '端末ﾏｽﾀの特定
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)
            If IsNull(strDenbunDtl(DSPTERM_ID)) = False Then
                objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '端末ID     ｾｯﾄ
                Call objTDSP_TERM.GET_TDSP_TERM(False)              '特定
            End If

            '***********************
            'ﾕｰｻﾞｰﾏｽﾀの特定
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            If IsNull(strDenbunDtl(DSPUSER_ID)) = False Then
                objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)    'ﾕｰｻﾞｰID
                Call objTMST_USER.GET_TMST_USER(False)              '特定
            End If


            '**************************************
            'ﾃｰﾌﾞﾙ変更履歴      追加
            '**************************************
            Dim objTEVD_TBLCHANGE As New TBL_TEVD_TBLCHANGE(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE.FLOG_NO = 0                               'ﾛｸﾞ№
            objTEVD_TBLCHANGE.FSYORI_ID = MeSyoriID                     '処理ID
            objTEVD_TBLCHANGE.FHASSEI_DT = Now                          '発生日時
            objTEVD_TBLCHANGE.FTERM_ID = objTDSP_TERM.FTERM_ID          '端末ID
            objTEVD_TBLCHANGE.FTERM_NAME = objTDSP_TERM.FTERM_NAME      '端末名
            objTEVD_TBLCHANGE.FUSER_ID = objTMST_USER.FUSER_ID          'ﾕｰｻﾞｰID
            objTEVD_TBLCHANGE.FUSER_NAME = objTMST_USER.FUSER_NAME      'ﾕｰｻﾞｰ名
            objTEVD_TBLCHANGE.FREASON_CD = Nothing                      '理由ｺｰﾄﾞ
            objTEVD_TBLCHANGE.FREASON = strDenbunDtl(DSPREASON)         '理由
            Call objTEVD_TBLCHANGE.ADD_TEVD_TBLCHANGE_SEQ()             '追加


            '**************************************
            '更新前ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄの初期化
            '**************************************
            If IsNull(objTPRG_TRK_BUF_Before) Then
                objTPRG_TRK_BUF_Before = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            End If
            If IsNull(objTPRG_TRK_BUF_After) Then
                objTPRG_TRK_BUF_After = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            End If
            If IsNull(objTRST_STOCK_Before) Then
                objTRST_STOCK_Before = New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            End If
            If IsNull(objTRST_STOCK_After) Then
                objTRST_STOCK_After = New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            End If


            '**************************************
            'ﾃｰﾌﾞﾙ変更履歴詳細  追加
            '**************************************
            '===========================
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            '===========================
            Dim objTEVD_TBLCHANGE_DTL As New TBL_TEVD_TBLCHANGE_DTL(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE_DTL.FLOG_NO = objTEVD_TBLCHANGE.FLOG_NO               'ﾛｸﾞ№
            objTEVD_TBLCHANGE_DTL.FSYORI_ID = objTEVD_TBLCHANGE.FSYORI_ID           '処理ID
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TPRG_TRK_BUF"                      'ﾃｰﾌﾞﾙ名

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTRK_BUF_NO"                                               'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTRK_BUF_NO)             '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTRK_BUF_NO)               '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTRK_BUF_ARRAY"                                            'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTRK_BUF_ARRAY)          '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTRK_BUF_ARRAY)            '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FSERCH_NO"                                                 'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FSERCH_NO)               '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FSERCH_NO)                 '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTRNS_ADDRESS"                                             'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTRNS_ADDRESS)           '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTRNS_ADDRESS)             '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDISP_ADDRESS"                                             'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FDISP_ADDRESS)           '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FDISP_ADDRESS)             '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRAC_RETU"                                                 'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRAC_RETU)               '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRAC_RETU)                 '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRAC_REN"                                                  'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRAC_REN)                '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRAC_REN)                  '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRAC_DAN"                                                  'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRAC_DAN)                '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRAC_DAN)                  '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRAC_EDA"                                                  'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRAC_EDA)                '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRAC_EDA)                  '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FREMOVE_KIND"                                              'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FREMOVE_KIND)            '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FREMOVE_KIND)              '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRAC_FORM"                                                 'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRAC_FORM)               '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRAC_FORM)                 '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRES_KIND"                                                 'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRES_KIND)               '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRES_KIND)                 '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRSV_PALLET"                                               'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRSV_PALLET)             '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRSV_PALLET)               '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTR_FM"                                                    'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTR_FM)                  '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTR_FM)                    '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTR_TO"                                                    'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTR_TO)                  '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTR_TO)                    '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTR_IDOU"                                                  'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTR_IDOU)                '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTR_IDOU)                  '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTRNS_FM"                                                  'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTRNS_FM)                '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTRNS_FM)                  '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTRNS_TO"                                                  'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FTRNS_TO)                '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FTRNS_TO)                  '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRSV_BUF_FM"                                               'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRSV_BUF_FM)             '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRSV_BUF_FM)               '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRSV_ARRAY_FM"                                             'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRSV_ARRAY_FM)           '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRSV_ARRAY_FM)             '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRSV_BUF_TO"                                               'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRSV_BUF_TO)             '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRSV_BUF_TO)               '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRSV_ARRAY_TO"                                             'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRSV_ARRAY_TO)           '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRSV_ARRAY_TO)             '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDISP_ADDRESS_FM"                                          'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FDISP_ADDRESS_FM)        '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FDISP_ADDRESS_FM)          '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDISP_ADDRESS_TO"                                          'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FDISP_ADDRESS_TO)        '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FDISP_ADDRESS_TO)          '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDISPLOG_ADDRESS_FM"                                       'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FDISPLOG_ADDRESS_FM)     '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FDISPLOG_ADDRESS_FM)       '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDISPLOG_ADDRESS_TO"                                       'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FDISPLOG_ADDRESS_TO)     '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FDISPLOG_ADDRESS_TO)       '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FPALLET_ID"                                                'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FPALLET_ID)              '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FPALLET_ID)                '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FBUF_IN_DT"                                                'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FBUF_IN_DT)              '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FBUF_IN_DT)                '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FRAC_BUNRUI"                                               'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTPRG_TRK_BUF_Before.FRAC_BUNRUI)             '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTPRG_TRK_BUF_After.FRAC_BUNRUI)               '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            '===========================
            '在庫情報
            '===========================
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TRST_STOCK"                      'ﾃｰﾌﾞﾙ名

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FPALLET_ID"                                                'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FPALLET_ID)                '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FPALLET_ID)                  '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FLOT_NO_STOCK"                                             'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FLOT_NO_STOCK)             '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FLOT_NO_STOCK)               '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FHINMEI_CD"                                                'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FHINMEI_CD)                '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FHINMEI_CD)                  '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FLOT_NO"                                                   'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FLOT_NO)                   '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FLOT_NO)                     '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FARRIVE_DT"                                                'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FARRIVE_DT)                '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FARRIVE_DT)                  '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FIN_KUBUN"                                                 'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FIN_KUBUN)                 '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FIN_KUBUN)                   '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FSEIHIN_KUBUN"                                             'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FSEIHIN_KUBUN)             '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FSEIHIN_KUBUN)               '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FZAIKO_KUBUN"                                              'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FZAIKO_KUBUN)              '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FZAIKO_KUBUN)                '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FHORYU_KUBUN"                                              'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FHORYU_KUBUN)              '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FHORYU_KUBUN)                '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FST_FM"                                                    'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FST_FM)                    '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FST_FM)                      '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTR_VOL"                                                   'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FTR_VOL)                   '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FTR_VOL)                     '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTR_RES_VOL"                                               'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FTR_RES_VOL)               '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FTR_RES_VOL)                 '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_DT"                                                'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FUPDATE_DT)                '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FUPDATE_DT)                  '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FHASU_FLAG"                                                'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FHASU_FLAG)                '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FHASU_FLAG)                  '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FLABEL_ID"                                                 'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FLABEL_ID)                 '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FLABEL_ID)                   '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FSYUKKA_TO_CD"                                             'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FSYUKKA_TO_CD)             '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FSYUKKA_TO_CD)               '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FSYUKKA_TO_NAME"                                           'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTRST_STOCK_Before.FSYUKKA_TO_NAME)           '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTRST_STOCK_After.FSYUKKA_TO_NAME)             '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                             '追加


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "　変更履歴詳細追加(TMST_REASON)                                                            "
    ''' ****************************************************************************************************
    ''' <summary>
    ''' 変更履歴詳細追加
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <param name="MeSyoriID">処理ID</param>
    ''' <param name="objTMST_REASON_Before">理由ﾏｽﾀ更新前ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objTMST_REASON_After">理由ﾏｽﾀ更新後ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************************
    Public Sub Add_TEVD_TBLCHANGE_DTL_TMST_REASON(ByVal strDenbunDtl() As String _
                                                , ByVal MeSyoriID As String _
                                                , ByVal objTMST_REASON_Before As TBL_TMST_REASON _
                                                , ByVal objTMST_REASON_After As TBL_TMST_REASON _
                                                 )
        Try

            ''Dim intRet As RetCode
            ''Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '***********************
            '端末ﾏｽﾀの特定
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)
            objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '端末ID     ｾｯﾄ
            Call objTDSP_TERM.GET_TDSP_TERM(False)              '特定


            '***********************
            'ﾕｰｻﾞｰﾏｽﾀの特定
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)    'ﾕｰｻﾞｰID
            Call objTMST_USER.GET_TMST_USER(False)              '特定


            '**************************************
            'ﾃｰﾌﾞﾙ変更履歴      追加
            '**************************************
            Dim objTEVD_TBLCHANGE As New TBL_TEVD_TBLCHANGE(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE.FLOG_NO = 0                               'ﾛｸﾞ№
            objTEVD_TBLCHANGE.FSYORI_ID = MeSyoriID                     '処理ID
            objTEVD_TBLCHANGE.FHASSEI_DT = Now                          '発生日時
            objTEVD_TBLCHANGE.FTERM_ID = objTDSP_TERM.FTERM_ID          '端末ID
            objTEVD_TBLCHANGE.FTERM_NAME = objTDSP_TERM.FTERM_NAME      '端末名
            objTEVD_TBLCHANGE.FUSER_ID = objTMST_USER.FUSER_ID          'ﾕｰｻﾞｰID
            objTEVD_TBLCHANGE.FUSER_NAME = objTMST_USER.FUSER_NAME      'ﾕｰｻﾞｰ名
            objTEVD_TBLCHANGE.FREASON_CD = Nothing                      '理由ｺｰﾄﾞ
            objTEVD_TBLCHANGE.FREASON = strDenbunDtl(DSPREASON)         '理由
            Call objTEVD_TBLCHANGE.ADD_TEVD_TBLCHANGE_SEQ()             '追加


            '**************************************
            'ﾃｰﾌﾞﾙ変更履歴詳細  追加
            '**************************************
            Dim objTEVD_TBLCHANGE_DTL As New TBL_TEVD_TBLCHANGE_DTL(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE_DTL.FLOG_NO = objTEVD_TBLCHANGE.FLOG_NO               'ﾛｸﾞ№
            objTEVD_TBLCHANGE_DTL.FSYORI_ID = objTEVD_TBLCHANGE.FSYORI_ID           '処理ID
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TMST_REASON"                       'ﾃｰﾌﾞﾙ名

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FREASON_CD"                                            'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FREASON_CD)           '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FREASON_CD)             '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FREASON_KUBUN"                                         'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FREASON_KUBUN)        '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FREASON_KUBUN)          '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FREASON"                                               'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FREASON)              '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FREASON)                '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_DT"                                             'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FENTRY_DT)            '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FENTRY_DT)              '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_USER_ID"                                        'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FENTRY_USER_ID)       '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FENTRY_USER_ID)         '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_TERM_ID"                                        'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FENTRY_TERM_ID)       '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FENTRY_TERM_ID)         '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_DT"                                            'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FUPDATE_DT)           '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FUPDATE_DT)             '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_USER_ID"                                       'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FUPDATE_USER_ID)      '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FUPDATE_USER_ID)        '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_TERM_ID"                                       'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_REASON_Before.FUPDATE_TERM_ID)      '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_REASON_After.FUPDATE_TERM_ID)        '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "　変更履歴詳細追加(TDSP_PMT_USER)                                                          "
    ''' ****************************************************************************************************
    ''' <summary>
    ''' 変更履歴詳細追加
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <param name="MeSyoriID">処理ID</param>
    ''' <param name="objTDSP_PMT_USER_Before">ﾕｰｻﾞ別許可ﾏｽﾀ更新前ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objTDSP_PMT_USER_After">ﾕｰｻﾞ別許可ﾏｽﾀ更新後ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************************
    Public Sub Add_TEVD_TBLCHANGE_DTL_TDSP_PMT_USER(ByVal strDenbunDtl() As String _
                                                , ByVal MeSyoriID As String _
                                                , ByVal objTDSP_PMT_USER_Before As TBL_TDSP_PMT_USER _
                                                , ByVal objTDSP_PMT_USER_After As TBL_TDSP_PMT_USER _
                                                 )
        Try

            ''Dim intRet As RetCode
            ''Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            Dim strYuukou As String = "○"          '有効表示
            Dim strMukou As String = "×"           '無効表示


            '***********************
            '端末ﾏｽﾀの特定
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)
            objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '端末ID     ｾｯﾄ
            Call objTDSP_TERM.GET_TDSP_TERM(False)              '特定


            '***********************
            'ﾕｰｻﾞｰﾏｽﾀの特定
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)    'ﾕｰｻﾞｰID
            Call objTMST_USER.GET_TMST_USER(False)              '特定


            '**************************************
            'ﾃｰﾌﾞﾙ変更履歴      追加
            '**************************************
            Dim objTEVD_TBLCHANGE As New TBL_TEVD_TBLCHANGE(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE.FLOG_NO = 0                               'ﾛｸﾞ№
            objTEVD_TBLCHANGE.FSYORI_ID = MeSyoriID                     '処理ID
            objTEVD_TBLCHANGE.FHASSEI_DT = Now                          '発生日時
            objTEVD_TBLCHANGE.FTERM_ID = objTDSP_TERM.FTERM_ID          '端末ID
            objTEVD_TBLCHANGE.FTERM_NAME = objTDSP_TERM.FTERM_NAME      '端末名
            objTEVD_TBLCHANGE.FUSER_ID = objTMST_USER.FUSER_ID          'ﾕｰｻﾞｰID
            objTEVD_TBLCHANGE.FUSER_NAME = objTMST_USER.FUSER_NAME      'ﾕｰｻﾞｰ名
            objTEVD_TBLCHANGE.FREASON_CD = Nothing                      '理由ｺｰﾄﾞ
            objTEVD_TBLCHANGE.FREASON = strDenbunDtl(DSPREASON)         '理由
            Call objTEVD_TBLCHANGE.ADD_TEVD_TBLCHANGE_SEQ()             '追加


            '**************************************
            'ﾃｰﾌﾞﾙ変更履歴詳細  追加
            '**************************************
            Dim objTEVD_TBLCHANGE_DTL As New TBL_TEVD_TBLCHANGE_DTL(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE_DTL.FLOG_NO = objTEVD_TBLCHANGE.FLOG_NO               'ﾛｸﾞ№
            objTEVD_TBLCHANGE_DTL.FSYORI_ID = objTEVD_TBLCHANGE.FSYORI_ID           '処理ID
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TDSP_PMT_USER"                     'ﾃｰﾌﾞﾙ名

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUSER_DSP_LEBEL"                                       'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FUSER_DSP_LEVEL)    '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FUSER_DSP_LEVEL)      '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDISP_ID"                                              'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FDISP_ID)           '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FDISP_ID)             '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FCTRL_ID"                                              'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FCTRL_ID)           '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FCTRL_ID)             '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FOPE_FLAG"                                             'ﾌｨｰﾙﾄﾞ名
            If TO_STRING(objTDSP_PMT_USER_Before.FOPE_FLAG) = TO_STRING(FLAG_ON) Then
                objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = strYuukou
            Else
                objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = strMukou
            End If
            If TO_STRING(objTDSP_PMT_USER_After.FOPE_FLAG) = TO_STRING(FLAG_ON) Then
                objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = strYuukou
            Else
                objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = strMukou
            End If
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_DT"                                             'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FENTRY_DT)          '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FENTRY_DT)            '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_USER_ID"                                        'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FENTRY_USER_ID)     '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FENTRY_USER_ID)       '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FENTRY_TERM_ID"                                        'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FENTRY_TERM_ID)     '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FENTRY_TERM_ID)       '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_DT"                                            'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FUPDATE_DT)         '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FUPDATE_DT)           '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_USER_ID"                                       'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FUPDATE_USER_ID)    '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FUPDATE_USER_ID)      '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FUPDATE_TERM_ID"                                       'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTDSP_PMT_USER_Before.FUPDATE_TERM_ID)    '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTDSP_PMT_USER_After.FUPDATE_TERM_ID)      '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  変更履歴詳細追加(TMST_LOT)                                                               "
    '''****************************************************************************************************
    ''' <summary>
    ''' 変更履歴詳細追加
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <param name="MeSyoriID">処理ID</param>
    ''' <param name="objTMST_LOT_Before">品名ﾏｽﾀ更新前ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objTMST_LOT_After">品名ﾏｽﾀ更新後ﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    '''****************************************************************************************************
    Public Sub Add_TEVD_TBLCHANGE_DTL_TMST_LOT(ByVal strDenbunDtl() As String _
                                              , ByVal MeSyoriID As String _
                                              , ByVal objTMST_LOT_Before As TBL_TMST_LOT _
                                              , ByVal objTMST_LOT_After As TBL_TMST_LOT _
                                              )
        Try

            'Dim intRet As RetCode
            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ

            '***********************
            '端末ﾏｽﾀの特定
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)
            objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '端末ID     ｾｯﾄ
            Call objTDSP_TERM.GET_TDSP_TERM(False)              '特定


            '***********************
            'ﾕｰｻﾞｰﾏｽﾀの特定
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)    'ﾕｰｻﾞｰID
            Call objTMST_USER.GET_TMST_USER(False)              '特定

            '***********************
            '品名ﾏｽﾀの特定
            '***********************
            Dim objTMST_ITEM_Before As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
            Dim objTMST_ITEM_After As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
            objTMST_ITEM_Before.FHINMEI_CD = objTMST_LOT_Before.FHINMEI_CD
            objTMST_ITEM_After.FHINMEI_CD = objTMST_LOT_After.FHINMEI_CD
            If Not (TO_STRING(objTMST_ITEM_Before.FHINMEI_CD) Is Nothing) Or TO_STRING(objTMST_ITEM_Before.FHINMEI_CD) <> "" Then
                Call objTMST_ITEM_Before.GET_TMST_ITEM(False)
            End If
            If Not (TO_STRING(objTMST_ITEM_After.FHINMEI_CD) Is Nothing) Or TO_STRING(objTMST_ITEM_After.FHINMEI_CD) <> "" Then
                Call objTMST_ITEM_After.GET_TMST_ITEM(False)
            End If


            '***********************
            '単位ﾏｽﾀの特定
            '***********************
            Dim objTMST_UNIT_Before As New TBL_TMST_UNIT(Owner, ObjDb, ObjDbLog)
            Dim objTMST_UNIT_After As New TBL_TMST_UNIT(Owner, ObjDb, ObjDbLog)
            objTMST_UNIT_Before.FTANI = objTMST_LOT_Before.FTANI
            objTMST_UNIT_After.FTANI = objTMST_LOT_After.FTANI
            If Not (TO_STRING(objTMST_UNIT_Before.FTANI) Is Nothing) Or TO_STRING(objTMST_UNIT_Before.FTANI) <> "" Then
                Call objTMST_UNIT_Before.GET_TMST_UNIT(False)
            End If
            If Not (TO_STRING(objTMST_UNIT_After.FTANI) Is Nothing) Or TO_STRING(objTMST_UNIT_After.FTANI) <> "" Then
                Call objTMST_UNIT_After.GET_TMST_UNIT(False)
            End If


            '**************************************
            'ﾃｰﾌﾞﾙ変更履歴      追加
            '**************************************
            Dim objTEVD_TBLCHANGE As New TBL_TEVD_TBLCHANGE(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE.FLOG_NO = 0                               'ﾛｸﾞ№
            objTEVD_TBLCHANGE.FSYORI_ID = MeSyoriID                     '処理ID
            objTEVD_TBLCHANGE.FHASSEI_DT = Now                          '発生日時
            objTEVD_TBLCHANGE.FTERM_ID = objTDSP_TERM.FTERM_ID          '端末ID
            objTEVD_TBLCHANGE.FTERM_NAME = objTDSP_TERM.FTERM_NAME      '端末名
            objTEVD_TBLCHANGE.FUSER_ID = objTMST_USER.FUSER_ID        'ﾕｰｻﾞｰID
            objTEVD_TBLCHANGE.FUSER_NAME = objTMST_USER.FUSER_NAME      'ﾕｰｻﾞｰ名
            objTEVD_TBLCHANGE.FREASON_CD = Nothing                      '理由ｺｰﾄﾞ
            objTEVD_TBLCHANGE.FREASON = strDenbunDtl(DSPREASON)         '理由
            Call objTEVD_TBLCHANGE.ADD_TEVD_TBLCHANGE_SEQ()             '追加


            '**************************************
            'ﾃｰﾌﾞﾙ変更履歴詳細  追加
            '**************************************
            Dim objTEVD_TBLCHANGE_DTL As New TBL_TEVD_TBLCHANGE_DTL(Owner, ObjDb, ObjDbLog)
            objTEVD_TBLCHANGE_DTL.FLOG_NO = objTEVD_TBLCHANGE.FLOG_NO               'ﾛｸﾞ№
            objTEVD_TBLCHANGE_DTL.FSYORI_ID = objTEVD_TBLCHANGE.FSYORI_ID           '処理ID
            objTEVD_TBLCHANGE_DTL.FTABLE_NAME = "TMST_LOT"                          'ﾃｰﾌﾞﾙ名

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FHINMEI_CD"                                            'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FHINMEI_CD)              '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FHINMEI_CD)                '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FHINMEI"                                               'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_ITEM_Before.FHINMEI)                '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_ITEM_After.FHINMEI)                  '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FLOT_NO"                                               'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FLOT_NO)                 '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FLOT_NO)                   '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加



            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FNUM_IN_CASE"                                          'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FNUM_IN_CASE)            '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FNUM_IN_CASE)              '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FTANI"                                                 'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FTANI)                   '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FTANI)                     '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FSHIKEN_RESULT"                                        'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FSHIKEN_RESULT)          '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FSHIKEN_RESULT)            '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FSHIKEN_RECV_DT"                                       'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FSHIKEN_RECV_DT)         '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FSHIKEN_RECV_DT)           '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FSHIKEN_LIMIT_DT"                                      'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FSHIKEN_LIMIT_DT)        '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FSHIKEN_LIMIT_DT)          '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加



            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FARRIVE_DT"                                            'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FARRIVE_DT)              '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FARRIVE_DT)                '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加

            objTEVD_TBLCHANGE_DTL.FFIELD_NAME = "FDEPART_DT"                                            'ﾌｨｰﾙﾄﾞ名
            objTEVD_TBLCHANGE_DTL.FVALUE_BEFORE = TO_STRING(objTMST_LOT_Before.FDEPART_DT)              '更新前情報
            objTEVD_TBLCHANGE_DTL.FVALUE_AFTER = TO_STRING(objTMST_LOT_After.FDEPART_DT)                '更新後情報
            Call objTEVD_TBLCHANGE_DTL.ADD_TEVD_TBLCHANGE_DTL()                                         '追加



        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  保管出納記録追加                                                                         "

    ''' <summary>
    ''' 保管出納記録追加
    ''' </summary>
    ''' <param name="intTRK_BUF_NO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <param name="intTR_TO">搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <param name="intSAGYOU_KIND">作業種別</param>
    ''' <param name="strTERM_ID">端末ID</param>
    ''' <param name="strUSER_ID">ﾕｰｻﾞｰID</param>
    ''' <param name="strREASON_CD">理由ｺｰﾄﾞ</param>
    ''' <param name="strREASON">理由</param>
    ''' <param name="objTRST_STOCK_BASE">在庫情報</param>
    ''' <remarks></remarks>
    Public Sub Add_TBL_TEVD_SUITOU(ByVal intTRK_BUF_NO As Nullable(Of Integer) _
                                 , ByVal intTR_TO As Nullable(Of Integer) _
                                 , ByVal intSAGYOU_KIND As Integer _
                                 , ByVal strTERM_ID As String _
                                 , ByVal strUSER_ID As String _
                                 , ByVal strREASON_CD As String _
                                 , ByVal strREASON As String _
                                 , ByVal objTRST_STOCK_BASE As TBL_TRST_STOCK _
                                  )
        Try
            '' ''Dim intRet As RetCode
            '' ''Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '***********************
            'ﾛｸﾞ№の特定
            '***********************
            Dim strFLOG_NO As String                                                    'ﾛｸﾞ№
            Dim objTPRG_SEQNO As New TBL_TPRG_SEQNO(Owner, ObjDb, ObjDbLog)             'ｼｰｹﾝｽ№ｸﾗｽ
            objTPRG_SEQNO.FSEQ_ID = FSEQ_ID_SSVRLOG_NO_SUITOU                            'ｼｰｹﾝｽID
            strFLOG_NO = objTPRG_SEQNO.GET_ENTRY_NO()                                   'SEQ№の特定


            '***********************
            '端末ﾏｽﾀの特定
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)
            If IsNull(strTERM_ID) = False Then
                objTDSP_TERM.FTERM_ID = strTERM_ID                                      '端末ID
                Call objTDSP_TERM.GET_TDSP_TERM(False)                                  '特定
            End If


            '***********************
            'ﾕｰｻﾞｰﾏｽﾀの特定
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            If IsNull(strUSER_ID) = False Then
                objTMST_USER.FUSER_ID = strUSER_ID                                      'ﾕｰｻﾞｰID
                Call objTMST_USER.GET_TMST_USER(False)                                  '特定
            End If


            '************************
            '在庫情報の取得
            '************************
            For Each objTRST_STOCK As TBL_TRST_STOCK In objTRST_STOCK_BASE.ARYME
                '**************************************
                '品名ﾏｽﾀの特定
                '**************************************
                Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                objTMST_ITEM.FHINMEI_CD = objTRST_STOCK.FHINMEI_CD                      '品名ｺｰﾄﾞ
                Call objTMST_ITEM.GET_TMST_ITEM(False)                                  '特定

                '**************************************
                'ﾃｰﾌﾞﾙ変更履歴      追加
                '**************************************
                Dim objTEVD_SUITOU As New TBL_TEVD_SUITOU(Owner, ObjDb, ObjDbLog)
                objTEVD_SUITOU.FLOG_NO = strFLOG_NO                                     'ﾛｸﾞ№
                objTEVD_SUITOU.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK              '在庫ﾛｯﾄ№
                objTEVD_SUITOU.FRESULT_DT = Now                                         '実績日時
                objTEVD_SUITOU.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD                     '品名ｺｰﾄﾞ
                objTEVD_SUITOU.FHINMEI = objTMST_ITEM.FHINMEI                           '品名
                objTEVD_SUITOU.FLOT_NO = objTRST_STOCK.FLOT_NO                          'ﾛｯﾄ№
                objTEVD_SUITOU.FTRK_BUF_NO = intTRK_BUF_NO                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTEVD_SUITOU.FTR_TO = intTR_TO                                        '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTEVD_SUITOU.FTR_VOL = objTRST_STOCK.FTR_VOL                          '搬送管理量
                objTEVD_SUITOU.FTERM_ID = objTDSP_TERM.FTERM_ID                         '端末ID
                objTEVD_SUITOU.FTERM_NAME = objTDSP_TERM.FTERM_NAME                     '端末名
                objTEVD_SUITOU.FUSER_ID = objTMST_USER.FUSER_ID                         'ﾕｰｻﾞｰID
                objTEVD_SUITOU.FUSER_NAME = objTMST_USER.FUSER_NAME                     'ﾕｰｻﾞｰ名
                objTEVD_SUITOU.FREASON_CD = strREASON_CD                                '理由ｺｰﾄﾞ
                objTEVD_SUITOU.FREASON = strREASON                                      '理由
                objTEVD_SUITOU.FSAGYOU_KIND = intSAGYOU_KIND                            '作業種別
                Call objTEVD_SUITOU.ADD_TEVD_SUITOU()                                   '追加
            Next


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region

    '変換処理
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№       → 出庫確認後平置き         変換                                    "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№       → 出庫確認後平置き         変換
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <returns>出庫確認後平置き</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GetXNEXTFromFTRK_BUF_NO(ByVal intFTRK_BUF_NO As Integer) As Integer
        Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        'Dim dtmNow As Date = Now
        Dim intReturn As Integer

        Try


            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
            '************************
            Dim intXNEXT As Integer = -1
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.FTRK_BUF_NO = intFTRK_BUF_NO
            intRet = objTMST_TRK.GET_TMST_TRK(False)
            If intRet = RetCode.OK Then
                '↓↓↓↓↓↓************************************************************************************************************
                'CommentMate:A.Noto 2012/06/26 後で設定必須
                ''intXNEXT = objTMST_TRK.XNEXT
                '↑↑↑↑↑↑************************************************************************************************************
            End If



            intReturn = intXNEXT
            Return intReturn
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№       → ｸﾚｰﾝ設備ID               変換                                    "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№       → ｸﾚｰﾝ設備ID               変換
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <returns>ｸﾚｰﾝ設備ID</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GetXEQ_ID_CRANEFromFTRK_BUF_NO(ByVal intFTRK_BUF_NO As Integer) As String
        Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        'Dim dtmNow As Date = Now
        Dim strReturn As String

        Try


            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
            '************************
            Dim strXEQ_ID_CRANE As String = ""
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.FTRK_BUF_NO = intFTRK_BUF_NO
            intRet = objTMST_TRK.GET_TMST_TRK(False)
            If intRet = RetCode.OK Then
                '↓↓↓↓↓↓************************************************************************************************************
                'CommentMate:A.Noto 2012/06/26 後で設定必須
                ''strXEQ_ID_CRANE = objTMST_TRK.XEQ_ID_CRANE
                '↑↑↑↑↑↑************************************************************************************************************
            End If


            strReturn = strXEQ_ID_CRANE
            Return strReturn
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№       → 入出庫ﾓｰﾄﾞ設備ID         変換                                    "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№       → 入出庫ﾓｰﾄﾞ設備ID         変換
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <returns>ｸﾚｰﾝ設備ID</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GetXEQ_ID_MODFromFTRK_BUF_NO(ByVal intFTRK_BUF_NO As Integer) As String
        Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        'Dim dtmNow As Date = Now
        Dim strReturn As String

        Try


            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
            '************************
            Dim strXEQ_ID_MOD As String = ""
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.FTRK_BUF_NO = intFTRK_BUF_NO
            intRet = objTMST_TRK.GET_TMST_TRK(False)
            If intRet = RetCode.OK Then
                strXEQ_ID_MOD = objTMST_TRK.XEQ_ID_MOD
            End If

            strReturn = strXEQ_ID_MOD

            Return strReturn

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ﾛｰｶﾙ設備ID           → 設備ID(送信PLC)          変換                                    "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾛｰｶﾙ設備ID           → 設備ID(送信PLC)          変換
    ''' </summary>
    ''' <param name="strFEQ_ID">設備ID</param>
    ''' <returns>設備ID(送信PLC)</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GetXEQ_ID_SendFromFEQ_ID_LOCAL(ByVal strFEQ_ID As String) As String
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        'Dim dtmNow As Date = Now
        Dim strReturn As String = ""

        Try


            '************************************************
            '設備状況           取得
            '************************************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID          '設備ID
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()          '取得


            '************************************************
            '設備ID         取得
            '************************************************
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2015/07/13 CW6追加対応 ↓↓↓↓↓↓
            '' ''Select Case Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 1)
            '' ''    Case "M" : strReturn = FEQ_ID_JSYS0000
            '' ''    Case "Y"
            '' ''        Select Case Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 2, 2)
            '' ''            Case "01" : strReturn = FEQ_ID_JSYS0001
            '' ''            Case "02" : strReturn = FEQ_ID_JSYS0002
            '' ''            Case "03" : strReturn = FEQ_ID_JSYS0003
            '' ''            Case "04" : strReturn = FEQ_ID_JSYS0004
            '' ''            Case "05" : strReturn = FEQ_ID_JSYS0005
            '' ''            Case "06" : strReturn = FEQ_ID_JSYS0006
            '' ''        End Select
            '' ''End Select
            Select Case Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 1)
                Case "M"
                    Select Case Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 2, 2)
                        Case "FF" : strReturn = FEQ_ID_JSYS0000
                        Case "FE" : strReturn = FEQ_ID_JSYS0007
                    End Select
                Case "Y"
                    Select Case Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 2, 2)
                        Case "01" : strReturn = FEQ_ID_JSYS0001
                        Case "02" : strReturn = FEQ_ID_JSYS0002
                        Case "03" : strReturn = FEQ_ID_JSYS0003
                        Case "04" : strReturn = FEQ_ID_JSYS0004
                        Case "05" : strReturn = FEQ_ID_JSYS0005
                        Case "06" : strReturn = FEQ_ID_JSYS0006
                    End Select
            End Select
            'JobMate:S.Ouchi 2015/07/13 CW6追加対応 ↑↑↑↑↑↑
            '↑↑↑↑↑↑************************************************************************************************************


            Return strReturn
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  列(ﾏﾃｽﾄ)             → 列(PLC)                  変換                                    "
    '''**********************************************************************************************
    ''' <summary>
    ''' 列(ﾏﾃｽﾄ)         → 列(PLC)                      変換
    ''' </summary>
    ''' <param name="intFRAC_RETU">列(ﾏﾃｽﾄ)</param>
    ''' <returns>列(PLC)</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GetPLCRetuFromFRAC_RETU(ByVal intFRAC_RETU As Integer) As Integer
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        'Dim dtmNow As Date = Now
        Dim strReturn As String = ""


        '************************************************
        '設備状況           取得
        '************************************************
        If (intFRAC_RETU Mod 2) = 0 Then
            strReturn = 2
        Else
            strReturn = 1
        End If


        Return strReturn
    End Function
#End Region
#Region "  列(PLC)              → 列(ﾏﾃｽﾄ)                 変換                                    "
    '''**********************************************************************************************
    ''' <summary>
    ''' 列(PLC)              → 列(ﾏﾃｽﾄ)                 変換
    ''' </summary>
    ''' <param name="intPLCRetu">列(PLC)</param>
    ''' <param name="intGouki">号機</param>
    ''' <param name="blnErr">想定外の値の場合はｴﾗｰとするか否か</param>
    ''' <returns>列(ﾏﾃｽﾄ)</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GetFRAC_RETUFromPLCRetu(ByVal intPLCRetu As Integer _
                                          , ByVal intGouki As Integer _
                                          , Optional ByVal blnErr As Boolean = True _
                                          ) As Integer
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        'Dim dtmNow As Date = Now
        Dim intReturn As Integer = -1


        '************************************************
        '設備状況           取得
        '************************************************
        Select Case intPLCRetu
            Case 2 : intReturn = (intGouki * 2)
            Case 1 : intReturn = (intGouki * 2) - 1
            Case Else : If blnErr = True Then Throw New Exception("PLCから列取得時にｴﾗｰ発生。")
        End Select


        Return intReturn
    End Function
#End Region
#Region "  ｴﾗｰｺｰﾄﾞ(PLC)         → ｴﾗｰｺｰﾄﾞ(MDD)             変換                                    "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｴﾗｰｺｰﾄﾞ(PLC)         → ｴﾗｰｺｰﾄﾞ(MDD)             変換
    ''' </summary>
    ''' <param name="strPLCErrCode">ｴﾗｰｺｰﾄﾞ(PLC)</param>
    ''' <returns>ｴﾗｰｺｰﾄﾞ(MDD)</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GetMDDErrCodeFromPLCErrCode(ByVal strPLCErrCode As String) As String
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        'Dim dtmNow As Date = Now
        Dim strReturn As String = ""


        '************************************************
        '値変換
        '************************************************
        strReturn = Change10To16(strPLCErrCode, 4)
        strReturn = Right(strReturn, 2)


        Return strReturn
    End Function
#End Region


    'ﾄﾗｯｷﾝｸﾞ予約解除
#Region "  ﾄﾗｯｷﾝｸﾞ予約解除  (搬送元)                                                                "
    '''**********************************************************************************************
    ''' <summary>
    ''' 搬送元ﾄﾗｯｷﾝｸﾞ予約解除
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">搬送中ﾄﾗｯｷﾝｸﾞ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub ClearFromReserve(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF)
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        '************************************************
        '予約されているﾄﾗｯｷﾝｸﾞの取得
        '************************************************
        Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        objTPRG_TRK_BUF_FM.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF()                                       '特定


        If objTPRG_TRK_BUF_FM.FRSV_PALLET = objTPRG_TRK_BUF_RELAY.FPALLET_ID Then
            objTPRG_TRK_BUF_FM.CLEAR_TPRG_TRK_BUF()   '解放
        End If


    End Sub
#End Region

    '平置き在庫削除
#Region "  平置き在庫削除                                                                           "
    '''**********************************************************************************************
    ''' <summary>
    ''' 平置き在庫削除
    ''' </summary>
    ''' <param name="strFPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <param name="intFINOUT_STS">IN/OUT</param>
    ''' <param name="intFSAGYOU_KIND">作業種別</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub DeleteHiraoki(ByVal strFPALLET_ID As String _
                           , ByVal intFINOUT_STS As Integer _
                           , ByVal intFSAGYOU_KIND As Integer _
                           )
        Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        '************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
        '************************
        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
        objTPRG_TRK_BUF.FPALLET_ID = strFPALLET_ID                                  'ﾊﾟﾚｯﾄID
        objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                                          '特定


        '************************
        '在庫引当情報の削除
        '************************
        Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '在庫引当情報ｸﾗｽ
        objTSTS_HIKIATE.FPALLET_ID = strFPALLET_ID                          'ﾊﾟﾚｯﾄID
        objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()                        '削除


        '************************
        '在庫削除
        '************************
        Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '在庫削除ｸﾗｽ
        objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        objSVR_100102.FPALLET_ID = strFPALLET_ID                    'ﾊﾟﾚｯﾄID
        objSVR_100102.FINOUT_STS = intFINOUT_STS                    'INOUT
        objSVR_100102.FSAGYOU_KIND = intFSAGYOU_KIND                '作業種別
        objSVR_100102.STOCK_DELETE()                                '削除


        '************************
        '在庫情報の特定
        '************************
        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '在庫情報ｸﾗｽ
        objTRST_STOCK.FPALLET_ID = strFPALLET_ID                        'ﾊﾟﾚｯﾄID
        intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(False)             '特定
        If intRet = RetCode.NotFound Then
            '(見つからない場合)

            '************************
            '引当ﾊﾞｯﾌｧの解放
            '************************
            Dim objTPRG_TRK_BUF_CLEAR As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)   '在庫削除ｸﾗｽ
            objTPRG_TRK_BUF_CLEAR.FRSV_PALLET = strFPALLET_ID                           'ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_CLEAR.CLEAR_TPRG_TRK_BUF_RSV_PC()                           '解放

        End If


    End Sub
#End Region

    '搬送処理
#Region "  出庫設定                     (SVR_201601)                                                "
    '''**********************************************************************************************
    ''' <summary>
    ''' 入庫設定
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO_TO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(TO)</param>
    ''' <param name="strFPALLET_ID_OYA">ﾊﾟﾚｯﾄID(親)</param>
    ''' <param name="strFPALLET_ID_KO">ﾊﾟﾚｯﾄID(子)</param>
    ''' <param name="intFSAGYOU_KIND">作業種別</param>
    ''' <param name="strFTERM_ID">端末ID</param>
    ''' <param name="strFUSER_ID">ﾕｰｻﾞｰID</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SVR_201601_Process(ByVal intFTRK_BUF_NO_TO As Integer _
                                     , ByVal strFPALLET_ID_OYA As String _
                                     , ByVal strFPALLET_ID_KO As String _
                                     , ByVal intFSAGYOU_KIND As Integer _
                                     , ByVal strFTERM_ID As String _
                                     , ByVal strFUSER_ID As String _
                                     ) As RetCode


        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        Try



            '************************************************************************************************************
            '************************************************************************************************************
            '親の出庫
            '************************************************************************************************************
            '************************************************************************************************************
            '************************************
            '出庫ﾄﾗｯｷﾝｸﾞ定義ｸﾗｽ(ﾊﾟﾚｯﾄID指定)
            '************************************
            Dim objSVR_100501_OYA As New SVR_100501(Owner, ObjDb, ObjDbLog)
            objSVR_100501_OYA.FTRK_BUF_NO_TO = intFTRK_BUF_NO_TO                            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(出庫先ﾄﾗｯｷﾝｸﾞ)
            objSVR_100501_OYA.FPALLET_ID = strFPALLET_ID_OYA                                'ﾊﾟﾚｯﾄID
            objSVR_100501_OYA.FSAGYOU_KIND = intFSAGYOU_KIND                                '作業種別
            objSVR_100501_OYA.FTERM_ID = strFTERM_ID                                        '端末ID
            objSVR_100501_OYA.FUSER_ID = strFUSER_ID                                        'ﾕｰｻﾞｰID
            objSVR_100501_OYA.UPDATE_OUT_BUF(FTR_VOL_SFULL)                                 '定義


            ''************************************
            ''搬送指示QUE        更新
            ''************************************
            'Dim objTPLN_CARRY_QUE_OYA As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
            'objTPLN_CARRY_QUE_OYA.FPALLET_ID = strFPALLET_ID_OYA    'ﾊﾟﾚｯﾄID
            'objTPLN_CARRY_QUE_OYA.GET_TPLN_CARRY_QUE()              '取得
            'objTPLN_CARRY_QUE_OYA.XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA      '親子区分
            'objTPLN_CARRY_QUE_OYA.XPALLET_ID_AITE = strFPALLET_ID_KO    '相手ﾊﾟﾚｯﾄID
            'objTPLN_CARRY_QUE_OYA.UPDATE_TPLN_CARRY_QUE()               '更新


            '************************************************************************************************************
            '************************************************************************************************************
            '子の出庫
            '************************************************************************************************************
            '************************************************************************************************************
            If IsNotNull(strFPALLET_ID_KO) Then
                '(ﾍﾟｱ搬送の場合)


                '************************************
                '出庫ﾄﾗｯｷﾝｸﾞ定義ｸﾗｽ(ﾊﾟﾚｯﾄID指定)
                '************************************
                Dim objSVR_100501_KO As New SVR_100501(Owner, ObjDb, ObjDbLog)
                objSVR_100501_KO.FTRK_BUF_NO_TO = intFTRK_BUF_NO_TO                            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(出庫先ﾄﾗｯｷﾝｸﾞ)
                objSVR_100501_KO.FPALLET_ID = strFPALLET_ID_KO                                 'ﾊﾟﾚｯﾄID
                objSVR_100501_KO.FSAGYOU_KIND = intFSAGYOU_KIND                                '作業種別
                objSVR_100501_KO.FTERM_ID = strFTERM_ID                                        '端末ID
                objSVR_100501_KO.FUSER_ID = strFUSER_ID                                        'ﾕｰｻﾞｰID
                objSVR_100501_KO.UPDATE_OUT_BUF(FTR_VOL_SFULL)                                 '定義


                '************************************
                '搬送指示QUE        更新
                '************************************
                Dim objTPLN_CARRY_QUE_KO As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                objTPLN_CARRY_QUE_KO.FPALLET_ID = strFPALLET_ID_KO     'ﾊﾟﾚｯﾄID
                objTPLN_CARRY_QUE_KO.GET_TPLN_CARRY_QUE()              '取得
                objTPLN_CARRY_QUE_KO.XOYAKO_KUBUN = XOYAKO_KUBUN_JKO       '親子区分
                objTPLN_CARRY_QUE_KO.XPALLET_ID_AITE = strFPALLET_ID_OYA   '相手ﾊﾟﾚｯﾄID
                objTPLN_CARRY_QUE_KO.UPDATE_TPLN_CARRY_QUE()               '更新


            End If




            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動


            Return RetCode.OK
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  入庫設定                     (SVR_400001)STに一度ﾄﾗｯｷﾝｸﾞだけを作成するﾊﾞｰｼﾞｮﾝ            "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SVR_400001_Process(ByVal strDenbunDtl() As String _
                                     , ByVal strMSG_RECV As String _
                                     , ByRef strMSG_SEND As String _
                                     ) _
                                     As RetCode
        Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        Dim intRet As RetCode                 '戻り値
        Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        Try
            Dim DSPTERM_ID As Integer = 0             '端末ID
            Dim DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
            Dim DSPREASON As Integer = 2              '理由
            Dim DSPST_FM As Integer = 3               '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            Dim DSPST_TO As Integer = 4               '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            Dim DSPPALLET_ID As Integer = 5           'ﾊﾟﾚｯﾄID
            Dim DSPLOT_NO_STOCK As Integer = 6        '在庫ﾛｯﾄ№
            Dim DSPSAGYOU_KIND As Integer = 7         '作業種別
            Dim DSPHINMEI_CD As Integer = 8           '品名ｺｰﾄﾞ
            Dim DSPTR_VOL As Integer = 9              '搬送管理量
            Dim XDSPIN_KIND As Integer = 10           '入庫種別
            Dim XDSPIN_SITEI As Integer = 11          '入庫指定
            Dim DSPARRIVE_DT As Integer = 12          '在庫発生日時
            Dim XDSPPROD_LINE As Integer = 13         '生産ﾗｲﾝ№
            Dim XDSPMAKER_CD As Integer = 14          'ﾒｰｶｺｰﾄﾞ
            Dim XDSPKENSA_KUBUN As Integer = 15       '検査区分
            Dim DSPHORYU_KUBUN As Integer = 16        '保留区分
            Dim DSPIN_KUBUN As Integer = 17           '入庫区分
            Dim XDSPKENPIN_KUBUN As Integer = 18      '検品区分
            Dim XDSPPALLET_ID_KO As Integer = 19      'ﾊﾟﾚｯﾄID(子)
            Dim XDSPTR_VOL_KO As Integer = 20         '搬送管理量(子)
            Dim XDSPTANA_BLOCK As Integer = 21        '棚ﾌﾞﾛｯｸ
            Dim XDSPST_TO_ARRAY01 As Integer = 22     '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№01
            Dim XDSPST_TO_ARRAY02 As Integer = 23     '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№02


            '************************
            '初期設定
            '************************
            Dim dtmNow As Date = Now
            Dim intFSAGYOU_KIND As Integer = strDenbunDtl(DSPSAGYOU_KIND)   '作業種別
            Dim blnPair As Boolean                                          'ﾍﾟｱﾌﾗｸﾞ
            Dim blnHasuBlock As Boolean = False                             '端数ﾌﾗｸﾞ
            Dim dtmFARRIVE_DT As Date = IIf(IsNotNull(strDenbunDtl(DSPARRIVE_DT)), TO_DATE(strDenbunDtl(DSPARRIVE_DT)), Now)    '在庫発生日時
            If strDenbunDtl(XDSPIN_KIND) = XDSPIN_KIND_PAIR Then blnPair = True
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)


            '*****************************************************
            'ﾛｯﾄ№取得
            '*****************************************************
            Dim strFLOT_NO As String = ""               'ﾛｯﾄ№
            If IsNull(strDenbunDtl(DSPARRIVE_DT)) Then
                '(在庫発生日時が設定されていなかった場合)
                Call GetFLOT_NO(strFLOT_NO, strDenbunDtl(XDSPPROD_LINE))
            Else
                '(在庫発生日時が設定されていた場合)
                strFLOT_NO = strDenbunDtl(XDSPPROD_LINE) & Format(TO_DATE(strDenbunDtl(DSPARRIVE_DT)), "yyyyMMdd")
            End If


            '************************************************************************************************
            '************************************************************************************************
            '1PL目在庫作成
            '************************************************************************************************
            '************************************************************************************************
            Dim strFPALLET_ID_OYA As String = ""
            Dim strFHINMEI_CD As String = ""
            '************************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(搬送先)(親)       取得
            '************************************************
            Dim objTPRG_TRK_BUF_TO_OYA As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF_TO_OYA.FTRK_BUF_NO = strDenbunDtl(DSPST_FM)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            intRet = objTPRG_TRK_BUF_TO_OYA.GET_TPRG_TRK_BUF_AKI_HIRA()         '取得
            If intRet <> RetCode.OK Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_TO_OYA.FTRK_BUF_NO) & "]"
                Throw New UserException(strMsg)
            End If


            If IsNull(strDenbunDtl(DSPPALLET_ID)) Then
                '(新規入庫の場合)


                '************************
                '在庫情報の登録(親)
                '************************
                Dim objTRST_STOCK_ADD_OYA As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)                     '在庫情報ﾃｰﾌﾞﾙｸﾗｽ
                Call TRST_STOCKAddProcess(objTRST_STOCK_ADD_OYA _
                                        , strDenbunDtl(DSPHINMEI_CD) _
                                        , strFLOT_NO _
                                        , dtmFARRIVE_DT _
                                        , TO_INTEGER_NULLABLE(strDenbunDtl(DSPIN_KUBUN)) _
                                        , TO_INTEGER_NULLABLE(strDenbunDtl(DSPHORYU_KUBUN)) _
                                        , TO_DECIMAL(strDenbunDtl(DSPTR_VOL)) _
                                        , FTR_RES_VOL_SKOTEI _
                                        , dtmNow _
                                        , strDenbunDtl(XDSPPROD_LINE) _
                                        , strDenbunDtl(XDSPKENSA_KUBUN) _
                                        , strDenbunDtl(XDSPKENPIN_KUBUN) _
                                        , strDenbunDtl(XDSPMAKER_CD) _
                                        , objTPRG_TRK_BUF_TO_OYA.FTRK_BUF_NO _
                                        )


                '************************
                '在庫登録(親)
                '************************
                Dim objSYS_100101_OYA As New SVR_100101(Owner, ObjDb, ObjDbLog)         '在庫作成ｸﾗｽ
                objSYS_100101_OYA.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_TO_OYA              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                objSYS_100101_OYA.FPALLET_ID = objTRST_STOCK_ADD_OYA.FPALLET_ID         'ﾊﾟﾚｯﾄID
                objSYS_100101_OYA.FINOUT_STS = FINOUT_STS_SIN_UKETUKE                   'INOUT(入庫設定)
                objSYS_100101_OYA.FSAGYOU_KIND = intFSAGYOU_KIND                        '作業種別(ｼｽﾃﾑ保守)
                objSYS_100101_OYA.STOCK_ADD()                                           '登録


                '************************
                '品目ﾏｽﾀ        取得
                '************************
                Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                objTMST_ITEM.FHINMEI_CD = objTRST_STOCK_ADD_OYA.FHINMEI_CD      '品目ｺｰﾄﾞ
                objTMST_ITEM.GET_TMST_ITEM()                                    '取得


                '************************
                'ﾃﾞｰﾀ               設定
                '************************
                strFPALLET_ID_OYA = objSYS_100101_OYA.FPALLET_ID    'ﾊﾟﾚｯﾄID
                strFHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)          '品目ｺｰﾄﾞ
                If objTMST_ITEM.FNUM_IN_PALLET <> objTRST_STOCK_ADD_OYA.FTR_VOL Then blnHasuBlock = True


            Else
                '(倉替入庫の場合)


                '************************************************
                '在庫情報           更新
                '************************************************
                Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                objTRST_STOCK.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)   'ﾊﾟﾚｯﾄID
                objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)               '取得
                For ii As Integer = 0 To UBound(objTRST_STOCK.ARYME)
                    '(ﾙｰﾌﾟ:在庫ﾛｯﾄ№数)
                    objTRST_STOCK.ARYME(ii).FIN_KUBUN = strDenbunDtl(DSPIN_KUBUN)               '入庫区分
                    objTRST_STOCK.ARYME(ii).XKENPIN_KUBUN = strDenbunDtl(XDSPKENPIN_KUBUN)      '検品区分
                    objTRST_STOCK.ARYME(ii).FUPDATE_DT = Now                                    '更新日時
                    objTRST_STOCK.ARYME(ii).UPDATE_TRST_STOCK_ALL()                             '更新
                Next


                '************************************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(平置)         取得
                '************************************************
                Dim objTPRG_TRK_BUF_HIRA As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_HIRA.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)    'ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_HIRA.GET_TPRG_TRK_BUF()                         '取得


                '************************
                '在庫移動
                '************************
                Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog)         '在庫移動ｸﾗｽ
                objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_HIRA             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_TO_OYA           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_HIRA.FPALLET_ID          'ﾊﾟﾚｯﾄID
                objSVR_100103.FINOUT_STS = FINOUT_STS_SKURAGAE_UKETUKE              'INOUT
                objSVR_100103.FSAGYOU_KIND = strDenbunDtl(DSPSAGYOU_KIND)           '作業種別
                objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                            '搬送元ｸﾘｱﾌﾗｸﾞ
                objSVR_100103.STOCK_TRNS()                                          '移動


                '************************
                '品目ﾏｽﾀ        取得
                '************************
                Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                objTMST_ITEM.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD     '品目ｺｰﾄﾞ
                objTMST_ITEM.GET_TMST_ITEM()                                    '取得


                '************************
                'ﾃﾞｰﾀ               設定
                '************************
                strFPALLET_ID_OYA = strDenbunDtl(DSPPALLET_ID)      'ﾊﾟﾚｯﾄID
                strFHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD   '品目ｺｰﾄﾞ
                If objTMST_ITEM.FNUM_IN_PALLET <> objTRST_STOCK.ARYME(0).FTR_VOL Then blnHasuBlock = True


            End If


            '************************************************************************************************
            '************************************************************************************************
            '2PL目在庫作成
            '************************************************************************************************
            '************************************************************************************************
            Dim objTPRG_TRK_BUF_TO_KOO As TBL_TPRG_TRK_BUF = Nothing
            Dim strFPALLET_ID_KOO As String = ""
            If blnPair = True Then
                '(ﾍﾟｱ搬送の場合)


                '************************************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(搬送先)(子)       取得
                '************************************************
                objTPRG_TRK_BUF_TO_KOO = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_TO_KOO.FTRK_BUF_NO = strDenbunDtl(DSPST_FM)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                intRet = objTPRG_TRK_BUF_TO_KOO.GET_TPRG_TRK_BUF_AKI_HIRA()         '取得
                If intRet <> RetCode.OK Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_TO_KOO.FTRK_BUF_NO) & "]"
                    Throw New UserException(strMsg)
                End If


                If IsNull(strDenbunDtl(XDSPPALLET_ID_KO)) Then
                    '(新規入庫の場合)


                    '************************
                    '在庫情報の登録(子)
                    '************************
                    Dim objTRST_STOCK_ADD_KOO As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                    Call TRST_STOCKAddProcess(objTRST_STOCK_ADD_KOO _
                                            , strDenbunDtl(DSPHINMEI_CD) _
                                            , strFLOT_NO _
                                            , dtmFARRIVE_DT _
                                            , TO_INTEGER_NULLABLE(strDenbunDtl(DSPIN_KUBUN)) _
                                            , TO_INTEGER_NULLABLE(strDenbunDtl(DSPHORYU_KUBUN)) _
                                            , TO_DECIMAL(strDenbunDtl(XDSPTR_VOL_KO)) _
                                            , FTR_RES_VOL_SKOTEI _
                                            , dtmNow _
                                            , strDenbunDtl(XDSPPROD_LINE) _
                                            , strDenbunDtl(XDSPKENSA_KUBUN) _
                                            , strDenbunDtl(XDSPKENPIN_KUBUN) _
                                            , strDenbunDtl(XDSPMAKER_CD) _
                                            , objTPRG_TRK_BUF_TO_KOO.FTRK_BUF_NO _
                                            )


                    '************************
                    '在庫登録(子)
                    '************************
                    Dim objSYS_100101_KOO As New SVR_100101(Owner, ObjDb, ObjDbLog)
                    objSYS_100101_KOO.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_TO_KOO              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                    objSYS_100101_KOO.FPALLET_ID = objTRST_STOCK_ADD_KOO.FPALLET_ID         'ﾊﾟﾚｯﾄID
                    objSYS_100101_KOO.FINOUT_STS = FINOUT_STS_SIN_UKETUKE                   'INOUT(入庫設定)
                    objSYS_100101_KOO.FSAGYOU_KIND = intFSAGYOU_KIND                        '作業種別(ｼｽﾃﾑ保守)
                    objSYS_100101_KOO.STOCK_ADD()                                           '登録


                    '************************
                    '品目ﾏｽﾀ        取得
                    '************************
                    Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                    objTMST_ITEM.FHINMEI_CD = objTRST_STOCK_ADD_KOO.FHINMEI_CD  '品目ｺｰﾄﾞ
                    objTMST_ITEM.GET_TMST_ITEM()                                '取得


                    '************************
                    'ﾊﾟﾚｯﾄID            設定
                    '************************
                    strFPALLET_ID_KOO = objSYS_100101_KOO.FPALLET_ID
                    If objTMST_ITEM.FNUM_IN_PALLET <> objTRST_STOCK_ADD_KOO.FTR_VOL Then blnHasuBlock = True


                Else
                    '(倉替入庫の場合)


                    '************************************************
                    '在庫情報           更新
                    '************************************************
                    Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                    objTRST_STOCK.FPALLET_ID = strDenbunDtl(XDSPPALLET_ID_KO)   'ﾊﾟﾚｯﾄID
                    objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)                   '取得
                    For ii As Integer = 0 To UBound(objTRST_STOCK.ARYME)
                        '(ﾙｰﾌﾟ:在庫ﾛｯﾄ№数)
                        objTRST_STOCK.ARYME(ii).FIN_KUBUN = strDenbunDtl(DSPIN_KUBUN)               '入庫区分

                        '↓↓↓↓↓↓************************************************************************************************************
                        'JobMate:S.Ouchi 2013/11/14 倉替入庫 検査区分＆検品区分の不具合修正
                        ''''objTRST_STOCK.ARYME(ii).XKENSA_KUBUN = strDenbunDtl(XDSPKENSA_KUBUN)        '検品区分
                        objTRST_STOCK.ARYME(ii).XKENPIN_KUBUN = strDenbunDtl(XDSPKENPIN_KUBUN)      '検品区分
                        'JobMate:S.Ouchi 2013/11/14 倉替入庫 検査区分＆検品区分の不具合修正
                        '↑↑↑↑↑↑************************************************************************************************************

                        objTRST_STOCK.ARYME(ii).FUPDATE_DT = Now                                    '更新日時
                        objTRST_STOCK.ARYME(ii).UPDATE_TRST_STOCK_ALL()                             '更新
                    Next


                    '************************************************
                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(平置)         取得
                    '************************************************
                    Dim objTPRG_TRK_BUF_HIRA As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    objTPRG_TRK_BUF_HIRA.FPALLET_ID = strDenbunDtl(XDSPPALLET_ID_KO)    'ﾊﾟﾚｯﾄID
                    objTPRG_TRK_BUF_HIRA.GET_TPRG_TRK_BUF()                             '取得


                    '************************
                    '在庫移動
                    '************************
                    Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog)         '在庫移動ｸﾗｽ
                    objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_HIRA             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                    objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_TO_KOO           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                    objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_HIRA.FPALLET_ID          'ﾊﾟﾚｯﾄID
                    objSVR_100103.FINOUT_STS = FINOUT_STS_SKURAGAE_UKETUKE              'INOUT
                    objSVR_100103.FSAGYOU_KIND = strDenbunDtl(DSPSAGYOU_KIND)           '作業種別
                    objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                            '搬送元ｸﾘｱﾌﾗｸﾞ
                    objSVR_100103.STOCK_TRNS()                                          '移動


                    '************************
                    '品目ﾏｽﾀ        取得
                    '************************
                    Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                    objTMST_ITEM.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD     '品目ｺｰﾄﾞ
                    objTMST_ITEM.GET_TMST_ITEM()                                    '取得


                    '************************
                    'ﾊﾟﾚｯﾄID            設定
                    '************************
                    strFPALLET_ID_KOO = strDenbunDtl(XDSPPALLET_ID_KO)
                    If objTMST_ITEM.FNUM_IN_PALLET <> objTRST_STOCK.ARYME(0).FTR_VOL Then blnHasuBlock = True


                End If


            End If


            '************************************************************************************************
            '************************************************************************************************
            '空棚引当処理
            '************************************************************************************************
            '************************************************************************************************
            Dim objTPRG_TRK_BUF_ASRS_OYA As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            Dim objTPRG_TRK_BUF_ASRS_KOO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            If strDenbunDtl(DSPST_TO) = FTRK_BUF_NO_J9000 Then
                '(通常入庫の場合)


                '**********************************************
                '空棚引当処理
                '**********************************************
                Dim objSYS_100201 As New SVR_100201(Owner, ObjDb, ObjDbLog) '空棚引当ｸﾗｽ
                intRet = AkitanaHikiate(objSYS_100201 _
                                      , objTPRG_TRK_BUF_ASRS_OYA _
                                      , objTPRG_TRK_BUF_ASRS_KOO _
                                      , objTPRG_TRK_BUF_TO_OYA _
                                      , strFPALLET_ID_OYA _
                                      , strFHINMEI_CD _
                                      , FTRK_BUF_NO_J9000 _
                                      , True _
                                      , blnPair _
                                      , IIf(IsNull(strDenbunDtl(XDSPTANA_BLOCK)), Nothing, TO_INTEGER(strDenbunDtl(XDSPTANA_BLOCK))) _
                                      , blnHasuBlock _
                                      )
                If intRet = RetCode.NotFound Then
                    '    '(見つからない場合)
                    Call AddToMsgLog(Now, FMSG_ID_S0102, objTPRG_TRK_BUF_TO_OYA.FDISP_ADDRESS, "品名ｺｰﾄﾞ:" & strFHINMEI_CD)
                    strMsg = ERRMSG_NOTFOUND_AKI
                    Throw New UserException(strMsg, False)
                    'Return RetCode.RollBack
                End If


            Else
                '(緊急入庫の場合)


                '**********************************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ        取得
                '**********************************************
                Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                objTMST_TRK.XTRK_BUF_NO_CONV = strDenbunDtl(DSPST_FM)   'ｺﾝﾍﾞｱ関連付け
                objTMST_TRK.GET_TMST_TRK()                              '取得


                '**********************************************
                '生産入庫設定状態       取得
                '**********************************************
                Dim objXSTS_PRODUCT_IN As New TBL_XSTS_PRODUCT_IN(Owner, ObjDb, ObjDbLog)
                objXSTS_PRODUCT_IN.FTRK_BUF_NO = objTMST_TRK.FTRK_BUF_NO    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objXSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN()                    '取得


                '**********************************************
                '出庫先STの設定
                '**********************************************
                '親
                objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO = objXSTS_PRODUCT_IN.XKINKYU_BUF_TO        'ﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_ARRAY = 1                                     '配列№
                objTPRG_TRK_BUF_ASRS_OYA.GET_TPRG_TRK_BUF()                                     '特定
                '子
                If blnPair = True Then
                    objTPRG_TRK_BUF_ASRS_KOO.FTRK_BUF_NO = objXSTS_PRODUCT_IN.XKINKYU_BUF_TO    'ﾊﾞｯﾌｧ№
                    objTPRG_TRK_BUF_ASRS_KOO.FTRK_BUF_ARRAY = 1                                 '配列№
                    objTPRG_TRK_BUF_ASRS_KOO.GET_TPRG_TRK_BUF()                                 '特定
                End If


            End If


            '************************************************************************************************
            '************************************************************************************************
            '1PL目設定
            '************************************************************************************************
            '************************************************************************************************
            '******************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ST)(親)の更新
            '******************************************
            objTPRG_TRK_BUF_TO_OYA.FRSV_BUF_TO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO               'TO引当ﾄﾗｯｷﾝｸﾞ№
            objTPRG_TRK_BUF_TO_OYA.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_ARRAY          'TO引当配列№
            objTPRG_TRK_BUF_TO_OYA.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_TO_OYA.FDISP_ADDRESS          'FM表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF_TO_OYA.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_ASRS_OYA.FDISP_ADDRESS        'TO表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF_TO_OYA.FBUF_IN_DT = Now                                                 'ﾊﾞｯﾌｧ入日時
            objTPRG_TRK_BUF_TO_OYA.UPDATE_TPRG_TRK_BUF()                                            '更新


            '************************
            '倉庫の更新(親)
            '************************
            If strDenbunDtl(DSPST_TO) = FTRK_BUF_NO_J9000 Then
                objTPRG_TRK_BUF_ASRS_OYA.FRSV_PALLET = objTPRG_TRK_BUF_TO_OYA.FPALLET_ID    '仮引当PC名
                objTPRG_TRK_BUF_ASRS_OYA.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                 '引当状態
                objTPRG_TRK_BUF_ASRS_OYA.FBUF_IN_DT = Now                                   'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_ASRS_OYA.UPDATE_TPRG_TRK_BUF()                              '更新
            End If


            '************************
            '在庫情報(親)       取得
            '************************
            Dim objTRST_STOCK_GET_OYA As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            objTRST_STOCK_GET_OYA.FPALLET_ID = strFPALLET_ID_OYA                'ﾊﾟﾚｯﾄID
            objTRST_STOCK_GET_OYA.GET_TRST_STOCK_KONSAI(True)                   '取得


            '************************************************
            '在庫情報(親)       入庫ﾄﾗｯｷﾝｸﾞ情報の更新
            '************************************************
            Call UpdateTRST_STOCK_InInfor(objTPRG_TRK_BUF_ASRS_OYA, objTRST_STOCK_GET_OYA)


            '************************
            '在庫引当情報(親)の登録
            '************************
            Dim objTSTS_HIKIATE_OYA As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)             '在庫引当情報ｸﾗｽ
            objTSTS_HIKIATE_OYA.FSAGYOU_KIND = intFSAGYOU_KIND                                  '作業種別
            objTSTS_HIKIATE_OYA.FPLAN_KEY = FPLAN_KEY_SKOTEI                                    '計画ｷｰ
            objTSTS_HIKIATE_OYA.FPALLET_ID = objTRST_STOCK_GET_OYA.ARYME(0).FPALLET_ID          'ﾊﾟﾚｯﾄID
            objTSTS_HIKIATE_OYA.FLOT_NO_STOCK = objTRST_STOCK_GET_OYA.ARYME(0).FLOT_NO_STOCK    '在庫ﾛｯﾄ№
            objTSTS_HIKIATE_OYA.FTR_VOL = objTRST_STOCK_GET_OYA.ARYME(0).FTR_VOL                '搬送管理量
            objTSTS_HIKIATE_OYA.FTERM_ID = DEFAULT_STRING                                       '端末ID
            objTSTS_HIKIATE_OYA.FUSER_ID = DEFAULT_STRING                                       'ﾕｰｻﾞｰID
            objTSTS_HIKIATE_OYA.FWAIT_REASON = FWAIT_REASON_JIN_YOUKYUU                         '指示送信待ち理由
            objTSTS_HIKIATE_OYA.FTRNS_START_DT = DEFAULT_DATE                                   '搬送開始日時
            objTSTS_HIKIATE_OYA.FTRNS_END_DT = DEFAULT_DATE                                     '搬送完了日時
            objTSTS_HIKIATE_OYA.FUPDATE_DT = Now                                                '更新日時
            objTSTS_HIKIATE_OYA.ADD_TSTS_HIKIATE()                                              '登録


            '************************************************************************************************
            '************************************************************************************************
            '2PL目設定
            '************************************************************************************************
            '************************************************************************************************
            If blnPair = True Then
                '(ﾍﾟｱ搬送の場合)


                '******************************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ST)(子)の更新
                '******************************************
                objTPRG_TRK_BUF_TO_KOO.FRSV_BUF_TO = objTPRG_TRK_BUF_ASRS_KOO.FTRK_BUF_NO               'TO引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_TO_KOO.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ASRS_KOO.FTRK_BUF_ARRAY          'TO引当配列№
                objTPRG_TRK_BUF_TO_KOO.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_TO_KOO.FDISP_ADDRESS          'FM表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_TO_KOO.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_ASRS_KOO.FDISP_ADDRESS        'TO表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_TO_KOO.FBUF_IN_DT = Now                                                 'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_TO_KOO.UPDATE_TPRG_TRK_BUF()                                            '更新


                '************************
                '倉庫の更新(子)
                '************************
                If strDenbunDtl(DSPST_TO) = FTRK_BUF_NO_J9000 Then
                    objTPRG_TRK_BUF_ASRS_KOO.FRSV_PALLET = objTPRG_TRK_BUF_TO_KOO.FPALLET_ID    '仮引当PC名
                    objTPRG_TRK_BUF_ASRS_KOO.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                 '引当状態
                    objTPRG_TRK_BUF_ASRS_KOO.FBUF_IN_DT = Now                                   'ﾊﾞｯﾌｧ入日時
                    objTPRG_TRK_BUF_ASRS_KOO.UPDATE_TPRG_TRK_BUF()                              '更新
                End If


                '************************
                '在庫情報(子)       取得
                '************************
                Dim objTRST_STOCK_GET_KOO As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                objTRST_STOCK_GET_KOO.FPALLET_ID = strFPALLET_ID_KOO                'ﾊﾟﾚｯﾄID
                objTRST_STOCK_GET_KOO.GET_TRST_STOCK_KONSAI(True)                   '取得


                '************************************************
                '在庫情報(子)       入庫ﾄﾗｯｷﾝｸﾞ情報の更新
                '************************************************
                Call UpdateTRST_STOCK_InInfor(objTPRG_TRK_BUF_ASRS_KOO, objTRST_STOCK_GET_KOO)


                '************************
                '在庫引当情報(子)の登録
                '************************
                Dim objTSTS_HIKIATE_KOO As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)             '在庫引当情報ｸﾗｽ
                objTSTS_HIKIATE_KOO.FSAGYOU_KIND = intFSAGYOU_KIND                                  '作業種別
                objTSTS_HIKIATE_KOO.FPLAN_KEY = FPLAN_KEY_SKOTEI                                    '計画ｷｰ
                objTSTS_HIKIATE_KOO.FPALLET_ID = objTRST_STOCK_GET_KOO.ARYME(0).FPALLET_ID          'ﾊﾟﾚｯﾄID
                objTSTS_HIKIATE_KOO.FLOT_NO_STOCK = objTRST_STOCK_GET_KOO.ARYME(0).FLOT_NO_STOCK    '在庫ﾛｯﾄ№
                objTSTS_HIKIATE_KOO.FTR_VOL = objTRST_STOCK_GET_KOO.ARYME(0).FTR_VOL                '搬送管理量
                objTSTS_HIKIATE_KOO.FTERM_ID = DEFAULT_STRING                                       '端末ID
                objTSTS_HIKIATE_KOO.FUSER_ID = DEFAULT_STRING                                       'ﾕｰｻﾞｰID
                objTSTS_HIKIATE_KOO.FWAIT_REASON = FWAIT_REASON_JIN_YOUKYUU                         '指示送信待ち理由
                objTSTS_HIKIATE_KOO.FTRNS_START_DT = DEFAULT_DATE                                   '搬送開始日時
                objTSTS_HIKIATE_KOO.FTRNS_END_DT = DEFAULT_DATE                                     '搬送完了日時
                objTSTS_HIKIATE_KOO.FUPDATE_DT = Now                                                '更新日時
                objTSTS_HIKIATE_KOO.ADD_TSTS_HIKIATE()                                              '登録


            End If


            ''************************************************************************************************
            ''************************************************************************************************
            ''棚ﾌﾞﾛｯｸ状態            更新
            ''ｸﾚｰﾝ優先順             更新
            ''************************************************************************************************
            ''************************************************************************************************
            'If TO_INTEGER(strDenbunDtl(DSPST_TO)) = FTRK_BUF_NO_J9000 Then
            '    '(自動倉庫への入庫の場合)

            '    If blnHasu = False Then
            '        '(端数在庫が存在しない 場合)


            '        '************************************************
            '        '棚ﾌﾞﾛｯｸ状態の更新
            '        '************************************************
            '        Call UpdateTPRG_TRK_BUF_Relation_XTANA_BLOCK_STS(objTPRG_TRK_BUF_ASRS_OYA, XTANA_BLOCK_STS_IN)


            '    Else
            '        '(端数在庫が存在する 場合)

            '        If TO_INTEGER(objTPRG_TRK_BUF_ASRS_OYA.FRAC_EDA) = FLAG_ON Then
            '            '(奥棚の場合)


            '            '************************************************
            '            'ｸﾚｰﾝ優先順の更新
            '            '************************************************
            '            '====================================
            '            'ｸﾚｰﾝﾏｽﾀの特定
            '            '====================================
            '            Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)             'ｸﾚｰﾝﾏｽﾀｸﾗｽ
            '            objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO            'ﾊﾞｯﾌｧ№
            '            objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS_OYA.FRAC_RETU             '列
            '            intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                                   '特定
            '            If intRet = RetCode.NotFound Then
            '                '(見つからない場合)
            '                strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
            '                Throw New UserException(strMsg)
            '            End If

            '            '====================================
            '            'ｸﾚｰﾝ優先順の更新
            '            '====================================
            '            Dim objSVR_100205 As New SVR_100205(Owner, ObjDb, ObjDbLog)     'ｸﾚｰﾝ優先順更新ｸﾗｽ
            '            objSVR_100205.FTRK_BUF_NO = TO_INTEGER(strDenbunDtl(DSPST_TO))  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            '            objSVR_100205.FEQ_ID = objTMST_CRANE.FEQ_ID                     '使用設備ID
            '            objSVR_100205.CRANE_ORDER_UPDATE()                              '更新


            '        End If

            '    End If

            'End If


            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_J310102)                           '起動


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  入庫設定                     (SVR_400001)STから直接入庫指示を送信するﾊﾟﾀｰﾝで、今回は未使用   "
    ''''**********************************************************************************************
    '''' <summary>
    '''' 入庫設定
    '''' </summary>
    '''' <param name="strDenbunDtl">電文分解配列</param>
    '''' <param name="strMSG_RECV">受信電文</param>
    '''' <param name="strMSG_SEND">送信電文</param>
    '''' <param name="strFPALLET_ID">あらかじめ作成しておいたﾊﾟﾚｯﾄID</param>
    '''' <param name="strFTRK_BUF_NO_ASRS">あらかじめ予約しておいた倉庫のﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    '''' <param name="strFTRK_BUF_ARRAY_ASRS">あらかじめ予約しておいた倉庫のﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№</param>
    '''' <param name="strXOYAKO_KUBUN">親子区分</param>
    '''' <param name="strXPALLET_ID_AITE">相手ﾊﾟﾚｯﾄID</param>
    '''' <returns>OK/NG</returns>
    '''' <remarks></remarks>
    ''''**********************************************************************************************
    'Public Function SVR_400001_Process(ByVal strDenbunDtl() As String _
    '                                 , ByVal strMSG_RECV As String _
    '                                 , ByRef strMSG_SEND As String _
    '                                 , ByVal strFPALLET_ID As String _
    '                                 , ByVal strFTRK_BUF_NO_ASRS As String _
    '                                 , ByVal strFTRK_BUF_ARRAY_ASRS As String _
    '                                 , ByVal strXOYAKO_KUBUN As String _
    '                                 , ByVal strXPALLET_ID_AITE As String _
    '                                 ) As RetCode


    '    Dim intRet As RetCode                 '戻り値
    '    Dim strMsg As String                  'ﾒｯｾｰｼﾞ

    '    '電文分解用
    '    Dim DSPTERM_ID As Integer = 0             '端末ID
    '    Dim DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
    '    Dim DSPREASON As Integer = 2              '理由
    '    Dim DSPST_FM As Integer = 3               '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '    Dim DSPST_TO As Integer = 4               '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '    Dim DSPPALLET_ID As Integer = 5           'ﾊﾟﾚｯﾄID
    '    Dim DSPLOT_NO_STOCK As Integer = 6        '在庫ﾛｯﾄ№
    '    Dim DSPSAGYOU_KIND As Integer = 7         '作業種別
    '    Dim DSPHINMEI_CD As Integer = 8           '品名ｺｰﾄﾞ
    '    Dim DSPTR_VOL As Integer = 9              '搬送管理量
    '    Dim XDSPIN_KIND As Integer = 10           '入庫種別
    '    Dim XDSPIN_SITEI As Integer = 11          '入庫指定
    '    Dim XDSPPROD_LINE As Integer = 12         '生産ﾗｲﾝ№
    '    Dim XDSPKENSA_KUBUN As Integer = 13       '検査区分
    '    Dim DSPHORYU_KUBUN As Integer = 14        '保留区分
    '    Dim XDSPTR_VOL_KO As Integer = 15         '搬送管理量(子)
    '    Dim XDSPKENSA_KUBUN_KO As Integer = 16    '検査区分(子)
    '    Dim XDSPHORYU_KUBUN_KO As Integer = 17    '保留区分(子)
    '    Dim XDSPST_TO_ARRAY01 As Integer = 18     '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№01
    '    Dim XDSPST_TO_ARRAY02 As Integer = 19     '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№02

    '    Try


    '        '************************************************
    '        '搬送元STのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ      取得
    '        '************************************************
    '        Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
    '        objTMST_TRK.FTRK_BUF_NO = strDenbunDtl(DSPST_FM)
    '        objTMST_TRK.GET_TMST_TRK()


    '        '************************
    '        '搬送元ST取得
    '        '************************
    '        Dim intFTRK_BUF_NO_FM As Integer = strDenbunDtl(DSPST_FM)   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(FM)
    '        Dim intFTRK_BUF_NO_TO As Integer                            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(TO)
    '        Dim intFSAGYOU_KIND As Integer = strDenbunDtl(DSPSAGYOU_KIND)   '作業種別

    '        '************************
    '        '空ﾊﾞｯﾌｧの特定
    '        '************************
    '        Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙｸﾗｽ
    '        If IsNull(strFPALLET_ID) Then
    '            objTPRG_TRK_BUF_FM.FTRK_BUF_NO = intFTRK_BUF_NO_FM                      '入庫設定ST
    '            intRet = objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF_AKI_HIRA                   '特定
    '            If intRet = RetCode.NotFound Then
    '                '(見つからない場合)
    '                strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_FM.FTRK_BUF_NO) & "]"
    '                Throw New UserException(strMsg)
    '            End If
    '        End If


    '        If IsNull(strFPALLET_ID) Then
    '            '(在庫情報がない場合)

    '            Throw New Exception("ﾍﾟｱ搬送とか絡むとややこしくなるので、ここでは在庫作成しない。")

    '            ' '' ''************************
    '            ' '' ''品目ﾏｽﾀ        取得
    '            ' '' ''************************
    '            '' ''Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
    '            '' ''objTMST_ITEM.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)        '品目ｺｰﾄﾞ
    '            '' ''intRet = objTMST_ITEM.GET_TMST_ITEM(False)                  '取得
    '            '' ''If intRet <> RetCode.OK Then
    '            '' ''    '(見つからない場合)
    '            '' ''    Call AddToMsgLog(Now, FMSG_ID_S0201, objTMST_ITEM.FHINMEI_CD)
    '            '' ''    strMsg = ERRMSG_NOTFOUND_TMST_ITEM
    '            '' ''    Throw New UserException(strMsg, False)
    '            '' ''    'Return RetCode.RollBack
    '            '' ''End If


    '            ' '' ''************************
    '            ' '' ''在庫情報の登録
    '            ' '' ''************************
    '            '' ''Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)                     '在庫情報ﾃｰﾌﾞﾙｸﾗｽ
    '            '' ''Call TRST_STOCKAddProcess(objTRST_STOCK _
    '            '' ''                        , strDenbunDtl(DSPHINMEI_CD) _
    '            '' ''                        , Now _
    '            '' ''                        , FHORYU_KUBUN_SNORMAL _
    '            '' ''                        , TO_DECIMAL(strDenbunDtl(DSPTR_VOL)) _
    '            '' ''                        , FTR_RES_VOL_SKOTEI _
    '            '' ''                        , Now _
    '            '' ''                        , TO_DATE(strDenbunDtl(XDSPSEIZOU_DT)) _
    '            '' ''                        , strDenbunDtl(XDSPLINE_NO) _
    '            '' ''                        , strDenbunDtl(XDSPPALLET_NO) _
    '            '' ''                        , strDenbunDtl(XDSPKENSA_KUBUN) _
    '            '' ''                        , strDenbunDtl(XDSPAB_KUBUN) _
    '            '' ''                        , intXSYUKKA_KAHI _
    '            '' ''                        , IIf(objTMST_ITEM.XSTRETCH_KUBUN = XSTRETCH_KUBUN_JON, XSTRETCH_STS_JNONE, XSTRETCH_STS_JEND) _
    '            '' ''                        , intXHINSHITU_STS _
    '            '' ''                        , Nothing _
    '            '' ''                        , Nothing _
    '            '' ''                        , Nothing _
    '            '' ''                        , strDenbunDtl(XDSPBC_DATA) _
    '            '' ''                        , Nothing _
    '            '' ''                        , Now _
    '            '' ''                        , Nothing _
    '            '' ''                        )
    '            '' ''strFPALLET_ID = objTRST_STOCK.FPALLET_ID                                            'ﾊﾟﾚｯﾄID更新


    '            ' '' ''************************
    '            ' '' ''在庫引当情報の登録
    '            ' '' ''************************
    '            '' ''Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '在庫引当情報ｸﾗｽ
    '            '' ''objTSTS_HIKIATE.FSAGYOU_KIND = intFSAGYOU_KIND                      '作業種別
    '            '' ''objTSTS_HIKIATE.FPLAN_KEY = FPLAN_KEY_SKOTEI                        '計画ｷｰ
    '            '' ''objTSTS_HIKIATE.FPALLET_ID = objTRST_STOCK.FPALLET_ID               'ﾊﾟﾚｯﾄID
    '            '' ''objTSTS_HIKIATE.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK         '在庫ﾛｯﾄ№
    '            '' ''objTSTS_HIKIATE.FTR_VOL = objTRST_STOCK.FTR_VOL                     '搬送管理量
    '            '' ''objTSTS_HIKIATE.FTERM_ID = DEFAULT_STRING                           '端末ID
    '            '' ''objTSTS_HIKIATE.FUSER_ID = DEFAULT_STRING                           'ﾕｰｻﾞｰID
    '            '' ''objTSTS_HIKIATE.FWAIT_REASON = DEFAULT_STRING                       '指示送信待ち理由
    '            '' ''objTSTS_HIKIATE.FTRNS_START_DT = DEFAULT_DATE                       '搬送開始日時
    '            '' ''objTSTS_HIKIATE.FTRNS_END_DT = DEFAULT_DATE                         '搬送完了日時
    '            '' ''objTSTS_HIKIATE.FUPDATE_DT = Now                                    '更新日時
    '            '' ''objTSTS_HIKIATE.ADD_TSTS_HIKIATE()                                  '登録


    '            ' '' ''************************
    '            ' '' ''在庫登録
    '            ' '' ''************************
    '            '' ''Dim objSYS_100101 As New SVR_100101(Owner, ObjDb, ObjDbLog)         '在庫作成ｸﾗｽ
    '            '' ''objSYS_100101.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_FM                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    '            '' ''objSYS_100101.FPALLET_ID = objTRST_STOCK.FPALLET_ID                 'ﾊﾟﾚｯﾄID
    '            '' ''objSYS_100101.FINOUT_STS = FINOUT_STS_SIN_UKETUKE                   'INOUT(入庫設定)
    '            '' ''objSYS_100101.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND           '作業種別(ｼｽﾃﾑ保守)
    '            '' ''objSYS_100101.STOCK_ADD()                                           '登録


    '        Else
    '            '(在庫情報がある場合)


    '            '************************
    '            'STﾄﾗｯｷﾝｸﾞの特定
    '            '************************
    '            objTPRG_TRK_BUF_FM.FTRK_BUF_NO = intFTRK_BUF_NO_FM          '入庫設定ST
    '            objTPRG_TRK_BUF_FM.FPALLET_ID = strFPALLET_ID               'ﾊﾟﾚｯﾄID
    '            objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF()                       '特定

    '        End If


    '        '************************
    '        'ﾊﾞｯﾌｧの更新
    '        '************************
    '        objTPRG_TRK_BUF_FM.FRSV_PALLET = strFPALLET_ID                         '仮引当ﾊﾟﾚｯﾄID
    '        objTPRG_TRK_BUF_FM.FRES_KIND = FRES_KIND_SZAIKO                        '引当状態
    '        objTPRG_TRK_BUF_FM.FTR_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO             '搬送FMﾊﾞｯﾌｧ№
    '        objTPRG_TRK_BUF_FM.FTR_TO = intFTRK_BUF_NO_TO                          '搬送TOﾊﾞｯﾌｧ№
    '        objTPRG_TRK_BUF_FM.FTR_IDOU = intFTRK_BUF_NO_TO                        '搬送TO移動ﾊﾞｯﾌｧ№
    '        objTPRG_TRK_BUF_FM.FTRNS_FM = DEFAULT_STRING                           '搬送指令用FM
    '        objTPRG_TRK_BUF_FM.FTRNS_TO = DEFAULT_STRING                           '搬送指令用TO
    '        objTPRG_TRK_BUF_FM.FRSV_BUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO        'FM引当ﾊﾞｯﾌｧ№
    '        objTPRG_TRK_BUF_FM.FRSV_ARRAY_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY   'FM引当配列№
    '        objTPRG_TRK_BUF_FM.FRSV_BUF_TO = DEFAULT_INTEGER                       'TO引当ﾊﾞｯﾌｧ№
    '        objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO = DEFAULT_INTEGER                     'TO引当配列№
    '        objTPRG_TRK_BUF_FM.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_FM.FDISP_ADDRESS 'FM表記用ｱﾄﾞﾚｽ
    '        objTPRG_TRK_BUF_FM.FDISP_ADDRESS_TO = DEFAULT_STRING                   'TO表記用ｱﾄﾞﾚｽ
    '        objTPRG_TRK_BUF_FM.FBUF_IN_DT = Now                                    'ﾊﾞｯﾌｧ入日時
    '        objTPRG_TRK_BUF_FM.UPDATE_TPRG_TRK_BUF()                               '更新


    '        '************************
    '        '倉庫ﾊﾞｯﾌｧの特定
    '        '************************
    '        Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
    '        If IsNull(strFTRK_BUF_NO_ASRS) And IsNull(strFTRK_BUF_ARRAY_ASRS) Then
    '            '(まだ棚が確定していない場合)

    '            Throw New Exception("ここの時点では空棚が確定していないといけません。")


    '            ''**********************************************
    '            ''空棚引当処理
    '            ''**********************************************
    '            'Dim objSYS_100201 As New SVR_100201(Owner, ObjDb, ObjDbLog) '空棚引当ｸﾗｽ
    '            'intRet = AkitanaHikiate(objSYS_100201 _
    '            '                      , objTPRG_TRK_BUF_ASRS _
    '            '                      , objTPRG_TRK_BUF_FM _
    '            '                      , strFPALLET_ID _
    '            '                      , strDenbunDtl(DSPHINMEI_CD) _
    '            '                      , FTRK_BUF_NO_J9000 _
    '            '                      , True _
    '            '                      )


    '            'If intRet = RetCode.NotFound Then
    '            '    '    '(見つからない場合)
    '            '    Call AddToMsgLog(Now, FMSG_ID_S0102, objTMST_TRK.FBUF_NAME, "品名ｺｰﾄﾞ:" & strDenbunDtl(DSPHINMEI_CD))
    '            '    strMsg = ERRMSG_NOTFOUND_AKI
    '            '    Throw New UserException(strMsg, False)
    '            '    'Return RetCode.RollBack
    '            'End If


    '            ''↓↓↓↓↓↓**********************************************************************************************************************************************************************************************
    '            ''SystemMate:N.Dounoshita 2012/08/15  空棚引当処理の共通化


    '            ' '' '' ''************************************************
    '            ' '' '' ''品目ﾏｽﾀ      取得
    '            ' '' '' ''************************************************
    '            '' '' ''Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
    '            '' '' ''objTMST_ITEM.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)
    '            '' '' ''objTMST_ITEM.GET_TMST_ITEM()


    '            ' '' '' ''************************************************
    '            ' '' '' ''引当ﾀｲﾌﾟ特定ﾏｽﾀ        取得
    '            ' '' '' ''************************************************
    '            '' '' ''Dim objTMST_SP_RES_TYPE As New TBL_TMST_SP_RES_TYPE(Owner, ObjDb, ObjDbLog)
    '            '' '' ''objTMST_SP_RES_TYPE.FCONDITION01 = objTMST_ITEM.XNIDAKA_KUBUN
    '            '' '' ''objTMST_SP_RES_TYPE.GET_TMST_SP_RES_TYPE()


    '            ' '' '' ''↓↓↓↓↓↓************************************************************************************************************
    '            ' '' '' ''JobMate:A.Noto 2012/07/07 ｸﾚｰﾝ引当処理追加

    '            ' '' '' ''************************
    '            ' '' '' ''ｸﾚｰﾝの特定
    '            ' '' '' ''************************
    '            '' '' ''Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)         'ｼｽﾃﾑ変数ｸﾗｽ
    '            '' '' ''objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS000000_002                         '変数ID
    '            '' '' ''intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                             '取得
    '            ' '' '' ''品目ﾏｽﾀの最終引当ｸﾚｰﾝIDで更新
    '            '' '' ''objTPRG_SYS_HEN.OBJCHANGE_DATA = objTMST_ITEM.XHIKIATE_CRANE_ID             '変更ﾃﾞｰﾀ
    '            '' '' ''objTPRG_SYS_HEN.UPDATE_TPRG_SYS_HEN_OBJ()                                   '更新

    '            ' '' '' ''************************
    '            ' '' '' ''ｸﾚｰﾝ優先順の作成
    '            ' '' '' ''************************
    '            '' '' ''Dim strFEQ_ID_CRANE() As String
    '            '' '' ''objTPRG_SYS_HEN.FHENSU_CHAR = Nothing
    '            '' '' ''intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                             '取得
    '            '' '' ''strFEQ_ID_CRANE = Split(objTPRG_SYS_HEN.FHENSU_CHAR, KUGIRI01)

    '            ' '' '' ''↑↑↑↑↑↑************************************************************************************************************


    '            ' '' '' ''************************
    '            ' '' '' ''倉庫ﾊﾞｯﾌｧの特定
    '            ' '' '' ''************************
    '            '' '' ''Dim objSYS_100201 As New SVR_100201(Owner, ObjDb, ObjDbLog) '空棚引当ｸﾗｽ
    '            '' '' ''objSYS_100201.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTR_TO       'ﾊﾞｯﾌｧ№(倉庫)
    '            ' '' '' ''objSYS_100201.FRAC_FORM = objTMST_ITEM.FRAC_FORM            '棚形状種別
    '            '' '' ''objSYS_100201.FRES_TYPE = objTMST_SP_RES_TYPE.FRES_TYPE     '引当ﾀｲﾌﾟ
    '            '' '' ''objSYS_100201.FPALLET_ID = strFPALLET_ID                    'ﾊﾟﾚｯﾄID
    '            '' '' ''objSYS_100201.FEQ_ID_CRANE = strFEQ_ID_CRANE                '元ｸﾚｰﾝ設備ID
    '            '' '' ''intRet = objSYS_100201.FIND_TANA_AKI            '特定
    '            '' '' ''If intRet = RetCode.NotFound Then
    '            '' '' ''    '(見つからない場合)

    '            '' '' ''    Call AddToMsgLog(Now, FMSG_ID_S0102, objTMST_TRK.FBUF_NAME)
    '            '' '' ''    strMsg = ERRMSG_NOTFOUND_AKI
    '            '' '' ''    Throw New UserException(strMsg, False)
    '            '' '' ''    'Return RetCode.RollBack
    '            '' '' ''End If
    '            '' '' ''objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objSYS_100201.FTRK_BUF_NO                'ﾊﾞｯﾌｧ№
    '            '' '' ''objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objSYS_100201.FTRK_BUF_ARRAY          '配列№
    '            '' '' ''objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()                                     '特定


    '            ' '' '' ''↓↓↓↓↓↓************************************************************************************************************
    '            ' '' '' ''CommentMate:A.Noto 2012/07/07 後でｸﾚｰﾝ引当処理追加

    '            ' '' '' ''************************
    '            ' '' '' ''ｸﾚｰﾝの特定
    '            ' '' '' ''************************
    '            '' '' ''Dim objTPRG_SYS_HEN_BEFORE As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)         'ｼｽﾃﾑ変数ｸﾗｽ
    '            '' '' ''objTPRG_SYS_HEN_BEFORE.FHENSU_ID = FHENSU_ID_SSS000000_002                         '変数ID
    '            '' '' ''intRet = objTPRG_SYS_HEN_BEFORE.GET_TPRG_SYS_HEN(True)                             '取得

    '            ' '' '' ''************************
    '            ' '' '' ''品名ﾏｽﾀ更新
    '            ' '' '' ''************************
    '            '' '' ''objTMST_ITEM.XHIKIATE_CRANE_ID = objTPRG_SYS_HEN_BEFORE.FHENSU_CHAR
    '            '' '' ''objTMST_ITEM.UPDATE_TMST_ITEM()

    '            ' '' '' ''↑↑↑↑↑↑************************************************************************************************************


    '            ''↑↑↑↑↑↑**********************************************************************************************************************************************************************************************


    '        Else
    '            '(既に棚が確定している場合)


    '            '************************
    '            '倉庫ﾊﾞｯﾌｧの特定
    '            '************************
    '            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = strFTRK_BUF_NO_ASRS              'ﾊﾞｯﾌｧ№
    '            objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = strFTRK_BUF_ARRAY_ASRS        '配列№
    '            objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()                             '特定


    '            '************************
    '            '作業種別の変更
    '            '************************
    '            intFSAGYOU_KIND = FSAGYOU_KIND_SIN_PICK


    '        End If


    '        '************************
    '        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ST)の更新
    '        '************************
    '        objTPRG_TRK_BUF_FM.FRSV_BUF_TO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO               'TO引当ﾄﾗｯｷﾝｸﾞ№
    '        objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY          'TO引当配列№
    '        objTPRG_TRK_BUF_FM.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_FM.FDISP_ADDRESS          'FM表記用ｱﾄﾞﾚｽ
    '        objTPRG_TRK_BUF_FM.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS        'TO表記用ｱﾄﾞﾚｽ
    '        objTPRG_TRK_BUF_FM.FBUF_IN_DT = Now                                             'ﾊﾞｯﾌｧ入日時
    '        objTPRG_TRK_BUF_FM.UPDATE_TPRG_TRK_BUF()                                        '更新


    '        '************************
    '        '倉庫の更新
    '        '************************
    '        objTPRG_TRK_BUF_ASRS.FRSV_PALLET = objTPRG_TRK_BUF_FM.FPALLET_ID        '仮引当PC名
    '        objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                 '引当状態
    '        objTPRG_TRK_BUF_ASRS.FBUF_IN_DT = Now                                   'ﾊﾞｯﾌｧ入日時
    '        objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                              '更新


    '        '↓↓↓↓↓↓************************************************************************************************************
    '        'JobMate:N.Dounoshita 2013/04/04 棚ﾌﾞﾛｯｸ状態を更新


    '        '************************************************
    '        '棚ﾌﾞﾛｯｸ状態の更新
    '        '************************************************
    '        Call UpdateTPRG_TRK_BUF_Relation_XTANA_BLOCK_STS(objTPRG_TRK_BUF_ASRS, XTANA_BLOCK_STS_IN)


    '        '↑↑↑↑↑↑************************************************************************************************************


    '        '************************************************
    '        '入庫指示用の搬送指示QUEを追加
    '        '************************************************
    '        Call Add_In_TPLN_CARRY_QUE_Process(objTPRG_TRK_BUF_FM, intFSAGYOU_KIND, strXOYAKO_KUBUN, strXPALLET_ID_AITE)


    '        '************************
    '        '次処理起動
    '        '************************
    '        Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
    '        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動


    '        Return RetCode.OK
    '    Catch ex As UserException
    '        Call ComUser(ex, MeSyoriID)
    '        Throw New UserException(ex.Message)
    '    Catch ex As Exception
    '        Call ComError(ex, MeSyoriID)
    '        Throw New Exception(ex.Message)
    '    End Try
    'End Function
#End Region
#Region "  平置き出庫                   (SVR_400102)                                                "
    '''**********************************************************************************************
    ''' <summary>
    ''' 平置き出庫
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SVR_400102_Process(ByVal strDenbunDtl() As String _
                                     , ByVal strMSG_RECV As String _
                                     , ByRef strMSG_SEND As String _
                                     ) As RetCode
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ

        '電文分解用
        Dim DSPTERM_ID As Integer = 0         '端末ID
        Dim DSPUSER_ID As Integer = 1         'ﾕｰｻﾞｰID
        Dim DSPREASON As Integer = 2          '理由
        Dim DSPPALLET_ID As Integer = 3       'ﾊﾟﾚｯﾄID

        Try


            '************************************************
            'ﾄﾗｯｷﾝｸﾞの特定
            '************************************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)     'ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                          '特定


            '************************
            'IN/OUT     設定
            '************************
            Dim intFINOUT_STS As Integer = 0


            '************************
            'ﾄﾗｯｷﾝｸﾞ削除
            '************************
            Dim objSVR_100302 As New SVR_100302(Owner, ObjDb, ObjDbLog)
            objSVR_100302.FTRK_BUF_NO = objTPRG_TRK_BUF.FTRK_BUF_NO     'ﾊﾞｯﾌｧ№
            objSVR_100302.FPALLET_ID = objTPRG_TRK_BUF.FPALLET_ID       'ﾊﾟﾚｯﾄID
            objSVR_100302.FINOUT_STS = intFINOUT_STS                    'IN/OUT
            objSVR_100302.FTERM_ID = FTERM_ID_SKOTEI                    '端末ID
            objSVR_100302.FUSER_ID = FUSER_ID_SKOTEI                    'ﾕｰｻﾞｰID
            objSVR_100302.MENTE_DELETE()                                'ﾄﾗｯｷﾝｸﾞ削除


            Return RetCode.OK
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  直行設定                     (SVR_499999)                                                "
    '''**********************************************************************************************
    ''' <summary>
    ''' 直行設定
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SVR_499999_Process(ByVal strDenbunDtl() As String _
                                     , ByVal strMSG_RECV As String _
                                     , ByRef strMSG_SEND As String _
                                     , Optional ByVal strFPALLET_ID As String = Nothing _
                                     , Optional ByVal strFTRK_BUF_NO_ASRS As String = Nothing _
                                     , Optional ByVal strFTRK_BUF_ARRAY_ASRS As String = Nothing _
                                     , Optional ByVal strXOYAKO_KUBUN As String = Nothing _
                                     , Optional ByVal strXPALLET_ID_AITE As String = Nothing _
                                     ) As RetCode
        Dim intRet As RetCode                 '戻り値
        Dim strMsg As String                  'ﾒｯｾｰｼﾞ

        '電文分解用
        Dim DSPTERM_ID As Integer = 0             '端末ID
        Dim DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
        Dim DSPREASON As Integer = 2              '理由
        Dim DSPST_FM As Integer = 3               '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        Dim DSPST_TO As Integer = 4               '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        Dim DSPPALLET_ID As Integer = 5           'ﾊﾟﾚｯﾄID
        Dim DSPLOT_NO_STOCK As Integer = 6        '在庫ﾛｯﾄ№
        Dim DSPSAGYOU_KIND As Integer = 7         '作業種別
        Dim DSPHINMEI_CD As Integer = 8           '品名ｺｰﾄﾞ
        Dim DSPTR_VOL As Integer = 9              '搬送管理量
        Dim XDSPIN_KIND As Integer = 10           '入庫種別
        Dim XDSPIN_SITEI As Integer = 11          '入庫指定
        Dim XDSPPROD_LINE As Integer = 12         '生産ﾗｲﾝ№
        Dim XDSPKENSA_KUBUN As Integer = 13       '検査区分
        Dim DSPHORYU_KUBUN As Integer = 14        '保留区分
        Dim XDSPTR_VOL_KO As Integer = 15         '搬送管理量(子)
        Dim XDSPKENSA_KUBUN_KO As Integer = 16    '検査区分(子)
        Dim XDSPHORYU_KUBUN_KO As Integer = 17    '保留区分(子)
        Dim XDSPST_TO_ARRAY01 As Integer = 18     '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№01
        Dim XDSPST_TO_ARRAY02 As Integer = 19     '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№02

        Try


            '************************
            '搬送元ST取得
            '************************
            Dim intFTRK_BUF_NO_FM As Integer = strDenbunDtl(DSPST_FM)           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(FM)
            Dim intFTRK_BUF_NO_TO As Integer = strDenbunDtl(DSPST_TO)           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(TO)
            Dim intFSAGYOU_KIND As Integer = strDenbunDtl(DSPSAGYOU_KIND)       '作業種別


            '************************
            '空ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙｸﾗｽ
            If IsNull(strFPALLET_ID) Then
                objTPRG_TRK_BUF_FM.FTRK_BUF_NO = intFTRK_BUF_NO_FM                     '入庫設定ST
                intRet = objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF_AKI_HIRA                  '特定
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_FM.FTRK_BUF_NO) & "]"
                    Throw New UserException(strMsg)
                End If
            End If


            If IsNull(strFPALLET_ID) Then
                '(在庫情報がない場合)


                '************************
                '品目ﾏｽﾀ        取得
                '************************
                Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                objTMST_ITEM.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)        '品目ｺｰﾄﾞ
                intRet = objTMST_ITEM.GET_TMST_ITEM(False)                  '取得
                If intRet <> RetCode.OK Then
                    '(見つからない場合)
                    Call AddToMsgLog(Now, FMSG_ID_S0201, objTMST_ITEM.FHINMEI_CD)
                    strMsg = ERRMSG_NOTFOUND_TMST_ITEM
                    Throw New UserException(strMsg, False)
                    'Return RetCode.RollBack
                End If

                '↓↓↓↓↓↓************************************************************************************************************
                'Checked Comment:A.Noto 2013/03/21 ﾌﾟﾛｸﾞﾗﾑ整理時のｺﾒﾝﾄｱｳﾄ
                ''************************
                ''在庫情報の登録
                ''************************
                'Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)                     '在庫情報ﾃｰﾌﾞﾙｸﾗｽ
                'Call TRST_STOCKAddProcess(objTRST_STOCK _
                '                        , strDenbunDtl(DSPHINMEI_CD) _
                '                        , Now _
                '                        , FHORYU_KUBUN_SNORMAL _
                '                        , TO_DECIMAL(strDenbunDtl(DSPTR_VOL)) _
                '                        , FTR_RES_VOL_SKOTEI _
                '                        , Now _
                '                        , TO_DATE(strDenbunDtl(XDSPSEIZOU_DT)) _
                '                        , strDenbunDtl(XDSPLINE_NO) _
                '                        , strDenbunDtl(XDSPPALLET_NO) _
                '                        , strDenbunDtl(XDSPKENSA_KUBUN) _
                '                        , strDenbunDtl(XDSPAB_KUBUN) _
                '                        , intXSYUKKA_KAHI _
                '                        , IIf(objTMST_ITEM.XSTRETCH_KUBUN = XSTRETCH_KUBUN_JON, XSTRETCH_STS_JNONE, XSTRETCH_STS_JEND) _
                '                        , intXHINSHITU_STS _
                '                        , Nothing _
                '                        , Nothing _
                '                        , Nothing _
                '                        , strDenbunDtl(XDSPBC_DATA) _
                '                        , Nothing _
                '                        , Now _
                '                        , Nothing _
                '                        )
                'strFPALLET_ID = objTRST_STOCK.FPALLET_ID                                            'ﾊﾟﾚｯﾄID更新


                ''************************
                ''在庫引当情報の登録
                ''************************
                'Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '在庫引当情報ｸﾗｽ
                'objTSTS_HIKIATE.FSAGYOU_KIND = intFSAGYOU_KIND                      '作業種別
                'objTSTS_HIKIATE.FPLAN_KEY = FPLAN_KEY_SKOTEI                        '計画ｷｰ
                'objTSTS_HIKIATE.FPALLET_ID = objTRST_STOCK.FPALLET_ID               'ﾊﾟﾚｯﾄID
                'objTSTS_HIKIATE.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK         '在庫ﾛｯﾄ№
                'objTSTS_HIKIATE.FTR_VOL = objTRST_STOCK.FTR_VOL                     '搬送管理量
                'objTSTS_HIKIATE.FTERM_ID = DEFAULT_STRING                           '端末ID
                'objTSTS_HIKIATE.FUSER_ID = DEFAULT_STRING                           'ﾕｰｻﾞｰID
                'objTSTS_HIKIATE.FWAIT_REASON = DEFAULT_STRING                       '指示送信待ち理由
                'objTSTS_HIKIATE.FTRNS_START_DT = DEFAULT_DATE                       '搬送開始日時
                'objTSTS_HIKIATE.FTRNS_END_DT = DEFAULT_DATE                         '搬送完了日時
                'objTSTS_HIKIATE.FUPDATE_DT = Now                                    '更新日時
                'objTSTS_HIKIATE.ADD_TSTS_HIKIATE()                                  '登録


                ''************************
                ''在庫登録
                ''************************
                'Dim objSYS_100101 As New SVR_100101(Owner, ObjDb, ObjDbLog)         '在庫作成ｸﾗｽ
                'objSYS_100101.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_FM                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                'objSYS_100101.FPALLET_ID = objTRST_STOCK.FPALLET_ID                 'ﾊﾟﾚｯﾄID
                'objSYS_100101.FINOUT_STS = FINOUT_STS_SIN_UKETUKE                   'INOUT(入庫設定)
                'objSYS_100101.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND           '作業種別(ｼｽﾃﾑ保守)
                'objSYS_100101.STOCK_ADD()                                           '登録
                '↑↑↑↑↑↑************************************************************************************************************

            Else
                '(在庫情報がある場合)


                '************************
                'STﾄﾗｯｷﾝｸﾞの特定
                '************************
                objTPRG_TRK_BUF_FM.FPALLET_ID = strFPALLET_ID       'ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF()               '特定


            End If


            '************************
            '搬送先ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀｸﾗｽ
            objTMST_TRK.FTRK_BUF_NO = intFTRK_BUF_NO_TO                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            objTMST_TRK.GET_TMST_TRK()                                      '特定


            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの更新(FM)
            '************************
            objTPRG_TRK_BUF_FM.FRSV_PALLET = objTPRG_TRK_BUF_FM.FPALLET_ID              '仮引当ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_FM.FTR_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO                  '搬送FMﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_FM.FTR_TO = intFTRK_BUF_NO_TO                               '搬送TOﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_FM.FTR_IDOU = DEFAULT_INTEGER                               '搬送TO移動ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_FM.FTRNS_FM = DEFAULT_STRING                                '搬送指令用FM
            objTPRG_TRK_BUF_FM.FTRNS_TO = DEFAULT_STRING                                '搬送指令用TO
            objTPRG_TRK_BUF_FM.FRSV_BUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO             'FM引当ﾄﾗｯｷﾝｸﾞ№
            objTPRG_TRK_BUF_FM.FRSV_ARRAY_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY        'FM引当配列№
            objTPRG_TRK_BUF_FM.FRSV_BUF_TO = DEFAULT_INTEGER                            'TO引当ﾄﾗｯｷﾝｸﾞ№
            objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO = DEFAULT_INTEGER                          'TO引当配列№
            objTPRG_TRK_BUF_FM.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_FM.FDISP_ADDRESS      'FM表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF_FM.FDISP_ADDRESS_TO = objTMST_TRK.FBUF_NAME                 'TO表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF_FM.FBUF_IN_DT = Now                                         'ﾊﾞｯﾌｧ入日時
            objTPRG_TRK_BUF_FM.UPDATE_TPRG_TRK_BUF()                                    '更新


            '************************
            '作業種別毎制御情報の特定
            '************************
            Dim objTMST_SAGYO As New TBL_TMST_SAGYO(Owner, ObjDb, ObjDbLog)
            objTMST_SAGYO.FSAGYOU_KIND = intFSAGYOU_KIND        '作業種別
            objTMST_SAGYO.FEQ_ID = FEQ_ID_SKOTEI                '設備ID
            objTMST_SAGYO.GET_TMST_SAGYO()                      '取得


            '************************
            '出庫指示QUEの登録
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '搬送指示QUEｸﾗｽ
            objTPLN_CARRY_QUE.FCARRYQUE_D = Now                                     '搬送指示日
            objTPLN_CARRY_QUE.FEQ_ID = FEQ_ID_SKOTEI                                '設備ID
            objTPLN_CARRY_QUE.FPRIORITY = objTMST_SAGYO.FPRIORITY                   '優先ﾚﾍﾞﾙ
            objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_FM.FPALLET_ID            'ﾊﾟﾚｯﾄID
            objTPLN_CARRY_QUE.FCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SMOVE               '指示区分
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON            '搬送指示状況
            objTPLN_CARRY_QUE.FENTRY_DT = Now                                       '登録日時
            objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '更新日時
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/03/27 親子設定
            objTPLN_CARRY_QUE.XOYAKO_KUBUN = strXOYAKO_KUBUN                        '親子区分
            objTPLN_CARRY_QUE.XPALLET_ID_AITE = strXPALLET_ID_AITE                  '相手ﾊﾟﾚｯﾄID
            '↑↑↑↑↑↑************************************************************************************************************
            objTPLN_CARRY_QUE.ADD_TPLN_CARRY_QUE_ORDER()                            '登録


            ''↓↓↓↓↓↓************************************************************************************************************
            ''SystemMate:N.Dounoshita 2012/10/18  ここの時点で、空棚を引き当てる場合はこの処理が必要


            'If Not ( _
            '          objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J384 _
            '       Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J387 _
            '       Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J389 _
            '       Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J394 _
            '       Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J399 _
            '       ) _
            '       Then
            '    '(生産入庫以外の場合)


            '    '************************
            '    '倉庫ﾊﾞｯﾌｧの特定
            '    '************************
            '    Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            '    If IsNull(strFTRK_BUF_NO_ASRS) And IsNull(strFTRK_BUF_ARRAY_ASRS) Then
            '        '(まだ棚が確定していない場合)


            '        '**********************************************
            '        '空棚引当処理
            '        '**********************************************
            '        Dim objSYS_100201 As New SVR_100201(Owner, ObjDb, ObjDbLog) '空棚引当ｸﾗｽ
            '        intRet = AkitanaHikiate(objSYS_100201 _
            '                              , objTPRG_TRK_BUF_ASRS _
            '                              , objTPRG_TRK_BUF_FM _
            '                              , strFPALLET_ID _
            '                              , strDenbunDtl(DSPHINMEI_CD) _
            '                              , FTRK_BUF_NO_J9000 _
            '                              , True _
            '                              )
            '        If intRet = RetCode.NotFound Then
            '            '(見つからない場合)

            '            Call AddToMsgLog(Now, FMSG_ID_S0102, objTMST_TRK.FBUF_NAME, "品名ｺｰﾄﾞ:" & strDenbunDtl(DSPHINMEI_CD))
            '            strMsg = ERRMSG_NOTFOUND_AKI
            '            Throw New UserException(strMsg, False)
            '            'Return RetCode.RollBack

            '        End If


            '    Else
            '        '(既に棚が確定している場合)


            '        '************************
            '        '倉庫ﾊﾞｯﾌｧの特定
            '        '************************
            '        objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = strFTRK_BUF_NO_ASRS              'ﾊﾞｯﾌｧ№
            '        objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = strFTRK_BUF_ARRAY_ASRS        '配列№
            '        objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()                             '特定


            '        '************************
            '        '作業種別の変更
            '        '************************
            '        intFSAGYOU_KIND = FSAGYOU_KIND_SIN_PICK


            '    End If


            '    '************************
            '    '倉庫の更新
            '    '************************
            '    objTPRG_TRK_BUF_ASRS.FRSV_PALLET = objTPRG_TRK_BUF_FM.FPALLET_ID        '仮引当PC名
            '    objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                 '引当状態
            '    objTPRG_TRK_BUF_ASRS.FBUF_IN_DT = Now                                   'ﾊﾞｯﾌｧ入日時
            '    objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                              '更新


            'End If


            ''↑↑↑↑↑↑************************************************************************************************************


            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動


            Return RetCode.OK
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  入庫指示用の搬送指示QUEを追加                                                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入庫指示用の搬送指示QUEを追加
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_ST">STﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="intFSAGYOU_KIND">作業種別</param>
    ''' <param name="strXOYAKO_KUBUN">親子区分</param>
    ''' <param name="strXPALLET_ID_AITE">相手ﾊﾟﾚｯﾄID</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Add_In_TPLN_CARRY_QUE_Process(ByRef objTPRG_TRK_BUF_ST As TBL_TPRG_TRK_BUF _
                                           , ByVal intFSAGYOU_KIND As Integer _
                                           , Optional ByVal strXOYAKO_KUBUN As String = Nothing _
                                           , Optional ByVal strXPALLET_ID_AITE As String = Nothing _
                                           )
        Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '************************
            '倉庫ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_ST.FRSV_BUF_TO           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_TRK & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO) & "  ,ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY) & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            'ｸﾚｰﾝﾏｽﾀの特定
            '************************
            Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)     'ｸﾚｰﾝﾏｽﾀｸﾗｽ
            objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO        'ﾊﾞｯﾌｧ№
            objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU         '列
            intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                           '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '作業種別毎制御情報の特定
            '************************
            Dim intFPRIORITY As Integer = FPRIORITY_SLOW
            Dim objTMST_SAGYO As New TBL_TMST_SAGYO(Owner, ObjDb, ObjDbLog)
            objTMST_SAGYO.FSAGYOU_KIND = intFSAGYOU_KIND        '作業種別
            objTMST_SAGYO.FEQ_ID = FEQ_ID_SKOTEI                '設備ID
            intRet = objTMST_SAGYO.GET_TMST_SAGYO(False)        '特定
            If intRet = RetCode.OK Then
                intFPRIORITY = objTMST_SAGYO.FPRIORITY
            End If


            '************************
            '搬送指示QUEの登録
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '搬送指示QUEｸﾗｽ
            objTPLN_CARRY_QUE.FCARRYQUE_D = Now                                     '搬送指示日
            objTPLN_CARRY_QUE.FEQ_ID = objTMST_CRANE.FEQ_ID                         '設備ID
            objTPLN_CARRY_QUE.FPRIORITY = intFPRIORITY                              'ﾌﾟﾗｲｵﾘﾃｨ区分
            objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID            'ﾊﾟﾚｯﾄID
            objTPLN_CARRY_QUE.FCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SIN                 '搬送区分
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON            '搬送指示状況
            objTPLN_CARRY_QUE.FENTRY_DT = Now                                       '登録日時
            objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '更新日時
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/03/27 親子設定
            objTPLN_CARRY_QUE.XOYAKO_KUBUN = strXOYAKO_KUBUN                        '親子区分
            objTPLN_CARRY_QUE.XPALLET_ID_AITE = strXPALLET_ID_AITE                  '相手ﾊﾟﾚｯﾄID
            '↑↑↑↑↑↑************************************************************************************************************
            objTPLN_CARRY_QUE.ADD_TPLN_CARRY_QUE_ORDER()                            '登録


            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動


        Catch ex As ContinueForException
            Throw New ContinueForException()
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

    '空棚引当
#Region "  空棚引当処理(品目毎にｸﾚｰﾝ順番を記憶)                                                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' 空棚引当処理(品目毎にｸﾚｰﾝ順番を記憶)
    ''' </summary>
    ''' <param name="objSYS_100201">空棚引当ｸﾗｽ</param>
    ''' <param name="objTPRG_TRK_BUF_ASRS_OYA">倉庫ﾄﾗｯｷﾝｸﾞ(親)</param>
    ''' <param name="objTPRG_TRK_BUF_ASRS_KOO">倉庫ﾄﾗｯｷﾝｸﾞ(子)</param>
    ''' <param name="objTPRG_TRK_BUF_FM">入庫する元STﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="strFPALLET_ID">入庫する在庫情報のﾊﾟﾚｯﾄID</param>
    ''' <param name="strFHINMEI_CD">入庫する在庫情報の品名ｺｰﾄﾞ</param>
    ''' <param name="intFTRK_BUF_NO_ASRS">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(自動倉庫)</param>
    ''' <param name="blnUpdate">ｸﾚｰﾝ優先順更新ﾌﾗｸﾞ</param>
    ''' <param name="blnPair">ﾍﾟｱ搬送ﾌﾗｸﾞ</param>
    ''' <param name="intXTANA_BLOCK">棚ﾌﾞﾛｯｸ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function AkitanaHikiate(ByRef objSYS_100201 As SVR_100201 _
                                 , ByRef objTPRG_TRK_BUF_ASRS_OYA As TBL_TPRG_TRK_BUF _
                                 , ByRef objTPRG_TRK_BUF_ASRS_KOO As TBL_TPRG_TRK_BUF _
                                 , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                                 , ByVal strFPALLET_ID As String _
                                 , ByVal strFHINMEI_CD As String _
                                 , ByVal intFTRK_BUF_NO_ASRS As Integer _
                                 , ByVal blnUpdate As Boolean _
                                 , ByVal blnPair As Boolean _
                                 , ByVal intXTANA_BLOCK As Nullable(Of Integer) _
                                 , ByVal blnHasuBlock As Boolean _
                                 ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        Dim strMsg As String
        Dim intRet As RetCode


        '************************************************
        '搬送元STのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ      取得
        '************************************************
        Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO
        objTMST_TRK.GET_TMST_TRK()


        '************************************************
        '品目ﾏｽﾀ      取得
        '************************************************
        Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
        objTMST_ITEM.FHINMEI_CD = strFHINMEI_CD
        objTMST_ITEM.GET_TMST_ITEM()
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/04/10 棚形状種別の設定
        Dim intFRAC_FORM As Nullable(Of Integer) = Nothing
        If objTMST_ITEM.FRAC_FORM = FRAC_FORM_JHIGH_TANA Then intFRAC_FORM = objTMST_ITEM.FRAC_FORM
        '↑↑↑↑↑↑************************************************************************************************************


        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2012/07/07 ｸﾚｰﾝ引当処理追加


        '************************************************
        '在庫情報           取得
        '************************************************
        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
        objTRST_STOCK.FPALLET_ID = strFPALLET_ID
        objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)


        '************************************************
        'ﾄﾗｯｷﾝｸﾞ状況        取得
        '************************************************
        Dim objXSTS_TRK As New TBL_XSTS_TRK(Owner, ObjDb, ObjDbLog)
        objXSTS_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO    '品目ｺｰﾄﾞ
        objXSTS_TRK.GET_XSTS_TRK(True)                              '取得


        '↑↑↑↑↑↑************************************************************************************************************


        '************************************************
        '引当ﾀｲﾌﾟ特定ﾏｽﾀ        取得
        '************************************************
        Dim objTMST_SP_RES_TYPE As New TBL_TMST_SP_RES_TYPE(Owner, ObjDb, ObjDbLog)
        objTMST_SP_RES_TYPE.FCONDITION01 = objTMST_ITEM.XIN_RES_TYPE
        objTMST_SP_RES_TYPE.GET_TMST_SP_RES_TYPE()


        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2012/07/07 ｸﾚｰﾝ引当処理追加

        '************************
        'ｸﾚｰﾝの特定
        '************************

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/11/08 空棚引当変更

        '' ''Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)         'ｼｽﾃﾑ変数ｸﾗｽ
        '' ''objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS000000_002                         '変数ID
        '' ''intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                             '取得
        ' '' ''品目ﾏｽﾀの最終引当ｸﾚｰﾝIDで更新
        '' ''objTPRG_SYS_HEN.OBJCHANGE_DATA = objXSTS_TRK.XHIKIATE_CRANE_ID              '変更ﾃﾞｰﾀ
        '' ''objTPRG_SYS_HEN.UPDATE_TPRG_SYS_HEN_OBJ()                                   '更新

        Dim strFHENSU_ID As String

        Select Case TO_INTEGER(objTPRG_TRK_BUF_FM.FTRK_BUF_NO)
            Case 1000 To 1999
                strFHENSU_ID = FHENSU_ID_SSJ000000_051      '1F
            Case 2000 To 2999
                strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
            Case 4000 To 4999
                strFHENSU_ID = FHENSU_ID_SSJ000000_051      '1F
            Case 5000 To 5999
                strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
            Case Else
                strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
        End Select
        Dim objTPRG_SYS_HEN_WK As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)      'ｼｽﾃﾑ変数ｸﾗｽ
        objTPRG_SYS_HEN_WK.FHENSU_ID = strFHENSU_ID                                 '変数ID
        intRet = objTPRG_SYS_HEN_WK.GET_TPRG_SYS_HEN(True)                          '取得

        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)         'ｼｽﾃﾑ変数ｸﾗｽ
        objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS000000_002                         '変数ID
        intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                             '取得
        '品目ﾏｽﾀの最終引当ｸﾚｰﾝIDで更新
        objTPRG_SYS_HEN.OBJCHANGE_DATA = objTPRG_SYS_HEN_WK.FHENSU_CHAR             '変更ﾃﾞｰﾀ
        objTPRG_SYS_HEN.UPDATE_TPRG_SYS_HEN_OBJ()                                   '更新

        'JobMate:S.Ouchi 2013/11/08 空棚引当変更
        '↑↑↑↑↑↑************************************************************************************************************

        '************************
        'ｸﾚｰﾝ優先順の作成
        '************************
        Dim strFEQ_ID_CRANE() As String
        objTPRG_SYS_HEN.FHENSU_CHAR = Nothing
        intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                             '取得
        strFEQ_ID_CRANE = Split(objTPRG_SYS_HEN.FHENSU_CHAR, KUGIRI01)

        '↑↑↑↑↑↑************************************************************************************************************


        '************************
        '倉庫ﾊﾞｯﾌｧの特定
        '************************
        objSYS_100201.FTRK_BUF_NO = intFTRK_BUF_NO_ASRS                 'ﾊﾞｯﾌｧ№(倉庫)
        'objSYS_100201.FRAC_FORM = objTMST_ITEM.FRAC_FORM               '棚形状種別
        objSYS_100201.FRES_TYPE = objTMST_SP_RES_TYPE.FRES_TYPE         '引当ﾀｲﾌﾟ
        objSYS_100201.FPALLET_ID = strFPALLET_ID                        'ﾊﾟﾚｯﾄID
        objSYS_100201.FEQ_ID_CRANE = strFEQ_ID_CRANE                    '元ｸﾚｰﾝ設備ID
        objSYS_100201.blnUpdate = blnUpdate                             '更新ﾌﾗｸﾞ
        objSYS_100201.FBUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO          '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objSYS_100201.FRAC_FORM = intFRAC_FORM                          '棚形状種別
        objSYS_100201.blnPair = blnPair                                 'ﾍﾟｱ搬送ﾌﾗｸﾞ
        objSYS_100201.XTANA_BLOCK = intXTANA_BLOCK                      '棚ﾌﾞﾛｯｸ
        intRet = objSYS_100201.FIND_PAIR_TANA_AKI                       '特定
        'intRet = objSYS_100201.FIND_TANA_AKI                            '特定
        If intRet = RetCode.NotFound Then
            '(見つからない場合)
            Return intRet
        End If
        '親
        objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO = objSYS_100201.FTRK_BUF_NO                'ﾊﾞｯﾌｧ№
        objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_ARRAY = objSYS_100201.FTRK_BUF_ARRAY          '配列№
        objTPRG_TRK_BUF_ASRS_OYA.GET_TPRG_TRK_BUF()                                     '特定
        '子
        If blnPair = True Then
            objTPRG_TRK_BUF_ASRS_KOO.FTRK_BUF_NO = objSYS_100201.FTRK_BUF_NO                'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS_KOO.FTRK_BUF_ARRAY = objSYS_100201.FTRK_BUF_ARRAY_Pair     '配列№
            objTPRG_TRK_BUF_ASRS_KOO.GET_TPRG_TRK_BUF()                                     '特定
        End If
        'ﾛｸﾞ出力
        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                         "[空棚引当(親):" & TO_STRING(objTPRG_TRK_BUF_ASRS_OYA.FDISP_ADDRESS) & "]" _
                       & "[空棚引当(子):" & TO_STRING(objTPRG_TRK_BUF_ASRS_KOO.FDISP_ADDRESS) & "]" _
                         )
        If blnUpdate = False Then Return intRet


        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/11/21 空棚引当変更
        ' '' ''************************************************************************************************
        ' '' ''************************************************************************************************
        ' '' ''棚ﾌﾞﾛｯｸ状態            更新
        ' '' ''ｸﾚｰﾝ優先順             更新
        ' '' ''************************************************************************************************
        ' '' ''************************************************************************************************
        '' ''If blnHasuBlock = False Then
        '' ''    '(端数在庫が存在しない 場合)


        '' ''    '************************************************
        '' ''    '棚ﾌﾞﾛｯｸ状態の更新
        '' ''    '************************************************
        '' ''    Call UpdateTPRG_TRK_BUF_Relation_XTANA_BLOCK_STS(objTPRG_TRK_BUF_ASRS_OYA, XTANA_BLOCK_STS_IN)


        '' ''Else
        '' ''    '(端数在庫が存在する 場合)

        '' ''    If TO_INTEGER(objTPRG_TRK_BUF_ASRS_OYA.FRAC_EDA) = FLAG_ON Then
        '' ''        '(奥棚の場合)


        '' ''        '************************************************
        '' ''        'ｸﾚｰﾝ優先順の更新
        '' ''        '************************************************
        '' ''        '====================================
        '' ''        'ｸﾚｰﾝﾏｽﾀの特定
        '' ''        '====================================
        '' ''        Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)             'ｸﾚｰﾝﾏｽﾀｸﾗｽ
        '' ''        objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO            'ﾊﾞｯﾌｧ№
        '' ''        objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS_OYA.FRAC_RETU             '列
        '' ''        intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                                   '特定
        '' ''        If intRet = RetCode.NotFound Then
        '' ''            '(見つからない場合)
        '' ''            strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
        '' ''            Throw New UserException(strMsg)
        '' ''        End If

        '' ''        '====================================
        '' ''        'ｸﾚｰﾝ優先順の更新
        '' ''        '====================================
        '' ''        Dim objSVR_100205 As New SVR_100205(Owner, ObjDb, ObjDbLog)         'ｸﾚｰﾝ優先順更新ｸﾗｽ
        '' ''        objSVR_100205.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
        '' ''        objSVR_100205.FEQ_ID = objTMST_CRANE.FEQ_ID                         '使用設備ID
        '' ''        objSVR_100205.CRANE_ORDER_UPDATE()                                  '更新


        '' ''    End If

        '' ''End If


        '************************************************************************************************
        '************************************************************************************************
        '棚ﾌﾞﾛｯｸ状態            更新
        'ｸﾚｰﾝ優先順             更新
        '************************************************************************************************
        '************************************************************************************************
        If blnHasuBlock = False Then
            '(端数在庫が存在しない 場合)


            '************************************************
            '棚ﾌﾞﾛｯｸ状態の更新
            '************************************************
            Call UpdateTPRG_TRK_BUF_Relation_XTANA_BLOCK_STS(objTPRG_TRK_BUF_ASRS_OYA, XTANA_BLOCK_STS_IN)


        End If


        'ｸﾚｰﾝ優先順の更新
        If TO_INTEGER(objTPRG_TRK_BUF_ASRS_OYA.FRAC_EDA) = FLAG_ON Then
            '(奥棚の場合)


            '************************************************
            'ｸﾚｰﾝ優先順の更新
            '************************************************
            '====================================
            'ｸﾚｰﾝﾏｽﾀの特定
            '====================================
            Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)             'ｸﾚｰﾝﾏｽﾀｸﾗｽ
            objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO            'ﾊﾞｯﾌｧ№
            objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS_OYA.FRAC_RETU             '列
            intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                                   '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                Throw New UserException(strMsg)
            End If

            '====================================
            'ｸﾚｰﾝ優先順の更新
            '====================================
            Dim objSVR_100205 As New SVR_100205(Owner, ObjDb, ObjDbLog)         'ｸﾚｰﾝ優先順更新ｸﾗｽ
            objSVR_100205.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            objSVR_100205.FEQ_ID = objTMST_CRANE.FEQ_ID                         '使用設備ID
            objSVR_100205.CRANE_ORDER_UPDATE()                                  '更新


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/12/02 空棚引当変更
            Dim objTPRG_SYS_HEN_BEFORE2 As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog) 'ｼｽﾃﾑ変数ｸﾗｽ
            objTPRG_SYS_HEN_BEFORE2.FHENSU_ID = FHENSU_ID_SSS000000_002                 '変数ID
            intRet = objTPRG_SYS_HEN_BEFORE2.GET_TPRG_SYS_HEN(True)                     '取得

            Dim objTPRG_SYS_HEN_AFTER2 As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)  'ｼｽﾃﾑ変数ｸﾗｽ
            objTPRG_SYS_HEN_AFTER2.FHENSU_ID = strFHENSU_ID                             '変数ID
            intRet = objTPRG_SYS_HEN_AFTER2.GET_TPRG_SYS_HEN(True)                      '取得
            objTPRG_SYS_HEN_AFTER2.OBJCHANGE_DATA = objTPRG_SYS_HEN_BEFORE2.FHENSU_CHAR '変更ﾃﾞｰﾀ
            objTPRG_SYS_HEN_AFTER2.UPDATE_TPRG_SYS_HEN_OBJ()                            '更新
            'JobMate:S.Ouchi 2013/12/02 空棚引当変更
            '↑↑↑↑↑↑************************************************************************************************************
        End If
        'JobMate:S.Ouchi 2013/11/21 空棚引当変更
        '↑↑↑↑↑↑************************************************************************************************************



        '************************
        'ｸﾚｰﾝの特定
        '************************
        Dim objTPRG_SYS_HEN_BEFORE As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)         'ｼｽﾃﾑ変数ｸﾗｽ
        objTPRG_SYS_HEN_BEFORE.FHENSU_ID = FHENSU_ID_SSS000000_002                         '変数ID
        intRet = objTPRG_SYS_HEN_BEFORE.GET_TPRG_SYS_HEN(True)                             '取得

        '************************
        '品名ﾏｽﾀ更新
        '************************
        objXSTS_TRK.XHIKIATE_CRANE_ID = objTPRG_SYS_HEN_BEFORE.FHENSU_CHAR
        objXSTS_TRK.UPDATE_XSTS_TRK()

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/12/02 空棚引当変更
        ' '' ''↓↓↓↓↓↓************************************************************************************************************
        ' '' ''JobMate:S.Ouchi 2013/11/08 空棚引当変更
        '' ''Dim objTPRG_SYS_HEN_AFTER As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)   'ｼｽﾃﾑ変数ｸﾗｽ
        '' ''objTPRG_SYS_HEN_AFTER.FHENSU_ID = strFHENSU_ID                              '変数ID
        '' ''intRet = objTPRG_SYS_HEN_AFTER.GET_TPRG_SYS_HEN(True)                       '取得
        '' ''objTPRG_SYS_HEN_AFTER.OBJCHANGE_DATA = objTPRG_SYS_HEN_BEFORE.FHENSU_CHAR   '変更ﾃﾞｰﾀ
        '' ''objTPRG_SYS_HEN_AFTER.UPDATE_TPRG_SYS_HEN_OBJ()                             '更新
        ' '' ''JobMate:S.Ouchi 2013/11/08 空棚引当変更
        ' '' ''↑↑↑↑↑↑************************************************************************************************************
        'JobMate:S.Ouchi 2013/12/02 空棚引当変更
        '↑↑↑↑↑↑************************************************************************************************************

        Return intReturn
    End Function
#End Region


    '出荷引当
#Region "  出荷引当処理(ﾙｰﾄ)                                                                        "
    '''**********************************************************************************************
    ''' <summary>
    ''' 出荷引当処理(ﾙｰﾄ)
    ''' </summary>
    ''' <param name="dtmXSYUKKA_D">出荷日</param>
    ''' <param name="strXHENSEI_NO_OYA">親編成No.</param>
    ''' <param name="intSyukkaHikiateMode">出荷引当時の区分</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SyukkaHikiateRoot(ByVal dtmXSYUKKA_D As Date _
                                    , ByVal strXHENSEI_NO_OYA As String _
                                    , ByVal intSyukkaHikiateMode As SyukkaHikiateMode _
                                    ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        Dim intRet As RetCode


        '****************************************
        '初期設定
        '****************************************
        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)
        Dim intOutSiziSameNum As Integer = objTPRG_SYS_HEN.SJ000000_001     '同時出庫指示数
        Dim intPointOutSiziSameNum As Integer = 1                           '同時出庫指示数ﾎﾟｲﾝﾀ
        Dim objOkuPalletIDList As New ArrayList                             '手前棚に在庫がある為、出庫不可のﾊﾟﾚｯﾄIDﾘｽﾄ
        Dim blnHikiate As Boolean = False                                   '引当ﾌﾗｸﾞ


        '************************************************************************************************
        '************************************************************************************************
        '出庫CV、同時出庫指示数             取得
        '************************************************************************************************
        '************************************************************************************************
        Dim intAryOutCV() As Integer = Nothing                              '出庫CV
        Dim intPointOutCV As Integer = 0                                    '出庫CVﾎﾟｲﾝﾀ

        '=======================================
        '出荷指示           取得
        '=======================================
        Dim objXPLN_OUT_Berth As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
        objXPLN_OUT_Berth.XSYUKKA_D = dtmXSYUKKA_D            '出荷日
        objXPLN_OUT_Berth.XHENSEI_NO = strXHENSEI_NO_OYA      '編成No.
        objXPLN_OUT_Berth.GET_XPLN_OUT_ANY()                  '取得

        '=======================================
        '出荷ﾊﾞｰｽ状況           取得
        '=======================================
        Dim objXSTS_BERTH As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)
        objXSTS_BERTH.XBERTH_NO = objXPLN_OUT_Berth.ARYME(0).XBERTH_NO    'ﾊﾞｰｽ№
        objXSTS_BERTH.GET_XSTS_BERTH()                              '取得

        '=======================================
        '出庫CV配列                   取得
        '=======================================
        Call GetintAryOutCV(intAryOutCV, objXSTS_BERTH.XBERTH_GROUP)
        ''=======================================
        ''出荷ﾊﾞｰｽ状況           取得
        ''=======================================
        'Dim objAryXSTS_CONVEYOR As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)
        'objAryXSTS_CONVEYOR.XBERTH_GROUP = objXSTS_BERTH.XBERTH_GROUP      'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
        'objAryXSTS_CONVEYOR.ORDER_BY = " XSTNO "                           '並び
        'intRet = objAryXSTS_CONVEYOR.GET_XSTS_CONVEYOR_ANY()               '取得
        'If intRet = RetCode.OK Then
        '    '(見つかった場合)
        '    ReDim intAryOutCV(UBound(objAryXSTS_CONVEYOR.ARYME))
        '    For ii As Integer = 0 To UBound(objAryXSTS_CONVEYOR.ARYME)
        '        '(ﾙｰﾌﾟ:出庫CV数)
        '        intAryOutCV(ii) = objAryXSTS_CONVEYOR.ARYME(ii).XSTNO
        '    Next
        'Else
        '    '(見つからなかった場合)
        '    Throw New Exception(ERRMSG_NOTFOUND_XSTS_CONVEYOR & "[ﾊﾞｰｽｸﾞﾙｰﾌﾟ:" & TO_STRING(objAryXSTS_CONVEYOR.XBERTH_GROUP) & "]")
        'End If


        '************************************************************************************************
        '************************************************************************************************
        '出荷計画           取得
        '************************************************************************************************
        '************************************************************************************************
        '****************************************
        '出荷指示詳細               取得
        '****************************************
        Dim objAryXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
        objAryXPLN_OUT_DTL.XSYUKKA_D = dtmXSYUKKA_D                 '出荷日
        objAryXPLN_OUT_DTL.XHENSEI_NO_OYA = strXHENSEI_NO_OYA       '親編成No.
        objAryXPLN_OUT_DTL.WHERE = " AND XSYUKKA_KON_RESERVE < XSYUKKA_KON_PLAN "      '追加条件
        'objAryXPLN_OUT_DTL.WHERE = " AND XSYUKKA_STS_DTL IN (" & XSYUKKA_STS_DTL_JNON & ", " & XSYUKKA_STS_DTL_JLESS & ")"      '追加条件
        objAryXPLN_OUT_DTL.ORDER_BY = " XOUT_ORDER, FHINMEI_CD, XHENSEI_NO"     '並び
        intRet = objAryXPLN_OUT_DTL.GET_XPLN_OUT_DTL_ANY()          '取得
        If intRet <> RetCode.OK Then
            '(見つからなかった場合)
            If intSyukkaHikiateMode <> SyukkaHikiateMode.Loader02 Then
                '(ﾄﾗｯｸﾛｰﾀﾞ2回目の場合は、全て出荷引当されていると、ﾚｺｰﾄﾞが見つからない場合がある為)
                Throw New Exception("引当可能な" & ERRMSG_NOTFOUND_XPLN_OUT_DTL & "[出荷日:" & Format(objAryXPLN_OUT_DTL.XSYUKKA_D, DATE_FORMAT_03) & "][親編成№" & objAryXPLN_OUT_DTL.XHENSEI_NO_OYA & "]")
            End If
        Else
            '(見つかった場合)


            For Each objXPLN_OUT_DTL As TBL_XPLN_OUT_DTL In objAryXPLN_OUT_DTL.ARYME
                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


                '********************************************************************************
                'ﾁｪｯｸ処理
                '********************************************************************************
                If intSyukkaHikiateMode = SyukkaHikiateMode.Loader01 Or intSyukkaHikiateMode = SyukkaHikiateMode.Loader02 Then
                    If objXPLN_OUT_DTL.FSAGYOU_KIND <> FSAGYOU_KIND_J57 Then Throw New Exception("引数が間違っています。[出荷日:" & Format(dtmXSYUKKA_D, DATE_FORMAT_03) & "][親編成№" & strXHENSEI_NO_OYA & "][出荷引当時の区分:" & TO_STRING(intSyukkaHikiateMode) & "]")
                End If


                '********************************************************************************
                'ﾛｯﾄ№配列                  取得
                '********************************************************************************
                Dim strAryFLOT_NO_FIN_KUBUN_J04() As String = Nothing        'ﾛｯﾄ№配列(持戻り品)
                Dim strAryFLOT_NO_FIN_KUBUN_J06() As String = Nothing        'ﾛｯﾄ№配列(再入庫品)
                Dim strAryFLOT_NO_FIN_KUBUN_J02() As String = Nothing        'ﾛｯﾄ№配列(入荷品(外部生産品))
                Dim strAryFLOT_NO_All() As String = Nothing                 'ﾛｯﾄ№配列(全て)
                intRet = SyukkaHikiateGetAryFLOT_NO(strAryFLOT_NO_FIN_KUBUN_J04, objXPLN_OUT_DTL.FHINMEI_CD, FIN_KUBUN_J04)
                intRet = SyukkaHikiateGetAryFLOT_NO(strAryFLOT_NO_FIN_KUBUN_J06, objXPLN_OUT_DTL.FHINMEI_CD, FIN_KUBUN_J06)
                intRet = SyukkaHikiateGetAryFLOT_NO(strAryFLOT_NO_FIN_KUBUN_J02, objXPLN_OUT_DTL.FHINMEI_CD, FIN_KUBUN_J02)
                intRet = SyukkaHikiateGetAryFLOT_NO(strAryFLOT_NO_All, objXPLN_OUT_DTL.FHINMEI_CD, Nothing)
                If intRet <> RetCode.OK Then
                    '(見つからなかった場合)

                    '====================================
                    '出荷状況詳細       更新
                    '====================================
                    objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JLESS     '出荷状況詳細
                    objXPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()                       '更新

                    '====================================
                    'ﾒｯｾｰｼﾞ履歴         追加
                    '====================================
                    Call AddToMsgLog(Now, FMSG_ID_S0101, "[品目ｺｰﾄﾞ:" & objXPLN_OUT_DTL.FHINMEI_CD & "]" _
                                                       & "[出荷日:" & objXPLN_OUT_DTL.XSYUKKA_D & "]" _
                                                       & "[編成№:" & objXPLN_OUT_DTL.XHENSEI_NO & "]" _
                                                       & "[伝票№:" & objXPLN_OUT_DTL.XDENPYOU_NO & "]" _
                                                       , "ﾛｯﾄ№配列取得時に判明")
                    Continue For
                End If


                '********************************************************************************
                '出荷指示           取得
                '********************************************************************************
                Dim objXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
                objXPLN_OUT.XSYUKKA_D = objXPLN_OUT_DTL.XSYUKKA_D           '出荷日
                objXPLN_OUT.XHENSEI_NO = objXPLN_OUT_DTL.XHENSEI_NO         '編成No.
                objXPLN_OUT.XDENPYOU_NO = objXPLN_OUT_DTL.XDENPYOU_NO       '伝票No.
                objXPLN_OUT.GET_XPLN_OUT()                                  '取得


                '********************************************************************************
                'その他必要な情報を取得
                '********************************************************************************
                '=======================================
                '品目ﾏｽﾀ                取得
                '=======================================
                Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                objTMST_ITEM.FHINMEI_CD = objXPLN_OUT_DTL.FHINMEI_CD            '品目ｺｰﾄﾞ
                objTMST_ITEM.GET_TMST_ITEM()                                    '取得


                '********************************************************************************
                '引当数量を取得
                '********************************************************************************
                Dim decHikiateNum As Decimal = TO_DECIMAL(objXPLN_OUT_DTL.XSYUKKA_KON_PLAN) - TO_DECIMAL(objXPLN_OUT_DTL.XSYUKKA_KON_RESERVE)   '出荷予定梱数
                If intSyukkaHikiateMode = SyukkaHikiateMode.Loader01 Then
                    '(ﾄﾗｯｸﾛｰﾀﾞ1回目の場合)
                    '(ﾍﾟｱ搬送可能な分だけ引当てて、残りは後でもう一回引当てる)
                    decHikiateNum = decHikiateNum - (decHikiateNum Mod (objTMST_ITEM.FNUM_IN_PALLET * 2))
                End If
                Dim decSaveHikiateNum As Decimal = decHikiateNum            '一時保存


                '********************************************************************************
                '引当&コンベヤ割付処理
                '(入庫区分：持ち戻り品)
                '********************************************************************************
                If IsNotNull(strAryFLOT_NO_FIN_KUBUN_J04) Then
                    If 0 < decHikiateNum Then
                        While True
                            '(ﾙｰﾌﾟ:出荷予定梱数を満たすまで、引当てる)

                            For Each strFLOT_NO As String In strAryFLOT_NO_FIN_KUBUN_J04
                                '(ﾙｰﾌﾟ:ﾛｯﾄ№数)

                                intRet = SyukkaHikiateCVWarituke(TO_STRING(FIN_KUBUN_J04) _
                                                               , decHikiateNum _
                                                               , strFLOT_NO _
                                                               , intAryOutCV _
                                                               , intPointOutCV _
                                                               , intPointOutSiziSameNum _
                                                               , intOutSiziSameNum _
                                                               , objXPLN_OUT _
                                                               , objXPLN_OUT_DTL _
                                                               , objTMST_ITEM _
                                                               , intSyukkaHikiateMode _
                                                               , objOkuPalletIDList _
                                                               )
                                '脱出
                                If intRet = RetCode.OK Then Exit For
                                If decHikiateNum <= 0 Then Exit For

                            Next

                            '脱出
                            If intRet <> RetCode.OK Then Exit While
                            If decHikiateNum <= 0 Then Exit While

                        End While
                    End If
                End If


                '********************************************************************************
                '引当&コンベヤ割付処理
                '(入庫区分：再入庫品)
                '********************************************************************************
                If IsNotNull(strAryFLOT_NO_FIN_KUBUN_J06) Then
                    If 0 < decHikiateNum Then
                        While True
                            '(ﾙｰﾌﾟ:出荷予定梱数を満たすまで、引当てる)

                            For Each strFLOT_NO As String In strAryFLOT_NO_FIN_KUBUN_J06
                                '(ﾙｰﾌﾟ:ﾛｯﾄ№数)

                                intRet = SyukkaHikiateCVWarituke(TO_STRING(FIN_KUBUN_J06) _
                                                               , decHikiateNum _
                                                               , strFLOT_NO _
                                                               , intAryOutCV _
                                                               , intPointOutCV _
                                                               , intPointOutSiziSameNum _
                                                               , intOutSiziSameNum _
                                                               , objXPLN_OUT _
                                                               , objXPLN_OUT_DTL _
                                                               , objTMST_ITEM _
                                                               , intSyukkaHikiateMode _
                                                               , objOkuPalletIDList _
                                                               )
                                '脱出
                                If intRet = RetCode.OK Then Exit For
                                If decHikiateNum <= 0 Then Exit For

                            Next

                            '脱出
                            If intRet <> RetCode.OK Then Exit While
                            If decHikiateNum <= 0 Then Exit While

                        End While
                    End If
                End If


                '********************************************************************************
                '引当&コンベヤ割付処理
                '(入庫区分：外部生産品)
                '********************************************************************************
                If IsNotNull(strAryFLOT_NO_FIN_KUBUN_J02) Then
                    If 0 < decHikiateNum Then
                        While True
                            '(ﾙｰﾌﾟ:出荷予定梱数を満たすまで、引当てる)

                            For Each strFLOT_NO As String In strAryFLOT_NO_FIN_KUBUN_J02
                                '(ﾙｰﾌﾟ:ﾛｯﾄ№数)

                                intRet = SyukkaHikiateCVWarituke(TO_STRING(FIN_KUBUN_J02) _
                                                               , decHikiateNum _
                                                               , strFLOT_NO _
                                                               , intAryOutCV _
                                                               , intPointOutCV _
                                                               , intPointOutSiziSameNum _
                                                               , intOutSiziSameNum _
                                                               , objXPLN_OUT _
                                                               , objXPLN_OUT_DTL _
                                                               , objTMST_ITEM _
                                                               , intSyukkaHikiateMode _
                                                               , objOkuPalletIDList _
                                                               )
                                '脱出
                                If intRet = RetCode.OK Then Exit For
                                If decHikiateNum <= 0 Then Exit For

                            Next

                            '脱出
                            If intRet <> RetCode.OK Then Exit While
                            If decHikiateNum <= 0 Then Exit While

                        End While
                    End If
                End If


                '********************************************************************************
                '引当&コンベヤ割付処理
                '(入庫区分：なし)
                '********************************************************************************
                If 0 < decHikiateNum Then
                    While True
                        '(ﾙｰﾌﾟ:出荷予定梱数を満たすまで、引当てる)

                        For Each strFLOT_NO As String In strAryFLOT_NO_All
                            '(ﾙｰﾌﾟ:ﾛｯﾄ№数)

                            intRet = SyukkaHikiateCVWarituke("" _
                                                           , decHikiateNum _
                                                           , strFLOT_NO _
                                                           , intAryOutCV _
                                                           , intPointOutCV _
                                                           , intPointOutSiziSameNum _
                                                           , intOutSiziSameNum _
                                                           , objXPLN_OUT _
                                                           , objXPLN_OUT_DTL _
                                                           , objTMST_ITEM _
                                                           , intSyukkaHikiateMode _
                                                           , objOkuPalletIDList _
                                                           )
                            '脱出
                            If intRet = RetCode.OK Then Exit For
                            If decHikiateNum <= 0 Then Exit For

                        Next

                        '脱出
                        If intRet <> RetCode.OK Then Exit While
                        If decHikiateNum <= 0 Then Exit While

                    End While
                End If


                '********************************************************************************
                '出荷引当結果           更新
                '********************************************************************************
                With objXPLN_OUT_DTL
                    .XSYUKKA_KON_RESERVE = .XSYUKKA_KON_RESERVE + (decSaveHikiateNum - decHikiateNum)
                End With
                If decHikiateNum < decSaveHikiateNum Then blnHikiate = True
                If objXPLN_OUT_DTL.XSYUKKA_KON_PLAN <= objXPLN_OUT_DTL.XSYUKKA_KON_RESERVE Then
                    'If decHikiateNum <= 0 Then
                    '(出荷指示正常完了の場合)

                    '====================================
                    '出荷状況詳細       更新
                    '====================================
                    '(その他)
                    If objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JNON Or objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JLESS Then
                        '(平置きで全て引き当てる場合があるので、その対応)
                        objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JSTART        '出荷状況詳細
                    End If
                    objXPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()                           '更新

                Else
                    '(欠品の場合)

                    If intSyukkaHikiateMode <> SyukkaHikiateMode.Loader01 Then
                        '(ﾄﾗｯｸﾛｰﾀﾞ1回目の場合は欠品としない)

                        '====================================
                        '出荷状況詳細       更新
                        '====================================
                        objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JLESS         '出荷状況詳細
                        objXPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()                           '更新

                        '====================================
                        'ﾒｯｾｰｼﾞ履歴         追加
                        '====================================
                        Call AddToMsgLog(Now, FMSG_ID_S0101, "[品目ｺｰﾄﾞ:" & objXPLN_OUT_DTL.FHINMEI_CD & "]" _
                                                           & "[出荷日:" & objXPLN_OUT_DTL.XSYUKKA_D & "]" _
                                                           & "[編成№:" & objXPLN_OUT_DTL.XHENSEI_NO & "]" _
                                                           & "[伝票№:" & objXPLN_OUT_DTL.XDENPYOU_NO & "]" _
                                                           , "数量欠品" _
                                                           )
                        intReturn = RetCode.NotFound
                        Continue For

                    Else
                        '(ﾄﾗｯｸﾛｰﾀﾞ1回目の場合)
                        objXPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()                           '更新
                    End If

                End If


            Next


        End If


        '****************************************
        '出荷指示詳細           取得
        '****************************************
        Dim blnLESS As Boolean = False          '欠品ﾌﾗｸﾞ
        Dim objAryXPLN_OUT_DTL_Check As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
        objAryXPLN_OUT_DTL_Check.XSYUKKA_D = dtmXSYUKKA_D                 '出荷日
        objAryXPLN_OUT_DTL_Check.XHENSEI_NO = strXHENSEI_NO_OYA           '親編成No.
        intRet = objAryXPLN_OUT_DTL_Check.GET_XPLN_OUT_DTL_ANY()          '取得
        If intRet = RetCode.OK Then
            '(見つかった場合)
            For Each objXPLN_OUT_DTL As TBL_XPLN_OUT_DTL In objAryXPLN_OUT_DTL_Check.ARYME
                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)
                If objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JLESS Then blnLESS = True : Exit For
            Next
        End If


        '****************************************
        '出荷指示           取得
        '****************************************
        Dim objAryXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
        objAryXPLN_OUT.XSYUKKA_D = dtmXSYUKKA_D             '出荷日
        objAryXPLN_OUT.XHENSEI_NO_OYA = strXHENSEI_NO_OYA   '親編成No.
        intRet = objAryXPLN_OUT.GET_XPLN_OUT_ANY()          '取得
        If intRet = RetCode.OK Then
            '(見つかった場合)
            For Each objXPLN_OUT As TBL_XPLN_OUT In objAryXPLN_OUT.ARYME
                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


                '****************************************
                '出荷指示                       更新
                '****************************************
                If TO_INTEGER(objXPLN_OUT.XSYUKKA_STS) = XSYUKKA_STS_JRDY Or TO_INTEGER(objXPLN_OUT.XSYUKKA_STS) = XSYUKKA_STS_JLESS Then
                    '(引当可能 or 欠品の場合)

                    If blnLESS = True Then
                        objXPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JLESS     '出荷状況
                    Else
                        objXPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JRSV      '出荷状況
                    End If

                    If IsNull(objXPLN_OUT.XOUT_START_DT) Then
                        '(Nullの場合)
                        objXPLN_OUT.XOUT_START_DT = Now                 '出庫開始日時
                    End If

                    If intSyukkaHikiateMode <> SyukkaHikiateMode.Loader01 _
                       Or (intSyukkaHikiateMode = SyukkaHikiateMode.Loader01 And objXPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JLESS) _
                       Then
                        '(    ﾄﾗｯｸﾛｰﾀﾞ1回目以外         の場合)
                        '( or ﾄﾗｯｸﾛｰﾀﾞ1回目かつ欠品     の場合)
                        objXPLN_OUT.UPDATE_XPLN_OUT()                   '更新
                    End If


                End If


            Next
        End If


        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
        If blnHikiate = True Then
            '(引当てていた場合)


            '****************************************
            '車輌番号表示           更新
            '編成№表示             更新
            '****************************************
            Call objSVR_190001.SendYasukawa_IDDispSyaban(objXSTS_BERTH.XBERTH_GROUP, objAryXPLN_OUT.ARYME(0).XSYARYOU_NO)
            Call objSVR_190001.SendYasukawa_IDDispHensei(objXSTS_BERTH.XBERTH_GROUP, objAryXPLN_OUT_DTL.ARYME(0).XHENSEI_NO_OYA)


            '****************************************
            'ﾋﾟｯｷﾝｸﾞﾘｽﾄ印字出力
            '****************************************
            If intSyukkaHikiateMode = SyukkaHikiateMode.Bara Or intSyukkaHikiateMode = SyukkaHikiateMode.Pallet Then
                '(ﾊﾞﾗ or ﾊﾟﾚｯﾄ の場合)

                Call objSVR_190001.SendOther_IDOther(FCOMMAND_ID_JPRINT_PICK, Format(dtmXSYUKKA_D, DATE_FORMAT_02), strXHENSEI_NO_OYA)
                'Call PrintPickingList(dtmXSYUKKA_D, strXHENSEI_NO_OYA)
                'Call Shell(objTPRG_SYS_HEN.SJ000000_024 _
                '           & " " & CMD_STRING01_PRINT _
                '           & " " & Format(dtmXSYUKKA_D, DATE_FORMAT_02) _
                '           & " " & strXHENSEI_NO_OYA _
                '           , AppWinStyle.NormalFocus _
                '           )

            End If


        End If


        '****************************************
        '出荷引当処理(ﾄﾗｯｸﾛｰﾀﾞの予定数書込)
        '****************************************
        Call SyukkaHikiateSetYoteiLoader(dtmXSYUKKA_D _
                                       , strXHENSEI_NO_OYA _
                                       , intSyukkaHikiateMode _
                                       , intAryOutCV(0) _
                                       )


        '****************************************
        '車輌ｺﾝﾄﾛｰﾗ   表示盤出力
        '****************************************
        Call objSVR_190001.SendCar_IDJS_CARD02()


        ''****************************************
        ''Melsec       ﾛｰﾀﾞｰﾓｰﾄﾞ     書込
        ''****************************************
        'Call objSVR_190001.SendYasukawa_IDLoaderMode(objXSTS_BERTH.XBERTH_GROUP _
        '                                           , objAryXPLN_OUT.ARYME(0).XSYARYOU_NO _
        '                                           , intSyukkaHikiateMode _
        '                                           )


        Return intReturn
    End Function
#End Region
#Region "  出荷引当処理(引当 ＆ ｺﾝﾍﾞﾔ割付処理)                                                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' 出荷引当処理(引当 ＆ ｺﾝﾍﾞﾔ割付処理)
    ''' </summary>
    ''' <param name="strFIN_KUBUN">入庫区分</param>
    ''' <param name="decHikiateNum">引当数量</param>
    ''' <param name="strFLOT_NO">ﾛｯﾄ№</param>
    ''' <param name="intAryOutCV">出庫CV</param>
    ''' <param name="intPointOutCV">出庫CVﾎﾟｲﾝﾀ</param>
    ''' <param name="intPointOutSiziSameNum">同時出庫指示数ﾎﾟｲﾝﾀ</param>
    ''' <param name="intOutSiziSameNum">同時出庫指示数</param>
    ''' <param name="objXPLN_OUT">出荷指示</param>
    ''' <param name="objXPLN_OUT_DTL">出荷指示詳細</param>
    ''' <param name="objTMST_ITEM">品目ﾏｽﾀ</param>
    ''' <param name="intSyukkaHikiateMode">出荷引当時の区分</param>
    ''' <param name="objOkuPalletIDList">手前棚に在庫がある為、出庫不可のﾊﾟﾚｯﾄIDﾘｽﾄ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SyukkaHikiateCVWarituke(ByVal strFIN_KUBUN As String _
                                          , ByRef decHikiateNum As Decimal _
                                          , ByVal strFLOT_NO As String _
                                          , ByRef intAryOutCV() As Integer _
                                          , ByRef intPointOutCV As String _
                                          , ByRef intPointOutSiziSameNum As String _
                                          , ByVal intOutSiziSameNum As String _
                                          , ByVal objXPLN_OUT As TBL_XPLN_OUT _
                                          , ByVal objXPLN_OUT_DTL As TBL_XPLN_OUT_DTL _
                                          , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                          , ByVal intSyukkaHikiateMode As SyukkaHikiateMode _
                                          , ByRef objOkuPalletIDList As ArrayList _
                                          ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        Dim intRet As RetCode


        '************************************************
        '初期設定
        '************************************************
        Dim strAryFinalPALLET_ID() As String = Nothing      '最終引当ﾊﾟﾚｯﾄID配列


        '************************************************************************************************************************************************
        '************************************************************************************************************************************************
        '引当処理
        '************************************************************************************************************************************************
        '************************************************************************************************************************************************
        If objXPLN_OUT_DTL.FSAGYOU_KIND = FSAGYOU_KIND_J57 Then
            '(ﾄﾗｯｸﾛｰﾀﾞの場合)

            If intPointOutCV = 0 And (objTMST_ITEM.FNUM_IN_PALLET * 2) <= decHikiateNum Then
                '(1つ目のｺﾝﾍﾞﾔだった場合)


                '************************************************
                '出荷引当処理(ﾍﾟｱﾌﾙﾊﾟﾚｯﾄ出荷引当処理)
                '************************************************
                intRet = SyukkaHikiatePairFull(strFIN_KUBUN _
                                             , objTMST_ITEM _
                                             , strAryFinalPALLET_ID _
                                             , "" _
                                             , objXPLN_OUT_DTL _
                                             , False _
                                             , objOkuPalletIDList _
                                             )


            Else
                '(ｺﾝﾍﾞﾔが進んでしまっていた場合)


                '************************************************
                '出荷引当処理(ｼﾝｸﾞﾙﾌﾙﾊﾟﾚｯﾄ出荷引当処理)
                '************************************************
                intRet = SyukkaHikiateSingleFull(strFIN_KUBUN _
                                               , objTMST_ITEM _
                                               , strAryFinalPALLET_ID _
                                               , "" _
                                               , objXPLN_OUT_DTL _
                                               , False _
                                               , objOkuPalletIDList _
                                               )


            End If


        Else
            '(その他)


            Dim intBaraRet As RetCode = RetCode.NG
            '***************************************************************************************
            '端数の場合 は、平置き優先にする場合の条件

            If ( _
                   (decHikiateNum < (objTMST_ITEM.FNUM_IN_PALLET * 2)) _
               And ((decHikiateNum Mod objTMST_ITEM.FNUM_IN_PALLET) <> 0) _
               ) _
               Then
                '(端数出荷の場合)

                '***************************************************************************************

                '***************************************************************************************
                '端数の場合 or ﾊﾞﾗ出庫の場合 は、平置き優先にする場合の条件

                ''If ( _
                ''       (decHikiateNum < (objTMST_ITEM.FNUM_IN_PALLET * 2)) _
                ''   And ((decHikiateNum Mod objTMST_ITEM.FNUM_IN_PALLET) <> 0) _
                ''   ) _
                ''   Or _
                ''   ( _
                ''   intSyukkaHikiateMode = SyukkaHikiateMode.Bara _
                ''   ) _
                ''   Then
                ' ''(端数出荷の場合)

                '***************************************************************************************


                '************************************************
                '出荷引当処理(端数出荷引当処理)
                '************************************************
                intBaraRet = SyukkaHikiateHasu(strFIN_KUBUN _
                                             , objTMST_ITEM _
                                             , strAryFinalPALLET_ID _
                                             , strFLOT_NO _
                                             , objXPLN_OUT_DTL _
                                             , objOkuPalletIDList _
                                             )
                intRet = intBaraRet


            End If
            If intBaraRet <> RetCode.OK Then
                '(ﾊﾞﾗ出荷で在庫を引当てていない場合)


                '************************************************
                '同時出庫指示数ﾎﾟｲﾝﾀ            ﾁｪｯｸ
                '************************************************
                If intPointOutSiziSameNum < intOutSiziSameNum _
                   And objTMST_ITEM.FNUM_IN_PALLET < decHikiateNum _
                   Then
                    '(ﾎﾟｲﾝﾀ1or2or3かつ、残り数量が1PL超の場合)


                    '************************************************
                    '出荷引当処理(ﾍﾟｱﾌﾙﾊﾟﾚｯﾄ出荷引当処理)
                    '************************************************
                    intRet = SyukkaHikiatePairFull(strFIN_KUBUN _
                                                 , objTMST_ITEM _
                                                 , strAryFinalPALLET_ID _
                                                 , strFLOT_NO _
                                                 , objXPLN_OUT_DTL _
                                                 , True _
                                                 , objOkuPalletIDList _
                                                 )


                Else
                    '(その他)


                    '************************************************
                    '出荷引当処理(ｼﾝｸﾞﾙﾌﾙﾊﾟﾚｯﾄ出荷引当処理)
                    '************************************************
                    intRet = SyukkaHikiateSingleFull(strFIN_KUBUN _
                                                   , objTMST_ITEM _
                                                   , strAryFinalPALLET_ID _
                                                   , strFLOT_NO _
                                                   , objXPLN_OUT_DTL _
                                                   , True _
                                                   , objOkuPalletIDList _
                                                   )


                End If


            End If


        End If
        If intRet <> RetCode.OK Then
            '(見つからなかった場合)
            Return intRet
        End If


        '************************************************************************************************************************************************
        '************************************************************************************************************************************************
        '出庫処理
        '************************************************************************************************************************************************
        '************************************************************************************************************************************************
        ReDim Preserve strAryFinalPALLET_ID(1)          '最終引当ﾊﾟﾚｯﾄID配列(要素数を合わせる)
        For ii As Integer = 1 To 2
            '(ﾙｰﾌﾟ:ﾍﾟｱ搬送)


            '************************************
            '作業種別       設定
            '************************************
            Dim intXOYAKO_KUBUN As Integer          '親子区分
            Dim strFPALLET_ID As String = ""        '出庫ﾊﾟﾚｯﾄID
            Dim strXPALLET_ID_AITE As String = ""   '相手ﾊﾟﾚｯﾄID
            If ii = 1 Then
                '(1PL目の場合)
                intXOYAKO_KUBUN = XOYAKO_KUBUN_JOYA                     '親子区分
                strFPALLET_ID = strAryFinalPALLET_ID(0)                 '出庫ﾊﾟﾚｯﾄID
                strXPALLET_ID_AITE = strAryFinalPALLET_ID(1)            '相手ﾊﾟﾚｯﾄID
            ElseIf ii = 2 Then
                '(2PL目の場合)
                If IsNotNull(strAryFinalPALLET_ID(1)) Then
                    '(子の出庫がある場合)
                    intXOYAKO_KUBUN = XOYAKO_KUBUN_JKO                  '親子区分
                    strFPALLET_ID = strAryFinalPALLET_ID(1)             '出庫ﾊﾟﾚｯﾄID
                    strXPALLET_ID_AITE = strAryFinalPALLET_ID(0)        '相手ﾊﾟﾚｯﾄID
                Else
                    '(子の出庫がない場合)
                    Exit For
                End If
            End If


            '************************************
            '在庫情報               取得
            '************************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            objTRST_STOCK.FPALLET_ID = strFPALLET_ID        'ﾊﾟﾚｯﾄID
            objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)       '取得


            '************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ           取得
            '************************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF.FPALLET_ID = strFPALLET_ID      'ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()              '取得


            '************************************
            '引当数量               計算
            '************************************
            Dim decTempNum As Decimal = 0
            If objTRST_STOCK.ARYME(0).FTR_VOL <= decHikiateNum Then
                '(ﾌﾙPL引当の場合)
                decTempNum = objTRST_STOCK.ARYME(0).FTR_VOL
            Else
                '(端数引当の場合)
                decTempNum = decHikiateNum
            End If
            '===============================================
            '引当数量                   更新
            '===============================================
            decHikiateNum = decHikiateNum - decTempNum


            If objTPRG_TRK_BUF.FTRK_BUF_NO = FTRK_BUF_NO_J9000 Then
                '(自動倉庫の場合)


                '************************************************************************************************************************************************
                '************************************************************************************************************************************************
                '自動倉庫               出庫引当
                '************************************************************************************************************************************************
                '************************************************************************************************************************************************
                '************************************
                '出庫ﾄﾗｯｷﾝｸﾞ定義ｸﾗｽ(ﾊﾟﾚｯﾄID指定)
                '************************************
                Dim objSVR_100501 As New SVR_100501(Owner, ObjDb, ObjDbLog)
                objSVR_100501.FTRK_BUF_NO_TO = intAryOutCV(intPointOutCV)                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(出庫先ﾄﾗｯｷﾝｸﾞ)
                objSVR_100501.FPALLET_ID = strFPALLET_ID                                    'ﾊﾟﾚｯﾄID
                objSVR_100501.FSAGYOU_KIND = objXPLN_OUT_DTL.FSAGYOU_KIND                   '作業種別
                objSVR_100501.FTERM_ID = FTERM_ID_SKOTEI                                    '端末ID
                objSVR_100501.FUSER_ID = FUSER_ID_SKOTEI                                    'ﾕｰｻﾞｰID
                objSVR_100501.FPLAN_KEY = objXPLN_OUT_DTL.FPLAN_KEY                         '計画ｷｰ
                If intSyukkaHikiateMode = SyukkaHikiateMode.Loader02 Then
                    objSVR_100501.FPRIORITY = FPRIORITY_JLOW_MORE01                         '優先ﾚﾍﾞﾙ
                End If
                objSVR_100501.UPDATE_OUT_BUF_Syukka(decTempNum)                             '定義


                '************************
                '搬送指示QUEの特定
                '************************
                Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)         '搬送指示QUE
                objTPLN_CARRY_QUE.FPALLET_ID = strFPALLET_ID                                    'ﾊﾟﾚｯﾄID
                objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                                          '特定


                '************************
                '搬送指示QUEの更新
                '************************
                objTPLN_CARRY_QUE.XOYAKO_KUBUN = intXOYAKO_KUBUN            '親子区分
                objTPLN_CARRY_QUE.XPALLET_ID_AITE = strXPALLET_ID_AITE      '相手ﾊﾟﾚｯﾄID
                objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                   '更新


                '************************************************************************
                '同時出庫指示数ﾎﾟｲﾝﾀ        更新
                '出庫CVﾎﾟｲﾝﾀ                更新
                '************************************************************************
                If objXPLN_OUT_DTL.FSAGYOU_KIND = FSAGYOU_KIND_J57 Then
                    '(ﾄﾗｯｸﾛｰﾀﾞの場合)

                    If IsNull(strXPALLET_ID_AITE) Then
                        '(ｼﾝｸﾞﾙ出庫の場合)

                        '出庫CVﾎﾟｲﾝﾀ                更新
                        If UBound(intAryOutCV) <= intPointOutCV Then intPointOutCV = 0 Else intPointOutCV += 1

                    End If


                Else
                    '(その他)

                    If intOutSiziSameNum <= intPointOutSiziSameNum Then
                        '(ｺﾝﾍﾞﾔ一杯の場合)

                        '同時出庫指示数ﾎﾟｲﾝﾀ        更新
                        intPointOutSiziSameNum = 1
                        '出庫CVﾎﾟｲﾝﾀ                更新
                        If UBound(intAryOutCV) <= intPointOutCV Then intPointOutCV = 0 Else intPointOutCV += 1

                    Else
                        intPointOutSiziSameNum += 1
                    End If

                End If


            Else


                '************************************************************************************************************************************************
                '************************************************************************************************************************************************
                '平置き                 出庫引当
                '************************************************************************************************************************************************
                '************************************************************************************************************************************************
                '*****************************************************
                '出荷指示、出荷指示詳細、出庫実績詳細  の追加更新
                '*****************************************************
                Call SyukkaHikiateHiraokiUpdate(objTRST_STOCK _
                                              , objTMST_ITEM _
                                              , objXPLN_OUT_DTL.FPLAN_KEY _
                                              , decTempNum _
                                              , objTPRG_TRK_BUF.FTRK_BUF_NO _
                                              , objTPRG_TRK_BUF.FTRK_BUF_ARRAY _
                                              , objTPRG_TRK_BUF.FTRK_BUF_NO _
                                              , objTPRG_TRK_BUF.FTRK_BUF_ARRAY _
                                              , True _
                                              )
                '更新されているので、再取得
                Dim dtmXSYUKKA_D_Temp As Date = objXPLN_OUT.XSYUKKA_D           '出荷日
                Dim strXHENSEI_NO_Temp As String = objXPLN_OUT.XHENSEI_NO       '編成No.
                Dim strXDENPYOU_NO_Temp As String = objXPLN_OUT.XDENPYOU_NO     '伝票No.
                Dim strFHINMEI_CD_Temp As String = objXPLN_OUT_DTL.FHINMEI_CD   '品目ｺｰﾄﾞ
                '出荷指示
                objXPLN_OUT.CLEAR_PROPERTY()
                objXPLN_OUT.XSYUKKA_D = dtmXSYUKKA_D_Temp                       '出荷日
                objXPLN_OUT.XHENSEI_NO = strXHENSEI_NO_Temp                     '編成No.
                objXPLN_OUT.XDENPYOU_NO = strXDENPYOU_NO_Temp                   '伝票No.
                objXPLN_OUT.GET_XPLN_OUT()                                      '取得
                '出荷指示詳細
                objXPLN_OUT_DTL.CLEAR_PROPERTY()
                objXPLN_OUT_DTL.XSYUKKA_D = dtmXSYUKKA_D_Temp                   '出荷日
                objXPLN_OUT_DTL.XHENSEI_NO = strXHENSEI_NO_Temp                 '編成No.
                objXPLN_OUT_DTL.FHINMEI_CD = strFHINMEI_CD_Temp                 '品目ｺｰﾄﾞ
                objXPLN_OUT_DTL.XDENPYOU_NO = strXDENPYOU_NO_Temp               '伝票No.
                objXPLN_OUT_DTL.GET_XPLN_OUT_DTL()                              '取得


                If objTRST_STOCK.ARYME(0).FTR_VOL = decTempNum Then
                    '(在庫削除の場合)


                    '************************
                    '平置き在庫削除
                    '************************
                    Call DeleteHiraoki(objTRST_STOCK.ARYME(0).FPALLET_ID _
                                     , FINOUT_STS_SOUT_END _
                                     , objXPLN_OUT_DTL.FSAGYOU_KIND _
                                     )


                Else
                    '(在庫更新の場合)


                    '************************
                    '在庫情報       更新
                    '************************
                    objTRST_STOCK.ARYME(0).FTR_VOL -= decTempNum         '搬送管理量
                    objTRST_STOCK.ARYME(0).FUPDATE_DT = Now              '更新日時
                    objTRST_STOCK.ARYME(0).UPDATE_TRST_STOCK_ALL()       '更新


                    '************************
                    'INOUT実績追加
                    '************************
                    Dim objTLOG_INOUT As New TBL_TLOG_INOUT(Owner, ObjDb, ObjDbLog)         'INOUT実績ｸﾗｽ
                    objTLOG_INOUT.FRESULT_DT = Now                                          '実績日時
                    objTLOG_INOUT.FBUF_FM = objTPRG_TRK_BUF.FTRK_BUF_NO                     '搬送元ﾊﾞｯﾌｧ№
                    objTLOG_INOUT.FARRAY_FM = objTPRG_TRK_BUF.FTRK_BUF_ARRAY                '搬送元配列№
                    objTLOG_INOUT.FBUF_TO = objTPRG_TRK_BUF.FTRK_BUF_NO                     '搬送先ﾊﾞｯﾌｧ№
                    objTLOG_INOUT.FARRAY_TO = objTPRG_TRK_BUF.FTRK_BUF_ARRAY                '搬送先配列№
                    objTLOG_INOUT.FINOUT_STS = FINOUT_STS_SOUT_END                          'IN/OUT
                    objTLOG_INOUT.FSAGYOU_KIND = objXPLN_OUT_DTL.FSAGYOU_KIND               '作業種別
                    objTLOG_INOUT.FDISP_ADDRESS_FM = objTPRG_TRK_BUF.FDISP_ADDRESS          'FM表記用ｱﾄﾞﾚｽ
                    objTLOG_INOUT.FDISP_ADDRESS_TO = objTPRG_TRK_BUF.FDISP_ADDRESS          'TO表記用ｱﾄﾞﾚｽ
                    objTLOG_INOUT.FDISPLOG_ADDRESS_FM = objTPRG_TRK_BUF.FDISP_ADDRESS       'FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
                    objTLOG_INOUT.FDISPLOG_ADDRESS_TO = objTPRG_TRK_BUF.FDISP_ADDRESS       'TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
                    objTLOG_INOUT.FUSER_ID = FUSER_ID_SKOTEI                                'ﾕｰｻﾞｰID
                    objTLOG_INOUT.OBJTRST_STOCK = objTRST_STOCK                             '在庫情報
                    objTLOG_INOUT.ADD_TLOG_INOUT_ALL()                                      '追加


                End If


            End If


        Next


        Return intReturn
    End Function
#End Region
#Region "  出荷引当処理(ﾍﾟｱﾌﾙﾊﾟﾚｯﾄ出荷引当処理)                                                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' 出荷引当処理(ﾍﾟｱﾌﾙﾊﾟﾚｯﾄ出荷引当処理)
    ''' </summary>
    ''' <param name="strFIN_KUBUN">入庫区分</param>
    ''' <param name="objTMST_ITEM">品目ﾏｽﾀ</param>
    ''' <param name="strAryFinalPALLET_ID">最終引当ﾊﾟﾚｯﾄID配列</param>
    ''' <param name="strFLOT_NO">ﾛｯﾄ№一覧の配列</param>
    ''' <param name="objXPLN_OUT_DTL">出荷指示詳細</param>
    ''' <param name="blnHikiateHasuHira">端数or平置きの在庫を引当てるか否か</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SyukkaHikiatePairFull(ByVal strFIN_KUBUN As String _
                                        , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                        , ByRef strAryFinalPALLET_ID() As String _
                                        , ByVal strFLOT_NO As String _
                                        , ByVal objXPLN_OUT_DTL As TBL_XPLN_OUT_DTL _
                                        , ByVal blnHikiateHasuHira As Boolean _
                                        , ByRef objOkuPalletIDList As ArrayList _
                                        ) As RetCode
        Dim intReturn As RetCode = RetCode.NotFound
        'Dim strMsg As String
        Dim intRet As RetCode


        '************************************************************************************************
        '************************************************************************************************
        'ﾌﾙPL引当処理
        '************************************************************************************************
        '************************************************************************************************
        '************************************************
        '在庫引当
        '************************************************
        Dim objSVR_100202 As New SVR_100202(Owner, ObjDb, ObjDbLog)             '在庫引当ｸﾗｽ
        objSVR_100202.FTRK_BUF_NO = FTRK_BUF_NO_J9000                           'ﾊﾞｯﾌｧ№
        'objSVR_100202.INTMaxPlt = 2                                             '最大引当ﾊﾟﾚｯﾄ数
        objSVR_100202.intHasu = SVR_100202.HasuMode.FullPL                      '端数ﾓｰﾄﾞ
        objSVR_100202.INTUpdateMode = SVR_100202.UpdateMode.NON_UPDATE          '更新ﾓｰﾄﾞ(通常)
        objSVR_100202.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD                      '品目ｺｰﾄﾞ
        objSVR_100202.FIN_KUBUN = strFIN_KUBUN                                  '入庫区分
        objSVR_100202.FLOT_NO = strFLOT_NO                                      'ﾛｯﾄ№
        objSVR_100202.FHORYU_KUBUN = FHORYU_KUBUN_SNORMAL                       '保留区分
        objSVR_100202.XKENSA_KUBUN = XKENSA_KUBUN_J_OK                          '検査区分
        'objSVR_100202.XKENPIN_KUBUN = XKENPIN_KUBUN_J_SUMI                      '検品区分
        intRet = objSVR_100202.FIND_STOCK(FTR_VOL_SFULL)                        '在庫引当
        If intRet = RetCode.OK Then
            '(見つかった場合)

            For ii As Integer = 1 To 2
                '(ﾙｰﾌﾟ:2回)
                '(1回目ﾙｰﾌﾟ:出庫可能PLが対象(手前棚に、在庫or予約がある場合、奥棚は引当てない))
                '(2回目ﾙｰﾌﾟ:出庫不可PLも対象(手前棚に、在庫or予約がある場合でも、奥棚は引当てる))


                '************************************************************************************************
                '在庫引当処理(ﾌﾞﾛｯｸ単位で引当てる)
                '満数ﾌﾞﾛｯｸしか引当てない
                '************************************************************************************************
                ReDim strAryFinalPALLET_ID(1)
                Select Case ii
                    Case 1 : Call ZaikoHikiatePair(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, False, PairOrSingle.intPair, objOkuPalletIDList)
                    Case 2 : Call ZaikoHikiatePair(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, True, PairOrSingle.intPair, objOkuPalletIDList)
                End Select
                If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


                '************************************************************************************************
                '在庫引当処理(ﾌﾞﾛｯｸ単位で引当てる)
                '************************************************************************************************
                ReDim strAryFinalPALLET_ID(0)
                Select Case ii
                    Case 1 : Call ZaikoHikiateNormal(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, False, False, True, objOkuPalletIDList)
                    Case 2 : Call ZaikoHikiateNormal(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, True, False, True, objOkuPalletIDList)
                End Select
                If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


            Next

        End If


        If blnHikiateHasuHira = True Then
            '(端数or平置きの在庫を引当てる場合)


            '************************************************************************************************
            '************************************************************************************************
            '端数PL引当処理
            '************************************************************************************************
            '************************************************************************************************
            ReDim strAryFinalPALLET_ID(1)
            intRet = SyukkaHikiateHasu(strFIN_KUBUN _
                                     , objTMST_ITEM _
                                     , strAryFinalPALLET_ID _
                                     , strFLOT_NO _
                                     , objOkuPalletIDList _
                                     )
            If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


            '************************************************************************************************
            '************************************************************************************************
            '平置きPL引当処理
            '************************************************************************************************
            '************************************************************************************************
            intRet = SyukkaHikiateHira(strFIN_KUBUN _
                                     , objTMST_ITEM _
                                     , strAryFinalPALLET_ID _
                                     , strFLOT_NO _
                                     )
            If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


        End If


        Return intReturn
    End Function
#End Region
#Region "  出荷引当処理(ｼﾝｸﾞﾙﾌﾙﾊﾟﾚｯﾄ出荷引当処理)                                                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' 出荷引当処理(ｼﾝｸﾞﾙﾌﾙﾊﾟﾚｯﾄ出荷引当処理)
    ''' </summary>
    ''' <param name="strFIN_KUBUN">入庫区分</param>
    ''' <param name="objTMST_ITEM">品目ﾏｽﾀ</param>
    ''' <param name="strAryFinalPALLET_ID">最終引当ﾊﾟﾚｯﾄID配列</param>
    ''' <param name="strFLOT_NO">ﾛｯﾄ№</param>
    ''' <param name="objXPLN_OUT_DTL">出荷指示詳細</param>
    ''' <param name="blnHikiateHasuHira">端数or平置きの在庫を引当てるか否か</param>
    ''' <param name="objOkuPalletIDList">手前棚に在庫がある為、出庫不可のﾊﾟﾚｯﾄIDﾘｽﾄ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SyukkaHikiateSingleFull(ByVal strFIN_KUBUN As String _
                                          , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                          , ByRef strAryFinalPALLET_ID() As String _
                                          , ByVal strFLOT_NO As String _
                                          , ByVal objXPLN_OUT_DTL As TBL_XPLN_OUT_DTL _
                                          , ByVal blnHikiateHasuHira As Boolean _
                                          , ByRef objOkuPalletIDList As ArrayList _
                                          ) As RetCode
        Dim intReturn As RetCode = RetCode.NotFound
        'Dim strMsg As String
        Dim intRet As RetCode


        '************************************************************************************************
        '************************************************************************************************
        'ﾌﾙPL引当処理
        '************************************************************************************************
        '************************************************************************************************
        '************************************************
        '在庫引当
        '************************************************
        Dim objSVR_100202 As New SVR_100202(Owner, ObjDb, ObjDbLog)             '在庫引当ｸﾗｽ
        objSVR_100202.FTRK_BUF_NO = FTRK_BUF_NO_J9000                           'ﾊﾞｯﾌｧ№
        'objSVR_100202.INTMaxPlt = 2                                             '最大引当ﾊﾟﾚｯﾄ数
        objSVR_100202.intHasu = SVR_100202.HasuMode.FullPL                      '端数ﾓｰﾄﾞ
        objSVR_100202.INTUpdateMode = SVR_100202.UpdateMode.NON_UPDATE          '更新ﾓｰﾄﾞ(通常)
        objSVR_100202.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD                      '品目ｺｰﾄﾞ
        objSVR_100202.FIN_KUBUN = strFIN_KUBUN                                  '入庫区分
        objSVR_100202.FLOT_NO = strFLOT_NO                                      'ﾛｯﾄ№
        objSVR_100202.FHORYU_KUBUN = FHORYU_KUBUN_SNORMAL                       '保留区分
        objSVR_100202.XKENSA_KUBUN = XKENSA_KUBUN_J_OK                          '検査区分
        'objSVR_100202.XKENPIN_KUBUN = XKENPIN_KUBUN_J_SUMI                      '検品区分
        intRet = objSVR_100202.FIND_STOCK(FTR_VOL_SFULL)                        '在庫引当
        If intRet = RetCode.OK Then
            '(見つかった場合)

            For ii As Integer = 1 To 2
                '(ﾙｰﾌﾟ:2回)
                '(1回目ﾙｰﾌﾟ:出庫可能PLが対象(手前棚に、在庫or予約がある場合、奥棚は引当てない))
                '(2回目ﾙｰﾌﾟ:出庫不可PLも対象(手前棚に、在庫or予約がある場合でも、奥棚は引当てる))


                '************************************************************************************************
                '在庫引当処理(ﾌﾞﾛｯｸ単位で引当てる)
                '端数ﾌﾞﾛｯｸしか引当てない
                '************************************************************************************************
                ReDim strAryFinalPALLET_ID(0)
                Select Case ii
                    Case 1 : Call ZaikoHikiatePair(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, False, PairOrSingle.intSingle, objOkuPalletIDList)
                    Case 2 : Call ZaikoHikiatePair(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, True, PairOrSingle.intSingle, objOkuPalletIDList)
                End Select
                If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


                '************************************************************************************************
                '在庫引当処理(ﾌﾞﾛｯｸ単位で引当てる)
                '************************************************************************************************
                ReDim strAryFinalPALLET_ID(0)
                Select Case ii
                    Case 1 : Call ZaikoHikiateNormal(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, False, False, True, objOkuPalletIDList)
                    Case 2 : Call ZaikoHikiateNormal(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, True, False, True, objOkuPalletIDList)
                End Select
                If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


            Next

        End If


        If blnHikiateHasuHira = True Then
            '(端数or平置きの在庫を引当てる場合)


            '************************************************************************************************
            '************************************************************************************************
            '端数PL引当処理
            '************************************************************************************************
            '************************************************************************************************
            ReDim strAryFinalPALLET_ID(0)
            intRet = SyukkaHikiateHasu(strFIN_KUBUN _
                                     , objTMST_ITEM _
                                     , strAryFinalPALLET_ID _
                                     , strFLOT_NO _
                                     , objOkuPalletIDList _
                                     )
            If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


            '************************************************************************************************
            '************************************************************************************************
            '平置きPL引当処理
            '************************************************************************************************
            '************************************************************************************************
            intRet = SyukkaHikiateHira(strFIN_KUBUN _
                                     , objTMST_ITEM _
                                     , strAryFinalPALLET_ID _
                                     , strFLOT_NO _
                                     )
            If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


        End If


        Return intReturn
    End Function
#End Region
#Region "  出荷引当処理(端数出荷引当処理)                                                           "
    '''**********************************************************************************************
    ''' <summary>
    ''' 出荷引当処理(端数出荷引当処理)
    ''' </summary>
    ''' <param name="strFIN_KUBUN">入庫区分</param>
    ''' <param name="objTMST_ITEM">品目ﾏｽﾀ</param>
    ''' <param name="strAryFinalPALLET_ID">最終引当ﾊﾟﾚｯﾄID配列</param>
    ''' <param name="strFLOT_NO">ﾛｯﾄ№</param>
    ''' <param name="objXPLN_OUT_DTL">出荷指示詳細</param>
    ''' <param name="objOkuPalletIDList">手前棚に在庫がある為、出庫不可のﾊﾟﾚｯﾄIDﾘｽﾄ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SyukkaHikiateHasu(ByVal strFIN_KUBUN As String _
                                    , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                    , ByRef strAryFinalPALLET_ID() As String _
                                    , ByVal strFLOT_NO As String _
                                    , ByVal objXPLN_OUT_DTL As TBL_XPLN_OUT_DTL _
                                    , ByRef objOkuPalletIDList As ArrayList _
                                    ) As RetCode
        Dim intReturn As RetCode = RetCode.NotFound
        'Dim strMsg As String
        Dim intRet As RetCode


        '*****************************************************
        '平置きPL引当処理
        '*****************************************************
        intRet = SyukkaHikiateHira(strFIN_KUBUN _
                                 , objTMST_ITEM _
                                 , strAryFinalPALLET_ID _
                                 , strFLOT_NO _
                                 )
        If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


        '*****************************************************
        '端数PL引当処理
        '*****************************************************
        ReDim strAryFinalPALLET_ID(0)
        intRet = SyukkaHikiateHasu(strFIN_KUBUN _
                                 , objTMST_ITEM _
                                 , strAryFinalPALLET_ID _
                                 , strFLOT_NO _
                                 , objOkuPalletIDList _
                                 )
        If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


        Return intReturn
    End Function
#End Region
#Region "  出荷引当処理(端数PL引当処理)                                                             "
    '''**********************************************************************************************
    ''' <summary>
    ''' 出荷引当処理(ﾛｯﾄ№配列取得)
    ''' </summary>
    ''' <param name="strFIN_KUBUN">入庫区分</param>
    ''' <param name="objTMST_ITEM">品目ﾏｽﾀ</param>
    ''' <param name="strAryFinalPALLET_ID">最終引当ﾊﾟﾚｯﾄID配列</param>
    ''' <param name="strFLOT_NO">ﾛｯﾄ№</param>
    ''' <param name="objOkuPalletIDList">手前棚に在庫がある為、出庫不可のﾊﾟﾚｯﾄIDﾘｽﾄ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function SyukkaHikiateHasu(ByVal strFIN_KUBUN As String _
                                     , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                     , ByRef strAryFinalPALLET_ID() As String _
                                     , ByVal strFLOT_NO As String _
                                     , ByRef objOkuPalletIDList As ArrayList _
                                     ) As RetCode
        Dim intReturn As RetCode = RetCode.NotFound
        'Dim strMsg As String
        Dim intRet As RetCode


        '************************************************************************************************
        '************************************************************************************************
        '端数PL引当処理
        '************************************************************************************************
        '************************************************************************************************
        '************************************************
        '在庫引当
        '************************************************
        Dim objSVR_100202 As New SVR_100202(Owner, ObjDb, ObjDbLog)             '在庫引当ｸﾗｽ
        objSVR_100202.FTRK_BUF_NO = FTRK_BUF_NO_J9000                           'ﾊﾞｯﾌｧ№
        'objSVR_100202.INTMaxPlt = 2                                             '最大引当ﾊﾟﾚｯﾄ数
        objSVR_100202.intHasu = SVR_100202.HasuMode.All                         '端数ﾓｰﾄﾞ
        objSVR_100202.INTUpdateMode = SVR_100202.UpdateMode.NON_UPDATE          '更新ﾓｰﾄﾞ(通常)
        objSVR_100202.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD                      '品目ｺｰﾄﾞ
        objSVR_100202.FIN_KUBUN = strFIN_KUBUN                                  '入庫区分
        objSVR_100202.FLOT_NO = strFLOT_NO                                      'ﾛｯﾄ№
        objSVR_100202.FHORYU_KUBUN = FHORYU_KUBUN_SNORMAL                       '保留区分
        objSVR_100202.XKENSA_KUBUN = XKENSA_KUBUN_J_OK                          '検査区分
        'objSVR_100202.XKENPIN_KUBUN = XKENPIN_KUBUN_J_SUMI                      '検品区分
        intRet = objSVR_100202.FIND_STOCK(FTR_VOL_SFULL)                        '在庫引当
        If intRet = RetCode.OK Then
            '(見つかった場合)


            '************************************************************************************************
            '在庫引当処理(ﾌﾞﾛｯｸ単位で引当てて、かつ手前棚から引当てる)
            '************************************************************************************************
            Call ZaikoHikiateNormal(objSVR_100202, strAryFinalPALLET_ID, objTMST_ITEM, True, True, True, objOkuPalletIDList)
            If IsNotNull(strAryFinalPALLET_ID(0)) Then Return RetCode.OK


        End If


        Return intReturn
    End Function
#End Region
#Region "  出荷引当処理(平置きPL引当処理)                                                           "
    '''**********************************************************************************************
    ''' <summary>
    ''' 出荷引当処理(平置きPL引当処理)
    ''' </summary>
    ''' <param name="strFIN_KUBUN">入庫区分</param>
    ''' <param name="objTMST_ITEM">品目ﾏｽﾀ</param>
    ''' <param name="strAryFinalPALLET_ID">最終引当ﾊﾟﾚｯﾄID配列</param>
    ''' <param name="strFLOT_NO">ﾛｯﾄ№</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function SyukkaHikiateHira(ByVal strFIN_KUBUN As String _
                                     , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                     , ByRef strAryFinalPALLET_ID() As String _
                                     , ByVal strFLOT_NO As String _
                                     ) As RetCode
        Dim intReturn As RetCode = RetCode.NotFound
        'Dim strMsg As String
        Dim intRet As RetCode
        ReDim strAryFinalPALLET_ID(0)


        '************************************************************************************************
        '************************************************************************************************
        '平置きPL引当処理
        '************************************************************************************************
        '************************************************************************************************
        '************************************************
        '平置き在庫を引当てる
        '************************************************
        Dim strSQL As String = ""       'SQL文
        Dim objAryTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    TRST_STOCK.FPALLET_ID "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FLOT_NO_STOCK "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FHINMEI_CD "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FLOT_NO "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FARRIVE_DT "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FIN_KUBUN "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FSEIHIN_KUBUN "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FZAIKO_KUBUN "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FHORYU_KUBUN "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FST_FM "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FTR_VOL "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FTR_RES_VOL "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FUPDATE_DT "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FHASU_FLAG "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FLABEL_ID "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FSYUKKA_TO_CD "
        strSQL &= vbCrLf & "   ,TRST_STOCK.FSYUKKA_TO_NAME "
        strSQL &= vbCrLf & "   ,TRST_STOCK.XPROD_LINE "
        strSQL &= vbCrLf & "   ,TRST_STOCK.XKENSA_KUBUN "
        strSQL &= vbCrLf & "   ,TRST_STOCK.XKENPIN_KUBUN "
        strSQL &= vbCrLf & "   ,TRST_STOCK.XMAKER_CD "
        strSQL &= vbCrLf & "   ,TRST_STOCK.XRAC_IN_DT "
        strSQL &= vbCrLf & "   ,TRST_STOCK.XTRK_BUF_NO_IN "
        strSQL &= vbCrLf & "   ,TRST_STOCK.XTRK_BUF_ARRAY_IN "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TRST_STOCK "
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF "
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "    1 = 1 "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID "           'ﾊﾟﾚｯﾄIDで結合
        strSQL &= vbCrLf & "    AND TRST_STOCK.FTR_RES_VOL < TRST_STOCK.FTR_VOL "               '引当されていない在庫がある
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO IN (" & FTRK_BUF_NO_J9100 & ") "   '平置き
        strSQL &= vbCrLf & "    AND TRST_STOCK.FHORYU_KUBUN = " & FHORYU_KUBUN_SNORMAL & " "    '保留区分
        strSQL &= vbCrLf & "    AND TRST_STOCK.XKENSA_KUBUN = " & XKENSA_KUBUN_J_OK & " "       '検査区分
        If IsNotNull(objTMST_ITEM.FHINMEI_CD) Then
            '(品名ｺｰﾄﾞ指定有りの場合)
            strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = '" & objTMST_ITEM.FHINMEI_CD & "' "     '品名ｺｰﾄﾞ
        End If
        If IsNotNull(strFLOT_NO) Then
            '(ﾛｯﾄ№指定有りの場合)
            strSQL &= vbCrLf & "    AND TRST_STOCK.FLOT_NO = '" & strFLOT_NO & "' "                 'ﾛｯﾄ№
        End If
        If IsNotNull(strFIN_KUBUN) Then
            '(入庫区分指定有りの場合)
            strSQL &= vbCrLf & "    AND TRST_STOCK.FIN_KUBUN IN (" & strFIN_KUBUN & ")"             '入庫区分
        End If
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    TRST_STOCK.FLOT_NO "            'ﾛｯﾄ№
        strSQL &= vbCrLf & "   ,TRST_STOCK.FPALLET_ID "         'ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf
        objAryTRST_STOCK.USER_SQL = strSQL                      'SQL文
        intRet = objAryTRST_STOCK.GET_TRST_STOCK_USER()         '取得
        If intRet = RetCode.OK Then
            '(見つかった場合)

            For Each objTRST_STOCK As TBL_TRST_STOCK In objAryTRST_STOCK.ARYME
                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


                '************************************************
                '最終引当ﾊﾟﾚｯﾄID配列                更新
                '************************************************
                strAryFinalPALLET_ID(0) = objTRST_STOCK.FPALLET_ID      'ﾊﾟﾚｯﾄID
                Return RetCode.OK

            Next

        End If


        Return intReturn
    End Function
#End Region
    '出荷引当(内部関数)
#Region "  出荷引当処理(ﾛｯﾄ№配列取得)                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' 出荷引当処理(ﾛｯﾄ№配列取得)
    ''' </summary>
    ''' <param name="strAryFLOT_NO">ﾛｯﾄ№</param>
    ''' <param name="strFHINMEI_CD">品目ｺｰﾄﾞ</param>
    ''' <param name="intFIN_KUBUN">入庫区分</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function SyukkaHikiateGetAryFLOT_NO(ByRef strAryFLOT_NO() As String _
                                              , ByVal strFHINMEI_CD As String _
                                              , ByVal intFIN_KUBUN As Nullable(Of Integer) _
                                              ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        'Dim intRet As RetCode


        '****************************************
        'ﾛｯﾄ№                  取得
        '****************************************
        Dim strSQL As String = ""       'SQL文
        Dim objAryTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    FLOT_NO AS FLOT_NO "
        strSQL &= vbCrLf & "   ,MIN(FARRIVE_DT) AS FARRIVE_DT_MIN "
        strSQL &= vbCrLf & "   ,TO_CHAR(MIN(FARRIVE_DT), 'YYYYMMDD') AS FARRIVE_DT_MIN_TOCHAR "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TRST_STOCK "
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "    1 = 1 "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FTR_RES_VOL < TRST_STOCK.FTR_VOL "               '引当されていない在庫がある
        strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = '" & strFHINMEI_CD & "' "           '品目ｺｰﾄﾞ
        strSQL &= vbCrLf & "    AND TRST_STOCK.FHORYU_KUBUN = " & FHORYU_KUBUN_SNORMAL & " "    '保留区分
        strSQL &= vbCrLf & "    AND TRST_STOCK.XKENSA_KUBUN = " & XKENSA_KUBUN_J_OK & " "       '検査区分
        If IsNotNull(intFIN_KUBUN) Then
            strSQL &= vbCrLf & "    AND TRST_STOCK.FIN_KUBUN = " & intFIN_KUBUN & " "           '入庫区分
        End If
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "    FLOT_NO "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    FARRIVE_DT_MIN_TOCHAR "
        strSQL &= vbCrLf & "   ,FLOT_NO "
        strSQL &= vbCrLf


        '***********************
        '抽出
        '***********************
        Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
        'Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        ObjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TRST_STOCK"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim strAryFLOT_NO(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii As Integer = LBound(strAryFLOT_NO) To UBound(strAryFLOT_NO)
                strAryFLOT_NO(ii) = TO_STRING(objDataSet.Tables(strDataSetName).Rows(ii)(0))
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If


        Return intReturn
    End Function
#End Region
#Region "  出荷引当処理(ﾄﾗｯｸﾛｰﾀﾞの予定数書込)                                                       "
    '''**********************************************************************************************
    ''' <summary>
    ''' 出荷引当処理(ﾄﾗｯｸﾛｰﾀﾞの予定数書込)
    ''' </summary>
    ''' <param name="dtmXSYUKKA_D">出荷日</param>
    ''' <param name="strXHENSEI_NO_OYA">親編成No.</param>
    ''' <param name="intFTRK_BUF_NO_TO">行先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function SyukkaHikiateSetYoteiLoader(ByVal dtmXSYUKKA_D As Date _
                                               , ByVal strXHENSEI_NO_OYA As String _
                                               , ByVal intSyukkaHikiateMode As SyukkaHikiateMode _
                                               , ByVal intFTRK_BUF_NO_TO As Integer _
                                               ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        Dim intRet As RetCode


        '****************************************
        'ﾁｪｯｸ
        '****************************************
        If intSyukkaHikiateMode <> SyukkaHikiateMode.Loader02 Then Return RetCode.OK


        '****************************************
        '在庫引当情報               取得
        '****************************************
        Dim intCountSingle As Integer = 0       'ｼﾝｸﾞﾙ搬送の計画数
        Dim strSQL As String = ""       'SQL文
        Dim objAryTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    * "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TSTS_HIKIATE "
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "    1 = 1 "
        strSQL &= vbCrLf & "    AND FPLAN_KEY IN ( SELECT "
        strSQL &= vbCrLf & "                          FPLAN_KEY "
        strSQL &= vbCrLf & "                       FROM "
        strSQL &= vbCrLf & "                          XPLN_OUT_DTL "
        strSQL &= vbCrLf & "                       WHERE "
        strSQL &= vbCrLf & "                          1 = 1 "
        strSQL &= vbCrLf & "                          AND XSYUKKA_D = TO_DATE('" & Format(dtmXSYUKKA_D, DATE_FORMAT_03) & "','YYYY/MM/DD HH24:MI:SS') "
        strSQL &= vbCrLf & "                          AND XHENSEI_NO_OYA = '" & strXHENSEI_NO_OYA & "' "
        strSQL &= vbCrLf & "                      ) "
        strSQL &= vbCrLf
        objAryTSTS_HIKIATE.USER_SQL = strSQL
        intRet = objAryTSTS_HIKIATE.GET_TSTS_HIKIATE_USER()
        If intRet = RetCode.OK Then
            '(見つかった場合)
            For Each objTSTS_HIKIATE As TBL_TSTS_HIKIATE In objAryTSTS_HIKIATE.ARYME
                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


                '****************************************
                '搬送指示QUE                取得
                '****************************************
                Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                objTPLN_CARRY_QUE.FPALLET_ID = objTSTS_HIKIATE.FPALLET_ID       'ﾊﾟﾚｯﾄID
                intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)            '取得
                If intRet = RetCode.OK Then
                    '(見つかった場合)
                    '(再引当の場合、既にSTに到着しているﾄﾗｯｷﾝｸﾞもｶｳﾝﾄしてしまう為)
                    If IsNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then intCountSingle += 1
                End If


            Next


            '****************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ            取得
            '****************************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.FTRK_BUF_NO = intFTRK_BUF_NO_TO     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTMST_TRK.GET_TMST_TRK()                      '取得


            '************************************************
            '安川         到着予定数
            '************************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            'objSVR_190001.FEQ_ID = strFEQ_ID                                '設備ID
            objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         'ｺﾏﾝﾄﾞID
            objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK.FTRK_BUF_NO _
                                                  , intCountSingle _
                                                  , objAryTSTS_HIKIATE.ARYME.Length - intCountSingle _
                                                  )


        End If


        Return intReturn
    End Function
#End Region

    '在庫引当
#Region "  在庫引当処理(ﾌﾞﾛｯｸ単位で引当てる)(1PLしか引当てない)                                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' 在庫引当処理(ﾌﾞﾛｯｸ単位で引当てて、かつ手前棚から引当てる)
    ''' </summary>
    ''' <param name="objSVR_100202">在庫引当ｸﾗｽ</param>
    ''' <param name="strAryFinalPALLET_ID">ﾀﾞﾌﾞﾙﾃﾞｨｰﾌﾟも考慮して引当てたﾊﾟﾚｯﾄID配列</param>
    ''' <param name="objTMST_ITEM">品目ﾏｽﾀ</param>
    ''' <param name="blnOkuHikiate">手前棚が予約されていても、奥棚を引当てるか否か</param>
    ''' <param name="blnHasuHikiate">端数PLは引当対象とするか否か</param>
    ''' <param name="blnHasuBlockHikiate">端数ﾌﾞﾛｯｸは引当対象とするか否か</param>
    ''' <param name="objOkuPalletIDList">手前棚に在庫がある為、出庫不可のﾊﾟﾚｯﾄIDﾘｽﾄ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function ZaikoHikiateNormal(ByVal objSVR_100202 As SVR_100202 _
                                     , ByRef strAryFinalPALLET_ID() As String _
                                     , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                     , ByVal blnOkuHikiate As Boolean _
                                     , ByVal blnHasuHikiate As Boolean _
                                     , ByVal blnHasuBlockHikiate As Boolean _
                                     , ByRef objOkuPalletIDList As ArrayList _
                                     ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        Dim intRet As RetCode


        '************************************************************************************************
        '************************************************************************************************
        'ﾌﾞﾛｯｸ処理
        '************************************************************************************************
        '************************************************************************************************
        'ReDim strAryFinalPALLET_ID(0)                                       'ﾌﾞﾛｯｸ単位で引当てたﾊﾟﾚｯﾄID配列
        Dim intXTANA_BLOCK_Memory As Integer = -1                           '引当てたﾊﾟﾚｯﾄの棚ﾌﾞﾛｯｸ(記憶)
        For ii As Integer = 0 To UBound(objSVR_100202.strArrayPALLET_ID)
            '(ﾙｰﾌﾟ:引き当たったﾊﾟﾚｯﾄ数)


            '***********************************************
            '初期設定
            '***********************************************
            Dim strHikiateFPALLET_ID As String = objSVR_100202.strArrayPALLET_ID(ii)                    '仮に引き当たったﾊﾟﾚｯﾄID
            Dim intHikiateXTANA_BLOCK As Integer = TO_INTEGER(objSVR_100202.intAryXTANA_BLOCK(ii))      '仮に引き当たったﾊﾟﾚｯﾄIDの棚ﾌﾞﾛｯｸ


            '***********************************************
            '処理時間短縮ﾁｪｯｸ
            '***********************************************
            '======================================
            '棚ﾌﾞﾛｯｸﾁｪｯｸ
            '======================================
            If intXTANA_BLOCK_Memory = intHikiateXTANA_BLOCK Then Continue For
            intXTANA_BLOCK_Memory = intHikiateXTANA_BLOCK

            ''======================================
            ''出庫不可の奥棚ﾁｪｯｸ
            ''======================================
            'If blnOkuHikiate = False Then
            '    '(奥は引当てない場合)
            '    If objOkuPalletIDList.Contains(strHikiateFPALLET_ID) = True Then
            '        '(手前棚に在庫がある為、出庫不可のﾊﾟﾚｯﾄIDﾘｽﾄに存在していた場合)
            '        Continue For
            '    Else
            '        '(手前棚に在庫がある為、出庫不可のﾊﾟﾚｯﾄIDﾘｽﾄに存在していない場合)
            '        objOkuPalletIDList.Add(strHikiateFPALLET_ID)
            '    End If
            'End If
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, "%%%", FLOG_DATA_TRN_SEND_NORMAL, "[" & strHikiateFPALLET_ID & "][" & Format(Now, DATE_FORMAT_99) & "]%出荷引当時間調査ﾛｸﾞ")


            '***********************************************
            '引き当たった在庫のﾄﾗｯｷﾝｸﾞの取得
            '***********************************************
            Dim objTrkFind As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTrkFind.FPALLET_ID = strHikiateFPALLET_ID    'ﾊﾟﾚｯﾄID
            objTrkFind.GET_TPRG_TRK_BUF()                   '取得


            '***********************************************
            '関連するﾌﾞﾛｯｸ棚の取得
            '***********************************************
            Dim objTrkRelation() As TBL_TPRG_TRK_BUF = Nothing                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            Dim objStockFind As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)          '在庫情報
            Dim objStockRelation() As TBL_TRST_STOCK = Nothing                      '在庫情報
            Call GetTPRG_TRK_BUF_Relation(objTrkFind, objTrkRelation, objStockFind, objStockRelation)


            '**********************************************************************************************
            '前棚奇数→前棚偶数→奥棚奇数→奥棚偶数    の順番で引当て直す
            '**********************************************************************************************
            intRet = ZaikoHikiateBlockHikiate(strAryFinalPALLET_ID _
                                            , objTMST_ITEM _
                                            , blnOkuHikiate _
                                            , blnHasuHikiate _
                                            , blnHasuBlockHikiate _
                                            , objTrkRelation _
                                            , objStockRelation _
                                            )
            If intRet = RetCode.OK Then Return intRet


        Next


        Return intReturn
    End Function
#End Region
#Region "  在庫引当処理(ﾌﾞﾛｯｸ単位で引当てる)                                                        "
    '''**********************************************************************************************
    ''' <summary>
    ''' 在庫引当処理(ﾌﾞﾛｯｸ単位で引当てる)
    ''' </summary>
    ''' <param name="objSVR_100202">在庫引当ｸﾗｽ</param>
    ''' <param name="strAryFinalPALLET_ID">ﾀﾞﾌﾞﾙﾃﾞｨｰﾌﾟも考慮して引当てたﾊﾟﾚｯﾄID配列</param>
    ''' <param name="objTMST_ITEM">品目ﾏｽﾀ</param>
    ''' <param name="blnOkuHikiate">手前棚が予約されていても、奥棚を引当てるか否か</param>
    ''' <param name="intPairOrSingle">ﾍﾟｱ or ｼﾝｸﾞﾙ</param>
    ''' <param name="objOkuPalletIDList">手前棚に在庫がある為、出庫不可のﾊﾟﾚｯﾄIDﾘｽﾄ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function ZaikoHikiatePair(ByVal objSVR_100202 As SVR_100202 _
                                   , ByRef strAryFinalPALLET_ID() As String _
                                   , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                   , ByVal blnOkuHikiate As Boolean _
                                   , ByVal intPairOrSingle As PairOrSingle _
                                   , ByRef objOkuPalletIDList As ArrayList _
                                   ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        Dim intRet As RetCode


        '************************************************************************************************
        '************************************************************************************************
        'ﾌﾞﾛｯｸ処理
        '************************************************************************************************
        '************************************************************************************************
        Dim intXTANA_BLOCK_Memory As Integer = -1       '引当てたﾊﾟﾚｯﾄの棚ﾌﾞﾛｯｸ(記憶)
        For ii As Integer = 0 To UBound(objSVR_100202.strArrayPALLET_ID)
            '(ﾙｰﾌﾟ:引き当たったﾊﾟﾚｯﾄ数)


            '***********************************************
            '初期設定
            '***********************************************
            Dim strHikiateFPALLET_ID As String = objSVR_100202.strArrayPALLET_ID(ii)                    '仮に引き当たったﾊﾟﾚｯﾄID
            Dim intHikiateXTANA_BLOCK As Integer = TO_INTEGER(objSVR_100202.intAryXTANA_BLOCK(ii))      '仮に引き当たったﾊﾟﾚｯﾄIDの棚ﾌﾞﾛｯｸ


            '***********************************************
            '処理時間短縮ﾁｪｯｸ
            '***********************************************
            '======================================
            '棚ﾌﾞﾛｯｸﾁｪｯｸ
            '======================================
            If intXTANA_BLOCK_Memory = intHikiateXTANA_BLOCK Then Continue For
            intXTANA_BLOCK_Memory = intHikiateXTANA_BLOCK

            ''======================================
            ''出庫不可の奥棚ﾁｪｯｸ
            ''======================================
            'If blnOkuHikiate = False Then
            '    '(奥は引当てない場合)
            '    If objOkuPalletIDList.Contains(strHikiateFPALLET_ID) = True Then
            '        '(手前棚に在庫がある為、出庫不可のﾊﾟﾚｯﾄIDﾘｽﾄに存在していた場合)
            '        Continue For
            '    Else
            '        '(手前棚に在庫がある為、出庫不可のﾊﾟﾚｯﾄIDﾘｽﾄに存在していない場合)
            '        objOkuPalletIDList.Add(strHikiateFPALLET_ID)
            '    End If
            'End If
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, "bbb", FLOG_DATA_TRN_SEND_NORMAL, "[" & strHikiateFPALLET_ID & "][" & Format(Now, DATE_FORMAT_99) & "]b出荷引当時間調査ﾛｸﾞ")


            '***********************************************
            '引き当たった在庫のﾄﾗｯｷﾝｸﾞの取得
            '***********************************************
            Dim objTrkFind As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTrkFind.FPALLET_ID = strHikiateFPALLET_ID    'ﾊﾟﾚｯﾄID
            objTrkFind.GET_TPRG_TRK_BUF()                   '取得


            '***********************************************
            '関連するﾌﾞﾛｯｸ棚の取得
            '***********************************************
            Dim objTrkRelation() As TBL_TPRG_TRK_BUF = Nothing                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            Dim objStockFind As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)          '在庫情報
            Dim objStockRelation() As TBL_TRST_STOCK = Nothing                      '在庫情報
            Call GetTPRG_TRK_BUF_Relation(objTrkFind, objTrkRelation, objStockFind, objStockRelation)


            '***********************************************
            '端数ﾌﾞﾛｯｸ判定
            '***********************************************
            Dim blnPairBlock As Boolean = False     'ﾍﾟｱ出庫ﾌﾞﾛｯｸか否かのﾌﾗｸﾞ
            blnPairBlock = ZaikoHikiateBlockHasuBlockHantei(objTMST_ITEM, objTrkRelation, objStockRelation)



            If intPairOrSingle = PairOrSingle.intSingle Then
                '(ｼﾝｸﾞﾙの場合)
                '(ﾍﾟｱ出庫ﾌﾞﾛｯｸは引当てない)


                If blnPairBlock = False Then
                    '(ﾍﾟｱ出庫ﾌﾞﾛｯｸは引当てない)


                    '**********************************************************************************************
                    '前棚奇数→前棚偶数→奥棚奇数→奥棚偶数    の順番で引当て直す
                    '**********************************************************************************************
                    intRet = ZaikoHikiateBlockHikiate(strAryFinalPALLET_ID _
                                                    , objTMST_ITEM _
                                                    , blnOkuHikiate _
                                                    , False _
                                                    , True _
                                                    , objTrkRelation _
                                                    , objStockRelation _
                                                    )
                    If intRet = RetCode.OK Then Return intRet


                End If


            Else
                '(ﾍﾟｱの場合)
                '(ﾍﾟｱ出庫ﾌﾞﾛｯｸのみ引当てる)


                If blnPairBlock = True Then
                    '(ﾍﾟｱ出庫ﾌﾞﾛｯｸのみ引当てる)


                    '**********************************************************************************************
                    '前棚奇数→前棚偶数→奥棚奇数→奥棚偶数    の順番で引当て直す
                    '**********************************************************************************************
                    intRet = ZaikoHikiateBlockHikiate(strAryFinalPALLET_ID _
                                                    , objTMST_ITEM _
                                                    , blnOkuHikiate _
                                                    , False _
                                                    , False _
                                                    , objTrkRelation _
                                                    , objStockRelation _
                                                    )
                    If intRet = RetCode.OK Then Return intRet


                End If


            End If


        Next


        Return intReturn
    End Function
#End Region
#Region "  在庫引当処理(ﾌﾞﾛｯｸ内での在庫引当処理)        (内部関数)                                  "
    '''**********************************************************************************************
    ''' <summary>
    ''' 在庫引当処理(ﾌﾞﾛｯｸ内での在庫引当処理)        (内部関数)
    ''' </summary>
    ''' <param name="strAryFinalPALLET_ID">ﾀﾞﾌﾞﾙﾃﾞｨｰﾌﾟも考慮して引当てたﾊﾟﾚｯﾄID配列</param>
    ''' <param name="objTMST_ITEM">品目ﾏｽﾀ</param>
    ''' <param name="blnOkuHikiate">手前棚が予約されていても、奥棚を引当てるか否か</param>
    ''' <param name="blnHasuHikiate">端数PLは引当対象とするか否か</param>
    ''' <param name="blnHasuBlockHikiate">端数ﾌﾞﾛｯｸは引当対象とするか否か</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function ZaikoHikiateBlockHikiate(ByRef strAryFinalPALLET_ID() As String _
                                            , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                            , ByVal blnOkuHikiate As Boolean _
                                            , ByVal blnHasuHikiate As Boolean _
                                            , ByVal blnHasuBlockHikiate As Boolean _
                                            , ByVal objTrkRelation() As TBL_TPRG_TRK_BUF _
                                            , ByVal objStockRelation() As TBL_TRST_STOCK _
                                            ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        'Dim intRet As RetCode
        Dim intAryCount As Integer = 0          '引当てたﾊﾟﾚｯﾄのｶｳﾝﾄ


        '**********************************************************************************************
        '前棚偶数→前棚奇数→奥棚偶数→奥棚奇数    の順番で引当て直す
        '**********************************************************************************************
        '===============================================
        '前棚偶数
        '===============================================
        If IsNotNull(objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID) And objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SZAIKO Then
            '(在庫棚の場合)
            If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.MAE_EVN).ARYME(0).FTR_VOL Then
                '(端数PLを引当てる or 満数PLの場合)
                strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID        '引当てる
                intAryCount += 1                                                                            'ｶｳﾝﾄｱｯﾌﾟ
                'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[出荷引当][ﾊﾟﾚｯﾄID:" & objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID & "][棚番:" & objTrkRelation(RelationArray.MAE_EVN).FDISP_ADDRESS & "][" & strLogMsg & "]")
                If UBound(strAryFinalPALLET_ID) < intAryCount Then
                    '(必要数量引当てた場合)
                    Return RetCode.OK
                End If
            Else
                '(端数PLで、端数PLを引当対象としない場合)
                If blnHasuBlockHikiate = False Then
                    '(端数ﾌﾞﾛｯｸを引当対象とするか否か)
                    Return RetCode.NotFound
                End If
            End If
        End If

        '===============================================
        '前棚奇数
        '===============================================
        If IsNotNull(objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID) And objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SZAIKO Then
            '(在庫棚の場合)
            If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.MAE_ODD).ARYME(0).FTR_VOL Then
                '(端数PLを引当てる or 満数PLの場合)
                strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID        '引当てる
                intAryCount += 1                                                                            'ｶｳﾝﾄｱｯﾌﾟ
                'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[出荷引当][ﾊﾟﾚｯﾄID:" & objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID & "][棚番:" & objTrkRelation(RelationArray.MAE_ODD).FDISP_ADDRESS & "][" & strLogMsg & "]")
                If UBound(strAryFinalPALLET_ID) < intAryCount Then
                    '(必要数量引当てた場合)
                    Return RetCode.OK
                End If
            Else
                '(端数PLで、端数PLを引当対象としない場合)
                If blnHasuBlockHikiate = False Then
                    '(端数ﾌﾞﾛｯｸを引当対象とするか否か)
                    Return RetCode.NotFound
                End If
            End If
        End If


        '**********************************************************************************************
        '奥棚引当判定
        '**********************************************************************************************
        If (objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Or objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SAKI) _
       And (objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Or objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SAKI) _
        Then
            '(手前棚が両方とも、搬出予約or空棚の場合)

            If objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT _
            Or objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT _
            Then
                '(手前棚のどちらかが、搬出予約の場合)

                If blnOkuHikiate = False Then
                    '(手前棚両方とも搬出予約の場合に、奥棚を引当てない場合)
                    Return RetCode.NotFound
                End If

            End If

        Else
            '(手前棚のどちらかが、在庫棚or搬入予約or異常棚の場合)
            Return RetCode.NotFound
        End If

        '===============================================
        '奥棚偶数
        '===============================================
        If IsNotNull(objTrkRelation(RelationArray.OKU_EVN).FPALLET_ID) And objTrkRelation(RelationArray.OKU_EVN).FRES_KIND = FRES_KIND_SZAIKO Then
            '(在庫棚の場合)
            If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.OKU_EVN).ARYME(0).FTR_VOL Then
                '(端数PLを引当てる or 満数PLの場合)
                strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.OKU_EVN).FPALLET_ID        '引当てる
                intAryCount += 1                                                                            'ｶｳﾝﾄｱｯﾌﾟ
                'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[出荷引当][ﾊﾟﾚｯﾄID:" & objTrkRelation(RelationArray.OKU_EVN).FPALLET_ID & "][棚番:" & objTrkRelation(RelationArray.OKU_EVN).FDISP_ADDRESS & "][" & strLogMsg & "]")
                If UBound(strAryFinalPALLET_ID) < intAryCount Then
                    '(必要数量引当てた場合)
                    Return RetCode.OK
                End If
            Else
                '(端数PLで、端数PLを引当対象としない場合)
                If blnHasuBlockHikiate = False Then
                    '(端数ﾌﾞﾛｯｸを引当対象とするか否か)
                    Return RetCode.NotFound
                End If
            End If
        End If

        '===============================================
        '奥棚奇数
        '===============================================
        If IsNotNull(objTrkRelation(RelationArray.OKU_ODD).FPALLET_ID) And objTrkRelation(RelationArray.OKU_ODD).FRES_KIND = FRES_KIND_SZAIKO Then
            '(在庫棚の場合)
            If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.OKU_ODD).ARYME(0).FTR_VOL Then
                '(端数PLを引当てる or 満数PLの場合)
                strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.OKU_ODD).FPALLET_ID        '引当てる
                intAryCount += 1                                                                            'ｶｳﾝﾄｱｯﾌﾟ
                'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[出荷引当][ﾊﾟﾚｯﾄID:" & objTrkRelation(RelationArray.OKU_ODD).FPALLET_ID & "][棚番:" & objTrkRelation(RelationArray.OKU_ODD).FDISP_ADDRESS & "][" & strLogMsg & "]")
                If UBound(strAryFinalPALLET_ID) < intAryCount Then
                    '(必要数量引当てた場合)
                    Return RetCode.OK
                End If
            Else
                '(端数PLで、端数PLを引当対象としない場合)
                If blnHasuBlockHikiate = False Then
                    '(端数ﾌﾞﾛｯｸを引当対象とするか否か)
                    Return RetCode.NotFound
                End If
            End If
        End If


        Return intReturn
    End Function
#End Region
#Region "  在庫引当処理(ﾌﾞﾛｯｸ内での在庫引当処理)        (内部関数)2013/08/12 Backup                 "
    ''''**********************************************************************************************
    '''' <summary>
    '''' 在庫引当処理(ﾌﾞﾛｯｸ内での在庫引当処理)        (内部関数)
    '''' </summary>
    '''' <param name="strAryFinalPALLET_ID">ﾀﾞﾌﾞﾙﾃﾞｨｰﾌﾟも考慮して引当てたﾊﾟﾚｯﾄID配列</param>
    '''' <param name="objTMST_ITEM">品目ﾏｽﾀ</param>
    '''' <param name="blnOkuHikiate">手前棚が予約されていても、奥棚を引当てるか否か</param>
    '''' <param name="blnHasuHikiate">端数PLは引当対象とするか否か</param>
    '''' <param name="blnHasuBlockHikiate">端数ﾌﾞﾛｯｸは引当対象とするか否か</param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    ''''**********************************************************************************************
    'Private Function ZaikoHikiateBlockHikiate(ByRef strAryFinalPALLET_ID() As String _
    '                                        , ByVal objTMST_ITEM As TBL_TMST_ITEM _
    '                                        , ByVal blnOkuHikiate As Boolean _
    '                                        , ByVal blnHasuHikiate As Boolean _
    '                                        , ByVal blnHasuBlockHikiate As Boolean _
    '                                        , ByVal objTrkRelation() As TBL_TPRG_TRK_BUF _
    '                                        , ByVal objStockRelation() As TBL_TRST_STOCK _
    '                                        ) As RetCode
    '    Dim intReturn As RetCode = RetCode.OK
    '    'Dim strMsg As String
    '    'Dim intRet As RetCode
    '    Dim intAryCount As Integer = 0          '引当てたﾊﾟﾚｯﾄのｶｳﾝﾄ


    '    '**********************************************************************************************
    '    '前棚奇数→前棚偶数→奥棚奇数→奥棚偶数    の順番で引当て直す
    '    '**********************************************************************************************
    '    '===============================================
    '    '前棚奇数
    '    '===============================================
    '    If IsNotNull(objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID) And objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SZAIKO Then
    '        '(在庫棚の場合)
    '        If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.MAE_ODD).ARYME(0).FTR_VOL Then
    '            '(端数PLを引当てる or 満数PLの場合)
    '            strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID        '引当てる
    '            intAryCount += 1                                                                            'ｶｳﾝﾄｱｯﾌﾟ
    '            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[出荷引当][ﾊﾟﾚｯﾄID:" & objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID & "][棚番:" & objTrkRelation(RelationArray.MAE_ODD).FDISP_ADDRESS & "][" & strLogMsg & "]")
    '            If UBound(strAryFinalPALLET_ID) < intAryCount Then
    '                '(必要数量引当てた場合)
    '                Return RetCode.OK
    '            End If
    '        Else
    '            '(端数PLで、端数PLを引当対象としない場合)
    '            If blnHasuBlockHikiate = False Then
    '                '(端数ﾌﾞﾛｯｸを引当対象とするか否か)
    '                Return RetCode.NotFound
    '            End If
    '        End If
    '    End If

    '    '===============================================
    '    '前棚偶数
    '    '===============================================
    '    If IsNotNull(objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID) And objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SZAIKO Then
    '        '(在庫棚の場合)
    '        If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.MAE_EVN).ARYME(0).FTR_VOL Then
    '            '(端数PLを引当てる or 満数PLの場合)
    '            strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID        '引当てる
    '            intAryCount += 1                                                                            'ｶｳﾝﾄｱｯﾌﾟ
    '            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[出荷引当][ﾊﾟﾚｯﾄID:" & objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID & "][棚番:" & objTrkRelation(RelationArray.MAE_EVN).FDISP_ADDRESS & "][" & strLogMsg & "]")
    '            If UBound(strAryFinalPALLET_ID) < intAryCount Then
    '                '(必要数量引当てた場合)
    '                Return RetCode.OK
    '            End If
    '        Else
    '            '(端数PLで、端数PLを引当対象としない場合)
    '            If blnHasuBlockHikiate = False Then
    '                '(端数ﾌﾞﾛｯｸを引当対象とするか否か)
    '                Return RetCode.NotFound
    '            End If
    '        End If
    '    End If


    '    '**********************************************************************************************
    '    '奥棚引当判定
    '    '**********************************************************************************************
    '    If (objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Or objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SAKI) _
    '   And (objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Or objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SAKI) _
    '    Then
    '        '(手前棚が両方とも、搬出予約or空棚の場合)

    '        If objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT _
    '        Or objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT _
    '        Then
    '            '(手前棚のどちらかが、搬出予約の場合)

    '            If blnOkuHikiate = False Then
    '                '(手前棚両方とも搬出予約の場合に、奥棚を引当てない場合)
    '                Return RetCode.NotFound
    '            End If

    '        End If

    '    Else
    '        '(手前棚のどちらかが、在庫棚or搬入予約or異常棚の場合)
    '        Return RetCode.NotFound
    '    End If

    '    '===============================================
    '    '奥棚奇数
    '    '===============================================
    '    If IsNotNull(objTrkRelation(RelationArray.OKU_ODD).FPALLET_ID) And objTrkRelation(RelationArray.OKU_ODD).FRES_KIND = FRES_KIND_SZAIKO Then
    '        '(在庫棚の場合)
    '        If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.OKU_ODD).ARYME(0).FTR_VOL Then
    '            '(端数PLを引当てる or 満数PLの場合)
    '            strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.OKU_ODD).FPALLET_ID        '引当てる
    '            intAryCount += 1                                                                            'ｶｳﾝﾄｱｯﾌﾟ
    '            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[出荷引当][ﾊﾟﾚｯﾄID:" & objTrkRelation(RelationArray.OKU_ODD).FPALLET_ID & "][棚番:" & objTrkRelation(RelationArray.OKU_ODD).FDISP_ADDRESS & "][" & strLogMsg & "]")
    '            If UBound(strAryFinalPALLET_ID) < intAryCount Then
    '                '(必要数量引当てた場合)
    '                Return RetCode.OK
    '            End If
    '        Else
    '            '(端数PLで、端数PLを引当対象としない場合)
    '            If blnHasuBlockHikiate = False Then
    '                '(端数ﾌﾞﾛｯｸを引当対象とするか否か)
    '                Return RetCode.NotFound
    '            End If
    '        End If
    '    End If

    '    '===============================================
    '    '奥棚偶数
    '    '===============================================
    '    If IsNotNull(objTrkRelation(RelationArray.OKU_EVN).FPALLET_ID) And objTrkRelation(RelationArray.OKU_EVN).FRES_KIND = FRES_KIND_SZAIKO Then
    '        '(在庫棚の場合)
    '        If blnHasuHikiate = True Or objTMST_ITEM.FNUM_IN_PALLET = objStockRelation(RelationArray.OKU_EVN).ARYME(0).FTR_VOL Then
    '            '(端数PLを引当てる or 満数PLの場合)
    '            strAryFinalPALLET_ID(intAryCount) = objTrkRelation(RelationArray.OKU_EVN).FPALLET_ID        '引当てる
    '            intAryCount += 1                                                                            'ｶｳﾝﾄｱｯﾌﾟ
    '            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "[出荷引当][ﾊﾟﾚｯﾄID:" & objTrkRelation(RelationArray.OKU_EVN).FPALLET_ID & "][棚番:" & objTrkRelation(RelationArray.OKU_EVN).FDISP_ADDRESS & "][" & strLogMsg & "]")
    '            If UBound(strAryFinalPALLET_ID) < intAryCount Then
    '                '(必要数量引当てた場合)
    '                Return RetCode.OK
    '            End If
    '        Else
    '            '(端数PLで、端数PLを引当対象としない場合)
    '            If blnHasuBlockHikiate = False Then
    '                '(端数ﾌﾞﾛｯｸを引当対象とするか否か)
    '                Return RetCode.NotFound
    '            End If
    '        End If
    '    End If


    '    Return intReturn
    'End Function
#End Region
#Region "  在庫引当処理(端数ﾌﾞﾛｯｸ判定)                  (内部関数)                                  "
    '''**********************************************************************************************
    ''' <summary>
    ''' 在庫引当処理(端数ﾌﾞﾛｯｸ判定)                  (内部関数)
    ''' </summary>
    ''' <param name="objTMST_ITEM">品目ﾏｽﾀ</param>
    ''' <returns>
    ''' ﾍﾟｱ出庫ﾌﾞﾛｯｸか否かのﾌﾗｸﾞ
    ''' True:満数ﾌﾞﾛｯｸ
    ''' False:端数ﾌﾞﾛｯｸ
    ''' </returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function ZaikoHikiateBlockHasuBlockHantei(ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                            , ByVal objTrkRelation() As TBL_TPRG_TRK_BUF _
                                            , ByVal objStockRelation() As TBL_TRST_STOCK _
                                            ) _
                                            As Boolean
        'Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        'Dim intRet As RetCode


        '***********************************************
        '在庫引当状態       取得
        '***********************************************
        Dim intFRES_KIND_MAE_ODD As Integer = objTrkRelation(RelationArray.MAE_ODD).FRES_KIND
        Dim intFRES_KIND_MAE_EVN As Integer = objTrkRelation(RelationArray.MAE_EVN).FRES_KIND
        Dim intFRES_KIND_OKU_ODD As Integer = objTrkRelation(RelationArray.OKU_ODD).FRES_KIND
        Dim intFRES_KIND_OKU_EVN As Integer = objTrkRelation(RelationArray.OKU_EVN).FRES_KIND


        '***********************************************
        'ﾊﾟﾚｯﾄID            取得
        '***********************************************
        Dim strFPALLET_ID_MAE_ODD As String = objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID
        Dim strFPALLET_ID_MAE_EVN As String = objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID
        Dim strFPALLET_ID_OKU_ODD As String = objTrkRelation(RelationArray.OKU_ODD).FPALLET_ID
        Dim strFPALLET_ID_OKU_EVN As String = objTrkRelation(RelationArray.OKU_EVN).FPALLET_ID


        '**********************************************************************************************
        '**********************************************************************************************
        '端数ﾌﾞﾛｯｸ判定
        '**********************************************************************************************
        '**********************************************************************************************
        Dim blnPairBlock As Boolean = False         'ﾍﾟｱ出庫ﾌﾞﾛｯｸか否かのﾌﾗｸﾞ
        If (IsNotNull(strFPALLET_ID_MAE_ODD) And IsNotNull(strFPALLET_ID_MAE_EVN) And IsNotNull(strFPALLET_ID_OKU_ODD) And IsNotNull(strFPALLET_ID_OKU_EVN)) _
           Or _
           (IsNull(strFPALLET_ID_MAE_ODD) And IsNull(strFPALLET_ID_MAE_EVN) And IsNotNull(strFPALLET_ID_OKU_ODD) And IsNotNull(strFPALLET_ID_OKU_EVN)) _
           Then
            '(4つともﾊﾟﾚｯﾄIDが存在する or 奥棚2つだけﾊﾟﾚｯﾄIDが存在する場合)


            '***********************************************
            '在庫引当情報           判定
            '***********************************************
            Dim blnTempHasuBlock As Boolean = False         '端数ﾌﾞﾛｯｸ検知ﾌﾗｸﾞ
            If (intFRES_KIND_MAE_ODD = FRES_KIND_SZAIKO And intFRES_KIND_MAE_EVN = FRES_KIND_SZAIKO And intFRES_KIND_OKU_ODD = FRES_KIND_SZAIKO And intFRES_KIND_OKU_EVN = FRES_KIND_SZAIKO) _
               Or _
               (intFRES_KIND_MAE_ODD = FRES_KIND_SAKI And intFRES_KIND_MAE_EVN = FRES_KIND_SAKI And intFRES_KIND_OKU_ODD = FRES_KIND_SZAIKO And intFRES_KIND_OKU_EVN = FRES_KIND_SZAIKO) _
               Or _
               (intFRES_KIND_MAE_ODD = FRES_KIND_SRSV_TRNS_OUT And intFRES_KIND_MAE_EVN = FRES_KIND_SRSV_TRNS_OUT And intFRES_KIND_OKU_ODD = FRES_KIND_SZAIKO And intFRES_KIND_OKU_EVN = FRES_KIND_SZAIKO) _
               Then
                '(   全て在庫棚の場合)
                '(or 前棚が空棚、奥棚が在庫棚の場合)
                '(or 前棚が出庫予約棚、奥棚が在庫棚の場合)
                blnTempHasuBlock = False
            Else
                '(それ以外の場合)
                blnTempHasuBlock = True
            End If


            '***********************************************
            '端数ﾊﾟﾚｯﾄ              判定
            '***********************************************
            Dim blnTempHasuZaiko As Boolean = False     '端数ﾌﾞﾛｯｸ検知ﾌﾗｸﾞ
            If IsNotNull(objStockRelation(RelationArray.MAE_ODD)) Then If objStockRelation(RelationArray.MAE_ODD).ARYME(0).FTR_VOL <> objTMST_ITEM.FNUM_IN_PALLET Then blnTempHasuZaiko = True
            If IsNotNull(objStockRelation(RelationArray.MAE_EVN)) Then If objStockRelation(RelationArray.MAE_EVN).ARYME(0).FTR_VOL <> objTMST_ITEM.FNUM_IN_PALLET Then blnTempHasuZaiko = True
            If IsNotNull(objStockRelation(RelationArray.OKU_ODD)) Then If objStockRelation(RelationArray.OKU_ODD).ARYME(0).FTR_VOL <> objTMST_ITEM.FNUM_IN_PALLET Then blnTempHasuZaiko = True
            If IsNotNull(objStockRelation(RelationArray.OKU_EVN)) Then If objStockRelation(RelationArray.OKU_EVN).ARYME(0).FTR_VOL <> objTMST_ITEM.FNUM_IN_PALLET Then blnTempHasuZaiko = True

            If blnTempHasuBlock = False And blnTempHasuZaiko = False Then
                '(端数ﾌﾞﾛｯｸ検知なし and 端数在庫検知なし の場合)
                blnPairBlock = True
            End If

        End If


        Return blnPairBlock
    End Function
#End Region

    '積込完了
#Region "  積込完了                                                                                 "
    '''**********************************************************************************************
    ''' <summary>
    ''' 積込完了
    ''' </summary>
    ''' <param name="strXDSPBERTH_NO">ﾊﾞｰｽ№</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function TumikomiKanryou(ByVal strXDSPBERTH_NO As String _
                                  , ByVal dtmXDSPSYUKKA_D As Nullable(Of Date) _
                                  , ByVal strXDSPHENSEI_NO_OYA As String _
                                  ) As RetCode
        Dim intReturn As RetCode = RetCode.OK
        Dim strMsg As String
        Dim intRet As RetCode


        '***********************************************
        '初期設定
        '***********************************************
        Dim strFPLAN_KEY As String = Nothing                '計画ｷｰ


        '***********************************************
        '出荷ﾊﾞｰｽ状況               取得
        '***********************************************
        Dim objXSTS_BERTH As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)
        objXSTS_BERTH.XBERTH_NO = strXDSPBERTH_NO               'ﾊﾞｰｽNo.
        objXSTS_BERTH.GET_XSTS_BERTH()                          '取得


        '**********************************************************************************************
        '**********************************************************************************************
        'ﾄﾗｯｷﾝｸﾞ完了
        '**********************************************************************************************
        '**********************************************************************************************
        '***********************************************
        '出荷ｺﾝﾍﾞﾔ状況              取得
        '***********************************************
        Dim objAryXSTS_CONVEYOR As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)
        objAryXSTS_CONVEYOR.XBERTH_GROUP = objXSTS_BERTH.XBERTH_GROUP      'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
        intRet = objAryXSTS_CONVEYOR.GET_XSTS_CONVEYOR_ANY()               '取得
        If intRet <> RetCode.OK Then Throw New Exception(ERRMSG_NOTFOUND_XSTS_CONVEYOR & "[ﾊﾞｰｽｸﾞﾙｰﾌﾟ:" & objAryXSTS_CONVEYOR.XBERTH_GROUP & "]")
        For Each objXSTS_CONVEYOR As TBL_XSTS_CONVEYOR In objAryXSTS_CONVEYOR.ARYME
            '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


            '***********************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ST)           取得
            '***********************************************
            Dim objAryTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objAryTPRG_TRK_BUF_ST.FTRK_BUF_NO = objXSTS_CONVEYOR.XSTNO     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            intRet = objAryTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF_FIFO(True)     '取得
            If intRet = RetCode.OK Then
                '(見つかった場合)
                For Each objTPRG_TRK_BUF_ST As TBL_TPRG_TRK_BUF In objAryTPRG_TRK_BUF_ST.ARYME
                    '(ﾙｰﾌﾟ:搬送中のﾄﾗｯｷﾝｸﾞ数)


                    '**************************************
                    '在庫情報               取得
                    '**************************************
                    Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                    objTRST_STOCK.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID        'ﾊﾟﾚｯﾄID
                    objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)                       '取得


                    '**************************************
                    '在庫引当情報           取得
                    '**************************************
                    Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
                    objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID      'ﾊﾟﾚｯﾄID
                    objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET()                       '取得
                    strFPLAN_KEY = objTSTS_HIKIATE.FPLAN_KEY                        '計画ｷｰ


                    Dim intFSAGYOU_KIND As Integer = objTSTS_HIKIATE.FSAGYOU_KIND
                    If objTRST_STOCK.ARYME(0).FTR_VOL <= objTSTS_HIKIATE.FTR_VOL Then
                        '(全て引き当たっている場合)


                        '************************************************************************
                        'ﾄﾗｯｷﾝｸﾞ,在庫情報,その他ﾊﾟﾚｯﾄに関係する情報全て削除
                        '************************************************************************
                        Call ClearDustProcess(objTPRG_TRK_BUF_ST.FPALLET_ID)


                        '************************
                        '在庫削除
                        '************************
                        Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '在庫削除ｸﾗｽ
                        objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_ST          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                        objSVR_100102.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID    'ﾊﾟﾚｯﾄID
                        'objSVR_100102.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK   '在庫ﾛｯﾄ№
                        objSVR_100102.FINOUT_STS = FINOUT_STS_JTUMI_END             'INOUT
                        objSVR_100102.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '作業種別
                        objSVR_100102.STOCK_DELETE()                                '削除


                    Else
                        '(全て引き当たっていない場合)


                        '************************************************************************
                        '在庫情報               更新
                        '************************************************************************
                        For ii As Integer = 0 To UBound(objTRST_STOCK.ARYME)
                            '(ﾙｰﾌﾟ:在庫ﾛｯﾄ№数)

                            objTRST_STOCK.ARYME(ii).FTR_VOL = objTRST_STOCK.ARYME(ii).FTR_VOL - objTSTS_HIKIATE.FTR_VOL         '搬送管理量
                            objTRST_STOCK.ARYME(ii).FTR_RES_VOL = 0             '搬送引当量
                            objTRST_STOCK.ARYME(ii).FUPDATE_DT = Now            '更新日時
                            objTRST_STOCK.ARYME(ii).UPDATE_TRST_STOCK_ALL()     '更新

                        Next


                        '************************************************
                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(平置)         取得
                        '************************************************
                        Dim objTPRG_TRK_BUF_HIRA As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        objTPRG_TRK_BUF_HIRA.FTRK_BUF_NO = FTRK_BUF_NO_J9100            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        intRet = objTPRG_TRK_BUF_HIRA.GET_TPRG_TRK_BUF_AKI_HIRA()       '取得
                        If intRet <> RetCode.OK Then
                            '(見つからない場合)
                            strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_HIRA.FTRK_BUF_NO) & "]"
                            Throw New UserException(strMsg)
                        End If


                        '************************
                        '在庫移動
                        '************************
                        Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog)         '在庫移動ｸﾗｽ
                        objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_ST               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                        objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_HIRA             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                        objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID            'ﾊﾟﾚｯﾄID
                        objSVR_100103.FINOUT_STS = FINOUT_STS_JTUMI_END                     'INOUT
                        objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND           '作業種別
                        objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                            '搬送元ｸﾘｱﾌﾗｸﾞ
                        objSVR_100103.STOCK_TRNS()                                          '移動


                        '************************************************************************
                        'ﾄﾗｯｷﾝｸﾞ,在庫情報,その他ﾊﾟﾚｯﾄに関係する情報全て削除
                        '************************************************************************
                        Call ClearDustProcess(objTPRG_TRK_BUF_HIRA.FPALLET_ID)


                    End If


                Next
            End If


        Next


        '************************************************
        '車番表示               OFF
        '編成№                 OFF
        '出庫完了ﾗﾝﾌﾟ           OFF
        '************************************************
        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
        Call objSVR_190001.SendYasukawa_IDDispSyaban(objXSTS_BERTH.XBERTH_GROUP, FLAG_OFF)
        Call objSVR_190001.SendYasukawa_IDDispHensei(objXSTS_BERTH.XBERTH_GROUP, FLAG_OFF)
        Call objSVR_190001.SendYasukawa_IDDispOutEnd(objXSTS_BERTH.XBERTH_GROUP, FLAG_OFF)


        '**************************************************
        'ｶｰﾄﾞﾘｰﾀﾞ読取完了ﾋﾞｯﾄ           OFF
        '**************************************************
        Select Case objXSTS_BERTH.XBERTH_NO
            Case XBERTH_NO_JX01, XBERTH_NO_JX02, XBERTH_NO_JX03
                '============================================
                'ｶｰﾄﾞﾘｰﾀﾞ読取完了           OFF
                '============================================
                Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_15, FTEXT_ID_JW_ETC, FLAG_OFF)
                Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_14, FTEXT_ID_JW_ETC, FLAG_OFF)
                Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_13, FTEXT_ID_JW_ETC, FLAG_OFF)
                ''============================================
                ''ﾁｪｯｸﾎﾟｲﾝﾄ消去可            OFF
                ''============================================
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_15, FTEXT_ID_JW_ETC, FLAG_OFF)
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_14, FTEXT_ID_JW_ETC, FLAG_OFF)
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_13, FTEXT_ID_JW_ETC, FLAG_OFF)
                ''============================================
                ''車輌ｺﾝﾄﾛｰﾗ   表示盤出力
                ''============================================
                'Call objSVR_190001.SendCar_IDJS_CARD02()
            Case XBERTH_NO_JX04, XBERTH_NO_JX05, XBERTH_NO_JX06
                '============================================
                'ｶｰﾄﾞﾘｰﾀﾞ読取完了           OFF
                '============================================
                Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_12, FTEXT_ID_JW_ETC, FLAG_OFF)
                Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_11, FTEXT_ID_JW_ETC, FLAG_OFF)
                Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_10, FTEXT_ID_JW_ETC, FLAG_OFF)
                ''============================================
                ''ﾁｪｯｸﾎﾟｲﾝﾄ消去可            OFF
                ''============================================
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_12, FTEXT_ID_JW_ETC, FLAG_OFF)
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_11, FTEXT_ID_JW_ETC, FLAG_OFF)
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_10, FTEXT_ID_JW_ETC, FLAG_OFF)
                ''============================================
                ''車輌ｺﾝﾄﾛｰﾗ   表示盤出力
                ''============================================
                'Call objSVR_190001.SendCar_IDJS_CARD02()
        End Select


        '**********************************************************************************************
        '**********************************************************************************************
        '出荷指示完了
        '**********************************************************************************************
        '**********************************************************************************************
        '************************************************
        '出荷指示詳細(計画ｷｰ)                   取得
        '************************************************
        Dim objXPLN_OUT_DTL01 As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
        If (IsNotNull(dtmXDSPSYUKKA_D) And IsNotNull(strXDSPHENSEI_NO_OYA)) _
           Or (IsNotNull(strFPLAN_KEY)) _
           Then
            objXPLN_OUT_DTL01.XSYUKKA_D = dtmXDSPSYUKKA_D               '出荷日
            objXPLN_OUT_DTL01.XHENSEI_NO_OYA = strXDSPHENSEI_NO_OYA     '親編成No.
        Else
            objXPLN_OUT_DTL01.FPLAN_KEY = strFPLAN_KEY                  '計画ｷｰ
        End If
        intRet = objXPLN_OUT_DTL01.GET_XPLN_OUT_DTL_ANY()               '取得
        If intRet <> RetCode.OK Then Throw New System.Exception(ERRMSG_NOTFOUND_XPLN_OUT & "[出荷日:" & objXPLN_OUT_DTL01.XSYUKKA_D & "][親編成No.:" & objXPLN_OUT_DTL01.XHENSEI_NO_OYA & "][計画ｷｰ:" & objXPLN_OUT_DTL01.FPLAN_KEY & "]")


        '************************************************
        '出荷指示詳細(出荷日、親編成№)         取得
        '************************************************
        Dim objAryXPLN_OUT_DTL02 As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
        objAryXPLN_OUT_DTL02.XSYUKKA_D = objXPLN_OUT_DTL01.ARYME(0).XSYUKKA_D               '出荷日
        objAryXPLN_OUT_DTL02.XHENSEI_NO_OYA = objXPLN_OUT_DTL01.ARYME(0).XHENSEI_NO_OYA     '親編成No.
        intRet = objAryXPLN_OUT_DTL02.GET_XPLN_OUT_DTL_ANY()                                '取得
        If intRet <> RetCode.OK Then Throw New System.Exception(ERRMSG_NOTFOUND_XPLN_OUT & "[出荷日:" & objAryXPLN_OUT_DTL02.XSYUKKA_D & "][親編成No.:" & objAryXPLN_OUT_DTL02.XHENSEI_NO_OYA & "]")
        For ii As Integer = 0 To UBound(objAryXPLN_OUT_DTL02.ARYME)
            '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)

            '=====================================
            '出荷状況詳細       更新
            '=====================================
            objAryXPLN_OUT_DTL02.ARYME(ii).XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JTUMI      '出荷状況詳細
            objAryXPLN_OUT_DTL02.ARYME(ii).UPDATE_XPLN_OUT_DTL()                        '更新

        Next


        '************************************************
        '出荷指示(出荷日、親編成№)         取得
        '************************************************
        Dim objAryXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
        objAryXPLN_OUT.XSYUKKA_D = objXPLN_OUT_DTL01.ARYME(0).XSYUKKA_D             '出荷日
        objAryXPLN_OUT.XHENSEI_NO_OYA = objXPLN_OUT_DTL01.ARYME(0).XHENSEI_NO_OYA   '親編成No.
        intRet = objAryXPLN_OUT.GET_XPLN_OUT_ANY()                                  '取得
        If intRet <> RetCode.OK Then Throw New System.Exception(ERRMSG_NOTFOUND_XPLN_OUT & "[出荷日:" & objAryXPLN_OUT.XSYUKKA_D & "][親編成No.:" & objAryXPLN_OUT.XHENSEI_NO_OYA & "]")
        For ii As Integer = 0 To UBound(objAryXPLN_OUT.ARYME)
            '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)

            '=====================================
            '出荷状況詳細       更新
            '=====================================
            objAryXPLN_OUT.ARYME(ii).XSYUKKA_STS = XSYUKKA_STS_JTUMI        '出荷状況詳細
            If IsNull(objAryXPLN_OUT.ARYME(ii).XTUMI_END_DT) Then objAryXPLN_OUT.ARYME(ii).XTUMI_END_DT = Now '積込完了日時
            objAryXPLN_OUT.ARYME(ii).UPDATE_XPLN_OUT()                      '更新

        Next


        '**********************************************************************************************
        '**********************************************************************************************
        'ﾊﾞｰｽ開放処理
        '**********************************************************************************************
        '**********************************************************************************************
        Dim strSQL As String                    'SQL文

        '-------------------
        '出荷ﾊﾞｰｽ状況読込
        '-------------------
        Dim objXSTS_BERTH_ALL As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)     '出荷ﾊﾞｰｽ状況ｸﾗｽ
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & "    *"
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    XSTS_BERTH"                                     '出荷ﾊﾞｰｽ状況
        strSQL &= vbCrLf & " ORDER BY"
        strSQL &= vbCrLf & "    XBERTH_NO"                                      'ﾊﾞｰｽ№
        strSQL &= vbCrLf
        objXSTS_BERTH_ALL.USER_SQL = strSQL
        objXSTS_BERTH_ALL.GET_XSTS_BERTH_USER()

        '-------------------
        'ﾊﾞｰｽ使用状況更新
        '-------------------
        intRet = Get_Barth_Data(strXDSPBERTH_NO, objXSTS_BERTH_ALL, objXSTS_BERTH)
        objXSTS_BERTH.XSYUKKA_D = DEFAULT_DATE                      '出荷日
        objXSTS_BERTH.XHENSEI_NO = DEFAULT_STRING                   '編成No.
        objXSTS_BERTH.XSYUKKA_D_RIN1 = DEFAULT_DATE                 '隣接1出荷日
        objXSTS_BERTH.XHENSEI_NO_OYA_RIN1 = DEFAULT_STRING          '隣接1親編成No.
        objXSTS_BERTH.XSYUKKA_D_RIN2 = DEFAULT_DATE                 '隣接2出荷日
        objXSTS_BERTH.XHENSEI_NO_OYA_RIN2 = DEFAULT_STRING          '隣接2親編成No.
        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JAKI                  'ﾊﾞｰｽ使用状況
        objXSTS_BERTH.FUPDATE_DT = Now                              '更新日時
        objXSTS_BERTH.UPDATE_XSTS_BERTH()

        If TO_INTEGER(objAryXPLN_OUT.ARYME(0).XTUMI_HOUHOU) = XTUMI_HOUHOU_JL Then
            'ﾛｰﾀﾞ積の場合は、本体ﾊﾞｰｽの開放のみ(横の開放は行わない)
        Else
            Select Case TO_INTEGER(objAryXPLN_OUT.ARYME(0).XTUMI_HOUKOU)
                Case XTUMI_HOUKOU_JBACK         '後積み
                    'NOP
                Case XTUMI_HOUKOU_JSIDE         '片横積み
                    '-------------------
                    '横ﾊﾞｰｽ(上)状態更新
                    '-------------------
                    Dim strBth_Prev = ""
                    intRet = Get_Barth_Prev(strXDSPBERTH_NO, strBth_Prev)
                    intRet = Get_Barth_Data(strBth_Prev, objXSTS_BERTH_ALL, objXSTS_BERTH)
                    objXSTS_BERTH.XSYUKKA_D_RIN2 = DEFAULT_DATE                         '隣接2出荷日
                    objXSTS_BERTH.XHENSEI_NO_OYA_RIN2 = DEFAULT_STRING                  '隣接2親編成No.
                    If objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUPDOWN Then
                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUP                       'ﾊﾞｰｽ使用状況
                    Else
                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JAKI                      'ﾊﾞｰｽ使用状況
                    End If
                    objXSTS_BERTH.FUPDATE_DT = Now                                      '更新日時
                    objXSTS_BERTH.UPDATE_XSTS_BERTH()

                Case XTUMI_HOUKOU_JWING         '両横積み
                    '-------------------
                    '両横ﾊﾞｰｽ(上)状態更新
                    '-------------------
                    Dim strBth_Prev = ""
                    intRet = Get_Barth_Prev(strXDSPBERTH_NO, strBth_Prev)
                    intRet = Get_Barth_Data(strBth_Prev, objXSTS_BERTH_ALL, objXSTS_BERTH)
                    objXSTS_BERTH.XSYUKKA_D_RIN2 = DEFAULT_DATE                         '隣接2出荷日
                    objXSTS_BERTH.XHENSEI_NO_OYA_RIN2 = DEFAULT_STRING                  '隣接2親編成No.
                    If objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUPDOWN Then
                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUP                       'ﾊﾞｰｽ使用状況
                    Else
                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JAKI                      'ﾊﾞｰｽ使用状況
                    End If
                    objXSTS_BERTH.FUPDATE_DT = Now                                      '更新日時
                    objXSTS_BERTH.UPDATE_XSTS_BERTH()

                    '-------------------
                    '両横ﾊﾞｰｽ(下)状態更新
                    '-------------------
                    Dim strBth_Next = ""
                    intRet = Get_Barth_Next(strXDSPBERTH_NO, strBth_Next)
                    intRet = Get_Barth_Data(strBth_Next, objXSTS_BERTH_ALL, objXSTS_BERTH)
                    objXSTS_BERTH.XSYUKKA_D_RIN1 = DEFAULT_DATE                         '隣接1出荷日
                    objXSTS_BERTH.XHENSEI_NO_OYA_RIN1 = DEFAULT_STRING                  '隣接1親編成No.
                    If objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUPDOWN Then
                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JDOWN                     'ﾊﾞｰｽ使用状況
                    Else
                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JAKI                      'ﾊﾞｰｽ使用状況
                    End If
                    objXSTS_BERTH.FUPDATE_DT = Now                                      '更新日時
                    objXSTS_BERTH.UPDATE_XSTS_BERTH()
            End Select
        End If


        '**************************************************
        '車輌ｺﾝﾄﾛｰﾗ   表示盤出力
        '**************************************************
        Select Case objXSTS_BERTH.XBERTH_NO
            Case XBERTH_NO_JX01, XBERTH_NO_JX02, XBERTH_NO_JX03, XBERTH_NO_JX04, XBERTH_NO_JX05, XBERTH_NO_JX06
                '============================================
                '車輌ｺﾝﾄﾛｰﾗ   表示盤出力
                '============================================
                Call objSVR_190001.SendCar_IDJS_CARD02()
        End Select


        Return intReturn
    End Function
#End Region

    '出荷指示、出庫実績詳細　の追加更新
#Region "  出荷指示、出荷指示詳細、出庫実績詳細  の追加更新                                         "
    '''**********************************************************************************************
    ''' <summary>
    ''' 出荷指示、出荷指示詳細、出庫実績詳細  の追加更新
    ''' </summary>
    ''' <param name="objTRST_STOCK">在庫情報</param>
    ''' <param name="objTMST_ITEM">品目ﾏｽﾀ</param>
    ''' <param name="strFPLAN_KEY">計画ｷｰ</param>
    ''' <param name="intHikiateNum">引当数量</param>
    ''' <param name="intFBUF_FM">搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <param name="intFARRAY_FM">搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№</param>
    ''' <param name="intFBUF_TO">搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <param name="intFARRAY_TO">搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№</param>
    ''' <param name="blnHiraoki">平置きか否か</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function SyukkaHikiateHiraokiUpdate(ByVal objTRST_STOCK As TBL_TRST_STOCK _
                                             , ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                             , ByVal strFPLAN_KEY As String _
                                             , ByVal intHikiateNum As Integer _
                                             , ByVal intFBUF_FM As Integer _
                                             , ByVal intFARRAY_FM As Integer _
                                             , ByVal intFBUF_TO As Integer _
                                             , ByVal intFARRAY_TO As Integer _
                                             , ByVal blnHiraoki As Boolean _
                                             ) _
                                             As RetCode
        Dim intReturn As RetCode = RetCode.OK
        'Dim strMsg As String
        Dim intRet As RetCode


        '************************************************************************************************
        '************************************************************************************************
        '出荷指示、出荷指示詳細ﾃｰﾌﾞﾙ            更新
        '************************************************************************************************
        '************************************************************************************************
        '************************************************
        '出荷指示詳細(更新用)           取得
        '************************************************
        Dim objXPLN_OUT_DTL_Update As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
        objXPLN_OUT_DTL_Update.FPLAN_KEY = strFPLAN_KEY                     '計画ｷｰ
        intRet = objXPLN_OUT_DTL_Update.GET_XPLN_OUT_DTL(False)             '取得
        If intRet <> RetCode.OK Then
            Return RetCode.OK
        End If


        '************************************************
        '出荷指示詳細(更新用)           更新
        '************************************************
        objXPLN_OUT_DTL_Update.XSYUKKA_KON_RESULT += intHikiateNum              '出荷実績梱数
        If objXPLN_OUT_DTL_Update.XSYUKKA_KON_PLAN <= objXPLN_OUT_DTL_Update.XSYUKKA_KON_RESULT Then
            '(出荷予定梱数 <= 出荷実績梱数 の場合)
            If objXPLN_OUT_DTL_Update.XSYUKKA_STS_DTL <> XSYUKKA_STS_DTL_JTUMI Then
                '(積込済以外の場合)
                objXPLN_OUT_DTL_Update.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JALL       '出荷状況詳細
            End If
        Else
            If objXPLN_OUT_DTL_Update.XSYUKKA_STS_DTL <> XSYUKKA_STS_DTL_JLESS Then
                '(欠品以外の場合)
                If blnHiraoki = False Then
                    '(平置き以外の場合)
                    If objXPLN_OUT_DTL_Update.XSYUKKA_STS_DTL <> XSYUKKA_STS_DTL_JTUMI Then
                        '(積込済以外の場合)
                        objXPLN_OUT_DTL_Update.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JOUT   '出荷状況詳細
                    End If
                End If
            End If
        End If
        If blnHiraoki Then
            '(平置きの場合)
            objXPLN_OUT_DTL_Update.XSYUKKA_KON_H_RESULT = TO_INTEGER(objXPLN_OUT_DTL_Update.XSYUKKA_KON_H_RESULT) + intHikiateNum
        End If
        objXPLN_OUT_DTL_Update.UPDATE_XPLN_OUT_DTL()                            '更新


        '************************************************
        '出荷指示詳細(ﾁｪｯｸ用)           取得
        '************************************************
        Dim blnXSYUKKA_STS_DTL_JALL As Boolean = False          '全品出庫判定
        Dim objAryXPLN_OUT_DTL_Check As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
        objAryXPLN_OUT_DTL_Check.XSYUKKA_D = objXPLN_OUT_DTL_Update.XSYUKKA_D                   '出荷日
        objAryXPLN_OUT_DTL_Check.XHENSEI_NO_OYA = objXPLN_OUT_DTL_Update.XHENSEI_NO_OYA         '親編成No.
        intRet = objAryXPLN_OUT_DTL_Check.GET_XPLN_OUT_DTL_ANY()                                '取得
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


        '************************************************
        '出荷指示                       取得
        '************************************************
        Dim objAryXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
        objAryXPLN_OUT.XSYUKKA_D = objXPLN_OUT_DTL_Update.XSYUKKA_D            '出荷日
        objAryXPLN_OUT.XHENSEI_NO_OYA = objXPLN_OUT_DTL_Update.XHENSEI_NO_OYA  '親編成No.
        intRet = objAryXPLN_OUT.GET_XPLN_OUT_ANY()                             '取得
        If intRet <> RetCode.OK Then Throw New System.Exception(ERRMSG_NOTFOUND_XPLN_OUT & "[出荷日:" & objAryXPLN_OUT.XSYUKKA_D & "][親編成No.:" & objAryXPLN_OUT.XHENSEI_NO_OYA & "]")


        '************************************************
        '出荷指示                       更新
        '************************************************
        If blnXSYUKKA_STS_DTL_JALL = True Then
            '(全品出庫の場合)
            For ii As Integer = 0 To UBound(objAryXPLN_OUT.ARYME)
                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)

                If objAryXPLN_OUT.ARYME(ii).XSYUKKA_STS <> XSYUKKA_STS_JTUMI Then
                    '(積込済以外の場合)
                    objAryXPLN_OUT.ARYME(ii).XSYUKKA_STS = XSYUKKA_STS_JOUT      '出荷状況
                End If
                If IsNull(objAryXPLN_OUT.ARYME(ii).XOUT_START_DT) Then objAryXPLN_OUT.ARYME(ii).XOUT_START_DT = Now '出庫開始日時
                If IsNull(objAryXPLN_OUT.ARYME(ii).XOUT_END_DT) Then objAryXPLN_OUT.ARYME(ii).XOUT_END_DT = Now '出庫完了日時
                objAryXPLN_OUT.ARYME(ii).UPDATE_XPLN_OUT()                   '更新

            Next


            '************************************************
            '出荷ﾊﾞｰｽ状況           取得
            '************************************************
            Dim objXSTS_BERTH As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)
            objXSTS_BERTH.XBERTH_NO = objAryXPLN_OUT.ARYME(0).XBERTH_NO 'ﾊﾞｰｽ№
            objXSTS_BERTH.GET_XSTS_BERTH()                              '取得


            '************************************************
            '出庫完了ﾗﾝﾌﾟ           ON
            '************************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            Call objSVR_190001.SendYasukawa_IDDispOutEnd(objXSTS_BERTH.XBERTH_GROUP, FLAG_ON)


            ''************************************************
            '' 出荷ｺﾝﾍﾞﾔ状況             取得
            ''************************************************
            'Dim objXSTS_CONVEYOR As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)
            'objXSTS_CONVEYOR.XSTNO = intFBUF_TO                     'STNo.
            'intRet = objXSTS_CONVEYOR.GET_XSTS_CONVEYOR(False)      '取得
            'If intRet = RetCode.OK Then
            '    '(見つかった場合)
            '    '(STの場合)


            '    '************************************************
            '    '出庫完了ﾗﾝﾌﾟ           ON
            '    '************************************************
            '    Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            '    Call objSVR_190001.SendYasukawa_IDDispOutEnd(objXSTS_CONVEYOR.XBERTH_GROUP, FLAG_ON)


            'End If


        End If


        '************************************************************************************************
        '************************************************************************************************
        '出庫実績詳細               追加
        '************************************************************************************************
        '************************************************************************************************
        '************************************************
        '出荷実績詳細                   追加
        '************************************************
        Dim objXRST_OUT_DTL As New TBL_XRST_OUT_DTL(Owner, ObjDb, ObjDbLog)
        objXRST_OUT_DTL.XSYUKKA_D = objXPLN_OUT_DTL_Update.XSYUKKA_D            '出荷日
        objXRST_OUT_DTL.XHENSEI_NO = objXPLN_OUT_DTL_Update.XHENSEI_NO          '編成No.
        objXRST_OUT_DTL.XDENPYOU_NO = objXPLN_OUT_DTL_Update.XDENPYOU_NO        '伝票No.
        objXRST_OUT_DTL.XSYUKKA_RESULT_DT = Now                                 '出荷実績日時
        objXRST_OUT_DTL.FPALLET_ID = objTRST_STOCK.ARYME(0).FPALLET_ID          'ﾊﾟﾚｯﾄID
        objXRST_OUT_DTL.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD          '品目ｺｰﾄﾞ
        objXRST_OUT_DTL.FLOT_NO = objTRST_STOCK.ARYME(0).FLOT_NO                'ﾛｯﾄ№
        objXRST_OUT_DTL.XNUM = intHikiateNum                                    '数量
        objXRST_OUT_DTL.XTUMI_HOUKOU = objAryXPLN_OUT.ARYME(0).XTUMI_HOUKOU     '積込方向
        objXRST_OUT_DTL.XTUMI_HOUHOU = objAryXPLN_OUT.ARYME(0).XTUMI_HOUHOU     '積込方法
        objXRST_OUT_DTL.FIN_KUBUN = objTRST_STOCK.ARYME(0).FIN_KUBUN            '入庫区分
        objXRST_OUT_DTL.FARRIVE_DT = objTRST_STOCK.ARYME(0).FARRIVE_DT          '在庫発生日時
        objXRST_OUT_DTL.XPROD_LINE = objTRST_STOCK.ARYME(0).XPROD_LINE          '生産ﾗｲﾝ№
        objXRST_OUT_DTL.XFM_ST = objTRST_STOCK.ARYME(0).FST_FM                  '搬送元ｽﾃｰｼｮﾝNo.
        objXRST_OUT_DTL.FBUF_FM = intFBUF_FM                                    '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objXRST_OUT_DTL.FARRAY_FM = intFARRAY_FM                                '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        objXRST_OUT_DTL.FBUF_TO = intFBUF_TO                                    '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objXRST_OUT_DTL.FARRAY_TO = intFARRAY_TO                                '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        objXRST_OUT_DTL.XBERTH_NO = objAryXPLN_OUT.ARYME(0).XBERTH_NO           'ﾊﾞｰｽNo.
        objXRST_OUT_DTL.XSEND_NAME = objAryXPLN_OUT.ARYME(0).XSEND_NAME         '届け先名称
        objXRST_OUT_DTL.XGYOUSYA_CD = objAryXPLN_OUT.ARYME(0).XGYOUSYA_CD       '物流業者ｺｰﾄﾞ
        objXRST_OUT_DTL.XHINMEI_CD = objTMST_ITEM.XHINMEI_CD                    '品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)
        objXRST_OUT_DTL.XRAC_IN_DT = objTRST_STOCK.ARYME(0).XRAC_IN_DT          '入庫日時
        objXRST_OUT_DTL.XSYARYOU_NO = objAryXPLN_OUT.ARYME(0).XSYARYOU_NO       '車輌番号
        objXRST_OUT_DTL.XKENPIN_KUBUN = objTRST_STOCK.ARYME(0).XKENPIN_KUBUN    '検品区分
        objXRST_OUT_DTL.XSAIMOKU = objXPLN_OUT_DTL_Update.XSAIMOKU              '取引区分細目
        objXRST_OUT_DTL.XIDOU_KBN = objXPLN_OUT_DTL_Update.XIDOU_KBN            '移動区分
        objXRST_OUT_DTL.XSYASYU_KBN = objAryXPLN_OUT.ARYME(0).XSYASYU_KBN       '車種区分
        objXRST_OUT_DTL.XARTICLE_TYPE_CODE = objTMST_ITEM.XARTICLE_TYPE_CODE    '品目種別(商品区分)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/11/12 日報変更
        objXRST_OUT_DTL.XUNKOU_NO = objAryXPLN_OUT.ARYME(0).XUNKOU_NO           '倉庫別運行No.
        objXRST_OUT_DTL.XHENSEI_NO_OYA = objAryXPLN_OUT.ARYME(0).XHENSEI_NO_OYA '親編成No.
        'JobMate:S.Ouchi 2013/11/12 日報変更
        '↑↑↑↑↑↑************************************************************************************************************
        objXRST_OUT_DTL.ADD_XRST_OUT_DTL()                                      '追加


        Return intReturn
    End Function
#End Region

    'ﾊﾞｰｽ引当関連
#Region "  前ﾊﾞｰｽ№取得                 (Public  Get_Barth_Prev)"
    '==============================================================================================
    '【機能】前ﾊﾞｰｽ№取得
    '【引数】[IN ] strBth       :
    '        [OUT] strBth_Prev  :
    '【戻値】RetCode
    '==============================================================================================
    Public Function Get_Barth_Prev(ByVal strBth As String, ByRef strBth_Prev As String) As RetCode
        Try
            Select Case strBth
                Case XBERTH_NO_JX01                                                    'Xﾊﾞｰｽ01
                    Return RetCode.NG
                Case XBERTH_NO_JX02                                                    'Xﾊﾞｰｽ02
                    strBth_Prev = XBERTH_NO_JX01
                Case XBERTH_NO_JX03                                                    'Xﾊﾞｰｽ03
                    strBth_Prev = XBERTH_NO_JX02
                Case XBERTH_NO_JX04                                                    'Xﾊﾞｰｽ04
                    strBth_Prev = XBERTH_NO_JX03
                Case XBERTH_NO_JX05                                                    'Xﾊﾞｰｽ05
                    strBth_Prev = XBERTH_NO_JX04
                Case XBERTH_NO_JX06                                                    'Xﾊﾞｰｽ06
                    strBth_Prev = XBERTH_NO_JX05
                Case XBERTH_NO_JY01                                                    'Yﾊﾞｰｽ01
                    Return RetCode.NG
                Case XBERTH_NO_JY02                                                    'Yﾊﾞｰｽ02
                    strBth_Prev = XBERTH_NO_JY01
                Case XBERTH_NO_JY03                                                    'Yﾊﾞｰｽ03
                    strBth_Prev = XBERTH_NO_JY02
                Case XBERTH_NO_JY04                                                    'Yﾊﾞｰｽ04
                    strBth_Prev = XBERTH_NO_JY03
                Case XBERTH_NO_JY05                                                    'Yﾊﾞｰｽ05
                    Return RetCode.NG
                Case XBERTH_NO_JY06                                                    'Yﾊﾞｰｽ06
                    strBth_Prev = XBERTH_NO_JY05
                Case XBERTH_NO_JY07                                                    'Yﾊﾞｰｽ07
                    strBth_Prev = XBERTH_NO_JY06
                Case XBERTH_NO_JY08                                                    'Yﾊﾞｰｽ08
                    strBth_Prev = XBERTH_NO_JY07
                Case XBERTH_NO_JY09                                                    'Yﾊﾞｰｽ09
                    Return RetCode.NG
                Case XBERTH_NO_JY10                                                    'Yﾊﾞｰｽ10
                    strBth_Prev = XBERTH_NO_JY09
                Case XBERTH_NO_JY11                                                    'Yﾊﾞｰｽ11
                    strBth_Prev = XBERTH_NO_JY10
                Case XBERTH_NO_JY12                                                    'Yﾊﾞｰｽ12
                    strBth_Prev = XBERTH_NO_JY11
                Case XBERTH_NO_JY13                                                    'Yﾊﾞｰｽ13
                    Return RetCode.NG
                Case XBERTH_NO_JY14                                                    'Yﾊﾞｰｽ14
                    strBth_Prev = XBERTH_NO_JY13
                Case XBERTH_NO_JY15                                                    'Yﾊﾞｰｽ15
                    strBth_Prev = XBERTH_NO_JY14
                Case XBERTH_NO_JY16                                                    'Yﾊﾞｰｽ16
                    strBth_Prev = XBERTH_NO_JY15
                Case XBERTH_NO_JY17                                                    'Yﾊﾞｰｽ17
                    Return RetCode.NG
                Case XBERTH_NO_JY18                                                    'Yﾊﾞｰｽ18
                    strBth_Prev = XBERTH_NO_JY17
                Case XBERTH_NO_JY19                                                    'Yﾊﾞｰｽ19
                    strBth_Prev = XBERTH_NO_JY18
                Case XBERTH_NO_JY20                                                    'Yﾊﾞｰｽ20
                    strBth_Prev = XBERTH_NO_JY19
                Case Else
                    Return RetCode.NG
            End Select

            '正常終了
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
#Region "  次ﾊﾞｰｽ№取得                 (Public  Get_Barth_Next)"
    '==============================================================================================
    '【機能】次ﾊﾞｰｽ№取得
    '【引数】[IN ] strBth       :
    '        [OUT] strBth_Next  :
    '【戻値】RetCode
    '==============================================================================================
    Public Function Get_Barth_Next(ByVal strBth As String, ByRef strBth_Next As String) As RetCode
        Try
            Select Case strBth
                Case XBERTH_NO_JX01                                                    'Xﾊﾞｰｽ01
                    strBth_Next = XBERTH_NO_JX02
                Case XBERTH_NO_JX02                                                    'Xﾊﾞｰｽ02
                    strBth_Next = XBERTH_NO_JX03
                Case XBERTH_NO_JX03                                                    'Xﾊﾞｰｽ03
                    strBth_Next = XBERTH_NO_JX04
                Case XBERTH_NO_JX04                                                    'Xﾊﾞｰｽ04
                    strBth_Next = XBERTH_NO_JX05
                Case XBERTH_NO_JX05                                                    'Xﾊﾞｰｽ05
                    strBth_Next = XBERTH_NO_JX06
                Case XBERTH_NO_JX06                                                    'Xﾊﾞｰｽ06
                    Return RetCode.NG
                Case XBERTH_NO_JY01                                                    'Yﾊﾞｰｽ01
                    strBth_Next = XBERTH_NO_JY02
                Case XBERTH_NO_JY02                                                    'Yﾊﾞｰｽ02
                    strBth_Next = XBERTH_NO_JY03
                Case XBERTH_NO_JY03                                                    'Yﾊﾞｰｽ03
                    strBth_Next = XBERTH_NO_JY04
                Case XBERTH_NO_JY04                                                    'Yﾊﾞｰｽ04
                    Return RetCode.NG
                Case XBERTH_NO_JY05                                                    'Yﾊﾞｰｽ05
                    strBth_Next = XBERTH_NO_JY06
                Case XBERTH_NO_JY06                                                    'Yﾊﾞｰｽ06
                    strBth_Next = XBERTH_NO_JY07
                Case XBERTH_NO_JY07                                                    'Yﾊﾞｰｽ07
                    strBth_Next = XBERTH_NO_JY08
                Case XBERTH_NO_JY08                                                    'Yﾊﾞｰｽ08
                    Return RetCode.NG
                Case XBERTH_NO_JY09                                                    'Yﾊﾞｰｽ09
                    strBth_Next = XBERTH_NO_JY10
                Case XBERTH_NO_JY10                                                    'Yﾊﾞｰｽ10
                    strBth_Next = XBERTH_NO_JY11
                Case XBERTH_NO_JY11                                                    'Yﾊﾞｰｽ11
                    strBth_Next = XBERTH_NO_JY12
                Case XBERTH_NO_JY12                                                    'Yﾊﾞｰｽ12
                    Return RetCode.NG
                Case XBERTH_NO_JY13                                                    'Yﾊﾞｰｽ13
                    strBth_Next = XBERTH_NO_JY14
                Case XBERTH_NO_JY14                                                    'Yﾊﾞｰｽ14
                    strBth_Next = XBERTH_NO_JY15
                Case XBERTH_NO_JY15                                                    'Yﾊﾞｰｽ15
                    strBth_Next = XBERTH_NO_JY16
                Case XBERTH_NO_JY16                                                    'Yﾊﾞｰｽ16
                    Return RetCode.NG
                Case XBERTH_NO_JY17                                                    'Yﾊﾞｰｽ17
                    strBth_Next = XBERTH_NO_JY18
                Case XBERTH_NO_JY18                                                    'Yﾊﾞｰｽ18
                    strBth_Next = XBERTH_NO_JY19
                Case XBERTH_NO_JY19                                                    'Yﾊﾞｰｽ19
                    strBth_Next = XBERTH_NO_JY20
                Case XBERTH_NO_JY20                                                    'Yﾊﾞｰｽ20
                    Return RetCode.NG
                Case Else
                    Return RetCode.NG
            End Select

            '正常終了
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
#Region "  ﾊﾞｰｽ情報取得                 (Public  Get_Barth_Data)"
    '==============================================================================================
    '【機能】ﾊﾞｰｽ情報取得
    '【引数】[IN ] strBth               :
    '        [IN ] objXSTS_BERTH_ALL    :
    '        [OUT] objXSTS_BERTH        :
    '【戻値】RetCode
    '==============================================================================================
    Public Function Get_Barth_Data(ByVal strBth As String, ByVal objXSTS_BERTH_ALL As TBL_XSTS_BERTH, ByRef objXSTS_BERTH As TBL_XSTS_BERTH) As RetCode
        Try
            Dim blnFlg As Boolean
            Dim strMsg As String                                    'ﾒｯｾｰｼﾞ

            '出荷ﾊﾞｰｽ状況
            blnFlg = False
            For Each objXSTS_BERTH_WK As TBL_XSTS_BERTH In objXSTS_BERTH_ALL.ARYME
                If strBth = objXSTS_BERTH_WK.XBERTH_NO Then         'ﾊﾞｰｽ№
                    objXSTS_BERTH.COPY_PROPERTY(objXSTS_BERTH_WK)
                    blnFlg = True
                End If
            Next
            If blnFlg = False Then
                strMsg = "出荷ﾊﾞｰｽ状況に該当バース情報無し。[バース№:" & strBth & "]"
                Throw New UserException(strMsg)
            End If

            '正常終了
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
#Region "  ﾊﾞｰｽ情報取得(設備状態含む)   (Public  Get_Barth_Data_EQ)"
    '==============================================================================================
    '【機能】ﾊﾞｰｽ情報取得
    '【引数】[IN ] strBth       :
    '        [IN ] objPLN_OUT   :
    '【戻値】RetCode
    '==============================================================================================
    Public Function Get_Barth_Data_EQ(ByVal strBth As String, ByVal objXSTS_BERTH_ALL As TBL_XSTS_BERTH, ByVal objTSTS_EQ_ALL As TBL_TSTS_EQ_CTRL, ByRef objXSTS_BERTH As TBL_XSTS_BERTH, ByRef objTSTS_EQ As TBL_TSTS_EQ_CTRL) As RetCode
        Try
            Dim blnFlg As Boolean
            Dim strMsg As String                                    'ﾒｯｾｰｼﾞ

            '出荷ﾊﾞｰｽ状況
            blnFlg = False
            For Each objXSTS_BERTH_WK As TBL_XSTS_BERTH In objXSTS_BERTH_ALL.ARYME
                If strBth = objXSTS_BERTH_WK.XBERTH_NO Then         'ﾊﾞｰｽ№
                    objXSTS_BERTH.COPY_PROPERTY(objXSTS_BERTH_WK)
                    blnFlg = True
                End If
            Next
            If blnFlg = False Then
                strMsg = "出荷ﾊﾞｰｽ状況に該当バース情報無し。[バース№:" & strBth & "]"
                Throw New UserException(strMsg)
            End If

            '設備状況
            blnFlg = False
            For Each objTSTS_EQ_WK As TBL_TSTS_EQ_CTRL In objTSTS_EQ_ALL.ARYME
                If strBth = objTSTS_EQ_WK.FEQ_ID Then               '設備ID(ﾊﾞｰｽ№)
                    objTSTS_EQ.COPY_PROPERTY(objTSTS_EQ_WK)
                    blnFlg = True
                End If
            Next
            If blnFlg = False Then
                strMsg = "設備状況に該当設備ID無し。[設備ID:" & strBth & "]"
                Throw New UserException(strMsg)
            End If

            '正常終了
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
#Region "  ﾛｰﾀﾞﾊﾞｰｽ№号機取得           (Public  Get_LOADER_GOUKI)"
    '==============================================================================================
    '【機能】ﾛｰﾀﾞﾊﾞｰｽ№号機取得
    '【引数】[IN ] strBth       :
    '【戻値】号機
    '==============================================================================================
    Public Function Get_LOADER_GOUKI(ByVal strBth As String) As Integer
        Try
            Select Case strBth
                Case XBERTH_NO_JX01                                                    'Xﾊﾞｰｽ01
                    Return 1
                Case XBERTH_NO_JX02                                                    'Xﾊﾞｰｽ02
                    Return 1
                Case XBERTH_NO_JX03                                                    'Xﾊﾞｰｽ03
                    Return 1
                Case XBERTH_NO_JX04                                                    'Xﾊﾞｰｽ04
                    Return 2
                Case XBERTH_NO_JX05                                                    'Xﾊﾞｰｽ05
                    Return 2
                Case XBERTH_NO_JX06                                                    'Xﾊﾞｰｽ06
                    Return 2
                Case XBERTH_NO_JY01                                                    'Yﾊﾞｰｽ01
                    Return 0
                Case XBERTH_NO_JY02                                                    'Yﾊﾞｰｽ02
                    Return 0
                Case XBERTH_NO_JY03                                                    'Yﾊﾞｰｽ03
                    Return 0
                Case XBERTH_NO_JY04                                                    'Yﾊﾞｰｽ04
                    Return 0
                Case XBERTH_NO_JY05                                                    'Yﾊﾞｰｽ05
                    Return 0
                Case XBERTH_NO_JY06                                                    'Yﾊﾞｰｽ06
                    Return 0
                Case XBERTH_NO_JY07                                                    'Yﾊﾞｰｽ07
                    Return 0
                Case XBERTH_NO_JY08                                                    'Yﾊﾞｰｽ08
                    Return 0
                Case XBERTH_NO_JY09                                                    'Yﾊﾞｰｽ09
                    Return 0
                Case XBERTH_NO_JY10                                                    'Yﾊﾞｰｽ10
                    Return 0
                Case XBERTH_NO_JY11                                                    'Yﾊﾞｰｽ11
                    Return 0
                Case XBERTH_NO_JY12                                                    'Yﾊﾞｰｽ12
                    Return 0
                Case XBERTH_NO_JY13                                                    'Yﾊﾞｰｽ13
                    Return 0
                Case XBERTH_NO_JY14                                                    'Yﾊﾞｰｽ14
                    Return 0
                Case XBERTH_NO_JY15                                                    'Yﾊﾞｰｽ15
                    Return 0
                Case XBERTH_NO_JY16                                                    'Yﾊﾞｰｽ16
                    Return 0
                Case XBERTH_NO_JY17                                                    'Yﾊﾞｰｽ17
                    Return 0
                Case XBERTH_NO_JY18                                                    'Yﾊﾞｰｽ18
                    Return 0
                Case XBERTH_NO_JY19                                                    'Yﾊﾞｰｽ19
                    Return 0
                Case XBERTH_NO_JY20                                                    'Yﾊﾞｰｽ20
                    Return 0
                Case Else
                    Return 0
            End Select

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region

    '印字関連
#Region "  ﾋﾟｯｷﾝｸﾞﾘｽﾄ印字出力                                       "
    '''*************************************************************************************************************
    ''' <summary>
    ''' ﾋﾟｯｷﾝｸﾞﾘｽﾄ印字出力
    ''' </summary>
    ''' <param name="dtmXSYUKKA_D">出荷日</param>
    ''' <param name="strXHENSEI_NO_OYA">親編成No.</param>
    ''' <remarks></remarks>
    '''*************************************************************************************************************
    Public Sub PrintPickingList(ByVal dtmXSYUKKA_D As Date _
                              , ByVal strXHENSEI_NO_OYA As String _
                              )

        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_311050_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
        Dim objComFuncFRM As New clsComFuncFRM  '標準機能(GamenMate.clsComFuncFRMよりｺﾋﾟｰ)

        Try
            Dim intRet As Integer = 0

            '************************************************************
            ' ﾍｯﾀﾞｰ部情報取得
            '************************************************************
            'ﾍｯﾀﾞｰ部変数
            Dim strXSYUKKA_D As String = ""                 '出荷日
            Dim strXSYARYOU_NO As String = ""               '車輌No.
            Dim strXBERTH_NO As String = ""                 'ﾊﾞｰｽNo.
            Dim strXTUMI_HOUHOU As String = ""              '積込方法
            Dim strXTUMI_HOUKOU As String = ""              '積込方向
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
            Dim strSAIMOKU As String = ""                   '細目
            Dim strGYOUSYA As String = ""                   '業者
            'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
            '↑↑↑↑↑↑************************************************************************************************************

            Dim objTBL_XPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, Nothing)
            objTBL_XPLN_OUT.XHENSEI_NO_OYA = strXHENSEI_NO_OYA     '親編成No.
            objTBL_XPLN_OUT.XSYUKKA_D = dtmXSYUKKA_D               '出荷日
            intRet = objTBL_XPLN_OUT.GET_XPLN_OUT_ANY()
            If intRet <> RetCode.OK Then
                '(ﾃﾞｰﾀ取得失敗時)
                Exit Try
            End If


            For Each objTBL_XPLN_OUT_DATA As TBL_XPLN_OUT In objTBL_XPLN_OUT.ARYME
                strXSYARYOU_NO = TO_STRING(objTBL_XPLN_OUT_DATA.XSYARYOU_NO)     '車輌No.
                strXBERTH_NO = TO_STRING(objTBL_XPLN_OUT_DATA.XBERTH_NO)         'ﾊﾞｰｽNo.
                strXTUMI_HOUHOU = TO_STRING(objTBL_XPLN_OUT_DATA.XTUMI_HOUHOU)   '積込方法
                strXTUMI_HOUKOU = TO_STRING(objTBL_XPLN_OUT_DATA.XTUMI_HOUKOU)   '積込方向
            Next


            '************************************************************
            ' ﾃﾞｰﾀ部情報取得
            '************************************************************
            Dim strSQL As String                        'SQL文
            Dim objRow As DataRow                       '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
            Dim objTBLDataSet As New DataSet            'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
            ' '' ''============================================================
            ' '' ''SELECT
            ' '' ''============================================================

            '' ''strSQL = ""
            '' ''strSQL &= vbCrLf & "SELECT "
            '' ''strSQL &= vbCrLf & "    XPLN_OUT_DTL.XHENSEI_NO "                                       '出荷指示詳細.      編成No.
            '' ''strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XDENPYOU_NO "                                      '出荷指示詳細.      伝票No.
            '' ''strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XOUT_ORDER "                                       '出荷指示詳細.  　　車輌内出荷品目順
            '' ''strSQL &= vbCrLf & "  , TMST_ITEM.XHINMEI_CD "                                          '品名ﾏｽﾀ.　　       品名ｺｰﾄﾞ
            '' ''strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FHINMEI_CD "                                       '出荷指示詳細.      品名記号
            '' ''strSQL &= vbCrLf & "  , TMST_ITEM.FHINMEI "                                             '品名ﾏｽﾀ.　　       品名
            '' ''strSQL &= vbCrLf & "  , NVL(XPLN_OUT_DTL.XSYUKKA_KON_RESERVE,0) XSYUKKA_KON_RESERVE "   '出荷指示詳細.  　　出荷引当梱数
            '' ''strSQL &= vbCrLf & "  , NVL(XPLN_OUT_DTL.XSYUKKA_KON_H_RESULT, 0) XSYUKKA_KON_H_RESULT" '出荷指示詳細.      出荷実績梱数
            '' ''strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FPLAN_KEY "                                        '出荷指示詳細.      計画ｷｰ

            ' '' ''============================================================
            ' '' ''FROM
            ' '' ''============================================================
            '' ''strSQL &= vbCrLf & " FROM "
            '' ''strSQL &= vbCrLf & "    XPLN_OUT_DTL "           '【出荷指示詳細】
            '' ''strSQL &= vbCrLf & "  , TMST_ITEM "              '【品目ﾏｽﾀ】

            ' '' ''============================================================
            ' '' ''WHERE
            ' '' ''============================================================
            '' ''strSQL &= vbCrLf & " WHERE "
            '' ''strSQL &= vbCrLf & "         1 = 1 "
            '' ''strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XHENSEI_NO_OYA = '" & strXHENSEI_NO_OYA & "' "    '出荷指示詳細 を 親編成No. で特定
            '' ''strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_D = '" & dtmXSYUKKA_D & "' "              '出荷指示詳細 を 出荷日 で特定
            '' ''strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD "               '出荷指示詳細 と 品目ﾏｽﾀ を 品目ｺｰﾄﾞ で結合

            ' '' ''============================================================
            ' '' ''ORDER BY
            ' '' ''============================================================
            '' ''strSQL &= vbCrLf & " ORDER BY "
            '' ''strSQL &= vbCrLf & "         XPLN_OUT_DTL.XOUT_ORDER "                                      '出荷指示詳細.  　　車輌内出荷品目順


            '============================================================
            'SELECT
            '============================================================
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "    XPLN_OUT_DTL.XHENSEI_NO "                                       '出荷指示詳細.      編成No.
            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XDENPYOU_NO "                                      '出荷指示詳細.      伝票No.
            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XOUT_ORDER "                                       '出荷指示詳細.  　　車輌内出荷品目順
            strSQL &= vbCrLf & "  , TMST_ITEM.XHINMEI_CD "                                          '品名ﾏｽﾀ.　　       品名ｺｰﾄﾞ
            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FHINMEI_CD "                                       '出荷指示詳細.      品名記号
            strSQL &= vbCrLf & "  , TMST_ITEM.FHINMEI "                                             '品名ﾏｽﾀ.　　       品名
            strSQL &= vbCrLf & "  , NVL(XPLN_OUT_DTL.XSYUKKA_KON_RESERVE,0) XSYUKKA_KON_RESERVE "   '出荷指示詳細.  　　出荷引当梱数
            strSQL &= vbCrLf & "  , NVL(XPLN_OUT_DTL.XSYUKKA_KON_H_RESULT, 0) XSYUKKA_KON_H_RESULT" '出荷指示詳細.      出荷実績梱数
            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FPLAN_KEY "                                        '出荷指示詳細.      計画ｷｰ
            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XSAIMOKU "                                         '出荷指示詳細.      取引区分細目
            strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP AS XSAIMOKU_Dsp "                            '出荷指示詳細.      取引区分細目(表示用)
            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XIDOU_KBN "                                        '出荷指示詳細.      移動区分
            strSQL &= vbCrLf & "  , XPLN_OUT.XGYOUSYA_CD "                                          '出荷指示.          業者ｺｰﾄﾞ
            strSQL &= vbCrLf & "  , XMST_GYOUSYA.XGYOUSYA_NAME "                                    '業者ﾏｽﾀ.           業者名
            strSQL &= vbCrLf & "  , TMST_ITEM.FNUM_IN_PALLET "                                      '品名ﾏｽﾀ.　　       PL毎積載数
            strSQL &= vbCrLf & "  , TMST_ITEM.XPLANE_PACK_NUMBER "                                  '品名ﾏｽﾀ.　　       平面梱数

            '============================================================
            'FROM
            '============================================================
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "    XPLN_OUT_DTL "           '【出荷指示詳細】
            strSQL &= vbCrLf & "  , TMST_ITEM "              '【品目ﾏｽﾀ】
            strSQL &= vbCrLf & "  , XPLN_OUT "               '【出荷指示】
            strSQL &= vbCrLf & "  , XMST_GYOUSYA "           '【業者ﾏｽﾀ】
            strSQL &= vbCrLf & "  ,(SELECT * FROM TDSP_DISP WHERE FTABLE_NAME = 'XPLN_OUT_DTL' AND FFIELD_NAME = 'XSAIMOKU') HASH01 "

            '============================================================
            'WHERE
            '============================================================
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "         1 = 1 "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XHENSEI_NO_OYA = '" & strXHENSEI_NO_OYA & "' "    '出荷指示詳細 を 親編成No. で特定
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_D = '" & dtmXSYUKKA_D & "' "              '出荷指示詳細 を 出荷日 で特定
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD "               '出荷指示詳細 と 品目ﾏｽﾀ を 品目ｺｰﾄﾞ で結合
            strSQL &= vbCrLf & "     AND HASH01.FDISP_VALUE(+) = XPLN_OUT_DTL.XSAIMOKU "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_D = XPLN_OUT.XSYUKKA_D "                  '出荷指示詳細 と 出荷指示 を 出荷日 で特定
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XHENSEI_NO = XPLN_OUT.XHENSEI_NO "                '出荷指示詳細 と 出荷指示 を 親編成No. で特定
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XDENPYOU_NO = XPLN_OUT.XDENPYOU_NO "              '出荷指示詳細 と 出荷指示 を 伝票No. で特定
            strSQL &= vbCrLf & "     AND XMST_GYOUSYA.XGYOUSYA_CD = XPLN_OUT.XGYOUSYA_CD "              '出荷指示     と 業者ﾏｽﾀ  を 業者ｺｰﾄﾞ で特定

            '============================================================
            'ORDER BY
            '============================================================
            strSQL &= vbCrLf & " ORDER BY "
            strSQL &= vbCrLf & "         XPLN_OUT_DTL.XOUT_ORDER "                                      '出荷指示詳細.  　　車輌内出荷品目順
            'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
            '↑↑↑↑↑↑************************************************************************************************************

            '-----------------------
            '抽出
            '-----------------------
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "XPLN_OUT_DTL"
            ObjDb.GetDataSet(strDataSetName, objDataSet)


            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For Each objRow In objDataSet.Tables(strDataSetName).Rows

                    Dim strXHENSEI_NO As String = ""                '編成No.
                    Dim strXDENPYOU_NO As String = ""               '伝票No.
                    Dim strXOUT_ORDER As String = ""                '出庫順
                    Dim strXHINMEI_CD As String = ""                '品名ｺｰﾄﾞ
                    Dim strFHINMEI_CD As String = ""                '品名記号
                    Dim strFHINMEI As String = ""                   '品名
                    Dim strXSYUKKA_KON_RESERVE As String = ""       '出荷数
                    Dim strXSYUKKA_KON_H_RESULT As String = ""      '平置
                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
                    Dim strFNUM_IN_PALLET As String = ""            'PL毎積載数
                    Dim strMODOSHI_NUM As String = ""               '平置き戻し数

                    If strSAIMOKU = "" Then
                        strSAIMOKU = TO_STRING(objRow("XSAIMOKU_Dsp"))
                        If TO_INTEGER(objRow("XSAIMOKU")) = XSAIMOKU_JIDOU Then
                            '(細目が移動の場合)
                            If TO_INTEGER(objRow("XIDOU_KBN")) = XIDOU_KBN_JIDOU Then
                                '(移動区分が1の場合)
                                strSAIMOKU = "移動-1"
                            End If
                        End If
                    End If

                    If strGYOUSYA = "" Then
                        strGYOUSYA = TO_STRING(objRow("XGYOUSYA_NAME"))
                    End If
                    'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
                    '↑↑↑↑↑↑************************************************************************************************************

                    'ﾃﾞｰﾀ部
                    strXHENSEI_NO = TO_STRING(objRow("XHENSEI_NO"))
                    strXDENPYOU_NO = TO_STRING(objRow("XDENPYOU_NO"))
                    strXOUT_ORDER = TO_STRING(objRow("XOUT_ORDER"))
                    strXHINMEI_CD = TO_STRING(objRow("XHINMEI_CD"))
                    strFHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))
                    strFHINMEI = TO_STRING(objRow("FHINMEI"))
                    strXSYUKKA_KON_RESERVE = TO_STRING(objRow("XSYUKKA_KON_RESERVE"))
                    strXSYUKKA_KON_H_RESULT = TO_STRING(objRow("XSYUKKA_KON_H_RESULT"))
                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
                    strFNUM_IN_PALLET = TO_STRING(objRow("FNUM_IN_PALLET"))             'PL毎積載数
                    'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
                    '↑↑↑↑↑↑************************************************************************************************************

                    Dim strFPLAN_KEY As String = ""                 '計画ｷｰ
                    strFPLAN_KEY = TO_STRING(objRow("FPLAN_KEY"))


                    '************************************************************
                    ' SQL文作成 在庫引当情報取得
                    '************************************************************
                    Dim strSQL2 As String                        'SQL文
                    Dim objRow2 As DataRow                       '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
                    Dim strDataSetName2 As String                'ﾃﾞｰﾀｾｯﾄ名
                    Dim objTBLDataSet2 As New DataSet            'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）


                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
                    ' '' ''============================================================
                    ' '' ''SELECT
                    ' '' ''============================================================
                    '' ''strSQL2 = ""
                    '' ''strSQL2 &= vbCrLf & " SELECT "
                    '' ''strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                           '在庫引当情報.  　　    計画ｷｰ
                    ' '' ''strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.          ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
                    '' ''strSQL2 &= vbCrLf & "  , SUM(NVL(TSTS_HIKIATE.FTR_VOL,0)) AS FTR_VOL_SUM "  '在庫引当情報.          搬送管理量合計
                    '' ''strSQL2 &= vbCrLf & "  , COUNT(0) AS FTR_VOL_PL "                           '在庫引当情報.          PL数
                    ' '' '' ''strSQL2 &= vbCrLf & "  , TSTS_HIKIATE.FPALLET_ID "                          '在庫引当情報.          ﾊﾟﾚｯﾄID

                    ' '' ''============================================================
                    ' '' ''FROM
                    ' '' ''============================================================
                    '' ''strSQL2 &= vbCrLf & " FROM "
                    '' ''strSQL2 &= vbCrLf & "    TSTS_HIKIATE "           '【在庫引当情報】
                    ' '' ''strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF "           '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ】

                    ' '' ''============================================================
                    ' '' ''WHERE
                    ' '' ''============================================================
                    '' ''strSQL2 &= vbCrLf & " WHERE "
                    '' ''strSQL2 &= vbCrLf & "         1 = 1 "
                    '' ''strSQL2 &= vbCrLf & "     AND TSTS_HIKIATE.FPLAN_KEY = '" & strFPLAN_KEY & "' "             '引当情報 を 計画ｷｰ で特定
                    ' '' ''strSQL2 &= vbCrLf & "     AND TSTS_HIKIATE.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID "           '引当情報 と ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ を ﾊﾟﾚｯﾄID で結合

                    ' '' ''============================================================
                    ' '' ''GROUP BY
                    ' '' ''============================================================
                    '' ''strSQL2 &= vbCrLf & " GROUP BY  "
                    '' ''strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                    '在庫引当情報.  　　計画ｷｰ
                    ' '' ''strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.

                    ' '' ''============================================================
                    ' '' ''ORDER BY
                    ' '' ''============================================================
                    '' ''strSQL2 &= vbCrLf & " ORDER BY  "
                    '' ''strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                    '在庫引当情報.  　　計画ｷｰ
                    ' '' ''strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
                    '' ''strSQL2 &= vbCrLf

                    '============================================================
                    'SELECT
                    '============================================================
                    strSQL2 = ""
                    strSQL2 &= vbCrLf & " SELECT "
                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                               '在庫引当情報.  　　    計画ｷｰ
                    strSQL2 &= vbCrLf & "  , SUM(NVL(TSTS_HIKIATE.FTR_VOL,0)) AS FTR_VOL_SUM "      '在庫引当情報.          搬送管理量合計
                    strSQL2 &= vbCrLf & "  , COUNT(0) AS FTR_VOL_PL "                               '在庫引当情報.          PL数
                    strSQL2 &= vbCrLf & "  , SUM(NVL(TRST_STOCK.FTR_VOL,0)) AS FTR_VOL "            '在庫情報.              搬送管理量合計
                    strSQL2 &= vbCrLf & "  , SUM(NVL(TRST_STOCK.FTR_RES_VOL,0)) AS FTR_RES_VOL "    '在庫情報.              搬送引当量合計

                    '============================================================
                    'FROM
                    '============================================================
                    strSQL2 &= vbCrLf & " FROM "
                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE "                                         '【在庫引当情報】
                    strSQL2 &= vbCrLf & "  , TRST_STOCK "                                           '【在庫情報】

                    '============================================================
                    'WHERE
                    '============================================================
                    strSQL2 &= vbCrLf & " WHERE "
                    strSQL2 &= vbCrLf & "         1 = 1 "
                    strSQL2 &= vbCrLf & "     AND TSTS_HIKIATE.FPLAN_KEY = '" & strFPLAN_KEY & "' " '引当情報 を 計画ｷｰ で特定
                    strSQL2 &= vbCrLf & "     AND TSTS_HIKIATE.FPALLET_ID = TRST_STOCK.FPALLET_ID " '引当情報 と 在庫情報 を ﾊﾟﾚｯﾄID で結合

                    '============================================================
                    'GROUP BY
                    '============================================================
                    strSQL2 &= vbCrLf & " GROUP BY  "
                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                               '在庫引当情報.  　　計画ｷｰ

                    '============================================================
                    'ORDER BY
                    '============================================================
                    strSQL2 &= vbCrLf & " ORDER BY  "
                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                               '在庫引当情報.  　　計画ｷｰ
                    strSQL2 &= vbCrLf

                    'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
                    '↑↑↑↑↑↑************************************************************************************************************

                    '-----------------------
                    '抽出
                    '-----------------------
                    ObjDb.SQL = strSQL2
                    objTBLDataSet2.Clear()
                    strDataSetName2 = "TSTS_HIKIATE"
                    ObjDb.GetDataSet(strDataSetName2, objTBLDataSet2)

                    Dim intFTR_VOL_CONVEYOR As Integer = 0     '出荷ｺﾝﾍﾞﾔ
                    Dim intFTR_VOL_CONVEYOR_PL As Integer = 0  '出荷ｺﾝﾍﾞﾔ(PL数)
                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
                    Dim intFTR_VOL As Decimal = 0               '在庫情報.搬送管理量合計
                    Dim intFTR_RES_VOL As Decimal = 0           '在庫情報.搬送引当量合計
                    'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
                    '↑↑↑↑↑↑************************************************************************************************************

                    If objTBLDataSet2.Tables(strDataSetName2).Rows.Count > 0 Then
                        For Each objRow2 In objTBLDataSet2.Tables(strDataSetName2).Rows

                            Dim strFTR_VOL_SUM As String        '搬送数
                            Dim strFTR_VOL_PL As String         '搬送数(PL)

                            strFTR_VOL_SUM = TO_STRING(objRow2("FTR_VOL_SUM"))
                            strFTR_VOL_PL = TO_STRING(objRow2("FTR_VOL_PL"))

                            intFTR_VOL_CONVEYOR = intFTR_VOL_CONVEYOR + TO_INTEGER(strFTR_VOL_SUM)      '出荷ｺﾝﾍﾞﾔ
                            intFTR_VOL_CONVEYOR_PL = intFTR_VOL_CONVEYOR_PL + TO_INTEGER(strFTR_VOL_PL) '出荷ｺﾝﾍﾞﾔ(PL数)

                            '↓↓↓↓↓↓************************************************************************************************************
                            'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
                            intFTR_VOL += TO_DECIMAL(objRow2("FTR_VOL"))                                '在庫情報.搬送管理量合計
                            intFTR_RES_VOL += TO_DECIMAL(objRow2("FTR_RES_VOL"))                        '在庫情報.搬送引当量合計
                            'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
                            '↑↑↑↑↑↑************************************************************************************************************
                        Next
                    End If


                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
                    Dim intRetVol As Decimal = 0                        '平置き戻し数
                    Dim intXPLANE_PACK_NUMBER As Decimal = 0            '平面梱数
                    Dim intDAN As Decimal = 0                           '段数
                    Dim intKON As Decimal = 0                           '1段未満の梱数

                    '平置き戻し数
                    intRetVol = intFTR_VOL - intFTR_RES_VOL
                    If intRetVol < 0 Then intRetVol = 0

                    '平置き戻し数(文字列)
                    If intRetVol = 0 Then
                        strMODOSHI_NUM = "0"
                    Else
                        '平面梱数
                        intXPLANE_PACK_NUMBER = TO_DECIMAL(objRow("XPLANE_PACK_NUMBER"))

                        '段数
                        intDAN = Int(intRetVol / intXPLANE_PACK_NUMBER)

                        '1段未満の梱数
                        intKON = intRetVol Mod intXPLANE_PACK_NUMBER

                        strMODOSHI_NUM = ""
                        strMODOSHI_NUM &= TO_STRING(intRetVol)
                        strMODOSHI_NUM &= "("
                        strMODOSHI_NUM &= TO_STRING(intXPLANE_PACK_NUMBER)
                        strMODOSHI_NUM &= "x"
                        strMODOSHI_NUM &= TO_STRING(intDAN)
                        strMODOSHI_NUM &= "段+"
                        strMODOSHI_NUM &= TO_STRING(intKON)
                        strMODOSHI_NUM &= "梱)"
                    End If
                    'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
                    '↑↑↑↑↑↑************************************************************************************************************


                    '***********************************************
                    ' ﾃﾞｰﾀ部分作成
                    '***********************************************
                    Dim objDataRow As clsPrintDataSet.DataTable01Row
                    objDataRow = objDataSet.DataTable01.NewRow

                    objDataRow.BeginEdit()

                    'ﾋﾟｯｷﾝｸﾞﾘｽﾄ ﾃﾞｰﾀ部
                    objDataRow.Data00 = strXHENSEI_NO                   '編成No.
                    objDataRow.Data01 = strXDENPYOU_NO                  '伝票No.
                    objDataRow.Data02 = strXOUT_ORDER                   '出庫順
                    objDataRow.Data03 = strXHINMEI_CD                   '品名ｺｰﾄﾞ
                    objDataRow.Data04 = strFHINMEI_CD                   '品名記号
                    objDataRow.Data05 = strFHINMEI                      '品名
                    objDataRow.Data06 = strXSYUKKA_KON_RESERVE          '出荷数
                    objDataRow.Data07 = TO_STRING(intFTR_VOL_CONVEYOR)  '出荷ｺﾝﾍﾞﾔ
                    objDataRow.Data08 = "(" & TO_STRING(intFTR_VOL_CONVEYOR_PL) & ")"   '(PL数)
                    objDataRow.Data09 = strXSYUKKA_KON_H_RESULT         '平置

                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
                    objDataRow.Data10 = strFNUM_IN_PALLET               'PL毎積載数
                    objDataRow.Data11 = strMODOSHI_NUM                  '平置き戻し数
                    'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
                    '↑↑↑↑↑↑************************************************************************************************************

                    objDataRow.EndEdit()

                    objDataSet.DataTable01.Rows.Add(objDataRow)

                Next
            End If

            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            Call objComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))          '発行日時
            Call objComFuncFRM.ChangeCRText(objCR, "crXSYARYOU_NO", strXSYARYOU_NO)                            '車番
            Call objComFuncFRM.ChangeCRText(objCR, "crXBERTH", strXBERTH_NO)                                   'ﾊﾞｰｽ
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
            Call objComFuncFRM.ChangeCRText(objCR, "crSAIMOKU", strSAIMOKU)                                    '細目
            Call objComFuncFRM.ChangeCRText(objCR, "crGYOUSYA", strGYOUSYA)                                    '業者
            'JobMate:S.Ouchi 2013/11/07 ﾋﾟｯｷﾝｸﾞﾘｽﾄ項目追加
            '↑↑↑↑↑↑************************************************************************************************************

            Select Case strXTUMI_HOUHOU                                                                         '積込方法
                Case TO_STRING(XTUMI_HOUHOU_JP)
                    strXTUMI_HOUHOU = "パレット"
                Case TO_STRING(XTUMI_HOUHOU_JB)
                    strXTUMI_HOUHOU = "バラ"
                Case TO_STRING(XTUMI_HOUHOU_JL)
                    strXTUMI_HOUHOU = "ローダ"
            End Select
            Call objComFuncFRM.ChangeCRText(objCR, "crXTUMI_HOUHOU", strXTUMI_HOUHOU)

            Select Case strXTUMI_HOUKOU                                                                         '積込方向
                Case TO_STRING(XTUMI_HOUKOU_JBACK)
                    strXTUMI_HOUKOU = "後積"
                Case TO_STRING(XTUMI_HOUKOU_JSIDE)
                    strXTUMI_HOUKOU = "片横積"
                Case TO_STRING(XTUMI_HOUKOU_JWING)
                    strXTUMI_HOUKOU = "両横積"
                Case TO_STRING(XTUMI_HOUKOU_JALL)
                    strXTUMI_HOUKOU = "ALL"
            End Select
            Call objComFuncFRM.ChangeCRText(objCR, "crXTUMI_HOUKOU", strXTUMI_HOUKOU)

            '***********************************************
            ' ｸﾘｽﾀﾙﾚﾎﾟｰﾄにﾃﾞｰﾀｾｯﾄをｾｯﾄ
            '***********************************************
            objCR.SetDataSource(objDataSet)

            '***********************************************
            ' 印字
            '***********************************************
            Call objComFuncFRM.CRPrint(objCR)

        Catch ex As Exception
            Throw ex

        Finally

            'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
            objCR.Dispose()
            objCR = Nothing
            'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
            objDataSet.Dispose()
            objDataSet = Nothing

        End Try


    End Sub
#End Region
#Region "  Excel日報出力                                            "
    '''*************************************************************************************************************
    ''' <summary>
    ''' Excel日報出力
    ''' </summary>
    ''' <param name="dtmSOUGYOU_D">操業日</param>
    ''' <remarks></remarks>
    '''*************************************************************************************************************
    Public Sub MakeExcelNippou(ByVal dtmSOUGYOU_D As Date)
        Dim strFile As String = ""
        Dim strFileNM As String = ""
        Dim strCSVFileNM As String = ""
        Dim objFuncExcel As New clsComFuncExcel(Owner, ObjDb, ObjDbLog)

        Try
            '*============================
            '* 作成ﾌｧｲﾙ名取得
            '*============================
            Dim identifier As String = Format(dtmSOUGYOU_D, "yyyyMMdd")
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 'ｼｽﾃﾑ変数ｸﾗｽ
            'Dim strDirectory As String = "..\Excel\"
            Dim strDirectory As String = objTPRG_SYS_HEN.SJ000000_022
            strFileNM = "日報_" & identifier & ".xls"
            strCSVFileNM = "日報_" & identifier & ".csv"
            '' ファイルの存在確認
            'If File.Exists(strFile) = True Then
            '    '(ファイルがある)
            '    '*******************************************************
            '    '確認ﾒｯｾｰｼﾞ
            '    '*******************************************************
            '    Dim udeRet As PopupFormType
            '    udeRet = gobjComFuncFRM.DisplayPopup("既に出力済みの日報が存在します。上書きしてもよろしいですか?", PopupFormType.Ok_Cancel, PopupIconType.Quest)
            '    If udeRet <> PopupFormType.Ok Then
            '        Exit Sub
            '    End If
            'End If

            ' Excelﾌｧｲﾙの起動確認
            If objFuncExcel.IsExcelBookOpen(strFileNM) Then
                Throw New UserException(strFileNM & "が開かれています。閉じてから再度実行して下さい。")
                Exit Sub
            End If

            '*============================
            '* 日報作成
            '*============================
            If objFuncExcel.makeReportNippo(dtmSOUGYOU_D, strDirectory, strFileNM, strCSVFileNM) = False Then
                '(エラーの場合)
                Throw New UserException("日報の作成に失敗しました。")
            End If

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try

    End Sub
#End Region
#Region "  Excel月報出力                                            "
    '''*************************************************************************************************************
    ''' <summary>
    ''' Excel月報出力
    ''' </summary>
    ''' <param name="dtmSOUGYOU_D">操業日</param>
    ''' <remarks></remarks>
    '''*************************************************************************************************************
    Public Sub MakeExcelGeppou(ByVal dtmSOUGYOU_D As Date)

        Dim strFile As String = ""
        Dim strFileNM As String = ""
        Dim objFuncExcel As New clsComFuncExcel(Owner, ObjDb, ObjDbLog)

        Try

            '*============================
            '* 作成ﾌｧｲﾙ名取得
            '*============================
            Dim identifier As String = ""
            identifier &= dtmSOUGYOU_D.ToString("yyyyMM")
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 'ｼｽﾃﾑ変数ｸﾗｽ
            'Dim strDirectory As String = "..\Excel\"
            Dim strDirectory As String = objTPRG_SYS_HEN.SJ000000_022
            strFileNM = "月報_" & identifier & ".xls"
            '' ファイルの存在確認
            'If File.Exists(strFile) = True Then
            '    '(ファイルがある)
            '    '*******************************************************
            '    '確認ﾒｯｾｰｼﾞ
            '    '*******************************************************
            '    Dim udeRet As PopupFormType
            '    udeRet = gobjComFuncFRM.DisplayPopup("既に出力済みの月報が存在します。上書きしてもよろしいですか?", PopupFormType.Ok_Cancel, PopupIconType.Quest)
            '    If udeRet <> PopupFormType.Ok Then
            '        Exit Sub
            '    End If
            'End If

            ' Excelﾌｧｲﾙの起動確認
            If objFuncExcel.IsExcelBookOpen(strFileNM) Then
                Throw New UserException(strFileNM & "が開かれています。閉じてから再度実行して下さい。")
                Exit Sub
            End If

            '*============================
            '* 月報作成
            '*============================
            If objFuncExcel.makeReportGeppo(dtmSOUGYOU_D.Year, dtmSOUGYOU_D.Month, strDirectory, strFileNM) = False Then
                '(エラーの場合)
                Throw New UserException("月報の作成に失敗しました。")
            End If

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try

    End Sub
#End Region
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↓↓↓↓↓↓
#Region "  Excel生産ライン日報出力                                  "
    '''*************************************************************************************************************
    ''' <summary>
    ''' Excel生産ライン日報出力
    ''' </summary>
    ''' <param name="dtmSOUGYOU_D">操業日</param>
    ''' <remarks></remarks>
    '''*************************************************************************************************************
    Public Sub MakeExcelSeisanNippou(ByVal dtmSOUGYOU_D As Date)
        Dim strFile As String = ""
        Dim strFileNM As String = ""
        Dim strCSVFileNM As String = ""
        Dim objFuncExcel As New clsComFuncExcel(Owner, ObjDb, ObjDbLog)

        Try
            '*============================
            '* 作成ﾌｧｲﾙ名取得
            '*============================
            Dim identifier As String = Format(dtmSOUGYOU_D, "yyyyMMdd")
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 'ｼｽﾃﾑ変数ｸﾗｽ
            Dim strDirectory As String = objTPRG_SYS_HEN.SJ000000_022
            strFileNM = "生産ライン日報_" & identifier & ".xls"
            strCSVFileNM = "生産ライン日報_" & identifier & ".csv"

            ' Excelﾌｧｲﾙの起動確認
            If objFuncExcel.IsExcelBookOpen(strFileNM) Then
                Throw New UserException(strFileNM & "が開かれています。閉じてから再度実行して下さい。")
                Exit Sub
            End If

            '*============================
            '* 生産ライン日報作成
            '*============================
            If objFuncExcel.makeReportSeisanNippo(dtmSOUGYOU_D, strDirectory, strFileNM, strCSVFileNM) = False Then
                '(エラーの場合)
                Throw New UserException("生産ライン日報の作成に失敗しました。")
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try

    End Sub
#End Region
    'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↑↑↑↑↑↑
    '↑↑↑↑↑↑************************************************************************************************************

    'その他
#Region "  関連する棚ﾌﾞﾛｯｸの取得                                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 関連するﾌﾞﾛｯｸ棚の取得
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_Base">
    ''' 基準となる棚
    ''' </param>
    ''' <param name="objTPRG_TRK_BUF_Relation">
    ''' 関連するﾌﾞﾛｯｸ棚の配列
    ''' </param>
    ''' <param name="objTRST_STOCK_Base">
    ''' 基準となる在庫情報
    ''' </param>
    ''' <param name="objTRST_STOCK_Relation">
    ''' 関連するﾌﾞﾛｯｸ棚の在庫情報の配列
    ''' </param>
    ''' <param name="objTRST_PALLET_Base">
    ''' 基準となるﾊﾟﾚｯﾄ情報
    ''' </param>
    ''' <param name="objTRST_PALLET_Relation">
    ''' 関連するﾌﾞﾛｯｸ棚のﾊﾟﾚｯﾄ情報の配列
    ''' </param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub GetTPRG_TRK_BUF_Relation(ByVal objTPRG_TRK_BUF_Base As TBL_TPRG_TRK_BUF _
                                      , ByRef objTPRG_TRK_BUF_Relation() As TBL_TPRG_TRK_BUF _
                                      , ByRef objTRST_STOCK_Base As TBL_TRST_STOCK _
                                      , ByRef objTRST_STOCK_Relation() As TBL_TRST_STOCK _
                                      , Optional ByRef objTRST_PALLET_Base As TBL_TRST_PALLET = Nothing _
                                      , Optional ByRef objTRST_PALLET_Relation() As TBL_TRST_PALLET = Nothing _
                                        )
        Dim intRet As RetCode                 '戻り値
        Dim strMsg As String                  'ﾒｯｾｰｼﾞ

        Try


            '************************************************
            '初期設定
            '************************************************
            ReDim objTPRG_TRK_BUF_Relation(RelationArray.MAX - 1)
            ReDim objTRST_STOCK_Relation(RelationArray.MAX - 1)
            ReDim objTRST_PALLET_Relation(RelationArray.MAX - 1)


            '************************************************************************************************
            '************************************************************************************************
            '関連情報の取得
            '************************************************************************************************
            '************************************************************************************************
            '************************************************
            '関連棚の取得
            '************************************************
            Dim objAryTPRG_TRK_BUF_Get As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objAryTPRG_TRK_BUF_Get.FTRK_BUF_NO = objTPRG_TRK_BUF_Base.FTRK_BUF_NO       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objAryTPRG_TRK_BUF_Get.XTANA_BLOCK = objTPRG_TRK_BUF_Base.XTANA_BLOCK       '棚ﾌﾞﾛｯｸ
            objAryTPRG_TRK_BUF_Get.ORDER_BY = "XTANA_BLOCK_DTL ASC"                     '並び
            intRet = objAryTPRG_TRK_BUF_Get.GET_TPRG_TRK_BUF_ANY()                      '取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_BUF & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & objAryTPRG_TRK_BUF_Get.FTRK_BUF_NO & "]" _
                                             & "[棚ﾌﾞﾛｯｸ:" & objAryTPRG_TRK_BUF_Get.XTANA_BLOCK & "]"
                Throw New UserException(strMsg)
            End If
            For ii As Integer = 0 To UBound(objAryTPRG_TRK_BUF_Get.ARYME)
                '(ﾙｰﾌﾟ:同一棚ﾌﾞﾛｯｸ数)


                '************************************************
                '関連棚の取得
                '************************************************
                objTPRG_TRK_BUF_Relation(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_Relation(ii).FTRK_BUF_NO = objAryTPRG_TRK_BUF_Get.ARYME(ii).FTRK_BUF_NO
                objTPRG_TRK_BUF_Relation(ii).FTRK_BUF_ARRAY = objAryTPRG_TRK_BUF_Get.ARYME(ii).FTRK_BUF_ARRAY
                objTPRG_TRK_BUF_Relation(ii).GET_TPRG_TRK_BUF()


                '**********************************************
                '基準となる棚の在庫取得
                '**********************************************
                If IsNotNull(objTPRG_TRK_BUF_Relation(ii).FPALLET_ID) Then
                    '(実棚の場合)

                    '==========================================
                    '在庫情報の取得
                    '==========================================
                    objTRST_STOCK_Relation(ii) = New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                    objTRST_STOCK_Relation(ii).FPALLET_ID = objTPRG_TRK_BUF_Relation(ii).FPALLET_ID     'ﾊﾟﾚｯﾄID
                    intRet = objTRST_STOCK_Relation(ii).GET_TRST_STOCK_KONSAI(True)                     '取得

                    '==========================================
                    'ﾊﾟﾚｯﾄ情報の取得
                    '==========================================
                    If IsNotNull(objTRST_PALLET_Relation) Then
                        objTRST_PALLET_Relation(ii) = New TBL_TRST_PALLET(Owner, ObjDb, ObjDbLog)
                        objTRST_PALLET_Relation(ii).FPALLET_ID = objTPRG_TRK_BUF_Relation(ii).FPALLET_ID    'ﾊﾟﾚｯﾄID
                        objTRST_PALLET_Relation(ii).GET_TRST_PALLET()                                       '取得
                    End If

                ElseIf IsNotNull(objTPRG_TRK_BUF_Relation(ii).FRSV_PALLET) Then
                    '(予約棚の場合)

                    '==========================================
                    '在庫情報の取得
                    '==========================================
                    objTRST_STOCK_Relation(ii) = New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                    objTRST_STOCK_Relation(ii).FPALLET_ID = objTPRG_TRK_BUF_Relation(ii).FRSV_PALLET    'ﾊﾟﾚｯﾄID
                    intRet = objTRST_STOCK_Relation(ii).GET_TRST_STOCK_KONSAI(True)                     '取得

                    '==========================================
                    'ﾊﾟﾚｯﾄ情報の取得
                    '==========================================
                    If IsNotNull(objTRST_PALLET_Relation) Then
                        objTRST_PALLET_Relation(ii) = New TBL_TRST_PALLET(Owner, ObjDb, ObjDbLog)
                        objTRST_PALLET_Relation(ii).FPALLET_ID = objTPRG_TRK_BUF_Relation(ii).FRSV_PALLET       'ﾊﾟﾚｯﾄID
                        objTRST_PALLET_Relation(ii).GET_TRST_PALLET()                                           '取得
                    End If

                End If



            Next


            '************************************************************************************************
            '************************************************************************************************
            '基準となる棚の情報の取得
            '************************************************************************************************
            '************************************************************************************************
            '**********************************************
            '基準となる棚の在庫取得
            '**********************************************
            If IsNotNull(objTPRG_TRK_BUF_Base.FPALLET_ID) Then
                '(実棚の場合)

                '==========================================
                '在庫情報の取得
                '==========================================
                objTRST_STOCK_Base.FPALLET_ID = objTPRG_TRK_BUF_Base.FPALLET_ID             'ﾊﾟﾚｯﾄID
                intRet = objTRST_STOCK_Base.GET_TRST_STOCK_KONSAI(True)                     '取得

                '==========================================
                'ﾊﾟﾚｯﾄ情報の取得
                '==========================================
                If IsNotNull(objTRST_PALLET_Base) Then
                    objTRST_PALLET_Base.FPALLET_ID = objTPRG_TRK_BUF_Base.FPALLET_ID            'ﾊﾟﾚｯﾄID
                    objTRST_PALLET_Base.GET_TRST_PALLET()                                       '取得
                End If

            ElseIf IsNotNull(objTPRG_TRK_BUF_Base.FRSV_PALLET) Then
                '(予約棚の場合)

                '==========================================
                '在庫情報の取得
                '==========================================
                objTRST_STOCK_Base.FPALLET_ID = objTPRG_TRK_BUF_Base.FRSV_PALLET            'ﾊﾟﾚｯﾄID
                intRet = objTRST_STOCK_Base.GET_TRST_STOCK_KONSAI(True)                     '取得

                '==========================================
                'ﾊﾟﾚｯﾄ情報の取得
                '==========================================
                If IsNotNull(objTRST_PALLET_Base) Then
                    objTRST_PALLET_Base.FPALLET_ID = objTPRG_TRK_BUF_Base.FRSV_PALLET       'ﾊﾟﾚｯﾄID
                    objTRST_PALLET_Base.GET_TRST_PALLET()                                   '取得
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
#Region "  関連する棚ﾌﾞﾛｯｸの取得(在庫引当情報、搬送指示QUE)                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 関連する棚ﾌﾞﾛｯｸの取得(在庫引当情報、搬送指示QUE)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_Base">基準となる棚</param>
    ''' <param name="objTPRG_TRK_BUF_Relation">関連するﾌﾞﾛｯｸ棚の配列</param>
    ''' <param name="objTSTS_HIKIATE_Base">基準となる棚の在庫引当情報の配列</param>
    ''' <param name="objTSTS_HIKIATE_Relation">関連するﾌﾞﾛｯｸ棚の在庫引当情報の配列</param>
    ''' <param name="objTPLN_CARRY_QUE_Base">基準となる棚の搬送指示QUEの配列</param>
    ''' <param name="objTPLN_CARRY_QUE_Relation">関連するﾌﾞﾛｯｸ棚の搬送指示QUEの配列</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub GetInfor_Relation(ByVal objTPRG_TRK_BUF_Base As TBL_TPRG_TRK_BUF _
                               , ByVal objTPRG_TRK_BUF_Relation() As TBL_TPRG_TRK_BUF _
                               , ByRef objTSTS_HIKIATE_Base As TBL_TSTS_HIKIATE _
                               , ByRef objTSTS_HIKIATE_Relation() As TBL_TSTS_HIKIATE _
                               , ByRef objTPLN_CARRY_QUE_Base As TBL_TPLN_CARRY_QUE _
                               , ByRef objTPLN_CARRY_QUE_Relation() As TBL_TPLN_CARRY_QUE _
                               )
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ

        Try


            '************************************************
            '初期設定
            '************************************************
            ReDim objTSTS_HIKIATE_Relation(RelationArray.MAX - 1)
            ReDim objTPLN_CARRY_QUE_Relation(RelationArray.MAX - 1)


            '************************************************************************************************
            '************************************************************************************************
            'ﾌﾞﾛｯｸ内情報                        取得
            '************************************************************************************************
            '************************************************************************************************
            For ii As Integer = 0 To UBound(objTPRG_TRK_BUF_Relation)
                '(ﾙｰﾌﾟ:同一棚ﾌﾞﾛｯｸ数)


                If IsNotNull(objTPRG_TRK_BUF_Relation(ii).FPALLET_ID) And objTPRG_TRK_BUF_Relation(ii).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Then
                    '(在庫が存在している場合)


                    '==========================================
                    '在庫引当情報               取得
                    '==========================================
                    objTSTS_HIKIATE_Relation(ii) = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
                    objTSTS_HIKIATE_Relation(ii).FPALLET_ID = objTPRG_TRK_BUF_Relation(ii).FPALLET_ID   'ﾊﾟﾚｯﾄID
                    objTSTS_HIKIATE_Relation(ii).GET_TSTS_HIKIATE()                                     '取得

                    '==========================================
                    '搬送指示QUE                取得
                    '==========================================
                    objTPLN_CARRY_QUE_Relation(ii) = New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                    objTPLN_CARRY_QUE_Relation(ii).FPALLET_ID = objTPRG_TRK_BUF_Relation(ii).FPALLET_ID     'ﾊﾟﾚｯﾄID
                    objTPLN_CARRY_QUE_Relation(ii).GET_TPLN_CARRY_QUE()                                     '取得


                End If


            Next


            '************************************************************************************************
            '************************************************************************************************
            '基準となる棚の情報の取得
            '************************************************************************************************
            '************************************************************************************************
            '**********************************************
            '基準となる棚の在庫取得
            '**********************************************
            If IsNotNull(objTPRG_TRK_BUF_Base.FPALLET_ID) And objTPRG_TRK_BUF_Base.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Then
                '(実棚の場合)

                '==========================================
                '在庫引当情報               取得
                '==========================================
                objTSTS_HIKIATE_Base = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
                objTSTS_HIKIATE_Base.FPALLET_ID = objTPRG_TRK_BUF_Base.FPALLET_ID       'ﾊﾟﾚｯﾄID
                objTSTS_HIKIATE_Base.GET_TSTS_HIKIATE()                                 '取得

                '==========================================
                '在庫引当情報               取得
                '==========================================
                objTPLN_CARRY_QUE_Base = New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                objTPLN_CARRY_QUE_Base.FPALLET_ID = objTPRG_TRK_BUF_Base.FPALLET_ID     'ﾊﾟﾚｯﾄID
                objTPLN_CARRY_QUE_Base.GET_TPLN_CARRY_QUE()                             '取得

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
#Region "  関連する棚ﾌﾞﾛｯｸの、全棚ﾌﾞﾛｯｸ状態を更新                                                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 関連する棚ﾌﾞﾛｯｸの、全棚ﾌﾞﾛｯｸ状態を更新
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_Base">基準となる棚</param>
    ''' <param name="intXTANA_BLOCK_STS">棚ﾌﾞﾛｯｸ状態</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub UpdateTPRG_TRK_BUF_Relation_XTANA_BLOCK_STS(ByRef objTPRG_TRK_BUF_Base As TBL_TPRG_TRK_BUF _
                                                         , ByVal intXTANA_BLOCK_STS As Integer _
                                                         )
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '************************************************
        '棚ﾌﾞﾛｯｸ状態の更新
        '************************************************
        Dim objTrkRelation() As TBL_TPRG_TRK_BUF = Nothing                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
        Dim objStockFind As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)          '在庫情報
        Dim objStockRelation() As TBL_TRST_STOCK = Nothing                      '在庫情報
        Call GetTPRG_TRK_BUF_Relation(objTPRG_TRK_BUF_Base, objTrkRelation, objStockFind, objStockRelation)
        For ii As Integer = 0 To UBound(objTrkRelation)
            '(ﾙｰﾌﾟ:関係するﾄﾗｯｷﾝｸﾞ数)

            If objTPRG_TRK_BUF_Base.FTRK_BUF_NO = objTrkRelation(ii).FTRK_BUF_NO And objTPRG_TRK_BUF_Base.FTRK_BUF_ARRAY = objTrkRelation(ii).FTRK_BUF_ARRAY Then
                '対象となる棚
                objTPRG_TRK_BUF_Base.XTANA_BLOCK_STS = intXTANA_BLOCK_STS       '棚ﾌﾞﾛｯｸ状態
                objTPRG_TRK_BUF_Base.FBUF_IN_DT = Now                           'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_Base.UPDATE_TPRG_TRK_BUF()                      '更新
            Else
                '関連する棚
                objTrkRelation(ii).XTANA_BLOCK_STS = intXTANA_BLOCK_STS     '棚ﾌﾞﾛｯｸ状態
                objTrkRelation(ii).FBUF_IN_DT = Now                         'ﾊﾞｯﾌｧ入日時
                objTrkRelation(ii).UPDATE_TPRG_TRK_BUF()                    '更新
            End If

        Next


        ''************************************************
        ''棚ﾌﾞﾛｯｸ状態の更新(27列特殊処理)
        ''************************************************
        'Dim strSQL As String        'SQL文
        'Dim intRetSQL As Integer    'SQL実行戻り値
        'strSQL = ""
        'strSQL &= vbCrLf & " UPDATE "
        'strSQL &= vbCrLf & "    TPRG_TRK_BUF "
        'strSQL &= vbCrLf & " SET "
        'strSQL &= vbCrLf & "    XTANA_BLOCK_STS = " & XTANA_BLOCK_STS_IN
        'strSQL &= vbCrLf & " WHERE "
        'strSQL &= vbCrLf & "     1 = 1 "
        'strSQL &= vbCrLf & " AND FRAC_RETU = " & FRAC_RETU_J27
        'strSQL &= vbCrLf & " AND ( XTANA_BLOCK_STS <> " & XTANA_BLOCK_STS_IN & " OR XTANA_BLOCK_STS IS NULL )"
        'strSQL &= vbCrLf
        'intRetSQL = ObjDb.Execute(strSQL)
        'If intRetSQL = -1 Then
        '    '(SQLｴﾗｰ)
        '    strSQL = Replace(strSQL, vbCrLf, "")
        '    strMsg = ERRMSG_ERR_DELETE & ObjDb.ErrMsg & "【" & strSQL & "】"
        '    Throw New UserException(strMsg)
        'End If


    End Sub
#End Region
#Region "  親子判定(ﾊﾟﾚｯﾄID)                                                                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 親子判定(ﾊﾟﾚｯﾄID)
    ''' </summary>
    ''' <param name="strFPALLET_ID_01">ﾊﾟﾚｯﾄID01</param>
    ''' <param name="strFPALLET_ID_02">ﾊﾟﾚｯﾄID02</param>
    ''' <returns>OK:親子関係     NG:親子関係じゃない</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function HanteiOyakoFPALLET_ID(ByVal strFPALLET_ID_01 As String _
                                        , ByVal strFPALLET_ID_02 As String _
                                        ) _
                                        As RetCode
        Dim intReturn As RetCode = RetCode.NG
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ

        Try


            '************************************************
            'ﾁｪｯｸ
            '************************************************
            If IsNull(strFPALLET_ID_01) Then Return intReturn
            If IsNull(strFPALLET_ID_02) Then Return intReturn


            '************************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(01)       取得
            '************************************************
            Dim objTPRG_TRK_BUF01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF01.FPALLET_ID = strFPALLET_ID_01     'ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF01.GET_TPRG_TRK_BUF()                '取得


            '************************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(02)       取得
            '************************************************
            Dim objTPRG_TRK_BUF02 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF02.FPALLET_ID = strFPALLET_ID_02     'ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF02.GET_TPRG_TRK_BUF()                '取得


            '************************************************
            '親子判定
            '************************************************
            If objTPRG_TRK_BUF01.XTANA_BLOCK = objTPRG_TRK_BUF02.XTANA_BLOCK Then
                '(棚ﾌﾞﾛｯｸが同一の場合)

                Select Case objTPRG_TRK_BUF01.XTANA_BLOCK_DTL
                    Case XTANA_BLOCK_DTL_OKU_EVN : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_OKU_ODD Then intReturn = RetCode.OK
                    Case XTANA_BLOCK_DTL_OKU_ODD : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_OKU_EVN Then intReturn = RetCode.OK
                    Case XTANA_BLOCK_DTL_MAE_EVN : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_MAE_ODD Then intReturn = RetCode.OK
                    Case XTANA_BLOCK_DTL_MAE_ODD : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_MAE_EVN Then intReturn = RetCode.OK
                End Select


            End If


            Return intReturn
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  親子判定(仮引当ﾊﾟﾚｯﾄID)                                                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 親子判定(仮引当ﾊﾟﾚｯﾄID)
    ''' </summary>
    ''' <param name="strFRSV_PALLET_01">仮引当ﾊﾟﾚｯﾄID01</param>
    ''' <param name="strFRSV_PALLET_02">仮引当ﾊﾟﾚｯﾄID02</param>
    ''' <returns>OK:親子関係     NG:親子関係じゃない</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function HanteiOyakoFRSV_PALLET(ByVal strFRSV_PALLET_01 As String _
                                         , ByVal strFRSV_PALLET_02 As String _
                                         ) _
                                         As RetCode
        Dim intReturn As RetCode = RetCode.NG
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ

        Try


            '************************************************
            'ﾁｪｯｸ
            '************************************************
            If IsNull(strFRSV_PALLET_01) Then Return intReturn
            If IsNull(strFRSV_PALLET_02) Then Return intReturn


            '************************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(01)       取得
            '************************************************
            Dim objTPRG_TRK_BUF01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF01.FRSV_PALLET = strFRSV_PALLET_01       '仮引当ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF01.GET_TPRG_TRK_BUF()                    '取得


            '************************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(02)       取得
            '************************************************
            Dim objTPRG_TRK_BUF02 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF02.FRSV_PALLET = strFRSV_PALLET_02       '仮引当ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF02.GET_TPRG_TRK_BUF()                    '取得


            '************************************************
            '親子判定
            '************************************************
            If objTPRG_TRK_BUF01.XTANA_BLOCK = objTPRG_TRK_BUF02.XTANA_BLOCK Then
                '(棚ﾌﾞﾛｯｸが同一の場合)

                Select Case objTPRG_TRK_BUF01.XTANA_BLOCK_DTL
                    Case XTANA_BLOCK_DTL_OKU_EVN : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_OKU_ODD Then intReturn = RetCode.OK
                    Case XTANA_BLOCK_DTL_OKU_ODD : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_OKU_EVN Then intReturn = RetCode.OK
                    Case XTANA_BLOCK_DTL_MAE_EVN : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_MAE_ODD Then intReturn = RetCode.OK
                    Case XTANA_BLOCK_DTL_MAE_ODD : If objTPRG_TRK_BUF02.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_MAE_EVN Then intReturn = RetCode.OK
                End Select


            End If


            Return intReturn
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  入庫ﾄﾗｯｷﾝｸﾞ情報の更新                                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入庫ﾄﾗｯｷﾝｸﾞ情報の更新
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <param name="objTRST_STOCK">在庫情報ﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub UpdateTRST_STOCK_InInfor(ByVal objTPRG_TRK_BUF As TBL_TPRG_TRK_BUF _
                                      , ByVal objTRST_STOCK As TBL_TRST_STOCK _
                                      )


        '*****************************************************
        '在庫情報               更新
        '*****************************************************
        objTRST_STOCK.ARYME(0).XTRK_BUF_NO_IN = objTPRG_TRK_BUF.FTRK_BUF_NO             '入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTRST_STOCK.ARYME(0).XTRK_BUF_ARRAY_IN = objTPRG_TRK_BUF.FTRK_BUF_ARRAY       '入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        objTRST_STOCK.ARYME(0).UPDATE_TRST_STOCK()                                      '更新


    End Sub
#End Region
#Region "  ﾛｯﾄ№                        取得                                                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｯﾄ№取得
    ''' </summary>
    ''' <param name="strFLOT_NO">ﾛｯﾄ№</param>
    ''' <param name="strXPROD_LINE">生産ﾗｲﾝ№</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub GetFLOT_NO(ByRef strFLOT_NO As String _
                        , ByVal strXPROD_LINE As String _
                        )
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        '*****************************************************
        '操業履歴                       取得
        '*****************************************************
        Dim objXRST_SOUGYOU As New TBL_XRST_SOUGYOU(Owner, ObjDb, ObjDbLog)
        objXRST_SOUGYOU.GET_XRST_SOUGYOU_XRST_SOUGYOU_MAX()    '取得


        '*****************************************************
        'ﾛｯﾄ№                          設定
        '*****************************************************
        strFLOT_NO = strXPROD_LINE & Format(objXRST_SOUGYOU.XSOUGYOU_DT, "yyyyMMdd")


    End Sub
#End Region
#Region "  出庫CV配列                   取得                                                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出庫CV配列取得
    ''' </summary>
    ''' <param name="intAryOutCV">出庫CV配列</param>
    ''' <param name="intXBERTH_GROUP">ﾊﾞｰｽｸﾞﾙｰﾌﾟ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub GetintAryOutCV(ByRef intAryOutCV() As Integer _
                            , ByVal intXBERTH_GROUP As Integer _
                            )
        Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        '=======================================
        '出荷ﾊﾞｰｽ状況           取得
        '=======================================
        Dim objAryXSTS_CONVEYOR As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)
        objAryXSTS_CONVEYOR.XBERTH_GROUP = intXBERTH_GROUP                  'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
        objAryXSTS_CONVEYOR.ORDER_BY = " XSTNO "                            '並び
        intRet = objAryXSTS_CONVEYOR.GET_XSTS_CONVEYOR_ANY()                '取得
        If intRet = RetCode.OK Then
            '(見つかった場合)
            ReDim intAryOutCV(UBound(objAryXSTS_CONVEYOR.ARYME))
            For ii As Integer = 0 To UBound(objAryXSTS_CONVEYOR.ARYME)
                '(ﾙｰﾌﾟ:出庫CV数)
                intAryOutCV(ii) = objAryXSTS_CONVEYOR.ARYME(ii).XSTNO
            Next
        Else
            '(見つからなかった場合)
            Throw New Exception(ERRMSG_NOTFOUND_XSTS_CONVEYOR & "[ﾊﾞｰｽｸﾞﾙｰﾌﾟ:" & TO_STRING(objAryXSTS_CONVEYOR.XBERTH_GROUP) & "]")
        End If


    End Sub
#End Region
#Region "  予定数                       取得                                                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 予定数                       取得
    ''' </summary>
    ''' <param name="objTMST_TRK">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ</param>
    ''' <param name="intYotei01">予定数01</param>
    ''' <param name="intYotei02">予定数02</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub GetYoteiNum(ByVal objTMST_TRK As TBL_TMST_TRK _
                         , ByRef intYotei01 As Integer _
                         , ByRef intYotei02 As Integer _
                         )
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        If IsNotNull(objTMST_TRK.XADRS_YOTEI01) Then
            '(予定数ｱﾄﾞﾚｽ01が定義されている場合)


            '************************************************
            '設備状況           取得
            '************************************************
            Dim objTSTS_EQ_CTRL_YOTEI01 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            Dim objTSTS_EQ_CTRL_YOTEI02 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_YOTEI01, objTMST_TRK.XADRS_YOTEI01)
            If IsNotNull(objTMST_TRK.XADRS_YOTEI02) Then
                '(予定数ｱﾄﾞﾚｽ02が定義されている場合)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_YOTEI02, objTMST_TRK.XADRS_YOTEI02)
            End If


            '************************************************
            'ﾃﾞｰﾀをｾｯﾄ
            '************************************************
            intYotei01 = objTSTS_EQ_CTRL_YOTEI01.FEQ_STS
            intYotei02 = objTSTS_EQ_CTRL_YOTEI02.FEQ_STS


        End If


    End Sub
#End Region
#Region "  予定数、ﾊﾟﾚｯﾄ数の0ﾁｪｯｸ                                                                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 到着予定数のﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№を取得(ﾍﾟｱ搬送、ｼﾝｸﾞﾙ搬送)
    ''' </summary>
    ''' <param name="objTMST_TRK">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub CheckYoteiPalletNum(ByVal objTMST_TRK As TBL_TMST_TRK)
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        If IsNotNull(objTMST_TRK.XADRS_YOTEI01) Then
            '(予定数ｱﾄﾞﾚｽ01が定義されている場合)


            '************************************************
            '設備状況           取得
            '************************************************
            Dim objTSTS_EQ_CTRL_YOTEI01 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            Dim objTSTS_EQ_CTRL_YOTEI02 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            Dim objTSTS_EQ_CTRL_PALLET01 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            Dim objTSTS_EQ_CTRL_PALLET02 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_YOTEI01, objTMST_TRK.XADRS_YOTEI01)
            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_PALLET01, objTMST_TRK.XADRS_PALLET01)
            If IsNotNull(objTMST_TRK.XADRS_YOTEI02) Then
                '(予定数ｱﾄﾞﾚｽ02が定義されている場合)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_YOTEI02, objTMST_TRK.XADRS_YOTEI02)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_PALLET02, objTMST_TRK.XADRS_PALLET02)
            End If


            '************************************************
            '予定数
            '************************************************
            If objTSTS_EQ_CTRL_YOTEI01.FEQ_STS <> 0 Then Throw New Exception("予定数が0でない為、出庫は行えません。[設備ID:" & objTSTS_EQ_CTRL_YOTEI01.FEQ_ID & "][設備状態:" & objTSTS_EQ_CTRL_YOTEI01.FEQ_STS & "]")
            If IsNotNull(objTMST_TRK.XADRS_YOTEI02) Then
                '(予定数ｱﾄﾞﾚｽ02が定義されている場合)
                If objTSTS_EQ_CTRL_YOTEI02.FEQ_STS <> 0 Then Throw New Exception("予定数が0でない為、出庫は行えません。[設備ID:" & objTSTS_EQ_CTRL_YOTEI02.FEQ_ID & "][設備状態:" & objTSTS_EQ_CTRL_YOTEI02.FEQ_STS & "]")
            End If


            '************************************************
            'ﾊﾟﾚｯﾄ数ﾁｪｯｸ
            '************************************************
            Select Case objTMST_TRK.FTRK_BUF_NO
                Case FTRK_BUF_NO_J2039 _
                   , FTRK_BUF_NO_J2917 _
                   , FTRK_BUF_NO_J2062 _
                   , FTRK_BUF_NO_J2061 _
                   , FTRK_BUF_NO_J2037 _
                   , FTRK_BUF_NO_J2909 _
                   , FTRK_BUF_NO_J2908 _
                   , FTRK_BUF_NO_J2907 _
                   , FTRK_BUF_NO_J2906 _
                   , FTRK_BUF_NO_J2905
                    'NOP
                Case Else
                    If objTSTS_EQ_CTRL_PALLET01.FEQ_STS <> 0 Then Throw New Exception("ﾊﾟﾚｯﾄ数が0でない為、出庫は行えません。[設備ID:" & objTSTS_EQ_CTRL_PALLET01.FEQ_ID & "][設備状態:" & objTSTS_EQ_CTRL_PALLET01.FEQ_STS & "]")
                    If IsNotNull(objTMST_TRK.XADRS_YOTEI02) Then
                        '(予定数ｱﾄﾞﾚｽ02が定義されている場合)
                        If objTSTS_EQ_CTRL_PALLET02.FEQ_STS <> 0 Then Throw New Exception("ﾊﾟﾚｯﾄ数が0でない為、出庫は行えません。[設備ID:" & objTSTS_EQ_CTRL_PALLET02.FEQ_ID & "][設備状態:" & objTSTS_EQ_CTRL_PALLET02.FEQ_STS & "]")
                    End If
            End Select


        End If


    End Sub
#End Region
#Region "  予定数ﾏｲﾅｽ1                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 予定数ﾏｲﾅｽ1
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <param name="strFPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <param name="blnPair">ﾍﾟｱﾌﾗｸﾞ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub UpdateYoteiNumMinus1(ByVal intFTRK_BUF_NO As Integer _
                                  , ByVal strFPALLET_ID As String _
                                  , ByVal blnPair As Boolean _
                                  )
        Try
            'Dim intRet As RetCode                 '戻り値
            'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


            '***********************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ           取得
            '***********************************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF.FPALLET_ID = strFPALLET_ID          'ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                  '取得
            If IsNull(objTPRG_TRK_BUF.FTR_TO) Then Exit Sub


            '***********************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ(TO)
            '***********************************************
            Dim objTMST_TRK_TO As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK_TO.FTRK_BUF_NO = objTPRG_TRK_BUF.FTR_TO            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTMST_TRK_TO.GET_TMST_TRK()                                  '取得


            '***********************************************
            '搬送指示QUE        特定
            '***********************************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
            objTPLN_CARRY_QUE.FPALLET_ID = strFPALLET_ID            'ﾊﾟﾚｯﾄID
            objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                  '取得
            If IsNotNull(objTMST_TRK_TO.XADRS_YOTEI02) Then Exit Sub 'ﾄﾗｯｸﾛｰﾀﾞの場合は処理しない


            '***********************************************
            '予定数             取得
            '***********************************************
            Dim intYotei01 As Integer = 0
            Dim intYotei02 As Integer = 0
            Call GetYoteiNum(objTMST_TRK_TO, intYotei01, intYotei02)
            If intYotei01 <= 0 And IsNull(objTMST_TRK_TO.XADRS_YOTEI02) Then Exit Sub
            If intYotei01 <= 0 And intYotei02 <= 0 Then Exit Sub


            '************************************************
            '予定数             ﾃﾞｰﾀｾｯﾄ
            '************************************************
            If blnPair Then
                '(ﾍﾟｱ搬送の場合)
                If 0 <= intYotei01 Then intYotei01 = intYotei01 - 2
            Else
                '(ｼﾝｸﾞﾙ搬送の場合)
                If 0 <= intYotei01 Then intYotei01 = intYotei01 - 1
            End If


            '************************************************
            '安川         到着予定数
            '************************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            'objSVR_190001.FEQ_ID = strFEQ_ID                                '設備ID
            objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         'ｺﾏﾝﾄﾞID
            objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
                                                  , intYotei01 _
                                                  , intYotei02 _
                                                  )


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub


    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 予定数ﾏｲﾅｽ1
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <param name="strFPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub UpdateYoteiNumMinus1(ByVal intFTRK_BUF_NO As Integer _
                                  , ByVal strFPALLET_ID As String _
                                  )
        'Try
        '    'Dim intRet As RetCode                 '戻り値
        '    'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        '    '***********************************************
        '    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ           取得
        '    '***********************************************
        '    Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        '    objTPRG_TRK_BUF.FPALLET_ID = strFPALLET_ID          'ﾊﾟﾚｯﾄID
        '    objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                  '取得
        '    If IsNull(objTPRG_TRK_BUF.FTR_TO) Then Exit Sub


        '    '***********************************************
        '    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ(TO)
        '    '***********************************************
        '    Dim objTMST_TRK_TO As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        '    objTMST_TRK_TO.FTRK_BUF_NO = objTPRG_TRK_BUF.FTR_TO            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        '    objTMST_TRK_TO.GET_TMST_TRK()                                  '取得


        '    '***********************************************
        '    '搬送指示QUE        特定
        '    '***********************************************
        '    Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
        '    objTPLN_CARRY_QUE.FPALLET_ID = strFPALLET_ID            'ﾊﾟﾚｯﾄID
        '    objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                  '取得


        '    '***********************************************
        '    '予定数             取得
        '    '***********************************************
        '    Dim intYotei01 As Integer = 0
        '    Dim intYotei02 As Integer = 0
        '    Call GetYoteiNum(objTMST_TRK_TO, intYotei01, intYotei02)
        '    If intYotei01 <= 0 And intYotei02 <= 0 Then Exit Sub


        '    '************************************************
        '    '予定数             ﾃﾞｰﾀｾｯﾄ
        '    '************************************************
        '    If IsNotNull(objTMST_TRK_TO.XADRS_YOTEI02) Then
        '        '(ﾄﾗｯｸﾛｰﾀﾞの場合)


        '        '************************************************
        '        '安川         到着予定数
        '        '************************************************
        '        If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
        '            '(ﾍﾟｱ搬送の場合)
        '            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
        '                                                  , intYotei01 _
        '                                                  , intYotei02 - 1 _
        '                                                  )
        '        Else
        '            '(ｼﾝｸﾞﾙ搬送の場合)
        '            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
        '                                                  , intYotei01 - 1 _
        '                                                  , intYotei02 _
        '                                                  )
        '        End If


        '    ElseIf IsNotNull(objTMST_TRK_TO.XADRS_YOTEI01) Then
        '        '(予定数ｱﾄﾞﾚｽ01が定義されている場合)


        '        '************************************************
        '        '安川         到着予定数
        '        '************************************************
        '        If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
        '            '(ﾍﾟｱ搬送の場合)
        '            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
        '                                                  , intYotei01 - 2 _
        '                                                  , 0 _
        '                                                  )
        '        Else
        '            '(ｼﾝｸﾞﾙ搬送の場合)
        '            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
        '                                                  , intYotei01 - 1 _
        '                                                  , 0 _
        '                                                  )
        '        End If


        '    End If


        '    '************************************************
        '    '安川         到着予定数
        '    '************************************************
        '    Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
        '    'objSVR_190001.FEQ_ID = strFEQ_ID                                '設備ID
        '    objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         'ｺﾏﾝﾄﾞID
        '    objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
        '    Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
        '                                          , intYotei01 _
        '                                          , intYotei02 _
        '                                          )


        'Catch ex As Exception
        '    Call ComError(ex)

        'End Try
    End Sub
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞ数ﾁｪｯｸ01(ｺﾝﾍﾞﾔ用途設定、ﾊﾞｰｽ割付ｺﾝﾍﾞﾔ設定で使用)                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞ数ﾁｪｯｸ01(ｺﾝﾍﾞﾔ用途設定、ﾊﾞｰｽ割付ｺﾝﾍﾞﾔ設定で使用)
    ''' ﾊﾞｰｽｸﾞﾙｰﾌﾟからSTを特定し、関連する出庫がないか判定する。
    ''' </summary>
    ''' <param name="intXBERTH_GROUP_Before">変更前のｸﾞﾙｰﾌﾟ№</param>
    ''' <param name="intXBERTH_GROUP_After">変更後のｸﾞﾙｰﾌﾟ№</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub CheckTrkBufCount01(ByVal intXBERTH_GROUP_Before As Integer _
                                , ByVal intXBERTH_GROUP_After As Integer _
                                )
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        '************************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ               ﾁｪｯｸ
        '************************************************
        Dim strSQL01 As String = ""       'SQL文
        strSQL01 &= vbCrLf & " SELECT "
        strSQL01 &= vbCrLf & "    COUNT(*) "
        strSQL01 &= vbCrLf & " FROM "
        strSQL01 &= vbCrLf & "    TPRG_TRK_BUF "
        strSQL01 &= vbCrLf & " WHERE "
        strSQL01 &= vbCrLf & "    1 = 1 "
        strSQL01 &= vbCrLf & "    AND ("
        strSQL01 &= vbCrLf & "            FTR_TO      IN ( SELECT XSTNO FROM XSTS_CONVEYOR WHERE XBERTH_GROUP IN ( " & intXBERTH_GROUP_Before & ", " & intXBERTH_GROUP_After & " ) ) "
        strSQL01 &= vbCrLf & "         OR FTRK_BUF_NO IN ( SELECT XSTNO FROM XSTS_CONVEYOR WHERE XBERTH_GROUP IN ( " & intXBERTH_GROUP_Before & ", " & intXBERTH_GROUP_After & " ) ) "
        strSQL01 &= vbCrLf & "        ) "
        strSQL01 &= vbCrLf & "    AND FPALLET_ID IS NOT NULL "
        strSQL01 &= vbCrLf
        '抽出
        Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        ObjDb.SQL = strSQL01
        objDataSet.Clear()
        strDataSetName = "TPRG_TRK_BUF"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        objRow = objDataSet.Tables(strDataSetName).Rows(0)
        If 0 < TO_INTEGER(objRow(0)) Then
            Throw New UserException("変更前もしくは変更後のグループ№に関連する出庫トラッキングが存在します。", False)
        End If


    End Sub

    '''' *******************************************************************************************************************
    '''' <summary>
    '''' ﾄﾗｯｷﾝｸﾞ数ﾁｪｯｸ01(ｺﾝﾍﾞﾔ用途設定、ﾊﾞｰｽ割付ｺﾝﾍﾞﾔ設定で使用)
    '''' </summary>
    '''' <remarks></remarks>
    '''' *******************************************************************************************************************
    'Public Sub CheckTrkBufCount01()
    '    'Dim intRet As RetCode                 '戻り値
    '    'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


    '    '************************************************
    '    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ               ﾁｪｯｸ
    '    '************************************************
    '    Dim strSQL01 As String = ""       'SQL文
    '    strSQL01 &= vbCrLf & " SELECT "
    '    strSQL01 &= vbCrLf & "    COUNT(*) "
    '    strSQL01 &= vbCrLf & " FROM "
    '    strSQL01 &= vbCrLf & "    TPRG_TRK_BUF "
    '    strSQL01 &= vbCrLf & " WHERE "
    '    strSQL01 &= vbCrLf & "    1 = 1 "
    '    strSQL01 &= vbCrLf & "    AND FTRK_BUF_NO NOT IN (" & TO_STRING(FTRK_BUF_NO_J9000) & "," & TO_STRING(FTRK_BUF_NO_J9100) & "," & TO_STRING(FTRK_BUF_NO_J9200) & ") "
    '    strSQL01 &= vbCrLf & "    AND FPALLET_ID IS NOT NULL "
    '    strSQL01 &= vbCrLf
    '    '抽出
    '    Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
    '    Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
    '    Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
    '    ObjDb.SQL = strSQL01
    '    objDataSet.Clear()
    '    strDataSetName = "TPRG_TRK_BUF"
    '    ObjDb.GetDataSet(strDataSetName, objDataSet)
    '    objRow = objDataSet.Tables(strDataSetName).Rows(0)
    '    If 0 < TO_INTEGER(objRow(0)) Then
    '        Throw New UserException("自動倉庫、平置き、検品ｴﾘｱ以外にﾄﾗｯｷﾝｸﾞが存在しています。ﾄﾗｯｷﾝｸﾞﾒﾝﾃﾅﾝｽ画面でﾒﾝﾃﾅﾝｽして下さい。", False)
    '    End If


    'End Sub
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞｷｬﾝｾﾙで、出荷指示.出荷引当梱数を元に戻す                                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞｷｬﾝｾﾙで、出荷指示.出荷引当梱数を元に戻す
    ''' </summary>
    ''' <param name="strFPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Update_XSYUKKA_KON_RESERVE_Minus(ByVal strFPALLET_ID As String)
        Try

            Dim intRet As RetCode                 '戻り値
            'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


            '************************************************
            '出荷指示詳細       取得
            '************************************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            objTRST_STOCK.FPALLET_ID = strFPALLET_ID        'ﾊﾟﾚｯﾄID
            objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)       '取得


            '************************************************
            '在庫引当情報       取得
            '************************************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
            objTSTS_HIKIATE.FPALLET_ID = strFPALLET_ID          'ﾊﾟﾚｯﾄID
            objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET()           '取得


            '************************************************
            '出荷指示詳細       取得
            '************************************************
            Dim objXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
            objXPLN_OUT_DTL.FPLAN_KEY = objTSTS_HIKIATE.FPLAN_KEY       '計画ｷｰ
            intRet = objXPLN_OUT_DTL.GET_XPLN_OUT_DTL(False)            '取得
            If intRet = RetCode.OK Then
                '(見つかった場合)


                '************************************************
                '出荷引当梱数       更新
                '************************************************
                objXPLN_OUT_DTL.XSYUKKA_KON_RESERVE = objXPLN_OUT_DTL.XSYUKKA_KON_RESERVE - objTRST_STOCK.ARYME(0).FTR_RES_VOL      '出荷引当梱数
                objXPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()


            End If


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region


    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/11/14 搬送完了しないトラッキングのチェック
#Region "  搬送完了しないﾄﾗｯｷﾝｸﾞのﾁｪｯｸ                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 搬送完了しないﾄﾗｯｷﾝｸﾞのﾁｪｯｸ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub CheckConveyanceTime()
        Try
            Dim intRet As RetCode
            Dim strSQL As String                'SQL文
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

            '(猶予時間の取得)
            Dim intInterval As Integer = 0
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)     'ｼｽﾃﾑ変数ｸﾗｽ
            objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSJ000000_044                     '変数ID
            intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                         '取得
            If intRet = RetCode.OK Then
                intInterval = objTPRG_SYS_HEN.FHENSU_INT
            End If

            '時間範囲が指定されている場合、判定処理を行う
            If intInterval > 0 Then
                '***********************
                '抽出SQL作成
                '***********************
                strSQL = ""
                strSQL &= vbCrLf & "         SELECT "
                strSQL &= vbCrLf & "            * "
                strSQL &= vbCrLf & "         FROM"
                strSQL &= vbCrLf & "            TPRG_TRK_BUF"
                strSQL &= vbCrLf & "         WHERE"
                strSQL &= vbCrLf & "                FTRK_BUF_NO IN(" & TO_STRING(FTRK_BUF_NO_J3101)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(1F入庫中)
                strSQL &= vbCrLf & "                              ," & TO_STRING(FTRK_BUF_NO_J3102)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(2F入庫中)
                strSQL &= vbCrLf & "                              ," & TO_STRING(FTRK_BUF_NO_J3201)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(1F出庫中)
                strSQL &= vbCrLf & "                              ," & TO_STRING(FTRK_BUF_NO_J3202)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(2F出庫中)
                strSQL &= vbCrLf & "                              ," & TO_STRING(FTRK_BUF_NO_J3301)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(1F入庫搬送中)
                strSQL &= vbCrLf & "                              ," & TO_STRING(FTRK_BUF_NO_J3302)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(2F入庫搬送中)
                strSQL &= vbCrLf & "                              ," & TO_STRING(FTRK_BUF_NO_J3401)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(1F出庫搬送中)
                strSQL &= vbCrLf & "                              ," & TO_STRING(FTRK_BUF_NO_J3402) & ")"   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(2F出庫搬送中)
                strSQL &= vbCrLf & "            AND FPALLET_ID IS NOT NULL"                                 'ﾊﾟﾚｯﾄID
                strSQL &= vbCrLf & "         ORDER BY "
                strSQL &= vbCrLf & "            FBUF_IN_DT"
                strSQL &= vbCrLf

                '***********************
                '抽出
                '***********************
                ObjDb.SQL = strSQL
                objDataSet.Clear()
                strDataSetName = "TPRG_TRK_BUF"
                ObjDb.GetDataSet(strDataSetName, objDataSet)

                If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                    For Each objRow As DataRow In objDataSet.Tables(strDataSetName).Rows
                        '(時刻の判定)
                        Dim dtmButInDt As Date
                        Dim dtmLimitDt As Date
                        dtmButInDt = TO_DATE(objRow("FBUF_IN_DT"))
                        dtmLimitDt = DateAdd(DateInterval.Minute, intInterval, dtmButInDt)
                        If Now > dtmLimitDt Then
                            'ﾒｯｾｰｼﾞ出力
                            Call AddToMsgLog(Now, FMSG_ID_J4002, "ﾄﾗｯｷﾝｸﾞﾃﾞｰﾀを確認して、強制完了等の操作を行って下さい。" _
                                                               , "[搬送元:" & TO_STRING(objRow("FDISP_ADDRESS_FM")) & "]" & _
                                                                 "[搬送先:" & TO_STRING(objRow("FDISP_ADDRESS_TO")) & "]" _
                                                               , "[搬送指令時刻:" & TO_DATE(objRow("FBUF_IN_DT")).ToString("HH:mm:ss") & "]" _
                                                               , "[ﾊﾟﾚｯﾄID:" & TO_STRING(objRow("FPALLET_ID")) & "]" _
                                                               )
                        Else
                            Exit For
                        End If
                    Next
                End If
            End If

        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
    'JobMate:S.Ouchi 2013/11/14 搬送完了しないトラッキングのチェック
    '↑↑↑↑↑↑************************************************************************************************************

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
