﻿'画面ｿｹｯﾄ受付用
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

'    '電文分解用
'    Private Const DSPTERM_ID As Integer = 0         '端末ID
'    Private Const DSPUSER_ID As Integer = 1         'ﾕｰｻﾞｰID
'    Private Const DSPREASON As Integer = 2          '理由
'    Private Const  As Integer = 3         '
'    Private Const  As Integer = 4         '
'    Private Const  As Integer = 5         '
'    Private Const  As Integer = 6         '
'    Private Const  As Integer = 7         '
'    Private Const  As Integer = 8         '
'    Private Const  As Integer = 9         '
'    Private Const  As Integer = 10        '
'    Private Const  As Integer = 11        '
'    Private Const  As Integer = 12        '
'    Private Const  As Integer = 13        '
'    Private Const  As Integer = 14        '
'    Private Const  As Integer = 15        '
'    Private Const  As Integer = 16        '
'    Private Const  As Integer = 17        '
'    Private Const  As Integer = 18        '
'    Private Const  As Integer = 19        '
'    Private Const  As Integer = 20        '
'    Private Const  As Integer = 21        '
'    Private Const  As Integer = 22        '
'    Private Const  As Integer = 23        '
'    Private Const  As Integer = 24        '
'    Private Const  As Integer = 25        '
'    Private Const  As Integer = 26        '
'    Private Const  As Integer = 27        '
'    Private Const  As Integer = 28        '
'    Private Const  As Integer = 29        '
'    Private Const  As Integer = 30        '

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
'        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
'        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
'        Dim strDenbunDtl(0) As String         '電文分解配列
'        Dim strDenbunDtlName(0) As String     '電文分解名称配列
'        Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
'        Dim intRet As RetCode                 '戻り値
'        Dim strMsg As String                  'ﾒｯｾｰｼﾞ
'        Try


'            '************************
'            '初期処理
'            '************************
'            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
'            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
'            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
'            Call CheckBeforeAct(strDenbunDtl)




'            '************************
'            '正常完了
'            '************************
'            Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
'            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
'            Return RetCode.OK


'        Catch ex As UserException
'            Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ex.Message)
'            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
'            Call ComUser(ex, MeSyoriID)
'            Return RetCode.NG
'        Catch ex As Exception
'            Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ERRMSG_DISP_ERR)
'            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
'            Call ComError(ex, MeSyoriID)
'            Return RetCode.NG
'        End Try
'    End Function
'#End Region
'#Region "  事前ﾁｪｯｸ                                                                             "
'    '''**********************************************************************************************
'    ''' <summary>
'    ''' 事前ﾁｪｯｸ
'    ''' </summary>
'    ''' <param name="strDenbunDtl">電文内容構造体</param>
'    ''' <remarks></remarks>
'    '''**********************************************************************************************
'    Private Sub CheckBeforeAct(ByVal strDenbunDtl() As String)
'        Try
'            'Dim intRet As RetCode                   '戻り値
'            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


'            '************************
'            '値漏れﾁｪｯｸ
'            '************************
'            If 1 = 1 Then
'            ElseIf strDenbunDtl(DSPTERM_ID) = DEFAULT_STRING Then
'                strMsg = ERRMSG_DISP_SOCKET & "[端末ID]"
'                Throw New UserException(strMsg)
'            ElseIf strDenbunDtl(DSPUSER_ID) = DEFAULT_STRING Then
'                strMsg = ERRMSG_DISP_SOCKET & "[ﾕｰｻﾞｰID]"
'                Throw New UserException(strMsg)
'            End If


'        Catch ex As UserException
'            Call ComUser(ex, MeSyoriID)
'            Throw ex
'        Catch ex As Exception
'            Call ComError(ex, MeSyoriID)
'            Throw ex
'        End Try
'    End Sub
'#End Region

'    '**********************************************************************************************
'    '↓↓↓ｼｽﾃﾑ固有

'    '↑↑↑ｼｽﾃﾑ固有
'    '**********************************************************************************************

'End Class
