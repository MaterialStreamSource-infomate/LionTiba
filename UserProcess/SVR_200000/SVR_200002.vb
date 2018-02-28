'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾛｸﾞｲﾝ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_200002
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0         '端末ID
    Private Const DSPUSER_ID As Integer = 1         'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2          '理由
    Private Const DSPLOGIN_ID As Integer = 3        'ﾛｸﾞｲﾝﾕｰｻﾞｰID
    Private Const DSPPASS_WORD As Integer = 4       'ﾊﾟｽﾜｰﾄﾞ

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
        Dim strDenbunDtl(0) As String          '電文分解配列
        Dim strDenbunDtlName(0) As String      '電文分解名称配列
        Dim strDenbunInfo As String = ""       '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        Dim intRet As Integer                  '戻り値
        Dim strMsg As String                   'ﾒｯｾｰｼﾞ
        Dim strMsg2 As String = ""              '付加ﾒｯｾｰｼﾞ

        Try


            '************************
            '初期処理
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)


            '************************
            'ﾊﾟｽﾜｰﾄﾞ入替(ﾛｸﾞに*******を表示するため、ﾊﾟｽﾜｰﾄﾞ入替えする)
            '************************
            Dim strPassWord As String = strDenbunDtl(DSPPASS_WORD)
            strDenbunDtl(DSPPASS_WORD) = FPASS_WORD_SKOTEI              '固定値ﾊﾟｽﾜｰﾄﾞ


            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call CheckBeforeAct(strDenbunDtl)
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 'ｼｽﾃﾑ変数




            Dim strLOG_DATA_OPE As String = ""    '作業詳細
            Dim blnCheckOK As Boolean = False       'ﾛｸﾞｲﾝOKﾁｪｯｸOKﾌﾗｸﾞ(False:ﾁｪｯｸNG　True:ﾁｪｯｸOK
            strMsg = DEFAULT_STRING
            Try

                '*******************************************************
                ' 端末名取得
                '*******************************************************
                Dim udtRet As RetCode
                Dim TDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)
                TDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)               '端末ID     ｾｯﾄ
                udtRet = TDSP_TERM.GET_TDSP_TERM(False)                      '情報取得
                If udtRet = RetCode.NotFound Then
                    strMsg = FRM_MSG_FRM100001_02
                    strLOG_DATA_OPE = FLOG_DATA_OPE_SEND_ERR & "[" & strMsg & "]"
                    Exit Try
                End If
                If TDSP_TERM.FTERM_CUT_STS = FTERM_CUT_STS_SON Then
                    strMsg = FRM_MSG_FRM100001_11
                    strLOG_DATA_OPE = FLOG_DATA_OPE_SEND_ERR & "[" & strMsg & "]"
                    Exit Try
                End If


                '************************
                'ﾛｸﾞｲﾝﾕｰｻﾞｰ特定
                '************************
                Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)   'ﾕｰｻﾞｰﾏｽﾀ
                objTMST_USER.FUSER_ID = strDenbunDtl(DSPLOGIN_ID)               'ﾕｰｻﾞID
                intRet = objTMST_USER.GET_TMST_USER(False)                      '特定
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)

                    strMsg = FRM_MSG_FRM100001_02
                    strLOG_DATA_OPE = FLOG_DATA_OPE_SEND_ERR & "[" & strMsg & "]"
                    Exit Try

                End If


                If objTMST_USER.FUSER_ATEST <> FUSER_ATEST_SNORMAL Then
                    '(ﾛｯｸされている場合)
                    strMsg2 = FRM_MSG_FRM100001_24
                End If

                '************************
                'ﾕｰｻﾞｰﾁｪｯｸ
                '************************
                If objTMST_USER.FUSER_ATEST = FUSER_ATEST_SPASS_ORVER Then
                    '(ﾊﾟｽﾜｰﾄﾞ有効期限超過ﾛｯｸの場合)

                    strMsg = FRM_MSG_FRM100001_20
                    strLOG_DATA_OPE = FLOG_DATA_OPE_SEND_ERR & "[" & strMsg & "]"
                    Exit Try

                ElseIf objTMST_USER.FUSER_ATEST = FUSER_ATEST_SPASS_DIF Then
                    '(ﾊﾟｽﾜｰﾄﾞ不一致回数ｵｰﾊﾞｰﾛｯｸの場合)

                    strMsg = FRM_MSG_FRM100001_21
                    strLOG_DATA_OPE = FLOG_DATA_OPE_SEND_ERR & "[" & strMsg & "]"
                    Exit Try

                ElseIf objTMST_USER.FUSER_ATEST = FUSER_ATEST_SID_NON Then
                    '(未登録ｱｸｾｽﾛｯｸの場合)

                    strMsg = FRM_MSG_FRM100001_02
                    strLOG_DATA_OPE = FLOG_DATA_OPE_SEND_ERR & "[" & strMsg & "]"
                    Exit Try

                ElseIf objTMST_USER.FUSER_ATEST = FUSER_ATEST_SUSER_ORVER Then
                    '(ﾕｰｻﾞ有効期限超過ﾛｯｸの場合)

                    strMsg = FRM_MSG_FRM100001_22
                    strLOG_DATA_OPE = FLOG_DATA_OPE_SEND_ERR & "[" & strMsg & "]"
                    Exit Try

                ElseIf objTPRG_SYS_HEN.SS000000_013 <> 0 _
                       And DateAdd(DateInterval.Day, TO_INTEGER(objTPRG_SYS_HEN.SS000000_013), TO_DATE(objTMST_USER.FPASS_WORDUP_DT)) < Now _
                       Then
                    '(ﾊﾟｽﾜｰﾄﾞ有効期限超過ﾛｯｸの場合)

                    strMsg = FRM_MSG_FRM100001_20
                    strLOG_DATA_OPE = FLOG_DATA_OPE_SEND_ERR & "[" & strMsg & "]"
                    Exit Try

                ElseIf objTMST_USER.FPASS_WORD <> strPassWord And IsNull(objTMST_USER.FPASS_WORD) = False Then

                    '(ﾊﾟｽﾜｰﾄﾞ不一致の場合)
                    '(新規の場合：ﾊﾟｽﾜｰﾄﾞとﾕｰｻﾞIDが同じになっている)
                    '============================
                    'ﾚｺｰﾄﾞ更新
                    '============================
                    If objTPRG_SYS_HEN.SS000000_012 <> 0 Then
                        '(ﾊﾟｽﾜｰﾄﾞ不一致回数ﾁｪｯｸが有効の場合)

                        If (objTPRG_SYS_HEN.SS000000_012 - 1) <= objTMST_USER.FWARNING_COUNT Then
                            '(ﾊﾟｽﾜｰﾄﾞ不一致回数ｵｰﾊﾞｰの場合)
                            objTMST_USER.FUSER_ATEST = FUSER_ATEST_SPASS_DIF         'ﾕｰｻﾞｰ認証状況
                            objTMST_USER.FLOCK_DT = Now                             'ﾛｯｸ日時
                        End If
                        objTMST_USER.FWARNING_COUNT = TO_INTEGER(objTMST_USER.FWARNING_COUNT) + 1   '不正ｱｸｾｽ回数
                        objTMST_USER.FUPDATE_DT = Now                                               '更新日時
                        objTMST_USER.FUPDATE_USER_ID = strDenbunDtl(DSPLOGIN_ID)                    '更新ﾕｰｻﾞｰID
                        objTMST_USER.FUPDATE_TERM_ID = strDenbunDtl(DSPTERM_ID)                     '更新端末ID
                        objTMST_USER.UPDATE_TMST_USER()                                             '更新

                    End If

                    strMsg = FRM_MSG_FRM100001_01
                    strLOG_DATA_OPE = FLOG_DATA_OPE_SEND_ERR & "[" & strMsg & "]"

                    Exit Try

                ElseIf objTMST_USER.FPASS_WORD = objTMST_USER.FUSER_ID _
                   And objTPRG_SYS_HEN.SS000000_014 = FLAG_ON _
                   Then
                    '(ﾊﾟｽﾜｰﾄﾞとﾕｰｻﾞIDが同じになっている)

                    strMsg = FRM_MSG_FRM100001_19
                    strLOG_DATA_OPE = FLOG_DATA_OPE_SEND_ERR & "[" & strMsg & "]"

                    Exit Try

                End If


                '============================
                '不正ｱｸｾｽ回数ｸﾘｱ
                '============================
                objTMST_USER.FWARNING_COUNT = 0                                             '不正ｱｸｾｽ回数
                objTMST_USER.FUPDATE_DT = Now                                               '更新日時
                objTMST_USER.FUPDATE_USER_ID = strDenbunDtl(DSPLOGIN_ID)                        '更新ﾕｰｻﾞｰID
                objTMST_USER.FUPDATE_TERM_ID = strDenbunDtl(DSPTERM_ID)                     '更新端末ID
                objTMST_USER.UPDATE_TMST_USER()                                             '更新


                '************************
                '新規ﾊﾟｽﾜｰﾄﾞ登録
                '************************
               
                If objTMST_USER.FUSER_ATEST = FUSER_ATEST_SNORMAL And _
                IsNull(objTMST_USER.FPASS_WORD) = True And _
                IsNothing(objTMST_USER.FLOCK_DT) = True Then
                    '(ﾊﾟｽﾜｰﾄﾞが登録されていない場合)
                    '============================
                    'ﾚｺｰﾄﾞ更新
                    '============================
                    objTMST_USER.FPASS_WORD = strPassWord                       'ﾊﾟｽﾜｰﾄﾞ
                    objTMST_USER.FPASS_WORDUP_DT = Now                          'ﾊﾟｽﾜｰﾄﾞ更新日時
                    objTMST_USER.FUPDATE_DT = Now                               '更新日時
                    objTMST_USER.FUPDATE_USER_ID = strDenbunDtl(DSPLOGIN_ID)    '更新ﾕｰｻﾞｰID
                    objTMST_USER.FUPDATE_TERM_ID = strDenbunDtl(DSPTERM_ID)     '更新端末ID
                    objTMST_USER.UPDATE_TMST_USER()                             '更新

                End If

                blnCheckOK = True


               
                Dim dtLimitDateDisp As Date = DateAdd(DateInterval.Day, TO_INTEGER(objTPRG_SYS_HEN.SS000000_013) - (TO_INTEGER(objTPRG_SYS_HEN.SS000000_015)), TO_DATE(objTMST_USER.FPASS_WORDUP_DT))
                Dim dtLimitDate As Date = DateAdd(DateInterval.Day, TO_INTEGER(objTPRG_SYS_HEN.SS000000_013), TO_DATE(objTMST_USER.FPASS_WORDUP_DT))

                If objTPRG_SYS_HEN.SS000000_015 <> 0 And dtLimitDateDisp < Now Then
                    '(ﾊﾟｽﾜｰﾄﾞ有効期限切れ間近のとき)
                    Dim intKikan As Integer = DateDiff(DateInterval.Day, Now, dtLimitDate)
                    strMsg = FRM_MSG_FRM100001_25 & intKikan & FRM_MSG_FRM100001_26
                    Exit Try
                End If


            Catch ex_1 As UserException
                Call ComError(ex_1, MeSyoriID)
                Throw ex_1

            End Try


            '************************
            '正常完了
            '************************
            If blnCheckOK = True Then
                '(ﾛｸﾞｲﾝ可の場合)

                If strMsg <> DEFAULT_STRING Then
                    '(ﾒｯｾｰｼﾞがあるとき)
                    Call MakeMessageGamenMessage(objTelegramSend, strMSG_SEND, strMsg)
                Else
                    '(ﾒｯｾｰｼﾞがないとき)
                    Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
                End If

                Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
            Else
                '(ﾛｸﾞｲﾝ不可の場合)
                strMsg &= vbCrLf & strMsg2
                Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, strMsg)
                Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, strLOG_DATA_OPE)    'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ書き込み
            End If

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
                ' ''ElseIf strDenbunDtl(DSPUSER_ID) = DEFAULT_STRING Then
                ' ''    strMsg = ERRMSG_DISP_SOCKET & "[ﾕｰｻﾞｰID]"
                ' ''    Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPLOGIN_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[ﾛｸﾞｲﾝﾕｰｻﾞｰID]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPPASS_WORD) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[ﾊﾟｽﾜｰﾄﾞ]"
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

End Class
