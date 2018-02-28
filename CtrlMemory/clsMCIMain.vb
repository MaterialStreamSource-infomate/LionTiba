'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zMCIҲݸ׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports  "
Imports JobCommon
Imports MateCommon.clsConst
Imports MateCommon
#End Region

Public Class clsMCIMain

#Region "  ���ʕϐ�02           "

    '==================================================
    '���ʵ�޼ު��
    '==================================================

    '==================================================
    '�����ϐ�
    '==================================================


#End Region

    '***********************************************
    '����������������K�v
#Region "  ���ʕϐ�             "

    '==================================================
    '���ʵ�޼ު��
    '==================================================
    Private mobjOwner As Object                                 '��Ű��޼ު��

    '==================================================
    '�����ϐ�
    '==================================================
    Private mdtmNow As Date                     '���ݓ���
    Private mdtmBeforeMemoryLogTime As Date     '�O�����۸ޏo�͎���
    Private mdtmBeforeOraLogTime As Date        '�O�����۸ޏo�͎���

    '==================================================
    'Confiģ�ُ��
    '==================================================
    '۸ފ֌W
    Private mstrFilePath As String                  '̧���߽        ���
    Private mstrFileName As String                  '̧�ٖ�         ���
    Private mintMaxDeleteDay As Integer             '�ێ�����       ���
    Private mintMaxSize As Integer                  '�ő�̧�ٻ���   ���
    '���̑�
    Private mintDebugFlag As Integer                '���ޯ���׸�

    '==================================================
    '�Œ�l
    '==================================================
    Private Const ERR_MSG_01 As String = "���Ѵװ�����B"

#End Region
#Region "  �����è              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ���ޯ���׸�
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Property intDebugFlag() As Integer
        Get
            Return mintDebugFlag
        End Get
        Set(ByVal Value As Integer)
            mintDebugFlag = Value
        End Set
    End Property
#End Region

#Region "  Ҳݏ���              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' Ҳݏ���
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Overridable Sub Main()
        Try
            'Dim strMsg As String                    'ү����


            '*****************************************************
            '�F�X������
            '*****************************************************
            mdtmNow = Now


            '*****************************************************
            'Confiģ�ُ��擾
            '*****************************************************
            Dim objConfig As New clsConnectConfig(CONFIG_MEMORY)                              'Confiģ�ِڑ��׽����
            '۸ފ֌W
            mstrFilePath = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_PATH))                    '̧���߽        ���
            mstrFileName = TO_STRING(objConfig.GET_INFO(GKEY_LOG_FILE_NAME))                    '̧�ٖ�         ���
            mintMaxDeleteDay = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_DELETE_DAY))          '�ێ�����       ���
            mintMaxSize = TO_NUMBER(objConfig.GET_INFO(GKEY_LOG_FILE_SIZE))                     '�ő�̧�ٻ���   ���
            '���̑�
            Dim intMemoryLogTimer As Integer                                                    '���۸ނ��o�͂������      (min)
            intMemoryLogTimer = TO_INTEGER(objConfig.GET_INFO("MemoryLogTimer"))


            '������������************************************************************************************************************
            '�ýē��L����

            '*****************************************************
            '�׸ق���؏�Ԃ̏o�͏���(�ýē��L����)
            '*****************************************************
            Try
                Call MainProcess03()
            Catch ex As Exception
                Call ComError(ex)
            End Try

            '������������************************************************************************************************************


            '*****************************************************
            '��ϰ����
            '*****************************************************
            Dim objDiff As TimeSpan = mdtmBeforeMemoryLogTime.AddMinutes(intMemoryLogTimer) - Now
            If 0 < objDiff.TotalMilliseconds Then
                Exit Sub
            End If
            mdtmBeforeMemoryLogTime = Now


            '*****************************************************
            '��۾�����؏�Ԃ̏o�͏���
            '*****************************************************
            Try
                Call MainProcess01()
            Catch ex As Exception
                Call ComError(ex)
            End Try


            '*****************************************************
            '̧�ٍ폜����
            '*****************************************************
            Try
                Call MainProcess02()
            Catch ex As Exception
                Call ComError(ex)
            End Try


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region
#Region "  �ݽ�׸�              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ݽ�׸�
    ''' </summary>
    ''' <param name="objOwner">��Ű��޼ު��(���۸ޏ����݂Ɏg�p)</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object)
        Try

            '*****************************************************
            '�F�X������
            '*****************************************************
            mobjOwner = objOwner                                '��Ű��޼ު��
            mdtmNow = Now


        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region
#Region "  ������               "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ����������
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Initialize()


        '****************************************************
        '�ʐM�����
        '****************************************************
        Call Open()


    End Sub
#End Region

#Region "  ۸ޏ������ݏ���                  "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ۸ޏ������ݏ���
    ''' </summary>
    ''' <param name="strMsg_1">۸�÷��</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)

        mobjOwner.AddToLog(strMsg_1)

    End Sub
#End Region
#Region "  ۸ޏ������ݏ���(���ޯ�ޗp)       "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ۸ޏ������ݏ���(���ޯ�ޗp)
    ''' </summary>
    ''' <param name="strMsg_1">۸�÷��</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddToDebugLog(ByVal strMsg_1 As String)

        If intDebugFlag = 1 Then
            mobjOwner.AddToLog(strMsg_1)
        End If

    End Sub
#End Region
#Region "  �װ����                          "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �װ����
    ''' </summary>
    ''' <param name="objException">�װException</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
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
                AddToLog(objException.Message & "," & strStackTrace(ii))
            Next


        Catch ex2 As Exception
            'NOP
        End Try
    End Sub
#End Region
    '����������������K�v
    '***********************************************


    '*******************
    'Public
    '*******************
#Region "  ��۾�����؏�Ԃ̏o�͏���                     "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ��۾�����؏�Ԃ̏o�͏���
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub MainProcess01()


        '**********************************************************************************
        'Confiģ�ُ��擾
        '**********************************************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MEMORY)        'Confiģ�ِڑ��׽����
        Dim strProcessNameArray() As String                         '��۾����z��
        strProcessNameArray = Split(TO_STRING(objConfig.GET_INFO("ProcessNameArray")), ",")


        '**********************************************************************************
        '��۾����̎擾
        '**********************************************************************************
        For ii As Integer = 0 To strProcessNameArray.Length - 1
            strProcessNameArray(ii) = strProcessNameArray(ii).Replace(vbCrLf, "")
            strProcessNameArray(ii) = RTrim(strProcessNameArray(ii))
            strProcessNameArray(ii) = LTrim(strProcessNameArray(ii))
        Next


        '**********************************************************************************
        '���[�J���R���s���[�^��Ŏ��s����Ă��邷�ׂẴv���Z�X���擾
        '**********************************************************************************
        Dim ps As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcesses()

        '"machinename"�Ƃ������O�̃R���s���[�^�Ŏ��s����Ă���
        '���ׂẴv���Z�X���擾����ɂ͎��̂悤�ɂ���B
        'Dim ps As System.Diagnostics.Process() = _
        '    System.Diagnostics.Process.GetProcesses("machinename")

        '**********************************************************************************
        '�z�񂩂�1�����o��
        '**********************************************************************************
        For Each p As System.Diagnostics.Process In ps
            Try


                '**********************************************************************************
                '��۾�����
                '**********************************************************************************
                If -1 = ArrayFindData(strProcessNameArray, p.ProcessName) Then Continue For


                ''�v���Z�X�����o�͂���
                'Call AddToLog("�v���Z�X��: {0}" & p.ProcessName)
                ''ID
                'Call AddToLog("ID: {0}" & p.Id)
                ''���C�����W���[���̃p�X
                'Call AddToLog("�p�X: {0}" & p.MainModule.FileName)
                ''���v�v���Z�b�T����
                'Call AddToLog("���v�v���Z�b�T����: {0}" & TO_STRING(p.TotalProcessorTime.Days))
                ''�����������g�p��
                'Call AddToLog("�����������g�p��: {0}" & p.WorkingSet64)
                ''.NET Framework 1.1�ȑO�ł͎��̂悤�ɂ���
                ''Call AddToLog("�����������g�p��: {0}", p.WorkingSet)


                '**********************************************************************************
                '̧�ٖ��̍쐬
                '**********************************************************************************
                Dim strFile As String = ""
                Try
                    strFile &= p.MainModule.FileName
                Catch ex As Exception
                    'MainModule.FileName�ւ̱��������ۂ����ꍇ������
                    'NOP
                End Try
                strFile = Replace(strFile, "\", "_")
                strFile = Replace(strFile, ":", "_")
                strFile &= "_ID_" & p.Id & "_" & p.ProcessName


                '**********************************************************************************
                '۸�÷�č쐬
                '**********************************************************************************
                Dim strMsg As String = ""
                strMsg &= "PrivateMemorySize:" & FixTextMemory(p.PrivateMemorySize64)
                strMsg &= ",VirtualMemorySize:" & FixTextMemory(p.VirtualMemorySize64)
                strMsg &= ",WorkingSet:" & FixTextMemory(p.WorkingSet64)
                Try
                    Dim objDiff As TimeSpan = Now - p.StartTime
                    strMsg &= ",�������:" & SPC_PAD_RIGHT_SJIS(Math.Floor(TO_INTEGER(objDiff.TotalDays)) & "��", 7)
                Catch ex As Exception
                    '���������ۂ����ꍇ������
                    'NOP
                End Try


                '**********************************************************************************
                '۸ޏ�����
                '**********************************************************************************
                Call AddMemoryLog(strFile, strMsg)


            Catch ex As Exception
                Call AddToLog("�G���[: {0}" & ex.Message)
            End Try
        Next


        '*****************************************************
        '۸ޏo��
        '*****************************************************
        AddToLog("���۸ޏo�͊����B")


    End Sub
#End Region
#Region "  ̧�ٍ폜����                                 "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ̧�ٍ폜����
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub MainProcess02()


        '**********************************************************************************
        'Confiģ�ُ��擾
        '**********************************************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MEMORY)        'Confiģ�ِڑ��׽����
        Dim strFolderMain As String                                 '���۸ޗp̫��ޖ�
        Dim strFolderDeleteTimer As String                          '�׸����۸ޗp̫��ނ��폜�������        (Day)
        strFolderMain = TO_STRING(objConfig.GET_INFO("FolderMain"))
        strFolderDeleteTimer = TO_STRING(objConfig.GET_INFO("FolderDeleteTimer"))


        '**********************************************************************************
        '̫��ނ̍폜
        '**********************************************************************************
        '================================================
        '�F�X�ݒ�
        '================================================
        Dim strOraMemoryLogFoler As String
        If Right(mstrFilePath, 1) = "\" Then
            strOraMemoryLogFoler = mstrFilePath & strFolderMain
        Else
            strOraMemoryLogFoler = mstrFilePath & "\" & strFolderMain
        End If

        '================================================
        '̧�ق��폜
        '================================================
        Call DeleteFile(strOraMemoryLogFoler, TO_INTEGER(strFolderDeleteTimer))


        '*****************************************************
        '۸ޏo��
        '*****************************************************
        AddToLog("̧�ٍ폜���������B")


    End Sub
#End Region
#Region "  �׸ق���؏�Ԃ̏o�͏���(�ýē��L����)        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �׸ق���؏�Ԃ̏o�͏���(�ýē��L����)
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub MainProcess03()


        '**********************************************************************************
        'Confiģ�ُ��擾
        '**********************************************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MEMORY)        'Confiģ�ِڑ��׽����
        Dim strMaterialStreamMode As String                         '��رٽ�ذ�Ӱ�� �ýē��L�����������s����邩�ǂ������׸�
        Dim strFolderMain As String                                 '���۸ޗp̫��ޖ�
        Dim strFolderOra As String                                  '�׸����۸ޗp̫��ޖ�
        Dim strOraLogTimer As String                                '�׸����۸ނ��o�͂������                   (min)
        Dim strExcecProcess() As String                             '���s������۾����ϋ�؂�Ŏw��
        strMaterialStreamMode = TO_STRING(objConfig.GET_INFO("MaterialStreamMode"))
        strFolderMain = TO_STRING(objConfig.GET_INFO("FolderMain"))
        strFolderOra = TO_STRING(objConfig.GET_INFO("FolderOra"))
        strOraLogTimer = TO_STRING(objConfig.GET_INFO("OraLogTimer"))
        strExcecProcess = Split(TO_STRING(objConfig.GET_INFO("ExcecProcess")), ",")


        '*****************************************************
        '��ϰ����
        '*****************************************************
        Dim objDiff As TimeSpan = mdtmBeforeOraLogTime.AddMinutes(strOraLogTimer) - Now
        If 0 < objDiff.TotalMilliseconds Then
            Exit Sub
        End If
        mdtmBeforeOraLogTime = Now


        '**********************************************************************************
        '�F�X����
        '**********************************************************************************
        If TO_INTEGER(strMaterialStreamMode) = FLAG_OFF Then Exit Sub


        '**********************************************************************************
        '��۾����̎擾
        '**********************************************************************************
        For ii As Integer = 0 To strExcecProcess.Length - 1
            strExcecProcess(ii) = strExcecProcess(ii).Replace(vbCrLf, "")
            strExcecProcess(ii) = RTrim(strExcecProcess(ii))
            strExcecProcess(ii) = LTrim(strExcecProcess(ii))
        Next


        '*************************************************
        '��۾��̎��s
        '*************************************************
        For ii As Integer = 0 To strExcecProcess.Length - 1
            If IsNull(strExcecProcess(ii)) Then Continue For
            If mintDebugFlag <> FLAG_ON Then
                Call Shell(strExcecProcess(ii), AppWinStyle.Hide)
            Else
                Call Shell(strExcecProcess(ii), AppWinStyle.NormalFocus)
            End If
        Next


        '*****************************************************
        '۸ޏo��
        '*****************************************************
        AddToLog("�׸����۸ޏo�͊����B")


    End Sub
    ''''*******************************************************************************************************************
    '''' <summary>
    '''' �׸ق���؏�Ԃ̏o�͏���(�ýē��L����)
    '''' </summary>
    '''' <remarks></remarks>
    ''''*******************************************************************************************************************
    'Public Sub MainProcess02()


    '    '**********************************************************************************
    '    'Confiģ�ُ��擾
    '    '**********************************************************************************
    '    Dim objConfig As New clsConnectConfig(CONFIG_MEMORY)        'Confiģ�ِڑ��׽����
    '    Dim strMaterialStreamMode As String                         '��رٽ�ذ�Ӱ�� �ýē��L�����������s����邩�ǂ������׸�
    '    Dim strFolderTemp As String                                 '�׸����۸ޗp�ꎞ�ۊǗp̫���
    '    Dim strFolderName As String                                 '�׸����۸ޗp̫��ޖ�
    '    Dim strFolderDeleteTimer As String                          '�׸����۸ޗp̫��ނ��폜�������        (Day)
    '    Dim strFolderCopyWait As String                             '�׸����۸ޗp̫��ނ��߰����ҋ@����    (ms)  CSV̧�ق��쐬�����܂őҋ@
    '    Dim strExcecProcess() As String                             '���s������۾����ϋ�؂�Ŏw��
    '    strMaterialStreamMode = TO_STRING(objConfig.GET_INFO("MaterialStreamMode"))             
    '    strFolderTemp = TO_STRING(objConfig.GET_INFO("FolderTemp"))
    '    strFolderName = TO_STRING(objConfig.GET_INFO("FolderName"))
    '    strFolderDeleteTimer = TO_STRING(objConfig.GET_INFO("FolderDeleteTimer"))
    '    strFolderCopyWait = TO_STRING(objConfig.GET_INFO("FolderCopyWait"))
    '    strExcecProcess = TO_STRING(objConfig.GET_INFO("ExcecProcess")).Split(",")


    '    '**********************************************************************************
    '    '�F�X����
    '    '**********************************************************************************
    '    If TO_INTEGER(strMaterialStreamMode) = FLAG_OFF Then Exit Sub


    '    '**********************************************************************************
    '    '��۾����̎擾
    '    '**********************************************************************************
    '    For ii As Integer = 0 To strExcecProcess.Length - 1
    '        strExcecProcess(ii) = strExcecProcess(ii).Replace(vbCrLf, "")
    '        strExcecProcess(ii) = RTrim(strExcecProcess(ii))
    '        strExcecProcess(ii) = LTrim(strExcecProcess(ii))
    '    Next


    '    '**********************************************************************************
    '    '̫��ނ̍쐬
    '    '**********************************************************************************
    '    Call System.IO.Directory.CreateDirectory(strFolderTemp)          '̫��ލ쐬


    '    '*************************************************
    '    '�����������Ď��s
    '    '*************************************************
    '    For ii As Integer = 0 To strExcecProcess.Length - 1
    '        '(ٰ��:�����������Ď��s)

    '        Dim psi As New System.Diagnostics.ProcessStartInfo()
    '        psi.FileName = System.Environment.GetEnvironmentVariable("ComSpec")     'ComSpec�̃p�X���擾����
    '        psi.RedirectStandardInput = False           '�o�͂�ǂݎ���悤�ɂ���
    '        psi.RedirectStandardOutput = True           '�o�͂�ǂݎ���悤�ɂ���
    '        psi.UseShellExecute = False                 '�o�͂�ǂݎ���悤�ɂ���
    '        psi.CreateNoWindow = True                   '�E�B���h�E��\�����Ȃ��悤�ɂ���
    '        psi.Arguments = strExcecProcess(ii) '�R�}���h���C�����w��i"/c"�͎��s����邽�߂ɕK�v�j
    '        'psi.Arguments = "/c " & strExcecProcess(ii) '�R�}���h���C�����w��i"/c"�͎��s����邽�߂ɕK�v�j
    '        '�N��
    '        System.Diagnostics.Process.Start(psi)

    '    Next


    '    '**********************************************************************************
    '    '�쐬���ꂽcsv̧�ق��߰
    '    '**********************************************************************************
    '    '=======================================================
    '    'csv̧�ق��o����܂őҋ@
    '    '=======================================================
    '    Call Threading.Thread.Sleep(TO_INTEGER(strFolderCopyWait))

    '    '=======================================================
    '    '̫��ނ��쐬
    '    '=======================================================
    '    Dim strOraMemoryLogFoler As String
    '    If Right(mstrFilePath, 1) = "\" Then
    '        strOraMemoryLogFoler = mstrFilePath & strFolderName
    '    Else
    '        strOraMemoryLogFoler = mstrFilePath & "\" & strFolderName
    '    End If
    '    strOraMemoryLogFoler &= "\" & Format(Now, "yyyyMMddhhmmss")
    '    Call System.IO.Directory.CreateDirectory(strOraMemoryLogFoler)      '̫��ލ쐬

    '    '=======================================================
    '    '̫��ނ��߰
    '    '=======================================================
    '    Call My.Computer.FileSystem.CopyDirectory(strFolderTemp, strOraMemoryLogFoler)


    '    '**********************************************************************************
    '    '̫��ނ̍폜
    '    '**********************************************************************************
    '    '================================================
    '    '�F�X�ݒ�
    '    '================================================
    '    Dim dtmKigen As Date = Now.AddDays(-(TO_INTEGER(strFolderDeleteTimer)))

    '    '================================================
    '    '̧�ق��擾
    '    '================================================
    '    Dim objFiles As String() = System.IO.Directory.GetDirectories(strOraMemoryLogFoler _
    '                                                                , "*" _
    '                                                                , System.IO.SearchOption.TopDirectoryOnly _
    '                                                                )

    '    '================================================
    '    '̧�ق��폜
    '    '================================================
    '    For ii As Integer = 0 To UBound(objFiles)
    '        '(ٰ��:̫��ޓ���̧�ِ�)

    '        '�폜����
    '        Dim dtmFileTime As Date = System.IO.File.GetLastWriteTime(objFiles(ii))   '̧�ٍX�V�����擾
    '        If dtmFileTime <= dtmKigen Then
    '            '(�������߂����ꍇ)
    '            System.IO.File.Delete(objFiles(ii))      '�폜
    '        End If

    '    Next


    'End Sub
#End Region

#Region "  �ʐM�����            "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ʐM�����
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Open()
        'NOP
    End Sub
#End Region
#Region "  �ʐM�۰��            "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ʐM�۰��
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Close()
        'NOP
    End Sub
#End Region
#Region "  ���۸ޏo��           "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ���۸ޏo��
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddMemoryLog(ByVal strFileName As String _
                          , ByVal strMsg1 As String _
                          , Optional ByVal strMsg2 As String = "" _
                          , Optional ByVal strMsg3 As String = "" _
                          )


        '**********************************************************************************
        'Confiģ�ُ��擾
        '**********************************************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MEMORY)        'Confiģ�ِڑ��׽����
        Dim strFolderMain As String                                 '���۸ޗp̫��ޖ�
        strFolderMain = TO_STRING(objConfig.GET_INFO("FolderMain"))


        '******************************************************
        '۸ޏo���߽�̒���
        '******************************************************
        Dim strFilePathTemp As String
        '̧���߽        ���
        strFilePathTemp = mstrFilePath
        If Right(mstrFilePath, 1) <> "\" Then
            strFilePathTemp &= "\"
        End If
        '���۸ޗp̫��ޖ�
        strFilePathTemp &= strFolderMain
        If Right(mstrFilePath, 1) <> "\" Then
            strFilePathTemp &= "\"
        End If


        '******************************************************
        '۸ޏo��        �쐬
        '******************************************************
        Dim objLogWrite As clsWriteLog
        objLogWrite = New clsWriteLog
        objLogWrite.clspFileName = strFilePathTemp & strFileName & ".log"            '̧�ٖ�         ���
        objLogWrite.clspCopyFile = strFilePathTemp & strFileName & "_Old.log"        '̧�ٖ�(�Â�)   ���
        objLogWrite.clspMaxSize = mintMaxSize * 1000 * 1000                          '�ő�̧�ٻ���   ���    (Byte �� MByte)


        '******************************************************
        '۸ޏo��
        '******************************************************
        objLogWrite.WriteLog(strMsg1, strMsg2, strMsg3)              '۸ޏ���


    End Sub
#End Region
#Region "  ̫�ϯĂ𐮂��鏈��   "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ̫�ϯĂ𐮂��鏈��
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function FixTextMemory(ByVal strMemorySize As String) As String
        Dim strReturn As String


        '******************************************************
        '̫�ϯĂ𐮂���
        '******************************************************
        strReturn = strMemorySize
        strReturn = Format(TO_INTEGER(strReturn), "#,0")
        strReturn = SPC_PAD_RIGHT_SJIS(strReturn, 17)
        strReturn = strReturn & Space(3)


        Return strReturn
    End Function
#End Region


End Class
