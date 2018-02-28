'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾙｰﾄ設備ﾁｪｯｸｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100203
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義                                                                      "
    Private mFBUF_FM As Nullable(Of Integer)        '元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFEQ_ID_CRANE_FM As String              '元ｸﾚｰﾝ設備ID
    Private mFBUF_TO As Nullable(Of Integer)        '先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFEQ_ID_CRANE_TO As String              '先ｸﾚｰﾝ設備ID
    Private mstrNG_DTL As String                    'NG詳細
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
    ''' =======================================
    ''' <summary>元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</summary>
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
    ''' =======================================
    ''' <summary>元ｸﾚｰﾝ設備ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FEQ_ID_CRANE_FM() As String
        Get
            Return mFEQ_ID_CRANE_FM
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CRANE_FM = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</summary>
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
    ''' =======================================
    ''' <summary>先ｸﾚｰﾝ設備ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FEQ_ID_CRANE_TO() As String
        Get
            Return mFEQ_ID_CRANE_TO
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CRANE_TO = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>NG詳細</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property STRNG_DTL() As String
        Get
            Return mstrNG_DTL
        End Get
        Set(ByVal Value As String)
            mstrNG_DTL = Value
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
#Region "  ﾙｰﾄ設備ﾁｪｯｸ                                                                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾙｰﾄ設備ﾁｪｯｸ
    ''' </summary>
    ''' <param name="objTSTS_HIKIATE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function CHECK_ROUTE(ByRef objTSTS_HIKIATE As TBL_TSTS_HIKIATE) As RetCode
        Try
            Dim strSQL As String        'SQL文
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            Dim intRet As RetCode       '戻り値


            '************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '************************
            If IsNull(mFBUF_FM) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[元ﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFBUF_TO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[先ﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFEQ_ID_CRANE_FM) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[元ｸﾚｰﾝ設備ID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFEQ_ID_CRANE_TO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[先ｸﾚｰﾝ設備ID]"
                Throw New UserException(strMsg)
            End If


            '************************
            '搬送起動判定ﾏｽﾀ特定
            '************************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    * "
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TMST_CHECK_EQ"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FBUF_FM = " & TO_STRING(mFBUF_FM)                   '元ﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "    AND FBUF_TO = " & TO_STRING(mFBUF_TO)                   '先ﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "    AND FEQ_ID_CRANE_FM = '" & mFEQ_ID_CRANE_FM & "'"       '元ｸﾚｰﾝ設備ID
            strSQL &= vbCrLf & "    AND FEQ_ID_CRANE_TO = '" & mFEQ_ID_CRANE_TO & "'"       '先ｸﾚｰﾝ設備ID
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    FCHECK_EQ_INDEX"                    '判定設備ｲﾝﾃﾞｯｸｽ
            strSQL &= vbCrLf
            Dim objTMST_CHECK_EQ As New TBL_TMST_CHECK_EQ(Owner, ObjDb, ObjDbLog) '搬送起動判定ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
            objTMST_CHECK_EQ.USER_SQL = strSQL
            intRet = objTMST_CHECK_EQ.GET_TMST_CHECK_EQ_USER()
            If intRet = RetCode.OK Then
                '(見つかった場合)

                For ii As Integer = LBound(objTMST_CHECK_EQ.ARYME) To UBound(objTMST_CHECK_EQ.ARYME)
                    '(ﾙｰﾌﾟ:対象となる搬送起動判定ﾏｽﾀのﾚｺｰﾄﾞ数)


                    '************************
                    '設備状況の特定
                    '************************
                    Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog) '設備状況ｸﾗｽ
                    objTSTS_EQ_CTRL.FEQ_ID = objTMST_CHECK_EQ.ARYME(ii).FCHECK_EQ_ID    '判定設備ID
                    intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)                     '特定


                    '************************
                    '設備状態ﾁｪｯｸ
                    '************************
                    If TO_INTEGER(objTMST_CHECK_EQ.ARYME(ii).FEQ_STS) <> FEQ_STS_SCHECK_OFF And _
                       TO_INTEGER(objTMST_CHECK_EQ.ARYME(ii).FEQ_STS) <> TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS) Then
                        '(設備状態がNGの場合)

                        '========================
                        'NG詳細の登録
                        '========================
                        mstrNG_DTL = "設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "  ,設備名:" & objTSTS_EQ_CTRL.FEQ_NAME & "  ,ﾛｰｶﾙ設備ID:" & objTSTS_EQ_CTRL.FEQ_ID_LOCAL & "  ,設備状態:" & TO_STRING(objTSTS_EQ_CTRL.FEQ_STS) & "  ,判定状態:" & TO_STRING(objTMST_CHECK_EQ.ARYME(ii).FEQ_STS)

                        '========================
                        '指示送信待ち理由の登録
                        '========================
                        objTSTS_HIKIATE.FWAIT_REASON = mstrNG_DTL
                        objTSTS_HIKIATE.FUPDATE_DT = Now
                        objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                        Return (RetCode.NG)

                    ElseIf TO_INTEGER(objTMST_CHECK_EQ.ARYME(ii).FEQ_CUT_STS) <> FEQ_CUT_STS_SCHECK_OFF And _
                           TO_INTEGER(objTMST_CHECK_EQ.ARYME(ii).FEQ_CUT_STS) <> TO_INTEGER(objTSTS_EQ_CTRL.FEQ_CUT_STS) Then
                        '(切離状態がNGの場合)

                        '========================
                        'NG詳細の登録
                        '========================
                        mstrNG_DTL = "設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "  ,設備名:" & objTSTS_EQ_CTRL.FEQ_NAME & "  ,ﾛｰｶﾙ設備ID:" & objTSTS_EQ_CTRL.FEQ_ID_LOCAL & "  ,切離状態:" & TO_STRING(objTSTS_EQ_CTRL.FEQ_CUT_STS) & "  ,判定状態:" & TO_STRING(objTMST_CHECK_EQ.ARYME(ii).FEQ_CUT_STS)

                        '========================
                        '指示送信待ち理由の登録
                        '========================
                        objTSTS_HIKIATE.FWAIT_REASON = mstrNG_DTL
                        objTSTS_HIKIATE.FUPDATE_DT = Now
                        objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                        Return (RetCode.NG)


                    ElseIf TO_INTEGER(objTMST_CHECK_EQ.ARYME(ii).FEQ_REQ_STS) <> FEQ_CUT_STS_SCHECK_OFF And _
                           TO_INTEGER(objTMST_CHECK_EQ.ARYME(ii).FEQ_REQ_STS) <> TO_INTEGER(objTSTS_EQ_CTRL.FEQ_REQ_STS) Then
                        '(要求状態をﾁｪｯｸする場合)

                        '========================
                        'NG詳細の登録
                        '========================
                        mstrNG_DTL = "設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "  ,設備名:" & objTSTS_EQ_CTRL.FEQ_NAME & "  ,ﾛｰｶﾙ設備ID:" & objTSTS_EQ_CTRL.FEQ_ID_LOCAL & "  ,要求状態:" & TO_STRING(objTSTS_EQ_CTRL.FEQ_REQ_STS) & "  ,判定状態:" & TO_STRING(objTMST_CHECK_EQ.ARYME(ii).FEQ_REQ_STS)

                        '========================
                        '指示送信待ち理由の登録
                        '========================
                        objTSTS_HIKIATE.FWAIT_REASON = mstrNG_DTL
                        objTSTS_HIKIATE.FUPDATE_DT = Now
                        objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                        Return (RetCode.NG)

                    End If

                Next

            End If
            objTMST_CHECK_EQ.ARYME_CLEAR()

            Return (RetCode.OK)

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
