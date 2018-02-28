'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出荷指示処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_400103
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0             '端末ID
    Private Const DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2              '理由
    Private Const XDSPSYUKKA_D As Integer = 3           '出荷日
    Private Const XDSPSYARYOU_NO As Integer = 4         '車輌番号
    Private Const XDSPTUMI_HOUKOU As Integer = 5        '積込方向
    Private Const XDSPTUMI_HOUHOU As Integer = 6        '積込方法
    Private Const XDSPBERTH_NO As Integer = 7           'ﾊﾞｰｽ指定
    Private Const XDSPKINKYU_KBN As Integer = 8         '緊急出荷区分
    Private Const XDSPHENSEI_NO As Integer = 9          '編成№
    Private Const XDSPDENPYOU_NO As Integer = 10        '伝票№
    Private Const XDSPHINMEI_CD As Integer = 11         '品目ｺｰﾄﾞ
    Private Const XDSPOUT_ORDER As Integer = 12         '車輌内出荷品目順

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
        Dim strDenbunDtl(0) As String         '電文分解配列
        Dim strDenbunDtlName(0) As String     '電文分解名称配列
        Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        Dim intRet As Integer                 '戻り値
        Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        Try


            '************************
            '初期処理
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call CheckBeforeAct(strDenbunDtl)


            '-------------------
            '車輌マスタ読込
            '-------------------
            Dim objMST_SYARYOU As New TBL_XMST_SYARYOU(Owner, ObjDb, ObjDbLog)
            objMST_SYARYOU.XSYARYOU_NO = strDenbunDtl(XDSPSYARYOU_NO)
            intRet = objMST_SYARYOU.GET_XMST_SYARYOU(False)
            If intRet = RetCode.OK Then
                If objMST_SYARYOU.XTUMI_HOUKOU <> TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUKOU)) Or _
                   objMST_SYARYOU.XTUMI_HOUHOU <> TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUHOU)) Then
                    objMST_SYARYOU.XTUMI_HOUKOU = TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUKOU)) '積込方向
                    objMST_SYARYOU.XTUMI_HOUHOU = TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUHOU)) '積込方法
                    objMST_SYARYOU.UPDATE_XMST_SYARYOU()
                End If
            ElseIf intRet = RetCode.NotFound Then
                objMST_SYARYOU.XSYARYOU_NO = TO_INTEGER(strDenbunDtl(XDSPSYARYOU_NO))       '車輌番号
                objMST_SYARYOU.XTUMI_HOUKOU = TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUKOU))     '積込方向
                objMST_SYARYOU.XTUMI_HOUHOU = TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUHOU))     '積込方法
                objMST_SYARYOU.XNOT_USER = XNOT_USER_JOFF                                   '未使用区分
                objMST_SYARYOU.FENTRY_DT = Now                                              '登録年月日
                objMST_SYARYOU.ADD_XMST_SYARYOU()
            End If
            If TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUHOU)) = XTUMI_HOUHOU_JL And _
               TO_INTEGER(objMST_SYARYOU.XLOADER_POSSIBLE) <> FLAG_ON Then
                strMsg = "ローダ未対応の車輌です。[車輌番号:" & strDenbunDtl(XDSPSYARYOU_NO) & "]"
                Throw New UserException(strMsg)
            End If

            '-------------------
            '作業種別
            '-------------------
            Dim intSAGYOU_KIND As Integer
            If TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUHOU)) = XTUMI_HOUHOU_JP Then
                intSAGYOU_KIND = FSAGYOU_KIND_J55                                       '作業種別(ﾊﾟﾚｯﾄ出庫)
            ElseIf TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUHOU)) = XTUMI_HOUHOU_JB Then
                intSAGYOU_KIND = FSAGYOU_KIND_J56                                       '作業種別(ﾊﾞﾗ出庫)
            ElseIf TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUHOU)) = XTUMI_HOUHOU_JL Then
                intSAGYOU_KIND = FSAGYOU_KIND_J57                                       '作業種別(ﾛｰﾀﾞ出庫)
            Else
                strMsg = "積込方法が正しく設定されていません。[積込方法:" & strDenbunDtl(XDSPTUMI_HOUHOU) & "]"
                Throw New UserException(strMsg)
            End If

            '-------------------    
            '緊急度読込
            '-------------------
            Dim intKINKYU_LEVEL As Integer = 0
            If TO_INTEGER(strDenbunDtl(XDSPKINKYU_KBN)) > 0 Then
                Dim strSQL As String                    'SQL文
                Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
                Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
                Dim objPLN_OUT_ARY As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
                strSQL = ""
                strSQL &= vbCrLf & "SELECT"
                strSQL &= vbCrLf & "    MAX(XKINKYU_LEVEL) + 1 AS XKINKYU_LEVEL"
                strSQL &= vbCrLf & " FROM"
                strSQL &= vbCrLf & "    XPLN_OUT"
                strSQL &= vbCrLf & " WHERE"
                strSQL &= vbCrLf & "    XSYUKKA_STS <= " & XSYUKKA_STS_JDIR                 '出荷状況
                strSQL &= vbCrLf
                objPLN_OUT_ARY.USER_SQL = strSQL
                ObjDb.SQL = strSQL
                objDataSet.Clear()
                strDataSetName = "XPLN_OUT"
                ObjDb.GetDataSet(strDataSetName, objDataSet)
                If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                    intKINKYU_LEVEL = TO_INTEGER(objDataSet.Tables(strDataSetName).Rows(0).Item("XKINKYU_LEVEL"))
                End If
                If intKINKYU_LEVEL = 0 Then
                    intKINKYU_LEVEL = 1
                End If
            End If

            '************************
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ取得
            '************************
            Dim objTPRG_PARAM_TBL As New TBL_TPRG_PARAM_TBL(Owner, ObjDb, ObjDbLog)     'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ
            objTPRG_PARAM_TBL.FPARA_ID = strDenbunDtl(DSPTERM_ID)                       'ﾊﾟﾗﾒｰﾀID
            intRet = objTPRG_PARAM_TBL.GET_TPRG_PARAM_TBL_FPARA_ID()                    '特定
            If intRet = RetCode.OK Then
                Dim dtmSYUKKA_D(UBound(objTPRG_PARAM_TBL.ARYME)) As Nullable(Of Date)               '出荷日
                Dim strHENSEI_NO(UBound(objTPRG_PARAM_TBL.ARYME)) As String                         '編成№
                Dim strDENPYOU_NO(UBound(objTPRG_PARAM_TBL.ARYME)) As String                        '伝票№
                Dim strHINMEI_CD(UBound(objTPRG_PARAM_TBL.ARYME)) As String                         '品名ｺｰﾄﾞ
                Dim intOUT_ORDER(UBound(objTPRG_PARAM_TBL.ARYME)) As Integer                        '車輌内出荷品目順

                For ii As Integer = LBound(objTPRG_PARAM_TBL.ARYME) To UBound(objTPRG_PARAM_TBL.ARYME)
                    '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


                    Dim objTel As New clsTelegram(CONFIG_TELEGRAM_DSP)                  '受信用電文
                    objTel.FORMAT_ID = MeDSPID                                          'ﾌｫｰﾏｯﾄ名ｾｯﾄ
                    objTel.TELEGRAM_PARTITION = objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA  '分割する電文ｾｯﾄ
                    objTel.PARTITION()                                                  '電文分割


                    dtmSYUKKA_D(ii) = TO_DATE(Trim(objTel.SELECT_DATA("XDSPSYUKKA_D")))             '出荷日
                    strHENSEI_NO(ii) = Trim(objTel.SELECT_DATA("XDSPHENSEI_NO"))                    '編成№
                    strDENPYOU_NO(ii) = Trim(objTel.SELECT_DATA("XDSPDENPYOU_NO"))                  '伝票№
                    strHINMEI_CD(ii) = Trim(objTel.SELECT_DATA("DSPHINMEI_CD"))                     '品名ｺｰﾄﾞ
                    intOUT_ORDER(ii) = TO_INTEGER(objTel.SELECT_DATA("XDSPOUT_ORDER"))              '車輌内出荷品目順

                    '-------------------
                    '出荷指示更新済み判定
                    '-------------------
                    Dim blnFLG As Boolean = False
                    For jj As Integer = 0 To ii
                        If jj <> ii And _
                           dtmSYUKKA_D(ii) = dtmSYUKKA_D(jj) And _
                           strHENSEI_NO(ii) = strHENSEI_NO(jj) And _
                           strDENPYOU_NO(ii) = strDENPYOU_NO(jj) Then
                            blnFLG = True                               '処理済
                            Exit For
                        End If
                    Next
                    If blnFLG = False Then                              '未処理ﾃﾞｰﾀの更新
                        '-------------------
                        '出荷指示更新
                        '-------------------
                        Dim objPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
                        objPLN_OUT.XSYUKKA_D = dtmSYUKKA_D(ii)
                        objPLN_OUT.XHENSEI_NO = strHENSEI_NO(ii)
                        objPLN_OUT.XDENPYOU_NO = strDENPYOU_NO(ii)
                        intRet = objPLN_OUT.GET_XPLN_OUT(False)
                        If intRet = RetCode.OK Then
                            If TO_INTEGER(strDenbunDtl(XDSPKINKYU_KBN)) > 0 Then
                                objPLN_OUT.XKINKYU_LEVEL = intKINKYU_LEVEL                          '緊急度
                            End If

                            '↓↓↓↓↓↓************************************************************************************************************
                            'JobMate:N.Dounoshita 2013/08/20 同じ計画を同時に指示された時の対応


                            If objPLN_OUT.XSYUKKA_STS <> XSYUKKA_STS_JREQ Then
                                '(指示済以外の場合)
                                '(同じ計画を同時に指示された時の対応)
                                strMsg = "出荷指示の進捗が「受付済」ではないので、受け付けられません。" & vbCrLf & "[出荷日:" & Trim(objTel.SELECT_DATA("XDSPSYUKKA_D")) & _
                                                                                                                  "][編成№:" & Trim(objTel.SELECT_DATA("XDSPHENSEI_NO")) & _
                                                                                                                  "][伝票№:" & Trim(objTel.SELECT_DATA("XDSPDENPYOU_NO")) & "]"
                                Throw New UserException(strMsg)
                            End If


                            '↑↑↑↑↑↑************************************************************************************************************
                            '-------------------
                            '出荷指示更新(指示済)
                            '-------------------
                            objPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JDIR                               '出荷状況(指示済)
                            objPLN_OUT.XSYARYOU_NO = TO_INTEGER(strDenbunDtl(XDSPSYARYOU_NO))       '車輌番号
                            objPLN_OUT.XTUMI_HOUKOU = TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUKOU))     '積込方向
                            objPLN_OUT.XTUMI_HOUHOU = TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUHOU))     '積込方法
                            objPLN_OUT.XBERTH_NO = Trim(objTel.SELECT_DATA("XDSPBERTH_NO"))         'ﾊﾞｰｽ№
                            objPLN_OUT.XSYUKKA_DIR_DT = Now                                         '出荷指示日時
                            objPLN_OUT.UPDATE_XPLN_OUT()
                        Else
                            strMsg = "出荷指示が存在しません。[出荷日:" & Trim(objTel.SELECT_DATA("XDSPSYUKKA_D")) & _
                                                            "][編成№:" & Trim(objTel.SELECT_DATA("XDSPHENSEI_NO")) & _
                                                            "][伝票№:" & Trim(objTel.SELECT_DATA("XDSPDENPYOU_NO")) & "]"
                            Throw New UserException(strMsg)
                        End If
                    End If

                    If IsNull(dtmSYUKKA_D(ii)) = False And _
                       IsNull(strHENSEI_NO(ii)) = False And _
                       IsNull(strDENPYOU_NO(ii)) = False And _
                       IsNull(strHINMEI_CD(ii)) = False Then

                        '-------------------
                        '出荷指示詳細の特定
                        '-------------------
                        Dim objXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)         '出荷指示詳細ｸﾗｽ
                        objXPLN_OUT_DTL.XSYUKKA_D = dtmSYUKKA_D(ii)                                 '出荷日
                        objXPLN_OUT_DTL.XHENSEI_NO = strHENSEI_NO(ii)                               '編成№
                        objXPLN_OUT_DTL.XDENPYOU_NO = strDENPYOU_NO(ii)                             '伝票№
                        objXPLN_OUT_DTL.FHINMEI_CD = strHINMEI_CD(ii)                               '品名ｺｰﾄﾞ
                        intRet = objXPLN_OUT_DTL.GET_XPLN_OUT_DTL(False)                            '特定
                        If intRet = RetCode.OK Then
                            objXPLN_OUT_DTL.FSAGYOU_KIND = intSAGYOU_KIND                                       '作業種別
                            objXPLN_OUT_DTL.XOUT_ORDER = TO_INTEGER(Trim(objTel.SELECT_DATA("XDSPOUT_ORDER")))  '車輌内出荷品目順
                            objXPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()
                        Else
                            strMsg = "出荷指示詳細が存在しません。[出荷日:" & Trim(objTel.SELECT_DATA("XDSPSYUKKA_D")) & _
                                                                "][編成№:" & Trim(objTel.SELECT_DATA("XDSPHENSEI_NO")) & _
                                                                "][伝票№:" & Trim(objTel.SELECT_DATA("XDSPDENPYOU_NO")) & _
                                                                "][品名ｺｰﾄﾞ:" & Trim(objTel.SELECT_DATA("XDSPHINMEI_CD")) & "]"
                            Throw New UserException(strMsg)
                        End If
                    End If

                Next
            End If


            '-------------------
            'ﾊﾞｰｽ引当処理起動
            '-------------------
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '定周期管理ｸﾗｽ


            objTPRG_TIMER.FSYORI_ID = FORMAT_DSP_DELCMD & FSYORI_ID_J310301
            objTPRG_TIMER.GET_TPRG_TIMER()

            If DateDiff(DateInterval.Second, TO_DATE(objTPRG_TIMER.FLAST_DT), Now) > objTPRG_TIMER.FTIME_OUT_SEC Then
                objTPRG_TIMER.KIDOU_ON(FSYORI_ID_J310301)                               '起動
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
            If strDenbunDtl(DSPTERM_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[端末ID]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPUSER_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[ﾕｰｻﾞｰID]"
                Throw New UserException(strMsg)
            ElseIf TO_INTEGER(strDenbunDtl(XDSPSYARYOU_NO)) = 0 Then
                strMsg = ERRMSG_DISP_SOCKET & "[車輌番号]"
                Throw New System.Exception(strMsg)
            ElseIf TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUKOU)) <> XTUMI_HOUKOU_JBACK And _
                   TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUKOU)) <> XTUMI_HOUKOU_JSIDE And _
                   TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUKOU)) <> XTUMI_HOUKOU_JWING Then
                strMsg = ERRMSG_DISP_SOCKET & "[積込方向]"
                Throw New System.Exception(strMsg)
            ElseIf TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUHOU)) <> XTUMI_HOUHOU_JP And _
                   TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUHOU)) <> XTUMI_HOUHOU_JB And _
                   TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUHOU)) <> XTUMI_HOUHOU_JL Then
                strMsg = ERRMSG_DISP_SOCKET & "[積込方法]"
                Throw New System.Exception(strMsg)
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
