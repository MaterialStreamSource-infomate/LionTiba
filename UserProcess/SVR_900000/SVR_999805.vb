'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】Melsec電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする04(読書込用)
'         前回の電文送信時間を測定
'         Melsecのﾛｸﾞは、時間を計算して出しているので、まったく意味不明な機能だった
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_999805
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ用)</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  ﾒｲﾝ処理                                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '************************************************
            'ﾓﾄﾞﾊﾞｽ通信ﾛｸﾞ              取得
            '************************************************
            Dim objAryXLOG_MELSEC As New TBL_XLOG_MELSEC(Owner, ObjDb, ObjDbLog)
            'objAryXLOG_MELSEC.FTEXT_ID = "読"                   'ﾃｷｽﾄID
            objAryXLOG_MELSEC.ORDER_BY = " FLOG_CHECK_DT1, FLOG_NO" '並び
            'objAryXLOG_MELSEC.FLOG_NO = "2013021400032656"
            ''objAryXLOG_MELSEC.FLOG_NO = "2013021400034241"
            intRet = objAryXLOG_MELSEC.GET_XLOG_MELSEC_ANY
            If intRet = RetCode.OK Then
                For ii As Integer = 0 To UBound(objAryXLOG_MELSEC.ARYME)
                    '(ﾙｰﾌﾟ:読込ｺﾏﾝﾄﾞのﾚｺｰﾄﾞ数)
                    Try


                        '************************************************************************************************
                        '************************************************************************************************
                        '初期設定
                        '************************************************************************************************
                        '************************************************************************************************
                        Dim objXLOG_MELSEC As TBL_XLOG_MELSEC = objAryXLOG_MELSEC.ARYME(ii)
                        objXLOG_MELSEC.XCOMMENT07 = ""


                        '********************************************************
                        'ﾓﾄﾞﾊﾞｽ通信ﾛｸﾞ      前回ﾚｺｰﾄﾞﾁｪｯｸ
                        '********************************************************
                        Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
                        Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
                        Dim strSQL As String = ""       'SQL文
                        strSQL &= vbCrLf & " SELECT    "
                        strSQL &= vbCrLf & "    MAX(FLOG_CHECK_DT1) AS FLOG_CHECK_DT1 "
                        strSQL &= vbCrLf & " FROM "
                        strSQL &= vbCrLf & "    XLOG_MELSEC "
                        strSQL &= vbCrLf & " WHERE "
                        strSQL &= vbCrLf & "    1 = 1 "
                        strSQL &= vbCrLf & "    AND FLOG_CHECK_DT1 < TO_DATE('" & Format(objXLOG_MELSEC.FLOG_CHECK_DT1, "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS') "
                        strSQL &= vbCrLf & "    AND XCOMMENT01 = '" & objXLOG_MELSEC.XCOMMENT01 & "' "
                        strSQL &= vbCrLf & "    AND FTEXT_ID = '" & objXLOG_MELSEC.FTEXT_ID & "' "
                        strSQL &= vbCrLf & "  "
                        ObjDb.SQL = strSQL
                        objDataSet.Clear()
                        strDataSetName = "XLOG_MELSEC"
                        ObjDb.GetDataSet(strDataSetName, objDataSet)
                        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                            Dim dtmFLOG_CHECK_DT1_Before As Date = TO_DATE(objDataSet.Tables(strDataSetName).Rows(0)(0))
                            If dtmFLOG_CHECK_DT1_Before <> Date.MinValue Then
                                Dim objDiff As TimeSpan = objXLOG_MELSEC.FLOG_CHECK_DT1 - dtmFLOG_CHECK_DT1_Before
                                Dim strDiff As String = ZERO_PAD(TO_DECIMAL(Math.Floor(objDiff.TotalHours)), 2) _
                                                & ":" & ZERO_PAD(TO_DECIMAL(Math.Floor(objDiff.TotalMinutes)), 2) _
                                                & ":" & ZERO_PAD(TO_DECIMAL(Math.Floor(objDiff.TotalSeconds)), 2)
                                objXLOG_MELSEC.XCOMMENT07 = "前回読込:" & strDiff & "   前"
                            End If
                        End If


                        objXLOG_MELSEC.UPDATE_XLOG_MELSEC()
                        '************************************************************************************************
                        '************************************************************************************************
                        '進捗出力
                        '************************************************************************************************
                        '************************************************************************************************
                        If ii Mod 1000 = 0 Then
                            Call AddToLog(Format((ii * 100) / objAryXLOG_MELSEC.ARYME.Length, "0.00") & "%", "", LogType.INFO)
                            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID _
                                           , Format((ii * 100) / objAryXLOG_MELSEC.ARYME.Length, "0.00") & "%" _
                                             )
                        End If
                        'If 10000 <= ii Then Exit For


                    Catch ex As Exception
                        Call ComError(ex, "[ﾛｸﾞ№:" & objAryXLOG_MELSEC.ARYME(ii).FLOG_NO & "]")
                    End Try
                Next
            End If


            '************************
            '正常完了
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                             FLOG_DATA_TRN_SEND_NORMAL)


            Return RetCode.OK
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        End Try
    End Function
#End Region


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
