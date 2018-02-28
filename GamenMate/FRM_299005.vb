'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】在庫移行ﾂｰﾙ
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_299005

#Region "  共通変数                             "

    '旧在庫ﾃﾞｰﾀ
    Private Const MAINKEY_FRAC_RETU As Integer = 2          '列
    Private Const MAINKEY_FRAC_REN As Integer = 2           '連
    Private Const MAINKEY_FRAC_DAN As Integer = 2           '段

    Private Const SUBKEY1_XHINMEI_CD As Integer = 6         '品名ｺｰﾄﾞ
    Private Const SUBKEY1_FREMOVE_KIND As Integer = 2       'ﾌﾞﾛｯｸ状態
    Private Const SUBKEY1_VAL3 As Integer = 2               '棚格納状態(未使用)
    Private Const SUBKEY1_FIN_KUBUN As Integer = 2          '検索優先順
    Private Const SUBKEY1_FBUF_IN_DT As Integer = 8         '入庫年月日
    Private Const SUBKEY1_XPROD_LINE As Integer = 6         '生産ﾗｲﾝNo.
    Private Const SUBKEY1_FBUF_IN_DT_TIME As Integer = 6    '入庫時分秒

    Private Const SUBKEY2_XHINMEI_CD As Integer = 6         '品名ｺｰﾄﾞ(未使用)
    Private Const SUBKEY2_FBUF_IN_DT As Integer = 8         '入庫年月日(未使用)
    Private Const SUBKEY2_FBUF_IN_DT_TIME As Integer = 6    '入庫時分秒(未使用)
    Private Const SUBKEY2_XPROD_LINE As Integer = 6         '生産ﾗｲﾝNo.(未使用)

    Private Const DATA1_VAL1 As Integer = 2                 '混載数(未使用)
    Private Const DATA1_VAL2 As Integer = 8                 '棚ﾌﾞﾛｯｸ在庫梱数(未使用)
    Private Const DATA1_VAL3 As Integer = 8                 '棚ﾌﾞﾛｯｸ引当梱数(未使用)
    Private Const DATA1_VAL4 As Integer = 1                 '商品区分(未使用)
    Private Const DATA1_FREMOVE_KIND As Integer = 2         '棚禁止詳細

    Private Const DATA1_TANA1_FBUF_IN_DT As Integer = 8         '棚1 入庫年月日
    Private Const DATA1_TANA1_FBUF_IN_DT_TIME As Integer = 6    '棚1 入庫時分秒
    Private Const DATA1_TANA1_FTR_VOL As Integer = 8            '棚1 在庫梱数
    Private Const DATA1_TANA1_FRES_KIND As Integer = 1          '棚1 引当区分
    Private Const DATA1_TANA1_FHASU_FLAG As Integer = 1         '棚1 棚区分

    Private Const DATA1_TANA2_FBUF_IN_DT As Integer = 8         '棚2 入庫年月日
    Private Const DATA1_TANA2_FBUF_IN_DT_TIME As Integer = 6    '棚2 入庫時分秒
    Private Const DATA1_TANA2_FTR_VOL As Integer = 8            '棚2 在庫梱数
    Private Const DATA1_TANA2_FRES_KIND As Integer = 1          '棚2 引当区分
    Private Const DATA1_TANA2_FHASU_FLAG As Integer = 1         '棚2 棚区分

    Private Const DATA1_TANA3_FBUF_IN_DT As Integer = 8         '棚3 入庫年月日
    Private Const DATA1_TANA3_FBUF_IN_DT_TIME As Integer = 6    '棚3 入庫時分秒
    Private Const DATA1_TANA3_FTR_VOL As Integer = 8            '棚3 在庫梱数
    Private Const DATA1_TANA3_FRES_KIND As Integer = 1          '棚3 引当区分
    Private Const DATA1_TANA3_FHASU_FLAG As Integer = 1         '棚3 棚区分

    Private Const DATA1_TANA4_FBUF_IN_DT As Integer = 8         '棚4 入庫年月日
    Private Const DATA1_TANA4_FBUF_IN_DT_TIME As Integer = 6    '棚4 入庫時分秒
    Private Const DATA1_TANA4_FTR_VOL As Integer = 8            '棚4 在庫梱数
    Private Const DATA1_TANA4_FRES_KIND As Integer = 1          '棚4 引当区分
    Private Const DATA1_TANA4_FHASU_FLAG As Integer = 1         '棚4 棚区分

    Private Const DATA1_VAL26 As Integer = 2                    '出荷指示済PL数(未使用)
    Private Const DATA1_FUPDATE_DT As Integer = 8               '最終更新日



    Private Const DKA8300_MAINKEY_INDEX As Integer = 0      '項目1
    Private Const DKA8300_SUBKEY1_INDEX As Integer = 1      '項目2
    Private Const DKA8300_SUBKEY2_INDEX As Integer = 2      '項目3
    Private Const DKA8300_DATA1_INDEX As Integer = 3        '項目4

    Private Const DKA8300_MAINKEY_LENGTH As Integer = 6     '項目1 長さ
    Private Const DKA8300_SUBKEY1_LENGTH As Integer = 32    '項目2 長さ
    Private Const DKA8300_SUBKEY2_LENGTH As Integer = 26    '項目3 長さ
    Private Const DKA8300_DATA1_LENGTH As Integer = 136     '項目4 長さ

    '' ''Stockﾌｧｲﾙ
    ' ''Private Const F01_FTRK_BUF_NO As Integer = 0            '保管区分 9000
    ' ''Private Const F01_FRAC_RETU As Integer = 1              '列
    ' ''Private Const F01_FRAC_REN As Integer = 2               '連
    ' ''Private Const F01_FRAC_DAN As Integer = 3               '段
    ' ''Private Const F01_FHINMEI_CD As Integer = 4             '品名ｺｰﾄﾞ
    ' ''Private Const F01_XSEIZOU_DT As Integer = 5             '製造年月日
    ' ''Private Const F01_XLINE_NO As Integer = 6               'ﾗｲﾝ№
    ' ''Private Const F01_XPALLET_NO As Integer = 7             'ﾊﾟﾚｯﾄ№
    ' ''Private Const F01_FTR_VOL As Integer = 8                '数量
    ' ''Private Const F01_XKENSA_KUBUN As Integer = 9           '検査区分
    ' ''Private Const F01_XAB_KUBUN As Integer = 10             'AB区分
    ' ''Private Const F01_XSYUKKA_KAHI As Integer = 11          '出荷可否
    ' ''Private Const F01_XSTRETCH_STS As Integer = 12          'ｽﾄﾚｯﾁｽﾃｰﾀｽ
    ' ''Private Const F01_XHINSHITU_STS As Integer = 13         '品質ｽﾃｰﾀｽ
    ' ''Private Const F01_XLIMIT As Integer = 14                '賞味期限
    ' ''Private Const F01_FHORYU_KUBUN As Integer = 15          '保留区分
    ' ''Private Const F01_XHORYU_NO As Integer = 16             '保留№
    ' ''Private Const F01_XHORYU_REASON As Integer = 17         '保留理由
    ' ''Private Const F01_XHORYU_DT As Integer = 18             '保留年月日


    '' ''SHIPﾌｧｲﾙ
    ' ''Private Const F02_JIGYOUSYO_CD As Integer = 0           '事業所ｺｰﾄﾞ
    ' ''Private Const F02_FHINMEI_CD As Integer = 1             '(KEY)品目ｺｰﾄﾞ
    ' ''Private Const F02_ZAIKO_STS As Integer = 2              '在庫状態
    ' ''Private Const F02_XHINSHITU_STS As Integer = 3          '(ITEM)品質ｽﾃｰﾀｽ
    ' ''Private Const F02_XSEIZOU_DT As Integer = 4             '(KEY)製造年月日
    ' ''Private Const F02_XSYOMIKIGEN_DT As Integer = 5         '賞味期限
    ' ''Private Const F02_LOCATION_NO As Integer = 6            'ﾛｹｰｼｮﾝ№
    ' ''Private Const F02_SEIZOU_SASIZU As Integer = 7          '製造指図№
    ' ''Private Const F02_ORDER_NO As Integer = 8               '購買ｵｰﾀﾞｰ№
    ' ''Private Const F02_ORDER_EDA As Integer = 9              '購買ｵｰﾀﾞｰ№枝番
    ' ''Private Const F02_XPALLET_NO As Integer = 10            '(KEY)ﾊﾟﾚｯﾄ№(ﾗｲﾝ№ + ﾊﾟﾚｯﾄ№)
    ' ''Private Const F02_XPALLET_EDA As Integer = 11           '(ITEM)ﾊﾟﾚｯﾄ№枝番(検査区分 + AB区分)
    ' ''Private Const F02_REFARENCE_NO As Integer = 12          'ﾚﾌｧﾚﾝｽ№
    ' ''Private Const F02_SURYOU As Integer = 13                '数量
    ' ''Private Const F02_ECC_SURYOU As Integer = 14            'ECC数量


    'ﾃﾞﾌｫﾙﾄ値
    Private Const DEFAULT_HUMEI As String = ""              'ﾃﾞﾌｫﾙﾄ値不明

#End Region

#Region "  全在庫削除                   ｸﾘｯｸ    "
    Private Sub cmd001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd001.Click
        Try

            Dim intRet As RetCode
            Dim blnRet As Boolean = False

            If MessageBox.Show("OK?", "", MessageBoxButtons.OKCancel) <> Windows.Forms.DialogResult.OK Then Return


            '****************************************************
            '在庫情報取得
            '****************************************************
            Dim strSQL As String = ""
            Dim objTRST_STOCK As New TBL_TRST_STOCK(gobjOwner, gobjDb, Nothing)
            intRet = objTRST_STOCK.GET_TRST_STOCK_ANY()

            If intRet <> RetCode.OK Then
                Throw New Exception("在庫情報が見つかりません。")
            End If

            Try
                gobjDb.Commit()
                gobjDb.BeginTrans()

                If intRet = RetCode.OK Then

                    '****************************************************
                    '在庫情報取得
                    '****************************************************
                    For ii As Integer = LBound(objTRST_STOCK.ARYME) To UBound(objTRST_STOCK.ARYME)
                        '(ﾙｰﾌﾟ:在庫数)


                        '*******************************************************
                        '進捗更新
                        '*******************************************************
                        lblProgress.Text = TO_STRING(ii) & "/" & TO_STRING(UBound(objTRST_STOCK.ARYME))
                        Me.Refresh()
                        System.Windows.Forms.Application.DoEvents()


                        '****************************************************
                        '在庫情報取得
                        '****************************************************
                        Dim strDIR_KUBUN As String = ""     '指示区分
                        Dim intCount As Integer

                        Dim objCheck As New TBL_TRST_STOCK(gobjOwner, gobjDb, Nothing)
                        objCheck.FPALLET_ID = objTRST_STOCK.ARYME(ii).FPALLET_ID    'ﾊﾟﾚｯﾄID
                        intCount = objCheck.GET_TRST_STOCK_COUNT()
                        If intCount <= 0 Then
                            '在庫削除の場合)
                            Continue For
                        End If
                        strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_DELETE           '指示区分(在庫情報削除)


                        '****************************************************
                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                        '****************************************************
                        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
                        objTPRG_TRK_BUF.FPALLET_ID = objTRST_STOCK.ARYME(ii).FPALLET_ID     'ﾊﾟﾚｯﾄID
                        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(False)
                        If intRet <> RetCode.OK Then
                            MsgBox("ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧが見つかりません。[ﾊﾟﾚｯﾄID:" & objTRST_STOCK.ARYME(ii).FPALLET_ID & "]")
                            Continue For
                        End If
                        'Select Case objTPRG_TRK_BUF.FTRK_BUF_NO
                        '    Case FTRK_BUF_NO_9002, FTRK_BUF_NO_9910
                        '    Case Else : Continue For
                        'End Select


                        '*******************************************************
                        'ｿｹｯﾄ送信処理
                        '*******************************************************
                        '========================================
                        ' 変数宣言
                        '========================================
                        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

                        'Dim strDIR_KUBUN As String = ""                             '処理区分
                        Dim strFBUF_NO As String = ""                               'ﾊﾞｯﾌｧ№
                        Dim strFBUF_ARRAY As String = ""                            'ﾊﾞｯﾌｧ配列№
                        Dim strFREMOVE_KIND As String = ""                          '禁止棚設定
                        Dim strFRAC_FORM As String = ""                             '棚形状種別
                        Dim strFRES_KIND As String = ""                             '引当状態

                        Dim strFHINMEI_CD As String = ""                            '品名ｺｰﾄﾞ
                        Dim strFLOT_NO As String = ""                               'ﾛｯﾄ№
                        Dim strFARRIVE_DT As String = ""                            '在庫発生日時
                        Dim strFIN_KUBUN As String = ""                             '入庫区分
                        Dim strFSEIHIN_KUBUN As String = ""                         '製品区分
                        Dim strFZAIKO_KUBUN As String = ""                          '在庫区分
                        Dim strFHORYU_KUBUN As String = ""                          '保留区分
                        Dim strFST_FM As String = ""                                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        Dim strFTR_VOL As String = ""                               '搬送管理量
                        Dim strFTR_RES_VOL As String = ""                           '搬送引当量
                        Dim strFPALLET_ID As String = ""                            'ﾊﾟﾚｯﾄID
                        Dim strFLOT_NO_STOCK As String = ""                         '在庫ﾛｯﾄ№
                        Dim strFLABEL_ID As String = ""                             'ﾗﾍﾞﾙID
                        Dim strFHASU_FLAG As String = ""                            '端数ﾌﾗｸﾞ
                        Dim strFSYUKKA_TO_CD As String = ""                         '出荷先ｺｰﾄﾞ
                        Dim strFSYUKKA_TO_NAME As String = ""                       '出荷先名称
                        Dim strFRAC_BUNRUI As String = ""                           '棚分類


                        '**********************************************************************************************
                        '↓↓↓ｼｽﾃﾑ固有

                        Dim strXDSPSEIZOU_DT As String = ""                         '製造年月日
                        Dim strXDSPLINE_NO As String = ""                           'ﾗｲﾝ№
                        Dim strXDSPPALLET_NO As String = ""                         'ﾊﾟﾚｯﾄ№
                        Dim strXDSPKENSA_KUBUN As String = ""                       '検査区分
                        Dim strXDSPAB_KUBUN As String = ""                          'AB区分
                        Dim strXDSPSYUKKA_KAHI As String = ""                       '出荷可否
                        Dim strXDSPSTRETCH_KUBUN As String = ""                     'ｽﾄﾚｯﾁ区分
                        Dim strXDSPHINSHITU_STS As String = ""                      '品質ｽﾃｰﾀｽ
                        Dim strXDSPLIMIT As String = ""                             '賞味期限
                        Dim strXDSPHORYU_NO As String = ""                          '保留№
                        Dim strXDSPHORYU_REASON As String = ""                      '保留理由
                        Dim strXASRS_IN_DT As String = ""                           '入庫日時
                        Dim strXDSPHORYU_DT As String = ""                          '保留年月日

                        '↑↑↑ｼｽﾃﾑ固有
                        '**********************************************************************************************


                        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ


                        strFBUF_NO = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO)                 'ﾊﾞｯﾌｧ№
                        strFBUF_ARRAY = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY)           'ﾊﾞｯﾌｧ配列№
                        strFREMOVE_KIND = TO_STRING(objTPRG_TRK_BUF.FREMOVE_KIND)           '禁止棚設定
                        strFRAC_FORM = TO_STRING(objTPRG_TRK_BUF.FRAC_FORM)                 '棚形状種別
                        strFRES_KIND = TO_STRING(objTPRG_TRK_BUF.FRES_KIND)                 '引当状態

                        strFHINMEI_CD = TO_STRING(objTRST_STOCK.ARYME(ii).FHINMEI_CD)       '品名ｺｰﾄﾞ
                        strFLOT_NO = TO_STRING(objTRST_STOCK.ARYME(ii).FLOT_NO)             'ﾛｯﾄ№
                        strFARRIVE_DT = TO_STRING(objTRST_STOCK.ARYME(ii).FARRIVE_DT)       '在庫発生日時
                        strFIN_KUBUN = TO_STRING(objTRST_STOCK.ARYME(ii).FIN_KUBUN)         '入庫区分
                        strFSEIHIN_KUBUN = TO_STRING(objTRST_STOCK.ARYME(ii).FSEIHIN_KUBUN) '製品区分
                        strFZAIKO_KUBUN = TO_STRING(objTRST_STOCK.ARYME(ii).FZAIKO_KUBUN)   '在庫区分
                        strFHORYU_KUBUN = TO_STRING(objTRST_STOCK.ARYME(ii).FHORYU_KUBUN)   '保留区分
                        strFST_FM = TO_STRING(objTRST_STOCK.ARYME(ii).FST_FM)               '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        strFTR_VOL = TO_STRING(objTRST_STOCK.ARYME(ii).FTR_VOL)             '搬送管理量
                        strFTR_RES_VOL = TO_STRING(objTRST_STOCK.ARYME(ii).FTR_RES_VOL)     '搬送引当量
                        strFPALLET_ID = TO_STRING(objTRST_STOCK.ARYME(ii).FPALLET_ID)       'ﾊﾟﾚｯﾄID
                        strFLOT_NO_STOCK = TO_STRING(objTRST_STOCK.ARYME(ii).FLOT_NO_STOCK) '在庫ﾛｯﾄ№


                        objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO)                 'ﾊﾞｯﾌｧ№
                        objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY)           'ﾊﾞｯﾌｧ配列№
                        objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                        objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                        objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態

                        objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
                        objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                        objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                        objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                        objTelegram.SETIN_DATA("DSPSEIHIN_KUBUN", strFSEIHIN_KUBUN)         '製品区分
                        objTelegram.SETIN_DATA("DSPZAIKO_KUBUN", strFZAIKO_KUBUN)           '在庫区分
                        objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                        objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        objTelegram.SETIN_DATA("DSPTR_VOL", strFTR_VOL)                     '搬送管理量
                        objTelegram.SETIN_DATA("DSPTR_RES_VOL", strFTR_RES_VOL)             '搬送引当量
                        objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                        objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№






                        Dim strRET_STATE As String = ""
                        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
                        Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

                        strErrMsg = FRM_MSG_FRM205041_01
                        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
                        If udtSckSendRET = clsSocketClient.RetCode.OK Then
                            '(送信できた場合)
                            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                                '(正常終了の場合)
                                blnRet = True
                            End If
                        End If

                        If blnRet = False Then
                            MsgBox("【在庫削除失敗】[ﾊﾟﾚｯﾄID:" & objTRST_STOCK.ARYME(ii).FPALLET_ID & "][在庫ﾛｯﾄ№:" & objTRST_STOCK.ARYME(ii).FLOT_NO_STOCK & "]")
                        End If

                    Next

                End If

                gobjDb.Commit()
                gobjDb.BeginTrans()

            Catch ex As Exception
                MsgBox(ex.Message)
                gobjDb.RollBack()
                gobjDb.BeginTrans()
            End Try


            '****************************************************
            'ｺﾞﾐ削除
            '****************************************************
            Try
                gobjDb.Commit()
                gobjDb.BeginTrans()

                '****************************************************
                '全計画、報告削除
                '****************************************************
                'gobjDb.SQL = "TRUNCATE TABLE XPLN_REQUEST"
                'gobjDb.Execute()

                'gobjDb.SQL = "TRUNCATE TABLE XPLN_REQUEST_DTL"
                'gobjDb.Execute()


                'gobjDb.SQL = "TRUNCATE TABLE TRST_REPORT"
                'gobjDb.Execute()

                'gobjDb.SQL = "TRUNCATE TABLE TRST_REPORT_DTL"
                'gobjDb.Execute()

                ''****************************************************
                '在庫情報削除
                '****************************************************
                gobjDb.SQL = "TRUNCATE TABLE TRST_STOCK"
                gobjDb.Execute()

                '****************************************************
                '在庫引当情報削除
                '****************************************************
                gobjDb.SQL = "TRUNCATE TABLE TSTS_HIKIATE"
                gobjDb.Execute()

                '****************************************************
                '搬送指示QUE削除
                '****************************************************
                gobjDb.SQL = "TRUNCATE TABLE TPLN_CARRY_QUE"
                gobjDb.Execute()

                '****************************************************
                'ｼﾘｱﾙ関連付け削除
                '****************************************************
                gobjDb.SQL = "TRUNCATE TABLE TPRG_SERIAL"
                gobjDb.Execute()

                '****************************************************
                'ﾊﾟﾚｯﾄ情報削除
                '****************************************************
                gobjDb.SQL = "TRUNCATE TABLE TRST_PALLET"
                gobjDb.Execute()
       

                gobjDb.Commit()
                gobjDb.BeginTrans()

            Catch ex As Exception
                MsgBox(ex.Message)
                gobjDb.RollBack()
                gobjDb.BeginTrans()
            End Try




        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
#Region "  指定列在庫削除               ｸﾘｯｸ    "
    Private Sub cmd005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd005.Click
        Try

            Dim intRet As RetCode
            Dim blnRet As Boolean = False

            If MessageBox.Show("OK?", "", MessageBoxButtons.OKCancel) <> Windows.Forms.DialogResult.OK Then Return


            '****************************************************
            '在庫情報取得
            '****************************************************
            Dim strSQL As String = ""
            Dim objTRST_STOCK As New TBL_TRST_STOCK(gobjOwner, gobjDb, Nothing)
            strSQL &= " SELECT "
            strSQL &= "      *"
            strSQL &= " FROM "
            strSQL &= "    TRST_STOCK"
            strSQL &= " WHERE "
            strSQL &= "         1 = 1 "
            strSQL &= "     AND EXISTS("
            strSQL &= "                SELECT "
            strSQL &= "                   *"
            strSQL &= "                FROM "
            strSQL &= "                   TPRG_TRK_BUF"
            strSQL &= "                WHERE "
            strSQL &= "                       1 = 1 "
            strSQL &= "                   AND TPRG_TRK_BUF.FPALLET_ID = TRST_STOCK.FPALLET_ID"
            strSQL &= "                   AND TPRG_TRK_BUF.FRAC_RETU IN ( " & txtFRAC_RETU.Text & " ) "
            strSQL &= "                )"
            objTRST_STOCK.USER_SQL = strSQL
            intRet = objTRST_STOCK.GET_TRST_STOCK_USER()

            'intRet = objTRST_STOCK.GET_TRST_STOCK_ANY()

            'If intRet <> RetCode.OK Then
            '    Throw New Exception("在庫情報が見つかりません。")
            'End If

            Try
                gobjDb.Commit()
                gobjDb.BeginTrans()

                If intRet = RetCode.OK Then

                    '****************************************************
                    '在庫情報取得
                    '****************************************************
                    For ii As Integer = LBound(objTRST_STOCK.ARYME) To UBound(objTRST_STOCK.ARYME)
                        '(ﾙｰﾌﾟ:在庫数)


                        '*******************************************************
                        '進捗更新
                        '*******************************************************
                        lblProgress.Text = TO_STRING(ii) & "/" & TO_STRING(UBound(objTRST_STOCK.ARYME))
                        Me.Refresh()
                        System.Windows.Forms.Application.DoEvents()


                        '****************************************************
                        '在庫情報取得
                        '****************************************************
                        Dim strDIR_KUBUN As String = ""     '指示区分
                        Dim intCount As Integer

                        Dim objCheck As New TBL_TRST_STOCK(gobjOwner, gobjDb, Nothing)
                        objCheck.FPALLET_ID = objTRST_STOCK.ARYME(ii).FPALLET_ID    'ﾊﾟﾚｯﾄID
                        intCount = objCheck.GET_TRST_STOCK_COUNT()
                        If intCount <= 0 Then
                            '在庫削除の場合)
                            Continue For
                        End If
                        strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_DELETE           '指示区分(在庫情報削除)


                        '****************************************************
                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                        '****************************************************
                        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
                        objTPRG_TRK_BUF.FPALLET_ID = objTRST_STOCK.ARYME(ii).FPALLET_ID     'ﾊﾟﾚｯﾄID
                        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(False)
                        If intRet <> RetCode.OK Then
                            MsgBox("ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧが見つかりません。[ﾊﾟﾚｯﾄID:" & objTRST_STOCK.ARYME(ii).FPALLET_ID & "]")
                            Continue For
                        End If
                        'Select Case objTPRG_TRK_BUF.FTRK_BUF_NO
                        '    Case FTRK_BUF_NO_9002, FTRK_BUF_NO_9910
                        '    Case Else : Continue For
                        'End Select


                        '*******************************************************
                        'ｿｹｯﾄ送信処理
                        '*******************************************************
                        '========================================
                        ' 変数宣言
                        '========================================
                        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

                        'Dim strDIR_KUBUN As String = ""                             '処理区分
                        Dim strFBUF_NO As String = ""                               'ﾊﾞｯﾌｧ№
                        Dim strFBUF_ARRAY As String = ""                            'ﾊﾞｯﾌｧ配列№
                        Dim strFREMOVE_KIND As String = ""                          '禁止棚設定
                        Dim strFRAC_FORM As String = ""                             '棚形状種別
                        Dim strFRES_KIND As String = ""                             '引当状態

                        Dim strFHINMEI_CD As String = ""                            '品名ｺｰﾄﾞ
                        Dim strFLOT_NO As String = ""                               'ﾛｯﾄ№
                        Dim strFARRIVE_DT As String = ""                            '在庫発生日時
                        Dim strFIN_KUBUN As String = ""                             '入庫区分
                        Dim strFSEIHIN_KUBUN As String = ""                         '製品区分
                        Dim strFZAIKO_KUBUN As String = ""                          '在庫区分
                        Dim strFHORYU_KUBUN As String = ""                          '保留区分
                        Dim strFST_FM As String = ""                                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        Dim strFTR_VOL As String = ""                               '搬送管理量
                        Dim strFTR_RES_VOL As String = ""                           '搬送引当量
                        Dim strFPALLET_ID As String = ""                            'ﾊﾟﾚｯﾄID
                        Dim strFLOT_NO_STOCK As String = ""                         '在庫ﾛｯﾄ№
                        Dim strFLABEL_ID As String = ""                             'ﾗﾍﾞﾙID
                        Dim strFHASU_FLAG As String = ""                            '端数ﾌﾗｸﾞ
                        Dim strFSYUKKA_TO_CD As String = ""                         '出荷先ｺｰﾄﾞ
                        Dim strFSYUKKA_TO_NAME As String = ""                       '出荷先名称
                        Dim strFRAC_BUNRUI As String = ""                           '棚分類


                        '**********************************************************************************************
                        '↓↓↓ｼｽﾃﾑ固有

                        Dim strXDSPSEIZOU_DT As String = ""                         '製造年月日
                        Dim strXDSPLINE_NO As String = ""                           'ﾗｲﾝ№
                        Dim strXDSPPALLET_NO As String = ""                         'ﾊﾟﾚｯﾄ№
                        Dim strXDSPKENSA_KUBUN As String = ""                       '検査区分
                        Dim strXDSPAB_KUBUN As String = ""                          'AB区分
                        Dim strXDSPSYUKKA_KAHI As String = ""                       '出荷可否
                        Dim strXDSPSTRETCH_KUBUN As String = ""                     'ｽﾄﾚｯﾁ区分
                        Dim strXDSPHINSHITU_STS As String = ""                      '品質ｽﾃｰﾀｽ
                        Dim strXDSPLIMIT As String = ""                             '賞味期限
                        Dim strXDSPHORYU_NO As String = ""                          '保留№
                        Dim strXDSPHORYU_REASON As String = ""                      '保留理由
                        Dim strXASRS_IN_DT As String = ""                           '入庫日時
                        Dim strXDSPHORYU_DT As String = ""                          '保留年月日

                        '↑↑↑ｼｽﾃﾑ固有
                        '**********************************************************************************************


                        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ


                        strFBUF_NO = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO)                 'ﾊﾞｯﾌｧ№
                        strFBUF_ARRAY = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY)           'ﾊﾞｯﾌｧ配列№
                        strFREMOVE_KIND = TO_STRING(objTPRG_TRK_BUF.FREMOVE_KIND)           '禁止棚設定
                        strFRAC_FORM = TO_STRING(objTPRG_TRK_BUF.FRAC_FORM)                 '棚形状種別
                        strFRES_KIND = TO_STRING(objTPRG_TRK_BUF.FRES_KIND)                 '引当状態

                        strFHINMEI_CD = TO_STRING(objTRST_STOCK.ARYME(ii).FHINMEI_CD)       '品名ｺｰﾄﾞ
                        strFLOT_NO = TO_STRING(objTRST_STOCK.ARYME(ii).FLOT_NO)             'ﾛｯﾄ№
                        strFARRIVE_DT = TO_STRING(objTRST_STOCK.ARYME(ii).FARRIVE_DT)       '在庫発生日時
                        strFIN_KUBUN = TO_STRING(objTRST_STOCK.ARYME(ii).FIN_KUBUN)         '入庫区分
                        strFSEIHIN_KUBUN = TO_STRING(objTRST_STOCK.ARYME(ii).FSEIHIN_KUBUN) '製品区分
                        strFZAIKO_KUBUN = TO_STRING(objTRST_STOCK.ARYME(ii).FZAIKO_KUBUN)   '在庫区分
                        strFHORYU_KUBUN = TO_STRING(objTRST_STOCK.ARYME(ii).FHORYU_KUBUN)   '保留区分
                        strFST_FM = TO_STRING(objTRST_STOCK.ARYME(ii).FST_FM)               '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        strFTR_VOL = TO_STRING(objTRST_STOCK.ARYME(ii).FTR_VOL)             '搬送管理量
                        strFTR_RES_VOL = TO_STRING(objTRST_STOCK.ARYME(ii).FTR_RES_VOL)     '搬送引当量
                        strFPALLET_ID = TO_STRING(objTRST_STOCK.ARYME(ii).FPALLET_ID)       'ﾊﾟﾚｯﾄID
                        strFLOT_NO_STOCK = TO_STRING(objTRST_STOCK.ARYME(ii).FLOT_NO_STOCK) '在庫ﾛｯﾄ№


                        objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO)                 'ﾊﾞｯﾌｧ№
                        objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY)           'ﾊﾞｯﾌｧ配列№
                        objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                        objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                        objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態

                        objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
                        objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                        objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                        objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                        objTelegram.SETIN_DATA("DSPSEIHIN_KUBUN", strFSEIHIN_KUBUN)         '製品区分
                        objTelegram.SETIN_DATA("DSPZAIKO_KUBUN", strFZAIKO_KUBUN)           '在庫区分
                        objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                        objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        objTelegram.SETIN_DATA("DSPTR_VOL", strFTR_VOL)                     '搬送管理量
                        objTelegram.SETIN_DATA("DSPTR_RES_VOL", strFTR_RES_VOL)             '搬送引当量
                        objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                        objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№






                        Dim strRET_STATE As String = ""
                        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
                        Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

                        strErrMsg = FRM_MSG_FRM205041_01
                        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
                        If udtSckSendRET = clsSocketClient.RetCode.OK Then
                            '(送信できた場合)
                            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                                '(正常終了の場合)
                                blnRet = True
                            End If
                        End If

                        If blnRet = False Then
                            MsgBox("【在庫削除失敗】[ﾊﾟﾚｯﾄID:" & objTRST_STOCK.ARYME(ii).FPALLET_ID & "][在庫ﾛｯﾄ№:" & objTRST_STOCK.ARYME(ii).FLOT_NO_STOCK & "]")
                        End If

                    Next

                End If

                gobjDb.Commit()
                gobjDb.BeginTrans()

            Catch ex As Exception
                MsgBox(ex.Message)
                gobjDb.RollBack()
                gobjDb.BeginTrans()
            End Try






        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region


#Region "  在庫移行前ﾁｪｯｸ               ｸﾘｯｸ    "
    Private Sub cmd002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd002.Click
        Try
            Call ZaikoIkou(False)
        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
#Region "  在庫移行                     ｸﾘｯｸ    "
    Private Sub cmd003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd003.Click
        Try
            Call ZaikoIkou(True)
        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
#Region "  SHIP在庫ﾃﾞｰﾀ更新             ｸﾘｯｸ    "
    ' ''Private Sub cmd004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd004.Click
    ' ''    Try
    ' ''        Call SHIP_UPDATE()
    ' ''    Catch ex As Exception
    ' ''        Call gobjComFuncFRM.ComError_frm(ex)
    ' ''        MsgBox(ex.Message)
    ' ''    End Try
    ' ''End Sub
#End Region

#Region "  在庫移行処理                         "
    '''***********************************************************************************************************************************
    ''' <summary>
    ''' 在庫移行処理
    ''' </summary>
    ''' <param name="blnSockSend">
    ''' ｿｹｯﾄ送信ﾌﾗｸﾞ
    ''' True :ｿｹｯﾄを送信する
    ''' False:ｿｹｯﾄを送信しない事によって事前にｴﾗｰを感知出来る
    ''' </param>
    ''' <remarks></remarks>
    '''***********************************************************************************************************************************
    Private Sub ZaikoIkou(ByVal blnSockSend As Boolean)

        Try

            Dim objStock As New System.Collections.ArrayList()          'Stockﾌｧｲﾙ      ﾃﾞｰﾀﾌｧｲﾙｵﾌﾞｼﾞｪｸﾄ
            Dim strcsvFileName01 As String = txtReadFile01.Text         'Stockﾌｧｲﾙ名
            Dim objTextFieldParser01 As New FileIO.TextFieldParser(strcsvFileName01, System.Text.Encoding.GetEncoding(932))     'Shift JISで読み込む

            Try
                Dim intRet As RetCode
                Dim blnRet As Boolean = False
                Dim dtmNow As Date = Now
                Dim strSQL As String = ""

                '*******************************************************
                '色々設定
                '*******************************************************
                'ﾃﾞﾘﾐﾀ設定
                objTextFieldParser01.TextFieldType = FileIO.FieldType.Delimited
                objTextFieldParser01.Delimiters = New String() {vbTab}
                'ﾌｨｰﾙﾄﾞを"で囲み、改行文字、区切り文字を含めることができるか
                objTextFieldParser01.HasFieldsEnclosedInQuotes = False
                'ﾌｨｰﾙﾄﾞの前後からｽﾍﾟｰｽを削除する
                objTextFieldParser01.TrimWhiteSpace = False


                '*******************************************************
                'ﾃｷｽﾄﾌｧｲﾙ読込
                '*******************************************************
                While Not objTextFieldParser01.EndOfData
                    '(ﾙｰﾌﾟ:ﾚｺｰﾄﾞ数)
                    Dim strfields As String() = objTextFieldParser01.ReadFields()       'ﾌｨｰﾙﾄﾞを読み込む
                    objStock.Add(strfields)                                             '保存
                End While


                '*******************************************************
                'ｿｹｯﾄ送信処理
                '*******************************************************
                Dim strSendTel() As String = Nothing        '送信電文配列


                '*******************************************************
                '開始宣言
                '*******************************************************
                gobjComFuncFRM.AddToLog_frm("在庫移行開始:" & Format(Now, "yyyy/MM/dd HH:mm:ss"), AddToLog_D_ErrorType.USER_LOG, "")

                For ii As Integer = 0 To objStock.Count - 1
                    '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)

                    '*******************************************************
                    '進捗更新
                    '*******************************************************
                    lblProgress.Text = TO_STRING(ii) & "/" & TO_STRING(objStock.Count - 1)
                    Me.Refresh()
                    System.Windows.Forms.Application.DoEvents()


                    '*******************************************************
                    '正しいCSVかﾁｪｯｸ
                    '*******************************************************
                    If UBound(objStock.Item(ii)) <> 3 Then Continue For

                    '*******************************************************
                    '必須 ﾁｪｯｸ
                    '*******************************************************
                    If TO_STRING(objStock.Item(ii)(DKA8300_MAINKEY_INDEX)) = "" Then
                        Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 列連段は必須です。")
                    End If

                    If TO_STRING(objStock.Item(ii)(DKA8300_SUBKEY1_INDEX)) = "" Then
                        Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 引当ｷｰは必須です。")
                    End If

                    ' ''If TO_STRING(objStock.Item(ii)(DKA8300_SUBKEY2_INDEX)) = "" Then
                    ' ''    Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 問合せｷｰは必須です。")
                    ' ''End If

                    If TO_STRING(objStock.Item(ii)(DKA8300_DATA1_INDEX)) = "" Then
                        Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 ﾃﾞｰﾀは必須です。")
                    End If

                    '*******************************************************
                    '長さ ﾁｪｯｸ
                    '*******************************************************
                    If Len(objStock.Item(ii)(DKA8300_MAINKEY_INDEX)) <> DKA8300_MAINKEY_LENGTH Then
                        Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 列連段の長さが一致しません。")
                    End If

                    If Len(objStock.Item(ii)(DKA8300_SUBKEY1_INDEX)) <> DKA8300_SUBKEY1_LENGTH Then
                        Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 引当ｷｰの長さが一致しません。")
                    End If

                    ' ''If Len(objStock.Item(ii)(DKA8300_SUBKEY2_INDEX)) <> DKA8300_SUBKEY2_LENGTH Then
                    ' ''    Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 問合せｷｰの長さが一致しません。")
                    ' ''End If

                    If Len(objStock.Item(ii)(DKA8300_DATA1_INDEX)) <> DKA8300_DATA1_LENGTH Then
                        Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 ﾃﾞｰﾀの長さが一致しません。")
                    End If

                    '*******************************************************
                    'ﾃﾞｰﾀ取得
                    '*******************************************************
                    Dim intIndex As Integer = 0

                    Dim strMAINKEY_FRAC_RETU As String = ""                     '列
                    Dim strMAINKEY_FRAC_REN As String = ""                      '連
                    Dim strMAINKEY_FRAC_DAN As String = ""                      '段

                    Dim strSUBKEY1_XHINMEI_CD As String = ""                    '品名ｺｰﾄﾞ
                    Dim strSUBKEY1_FREMOVE_KIND As String = ""                  'ﾌﾞﾛｯｸ状態
                    Dim strSUBKEY1_FIN_KUBUN As String = ""                     '検索優先順
                    Dim strSUBKEY1_FBUF_IN_DT As String = ""                    '入庫年月日
                    Dim strSUBKEY1_XPROD_LINE As String = ""                    '生産ﾗｲﾝNo.
                    Dim strSUBKEY1_FBUF_IN_DT_TIME As String = ""               '入庫時分秒

                    Dim strDATA1_FREMOVE_KIND As String = ""                    '棚禁止詳細
                    Dim strDATA1_TANA1_FBUF_IN_DT As String = ""                '棚1 入庫年月日
                    Dim strDATA1_TANA1_FBUF_IN_DT_TIME As String = ""           '棚1 入庫時分秒
                    Dim strDATA1_TANA1_FTR_VOL As String = ""                   '棚1 在庫梱数
                    Dim strDATA1_TANA1_FRES_KIND As String = ""                 '棚1 引当状態
                    Dim strDATA1_TANA1_FHASUU_FLAG As String = ""               '棚1 端数ﾌﾗｸﾞ
                    Dim strDATA1_TANA2_FBUF_IN_DT As String = ""                '棚2 入庫年月日
                    Dim strDATA1_TANA2_FBUF_IN_DT_TIME As String = ""           '棚2 入庫時分秒
                    Dim strDATA1_TANA2_FTR_VOL As String = ""                   '棚2 在庫梱数
                    Dim strDATA1_TANA2_FRES_KIND As String = ""                 '棚2 引当状態
                    Dim strDATA1_TANA2_FHASUU_FLAG As String = ""               '棚2 端数ﾌﾗｸﾞ
                    Dim strDATA1_TANA3_FBUF_IN_DT As String = ""                '棚3 入庫年月日
                    Dim strDATA1_TANA3_FBUF_IN_DT_TIME As String = ""           '棚3 入庫時分秒
                    Dim strDATA1_TANA3_FTR_VOL As String = ""                   '棚3 在庫梱数
                    Dim strDATA1_TANA3_FRES_KIND As String = ""                 '棚3 引当状態
                    Dim strDATA1_TANA3_FHASUU_FLAG As String = ""               '棚3 端数ﾌﾗｸﾞ
                    Dim strDATA1_TANA4_FBUF_IN_DT As String = ""                '棚4 入庫年月日
                    Dim strDATA1_TANA4_FBUF_IN_DT_TIME As String = ""           '棚4 入庫時分秒
                    Dim strDATA1_TANA4_FTR_VOL As String = ""                   '棚4 在庫梱数
                    Dim strDATA1_TANA4_FRES_KIND As String = ""                 '棚4 引当状態
                    Dim strDATA1_TANA4_FHASUU_FLAG As String = ""               '棚4 端数ﾌﾗｸﾞ

                    Dim strDATA1_FUPDATE_DT As String = ""                      '最終更新日

                    '(MAINKEY)
                    Dim strMAINKEY As String = objStock.Item(ii)(DKA8300_MAINKEY_INDEX)
                    strMAINKEY_FRAC_RETU = strMAINKEY.Substring(intIndex, MAINKEY_FRAC_RETU)    '列
                    intIndex = intIndex + MAINKEY_FRAC_RETU
                    strMAINKEY_FRAC_REN = strMAINKEY.Substring(intIndex, MAINKEY_FRAC_REN)      '連
                    intIndex = intIndex + MAINKEY_FRAC_REN
                    strMAINKEY_FRAC_DAN = strMAINKEY.Substring(intIndex, MAINKEY_FRAC_DAN)      '段
                    intIndex = intIndex + MAINKEY_FRAC_DAN

                    '(SUBKEY)
                    intIndex = 0
                    Dim strSUBKEY1 As String = objStock.Item(ii)(DKA8300_SUBKEY1_INDEX)
                    strSUBKEY1_XHINMEI_CD = strSUBKEY1.Substring(intIndex, SUBKEY1_XHINMEI_CD)          '品名ｺｰﾄﾞ
                    intIndex = intIndex + SUBKEY1_XHINMEI_CD
                    strSUBKEY1_FREMOVE_KIND = strSUBKEY1.Substring(intIndex, SUBKEY1_FREMOVE_KIND)      'ﾌﾞﾛｯｸ状態
                    intIndex = intIndex + SUBKEY1_FREMOVE_KIND
                    intIndex = intIndex + SUBKEY1_VAL3                                                  '棚格納状態(未使用)
                    strSUBKEY1_FIN_KUBUN = strSUBKEY1.Substring(intIndex, SUBKEY1_FIN_KUBUN)            '検索優先順
                    intIndex = intIndex + SUBKEY1_FIN_KUBUN
                    strSUBKEY1_FBUF_IN_DT = strSUBKEY1.Substring(intIndex, SUBKEY1_FBUF_IN_DT)          '入庫年月日
                    intIndex = intIndex + SUBKEY1_FBUF_IN_DT
                    strSUBKEY1_XPROD_LINE = strSUBKEY1.Substring(intIndex, SUBKEY1_XPROD_LINE)          '生産ﾗｲﾝNo.
                    intIndex = intIndex + SUBKEY1_XPROD_LINE
                    strSUBKEY1_FBUF_IN_DT_TIME = strSUBKEY1.Substring(intIndex, SUBKEY1_FBUF_IN_DT_TIME) '入庫時分秒
                    intIndex = intIndex + SUBKEY1_FBUF_IN_DT_TIME

                    '(DATA1)
                    intIndex = 0
                    Dim strDATA1 As String = objStock.Item(ii)(DKA8300_DATA1_INDEX)
                    intIndex = intIndex + DATA1_VAL1                                                    '混載数
                    intIndex = intIndex + DATA1_VAL2                                                    '棚ﾌﾞﾛｯｸ在庫梱数
                    intIndex = intIndex + DATA1_VAL3                                                    '棚ﾌﾞﾛｯｸ引当梱数
                    intIndex = intIndex + DATA1_VAL4                                                    '商品区分
                    strDATA1_FREMOVE_KIND = strDATA1.Substring(intIndex, DATA1_FREMOVE_KIND)            '棚禁止詳細
                    intIndex = intIndex + DATA1_FREMOVE_KIND

                    strDATA1_TANA1_FBUF_IN_DT = strDATA1.Substring(intIndex, DATA1_TANA1_FBUF_IN_DT)    '棚1 入庫年月日
                    intIndex = intIndex + DATA1_TANA1_FBUF_IN_DT
                    strDATA1_TANA1_FBUF_IN_DT_TIME = strDATA1.Substring(intIndex, DATA1_TANA1_FBUF_IN_DT_TIME)    '棚1 入庫時分秒
                    intIndex = intIndex + DATA1_TANA1_FBUF_IN_DT_TIME
                    strDATA1_TANA1_FTR_VOL = strDATA1.Substring(intIndex, DATA1_TANA1_FTR_VOL)          '棚1 在棚梱数
                    intIndex = intIndex + DATA1_TANA1_FTR_VOL
                    strDATA1_TANA1_FRES_KIND = strDATA1.Substring(intIndex, DATA1_TANA1_FRES_KIND)      '棚1 引当区分
                    intIndex = intIndex + DATA1_TANA1_FRES_KIND
                    strDATA1_TANA1_FHASUU_FLAG = strDATA1.Substring(intIndex, DATA1_TANA1_FHASU_FLAG)   '棚1 棚区分
                    intIndex = intIndex + DATA1_TANA1_FHASU_FLAG

                    strDATA1_TANA2_FBUF_IN_DT = strDATA1.Substring(intIndex, DATA1_TANA2_FBUF_IN_DT)    '棚2 入庫年月日
                    intIndex = intIndex + DATA1_TANA2_FBUF_IN_DT
                    strDATA1_TANA2_FBUF_IN_DT_TIME = strDATA1.Substring(intIndex, DATA1_TANA2_FBUF_IN_DT_TIME)    '棚2 入庫時分秒
                    intIndex = intIndex + DATA1_TANA2_FBUF_IN_DT_TIME
                    strDATA1_TANA2_FTR_VOL = strDATA1.Substring(intIndex, DATA1_TANA2_FTR_VOL)          '棚2 在棚梱数
                    intIndex = intIndex + DATA1_TANA2_FTR_VOL
                    strDATA1_TANA2_FRES_KIND = strDATA1.Substring(intIndex, DATA1_TANA2_FRES_KIND)      '棚2 引当区分
                    intIndex = intIndex + DATA1_TANA2_FRES_KIND
                    strDATA1_TANA2_FHASUU_FLAG = strDATA1.Substring(intIndex, DATA1_TANA2_FHASU_FLAG)   '棚2 棚区分
                    intIndex = intIndex + DATA1_TANA2_FHASU_FLAG

                    strDATA1_TANA3_FBUF_IN_DT = strDATA1.Substring(intIndex, DATA1_TANA3_FBUF_IN_DT)    '棚3 入庫年月日
                    intIndex = intIndex + DATA1_TANA3_FBUF_IN_DT
                    strDATA1_TANA3_FBUF_IN_DT_TIME = strDATA1.Substring(intIndex, DATA1_TANA3_FBUF_IN_DT_TIME)    '棚3 入庫時分秒
                    intIndex = intIndex + DATA1_TANA3_FBUF_IN_DT_TIME
                    strDATA1_TANA3_FTR_VOL = strDATA1.Substring(intIndex, DATA1_TANA3_FTR_VOL)          '棚3 在棚梱数
                    intIndex = intIndex + DATA1_TANA3_FTR_VOL
                    strDATA1_TANA3_FRES_KIND = strDATA1.Substring(intIndex, DATA1_TANA3_FRES_KIND)      '棚3 引当区分
                    intIndex = intIndex + DATA1_TANA3_FRES_KIND
                    strDATA1_TANA3_FHASUU_FLAG = strDATA1.Substring(intIndex, DATA1_TANA3_FHASU_FLAG)   '棚3 棚区分
                    intIndex = intIndex + DATA1_TANA3_FHASU_FLAG

                    strDATA1_TANA4_FBUF_IN_DT = strDATA1.Substring(intIndex, DATA1_TANA4_FBUF_IN_DT)    '棚4 入庫年月日
                    intIndex = intIndex + DATA1_TANA4_FBUF_IN_DT
                    strDATA1_TANA4_FBUF_IN_DT_TIME = strDATA1.Substring(intIndex, DATA1_TANA4_FBUF_IN_DT_TIME)    '棚4 入庫時分秒
                    intIndex = intIndex + DATA1_TANA4_FBUF_IN_DT_TIME
                    strDATA1_TANA4_FTR_VOL = strDATA1.Substring(intIndex, DATA1_TANA4_FTR_VOL)          '棚4 在棚梱数
                    intIndex = intIndex + DATA1_TANA4_FTR_VOL
                    strDATA1_TANA4_FRES_KIND = strDATA1.Substring(intIndex, DATA1_TANA4_FRES_KIND)      '棚4 引当区分
                    intIndex = intIndex + DATA1_TANA4_FRES_KIND
                    strDATA1_TANA4_FHASUU_FLAG = strDATA1.Substring(intIndex, DATA1_TANA4_FHASU_FLAG)   '棚4 棚区分
                    intIndex = intIndex + DATA1_TANA4_FHASU_FLAG
                    intIndex = intIndex + DATA1_VAL26                                                   '出荷指示済PL数(未使用)
                    strDATA1_FUPDATE_DT = strDATA1.Substring(intIndex, DATA1_FUPDATE_DT)                '更新日
                    intIndex = intIndex + DATA1_FUPDATE_DT

                    '========================================
                    ' 変数宣言
                    '========================================
                    Dim strDIR_KUBUN As String = ""                             '処理区分

                    Dim strFBUF_NO1 As String = ""                               'ﾊﾞｯﾌｧ№1
                    Dim strFBUF_ARRAY1 As String = ""                            'ﾊﾞｯﾌｧ配列№1
                    Dim strFBUF_NO2 As String = ""                               'ﾊﾞｯﾌｧ№2
                    Dim strFBUF_ARRAY2 As String = ""                            'ﾊﾞｯﾌｧ配列№2
                    Dim strFBUF_NO3 As String = ""                               'ﾊﾞｯﾌｧ№3
                    Dim strFBUF_ARRAY3 As String = ""                            'ﾊﾞｯﾌｧ配列№3
                    Dim strFBUF_NO4 As String = ""                               'ﾊﾞｯﾌｧ№4
                    Dim strFBUF_ARRAY4 As String = ""                            'ﾊﾞｯﾌｧ配列№4

                    Dim strFREMOVE_KIND As String = ""                          '禁止棚設定
                    Dim strFRAC_FORM As String = ""                             '棚形状種別
                    Dim strFRES_KIND As String = ""                             '引当状態
                    Dim strFHINMEI_CD As String = ""                            '品名記号
                    Dim strFLOT_NO As String = ""                               'ﾛｯﾄ№
                    Dim strFARRIVE_DT As String = ""                            '在庫発生日時
                    Dim strFIN_KUBUN As String = ""                             '入庫区分
                    Dim strFSEIHIN_KUBUN As String = ""                         '製品区分
                    Dim strFZAIKO_KUBUN As String = ""                          '在庫区分
                    Dim strFHORYU_KUBUN As String = ""                          '保留区分
                    Dim strFST_FM As String = ""                                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    Dim strFTR_VOL As String = ""                               '搬送管理量
                    Dim strFTR_RES_VOL As String = ""                           '搬送引当量
                    Dim strFPALLET_ID As String = ""                            'ﾊﾟﾚｯﾄID
                    Dim strFLOT_NO_STOCK As String = ""                         '在庫ﾛｯﾄ№
                    Dim strFLABEL_ID As String = ""                             'ﾗﾍﾞﾙID
                    Dim strFHASU_FLAG As String = ""                            '端数ﾌﾗｸﾞ
                    Dim strFSYUKKA_TO_CD As String = ""                         '出荷先ｺｰﾄﾞ
                    Dim strFSYUKKA_TO_NAME As String = ""                       '出荷先名称
                    Dim strFRAC_BUNRUI As String = ""                           '棚分類
                    Dim strFBUF_IN_DT As String = ""                            'ﾊﾞｯﾌｧ入日時
                    Dim strXTANA_BLOCK As String = ""                           '棚ﾌﾞﾛｯｸ
                    Dim strXTANA_BLOCK_DTL As String = ""                       '棚ﾌﾞﾛｯｸ詳細
                    Dim strXTANA_BLOCK_STS As String = ""                       '棚ﾌﾞﾛｯｸ状態
                    Dim strXPROD_LINE As String = ""                            '生産ﾗｲﾝNo.
                    Dim strXKENSA_KUBUN As String = ""                          '検査区分
                    Dim strXKENPIN_KUBUN As String = ""                         '検品区分
                    Dim strFUPDATE_DT As String = ""                            '更新日時

                    Dim blnTANA1_KARA As Boolean = False                        '棚1 空棚ﾌﾗｸﾞ
                    Dim blnTANA2_KARA As Boolean = False                        '棚2 空棚ﾌﾗｸﾞ
                    Dim blnTANA3_KARA As Boolean = False                        '棚3 空棚ﾌﾗｸﾞ
                    Dim blnTANA4_KARA As Boolean = False                        '棚4 空棚ﾌﾗｸﾞ

                    Dim blnFREMOVE_KIND As Boolean = False                      '棚禁止ﾌﾗｸﾞ



                    '========================================
                    ' 棚 共通ﾃﾞｰﾀ確認
                    '========================================
                    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
                    Dim objTPRG_TRK_BUF As TBL_TPRG_TRK_BUF
                    Dim objTBL_TMST_ITEM As TBL_TMST_ITEM


                    '*******************************************************
                    ' 27列目かどうかで処理分岐
                    '*******************************************************
                    If TO_INTEGER(strMAINKEY_FRAC_RETU) <> 27 Then
                        '*******************************************************
                        '
                        ' 27列目以外の場合
                        '
                        '*******************************************************

                        '*******************************************************
                        '棚禁止設定 確認
                        '*******************************************************
                        If strDATA1_FREMOVE_KIND.Substring(0, 1) = "1" Then
                            '(棚禁止詳細が1のとき=禁止設定)
                            If TO_INTEGER(strSUBKEY1_FREMOVE_KIND) = 2 Or _
                               TO_INTEGER(strSUBKEY1_FREMOVE_KIND) = 3 Then
                                '(棚禁止の場合)
                                blnFREMOVE_KIND = True
                            Else
                                Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。" & vbCrLf & "棚禁止設定に誤りがあります" & "[ﾌﾞﾛｯｸ状態:" & strSUBKEY1_FREMOVE_KIND & "]" & " [棚禁止詳細:" & strDATA1_FREMOVE_KIND & "]")
                            End If
                        End If


                        '*******************************************************
                        '品名ｺｰﾄﾞ取得
                        '*******************************************************
                        If strSUBKEY1_XHINMEI_CD.Trim <> "" Then
                            '(品目ｺｰﾄﾞが設定されている場合)
                            objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                            objTBL_TMST_ITEM.XHINMEI_CD = strSUBKEY1_XHINMEI_CD.Trim
                            intRet = objTBL_TMST_ITEM.GET_TMST_ITEM()
                            If intRet <> RetCode.OK Then
                                Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。" & vbCrLf & "該当する品目ｺｰﾄﾞがありません" & "[品目ｺｰﾄﾞ:" & strSUBKEY1_XHINMEI_CD & "]")
                            End If

                            strFHINMEI_CD = TO_STRING(objTBL_TMST_ITEM.FHINMEI_CD)          '品名ｺｰﾄﾞ
                            objTBL_TMST_ITEM.Close()
                        Else
                            '(品目ｺｰﾄﾞが設定されていない場合 = 全て空)
                            blnTANA1_KARA = True
                            blnTANA2_KARA = True
                            blnTANA3_KARA = True
                            blnTANA4_KARA = True
                        End If


                        '========================================
                        '
                        ' 棚1 電文作成
                        '
                        '========================================
                        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

                        '*******************************************************
                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ取得
                        '*******************************************************
                        objTPRG_TRK_BUF = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
                        '(奥 偶数)
                        objTPRG_TRK_BUF.FRAC_RETU = TO_INTEGER(strMAINKEY_FRAC_RETU)    '列
                        objTPRG_TRK_BUF.FRAC_REN = TO_INTEGER(strMAINKEY_FRAC_REN)   '連
                        objTPRG_TRK_BUF.FRAC_DAN = TO_INTEGER(strMAINKEY_FRAC_DAN)      '段
                        objTPRG_TRK_BUF.FRAC_EDA = 1                                    '枝
                        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                     '取得
                        If intRet <> RetCode.OK Then
                            Throw New Exception(TO_STRING(ii + 1) & "行目棚1でｴﾗｰ発生。" & vbCrLf & ERRMSG_NOTFOUND_BUF & "[列連段枝:" & objTPRG_TRK_BUF.FRAC_RETU & "-" & objTPRG_TRK_BUF.FRAC_REN & "-" & objTPRG_TRK_BUF.FRAC_DAN & "-" & objTPRG_TRK_BUF.FRAC_EDA & "]")
                        End If

                        strFBUF_NO1 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO)                'ﾊﾞｯﾌｧ№1
                        strFBUF_ARRAY1 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY)          'ﾊﾞｯﾌｧ配列№1
                        strFRAC_FORM = TO_STRING(objTPRG_TRK_BUF.FRAC_FORM)                 '棚形状種別
                        strFRAC_BUNRUI = TO_STRING(objTPRG_TRK_BUF.FRAC_BUNRUI)             '棚分類
                        strXTANA_BLOCK = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK)             '棚ﾌﾞﾛｯｸ
                        strXTANA_BLOCK_DTL = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_DTL)     '棚ﾌﾞﾛｯｸ詳細
                        strXTANA_BLOCK_STS = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_STS)     '棚ﾌﾞﾛｯｸ状態
                        strFREMOVE_KIND = TO_STRING(objTPRG_TRK_BUF.FREMOVE_KIND)           '禁止状態

                        objTPRG_TRK_BUF.Close()

                        '*******************************************************
                        '空棚か確認
                        '*******************************************************
                        If blnTANA1_KARA = False Then
                            '(空棚の場合、確認不要)
                            If strDATA1_TANA1_FBUF_IN_DT.Trim = "" Or _
                               TO_INTEGER(strDATA1_TANA1_FBUF_IN_DT) = 0 Then
                                '(棚1の入庫年月日が設定されていない場合)
                                blnTANA1_KARA = True
                            End If
                        End If

                        If blnTANA1_KARA = True Then
                            '(在庫なし)

                            strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK         '処理区分
                            'ﾊﾞｯﾌｧ№
                            'ﾊﾞｯﾌｧ配列№
                            If strFREMOVE_KIND <> "9" Then                              '禁止棚設定
                                '(無効棚ではない場合)
                                If blnFREMOVE_KIND = True Then
                                    strFREMOVE_KIND = FREMOVE_KIND_SON
                                Else
                                    strFREMOVE_KIND = FREMOVE_KIND_SNORMAL
                                End If
                            End If
                            '棚形状種別
                            strFRES_KIND = FRES_KIND_SAKI                               '引当状態=空
                            ' ''strFHINMEI_CD = ""                                          '品名ｺｰﾄﾞ
                            strFLOT_NO = ""                                             'ﾛｯﾄNo.
                            strFARRIVE_DT = ""                                          '在庫発生日時
                            strFIN_KUBUN = ""                                           '入庫区分
                            strFHORYU_KUBUN = ""                                        '保留区分
                            strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            strFTR_VOL = ""                                             '数量
                            '棚分類
                            '棚ﾌﾞﾛｯｸ
                            '棚ﾌﾞﾛｯｸ詳細
                            '棚ﾌﾞﾛｯｸ状態

                            objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                            objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO1)                'ﾊﾞｯﾌｧ№1
                            objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY1)          'ﾊﾞｯﾌｧ配列№1
                            objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                            objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                            objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態
                            objTelegram.SETIN_DATA("DSPHINMEI_CD", "")                          '品名ｺｰﾄﾞ
                            objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                            objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                            objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                            objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTR_VOL", strFTR_VOL)                     '搬送管理量
                            ' ''objTelegram.SETIN_DATA("DSPTR_RES_VOL", "0")                        '搬送引当量
                            ' ''objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                            ' ''objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
                            ' ''objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
                            objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK", strXTANA_BLOCK)            '棚ﾌﾞﾛｯｸ
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_DTL", strXTANA_BLOCK_DTL)    '棚ﾌﾞﾛｯｸ詳細
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_STS", strXTANA_BLOCK_STS)    '棚ﾌﾞﾛｯｸ状態


                        ElseIf blnTANA1_KARA = False Then
                            '(在庫情報がある場合)

                            If strFREMOVE_KIND = "9" Then
                                '(無効棚である場合)
                                Throw New Exception(TO_STRING(ii + 1) & "行目棚1でｴﾗｰ発生。" & vbCrLf & "在庫の追加先が無効棚です。" & "[列連段枝:" & objTPRG_TRK_BUF.FRAC_RETU & "-" & objTPRG_TRK_BUF.FRAC_REN & "-" & objTPRG_TRK_BUF.FRAC_DAN & "-" & objTPRG_TRK_BUF.FRAC_EDA & "]")
                            End If

                            strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_INSERT               '処理区分
                            'ﾊﾞｯﾌｧ№
                            'ﾊﾞｯﾌｧ配列№
                            If blnFREMOVE_KIND = True Then                              '禁止設定
                                strFREMOVE_KIND = FREMOVE_KIND_SON
                            Else
                                strFREMOVE_KIND = FREMOVE_KIND_SNORMAL
                            End If
                            '棚形状種別
                            strFRES_KIND = FRES_KIND_SZAIKO                             '引当状態=在庫
                            ' ''strFHINMEI_CD = strFHINMEI_CD                               '品名ｺｰﾄﾞ
                            strFLOT_NO = strSUBKEY1_XPROD_LINE.Trim & strSUBKEY1_FBUF_IN_DT     'ﾛｯﾄNo.(生産ﾗｲﾝ + 入庫年月日)
                            '在庫年月日
                            strFARRIVE_DT = strSUBKEY1_FBUF_IN_DT.Substring(0, 4) & "/" & strSUBKEY1_FBUF_IN_DT.Substring(4, 2) & "/" & strSUBKEY1_FBUF_IN_DT.Substring(6, 2) & " " & _
                                            strSUBKEY1_FBUF_IN_DT_TIME.Substring(0, 2) & ":" & strSUBKEY1_FBUF_IN_DT_TIME.Substring(2, 2) & ":" & strSUBKEY1_FBUF_IN_DT_TIME.Substring(4, 2)
                            '入庫区分
                            If strSUBKEY1_FIN_KUBUN = "91" Then
                                '(持戻り品)
                                strFIN_KUBUN = FIN_KUBUN_J04

                            ElseIf strSUBKEY1_FIN_KUBUN = "92" Then
                                '(再入棚品)
                                strFIN_KUBUN = FIN_KUBUN_J06

                            ElseIf strSUBKEY1_FIN_KUBUN = "93" Then
                                '(外部品)
                                strFIN_KUBUN = FIN_KUBUN_J02

                            ElseIf strSUBKEY1_FIN_KUBUN = "98" Then
                                '(生産入庫品)
                                strFIN_KUBUN = FIN_KUBUN_J01

                            ElseIf strSUBKEY1_FIN_KUBUN = "99" Then
                                '(その他)
                                strFIN_KUBUN = FIN_KUBUN_J05

                            End If
                            strFHORYU_KUBUN = FHORYU_KUBUN_SNORMAL                      '保留区分=通常品
                            strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            strFTR_VOL = strDATA1_TANA1_FTR_VOL                         '搬送管理量(棚1)

                            If TO_INTEGER(strDATA1_TANA1_FHASUU_FLAG) = 1 Then          '端数ﾌﾗｸﾞ(棚1)
                                '(端数の場合)
                                strFHASU_FLAG = "1"

                            ElseIf TO_INTEGER(strDATA1_TANA1_FHASUU_FLAG) = 2 Then
                                '(ﾌﾙPLの場合)
                                strFHASU_FLAG = "0"

                            End If

                            '棚分類
                            'ﾊﾞｯﾌｧ入日時(棚1)
                            strFBUF_IN_DT = strDATA1_TANA1_FBUF_IN_DT.Substring(0, 4) & "/" & strDATA1_TANA1_FBUF_IN_DT.Substring(4, 2) & "/" & strDATA1_TANA1_FBUF_IN_DT.Substring(6, 2) & " " & _
                                            strDATA1_TANA1_FBUF_IN_DT_TIME.Substring(0, 2) & ":" & strDATA1_TANA1_FBUF_IN_DT_TIME.Substring(2, 2) & ":" & strDATA1_TANA1_FBUF_IN_DT_TIME.Substring(4, 2)
                            '棚ﾌﾞﾛｯｸ
                            '棚ﾌﾞﾛｯｸ詳細
                            '棚ﾌﾞﾛｯｸ状態
                            strXPROD_LINE = strSUBKEY1_XPROD_LINE.Trim                  '生産ﾗｲﾝNo.
                            strXKENSA_KUBUN = XKENSA_KUBUN_J_OK                         '検査区分
                            strXKENPIN_KUBUN = XKENPIN_KUBUN_J_MI                       '検品区分
                            '更新日時
                            strFUPDATE_DT = strDATA1_FUPDATE_DT.Substring(0, 4) & "/" & strDATA1_FUPDATE_DT.Substring(4, 2) & "/" & strDATA1_FUPDATE_DT.Substring(6, 2) & " " & "00:00:00"


                            objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                            objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO1)                'ﾊﾞｯﾌｧ№1
                            objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY1)          'ﾊﾞｯﾌｧ配列№1
                            objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                            objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                            objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態
                            objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
                            objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                            objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                            objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                            objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTR_VOL", TO_INTEGER(strFTR_VOL))         '搬送管理量
                            objTelegram.SETIN_DATA("DSPTR_RES_VOL", "0")                        '搬送引当量
                            objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                            objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
                            objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類
                            objTelegram.SETIN_DATA("DSPBUF_IN_DT", strFBUF_IN_DT)               'ﾊﾞｯﾌｧ入日時
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK", strXTANA_BLOCK)            '棚ﾌﾞﾛｯｸ
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_DTL", strXTANA_BLOCK_DTL)    '棚ﾌﾞﾛｯｸ詳細
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_STS", strXTANA_BLOCK_STS)    '棚ﾌﾞﾛｯｸ状態
                            objTelegram.SETIN_DATA("XDSPKENSA_KUBUN", strXKENSA_KUBUN)          '検査区分
                            objTelegram.SETIN_DATA("XDSPKENPIN_KUBUN", strXKENPIN_KUBUN)        '検品区分
                            objTelegram.SETIN_DATA("XDSPRAC_IN_DT", strFBUF_IN_DT)              '入庫日時=ﾊﾞｯﾌｧ入日時と同じ
                            objTelegram.SETIN_DATA("DSPUPDATE_DT", strFUPDATE_DT)               '更新日時


                            If strSUBKEY1_XPROD_LINE.Trim.Length <= 3 Then
                                '(3ﾊﾞｲﾄ以下=ﾒｰｶｺｰﾄﾞ)
                                objTelegram.SETIN_DATA("XDSPPROD_LINE", "")                     '生産ﾗｲﾝNo
                                objTelegram.SETIN_DATA("XDSPMAKER_CD", strXPROD_LINE)           'ﾒｰｶｺｰﾄﾞ

                            Else
                                '(3ﾊﾞｲﾄ以上=生産ﾗｲﾝNo.)
                                objTelegram.SETIN_DATA("XDSPPROD_LINE", strXPROD_LINE)          '生産ﾗｲﾝNo
                                objTelegram.SETIN_DATA("XDSPMAKER_CD", "")                      'ﾒｰｶｺｰﾄﾞ

                            End If


                        End If

                        '*******************************************************
                        'ｿｹｯﾄ送信
                        '*******************************************************
                        If blnSockSend = True Then
                            Dim strRET_STATE As String = ""
                            Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
                            Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

                            strErrMsg = "在庫移行に失敗しました。"
                            udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
                            If udtSckSendRET = clsSocketClient.RetCode.OK Then
                                '(送信できた場合)
                                If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                                    '(正常終了の場合)
                                    blnRet = True
                                End If
                            End If

                            If blnRet = False Then
                                Throw New Exception(TO_STRING(ii + 1) & "行目棚1でｴﾗｰ発生。")
                            End If

                        End If




                        '******************************************************************************************************************
                        '
                        ' 棚2 電文作成
                        '
                        '******************************************************************************************************************

                        '========================================
                        ' 変数初期化
                        '========================================
                        strDIR_KUBUN = ""                             '処理区分
                        strFBUF_NO2 = ""                              'ﾊﾞｯﾌｧ№
                        strFBUF_ARRAY2 = ""                           'ﾊﾞｯﾌｧ配列№
                        strFREMOVE_KIND = ""                          '禁止棚設定
                        strFRAC_FORM = ""                             '棚形状種別
                        strFRES_KIND = ""                             '引当状態
                        ' ''strFHINMEI_CD = ""                            '品名記号
                        strFLOT_NO = ""                               'ﾛｯﾄ№
                        strFARRIVE_DT = ""                            '在庫発生日時
                        strFIN_KUBUN = ""                             '入庫区分
                        strFSEIHIN_KUBUN = ""                         '製品区分
                        strFZAIKO_KUBUN = ""                          '在庫区分
                        strFHORYU_KUBUN = ""                          '保留区分
                        strFST_FM = ""                                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        strFTR_VOL = ""                               '搬送管理量
                        strFTR_RES_VOL = ""                           '搬送引当量
                        strFPALLET_ID = ""                            'ﾊﾟﾚｯﾄID
                        strFLOT_NO_STOCK = ""                         '在庫ﾛｯﾄ№
                        strFLABEL_ID = ""                             'ﾗﾍﾞﾙID
                        strFHASU_FLAG = ""                            '端数ﾌﾗｸﾞ
                        strFSYUKKA_TO_CD = ""                         '出荷先ｺｰﾄﾞ
                        strFSYUKKA_TO_NAME = ""                       '出荷先名称
                        strFRAC_BUNRUI = ""                           '棚分類
                        strFBUF_IN_DT = ""                            'ﾊﾞｯﾌｧ入日時
                        strXTANA_BLOCK = ""                           '棚ﾌﾞﾛｯｸ
                        strXTANA_BLOCK_DTL = ""                       '棚ﾌﾞﾛｯｸ詳細
                        strXTANA_BLOCK_STS = ""                       '棚ﾌﾞﾛｯｸ状態
                        strXPROD_LINE = ""                            '生産ﾗｲﾝNo.
                        strXKENSA_KUBUN = ""                          '検査区分
                        strXKENPIN_KUBUN = ""                         '検品区分

                        objTelegram = Nothing
                        objTelegram = New clsTelegram(CONFIG_TELEGRAM_DSP)
                        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

                        '*******************************************************
                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ取得
                        '*******************************************************
                        objTPRG_TRK_BUF = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
                        '(奥 奇数)
                        objTPRG_TRK_BUF.FRAC_RETU = TO_INTEGER(strMAINKEY_FRAC_RETU)    '列
                        objTPRG_TRK_BUF.FRAC_REN = TO_INTEGER(strMAINKEY_FRAC_REN) - 1      '連
                        objTPRG_TRK_BUF.FRAC_DAN = TO_INTEGER(strMAINKEY_FRAC_DAN)      '段
                        objTPRG_TRK_BUF.FRAC_EDA = 1                                    '枝
                        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                     '取得
                        If intRet <> RetCode.OK Then
                            Throw New Exception(TO_STRING(ii + 1) & "行目棚2でｴﾗｰ発生。" & vbCrLf & ERRMSG_NOTFOUND_BUF & "[列連段枝:" & objTPRG_TRK_BUF.FRAC_RETU & "-" & objTPRG_TRK_BUF.FRAC_REN & "-" & objTPRG_TRK_BUF.FRAC_DAN & "-" & objTPRG_TRK_BUF.FRAC_EDA & "]")
                        End If

                        strFBUF_NO2 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO)                'ﾊﾞｯﾌｧ№2
                        strFBUF_ARRAY2 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY)          'ﾊﾞｯﾌｧ配列№2
                        strFRAC_FORM = TO_STRING(objTPRG_TRK_BUF.FRAC_FORM)                 '棚形状種別
                        strFRAC_BUNRUI = TO_STRING(objTPRG_TRK_BUF.FRAC_BUNRUI)             '棚分類
                        strXTANA_BLOCK = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK)             '棚ﾌﾞﾛｯｸ
                        strXTANA_BLOCK_DTL = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_DTL)     '棚ﾌﾞﾛｯｸ詳細
                        strXTANA_BLOCK_STS = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_STS)     '棚ﾌﾞﾛｯｸ状態
                        strFREMOVE_KIND = TO_STRING(objTPRG_TRK_BUF.FREMOVE_KIND)           '禁止状態

                        objTPRG_TRK_BUF.Close()

                        '*******************************************************
                        '空棚か確認
                        '*******************************************************
                        If blnTANA2_KARA = False Then
                            '(空棚の場合、確認不要)
                            If strDATA1_TANA2_FBUF_IN_DT.Trim = "" Or _
                               TO_INTEGER(strDATA1_TANA2_FBUF_IN_DT) = 0 Then
                                '(棚2の入庫年月日が設定されていない場合)
                                blnTANA2_KARA = True
                            End If
                        End If


                        If blnTANA2_KARA = True Then
                            '(在庫なし)

                            strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK         '処理区分
                            'ﾊﾞｯﾌｧ№
                            'ﾊﾞｯﾌｧ配列№
                            If strFREMOVE_KIND <> "9" Then                              '禁止棚設定
                                '(無効棚ではない場合)
                                If blnFREMOVE_KIND = True Then
                                    strFREMOVE_KIND = FREMOVE_KIND_SON
                                Else
                                    strFREMOVE_KIND = FREMOVE_KIND_SNORMAL
                                End If
                            End If
                            '棚形状種別
                            strFRES_KIND = FRES_KIND_SAKI                               '引当状態=空
                            strFHINMEI_CD = ""                                          '品名ｺｰﾄﾞ
                            strFLOT_NO = ""                                             'ﾛｯﾄNo.
                            strFARRIVE_DT = ""                                          '在庫発生日時
                            strFIN_KUBUN = ""                                           '入庫区分
                            strFHORYU_KUBUN = ""                                        '保留区分
                            strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            strFTR_VOL = ""                                             '数量
                            '棚分類
                            '棚ﾌﾞﾛｯｸ
                            '棚ﾌﾞﾛｯｸ詳細
                            '棚ﾌﾞﾛｯｸ状態

                            objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                            objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO2)                'ﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY2)          'ﾊﾞｯﾌｧ配列№
                            objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                            objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                            objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態
                            objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
                            objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                            objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                            objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                            objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTR_VOL", strFTR_VOL)                     '搬送管理量
                            ' ''objTelegram.SETIN_DATA("DSPTR_RES_VOL", strFTR_RES_VOL)             '搬送引当量
                            ' ''objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                            ' ''objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
                            ' ''objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
                            objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK", strXTANA_BLOCK)            '棚ﾌﾞﾛｯｸ
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_DTL", strXTANA_BLOCK_DTL)    '棚ﾌﾞﾛｯｸ詳細
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_STS", strXTANA_BLOCK_STS)    '棚ﾌﾞﾛｯｸ状態


                        ElseIf blnTANA2_KARA = False Then
                            '(在庫情報がある場合)

                            If strFREMOVE_KIND = "9" Then
                                '(無効棚である場合)
                                Throw New Exception(TO_STRING(ii + 1) & "行目棚2でｴﾗｰ発生。" & vbCrLf & "在庫の追加先が無効棚です。" & "[列連段枝:" & objTPRG_TRK_BUF.FRAC_RETU & "-" & objTPRG_TRK_BUF.FRAC_REN & "-" & objTPRG_TRK_BUF.FRAC_DAN & "-" & objTPRG_TRK_BUF.FRAC_EDA & "]")
                            End If

                            strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_INSERT               '処理区分
                            'ﾊﾞｯﾌｧ№
                            'ﾊﾞｯﾌｧ配列№
                            If blnFREMOVE_KIND = True Then                              '禁止棚設定
                                strFREMOVE_KIND = FREMOVE_KIND_SON
                            Else
                                strFREMOVE_KIND = FREMOVE_KIND_SNORMAL
                            End If
                            '棚形状種別
                            strFRES_KIND = FRES_KIND_SZAIKO                             '引当状態=在庫
                            strFHINMEI_CD = strFHINMEI_CD                               '品名ｺｰﾄﾞ
                            strFLOT_NO = strSUBKEY1_XPROD_LINE.Trim & strSUBKEY1_FBUF_IN_DT     'ﾛｯﾄNo.(生産ﾗｲﾝ + 入庫年月日)
                            '在庫年月日
                            strFARRIVE_DT = strSUBKEY1_FBUF_IN_DT.Substring(0, 4) & "/" & strSUBKEY1_FBUF_IN_DT.Substring(4, 2) & "/" & strSUBKEY1_FBUF_IN_DT.Substring(6, 2) & " " & _
                                            strSUBKEY1_FBUF_IN_DT_TIME.Substring(0, 2) & ":" & strSUBKEY1_FBUF_IN_DT_TIME.Substring(2, 2) & ":" & strSUBKEY1_FBUF_IN_DT_TIME.Substring(4, 2)
                            '入庫区分
                            If strSUBKEY1_FIN_KUBUN = "91" Then
                                '(持戻り品)
                                strFIN_KUBUN = FIN_KUBUN_J04

                            ElseIf strSUBKEY1_FIN_KUBUN = "92" Then
                                '(再入棚品)
                                strFIN_KUBUN = FIN_KUBUN_J06

                            ElseIf strSUBKEY1_FIN_KUBUN = "93" Then
                                '(外部品)
                                strFIN_KUBUN = FIN_KUBUN_J02

                            ElseIf strSUBKEY1_FIN_KUBUN = "98" Then
                                '(生産入庫品)
                                strFIN_KUBUN = FIN_KUBUN_J01

                            ElseIf strSUBKEY1_FIN_KUBUN = "99" Then
                                '(その他)
                                strFIN_KUBUN = FIN_KUBUN_J05

                            End If
                            strFHORYU_KUBUN = FHORYU_KUBUN_SNORMAL                      '保留区分=通常品
                            strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            strFTR_VOL = strDATA1_TANA2_FTR_VOL                         '搬送管理量(棚2)
                            If TO_INTEGER(strDATA1_TANA2_FHASUU_FLAG) = 1 Then          '端数ﾌﾗｸﾞ(棚2)
                                '(端数の場合)
                                strFHASU_FLAG = "1"

                            ElseIf TO_INTEGER(strDATA1_TANA2_FHASUU_FLAG) = 2 Then
                                '(ﾌﾙPLの場合)
                                strFHASU_FLAG = "0"

                            End If
                            '棚分類
                            'ﾊﾞｯﾌｧ入日時(棚2)
                            strFBUF_IN_DT = strDATA1_TANA2_FBUF_IN_DT.Substring(0, 4) & "/" & strDATA1_TANA2_FBUF_IN_DT.Substring(4, 2) & "/" & strDATA1_TANA2_FBUF_IN_DT.Substring(6, 2) & " " & _
                                            strDATA1_TANA2_FBUF_IN_DT_TIME.Substring(0, 2) & ":" & strDATA1_TANA2_FBUF_IN_DT_TIME.Substring(2, 2) & ":" & strDATA1_TANA2_FBUF_IN_DT_TIME.Substring(4, 2)
                            '棚ﾌﾞﾛｯｸ
                            '棚ﾌﾞﾛｯｸ詳細
                            '棚ﾌﾞﾛｯｸ状態
                            strXPROD_LINE = strSUBKEY1_XPROD_LINE.Trim                  '生産ﾗｲﾝNo.
                            strXKENSA_KUBUN = XKENSA_KUBUN_J_OK                         '検査区分
                            strXKENPIN_KUBUN = XKENPIN_KUBUN_J_MI                       '検品区分


                            objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                            objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO2)                'ﾊﾞｯﾌｧ№2
                            objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY2)          'ﾊﾞｯﾌｧ配列№2
                            objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                            objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                            objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態
                            objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
                            objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                            objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                            objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                            objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTR_VOL", TO_INTEGER(strFTR_VOL))                     '搬送管理量
                            objTelegram.SETIN_DATA("DSPTR_RES_VOL", "0")                        '搬送引当量
                            objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                            objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
                            objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類
                            objTelegram.SETIN_DATA("DSPBUF_IN_DT", strFBUF_IN_DT)               'ﾊﾞｯﾌｧ入日時
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK", strXTANA_BLOCK)            '棚ﾌﾞﾛｯｸ
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_DTL", strXTANA_BLOCK_DTL)    '棚ﾌﾞﾛｯｸ詳細
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_STS", strXTANA_BLOCK_STS)    '棚ﾌﾞﾛｯｸ状態
                            objTelegram.SETIN_DATA("XDSPKENSA_KUBUN", strXKENSA_KUBUN)          '検査区分
                            objTelegram.SETIN_DATA("XDSPKENPIN_KUBUN", strXKENPIN_KUBUN)        '検品区分
                            objTelegram.SETIN_DATA("XDSPRAC_IN_DT", strFBUF_IN_DT)              '入庫日時=ﾊﾞｯﾌｧ入日時と同じ
                            objTelegram.SETIN_DATA("DSPUPDATE_DT", strFUPDATE_DT)               '更新日時

                            If strSUBKEY1_XPROD_LINE.Trim.Length <= 3 Then
                                '(3ﾊﾞｲﾄ以下=ﾒｰｶｺｰﾄﾞ)
                                objTelegram.SETIN_DATA("XDSPPROD_LINE", "")                     '生産ﾗｲﾝNo
                                objTelegram.SETIN_DATA("XDSPMAKER_CD", strXPROD_LINE)           'ﾒｰｶｺｰﾄﾞ

                            Else
                                '(3ﾊﾞｲﾄ以上=生産ﾗｲﾝNo.)
                                objTelegram.SETIN_DATA("XDSPPROD_LINE", strXPROD_LINE)          '生産ﾗｲﾝNo
                                objTelegram.SETIN_DATA("XDSPMAKER_CD", "")                      'ﾒｰｶｺｰﾄﾞ

                            End If



                        End If

                        '*******************************************************
                        'ｿｹｯﾄ送信
                        '*******************************************************
                        If blnSockSend = True Then
                            Dim strRET_STATE As String = ""
                            Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
                            Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

                            strErrMsg = "在庫移行に失敗しました。"
                            udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
                            If udtSckSendRET = clsSocketClient.RetCode.OK Then
                                '(送信できた場合)
                                If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                                    '(正常終了の場合)
                                    blnRet = True
                                End If
                            End If

                            If blnRet = False Then
                                Throw New Exception(TO_STRING(ii + 1) & "行目棚2でｴﾗｰ発生。")
                            End If

                        End If




                        '******************************************************************************************************************
                        '
                        ' 棚3 電文作成
                        '
                        '******************************************************************************************************************

                        '========================================
                        ' 変数初期化
                        '========================================
                        strDIR_KUBUN = ""                             '処理区分
                        strFBUF_NO3 = ""                              'ﾊﾞｯﾌｧ№3
                        strFBUF_ARRAY3 = ""                           'ﾊﾞｯﾌｧ配列№3
                        strFREMOVE_KIND = ""                          '禁止棚設定
                        strFRAC_FORM = ""                             '棚形状種別
                        strFRES_KIND = ""                             '引当状態
                        ' ''strFHINMEI_CD = ""                            '品名記号
                        strFLOT_NO = ""                               'ﾛｯﾄ№
                        strFARRIVE_DT = ""                            '在庫発生日時
                        strFIN_KUBUN = ""                             '入庫区分
                        strFSEIHIN_KUBUN = ""                         '製品区分
                        strFZAIKO_KUBUN = ""                          '在庫区分
                        strFHORYU_KUBUN = ""                          '保留区分
                        strFST_FM = ""                                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        strFTR_VOL = ""                               '搬送管理量
                        strFTR_RES_VOL = ""                           '搬送引当量
                        strFPALLET_ID = ""                            'ﾊﾟﾚｯﾄID
                        strFLOT_NO_STOCK = ""                         '在庫ﾛｯﾄ№
                        strFLABEL_ID = ""                             'ﾗﾍﾞﾙID
                        strFHASU_FLAG = ""                            '端数ﾌﾗｸﾞ
                        strFSYUKKA_TO_CD = ""                         '出荷先ｺｰﾄﾞ
                        strFSYUKKA_TO_NAME = ""                       '出荷先名称
                        strFRAC_BUNRUI = ""                           '棚分類
                        strFBUF_IN_DT = ""                            'ﾊﾞｯﾌｧ入日時
                        strXTANA_BLOCK = ""                           '棚ﾌﾞﾛｯｸ
                        strXTANA_BLOCK_DTL = ""                       '棚ﾌﾞﾛｯｸ詳細
                        strXTANA_BLOCK_STS = ""                       '棚ﾌﾞﾛｯｸ状態
                        strXPROD_LINE = ""                            '生産ﾗｲﾝNo.
                        strXKENSA_KUBUN = ""                          '検査区分
                        strXKENPIN_KUBUN = ""                         '検品区分

                        objTelegram = Nothing
                        objTelegram = New clsTelegram(CONFIG_TELEGRAM_DSP)
                        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

                        '*******************************************************
                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ取得
                        '*******************************************************
                        objTPRG_TRK_BUF = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
                        '(手前 偶数)
                        objTPRG_TRK_BUF.FRAC_RETU = TO_INTEGER(strMAINKEY_FRAC_RETU)    '列
                        objTPRG_TRK_BUF.FRAC_REN = TO_INTEGER(strMAINKEY_FRAC_REN)   '連
                        objTPRG_TRK_BUF.FRAC_DAN = TO_INTEGER(strMAINKEY_FRAC_DAN)      '段
                        objTPRG_TRK_BUF.FRAC_EDA = 0                                    '枝
                        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                     '取得
                        If intRet <> RetCode.OK Then
                            Throw New Exception(TO_STRING(ii + 1) & "行目棚3でｴﾗｰ発生。" & vbCrLf & ERRMSG_NOTFOUND_BUF & "[列連段枝:" & objTPRG_TRK_BUF.FRAC_RETU & "-" & objTPRG_TRK_BUF.FRAC_REN & "-" & objTPRG_TRK_BUF.FRAC_DAN & "-" & objTPRG_TRK_BUF.FRAC_EDA & "]")
                        End If

                        strFBUF_NO3 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO)                'ﾊﾞｯﾌｧ№3
                        strFBUF_ARRAY3 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY)          'ﾊﾞｯﾌｧ配列№3
                        strFRAC_FORM = TO_STRING(objTPRG_TRK_BUF.FRAC_FORM)                 '棚形状種別
                        strFRAC_BUNRUI = TO_STRING(objTPRG_TRK_BUF.FRAC_BUNRUI)             '棚分類
                        strXTANA_BLOCK = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK)             '棚ﾌﾞﾛｯｸ
                        strXTANA_BLOCK_DTL = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_DTL)     '棚ﾌﾞﾛｯｸ詳細
                        strXTANA_BLOCK_STS = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_STS)     '棚ﾌﾞﾛｯｸ状態
                        strFREMOVE_KIND = TO_STRING(objTPRG_TRK_BUF.FREMOVE_KIND)           '禁止状態

                        objTPRG_TRK_BUF.Close()

                        '*******************************************************
                        '空棚か確認
                        '*******************************************************
                        If blnTANA3_KARA = False Then
                            '(空棚の場合、確認不要)
                            If strDATA1_TANA3_FBUF_IN_DT.Trim = "" Or _
                               TO_INTEGER(strDATA1_TANA3_FBUF_IN_DT) = 0 Then
                                '(棚3の入庫年月日が設定されていない場合)
                                blnTANA3_KARA = True
                            End If
                        End If

                        If blnTANA3_KARA = True Then
                            '(在庫なし)

                            strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK         '処理区分
                            'ﾊﾞｯﾌｧ№
                            'ﾊﾞｯﾌｧ配列№
                            If strFREMOVE_KIND <> "9" Then                              '禁止棚設定
                                '(無効棚ではない場合)
                                If blnFREMOVE_KIND = True Then
                                    strFREMOVE_KIND = FREMOVE_KIND_SON
                                Else
                                    strFREMOVE_KIND = FREMOVE_KIND_SNORMAL
                                End If
                            End If
                            '棚形状種別
                            strFRES_KIND = FRES_KIND_SAKI                               '引当状態=空
                            strFHINMEI_CD = ""                                          '品名ｺｰﾄﾞ
                            strFLOT_NO = ""                                             'ﾛｯﾄNo.
                            strFARRIVE_DT = ""                                          '在庫発生日時
                            strFIN_KUBUN = ""                                           '入庫区分
                            strFHORYU_KUBUN = ""                                        '保留区分
                            strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            strFTR_VOL = ""                                             '数量
                            '棚分類
                            '棚ﾌﾞﾛｯｸ
                            '棚ﾌﾞﾛｯｸ詳細
                            '棚ﾌﾞﾛｯｸ状態

                            objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                            objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO3)                'ﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY3)          'ﾊﾞｯﾌｧ配列№
                            objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                            objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                            objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態
                            objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
                            objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                            objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                            objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                            objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTR_VOL", strFTR_VOL)                     '搬送管理量
                            ' ''objTelegram.SETIN_DATA("DSPTR_RES_VOL", strFTR_RES_VOL)             '搬送引当量
                            ' ''objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                            ' ''objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
                            ' ''objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
                            objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK", strXTANA_BLOCK)            '棚ﾌﾞﾛｯｸ
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_DTL", strXTANA_BLOCK_DTL)    '棚ﾌﾞﾛｯｸ詳細
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_STS", strXTANA_BLOCK_STS)    '棚ﾌﾞﾛｯｸ状態


                        ElseIf blnTANA3_KARA = False Then
                            '(在庫情報がある場合)

                            If strFREMOVE_KIND = "9" Then
                                '(無効棚である場合)
                                Throw New Exception(TO_STRING(ii + 1) & "行目棚3でｴﾗｰ発生。" & vbCrLf & "在庫の追加先が無効棚です。" & "[列連段枝:" & objTPRG_TRK_BUF.FRAC_RETU & "-" & objTPRG_TRK_BUF.FRAC_REN & "-" & objTPRG_TRK_BUF.FRAC_DAN & "-" & objTPRG_TRK_BUF.FRAC_EDA & "]")
                            End If

                            strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_INSERT               '処理区分
                            'ﾊﾞｯﾌｧ№
                            'ﾊﾞｯﾌｧ配列№
                            If blnFREMOVE_KIND = True Then                              '禁止棚設定
                                strFREMOVE_KIND = FREMOVE_KIND_SON
                            Else
                                strFREMOVE_KIND = FREMOVE_KIND_SNORMAL
                            End If
                            '棚形状種別
                            strFRES_KIND = FRES_KIND_SZAIKO                             '引当状態=在庫
                            strFHINMEI_CD = strFHINMEI_CD                               '品名ｺｰﾄﾞ
                            strFLOT_NO = strSUBKEY1_XPROD_LINE.Trim & strSUBKEY1_FBUF_IN_DT     'ﾛｯﾄNo.(生産ﾗｲﾝ + 入庫年月日)
                            '在庫年月日
                            strFARRIVE_DT = strSUBKEY1_FBUF_IN_DT.Substring(0, 4) & "/" & strSUBKEY1_FBUF_IN_DT.Substring(4, 2) & "/" & strSUBKEY1_FBUF_IN_DT.Substring(6, 2) & " " & _
                                            strSUBKEY1_FBUF_IN_DT_TIME.Substring(0, 2) & ":" & strSUBKEY1_FBUF_IN_DT_TIME.Substring(2, 2) & ":" & strSUBKEY1_FBUF_IN_DT_TIME.Substring(4, 2)
                            '入庫区分
                            If strSUBKEY1_FIN_KUBUN = "91" Then
                                '(持戻り品)
                                strFIN_KUBUN = FIN_KUBUN_J04

                            ElseIf strSUBKEY1_FIN_KUBUN = "92" Then
                                '(再入棚品)
                                strFIN_KUBUN = FIN_KUBUN_J06

                            ElseIf strSUBKEY1_FIN_KUBUN = "93" Then
                                '(外部品)
                                strFIN_KUBUN = FIN_KUBUN_J02

                            ElseIf strSUBKEY1_FIN_KUBUN = "98" Then
                                '(生産入庫品)
                                strFIN_KUBUN = FIN_KUBUN_J01

                            ElseIf strSUBKEY1_FIN_KUBUN = "99" Then
                                '(その他)
                                strFIN_KUBUN = FIN_KUBUN_J05

                            End If
                            strFHORYU_KUBUN = FHORYU_KUBUN_SNORMAL                      '保留区分=通常品
                            strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            strFTR_VOL = strDATA1_TANA3_FTR_VOL                         '搬送管理量(棚3)
                            If TO_INTEGER(strDATA1_TANA3_FHASUU_FLAG) = 1 Then          '端数ﾌﾗｸﾞ(棚3)
                                '(端数の場合)
                                strFHASU_FLAG = "1"

                            ElseIf TO_INTEGER(strDATA1_TANA3_FHASUU_FLAG) = 2 Then
                                '(ﾌﾙPLの場合)
                                strFHASU_FLAG = "0"

                            End If
                            '棚分類
                            'ﾊﾞｯﾌｧ入日時(棚3)
                            strFBUF_IN_DT = strDATA1_TANA3_FBUF_IN_DT.Substring(0, 4) & "/" & strDATA1_TANA3_FBUF_IN_DT.Substring(4, 2) & "/" & strDATA1_TANA3_FBUF_IN_DT.Substring(6, 2) & " " & _
                                            strDATA1_TANA3_FBUF_IN_DT_TIME.Substring(0, 2) & ":" & strDATA1_TANA3_FBUF_IN_DT_TIME.Substring(2, 2) & ":" & strDATA1_TANA3_FBUF_IN_DT_TIME.Substring(4, 2)
                            '棚ﾌﾞﾛｯｸ
                            '棚ﾌﾞﾛｯｸ詳細
                            '棚ﾌﾞﾛｯｸ状態
                            strXPROD_LINE = strSUBKEY1_XPROD_LINE.Trim                  '生産ﾗｲﾝNo.
                            strXKENSA_KUBUN = XKENSA_KUBUN_J_OK                         '検査区分
                            strXKENPIN_KUBUN = XKENPIN_KUBUN_J_MI                       '検品区分


                            objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                            objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO3)                'ﾊﾞｯﾌｧ№3
                            objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY3)          'ﾊﾞｯﾌｧ配列№3
                            objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                            objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                            objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態
                            objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
                            objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                            objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                            objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                            objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTR_VOL", TO_INTEGER(strFTR_VOL))         '搬送管理量
                            objTelegram.SETIN_DATA("DSPTR_RES_VOL", "0")                        '搬送引当量
                            objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                            objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
                            objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類
                            objTelegram.SETIN_DATA("DSPBUF_IN_DT", strFBUF_IN_DT)               'ﾊﾞｯﾌｧ入日時
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK", strXTANA_BLOCK)            '棚ﾌﾞﾛｯｸ
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_DTL", strXTANA_BLOCK_DTL)    '棚ﾌﾞﾛｯｸ詳細
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_STS", strXTANA_BLOCK_STS)    '棚ﾌﾞﾛｯｸ状態
                            objTelegram.SETIN_DATA("XDSPKENSA_KUBUN", strXKENSA_KUBUN)          '検査区分
                            objTelegram.SETIN_DATA("XDSPKENPIN_KUBUN", strXKENPIN_KUBUN)        '検品区分
                            objTelegram.SETIN_DATA("XDSPRAC_IN_DT", strFBUF_IN_DT)              '入庫日時=ﾊﾞｯﾌｧ入日時と同じ
                            objTelegram.SETIN_DATA("DSPUPDATE_DT", strFUPDATE_DT)               '更新日時

                            If strSUBKEY1_XPROD_LINE.Trim.Length <= 3 Then
                                '(3ﾊﾞｲﾄ以下=ﾒｰｶｺｰﾄﾞ)
                                objTelegram.SETIN_DATA("XDSPPROD_LINE", "")                     '生産ﾗｲﾝNo
                                objTelegram.SETIN_DATA("XDSPMAKER_CD", strXPROD_LINE)           'ﾒｰｶｺｰﾄﾞ

                            Else
                                '(3ﾊﾞｲﾄ以上=生産ﾗｲﾝNo.)
                                objTelegram.SETIN_DATA("XDSPPROD_LINE", strXPROD_LINE)          '生産ﾗｲﾝNo
                                objTelegram.SETIN_DATA("XDSPMAKER_CD", "")                      'ﾒｰｶｺｰﾄﾞ

                            End If



                        End If

                        '*******************************************************
                        'ｿｹｯﾄ送信
                        '*******************************************************
                        If blnSockSend = True Then
                            Dim strRET_STATE As String = ""
                            Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
                            Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

                            strErrMsg = "在庫移行に失敗しました。"
                            udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
                            If udtSckSendRET = clsSocketClient.RetCode.OK Then
                                '(送信できた場合)
                                If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                                    '(正常終了の場合)
                                    blnRet = True
                                End If
                            End If

                            If blnRet = False Then
                                Throw New Exception(TO_STRING(ii + 1) & "行目棚3でｴﾗｰ発生。")
                            End If

                        End If




                        '******************************************************************************************************************
                        '
                        ' 棚4 電文作成
                        '
                        '******************************************************************************************************************

                        '========================================
                        ' 変数初期化
                        '========================================
                        strDIR_KUBUN = ""                             '処理区分
                        strFBUF_NO4 = ""                              'ﾊﾞｯﾌｧ№4
                        strFBUF_ARRAY4 = ""                           'ﾊﾞｯﾌｧ配列№4
                        strFREMOVE_KIND = ""                          '禁止棚設定
                        strFRAC_FORM = ""                             '棚形状種別
                        strFRES_KIND = ""                             '引当状態
                        ' ''strFHINMEI_CD = ""                            '品名記号
                        strFLOT_NO = ""                               'ﾛｯﾄ№
                        strFARRIVE_DT = ""                            '在庫発生日時
                        strFIN_KUBUN = ""                             '入庫区分
                        strFSEIHIN_KUBUN = ""                         '製品区分
                        strFZAIKO_KUBUN = ""                          '在庫区分
                        strFHORYU_KUBUN = ""                          '保留区分
                        strFST_FM = ""                                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        strFTR_VOL = ""                               '搬送管理量
                        strFTR_RES_VOL = ""                           '搬送引当量
                        strFPALLET_ID = ""                            'ﾊﾟﾚｯﾄID
                        strFLOT_NO_STOCK = ""                         '在庫ﾛｯﾄ№
                        strFLABEL_ID = ""                             'ﾗﾍﾞﾙID
                        strFHASU_FLAG = ""                            '端数ﾌﾗｸﾞ
                        strFSYUKKA_TO_CD = ""                         '出荷先ｺｰﾄﾞ
                        strFSYUKKA_TO_NAME = ""                       '出荷先名称
                        strFRAC_BUNRUI = ""                           '棚分類
                        strFBUF_IN_DT = ""                            'ﾊﾞｯﾌｧ入日時
                        strXTANA_BLOCK = ""                           '棚ﾌﾞﾛｯｸ
                        strXTANA_BLOCK_DTL = ""                       '棚ﾌﾞﾛｯｸ詳細
                        strXTANA_BLOCK_STS = ""                       '棚ﾌﾞﾛｯｸ状態
                        strXPROD_LINE = ""                            '生産ﾗｲﾝNo.
                        strXKENSA_KUBUN = ""                          '検査区分
                        strXKENPIN_KUBUN = ""                         '検品区分

                        objTelegram = Nothing
                        objTelegram = New clsTelegram(CONFIG_TELEGRAM_DSP)
                        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

                        '*******************************************************
                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ取得
                        '*******************************************************
                        objTPRG_TRK_BUF = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
                        '(手前 奇数)
                        objTPRG_TRK_BUF.FRAC_RETU = TO_INTEGER(strMAINKEY_FRAC_RETU)    '列
                        objTPRG_TRK_BUF.FRAC_REN = TO_INTEGER(strMAINKEY_FRAC_REN) - 1     '連
                        objTPRG_TRK_BUF.FRAC_DAN = TO_INTEGER(strMAINKEY_FRAC_DAN)      '段
                        objTPRG_TRK_BUF.FRAC_EDA = 0                                    '枝
                        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                     '取得
                        If intRet <> RetCode.OK Then
                            Throw New Exception(TO_STRING(ii + 1) & "行目棚4でｴﾗｰ発生。" & vbCrLf & ERRMSG_NOTFOUND_BUF & "[列連段枝:" & objTPRG_TRK_BUF.FRAC_RETU & "-" & objTPRG_TRK_BUF.FRAC_REN & "-" & objTPRG_TRK_BUF.FRAC_DAN & "-" & objTPRG_TRK_BUF.FRAC_EDA & "]")
                        End If

                        strFBUF_NO4 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO)                'ﾊﾞｯﾌｧ№4
                        strFBUF_ARRAY4 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY)          'ﾊﾞｯﾌｧ配列№4
                        strFRAC_FORM = TO_STRING(objTPRG_TRK_BUF.FRAC_FORM)                 '棚形状種別
                        strFRAC_BUNRUI = TO_STRING(objTPRG_TRK_BUF.FRAC_BUNRUI)             '棚分類
                        strXTANA_BLOCK = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK)             '棚ﾌﾞﾛｯｸ
                        strXTANA_BLOCK_DTL = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_DTL)     '棚ﾌﾞﾛｯｸ詳細
                        strXTANA_BLOCK_STS = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_STS)     '棚ﾌﾞﾛｯｸ状態
                        strFREMOVE_KIND = TO_STRING(objTPRG_TRK_BUF.FREMOVE_KIND)           '禁止状態

                        objTPRG_TRK_BUF.Close()

                        '*******************************************************
                        '空棚か確認
                        '*******************************************************
                        If blnTANA4_KARA = False Then
                            '(空棚の場合、確認不要)
                            If strDATA1_TANA4_FBUF_IN_DT.Trim = "" Or _
                               TO_INTEGER(strDATA1_TANA4_FBUF_IN_DT) = 0 Then
                                '(棚4の入庫年月日が設定されていない場合)
                                blnTANA4_KARA = True
                            End If
                        End If


                        If blnTANA4_KARA = True Then
                            '(在庫なし)

                            strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK         '処理区分
                            'ﾊﾞｯﾌｧ№
                            'ﾊﾞｯﾌｧ配列№
                            If strFREMOVE_KIND <> "9" Then                              '禁止棚設定
                                '(無効棚ではない場合)
                                If blnFREMOVE_KIND = True Then
                                    strFREMOVE_KIND = FREMOVE_KIND_SON
                                Else
                                    strFREMOVE_KIND = FREMOVE_KIND_SNORMAL
                                End If
                            End If
                            '棚形状種別
                            strFRES_KIND = FRES_KIND_SAKI                               '引当状態=空
                            strFHINMEI_CD = ""                                          '品名ｺｰﾄﾞ
                            strFLOT_NO = ""                                             'ﾛｯﾄNo.
                            strFARRIVE_DT = ""                                          '在庫発生日時
                            strFIN_KUBUN = ""                                           '入庫区分
                            strFHORYU_KUBUN = ""                                        '保留区分
                            strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            strFTR_VOL = ""                                             '数量
                            '棚分類
                            '棚ﾌﾞﾛｯｸ
                            '棚ﾌﾞﾛｯｸ詳細
                            '棚ﾌﾞﾛｯｸ状態

                            objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                            objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO4)                'ﾊﾞｯﾌｧ№4
                            objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY4)          'ﾊﾞｯﾌｧ配列№4
                            objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                            objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                            objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態
                            objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
                            objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                            objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                            objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                            objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTR_VOL", strFTR_VOL)                     '搬送管理量
                            ' ''objTelegram.SETIN_DATA("DSPTR_RES_VOL", strFTR_RES_VOL)             '搬送引当量
                            ' ''objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                            ' ''objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
                            ' ''objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
                            objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK", strXTANA_BLOCK)            '棚ﾌﾞﾛｯｸ
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_DTL", strXTANA_BLOCK_DTL)    '棚ﾌﾞﾛｯｸ詳細
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_STS", strXTANA_BLOCK_STS)    '棚ﾌﾞﾛｯｸ状態


                        ElseIf blnTANA4_KARA = False Then
                            '(在庫情報がある場合)
                            If strFREMOVE_KIND = "9" Then
                                '(無効棚である場合)
                                Throw New Exception(TO_STRING(ii + 1) & "行目棚1でｴﾗｰ発生。" & vbCrLf & "在庫の追加先が無効棚です。" & "[列連段枝:" & objTPRG_TRK_BUF.FRAC_RETU & "-" & objTPRG_TRK_BUF.FRAC_REN & "-" & objTPRG_TRK_BUF.FRAC_DAN & "-" & objTPRG_TRK_BUF.FRAC_EDA & "]")
                            End If

                            strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_INSERT               '処理区分
                            'ﾊﾞｯﾌｧ№
                            'ﾊﾞｯﾌｧ配列№
                            If blnFREMOVE_KIND = True Then                              '禁止設定
                                strFREMOVE_KIND = FREMOVE_KIND_SON
                            Else
                                strFREMOVE_KIND = FREMOVE_KIND_SNORMAL
                            End If
                            '棚形状種別
                            strFRES_KIND = FRES_KIND_SZAIKO                             '引当状態=在庫
                            strFHINMEI_CD = strFHINMEI_CD                               '品名ｺｰﾄﾞ
                            strFLOT_NO = strSUBKEY1_XPROD_LINE.Trim & strSUBKEY1_FBUF_IN_DT     'ﾛｯﾄNo.(生産ﾗｲﾝ + 入庫年月日)
                            '在庫年月日
                            strFARRIVE_DT = strSUBKEY1_FBUF_IN_DT.Substring(0, 4) & "/" & strSUBKEY1_FBUF_IN_DT.Substring(4, 2) & "/" & strSUBKEY1_FBUF_IN_DT.Substring(6, 2) & " " & _
                                            strSUBKEY1_FBUF_IN_DT_TIME.Substring(0, 2) & ":" & strSUBKEY1_FBUF_IN_DT_TIME.Substring(2, 2) & ":" & strSUBKEY1_FBUF_IN_DT_TIME.Substring(4, 2)
                            '入庫区分
                            If strSUBKEY1_FIN_KUBUN = "91" Then
                                '(持戻り品)
                                strFIN_KUBUN = FIN_KUBUN_J04

                            ElseIf strSUBKEY1_FIN_KUBUN = "92" Then
                                '(再入棚品)
                                strFIN_KUBUN = FIN_KUBUN_J06

                            ElseIf strSUBKEY1_FIN_KUBUN = "93" Then
                                '(外部品)
                                strFIN_KUBUN = FIN_KUBUN_J02

                            ElseIf strSUBKEY1_FIN_KUBUN = "98" Then
                                '(生産入庫品)
                                strFIN_KUBUN = FIN_KUBUN_J01

                            ElseIf strSUBKEY1_FIN_KUBUN = "99" Then
                                '(その他)
                                strFIN_KUBUN = FIN_KUBUN_J05

                            End If
                            strFHORYU_KUBUN = FHORYU_KUBUN_SNORMAL                      '保留区分=通常品
                            strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            strFTR_VOL = strDATA1_TANA4_FTR_VOL                         '搬送管理量(棚4)
                            If TO_INTEGER(strDATA1_TANA1_FHASUU_FLAG) = 1 Then          '端数ﾌﾗｸﾞ(棚4)
                                '(端数の場合)
                                strFHASU_FLAG = "1"

                            ElseIf TO_INTEGER(strDATA1_TANA1_FHASUU_FLAG) = 2 Then
                                '(ﾌﾙPLの場合)
                                strFHASU_FLAG = "0"

                            End If
                            '棚分類
                            'ﾊﾞｯﾌｧ入日時(棚4)
                            strFBUF_IN_DT = strDATA1_TANA4_FBUF_IN_DT.Substring(0, 4) & "/" & strDATA1_TANA4_FBUF_IN_DT.Substring(4, 2) & "/" & strDATA1_TANA4_FBUF_IN_DT.Substring(6, 2) & " " & _
                                            strDATA1_TANA4_FBUF_IN_DT_TIME.Substring(0, 2) & ":" & strDATA1_TANA4_FBUF_IN_DT_TIME.Substring(2, 2) & ":" & strDATA1_TANA4_FBUF_IN_DT_TIME.Substring(4, 2)
                            '棚ﾌﾞﾛｯｸ
                            '棚ﾌﾞﾛｯｸ詳細
                            '棚ﾌﾞﾛｯｸ状態
                            strXPROD_LINE = strSUBKEY1_XPROD_LINE.Trim                  '生産ﾗｲﾝNo.
                            strXKENSA_KUBUN = XKENSA_KUBUN_J_OK                         '検査区分
                            strXKENPIN_KUBUN = XKENPIN_KUBUN_J_MI                       '検品区分


                            objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                            objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO4)                'ﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY4)          'ﾊﾞｯﾌｧ配列№
                            objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                            objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                            objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態
                            objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
                            objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                            objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                            objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                            objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTR_VOL", TO_INTEGER(strFTR_VOL))                     '搬送管理量
                            objTelegram.SETIN_DATA("DSPTR_RES_VOL", "0")                        '搬送引当量
                            objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                            objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
                            objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類
                            objTelegram.SETIN_DATA("DSPBUF_IN_DT", strFBUF_IN_DT)               'ﾊﾞｯﾌｧ入日時
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK", strXTANA_BLOCK)            '棚ﾌﾞﾛｯｸ
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_DTL", strXTANA_BLOCK_DTL)    '棚ﾌﾞﾛｯｸ詳細
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_STS", strXTANA_BLOCK_STS)    '棚ﾌﾞﾛｯｸ状態
                            objTelegram.SETIN_DATA("XDSPKENSA_KUBUN", strXKENSA_KUBUN)          '検査区分
                            objTelegram.SETIN_DATA("XDSPKENPIN_KUBUN", strXKENPIN_KUBUN)        '検品区分
                            objTelegram.SETIN_DATA("XDSPRAC_IN_DT", strFBUF_IN_DT)              '入庫日時=ﾊﾞｯﾌｧ入日時と同じ
                            objTelegram.SETIN_DATA("DSPUPDATE_DT", strFUPDATE_DT)               '更新日時

                            If strSUBKEY1_XPROD_LINE.Trim.Length <= 3 Then
                                '(3ﾊﾞｲﾄ以下=ﾒｰｶｺｰﾄﾞ)
                                objTelegram.SETIN_DATA("XDSPPROD_LINE", "")                     '生産ﾗｲﾝNo
                                objTelegram.SETIN_DATA("XDSPMAKER_CD", strXPROD_LINE)           'ﾒｰｶｺｰﾄﾞ

                            Else
                                '(3ﾊﾞｲﾄ以上=生産ﾗｲﾝNo.)
                                objTelegram.SETIN_DATA("XDSPPROD_LINE", strXPROD_LINE)          '生産ﾗｲﾝNo
                                objTelegram.SETIN_DATA("XDSPMAKER_CD", "")                      'ﾒｰｶｺｰﾄﾞ

                            End If



                        End If

                        '*******************************************************
                        'ｿｹｯﾄ送信
                        '*******************************************************
                        If blnSockSend = True Then
                            Dim strRET_STATE As String = ""
                            Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
                            Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

                            strErrMsg = "在庫移行に失敗しました。"
                            udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
                            If udtSckSendRET = clsSocketClient.RetCode.OK Then
                                '(送信できた場合)
                                If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                                    '(正常終了の場合)
                                    blnRet = True
                                End If
                            End If

                            If blnRet = False Then
                                Throw New Exception(TO_STRING(ii + 1) & "行目棚4でｴﾗｰ発生。")
                            End If

                        End If







                    ElseIf TO_INTEGER(strMAINKEY_FRAC_RETU) = 27 Then
                        '*******************************************************
                        '
                        ' 27列目の場合
                        '
                        '*******************************************************

                        '*******************************************************
                        '棚禁止設定 確認
                        '*******************************************************
                        If strDATA1_FREMOVE_KIND.Substring(0, 1) = "1" Then
                            '(棚禁止詳細が1のとき=禁止設定)
                            If TO_INTEGER(strSUBKEY1_FREMOVE_KIND) = 2 Or _
                               TO_INTEGER(strSUBKEY1_FREMOVE_KIND) = 3 Then
                                '(棚禁止の場合)
                                blnFREMOVE_KIND = True
                            Else
                                Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。" & vbCrLf & "棚禁止設定に誤りがあります" & "[ﾌﾞﾛｯｸ状態:" & strSUBKEY1_FREMOVE_KIND & "]" & " [棚禁止詳細:" & strDATA1_FREMOVE_KIND & "]")
                            End If
                        End If


                        '*******************************************************
                        '品名ｺｰﾄﾞ取得
                        '*******************************************************
                        If strSUBKEY1_XHINMEI_CD.Trim <> "" Then
                            '(品目ｺｰﾄﾞが設定されている場合)
                            objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                            objTBL_TMST_ITEM.XHINMEI_CD = strSUBKEY1_XHINMEI_CD.Trim
                            intRet = objTBL_TMST_ITEM.GET_TMST_ITEM()
                            If intRet <> RetCode.OK Then
                                Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。" & vbCrLf & "該当する品目ｺｰﾄﾞがありません" & "[品目ｺｰﾄﾞ:" & strSUBKEY1_XHINMEI_CD & "]")
                            End If

                            strFHINMEI_CD = TO_STRING(objTBL_TMST_ITEM.FHINMEI_CD)          '品名ｺｰﾄﾞ
                            objTBL_TMST_ITEM.Close()
                        Else
                            '(品目ｺｰﾄﾞが設定されていない場合 = 全て空)
                            blnTANA1_KARA = True
                            blnTANA2_KARA = True
                            blnTANA3_KARA = True
                            blnTANA4_KARA = True
                        End If


                        '*******************************************************
                        ' 各棚の在庫状況確認
                        '*******************************************************
                        If blnTANA1_KARA = False Then
                            '(空棚の場合、確認不要)
                            If strDATA1_TANA1_FBUF_IN_DT.Trim = "" Or _
                               TO_INTEGER(strDATA1_TANA1_FBUF_IN_DT) = 0 Then
                                '(棚1の入庫年月日が設定されていない場合)
                                blnTANA1_KARA = True
                            End If
                        End If

                        If blnTANA2_KARA = False Then
                            '(空棚の場合、確認不要)
                            If strDATA1_TANA2_FBUF_IN_DT.Trim = "" Or _
                               TO_INTEGER(strDATA1_TANA2_FBUF_IN_DT) = 0 Then
                                '(棚2の入庫年月日が設定されていない場合)
                                blnTANA2_KARA = True
                            End If
                        End If

                        If blnTANA3_KARA = False Then
                            '(空棚の場合、確認不要)
                            If strDATA1_TANA3_FBUF_IN_DT.Trim = "" Or _
                               TO_INTEGER(strDATA1_TANA3_FBUF_IN_DT) = 0 Then
                                '(棚3の入庫年月日が設定されていない場合)
                                blnTANA3_KARA = True
                            End If
                        End If

                        If blnTANA4_KARA = False Then
                            '(空棚の場合、確認不要)
                            If strDATA1_TANA4_FBUF_IN_DT.Trim = "" Or _
                               TO_INTEGER(strDATA1_TANA4_FBUF_IN_DT) = 0 Then
                                '(棚4の入庫年月日が設定されていない場合)
                                blnTANA4_KARA = True
                            End If
                        End If

                        Dim intZAIKO_Count As Integer = 0
                        If blnTANA1_KARA = False Then intZAIKO_Count = intZAIKO_Count + 1
                        If blnTANA2_KARA = False Then intZAIKO_Count = intZAIKO_Count + 1
                        If blnTANA3_KARA = False Then intZAIKO_Count = intZAIKO_Count + 1
                        If blnTANA4_KARA = False Then intZAIKO_Count = intZAIKO_Count + 1

                        If intZAIKO_Count > 2 Then
                            '(2件より多い場合=手前奥の両方使用時)
                            Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。" & vbCrLf & "在庫が3件以上登録されています" & "[列:" & strMAINKEY_FRAC_RETU & "]")
                        End If


                        '========================================
                        '
                        ' 棚1 電文作成
                        '
                        '========================================
                        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

                        '*******************************************************
                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ取得
                        '*******************************************************
                        objTPRG_TRK_BUF = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
                        '(手前 偶数)
                        objTPRG_TRK_BUF.FRAC_RETU = TO_INTEGER(strMAINKEY_FRAC_RETU)    '列
                        objTPRG_TRK_BUF.FRAC_REN = TO_INTEGER(strMAINKEY_FRAC_REN)      '連
                        objTPRG_TRK_BUF.FRAC_DAN = TO_INTEGER(strMAINKEY_FRAC_DAN)      '段
                        objTPRG_TRK_BUF.FRAC_EDA = 1                                    '枝
                        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                     '取得
                        If intRet <> RetCode.OK Then
                            Throw New Exception(TO_STRING(ii + 1) & "行目棚1でｴﾗｰ発生。" & vbCrLf & ERRMSG_NOTFOUND_BUF & "[列連段枝:" & objTPRG_TRK_BUF.FRAC_RETU & "-" & objTPRG_TRK_BUF.FRAC_REN & "-" & objTPRG_TRK_BUF.FRAC_DAN & "-" & objTPRG_TRK_BUF.FRAC_EDA & "]")
                        End If

                        strFBUF_NO1 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO)                'ﾊﾞｯﾌｧ№1
                        strFBUF_ARRAY1 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY)          'ﾊﾞｯﾌｧ配列№1
                        strFRAC_FORM = TO_STRING(objTPRG_TRK_BUF.FRAC_FORM)                 '棚形状種別
                        strFRAC_BUNRUI = TO_STRING(objTPRG_TRK_BUF.FRAC_BUNRUI)             '棚分類
                        strXTANA_BLOCK = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK)             '棚ﾌﾞﾛｯｸ
                        strXTANA_BLOCK_DTL = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_DTL)     '棚ﾌﾞﾛｯｸ詳細
                        strXTANA_BLOCK_STS = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_STS)     '棚ﾌﾞﾛｯｸ状態
                        strFREMOVE_KIND = TO_STRING(objTPRG_TRK_BUF.FREMOVE_KIND)           '禁止状態

                        objTPRG_TRK_BUF.Close()

                        '*******************************************************
                        '空棚か確認
                        '*******************************************************
                        If blnTANA1_KARA = True Then
                            '(在庫なし)

                            strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK         '処理区分
                            'ﾊﾞｯﾌｧ№
                            'ﾊﾞｯﾌｧ配列№
                            If strFREMOVE_KIND <> "9" Then                              '禁止棚設定
                                '(無効棚ではない場合)
                                If blnFREMOVE_KIND = True Then
                                    strFREMOVE_KIND = FREMOVE_KIND_SON
                                Else
                                    strFREMOVE_KIND = FREMOVE_KIND_SNORMAL
                                End If
                            End If
                            '棚形状種別
                            strFRES_KIND = FRES_KIND_SAKI                               '引当状態=空
                            ' ''strFHINMEI_CD = ""                                          '品名ｺｰﾄﾞ
                            strFLOT_NO = ""                                             'ﾛｯﾄNo.
                            strFARRIVE_DT = ""                                          '在庫発生日時
                            strFIN_KUBUN = ""                                           '入庫区分
                            strFHORYU_KUBUN = ""                                        '保留区分
                            strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            strFTR_VOL = ""                                             '数量
                            '棚分類
                            '棚ﾌﾞﾛｯｸ
                            '棚ﾌﾞﾛｯｸ詳細
                            '棚ﾌﾞﾛｯｸ状態

                            objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                            objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO1)                'ﾊﾞｯﾌｧ№1
                            objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY1)          'ﾊﾞｯﾌｧ配列№1
                            objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                            objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                            objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態
                            objTelegram.SETIN_DATA("DSPHINMEI_CD", "")                          '品名ｺｰﾄﾞ
                            objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                            objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                            objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                            objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTR_VOL", strFTR_VOL)                     '搬送管理量
                            ' ''objTelegram.SETIN_DATA("DSPTR_RES_VOL", "0")                        '搬送引当量
                            ' ''objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                            ' ''objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
                            ' ''objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
                            objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK", strXTANA_BLOCK)            '棚ﾌﾞﾛｯｸ
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_DTL", strXTANA_BLOCK_DTL)    '棚ﾌﾞﾛｯｸ詳細
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_STS", strXTANA_BLOCK_STS)    '棚ﾌﾞﾛｯｸ状態


                        ElseIf blnTANA1_KARA = False Then
                            '(在庫情報がある場合)

                            If strFREMOVE_KIND = "9" Then
                                '(無効棚である場合)
                                ' ''Throw New Exception(TO_STRING(ii + 1) & "行目棚1でｴﾗｰ発生。" & vbCrLf & "在庫の追加先が無効棚です。" & "[列連段枝:" & objTPRG_TRK_BUF.FRAC_RETU & "-" & objTPRG_TRK_BUF.FRAC_REN & "-" & objTPRG_TRK_BUF.FRAC_DAN & "-" & objTPRG_TRK_BUF.FRAC_EDA & "]")
                            End If

                            strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_INSERT               '処理区分
                            'ﾊﾞｯﾌｧ№
                            'ﾊﾞｯﾌｧ配列№
                            If blnFREMOVE_KIND = True Then                              '禁止設定
                                strFREMOVE_KIND = FREMOVE_KIND_SON
                            Else
                                strFREMOVE_KIND = FREMOVE_KIND_SNORMAL
                            End If
                            '棚形状種別
                            strFRES_KIND = FRES_KIND_SZAIKO                             '引当状態=在庫
                            ' ''strFHINMEI_CD = strFHINMEI_CD                               '品名ｺｰﾄﾞ
                            strFLOT_NO = strSUBKEY1_XPROD_LINE.Trim & strSUBKEY1_FBUF_IN_DT     'ﾛｯﾄNo.(生産ﾗｲﾝ + 入庫年月日)
                            '在庫年月日
                            strFARRIVE_DT = strSUBKEY1_FBUF_IN_DT.Substring(0, 4) & "/" & strSUBKEY1_FBUF_IN_DT.Substring(4, 2) & "/" & strSUBKEY1_FBUF_IN_DT.Substring(6, 2) & " " & _
                                            strSUBKEY1_FBUF_IN_DT_TIME.Substring(0, 2) & ":" & strSUBKEY1_FBUF_IN_DT_TIME.Substring(2, 2) & ":" & strSUBKEY1_FBUF_IN_DT_TIME.Substring(4, 2)
                            '入庫区分
                            If strSUBKEY1_FIN_KUBUN = "91" Then
                                '(持戻り品)
                                strFIN_KUBUN = FIN_KUBUN_J04

                            ElseIf strSUBKEY1_FIN_KUBUN = "92" Then
                                '(再入棚品)
                                strFIN_KUBUN = FIN_KUBUN_J06

                            ElseIf strSUBKEY1_FIN_KUBUN = "93" Then
                                '(外部品)
                                strFIN_KUBUN = FIN_KUBUN_J02

                            ElseIf strSUBKEY1_FIN_KUBUN = "98" Then
                                '(生産入庫品)
                                strFIN_KUBUN = FIN_KUBUN_J01

                            ElseIf strSUBKEY1_FIN_KUBUN = "99" Then
                                '(その他)
                                strFIN_KUBUN = FIN_KUBUN_J05

                            End If
                            strFHORYU_KUBUN = FHORYU_KUBUN_SNORMAL                      '保留区分=通常品
                            strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            strFTR_VOL = strDATA1_TANA1_FTR_VOL                         '搬送管理量(棚1)

                            If TO_INTEGER(strDATA1_TANA1_FHASUU_FLAG) = 1 Then          '端数ﾌﾗｸﾞ(棚1)
                                '(端数の場合)
                                strFHASU_FLAG = "1"

                            ElseIf TO_INTEGER(strDATA1_TANA1_FHASUU_FLAG) = 2 Then
                                '(ﾌﾙPLの場合)
                                strFHASU_FLAG = "0"

                            End If

                            '棚分類
                            'ﾊﾞｯﾌｧ入日時(棚1)
                            strFBUF_IN_DT = strDATA1_TANA1_FBUF_IN_DT.Substring(0, 4) & "/" & strDATA1_TANA1_FBUF_IN_DT.Substring(4, 2) & "/" & strDATA1_TANA1_FBUF_IN_DT.Substring(6, 2) & " " & _
                                            strDATA1_TANA1_FBUF_IN_DT_TIME.Substring(0, 2) & ":" & strDATA1_TANA1_FBUF_IN_DT_TIME.Substring(2, 2) & ":" & strDATA1_TANA1_FBUF_IN_DT_TIME.Substring(4, 2)
                            '棚ﾌﾞﾛｯｸ
                            '棚ﾌﾞﾛｯｸ詳細
                            '棚ﾌﾞﾛｯｸ状態
                            strXPROD_LINE = strSUBKEY1_XPROD_LINE.Trim                  '生産ﾗｲﾝNo.
                            strXKENSA_KUBUN = XKENSA_KUBUN_J_OK                         '検査区分
                            strXKENPIN_KUBUN = XKENPIN_KUBUN_J_MI                       '検品区分
                            '更新日時
                            strFUPDATE_DT = strDATA1_FUPDATE_DT.Substring(0, 4) & "/" & strDATA1_FUPDATE_DT.Substring(4, 2) & "/" & strDATA1_FUPDATE_DT.Substring(6, 2) & " " & "00:00:00"


                            objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                            objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO1)                'ﾊﾞｯﾌｧ№1
                            objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY1)          'ﾊﾞｯﾌｧ配列№1
                            objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                            objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                            objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態
                            objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
                            objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                            objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                            objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                            objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTR_VOL", TO_INTEGER(strFTR_VOL))         '搬送管理量
                            objTelegram.SETIN_DATA("DSPTR_RES_VOL", "0")                        '搬送引当量
                            objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                            objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
                            objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類
                            objTelegram.SETIN_DATA("DSPBUF_IN_DT", strFBUF_IN_DT)               'ﾊﾞｯﾌｧ入日時
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK", strXTANA_BLOCK)            '棚ﾌﾞﾛｯｸ
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_DTL", strXTANA_BLOCK_DTL)    '棚ﾌﾞﾛｯｸ詳細
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_STS", strXTANA_BLOCK_STS)    '棚ﾌﾞﾛｯｸ状態
                            objTelegram.SETIN_DATA("XDSPKENSA_KUBUN", strXKENSA_KUBUN)          '検査区分
                            objTelegram.SETIN_DATA("XDSPKENPIN_KUBUN", strXKENPIN_KUBUN)        '検品区分
                            objTelegram.SETIN_DATA("XDSPRAC_IN_DT", strFBUF_IN_DT)              '入庫日時=ﾊﾞｯﾌｧ入日時と同じ
                            objTelegram.SETIN_DATA("DSPUPDATE_DT", strFUPDATE_DT)               '更新日時


                            If strSUBKEY1_XPROD_LINE.Trim.Length <= 3 Then
                                '(3ﾊﾞｲﾄ以下=ﾒｰｶｺｰﾄﾞ)
                                objTelegram.SETIN_DATA("XDSPPROD_LINE", "")                     '生産ﾗｲﾝNo
                                objTelegram.SETIN_DATA("XDSPMAKER_CD", strXPROD_LINE)           'ﾒｰｶｺｰﾄﾞ

                            Else
                                '(3ﾊﾞｲﾄ以上=生産ﾗｲﾝNo.)
                                objTelegram.SETIN_DATA("XDSPPROD_LINE", strXPROD_LINE)          '生産ﾗｲﾝNo
                                objTelegram.SETIN_DATA("XDSPMAKER_CD", "")                      'ﾒｰｶｺｰﾄﾞ

                            End If


                        End If

                        '*******************************************************
                        'ｿｹｯﾄ送信
                        '*******************************************************
                        If blnSockSend = True Then
                            Dim strRET_STATE As String = ""
                            Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
                            Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

                            strErrMsg = "在庫移行に失敗しました。"
                            udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
                            If udtSckSendRET = clsSocketClient.RetCode.OK Then
                                '(送信できた場合)
                                If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                                    '(正常終了の場合)
                                    blnRet = True
                                End If
                            End If

                            If blnRet = False Then
                                Throw New Exception(TO_STRING(ii + 1) & "行目棚1でｴﾗｰ発生。")
                            End If

                        End If

                        '******************************************************************************************************************
                        '
                        ' 棚2 電文作成
                        '
                        '******************************************************************************************************************

                        '========================================
                        ' 変数初期化
                        '========================================
                        strDIR_KUBUN = ""                             '処理区分
                        strFBUF_NO2 = ""                              'ﾊﾞｯﾌｧ№
                        strFBUF_ARRAY2 = ""                           'ﾊﾞｯﾌｧ配列№
                        strFREMOVE_KIND = ""                          '禁止棚設定
                        strFRAC_FORM = ""                             '棚形状種別
                        strFRES_KIND = ""                             '引当状態
                        ' ''strFHINMEI_CD = ""                            '品名記号
                        strFLOT_NO = ""                               'ﾛｯﾄ№
                        strFARRIVE_DT = ""                            '在庫発生日時
                        strFIN_KUBUN = ""                             '入庫区分
                        strFSEIHIN_KUBUN = ""                         '製品区分
                        strFZAIKO_KUBUN = ""                          '在庫区分
                        strFHORYU_KUBUN = ""                          '保留区分
                        strFST_FM = ""                                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        strFTR_VOL = ""                               '搬送管理量
                        strFTR_RES_VOL = ""                           '搬送引当量
                        strFPALLET_ID = ""                            'ﾊﾟﾚｯﾄID
                        strFLOT_NO_STOCK = ""                         '在庫ﾛｯﾄ№
                        strFLABEL_ID = ""                             'ﾗﾍﾞﾙID
                        strFHASU_FLAG = ""                            '端数ﾌﾗｸﾞ
                        strFSYUKKA_TO_CD = ""                         '出荷先ｺｰﾄﾞ
                        strFSYUKKA_TO_NAME = ""                       '出荷先名称
                        strFRAC_BUNRUI = ""                           '棚分類
                        strFBUF_IN_DT = ""                            'ﾊﾞｯﾌｧ入日時
                        strXTANA_BLOCK = ""                           '棚ﾌﾞﾛｯｸ
                        strXTANA_BLOCK_DTL = ""                       '棚ﾌﾞﾛｯｸ詳細
                        strXTANA_BLOCK_STS = ""                       '棚ﾌﾞﾛｯｸ状態
                        strXPROD_LINE = ""                            '生産ﾗｲﾝNo.
                        strXKENSA_KUBUN = ""                          '検査区分
                        strXKENPIN_KUBUN = ""                         '検品区分

                        objTelegram = Nothing
                        objTelegram = New clsTelegram(CONFIG_TELEGRAM_DSP)
                        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

                        '*******************************************************
                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ取得
                        '*******************************************************
                        objTPRG_TRK_BUF = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
                        '(奥 奇数)
                        objTPRG_TRK_BUF.FRAC_RETU = TO_INTEGER(strMAINKEY_FRAC_RETU)    '列
                        objTPRG_TRK_BUF.FRAC_REN = TO_INTEGER(strMAINKEY_FRAC_REN) - 1  '連
                        objTPRG_TRK_BUF.FRAC_DAN = TO_INTEGER(strMAINKEY_FRAC_DAN)      '段
                        objTPRG_TRK_BUF.FRAC_EDA = 1                                    '枝
                        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                     '取得
                        If intRet <> RetCode.OK Then
                            Throw New Exception(TO_STRING(ii + 1) & "行目棚2でｴﾗｰ発生。" & vbCrLf & ERRMSG_NOTFOUND_BUF & "[列連段枝:" & objTPRG_TRK_BUF.FRAC_RETU & "-" & objTPRG_TRK_BUF.FRAC_REN & "-" & objTPRG_TRK_BUF.FRAC_DAN & "-" & objTPRG_TRK_BUF.FRAC_EDA & "]")
                        End If

                        strFBUF_NO2 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO)                'ﾊﾞｯﾌｧ№2
                        strFBUF_ARRAY2 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY)          'ﾊﾞｯﾌｧ配列№2
                        strFRAC_FORM = TO_STRING(objTPRG_TRK_BUF.FRAC_FORM)                 '棚形状種別
                        strFRAC_BUNRUI = TO_STRING(objTPRG_TRK_BUF.FRAC_BUNRUI)             '棚分類
                        strXTANA_BLOCK = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK)             '棚ﾌﾞﾛｯｸ
                        strXTANA_BLOCK_DTL = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_DTL)     '棚ﾌﾞﾛｯｸ詳細
                        strXTANA_BLOCK_STS = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_STS)     '棚ﾌﾞﾛｯｸ状態
                        strFREMOVE_KIND = TO_STRING(objTPRG_TRK_BUF.FREMOVE_KIND)           '禁止状態

                        objTPRG_TRK_BUF.Close()

                        '*******************************************************
                        '空棚か確認
                        '*******************************************************
                        If blnTANA2_KARA = True Then
                            '(在庫なし)

                            strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK         '処理区分
                            'ﾊﾞｯﾌｧ№
                            'ﾊﾞｯﾌｧ配列№
                            If strFREMOVE_KIND <> "9" Then                              '禁止棚設定
                                '(無効棚ではない場合)
                                If blnFREMOVE_KIND = True Then
                                    strFREMOVE_KIND = FREMOVE_KIND_SON
                                Else
                                    strFREMOVE_KIND = FREMOVE_KIND_SNORMAL
                                End If
                            End If
                            '棚形状種別
                            strFRES_KIND = FRES_KIND_SAKI                               '引当状態=空
                            strFHINMEI_CD = ""                                          '品名ｺｰﾄﾞ
                            strFLOT_NO = ""                                             'ﾛｯﾄNo.
                            strFARRIVE_DT = ""                                          '在庫発生日時
                            strFIN_KUBUN = ""                                           '入庫区分
                            strFHORYU_KUBUN = ""                                        '保留区分
                            strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            strFTR_VOL = ""                                             '数量
                            '棚分類
                            '棚ﾌﾞﾛｯｸ
                            '棚ﾌﾞﾛｯｸ詳細
                            '棚ﾌﾞﾛｯｸ状態

                            objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                            objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO2)                'ﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY2)          'ﾊﾞｯﾌｧ配列№
                            objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                            objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                            objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態
                            objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
                            objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                            objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                            objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                            objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTR_VOL", strFTR_VOL)                     '搬送管理量
                            ' ''objTelegram.SETIN_DATA("DSPTR_RES_VOL", strFTR_RES_VOL)             '搬送引当量
                            ' ''objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                            ' ''objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
                            ' ''objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
                            objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK", strXTANA_BLOCK)            '棚ﾌﾞﾛｯｸ
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_DTL", strXTANA_BLOCK_DTL)    '棚ﾌﾞﾛｯｸ詳細
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_STS", strXTANA_BLOCK_STS)    '棚ﾌﾞﾛｯｸ状態


                        ElseIf blnTANA2_KARA = False Then
                            '(在庫情報がある場合)

                            If strFREMOVE_KIND = "9" Then
                                '(無効棚である場合)
                                ' ''Throw New Exception(TO_STRING(ii + 1) & "行目棚2でｴﾗｰ発生。" & vbCrLf & "在庫の追加先が無効棚です。" & "[列連段枝:" & objTPRG_TRK_BUF.FRAC_RETU & "-" & objTPRG_TRK_BUF.FRAC_REN & "-" & objTPRG_TRK_BUF.FRAC_DAN & "-" & objTPRG_TRK_BUF.FRAC_EDA & "]")
                            End If

                            strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_INSERT               '処理区分
                            'ﾊﾞｯﾌｧ№
                            'ﾊﾞｯﾌｧ配列№
                            If blnFREMOVE_KIND = True Then                              '禁止棚設定
                                strFREMOVE_KIND = FREMOVE_KIND_SON
                            Else
                                strFREMOVE_KIND = FREMOVE_KIND_SNORMAL
                            End If
                            '棚形状種別
                            strFRES_KIND = FRES_KIND_SZAIKO                             '引当状態=在庫
                            strFHINMEI_CD = strFHINMEI_CD                               '品名ｺｰﾄﾞ
                            strFLOT_NO = strSUBKEY1_XPROD_LINE.Trim & strSUBKEY1_FBUF_IN_DT     'ﾛｯﾄNo.(生産ﾗｲﾝ + 入庫年月日)
                            '在庫年月日
                            strFARRIVE_DT = strSUBKEY1_FBUF_IN_DT.Substring(0, 4) & "/" & strSUBKEY1_FBUF_IN_DT.Substring(4, 2) & "/" & strSUBKEY1_FBUF_IN_DT.Substring(6, 2) & " " & _
                                            strSUBKEY1_FBUF_IN_DT_TIME.Substring(0, 2) & ":" & strSUBKEY1_FBUF_IN_DT_TIME.Substring(2, 2) & ":" & strSUBKEY1_FBUF_IN_DT_TIME.Substring(4, 2)
                            '入庫区分
                            If strSUBKEY1_FIN_KUBUN = "91" Then
                                '(持戻り品)
                                strFIN_KUBUN = FIN_KUBUN_J04

                            ElseIf strSUBKEY1_FIN_KUBUN = "92" Then
                                '(再入棚品)
                                strFIN_KUBUN = FIN_KUBUN_J06

                            ElseIf strSUBKEY1_FIN_KUBUN = "93" Then
                                '(外部品)
                                strFIN_KUBUN = FIN_KUBUN_J02

                            ElseIf strSUBKEY1_FIN_KUBUN = "98" Then
                                '(生産入庫品)
                                strFIN_KUBUN = FIN_KUBUN_J01

                            ElseIf strSUBKEY1_FIN_KUBUN = "99" Then
                                '(その他)
                                strFIN_KUBUN = FIN_KUBUN_J05

                            End If
                            strFHORYU_KUBUN = FHORYU_KUBUN_SNORMAL                      '保留区分=通常品
                            strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            strFTR_VOL = strDATA1_TANA2_FTR_VOL                         '搬送管理量(棚2)
                            If TO_INTEGER(strDATA1_TANA2_FHASUU_FLAG) = 1 Then          '端数ﾌﾗｸﾞ(棚2)
                                '(端数の場合)
                                strFHASU_FLAG = "1"

                            ElseIf TO_INTEGER(strDATA1_TANA2_FHASUU_FLAG) = 2 Then
                                '(ﾌﾙPLの場合)
                                strFHASU_FLAG = "0"

                            End If
                            '棚分類
                            'ﾊﾞｯﾌｧ入日時(棚2)
                            strFBUF_IN_DT = strDATA1_TANA2_FBUF_IN_DT.Substring(0, 4) & "/" & strDATA1_TANA2_FBUF_IN_DT.Substring(4, 2) & "/" & strDATA1_TANA2_FBUF_IN_DT.Substring(6, 2) & " " & _
                                            strDATA1_TANA2_FBUF_IN_DT_TIME.Substring(0, 2) & ":" & strDATA1_TANA2_FBUF_IN_DT_TIME.Substring(2, 2) & ":" & strDATA1_TANA2_FBUF_IN_DT_TIME.Substring(4, 2)
                            '棚ﾌﾞﾛｯｸ
                            '棚ﾌﾞﾛｯｸ詳細
                            '棚ﾌﾞﾛｯｸ状態
                            strXPROD_LINE = strSUBKEY1_XPROD_LINE.Trim                  '生産ﾗｲﾝNo.
                            strXKENSA_KUBUN = XKENSA_KUBUN_J_OK                         '検査区分
                            strXKENPIN_KUBUN = XKENPIN_KUBUN_J_MI                       '検品区分


                            objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                            objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO2)                'ﾊﾞｯﾌｧ№2
                            objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY2)          'ﾊﾞｯﾌｧ配列№2
                            objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                            objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                            objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態
                            objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
                            objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                            objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                            objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                            objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            objTelegram.SETIN_DATA("DSPTR_VOL", TO_INTEGER(strFTR_VOL))                     '搬送管理量
                            objTelegram.SETIN_DATA("DSPTR_RES_VOL", "0")                        '搬送引当量
                            objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                            objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
                            objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
                            objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類
                            objTelegram.SETIN_DATA("DSPBUF_IN_DT", strFBUF_IN_DT)               'ﾊﾞｯﾌｧ入日時
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK", strXTANA_BLOCK)            '棚ﾌﾞﾛｯｸ
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_DTL", strXTANA_BLOCK_DTL)    '棚ﾌﾞﾛｯｸ詳細
                            objTelegram.SETIN_DATA("XDSPTANA_BLOCK_STS", strXTANA_BLOCK_STS)    '棚ﾌﾞﾛｯｸ状態
                            objTelegram.SETIN_DATA("XDSPKENSA_KUBUN", strXKENSA_KUBUN)          '検査区分
                            objTelegram.SETIN_DATA("XDSPKENPIN_KUBUN", strXKENPIN_KUBUN)        '検品区分
                            objTelegram.SETIN_DATA("XDSPRAC_IN_DT", strFBUF_IN_DT)              '入庫日時=ﾊﾞｯﾌｧ入日時と同じ
                            objTelegram.SETIN_DATA("DSPUPDATE_DT", strFUPDATE_DT)               '更新日時

                            If strSUBKEY1_XPROD_LINE.Trim.Length <= 3 Then
                                '(3ﾊﾞｲﾄ以下=ﾒｰｶｺｰﾄﾞ)
                                objTelegram.SETIN_DATA("XDSPPROD_LINE", "")                     '生産ﾗｲﾝNo
                                objTelegram.SETIN_DATA("XDSPMAKER_CD", strXPROD_LINE)           'ﾒｰｶｺｰﾄﾞ

                            Else
                                '(3ﾊﾞｲﾄ以上=生産ﾗｲﾝNo.)
                                objTelegram.SETIN_DATA("XDSPPROD_LINE", strXPROD_LINE)          '生産ﾗｲﾝNo
                                objTelegram.SETIN_DATA("XDSPMAKER_CD", "")                      'ﾒｰｶｺｰﾄﾞ

                            End If



                        End If

                        '*******************************************************
                        'ｿｹｯﾄ送信
                        '*******************************************************
                        If blnSockSend = True Then
                            Dim strRET_STATE As String = ""
                            Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
                            Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

                            strErrMsg = "在庫移行に失敗しました。"
                            udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
                            If udtSckSendRET = clsSocketClient.RetCode.OK Then
                                '(送信できた場合)
                                If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                                    '(正常終了の場合)
                                    blnRet = True
                                End If
                            End If

                            If blnRet = False Then
                                Throw New Exception(TO_STRING(ii + 1) & "行目棚2でｴﾗｰ発生。")
                            End If

                        End If


                        '' ''******************************************************************************************************************
                        '' ''
                        '' '' 棚3 電文作成
                        '' ''
                        '' ''******************************************************************************************************************

                        '' ''========================================
                        '' '' 変数初期化
                        '' ''========================================
                        ' ''strDIR_KUBUN = ""                             '処理区分
                        ' ''strFBUF_NO3 = ""                              'ﾊﾞｯﾌｧ№3
                        ' ''strFBUF_ARRAY3 = ""                           'ﾊﾞｯﾌｧ配列№3
                        ' ''strFREMOVE_KIND = ""                          '禁止棚設定
                        ' ''strFRAC_FORM = ""                             '棚形状種別
                        ' ''strFRES_KIND = ""                             '引当状態
                        '' '' ''strFHINMEI_CD = ""                            '品名記号
                        ' ''strFLOT_NO = ""                               'ﾛｯﾄ№
                        ' ''strFARRIVE_DT = ""                            '在庫発生日時
                        ' ''strFIN_KUBUN = ""                             '入庫区分
                        ' ''strFSEIHIN_KUBUN = ""                         '製品区分
                        ' ''strFZAIKO_KUBUN = ""                          '在庫区分
                        ' ''strFHORYU_KUBUN = ""                          '保留区分
                        ' ''strFST_FM = ""                                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        ' ''strFTR_VOL = ""                               '搬送管理量
                        ' ''strFTR_RES_VOL = ""                           '搬送引当量
                        ' ''strFPALLET_ID = ""                            'ﾊﾟﾚｯﾄID
                        ' ''strFLOT_NO_STOCK = ""                         '在庫ﾛｯﾄ№
                        ' ''strFLABEL_ID = ""                             'ﾗﾍﾞﾙID
                        ' ''strFHASU_FLAG = ""                            '端数ﾌﾗｸﾞ
                        ' ''strFSYUKKA_TO_CD = ""                         '出荷先ｺｰﾄﾞ
                        ' ''strFSYUKKA_TO_NAME = ""                       '出荷先名称
                        ' ''strFRAC_BUNRUI = ""                           '棚分類
                        ' ''strFBUF_IN_DT = ""                            'ﾊﾞｯﾌｧ入日時
                        ' ''strXTANA_BLOCK = ""                           '棚ﾌﾞﾛｯｸ
                        ' ''strXTANA_BLOCK_DTL = ""                       '棚ﾌﾞﾛｯｸ詳細
                        ' ''strXTANA_BLOCK_STS = ""                       '棚ﾌﾞﾛｯｸ状態
                        ' ''strXPROD_LINE = ""                            '生産ﾗｲﾝNo.
                        ' ''strXKENSA_KUBUN = ""                          '検査区分
                        ' ''strXKENPIN_KUBUN = ""                         '検品区分

                        ' ''objTelegram = Nothing
                        ' ''objTelegram = New clsTelegram(CONFIG_TELEGRAM_DSP)
                        ' ''objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

                        '' ''*******************************************************
                        '' ''ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ取得
                        '' ''*******************************************************
                        ' ''objTPRG_TRK_BUF = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
                        '' ''(手前 偶数)
                        ' ''objTPRG_TRK_BUF.FRAC_RETU = TO_INTEGER(strMAINKEY_FRAC_RETU)    '列
                        ' ''objTPRG_TRK_BUF.FRAC_REN = TO_INTEGER(strMAINKEY_FRAC_REN)   '連
                        ' ''objTPRG_TRK_BUF.FRAC_DAN = TO_INTEGER(strMAINKEY_FRAC_DAN)      '段
                        ' ''objTPRG_TRK_BUF.FRAC_EDA = 0                                    '枝
                        ' ''intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                     '取得
                        ' ''If intRet <> RetCode.OK Then
                        ' ''    Throw New Exception(TO_STRING(ii + 1) & "行目棚3でｴﾗｰ発生。" & vbCrLf & ERRMSG_NOTFOUND_BUF & "[列連段枝:" & objTPRG_TRK_BUF.FRAC_RETU & "-" & objTPRG_TRK_BUF.FRAC_REN & "-" & objTPRG_TRK_BUF.FRAC_DAN & "-" & objTPRG_TRK_BUF.FRAC_EDA & "]")
                        ' ''End If

                        ' ''strFBUF_NO3 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO)                'ﾊﾞｯﾌｧ№3
                        ' ''strFBUF_ARRAY3 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY)          'ﾊﾞｯﾌｧ配列№3
                        ' ''strFRAC_FORM = TO_STRING(objTPRG_TRK_BUF.FRAC_FORM)                 '棚形状種別
                        ' ''strFRAC_BUNRUI = TO_STRING(objTPRG_TRK_BUF.FRAC_BUNRUI)             '棚分類
                        ' ''strXTANA_BLOCK = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK)             '棚ﾌﾞﾛｯｸ
                        ' ''strXTANA_BLOCK_DTL = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_DTL)     '棚ﾌﾞﾛｯｸ詳細
                        ' ''strXTANA_BLOCK_STS = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_STS)     '棚ﾌﾞﾛｯｸ状態
                        ' ''strFREMOVE_KIND = TO_STRING(objTPRG_TRK_BUF.FREMOVE_KIND)           '禁止状態

                        ' ''objTPRG_TRK_BUF.Close()

                        '' ''*******************************************************
                        '' ''空棚か確認
                        '' ''*******************************************************
                        ' ''If blnTANA3_KARA = False Then
                        ' ''    '(空棚の場合、確認不要)
                        ' ''    If strDATA1_TANA3_FBUF_IN_DT.Trim = "" Or _
                        ' ''       TO_INTEGER(strDATA1_TANA3_FBUF_IN_DT) = 0 Then
                        ' ''        '(棚3の入庫年月日が設定されていない場合)
                        ' ''        blnTANA3_KARA = True
                        ' ''    End If
                        ' ''End If

                        ' ''If blnTANA3_KARA = True Then
                        ' ''    '(在庫なし)

                        ' ''    strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK         '処理区分
                        ' ''    'ﾊﾞｯﾌｧ№
                        ' ''    'ﾊﾞｯﾌｧ配列№
                        ' ''    strFREMOVE_KIND = 9                                         '禁止棚設定
                        ' ''    '棚形状種別
                        ' ''    strFRES_KIND = FRES_KIND_SAKI                               '引当状態=空
                        ' ''    strFHINMEI_CD = ""                                          '品名ｺｰﾄﾞ
                        ' ''    strFLOT_NO = ""                                             'ﾛｯﾄNo.
                        ' ''    strFARRIVE_DT = ""                                          '在庫発生日時
                        ' ''    strFIN_KUBUN = ""                                           '入庫区分
                        ' ''    strFHORYU_KUBUN = ""                                        '保留区分
                        ' ''    strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        ' ''    strFTR_VOL = ""                                             '数量
                        ' ''    '棚分類
                        ' ''    '棚ﾌﾞﾛｯｸ
                        ' ''    '棚ﾌﾞﾛｯｸ詳細
                        ' ''    '棚ﾌﾞﾛｯｸ状態

                        ' ''    objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                        ' ''    objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO3)                'ﾊﾞｯﾌｧ№
                        ' ''    objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY3)          'ﾊﾞｯﾌｧ配列№
                        ' ''    objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                        ' ''    objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                        ' ''    objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態
                        ' ''    objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
                        ' ''    objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                        ' ''    objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                        ' ''    objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                        ' ''    objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                        ' ''    objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        ' ''    objTelegram.SETIN_DATA("DSPTR_VOL", strFTR_VOL)                     '搬送管理量
                        ' ''    ' ''objTelegram.SETIN_DATA("DSPTR_RES_VOL", strFTR_RES_VOL)             '搬送引当量
                        ' ''    ' ''objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                        ' ''    ' ''objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
                        ' ''    ' ''objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
                        ' ''    objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類
                        ' ''    objTelegram.SETIN_DATA("XDSPTANA_BLOCK", strXTANA_BLOCK)            '棚ﾌﾞﾛｯｸ
                        ' ''    objTelegram.SETIN_DATA("XDSPTANA_BLOCK_DTL", strXTANA_BLOCK_DTL)    '棚ﾌﾞﾛｯｸ詳細
                        ' ''    objTelegram.SETIN_DATA("XDSPTANA_BLOCK_STS", strXTANA_BLOCK_STS)    '棚ﾌﾞﾛｯｸ状態

                        ' ''End If

                        '' ''*******************************************************
                        '' ''ｿｹｯﾄ送信
                        '' ''*******************************************************
                        ' ''If blnSockSend = True Then
                        ' ''    Dim strRET_STATE As String = ""
                        ' ''    Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
                        ' ''    Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

                        ' ''    strErrMsg = "在庫移行に失敗しました。"
                        ' ''    udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
                        ' ''    If udtSckSendRET = clsSocketClient.RetCode.OK Then
                        ' ''        '(送信できた場合)
                        ' ''        If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                        ' ''            '(正常終了の場合)
                        ' ''            blnRet = True
                        ' ''        End If
                        ' ''    End If

                        ' ''    If blnRet = False Then
                        ' ''        Throw New Exception(TO_STRING(ii + 1) & "行目棚3でｴﾗｰ発生。")
                        ' ''    End If

                        ' ''End If



                        '' ''******************************************************************************************************************
                        '' ''
                        '' '' 棚4 電文作成
                        '' ''
                        '' ''******************************************************************************************************************

                        '' ''========================================
                        '' '' 変数初期化
                        '' ''========================================
                        ' ''strDIR_KUBUN = ""                             '処理区分
                        ' ''strFBUF_NO4 = ""                              'ﾊﾞｯﾌｧ№4
                        ' ''strFBUF_ARRAY4 = ""                           'ﾊﾞｯﾌｧ配列№4
                        ' ''strFREMOVE_KIND = ""                          '禁止棚設定
                        ' ''strFRAC_FORM = ""                             '棚形状種別
                        ' ''strFRES_KIND = ""                             '引当状態
                        '' '' ''strFHINMEI_CD = ""                            '品名記号
                        ' ''strFLOT_NO = ""                               'ﾛｯﾄ№
                        ' ''strFARRIVE_DT = ""                            '在庫発生日時
                        ' ''strFIN_KUBUN = ""                             '入庫区分
                        ' ''strFSEIHIN_KUBUN = ""                         '製品区分
                        ' ''strFZAIKO_KUBUN = ""                          '在庫区分
                        ' ''strFHORYU_KUBUN = ""                          '保留区分
                        ' ''strFST_FM = ""                                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        ' ''strFTR_VOL = ""                               '搬送管理量
                        ' ''strFTR_RES_VOL = ""                           '搬送引当量
                        ' ''strFPALLET_ID = ""                            'ﾊﾟﾚｯﾄID
                        ' ''strFLOT_NO_STOCK = ""                         '在庫ﾛｯﾄ№
                        ' ''strFLABEL_ID = ""                             'ﾗﾍﾞﾙID
                        ' ''strFHASU_FLAG = ""                            '端数ﾌﾗｸﾞ
                        ' ''strFSYUKKA_TO_CD = ""                         '出荷先ｺｰﾄﾞ
                        ' ''strFSYUKKA_TO_NAME = ""                       '出荷先名称
                        ' ''strFRAC_BUNRUI = ""                           '棚分類
                        ' ''strFBUF_IN_DT = ""                            'ﾊﾞｯﾌｧ入日時
                        ' ''strXTANA_BLOCK = ""                           '棚ﾌﾞﾛｯｸ
                        ' ''strXTANA_BLOCK_DTL = ""                       '棚ﾌﾞﾛｯｸ詳細
                        ' ''strXTANA_BLOCK_STS = ""                       '棚ﾌﾞﾛｯｸ状態
                        ' ''strXPROD_LINE = ""                            '生産ﾗｲﾝNo.
                        ' ''strXKENSA_KUBUN = ""                          '検査区分
                        ' ''strXKENPIN_KUBUN = ""                         '検品区分

                        ' ''objTelegram = Nothing
                        ' ''objTelegram = New clsTelegram(CONFIG_TELEGRAM_DSP)
                        ' ''objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

                        '' ''*******************************************************
                        '' ''ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ取得
                        '' ''*******************************************************
                        ' ''objTPRG_TRK_BUF = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
                        '' ''(手前 奇数)
                        ' ''objTPRG_TRK_BUF.FRAC_RETU = TO_INTEGER(strMAINKEY_FRAC_RETU)    '列
                        ' ''objTPRG_TRK_BUF.FRAC_REN = TO_INTEGER(strMAINKEY_FRAC_REN) - 1     '連
                        ' ''objTPRG_TRK_BUF.FRAC_DAN = TO_INTEGER(strMAINKEY_FRAC_DAN)      '段
                        ' ''objTPRG_TRK_BUF.FRAC_EDA = 0                                    '枝
                        ' ''intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()                     '取得
                        ' ''If intRet <> RetCode.OK Then
                        ' ''    Throw New Exception(TO_STRING(ii + 1) & "行目棚4でｴﾗｰ発生。" & vbCrLf & ERRMSG_NOTFOUND_BUF & "[列連段枝:" & objTPRG_TRK_BUF.FRAC_RETU & "-" & objTPRG_TRK_BUF.FRAC_REN & "-" & objTPRG_TRK_BUF.FRAC_DAN & "-" & objTPRG_TRK_BUF.FRAC_EDA & "]")
                        ' ''End If

                        ' ''strFBUF_NO4 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO)                'ﾊﾞｯﾌｧ№4
                        ' ''strFBUF_ARRAY4 = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY)          'ﾊﾞｯﾌｧ配列№4
                        ' ''strFRAC_FORM = TO_STRING(objTPRG_TRK_BUF.FRAC_FORM)                 '棚形状種別
                        ' ''strFRAC_BUNRUI = TO_STRING(objTPRG_TRK_BUF.FRAC_BUNRUI)             '棚分類
                        ' ''strXTANA_BLOCK = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK)             '棚ﾌﾞﾛｯｸ
                        ' ''strXTANA_BLOCK_DTL = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_DTL)     '棚ﾌﾞﾛｯｸ詳細
                        ' ''strXTANA_BLOCK_STS = TO_STRING(objTPRG_TRK_BUF.XTANA_BLOCK_STS)     '棚ﾌﾞﾛｯｸ状態
                        ' ''strFREMOVE_KIND = TO_STRING(objTPRG_TRK_BUF.FREMOVE_KIND)           '禁止状態

                        ' ''objTPRG_TRK_BUF.Close()

                        '' ''*******************************************************
                        '' ''空棚か確認
                        '' ''*******************************************************
                        ' ''If blnTANA4_KARA = False Then
                        ' ''    '(空棚の場合、確認不要)
                        ' ''    If strDATA1_TANA4_FBUF_IN_DT.Trim = "" Or _
                        ' ''       TO_INTEGER(strDATA1_TANA4_FBUF_IN_DT) = 0 Then
                        ' ''        '(棚4の入庫年月日が設定されていない場合)
                        ' ''        blnTANA4_KARA = True
                        ' ''    End If
                        ' ''End If


                        ' ''If blnTANA4_KARA = True Then
                        ' ''    '(在庫なし)

                        ' ''    strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK         '処理区分
                        ' ''    'ﾊﾞｯﾌｧ№
                        ' ''    'ﾊﾞｯﾌｧ配列№
                        ' ''    strFREMOVE_KIND = "9"                                       '禁止棚設定
                        ' ''    '棚形状種別
                        ' ''    strFRES_KIND = FRES_KIND_SAKI                               '引当状態=空
                        ' ''    strFHINMEI_CD = ""                                          '品名ｺｰﾄﾞ
                        ' ''    strFLOT_NO = ""                                             'ﾛｯﾄNo.
                        ' ''    strFARRIVE_DT = ""                                          '在庫発生日時
                        ' ''    strFIN_KUBUN = ""                                           '入庫区分
                        ' ''    strFHORYU_KUBUN = ""                                        '保留区分
                        ' ''    strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        ' ''    strFTR_VOL = ""                                             '数量
                        ' ''    '棚分類
                        ' ''    '棚ﾌﾞﾛｯｸ
                        ' ''    '棚ﾌﾞﾛｯｸ詳細
                        ' ''    '棚ﾌﾞﾛｯｸ状態

                        ' ''    objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
                        ' ''    objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO4)                'ﾊﾞｯﾌｧ№4
                        ' ''    objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY4)          'ﾊﾞｯﾌｧ配列№4
                        ' ''    objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
                        ' ''    objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
                        ' ''    objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態
                        ' ''    objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
                        ' ''    objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
                        ' ''    objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
                        ' ''    objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
                        ' ''    objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
                        ' ''    objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        ' ''    objTelegram.SETIN_DATA("DSPTR_VOL", strFTR_VOL)                     '搬送管理量
                        ' ''    ' ''objTelegram.SETIN_DATA("DSPTR_RES_VOL", strFTR_RES_VOL)             '搬送引当量
                        ' ''    ' ''objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
                        ' ''    ' ''objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
                        ' ''    ' ''objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
                        ' ''    objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類
                        ' ''    objTelegram.SETIN_DATA("XDSPTANA_BLOCK", strXTANA_BLOCK)            '棚ﾌﾞﾛｯｸ
                        ' ''    objTelegram.SETIN_DATA("XDSPTANA_BLOCK_DTL", strXTANA_BLOCK_DTL)    '棚ﾌﾞﾛｯｸ詳細
                        ' ''    objTelegram.SETIN_DATA("XDSPTANA_BLOCK_STS", strXTANA_BLOCK_STS)    '棚ﾌﾞﾛｯｸ状態

                        ' ''End If

                        '' ''*******************************************************
                        '' ''ｿｹｯﾄ送信
                        '' ''*******************************************************
                        ' ''If blnSockSend = True Then
                        ' ''    Dim strRET_STATE As String = ""
                        ' ''    Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
                        ' ''    Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

                        ' ''    strErrMsg = "在庫移行に失敗しました。"
                        ' ''    udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
                        ' ''    If udtSckSendRET = clsSocketClient.RetCode.OK Then
                        ' ''        '(送信できた場合)
                        ' ''        If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                        ' ''            '(正常終了の場合)
                        ' ''            blnRet = True
                        ' ''        End If
                        ' ''    End If

                        ' ''    If blnRet = False Then
                        ' ''        Throw New Exception(TO_STRING(ii + 1) & "行目棚4でｴﾗｰ発生。")
                        ' ''    End If

                        ' ''End If




                    End If

                Next


            Catch ex As Exception
                Call gobjComFuncFRM.ComError_frm(ex)
                'MsgBox(ex.Message)
            Finally

                '*******************************************************
                '後始末
                '*******************************************************
                objTextFieldParser01.Close()

            End Try


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            'MsgBox(ex.Message)
        End Try

        '*******************************************************
        '終了宣言
        '*******************************************************
        gobjComFuncFRM.AddToLog_frm("在庫移行終了:" & Format(Now, "yyyy/MM/dd HH:mm:ss"), AddToLog_D_ErrorType.USER_LOG, "")

    End Sub
#End Region

#Region "  SHIP在庫ﾃﾞｰﾀ更新処理                 "
    '''***********************************************************************************************************************************
    ''' <summary>
    ''' 在庫移行処理SHIP在庫ﾃﾞｰﾀ更新処理
    ''' </summary>
    ''' <remarks></remarks>
    '''***********************************************************************************************************************************
    Private Sub SHIP_UPDATE()
        ' ''    Try

        ' ''        Dim objStock As New System.Collections.ArrayList()          'SHIPﾌｧｲﾙ      ﾃﾞｰﾀﾌｧｲﾙｵﾌﾞｼﾞｪｸﾄ
        ' ''        Dim strcsvFileName01 As String = txtReadFile02.Text         'SHIPﾌｧｲﾙ名
        ' ''        Dim objTextFieldParser01 As New FileIO.TextFieldParser(strcsvFileName01, System.Text.Encoding.GetEncoding(932))     'Shift JISで読み込む

        ' ''        Try
        ' ''            Dim intRet As RetCode
        ' ''            Dim blnRet As Boolean = False
        ' ''            Dim dtmNow As Date = Now

        ' ''            '*******************************************************
        ' ''            '色々設定
        ' ''            '*******************************************************
        ' ''            'ﾃﾞﾘﾐﾀ設定
        ' ''            objTextFieldParser01.TextFieldType = FileIO.FieldType.Delimited
        ' ''            'objTextFieldParser01.Delimiters = New String() {","}
        ' ''            objTextFieldParser01.Delimiters = New String() {vbTab}              'ﾀﾌﾞ区切り
        ' ''            'ﾌｨｰﾙﾄﾞを"で囲み、改行文字、区切り文字を含めることができるか
        ' ''            objTextFieldParser01.HasFieldsEnclosedInQuotes = False
        ' ''            'ﾌｨｰﾙﾄﾞの前後からｽﾍﾟｰｽを削除する
        ' ''            objTextFieldParser01.TrimWhiteSpace = False


        ' ''            '*******************************************************
        ' ''            'ﾃｷｽﾄﾌｧｲﾙ読込
        ' ''            '*******************************************************
        ' ''            While Not objTextFieldParser01.EndOfData
        ' ''                '(ﾙｰﾌﾟ:ﾚｺｰﾄﾞ数)
        ' ''                Dim strfields As String() = objTextFieldParser01.ReadFields()       'ﾌｨｰﾙﾄﾞを読み込む
        ' ''                objStock.Add(strfields)                                             '保存
        ' ''            End While


        ' ''            '*******************************************************
        ' ''            '*******************************************************
        ' ''            'ｿｹｯﾄ送信処理
        ' ''            '*******************************************************
        ' ''            '*******************************************************
        ' ''            'Dim strSendTel() As String = Nothing        '送信電文配列

        ' ''            For ii As Integer = 0 To objStock.Count - 1
        ' ''                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


        ' ''                '*******************************************************
        ' ''                '進捗更新
        ' ''                '*******************************************************
        ' ''                lblProgress.Text = TO_STRING(ii) & "/" & TO_STRING(objStock.Count - 1)
        ' ''                Me.Refresh()
        ' ''                System.Windows.Forms.Application.DoEvents()


        ' ''                '*******************************************************
        ' ''                '正しいCSVかﾁｪｯｸ
        ' ''                '*******************************************************
        ' ''                If UBound(objStock.Item(ii)) <> F02_ECC_SURYOU Then Continue For


        ' ''                '*******************************************************
        ' ''                'ﾊﾞｲﾊﾟｽ 条件
        ' ''                '*******************************************************
        ' ''                If (Mid(TO_STRING(objStock.Item(ii)(F02_FHINMEI_CD)), 1, 1) = "3") Or _
        ' ''                   (Mid(TO_STRING(objStock.Item(ii)(F02_FHINMEI_CD)), 1, 1) = "4") Then
        ' ''                    '(品目ｺｰﾄﾞの先頭１桁目、3、4は、読み飛ばし)
        ' ''                    Continue For
        ' ''                End If

        ' ''                If TO_STRING(objStock.Item(ii)(F02_XPALLET_EDA)) = "O" Then
        ' ''                    '(検査区分が0は、更新不要、読み飛ばし)
        ' ''                    Continue For
        ' ''                End If



        ' ''                ''*******************************************************
        ' ''                ''配列定義
        ' ''                ''*******************************************************
        ' ''                'If IsNull(strSendTel) Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)


        ' ''                '*******************************************************
        ' ''                '在庫情報 取得
        ' ''                '*******************************************************
        ' ''                Dim strDIR_KUBUN As String = FORMAT_DSP_DSPDIR_KUBUN_UPDATE     '指示区分 = 「更新」


        ' ''                Dim objTRST_STOCK As New TBL_TRST_STOCK(gobjOwner, gobjDb, Nothing)
        ' ''                If Mid(TO_STRING(objStock.Item(ii)(F02_FHINMEI_CD)), 1, 1) = "2" Then
        ' ''                    '(品目ｺｰﾄﾞの先頭1桁目が2の時)
        ' ''                    objTRST_STOCK.FHINMEI_CD = "0" & Mid(TO_STRING(objStock.Item(ii)(F02_FHINMEI_CD)), 2)         '品目ｺｰﾄﾞ
        ' ''                Else
        ' ''                    '(以外の時)
        ' ''                    objTRST_STOCK.FHINMEI_CD = TO_STRING(objStock.Item(ii)(F02_FHINMEI_CD))                       '品目ｺｰﾄﾞ
        ' ''                End If

        ' ''                intRet = objTRST_STOCK.GET_TRST_STOCK(False)
        ' ''                If intRet <> RetCode.OK Then
        ' ''                    Continue For                                                                '在庫情報無し、読み飛ばし
        ' ''                    '    Throw New Exception(ERRMSG_NOTFOUND_TRST_STOCK & _
        ' ''                    '                        "[品目ｺｰﾄﾞ:" & objTRST_STOCK.FHINMEI_CD & "]," & _
        ' ''                    '                        "[製造年月日:" & objTRST_STOCK.XSEIZOU_DT & "]," & _
        ' ''                    '                        "[ﾗｲﾝ№:" & objTRST_STOCK.XLINE_NO & "]," & _
        ' ''                    '                        "[ﾊﾟﾚｯﾄ№:" & objTRST_STOCK.XPALLET_NO & "]")
        ' ''                End If


        ' ''                Dim strFHINMEI_CD_CNV As String = ""                                '変換後品名ｺｰﾄﾞ
        ' ''                strFHINMEI_CD_CNV = objTRST_STOCK.FHINMEI_CD                        '変換後品名ｺｰﾄﾞ


        ' ''                '*******************************************************
        ' ''                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ取得
        ' ''                '*******************************************************
        ' ''                Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
        ' ''                objTPRG_TRK_BUF.FPALLET_ID = objTRST_STOCK.FPALLET_ID           'ﾊﾟﾚｯﾄID
        ' ''                intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(False)                     '取得
        ' ''                If intRet <> RetCode.OK Then
        ' ''                    Continue For                                                                '在庫情報無し、読み飛ばし
        ' ''                End If





        ' ''                '*******************************************************
        ' ''                'ｿｹｯﾄ送信処理
        ' ''                '*******************************************************

        ' ''                '********************************************************************
        ' ''                '日付文字列作成
        ' ''                '********************************************************************
        ' ''                Dim strFARRIVE_DTDate As String                              '在庫発生日時
        ' ''                'strFARRIVE_DTDate = Now
        ' ''                strFARRIVE_DTDate = Format(objTRST_STOCK.FARRIVE_DT, "yyyy/MM/dd HH:mm:ss")


        ' ''                '*******************************************************
        ' ''                'ｿｹｯﾄ送信処理
        ' ''                '*******************************************************
        ' ''                '========================================
        ' ''                ' 変数宣言
        ' ''                '========================================
        ' ''                Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        ' ''                'Dim strDIR_KUBUN As String = ""                             '処理区分
        ' ''                Dim strFBUF_NO As String = ""                               'ﾊﾞｯﾌｧ№
        ' ''                Dim strFBUF_ARRAY As String = ""                            'ﾊﾞｯﾌｧ配列№
        ' ''                Dim strFREMOVE_KIND As String = ""                          '禁止棚設定
        ' ''                Dim strFRAC_FORM As String = ""                             '棚形状種別
        ' ''                Dim strFRES_KIND As String = ""                             '引当状態

        ' ''                Dim strFHINMEI_CD As String = ""                            '品名ｺｰﾄﾞ
        ' ''                Dim strFLOT_NO As String = ""                               'ﾛｯﾄ№
        ' ''                Dim strFARRIVE_DT As String = ""                            '在庫発生日時
        ' ''                Dim strFIN_KUBUN As String = ""                             '入庫区分
        ' ''                Dim strFSEIHIN_KUBUN As String = ""                         '製品区分
        ' ''                Dim strFZAIKO_KUBUN As String = ""                          '在庫区分
        ' ''                Dim strFHORYU_KUBUN As String = ""                          '保留区分
        ' ''                Dim strFST_FM As String = ""                                '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        ' ''                Dim strFTR_VOL As String = ""                               '搬送管理量
        ' ''                Dim strFTR_RES_VOL As String = ""                           '搬送引当量
        ' ''                Dim strFPALLET_ID As String = ""                            'ﾊﾟﾚｯﾄID
        ' ''                Dim strFLOT_NO_STOCK As String = ""                         '在庫ﾛｯﾄ№
        ' ''                Dim strFLABEL_ID As String = ""                             'ﾗﾍﾞﾙID
        ' ''                Dim strFHASU_FLAG As String = ""                            '端数ﾌﾗｸﾞ
        ' ''                Dim strFSYUKKA_TO_CD As String = ""                         '出荷先ｺｰﾄﾞ
        ' ''                Dim strFSYUKKA_TO_NAME As String = ""                       '出荷先名称
        ' ''                Dim strFRAC_BUNRUI As String = ""                           '棚分類


        ' ''                '**********************************************************************************************
        ' ''                '↓↓↓ｼｽﾃﾑ固有

        ' ''                Dim strXDSPSEIZOU_DT As String = ""                         '製造年月日
        ' ''                Dim strXDSPLINE_NO As String = ""                           'ﾗｲﾝ№
        ' ''                Dim strXDSPPALLET_NO As String = ""                         'ﾊﾟﾚｯﾄ№
        ' ''                Dim strXDSPKENSA_KUBUN As String = ""                       '検査区分
        ' ''                Dim strXDSPAB_KUBUN As String = ""                          'AB区分
        ' ''                Dim strXDSPSYUKKA_KAHI As String = ""                       '出荷可否
        ' ''                Dim strXDSPSTRETCH_KUBUN As String = ""                     'ｽﾄﾚｯﾁ区分
        ' ''                Dim strXDSPHINSHITU_STS As String = ""                      '品質ｽﾃｰﾀｽ
        ' ''                Dim strXDSPLIMIT As String = ""                             '賞味期限
        ' ''                Dim strXDSPHORYU_NO As String = ""                          '保留№
        ' ''                Dim strXDSPHORYU_REASON As String = ""                      '保留理由
        ' ''                Dim strXASRS_IN_DT As String = ""                           '入庫日時
        ' ''                Dim strXDSPHORYU_DT As String = ""                          '保留年月日

        ' ''                '↑↑↑ｼｽﾃﾑ固有
        ' ''                '**********************************************************************************************


        ' ''                objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ


        ' ''                strFBUF_NO = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO)                 'ﾊﾞｯﾌｧ№
        ' ''                strFBUF_ARRAY = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY)           'ﾊﾞｯﾌｧ配列№
        ' ''                strFREMOVE_KIND = TO_STRING(objTPRG_TRK_BUF.FREMOVE_KIND)           '禁止棚設定
        ' ''                strFRAC_FORM = TO_STRING(objTPRG_TRK_BUF.FRAC_FORM)                 '棚形状種別
        ' ''                strFRES_KIND = TO_STRING(objTPRG_TRK_BUF.FRES_KIND)                 '引当状態

        ' ''                strFHINMEI_CD = strFHINMEI_CD_CNV                                   '品名ｺｰﾄﾞ
        ' ''                strFLOT_NO = ""                                                     'ﾛｯﾄ№
        ' ''                strFARRIVE_DT = strFARRIVE_DTDate                                   '在庫発生日時
        ' ''                'strFIN_KUBUN = ""                                                   '入庫区分
        ' ''                strFIN_KUBUN = "1"                                                  '入庫区分 に　「１」を。更新の目印！
        ' ''                strFSEIHIN_KUBUN = ""                                               '製品区分
        ' ''                strFZAIKO_KUBUN = ""                                                '在庫区分
        ' ''                strFHORYU_KUBUN = objTRST_STOCK.FHORYU_KUBUN                        '保留区分
        ' ''                strFST_FM = ""                                                      '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        ' ''                strFTR_VOL = TO_STRING(TO_DECIMAL(objTRST_STOCK.FTR_VOL))           '搬送管理量
        ' ''                strFTR_RES_VOL = TO_STRING(TO_DECIMAL(objTRST_STOCK.FTR_RES_VOL))   '搬送引当量
        ' ''                strFPALLET_ID = TO_STRING(objTPRG_TRK_BUF.FPALLET_ID)               'ﾊﾟﾚｯﾄID
        ' ''                strFLOT_NO_STOCK = ""                                               '在庫ﾛｯﾄ№
        ' ''                strFLABEL_ID = ""                                                   'ﾗﾍﾞﾙID

        ' ''                'Dim objTMST_ITEM As New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
        ' ''                'objTMST_ITEM.FHINMEI_CD = strFHINMEI_CD    '品目ｺｰﾄﾞ
        ' ''                'intRet = objTMST_ITEM.GET_TMST_ITEM(False)
        ' ''                'If intRet = RetCode.OK Then
        ' ''                '    '(読めた時)
        ' ''                '    If TO_INTEGER(strFTR_VOL) = objTMST_ITEM.FNUM_IN_PALLET Then
        ' ''                '        '(PL毎積載数と同じ時)
        ' ''                '        strFHASU_FLAG = FHASU_FLAG_SMANSU                               '端数ﾌﾗｸﾞ
        ' ''                '    Else
        ' ''                '        '(PL毎積載数と異なる時)
        ' ''                '        strFHASU_FLAG = FHASU_FLAG_SHASU                                '端数ﾌﾗｸﾞ
        ' ''                '    End If
        ' ''                'Else
        ' ''                '    '(読めなかった時)
        ' ''                '    strFHASU_FLAG = FHASU_FLAG_SMANSU                                   '端数ﾌﾗｸﾞ
        ' ''                'End If
        ' ''                strFHASU_FLAG = objTRST_STOCK.FHASU_FLAG                                 '端数ﾌﾗｸﾞ

        ' ''                strFSYUKKA_TO_CD = ""                                               '出荷先ｺｰﾄﾞ
        ' ''                strFSYUKKA_TO_NAME = ""                                             '出荷先名称
        ' ''                strFRAC_BUNRUI = TO_STRING(objTPRG_TRK_BUF.FRAC_FORM)               '棚分類



        ' ''                objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
        ' ''                objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strFBUF_NO)                 'ﾊﾞｯﾌｧ№
        ' ''                objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strFBUF_ARRAY)           'ﾊﾞｯﾌｧ配列№
        ' ''                objTelegram.SETIN_DATA("DSPREMOVE_KIND", strFREMOVE_KIND)           '禁止棚設定
        ' ''                objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                 '棚形状種別
        ' ''                objTelegram.SETIN_DATA("DSPRES_KIND", strFRES_KIND)                 '引当状態

        ' ''                objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)               '品名ｺｰﾄﾞ
        ' ''                objTelegram.SETIN_DATA("DSPLOT_NO", strFLOT_NO)                     'ﾛｯﾄ№
        ' ''                objTelegram.SETIN_DATA("DSPARRIVE_DT", strFARRIVE_DT)               '在庫発生日時
        ' ''                objTelegram.SETIN_DATA("DSPIN_KUBUN", strFIN_KUBUN)                 '入庫区分
        ' ''                objTelegram.SETIN_DATA("DSPSEIHIN_KUBUN", strFSEIHIN_KUBUN)         '製品区分
        ' ''                objTelegram.SETIN_DATA("DSPZAIKO_KUBUN", strFZAIKO_KUBUN)           '在庫区分
        ' ''                objTelegram.SETIN_DATA("DSPHORYU_KUBUN", strFHORYU_KUBUN)           '保留区分
        ' ''                objTelegram.SETIN_DATA("DSPST_FM", strFST_FM)                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        ' ''                objTelegram.SETIN_DATA("DSPTR_VOL", strFTR_VOL)                     '搬送管理量
        ' ''                objTelegram.SETIN_DATA("DSPTR_RES_VOL", strFTR_RES_VOL)             '搬送引当量
        ' ''                objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)               'ﾊﾟﾚｯﾄID
        ' ''                objTelegram.SETIN_DATA("DSPLOT_NO_STOCK", strFLOT_NO_STOCK)         '在庫ﾛｯﾄ№
        ' ''                objTelegram.SETIN_DATA("DSPLABEL_ID", strFLABEL_ID)                 'ﾗﾍﾞﾙID
        ' ''                objTelegram.SETIN_DATA("DSPHASU_FLAG", strFHASU_FLAG)               '端数ﾌﾗｸﾞ
        ' ''                objTelegram.SETIN_DATA("DSPSYUKKA_TO_CD", strFSYUKKA_TO_CD)         '出荷先ｺｰﾄﾞ
        ' ''                objTelegram.SETIN_DATA("DSPSYUKKA_TO_NAME", strFSYUKKA_TO_NAME)     '出荷先名称
        ' ''                objTelegram.SETIN_DATA("DSPRAC_BUNRUI", strFRAC_BUNRUI)             '棚分類


        ' ''                '**********************************************************************************************
        ' ''                '↓↓↓ｼｽﾃﾑ固有

        ' ''                objTelegram.SETIN_DATA("XDSPSEIZOU_DT", strXDSPSEIZOU_DT)           '製造年月日
        ' ''                objTelegram.SETIN_DATA("XDSPLINE_NO", strXDSPLINE_NO)               'ﾗｲﾝ№
        ' ''                objTelegram.SETIN_DATA("XDSPPALLET_NO", strXDSPPALLET_NO)           'ﾊﾟﾚｯﾄ№
        ' ''                objTelegram.SETIN_DATA("XDSPKENSA_KUBUN", strXDSPKENSA_KUBUN)       '検査区分
        ' ''                objTelegram.SETIN_DATA("XDSPAB_KUBUN", strXDSPAB_KUBUN)             'AB区分
        ' ''                objTelegram.SETIN_DATA("XDSPSYUKKA_KAHI", strXDSPSYUKKA_KAHI)       '出荷可否
        ' ''                objTelegram.SETIN_DATA("XDSPSTRETCH_KUBUN", strXDSPSTRETCH_KUBUN)   'ｽﾄﾚｯﾁ区分
        ' ''                objTelegram.SETIN_DATA("XDSPHINSHITU_STS", strXDSPHINSHITU_STS)     '品質ｽﾃｰﾀｽ
        ' ''                objTelegram.SETIN_DATA("XDSPLIMIT", strXDSPLIMIT)                   '賞味期限
        ' ''                objTelegram.SETIN_DATA("XDSPHORYU_NO", strXDSPHORYU_NO)             '保留№
        ' ''                objTelegram.SETIN_DATA("XDSPHORYU_REASON", strXDSPHORYU_REASON)     '保留理由
        ' ''                objTelegram.SETIN_DATA("XASRS_IN_DT", strXASRS_IN_DT)               '入庫日時
        ' ''                objTelegram.SETIN_DATA("XDSPHORYU_DT", strXDSPHORYU_DT)             '保留年月日

        ' ''                '↑↑↑ｼｽﾃﾑ固有
        ' ''                '**********************************************************************************************


        ' ''                '*******************************************************
        ' ''                'ｿｹｯﾄ送信
        ' ''                '*******************************************************
        ' ''                Dim strRET_STATE As String = ""
        ' ''                Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        ' ''                Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

        ' ''                strErrMsg = FRM_MSG_FRM205041_01
        ' ''                udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        ' ''                If udtSckSendRET = clsSocketClient.RetCode.OK Then
        ' ''                    '(送信できた場合)
        ' ''                    If strRET_STATE = ID_RETURN_RET_STATE_OK Then
        ' ''                        '(正常終了の場合)
        ' ''                        blnRet = True
        ' ''                    End If
        ' ''                End If

        ' ''                If blnRet = False Then
        ' ''                    Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。")
        ' ''                End If


        ' ''            Next


        ' ''        Catch ex As Exception
        ' ''            Call gobjComFuncFRM.ComError_frm(ex)
        ' ''            MsgBox(ex.Message)
        ' ''        Finally

        ' ''            '*******************************************************
        ' ''            '後始末
        ' ''            '*******************************************************
        ' ''            objTextFieldParser01.Close()

        ' ''        End Try

        ' ''    Catch ex As Exception
        ' ''        Call gobjComFuncFRM.ComError_frm(ex)
        ' ''        MsgBox(ex.Message)
        ' ''    End Try

    End Sub
#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim lngCount As Long = 0
        Dim lngEnd As Long = 100000

        lngEnd = txtTest.Text

        gobjComFuncFRM.AddToLog_frm("Test開始:" & Format(Now, "yyyy/MM/dd HH:mm:ss"), AddToLog_D_ErrorType.USER_LOG, "")

        For lngCount = 0 To lngEnd

            lblProgress.Text = lngCount & "/" & lngEnd

            Me.Refresh()
            System.Windows.Forms.Application.DoEvents()

        Next

        gobjComFuncFRM.AddToLog_frm("Test終了:" & Format(Now, "yyyy/MM/dd HH:mm:ss"), AddToLog_D_ErrorType.USER_LOG, "")

    End Sub

End Class