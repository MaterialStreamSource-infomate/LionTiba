'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】車両受付処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_400102
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0                 '端末ID
    Private Const DSPUSER_ID As Integer = 1                 'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2                  '理由
    Private Const XDSPSYARYOU_NO As Integer = 3             '車輌番号
    Private Const XDSPHENSEI_NO1 As Integer = 4             '編成№1
    Private Const XDSPHENSEI_NO2 As Integer = 5             '編成№2
    Private Const XDSPHENSEI_NO3 As Integer = 6             '編成№3
    Private Const XDSPHENSEI_NO4 As Integer = 7             '編成№4
    Private Const XDSPTUMI_HOUKOU As Integer = 8            '積込方向
    Private Const XDSPTUMI_HOUHOU As Integer = 9            '積込方法

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
                Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, strMsg)
                Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & strMsg & "]")
                Return RetCode.NG
            End If

            Dim strHENSEI_NO_Ary(3) As String                                               '編成№配列
            strHENSEI_NO_Ary(0) = strDenbunDtl(XDSPHENSEI_NO1)                              '編成№1
            strHENSEI_NO_Ary(1) = strDenbunDtl(XDSPHENSEI_NO2)                              '編成№2
            strHENSEI_NO_Ary(2) = strDenbunDtl(XDSPHENSEI_NO3)                              '編成№3
            strHENSEI_NO_Ary(3) = strDenbunDtl(XDSPHENSEI_NO4)                              '編成№4

            '-------------------    
            '親編成№の確定
            '-------------------
            Dim intII As Integer
            Dim intMinHENSEI_NO As Integer = Integer.MaxValue
            Dim strOyaHENSEI_NO As String = ""
            For intII = LBound(strHENSEI_NO_Ary) To UBound(strHENSEI_NO_Ary)
                If strHENSEI_NO_Ary(intII) <> DEFAULT_STRING Then
                    If intMinHENSEI_NO > TO_INTEGER(strHENSEI_NO_Ary(intII)) Then
                        intMinHENSEI_NO = TO_INTEGER(strHENSEI_NO_Ary(intII))
                        strOyaHENSEI_NO = strHENSEI_NO_Ary(intII)
                    End If
                End If
            Next
            If intMinHENSEI_NO = Integer.MaxValue Then
                strMsg = ERRMSG_DISP_SOCKET & "[編成№]"
                Throw New System.Exception(strMsg)
            End If

            '-------------------    
            '出荷指示読込
            '-------------------
            Dim dtmSYUKKA_D As Nullable(Of Date) = DEFAULT_DATE
            For intII = LBound(strHENSEI_NO_Ary) To UBound(strHENSEI_NO_Ary)
                If strHENSEI_NO_Ary(intII) <> DEFAULT_STRING Then
                    Dim objPLN_OUT_ARY As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
                    objPLN_OUT_ARY.XHENSEI_NO = strHENSEI_NO_Ary(intII)
                    intRet = objPLN_OUT_ARY.GET_PLN_OUT_HENSEI_MINYUKOU()
                    If intRet = RetCode.OK Then
                        For Each objPLN_OUT As TBL_XPLN_OUT In objPLN_OUT_ARY.ARYME
                            '-------------------
                            '出荷指示更新(受付済)
                            '-------------------
                            objPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JREQ                               '出荷状況(受付済)
                            objPLN_OUT.XSYARYOU_NO = TO_INTEGER(strDenbunDtl(XDSPSYARYOU_NO))       '車輌番号
                            objPLN_OUT.XTUMI_HOUKOU = TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUKOU))     '積込方向
                            objPLN_OUT.XTUMI_HOUHOU = TO_INTEGER(strDenbunDtl(XDSPTUMI_HOUHOU))     '積込方法
                            objPLN_OUT.XSYARYOU_ENTRY_DT = Now                                      '車輌受付日時
                            objPLN_OUT.XHENSEI_NO_OYA = strOyaHENSEI_NO                             '親編成№
                            objPLN_OUT.UPDATE_XPLN_OUT()


                            '↓↓↓↓↓↓************************************************************************************************************
                            'JobMate:N.Dounoshita 2013/08/15 親編成№が更新されていなかったので、修正


                            '------------------------
                            '出荷指示詳細       更新
                            '------------------------
                            Dim objAryXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)     '出荷指示詳細ｸﾗｽ
                            objAryXPLN_OUT_DTL.XSYUKKA_D = objPLN_OUT.XSYUKKA_D         '出荷日
                            objAryXPLN_OUT_DTL.XHENSEI_NO = objPLN_OUT.XHENSEI_NO       '編成No.
                            objAryXPLN_OUT_DTL.XDENPYOU_NO = objPLN_OUT.XDENPYOU_NO     '伝票No.
                            intRet = objAryXPLN_OUT_DTL.GET_XPLN_OUT_DTL_ANY            '取得
                            If intRet = RetCode.OK Then
                                For Each objXPLN_OUT_DTL As TBL_XPLN_OUT_DTL In objAryXPLN_OUT_DTL.ARYME
                                    objXPLN_OUT_DTL.XHENSEI_NO_OYA = strOyaHENSEI_NO    '親編成№
                                    objXPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()               '更新
                                Next
                            End If


                            '↑↑↑↑↑↑************************************************************************************************************


                            If (dtmSYUKKA_D Is Nothing) = True Then
                                dtmSYUKKA_D = objPLN_OUT.XSYUKKA_D
                            Else
                                If dtmSYUKKA_D <> objPLN_OUT.XSYUKKA_D Then
                                    strMsg = "出荷日が異なる編成№が選択されました。"
                                    Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, strMsg)
                                    Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & strMsg & "]")
                                    Return RetCode.NG
                                End If
                            End If
                        Next
                    ElseIf intRet = RetCode.NotFound Then
                        objPLN_OUT_ARY.XHENSEI_NO = strHENSEI_NO_Ary(intII)
                        intRet = objPLN_OUT_ARY.GET_PLN_OUT_HENSEI_MINCOMPLETE()
                        If intRet = RetCode.OK Then
                            If objPLN_OUT_ARY.XSYARYOU_NO = TO_INTEGER(strDenbunDtl(XDSPSYARYOU_NO)) Then
                                strMsg = "受付処理は既に実行済みです。"
                                Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, strMsg)
                                Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & strMsg & "]")
                                Return RetCode.NG
                            Else
                                strMsg = "受付処理は既に実行済みです。[車輌番号:" & objPLN_OUT_ARY.XSYARYOU_NO & "]"
                                Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, strMsg)
                                Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & strMsg & "]")
                                Return RetCode.NG
                            End If
                        Else
                            strMsg = "出荷指示が存在しません。[編成№:" & strHENSEI_NO_Ary(intII) & "]"
                            Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, strMsg)
                            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & strMsg & "]")
                            Return RetCode.NG
                        End If
                    End If
                End If
            Next


            '----------------------
            '車輌内出荷品目順更新
            '----------------------
            Call Update_OUT_ORDER(dtmSYUKKA_D, strOyaHENSEI_NO)


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
            ElseIf strDenbunDtl(XDSPHENSEI_NO1) = "" And _
                   strDenbunDtl(XDSPHENSEI_NO2) = "" And _
                   strDenbunDtl(XDSPHENSEI_NO3) = "" And _
                   strDenbunDtl(XDSPHENSEI_NO4) = "" Then
                strMsg = ERRMSG_DISP_SOCKET & "[編成№]"
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

#Region "  車輌内出荷品目順更新                                                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 車輌内出荷品目順更新
    ''' </summary>
    ''' <param name="dtmSYUKKA_D">出荷日</param>
    ''' <param name="strHENSEI_NO_OYA">親編成№</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Update_OUT_ORDER(ByVal dtmSYUKKA_D As Date, ByVal strHENSEI_NO_OYA As String)
        Try
            Dim strSQL As String                'SQL文
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim intII As Integer                'ｶｳﾝﾀ
            Dim intORDER As Integer = 0         '車輌内出荷品目順
            Dim intRet As RetCode               '戻り値
            Dim strMsg As String                'ﾒｯｾｰｼﾞ


            '-----------------------
            '抽出SQL作成
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XPLN_OUT_DTL"           '出荷指示詳細
            strSQL &= vbCrLf & "   ,TMST_ITEM"              '品名ﾏｽﾀ
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        XPLN_OUT_DTL.XSYUKKA_D = TO_DATE('" & Format(dtmSYUKKA_D, "yyyy/MM/dd") & "','YYYY/MM/DD')"   '出荷日
            strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XHENSEI_NO_OYA = '" & TO_STRING(strHENSEI_NO_OYA) & "'"    '親編成№
            strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD"                         '品名ｺｰﾄﾞ
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    TMST_ITEM.XHEIGHT_IN_PALLET DESC"       '荷高
            strSQL &= vbCrLf & "   ,TMST_ITEM.FHINMEI_CD"                   '品名ｺｰﾄﾞ
            strSQL &= vbCrLf & "   ,XPLN_OUT_DTL.XHENSEI_NO"                '編成№
            strSQL &= vbCrLf


            '-----------------------
            '抽出
            '-----------------------
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "XPLN_OUT_DTL"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For intII = 0 To objDataSet.Tables(strDataSetName).Rows.Count - 1
                    objRow = objDataSet.Tables(strDataSetName).Rows(intII)

                    '-----------------------
                    '出荷指示詳細の特定
                    '-----------------------
                    Dim objXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)     '出荷指示詳細ｸﾗｽ
                    objXPLN_OUT_DTL.XSYUKKA_D = TO_DATE(objRow("XSYUKKA_D"))                '出荷日
                    objXPLN_OUT_DTL.XHENSEI_NO = TO_STRING(objRow("XHENSEI_NO"))            '編成№
                    objXPLN_OUT_DTL.XDENPYOU_NO = TO_STRING(objRow("XDENPYOU_NO"))          '伝票№
                    objXPLN_OUT_DTL.FHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))            '品名ｺｰﾄﾞ
                    intRet = objXPLN_OUT_DTL.GET_XPLN_OUT_DTL()                             '特定
                    If intRet = RetCode.NotFound Then
                        '(見つからない場合)
                        strMsg = ERRMSG_NOTFOUND_XPLN_OUT_DTL & "[出荷日:" & objXPLN_OUT_DTL.XSYUKKA_D & "  ,親編成№:" & objXPLN_OUT_DTL.XHENSEI_NO_OYA & "  ,品名ｺｰﾄﾞ:" & objXPLN_OUT_DTL.FHINMEI_CD & "]"
                        Throw New System.Exception(strMsg)
                    End If


                    '-----------------------
                    '出荷指示詳細の更新
                    '-----------------------
                    intORDER += 1
                    objXPLN_OUT_DTL.XOUT_ORDER = intORDER               '車輌内出荷品目順
                    objXPLN_OUT_DTL.XHENSEI_NO_OYA = strHENSEI_NO_OYA   '親編成№
                    objXPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()               '更新

                Next
            End If


        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
