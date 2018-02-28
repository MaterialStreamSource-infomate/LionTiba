'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】Melsec電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする02(書込用)
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_999803
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
            objAryXLOG_MELSEC.FTEXT_ID = "書"                   'ﾃｷｽﾄID
            intRet = objAryXLOG_MELSEC.GET_XLOG_MELSEC_ANY
            If intRet = RetCode.OK Then
                For ii As Integer = 0 To UBound(objAryXLOG_MELSEC.ARYME)
                    '(ﾙｰﾌﾟ:書込ｺﾏﾝﾄﾞのﾚｺｰﾄﾞ数)


                    '************************************************************************************************
                    '************************************************************************************************
                    '初期設定
                    '************************************************************************************************
                    '************************************************************************************************
                    Dim objXLOG_MELSEC As TBL_XLOG_MELSEC = objAryXLOG_MELSEC.ARYME(ii)
                    objXLOG_MELSEC.XCOMMENT01 = ""
                    objXLOG_MELSEC.XCOMMENT02 = ""


                    '************************************************************************************************
                    '************************************************************************************************
                    '電文解析
                    '************************************************************************************************
                    '************************************************************************************************
                    Dim strTel As String = objXLOG_MELSEC.FDENBUN


                    '********************************************************
                    '書込みｱﾄﾞﾚｽ取得
                    '********************************************************
                    Dim intAdrsCount As Integer = Change16To10(Mid(strTel, 21, 2))              '個数
                    Dim intStartAdrs As Integer = Change16To10(Mid(strTel, 15, 2) & Mid(strTel, 13, 2) & Mid(strTel, 11, 2) & Mid(strTel, 9, 2))       '書込み開始ｱﾄﾞﾚｽ
                    Dim intEndAdrs As Integer                                                   '書込み終了ｱﾄﾞﾚｽ
                    Dim strDeviceValue As String = Mid(strTel, 19, 2) & Mid(strTel, 17, 2)      'ﾃﾞﾊﾞｲｽ値

                    'ﾃﾞﾊﾞｲｽ
                    Dim strDeviceName As String = ""        'ﾃﾞﾊﾞｲｽ名
                    Select Case strDeviceValue.ToUpper
                        Case "4420" : strDeviceValue = "D"
                        Case "5720" : strDeviceValue = "W"
                        Case "5220" : strDeviceValue = "R"
                        Case "544E" : strDeviceValue = "TN"
                        Case "5453" : strDeviceValue = "TS"
                        Case "5443" : strDeviceValue = "TC"
                        Case "434E" : strDeviceValue = "CN"
                        Case "4353" : strDeviceValue = "CS"
                        Case "4343" : strDeviceValue = "CC"
                        Case "5820" : strDeviceValue = "X"
                        Case "5920" : strDeviceValue = "Y"
                        Case "4D20" : strDeviceValue = "M"
                        Case "4220" : strDeviceValue = "B"
                        Case "4620" : strDeviceValue = "F"
                        Case Else : strDeviceValue = "不明"
                    End Select
                    objXLOG_MELSEC.XCOMMENT01 = strDeviceValue

                    '書込み終了ｱﾄﾞﾚｽ
                    Select Case strDeviceValue
                        Case "X" : intEndAdrs = intStartAdrs + intAdrsCount * 16
                        Case Else : intEndAdrs = intStartAdrs + intAdrsCount - 1
                    End Select

                    'ｱﾄﾞﾚｽ表示
                    If intStartAdrs = intEndAdrs Then
                        objXLOG_MELSEC.XCOMMENT01 &= ZERO_PAD(intStartAdrs, 7)                                      'ﾃｷｽﾄID
                    Else
                        objXLOG_MELSEC.XCOMMENT01 &= ZERO_PAD(intStartAdrs, 7) & "～" & ZERO_PAD(intEndAdrs, 7)     'ﾃｷｽﾄID
                    End If


                    '********************************************************
                    '書込みﾃﾞｰﾀ取得
                    '********************************************************
                    For jj As Integer = 0 To intAdrsCount - 1
                        '(ﾙｰﾌﾟ:書込ﾃﾞｰﾀ数)

                        '================================================
                        '書込ﾃﾞｰﾀ
                        '================================================
                        Dim strData16 As String = Mid(strTel, 27 + (jj * 4), 2) & Mid(strTel, 25 + (jj * 4), 2)
                        Dim intData10 As Integer = Change16To10(strData16)
                        Dim strData02 As String = Change10To2(intData10, 16)
                        objXLOG_MELSEC.XCOMMENT02 &= "[" & strDeviceValue & ZERO_PAD(intStartAdrs + jj, 7) & "←" & TO_STRING(intData10) & "]"

                        '================================================
                        '設備状況       ﾁｪｯｸ(ﾚｼﾞｽﾀ値)
                        '================================================
                        Dim strFEQ_ID_LOCAL As String = "99" & "_" & ZERO_PAD(intStartAdrs + jj, 6)     'ﾛｰｶﾙ設備ID
                        Dim strFEQ_ID As String = "OTH" & strFEQ_ID_LOCAL                               '設備ID
                        intRet = Special01(objXLOG_MELSEC _
                                         , strFEQ_ID_LOCAL _
                                         , strFEQ_ID _
                                         , intData10 _
                                         )

                        '================================================
                        '設備状況       ﾁｪｯｸ(ﾋﾞｯﾄ値)
                        '================================================
                        If intRet = RetCode.OK Then
                            '(ﾚｼﾞｽﾀ値に変化があった場合)
                            For kk As Integer = 0 To strData02.Length - 1
                                '(ﾙｰﾌﾟ:16ﾋﾞｯﾄ)

                                Dim intData As Integer = TO_INTEGER(Mid(strData02, 16 - kk, 1))
                                Call Special01(objXLOG_MELSEC _
                                             , strFEQ_ID_LOCAL & "_" & ZERO_PAD(kk, 2) _
                                             , strFEQ_ID & "_" & ZERO_PAD(kk, 2) _
                                             , intData _
                                             )

                            Next
                        End If

                        ''================================================
                        ''名称取得
                        ''================================================
                        'Dim strFEQ_ID_LOCAL As String = "99" & "_" & ZERO_PAD(intStartAdrs + jj, 6)
                        'Dim strFEQ_ID As String = "OTH" & strFEQ_ID_LOCAL
                        'Dim objXMST_XCOMMENT01_01 As New TBL_XMST_XCOMMENT01_01(Owner, ObjDb, ObjDbLog)
                        'objXMST_XCOMMENT01_01.FEQ_ID = objXLOG_MELSEC.FEQ_ID
                        'objXMST_XCOMMENT01_01.XCOMMENT01 = strFEQ_ID_LOCAL
                        'objXMST_XCOMMENT01_01.GET_XMST_XCOMMENT01_01(False)

                        ''================================================
                        ''設備状況       ﾁｪｯｸ
                        ''================================================
                        'Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                        'objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '設備ID
                        'objTSTS_EQ_CTRL.FEQ_ID_LOCAL = strFEQ_ID_LOCAL      'ﾛｰｶﾙ設備ID
                        'intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(False)    '取得
                        'If intRet = RetCode.OK Then
                        '    '(ﾚｺｰﾄﾞが存在した場合)
                        '    If objTSTS_EQ_CTRL.FEQ_STS <> TO_STRING(intData10) Then
                        '        '(値が変化していた場合)
                        '        'ｺﾒﾝﾄ
                        '        objXLOG_MELSEC.XCOMMENT03 &= "[設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "(" & objXMST_XCOMMENT01_01.XCOMMENT01_01 & ")|" & objTSTS_EQ_CTRL.FEQ_STS & "→" & TO_STRING(intData10) & "]"
                        '        '設備状況
                        '        If InStr(objTSTS_EQ_CTRL.FEQ_NAME, "書") = 0 Then objTSTS_EQ_CTRL.FEQ_NAME &= "書" '設備名称
                        '        objTSTS_EQ_CTRL.FEQ_STS = TO_STRING(intData10)  '設備状態
                        '        objTSTS_EQ_CTRL.FUPDATE_DT = Now                '更新日時
                        '        objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()           '更新
                        '    Else
                        '        '(値が変化なしの場合)
                        '        'ｺﾒﾝﾄ
                        '        'objXLOG_MELSEC.XCOMMENT03 &= "---"
                        '    End If
                        'Else
                        '    '(ﾚｺｰﾄﾞが存在しない場合)
                        '    'ｺﾒﾝﾄ
                        '    objXLOG_MELSEC.XCOMMENT03 &= "[設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "|" & TO_STRING(intData10) & "(ﾚｺｰﾄﾞ追加)]"
                        '    '設備状況
                        '    objTSTS_EQ_CTRL.FEQ_KUBUN = 0       '設備区分
                        '    objTSTS_EQ_CTRL.FEQ_NAME = "書"     '設備名称
                        '    objTSTS_EQ_CTRL.FUPDATE_DT = Now    '更新日時
                        '    objTSTS_EQ_CTRL.FENTRY_DT = Now     '登録日時
                        '    objTSTS_EQ_CTRL.FEQ_STS = TO_STRING(intData10)  '設備状態
                        '    objTSTS_EQ_CTRL.ADD_TSTS_EQ_CTRL()              '追加
                        'End If


                    Next


                    ''********************************************************
                    ''搬送指示判断
                    ''********************************************************
                    'If intAdrsCount = 3 Or intAdrsCount = 6 Then
                    '    '(搬送指示判断)

                    '    '==============================================
                    '    '書込みﾃﾞｰﾀ部分を取得
                    '    '==============================================
                    '    Dim strWriteData As String
                    '    If intAdrsCount <= 6 Then
                    '        strWriteData = Mid(strTel, 15, intAdrsCount * 4)
                    '    Else
                    '        strWriteData = Mid(strTel, 15, 24)
                    '    End If

                    '    For jj As Integer = 1 To strWriteData.Length Step +4
                    '        '(ﾙｰﾌﾟ:ｾｯﾄされた文字数)

                    '        '==============================================
                    '        'ﾃﾞｰﾀ取得
                    '        '==============================================
                    '        Dim strData16 As String = Mid(strWriteData, jj, 4)             '16進数
                    '        Dim strData10 As String = Change16To10(strData16)                   '10進数
                    '        Dim strData02 As String = Change10To2(strData10, 16)                '02進数

                    '        '==============================================
                    '        '入出庫
                    '        '==============================================
                    '        '1つ目
                    '        Dim strDataInout01 As String = Mid(strData02, 2, 1)        '入庫ﾓｰﾄﾞ
                    '        Dim strDataInout02 As String = Mid(strData02, 3, 1)        '出庫ﾓｰﾄﾞ
                    '        Dim strDataInout03 As String = Mid(strData02, 4, 1)        'ﾍﾟｱ搬送
                    '        Dim strDataInout04 As String = Mid(strData02, 5, 1)        'ﾌｫｰｸ2
                    '        Dim strDataInout05 As String = Mid(strData02, 6, 1)        'ﾌｫｰｸ1
                    '        Dim strDataInout06 As String = Change2To10(MID_SJIS(strData02, 7, 2))       'L/S番号
                    '        Dim strDataInout07 As String = Mid(strData02, 10, 1)                        'ﾀﾞﾌﾞﾙﾘｰﾁ
                    '        Dim strDataInout08 As String = Change2To10(MID_SJIS(strData02, 11, 2))      '列
                    '        Dim strDataInout09 As String = Change2To10(MID_SJIS(strData02, 13, 4))      '号機
                    '        '2つ目
                    '        Dim strDataInout10 As String = Change2To10(MID_SJIS(strData02, 4, 5))       '連
                    '        Dim strDataInout11 As String = Mid(strData02, 9, 1)                         'ENDﾌﾗｸﾞ
                    '        Dim strDataInout12 As String = Mid(strData02, 10, 1)                        '入棚再設定
                    '        Dim strDataInout13 As String = Change2To10(MID_SJIS(strData02, 13, 4))      '段

                    '        '==============================================
                    '        'ﾃｷｽﾄﾎﾞｯｸｽに出力
                    '        '==============================================
                    '        Select Case jj
                    '            Case 1, 13

                    '                objXLOG_MELSEC.XCOMMENT09 &= "[入庫ﾓｰﾄﾞ  :" & strDataInout01 & "]" & vbCrLf
                    '                objXLOG_MELSEC.XCOMMENT09 &= "[出庫ﾓｰﾄﾞ  :" & strDataInout02 & "]" & vbCrLf
                    '                objXLOG_MELSEC.XCOMMENT09 &= "[ﾍﾟｱ搬送   :" & strDataInout03 & "]" & vbCrLf
                    '                objXLOG_MELSEC.XCOMMENT09 &= "[ﾌｫｰｸ2     :" & strDataInout04 & "]" & vbCrLf
                    '                objXLOG_MELSEC.XCOMMENT09 &= "[ﾌｫｰｸ1     :" & strDataInout05 & "]" & vbCrLf
                    '                objXLOG_MELSEC.XCOMMENT09 &= "[L/S番号   :" & strDataInout06 & "]" & vbCrLf
                    '                objXLOG_MELSEC.XCOMMENT09 &= "[ﾀﾞﾌﾞﾙﾘｰﾁ  :" & strDataInout07 & "]" & vbCrLf
                    '                objXLOG_MELSEC.XCOMMENT09 &= "[列        :" & strDataInout08 & "]" & vbCrLf
                    '                objXLOG_MELSEC.XCOMMENT09 &= "[号機      :" & strDataInout09 & "]" & vbCrLf
                    '                '棚番
                    '                If TO_INTEGER(strDataInout08) = 0 Or TO_INTEGER(strDataInout09) = 0 Then
                    '                    objXLOG_MELSEC.XCOMMENT08 &= "0"
                    '                Else
                    '                    objXLOG_MELSEC.XCOMMENT08 &= TO_STRING((TO_INTEGER(strDataInout09) * 2) + (TO_INTEGER(strDataInout08) - 2))
                    '                End If

                    '            Case 5, 17

                    '                objXLOG_MELSEC.XCOMMENT09 &= "[連        :" & strDataInout10 & "]" & vbCrLf
                    '                objXLOG_MELSEC.XCOMMENT09 &= "[ENDﾌﾗｸﾞ   :" & strDataInout11 & "]" & vbCrLf
                    '                objXLOG_MELSEC.XCOMMENT09 &= "[入棚再設定:" & strDataInout12 & "]" & vbCrLf
                    '                objXLOG_MELSEC.XCOMMENT09 &= "[段        :" & strDataInout13 & "]" & vbCrLf
                    '                '棚番
                    '                objXLOG_MELSEC.XCOMMENT08 &= "-" & strDataInout10 & "-" & strDataInout13 & Space(3)

                    '            Case 9, 21

                    '                objXLOG_MELSEC.XCOMMENT09 &= "[ｱﾄﾞﾚｽ     :" & TO_STRING(40001 + Change16To10(strData16)) & "]" & vbCrLf & vbCrLf
                    '                '棚番
                    '                objXLOG_MELSEC.XCOMMENT08 &= TO_STRING(40001 + Change16To10(strData16)) & Space(3)

                    '        End Select


                    '        If 21 <= jj Then Exit For
                    '    Next

                    'End If




                    objXLOG_MELSEC.UPDATE_XLOG_MELSEC()
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
#Region "  前回の設備と比較しての処理                                                               "
    Private Function Special01(ByRef objXLOG_MELSEC As TBL_XLOG_MELSEC _
                             , ByVal strFEQ_ID_LOCAL As String _
                             , ByVal strFEQ_ID As String _
                             , ByVal intData10 As String _
                             ) _
                             As RetCode
        Dim intRet As RetCode                   '戻り値
        Dim intReturn As RetCode = RetCode.NotEnough    '関数戻値(ﾃﾞｰﾀに変化があった場合:OK)(ﾃﾞｰﾀに変化がない場合:NotEnough)


        '================================================
        '名称取得
        '================================================
        Dim objXMST_XCOMMENT01_01 As New TBL_XMST_XCOMMENT01_01(Owner, ObjDb, ObjDbLog)
        objXMST_XCOMMENT01_01.FEQ_ID = objXLOG_MELSEC.FEQ_ID
        objXMST_XCOMMENT01_01.XCOMMENT01 = strFEQ_ID_LOCAL
        objXMST_XCOMMENT01_01.GET_XMST_XCOMMENT01_01(False)

        '================================================
        '設備状況       ﾁｪｯｸ
        '================================================
        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '設備ID
        objTSTS_EQ_CTRL.FEQ_ID_LOCAL = strFEQ_ID_LOCAL      'ﾛｰｶﾙ設備ID
        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(False)    '取得
        If intRet = RetCode.OK Then
            '(ﾚｺｰﾄﾞが存在した場合)
            If objTSTS_EQ_CTRL.FEQ_STS <> TO_STRING(intData10) Then
                '(値が変化していた場合)
                'ｺﾒﾝﾄ
                objXLOG_MELSEC.XCOMMENT03 &= "[" & objTSTS_EQ_CTRL.FEQ_ID_LOCAL & "(" & objXMST_XCOMMENT01_01.XCOMMENT01_01 & ")|" & objTSTS_EQ_CTRL.FEQ_STS & "→" & TO_STRING(intData10) & "]"
                If objTSTS_EQ_CTRL.FEQ_ID_LOCAL.Length = 12 Then
                    objXLOG_MELSEC.XCOMMENT09 &= "[" & objXMST_XCOMMENT01_01.XCOMMENT01_01 & " | " & objTSTS_EQ_CTRL.FEQ_STS & "→" & TO_STRING(intData10) & "]"
                End If
                '設備状況
                If InStr(objTSTS_EQ_CTRL.FEQ_NAME, "書") = 0 Then objTSTS_EQ_CTRL.FEQ_NAME &= "書" '設備名称
                objTSTS_EQ_CTRL.FEQ_STS = TO_STRING(intData10)  '設備状態
                objTSTS_EQ_CTRL.FUPDATE_DT = Now                '更新日時
                objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()           '更新
                intReturn = RetCode.OK
            Else
                '(値が変化なしの場合)
                'ｺﾒﾝﾄ
                'objXLOG_MELSEC.XCOMMENT03 &= "---"
            End If
        Else
            '(ﾚｺｰﾄﾞが存在しない場合)
            'ｺﾒﾝﾄ
            objXLOG_MELSEC.XCOMMENT03 &= "[" & objTSTS_EQ_CTRL.FEQ_ID_LOCAL & "|" & TO_STRING(intData10) & "(ﾚｺｰﾄﾞ追加)]"
            '設備状況
            objTSTS_EQ_CTRL.FEQ_KUBUN = 0       '設備区分
            objTSTS_EQ_CTRL.FEQ_NAME = "書"     '設備名称
            objTSTS_EQ_CTRL.FUPDATE_DT = Now    '更新日時
            objTSTS_EQ_CTRL.FENTRY_DT = Now     '登録日時
            objTSTS_EQ_CTRL.FEQ_STS = TO_STRING(intData10)  '設備状態
            objTSTS_EQ_CTRL.ADD_TSTS_EQ_CTRL()              '追加
            intReturn = RetCode.OK
        End If


        Return intReturn
    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
