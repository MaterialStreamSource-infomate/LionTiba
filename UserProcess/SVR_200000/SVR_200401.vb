'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】在庫ﾒﾝﾃﾅﾝｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_200401
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0         '端末ID
    Private Const DSPUSER_ID As Integer = 1         'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2          '理由
    Private Const DSPDIR_KUBUN As Integer = 3       '処理区分
    Private Const DSPTRK_BUF_NO As Integer = 4      'ﾊﾞｯﾌｧ№
    Private Const DSPTRK_BUF_ARRAY As Integer = 5   'ﾊﾞｯﾌｧ配列№
    Private Const DSPREMOVE_KIND As Integer = 6     '禁止棚設定
    Private Const DSPRAC_FORM As Integer = 7        '棚形状種別
    Private Const DSPRES_KIND As Integer = 8        '引当状態
    Private Const DSPHINMEI_CD As Integer = 9       '品名ｺｰﾄﾞ
    Private Const DSPLOT_NO As Integer = 10         'ﾛｯﾄ№
    Private Const DSPARRIVE_DT As Integer = 11      '在庫発生日時
    Private Const DSPIN_KUBUN As Integer = 12       '入庫区分
    Private Const DSPSEIHIN_KUBUN As Integer = 13   '製品区分
    Private Const DSPZAIKO_KUBUN As Integer = 14    '在庫区分
    Private Const DSPHORYU_KUBUN As Integer = 15    '保留区分
    Private Const DSPST_FM As Integer = 16          '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private Const DSPTR_VOL As Integer = 17         '搬送管理量
    Private Const DSPTR_RES_VOL As Integer = 18     '搬送引当量
    Private Const DSPPALLET_ID As Integer = 19      'ﾊﾟﾚｯﾄID
    Private Const DSPLOT_NO_STOCK As Integer = 20   '在庫ﾛｯﾄ№
    Private Const DSPLABEL_ID As Integer = 21       'ﾗﾍﾞﾙID
    Private Const DSPHASU_FLAG As Integer = 22      '端数ﾌﾗｸﾞ
    Private Const DSPSYUKKA_TO_CD As Integer = 23   '出荷先ｺｰﾄﾞ
    Private Const DSPSYUKKA_TO_NAME As Integer = 24 '出荷先名称
    Private Const DSPRAC_BUNRUI As Integer = 25     '棚分類
    Private Const DSPBUF_IN_DT As Integer = 26      'ﾊﾞｯﾌｧ入日時
    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
    Private Const XDSPTANA_BLOCK As Integer = 27            '棚ﾌﾞﾛｯｸ
    Private Const XDSPTANA_BLOCK_DTL As Integer = 28        '棚ﾌﾞﾛｯｸ詳細
    Private Const XDSPTANA_BLOCK_STS As Integer = 29        '棚ﾌﾞﾛｯｸ状態
    Private Const XDSPPROD_LINE As Integer = 30             '生産ﾗｲﾝ№
    Private Const XDSPKENSA_KUBUN As Integer = 31           '検査区分
    Private Const XDSPKENPIN_KUBUN As Integer = 32          '検品区分
    Private Const XDSPMAKER_CD As Integer = 33              'ﾒｰｶｺｰﾄﾞ
    Private Const XDSPRAC_IN_DT As Integer = 34             '入庫日時
    '**********************************************************************************************
    '↓↓↓2013/07/14 H.Okumura 在庫移行で使用
    Private Const DSPUPDATE_DT As Integer = 35              '更新日時
    '↑↑↑
    '**********************************************************************************************


    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

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
        Dim strDenbunDtl(0) As String          '電文分解配列
        Dim strDenbunDtlName(0) As String      '電文分解名称配列
        Dim strDenbunInfo As String = ""        '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        'Dim intRet As Integer                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try

            '************************
            '初期処理
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call CheckBeforeAct(strDenbunDtl)


            '************************
            '在庫ﾒﾝﾃﾅﾝｽ
            '************************
            Select Case strDenbunDtl(DSPDIR_KUBUN)     '処理区分
                Case FORMAT_DSP_DSPDIR_KUBUN_INSERT
                    '(追加)
                    Call MenteStockADD(strDenbunDtl)


                Case FORMAT_DSP_DSPDIR_KUBUN_UPDATE _
                   , FORMAT_DSP_DSPDIR_KUBUN_INSERT_STOCK _
                   , FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK _
                   , FORMAT_DSP_DSPDIR_KUBUN_DELETE_STOCK
                    '(更新)
                    Call MenteStockUPDATE(strDenbunDtl)


                Case FORMAT_DSP_DSPDIR_KUBUN_DELETE
                    '(削除)
                    Call MenteStockDELETE(strDenbunDtl)

            End Select


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


            Select Case strDenbunDtl(DSPDIR_KUBUN)     '処理区分
                Case FORMAT_DSP_DSPDIR_KUBUN_INSERT
                    '(追加の場合)


                Case FORMAT_DSP_DSPDIR_KUBUN_UPDATE
                    '(変更の場合)


                Case FORMAT_DSP_DSPDIR_KUBUN_DELETE
                    '(削除の場合)


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
    ''' <param name="strDenbunDtl">電文内容構造体</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MenteStockADD(ByVal strDenbunDtl() As String)
        Try
            Dim intRet As Integer                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            Dim dtmNow As Date = Now                '現在日時


            '************************
            'ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)         'ﾄﾗｯｷﾝｸﾞﾏｽﾀｸﾗｽ
            objTMST_TRK.FTRK_BUF_NO = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_NO))    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            intRet = objTMST_TRK.GET_TMST_TRK(True)                             '特定


            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF.FTRK_BUF_NO = objTMST_TRK.FTRK_BUF_NO                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            If TO_INTEGER(objTMST_TRK.FBUF_KIND) = FBUF_KIND_SASRS Then
                '(倉庫の場合)
                objTPRG_TRK_BUF.FTRK_BUF_ARRAY = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_ARRAY))      'ﾄﾗｯｷﾝｸﾞ配列No
                intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)                                 '特定
                If TO_INTEGER(objTPRG_TRK_BUF.FRES_KIND) <> FRES_KIND_SAKI And TO_INTEGER(objTPRG_TRK_BUF.FRES_KIND) <> FRES_KIND_SZAIKO Then
                    '(空棚、在庫棚以外の場合)
                    strMsg = ERRMSG_DISP_TRK & "[ﾊﾞｯﾌｧNo:" & TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO) & "  ,配列No:" & TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY) & "  ,在庫引当状態:" & TO_STRING(objTPRG_TRK_BUF.FRES_KIND) & "]"
                    Throw New System.Exception(strMsg)
                End If
            Else
                '(平置き系の場合)
                intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_AKI_HIRA() '特定
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧNo:" & TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO) & "]"
                    Throw New System.Exception(strMsg)
                End If
            End If


            '**************************************
            'ﾛｸﾞ用ｵﾌﾞｼﾞｪｸﾄ作成
            '**************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            Dim objTPRG_TRK_BUF_Before As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF_Before.FTRK_BUF_NO = objTPRG_TRK_BUF.FTRK_BUF_NO            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            objTPRG_TRK_BUF_Before.FTRK_BUF_ARRAY = objTPRG_TRK_BUF.FTRK_BUF_ARRAY      'ﾄﾗｯｷﾝｸﾞ配列No
            intRet = objTPRG_TRK_BUF_Before.GET_TPRG_TRK_BUF(False)                     '特定


            '************************
            '在庫情報の登録
            '************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)                     '在庫情報ｸﾗｽ
            If strDenbunDtl(DSPPALLET_ID) <> DEFAULT_STRING Then
                objTRST_STOCK.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)                           'ﾊﾟﾚｯﾄID
            End If
            objTRST_STOCK.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                               '品名ｺｰﾄﾞ
            objTRST_STOCK.FLOT_NO = strDenbunDtl(DSPLOT_NO)                                     'ﾛｯﾄ№
            objTRST_STOCK.FARRIVE_DT = TO_DATE_NULLABLE(strDenbunDtl(DSPARRIVE_DT))             '在庫発生日時
            objTRST_STOCK.FIN_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPIN_KUBUN))            '入庫区分
            objTRST_STOCK.FSEIHIN_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPSEIHIN_KUBUN))    '製品区分
            objTRST_STOCK.FZAIKO_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPZAIKO_KUBUN))      '在庫区分
            objTRST_STOCK.FHORYU_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPHORYU_KUBUN))      '保留区分
            objTRST_STOCK.FST_FM = TO_INTEGER_NULLABLE(strDenbunDtl(DSPST_FM))                  '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTRST_STOCK.FTR_VOL = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPTR_VOL))                '搬送管理量
            objTRST_STOCK.FTR_RES_VOL = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPTR_RES_VOL))        '搬送引当量
            '**********************************************************************************************
            '↓↓↓2013/07/14 H.Okumura 在庫移行で使用
            If strDenbunDtl(DSPUPDATE_DT) <> "" Then                                            '更新日時
                objTRST_STOCK.FUPDATE_DT = strDenbunDtl(DSPUPDATE_DT)
            Else
                objTRST_STOCK.FUPDATE_DT = dtmNow
            End If
            '↑↑↑
            '**********************************************************************************************
            objTRST_STOCK.FLABEL_ID = strDenbunDtl(DSPLABEL_ID)                                 'ﾗﾍﾞﾙID
            objTRST_STOCK.FHASU_FLAG = TO_INTEGER_NULLABLE(strDenbunDtl(DSPHASU_FLAG))          '端数ﾌﾗｸﾞ
            objTRST_STOCK.FSYUKKA_TO_CD = strDenbunDtl(DSPSYUKKA_TO_CD)                         '出荷先ｺｰﾄﾞ
            objTRST_STOCK.FSYUKKA_TO_NAME = strDenbunDtl(DSPSYUKKA_TO_NAME)                     '出荷先名称
            '**********************************************************************************************
            '↓↓↓ｼｽﾃﾑ固有
            objTRST_STOCK.XPROD_LINE = strDenbunDtl(XDSPPROD_LINE)                           '生産ﾗｲﾝ№
            objTRST_STOCK.XKENSA_KUBUN = strDenbunDtl(XDSPKENSA_KUBUN)                       '検査区分
            objTRST_STOCK.XKENPIN_KUBUN = strDenbunDtl(XDSPKENPIN_KUBUN)                     '検品区分
            objTRST_STOCK.XMAKER_CD = strDenbunDtl(XDSPMAKER_CD)                             'ﾒｰｶｺｰﾄﾞ
            objTRST_STOCK.XRAC_IN_DT = TO_DATE(strDenbunDtl(XDSPRAC_IN_DT))                  '入庫日時
            '↑↑↑ｼｽﾃﾑ固有
            '**********************************************************************************************
            '**********************************************************************************************
            '↓↓↓2013/08/01 H.Okumura 入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧを追加
            If TO_INTEGER(objTMST_TRK.FBUF_KIND) = FBUF_KIND_SASRS Then
                '(倉庫の場合)
                objTRST_STOCK.XTRK_BUF_NO_IN = strDenbunDtl(DSPTRK_BUF_NO)
                objTRST_STOCK.XTRK_BUF_ARRAY_IN = strDenbunDtl(DSPTRK_BUF_ARRAY)
            End If
            '↑↑↑
            '**********************************************************************************************


            objTRST_STOCK.ADD_TRST_STOCK_ALL()                                                  '登録


            '************************
            '作業種別を取得
            '************************
            Dim intFSAGYO_KIND = FSAGYOU_KIND_SSYSTEM_MENTE_NON


            '************************
            '在庫登録
            '************************
            Dim objSVR_100101 As New SVR_100101(Owner, ObjDb, ObjDbLog) '在庫登録ｸﾗｽ
            objSVR_100101.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            objSVR_100101.FPALLET_ID = objTRST_STOCK.FPALLET_ID         'ﾊﾟﾚｯﾄID
            objSVR_100101.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK   '在庫ﾛｯﾄ№
            objSVR_100101.FINOUT_STS = FINOUT_STS_SMENTE_ADD            'INOUT(ﾒﾝﾃﾅﾝｽ登録)
            objSVR_100101.FSAGYOU_KIND = intFSAGYO_KIND                 '作業種別
            objSVR_100101.STOCK_ADD()                                   '登録


            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの更新
            '************************
            If TO_INTEGER(objTMST_TRK.FBUF_KIND) = FBUF_KIND_SASRS Then
                '(倉庫の場合)
                objTPRG_TRK_BUF.FREMOVE_KIND = TO_NUMBER(strDenbunDtl(DSPREMOVE_KIND))  '禁止棚設定
                objTPRG_TRK_BUF.FRAC_FORM = TO_NUMBER(strDenbunDtl(DSPRAC_FORM))        '棚形状種別
                objTPRG_TRK_BUF.FRAC_BUNRUI = strDenbunDtl(DSPRAC_BUNRUI)               '棚分類
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:A.Noto 2013/03/26 JOB固有項目追加
                'objTPRG_TRK_BUF.FBUF_IN_DT = dtmNow                                                        'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF.FBUF_IN_DT = TO_DATE_NULLABLE(strDenbunDtl(DSPBUF_IN_DT))                   'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF.XTANA_BLOCK = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTANA_BLOCK))             '棚ﾌﾞﾛｯｸ
                objTPRG_TRK_BUF.XTANA_BLOCK_DTL = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTANA_BLOCK_DTL))     '棚ﾌﾞﾛｯｸ詳細
                objTPRG_TRK_BUF.XTANA_BLOCK_STS = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTANA_BLOCK_STS))     '棚ﾌﾞﾛｯｸ状態
                '↑↑↑↑↑↑************************************************************************************************************
                objTPRG_TRK_BUF.UPDATE_TPRG_TRK_BUF()                                   '更新

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:H.Okumura 2013/07/17 棚ﾌﾞﾛｯｸ単位で更新(未使用棚を除く)
                Dim strXTANA_BLOCK As String
                strXTANA_BLOCK = objTPRG_TRK_BUF.XTANA_BLOCK        '棚ﾌﾞﾛｯｸ

                Dim strSQL As String
                Dim intRetSQL As Integer    'SQL実行戻り値

                strSQL = ""
                strSQL &= vbCrLf & "UPDATE"
                strSQL &= vbCrLf & "      TPRG_TRK_BUF "
                strSQL &= vbCrLf & " SET "
                strSQL &= vbCrLf & "      FREMOVE_KIND = " & TO_NUMBER(strDenbunDtl(DSPREMOVE_KIND)) & " "
                strSQL &= vbCrLf & " WHERE"
                strSQL &= vbCrLf & "      XTANA_BLOCK = " & strXTANA_BLOCK & " "
                strSQL &= vbCrLf & "  AND FTRK_BUF_NO = " & objTPRG_TRK_BUF.FTRK_BUF_NO & " "
                If TO_NUMBER(strDenbunDtl(DSPREMOVE_KIND)) <> FREMOVE_KIND_SNON Then
                    strSQL &= vbCrLf & "  AND FREMOVE_KIND <> " & FREMOVE_KIND_SNON & " "               '未使用棚を除く
                End If
                strSQL &= vbCrLf
                intRetSQL = ObjDb.Execute(strSQL)
                If intRetSQL = -1 Then
                    '(SQLｴﾗｰ)
                    strSQL = Replace(strSQL, vbCrLf, "")
                    strMsg = ERRMSG_ERR_UPDATE & ObjDb.ErrMsg & "【" & strSQL & "】"
                    Throw New UserException(strMsg)
                End If
                If intRetSQL < 1 Then
                    strMsg = "ERRMSG_NOTFOUND_TPRG_TRK_BUF" & "[ﾊﾞｯﾌｧ№:" & objTPRG_TRK_BUF.FTRK_BUF_NO & "  ,棚ﾌﾞﾛｯｸ:" & strXTANA_BLOCK & "]"
                    Throw New UserException(strMsg)
                End If
                '↑↑↑↑↑↑************************************************************************************************************


            End If

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:A.Noto 2013/03/26 変更履歴未使用
            ''**************************************
            ''ﾛｸﾞ用ｵﾌﾞｼﾞｪｸﾄ作成
            ''**************************************
            ''在庫情報
            'Dim objTRST_STOCK_After As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            'objTRST_STOCK_After.FPALLET_ID = objTRST_STOCK.FPALLET_ID         'ﾊﾟﾚｯﾄID
            'objTRST_STOCK_After.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK   '在庫ﾛｯﾄ№
            'intRet = objTRST_STOCK_After.GET_TRST_STOCK_ALL()                 '特定
            'If intRet = RetCode.NotFound Then
            '    '(見つからない場合)
            '    strMsg = ERRMSG_NOTFOUND_TRST_STOCK & "[ﾊﾟﾚｯﾄID:" & objTRST_STOCK_After.FPALLET_ID & "][在庫ﾛｯﾄ№" & objTRST_STOCK_After.FLOT_NO_STOCK & "]"
            '    Throw New UserException(strMsg)
            'End If

            ''ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            'Dim objTPRG_TRK_BUF_After As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            'objTPRG_TRK_BUF_After.FTRK_BUF_NO = objTPRG_TRK_BUF.FTRK_BUF_NO                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            'objTPRG_TRK_BUF_After.FTRK_BUF_ARRAY = objTPRG_TRK_BUF.FTRK_BUF_ARRAY           'ﾄﾗｯｷﾝｸﾞ配列No
            'intRet = objTPRG_TRK_BUF_After.GET_TPRG_TRK_BUF(True)                           '特定


            ''**************************************
            ''変更履歴詳細追加
            ''**************************************
            'Call Add_TEVD_TBLCHANGE_DTL_TRST_STOCK(strDenbunDtl _
            '                                     , MeSyoriID _
            '                                     , objTPRG_TRK_BUF_Before _
            '                                     , Nothing _
            '                                     , objTPRG_TRK_BUF_After _
            '                                     , objTRST_STOCK_After _
            '                                     )


            ''************************
            ''在庫更新履歴の登録
            ''************************
            'Call ADD_STOCK_LOG(strDenbunDtl, objTRST_STOCK_After)
            '↑↑↑↑↑↑************************************************************************************************************

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
    ''' <param name="strDenbunDtl">電文内容構造体</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MenteStockUPDATE(ByVal strDenbunDtl() As String)
        Try
            Dim intRet As Integer                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '**************************************
            'ﾛｸﾞ用ｵﾌﾞｼﾞｪｸﾄ作成
            '**************************************
            '在庫情報
            Dim objTRST_STOCK_Before As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            If IsNull(strDenbunDtl(DSPPALLET_ID)) = False And IsNull(strDenbunDtl(DSPLOT_NO_STOCK)) = False Then
                '(ﾊﾟﾚｯﾄIDが入っていた場合)
                objTRST_STOCK_Before.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)       'ﾊﾟﾚｯﾄID
                objTRST_STOCK_Before.FLOT_NO_STOCK = strDenbunDtl(DSPLOT_NO_STOCK) '在庫ﾛｯﾄ№
                intRet = objTRST_STOCK_Before.GET_TRST_STOCK_ALL()                 '特定
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_TRST_STOCK & "[ﾊﾟﾚｯﾄID:" & objTRST_STOCK_Before.FPALLET_ID & "][在庫ﾛｯﾄ№" & objTRST_STOCK_Before.FLOT_NO_STOCK & "]"
                    Throw New UserException(strMsg)
                End If
            End If

            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            Dim objTPRG_TRK_BUF_Before As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF_Before.FTRK_BUF_NO = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_NO))         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            objTPRG_TRK_BUF_Before.FTRK_BUF_ARRAY = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_ARRAY))   'ﾄﾗｯｷﾝｸﾞ配列No
            intRet = objTPRG_TRK_BUF_Before.GET_TPRG_TRK_BUF(False)                             '特定


            '************************
            'ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)         'ﾄﾗｯｷﾝｸﾞﾏｽﾀｸﾗｽ
            objTMST_TRK.FTRK_BUF_NO = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_NO))    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            intRet = objTMST_TRK.GET_TMST_TRK(True)                             '特定


            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF.FTRK_BUF_NO = objTMST_TRK.FTRK_BUF_NO                           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            objTPRG_TRK_BUF.FTRK_BUF_ARRAY = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_ARRAY))      'ﾄﾗｯｷﾝｸﾞ配列No
            intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)                                 '特定
            If Not (TO_INTEGER(objTPRG_TRK_BUF.FRES_KIND) = FRES_KIND_SAKI Or _
                   TO_INTEGER(objTPRG_TRK_BUF.FRES_KIND) = FRES_KIND_SZAIKO) Then
                '(引当状態が空か在庫以外の場合)
                strMsg = ERRMSG_DISP_TRK & "[ﾊﾞｯﾌｧNo:" & TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO) & "  ,配列No:" & TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY) & "  ,在庫引当状態:" & TO_STRING(objTPRG_TRK_BUF.FRES_KIND) & "]"
                Throw New System.Exception(strMsg)
            End If


            '************************
            '作業種別を取得
            '************************
            Dim intFSAGYO_KIND = FSAGYOU_KIND_SSYSTEM_MENTE_NON


            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)            '在庫情報ｸﾗｽ
            If TO_INTEGER(strDenbunDtl(DSPDIR_KUBUN)) = FORMAT_DSP_DSPDIR_KUBUN_UPDATE Then
                '(在庫も更新の場合)


                '**********************************************************************************
                '個装更新の場合
                '**********************************************************************************
                '=====================
                '在庫情報の特定
                '=====================
                objTRST_STOCK.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)                      'ﾊﾟﾚｯﾄID
                objTRST_STOCK.FLOT_NO_STOCK = strDenbunDtl(DSPLOT_NO_STOCK)                '在庫ﾛｯﾄ№
                intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)                         '特定

                '=====================
                '在庫情報1の更新
                '=====================
                objTRST_STOCK.ARYME(0).FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                             '品名ｺｰﾄﾞ
                objTRST_STOCK.ARYME(0).FLOT_NO = strDenbunDtl(DSPLOT_NO)                                   'ﾛｯﾄ№
                objTRST_STOCK.ARYME(0).FARRIVE_DT = TO_DATE_NULLABLE(strDenbunDtl(DSPARRIVE_DT))           '在庫発生日時
                objTRST_STOCK.ARYME(0).FIN_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPIN_KUBUN))          '入庫区分
                objTRST_STOCK.ARYME(0).FSEIHIN_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPSEIHIN_KUBUN))  '製品区分
                objTRST_STOCK.ARYME(0).FZAIKO_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPZAIKO_KUBUN))    '在庫区分
                objTRST_STOCK.ARYME(0).FHORYU_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPHORYU_KUBUN))    '保留区分
                objTRST_STOCK.ARYME(0).FST_FM = TO_INTEGER_NULLABLE(strDenbunDtl(DSPST_FM))                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTRST_STOCK.ARYME(0).FTR_VOL = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPTR_VOL))              '搬送管理量
                objTRST_STOCK.ARYME(0).FTR_RES_VOL = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPTR_RES_VOL))      '搬送引当量
                objTRST_STOCK.ARYME(0).FUPDATE_DT = Now                                                    '更新日時
                objTRST_STOCK.ARYME(0).FLABEL_ID = strDenbunDtl(DSPLABEL_ID)                               'ﾗﾍﾞﾙID
                objTRST_STOCK.ARYME(0).FHASU_FLAG = TO_INTEGER_NULLABLE(strDenbunDtl(DSPHASU_FLAG))        '端数ﾌﾗｸﾞ
                objTRST_STOCK.ARYME(0).FSYUKKA_TO_CD = strDenbunDtl(DSPSYUKKA_TO_CD)                       '出荷先ｺｰﾄﾞ
                objTRST_STOCK.ARYME(0).FSYUKKA_TO_NAME = strDenbunDtl(DSPSYUKKA_TO_NAME)                   '出荷先名称
                '**********************************************************************************************
                '↓↓↓ｼｽﾃﾑ固有
                objTRST_STOCK.ARYME(0).XPROD_LINE = strDenbunDtl(XDSPPROD_LINE)                             '生産ﾗｲﾝ№
                objTRST_STOCK.ARYME(0).XKENSA_KUBUN = strDenbunDtl(XDSPKENSA_KUBUN)                         '検査区分
                objTRST_STOCK.ARYME(0).XKENPIN_KUBUN = strDenbunDtl(XDSPKENPIN_KUBUN)                       '検品区分
                objTRST_STOCK.ARYME(0).XMAKER_CD = strDenbunDtl(XDSPMAKER_CD)                               'ﾒｰｶｺｰﾄﾞ
                objTRST_STOCK.ARYME(0).XRAC_IN_DT = TO_DATE(strDenbunDtl(XDSPRAC_IN_DT))                    '入庫日時
                '↑↑↑ｼｽﾃﾑ固有
                '**********************************************************************************************
                objTRST_STOCK.ARYME(0).UPDATE_TRST_STOCK_ALL()                                               '更新


                '=====================
                '在庫更新
                '=====================
                Dim objSVR_100104 As New SVR_100104(Owner, ObjDb, ObjDbLog)     '在庫更新ｸﾗｽ
                objSVR_100104.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｵﾌﾞｼﾞｪｸﾄ
                objSVR_100104.OBJTRST_STOCK = objTRST_STOCK                     '在庫情報ｵﾌﾞｼﾞｪｸﾄ
                objSVR_100104.FINOUT_STS = FINOUT_STS_SMENTE_UPDATE              'IN/OUT
                objSVR_100104.FSAGYOU_KIND = intFSAGYO_KIND                     '作業種別
                objSVR_100104.STOCK_UPDATE()                                    '更新


            ElseIf TO_INTEGER(strDenbunDtl(DSPDIR_KUBUN)) = FORMAT_DSP_DSPDIR_KUBUN_INSERT_STOCK Then
                '(個装追加の場合)


                '**********************************************************************************
                '個装追加の場合
                '**********************************************************************************
                '=====================
                '在庫情報の登録
                '=====================
                objTRST_STOCK.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)                               'ﾊﾟﾚｯﾄID
                objTRST_STOCK.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                               '品名ｺｰﾄﾞ
                objTRST_STOCK.FLOT_NO = strDenbunDtl(DSPLOT_NO)                                     'ﾛｯﾄ№
                objTRST_STOCK.FARRIVE_DT = TO_DATE_NULLABLE(strDenbunDtl(DSPARRIVE_DT))             '在庫発生日時
                objTRST_STOCK.FIN_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPIN_KUBUN))            '入庫区分
                objTRST_STOCK.FSEIHIN_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPSEIHIN_KUBUN))    '製品区分
                objTRST_STOCK.FZAIKO_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPZAIKO_KUBUN))      '在庫区分
                objTRST_STOCK.FHORYU_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPHORYU_KUBUN))      '保留区分
                objTRST_STOCK.FST_FM = TO_INTEGER_NULLABLE(strDenbunDtl(DSPST_FM))                  '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTRST_STOCK.FTR_VOL = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPTR_VOL))                '搬送管理量
                objTRST_STOCK.FTR_RES_VOL = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPTR_RES_VOL))        '搬送引当量
                objTRST_STOCK.FUPDATE_DT = Now                                                      '更新日時
                objTRST_STOCK.FLABEL_ID = strDenbunDtl(DSPLABEL_ID)                                 'ﾗﾍﾞﾙID
                objTRST_STOCK.FHASU_FLAG = TO_INTEGER_NULLABLE(strDenbunDtl(DSPHASU_FLAG))          '端数ﾌﾗｸﾞ
                objTRST_STOCK.FSYUKKA_TO_CD = strDenbunDtl(DSPSYUKKA_TO_CD)                         '出荷先ｺｰﾄﾞ
                objTRST_STOCK.FSYUKKA_TO_NAME = strDenbunDtl(DSPSYUKKA_TO_NAME)                     '出荷先名称
                '**********************************************************************************************
                '↓↓↓ｼｽﾃﾑ固有
                objTRST_STOCK.XPROD_LINE = strDenbunDtl(XDSPPROD_LINE)                              '生産ﾗｲﾝ№
                objTRST_STOCK.XKENSA_KUBUN = strDenbunDtl(XDSPKENSA_KUBUN)                          '検査区分
                objTRST_STOCK.XKENPIN_KUBUN = strDenbunDtl(XDSPKENPIN_KUBUN)                        '検品区分
                objTRST_STOCK.XMAKER_CD = strDenbunDtl(XDSPMAKER_CD)                                'ﾒｰｶｺｰﾄﾞ
                objTRST_STOCK.XRAC_IN_DT = TO_DATE(strDenbunDtl(XDSPRAC_IN_DT))                     '入庫日時
                '↑↑↑ｼｽﾃﾑ固有
                '**********************************************************************************************
                objTRST_STOCK.ADD_TRST_STOCK_ALL()                                                  '登録


                '=====================
                '在庫登録
                '=====================
                Dim objSVR_100101 As New SVR_100101(Owner, ObjDb, ObjDbLog) '在庫登録ｸﾗｽ
                objSVR_100101.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                objSVR_100101.FPALLET_ID = objTRST_STOCK.FPALLET_ID         'ﾊﾟﾚｯﾄID
                objSVR_100101.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK   '在庫ﾛｯﾄ№
                objSVR_100101.FINOUT_STS = FINOUT_STS_SMENTE_KOSOU_ADD       'INOUT
                objSVR_100101.FSAGYOU_KIND = intFSAGYO_KIND                 '作業種別
                objSVR_100101.STOCK_ADD()                                   '登録


            ElseIf TO_INTEGER(strDenbunDtl(DSPDIR_KUBUN)) = FORMAT_DSP_DSPDIR_KUBUN_DELETE_STOCK Then
                '(個装削除の場合)


                '**********************************************************************************
                '個装削除の場合
                '**********************************************************************************
                '=====================
                '在庫削除
                '=====================
                Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '在庫削除ｸﾗｽ
                objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                objSVR_100102.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)       'ﾊﾟﾚｯﾄID
                objSVR_100102.FLOT_NO_STOCK = strDenbunDtl(DSPLOT_NO_STOCK) '在庫ﾛｯﾄ№
                objSVR_100102.FINOUT_STS = FINOUT_STS_SMENTE_KOSOU_DELETE    'INOUT
                objSVR_100102.FSAGYOU_KIND = intFSAGYO_KIND                 '作業種別
                objSVR_100102.STOCK_DELETE()                                '削除


                '===========================================================
                '在庫情報の特定
                '最後の個装は「更新」としては削除出来ないのでｴﾗｰとする
                '===========================================================
                objTRST_STOCK.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)                      'ﾊﾟﾚｯﾄID
                intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)                         '特定


            ElseIf TO_INTEGER(strDenbunDtl(DSPDIR_KUBUN)) = FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK Then
                '(個装共通情報更新の場合)


                '**********************************************************************************
                '個装共通情報更新の場合
                '**********************************************************************************

                '=====================
                '在庫情報の特定
                '=====================
                If IsNotNull(strDenbunDtl(DSPPALLET_ID)) Then
                    '(在庫情報も更新する場合)

                    objTRST_STOCK.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)                      'ﾊﾟﾚｯﾄID
                    intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(False)                        '特定
                    If intRet = RetCode.OK Then
                        '(見つかった場合)

                        '↓↓↓↓↓↓************************************************************************************************************
                        'Checked JobMate:K.Shimizu 2011/09/12 共通で変更する個装情報はない

                        ''=====================
                        ''在庫情報の更新
                        ''=====================
                        'For ii As Integer = LBound(objTRST_STOCK.ARYME) To UBound(objTRST_STOCK.ARYME)
                        '    '(ﾙｰﾌﾟ:個装数)

                        '    objTRST_STOCK.ARYME(ii).FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                             '品名ｺｰﾄﾞ
                        '    objTRST_STOCK.ARYME(ii).FLOT_NO = strDenbunDtl(DSPLOT_NO)                                   'ﾛｯﾄ№
                        '    objTRST_STOCK.ARYME(ii).FSEIHIN_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPSEIHIN_KUBUN))  '製品区分
                        '    objTRST_STOCK.ARYME(ii).FHORYU_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPHORYU_KUBUN))    '保留区分

                        '    objTRST_STOCK.ARYME(ii).UPDATE_TRST_STOCK()                                                 '更新

                        'Next

                        ''=====================
                        ''在庫更新
                        ''=====================
                        'Dim objSVR_100104 As New SVR_100104(Owner, ObjDb, ObjDbLog)     '在庫更新ｸﾗｽ
                        'objSVR_100104.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｵﾌﾞｼﾞｪｸﾄ
                        'objSVR_100104.OBJTRST_STOCK = objTRST_STOCK                     '在庫情報ｵﾌﾞｼﾞｪｸﾄ
                        'objSVR_100104.FINOUT_STS = FINOUT_STS_MENTE_UPDATE              'IN/OUT
                        ''↓↓↓↓↓↓************************************************************************************************************
                        ''JobMate:K.Shimizu 2011/09/09 原料と包材のINOUT実績を分ける
                        ''objSVR_100104.FSAGYOU_KIND = FSAGYOU_KIND_SYSTEM_MENTE          '作業種別(ｼｽﾃﾑ保守)
                        'objSVR_100104.FSAGYOU_KIND = intFSAGYO_KIND                     '作業種別
                        ''↑↑↑↑↑↑************************************************************************************************************
                        'objSVR_100104.STOCK_UPDATE()                                    '更新


                        '↑↑↑↑↑↑************************************************************************************************************


                    End If
                End If

            End If

            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの更新
            '************************

            If TO_INTEGER(objTMST_TRK.FBUF_KIND) = FBUF_KIND_SASRS Then
                '(倉庫の場合)

                objTPRG_TRK_BUF.FREMOVE_KIND = TO_NUMBER(strDenbunDtl(DSPREMOVE_KIND))  '禁止棚設定
                objTPRG_TRK_BUF.FRAC_FORM = TO_NUMBER(strDenbunDtl(DSPRAC_FORM))        '棚形状種別
                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/04/25  在庫情報
                objTPRG_TRK_BUF.FRAC_BUNRUI = strDenbunDtl(DSPRAC_BUNRUI)               '棚分類
                '↑↑↑↑↑↑************************************************************************************************************
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:A.Noto 2013/03/26 JOB固有項目追加
                'objTPRG_TRK_BUF.FBUF_IN_DT = dtmNow                                                            'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF.FBUF_IN_DT = TO_DATE_NULLABLE(strDenbunDtl(DSPBUF_IN_DT))                       'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF.XTANA_BLOCK = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTANA_BLOCK))                 '棚ﾌﾞﾛｯｸ
                objTPRG_TRK_BUF.XTANA_BLOCK_DTL = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTANA_BLOCK_DTL))         '棚ﾌﾞﾛｯｸ詳細
                objTPRG_TRK_BUF.XTANA_BLOCK_STS = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTANA_BLOCK_STS))         '棚ﾌﾞﾛｯｸ状態
                '↑↑↑↑↑↑************************************************************************************************************
                objTPRG_TRK_BUF.UPDATE_TPRG_TRK_BUF()                                   '更新

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:H.Okumura 2013/07/17 棚ﾌﾞﾛｯｸ単位で更新(未使用棚を除く)
                Dim strXTANA_BLOCK As String
                strXTANA_BLOCK = objTPRG_TRK_BUF.XTANA_BLOCK        '棚ﾌﾞﾛｯｸ

                Dim strSQL As String
                Dim intRetSQL As Integer    'SQL実行戻り値

                strSQL = ""
                strSQL &= vbCrLf & "UPDATE"
                strSQL &= vbCrLf & "      TPRG_TRK_BUF "
                strSQL &= vbCrLf & " SET "
                strSQL &= vbCrLf & "      FREMOVE_KIND = " & TO_NUMBER(strDenbunDtl(DSPREMOVE_KIND)) & " "
                strSQL &= vbCrLf & " WHERE"
                strSQL &= vbCrLf & "      XTANA_BLOCK = " & strXTANA_BLOCK & " "
                strSQL &= vbCrLf & "  AND FTRK_BUF_NO = " & objTPRG_TRK_BUF.FTRK_BUF_NO & " "
                If TO_NUMBER(strDenbunDtl(DSPREMOVE_KIND)) <> FREMOVE_KIND_SNON Then
                    strSQL &= vbCrLf & "  AND FREMOVE_KIND <> " & FREMOVE_KIND_SNON & " "               '未使用棚を除く
                End If
                strSQL &= vbCrLf
                intRetSQL = ObjDb.Execute(strSQL)
                If intRetSQL = -1 Then
                    '(SQLｴﾗｰ)
                    strSQL = Replace(strSQL, vbCrLf, "")
                    strMsg = ERRMSG_ERR_UPDATE & ObjDb.ErrMsg & "【" & strSQL & "】"
                    Throw New UserException(strMsg)
                End If
                If intRetSQL < 1 Then
                    strMsg = "ERRMSG_NOTFOUND_TPRG_TRK_BUF" & "[ﾊﾞｯﾌｧ№:" & objTPRG_TRK_BUF.FTRK_BUF_NO & "  ,棚ﾌﾞﾛｯｸ:" & strXTANA_BLOCK & "]"
                    Throw New UserException(strMsg)
                End If
                '↑↑↑↑↑↑************************************************************************************************************


            End If


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:A.Noto 2013/03/26 変更履歴未使用
            ''**************************************
            ''ﾛｸﾞ用ｵﾌﾞｼﾞｪｸﾄ作成
            ''**************************************
            ''在庫情報
            'Dim objTRST_STOCK_After As TBL_TRST_STOCK = Nothing
            'Select Case TO_INTEGER(strDenbunDtl(DSPDIR_KUBUN))
            '    Case FORMAT_DSP_DSPDIR_KUBUN_UPDATE
            '        objTRST_STOCK_After = objTRST_STOCK.ARYME(0)
            '    Case FORMAT_DSP_DSPDIR_KUBUN_INSERT_STOCK
            '        objTRST_STOCK_After = objTRST_STOCK
            '    Case FORMAT_DSP_DSPDIR_KUBUN_DELETE_STOCK
            '        objTRST_STOCK_After = Nothing
            '    Case FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK
            '        objTRST_STOCK_After = Nothing
            'End Select

            ''ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            'Dim objTPRG_TRK_BUF_After As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            'objTPRG_TRK_BUF_After.FTRK_BUF_NO = strDenbunDtl(DSPTRK_BUF_NO)                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            'objTPRG_TRK_BUF_After.FTRK_BUF_ARRAY = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_ARRAY))    'ﾄﾗｯｷﾝｸﾞ配列No
            'intRet = objTPRG_TRK_BUF_After.GET_TPRG_TRK_BUF(True)                               '特定


            ''**************************************
            ''変更履歴詳細追加
            ''**************************************
            'Call Add_TEVD_TBLCHANGE_DTL_TRST_STOCK(strDenbunDtl _
            '                                     , MeSyoriID _
            '                                     , objTPRG_TRK_BUF_Before _
            '                                     , objTRST_STOCK_Before _
            '                                     , objTPRG_TRK_BUF_After _
            '                                     , objTRST_STOCK_After _
            '                                     )


            ''************************
            ''在庫更新履歴の登録
            ''************************
            'If IsNull(objTRST_STOCK_After) = False Then
            '    '(在庫が存在した場合)
            '    Call ADD_STOCK_LOG(strDenbunDtl, objTRST_STOCK_After)
            'End If
            '↑↑↑↑↑↑************************************************************************************************************


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
    ''' <param name="strDenbunDtl">電文内容構造体</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MenteStockDELETE(ByVal strDenbunDtl() As String)
        Try
            Dim intRet As Integer                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '**************************************
            'ﾛｸﾞ用ｵﾌﾞｼﾞｪｸﾄ作成
            '**************************************
            '在庫情報
            Dim objTRST_STOCK_Before As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            objTRST_STOCK_Before.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)       'ﾊﾟﾚｯﾄID
            intRet = objTRST_STOCK_Before.GET_TRST_STOCK_KONSAI(True)          '特定

            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            Dim objTPRG_TRK_BUF_Before As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF_Before.FTRK_BUF_NO = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_NO))         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            objTPRG_TRK_BUF_Before.FTRK_BUF_ARRAY = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_ARRAY))   'ﾄﾗｯｷﾝｸﾞ配列No
            intRet = objTPRG_TRK_BUF_Before.GET_TPRG_TRK_BUF(False)                             '特定


            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF.FTRK_BUF_NO = strDenbunDtl(DSPTRK_BUF_NO)                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            objTPRG_TRK_BUF.FTRK_BUF_ARRAY = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_ARRAY))  'ﾄﾗｯｷﾝｸﾞ配列No
            intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)                             '特定
            If TO_INTEGER(objTPRG_TRK_BUF.FRES_KIND) <> FRES_KIND_SZAIKO Then
                '(引当状態が在庫以外の場合)
                strMsg = ERRMSG_DISP_TRK & "[ﾊﾞｯﾌｧNo:" & TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO) & "  ,配列No:" & TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY) & "  ,在庫引当状態:" & TO_STRING(objTPRG_TRK_BUF.FRES_KIND) & "]"
                Throw New System.Exception(strMsg)
            End If


            '************************
            '在庫引当情報の削除
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '在庫引当情報ｸﾗｽ
            objTSTS_HIKIATE.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)             'ﾊﾟﾚｯﾄID
            objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()                        '削除


            '************************
            '作業種別を取得
            '************************
            Dim intFSAGYO_KIND = FSAGYOU_KIND_SSYSTEM_MENTE_NON


            '************************
            '在庫削除
            '************************
            Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '在庫削除ｸﾗｽ
            objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            objSVR_100102.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)       'ﾊﾟﾚｯﾄID
            objSVR_100102.FINOUT_STS = FINOUT_STS_SMENTE_DELETE          'INOUT(ﾒﾝﾃﾅﾝｽ削除)
            objSVR_100102.FSAGYOU_KIND = intFSAGYO_KIND                 '作業種別
            objSVR_100102.STOCK_DELETE()                                '削除


            '************************
            '在庫情報の特定
            '************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '在庫情報ｸﾗｽ
            objTRST_STOCK.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)           'ﾊﾟﾚｯﾄID
            intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(False)             '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)

                '************************
                '引当ﾊﾞｯﾌｧの解放
                '************************
                Dim objTPRG_TRK_BUF_CLEAR As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)   '在庫削除ｸﾗｽ
                objTPRG_TRK_BUF_CLEAR.FRSV_PALLET = strDenbunDtl(DSPPALLET_ID)              'ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_CLEAR.CLEAR_TPRG_TRK_BUF_RSV_PC()                           '解放

            End If


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:A.Noto 2013/03/26 変更履歴未使用
            ''**************************************
            ''ﾛｸﾞ用ｵﾌﾞｼﾞｪｸﾄ作成
            ''**************************************
            ''ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            'Dim objTPRG_TRK_BUF_After As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            'objTPRG_TRK_BUF_After.FTRK_BUF_NO = strDenbunDtl(DSPTRK_BUF_NO)                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            'objTPRG_TRK_BUF_After.FTRK_BUF_ARRAY = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_ARRAY))    'ﾄﾗｯｷﾝｸﾞ配列No
            'intRet = objTPRG_TRK_BUF_After.GET_TPRG_TRK_BUF(True)                               '特定


            ''**************************************
            ''変更履歴詳細追加
            ''**************************************
            'For ii As Integer = LBound(objTRST_STOCK_Before.ARYME) To UBound(objTRST_STOCK_Before.ARYME)
            '    '(ﾙｰﾌﾟ:個装数)
            '    Call Add_TEVD_TBLCHANGE_DTL_TRST_STOCK(strDenbunDtl _
            '                                         , MeSyoriID _
            '                                         , objTPRG_TRK_BUF_Before _
            '                                         , objTRST_STOCK_Before.ARYME(ii) _
            '                                         , objTPRG_TRK_BUF_After _
            '                                         , Nothing _
            '                                         )
            'Next


            ''************************
            ''在庫更新履歴の登録
            ''************************
            'For ii As Integer = LBound(objTRST_STOCK_Before.ARYME) To UBound(objTRST_STOCK_Before.ARYME)
            '    '(ﾙｰﾌﾟ:個装数)
            '    Call ADD_STOCK_LOG(strDenbunDtl, objTRST_STOCK_Before.ARYME(ii))
            'Next
            '↑↑↑↑↑↑************************************************************************************************************


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region

#Region "  在庫更新履歴の登録                                                                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在庫更新履歴の登録
    ''' </summary>
    ''' <param name="strDenbunDtl">電文内容構造体</param>
    ''' <param name="objTRST_STOCK"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ADD_STOCK_LOG(ByVal strDenbunDtl() As String, ByVal objTRST_STOCK As TBL_TRST_STOCK)
        Try
            '***********************
            '作業種別の特定
            '***********************
            Dim intSAGYOU_KIND As Integer
            Select Case strDenbunDtl(DSPDIR_KUBUN)     '処理区分
                Case FORMAT_DSP_DSPDIR_KUBUN_INSERT
                    '(追加)
                    intSAGYOU_KIND = FSAGYOU_KIND_SSTOCK_ADD


                Case FORMAT_DSP_DSPDIR_KUBUN_UPDATE
                    '(更新)
                    intSAGYOU_KIND = FSAGYOU_KIND_SSTOCK_CHG


                Case FORMAT_DSP_DSPDIR_KUBUN_DELETE
                    '(削除)
                    intSAGYOU_KIND = FSAGYOU_KIND_SSTOCK_DEL

            End Select


            '***********************
            '端末ﾏｽﾀの特定
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)               '端末ﾏｽﾀ
            If IsNull(strDenbunDtl(DSPTERM_ID)) = False Then
                objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '端末ID     ｾｯﾄ
                Call objTDSP_TERM.GET_TDSP_TERM(False)                                  '特定
            End If


            '***********************
            'ﾕｰｻﾞｰﾏｽﾀの特定
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)               'ﾕｰｻﾞｰﾏｽﾀ
            If IsNull(strDenbunDtl(DSPUSER_ID)) = False Then
                objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)                          'ﾕｰｻﾞｰID
                Call objTMST_USER.GET_TMST_USER(False)                                  '特定
            End If


            '************************
            '搬送元ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀｸﾗｽ
            objTMST_TRK.FTRK_BUF_NO = TO_DECIMAL(strDenbunDtl(DSPTRK_BUF_NO))           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            Call objTMST_TRK.GET_TMST_TRK(False)                                        '特定


            '***********************
            '作業種別毎制御情報の特定
            '***********************
            Dim objTMST_SAGYO As New TBL_TMST_SAGYO(Owner, ObjDb, ObjDbLog)             '作業種別毎制御情報
            If IsNull(intSAGYOU_KIND) = False Then
                objTMST_SAGYO.FSAGYOU_KIND = intSAGYOU_KIND                             '作業種別
                objTMST_SAGYO.FEQ_ID = FEQ_ID_SKOTEI                                    '設備ID
                Call objTMST_SAGYO.GET_TMST_SAGYO(False)                                '特定
            End If


            '**************************************
            '品名ﾏｽﾀの特定
            '**************************************
            Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
            objTMST_ITEM.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                        '品名ｺｰﾄﾞ
            Call objTMST_ITEM.GET_TMST_ITEM(False)                                      '特定


            '************************
            '在庫更新履歴の登録
            '************************
            Dim objTEVD_STOCK_LOG As New TBL_TEVD_STOCK_LOG(Owner, ObjDb, ObjDbLog)     '在庫更新履歴ﾃｰﾌﾞﾙｸﾗｽ
            objTEVD_STOCK_LOG.FENTRY_DT = Now                                           '登録日時
            objTEVD_STOCK_LOG.FPALLET_ID = objTRST_STOCK.FPALLET_ID                     'ﾊﾟﾚｯﾄID
            objTEVD_STOCK_LOG.FTERM_ID = objTDSP_TERM.FTERM_ID                          '端末ID
            objTEVD_STOCK_LOG.FTERM_NAME = objTDSP_TERM.FTERM_NAME                      '端末名
            objTEVD_STOCK_LOG.FUSER_ID = objTMST_USER.FUSER_ID                          'ﾕｰｻﾞｰID
            objTEVD_STOCK_LOG.FUSER_NAME = objTMST_USER.FUSER_NAME                      'ﾕｰｻﾞｰ名
            objTEVD_STOCK_LOG.FPLACE_CD = objTMST_TRK.FPLACE_CD                         '保管場所ｺｰﾄﾞ
            objTEVD_STOCK_LOG.FAREA_CD = objTMST_TRK.FAREA_CD                           'ｴﾘｱ
            objTEVD_STOCK_LOG.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD                      '品名ｺｰﾄﾞ
            objTEVD_STOCK_LOG.FHINMEI = objTMST_ITEM.FHINMEI                            '品名
            objTEVD_STOCK_LOG.FLOT_NO = strDenbunDtl(DSPLOT_NO)                         'ﾛｯﾄ№
            objTEVD_STOCK_LOG.FSAGYOU_KIND = objTMST_SAGYO.FSAGYOU_KIND                 '作業種別
            objTEVD_STOCK_LOG.FNUM_IN_CASE = objTMST_ITEM.FNUM_IN_CASE                  'ｹｰｽ入数
            objTEVD_STOCK_LOG.FTANI = objTMST_ITEM.FTANI                                '単位
            objTEVD_STOCK_LOG.FSEIHIN_KUBUN = TO_DECIMAL(strDenbunDtl(DSPSEIHIN_KUBUN)) '製品区分
            objTEVD_STOCK_LOG.FZAIKO_KUBUN = TO_DECIMAL(strDenbunDtl(DSPZAIKO_KUBUN))   '在庫区分
            objTEVD_STOCK_LOG.FRECEIVEPAY_NUM = TO_DECIMAL(strDenbunDtl(DSPTR_VOL))     '受払数量
            objTEVD_STOCK_LOG.FZAIKO_NUM = TO_DECIMAL(strDenbunDtl(DSPTR_VOL))          '在庫数量
            objTEVD_STOCK_LOG.FSAGYOU_CONTENT = objTMST_SAGYO.FSAGYOU_CONTENT           '作業内容
            objTEVD_STOCK_LOG.ADD_TEVD_STOCK_LOG_SEQ()


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
