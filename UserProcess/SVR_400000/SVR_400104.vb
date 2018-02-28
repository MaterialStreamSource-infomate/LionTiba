'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】優先設定受付
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_400104
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0                 '端末ID
    Private Const DSPUSER_ID As Integer = 1                 'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2                  '理由
    Private Const XDSPSYUKKA_D As Integer = 3               '出荷日
    Private Const XDSPHENSEI_NO_OYA As Integer = 4          '親編成№

#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner"></param>
    ''' <param name="objDb"></param>
    ''' <param name="objDbLog"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  ﾒｲﾝ処理                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
        Dim strDenbunDtl(0) As String         '電文分解配列
        Dim strDenbunDtlName(0) As String     '電文分解名称配列
        Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        Dim intRet As Integer                 '戻り値
        Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        Dim strSQL As String                    'SQL文
        Try


            '************************
            '初期処理
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call CheckBeforeAct(strDenbunDtl)

            '-------------------    
            '緊急度読込
            '-------------------
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            Dim intKINKYU_LEVEL As Integer = 0
            Dim objPLN_OUT_ARY As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    MAX(XKINKYU_LEVEL) + 1 AS XKINKYU_LEVEL"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XPLN_OUT"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "    XSYUKKA_STS <= " & XSYUKKA_STS_JDIR                 '出荷状況
            strSQL &= vbCrLf
            objPLN_OUT_ARY.USER_SQL = strSQL
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "XPLN_OUT"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                intKINKYU_LEVEL = TO_INTEGER(objDataSet.Tables(strDataSetName).Rows(0).Item("XKINKYU_LEVEL"))
            End If
            If intKINKYU_LEVEL = 0 Then
                intKINKYU_LEVEL = 1
            End If


            '-----------------------
            '更新SQL作成
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & "UPDATE"
            strSQL &= vbCrLf & "    XPLN_OUT"
            strSQL &= vbCrLf & " SET"
            strSQL &= vbCrLf & "    XKINKYU_KBN = " & TO_STRING(XKINKYU_KBN_JON)            '緊急出荷区分
            strSQL &= vbCrLf & "   ,XKINKYU_LEVEL = " & TO_STRING(intKINKYU_LEVEL)          '緊急度
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "    XSYUKKA_D = TO_DATE('" & Format(TO_DATE(strDenbunDtl(XDSPSYUKKA_D)), "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS')"                       '出荷日
            strSQL &= vbCrLf & " AND"
            strSQL &= vbCrLf & "    XHENSEI_NO_OYA = '" & strDenbunDtl(XDSPHENSEI_NO_OYA) & "'"     '親編成No
            strSQL &= vbCrLf
            intRet = ObjDb.Execute(strSQL)
            If intRet = -1 Then
                '(SQLｴﾗｰ)
                strMsg = ERRMSG_ERR_UPDATE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL, vbCrLf, "") & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '正常完了
            '************************
            Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
            Return RetCode.OK


        Catch ex As UserException
            Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ex.Message)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
            Call ComUser(ex, MeSyoriID)
            Return RetCode.NG
        Catch ex As Exception
            Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ERRMSG_DISP_ERR)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
            Call ComError(ex, MeSyoriID)
            Return RetCode.NG
        End Try
    End Function

#End Region
#Region "  事前ﾁｪｯｸ                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 事前ﾁｪｯｸ
    ''' </summary>
    ''' <param name="strDenbunDtl">電文内容構造体</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub CheckBeforeAct(ByVal strDenbunDtl() As String)
        Try
            'Dim intRet As Integer                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '************************
            '値漏れﾁｪｯｸ
            '************************
            If strDenbunDtl(DSPTERM_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[端末ID]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPUSER_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[ﾕｰｻﾞｰID]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(XDSPSYUKKA_D) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[出荷日]"
                Throw New System.Exception(strMsg)
            ElseIf strDenbunDtl(XDSPHENSEI_NO_OYA) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[親編成№]"
                Throw New System.Exception(strMsg)
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
