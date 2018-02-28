'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】日替検知
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_340001
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


            '************************************
            '初期設定
            '************************************
            Dim objPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)
            Dim dtmACTION_DATE As Date = Now        '動作日時



            If Format(dtmACTION_DATE, "HH:mm") = Format(objPRG_SYS_HEN.SJ000000_011, "HH:mm") And _
               Format(dtmACTION_DATE, "yyyy/MM/dd") <> Format(objPRG_SYS_HEN.SJ000000_012, "yyyy/MM/dd") Then
                '(ｼｽﾃﾑ時刻と締め時刻が一致する場合)(最終実行締め日付がｼｽﾃﾑ日付と一致しない場合)

                If intSIME_FLAG = FLAG_OFF Then
                    Try


                        '************************************
                        '出荷作業終了処理
                        '************************************
                        Dim objSVR_400107 As New SVR_400107(Owner, ObjDb, ObjDbLog) '日締め処理
                        intRet = objSVR_400107.ExecCmd("", "")                      '実行
                        If intRet = RetCode.NG Then
                            '(失敗した場合)
                            strMsg = ERRMSG_ERR_SVR_400107
                            Throw New System.Exception(strMsg)
                        End If


                        '************************************
                        '日締め処理
                        '************************************
                        Dim objSVR_340002 As New SVR_340002(Owner, ObjDb, ObjDbLog)     '日締め処理
                        objSVR_340002.dtmACTION_DATE = dtmACTION_DATE                   '動作日時
                        intRet = objSVR_340002.ExecCmd("", "")                          '実行
                        If intRet = RetCode.NG Then
                            '(失敗した場合)
                            strMsg = ERRMSG_ERR_SVR_340002
                            Throw New System.Exception(strMsg)
                        End If


                        '************************************
                        '最終実行締め時刻の更新
                        '************************************
                        objPRG_SYS_HEN.SJ000000_012 = dtmACTION_DATE         '変更ﾃﾞｰﾀ


                    Finally


                        '************************************
                        'ｺﾐｯﾄ
                        '************************************
                        ObjDb.Commit()


                        '************************************
                        'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                        '************************************
                        ObjDb.BeginTrans()


                        '************************************
                        '再起動ﾊﾞｯﾁ起動
                        '************************************
                        Try
                            Call Shell(objPRG_SYS_HEN.SJ000000_021, AppWinStyle.NormalFocus)
                        Catch ex As Exception
                            Call ComError(ex, MeSyoriID)
                        End Try


                    End Try
                End If


                '************************************
                '処理ﾌﾗｸﾞの更新
                '************************************
                intSIME_FLAG = FLAG_ON      '処理済


            Else
                '(ｼｽﾃﾑ時刻と締め時刻が一致しない場合)


                '************************************
                '処理ﾌﾗｸﾞの更新
                '************************************
                intSIME_FLAG = FLAG_OFF      '未処理


            End If


            '************************************
            '操業日の特定
            '************************************
            Dim dtmSougyo As Date
            If Format(dtmACTION_DATE, "HH:mm:ss") > Format(objPRG_SYS_HEN.SJ000000_011, "HH:mm:ss") Then
                dtmSougyo = Format(dtmACTION_DATE, "yyyy/MM/dd 00:00:00")
            Else
                dtmSougyo = Format(DateAdd(DateInterval.Day, -1, dtmACTION_DATE), "yyyy/MM/dd 00:00:00")
            End If


            '************************************
            '操業履歴の特定
            '************************************
            Dim objRST_SOUGYOU As New TBL_XRST_SOUGYOU(Owner, ObjDb, ObjDbLog)  '操業履歴ｸﾗｽ
            objRST_SOUGYOU.XSOUGYOU_DT = dtmSougyo                              '操業日
            intRet = objRST_SOUGYOU.GET_XRST_SOUGYOU(False)                     '特定
            If intRet = RetCode.NotFound Then


                '************************************
                '操業開始
                '************************************
                Dim objSVR_340003 As New SVR_340003(Owner, ObjDb, ObjDbLog)     '操業開始処理
                objSVR_340003.DTMACTION_DATE = dtmACTION_DATE                   '動作日時
                objSVR_340003.XSOUGYOU_DT = dtmSougyo                           '操業日
                intRet = objSVR_340003.ExecCmd("", "")                          '実行
                If intRet = RetCode.NG Then
                    '(失敗した場合)
                    strMsg = ERRMSG_ERR_SVR_340003
                    Throw New System.Exception(strMsg)
                End If


            End If


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
