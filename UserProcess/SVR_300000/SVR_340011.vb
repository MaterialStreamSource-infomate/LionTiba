'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】異常ﾋﾞｯﾄ更新処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_340011
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
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '*************************************************
            '初期設定
            '*************************************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)
            Dim strAryFMSG_ID_SJ000000_041() As String = Split(objTPRG_SYS_HEN.SJ000000_041, ",")   '引当異常ﾗﾝﾌﾟ
            Dim strAryFMSG_ID_SJ000000_042() As String = Split(objTPRG_SYS_HEN.SJ000000_042, ",")   '交信異常ﾗﾝﾌﾟ
            Dim strAryFMSG_ID_SJ000000_043() As String = Split(objTPRG_SYS_HEN.SJ000000_043, ",")   '情報異常ﾗﾝﾌﾟ


            For ii As Integer = 0 To 2
                '(ﾙｰﾌﾟ:異常ﾗﾝﾌﾟ数)


                '*************************************************
                'ﾒｯｾｰｼﾞID配列           設定
                '*************************************************
                Dim strAryFMSG_ID() As String = Nothing     'ﾒｯｾｰｼﾞID配列
                Dim strAdrs As String = ""                  '異常ﾋﾞｯﾄｱﾄﾞﾚｽ
                Select Case ii
                    Case 0 : strAryFMSG_ID = strAryFMSG_ID_SJ000000_041 : strAdrs = FEQ_ID_JOTHMFF_D000104_13   '引当異常ﾗﾝﾌﾟ
                    Case 1 : strAryFMSG_ID = strAryFMSG_ID_SJ000000_042 : strAdrs = FEQ_ID_JOTHMFF_D000104_14   '交信異常ﾗﾝﾌﾟ
                    Case 2 : strAryFMSG_ID = strAryFMSG_ID_SJ000000_043 : strAdrs = FEQ_ID_JOTHMFF_D000104_15   '情報異常ﾗﾝﾌﾟ
                End Select


                '*************************************************
                'Where句作成
                '*************************************************
                Dim strWhere As String = ""
                For jj As Integer = 0 To UBound(strAryFMSG_ID)
                    '(ﾙｰﾌﾟ:定義されたﾒｯｾｰｼﾞID数)
                    If jj = 0 Then
                        strWhere &= "'" & strAryFMSG_ID(jj) & "'"
                    Else
                        strWhere &= ", '" & strAryFMSG_ID(jj) & "'"
                    End If
                Next


                '****************************************
                '出荷指示詳細               取得
                '****************************************
                Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                objTSTS_EQ_CTRL.FEQ_ID = strAdrs        '設備ID
                objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()      '取得


                '*************************************************
                'SQL文作成
                '*************************************************
                Dim intCount As Integer = 0     '未確認ﾒｯｾｰｼﾞの件数
                Dim strSQL As String = ""
                strSQL &= vbCrLf & " SELECT "
                strSQL &= vbCrLf & "    COUNT(*) "
                strSQL &= vbCrLf & " FROM "
                strSQL &= vbCrLf & "    TLOG_MESSAGE "
                strSQL &= vbCrLf & " WHERE 1 = 1 "
                strSQL &= vbCrLf & "    AND FLOG_CHECK_FLAG = " & FLAG_OFF
                strSQL &= vbCrLf & "    AND FMSG_ID IN ( " & strWhere & " )"
                strSQL &= vbCrLf
                '抽出
                Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
                Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
                'Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
                ObjDb.SQL = strSQL
                objDataSet.Clear()
                strDataSetName = "TLOG_MESSAGE"
                ObjDb.GetDataSet(strDataSetName, objDataSet)
                intCount = TO_INTEGER(objDataSet.Tables(strDataSetName).Rows(0)(0))
                If 0 < intCount Then
                    '(未確認のﾒｯｾｰｼﾞが存在した場合)
                    If objTSTS_EQ_CTRL.FEQ_STS = FLAG_OFF Then
                        '(ﾋﾞｯﾄOFFの場合)


                        '*************************************************
                        '安川 Melsec  PLCﾒﾝﾃﾅﾝｽ(ﾋﾞｯﾄ)
                        '*************************************************
                        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(strAdrs, FTEXT_ID_JW_ETC, FLAG_ON)


                    End If
                Else
                    '(未確認のﾒｯｾｰｼﾞが存在しない場合)
                    If objTSTS_EQ_CTRL.FEQ_STS = FLAG_ON Then
                        '(ﾋﾞｯﾄONの場合)


                        '*************************************************
                        '安川 Melsec  PLCﾒﾝﾃﾅﾝｽ(ﾋﾞｯﾄ)
                        '*************************************************
                        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(strAdrs, FTEXT_ID_JW_ETC, FLAG_OFF)


                    End If
                End If


            Next


            ''************************
            ''正常完了
            ''************************
            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
            '                 FLOG_DATA_TRN_SEND_NORMAL _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
            '                 )



            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/14 搬送完了しないトラッキングのチェック
            Call CheckConveyanceTime()
            'JobMate:S.Ouchi 2013/11/14 搬送完了しないトラッキングのチェック
            '↑↑↑↑↑↑************************************************************************************************************



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
