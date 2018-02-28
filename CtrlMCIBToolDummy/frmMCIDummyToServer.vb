'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�ʐM̫��                 (KSH�p���ޯ��°قł�)
' �y�쐬�z2006/05/30  SIT  Rev 0.00
'**********************************************************************************************

#Region "  Imports  "
Imports JOBCommon
Imports MateCommon.clsConst
Imports MateCommon
Imports UserProcess
#End Region

Public Class frmMCIDummyToServer

    '***********************************************
    '����������������K�v
#Region "  ���ʕϐ�             "

    Private mobjDb As clsConn                       '�׸ِڑ���޼ު��
    Private mobjMCIMain As CtrlMCIB.clsMCIMain      '�{���̒ʐM��۸��Ѹ׽

#End Region
#Region "�@�񋓑́@             "
#End Region
#Region "  �����                "
#Region "  ̫��۰��"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim objConfig = New clsConnectConfig(CONFIG_MCIB_DUMMY)                     'Confiģ�ِڑ��׽����

            '************************************
            '�F�X������
            '************************************
            Me.Text = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FORM_NAME))                 '̫�і����
            Me.Text &= "��а���M"                                                       '̫�і����
            NotifyIcon1.Text = Me.Text                                                  '���ݖ����
            NotifyIcon1.Visible = False                                                 '���ݔ�\��
            mobjMCIMain = New CtrlMCIB.clsMCIMain(Nothing, Nothing, Nothing)            '�{���̒ʐM��۸��Ѹ׽

            '--------------------------
            'DB�ڑ��J�n
            '--------------------------
            Dim objSystem As New clsConnectConfig(CONFIG_FILE)
            mobjDb = New clsConn                                '�׸ِڑ���޼ު��
            mobjDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
            While True
                '(�ڑ�����܂�ٰ��)
                Dim blnRet As Boolean = False
                blnRet = mobjDb.Connect()
                If blnRet = True Then Exit While
            End While


            ''************************************
            ''���݉�
            ''************************************
            'Call cmdIcon_ClickProcess()


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region
#Region "  Close�د�    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Close�د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try

            Me.Close()

        Catch ex As Exception
            '�������Ȃ�

        End Try
    End Sub
#End Region
#Region "  ���݉�               �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���݉� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIcon.Click
        Try

            Call cmdIcon_ClickProcess()

        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ����                 ����ٸد�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���� ����ٸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Try

            Call NotifyIcon1_MouseDoubleClickProcess()

        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ���݊֌W             "
#Region "  ���݉�       ����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���݉� ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cmdIcon_ClickProcess()

        '���g̫��
        Me.Opacity = 0
        Me.ShowInTaskbar = False
        Me.NotifyIcon1.Visible = True
        Me.Hide()

    End Sub
#End Region
#Region "  ����         ����ٸد�����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���� ����ٸد�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub NotifyIcon1_MouseDoubleClickProcess()

        '���g̫��
        Me.Show()
        Me.Opacity = 100
        Me.ShowInTaskbar = True
        Me.NotifyIcon1.Visible = False

    End Sub
#End Region
#End Region
#Region "  Boolean�^��Integer�^�ɕϊ�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Boolean�^��Integer�^�ɕϊ�
    ''' </summary>
    ''' <param name="blnBoolean"></param>
    ''' <returns></returns>
    ''' *******************************************************************************************************************
    ''' <remarks></remarks>
    Private Function ChangeBooleanToInteger(ByVal blnBoolean As Boolean) As Integer
        Dim intReturn As Integer

        intReturn = IIf(blnBoolean, 1, 0)

        Return intReturn
    End Function
#End Region

#Region "  �װ����              "
    '''**********************************************************************************************
    ''' <summary>
    ''' �װ����
    ''' </summary>
    ''' <param name="objException">Exception��޼ު��</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub ComError(ByVal objException As Exception)
        Try
            gobjMCI.ComError(objException)
            MsgBox(objException)
        Catch ex As Exception
            'NOP
        End Try
    End Sub
#End Region
    '����������������K�v
    '***********************************************

#Region "  �����                "
#End Region



#Region "  ID:05  �⍇��ү���ނɑ΂��鉞��          "
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd01.Click
        'Try


        '    '*************************************************
        '    '�d�����M
        '    '*************************************************
        '    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_LC)
        '    objTelegram.FORMAT_ID = FORMAT_LC_00            '̫�ϯĖ����

        '    objTelegram.SETIN_DATA("LCCRN01_RES", gobjMCIToServer.txtLCCRN01_RES.Text)                  '�ڰ�1����
        '    objTelegram.SETIN_DATA("LCCRN01_UNU", gobjMCIToServer.txtLCCRN01_UNU.Text)                  '�ڰ�1�ُ���
        '    objTelegram.SETIN_DATA("LCCRN02_RES", gobjMCIToServer.txtLCCRN02_RES.Text)                  '�ڰ�2����
        '    objTelegram.SETIN_DATA("LCCRN02_UNU", gobjMCIToServer.txtLCCRN02_UNU.Text)                  '�ڰ�2�ُ���
        '    objTelegram.SETIN_DATA("LCCRN03_RES", gobjMCIToServer.txtLCCRN03_RES.Text)                  '�ڰ�3����
        '    objTelegram.SETIN_DATA("LCCRN03_UNU", gobjMCIToServer.txtLCCRN03_UNU.Text)                  '�ڰ�3�ُ���
        '    objTelegram.SETIN_DATA("LCCRN0401_RES", gobjMCIToServer.txtLCCRN0401_RES.Text)              '�ڰ�4���1����
        '    objTelegram.SETIN_DATA("LCCRN0402_RES", gobjMCIToServer.txtLCCRN0402_RES.Text)              '�ڰ�4���2����
        '    objTelegram.SETIN_DATA("LCCRN0401_STATE", gobjMCIToServer.txtLCCRN0401_STATE.Text)          '�ڰ�4���1���
        '    objTelegram.SETIN_DATA("LCCRN0402_STATE", gobjMCIToServer.txtLCCRN0402_STATE.Text)          '�ڰ�4���2���

        '    objTelegram.MAKE_TELEGRAM()                                 '�d���쐬
        '    gobjMain.SendDataVAGC(objTelegram.TELEGRAM_MAKED)           '���M�d��


        'Catch ex As Exception
        '    Call ComError(ex)
        'End Try
    End Sub
#End Region
End Class