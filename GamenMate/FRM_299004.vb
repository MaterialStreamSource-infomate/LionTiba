'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z���Ď�M°�
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports                                  "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_299004

#Region "  ���ʕϐ�"

    '���ʵ�޼ު��
    Private mobjOwner As clsOwner_FRM_299004              '��Ű��޼ު��
    Private mobjSocketListener As clsSocketListener       '����ؽŰ     ��޼ު��
    Private mobjSocketClient As clsSocketClient           '���ĸײ���   ��޼ު��
    Private mobjLogWrite As clsWriteLog             '۸ޏo�͸׽

    Private mintListCount As Integer                'ؽ��ޯ���ɕ\������ő�s��

    '�萔
    Private Const MESSAGE_001 As String = "�yؽŰ��M     �z"
    Private Const MESSAGE_002 As String = "�yؽŰ���M     �z"
    Private Const MESSAGE_003 As String = "�yؽŰ�ҋ@�J�n �z"
    Private Const MESSAGE_004 As String = "�yؽŰ�ҋ@�I�� �z"
    Private Const MESSAGE_051 As String = "�y�ײ��Ď�M   �z"
    Private Const MESSAGE_052 As String = "�y�ײ��đ��M   �z"
    Private Const MESSAGE_053 As String = "�y�ײ��Đڑ�   �z"
    Private Const MESSAGE_054 As String = "�y�ײ��Đؒf   �z"

#End Region

#Region "  ̫��۰��"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmSockTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            '****************************************************
            '�F�X������
            '****************************************************
            mintListCount = 100


            '*****************************************************
            '۸ޏo�͵�޼ު�Đ���
            '*****************************************************
            mobjLogWrite = New clsWriteLog
            mobjLogWrite.clspFileName = "logForm.log"       '̧�ٖ�         ���
            mobjLogWrite.clspCopyFile = "logForm_old.log"   '̧�ٖ�(�Â�)   ���
            mobjLogWrite.clspMaxSize = 500000               '�ő�̧�ٻ���   ���


            '****************************************************
            '���ĵ�޼ު��       �쐬
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
    'ؽŰ
    '**********************************

#Region "  ؽŰ��M�J�n����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ؽŰ��M�J�n����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdListenerListen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListenerListen.Click
        Try

            '****************************************************
            '���ĵ�޼ު��   ���
            '****************************************************
            mobjSocketListener.intPortNo = txtListenerPortNo.Text       '�߰�No
            mobjSocketListener.Listen()                                 '�ҋ@
            AddToLog(MESSAGE_003 & mobjSocketListener.strRecvText)


            '****************************************************
            '��ϰ���
            '****************************************************
            tmrListenTimer.Interval = txtListenerInterval.Text
            tmrListenTimer.Enabled = True


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ؽŰ��M�I������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ؽŰ��M�I������
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
#Region "  ؽŰ���M"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ؽŰ���M
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
#Region "  ؽŰ���M(Chr)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ؽŰ���M(Chr)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdListenerSendChr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListenerSendChr.Click
        Try
            Dim strSendText As String       '���M�d��
            Dim strChrNum() As String       '���M�d����chr�z��
            strSendText = ""
            strChrNum = Split(txtListenerSendChr.Text, ",")
            For ii As Integer = LBound(strChrNum) To UBound(strChrNum)
                '(ٰ��:�z��)
                If IsNumeric(strChrNum(ii)) = False Then Throw New Exception("�e�L�X�g�{�b�N�X�ɂ́A�J���}��؂��0�`255�̐��l��ݒ肵�ĉ������B")
                If CInt(strChrNum(ii)) < 0 Or 255 < CInt(strChrNum(ii)) Then Throw New Exception("�e�L�X�g�{�b�N�X�ɂ́A�J���}��؂��0�`255�̐��l��ݒ肵�ĉ������B")
                strSendText &= Chr(CInt(strChrNum(ii)))
            Next


            '****************************************************
            '���ĵ�޼ު��   ���
            '****************************************************
            mobjSocketListener.strSendText = strSendText
            mobjSocketListener.Send()
            AddToLog(MESSAGE_002 & mobjSocketListener.strSendText)


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ؽŰ��M��ϰ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ؽŰ��M��ϰ
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
                '(��M÷�Ă����݂��Ă����ꍇ)

                Dim strDispText As String = ""      '��M�d���\��������
                If rdoListenerASCII.Checked = True Then
                    '(���䕶���\���̏ꍇ)
                    Dim objASCII As New clsASCII
                    strDispText = objASCII.GetLogString(mobjSocketListener.strRecvText)
                Else
                    '(ɰ�ق̏ꍇ)
                    strDispText = mobjSocketListener.strRecvText
                End If
                AddToLog(MESSAGE_001 & strDispText)
                txtListenerRecvText.Text = strDispText

                '��ʿ��ēd���𕪉����ĕ\�� & ���퉞���d�����M
                Call DenbunBunkai(strDispText)

            End If


            tmrListenTimer.Enabled = True
        Catch ex As Exception
            ComError(ex)
            tmrListenTimer.Enabled = False


        End Try
    End Sub
#End Region
#Region "  ��ʿ��ēd���𕪉����ĕ\�� & ���퉞���d�����M"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ʿ��ēd���𕪉����ĕ\�������퉞���d�����M
    ''' </summary>
    ''' <param name="strDispText"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub DenbunBunkai(ByVal strDispText As String)
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '���M�p�d��
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '��M�p�d��


        '************************
        'ү���ސݒ�
        '************************
        objTelegramRecv.FORMAT_ID = "DSP_000000"                 '̫�ϯĖ����
        objTelegramRecv.TELEGRAM_PARTITION = strDispText         '��������d�����
        objTelegramRecv.PARTITION()                              '�d������

        objTelegramRecv.FORMAT_ID = "DSP_" & objTelegramRecv.SELECT_HEADER("DSPCMD_ID")      '̫�ϯĖ����
        objTelegramRecv.PARTITION()                                                 '�d������


        '************************
        '�d������
        '************************
        Dim strDenbunDtl(0) As String          '�d������z��
        Dim strDenbunDtlName(0) As String      '�d�����𖼏̔z��
        Dim objTemplateServer As New clsTemplateServer(gobjOwner, gobjDb, Nothing)       '�i��Ͻ�
        objTemplateServer.AnalysisDenbun(strDenbunDtl _
                                       , strDenbunDtlName _
                                       , objTelegramRecv _
                                         )

        For ii As Integer = 0 To strDenbunDtl.Length - 1
            '(ٰ��:�d���������ʂ̔z��)
            txtListenerRecvText.Text &= vbCrLf
            txtListenerRecvText.Text &= SPC_PAD_LEFT_SJIS("�y" & strDenbunDtlName(ii) & "�z", 30)
            txtListenerRecvText.Text &= strDenbunDtl(ii)
        Next



        If rdoReturnOK.Checked = True Then
            '(���퉞���̏ꍇ)


            '************************
            '���퉞���d�����M
            '************************
            Dim strMSG_SEND As String = ""      '�����d��
            objTemplateServer.MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
            txtListenerSendText.Text = strMSG_SEND
            Call cmdListenerSend_Click(Nothing, Nothing)


        ElseIf rdoReturnNG.Checked = True Then
            '(NG�����̏ꍇ)


            '************************
            '�ُ퉞���d�����M
            '************************
            Dim strMSG_SEND As String = ""      '�����d��
            objTemplateServer.MakeMessageGamenNG(objTelegramSend, strMSG_SEND, txtMessage.Text)
            txtListenerSendText.Text = strMSG_SEND
            Call cmdListenerSend_Click(Nothing, Nothing)


        ElseIf rdoReturnMessage.Checked = True Then
            '(ү���މ����̏ꍇ)


            '************************
            'ү���މ����d�����M
            '************************
            Dim strMSG_SEND As String = ""      '�����d��
            objTemplateServer.MakeMessageGamenMessage(objTelegramSend, strMSG_SEND, txtMessage.Text)
            txtListenerSendText.Text = strMSG_SEND
            Call cmdListenerSend_Click(Nothing, Nothing)


        Else
            '(���̑��̏ꍇ)


            '************************
            '���퉞���d�����M
            '************************
            Dim strMSG_SEND As String = ""      '�����d��
            objTemplateServer.MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
            txtListenerSendText.Text = strMSG_SEND
            Call cmdListenerSend_Click(Nothing, Nothing)


        End If


    End Sub
#End Region



#Region "  ��ʴװ����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��ʴװ����
    ''' </summary>
    ''' <param name="ex">�װException</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ComError(ByVal ex As Exception)
        Try

            '*****************************************************
            '÷�Đ���
            '*****************************************************
            Dim strTemp As String
            Dim strStackTrace(0) As String
            strTemp = Replace(ex.StackTrace, ",", "�C")       '���p��ς�S�p��ςɕϊ�
            strStackTrace = Split(strTemp, vbCrLf)

            '*****************************************************
            ' ۸ޏ�����
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
#Region "  ۸ޏ�������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۸ޏ�������
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
            '̧��۸ޏo��
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
            mobjLogWrite.WriteLog(strMsg_1, strMsg_2, strMsg_3)              '۸ޏ���


            '*****************************************************
            'ؽďo��
            '*****************************************************
            '==============================================
            '��`���ꂽ�s���܂�ؽ��ޯ���̍s���폜
            '==============================================
            While lstLog.Items.Count >= mintListCount
                lstLog.Items.RemoveAt(lstLog.Items.Count - 1)
            End While

            '==============================================
            'ؽĒǉ�
            '==============================================
            Dim strMessage As String = Format(Now, DATE_FORMAT_99) & Space(5) & strMsg_2 & strMsg_1 & Space(5) & strMsg_3
            If InStr(strMessage, "���݂��ޯ̧") = 0 Then
                lstLog.Items.Insert(0, strMessage)
            End If


        Catch ex2 As Exception
            Throw New Exception(ex2.Message)

        End Try
    End Sub
#End Region


End Class