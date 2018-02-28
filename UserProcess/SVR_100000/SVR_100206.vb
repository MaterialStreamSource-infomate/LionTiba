'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】全ﾙｰﾄの検索及び予約ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100206
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義                                                                      "
    Private objAryRoute As TBL_TMST_ROUTE()                                             '搬送ﾙｰﾄﾏｽﾀ
    Private mobjTRK_BUF_NEXT As TBL_TPRG_TRK_BUF()                                      '次ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    Private mobjTRK_BUF_RELAY As TBL_TPRG_TRK_BUF()                                     '中継ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    Private mFPALLET_ID As String                                                       'ﾊﾟﾚｯﾄID
    Private mFBUF_FM As Nullable(Of Integer)                                            '元ﾊﾞｯﾌｧ№
    Private mFEQ_ID_CRANE_FM As String                                                  '元ｸﾚｰﾝ設備ID
    Private mFBUF_TO As Nullable(Of Integer)                                            '先ﾊﾞｯﾌｧ№
    Private mFEQ_ID_CRANE_TO As String                                                  '先ｸﾚｰﾝ設備ID
    Private mFRES_KIND As Nullable(Of Integer)                                          '引当状態
    Private mFWAIT_REASON As String                                                     '指示送信待ﾁ理由
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
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
    ''' 引当状態  (整数型)
    ''' </summary>
    ''' <remarks>
    ''' ﾃｰﾌﾞﾙｸﾗｽ自動生成ﾌﾟﾛﾊﾟﾃｨ
    ''' </remarks>
    Public Property FRES_KIND() As Nullable(Of Integer)
        Get
            Return mFRES_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRES_KIND = Value
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
#Region "  全ﾙｰﾄの検索                                                                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 全ﾙｰﾄの検索
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function FIND_TMST_ROUTE_TO_END() As RetCode
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
            ElseIf IsNull(mFRES_KIND) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[引当状態]"
                Throw New UserException(strMsg)
            End If


            '************************
            '搬送ﾙｰﾄﾏｽﾀの特定
            '************************
            ReDim Preserve objAryRoute(0)
            objAryRoute(0) = New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)   '搬送ﾙｰﾄﾏｽﾀ
            objAryRoute(0).FBUF_FM = mFBUF_FM                             '元ﾊﾞｯﾌｧ№
            objAryRoute(0).FEQ_ID_CRANE_FM = mFEQ_ID_CRANE_FM             '元ｸﾚｰﾝ設備ID
            objAryRoute(0).FBUF_TO = mFBUF_TO                             '先ﾊﾞｯﾌｧ№
            objAryRoute(0).FEQ_ID_CRANE_TO = mFEQ_ID_CRANE_TO             '先ｸﾚｰﾝ設備ID
            intRet = objAryRoute(0).GET_TMST_ROUTE(True)                  '特定


            '********************************
            '最終地点まで到達するまでﾙｰﾌﾟ
            '********************************
            ReDim Preserve mobjTRK_BUF_NEXT(0)
            Dim intMax As Integer = UBound(objAryRoute)                 '配列の最大要素数
            While TO_INTEGER(objAryRoute(intMax).FBUF_TO) <> TO_INTEGER(objAryRoute(intMax).FBUF_NEXT) And _
                  TO_INTEGER(objAryRoute(intMax).FBUF_RELAY) <> 0 And _
                  TO_INTEGER(objAryRoute(intMax).FBUF_NEXT) <> 0
                '(最終地点まで到達するまでﾙｰﾌﾟ)

                '************************
                '元ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
                '************************
                Dim objTMST_TRK_FM As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀｸﾗｽ
                objTMST_TRK_FM.FTRK_BUF_NO = objAryRoute(intMax).FBUF_NEXT                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
                intRet = objTMST_TRK_FM.GET_TMST_TRK(True)                                      '特定

                '************************
                '元ｸﾚｰﾝ設備IDの特定
                '************************
                Dim strEQ_ID_CRANE_FM As String
                If TO_INTEGER(objTMST_TRK_FM.FBUF_KIND) = FBUF_KIND_SASRS Then
                    strEQ_ID_CRANE_FM = objAryRoute(intMax).FEQ_ID_CRANE_TO
                Else
                    strEQ_ID_CRANE_FM = FEQ_ID_SKOTEI
                End If

                '************************
                '次ﾙｰﾄのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ検索
                '************************
                Dim objSVR_100207 As New SVR_100207(Owner, ObjDb, ObjDbLog)                     '次ﾙｰﾄのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ検索ｸﾗｽ
                objSVR_100207.FPALLET_ID = mFPALLET_ID                                          'ﾊﾟﾚｯﾄID
                objSVR_100207.FBUF_FM = objAryRoute(intMax).FBUF_FM                             '元ﾊﾞｯﾌｧ№
                objSVR_100207.FEQ_ID_CRANE_FM = objAryRoute(intMax).FEQ_ID_CRANE_FM             '元ｸﾚｰﾝ設備ID
                objSVR_100207.FBUF_TO = objAryRoute(intMax).FBUF_TO                             '先ﾊﾞｯﾌｧ№
                objSVR_100207.FEQ_ID_CRANE_TO = objAryRoute(intMax).FEQ_ID_CRANE_TO             '先ｸﾚｰﾝ設備ID
                intRet = objSVR_100207.GET_NEXT_TPRG_TRK_BUF                                    '次ﾙｰﾄのﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ検索
                If intRet <> RetCode.OK Then
                    mFWAIT_REASON = objSVR_100207.FWAIT_REASON
                    Return (RetCode.NotEnough)
                End If

                '************************
                '先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
                '************************
                Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
                objTPRG_TRK_BUF_TO = objSVR_100207.TPRG_TRK_BUF_NEXT

                '************************
                '元ｸﾚｰﾝ設備IDの特定
                '************************
                Dim strEQ_ID_CRANE_TO As String
                strEQ_ID_CRANE_TO = objSVR_100207.FEQ_ID_CRANE

                '************************
                '中継ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
                '************************
                Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
                objTPRG_TRK_BUF_RELAY = objSVR_100207.TPRG_TRK_BUF_RELAY

                '************************
                '搬送ﾙｰﾄﾏｽﾀの特定
                '************************
                ReDim Preserve objAryRoute(UBound(objAryRoute) + 1)                             '要素数+1
                intMax = UBound(objAryRoute)                                                    '配列の最大要素数
                objAryRoute(intMax) = New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)                '搬送ﾙｰﾄﾏｽﾀ ｲﾝｽﾀﾝｽ化
                objAryRoute(intMax).FBUF_FM = objAryRoute(intMax - 1).FBUF_NEXT                 '元ﾊﾞｯﾌｧ№
                objAryRoute(intMax).FEQ_ID_CRANE_FM = strEQ_ID_CRANE_FM                         '元ｸﾚｰﾝ設備ID
                objAryRoute(intMax).FBUF_TO = objAryRoute(intMax - 1).FBUF_TO                   '先ﾊﾞｯﾌｧ№
                objAryRoute(intMax).FEQ_ID_CRANE_TO = strEQ_ID_CRANE_TO                         '先ｸﾚｰﾝ設備ID
                intRet = objAryRoute(intMax).GET_TMST_ROUTE(True)                               '特定


                '************************
                '予約ﾊﾞｯﾌｧの記憶
                '************************
                ReDim Preserve mobjTRK_BUF_NEXT(intMax)                                         '次ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                ReDim Preserve mobjTRK_BUF_RELAY(intMax)                                        '中継ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                mobjTRK_BUF_NEXT(intMax) = objTPRG_TRK_BUF_TO
                mobjTRK_BUF_RELAY(intMax) = objTPRG_TRK_BUF_RELAY

            End While


            Return (RetCode.OK)


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  全ﾙｰﾄの予約                                                                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 全ﾙｰﾄの予約
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub RSV_TMST_ROUTE_TO_END()
        Try
            Dim strMsg As String            'ﾒｯｾｰｼﾞ

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
            ElseIf IsNull(mFRES_KIND) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[引当状態]"
                Throw New UserException(strMsg)
            End If

            '************************
            '予約ﾊﾞｯﾌｧの更新
            '************************
            If UBound(mobjTRK_BUF_NEXT) > 0 Then
                For ii As Integer = 1 To UBound(mobjTRK_BUF_NEXT)
                    mobjTRK_BUF_NEXT(ii).GET_TPRG_TRK_BUF(False)
                    mobjTRK_BUF_NEXT(ii).FRSV_PALLET = mFPALLET_ID                                  'ﾊﾟﾚｯﾄID
                    mobjTRK_BUF_NEXT(ii).FRES_KIND = mFRES_KIND                                     '引当状態
                    mobjTRK_BUF_NEXT(ii).FBUF_IN_DT = Now                                           'ﾊﾞｯﾌｧ入日時
                    If mobjTRK_BUF_NEXT(ii).FPALLET_ID = "" And _
                       mobjTRK_BUF_NEXT(ii).FRES_KIND = FRES_KIND_SAKI Then
                        mobjTRK_BUF_NEXT(ii).UPDATE_TPRG_TRK_BUF()
                    End If

                    mobjTRK_BUF_RELAY(ii).GET_TPRG_TRK_BUF(False)
                    mobjTRK_BUF_RELAY(ii).FRSV_PALLET = mFPALLET_ID                                 'ﾊﾟﾚｯﾄID
                    mobjTRK_BUF_RELAY(ii).FRES_KIND = mFRES_KIND                                    '引当状態
                    mobjTRK_BUF_RELAY(ii).FBUF_IN_DT = Now                                          'ﾊﾞｯﾌｧ入日時
                    If mobjTRK_BUF_RELAY(ii).FPALLET_ID = "" And _
                       mobjTRK_BUF_RELAY(ii).FRES_KIND = FRES_KIND_SAKI Then
                        mobjTRK_BUF_RELAY(ii).UPDATE_TPRG_TRK_BUF()
                    End If
                Next
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
