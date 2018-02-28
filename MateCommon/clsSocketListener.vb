'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z����ؽŰ�׽
' �y�쐬�zSIT
'**********************************************************************************************

Imports MateCommon.clsConst
Imports MateCommon
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class clsSocketListener

#Region "  ���ʕϐ��A���ʒ萔"

    '***********************************************************************************************
    '���ʕϐ�
    '***********************************************************************************************
    '�����è�ϐ�
    Private mobjOwner As Object                 '��Ű��޼ު��
    Private mintPortNo As Integer               '��M���߰�No
    Private mstrSendText As String              '���M÷��
    Private mstrRecvText As String              '��M÷��
    Private mbytSendText() As Byte              '���M�޲Ĕz��
    Private mbytRecvText() As Byte              '��M�޲Ĕz��
    Private mintRET As RetCode                  '��������
    Private mintBackLog As Integer              '�ۗ����̐ڑ��̷���̍ő咷
    Private mudtConnection As Connection_Status '�ڑ�����Ă��邩�ǂ����̽ð��
    Private mintCodePage As Integer             '�ʐM�Ɏg�p����÷�Ă̺���
    Private mintDebugFlag As Integer            '���ޯ���׸�

    '����
    Private mobjSocket As Socket                '�펞�ҋ@�p���ĵ�޼ު��
    Private mobjConnSocket As Socket            '�V�����쐬���ꂽ�ڑ��ɑ΂��ĐV���� Socket ���쐬


    '***********************************************************************************************
    '���ʒ萔
    '***********************************************************************************************
    Private Const LOGFILE_NAME_DEFAULT As String = "clsSocketRecv.log"              '�w��̫�āx۸�̧�ٖ�
    Private Const LOGFILE_NAME_OLD_DEFAULT As String = "clsSocketRecv_OLD.log"      '�w��̫�āx۸�̧�ٖ�_OLD
    Private Const LOGFILE_SIZE_DEFAULT As Integer = 5000000                         '�w��̫�āx۸�̧�ٻ���
    Private Const BACKLOG_DEFAULT As Integer = 100                                  '�w��̫�āx�ۗ����̐ڑ��̷���̍ő咷
    Private Const TIMEOUT_DEFAULT As Integer = 5000                                 '�w��̫�āx��ѱ�Ď��ԁims�j

    '�񋓑�
    Public Enum RetCode
        OK = 1                      '����I��
        NG = 2                      '��۸��я�ł̴װ
        ReceiveTimeOut = 3          '��ѱ��
        ConnectError = 4            '�ڑ��װ
        PropertyError = 5           '�����è�װ
        RecvConnNothing = 6         '�ڑ����ĂȂ�
        RecvDataNothing = 7         '��M�ޯ̧�Ȃ�
        RecvConnNew = 8             '���Đڑ�������
    End Enum

    Public Enum Connection_Status
        YES = 1                     '�ڑ�����Ă���
        NO = 2                      '�ڑ�����Ă��Ȃ�
    End Enum

#End Region

#Region "  �����è"

    ''' =======================================
    ''' <summary>��M���߰�Noc</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intPortNo() As Integer
        Get
            Return mintPortNo
        End Get
        Set(ByVal Value As Integer)
            mintPortNo = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>���M÷��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strSendText() As String
        Get
            Return mstrSendText
        End Get
        Set(ByVal Value As String)
            mstrSendText = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>��M÷��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strRecvText() As String
        Get
            Return mstrRecvText
        End Get
        '''''Set(ByVal Value As String)
        '''''    mstrRECV_TEXT = Value
        '''''End Set
    End Property

    ''' =======================================
    ''' <summary>���M�޲Ĕz��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property bytSendText() As Byte()
        Get
            Return mbytSendText
        End Get
        Set(ByVal Value As Byte())
            mbytSendText = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>��M�޲Ĕz��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property bytRecvText() As Byte()
        Get
            Return mbytRecvText
        End Get
        '''''Set(ByVal Value As String)
        '''''    mstrRECV_TEXT = Value
        '''''End Set
    End Property

    ''' =======================================
    ''' <summary>��������</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property udtRET() As RetCode
        Get
            Return mintRET
        End Get
        ''Set(ByVal Value As RetCode)
        ''    mintRET = Value
        ''End Set
    End Property

    '' '' ''Public Property strLogFileName() As String
    '' '' ''    Get
    '' '' ''        Return mstrLOGFILE_NAME
    '' '' ''    End Get
    '' '' ''    Set(ByVal Value As String)
    '' '' ''        mstrLOGFILE_NAME = Value
    '' '' ''    End Set
    '' '' ''End Property

    '' '' ''Public Property strLogFileNameOld() As String
    '' '' ''    Get
    '' '' ''        Return mstrLOGFILE_NAME_OLD
    '' '' ''    End Get
    '' '' ''    Set(ByVal Value As String)
    '' '' ''        mstrLOGFILE_NAME_OLD = Value
    '' '' ''    End Set
    '' '' ''End Property

    '' '' ''Public Property intLogFileSize() As Integer
    '' '' ''    Get
    '' '' ''        Return mintLOGFILE_SIZE
    '' '' ''    End Get
    '' '' ''    Set(ByVal Value As Integer)
    '' '' ''        mintLOGFILE_SIZE = Value
    '' '' ''    End Set
    '' '' ''End Property

    ''' =======================================
    ''' <summary>�ۗ����̐ڑ��̷���̍ő咷</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intBackLog() As Integer
        Get
            Return mintBackLog
        End Get
        Set(ByVal Value As Integer)
            mintBackLog = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>�ڑ�����Ă��邩�ǂ����̽ð��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property udtConnection() As Connection_Status
        Get
            Return mudtConnection
        End Get
        Set(ByVal Value As Connection_Status)
            mudtConnection = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>�ʐM�Ɏg�p����÷�Ă̺���</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intCodePage() As Integer
        Get
            Return mintCodePage
        End Get
        Set(ByVal Value As Integer)
            mintCodePage = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>���ޯ���׸�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intDebugFlag() As Integer
        Get
            Return mintDebugFlag
        End Get
        Set(ByVal Value As Integer)
            mintDebugFlag = Value
        End Set
    End Property

#End Region

#Region "  �ݽ�׸�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ݽ�׸�
    ''' </summary>
    ''' <param name="objOwner"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object)

        ''MyBase.New()

        Try

            '***************************************
            ' �F�X������
            '***************************************
            mintPortNo = -1            '���M���߰�No
            mstrSendText = ""          '���M÷��
            mbytSendText = Nothing     '���M�޲Ĕz��
            mbytRecvText = Nothing     '��M�޲Ĕz��
            mintRET = RetCode.OK                                '��������
            mintBackLog = BACKLOG_DEFAULT                       '�ۗ����̐ڑ��̷���̍ő咷
            mudtConnection = Connection_Status.NO               '�ڑ�����Ă��邩�ǂ����̽ð��
            mobjOwner = objOwner                                '��Ű��޼ު��


            mintRET = RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region

#Region "  �ҋ@�@�@                             ����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ҋ@�@����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Listen()
        Try

            '*************************************************
            '�����è����
            '*************************************************
            If mintPortNo = -1 Then
                mintRET = RetCode.PropertyError
                Throw New Exception("�����è�װ")

            End If


            '*************************************************
            'EndPoint�擾
            '*************************************************
            Dim localEndPoint As IPEndPoint                                 'IP���ڽ�APORT �ݒ�
            localEndPoint = New IPEndPoint(IPAddress.Any, _
                                           mintPortNo)


            '*************************************************
            ' ��M�p���ĵ�޼ު��        ����
            '*************************************************
            mobjSocket = New Socket(AddressFamily.InterNetwork, _
                                    SocketType.Stream, _
                                    ProtocolType.Tcp)                   'TCP/IP socket ������
            mobjSocket.Bind(localEndPoint)                              '�����߲�ĂƊ֘A�t
            mobjSocket.Listen(Val(mintBackLog))                         '�ۗ����̐ڑ��̷���̍ő咷


            '*************************************************
            ' ۸ޏo��
            '*************************************************
            Call AddToLog("ؽŰ�߰Ă��J�݂��܂���   �߰�No:" & mintPortNo)


            mintRET = RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region

#Region "  �ؒf�@�@                             ����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ؒf�@����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Shutdown()
        Try

            '*************************************************
            '�ؒf
            '*************************************************
            '===================================
            '�펞�ҋ@�p���ĵ�޼ު��
            '===================================
            If IsNothing(mobjSocket) = False Then
                '''''mobjSocket.Shutdown(SocketShutdown.Receive)
                mobjSocket.Close()
            End If

            '===================================================
            '�V�����쐬���ꂽ�ڑ��ɑ΂��ĐV���� Socket ���쐬
            '===================================================
            If IsNothing(mobjConnSocket) = False Then
                mobjConnSocket.Shutdown(SocketShutdown.Receive)
                mobjConnSocket.Close()
            End If

            mobjSocket = Nothing
            mobjConnSocket = Nothing


            '*************************************************
            ' �ڑ��׸� = ��
            '*************************************************
            mudtConnection = Connection_Status.NO


            '*************************************************
            ' ۸ޏo��
            '*************************************************
            Call AddToLog("ؽŰ�߰Ă�ؒf���܂���   �߰�No:" & mintPortNo)


            mintRET = RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region

#Region "  �����ް��擾                         ����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �umobjSocket�v��ȯ�ܰ������M�����ް����擾���܂�
    ''' </summary>
    ''' <param name="intByte">�擾�����޲Đ��i-1�ȉ��̎��͑S�޲Đ����擾�j��̫�� = -1</param>
    ''' <remarks>�y���Ӂz###########�K���ǂ�ŉ������I############################
    '''                  �ײ��Ă���ڑ����ꂽ���A�O��̐ڑ����͂��ׂĔj������܂��I
    '''                  �����ײ��Ă���̐ڑ��ɑ΂��ẮA����͕ۏ�o���܂���I
    '''                  ###########�K���ǂ�ŉ������I############################
    ''' </remarks>
    ''' *******************************************************************************************************************
    Public Sub Receive(Optional ByVal intByte As Integer = -1)
        Try
            '*************************************************
            ' �F�X������
            '*************************************************
            mstrRecvText = ""
            mbytRecvText = Nothing


            '*************************************************
            ' �ײ��Ă���̐ڑ��m�F
            '*************************************************
            Select Case mudtConnection
                Case Connection_Status.YES
                    If mobjSocket.Poll(0, SelectMode.SelectRead) = True Then
                        '=============================================================
                        ' �V�����쐬���ꂽ�ڑ��ɑ΂��ĐV���� Socket ���쐬
                        '=============================================================
                        mobjConnSocket.Shutdown(SocketShutdown.Both)
                        mobjConnSocket.Close()
                        mobjConnSocket = Nothing
                        mobjConnSocket = mobjSocket.Accept()
                        AddToLog("�V�����ڑ����m�F���܂���  �߰�No:" & mintPortNo)      '۸ޏ�����
                        mintRET = RetCode.RecvConnNew
                        Exit Sub
                    End If

                Case Connection_Status.NO
                    If mobjSocket.Poll(0, SelectMode.SelectRead) = True Then
                        mudtConnection = Connection_Status.YES
                    Else
                        mintRET = RetCode.RecvConnNothing
                        Exit Sub
                    End If

                    '=============================================================
                    ' �V�����쐬���ꂽ�ڑ��ɑ΂��ĐV���� Socket ���쐬
                    '=============================================================
                    mobjConnSocket = mobjSocket.Accept()
                    AddToLog("�ڑ����m�F���܂���  �߰�No:" & mintPortNo)                    '۸ޏ�����
                    mintRET = RetCode.RecvConnNew
                    Exit Sub

            End Select


            '*************************************************
            ' ��M�ް���÷�ĉ�
            ' �uRECV_TEXT�v�����è�ɾ��
            '*************************************************
            While mobjConnSocket.Available = 0
                mintRET = RetCode.RecvDataNothing
                Exit Sub
            End While

            '==========================================
            ' ��M�޲Đ����
            '==========================================
            Dim intGetByte As Integer       '��M�޲Đ����
            Select Case intByte < 0
                Case True
                    intGetByte = mobjConnSocket.Available
                Case False
                    Select Case mobjConnSocket.Available < intByte
                        Case True
                            intGetByte = mobjConnSocket.Available
                        Case False
                            intGetByte = intByte
                    End Select
            End Select


            '==========================================
            ' �ް���M
            '==========================================
            Dim Buffer_Recv() As Byte           '��M�p�ޯ̧
            ReDim Buffer_Recv(intGetByte - 1)
            mobjConnSocket.Receive(Buffer_Recv, _
                                   0, _
                                   intGetByte, _
                                   SocketFlags.None)                    '��M
            mbytRecvText = Buffer_Recv                              '�����è���
            mstrRecvText = ByteToString(Buffer_Recv)                '�����è���


            mintRET = RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region

#Region "  �����ް����M                         ����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����ް����M ����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Send()
        Try
            Dim intRet As Integer
            Dim BufferSend() As Byte           '���M�p�ޯ̧


            '*************************************************
            '���O����
            '*************************************************
            If IsNothing(mobjConnSocket) = True Then
                mintRET = RetCode.ConnectError
                Call AddToLog("���Đڑ��װ�B���ݐڑ�����Ă��鿹�Ă͂���܂���B")
                Exit Sub
            End If


            '*************************************************
            '�����è����
            '*************************************************
            If IsNull(mstrSendText) And IsNull(mbytSendText) Then
                mintRET = RetCode.PropertyError
                Call AddToLog("���M÷�������è��÷�Ă���Ă���Ă��܂���B���M÷�������è�ɑ��M÷�Ă�Ă��ĉ������B")
                Exit Sub
            End If


            '*************************************************
            '���M
            '*************************************************
            If IsNotNull(mbytSendText) Then
                BufferSend = mbytSendText
            Else
                BufferSend = StringToByte(mstrSendText)
            End If
            '���M
            intRet = mobjConnSocket.Send(BufferSend _
                                       , 0 _
                                       , BufferSend.Length _
                                       , SocketFlags.None _
                                       )


            '*************************************************
            '���M�o���Ȃ��������̿��đ��M
            '*************************************************
            Dim ii As Integer = 0          'ٰ�߂̶���
            While intRet <> BufferSend.Length
                Dim BufferSend2() As Byte = BufferSend              '���M�p�ޯ̧�쐬�p�ޯ̧
                ReDim BufferSend(UBound(BufferSend2) - intRet)      '���M�p�ޯ̧������

                '���đ��M���s�����޲Ĕz��쐬
                Array.Copy(BufferSend2, _
                           intRet, _
                           BufferSend, _
                           0, _
                           BufferSend2.Length - intRet _
                           )

                intRet = mobjConnSocket.Send(BufferSend, _
                                             0, _
                                             BufferSend.Length, _
                                             SocketFlags.None)              '���M


                ii += 1
                Call AddToLog("��x�ſ��Ă𑗐M�o���Ȃ������ׁA�������đ���܂����B�@" & ii & "���   �߰�No:" & mintPortNo)
                If 100 <= ii Then Throw New Exception(ii & "�񕪊����đ��M���Ă��A���M�o���܂���ł���")
            End While


            mintRET = RetCode.OK
        Catch ex As SocketException
            Call AddToLog(ex.Message & "   �߰�No:" & mintPortNo)
            mintRET = RetCode.NG

        Catch ex As ArgumentNullException
            Call AddToLog(ex.Message & "   �߰�No:" & mintPortNo)
            mintRET = RetCode.NG

        Catch ex As ArgumentOutOfRangeException
            Call AddToLog(ex.Message & "   �߰�No:" & mintPortNo)
            mintRET = RetCode.NG

        Catch ex As ObjectDisposedException
            Call AddToLog(ex.Message & "   �߰�No:" & mintPortNo)
            mintRET = RetCode.NG

        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region


#Region "  �޲Ĕz�� �� ������"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �޲Ĕz�� �� ������
    ''' </summary>
    ''' <param name="bytData">�ϊ������޲Ĕz��</param>
    ''' <returns>�ϊ�����������</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ByteToString(ByVal bytData() As Byte) As String
        Dim strRet As String

        strRet = Text.Encoding.GetEncoding(mintCodePage).GetString(bytData, 0, bytData.Length)

        Return (strRet)
    End Function
#End Region

#Region "  ������ �� �޲Ĕz��"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ������ �� �޲Ĕz��
    ''' </summary>
    ''' <param name="strData">�ϊ����镶����</param>
    ''' <returns>�ϊ������޲Ĕz��</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function StringToByte(ByVal strData As String) As Byte()

        Dim bytRet() As Byte
        bytRet = Text.Encoding.GetEncoding(mintCodePage).GetBytes(strData)

        Return (bytRet)
    End Function
#End Region

#Region "  �װ����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �װ����
    ''' </summary>
    ''' <param name="objException"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ComError(ByVal objException As Exception)

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


        mintRET = RetCode.NG
    End Sub
#End Region

#Region "  ۸ޏ������ݏ���"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۸ޏ������ݏ���
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String)

        mobjOwner.AddToLog(strMsg_1)

    End Sub
#End Region

End Class
