'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】車輌ﾏｽﾀﾒﾝﾃﾅﾝｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_400601
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0                 '端末ID
    Private Const DSPUSER_ID As Integer = 1                 'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2                  '理由
    Private Const DSPDIR_KUBUN As Integer = 3               '処理区分
    Private Const DSPXSYARYOU_NO As Integer = 4             '車輌番号
    Private Const DSPXTUMI_HOUKOU As Integer = 5            '積込方向
    Private Const DSPXTUMI_HOUHOU As Integer = 6            '積込方法
    Private Const DSPXNOT_USER As Integer = 7               '未使用区分
    Private Const XDSPCARD_NO As Integer = 8                'ｶｰﾄﾞ№
    Private Const XDSPSYASYU_KBN As Integer = 9             '車種区分
    Private Const XDSPSYASYU_COMMENT As Integer = 10        '車種ｺﾒﾝﾄ
    Private Const XDSPGYOUSYA_CD As Integer = 11            '物流業者ｺｰﾄﾞ
    Private Const XDSPLOADER_POSSIBLE As Integer = 12       'ﾛｰﾀﾞ対応可否
    Private Const XDSPSYARYOU_MODE As Integer = 13          'ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)

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
            '車輌ﾏｽﾀﾒﾝﾃﾅﾝｽ
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
            'Dim intRet As RetCode                   '戻り値
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


            Select Case strDenbunDtl(DSPDIR_KUBUN)
                Case FORMAT_DSP_DSPDIR_KUBUN_INSERT, FORMAT_DSP_DSPDIR_KUBUN_UPDATE
                    '(追加、更新)

                    If IsNotNull(strDenbunDtl(XDSPCARD_NO)) Then
                        '(ｶｰﾄﾞ№がｾｯﾄされていた場合)


                        '**************************************
                        '車輌ﾏｽﾀ        ﾁｪｯｸ
                        '**************************************
                        Dim intCount As Integer = 0
                        Dim objXMST_SYARYOU_Check As New TBL_XMST_SYARYOU(Owner, ObjDb, ObjDbLog)
                        objXMST_SYARYOU_Check.XCARD_NO = strDenbunDtl(XDSPCARD_NO)                          'ｶｰﾄﾞ№
                        objXMST_SYARYOU_Check.WHERE = "    AND XSYARYOU_NO <>  " & strDenbunDtl(DSPXSYARYOU_NO) & " "       '車輌番号
                        intCount = objXMST_SYARYOU_Check.GET_XMST_SYARYOU_COUNT                             '取得
                        If 1 <= intCount Then
                            '(重複している場合)
                            Throw New UserException("ｶｰﾄﾞ№が重複しています。" & vbCrLf & "[ｶｰﾄﾞ№:" & objXMST_SYARYOU_Check.XCARD_NO & "]")
                        End If


                    End If

            End Select


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
            Dim intRet As RetCode
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ

            '**************************************
            '車輌ﾏｽﾀ存在ﾁｪｯｸ
            '**************************************
            Dim objXMST_SYARYOU_Before As New TBL_XMST_SYARYOU(Owner, ObjDb, ObjDbLog)
            objXMST_SYARYOU_Before.XSYARYOU_NO = strDenbunDtl(DSPXSYARYOU_NO)    '車輌番号
            intRet = objXMST_SYARYOU_Before.GET_XMST_SYARYOU(False)
            If intRet <> RetCode.NotFound Then
                '(車輌ﾏｽﾀが存在した場合)
                strMsg = FRM_MSG_FHINMEI_CD_MSG_03 & "[車輌番号:" & objXMST_SYARYOU_Before.XSYARYOU_NO & "]"
                Throw New System.Exception(strMsg)
                Exit Sub
            End If


            '**************************************
            '車輌ﾏｽﾀの追加
            '**************************************
            Dim objXMST_SYARYOU_After As New TBL_XMST_SYARYOU(Owner, ObjDb, ObjDbLog)
            objXMST_SYARYOU_After.XSYARYOU_NO = TO_INTEGER_NULLABLE(strDenbunDtl(DSPXSYARYOU_NO))               '車輌番号
            objXMST_SYARYOU_After.XTUMI_HOUKOU = TO_INTEGER_NULLABLE(strDenbunDtl(DSPXTUMI_HOUKOU))             '積込方向
            objXMST_SYARYOU_After.XTUMI_HOUHOU = TO_INTEGER_NULLABLE(strDenbunDtl(DSPXTUMI_HOUHOU))             '積込方法
            objXMST_SYARYOU_After.XNOT_USER = TO_INTEGER_NULLABLE(strDenbunDtl(DSPXNOT_USER))                   '未使用区分
            objXMST_SYARYOU_After.FENTRY_DT = Now                                                               '登録日時
            objXMST_SYARYOU_After.XCARD_NO = strDenbunDtl(XDSPCARD_NO)                                          'ｶｰﾄﾞ№
            objXMST_SYARYOU_After.XSYASYU_KBN = strDenbunDtl(XDSPSYASYU_KBN)                                    '車種区分
            objXMST_SYARYOU_After.XSYASYU_COMMENT = strDenbunDtl(XDSPSYASYU_COMMENT)                            '車種ｺﾒﾝﾄ
            objXMST_SYARYOU_After.XGYOUSYA_CD = strDenbunDtl(XDSPGYOUSYA_CD)                                    '物流業者ｺｰﾄﾞ
            objXMST_SYARYOU_After.XLOADER_POSSIBLE = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPLOADER_POSSIBLE))     'ﾛｰﾀﾞ対応可否
            objXMST_SYARYOU_After.XSYARYOU_MODE = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPSYARYOU_MODE))           'ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)
            Call objXMST_SYARYOU_After.ADD_XMST_SYARYOU()                                                       '追加


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
            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '**************************************
            '車輌ﾏｽﾀの更新
            '**************************************
            Dim objXMST_SYARYOU_After As New TBL_XMST_SYARYOU(Owner, ObjDb, ObjDbLog)
            objXMST_SYARYOU_After.XSYARYOU_NO = strDenbunDtl(DSPXSYARYOU_NO)                                '車輌番号
            objXMST_SYARYOU_After.GET_XMST_SYARYOU(False)
            objXMST_SYARYOU_After.XTUMI_HOUKOU = TO_INTEGER_NULLABLE(strDenbunDtl(DSPXTUMI_HOUKOU))         '積込方向
            objXMST_SYARYOU_After.XTUMI_HOUHOU = TO_INTEGER_NULLABLE(strDenbunDtl(DSPXTUMI_HOUHOU))         '積込方法
            objXMST_SYARYOU_After.XNOT_USER = TO_INTEGER_NULLABLE(strDenbunDtl(DSPXNOT_USER))               '未使用区分
            objXMST_SYARYOU_After.XCARD_NO = strDenbunDtl(XDSPCARD_NO)                                      'ｶｰﾄﾞ№
            objXMST_SYARYOU_After.XSYASYU_KBN = strDenbunDtl(XDSPSYASYU_KBN)                                '車種区分
            objXMST_SYARYOU_After.XSYASYU_COMMENT = strDenbunDtl(XDSPSYASYU_COMMENT)                        '車種ｺﾒﾝﾄ
            objXMST_SYARYOU_After.XGYOUSYA_CD = strDenbunDtl(XDSPGYOUSYA_CD)                                '物流業者ｺｰﾄﾞ
            objXMST_SYARYOU_After.XLOADER_POSSIBLE = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPLOADER_POSSIBLE)) 'ﾛｰﾀﾞ対応可否
            objXMST_SYARYOU_After.XSYARYOU_MODE = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPSYARYOU_MODE))       'ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)
            Call objXMST_SYARYOU_After.UPDATE_XMST_SYARYOU()                                                '更新


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
            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '**************************************
            '車輌ﾏｽﾀ　車輌番号ｾｯﾄ
            '**************************************
            Dim objXMST_SYARYOU As New TBL_XMST_SYARYOU(Owner, ObjDb, ObjDbLog)
            objXMST_SYARYOU.XSYARYOU_NO = strDenbunDtl(DSPXSYARYOU_NO)    '車輌番号


            '**************************************
            '車輌ﾏｽﾀの削除
            '**************************************
            Call objXMST_SYARYOU.DELETE_XMST_SYARYOU()                      '削除

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
