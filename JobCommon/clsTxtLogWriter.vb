'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
' �y�@�\�z÷��۸޸׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�C���|�[�g�̐錾"
Imports System.IO
Imports System.Threading
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Text
#End Region

'===============================================================================
'�y�@�\�z    LogWriter : ���O�t�@�C���Ǘ��N���X
'===============================================================================
Public Class clsLogWriter
    Implements IDisposable

#Region "�񋓑�"
#End Region

#Region "�萔"
    Private Const LOG_EXTENSION As String = ".Log"  '���O�t�@�C���g���q
#End Region

#Region "�t�B�[���h"
    '----- Class Level Shared
    Private Shared mLogInstns As New Collection     ' LogWriter �N���X�I�u�W�F�N�g �R���N�V����

    '----- Class Level Valiables (Private)
    ' Local Valiables
    Private MsgQueue As Queue      ' ���OQueue
    Private ThreadObj As Thread    ' ���O�X���b�h

    Private mblnDisposedFlg As Boolean = False          ' Dispose�t���O
    Private mstrLogDateFormat As String                 ' �t�@�C���t�H�[�}�b�g(Ex."yyyyMMdd")
    Private mblnEndFlg As Boolean = False               ' �I���t���O

    ' Config Value
    Private mstrLogPath As String                       ' ���O�t�@�C���o�̓p�X
    Private mstrLogFileName As String                   ' ���O�t�@�C����
    Private mintLogDeleteDay As Integer                 ' ���O�ێ�����
    Private mintLogFileSize As Integer                  ' ���O�t�@�C��Max�T�C�Y[M Byte]

#End Region

#Region "�C���X�^���X����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �C���X�^���X����(�e�|�[�g�Ɉ�̃C���X�^���X����)
    ''' </summary>
    ''' <param name="strLogPath">۸�̧�ُo���߽</param>
    ''' <param name="strLogFileName">۸�̧�ٖ�</param>
    ''' <param name="intLogDeleteDay">۸ޕێ�����[�ȗ���]���񎞂̂ݎw��</param>
    ''' <param name="intLogFileSize">۸�̧��Max����[�ȗ���]���񎞂̂ݎw��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Shared Function GetInstance(ByVal strLogPath As String, ByVal strLogFileName As String, _
                                       Optional ByVal intLogDeleteDay As Integer = 0, _
                                       Optional ByVal intLogFileSize As Integer = 0) As clsLogWriter
        Dim LogWriterObj As clsLogWriter = Nothing          ' LogWriter�N���X�I�u�W�F�N�g

        Try
            LogWriterObj = CType(mLogInstns.Item(strLogPath & strLogFileName), clsLogWriter)
        Catch
        End Try
        If LogWriterObj Is Nothing Then
            SyncLock GetType(clsLogWriter)
                If LogWriterObj Is Nothing Then
                    LogWriterObj = New clsLogWriter(strLogPath, strLogFileName, intLogDeleteDay, intLogFileSize)
                    mLogInstns.Add(LogWriterObj, strLogPath & strLogFileName)
                End If
            End SyncLock
        End If
        LogWriterObj = Nothing
        Return mLogInstns.Item(strLogPath & strLogFileName)

    End Function
#End Region

#Region "�R���X�g���N�^"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �R���X�g���N�^
    ''' </summary>
    ''' <param name="strLogPath">۸�̧�ُo���߽</param>
    ''' <param name="strLogFileName">۸�̧�ٖ�</param>
    ''' <param name="intLogDeleteDay">۸ޕێ�����</param>
    ''' <param name="intLogFileSize">۸�̧��Max����</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub New(ByVal strLogPath As String, ByVal strLogFileName As String, ByVal intLogDeleteDay As Integer, ByVal intLogFileSize As Integer)

        '-------------------------------
        ' ���O�p�X
        '-------------------------------
        Me.mstrLogPath = strLogPath
        ' �w��̃p�X�����݂��Ȃ���΍쐬���A�쐬�s�Ȃ�A�v���P�[�V�������s�t�H���_
        If Directory.Exists(Me.mstrLogPath) = False Then
            Try
                Directory.CreateDirectory(Me.mstrLogPath)
            Catch ex As Exception
                Me.mstrLogPath = Application.StartupPath
            End Try
        End If
        If Right(Me.mstrLogPath, 1) <> "\" Then Me.mstrLogPath &= "\"

        '-------------------------------
        ' ���O�ێ�����[��]
        '-------------------------------
        Me.mintLogDeleteDay = intLogDeleteDay

        '-------------------------------
        ' ���O�t�@�C��Max�T�C�Y[M Byte]
        '-------------------------------
        Me.mintLogFileSize = intLogFileSize

        '-------------------------------
        ' ���O�t�@�C����
        '-------------------------------
        Me.mstrLogFileName = strLogFileName

        '---------------------------------
        ' �t�@�C���t�H�[�}�b�g
        '---------------------------------
        Me.mstrLogDateFormat = "yyyyMMdd"

        '---------------------------------
        ' �L���[�I�u�W�F�N�g����
        '---------------------------------
        Me.MsgQueue = Queue.Synchronized(New Queue)

        '---------------------------------
        ' ���O�X���b�h�̗��グ
        '---------------------------------
        Me.ThreadObj = New Thread(New ThreadStart(AddressOf Me.WriteTxtLogThread))
        Me.ThreadObj.Start()

    End Sub
#End Region

#Region "�f�X�g���N�^"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �f�X�g���N�^
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �I�u�W�F�N�g���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �I�u�W�F�N�g���
    ''' </summary>
    ''' <param name="Disposing"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Overloads Sub Dispose(ByVal Disposing As Boolean)
        Dim iLoop As Integer
        Dim strNowFileName As String       ' ���t�@�C����
        Dim strNewFileName As String       ' �ύX�t�@�C����
        Dim intNowDateTime As String       ' ���ݓ���

        ' Dispose���s��ꂽ���ǂ����𔻒�
        If Not (Me.mblnDisposedFlg) Then
            ' Dispose�t���OON
            Me.mblnDisposedFlg = True

            If mLogInstns.Count > 0 Then

                ' �I���t���OON
                Me.mblnEndFlg = True

                ' ���ݓ����擾
                intNowDateTime = Format(Now, Me.mstrLogDateFormat)

                Try
                    '------------------------------
                    ' ���[�v���̃X���b�h���Ƃ߂�
                    '------------------------------
                    SyncLock (Me.MsgQueue)
                        Monitor.Pulse(Me.MsgQueue)
                    End SyncLock

                    '-------------------------------------
                    ' ���[�v���̃X���b�h���I������܂ł܂�
                    '-------------------------------------
                    Me.ThreadObj.Join()

                    '------------------------------
                    ' �I�u�W�F�N�g�j��
                    '------------------------------
                    Me.MsgQueue = Nothing

                    '------------------------------
                    ' �X���b�h�j��
                    '------------------------------
                    Me.ThreadObj = Nothing

                    '---------------------------------------
                    ' �t�@�C�����ύX
                    '---------------------------------------
                    ' ���t�@�C����
                    strNowFileName = Me.mstrLogPath & Me.mstrLogFileName & LOG_EXTENSION
                    ' ���t�@�C���������
                    If Dir(strNowFileName) <> "" Then
                        Try
                            ' �ύX�t�@�C�����擾
                            strNewFileName = Me.mstrLogPath & Me.mstrLogFileName & "_" & intNowDateTime & LOG_EXTENSION
                            ' �t�@�C�����X�V
                            FileNameChange(strNowFileName, strNewFileName)
                        Catch ex As Exception
                        End Try
                    End If

                Catch
                End Try

                '------------------------------
                ' �Â����O�t�@�C���̐��� 
                '------------------------------
                Me.LogCleanRenameFile()

                '------------------------------
                ' �R���N�V�������玩�u�W�F�N�g�j��
                '------------------------------
                For iLoop = 1 To mLogInstns.Count
                    If CType(mLogInstns.Item(iLoop), clsLogWriter) Is Me Then
                        mLogInstns.Remove(iLoop)
                        Exit For
                    End If
                Next iLoop
            End If

        End If
    End Sub

#End Region

#Region "SetQueue"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �L���[�Ƀf�[�^���i�[����
    ''' </summary>
    ''' <param name="MsgQueue">�L���[�I�u�W�F�N�g�ւ̎Q��</param>
    ''' <param name="obj">�L���[�Ɋi�[����f�[�^</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetQueue(ByVal MsgQueue As Queue, ByVal obj As Object)
        SyncLock (MsgQueue)
            ' ����������b�Z�[�W���L���[�C���O
            MsgQueue.Enqueue(obj)

            ' Lock�J���ʒm
            Monitor.Pulse(MsgQueue)
        End SyncLock
    End Sub
#End Region

#Region "GetQueue"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �L���[����f�[�^�����o��
    ''' </summary>
    ''' <param name="MsgQueue">�L���[�I�u�W�F�N�g�ւ̎Q��</param>
    ''' <returns>�L���[������o�����f�[�^</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function GetQueue(ByVal MsgQueue As Queue) As Object
        Try
            SyncLock (MsgQueue)

                ' �I���t���O��OFF�ŃL���[�ɉ���������� Wait ����
                If Me.mblnEndFlg = False And MsgQueue.Count <= 0 Then
                    ' Wait
                    Monitor.Wait(MsgQueue)
                End If

                ' �I���t���O��ON�ŃL���[�ɉ���������� �X���b�h�I��
                If Me.mblnEndFlg = True And MsgQueue.Count <= 0 Then
                    Thread.CurrentThread.Abort()
                End If

                ' Lock�J���ʒm
                Monitor.Pulse(MsgQueue)

                ' �L���[�̒��g��Ԃ�
                Return MsgQueue.Dequeue

            End SyncLock

            Return MsgQueue.Dequeue

        Catch ex As ThreadAbortException
            ' �X���b�h�̏I��
            Throw ex
        Catch ex As Exception
            Try
                MsgQueue.Dequeue()
            Catch
            End Try
            Throw ex
        End Try

    End Function
#End Region

#Region "���O���t�@�C���ɏo�͂��鏈��"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���O�f�[�^�\����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Structure LogDataTrace
        Friend DateTime As DateTime         ' ����
        Friend strMessage As String            ' ���b�Z�[�W
    End Structure
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���O���t�@�C���ɏo��
    ''' </summary>
    ''' <param name="strMessage">���b�Z�[�W</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub WriteTxtLog(ByVal strMessage As String)
        Dim intTraceLogData As LogDataTrace    ' ���O�f�[�^

        Try
            'Queue�I�u�W�F�N�g�ɒǉ�����f�[�^�쐬
            With intTraceLogData
                .DateTime = Now             ' ���ݓ���
                .strMessage = strMessage          ' ���b�Z�[�W
            End With

            ' Queue�I�u�W�F�N�g�Ƀ��O���e�ǉ�
            Me.SetQueue(Me.MsgQueue, intTraceLogData)

        Catch ex As Exception
        End Try
    End Sub

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���O���t�@�C���ɏo��(�I�[�o�[���[�h)
    ''' </summary>
    ''' <param name="strMessage">���b�Z�[�W</param>
    ''' <param name="txtObject"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub WriteTxtLog(ByVal strMessage As String, ByRef txtObject As TextBox)
        Dim intTraceLogData As LogDataTrace    ' ���O�f�[�^

        Try

            'Queue�I�u�W�F�N�g�ɒǉ�����f�[�^�쐬
            With intTraceLogData
                .DateTime = Now             ' ���ݓ���
                .strMessage = strMessage          ' ���b�Z�[�W
                txtObject.Text += Format(.DateTime, "yyyy/MM/dd HH:mm:ss[fff]") & " " & .strMessage & vbCrLf
            End With

            ' Queue�I�u�W�F�N�g�Ƀ��O���e�ǉ�
            Me.SetQueue(Me.MsgQueue, intTraceLogData)

        Catch ex As Exception
        End Try
    End Sub
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���O�o�̓X���b�h
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub WriteTxtLogThread()
        Dim intTraceLogData As LogDataTrace        ' ���샍�O�f�[�^
        Dim WriteMsg As StringBuilder           ' �������݃��b�Z�[�W
        Dim strMsgTime As String                   ' �^�C���X�^���v
        Dim strWriteFile As String                 ' �������݃t�@�C����

        While (True)
            Try
                ' �L���[����f�[�^�����o��
                intTraceLogData = CType(Me.GetQueue(Me.MsgQueue), LogDataTrace)

                ' �������݃f�[�^�쐬
                WriteMsg = New StringBuilder
                With intTraceLogData
                    strMsgTime = Format(.DateTime, "yyyy/MM/dd HH:mm:ss[fff]")
                    WriteMsg.Append(strMsgTime & " " & .strMessage & vbCrLf)
                End With
                'Debug.WriteLine(strWriteMsg)

                ' �t�H���_�������
                If Directory.Exists(Me.mstrLogPath) Then

                    '----------------------------------
                    ' �t�@�C����������
                    '----------------------------------
                    strWriteFile = Me.mstrLogPath & Me.mstrLogFileName & LOG_EXTENSION
                    WriteFile_Normal(strWriteFile, WriteMsg)

                    '----------------------------------
                    ' ���O�t�@�C���̈��k����
                    '----------------------------------
                    Me.Log_Pack_Check()
                End If
                WriteMsg = Nothing

            Catch ex As ThreadAbortException
                ' �X���b�h�̏I��
            Catch ex As Exception
            End Try
        End While
    End Sub
#End Region

#Region "�t�@�C���������ݏ���"


    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �t�@�C����������
    ''' </summary>
    ''' <param name="strWriteFile">���O�t�@�C����</param>
    ''' <param name="WriteMsg">�������݃��b�Z�[�W</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub WriteFile_Normal(ByVal strWriteFile As String, _
                                 ByVal WriteMsg As StringBuilder)
        Dim fs As FileStream                    ' FileStream�I�u�W�F�N�g
        Dim SwFromFileStream As StreamWriter    ' StreamWriter�I�u�W�F�N�g

        ' �t�@�C����������
        fs = New FileStream(strWriteFile, FileMode.Append, FileAccess.Write)
        Try
            SwFromFileStream = New StreamWriter(fs, System.Text.Encoding.Default)
            Try
                SwFromFileStream.Write(WriteMsg.ToString)
                SwFromFileStream.Flush()
            Finally
                SwFromFileStream.Close()
            End Try
        Finally
            fs.Close()
        End Try

    End Sub

#End Region

#Region "���O�t�@�C���̈��k����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���O�t�@�C���̈��k����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Log_Pack_Check()
        Dim strOldFileName As String        ' ���t�@�C����
        Dim strNewFileName As String        ' �ύX�t�@�C����

        ' ���t�@�C����
        strOldFileName = Me.mstrLogPath & Me.mstrLogFileName & LOG_EXTENSION

        ' ���t�@�C�����Ȃ���Ώ����I��
        If File.Exists(strOldFileName) = False Then Return

        ' Max�t�@�C���T�C�Y�𒴂�����t�@�C����������
        If FileLen(strOldFileName) >= (Me.mintLogFileSize * (1024 ^ 2)) Then
            Try
                ' ���k��̃t�@�C�����擾
                strNewFileName = Me.mstrLogPath & Me.mstrLogFileName & "_" & Format(Now, Me.mstrLogDateFormat) & LOG_EXTENSION
                ' �t�@�C�����X�V
                FileNameChange(strOldFileName, strNewFileName)

                ' �Â����O�t�@�C���̐��� 
                Me.LogCleanRenameFile()
            Catch ex As Exception
                'Debug.WriteLine(Format(Now, "yyyy/MM/dd HH:mm:ss") & " [E] [Log_Pack_Check] Dsc:" & ex.Message)
            End Try
        End If

    End Sub

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �t�@�C�����X�V
    ''' </summary>
    ''' <param name="strOldFileName">�ύX�O�t�@�C����</param>
    ''' <param name="CheckFile">�`�F�b�N�t�@�C��(�ύX��t�@�C����)</param>
    ''' <remarks>����t�@�C���������݂��邩�ǂ����`�F�b�N���A���݂���΃t�@�C�������J�E���g�A�b�v����</remarks>
    ''' *******************************************************************************************************************
    Private Sub FileNameChange(ByVal strOldFileName As String, _
                               ByVal CheckFile As String)
        Dim strNonExtFileName As String     ' �g���q�Ȃ��t�@�C����
        Dim strNewFileName As String        ' �ύX�t�@�C����
        Dim intSameFileCnt As Integer       ' ����t�@�C��������

        ' �g���q�Ȃ��t�@�C�����擾
        strNonExtFileName = Path.GetFileNameWithoutExtension(CheckFile)

        If File.Exists(CheckFile) = True Then
            '---------------------------------
            ' �t�@�C�������݂����
            '---------------------------------
            ' ���ʂȂ��t�@�C�����u(1)�v�t���t�@�C�����ɂ���
            File.Move(CheckFile, Me.mstrLogPath & strNonExtFileName & "(1)" & LOG_EXTENSION)
            ' �t�@�C�����̌��Ɋ��ʂŃJ�E���g�A�b�v�����ԍ���t����
            strNewFileName = Me.mstrLogPath & strNonExtFileName & "(2)" & LOG_EXTENSION

        ElseIf File.Exists(Me.mstrLogPath & strNonExtFileName & "(1)" & LOG_EXTENSION) = True Then
            '---------------------------------
            ' ���ʕt���̃t�@�C�������݂����
            '---------------------------------
            intSameFileCnt = Directory.GetFiles(Me.mstrLogPath, strNonExtFileName & "(*)" & LOG_EXTENSION).Length + 1
            strNewFileName = Me.mstrLogPath & strNonExtFileName & "(" & intSameFileCnt.ToString & ")" & LOG_EXTENSION
        Else
            '---------------------------------
            ' �t�@�C�������݂��Ȃ����
            '---------------------------------
            strNewFileName = CheckFile
        End If

        ' �t�@�C�����X�V
        File.Move(strOldFileName, strNewFileName)

    End Sub

#End Region

#Region "�Â����O�t�@�C���̐���"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �Â����O�t�@�C���̐���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LogCleanRenameFile()
        Dim PreserveDtm As DateTime             ' �ێ�����
        Dim strFileName As String                  ' �폜�Ώۃt�@�C��
        'Dim FileDate As DateTime                ' �t�@�C������
        Dim strFileDate As String                  ' �t�@�C������
        Dim intPointa As Integer

        Try
            ' ���O�t�H���_�̑��݃`�F�b�N
            If Directory.Exists(Me.mstrLogPath) = False Then Return

            '' ���O�t�H���_�̃T�C�Y�`�F�b�N
            'If Me.GetFolderSize(Me.mstrLogPath) > (Me.LogDirMazSize * (1024 ^ 2)) Then

            '---------------------------------
            ' �ێ����ԈȑO�̃t�@�C�����폜
            '---------------------------------
            PreserveDtm = DateAdd(DateInterval.Day, Me.mintLogDeleteDay * -1, Now)

            For Each strFileName In Directory.GetFiles(Me.mstrLogPath, "*" & LOG_EXTENSION)
                ''------------------------------
                '' �����̓^�C���X�^���v�ɂĔ��f
                ''------------------------------
                '' �t�@�C���̃^�C���X�^���v���擾
                'strFileDate = File.GetLastWriteTime(strFileName)
                '' ���O�ۑ����Ԃ��߂����t�@�C��(���Ŕ�r)�폜
                'If DateDiff(DateInterval.Minute, PreserveDtm, strFileDate) < 0 Then
                '    File.Delete(strFileName)
                'End If

                '------------------------------
                ' �����̓t�@�C�����ɂĔ��f
                '------------------------------
                ' �t�@�C�����̂���X�V�������擾����()
                ' Rename���ꂽ���O�t�@�C��[PreFix_YYYYMMDD.log] -> [YYYY/MM/DD]
                strFileName = Path.GetFileName(strFileName)
                intPointa = strFileName.IndexOf("_")
                If intPointa >= 0 Then
                    strFileDate = strFileName.Substring(intPointa + 1, 4) & "/" & _
                               strFileName.Substring(intPointa + 5, 2) & "/" & _
                               strFileName.Substring(intPointa + 7, 2) & " "
                    If IsDate(strFileDate) Then
                        ' ���O�ۑ����Ԃ��߂����t�@�C��(���Ŕ�r)
                        If DateDiff(DateInterval.Minute, PreserveDtm, CDate(strFileDate)) < 0 Then
                            File.Delete(Me.mstrLogPath & strFileName)
                        End If
                    End If
                End If
            Next
            'End If
        Catch ex As Exception
            'Debug.WriteLine(Format(Now, "yyyy/MM/dd HH:mm:ss") & " [E] [LogCleanRenameFile] Dsc:" & ex.Message)
        End Try
    End Sub
#End Region

#Region "�t�H���_�̃T�C�Y�擾"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �t�H���_�̃T�C�Y�擾
    ''' </summary>
    ''' <param name="FolderName">�t�H���_��(�t���p�X)</param>
    ''' <returns>�t�H���_�̃T�C�Y[Byte] (-1 = �����G���[)</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function GetFolderSize(ByVal FolderName As String) As Long
        Dim objFs As Object
        Dim objFolder As Object
        Dim lngFolderSize As Long = 0      ' �t�H���_�T�C�Y[Byte]

        Try
            ' �t�H���_�̃T�C�Y�擾
            objFs = CreateObject("Scripting.FileSystemobject")
            objFolder = objFs.GetFolder(FolderName)
            lngFolderSize = objFolder.Size
        Catch ex As Exception
            lngFolderSize = -1
            'Debug.WriteLine(Format(Now, "yyyy/MM/dd HH:mm:ss") & " [E] [GetlngFolderSize] Dsc:" & ex.Message)
        Finally
            objFolder = Nothing
            objFs = Nothing
        End Try
        Return lngFolderSize
    End Function

#End Region

End Class
