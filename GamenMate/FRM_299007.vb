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

Public Class FRM_299007

#Region "  共通変数                             "

    '在庫ﾃｰﾌﾞﾙ
    Private Const MAINKEY_XHINMEI_CD As Integer = 6         '品名ｺｰﾄﾞ

    Private Const SUBKEY1_商品区分 As Integer = 1           '商品区分(未使用)
    Private Const SUBKEY1_XHINMEI_CD As Integer = 6         '品名ｺｰﾄﾞ(未使用)

    Private Const DATA1_TOTALKSU As Integer = 8             '総在庫梱数(未使用)
    Private Const DATA1_TOTALHISU As Integer = 8            '総在庫梱数(未使用)

    Private Const DATA1_HIRA1KSU As Integer = 8             '平置1総梱数(検品ｴﾘｱ)
    Private Const DATA1_HIRA2KSU As Integer = 8             '平置2総梱数(平置き)
    Private Const DATA1_HIRA3KSU As Integer = 8             '平置3総梱数(未使用)



    Private Const DKA8310_MAINKEY_INDEX As Integer = 0      '項目1
    Private Const DKA8310_SUBKEY1_INDEX As Integer = 1      '項目2
    Private Const DKA8310_DATA1_INDEX As Integer = 2       '項目3

    Private Const DKA8310_MAINKEY_LENGTH As Integer = 6     '項目1 長さ
    Private Const DKA8310_SUBKEY1_LENGTH As Integer = 7     '項目2 長さ
    Private Const DKA8310_DATA1_LENGTH As Integer = 32     '項目3 長さ


    'ﾃﾞﾌｫﾙﾄ値
    Private Const DEFAULT_HUMEI As String = ""              'ﾃﾞﾌｫﾙﾄ値不明

#End Region

#Region "  平置き在庫削除                   ｸﾘｯｸ    "
    Private Sub cmd001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd001.Click
        Try

            Dim intRet As RetCode
            Dim blnRet As Boolean = False

            If MessageBox.Show("OK?", "", MessageBoxButtons.OKCancel) <> Windows.Forms.DialogResult.OK Then Return


            '****************************************************
            '平置き在庫情報取得
            '****************************************************
            Dim strSQL As String                        'SQL文
            Dim objRow As DataRow                       '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
            Dim objDataSet As New DataSet               'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）


            '============================================================
            'SELECT
            '============================================================
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "        TPRG_TRK_BUF.FTRK_BUF_NO "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            strSQL &= vbCrLf & "      , TPRG_TRK_BUF.FTRK_BUF_ARRAY "                           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
            strSQL &= vbCrLf & "      , TPRG_TRK_BUF.FREMOVE_KIND "                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.禁止棚設定
            strSQL &= vbCrLf & "      , TPRG_TRK_BUF.FRAC_FORM "                                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.棚形状種別
            strSQL &= vbCrLf & "      , TPRG_TRK_BUF.FRES_KIND "                                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.引当状態

            strSQL &= vbCrLf & "      , TRST_STOCK.FHINMEI_CD "                                 '在庫情報       .品名ｺｰﾄﾞ
            strSQL &= vbCrLf & "      , TRST_STOCK.FLOT_NO "                                    '在庫情報       .ﾛｯﾄ№
            strSQL &= vbCrLf & "      , TRST_STOCK.FARRIVE_DT "                                 '在庫情報       .在庫発生日時
            strSQL &= vbCrLf & "      , TRST_STOCK.FIN_KUBUN "                                  '在庫情報       .入庫区分
            strSQL &= vbCrLf & "      , TRST_STOCK.FSEIHIN_KUBUN "                              '在庫情報       .製品区分
            strSQL &= vbCrLf & "      , TRST_STOCK.FZAIKO_KUBUN "                               '在庫情報       .在庫区分
            strSQL &= vbCrLf & "      , TRST_STOCK.FHORYU_KUBUN "                               '在庫情報       .保留区分
            strSQL &= vbCrLf & "      , TRST_STOCK.FST_FM "                                     '在庫情報       .搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            strSQL &= vbCrLf & "      , TRST_STOCK.FTR_VOL "                                    '在庫情報       .搬送管理量
            strSQL &= vbCrLf & "      , TRST_STOCK.FTR_RES_VOL "                                '在庫情報       .搬送引当量
            strSQL &= vbCrLf & "      , TRST_STOCK.FPALLET_ID "                                 '在庫情報       .ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "      , TRST_STOCK.FLOT_NO_STOCK "                              '在庫情報       .在庫ﾛｯﾄ№

            '============================================================
            'FROM
            '============================================================
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "        TRST_STOCK "
            strSQL &= vbCrLf & "      , TPRG_TRK_BUF "

            '============================================================
            'WHERE
            '============================================================
            strSQL &= vbCrLf & " WHERE 0 = 0 "
            strSQL &= vbCrLf & "      AND TRST_STOCK.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = " & FTRK_BUF_NO_J9100 & " "

            '============================================================
            'ORDER BY
            '============================================================
            strSQL &= vbCrLf & " ORDER BY "
            strSQL &= vbCrLf & "        TPRG_TRK_BUF.FTRK_BUF_ARRAY "


            '-----------------------
            '抽出
            '-----------------------
            gobjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TRST_STOCK"
            gobjDb.GetDataSet(strDataSetName, objDataSet)

            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then

                Dim ii As Integer = 1
                Try
                    gobjDb.Commit()
                    gobjDb.BeginTrans()

                    '****************************************************
                    '在庫情報取得
                    '****************************************************
                    For Each objRow In objDataSet.Tables(strDataSetName).Rows
                        '(ﾙｰﾌﾟ:在庫数)

                        '*******************************************************
                        '進捗更新
                        '*******************************************************
                        lblProgress.Text = TO_STRING(ii) & "/" & TO_STRING(objDataSet.Tables(strDataSetName).Rows.Count)
                        Me.Refresh()
                        System.Windows.Forms.Application.DoEvents()


                        '****************************************************
                        '在庫情報取得
                        '****************************************************
                        Dim strDIR_KUBUN As String = ""     '指示区分
                        Dim intCount As Integer

                        Dim objCheck As New TBL_TRST_STOCK(gobjOwner, gobjDb, Nothing)
                        objCheck.FPALLET_ID = TO_STRING(objRow("FPALLET_ID"))    'ﾊﾟﾚｯﾄID
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
                        objTPRG_TRK_BUF.FPALLET_ID = TO_STRING(objRow("FPALLET_ID"))    'ﾊﾟﾚｯﾄID
                        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(False)
                        If intRet <> RetCode.OK Then
                            MsgBox("ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧが見つかりません。[ﾊﾟﾚｯﾄID:" & TO_STRING(objRow("FPALLET_ID")) & "]")
                            Continue For
                        End If

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


                        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

                        strFBUF_NO = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO)                 'ﾊﾞｯﾌｧ№
                        strFBUF_ARRAY = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY)           'ﾊﾞｯﾌｧ配列№
                        strFREMOVE_KIND = TO_STRING(objTPRG_TRK_BUF.FREMOVE_KIND)           '禁止棚設定
                        strFRAC_FORM = TO_STRING(objTPRG_TRK_BUF.FRAC_FORM)                 '棚形状種別
                        strFRES_KIND = TO_STRING(objTPRG_TRK_BUF.FRES_KIND)                 '引当状態

                        strFHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))       '品名ｺｰﾄﾞ
                        strFLOT_NO = TO_STRING(objRow("FLOT_NO"))             'ﾛｯﾄ№
                        strFARRIVE_DT = TO_STRING(objRow("FARRIVE_DT"))       '在庫発生日時
                        strFIN_KUBUN = TO_STRING(objRow("FIN_KUBUN"))         '入庫区分
                        strFSEIHIN_KUBUN = TO_STRING(objRow("FSEIHIN_KUBUN")) '製品区分
                        strFZAIKO_KUBUN = TO_STRING(objRow("FZAIKO_KUBUN"))   '在庫区分
                        strFHORYU_KUBUN = TO_STRING(objRow("FHORYU_KUBUN"))   '保留区分
                        strFST_FM = TO_STRING(objRow("FST_FM"))               '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        strFTR_VOL = TO_STRING(objRow("FTR_VOL"))             '搬送管理量
                        strFTR_RES_VOL = TO_STRING(objRow("FTR_RES_VOL"))     '搬送引当量
                        strFPALLET_ID = TO_STRING(objRow("FPALLET_ID"))       'ﾊﾟﾚｯﾄID
                        strFLOT_NO_STOCK = TO_STRING(objRow("FLOT_NO_STOCK")) '在庫ﾛｯﾄ№


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
                            MsgBox("【平置き在庫削除失敗】[ﾊﾟﾚｯﾄID:" & strFPALLET_ID & "][在庫ﾛｯﾄ№:" & strFLOT_NO_STOCK & "]")
                        End If

                        ii = ii + 1
                    Next

                    gobjDb.Commit()
                    gobjDb.BeginTrans()

                Catch ex As Exception
                    MsgBox(ex.Message)
                    gobjDb.RollBack()
                    gobjDb.BeginTrans()
                End Try

            Else

                Throw New Exception("平置き在庫情報が見つかりません。")

            End If




        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "  検品ｴﾘｱ在庫削除                   ｸﾘｯｸ    "
    Private Sub cmd002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd002.Click
        Try

            Dim intRet As RetCode
            Dim blnRet As Boolean = False

            If MessageBox.Show("OK?", "", MessageBoxButtons.OKCancel) <> Windows.Forms.DialogResult.OK Then Return


            '****************************************************
            '平置き在庫情報取得
            '****************************************************
            Dim strSQL As String                        'SQL文
            Dim objRow As DataRow                       '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
            Dim objDataSet As New DataSet               'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）


            '============================================================
            'SELECT
            '============================================================
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "        TPRG_TRK_BUF.FTRK_BUF_NO "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            strSQL &= vbCrLf & "      , TPRG_TRK_BUF.FTRK_BUF_ARRAY "                           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
            strSQL &= vbCrLf & "      , TPRG_TRK_BUF.FREMOVE_KIND "                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.禁止棚設定
            strSQL &= vbCrLf & "      , TPRG_TRK_BUF.FRAC_FORM "                                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.棚形状種別
            strSQL &= vbCrLf & "      , TPRG_TRK_BUF.FRES_KIND "                                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.引当状態

            strSQL &= vbCrLf & "      , TRST_STOCK.FHINMEI_CD "                                 '在庫情報       .品名ｺｰﾄﾞ
            strSQL &= vbCrLf & "      , TRST_STOCK.FLOT_NO "                                    '在庫情報       .ﾛｯﾄ№
            strSQL &= vbCrLf & "      , TRST_STOCK.FARRIVE_DT "                                 '在庫情報       .在庫発生日時
            strSQL &= vbCrLf & "      , TRST_STOCK.FIN_KUBUN "                                  '在庫情報       .入庫区分
            strSQL &= vbCrLf & "      , TRST_STOCK.FSEIHIN_KUBUN "                              '在庫情報       .製品区分
            strSQL &= vbCrLf & "      , TRST_STOCK.FZAIKO_KUBUN "                               '在庫情報       .在庫区分
            strSQL &= vbCrLf & "      , TRST_STOCK.FHORYU_KUBUN "                               '在庫情報       .保留区分
            strSQL &= vbCrLf & "      , TRST_STOCK.FST_FM "                                     '在庫情報       .搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            strSQL &= vbCrLf & "      , TRST_STOCK.FTR_VOL "                                    '在庫情報       .搬送管理量
            strSQL &= vbCrLf & "      , TRST_STOCK.FTR_RES_VOL "                                '在庫情報       .搬送引当量
            strSQL &= vbCrLf & "      , TRST_STOCK.FPALLET_ID "                                 '在庫情報       .ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "      , TRST_STOCK.FLOT_NO_STOCK "                              '在庫情報       .在庫ﾛｯﾄ№

            '============================================================
            'FROM
            '============================================================
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "        TRST_STOCK "
            strSQL &= vbCrLf & "      , TPRG_TRK_BUF "

            '============================================================
            'WHERE
            '============================================================
            strSQL &= vbCrLf & " WHERE 0 = 0 "
            strSQL &= vbCrLf & "      AND TRST_STOCK.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = " & FTRK_BUF_NO_J9200 & " "

            '============================================================
            'ORDER BY
            '============================================================
            strSQL &= vbCrLf & " ORDER BY "
            strSQL &= vbCrLf & "        TPRG_TRK_BUF.FTRK_BUF_ARRAY "


            '-----------------------
            '抽出
            '-----------------------
            gobjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TRST_STOCK"
            gobjDb.GetDataSet(strDataSetName, objDataSet)

            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then

                Dim ii As Integer = 1
                Try
                    gobjDb.Commit()
                    gobjDb.BeginTrans()

                    '****************************************************
                    '在庫情報取得
                    '****************************************************
                    For Each objRow In objDataSet.Tables(strDataSetName).Rows
                        '(ﾙｰﾌﾟ:在庫数)

                        '*******************************************************
                        '進捗更新
                        '*******************************************************
                        lblProgress.Text = TO_STRING(ii) & "/" & TO_STRING(objDataSet.Tables(strDataSetName).Rows.Count)
                        Me.Refresh()
                        System.Windows.Forms.Application.DoEvents()


                        '****************************************************
                        '在庫情報取得
                        '****************************************************
                        Dim strDIR_KUBUN As String = ""     '指示区分
                        Dim intCount As Integer

                        Dim objCheck As New TBL_TRST_STOCK(gobjOwner, gobjDb, Nothing)
                        objCheck.FPALLET_ID = TO_STRING(objRow("FPALLET_ID"))    'ﾊﾟﾚｯﾄID
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
                        objTPRG_TRK_BUF.FPALLET_ID = TO_STRING(objRow("FPALLET_ID"))    'ﾊﾟﾚｯﾄID
                        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(False)
                        If intRet <> RetCode.OK Then
                            MsgBox("ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧが見つかりません。[ﾊﾟﾚｯﾄID:" & TO_STRING(objRow("FPALLET_ID")) & "]")
                            Continue For
                        End If

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


                        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

                        strFBUF_NO = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO)                 'ﾊﾞｯﾌｧ№
                        strFBUF_ARRAY = TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY)           'ﾊﾞｯﾌｧ配列№
                        strFREMOVE_KIND = TO_STRING(objTPRG_TRK_BUF.FREMOVE_KIND)           '禁止棚設定
                        strFRAC_FORM = TO_STRING(objTPRG_TRK_BUF.FRAC_FORM)                 '棚形状種別
                        strFRES_KIND = TO_STRING(objTPRG_TRK_BUF.FRES_KIND)                 '引当状態

                        strFHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))       '品名ｺｰﾄﾞ
                        strFLOT_NO = TO_STRING(objRow("FLOT_NO"))             'ﾛｯﾄ№
                        strFARRIVE_DT = TO_STRING(objRow("FARRIVE_DT"))       '在庫発生日時
                        strFIN_KUBUN = TO_STRING(objRow("FIN_KUBUN"))         '入庫区分
                        strFSEIHIN_KUBUN = TO_STRING(objRow("FSEIHIN_KUBUN")) '製品区分
                        strFZAIKO_KUBUN = TO_STRING(objRow("FZAIKO_KUBUN"))   '在庫区分
                        strFHORYU_KUBUN = TO_STRING(objRow("FHORYU_KUBUN"))   '保留区分
                        strFST_FM = TO_STRING(objRow("FST_FM"))               '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        strFTR_VOL = TO_STRING(objRow("FTR_VOL"))             '搬送管理量
                        strFTR_RES_VOL = TO_STRING(objRow("FTR_RES_VOL"))     '搬送引当量
                        strFPALLET_ID = TO_STRING(objRow("FPALLET_ID"))       'ﾊﾟﾚｯﾄID
                        strFLOT_NO_STOCK = TO_STRING(objRow("FLOT_NO_STOCK")) '在庫ﾛｯﾄ№


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
                            MsgBox("【検品ｴﾘｱ在庫削除失敗】[ﾊﾟﾚｯﾄID:" & strFPALLET_ID & "][在庫ﾛｯﾄ№:" & strFLOT_NO_STOCK & "]")
                        End If

                        ii = ii + 1
                    Next

                    gobjDb.Commit()
                    gobjDb.BeginTrans()

                Catch ex As Exception
                    MsgBox(ex.Message)
                    gobjDb.RollBack()
                    gobjDb.BeginTrans()
                End Try

            Else

                Throw New Exception("検品ｴﾘｱ在庫情報が見つかりません。")

            End If


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "  在庫移行前ﾁｪｯｸ               ｸﾘｯｸ    "
    Private Sub cmd003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd003.Click
        Try
            Call ZaikoIkou(False)
        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
#Region "  在庫移行                     ｸﾘｯｸ    "
    Private Sub cmd004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd004.Click
        Try
            Call ZaikoIkou(True)
        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            MsgBox(ex.Message)
        End Try
    End Sub
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
                    If UBound(objStock.Item(ii)) <> 2 Then Continue For

                    '*******************************************************
                    '必須 ﾁｪｯｸ
                    '*******************************************************
                    If TO_STRING(objStock.Item(ii)(DKA8310_MAINKEY_INDEX)) = "" Then
                        Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 品目ｺｰﾄﾞは必須です。")
                    End If

                    ' ''If TO_STRING(objStock.Item(ii)(DKA8310_SUBKEY1_INDEX)) = "" Then
                    ' ''    Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 引当ｷｰは必須です。")
                    ' ''End If

                    If TO_STRING(objStock.Item(ii)(DKA8310_DATA1_INDEX)) = "" Then
                        Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 ﾃﾞｰﾀは必須です。")
                    End If

                    '*******************************************************
                    '長さ ﾁｪｯｸ
                    '*******************************************************
                    If Len(objStock.Item(ii)(DKA8310_MAINKEY_INDEX)) <> DKA8310_MAINKEY_LENGTH Then
                        Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 品目ｺｰﾄﾞの長さが一致しません。")
                    End If

                    ' ''If Len(objStock.Item(ii)(DKA8300_SUBKEY1_INDEX)) <> DKA8300_SUBKEY1_LENGTH Then
                    ' ''    Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 引当ｷｰの長さが一致しません。")
                    ' ''End If

                    If Len(objStock.Item(ii)(DKA8310_DATA1_INDEX)) < DKA8310_DATA1_LENGTH Then
                        Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 ﾃﾞｰﾀの長さが不足しています。")
                    End If

                    '*******************************************************
                    'ﾃﾞｰﾀ取得
                    '*******************************************************
                    Dim intIndex As Integer = 0

                    Dim strMAINKEY_XHINMEI_CD As String = ""                    '品名ｺｰﾄﾞ

                    Dim strDATA1_FTR_VOL_KENPIN As String = ""                  '検品ｴﾘｱ総梱数
                    Dim strDATA1_FTR_VOL_HIRAOKI As String = ""                 '平置き総梱数


                    '(MAINKEY)
                    Dim strMAINKEY As String = objStock.Item(ii)(DKA8310_MAINKEY_INDEX)
                    strMAINKEY_XHINMEI_CD = strMAINKEY.Substring(intIndex, MAINKEY_XHINMEI_CD)    '品名ｺｰﾄﾞ
                    intIndex = intIndex + MAINKEY_XHINMEI_CD

                    '(SUBKEY)

                    '(DATA1)
                    intIndex = 0
                    Dim strDATA1 As String = objStock.Item(ii)(DKA8310_DATA1_INDEX)
                    intIndex = intIndex + DATA1_TOTALKSU                                                '総在庫梱数
                    intIndex = intIndex + DATA1_TOTALHISU                                               '総引当梱数
                    strDATA1_FTR_VOL_KENPIN = strDATA1.Substring(intIndex, DATA1_HIRA1KSU)              '検品ｴﾘｱ総在庫数
                    intIndex = intIndex + DATA1_HIRA1KSU
                    strDATA1_FTR_VOL_HIRAOKI = strDATA1.Substring(intIndex, DATA1_HIRA2KSU)             '平置き総在庫数
                    intIndex = intIndex + DATA1_HIRA2KSU

                    '========================================
                    ' 変数宣言
                    '========================================
                    Dim strDIR_KUBUN As String = ""                             '処理区分

                    Dim strFBUF_NO As String = ""                               'ﾊﾞｯﾌｧ№
                    Dim strFBUF_ARRAY As String = ""                            'ﾊﾞｯﾌｧ配列№

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

                    Dim strFNUM_IN_PALLET As String = ""                        'ﾊﾟﾚｯﾄ毎

                    '========================================
                    ' 棚 共通ﾃﾞｰﾀ確認
                    '========================================
                    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
                    Dim objTBL_TMST_ITEM As TBL_TMST_ITEM

                    '*******************************************************
                    '品名ｺｰﾄﾞ取得
                    '*******************************************************
                    objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                    objTBL_TMST_ITEM.XHINMEI_CD = strMAINKEY_XHINMEI_CD.Trim
                    intRet = objTBL_TMST_ITEM.GET_TMST_ITEM()
                    If intRet <> RetCode.OK Then
                        Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。" & vbCrLf & "該当する品目ｺｰﾄﾞがありません" & "[品目ｺｰﾄﾞ:" & strMAINKEY_XHINMEI_CD & "]")
                        Continue For
                    End If

                    '========================================
                    '
                    ' 検品ｴﾘｱ 電文作成
                    '
                    '========================================
                    If TO_INTEGER(strDATA1_FTR_VOL_KENPIN) <> 0 Then

                        strFNUM_IN_PALLET = objTBL_TMST_ITEM.FNUM_IN_PALLET

                        Dim intDATA1_FTR_VOL_KENPIN As Integer
                        Dim intFNUM_IN_PALLET As Integer

                        intDATA1_FTR_VOL_KENPIN = TO_INTEGER(strDATA1_FTR_VOL_KENPIN)
                        intFNUM_IN_PALLET = TO_INTEGER(strFNUM_IN_PALLET)

                        Dim blnHASUUFlg As Boolean = False  '端数ﾌﾗｸﾞ
                        Dim intHASUU_VOL As Integer         '端数梱数
                        Dim intPL_COUNT As Integer          'PL数


                        intHASUU_VOL = (intDATA1_FTR_VOL_KENPIN Mod intFNUM_IN_PALLET)
                        If intHASUU_VOL = 0 Then
                            '(端数なし)
                            intPL_COUNT = intDATA1_FTR_VOL_KENPIN / intFNUM_IN_PALLET

                        Else
                            '(端数あり)
                            intPL_COUNT = Math.Floor(intDATA1_FTR_VOL_KENPIN / intFNUM_IN_PALLET)
                            intPL_COUNT = intPL_COUNT + 1
                            blnHASUUFlg = True
                        End If



                        Dim j As Integer

                        For j = 1 To intPL_COUNT

                            objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

                            strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_INSERT               '処理区分
                            strFBUF_NO = FTRK_BUF_NO_J9200                              'ﾊﾞｯﾌｧ№
                            strFBUF_ARRAY = "1"                                         'ﾊﾞｯﾌｧ配列№
                            strFREMOVE_KIND = FREMOVE_KIND_SNORMAL                      '禁止状態
                            strFRAC_FORM = ""                                           '棚形状種別
                            strFRES_KIND = FRES_KIND_SZAIKO                             '引当状態=在庫
                            strFHINMEI_CD = TO_STRING(objTBL_TMST_ITEM.FHINMEI_CD)      '品名ｺｰﾄﾞ
                            strFLOT_NO = ""                                             'ﾛｯﾄNo.(生産ﾗｲﾝ + 入庫年月日)
                            strFARRIVE_DT = Format(Now, "yyyy/MM/dd hh:mm:ss")          '在庫年月日=Now
                            strFIN_KUBUN = FIN_KUBUN_J01                                '入庫区分=生産品
                            strFHORYU_KUBUN = FHORYU_KUBUN_SNORMAL                      '保留区分=通常品
                            strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            '搬送管理量
                            If blnHASUUFlg = False Then
                                '(端数なしの場合)
                                strFTR_VOL = TO_STRING(objTBL_TMST_ITEM.FNUM_IN_PALLET)
                                strFHASU_FLAG = TO_STRING(FHASU_FLAG_SMANSU)

                            ElseIf blnHASUUFlg = True And (j <> intPL_COUNT) Then
                                '(端数ありで最後以外のPLの場合)
                                strFTR_VOL = TO_STRING(objTBL_TMST_ITEM.FNUM_IN_PALLET)
                                strFHASU_FLAG = TO_STRING(FHASU_FLAG_SMANSU)

                            ElseIf blnHASUUFlg = True And (j = intPL_COUNT) Then
                                '(端数ありで最後のPLの場合)
                                strFTR_VOL = TO_STRING(intHASUU_VOL)
                                strFHASU_FLAG = TO_STRING(FHASU_FLAG_SHASU)

                            End If
                            strFRAC_BUNRUI = ""                                         '棚分類
                            strFBUF_IN_DT = Format(Now, "yyyy/MM/dd hh:mm:ss")          'ﾊﾞｯﾌｧ入日時
                            strXTANA_BLOCK = ""                                         '棚ﾌﾞﾛｯｸ
                            strXTANA_BLOCK_DTL = ""                                     '棚ﾌﾞﾛｯｸ詳細
                            strXTANA_BLOCK_STS = ""                                     '棚ﾌﾞﾛｯｸ状態
                            strXPROD_LINE = ""                                          '生産ﾗｲﾝNo.
                            strXKENSA_KUBUN = XKENSA_KUBUN_J_OK                         '検査区分
                            strXKENPIN_KUBUN = XKENPIN_KUBUN_J_MI                       '検品区分
                            strFUPDATE_DT = ""                                          '更新日時

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
                            objTelegram.SETIN_DATA("XDSPPROD_LINE", strXPROD_LINE)              '生産ﾗｲﾝNo
                            objTelegram.SETIN_DATA("XDSPMAKER_CD", "")                          'ﾒｰｶｺｰﾄﾞ

                            '*******************************************************
                            'ｿｹｯﾄ送信
                            '*******************************************************
                            If blnSockSend = True Then
                                Dim strRET_STATE As String = ""
                                Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
                                Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

                                strErrMsg = "検品ｴﾘｱ在庫移行に失敗しました。"
                                udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
                                If udtSckSendRET = clsSocketClient.RetCode.OK Then
                                    '(送信できた場合)
                                    If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                                        '(正常終了の場合)
                                        blnRet = True
                                    End If
                                End If

                                If blnRet = False Then
                                    Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。")
                                End If

                            End If

                        Next


                    End If


                    '========================================
                    '
                    ' 平置き 電文作成
                    '
                    '========================================
                    If TO_INTEGER(strDATA1_FTR_VOL_HIRAOKI) <> 0 Then

                        strFNUM_IN_PALLET = objTBL_TMST_ITEM.FNUM_IN_PALLET

                        Dim intDATA1_FTR_VOL_HIRAOKI As Integer
                        Dim intFNUM_IN_PALLET As Integer

                        intDATA1_FTR_VOL_HIRAOKI = TO_INTEGER(strDATA1_FTR_VOL_HIRAOKI)
                        intFNUM_IN_PALLET = TO_INTEGER(strFNUM_IN_PALLET)

                        Dim blnHASUUFlg As Boolean = False  '端数ﾌﾗｸﾞ
                        Dim intHASUU_VOL As Integer         '端数梱数
                        Dim intPL_COUNT As Integer          'PL数


                        intHASUU_VOL = (intDATA1_FTR_VOL_HIRAOKI Mod intFNUM_IN_PALLET)
                        If intHASUU_VOL = 0 Then
                            '(端数なし)
                            intPL_COUNT = intDATA1_FTR_VOL_HIRAOKI / intFNUM_IN_PALLET

                        Else
                            '(端数あり)
                            intPL_COUNT = Math.Floor(intDATA1_FTR_VOL_HIRAOKI / intFNUM_IN_PALLET)
                            intPL_COUNT = intPL_COUNT + 1
                            blnHASUUFlg = True
                        End If



                        Dim j As Integer

                        For j = 1 To intPL_COUNT

                            objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200401          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

                            strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_INSERT               '処理区分
                            strFBUF_NO = FTRK_BUF_NO_J9100                              'ﾊﾞｯﾌｧ№
                            strFBUF_ARRAY = "1"                                         'ﾊﾞｯﾌｧ配列№
                            strFREMOVE_KIND = FREMOVE_KIND_SNORMAL                      '禁止状態
                            strFRAC_FORM = ""                                           '棚形状種別
                            strFRES_KIND = FRES_KIND_SZAIKO                             '引当状態=在庫
                            strFHINMEI_CD = TO_STRING(objTBL_TMST_ITEM.FHINMEI_CD)      '品名ｺｰﾄﾞ
                            strFLOT_NO = ""                                             'ﾛｯﾄNo.(生産ﾗｲﾝ + 入庫年月日)
                            strFARRIVE_DT = Format(Now, "yyyy/MM/dd hh:mm:ss")          '在庫年月日=Now
                            strFIN_KUBUN = FIN_KUBUN_J01                                '入庫区分=生産品
                            strFHORYU_KUBUN = FHORYU_KUBUN_SNORMAL                      '保留区分=通常品
                            strFST_FM = ""                                              '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                            '搬送管理量
                            If blnHASUUFlg = False Then
                                '(端数なしの場合)
                                strFTR_VOL = TO_STRING(objTBL_TMST_ITEM.FNUM_IN_PALLET)
                                strFHASU_FLAG = TO_STRING(FHASU_FLAG_SMANSU)

                            ElseIf blnHASUUFlg = True And (j <> intPL_COUNT) Then
                                '(端数ありで最後以外のPLの場合)
                                strFTR_VOL = TO_STRING(objTBL_TMST_ITEM.FNUM_IN_PALLET)
                                strFHASU_FLAG = TO_STRING(FHASU_FLAG_SMANSU)

                            ElseIf blnHASUUFlg = True And (j = intPL_COUNT) Then
                                '(端数ありで最後のPLの場合)
                                strFTR_VOL = TO_STRING(intHASUU_VOL)
                                strFHASU_FLAG = TO_STRING(FHASU_FLAG_SHASU)

                            End If
                            strFRAC_BUNRUI = ""                                         '棚分類
                            strFBUF_IN_DT = Format(Now, "yyyy/MM/dd hh:mm:ss")          'ﾊﾞｯﾌｧ入日時
                            strXTANA_BLOCK = ""                                         '棚ﾌﾞﾛｯｸ
                            strXTANA_BLOCK_DTL = ""                                     '棚ﾌﾞﾛｯｸ詳細
                            strXTANA_BLOCK_STS = ""                                     '棚ﾌﾞﾛｯｸ状態
                            strXPROD_LINE = ""                                          '生産ﾗｲﾝNo.
                            strXKENSA_KUBUN = XKENSA_KUBUN_J_OK                         '検査区分
                            strXKENPIN_KUBUN = XKENPIN_KUBUN_J_MI                       '検品区分
                            strFUPDATE_DT = ""                                          '更新日時

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
                            objTelegram.SETIN_DATA("XDSPPROD_LINE", strXPROD_LINE)              '生産ﾗｲﾝNo
                            objTelegram.SETIN_DATA("XDSPMAKER_CD", "")                          'ﾒｰｶｺｰﾄﾞ

                            '*******************************************************
                            'ｿｹｯﾄ送信
                            '*******************************************************
                            If blnSockSend = True Then
                                Dim strRET_STATE As String = ""
                                Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
                                Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

                                strErrMsg = "平置き在庫移行に失敗しました。"
                                udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
                                If udtSckSendRET = clsSocketClient.RetCode.OK Then
                                    '(送信できた場合)
                                    If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                                        '(正常終了の場合)
                                        blnRet = True
                                    End If
                                End If

                                If blnRet = False Then
                                    Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。")
                                End If

                            End If

                        Next


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
        gobjComFuncFRM.AddToLog_frm("平置き在庫移行終了:" & Format(Now, "yyyy/MM/dd HH:mm:ss"), AddToLog_D_ErrorType.USER_LOG, "")

    End Sub
#End Region

End Class