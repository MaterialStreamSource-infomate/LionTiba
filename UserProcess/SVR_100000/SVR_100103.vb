'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】在庫移動ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100103
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義                                                                      "
    Private mobjTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF     '元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    Private mobjTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF     '先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    Private mFPALLET_ID As String                       'ﾊﾟﾚｯﾄID
    Private mFINOUT_STS As Nullable(Of Integer)         'IN/OUT     (入出庫実績用)
    Private mFSAGYOU_KIND As Nullable(Of Integer)       '作業種別   (入出庫実績用)
    Private mINTCLEAR_FM_FLAG As Nullable(Of Integer)   '移動元ｸﾘｱﾌﾗｸﾞ
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
    ''' =======================================
    ''' <summary>元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OBJTPRG_TRK_BUF_FM() As TBL_TPRG_TRK_BUF
        Get
            Return mobjTPRG_TRK_BUF_FM
        End Get
        Set(ByVal Value As TBL_TPRG_TRK_BUF)
            mobjTPRG_TRK_BUF_FM = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OBJTPRG_TRK_BUF_TO() As TBL_TPRG_TRK_BUF
        Get
            Return mobjTPRG_TRK_BUF_TO
        End Get
        Set(ByVal Value As TBL_TPRG_TRK_BUF)
            mobjTPRG_TRK_BUF_TO = Value
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
    ''' <summary>IN/OUT     (入出庫実績用)</summary>
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
    ''' =======================================
    ''' <summary>作業種別   (入出庫実績用)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FSAGYOU_KIND() As Nullable(Of Integer)
        Get
            Return mFSAGYOU_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSAGYOU_KIND = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>移動元ｸﾘｱﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property INTCLEAR_FM_FLAG() As Nullable(Of Integer)
        Get
            Return mINTCLEAR_FM_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mINTCLEAR_FM_FLAG = Value
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
#Region "  在庫移動                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在庫移動
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub STOCK_TRNS()
        Try
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            Dim intRet As Integer       '戻り値


            '************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '************************
            If IsNull(mobjTPRG_TRK_BUF_FM) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mobjTPRG_TRK_BUF_TO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFPALLET_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFINOUT_STS) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[IN/OUT]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFSAGYOU_KIND) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[作業種別]"
                Throw New UserException(strMsg)
            ElseIf (TO_INTEGER(mobjTPRG_TRK_BUF_FM.FRES_KIND) <> FRES_KIND_SZAIKO) And _
                   (TO_INTEGER(mobjTPRG_TRK_BUF_FM.FRES_KIND) <> FRES_KIND_SRSV_TRNS_OUT) Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ<>在庫/搬送予約]"
                Throw New UserException(strMsg)
            End If


            '************************
            '在庫情報の特定
            '************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '在庫情報ｸﾗｽ
            objTRST_STOCK.FPALLET_ID = mFPALLET_ID                          'ﾊﾟﾚｯﾄID
            intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)              '特定


            '************************
            '先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの更新
            '************************
            mobjTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SZAIKO                '在庫引当状態(在庫)
            mobjTPRG_TRK_BUF_TO.FPALLET_ID = mFPALLET_ID                    'ﾊﾟﾚｯﾄID
            mobjTPRG_TRK_BUF_TO.FBUF_IN_DT = Now                            'ﾊﾞｯﾌｧ入日時
            mobjTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()                       '更新


            '************************
            'INOUT実績追加
            '************************
            Dim objTLOG_INOUT As New TBL_TLOG_INOUT(Owner, ObjDb, ObjDbLog)         'INOUT実績ｸﾗｽ
            objTLOG_INOUT.FRESULT_DT = Now                                          '実績日時
            objTLOG_INOUT.FBUF_FM = mobjTPRG_TRK_BUF_FM.FTRK_BUF_NO                 '搬送元ﾊﾞｯﾌｧ№
            objTLOG_INOUT.FARRAY_FM = mobjTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY            '搬送元配列№
            objTLOG_INOUT.FBUF_TO = mobjTPRG_TRK_BUF_TO.FTRK_BUF_NO                 '搬送先ﾊﾞｯﾌｧ№
            objTLOG_INOUT.FARRAY_TO = mobjTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY            '搬送先配列№
            objTLOG_INOUT.FINOUT_STS = mFINOUT_STS                                  'IN/OUT
            objTLOG_INOUT.FSAGYOU_KIND = mFSAGYOU_KIND                              '作業種別
            objTLOG_INOUT.FDISP_ADDRESS_FM = mobjTPRG_TRK_BUF_FM.FDISP_ADDRESS      'FM表記用ｱﾄﾞﾚｽ
            objTLOG_INOUT.FDISP_ADDRESS_TO = mobjTPRG_TRK_BUF_TO.FDISP_ADDRESS      'TO表記用ｱﾄﾞﾚｽ
            If IsNull(mobjTPRG_TRK_BUF_FM.FDISPLOG_ADDRESS_FM) = True Then
                '(FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用がｾｯﾄされていない場合)
                objTLOG_INOUT.FDISPLOG_ADDRESS_FM = objTLOG_INOUT.FDISP_ADDRESS_FM              'FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            Else
                '(FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用がｾｯﾄされている場合)
                objTLOG_INOUT.FDISPLOG_ADDRESS_FM = mobjTPRG_TRK_BUF_FM.FDISPLOG_ADDRESS_FM     'FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            End If
            objTLOG_INOUT.FDISPLOG_ADDRESS_TO = mobjTPRG_TRK_BUF_TO.FDISP_ADDRESS   'TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            objTLOG_INOUT.FUSER_ID = FUSER_ID_SKOTEI                                'ﾕｰｻﾞｰID
            objTLOG_INOUT.OBJTRST_STOCK = objTRST_STOCK                             '在庫情報
            objTLOG_INOUT.ADD_TLOG_INOUT_ALL()                                      '追加


            '**************************************
            '画面用入出庫実績の出力切替ｽﾃｰﾀｽ取得
            '**************************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog) 'ｼｽﾃﾑ変数
            Dim strSINOUTTemp As String                                         '画面用入出庫実績の出力切替ｽﾃｰﾀｽ文字列
            Dim strSINOUT() As String                                           '画面用入出庫実績の出力切替ｽﾃｰﾀｽ配列
            strSINOUTTemp = objTPRG_SYS_HEN.SS000000_010
            strSINOUT = Split(strSINOUTTemp, KUGIRI01)


            '**********************************
            '画面用入出庫実績の出力判断
            '**********************************
            Dim blnExist As Boolean = False     '画面用入出庫実績の出力ﾌﾗｸﾞ
            For ii As Integer = LBound(strSINOUT) To UBound(strSINOUT)
                '(設定されたｽﾃｰﾀｽ数)
                If strSINOUT(ii) = mFINOUT_STS Then
                    blnExist = True
                    Exit For
                End If
            Next


            '************************
            '表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用の更新
            '************************
            mobjTPRG_TRK_BUF_TO.FDISPLOG_ADDRESS_TO = mobjTPRG_TRK_BUF_TO.FDISP_ADDRESS             'TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            If blnExist = True Then
                '(画面用入出庫実績の出力を行う場合)
                mobjTPRG_TRK_BUF_TO.FDISPLOG_ADDRESS_FM = mobjTPRG_TRK_BUF_TO.FDISP_ADDRESS         'FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            Else
                '(画面用入出庫実績の出力を行わない場合)
                If IsNull(mobjTPRG_TRK_BUF_TO.FDISPLOG_ADDRESS_FM) = True Then
                    '(設定されていない場合)
                    mobjTPRG_TRK_BUF_TO.FDISPLOG_ADDRESS_FM = mobjTPRG_TRK_BUF_FM.FDISP_ADDRESS     'TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
                End If
            End If


            '************************
            '元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧのｸﾘｱ
            '************************
            If TO_INTEGER(mINTCLEAR_FM_FLAG) = FLAG_ON Then
                '(搬送元ｸﾘｱﾌﾗｸﾞがONの場合)
                mobjTPRG_TRK_BUF_FM.CLEAR_TPRG_TRK_BUF()
            Else
                '(搬送元ｸﾘｱﾌﾗｸﾞがOFFの場合)
                mobjTPRG_TRK_BUF_FM.FRES_KIND = FRES_KIND_SAKI
                mobjTPRG_TRK_BUF_FM.FPALLET_ID = DEFAULT_STRING
                mobjTPRG_TRK_BUF_FM.FBUF_IN_DT = Now
                mobjTPRG_TRK_BUF_FM.UPDATE_TPRG_TRK_BUF()
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
