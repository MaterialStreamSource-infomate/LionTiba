'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z��а���۰ْʐM�p̫��   (KSH�p���ޯ��°قł�)
' �y�쐬�z2006/05/30  SIT  Rev 0.00
'**********************************************************************************************

#Region "  Imports  "
Imports JOBCommon
Imports MateCommon.clsConst
Imports MateCommon
Imports UserProcess
#End Region

Public Class frmMCIDummy

#Region "  ���ʕϐ�"

    '==================================================
    '���ʵ�޼ު��
    '==================================================
    Private mobjOwner As clsOwner                   '��Ű��޼ު��
    Private mobjDb As clsConn                       '�׸ِڑ���޼ު��
    Private mobjDbLog As clsConn                    '�׸ِڑ���޼ު��
    Private mobjLogWriter As clsLogWriter           '÷��۸޸׽


    '==================================================
    'Confiģ�ُ��
    '==================================================
    '۸ފ֌W
    Private mstrFilePath As String                  '̧���߽        ���
    Private mstrFileName As String                  '̧�ٖ�         ���
    Private mintMaxDeleteDay As Integer             '�ێ�����       ���
    Private mintMaxSize As Integer                  '�ő�̧�ٻ���   ���
    '���̑�
    Private mintListCount As Integer                'ؽ��ޯ���ɕ\������ő�s��
    Private mintListFlag As Integer                 'ؽ��ޯ���g�p�׸�      0:�g�p���Ȃ�    1:�g�p
    Private mstrFormName As String                  '̫�і�
    Private minttmrMainInterval As Integer          '�ʐM������ϰ             �������
    Private mintCloseWaitTime As Integer            '̫�Ѹ۰�ގ��̑ҋ@����
    Private mintDebugFlag As Integer                '���ޯ���׸�


#End Region
#Region "  �����    "
#Region "  ̫��۰��"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmCtrlMCI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call FromLoadProcess()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  �ʐM������ϰ              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ʐM������ϰ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmrMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMain.Tick
        Try

            tmrMain.Enabled = False

            Call tmrMainProcess()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmrMain.Enabled = True

        End Try
    End Sub
#End Region
#Region "  ���M���ݽNo  ���     �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���M���ݽNo  ��� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendSeqnoSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendSEQNoSet.Click
        Try

            Call cmdSendSeqnoSet_Click_Process()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ��M���ݽNo  ���     �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��M���ݽNo  ��� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdRecvSeqnoSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRecvSEQNoSet.Click
        Try

            Call cmdRecvSeqnoSet_Click_Process()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  �Ƃɂ����d�����M     �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �Ƃɂ����d�����M �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendTelegram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendTelegram.Click
        Try


            Call cmdSendTelegram_ClickProcess()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ��а �� ����          �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��а �� ���� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendToButuryu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendToButuryu.Click
        Try

            Call cmdSendToButuryu_ClickProcess()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  "
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
            ComError(ex)

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
    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Try

            Call NotifyIcon1_MouseDoubleClickProcess()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region " "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  Close �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try

            Call cmdClose_ClickProcess()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ���ޯ���׸ޕύX                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ޯ���׸ޕύX
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub chkDebugFlag_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDebugFlag.CheckedChanged
        Try

            If chkDebugFlag.Checked = True Then
                gobjMain.intDebugFlag = FLAG_ON
            Else
                gobjMain.intDebugFlag = FLAG_OFF
            End If

        Catch ex As Exception

        End Try
    End Sub
#End Region
#End Region


    '****************************************
    ' ����ď���
    '****************************************
#Region "  ̫��۰��         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FromLoadProcess()


        '*****************************************************
        'Confiģ�ُ��擾
        '*****************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MCIA_DUMMY)                             'Confiģ�ِڑ��׽����
        '۸ފ֌W
        mstrFilePath = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_PATH))                    '̧���߽        ���
        mstrFileName = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_NAME))                    '̧�ٖ�         ���
        mintMaxDeleteDay = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_DELETE_DAY))          '�ێ�����       ���
        mintMaxSize = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_SIZE))                     '�ő�̧�ٻ���   ���
        '���̑�
        mintListCount = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_LIST_COUNT))                  'ؽĕ\���s��
        mintListFlag = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_LIST_FLAG))                    'ؽ��ޯ���g�p�׸�      0:�g�p���Ȃ�    1:�g�p
        mstrFormName = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FORM_NAME))                    '̫�і�
        minttmrMainInterval = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_TMRMAIN_INTERVAL))      '�ʐM������ϰ             ������� 
        mintCloseWaitTime = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_CLOSE_WAIT_TIME))         '̫�Ѹ۰�ގ��̑ҋ@����
        mintDebugFlag = TO_STRING(objConfig.GET_INFO(GKEY_MCI_DEBUG_FLAG))                  '���ޯ���׸�


        '*****************************************************
        '۸ޏo�͵�޼ު�Đ���
        '*****************************************************
        Dim strLogFileName As String = ""       '۸�̧�ٖ�
        strLogFileName &= mstrFileName
        'strLogFileName &= Diagnostics.Process.GetCurrentProcess.ProcessName
        'strLogFileName &= Me.Name
        mobjLogWriter = clsLogWriter.GetInstance(mstrFilePath, _
                                                 strLogFileName, _
                                                 mintMaxDeleteDay, _
                                                 mintMaxSize _
                                                 )


        '**************************************************************************
        ' �׸ِڑ�
        '**************************************************************************
        '===============================================
        'Config�擾
        '===============================================
        Dim objSystem As New clsConnectConfig(CONFIG_FILE)

        '===============================================
        'DB�ڑ�
        '===============================================
        mobjDb = New clsConn
        mobjDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
        While True
            '(�ڑ�����܂�ٰ��)
            Dim blnRet As Boolean = False
            blnRet = mobjDb.Connect()
            If blnRet = True Then Exit While
        End While

        '===============================================
        'DB�ڑ�
        '===============================================
        mobjDbLog = New clsConn
        mobjDbLog.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
        While True
            '(�ڑ�����܂�ٰ��)
            Dim blnRet As Boolean = False
            blnRet = mobjDbLog.Connect()
            If blnRet = True Then Exit While
            Call AddToLog(Me.Text & "DB�ڑ����s")
        End While


        mobjDb.BeginTrans()     '��ݻ޸��݊J�n
        Try

            '*****************************************************
            '�F�X�ݒ�
            '*****************************************************
            mobjOwner = New clsOwner                                        '��Ű��޼ު��
            gobjMain = New clsMCIMainDummy(mobjOwner, mobjDb, mobjDbLog)         'MCI�ʐM��޼ު�Đ���
            gobjMCI = Me                                                    '��̫�Ѿ��
            Me.Text = mstrFormName                                          '̫�і����
            NotifyIcon1.Text = Me.Text                                      '���ݖ����
            NotifyIcon1.Visible = False                                     '���ݔ�\��


            '*****************************************************
            '۸ޏo��
            '*****************************************************
            Call AddToLog(Me.Text & "�J�n")


            '*****************************************************
            'Ҳݵ�޼ު�ď�����
            '*****************************************************
            gobjMain.Initialize()


            '*****************************************************
            '���݉�
            '*****************************************************
            'Me.ShowInTaskbar = True
            Call cmdIcon_ClickProcess()


            '*****************************************************
            '�ʐM������ϰ   ���
            '*****************************************************
            tmrMain.Interval = minttmrMainInterval      '��ϰ�������
            tmrMain.Enabled = True


            '*****************************************************
            '���M��ʕ\��
            '*****************************************************
            Call cmdSendToButuryu_ClickProcess()


            '*****************************************************
            '���̑�
            '*****************************************************
            '���ޯ���׸�
            If mintDebugFlag = FLAG_ON Then chkDebugFlag.Checked = True Else chkDebugFlag.Checked = False


        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        Finally
            mobjDb.Commit()     '�Я�

        End Try
    End Sub
#End Region
#Region "  �ʐM������ϰ     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ʐM������ϰ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmrMainProcess()

        gobjMain.Main()

    End Sub
#End Region
#Region "  ���M���ݽNo  ��ď���"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���M���ݽNo  ��ď���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendSeqnoSet_Click_Process()

        gobjMain.intSendSEQNo = TO_INTEGER(txtSendSEQNo.Text)
        txtSendSEQNo.Text = ZERO_PAD(gobjMain.intSendSEQNo, 4)

    End Sub
#End Region
#Region "  ��M���ݽNo  ��ď���"
    Private Sub cmdRecvSeqnoSet_Click_Process()

        gobjMain.intRecvSEQNo = TO_INTEGER(txtRecvSEQNo.Text)
        txtRecvSEQNo.Text = ZERO_PAD(gobjMain.intRecvSEQNo, 4)

    End Sub
#End Region
#Region "  �Ƃɂ����d�����M     �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �Ƃɂ����d�����M �د�
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendTelegram_ClickProcess()

        Call Write(txtSendTelegram.Text)

    End Sub
#End Region
#Region "  ��а �� ����         �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ��а �� ���� �د�
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendToButuryu_ClickProcess()


        '***********************************************
        '����
        '***********************************************
        If IsNull(gobjMCIToServer) = False Then
            '(̫�т����݂��Ă����ꍇ)

            If gobjMCIToServer.NotifyIcon1.Visible = True Then
                '(���݉�����Ă����ꍇ)
                MsgBox("����̫�т��W�J����Ă���ׁA�����̫�т͍쐬�ł��܂���B")
                Exit Sub
            Else
                '(���݉�����Ă��Ȃ��ꍇ)
                gobjMCIToServer.Close()
                gobjMCIToServer.Dispose()
                gobjMCIToServer = Nothing
            End If
        End If


        '***********************************************
        '̫�ѕ\��
        '***********************************************
        gobjMCIToServer = New frmMCIDummyToServer
        gobjMCIToServer.ShowDialog()
        If gobjMCIToServer.NotifyIcon1.Visible = False Then
            '(���݉��ȊO�̏ꍇ)
            gobjMCIToServer.Close()
            gobjMCIToServer.Dispose()
            gobjMCIToServer = Nothing
        End If


    End Sub
#End Region
#Region "  Close                �د�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Close �د�
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_ClickProcess()

        '*****************************************************
        '÷��۸޸׽     �폜
        '*****************************************************
        If IsNull(mobjLogWriter) = False Then
            mobjLogWriter.Dispose()
            mobjLogWriter = Nothing
        End If


        gobjMain.Close()
        Me.Close()

    End Sub
#End Region
#Region "  ���݊֌W"

#Region "  ���݉�       ����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���݉� ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cmdIcon_ClickProcess()

        Me.Opacity = 0
        Me.ShowInTaskbar = False
        NotifyIcon1.Visible = True
        Me.Hide()

    End Sub
#End Region

#Region "  ����         ����ٸد�����"
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ���� ����ٸد�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub NotifyIcon1_MouseDoubleClickProcess()

        Me.Show()
        Me.Opacity = 100
        Me.ShowInTaskbar = True
        NotifyIcon1.Visible = False

    End Sub
#End Region

#End Region


    '****************************************
    ' ̫�ѓ����ʊ֐�����
    '****************************************
#Region "  ÷�đ��M                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ÷�đ��M
    ''' </summary>
    ''' <param name="strText"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Write(ByVal strText As String)
        Try

            Call gobjMain.SendDataVAGC(strText)


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  �װ����                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �װ����
    ''' </summary>
    ''' <param name="objException"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ComError(ByVal objException As Exception)
        Try


            '*****************************************************
            '÷�Đ���
            '*****************************************************
            Dim strTemp As String
            Dim strStackTrace(0) As String
            strTemp = Replace(objException.StackTrace, ",", "�C")       '���p��ς�S�p��ςɕϊ�
            strStackTrace = Split(strTemp, vbCrLf)


            '*****************************************************
            ' ۸ޏ�����
            '*****************************************************
            For ii As Integer = LBound(strStackTrace) To UBound(strStackTrace)
                Me.AddToLog(objException.Message & "," & strStackTrace(ii))
            Next


        Catch ex2 As Exception
            'NOP
        End Try
    End Sub
#End Region
#Region "  ۸ޏ�������                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۸ޏ�������
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)
        Try

            '*****************************************************
            '̧��۸ޏo��
            '*****************************************************
            Dim strLogMessage As String = ""
            strLogMessage &= "," & strMsg_1
            mobjLogWriter.WriteTxtLog(strLogMessage)


            '*****************************************************
            'ؽďo��
            '*****************************************************
            Dim strMessage As String = Format(Now, DATE_FORMAT_99) & Space(5) & strMsg_1 & Space(5)
            If mintListFlag = FLAG_ON Then
                '==============================================
                '��`���ꂽ�s���܂�ؽ��ޯ���̍s���폜
                '==============================================
                While ListBox1.Items.Count >= mintListCount
                    ListBox1.Items.RemoveAt(ListBox1.Items.Count - 1)
                End While

                '==============================================
                'ؽĒǉ�
                '==============================================
                ListBox1.Items.Insert(0, strMessage)

            End If


        Catch ex2 As Exception
            '�������Ȃ�

        End Try
    End Sub
#End Region


End Class