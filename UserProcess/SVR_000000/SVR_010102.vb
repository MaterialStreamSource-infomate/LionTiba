'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】入庫完了処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_010102
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ｸﾗｽ変数定義                                                                          "
    Private mFPALLET_ID As String                       'ﾊﾟﾚｯﾄID
    Private mFINOUT_STS As Nullable(Of Integer)         'IN/OUT
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


            '************************
            '入庫中ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = mFPALLET_ID                              'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                       '特定


            '************************
            'ｽﾃｰｼｮﾝﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            If IsNull(objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM) = False Then
                '(搬送元が解放されていない場合)
                objTPRG_TRK_BUF_ST.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
                intRet = objTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF(True)                          '特定
            End If


            '************************
            '倉庫ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                        '特定


            '************************
            '搬送先ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀｸﾗｽ
            objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            intRet = objTMST_TRK.GET_TMST_TRK(True)                                     '特定

            If objTMST_TRK.FBUF_KIND = FBUF_KIND_SASRS Then
                '************************
                'ｸﾚｰﾝﾏｽﾀの特定
                '************************
                Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog) 'ｸﾚｰﾝﾏｽﾀｸﾗｽ
                objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO    'ﾊﾞｯﾌｧ№
                objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU     '列
                intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                       '特定
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                    Throw New UserException(strMsg)
                End If
            End If


            '************************
            '在庫引当情報の特定
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '在庫引当情報ｸﾗｽ
            objTSTS_HIKIATE.FPALLET_ID = mFPALLET_ID                            'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                    '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[ﾊﾟﾚｯﾄID:" & mFPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '在庫移動
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '在庫移動ｸﾗｽ
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(入庫中ﾊﾞｯﾌｧ)
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_ASRS     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(倉庫ﾊﾞｯﾌｧ)
            objSVR_100103.FPALLET_ID = mFPALLET_ID                      'ﾊﾟﾚｯﾄID
            objSVR_100103.FINOUT_STS = mFINOUT_STS                      'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '作業種別
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '搬送元ｸﾘｱﾌﾗｸﾞ
            objSVR_100103.STOCK_TRNS()                                  '移動


            '***********************
            '端末ﾏｽﾀの特定
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)               '端末ﾏｽﾀ
            If IsNull(objTSTS_HIKIATE.FTERM_ID) = False Then
                objTDSP_TERM.FTERM_ID = objTSTS_HIKIATE.FTERM_ID                        '端末ID
                Call objTDSP_TERM.GET_TDSP_TERM(False)                                  '特定
            End If

            '***********************
            'ﾕｰｻﾞｰﾏｽﾀの特定
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)               'ﾕｰｻﾞｰﾏｽﾀ
            If IsNull(objTSTS_HIKIATE.FUSER_ID) = False Then
                objTMST_USER.FUSER_ID = objTSTS_HIKIATE.FUSER_ID                        'ﾕｰｻﾞｰID
                Call objTMST_USER.GET_TMST_USER(False)                                  '特定
            End If


            '***********************
            '作業種別毎制御情報の特定
            '***********************
            Dim objTMST_SAGYO As New TBL_TMST_SAGYO(Owner, ObjDb, ObjDbLog)             '作業種別毎制御情報
            If IsNull(objTSTS_HIKIATE.FSAGYOU_KIND) = False Then
                objTMST_SAGYO.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND               '作業種別
                objTMST_SAGYO.FEQ_ID = FEQ_ID_SKOTEI                                    '設備ID
                Call objTMST_SAGYO.GET_TMST_SAGYO(False)                                '特定
            End If


            '************************
            '在庫情報の取得
            '************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)             '在庫情報ｸﾗｽ
            Dim objTRST_STOCK_BASE As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)        '在庫情報ｸﾗｽ
            objTRST_STOCK_BASE.FPALLET_ID = mFPALLET_ID                                 'ﾊﾟﾚｯﾄID
            objTRST_STOCK_BASE.GET_TRST_STOCK_KONSAI(False)
            For Each objTRST_STOCK In objTRST_STOCK_BASE.ARYME
                '(ﾙｰﾌﾟ:混載在庫数)

                '**************************************
                '品名ﾏｽﾀの特定
                '**************************************
                Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                objTMST_ITEM.FHINMEI_CD = objTRST_STOCK.FHINMEI_CD                          '品名ｺｰﾄﾞ
                Call objTMST_ITEM.GET_TMST_ITEM(False)                                      '特定

                '************************
                '在庫更新履歴の登録
                '************************
                Dim objTEVD_STOCK_LOG As New TBL_TEVD_STOCK_LOG(Owner, ObjDb, ObjDbLog)     '在庫更新履歴ﾃｰﾌﾞﾙｸﾗｽ
                objTEVD_STOCK_LOG.FENTRY_DT = Now                                           '登録日時
                objTEVD_STOCK_LOG.FPALLET_ID = mFPALLET_ID                                  'ﾊﾟﾚｯﾄID
                objTEVD_STOCK_LOG.FTERM_ID = objTDSP_TERM.FTERM_ID                          '端末ID
                objTEVD_STOCK_LOG.FTERM_NAME = objTDSP_TERM.FTERM_NAME                      '端末名
                objTEVD_STOCK_LOG.FUSER_ID = objTMST_USER.FUSER_ID                          'ﾕｰｻﾞｰID
                objTEVD_STOCK_LOG.FUSER_NAME = objTMST_USER.FUSER_NAME                      'ﾕｰｻﾞｰ名
                objTEVD_STOCK_LOG.FPLACE_CD = objTMST_TRK.FPLACE_CD                         '保管場所ｺｰﾄﾞ
                objTEVD_STOCK_LOG.FAREA_CD = objTMST_TRK.FAREA_CD                           'ｴﾘｱ
                objTEVD_STOCK_LOG.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD                      '品名ｺｰﾄﾞ
                objTEVD_STOCK_LOG.FHINMEI = objTMST_ITEM.FHINMEI                            '品名
                objTEVD_STOCK_LOG.FLOT_NO = objTRST_STOCK.FLOT_NO                           'ﾛｯﾄ№
                objTEVD_STOCK_LOG.FSAGYOU_KIND = objTMST_SAGYO.FSAGYOU_KIND                 '作業種別
                objTEVD_STOCK_LOG.FNUM_IN_CASE = objTMST_ITEM.FNUM_IN_CASE                  'ｹｰｽ入数
                objTEVD_STOCK_LOG.FTANI = objTMST_ITEM.FTANI                                '単位
                objTEVD_STOCK_LOG.FDECIMAL_POINT = objTMST_ITEM.FDECIMAL_POINT              '小数点桁数
                objTEVD_STOCK_LOG.FSEIHIN_KUBUN = objTRST_STOCK.FSEIHIN_KUBUN               '製品区分
                objTEVD_STOCK_LOG.FRECEIVEPAY_NUM = objTRST_STOCK.FTR_VOL                   '受払数量
                objTEVD_STOCK_LOG.FZAIKO_NUM = objTRST_STOCK.FTR_VOL                        '在庫数量
                objTEVD_STOCK_LOG.FHORYU_KUBUN = objTRST_STOCK.FHORYU_KUBUN                 '保留区分
                objTEVD_STOCK_LOG.FSAGYOU_CONTENT = objTMST_SAGYO.FSAGYOU_CONTENT           '作業内容
                objTEVD_STOCK_LOG.ADD_TEVD_STOCK_LOG_SEQ()

                '************************
                '在庫情報の更新
                '************************
                objTRST_STOCK.FTR_RES_VOL = 0           '搬送引当量
                objTRST_STOCK.FUPDATE_DT = Now          '更新日時
                objTRST_STOCK.UPDATE_TRST_STOCK()       '更新



                '↓↓↓↓↓↓************************************************************************************************************
                '2017/07/29 BCR更新 infomate
                '更新タイミング変更の為コメントアウト

                'Try
                '    If objTSTS_HIKIATE.FSAGYOU_KIND = 81 Then
                '        Dim objXSTS_BCR As New TBL_XSTS_BCR(Owner, ObjDb, ObjDbLog)
                '        objXSTS_BCR.FTRK_BUF_NO = 2051
                '        objXSTS_BCR.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD
                '        objXSTS_BCR.GET_XSTS_BCR(False)

                '        objXSTS_BCR.XCOUNT_PL_IN = objXSTS_BCR.XCOUNT_PL_IN + 1
                '        objXSTS_BCR.XCOUNT_IN = objXSTS_BCR.XCOUNT_IN + objTMST_ITEM.FNUM_IN_PALLET
                '        objXSTS_BCR.UPDATE_XSTS_BCR()

                '    End If

                '    If objTSTS_HIKIATE.FSAGYOU_KIND = 82 Then
                '        Dim objXSTS_BCR As New TBL_XSTS_BCR(Owner, ObjDb, ObjDbLog)
                '        objXSTS_BCR.FTRK_BUF_NO = 2901
                '        objXSTS_BCR.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD
                '        objXSTS_BCR.GET_XSTS_BCR(False)

                '        objXSTS_BCR.XCOUNT_PL_IN = objXSTS_BCR.XCOUNT_PL_IN + 1
                '        objXSTS_BCR.XCOUNT_IN = objXSTS_BCR.XCOUNT_IN + objTMST_ITEM.FNUM_IN_PALLET
                '        objXSTS_BCR.UPDATE_XSTS_BCR()

                '    End If
                'Catch ex As Exception
                '    'NOP
                'End Try

                '↑↑↑↑↑↑************************************************************************************************************
            Next

     
            '**************************************
            '保管出納記録追加
            '**************************************
            Call Add_TBL_TEVD_SUITOU(objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO _
                                   , DEFAULT_INTEGER _
                                   , objTSTS_HIKIATE.FSAGYOU_KIND _
                                   , objTSTS_HIKIATE.FTERM_ID _
                                   , objTSTS_HIKIATE.FUSER_ID _
                                   , DEFAULT_STRING _
                                   , DEFAULT_STRING _
                                   , objTRST_STOCK_BASE _
                                    )


            '**************************************
            '配列解放
            '**************************************
            objTRST_STOCK_BASE.ARYME_CLEAR()


            '************************
            'ｽﾃｰｼｮﾝﾊﾞｯﾌｧの更新
            '************************
            If IsNull(objTPRG_TRK_BUF_ST.FTRK_BUF_NO) = False Then
                If mFPALLET_ID = objTPRG_TRK_BUF_ST.FRSV_PALLET Then
                    '(搬送元が解放されていない場合)
                    objTPRG_TRK_BUF_ST.CLEAR_TPRG_TRK_BUF()             '解放
                End If
            End If


            '************************
            '倉庫ﾊﾞｯﾌｧの更新
            '************************
            objTPRG_TRK_BUF_ASRS.FRSV_PALLET = DEFAULT_STRING                   '仮引当ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_ASRS.FTR_FM = DEFAULT_INTEGER                       '搬送FMﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS.FTR_TO = DEFAULT_INTEGER                       '搬送TOﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS.FTR_IDOU = DEFAULT_INTEGER                     '搬送TO移動ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS.FTRNS_FM = DEFAULT_STRING                      '搬送指令用FM
            objTPRG_TRK_BUF_ASRS.FTRNS_TO = DEFAULT_STRING                      '搬送指令用TO
            objTPRG_TRK_BUF_ASRS.FRSV_BUF_FM = DEFAULT_INTEGER                  'FM引当ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_FM = DEFAULT_INTEGER                'FM引当配列№
            objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO = DEFAULT_INTEGER                  'TO引当ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO = DEFAULT_INTEGER                'TO引当配列№
            objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_FM = DEFAULT_STRING              'FM表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_TO = DEFAULT_STRING              'TO表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF_ASRS.FDISPLOG_ADDRESS_FM = DEFAULT_STRING           'FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            objTPRG_TRK_BUF_ASRS.FDISPLOG_ADDRESS_TO = DEFAULT_STRING           'TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            objTPRG_TRK_BUF_ASRS.FBUF_IN_DT = Now                               'ﾊﾞｯﾌｧ入日時
            objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                          '更新


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/01 生産ライン別入庫実績で倉替え入庫は実績に計上させない
            Dim objTSTS_HIKIATE_WK As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '在庫引当情報ｸﾗｽ
            objTSTS_HIKIATE_WK.FPALLET_ID = mFPALLET_ID                            'ﾊﾟﾚｯﾄID
            objTSTS_HIKIATE_WK.GET_TSTS_HIKIATE_PALLET()                    '特定
            'JobMate:S.Ouchi 2013/11/01 生産ライン別入庫実績で倉替え入庫は実績に計上させない
            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '在庫引当情報の削除
            '************************
            objTSTS_HIKIATE = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)  '在庫引当情報ｸﾗｽ
            objTSTS_HIKIATE.FPALLET_ID = mFPALLET_ID
            objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()       '削除


            '************************
            '搬送指示QUEの削除
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) 'ｲﾝｽﾀﾝｽ化
            objTPLN_CARRY_QUE.FPALLET_ID = mFPALLET_ID                              'ﾊﾟﾚｯﾄID
            objTPLN_CARRY_QUE.DELETE_TPLN_CARRY_QUE_PALLET()                        '削除


            '************************
            'ｼﾘｱﾙ関連付けの削除
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)   'ｼﾘｱﾙ関連付けｸﾗｽ
            objTPRG_SERIAL.FPALLET_ID = mFPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                 '削除


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/04 特殊処理


            '**************************************
            '特殊処理01(棚ﾌﾞﾛｯｸ状態更新)
            '**************************************
            Call Special01(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_ST _
                         , objTPRG_TRK_BUF_ASRS _
                         , objTSTS_HIKIATE _
                         )


            '**************************************
            '特殊処理02(在庫情報更新)
            '**************************************
            Call Special02(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_ST _
                         , objTPRG_TRK_BUF_ASRS _
                         , objTSTS_HIKIATE _
                         )


            '**************************************
            '特殊処理21(出生産実績詳細追加)
            '**************************************
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/01 生産ライン別入庫実績で倉替え入庫は実績に計上させない
            '' ''Call Special21(objTPRG_TRK_BUF_RELAY _
            '' ''             , objTPRG_TRK_BUF_ST _
            '' ''             , objTPRG_TRK_BUF_ASRS _
            '' ''             , objTSTS_HIKIATE _
            '' ''             )
            Call Special21(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_ST _
                         , objTPRG_TRK_BUF_ASRS _
                         , objTSTS_HIKIATE_WK _
                         )
            'JobMate:S.Ouchi 2013/11/01 生産ライン別入庫実績で倉替え入庫は実績に計上させない
            '↑↑↑↑↑↑************************************************************************************************************


            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                           '起動(入庫指示)

            '************************
            '正常完了
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "  [ﾊﾟﾚｯﾄID:" & mFPALLET_ID & "]")


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
#Region "  特殊処理01(棚ﾌﾞﾛｯｸ状態更新)                                                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理01(ﾌﾞﾛｯｸ状態更新)
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


        '************************************************
        '棚ﾌﾞﾛｯｸの取得
        '************************************************
        Dim intCount As Integer = 0                                             'ﾌﾞﾛｯｸ内の手前棚の在庫ｶｳﾝﾄ
        Dim objTrkRelation() As TBL_TPRG_TRK_BUF = Nothing                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
        Dim objStockFind As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)          '在庫情報
        Dim objStockRelation() As TBL_TRST_STOCK = Nothing                      '在庫情報
        Call GetTPRG_TRK_BUF_Relation(objTPRG_TRK_BUF_TO, objTrkRelation, objStockFind, objStockRelation)
        For ii As Integer = 0 To UBound(objStockRelation)
            '(ﾙｰﾌﾟ:関係するﾄﾗｯｷﾝｸﾞ数)

            If (objTrkRelation(ii).XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_MAE_EVN Or objTrkRelation(ii).XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_MAE_ODD) _
               And IsNotNull(objTrkRelation(ii).FPALLET_ID) _
               Then
                '(手前棚かつ在庫が存在している場合)
                intCount += 1
            End If

            If ii = UBound(objStockRelation) Then
                '(ﾙｰﾌﾟ最終の場合)

                '************************************************
                '棚ﾌﾞﾛｯｸ状態の更新
                '************************************************
                If 1 <= intCount Then
                    '(手前棚に在庫が1つでも存在していた場合)
                    Call UpdateTPRG_TRK_BUF_Relation_XTANA_BLOCK_STS(objTPRG_TRK_BUF_TO, XTANA_BLOCK_STS_NON)
                End If


            End If

        Next


        Return intReturn
    End Function
#End Region
#Region "  特殊処理02(在庫情報更新)                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理02(在庫情報更新)
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
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '************************************************
        '在庫情報           取得
        '************************************************
        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
        objTRST_STOCK.FPALLET_ID = objTPRG_TRK_BUF_TO.FPALLET_ID
        objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)


        '************************************************
        '在庫情報           更新
        '************************************************
        objTRST_STOCK.ARYME(0).XRAC_IN_DT = Now                                         '入庫日時
        objTRST_STOCK.ARYME(0).XTRK_BUF_NO_IN = objTPRG_TRK_BUF_TO.FTRK_BUF_NO          '入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTRST_STOCK.ARYME(0).XTRK_BUF_ARRAY_IN = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY    '入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        objTRST_STOCK.ARYME(0).UPDATE_TRST_STOCK()                                      '更新


        '************************************************
        '在庫情報           入庫ﾄﾗｯｷﾝｸﾞ情報の更新
        '************************************************
        Call UpdateTRST_STOCK_InInfor(objTPRG_TRK_BUF_TO, objTRST_STOCK)


        Return intReturn
    End Function
#End Region

#Region "  特殊処理21(出生産実績詳細追加)                                                       "
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
        Dim intReturn As RetCode = RetCode.OK
        Try


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
            '操業履歴                   取得
            '************************************************
            Dim objXRST_SOUGYOU As New TBL_XRST_SOUGYOU(Owner, ObjDb, ObjDbLog)
            objXRST_SOUGYOU.GET_XRST_SOUGYOU_XRST_SOUGYOU_MAX()


            '*****************************************************
            '生産実績詳細               追加
            '*****************************************************
            Dim objXRST_PRODUCT_IN As New TBL_XRST_PRODUCT_IN(Owner, ObjDb, ObjDbLog)
            objXRST_PRODUCT_IN.XSOUGYOU_DT = objXRST_SOUGYOU.XSOUGYOU_DT                    '操業日
            objXRST_PRODUCT_IN.FPALLET_ID = objTRST_STOCK.ARYME(0).FPALLET_ID               'ﾊﾟﾚｯﾄID
            objXRST_PRODUCT_IN.FLOT_NO_STOCK = objTRST_STOCK.ARYME(0).FLOT_NO_STOCK         '在庫ﾛｯﾄ№
            intRet = objXRST_PRODUCT_IN.GET_XRST_PRODUCT_IN(False)
            If intRet <> RetCode.OK Then

                '↓↓↓↓↓↓************************************************************************************************************
                '    JobMate:S.Ouchi 2013/11/01 生産ライン別入庫実績で倉替え入庫は実績に計上させない
                If TO_INTEGER(objTSTS_HIKIATE.FSAGYOU_KIND) <> FSAGYOU_KIND_J75 And _
                   TO_INTEGER(objTSTS_HIKIATE.FSAGYOU_KIND) <> FSAGYOU_KIND_J76 Then
                    'JobMate:S.Ouchi 2013/11/01 生産ライン別入庫実績で倉替え入庫は実績に計上させない
                    '↑↑↑↑↑↑************************************************************************************************************

                    '(倉替入庫以外の場合)
                    objXRST_PRODUCT_IN.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND                  '作業種別
                    objXRST_PRODUCT_IN.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD               '品目ｺｰﾄﾞ
                    objXRST_PRODUCT_IN.FLOT_NO = objTRST_STOCK.ARYME(0).FLOT_NO                     'ﾛｯﾄ№
                    objXRST_PRODUCT_IN.FARRIVE_DT = objTRST_STOCK.ARYME(0).FARRIVE_DT               '在庫発生日時
                    objXRST_PRODUCT_IN.FIN_KUBUN = objTRST_STOCK.ARYME(0).FIN_KUBUN                 '入庫区分
                    objXRST_PRODUCT_IN.FSEIHIN_KUBUN = objTRST_STOCK.ARYME(0).FSEIHIN_KUBUN         '製品区分
                    objXRST_PRODUCT_IN.FZAIKO_KUBUN = objTRST_STOCK.ARYME(0).FZAIKO_KUBUN           '在庫区分
                    objXRST_PRODUCT_IN.FHORYU_KUBUN = objTRST_STOCK.ARYME(0).FHORYU_KUBUN           '保留区分
                    objXRST_PRODUCT_IN.FST_FM = objTRST_STOCK.ARYME(0).FST_FM                       '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objXRST_PRODUCT_IN.FTR_VOL = objTRST_STOCK.ARYME(0).FTR_VOL                     '搬送管理量
                    objXRST_PRODUCT_IN.FHASU_FLAG = objTRST_STOCK.ARYME(0).FHASU_FLAG               '端数ﾌﾗｸﾞ
                    objXRST_PRODUCT_IN.XPROD_LINE = objTRST_STOCK.ARYME(0).XPROD_LINE               '生産ﾗｲﾝ№
                    objXRST_PRODUCT_IN.XKENSA_KUBUN = objTRST_STOCK.ARYME(0).XKENSA_KUBUN           '検査区分
                    objXRST_PRODUCT_IN.XKENPIN_KUBUN = objTRST_STOCK.ARYME(0).XKENPIN_KUBUN         '検品区分
                    objXRST_PRODUCT_IN.XMAKER_CD = objTRST_STOCK.ARYME(0).XMAKER_CD                 'ﾒｰｶ-ｺｰﾄﾞ
                    objXRST_PRODUCT_IN.XRAC_IN_DT = Now                                             '入庫日時
                    objXRST_PRODUCT_IN.XTRK_BUF_NO_IN = objTPRG_TRK_BUF_TO.FTRK_BUF_NO              '入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objXRST_PRODUCT_IN.XTRK_BUF_ARRAY_IN = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY        '入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
                    objXRST_PRODUCT_IN.ADD_XRST_PRODUCT_IN()                                        '登録

                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/01 生産ライン別入庫実績で倉替え入庫は実績に計上させない
                End If
                '    JobMate:S.Ouchi 2013/11/01 生産ライン別入庫実績で倉替え入庫は実績に計上させない
                '↑↑↑↑↑↑************************************************************************************************************

            End If


            ' '' ''*****************************************************
            ' '' ''生産入庫設定状態           追加
            ' '' ''*****************************************************
            '' ''If IsNotNull(objTRST_STOCK.ARYME(0).FST_FM) Then
            '' ''    '(搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№がｾｯﾄされていた場合)

            '' ''    Dim objXSTS_PRODUCT_IN As New TBL_XSTS_PRODUCT_IN(Owner, ObjDb, ObjDbLog)
            '' ''    objXSTS_PRODUCT_IN.FTRK_BUF_NO = objTRST_STOCK.ARYME(0).FST_FM              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            '' ''    objXSTS_PRODUCT_IN.XPROD_LINE = objTRST_STOCK.ARYME(0).XPROD_LINE           '生産ﾗｲﾝ№
            '' ''    objXSTS_PRODUCT_IN.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD           '品目ｺｰﾄﾞ
            '' ''    objXSTS_PRODUCT_IN.FIN_KUBUN = objTRST_STOCK.ARYME(0).FIN_KUBUN             '入庫区分
            '' ''    objXSTS_PRODUCT_IN.FHORYU_KUBUN = objTRST_STOCK.ARYME(0).FHORYU_KUBUN       '保留区分
            '' ''    objXSTS_PRODUCT_IN.XKENSA_KUBUN = objTRST_STOCK.ARYME(0).XKENSA_KUBUN       '検査区分
            '' ''    objXSTS_PRODUCT_IN.XKENPIN_KUBUN = objTRST_STOCK.ARYME(0).XKENPIN_KUBUN     '検品区分
            '' ''    objXSTS_PRODUCT_IN.XMAKER_CD = objTRST_STOCK.ARYME(0).XMAKER_CD             'ﾒｰｶ-ｺｰﾄﾞ
            '' ''    intRet = objXSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN(False)                      '取得
            '' ''    If intRet = RetCode.OK Then
            '' ''        '(見つかった場合)

            '' ''        objXSTS_PRODUCT_IN.XRESULT_NUM = TO_INTEGER(objXSTS_PRODUCT_IN.XRESULT_NUM) + 1     '実績数量
            '' ''        objXSTS_PRODUCT_IN.UPDATE_XSTS_PRODUCT_IN()                                         '更新

            '' ''    End If

            '' ''End If


            Return intReturn
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG
        End Try
    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
