'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする02(書込用)
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_999903
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
            objAryXLOG_MODBUS.FTEXT_ID = "書"                   'ﾃｷｽﾄID
            intRet = objAryXLOG_MODBUS.GET_XLOG_MODBUS_ANY
            If intRet = RetCode.OK Then
                For ii As Integer = 0 To UBound(objAryXLOG_MODBUS.ARYME)
                    '(ﾙｰﾌﾟ:書込ｺﾏﾝﾄﾞのﾚｺｰﾄﾞ数)


                    '************************************************************************************************
                    '************************************************************************************************
                    '初期設定
                    '************************************************************************************************
                    '************************************************************************************************
                    Dim objXLOG_MODBUS As TBL_XLOG_MODBUS = objAryXLOG_MODBUS.ARYME(ii)
                    objXLOG_MODBUS.XCOMMENT01 = ""
                    objXLOG_MODBUS.XCOMMENT02 = ""
                    objXLOG_MODBUS.XCOMMENT08 = ""
                    objXLOG_MODBUS.XCOMMENT09 = ""


                    '************************************************************************************************
                    '************************************************************************************************
                    '電文解析
                    '************************************************************************************************
                    '************************************************************************************************
                    Dim strTel As String = objXLOG_MODBUS.FDENBUN


                    '********************************************************
                    '書込みｱﾄﾞﾚｽ取得
                    '********************************************************
                    Dim intAdrsCount As Integer = Change16To10(Mid(strTel, 9, 4))               '個数
                    Dim intStartAdrs As Integer = 40001 + Change16To10(Mid(strTel, 5, 4))       '書込み開始ｱﾄﾞﾚｽ
                    Dim intEndAdrs As Integer = intStartAdrs + intAdrsCount - 1                 '書込み終了ｱﾄﾞﾚｽ
                    If intStartAdrs = intEndAdrs Then
                        objXLOG_MODBUS.XCOMMENT01 = intStartAdrs                                'ﾃｷｽﾄID
                    Else
                        objXLOG_MODBUS.XCOMMENT01 = intStartAdrs & "～" & intEndAdrs            'ﾃｷｽﾄID
                    End If


                    '********************************************************
                    '書込みﾃﾞｰﾀ取得
                    '********************************************************
                    For jj As Integer = 0 To intAdrsCount - 1
                        '(ﾙｰﾌﾟ:書込ﾃﾞｰﾀ数)

                        '================================================
                        '書込ﾃﾞｰﾀ
                        '================================================
                        Dim strData16 As String = Mid(strTel, 15 + (jj * 4), 4)
                        Dim intData10 As Integer = Change16To10(strData16)
                        Dim strData02 As String = Change10To2(intData10, 16)
                        objXLOG_MODBUS.XCOMMENT02 &= "[" & TO_STRING(intStartAdrs + jj) & "←" & TO_STRING(intData10) & "]"

                        '================================================
                        '設備状況       ﾁｪｯｸ
                        '================================================
                        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                        Dim strFEQ_ID_LOCAL As String = Mid(strTel, 1, 2) & "_" & ZERO_PAD(intStartAdrs + jj, 6)
                        Dim strFEQ_ID As String = "OTH" & strFEQ_ID_LOCAL
                        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '設備ID
                        objTSTS_EQ_CTRL.FEQ_ID_LOCAL = strFEQ_ID_LOCAL      'ﾛｰｶﾙ設備ID
                        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(False)    '取得
                        If intRet = RetCode.OK Then
                            '(ﾚｺｰﾄﾞが存在した場合)
                            If objTSTS_EQ_CTRL.FEQ_STS <> TO_STRING(intData10) Then
                                '(値が変化していた場合)
                                'ｺﾒﾝﾄ
                                objXLOG_MODBUS.XCOMMENT03 &= "[設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "|" & objTSTS_EQ_CTRL.FEQ_STS & "→" & TO_STRING(intData10) & "]"
                                '設備状況
                                If InStr(objTSTS_EQ_CTRL.FEQ_NAME, "書") = 0 Then objTSTS_EQ_CTRL.FEQ_NAME &= "書" '設備名称
                                objTSTS_EQ_CTRL.FEQ_STS = TO_STRING(intData10)  '設備状態
                                objTSTS_EQ_CTRL.FUPDATE_DT = Now                '更新日時
                                objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()           '更新
                            Else
                                '(値が変化なしの場合)
                                'ｺﾒﾝﾄ
                                'objXLOG_MODBUS.XCOMMENT03 &= "---"
                            End If
                        Else
                            '(ﾚｺｰﾄﾞが存在しない場合)
                            'ｺﾒﾝﾄ
                            objXLOG_MODBUS.XCOMMENT03 &= "[設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "|" & TO_STRING(intData10) & "(ﾚｺｰﾄﾞ追加)]"
                            '設備状況
                            objTSTS_EQ_CTRL.FEQ_KUBUN = 0       '設備区分
                            objTSTS_EQ_CTRL.FEQ_NAME = "書"     '設備名称
                            objTSTS_EQ_CTRL.FUPDATE_DT = Now    '更新日時
                            objTSTS_EQ_CTRL.FENTRY_DT = Now     '登録日時
                            objTSTS_EQ_CTRL.FEQ_STS = TO_STRING(intData10)  '設備状態
                            objTSTS_EQ_CTRL.ADD_TSTS_EQ_CTRL()              '追加
                        End If


                    Next


                    '********************************************************
                    '搬送指示判断
                    '********************************************************
                    If intAdrsCount = 3 Or intAdrsCount = 6 Then
                        '(搬送指示判断)

                        '==============================================
                        '書込みﾃﾞｰﾀ部分を取得
                        '==============================================
                        Dim strWriteData As String
                        If intAdrsCount <= 6 Then
                            strWriteData = Mid(strTel, 15, intAdrsCount * 4)
                        Else
                            strWriteData = Mid(strTel, 15, 24)
                        End If

                        For jj As Integer = 1 To strWriteData.Length Step +4
                            '(ﾙｰﾌﾟ:ｾｯﾄされた文字数)

                            '==============================================
                            'ﾃﾞｰﾀ取得
                            '==============================================
                            Dim strData16 As String = Mid(strWriteData, jj, 4)             '16進数
                            Dim strData10 As String = Change16To10(strData16)                   '10進数
                            Dim strData02 As String = Change10To2(strData10, 16)                '02進数

                            '==============================================
                            '入出庫
                            '==============================================
                            '1つ目
                            Dim strDataInout01 As String = Mid(strData02, 2, 1)        '入庫ﾓｰﾄﾞ
                            Dim strDataInout02 As String = Mid(strData02, 3, 1)        '出庫ﾓｰﾄﾞ
                            Dim strDataInout03 As String = Mid(strData02, 4, 1)        'ﾍﾟｱ搬送
                            Dim strDataInout04 As String = Mid(strData02, 5, 1)        'ﾌｫｰｸ2
                            Dim strDataInout05 As String = Mid(strData02, 6, 1)        'ﾌｫｰｸ1
                            Dim strDataInout06 As String = Change2To10(MID_SJIS(strData02, 7, 2))       'L/S番号
                            Dim strDataInout07 As String = Mid(strData02, 10, 1)                        'ﾀﾞﾌﾞﾙﾘｰﾁ
                            Dim strDataInout08 As String = Change2To10(MID_SJIS(strData02, 11, 2))      '列
                            Dim strDataInout09 As String = Change2To10(MID_SJIS(strData02, 13, 4))      '号機
                            '2つ目
                            Dim strDataInout10 As String = Change2To10(MID_SJIS(strData02, 4, 5))       '連
                            Dim strDataInout11 As String = Mid(strData02, 9, 1)                         'ENDﾌﾗｸﾞ
                            Dim strDataInout12 As String = Mid(strData02, 10, 1)                        '入棚再設定
                            Dim strDataInout13 As String = Change2To10(MID_SJIS(strData02, 13, 4))      '段

                            '==============================================
                            'ﾃｷｽﾄﾎﾞｯｸｽに出力
                            '==============================================
                            Select Case jj
                                Case 1, 13

                                    objXLOG_MODBUS.XCOMMENT09 &= "[入庫ﾓｰﾄﾞ  :" & strDataInout01 & "]"
                                    objXLOG_MODBUS.XCOMMENT09 &= "[出庫ﾓｰﾄﾞ  :" & strDataInout02 & "]"
                                    objXLOG_MODBUS.XCOMMENT09 &= "[ﾍﾟｱ搬送   :" & strDataInout03 & "]"
                                    objXLOG_MODBUS.XCOMMENT09 &= "[ﾌｫｰｸ2     :" & strDataInout04 & "]"
                                    objXLOG_MODBUS.XCOMMENT09 &= "[ﾌｫｰｸ1     :" & strDataInout05 & "]"
                                    objXLOG_MODBUS.XCOMMENT09 &= "[L/S番号   :" & strDataInout06 & "]"
                                    objXLOG_MODBUS.XCOMMENT09 &= "[ﾀﾞﾌﾞﾙﾘｰﾁ  :" & strDataInout07 & "]"
                                    objXLOG_MODBUS.XCOMMENT09 &= "[列        :" & strDataInout08 & "]"
                                    objXLOG_MODBUS.XCOMMENT09 &= "[号機      :" & strDataInout09 & "]"
                                    'objXLOG_MODBUS.XCOMMENT09 &= "[入庫ﾓｰﾄﾞ  :" & strDataInout01 & "]" & vbCrLf
                                    'objXLOG_MODBUS.XCOMMENT09 &= "[出庫ﾓｰﾄﾞ  :" & strDataInout02 & "]" & vbCrLf
                                    'objXLOG_MODBUS.XCOMMENT09 &= "[ﾍﾟｱ搬送   :" & strDataInout03 & "]" & vbCrLf
                                    'objXLOG_MODBUS.XCOMMENT09 &= "[ﾌｫｰｸ2     :" & strDataInout04 & "]" & vbCrLf
                                    'objXLOG_MODBUS.XCOMMENT09 &= "[ﾌｫｰｸ1     :" & strDataInout05 & "]" & vbCrLf
                                    'objXLOG_MODBUS.XCOMMENT09 &= "[L/S番号   :" & strDataInout06 & "]" & vbCrLf
                                    'objXLOG_MODBUS.XCOMMENT09 &= "[ﾀﾞﾌﾞﾙﾘｰﾁ  :" & strDataInout07 & "]" & vbCrLf
                                    'objXLOG_MODBUS.XCOMMENT09 &= "[列        :" & strDataInout08 & "]" & vbCrLf
                                    'objXLOG_MODBUS.XCOMMENT09 &= "[号機      :" & strDataInout09 & "]" & vbCrLf
                                    '棚番
                                    If TO_INTEGER(strDataInout08) = 0 Or TO_INTEGER(strDataInout09) = 0 Then
                                        objXLOG_MODBUS.XCOMMENT08 &= "0"
                                    Else
                                        objXLOG_MODBUS.XCOMMENT08 &= TO_STRING((TO_INTEGER(strDataInout09) * 2) + (TO_INTEGER(strDataInout08) - 2))
                                    End If

                                Case 5, 17

                                    objXLOG_MODBUS.XCOMMENT09 &= "[連        :" & strDataInout10 & "]"
                                    objXLOG_MODBUS.XCOMMENT09 &= "[ENDﾌﾗｸﾞ   :" & strDataInout11 & "]"
                                    objXLOG_MODBUS.XCOMMENT09 &= "[入棚再設定:" & strDataInout12 & "]"
                                    objXLOG_MODBUS.XCOMMENT09 &= "[段        :" & strDataInout13 & "]"
                                    'objXLOG_MODBUS.XCOMMENT09 &= "[連        :" & strDataInout10 & "]" & vbCrLf
                                    'objXLOG_MODBUS.XCOMMENT09 &= "[ENDﾌﾗｸﾞ   :" & strDataInout11 & "]" & vbCrLf
                                    'objXLOG_MODBUS.XCOMMENT09 &= "[入棚再設定:" & strDataInout12 & "]" & vbCrLf
                                    'objXLOG_MODBUS.XCOMMENT09 &= "[段        :" & strDataInout13 & "]" & vbCrLf
                                    '棚番
                                    objXLOG_MODBUS.XCOMMENT08 &= "-" & strDataInout10 & "-" & strDataInout13 & Space(3)

                                Case 9, 21

                                    objXLOG_MODBUS.XCOMMENT09 &= "[ｱﾄﾞﾚｽ     :" & TO_STRING(Change16To10(strData16)) & "]"
                                    'objXLOG_MODBUS.XCOMMENT09 &= "[ｱﾄﾞﾚｽ     :" & TO_STRING(Change16To10(strData16)) & "]" & vbCrLf & vbCrLf
                                    '棚番
                                    objXLOG_MODBUS.XCOMMENT08 &= TO_STRING(Change16To10(strData16)) & Space(3)

                            End Select


                            If 21 <= jj Then Exit For
                        Next

                    End If




                    objXLOG_MODBUS.UPDATE_XLOG_MODBUS()
                    '************************************************************************************************
                    '************************************************************************************************
                    '進捗出力
                    '************************************************************************************************
                    '************************************************************************************************
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
