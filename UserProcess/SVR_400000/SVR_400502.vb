'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】倉替え入庫
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_400502
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0             '端末ID
    Private Const DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2              '理由
    Private Const DSPST_FM As Integer = 3               '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private Const DSPST_TO As Integer = 4               '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private Const DSPPALLET_ID As Integer = 5           'ﾊﾟﾚｯﾄID
    Private Const DSPLOT_NO_STOCK As Integer = 6        '在庫ﾛｯﾄ№
    Private Const XDSPPALLET_ID_KO As Integer = 7       'ﾊﾟﾚｯﾄID(子)
    Private Const XDSPLOT_NO_STOCK_KO As Integer = 8    '在庫ﾛｯﾄ№(子)
    Private Const DSPSAGYOU_KIND As Integer = 9         '作業種別
    Private Const XDSPKENSA_KUBUN As Integer = 10       '検査区分

#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ用)</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  ﾒｲﾝ処理                                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
        Dim strDenbunDtl(0) As String         '電文分解配列
        Dim strDenbunDtlName(0) As String     '電文分解名称配列
        Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        Dim intRet As RetCode                 '戻り値
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
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ取得
            '************************
            Dim objTPRG_PARAM_TBL As New TBL_TPRG_PARAM_TBL(Owner, ObjDb, ObjDbLog) 'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ
            objTPRG_PARAM_TBL.FPARA_ID = strDenbunDtl(DSPTERM_ID)       'ﾊﾟﾗﾒｰﾀID
            intRet = objTPRG_PARAM_TBL.GET_TPRG_PARAM_TBL_FPARA_ID()    '特定
            If intRet = RetCode.OK Then
                For ii As Integer = LBound(objTPRG_PARAM_TBL.ARYME) To UBound(objTPRG_PARAM_TBL.ARYME)
                    '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


                    '************************************************************************************************
                    '電文分解
                    '************************************************************************************************
                    Dim strTPRG_PARAM_TBL_DenbunDtl(0) As String         '電文分解配列
                    Dim strTPRG_PARAM_TBL_DenbunDtlName(0) As String     '電文分解名称配列
                    If ii = LBound(objTPRG_PARAM_TBL.ARYME) Then
                        '(最初だけ)

                        Call DivDenbun(strTPRG_PARAM_TBL_DenbunDtl _
                                     , strTPRG_PARAM_TBL_DenbunDtlName _
                                     , objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA _
                                     , strMSG_SEND _
                                     , objTelegramRecv _
                                     , objTelegramSend _
                                     )

                    End If


                    '************************************************************************************************
                    '事前ﾁｪｯｸ
                    '************************************************************************************************
                    If ii = LBound(objTPRG_PARAM_TBL.ARYME) Then
                        '(最初の一回だけ)

                        '===================================================
                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ                   取得
                        '===================================================
                        Dim intCountZaiko As Integer = 0
                        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        objTPRG_TRK_BUF.FTRK_BUF_NO = TO_INTEGER(strTPRG_PARAM_TBL_DenbunDtl(3))        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        intCountZaiko = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_COUNT_ZAIKO()                  '取得
                        If intCountZaiko <> 0 Then
                            Throw New UserException("選択されたSTは作業中です。" & vbCrLf & "作業が終了するまで、操作は実行出来ません。", False)
                        End If

                    End If


                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:Dou 2014/08/04 入庫設定並列処理を行う為の改造


                    '************************************************************************************************
                    '画面ｲﾝﾀｰﾌｪｰｽ一時保管ﾃｰﾌﾞﾙ              追加
                    '************************************************************************************************
                    Dim objXPRG_PARAM_TBL01 As New TBL_XPRG_PARAM_TBL01(Owner, ObjDb, ObjDbLog)
                    objXPRG_PARAM_TBL01.COPY_PROPERTY(objTPRG_PARAM_TBL.ARYME(ii))
                    objXPRG_PARAM_TBL01.ADD_XPRG_PARAM_TBL01()


                    '************************************************************************************************
                    '次処理起動
                    '************************************************************************************************
                    If ii = LBound(objTPRG_PARAM_TBL.ARYME) Then
                        '(最初の一回だけ)
                        Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_J390002)                           '起動
                    End If


                    ''************************************************************************************************
                    ''入庫設定(SVR_400001)STに一度ﾄﾗｯｷﾝｸﾞだけを作成するﾊﾞｰｼﾞｮﾝ
                    ''************************************************************************************************
                    'intRet = SVR_400001_Process(strTPRG_PARAM_TBL_DenbunDtl, "", "")


                    ''************************
                    ''正常完了
                    ''************************
                    'Call AddToOpeLog(strTPRG_PARAM_TBL_DenbunDtl, strTPRG_PARAM_TBL_DenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)


                    '↑↑↑↑↑↑************************************************************************************************************


                Next
            End If
            objTPRG_PARAM_TBL.ARYME_CLEAR()


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
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:Dou 2014/08/04 入庫設定並列処理を行う為の改造
#Region "  ﾒｲﾝ処理                                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function ExecCmd02(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
        Dim strDenbunDtl(0) As String         '電文分解配列
        Dim strDenbunDtlName(0) As String     '電文分解名称配列
        Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        Try


            '************************
            '初期処理
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call CheckBeforeAct(strDenbunDtl)


            '************************************************************************************************
            '入庫設定(SVR_400001)STに一度ﾄﾗｯｷﾝｸﾞだけを作成するﾊﾞｰｼﾞｮﾝ
            '************************************************************************************************
            intRet = SVR_400001_Process(strDenbunDtl, "", "")


            '************************
            '正常完了
            '************************
            Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, Replace(MeSyoriID, "SVR", "DMY"), FLOG_DATA_OPE_SEND_NORMAL)
            'Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
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
    '↑↑↑↑↑↑************************************************************************************************************
#Region "  事前ﾁｪｯｸ                                                                             "
    '''**********************************************************************************************
    ''' <summary>
    ''' 事前ﾁｪｯｸ
    ''' </summary>
    ''' <param name="strDenbunDtl">電文内容構造体</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
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
