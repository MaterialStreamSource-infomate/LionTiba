'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】設備ｵﾝﾗｲﾝ設定
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_200301
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0         '端末ID
    Private Const DSPUSER_ID As Integer = 1         'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2          '理由
    Private Const DSPEQ_ID As Integer = 3           '設備ID
    Private Const DSPEQ_CUT_STS As Integer = 4      '切離状態
    Private Const DSPRESEND As Integer = 5          '再送信ﾌﾗｸﾞ

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
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
        Dim strDenbunDtl(0) As String         '電文分解配列
        Dim strDenbunDtlName(0) As String     '電文分解名称配列
        Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        Dim intRet As Integer                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        Try


            '************************
            '初期処理
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call CheckBeforeAct(strDenbunDtl)


            '************************
            '設備状況の特定
            '************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog) '設備状況ｸﾗｽ
            objTSTS_EQ_CTRL.FEQ_ID = strDenbunDtl(DSPEQ_ID)                     '設備ID
            intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)                     '特定


            '************************
            '設備状況の更新
            '************************
            objTSTS_EQ_CTRL.FEQ_CUT_STS = TO_INTEGER(strDenbunDtl(DSPEQ_CUT_STS))   '切離状態
            objTSTS_EQ_CTRL.FUPDATE_DT = Now                '更新日時
            objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()           '更新


            '************************
            '電文送信処理
            '************************
            Call TelegramSendProcess(strDenbunDtl)


            '************************
            '正常完了
            '************************
            Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
            Return RetCode.OK


        Catch ex As UserException
            Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ex.Message)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
            Call ComUser(ex, MeSyoriID)
            Return RetCode.NG
        Catch ex As Exception
            Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ERRMSG_DISP_ERR)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
            Call ComError(ex, MeSyoriID)
            Return RetCode.NG
        End Try
    End Function

#End Region
#Region "  事前ﾁｪｯｸ                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 事前ﾁｪｯｸ
    ''' </summary>
    ''' <param name="strDenbunDtl">電文内容構造体</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub CheckBeforeAct(ByVal strDenbunDtl() As String)
        Try
            'Dim intRet As Integer                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '************************
            '値漏れﾁｪｯｸ
            '************************
            If 1 = 1 Then
            ElseIf strDenbunDtl(DSPTERM_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[端末ID]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPUSER_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[ﾕｰｻﾞｰID]"
                Throw New UserException(strMsg)
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

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  ｵﾝﾗｲﾝ電文送信処理        "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｵﾝﾗｲﾝ電文送信処理
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub TelegramSendProcess(ByVal strDenbunDtl() As String)
        Try
            '↓↓↓↓↓↓************************************************************************************************************
            'Checked Comment:A.Noto 2013/03/21 ﾌﾟﾛｸﾞﾗﾑ整理時のｺﾒﾝﾄｱｳﾄ

            '    Dim strSQL As String        'SQL文
            '    Dim strMsg As String        'ﾒｯｾｰｼﾞ
            '    'Dim intRet As Integer       '戻り値
            '    Dim intRetSQL As Integer    'SQL実行戻り値
            '    Dim intCount As Integer     '取得ﾚｺｰﾄﾞ数
            '    Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)     'ｼｽﾃﾑ変数ｸﾗｽ


            '    '**********************************
            '    'ﾃｷｽﾄID作成
            '    '**********************************
            '    Dim strFTEXT_ID As String = ""      'ﾃｷｽﾄID
            '    Dim strFDENBUN As String = ""       '電文

            '    '↓↓↓↓↓↓************************************************************************************************************
            '    'Amendment:N.Dounoshita 2012/04/06 ｵﾝﾗｲﾝ電文送信処理

            '    'Select Case strDenbunDtl(DSPEQ_ID)
            '    '    Case FEQ_ID_JSYS0001, FEQ_ID_JSYS0002
            '    '        Select Case strDenbunDtl(DSPEQ_CUT_STS)
            '    '            Case FLAG_ON : strFTEXT_ID = FTEXT_ID_AGC_03
            '    '            Case FLAG_OFF : strFTEXT_ID = FTEXT_ID_AGC_01
            '    '        End Select
            '    '        'Case FEQ_ID_SYS1001
            '    '        '    'NOP

            '    'End Select

            '    '↑↑↑↑↑↑************************************************************************************************************

            '    '**********************************
            '    '削除復帰
            '    '**********************************
            '    If (strDenbunDtl(DSPEQ_ID) = FEQ_ID_JSYS0001 Or strDenbunDtl(DSPEQ_ID) = FEQ_ID_JSYS0002 Or strDenbunDtl(DSPEQ_ID) = FEQ_ID_JSYS0003) _
            '       And strDenbunDtl(DSPEQ_CUT_STS) = FLAG_OFF Then
            '        '(MCIｵﾝﾗｲﾝの場合)

            '        '↓↓↓↓↓↓************************************************************************************************************
            '        'SystemMate:A.Noto 2012/04/28  ｿｹｯﾄの再送信ﾌﾗｸﾞまたはｼｽﾃﾑ変数にて判別

            '        Dim strReSendFlg As String      '再送信ﾌﾗｸﾞ
            '        strReSendFlg = IIf(IsNull(strDenbunDtl(DSPRESEND)), objTPRG_SYS_HEN.SS000000_011, strDenbunDtl(DSPRESEND))

            '        'If objTPRG_SYS_HEN.SS000000_011 = FLAG_ON Then
            '        If strReSendFlg = FLAG_ON Then
            '            '↑↑↑↑↑↑************************************************************************************************************

            '            '(失敗電文再送信の場合)


            '            '***********************
            '            '搬送制御IF更新
            '            '***********************
            '            '搬送制御送信IF
            '            strSQL = ""
            '            strSQL &= vbCrLf & " UPDATE"
            '            strSQL &= vbCrLf & "    TLIF_TRNS_SEND"
            '            strSQL &= vbCrLf & " SET"
            '            strSQL &= vbCrLf & "    FPROGRESS = " & FPROGRESS_SNON
            '            strSQL &= vbCrLf & "  , FRES_CD_EQ = NULL"
            '            strSQL &= vbCrLf & " WHERE"
            '            strSQL &= vbCrLf & "        (FPROGRESS IN ( " & TO_STRING(FPROGRESS_STRY)
            '            strSQL &= vbCrLf & "                       ," & TO_STRING(FPROGRESS_SERR_MCI)
            '            strSQL &= vbCrLf & "                       ," & TO_STRING(FPROGRESS_SERR_SVR)
            '            strSQL &= vbCrLf & "                       )"
            '            strSQL &= vbCrLf & "         )"
            '            strSQL &= vbCrLf & "    AND FEQ_ID = '" & strDenbunDtl(DSPEQ_ID) & "'"
            '            strSQL &= vbCrLf
            '            strSQL &= vbCrLf
            '            intRetSQL = ObjDb.Execute(strSQL)
            '            If intRetSQL = -1 Then
            '                '(SQLｴﾗｰ)
            '                strSQL = Replace(strSQL, vbCrLf, "")
            '                strMsg = ERRMSG_ERR_DELETE & ObjDb.ErrMsg & "【" & strSQL & "】"
            '                Throw New UserException(strMsg)
            '            End If


            '        Else
            '            '(失敗電文削除の場合)


            '            '***********************
            '            '搬送制御IF削除
            '            '***********************
            '            '搬送制御送信IF
            '            strSQL = ""
            '            strSQL &= vbCrLf & "DELETE"
            '            strSQL &= vbCrLf & " FROM"
            '            strSQL &= vbCrLf & "    TLIF_TRNS_SEND"
            '            strSQL &= vbCrLf & " WHERE"
            '            strSQL &= vbCrLf & "        (FPROGRESS IN ( " & TO_STRING(FPROGRESS_STRY)
            '            strSQL &= vbCrLf & "                       ," & TO_STRING(FPROGRESS_SERR_MCI)
            '            strSQL &= vbCrLf & "                       ," & TO_STRING(FPROGRESS_SERR_SVR)
            '            strSQL &= vbCrLf & "                       )"
            '            strSQL &= vbCrLf & "         )"
            '            strSQL &= vbCrLf & "    AND FEQ_ID = '" & strDenbunDtl(DSPEQ_ID) & "'"
            '            strSQL &= vbCrLf
            '            intRetSQL = ObjDb.Execute(strSQL)
            '            If intRetSQL = -1 Then
            '                '(SQLｴﾗｰ)
            '                strSQL = Replace(strSQL, vbCrLf, "")
            '                strMsg = ERRMSG_ERR_DELETE & ObjDb.ErrMsg & "【" & strSQL & "】"
            '                Throw New UserException(strMsg)
            '            End If

            '            '搬送制御受信IF 
            '            strSQL = ""
            '            strSQL &= vbCrLf & "DELETE"
            '            strSQL &= vbCrLf & " FROM"
            '            strSQL &= vbCrLf & "    TLIF_TRNS_RECV"
            '            strSQL &= vbCrLf & " WHERE"
            '            strSQL &= vbCrLf & "        (FPROGRESS IN ( " & TO_STRING(FPROGRESS_STRY)
            '            strSQL &= vbCrLf & "                       ," & TO_STRING(FPROGRESS_SERR_MCI)
            '            strSQL &= vbCrLf & "                       ," & TO_STRING(FPROGRESS_SERR_SVR)
            '            strSQL &= vbCrLf & "                       )"
            '            strSQL &= vbCrLf & "         )"
            '            strSQL &= vbCrLf & "    AND FEQ_ID = '" & strDenbunDtl(DSPEQ_ID) & "'"
            '            strSQL &= vbCrLf
            '            intRetSQL = ObjDb.Execute(strSQL)
            '            If intRetSQL = -1 Then
            '                '(SQLｴﾗｰ)
            '                strSQL = Replace(strSQL, vbCrLf, "")
            '                strMsg = ERRMSG_ERR_DELETE & ObjDb.ErrMsg & "【" & strSQL & "】"
            '                Throw New UserException(strMsg)
            '            End If

            '        End If

            '        '↓↓↓↓↓↓************************************************************************************************************
            '        'SystemMate:A.Noto 2012/05/07  搬送制御送信IFの登録をｼｽﾃﾑ変数にて判別
            '        If objTPRG_SYS_HEN.SS000000_018 = FLAG_ON Then
            '            '↑↑↑↑↑↑************************************************************************************************************
            '            '**********************************
            '            '搬送制御送信IFの登録
            '            '**********************************
            '            '===========================
            '            '搬送制御送信IFの登録
            '            '===========================
            '            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '搬送制御送信IFｸﾗｽ
            '            objTLIF_TRNS_SEND.FEQ_ID = strDenbunDtl(DSPEQ_ID)                       '設備ID
            '            objTLIF_TRNS_SEND.FCOMMAND_ID = FCOMMAND_ID_SONLINE                      'ｺﾏﾝﾄﾞID
            '            objTLIF_TRNS_SEND.FPALLET_ID = DEFAULT_STRING                           'ﾊﾟﾚｯﾄID
            '            objTLIF_TRNS_SEND.FTEXT_ID = strFTEXT_ID                                'ﾃｷｽﾄID
            '            objTLIF_TRNS_SEND.FDENBUN_PRM1 = DEFAULT_STRING                         '電文ﾊﾟﾗﾒｰﾀ1
            '            objTLIF_TRNS_SEND.FDENBUN_PRM2 = DEFAULT_STRING                         '電文ﾊﾟﾗﾒｰﾀ2
            '            objTLIF_TRNS_SEND.FDENBUN_PRM3 = DEFAULT_STRING                         '電文ﾊﾟﾗﾒｰﾀ3
            '            objTLIF_TRNS_SEND.FDENBUN_PRM4 = DEFAULT_STRING                         '電文ﾊﾟﾗﾒｰﾀ4
            '            objTLIF_TRNS_SEND.FDENBUN_PRM5 = DEFAULT_STRING                         '電文ﾊﾟﾗﾒｰﾀ5
            '            objTLIF_TRNS_SEND.FDENBUN = strFDENBUN                                  '通信電文
            '            intCount = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_COUNT                   'ﾚｺｰﾄﾞ数取得
            '            If intCount = 0 Then
            '                '(未指示の場合)
            '                objTLIF_TRNS_SEND.FPRIORITY = FPRIORITY_SHIGH                        '優先ﾚﾍﾞﾙ
            '                objTLIF_TRNS_SEND.FDENBUN = strFDENBUN                              '通信電文
            '                objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SNON                         '進捗状態
            '                objTLIF_TRNS_SEND.FRES_CD_EQ = DEFAULT_STRING                       '応答ｺｰﾄﾞ
            '                objTLIF_TRNS_SEND.FOFFLINE_FLAG = FLAG_ON                           'ｵﾌﾗｲﾝ送信ﾌﾗｸﾞ
            '                objTLIF_TRNS_SEND.FENTRY_DT = Now                                   '登録日時
            '                objTLIF_TRNS_SEND.FUPDATE_DT = Now                                  '更新日時
            '                objTLIF_TRNS_SEND.ADD_TLIF_TRNS_SEND_SEQ()                          '登録
            '            End If

            '            '↓↓↓↓↓↓************************************************************************************************************
            '            'SystemMate:A.Noto 2012/05/07  搬送制御送信IFの登録をｼｽﾃﾑ変数にて判別
            '        End If
            '        '↑↑↑↑↑↑************************************************************************************************************


            '    End If


            '    '**********************************
            '    'ｵﾌﾗｲﾝ
            '    '**********************************
            '    If (strDenbunDtl(DSPEQ_ID) = FEQ_ID_JSYS0001 Or strDenbunDtl(DSPEQ_ID) = FEQ_ID_JSYS0002 Or strDenbunDtl(DSPEQ_ID) = FEQ_ID_JSYS0003) _
            '       And strDenbunDtl(DSPEQ_CUT_STS) = FLAG_ON Then
            '        '(MCIｵﾝﾗｲﾝの場合)

            '        '↓↓↓↓↓↓************************************************************************************************************
            '        'SystemMate:A.Noto 2012/05/07  搬送制御送信IFの登録をｼｽﾃﾑ変数にて判別
            '        If objTPRG_SYS_HEN.SS000000_019 = FLAG_ON Then
            '            '↑↑↑↑↑↑************************************************************************************************************
            '            '**********************************
            '            '搬送制御送信IFの登録
            '            '**********************************
            '            '===========================
            '            '搬送制御送信IFの登録
            '            '===========================
            '            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '搬送制御送信IFｸﾗｽ
            '            objTLIF_TRNS_SEND.FEQ_ID = strDenbunDtl(DSPEQ_ID)                       '設備ID
            '            objTLIF_TRNS_SEND.FCOMMAND_ID = FCOMMAND_ID_SOFFLINE                     'ｺﾏﾝﾄﾞID(ｵﾌﾗｲﾝ)
            '            objTLIF_TRNS_SEND.FPALLET_ID = DEFAULT_STRING                           'ﾊﾟﾚｯﾄID
            '            objTLIF_TRNS_SEND.FTEXT_ID = strFTEXT_ID                                'ﾃｷｽﾄID
            '            objTLIF_TRNS_SEND.FDENBUN_PRM1 = DEFAULT_STRING                         '電文ﾊﾟﾗﾒｰﾀ1
            '            objTLIF_TRNS_SEND.FDENBUN_PRM2 = DEFAULT_STRING                         '電文ﾊﾟﾗﾒｰﾀ2
            '            objTLIF_TRNS_SEND.FDENBUN_PRM3 = DEFAULT_STRING                         '電文ﾊﾟﾗﾒｰﾀ3
            '            objTLIF_TRNS_SEND.FDENBUN_PRM4 = DEFAULT_STRING                         '電文ﾊﾟﾗﾒｰﾀ4
            '            objTLIF_TRNS_SEND.FDENBUN_PRM5 = DEFAULT_STRING                         '電文ﾊﾟﾗﾒｰﾀ5
            '            objTLIF_TRNS_SEND.FDENBUN = strFDENBUN                                  '通信電文
            '            intCount = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_COUNT                   'ﾚｺｰﾄﾞ数取得
            '            If intCount = 0 Then
            '                '(未指示の場合)
            '                objTLIF_TRNS_SEND.FPRIORITY = FPRIORITY_SHIGH                        '優先ﾚﾍﾞﾙ
            '                objTLIF_TRNS_SEND.FDENBUN = strFDENBUN                              '通信電文
            '                objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SNON                         '進捗状態
            '                objTLIF_TRNS_SEND.FRES_CD_EQ = DEFAULT_STRING                       '応答ｺｰﾄﾞ
            '                objTLIF_TRNS_SEND.FOFFLINE_FLAG = FLAG_ON                           'ｵﾌﾗｲﾝ送信ﾌﾗｸﾞ
            '                objTLIF_TRNS_SEND.FENTRY_DT = Now                                   '登録日時
            '                objTLIF_TRNS_SEND.FUPDATE_DT = Now                                  '更新日時
            '                objTLIF_TRNS_SEND.ADD_TLIF_TRNS_SEND_SEQ()                          '登録
            '            End If

            '            '↓↓↓↓↓↓************************************************************************************************************
            '            'SystemMate:A.Noto 2012/05/07  搬送制御送信IFの登録をｼｽﾃﾑ変数にて判別
            '        End If
            '        '↑↑↑↑↑↑************************************************************************************************************

            '    End If



            '    '**********************************
            '    'その他電文送信処理
            '    '**********************************
            '    Call SpecialProcess(strDenbunDtl)

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
    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
#Region "  その他電文送信処理           "
    '''**********************************************************************************************
    ''' <summary>
    ''' その他電文送信処理
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub SpecialProcess(ByVal strDenbunDtl() As String)
        Try




        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
