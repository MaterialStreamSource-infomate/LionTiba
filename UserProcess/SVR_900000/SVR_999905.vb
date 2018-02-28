'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする04(読込用)
'         前回の電文送信時間を測定
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_999905
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
            objAryXLOG_MODBUS.FTEXT_ID = "読"                   'ﾃｷｽﾄID
            objAryXLOG_MODBUS.ORDER_BY = " FLOG_CHECK_DT1, FLOG_NO" '並び
            'objAryXLOG_MODBUS.FLOG_NO = "2013021400032656"
            ''objAryXLOG_MODBUS.FLOG_NO = "2013021400034241"
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
                        objXLOG_MODBUS.XCOMMENT07 = ""


                        '********************************************************
                        'ﾓﾄﾞﾊﾞｽ通信ﾛｸﾞ      前回ﾚｺｰﾄﾞﾁｪｯｸ
                        '********************************************************
                        Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
                        Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
                        Dim strSQL As String = ""       'SQL文
                        strSQL &= vbCrLf & " SELECT    "
                        strSQL &= vbCrLf & "    MAX(FLOG_CHECK_DT1) AS FLOG_CHECK_DT1 "
                        strSQL &= vbCrLf & " FROM "
                        strSQL &= vbCrLf & "    XLOG_MODBUS "
                        strSQL &= vbCrLf & " WHERE "
                        strSQL &= vbCrLf & "    1 = 1 "
                        strSQL &= vbCrLf & "    AND FLOG_CHECK_DT1 < TO_DATE('" & Format(objXLOG_MODBUS.FLOG_CHECK_DT1, "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS') "
                        strSQL &= vbCrLf & "    AND XCOMMENT01 = '" & objXLOG_MODBUS.XCOMMENT01 & "' "
                        strSQL &= vbCrLf & "    AND FTEXT_ID = '" & objXLOG_MODBUS.FTEXT_ID & "' "
                        strSQL &= vbCrLf & "  "
                        ObjDb.SQL = strSQL
                        objDataSet.Clear()
                        strDataSetName = "XLOG_MODBUS"
                        ObjDb.GetDataSet(strDataSetName, objDataSet)
                        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                            Dim dtmFLOG_CHECK_DT1_Before As Date = TO_DATE(objDataSet.Tables(strDataSetName).Rows(0)(0))
                            If dtmFLOG_CHECK_DT1_Before <> Date.MinValue Then
                                Dim objDiff As TimeSpan = objXLOG_MODBUS.FLOG_CHECK_DT1 - dtmFLOG_CHECK_DT1_Before
                                Dim strDiff As String = ZERO_PAD(TO_DECIMAL(Math.Floor(objDiff.TotalHours)), 2) _
                                                & ":" & ZERO_PAD(TO_DECIMAL(Math.Floor(objDiff.TotalMinutes)), 2) _
                                                & ":" & ZERO_PAD(TO_DECIMAL(Math.Floor(objDiff.TotalSeconds) Mod 60), 2)
                                objXLOG_MODBUS.XCOMMENT07 = "前回読込:" & strDiff & "   前"
                            End If
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

    'ﾃｰﾌﾞﾙｺﾋﾟｰしたので、一応その時のﾊﾞｯｸｱｯﾌﾟ
    'XLOG_MODBUS        →XLOG_MODBUS02
#Region "  ﾒｲﾝ処理                                                                              "
    ''''**********************************************************************************************
    '''' <summary>
    '''' ﾒｲﾝ処理
    '''' </summary>
    '''' <param name="strMSG_RECV">受信電文</param>
    '''' <param name="strMSG_SEND">送信電文</param>
    '''' <returns>OK/NG</returns>
    '''' <remarks></remarks>
    ''''**********************************************************************************************
    'Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
    '    Dim intRet As RetCode                   '戻り値
    '    'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
    '    Try


    '        '************************************************
    '        'ﾓﾄﾞﾊﾞｽ通信ﾛｸﾞ              取得
    '        '************************************************
    '        Dim objAryXLOG_MODBUS As New TBL_XLOG_MODBUS(Owner, ObjDb, ObjDbLog)
    '        'objAryXLOG_MODBUS.FCOMMAND_ID = "書"                'ｺﾏﾝﾄﾞID
    '        intRet = objAryXLOG_MODBUS.GET_XLOG_MODBUS_ANY
    '        If intRet = RetCode.OK Then
    '            For ii As Integer = 0 To UBound(objAryXLOG_MODBUS.ARYME)
    '                '(ﾙｰﾌﾟ:書込ｺﾏﾝﾄﾞのﾚｺｰﾄﾞ数)


    '                '************************************************************************************************
    '                '************************************************************************************************
    '                '初期設定
    '                '************************************************************************************************
    '                '************************************************************************************************
    '                Dim objXLOG_MODBUS As TBL_XLOG_MODBUS = objAryXLOG_MODBUS.ARYME(ii)



    '                Dim objXLOG_MODBUS02 As New TBL_XLOG_MODBUS02(Owner, ObjDb, ObjDbLog)
    '                objXLOG_MODBUS02.FLOG_CHECK_DT1 = objXLOG_MODBUS.FLOG_CHECK_DT1
    '                objXLOG_MODBUS02.FEQ_ID = objXLOG_MODBUS.FEQ_ID
    '                objXLOG_MODBUS02.XCOMMENT01 = objXLOG_MODBUS.XCOMMENT01
    '                objXLOG_MODBUS02.XCOMMENT01_01 = objXLOG_MODBUS.XCOMMENT01_01
    '                objXLOG_MODBUS02.XCOMMENT02 = objXLOG_MODBUS.XCOMMENT02
    '                objXLOG_MODBUS02.XCOMMENT03 = objXLOG_MODBUS.XCOMMENT03
    '                objXLOG_MODBUS02.XCOMMENT04 = objXLOG_MODBUS.XCOMMENT04
    '                objXLOG_MODBUS02.XCOMMENT05 = objXLOG_MODBUS.XCOMMENT05
    '                objXLOG_MODBUS02.XCOMMENT06 = objXLOG_MODBUS.XCOMMENT06
    '                objXLOG_MODBUS02.XCOMMENT07 = objXLOG_MODBUS.XCOMMENT07
    '                objXLOG_MODBUS02.XCOMMENT08 = objXLOG_MODBUS.XCOMMENT08
    '                objXLOG_MODBUS02.XCOMMENT09 = objXLOG_MODBUS.XCOMMENT09
    '                objXLOG_MODBUS02.FTEXT_ID = objXLOG_MODBUS.FTEXT_ID
    '                objXLOG_MODBUS02.FTRNS_SERIAL = objXLOG_MODBUS.FTRNS_SERIAL
    '                objXLOG_MODBUS02.FLOG_CHECK_DT2 = objXLOG_MODBUS.FLOG_CHECK_DT2
    '                objXLOG_MODBUS02.FDENBUN = objXLOG_MODBUS.FDENBUN
    '                objXLOG_MODBUS02.FDENBUN02 = objXLOG_MODBUS.FDENBUN02
    '                objXLOG_MODBUS02.FLOG_NO = objXLOG_MODBUS.FLOG_NO
    '                objXLOG_MODBUS02.ADD_XLOG_MODBUS02()


    '                ''************************************************************************************************
    '                ''************************************************************************************************
    '                ''電文解析
    '                ''************************************************************************************************
    '                ''************************************************************************************************
    '                'Dim strTel As String = objXLOG_MODBUS.FDENBUN


    '                ''********************************************************
    '                ''書込みｱﾄﾞﾚｽ取得
    '                ''********************************************************
    '                'Dim intAdrsCount As Integer = Change16To10(Mid(strTel, 9, 4))               '個数
    '                'Dim intStartAdrs As Integer = 40001 + Change16To10(Mid(strTel, 5, 4))       '書込み開始ｱﾄﾞﾚｽ
    '                'Dim intEndAdrs As Integer = intStartAdrs + intAdrsCount                     '書込み終了ｱﾄﾞﾚｽ
    '                'objXLOG_MODBUS.FTEXT_ID = intStartAdrs & "～" & intEndAdrs                  'ﾃｷｽﾄID


    '                ''********************************************************
    '                ''搬送指示判断
    '                ''********************************************************
    '                'If intAdrsCount = 3 Or intAdrsCount = 6 Then
    '                '    '(搬送指示判断)

    '                '    '==============================================
    '                '    '書込みﾃﾞｰﾀ部分を取得
    '                '    '==============================================
    '                '    Dim strWriteData As String
    '                '    If intAdrsCount <= 6 Then
    '                '        strWriteData = MID_SJIS(strTel, 15, intAdrsCount * 4)
    '                '    Else
    '                '        strWriteData = MID_SJIS(strTel, 15, 24)
    '                '    End If

    '                '    For jj As Integer = 1 To strWriteData.Length Step +4
    '                '        '(ﾙｰﾌﾟ:ｾｯﾄされた文字数)

    '                '        '==============================================
    '                '        'ﾃﾞｰﾀ取得
    '                '        '==============================================
    '                '        Dim strData16 As String = MID_SJIS(strWriteData, jj, 4)             '16進数
    '                '        Dim strData10 As String = Change16To10(strData16)                   '10進数
    '                '        Dim strData02 As String = Change10To2(strData10, 16)                '02進数

    '                '        '==============================================
    '                '        '入出庫
    '                '        '==============================================
    '                '        '1つ目
    '                '        Dim strDataInout01 As String = MID_SJIS(strData02, 2, 1)        '入庫ﾓｰﾄﾞ
    '                '        Dim strDataInout02 As String = MID_SJIS(strData02, 3, 1)        '出庫ﾓｰﾄﾞ
    '                '        Dim strDataInout03 As String = MID_SJIS(strData02, 4, 1)        'ﾍﾟｱ搬送
    '                '        Dim strDataInout04 As String = MID_SJIS(strData02, 5, 1)        'ﾌｫｰｸ2
    '                '        Dim strDataInout05 As String = MID_SJIS(strData02, 6, 1)        'ﾌｫｰｸ1
    '                '        Dim strDataInout06 As String = MID_SJIS(strData02, 7, 2)        'L/S番号
    '                '        Dim strDataInout07 As String = MID_SJIS(strData02, 10, 1)       'ﾀﾞﾌﾞﾙﾘｰﾁ
    '                '        Dim strDataInout08 As String = Change2To10(MID_SJIS(strData02, 11, 2))      '列
    '                '        Dim strDataInout09 As String = Change2To10(MID_SJIS(strData02, 14, 3))      '号機
    '                '        '2つ目
    '                '        Dim strDataInout10 As String = Change2To10(MID_SJIS(strData02, 4, 5))       '連
    '                '        Dim strDataInout11 As String = MID_SJIS(strData02, 9, 1)                    'ENDﾌﾗｸﾞ
    '                '        Dim strDataInout12 As String = MID_SJIS(strData02, 10, 1)                   '入棚再設定
    '                '        Dim strDataInout13 As String = Change2To10(MID_SJIS(strData02, 13, 4))      '段

    '                '        '==============================================
    '                '        'ﾃｷｽﾄﾎﾞｯｸｽに出力
    '                '        '==============================================
    '                '        Select Case jj
    '                '            Case 1, 13
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "入庫ﾓｰﾄﾞ  :" & strDataInout01 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "出庫ﾓｰﾄﾞ  :" & strDataInout02 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "ﾍﾟｱ搬送   :" & strDataInout03 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "ﾌｫｰｸ2     :" & strDataInout04 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "ﾌｫｰｸ1     :" & strDataInout05 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "L/S番号   :" & strDataInout06 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "ﾀﾞﾌﾞﾙﾘｰﾁ  :" & strDataInout07 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "列        :" & strDataInout08 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "号機      :" & strDataInout09 & vbCrLf
    '                '            Case 5, 17
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "連        :" & strDataInout10 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "ENDﾌﾗｸﾞ   :" & strDataInout11 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "入棚再設定:" & strDataInout12 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "段        :" & strDataInout13 & vbCrLf
    '                '            Case 9, 21
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "ｱﾄﾞﾚｽ     :" & strData16 & vbCrLf & vbCrLf
    '                '        End Select


    '                '        If 21 <= jj Then Exit For
    '                '    Next

    '                'End If




    '                'objXLOG_MODBUS.UPDATE_XLOG_MODBUS()
    '                '************************************************************************************************
    '                '************************************************************************************************
    '                '進捗出力
    '                '************************************************************************************************
    '                '************************************************************************************************
    '                If ii Mod 1000 = 0 Then
    '                    Call AddToLog(Format((ii * 100) / objAryXLOG_MODBUS.ARYME.Length, "0.00") & "%", "", LogType.INFO)
    '                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
    '                                     Format((ii * 100) / objAryXLOG_MODBUS.ARYME.Length, "0.00") & "%" _
    '                                     )
    '                End If


    '            Next
    '        End If


    '        '************************
    '        '正常完了
    '        '************************
    '        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
    '                         FLOG_DATA_TRN_SEND_NORMAL)


    '        Return RetCode.OK
    '    Catch ex As UserException
    '        Call ComUser(ex, MeSyoriID)
    '        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
    '        Return RetCode.NG
    '    Catch ex As Exception
    '        Call ComError(ex, MeSyoriID)
    '        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
    '        Return RetCode.NG
    '    End Try
    'End Function
#End Region
    'XLOG_MODBUS02      →XLOG_MODBUS
#Region "  ﾒｲﾝ処理                                                                              "
    ''''**********************************************************************************************
    '''' <summary>
    '''' ﾒｲﾝ処理
    '''' </summary>
    '''' <param name="strMSG_RECV">受信電文</param>
    '''' <param name="strMSG_SEND">送信電文</param>
    '''' <returns>OK/NG</returns>
    '''' <remarks></remarks>
    ''''**********************************************************************************************
    'Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
    '    Dim intRet As RetCode                   '戻り値
    '    'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
    '    Try


    '        '************************************************
    '        'ﾓﾄﾞﾊﾞｽ通信ﾛｸﾞ              取得
    '        '************************************************
    '        Dim objAryXLOG_MODBUS02 As New TBL_XLOG_MODBUS02(Owner, ObjDb, ObjDbLog)
    '        'objAryXLOG_MODBUS.FCOMMAND_ID = "書"                'ｺﾏﾝﾄﾞID
    '        intRet = objAryXLOG_MODBUS02.GET_XLOG_MODBUS02_ANY
    '        If intRet = RetCode.OK Then
    '            For ii As Integer = 0 To UBound(objAryXLOG_MODBUS02.ARYME)
    '                '(ﾙｰﾌﾟ:書込ｺﾏﾝﾄﾞのﾚｺｰﾄﾞ数)


    '                '************************************************************************************************
    '                '************************************************************************************************
    '                '初期設定
    '                '************************************************************************************************
    '                '************************************************************************************************
    '                Dim objXLOG_MODBUS02 As TBL_XLOG_MODBUS02 = objAryXLOG_MODBUS02.ARYME(ii)



    '                Dim objXLOG_MODBUS As New TBL_XLOG_MODBUS(Owner, ObjDb, ObjDbLog)
    '                objXLOG_MODBUS.FLOG_CHECK_DT1 = objXLOG_MODBUS02.FLOG_CHECK_DT1
    '                objXLOG_MODBUS.FEQ_ID = objXLOG_MODBUS02.FEQ_ID
    '                objXLOG_MODBUS.XCOMMENT01 = objXLOG_MODBUS02.XCOMMENT01
    '                objXLOG_MODBUS.XCOMMENT01_01 = objXLOG_MODBUS02.XCOMMENT01_01
    '                objXLOG_MODBUS.XCOMMENT02 = objXLOG_MODBUS02.XCOMMENT02
    '                objXLOG_MODBUS.XCOMMENT03 = objXLOG_MODBUS02.XCOMMENT03
    '                objXLOG_MODBUS.XCOMMENT04 = objXLOG_MODBUS02.XCOMMENT04
    '                objXLOG_MODBUS.XCOMMENT05 = objXLOG_MODBUS02.XCOMMENT05
    '                objXLOG_MODBUS.XCOMMENT06 = objXLOG_MODBUS02.XCOMMENT06
    '                objXLOG_MODBUS.XCOMMENT07 = objXLOG_MODBUS02.XCOMMENT07
    '                objXLOG_MODBUS.XCOMMENT08 = objXLOG_MODBUS02.XCOMMENT08
    '                objXLOG_MODBUS.XCOMMENT09 = objXLOG_MODBUS02.XCOMMENT09
    '                objXLOG_MODBUS.FTEXT_ID = objXLOG_MODBUS02.FTEXT_ID
    '                objXLOG_MODBUS.FTRNS_SERIAL = objXLOG_MODBUS02.FTRNS_SERIAL
    '                objXLOG_MODBUS.FLOG_CHECK_DT2 = objXLOG_MODBUS02.FLOG_CHECK_DT2
    '                objXLOG_MODBUS.FDENBUN = objXLOG_MODBUS02.FDENBUN
    '                objXLOG_MODBUS.FDENBUN02 = objXLOG_MODBUS02.FDENBUN02
    '                objXLOG_MODBUS.FLOG_NO = objXLOG_MODBUS02.FLOG_NO
    '                objXLOG_MODBUS.ADD_XLOG_MODBUS()


    '                ''************************************************************************************************
    '                ''************************************************************************************************
    '                ''電文解析
    '                ''************************************************************************************************
    '                ''************************************************************************************************
    '                'Dim strTel As String = objXLOG_MODBUS.FDENBUN


    '                ''********************************************************
    '                ''書込みｱﾄﾞﾚｽ取得
    '                ''********************************************************
    '                'Dim intAdrsCount As Integer = Change16To10(Mid(strTel, 9, 4))               '個数
    '                'Dim intStartAdrs As Integer = 40001 + Change16To10(Mid(strTel, 5, 4))       '書込み開始ｱﾄﾞﾚｽ
    '                'Dim intEndAdrs As Integer = intStartAdrs + intAdrsCount                     '書込み終了ｱﾄﾞﾚｽ
    '                'objXLOG_MODBUS.FTEXT_ID = intStartAdrs & "～" & intEndAdrs                  'ﾃｷｽﾄID


    '                ''********************************************************
    '                ''搬送指示判断
    '                ''********************************************************
    '                'If intAdrsCount = 3 Or intAdrsCount = 6 Then
    '                '    '(搬送指示判断)

    '                '    '==============================================
    '                '    '書込みﾃﾞｰﾀ部分を取得
    '                '    '==============================================
    '                '    Dim strWriteData As String
    '                '    If intAdrsCount <= 6 Then
    '                '        strWriteData = MID_SJIS(strTel, 15, intAdrsCount * 4)
    '                '    Else
    '                '        strWriteData = MID_SJIS(strTel, 15, 24)
    '                '    End If

    '                '    For jj As Integer = 1 To strWriteData.Length Step +4
    '                '        '(ﾙｰﾌﾟ:ｾｯﾄされた文字数)

    '                '        '==============================================
    '                '        'ﾃﾞｰﾀ取得
    '                '        '==============================================
    '                '        Dim strData16 As String = MID_SJIS(strWriteData, jj, 4)             '16進数
    '                '        Dim strData10 As String = Change16To10(strData16)                   '10進数
    '                '        Dim strData02 As String = Change10To2(strData10, 16)                '02進数

    '                '        '==============================================
    '                '        '入出庫
    '                '        '==============================================
    '                '        '1つ目
    '                '        Dim strDataInout01 As String = MID_SJIS(strData02, 2, 1)        '入庫ﾓｰﾄﾞ
    '                '        Dim strDataInout02 As String = MID_SJIS(strData02, 3, 1)        '出庫ﾓｰﾄﾞ
    '                '        Dim strDataInout03 As String = MID_SJIS(strData02, 4, 1)        'ﾍﾟｱ搬送
    '                '        Dim strDataInout04 As String = MID_SJIS(strData02, 5, 1)        'ﾌｫｰｸ2
    '                '        Dim strDataInout05 As String = MID_SJIS(strData02, 6, 1)        'ﾌｫｰｸ1
    '                '        Dim strDataInout06 As String = MID_SJIS(strData02, 7, 2)        'L/S番号
    '                '        Dim strDataInout07 As String = MID_SJIS(strData02, 10, 1)       'ﾀﾞﾌﾞﾙﾘｰﾁ
    '                '        Dim strDataInout08 As String = Change2To10(MID_SJIS(strData02, 11, 2))      '列
    '                '        Dim strDataInout09 As String = Change2To10(MID_SJIS(strData02, 14, 3))      '号機
    '                '        '2つ目
    '                '        Dim strDataInout10 As String = Change2To10(MID_SJIS(strData02, 4, 5))       '連
    '                '        Dim strDataInout11 As String = MID_SJIS(strData02, 9, 1)                    'ENDﾌﾗｸﾞ
    '                '        Dim strDataInout12 As String = MID_SJIS(strData02, 10, 1)                   '入棚再設定
    '                '        Dim strDataInout13 As String = Change2To10(MID_SJIS(strData02, 13, 4))      '段

    '                '        '==============================================
    '                '        'ﾃｷｽﾄﾎﾞｯｸｽに出力
    '                '        '==============================================
    '                '        Select Case jj
    '                '            Case 1, 13
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "入庫ﾓｰﾄﾞ  :" & strDataInout01 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "出庫ﾓｰﾄﾞ  :" & strDataInout02 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "ﾍﾟｱ搬送   :" & strDataInout03 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "ﾌｫｰｸ2     :" & strDataInout04 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "ﾌｫｰｸ1     :" & strDataInout05 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "L/S番号   :" & strDataInout06 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "ﾀﾞﾌﾞﾙﾘｰﾁ  :" & strDataInout07 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "列        :" & strDataInout08 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "号機      :" & strDataInout09 & vbCrLf
    '                '            Case 5, 17
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "連        :" & strDataInout10 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "ENDﾌﾗｸﾞ   :" & strDataInout11 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "入棚再設定:" & strDataInout12 & vbCrLf
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "段        :" & strDataInout13 & vbCrLf
    '                '            Case 9, 21
    '                '                objXLOG_MODBUS.FMSG_PRM1 &= "ｱﾄﾞﾚｽ     :" & strData16 & vbCrLf & vbCrLf
    '                '        End Select


    '                '        If 21 <= jj Then Exit For
    '                '    Next

    '                'End If


    '                'objXLOG_MODBUS.UPDATE_XLOG_MODBUS()
    '                '************************************************************************************************
    '                '************************************************************************************************
    '                '進捗出力
    '                '************************************************************************************************
    '                '************************************************************************************************
    '                If ii Mod 1000 = 0 Then
    '                    Call AddToLog(Format((ii * 100) / objAryXLOG_MODBUS02.ARYME.Length, "0.00") & "%", "", LogType.INFO)
    '                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
    '                                     Format((ii * 100) / objAryXLOG_MODBUS02.ARYME.Length, "0.00") & "%" _
    '                                     )
    '                End If


    '            Next
    '        End If


    '        '************************
    '        '正常完了
    '        '************************
    '        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
    '                         FLOG_DATA_TRN_SEND_NORMAL)


    '        Return RetCode.OK
    '    Catch ex As UserException
    '        Call ComUser(ex, MeSyoriID)
    '        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
    '        Return RetCode.NG
    '    Catch ex As Exception
    '        Call ComError(ex, MeSyoriID)
    '        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
    '        Return RetCode.NG
    '    End Try
    'End Function
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
