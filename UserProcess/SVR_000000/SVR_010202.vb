'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出庫完了処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_010202
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

            '************************
            '出庫中ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = mFPALLET_ID                                  'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                           '特定


            '************************
            '倉庫ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            If TO_INTEGER(objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM) <> 0 And _
               TO_INTEGER(objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM) <> 0 Then
                objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM        'ﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM   '配列№
                intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                        '特定
            End If


            '************************
            'ｽﾃｰｼｮﾝﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_ST.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO          'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO     '配列№
            intRet = objTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF(True)                          '特定
            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2013/04/01  在庫ﾄﾗｯｷﾝｸﾞを更新してしまう為、修正

            If objTPRG_TRK_BUF_ST.FRES_KIND = FRES_KIND_SZAIKO Or IsNotNull(objTPRG_TRK_BUF_ST.FPALLET_ID) Then
                strMsg = ERRMSG_DISP_MENTE_FINISH_NOT_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_ST.FTRK_BUF_NO) & "  ,ﾊﾞｯﾌｧ配列№:" & TO_STRING(objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY) & "]"
                Throw New UserException(strMsg)
            End If
            'If objTPRG_TRK_BUF_ST.FRES_KIND = FRES_KIND_SZAIKO Then
            '    strMsg = ERRMSG_DISP_MENTE_FINISH_NOT_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_ST.FTRK_BUF_NO) & "  ,ﾊﾞｯﾌｧ配列№:" & TO_STRING(objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY) & "]"
            '    Throw New UserException(strMsg)
            'End If

            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '搬送先ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
            '************************
            Dim strEQ_ID As String = FEQ_ID_SKOTEI
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
                strEQ_ID = objTMST_CRANE.FEQ_ID
            End If


            '************************
            '搬送ﾙｰﾄﾏｽﾀの特定
            '************************
            Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)     '搬送ﾙｰﾄﾏｽﾀ
            objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_RELAY.FTR_FM                '元ﾊﾞｯﾌｧ№
            objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_RELAY.FTR_TO                '先ﾊﾞｯﾌｧ№
            objTMST_ROUTE.FEQ_ID_CRANE_FM = strEQ_ID                            '元ｸﾚｰﾝ設備ID
            objTMST_ROUTE.FEQ_ID_CRANE_TO = FEQ_ID_SKOTEI                       '先ｸﾚｰﾝ設備ID
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
            Dim objSVR_100103_ST As New SVR_100103(Owner, ObjDb, ObjDbLog) '在庫移動ｸﾗｽ
            objSVR_100103_ST.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(出庫中ﾊﾞｯﾌｧ)
            objSVR_100103_ST.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_ST       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ｽﾃｰｼｮﾝﾊﾞｯﾌｧ)
            objSVR_100103_ST.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID 'ﾊﾟﾚｯﾄID
            objSVR_100103_ST.FINOUT_STS = mFINOUT_STS                      'INOUT
            objSVR_100103_ST.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '作業種別(再検入庫)
            objSVR_100103_ST.INTCLEAR_FM_FLAG = FLAG_OFF                   '搬送元ｸﾘｱﾌﾗｸﾞ
            objSVR_100103_ST.STOCK_TRNS()                                  '移動


            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/08/24  搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№の利用
            '************************
            'ﾄﾗｯｷﾝｸﾞ情報一部記憶
            '************************
            Dim intFTR_TO As Nullable(Of Integer) = objTPRG_TRK_BUF_ST.FTR_TO            '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            Dim intFTR_IDOU As Nullable(Of Integer) = objTPRG_TRK_BUF_RELAY.FTR_IDOU     '搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            '↑↑↑↑↑↑************************************************************************************************************


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


            '************************
            '搬送元ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
            '************************
            objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            Call objTMST_TRK.GET_TMST_TRK(False)                                        '特定


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
                objTEVD_STOCK_LOG.FSEIHIN_KUBUN = objTRST_STOCK.FSEIHIN_KUBUN               '製品区分
                objTEVD_STOCK_LOG.FRECEIVEPAY_NUM = objTRST_STOCK.FTR_VOL                   '受払数量
                objTEVD_STOCK_LOG.FZAIKO_NUM = objTRST_STOCK.FTR_VOL                        '在庫数量
                objTEVD_STOCK_LOG.FSAGYOU_CONTENT = objTMST_SAGYO.FSAGYOU_CONTENT           '作業内容
                objTEVD_STOCK_LOG.ADD_TEVD_STOCK_LOG_SEQ()
            Next


            '**************************************
            '保管出納記録追加
            '**************************************
            Call Add_TBL_TEVD_SUITOU(objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO _
                                   , objTPRG_TRK_BUF_ST.FTRK_BUF_NO _
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


            '********************************
            '倉庫/出庫中/出庫先ﾊﾞｯﾌｧの更新
            '********************************

            '===========================
            '出庫先ﾊﾞｯﾌｧの更新
            '===========================
            If TO_INTEGER(objTMST_ROUTE.FBUF_TO) = TO_INTEGER(objTMST_ROUTE.FBUF_NEXT) Or _
               TO_INTEGER(objTMST_ROUTE.FBUF_RELAY) = 0 Or _
               TO_INTEGER(objTMST_ROUTE.FBUF_NEXT) = 0 Then
                '(最終の場合)

                objTPRG_TRK_BUF_ST.FRES_KIND = FRES_KIND_SZAIKO                             '引当状態
                objTPRG_TRK_BUF_ST.FRSV_PALLET = DEFAULT_STRING                             '仮引当ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_ST.FTR_FM = DEFAULT_INTEGER                                 '搬送FMﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_ST.FTR_TO = DEFAULT_INTEGER                                 '搬送TOﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_ST.FTR_IDOU = DEFAULT_INTEGER                               '搬送TO移動ﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_ST.FTRNS_FM = DEFAULT_STRING                                '搬送指令用FM
                objTPRG_TRK_BUF_ST.FTRNS_TO = DEFAULT_STRING                                '搬送指令用TO
                objTPRG_TRK_BUF_ST.FRSV_BUF_FM = DEFAULT_INTEGER                            'FM引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_ST.FRSV_ARRAY_FM = DEFAULT_INTEGER                          'FM引当配列№
                objTPRG_TRK_BUF_ST.FRSV_BUF_TO = DEFAULT_INTEGER                            'TO引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO = DEFAULT_INTEGER                          'TO引当配列№
                objTPRG_TRK_BUF_ST.FDISP_ADDRESS_FM = DEFAULT_STRING                        'FM表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_ST.FDISP_ADDRESS_TO = DEFAULT_STRING                        'TO表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_ST.FBUF_IN_DT = Now                                         'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_ST.UPDATE_TPRG_TRK_BUF()                                    '更新

            Else
                '(中継の場合)

                '************************
                '搬送ﾙｰﾄﾏｽﾀの特定
                '************************
                Dim objTMST_ROUTE_NEXT As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)        '搬送ﾙｰﾄﾏｽﾀ
                objTMST_ROUTE_NEXT.FBUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO                 '元ﾊﾞｯﾌｧ№
                objTMST_ROUTE_NEXT.FBUF_TO = objTPRG_TRK_BUF_RELAY.FTR_TO                   '先ﾊﾞｯﾌｧ№
                objTMST_ROUTE_NEXT.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                          '元ｸﾚｰﾝ設備ID
                objTMST_ROUTE_NEXT.FEQ_ID_CRANE_TO = FEQ_ID_SKOTEI                          '先ｸﾚｰﾝ設備ID
                intRet = objTMST_ROUTE_NEXT.GET_TMST_ROUTE(True)                            '特定

                '引当状態
                Select Case TO_INTEGER(objTMST_ROUTE_NEXT.FCARRYQUE_KUBUN)
                    Case FCARRYQUE_KUBUN_SIN                                 '入庫
                        '引当状態
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '搬出予約

                        '次搬送区分
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SIN              '入庫

                        '次処理起動
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動(入庫引当処理)

                    Case FCARRYQUE_KUBUN_SOUT                                '出庫
                        '引当状態
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '搬出予約

                        '次搬送区分
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SOUT             '出庫

                        '次処理起動
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動(入庫引当処理)

                    Case FCARRYQUE_KUBUN_STANA_MOVE                          '棚間搬送
                        '引当状態
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '搬出予約

                        '次搬送区分
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SIN              '入庫

                        '次処理起動
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動(入庫引当処理)

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

                objTPRG_TRK_BUF_ST.FRSV_PALLET = objTPRG_TRK_BUF_ST.FPALLET_ID                  '仮引当ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_ST.FRES_KIND = intRES_KIND                                      '引当状態
                objTPRG_TRK_BUF_ST.FTR_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO                      '搬送FMﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_ST.FTR_TO = objTPRG_TRK_BUF_RELAY.FTR_TO                        '搬送TOﾊﾞｯﾌｧ№
                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2013/06/04  倉替出庫で必要
                objTPRG_TRK_BUF_ST.FTR_IDOU = objTPRG_TRK_BUF_RELAY.FTR_IDOU                '搬送TO移動ﾊﾞｯﾌｧ№
                'objTPRG_TRK_BUF_ST.FTR_IDOU = DEFAULT_INTEGER                                   '搬送TO移動ﾊﾞｯﾌｧ№
                '↑↑↑↑↑↑************************************************************************************************************
                objTPRG_TRK_BUF_ST.FTRNS_FM = DEFAULT_STRING                                    '搬送指令用FM
                objTPRG_TRK_BUF_ST.FTRNS_TO = DEFAULT_STRING                                    '搬送指令用TO
                objTPRG_TRK_BUF_ST.FRSV_BUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO                 'FM引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_ST.FRSV_ARRAY_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY            'FM引当配列№
                objTPRG_TRK_BUF_ST.FRSV_BUF_TO = DEFAULT_INTEGER                                'TO引当ﾄﾗｯｷﾝｸﾞ№
                objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO = DEFAULT_INTEGER                              'TO引当配列№
                objTPRG_TRK_BUF_ST.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM    'FM表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_ST.FDISP_ADDRESS_TO = DEFAULT_STRING                            'TO表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_ST.FBUF_IN_DT = Now                                             'ﾊﾞｯﾌｧ入日時
                objTPRG_TRK_BUF_ST.UPDATE_TPRG_TRK_BUF()                                        '更新

            End If


            '************************
            '在庫削除判定
            '************************
            If TO_INTEGER(objTMST_ROUTE.FBUF_NEXT) = 0 Then
                '(搬送先が削除の場合)


                '↓↓↓↓↓↓************************************************************************************************************
                'Checked SystemMate:N.Dounoshita 2011/10/19 ﾄﾗｯｷﾝｸﾞ削除の方が適当だと思われる

                '************************
                'ﾄﾗｯｷﾝｸﾞ削除
                '************************
                Dim objSVR_100302 As New SVR_100302(Owner, ObjDb, ObjDbLog)
                objSVR_100302.FTRK_BUF_NO = objTPRG_TRK_BUF_ST.FTRK_BUF_NO  'ﾊﾞｯﾌｧ№
                objSVR_100302.FPALLET_ID = mFPALLET_ID                      'ﾊﾟﾚｯﾄID
                objSVR_100302.FINOUT_STS = FINOUT_STS_STRK_DELETE            'IN/OUT
                objSVR_100302.FTERM_ID = FTERM_ID_SKOTEI                      '端末ID
                objSVR_100302.FUSER_ID = FUSER_ID_SKOTEI                      'ﾕｰｻﾞｰID
                objSVR_100302.MENTE_DELETE()                                'ﾄﾗｯｷﾝｸﾞ削除


                ''************************
                ''在庫削除
                ''************************
                'Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '在庫削除ｸﾗｽ
                'objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_ST          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                'objSVR_100102.FPALLET_ID = mFPALLET_ID                      'ﾊﾟﾚｯﾄID
                'objSVR_100102.FINOUT_STS = FINOUT_STS_STRK_DELETE            'INOUT
                'objSVR_100102.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '作業種別
                'objSVR_100102.STOCK_DELETE()                                '削除

                '↑↑↑↑↑↑************************************************************************************************************

            End If


            '↓↓↓↓↓↓************************************************************************************************************
            'Checked JobMate:N.Dounoshita 2011/09/23 ﾊﾟﾚｯﾄ払出しまで在庫引当情報を保持する為ｺﾒﾝﾄｱｳﾄ

            ' '' '' ''************************
            ' '' '' ''在庫引当情報の削除
            ' '' '' ''************************
            '' '' ''If TO_INTEGER(objTPRG_TRK_BUF_ST.FTRK_BUF_NO) = TO_INTEGER(objTPRG_TRK_BUF_RELAY.FTR_TO) Then

            '' '' ''    '(出庫先が最終の場合)
            '' '' ''    objTSTS_HIKIATE = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)  '在庫引当情報ｸﾗｽ
            '' '' ''    objTSTS_HIKIATE.FPALLET_ID = mFPALLET_ID
            '' '' ''    objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()       '削除

            '' '' ''End If
            '↑↑↑↑↑↑************************************************************************************************************


            '===========================
            '倉庫ﾊﾞｯﾌｧの更新
            '===========================
            If TO_INTEGER(objTMST_SAGYO.FKEEP_RSVRAC_FLAG) = FLAG_OFF _
            Or TO_INTEGER(objTMST_ROUTE.FBUF_NEXT) = 0 _
            Then
                '(棚予約を保持しない場合)


                If (objTPRG_TRK_BUF_ASRS Is Nothing) = False Then
                    If objTPRG_TRK_BUF_ASRS.FRSV_PALLET = mFPALLET_ID Then
                        objTPRG_TRK_BUF_ASRS.CLEAR_TPRG_TRK_BUF()   '解放
                    End If
                End If


                '↓↓↓↓↓↓************************************************************************************************************
                'Checked SystemMate:N.Dounoshita 2011/09/23 棚の予約保持

            Else

                objTPRG_TRK_BUF_ST.FRSV_PALLET = objTPRG_TRK_BUF_RELAY.FRSV_PALLET                  '仮引当ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_ST.FTR_FM = objTPRG_TRK_BUF_RELAY.FTR_FM                            '搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                'objTPRG_TRK_BUF_ST.FTR_TO = objTPRG_TRK_BUF_RELAY.FTR_TO                            '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                'objTPRG_TRK_BUF_ST.FTR_IDOU = objTPRG_TRK_BUF_RELAY.FTR_IDOU                        '搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_ST.FTRNS_FM = objTPRG_TRK_BUF_RELAY.FTRNS_FM                        '搬送指令用FM
                'objTPRG_TRK_BUF_ST.FTRNS_TO = objTPRG_TRK_BUF_RELAY.FTRNS_TO                        '搬送指令用TO
                objTPRG_TRK_BUF_ST.FRSV_BUF_FM = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM                  'FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_ST.FRSV_ARRAY_FM = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM              'FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
                'objTPRG_TRK_BUF_ST.FRSV_BUF_TO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO                  'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                'objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO              'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
                objTPRG_TRK_BUF_ST.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM        'FM表記用ｱﾄﾞﾚｽ
                'objTPRG_TRK_BUF_ST.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO        'TO表記用ｱﾄﾞﾚｽ
                objTPRG_TRK_BUF_ST.FDISPLOG_ADDRESS_FM = objTPRG_TRK_BUF_RELAY.FDISPLOG_ADDRESS_FM  'FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
                'objTPRG_TRK_BUF_ST.FDISPLOG_ADDRESS_TO = objTPRG_TRK_BUF_RELAY.FDISPLOG_ADDRESS_TO  'TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
                objTPRG_TRK_BUF_ST.UPDATE_TPRG_TRK_BUF()                                            '更新

                '↑↑↑↑↑↑************************************************************************************************************

            End If


            '===========================
            '出庫中ﾊﾞｯﾌｧの更新
            '===========================
            objTPRG_TRK_BUF_RELAY.CLEAR_TPRG_TRK_BUF()      '解放


            '************************
            '搬送指示QUEの削除
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) 'ｲﾝｽﾀﾝｽ化
            objTPLN_CARRY_QUE.FPALLET_ID = mFPALLET_ID                              'ﾊﾟﾚｯﾄID
            objTPLN_CARRY_QUE.DELETE_TPLN_CARRY_QUE_PALLET()                        '削除

            '************************
            '搬送指示QUEの再登録
            '(搬送指示のみ、入庫指示は入庫引当処理にて実行)
            '************************
            If intRES_KIND = FRES_KIND_SRSV_TRNS_OUT And _
               intCARRYQUE_KUBUN <> FCARRYQUE_KUBUN_SIN Then
                '************************
                '優先ﾚﾍﾞﾙ
                '************************
                Dim intFPRIORITY As Integer                                             '優先ﾚﾍﾞﾙ
                objTMST_SAGYO.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND               '作業種別
                objTMST_SAGYO.FEQ_ID = FEQ_ID_SKOTEI                                    '設備ID
                objTMST_SAGYO.GET_TMST_SAGYO(False)                                     '取得
                intFPRIORITY = TO_INTEGER(objTMST_SAGYO.FPRIORITY)
                If intFPRIORITY < FPRIORITY_SLOW Then intFPRIORITY = FPRIORITY_SLOW

                '************************
                '搬送指示QUE登録
                '************************
                objTPLN_CARRY_QUE.FCARRYQUE_D = Now                                     '搬送指示日
                objTPLN_CARRY_QUE.FEQ_ID = FEQ_ID_SKOTEI                                '設備ID
                objTPLN_CARRY_QUE.FPRIORITY = FPRIORITY_SLOW                             'ﾌﾟﾗｲｵﾘﾃｨ区分
                objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID            'ﾊﾟﾚｯﾄID
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
            'SystemMate:N.Dounoshita 2012/08/24  搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№の利用


            If intFTR_TO = objTPRG_TRK_BUF_ST.FTRK_BUF_NO _
               And IsNotNull(intFTR_IDOU) _
                Then
                '(さらに行き先が設定されている場合)


                '************************************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(搬送先)       取得
                '************************************************
                Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_TO.FTRK_BUF_NO = intFTR_IDOU                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                intRet = objTPRG_TRK_BUF_TO.GET_TPRG_TRK_BUF_AKI_HIRA()         '取得
                If intRet <> RetCode.OK Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_TO.FTRK_BUF_NO) & "]"
                    Throw New UserException(strMsg)
                End If


                '************************
                '在庫移動
                '************************
                Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '在庫移動ｸﾗｽ
                objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_ST       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(FM)
                objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_TO       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(TO)
                objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID    'ﾊﾟﾚｯﾄID
                objSVR_100103.FINOUT_STS = FINOUT_STS_SIN_UKETUKE           'INOUT
                objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '作業種別
                objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '搬送元ｸﾘｱﾌﾗｸﾞ
                objSVR_100103.STOCK_TRNS()                                  '移動


            End If


            '↑↑↑↑↑↑************************************************************************************************************


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2012/08/22 特殊処理



            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '次処理起動
            '************************
            objTPRG_TIMER.CLEAR_PROPERTY()
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動


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

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
