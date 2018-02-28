'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】noto2てすと
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports MateCommon                         'SystemConfig使用の為
Imports MateCommon.clsConst                  'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
Imports JobCommon
#End Region

Public Class SVR_999999
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
#Region "  テスト                                                                               "

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' てすと
    ''' </summary>
    ''' <param name="strMSG_RECV">要求ﾒｯｾｰｼﾞ</param>
    ''' <param name="strMSG_SEND">応答ﾒｯｾｰｼﾞ</param>
    ''' <returns>正常終了：0 異常終了：1</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Try

            Dim intRet As RetCode = RetCode.NG


            ' '' ''*****************************************
            ' '' ''ｸﾚｰﾝ優先順ﾃｽﾄ
            ' '' ''*****************************************
            '' ''Dim objSVR_100204 As New SVR_100204(Owner, ObjDb, ObjDbLog)     'ｸﾚｰﾝ優先順取得ｸﾗｽ
            '' ''objSVR_100204.FTRK_BUF_NO = 9009                                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            '' ''objSVR_100204.CRANE_ORDER_GET()                                 '取得
            '' ''intRet = RetCode.OK
            '' ''Dim objSVR_100205 As New SVR_100205(Owner, ObjDb, ObjDbLog)     'ｸﾚｰﾝ優先順更新ｸﾗｽ
            '' ''objSVR_100205.FTRK_BUF_NO = 9009                                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            '' ''objSVR_100205.FEQ_ID = objSVR_100204.FEQ_ID(3)                  '使用設備ID
            '' ''objSVR_100205.CRANE_ORDER_UPDATE()                              '更新
            '' ''Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)             'ｼｽﾃﾑ変数ｸﾗｽ
            '' ''objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SS000000_003_ & TO_STRING(9009)          '変数ID
            '' ''intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(False)                                '取得
            '' ''intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(False)                                '取得


            ' '' ''*****************************************
            ' '' ''ﾒｯｾｰｼﾞﾛｸﾞ出力ﾃｽﾄ
            ' '' ''*****************************************
            '' ''Call AddToMsgLog(Now, FMSG_ID_0003)


            ' '' ''*****************************************
            ' '' ''ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ出力ﾃｽﾄ
            ' '' ''*****************************************
            '' ''For ii As Integer = 1 To 1000000
            '' ''    Call AddToTrnLog("TEST1", "TEST2", MeSyoriID, Format(Now, "yyyy/MM/dd HH:mm:ss.ffffff"))
            '' ''    intRet = RetCode.OK
            '' ''Next


            '*****************************************
            'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞｻｲｸﾘｯｸ用ﾚｺｰﾄﾞ作成
            '*****************************************
            Dim objTLOG_TRNS As New TBL_TLOG_TRNS(Owner, ObjDbLog, ObjDbLog)                    'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞｸﾗｽ
            objTLOG_TRNS.FUSER_ID = "1"              'ﾕｰｻﾞｰID
            objTLOG_TRNS.FTERM_ID = "1"             '端末ID
            objTLOG_TRNS.FSYORI_ID = "1"            '処理ID
            objTLOG_TRNS.FMSG_PRM1 = Nothing        'ﾊﾟﾗﾒｰﾀ1
            objTLOG_TRNS.FMSG_PRM2 = Nothing        'ﾊﾟﾗﾒｰﾀ2
            objTLOG_TRNS.FMSG_PRM3 = Nothing        'ﾊﾟﾗﾒｰﾀ3
            objTLOG_TRNS.FMSG_PRM4 = Nothing        'ﾊﾟﾗﾒｰﾀ4
            objTLOG_TRNS.FMSG_PRM5 = Nothing        'ﾊﾟﾗﾒｰﾀ5
            ObjDbLog.BeginTrans()
            'For ii As Integer = 101 To 1000000
            For ii As Integer = 1 To 1000000
                objTLOG_TRNS.FLOG_NO_CYCLIC = ii    'ｻｲｸﾘｯｸﾛｸﾞ№
                objTLOG_TRNS.FHASSEI_DT = Now           '発生日時
                objTLOG_TRNS.FLOG_DATA_TRN = Format(Now, "yyyy/MM/dd HH:mm:ss.ffffff")          'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞﾃﾞｰﾀ
                objTLOG_TRNS.ADD_TLOG_TRNS()            '登録
            Next
            ObjDbLog.Commit()


            ' '' ''*****************************************
            ' '' ''問合せ出庫受付
            ' '' ''*****************************************
            '' ''intRet = TEST400002()
            '' ''Return intRet


            ' '' ''************************
            ' '' ''ﾙｰﾄ設備ﾁｪｯｸﾃｽﾄ
            ' '' ''************************
            '' ''Dim strMsg As String
            '' ''Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '在庫引当情報ｸﾗｽ
            '' ''objTSTS_HIKIATE.FPALLET_ID = "0000000000000000"                     'ﾊﾟﾚｯﾄID
            '' ''intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                    '特定
            '' ''If intRet = RetCode.NotFound Then
            '' ''    '(見つからない場合)
            '' ''    strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[ﾊﾟﾚｯﾄID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
            '' ''    Throw New UserException(strMsg)
            '' ''End If

            '' ''Dim objSVR_100203 As New SVR_100203(Owner, ObjDb, ObjDbLog)
            '' ''objSVR_100203.FBUF_FM = 1101                        '元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            '' ''objSVR_100203.FBUF_TO = 9100                        '先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            '' ''objSVR_100203.FEQ_ID_CRANE_FM = 999999              '元ｸﾚｰﾝ設備ID
            '' ''objSVR_100203.FEQ_ID_CRANE_TO = "CRN1001"           '先ｸﾚｰﾝ設備ID
            '' ''intRet = objSVR_100203.CHECK_ROUTE(objTSTS_HIKIATE)
            '' ''If intRet = RetCode.NG Then
            '' ''    '(ｴﾗｰの場合)

            '' ''End If


            ' '' ''**********************************
            ' '' ''在庫引当ﾃｽﾄ
            ' '' ''**********************************
            '' ''Dim strMsg As String
            '' ''Dim objSVR_100202 As New SVR_100202(Owner, ObjDb, ObjDbLog)     '在庫引当ｸﾗｽ
            '' ''objSVR_100202.FTRK_BUF_NO = FTRK_BUF_NO_SOUKO_GENRYOU           'ﾊﾞｯﾌｧ№(原紙倉庫)
            '' ''objSVR_100202.INTMaxPlt = 2                                     '最大引当ﾊﾟﾚｯﾄ数
            '' ''objSVR_100202.FHINMEI_CD = "aaa"                                '品名ｺｰﾄﾞ
            '' ''objSVR_100202.INTUpdateMode = SVR_100202.UpdateMode.CHANGE_ALL  '更新ﾓｰﾄﾞ(通常)
            '' ''objSVR_100202.FEQ_ID_CRN = "CRN1001"                            'ｸﾚｰﾝ指定
            '' ''intRet = objSVR_100202.FIND_STOCK(2)                            '在庫引当
            '' ''If intRet = RetCode.NotFound Then
            '' ''    '(見つからない場合)
            '' ''    strMsg = ERRMSG_NOTFOUND_SYS_100202 & "[ﾊﾟﾚｯﾄID:" & objSVR_100202.FPALLET_ID & "]"
            '' ''    Throw New UserException(strMsg)
            '' ''End If


            ' '' ''**********************************
            ' '' ''棚番変更
            ' '' ''**********************************
            '' ''Dim strSQL As String
            '' ''strSQL = ""
            '' ''strSQL &= vbCrLf & " SELECT "
            '' ''strSQL &= vbCrLf & "    *"
            '' ''strSQL &= vbCrLf & " FROM "
            '' ''strSQL &= vbCrLf & "    TPRG_TRK_BUF "
            '' ''strSQL &= vbCrLf & " WHERE "
            '' ''strSQL &= vbCrLf & "        1 = 1 "
            '' ''strSQL &= vbCrLf & "    AND FTRK_BUF_NO = 9000 "
            '' ''strSQL &= vbCrLf & "    AND FRAC_RETU IN (3, 4) "
            '' ''strSQL &= vbCrLf & " ORDER BY "
            '' ''strSQL &= vbCrLf & "    FRAC_RETU "
            '' ''strSQL &= vbCrLf & "  , FRAC_REN "
            '' ''strSQL &= vbCrLf & "  , FRAC_DAN "
            '' ''strSQL &= vbCrLf
            '' ''Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            '' ''objTPRG_TRK_BUF.USER_SQL = strSQL
            '' ''objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_USER()
            '' ''For ii As Integer = LBound(objTPRG_TRK_BUF.ARYME) To UBound(objTPRG_TRK_BUF.ARYME)
            '' ''    '(ﾙｰﾌﾟ:更新する行数)

            '' ''    If objTPRG_TRK_BUF.ARYME(ii).FRAC_RETU = 3 Then
            '' ''        '(列が3の場合)
            '' ''        objTPRG_TRK_BUF.ARYME(ii).FTRNS_ADDRESS = "01"
            '' ''        objTPRG_TRK_BUF.ARYME(ii).FTRNS_ADDRESS &= ZERO_PAD(TO_INTEGER(objTPRG_TRK_BUF.ARYME(ii).FRAC_REN), 3)
            '' ''        objTPRG_TRK_BUF.ARYME(ii).FTRNS_ADDRESS &= ZERO_PAD(TO_INTEGER(objTPRG_TRK_BUF.ARYME(ii).FRAC_DAN), 2)
            '' ''    ElseIf objTPRG_TRK_BUF.ARYME(ii).FRAC_RETU = 4 Then
            '' ''        '(列が4の場合)
            '' ''        objTPRG_TRK_BUF.ARYME(ii).FTRNS_ADDRESS = "02"
            '' ''        objTPRG_TRK_BUF.ARYME(ii).FTRNS_ADDRESS &= ZERO_PAD(TO_INTEGER(objTPRG_TRK_BUF.ARYME(ii).FRAC_REN), 3)
            '' ''        objTPRG_TRK_BUF.ARYME(ii).FTRNS_ADDRESS &= ZERO_PAD(TO_INTEGER(objTPRG_TRK_BUF.ARYME(ii).FRAC_DAN), 2)
            '' ''    End If
            '' ''    objTPRG_TRK_BUF.ARYME(ii).UPDATE_TPRG_TRK_BUF()

            '' ''Next



        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Return RetCode.NG
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Return RetCode.NG
        End Try

    End Function

#End Region
#Region "  テスト                                                                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' テスト
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ExecCmdFunction(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV)
        Try

            '************************
            '応答ｺｰﾄﾞを更新
            '************************
            objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SEND
            objTLIF_TRNS_RECV.FRES_CD_EQ = 1
            objTLIF_TRNS_RECV.FENTRY_DT = Now
            objTLIF_TRNS_RECV.FUPDATE_DT = Now
            objTLIF_TRNS_RECV.UPDATE_TLIF_TRNS_RECV()


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
#Region "  テスト400002:問合せ出庫受付                                                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' テスト400002:問合せ出庫受付
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function TEST400002() As RetCode
        Try

            Dim strMsg As String
            Dim intRet As RetCode
            Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP)


            '*************************
            '電文作成
            '*************************
            objTelegramSend.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S201102
            objTelegramSend.SETIN_HEADER("DSPTERM_ID", FTERM_ID_SKOTEI)
            objTelegramSend.SETIN_HEADER("DSPUSER_ID", FUSER_ID_SKOTEI)
            objTelegramSend.SETIN_DATA("DSPPALLET_ID", "P-20090127000001")      'ﾊﾟﾚｯﾄID	
            objTelegramSend.SETIN_DATA("DSPST_OUT", "101")                      '出庫先ST
            objTelegramSend.MAKE_TELEGRAM()
            strMsg = objTelegramSend.TELEGRAM_MAKED

            Dim objSVR_400002 As New SVR_201601(Owner, ObjDb, ObjDbLog)
            intRet = objSVR_400002.ExecCmd(strMsg, "")
            If intRet = RetCode.NG Then
                Return RetCode.NG
            End If


            Return RetCode.OK
        Catch ex As UserException
            Return RetCode.NG
        Catch ex As Exception
            Return RetCode.NG
        End Try
    End Function
#End Region

End Class
