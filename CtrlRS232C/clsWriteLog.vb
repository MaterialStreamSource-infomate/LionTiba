'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' �y���́z���P���
' �y�@�\�z۸ޏo��
' �y�쐬�z2005/10/03�@KSH�@        Rev 0.00�@����(���p)
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.IO
#End Region

Public Class clsWriteLog

#Region "  ���ʒ萔���ϐ�"
    '------------------------------------------------------------------------
    '�萔�錾
    '------------------------------------------------------------------------
    Private Const FOMT_DATE_TIME As String = "yyyy/MM/dd HH:mm:ss"
    Private strDate As String      ' ���t
    Private strC1 As String
    Private strTime As String      ' ����
    Private strC2 As String
    Private strProg As String      ' ��۸��і�
    Private strC3 As String
    Private strFunc As String      ' �֐���
    Private strC4 As String
    Private strMsg As String       ' ү����


    Private strCRLF As String
    '------------------------------------------------------------------------
    ' �����ϐ�
    '------------------------------------------------------------------------
    Private mstrFileName As String
    Private mstrCopyName As String
    Private mlngMaxSize As Long
#End Region

#Region "  �����è��`"
    '------------------------------------------------------------------------
    ' clspFilePath �v���p�e�B
    '------------------------------------------------------------------------
    Public Property clspFileName( _
    ) As String
        Get
            Return (mstrFileName)
        End Get
        Set(ByVal Value As String)
            mstrFileName = Value
        End Set
    End Property

    '------------------------------------------------------------------------
    ' clspCopyFile �v���p�e�B
    '------------------------------------------------------------------------
    Public Property clspCopyFile( _
    ) As String
        Get
            Return (mstrCopyName)
        End Get
        Set(ByVal Value As String)
            mstrCopyName = Value
        End Set
    End Property

    '------------------------------------------------------------------------
    ' clspMaxSize �v���p�e�B
    '------------------------------------------------------------------------
    Public Property clspMaxSize( _
    ) As Long
        Get
            Return (mlngMaxSize)
        End Get
        Set(ByVal Value As Long)
            mlngMaxSize = Value
        End Set
    End Property
#End Region

#Region "  ۸�̧�ُ�����            (Public  clsmWriteLog)"
    Public Sub WriteLog(ByVal strMsg_1 As String, _
                             Optional ByVal strMsg_2 As String = "", _
                             Optional ByVal strMsg_3 As String = "")

        Try
            Dim fi As FileInfo
            Dim strWriteBuf As String
            Dim writer As StreamWriter

            ' ���O���̊i�[
            strDate = Format(Now, "yyyy/MM/dd")
            strTime = Format(Now, "HH:mm:ss.ffff")
            strWriteBuf = ""
            strWriteBuf = strWriteBuf & strDate
            strWriteBuf = strWriteBuf & ","
            strWriteBuf = strWriteBuf & strTime
            strWriteBuf = strWriteBuf & ","
            strWriteBuf = strWriteBuf & strMsg_2
            strWriteBuf = strWriteBuf & ","
            strWriteBuf = strWriteBuf & strMsg_3
            strWriteBuf = strWriteBuf & ","
            strWriteBuf = strWriteBuf & strMsg_1
            strWriteBuf = strWriteBuf & Chr(13) & Chr(10)
            '---------------------------------------------------------
            ' �t�@�C���̗e�ʃ`�F�b�N
            '---------------------------------------------------------
            fi = New FileInfo(mstrFileName)
            If fi.Exists = True Then
                '�t�@�C�������݂���ꍇ
                If fi.Length >= mlngMaxSize Then
                    '�t�@�C�����R�s�[
                    fi.CopyTo(mstrCopyName, True)
                    '�f�[�^���㏑��
                    '' ''writer = New StreamWriter(mstrFileName, False)
                    writer = New StreamWriter(mstrFileName, False, System.Text.Encoding.GetEncoding(932))   'shift_jis �ŏo��
                Else
                    '�f�[�^��ǉ�
                    '' ''writer = New StreamWriter(mstrFileName, True)
                    writer = New StreamWriter(mstrFileName, True, System.Text.Encoding.GetEncoding(932))    'shift_jis �ŏo��
                End If
            Else
                '�t�@�C�������݂��Ȃ��ꍇ
                '' ''writer = New StreamWriter(mstrFileName, False)
                writer = New StreamWriter(mstrFileName, False, System.Text.Encoding.GetEncoding(932))       'shift_jis �ŏo��
            End If
            writer.Write(strWriteBuf)
            writer.Flush()
            writer.Close()
            writer = Nothing

        Catch ex As Exception
            '�������Ȃ�

        End Try
    End Sub
#End Region

End Class

