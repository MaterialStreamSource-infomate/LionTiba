'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】一晩放置して収集したﾛｸﾞの日付変換
'         「02/09の夕刻」～「02/10の朝」のﾛｸﾞは、全て「2015/02/10」で登録されている事を前提とする。
'         「02/10の夕刻」～「02/11の朝」のﾛｸﾞは、全て「2015/02/11」で登録されている事を前提とする。
'         変換後は、2020年のﾛｸﾞとする。
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_999901
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
            Dim strSQL As String
            Dim objAryXLOG_MODBUS As New TBL_XLOG_MODBUS(Owner, ObjDb, ObjDbLog)
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "    * "
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "    XLOG_MODBUS "
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "        1 = 1 "
            strSQL &= vbCrLf & "    AND FLOG_CHECK_DT1 >= TO_DATE('2015/02/09 00:00:00','YYYY/MM/DD HH24:MI:SS') "
            strSQL &= vbCrLf & "    AND FLOG_CHECK_DT1 <= TO_DATE('2015/02/13 00:00:00','YYYY/MM/DD HH24:MI:SS') "
            strSQL &= vbCrLf & ""
            objAryXLOG_MODBUS.USER_SQL = strSQL
            intRet = objAryXLOG_MODBUS.GET_XLOG_MODBUS_USER
            If intRet = RetCode.OK Then
                For Each objXLOG_MODBUS As TBL_XLOG_MODBUS In objAryXLOG_MODBUS.ARYME
                    '(ﾙｰﾌﾟ:一晩放置していたﾛｸﾞのﾚｺｰﾄﾞ数)


                    '************************************************
                    '日付変換
                    '************************************************
                    If CDate("2015/02/10 12:00:00") < objXLOG_MODBUS.FLOG_CHECK_DT1 And objXLOG_MODBUS.FLOG_CHECK_DT1 < CDate("2015/02/11 00:00:00") Then
                        '(午後の場合は、前日の日付に変換)

                        objXLOG_MODBUS.FLOG_CHECK_DT1 = CDate(objXLOG_MODBUS.FLOG_CHECK_DT1).AddDays(-1)    '確認日時_1
                        objXLOG_MODBUS.FLOG_CHECK_DT2 = CDate(objXLOG_MODBUS.FLOG_CHECK_DT2).AddDays(-1)    '確認日時_2
                        objXLOG_MODBUS.UPDATE_XLOG_MODBUS()     '更新

                    ElseIf CDate("2015/02/11 12:00:00") < objXLOG_MODBUS.FLOG_CHECK_DT1 And objXLOG_MODBUS.FLOG_CHECK_DT1 < CDate("2015/02/12 00:00:00") Then
                        '(午後の場合は、前日の日付に変換)

                        objXLOG_MODBUS.FLOG_CHECK_DT1 = CDate(objXLOG_MODBUS.FLOG_CHECK_DT1).AddDays(-1)    '確認日時_1
                        objXLOG_MODBUS.FLOG_CHECK_DT2 = CDate(objXLOG_MODBUS.FLOG_CHECK_DT2).AddDays(-1)    '確認日時_2
                        objXLOG_MODBUS.UPDATE_XLOG_MODBUS()     '更新

                    End If


                    '************************************************
                    '年変換
                    '************************************************
                    objXLOG_MODBUS.FLOG_CHECK_DT1 = CDate(objXLOG_MODBUS.FLOG_CHECK_DT1).AddYears(5)    '確認日時_1
                    objXLOG_MODBUS.FLOG_CHECK_DT2 = CDate(objXLOG_MODBUS.FLOG_CHECK_DT2).AddYears(5)    '確認日時_2
                    objXLOG_MODBUS.UPDATE_XLOG_MODBUS()     '更新


                Next
            End If


            '************************
            '正常完了
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                             FLOG_DATA_TRN_SEND_NORMAL                             )


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
