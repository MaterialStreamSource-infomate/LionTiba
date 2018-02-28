'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】製品構成ﾏｽﾀﾒﾝﾃﾅﾝｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_202001
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0             '端末ID
    Private Const DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2              '理由
    Private Const DSPDIR_KUBUN As Integer = 3           '処理区分
    Private Const XDSPSEIHIN_CD As Integer = 4          '製品ｺｰﾄﾞ
    Private Const DSPHINMEI_CD As Integer = 5           '品目ｺｰﾄﾞ
    Private Const XDSPBATCHUSE_NUM As Integer = 6       '1ﾊﾞｯﾁ毎使用量

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
            'ｴﾝｼﾞﾝ型式ﾏｽﾀﾒﾝﾃﾅﾝｽ
            '************************
            Select Case strDenbunDtl(DSPDIR_KUBUN)
                Case FORMAT_DSP_DSPDIR_KUBUN_INSERT
                    '(追加)
                    Call Mente_ADD(strDenbunDtl)


                Case FORMAT_DSP_DSPDIR_KUBUN_UPDATE
                    '(更新)
                    Call Mente_UPDATE(strDenbunDtl)


                Case FORMAT_DSP_DSPDIR_KUBUN_DELETE
                    '(削除)
                    Call Mente_DELETE(strDenbunDtl)

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
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_ADD(ByVal strDenbunDtl() As String)
        Try
            'Dim intRet As RetCode
            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            ''************************
            ''製品構成ﾏｽﾀ  特定
            ''************************
            'Dim objXMST_SEIHIN_DTL_Before As New TBL_XMST_SEIHIN_DTL(Owner, ObjDb, ObjDbLog)
            'objXMST_SEIHIN_DTL_Before.XProductCodeFinal = strDenbunDtl(XDSPSEIHIN_CD)           '製品ｺｰﾄﾞ
            'objXMST_SEIHIN_DTL_Before.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                   '品目ｺｰﾄﾞ
            'intRet = objXMST_SEIHIN_DTL_Before.GET_XMST_SEIHIN_DTL(False)                       '取得
            'If intRet = RetCode.OK Then
            '    '(存在する場合)
            '    strMsg = FRM_MSG_FSEIHIN_CD_MSG_02 & "[製品品番:" & objXMST_SEIHIN_DTL_Before.XProductCodeFinal & "]" & "[品目ｺｰﾄﾞ:" & objXMST_SEIHIN_DTL_Before.FHINMEI_CD & "]"
            '    Throw New System.Exception(strMsg)
            '    Exit Sub
            'End If
            'objXMST_SEIHIN_DTL_Before.XProductCodeFinal = Nothing
            'objXMST_SEIHIN_DTL_Before.FHINMEI_CD = Nothing

            ''************************
            ''製品品番ﾃｰﾌﾞﾙ  特定
            ''************************
            'Dim objXMST_SEIHIN_Before As New TBL_XMST_SEIHIN(Owner, ObjDb, ObjDbLog)
            'objXMST_SEIHIN_Before.XProductCodeFinal = strDenbunDtl(XDSPSEIHIN_CD)   '製品ｺｰﾄﾞ
            'objXMST_SEIHIN_Before.GET_XMST_SEIHIN(True)                             '取得


            ''**************************************
            ''品名ﾏｽﾀ存在ﾁｪｯｸ
            ''**************************************
            'Dim objTMST_ITEM_Before As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
            'objTMST_ITEM_Before.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)    '品名ｺｰﾄﾞ
            'intRet = objTMST_ITEM_Before.GET_TMST_ITEM(True)


            ''************************
            ''製品構成ﾏｽﾀ  追加
            ''************************
            'Dim objXMST_SEIHIN_DTL_After As New TBL_XMST_SEIHIN_DTL(Owner, ObjDb, ObjDbLog)                     '製品構成ﾏｽﾀ
            'objXMST_SEIHIN_DTL_After.XProductCodeFinal = strDenbunDtl(XDSPSEIHIN_CD)                            '製品ｺｰﾄﾞ
            'objXMST_SEIHIN_DTL_After.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                                    '製品ｺｰﾄﾞ
            'objXMST_SEIHIN_DTL_After.XBATCHUSE_NUM = TO_DECIMAL_NULLABLE(strDenbunDtl(XDSPBATCHUSE_NUM))        '製品ｺｰﾄﾞ
            'objXMST_SEIHIN_DTL_After.FENTRY_DT = Now                                                            '登録日時
            'objXMST_SEIHIN_DTL_After.FENTRY_USER_ID = strDenbunDtl(DSPUSER_ID)                                  '登録担当者ｺｰﾄﾞ
            'objXMST_SEIHIN_DTL_After.FENTRY_TERM_ID = strDenbunDtl(DSPTERM_ID)                                  '登録端末ID
            'objXMST_SEIHIN_DTL_After.FUPDATE_DT = Now                                                           '更新日時
            'objXMST_SEIHIN_DTL_After.FUPDATE_USER_ID = strDenbunDtl(DSPUSER_ID)                                 '更新担当者ｺｰﾄﾞ
            'objXMST_SEIHIN_DTL_After.FUPDATE_TERM_ID = strDenbunDtl(DSPTERM_ID)                                 '更新端末ID

            'Call objXMST_SEIHIN_DTL_After.ADD_XMST_SEIHIN_DTL()                                                 '追加


            ''**************************************
            ''変更履歴詳細追加(XMST_SEIHIN_DTL)
            ''**************************************
            'Call Add_TEVD_TBLCHANGE_DTL_XMST_SEIHIN_DTL(strDenbunDtl _
            '                                      , MeSyoriID _
            '                                      , objXMST_SEIHIN_DTL_Before _
            '                                      , objXMST_SEIHIN_DTL_After _
            '                                      )



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
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_UPDATE(ByVal strDenbunDtl() As String)
        Try
            'Dim intRet As RetCode
            ''Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            ''************************
            ''製品構成ﾏｽﾀ  特定
            ''************************
            'Dim objXMST_SEIHIN_DTL_Before As New TBL_XMST_SEIHIN_DTL(Owner, ObjDb, ObjDbLog)
            'objXMST_SEIHIN_DTL_Before.XProductCodeFinal = strDenbunDtl(XDSPSEIHIN_CD)           '製品ｺｰﾄﾞ
            'objXMST_SEIHIN_DTL_Before.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                   '品目ｺｰﾄﾞ
            'objXMST_SEIHIN_DTL_Before.GET_XMST_SEIHIN_DTL(True)                                 '取得


            ''************************
            ''製品品番ﾃｰﾌﾞﾙ  特定
            ''************************
            'Dim objXMST_SEIHIN_Before As New TBL_XMST_SEIHIN(Owner, ObjDb, ObjDbLog)
            'objXMST_SEIHIN_Before.XProductCodeFinal = strDenbunDtl(XDSPSEIHIN_CD)       '製品ｺｰﾄﾞ
            'objXMST_SEIHIN_Before.GET_XMST_SEIHIN(True)                                 '取得


            ''**************************************
            ''品名ﾏｽﾀ存在ﾁｪｯｸ
            ''**************************************
            'Dim objTMST_ITEM_Before As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
            'objTMST_ITEM_Before.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)    '品名ｺｰﾄﾞ
            'intRet = objTMST_ITEM_Before.GET_TMST_ITEM(True)


            ''************************
            ''製品構成ﾏｽﾀ  更新
            ''************************
            'Dim objXMST_SEIHIN_DTL_After As New TBL_XMST_SEIHIN_DTL(Owner, ObjDb, ObjDbLog)                     '製品構成ﾏｽﾀ
            'objXMST_SEIHIN_DTL_After.XProductCodeFinal = strDenbunDtl(XDSPSEIHIN_CD)                            '製品ｺｰﾄﾞ
            'objXMST_SEIHIN_DTL_After.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                                    '品目ｺｰﾄﾞ
            'objXMST_SEIHIN_DTL_After.GET_XMST_SEIHIN_DTL(False)
            'objXMST_SEIHIN_DTL_After.XBATCHUSE_NUM = TO_DECIMAL_NULLABLE(strDenbunDtl(XDSPBATCHUSE_NUM))        '1ﾊﾞｯﾁ毎使用量
            'objXMST_SEIHIN_DTL_After.FUPDATE_DT = Now                                                           '更新日時
            'objXMST_SEIHIN_DTL_After.FUPDATE_USER_ID = strDenbunDtl(DSPUSER_ID)                                 '更新担当者ｺｰﾄﾞ
            'objXMST_SEIHIN_DTL_After.FUPDATE_TERM_ID = strDenbunDtl(DSPTERM_ID)                                 '更新端末ID

            'Call objXMST_SEIHIN_DTL_After.UPDATE_XMST_SEIHIN_DTL()                                                 '追加


            ''**************************************
            ''変更履歴詳細追加(XMST_SEIHIN_DTL)
            ''**************************************
            'Call Add_TEVD_TBLCHANGE_DTL_XMST_SEIHIN_DTL(strDenbunDtl _
            '                                      , MeSyoriID _
            '                                      , objXMST_SEIHIN_DTL_Before _
            '                                      , objXMST_SEIHIN_DTL_After _
            '                                      )


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
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_DELETE(ByVal strDenbunDtl() As String)
        Try
            ''Dim intRet As RetCode
            ''Dim strSQL As String
            ''Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            ''************************
            ''製品構成ﾏｽﾀ  特定
            ''************************
            'Dim objXMST_SEIHIN_DTL_Before As New TBL_XMST_SEIHIN_DTL(Owner, ObjDb, ObjDbLog)
            'objXMST_SEIHIN_DTL_Before.XProductCodeFinal = strDenbunDtl(XDSPSEIHIN_CD)   '製品ｺｰﾄﾞ
            'objXMST_SEIHIN_DTL_Before.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)           '品目ｺｰﾄﾞ
            'objXMST_SEIHIN_DTL_Before.GET_XMST_SEIHIN_DTL(True)                         '取得


            ''************************
            ''製品構成ﾏｽﾀ  削除
            ''************************
            'objXMST_SEIHIN_DTL_Before.DELETE_XMST_SEIHIN_DTL()


            ''**************************************
            ''製品構成ﾏｽﾀをﾀﾞﾐｰで作成
            ''**************************************
            'Dim objXMST_SEIHIN_DTL_After As New TBL_XMST_SEIHIN_DTL(Owner, ObjDb, ObjDbLog)


            ''**************************************
            ''変更履歴詳細追加(XMST_SEIHIN)
            ''**************************************
            'Call Add_TEVD_TBLCHANGE_DTL_XMST_SEIHIN_DTL(strDenbunDtl _
            '                                      , MeSyoriID _
            '                                      , objXMST_SEIHIN_DTL_Before _
            '                                      , objXMST_SEIHIN_DTL_After _
            '                                      )


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
