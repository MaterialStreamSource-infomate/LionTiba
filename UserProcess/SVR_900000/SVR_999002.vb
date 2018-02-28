'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】MCIｲﾍﾞﾝﾄ通知ﾏｽﾀ作成←ﾃｰﾌﾞﾙ自体がなくなったので、不要な機能となった
'         ﾚｺｰﾄﾞが存在しなかったら、ﾚｺｰﾄﾞを追加。
'         ﾚｺｰﾄﾞが存在していたら、ﾛｰｶﾙ設備IDを更新。
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_999002
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


            ''************************************************
            ''設備状況               取得
            ''************************************************
            'Dim strSQL As String = ""
            'Dim objAryTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            'strSQL &= " SELECT "
            'strSQL &= "    * "
            'strSQL &= " FROM "
            'strSQL &= "    TSTS_EQ_CTRL "
            'strSQL &= " WHERE "
            'strSQL &= "    SUBSTR(FEQ_ID, 1, 5) =  'JOTHY' OR SUBSTR(FEQ_ID, 1, 5) =  'JOTHM'"
            'objAryTSTS_EQ_CTRL.USER_SQL = strSQL
            'intRet = objAryTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL_USER()
            'If intRet = RetCode.OK Then
            '    '(見つかった場合)
            '    For Each objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL In objAryTSTS_EQ_CTRL.ARYME
            '        '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


            '        '************************************************
            '        '設備状況               取得
            '        '************************************************
            '        Dim objXMCI_MST_EVENT As New TBL_XMCI_MST_EVENT(Owner, ObjDb, ObjDbLog)
            '        objXMCI_MST_EVENT.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                   '設備ID
            '        intRet = objXMCI_MST_EVENT.GET_XMCI_MST_EVENT(False)                '取得
            '        If intRet = RetCode.OK Then
            '            '(見つかった場合)
            '            objXMCI_MST_EVENT.FEQ_ID_LOCAL = objTSTS_EQ_CTRL.FEQ_ID_LOCAL   'ﾛｰｶﾙ設備ID
            '            objXMCI_MST_EVENT.UPDATE_XMCI_MST_EVENT()                       '更新
            '        Else
            '            '(見つからなかった場合)
            '            objXMCI_MST_EVENT.FEQ_ID_LOCAL = objTSTS_EQ_CTRL.FEQ_ID_LOCAL   'ﾛｰｶﾙ設備ID
            '            objXMCI_MST_EVENT.FYUKOU_FLAG = FLAG_ON                         'ﾛｰｶﾙ設備ID
            '            objXMCI_MST_EVENT.ADD_XMCI_MST_EVENT()                          '更新
            '        End If


            '    Next
            'End If


            ''************************
            ''正常完了
            ''************************
            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
            '                 FLOG_DATA_TRN_SEND_NORMAL _
            '                 )


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
