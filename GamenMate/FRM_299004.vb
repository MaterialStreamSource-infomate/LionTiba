'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｿｹｯﾄ受信ﾂｰﾙ
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                                  "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_299004

#Region "  共通変数"

    '共通ｵﾌﾞｼﾞｪｸﾄ
    Private mobjOwner As clsOwner_FRM_299004              'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Private mobjSocketListener As clsSocketListener       'ｿｹｯﾄﾘｽﾅｰ     ｵﾌﾞｼﾞｪｸﾄ
    Private mobjSocketClient As clsSocketClient           'ｿｹｯﾄｸﾗｲｱﾝﾄ   ｵﾌﾞｼﾞｪｸﾄ
    Private mobjLogWrite As clsWriteLog             'ﾛｸﾞ出力ｸﾗｽ

    Private mintListCount As Integer                'ﾘｽﾄﾎﾞｯｸｽに表示する最大行数

    '定数
    Private Const MESSAGE_001 As String = "【ﾘｽﾅｰ受信     】"
    Private Const MESSAGE_002 As String = "【ﾘｽﾅｰ送信     】"
    Private Const MESSAGE_003 As String = "【ﾘｽﾅｰ待機開始 】"
    Private Const MESSAGE_004 As String = "【ﾘｽﾅｰ待機終了 】"
    Private Const MESSAGE_051 As String = "【ｸﾗｲｱﾝﾄ受信   】"
    Private Const MESSAGE_052 As String = "【ｸﾗｲｱﾝﾄ送信   】"
    Private Const MESSAGE_053 As String = "【ｸﾗｲｱﾝﾄ接続   】"
    Private Const MESSAGE_054 As String = "【ｸﾗｲｱﾝﾄ切断   】"

#End Region

#Region "  ﾌｫｰﾑﾛｰﾄﾞ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmSockTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            '****************************************************
            '色々初期化
            '****************************************************
            mintListCount = 100


            '*****************************************************
            'ﾛｸﾞ出力ｵﾌﾞｼﾞｪｸﾄ生成
            '*****************************************************
            mobjLogWrite = New clsWriteLog
            mobjLogWrite.clspFileName = "logForm.log"       'ﾌｧｲﾙ名         ｾｯﾄ
            mobjLogWrite.clspCopyFile = "logForm_old.log"   'ﾌｧｲﾙ名(古い)   ｾｯﾄ
            mobjLogWrite.clspMaxSize = 500000               '最大ﾌｧｲﾙｻｲｽﾞ   ｾｯﾄ


            '****************************************************
            'ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ       作成
            '****************************************************
            mobjOwner = New clsOwner_FRM_299004
            mobjOwner.objOwnerForm = Me

            mobjSocketListener = New clsSocketListener(mobjOwner)
            mobjSocketClient = New clsSocketClient(mobjOwner)


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region


    '**********************************
    'ﾘｽﾅｰ
    '**********************************

#Region "  ﾘｽﾅｰ受信開始ﾎﾞﾀﾝ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾅｰ受信開始ﾎﾞﾀﾝ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdListenerListen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListenerListen.Click
        Try

            '****************************************************
            'ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ   ｾｯﾄ
            '****************************************************
            mobjSocketListener.intPortNo = txtListenerPortNo.Text       'ﾎﾟｰﾄNo
            mobjSocketListener.Listen()                                 '待機
            AddToLog(MESSAGE_003 & mobjSocketListener.strRecvText)


            '****************************************************
            'ﾀｲﾏｰｾｯﾄ
            '****************************************************
            tmrListenTimer.Interval = txtListenerInterval.Text
            tmrListenTimer.Enabled = True


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾘｽﾅｰ受信終了ﾎﾞﾀﾝ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾅｰ受信終了ﾎﾞﾀﾝ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdListenerShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListenerShutdown.Click
        Try

            tmrListenTimer.Enabled = False
            mobjSocketListener.Shutdown()
            AddToLog(MESSAGE_004 & mobjSocketListener.strRecvText)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾘｽﾅｰ送信"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾅｰ送信
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdListenerSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListenerSend.Click
        Try

            mobjSocketListener.strSendText = txtListenerSendText.Text
            mobjSocketListener.Send()
            AddToLog(MESSAGE_002 & mobjSocketListener.strSendText)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾘｽﾅｰ送信(Chr)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾅｰ送信(Chr)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdListenerSendChr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListenerSendChr.Click
        Try
            Dim strSendText As String       '送信電文
            Dim strChrNum() As String       '送信電文のchr配列
            strSendText = ""
            strChrNum = Split(txtListenerSendChr.Text, ",")
            For ii As Integer = LBound(strChrNum) To UBound(strChrNum)
                '(ﾙｰﾌﾟ:配列数)
                If IsNumeric(strChrNum(ii)) = False Then Throw New Exception("テキストボックスには、カンマ区切りで0～255の数値を設定して下さい。")
                If CInt(strChrNum(ii)) < 0 Or 255 < CInt(strChrNum(ii)) Then Throw New Exception("テキストボックスには、カンマ区切りで0～255の数値を設定して下さい。")
                strSendText &= Chr(CInt(strChrNum(ii)))
            Next


            '****************************************************
            'ｿｹｯﾄｵﾌﾞｼﾞｪｸﾄ   ｾｯﾄ
            '****************************************************
            mobjSocketListener.strSendText = strSendText
            mobjSocketListener.Send()
            AddToLog(MESSAGE_002 & mobjSocketListener.strSendText)


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾘｽﾅｰ受信ﾀｲﾏｰ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾅｰ受信ﾀｲﾏｰ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrListenTimer.Tick
        Try
            tmrListenTimer.Enabled = False


            mobjSocketListener.Receive()
            If mobjSocketListener.strRecvText <> "" Then
                '(受信ﾃｷｽﾄが存在していた場合)

                Dim strDispText As String = ""      '受信電文表示文字列
                If rdoListenerASCII.Checked = True Then
                    '(制御文字表示の場合)
                    Dim objASCII As New clsASCII
                    strDispText = objASCII.GetLogString(mobjSocketListener.strRecvText)
                Else
                    '(ﾉｰﾏﾙの場合)
                    strDispText = mobjSocketListener.strRecvText
                End If
                AddToLog(MESSAGE_001 & strDispText)
                txtListenerRecvText.Text = strDispText

                '画面ｿｹｯﾄ電文を分解して表示 & 正常応答電文送信
                Call DenbunBunkai(strDispText)

            End If


            tmrListenTimer.Enabled = True
        Catch ex As Exception
            ComError(ex)
            tmrListenTimer.Enabled = False


        End Try
    End Sub
#End Region
#Region "  画面ｿｹｯﾄ電文を分解して表示 & 正常応答電文送信"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面ｿｹｯﾄ電文を分解して表示＆正常応答電文送信
    ''' </summary>
    ''' <param name="strDispText"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub DenbunBunkai(ByVal strDispText As String)
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文


        '************************
        'ﾒｯｾｰｼﾞ設定
        '************************
        objTelegramRecv.FORMAT_ID = "DSP_000000"                 'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        objTelegramRecv.TELEGRAM_PARTITION = strDispText         '分割する電文ｾｯﾄ
        objTelegramRecv.PARTITION()                              '電文分割

        objTelegramRecv.FORMAT_ID = "DSP_" & objTelegramRecv.SELECT_HEADER("DSPCMD_ID")      'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        objTelegramRecv.PARTITION()                                                 '電文分割


        '************************
        '電文分解
        '************************
        Dim strDenbunDtl(0) As String          '電文分解配列
        Dim strDenbunDtlName(0) As String      '電文分解名称配列
        Dim objTemplateServer As New clsTemplateServer(gobjOwner, gobjDb, Nothing)       '品名ﾏｽﾀ
        objTemplateServer.AnalysisDenbun(strDenbunDtl _
                                       , strDenbunDtlName _
                                       , objTelegramRecv _
                                         )

        For ii As Integer = 0 To strDenbunDtl.Length - 1
            '(ﾙｰﾌﾟ:電文分解結果の配列数)
            txtListenerRecvText.Text &= vbCrLf
            txtListenerRecvText.Text &= SPC_PAD_LEFT_SJIS("【" & strDenbunDtlName(ii) & "】", 30)
            txtListenerRecvText.Text &= strDenbunDtl(ii)
        Next



        If rdoReturnOK.Checked = True Then
            '(正常応答の場合)


            '************************
            '正常応答電文送信
            '************************
            Dim strMSG_SEND As String = ""      '応答電文
            objTemplateServer.MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
            txtListenerSendText.Text = strMSG_SEND
            Call cmdListenerSend_Click(Nothing, Nothing)


        ElseIf rdoReturnNG.Checked = True Then
            '(NG応答の場合)


            '************************
            '異常応答電文送信
            '************************
            Dim strMSG_SEND As String = ""      '応答電文
            objTemplateServer.MakeMessageGamenNG(objTelegramSend, strMSG_SEND, txtMessage.Text)
            txtListenerSendText.Text = strMSG_SEND
            Call cmdListenerSend_Click(Nothing, Nothing)


        ElseIf rdoReturnMessage.Checked = True Then
            '(ﾒｯｾｰｼﾞ応答の場合)


            '************************
            'ﾒｯｾｰｼﾞ応答電文送信
            '************************
            Dim strMSG_SEND As String = ""      '応答電文
            objTemplateServer.MakeMessageGamenMessage(objTelegramSend, strMSG_SEND, txtMessage.Text)
            txtListenerSendText.Text = strMSG_SEND
            Call cmdListenerSend_Click(Nothing, Nothing)


        Else
            '(その他の場合)


            '************************
            '正常応答電文送信
            '************************
            Dim strMSG_SEND As String = ""      '応答電文
            objTemplateServer.MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
            txtListenerSendText.Text = strMSG_SEND
            Call cmdListenerSend_Click(Nothing, Nothing)


        End If


    End Sub
#End Region



#Region "  画面ｴﾗｰ処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面ｴﾗｰ処理
    ''' </summary>
    ''' <param name="ex">ｴﾗｰException</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ComError(ByVal ex As Exception)
        Try

            '*****************************************************
            'ﾃｷｽﾄ生成
            '*****************************************************
            Dim strTemp As String
            Dim strStackTrace(0) As String
            strTemp = Replace(ex.StackTrace, ",", "，")       '半角ｶﾝﾏを全角ｶﾝﾏに変換
            strStackTrace = Split(strTemp, vbCrLf)

            '*****************************************************
            ' ﾛｸﾞ書込み
            '*****************************************************
            For ii As Integer = LBound(strStackTrace) To UBound(strStackTrace)
                AddToLog(ex.Message, _
                         AddToLog_D_ErrorType.PROGRAM_ERROR, _
                         strStackTrace(ii))
            Next


        Catch ex2 As Exception
            Throw New Exception(ex2.Message)

        End Try
    End Sub
#End Region
#Region "  ﾛｸﾞ書込処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込処理
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <param name="udtErrorType"></param>
    ''' <param name="strMsg_3"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String, _
                        Optional ByVal udtErrorType As AddToLog_D_ErrorType = AddToLog_D_ErrorType.USER_LOG, _
                        Optional ByVal strMsg_3 As String = "")
        Try

            '*****************************************************
            'ﾌｧｲﾙﾛｸﾞ出力
            '*****************************************************
            Dim strMsg_2 As String = ""
            Select Case udtErrorType
                Case AddToLog_D_ErrorType.PROGRAM_ERROR
                    strMsg_2 = FRM_ERR_COMERROR_TITLE
                Case AddToLog_D_ErrorType.USER_ERROR
                    strMsg_2 = FRM_ERR_USERERRO_TITLE
                Case AddToLog_D_ErrorType.USER_LOG
                    strMsg_2 = FRM_ERR_USERLOG_TITLE
            End Select
            mobjLogWrite.WriteLog(strMsg_1, strMsg_2, strMsg_3)              'ﾛｸﾞ書込


            '*****************************************************
            'ﾘｽﾄ出力
            '*****************************************************
            '==============================================
            '定義された行数までﾘｽﾄﾎﾞｯｸｽの行を削除
            '==============================================
            While lstLog.Items.Count >= mintListCount
                lstLog.Items.RemoveAt(lstLog.Items.Count - 1)
            End While

            '==============================================
            'ﾘｽﾄ追加
            '==============================================
            Dim strMessage As String = Format(Now, DATE_FORMAT_99) & Space(5) & strMsg_2 & strMsg_1 & Space(5) & strMsg_3
            If InStr(strMessage, "現在のﾊﾞｯﾌｧ") = 0 Then
                lstLog.Items.Insert(0, strMessage)
            End If


        Catch ex2 As Exception
            Throw New Exception(ex2.Message)

        End Try
    End Sub
#End Region


End Class