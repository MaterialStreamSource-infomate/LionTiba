'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出庫指示処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_010201
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
#Region "  構造体定義                                                                           "

#End Region
#Region "  出庫指示                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出庫指示
    ''' </summary>
    ''' <returns></returns>
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


            '************************
            '倉庫ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_ASRS.FPALLET_ID = mobjTPLN_CARRY_QUE.FPALLET_ID                 'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                            '特定


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/03 特殊処理


            '****************************************************************************
            '特殊処理12(ﾍﾟｱ搬送で、既に出庫処理が行われているか否かの判断)
            '****************************************************************************
            intRet = Special12(Nothing _
                             , objTPRG_TRK_BUF_ASRS _
                             , Nothing _
                             , Nothing _
                             , Nothing _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '在庫引当情報の特定
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '在庫引当情報ｸﾗｽ
            objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FPALLET_ID        'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                    '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[ﾊﾟﾚｯﾄID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            'ｸﾚｰﾝﾏｽﾀの特定
            '************************
            Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)             'ｸﾚｰﾝﾏｽﾀｸﾗｽ
            objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO                'ﾊﾞｯﾌｧ№
            objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU                 '列
            intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                                   '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                Throw New UserException(strMsg)
            End If


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2012/08/24 特殊処理


            '****************************************************************************
            '特殊処理11(ｸﾚｰﾝ毎に一件しか出庫指示を送信しないように制御)
            '****************************************************************************
            intRet = Special11(Nothing _
                             , objTPRG_TRK_BUF_ASRS _
                             , Nothing _
                             , objTSTS_HIKIATE _
                             , objTMST_CRANE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '↑↑↑↑↑↑************************************************************************************************************


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
            If TO_INTEGER(objTMST_CRANE.FINOUT_MAX) > 0 Then
                If TO_INTEGER(objTMST_CRANE.FOUT_MAX) <= mobjTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_SEND_COUNT_OUT() Then
                    '========================
                    '指示送信待ち理由の登録
                    '========================
                    objTSTS_HIKIATE.FWAIT_REASON = "出庫規制数ｵｰﾊﾞｰ  [ﾊﾞｯﾌｧ№" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "][設備ID" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                End If
            End If


            '************************
            'ｸﾚｰﾝ設備IDの特定
            '************************
            Dim strEQ_ID_CRANE_FM As String
            strEQ_ID_CRANE_FM = objTMST_CRANE.FEQ_ID


            '************************
            '搬送ﾙｰﾄﾏｽﾀの特定
            '************************
            Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)             '搬送ﾙｰﾄﾏｽﾀ
            objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_ASRS.FTR_FM                         '元ﾊﾞｯﾌｧ№
            objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_ASRS.FTR_TO                         '先ﾊﾞｯﾌｧ№
            objTMST_ROUTE.FEQ_ID_CRANE_FM = strEQ_ID_CRANE_FM                           '元ｸﾚｰﾝ設備ID
            objTMST_ROUTE.FEQ_ID_CRANE_TO = FEQ_ID_SKOTEI                               '先ｸﾚｰﾝ設備ID
            objTMST_ROUTE.GET_TMST_ROUTE()                                              '特定


            '************************
            '次ﾙｰﾄのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ検索
            '************************
            Dim objSVR_100207 As New SVR_100207(Owner, ObjDb, ObjDbLog)                     '次ﾙｰﾄのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ検索ｸﾗｽ
            objSVR_100207.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FPALLET_ID                      'ﾊﾟﾚｯﾄID
            objSVR_100207.FBUF_FM = objTMST_ROUTE.FBUF_FM                                   '元ﾊﾞｯﾌｧ№
            objSVR_100207.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM                   '元ｸﾚｰﾝ設備ID
            objSVR_100207.FBUF_TO = objTMST_ROUTE.FBUF_TO                                   '先ﾊﾞｯﾌｧ№
            objSVR_100207.FEQ_ID_CRANE_TO = objTMST_ROUTE.FEQ_ID_CRANE_TO                   '先ｸﾚｰﾝ設備ID
            intRet = objSVR_100207.GET_NEXT_TPRG_TRK_BUF                                    '次ﾙｰﾄのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ検索
            If intRet <> RetCode.OK Then
                '========================
                '指示送信待ち理由の登録
                '========================
                objTSTS_HIKIATE.FWAIT_REASON = objSVR_100207.FWAIT_REASON
                objTSTS_HIKIATE.FUPDATE_DT = Now
                objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                Return RetCode.NotEnough
            End If


            '************************
            '中継ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RELAY = objSVR_100207.TPRG_TRK_BUF_RELAY


            '*****************************
            '搬送先ﾊﾞｯﾌｧの特定
            '*****************************
            Dim objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF                                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_TO = objSVR_100207.TPRG_TRK_BUF_NEXT


            '************************
            'ﾙｰﾄ設備ﾁｪｯｸ(From - To)
            '************************
            Dim objSVR_100203 As New SVR_100203(Owner, ObjDb, ObjDbLog)
            objSVR_100203.FBUF_FM = objTMST_ROUTE.FBUF_FM                               '元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objSVR_100203.FBUF_TO = objTMST_ROUTE.FBUF_TO                               '先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objSVR_100203.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM               '元ｸﾚｰﾝ設備ID
            objSVR_100203.FEQ_ID_CRANE_TO = objTMST_ROUTE.FEQ_ID_CRANE_TO               '先ｸﾚｰﾝ設備ID
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

            '===============================
            'TO引当有無判定
            '===============================
            Dim objSVR_100206 As New SVR_100206(Owner, ObjDb, ObjDbLog)                 '全ﾙｰﾄの引当及び予約ｸﾗｽ
            If TO_INTEGER(objTMST_ROUTE.FRSV_BUF_TO_FLAG) = FRSV_BUF_TO_FLAG_SRSV Then
                '===============================
                'TO引当有無が「有」の場合、全ﾙｰﾄの引当＆予約を行う
                '===============================
                objSVR_100206.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FPALLET_ID              'ﾊﾟﾚｯﾄID
                objSVR_100206.FBUF_FM = objTMST_ROUTE.FBUF_FM                           '元ﾊﾞｯﾌｧ№
                objSVR_100206.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM           '元ｸﾚｰﾝ設備ID
                objSVR_100206.FBUF_TO = objTMST_ROUTE.FBUF_TO                           '先ﾊﾞｯﾌｧ№
                objSVR_100206.FEQ_ID_CRANE_TO = objTMST_ROUTE.FEQ_ID_CRANE_TO           '先ｸﾚｰﾝ設備ID
                objSVR_100206.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT                        '引当状態
                intRet = objSVR_100206.FIND_TMST_ROUTE_TO_END                           '全ﾙｰﾄの検索
                If intRet <> RetCode.OK Then
                    '(見つからない場合)
                    '========================
                    '指示送信待ち理由の登録
                    '========================
                    objTSTS_HIKIATE.FWAIT_REASON = objSVR_100206.FWAIT_REASON
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                End If
            End If


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/25 特殊処理


            '**************************************
            '特殊処理06(出棚ﾊﾞｯﾌｧ空ﾁｪｯｸ)
            '**************************************
            intRet = Special06(objTPRG_TRK_BUF_RELAY _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTPRG_TRK_BUF_TO _
                             , objTSTS_HIKIATE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '**************************************
            '特殊処理03(出庫指示の件数は一件のみ)
            '**************************************
            intRet = Special03(objTPRG_TRK_BUF_RELAY _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTPRG_TRK_BUF_TO _
                             , objTSTS_HIKIATE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '**************************************
            '特殊処理04(入庫指示ﾁｪｯｸ)
            '**************************************
            intRet = Special04(objTPRG_TRK_BUF_RELAY _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTPRG_TRK_BUF_TO _
                             , objTSTS_HIKIATE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '**************************************
            '特殊処理05(手前棚ﾁｪｯｸ)
            '**************************************
            intRet = Special05(objTPRG_TRK_BUF_RELAY _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTPRG_TRK_BUF_TO _
                             , objTSTS_HIKIATE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '在庫移動
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '在庫移動ｸﾗｽ
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_ASRS     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_RELAY    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FPALLET_ID  'ﾊﾟﾚｯﾄID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SOUT_START             'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '作業種別
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_OFF                   '搬送元ｸﾘｱﾌﾗｸﾞ
            objSVR_100103.STOCK_TRNS()                                  '移動


            '******************************************************
            '倉庫/出庫中/出庫先ﾊﾞｯﾌｧの更新
            '******************************************************
            '===============================
            '倉庫ﾊﾞｯﾌｧの更新
            '===============================
            objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT                         '引当状態
            objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO               'TO引当ﾄﾗｯｷﾝｸﾞ№
            objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY          'TO引当配列№
            objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_ASRS.GET_ADDRESS_TO     'TO表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF_ASRS.FBUF_IN_DT = Now                                           'ﾊﾞｯﾌｧ入日時
            objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                                      '更新


            '===============================
            '出庫中ﾊﾞｯﾌｧの更新
            '===============================
            objTPRG_TRK_BUF_RELAY.FRSV_PALLET = objTPRG_TRK_BUF_ASRS.FRSV_PALLET                '仮引当ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_RELAY.FRES_KIND = FRES_KIND_SZAIKO                                   '引当状態
            objTPRG_TRK_BUF_RELAY.FTR_FM = objTPRG_TRK_BUF_ASRS.FTR_FM                          '搬送FMﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_RELAY.FTR_TO = objTPRG_TRK_BUF_ASRS.FTR_TO                          '搬送TOﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_RELAY.FTR_IDOU = objTPRG_TRK_BUF_ASRS.FTR_IDOU                      '搬送TO移動ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_RELAY.FTRNS_FM = objTPRG_TRK_BUF_ASRS.FTRNS_ADDRESS                 '搬送指令用FM
            objTPRG_TRK_BUF_RELAY.FTRNS_TO = objTPRG_TRK_BUF_TO.FTRNS_ADDRESS                   '搬送指令用TO
            objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM = objTPRG_TRK_BUF_ASRS.FRSV_BUF_FM                'FM引当ﾄﾗｯｷﾝｸﾞ№
            objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM = objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_FM            'FM引当配列№
            objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO = objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO                'TO引当ﾄﾗｯｷﾝｸﾞ№
            objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO            'TO引当配列№
            objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_FM      'FM表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_RELAY.GET_ADDRESS_TO       'TO表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF_RELAY.FBUF_IN_DT = Now                                              'ﾊﾞｯﾌｧ入日時
            objTPRG_TRK_BUF_RELAY.UPDATE_TPRG_TRK_BUF()                                         '更新

            '===============================
            'TO引当有無判定
            '===============================
            If TO_INTEGER(objTMST_ROUTE.FRSV_BUF_TO_FLAG) = FRSV_BUF_TO_FLAG_SRSV Then
                '===============================
                '出庫先ﾊﾞｯﾌｧの更新
                '===============================
                objTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT                               '引当状態
                objTPRG_TRK_BUF_TO.FBUF_IN_DT = Now                                                 'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_TO.FRSV_PALLET = objTPRG_TRK_BUF_ASRS.FRSV_PALLET                   '仮引当ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_TO.FTR_FM = objTPRG_TRK_BUF_ASRS.FTR_FM                             '搬送FMﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_TO.FTR_TO = objTPRG_TRK_BUF_ASRS.FTR_TO                             '搬送TOﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_TO.FRSV_BUF_FM = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO                   'FM引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_TO.FRSV_ARRAY_FM = objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY              'FM引当配列№
                objTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()                                            '更新


                '===============================
                'TO引当有無が「有」の場合、全ﾙｰﾄの引当＆予約を行う
                '===============================
                Call objSVR_100206.RSV_TMST_ROUTE_TO_END()                                      '引当＆予約
            End If


            '************************
            '搬送指示QUEの更新
            '************************
            mobjTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND    '搬送指示状況
            mobjTPLN_CARRY_QUE.FUPDATE_DT = Now                             '更新日時
            mobjTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                      '更新


            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/04/25  搬送元を登録(出庫実績等で必要)

            '************************************************
            'ﾊﾟﾚｯﾄ情報      更新
            '************************************************
            Dim objTRST_PALLET As New TBL_TRST_PALLET(Owner, ObjDb, ObjDbLog)
            objTRST_PALLET.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID     'ﾊﾟﾚｯﾄID
            objTRST_PALLET.GET_TRST_PALLET()
            objTRST_PALLET.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTRST_PALLET.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
            objTRST_PALLET.UPDATE_TRST_PALLET()

            '↑↑↑↑↑↑************************************************************************************************************


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2012/04/24 出庫指示を送信


            '************************************************
            '出庫指示
            '************************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SOUT                    'ｺﾏﾝﾄﾞID
            objSVR_190001.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID     'ﾊﾟﾚｯﾄID
            objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
            objSVR_190001.SendYasukawa_IDOut(objTPRG_TRK_BUF_RELAY _
                                           , objTPRG_TRK_BUF_ASRS _
                                           , objTPRG_TRK_BUF_TO _
                                           , objTSTS_HIKIATE _
                                           , mobjTPLN_CARRY_QUE _
                                           , objTMST_ROUTE _
                                           )


            '↑↑↑↑↑↑************************************************************************************************************


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/06/24 特殊処理


            '************************************************
            '特殊処理21(出荷指示、出荷指示詳細ﾃｰﾌﾞﾙ更新)
            '************************************************
            intRet = Special21(objTPRG_TRK_BUF_RELAY _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTPRG_TRK_BUF_TO _
                             , objTSTS_HIKIATE _
                             )


            '↑↑↑↑↑↑************************************************************************************************************


            '========================
            '指示送信待ち理由のｸﾘｱ
            '========================
            objTSTS_HIKIATE.FWAIT_REASON = DEFAULT_STRING
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()


            '************************
            '正常完了
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & _
                                "  [ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & _
                                "  ,搬送元:" & objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS & _
                                "  ,搬送先:" & objTPRG_TRK_BUF_TO.FDISP_ADDRESS & _
                                "]")


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/03 特殊処理


            '****************************************************************************
            '特殊処理13(ﾍﾟｱ搬送で、相方の出庫指示を行う)
            '****************************************************************************
            intRet = Special13(objTPRG_TRK_BUF_RELAY _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTPRG_TRK_BUF_TO _
                             , objTSTS_HIKIATE _
                             , objTMST_CRANE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '↑↑↑↑↑↑************************************************************************************************************


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

#Region "  出庫指示(棚間搬送)                                                                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出庫指示(棚間搬送)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecCmdFunction_Tana() As RetCode
        Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            '************************
            '初期処理
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            '************************
            '搬送指示QUE
            '************************
            If IsNull(mobjTPLN_CARRY_QUE) = True Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPLN_CARRY_QUE
                Throw New UserException(strMsg)
            End If


            '************************
            '倉庫ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_ASRS.FPALLET_ID = mobjTPLN_CARRY_QUE.FPALLET_ID                 'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                            '特定


            '************************
            '在庫引当情報の特定
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '在庫引当情報ｸﾗｽ
            objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FPALLET_ID        'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                    '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[ﾊﾟﾚｯﾄID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            'ｸﾚｰﾝﾏｽﾀの特定
            '************************
            Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)             'ｸﾚｰﾝﾏｽﾀｸﾗｽ
            objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO                'ﾊﾞｯﾌｧ№
            objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU                 '列
            intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                                   '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
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
            If TO_INTEGER(objTMST_CRANE.FINOUT_MAX) > 0 Then
                If TO_INTEGER(objTMST_CRANE.FOUT_MAX) <= mobjTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_SEND_COUNT_OUT() Then
                    '========================
                    '指示送信待ち理由の登録
                    '========================
                    objTSTS_HIKIATE.FWAIT_REASON = "出庫規制数ｵｰﾊﾞｰ  [ﾊﾞｯﾌｧ№" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "][設備ID" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                End If
            End If


            '************************
            'ｸﾚｰﾝ設備IDの特定
            '************************
            Dim strEQ_ID_CRANE_FM As String
            strEQ_ID_CRANE_FM = objTMST_CRANE.FEQ_ID


            '************************
            'ｸﾚｰﾝ設備IDの特定(搬送先)
            '************************
            Dim objTPRG_TRK_BUF_Temp As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF_Temp.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_Temp.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
            intRet = objTPRG_TRK_BUF_Temp.GET_TPRG_TRK_BUF(True)
            Dim objTMST_CRANE_TO As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)             'ｸﾚｰﾝﾏｽﾀｸﾗｽ
            objTMST_CRANE_TO.FTRK_BUF_NO = objTPRG_TRK_BUF_Temp.FTRK_BUF_NO                'ﾊﾞｯﾌｧ№
            objTMST_CRANE_TO.INTCHECK_ROW = objTPRG_TRK_BUF_Temp.FRAC_RETU                 '列
            intRet = objTMST_CRANE_TO.GET_TMST_CRANE_ROW                                   '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE_TO.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE_TO.INTCHECK_ROW) & "]"
                Throw New UserException(strMsg)
            End If
            Dim strEQ_ID_CRANE_TO As String
            strEQ_ID_CRANE_TO = objTMST_CRANE_TO.FEQ_ID


            '************************
            '搬送ﾙｰﾄﾏｽﾀの特定
            '************************
            Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)             '搬送ﾙｰﾄﾏｽﾀ
            objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_ASRS.FTR_FM                         '元ﾊﾞｯﾌｧ№
            objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_ASRS.FTR_TO                         '先ﾊﾞｯﾌｧ№
            objTMST_ROUTE.FEQ_ID_CRANE_FM = strEQ_ID_CRANE_FM                           '元ｸﾚｰﾝ設備ID
            objTMST_ROUTE.FEQ_ID_CRANE_TO = strEQ_ID_CRANE_TO                           '先ｸﾚｰﾝ設備ID
            intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                                 '特定


            '************************
            '次ﾙｰﾄのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ検索
            '************************
            Dim objSVR_100207 As New SVR_100207(Owner, ObjDb, ObjDbLog)                     '次ﾙｰﾄのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ検索ｸﾗｽ
            objSVR_100207.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FPALLET_ID                      'ﾊﾟﾚｯﾄID
            objSVR_100207.FBUF_FM = objTMST_ROUTE.FBUF_FM                                   '元ﾊﾞｯﾌｧ№
            objSVR_100207.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM                   '元ｸﾚｰﾝ設備ID
            objSVR_100207.FBUF_TO = objTMST_ROUTE.FBUF_TO                                   '先ﾊﾞｯﾌｧ№
            objSVR_100207.FEQ_ID_CRANE_TO = objTMST_ROUTE.FEQ_ID_CRANE_TO                   '先ｸﾚｰﾝ設備ID
            intRet = objSVR_100207.GET_NEXT_TPRG_TRK_BUF                                    '次ﾙｰﾄのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ検索
            If intRet <> RetCode.OK Then
                '========================
                '指示送信待ち理由の登録
                '========================
                objTSTS_HIKIATE.FWAIT_REASON = objSVR_100207.FWAIT_REASON
                objTSTS_HIKIATE.FUPDATE_DT = Now
                objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                Return RetCode.NotEnough
            End If


            '************************
            '中継ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RELAY = objSVR_100207.TPRG_TRK_BUF_RELAY


            '*****************************
            '搬送先ﾊﾞｯﾌｧの特定
            '*****************************
            Dim objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF                                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_TO = objSVR_100207.TPRG_TRK_BUF_NEXT


            '************************
            'ﾙｰﾄ設備ﾁｪｯｸ(From - To)
            '************************
            Dim objSVR_100203 As New SVR_100203(Owner, ObjDb, ObjDbLog)
            objSVR_100203.FBUF_FM = objTMST_ROUTE.FBUF_FM                               '元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objSVR_100203.FBUF_TO = objTMST_ROUTE.FBUF_TO                               '先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objSVR_100203.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM               '元ｸﾚｰﾝ設備ID
            objSVR_100203.FEQ_ID_CRANE_TO = objTMST_ROUTE.FEQ_ID_CRANE_TO               '先ｸﾚｰﾝ設備ID
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


            '===============================
            'TO引当有無判定
            '===============================
            Dim objSVR_100206 As New SVR_100206(Owner, ObjDb, ObjDbLog)                 '全ﾙｰﾄの引当及び予約ｸﾗｽ
            If TO_INTEGER(objTMST_ROUTE.FRSV_BUF_TO_FLAG) = FRSV_BUF_TO_FLAG_SRSV Then
                '===============================
                'TO引当有無が「有」の場合、全ﾙｰﾄの引当＆予約を行う
                '===============================
                objSVR_100206.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FRSV_PALLET             'ﾊﾟﾚｯﾄID
                objSVR_100206.FBUF_FM = objTMST_ROUTE.FBUF_FM                           '元ﾊﾞｯﾌｧ№
                objSVR_100206.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM           '元ｸﾚｰﾝ設備ID
                objSVR_100206.FBUF_TO = objTMST_ROUTE.FBUF_TO                           '先ﾊﾞｯﾌｧ№
                objSVR_100206.FEQ_ID_CRANE_TO = objTMST_ROUTE.FEQ_ID_CRANE_TO           '先ｸﾚｰﾝ設備ID
                objSVR_100206.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT                        '引当状態
                intRet = objSVR_100206.FIND_TMST_ROUTE_TO_END                           '全ﾙｰﾄの検索
                If intRet <> RetCode.OK Then
                    '(見つからない場合)
                    '========================
                    '指示送信待ち理由の登録
                    '========================
                    objTSTS_HIKIATE.FWAIT_REASON = objSVR_100206.FWAIT_REASON
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                End If
            End If


            '************************
            '在庫移動
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '在庫移動ｸﾗｽ
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_ASRS     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_RELAY    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FPALLET_ID  'ﾊﾟﾚｯﾄID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SSOUKO_START          'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '作業種別
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_OFF                   '搬送元ｸﾘｱﾌﾗｸﾞ
            objSVR_100103.STOCK_TRNS()                                  '移動


            '******************************************************
            '倉庫/出庫中/出庫先ﾊﾞｯﾌｧの更新
            '******************************************************
            '===============================
            '倉庫ﾊﾞｯﾌｧの更新
            '===============================
            objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT                         '引当状態
            objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO               'TO引当ﾄﾗｯｷﾝｸﾞ№
            objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY          'TO引当配列№
            objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_ASRS.GET_ADDRESS_TO     'TO表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF_ASRS.FBUF_IN_DT = Now                                           'ﾊﾞｯﾌｧ入日時
            objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                                      '更新


            '===============================
            '出庫中ﾊﾞｯﾌｧの更新
            '===============================
            objTPRG_TRK_BUF_RELAY.FRSV_PALLET = objTPRG_TRK_BUF_ASRS.FRSV_PALLET                '仮引当ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_RELAY.FRES_KIND = FRES_KIND_SZAIKO                                   '引当状態
            objTPRG_TRK_BUF_RELAY.FTR_FM = objTPRG_TRK_BUF_ASRS.FTR_FM                          '搬送FMﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_RELAY.FTR_TO = objTPRG_TRK_BUF_ASRS.FTR_TO                          '搬送TOﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_RELAY.FTR_IDOU = objTPRG_TRK_BUF_ASRS.FTR_IDOU                      '搬送TO移動ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_RELAY.FTRNS_FM = objTPRG_TRK_BUF_ASRS.FTRNS_ADDRESS                 '搬送指令用FM
            objTPRG_TRK_BUF_RELAY.FTRNS_TO = objTPRG_TRK_BUF_TO.FTRNS_ADDRESS                   '搬送指令用TO
            objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM = objTPRG_TRK_BUF_ASRS.FRSV_BUF_FM                'FM引当ﾄﾗｯｷﾝｸﾞ№
            objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM = objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_FM            'FM引当配列№
            objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO = objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO                'TO引当ﾄﾗｯｷﾝｸﾞ№
            objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO            'TO引当配列№
            objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_FM      'FM表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_RELAY.GET_ADDRESS_TO       'TO表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF_RELAY.FBUF_IN_DT = Now                                              'ﾊﾞｯﾌｧ入日時
            objTPRG_TRK_BUF_RELAY.UPDATE_TPRG_TRK_BUF()                                         '更新

            '===============================
            '出庫先ﾊﾞｯﾌｧの更新
            '===============================
            objTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                                '引当状態
            objTPRG_TRK_BUF_TO.FBUF_IN_DT = Now                                                 'ﾊﾞｯﾌｧ入日時
            objTPRG_TRK_BUF_TO.FRSV_PALLET = objTPRG_TRK_BUF_ASRS.FRSV_PALLET                   '仮引当ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_TO.FTR_FM = objTPRG_TRK_BUF_ASRS.FTR_FM                             '搬送FMﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_TO.FTR_TO = objTPRG_TRK_BUF_ASRS.FTR_TO                             '搬送TOﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_TO.FRSV_BUF_FM = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO                   'FM引当ﾄﾗｯｷﾝｸﾞ№
            objTPRG_TRK_BUF_TO.FRSV_ARRAY_FM = objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY              'FM引当配列№
            objTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()                                            '更新


            '===============================
            'TO引当有無判定
            '===============================
            If TO_INTEGER(objTMST_ROUTE.FRSV_BUF_TO_FLAG) = FRSV_BUF_TO_FLAG_SRSV Then
                '===============================
                'TO引当有無が「有」の場合、全ﾙｰﾄの引当＆予約を行う
                '===============================
                Call objSVR_100206.RSV_TMST_ROUTE_TO_END()                                      '引当＆予約
            End If


            '************************
            '搬送指示QUEの更新
            '************************
            mobjTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND    '搬送指示状況
            mobjTPLN_CARRY_QUE.FUPDATE_DT = Now                             '更新日時
            mobjTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                      '更新


            '========================
            '指示送信待ち理由のｸﾘｱ
            '========================
            objTSTS_HIKIATE.FWAIT_REASON = DEFAULT_STRING
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()


            '************************
            '正常完了
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & _
                                "  [ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & _
                                "  ,搬送元:" & objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS & _
                                "  ,搬送先:" & objTPRG_TRK_BUF_TO.FDISP_ADDRESS & _
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

#Region "  特殊処理01(ﾓｰﾄﾞﾁｪｯｸ  [出庫指示用])                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理01(ﾓｰﾄﾞﾁｪｯｸ  [出庫指示用])
    ''' </summary>
    ''' <param name="objTSTS_HIKIATE">在庫引当情報</param>
    ''' <param name="objTPRG_TRK_BUF_ST">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ST)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special01(ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             , ByVal objTPRG_TRK_BUF_ST As TBL_TPRG_TRK_BUF _
                             ) _
                             As RetCode


        '************************************************
        '設備状況(ﾓｰﾄﾞ)     取得
        '************************************************
        Dim strXEQ_ID_MOD As String = GetXEQ_ID_MODFromFTRK_BUF_NO(objTPRG_TRK_BUF_ST.FTRK_BUF_NO)

        If strXEQ_ID_MOD <> "" Then
            '(入出庫ﾓｰﾄﾞ切替可能ﾄﾗｯｷﾝｸﾞのとき)
            Dim objTSTS_EQ_CTRL_MOD As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            objTSTS_EQ_CTRL_MOD.FEQ_ID = strXEQ_ID_MOD          '設備ID
            objTSTS_EQ_CTRL_MOD.GET_TSTS_EQ_CTRL()              '取得

            Select Case objTSTS_HIKIATE.FSAGYOU_KIND
                Case FSAGYOU_KIND_SOUT, FSAGYOU_KIND_STOI_OUT
                    '(計画出庫、問合せ出庫の場合)
                    If objTSTS_EQ_CTRL_MOD.FEQ_STS <> FEQ_STS_SINOUTMODE_OUT Then
                        '(出庫ﾓｰﾄﾞ以外の場合)

                        objTSTS_HIKIATE.FWAIT_REASON = "出庫ﾓｰﾄﾞ待ち  [設備ID:" & objTSTS_EQ_CTRL_MOD.FEQ_ID & "]"
                        objTSTS_HIKIATE.FUPDATE_DT = Now
                        objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                        Return RetCode.NotEnough
                    End If
            End Select

        End If

        Return RetCode.OK
    End Function
#End Region
#Region "  特殊処理03(出庫指示の件数は一件のみ)                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理03(出庫指示の件数は一件のみ)
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
        End If
        If 2 <= objAryTPLN_CARRY_QUE.ARYME.Length Then
            '(2件以上の出庫指示がある場合)

            objTSTS_HIKIATE.FWAIT_REASON = "ｸﾚｰﾝが出庫中[" & TO_STRING(objAryTPLN_CARRY_QUE.ARYME.Length) & "件]の為、出庫完了待ち。"
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

            Return RetCode.NotEnough
        End If


        '***********************************************
        '1件の出庫ﾄﾗｯｷﾝｸﾞが相方かどうかのﾁｪｯｸ
        '出庫ﾄﾗｯｷﾝｸﾞが相方だった場合はOKとする
        '***********************************************
        If TO_STRING(objAryTPLN_CARRY_QUE.ARYME(0).XPALLET_ID_AITE) = mobjTPLN_CARRY_QUE.FPALLET_ID Then
            '(相方が自分だった場合)
            Return RetCode.OK
        Else
            '(相方が自分じゃない場合)

            objTSTS_HIKIATE.FWAIT_REASON = "ｸﾚｰﾝが出庫中(1件)の為、出庫完了待ち。"
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

            Return RetCode.NotEnough
        End If


        Return intReturn
    End Function
#End Region
#Region "  特殊処理04(入庫指示ﾁｪｯｸ)                                                                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理04(入庫指示ﾁｪｯｸ)
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
        Else
            '(入庫指示がある場合)

            objTSTS_HIKIATE.FWAIT_REASON = "ｸﾚｰﾝが入庫中(" & TO_STRING(objAryTPLN_CARRY_QUE.ARYME.Length) & "件)の為、入庫完了待ち。"
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

            Return RetCode.NotEnough
        End If


        Return intReturn
    End Function
#End Region
#Region "  特殊処理05(手前棚ﾁｪｯｸ)                                                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理05(入庫指示ﾁｪｯｸ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special05(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '***********************************************
        'ﾁｪｯｸ
        '***********************************************
        If objTPRG_TRK_BUF_FM.FRAC_EDA = FLAG_OFF Then Return RetCode.OK


        '***********************************************
        '関連するﾌﾞﾛｯｸ棚の取得
        '***********************************************
        Dim objTrkRelation() As TBL_TPRG_TRK_BUF = Nothing                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
        Dim objStockFind As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)          '在庫情報
        Dim objStockRelation() As TBL_TRST_STOCK = Nothing                      '在庫情報
        Call GetTPRG_TRK_BUF_Relation(objTPRG_TRK_BUF_FM, objTrkRelation, objStockFind, objStockRelation)


        '***********************************************
        '前棚ﾁｪｯｸ
        '***********************************************
        If IsNull(objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID) And IsNull(objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID) Then
            '(前棚が両方とも空棚だった場合)
            Return RetCode.OK
        End If


        '**********************************************************************************************
        '搬送指示QUE            更新
        '前棚の優先を上げる
        '
        'ｸﾚｰﾝに対して一回の出庫指示しかﾄﾗｲしないので、前棚よりも奥棚の方が優先度が高いと、永遠に出庫指示が出なくなるので、その対応
        '**********************************************************************************************
        Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)
        '===================================
        '前棚奇数       更新
        '===================================
        If IsNotNull(objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID) Then
            '(在庫が存在している場合)

            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
            objTPLN_CARRY_QUE.FPALLET_ID = objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID     'ﾊﾟﾚｯﾄID
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON                        '搬送指示状況
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)                                '取得
            If intRet = RetCode.OK Then
                objTPLN_CARRY_QUE.FPRIORITY += 1                    '優先ﾚﾍﾞﾙ
                objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()           '更新
                objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)           'もう一回起動
            End If

        End If

        '===================================
        '前棚偶数       更新
        '===================================
        If IsNotNull(objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID) Then
            '(在庫が存在している場合)

            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
            objTPLN_CARRY_QUE.FPALLET_ID = objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID     'ﾊﾟﾚｯﾄID
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON                        '搬送指示状況
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)                                '取得
            If intRet = RetCode.OK Then
                objTPLN_CARRY_QUE.FPRIORITY += 1                    '優先ﾚﾍﾞﾙ
                objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()           '更新
                objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)           'もう一回起動
            End If

        End If



        '***********************************************
        '指示待ち理由           更新
        '***********************************************
        objTSTS_HIKIATE.FWAIT_REASON = "前棚の出庫待ち"
        objTSTS_HIKIATE.FUPDATE_DT = Now
        objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()


        Return RetCode.NotEnough
    End Function
#End Region
#Region "  特殊処理06(出棚ﾊﾞｯﾌｧ空ﾁｪｯｸ)                                                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理06(出棚ﾊﾞｯﾌｧ空ﾁｪｯｸ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special06(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             ) _
                             As RetCode
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK



        '**************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ        取得
        '**************************************
        Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTMST_TRK.GET_TMST_TRK(False)                             '取得
        If IsNull(objTMST_TRK.XEQ_ID_OUT_BUF) Then Return RetCode.OK


        '**************************************
        '設備状況(出棚ﾊﾞｯﾌｧ空)      取得
        '**************************************
        Dim objTSTS_EQ_CTRL_OUT_BUF As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        objTSTS_EQ_CTRL_OUT_BUF.FEQ_ID = objTMST_TRK.XEQ_ID_OUT_BUF     '設備ID
        objTSTS_EQ_CTRL_OUT_BUF.GET_TSTS_EQ_CTRL()                      '取得


        '**************************************
        'ﾁｪｯｸ
        '**************************************
        If TO_INTEGER(objTSTS_EQ_CTRL_OUT_BUF.FEQ_STS) = FLAG_ON Then
            '(出棚ﾊﾞｯﾌｧ空ONの場合)
            Return RetCode.OK
        Else
            objTSTS_HIKIATE.FWAIT_REASON = "出棚ﾊﾞｯﾌｧ空待ち  [設備ID:" & objTSTS_EQ_CTRL_OUT_BUF.FEQ_ID & "]"
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

            Return RetCode.NotEnough
        End If


        Return RetCode.NotEnough
    End Function
#End Region


#Region "  特殊処理11(ｸﾚｰﾝ毎に一件しか出庫指示を送信しないように制御)                                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理11(ｸﾚｰﾝ毎に一件しか出庫指示を送信しないように制御)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">搬送中ﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FMﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TOﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTSTS_HIKIATE">在庫引当情報</param>
    ''' <param name="objTMST_CRANE">ｸﾚｰﾝﾏｽﾀ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special11(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             , ByVal objTMST_CRANE As TBL_TMST_CRANE _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String


        '************************************************
        '初期設定
        '************************************************
        Dim intCount As Integer = 0     '出庫指示ｶｳﾝﾄ数


        '************************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ﾁｪｯｸ用)       取得
        '************************************************
        Dim objTPRG_TRK_BUF_ASRS_CHECK As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        objTPRG_TRK_BUF_ASRS_CHECK.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTPRG_TRK_BUF_ASRS_CHECK.objTMST_CRANE = objTMST_CRANE                    'ｸﾚｰﾝﾏｽﾀ
        intRet = objTPRG_TRK_BUF_ASRS_CHECK.GET_TPRG_TRK_BUF_RESERVE_RAC(True)      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [入出庫予約棚]
        If intRet = RetCode.OK Then
            For ii As Integer = 0 To UBound(objTPRG_TRK_BUF_ASRS_CHECK.ARYME)
                '(ﾙｰﾌﾟ:入出庫予約棚数)

                If objTPRG_TRK_BUF_ASRS_CHECK.ARYME(ii).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Then
                    '(搬出予約の場合)

                    intCount += 1
                    If intCount = 2 Then
                        '(既に2件出庫していた場合)
                        objTSTS_HIKIATE.FWAIT_REASON = "ｸﾚｰﾝが出庫中の為、出庫完了待ち。"
                        objTSTS_HIKIATE.FUPDATE_DT = Now
                        objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()
                        Return RetCode.NotEnough
                    End If

                End If

            Next
        End If


        Return RetCode.OK
    End Function
#End Region
#Region "  特殊処理12(ﾍﾟｱ搬送で、既に出庫処理が行われているか否かの判断)                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理12(ﾍﾟｱ搬送で、既に出庫処理が行われているか否かの判断)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">搬送中ﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FMﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TOﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTSTS_HIKIATE">在庫引当情報</param>
    ''' <param name="objTMST_CRANE">ｸﾚｰﾝﾏｽﾀ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special12(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             , ByVal objTMST_CRANE As TBL_TMST_CRANE _
                             ) _
                             As RetCode
        'Dim intRet As RetCode
        'Dim strMsg As String


        '************************************************
        '初期設定
        '************************************************
        Dim intCount As Integer = 0     '出庫指示ｶｳﾝﾄ数


        '************************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ﾁｪｯｸ用)       取得
        '************************************************
        If objTPRG_TRK_BUF_FM.FTRK_BUF_NO <> FTRK_BUF_NO_J9000 Then
            Return RetCode.NotEnough
        End If


        Return RetCode.OK
    End Function
#End Region
#Region "  特殊処理13(ﾍﾟｱ搬送で、相方の出庫指示を行う)                                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理13(ﾍﾟｱ搬送で、相方の出庫指示を行う)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">搬送中ﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FMﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TOﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTSTS_HIKIATE">在庫引当情報</param>
    ''' <param name="objTMST_CRANE">ｸﾚｰﾝﾏｽﾀ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special13(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             , ByVal objTMST_CRANE As TBL_TMST_CRANE _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String


        '************************
        'ﾁｪｯｸ
        '************************
        If IsNull(mobjTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
            '(ｼﾝｸﾞﾙ出庫の場合)
            Return RetCode.OK
        End If


        '************************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(相手)         取得
        '************************************************
        Dim objTPRG_TRK_BUF_AITE As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        objTPRG_TRK_BUF_AITE.FPALLET_ID = mobjTPLN_CARRY_QUE.XPALLET_ID_AITE        'ﾊﾟﾚｯﾄID
        objTPRG_TRK_BUF_AITE.GET_TPRG_TRK_BUF()                                     '取得
        If objTPRG_TRK_BUF_AITE.FTRK_BUF_NO <> objTPRG_TRK_BUF_FM.FTRK_BUF_NO Then
            '(相手のﾊﾟﾚｯﾄが自動倉庫にいなかった場合)
            Return RetCode.OK
        End If



        '************************
        '搬送指示QUEの特定
        '************************
        Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)         '搬送指示QUE
        objTPLN_CARRY_QUE.FPALLET_ID = mobjTPLN_CARRY_QUE.XPALLET_ID_AITE               'ﾊﾟﾚｯﾄID
        objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                                          '特定


        '************************
        '出庫指示処理
        '************************
        Dim objSVR_010201 As New SVR_010201(Owner, ObjDb, ObjDbLog) '出庫指示ｸﾗｽ
        objSVR_010201.TPLN_CARRY_QUE = objTPLN_CARRY_QUE            '搬送指示QUE
        intRet = objSVR_010201.ExecCmdFunction()
        If intRet = RetCode.OK Then
            '(出庫指示された場合)


            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/08/15  完了報告が受信しない場合、自動で完了させるが、自動で完了させると搬送指示QUEにﾚｺｰﾄﾞがなくなり、ｴﾗｰとなるのでその対策
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)
            If intRet = RetCode.OK Then
                '↑↑↑↑↑↑************************************************************************************************************
                objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND
                objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()
                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/08/15  完了報告が受信しない場合、自動で完了させるが、自動で完了させると搬送指示QUEにﾚｺｰﾄﾞがなくなり、ｴﾗｰとなるのでその対策
            End If
            '↑↑↑↑↑↑************************************************************************************************************


        End If


        Return RetCode.OK
    End Function
#End Region

#Region "  特殊処理21(出荷指示、出荷指示詳細ﾃｰﾌﾞﾙ更新)                                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理21(出荷指示、出荷指示詳細ﾃｰﾌﾞﾙ更新)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">搬送中ﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FMﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TOﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTSTS_HIKIATE">在庫引当情報</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special21(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String


        '************************
        'ﾁｪｯｸ
        '************************
        'NOP


        '************************************************
        '出荷指示詳細                   取得
        '************************************************
        Dim objXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
        objXPLN_OUT_DTL.FPLAN_KEY = objTSTS_HIKIATE.FPLAN_KEY       '計画ｷｰ
        intRet = objXPLN_OUT_DTL.GET_XPLN_OUT_DTL(False)            '取得
        If intRet <> RetCode.OK Then
            Return RetCode.OK
        End If


        '************************************************
        '出荷指示                       取得
        '************************************************
        Dim objXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
        objXPLN_OUT.XSYUKKA_D = objXPLN_OUT_DTL.XSYUKKA_D           '出荷日
        objXPLN_OUT.XHENSEI_NO = objXPLN_OUT_DTL.XHENSEI_NO         '編成No.
        objXPLN_OUT.XDENPYOU_NO = objXPLN_OUT_DTL.XDENPYOU_NO       '伝票No.
        objXPLN_OUT.GET_XPLN_OUT()                                  '取得


        '************************************************
        '出荷指示                       更新
        '************************************************
        If objXPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JRSV Then
            objXPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JACT      '出荷状況
            objXPLN_OUT.UPDATE_XPLN_OUT()                   '更新
        End If


        Return RetCode.OK
    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
