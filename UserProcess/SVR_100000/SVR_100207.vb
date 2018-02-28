'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】次ﾙｰﾄのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ検索ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100207
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義                                                                      "
    Private mobjTPRG_TRK_BUF_NEXT As TBL_TPRG_TRK_BUF                                   '次ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    Private mobjTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF                                  '中継ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    Private mFPALLET_ID As String                                                       'ﾊﾟﾚｯﾄID
    Private mFBUF_FM As Nullable(Of Integer)                                            '元ﾊﾞｯﾌｧ№
    Private mFEQ_ID_CRANE_FM As String                                                  '元ｸﾚｰﾝ設備ID
    Private mFBUF_TO As Nullable(Of Integer)                                            '先ﾊﾞｯﾌｧ№
    Private mFEQ_ID_CRANE_TO As String                                                  '先ｸﾚｰﾝ設備ID
    Private mFWAIT_REASON As String                                                     '指示送信待ﾁ理由
    Private mFEQ_ID_CRANE As String                                                     'ｸﾚｰﾝ設備ID
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
    ''' <summary>
    ''' 次ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    ''' </summary>
    Public Property TPRG_TRK_BUF_NEXT() As TBL_TPRG_TRK_BUF
        Get
            Return mobjTPRG_TRK_BUF_NEXT
        End Get
        Set(ByVal Value As TBL_TPRG_TRK_BUF)
            mobjTPRG_TRK_BUF_NEXT = Value
        End Set
    End Property
    ''' <summary>
    ''' 次ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    ''' </summary>
    Public Property TPRG_TRK_BUF_RELAY() As TBL_TPRG_TRK_BUF
        Get
            Return mobjTPRG_TRK_BUF_RELAY
        End Get
        Set(ByVal Value As TBL_TPRG_TRK_BUF)
            mobjTPRG_TRK_BUF_RELAY = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾟﾚｯﾄID
    ''' </summary>
    Public Property FPALLET_ID() As String
        Get
            Return mFPALLET_ID
        End Get
        Set(ByVal Value As String)
            mFPALLET_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' 元ﾊﾞｯﾌｧ№
    ''' </summary>
    Public Property FBUF_FM() As Nullable(Of Integer)
        Get
            Return mFBUF_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' 元ｸﾚｰﾝ設備ID
    ''' </summary>
    Public Property FEQ_ID_CRANE_FM() As String
        Get
            Return mFEQ_ID_CRANE_FM
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CRANE_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' 先ﾊﾞｯﾌｧ№
    ''' </summary>
    Public Property FBUF_TO() As Nullable(Of Integer)
        Get
            Return mFBUF_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' 先ｸﾚｰﾝ設備ID
    ''' </summary>
    Public Property FEQ_ID_CRANE_TO() As String
        Get
            Return mFEQ_ID_CRANE_TO
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CRANE_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' 指示送信待ﾁ理由
    ''' </summary>
    Public Property FWAIT_REASON() As String
        Get
            Return mFWAIT_REASON
        End Get
        Set(ByVal Value As String)
            mFWAIT_REASON = Value
        End Set
    End Property
    ''' <summary>
    ''' ｸﾚｰﾝ設備ID
    ''' </summary>
    Public Property FEQ_ID_CRANE() As String
        Get
            Return mFEQ_ID_CRANE
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CRANE = Value
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
#Region "  次ﾙｰﾄのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ検索                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 次ﾙｰﾄのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ検索
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GET_NEXT_TPRG_TRK_BUF() As RetCode
        Try
            Dim strMsg As String            'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim intRet As RetCode           '戻り値

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If 1 <> 1 Then
            ElseIf IsNull(mFPALLET_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFBUF_FM) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[元ﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFEQ_ID_CRANE_FM) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[元ｸﾚｰﾝ設備ID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFBUF_TO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[先ﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFEQ_ID_CRANE_TO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[先ｸﾚｰﾝ設備ID]"
                Throw New UserException(strMsg)
            End If


            '↓↓↓↓↓↓************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/19 同じﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ内での搬送（具体的には棚間移動）になるとｴﾗｰとなるので対応

            Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            objTPRG_TRK_BUF_FM.FPALLET_ID = mFPALLET_ID            'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF(True)     '取得

            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '搬送ﾙｰﾄﾏｽﾀの特定
            '************************
            Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)                 '搬送ﾙｰﾄﾏｽﾀ
            objTMST_ROUTE.FBUF_FM = mFBUF_FM                                                '元ﾊﾞｯﾌｧ№
            objTMST_ROUTE.FEQ_ID_CRANE_FM = mFEQ_ID_CRANE_FM                                '元ｸﾚｰﾝ設備ID
            objTMST_ROUTE.FBUF_TO = mFBUF_TO                                                '先ﾊﾞｯﾌｧ№
            objTMST_ROUTE.FEQ_ID_CRANE_TO = mFEQ_ID_CRANE_TO                                '先ｸﾚｰﾝ設備ID
            intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                                     '特定


            '************************
            '先ﾄﾗｯｷﾝｸﾞの補正(次ﾄﾗｯｷﾝｸﾞが0指定の場合)
            '************************
            If TO_INTEGER(objTMST_ROUTE.FBUF_NEXT) = 0 Then
                objTMST_ROUTE.FBUF_NEXT = objTMST_ROUTE.FBUF_TO
            End If

            '************************
            '先ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
            '************************
            Dim objTMST_TRK_TO As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀｸﾗｽ
            objTMST_TRK_TO.FTRK_BUF_NO = objTMST_ROUTE.FBUF_NEXT                            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            intRet = objTMST_TRK_TO.GET_TMST_TRK(True)                                      '特定

            '************************
            '先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
            '************************
            mobjTPRG_TRK_BUF_NEXT = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀｸﾗｽ
            '↓↓↓↓↓↓************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/19 同じﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ内での搬送（具体的には棚間移動）になるとｴﾗｰとなるので対応

            If IsNotNull(objTPRG_TRK_BUF_FM.FRSV_BUF_TO) And IsNotNull(objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO) Then
                '(搬送先が予約されている場合)
                mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FRSV_BUF_TO              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
                mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
                intRet = mobjTPRG_TRK_BUF_NEXT.GET_TPRG_TRK_BUF(False)                          '特定
            Else
                '(搬送先が予約されていない場合)
                mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO = objTMST_TRK_TO.FTRK_BUF_NO                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
                intRet = RetCode.NotFound
            End If

            'mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO = objTMST_TRK_TO.FTRK_BUF_NO                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            'mobjTPRG_TRK_BUF_NEXT.FRSV_PALLET = mFPALLET_ID                                 '仮引当ﾊﾟﾚｯﾄID
            'intRet = mobjTPRG_TRK_BUF_NEXT.GET_TPRG_TRK_BUF_RSV_PALLET                      '特定

            '↑↑↑↑↑↑************************************************************************************************************
            If intRet = RetCode.OK Then
                '(先に引当されている場合)
                If TO_INTEGER(objTMST_TRK_TO.FBUF_KIND) = FBUF_KIND_SASRS Then
                    '************************
                    'ｸﾚｰﾝﾏｽﾀの特定
                    '************************
                    Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)         'ｸﾚｰﾝﾏｽﾀｸﾗｽ
                    objTMST_CRANE.FTRK_BUF_NO = mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO           'ﾊﾞｯﾌｧ№
                    objTMST_CRANE.INTCHECK_ROW = mobjTPRG_TRK_BUF_NEXT.FRAC_RETU            '列
                    intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                               '特定
                    If intRet = RetCode.NotFound Then
                        '(見つからない場合)
                        strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                        Throw New UserException(strMsg)
                    End If

                    '************************
                    '先ｸﾚｰﾝ設備IDの特定
                    '************************
                    mFEQ_ID_CRANE = objTMST_CRANE.FEQ_ID

                Else

                    '************************
                    '先ｸﾚｰﾝ設備IDの特定
                    '************************
                    mFEQ_ID_CRANE = FEQ_ID_SKOTEI

                End If
            Else
                '(新たに引当する場合)
                If TO_INTEGER(objTMST_TRK_TO.FBUF_KIND) = FBUF_KIND_SASRS Then
                    '(自動倉庫の場合)
                    '************************
                    '搬送可能な全ｸﾚｰﾝを取得
                    '************************
                    Dim strEQ_ID() As String                                                'ｸﾚｰﾝID
                    intRet = objTMST_ROUTE.GET_TMST_ROUTE_CRANES()                          'ｸﾚｰﾝID取得
                    If intRet = RetCode.NotFound Then
                        '(見つからない場合)
                        strMsg = ERRMSG_NOTFOUND_TMST_ROUTE & "[元ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_ROUTE.FBUF_FM) & "][元ｸﾚｰﾝ設備ID:" & objTMST_ROUTE.FEQ_ID_CRANE_FM & "][先ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_ROUTE.FBUF_TO) & "][先ｸﾚｰﾝ設備ID:******]"
                        Throw New UserException(strMsg)
                    End If
                    ReDim Preserve strEQ_ID(UBound(objTMST_ROUTE.ARYME))
                    For ii As Integer = LBound(objTMST_ROUTE.ARYME) To UBound(objTMST_ROUTE.ARYME)
                        strEQ_ID(ii) = objTMST_ROUTE.ARYME(ii).FEQ_ID_CRANE_TO
                    Next
                    objTMST_ROUTE.ARYME_CLEAR()


                    '************************
                    '在庫情報   取得
                    '************************
                    Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)             '在庫情報ﾃｰﾌﾞﾙ
                    objTRST_STOCK.FPALLET_ID = mFPALLET_ID
                    intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)


                    '************************
                    '品目ﾏｽﾀ取得
                    '************************
                    Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)             '品目ﾏｽﾀ
                    objTMST_ITEM.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD
                    intRet = objTMST_ITEM.GET_TMST_ITEM(True)


                    '************************
                    '移動先ﾊﾞｯﾌｧの空棚引当
                    '************************
                    Dim objSVR_100201 As New SVR_100201(Owner, ObjDb, ObjDbLog)             '空棚引当ｸﾗｽ
                    objSVR_100201.FTRK_BUF_NO = mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO           'ﾊﾞｯﾌｧ№
                    objSVR_100201.FEQ_ID_CRANE = strEQ_ID                                   'ｸﾚｰﾝID
                    objSVR_100201.FPALLET_ID = mFPALLET_ID                                  'ﾊﾟﾚｯﾄID
                    intRet = objSVR_100201.FIND_TANA_AKI                                    '特定
                    If intRet = RetCode.NotFound Then
                        '(見つからない場合)
                        mFWAIT_REASON = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO) & "]"
                        Return (RetCode.NotEnough)
                    End If
                    mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO = objSVR_100201.FTRK_BUF_NO           'ﾊﾞｯﾌｧ№
                    mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_ARRAY = objSVR_100201.FTRK_BUF_ARRAY     '配列№
                    intRet = mobjTPRG_TRK_BUF_NEXT.GET_TPRG_TRK_BUF(False)                  '特定
                    If intRet = RetCode.NotFound Then
                        '(見つからない場合)
                        strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO) & "  ,配列№:" & TO_STRING(mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_ARRAY) & "]"
                        Throw New UserException(strMsg)
                    End If

                    '************************
                    'ｸﾚｰﾝﾏｽﾀの特定
                    '************************
                    Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)         'ｸﾚｰﾝﾏｽﾀｸﾗｽ
                    objTMST_CRANE.FTRK_BUF_NO = mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO           'ﾊﾞｯﾌｧ№
                    objTMST_CRANE.INTCHECK_ROW = mobjTPRG_TRK_BUF_NEXT.FRAC_RETU            '列
                    intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                               '特定
                    If intRet = RetCode.NotFound Then
                        '(見つからない場合)
                        strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                        Throw New UserException(strMsg)
                    End If

                    '************************
                    '先ｸﾚｰﾝ設備IDの特定
                    '************************
                    mFEQ_ID_CRANE = objTMST_CRANE.FEQ_ID


                Else
                    '(自動倉庫以外の場合)

                    '************************
                    '移動先ﾊﾞｯﾌｧの引当
                    '************************
                    '↓↓↓↓↓↓************************************************************************************************************
                    'Checked SystemMate:N.Dounoshita 2011/12/13 出庫先を引き当てない場合は、空きﾁｪｯｸを行わなくても良いが、空きがないと出庫指示出来ない。
                    '                                   しかし、このﾛｼﾞｯｸを処理しないと、正常に出庫指示がされない。

                    intRet = mobjTPRG_TRK_BUF_NEXT.GET_TPRG_TRK_BUF_AKI_HIRA                '特定
                    If intRet = RetCode.NotFound Then
                        '(見つからない場合)
                        mFWAIT_REASON = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(mobjTPRG_TRK_BUF_NEXT.FTRK_BUF_NO) & "]"
                        Return (RetCode.NotEnough)
                    End If

                    '↑↑↑↑↑↑************************************************************************************************************


                    '************************
                    '先ｸﾚｰﾝ設備IDの特定
                    '************************
                    mFEQ_ID_CRANE = FEQ_ID_SKOTEI
                End If
            End If

            If TO_INTEGER(objTMST_ROUTE.FBUF_RELAY) > 0 Then
                '************************
                '中継ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
                '************************
                mobjTPRG_TRK_BUF_RELAY = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀｸﾗｽ
                mobjTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = objTMST_ROUTE.FBUF_RELAY                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
                mobjTPRG_TRK_BUF_RELAY.FRSV_PALLET = mFPALLET_ID                                '仮引当ﾊﾟﾚｯﾄID
                intRet = mobjTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF_RSV_PALLET                     '特定
                If intRet = RetCode.OK Then
                    '(先に引当されている場合)
                Else
                    '(新たに引当する場合)
                    '************************
                    '移動先ﾊﾞｯﾌｧの引当
                    '************************
                    intRet = mobjTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF_AKI_HIRA                   '特定
                    If intRet = RetCode.NotFound Then
                        '(見つからない場合)
                        mFWAIT_REASON = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(mobjTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "]"
                        Return (RetCode.NotEnough)
                    End If
                End If
            End If

            Return (RetCode.OK)


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
