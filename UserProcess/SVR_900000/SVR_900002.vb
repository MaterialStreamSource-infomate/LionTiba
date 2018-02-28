'ｻｰﾊﾞﾌﾟﾛｾｽ用
''**********************************************************************************************
'' Copyright(C) Kanazawa System House Corporation 
'' All Rights Reserved
''
'' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
'' 【機能】$$$$$$$$$$$$$$$$$$$$$$$$
'' 【作成】$$$$$$$$$$$$$$$$$$$$$$$$
''**********************************************************************************************

'#Region "  Imports                                                                              "
'Imports JobCommon
'Imports MateCommon                          'MateCommon使用の為
'Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
'#End Region

'Public Class SVR_$$$$$$
'    Inherits clsTemplateServer

'#Region "  ｸﾗｽ内部処理用定数定義                                                                "
'#End Region
'#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
'    '''**********************************************************************************************
'    ''' <summary>
'    ''' ｺﾝｽﾄﾗｸﾀ
'    ''' </summary>
'    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
'    ''' <param name="objDb">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ</param>
'    ''' <param name="objDbLog">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ用)</param>
'    ''' <remarks></remarks>
'    '''**********************************************************************************************
'    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
'        MyBase.new(objOwner, objDb, objDbLog)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
'    End Sub
'#End Region
'#Region "  ﾒｲﾝ処理                                                                              "
'    '''**********************************************************************************************
'    ''' <summary>
'    ''' ﾒｲﾝ処理
'    ''' </summary>
'    ''' <param name="strMSG_RECV">受信電文</param>
'    ''' <param name="strMSG_SEND">送信電文</param>
'    ''' <returns>OK/NG</returns>
'    ''' <remarks></remarks>
'    '''**********************************************************************************************
'    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
'        Dim intRet As RetCode                   '戻り値
'        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
'        Try




'            '************************
'            '正常完了
'            '************************
'            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
'                             FLOG_DATA_TRN_SEND_NORMAL _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             & "[ｱｲﾃﾑ名:" &                 & "]" _
'                             )


'            Return RetCode.OK
'        Catch ex As UserException
'            Call ComUser(ex, MeSyoriID)
'            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
'            Return RetCode.NG
'        Catch ex As Exception
'            Call ComError(ex, MeSyoriID)
'            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
'            Return RetCode.NG
'        End Try
'    End Function
'#End Region

'    '**********************************************************************************************
'    '↓↓↓ｼｽﾃﾑ固有

'    '↑↑↑ｼｽﾃﾑ固有
'    '**********************************************************************************************

'End Class
