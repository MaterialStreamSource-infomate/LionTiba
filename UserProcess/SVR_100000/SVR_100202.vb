'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】在庫引当ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100202
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "
    Public Enum UpdateMode
        CHANGE_ALL = 0                                              '在庫情報＆ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ更新
        STOCK_ONLY = 1                                              '在庫情報のみ更新
        NON_UPDATE = 2                                              '更新なし
    End Enum

    Public Const CHK_PROC As Integer = 1                            '有効在庫数ﾁｪｯｸ
    Public Const RSV_PROC As Integer = 2                            '在庫確保処理
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義                                                                      "
    Private mFTRK_BUF_NO As Nullable(Of Integer)                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFPALLET_ID As String                                       'ﾊﾟﾚｯﾄID
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/25  引当条件に在庫ﾛｯﾄ№を追加
    Private mFLOT_NO_STOCK As String                                    '在庫ﾛｯﾄ№
    '↑↑↑↑↑↑************************************************************************************************************
    Private mFHINMEI_CD As String                                       '品名ｺｰﾄﾞ
    Private mFLOT_NO As String                                          'ﾛｯﾄ№
    Private mFEQ_CHK_KUBUN As Boolean = True                            '設備判定区分
    Private mFSYUKKA_TO_CD As String = ""                               '出荷先ｺｰﾄﾞ
    Private mFEQ_ID_CRN As String                                       '設備ID(ｸﾚｰﾝ)
    Private mBLNFullVol_Check As Boolean = False                        'ﾊﾟﾚｯﾄ内全数引当ﾌﾗｸﾞ
    Private mINTUpdateMode As UpdateMode = UpdateMode.CHANGE_ALL        '更新ﾓｰﾄﾞ
    Private mFSEIHIN_KUBUN As Nullable(Of Integer)                      '製品区分
    Private mFZAIKO_KUBUN As Nullable(Of Integer)                       '在庫区分
    Private mFHORYU_KUBUN As Nullable(Of Integer)                       '保留区分
    Private mINTMaxPlt As Nullable(Of Integer)                          '引当ﾊﾟﾚｯﾄ制限数
    Private mstrArrayPALLET_ID() As String                              '引当済みﾊﾟﾚｯﾄ(ﾊﾟﾚｯﾄID)
    Private mFTR_RES_VOL() As Nullable(Of Decimal)                      '引当済みﾊﾟﾚｯﾄ(搬送引当量)
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/27  棚形状種別を追加
    Private mFRAC_FORM As Nullable(Of Integer)                          '棚形状種別
    '↑↑↑↑↑↑************************************************************************************************************
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/25  引当条件に在庫ﾛｯﾄ№を追加
    Private mstrArrayFLOT_NO_STOCK() As String                          '引当済みﾊﾟﾚｯﾄ(在庫ﾛｯﾄ№)
    '↑↑↑↑↑↑************************************************************************************************************
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/27  OrderByを制御
    Private mstrOrderBy As String                                       'OrderBy
    '↑↑↑↑↑↑************************************************************************************************************
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/10/20  在庫引当に、ｺﾝﾍﾞｱの切離しも条件に追加。切離しされていたら、在庫引当の対象としない。
    Private mFBUF_TO As Nullable(Of Integer)           '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '↑↑↑↑↑↑************************************************************************************************************
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/06/05  端数制御
    Public Enum HasuMode
        All             'ﾌﾙPL、端数PL両方
        HasuPL          '端数PL のみ
        FullPL          'ﾌﾙPL   のみ
    End Enum
    Private mintHasu As HasuMode = HasuMode.All         '端数ﾌﾗｸﾞ
    '↑↑↑↑↑↑************************************************************************************************************
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/06/07  入庫区分
    Private mFIN_KUBUN As String                        '入庫区分
    '↑↑↑↑↑↑************************************************************************************************************
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:N.Dounoshita 2013/06/20 棚ﾌﾞﾛｯｸ追加
    Private mintAryXTANA_BLOCK() As Nullable(Of Integer)    '棚ﾌﾞﾛｯｸ
    '↑↑↑↑↑↑************************************************************************************************************
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:N.Dounoshita 2013/06/20 検査区分、検品区分を追加
    Private mXKENSA_KUBUN As Nullable(Of Integer)    '検査区分
    Private mXKENPIN_KUBUN As Nullable(Of Integer)   '検品区分
    Private mXMAKER_CD As String                     'ﾒｰｶ-ｺｰﾄﾞ
    '↑↑↑↑↑↑************************************************************************************************************
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FTRK_BUF_NO() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_NO = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ﾊﾟﾚｯﾄID</summary>
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
    ''' <summary>在庫ﾛｯﾄ№</summary>
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
    ''' <summary>品名ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FHINMEI_CD() As String
        Get
            Return mFHINMEI_CD
        End Get
        Set(ByVal Value As String)
            mFHINMEI_CD = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ﾛｯﾄ№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FLOT_NO() As String
        Get
            Return mFLOT_NO
        End Get
        Set(ByVal Value As String)
            mFLOT_NO = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>設備判定区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FEQ_CHK_KUBUN() As Boolean
        Get
            Return mFEQ_CHK_KUBUN
        End Get
        Set(ByVal Value As Boolean)
            mFEQ_CHK_KUBUN = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>出荷先ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FSYUKKA_TO_CD() As String
        Get
            Return mFSYUKKA_TO_CD
        End Get
        Set(ByVal Value As String)
            mFSYUKKA_TO_CD = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>設備ID(ｸﾚｰﾝ)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FEQ_ID_CRN() As String
        Get
            Return mFEQ_ID_CRN
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CRN = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ﾊﾟﾚｯﾄ内全数引当ﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property BLNFullVol_Check() As Boolean
        Get
            Return mBLNFullVol_Check
        End Get
        Set(ByVal Value As Boolean)
            mBLNFullVol_Check = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>更新ﾓｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property INTUpdateMode() As UpdateMode
        Get
            Return mINTUpdateMode
        End Get
        Set(ByVal Value As UpdateMode)
            mINTUpdateMode = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>製品区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FSEIHIN_KUBUN() As Nullable(Of Integer)
        Get
            Return mFSEIHIN_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSEIHIN_KUBUN = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>在庫区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FZAIKO_KUBUN() As Nullable(Of Integer)
        Get
            Return mFZAIKO_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFZAIKO_KUBUN = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>保留区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FHORYU_KUBUN() As Nullable(Of Integer)
        Get
            Return mFHORYU_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFHORYU_KUBUN = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>引当ﾊﾟﾚｯﾄ制限数</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property INTMaxPlt() As Nullable(Of Integer)
        Get
            Return mINTMaxPlt
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mINTMaxPlt = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>引当済みﾊﾟﾚｯﾄ(ﾊﾟﾚｯﾄID)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strArrayPALLET_ID() As String()
        Get
            Return mstrArrayPALLET_ID
        End Get
    End Property
    ''' =======================================
    ''' <summary>引当済みﾊﾟﾚｯﾄ(搬送引当量)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property FTR_RES_VOL(ByVal decIndex As Decimal) As Nullable(Of Decimal)
        Get
            Return mFTR_RES_VOL(decIndex)
        End Get
    End Property

    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/27  棚形状種別を追加
    ''' =======================================
    ''' <summary>棚形状種別</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FRAC_FORM() As String
        Get
            Return mFRAC_FORM
        End Get
        Set(ByVal Value As String)
            mFRAC_FORM = Value
        End Set
    End Property
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/25  引当条件に在庫ﾛｯﾄ№を追加
    ''' =======================================
    ''' <summary>引当済みﾊﾟﾚｯﾄ(在庫ﾛｯﾄ№)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strArrayFLOT_NO_STOCK() As String()
        Get
            Return mstrArrayFLOT_NO_STOCK
        End Get
    End Property
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/27  OrderByを制御
    ''' =======================================
    ''' <summary>OrderByを制御</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strOrderBy() As String
        Get
            Return mstrOrderBy
        End Get
        Set(ByVal Value As String)
            mstrOrderBy = Value
        End Set
    End Property
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/10/20  在庫引当に、ｺﾝﾍﾞｱの切離しも条件に追加。切離しされていたら、在庫引当の対象としない。
    ''' =======================================
    ''' <summary>搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FBUF_TO() As Nullable(Of Integer)
        Get
            Return mFBUF_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_TO = Value
        End Set
    End Property
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/06/05  端数制御
    ''' =======================================
    ''' <summary>端数ﾓｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intHasu() As HasuMode
        Get
            Return mintHasu
        End Get
        Set(ByVal Value As HasuMode)
            mintHasu = Value
        End Set
    End Property
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/06/07  入庫区分
    ''' =======================================
    ''' <summary>入庫区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FIN_KUBUN() As String
        Get
            Return mFIN_KUBUN
        End Get
        Set(ByVal Value As String)
            mFIN_KUBUN = Value
        End Set
    End Property
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:N.Dounoshita 2013/06/20 棚ﾌﾞﾛｯｸ追加
    ''' =======================================
    ''' <summary>棚ﾌﾞﾛｯｸ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intAryXTANA_BLOCK() As Nullable(Of Integer)()
        Get
            Return mintAryXTANA_BLOCK
        End Get
        Set(ByVal Value As Nullable(Of Integer)())
            mintAryXTANA_BLOCK = Value
        End Set
    End Property
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:N.Dounoshita 2013/06/20 保留区分、検査区分、検品区分を追加

    ''' =======================================
    ''' <summary>検査区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property XKENSA_KUBUN() As Nullable(Of Integer)
        Get
            Return mXKENSA_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXKENSA_KUBUN = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>検品区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property XKENPIN_KUBUN() As Nullable(Of Integer)
        Get
            Return mXKENPIN_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXKENPIN_KUBUN = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾒｰｶ-ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property XMAKER_CD() As String
        Get
            Return mXMAKER_CD
        End Get
        Set(ByVal Value As String)
            mXMAKER_CD = Value
        End Set
    End Property

    '↑↑↑↑↑↑************************************************************************************************************

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
#Region "　ｸﾛｰｽﾞ処理                                                                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾛｰｽﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub Close()
        Try
            '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実行
            MyBase.Close()

        Catch ex As Exception
            ComError(ex)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "　在庫引当処理                                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在庫引当処理
    ''' </summary>
    ''' <param name="decReqNum">引当要求数</param>
    ''' <returns>0:OK 1:NG 2:NotFound</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function FIND_STOCK(ByVal decReqNum As Decimal) As RetCode
        Try
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            Dim intRet As RetCode                   '戻り値


            '************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '************************
            If decReqNum < 0 Then
                strMsg = ERRMSG_ERR_PROPERTY & "[引当要求数]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo]"
                Throw New UserException(strMsg)
            End If


            '************************
            '有効在庫数ﾁｪｯｸ
            '************************
            intRet = CheckStock()
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                Return RetCode.NotFound
            ElseIf intRet = RetCode.NG Then
                '(その他NGの場合)
                Return RetCode.NG
            End If


            '************************
            '在庫確保
            '************************
            intRet = ReserveStock(decReqNum)
            If intRet = RetCode.NotEnough Then
                '(不足している場合)
                Return RetCode.NotEnough
            ElseIf intRet = RetCode.NG Then
                '(その他NGの場合)
                Return RetCode.NG
            End If


            Return RetCode.OK
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  有効在庫数ﾁｪｯｸ                                                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 有効在庫数ﾁｪｯｸ
    ''' </summary>
    ''' <returns>0:OK 1:NG 2:NotFound</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function CheckStock() As RetCode
        Try
            Dim objDataSet As New DataSet               'ﾃﾞｰﾀｾｯﾄ
            Try
                Dim strSQL As String                    'SQL文


                '************************
                'SQL文生成
                '************************
                strSQL = MakeSQL(CHK_PROC)


                '************************
                '抽出
                '************************
                objDataSet.Clear()
                ObjDb.SQL = strSQL
                ObjDb.GetDataSet("TRST_STOCK", objDataSet)


                '************************
                '有効在庫数ﾁｪｯｸ
                '************************
                If TO_DECIMAL_NULLABLE(objDataSet.Tables("TRST_STOCK").Rows(0).Item("FTR_VOL")) - _
                   TO_DECIMAL_NULLABLE(objDataSet.Tables("TRST_STOCK").Rows(0).Item("FTR_RES_VOL")) > 0 Then

                    '(搬送管理量-搬送引当量>0の場合)
                    Return RetCode.OK
                Else
                    Return RetCode.NotFound
                End If


            Catch ex As UserException
                Throw ex
            Catch ex As Exception
                Throw New System.Exception(ex.Message)
            Finally
                objDataSet.Dispose()
                objDataSet = Nothing
            End Try
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  在庫確保処理                                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在庫確保処理
    ''' </summary>
    ''' <param name="decReqNum">引当要求数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function ReserveStock(ByVal decReqNum As Decimal) As Integer
        Try
            Dim objDataSet As New DataSet               'ﾃﾞｰﾀｾｯﾄ
            Try
                Dim strMsg As String                    'ﾒｯｾｰｼﾞ
                Dim intRet As RetCode                   '戻り値
                Dim strSQL As String                    'SQL文
                Dim oRow As DataRow                     '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
                Dim decRsv As Decimal = 0               '引当済み数
                Dim intPlt As Integer = 0               '引当済みﾊﾟﾚｯﾄ数


                '************************
                'SQL文生成
                '************************
                strSQL = MakeSQL(RSV_PROC)


                '************************
                '抽出
                '************************
                objDataSet.Clear()
                ObjDb.SQL = strSQL
                ObjDb.GetDataSet("TRST_STOCK", objDataSet)


                '************************
                'ﾊﾟﾚｯﾄID配列を初期化
                '************************
                mstrArrayPALLET_ID = Nothing


                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/10/20  在庫引当に、ｺﾝﾍﾞｱの切離しも条件に追加。切離しされていたら、在庫引当の対象としない。

                Dim blnGetPallet As Boolean = False      '在庫取得ﾌﾗｸﾞ

                '↑↑↑↑↑↑************************************************************************************************************


                If objDataSet.Tables("TRST_STOCK").Rows.Count > 0 Then
                    For Each oRow In objDataSet.Tables("TRST_STOCK").Rows


                        '↓↓↓↓↓↓************************************************************************************************************
                        'SystemMate:N.Dounoshita 2012/10/20  在庫引当に、ｺﾝﾍﾞｱの切離しも条件に追加。切離しされていたら、在庫引当の対象としない。


                        '************************************************
                        'ｺﾝﾍﾞｱ切離ﾁｪｯｸ
                        '************************************************
                        Dim blnEQCut As Boolean     '切離ﾌﾗｸﾞ
                        blnEQCut = SVR_100202_CheckTMST_CNV_CRANE(TO_STRING(oRow.Item("FPALLET_ID")), mFTRK_BUF_NO, mFBUF_TO)
                        If blnEQCut = True Then
                            '(切離中の場合)
                            Continue For
                        End If
                        blnGetPallet = True


                        '↑↑↑↑↑↑************************************************************************************************************


                        If mINTUpdateMode = UpdateMode.CHANGE_ALL Then
                            Dim intRetSQL As Integer    'SQL実行戻り値

                            strSQL = ""
                            strSQL &= vbCrLf & "UPDATE"
                            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
                            strSQL &= vbCrLf & " SET"
                            strSQL &= vbCrLf & "    FRES_KIND = '" & TO_STRING(FRES_KIND_SRSV_TRNS_OUT) & "'"
                            strSQL &= vbCrLf & " WHERE"
                            strSQL &= vbCrLf & "        FPALLET_ID = '" & TO_STRING(oRow.Item("FPALLET_ID")) & "'"
                            strSQL &= vbCrLf & "    AND FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)
                            strSQL &= vbCrLf
                            intRetSQL = ObjDb.Execute(strSQL)
                            If intRetSQL = -1 Then
                                '(SQLｴﾗｰ)
                                strSQL = Replace(strSQL, vbCrLf, "")
                                strMsg = ERRMSG_ERR_UPDATE & ObjDb.ErrMsg & "【" & strSQL & "】"
                                Throw New UserException(strMsg)
                            End If
                            If intRetSQL < 1 Then
                                strMsg = ERRMSG_NOTFOUND_TPRG_TRK & "[ﾊﾞｯﾌｧ№:" & TO_STRING(mFTRK_BUF_NO) & "  ,ﾊﾟﾚｯﾄID:" & TO_STRING(oRow.Item("FPALLET_ID")) & "]"
                                Throw New UserException(strMsg)
                            End If

                        End If


                        '************************
                        '在庫情報の特定
                        '************************
                        Dim decNowRsv As Decimal                                            '今回引き当て量
                        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)     '在庫情報ｸﾗｽ
                        objTRST_STOCK.FPALLET_ID = TO_STRING(oRow.Item("FPALLET_ID"))       'ﾊﾟﾚｯﾄID
                        objTRST_STOCK.FLOT_NO_STOCK = TO_STRING(oRow.Item("FLOT_NO_STOCK")) '在庫ﾛｯﾄNo
                        intRet = objTRST_STOCK.GET_TRST_STOCK(True)                         '特定


                        '************************
                        '在庫情報の更新
                        '************************
                        If decReqNum = 0 Then
                            '(今回引当量が指定無しの場合)
                            '引当てたい搬送管理量が不明で、かつ1ﾊﾟﾚｯﾄの全ての搬送管理量を引当てしたい場合に使用
                            decNowRsv = TO_NUMBER(objTRST_STOCK.FTR_VOL) - TO_NUMBER(objTRST_STOCK.FTR_RES_VOL)         '今回引き当て量
                            decRsv += decNowRsv                                                                         '引当済み数をｶｳﾝﾄ
                            objTRST_STOCK.FTR_RES_VOL = objTRST_STOCK.FTR_VOL                                           '搬送引当量を設定
                        Else
                            '(今回引当量が指定ありの場合)
                            '引当てたい搬送管理量が明確な場合に使用
                            If (TO_NUMBER(objTRST_STOCK.FTR_VOL) - TO_NUMBER(objTRST_STOCK.FTR_RES_VOL)) > (decReqNum - decRsv) And mBLNFullVol_Check = False Then
                                '(搬送管理量 > 搬送引当量 になる場合、もしくは 搬送管理量 > 搬送引当量 にしたい場合)
                                objTRST_STOCK.FTR_RES_VOL = TO_NUMBER(objTRST_STOCK.FTR_RES_VOL) + (decReqNum - decRsv)               '搬送引当量を設定
                                decNowRsv = decReqNum - decRsv                                  '今回引き当て量
                                decRsv += decNowRsv                                             '引当済み数をｶｳﾝﾄ
                            Else
                                '(搬送管理量 = 搬送引当量 になる場合、もしくは 搬送管理量 = 搬送引当量 にしたい場合)
                                decNowRsv = TO_NUMBER(objTRST_STOCK.FTR_VOL) - TO_NUMBER(objTRST_STOCK.FTR_RES_VOL)     '今回引き当て量
                                decRsv += TO_NUMBER(objTRST_STOCK.FTR_VOL) - TO_NUMBER(objTRST_STOCK.FTR_RES_VOL)       '引当済み数をｶｳﾝﾄ
                                objTRST_STOCK.FTR_RES_VOL = objTRST_STOCK.FTR_VOL               '搬送引当量を設定
                            End If
                        End If
                        If mINTUpdateMode = UpdateMode.CHANGE_ALL Or mINTUpdateMode = UpdateMode.STOCK_ONLY Then
                            '(更新ﾓｰﾄﾞが全更新/在庫更新の場合)
                            objTRST_STOCK.UPDATE_TRST_STOCK()
                        End If


                        '************************
                        '引当済みﾊﾟﾚｯﾄ数をｶｳﾝﾄ
                        '************************
                        intPlt += 1


                        '************************
                        '処理されたﾊﾟﾚｯﾄID保持
                        '************************
                        intRet = ArrayFindData(mstrArrayPALLET_ID, TO_STRING(oRow.Item("FPALLET_ID")))
                        If intRet = -1 Then
                            '(ﾊﾟﾚｯﾄIDが見つからなかった場合)
                            If IsNull(mstrArrayPALLET_ID) Then
                                ReDim mstrArrayPALLET_ID(0)
                            Else
                                ReDim Preserve mstrArrayPALLET_ID(UBound(mstrArrayPALLET_ID) + 1)
                            End If
                            mstrArrayPALLET_ID(UBound(mstrArrayPALLET_ID)) = TO_STRING(oRow.Item("FPALLET_ID"))
                        End If


                        '************************
                        '処理された搬送管理量保持
                        '************************
                        Dim intIndex As Integer = UBound(mstrArrayPALLET_ID)
                        ReDim Preserve mFTR_RES_VOL(intIndex)
                        mFTR_RES_VOL(intIndex) = decNowRsv


                        '↓↓↓↓↓↓************************************************************************************************************
                        'SystemMate:N.Dounoshita 2012/04/25  引当条件に在庫ﾛｯﾄ№を追加

                        '************************
                        '処理された在庫ﾛｯﾄ№保持
                        '************************
                        ReDim Preserve mstrArrayFLOT_NO_STOCK(intIndex)
                        mstrArrayFLOT_NO_STOCK(intIndex) = TO_STRING(oRow.Item("FLOT_NO_STOCK"))

                        '↑↑↑↑↑↑************************************************************************************************************


                        '↓↓↓↓↓↓************************************************************************************************************
                        'JobMate:N.Dounoshita 2013/06/20 棚ﾌﾞﾛｯｸ追加

                        '************************
                        '処理された棚ﾌﾞﾛｯｸ保持
                        '************************
                        ReDim Preserve mintAryXTANA_BLOCK(intIndex)
                        mintAryXTANA_BLOCK(intIndex) = TO_STRING(oRow.Item("XTANA_BLOCK"))

                        '↑↑↑↑↑↑************************************************************************************************************


                        '************************
                        '引当ﾊﾟﾚｯﾄ制限数判定
                        '************************
                        If decReqNum > 0 Then
                            If TO_INTEGER(mINTMaxPlt) > 0 Then
                                If TO_INTEGER(mINTMaxPlt) <= intPlt Then
                                    Exit For
                                End If
                            End If
                        End If


                        '************************
                        '要求数判定
                        '************************
                        If decReqNum > 0 Then
                            If decReqNum <= decRsv Then
                                Exit For
                            End If
                        End If
                    Next

                    '************************
                    '要求数判定
                    '************************
                    '↓↓↓↓↓↓************************************************************************************************************
                    'SystemMate:N.Dounoshita 2012/10/20  在庫引当に、ｺﾝﾍﾞｱの切離しも条件に追加。切離しされていたら、在庫引当の対象としない。
                    If blnGetPallet = True Then
                        '(在庫取得していた場合)
                        '↑↑↑↑↑↑************************************************************************************************************

                        If decReqNum = 0 Then
                            Return RetCode.OK
                        Else
                            If TO_INTEGER(mINTMaxPlt) > 0 And TO_INTEGER(mINTMaxPlt) <= intPlt Then
                                Return RetCode.OK
                            Else
                                If decReqNum <= decRsv Then
                                    Return RetCode.OK
                                Else
                                    Return RetCode.NotEnough
                                End If
                            End If
                        End If

                        '↓↓↓↓↓↓************************************************************************************************************
                        'SystemMate:N.Dounoshita 2012/10/20  在庫引当に、ｺﾝﾍﾞｱの切離しも条件に追加。切離しされていたら、在庫引当の対象としない。
                    Else
                        '(在庫取得していない場合)
                        Return RetCode.NotEnough
                    End If
                    '↑↑↑↑↑↑************************************************************************************************************

                Else
                    Throw New System.Exception(ERRMSG_NOTFOUND_TRST_STOCK & "【" & strSQL & "】")
                End If


                Return RetCode.NotFound
            Catch ex As UserException
                Call ComUser(ex, MeSyoriID)
                Throw ex
            Catch ex As Exception
                Call ComError(ex, MeSyoriID)
                Throw New System.Exception(ex.Message)
            Finally
                objDataSet.Dispose()
                objDataSet = Nothing
            End Try
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "　在庫引当SQL文生成                                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在庫引当SQL文生成
    ''' </summary>
    ''' <param name="intProcKubun">1:有効在庫数ﾁｪｯｸ 2:在庫確保処理</param>
    ''' <returns>SQL文</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function MakeSQL(ByVal intProcKubun As Integer) As String
        Try
            Dim intRet As Integer = 0
            Dim objDataSet As New DataSet               'ﾃﾞｰﾀｾｯﾄ
            Try
                Dim strSQL As String = ""               'SQL文


                '************************
                'SQL文生成
                '************************
                strSQL = ""
                strSQL &= vbCrLf & "SELECT "
                If intProcKubun = CHK_PROC Then
                    '(有効在庫数ﾁｪｯｸの場合)
                    strSQL &= vbCrLf & "   SUM(FTR_VOL) AS FTR_VOL "                           '搬送管理量(総在庫数)
                    strSQL &= vbCrLf & "  ,SUM(FTR_RES_VOL) AS FTR_RES_VOL "                   '搬送引当量(総引当済み数)
                ElseIf intProcKubun = RSV_PROC Then
                    '(在庫確保処理の場合)
                    strSQL &= vbCrLf & "   FTR_VOL "                                           '搬送管理量
                    strSQL &= vbCrLf & "  ,FPALLET_ID "                                        'ﾊﾟﾚｯﾄID
                    strSQL &= vbCrLf & "  ,FLOT_NO_STOCK "                                     '在庫ﾛｯﾄ№
                    strSQL &= vbCrLf & "  ,FARRIVE_DT AS FARRIVE_DT"                           '在庫発生日時
                    '↓↓↓↓↓↓************************************************************************************************************
                    'SystemMate:N.Dounoshita 2012/04/27  OrderByを制御
                    strSQL &= vbCrLf & "  ,FSERCH_NO "                                          '空検索順№
                    strSQL &= vbCrLf & "  ,FRAC_FORM "                                          '棚形状種別
                    '↑↑↑↑↑↑************************************************************************************************************
                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:N.Dounoshita 2013/06/20 棚ﾌﾞﾛｯｸ追加
                    strSQL &= vbCrLf & "  ,XTANA_BLOCK "                                        '棚ﾌﾞﾛｯｸ
                    '↑↑↑↑↑↑************************************************************************************************************
                End If
                strSQL &= vbCrLf & "FROM "
                strSQL &= vbCrLf & "( "
                strSQL &= vbCrLf & "    SELECT B.FTRK_BUF_ARRAY AS FTRK_BUF_ARRAY "             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列No
                strSQL &= vbCrLf & "          ,B.FPALLET_ID AS FPALLET_ID "                     'ﾊﾟﾚｯﾄID
                strSQL &= vbCrLf & "          ,A.FLOT_NO_STOCK AS FLOT_NO_STOCK "               '在庫ﾛｯﾄ№
                strSQL &= vbCrLf & "          ,A.FHINMEI_CD AS FHINMEI_CD "                     '品名ｺｰﾄﾞ
                strSQL &= vbCrLf & "          ,A.FLOT_NO AS FLOT_NO "                           'ﾛｯﾄ№
                strSQL &= vbCrLf & "          ,A.FTR_VOL AS FTR_VOL "                           '搬送管理量
                strSQL &= vbCrLf & "          ,A.FTR_RES_VOL AS FTR_RES_VOL "                   '搬送引当量
                strSQL &= vbCrLf & "          ,A.FARRIVE_DT AS FARRIVE_DT "                     '在庫発生日時
                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/04/27  OrderByを制御
                strSQL &= vbCrLf & "          ,B.FSERCH_NO AS FSERCH_NO "                       '空検索順№
                strSQL &= vbCrLf & "          ,B.FRAC_FORM AS FRAC_FORM "                       '棚形状種別
                '↑↑↑↑↑↑************************************************************************************************************
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:N.Dounoshita 2013/06/20 棚ﾌﾞﾛｯｸ追加
                strSQL &= vbCrLf & "          ,B.XTANA_BLOCK AS XTANA_BLOCK "                   '棚ﾌﾞﾛｯｸ
                '↑↑↑↑↑↑************************************************************************************************************
                strSQL &= vbCrLf & "    FROM TRST_STOCK A "
                strSQL &= vbCrLf & "        ,TPRG_TRK_BUF B"
                strSQL &= vbCrLf & "        ,TMST_CRANE E "
                strSQL &= vbCrLf & "        ,TSTS_EQ_CTRL F "
                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2013/06/05  端数制御
                If mintHasu = HasuMode.FullPL Or mintHasu = HasuMode.HasuPL Then
                    strSQL &= vbCrLf & "        ,TMST_ITEM G "
                End If
                '↑↑↑↑↑↑************************************************************************************************************

                strSQL &= vbCrLf & "	WHERE "
                strSQL &= vbCrLf & "	      A.FPALLET_ID = B.FPALLET_ID"                      '結合条件

                strSQL &= vbCrLf & "	  AND E.FEQ_ID     = F.FEQ_ID"                          '結合条件

                strSQL &= vbCrLf & "	  AND E.FCRANE_ROW1 <= B.FRAC_RETU "                    '結合条件
                strSQL &= vbCrLf & "	  AND B.FRAC_RETU   <= E.FCRANE_ROW2 "                  '結合条件


                strSQL &= vbCrLf & "	  AND B.FTRK_BUF_NO = " & Trim(Str(mFTRK_BUF_NO))       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                strSQL &= vbCrLf & "	  AND B.FREMOVE_KIND = " & Trim(Str(FLAG_OFF))          '禁止有無
                strSQL &= vbCrLf & "	  AND B.FRES_KIND = " & Trim(Str(FRES_KIND_SZAIKO))     '在庫引当状態
                strSQL &= vbCrLf & "	  AND A.FTR_VOL > A.FTR_RES_VOL"                    '有効在庫数判定
                strSQL &= vbCrLf & "	  AND E.FTRK_BUF_NO = " & Trim(Str(mFTRK_BUF_NO))
                strSQL &= vbCrLf & "	  AND F.FEQ_CUT_STS = " & Trim(Str(FLAG_OFF))
                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2013/06/05  端数制御
                If mintHasu = HasuMode.FullPL Or mintHasu = HasuMode.HasuPL Then
                    strSQL &= vbCrLf & "	  AND A.FHINMEI_CD = G.FHINMEI_CD "                 '品名ｺｰﾄﾞ
                    If mintHasu = HasuMode.FullPL Then
                        strSQL &= vbCrLf & "	  AND A.FTR_VOL = G.FNUM_IN_PALLET "            'PL毎積載数
                    Else
                        strSQL &= vbCrLf & "	  AND A.FTR_VOL <> G.FNUM_IN_PALLET "           'PL毎積載数
                    End If
                End If
                '↑↑↑↑↑↑************************************************************************************************************
                If mFEQ_ID_CRN <> "" Then
                    '(ｸﾚｰﾝ指定がある場合)
                    strSQL &= vbCrLf & "	  AND E.FEQ_ID = '" & mFEQ_ID_CRN & "'"
                End If

                '========================
                'ｵﾌﾟｼｮﾝ条件指定
                '========================
                If mFPALLET_ID <> DEFAULT_STRING Then
                    '(ﾊﾟﾚｯﾄID指定有りの場合)
                    strSQL &= vbCrLf & "      AND A.FPALLET_ID = '" & mFPALLET_ID & "'"                 'ﾊﾟﾚｯﾄID
                End If

                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/04/27  棚形状種別を追加
                If IsNotNull(mFRAC_FORM) Then
                    '(棚形状種別指定有りの場合)
                    strSQL &= vbCrLf & "      AND B.FRAC_FORM = " & mFRAC_FORM                      '棚形状種別
                End If
                '↑↑↑↑↑↑************************************************************************************************************

                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2013/06/07  入庫区分
                If IsNotNull(mFIN_KUBUN) Then
                    '(入庫区分指定有りの場合)
                    strSQL &= vbCrLf & "      AND A.FIN_KUBUN IN (" & mFIN_KUBUN & ")"              '入庫区分
                End If
                '↑↑↑↑↑↑************************************************************************************************************

                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/04/25  引当条件に在庫ﾛｯﾄ№を追加
                If mFLOT_NO_STOCK <> DEFAULT_STRING Then
                    '(在庫ﾛｯﾄ№指定有りの場合)
                    strSQL &= vbCrLf & "      AND A.FLOT_NO_STOCK = '" & mFLOT_NO_STOCK & "'"           '在庫ﾛｯﾄ№
                End If
                '↑↑↑↑↑↑************************************************************************************************************
                If mFHINMEI_CD <> DEFAULT_STRING Then
                    '(品名ｺｰﾄﾞ指定有りの場合)
                    strSQL &= vbCrLf & "      AND A.FHINMEI_CD = '" & mFHINMEI_CD & "'"                 '品名ｺｰﾄﾞ
                End If
                If mFLOT_NO <> DEFAULT_STRING Then
                    '(ﾛｯﾄ№指定有りの場合)
                    strSQL &= vbCrLf & "      AND A.FLOT_NO = '" & mFLOT_NO & "'"                       'ﾛｯﾄ№
                End If
                If IsNull(mFSEIHIN_KUBUN) = False Then
                    '(製品区分指定有りの場合)
                    strSQL &= vbCrLf & "      AND A.FSEIHIN_KUBUN = " & Trim(Str(mFSEIHIN_KUBUN))       '製品区分
                End If
                If IsNull(mFZAIKO_KUBUN) = False Then
                    '(在庫区分指定有りの場合)
                    strSQL &= vbCrLf & "      AND A.FZAIKO_KUBUN = " & Trim(Str(mFZAIKO_KUBUN))         '在庫区分
                End If

                If IsNull(mFHORYU_KUBUN) = False Then
                    '(保留区分指定有りの場合)
                    strSQL &= vbCrLf & "      AND A.FHORYU_KUBUN = " & Trim(Str(mFHORYU_KUBUN))         '保留区分
                End If

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:N.Dounoshita 2013/06/20 検査区分、検品区分を追加

                If IsNull(mXKENSA_KUBUN) = False Then
                    '(検査区分指定有りの場合)
                    strSQL &= vbCrLf & "      AND A.XKENSA_KUBUN = " & Trim(Str(mXKENSA_KUBUN))         '検査区分
                End If

                If IsNull(mXKENPIN_KUBUN) = False Then
                    '(検品区分指定有りの場合)
                    strSQL &= vbCrLf & "      AND A.XKENPIN_KUBUN = " & Trim(Str(mXKENPIN_KUBUN))       '検品区分
                End If

                If IsNull(mXMAKER_CD) = False Then
                    '(検品区分指定有りの場合)
                    strSQL &= vbCrLf & "      AND A.XMAKER_CD = '" & (mXMAKER_CD) & "'"                 'ﾒｰｶ-ｺｰﾄﾞ
                End If

                '↑↑↑↑↑↑************************************************************************************************************


                strSQL &= vbCrLf & ") HIKI"
                '========================
                '優先順指定
                '========================
                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/04/27  OrderByを制御
                If IsNull(mstrOrderBy) Then
                    '(ﾌﾟﾛﾊﾟﾃｨがｾｯﾄされていない場合)
                    '↑↑↑↑↑↑************************************************************************************************************

                    If intProcKubun = RSV_PROC Then
                        '(在庫確保処理の場合)

                        '↓↓↓↓↓↓************************************************************************************************************
                        'JobMate:N.Dounoshita 2013/06/12 並び替え

                        strSQL &= vbCrLf & "    ORDER BY FLOT_NO "                  'ﾛｯﾄ№
                        strSQL &= vbCrLf & "           , FARRIVE_DT "               '在庫発生日時
                        strSQL &= vbCrLf & "           , FTR_VOL"                   '搬送管理量

                        'strSQL &= vbCrLf & "    ORDER BY FARRIVE_DT "                                   '在庫発生日時
                        'strSQL &= vbCrLf & "           , FTR_VOL"                                       '搬送管理量

                        '↑↑↑↑↑↑************************************************************************************************************

                    End If

                    '↓↓↓↓↓↓************************************************************************************************************
                    'SystemMate:N.Dounoshita 2012/04/27  OrderByを制御
                Else
                    '(ﾌﾟﾛﾊﾟﾃｨがｾｯﾄされている場合)

                    If intProcKubun = RSV_PROC Then
                        '(在庫確保処理の場合)

                        strSQL &= vbCrLf & "    ORDER BY "
                        strSQL &= vbCrLf & "    " & mstrOrderBy

                    End If

                End If
                strSQL &= vbCrLf
                '↑↑↑↑↑↑************************************************************************************************************



                Return strSQL


            Catch ex As UserException
                Call ComUser(ex, MeSyoriID)
                Throw ex
            Catch ex As Exception
                ComError(ex, MeSyoriID)
                Throw New System.Exception(ex.Message)
            Finally
                objDataSet.Dispose()
                objDataSet = Nothing
            End Try
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region

    '便利機能
#Region "  有効在庫数ﾁｪｯｸ（在庫数取得）                                                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 有効在庫数ﾁｪｯｸ（在庫数取得）
    ''' </summary>
    ''' <returns>在庫数</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function CheckStockVol() As Decimal
        Try
            Dim objDataSet As New DataSet               'ﾃﾞｰﾀｾｯﾄ
            Try
                Dim strSQL As String                    'SQL文


                '************************
                'SQL文生成
                '************************
                strSQL = MakeSQL(CHK_PROC)


                '************************
                '抽出
                '************************
                objDataSet.Clear()
                ObjDb.SQL = strSQL
                ObjDb.GetDataSet("TRST_STOCK", objDataSet)


                '************************
                '有効在庫数ﾁｪｯｸ
                '************************
                Dim intVol As Decimal = 0

                intVol = TO_DECIMAL(objDataSet.Tables("TRST_STOCK").Rows(0).Item("FTR_VOL")) - _
                   TO_DECIMAL(objDataSet.Tables("TRST_STOCK").Rows(0).Item("FTR_RES_VOL"))

                Return intVol

            Catch ex As UserException
                Throw ex
            Catch ex As Exception
                Throw New System.Exception(ex.Message)
            Finally
                objDataSet.Dispose()
                objDataSet = Nothing
            End Try
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
