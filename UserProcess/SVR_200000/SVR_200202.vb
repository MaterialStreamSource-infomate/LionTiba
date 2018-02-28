'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】代替棚指示要求
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_200202
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0         '端末ID
    Private Const DSPUSER_ID As Integer = 1         'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2          '理由

    Private Const DSPSIZI_KUBUN As Integer = 3      '指示区分
    Private Const DSPTRK_BUF_NO As Integer = 4      'ﾊﾞｯﾌｧ№
    Private Const DSPTRK_BUF_ARRAY As Integer = 5   'ﾊﾞｯﾌｧ配列№
    Private Const DSPST_OUT As Integer = 6          '出庫先ST
    Private Const DSPEQ_ID As Integer = 7           '設備ID
    Private Const DSPPALLET_ID As Integer = 8       'ﾊﾟﾚｯﾄID

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
            '初期設定
            '************************
            Dim dtmNow As Date = Now
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)


            '************************
            'ｸﾚｰﾝ状態の特定
            '************************
            Dim objTSTS_CRANE As New TBL_TSTS_CRANE(Owner, ObjDb, ObjDbLog)
            objTSTS_CRANE.FEQ_ID = strDenbunDtl(DSPEQ_ID)       '設備ID
            objTSTS_CRANE.GET_TSTS_CRANE()                      '特定


            '************************
            '移動中ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)   '移動中ﾄﾗｯｷﾝｸﾞ
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)       'ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF()                            '特定


            '************************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ    特定
            '************************************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTMST_TRK.GET_TMST_TRK()                                      '取得


            '************************
            '倉庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    '倉庫ﾄﾗｯｷﾝｸﾞ
            Select Case objTMST_TRK.FBUF_KIND
                Case FBUF_KIND_SIN
                    '(入庫完了の場合)
                    objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
                Case FBUF_KIND_SOUT
                    '(出庫完了の場合)
                    objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
                Case Else
                    Exit Function
            End Select
            objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()                             '特定


            '************************
            'ｸﾚｰﾝﾏｽﾀ特定
            '************************
            Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)
            objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU             'ﾁｪｯｸ列
            intRet = objTMST_CRANE.GET_TMST_CRANE_ROW()                             '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                Throw New UserException(strMsg)
            End If
            If objTMST_CRANE.FEQ_ID <> strDenbunDtl(DSPEQ_ID) Then
                '(ｸﾚｰﾝIDが一致していない場合)
                strMsg = "指定された棚番には、代替棚指示出来ません。"
                strMsg &= vbCrLf & "同じｸﾚｰﾝの棚番を設定して下さい。"
                Throw New UserException(strMsg)
            End If


            '************************
            'ﾃﾞｰﾀを設定 & 処理実行
            '************************
            Select Case strDenbunDtl(DSPSIZI_KUBUN)
                Case FORMAT_DSP_DSPSIZI_KUBUN_TOCHANGE, FORMAT_DSP_DSPSIZI_KUBUN_TOCHANGE_FUICCHI
                    '(行先変更の場合)


                    '************************************************************************************************************************
                    '************************************************************************************************************************
                    '行先変更
                    '************************************************************************************************************************
                    '************************************************************************************************************************
                    '===============================
                    '代替入庫先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ取得
                    '===============================
                    Dim objTPRG_TRK_BUF_NEW_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
                    objTPRG_TRK_BUF_NEW_ASRS.FTRK_BUF_NO = TO_DECIMAL(strDenbunDtl(DSPTRK_BUF_NO))       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
                    objTPRG_TRK_BUF_NEW_ASRS.FTRK_BUF_ARRAY = TO_DECIMAL(strDenbunDtl(DSPTRK_BUF_ARRAY)) 'ﾄﾗｯｷﾝｸﾞ配列No
                    objTPRG_TRK_BUF_NEW_ASRS.GET_TPRG_TRK_BUF()                                          '特定
                    If objTPRG_TRK_BUF_NEW_ASRS.FPALLET_ID <> "" _
                    Or objTPRG_TRK_BUF_NEW_ASRS.FRES_KIND <> FRES_KIND_SAKI _
                    Then
                        '(ﾊﾟﾚｯﾄIDがない場合)
                        strMsg = "ﾊﾟﾚｯﾄIDもしくは在庫引当情報が不正です。[ﾊﾞｯﾌｧNo:" & TO_STRING(objTPRG_TRK_BUF_NEW_ASRS.FTRK_BUF_NO) & "  ,配列No:" & TO_STRING(objTPRG_TRK_BUF_NEW_ASRS.FTRK_BUF_ARRAY) & "]"
                        Throw New System.Exception(strMsg)
                    End If

                    '===============================
                    '入庫中ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ更新
                    '===============================
                    objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO = objTPRG_TRK_BUF_NEW_ASRS.FTRK_BUF_NO                'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO = objTPRG_TRK_BUF_NEW_ASRS.FTRK_BUF_ARRAY           'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
                    objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_NEW_ASRS.FDISP_ADDRESS         'TO表記用ｱﾄﾞﾚｽ
                    objTPRG_TRK_BUF_RELAY.UPDATE_TPRG_TRK_BUF()                                             '更新

                    '===============================
                    '代替入庫先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ更新
                    '===============================
                    objTPRG_TRK_BUF_NEW_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                           '引当状態
                    objTPRG_TRK_BUF_NEW_ASRS.FRSV_PALLET = objTPRG_TRK_BUF_RELAY.FPALLET_ID               '仮引当ﾊﾟﾚｯﾄID
                    objTPRG_TRK_BUF_NEW_ASRS.FRSV_BUF_FM = objTPRG_TRK_BUF_ASRS.FRSV_BUF_FM               'FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTPRG_TRK_BUF_NEW_ASRS.FRSV_ARRAY_FM = objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_FM           'FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
                    objTPRG_TRK_BUF_NEW_ASRS.UPDATE_TPRG_TRK_BUF()

                    '===============================
                    '変更前入庫先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ解放
                    '===============================
                    objTPRG_TRK_BUF_ASRS.CLEAR_TPRG_TRK_BUF()           '解放
                    objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SAKI     '引当状態
                    objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()          '更新

                    ''**************************************
                    ''品名ﾏｽﾀの取得
                    ''**************************************
                    'Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                    'objTMST_ITEM.FHINMEI_CD = strFHINMEI_CD                         '品名ｺｰﾄﾞ
                    'intRet = objTMST_ITEM.GET_TMST_ITEM()                           '特定
                    'If intRet <> RetCode.OK Then
                    '    '(見つからない場合)
                    '    strMsg = ERRMSG_NOTFOUND_TMST_ITEM & "[品名ｺｰﾄﾞ:" & objTMST_ITEM.FHINMEI_CD & "]"
                    '    Throw New UserException(strMsg)
                    'End If

                    '************************
                    '在庫情報の登録
                    '************************
                    Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '在庫情報ﾃｰﾌﾞﾙｸﾗｽ
                    'objTRST_STOCK.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD              '品名ｺｰﾄﾞ
                    'objTRST_STOCK.FLOT_NO = KOTEI_LOT_NO_STOCK                      'ﾛｯﾄ№
                    objTRST_STOCK.FARRIVE_DT = dtmNow                               '在庫発生日時
                    'objTRST_STOCK.FIN_KUBUN = DEFAULT_INTEGER                       '入庫区分
                    'objTRST_STOCK.FSEIHIN_KUBUN = FSEIHIN_KUBUN_ETC                 '製品区分
                    'objTRST_STOCK.FZAIKO_KUBUN = objTMST_ITEM.FZAIKO_KUBUN          '在庫区分
                    'objTRST_STOCK.FHORYU_KUBUN = FHORYU_KUBUN_NORMAL                '保留区分
                    'objTRST_STOCK.FST_FM = DEFAULT_INTEGER                          '元ｽﾃｰｼｮﾝ№
                    objTRST_STOCK.FTR_VOL = FTR_VOL_SKOTEI                          '搬送管理量
                    objTRST_STOCK.FTR_RES_VOL = FTR_RES_VOL_SKOTEI                  '搬送引当量
                    objTRST_STOCK.FUPDATE_DT = dtmNow                               '更新日時
                    objTRST_STOCK.FHASU_FLAG = FLAG_OFF                             '端数ﾌﾗｸﾞ
                    objTRST_STOCK.ADD_TRST_STOCK_ALL()                              '登録


                    '************************
                    '在庫登録
                    '************************
                    Dim objSVR_100101 As New SVR_100101(Owner, ObjDb, ObjDbLog)     '在庫登録ｸﾗｽ
                    objSVR_100101.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_ASRS            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                    objSVR_100101.FPALLET_ID = objTRST_STOCK.FPALLET_ID             'ﾊﾟﾚｯﾄID
                    objSVR_100101.FINOUT_STS = FINOUT_STS_SMENTE_ADD                'INOUT
                    objSVR_100101.FSAGYOU_KIND = FSAGYOU_KIND_SSYSTEM_MENTE_NON     '作業種別
                    objSVR_100101.STOCK_ADD()                                       '登録


                    '************************
                    'ﾄﾗｯｷﾝｸﾞ強制完了
                    '************************
                    Dim objSVR_100301 As New SVR_100301(Owner, ObjDb, ObjDbLog)     'ﾄﾗｯｷﾝｸﾞ強制完了ｸﾗｽ
                    objSVR_100301.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO   'ﾊﾞｯﾌｧ№
                    objSVR_100301.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)           'ﾊﾟﾚｯﾄID
                    objSVR_100301.MENTE_FINISH()                                    'ﾄﾗｯｷﾝｸﾞ強制完了


                    '************************
                    'ｸﾚｰﾝ状態の更新
                    '************************
                    objTSTS_CRANE.FCOMP_KUBUN = FCOMP_KUBUN_SNORMAL     '完了区分
                    objTSTS_CRANE.FUPDATE_DT = Now                      '更新日時
                    objTSTS_CRANE.UPDATE_TSTS_CRANE()                   '更新


                Case FORMAT_DSP_DSPSIZI_KUBUN_MANUAL, FORMAT_DSP_DSPSIZI_KUBUN_MANUAL_FUICCHI
                    '(手動払い出しの場合)


                    '************************************************************************************************************************
                    '************************************************************************************************************************
                    '手動払い出し
                    '************************************************************************************************************************
                    '************************************************************************************************************************
                    '===============================
                    '入庫中ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ更新
                    '===============================
                    objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO = Nothing                 'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO = Nothing               'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
                    objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO = Nothing            'TO表記用ｱﾄﾞﾚｽ
                    objTPRG_TRK_BUF_RELAY.UPDATE_TPRG_TRK_BUF()                 '更新

                    '===============================
                    '変更前入庫先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ解放
                    '===============================
                    objTPRG_TRK_BUF_ASRS.CLEAR_TPRG_TRK_BUF()           '解放
                    objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SAKI     '引当状態
                    objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()          '更新


                    ''**************************************
                    ''品名ﾏｽﾀの取得
                    ''**************************************
                    'Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                    'objTMST_ITEM.FHINMEI_CD = strFHINMEI_CD                         '品名ｺｰﾄﾞ
                    'intRet = objTMST_ITEM.GET_TMST_ITEM()                           '特定
                    'If intRet <> RetCode.OK Then
                    '    '(見つからない場合)
                    '    strMsg = ERRMSG_NOTFOUND_TMST_ITEM & "[品名ｺｰﾄﾞ:" & objTMST_ITEM.FHINMEI_CD & "]"
                    '    Throw New UserException(strMsg)
                    'End If


                    '************************
                    '在庫情報の登録
                    '************************
                    Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '在庫情報ﾃｰﾌﾞﾙｸﾗｽ
                    'objTRST_STOCK.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD              '品名ｺｰﾄﾞ
                    'objTRST_STOCK.FLOT_NO = KOTEI_LOT_NO_STOCK                      'ﾛｯﾄ№
                    objTRST_STOCK.FARRIVE_DT = dtmNow                               '在庫発生日時
                    'objTRST_STOCK.FIN_KUBUN = DEFAULT_INTEGER                       '入庫区分
                    'objTRST_STOCK.FSEIHIN_KUBUN = FSEIHIN_KUBUN_ETC                 '製品区分
                    'objTRST_STOCK.FZAIKO_KUBUN = objTMST_ITEM.FZAIKO_KUBUN          '在庫区分
                    'objTRST_STOCK.FHORYU_KUBUN = FHORYU_KUBUN_NORMAL                '保留区分
                    objTRST_STOCK.FST_FM = DEFAULT_INTEGER                          '元ｽﾃｰｼｮﾝ№
                    objTRST_STOCK.FTR_VOL = FTR_VOL_SKOTEI                          '搬送管理量
                    objTRST_STOCK.FTR_RES_VOL = FTR_RES_VOL_SKOTEI                  '搬送引当量
                    objTRST_STOCK.FUPDATE_DT = dtmNow                               '更新日時
                    'objTRST_STOCK.FHASU_FLAG = FLAG_OFF                             '端数ﾌﾗｸﾞ
                    objTRST_STOCK.ADD_TRST_STOCK_ALL()                              '登録

                    '************************
                    '在庫登録
                    '************************
                    Dim objSVR_100101 As New SVR_100101(Owner, ObjDb, ObjDbLog)     '在庫登録ｸﾗｽ
                    objSVR_100101.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_ASRS            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                    objSVR_100101.FPALLET_ID = objTRST_STOCK.FPALLET_ID             'ﾊﾟﾚｯﾄID
                    objSVR_100101.FINOUT_STS = FINOUT_STS_SMENTE_ADD                'INOUT
                    objSVR_100101.FSAGYOU_KIND = FSAGYOU_KIND_SSYSTEM_MENTE_NON     '作業種別
                    objSVR_100101.STOCK_ADD()                                       '登録


                Case FORMAT_DSP_DSPSIZI_KUBUN_EMPTY
                    '(空出庫対応の場合)

                    '************************************************************************************************************************
                    '************************************************************************************************************************
                    '空出庫
                    '************************************************************************************************************************
                    '************************************************************************************************************************
                    '=======================
                    'ﾄﾗｯｷﾝｸﾞｷｬﾝｾﾙ
                    '=======================
                    Dim objSVR_100303 As New SVR_100303(Owner, ObjDb, ObjDbLog)     'ﾄﾗｯｷﾝｸﾞ強制完了ｸﾗｽ
                    objSVR_100303.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO   'ﾊﾞｯﾌｧ№
                    objSVR_100303.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID     'ﾊﾟﾚｯﾄID
                    objSVR_100303.KARA_OUT_FLAG = FLAG_ON                           '空出庫ﾌﾗｸﾞ
                    objSVR_100303.MENTE_CANCEL()                                    'ﾄﾗｯｷﾝｸﾞｷｬﾝｾﾙ

                    '=======================
                    'ﾄﾗｯｷﾝｸﾞ削除
                    '=======================
                    Dim objSVR_100302 As New SVR_100302(Owner, ObjDb, ObjDbLog)
                    objSVR_100302.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO    'ﾊﾞｯﾌｧ№
                    objSVR_100302.FPALLET_ID = objSVR_100303.FPALLET_ID             'ﾊﾟﾚｯﾄID
                    objSVR_100302.FTERM_ID = strDenbunDtl(DSPTERM_ID)               '端末ID
                    objSVR_100302.FUSER_ID = strDenbunDtl(DSPUSER_ID)               'ﾕｰｻﾞｰID
                    objSVR_100302.MENTE_DELETE()                                    'ﾄﾗｯｷﾝｸﾞ削除

                    '=======================
                    'ｸﾚｰﾝ状態の更新
                    '=======================
                    objTSTS_CRANE.FCOMP_KUBUN = FCOMP_KUBUN_SNORMAL     '完了区分
                    objTSTS_CRANE.FUPDATE_DT = Now                      '更新日時
                    objTSTS_CRANE.UPDATE_TSTS_CRANE()                   '更新


                Case Else
                    'NOP
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

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
