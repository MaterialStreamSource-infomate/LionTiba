'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする05
'         ｺﾒﾝﾄ01_01にﾚｼﾞｽﾀ説明をｾｯﾄ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_999906
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
            objAryXLOG_MODBUS.ORDER_BY = " FLOG_CHECK_DT1, FLOG_NO" '並び
            intRet = objAryXLOG_MODBUS.GET_XLOG_MODBUS_ANY
            If intRet = RetCode.OK Then
                For ii As Integer = 0 To UBound(objAryXLOG_MODBUS.ARYME)
                    '(ﾙｰﾌﾟ:読込ｺﾏﾝﾄﾞのﾚｺｰﾄﾞ数)
                    Try


                        '************************************************************************************************
                        '************************************************************************************************
                        '初期設定
                        '************************************************************************************************
                        '************************************************************************************************
                        Dim objXLOG_MODBUS As TBL_XLOG_MODBUS = objAryXLOG_MODBUS.ARYME(ii)
                        objXLOG_MODBUS.XCOMMENT01_01 = ""


                        '********************************************************
                        'ｺﾒﾝﾄ01_01ﾏｽﾀ       取得
                        '********************************************************
                        Dim objXMST_XCOMMENT01_01 As New TBL_XMST_XCOMMENT01_01(Nothing, ObjDb, ObjDb)
                        objXMST_XCOMMENT01_01.FEQ_ID = objXLOG_MODBUS.FEQ_ID            '設備ID
                        objXMST_XCOMMENT01_01.XCOMMENT01 = objXLOG_MODBUS.XCOMMENT01    'ｺﾒﾝﾄ01
                        intRet = objXMST_XCOMMENT01_01.GET_XMST_XCOMMENT01_01(False)    '取得
                        If intRet = RetCode.OK Then
                            objXLOG_MODBUS.XCOMMENT01_01 = objXMST_XCOMMENT01_01.XCOMMENT01_01
                        End If


                        objXLOG_MODBUS.UPDATE_XLOG_MODBUS()
                        '************************************************************************************************
                        '************************************************************************************************
                        '進捗出力
                        '************************************************************************************************
                        '************************************************************************************************
                        If ii Mod 1000 = 0 Then
                            Call AddToLog(Format((ii * 100) / objAryXLOG_MODBUS.ARYME.Length, "0.00") & "%", "", LogType.INFO)
                            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID _
                                           , Format((ii * 100) / objAryXLOG_MODBUS.ARYME.Length, "0.00") & "%" _
                                             )
                        End If
                        'If 10000 <= ii Then Exit For


                    Catch ex As Exception
                        Call ComError(ex, "[ﾛｸﾞ№:" & objAryXLOG_MODBUS.ARYME(ii).FLOG_NO & "]")
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
