'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】品目移行ﾂｰﾙ
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_299006

#Region "  共通変数                             "

    '旧品目ﾏｽﾀ
    Private Const DKA8000_XHINMEI_CD As Integer = 6         '品名ｺｰﾄﾞ
    Private Const DKA8000_XARTICLE_TYPE_CODE As Integer = 1 '品名区分
    Private Const DKA8000_XHINMEI_CD2 As Integer = 6        '品名ｺｰﾄﾞ2
    Private Const DKA8000_FHINMEI_CD As Integer = 14        '品名記号
    Private Const DKA8000_FHINMEI As Integer = 24           '品名
    Private Const DKA8000_XWEIGHT_IN_CASE As Integer = 5    '棚重量
    Private Const DKA8000_FNUM_IN_PL As Integer = 3         '梱数/ﾊﾟﾚｯﾄ
    Private Const DKA8000_VAL8 As Integer = 5               '入数/梱(未使用)
    Private Const DKA8000_XPLANE_PACK_NUMBER As Integer = 3 '梱数/段
    Private Const DKA8000_XWEIGHT_IN_PL As Integer = 4      '重量/ﾊﾟﾚｯﾄ
    Private Const DKA8000_XDAN_IN_PALLET As Integer = 2     '段/ﾊﾟﾚｯﾄ
    Private Const DKA8000_XHEIGHT_IN_CASE As Integer = 4    '高さ/梱
    Private Const DKA8000_XHEIGHT_IN_PALLET As Integer = 4  '高さ/ﾊﾟﾚｯﾄ
    Private Const DKA8000_FRAC_FROM As Integer = 1          '入庫ﾗｯｸ区分
    Private Const DKA8000_XJAN_CD As Integer = 14           'JANｺｰﾄﾞ
    Private Const DKA8000_XITF_CD As Integer = 16           'ITFｺｰﾄﾞ
    Private Const DKA8000_VAL17 As Integer = 2              'ABC区分 連数(未使用)
    Private Const DKA8000_VAL18 As Integer = 2              'ABC区分 段数(未使用)
    Private Const DKA8000_VAL19 As Integer = 1              'ABC区分 内外区分(未使用)
    Private Const DKA8000_FENTRY_DT As Integer = 8          '使用日時(未使用)
    Private Const DKA8000_VAL21 As Integer = 25             'ﾀﾞﾐｰ(未使用)

    Private Const DKA8000_MAINKEY_INDEX As Integer = 0      '項目1
    Private Const DKA8000_SUBKEY1_INDEX As Integer = 1      '項目2
    Private Const DKA8000_SUBKEY2_INDEX As Integer = 2      '項目3
    Private Const DKA8000_DATA1_INDEX As Integer = 3        '項目4
    Private Const DKA8000_DATA2_INDEX As Integer = 4        '項目5

    Private Const DKA8000_MAINKEY_LENGTH As Integer = 6     '項目1 長さ
    Private Const DKA8000_SUBKEY1_LENGTH As Integer = 7     '項目2 長さ
    Private Const DKA8000_SUBKEY2_LENGTH As Integer = 14    '項目3 長さ
    Private Const DKA8000_DATA1_LENGTH As Integer = 24      '項目4 長さ
    Private Const DKA8000_DATA2_LENGTH As Integer = 99      '項目5 長さ



    'Hinmokuﾌｧｲﾙ
    Private Const F01_FHINMEI_CD As Integer = 0             '品名ｺｰﾄﾞ
    Private Const F01_FHINMEI As Integer = 1                '品名
    Private Const F01_FNUM_IN_PALLET As Integer = 2         'PL毎積載数
    Private Const F01_XHINMEI_SYU_CD As Integer = 3         '品目種別ｺｰﾄﾞ
    Private Const F01_XHEIMEN_KONSU As Integer = 4          '平面梱数
    Private Const F01_XNIDAKA_KUBUN As Integer = 5          '荷高区分
    Private Const F01_XKANRI_KUBUN As Integer = 6           '管理区分
    Private Const F01_XSTRETCH_KUBUN As Integer = 7         'ｽﾄﾚｯﾁ区分

    'ﾃﾞﾌｫﾙﾄ値
    Private Const DEFAULT_HUMEI As String = ""              'ﾃﾞﾌｫﾙﾄ値不明





#End Region

#Region "  全品目削除                   ｸﾘｯｸ    "
    Private Sub cmd001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd001.Click
        Try

            Dim intRet As RetCode
            Dim blnRet As Boolean = False

            If MessageBox.Show("OK?", "", MessageBoxButtons.OKCancel) <> Windows.Forms.DialogResult.OK Then Return


            '****************************************************
            '品目情報取得
            '****************************************************
            Dim strSQL As String = ""
            Dim objTMST_ITEM As New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
            intRet = objTMST_ITEM.GET_TMST_ITEM_ANY()
            'If intRet <> RetCode.OK Then
            '    Throw New Exception("在庫情報が見つかりません。")
            'End If

            Try
                gobjDb.Commit()
                gobjDb.BeginTrans()

                If intRet = RetCode.OK Then

                    '****************************************************
                    '品目情報取得
                    '****************************************************
                    For ii As Integer = LBound(objTMST_ITEM.ARYME) To UBound(objTMST_ITEM.ARYME)
                        '(ﾙｰﾌﾟ:品目数)


                        '*******************************************************
                        '進捗更新
                        '*******************************************************
                        lblProgress.Text = TO_STRING(ii) & "/" & TO_STRING(UBound(objTMST_ITEM.ARYME))
                        Me.Refresh()
                        System.Windows.Forms.Application.DoEvents()


                        '****************************************************
                        '品目情報取得
                        '****************************************************
                        Dim strDIR_KUBUN As String = ""     '指示区分
                        Dim intCount As Integer

                        Dim objCheck As New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                        objCheck.FHINMEI_CD = objTMST_ITEM.ARYME(ii).FHINMEI_CD    '品目ｺｰﾄﾞ
                        intCount = objCheck.GET_TMST_ITEM_COUNT()
                        If intCount <= 0 Then
                            '品目削除の場合)
                            Continue For
                        End If
                        strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_DELETE           '指示区分(品目情報削除)


                        '*******************************************************
                        'ｿｹｯﾄ送信処理
                        '*******************************************************
                        '========================================
                        ' 変数宣言
                        '========================================
                        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

                        'Dim strDSPDIR_KUBUN As String = ""          '処理区分
                        Dim strDSPHINMEI_CD As String = ""          '品名ｺｰﾄﾞ
                        Dim strDSPHINMEI As String = ""             '品名
                        Dim strDSPNUM_IN_CASE As String = ""        'ｹｰｽ入数
                        Dim strDSPTANI As String = ""               '単位
                        Dim strDSPDECIMAL_POINT As String = ""      '小数点桁数
                        Dim strDSPNUM_IN_PALLET As String = ""      'PL毎積載数
                        Dim strDSPZAIKO_KUBUN As String = ""        '在庫区分
                        Dim strDSPRAC_FORM As String = ""           '棚形状種別

                        '**********************************************************************************************
                        '↓↓↓ｼｽﾃﾑ固有
                        Dim strXDSPHINMEI_SYU_CD As String = ""     '品目種別ｺｰﾄﾞ
                        Dim strXDSPHEIMEN_KONSU As String = ""      '平面梱数
                        Dim strXDSPNIDAKA_KUBUN As String = ""      '荷高区分
                        Dim strXDSPKANRI_KUBUN As String = ""       '管理区分
                        Dim strXDSPSTRETCH_KUBUN As String = ""     'ｽﾄﾚｯﾁ区分
                        Dim strXDSPHIKIATE_CRANE_ID As String = ""  '最終引当ｸﾚｰﾝID
                        '↑↑↑ｼｽﾃﾑ固有
                        '**********************************************************************************************


                        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S201901          'ﾌｫｰﾏｯﾄ名ｾｯﾄ


                        strDSPHINMEI_CD = TO_STRING(objTMST_ITEM.ARYME(ii).FHINMEI_CD)                  '品名ｺｰﾄﾞ
                        strDSPHINMEI = TO_STRING(objTMST_ITEM.ARYME(ii).FHINMEI)                        '品名
                        strDSPNUM_IN_CASE = TO_STRING(objTMST_ITEM.ARYME(ii).FNUM_IN_CASE)              'ｹｰｽ入数
                        strDSPTANI = TO_STRING(objTMST_ITEM.ARYME(ii).FTANI)                            '単位
                        strDSPDECIMAL_POINT = TO_STRING(objTMST_ITEM.ARYME(ii).FDECIMAL_POINT)          '小数点桁数
                        strDSPNUM_IN_PALLET = TO_STRING(objTMST_ITEM.ARYME(ii).FNUM_IN_PALLET)          'PL毎積載数
                        strDSPZAIKO_KUBUN = TO_STRING(objTMST_ITEM.ARYME(ii).FZAIKO_KUBUN)              '在庫区分
                        strDSPRAC_FORM = TO_STRING(objTMST_ITEM.ARYME(ii).FRAC_FORM)                    '棚形状種別
                        'strXDSPHINMEI_SYU_CD = TO_STRING(objTMST_ITEM.ARYME(ii).XHINMEI_SYU_CD)         '品目種別ｺｰﾄﾞ
                        'strXDSPHEIMEN_KONSU = TO_STRING(objTMST_ITEM.ARYME(ii).XHEIMEN_KONSU)           '平面梱数
                        'strXDSPNIDAKA_KUBUN = TO_STRING(objTMST_ITEM.ARYME(ii).XNIDAKA_KUBUN)           '荷高区分
                        'strXDSPKANRI_KUBUN = TO_STRING(objTMST_ITEM.ARYME(ii).XKANRI_KUBUN)             '管理区分
                        'strXDSPSTRETCH_KUBUN = TO_STRING(objTMST_ITEM.ARYME(ii).XSTRETCH_KUBUN)         'ｽﾄﾚｯﾁ区分
                        'strXDSPHIKIATE_CRANE_ID = ""                                                    '最終引当ｸﾚｰﾝID



                        objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                       '処理区分
                        objTelegram.SETIN_DATA("DSPHINMEI_CD", strDSPHINMEI_CD)                    '品名ｺｰﾄﾞ
                        objTelegram.SETIN_DATA("DSPHINMEI", strDSPHINMEI)                          '品名
                        objTelegram.SETIN_DATA("DSPNUM_IN_CASE", strDSPNUM_IN_CASE)                'ｹｰｽ入数
                        objTelegram.SETIN_DATA("DSPTANI", strDSPTANI)                              '単位
                        objTelegram.SETIN_DATA("DSPDECIMAL_POINT", strDSPDECIMAL_POINT)            '小数点桁数
                        objTelegram.SETIN_DATA("DSPNUM_IN_PALLET", strDSPNUM_IN_PALLET)            'PL毎積載数
                        objTelegram.SETIN_DATA("DSPZAIKO_KUBUN", strDSPZAIKO_KUBUN)                '在庫区分
                        objTelegram.SETIN_DATA("DSPRAC_FORM", strDSPRAC_FORM)                      '棚形状種別

                        '**********************************************************************************************
                        '↓↓↓ｼｽﾃﾑ固有
                        ' ''objTelegram.SETIN_DATA("XDSPHINMEI_SYU_CD", strXDSPHINMEI_SYU_CD)          '品目種別ｺｰﾄﾞ
                        ' ''objTelegram.SETIN_DATA("XDSPHEIMEN_KONSU", strXDSPHEIMEN_KONSU)            '平面梱数
                        ' ''objTelegram.SETIN_DATA("XDSPNIDAKA_KUBUN", strXDSPNIDAKA_KUBUN)            '荷高区分
                        ' ''objTelegram.SETIN_DATA("XDSPKANRI_KUBUN", strXDSPKANRI_KUBUN)              '管理区分
                        ' ''objTelegram.SETIN_DATA("XDSPSTRETCH_KUBUN", strXDSPSTRETCH_KUBUN)          'ｽﾄﾚｯﾁ区分
                        ' ''objTelegram.SETIN_DATA("XDSPHIKIATE_CRANE_ID", strXDSPHIKIATE_CRANE_ID)    '最終引当ｸﾚｰﾝID
                        '↑↑↑ｼｽﾃﾑ固有
                        '**********************************************************************************************


                        Dim strRET_STATE As String = ""
                        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
                        Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

                        strErrMsg = "品名ﾏｽﾀﾒﾝﾃﾅﾝｽ" & FRM_MSG_FRM206011_01
                        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
                        If udtSckSendRET = clsSocketClient.RetCode.OK Then
                            '(送信できた場合)
                            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                                '(正常終了の場合)
                                blnRet = True
                            End If
                        End If

                        If blnRet = False Then
                            MsgBox("【品目削除失敗】[品目ｺｰﾄﾞ:" & objTMST_ITEM.ARYME(ii).FHINMEI_CD & "]")
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


            ''****************************************************
            ''ｺﾞﾐ削除
            ''****************************************************
            'Try
            '    gobjDb.Commit()
            '    gobjDb.BeginTrans()

            '    '****************************************************
            '    '全計画、報告削除
            '    '****************************************************
            '    'gobjDb.SQL = "TRUNCATE TABLE XPLN_REQUEST"
            '    'gobjDb.Execute()

            '    'gobjDb.SQL = "TRUNCATE TABLE XPLN_REQUEST_DTL"
            '    'gobjDb.Execute()


            '    'gobjDb.SQL = "TRUNCATE TABLE TRST_REPORT"
            '    'gobjDb.Execute()

            '    'gobjDb.SQL = "TRUNCATE TABLE TRST_REPORT_DTL"
            '    'gobjDb.Execute()

            '    ''****************************************************
            '    '在庫情報削除
            '    '****************************************************
            '    gobjDb.SQL = "TRUNCATE TABLE TRST_STOCK"
            '    gobjDb.Execute()

            '    '****************************************************
            '    '在庫引当情報削除
            '    '****************************************************
            '    gobjDb.SQL = "TRUNCATE TABLE TSTS_HIKIATE"
            '    gobjDb.Execute()

            '    '****************************************************
            '    '搬送指示QUE削除
            '    '****************************************************
            '    gobjDb.SQL = "TRUNCATE TABLE TPLN_CARRY_QUE"
            '    gobjDb.Execute()

            '    '****************************************************
            '    'ｼﾘｱﾙ関連付け削除
            '    '****************************************************
            '    gobjDb.SQL = "TRUNCATE TABLE TPRG_SERIAL"
            '    gobjDb.Execute()

            '    '****************************************************
            '    'ﾊﾟﾚｯﾄ情報削除
            '    '****************************************************
            '    gobjDb.SQL = "TRUNCATE TABLE TRST_PALLET"
            '    gobjDb.Execute()


            '    gobjDb.Commit()
            '    gobjDb.BeginTrans()

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            '    gobjDb.RollBack()
            '    gobjDb.BeginTrans()
            'End Try




        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "  品目移行前ﾁｪｯｸ               ｸﾘｯｸ    "
    Private Sub cmd002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd002.Click
        Try
            Call HinmokuIkou(False)
        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
#Region "  品目移行                     ｸﾘｯｸ    "
    Private Sub cmd003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd003.Click
        Try
            Call HinmokuIkou(True)
        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "  品目移行処理                         "
    '''***********************************************************************************************************************************
    ''' <summary>
    ''' 品目移行処理
    ''' </summary>
    ''' <param name="blnSockSend">
    ''' ｿｹｯﾄ送信ﾌﾗｸﾞ
    ''' True :ｿｹｯﾄを送信する
    ''' False:ｿｹｯﾄを送信しない事によって事前にｴﾗｰを感知出来る
    ''' </param>
    ''' <remarks></remarks>
    '''***********************************************************************************************************************************
    Private Sub HinmokuIkou(ByVal blnSockSend As Boolean)
        Try

            Dim objHinmoku As New System.Collections.ArrayList()        'Hinmokuﾌｧｲﾙ      ﾃﾞｰﾀﾌｧｲﾙｵﾌﾞｼﾞｪｸﾄ
            Dim strcsvFileName01 As String = txtReadFile01.Text         'Hinmokuﾌｧｲﾙ名
            Dim objTextFieldParser01 As New FileIO.TextFieldParser(strcsvFileName01, System.Text.Encoding.GetEncoding(932))     'Shift JISで読み込む

            Try
                'Dim intRet As RetCode
                Dim blnRet As Boolean = False
                Dim dtmNow As Date = Now

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
                    objHinmoku.Add(strfields)                                           '保存
                End While

                '*******************************************************
                '*******************************************************
                'ｿｹｯﾄ送信処理
                '*******************************************************
                '*******************************************************
                Dim strSendTel() As String = Nothing        '送信電文配列

                For ii As Integer = 0 To objHinmoku.Count - 1
                    '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


                    '*******************************************************
                    '進捗更新
                    '*******************************************************
                    lblProgress.Text = TO_STRING(ii) & "/" & TO_STRING(objHinmoku.Count - 1)
                    Me.Refresh()
                    System.Windows.Forms.Application.DoEvents()


                    '*******************************************************
                    '正しいCSVかﾁｪｯｸ
                    '*******************************************************
                    If UBound(objHinmoku.Item(ii)) <> 4 Then Continue For


                    '*******************************************************
                    '必須 ﾁｪｯｸ
                    '*******************************************************
                    If TO_STRING(objHinmoku.Item(ii)(DKA8000_MAINKEY_INDEX)) = "" Then
                        Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 品名ｺｰﾄﾞは必須です。")
                    End If

                    ''If TO_STRING(objHinmoku.Item(ii)(DKA8000_SUBKEY1_INDEX)) = "" Then
                    ''    Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 品名区分は必須です。")
                    ''End If

                    ''If TO_STRING(objHinmoku.Item(ii)(DKA8000_SUBKEY2_INDEX)) = "" Then
                    ''    Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 品名記号は必須です。")
                    ''End If

                    ''If TO_STRING(objHinmoku.Item(ii)(DKA8000_DATA1_INDEX)) = "" Then
                    ''    Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 品名は必須です。")
                    ''End If

                    ''If TO_STRING(objHinmoku.Item(ii)(DKA8000_DATA2_INDEX)) = "" Then
                    ''    Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 品目ﾃﾞｰﾀは必須です。")
                    ''End If

                    '*******************************************************
                    '長さ ﾁｪｯｸ
                    '*******************************************************
                    ' ''If Len(objHinmoku.Item(ii)(DKA8000_MAINKEY_INDEX)) <> DKA8000_MAINKEY_LENGTH Then
                    ' ''    Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 品名ｺｰﾄﾞの長さが一致しません。")
                    ' ''End If

                    ' ''If Len(objHinmoku.Item(ii)(DKA8000_SUBKEY1_INDEX)) <> DKA8000_SUBKEY1_LENGTH Then
                    ' ''    Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 品名区分の長さが一致しません。")
                    ' ''End If

                    ' ''If Len(objHinmoku.Item(ii)(DKA8000_SUBKEY2_INDEX)) <> DKA8000_SUBKEY2_LENGTH Then
                    ' ''    Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 品名記号の長さが一致しません。")
                    ' ''End If

                    ' ''If Len(objHinmoku.Item(ii)(DKA8000_DATA1_INDEX)) <> DKA8000_DATA1_LENGTH Then
                    ' ''    Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 品名の長さが一致しません。")
                    ' ''End If

                    If Len(objHinmoku.Item(ii)(DKA8000_DATA2_INDEX)) <> DKA8000_DATA2_LENGTH Then
                        Throw New Exception(TO_STRING(ii + 1) & "行目でｴﾗｰ発生。 品名ﾃﾞｰﾀの長さが一致しません。")
                    End If

                    '*******************************************************
                    '重複 ﾁｪｯｸ
                    '*******************************************************
                    Dim strFHINMEI_CD As String
                    strFHINMEI_CD = objHinmoku.Item(ii)(DKA8000_SUBKEY2_INDEX).Trim
                    Dim intCount As Integer
                    Dim objTBL_TMST_ITEM As New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                    objTBL_TMST_ITEM.FHINMEI_CD = strFHINMEI_CD
                    intCount = objTBL_TMST_ITEM.GET_TMST_ITEM_COUNT()
                    If intCount >= 1 Then
                        '(既に登録済みの場合)
                        Call gobjComFuncFRM.ComError_frm(New Exception(TO_STRING(ii + 1) & "行目のﾃﾞｰﾀは既に登録されています。"))
                        Continue For
                    End If
                    objTBL_TMST_ITEM.Close()

                    '*******************************************************
                    '配列定義
                    '*******************************************************
                    If IsNull(strSendTel) Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)


                    '*******************************************************
                    'ｿｹｯﾄ送信処理
                    '*******************************************************
                    '========================================
                    ' 変数宣言
                    '========================================
                    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

                    Dim strDIR_KUBUN As String = ""             '処理区分
                    Dim strXHINMEI_CD As String = ""            '品名ｺｰﾄﾞ
                    Dim strXARTICLE_TYPE_CODE As String = ""    '品目種別
                    ' ''Dim strFHINMEI_CD As String = ""            '品名記号
                    Dim strFHINMEI As String = ""               '品名

                    Dim strXWEIGHT_IN_CASE As String = ""       '梱重量
                    Dim strFNUM_IN_PALLET As String = ""        'PL毎積載数(ﾊﾟﾚｯﾄ積付数)
                    Dim strXPLANE_PACK_NUMBER As String = ""    '平面梱数
                    Dim strXWEIGHT_IN_PALLET As String = ""     'ﾊﾟﾚｯﾄあたりの重量(1PL当重量)
                    Dim strXDAN_IN_PALLET As String = ""        '1ﾊﾟﾚｯﾄの段数(1PL当段数)
                    Dim strXHEIGHT_IN_CASE As String = ""       '梱高さ
                    Dim strXHEIGHT_IN_PALLET As String = ""     'ﾊﾟﾚｯﾄ高さ(1PL当高さ)
                    Dim strFRAC_FORM As String = ""             '棚形状種別
                    Dim strXJAN_CD As String = ""               'JANｺｰﾄﾞ
                    Dim strXITF_CD As String = ""               'ITFｺｰﾄﾞ

                    Dim strXIN_RES_TYPE As String = ""          '空棚引当ﾀｲﾌﾟ

                    objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S201901                                  'ﾌｫｰﾏｯﾄ名ｾｯﾄ

                    strDIR_KUBUN = FORMAT_DSP_DSPDIR_KUBUN_INSERT                                               '指示区分(追加)
                    '(MAIN_KEY)
                    strXHINMEI_CD = TO_STRING(objHinmoku.Item(ii)(DKA8000_MAINKEY_INDEX).Trim)                  '品名ｺｰﾄﾞ
                    '(SUBKEY1)
                    Dim strSUBKEY1 As String = objHinmoku.Item(ii)(DKA8000_SUBKEY1_INDEX)
                    strXARTICLE_TYPE_CODE = strSUBKEY1.Substring(0, DKA8000_XARTICLE_TYPE_CODE)                 '品目種別
                    '(SUBKEY2)
                    ' ''strFHINMEI_CD = TO_STRING("")                                                               '品名記号
                    '(DATA1)
                    strFHINMEI = TO_STRING(objHinmoku.Item(ii)(DKA8000_DATA1_INDEX).Trim)                       '品名
                    '(DATA2)
                    Dim strDATA2 As String = objHinmoku.Item(ii)(DKA8000_DATA2_INDEX)
                    Dim intIndex As Integer = 0
                    strXWEIGHT_IN_CASE = strDATA2.Substring(intIndex, DKA8000_XWEIGHT_IN_CASE).Trim             '梱重量
                    intIndex = intIndex + DKA8000_XWEIGHT_IN_CASE
                    strFNUM_IN_PALLET = strDATA2.Substring(intIndex, DKA8000_FNUM_IN_PL).Trim                   'PL毎積載数(ﾊﾟﾚｯﾄ積付数)
                    intIndex = intIndex + DKA8000_FNUM_IN_PL
                    intIndex = intIndex + DKA8000_VAL8                                                          '入数/梱(未使用)
                    strXPLANE_PACK_NUMBER = strDATA2.Substring(intIndex, DKA8000_XPLANE_PACK_NUMBER).Trim       '平面梱数
                    intIndex = intIndex + DKA8000_XPLANE_PACK_NUMBER
                    strXWEIGHT_IN_PALLET = strDATA2.Substring(intIndex, DKA8000_XWEIGHT_IN_PL).Trim             'ﾊﾟﾚｯﾄあたりの重量(1PL当重量)
                    intIndex = intIndex + DKA8000_XWEIGHT_IN_PL
                    strXDAN_IN_PALLET = strDATA2.Substring(intIndex, DKA8000_XDAN_IN_PALLET).Trim               '1ﾊﾟﾚｯﾄの段数(1PL当段数)
                    intIndex = intIndex + DKA8000_XDAN_IN_PALLET
                    strXHEIGHT_IN_CASE = strDATA2.Substring(intIndex, DKA8000_XHEIGHT_IN_CASE).Trim             '梱高さ
                    intIndex = intIndex + DKA8000_XHEIGHT_IN_CASE
                    strXHEIGHT_IN_PALLET = strDATA2.Substring(intIndex, DKA8000_XHEIGHT_IN_PALLET).Trim         'ﾊﾟﾚｯﾄ高さ(1PL当高さ)
                    intIndex = intIndex + DKA8000_XHEIGHT_IN_PALLET
                    strFRAC_FORM = strDATA2.Substring(intIndex, DKA8000_FRAC_FROM).Trim                         '棚形状種別
                    intIndex = intIndex + DKA8000_FRAC_FROM
                    strXJAN_CD = strDATA2.Substring(intIndex, DKA8000_XJAN_CD).Trim                             'JANｺｰﾄﾞ
                    intIndex = intIndex + DKA8000_XJAN_CD
                    strXITF_CD = strDATA2.Substring(intIndex, DKA8000_XITF_CD).Trim                             'ITFｺｰﾄﾞ
                    intIndex = intIndex + DKA8000_XITF_CD
                    If TO_INTEGER(strXARTICLE_TYPE_CODE) = XARTICLE_TYPE_CODE_J03 Then                          '空棚引当ﾀｲﾌﾟ
                        '(品目種別が3=包材の場合)
                        strXIN_RES_TYPE = XIN_RES_TYPE_J04       '包材
                    Else
                        strXIN_RES_TYPE = XIN_RES_TYPE_J01       '液HBox
                    End If

                    objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                                    '指示区分
                    objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)                                   '品名記号
                    objTelegram.SETIN_DATA("DSPHINMEI", strFHINMEI)                                         '品名
                    objTelegram.SETIN_DATA("DSPNUM_IN_PALLET", strFNUM_IN_PALLET)                           'PL毎積載数(ﾊﾟﾚｯﾄ積付数)
                    objTelegram.SETIN_DATA("DSPRAC_FORM", strFRAC_FORM)                                     '棚形状種別
                    objTelegram.SETIN_DATA("XDSPPLANE_PACK_NUMBER", strXPLANE_PACK_NUMBER)                  '平面梱数
                    objTelegram.SETIN_DATA("XDSPWEIGHT_IN_CASE", strXWEIGHT_IN_CASE)                        '梱重量
                    objTelegram.SETIN_DATA("XDSPWEIGHT_IN_PALLET", strXWEIGHT_IN_PALLET)                    'ﾊﾟﾚｯﾄあたりの重量(1PL当重量)
                    objTelegram.SETIN_DATA("XDSPHEIGHT_IN_CASE", strXHEIGHT_IN_CASE)                        '梱高さ
                    objTelegram.SETIN_DATA("XDSPHEIGHT_IN_PALLET", strXHEIGHT_IN_PALLET)                    'ﾊﾟﾚｯﾄ高さ(1PL当高さ)
                    objTelegram.SETIN_DATA("XDSPARTICLE_TYPE_CODE", strXARTICLE_TYPE_CODE)                  '品目種別
                    objTelegram.SETIN_DATA("XDSPHINMEI_CD", strXHINMEI_CD)                                  '品名ｺｰﾄﾞ
                    objTelegram.SETIN_DATA("XDSPITF_CD", strXITF_CD)                                        'ITFｺｰﾄﾞ
                    objTelegram.SETIN_DATA("XDSPJAN_CD", strXJAN_CD)                                        'JANｺｰﾄﾞ
                    objTelegram.SETIN_DATA("XDSPDAN_IN_PALLET", strXDAN_IN_PALLET)                          '1ﾊﾟﾚｯﾄの段数(1PL当段数)
                    objTelegram.SETIN_DATA("XDSPIN_RES_TYPE", strXIN_RES_TYPE)                              '空棚引当ﾀｲﾌﾟ

                    'objTelegram.SETIN_DATA("XDSPSUB_CD", "")                            'ｻﾌﾞｺｰﾄﾞ

                    '*******************************************************
                    'ｿｹｯﾄ送信
                    '*******************************************************
                    If blnSockSend = True Then
                        Dim strRET_STATE As String = ""
                        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
                        Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

                        strErrMsg = "品目移行に失敗しました。"

                        udtSckSendRET = gobjComFuncFRM.SockSendServer_DATA_MOVE(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
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


            Catch ex As Exception
                Call gobjComFuncFRM.ComError_frm(ex)
                MsgBox(ex.Message)
            Finally

                '*******************************************************
                '後始末
                '*******************************************************
                objTextFieldParser01.Close()

            End Try

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            MsgBox(ex.Message)
        End Try

    End Sub
#End Region


End Class