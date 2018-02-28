'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】Melsecﾛｸﾞの日付変換
'         最初と最後の時間をｾｯﾄして、その間ﾛｸﾞが均等になるように、日付変換する。
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_999801
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
            'Melsec通信ﾛｸﾞ              取得
            '************************************************
            Dim objAryXLOG_MELSEC As New TBL_XLOG_MELSEC(Owner, ObjDb, ObjDbLog)
            objAryXLOG_MELSEC.FLOG_CHECK_DT2 = CDate("2020/02/11 00:00:03")         '**************************************************************************************対象となるﾚｺｰﾄﾞ
            objAryXLOG_MELSEC.ORDER_BY = "FLOG_NO"
            intRet = objAryXLOG_MELSEC.GET_XLOG_MELSEC_ANY
            If intRet = RetCode.OK Then
                For ii As Integer = 0 To objAryXLOG_MELSEC.ARYME.Length - 1
                    '(ﾙｰﾌﾟ:一晩放置していたﾛｸﾞのﾚｺｰﾄﾞ数)


                    '************************************************
                    '平均時間を計算
                    '************************************************
                    Dim objXLOG_MELSEC As TBL_XLOG_MELSEC = objAryXLOG_MELSEC.ARYME(ii)


                    '************************************************
                    '平均時間を計算して、加算
                    '************************************************
                    Dim dtmStart As Date = CDate("2020/02/11 09:06:14")     '*******************************************************************************実際の開始時間
                    Dim dtmEnd As Date = CDate("2020/02/11 12:45:09")       '*******************************************************************************実際の終了時間
                    Dim dtmFLOG_CHECK_DT1 As Date       '確認日時_1
                    Dim objDiff As TimeSpan             'ﾄｰﾀﾙ時間(msec)
                    If ii = 0 Then
                        '(最初の一回目)
                        dtmFLOG_CHECK_DT1 = dtmStart            '確認日時_1
                    Else
                        '(二回目以降)
                        objDiff = dtmEnd - dtmFLOG_CHECK_DT1    'ﾄｰﾀﾙ時間(msec)
                        Dim dblAverageTime As Double = objDiff.TotalMilliseconds / (objAryXLOG_MELSEC.ARYME.Length - ii)  '1電文送信の平均時間
                        dtmFLOG_CHECK_DT1 = dtmFLOG_CHECK_DT1.AddMilliseconds(dblAverageTime)       '確認日時_1 更新
                    End If


                    '************************************************
                    'Melsec通信ﾛｸﾞ              更新
                    '************************************************
                    objXLOG_MELSEC.FLOG_CHECK_DT1 = dtmFLOG_CHECK_DT1   '確認日時_1
                    objXLOG_MELSEC.UPDATE_XLOG_MELSEC()                 '更新


                    '************************************************************************************************
                    '************************************************************************************************
                    '進捗出力
                    '************************************************************************************************
                    '************************************************************************************************
                    If ii Mod 1000 = 0 Then
                        Call AddToLog(Format((ii * 100) / objAryXLOG_MELSEC.ARYME.Length, "0.00") & "%", "", LogType.INFO)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                         Format((ii * 100) / objAryXLOG_MELSEC.ARYME.Length, "0.00") & "%" _
                                         )
                    End If


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
