'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z���ް�ֿ��đ��M�׽
' �y�쐬�zSIT
'**********************************************************************************************

Imports MateCommon.clsConst

Public Class clsSocketToServer

#Region "  ���ʕϐ�         "

    '�����è�ϐ�
    Private mobjOwner As Object                 '��Ű��޼ު��
    Private mstrTermID As String                '�[��ID
    Private mstrEmpCD As String                 'հ�ްID
    Private mstrAddress As String               '���M����ڽ
    Private mintPortNo As Integer               '�߰�No
    Private mintTimeout As Integer              '��ѱ��
    Private mstrTelFilePath As String           '�ǂݍ��ޒ�`̧�ق��߽

#End Region

#Region "  �����è��`"
    ''' =======================================
    ''' <summary>��Ű��޼ު��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property objOwner() As Object
        Get
            Return mobjOwner
        End Get
        Set(ByVal Value As Object)
            mobjOwner = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�[��ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strTermID() As String
        Get
            Return mstrTermID
        End Get
        Set(ByVal Value As String)
            mstrTermID = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>հ�ްID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strEmpCD() As String
        Get
            Return mstrEmpCD
        End Get
        Set(ByVal Value As String)
            mstrEmpCD = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>���M����ڽ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strAddress() As String
        Get
            Return mstrAddress
        End Get
        Set(ByVal Value As String)
            mstrAddress = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�߰�No</summary>
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
    ''' <summary>��ѱ��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intTimeout() As Integer
        Get
            Return mintTimeout
        End Get
        Set(ByVal Value As Integer)
            mintTimeout = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�ǂݍ��ޒ�`̧�ق��߽</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strTelFilePath() As String
        Get
            Return mstrTelFilePath
        End Get
        Set(ByVal Value As String)
            mstrTelFilePath = Value
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
        Try

            '***************************************
            ' �F�X������
            '***************************************
            mobjOwner = objOwner                                '��Ű��޼ު��


        Catch ex As Exception
            Throw ex

        End Try
    End Sub
#End Region

#Region "  ���ް�ֿ��đ��M      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ް�ֿ��đ��M
    ''' </summary>
    ''' <param name="objTelegramSend">�d���쐬�׽</param>
    ''' <param name="strRET_STATE">���ނ����M���������ð��(��̫�� = "")</param>
    ''' <param name="strRET_DATA_SYUBETU">���ނ����M���������ް����(��̫�� = "")</param>
    ''' <param name="strRET_DATA">���ނ����M���������ް�(��̫�� = "")</param>
    ''' <returns>���đ��M�A���퉞�� or �ُ퉞��</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SockSendServer(ByRef objTelegramSend As clsTelegram, _
                                   Optional ByRef strRET_STATE As String = "", _
                                   Optional ByRef strRET_DATA_SYUBETU As String = "", _
                                   Optional ByRef strRET_DATA As String = "" _
                                   ) _
                                   As clsSocketClient.RetCode
        Dim dtmNow As Date = Now
        Dim objSocketSend As New clsSocketClientGamen(mobjOwner)

        '***************************************************
        ' �d���쐬
        '***************************************************
        'ͯ�ް�������
        objTelegramSend.SETIN_HEADER("DSPCMD_ID", Right(objTelegramSend.FORMAT_ID, 6))  '�����ID
        objTelegramSend.SETIN_HEADER("DSPTERM_ID", mstrTermID)                          '�[��ID
        objTelegramSend.SETIN_HEADER("DSPUSER_ID", mstrEmpCD)                            'հ�ްID
        objTelegramSend.MAKE_TELEGRAM()                                                 '�d���쐬


        '***************************************************
        ' ���đ��M
        '***************************************************
        objSocketSend.strAddress = mstrAddress                          '���M����ڽ
        objSocketSend.intPortNo = mintPortNo                            '�߰�No
        objSocketSend.intTimeOut = mintTimeout                          '��ѱ��
        objSocketSend.strSendText = objTelegramSend.TELEGRAM_MAKED      '���M÷��
        If mintTimeout = 0 Then
            objSocketSend.blnReceiveFlag = False                        '�������đҋ@
        Else
            objSocketSend.blnReceiveFlag = True                         '�������đҋ@
        End If
        objSocketSend.SendSock()                                        '���đ��M


        '***************************************************
        ' ���đ��M����I������
        '***************************************************
        Select Case objSocketSend.udtRet
            Case clsSocketClient.RetCode.NG
                Call Me.AddToLog(FRM_MSG_SOCKSENDSERVER_01)

            Case clsSocketClient.RetCode.ReceiveTimeOut
                Call Me.AddToLog(FRM_MSG_SOCKSENDSERVER_02)

            Case clsSocketClient.RetCode.ConnectError
                Call Me.AddToLog(FRM_MSG_SOCKSENDSERVER_03)

        End Select


        '***************************************************
        ' ��M���ĉ��
        '***************************************************
        If objSocketSend.blnReceiveFlag = True Then
            '(�������Ă���M����ꍇ)

            Dim objTelegramRecv As New clsTelegram(mstrTelFilePath)
            Dim strRET_MESSAGE_EXIST As String          '����ү���ޗL��
            Dim strRET_MESSAGE As String                '����ү����

            objTelegramRecv.FORMAT_ID = FORMAT_DSP_RETURN                       '̫�ϯĖ����
            objTelegramRecv.TELEGRAM_PARTITION = objSocketSend.strRecvText      '��������d�����
            objTelegramRecv.PARTITION()                                         '�d������
            strRET_STATE = objTelegramRecv.SELECT_DATA("DSPRET_STATE")                     '�����ð��
            strRET_MESSAGE_EXIST = objTelegramRecv.SELECT_DATA("DSPRET_MESSAGE_EXIST")     '����ү���ޗL��
            strRET_MESSAGE = Trim(objTelegramRecv.SELECT_DATA("DSPRET_MESSAGE"))           '����ү����
            strRET_DATA_SYUBETU = objTelegramRecv.SELECT_DATA("DSPRET_DATA_SYUBETU")       '�����ް����
            strRET_DATA = objTelegramRecv.SELECT_DATA("DSPRET_DATA")                       '�����ް�

            '---------------------------------
            '�������ޕ\��
            '---------------------------------
            If objSocketSend.udtRet = clsSocketClient.RetCode.OK Then
                '(����̏ꍇ)
                If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                    '(�������ސ���̏ꍇ)
                    Me.AddToLog("���đ��M�͐���ɍs���܂����B")
                Else
                    '(�������ވُ�̏ꍇ)
                    Me.AddToLog("���đ��M�͐���ɍs���܂������A�������ނ�����ł͂���܂���B[��������:" & strRET_STATE & "]")
                End If
            Else
                '(�ُ�̏ꍇ)
                Me.AddToLog("���đ��M�͎��s���܂����B")
            End If

            '---------------------------------
            'ү���ޕ\��
            '---------------------------------
            If Trim(strRET_MESSAGE_EXIST) = ID_RETURN_RET_MESSAGE_EXIST_YES Then
                Call Me.AddToLog("���ް���牞��ү���ނ���M���܂����B[" & strRET_MESSAGE & "]")
            End If

            '---------------------------------
            '�����ް��\��
            '---------------------------------
            If Trim(strRET_DATA_SYUBETU) = ID_RETURN_RET_DATA_SYUBETU _
               And Trim(strRET_DATA) = ID_RETURN_RET_DATA Then
                '(�����ް����,�����ް��Ȃ��̏ꍇ)
                'NOP
            Else
                '(�����ް����,�����ް�����̏ꍇ)
                Me.AddToLog("[�����ް����:" & strRET_DATA_SYUBETU & "]    �����ް�[" & strRET_DATA & "]")
            End If

        End If


        Return (objSocketSend.udtRet)
    End Function
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
