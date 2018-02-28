'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】入庫指示処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_010101
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ｸﾗｽ変数定義                                                                          "
    Private mobjTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE            '搬送指示QUE
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
    ''' =======================================
    ''' <summary>搬送指示QUE</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property TPLN_CARRY_QUE() As TBL_TPLN_CARRY_QUE
        Get
            Return mobjTPLN_CARRY_QUE
        End Get
        Set(ByVal Value As TBL_TPLN_CARRY_QUE)
            mobjTPLN_CARRY_QUE = Value
        End Set
    End Property
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  ﾒｲﾝ処理(関数)                                                                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理(関数)
    ''' </summary>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecCmdFunction() As RetCode
        Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try

            ''************************
            ''初期処理
            ''************************
            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)

            '************************
            '搬送指示QUE
            '************************
            If IsNull(mobjTPLN_CARRY_QUE) = True Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPLN_CARRY_QUE
                Throw New UserException(strMsg)
            End If


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/25 特殊処理


            '**************************************
            '特殊処理02(手前棚と奥棚の入庫予約入替処理)
            '**************************************
            Call Special02()


            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            'ｽﾃｰｼｮﾝﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_ST.FPALLET_ID = mobjTPLN_CARRY_QUE.FPALLET_ID           'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF(True)                      '特定


            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)                 '搬送ﾙｰﾄﾏｽﾀ
            Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)                 'ｸﾚｰﾝﾏｽﾀｸﾗｽ

            If TO_INTEGER(objTPRG_TRK_BUF_ST.FRSV_BUF_TO) <> TO_INTEGER(DEFAULT_INTEGER) And _
               TO_INTEGER(objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO) <> TO_INTEGER(DEFAULT_INTEGER) Then
                '************************************************
                '搬送先が引当されている場合
                '************************************************
                '************************
                '倉庫ﾊﾞｯﾌｧの特定
                '************************
                objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_ST.FRSV_BUF_TO         'ﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO    '配列№
                intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(False)                     '特定
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO) & "  ,配列№:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY) & "]"
                    Throw New UserException(strMsg)
                End If

                '************************
                'ｸﾚｰﾝﾏｽﾀの特定
                '************************
                objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO              'ﾊﾞｯﾌｧ№
                objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU               '列
                intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                                 '特定
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                    Throw New UserException(strMsg)
                End If

                '************************
                '搬送ﾙｰﾄﾏｽﾀの特定
                '************************
                objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO                  '元ﾊﾞｯﾌｧ№      
                objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_ST.FTR_TO                       '先ﾊﾞｯﾌｧ№
                objTMST_ROUTE.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                           '元ｸﾚｰﾝ設備ID
                objTMST_ROUTE.FEQ_ID_CRANE_TO = objTMST_CRANE.FEQ_ID                    '先ｸﾚｰﾝ設備ID
                intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                             '特定

            Else
                '************************************************
                '搬送先が引当されていない場合
                '************************************************
                '************************
                '搬送ﾙｰﾄﾏｽﾀの特定
                '************************
                objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO                  '元ﾊﾞｯﾌｧ№      
                objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_ST.FTR_TO                       '先ﾊﾞｯﾌｧ№
                objTMST_ROUTE.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                           '元ｸﾚｰﾝ設備ID
                objTMST_ROUTE.FEQ_ID_CRANE_TO = FEQ_ID_SKOTEI                           '先ｸﾚｰﾝ設備ID
                intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                             '特定


                '************************
                '搬送先ｸﾚｰﾝID取得
                '************************
                Dim strEQ_ID() As String                                            'ｸﾚｰﾝID
                intRet = objTMST_ROUTE.GET_TMST_ROUTE_CRANES()                      'ｸﾚｰﾝID取得
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_TMST_ROUTE & "[元ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_ROUTE.FBUF_FM) & "][元ｸﾚｰﾝ設備ID:" & objTMST_ROUTE.FEQ_ID_CRANE_FM & "][先ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_ROUTE.FBUF_TO) & "][先ｸﾚｰﾝ設備ID:******]"
                    Throw New UserException(strMsg)
                End If
                ReDim Preserve strEQ_ID(UBound(objTMST_ROUTE.ARYME))
                For ii As Integer = LBound(objTMST_ROUTE.ARYME) To UBound(objTMST_ROUTE.ARYME)
                    strEQ_ID(ii) = objTMST_ROUTE.ARYME(ii).FEQ_ID_CRANE_TO
                Next
                objTMST_ROUTE.ARYME_CLEAR()

                '************************************************
                '移動先の引当が必要な場合
                '************************************************

                '************************
                '移動先ﾊﾞｯﾌｧの空棚引当
                '************************
                Dim objSVR_100201 As New SVR_100201(Owner, ObjDb, ObjDbLog)         '空棚引当ｸﾗｽ
                objSVR_100201.FTRK_BUF_NO = objTPRG_TRK_BUF_ST.FTR_TO               'ﾊﾞｯﾌｧ№
                objSVR_100201.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID            'ﾊﾟﾚｯﾄID
                objSVR_100201.FEQ_ID_CRANE = strEQ_ID                               'ｸﾚｰﾝID
                intRet = objSVR_100201.FIND_TANA_AKI                                '特定
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    Select Case objSVR_100201.FTRK_BUF_NO
                        Case FTRK_BUF_NO_J9000 : Call AddToMsgLog(Now, FMSG_ID_S0102)
                        Case Else : Call AddToMsgLog(Now, FMSG_ID_S0102)
                    End Select
                    Return RetCode.NotEnough
                End If

                objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objSVR_100201.FTRK_BUF_NO          'ﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objSVR_100201.FTRK_BUF_ARRAY    '配列№
                intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(False)                 '特定
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO) & "  ,配列№:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY) & "]"
                    Throw New UserException(strMsg)
                End If

                objTPRG_TRK_BUF_ST.FRSV_BUF_TO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO           'TO引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY      'TO引当配列№
                objTPRG_TRK_BUF_ST.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_ST.FDISP_ADDRESS      'FM表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_ST.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS    'TO表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_ST.FBUF_IN_DT = Now                                         'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_ST.UPDATE_TPRG_TRK_BUF()                                    '更新


                '************************
                '倉庫の更新
                '************************
                objTPRG_TRK_BUF_ASRS.FRSV_PALLET = objTPRG_TRK_BUF_ST.FPALLET_ID            '仮引当ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                     '引当状態 = 搬入予約
                objTPRG_TRK_BUF_ASRS.FRSV_BUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO           'FM引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY      'FM引当配列№
                objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                                  '更新


                '************************
                'ｸﾚｰﾝﾏｽﾀの特定
                '************************
                objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO                'ﾊﾞｯﾌｧ№
                objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU                 '列
                intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                                   '特定
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                    Throw New UserException(strMsg)
                End If

                '************************
                '搬送ﾙｰﾄﾏｽﾀの特定
                '************************
                objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO                  '元ﾊﾞｯﾌｧ№      
                objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_ST.FTR_TO                       '先ﾊﾞｯﾌｧ№
                objTMST_ROUTE.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                           '元ｸﾚｰﾝ設備ID
                objTMST_ROUTE.FEQ_ID_CRANE_TO = objTMST_CRANE.FEQ_ID                    '先ｸﾚｰﾝ設備ID
                intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                             '特定

            End If


            '************************
            '在庫引当情報の特定
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '在庫引当情報ｸﾗｽ
            objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID          'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                    '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[ﾊﾟﾚｯﾄID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            'ｸﾚｰﾝ毎の指示件数ﾁｪｯｸ
            '************************
            If TO_INTEGER(objTMST_CRANE.FINOUT_MAX) > 0 Then
                If TO_INTEGER(objTMST_CRANE.FINOUT_MAX) <= mobjTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_SEND_COUNT_BY_EQ_ID() Then
                    '========================
                    '指示送信待ち理由の登録
                    '========================
                    objTSTS_HIKIATE.FWAIT_REASON = "入出庫規制数ｵｰﾊﾞｰ  [ﾊﾞｯﾌｧ№" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "][設備ID" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                End If
            End If
            If TO_INTEGER(objTMST_CRANE.FIN_MAX) > 0 Then
                If TO_INTEGER(objTMST_CRANE.FIN_MAX) <= mobjTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_SEND_COUNT_IN() Then
                    '========================
                    '指示送信待ち理由の登録
                    '========================
                    objTSTS_HIKIATE.FWAIT_REASON = "入庫規制数ｵｰﾊﾞｰ  [ﾊﾞｯﾌｧ№" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "][設備ID" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                End If
            End If


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/25 特殊処理


            '**************************************
            '特殊処理03(入庫指示の件数は一件のみ)
            '**************************************
            intRet = Special03(Nothing _
                             , objTPRG_TRK_BUF_ST _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTSTS_HIKIATE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '**************************************
            '特殊処理04(出庫指示ﾁｪｯｸ)
            '**************************************
            intRet = Special04(Nothing _
                             , objTPRG_TRK_BUF_ST _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTSTS_HIKIATE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '搬送ﾙｰﾄﾏｽﾀの特定
            '************************
            objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO              '元ﾊﾞｯﾌｧ№      
            objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO            '先ﾊﾞｯﾌｧ№
            objTMST_ROUTE.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                       '元ｸﾚｰﾝ設備ID
            objTMST_ROUTE.FEQ_ID_CRANE_TO = objTMST_CRANE.FEQ_ID                '先ｸﾚｰﾝ設備ID
            intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                         '特定


            '************************
            'ﾙｰﾄ設備ﾁｪｯｸ(From - To)
            '************************
            Dim objSVR_100203 As New SVR_100203(Owner, ObjDb, ObjDbLog)
            objSVR_100203.FBUF_FM = objTMST_ROUTE.FBUF_FM                   '元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objSVR_100203.FBUF_TO = objTMST_ROUTE.FBUF_TO                   '先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objSVR_100203.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM   '元ｸﾚｰﾝ設備ID
            objSVR_100203.FEQ_ID_CRANE_TO = objTMST_ROUTE.FEQ_ID_CRANE_TO   '先ｸﾚｰﾝ設備ID
            intRet = objSVR_100203.CHECK_ROUTE(objTSTS_HIKIATE)
            If intRet = RetCode.NG Then
                '(ｴﾗｰの場合)
                Return RetCode.NotEnough
            End If

            '************************
            'ﾙｰﾄ設備ﾁｪｯｸ(From - Next)
            '************************
            If objTMST_ROUTE.FBUF_TO <> objTMST_ROUTE.FBUF_NEXT Then
                objSVR_100203 = New SVR_100203(Owner, ObjDb, ObjDbLog)
                objSVR_100203.FBUF_FM = objTMST_ROUTE.FBUF_FM                   '元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objSVR_100203.FBUF_TO = objTMST_ROUTE.FBUF_NEXT                 '先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objSVR_100203.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM   '元ｸﾚｰﾝ設備ID
                objSVR_100203.FEQ_ID_CRANE_TO = FEQ_ID_SKOTEI                   '先ｸﾚｰﾝ設備ID
                intRet = objSVR_100203.CHECK_ROUTE(objTSTS_HIKIATE)
                If intRet = RetCode.NG Then
                    '(ｴﾗｰの場合)
                    Return RetCode.NotEnough
                End If
            End If
            
            '************************
            '入庫中ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = objTMST_ROUTE.FBUF_RELAY                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            objTPRG_TRK_BUF_RELAY.FRSV_PALLET = objTPRG_TRK_BUF_ST.FPALLET_ID               '仮引当ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF_RSV_PALLET                      '特定
            If intRet = RetCode.OK Then
                '(先に引当されている場合)
            Else
                '(新たに引当する場合)
                intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF_AKI_HIRA                    '特定
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    '========================
                    '指示送信待ち理由の登録
                    '========================
                    objTSTS_HIKIATE.FWAIT_REASON = "空き待ち  [ﾊﾞｯﾌｧ№" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "]"
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                End If
            End If


            '************************
            '在庫移動
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '在庫移動ｸﾗｽ
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_ST       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ｽﾃｰｼｮﾝﾊﾞｯﾌｧ)
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_RELAY    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(入庫中ﾊﾞｯﾌｧ)
            objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID    'ﾊﾟﾚｯﾄID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SIN_START             'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '作業種別
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_OFF                   '搬送元ｸﾘｱﾌﾗｸﾞ
            objSVR_100103.STOCK_TRNS()                                  '移動


            '************************
            'ｽﾃｰｼｮﾝﾏｽﾀの特定
            '************************
            Dim blnMENTE_CANCEL_FLAG As Boolean = False
            Dim objTMST_ST As New TBL_TMST_ST(Owner, ObjDb, ObjDbLog)   'ｽﾃｰｼｮﾝﾏｽﾀｸﾗｽ
            objTMST_ST.FTRK_BUF_NO = objTPRG_TRK_BUF_ST.FTRK_BUF_NO     'ﾊﾞｯﾌｧ№(ｽﾃｰｼｮﾝ№)
            intRet = objTMST_ST.GET_TMST_ST(False)                      '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                blnMENTE_CANCEL_FLAG = False
            Else
                If TO_INTEGER(objTMST_ST.FMENTE_CANCEL_FLAG) <> FLAG_OFF Then
                    blnMENTE_CANCEL_FLAG = True
                End If
            End If


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/03/22 特殊処理


            '**************************************
            '特殊処理01(ﾍﾟｱ搬送待ちﾁｪｯｸ)
            '**************************************
            Call Special01(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_ST _
                         , objTPRG_TRK_BUF_ASRS _
                         , objTSTS_HIKIATE _
                         )


            '↑↑↑↑↑↑************************************************************************************************************


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2012/04/24 入庫指示を送信


            '************************************************
            '入庫指示
            '************************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SIN                     'ｺﾏﾝﾄﾞID
            objSVR_190001.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID     'ﾊﾟﾚｯﾄID
            objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
            Call objSVR_190001.SendYasukawa_IDIn(objTPRG_TRK_BUF_RELAY _
                                               , objTPRG_TRK_BUF_ST _
                                               , objTPRG_TRK_BUF_ASRS _
                                               , mobjTPLN_CARRY_QUE _
                                               , objTMST_ROUTE _
                                               )
            

            '↑↑↑↑↑↑************************************************************************************************************


            '****************************************
            'ｽﾃｰｼｮﾝ/入庫中/倉庫ﾊﾞｯﾌｧの更新
            '****************************************
            If blnMENTE_CANCEL_FLAG = False Then
                '(ｷｬﾝｾﾙ可否ﾌﾗｸﾞがOFFの場合)

                '========================
                '入庫中ﾊﾞｯﾌｧ
                '========================
                objTPRG_TRK_BUF_RELAY.FRSV_PALLET = objTPRG_TRK_BUF_ST.FRSV_PALLET              '仮引当ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_RELAY.FRES_KIND = FRES_KIND_SZAIKO                               '引当状態
                objTPRG_TRK_BUF_RELAY.FTR_FM = objTPRG_TRK_BUF_ST.FTR_FM                        '搬送FMﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_RELAY.FTR_TO = objTPRG_TRK_BUF_ST.FTR_TO                        '搬送TOﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_RELAY.FTR_IDOU = objTPRG_TRK_BUF_ST.FTR_IDOU                    '搬送TO移動ﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_RELAY.FTRNS_FM = objTPRG_TRK_BUF_ST.FTRNS_FM                    '搬送指令用FM
                objTPRG_TRK_BUF_RELAY.FTRNS_TO = objTPRG_TRK_BUF_ST.FTRNS_TO                    '搬送指令用TO
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM = DEFAULT_INTEGER                             'FM引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM = DEFAULT_INTEGER                           'FM引当配列№
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO = objTPRG_TRK_BUF_ST.FRSV_BUF_TO              'TO引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO          'TO引当配列№
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_ST.FDISP_ADDRESS_FM    'FM表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_RELAY.GET_ADDRESS_TO   'TO表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_RELAY.FBUF_IN_DT = Now                                          'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_RELAY.UPDATE_TPRG_TRK_BUF()                                     '更新

                '========================
                'ｽﾃｰｼｮﾝﾊﾞｯﾌｧ
                '========================
                objTPRG_TRK_BUF_ST.CLEAR_TPRG_TRK_BUF()             '解放


            Else
                '(ｷｬﾝｾﾙ可否ﾌﾗｸﾞがONの場合)

                '========================
                'ｽﾃｰｼｮﾝﾊﾞｯﾌｧ
                '========================
                objTPRG_TRK_BUF_ST.FRSV_PALLET = objTPRG_TRK_BUF_RELAY.FPALLET_ID               '仮引当ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_ST.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                           '引当状態 = 搬入予約
                objTPRG_TRK_BUF_ST.FBUF_IN_DT = Now                                             'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_ST.UPDATE_TPRG_TRK_BUF()                                        '更新

                '========================
                '入庫中ﾊﾞｯﾌｧ
                '========================
                objTPRG_TRK_BUF_RELAY.FRSV_PALLET = objTPRG_TRK_BUF_RELAY.FPALLET_ID            '仮引当ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_RELAY.FRES_KIND = FRES_KIND_SZAIKO                               '引当状態
                objTPRG_TRK_BUF_RELAY.FTR_FM = objTPRG_TRK_BUF_ST.FTR_FM                        '搬送FMﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_RELAY.FTR_TO = objTPRG_TRK_BUF_ST.FTR_TO                        '搬送TOﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_RELAY.FTR_IDOU = objTPRG_TRK_BUF_ST.FTR_IDOU                    '搬送TO移動ﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_RELAY.FTRNS_FM = objTPRG_TRK_BUF_ST.FTRNS_FM                    '搬送指令用FM
                objTPRG_TRK_BUF_RELAY.FTRNS_TO = objTPRG_TRK_BUF_ST.FTRNS_TO                    '搬送指令用TO
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO              'FM引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY         'FM引当配列№
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO = objTPRG_TRK_BUF_ST.FRSV_BUF_TO              'TO引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO          'TO引当配列№
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_ST.FDISP_ADDRESS_FM    'FM表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_RELAY.GET_ADDRESS_TO   'TO表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_RELAY.FBUF_IN_DT = Now                                          'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_RELAY.UPDATE_TPRG_TRK_BUF()                                     '更新

            End If


            '========================
            '指示送信待ち理由のｸﾘｱ
            '========================
            objTSTS_HIKIATE.FWAIT_REASON = DEFAULT_STRING
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()


            '************************
            '正常終了
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & _
                                "  [ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & _
                                "  ,搬送元:" & objTPRG_TRK_BUF_ST.FDISP_ADDRESS & _
                                "  ,搬送先:" & objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS & _
                                "]")

            Return RetCode.OK
        Catch ex As ContinueForException
            Throw New ContinueForException()
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
#Region "  特殊処理01(ﾍﾟｱ搬送待ちﾁｪｯｸ)                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理01(ﾍﾟｱ搬送待ちﾁｪｯｸ)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">搬送中ﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FMﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TOﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTSTS_HIKIATE">在庫引当情報</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special01(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        If mobjTPLN_CARRY_QUE.XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA And IsNotNull(mobjTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
            '(親かつﾍﾟｱ搬送の場合)


            '*************************************************
            'FMﾄﾗｯｷﾝｸﾞ(ﾍﾟｱﾄﾗｯｷﾝｸﾞ)       取得
            '*************************************************
            Dim objTPRG_TRK_BUF_Aite_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF_Aite_FM.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_Aite_FM.FRSV_PALLET = mobjTPLN_CARRY_QUE.XPALLET_ID_AITE        '仮引当ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_Aite_FM.GET_TPRG_TRK_BUF_RSV_PALLET()                  '取得
            If intRet <> RetCode.OK Then
                '(ﾍﾟｱﾄﾗｯｷﾝｸﾞがまだSTに到着していない場合)
                intReturn = RetCode.NG
            End If


        End If


        Return intReturn
    End Function
#End Region
#Region "  特殊処理02(手前棚と奥棚の入庫予約入替処理)                                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理02(手前棚と奥棚の入庫予約入替処理)
    ''' 奥棚の在庫を入庫する前に、手前棚の在庫が到着した場合、手前棚の行先と奥棚の行先を変える。
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special02() As RetCode
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '************************
        'ｽﾃｰｼｮﾝﾊﾞｯﾌｧの特定
        '************************
        Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
        objTPRG_TRK_BUF_FM.FPALLET_ID = mobjTPLN_CARRY_QUE.FPALLET_ID           'ﾊﾟﾚｯﾄID
        objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF()                                   '特定


        '***********************************************
        'ﾁｪｯｸ
        '***********************************************
        If TO_INTEGER(objTPRG_TRK_BUF_FM.FRSV_BUF_TO) <> TO_INTEGER(DEFAULT_INTEGER) And _
           TO_INTEGER(objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO) <> TO_INTEGER(DEFAULT_INTEGER) Then
            '(搬送先が引当されている場合)


            '***********************************************
            'ﾁｪｯｸ
            '***********************************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FRSV_BUF_TO           'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO      '配列№
            objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()                                     '特定
            If objTPRG_TRK_BUF_ASRS.FRAC_EDA = FLAG_ON Then Return intReturn '奥棚の場合は何もしない


            '***********************************************
            '関連するﾌﾞﾛｯｸ棚の取得
            '***********************************************
            Dim objTrkRelation() As TBL_TPRG_TRK_BUF = Nothing                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            Dim objStockFind As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)          '在庫情報
            Dim objStockRelation() As TBL_TRST_STOCK = Nothing                      '在庫情報
            Call GetTPRG_TRK_BUF_Relation(objTPRG_TRK_BUF_ASRS, objTrkRelation, objStockFind, objStockRelation)


            '***********************************************
            '奥棚に予約がかかっているかﾁｪｯｸ
            '***********************************************
            If Not ( _
                      objTrkRelation(RelationArray.OKU_EVN).FRES_KIND = FRES_KIND_SRSV_TRNS_IN _
                   Or objTrkRelation(RelationArray.OKU_ODD).FRES_KIND = FRES_KIND_SRSV_TRNS_IN _
                   ) _
                   Then
                '(奥棚に入庫予約がかかっていない場合は、何もしない)
                Return intReturn
            End If


            '***********************************************
            '奥棚の予約が入庫指示済かﾁｪｯｸ
            '***********************************************
            If IsNotNull(objTrkRelation(RelationArray.OKU_EVN).FRSV_PALLET) Then
                Dim objTPRG_TRK_BUF_RELAY_Check As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_RELAY_Check.FPALLET_ID = objTrkRelation(RelationArray.OKU_EVN).FRSV_PALLET      'ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_RELAY_Check.GET_TPRG_TRK_BUF()                                                  '取得
                If objTPRG_TRK_BUF_RELAY_Check.FTRK_BUF_NO = FTRK_BUF_NO_J3101 _
                   Or objTPRG_TRK_BUF_RELAY_Check.FTRK_BUF_NO = FTRK_BUF_NO_J3102 _
                   Then
                    '(指示済みの場合)
                    Return intReturn
                End If

            End If


            '**********************************************************************************************
            '**********************************************************************************************
            '手前棚と奥棚の入庫予約を入替
            '**********************************************************************************************
            '**********************************************************************************************
            '***********************************************
            '自動倉庫ﾄﾗｯｷﾝｸﾞの仮引当ﾊﾟﾚｯﾄIDを入替
            '***********************************************
            Dim strTemp01 As String
            Dim strTemp02 As String
            '======================================
            '仮引当ﾊﾟﾚｯﾄID
            '======================================
            strTemp01 = objTrkRelation(RelationArray.OKU_EVN).FRSV_PALLET                                           '(一時保管)←(奥)
            strTemp02 = objTrkRelation(RelationArray.OKU_ODD).FRSV_PALLET                                           '(一時保管)←(奥)
            objTrkRelation(RelationArray.OKU_EVN).FRSV_PALLET = objTrkRelation(RelationArray.MAE_EVN).FRSV_PALLET   '(奥)←(手前)
            objTrkRelation(RelationArray.OKU_ODD).FRSV_PALLET = objTrkRelation(RelationArray.MAE_ODD).FRSV_PALLET   '(奥)←(手前)
            objTrkRelation(RelationArray.MAE_EVN).FRSV_PALLET = strTemp01                                           '(手前)←(一時保管)
            objTrkRelation(RelationArray.MAE_ODD).FRSV_PALLET = strTemp02                                           '(手前)←(一時保管)

            '======================================
            '引当状態
            '======================================
            strTemp01 = objTrkRelation(RelationArray.OKU_EVN).FRES_KIND                                             '(一時保管)←(奥)
            strTemp02 = objTrkRelation(RelationArray.OKU_ODD).FRES_KIND                                             '(一時保管)←(奥)
            objTrkRelation(RelationArray.OKU_EVN).FRES_KIND = objTrkRelation(RelationArray.MAE_EVN).FRES_KIND       '(奥)←(手前)
            objTrkRelation(RelationArray.OKU_ODD).FRES_KIND = objTrkRelation(RelationArray.MAE_ODD).FRES_KIND       '(奥)←(手前)
            objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = strTemp01                                             '(手前)←(一時保管)
            objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = strTemp02                                             '(手前)←(一時保管)

            '======================================
            '更新
            '======================================
            objTrkRelation(RelationArray.OKU_EVN).UPDATE_TPRG_TRK_BUF() '更新
            objTrkRelation(RelationArray.OKU_ODD).UPDATE_TPRG_TRK_BUF() '更新
            objTrkRelation(RelationArray.MAE_EVN).UPDATE_TPRG_TRK_BUF() '更新
            objTrkRelation(RelationArray.MAE_ODD).UPDATE_TPRG_TRK_BUF() '更新

            '============================================================================
            '在庫情報           入庫ﾄﾗｯｷﾝｸﾞ情報の更新
            '============================================================================
            Call UpdateTRST_STOCK_InInfor(objTrkRelation(RelationArray.OKU_EVN), objStockRelation(RelationArray.MAE_EVN))
            Call UpdateTRST_STOCK_InInfor(objTrkRelation(RelationArray.OKU_ODD), objStockRelation(RelationArray.MAE_ODD))
            Call UpdateTRST_STOCK_InInfor(objTrkRelation(RelationArray.MAE_EVN), objStockRelation(RelationArray.OKU_EVN))
            Call UpdateTRST_STOCK_InInfor(objTrkRelation(RelationArray.MAE_ODD), objStockRelation(RelationArray.OKU_ODD))

            '======================================
            'ﾛｸﾞ出力
            '======================================
            'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                   "手前棚入庫予定の在庫が、奥棚入庫予定の在庫よりも先に到着した為、手前棚と奥棚の予約を入れ替える。" _
                 & "[対象棚1:" & objTrkRelation(RelationArray.OKU_EVN).FDISP_ADDRESS & "]" _
                 & "[対象棚2:" & objTrkRelation(RelationArray.OKU_ODD).FDISP_ADDRESS & "]" _
                 & "[対象棚3:" & objTrkRelation(RelationArray.MAE_EVN).FDISP_ADDRESS & "]" _
                 & "[対象棚4:" & objTrkRelation(RelationArray.MAE_ODD).FDISP_ADDRESS & "]" _
                 )
            'ﾒｯｾｰｼﾞﾛｸﾞ出力
            Call AddToMsgLog(Now, FMSG_ID_J4001 _
                           , "手前棚入庫予定の在庫が、奥棚入庫予定の在庫よりも先に到着した為、手前棚と奥棚の予約を入れ替えました。" _
                           , "[対象棚1:" & objTrkRelation(RelationArray.OKU_EVN).FDISP_ADDRESS & "]" _
                           & "[対象棚2:" & objTrkRelation(RelationArray.OKU_ODD).FDISP_ADDRESS & "]" _
                           & "[対象棚3:" & objTrkRelation(RelationArray.MAE_EVN).FDISP_ADDRESS & "]" _
                           & "[対象棚4:" & objTrkRelation(RelationArray.MAE_ODD).FDISP_ADDRESS & "]" _
                           )


            '***********************************************
            '元ﾄﾗｯｷﾝｸﾞを更新
            '***********************************************
            For ii As Integer = 0 To UBound(objTrkRelation)
                '(ﾙｰﾌﾟ:関係するﾄﾗｯｷﾝｸﾞ数)
                If IsNull(objTrkRelation(ii).FRSV_PALLET) Then Continue For


                '***********************************************
                'STﾄﾗｯｷﾝｸﾞ取得
                '***********************************************
                Dim objTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_ST.FPALLET_ID = objTrkRelation(ii).FRSV_PALLET          'ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF()                                   '取得


                '***********************************************
                'STﾄﾗｯｷﾝｸﾞ更新
                '***********************************************
                Select Case objTPRG_TRK_BUF_ST.FTRK_BUF_NO
                    Case FTRK_BUF_NO_J1010 _
                       , FTRK_BUF_NO_J1013 _
                       , FTRK_BUF_NO_J1017 _
                       , FTRK_BUF_NO_J1021 _
                       , FTRK_BUF_NO_J1025 _
                       , FTRK_BUF_NO_J1029 _
                       , FTRK_BUF_NO_J1033 _
                       , FTRK_BUF_NO_J1037 _
                       , FTRK_BUF_NO_J1041 _
                       , FTRK_BUF_NO_J1045 _
                       , FTRK_BUF_NO_J1049 _
                       , FTRK_BUF_NO_J1053 _
                       , FTRK_BUF_NO_J1057 _
                       , FTRK_BUF_NO_J1061 _
                       , FTRK_BUF_NO_J2079 _
                       , FTRK_BUF_NO_J2081 _
                       , FTRK_BUF_NO_J2084 _
                       , FTRK_BUF_NO_J2087 _
                       , FTRK_BUF_NO_J2090 _
                       , FTRK_BUF_NO_J2093 _
                       , FTRK_BUF_NO_J2096 _
                       , FTRK_BUF_NO_J2099 _
                       , FTRK_BUF_NO_J2102 _
                       , FTRK_BUF_NO_J2105 _
                       , FTRK_BUF_NO_J2108 _
                       , FTRK_BUF_NO_J2111 _
                       , FTRK_BUF_NO_J2114 _
                       , FTRK_BUF_NO_J2117
                        '(入庫ｺﾝﾍﾞﾔにﾄﾗｯｷﾝｸﾞが存在している場合)
                        objTPRG_TRK_BUF_ST.FRSV_BUF_TO = objTrkRelation(ii).FTRK_BUF_NO                 'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO = objTrkRelation(ii).FTRK_BUF_ARRAY            'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
                        objTPRG_TRK_BUF_ST.FDISP_ADDRESS_TO = objTrkRelation(ii).FDISP_ADDRESS          'TO表記用ｱﾄﾞﾚｽ
                        objTPRG_TRK_BUF_ST.UPDATE_TPRG_TRK_BUF()                                        '更新
                End Select


            Next


        Else
            '(搬送先が引当されていない場合)
            Return intReturn
        End If


        Return intReturn
    End Function
#End Region
#Region "  特殊処理03(入庫指示の件数は一件のみ)                                                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理03(入庫指示の件数は一件のみ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special03(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '***********************************************
        '入庫指示済ﾄﾗｯｷﾝｸﾞ          ﾁｪｯｸ
        '***********************************************
        Dim objAryTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
        objAryTPLN_CARRY_QUE.FEQ_ID = mobjTPLN_CARRY_QUE.FEQ_ID            '設備ID
        objAryTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND    '搬送指示状況
        objAryTPLN_CARRY_QUE.FCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SIN         '指示区分
        intRet = objAryTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_ANY()             '取得
        If intRet <> RetCode.OK Then
            '(入庫指示がない場合)
            Return RetCode.OK
        End If
        If 2 <= objAryTPLN_CARRY_QUE.ARYME.Length Then
            '(2件以上の入庫指示がある場合)

            objTSTS_HIKIATE.FWAIT_REASON = "ｸﾚｰﾝが入庫中[" & TO_STRING(objAryTPLN_CARRY_QUE.ARYME.Length) & "件]の為、入庫完了待ち。"
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

            Return RetCode.NotEnough
        End If


        '***********************************************
        '1件の入庫ﾄﾗｯｷﾝｸﾞが相方かどうかのﾁｪｯｸ
        '入庫ﾄﾗｯｷﾝｸﾞが相方だった場合はOKとする
        '***********************************************
        If TO_STRING(objAryTPLN_CARRY_QUE.ARYME(0).XPALLET_ID_AITE) = mobjTPLN_CARRY_QUE.FPALLET_ID Then
            '(相方が自分だった場合)
            Return RetCode.OK
        Else
            '(相方が自分じゃない場合)

            objTSTS_HIKIATE.FWAIT_REASON = "ｸﾚｰﾝが入庫中(1件)の為、入庫完了待ち。"
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

            Return RetCode.NotEnough
        End If


        Return intReturn
    End Function
#End Region
#Region "  特殊処理04(出庫指示ﾁｪｯｸ)                                                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理04(出庫指示ﾁｪｯｸ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special04(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '***********************************************
        '出庫指示済ﾄﾗｯｷﾝｸﾞ          ﾁｪｯｸ
        '***********************************************
        Dim objAryTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
        objAryTPLN_CARRY_QUE.FEQ_ID = mobjTPLN_CARRY_QUE.FEQ_ID            '設備ID
        objAryTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND    '搬送指示状況
        objAryTPLN_CARRY_QUE.FCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SOUT        '指示区分
        intRet = objAryTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_ANY()             '取得
        If intRet <> RetCode.OK Then
            '(出庫指示がない場合)
            Return RetCode.OK
        Else
            '(出庫指示がある場合)

            objTSTS_HIKIATE.FWAIT_REASON = "ｸﾚｰﾝが出庫中(" & TO_STRING(objAryTPLN_CARRY_QUE.ARYME.Length) & "件)の為、出庫完了待ち。"
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

            Return RetCode.NotEnough
        End If


        Return intReturn
    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
