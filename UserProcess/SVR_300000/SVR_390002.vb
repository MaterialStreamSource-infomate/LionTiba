'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】画面ｲﾝﾀｰﾌｪｰｽ一時保管監視処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_390002
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
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '************************
            '初期処理01
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            '************************
            '初期処理02
            '************************
            Dim dtmNow01 As Date = Now
            Dim intLoopCount01 As Integer = 0
            'Dim intLoopCount02 As Integer = 0
            Dim objDiff As TimeSpan
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)


            '************************
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ取得
            '************************
            Dim objXPRG_PARAM_TBL01 As New TBL_XPRG_PARAM_TBL01(Owner, ObjDb, ObjDbLog)
            objXPRG_PARAM_TBL01.ORDER_BY = "   FENTRY_DT, FPARA_EDA_NO "
            intRet = objXPRG_PARAM_TBL01.GET_XPRG_PARAM_TBL01_ANY()
            If intRet = RetCode.OK Then
                For ii As Integer = LBound(objXPRG_PARAM_TBL01.ARYME) To UBound(objXPRG_PARAM_TBL01.ARYME)
                    '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


                    '************************************************
                    'ﾙｰﾌﾟ脱出判定
                    '************************************************
                    objDiff = Now - dtmNow01
                    If objTPRG_SYS_HEN.SJ390002_001 < objDiff.TotalMilliseconds Then
                        Continue For
                    End If


                    Dim msgRecv As String = ""
                    Dim msgSend As String = ""
                    Try
                        Dim rtn As Integer = RetCode.OK
                        Dim rtn2 As Integer = RetCode.OK


                        '************************
                        'ﾒｯｾｰｼﾞ設定
                        '************************
                        objTelegramRecvDSP.FORMAT_ID = "DSP_000000"                 'ﾌｫｰﾏｯﾄ名ｾｯﾄ
                        objTelegramRecvDSP.TELEGRAM_PARTITION = objXPRG_PARAM_TBL01.ARYME(ii).FSEND_DATA      '分割する電文ｾｯﾄ
                        objTelegramRecvDSP.PARTITION()                              '電文分割


                        '************************
                        'ｺﾏﾝﾄﾞIDの特定
                        '************************
                        Dim strCMD_ID As String
                        strCMD_ID = objTelegramRecvDSP.SELECT_HEADER("DSPCMD_ID")
                        strCMD_ID = Trim(strCMD_ID)


                        '************************
                        'ｺﾏﾝﾄﾞ処理
                        '************************
                        msgRecv = objXPRG_PARAM_TBL01.ARYME(ii).FSEND_DATA
                        msgSend = objXPRG_PARAM_TBL01.ARYME(ii).FRECV_DATA
                        Select Case strCMD_ID
                            Case FSYORI_ID_J400001
                                'AddToLog("■受付:入庫設定", "", LogType.INFO)
                                Dim objCmd As New SVR_400001(Owner, ObjDb, ObjDbLog)
                                rtn = objCmd.ExecCmd02(msgRecv, msgSend)

                            Case FSYORI_ID_J400502
                                'AddToLog("■受付:倉替え入庫", "", LogType.INFO)
                                Dim objCmd As New SVR_400502(Owner, ObjDb, ObjDbLog)
                                rtn = objCmd.ExecCmd02(msgRecv, msgSend)

                            Case Else

                        End Select


                        '************************
                        'ｴﾗｰﾁｪｯｸ
                        '************************
                        If rtn = RetCode.NG Or rtn2 = RetCode.NG Then
                            '(異常終了の場合)
                            strMsg = ERRMSG_DISP_PARAM
                            Throw New UserException(strMsg)
                        End If


                        intLoopCount01 += 1
                    Catch ex As UserException
                        Call ComUser(ex, MeSyoriID)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                        ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                        ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始

                    Catch ex As Exception
                        Call ComError(ex, MeSyoriID)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                        ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                        ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    Finally
                        objXPRG_PARAM_TBL01.ARYME(ii).DELETE_XPRG_PARAM_TBL01()     '削除
                        ObjDb.Commit()      'ｺﾐｯﾄ
                        ObjDb.BeginTrans()  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    End Try


                Next
            End If
            objXPRG_PARAM_TBL01.ARYME_CLEAR()


            '************************
            '正常完了
            '************************
            objDiff = Now - dtmNow01
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                             FLOG_DATA_TRN_SEND_NORMAL _
                             & "[処理時間:" & TO_STRING(TO_DECIMAL(objDiff.TotalMilliseconds / 1000)) & "]" _
                             & "[ﾙｰﾌﾟ回数01:" & TO_STRING(intLoopCount01) & "]" _
                             )


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
