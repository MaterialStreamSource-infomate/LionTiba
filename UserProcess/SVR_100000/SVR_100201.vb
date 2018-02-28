'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】空棚引当てｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100201
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義                                                                      "
    Private mFTRK_BUF_NO As Nullable(Of Integer)      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
    Private mFTRK_BUF_ARRAY As Nullable(Of Integer)   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列No
    Private mFRAC_FORM As Nullable(Of Integer)        '棚形状種別
    Private mFEQ_ID_CRANE As String()                 '元ｸﾚｰﾝ設備ID
    Private mFPALLET_ID As String                     'ﾊﾟﾚｯﾄID
    Private mblnUpdate As Boolean                     '更新ﾌﾗｸﾞ
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/18  空棚引当改造
    Private mFRES_TYPE As String                      '引当ﾀｲﾌﾟ
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/10/19  空棚引当に、ｺﾝﾍﾞｱの切離しも条件に追加。切離しされていたら、空棚引当の対象としない。
    Private mFBUF_FM As Nullable(Of Integer)           '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:N.Dounoshita 2013/04/03 ﾀﾞﾌﾞﾙﾃﾞｨｰﾌﾟ and ﾍﾟｱ搬送の空棚引当に対応
    Private mblnPair As Boolean                             'ﾍﾟｱ搬送ﾌﾗｸﾞ
    Private mXTANA_BLOCK As Nullable(Of Integer)            '棚ﾌﾞﾛｯｸ
    Private mFTRK_BUF_ARRAY_Pair As Nullable(Of Integer)    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列No(ﾍﾟｱ搬送)
    '↑↑↑↑↑↑************************************************************************************************************

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo</summary>
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
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列No</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FTRK_BUF_ARRAY() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_ARRAY
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_ARRAY = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>棚形状種別</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FRAC_FORM() As Nullable(Of Integer)
        Get
            Return mFRAC_FORM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_FORM = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>元ｸﾚｰﾝ設備ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FEQ_ID_CRANE() As String()
        Get
            Return mFEQ_ID_CRANE
        End Get
        Set(ByVal Value As String())
            mFEQ_ID_CRANE = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>更新ﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property blnUpdate() As Boolean
        Get
            Return mblnUpdate
        End Get
        Set(ByVal Value As Boolean)
            mblnUpdate = Value
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

    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/18  空棚引当改造
    ''' =======================================
    ''' <summary>ﾊﾟﾚｯﾄID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FRES_TYPE() As String
        Get
            Return mFRES_TYPE
        End Get
        Set(ByVal Value As String)
            mFRES_TYPE = Value
        End Set
    End Property
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/10/19  空棚引当に、ｺﾝﾍﾞｱの切離しも条件に追加。切離しされていたら、空棚引当の対象としない。
    ''' =======================================
    ''' <summary>搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FBUF_FM() As Nullable(Of Integer)
        Get
            Return mFBUF_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_FM = Value
        End Set
    End Property
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:N.Dounoshita 2013/04/03 ﾀﾞﾌﾞﾙﾃﾞｨｰﾌﾟ and ﾍﾟｱ搬送の空棚引当に対応
    ''' =======================================
    ''' <summary>ﾍﾟｱ搬送ﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property blnPair() As Boolean
        Get
            Return mblnPair
        End Get
        Set(ByVal Value As Boolean)
            mblnPair = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列No(ﾍﾟｱ搬送)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FTRK_BUF_ARRAY_Pair() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_ARRAY_Pair
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_ARRAY_Pair = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>棚ﾌﾞﾛｯｸ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property XTANA_BLOCK() As Nullable(Of Integer)
        Get
            Return mXTANA_BLOCK
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTANA_BLOCK = Value
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
        mblnUpdate = True
    End Sub
#End Region
#Region "  空棚引当て                                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 空棚引当て
    ''' </summary>
    ''' <returns>RetCode</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function FIND_TANA_AKI() As RetCode
        Try
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            Dim intRet As RetCode                   '戻り値
            Dim blnFIND As Boolean = False          '検索結果


            '************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '************************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo]"
                Throw New UserException(strMsg)
            End If

            '************************
            'ｸﾚｰﾝ優先順使用有無の確認
            '************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)             'ｼｽﾃﾑ変数ｸﾗｽ
            objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS000000_003                             '変数ID
            intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                                 '取得


            If TO_INTEGER(objTPRG_SYS_HEN.FHENSU_INT) = FLAG_ON Then
                '(ｸﾚｰﾝ優先順変数使用の場合)

                '************************
                '棚形状種別優先順ﾏｽﾀの取得
                '************************
                Dim objTMST_RAC_BUNRUI_PR As New TBL_TMST_RAC_BUNRUI_PR(Owner, ObjDb, ObjDbLog)         '棚分類優先順ﾏｽﾀ
                objTMST_RAC_BUNRUI_PR.FRES_TYPE = mFRES_TYPE                '引当ﾀｲﾌﾟ
                objTMST_RAC_BUNRUI_PR.ORDER_BY = "FRAC_PRIORITY"            '並び
                intRet = objTMST_RAC_BUNRUI_PR.GET_TMST_RAC_BUNRUI_PR_ANY() '取得
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_TMST_RACBUNRUI_PRIORITY & "[引当ﾀｲﾌﾟ:" & mFRES_TYPE & "]"
                    Throw New UserException(strMsg)
                End If

                For kk As Integer = 0 To objTMST_RAC_BUNRUI_PR.ARYME.Length - 1
                    '(ﾙｰﾌﾟ:優先順数)

                    '************************
                    'ｸﾚｰﾝ優先順の取得
                    '************************
                    Dim objSVR_100204 As New SVR_100204(Owner, ObjDb, ObjDbLog)    'ｸﾚｰﾝ優先順取得ｸﾗｽ
                    objSVR_100204.FTRK_BUF_NO = mFTRK_BUF_NO                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
                    objSVR_100204.CRANE_ORDER_GET()                                '取得


                    For ii As Integer = LBound(objSVR_100204.FEQ_ID) To UBound(objSVR_100204.FEQ_ID)
                        '(ﾙｰﾌﾟ:ｸﾚｰﾝ数)

                        '************************
                        'ｸﾚｰﾝ指定判定
                        '************************
                        Dim blnCr As Boolean = False
                        If mFEQ_ID_CRANE Is Nothing Then
                            '************************
                            'ｸﾚｰﾝ未指定
                            '************************
                            blnCr = True
                        Else
                            '************************
                            'ｸﾚｰﾝ指定時
                            '************************
                            For jj As Integer = LBound(mFEQ_ID_CRANE) To UBound(mFEQ_ID_CRANE)
                                If mFEQ_ID_CRANE(jj) = objSVR_100204.FEQ_ID(ii) Then
                                    blnCr = True
                                    Exit For
                                End If
                            Next
                            If blnCr = False Then
                                Continue For
                            End If
                        End If


                        '************************
                        'ｸﾚｰﾝﾏｽﾀの特定
                        '************************
                        Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog) 'ｸﾚｰﾝﾏｽﾀｸﾗｽ
                        objTMST_CRANE.FEQ_ID = objSVR_100204.FEQ_ID(ii)                 '設備ID
                        intRet = objTMST_CRANE.GET_TMST_CRANE(False)                    '特定
                        If intRet = RetCode.NotFound Then
                            '(見つからない場合)
                            strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[設備ID:" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                            Throw New UserException(strMsg)
                        End If


                        '************************
                        '設備状況の特定
                        '************************
                        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog) '設備状況ｸﾗｽ
                        objTSTS_EQ_CTRL.FEQ_ID = objTMST_CRANE.FEQ_ID                       '設備ID
                        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)                     '特定
                        If (TO_INTEGER(objTSTS_EQ_CTRL.FEQ_CUT_STS) = FLAG_ON) Then
                            '(切離中の場合)
                            Continue For
                        End If


                        '↓↓↓↓↓↓************************************************************************************************************
                        'SystemMate:N.Dounoshita 2012/10/19  空棚引当に、ｺﾝﾍﾞｱの切離しも条件に追加。切離しされていたら、空棚引当の対象としない。


                        '************************************************
                        'ｺﾝﾍﾞｱ切離ﾁｪｯｸ
                        '************************************************
                        Dim blnEQCut As Boolean     '切離ﾌﾗｸﾞ
                        blnEQCut = SVR_100201_CheckTMST_CNV_CRANE(objTMST_CRANE.FEQ_ID, mFBUF_FM, mFTRK_BUF_NO)
                        If blnEQCut = True Then
                            '(切離中の場合)
                            Continue For
                        End If


                        '↑↑↑↑↑↑************************************************************************************************************


                        '************************
                        '空棚の特定
                        '************************
                        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
                        objTPRG_TRK_BUF.FTRK_BUF_NO = mFTRK_BUF_NO                                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
                        objTPRG_TRK_BUF.FRAC_FORM = mFRAC_FORM                                          '棚形状種別
                        objTPRG_TRK_BUF.FRAC_BUNRUI = objTMST_RAC_BUNRUI_PR.ARYME(kk).FRAC_BUNRUI       '棚分類
                        objTPRG_TRK_BUF.INTRETU_MIN = objTMST_CRANE.FCRANE_ROW1                         '最小列
                        objTPRG_TRK_BUF.INTRETU_MAX = objTMST_CRANE.FCRANE_ROW2                         '最大列

                        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_AKI_RAC                   '特定
                        If intRet = RetCode.OK Then
                            '(見つかった場合)


                            '************************
                            'ｸﾚｰﾝ優先順の更新
                            '************************
                            If mblnUpdate = True Then
                                '(更新ﾌﾗｸﾞがONの場合)
                                Dim objSVR_100205 As New SVR_100205(Owner, ObjDb, ObjDbLog)     'ｸﾚｰﾝ優先順更新ｸﾗｽ
                                objSVR_100205.FTRK_BUF_NO = mFTRK_BUF_NO                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
                                objSVR_100205.FEQ_ID = objSVR_100204.FEQ_ID(ii)                 '使用設備ID
                                objSVR_100205.CRANE_ORDER_UPDATE()                              '更新
                            End If


                            '************************
                            '戻り値のｾｯﾄ
                            '************************
                            mFTRK_BUF_ARRAY = objTPRG_TRK_BUF.FTRK_BUF_ARRAY    'ﾄﾗｯｷﾝｸﾞ配列No
                            Return (RetCode.OK)                                 '正常終了


                        End If
                    Next


                Next


            Else
                '(ｸﾚｰﾝ未使用の場合)


                '************************
                '空棚の特定
                '************************
                Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
                objTPRG_TRK_BUF.FTRK_BUF_NO = mFTRK_BUF_NO                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
                objTPRG_TRK_BUF.FRAC_FORM = mFRAC_FORM                              '棚形状種別
                intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_AKI_RAC                   '特定
                If intRet = RetCode.OK Then
                    '(見つかった場合)

                    '************************
                    '戻り値のｾｯﾄ
                    '************************
                    mFTRK_BUF_ARRAY = objTPRG_TRK_BUF.FTRK_BUF_ARRAY    'ﾄﾗｯｷﾝｸﾞ配列No
                    Return (RetCode.OK)                                 '正常終了
                End If


            End If


            Return (RetCode.NotFound)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:N.Dounoshita 2013/04/03 ﾀﾞﾌﾞﾙﾃﾞｨｰﾌﾟ and ﾍﾟｱ搬送の空棚引当に対応
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義                                                                      "

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "

#End Region
#Region "  列挙対(検索ﾊﾟﾀｰﾝ)                                                                    "
    Public Enum SearchKind
        Kind11      '判定1-1(ﾍﾟｱ入庫1回目)(棚ﾌﾞﾛｯｸ状態が入庫中であり、同一品目が奥棚に在庫している手前棚を引当てる。)
        Kind12      '判定1-2(ﾍﾟｱ入庫2回目)(奥棚を引当てる。)
    End Enum
#End Region
#Region "  空棚引当て(ﾀﾞﾌﾞﾙﾃﾞｨｰﾌﾟ and ﾍﾟｱ搬送用)                                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 空棚引当て(ﾀﾞﾌﾞﾙﾃﾞｨｰﾌﾟ and ﾍﾟｱ搬送用)
    ''' </summary>
    ''' <returns>RetCode</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function FIND_PAIR_TANA_AKI() As RetCode
        Try
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            Dim intRet As RetCode                   '戻り値
            Dim blnFIND As Boolean = False          '検索結果


            '************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '************************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo]"
                Throw New UserException(strMsg)
            End If

            '************************
            'ｸﾚｰﾝ優先順使用有無の確認
            '************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)             'ｼｽﾃﾑ変数ｸﾗｽ
            objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS000000_003                             '変数ID
            intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN()                                     '取得


            If TO_INTEGER(objTPRG_SYS_HEN.FHENSU_INT) = FLAG_ON Then
                '(ｸﾚｰﾝ優先順変数使用の場合)


                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2013/11/08 空棚引当変更
                ' '' '' '' ''************************
                ' '' '' '' ''棚形状種別優先順ﾏｽﾀの取得
                ' '' '' '' ''************************
                '' '' '' ''Dim objTMST_RAC_BUNRUI_PR As New TBL_TMST_RAC_BUNRUI_PR(Owner, ObjDb, ObjDbLog)         '棚分類優先順ﾏｽﾀ
                '' '' '' ''objTMST_RAC_BUNRUI_PR.FRES_TYPE = mFRES_TYPE                '引当ﾀｲﾌﾟ
                '' '' '' ''objTMST_RAC_BUNRUI_PR.ORDER_BY = "FRAC_PRIORITY"            '並び
                '' '' '' ''intRet = objTMST_RAC_BUNRUI_PR.GET_TMST_RAC_BUNRUI_PR_ANY() '取得
                '' '' '' ''If intRet = RetCode.NotFound Then
                '' '' '' ''    '(見つからない場合)
                '' '' '' ''    strMsg = ERRMSG_NOTFOUND_TMST_RACBUNRUI_PRIORITY & "[引当ﾀｲﾌﾟ:" & mFRES_TYPE & "]"
                '' '' '' ''    Throw New UserException(strMsg)
                '' '' '' ''End If

                '' '' '' ''For kk As Integer = 0 To objTMST_RAC_BUNRUI_PR.ARYME.Length - 1
                '' '' '' ''    '(ﾙｰﾌﾟ:優先順数)

                '' '' '' ''    '************************
                '' '' '' ''    'ｸﾚｰﾝ優先順の取得
                '' '' '' ''    '************************
                '' '' '' ''    Dim objSVR_100204 As New SVR_100204(Owner, ObjDb, ObjDbLog)    'ｸﾚｰﾝ優先順取得ｸﾗｽ
                '' '' '' ''    objSVR_100204.FTRK_BUF_NO = mFTRK_BUF_NO                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
                '' '' '' ''    objSVR_100204.CRANE_ORDER_GET()                                '取得


                '' '' '' ''    For ii As Integer = LBound(objSVR_100204.FEQ_ID) To UBound(objSVR_100204.FEQ_ID)
                '' '' '' ''        '(ﾙｰﾌﾟ:ｸﾚｰﾝ数)

                '' '' '' ''        '************************
                '' '' '' ''        'ｸﾚｰﾝ指定判定
                '' '' '' ''        '************************
                '' '' '' ''        Dim blnCr As Boolean = False
                '' '' '' ''        If mFEQ_ID_CRANE Is Nothing Then
                '' '' '' ''            '************************
                '' '' '' ''            'ｸﾚｰﾝ未指定
                '' '' '' ''            '************************
                '' '' '' ''            blnCr = True
                '' '' '' ''        Else
                '' '' '' ''            '************************
                '' '' '' ''            'ｸﾚｰﾝ指定時
                '' '' '' ''            '************************
                '' '' '' ''            For jj As Integer = LBound(mFEQ_ID_CRANE) To UBound(mFEQ_ID_CRANE)
                '' '' '' ''                If mFEQ_ID_CRANE(jj) = objSVR_100204.FEQ_ID(ii) Then
                '' '' '' ''                    blnCr = True
                '' '' '' ''                    Exit For
                '' '' '' ''                End If
                '' '' '' ''            Next
                '' '' '' ''            If blnCr = False Then
                '' '' '' ''                Continue For
                '' '' '' ''            End If
                '' '' '' ''        End If

                '' '' '' ''        '************************
                '' '' '' ''        'ｸﾚｰﾝﾏｽﾀの特定
                '' '' '' ''        '************************
                '' '' '' ''        Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog) 'ｸﾚｰﾝﾏｽﾀｸﾗｽ
                '' '' '' ''        objTMST_CRANE.FEQ_ID = objSVR_100204.FEQ_ID(ii)                 '設備ID
                '' '' '' ''        intRet = objTMST_CRANE.GET_TMST_CRANE()                         '特定
                '' '' '' ''        If intRet = RetCode.NotFound Then
                '' '' '' ''            '(見つからない場合)
                '' '' '' ''            strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[設備ID:" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                '' '' '' ''            Throw New UserException(strMsg)
                '' '' '' ''        End If


                '' '' '' ''        '************************
                '' '' '' ''        '設備状況の特定
                '' '' '' ''        '************************
                '' '' '' ''        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog) '設備状況ｸﾗｽ
                '' '' '' ''        objTSTS_EQ_CTRL.FEQ_ID = objTMST_CRANE.FEQ_ID                       '設備ID
                '' '' '' ''        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                         '特定
                '' '' '' ''        If intRet = RetCode.NotFound Then
                '' '' '' ''            '(見つからない場合)
                '' '' '' ''            strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]"
                '' '' '' ''            Throw New UserException(strMsg)
                '' '' '' ''        ElseIf (TO_INTEGER(objTSTS_EQ_CTRL.FEQ_CUT_STS) = FLAG_ON) Then
                '' '' '' ''            '(切離中の場合)
                '' '' '' ''            Continue For
                '' '' '' ''        End If


                '' '' '' ''        '************************************************
                '' '' '' ''        '空棚の特定
                '' '' '' ''        '************************************************
                '' '' '' ''        ' ''If mblnPair = True Then
                '' '' '' ''        ' ''    '(ﾍﾟｱ搬送の場合)

                '' '' '' ''        '==============================
                '' '' '' ''        '判定1-1(ﾍﾟｱ入庫1回目)
                '' '' '' ''        '==============================
                '' '' '' ''        intRet = SelectAkiTPRG_TRK_BUF(objTMST_CRANE _
                '' '' '' ''                                     , Nothing _
                '' '' '' ''                                     , objSVR_100204.FEQ_ID(ii) _
                '' '' '' ''                                     , objTMST_RAC_BUNRUI_PR.ARYME(kk) _
                '' '' '' ''                                     , SearchKind.Kind11 _
                '' '' '' ''                                     )
                '' '' '' ''        If intRet = RetCode.OK Then Return (RetCode.OK) '正常終了

                '' '' '' ''        '==============================
                '' '' '' ''        '判定1-2(ﾍﾟｱ入庫2回目)
                '' '' '' ''        '==============================
                '' '' '' ''        intRet = SelectAkiTPRG_TRK_BUF(objTMST_CRANE _
                '' '' '' ''                                     , Nothing _
                '' '' '' ''                                     , objSVR_100204.FEQ_ID(ii) _
                '' '' '' ''                                     , objTMST_RAC_BUNRUI_PR.ARYME(kk) _
                '' '' '' ''                                     , SearchKind.Kind12 _
                '' '' '' ''                                     )
                '' '' '' ''        If intRet = RetCode.OK Then Return (RetCode.OK) '正常終了


                '' '' '' ''    Next


                '' '' '' ''Next
                'JobMate:S.Ouchi 2013/11/08 空棚引当変更
                '↑↑↑↑↑↑************************************************************************************************************




                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2013/11/08 空棚引当変更

                '************************
                '手前棚引当て
                '************************
                intRet = FIND_TEMAE_TANA_AKI()
                If intRet = RetCode.OK Then Return (RetCode.OK) '正常終了

                '************************
                'ｸﾚｰﾝ優先順の取得
                '************************
                Dim objSVR_100204 As New SVR_100204(Owner, ObjDb, ObjDbLog)    'ｸﾚｰﾝ優先順取得ｸﾗｽ
                objSVR_100204.FTRK_BUF_NO = mFTRK_BUF_NO                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
                objSVR_100204.CRANE_ORDER_GET()                                '取得

                For ii As Integer = LBound(objSVR_100204.FEQ_ID) To UBound(objSVR_100204.FEQ_ID)
                    '(ﾙｰﾌﾟ:ｸﾚｰﾝ数)

                    '************************
                    'ｸﾚｰﾝ指定判定
                    '************************
                    Dim blnCr As Boolean = False
                    If mFEQ_ID_CRANE Is Nothing Then
                        '************************
                        'ｸﾚｰﾝ未指定
                        '************************
                        blnCr = True
                    Else
                        '************************
                        'ｸﾚｰﾝ指定時
                        '************************
                        For jj As Integer = LBound(mFEQ_ID_CRANE) To UBound(mFEQ_ID_CRANE)
                            If mFEQ_ID_CRANE(jj) = objSVR_100204.FEQ_ID(ii) Then
                                blnCr = True
                                Exit For
                            End If
                        Next
                        If blnCr = False Then
                            Continue For
                        End If
                    End If

                    '************************
                    'ｸﾚｰﾝﾏｽﾀの特定
                    '************************
                    Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog) 'ｸﾚｰﾝﾏｽﾀｸﾗｽ
                    objTMST_CRANE.FEQ_ID = objSVR_100204.FEQ_ID(ii)                 '設備ID
                    intRet = objTMST_CRANE.GET_TMST_CRANE()                         '特定
                    If intRet = RetCode.NotFound Then
                        '(見つからない場合)
                        strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[設備ID:" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                        Throw New UserException(strMsg)
                    End If


                    '************************
                    '設備状況の特定
                    '************************
                    Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog) '設備状況ｸﾗｽ
                    objTSTS_EQ_CTRL.FEQ_ID = objTMST_CRANE.FEQ_ID                       '設備ID
                    intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                         '特定
                    If intRet = RetCode.NotFound Then
                        '(見つからない場合)
                        strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]"
                        Throw New UserException(strMsg)
                    ElseIf (TO_INTEGER(objTSTS_EQ_CTRL.FEQ_CUT_STS) = FLAG_ON) Then
                        '(切離中の場合)
                        Continue For
                    End If


                    '************************
                    '入庫中4PL判定
                    '************************
                    Dim strFHENSU_ID As String

                    Select Case TO_INTEGER(mFBUF_FM)
                        Case 1000 To 1999
                            strFHENSU_ID = FHENSU_ID_SSJ000000_051      '1F
                        Case 2000 To 2999
                            strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
                        Case 4000 To 4999
                            strFHENSU_ID = FHENSU_ID_SSJ000000_051      '1F
                        Case 5000 To 5999
                            strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
                        Case Else
                            strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
                    End Select

                    Dim intCount As Integer
                    Dim objTRK_BUF_IN As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
                    intCount = objTRK_BUF_IN.GET_TPRG_TRK_BUF_NI_NUM(objTMST_CRANE.FEQ_ID, strFHENSU_ID)    '特定
                    If intCount >= 4 Then
                        '(4PL以上の場合)
                        Continue For
                    End If


                    '************************
                    '棚形状種別優先順ﾏｽﾀの取得
                    '************************
                    Dim objTMST_RAC_BUNRUI_PR As New TBL_TMST_RAC_BUNRUI_PR(Owner, ObjDb, ObjDbLog)         '棚分類優先順ﾏｽﾀ
                    objTMST_RAC_BUNRUI_PR.FRES_TYPE = mFRES_TYPE                '引当ﾀｲﾌﾟ
                    objTMST_RAC_BUNRUI_PR.ORDER_BY = "FRAC_PRIORITY"            '並び
                    intRet = objTMST_RAC_BUNRUI_PR.GET_TMST_RAC_BUNRUI_PR_ANY() '取得
                    If intRet = RetCode.NotFound Then
                        '(見つからない場合)
                        strMsg = ERRMSG_NOTFOUND_TMST_RACBUNRUI_PRIORITY & "[引当ﾀｲﾌﾟ:" & mFRES_TYPE & "]"
                        Throw New UserException(strMsg)
                    End If

                    For kk As Integer = 0 To objTMST_RAC_BUNRUI_PR.ARYME.Length - 1
                        '(ﾙｰﾌﾟ:優先順数)

                        '************************************************
                        '空棚の特定
                        '************************************************
                        ' ''If mblnPair = True Then
                        ' ''    '(ﾍﾟｱ搬送の場合)

                        ' '' ''==============================
                        ' '' ''判定1-1(ﾍﾟｱ入庫1回目)
                        ' '' ''==============================
                        '' ''intRet = SelectAkiTPRG_TRK_BUF(objTMST_CRANE _
                        '' ''                             , Nothing _
                        '' ''                             , objSVR_100204.FEQ_ID(ii) _
                        '' ''                             , objTMST_RAC_BUNRUI_PR.ARYME(kk) _
                        '' ''                             , SearchKind.Kind11 _
                        '' ''                             )
                        '' ''If intRet = RetCode.OK Then Return (RetCode.OK) '正常終了

                        '==============================
                        '判定1-2(ﾍﾟｱ入庫2回目)
                        '==============================
                        intRet = SelectAkiTPRG_TRK_BUF(objTMST_CRANE _
                                                     , Nothing _
                                                     , objSVR_100204.FEQ_ID(ii) _
                                                     , objTMST_RAC_BUNRUI_PR.ARYME(kk) _
                                                     , SearchKind.Kind12 _
                                                     )
                        If intRet = RetCode.OK Then Return (RetCode.OK) '正常終了


                    Next


                Next
                'JobMate:S.Ouchi 2013/11/08 空棚引当変更
                '↑↑↑↑↑↑************************************************************************************************************


            Else
                '(ｸﾚｰﾝ未使用の場合)


                '************************
                '空棚の特定
                '************************
                Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
                objTPRG_TRK_BUF.FTRK_BUF_NO = mFTRK_BUF_NO                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
                objTPRG_TRK_BUF.FRAC_FORM = mFRAC_FORM                              '棚形状種別
                intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_AKI_RAC                   '特定
                If intRet = RetCode.OK Then
                    '(見つかった場合)

                    '************************
                    '戻り値のｾｯﾄ
                    '************************
                    mFTRK_BUF_ARRAY = objTPRG_TRK_BUF.FTRK_BUF_ARRAY    'ﾄﾗｯｷﾝｸﾞ配列No
                    Return (RetCode.OK)                                 '正常終了
                End If


            End If


            Return (RetCode.NotFound)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙ空棚検索処理                                                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙ空棚検索処理
    ''' </summary>
    ''' <param name="objTMST_CRANE">ｸﾚｰﾝﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ</param>
    ''' <param name="intFRAC_FORM">棚形状種別</param>
    ''' <param name="strFEQ_ID">設備ID(ｸﾚｰﾝID)</param>
    ''' <param name="objTMST_RAC_BUNRUI_PR">棚分類優先順ﾏｽﾀ</param>
    ''' <param name="intSearchKind">検索ﾊﾟﾀｰﾝ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SelectAkiTPRG_TRK_BUF(ByVal objTMST_CRANE As TBL_TMST_CRANE _
                                         , ByVal intFRAC_FORM As Integer _
                                         , ByVal strFEQ_ID As String _
                                         , ByVal objTMST_RAC_BUNRUI_PR As TBL_TMST_RAC_BUNRUI_PR _
                                         , ByVal intSearchKind As SearchKind _
                                           ) As RetCode
        Try
            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            Dim intRet As RetCode                   '戻り値
            Dim blnFIND As Boolean = False          '検索結果


            '***************************************************************************************************************************************************************
            '***************************************************************************************************************************************************************
            '検索条件の設定
            '***************************************************************************************************************************************************************
            '***************************************************************************************************************************************************************
            Dim intXTANA_BLOCK_STS As Nullable(Of Integer)      '棚ﾌﾞﾛｯｸ状態
            Dim intXTANA_BLOCK_DTL As Nullable(Of Integer)      '棚ﾌﾞﾛｯｸ詳細
            Dim intFRAC_EDA As Nullable(Of Integer)             '枝
            Select Case intSearchKind
                '************************
                'ﾍﾟｱ搬送
                '************************
                Case SearchKind.Kind11
                    '判定1-1(ﾍﾟｱ入庫1回目)
                    '(棚ﾌﾞﾛｯｸ状態が入庫中であり、同一品目が奥棚に在庫している手前棚を引当てる。)
                    intXTANA_BLOCK_STS = XTANA_BLOCK_STS_IN                         '棚ﾌﾞﾛｯｸ状態
                    intXTANA_BLOCK_DTL = XTANA_BLOCK_DTL_MAE_EVN                    '棚ﾌﾞﾛｯｸ詳細
                    intFRAC_EDA = FRAC_EDA_MAE                                      '枝
                Case SearchKind.Kind12
                    '判定1-1(ﾍﾟｱ入庫2回目)
                    '(奥棚を引当てる。)
                    intXTANA_BLOCK_STS = Nothing                                    '棚ﾌﾞﾛｯｸ状態
                    intXTANA_BLOCK_DTL = XTANA_BLOCK_DTL_OKU_EVN                    '棚ﾌﾞﾛｯｸ詳細
                    intFRAC_EDA = FRAC_EDA_OKU                                      '枝
            End Select


            '************************
            '空棚の特定
            '************************
            Dim objTrkBase As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTrkBase.FTRK_BUF_NO = mFTRK_BUF_NO                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            objTrkBase.FRAC_FORM = intFRAC_FORM                            '棚形状種別

            '    ↓↓↓↓↓↓************************************************************************************************************
            '    JobMate:S.Ouchi 2013/11/08 空棚引当変更
            If Not (objTMST_RAC_BUNRUI_PR Is Nothing) Then
                'JobMate:S.Ouchi 2013/11/08 空棚引当変更
                '↑↑↑↑↑↑************************************************************************************************************

                objTrkBase.FRAC_BUNRUI = objTMST_RAC_BUNRUI_PR.FRAC_BUNRUI     '棚分類

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2013/11/08 空棚引当変更
            End If
            '    JobMate:S.Ouchi 2013/11/08 空棚引当変更
            '    ↑↑↑↑↑↑************************************************************************************************************

            objTrkBase.INTRETU_MIN = objTMST_CRANE.FCRANE_ROW1             '最小列
            objTrkBase.INTRETU_MAX = objTMST_CRANE.FCRANE_ROW2             '最大列
            objTrkBase.FRAC_FORM = mFRAC_FORM                              '棚形状種別
            objTrkBase.FRAC_EDA = intFRAC_EDA                              '枝
            objTrkBase.XTANA_BLOCK = mXTANA_BLOCK                          '棚ﾌﾞﾛｯｸ
            objTrkBase.XTANA_BLOCK_DTL = intXTANA_BLOCK_DTL                '棚ﾌﾞﾛｯｸ詳細
            objTrkBase.XTANA_BLOCK_STS = intXTANA_BLOCK_STS                '棚ﾌﾞﾛｯｸ状態
            intRet = objTrkBase.GET_TPRG_TRK_BUF_AKI_RAC(True)             '特定
            If intRet = RetCode.OK Then
                '(見つかった場合)
                For ii As Integer = 0 To objTrkBase.ARYME.Length - 1
                    '(ﾙｰﾌﾟ:空棚数)


                    '************************************************
                    '前後する棚情報を取得
                    '************************************************
                    Dim objTrkFind As TBL_TPRG_TRK_BUF = objTrkBase.ARYME(ii)               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
                    Dim objTrkRelation() As TBL_TPRG_TRK_BUF = Nothing                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
                    Dim objStockFind As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)          '在庫情報
                    Dim objStockRelation() As TBL_TRST_STOCK = Nothing                      '在庫情報
                    Call GetTPRG_TRK_BUF_Relation(objTrkFind, objTrkRelation, objStockFind, objStockRelation)

                    '========================
                    '入庫する在庫情報を取得
                    '========================
                    objStockFind.CLEAR_PROPERTY()                   'ﾌﾟﾛﾊﾟﾃｨｸﾘｱ
                    objStockFind.FPALLET_ID = mFPALLET_ID           'ﾊﾟﾚｯﾄID
                    intRet = objStockFind.GET_TRST_STOCK_KONSAI(True)   '取得


                    '***************************************************************************************************************************************************************
                    '***************************************************************************************************************************************************************
                    '空棚を引き当てるか否かの判断
                    '***************************************************************************************************************************************************************
                    '***************************************************************************************************************************************************************
                    Dim intFTRK_BUF_ARRAY_Pair As Nullable(Of Integer) = Nothing
                    Select Case intSearchKind
                        Case SearchKind.Kind11
                            '判定1-1(ﾍﾟｱ入庫1回目)


                            '************************************************************************************************
                            '手前棚が両方とも空棚じゃないと引き当てない
                            '************************************************************************************************
                            If Not (objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SAKI) Then Continue For
                            If Not (objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SAKI) Then Continue For


                            '************************************************************************************************
                            '奥棚が 在庫棚 or 搬入予約 以外の場合は引き当てない
                            '************************************************************************************************
                            If Not (objTrkRelation(RelationArray.OKU_EVN).FRES_KIND = FRES_KIND_SZAIKO Or objTrkRelation(RelationArray.OKU_EVN).FRES_KIND = FRES_KIND_SRSV_TRNS_IN) Then Continue For
                            If Not (objTrkRelation(RelationArray.OKU_ODD).FRES_KIND = FRES_KIND_SZAIKO Or objTrkRelation(RelationArray.OKU_ODD).FRES_KIND = FRES_KIND_SRSV_TRNS_IN) Then Continue For


                            '************************************************************************************************
                            '同一品番                       の在庫じゃないと引当てない
                            '同一入庫区分                   の在庫じゃないと引当てない
                            '同一生産ﾗｲﾝ№                  の在庫じゃないと引当てない
                            '同一ﾛｯﾄ№                      の在庫じゃないと引当てない
                            '同一ﾒｰｶｰｺｰﾄﾞ                   の在庫じゃないと引当てない
                            '************************************************************************************************
                            If Not (objStockFind.ARYME(0).FHINMEI_CD = objStockRelation(RelationArray.OKU_EVN).ARYME(0).FHINMEI_CD) Then Continue For
                            If Not (objStockFind.ARYME(0).FHINMEI_CD = objStockRelation(RelationArray.OKU_ODD).ARYME(0).FHINMEI_CD) Then Continue For
                            If Not (objStockFind.ARYME(0).FIN_KUBUN = objStockRelation(RelationArray.OKU_EVN).ARYME(0).FIN_KUBUN) Then Continue For
                            If Not (objStockFind.ARYME(0).FIN_KUBUN = objStockRelation(RelationArray.OKU_ODD).ARYME(0).FIN_KUBUN) Then Continue For
                            If Not (objStockFind.ARYME(0).XPROD_LINE = objStockRelation(RelationArray.OKU_EVN).ARYME(0).XPROD_LINE) Then Continue For
                            If Not (objStockFind.ARYME(0).XPROD_LINE = objStockRelation(RelationArray.OKU_ODD).ARYME(0).XPROD_LINE) Then Continue For
                            If Not (objStockFind.ARYME(0).FLOT_NO = objStockRelation(RelationArray.OKU_EVN).ARYME(0).FLOT_NO) Then Continue For
                            If Not (objStockFind.ARYME(0).FLOT_NO = objStockRelation(RelationArray.OKU_ODD).ARYME(0).FLOT_NO) Then Continue For
                            If Not (objStockFind.ARYME(0).XMAKER_CD = objStockRelation(RelationArray.OKU_EVN).ARYME(0).XMAKER_CD) Then Continue For
                            If Not (objStockFind.ARYME(0).XMAKER_CD = objStockRelation(RelationArray.OKU_ODD).ARYME(0).XMAKER_CD) Then Continue For


                            '************************************************************************************************
                            'ﾍﾟｱの戻り値設定
                            '************************************************************************************************
                            If mblnPair = True Then
                                '(ﾍﾟｱ入庫の場合)
                                If objTrkFind.XTANA_BLOCK_DTL = objTrkRelation(RelationArray.MAE_EVN).XTANA_BLOCK_DTL Then
                                    intFTRK_BUF_ARRAY_Pair = objTrkRelation(RelationArray.MAE_ODD).FTRK_BUF_ARRAY
                                Else
                                    intFTRK_BUF_ARRAY_Pair = objTrkRelation(RelationArray.MAE_EVN).FTRK_BUF_ARRAY
                                End If
                            End If


                        Case SearchKind.Kind12
                            'Case SearchKind.Kind12, SearchKind.Kind24
                            '判定1-2(ﾍﾟｱ入庫2回目)


                            '************************************************************************************************
                            '奥棚が両方とも空棚じゃないと引き当てない
                            '************************************************************************************************
                            If Not (objTrkRelation(RelationArray.OKU_EVN).FRES_KIND = FRES_KIND_SAKI) Then Continue For
                            If Not (objTrkRelation(RelationArray.OKU_ODD).FRES_KIND = FRES_KIND_SAKI) Then Continue For


                            '************************************************************************************************
                            '手前棚が 空棚 以外の場合は引き当てない
                            '************************************************************************************************
                            If Not (objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SAKI) Then Continue For
                            If Not (objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SAKI) Then Continue For


                            '************************************************************************************************
                            'ﾍﾟｱの戻り値設定
                            '************************************************************************************************
                            If mblnPair = True Then
                                '(ﾍﾟｱ入庫の場合)
                                If objTrkFind.XTANA_BLOCK_DTL = objTrkRelation(RelationArray.OKU_EVN).XTANA_BLOCK_DTL Then
                                    intFTRK_BUF_ARRAY_Pair = objTrkRelation(RelationArray.OKU_ODD).FTRK_BUF_ARRAY
                                Else
                                    intFTRK_BUF_ARRAY_Pair = objTrkRelation(RelationArray.OKU_EVN).FTRK_BUF_ARRAY
                                End If
                            End If


                    End Select


                    '************************
                    'ｸﾚｰﾝ優先順の更新
                    '************************
                    If mblnUpdate = True Then
                        '(更新ﾌﾗｸﾞがONの場合)
                        If intSearchKind = SearchKind.Kind11 Or mblnPair = False Then
                            '(ｸﾚｰﾝを更新する場合)
                            Dim objSVR_100205 As New SVR_100205(Owner, ObjDb, ObjDbLog)     'ｸﾚｰﾝ優先順更新ｸﾗｽ
                            objSVR_100205.FTRK_BUF_NO = mFTRK_BUF_NO                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
                            objSVR_100205.FEQ_ID = strFEQ_ID                                '使用設備ID
                            objSVR_100205.CRANE_ORDER_UPDATE()                              '更新
                        End If
                    End If


                    '************************
                    '戻り値のｾｯﾄ
                    '************************
                    mFTRK_BUF_ARRAY = objTrkFind.FTRK_BUF_ARRAY         'ﾄﾗｯｷﾝｸﾞ配列No
                    mFTRK_BUF_ARRAY_Pair = intFTRK_BUF_ARRAY_Pair       'ﾄﾗｯｷﾝｸﾞ配列No(ﾍﾟｱ搬送)
                    Return (RetCode.OK)                                 '正常終了


                Next
            End If


            Return (RetCode.NotFound)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region


    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/11/08 空棚引当変更
#Region "  手前棚引当て(ﾀﾞﾌﾞﾙﾃﾞｨｰﾌﾟ and ﾍﾟｱ搬送用)                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 手前棚引当て(ﾀﾞﾌﾞﾙﾃﾞｨｰﾌﾟ and ﾍﾟｱ搬送用)
    ''' </summary>
    ''' <returns>RetCode</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function FIND_TEMAE_TANA_AKI() As RetCode
        Try
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            Dim intRet As RetCode                   '戻り値
            Dim blnFIND As Boolean = False          '検索結果


            '************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '************************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo]"
                Throw New UserException(strMsg)
            End If


            '************************
            'ｸﾚｰﾝ優先順の取得
            '************************
            Dim objSVR_100204 As New SVR_100204(Owner, ObjDb, ObjDbLog)    'ｸﾚｰﾝ優先順取得ｸﾗｽ
            objSVR_100204.FTRK_BUF_NO = mFTRK_BUF_NO                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            objSVR_100204.CRANE_ORDER_GET()                                '取得

            For ii As Integer = LBound(objSVR_100204.FEQ_ID) To UBound(objSVR_100204.FEQ_ID)
                '(ﾙｰﾌﾟ:ｸﾚｰﾝ数)

                '************************
                'ｸﾚｰﾝ指定判定
                '************************
                Dim blnCr As Boolean = False
                If mFEQ_ID_CRANE Is Nothing Then
                    '************************
                    'ｸﾚｰﾝ未指定
                    '************************
                    blnCr = True
                Else
                    '************************
                    'ｸﾚｰﾝ指定時
                    '************************
                    For jj As Integer = LBound(mFEQ_ID_CRANE) To UBound(mFEQ_ID_CRANE)
                        If mFEQ_ID_CRANE(jj) = objSVR_100204.FEQ_ID(ii) Then
                            blnCr = True
                            Exit For
                        End If
                    Next
                    If blnCr = False Then
                        Continue For
                    End If
                End If

                '************************
                'ｸﾚｰﾝﾏｽﾀの特定
                '************************
                Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog) 'ｸﾚｰﾝﾏｽﾀｸﾗｽ
                objTMST_CRANE.FEQ_ID = objSVR_100204.FEQ_ID(ii)                 '設備ID
                intRet = objTMST_CRANE.GET_TMST_CRANE()                         '特定
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[設備ID:" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                    Throw New UserException(strMsg)
                End If


                '************************
                '設備状況の特定
                '************************
                Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog) '設備状況ｸﾗｽ
                objTSTS_EQ_CTRL.FEQ_ID = objTMST_CRANE.FEQ_ID                       '設備ID
                intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                         '特定
                If intRet = RetCode.NotFound Then
                    '(見つからない場合)
                    strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]"
                    Throw New UserException(strMsg)
                ElseIf (TO_INTEGER(objTSTS_EQ_CTRL.FEQ_CUT_STS) = FLAG_ON) Then
                    '(切離中の場合)
                    Continue For
                End If


                '************************
                '入庫中4PL判定
                '************************
                Dim strFHENSU_ID As String

                Select Case TO_INTEGER(mFBUF_FM)
                    Case 1000 To 1999
                        strFHENSU_ID = FHENSU_ID_SSJ000000_051      '1F
                    Case 2000 To 2999
                        strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
                    Case 4000 To 4999
                        strFHENSU_ID = FHENSU_ID_SSJ000000_051      '1F
                    Case 5000 To 5999
                        strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
                    Case Else
                        strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
                End Select

                Dim intCount As Integer
                Dim objTRK_BUF_IN As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
                intCount = objTRK_BUF_IN.GET_TPRG_TRK_BUF_NI_NUM(objTMST_CRANE.FEQ_ID, strFHENSU_ID)    '特定
                If intCount >= 4 Then
                    '(4PL以上の場合)
                    Continue For
                End If

                '==============================
                '判定1-1(ﾍﾟｱ入庫1回目)
                '==============================
                intRet = SelectAkiTPRG_TRK_BUF(objTMST_CRANE _
                                             , Nothing _
                                             , objSVR_100204.FEQ_ID(ii) _
                                             , Nothing _
                                             , SearchKind.Kind11 _
                                             )
                If intRet = RetCode.OK Then Return (RetCode.OK) '正常終了

            Next


            Return (RetCode.NotFound)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
    'JobMate:S.Ouchi 2013/11/08 空棚引当変更
    '↑↑↑↑↑↑************************************************************************************************************

    '↑↑↑↑↑↑************************************************************************************************************

End Class
