'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�ʐM��аҲݸ׽              (KSH�p���ޯ��°قł�)
' �y�쐬�z2006/05/30  SIT  Rev 0.00
'**********************************************************************************************

#Region "  Imports  "
Imports JobCommon
Imports MateCommon.clsConst
Imports MateCommon
Imports UserProcess
#End Region

Public Class clsMCIMainDummy

#Region "  ���ʕϐ�02           "


    '==================================================
    '���ʵ�޼ު��
    '==================================================
    Private mobjSerial As clsSerial                     '�رْʐM��޼ު��
    Private mobjEQSendTelBuff As TBL_TLIF_TRNS_SEND     '�d�����M�ޯ̧
    'Private mobjEQSendResBuff As TBL_TLIF_TRNS_SEND    '�����d�����M�ޯ̧
    Private mobjGetTelegram As clsGetTelegram           '�d���p÷�Ď擾�׽
    Private mobjMCIMain As CtrlMCID.clsMCIMain          '�{���̒ʐM��۸��Ѹ׽

    '==================================================
    '�����ϐ�
    '==================================================
    '��M�pCOM�ݒ�
    Private mstrCOMRecvPort As String               '�߰Ĕԍ�
    Private mintCOMRecvBaud As Integer              '�ʐM���x
    Private mstrCOMRecvParity As String             '���è
    Private mintCOMRecvDataLength As Integer        '�ް���
    Private mstrCOMRecvStopBit As String            '�į���ޯĒ�
    Private mstrCOMRecvArrayHeader As String        '��Mͯ�ް
    Private mstrCOMRecvArrayTerminator As String    '��M���Ȱ�
    Private mintCOMCodePage As Integer              '�ʐM�Ɏg�p����÷�Ă̺���  (932:ShiftJIS)
    Private mstrCOMComName As String                '�ʐM��

    '���̑�
    Private mintSendCount As Integer            '�đ��M��
    Private mdtmBeforeRecvTime As Date          '�O���M����
    Private mdtmBeforeSendTime As Date          '�O�񑗐M����
    Private mstrRecvTelBuff As String           '��M�ޯ̧
    Private mintResponsWait As Integer          '�����҂��׸�
    Private mdtmBeforeConnTime As Date          '�O��ڑ�����
    'Private mblnConnect As Boolean              '���Đڑ��׸�
    Private mintSockRecvMode As Integer         '���Ď�MӰ��


    '�����è
    Private mintSendSEQNo As Integer        '���MSEQ��
    Private mintRecvSEQNo As Integer        '��MSEQ��

#End Region
#Region "  �����è02            "

    ''' =======================================
    ''' <summary>���MSEQ��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intSendSEQNo() As Integer
        Get
            Return mintSendSEQNo
        End Get
        Set(ByVal Value As Integer)
            mintSendSEQNo = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>��MSEQ��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intRecvSEQNo() As Integer
        Get
            Return mintRecvSEQNo
        End Get
        Set(ByVal Value As Integer)
            mintRecvSEQNo = Value
        End Set
    End Property

#End Region

    '***********************************************
    '����������������K�v
#Region "  ���ʕϐ�             "

    '==================================================
    '���ʵ�޼ު��
    '==================================================
    Private mobjOwner As Object                                 '��Ű��޼ު��
    Private mobjDb As clsConn                                   '�׸ِڑ���޼ު��
    Private mobjDbLog As clsConn                                '�׸ِڑ���޼ު��
    Private mobjTPRG_SYS_HEN As TBL_TPRG_SYS_HEN                '���ѕϐ�
    Private mobjSockSvr As clsSocketToServer                    '���ް�ֿ��đ��M�׽
    Private mobjASCII As clsASCII                               'ASCII���ޕ����׽

    '==================================================
    '�����ϐ�
    '==================================================
    Private mdtmNow As Date                     '���ݓ���
    Private mdtmBeforeDBTime As Date            '�O��DB��������
    Private mblnSockSend As Boolean             '���đ��M�׸�
    Private mblnSockEnd As Boolean              '���đ��M�����׸�

    '==================================================
    'Confiģ�ُ��
    '==================================================
    '���ް�ւ̿��ėp
    Private mstrSvrSockSendAddress As String        '���ޑ��M����ڽ
    Private mintSvrSockSendPort As Integer          '���ޑ��M���߰�No
    Private mintSvrSockSendTimeOut As Integer       '���މ������đҋ@����
    Private mstrSvrSockSendTermID As String         '���ޒ[��ID
    Private mstrSvrSockSendUserID As String         '����հ�ްID
    Private mstrSvrSockSendFlag As String           '���޿��đ��M�׸�
    '���̑�
    Private mintDBReadTimer As Integer              '���M�ޯ̧ð��ق������������ (�b)
    Private mstrFEQ_ID As String                    '����PC�敪
    Private mstrFMSG_ID_ERR_SYS As String           '���Ѵװ  ����ү����ID
    Private mstrFMSG_ID_ERR_USER As String          'հ�ް�װ ����ү����ID
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
    Private mintEQ_SendTimer As Integer             '������₢���킹����(ms)
    '������������************************************************************************************************************
    Private mintSendSleep As Integer                '�ʐMؾ�Ď��̽ذ�ߎ���(ms)  �A������ؾ�Ă��s��Ȃ���
    Private mintSendTimeout As Integer              '���M��ѱ��(ms)
    Private mintSendRetry As Integer                '���M��ײ��
    Private mintDebugFlag As Integer                '���ޯ���׸�

    '==================================================
    '�Œ�l
    '==================================================
    Private Const ERR_MSG_01 As String = "���Ѵװ�����B"

#End Region
#Region "  �����è              "

    Public Property intDebugFlag() As Integer
        Get
            Return mintDebugFlag
        End Get
        Set(ByVal Value As Integer)
            mintDebugFlag = Value
            mobjSerial.intDebugFlag = Value
        End Set
    End Property

#End Region

#Region "  Ҳݏ���              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Ҳݏ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub Main()
        Try
            mobjDb.BeginTrans()     '��ݻ޸��݊J�n
            Try
                'Dim strMsg As String                    'ү����


                '*****************************************************
                '�F�X������
                '*****************************************************
                mdtmNow = Now


                '*****************************************************
                '�d����M
                '*****************************************************
                Dim strRecvText As String = ""          '��M�d��
                Call RecvDataEQ(strRecvText)


                '*****************************************************
                'ALC�d����M����
                '*****************************************************
                Call MCIA_900002(strRecvText)


            Catch ex As Exception
                Call ComError(ex)

            Finally
                mobjDb.Commit()     '�Я�

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
    ''' <param name="objOwner">��Ű��޼ު��  (���۸ޏ����݂Ɏg�p)</param>
    ''' <param name="objDb">�׸ِڑ��׽   (�ʏ�p)</param>
    ''' <param name="objDbLog">�׸ِڑ��׽   (۸ޗp)</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, _
                   ByVal objDb As clsConn, _
                   ByVal objDbLog As clsConn _
                   )
        Try

            '*****************************************************
            '�F�X������
            '*****************************************************
            mobjOwner = objOwner                                '��Ű��޼ު��
            mdtmBeforeDBTime = Now                              '�O��DB��������
            mstrRecvTelBuff = ""                                '���Ď�M�ޯ̧
            mdtmNow = Now
            mobjMCIMain = New CtrlMCID.clsMCIMain(objOwner, objDb, objDbLog)    '�{���̒ʐM��۸��Ѹ׽

            '*****************************************************
            ' �׸ِڑ�
            '*****************************************************
            mobjDb = objDb
            mobjDbLog = objDbLog


        Catch ex As Exception
            Call ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region
#Region "  ������               "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ������
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Initialize()


        '*****************************************************
        ' �y���ѕϐ��z     �ڑ��׽�쐬
        '*****************************************************
        mobjTPRG_SYS_HEN = New TBL_TPRG_SYS_HEN(mobjOwner, mobjDb, mobjDbLog)


        '*****************************************************
        '�F�X������
        '*****************************************************
        mintSendCount = 0                               '��ײ��
        mdtmBeforeRecvTime = Now                        '�O���M����
        mdtmBeforeSendTime = Now                        '�O�񑗐M����
        mobjASCII = New clsASCII()              'ASCII���ޕ����׽
        mobjEQSendTelBuff = New TBL_TLIF_TRNS_SEND(mobjOwner, Nothing, Nothing)    '�d�����M�ޯ̧
        'mobjEQSendResBuff = New TBL_TLIF_TRNS_SEND(mobjOwner, Nothing, Nothing)    '�����d�����M�ޯ̧
        mdtmBeforeConnTime = Now                        '�O��ڑ�����
        mobjGetTelegram = New clsGetTelegram(mobjOwner) '�d���p÷�Ď擾�׽


        '*****************************************************
        'Confiģ�ُ��擾(�W������)
        '*****************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MCID_DUMMY)                                    'Confiģ�ِڑ��׽����

        '���ް���ėp
        mstrSvrSockSendAddress = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_ADDRESS))              '���ޑ��M����ڽ
        mintSvrSockSendPort = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_PORT))                    '���ޑ��M���߰�No
        mintSvrSockSendTimeOut = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_TIME_OUT))             '���މ������đҋ@����
        mstrSvrSockSendTermID = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_TERM_ID))               '���ޒ[��ID
        mstrSvrSockSendUserID = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_USER_ID))               '����հ�ްID
        mstrSvrSockSendFlag = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_FLAG))                    '���޿��đ��M�׸�
        '���̑�
        mintDBReadTimer = TO_INTEGER(objConfig.GET_INFO(GKEY_MCI_DB_READ_TIMER))                    '���M�ޯ̧ð��ق������������
        mstrFEQ_ID = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FEQ_ID))                                 'MCI���
        mstrFMSG_ID_ERR_SYS = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FMSG_ID_ERR_SYS))               '���Ѵװ  ����ү����ID
        mstrFMSG_ID_ERR_USER = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FMSG_ID_ERR_USER))             'հ�ް�װ ����ү����ID
        '������������************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
        mintEQ_SendTimer = TO_INTEGER(objConfig.GET_INFO(GKEY_MCI_EQ_SEND_TIMER))                   '������₢���킹����(ms)
        '������������************************************************************************************************************
        mintSendSleep = TO_STRING(objConfig.GET_INFO(GKEY_MCI_SEND_SLEEP))                          '�ʐMؾ�Ď��̽ذ�ߎ���(ms)  �A������ؾ�Ă��s��Ȃ���
        mintSendTimeout = TO_STRING(objConfig.GET_INFO(GKEY_MCI_SEND_TIMEOUT))                      '���M��ѱ��(ms)
        mintSendRetry = TO_STRING(objConfig.GET_INFO(GKEY_MCI_SEND_RETRY))                          '���M��ײ��


        '*****************************************************
        '���ް���đ��M��޼ު��  ����
        '*****************************************************
        mobjSockSvr = New clsSocketToServer(mobjOwner)
        mobjSockSvr.objOwner = mobjOwner                        '��Ű��޼ު��
        mobjSockSvr.strTermID = mstrSvrSockSendTermID           '���ޒ[��ID
        mobjSockSvr.strEmpCD = mstrSvrSockSendUserID            '����հ�ްID
        mobjSockSvr.strAddress = mstrSvrSockSendAddress         '���ޑ��M����ڽ
        mobjSockSvr.intPortNo = mintSvrSockSendPort             '���ޑ��M���߰�No
        mobjSockSvr.intTimeout = mintSvrSockSendTimeOut         '���މ������đҋ@����
        mobjSockSvr.strTelFilePath = CONFIG_TELEGRAM_DSP        '�ǂݍ��ޒ�`̧�ق��߽


        '**********************************************************************************************************************
        '���������ŗL����


        '*****************************************************
        '������ݒ�
        '*****************************************************
        mobjGetTelegram.strSTX = mobjASCII.strSTX
        mobjGetTelegram.strETX = mobjASCII.strETX & mobjASCII.strCR


        '*****************************************************
        'Confiģ�ُ��擾(�ŗL����)
        '*****************************************************
        '��M�pCOM�ݒ�
        mstrCOMRecvPort = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_PORT))                    '�߰Ĕԍ�
        mintCOMRecvBaud = TO_NUMBER(objConfig.GET_INFO(GKEY_EQ_COM_RECV_BAUD))                    '�ʐM���x
        mstrCOMRecvParity = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_PARITY))                '���è
        mintCOMRecvDataLength = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_DATALENGTH))        '�ް���
        mstrCOMRecvStopBit = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_STOPBIT))              '�į���ޯĒ�
        mintCOMCodePage = TO_NUMBER(objConfig.GET_INFO(GKEY_EQ_COM_CODEPAGE))                     '�ʐM�Ɏg�p����÷�Ă̺���  (932:ShiftJIS)
        mstrCOMComName = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_COMNAME))                       '�ʐM��


        '****************************************************
        '���ĵ�޼ު��   ���
        '****************************************************
        mobjSerial = New clsSerial(mobjOwner)                        '�رْʐM��޼ު��
        mobjSerial.strRecvPort = mstrCOMRecvPort                     '�߰Ĕԍ�
        mobjSerial.intRecvBaud = mintCOMRecvBaud                     '�ʐM���x
        mobjSerial.strRecvParity = mstrCOMRecvParity                 '���è
        mobjSerial.intRecvDataLength = mintCOMRecvDataLength         '�ް���
        mobjSerial.strRecvStopBit = mstrCOMRecvStopBit               '�į���ޯĒ�
        mobjSerial.intCodePage = mintCOMCodePage                     '�ʐM�Ɏg�p����÷�Ă̺���  (932:ShiftJIS)
        mobjSerial.strComName = mstrCOMComName                       '�ʐM��
        mobjSerial.Open()                                            '�ʐM�m��


        '���������ŗL����
        '**********************************************************************************************************************


        ''****************************************************
        ''�ʐM�����
        ''****************************************************
        'Call Open()


    End Sub
#End Region

#Region "  ۸ޏ������ݏ���                  "
    '''*******************************************************************************************************************
    ''' <summary>
    '''  ۸ޏ������ݏ���
    ''' </summary>
    ''' <param name="strMsg_1"></param>
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
    ''' <param name="strMsg_1"></param>
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
    ''' <param name="objException"></param>
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
#Region "  ���ѕϐ��擾                     "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ���ѕϐ��擾
    ''' </summary>
    ''' <param name="strITEM_ID">�ϐ�ID</param>
    ''' <returns>���ѕϐ��擾�l</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function GetSYS_HEN(ByVal strITEM_ID As String) As Object

        Dim objReturn As Object         '�֐��ߒl
        Dim udtRet As RetCode           '�ߒl
        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(mobjOwner, mobjDb, mobjDbLog)
        objTPRG_SYS_HEN.FHENSU_ID = strITEM_ID              '�ϐ�ID
        udtRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN_OBJ()     '���擾
        If udtRet <> RetCode.OK Then
            Throw New Exception("���ѕϐ��擾�װ")
        End If
        objReturn = objTPRG_SYS_HEN.OBJGET_DATA


        Return (objReturn)
    End Function
#End Region
#Region "  ���ѕϐ��ύX                     "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ���ѕϐ��ύX
    ''' </summary>
    ''' <param name="strITEM_ID">�ϐ�ID</param>
    ''' <param name="objSetData">�ύX�ް�</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub SetSYS_HEN(ByVal strITEM_ID As String, _
                          ByVal objSetData As Object _
                          )

        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(mobjOwner, mobjDb, mobjDbLog)
        objTPRG_SYS_HEN.FHENSU_ID = strITEM_ID              '�ϐ�ID
        objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(False)             '���擾
        objTPRG_SYS_HEN.OBJCHANGE_DATA = objSetData         '�ύX�ް�
        objTPRG_SYS_HEN.UPDATE_TPRG_SYS_HEN_OBJ()           '�ύX����


    End Sub
#End Region
    '����������������K�v
    '***********************************************


    '***********************************************
    '���������������M����
    '���������������M����
    '***********************************************
    '��������������M����
    '��������������M����
    '***********************************************
    '�������������ڑ��m�F����


    '�������������ڑ��m�F����
    '***********************************************

#Region "  �ʐM�����                        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ʐM�����
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Open()


        '****************************************************
        '�رْʐM��޼ު��       �����
        '****************************************************
        mobjSerial.strRecvPort = mstrCOMRecvPort                     '�߰Ĕԍ�
        mobjSerial.intRecvBaud = mintCOMRecvBaud                     '�ʐM���x
        mobjSerial.strRecvParity = mstrCOMRecvParity                 '���è
        mobjSerial.intRecvDataLength = mintCOMRecvDataLength         '�ް���
        mobjSerial.strRecvStopBit = mstrCOMRecvStopBit               '�į���ޯĒ�
        mobjSerial.intCodePage = mintCOMCodePage                     '�ʐM�Ɏg�p����÷�Ă̺���  (932:ShiftJIS)
        mobjSerial.strComName = mstrCOMComName                       '�ʐM��
        mobjSerial.Open()                                            '�ʐM�m��


    End Sub
#End Region
#Region "  �ʐM�۰��                        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ʐM�۰��
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub Close()
        Try


            '****************************************************
            '�رْʐM��޼ު��       �۰��
            '****************************************************
            mobjSerial.Close()                                          '�ʐM�m��


        Catch ex As Exception
            'NOP(���s���Ă����ɖ��Ȃ�)
        End Try
    End Sub
#End Region

#Region "  �ް����M                         "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ް����M(����ؽŰ)
    ''' </summary>
    ''' <param name="strSendText">���M÷��</param>
    ''' <returns>����I���̗L��</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function SendDataEQ(ByVal strSendText As String) As RetCode
        Try
            Dim intRet As RetCode = RetCode.OK


            '*****************************************************
            '�A�����đ��M�o���Ȃ���Sleep
            '*****************************************************
            If 0 < mintSendSleep Then
                '(�ذ�ߎ��Ԃ���Ă���Ă���ꍇ)

                Dim objDiff As TimeSpan = mdtmBeforeSendTime.AddMilliseconds(mintSendSleep) - Now
                If 0 < objDiff.TotalMilliseconds Then
                    Call Threading.Thread.Sleep(objDiff.TotalMilliseconds)
                End If

            End If


            '*****************************************************
            '÷���ް����M
            '*****************************************************
            Dim blnSendSuccess As Boolean = False       '�d�����M�����׸�
            For II As Integer = 1 To mintSendRetry
                '(ٰ��:��ײ��)

                mobjSerial.strSendText = strSendText
                'mobjSerial.strSendText = mobjGetTelegram.MakeTelegramSTXETX(strSendText)

                Try
                    mobjSerial.Send()
                    blnSendSuccess = True
                    Exit For
                Catch ex As Exception
                End Try
            Next
            If blnSendSuccess = True Then
                '(���������ꍇ)
            Else
                '(���s�����ꍇ)
                Call AddToLog(MCIA_MSG_022 & strSendText)
                intRet = RetCode.NG
                Return intRet
            End If


            '*****************************************************
            '۸ޏo��
            '*****************************************************
            '===========================================
            '÷��۸ޒǉ�
            '===========================================
            Call AddToLog(MCIA_MSG_021 & strSendText)


            Return intRet
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
#Region "  �ް���M                         "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ް���M
    ''' </summary>
    ''' <param name="strRecvText">��M÷��</param>
    ''' <remarks>����I���̗L��</remarks>
    '''*******************************************************************************************************************
    Public Sub RecvDataEQ(ByRef strRecvText As String)


        '****************************************
        '���Ď�M
        '****************************************
        mobjSerial.Receive()


        '****************************************
        '�d�������𒊏o & ���Ď�M�ޯ̧�X�V
        '****************************************
        If IsNotNull(mobjSerial.strRecvText) Then
            '(�d������M�����ꍇ)


            '****************************************
            '���Ď�M�ޯ̧�Ɍ���
            '****************************************
            If IsNull(mstrRecvTelBuff) Then
                mstrRecvTelBuff = mobjSerial.strRecvText
            Else
                mstrRecvTelBuff &= mobjSerial.strRecvText
            End If


            '****************************************
            '�d�������𒊏o & ���Ď�M�ޯ̧�X�V
            '****************************************
            strRecvText = mobjGetTelegram.GetTelegramSTXETX(mstrRecvTelBuff)
            If IsNotNull(strRecvText) Then
                Call AddToLog(MCIA_MSG_011 & strRecvText) '�d���擾۸ޏo��
            End If

        End If


    End Sub
#End Region



    '*******************
    'Public
    '*******************



    '*******************
    'Private
    '*******************
#Region "  MCIA_100002  �d����M                ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �d����M����
    ''' </summary>
    ''' <param name="strRecvText">����Ɏ�M�ł����ް�</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_900002(ByVal strRecvText As String)
        Try




        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region

End Class
