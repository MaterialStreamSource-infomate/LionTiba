'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】搬送指示処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_010301
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
#Region "  搬送指示                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 搬送指示
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecCmdFunction() As RetCode
        Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            ' '' ''************************
            ' '' ''初期処理
            ' '' ''************************
            '' ''Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            '************************
            '搬送指示QUE
            '************************
            If IsNull(mobjTPLN_CARRY_QUE) = True Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPLN_CARRY_QUE
                Throw New UserException(strMsg)
            End If


            '************************
            '搬送元ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_FM.FPALLET_ID = mobjTPLN_CARRY_QUE.FPALLET_ID               'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF(True)                          '特定


            '************************
            '搬送元ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀｸﾗｽ
            objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            intRet = objTMST_TRK.GET_TMST_TRK(True)                                     '特定


            '************************
            '搬送元ｸﾚｰﾝ設備IDの特定
            '************************
            Dim strEQ_ID_CRANE_FM As String
            If TO_INTEGER(objTMST_TRK.FBUF_KIND) = FBUF_KIND_SASRS Then
                '************************
                'ｸﾚｰﾝﾏｽﾀの特定
                '************************
                Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)         'ｸﾚｰﾝﾏｽﾀｸﾗｽ
                objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO              'ﾊﾞｯﾌｧ№
                objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_FM.FRAC_RETU               '列
                intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                               '特定
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                    Throw New UserException(strMsg)
                End If

                'ｸﾚｰﾝ設備IDの特定
                strEQ_ID_CRANE_FM = objTMST_CRANE.FEQ_ID
            Else
                'ｸﾚｰﾝ設備IDの特定
                strEQ_ID_CRANE_FM = FEQ_ID_SKOTEI
            End If

            Dim strEQ_ID_CRANE_TO_WORK As String
            '************************
            '最終到達ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_END_WORK As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_END_WORK.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTR_TO                 'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_END_WORK.FRSV_PALLET = mobjTPLN_CARRY_QUE.FPALLET_ID                              '仮引当ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_END_WORK.GET_TPRG_TRK_BUF_RSV_PALLET()
            If intRet = RetCode.OK Then
                '(最終到着ﾊﾞｯﾌｧが引当てされている場合)

                '************************
                'ｸﾚｰﾝﾏｽﾀの特定
                '************************
                Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)         'ｸﾚｰﾝﾏｽﾀｸﾗｽ
                objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_END_WORK.FTRK_BUF_NO             'ﾊﾞｯﾌｧ№
                objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_END_WORK.FRAC_RETU              '列
                intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                               '特定
                If intRet = RetCode.OK Then
                    '(ｸﾚｰﾝが引きあたった場合)
                    strEQ_ID_CRANE_TO_WORK = objTMST_CRANE.FEQ_ID
                Else
                    strEQ_ID_CRANE_TO_WORK = FEQ_ID_SKOTEI
                End If
                'ｸﾚｰﾝ設備IDの特定
                strEQ_ID_CRANE_TO_WORK = objTMST_CRANE.FEQ_ID

            Else
                '(最終到着ﾊﾞｯﾌｧが引当てされていない場合)
                strEQ_ID_CRANE_TO_WORK = FEQ_ID_SKOTEI
            End If


            '************************
            '搬送ﾙｰﾄﾏｽﾀの特定
            '************************
            Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)             '搬送ﾙｰﾄﾏｽﾀ
            objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO                      '元ﾊﾞｯﾌｧ№
            objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_FM.FTR_TO                           '先ﾊﾞｯﾌｧ№
            objTMST_ROUTE.FEQ_ID_CRANE_FM = strEQ_ID_CRANE_FM                           '元ｸﾚｰﾝ設備ID
            objTMST_ROUTE.FEQ_ID_CRANE_TO = strEQ_ID_CRANE_TO_WORK                      '先ｸﾚｰﾝ設備ID
            intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                                 '特定


            '************************
            '在庫引当情報の特定
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)         '在庫引当情報ｸﾗｽ
            objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_FM.FPALLET_ID                  'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                            '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[ﾊﾟﾚｯﾄID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '次ﾙｰﾄのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ検索
            '************************
            Dim objSVR_100207 As New SVR_100207(Owner, ObjDb, ObjDbLog)                     '次ﾙｰﾄのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ検索ｸﾗｽ
            objSVR_100207.FPALLET_ID = objTPRG_TRK_BUF_FM.FPALLET_ID                        'ﾊﾟﾚｯﾄID
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
            Dim objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
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
                objSVR_100206.FPALLET_ID = objTPRG_TRK_BUF_FM.FPALLET_ID                'ﾊﾟﾚｯﾄID
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
            'JobMate:N.Dounoshita 2013/09/05 異常ﾋﾞｯﾄ更新


            '****************************************************************************
            '特殊処理11(ﾍﾟｱ入庫搬送の場合、2個の空ﾊﾞｯﾌｧがないと搬送は行わない)
            '****************************************************************************
            intRet = Special11(objTPRG_TRK_BUF_RELAY _
                             , objTPRG_TRK_BUF_FM _
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
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog)                 '在庫移動ｸﾗｽ
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_FM                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_RELAY                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_FM.FPALLET_ID                    'ﾊﾟﾚｯﾄID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SRELAY_START                           'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND                   '作業種別
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_OFF                                   '搬送元ｸﾘｱﾌﾗｸﾞ
            objSVR_100103.STOCK_TRNS()                                                  '移動


            '************************
            'ｽﾃｰｼｮﾝﾏｽﾀの特定
            '************************
            Dim blnMENTE_CANCEL_FLAG As Boolean = False
            Dim objTMST_ST As New TBL_TMST_ST(Owner, ObjDb, ObjDbLog)   'ｽﾃｰｼｮﾝﾏｽﾀｸﾗｽ
            objTMST_ST.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO     'ﾊﾞｯﾌｧ№(ｽﾃｰｼｮﾝ№)
            intRet = objTMST_ST.GET_TMST_ST(False)                      '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                blnMENTE_CANCEL_FLAG = False
            Else
                If TO_INTEGER(objTMST_ST.FMENTE_CANCEL_FLAG) <> FLAG_OFF Then
                    blnMENTE_CANCEL_FLAG = True
                End If
            End If

            objTPRG_TRK_BUF_FM.FRSV_PALLET = mobjTPLN_CARRY_QUE.FPALLET_ID                  '仮引当ﾊﾟﾚｯﾄID
           
            '===============================
            'TO引当有無判定
            '===============================
            If TO_INTEGER(objTMST_ROUTE.FRSV_BUF_TO_FLAG) = FRSV_BUF_TO_FLAG_SRSV Then
                '===============================
                '搬送先ﾊﾞｯﾌｧの更新
                '===============================
                objTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT                               '引当状態
                objTPRG_TRK_BUF_TO.FBUF_IN_DT = Now                                                 'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_TO.FTR_FM = objTPRG_TRK_BUF_FM.FTR_FM                               '搬送FMﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_TO.FTR_TO = objTPRG_TRK_BUF_FM.FTR_TO                               '搬送TOﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_TO.FRSV_PALLET = objTPRG_TRK_BUF_FM.FRSV_PALLET                     '仮引当ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_TO.FRSV_BUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO                     'FM引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_TO.FRSV_ARRAY_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY                'FM引当配列№
                objTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()                                            '更新


                '===============================
                'TO引当有無が「有」の場合、全ﾙｰﾄの引当＆予約を行う
                '===============================
                Call objSVR_100206.RSV_TMST_ROUTE_TO_END()                                      '引当＆予約
            End If




            '******************************************************
            '搬送元/搬送中/搬送先ﾊﾞｯﾌｧの更新
            '******************************************************

            If blnMENTE_CANCEL_FLAG = False Then
                '(ｷｬﾝｾﾙ可否ﾌﾗｸﾞがOFFの場合)

                '===============================
                '搬送中ﾊﾞｯﾌｧの更新
                '===============================
                objTPRG_TRK_BUF_RELAY.FRSV_PALLET = objTPRG_TRK_BUF_FM.FRSV_PALLET                  '仮引当ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_RELAY.FRES_KIND = FRES_KIND_SZAIKO                                   '引当状態
                objTPRG_TRK_BUF_RELAY.FTR_FM = objTPRG_TRK_BUF_FM.FTR_FM                            '搬送FMﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_RELAY.FTR_TO = objTPRG_TRK_BUF_FM.FTR_TO                            '搬送TOﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_RELAY.FTR_IDOU = objTPRG_TRK_BUF_FM.FTR_IDOU                        '搬送TO移動ﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_RELAY.FTRNS_FM = objTPRG_TRK_BUF_FM.FTRNS_ADDRESS                   '搬送指令用FM
                objTPRG_TRK_BUF_RELAY.FTRNS_TO = objTPRG_TRK_BUF_TO.FTRNS_ADDRESS                   '搬送指令用TO
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO                  'FM引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY             'FM引当配列№
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO                  'TO引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY             'TO引当配列№
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_FM.FDISP_ADDRESS_FM        'FM表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_TO.FDISP_ADDRESS           'TO表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_RELAY.FBUF_IN_DT = Now                                              'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_RELAY.UPDATE_TPRG_TRK_BUF()                                         '更新


                '===============================
                '搬送元ﾊﾞｯﾌｧの更新
                '===============================
                objTPRG_TRK_BUF_FM.CLEAR_TPRG_TRK_BUF()                                             '解放


            Else
                '(ｷｬﾝｾﾙ可否ﾌﾗｸﾞがONの場合)

                '===============================
                '搬送元ﾊﾞｯﾌｧの更新
                '===============================
                objTPRG_TRK_BUF_FM.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                        '引当状態
                objTPRG_TRK_BUF_FM.FRSV_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO             'TO引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY        'TO引当配列№
                objTPRG_TRK_BUF_FM.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_FM.GET_ADDRESS_TO     'TO表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_FM.FBUF_IN_DT = Now                                         'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_FM.UPDATE_TPRG_TRK_BUF()                                    '更新


                '===============================
                '搬送中ﾊﾞｯﾌｧの更新
                '===============================
                objTPRG_TRK_BUF_RELAY.FRSV_PALLET = objTPRG_TRK_BUF_FM.FRSV_PALLET                  '仮引当ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_RELAY.FRES_KIND = FRES_KIND_SZAIKO                                   '引当状態
                objTPRG_TRK_BUF_RELAY.FTR_FM = objTPRG_TRK_BUF_FM.FTR_FM                            '搬送FMﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_RELAY.FTR_TO = objTPRG_TRK_BUF_FM.FTR_TO                            '搬送TOﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_RELAY.FTR_IDOU = objTPRG_TRK_BUF_FM.FTR_IDOU                        '搬送TO移動ﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_RELAY.FTRNS_FM = objTPRG_TRK_BUF_FM.FTRNS_ADDRESS                   '搬送指令用FM
                objTPRG_TRK_BUF_RELAY.FTRNS_TO = objTPRG_TRK_BUF_TO.FTRNS_ADDRESS                   '搬送指令用TO
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO                  'FM引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY             'FM引当配列№
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO                  'TO引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY             'TO引当配列№
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_FM.FDISP_ADDRESS_FM        'FM表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_TO.FDISP_ADDRESS           'TO表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_RELAY.FBUF_IN_DT = Now                                              'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_RELAY.UPDATE_TPRG_TRK_BUF()                                         '更新

            End If


            '************************
            '搬送指示QUEの更新
            '************************
            mobjTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND    '搬送指示状況
            mobjTPLN_CARRY_QUE.FUPDATE_DT = Now                             '更新日時
            mobjTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                      '更新


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2012/04/24 搬送指示を送信


            '************************************************
            '生産入庫設定状態       特定(緊急入庫か否かの判断)
            '************************************************
            Dim objXSTS_PRODUCT_IN As New TBL_XSTS_PRODUCT_IN(Owner, ObjDb, ObjDbLog)
            objXSTS_PRODUCT_IN.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objXSTS_PRODUCT_IN.XKINKYU_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO          '緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            intRet = objXSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN(False)                      '取得


            If TO_INTEGER(objTPRG_TRK_BUF_FM.FTR_TO) = FTRK_BUF_NO_J9000 Then
                '(行先が自動倉庫の場合)


                '************************************************
                '搬送指示
                '************************************************
                Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         'ｺﾏﾝﾄﾞID
                objSVR_190001.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID     'ﾊﾟﾚｯﾄID
                objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
                Call objSVR_190001.SendYasukawa_IDTrns(objTPRG_TRK_BUF_RELAY _
                                                     , objTPRG_TRK_BUF_FM _
                                                     , objTPRG_TRK_BUF_TO _
                                                     , mobjTPLN_CARRY_QUE _
                                                     , objTMST_ROUTE _
                                                     )


            ElseIf intRet = RetCode.OK Then
                '(緊急入庫設定の場合)


                '************************************************
                '搬送指示
                '************************************************
                Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         'ｺﾏﾝﾄﾞID
                objSVR_190001.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID     'ﾊﾟﾚｯﾄID
                objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
                Call objSVR_190001.SendYasukawa_IDKinkyuTrns(objTPRG_TRK_BUF_RELAY _
                                                           , objTPRG_TRK_BUF_FM _
                                                           , objTPRG_TRK_BUF_TO _
                                                           , mobjTPLN_CARRY_QUE _
                                                           , objTMST_ROUTE _
                                                           )


            End If


            '↑↑↑↑↑↑************************************************************************************************************


            '========================
            '指示送信待ち理由のｸﾘｱ
            '========================
            objTSTS_HIKIATE.FWAIT_REASON = DEFAULT_STRING
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/03/22 特殊処理


            ''**************************************
            ''特殊処理01(要求状態更新)
            ''**************************************
            'Call Special01(objTPRG_TRK_BUF_RELAY _
            '             , objTPRG_TRK_BUF_FM _
            '             , objTPRG_TRK_BUF_TO _
            '             , objTSTS_HIKIATE _
            '             )


            '****************************************************************************
            '特殊処理02(生産入庫設定状態の実績数量ｶｳﾝﾄｱｯﾌﾟ)
            '****************************************************************************
            Call Special02(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_FM _
                         , objTPRG_TRK_BUF_TO _
                         , objTSTS_HIKIATE _
                         )


            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '正常完了
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & _
                                "  [ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & _
                                "  ,搬送元:" & objTPRG_TRK_BUF_FM.FDISP_ADDRESS & _
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
#Region "  特殊処理01(要求状態更新)                                                             "
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
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        ''************************************************
        ''ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ            取得
        ''************************************************
        'Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        'objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        'objTMST_TRK.GET_TMST_TRK()                                      '取得


        ''************************************************
        ''ﾁｪｯｸ
        ''************************************************
        'If IsNull(objTMST_TRK.XEQ_ID_IN_FR) Or IsNull(objTMST_TRK.XEQ_ID_IN_BK) Then
        '    Return RetCode.OK
        'End If


        ''************************************************
        ''設備状況                   更新
        ''************************************************
        'Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_IN_FR, FEQ_REQ_STS_JIN_TRNS_SIZI_ON)
        'Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_IN_BK, FEQ_REQ_STS_JIN_TRNS_SIZI_ON)
        'If IsNotNull(objTMST_TRK.XEQ_ID_HASU_FR) Then Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_HASU_FR, FEQ_REQ_STS_JIN_TRNS_SIZI_ON)
        'If IsNotNull(objTMST_TRK.XEQ_ID_HASU_BK) Then Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_HASU_BK, FEQ_REQ_STS_JIN_TRNS_SIZI_ON)


        Return intReturn
    End Function
#End Region
#Region "  特殊処理02(生産入庫設定状態の実績数量ｶｳﾝﾄｱｯﾌﾟ)                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理02(生産入庫設定状態の実績数量ｶｳﾝﾄｱｯﾌﾟ)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">搬送中ﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FMﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TOﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTSTS_HIKIATE">在庫引当情報</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special02(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '************************************************
        'ﾁｪｯｸ
        '************************************************
        If TO_INTEGER(objTPRG_TRK_BUF_FM.FTR_TO) <> FTRK_BUF_NO_J9000 Then
            Return intReturn
        End If


        '************************************************
        '在庫情報                   取得
        '************************************************
        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
        objTRST_STOCK.FPALLET_ID = objTSTS_HIKIATE.FPALLET_ID           'ﾊﾟﾚｯﾄID
        objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)                       '取得


        '*****************************************************
        '生産入庫設定状態           追加
        '*****************************************************
        If IsNotNull(objTRST_STOCK.ARYME(0).FST_FM) Then
            '(搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№がｾｯﾄされていた場合)

            Dim objXSTS_PRODUCT_IN As New TBL_XSTS_PRODUCT_IN(Owner, ObjDb, ObjDbLog)
            objXSTS_PRODUCT_IN.FTRK_BUF_NO = objTRST_STOCK.ARYME(0).FST_FM              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objXSTS_PRODUCT_IN.XPROD_LINE = objTRST_STOCK.ARYME(0).XPROD_LINE           '生産ﾗｲﾝ№
            objXSTS_PRODUCT_IN.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD           '品目ｺｰﾄﾞ
            objXSTS_PRODUCT_IN.FIN_KUBUN = objTRST_STOCK.ARYME(0).FIN_KUBUN             '入庫区分
            objXSTS_PRODUCT_IN.FHORYU_KUBUN = objTRST_STOCK.ARYME(0).FHORYU_KUBUN       '保留区分
            objXSTS_PRODUCT_IN.XKENSA_KUBUN = objTRST_STOCK.ARYME(0).XKENSA_KUBUN       '検査区分
            objXSTS_PRODUCT_IN.XKENPIN_KUBUN = objTRST_STOCK.ARYME(0).XKENPIN_KUBUN     '検品区分
            objXSTS_PRODUCT_IN.XMAKER_CD = objTRST_STOCK.ARYME(0).XMAKER_CD             'ﾒｰｶ-ｺｰﾄﾞ
            intRet = objXSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN(False)                      '取得
            If intRet = RetCode.OK Then
                '(見つかった場合)

                objXSTS_PRODUCT_IN.XRESULT_NUM = TO_INTEGER(objXSTS_PRODUCT_IN.XRESULT_NUM) + 1     '実績数量
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
                objXSTS_PRODUCT_IN.XRESULT_NUM_CASE = TO_INTEGER(objXSTS_PRODUCT_IN.XRESULT_NUM_CASE) + objTRST_STOCK.ARYME(0).FTR_VOL  '実績数量(梱数)
                'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
                '↑↑↑↑↑↑************************************************************************************************************
                objXSTS_PRODUCT_IN.UPDATE_XSTS_PRODUCT_IN()                                         '更新

            End If

        End If


        Return intReturn
    End Function
#End Region

#Region "  特殊処理11(ﾍﾟｱ入庫搬送の場合、2個の空ﾊﾞｯﾌｧがないと搬送は行わない)                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理11(ﾍﾟｱ入庫搬送の場合、2個の空ﾊﾞｯﾌｧがないと搬送は行わない)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">搬送中ﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FMﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TOﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTSTS_HIKIATE">在庫引当情報</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special11(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             ) _
                             As RetCode
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '************************************************
        'ﾁｪｯｸ
        '************************************************
        'NOP


        '************************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(TO)空ﾊﾞｯﾌｧ数      取得
        '************************************************
        Dim intCountAkiTo As Integer = 0        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(TO)空ﾊﾞｯﾌｧ数
        Dim objTPRG_TRK_BUF_CountTo As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        objTPRG_TRK_BUF_CountTo.FTRK_BUF_NO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTPRG_TRK_BUF_CountTo.WHERE = "   AND FRES_KIND = 0 AND FRSV_PALLET IS NULL AND FPALLET_ID IS NULL "        '空ﾊﾞｯﾌｧ条件
        intCountAkiTo = objTPRG_TRK_BUF_CountTo.GET_TPRG_TRK_BUF_COUNT()              '取得


        '************************************************
        '
        '************************************************
        If intCountAkiTo <= 1 Then
            '(Toの空きが1個以下しかない場合)

            If IsNotNull(mobjTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                '(ﾍﾟｱ搬送の場合)

                If mobjTPLN_CARRY_QUE.XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA Then
                    '(親の場合)

                    objTSTS_HIKIATE.FWAIT_REASON = "搬送先ﾊﾞｯﾌｧの空ﾊﾞｯﾌｧ待ち。(親)[搬送先:" & objTPRG_TRK_BUF_TO.FDISP_ADDRESS & "][ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_TO.FTRK_BUF_NO) & "]"
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                Else
                    '(子の場合)


                    '************************************************
                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(相方)         取得
                    '************************************************
                    Dim objTPRG_TRK_BUF_AITE As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    objTPRG_TRK_BUF_AITE.FPALLET_ID = mobjTPLN_CARRY_QUE.XPALLET_ID_AITE        'ﾊﾟﾚｯﾄID
                    objTPRG_TRK_BUF_AITE.GET_TPRG_TRK_BUF()                                     '取得
                    If objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO <> objTPRG_TRK_BUF_AITE.FTRK_BUF_NO Then
                        '(相方がまだ搬送中じゃなかった場合)

                        objTSTS_HIKIATE.FWAIT_REASON = "搬送先ﾊﾞｯﾌｧの空ﾊﾞｯﾌｧ待ち。(子)[搬送先:" & objTPRG_TRK_BUF_TO.FDISP_ADDRESS & "][ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_TO.FTRK_BUF_NO) & "]"
                        objTSTS_HIKIATE.FUPDATE_DT = Now
                        objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                        Return RetCode.NotEnough
                    End If


                End If

            End If

        End If


        Return intReturn
    End Function
#End Region

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
