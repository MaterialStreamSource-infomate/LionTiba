'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】生産ﾗｲﾝﾓﾆﾀ運転設定
' 【作成】KSH
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_400901
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0             '端末ID
    Private Const DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2              '理由

    Private Const DSPDIR_KUBUN As Integer = 3           '処理区分
    Private Const XDSPDPL_PL_NO As Integer = 4          'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
    Private Const DSPHINMEI_CD As Integer = 5           '品名ｺｰﾄﾞ
    Private Const XDSPDPL_PL_PTN As Integer = 6         'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ

    Enum menmCheckCase
        UntenBtn_Click                  '運転
        TeisiBtn_Click                  '停止
        DataClear_Click                 'ﾃﾞｰﾀｸﾘｱ
        SeisanEND_Click                 '生産終了
        HinsyuBtn_Click                 '品種設定
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
        HaraiBtn_Click                  '払出停止
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************
    End Enum

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
            '処理分岐
            '************************
            Select Case TO_INTEGER(strDenbunDtl(DSPDIR_KUBUN))
                Case menmCheckCase.UntenBtn_Click       '運転
                    Call cmdUnten(strDenbunDtl)
                Case menmCheckCase.TeisiBtn_Click       '停止
                    Call cmdTeisi(strDenbunDtl)
                Case menmCheckCase.DataClear_Click      'ﾃﾞｰﾀｸﾘｱ
                    Call cmdDataClear(strDenbunDtl)
                Case menmCheckCase.SeisanEND_Click      '生産終了
                    Call cmdSeisanEND(strDenbunDtl)

                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
                Case menmCheckCase.HaraiBtn_Click       '払出停止
                    Call cmdSeisanEND(strDenbunDtl)
                    'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
                    '↑↑↑↑↑↑************************************************************************************************************

                Case menmCheckCase.HinsyuBtn_Click      '品種設定
                    Call cmdHinsyu(strDenbunDtl)
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

#Region "  運転                                                                                 "
    ''' <summary>
    ''' 運転
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <remarks></remarks>
    Private Sub cmdUnten(ByVal strDenbunDtl() As String)
        'Dim intRet As RetCode                 '戻り値
        Dim strMsg As String
        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ
        '************************************************
        Dim objXMST_DPL_PL As New TBL_XMST_DPL_PL(Owner, ObjDb, ObjDbLog)
        objXMST_DPL_PL.XDPL_PL_NO = TO_INTEGER(strDenbunDtl(XDSPDPL_PL_NO))
        objXMST_DPL_PL.GET_XMST_DPL_PL()

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況
        '************************************************
        Dim intSTS As Nullable(Of Integer)
        Dim objXSTS_DPL_PL As New TBL_XSTS_DPL_PL(Owner, ObjDb, ObjDbLog)
        objXSTS_DPL_PL.XDPL_PL_NO = objXMST_DPL_PL.XDPL_PL_NO
        objXSTS_DPL_PL.GET_XSTS_DPL_PL()
        If TO_INTEGER(objXSTS_DPL_PL.XDPL_PL_STS) <> XDPL_PL_STS_KANOU And _
           TO_INTEGER(objXSTS_DPL_PL.XDPL_PL_STS) <> XDPL_PL_STS_CHUDN Then
            strMsg = FRM_MSG_FRM302011_04
            Throw New UserException(strMsg)
        End If
        intSTS = objXSTS_DPL_PL.XDPL_PL_STS

        '************************
        'ﾊﾟﾀｰﾝ設定されているかをPLCのﾌﾗｸﾞ値でﾁｪｯｸ
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_PLPT
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        If TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS) <> FLAG_ON Then
            strMsg = "PLCﾊﾟﾀｰﾝ照合OFF。" & vbCrLf
            strMsg &= "品種設定を行ってください。" & vbCrLf
            strMsg &= "(" & objTSTS_EQ_CTRL.FEQ_ID_LOCAL & ")"
            Throw New UserException(strMsg)
        End If

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ
        '************************************************
        Dim objXMST_DPL_PL_PTN As New TBL_XMST_DPL_PL_PTN(Owner, ObjDb, ObjDbLog)
        objXMST_DPL_PL_PTN.XDPL_PL_NO = objXMST_DPL_PL.XDPL_PL_NO
        objXMST_DPL_PL_PTN.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)
        objXMST_DPL_PL_PTN.XDPL_PL_PTN = TO_INTEGER(strDenbunDtl(XDSPDPL_PL_PTN))
        objXMST_DPL_PL_PTN.GET_XMST_DPL_PL_PTN()

        '************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝをPLCの値と比較
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_HINM
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        If TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS) <> TO_INTEGER(objXMST_DPL_PL_PTN.XDPL_PL_PTN) Then
            strMsg = "PLCﾊﾟﾀｰﾝ不一致。" & vbCrLf
            strMsg &= "品種設定を行ってください。" & vbCrLf
            strMsg &= "設定値[" & objXMST_DPL_PL_PTN.XDPL_PL_PTN & "] PLC[" & objTSTS_EQ_CTRL.FEQ_STS & "]"
            Throw New UserException(strMsg)
        End If

        '************************
        '開始可能かをPLCのﾌﾗｸﾞ値でﾁｪｯｸ
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_REDY
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        If TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS) <> FLAG_ON Then
            strMsg = "起動可能ﾌﾗｸﾞOFF。" & vbCrLf
            strMsg &= "設備の起動準備を行ってください。" & vbCrLf
            strMsg &= "(" & objTSTS_EQ_CTRL.FEQ_ID_LOCAL & ")"
            Throw New UserException(strMsg)
        End If

        '************************
        '操業日の取得
        '************************
        Dim objXRST_SOUGYOU As New TBL_XRST_SOUGYOU(Owner, ObjDb, ObjDbLog)     '操業履歴ｸﾗｽ
        objXRST_SOUGYOU.GET_XRST_SOUGYOU_XRST_SOUGYOU_MAX()                     '特定

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況 ｽﾃｰﾀｽ更新
        '************************************************
        objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_START
        objXSTS_DPL_PL.FHINMEI_CD = objXMST_DPL_PL_PTN.FHINMEI_CD
        objXSTS_DPL_PL.XDPL_PL_PTN = objXMST_DPL_PL_PTN.XDPL_PL_PTN
        objXSTS_DPL_PL.XSTART_DT = Now
        objXSTS_DPL_PL.XEND_DT = DEFAULT_DATE
        objXSTS_DPL_PL.UPDATE_XSTS_DPL_PL()

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ実績 追加
        '************************************************
        If TO_INTEGER(intSTS) = XDPL_PL_STS_KANOU Then
            Dim objXRST_DPL_PL As New TBL_XRST_DPL_PL(Owner, ObjDb, ObjDbLog)
            objXRST_DPL_PL.XSOUGYOU_DT = objXRST_SOUGYOU.XSOUGYOU_DT        '操業日
            objXRST_DPL_PL.XDPL_PL_NO = objXMST_DPL_PL_PTN.XDPL_PL_NO       'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
            objXRST_DPL_PL.FHINMEI_CD = objXMST_DPL_PL_PTN.FHINMEI_CD       '品目ｺｰﾄﾞ
            objXRST_DPL_PL.XDPL_PL_PTN = objXMST_DPL_PL_PTN.XDPL_PL_PTN     'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
            objXRST_DPL_PL.XSTART_DT = Now                                  '開始日時
            objXRST_DPL_PL.XEND_DT = DEFAULT_DATE                           '終了日時
            objXRST_DPL_PL.XDPL_PL_CNT = DEFAULT_INTEGER                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数
            objXRST_DPL_PL.XDPL_PL_PLT = DEFAULT_INTEGER                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数
            objXRST_DPL_PL.XDPL_PL_HAS = DEFAULT_INTEGER                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ
            objXRST_DPL_PL.XDPL_PL_KADO_TIM = DEFAULT_INTEGER               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間
            objXRST_DPL_PL.XDPL_PL_TRBL_TIM = DEFAULT_INTEGER               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間
            objXRST_DPL_PL.XDPL_PL_TRBL_CNT = DEFAULT_INTEGER               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数
            objXRST_DPL_PL.ADD_XRST_DPL_PL()
        End If

        '************************************************
        'PLC 起動ﾌﾗｸﾞ(D5500[Bit00]～) ON
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STKD, FTEXT_ID_JW_ETC, FLAG_ON)

        '************************************************
        'PLC 運転終了ﾌﾗｸﾞ(D5500[Bit01]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STED, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC 積付ﾊﾟﾀｰﾝ設定(D5500[Bit02]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STPT, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit03]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STCL, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit04]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STKN, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit05]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STST, FTEXT_ID_JW_ETC, FLAG_OFF)

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
        '************************************************
        'PLC 払出停止ﾌﾗｸﾞ(D5500[Bit06]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STHR, FTEXT_ID_JW_ETC, FLAG_OFF)
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************

        '************************************************
        '状態変化処理(起動状態設定)
        '************************************************
        Call KidouStatusCheck(objXMST_DPL_PL)

    End Sub
#End Region
#Region "  停止                                                                                 "
    ''' <summary>
    ''' 停止
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <remarks></remarks>
    Private Sub cmdTeisi(ByVal strDenbunDtl() As String)
        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ
        '************************************************
        Dim objXMST_DPL_PL As New TBL_XMST_DPL_PL(Owner, ObjDb, ObjDbLog)
        objXMST_DPL_PL.XDPL_PL_NO = TO_INTEGER(strDenbunDtl(XDSPDPL_PL_NO))
        objXMST_DPL_PL.GET_XMST_DPL_PL()

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況 ｸﾘｱ
        '************************************************
        Dim objXSTS_DPL_PL As New TBL_XSTS_DPL_PL(Owner, ObjDb, ObjDbLog)
        objXSTS_DPL_PL.XDPL_PL_NO = objXMST_DPL_PL.XDPL_PL_NO
        objXSTS_DPL_PL.GET_XSTS_DPL_PL()
        Select Case TO_INTEGER(objXSTS_DPL_PL.XDPL_PL_STS)
            Case XDPL_PL_STS_TEISI      '終了
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_TEISI
            Case XDPL_PL_STS_KANOU      '起動可
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_KANOU
            Case XDPL_PL_STS_START      '起動中
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_START
            Case XDPL_PL_STS_KIDOU      '起動
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_CHUYK
            Case XDPL_PL_STS_YOKYU      '終了中
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_YOKYU
            Case XDPL_PL_STS_CLEAR      'ｸﾘｱ中
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_CLEAR
            Case XDPL_PL_STS_CLRED      'ｸﾘｱ完
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_CLRED
            Case XDPL_PL_STS_ERROR      '異常
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_CHUYK
            Case XDPL_PL_STS_CHUYK      '停止中
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_CHUYK
            Case XDPL_PL_STS_CHUDN      '停止
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_CHUDN
        End Select
        objXSTS_DPL_PL.UPDATE_XSTS_DPL_PL()

        '************************************************
        'PLC 起動ﾌﾗｸﾞ(D5500[Bit00]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STKD, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC 運転終了ﾌﾗｸﾞ(D5500[Bit01]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STED, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC 積付ﾊﾟﾀｰﾝ設定(D5500[Bit02]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STPT, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit03]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STCL, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit04]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STKN, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit05]～) ON
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STST, FTEXT_ID_JW_ETC, FLAG_ON)

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
        '************************************************
        'PLC 払出停止ﾌﾗｸﾞ(D5500[Bit06]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STHR, FTEXT_ID_JW_ETC, FLAG_OFF)
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************

        ' '' ''************************************************
        ' '' ''PLC 品種ｺｰﾄﾞ(D901～) ｸﾘｱ
        ' '' ''************************************************
        '' ''Call objSVR_190001.SendYasukawaMelsec_IDMainteWord(objXMST_DPL_PL.XDPL_PL_EQ_ID_HINM, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        '状態変化処理(起動状態設定)
        '************************************************
        Call KidouStatusCheck(objXMST_DPL_PL)
    End Sub
#End Region
#Region "  ﾃﾞｰﾀｸﾘｱ                                                                              "
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾘｱ
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <remarks></remarks>
    Private Sub cmdDataClear(ByVal strDenbunDtl() As String)
        '' '' '' ''Dim strMsg As String
        '' ''Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)

        ' '' ''************************************************
        ' '' ''ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ
        ' '' ''************************************************
        '' ''Dim objXMST_DPL_PL As New TBL_XMST_DPL_PL(Owner, ObjDb, ObjDbLog)
        '' ''objXMST_DPL_PL.XDPL_PL_NO = TO_INTEGER(strDenbunDtl(XDSPDPL_PL_NO))
        '' ''objXMST_DPL_PL.GET_XMST_DPL_PL()

        ' '' ''************************************************
        ' '' ''ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況
        ' '' ''************************************************
        '' ''Dim objXSTS_DPL_PL As New TBL_XSTS_DPL_PL(Owner, ObjDb, ObjDbLog)
        '' ''objXSTS_DPL_PL.XDPL_PL_NO = objXMST_DPL_PL.XDPL_PL_NO
        '' ''objXSTS_DPL_PL.GET_XSTS_DPL_PL()
        '' '' '' ''画面側で警告ﾒｯｾｰｼﾞを確認させるようにする
        '' '' '' ''If TO_INTEGER(objXSTS_DPL_PL.XDPL_PL_STS) <> XDPL_PL_STS_YOKYU And _
        '' '' '' ''   TO_INTEGER(objXSTS_DPL_PL.XDPL_PL_STS) <> XDPL_PL_STS_CLEAR Then
        '' '' '' ''    strMsg = FRM_MSG_FRM302011_01
        '' '' '' ''    Throw New UserException(strMsg)
        '' '' '' ''End If
        '' ''If TO_INTEGER(objXSTS_DPL_PL.XDPL_PL_STS) = XDPL_PL_STS_YOKYU Then
        '' ''    objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_CLEAR
        '' ''    objXSTS_DPL_PL.UPDATE_XSTS_DPL_PL()
        '' ''End If

        ' '' ''************************************************
        ' '' ''PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit03]～) ON
        ' '' ''************************************************
        '' ''Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STCL, FTEXT_ID_JW_ETC, FLAG_ON)
        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ
        '************************************************
        Dim objXMST_DPL_PL As New TBL_XMST_DPL_PL(Owner, ObjDb, ObjDbLog)
        objXMST_DPL_PL.XDPL_PL_NO = TO_INTEGER(strDenbunDtl(XDSPDPL_PL_NO))
        objXMST_DPL_PL.GET_XMST_DPL_PL()

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況
        '************************************************
        Dim objXSTS_DPL_PL As New TBL_XSTS_DPL_PL(Owner, ObjDb, ObjDbLog)
        objXSTS_DPL_PL.XDPL_PL_NO = objXMST_DPL_PL.XDPL_PL_NO
        objXSTS_DPL_PL.GET_XSTS_DPL_PL()

        '************************************************
        '運転停止時帳票用ﾃﾞｰﾀ更新
        '************************************************
        Call cmdShimeSyori(objXMST_DPL_PL, objXSTS_DPL_PL)

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況 ｸﾘｱ
        '************************************************
        objXSTS_DPL_PL.XDPL_PL_PTN = DEFAULT_INTEGER
        objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_TEISI
        objXSTS_DPL_PL.UPDATE_XSTS_DPL_PL()

        '************************************************
        'PLC 起動ﾌﾗｸﾞ(D5500[Bit00]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STKD, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC 運転終了ﾌﾗｸﾞ(D5500[Bit01]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STED, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC 積付ﾊﾟﾀｰﾝ設定(D5500[Bit02]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STPT, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit03]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STCL, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit04]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STKN, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit05]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STST, FTEXT_ID_JW_ETC, FLAG_OFF)

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
        '************************************************
        'PLC 払出停止ﾌﾗｸﾞ(D5500[Bit06]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STHR, FTEXT_ID_JW_ETC, FLAG_OFF)
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************

        '************************************************
        'PLC 品種ｺｰﾄﾞ(D901～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteWord(objXMST_DPL_PL.XDPL_PL_EQ_ID_HINM, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        '状態変化処理(起動状態設定)
        '************************************************
        Call KidouStatusCheck(objXMST_DPL_PL)
    End Sub
#End Region
#Region "  生産終了                                                                             "
    ''' <summary>
    ''' 生産終了
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <remarks></remarks>
    Private Sub cmdSeisanEND(ByVal strDenbunDtl() As String)
        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ
        '************************************************
        Dim objXMST_DPL_PL As New TBL_XMST_DPL_PL(Owner, ObjDb, ObjDbLog)
        objXMST_DPL_PL.XDPL_PL_NO = TO_INTEGER(strDenbunDtl(XDSPDPL_PL_NO))
        objXMST_DPL_PL.GET_XMST_DPL_PL()

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況 ｸﾘｱ
        '************************************************
        Dim objXSTS_DPL_PL As New TBL_XSTS_DPL_PL(Owner, ObjDb, ObjDbLog)
        objXSTS_DPL_PL.XDPL_PL_NO = objXMST_DPL_PL.XDPL_PL_NO
        objXSTS_DPL_PL.GET_XSTS_DPL_PL()
        Select Case TO_INTEGER(objXSTS_DPL_PL.XDPL_PL_STS)
            Case XDPL_PL_STS_TEISI      '終了
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_TEISI
                objXSTS_DPL_PL.XDPL_PL_PTN = DEFAULT_INTEGER
            Case XDPL_PL_STS_KANOU      '起動可
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_KANOU
            Case XDPL_PL_STS_START      '起動中
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_YOKYU
                objXSTS_DPL_PL.XDPL_PL_PTN = DEFAULT_INTEGER
                objXSTS_DPL_PL.XEND_DT = Now
            Case XDPL_PL_STS_KIDOU      '起動
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_YOKYU
                objXSTS_DPL_PL.XDPL_PL_PTN = DEFAULT_INTEGER
                objXSTS_DPL_PL.XEND_DT = Now
            Case XDPL_PL_STS_YOKYU      '終了中
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_YOKYU
                objXSTS_DPL_PL.XDPL_PL_PTN = DEFAULT_INTEGER
            Case XDPL_PL_STS_CLEAR      'ｸﾘｱ中
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_CLEAR
            Case XDPL_PL_STS_CLRED      'ｸﾘｱ完
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_CLRED
            Case XDPL_PL_STS_ERROR      '異常
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_YOKYU
                objXSTS_DPL_PL.XDPL_PL_PTN = DEFAULT_INTEGER
                objXSTS_DPL_PL.XEND_DT = Now
            Case XDPL_PL_STS_CHUYK      '停止中
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_YOKYU
                objXSTS_DPL_PL.XDPL_PL_PTN = DEFAULT_INTEGER
                objXSTS_DPL_PL.XEND_DT = Now
            Case XDPL_PL_STS_CHUDN      '停止
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_YOKYU
                objXSTS_DPL_PL.XDPL_PL_PTN = DEFAULT_INTEGER
                objXSTS_DPL_PL.XEND_DT = Now
        End Select
        objXSTS_DPL_PL.UPDATE_XSTS_DPL_PL()

        '************************************************
        '運転停止時帳票用ﾃﾞｰﾀ更新
        '************************************************
        Call cmdShimeSyori(objXMST_DPL_PL, objXSTS_DPL_PL)

        '************************************************
        'PLC 起動ﾌﾗｸﾞ(D5500[Bit00]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STKD, FTEXT_ID_JW_ETC, FLAG_OFF)

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
        If TO_INTEGER(strDenbunDtl(DSPDIR_KUBUN)) = menmCheckCase.HaraiBtn_Click Then
            '************************************************
            'PLC 払出停止ﾌﾗｸﾞ(D5500[Bit06]～) ON
            '************************************************
            Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STHR, FTEXT_ID_JW_ETC, FLAG_ON)
        Else
            'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
            '↑↑↑↑↑↑************************************************************************************************************

            '************************************************
            'PLC 運転終了ﾌﾗｸﾞ(D5500[Bit01]～) ON
            '************************************************
            Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STED, FTEXT_ID_JW_ETC, FLAG_ON)

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
        End If
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************

        '************************************************
        'PLC 積付ﾊﾟﾀｰﾝ設定(D5500[Bit02]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STPT, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit03]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STCL, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit04]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STKN, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit05]～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STST, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        'PLC 品種ｺｰﾄﾞ(D901～) ｸﾘｱ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteWord(objXMST_DPL_PL.XDPL_PL_EQ_ID_HINM, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        '状態変化処理(起動状態設定)
        '************************************************
        Call KidouStatusCheck(objXMST_DPL_PL)
    End Sub
#End Region
#Region "  品種設定                                                                             "
    ''' <summary>
    ''' 品種設定
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <remarks></remarks>
    Private Sub cmdHinsyu(ByVal strDenbunDtl() As String)
        Dim strMsg As String
        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ
        '************************************************
        Dim objXMST_DPL_PL As New TBL_XMST_DPL_PL(Owner, ObjDb, ObjDbLog)
        objXMST_DPL_PL.XDPL_PL_NO = TO_INTEGER(strDenbunDtl(XDSPDPL_PL_NO))
        objXMST_DPL_PL.GET_XMST_DPL_PL()

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況
        '************************************************
        Dim objXSTS_DPL_PL As New TBL_XSTS_DPL_PL(Owner, ObjDb, ObjDbLog)
        objXSTS_DPL_PL.XDPL_PL_NO = objXMST_DPL_PL.XDPL_PL_NO
        objXSTS_DPL_PL.GET_XSTS_DPL_PL()
        Select Case TO_INTEGER(objXSTS_DPL_PL.XDPL_PL_STS)
            Case XDPL_PL_STS_TEISI              '終了
                '************************************************
                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況更新(品種再設定時のｽﾃｰﾀｽ戻り対応)
                '************************************************
                objXSTS_DPL_PL.XDPL_PL_PTN = TO_INTEGER(strDenbunDtl(XDSPDPL_PL_PTN))
                objXSTS_DPL_PL.UPDATE_XSTS_DPL_PL()
            Case XDPL_PL_STS_KANOU              '起動可
                '************************************************
                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況更新(品種再設定時のｽﾃｰﾀｽ戻り対応)
                '************************************************
                objXSTS_DPL_PL.XDPL_PL_PTN = TO_INTEGER(strDenbunDtl(XDSPDPL_PL_PTN))
                objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_TEISI
                objXSTS_DPL_PL.UPDATE_XSTS_DPL_PL()
            Case XDPL_PL_STS_START              '起動中
                strMsg = FRM_MSG_FRM302011_01
                Throw New UserException(strMsg)
            Case XDPL_PL_STS_KIDOU              '起動
                strMsg = FRM_MSG_FRM302011_01
                Throw New UserException(strMsg)
            Case XDPL_PL_STS_YOKYU              '終了中
                strMsg = FRM_MSG_FRM302011_01
                Throw New UserException(strMsg)
            Case XDPL_PL_STS_CLEAR              'ｸﾘｱ中
                strMsg = FRM_MSG_FRM302011_01
                Throw New UserException(strMsg)
            Case XDPL_PL_STS_CLRED              'ｸﾘｱ完
                strMsg = FRM_MSG_FRM302011_01
                Throw New UserException(strMsg)
            Case XDPL_PL_STS_ERROR              '異常
                strMsg = FRM_MSG_FRM302011_01
                Throw New UserException(strMsg)
        End Select

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ
        '************************************************
        Dim objXMST_DPL_PL_PTN As New TBL_XMST_DPL_PL_PTN(Owner, ObjDb, ObjDbLog)
        objXMST_DPL_PL_PTN.XDPL_PL_NO = objXMST_DPL_PL.XDPL_PL_NO
        objXMST_DPL_PL_PTN.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)
        objXMST_DPL_PL_PTN.XDPL_PL_PTN = TO_INTEGER(strDenbunDtl(XDSPDPL_PL_PTN))
        objXMST_DPL_PL_PTN.GET_XMST_DPL_PL_PTN()

        '************************************************
        'PLC 品種ｺｰﾄﾞ(D901～) ｾｯﾄ
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteWord(objXMST_DPL_PL.XDPL_PL_EQ_ID_HINM, FTEXT_ID_JW_ETC, objXMST_DPL_PL_PTN.XDPL_PL_PTN)

        '************************************************
        'PLC 積付ﾊﾟﾀｰﾝ設定(D5500[Bit02]～) ON
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STPT, FTEXT_ID_JW_ETC, FLAG_ON)

        '************************************************
        '状態変化処理(起動状態設定)
        '************************************************
        Call KidouStatusCheck(objXMST_DPL_PL)
    End Sub
#End Region

#Region "  起動状態設定                                                                         "
    ''' <summary>
    ''' 起動状態設定
    ''' </summary>
    ''' <param name="objXMST_DPL_PL">ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ</param>
    ''' <remarks></remarks>
    Public Sub KidouStatusCheck(ByVal objXMST_DPL_PL As TBL_XMST_DPL_PL)
        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
        Dim intSTAT As Integer          '起動状態
        Dim intKIDO_5514_00 As Integer  '(D5514[Bit00]～)起動ANS            設備状態
        Dim intONLN_5514_01 As Integer  '(D5514[Bit01]～)ｵﾝﾗｲﾝANS           設備状態
        Dim intOFLN_5514_02 As Integer  '(D5514[Bit02]～)ｵﾌﾗｲﾝANS           設備状態
        Dim intPLPT_5514_05 As Integer  '(D5514[Bit05]～)積付ﾊﾟﾀｰﾝ設定一致  設備状態
        Dim intREDY_5514_06 As Integer  '(D5514[Bit06]～)起動可能           設備状態
        Dim intSYRY_5514_07 As Integer  '(D5514[Bit07]～)終了要求           設備状態
        Dim intSTAT_NEW As Integer  '起動状態(設定用)
        Dim intONLN_NEW As Integer  'ｵﾝﾗｲﾝ状態(設定用)

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況          起動状態取得
        '************************************************
        Dim objXSTS_DPL_PL As New TBL_XSTS_DPL_PL(Owner, ObjDb, ObjDbLog)
        objXSTS_DPL_PL.XDPL_PL_NO = objXMST_DPL_PL.XDPL_PL_NO
        objXSTS_DPL_PL.GET_XSTS_DPL_PL()
        intSTAT = TO_INTEGER(objXSTS_DPL_PL.XDPL_PL_STS)

        '************************
        '(D5514[Bit00]～)起動ANS            設備状態取得
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_KIDO
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intKIDO_5514_00 = TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)

        '************************
        '(D5514[Bit01]～)ｵﾝﾗｲﾝANS           設備状態取得
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_ONLN
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intONLN_5514_01 = TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)

        '************************
        '(D5514[Bit02]～)ｵﾌﾗｲﾝANS           設備状態取得
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_OFLN
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intOFLN_5514_02 = TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)

        '************************
        '(D5514[Bit05]～)積付ﾊﾟﾀｰﾝ設定一致  設備状態取得
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_PLPT
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intPLPT_5514_05 = TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)

        '************************
        '(D5514[Bit06]～)起動可能           設備状態取得
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_REDY
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intREDY_5514_06 = TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)

        '************************
        '(D5514[Bit07]～)終了要求           設備状態取得
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_SYRY
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intSYRY_5514_07 = TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)

        '************************
        '起動状態判定
        '************************
        intSTAT_NEW = intSTAT
        Select Case intSTAT
            Case XDPL_PL_STS_TEISI      '終了
                If intPLPT_5514_05 = FLAG_ON Then
                    '************************************************
                    '(D5500[Bit02]～)積付ﾊﾟﾀｰﾝ設定      ｸﾘｱ
                    '************************************************
                    Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STPT, FTEXT_ID_JW_ETC, FLAG_OFF)
                End If


                '************************************************
                '終了時に(D5514[Bit06]～)起動可能がONすると、起動可能にさせる
                '************************************************
                If intREDY_5514_06 = FLAG_ON Then
                    intSTAT_NEW = XDPL_PL_STS_KANOU

                End If


                '************************************************
                '終了時に(D5514[Bit00]～)起動ANSがONすると、起動にさせる
                '************************************************
                If intKIDO_5514_00 = FLAG_ON Then
                    intSTAT_NEW = XDPL_PL_STS_KIDOU
                End If


            Case XDPL_PL_STS_KANOU      '起動可
                '************************************************
                '起動可時に(D5514[Bit06]～)起動可能がOFFすると、停止にさせる
                '************************************************
                If intREDY_5514_06 = FLAG_OFF Then
                    intSTAT_NEW = XDPL_PL_STS_TEISI
                End If

                '************************************************
                '起動可時に(D5514[Bit00]～)起動ANSがONすると、起動にさせる
                '************************************************
                If intKIDO_5514_00 = FLAG_ON Then
                    intSTAT_NEW = XDPL_PL_STS_KIDOU
                End If


            Case XDPL_PL_STS_START      '起動中
                If intKIDO_5514_00 = FLAG_ON Then
                    intSTAT_NEW = XDPL_PL_STS_KIDOU

                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2015/07/30 運転操作時にｾｯﾄする様に変更 ↓↓↓↓↓↓
                    ' '' ''************************************************
                    ' '' ''ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況          開始時刻登録
                    ' '' ''************************************************
                    '' ''objXSTS_DPL_PL.XSTART_DT = Now
                    'JobMate:S.Ouchi 2015/07/30 運転操作時にｾｯﾄする様に変更 ↑↑↑↑↑↑
                    '↑↑↑↑↑↑************************************************************************************************************

                    '************************************************
                    '(D5500[Bit00]～)起動ﾌﾗｸﾞ           ｸﾘｱ
                    '************************************************
                    Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STKD, FTEXT_ID_JW_ETC, FLAG_OFF)

                End If


            Case XDPL_PL_STS_KIDOU      '起動
                '************************************************
                '起動時に(D5514[Bit00]～)起動ANSがOFFすると、停止にさせる
                '************************************************
                If intKIDO_5514_00 = FLAG_OFF Then
                    intSTAT_NEW = XDPL_PL_STS_CHUDN

                End If


            Case XDPL_PL_STS_YOKYU      '終了中
                If intSYRY_5514_07 = FLAG_ON Then
                    intSTAT_NEW = XDPL_PL_STS_CLEAR

                    '************************************************
                    '(D5500[Bit01]～)運転終了ﾌﾗｸﾞ       ｸﾘｱ
                    '************************************************
                    Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STED, FTEXT_ID_JW_ETC, FLAG_OFF)

                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
                    '************************************************
                    '(D5500[Bit06]～)払出停止ﾌﾗｸﾞ       ｸﾘｱ
                    '************************************************
                    Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STHR, FTEXT_ID_JW_ETC, FLAG_OFF)
                    'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
                    '↑↑↑↑↑↑************************************************************************************************************

                    '************************************************
                    '(D5500[Bit03]～)ﾃﾞｰﾀｸﾘｱ            ON
                    '************************************************
                    Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STCL, FTEXT_ID_JW_ETC, FLAG_ON)
                    Call ClearCheck(objXMST_DPL_PL)
                End If


            Case XDPL_PL_STS_CLEAR      'ｸﾘｱ中
                Call ClearCheck(objXMST_DPL_PL)


            Case XDPL_PL_STS_CLRED      'ｸﾘｱ完
                If intSYRY_5514_07 = FLAG_OFF Then
                    intSTAT_NEW = XDPL_PL_STS_TEISI

                    '************************************************
                    '(D5500[Bit04]～)ﾃﾞｰﾀｸﾘｱ完了        ｸﾘｱ
                    '************************************************
                    Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STKN, FTEXT_ID_JW_ETC, FLAG_OFF)
                End If


            Case XDPL_PL_STS_ERROR      '異常
                'NOP


            Case XDPL_PL_STS_CHUYK      '停止中
                'If intSYRY_5514_07 = FLAG_ON Then
                If intKIDO_5514_00 = FLAG_OFF Then
                    intSTAT_NEW = XDPL_PL_STS_CHUDN

                    '************************************************
                    '(D5500[Bit05]～)運転停止ﾌﾗｸﾞ       ｸﾘｱ
                    '************************************************
                    Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STST, FTEXT_ID_JW_ETC, FLAG_OFF)

                End If


            Case XDPL_PL_STS_CHUDN      '停止
                '************************************************
                '停止時に(D5514[Bit00]～)起動ANSがONすると、運転にさせる
                '************************************************
                If intKIDO_5514_00 = FLAG_ON Then
                    intSTAT_NEW = XDPL_PL_STS_KIDOU

                End If


        End Select

        '************************
        'ｵﾝﾗｲﾝ状態判定
        '************************
        If intONLN_5514_01 = FLAG_ON And intOFLN_5514_02 = FLAG_OFF Then
            intONLN_NEW = XDPL_PL_ONLINE_ON
        ElseIf intONLN_5514_01 = FLAG_OFF And intOFLN_5514_02 = FLAG_ON Then
            intONLN_NEW = XDPL_PL_ONLINE_OFF
        ElseIf intONLN_5514_01 = FLAG_OFF And intOFLN_5514_02 = FLAG_OFF Then
            intONLN_NEW = XDPL_PL_ONLINE_OFF
        Else
            intONLN_NEW = XDPL_PL_ONLINE_ERR
        End If

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況          更新
        '************************************************
        objXSTS_DPL_PL.XDPL_PL_ONLINE = intONLN_NEW
        objXSTS_DPL_PL.XDPL_PL_STS = intSTAT_NEW
        objXSTS_DPL_PL.UPDATE_XSTS_DPL_PL()

    End Sub
#End Region

#Region "  ｸﾘｱ判定                                                                              "
    ''' <summary>
    ''' ｸﾘｱ判定
    ''' </summary>
    ''' <param name="objXMST_DPL_PL">ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ</param>
    ''' <remarks></remarks>
    Public Sub ClearCheck(ByVal objXMST_DPL_PL As TBL_XMST_DPL_PL)
        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        Dim intEQ_STS As Integer
        Dim intSTAT As Integer          '起動状態

        '************************************************
        'ｸﾘｱ中かをPLCのﾌﾗｸﾞ値でﾁｪｯｸ
        '************************************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_STCL
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intEQ_STS = objTSTS_EQ_CTRL.FEQ_STS
        If intEQ_STS = FLAG_OFF Then Exit Sub

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況          起動状態取得
        '************************************************
        Dim objXSTS_DPL_PL As New TBL_XSTS_DPL_PL(Owner, ObjDb, ObjDbLog)
        objXSTS_DPL_PL.XDPL_PL_NO = objXMST_DPL_PL.XDPL_PL_NO
        objXSTS_DPL_PL.GET_XSTS_DPL_PL()
        intSTAT = TO_INTEGER(objXSTS_DPL_PL.XDPL_PL_STS)

        '************************************************
        '以下の値が全てｸﾘｱされているかの判定を行う
        '************************************************
        '************************
        '生産ﾊﾟﾚｯﾄ数
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_PL
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intEQ_STS = objTSTS_EQ_CTRL.FEQ_STS
        If intEQ_STS <> FLAG_OFF Then Exit Sub

        '************************
        '端数ﾃﾞｰﾀ
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_HASU
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intEQ_STS = objTSTS_EQ_CTRL.FEQ_STS
        If intEQ_STS <> FLAG_OFF Then Exit Sub

        '************************
        'ﾄﾗﾌﾞﾙ時間(時)
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_TRBL_HH
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intEQ_STS = objTSTS_EQ_CTRL.FEQ_STS
        If intEQ_STS <> FLAG_OFF Then Exit Sub

        '************************
        'ﾄﾗﾌﾞﾙ時間(分)
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_TRBL_MM
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intEQ_STS = objTSTS_EQ_CTRL.FEQ_STS
        If intEQ_STS <> FLAG_OFF Then Exit Sub

        '************************
        'ﾄﾗﾌﾞﾙ時間(秒)
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_TRBL_SS
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intEQ_STS = objTSTS_EQ_CTRL.FEQ_STS
        If intEQ_STS <> FLAG_OFF Then Exit Sub

        '************************
        'ﾄﾗﾌﾞﾙ件数
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_TRBL
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intEQ_STS = objTSTS_EQ_CTRL.FEQ_STS
        If intEQ_STS <> FLAG_OFF Then Exit Sub

        '************************
        '積付数
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_COUNT
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intEQ_STS = objTSTS_EQ_CTRL.FEQ_STS
        If intEQ_STS <> FLAG_OFF Then Exit Sub

        '************************
        '運転時間(時)
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_KADOU_HH
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intEQ_STS = objTSTS_EQ_CTRL.FEQ_STS
        If intEQ_STS <> FLAG_OFF Then Exit Sub

        '************************
        '運転時間(分)
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_KADOU_MM
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intEQ_STS = objTSTS_EQ_CTRL.FEQ_STS
        If intEQ_STS <> FLAG_OFF Then Exit Sub

        '************************
        '運転時間(秒)
        '************************
        objTSTS_EQ_CTRL.CLEAR_PROPERTY()
        objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_KADOU_SS
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
        intEQ_STS = objTSTS_EQ_CTRL.FEQ_STS
        If intEQ_STS <> FLAG_OFF Then Exit Sub

        '************************************************
        '全てｸﾘｱされている場合、ｸﾘｱ完了を送信する
        '************************************************
        '************************************************
        'PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit03]～) ｸﾘｱ
        '************************************************
        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STCL, FTEXT_ID_JW_ETC, FLAG_OFF)

        '************************************************
        '(D5500[Bit04]～)ﾃﾞｰﾀｸﾘｱ完了        ON
        '************************************************
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STKN, FTEXT_ID_JW_ETC, FLAG_ON)

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況          更新
        '************************************************
        If intSTAT = XDPL_PL_STS_CLEAR Then
            objXSTS_DPL_PL.XDPL_PL_STS = XDPL_PL_STS_CLRED
            objXSTS_DPL_PL.UPDATE_XSTS_DPL_PL()
        End If
    End Sub
#End Region

#Region "  運転停止時帳票用ﾃﾞｰﾀ更新                                                             "
    ''' <summary>
    ''' 運転停止時帳票用ﾃﾞｰﾀ更新
    ''' </summary>
    ''' <param name="objXMST_DPL_PL">ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ</param>
    ''' <param name="objXSTS_DPL_PL">ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況</param>
    ''' <remarks></remarks>
    Public Sub cmdShimeSyori(ByVal objXMST_DPL_PL As TBL_XMST_DPL_PL, ByVal objXSTS_DPL_PL As TBL_XSTS_DPL_PL)
        Dim intRet As RetCode

        '************************
        '操業日の取得
        '************************
        Dim objXRST_SOUGYOU As New TBL_XRST_SOUGYOU(Owner, ObjDb, ObjDbLog)     '操業履歴ｸﾗｽ
        objXRST_SOUGYOU.GET_XRST_SOUGYOU_XRST_SOUGYOU_MAX()                     '特定

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ実績 追加
        '************************************************
        Dim objXRST_DPL_PL As New TBL_XRST_DPL_PL(Owner, ObjDb, ObjDbLog)
        'objXRST_DPL_PL.XSOUGYOU_DT = objXRST_SOUGYOU.XSOUGYOU_DT                '操業日
        objXRST_DPL_PL.XDPL_PL_NO = objXSTS_DPL_PL.XDPL_PL_NO                   'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        objXRST_DPL_PL.FHINMEI_CD = objXSTS_DPL_PL.FHINMEI_CD                   '品目ｺｰﾄﾞ
        objXRST_DPL_PL.XDPL_PL_PTN = objXSTS_DPL_PL.XDPL_PL_PTN                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
        intRet = objXRST_DPL_PL.GET_XRST_DPL_PL_NotEnd(False)
        If intRet = RetCode.OK Then
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            '************************
            '積付数 取得
            '************************
            Dim intCNT As Integer
            objTSTS_EQ_CTRL.CLEAR_PROPERTY()
            objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_COUNT
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            intCNT = TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)

            '************************
            '生産ﾊﾟﾚｯﾄ数 取得
            '************************
            Dim intPLT As Integer
            objTSTS_EQ_CTRL.CLEAR_PROPERTY()
            objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_PL
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            intPLT = TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)

            '************************
            '生産ﾊﾟﾚｯﾄ数 取得
            '************************
            Dim intHAS As Integer
            objTSTS_EQ_CTRL.CLEAR_PROPERTY()
            objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_HASU
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            intHAS = TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)

            '************************
            '運転時間 取得
            '************************
            Dim intKADO_TIM As Integer
            Dim intKADO_TIM_HH As Integer
            Dim intKADO_TIM_MM As Integer
            objTSTS_EQ_CTRL.CLEAR_PROPERTY()
            objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_KADOU_HH
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            intKADO_TIM_HH = TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)
            objTSTS_EQ_CTRL.CLEAR_PROPERTY()
            objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_KADOU_MM
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            intKADO_TIM_MM = TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)
            intKADO_TIM = (intKADO_TIM_HH * 60) + intKADO_TIM_MM

            '************************
            '運転時間 取得
            '************************
            Dim intTRBL_TIM As Integer
            Dim intTRBL_TIM_HH As Integer
            Dim intTRBL_TIM_MM As Integer
            objTSTS_EQ_CTRL.CLEAR_PROPERTY()
            objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_TRBL_HH
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            intTRBL_TIM_HH = TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)
            objTSTS_EQ_CTRL.CLEAR_PROPERTY()
            objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_TRBL_MM
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            intTRBL_TIM_MM = TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)
            intTRBL_TIM = (intTRBL_TIM_HH * 60) + intTRBL_TIM_MM

            '************************
            '生産ﾊﾟﾚｯﾄ数 取得
            '************************
            Dim intTRBL_CNT As Integer
            objTSTS_EQ_CTRL.CLEAR_PROPERTY()
            objTSTS_EQ_CTRL.FEQ_ID = objXMST_DPL_PL.XDPL_PL_EQ_ID_TRBL
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            intTRBL_CNT = TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)

            objXRST_DPL_PL.XEND_DT = Now                                    '終了日時
            objXRST_DPL_PL.XDPL_PL_CNT = intCNT                             'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数
            objXRST_DPL_PL.XDPL_PL_PLT = intPLT                             'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数
            objXRST_DPL_PL.XDPL_PL_HAS = intHAS                             'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ
            objXRST_DPL_PL.XDPL_PL_KADO_TIM = intKADO_TIM                   'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間
            objXRST_DPL_PL.XDPL_PL_TRBL_TIM = intTRBL_TIM                   'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間
            objXRST_DPL_PL.XDPL_PL_TRBL_CNT = intTRBL_CNT                   'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数
            objXRST_DPL_PL.UPDATE_XRST_DPL_PL()
        End If
    End Sub
#End Region

#Region "  定時締め処理時の生産ﾗｲﾝ運転関連処理                                                  "
    ''''''' <summary>
    ''''''' 定時締め処理時の生産ﾗｲﾝ運転関連処理
    ''''''' </summary>
    ''''''' <remarks></remarks>
    '' ''Public Sub cmdShimeSyori_ALL()
    '' ''    Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
    '' ''    Dim intRet As RetCode

    '' ''    '************************************************
    '' ''    '以下は、運転状態のみｸﾘｱ送信↓↓↓↓↓
    '' ''    '************************************************
    '' ''    '' ''Dim objXSTS_DPL_PL_BASE As New TBL_XSTS_DPL_PL(Owner, ObjDb, ObjDbLog)
    '' ''    ' '' ''************************************************
    '' ''    ' '' ''ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況
    '' ''    ' '' ''************************************************
    '' ''    '' ''Dim objXSTS_DPL_PL_BASE As New TBL_XSTS_DPL_PL(Owner, ObjDb, ObjDbLog)
    '' ''    '' ''objXSTS_DPL_PL_BASE.XDPL_PL_STS = XDPL_PL_STS_KIDOU
    '' ''    '' ''intRet = objXSTS_DPL_PL_BASE.GET_XSTS_DPL_PL_ANY
    '' ''    '' ''If intRet = RetCode.OK Then
    '' ''    '' ''    For Each objXSTS_DPL_PL As TBL_XSTS_DPL_PL In objXSTS_DPL_PL_BASE.ARYME
    '' ''    '' ''        '************************************************
    '' ''    '' ''        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ
    '' ''    '' ''        '************************************************
    '' ''    '' ''        Dim objXMST_DPL_PL As New TBL_XMST_DPL_PL(Owner, ObjDb, ObjDbLog)
    '' ''    '' ''        objXMST_DPL_PL.XDPL_PL_NO = objXSTS_DPL_PL.XDPL_PL_NO
    '' ''    '' ''        objXMST_DPL_PL.GET_XMST_DPL_PL()

    '' ''    '' ''        '************************************************
    '' ''    '' ''        '運転停止時帳票用ﾃﾞｰﾀ更新
    '' ''    '' ''        '************************************************
    '' ''    '' ''        Call cmdShimeSyori(objXMST_DPL_PL, objXSTS_DPL_PL)

    '' ''    '' ''        '************************************************
    '' ''    '' ''        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ実績 追加
    '' ''    '' ''        '************************************************
    '' ''    '' ''        Dim objXRST_DPL_PL As New TBL_XRST_DPL_PL(Owner, ObjDb, ObjDbLog)
    '' ''    '' ''        objXRST_DPL_PL.XSOUGYOU_DT = Format(Now, "YYYY/MM/DD")          '操業日
    '' ''    '' ''        objXRST_DPL_PL.XDPL_PL_NO = objXSTS_DPL_PL.XDPL_PL_NO           'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
    '' ''    '' ''        objXRST_DPL_PL.FHINMEI_CD = objXSTS_DPL_PL.FHINMEI_CD           '品目ｺｰﾄﾞ
    '' ''    '' ''        objXRST_DPL_PL.XDPL_PL_PTN = objXSTS_DPL_PL.XDPL_PL_PTN         'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
    '' ''    '' ''        objXRST_DPL_PL.XSTART_DT = Now                                  '開始日時
    '' ''    '' ''        objXRST_DPL_PL.XEND_DT = DEFAULT_DATE                           '終了日時
    '' ''    '' ''        objXRST_DPL_PL.XDPL_PL_CNT = DEFAULT_INTEGER                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数
    '' ''    '' ''        objXRST_DPL_PL.XDPL_PL_PLT = DEFAULT_INTEGER                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数
    '' ''    '' ''        objXRST_DPL_PL.XDPL_PL_HAS = DEFAULT_INTEGER                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ
    '' ''    '' ''        objXRST_DPL_PL.XDPL_PL_KADO_TIM = DEFAULT_INTEGER               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間
    '' ''    '' ''        objXRST_DPL_PL.XDPL_PL_TRBL_TIM = DEFAULT_INTEGER               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間
    '' ''    '' ''        objXRST_DPL_PL.XDPL_PL_TRBL_CNT = DEFAULT_INTEGER               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数
    '' ''    '' ''        objXRST_DPL_PL.ADD_XRST_DPL_PL()

    '' ''    '' ''        '************************************************
    '' ''    '' ''        'PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit03]～) ON
    '' ''    '' ''        '************************************************
    '' ''    '' ''        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STCL, FTEXT_ID_JW_ETC, FLAG_ON)
    '' ''    '' ''    Next
    '' ''    '' ''End If
    '' ''    '************************************************
    '' ''    'ここまで、運転状態のみｸﾘｱ送信↑↑↑↑↑
    '' ''    '************************************************


    '' ''    '************************************************
    '' ''    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ
    '' ''    '************************************************
    '' ''    Dim objXMST_DPL_PL_BASE As New TBL_XMST_DPL_PL(Owner, ObjDb, ObjDbLog)
    '' ''    objXMST_DPL_PL_BASE.GET_XMST_DPL_PL_ANY()
    '' ''    intRet = objXMST_DPL_PL_BASE.GET_XMST_DPL_PL_ANY
    '' ''    If intRet = RetCode.OK Then
    '' ''        For Each objXMST_DPL_PL As TBL_XMST_DPL_PL In objXMST_DPL_PL_BASE.ARYME
    '' ''            '************************************************
    '' ''            'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況
    '' ''            '************************************************
    '' ''            Dim objXSTS_DPL_PL As New TBL_XSTS_DPL_PL(Owner, ObjDb, ObjDbLog)
    '' ''            objXSTS_DPL_PL.XDPL_PL_NO = objXMST_DPL_PL.XDPL_PL_NO
    '' ''            objXSTS_DPL_PL.GET_XSTS_DPL_PL()

    '' ''            If TO_INTEGER(objXSTS_DPL_PL.XDPL_PL_STS) = XDPL_PL_STS_KIDOU Then
    '' ''                '************************************************
    '' ''                '運転停止時帳票用ﾃﾞｰﾀ更新
    '' ''                '************************************************
    '' ''                Call cmdShimeSyori(objXMST_DPL_PL, objXSTS_DPL_PL)

    '' ''                '************************************************
    '' ''                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ実績 追加
    '' ''                '************************************************
    '' ''                Dim objXRST_DPL_PL As New TBL_XRST_DPL_PL(Owner, ObjDb, ObjDbLog)
    '' ''                objXRST_DPL_PL.XSOUGYOU_DT = Format(Now, "YYYY/MM/DD")          '操業日
    '' ''                objXRST_DPL_PL.XDPL_PL_NO = objXSTS_DPL_PL.XDPL_PL_NO           'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
    '' ''                objXRST_DPL_PL.FHINMEI_CD = objXSTS_DPL_PL.FHINMEI_CD           '品目ｺｰﾄﾞ
    '' ''                objXRST_DPL_PL.XDPL_PL_PTN = objXSTS_DPL_PL.XDPL_PL_PTN         'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
    '' ''                objXRST_DPL_PL.XSTART_DT = Now                                  '開始日時
    '' ''                objXRST_DPL_PL.XEND_DT = DEFAULT_DATE                           '終了日時
    '' ''                objXRST_DPL_PL.XDPL_PL_CNT = DEFAULT_INTEGER                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数
    '' ''                objXRST_DPL_PL.XDPL_PL_PLT = DEFAULT_INTEGER                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数
    '' ''                objXRST_DPL_PL.XDPL_PL_HAS = DEFAULT_INTEGER                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ
    '' ''                objXRST_DPL_PL.XDPL_PL_KADO_TIM = DEFAULT_INTEGER               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間
    '' ''                objXRST_DPL_PL.XDPL_PL_TRBL_TIM = DEFAULT_INTEGER               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間
    '' ''                objXRST_DPL_PL.XDPL_PL_TRBL_CNT = DEFAULT_INTEGER               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数
    '' ''                objXRST_DPL_PL.ADD_XRST_DPL_PL()
    '' ''            End If

    '' ''            '************************************************
    '' ''            'PLC ﾃﾞｰﾀｸﾘｱ(D5500[Bit03]～) ON
    '' ''            '************************************************
    '' ''            Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(objXMST_DPL_PL.XDPL_PL_EQ_ID_STCL, FTEXT_ID_JW_ETC, FLAG_ON)
    '' ''        Next
    '' ''    End If
    '' ''End Sub
#End Region

End Class
