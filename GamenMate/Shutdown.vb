'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�����޳ݏ���
' �y�쐬�zKSH
'**********************************************************************************************

Imports System
Imports System.Diagnostics
Imports System.Runtime.InteropServices

Public Class Shutdown

#Region "  ��`"

    <Flags()> _
Public Enum ShutdownFlag As Integer

        LogOff = &H0
        Shutdown = &H1
        Reboot = &H2
        Force = &H4
        PowerOff = &H8
        ForceIfHung = &H10

    End Enum

    <DllImport("user32.dll")> _
    Private Shared Function ExitWindowsEx _
        (ByVal flag As Integer, _
         ByVal reserved As Integer) _
         As Boolean
    End Function

    <StructLayout(LayoutKind.Sequential, Pack:=4)> _
    Private Structure LUID_AND_ATTRIBUTES

        Dim Luid As Long
        Dim Attributes As Integer

    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=4)> _
    Private Structure TOKEN_PRIVILEGES

        Dim PrivilegeCount As Integer
        Dim Privilege As LUID_AND_ATTRIBUTES

    End Structure

    <DllImport("advapi32.dll")> _
    Private Shared Function OpenProcessToken _
        (ByVal ProcessHandle As IntPtr, _
         ByVal DesiredAccess As Integer, _
         ByRef TokenHandle As IntPtr) _
        As Boolean
    End Function

    <DllImport("advapi32.dll")> _
    Private Shared Function LookupPrivilegeValue _
        (ByVal lpSystemName As String, _
         ByVal lpName As String, _
         ByRef lpLuid As Long) _
         As Boolean
    End Function

    <DllImport("advapi32.dll")> _
    Private Shared Function AdjustTokenPrivileges _
        (ByVal TokenHandle As IntPtr, _
         ByVal DisableAllPrivileges As Boolean, _
         ByRef NewState As TOKEN_PRIVILEGES, _
         ByVal BufferLength As Integer, _
         ByVal PreviousState As IntPtr, _
         ByVal ReturnLength As IntPtr) _
         As Boolean
    End Function

#End Region

#Region "  ExitWindowsEx�֐����Ăяo��"
    Public Shared Function ExitWindows(ByVal flags As ShutdownFlag) As Boolean

        Dim result As Boolean = False

        Try

            ' �V�X�e����NT�n�ł�������
            If Environment.OSVersion.Platform = PlatformID.Win32NT Then

                Dim flag As ShutdownFlag = flags

                flag = flag And Not Shutdown.ShutdownFlag.Force
                flag = flag And Not Shutdown.ShutdownFlag.ForceIfHung

                ' ���O�I�t�̂Ƃ��͓��������蓖�Ă�K�v�͂Ȃ�
                If flags <> ShutdownFlag.LogOff Then
                    ' �V���b�g�_�E�����������蓖�Ă�
                    SetShutdownPrivilege()
                End If

            Else

                ' NT�n�ȊO�ł�ForceIfHung�͖���
                flags = flags And Not Shutdown.ShutdownFlag.ForceIfHung

            End If

            ' ExitWindowsEx�֐����Ăяo��
            result = ExitWindowsEx(CInt(flags), 0)


        Catch ex As Exception
            result = False
            Throw ex
        End Try

        Return result

    End Function
#End Region

#Region "  ���݂̃v���Z�X�ɃV���b�g�_�E�����������蓖�Ă�"
    ' ���݂̃v���Z�X�ɃV���b�g�_�E�����������蓖�Ă�
    Private Shared Sub SetShutdownPrivilege()

        Try

            Const TOKEN_QUERY As Integer = &H8
            Const TOKEN_ADJUST_PRIVILEGES As Integer = &H20
            Const SE_SHUTDOWN_NAME As String = "SeShutdownPrivilege"
            Const SE_PRIVILEGE_ENABLED As Integer = &H2

            ' �v���Z�X�n���h�����擾����
            Dim hProc As IntPtr

            hProc = Process.GetCurrentProcess().Handle

            ' �g�[�N�����擾����
            Dim hToken As IntPtr = IntPtr.Zero

            If Not OpenProcessToken(hProc, TOKEN_ADJUST_PRIVILEGES Or TOKEN_QUERY, hToken) Then

                Throw New Exception("�g�[�N�����擾�ł��܂���ł����B")

            End If

            ' LUID���擾����
            Dim luid As Long = 0

            If Not LookupPrivilegeValue(Nothing, SE_SHUTDOWN_NAME, luid) Then

                Throw New Exception("LUID���擾�ł��܂���ł����B")

            End If

            ' SE_SHUTDOWN_NAME������ݒ肷��
            Dim tp As New TOKEN_PRIVILEGES

            tp.PrivilegeCount = 1
            tp.Privilege = New LUID_AND_ATTRIBUTES
            tp.Privilege.Luid = luid
            tp.Privilege.Attributes = SE_PRIVILEGE_ENABLED

            If Not AdjustTokenPrivileges(hToken, False, tp, 0, IntPtr.Zero, IntPtr.Zero) Then

                Throw New Exception("SE_SHUTDOWN_NAME������ݒ�ł��܂���ł����B")

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


End Class
