'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】理由ﾏｽﾀﾒﾝﾃﾅﾝｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_200901
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0         '端末ID
    Private Const DSPUSER_ID As Integer = 1         'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2          '理由
    Private Const DSPDIR_KUBUN As Integer = 3       '処理区分
    Private Const DSPREASON_CD As Integer = 4       '理由ｺｰﾄﾞ
    Private Const DSPREASON_KUBUN As Integer = 5    '理由区分
    Private Const DSPREASON_2 As Integer = 6        '理由(理由ﾏｽﾀに登録されるﾃﾞｰﾀ)

#End Region
#Region "　ｺﾝｽﾄﾗｸﾀ                                                                              "
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
    '**********************************************************************************************
    '【機能】ﾒｲﾝ処理
    '【引数】[IN ] strMSG_RECV          :受信電文
    '        [OUT] strMSG_SEND          :送信電文
    '【戻値】OK/NG
    '**********************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
        Dim strDenbunDtl(0) As String           '電文分解配列
        Dim strDenbunDtlName(0) As String       '電文分解名称配列
        Dim strDenbunInfo As String = ""        '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        '' ''Dim intRet As Integer                 '戻り値
        '' ''Dim strMsg As String                  'ﾒｯｾｰｼﾞ
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
            Dim intRet As Integer                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '************************
            '理由区分ﾁｪｯｸ
            '************************
            If strDenbunDtl(DSPREASON_KUBUN) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[理由区分]"
                Throw New UserException(strMsg)
            End If


            '************************
            '理由ﾏｽﾀ特定
            '************************
            Dim objTMST_REASON_After As New TBL_TMST_REASON(Owner, ObjDb, ObjDbLog)             '理由ﾏｽﾀ
            objTMST_REASON_After.FREASON_CD = strDenbunDtl(DSPREASON_CD)                        '理由ｺｰﾄﾞ
            intRet = objTMST_REASON_After.GET_TMST_REASON(False)
            If intRet = RetCode.OK Then
                '(理由が存在した場合)
                strMsg = ERRMSG_FOUND_TMST_REASON & "[理由ｺｰﾄﾞ:" & TO_STRING(objTMST_REASON_After.FREASON_CD) & "]"
                Throw New UserException(strMsg)
            End If

            '************************
            '理由ﾏｽﾀ更新前ｵﾌﾞｼﾞｪｸﾄｲﾝｽﾀﾝｽ
            '************************
            Dim objTMST_REASON_Before As New TBL_TMST_REASON(Owner, ObjDb, ObjDbLog)            '理由ﾏｽﾀ

            '************************
            '理由ﾏｽﾀ登録
            '************************
            objTMST_REASON_After.FREASON_CD = strDenbunDtl(DSPREASON_CD)                        '理由ｺｰﾄﾞ
            objTMST_REASON_After.FREASON_KUBUN = strDenbunDtl(DSPREASON_KUBUN)                  '理由区分
            objTMST_REASON_After.FREASON = strDenbunDtl(DSPREASON_2)                            '理由
            objTMST_REASON_After.FENTRY_DT = Now                                                '登録日時
            objTMST_REASON_After.FENTRY_USER_ID = strDenbunDtl(DSPUSER_ID)                      '登録ﾕｰｻﾞｰID
            objTMST_REASON_After.FENTRY_TERM_ID = strDenbunDtl(DSPTERM_ID)                      '登録端末
            objTMST_REASON_After.FUPDATE_DT = Now                                               '更新日時
            objTMST_REASON_After.FUPDATE_USER_ID = strDenbunDtl(DSPUSER_ID)                     '更新ﾕｰｻﾞｰID
            objTMST_REASON_After.FUPDATE_TERM_ID = strDenbunDtl(DSPTERM_ID)                     '更新端末
            objTMST_REASON_After.ADD_TMST_REASON()                                              '登録

            '**************************************
            '変更履歴詳細追加(TMST_REASON)
            '**************************************
            Call Add_TEVD_TBLCHANGE_DTL_TMST_REASON(strDenbunDtl _
                                                  , MeSyoriID _
                                                  , objTMST_REASON_Before _
                                                  , objTMST_REASON_After _
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
            '理由ﾏｽﾀ特定
            '************************
            Dim objTMST_REASON_Before As New TBL_TMST_REASON(Owner, ObjDb, ObjDbLog)             '理由ﾏｽﾀ
            objTMST_REASON_Before.FREASON_CD = strDenbunDtl(DSPREASON_CD)                        '理由ｺｰﾄﾞ
            intRet = objTMST_REASON_Before.GET_TMST_REASON(True)


            '************************
            '理由ﾏｽﾀ特定
            '************************
            Dim objTMST_REASON_After As New TBL_TMST_REASON(Owner, ObjDb, ObjDbLog)             '理由ﾏｽﾀ
            objTMST_REASON_After.FREASON_CD = strDenbunDtl(DSPREASON_CD)                        '理由ｺｰﾄﾞ
            intRet = objTMST_REASON_After.GET_TMST_REASON(False)


            '************************
            '理由ﾏｽﾀ更新
            '************************
            objTMST_REASON_After.FREASON = strDenbunDtl(DSPREASON_2)                            '理由
            objTMST_REASON_After.FUPDATE_DT = Now                                               '更新日時
            objTMST_REASON_After.FUPDATE_USER_ID = strDenbunDtl(DSPUSER_ID)                     '更新ﾕｰｻﾞｰID
            objTMST_REASON_After.FUPDATE_TERM_ID = strDenbunDtl(DSPTERM_ID)                     '更新端末
            objTMST_REASON_After.UPDATE_TMST_REASON()

            '**************************************
            '変更履歴詳細追加(TMST_REASON)
            '**************************************
            Call Add_TEVD_TBLCHANGE_DTL_TMST_REASON(strDenbunDtl _
                                                  , MeSyoriID _
                                                  , objTMST_REASON_Before _
                                                  , objTMST_REASON_After _
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
            '理由ﾏｽﾀ特定
            '************************
            Dim objTMST_REASON_After As New TBL_TMST_REASON(Owner, ObjDb, ObjDbLog)             '理由ﾏｽﾀ
            Dim objTMST_REASON_Before As New TBL_TMST_REASON(Owner, ObjDb, ObjDbLog)            '理由ﾏｽﾀ
            objTMST_REASON_Before.FREASON_CD = strDenbunDtl(DSPREASON_CD)                       '理由ｺｰﾄﾞ
            intRet = objTMST_REASON_Before.GET_TMST_REASON(True)


            '************************
            '理由ﾏｽﾀ削除
            '************************
            objTMST_REASON_Before.DELETE_TMST_REASON()                                                 '削除


            '**************************************
            '変更履歴詳細追加(TMST_REASON)
            '**************************************
            Call Add_TEVD_TBLCHANGE_DTL_TMST_REASON(strDenbunDtl _
                                                  , MeSyoriID _
                                                  , objTMST_REASON_Before _
                                                  , objTMST_REASON_After _
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
