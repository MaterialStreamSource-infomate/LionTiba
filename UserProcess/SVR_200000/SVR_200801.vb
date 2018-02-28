'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】操作権限ﾏｽﾀﾒﾝﾃﾅﾝｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_200801
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0         '端末ID
    Private Const DSPUSER_ID As Integer = 1         'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2          '理由
    Private Const DSPUSER_DSP_LEVEL As Integer = 3  'ﾕｰｻﾞ操作ﾚﾍﾞﾙ
    Private Const DSPDISP_ID As Integer = 4         '画面ID
    Private Const DSPCONTROL_ID As Integer = 5      'ｺﾝﾄﾛｰﾙID
    Private Const DSPOPE_FLAG As Integer = 6        '操作ﾌﾗｸﾞ

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
        Dim intRet As Integer                 '戻り値
        Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        Try


            '************************
            '初期処理
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call CheckBeforeAct(strDenbunDtl)


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


                    '************************
                    'ﾕｰｻﾞｰ別許可ﾏｽﾀ特定
                    '************************
                    Dim objTDSP_PMT_USER_Before As New TBL_TDSP_PMT_USER(Owner, ObjDb, ObjDbLog)
                    objTDSP_PMT_USER_Before.FUSER_DSP_LEVEL = Trim(objTel.SELECT_DATA("DSPUSER_DSP_LEVEL"))     'ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
                    objTDSP_PMT_USER_Before.FDISP_ID = Trim(objTel.SELECT_DATA("DSPDISP_ID"))                   '画面ID
                    objTDSP_PMT_USER_Before.FCTRL_ID = Trim(objTel.SELECT_DATA("DSPCONTROL_ID"))                'ｺﾝﾄﾛｰﾙID
                    intRet = objTDSP_PMT_USER_Before.GET_TDSP_PMT_USER(False)
                    If intRet = RetCode.NotFound Then
                        '(ﾕｰｻﾞｰ別許可ﾏｽﾀが存在しない場合)
                        strMsg = ERRMSG_NOTFOUND_TDSP_PMT_USER & "[ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ:" & TO_STRING(objTDSP_PMT_USER_Before.FUSER_DSP_LEVEL) & "][画面ID:" & objTDSP_PMT_USER_Before.FDISP_ID & "][ｺﾝﾄﾛｰﾙID:" & objTDSP_PMT_USER_Before.FCTRL_ID & "]"
                        Throw New UserException(strMsg)
                    End If


                    '************************
                    'ﾕｰｻﾞｰ別許可ﾏｽﾀ特定
                    '************************
                    Dim objTDSP_PMT_USER_After As New TBL_TDSP_PMT_USER(Owner, ObjDb, ObjDbLog)
                    objTDSP_PMT_USER_After.FUSER_DSP_LEVEL = Trim(objTel.SELECT_DATA("DSPUSER_DSP_LEVEL"))      'ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
                    objTDSP_PMT_USER_After.FDISP_ID = Trim(objTel.SELECT_DATA("DSPDISP_ID"))                    '画面ID
                    objTDSP_PMT_USER_After.FCTRL_ID = Trim(objTel.SELECT_DATA("DSPCONTROL_ID"))                 'ｺﾝﾄﾛｰﾙID


                    '************************
                    'ﾕｰｻﾞｰ別許可ﾏｽﾀ更新
                    '************************
                    objTDSP_PMT_USER_After.FOPE_FLAG = Trim(objTel.SELECT_DATA("DSPOPE_FLAG"))    '操作ﾌﾗｸﾞ
                    objTDSP_PMT_USER_After.FUPDATE_DT = Now                                       '更新日時
                    objTDSP_PMT_USER_After.FUPDATE_USER_ID = strDenbunDtl(DSPUSER_ID)             '更新ﾕｰｻﾞｰID
                    objTDSP_PMT_USER_After.FUPDATE_TERM_ID = strDenbunDtl(DSPTERM_ID)             '更新端末ID
                    Call objTDSP_PMT_USER_After.UPDATE_TDSP_PMT_USER()

                    '**************************************
                    '変更履歴詳細追加(TDSP_PMT_USER)
                    '**************************************
                    Call Add_TEVD_TBLCHANGE_DTL_TDSP_PMT_USER(strDenbunDtl _
                                                          , MeSyoriID _
                                                          , objTDSP_PMT_USER_Before _
                                                          , objTDSP_PMT_USER_After _
                                                          )



                Next
            End If
            objTPRG_PARAM_TBL.ARYME_CLEAR()


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
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
