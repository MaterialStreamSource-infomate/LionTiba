'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】包材出庫設定受付(1F)
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_400205
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0             '端末ID
    Private Const DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2              '理由
    Private Const XDSPPROD_LINE As Integer = 3          '生産ﾗｲﾝ№
    Private Const DSPTRK_BUF_NO As Integer = 4          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private Const DSPEQ_ID As Integer = 5               '設備ID
    Private Const DSPHINMEI_CD As Integer = 6           '品名ｺｰﾄﾞ
    Private Const XDSPMAKER_CD As Integer = 7           'ﾒｰｶｺｰﾄﾞ
    Private Const XDSPSTART_DT As Integer = 8           '開始日時
    Private Const XDSPEND_DT As Integer = 9             '終了日時
    Private Const XDSPPLAN_NUM As Integer = 10          '計画数量
    Private Const XDSPRESULT_NUM As Integer = 11        '実績数量
    Private Const XDSPRESULT_NUM_SUM As Integer = 12    '実績数量(合計)
    Private Const XDSPPROGRESS As Integer = 13          '進捗状態
    Private Const DSPGRID_DISPLAYINDEX As Integer = 14  'ｸﾞﾘｯﾄﾞ列表示順序
    Private Const XDSPPALLET_OUT_NUM As Integer = 15    '出庫ﾊﾟﾚｯﾄ設定枚数

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


            '************************************************
            '包材出庫設定状態(1F)          更新
            '************************************************
            Dim objXSTS_WRAPPING_MATERIAL_1F As New TBL_XSTS_WRAPPING_MATERIAL_1F(Owner, ObjDb, ObjDbLog)
            objXSTS_WRAPPING_MATERIAL_1F.XPROD_LINE = strDenbunDtl(XDSPPROD_LINE)          '生産ﾗｲﾝ№
            intRet = objXSTS_WRAPPING_MATERIAL_1F.GET_XSTS_WRAPPING_MATERIAL_1F(True)
            If intRet = RetCode.OK Then
                '(見つかったとき)

                '======================================
                '包材出庫設定状態(1F)          更新
                '======================================
                objXSTS_WRAPPING_MATERIAL_1F.FTRK_BUF_NO = TO_INTEGER_NULLABLE(strDenbunDtl(DSPTRK_BUF_NO))                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objXSTS_WRAPPING_MATERIAL_1F.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                                           '品名ｺｰﾄﾞ
                objXSTS_WRAPPING_MATERIAL_1F.XMAKER_CD = strDenbunDtl(XDSPMAKER_CD)                                            'ﾒｰｶｺｰﾄﾞ
                objXSTS_WRAPPING_MATERIAL_1F.XSTART_DT = TO_DATE_NULLABLE(strDenbunDtl(XDSPSTART_DT))                          '開始日時
                objXSTS_WRAPPING_MATERIAL_1F.XEND_DT = TO_DATE_NULLABLE(strDenbunDtl(XDSPEND_DT))                              '終了日時
                objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM_SUM = TO_INTEGER(strDenbunDtl(XDSPRESULT_NUM_SUM))                    '実績数量(合計)
                objXSTS_WRAPPING_MATERIAL_1F.XPROGRESS = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPPROGRESS))                       '進捗状態
                objXSTS_WRAPPING_MATERIAL_1F.FGRID_DISPLAYINDEX = TO_INTEGER_NULLABLE(strDenbunDtl(DSPGRID_DISPLAYINDEX))      'ｸﾞﾘｯﾄﾞ列表示順序
                objXSTS_WRAPPING_MATERIAL_1F.XOUT_PALLET_NUM = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPPALLET_OUT_NUM))            '出庫パレット設定枚数
                objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM = 0
                objXSTS_WRAPPING_MATERIAL_1F.XPLAN_NUM = 0
                objXSTS_WRAPPING_MATERIAL_1F.FTR_RES_VOL = 0

                objXSTS_WRAPPING_MATERIAL_1F.UPDATE_XSTS_WRAPPING_MATERIAL_1F()                       '更新

            End If


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

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
