'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】在庫更新ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100104
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義                                                                      "
    Private mobjTPRG_TRK_BUF As TBL_TPRG_TRK_BUF    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙｸﾗｽ
    Private mobjTRST_STOCK As TBL_TRST_STOCK        '在庫情報ﾃｰﾌﾞﾙｸﾗｽ
    Private mFINOUT_STS As Nullable(Of Integer)     'IN/OUT     (入出庫実績用)
    Private mFSAGYOU_KIND As Nullable(Of Integer)   '作業種別   (入出庫実績用)
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙｸﾗｽ</summary>
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
    ''' <summary>在庫情報ﾃｰﾌﾞﾙｸﾗｽ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OBJTRST_STOCK() As TBL_TRST_STOCK
        Get
            Return mobjTRST_STOCK
        End Get
        Set(ByVal Value As TBL_TRST_STOCK)
            mobjTRST_STOCK = Value
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
#Region "  在庫更新                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在庫更新
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub STOCK_UPDATE()
        Try
            Dim strMsg As String        'ﾒｯｾｰｼﾞ


            '************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '************************
            If IsNull(mobjTPRG_TRK_BUF) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mobjTRST_STOCK) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[在庫情報]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFINOUT_STS) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[IN/OUT]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFSAGYOU_KIND) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[作業種別]"
                Throw New UserException(strMsg)
            End If


            '************************
            'INOUT実績追加
            '************************
            Dim objTLOG_INOUT As New TBL_TLOG_INOUT(Owner, ObjDb, ObjDbLog)         'INOUT実績ｸﾗｽ
            objTLOG_INOUT.FRESULT_DT = Now                                          '実績日時
            objTLOG_INOUT.FBUF_FM = mobjTPRG_TRK_BUF.FTRK_BUF_NO                    '搬送元ﾊﾞｯﾌｧ№
            objTLOG_INOUT.FARRAY_FM = mobjTPRG_TRK_BUF.FTRK_BUF_ARRAY               '搬送元配列№
            objTLOG_INOUT.FBUF_TO = mobjTPRG_TRK_BUF.FTRK_BUF_NO                    '搬送先ﾊﾞｯﾌｧ№
            objTLOG_INOUT.FARRAY_TO = mobjTPRG_TRK_BUF.FTRK_BUF_ARRAY               '搬送先配列№
            objTLOG_INOUT.FINOUT_STS = mFINOUT_STS                                  'IN/OUT
            objTLOG_INOUT.FSAGYOU_KIND = mFSAGYOU_KIND                              '作業種別
            objTLOG_INOUT.FDISP_ADDRESS_FM = mobjTPRG_TRK_BUF.FDISP_ADDRESS         'FM表記用ｱﾄﾞﾚｽ
            objTLOG_INOUT.FDISP_ADDRESS_TO = mobjTPRG_TRK_BUF.FDISP_ADDRESS         'TO表記用ｱﾄﾞﾚｽ
            objTLOG_INOUT.FUSER_ID = FUSER_ID_SKOTEI                                'ﾕｰｻﾞｰID
            objTLOG_INOUT.OBJTRST_STOCK = mobjTRST_STOCK                            '在庫情報
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
