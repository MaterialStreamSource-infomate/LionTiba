'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】在庫作成ｸﾗｽ
' 【作成】KSH
'**********************************************************************************************

#Region "  Imports"
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100101
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義"
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義"
    Private mobjTPRG_TRK_BUF As TBL_TPRG_TRK_BUF    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    Private mFPALLET_ID As String                   'ﾊﾟﾚｯﾄID
    Private mFLOT_NO_STOCK As String                '在庫ﾛｯﾄ№
    Private mFINOUT_STS As Nullable(Of Integer)     'IN/OUT     (入出庫実績用)
    Private mFSAGYOU_KIND As Nullable(Of Integer)   '作業種別   (入出庫実績用)
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
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
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ"
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
#Region "  在庫作成"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在庫作成
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub STOCK_ADD()
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
            ElseIf TO_INTEGER(mobjTPRG_TRK_BUF.FRES_KIND) <> FRES_KIND_SAKI And TO_INTEGER(mobjTPRG_TRK_BUF.FRES_KIND) <> FRES_KIND_SZAIKO Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ<>空棚 AND ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ<>在庫棚]"
                Throw New UserException(strMsg)
            End If


            '************************
            '在庫情報の特定
            '************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '在庫情報ｸﾗｽ
            objTRST_STOCK.FPALLET_ID = mFPALLET_ID                          'ﾊﾟﾚｯﾄID
            objTRST_STOCK.FLOT_NO_STOCK = mFLOT_NO_STOCK                    '在庫ﾛｯﾄ№
            intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)              '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TRST_STOCK & "[ﾊﾟﾚｯﾄID:" & objTRST_STOCK.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If

            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ更新
            '************************
            If TO_INTEGER(mobjTPRG_TRK_BUF.FRES_KIND) = FRES_KIND_SAKI Then
                '(空棚の場合)
                mobjTPRG_TRK_BUF.FRES_KIND = FRES_KIND_SZAIKO                '在庫引当状態  
                mobjTPRG_TRK_BUF.FPALLET_ID = mFPALLET_ID                   'ﾊﾟﾚｯﾄID
                mobjTPRG_TRK_BUF.FBUF_IN_DT = Now                           'ﾊﾞｯﾌｧ入日時
                mobjTPRG_TRK_BUF.UPDATE_TPRG_TRK_BUF()                      '更新
            End If



            '************************
            'INOUT実績追加
            '************************
            Dim objTLOG_INOUT As New TBL_TLOG_INOUT(Owner, ObjDb, ObjDbLog)         'INOUT実績ｸﾗｽ
            objTLOG_INOUT.FRESULT_DT = Now                                          '実績日時
            objTLOG_INOUT.FBUF_FM = DEFAULT_INTEGER                                 '搬送元ﾊﾞｯﾌｧ№
            objTLOG_INOUT.FARRAY_FM = DEFAULT_INTEGER                               '搬送元配列№
            objTLOG_INOUT.FBUF_TO = mobjTPRG_TRK_BUF.FTRK_BUF_NO                    '搬送先ﾊﾞｯﾌｧ№
            objTLOG_INOUT.FARRAY_TO = mobjTPRG_TRK_BUF.FTRK_BUF_ARRAY               '搬送先配列№
            objTLOG_INOUT.FINOUT_STS = mFINOUT_STS                                  'IN/OUT
            objTLOG_INOUT.FSAGYOU_KIND = mFSAGYOU_KIND                              '作業種別
            objTLOG_INOUT.FDISP_ADDRESS_FM = DEFAULT_STRING                         'FM表記用ｱﾄﾞﾚｽ
            objTLOG_INOUT.FDISP_ADDRESS_TO = mobjTPRG_TRK_BUF.FDISP_ADDRESS         'TO表記用ｱﾄﾞﾚｽ
            objTLOG_INOUT.FDISPLOG_ADDRESS_FM = DEFAULT_STRING                      'FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            objTLOG_INOUT.FDISPLOG_ADDRESS_TO = mobjTPRG_TRK_BUF.FDISP_ADDRESS      'TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            objTLOG_INOUT.FUSER_ID = FUSER_ID_SKOTEI                                'ﾕｰｻﾞｰID
            objTLOG_INOUT.OBJTRST_STOCK = objTRST_STOCK                             '在庫情報
            objTLOG_INOUT.ADD_TLOG_INOUT_ALL()                                      '追加


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
