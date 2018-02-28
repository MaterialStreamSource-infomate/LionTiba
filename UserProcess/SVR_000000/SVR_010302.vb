'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】搬送完了処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_010302
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ｸﾗｽ変数定義                                                                          "
    Private mFPALLET_ID As String                 'ﾊﾟﾚｯﾄID
    Private mFINOUT_STS As Nullable(Of Integer)   'IN/OUT
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
    ''' =======================================
    ''' <summary>ﾊﾟﾚｯﾄID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FPALLET_ID() As String
        Get
            Return mFPALLET_ID
        End Get
        Set(ByVal Value As String)
            mFPALLET_ID = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>IN/OUT</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FINOUT_STS() As Nullable(Of Integer)
        Get
            Return mFINOUT_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFINOUT_STS = Value
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
#Region "  ﾒｲﾝ処理(関数)                                                                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理(関数)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ExecCmdFunction()
        Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try

            '************************
            '初期処理
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If 1 <> 1 Then
            ElseIf IsNull(mFPALLET_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFINOUT_STS) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[IN/OUT]"
                Throw New UserException(strMsg)
            End If


            '定周期管理
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)                 '定周期管理ｸﾗｽ

            '在庫状態
            Dim intRES_KIND As Integer

            '次搬送区分
            Dim intCARRYQUE_KUBUN As Integer

            'ｸﾚｰﾝID
            Dim strEQ_ID_CRANE_TO As String = FEQ_ID_SKOTEI

            '************************
            '搬送指示QUEの特定
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)         '搬送指示QUE
            objTPLN_CARRY_QUE.FPALLET_ID = mFPALLET_ID                                      'ﾊﾟﾚｯﾄID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(True)                             '特定


            '************************
            '搬送中ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = mFPALLET_ID                                  'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                           '特定
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/05/30 特殊処理
            Dim intFTR_IDOU As Nullable(Of Integer) = objTPRG_TRK_BUF_RELAY.FTR_IDOU        '搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '搬送元ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            If TO_INTEGER(objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM) <> 0 And _
               TO_INTEGER(objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM) <> 0 Then
                objTPRG_TRK_BUF_FM.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM          'ﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM     '配列№
                intRet = objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF(True)                          '特定
            End If


            '************************
            '搬送先ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_TO.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO          'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO     '配列№
            intRet = objTPRG_TRK_BUF_TO.GET_TPRG_TRK_BUF(True)                          '特定
            If objTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SZAIKO Or _
               objTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Then
                If objTPRG_TRK_BUF_TO.FRSV_PALLET <> objTPRG_TRK_BUF_RELAY.FPALLET_ID Then
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_TO.FTRK_BUF_NO) & "  ,ﾊﾞｯﾌｧ配列№:" & TO_STRING(objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY) & "]"
                    Throw New UserException(strMsg)
                End If
            End If


            '************************
            '搬送ﾙｰﾄﾏｽﾀの特定
            '************************
            Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)     '搬送ﾙｰﾄﾏｽﾀ
            objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_RELAY.FTR_FM                '元ﾊﾞｯﾌｧ№
            objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_RELAY.FTR_TO                '先ﾊﾞｯﾌｧ№
            objTMST_ROUTE.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                       '元ｸﾚｰﾝ設備ID
            objTMST_ROUTE.FEQ_ID_CRANE_TO = objTPLN_CARRY_QUE.FEQ_ID            '先ｸﾚｰﾝ設備ID
            intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                         '特定


            '************************
            '在庫引当情報の特定
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '在庫引当情報ｸﾗｽ
            objTSTS_HIKIATE.FPALLET_ID = mFPALLET_ID                            'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                    '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[ﾊﾟﾚｯﾄID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '在庫移動
            '************************
            Dim objSVR_100103_ST As New SVR_100103(Owner, ObjDb, ObjDbLog)      '在庫移動ｸﾗｽ
            objSVR_100103_ST.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(搬送中ﾊﾞｯﾌｧ)
            objSVR_100103_ST.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_TO            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(搬送先ﾊﾞｯﾌｧ)
            objSVR_100103_ST.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID      'ﾊﾟﾚｯﾄID
            objSVR_100103_ST.FINOUT_STS = mFINOUT_STS                           'INOUT
            objSVR_100103_ST.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND        '作業種別(再検入庫)
            objSVR_100103_ST.INTCLEAR_FM_FLAG = FLAG_OFF                        '搬送元ｸﾘｱﾌﾗｸﾞ
            objSVR_100103_ST.STOCK_TRNS()                                       '移動


            '********************************
            '搬送元/搬送中/搬送先ﾊﾞｯﾌｧの更新
            '********************************
            '
            '===========================
            '搬送先ﾊﾞｯﾌｧの更新
            '===========================
            If TO_INTEGER(objTMST_ROUTE.FBUF_TO) = TO_INTEGER(objTMST_ROUTE.FBUF_NEXT) Or _
               TO_INTEGER(objTMST_ROUTE.FBUF_RELAY) = 0 Or _
               TO_INTEGER(objTMST_ROUTE.FBUF_NEXT) = 0 Then
                '(最終の場合)
                objTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SZAIKO                              '引当状態
                objTPRG_TRK_BUF_TO.FRSV_PALLET = DEFAULT_STRING                             '仮引当ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_TO.FTR_FM = DEFAULT_INTEGER                                 '搬送FMﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_TO.FTR_TO = DEFAULT_INTEGER                                 '搬送TOﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_TO.FTR_IDOU = DEFAULT_INTEGER                               '搬送TO移動ﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_TO.FTRNS_FM = DEFAULT_STRING                                '搬送指令用FM
                objTPRG_TRK_BUF_TO.FTRNS_TO = DEFAULT_STRING                                '搬送指令用TO
                objTPRG_TRK_BUF_TO.FRSV_BUF_FM = DEFAULT_INTEGER                            'FM引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_TO.FRSV_ARRAY_FM = DEFAULT_INTEGER                          'FM引当配列№
                objTPRG_TRK_BUF_TO.FRSV_BUF_TO = DEFAULT_INTEGER                            'TO引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_TO.FRSV_ARRAY_TO = DEFAULT_INTEGER                          'TO引当配列№
                objTPRG_TRK_BUF_TO.FDISP_ADDRESS_FM = DEFAULT_STRING                        'FM表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_TO.FDISP_ADDRESS_TO = DEFAULT_STRING                        'TO表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_TO.FBUF_IN_DT = Now                                         'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()                                    '更新

                '************************
                '在庫情報の更新
                '************************
            Else
                '(中継の場合)
                '************************
                '搬送元ｸﾚｰﾝ設備IDの特定
                '************************
                Dim intRSV_BUF_TO As Nullable(Of Integer) = DEFAULT_INTEGER                 'TO引当ﾄﾗｯｷﾝｸﾞ№
                Dim intRSV_ARRAY_TO As Nullable(Of Integer) = DEFAULT_INTEGER               'TO引当配列№
                Dim strDISP_ADDRESS_TO As String = DEFAULT_STRING                           'TO表記用ｱﾄﾞﾚｽ

                '************************
                '最終到達ﾊﾞｯﾌｧの特定
                '************************
                Dim objTPRG_TRK_BUF_END As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
                objTPRG_TRK_BUF_END.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FTR_TO             '自動倉庫ﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_END.FRSV_PALLET = mFPALLET_ID                              '仮引当ﾊﾟﾚｯﾄID
                intRet = objTPRG_TRK_BUF_END.GET_TPRG_TRK_BUF_RSV_PALLET()
                If intRet = RetCode.OK Then
                    '************************
                    '最終到達ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
                    '************************
                    Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀｸﾗｽ
                    objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FTR_TO                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
                    intRet = objTMST_TRK.GET_TMST_TRK(True)                                 '特定

                    If TO_INTEGER(objTMST_TRK.FBUF_KIND) = FBUF_KIND_SASRS Then
                        '************************
                        'ｸﾚｰﾝﾏｽﾀの特定
                        '************************
                        Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)     'ｸﾚｰﾝﾏｽﾀｸﾗｽ
                        objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_END.FTRK_BUF_NO         'ﾊﾞｯﾌｧ№
                        objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_END.FRAC_RETU          '列
                        intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                           '特定
                        If intRet = RetCode.NotFound Then
                            '(見つからない場合)
                            strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                            Throw New UserException(strMsg)
                        End If

                        'ｸﾚｰﾝ設備IDの特定
                        strEQ_ID_CRANE_TO = objTMST_CRANE.FEQ_ID
                    End If

                    intRSV_BUF_TO = objTPRG_TRK_BUF_END.FTRK_BUF_NO                         'TO引当ﾄﾗｯｷﾝｸﾞ№
                    intRSV_ARRAY_TO = objTPRG_TRK_BUF_END.FTRK_BUF_ARRAY                    'TO引当配列№
                    strDISP_ADDRESS_TO = objTPRG_TRK_BUF_END.FDISP_ADDRESS                  'TO表記用ｱﾄﾞﾚｽ
                End If


                '************************
                '搬送ﾙｰﾄﾏｽﾀの特定
                '************************
                Dim objTMST_ROUTE_NEXT As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)        '搬送ﾙｰﾄﾏｽﾀ
                objTMST_ROUTE_NEXT.FBUF_FM = objTPRG_TRK_BUF_TO.FTRK_BUF_NO                 '元ﾊﾞｯﾌｧ№
                objTMST_ROUTE_NEXT.FBUF_TO = objTPRG_TRK_BUF_RELAY.FTR_TO                   '先ﾊﾞｯﾌｧ№
                objTMST_ROUTE_NEXT.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                          '元ｸﾚｰﾝ設備ID
                objTMST_ROUTE_NEXT.FEQ_ID_CRANE_TO = strEQ_ID_CRANE_TO                      '先ｸﾚｰﾝ設備ID
                intRet = objTMST_ROUTE_NEXT.GET_TMST_ROUTE(True)                            '特定

                '引当状態
                Select Case TO_INTEGER(objTMST_ROUTE_NEXT.FCARRYQUE_KUBUN)
                    Case FCARRYQUE_KUBUN_SIN                                 '入庫
                        '引当状態
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '搬出予約

                        '次搬送区分
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SIN              '入庫

                        '次処理起動
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動(搬送引当処理)

                    Case FCARRYQUE_KUBUN_SOUT                                '出庫
                        '引当状態
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '搬出予約

                        '次搬送区分
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SOUT             '出庫

                        '次処理起動
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動(搬送引当処理)

                    Case FCARRYQUE_KUBUN_STANA_MOVE                          '棚間搬送
                        '引当状態
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '搬出予約

                        '次搬送区分
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SIN              '入庫

                        '次処理起動
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動(搬送引当処理)

                    Case FCARRYQUE_KUBUN_SMOVE                               '搬送
                        '引当状態
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '搬出予約

                        '次搬送区分
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SMOVE            '搬送

                        '次処理起動
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動(搬送引当処理)

                    Case FCARRYQUE_KUBUN_SBUNKI                              '分岐
                        '引当状態
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '搬出予約

                        '次搬送区分
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SMOVE            '搬送

                        '次処理起動
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動(搬送引当処理)

                    Case Else                                               'その他
                        '引当状態
                        intRES_KIND = FRES_KIND_SZAIKO                                       '在庫棚

                        '次搬送区分
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SMOVE            '搬送

                        '次処理起動
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動(搬送引当処理)

                End Select

                objTPRG_TRK_BUF_TO.FRSV_PALLET = objTPRG_TRK_BUF_TO.FPALLET_ID                  '仮引当ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_TO.FRES_KIND = intRES_KIND                                      '引当状態
                objTPRG_TRK_BUF_TO.FTR_FM = objTPRG_TRK_BUF_TO.FTRK_BUF_NO                      '搬送FMﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_TO.FTR_TO = objTPRG_TRK_BUF_RELAY.FTR_TO                        '搬送TOﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_TO.FTR_IDOU = DEFAULT_INTEGER                                   '搬送TO移動ﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_TO.FTRNS_FM = DEFAULT_STRING                                    '搬送指令用FM
                objTPRG_TRK_BUF_TO.FTRNS_TO = DEFAULT_STRING                                    '搬送指令用TO
                objTPRG_TRK_BUF_TO.FRSV_BUF_FM = objTPRG_TRK_BUF_TO.FTRK_BUF_NO                 'FM引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_TO.FRSV_ARRAY_FM = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY            'FM引当配列№
                objTPRG_TRK_BUF_TO.FRSV_BUF_TO = intRSV_BUF_TO                                  'TO引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_TO.FRSV_ARRAY_TO = intRSV_ARRAY_TO                              'TO引当配列№
                objTPRG_TRK_BUF_TO.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO    'FM表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_TO.FDISP_ADDRESS_TO = strDISP_ADDRESS_TO                        'TO表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_TO.FBUF_IN_DT = Now                                             'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()                                        '更新

            End If


            '===========================
            '搬送元ﾊﾞｯﾌｧの更新
            '===========================
            If (objTPRG_TRK_BUF_FM Is Nothing) = False Then
                If objTPRG_TRK_BUF_FM.FRSV_PALLET = mFPALLET_ID Then
                    objTPRG_TRK_BUF_FM.CLEAR_TPRG_TRK_BUF()     '解放
                End If
            End If

            '===========================
            '搬送中ﾊﾞｯﾌｧの更新
            '===========================
            objTPRG_TRK_BUF_RELAY.CLEAR_TPRG_TRK_BUF()          '解放


            '************************
            '搬送指示QUEの削除
            '************************
            objTPLN_CARRY_QUE.DELETE_TPLN_CARRY_QUE_PALLET()                            '削除

            '************************
            '搬送指示QUEの再登録
            '(搬送指示のみ、入庫指示は入庫引当処理にて実行)
            '************************
            If intRES_KIND = FRES_KIND_SRSV_TRNS_OUT Then
                '************************
                '優先ﾚﾍﾞﾙ
                '************************
                Dim intFPRIORITY As Integer                                             '優先ﾚﾍﾞﾙ
                Dim objTMST_SAGYO As New TBL_TMST_SAGYO(Owner, ObjDb, ObjDbLog)         '作業種別毎制御情報
                objTMST_SAGYO.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND               '作業種別
                objTMST_SAGYO.FEQ_ID = FEQ_ID_SKOTEI                                    '設備ID
                objTMST_SAGYO.GET_TMST_SAGYO(False)                                     '取得
                intFPRIORITY = TO_INTEGER(objTMST_SAGYO.FPRIORITY)
                If intFPRIORITY < FPRIORITY_SLOW Then intFPRIORITY = FPRIORITY_SLOW

                '************************
                '搬送指示QUE登録
                '************************
                objTPLN_CARRY_QUE.FCARRYQUE_D = Now                                     '搬送指示日
                objTPLN_CARRY_QUE.FEQ_ID = strEQ_ID_CRANE_TO                            '設備ID
                objTPLN_CARRY_QUE.FPRIORITY = intFPRIORITY                              'ﾌﾟﾗｲｵﾘﾃｨ区分
                objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_TO.FPALLET_ID            'ﾊﾟﾚｯﾄID
                objTPLN_CARRY_QUE.FCARRYQUE_KUBUN = intCARRYQUE_KUBUN                   '搬送区分
                objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON             '搬送指示状況(未指示)
                objTPLN_CARRY_QUE.FENTRY_DT = Now                                       '登録日時
                objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '更新日時
                objTPLN_CARRY_QUE.ADD_TPLN_CARRY_QUE_ORDER()                            '登録
            End If


            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2011/10/05 完了後にも色々来るので削除しない

            '************************
            'ｼﾘｱﾙ関連付けの削除
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)   'ｼﾘｱﾙ関連付けｸﾗｽ
            objTPRG_SERIAL.FPALLET_ID = mFPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                 '削除

            '↑↑↑↑↑↑************************************************************************************************************


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/08 特殊処理


            '****************************************************************************
            '特殊処理21(出荷指示、出荷指示詳細ﾃｰﾌﾞﾙ更新)
            '****************************************************************************
            Call Special21(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_FM _
                         , objTPRG_TRK_BUF_TO _
                         , objTSTS_HIKIATE _
                         , objTPLN_CARRY_QUE _
                         )


            '****************************************************************************
            '特殊処理02(包材出庫時の実績数量更新)
            '****************************************************************************
            Call Special02(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_FM _
                         , objTPRG_TRK_BUF_TO _
                         , objTSTS_HIKIATE _
                         , objTPLN_CARRY_QUE _
                         )


            '****************************************************************************
            '特殊処理01(出庫搬送完了時の在庫削除処理)
            '****************************************************************************
            Call Special01(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_FM _
                         , objTPRG_TRK_BUF_TO _
                         , objTSTS_HIKIATE _
                         , objTPLN_CARRY_QUE _
                         , intFTR_IDOU _
                         )


            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '次処理起動
            '************************
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/06/18 特殊処理
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_J310304)                            '起動
            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '正常完了
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & _
                                "  [ﾊﾟﾚｯﾄID:" & mFPALLET_ID & _
                                "]")

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
#Region "  特殊処理01(出庫搬送完了時の在庫削除処理or平置移動処理)                                                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理01(出庫搬送完了時の在庫削除処理)
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
                             , ByVal objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE _
                             , ByVal intFTR_IDOU As Nullable(Of Integer) _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        Dim strMsg As String
        Dim strMsg01 As String
        Dim strMsg02 As String
        Dim intReturn As RetCode = RetCode.OK


        '***********************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ(TO)
        '***********************************************
        Dim objTMST_TRK_TO As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        objTMST_TRK_TO.FTRK_BUF_NO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTMST_TRK_TO.GET_TMST_TRK()                                  '取得
        If IsNotNull(objTMST_TRK_TO.XEQ_ID_OUT_END) Or objTMST_TRK_TO.FTRK_BUF_NO = FTRK_BUF_NO_J2062 Or objTMST_TRK_TO.FTRK_BUF_NO = FTRK_BUF_NO_J2061 Then
            '(出庫搬送完了時の場合)
            '(D41、D42は、例外的に違う条件で出庫搬送完了を行っているので、判定は別に行う)


            If IsNull(intFTR_IDOU) Then
                '(最終の場合)


                '*********************************************
                'ﾄﾗｯｷﾝｸﾞ削除判定
                '*********************************************
                Dim blnDelete As Boolean = False        'ﾄﾗｯｷﾝｸﾞ削除ﾌﾗｸﾞ
                Select Case objTSTS_HIKIATE.FSAGYOU_KIND
                    Case FSAGYOU_KIND_J55, FSAGYOU_KIND_J56, FSAGYOU_KIND_J57

                        '===================================
                        '出荷指示詳細
                        '===================================
                        Dim objXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
                        objXPLN_OUT_DTL.FPLAN_KEY = objTSTS_HIKIATE.FPLAN_KEY       '計画ｷｰ
                        intRet = objXPLN_OUT_DTL.GET_XPLN_OUT_DTL(False)            '取得
                        If intRet = RetCode.OK Then
                            '(見つかった場合)
                            If objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JTUMI Then
                                '(積込済の場合)
                                blnDelete = True
                                strMsg01 = "積込完了したﾄﾗｯｷﾝｸﾞが出庫完了された為、強制的にﾄﾗｯｷﾝｸﾞを削除しました。在庫ﾒﾝﾃﾅﾝｽで平置き在庫が実在庫と合うように調整して下さい。"
                                strMsg02 = "[品目ｺｰﾄﾞ:" & objXPLN_OUT_DTL.FHINMEI_CD & "]"
                                strMsg02 &= "[出荷日:" & objXPLN_OUT_DTL.XSYUKKA_D & "]"
                                strMsg02 &= "[編成№:" & objXPLN_OUT_DTL.XHENSEI_NO & "]"
                                strMsg02 &= "[伝票№:" & objXPLN_OUT_DTL.XDENPYOU_NO & "]"
                                strMsg02 &= "[ﾊﾟﾚｯﾄID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                                Call AddToMsgLog(Now, FMSG_ID_J4001, strMsg01, strMsg02)
                                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & strMsg01 & strMsg02)
                            End If
                        Else
                            '(見つからない場合場合)
                            blnDelete = True
                        End If

                    Case Else
                        blnDelete = True
                End Select
                If blnDelete = True Then
                    '(ﾄﾗｯｷﾝｸﾞ削除の場合)


                    '************************************************************************
                    'ﾄﾗｯｷﾝｸﾞ,在庫情報,その他ﾊﾟﾚｯﾄに関係する情報全て削除
                    '************************************************************************
                    Call ClearDustProcess(objTPRG_TRK_BUF_TO.FPALLET_ID)


                    '************************
                    '在庫削除
                    '************************
                    Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '在庫削除ｸﾗｽ
                    objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_TO          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                    objSVR_100102.FPALLET_ID = objTPRG_TRK_BUF_TO.FPALLET_ID    'ﾊﾟﾚｯﾄID
                    'objSVR_100102.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK   '在庫ﾛｯﾄ№
                    objSVR_100102.FINOUT_STS = mFINOUT_STS                      'INOUT
                    objSVR_100102.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '作業種別
                    objSVR_100102.STOCK_DELETE()                                '削除


                End If


            Else
                '(倉替えの場合)


                '************************************************
                '在庫情報           更新
                '************************************************
                Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                objTRST_STOCK.FPALLET_ID = objTPRG_TRK_BUF_TO.FPALLET_ID    'ﾊﾟﾚｯﾄID
                objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)                   '取得
                For ii As Integer = 0 To UBound(objTRST_STOCK.ARYME)
                    '(ﾙｰﾌﾟ:在庫ﾛｯﾄ№数)

                    If objTSTS_HIKIATE.FSAGYOU_KIND = FSAGYOU_KIND_J73 Or objTSTS_HIKIATE.FSAGYOU_KIND = FSAGYOU_KIND_J74 Then
                        '(倉替の場合)
                        objTRST_STOCK.ARYME(ii).FTR_RES_VOL = 0                                                             '搬送引当量
                    Else
                        '(出荷の場合)
                        objTRST_STOCK.ARYME(ii).FTR_RES_VOL = objTRST_STOCK.ARYME(ii).FTR_VOL - objTSTS_HIKIATE.FTR_VOL     '搬送引当量
                    End If
                    objTRST_STOCK.ARYME(ii).FUPDATE_DT = Now            '更新日時
                    objTRST_STOCK.ARYME(ii).UPDATE_TRST_STOCK_ALL()     '更新

                Next


                '************************************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(平置)         取得
                '************************************************
                Dim objTPRG_TRK_BUF_HIRA As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_HIRA.FTRK_BUF_NO = intFTR_IDOU                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                intRet = objTPRG_TRK_BUF_HIRA.GET_TPRG_TRK_BUF_AKI_HIRA()       '取得
                If intRet <> RetCode.OK Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_HIRA.FTRK_BUF_NO) & "]"
                    Throw New UserException(strMsg)
                End If


                '************************
                '在庫移動
                '************************
                Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog)         '在庫移動ｸﾗｽ
                objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_TO               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_HIRA             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_TO.FPALLET_ID            'ﾊﾟﾚｯﾄID
                objSVR_100103.FINOUT_STS = mFINOUT_STS                              'INOUT
                objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND           '作業種別
                objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                            '搬送元ｸﾘｱﾌﾗｸﾞ
                objSVR_100103.STOCK_TRNS()                                          '移動


                '************************************************************************
                'ﾄﾗｯｷﾝｸﾞ,在庫情報,その他ﾊﾟﾚｯﾄに関係する情報全て削除
                '************************************************************************
                Call ClearDustProcess(objTPRG_TRK_BUF_HIRA.FPALLET_ID)


            End If


        End If


        Return intReturn
    End Function
#End Region
#Region "  特殊処理02(包材出庫時、緊急入庫設定時の実績数量更新)                                                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理02(包材出庫時、緊急入庫設定時の実績数量更新)
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
                             , ByVal objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '***********************************************
        '在庫情報                   取得
        '***********************************************
        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
        objTRST_STOCK.FPALLET_ID = objTSTS_HIKIATE.FPALLET_ID   'ﾊﾟﾚｯﾄID
        objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)               '取得


        ''***********************************************
        ''包材出庫設定状態           取得
        ''***********************************************
        'Dim objXSTS_WRAPPING_MATERIAL As New TBL_XSTS_WRAPPING_MATERIAL(Owner, ObjDb, ObjDbLog)
        'objXSTS_WRAPPING_MATERIAL.FTRK_BUF_NO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        'intRet = objXSTS_WRAPPING_MATERIAL.GET_XSTS_WRAPPING_MATERIAL(False)        '取得
        'If intRet = RetCode.OK Then
        '    '(見つかった場合)


        '    '***********************************************
        '    '包材出庫設定状態           更新
        '    '***********************************************
        '    objXSTS_WRAPPING_MATERIAL.XRESULT_NUM = TO_INTEGER(objXSTS_WRAPPING_MATERIAL.XRESULT_NUM) + 1       '実績数量
        '    objXSTS_WRAPPING_MATERIAL.UPDATE_XSTS_WRAPPING_MATERIAL()       '更新


        'End If


        '***********************************************
        '包材出庫設定状態               取得
        '***********************************************
        Dim objXSTS_WRAPPING_MATERIAL As New TBL_XSTS_WRAPPING_MATERIAL(Owner, ObjDb, ObjDbLog)
        objXSTS_WRAPPING_MATERIAL.FTRK_BUF_NO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objXSTS_WRAPPING_MATERIAL.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD    '品目ｺｰﾄﾞ
        intRet = objXSTS_WRAPPING_MATERIAL.GET_XSTS_WRAPPING_MATERIAL(False)        '取得
        If intRet = RetCode.OK Then
            '(見つかった場合)
            If 0 <= objXSTS_WRAPPING_MATERIAL.XPLAN_NUM Then
                '(空PL出庫以外の場合)


                '***********************************************
                '包材出庫設定状態               更新
                '***********************************************
                objXSTS_WRAPPING_MATERIAL.XRESULT_NUM = TO_INTEGER(objXSTS_WRAPPING_MATERIAL.XRESULT_NUM) + 1       '実績数量
                objXSTS_WRAPPING_MATERIAL.UPDATE_XSTS_WRAPPING_MATERIAL()                                           '更新

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2013/10/29 包材出庫登録 計画満了時のﾒｯｾｰｼﾞ出力
                If objXSTS_WRAPPING_MATERIAL.XRESULT_NUM >= objXSTS_WRAPPING_MATERIAL.XPLAN_NUM Then
                    '************************************************
                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ            取得
                    '************************************************
                    Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                    objTMST_TRK.FTRK_BUF_NO = objXSTS_WRAPPING_MATERIAL.FTRK_BUF_NO 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTMST_TRK.GET_TMST_TRK()                                      '取得

                    Dim strMsg01 As String
                    strMsg01 = "ｽﾃｰｼｮﾝ:[" & objTMST_TRK.FBUF_NAME & "]"
                    Call AddToMsgLog(Now, FMSG_ID_J4003, strMsg01)
                End If
                'JobMate:S.Ouchi 2013/10/29 包材出庫登録 計画満了時のﾒｯｾｰｼﾞ出力
                '↑↑↑↑↑↑************************************************************************************************************
            End If
        End If


        '↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        '’D45の搬送完了特殊処理は不要？
        '***********************************************
        '包材出庫設定状態(D45)          取得
        '***********************************************
        ''Dim objXSTS_WRAPPING_MATERIAL_D45 As New TBL_XSTS_WRAPPING_MATERIAL_D45(Owner, ObjDb, ObjDbLog)
        ''objXSTS_WRAPPING_MATERIAL_D45.FPLAN_KEY = objTSTS_HIKIATE.FPLAN_KEY             '計画ｷｰ
        ''intRet = objXSTS_WRAPPING_MATERIAL_D45.GET_XSTS_WRAPPING_MATERIAL_D45(False)    '取得
        ''If intRet = RetCode.OK Then
        ''    '(見つかった場合)


        ''    '***********************************************
        ''    '包材出庫設定状態(D45)          更新
        ''    '***********************************************
        ''    objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM = TO_INTEGER(objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM) + 1               '実績数量
        ''    objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM_SUM = TO_INTEGER(objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM_SUM) + 1       '実績数量(合計)
        ''    If objXSTS_WRAPPING_MATERIAL_D45.XPLAN_NUM <= objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM Then
        ''        '(計画数量 <= 実績数量 の場合)

        ''        '======================================
        ''        '実績数量           ﾘｾｯﾄ
        ''        '======================================
        ''        objXSTS_WRAPPING_MATERIAL_D45.XPLAN_NUM = 0             '計画数量
        ''        objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM = 0           '実績数量

        ''        '======================================
        ''        'D45生産ﾗｲﾝXX要求枚数       ﾘｾｯﾄ
        ''        '======================================
        ''        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
        ''        Call objSVR_190001.SendYasukawaMelsec_IDMainteWord(objXSTS_WRAPPING_MATERIAL_D45.FEQ_ID, FTEXT_ID_JW_ETC, 0)

        ''        '↓↓↓↓↓↓************************************************************************************************************
        ''        'JobMate:S.Ouchi 2013/12/02 包材出庫登録 計画満了時のﾒｯｾｰｼﾞ出力 削除
        ''        ' '' ''↓↓↓↓↓↓************************************************************************************************************
        ''        ' '' ''JobMate:S.Ouchi 2013/10/29 包材出庫登録 計画満了時のﾒｯｾｰｼﾞ出力
        ''        ' '' ''************************************************
        ''        ' '' ''ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ            取得
        ''        ' '' ''************************************************
        ''        '' ''Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        ''        '' ''objTMST_TRK.FTRK_BUF_NO = objXSTS_WRAPPING_MATERIAL_D45.FTRK_BUF_NO 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        ''        '' ''objTMST_TRK.GET_TMST_TRK()                                          '取得

        ''        ' '' ''**************************************
        ''        ' '' ''包装材料ﾒｰｶﾏｽﾀの更新
        ''        ' '' ''**************************************
        ''        '' ''Dim obj_XMST_PROD_LINE_D45 As New TBL_XMST_PROD_LINE_D45(Owner, ObjDb, ObjDbLog)
        ''        '' ''obj_XMST_PROD_LINE_D45.XPROD_LINE = objXSTS_WRAPPING_MATERIAL_D45.XPROD_LINE        '生産ﾗｲﾝ№
        ''        '' ''obj_XMST_PROD_LINE_D45.GET_XMST_PROD_LINE_D45(False)

        ''        '' ''Dim strMsg01 As String
        ''        '' ''strMsg01 = "ｽﾃｰｼｮﾝ:[" & objTMST_TRK.FBUF_NAME & "]"
        ''        '' ''strMsg01 &= " 生産ﾗｲﾝ:[" & obj_XMST_PROD_LINE_D45.XPROD_LINE_NAME & "]"
        ''        '' ''Call AddToMsgLog(Now, FMSG_ID_J4003, strMsg01)
        ''        ' '' ''JobMate:S.Ouchi 2013/10/29 包材出庫登録 計画満了時のﾒｯｾｰｼﾞ出力
        ''        ' '' ''↑↑↑↑↑↑************************************************************************************************************
        ''        'JobMate:S.Ouchi 2013/12/02 包材出庫登録 計画満了時のﾒｯｾｰｼﾞ出力 削除
        ''        '↑↑↑↑↑↑************************************************************************************************************
        ''    End If
        ''    objXSTS_WRAPPING_MATERIAL_D45.UPDATE_XSTS_WRAPPING_MATERIAL_D45()       '更新


        ''End If
        '↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

        '***********************************************
        '生産入庫設定状態           取得
        '***********************************************
        Dim objXSTS_PRODUCT_IN As New TBL_XSTS_PRODUCT_IN(Owner, ObjDb, ObjDbLog)
        objXSTS_PRODUCT_IN.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objXSTS_PRODUCT_IN.XKINKYU_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO      '緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        intRet = objXSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN(False)                  '取得
        If intRet = RetCode.OK Then
            '(見つかった場合)


            '***********************************************
            '生産入庫設定状態           更新
            '***********************************************
            objXSTS_PRODUCT_IN.XRESULT_NUM = TO_INTEGER(objXSTS_PRODUCT_IN.XRESULT_NUM) + 1        '実績数量
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
            objXSTS_PRODUCT_IN.XRESULT_NUM_CASE = TO_INTEGER(objXSTS_PRODUCT_IN.XRESULT_NUM_CASE) + objTRST_STOCK.ARYME(0).FTR_VOL  '実績数量(梱数)
            'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
            '↑↑↑↑↑↑************************************************************************************************************
            objXSTS_PRODUCT_IN.UPDATE_XSTS_PRODUCT_IN()         '更新


        End If


        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:YAMAMOTO 2017/04/11 1F包材出庫対応 ↓↓↓↓↓↓
        '***********************************************
        '包材出庫設定状態(1F)          取得
        '***********************************************
        Dim objXSTS_WRAPPING_MATERIAL_1F As New TBL_XSTS_WRAPPING_MATERIAL_1F(Owner, ObjDb, ObjDbLog)
        objXSTS_WRAPPING_MATERIAL_1F.FPLAN_KEY = objTSTS_HIKIATE.FPLAN_KEY             '計画ｷｰ
        intRet = objXSTS_WRAPPING_MATERIAL_1F.GET_XSTS_WRAPPING_MATERIAL_1F(False)    '取得
        If intRet = RetCode.OK Then
            '(見つかった場合)


            '***********************************************
            '包材出庫設定状態(1F)          更新
            '***********************************************
            objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM = TO_INTEGER(objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM) + 1               '実績数量
            objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM_SUM = TO_INTEGER(objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM_SUM) + 1       '実績数量(合計)
            If objXSTS_WRAPPING_MATERIAL_1F.XPLAN_NUM <= objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM Then
                '(計画数量 <= 実績数量 の場合)

                '======================================
                '実績数量           ﾘｾｯﾄ
                '======================================
                objXSTS_WRAPPING_MATERIAL_1F.XPLAN_NUM = 0             '計画数量
                objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM = 0           '実績数量
                objXSTS_WRAPPING_MATERIAL_1F.FTR_RES_VOL = 0           '引当数量

                '======================================
                'D45生産ﾗｲﾝXX要求枚数       ﾘｾｯﾄ
                '======================================
                'Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteWord(objXSTS_WRAPPING_MATERIAL_1F.FEQ_ID, FTEXT_ID_JW_ETC, 0)

            End If
            objXSTS_WRAPPING_MATERIAL_1F.UPDATE_XSTS_WRAPPING_MATERIAL_1F()       '更新


        End If
        'JobMate:YAMAMOTO 2017/04/111F包材出庫対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************


        Return intReturn
    End Function
#End Region

#Region "  特殊処理21(出荷指示、出荷指示詳細更新。出庫実績詳細追加。)                                                           "
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
                             , ByVal objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE _
                             ) _
                             As RetCode
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '************************
        'ﾁｪｯｸ
        '************************
        'NOP


        '************************************************
        '在庫情報                   取得
        '************************************************
        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
        objTRST_STOCK.FPALLET_ID = objTSTS_HIKIATE.FPALLET_ID           'ﾊﾟﾚｯﾄID
        objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)                       '取得


        '************************************************
        '在庫情報                   取得
        '************************************************
        Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
        objTMST_ITEM.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD     '品名ｺｰﾄﾞ
        objTMST_ITEM.GET_TMST_ITEM()                                    '取得


        '*****************************************************
        '出荷指示、出荷指示詳細、出庫実績詳細  の追加更新
        '*****************************************************
        Call SyukkaHikiateHiraokiUpdate(objTRST_STOCK _
                                      , objTMST_ITEM _
                                      , objTSTS_HIKIATE.FPLAN_KEY _
                                      , objTSTS_HIKIATE.FTR_VOL _
                                      , TO_INTEGER(objTRST_STOCK.ARYME(0).XTRK_BUF_NO_IN) _
                                      , TO_INTEGER(objTRST_STOCK.ARYME(0).XTRK_BUF_ARRAY_IN) _
                                      , objTPRG_TRK_BUF_TO.FTRK_BUF_NO _
                                      , objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY _
                                      , False _
                                      )


        Return intReturn
    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************


End Class
