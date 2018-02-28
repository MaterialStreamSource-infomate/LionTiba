'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出庫指示引当(ｸﾚｰﾝ毎)
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_390001
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


            '************************
            '初期処理
            '************************
            Dim dtmNow01 As Date = Now
            Dim intLoopCount01 As Integer = 0
            Dim intLoopCount02 As Integer = 0
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            '************************
            'ｸﾚｰﾝID配列     取得
            '************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)
            Dim strFEQ_ID() As String = Split(TO_STRING(objTPRG_SYS_HEN.SS000000_022), ",")


            '************************
            'ｸﾚｰﾝ優先順の更新
            '************************
            Dim objSVR_100205 As New SVR_100205(Owner, ObjDb, ObjDbLog)     'ｸﾚｰﾝ優先順更新ｸﾗｽ
            objSVR_100205.FTRK_BUF_NO = FTRK_BUF_NO_J9000                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            objSVR_100205.FEQ_ID = strFEQ_ID(0)                             '使用設備ID
            objSVR_100205.FHENSU_ID = objTPRG_SYS_HEN.FHENSU_ID             '変数ID
            objSVR_100205.CRANE_ORDER_UPDATE()                              '更新
            

            '************************************************************************************************************************************************************************
            '************************************************************************************************************************************************************************
            'ｸﾚｰﾝﾏｽﾀ        取得
            'ｸﾚｰﾝ毎にﾙｰﾌﾟ(1次)
            '************************************************************************************************************************************************************************
            '************************************************************************************************************************************************************************
            Dim objAryTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)
            objAryTMST_CRANE.FEQ_ID = strFEQ_ID(0)                  '設備ID
            intRet = objAryTMST_CRANE.GET_TMST_CRANE_ANY()          '取得
            If intRet = RetCode.OK Then
                For Each objTMST_CRANE As TBL_TMST_CRANE In objAryTMST_CRANE.ARYME
                    '(ﾙｰﾌﾟ:ｸﾚｰﾝ数)


                    '************************************************
                    '出庫指示引当処理
                    '************************************************
                    intRet = SVR_010002_Process01(objTMST_CRANE _
                                                , intLoopCount01 _
                                                , intLoopCount02 _
                                                , False _
                                                )


                Next


            End If


            '************************
            '正常完了
            '************************
            Dim objDiff As TimeSpan = Now - dtmNow01
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                             FLOG_DATA_TRN_SEND_NORMAL _
                             & "[処理時間:" & TO_STRING(TO_DECIMAL(objDiff.TotalMilliseconds / 1000)) & "]" _
                             & "[ﾙｰﾌﾟ回数01:" & TO_STRING(intLoopCount01) & "]" _
                             & "[ﾙｰﾌﾟ回数02:" & TO_STRING(intLoopCount02) & "]" _
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

