'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z���đ��M�׽
' �y�쐬�zSIT
'**********************************************************************************************

Imports MateCommon.clsConst
Imports MateCommon
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text

Public Class clsSocketClientGamen
    Inherits clsSocketClient

#Region "  ���ʕϐ�"

    '������ 2012.11.16 12:58 �u���΂炭���҂����������v�޲�۸��ޯ�� �����Ȃ�h���Ή�
    Private Declare Function GetInputState Lib "USER32" () As Long   'GetInputState�֐��Ͳ���ķ��ɑҋ@���̲���Ă����邩���ׂ�
    '������ 2012.11.16 12:58 �u���΂炭���҂����������v�޲�۸��ޯ�� �����Ȃ�h���Ή�

    Private mblnReceiveFlag As Boolean      '�������đҋ@�׸�
    Private mintTimeOut As Integer          '��ѱ�Ď��ԁims�j

#End Region

#Region "  �ݽ�׸�"
    Public Sub New(ByVal objOwner As Object)

        MyBase.New(objOwner)

        Try

            mblnReceiveFlag = False                            '�������đҋ@�׸�
            mintTimeOut = 10000                                 '��ѱ�Ď��ԁims�j


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region

#Region "  �����è"

    Public Property intTimeOut() As Integer
        Get
            Return mintTimeOut
        End Get
        Set(ByVal Value As Integer)
            mintTimeOut = Value
        End Set
    End Property

    Public Property blnReceiveFlag() As Boolean
        Get
            Return mblnReceiveFlag
        End Get
        Set(ByVal Value As Boolean)
            mblnReceiveFlag = Value
        End Set
    End Property

#End Region

#Region "  ���đ��M(����ڑ��A�ؒf�����ʗp)   ����"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���đ��M����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub SendSock()
        Try
            Dim intRet As Integer
            Dim dtmNow As Date = Now            '���ݎ���
            Dim Buffer_Send() As Byte           '���M�p�ޯ̧
            Dim Buffer_Recv() As Byte           '��M�p�ޯ̧
            Dim objIpAddress As IPAddress          'IP���ڽ�擾
            'Dim localEndPoint As New IPEndPoint(Dns.Resolve(mstrADDRESS).AddressList(0), _
            '                                    mintPORT_NO)                               'IP���ڽ�APORT �ݒ�
            Dim localEndPoint As IPEndPoint                                                 'IP���ڽ�APORT �ݒ�
            Dim objSocket As Socket = New Socket(AddressFamily.InterNetwork, _
                                                 SocketType.Stream, _
                                                 ProtocolType.Tcp)


            '*************************************************
            'EndPoint�擾
            '*************************************************
            Try
                objIpAddress = IPAddress.Parse(mstrAddress)
            Catch ex As FormatException
                Dim oLog As New clsWriteLog
                oLog.WriteLog("IP���ڽ Parse �ُ� [" & ex.Message & "]")
                objIpAddress = Dns.GetHostEntry(mstrAddress).AddressList(0)
            End Try

            localEndPoint = New IPEndPoint(objIpAddress, _
                                                   mintPortNo)

            '*************************************************
            '�����è����
            '*************************************************
            If mstrAddress = "" Or _
               mintPortNo = -1 Or _
               mstrSendText = "" Then
                mudtRET = RetCode.PropertyError
                Exit Sub
            End If


            '*************************************************
            '���ް�ڑ�
            '*************************************************
            Try
                objSocket.Connect(localEndPoint)            '�ڑ�
                If objSocket.Connected = False Then         '�ڑ��̊m�F
                    Throw New Exception
                End If
            Catch ex As Exception
                mudtRET = RetCode.ConnectError
                Exit Sub
            End Try


            '*************************************************
            '���M
            '*************************************************
            Buffer_Send = StringToByte(mstrSendText)
            intRet = objSocket.Send(Buffer_Send, _
                                    0, _
                                    Buffer_Send.Length, _
                                    SocketFlags.None)               '���M
            AddToLog("�ýĻ��ނֿ��Ă𑗐M���܂���   �F" & mstrSendText)


            '*************************************************
            '��M
            '*************************************************
            If mblnReceiveFlag = True Then

                While objSocket.Available = 0
                    If DateAdd(DateInterval.Second, CInt(mintTimeOut / 1000), dtmNow) < Now Then
                        mudtRET = RetCode.ReceiveTimeOut
                        Exit Sub
                    End If

                    '������ 2012.11.16 12:58 �u���΂炭���҂����������v�޲�۸��ޯ�� �����Ȃ�h���Ή�
                    '* 2012/11/29 11:00 H.Morita ���݂��ēx�����Ă��܂��BWindowsү���ނ����������̂Ŏ~�߂� * If GetInputState() Then System.Windows.Forms.Application.DoEvents()
                    '������ 2012.11.16 12:58 �u���΂炭���҂����������v�޲�۸��ޯ�� �����Ȃ�h���Ή�

                    System.Threading.Thread.Sleep(100)
                End While

                ReDim Buffer_Recv(objSocket.Available)
                objSocket.Receive(Buffer_Recv, _
                                  0, _
                                  objSocket.Available, _
                                  SocketFlags.None)                         '��M
                mstrRecvText = mobjEncode.GetString(Buffer_Recv)           '�����è���

            End If


            '*************************************************
            '���ް�ؒf
            '*************************************************
            objSocket.Shutdown(SocketShutdown.Both)
            objSocket.Close()


            mudtRET = RetCode.OK
        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region

End Class