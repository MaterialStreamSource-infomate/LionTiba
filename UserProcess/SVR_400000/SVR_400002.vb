'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】生産入庫設定受付
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_400002
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0             '端末ID
    Private Const DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2              '理由
    Private Const DSPTRK_BUF_NO As Integer = 3          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private Const DSPEQ_ID As Integer = 4               '設備ID
    Private Const XDSPPROD_LINE As Integer = 5          '生産ﾗｲﾝ№
    Private Const DSPHINMEI_CD As Integer = 6           '品名ｺｰﾄﾞ
    Private Const XDSPSTART_DT As Integer = 7           '開始日時
    Private Const XDSPEND_DT As Integer = 8             '終了日時
    Private Const XDSPPROGRESS As Integer = 9           '進捗状態
    Private Const DSPGRID_DISPLAYINDEX As Integer = 10  'ｸﾞﾘｯﾄﾞ列表示順序
    Private Const DSPARRIVE_DT As Integer = 11          '在庫発生日時
    Private Const DSPIN_KUBUN As Integer = 12           '入庫区分
    Private Const DSPHORYU_KUBUN As Integer = 13        '保留区分
    Private Const XDSPKENSA_KUBUN As Integer = 14       '検査区分
    Private Const XDSPKENPIN_KUBUN As Integer = 15      '検品区分
    Private Const XDSPMAKER_CD As Integer = 16          'ﾒｰｶ-ｺｰﾄﾞ
    Private Const XDSPKINKYU_BUF_TO As Integer = 17     '緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private Const XDSPRESULT_NUM As Integer = 18        '実績数量
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
    Private Const XDSPRESULT_NUM_CASE As Integer = 19   '実績数量(梱数)
    'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
    '↑↑↑↑↑↑************************************************************************************************************

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
            '生産入庫設定状態          更新
            '************************************************
            Dim objXSTS_PRODUCT_IN As New TBL_XSTS_PRODUCT_IN(Owner, ObjDb, ObjDbLog)
            objXSTS_PRODUCT_IN.FTRK_BUF_NO = strDenbunDtl(DSPTRK_BUF_NO)        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            intRet = objXSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN(True)
            If intRet = RetCode.OK Then
                '(見つかったとき)

                objXSTS_PRODUCT_IN.FEQ_ID = strDenbunDtl(DSPEQ_ID)                                              '設備ID
                objXSTS_PRODUCT_IN.XPROD_LINE = strDenbunDtl(XDSPPROD_LINE)                                     '生産ﾗｲﾝ№
                objXSTS_PRODUCT_IN.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                                      '品名ｺｰﾄﾞ
                objXSTS_PRODUCT_IN.XSTART_DT = TO_DATE_NULLABLE(strDenbunDtl(XDSPSTART_DT))                     '開始日時
                objXSTS_PRODUCT_IN.XEND_DT = TO_DATE_NULLABLE(strDenbunDtl(XDSPEND_DT))                         '終了日時
                objXSTS_PRODUCT_IN.XPROGRESS = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPPROGRESS))                  '進捗状態
                objXSTS_PRODUCT_IN.FGRID_DISPLAYINDEX = TO_INTEGER_NULLABLE(strDenbunDtl(DSPGRID_DISPLAYINDEX)) 'ｸﾞﾘｯﾄﾞ列表示順序
                objXSTS_PRODUCT_IN.FARRIVE_DT = TO_DATE_NULLABLE(strDenbunDtl(DSPARRIVE_DT))                    '在庫発生日時
                objXSTS_PRODUCT_IN.FIN_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPIN_KUBUN))                   '入庫区分
                objXSTS_PRODUCT_IN.FHORYU_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPHORYU_KUBUN))             '保留区分
                objXSTS_PRODUCT_IN.XKENSA_KUBUN = TO_STRING_NULLABLE(strDenbunDtl(XDSPKENSA_KUBUN))             '検査区分
                objXSTS_PRODUCT_IN.XKENPIN_KUBUN = TO_STRING_NULLABLE(strDenbunDtl(XDSPKENPIN_KUBUN))           '検品区分
                objXSTS_PRODUCT_IN.XMAKER_CD = strDenbunDtl(XDSPMAKER_CD)                                       'ﾒｰｶ-ｺｰﾄﾞ
                objXSTS_PRODUCT_IN.XKINKYU_BUF_TO = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPKINKYU_BUF_TO))        '緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objXSTS_PRODUCT_IN.XRESULT_NUM = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPRESULT_NUM))              '実績数量
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
                objXSTS_PRODUCT_IN.XRESULT_NUM_CASE = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPRESULT_NUM_CASE))    '実績数量(梱数)
                'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
                '↑↑↑↑↑↑************************************************************************************************************
                objXSTS_PRODUCT_IN.UPDATE_XSTS_PRODUCT_IN()                                                     '更新

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
