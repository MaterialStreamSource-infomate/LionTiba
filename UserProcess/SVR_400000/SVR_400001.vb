'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】入庫設定
' 【作成】2012/08/23  SIT N.Dounoshita
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_400001
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
    Private Const DSPSAGYOU_KIND As Integer = 7         '作業種別
    Private Const DSPHINMEI_CD As Integer = 8           '品名ｺｰﾄﾞ
    Private Const DSPTR_VOL As Integer = 9              '搬送管理量
    Private Const XDSPIN_KIND As Integer = 10           '入庫種別
    Private Const XDSPIN_SITEI As Integer = 11          '入庫指定
    Private Const DSPARRIVE_DT As Integer = 12          '在庫発生日時
    Private Const XDSPPROD_LINE As Integer = 13         '生産ﾗｲﾝ№
    Private Const XDSPMAKER_CD As Integer = 14          'ﾒｰｶｺｰﾄﾞ
    Private Const XDSPKENSA_KUBUN As Integer = 15       '検査区分
    Private Const DSPHORYU_KUBUN As Integer = 16        '保留区分
    Private Const DSPIN_KUBUN As Integer = 17           '入庫区分
    Private Const XDSPKENPIN_KUBUN As Integer = 18      '検品区分
    Private Const XDSPTR_VOL_KO As Integer = 19         '搬送管理量(子)
    Private Const XDSPTANA_BLOCK As Integer = 20        '棚ﾌﾞﾛｯｸ
    Private Const XDSPST_TO_ARRAY01 As Integer = 21     '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№01
    Private Const XDSPST_TO_ARRAY02 As Integer = 22     '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№02

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


                    'If Not ( _
                    '           strTPRG_PARAM_TBL_DenbunDtl(DSPST_TO) = FTRK_BUF_NO_J9100 _
                    '        Or strTPRG_PARAM_TBL_DenbunDtl(DSPST_TO) = FTRK_BUF_NO_J9200 _
                    '        ) Then
                    '    '(自動倉庫の場合 or 緊急入庫の場合)


                    '    '************************************************
                    '    '予定数                 ｾｯﾄ
                    '    '************************************************
                    '    If strTPRG_PARAM_TBL_DenbunDtl(DSPST_TO) <> FTRK_BUF_NO_J9000 Then
                    '        '(緊急時入庫設定の場合)

                    '        '=======================================
                    '        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ(TO)            取得
                    '        '=======================================
                    '        Dim objTMST_TRK_TO As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                    '        objTMST_TRK_TO.FTRK_BUF_NO = strTPRG_PARAM_TBL_DenbunDtl(DSPST_TO)  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    '        objTMST_TRK_TO.GET_TMST_TRK()                                       '取得
                    '        If IsNotNull(objTMST_TRK_TO.XADRS_YOTEI01) Then
                    '            '(予定数が存在している場合)

                    '            '=======================================
                    '            '予定数、ﾊﾟﾚｯﾄ数の0ﾁｪｯｸ
                    '            '=======================================
                    '            Call CheckYoteiPalletNum(objTMST_TRK_TO)

                    '            '=======================================
                    '            '予定数         取得
                    '            '=======================================
                    '            Dim intYotei As Integer = 2
                    '            If strTPRG_PARAM_TBL_DenbunDtl(XDSPIN_KIND) = XDSPIN_KIND_SINGLE Then intYotei = 1

                    '            '=======================================
                    '            '安川         到着予定数
                    '            '=======================================
                    '            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                    '            'objSVR_190001.FEQ_ID = strFEQ_ID                                '設備ID
                    '            objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         'ｺﾏﾝﾄﾞID
                    '            objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
                    '            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
                    '                                                  , intYotei _
                    '                                                  )

                    '        End If

                    '    End If


                    '    '************************************************************************************************
                    '    '入庫設定(SVR_400001)STに一度ﾄﾗｯｷﾝｸﾞだけを作成するﾊﾞｰｼﾞｮﾝ
                    '    '************************************************************************************************
                    '    intRet = SVR_400001_Process(strTPRG_PARAM_TBL_DenbunDtl, "", "")


                    'Else
                    '    '(平置きの場合)


                    '    '************************************************************************************************
                    '    '入庫設定(平置き)
                    '    '************************************************************************************************
                    '    intRet = ExecCmd11(strTPRG_PARAM_TBL_DenbunDtl, "", "")


                    'End If


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
#Region "  ﾒｲﾝ処理02                                                                            "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理02
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


            If Not ( _
                               strDenbunDtl(DSPST_TO) = FTRK_BUF_NO_J9100 _
                            Or strDenbunDtl(DSPST_TO) = FTRK_BUF_NO_J9200 _
                            ) Then
                '(自動倉庫の場合 or 緊急入庫の場合)


                '************************************************
                '予定数                 ｾｯﾄ
                '************************************************
                If strDenbunDtl(DSPST_TO) <> FTRK_BUF_NO_J9000 Then
                    '(緊急時入庫設定の場合)

                    '=======================================
                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ(TO)            取得
                    '=======================================
                    Dim objTMST_TRK_TO As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                    objTMST_TRK_TO.FTRK_BUF_NO = strDenbunDtl(DSPST_TO)  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTMST_TRK_TO.GET_TMST_TRK()                                       '取得
                    If IsNotNull(objTMST_TRK_TO.XADRS_YOTEI01) Then
                        '(予定数が存在している場合)

                        '=======================================
                        '予定数、ﾊﾟﾚｯﾄ数の0ﾁｪｯｸ
                        '=======================================
                        Call CheckYoteiPalletNum(objTMST_TRK_TO)

                        '=======================================
                        '予定数         取得
                        '=======================================
                        Dim intYotei As Integer = 2
                        If strDenbunDtl(XDSPIN_KIND) = XDSPIN_KIND_SINGLE Then intYotei = 1

                        '=======================================
                        '安川         到着予定数
                        '=======================================
                        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                        'objSVR_190001.FEQ_ID = strFEQ_ID                                '設備ID
                        objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         'ｺﾏﾝﾄﾞID
                        objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
                        Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
                                                              , intYotei _
                                                              )

                    End If

                End If


                '************************************************************************************************
                '入庫設定(SVR_400001)STに一度ﾄﾗｯｷﾝｸﾞだけを作成するﾊﾞｰｼﾞｮﾝ
                '************************************************************************************************
                intRet = SVR_400001_Process(strDenbunDtl, "", "")


            Else
                '(平置きの場合)


                '************************************************************************************************
                '入庫設定(平置き)
                '************************************************************************************************
                intRet = ExecCmd11(strDenbunDtl, "", "")


            End If


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


#Region "  ﾒｲﾝ処理                                                              一応ﾊﾞｯｸｱｯﾌﾟ01  "
    ''''**********************************************************************************************
    '''' <summary>
    '''' ﾒｲﾝ処理
    '''' </summary>
    '''' <param name="strMSG_RECV">受信電文</param>
    '''' <param name="strMSG_SEND">送信電文</param>
    '''' <returns>OK/NG</returns>
    '''' <remarks></remarks>
    ''''**********************************************************************************************
    'Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
    '    Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
    '    Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
    '    Dim strDenbunDtl(0) As String         '電文分解配列
    '    Dim strDenbunDtlName(0) As String     '電文分解名称配列
    '    Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
    '    Dim intRet As RetCode                 '戻り値
    '    Dim strMsg As String                  'ﾒｯｾｰｼﾞ
    '    Try


    '        '************************
    '        '初期処理
    '        '************************
    '        Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
    '        Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
    '        Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
    '        Call CheckBeforeAct(strDenbunDtl)


    '        Dim dtmNow As Date = Now
    '        Dim intFSAGYOU_KIND As Integer = strDenbunDtl(DSPSAGYOU_KIND)    '作業種別
    '        Dim strFPALLET_ID01 As String = ""      'ﾊﾟﾚｯﾄID(親)
    '        Dim strFPALLET_ID02 As String = ""      'ﾊﾟﾚｯﾄID(子)
    '        If IsNotNull(strDenbunDtl(DSPPALLET_ID)) Then
    '            '(倉替の場合)


    '            '************************************************************************************************
    '            'ﾄﾗｯｷﾝｸﾞ,在庫情報,その他ﾊﾟﾚｯﾄに関係する情報全て削除
    '            '************************************************************************************************
    '            Call ClearDustProcess(strDenbunDtl(DSPPALLET_ID))


    '            '************************************************
    '            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(搬送元)       取得
    '            '************************************************
    '            Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '            'objTPRG_TRK_BUF_FM.FTRK_BUF_NO = strDenbunDtl(DSPST_FM)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '            objTPRG_TRK_BUF_FM.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)      'ﾊﾟﾚｯﾄID
    '            objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF()                           '取得


    '            '************************************************
    '            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(搬送先)       取得
    '            '************************************************
    '            Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '            objTPRG_TRK_BUF_TO.FTRK_BUF_NO = strDenbunDtl(DSPST_FM)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '            intRet = objTPRG_TRK_BUF_TO.GET_TPRG_TRK_BUF_AKI_HIRA()         '取得
    '            If intRet <> RetCode.OK Then
    '                '(見つからない場合)
    '                strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_TO.FTRK_BUF_NO) & "]"
    '                Throw New UserException(strMsg)
    '            End If


    '            '************************
    '            '在庫移動
    '            '************************
    '            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '在庫移動ｸﾗｽ
    '            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_FM       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ｽﾃｰｼｮﾝﾊﾞｯﾌｧ)
    '            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_TO       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(平置きﾊﾞｯﾌｧ)
    '            objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_FM.FPALLET_ID    'ﾊﾟﾚｯﾄID
    '            objSVR_100103.FINOUT_STS = FINOUT_STS_SIN_UKETUKE           'INOUT
    '            objSVR_100103.FSAGYOU_KIND = intFSAGYOU_KIND                '作業種別
    '            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '搬送元ｸﾘｱﾌﾗｸﾞ
    '            objSVR_100103.STOCK_TRNS()                                  '移動


    '            '************************
    '            'ﾊﾟﾚｯﾄID        設定
    '            '************************
    '            strFPALLET_ID01 = objSVR_100103.FPALLET_ID


    '        Else
    '            '(新規入庫の場合)


    '            For ii As Integer = 1 To 2
    '                '(ﾙｰﾌﾟ:ﾍﾟｱ搬送数)


    '                '************************************************
    '                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(搬送先)       取得
    '                '************************************************
    '                Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '                objTPRG_TRK_BUF_TO.FTRK_BUF_NO = strDenbunDtl(DSPST_FM)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '                intRet = objTPRG_TRK_BUF_TO.GET_TPRG_TRK_BUF_AKI_HIRA()         '取得
    '                If intRet <> RetCode.OK Then
    '                    '(見つからない場合)
    '                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_TO.FTRK_BUF_NO) & "]"
    '                    Throw New UserException(strMsg)
    '                End If


    '                '************************
    '                '品目ﾏｽﾀ        取得
    '                '************************
    '                Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
    '                objTMST_ITEM.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)        '品目ｺｰﾄﾞ
    '                intRet = objTMST_ITEM.GET_TMST_ITEM(False)                  '取得
    '                If intRet <> RetCode.OK Then
    '                    '(見つからない場合)
    '                    Call AddToMsgLog(Now, FMSG_ID_S0201, objTMST_ITEM.FHINMEI_CD)
    '                    strMsg = ERRMSG_NOTFOUND_TMST_ITEM
    '                    Throw New UserException(strMsg, False)
    '                    'Return RetCode.RollBack
    '                End If


    '                '************************
    '                '在庫情報の登録
    '                '************************
    '                Dim objTRST_STOCK_ADD As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)                     '在庫情報ﾃｰﾌﾞﾙｸﾗｽ
    '                If ii = 1 Then
    '                    '(親の場合)
    '                    Call TRST_STOCKAddProcess(objTRST_STOCK_ADD _
    '                                            , strDenbunDtl(DSPHINMEI_CD) _
    '                                            , dtmNow _
    '                                            , strDenbunDtl(DSPHORYU_KUBUN) _
    '                                            , TO_DECIMAL(strDenbunDtl(DSPTR_VOL)) _
    '                                            , FTR_RES_VOL_SKOTEI _
    '                                            , dtmNow _
    '                                            , strDenbunDtl(XDSPPROD_LINE) _
    '                                            , strDenbunDtl(XDSPKENSA_KUBUN) _
    '                                            , 0 _
    '                                            )
    '                ElseIf ii = 2 Then
    '                    '(子の場合)
    '                    Call TRST_STOCKAddProcess(objTRST_STOCK_ADD _
    '                                            , strDenbunDtl(DSPHINMEI_CD) _
    '                                            , dtmNow _
    '                                            , strDenbunDtl(XDSPHORYU_KUBUN_KO) _
    '                                            , TO_DECIMAL(strDenbunDtl(XDSPTR_VOL_KO)) _
    '                                            , FTR_RES_VOL_SKOTEI _
    '                                            , dtmNow _
    '                                            , strDenbunDtl(XDSPPROD_LINE) _
    '                                            , strDenbunDtl(XDSPKENSA_KUBUN_KO) _
    '                                            , 0 _
    '                                            )
    '                End If


    '                '************************
    '                '在庫登録
    '                '************************
    '                Dim objSYS_100101 As New SVR_100101(Owner, ObjDb, ObjDbLog)         '在庫作成ｸﾗｽ
    '                objSYS_100101.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_TO                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    '                objSYS_100101.FPALLET_ID = objTRST_STOCK_ADD.FPALLET_ID             'ﾊﾟﾚｯﾄID
    '                objSYS_100101.FINOUT_STS = FINOUT_STS_SIN_UKETUKE                   'INOUT(入庫設定)
    '                objSYS_100101.FSAGYOU_KIND = intFSAGYOU_KIND                        '作業種別(ｼｽﾃﾑ保守)
    '                objSYS_100101.STOCK_ADD()                                           '登録


    '                '************************
    '                'ﾊﾟﾚｯﾄID        設定
    '                '************************
    '                If ii = 1 Then
    '                    '(親の場合)
    '                    strFPALLET_ID01 = objSYS_100101.FPALLET_ID
    '                ElseIf ii = 2 Then
    '                    '(子の場合)
    '                    strFPALLET_ID02 = objSYS_100101.FPALLET_ID
    '                End If


    '                '**********************************************
    '                '空棚引当処理
    '                '**********************************************
    '                Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
    '                Dim objSYS_100201 As New SVR_100201(Owner, ObjDb, ObjDbLog) '空棚引当ｸﾗｽ
    '                intRet = AkitanaHikiate(objSYS_100201 _
    '                                      , objTPRG_TRK_BUF_ASRS _
    '                                      , objTPRG_TRK_BUF_TO _
    '                                      , objSYS_100101.FPALLET_ID _
    '                                      , strDenbunDtl(DSPHINMEI_CD) _
    '                                      , FTRK_BUF_NO_J9000 _
    '                                      , True _
    '                                      )


    '                If intRet = RetCode.NotFound Then
    '                    '    '(見つからない場合)
    '                    Call AddToMsgLog(Now, FMSG_ID_S0102, objTPRG_TRK_BUF_TO.FDISP_ADDRESS, "品名ｺｰﾄﾞ:" & strDenbunDtl(DSPHINMEI_CD))
    '                    strMsg = ERRMSG_NOTFOUND_AKI
    '                    Throw New UserException(strMsg, False)
    '                    'Return RetCode.RollBack
    '                End If


    '                '************************
    '                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ST)の更新
    '                '************************
    '                objTPRG_TRK_BUF_TO.FRSV_BUF_TO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO               'TO引当ﾄﾗｯｷﾝｸﾞ№
    '                objTPRG_TRK_BUF_TO.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY          'TO引当配列№
    '                objTPRG_TRK_BUF_TO.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_TO.FDISP_ADDRESS          'FM表記用ｱﾄﾞﾚｽ
    '                objTPRG_TRK_BUF_TO.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS        'TO表記用ｱﾄﾞﾚｽ
    '                objTPRG_TRK_BUF_TO.FBUF_IN_DT = Now                                             'ﾊﾞｯﾌｧ入日時
    '                objTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()                                        '更新


    '                '************************
    '                '倉庫の更新
    '                '************************
    '                objTPRG_TRK_BUF_ASRS.FRSV_PALLET = objTPRG_TRK_BUF_TO.FPALLET_ID        '仮引当PC名
    '                objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                 '引当状態
    '                objTPRG_TRK_BUF_ASRS.FBUF_IN_DT = Now                                   'ﾊﾞｯﾌｧ入日時
    '                objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                              '更新


    '            Next


    '        End If


    '        For ii As Integer = 1 To 2
    '            '(ﾙｰﾌﾟ:ﾍﾟｱ搬送数)


    '            '************************
    '            'ﾊﾟﾚｯﾄID        設定
    '            '************************
    '            Dim strFPALLET_ID As String = Nothing
    '            Select Case ii
    '                Case 1 : strFPALLET_ID = strFPALLET_ID01
    '                Case 2 : strFPALLET_ID = strFPALLET_ID02
    '            End Select
    '            If IsNull(strFPALLET_ID) Then Continue For


    '            '************************
    '            '在庫情報       取得
    '            '************************
    '            Dim objTRST_STOCK_GET As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
    '            objTRST_STOCK_GET.FPALLET_ID = strFPALLET_ID        'ﾊﾟﾚｯﾄID
    '            objTRST_STOCK_GET.GET_TRST_STOCK_KONSAI(True)       '取得


    '            '************************
    '            '在庫引当情報の登録
    '            '************************
    '            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)         '在庫引当情報ｸﾗｽ
    '            objTSTS_HIKIATE.FSAGYOU_KIND = intFSAGYOU_KIND                              '作業種別
    '            objTSTS_HIKIATE.FPLAN_KEY = FPLAN_KEY_SKOTEI                                '計画ｷｰ
    '            objTSTS_HIKIATE.FPALLET_ID = objTRST_STOCK_GET.ARYME(0).FPALLET_ID          'ﾊﾟﾚｯﾄID
    '            objTSTS_HIKIATE.FLOT_NO_STOCK = objTRST_STOCK_GET.ARYME(0).FLOT_NO_STOCK    '在庫ﾛｯﾄ№
    '            objTSTS_HIKIATE.FTR_VOL = objTRST_STOCK_GET.ARYME(0).FTR_VOL                '搬送管理量
    '            objTSTS_HIKIATE.FTERM_ID = DEFAULT_STRING                                   '端末ID
    '            objTSTS_HIKIATE.FUSER_ID = DEFAULT_STRING                                   'ﾕｰｻﾞｰID
    '            'objTSTS_HIKIATE.FWAIT_REASON = "入庫要求待ち"                               '指示送信待ち理由
    '            objTSTS_HIKIATE.FTRNS_START_DT = DEFAULT_DATE                               '搬送開始日時
    '            objTSTS_HIKIATE.FTRNS_END_DT = DEFAULT_DATE                                 '搬送完了日時
    '            objTSTS_HIKIATE.FUPDATE_DT = Now                                            '更新日時
    '            objTSTS_HIKIATE.ADD_TSTS_HIKIATE()                                          '登録


    '        Next


    '        '************************
    '        '次処理起動
    '        '************************
    '        Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
    '        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_J310102)                           '起動


    '        '************************
    '        '正常完了
    '        '************************
    '        Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
    '        Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
    '        Return RetCode.OK


    '    Catch ex As UserException
    '        Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ex.Message)
    '        Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
    '        Call ComUser(ex, MeSyoriID)
    '        Return RetCode.NG
    '    Catch ex As Exception
    '        Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ERRMSG_DISP_ERR)
    '        Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
    '        Call ComError(ex, MeSyoriID)
    '        Return RetCode.NG
    '    End Try
    'End Function

#End Region
#Region "  ﾒｲﾝ処理11(入庫ﾄﾗｯｷﾝｸﾞ作成)                                           一応ﾊﾞｯｸｱｯﾌﾟ02  "
    ''''**********************************************************************************************
    '''' <summary>
    '''' ﾒｲﾝ処理
    '''' </summary>
    '''' <param name="strMSG_RECV">受信電文</param>
    '''' <param name="strMSG_SEND">送信電文</param>
    '''' <returns>OK/NG</returns>
    '''' <remarks></remarks>
    ''''**********************************************************************************************
    'Public Function ExecCmd11(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
    '    Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
    '    Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
    '    Dim strDenbunDtl(0) As String         '電文分解配列
    '    Dim strDenbunDtlName(0) As String     '電文分解名称配列
    '    Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
    '    Dim intRet As RetCode                 '戻り値
    '    Dim strMsg As String                  'ﾒｯｾｰｼﾞ
    '    Try


    '        '************************
    '        '初期処理
    '        '************************
    '        Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
    '        Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
    '        Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
    '        Call CheckBeforeAct(strDenbunDtl)


    '        '************************
    '        '初期設定
    '        '************************
    '        Dim dtmNow As Date = Now
    '        Dim intFSAGYOU_KIND As Integer = strDenbunDtl(DSPSAGYOU_KIND)   '作業種別
    '        Dim blnPair As Boolean                                          'ﾍﾟｱﾌﾗｸﾞ
    '        If strDenbunDtl(XDSPIN_KIND) = XDSPIN_KIND_PAIR Then blnPair = True


    '        '************************************************************************************************
    '        '************************************************************************************************
    '        '1PL目在庫作成
    '        '************************************************************************************************
    '        '************************************************************************************************
    '        '************************************************
    '        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(搬送先)(親)       取得
    '        '************************************************
    '        Dim objTPRG_TRK_BUF_TO_OYA As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '        objTPRG_TRK_BUF_TO_OYA.FTRK_BUF_NO = strDenbunDtl(DSPST_FM)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '        intRet = objTPRG_TRK_BUF_TO_OYA.GET_TPRG_TRK_BUF_AKI_HIRA()         '取得
    '        If intRet <> RetCode.OK Then
    '            '(見つからない場合)
    '            strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_TO_OYA.FTRK_BUF_NO) & "]"
    '            Throw New UserException(strMsg)
    '        End If


    '        '************************
    '        '品目ﾏｽﾀ        取得
    '        '************************
    '        Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
    '        objTMST_ITEM.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)        '品目ｺｰﾄﾞ
    '        intRet = objTMST_ITEM.GET_TMST_ITEM(False)                  '取得
    '        If intRet <> RetCode.OK Then
    '            '(見つからない場合)
    '            Call AddToMsgLog(Now, FMSG_ID_S0201, objTMST_ITEM.FHINMEI_CD)
    '            strMsg = ERRMSG_NOTFOUND_TMST_ITEM
    '            Throw New UserException(strMsg, False)
    '            'Return RetCode.RollBack
    '        End If


    '        '************************
    '        '在庫情報の登録(親)
    '        '************************
    '        Dim objTRST_STOCK_ADD_OYA As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)                     '在庫情報ﾃｰﾌﾞﾙｸﾗｽ
    '        Call TRST_STOCKAddProcess(objTRST_STOCK_ADD_OYA _
    '                                    , strDenbunDtl(DSPHINMEI_CD) _
    '                                    , dtmNow _
    '                                    , strDenbunDtl(DSPHORYU_KUBUN) _
    '                                    , TO_DECIMAL(strDenbunDtl(DSPTR_VOL)) _
    '                                    , FTR_RES_VOL_SKOTEI _
    '                                    , dtmNow _
    '                                    , strDenbunDtl(XDSPPROD_LINE) _
    '                                    , strDenbunDtl(XDSPKENSA_KUBUN) _
    '                                    , 0 _
    '                                    )


    '        '************************
    '        '在庫登録(親)
    '        '************************
    '        Dim objSYS_100101_OYA As New SVR_100101(Owner, ObjDb, ObjDbLog)         '在庫作成ｸﾗｽ
    '        objSYS_100101_OYA.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_TO_OYA              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    '        objSYS_100101_OYA.FPALLET_ID = objTRST_STOCK_ADD_OYA.FPALLET_ID         'ﾊﾟﾚｯﾄID
    '        objSYS_100101_OYA.FINOUT_STS = FINOUT_STS_SIN_UKETUKE                   'INOUT(入庫設定)
    '        objSYS_100101_OYA.FSAGYOU_KIND = intFSAGYOU_KIND                        '作業種別(ｼｽﾃﾑ保守)
    '        objSYS_100101_OYA.STOCK_ADD()                                           '登録


    '        '************************************************************************************************
    '        '************************************************************************************************
    '        '2PL目在庫作成
    '        '************************************************************************************************
    '        '************************************************************************************************
    '        Dim objTPRG_TRK_BUF_TO_KOO As TBL_TPRG_TRK_BUF = Nothing
    '        Dim objTRST_STOCK_ADD_KOO As TBL_TRST_STOCK = Nothing
    '        Dim objSYS_100101_KOO As SVR_100101 = Nothing
    '        If blnPair = True Then
    '            '(ﾍﾟｱ搬送の場合)


    '            '************************************************
    '            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(搬送先)(子)       取得
    '            '************************************************
    '            objTPRG_TRK_BUF_TO_KOO = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '            objTPRG_TRK_BUF_TO_KOO.FTRK_BUF_NO = strDenbunDtl(DSPST_FM)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '            intRet = objTPRG_TRK_BUF_TO_KOO.GET_TPRG_TRK_BUF_AKI_HIRA()         '取得
    '            If intRet <> RetCode.OK Then
    '                '(見つからない場合)
    '                strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_TO_KOO.FTRK_BUF_NO) & "]"
    '                Throw New UserException(strMsg)
    '            End If


    '            '************************
    '            '在庫情報の登録(子)
    '            '************************
    '            objTRST_STOCK_ADD_KOO = New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)                     '在庫情報ﾃｰﾌﾞﾙｸﾗｽ
    '            Call TRST_STOCKAddProcess(objTRST_STOCK_ADD_KOO _
    '                    , strDenbunDtl(DSPHINMEI_CD) _
    '                    , dtmNow _
    '                    , strDenbunDtl(DSPHORYU_KUBUN) _
    '                    , TO_DECIMAL(strDenbunDtl(XDSPTR_VOL_KO)) _
    '                    , FTR_RES_VOL_SKOTEI _
    '                    , dtmNow _
    '                    , strDenbunDtl(XDSPPROD_LINE) _
    '                    , strDenbunDtl(XDSPKENSA_KUBUN) _
    '                    , 0 _
    '                    )


    '            '************************
    '            '在庫登録(子)
    '            '************************
    '            objSYS_100101_KOO = New SVR_100101(Owner, ObjDb, ObjDbLog)              '在庫作成ｸﾗｽ
    '            objSYS_100101_KOO.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_TO_KOO              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    '            objSYS_100101_KOO.FPALLET_ID = objTRST_STOCK_ADD_KOO.FPALLET_ID         'ﾊﾟﾚｯﾄID
    '            objSYS_100101_KOO.FINOUT_STS = FINOUT_STS_SIN_UKETUKE                   'INOUT(入庫設定)
    '            objSYS_100101_KOO.FSAGYOU_KIND = intFSAGYOU_KIND                        '作業種別(ｼｽﾃﾑ保守)
    '            objSYS_100101_KOO.STOCK_ADD()                                           '登録


    '        End If


    '        '************************************************************************************************
    '        '************************************************************************************************
    '        '空棚引当処理
    '        '************************************************************************************************
    '        '************************************************************************************************
    '        '**********************************************
    '        '空棚引当処理
    '        '**********************************************
    '        Dim objTPRG_TRK_BUF_ASRS_OYA As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
    '        Dim objTPRG_TRK_BUF_ASRS_KOO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
    '        Dim objSYS_100201 As New SVR_100201(Owner, ObjDb, ObjDbLog) '空棚引当ｸﾗｽ
    '        intRet = AkitanaHikiate(objSYS_100201 _
    '                              , objTPRG_TRK_BUF_ASRS_OYA _
    '                              , objTPRG_TRK_BUF_ASRS_KOO _
    '                              , objTPRG_TRK_BUF_TO_OYA _
    '                              , objSYS_100101_OYA.FPALLET_ID _
    '                              , strDenbunDtl(DSPHINMEI_CD) _
    '                              , FTRK_BUF_NO_J9000 _
    '                              , True _
    '                              , blnPair _
    '                              )
    '        If intRet = RetCode.NotFound Then
    '            '    '(見つからない場合)
    '            Call AddToMsgLog(Now, FMSG_ID_S0102, objTPRG_TRK_BUF_TO_OYA.FDISP_ADDRESS, "品名ｺｰﾄﾞ:" & strDenbunDtl(DSPHINMEI_CD))
    '            strMsg = ERRMSG_NOTFOUND_AKI
    '            Throw New UserException(strMsg, False)
    '            'Return RetCode.RollBack
    '        End If


    '        '************************************************************************************************
    '        '************************************************************************************************
    '        '1PL目設定
    '        '************************************************************************************************
    '        '************************************************************************************************
    '        '******************************************
    '        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ST)(親)の更新
    '        '******************************************
    '        objTPRG_TRK_BUF_TO_OYA.FRSV_BUF_TO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_NO               'TO引当ﾄﾗｯｷﾝｸﾞ№
    '        objTPRG_TRK_BUF_TO_OYA.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ASRS_OYA.FTRK_BUF_ARRAY          'TO引当配列№
    '        objTPRG_TRK_BUF_TO_OYA.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_TO_OYA.FDISP_ADDRESS          'FM表記用ｱﾄﾞﾚｽ
    '        objTPRG_TRK_BUF_TO_OYA.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_ASRS_OYA.FDISP_ADDRESS        'TO表記用ｱﾄﾞﾚｽ
    '        objTPRG_TRK_BUF_TO_OYA.FBUF_IN_DT = Now                                                 'ﾊﾞｯﾌｧ入日時
    '        objTPRG_TRK_BUF_TO_OYA.UPDATE_TPRG_TRK_BUF()                                            '更新


    '        '************************
    '        '倉庫の更新(親)
    '        '************************
    '        objTPRG_TRK_BUF_ASRS_OYA.FRSV_PALLET = objTPRG_TRK_BUF_TO_OYA.FPALLET_ID    '仮引当PC名
    '        objTPRG_TRK_BUF_ASRS_OYA.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                 '引当状態
    '        objTPRG_TRK_BUF_ASRS_OYA.FBUF_IN_DT = Now                                   'ﾊﾞｯﾌｧ入日時
    '        objTPRG_TRK_BUF_ASRS_OYA.UPDATE_TPRG_TRK_BUF()                              '更新


    '        '************************
    '        '在庫情報(親)       取得
    '        '************************
    '        Dim objTRST_STOCK_GET_OYA As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
    '        objTRST_STOCK_GET_OYA.FPALLET_ID = objSYS_100101_OYA.FPALLET_ID     'ﾊﾟﾚｯﾄID
    '        objTRST_STOCK_GET_OYA.GET_TRST_STOCK_KONSAI(True)                   '取得


    '        '************************
    '        '在庫引当情報(親)の登録
    '        '************************
    '        Dim objTSTS_HIKIATE_OYA As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)             '在庫引当情報ｸﾗｽ
    '        objTSTS_HIKIATE_OYA.FSAGYOU_KIND = intFSAGYOU_KIND                                  '作業種別
    '        objTSTS_HIKIATE_OYA.FPLAN_KEY = FPLAN_KEY_SKOTEI                                    '計画ｷｰ
    '        objTSTS_HIKIATE_OYA.FPALLET_ID = objTRST_STOCK_GET_OYA.ARYME(0).FPALLET_ID          'ﾊﾟﾚｯﾄID
    '        objTSTS_HIKIATE_OYA.FLOT_NO_STOCK = objTRST_STOCK_GET_OYA.ARYME(0).FLOT_NO_STOCK    '在庫ﾛｯﾄ№
    '        objTSTS_HIKIATE_OYA.FTR_VOL = objTRST_STOCK_GET_OYA.ARYME(0).FTR_VOL                '搬送管理量
    '        objTSTS_HIKIATE_OYA.FTERM_ID = DEFAULT_STRING                                       '端末ID
    '        objTSTS_HIKIATE_OYA.FUSER_ID = DEFAULT_STRING                                       'ﾕｰｻﾞｰID
    '        'objTSTS_HIKIATE_OYA.FWAIT_REASON = "入庫要求待ち"                                   '指示送信待ち理由
    '        objTSTS_HIKIATE_OYA.FTRNS_START_DT = DEFAULT_DATE                                   '搬送開始日時
    '        objTSTS_HIKIATE_OYA.FTRNS_END_DT = DEFAULT_DATE                                     '搬送完了日時
    '        objTSTS_HIKIATE_OYA.FUPDATE_DT = Now                                                '更新日時
    '        objTSTS_HIKIATE_OYA.ADD_TSTS_HIKIATE()                                              '登録


    '        '************************************************************************************************
    '        '************************************************************************************************
    '        '2PL目設定
    '        '************************************************************************************************
    '        '************************************************************************************************
    '        If blnPair = True Then
    '            '(ﾍﾟｱ搬送の場合)


    '            '******************************************
    '            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ST)(子)の更新
    '            '******************************************
    '            objTPRG_TRK_BUF_TO_KOO.FRSV_BUF_TO = objTPRG_TRK_BUF_ASRS_KOO.FTRK_BUF_NO               'TO引当ﾄﾗｯｷﾝｸﾞ№
    '            objTPRG_TRK_BUF_TO_KOO.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ASRS_KOO.FTRK_BUF_ARRAY          'TO引当配列№
    '            objTPRG_TRK_BUF_TO_KOO.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_TO_KOO.FDISP_ADDRESS          'FM表記用ｱﾄﾞﾚｽ
    '            objTPRG_TRK_BUF_TO_KOO.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_ASRS_KOO.FDISP_ADDRESS        'TO表記用ｱﾄﾞﾚｽ
    '            objTPRG_TRK_BUF_TO_KOO.FBUF_IN_DT = Now                                                 'ﾊﾞｯﾌｧ入日時
    '            objTPRG_TRK_BUF_TO_KOO.UPDATE_TPRG_TRK_BUF()                                            '更新


    '            '************************
    '            '倉庫の更新(子)
    '            '************************
    '            objTPRG_TRK_BUF_ASRS_KOO.FRSV_PALLET = objTPRG_TRK_BUF_TO_KOO.FPALLET_ID    '仮引当PC名
    '            objTPRG_TRK_BUF_ASRS_KOO.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                 '引当状態
    '            objTPRG_TRK_BUF_ASRS_KOO.FBUF_IN_DT = Now                                   'ﾊﾞｯﾌｧ入日時
    '            objTPRG_TRK_BUF_ASRS_KOO.UPDATE_TPRG_TRK_BUF()                              '更新


    '            '************************
    '            '在庫情報(子)       取得
    '            '************************
    '            Dim objTRST_STOCK_GET_KOO As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
    '            objTRST_STOCK_GET_KOO.FPALLET_ID = objSYS_100101_KOO.FPALLET_ID     'ﾊﾟﾚｯﾄID
    '            objTRST_STOCK_GET_KOO.GET_TRST_STOCK_KONSAI(True)                   '取得


    '            '************************
    '            '在庫引当情報(子)の登録
    '            '************************
    '            Dim objTSTS_HIKIATE_KOO As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)             '在庫引当情報ｸﾗｽ
    '            objTSTS_HIKIATE_KOO.FSAGYOU_KIND = intFSAGYOU_KIND                                  '作業種別
    '            objTSTS_HIKIATE_KOO.FPLAN_KEY = FPLAN_KEY_SKOTEI                                    '計画ｷｰ
    '            objTSTS_HIKIATE_KOO.FPALLET_ID = objTRST_STOCK_GET_KOO.ARYME(0).FPALLET_ID          'ﾊﾟﾚｯﾄID
    '            objTSTS_HIKIATE_KOO.FLOT_NO_STOCK = objTRST_STOCK_GET_KOO.ARYME(0).FLOT_NO_STOCK    '在庫ﾛｯﾄ№
    '            objTSTS_HIKIATE_KOO.FTR_VOL = objTRST_STOCK_GET_KOO.ARYME(0).FTR_VOL                '搬送管理量
    '            objTSTS_HIKIATE_KOO.FTERM_ID = DEFAULT_STRING                                       '端末ID
    '            objTSTS_HIKIATE_KOO.FUSER_ID = DEFAULT_STRING                                       'ﾕｰｻﾞｰID
    '            'objTSTS_HIKIATE_KOO.FWAIT_REASON = "入庫要求待ち"                                   '指示送信待ち理由
    '            objTSTS_HIKIATE_KOO.FTRNS_START_DT = DEFAULT_DATE                                   '搬送開始日時
    '            objTSTS_HIKIATE_KOO.FTRNS_END_DT = DEFAULT_DATE                                     '搬送完了日時
    '            objTSTS_HIKIATE_KOO.FUPDATE_DT = Now                                                '更新日時
    '            objTSTS_HIKIATE_KOO.ADD_TSTS_HIKIATE()                                              '登録


    '        End If


    '        '************************************************
    '        '棚ﾌﾞﾛｯｸ状態の更新
    '        '************************************************
    '        Call UpdateTPRG_TRK_BUF_Relation_XTANA_BLOCK_STS(objTPRG_TRK_BUF_ASRS_OYA, XTANA_BLOCK_STS_IN)


    '        '************************
    '        '次処理起動
    '        '************************
    '        Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
    '        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_J310102)                           '起動


    '        '************************
    '        '正常完了
    '        '************************
    '        Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
    '        Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
    '        Return RetCode.OK


    '    Catch ex As UserException
    '        Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ex.Message)
    '        Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
    '        Call ComUser(ex, MeSyoriID)
    '        Return RetCode.NG
    '    Catch ex As Exception
    '        Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ERRMSG_DISP_ERR)
    '        Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
    '        Call ComError(ex, MeSyoriID)
    '        Return RetCode.NG
    '    End Try
    'End Function

#End Region
    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

#Region "  入庫設定(平置き)                                                                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' 入庫設定(平置き)
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function ExecCmd11(ByVal strDenbunDtl() As String _
                            , ByVal strMSG_RECV As String _
                            , ByRef strMSG_SEND As String _
                            ) _
                            As RetCode
        Dim intRet As RetCode                 '戻り値
        Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        Dim dtmNow As Date = Now


        '*****************************************************
        'ﾛｯﾄ№取得
        '*****************************************************
        Dim strFLOT_NO As String = ""               'ﾛｯﾄ№
        If IsNull(strDenbunDtl(DSPARRIVE_DT)) Then
            '(在庫発生日時が設定されていなかった場合)
            Call GetFLOT_NO(strFLOT_NO, strDenbunDtl(XDSPPROD_LINE))
        Else
            '(在庫発生日時が設定されていた場合)
            strFLOT_NO = strDenbunDtl(XDSPPROD_LINE) & Format(TO_DATE(strDenbunDtl(DSPARRIVE_DT)), "yyyyMMdd")
        End If


        '************************
        '品目ﾏｽﾀ        取得
        '************************
        Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
        objTMST_ITEM.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)        '品目ｺｰﾄﾞ
        intRet = objTMST_ITEM.GET_TMST_ITEM(False)                  '取得
        If intRet <> RetCode.OK Then
            '(見つからない場合)
            Call AddToMsgLog(Now, FMSG_ID_S0201, objTMST_ITEM.FHINMEI_CD)
            strMsg = ERRMSG_NOTFOUND_TMST_ITEM
            Throw New UserException(strMsg, False)
            'Return RetCode.RollBack
        End If


        '************************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(平置)         取得
        '************************************************
        Dim objTPRG_TRK_BUF_HIRA As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        objTPRG_TRK_BUF_HIRA.FTRK_BUF_NO = strDenbunDtl(DSPST_TO)            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTPRG_TRK_BUF_HIRA.GET_TPRG_TRK_BUF_AKI_HIRA()                     '取得


        '************************
        '在庫情報の登録(親)
        '************************
        Dim objTRST_STOCK_ADD_OYA As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)         '在庫情報ﾃｰﾌﾞﾙｸﾗｽ
        Dim dtmFARRIVE_DT As Date = IIf(IsNotNull(strDenbunDtl(DSPARRIVE_DT)), TO_DATE(strDenbunDtl(DSPARRIVE_DT)), Now)    '在庫発生日時
        Call TRST_STOCKAddProcess(objTRST_STOCK_ADD_OYA _
                                , strDenbunDtl(DSPHINMEI_CD) _
                                , strFLOT_NO _
                                , dtmFARRIVE_DT _
                                , TO_INTEGER_NULLABLE(strDenbunDtl(DSPIN_KUBUN)) _
                                , TO_INTEGER_NULLABLE(strDenbunDtl(DSPHORYU_KUBUN)) _
                                , TO_DECIMAL(strDenbunDtl(DSPTR_VOL)) _
                                , FTR_RES_VOL_SKOTEI _
                                , dtmNow _
                                , strDenbunDtl(XDSPPROD_LINE) _
                                , strDenbunDtl(XDSPKENSA_KUBUN) _
                                , strDenbunDtl(XDSPKENPIN_KUBUN) _
                                , strDenbunDtl(XDSPMAKER_CD) _
                                , objTPRG_TRK_BUF_HIRA.FTRK_BUF_NO _
                                )


        '************************
        '在庫登録(親)
        '************************
        Dim objSYS_100101_OYA As New SVR_100101(Owner, ObjDb, ObjDbLog)         '在庫作成ｸﾗｽ
        objSYS_100101_OYA.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_HIRA                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        objSYS_100101_OYA.FPALLET_ID = objTRST_STOCK_ADD_OYA.FPALLET_ID         'ﾊﾟﾚｯﾄID
        objSYS_100101_OYA.FINOUT_STS = FINOUT_STS_SIN_UKETUKE                   'INOUT(入庫設定)
        objSYS_100101_OYA.FSAGYOU_KIND = FSAGYOU_KIND_SIN                       '作業種別
        objSYS_100101_OYA.STOCK_ADD()                                           '登録


    End Function
#End Region

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
