'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする01
'         設備ID    (SWxx)
'         ｺﾏﾝﾄﾞID   (書込or読込)
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_999902
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
            Dim objAryXLOG_MODBUS As New TBL_XLOG_MODBUS(Owner, ObjDb, ObjDbLog)
            intRet = objAryXLOG_MODBUS.GET_XLOG_MODBUS_ANY
            If intRet = RetCode.OK Then
                For ii As Integer = 0 To UBound(objAryXLOG_MODBUS.ARYME)
                    '(ﾙｰﾌﾟ:全てのﾚｺｰﾄﾞ数)


                    '************************************************
                    '初期設定
                    '************************************************
                    Dim objXLOG_MODBUS As TBL_XLOG_MODBUS = objAryXLOG_MODBUS.ARYME(ii)


                    '************************************************
                    '電文解析
                    '************************************************
                    Dim strTel As String = objXLOG_MODBUS.FDENBUN
                    '====================================
                    '設備ID
                    '====================================
                    Select Case Mid(strTel, 1, 2)
                        Case "01" : objXLOG_MODBUS.FEQ_ID = "SW01"
                        Case "02" : objXLOG_MODBUS.FEQ_ID = "SW02"
                        Case "03" : objXLOG_MODBUS.FEQ_ID = "SW03"
                        Case "04" : objXLOG_MODBUS.FEQ_ID = "SW04"
                        Case "05" : objXLOG_MODBUS.FEQ_ID = "SW05"
                        Case "06" : objXLOG_MODBUS.FEQ_ID = "SW04A"
                        Case Else : objXLOG_MODBUS.FEQ_ID = "不明"
                    End Select

                    '====================================
                    'ｺﾏﾝﾄﾞID
                    '====================================
                    Select Case Mid(strTel, 3, 2)
                        Case "03" : objXLOG_MODBUS.FTEXT_ID = "読"
                        Case "10" : objXLOG_MODBUS.FTEXT_ID = "書"
                        Case Else : objXLOG_MODBUS.FTEXT_ID = "不明"
                    End Select
                    objXLOG_MODBUS.UPDATE_XLOG_MODBUS()     '更新


                    '************************************************
                    '進捗出力
                    '************************************************
                    If ii Mod 1000 = 0 Then
                        Call AddToLog(Format((ii * 100) / objAryXLOG_MODBUS.ARYME.Length, "0.00") & "%", "", LogType.INFO)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                         Format((ii * 100) / objAryXLOG_MODBUS.ARYME.Length, "0.00") & "%" _
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
