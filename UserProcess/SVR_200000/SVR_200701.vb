'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾕｰｻﾞｰﾏｽﾀﾒﾝﾃﾅﾝｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_200701
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0             '端末ID
    Private Const DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2              '理由
    Private Const DSPDIR_KUBUN As Integer = 3           '処理区分
    Private Const DSPMAINTE_USER_ID As Integer = 4      'ﾒﾝﾃﾅﾝｽﾕｰｻﾞｰID
    Private Const DSPMAINTE_LOGIN_ID As Integer = 5     'ﾒﾝﾃﾅﾝｽﾛｸﾞｲﾝID
    Private Const DSPMAINTE_USER_NAME As Integer = 6    'ﾒﾝﾃﾅﾝｽﾕｰｻﾞｰ名
    Private Const DSPUSER_DSP_LEVEL As Integer = 7      'ﾕｰｻﾞ操作ﾚﾍﾞﾙ
    Private Const DSPCHECK As Integer = 8               'ﾁｪｯｸﾎﾞｯｸｽ値


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
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
        Dim strDenbunDtl(0) As String         '電文分解配列
        Dim strDenbunDtlName(0) As String     '電文分解名称配列
        Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        'Dim intRet As Integer                 '戻り値
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
            '分岐処理
            '************************
            Select Case strDenbunDtl(DSPDIR_KUBUN)     '処理区分
                Case FORMAT_DSP_DSPDIR_KUBUN_INSERT
                    '(追加)
                    Call MenteReasonADD(strDenbunDtl)


                Case FORMAT_DSP_DSPDIR_KUBUN_UPDATE
                    '(更新)
                    Call MenteReasonUPDATE(strDenbunDtl)


                Case FORMAT_DSP_DSPDIR_KUBUN_DELETE
                    '(削除)
                    Call MenteReasonDELETE(strDenbunDtl)

            End Select


            '************************
            '正常完了
            '************************
            Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL, strDenbunDtl(DSPREASON))
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
            ElseIf strDenbunDtl(DSPDIR_KUBUN) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[処理区分]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPMAINTE_USER_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[ﾒﾝﾃﾅﾝｽﾕｰｻﾞｰID]"
                Throw New UserException(strMsg)
                '' ''ElseIf strDenbunDtl(DSPMAINTE_USER_NAME) = DEFAULT_STRING Then
                '' ''    strMsg = ERRMSG_DISP_SOCKET & "[ﾒﾝﾃﾅﾝｽﾕｰｻﾞｰ名]"
                '' ''    Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPREASON) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[理由]"
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

#Region "  追加ﾒﾝﾃﾅﾝｽ                                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 追加ﾒﾝﾃﾅﾝｽ
    ''' </summary>
    ''' <param name="strDenbunDtl">電文内容構造体</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MenteReasonADD(ByVal strDenbunDtl() As String)
        Try
            Dim intRet As RetCode                   '戻り値
            ''Dim strMsg As String                    'ﾒｯｾｰｼﾞ

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:J.Kato 2011/10/05 ﾛｸﾞｲﾝID未使用のためｺﾒﾝﾄｱｳﾄ

            ' ''************************
            ' ''ﾛｸﾞｲﾝID重複ﾁｪｯｸ
            ' ''************************
            ''Dim objTMST_USER_CHECK As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)           'ﾕｰｻﾞｰﾏｽﾀ
            ''objTMST_USER_CHECK.FLOGIN_ID = strDenbunDtl(DSPMAINTE_LOGIN_ID)               'ﾕｰｻﾞｰID
            ''intRet = objTMST_USER_CHECK.GET_TMST_USER_FLOGIN_ID()                         '特定
            ''If intRet = RetCode.OK Then
            ''    '(入力されたﾕｰｻﾞｰIDが登録されている場合)
            ''    strMsg = FRM_MSG_FRM206021_06
            ''    Throw New UserException(strMsg)
            ''End If

            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            'ﾕｰｻﾞｰﾏｽﾀ追加
            '************************
            Dim objTMST_USER_After As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            objTMST_USER_After.FUSER_ID = strDenbunDtl(DSPMAINTE_USER_ID)               'ﾕｰｻﾞｰID
            objTMST_USER_After.FLOGIN_ID = strDenbunDtl(DSPMAINTE_LOGIN_ID)             'ﾛｸﾞｲﾝID
            objTMST_USER_After.FPASS_WORD = Nothing                                     'ﾊﾟｽﾜｰﾄﾞ
            objTMST_USER_After.FPASS_WORDUP_DT = Now
            objTMST_USER_After.FUSER_NAME = strDenbunDtl(DSPMAINTE_USER_NAME)           'ﾕｰｻﾞｰ名
            objTMST_USER_After.FENTRY_DT = Now                                          '登録日時
            objTMST_USER_After.FENTRY_USER_ID = strDenbunDtl(DSPUSER_ID)                '登録ﾕｰｻﾞｰID
            objTMST_USER_After.FENTRY_TERM_ID = strDenbunDtl(DSPTERM_ID)                '登録端末ID
            objTMST_USER_After.FUPDATE_DT = Now                                         '更新日時
            objTMST_USER_After.FUPDATE_USER_ID = objTMST_USER_After.FENTRY_USER_ID      '更新ﾕｰｻﾞｰID
            objTMST_USER_After.FUPDATE_TERM_ID = objTMST_USER_After.FENTRY_TERM_ID      '更新端末ID
            objTMST_USER_After.FUSER_ATEST = FUSER_ATEST_SNORMAL                         'ﾕｰｻﾞｰ認証状況
            objTMST_USER_After.FWARNING_COUNT = FLAG_OFF                                '不正ｱｸｾｽ回数
            objTMST_USER_After.FLOCK_DT = Nothing                                       'ﾛｯｸ日時
            objTMST_USER_After.ADD_TMST_USER()                                          '追加


            '************************
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ取得
            '************************
            Dim objTPRG_PARAM_TBL As New TBL_TPRG_PARAM_TBL(Owner, ObjDb, ObjDbLog) 'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ
            objTPRG_PARAM_TBL.FPARA_ID = strDenbunDtl(DSPTERM_ID)       'ﾊﾟﾗﾒｰﾀID
            intRet = objTPRG_PARAM_TBL.GET_TPRG_PARAM_TBL_FPARA_ID()    '特定
            If intRet = RetCode.OK Then
                For ii As Integer = LBound(objTPRG_PARAM_TBL.ARYME) To UBound(objTPRG_PARAM_TBL.ARYME)
                    '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)

                    Dim objTel As New clsTelegram(CONFIG_TELEGRAM_DSP)  '受信用電文
                    objTel.FORMAT_ID = MeDSPID                          'ﾌｫｰﾏｯﾄ名ｾｯﾄ
                    objTel.TELEGRAM_PARTITION = objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA      '分割する電文ｾｯﾄ
                    objTel.PARTITION()                                  '電文分割

                    If objTel.SELECT_DATA("DSPCHECK") = "1" Then
                        '(ﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸが入っていた場合)


                        '********************************
                        'ﾕｰｻﾞｰ責任区分ﾏｽﾀ  追加
                        '********************************
                        Dim objTMST_USER_DSP As New TBL_TMST_USER_DSP(Owner, ObjDb, ObjDbLog)   'ﾕｰｻﾞｰ責任区分ﾏｽﾀ
                        objTMST_USER_DSP.FUSER_ID = objTMST_USER_After.FUSER_ID                         'ﾕｰｻﾞｰID
                        objTMST_USER_DSP.FUSER_DSP_LEVEL = objTel.SELECT_DATA("DSPUSER_DSP_LEVEL")      'ﾕｰｻﾞ操作ﾚﾍﾞﾙ
                        objTMST_USER_DSP.ADD_TMST_USER_DSP()                                            '追加


                    End If

                Next
            End If
            objTPRG_PARAM_TBL.ARYME_CLEAR()

            '**************************************
            'ﾕｰｻﾞｰ責任区分ﾏｽﾀ      ﾛｸﾞ用ﾃﾞｰﾀ取得
            '**************************************
            Dim objTMST_USER_DSP_After As New TBL_TMST_USER_DSP(Owner, ObjDb, ObjDbLog)
            objTMST_USER_DSP_After.FUSER_ID = objTMST_USER_After.FUSER_ID     'ﾕｰｻﾞｰID
            intRet = objTMST_USER_DSP_After.GET_TMST_USER_DSP_FUSER_ID()      '取得
            If intRet <> RetCode.OK Then
                '(存在しない場合)
                objTMST_USER_DSP_After = Nothing
            End If


            '**************************************
            '変更履歴詳細追加
            '**************************************
            Call Add_TEVD_TBLCHANGE_DTL_TMST_USER(strDenbunDtl _
                                                , MeSyoriID _
                                                , Nothing _
                                                , Nothing _
                                                , objTMST_USER_After _
                                                , objTMST_USER_DSP_After _
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
#Region "  更新ﾒﾝﾃﾅﾝｽ                                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 更新ﾒﾝﾃﾅﾝｽ
    ''' </summary>
    ''' <param name="strDenbunDtl">電文内容構造体</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MenteReasonUPDATE(ByVal strDenbunDtl() As String)
        Try
            Dim intRet As Integer                   '戻り値
            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '************************
            'ﾕｰｻﾞｰﾏｽﾀ特定
            '************************
            Dim objTMST_USER_Before As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            objTMST_USER_Before.FUSER_ID = strDenbunDtl(DSPMAINTE_USER_ID)               'ﾕｰｻﾞｰID
            intRet = objTMST_USER_Before.GET_TMST_USER(True)


            '**************************************
            'ﾕｰｻﾞｰ責任区分ﾏｽﾀ      ﾛｸﾞ用ﾃﾞｰﾀ取得
            '**************************************
            Dim objTMST_USER_DSP_Before As New TBL_TMST_USER_DSP(Owner, ObjDb, ObjDbLog)
            objTMST_USER_DSP_Before.FUSER_ID = strDenbunDtl(DSPMAINTE_USER_ID)      'ﾕｰｻﾞｰID
            intRet = objTMST_USER_DSP_Before.GET_TMST_USER_DSP_FUSER_ID()           '取得
            If intRet <> RetCode.OK Then
                '(存在しない場合)
                objTMST_USER_DSP_Before = Nothing
            End If


            '************************
            'ﾕｰｻﾞｰﾏｽﾀ更新
            '************************
            Dim objTMST_USER_After As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            objTMST_USER_After.FUSER_ID = strDenbunDtl(DSPMAINTE_USER_ID)           'ﾕｰｻﾞｰID
            intRet = objTMST_USER_After.GET_TMST_USER(False)                        '取得
            objTMST_USER_After.FLOGIN_ID = strDenbunDtl(DSPMAINTE_LOGIN_ID)         'ﾛｸﾞｲﾝID
            objTMST_USER_After.FUSER_NAME = strDenbunDtl(DSPMAINTE_USER_NAME)       'ﾕｰｻﾞｰ名
            objTMST_USER_After.FUPDATE_DT = Now                                     '更新日時
            objTMST_USER_After.FUPDATE_USER_ID = strDenbunDtl(DSPUSER_ID)           '更新ﾕｰｻﾞｰID
            objTMST_USER_After.FUPDATE_TERM_ID = strDenbunDtl(DSPTERM_ID)           '更新端末ID
            objTMST_USER_After.UPDATE_TMST_USER()                                   '更新


            '********************************
            'ﾕｰｻﾞｰ責任区分ﾏｽﾀ  初期化
            '********************************
            Dim objTMST_USER_DSP As New TBL_TMST_USER_DSP(Owner, ObjDb, ObjDbLog)
            objTMST_USER_DSP.FUSER_ID = objTMST_USER_After.FUSER_ID                 'ﾕｰｻﾞｰID
            objTMST_USER_DSP.DELETE_TMST_USER_DSP_FUSER_ID()                        '削除


            '************************
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ取得
            '************************
            Dim objTPRG_PARAM_TBL As New TBL_TPRG_PARAM_TBL(Owner, ObjDb, ObjDbLog) 'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ
            objTPRG_PARAM_TBL.FPARA_ID = strDenbunDtl(DSPTERM_ID)       'ﾊﾟﾗﾒｰﾀID
            intRet = objTPRG_PARAM_TBL.GET_TPRG_PARAM_TBL_FPARA_ID()    '特定
            If intRet = RetCode.OK Then
                For ii As Integer = LBound(objTPRG_PARAM_TBL.ARYME) To UBound(objTPRG_PARAM_TBL.ARYME)
                    '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)

                    Dim objTel As New clsTelegram(CONFIG_TELEGRAM_DSP)  '受信用電文
                    objTel.FORMAT_ID = MeDSPID                          'ﾌｫｰﾏｯﾄ名ｾｯﾄ
                    objTel.TELEGRAM_PARTITION = objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA      '分割する電文ｾｯﾄ
                    objTel.PARTITION()                                  '電文分割

                    If objTel.SELECT_DATA("DSPCHECK") = "1" Then
                        '(ﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸが入っていた場合)


                        '********************************
                        'ﾕｰｻﾞｰ責任区分ﾏｽﾀ  追加
                        '********************************
                        objTMST_USER_DSP.FUSER_DSP_LEVEL = objTel.SELECT_DATA("DSPUSER_DSP_LEVEL")      'ﾕｰｻﾞ操作ﾚﾍﾞﾙ
                        objTMST_USER_DSP.DELETE_TMST_USER_DSP()                                         '削除
                        objTMST_USER_DSP.ADD_TMST_USER_DSP()                                            '追加


                    End If

                Next
            End If
            objTPRG_PARAM_TBL.ARYME_CLEAR()


            '**************************************
            'ﾕｰｻﾞｰ責任区分ﾏｽﾀ      ﾛｸﾞ用ﾃﾞｰﾀ取得
            '**************************************
            Dim objTMST_USER_DSP_After As New TBL_TMST_USER_DSP(Owner, ObjDb, ObjDbLog)
            objTMST_USER_DSP_After.FUSER_ID = objTMST_USER_After.FUSER_ID       'ﾕｰｻﾞｰID
            intRet = objTMST_USER_DSP_After.GET_TMST_USER_DSP_FUSER_ID()        '取得
            If intRet <> RetCode.OK Then
                '(存在しない場合)
                objTMST_USER_DSP_After = Nothing
            End If


            '**************************************
            '変更履歴詳細追加
            '**************************************
            Call Add_TEVD_TBLCHANGE_DTL_TMST_USER(strDenbunDtl _
                                                , MeSyoriID _
                                                , objTMST_USER_Before _
                                                , objTMST_USER_DSP_Before _
                                                , objTMST_USER_After _
                                                , objTMST_USER_DSP_After _
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
#Region "  削除ﾒﾝﾃﾅﾝｽ                                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 削除ﾒﾝﾃﾅﾝｽ
    ''' </summary>
    ''' <param name="strDenbunDtl">電文内容構造体</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MenteReasonDELETE(ByVal strDenbunDtl() As String)
        Try
            Dim intRet As Integer                   '戻り値
            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '************************
            'ﾕｰｻﾞｰﾏｽﾀ特定
            '************************
            Dim objTMST_USER_Before As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            objTMST_USER_Before.FUSER_ID = strDenbunDtl(DSPMAINTE_USER_ID)               'ﾕｰｻﾞｰID
            intRet = objTMST_USER_Before.GET_TMST_USER(True)


            '**************************************
            'ﾕｰｻﾞｰ責任区分ﾏｽﾀ      ﾛｸﾞ用ﾃﾞｰﾀ取得
            '**************************************
            Dim objTMST_USER_DSP_Before As New TBL_TMST_USER_DSP(Owner, ObjDb, ObjDbLog)
            objTMST_USER_DSP_Before.FUSER_ID = strDenbunDtl(DSPMAINTE_USER_ID)      'ﾕｰｻﾞｰID
            intRet = objTMST_USER_DSP_Before.GET_TMST_USER_DSP_FUSER_ID()           '取得
            If intRet <> RetCode.OK Then
                '(存在しない場合)
                objTMST_USER_DSP_Before = Nothing
            End If


            '************************
            '理由ﾏｽﾀ削除
            '************************
            objTMST_USER_Before.DELETE_TMST_USER()                                                 '削除


            '************************
            'ﾕｰｻﾞｰ責任区分ﾏｽﾀ
            '************************
            Dim objTMST_USER_DSP As New TBL_TMST_USER_DSP(Owner, ObjDb, ObjDbLog)
            objTMST_USER_DSP.FUSER_ID = objTMST_USER_Before.FUSER_ID
            objTMST_USER_DSP.DELETE_TMST_USER_DSP_FUSER_ID()


            '**************************************
            '変更履歴詳細追加
            '**************************************
            Call Add_TEVD_TBLCHANGE_DTL_TMST_USER(strDenbunDtl _
                                                , MeSyoriID _
                                                , objTMST_USER_Before _
                                                , objTMST_USER_DSP_Before _
                                                , Nothing _
                                                , Nothing _
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

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
