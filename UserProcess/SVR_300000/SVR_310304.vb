'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出庫順制御処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_310304
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "
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
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '****************************************
            '初期設定
            '****************************************
            Dim dtmNow01 As Date = Now
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)
            Dim intOutSiziSameNum As Integer = objTPRG_SYS_HEN.SJ000000_001     '同時出庫指示数


            '************************************************************************************************************************
            '************************************************************************************************************************
            'ﾙｰﾌﾟ:搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            '************************************************************************************************************************
            '************************************************************************************************************************
            '****************************************
            'まだ出庫していない自動倉庫ﾄﾗｯｷﾝｸﾞ取得
            '****************************************
            Dim strSQL01 As String = ""       'SQL文
            strSQL01 &= vbCrLf & " SELECT "
            strSQL01 &= vbCrLf & "    FTR_TO "
            strSQL01 &= vbCrLf & " FROM "
            strSQL01 &= vbCrLf & "    TPRG_TRK_BUF "
            strSQL01 &= vbCrLf & "   ,TPLN_CARRY_QUE "
            strSQL01 &= vbCrLf & " WHERE "
            strSQL01 &= vbCrLf & "    1 = 1 "
            strSQL01 &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID = TPLN_CARRY_QUE.FPALLET_ID "           '結合
            strSQL01 &= vbCrLf & "    AND TPRG_TRK_BUF.FRES_KIND  = " & FRES_KIND_SRSV_TRNS_OUT & " "     '引当状態
            strSQL01 &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO= " & FTRK_BUF_NO_J9000 & " "           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            strSQL01 &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID IS NOT NULL "                           'ﾊﾟﾚｯﾄID
            strSQL01 &= vbCrLf & "    AND TPLN_CARRY_QUE.FCARRYQUE_DIR_STS = " & FCARRYQUE_DIR_STS_JTAIKI & " "   '搬送指示状況
            strSQL01 &= vbCrLf & " GROUP BY "
            strSQL01 &= vbCrLf & "    FTR_TO "
            strSQL01 &= vbCrLf & " ORDER BY "
            strSQL01 &= vbCrLf & "    FTR_TO "
            strSQL01 &= vbCrLf
            '抽出
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            'Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            ObjDb.SQL = strSQL01
            objDataSet.Clear()
            strDataSetName = "TRST_STOCK"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '(見つかった場合)

                For Each objRow As DataRow In objDataSet.Tables(strDataSetName).Rows
                    '(ﾙｰﾌﾟ:取得したﾃﾞｰﾀ数)


                    '****************************************
                    '初期設定
                    '****************************************
                    Dim intFTR_TO As Integer = objRow(0)                '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    Dim strFTR_TO As String = TO_STRING(objRow(0))      '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    Dim intSendPairCount As Integer = 0                 '出庫指示電文送信件数ｶｳﾝﾄ(ﾍﾟｱ)
                    Dim intSendSingleCount As Integer = 0               '出庫指示電文送信件数ｶｳﾝﾄ(ｼﾝｸﾞﾙ)
                    Dim intXOUT_ORDER_Memory As Nullable(Of Integer) = Nothing      '車輌内出荷品目順(記憶用)


                    '****************************************
                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ            取得
                    '****************************************
                    Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                    objTMST_TRK.FTRK_BUF_NO = intFTR_TO             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTMST_TRK.GET_TMST_TRK()                      '取得


                    ' '' ''************************************************
                    ' '' ''設備状況(出庫要求)         取得
                    ' '' ''************************************************
                    '' ''Dim objTSTS_EQ_CTRL_OUT_YOUKYU As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)      '入庫要求前 設備ID
                    '' ''Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_OUT_YOUKYU, objTMST_TRK.XEQ_ID_OUT_YOUKYU)     '出庫要求   設備ID
                    '' ''If objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_STS = FLAG_OFF Then
                    '' ''    '(出庫要求が立っていない場合)
                    '' ''    Continue For
                    '' ''End If


                    '****************************************
                    '搬送中ﾄﾗｯｷﾝｸﾞ              ﾁｪｯｸ
                    '****************************************
                    Dim intCheckCount As Integer = 0
                    Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    objTPRG_TRK_BUF_RELAY.FTR_TO = intFTR_TO                                        '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTPRG_TRK_BUF_RELAY.WHERE = " AND FTRK_BUF_NO <> " & FTRK_BUF_NO_J9000        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    intCheckCount = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF_COUNT()                  '件数取得
                    If 0 < intCheckCount Then
                        '(見つからなかった場合)
                        Continue For
                    End If


                    '****************************************
                    'STﾄﾗｯｷﾝｸﾞ                  ﾁｪｯｸ
                    '****************************************
                    Dim intCountSTZaiko As Integer = 0
                    Dim objTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    objTPRG_TRK_BUF_ST.FTRK_BUF_NO = intFTR_TO                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    intCountSTZaiko = objTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF_COUNT_ZAIKO() '取得
                    If 0 < intCountSTZaiko Then
                        '(何かしらの在庫が存在していた場合)

                        '出庫する数を変更
                        Select Case intCountSTZaiko
                            Case 1 : intOutSiziSameNum -= 3
                            Case 2 : intOutSiziSameNum -= 2
                            Case 3 : intOutSiziSameNum -= 1
                            Case Else : intOutSiziSameNum = 2
                        End Select
                        'intOutSiziSameNum = 2

                    End If


                    If IsNull(objTMST_TRK.XADRS_YOTEI02) Then
                        '(ﾛｰﾀﾞ以外の場合)


                        '************************************************
                        '設備状況(出庫要求)         取得
                        '1 <= STﾄﾗｯｷﾝｸﾞ <= 3 以外の場合に限り、ﾁｪｯｸを行う
                        '************************************************
                        If Not (1 <= intCountSTZaiko And intCountSTZaiko <= 3) Then
                            '(1 <= STﾄﾗｯｷﾝｸﾞ <= 3 以外の場合)

                            Dim objTSTS_EQ_CTRL_OUT_YOUKYU As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)      '入庫要求前 設備ID
                            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_OUT_YOUKYU, objTMST_TRK.XEQ_ID_OUT_YOUKYU)     '出庫要求   設備ID
                            If objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_STS = FLAG_OFF Then
                                '(出庫要求が立っていない場合)
                                Continue For
                            End If

                        End If


                    End If


                    '****************************************
                    'ﾄﾗｯｸﾛｰﾀﾞ特殊処理01
                    '****************************************
                    Select Case intFTR_TO
                        Case FTRK_BUF_NO_J1085 : intOutSiziSameNum = 100 : strFTR_TO = TO_STRING(FTRK_BUF_NO_J1085) & ", " & TO_STRING(FTRK_BUF_NO_J1086)
                        Case FTRK_BUF_NO_J1088 : intOutSiziSameNum = 100 : strFTR_TO = TO_STRING(FTRK_BUF_NO_J1088) & ", " & TO_STRING(FTRK_BUF_NO_J1089)
                        Case FTRK_BUF_NO_J1090 : intOutSiziSameNum = 100 : strFTR_TO = TO_STRING(FTRK_BUF_NO_J1090) & ", " & TO_STRING(FTRK_BUF_NO_J1091)
                        Case FTRK_BUF_NO_J1093 : intOutSiziSameNum = 100 : strFTR_TO = TO_STRING(FTRK_BUF_NO_J1093) & ", " & TO_STRING(FTRK_BUF_NO_J1094)
                        Case FTRK_BUF_NO_J1096 : intOutSiziSameNum = 100 : strFTR_TO = TO_STRING(FTRK_BUF_NO_J1096) & ", " & TO_STRING(FTRK_BUF_NO_J1097)
                        Case FTRK_BUF_NO_J1098 : intOutSiziSameNum = 100 : strFTR_TO = TO_STRING(FTRK_BUF_NO_J1098) & ", " & TO_STRING(FTRK_BUF_NO_J1099)
                        Case FTRK_BUF_NO_J1086, FTRK_BUF_NO_J1089, FTRK_BUF_NO_J1091, FTRK_BUF_NO_J1094, FTRK_BUF_NO_J1097, FTRK_BUF_NO_J1099 : Continue For
                    End Select


                    '************************************************************************************************************************
                    '************************************************************************************************************************
                    'ﾙｰﾌﾟ:搬送指示QUE
                    '************************************************************************************************************************
                    '************************************************************************************************************************
                    '****************************************
                    '搬送指示QUE                取得
                    '****************************************
                    Dim strSQL02 As String = ""       'SQL文
                    Dim objAryTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                    strSQL02 &= vbCrLf & " SELECT "
                    strSQL02 &= vbCrLf & "    * "
                    strSQL02 &= vbCrLf & " FROM "
                    strSQL02 &= vbCrLf & "    TPLN_CARRY_QUE "
                    strSQL02 &= vbCrLf & " WHERE "
                    strSQL02 &= vbCrLf & "        EXISTS("
                    strSQL02 &= vbCrLf & "               SELECT"
                    strSQL02 &= vbCrLf & "                   *"
                    strSQL02 &= vbCrLf & "               FROM"
                    strSQL02 &= vbCrLf & "                   TPRG_TRK_BUF"
                    strSQL02 &= vbCrLf & "               WHERE"
                    strSQL02 &= vbCrLf & "                       1 = 1 "
                    strSQL02 &= vbCrLf & "                   AND TPRG_TRK_BUF.FPALLET_ID = TPLN_CARRY_QUE.FPALLET_ID"
                    strSQL02 &= vbCrLf & "                   AND TPRG_TRK_BUF.FTR_TO IN ( " & strFTR_TO & " ) "
                    strSQL02 &= vbCrLf & "               )"
                    strSQL02 &= vbCrLf & "    AND TPLN_CARRY_QUE.FCARRYQUE_DIR_STS IN (" & TO_STRING(FCARRYQUE_DIR_STS_JTAIKI) & ", " & TO_STRING(FCARRYQUE_DIR_STS_SNON) & ")"   '搬送指示状況
                    strSQL02 &= vbCrLf & " ORDER BY "
                    strSQL02 &= vbCrLf & "    FCARRYQUE_DIR_STS "   '搬送指示状況
                    strSQL02 &= vbCrLf & "   ,FCARRYQUE_D "         '搬送指示日
                    strSQL02 &= vbCrLf & "   ,FCARRYQUE_ORDER "     '搬送順№
                    strSQL02 &= vbCrLf
                    objAryTPLN_CARRY_QUE.USER_SQL = strSQL02
                    intRet = objAryTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_USER()     '取得
                    If intRet <> RetCode.OK Then Continue For
                    For Each objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE In objAryTPLN_CARRY_QUE.ARYME
                        '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


                        '****************************************
                        '搬送指示状況               ﾁｪｯｸ
                        'まだ未指示のﾄﾗｯｷﾝｸﾞがあった場合は、処理しない
                        '****************************************
                        If objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON Then Exit For


                        '****************************************
                        'ﾄﾗｯｸﾛｰﾀﾞ特殊処理02
                        '****************************************
                        If objTPLN_CARRY_QUE.FPRIORITY = FPRIORITY_JLOW_MORE01 Then
                            '(ﾄﾗｯｸﾛｰﾀﾞ2回目の場合)
                            intOutSiziSameNum = 2
                        End If


                        '****************************************
                        '在庫引当情報           取得
                        '****************************************
                        Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
                        objTSTS_HIKIATE.FPALLET_ID = objTPLN_CARRY_QUE.FPALLET_ID   'ﾊﾟﾚｯﾄID
                        objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET()          '取得
                        If intRet = RetCode.OK Then
                            '(見つかった場合)


                            '****************************************
                            '出荷指示詳細           取得
                            '****************************************
                            Dim objXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
                            objXPLN_OUT_DTL.FPLAN_KEY = objTSTS_HIKIATE.FPLAN_KEY
                            objXPLN_OUT_DTL.GET_XPLN_OUT_DTL()


                            '****************************************
                            '車輌内出荷品目順(記憶用)       ﾁｪｯｸ & 更新
                            '****************************************
                            If IsNotNull(intXOUT_ORDER_Memory) Then
                                '(ﾙｰﾌﾟ2回目以降の場合)

                                If Not (TO_STRING(intFTR_TO) <> strFTR_TO And objTPLN_CARRY_QUE.FPRIORITY = FPRIORITY_JLOW_MORE01) Then
                                    '(ﾄﾗｯｸﾛｰﾀﾞ2回目以外の場合)

                                    '=======================================
                                    '前回の計画と違っていた場合は引当終了
                                    '=======================================
                                    If intXOUT_ORDER_Memory <> objXPLN_OUT_DTL.XOUT_ORDER Then Exit For

                                Else
                                    '(ﾄﾗｯｸﾛｰﾀﾞ2回目の場合)

                                    '==============================================================================
                                    '既に2件以上出庫指示を送信していた場合は、引当終了
                                    '==============================================================================
                                    If 2 <= (intSendPairCount + intSendSingleCount) Then Exit For

                                    '==============================================================================
                                    '前回の計画と違っていても大丈夫だが、今の計画で強制的に終了させる
                                    '==============================================================================
                                    intOutSiziSameNum = 0

                                End If


                            Else
                                '(ﾙｰﾌﾟ1回目の場合)
                                intXOUT_ORDER_Memory = objXPLN_OUT_DTL.XOUT_ORDER       '車輌内出荷品目順
                            End If


                        End If


                        '****************************************
                        '搬送指示QUE            取得
                        '****************************************
                        objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON        '搬送指示状況
                        objTPLN_CARRY_QUE.FUPDATE_DT = Now                                  '更新日時
                        objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                           '更新


                        '****************************************
                        '出庫指示電文送信件数ｶｳﾝﾄ
                        '****************************************
                        If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                            '(ﾍﾟｱ搬送の場合)
                            intSendPairCount += 1
                        Else
                            '(ｼﾝｸﾞﾙ搬送の場合)
                            intSendSingleCount += 1
                        End If


                        '************************
                        '正常完了
                        '************************
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                         FLOG_DATA_TRN_SEND_NORMAL _
                                         & "[出庫ST:" & objTMST_TRK.FBUF_NAME & "]" _
                                         & "[搬送指示日:" & Format(objTPLN_CARRY_QUE.FCARRYQUE_D, DATE_FORMAT_03) & "]" _
                                         & "[搬送順№:" & TO_STRING(objTPLN_CARRY_QUE.FCARRYQUE_ORDER) & "]" _
                                         & "[ﾊﾟﾚｯﾄID:" & objTPLN_CARRY_QUE.FPALLET_ID & "]" _
                                         )


                        '****************************************
                        '出庫CV当たりの同時出庫指示数   ﾁｪｯｸ
                        '****************************************
                        If intOutSiziSameNum <= (intSendPairCount + intSendSingleCount) And (intSendPairCount Mod 2) = 0 Then
                            '(指示数ｵｰﾊﾞｰの場合)
                            Exit For
                        End If


                    Next


                    If 0 < (intSendPairCount + intSendSingleCount) Then
                        '(出庫指示する場合)


                        '************************************************
                        'ﾁｪｯｸ
                        '************************************************
                        If (intSendPairCount Mod 2) <> 0 Then Throw New Exception("ﾍﾟｱ搬送数が奇数なので、ｴﾗｰとします。")


                        '************************************************
                        '安川         到着予定数
                        '************************************************
                        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                        'objSVR_190001.FEQ_ID = strFEQ_ID                                '設備ID
                        objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         'ｺﾏﾝﾄﾞID
                        objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
                        If IsNull(objTMST_TRK.XADRS_YOTEI02) Then
                            '(予定数ｱﾄﾞﾚｽ02が定義されていない場合)
                            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK.FTRK_BUF_NO _
                                                                  , (intSendSingleCount + intSendPairCount) _
                                                                  )
                        Else
                            '(予定数ｱﾄﾞﾚｽ02が定義されている場合)

                            'ﾄﾗｯｸﾛｰﾀﾞの場合、出荷引当時に書き込んでいるので不要
                            'Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK.FTRK_BUF_NO _
                            '                                      , intSendSingleCount _
                            '                                      , (intSendPairCount / 2) _
                            '                                      )

                        End If


                        '************************
                        '次処理起動
                        '************************
                        Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                           '起動


                    End If


                Next


            End If


            '************************
            '処理時間取得
            '************************
            Dim objDiff As TimeSpan = Now - dtmNow01
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                 FLOG_DATA_TRN_SEND_NORMAL _
                 & "[処理時間:" & TO_STRING(TO_DECIMAL(objDiff.TotalMilliseconds / 1000)) & "]" _
                 )


            Return RetCode.OK
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        End Try
    End Function
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
