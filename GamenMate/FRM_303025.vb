'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】問合せ出庫設定ﾃｽﾄ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess

#End Region

Public Class FRM_303025

    '問合せ出庫電文用構造体
    Private mudtDSP_201601() As DSP_201601

    ''' <summary>問合せ出庫 電文</summary>
    Private Structure DSP_201601
        Dim DSPPALLET_ID As String          'ﾊﾟﾚｯﾄID
        Dim DSPST_OUT As String             '出庫先ST
        Dim XDSPPALLET_ID_KO As String      'ﾊﾟﾚｯﾄID(子)
        Dim XDSPYOTEI_NUM As String         '予定数
        Dim XDSPYOTEI_EQ_ID As String       '予定設備ID
    End Structure

#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_303025_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '===================================
        'ﾊﾟﾚｯﾄID ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================

        cboFPALLET_ID_KO.Items.Add("")

        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ
        Dim strSQL As String = ""

        '********************************************************************
        ' ｺﾈｸｼｮﾝの確認
        '********************************************************************
        If IsNull(gobjDb) = True Then
            'ｺﾈｸｼｮﾝがｾｯﾄされていない場合は終了
            Return
        End If

        '********************************************************************
        ' SQL文
        '********************************************************************
        strSQL = ""
        '(Select句)
        strSQL &= vbCrLf & " SELECT  "
        strSQL &= vbCrLf & "     TRST_STOCK.FPALLET_ID "                            '在庫情報       .ﾊﾟﾚｯﾄID
        'strSQL &= vbCrLf & "   , TMST_ITEM.XMAKER_CD "                              '品目ﾏｽﾀ        .ﾒｰｶｰｺｰﾄﾞ
        '(From句)
        strSQL &= vbCrLf & " FROM   "
        strSQL &= vbCrLf & "     TRST_STOCK "                                       '【在庫情報】
        'strSQL &= vbCrLf & "   , XMST_WRAPPING_MAKER "                              '【包材ﾒｰｶｰﾏｽﾀ】
        'strSQL &= vbCrLf & "   , XMST_PROD_LINE "                                   '【生産ﾗｲﾝﾏｽﾀ】
        '(Where句)
        'strSQL &= vbCrLf & " WHERE  "
        'strSQL &= vbCrLf & "     TMST_ITEM.XMAKER_CD = XMST_WRAPPING_MAKER.XMAKER_CD(+) "
        'strSQL &= vbCrLf & " AND TMST_ITEM.FHINMEI_CD = XMST_PROD_LINE.FHINMEI_CD(+) "
        'strSQL &= vbCrLf & " AND TMST_ITEM.FHINMEI_CD = '" & cboFHINMEI_CD.Text & "' "
        '(Order)
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     TRST_STOCK.FPALLET_ID "

        '********************************************************************
        ' 実行
        '********************************************************************
        gobjDb.SQL = strSQL

        objDataSet.Clear()
        gobjDb.GetDataSet("STOCK", objDataSet)

        If objDataSet.Tables("STOCK").Rows.Count > 0 Then
            Dim ii As Integer

            For ii = 0 To objDataSet.Tables("STOCK").Rows.Count - 1
                cboFPALLET_ID_OYA.Items.Add(TO_STRING(objDataSet.Tables("STOCK").Rows(ii).Item("FPALLET_ID")))
                cboFPALLET_ID_KO.Items.Add(TO_STRING(objDataSet.Tables("STOCK").Rows(ii).Item("FPALLET_ID")))
            Next

        End If



        '===================================
        '出庫ST ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup("FRM_303020", cboFTRK_BUF_NO, False, -1)





        mudtDSP_201601 = Nothing

    End Sub
#End Region


    '追加ﾎﾞﾀﾝ
    Private Sub cmdADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdADD.Click

        'ﾁｪｯｸ
        If cboFPALLET_ID_OYA.Text = "" Then
            Exit Sub
        End If

        If cboFTRK_BUF_NO.Text = "" Then
            Exit Sub
        End If

        'If cboFPALLET_ID_KO.Text = "" Then
        '    Exit Sub
        'End If



        If mudtDSP_201601 Is Nothing Then
            ReDim mudtDSP_201601(0)
        Else
            ReDim Preserve mudtDSP_201601(UBound(mudtDSP_201601) + 1)
        End If


        mudtDSP_201601(UBound(mudtDSP_201601)).DSPPALLET_ID = cboFPALLET_ID_OYA.Text
        mudtDSP_201601(UBound(mudtDSP_201601)).DSPST_OUT = TO_STRING(cboFTRK_BUF_NO.SelectedValue)
        mudtDSP_201601(UBound(mudtDSP_201601)).XDSPPALLET_ID_KO = cboFPALLET_ID_KO.Text


        txtTelegram.Text = txtTelegram.Text & " 親:" & cboFPALLET_ID_OYA.Text & "    子:" & cboFPALLET_ID_KO.Text & "    出庫ST:" & TO_STRING(cboFTRK_BUF_NO.SelectedValue) & vbCrLf


    End Sub




    '送信ﾎﾞﾀﾝ
    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click

        If mudtDSP_201601 Is Nothing Then
            Exit Sub
        End If

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303020_09, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If


        '********************************************************************
        ' 出庫在庫ﾃﾞｰﾀｾｯﾄ
        '********************************************************************
        'Dim udtOUT_STOCK() As STOCK_DATA = Nothing      '出庫在庫ﾃﾞｰﾀ用構造体
        Dim strSndTlgrm() As String = Nothing           '送信電文文字列
        Dim intHairetu As Integer = 0                   '配列数
        'Dim intRet As RetCode
        Dim strMsg As String = ""
        Dim strXADRS_YOTEI = ""                         '予定数ｱﾄﾞﾚｽ
        Dim strOUTST_NO As String = ""                  'ｽﾃｰｼｮﾝID
        Dim blnPareFlag As Boolean = False              'ﾍﾟｱ出庫ﾌﾗｸﾞ

        '********************************************************************
        ' 出庫数予約用 電文作成
        '********************************************************************
        strOUTST_NO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)                   '出庫先ST

        '予定設備IDの取得
        Dim intRet As RetCode
        Dim objTBL_TMST_TRK As TBL_TMST_TRK                                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        objTBL_TMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)

        objTBL_TMST_TRK.FTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.

        intRet = objTBL_TMST_TRK.GET_TMST_TRK(False)
        If intRet = RetCode.OK Then
            '(値がある時)
            If Not objTBL_TMST_TRK.XADRS_YOTEI01 Is Nothing Then
                strXADRS_YOTEI = objTBL_TMST_TRK.XADRS_YOTEI01                  '予定数ｱﾄﾞﾚｽ
            Else
                'Throw New System.Exception(FRM_MSG_FRM303020_10)
            End If

        Else
            '(読めなかった時)
            'Throw New System.Exception(FRM_MSG_FRM303020_10)
        End If


        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S201601

        objTelegram.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegram.FORMAT_ID, 6))    'ｺﾏﾝﾄﾞID
        objTelegram.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                           '端末ID
        objTelegram.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                           '担当者ｺｰﾄﾞ

        objTelegram.SETIN_DATA("DSPPALLET_ID", "")                                                      'ﾊﾟﾚｯﾄID
        objTelegram.SETIN_DATA("DSPST_OUT", strOUTST_NO)                                                '出庫先ST
        objTelegram.SETIN_DATA("XDSPPALLET_ID_KO", "")                                                  'ﾊﾟﾚｯﾄID(子)
        objTelegram.SETIN_DATA("XDSPYOTEI_NUM", TO_STRING(mudtDSP_201601.Length))                       '予定数
        objTelegram.SETIN_DATA("XDSPYOTEI_EQ_ID", strXADRS_YOTEI)                                       '予定設備ID

        '送信電文
        ReDim strSndTlgrm(0)
        objTelegram.MAKE_TELEGRAM()
        strSndTlgrm(0) = objTelegram.TELEGRAM_MAKED

        '********************************************************************
        ' 問合せ出庫用 電文作成
        '********************************************************************
        If Not mudtDSP_201601 Is Nothing Then
            '(手前棚を出庫する場合)

            For ii As Integer = 0 To UBound(mudtDSP_201601)
                '(手前棚分 電文作成)

                '配列再定義
                intHairetu = intHairetu + 1
                ReDim Preserve strSndTlgrm(0 To intHairetu)         '送信電文文字列


                Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

                objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S201601

                objTelegramSub.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegramSub.FORMAT_ID, 6))  'ｺﾏﾝﾄﾞID
                objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                            '端末ID
                objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                            '担当者ｺｰﾄﾞ

                objTelegramSub.SETIN_DATA("DSPPALLET_ID", mudtDSP_201601(ii).DSPPALLET_ID)                          'ﾊﾟﾚｯﾄID(親)
                objTelegramSub.SETIN_DATA("DSPST_OUT", mudtDSP_201601(ii).DSPST_OUT)                                '出庫先ST
                objTelegramSub.SETIN_DATA("XDSPPALLET_ID_KO", mudtDSP_201601(ii).XDSPPALLET_ID_KO)                  'ﾊﾟﾚｯﾄID(子)

                objTelegramSub.MAKE_TELEGRAM()
                strSndTlgrm(intHairetu) = objTelegramSub.TELEGRAM_MAKED                                            '送信電文

            Next

        End If

        '********************************************************************
        ' ｿｹｯﾄ送信処理
        '********************************************************************
        Dim strRetState() As String = Nothing               '出庫処理戻りｽﾃｰﾀｽ
        Dim strErrMsg As String = ""                        'ｴﾗｰﾒｯｾｰｼﾞ
        Dim udtSckSendRET As clsSocketClient.RetCode        'ｿｹｯﾄ送信戻り値
        Dim strRET_STATE As String = ""

        Dim objTelegramNull As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegramNull.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S201601

        '=====================================
        '複数ｿｹｯﾄ処理
        '=====================================
        strErrMsg = FRM_MSG_FRM303020_10
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegramNull, strSndTlgrm, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)

            End If
        End If

    End Sub

    '閉じるﾎﾞﾀﾝ
    Private Sub cmdReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReturn.Click
        Me.Close()
    End Sub


    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        mudtDSP_201601 = Nothing
        txtTelegram.Text = ""

    End Sub
End Class
