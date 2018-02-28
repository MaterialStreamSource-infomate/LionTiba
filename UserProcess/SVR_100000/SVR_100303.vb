'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾄﾗｯｷﾝｸﾞｷｬﾝｾﾙｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100303
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義                                                                      "
    Private mFTRK_BUF_NO As Nullable(Of Integer)    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFPALLET_ID As String                   'ﾊﾟﾚｯﾄID
    Private mFINOUT_STS As Nullable(Of Integer)     'INOUT
    Private mKARA_OUT_FLAG As Integer = FLAG_OFF    '空出庫ﾌﾗｸﾞ
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FTRK_BUF_NO() As Integer
        Get
            Return mFTRK_BUF_NO
        End Get
        Set(ByVal Value As Integer)
            mFTRK_BUF_NO = Value
        End Set
    End Property
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
    ''' <summary>INOUT</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FINOUT_STS() As Integer
        Get
            Return mFINOUT_STS
        End Get
        Set(ByVal Value As Integer)
            mFINOUT_STS = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>空出庫ﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property KARA_OUT_FLAG() As Integer
        Get
            Return mKARA_OUT_FLAG
        End Get
        Set(ByVal Value As Integer)
            mKARA_OUT_FLAG = Value
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
#Region "  ﾄﾗｯｷﾝｸﾞｷｬﾝｾﾙ                                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞｷｬﾝｾﾙ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MENTE_CANCEL()
        Try
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            Dim intRet As RetCode                   '戻り値


            '************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '************************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFPALLET_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
                Throw New UserException(strMsg)
            End If

           
            '************************
            'ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀｸﾗｽ
            objTMST_TRK.FTRK_BUF_NO = mFTRK_BUF_NO                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            intRet = objTMST_TRK.GET_TMST_TRK(True)                     '特定

           
            '************************
            'ﾄﾗｯｷﾝｸﾞｷｬﾝｾﾙ
            '************************
            Select Case TO_INTEGER(objTMST_TRK.FBUF_KIND)
                Case FBUF_KIND_SIN : Call Mente_Cancel_IN(mFPALLET_ID, mFTRK_BUF_NO)         '入庫中強制ｷｬﾝｾﾙ
                Case FBUF_KIND_SASRS : Call Mente_Cancel_OUT_RSV(mFPALLET_ID, mFTRK_BUF_NO)  '出庫予約強制ｷｬﾝｾﾙ
                Case FBUF_KIND_SHIRA : Call Mente_Cancel_OUT_RSV_NOTORSV(mFPALLET_ID, mFTRK_BUF_NO)        '出庫予約強制ｷｬﾝｾﾙ（搬送先引当てﾁｪｯｸ無し）
                Case FBUF_KIND_SOUT : Call Mente_Cancel_OUT(mFPALLET_ID, mFTRK_BUF_NO)       '出庫中強制ｷｬﾝｾﾙ
                Case FBUF_KIND_STRNS
                    'If mFTRK_BUF_NO = FTRK_BUF_NO_2004 Then
                    '    '(ｸﾚｰﾝ搬送中の場合)
                    '    Call Mente_Cancel_TRNS_CRANE(mFPALLET_ID, mFTRK_BUF_NO)             '搬送中強制ｷｬﾝｾﾙ(ｸﾚｰﾝ搬送中)
                    'Else
                    '(その他搬送中の場合)
                    Call Mente_Cancel_TRNS(mFPALLET_ID, mFTRK_BUF_NO)                   '搬送中強制ｷｬﾝｾﾙ
                    'End If
                Case FBUF_KIND_SSOUKO : Call Mente_Cancel_SOUKO(mFPALLET_ID, mFTRK_BUF_NO)   '倉庫間移動中ｷｬﾝｾﾙ
                Case Else
                    '(見つからない場合)
                    strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[想定外ﾊﾞｯﾌｧ]" & "[ﾊﾞｯﾌｧNo:" & TO_STRING(objTMST_TRK.FTRK_BUF_NO) & "]"
                    Throw New UserException(strMsg)
            End Select


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region

#Region "  入庫中強制ｷｬﾝｾﾙ                                                                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入庫中強制ｷｬﾝｾﾙ
    ''' </summary>
    ''' <param name="strPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <param name="intTRK_BUF_NO">ﾊﾞｯﾌｧ№</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_Cancel_IN(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '************************
            '入庫中ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = intTRK_BUF_NO                               'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = strPALLET_ID                                 'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                           '特定
            If IsNull(objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM) = True Then
                '(搬送元が解放済の場合)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[搬送元開放済]" & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "  ,ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            'ｽﾃｰｼｮﾝﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_ST.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM      'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM '配列№
            intRet = objTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF(True)                      '特定


            '************************
            '搬送元開放
            '************************
            If objTPRG_TRK_BUF_ST.FRSV_PALLET <> objTPRG_TRK_BUF_RELAY.FPALLET_ID Or _
               objTPRG_TRK_BUF_ST.FRES_KIND <> FRES_KIND_SRSV_TRNS_IN Then
                '(搬送元が解放済の場合)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[搬送元開放済]" & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "  ,ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '倉庫ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO      'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO '配列№
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                      '特定


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


            '************************
            '在庫引当情報の特定
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '在庫引当情報
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID                               'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[ﾊﾟﾚｯﾄID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '搬送指示QUEの特定
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '搬送指示QUE
            objTPLN_CARRY_QUE.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(True)                     '特定


            '************************
            '在庫移動
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '在庫移動ｸﾗｽ
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(入庫中ﾊﾞｯﾌｧ)
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_ST       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ｽﾃｰｼｮﾝﾊﾞｯﾌｧ)
            objSVR_100103.FPALLET_ID = strPALLET_ID                     'ﾊﾟﾚｯﾄID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SMENTE_CANCEL          'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '作業種別
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '搬送元ｸﾘｱﾌﾗｸﾞ
            objSVR_100103.STOCK_TRNS()                                  '移動


            '************************
            '搬送指示QUEの更新
            '************************
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON             '搬送指示状況(未実施)
            objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '現在日時
            objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                               '更新


            '************************
            '搬送制御送信IFの削除
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '搬送制御送信IFｸﾗｽ
            objTLIF_TRNS_SEND.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '削除


            '************************
            '搬送制御受信IFの削除
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '搬送制御受信IFｸﾗｽ
            objTLIF_TRNS_RECV.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV_PALLET()                        '削除


            '************************
            'ｼﾘｱﾙ関連付け削除
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)       'ｼﾘｱﾙ関連付けｸﾗｽ
            objTPRG_SERIAL.FPALLET_ID = strPALLET_ID                                'ﾊﾟﾚｯﾄID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                     '削除

            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                                '起動(搬送引当処理)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  出庫予約強制ｷｬﾝｾﾙ(搬送先引当てﾁｪｯｸ無し)                                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出庫予約強制ｷｬﾝｾﾙ(搬送先引当てﾁｪｯｸ無し)
    ''' </summary>
    ''' <param name="strPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <param name="intTRK_BUF_NO">ﾊﾞｯﾌｧ№</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_Cancel_OUT_RSV_NOTORSV(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/09/03 予定数ﾏｲﾅｽ1


            ''*********************************************
            ''予定数ﾏｲﾅｽ1
            ''*********************************************
            'Call UpdateYoteiNumMinus1(mFTRK_BUF_NO, mFPALLET_ID)


            '******************************************************************************************
            'ﾄﾗｯｷﾝｸﾞｷｬﾝｾﾙで、出荷指示.出荷引当梱数を元に戻す
            '******************************************************************************************
            Call Update_XSYUKKA_KON_RESERVE_Minus(mFPALLET_ID)


            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '倉庫ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = intTRK_BUF_NO                            'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS.FPALLET_ID = strPALLET_ID                              'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                        '特定

            '************************
            '在庫引当情報の特定
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)             '在庫引当情報
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID                                       'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                                '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[ﾊﾟﾚｯﾄID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/08/25  特殊処理用に作業種別を記憶
            Dim intFSAGYOU_KIND As Nullable(Of Integer) = objTSTS_HIKIATE.FSAGYOU_KIND      '作業種別
            ' ''↑↑↑↑↑↑************************************************************************************************************


            '************************
            '倉庫ﾊﾞｯﾌｧの更新
            '************************
            objTPRG_TRK_BUF_ASRS.FRSV_PALLET = DEFAULT_STRING                   '仮引当ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SZAIKO                    '引当状態
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


            '************************
            '予約ﾊﾞｯﾌｧの開放
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = objTPRG_TRK_BUF_ASRS.FPALLET_ID           '仮引当ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                             '開放


            '************************
            '在庫情報の更新
            '************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)             '在庫情報ﾃｰﾌﾞﾙｸﾗｽ
            objTRST_STOCK.FPALLET_ID = strPALLET_ID                                     'ﾊﾟﾚｯﾄID
            objTRST_STOCK.GET_TRST_STOCK_KONSAI(False)
            For ii As Integer = LBound(objTRST_STOCK.ARYME) To UBound(objTRST_STOCK.ARYME)
                objTRST_STOCK.ARYME(ii).FTR_RES_VOL = 0         '搬送引当量
                objTRST_STOCK.ARYME(ii).FUPDATE_DT = Now        '更新日時
                objTRST_STOCK.ARYME(ii).UPDATE_TRST_STOCK()     '更新
            Next
            objTRST_STOCK.ARYME_CLEAR()


            '************************
            '搬送指示QUEの削除
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)     '搬送指示QUEｸﾗｽ
            objTPLN_CARRY_QUE.FPALLET_ID = strPALLET_ID                               'ﾊﾟﾚｯﾄID
            objTPLN_CARRY_QUE.DELETE_TPLN_CARRY_QUE_PALLET()                            '削除


            '************************
            '在庫引当情報の削除
            '************************
            objTSTS_HIKIATE = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)  '在庫引当情報ｸﾗｽ
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID
            objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()       '削除


            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                                '起動(搬送引当処理)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  出庫予約強制ｷｬﾝｾﾙ                                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出庫予約強制ｷｬﾝｾﾙ
    ''' </summary>
    ''' <param name="strPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <param name="intTRK_BUF_NO">ﾊﾞｯﾌｧ№</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_Cancel_OUT_RSV(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            ''Dim intRet As RetCode                   '戻り値
            ''Dim strMsg As String                    'ﾒｯｾｰｼﾞ

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:A.Noto 2012/10/25 倉庫ﾊﾞｯﾌｧ特定ﾁｪｯｸｺﾒﾝﾄｱｳﾄ
            '                          (仮引当した在庫のﾄﾗｯｷﾝｸﾞは搬出予約にするが、その時点では搬送先が決まっていないため)
            ' ''************************
            ' ''倉庫ﾊﾞｯﾌｧの特定
            ' ''************************
            ''Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            ''objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = intTRK_BUF_NO                            'ﾊﾞｯﾌｧ№
            ''objTPRG_TRK_BUF_ASRS.FPALLET_ID = strPALLET_ID                              'ﾊﾟﾚｯﾄID
            ''intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                        '特定
            ''If IsNull(objTPRG_TRK_BUF_ASRS.FTR_TO) = True Then
            ''    '(搬送先未引当の場合)
            ''    strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[搬送先未引当]" & "[ﾄﾗｯｷﾝｸﾞ:" & objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS & "]"
            ''    Throw New UserException(strMsg)
            ''End If
            '↑↑↑↑↑↑************************************************************************************************************

            '************************
            '出庫予約ｷｬﾝｾﾙ
            '************************
            Mente_Cancel_OUT_RSV_NOTORSV(strPALLET_ID, intTRK_BUF_NO)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  出庫中強制ｷｬﾝｾﾙ                                                                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出庫中強制ｷｬﾝｾﾙ
    ''' </summary>
    ''' <param name="strPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <param name="intTRK_BUF_NO">ﾊﾞｯﾌｧ№</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_Cancel_OUT(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '************************
            '出庫中ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = intTRK_BUF_NO                           'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                       '特定


            '************************
            'ｽﾃｰｼｮﾝﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_ST.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO      'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO '配列№
            intRet = objTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF(True)                      '特定


            '************************
            '倉庫ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM      'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM '配列№
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                      '特定


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


            '************************
            '在庫引当情報の特定
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '在庫引当情報
            objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID           'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[ﾊﾟﾚｯﾄID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '搬送指示QUEの特定
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '搬送指示QUE
            objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID         'ﾊﾟﾚｯﾄID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(True)                     '特定


            '************************
            '搬送元開放ﾁｪｯｸ
            '************************
            If objTPRG_TRK_BUF_ASRS.FRSV_PALLET <> objTPRG_TRK_BUF_RELAY.FPALLET_ID Or _
               objTPRG_TRK_BUF_ASRS.FRES_KIND <> FRES_KIND_SRSV_TRNS_OUT Then
                '(搬送元が解放済の場合)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[搬送元開放済]" & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "  ,ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '在庫移動
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '在庫移動ｸﾗｽ
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(入庫中ﾊﾞｯﾌｧ)
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_ASRS     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(倉庫ﾊﾞｯﾌｧ)
            objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID 'ﾊﾟﾚｯﾄID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SMENTE_CANCEL          'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '作業種別
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '搬送元ｸﾘｱﾌﾗｸﾞ
            objSVR_100103.STOCK_TRNS()                                  '移動


            '************************
            '倉庫ﾊﾞｯﾌｧの更新
            '************************
            objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT     '搬出予約
            objTPRG_TRK_BUF_ASRS.FTRNS_FM = DEFAULT_STRING              '搬送指令用FM
            objTPRG_TRK_BUF_ASRS.FTRNS_TO = DEFAULT_STRING              '搬送指令用TO
            objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO = DEFAULT_INTEGER          'TO引当ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO = DEFAULT_INTEGER        'TO引当配列№
            objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_TO = DEFAULT_STRING      'TO表記用
            objTPRG_TRK_BUF_ASRS.FBUF_IN_DT = Now                       '更新日時
            objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                  '更新


            '************************
            '予約ﾊﾞｯﾌｧの解放
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = objTPRG_TRK_BUF_ASRS.FPALLET_ID       'ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                         '解放


            '************************
            '搬送指示QUEの更新
            '************************
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON             '搬送指示状況(未実施)
            objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '現在日時
            objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                               '更新


            '************************
            'ｼﾘｱﾙ関連付け削除
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)       'ｼﾘｱﾙ関連付けｸﾗｽ
            objTPRG_SERIAL.FPALLET_ID = strPALLET_ID                                'ﾊﾟﾚｯﾄID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                     '削除


            '************************
            '搬送制御送信IFの削除
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '搬送制御送信IFｸﾗｽ
            objTLIF_TRNS_SEND.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '削除


            '************************
            '搬送制御受信IFの削除
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '搬送制御受信IFｸﾗｽ
            objTLIF_TRNS_RECV.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV_PALLET()                        '削除


            '******************************************************************************************************
            '出庫予約強制ｷｬﾝｾﾙ(出庫棚予約まで戻ったので、さらにもう一段階戻る)
            '******************************************************************************************************
            Call Mente_Cancel_OUT_RSV(strPALLET_ID, objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO)


            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                                '起動(搬送引当処理)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  搬送中強制ｷｬﾝｾﾙ                                                                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 搬送中強制ｷｬﾝｾﾙ
    ''' </summary>
    ''' <param name="strPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <param name="intTRK_BUF_NO">ﾊﾞｯﾌｧ№</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_Cancel_TRNS(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '************************
            '搬送中ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = intTRK_BUF_NO                               'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = strPALLET_ID                                 'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                           '特定
            If IsNull(objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM) = True Then
                '(搬送元が解放済の場合)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[搬送元開放済]" & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "  ,ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '搬送元ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_FM.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM      'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM '配列№
            intRet = objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF(True)                      '特定


            If objTPRG_TRK_BUF_FM.FRSV_PALLET <> objTPRG_TRK_BUF_RELAY.FPALLET_ID Or _
               objTPRG_TRK_BUF_FM.FRES_KIND <> FRES_KIND_SRSV_TRNS_IN Then
                '(搬送元が解放済の場合)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[搬送元開放済]" & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "  ,ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '搬送先ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_TO.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO      'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO '配列№
            intRet = objTPRG_TRK_BUF_TO.GET_TPRG_TRK_BUF(True)                      '特定


            '************************
            '在庫引当情報の特定
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '在庫引当情報
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID                               'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[ﾊﾟﾚｯﾄID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '搬送指示QUEの特定
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '搬送指示QUE
            objTPLN_CARRY_QUE.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(True)                     '特定


            '************************
            '在庫移動
            '************************
            Dim intFTRK_BUF_NO_FM As Integer = objTPRG_TRK_BUF_FM.FTRK_BUF_NO
            Dim intFTR_FM_RELAY As Integer = objTPRG_TRK_BUF_RELAY.FTR_FM

            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '在庫移動ｸﾗｽ
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(入庫中ﾊﾞｯﾌｧ)
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_FM       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(倉庫ﾊﾞｯﾌｧ)
            objSVR_100103.FPALLET_ID = strPALLET_ID                     'ﾊﾟﾚｯﾄID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SMENTE_CANCEL          'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '作業種別
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '搬送元ｸﾘｱﾌﾗｸﾞ
            objSVR_100103.STOCK_TRNS()                                  '移動


            '************************
            '最終到達ﾊﾞｯﾌｧの特定
            '************************
            Dim intRSV_BUF_TO As Nullable(Of Integer) = DEFAULT_INTEGER                 'TO引当ﾄﾗｯｷﾝｸﾞ№
            Dim intRSV_ARRAY_TO As Nullable(Of Integer) = DEFAULT_INTEGER               'TO引当配列№
            Dim strDISP_ADDRESS_TO As String = DEFAULT_STRING                           'TO表記用ｱﾄﾞﾚｽ
            Dim objTPRG_TRK_BUF_END As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_END.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTR_TO                 '最終ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_END.FRSV_PALLET = mFPALLET_ID                               '仮引当ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_END.GET_TPRG_TRK_BUF_RSV_PALLET()
            If intRet = RetCode.OK Then
                '↓↓↓↓↓↓************************************************************************************************************
                'Checked SystemMate:N.Dounoshita 2012/01/26 「搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№」を使用しているのは間違いと思われる。
                '    intRSV_BUF_TO = objTPRG_TRK_BUF_END.FTRK_BUF_NO                         'TO引当ﾄﾗｯｷﾝｸﾞ№
                '    intRSV_ARRAY_TO = objTPRG_TRK_BUF_END.FTRK_BUF_ARRAY                    'TO引当配列№
                '↑↑↑↑↑↑************************************************************************************************************
                strDISP_ADDRESS_TO = objTPRG_TRK_BUF_END.FDISP_ADDRESS                  'TO表記用ｱﾄﾞﾚｽ
            End If


            '************************
            '予約ﾊﾞｯﾌｧの解放
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = strPALLET_ID                          'ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                         '解放

            '************************
            '最終到達ﾊﾞｯﾌｧの再予約
            '************************
            If IsNull(objTPRG_TRK_BUF_END.FTRK_BUF_ARRAY) = False Then
                '(最終ﾊﾞｯﾌｧが引当てされている場合)
                objTPRG_TRK_BUF_END.UPDATE_TPRG_TRK_BUF()
            End If

            '************************
            '搬送元ﾊﾞｯﾌｧの更新
            '************************
            '↓↓↓↓↓↓************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2012/01/26 「搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№」を使用しているのは間違いと思われる。
            'objTPRG_TRK_BUF_FM.FTRNS_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO
            'objTPRG_TRK_BUF_FM.FTRNS_TO = TO_STRING(intRSV_BUF_TO)
            '↑↑↑↑↑↑************************************************************************************************************
            objTPRG_TRK_BUF_FM.FRSV_BUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO
            objTPRG_TRK_BUF_FM.FRSV_ARRAY_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY
            objTPRG_TRK_BUF_FM.FRSV_BUF_TO = intRSV_BUF_TO
            objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO = intRSV_ARRAY_TO
            objTPRG_TRK_BUF_FM.FDISP_ADDRESS_TO = strDISP_ADDRESS_TO
            objTPRG_TRK_BUF_FM.FBUF_IN_DT = Now
            objTPRG_TRK_BUF_FM.UPDATE_TPRG_TRK_BUF()


            '************************
            '搬送指示QUEの更新
            '************************
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON             '搬送指示状況(未実施)
            objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '現在日時
            objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                               '更新

            '************************
            'ｼﾘｱﾙ関連付け削除
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)       'ｼﾘｱﾙ関連付けｸﾗｽ
            objTPRG_SERIAL.FPALLET_ID = strPALLET_ID                                'ﾊﾟﾚｯﾄID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                     '削除


            '************************
            '搬送制御送信IFの削除
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '搬送制御送信IFｸﾗｽ
            objTLIF_TRNS_SEND.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '削除


            '************************
            '搬送制御受信IFの削除
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '搬送制御受信IFｸﾗｽ
            objTLIF_TRNS_RECV.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV_PALLET()                        '削除

            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                                '起動(搬送引当処理)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  搬送中強制ｷｬﾝｾﾙ(ｸﾚｰﾝ搬送中)                                                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 搬送中強制ｷｬﾝｾﾙ(ｸﾚｰﾝ搬送中)
    ''' </summary>
    ''' <param name="strPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <param name="intTRK_BUF_NO">ﾊﾞｯﾌｧ№</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_Cancel_TRNS_CRANE(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '************************
            '搬送中中ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = intTRK_BUF_NO                               'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = strPALLET_ID                                 'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                           '特定
            If IsNull(objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM) = True Then
                '(搬送元が解放済の場合)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[搬送元開放済]" & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "  ,ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '元ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_FM.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM      'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM '配列№
            intRet = objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF(True)                      '特定


            '************************
            '搬送元開放
            '************************
            If objTPRG_TRK_BUF_FM.FRSV_PALLET <> objTPRG_TRK_BUF_RELAY.FPALLET_ID Or _
               objTPRG_TRK_BUF_FM.FRES_KIND <> FRES_KIND_SRSV_TRNS_IN Then
                '(搬送元が解放済の場合)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[搬送元開放済]" & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "  ,ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '先ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_TO.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO      'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO '配列№
            intRet = objTPRG_TRK_BUF_TO.GET_TPRG_TRK_BUF(True)                      '特定


            '************************
            '在庫引当情報の特定
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '在庫引当情報
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID                               'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[ﾊﾟﾚｯﾄID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '搬送指示QUEの特定
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '搬送指示QUE
            objTPLN_CARRY_QUE.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(True)                     '特定


            '************************
            '在庫移動
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '在庫移動ｸﾗｽ
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(入庫中ﾊﾞｯﾌｧ)
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_FM       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(ｽﾃｰｼｮﾝﾊﾞｯﾌｧ)
            objSVR_100103.FPALLET_ID = strPALLET_ID                     'ﾊﾟﾚｯﾄID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SMENTE_CANCEL          'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '作業種別
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '搬送元ｸﾘｱﾌﾗｸﾞ
            objSVR_100103.STOCK_TRNS()                                  '移動


            '************************
            'ｽﾃｰｼｮﾝﾊﾞｯﾌｧの更新
            '************************
            objTPRG_TRK_BUF_FM.FTRNS_FM = objTPRG_TRK_BUF_RELAY.FTRNS_FM
            objTPRG_TRK_BUF_FM.FTRNS_TO = objTPRG_TRK_BUF_RELAY.FTRNS_TO
            objTPRG_TRK_BUF_FM.FRSV_BUF_TO = DEFAULT_INTEGER
            objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO = DEFAULT_INTEGER
            objTPRG_TRK_BUF_FM.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO
            objTPRG_TRK_BUF_FM.FBUF_IN_DT = Now
            objTPRG_TRK_BUF_FM.UPDATE_TPRG_TRK_BUF()


            '************************
            '倉庫ﾊﾞｯﾌｧの更新
            '************************
            objTPRG_TRK_BUF_TO.CLEAR_TPRG_TRK_BUF()


            '************************
            '搬送指示QUEの更新
            '************************
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON             '搬送指示状況(未実施)
            objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '現在日時
            objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                               '更新


            '************************
            '搬送制御送信IFの削除
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '搬送制御送信IFｸﾗｽ
            objTLIF_TRNS_SEND.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '削除


            '************************
            '搬送制御受信IFの削除
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '搬送制御受信IFｸﾗｽ
            objTLIF_TRNS_RECV.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV_PALLET()                        '削除

            '************************
            'ｼﾘｱﾙ関連付け削除
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)       'ｼﾘｱﾙ関連付けｸﾗｽ
            objTPRG_SERIAL.FPALLET_ID = strPALLET_ID                                'ﾊﾟﾚｯﾄID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                     '削除

            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                                '起動(搬送引当処理)

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  倉庫間移動中強制ｷｬﾝｾﾙ                                                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 倉庫間移動中強制ｷｬﾝｾﾙ
    ''' </summary>
    ''' <param name="strPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <param name="intTRK_BUF_NO">ﾊﾞｯﾌｧ№</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_Cancel_SOUKO(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '************************
            '出庫中ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = intTRK_BUF_NO                           'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                       '特定


            '************************
            'ｽﾃｰｼｮﾝﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_ST.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO      'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO '配列№
            intRet = objTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF(True)                      '特定


            '************************
            '倉庫ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM      'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM '配列№
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                      '特定


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


            '************************
            '在庫引当情報の特定
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '在庫引当情報
            objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID           'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[ﾊﾟﾚｯﾄID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '搬送指示QUEの特定
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '搬送指示QUE
            objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID         'ﾊﾟﾚｯﾄID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(True)                     '特定


            '************************
            '在庫移動
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '在庫移動ｸﾗｽ
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(入庫中ﾊﾞｯﾌｧ)
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_ASRS     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(倉庫ﾊﾞｯﾌｧ)
            objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID 'ﾊﾟﾚｯﾄID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SMENTE_CANCEL          'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '作業種別
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '搬送元ｸﾘｱﾌﾗｸﾞ
            objSVR_100103.STOCK_TRNS()                                  '移動


            '************************
            '倉庫ﾊﾞｯﾌｧの更新
            '************************
            objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT     '搬出予約
            objTPRG_TRK_BUF_ASRS.FTRNS_FM = DEFAULT_STRING              '搬送指令用FM
            objTPRG_TRK_BUF_ASRS.FTRNS_TO = DEFAULT_STRING              '搬送指令用TO
            objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO = DEFAULT_INTEGER          'TO引当ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO = DEFAULT_INTEGER        'TO引当配列№
            objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_TO = DEFAULT_STRING      'TO表記用
            objTPRG_TRK_BUF_ASRS.FBUF_IN_DT = Now                       '更新日時
            objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                  '更新


            '************************
            '予約ﾊﾞｯﾌｧの解放
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            '↓↓↓↓↓↓************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/12/20 ﾊﾞｸﾞ修正
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = strPALLET_ID                          'ﾊﾟﾚｯﾄID
            'objTPRG_TRK_BUF_RSV.FRSV_PALLET = objTPRG_TRK_BUF_RELAY.FPALLET_ID      'ﾊﾟﾚｯﾄID
            '↑↑↑↑↑↑************************************************************************************************************
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                         '解放


            '************************
            '搬送指示QUEの更新
            '************************
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON             '搬送指示状況(未実施)
            objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '現在日時
            objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                               '更新


            '************************
            'ｼﾘｱﾙ関連付け削除
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)       'ｼﾘｱﾙ関連付けｸﾗｽ
            objTPRG_SERIAL.FPALLET_ID = strPALLET_ID                                'ﾊﾟﾚｯﾄID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                     '削除


            '************************
            '搬送制御送信IFの削除
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '搬送制御送信IFｸﾗｽ
            objTLIF_TRNS_SEND.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '削除


            '************************
            '搬送制御受信IFの削除
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '搬送制御受信IFｸﾗｽ
            objTLIF_TRNS_RECV.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV_PALLET()                        '削除


            '********************************
            '倉庫間移動中強制ｷｬﾝｾﾙ特殊処理
            '********************************
            '' ''Call Mente_Cancel_OUT_Special(strPALLET_ID, objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO)


            '******************************************************************************************************
            '倉庫間移動棚予約強制ｷｬﾝｾﾙ(出庫棚予約まで戻ったので、さらにもう一段階戻る)
            '******************************************************************************************************
            Call Mente_Cancel_SOUKO_RSV(strPALLET_ID, objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO)


            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                                '起動(搬送引当処理)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  倉庫間移動棚予約強制ｷｬﾝｾﾙ                                                            "
    '**********************************************************************************************
    '【機能】同上
    '【引数】[IN ] strPALLET_ID         :
    '        [IN ] intTRK_BUF_NO        :
    '【戻値】無し
    '**********************************************************************************************
    ''' <summary>
    ''' 倉庫間移動棚予約強制ｷｬﾝｾﾙ 
    ''' </summary>
    ''' <param name="strPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <param name="intTRK_BUF_NO">ﾊﾞｯﾌｧ№</param>
    ''' <remarks></remarks>
    Private Sub Mente_Cancel_SOUKO_RSV(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '************************
            '倉庫ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = intTRK_BUF_NO                            'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_ASRS.FPALLET_ID = strPALLET_ID                              'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                        '特定
            If IsNull(objTPRG_TRK_BUF_ASRS.FTR_TO) = True Then
                '(搬送先未引当の場合)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[搬送先未引当]" & "[ﾄﾗｯｷﾝｸﾞ:" & objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '在庫引当情報の特定
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '在庫引当情報
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID                               'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[ﾊﾟﾚｯﾄID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '倉庫ﾊﾞｯﾌｧの更新
            '************************
            objTPRG_TRK_BUF_ASRS.FRSV_PALLET = DEFAULT_STRING                   '仮引当ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SZAIKO                    '引当状態
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


            '************************
            '予約ﾊﾞｯﾌｧの開放
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = objTPRG_TRK_BUF_ASRS.FPALLET_ID           '仮引当ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                             '開放


            '************************
            '在庫情報の更新
            '************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)             '在庫情報ﾃｰﾌﾞﾙｸﾗｽ
            objTRST_STOCK.FPALLET_ID = strPALLET_ID                                     'ﾊﾟﾚｯﾄID
            objTRST_STOCK.GET_TRST_STOCK_KONSAI(False)
            For ii As Integer = LBound(objTRST_STOCK.ARYME) To UBound(objTRST_STOCK.ARYME)
                objTRST_STOCK.ARYME(ii).FTR_RES_VOL = 0         '搬送引当量
                objTRST_STOCK.ARYME(ii).FUPDATE_DT = Now        '更新日時
                objTRST_STOCK.ARYME(ii).UPDATE_TRST_STOCK()     '更新
            Next
            objTRST_STOCK.ARYME_CLEAR()


            '************************
            '搬送指示QUEの削除
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)     '搬送指示QUEｸﾗｽ
            objTPLN_CARRY_QUE.FPALLET_ID = strPALLET_ID                               'ﾊﾟﾚｯﾄID
            objTPLN_CARRY_QUE.DELETE_TPLN_CARRY_QUE_PALLET()                            '削除


            '************************
            '在庫引当情報の削除
            '************************
            objTSTS_HIKIATE = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)  '在庫引当情報ｸﾗｽ
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID
            objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()       '削除


            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                                '起動(搬送引当処理)


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
