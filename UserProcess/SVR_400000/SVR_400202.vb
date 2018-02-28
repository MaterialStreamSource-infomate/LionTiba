'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｺﾝﾍﾞﾔ用途設定受付
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_400202
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0             '端末ID
    Private Const DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2              '理由
    Private Const XDSPSTNO As Integer = 3               'ST№
    Private Const XDSPCONVEYOR_YOUTO As Integer = 4     'ｺﾝﾍﾞﾔ用途
    Private Const XDSPBERTH_GROUP As Integer = 5        'ﾊﾞｰｽｸﾞﾙｰﾌﾟ


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
        'Dim intRet As RetCode                 '戻り値
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
            'ﾒｲﾝ処理11(設定ﾓｰﾄﾞ更新)
            '************************
            Call ExecCmd11(strMSG_RECV, strMSG_SEND)


            '************************
            'ﾒｲﾝ処理12(ﾊﾞｰｽｸﾞﾙｰﾌﾟ更新)
            '************************
            Call ExecCmd12(strMSG_RECV, strMSG_SEND)


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
#Region "  ﾒｲﾝ処理11(設定ﾓｰﾄﾞ更新)                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理11(設定ﾓｰﾄﾞ更新)
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
        Dim intRet As RetCode                 '戻り値
        Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        '************************
        '初期処理
        '************************
        Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
        Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
        Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
        Call CheckBeforeAct(strDenbunDtl)


        '-------------------
        'ｽﾃｰｼｮﾝﾏｽﾀの特定
        '-------------------
        Dim objTMST_ST As New TBL_TMST_ST(Owner, ObjDb, ObjDbLog)           'ｽﾃｰｼｮﾝﾏｽﾀｸﾗｽ
        objTMST_ST.FTRK_BUF_NO = TO_INTEGER(strDenbunDtl(XDSPSTNO))         'ｽﾃｰｼｮﾝNo(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№として使用)
        intRet = objTMST_ST.GET_TMST_ST()                                   '特定
        If intRet = RetCode.NotFound Then
            '(見つからない場合)
            strMsg = ERRMSG_NOTFOUND_TMST_ST & "[STNo:" & objTMST_ST.FTRK_BUF_NO & "]"
            Throw New System.Exception(strMsg)
        End If


        ''-------------------
        ''設備状況の特定
        ''-------------------
        'Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     '設備状況ｸﾗｽ
        'objTSTS_EQ_CTRL.FEQ_ID = objTMST_ST.FEQ_ID                              '設備ID
        'intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                             '特定
        'If intRet = RetCode.NotFound Then
        '    '(見つからない場合)
        '    strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]"
        '    Throw New System.Exception(strMsg)
        'End If


        '-------------------
        '出庫中ﾁｪｯｸ
        '-------------------
        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
        objTPRG_TRK_BUF.FTR_TO = TO_INTEGER(strDenbunDtl(XDSPSTNO))             '搬送ToﾊﾞｯﾌｧNo
        If 0 < objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_COUNT() Then
            strMsg = ERRMSG_DISP_USE_ST & "[ｽﾃｰｼｮﾝNo:" & objTPRG_TRK_BUF.FTR_TO & "(出庫中)]"
            Throw New System.Exception(strMsg)
        End If


        '-------------------
        'ｽﾃｰｼｮﾝﾁｪｯｸ
        '-------------------
        Dim strSQL As String                    'SQL文
        objTPRG_TRK_BUF.CLEAR_PROPERTY()
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & "    * "
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    TPRG_TRK_BUF "
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        FTRK_BUF_NO = " & TO_INTEGER(strDenbunDtl(XDSPSTNO))    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
        strSQL &= vbCrLf & "    AND FTR_TO <> " & FTRK_BUF_NO_J9000                         '搬送ToﾊﾞｯﾌｧNo
        strSQL &= vbCrLf & "    AND FRES_KIND = " & FRES_KIND_SZAIKO                        '在庫引当状態
        strSQL &= vbCrLf
        objTPRG_TRK_BUF.USER_SQL = strSQL
        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_USER()
        If intRet <> RetCode.NotFound Then
            '(出庫中の場合)
            strMsg = ERRMSG_DISP_USE_ST & "[ｽﾃｰｼｮﾝNo:" & objTPRG_TRK_BUF.FTR_TO & "(出庫中)]"
            Throw New System.Exception(strMsg)
        End If


        '-------------------
        '入庫中ﾁｪｯｸ
        '-------------------
        objTPRG_TRK_BUF.CLEAR_PROPERTY()
        objTPRG_TRK_BUF.FTRK_BUF_NO = TO_INTEGER(strDenbunDtl(XDSPSTNO))        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTPRG_TRK_BUF.FTR_TO = FTRK_BUF_NO_J9000                              '搬送ToﾊﾞｯﾌｧNo
        If 0 < objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_COUNT() Then
            '(入庫中の場合)
            strMsg = ERRMSG_DISP_USE_ST & "[ｽﾃｰｼｮﾝNo:" & objTPRG_TRK_BUF.FTR_TO & "(入庫中)]"
            Throw New System.Exception(strMsg)
        End If


        '-------------------
        '出荷ｺﾝﾍﾞﾔ状況更新
        '-------------------
        Dim objXSTS_CONVEYER As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)       '出荷ｺﾝﾍﾞﾔ状況ｸﾗｽ
        objXSTS_CONVEYER.XSTNO = TO_INTEGER(strDenbunDtl(XDSPSTNO))                 'STNo
        intRet = objXSTS_CONVEYER.GET_XSTS_CONVEYOR()                               '特定
        If intRet = RetCode.NotFound Then
            '(見つからない場合)
            strMsg = ERRMSG_NOTFOUND_XSTS_CONVEYOR & "[STNo:" & objXSTS_CONVEYER.XSTNO & "]"
            Throw New System.Exception(strMsg)
        End If
        objXSTS_CONVEYER.XCONVEYOR_YOUTO = TO_INTEGER(strDenbunDtl(XDSPCONVEYOR_YOUTO))     'ｺﾝﾍﾞﾔ用途   
        objXSTS_CONVEYER.UPDATE_XSTS_CONVEYOR()                                             '更新


        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/11/14 ｺﾝﾍﾞﾔ用途変更時 切離状態をｾｯﾄ
        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     '設備状況ｸﾗｽ
        objTSTS_EQ_CTRL.FTRK_BUF_NO = TO_INTEGER(strDenbunDtl(XDSPSTNO))        '設備ID
        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                             '特定
        If intRet = RetCode.OK Then
            If TO_INTEGER(strDenbunDtl(XDSPCONVEYOR_YOUTO)) = XCONVEYOR_YOUTO_JDOWN Then
                objTSTS_EQ_CTRL.FEQ_CUT_STS = FLAG_ON
            Else
                objTSTS_EQ_CTRL.FEQ_CUT_STS = FLAG_OFF
            End If
            objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()
        End If
        'JobMate:S.Ouchi 2013/11/14 ｺﾝﾍﾞﾔ用途変更時 切離状態をｾｯﾄ
        '↑↑↑↑↑↑************************************************************************************************************


        '-------------------
        '通信電文の作成
        '-------------------
        Dim strData01_02 As String = ""     'ﾃﾞｰﾀ01(02進数)
        Dim strData02_02 As String = ""     'ﾃﾞｰﾀ02(02進数)
        Dim strData03_02 As String = ""     'ﾃﾞｰﾀ03(02進数)
        Dim strData04_02 As String = ""     'ﾃﾞｰﾀ04(02進数)
        Dim strData05_02 As String = ""     'ﾃﾞｰﾀ05(02進数)
        Dim strData06_02 As String = ""     'ﾃﾞｰﾀ06(02進数)
        Dim strData07_02 As String = ""     'ﾃﾞｰﾀ07(02進数)

        Dim strData01_10 As String = ""     'ﾃﾞｰﾀ01(10進数)
        Dim strData02_10 As String = ""     'ﾃﾞｰﾀ02(10進数)
        Dim strData03_10 As String = ""     'ﾃﾞｰﾀ03(10進数)
        Dim strData04_10 As String = ""     'ﾃﾞｰﾀ04(10進数)
        Dim strData05_10 As String = ""     'ﾃﾞｰﾀ05(10進数)
        Dim strData06_10 As String = ""     'ﾃﾞｰﾀ06(10進数)
        Dim strData07_10 As String = ""     'ﾃﾞｰﾀ07(10進数)


        For intII As Integer = 1 To 7
            '(7電文繰り返す)
            Dim strDENBUN As String = ""            '電文
            Dim objXSTS_CONVEYER_MAKE_ARY As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)       '出荷ｺﾝﾍﾞﾔ状況ｸﾗｽ
            objXSTS_CONVEYER_MAKE_ARY.XCONVEYOR_GROUP = intII
            objXSTS_CONVEYER_MAKE_ARY.ORDER_BY = " XCONVEYOR_ORDER "
            intRet = objXSTS_CONVEYER_MAKE_ARY.GET_XSTS_CONVEYOR_ANY()                           '特定
            For Each objXSTS_CONVEYER_MAKE As TBL_XSTS_CONVEYOR In objXSTS_CONVEYER_MAKE_ARY.ARYME
                '(ﾙｰﾌﾟ:取得件数分)

                '**********************************
                ' ｺﾝﾍﾞﾔ用途
                '**********************************
                Dim strCV_MODE As String = ""           'ｺﾝﾍﾞﾔ用途
                Select Case objXSTS_CONVEYER_MAKE.XCONVEYOR_YOUTO
                    Case XCONVEYOR_YOUTO_JPALLET, XCONVEYOR_YOUTO_JBARA
                        '(ﾊﾟﾚｯﾄ,ﾊﾞﾗのとき)
                        strCV_MODE = "100"
                    Case XCONVEYOR_YOUTO_JINOUT
                        '(設定入出庫のとき)
                        strCV_MODE = "001"
                    Case XCONVEYOR_YOUTO_JDOWN
                        '(ﾀﾞｳﾝのとき)
                        strCV_MODE = "010"
                End Select

                strDENBUN &= strCV_MODE         '電文作成

            Next


            Select Case intII
                Case 1
                    strData01_02 = "0" & strDENBUN
                Case 2
                    strData02_02 = "0" & strDENBUN
                Case 3
                    strData03_02 = "0" & strDENBUN
                Case 4
                    strData04_02 = "0" & strDENBUN
                Case 5
                    strData05_02 = "0" & strDENBUN
                Case 6
                    strData06_02 = "0" & strDENBUN
                Case 7
                    strData07_02 = "0" & strDENBUN & "000"
            End Select

        Next


        '*****************************************************
        'ﾁｪｯｸ
        '*****************************************************
        If strData01_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ01(02進)が16桁じゃないのでｴﾗｰとします。")
        If strData02_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ02(02進)が16桁じゃないのでｴﾗｰとします。")
        If strData03_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ03(02進)が16桁じゃないのでｴﾗｰとします。")
        If strData04_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ04(02進)が16桁じゃないのでｴﾗｰとします。")
        If strData05_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ05(02進)が16桁じゃないのでｴﾗｰとします。")
        If strData06_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ06(02進)が16桁じゃないのでｴﾗｰとします。")
        If strData07_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ07(02進)が16桁じゃないのでｴﾗｰとします。")


        '*****************************************************
        '10進数に変換
        '*****************************************************
        strData01_10 = Change2To10(strData01_02)    'ﾃﾞｰﾀ01(10進数)
        strData02_10 = Change2To10(strData02_02)    'ﾃﾞｰﾀ02(10進数)
        strData03_10 = Change2To10(strData03_02)    'ﾃﾞｰﾀ03(10進数)
        strData04_10 = Change2To10(strData04_02)    'ﾃﾞｰﾀ01(10進数)
        strData05_10 = Change2To10(strData05_02)    'ﾃﾞｰﾀ02(10進数)
        strData06_10 = Change2To10(strData06_02)    'ﾃﾞｰﾀ03(10進数)
        strData07_10 = Change2To10(strData07_02)    'ﾃﾞｰﾀ03(10進数)

        Dim strXSEND_DATA As String = ""                    '送信ﾃﾞｰﾀ
        strXSEND_DATA = strData01_10 & "," & strData02_10 & "," & strData03_10 & "," & strData04_10 & _
                  "," & strData05_10 & "," & strData06_10 & "," & strData07_10                                  '送信ﾃﾞｰﾀ



        '************************************************
        'PLCﾒﾝﾃﾅﾝｽ
        '************************************************
        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
        Call objSVR_190001.SendYasukawaMelsec_IDMainteWord(FEQ_ID_JOTHY03_X048301, FTEXT_ID_JW_CV_YOUTO, strXSEND_DATA)


    End Function
#End Region
#Region "  ﾒｲﾝ処理12(ﾊﾞｰｽｸﾞﾙｰﾌﾟ更新)                                                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理12(ﾊﾞｰｽｸﾞﾙｰﾌﾟ更新)
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


        '************************
        '初期設定
        '************************
        Dim dtmNow As Date = Now


        '************************************
        '出荷ｺﾝﾍﾞﾔ状況          取得
        '************************************
        Dim objXSTS_CONVEYOR As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)
        objXSTS_CONVEYOR.XSTNO = TO_INTEGER(strDenbunDtl(XDSPSTNO))         'ｽﾃｰｼｮﾝNo(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№として使用)
        objXSTS_CONVEYOR.GET_XSTS_CONVEYOR()


        '************************************
        '出荷ｺﾝﾍﾞﾔ状況          更新
        '************************************
        objXSTS_CONVEYOR.XBERTH_GROUP = TO_INTEGER(strDenbunDtl(XDSPBERTH_GROUP))   'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
        objXSTS_CONVEYOR.FUPDATE_DT = dtmNow        '更新日時
        objXSTS_CONVEYOR.UPDATE_XSTS_CONVEYOR()     '更新


    End Function
#End Region
#Region "  ﾒｲﾝ処理                                                                          _old"
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


    '        '-------------------
    '        'ｽﾃｰｼｮﾝﾏｽﾀの特定
    '        '-------------------
    '        Dim objTMST_ST As New TBL_TMST_ST(Owner, ObjDb, ObjDbLog)           'ｽﾃｰｼｮﾝﾏｽﾀｸﾗｽ
    '        objTMST_ST.FTRK_BUF_NO = TO_INTEGER(strDenbunDtl(XDSPSTNO))         'ｽﾃｰｼｮﾝNo(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№として使用)
    '        intRet = objTMST_ST.GET_TMST_ST()                                   '特定
    '        If intRet = RetCode.NotFound Then
    '            '(見つからない場合)
    '            strMsg = ERRMSG_NOTFOUND_TMST_ST & "[STNo:" & objTMST_ST.FTRK_BUF_NO & "]"
    '            Throw New System.Exception(strMsg)
    '        End If


    '        ''-------------------
    '        ''設備状況の特定
    '        ''-------------------
    '        'Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     '設備状況ｸﾗｽ
    '        'objTSTS_EQ_CTRL.FEQ_ID = objTMST_ST.FEQ_ID                              '設備ID
    '        'intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                             '特定
    '        'If intRet = RetCode.NotFound Then
    '        '    '(見つからない場合)
    '        '    strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]"
    '        '    Throw New System.Exception(strMsg)
    '        'End If


    '        '-------------------
    '        '出庫中ﾁｪｯｸ
    '        '-------------------
    '        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
    '        objTPRG_TRK_BUF.FTR_TO = TO_INTEGER(strDenbunDtl(XDSPSTNO))             '搬送ToﾊﾞｯﾌｧNo
    '        If 0 < objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_COUNT() Then
    '            strMsg = ERRMSG_DISP_USE_ST & "[ｽﾃｰｼｮﾝNo:" & objTPRG_TRK_BUF.FTR_TO & "(出庫中)]"
    '            Throw New System.Exception(strMsg)
    '        End If


    '        '-------------------
    '        'ｽﾃｰｼｮﾝﾁｪｯｸ
    '        '-------------------
    '        Dim strSQL As String                    'SQL文
    '        objTPRG_TRK_BUF.CLEAR_PROPERTY()
    '        strSQL = ""
    '        strSQL &= vbCrLf & "SELECT"
    '        strSQL &= vbCrLf & "    * "
    '        strSQL &= vbCrLf & " FROM"
    '        strSQL &= vbCrLf & "    TPRG_TRK_BUF "
    '        strSQL &= vbCrLf & " WHERE"
    '        strSQL &= vbCrLf & "        FTRK_BUF_NO = " & TO_INTEGER(strDenbunDtl(XDSPSTNO))    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
    '        strSQL &= vbCrLf & "    AND FTR_TO <> " & FTRK_BUF_NO_J9000                         '搬送ToﾊﾞｯﾌｧNo
    '        strSQL &= vbCrLf & "    AND FRES_KIND = " & FRES_KIND_SZAIKO                        '在庫引当状態
    '        strSQL &= vbCrLf
    '        objTPRG_TRK_BUF.USER_SQL = strSQL
    '        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_USER()
    '        If intRet <> RetCode.NotFound Then
    '            '(出庫中の場合)
    '            strMsg = ERRMSG_DISP_USE_ST & "[ｽﾃｰｼｮﾝNo:" & objTPRG_TRK_BUF.FTR_TO & "(出庫中)]"
    '            Throw New System.Exception(strMsg)
    '        End If


    '        '-------------------
    '        '入庫中ﾁｪｯｸ
    '        '-------------------
    '        objTPRG_TRK_BUF.CLEAR_PROPERTY()
    '        objTPRG_TRK_BUF.FTRK_BUF_NO = TO_INTEGER(strDenbunDtl(XDSPSTNO))        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '        objTPRG_TRK_BUF.FTR_TO = FTRK_BUF_NO_J9000                              '搬送ToﾊﾞｯﾌｧNo
    '        If 0 < objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_COUNT() Then
    '            '(入庫中の場合)
    '            strMsg = ERRMSG_DISP_USE_ST & "[ｽﾃｰｼｮﾝNo:" & objTPRG_TRK_BUF.FTR_TO & "(入庫中)]"
    '            Throw New System.Exception(strMsg)
    '        End If


    '        '-------------------
    '        '出荷ｺﾝﾍﾞﾔ状況更新
    '        '-------------------
    '        Dim objXSTS_CONVEYER As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)       '出荷ｺﾝﾍﾞﾔ状況ｸﾗｽ
    '        objXSTS_CONVEYER.XSTNO = TO_INTEGER(strDenbunDtl(XDSPSTNO))                 'STNo
    '        intRet = objXSTS_CONVEYER.GET_XSTS_CONVEYOR()                               '特定
    '        If intRet = RetCode.NotFound Then
    '            '(見つからない場合)
    '            strMsg = ERRMSG_NOTFOUND_XSTS_CONVEYOR & "[STNo:" & objXSTS_CONVEYER.XSTNO & "]"
    '            Throw New System.Exception(strMsg)
    '        End If
    '        objXSTS_CONVEYER.XCONVEYOR_YOUTO = TO_INTEGER(strDenbunDtl(XDSPCONVEYOR_YOUTO))     'ｺﾝﾍﾞﾔ用途   
    '        objXSTS_CONVEYER.UPDATE_XSTS_CONVEYOR()                                             '更新


    '        '-------------------
    '        '通信電文の作成
    '        '-------------------
    '        Dim strData01_02 As String = ""     'ﾃﾞｰﾀ01(02進数)
    '        Dim strData02_02 As String = ""     'ﾃﾞｰﾀ02(02進数)
    '        Dim strData03_02 As String = ""     'ﾃﾞｰﾀ03(02進数)
    '        Dim strData04_02 As String = ""     'ﾃﾞｰﾀ04(02進数)
    '        Dim strData05_02 As String = ""     'ﾃﾞｰﾀ05(02進数)
    '        Dim strData06_02 As String = ""     'ﾃﾞｰﾀ06(02進数)
    '        Dim strData07_02 As String = ""     'ﾃﾞｰﾀ07(02進数)

    '        Dim strData01_10 As String = ""     'ﾃﾞｰﾀ01(10進数)
    '        Dim strData02_10 As String = ""     'ﾃﾞｰﾀ02(10進数)
    '        Dim strData03_10 As String = ""     'ﾃﾞｰﾀ03(10進数)
    '        Dim strData04_10 As String = ""     'ﾃﾞｰﾀ04(10進数)
    '        Dim strData05_10 As String = ""     'ﾃﾞｰﾀ05(10進数)
    '        Dim strData06_10 As String = ""     'ﾃﾞｰﾀ06(10進数)
    '        Dim strData07_10 As String = ""     'ﾃﾞｰﾀ07(10進数)


    '        For intII As Integer = 1 To 7
    '            '(7電文繰り返す)
    '            Dim strDENBUN As String = ""            '電文
    '            Dim objXSTS_CONVEYER_MAKE_ARY As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)       '出荷ｺﾝﾍﾞﾔ状況ｸﾗｽ
    '            objXSTS_CONVEYER_MAKE_ARY.XCONVEYOR_GROUP = intII
    '            objXSTS_CONVEYER_MAKE_ARY.ORDER_BY = " XCONVEYOR_ORDER "
    '            intRet = objXSTS_CONVEYER_MAKE_ARY.GET_XSTS_CONVEYOR_ANY()                           '特定
    '            For Each objXSTS_CONVEYER_MAKE As TBL_XSTS_CONVEYOR In objXSTS_CONVEYER_MAKE_ARY.ARYME
    '                '(ﾙｰﾌﾟ:取得件数分)

    '                '**********************************
    '                ' ｺﾝﾍﾞﾔ用途
    '                '**********************************
    '                Dim strCV_MODE As String = ""           'ｺﾝﾍﾞﾔ用途
    '                Select Case objXSTS_CONVEYER_MAKE.XCONVEYOR_YOUTO
    '                    Case XCONVEYOR_YOUTO_JPALLET, XCONVEYOR_YOUTO_JBARA
    '                        '(ﾊﾟﾚｯﾄ,ﾊﾞﾗのとき)
    '                        strCV_MODE = "100"
    '                    Case XCONVEYOR_YOUTO_JINOUT
    '                        '(設定入出庫のとき)
    '                        strCV_MODE = "001"
    '                    Case XCONVEYOR_YOUTO_JDOWN
    '                        '(ﾀﾞｳﾝのとき)
    '                        strCV_MODE = "010"
    '                End Select

    '                strDENBUN &= strCV_MODE         '電文作成

    '            Next


    '            Select Case intII
    '                Case 1
    '                    strData01_02 = "0" & strDENBUN
    '                Case 2
    '                    strData02_02 = "0" & strDENBUN
    '                Case 3
    '                    strData03_02 = "0" & strDENBUN
    '                Case 4
    '                    strData04_02 = "0" & strDENBUN
    '                Case 5
    '                    strData05_02 = "0" & strDENBUN
    '                Case 6
    '                    strData06_02 = "0" & strDENBUN
    '                Case 7
    '                    strData07_02 = "0" & strDENBUN & "000"
    '            End Select

    '        Next


    '        '*****************************************************
    '        'ﾁｪｯｸ
    '        '*****************************************************
    '        If strData01_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ01(02進)が16桁じゃないのでｴﾗｰとします。")
    '        If strData02_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ02(02進)が16桁じゃないのでｴﾗｰとします。")
    '        If strData03_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ03(02進)が16桁じゃないのでｴﾗｰとします。")
    '        If strData04_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ04(02進)が16桁じゃないのでｴﾗｰとします。")
    '        If strData05_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ05(02進)が16桁じゃないのでｴﾗｰとします。")
    '        If strData06_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ06(02進)が16桁じゃないのでｴﾗｰとします。")
    '        If strData07_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ07(02進)が16桁じゃないのでｴﾗｰとします。")


    '        '*****************************************************
    '        '10進数に変換
    '        '*****************************************************
    '        strData01_10 = Change2To10(strData01_02)    'ﾃﾞｰﾀ01(10進数)
    '        strData02_10 = Change2To10(strData02_02)    'ﾃﾞｰﾀ02(10進数)
    '        strData03_10 = Change2To10(strData03_02)    'ﾃﾞｰﾀ03(10進数)
    '        strData04_10 = Change2To10(strData04_02)    'ﾃﾞｰﾀ01(10進数)
    '        strData05_10 = Change2To10(strData05_02)    'ﾃﾞｰﾀ02(10進数)
    '        strData06_10 = Change2To10(strData06_02)    'ﾃﾞｰﾀ03(10進数)
    '        strData07_10 = Change2To10(strData07_02)    'ﾃﾞｰﾀ03(10進数)

    '        Dim strXSEND_DATA As String = ""                    '送信ﾃﾞｰﾀ
    '        strXSEND_DATA = strData01_10 & "," & strData02_10 & "," & strData03_10 & "," & strData04_10 & _
    '                  "," & strData05_10 & "," & strData06_10 & "," & strData07_10                                  '送信ﾃﾞｰﾀ



    '        '************************************************
    '        'PLCﾒﾝﾃﾅﾝｽ
    '        '************************************************
    '        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
    '        Call objSVR_190001.SendYasukawa_IDMainte(FEQ_ID_JOTHY03_X048301, FTEXT_ID_JW_CV_YOUTO, strXSEND_DATA)



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


            '************************************************
            '出荷ｺﾝﾍﾞﾔ状況(変更前)          取得
            '************************************************
            Dim objXSTS_CONVEYOR_Before As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)
            objXSTS_CONVEYOR_Before.XSTNO = strDenbunDtl(XDSPSTNO)      'STNo.
            objXSTS_CONVEYOR_Before.GET_XSTS_CONVEYOR()                 '取得


            '*********************************************************************
            'ﾄﾗｯｷﾝｸﾞ数ﾁｪｯｸ01(ｺﾝﾍﾞﾔ用途設定、ﾊﾞｰｽ割付ｺﾝﾍﾞﾔ設定で使用)
            '*********************************************************************
            Call CheckTrkBufCount01(objXSTS_CONVEYOR_Before.XBERTH_GROUP, strDenbunDtl(XDSPBERTH_GROUP))


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
