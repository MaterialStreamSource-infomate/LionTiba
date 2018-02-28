'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】生産ﾗｲﾝ(D45)ﾏｽﾀﾒﾝﾃﾅﾝｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_400606
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0             '端末ID
    Private Const DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2              '理由
    Private Const DSPDIR_KUBUN As Integer = 3           '処理区分
    Private Const XDSPPROD_LINE As Integer = 4          '生産ﾗｲﾝ№
    Private Const XDSPPROD_LINE_NAME As Integer = 5     '生産ﾗｲﾝ名称
    Private Const DSPHINMEI_CD As Integer = 6           '品名ｺｰﾄﾞ

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
            '包装材料ﾒｰｶﾏｽﾀﾒﾝﾃﾅﾝｽ
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
            Dim intRet As RetCode
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ

            '**************************************
            '包装材料ﾒｰｶﾏｽﾀ存在ﾁｪｯｸ
            '**************************************
            Dim obj_XMST_PROD_LINE_D45_Before As New TBL_XMST_PROD_LINE_D45(Owner, ObjDb, ObjDbLog)
            obj_XMST_PROD_LINE_D45_Before.XPROD_LINE = strDenbunDtl(XDSPPROD_LINE)                  '生産ﾗｲﾝ№
            intRet = obj_XMST_PROD_LINE_D45_Before.GET_XMST_PROD_LINE_D45(False)
            If intRet <> RetCode.NotFound Then
                '(包装材料ﾒｰｶﾏｽﾀが存在した場合)
                strMsg = FRM_MSG_XPROD_LINE_02 & "[生産ﾗｲﾝ(D45)№:" & obj_XMST_PROD_LINE_D45_Before.XPROD_LINE & "]"
                Throw New System.Exception(strMsg)
                Exit Sub
            End If

            '**************************************
            '包装材料ﾒｰｶﾏｽﾀの追加
            '**************************************
            Dim obj_XMST_PROD_LINE_D45_After As New TBL_XMST_PROD_LINE_D45(Owner, ObjDb, ObjDbLog)
            obj_XMST_PROD_LINE_D45_After.XPROD_LINE = strDenbunDtl(XDSPPROD_LINE)                               '生産ﾗｲﾝ№
            obj_XMST_PROD_LINE_D45_After.XPROD_LINE_NAME = strDenbunDtl(XDSPPROD_LINE_NAME)                     '生産ﾗｲﾝ名称
            obj_XMST_PROD_LINE_D45_After.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                                '品名ｺｰﾄﾞ
            Call obj_XMST_PROD_LINE_D45_After.ADD_XMST_PROD_LINE_D45()                                  '追加

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
            '包装材料ﾒｰｶﾏｽﾀの更新
            '**************************************
            Dim obj_XMST_PROD_LINE_D45 As New TBL_XMST_PROD_LINE_D45(Owner, ObjDb, ObjDbLog)
            obj_XMST_PROD_LINE_D45.XPROD_LINE = strDenbunDtl(XDSPPROD_LINE)                                     '生産ﾗｲﾝ№
            obj_XMST_PROD_LINE_D45.GET_XMST_PROD_LINE_D45(False)
            obj_XMST_PROD_LINE_D45.XPROD_LINE_NAME = strDenbunDtl(XDSPPROD_LINE_NAME)                           '生産ﾗｲﾝ名称
            obj_XMST_PROD_LINE_D45.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                                      '品名ｺｰﾄﾞ
            Call obj_XMST_PROD_LINE_D45.UPDATE_XMST_PROD_LINE_D45()                                     '更新

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
            '包装材料ﾒｰｶﾏｽﾀ　生産ﾗｲﾝ(D45)№ｾｯﾄ
            '**************************************
            Dim obj_XMST_PROD_LINE_D45 As New TBL_XMST_PROD_LINE_D45(Owner, ObjDb, ObjDbLog)
            obj_XMST_PROD_LINE_D45.XPROD_LINE = strDenbunDtl(XDSPPROD_LINE)    '生産ﾗｲﾝ№


            '**************************************
            '包装材料ﾒｰｶﾏｽﾀの削除
            '**************************************
            Call obj_XMST_PROD_LINE_D45.DELETE_XMST_PROD_LINE_D45()                      '削除


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