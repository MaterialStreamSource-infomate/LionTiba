'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】在庫削除ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100102
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義                                                                      "
    Private mobjTPRG_TRK_BUF As TBL_TPRG_TRK_BUF    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    Private mFPALLET_ID As String                   'ﾊﾟﾚｯﾄID
    Private mFLOT_NO_STOCK As String                '在庫ﾛｯﾄ№
    Private mFINOUT_STS As Nullable(Of Integer)     'IN/OUT     (入出庫実績用)
    Private mFSAGYOU_KIND As Nullable(Of Integer)   '作業種別   (入出庫実績用)
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OBJTPRG_TRK_BUF() As TBL_TPRG_TRK_BUF
        Get
            Return mobjTPRG_TRK_BUF
        End Get
        Set(ByVal Value As TBL_TPRG_TRK_BUF)
            mobjTPRG_TRK_BUF = Value
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
    ''' <summary>在庫ﾛｯﾄ№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FLOT_NO_STOCK() As String
        Get
            Return mFLOT_NO_STOCK
        End Get
        Set(ByVal Value As String)
            mFLOT_NO_STOCK = Value
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
#Region "  在庫削除                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在庫削除
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub STOCK_DELETE()
        Try
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            Dim intRet As Integer       '戻り値


            '************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '************************
            If IsNull(mobjTPRG_TRK_BUF) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ]"
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
                '' ''ElseIf mobjTPRG_TRK_BUF.FRES_KIND <> FRES_KIND_SZAIKO Then
                '' ''    strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ<>在庫]"
                '' ''    Throw New UserException(strMsg)
            End If


            '*******************************
            '在庫情報の特定(ﾊﾟﾚｯﾄIDのみ)
            '*******************************
            Dim objTRST_STOCK_ALL As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '在庫情報ｸﾗｽ
            objTRST_STOCK_ALL.FPALLET_ID = mFPALLET_ID                          'ﾊﾟﾚｯﾄID
            intRet = objTRST_STOCK_ALL.GET_TRST_STOCK_KONSAI(True)              '特定


            '************************
            '予約ﾊﾞｯﾌｧの解放
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = mFPALLET_ID                           'ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                         '解放


            '************************
            'ﾊﾞｯﾌｧのｸﾘｱ
            '************************
            If UBound(objTRST_STOCK_ALL.ARYME) = 0 Or IsNull(mFLOT_NO_STOCK) = True Then
                '(在庫全て削除の場合)
                mobjTPRG_TRK_BUF.CLEAR_TPRG_TRK_BUF()
            End If
            objTRST_STOCK_ALL.ARYME_CLEAR()


            '**************************************
            '在庫情報の特定(ﾊﾟﾚｯﾄID,在庫ﾛｯﾄ№)
            '**************************************
            Dim objTRST_STOCK_ONE As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '在庫情報ｸﾗｽ
            objTRST_STOCK_ONE.FPALLET_ID = mFPALLET_ID                          'ﾊﾟﾚｯﾄID
            If IsNull(mFLOT_NO_STOCK) = False Then
                objTRST_STOCK_ONE.FLOT_NO_STOCK = mFLOT_NO_STOCK                '在庫ﾛｯﾄ№
            End If
            intRet = objTRST_STOCK_ONE.GET_TRST_STOCK_KONSAI(True)              '特定


            '************************
            'INOUT実績追加
            '************************
            Dim objTLOG_INOUT As New TBL_TLOG_INOUT(Owner, ObjDb, ObjDbLog)         'INOUT実績ｸﾗｽ
            objTLOG_INOUT.FRESULT_DT = Now                                          '実績日時
            objTLOG_INOUT.FBUF_FM = mobjTPRG_TRK_BUF.FTRK_BUF_NO                    '搬送元ﾊﾞｯﾌｧ№
            objTLOG_INOUT.FARRAY_FM = mobjTPRG_TRK_BUF.FTRK_BUF_ARRAY               '搬送元配列№
            objTLOG_INOUT.FBUF_TO = DEFAULT_INTEGER                                 '搬送先ﾊﾞｯﾌｧ№
            objTLOG_INOUT.FARRAY_TO = DEFAULT_INTEGER                               '搬送先配列№
            objTLOG_INOUT.FINOUT_STS = mFINOUT_STS                                  'IN/OUT
            objTLOG_INOUT.FSAGYOU_KIND = mFSAGYOU_KIND                              '作業種別
            objTLOG_INOUT.FDISP_ADDRESS_FM = mobjTPRG_TRK_BUF.FDISP_ADDRESS         'FM表記用ｱﾄﾞﾚｽ
            objTLOG_INOUT.FDISP_ADDRESS_TO = DEFAULT_STRING                         'TO表記用ｱﾄﾞﾚｽ
            objTLOG_INOUT.FDISPLOG_ADDRESS_FM = mobjTPRG_TRK_BUF.FDISP_ADDRESS      'FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            objTLOG_INOUT.FDISPLOG_ADDRESS_TO = DEFAULT_STRING                      'TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            objTLOG_INOUT.FUSER_ID = FUSER_ID_SKOTEI                                'ﾕｰｻﾞｰID
            objTLOG_INOUT.OBJTRST_STOCK = objTRST_STOCK_ONE                         '在庫情報
            objTLOG_INOUT.ADD_TLOG_INOUT_ALL()                                      '追加


            '************************
            '在庫の削除
            '************************
            objTRST_STOCK_ONE.FPALLET_ID = objTRST_STOCK_ONE.ARYME(0).FPALLET_ID
            If IsNull(mFLOT_NO_STOCK) = False Then
                objTRST_STOCK_ONE.FLOT_NO_STOCK = objTRST_STOCK_ONE.ARYME(0).FLOT_NO_STOCK
            End If
            objTRST_STOCK_ONE.DELETE_TRST_STOCK_ALL()
            objTRST_STOCK_ONE.ARYME_CLEAR()


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  在庫削除   (Public STOCK_DELETE) 古いﾊﾞｰｼﾞｮﾝ一応ﾊﾞｯｸｱｯﾌﾟ"
    ' '' '' ''**********************************************************************************************
    ' '' '' ''【機能】在庫削除
    ' '' '' ''【引数】無し
    ' '' '' ''【戻値】無し
    ' '' '' ''**********************************************************************************************
    '' '' ''Public Sub STOCK_DELETE()
    '' '' ''    Try
    '' '' ''        Dim strMsg As String        'ﾒｯｾｰｼﾞ
    '' '' ''        Dim intRet As Integer       '戻り値


    '' '' ''        '************************
    '' '' ''        'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
    '' '' ''        '************************
    '' '' ''        If IsNull(mobjTPRG_TRK_BUF) = True Then
    '' '' ''            strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ]"
    '' '' ''            Throw New UserException(strMsg)
    '' '' ''        ElseIf IsNull(mFPALLET_ID) = True Then
    '' '' ''            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
    '' '' ''            Throw New UserException(strMsg)
    '' '' ''        ElseIf IsNull(mFINOUT_STS) = True Then
    '' '' ''            strMsg = ERRMSG_ERR_PROPERTY & "[IN/OUT]"
    '' '' ''            Throw New UserException(strMsg)
    '' '' ''        ElseIf IsNull(mFSAGYOU_KIND) = True Then
    '' '' ''            strMsg = ERRMSG_ERR_PROPERTY & "[作業種別]"
    '' '' ''            Throw New UserException(strMsg)
    '' '' ''            '' ''ElseIf mobjTPRG_TRK_BUF.FRES_KIND <> FRES_KIND_ZAIKO Then
    '' '' ''            '' ''    strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ<>在庫]"
    '' '' ''            '' ''    Throw New UserException(strMsg)
    '' '' ''        End If


    '' '' ''        '************************
    '' '' ''        '在庫情報の特定
    '' '' ''        '************************
    '' '' ''        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '在庫情報ｸﾗｽ
    '' '' ''        objTRST_STOCK.FPALLET_ID = mFPALLET_ID                          'ﾊﾟﾚｯﾄID
    '' '' ''        intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI()                  '特定
    '' '' ''        If intRet = RetCode.NotFound Then
    '' '' ''            '(見つからない場合)
    '' '' ''            strMsg = ERRMSG_NOTFOUND_TRST_STOCK & "[ﾊﾟﾚｯﾄID:" & objTRST_STOCK.FPALLET_ID & "]"
    '' '' ''            Throw New UserException(strMsg)
    '' '' ''        End If


    '' '' ''        '************************
    '' '' ''        'ﾊﾞｯﾌｧのｸﾘｱ
    '' '' ''        '************************
    '' '' ''        mobjTPRG_TRK_BUF.CLEAR_TPRG_TRK_BUF()


    '' '' ''        '************************
    '' '' ''        'INOUT実績追加
    '' '' ''        '************************
    '' '' ''        Dim objTLOG_INOUT As New TBL_TLOG_INOUT(Owner, ObjDb, ObjDbLog)         'INOUT実績ｸﾗｽ
    '' '' ''        objTLOG_INOUT.FRESULT_DT = Now                                          '実績日時
    '' '' ''        objTLOG_INOUT.FBUF_FM = mobjTPRG_TRK_BUF.FTRK_BUF_NO                    '搬送元ﾊﾞｯﾌｧ№
    '' '' ''        objTLOG_INOUT.FARRAY_FM = mobjTPRG_TRK_BUF.FTRK_BUF_ARRAY               '搬送元配列№
    '' '' ''        objTLOG_INOUT.FBUF_TO = DEFAULT_INTEGER                                 '搬送先ﾊﾞｯﾌｧ№
    '' '' ''        objTLOG_INOUT.FARRAY_TO = DEFAULT_INTEGER                               '搬送先配列№
    '' '' ''        objTLOG_INOUT.FINOUT_STS = mFINOUT_STS                                  'IN/OUT
    '' '' ''        objTLOG_INOUT.FSAGYOU_KIND = mFSAGYOU_KIND                              '作業種別
    '' '' ''        objTLOG_INOUT.FDISP_ADDRESS_FM = mobjTPRG_TRK_BUF.FDISP_ADDRESS         'FM表記用ｱﾄﾞﾚｽ
    '' '' ''        objTLOG_INOUT.FDISP_ADDRESS_TO = DEFAULT_STRING                         'TO表記用ｱﾄﾞﾚｽ
    '' '' ''        objTLOG_INOUT.FDISPLOG_ADDRESS_FM = mobjTPRG_TRK_BUF.FDISP_ADDRESS      'FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
    '' '' ''        objTLOG_INOUT.FDISPLOG_ADDRESS_TO = DEFAULT_STRING                      'TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
    '' '' ''        objTLOG_INOUT.FUSER_ID = FUSER_ID_SKOTEI                                    'ﾕｰｻﾞｰID
    '' '' ''        objTLOG_INOUT.OBJTRST_STOCK = objTRST_STOCK                             '在庫情報
    '' '' ''        objTLOG_INOUT.ADD_TLOG_INOUT_ALL()                                      '追加


    '' '' ''        Dim ii As Integer
    '' '' ''        For ii = LBound(objTRST_STOCK.ARYME) To UBound(objTRST_STOCK.ARYME)
    '' '' ''            '(ﾙｰﾌﾟ:混載在庫数)

    '' '' ''            '************************
    '' '' ''            '在庫の削除
    '' '' ''            '************************
    '' '' ''            objTRST_STOCK.FPALLET_ID = objTRST_STOCK.ARYME(ii).FPALLET_ID
    '' '' ''            objTRST_STOCK.FLOT_NO_STOCK = objTRST_STOCK.ARYME(ii).FLOT_NO_STOCK
    '' '' ''            objTRST_STOCK.DELETE_TRST_STOCK_ALL()

    '' '' ''        Next


    '' '' ''    Catch ex As UserException
    '' '' ''        Call ComUser(ex, MeSyoriID)
    '' '' ''        Throw ex
    '' '' ''    Catch ex As Exception
    '' '' ''        Call ComError(ex, MeSyoriID)
    '' '' ''        Throw New System.Exception(ex.Message)
    '' '' ''    End Try

    '' '' ''End Sub
#End Region


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
