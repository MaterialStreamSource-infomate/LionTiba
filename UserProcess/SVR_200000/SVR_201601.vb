'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】問合せ出庫
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_201601
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0         '端末ID
    Private Const DSPUSER_ID As Integer = 1         'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2          '理由
    Private Const DSPPALLET_ID As Integer = 3       'ﾊﾟﾚｯﾄID
    Private Const DSPST_OUT As Integer = 4          '出庫先ST
    Private Const XDSPPALLET_ID_KO As Integer = 5   'ﾊﾟﾚｯﾄID(子)
    Private Const XDSPYOTEI_NUM As Integer = 6      '予定数
    Private Const XDSPYOTEI_EQ_ID As Integer = 7    '予定設備ID


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
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/04/01  出庫時には予定数を設定しなければならないので、全ての処理が完了してからｺﾐｯﾄorﾛｰﾙﾊﾞｯｸする
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


                    Dim objTel As New clsTelegram(CONFIG_TELEGRAM_DSP)  '受信用電文
                    objTel.FORMAT_ID = MeDSPID                          'ﾌｫｰﾏｯﾄ名ｾｯﾄ
                    objTel.TELEGRAM_PARTITION = objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA      '分割する電文ｾｯﾄ
                    objTel.PARTITION()                                  '電文分割


                    If IsNull(Trim(objTel.SELECT_DATA("XDSPYOTEI_NUM"))) And IsNull(Trim(objTel.SELECT_DATA("XDSPYOTEI_EQ_ID"))) Then
                        '(予定数、予定設備IDが設定されていない場合)


                        '************************
                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
                        '************************
                        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
                        objTPRG_TRK_BUF.FPALLET_ID = Trim(objTel.SELECT_DATA("DSPPALLET_ID"))       'ﾊﾟﾚｯﾄID
                        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)                             '特定
                        If intRet = RetCode.OK And objTPRG_TRK_BUF.FTRK_BUF_NO = FTRK_BUF_NO_J9000 Then
                            '(出庫元が、自動倉庫の場合)


                            '************************************************
                            'ﾒｲﾝ処理11(出庫ﾄﾗｯｷﾝｸﾞ作成)
                            '************************************************
                            intRet = ExecCmd11(objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA, strMSG_SEND)


                        Else
                            '(出庫元が、自動倉庫以外の場合)


                            '************************************************
                            'ﾒｲﾝ処理21(平置き在庫削除)
                            '************************************************
                            intRet = ExecCmd21(objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA, strMSG_SEND)


                        End If


                    Else
                        '(予定数設定の場合)


                        '************************************************
                        'ﾒｲﾝ処理12(予定数設定)
                        '************************************************
                        intRet = ExecCmd12(objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA, strMSG_SEND)
                        

                    End If


                Next
            End If
            objTPRG_PARAM_TBL.ARYME_CLEAR()


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
#Region "  ﾒｲﾝ処理11(出庫ﾄﾗｯｷﾝｸﾞ作成)                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理11(出庫ﾄﾗｯｷﾝｸﾞ作成)
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecCmd11(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
        Dim strDenbunDtl(0) As String         '電文分解配列
        Dim strDenbunDtlName(0) As String     '電文分解名称配列
        Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        '************************
        '初期処理
        '************************
        Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
        Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
        Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
        Call CheckBeforeAct(strDenbunDtl)


        For ii As Integer = 1 To 2
            '(ﾙｰﾌﾟ:ﾍﾟｱ搬送)


            '************************************
            '作業種別       設定
            '************************************
            Dim intFSAGYOU_KIND As Integer          '作業種別
            Dim intXOYAKO_KUBUN As Integer          '親子区分
            Dim strFPALLET_ID As String = ""        '出庫ﾊﾟﾚｯﾄID
            Dim strXPALLET_ID_AITE As String = ""   '相手ﾊﾟﾚｯﾄID
            If ii = 1 Then
                '(1PL目の場合)
                If IsNotNull(strDenbunDtl(XDSPPALLET_ID_KO)) Then
                    intFSAGYOU_KIND = FSAGYOU_KIND_J71                  '作業種別
                Else
                    intFSAGYOU_KIND = FSAGYOU_KIND_J72                  '作業種別
                End If
                intXOYAKO_KUBUN = XOYAKO_KUBUN_JOYA                     '親子区分
                strFPALLET_ID = strDenbunDtl(DSPPALLET_ID)              '出庫ﾊﾟﾚｯﾄID
                strXPALLET_ID_AITE = strDenbunDtl(XDSPPALLET_ID_KO)     '相手ﾊﾟﾚｯﾄID
            ElseIf ii = 2 Then
                '(2PL目の場合)
                If IsNotNull(strDenbunDtl(XDSPPALLET_ID_KO)) Then
                    '(子の出庫がある場合)
                    intFSAGYOU_KIND = FSAGYOU_KIND_J71                      '作業種別
                    intXOYAKO_KUBUN = XOYAKO_KUBUN_JKO                      '親子区分
                    strFPALLET_ID = strDenbunDtl(XDSPPALLET_ID_KO)          '出庫ﾊﾟﾚｯﾄID
                    strXPALLET_ID_AITE = strDenbunDtl(DSPPALLET_ID)         '相手ﾊﾟﾚｯﾄID
                Else
                    '(子の出庫がない場合)
                    Exit For
                End If
            End If


            '************************************
            '出庫ﾄﾗｯｷﾝｸﾞ定義ｸﾗｽ(ﾊﾟﾚｯﾄID指定)
            '************************************
            Dim objSVR_100501 As New SVR_100501(Owner, ObjDb, ObjDbLog)
            objSVR_100501.FTRK_BUF_NO_TO = TO_INTEGER(strDenbunDtl(DSPST_OUT))          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(出庫先ﾄﾗｯｷﾝｸﾞ)
            objSVR_100501.FPALLET_ID = strFPALLET_ID                                    'ﾊﾟﾚｯﾄID
            objSVR_100501.FSAGYOU_KIND = intFSAGYOU_KIND                                '作業種別
            objSVR_100501.FTERM_ID = strDenbunDtl(DSPTERM_ID)                           '端末ID
            objSVR_100501.FUSER_ID = strDenbunDtl(DSPUSER_ID)                           'ﾕｰｻﾞｰID
            objSVR_100501.UPDATE_OUT_BUF(FTR_VOL_SFULL)                                 '定義


            '************************
            '搬送指示QUEの特定
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)         '搬送指示QUE
            objTPLN_CARRY_QUE.FPALLET_ID = strFPALLET_ID                                    'ﾊﾟﾚｯﾄID
            objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                                          '特定


            '************************
            '搬送指示QUEの更新
            '************************
            objTPLN_CARRY_QUE.XOYAKO_KUBUN = intXOYAKO_KUBUN            '親子区分
            objTPLN_CARRY_QUE.XPALLET_ID_AITE = strXPALLET_ID_AITE      '相手ﾊﾟﾚｯﾄID
            objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                   '更新


        Next


        '************************
        '正常完了
        '************************
        Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
        Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
        Return RetCode.OK


    End Function
#End Region
#Region "  ﾒｲﾝ処理12(予定数設定)                                                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理12(予定数設定)
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecCmd12(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
        Dim strDenbunDtl(0) As String         '電文分解配列
        Dim strDenbunDtlName(0) As String     '電文分解名称配列
        Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        '************************
        '初期処理
        '************************
        Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
        Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
        Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
        Call CheckBeforeAct(strDenbunDtl)


        '************************************
        'ﾄﾗｯｷﾝｸﾞの特定
        '************************************
        Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        objTMST_TRK.FTRK_BUF_NO = strDenbunDtl(DSPST_OUT)       '出庫先ST
        objTMST_TRK.GET_TMST_TRK()                              '特定


        ''************************************************************************
        ''ﾛｰｶﾙ設備ID           → 設備ID(送信PLC)          変換
        ''************************************************************************
        'Dim strFEQ_ID As String
        'strFEQ_ID = GetXEQ_ID_SendFromFEQ_ID_LOCAL(objTMST_TRK.XADRS_YOTEI)


        If IsNotNull(objTMST_TRK.XADRS_YOTEI01) Then
            '(予定数を設定する場合)


            '************************************************
            '予定数                       取得
            '************************************************
            Dim intYotei01 As Integer = 0
            Dim intYotei02 As Integer = 0
            Call GetYoteiNum(objTMST_TRK, intYotei01, intYotei02)
            'Call CheckYoteiPalletNum(objTMST_TRK)


            '************************************************
            '安川         到着予定数
            '************************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            'objSVR_190001.FEQ_ID = strFEQ_ID                                '設備ID
            objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         'ｺﾏﾝﾄﾞID
            objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK.FTRK_BUF_NO _
                                                  , intYotei01 + TO_INTEGER(strDenbunDtl(XDSPYOTEI_NUM)) _
                                                  )


        End If


        '************************
        '正常完了
        '************************
        Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
        Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
        Return RetCode.OK


    End Function
#End Region
#Region "  ﾒｲﾝ処理21(平置き在庫削除)                                                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理21(平置き在庫削除)
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecCmd21(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
        Dim strDenbunDtl(0) As String         '電文分解配列
        Dim strDenbunDtlName(0) As String     '電文分解名称配列
        Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        '************************
        '初期処理
        '************************
        Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
        Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
        Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
        Call CheckBeforeAct(strDenbunDtl)


        '************************
        '平置き在庫削除
        '************************
        Call DeleteHiraoki(strDenbunDtl(DSPPALLET_ID) _
                         , FINOUT_STS_SOUT_END _
                         , FSAGYOU_KIND_SSYSTEM_MENTE_NON _
                         )


        '************************
        '正常完了
        '************************
        Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
        Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
        Return RetCode.OK


    End Function
#End Region

#Region "  ﾒｲﾝ処理                                                                          _old"
    '''' *******************************************************************************************************************
    '''' <summary>
    '''' ﾒｲﾝ処理
    '''' </summary>
    '''' <param name="strMSG_RECV">受信電文</param>
    '''' <param name="strMSG_SEND">送信電文</param>
    '''' <returns>OK/NG</returns>
    '''' <remarks></remarks>
    '''' *******************************************************************************************************************
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


    '        '************************************
    '        'ﾄﾗｯｷﾝｸﾞの特定
    '        '************************************
    '        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '        objTPRG_TRK_BUF.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)     'ﾊﾟﾚｯﾄID
    '        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)             '特定


    '        '************************************
    '        '作業種別       設定
    '        '************************************
    '        Dim intFSAGYOU_KIND As Integer          '作業種別
    '        Select Case objTPRG_TRK_BUF.FTRK_BUF_NO
    '            Case FTRK_BUF_NO_J9000
    '                '(製品自動倉庫の問合せ出庫の場合)
    '                intFSAGYOU_KIND = FSAGYOU_KIND_STOI_OUT
    '            Case Else
    '                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & objTPRG_TRK_BUF.FTRK_BUF_NO & "][ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF.FPALLET_ID & "]"
    '                Throw New UserException(strMsg)
    '        End Select


    '        '************************************
    '        '出庫ﾄﾗｯｷﾝｸﾞ定義ｸﾗｽ(ﾊﾟﾚｯﾄID指定)
    '        '************************************
    '        Dim objSVR_100501 As New SVR_100501(Owner, ObjDb, ObjDbLog)
    '        objSVR_100501.FTRK_BUF_NO_TO = TO_INTEGER(strDenbunDtl(DSPST_OUT))          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(出庫先ﾄﾗｯｷﾝｸﾞ)
    '        objSVR_100501.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)                       'ﾊﾟﾚｯﾄID
    '        objSVR_100501.FSAGYOU_KIND = intFSAGYOU_KIND                                '作業種別
    '        objSVR_100501.FTERM_ID = strDenbunDtl(DSPTERM_ID)                           '端末ID
    '        objSVR_100501.FUSER_ID = strDenbunDtl(DSPUSER_ID)                           'ﾕｰｻﾞｰID
    '        objSVR_100501.UPDATE_OUT_BUF(FTR_VOL_SFULL)                                 '定義


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
    '↑↑↑↑↑↑************************************************************************************************************
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


End Class
