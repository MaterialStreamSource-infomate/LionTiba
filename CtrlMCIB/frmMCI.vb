'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zMCIҲ�̫��
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports    "
Imports MateCommon
Imports MateCommon.clsConst
Imports UserProcess
Imports System.IO.Ports
Imports JobCommon
#End Region

Public Class frmMCI

    '***********************************************
    '����������������K�v
#Region "  ���ʕϐ�         "

    '==================================================
    '���ʵ�޼ު��
    '==================================================
    Private mobjDb As clsConn                       '�׸ِڑ���޼ު��
    Private mobjDbLog As clsConn                    '�׸ِڑ���޼ު��
    Private mobjOwner As clsOwner                   '��Ű��޼ު��
    Private mobjLogWriter As clsLogWriter           '÷��۸޸׽
    Private mobjLogWriterMany As clsLogWriter       '÷��۸޸׽(�ǉ��p)

    '==================================================
    'Confiģ�ُ��
    '==================================================
    '۸ފ֌W
    Private mstrFilePath As String                  '̧���߽        ���
    Private mstrFileName As String                  '̧�ٖ�         ���
    Private mintMaxDeleteDay As Integer             '�ێ�����       ���
    Private mintMaxSize As Integer                  '�ő�̧�ٻ���   ���
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/04/24  �ǉ��p۸ނ𕪂���
    '۸ފ֌W(�ǉ��p)
    Private mstrFilePathMany As String             '̧���߽        (�ǉ��p)���
    Private mstrFileNameMany As String             '̧�ٖ�         (�ǉ��p)���
    Private mintMaxDeleteDayMany As Integer        '�ێ�����       (�ǉ��p)���
    Private mintMaxSizeMany As Integer             '�ő�̧�ٻ���   (�ǉ��p)���
    '������������************************************************************************************************************
    '���̑�
    Private mintListCount As Integer                'ؽ��ޯ���ɕ\������ő�s��
    Private mintListFlag As Integer                 'ؽ��ޯ���g�p�׸�      0:�g�p���Ȃ�    1:�g�p
    Private mstrFormName As String                  '̫�і�
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/05/08  ��d�N��������Config�֎�������
    Private mintProcessCheck As Integer             '��۸��ыN��������
    '������������************************************************************************************************************
    Private minttmrMainInterval As Integer          '�ʐM������ϰ             �������
    Private mintCloseWaitTime As Integer            '̫�Ѹ۰�ގ��̑ҋ@����
    Private mintDebugFlag As Integer                '���ޯ���׸�
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/07/03  �׸ِڑ��������Pooling�̐ݒ�l��Config�֎�������
    Private mintOraclePoolingFlag As Integer        '�׸ِڑ��������Pooling�̐ݒ�l  [0:False  1:True(��̫�Ēl)]
    '������������************************************************************************************************************

#End Region
#Region "  �����            "
#Region "  ̫��۰��                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmMCI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call FormLoadProcess()


        Catch ex As Exception
            ComError(ex)
            MsgBox(ex.Message)
            Me.Close()

        End Try
    End Sub
#End Region
#Region "  ̫�Ѹ۰��                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ̫�Ѹ۰��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmMCI_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call FormClosingProcess()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
#End Region
#Region "  �ʐM������ϰ                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  �ʐM������ϰ
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
#Region "  �رْʐM�����        �د�        "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  �رْʐM����� �د� 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCOMOpen.Click
        Try

            Call cmdOpenProcess()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  �رْʐM�۰��        �د�        "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  �رْʐM�۰�� �د�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCOMClose.Click
        Try

            Call cmdCloseProcess()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ýđ��M              �د�        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ýđ��M �د� 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdShowSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowSend.Click
        Try

            Call cmdShowSendProcess()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ����               �د�        "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ���� �د� 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdFormClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFormClose.Click
        Try

            Call cmdFormClose_Click_Process()

        Catch ex As Exception
            Call MsgBox(ex.Message)

        End Try
    End Sub
#End Region
#Region "  ���݉�               �د�        "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ���݉� �د� 
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
#Region "  ����                 ����ٸد�   "
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
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ���ޯ���׸ޕύX                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ���ޯ���׸ޕύX
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

#Region "  ̫��۰��         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormLoadProcess()


        '������������************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/05/08  ��d�N��������Config�֎�������

        ''*********************************************
        ''��d�N������
        ''*********************************************
        'If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) >= 2 Then
        '    Dim strMessage As String
        '    strMessage = "������۸��т͋N�����Ă���̂ŁA���s����܂���B"
        '    MsgBox(strMessage)
        '    Me.Close()
        '    Me.Dispose()
        '    Exit Sub
        'End If

        '������������************************************************************************************************************


        '*****************************************************
        'Confiģ�ُ��擾
        '*****************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MCIB)                                  'Confiģ�ِڑ��׽����
        '۸ފ֌W
        mstrFilePath = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_PATH))                    '̧���߽        ���
        mstrFileName = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_NAME))                    '̧�ٖ�         ���
        mintMaxDeleteDay = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_DELETE_DAY))          '�ێ�����       ���
        mintMaxSize = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_SIZE))                     '�ő�̧�ٻ���   ���
        '������������************************************************************************************************************
        'SystemMate:N.Dounoshita 2013/04/24  �ǉ��p۸ނ𕪂���
        '۸ފ֌W�ǉ��p)
        mstrFilePathMany = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_PATH_MANY))                    '̧���߽        (�ǉ��p)���
        mstrFileNameMany = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_NAME_MANY))                    '̧�ٖ�         (�ǉ��p)���
        mintMaxDeleteDayMany = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_DELETE_DAY_MANY))          '�ێ�����       (�ǉ��p)���
        mintMaxSizeMany = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_SIZE_MANY))                     '�ő�̧�ٻ���   (�ǉ��p)���
        '������������************************************************************************************************************
        '���̑�
        mintListCount = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_LIST_COUNT))                  'ؽĕ\���s��
        mintListFlag = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_LIST_FLAG))                    'ؽ��ޯ���g�p�׸�      0:�g�p���Ȃ�    1:�g�p
        mstrFormName = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FORM_NAME))                    '̫�і�
        '������������************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/05/08  ��d�N��������Config�֎�������
        mintProcessCheck = TO_INTEGER(objConfig.GET_INFO(GKEY_MCI_PROCESS_CHECK))           '��۸��ыN��������
        '������������************************************************************************************************************
        minttmrMainInterval = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_TMRMAIN_INTERVAL))      '�ʐM������ϰ             ������� 
        mintCloseWaitTime = TO_NUMBER(objConfig.GET_INFO(GKEY_MCI_CLOSE_WAIT_TIME))         '̫�Ѹ۰�ގ��̑ҋ@����
        mintDebugFlag = TO_STRING(objConfig.GET_INFO(GKEY_MCI_DEBUG_FLAG))                  '���ޯ���׸�
        '������������************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/07/03  �׸ِڑ��������Pooling�̐ݒ�l��Config�֎�������
        mintOraclePoolingFlag = TO_STRING(objConfig.GET_INFO(GKEY_MCI_ORACLE_POOLING_FLAG)) '�׸ِڑ��������Pooling�̐ݒ�l  [0:False  1:True(��̫�Ēl)]
        '������������************************************************************************************************************


        '������������************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/05/08  ��d�N��������Config�֎�������

        '*********************************************
        '��d�N������
        '*********************************************
        If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) >= mintProcessCheck Then
            Dim strMessage As String
            strMessage = "�����ɋN���\����۸��ѐ��𒴂��Ă���̂ŁA�N���ł��܂���B[�����N��������:" & TO_STRING(mintProcessCheck) & "]"
            MsgBox(strMessage)
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If

        '������������************************************************************************************************************


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
        '������������************************************************************************************************************
        'SystemMate:N.Dounoshita 2013/04/24  �ǉ��p۸ނ𕪂���
        Dim strLogFileNameMany As String = ""       '۸�̧�ٖ�
        strLogFileNameMany &= mstrFileNameMany
        'strLogFileNameMany &= Diagnostics.Process.GetCurrentProcess.ProcessName
        'strLogFileNameMany &= Me.Name
        mobjLogWriterMany = clsLogWriter.GetInstance(mstrFilePathMany, _
                                                     strLogFileNameMany, _
                                                     mintMaxDeleteDayMany, _
                                                     mintMaxSizeMany _
                                                     )
        '������������************************************************************************************************************


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
        '������������************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/07/03  �׸ِڑ��������Pooling�̐ݒ�l��Config�֎�������
        If mintOraclePoolingFlag = FLAG_OFF Then mobjDb.ConnectString &= ORACLE_CONNECT_STRING01
        '������������************************************************************************************************************
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
        '������������************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/07/03  �׸ِڑ��������Pooling�̐ݒ�l��Config�֎�������
        If mintOraclePoolingFlag = FLAG_OFF Then mobjDbLog.ConnectString &= ORACLE_CONNECT_STRING01
        '������������************************************************************************************************************
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
            gobjMain = New clsMCIMain(mobjOwner, mobjDb, mobjDbLog)         'MCI�ʐM��޼ު�Đ���
            gobjMCI = Me                                                    '��̫�Ѿ��
            Me.Text = mstrFormName                                          '̫�і����
            NotifyIcon1.Text = Me.Text                                      '���ݖ����
            NotifyIcon1.Visible = False                                     '���ݔ�\��


            '*****************************************************
            '۸ޏo��
            '*****************************************************
            Call AddToLog(Me.Text & "�J�n�B")


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
            '���̑�
            '*****************************************************
            '���ޯ���׸�
            If mintDebugFlag = FLAG_ON Then chkDebugFlag.Checked = True Else chkDebugFlag.Checked = False


        Catch ex As Exception
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
#Region "  ����           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdFormClose_Click_Process()
        Dim udtRetMsg As MsgBoxResult


        '*****************************************************
        'ү�����ޯ��\��
        '*****************************************************
        If 0 < mintCloseWaitTime Then
            '(̫�Ѹ۰�ގ��̑ҋ@���Ԃ��ݒ肳��Ă����ꍇ)
            Dim strMsg As String = ""
            strMsg &= Me.Text & "���I�����Ă�낵���ł����H"
            strMsg &= vbCrLf & "�I������ɂ�" & mintCloseWaitTime & "�b������܂��B"
            udtRetMsg = MsgBox(strMsg, MsgBoxStyle.YesNo)
            If udtRetMsg <> MsgBoxResult.Yes Then Exit Sub
        End If


        '*****************************************************
        '�F�X����
        '*****************************************************
        Dim dtmTemp As Date = Now       '���ݎ���
        tmrMain.Enabled = False         '��ϰ�į��
        While True
            '(�w�肳�ꂽ�b���o�߂�����Exit)
            If DateAdd(DateInterval.Second, mintCloseWaitTime, dtmTemp) < Now Then Exit While
        End While
        mobjOwner.AddToLog("��۸��т��I�����܂��B")


        '*****************************************************
        '÷��۸޸׽     �폜
        '*****************************************************
        If IsNull(mobjLogWriter) = False Then
            mobjLogWriter.Dispose()
            mobjLogWriter = Nothing
        End If
        '������������************************************************************************************************************
        'SystemMate:N.Dounoshita 2013/04/24  �ǉ��p۸ނ𕪂���
        If IsNull(mobjLogWriterMany) = False Then
            mobjLogWriterMany.Dispose()
            mobjLogWriterMany = Nothing
        End If
        '������������************************************************************************************************************


        '*****************************************************
        '̫�Ѹ۰��
        '*****************************************************
        Me.Close()


    End Sub
#End Region
#Region "  ���݊֌W         "
#Region "  ���݉�       ����            "
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
#Region "  ����         ����ٸد�����   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���� ����ٸد�����
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
#Region "  ̫�Ѹ۰��        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫�Ѹ۰��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormClosingProcess()


        '*****************************************************
        '÷��۸޸׽     �폜
        '*****************************************************
        If IsNull(mobjLogWriter) = False Then
            mobjLogWriter.Dispose()
            mobjLogWriter = Nothing
        End If
        '������������************************************************************************************************************
        'SystemMate:N.Dounoshita 2013/04/24  �ǉ��p۸ނ𕪂���
        If IsNull(mobjLogWriterMany) = False Then
            mobjLogWriterMany.Dispose()
            mobjLogWriterMany = Nothing
        End If
        '������������************************************************************************************************************


        '***********************************************
        '�ʐM�ؒf
        '***********************************************
        tmrMain.Enabled = False
        If IsNull(gobjMain) = False Then
            gobjMain.Close()
        End If


        '***********************************************
        '��޼ު�ĊJ��
        '***********************************************
        If IsNull(mobjDb) = False Then
            mobjDb.Disconnect()
            mobjDb = Nothing
        End If
        If IsNull(mobjDbLog) = False Then
            mobjDbLog.Disconnect()
            mobjDbLog = Nothing
        End If
        If IsNull(gobjMain) = False Then
            gobjMain = Nothing
        End If


    End Sub
#End Region

#Region "  �װ����          "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  �װ����
    ''' </summary>
    ''' <param name="objException">�װException</param>
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
#Region "  ۸ޏ�������      "
    ''' ****************************************************************************************
    ''' <summary>
    '''  ۸ޏ�������
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
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
#Region "  ۸ޏ�������(�ǉ��p)  "
    ''' ****************************************************************************************
    ''' <summary>
    '''  ۸ޏ�������(�ǉ��p)
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub AddToManyLog(ByVal strMsg_1 As String)
        Try

            '*****************************************************
            '̧��۸ޏo��
            '*****************************************************
            Dim strLogMessage As String = ""
            strLogMessage &= "," & strMsg_1
            mobjLogWriterMany.WriteTxtLog(strLogMessage)

        Catch ex2 As Exception
            '�������Ȃ�

        End Try
    End Sub
#End Region
    '����������������K�v
    '***********************************************


#Region "  �رْʐM�����    "
    ''' ****************************************************************************************
    ''' <summary>
    ''' �رْʐM�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Private Sub cmdOpenProcess()
        Try
            Call cmdCloseProcess()      '�ʐM�ؒf
        Catch ex As Exception
            Call AddToLog("�ʐM�߰ĸ۰�ޏ����Ɏ��s���܂����B")
        End Try
        Call FormLoadProcess()      '�ʐM�ĊJ

        tmrMain.Enabled = True

    End Sub
#End Region
#Region "  �رْʐM�۰��    "
    ''' ****************************************************************************************
    ''' <summary>
    ''' �رْʐM�۰��
    ''' </summary>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Private Sub cmdCloseProcess()

        tmrMain.Enabled = False

        mobjDb.Disconnect()         'DB�ؒf
        mobjDbLog.Disconnect()      'DB�ؒf

        gobjMain.Close()

    End Sub
#End Region
#Region "  ýđ��M          "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ýđ��M
    ''' </summary>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Private Sub cmdShowSendProcess()
        Try

            'gobjMain.SendDataListener(TextBox1.Text)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region


#Region "  ����PLC°�                   ���ݸد�"
    Private Sub cmdTool01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTool01.Click
        Try
            Dim objForm As New frmTool01(mobjOwner)
            objForm.Show()
        Catch ex As Exception
            Call ComError(ex)
        End Try
    End Sub
#End Region


End Class