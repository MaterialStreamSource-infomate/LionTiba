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
Imports UserProcess
#End Region

Public Class clsMCIMain

#Region "  ���ʕϐ�02           "

    '==================================================
    '���ʵ�޼ު��
    '==================================================
    Friend mobjSerial As clsMcvSerial                   'MCV�ʐM��޼ު��
    Private mobjEQSendTelBuff As TBL_TLIF_TRNS_SEND     '�d�����M�ޯ̧
    Private mobjEQSendResBuff As TBL_TLIF_TRNS_SEND     '�����d�����M�ޯ̧
    Private mobjGetTelegram As clsGetTelegram           '�d���p÷�Ď擾�׽

    '==================================================
    '�����ϐ�
    '==================================================
    'EQ�رْʐM�p(���M�p)
    Private mstrCOMSendPort As String               '�߰Ĕԍ�
    Private mintCOMSendBaud As Integer              '�ʐM���x
    Private mstrCOMSendParity As String             '���è
    Private mintCOMSendDataLength As Integer        '�ް���
    Private mstrCOMSendStopBit As String            '�į���ޯĒ�
    Private mstrCOMSendArrayHeader As String        '��Mͯ�ް
    Private mstrCOMSendArrayTerminator As String    '��M���Ȱ�
    'EQ�رْʐM�p(��M�p)
    Private mstrCOMRecvPort As String               '�߰Ĕԍ�
    Private mintCOMRecvBaud As Integer              '�ʐM���x
    Private mstrCOMRecvParity As String             '���è
    Private mintCOMRecvDataLength As Integer        '�ް���
    Private mstrCOMRecvStopBit As String            '�į���ޯĒ�
    Private mstrCOMRecvArrayHeader As String        '��Mͯ�ް
    Private mstrCOMRecvArrayTerminator As String    '��M���Ȱ�
    'EQ�رْʐM�p(���̑�)
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




    '������MCV�p

    '����MCV�̎��ɑΉ�
    Private mFHENSU_IDAbnormal As String     '�ُ��׸�
    Private mFHENSU_IDSeqNoSend As String    '���M���ݽ��
    Private mFHENSU_IDSeqNoRecv As String    '��M���ݽ��
    Private mstrTelConfigPath As String      'Confiģ���߽
    Private mstrONLINE_ID As String          '�ް��ݸ�m��ID
    Private mstrOFLINE_ID As String          '�ް��ݸ�ؒfID

    '���̑�
    Friend mblnCutFlag As Boolean            '�ް��ݸ�ؒf�׸�


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
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
    Private mdtmEQ_SendTimer_Before As Date         '�O�������₢���킹����
    Private mstrEQ_SendTimerTel_Before As String    '�O�������₢���킹�d��
    '������������************************************************************************************************************

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
            mobjSerial.intDebugFlag = Value                 '�رْʐM�׽
            mobjGetTelegram.intDebugFlag = mintDebugFlag    '�d���p÷�Ď擾�׽
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
            mobjDb.BeginTrans()     '��ݻ޸��݊J�n
            Try
                'Dim strMsg As String                    'ү����


                '*****************************************************
                '�F�X������
                '*****************************************************
                mdtmNow = Now


                '*****************************************************
                '�رْʐM�ް�           ��M
                '*****************************************************
                Dim strReceiveData As String = ""       '����Ɏ�M�ł����ް�
                Dim strResponsCode As String = ""       '��������
                mobjSerial.ReceiveText(strReceiveData, _
                                       strResponsCode, _
                                       clsMcvSerial.SerialKind.Recv)
                If strReceiveData <> "" Then AddToLog(MCIA_MSG_011 & strReceiveData) '�d���擾۸ޏo��


                '*****************************************************
                '�رْʐM����           ����
                '*****************************************************
                Call MCIA_100201(strReceiveData, strResponsCode)         'رْʐM��������


                '*****************************************************
                'DB���M�ޯ̧���� & �d�����M     ����
                '*****************************************************
                Call MCIA_100001(True)


                '*****************************************************
                '�رْʐM�����d��       �m�F
                '*****************************************************
                Dim strResponsData As String = ""       '����Ɏ�M�ł����ް�
                Dim strResponsCode2 As String = ""      '��������
                mobjSerial.ReceiveText(strResponsData, _
                                       strResponsCode2, _
                                       clsMcvSerial.SerialKind.Send)
                If strResponsData <> "" Then Call AddToLog(MCIA_MSG_RES011 & strResponsData) '�d���擾۸ޏo��


                '*****************************************************
                '�رْʐM������M       ����
                '*****************************************************
                Call MCIA_100202(strResponsData, strResponsCode2)                    '�رْʐM������M����


                '*****************************************************
                '���ނֿ��đ��M
                '*****************************************************
                Call MCI_000001()


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
    ''' <param name="objOwner">��Ű��޼ު��(���۸ޏ����݂Ɏg�p)</param>
    ''' <param name="objDb">�׸ِڑ��׽(�ʏ�p)</param>
    ''' <param name="objDbLog">�׸ِڑ��׽(۸ޗp)</param>
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
            mstrRecvTelBuff = ""                                '��M�ޯ̧
            mdtmNow = Now


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
    ''' ����������
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
        mobjEQSendResBuff = New TBL_TLIF_TRNS_SEND(mobjOwner, Nothing, Nothing)    '�����d�����M�ޯ̧
        mdtmBeforeConnTime = Now                        '�O��ڑ�����
        mobjGetTelegram = New clsGetTelegram(mobjOwner) '�d���p÷�Ď擾�׽


        '*****************************************************
        'Confiģ�ُ��擾(�W������)
        '*****************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MCIC)                              'Confiģ�ِڑ��׽����

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
        'EQ�رْʐM�p(���M�p)
        mstrCOMSendPort = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_SEND_PORT))                    '�߰Ĕԍ�
        mintCOMSendBaud = TO_NUMBER(objConfig.GET_INFO(GKEY_EQ_COM_SEND_BAUD))                    '�ʐM���x
        mstrCOMSendParity = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_SEND_PARITY))                '���è
        mintCOMSendDataLength = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_SEND_DATALENGTH))        '�ް���
        mstrCOMSendStopBit = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_SEND_STOPBIT))              '�į���ޯĒ�
        'EQ�رْʐM�p(��M�p)
        mstrCOMRecvPort = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_PORT))                    '�߰Ĕԍ�
        mintCOMRecvBaud = TO_NUMBER(objConfig.GET_INFO(GKEY_EQ_COM_RECV_BAUD))                    '�ʐM���x
        mstrCOMRecvParity = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_PARITY))                '���è
        mintCOMRecvDataLength = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_DATALENGTH))        '�ް���
        mstrCOMRecvStopBit = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_RECV_STOPBIT))              '�į���ޯĒ�
        'EQ�رْʐM�p(���̑�)
        mintCOMCodePage = TO_NUMBER(objConfig.GET_INFO(GKEY_EQ_COM_CODEPAGE))                     '�ʐM�Ɏg�p����÷�Ă̺���  (932:ShiftJIS)
        mstrCOMComName = TO_STRING(objConfig.GET_INFO(GKEY_EQ_COM_COMNAME))                       '�ʐM��


        '****************************************************
        '�رْʐM��޼ު��       ���
        '****************************************************
        mobjSerial = New clsMcvSerial(mobjOwner)                     '�رْʐM��޼ު��
        'EQ�رْʐM�p(���M�p)
        mobjSerial.strSendPort = mstrCOMSendPort                     '�߰Ĕԍ�
        mobjSerial.intSendBaud = mintCOMSendBaud                     '�ʐM���x
        mobjSerial.strSendParity = mstrCOMSendParity                 '���è
        mobjSerial.intSendDataLength = mintCOMSendDataLength         '�ް���
        mobjSerial.strSendStopBit = mstrCOMSendStopBit               '�į���ޯĒ�
        'EQ�رْʐM�p(��M�p)
        mobjSerial.strRecvPort = mstrCOMRecvPort                     '�߰Ĕԍ�
        mobjSerial.intRecvBaud = mintCOMRecvBaud                     '�ʐM���x
        mobjSerial.strRecvParity = mstrCOMRecvParity                 '���è
        mobjSerial.intRecvDataLength = mintCOMRecvDataLength         '�ް���
        mobjSerial.strRecvStopBit = mstrCOMRecvStopBit               '�į���ޯĒ�
        'EQ�رْʐM�p(���̑�)
        mobjSerial.intCodePage = mintCOMCodePage                     '�ʐM�Ɏg�p����÷�Ă̺���  (932:ShiftJIS)
        mobjSerial.intBCCUseFlag = FLAG_OFF                          'BCC�g�p�׸�       (0:�g�p���Ȃ��@�@1:�g�p����)
        mobjSerial.Open()                                            '�ʐM�m��


        '*****************************************************
        ' MCV32,33����
        '*****************************************************
        Select Case mstrFEQ_ID
            Case FEQ_ID_JSYS0003
                mFHENSU_IDAbnormal = FHENSU_ID_JSJ100000_001           '�ُ��׸�
                mFHENSU_IDSeqNoSend = FHENSU_ID_JSJ100000_002          '���M���ݽ��
                mFHENSU_IDSeqNoRecv = FHENSU_ID_JSJ100000_003          '��M���ݽ��
                mstrTelConfigPath = CONFIG_TELEGRAM_MCV                'Config���߽
                mstrONLINE_ID = FCOMMAND_ID_JMCV_000                   '�ް��ݸ�m��ID
                mstrOFLINE_ID = FCOMMAND_ID_JMCV_999                   '�ް��ݸ�ؒfID

                'Case FEQ_ID_MCV_C33
                '    mFHENSU_IDAbnormal = FHENSU_ID_MCV33_ABNORMAL           '�ُ��׸�
                '    mFHENSU_IDSeqNoSend = FHENSU_ID_MCV33_SEQNO_SEND        '���M���ݽ��
                '    mFHENSU_IDSeqNoRecv = FHENSU_ID_MCV33_SEQNO_RECV        '��M���ݽ��
                '    mstrTelConfigPath = CONFIG_TELEGRAM_MCV33               'Config���߽
                '    mstrONLINE_ID = FCOMMAND_ID_MCV_000_33                  '�ް��ݸ�m��ID
                '    mstrOFLINE_ID = FCOMMAND_ID_MCV_999_33                  '�ް��ݸ�ؒfID

        End Select


        '���������ŗL����
        '**********************************************************************************************************************


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


            '*****************************************************
            '�ʐM�װ�ǉ�
            '*****************************************************
            Call ErrorAdd(mstrFMSG_ID_ERR_SYS, ERR_MSG_01, objException.Message)


        Catch ex2 As Exception
            'NOP
        End Try
    End Sub
#End Region
#Region "  ү����۸ޒǉ�                    "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ү����۸ޒǉ�
    ''' </summary>
    ''' <param name="strFMSG_ID">ү����ID</param>
    ''' <param name="strFMSG_PRM1">���Ұ�1</param>
    ''' <param name="strFMSG_PRM2">���Ұ�2</param>
    ''' <param name="strFMSG_PRM3">���Ұ�3</param>
    ''' <param name="strFMSG_PRM4">���Ұ�4</param>
    ''' <param name="strFMSG_PRM5">���Ұ�5</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub ErrorAdd(ByVal strFMSG_ID As String _
                       , ByVal strFMSG_PRM1 As String _
                       , Optional ByVal strFMSG_PRM2 As String = Nothing _
                       , Optional ByVal strFMSG_PRM3 As String = Nothing _
                       , Optional ByVal strFMSG_PRM4 As String = Nothing _
                       , Optional ByVal strFMSG_PRM5 As String = Nothing _
                         )
        Try


            '***********************************
            '÷�ĕϊ�
            '***********************************
            strFMSG_PRM1 = SQL_ITEM(strFMSG_PRM1, 254)       '���Ұ�1
            strFMSG_PRM2 = SQL_ITEM(strFMSG_PRM2, 254)       '���Ұ�2
            strFMSG_PRM3 = SQL_ITEM(strFMSG_PRM3, 254)       '���Ұ�3
            strFMSG_PRM4 = SQL_ITEM(strFMSG_PRM4, 254)       '���Ұ�4
            strFMSG_PRM5 = SQL_ITEM(strFMSG_PRM4, 254)       '���Ұ�5


            '***********************************
            '۸ޏo��
            '***********************************
            Dim strMsg As String
            strMsg = ""
            strMsg &= strFMSG_PRM1
            If IsNull(strFMSG_PRM2) = False Then strMsg &= Space(10) & strFMSG_PRM2
            If IsNull(strFMSG_PRM3) = False Then strMsg &= Space(10) & strFMSG_PRM3
            If IsNull(strFMSG_PRM4) = False Then strMsg &= Space(10) & strFMSG_PRM4
            If IsNull(strFMSG_PRM5) = False Then strMsg &= Space(10) & strFMSG_PRM5
            Call AddToLog(strMsg)


            '***********************************
            '���������MIF �ǉ�
            '***********************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)
            objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                           '�ݔ�ID
            objTLIF_TRNS_RECV.FCOMMAND_ID = FCOMMAND_ID_SADD_MSG             '�����ID
            objTLIF_TRNS_RECV.FDENBUN_PRM1 = strFMSG_ID                     'ү����ID
            objTLIF_TRNS_RECV.FDENBUN_PRM2 = strFMSG_PRM1                   '���Ұ�1
            objTLIF_TRNS_RECV.FDENBUN_PRM3 = strFMSG_PRM2                   '���Ұ�2
            objTLIF_TRNS_RECV.FDENBUN_PRM4 = strFMSG_PRM3                   '���Ұ�3
            objTLIF_TRNS_RECV.FDENBUN_PRM5 = strFMSG_PRM4                   '���Ұ�4
            objTLIF_TRNS_RECV.FDENBUN_PRM6 = strFMSG_PRM5                   '���Ұ�5
            objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SEND                     '�i�����
            '' ''      objTLIF_TRNS_RECV.FRES_CD_EQ = FORMAT_PLC_RES_CD_OK             '�ݔ���������
            objTLIF_TRNS_RECV.FENTRY_DT = Now                               '�o�^����
            objTLIF_TRNS_RECV.FUPDATE_DT = Now                              '�X�V����
            objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()                      '�ǉ�
            mblnSockSend = True                                             '���đ��M�׸�


        Catch ex As Exception
            'NOP
        End Try
    End Sub
#End Region
#Region "  �ʐM�į��                        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ʐM�į��
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub StopCommunication()
        Try


            '***********************************
            '۸ޏo��
            '***********************************
            Dim strMsg As String
            strMsg = ""
            strMsg &= "�ʐM�į�߁B"
            Call AddToLog(strMsg)


            '***********************************
            '���������MIF �ǉ�
            '***********************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)
            objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                           '�ݔ�ID
            objTLIF_TRNS_RECV.FCOMMAND_ID = FCOMMAND_ID_SCUT_EQ              '�����ID
            objTLIF_TRNS_RECV.FDENBUN_PRM1 = mstrFEQ_ID                     'ү����ID
            objTLIF_TRNS_RECV.FDENBUN_PRM2 = Nothing                        '���Ұ�1
            objTLIF_TRNS_RECV.FDENBUN_PRM3 = Nothing                        '���Ұ�2
            objTLIF_TRNS_RECV.FDENBUN_PRM4 = Nothing                        '���Ұ�3
            objTLIF_TRNS_RECV.FDENBUN_PRM5 = Nothing                        '���Ұ�4
            objTLIF_TRNS_RECV.FDENBUN_PRM6 = Nothing                        '���Ұ�5
            objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SEND                     '�i�����
            '' ''      objTLIF_TRNS_RECV.FRES_CD_EQ = FORMAT_PLC_RES_CD_OK             '�ݔ���������
            objTLIF_TRNS_RECV.FENTRY_DT = Now                               '�o�^����
            objTLIF_TRNS_RECV.FUPDATE_DT = Now                              '�X�V����
            objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()                      '�ǉ�
            mblnSockSend = True                                             '���đ��M�׸�


        Catch ex As Exception
            'NOP
        End Try
    End Sub
#End Region
#Region "  MCI_000001  ���ނֿ��đ��M       "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ���ނֿ��đ��M
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCI_000001()
        Try

            '*****************************************************
            '���ނֿ��đ��M
            '*****************************************************
            If mstrSvrSockSendFlag = FLAG_ON Then
                '(Config�̿��đ��M�׸ނ������Ă���ꍇ)
                If mblnSockSend = True Then
                    '(���đ��M�׸ނ������Ă���ꍇ)
                    mobjDb.Commit()                                             '�Я�
                    mobjDb.BeginTrans()                                         '��ݻ޸��݊J�n
                    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
                    objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S210001   '̫�ϯĖ����
                    Call mobjSockSvr.SockSendServer(objTelegram)                '���đ��M
                    mblnSockSend = False                                        '���đ��M�׸�
                    mblnSockEnd = True                                          '���đ��M�����׸�
                    '' ''Call AddToLog("���đ��M**********************************************************************************")
                End If

            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ID:99    SQL���s                 "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ID:99    SQL���s
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">�������䑗�MIFð��ٸ׽</param>
    ''' <returns>����I���̗L��</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function IDSQLProcess(ByRef objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND) As RetCode
        Try
            Dim intRetSQL As Integer    'SQL���s�߂�l


            '***********************
            'SQL���s
            '***********************
            Try
                intRetSQL = mobjDb.Execute(objTLIF_TRNS_SEND.FDENBUN_PRM6)
            Catch ex As Exception
                intRetSQL = -1
            End Try
            If intRetSQL <> -1 Then
                '(SQL���s����)

                '*******************************************
                '�������MIF�X�V
                '*******************************************
                objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SEND                     '�i�����
                objTLIF_TRNS_SEND.FUPDATE_DT = Now                              '�X�V����
                objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()                       '�X�V

            Else
                '(SQL���s�װ)

                '*******************************************
                '�������MIF�X�V
                '*******************************************
                objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SERR_MCI                 '�i�����
                objTLIF_TRNS_SEND.FUPDATE_DT = Now                              '�X�V����
                objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()                       '�X�V

            End If


            '*******************************************
            '۸ޏo��
            '*******************************************
            Call AddToLog(MCI_MESSAGE_01 & objTLIF_TRNS_SEND.FDENBUN_PRM6)


            Return RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region

#Region "  ������DB��������                 "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ������DB��������
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub InitializeDBReadTimer()
        Dim dtmTemp As Date
        mdtmBeforeDBTime = dtmTemp
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


    '*******************
    'Public
    '*******************
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
    ''' �ް����M
    ''' </summary>
    ''' <param name="strSendText">���M÷��</param>
    ''' <param name="objTLIF_TRNS_SEND">�������䑗�MIFð��ٸ׽</param>
    ''' <returns>����I���̗L��</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function SendData(ByVal strSendText As String _
                           , ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND _
                           ) As RetCode
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
            mobjSerial.Send(strSendText, _
                            clsMcvSerial.SerialKind.Send)


            '*****************************************************
            '�đ��M�p�ް�     ���
            '*****************************************************
            mobjEQSendTelBuff.FDENBUN = strSendText        '�đ��M�p÷���ޯ̧
            mdtmBeforeSendTime = Now                        '�O�񑗐M����


            '*****************************************************
            '۸ޏo��
            '*****************************************************
            '===========================================
            '÷��۸ޒǉ�
            '===========================================
            Call AddToLog(MCIA_MSG_021 & strSendText)

            '===========================================
            '÷��ID�擾
            '===========================================
            Dim strFTEXT_ID As String = ""
            strFTEXT_ID = MID_SJIS(strSendText, 1, 16)

            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
            If mobjEQSendTelBuff.FENTRY_NO <> FENTRY_NO_SMCI_MYSELF Then
                '������������************************************************************************************************************
                Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)   '�ݔ��ʐM۸�
                objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '�ݔ�ID
                objTLOG_EQ.FHASSEI_DT = Now                         '��������
                objTLOG_EQ.FDIRECTION = FDIRECTION_SSEND            '����
                Select Case mobjEQSendTelBuff.FCOMMAND_ID
                    Case FCOMMAND_ID_SONLINE : objTLOG_EQ.FTEXT_ID = FTEXT_ID_JMCV_000      '÷��ID
                    Case FCOMMAND_ID_SOFFLINE : objTLOG_EQ.FTEXT_ID = FTEXT_ID_JMCV_999     '÷��ID
                    Case Else : objTLOG_EQ.FTEXT_ID = objTLIF_TRNS_SEND.FTEXT_ID            '÷��ID
                End Select
                objTLOG_EQ.FTRNS_SERIAL = DEFAULT_STRING            '�����ره�
                objTLOG_EQ.FPALLET_ID = DEFAULT_STRING              '��گ�ID
                objTLOG_EQ.FDENBUN = strSendText                    '�ʐM�d��
                objTLOG_EQ.FRES_CD_EQ = DEFAULT_STRING              '�ݔ���������
                objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '�ǉ�
                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
            End If
            '������������************************************************************************************************************


            Return intRet
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
#Region "  �ް���M(���񖢎g�p)             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ް���M
    ''' </summary>
    ''' <param name="strRecvText">��M÷��</param>
    ''' <remarks>����I���̗L��</remarks>
    '''*******************************************************************************************************************
    Public Sub RecvDataEQ(ByRef strRecvText As String)


        ''****************************************
        ''�d����M
        ''****************************************
        'mobjSerial.Receive()


        ''****************************************
        ''�d�������𒊏o & ��M�ޯ̧�X�V
        ''****************************************
        'If IsNotNull(mobjSerial.strRecvText) Then
        '    '(�d������M�����ꍇ)


        '    '****************************************
        '    '��M�ޯ̧�Ɍ���
        '    '****************************************
        '    If IsNull(mstrRecvTelBuff) Then
        '        mstrRecvTelBuff = mobjSerial.strRecvText
        '    Else
        '        mstrRecvTelBuff &= mobjSerial.strRecvText
        '    End If


        '    '****************************************
        '    '�d�������𒊏o & ��M�ޯ̧�X�V
        '    '****************************************
        '    strRecvText = mobjGetTelegram.GetTelegramSTXETX(mstrRecvTelBuff)
        '    If IsNotNull(strRecvText) Then
        '        Call AddToLog(MCIA_MSG_011 & strRecvText) '�d���擾۸ޏo��
        '    End If

        'End If


    End Sub
#End Region
#Region "  �����ް����M                     "
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����zstrSendText    �F���M÷��
    '�y�ߒl�z����I���̗L��
    '*******************************************************************************************************************
    Public Sub SendResponsData(ByVal strSendText As String)


        '*****************************************************
        '�A�����đ��M�o���Ȃ���Sleep
        '*****************************************************
        Threading.Thread.Sleep(mintSendSleep)


        '*****************************************************
        '÷���ް����M
        '*****************************************************
        mobjSerial.Send(strSendText, _
                        clsMcvSerial.SerialKind.Recv)


        '*****************************************************
        '�����d���ޯ̧�ɾ��
        '*****************************************************
        mobjEQSendResBuff.FDENBUN = strSendText


        '*****************************************************
        '۸ޏo��
        '*****************************************************
        '===========================================
        '÷��۸ޒǉ�
        '===========================================
        Call AddToLog(MCIA_MSG_RES021 & strSendText)

        '===========================================
        '÷��ID�擾
        '===========================================
        Dim strFTEXT_ID As String = ""
        strFTEXT_ID = MID_SJIS(strSendText, 1, 16)

        '������������************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
        If mobjEQSendTelBuff.FENTRY_NO <> FENTRY_NO_SMCI_MYSELF Then
            '������������************************************************************************************************************
            Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)   '�ݔ��ʐM۸�
            objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '�ݔ�ID
            objTLOG_EQ.FHASSEI_DT = Now                         '��������
            objTLOG_EQ.FDIRECTION = FDIRECTION_SSEND             '����
            objTLOG_EQ.FTEXT_ID = FTEXT_ID_SRE                  '÷��ID
            objTLOG_EQ.FTRNS_SERIAL = DEFAULT_STRING            '�����ره�
            objTLOG_EQ.FPALLET_ID = DEFAULT_STRING              '��گ�ID
            objTLOG_EQ.FDENBUN = strSendText                    '�ʐM�d��
            objTLOG_EQ.FRES_CD_EQ = DEFAULT_STRING              '�ݔ���������
            objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '�ǉ�
            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
        End If
        '������������************************************************************************************************************


    End Sub
#End Region

    '���ݽ���֌W
#Region "  ���M���ݽNo + 1"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z
    '�y�ߒl�z�Ȃ�
    '*******************************************************************************************************************
    Public Sub SeqNoSendUpdate()

        '*****************************************************
        '���M�pSeqNo  + 1
        '*****************************************************
        Dim intSeqPlus1 As Integer = SeqNoPlus1(GetSYS_HEN(mFHENSU_IDSeqNoSend))
        Call SetSYS_HEN(mFHENSU_IDSeqNoSend, intSeqPlus1)

    End Sub
#End Region
#Region "  ��M���ݽNo + 1"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z
    '�y�ߒl�z�Ȃ�
    '*******************************************************************************************************************
    Public Sub SeqNoRecvUpdate()

        '*****************************************************
        '���M�pSeqNo  + 1
        '*****************************************************
        Dim intSeqPlus1 As Integer = SeqNoPlus1(GetSYS_HEN(mFHENSU_IDSeqNoRecv))
        Call SetSYS_HEN(mFHENSU_IDSeqNoRecv, intSeqPlus1)

    End Sub
#End Region
#Region "  ���M���ݽNo - 1"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z
    '�y�ߒl�z�Ȃ�
    '*******************************************************************************************************************
    Public Sub SeqNoSendUpdateMinus()

        '*****************************************************
        '���M�pSeqNo  - 1
        '*****************************************************
        Dim intSeqMinus1 As Integer = SeqNoMinus1(GetSYS_HEN(mFHENSU_IDSeqNoSend))
        Call SetSYS_HEN(mFHENSU_IDSeqNoSend, intSeqMinus1)

    End Sub
#End Region
#Region "  ��M���ݽNo - 1"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z
    '�y�ߒl�z�Ȃ�
    '*******************************************************************************************************************
    Public Sub SeqNoRecvUpdateMinus()

        '*****************************************************
        '���M�pSeqNo  - 1
        '*****************************************************
        Dim intSeqMinus1 As Integer = SeqNoMinus1(GetSYS_HEN(mFHENSU_IDSeqNoRecv))
        Call SetSYS_HEN(mFHENSU_IDSeqNoRecv, intSeqMinus1)

    End Sub
#End Region
#Region "  ���ݽNo + 1          ����"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z[ IN ]intSeqNo         �F+ 1 ���鼰�ݽNo
    '�y�ߒl�z+ 1 �����l
    '*******************************************************************************************************************
    Public Function SeqNoPlus1(ByVal intSeqNo As Integer) As Integer
        Dim intRet As Integer

        Select Case intSeqNo
            Case 255
                intRet = 1
            Case Else
                intRet = intSeqNo + 1
        End Select

        Return (intRet)
    End Function
#End Region
#Region "  ���ݽNo - 1          ����"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z[ IN ]intSeqNo         �F- 1 ���鼰�ݽNo
    '�y�ߒl�z+ 1 �����l
    '*******************************************************************************************************************
    Public Function SeqNoMinus1(ByVal intSeqNo As Integer) As Integer
        Dim intRet As Integer

        Select Case intSeqNo
            Case 1
                intRet = 255
            Case Else
                intRet = intSeqNo - 1
        End Select

        Return (intRet)
    End Function
#End Region


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
    Private Sub MCIA_100002(ByVal strRecvText As String)
        Try
            Dim strMsg As String = ""       'ү����


            '*****************************************************
            '��M�d���L������
            '*****************************************************
            If strRecvText = "" Then Exit Sub
            mdtmBeforeRecvTime = Now


            '*****************************************************
            '��M�d������
            '*****************************************************
            Dim objTel As New clsTelegram(mstrTelConfigPath)
            objTel.FORMAT_ID = FORMAT_BCR_01                    '̫�ϯĖ����    (���ɉ��ł��ǂ�)
            objTel.TELEGRAM_PARTITION = strRecvText             '��������d�����
            objTel.PARTITION()                                  '�d������


            '*****************************************************
            '�y�ݔ��ʐM۸ށz             �ǉ�
            '*****************************************************
            Dim strFTEXT_ID As String = FTEXT_ID_JBCR_01     '÷��ID
            Dim blnLogAdd As Boolean = True                  '��M�d����۸ޏo�͂������ۂ����׸�
            ''������������************************************************************************************************************
            ''SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
            'If mobjEQSendTelBuff.FTEXT_ID <> FTEXT_ID_JLC_05 Or mstrEQ_SendTimerTel_Before <> strRecvText Then
            '    If mobjEQSendTelBuff.FTEXT_ID = FTEXT_ID_JLC_05 Then
            '        Call AddDBRecvLog_LOG(FTEXT_ID_JLC_05_00 _
            '                            , strRecvText _
            '                            , "" _
            '                            )
            '    Else
            '        '������������************************************************************************************************************

            Call AddDBRecvLog_LOG(strFTEXT_ID _
                                , strRecvText _
                                , "" _
                                )

            '        '������������************************************************************************************************************
            '        'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
            '    End If
            '    If mobjEQSendTelBuff.FTEXT_ID = FTEXT_ID_JLC_05 Then mstrEQ_SendTimerTel_Before = strRecvText
            'Else
            '    blnLogAdd = False
            'End If
            ''������������************************************************************************************************************



            Dim intFRES_CD_EQ As String = ""                    '���������MIFð��قɒǉ�����ݔ���������
            Dim strFDENBUN_PRM1 As String = Nothing             '�d�����Ұ�1
            Dim strFDENBUN_PRM2 As String = Nothing             '�d�����Ұ�2
            Select Case strFTEXT_ID
                Case "******************************" '�d����M�݂̂Ȃ̂ŁA���̏����͒ʂ�Ȃ�
                    '(�����d����M�̏ꍇ)


                    '*****************************************************
                    '���������MIFð��قɒǉ�����ݔ���������  �擾
                    '*****************************************************
                    intFRES_CD_EQ = GetFRES_CD_EQ(strRecvText)


                    '*****************************************************
                    '�y�������䑗�M����̪���z   �X�V
                    '*****************************************************
                    If mobjEQSendTelBuff.FENTRY_NO <> "" Then
                        Call UpdateSendFPROGRESS(FPROGRESS_SEND, intFRES_CD_EQ)      '�ʐM��ԕύX
                        strFDENBUN_PRM1 = mobjEQSendTelBuff.FTEXT_ID    '�d�����Ұ�1
                        strFDENBUN_PRM2 = mobjEQSendTelBuff.FDENBUN     '�d�����Ұ�2
                    End If


                    '*****************************************************
                    '�ʐM��Ԃ𑗐M�\��Ԃɂ���
                    '*****************************************************
                    mintResponsWait = FLAG_OFF                  '�����҂��׸�   ���
                    mintSendCount = 0                           '�đ��M��
                    mobjEQSendTelBuff.CLEAR_PROPERTY()         '�O�񑗐MDB���폜
                    Call InitializeDBReadTimer()                '������DB��������


                Case Else
                    '(�ʏ�̓d����M�̏ꍇ)

                    'NOP

            End Select


            '*****************************************************
            '�y�������䑗��M����̪���z   �ǉ�
            '*****************************************************
            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
            If blnLogAdd = True Then
                '������������************************************************************************************************************

                Call AddDBRecvLIF_TRNS_RECV(FCOMMAND_ID_SOT _
                                              , strRecvText _
                                              , strFTEXT_ID _
                                              , FPROGRESS_SEND _
                                              , intFRES_CD_EQ _
                                              , strFDENBUN_PRM1 _
                                              , strFDENBUN_PRM2 _
                                              )

                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
            End If
            '������������************************************************************************************************************


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  MCIA_100011  �����d����ѱ������      ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ��ѱ������
    ''' </summary>
    ''' <param name="strRET_CD">��M������������</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_100011(ByVal strRET_CD As String)
        Try


            '*****************************************************
            '�����׸�����
            '*****************************************************
            If mintResponsWait = FLAG_OFF Then Exit Sub


            If mintSendCount < mintSendRetry Then
                '(��ײ�̏ꍇ)


                '*****************************************************
                '��ײ���M
                '*****************************************************
                Dim udtRet As RetCode
                udtRet = SendData(mobjEQSendTelBuff.FDENBUN, mobjEQSendTelBuff)    '�d�����M
                mintSendCount += 1


            Else
                '(��ײ���ް�̏ꍇ)


                '*****************************************************
                '��ײ���ް
                '��ѱ�ď���
                '*****************************************************
                '========================================
                '�y�������䑗�M����̪���z   �X�V
                '========================================
                If mobjEQSendTelBuff.FENTRY_NO <> "" Then
                    '(���ނ���̓d���̏ꍇ)
                    Call UpdateSendFPROGRESS(FPROGRESS_STIMEOUT)        '�ʐM��ԕύX
                    Call UpdateSendFRES_CD_EQ(strRET_CD)                '�������ޒǉ�
                End If
                If IsNull(strRET_CD) Then
                    Call AddToLog(MCIA_MSG_031)
                    Call ErrorAdd(mstrFMSG_ID_ERR_USER, ERR_MSG_01, MCIA_MSG_031)
                End If

                '========================================
                '�ʐMΰ���
                '========================================
                Call CommunicationHold()


            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region

#Region "  MCIA_100001  DB���� & �d�����M        ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' DB���� �� �d�����M
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_100001(ByVal blnCheck As Boolean)
        Try
            Dim udtRet As RetCode

            '*****************************************************
            '�����׸�����
            '*****************************************************
            If mintResponsWait = FLAG_ON Then
                '(�����׸� = ON �̏ꍇ)
                Exit Sub
            End If


            '*****************************************************
            '��ѱ������
            '*****************************************************
            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
            If blnCheck = True Then
                '������������************************************************************************************************************


                '*****************************************************
                '��ϰ����
                '*****************************************************
                Dim objDiff As TimeSpan = mdtmBeforeDBTime.AddMilliseconds(mintDBReadTimer) - Now
                If 0 < objDiff.TotalMilliseconds Then
                    Exit Sub
                End If
                mdtmBeforeDBTime = Now


                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
            End If
            '������������************************************************************************************************************


            '********************************************************************************
            '�i����� = �ُ�I���@�������́A�ݔ��������� <> �u00�v��ں��ތ���
            '********************************************************************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(mobjOwner, mobjDb, mobjDbLog)
            objTLIF_TRNS_SEND.FEQ_ID = mstrFEQ_ID                           '�ݔ�ID
            udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_ERROR_RECORD()    '�i����� = �ُ�I���@�������́A�ݔ��������� <> �u00�v��ں��ތ���
            If udtRet = RetCode.OK Then
                Call AddToLog("���M�ُ킵��ں��ނ����݂���ׁA���M�����͍s���܂���B")
                Exit Sub
            End If
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)
            objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                           '�ݔ�ID
            udtRet = objTLIF_TRNS_RECV.GET_TLIF_TRNS_RECV_ERROR_RECORD()    '�ʐM�װں��ތ���
            If udtRet = RetCode.OK Then
                Call AddToLog("�ُ퉞�����ނ�ں��ނ����݂���ׁA���M�����͍s���܂���B")
                Exit Sub
            End If


            '*****************************************************
            '���M�ޯ̧      (�ʐM��� = ���M�� �� �����{)ں��ލX�V
            '*****************************************************
            Call Update_INTCOMM_STS_ACT()


            '*****************************************************
            '���M�ޯ̧����
            '*****************************************************
            If GetSYS_HEN(mFHENSU_IDAbnormal) = FLAG_OFF Then
                '(�ʐM�ُ�łȂ��ꍇ)

                '==========================================
                '�y�ݔ���ԁz   ��ײ݊m�F
                '==========================================
                Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(mobjOwner, mobjDb, mobjDbLog)
                objTSTS_EQ_CTRL.FEQ_ID = mstrFEQ_ID                 'MCV�ȸ���
                objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                  '�擾
                If objTSTS_EQ_CTRL.FEQ_CUT_STS = FLAG_OFF _
                   And objTSTS_EQ_CTRL.FEQ_STS = FEQ_STS_SMCI_ONLINE Then
                    '(�uMCV�v = �u��ײ݁v�̏ꍇ)

                    objTLIF_TRNS_SEND.FEQ_ID = mstrFEQ_ID
                    udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_LATEST()      '���M�ޯ̧����
                    If udtRet <> RetCode.OK Then
                        '(���M�ޯ̧���ް����Ȃ��ꍇ)
                        Exit Sub            '�E�o
                    End If

                Else
                    '(�uMCV�v = �u��ײ݁v�̏ꍇ)

                    objTLIF_TRNS_SEND.FEQ_ID = mstrFEQ_ID
                    udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_LATEST_FOFFLINE_FLAG()       '���M�ޯ̧����(��ײ��׸�=FLAG_ON�̂�)
                    If udtRet <> RetCode.OK Then
                        '(���M�ޯ̧���ް����Ȃ��ꍇ)
                        Exit Sub            '�E�o
                    End If
                End If

            End If
            Call SetSendBuff(objTLIF_TRNS_SEND)


            '*****************************************************
            'ID�ɂ���ĕ��� & ÷�đ��M
            '*****************************************************
            Dim strTelegram As String = ""          '���M�d��
            Select Case objTLIF_TRNS_SEND.FCOMMAND_ID
                Case FCOMMAND_ID_SONLINE             '��ײݗv��
                    udtRet = ID01Process(objTLIF_TRNS_SEND, strTelegram)

                Case FCOMMAND_ID_SOFFLINE            '��ײݗv��
                    udtRet = ID02Process(objTLIF_TRNS_SEND, strTelegram)

                Case FCOMMAND_ID_SSQL                'SQL���s
                    udtRet = IDSQLProcess(objTLIF_TRNS_SEND)
                    Exit Sub

                Case Else                           '���̑�
                    udtRet = IDZZProcess(objTLIF_TRNS_SEND, strTelegram)

            End Select


            '*****************************************************
            '�d�����M
            '*****************************************************
            If udtRet = RetCode.OK Then
                udtRet = SendData(strTelegram, objTLIF_TRNS_SEND)       '�d�����M
                mintSendCount = 1                                       '���M��(����)
            End If


            '*****************************************************
            '÷�đ��M���ʂɂ�菈���ύX
            '*****************************************************
            '����
            mdtmBeforeSendTime = Now                                        '�O�񑗐M����   ���

            Select Case udtRet
                Case RetCode.OK
                    '=========================================
                    '����
                    '=========================================
                    Call UpdateSendFPROGRESS(FPROGRESS_SACT)            '�������䑗�M����̪��.�ʐM���      ���
                    mintResponsWait = FLAG_ON                           '�����҂��׸�                       ���
                    Call SeqNoSendUpdate()                              '���ݽNo + 1                        ���

                Case Else
                    '=========================================
                    '�ُ�
                    '=========================================
                    Call UpdateSendFPROGRESS(FPROGRESS_SERR_MCI)        '�������䑗�M����̪��.�ʐM���      ���
                    mintResponsWait = FLAG_OFF                          '�����҂��׸�                       ���
                    '' ''Call SeqNoSendUpdate()                         '���ݽNo + 1                        ���
                    Call mobjEQSendTelBuff.CLEAR_PROPERTY()             '���M�ޯ̧                          �폜

            End Select


        Catch ex As Exception
            Me.ComError(ex)

        End Try
    End Sub
#End Region
#Region "  MCIA_100201  �رْʐM�d����M         ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �رْʐM�d����M
    ''' </summary>
    ''' <param name="strGetData">����Ɏ�M�ł����ް�</param>
    ''' <param name="strResponsCode">��������</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_100201(ByVal strGetData As String _
                          , ByVal strResponsCode As String _
                          )
        Try


            '*****************************************************
            '�رْʐM   ��M�d������
            '*****************************************************
            If strGetData = "" Then
                '(��M�d�������݂��Ȃ������ꍇ)
                Exit Sub
            End If


            ' '' ''*****************************************************
            ' '' ''�ް��ݸ�ؒf���́A�ް��ݸ�m�������󂯕t���Ȃ�
            ' '' ''*****************************************************
            '' ''If mblnCutFlag = True _
            '' ''   And strGetData <> MCV_ID_DIR_ONLINE Then
            '' ''    Exit Sub
            '' ''End If


            '*****************************************************
            '�رْʐM   ��M�d������
            '*****************************************************
            Dim objTel As New clsTelegram(mstrTelConfigPath)
            objTel.FORMAT_ID = mstrONLINE_ID                   '̫�ϯĖ����    (���ɉ��ł��ǂ�)
            objTel.TELEGRAM_PARTITION = strGetData             '��������d�����
            objTel.PARTITION()                                 '�d������


            '*****************************************************
            '����ɓd����M�o����������
            '*****************************************************
            If strResponsCode <> FRES_CD_EQ_SMCV_OK Then
                Call ReceiveDustProcess(strGetData, strResponsCode)

                Exit Sub
            End If


            '*****************************************************
            '�y�ݔ��ʐM۸ށz��M۸ޒǉ�
            '*****************************************************
            If strGetData = MCV_ID_DIR_ONLINE Or strGetData = MCV_ID_DIR_OFFLINE Then
                Call AddDBRecvLog_LOG(FORMAT_MCV & strGetData _
                                    , strGetData _
                                    , strResponsCode _
                                    )
            Else
                Call AddDBRecvLog_LOG(FORMAT_MCV & objTel.SELECT_HEADER("MCVID") _
                                    , strGetData _
                                    , strResponsCode _
                                    )
            End If


            '*****************************************************
            '���ݽNo  ����
            '*****************************************************
            If strResponsCode = FRES_CD_EQ_SMCV_OK Then     '����Ɏ�M���Ă��Ȃ�������Ӗ����Ȃ���

                Dim strRecvSeqNo As String          '��M�������ݽNo
                strRecvSeqNo = TO_STRING(objTel.SELECT_HEADER("MCVSEQ_NO"))
                If strRecvSeqNo <> MCV_ID_DIR_ONLINE _
                   And strRecvSeqNo <> MCV_ID_DIR_OFFLINE _
                   And strRecvSeqNo <> MCV_ID_DIR_TEL_READ_ERR _
                   And strRecvSeqNo <> MCV_ID_DIR_RES_READ_ERR Then

                    '���ݽNo�����s�v�ׁ̈A���ĉ�*********************************
                    If TO_NUMBER(strRecvSeqNo) = SeqNoMinus1(GetSYS_HEN(mFHENSU_IDSeqNoRecv)) Then
                        '(�O��Ɠ������ݽ���̏ꍇ)
                        strResponsCode = FRES_CD_EQ_SMCV_ER_ALREADY          '��M�ςݴװ
                    ElseIf TO_NUMBER(strRecvSeqNo) <> GetSYS_HEN(mFHENSU_IDSeqNoRecv) Then
                        '(���ݽ���װ�̏ꍇ)
                        strResponsCode = FRES_CD_EQ_SMCV_ER_SEQNO            'SEQ�����װ
                        Call AddToLog("���ݽ���װ[���Ғl:" & GetSYS_HEN(mFHENSU_IDSeqNoRecv) & "][�擾�l:" & TO_NUMBER(strRecvSeqNo) & "]")
                    End If
                    '���ݽNo�����s�v�ׁ̈A���ĉ�*********************************

                End If

                '���ݽNo = �u000�v����M������A���ݽNo��ؾ�Ă���
                If strRecvSeqNo = MCV_ID_DIR_ONLINE Then
                    SetSYS_HEN(mFHENSU_IDSeqNoRecv, 0)
                End If
            End If


            '*****************************************************
            'ID �ɂ���ĕ���
            '*****************************************************
            Dim strTRNS_SERIAL_NO_1 As String = ""
            Dim strPALLET_ID1 As String = ""
            Dim strResponsText As String = ""
            Dim strCMD_ID As String = objTel.SELECT_HEADER("MCVID")     '�����ID

            Select Case FORMAT_MCV & strCMD_ID
                Case FTEXT_ID_JMCV_000 _
                   , FTEXT_ID_JMCV_999 _
                   , FTEXT_ID_JMCV_A1 _
                   , FTEXT_ID_JMCV_A2 _
                   , FTEXT_ID_JMCV_A3 _
                   , FTEXT_ID_JMCV_A4 _
                   , FTEXT_ID_JMCV_B1 _
                   , FTEXT_ID_JMCV_B2 _
                   , FTEXT_ID_JMCV_B3 _
                   , FTEXT_ID_JMCV_B4 _
                   , FTEXT_ID_JMCV_B5 _
                   , FTEXT_ID_JMCV_B6 _
                   , FTEXT_ID_JMCV_B7 _
                   , FTEXT_ID_JMCV_B8 _
                   , FTEXT_ID_JMCV_B9 _
                   , FTEXT_ID_JMCV_BA _
                   , FTEXT_ID_JMCV_C1 _
                   , FTEXT_ID_JMCV_C2 _
                   , FTEXT_ID_JMCV_C3 _
                   , FTEXT_ID_JMCV_C4 _
                   , FTEXT_ID_JMCV_C5 _
                   , FTEXT_ID_JMCV_C6 _
                   , FTEXT_ID_JMCV_C7 _
                   , FTEXT_ID_JMCV_C8 _
                   , FTEXT_ID_JMCV_D1 _
                   , FTEXT_ID_JMCV_D2


                    '*****************************************************
                    '�����d���쐬
                    '*****************************************************
                    strResponsText = ""
                    strResponsText &= objTel.SELECT_HEADER("MCVSEQ_NO")     '���ݽNo
                    strResponsText &= strResponsCode                         '��������


                    'Case FCOMMAND_ID_MCV_A1                             '��ԕ�A1
                    '    Call A1Process(strGetData, strResponsCode, strTRNS_SERIAL_NO_1, strPALLET_ID1, strResponsText)

                    'Case FCOMMAND_ID_MCV_A2                             '��ԕ�A2
                    '    Call A2Process(strGetData, strResponsCode, strTRNS_SERIAL_NO_1, strPALLET_ID1, strResponsText)

                    'Case FCOMMAND_ID_MCV_C1                             '����������1
                    '    Call C1Process(strGetData, strResponsCode, strTRNS_SERIAL_NO_1, strPALLET_ID1, strResponsText)

                    'Case FCOMMAND_ID_MCV_C2                             '����������2
                    '    Call C2Process(strGetData, strResponsCode, strTRNS_SERIAL_NO_1, strPALLET_ID1, strResponsText)

                    'Case FCOMMAND_ID_MCV_C3                             '���iPL������
                    '    Call C3Process(strGetData, strResponsCode, strTRNS_SERIAL_NO_1, strPALLET_ID1, strResponsText)

                    'Case FCOMMAND_ID_MCV_C4                             '��ݾٕ�
                    '    Call C4Process(strGetData, strResponsCode, strTRNS_SERIAL_NO_1, strPALLET_ID1, strResponsText)

                    'Case FCOMMAND_ID_MCV_C5                             '�Č���PL������
                    '    Call C5Process(strGetData, strResponsCode, strTRNS_SERIAL_NO_1, strPALLET_ID1, strResponsText)

                Case Else                                           '�s����ID
                    Dim strRecvSeqNo As String          '��M�������ݽNo
                    strRecvSeqNo = TO_STRING(objTel.SELECT_HEADER("MCVSEQ_NO"))
                    Select Case strRecvSeqNo
                        Case MCV_ID_DIR_ONLINE          '�ް��ݸ�m��
                            Call Receive000Process(strGetData, strResponsCode)
                            Exit Sub

                        Case MCV_ID_DIR_OFFLINE         '�ް��ݸ�ؒf
                            Call Receive999Process(strGetData, strResponsCode)
                            Exit Sub

                        Case MCV_ID_DIR_TEL_READ_ERR, MCV_ID_DIR_RES_READ_ERR   '�đ��M�v��
                            Call Receive777Process(strGetData, strResponsCode)
                            Exit Sub

                        Case Else
                            Call XXProcess(strGetData, strResponsCode)
                            Exit Sub

                    End Select

            End Select


            '*****************************************************
            '�����d�����M
            '*****************************************************
            Call SendResponsData(strResponsText)


            '**********************************************************************************************************
            '**********************************************************************************************************
            '�y�������䑗��M����̪���z   �ǉ�
            '    �����d�����܂Ƃ߂đ��M����Ă��鎖����̂ŁAID�œd�����𔻒f���āA��������
            '**********************************************************************************************************
            '**********************************************************************************************************
            Dim strWork01GetData As String = strGetData         '����Ɏ�M�ł����ް�(��Ɨp)
            Dim strWork02GetData As String = ""                 '����������̓d��
            While 3 < GET_BYTE_LENGTH_STRING(strWork01GetData)
                '(ٰ��:�S�Ă̓d������������܂�)

                '===========================================
                '�d����؂�o��
                '===========================================
                Dim strWorkCMD_ID As String = MID_SJIS(strWork01GetData, 4, 2)  '�����ID
                Dim blnCMD_IDErr As String = False                              '�����ID�װ�׸�
                Select Case FORMAT_MCV & strWorkCMD_ID
                    Case FTEXT_ID_JMCV_A1 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 84)
                    Case FTEXT_ID_JMCV_A2 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 32)
                    Case FTEXT_ID_JMCV_A3 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 10)
                    Case FTEXT_ID_JMCV_A4 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 10)
                    Case FTEXT_ID_JMCV_C1 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 21)
                    Case FTEXT_ID_JMCV_C2 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 21)
                    Case FTEXT_ID_JMCV_C3 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 21)
                        'Case FTEXT_ID_JMCV_C4 : strWork02GetData = MID_SJIS(strWork01GetData, 1, )
                    Case FTEXT_ID_JMCV_C5 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 21)
                    Case FTEXT_ID_JMCV_C6 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 13)
                    Case FTEXT_ID_JMCV_C7 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 22)
                    Case FTEXT_ID_JMCV_C8 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 18)
                    Case FTEXT_ID_JMCV_D1 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 8)
                    Case FTEXT_ID_JMCV_D2 : strWork02GetData = MID_SJIS(strWork01GetData, 1, 8)
                    Case Else
                        '(�\�z�O��÷�ēd���������ꍇ)
                        strWork02GetData = strWork01GetData
                        blnCMD_IDErr = True
                End Select

                '===========================================
                '�y�������䑗��M����̪���z   �ǉ�
                '===========================================
                Dim strFDENBUN_PRM1 As String = ""             '�d�����Ұ�1
                Dim strFDENBUN_PRM2 As String = ""             '�d�����Ұ�2
                Call AddDBRecvLIF_TRNS_RECV(FCOMMAND_ID_SOT _
                                          , strWork02GetData _
                                          , FORMAT_MCV & strWorkCMD_ID _
                                          , FPROGRESS_SEND _
                                          , strResponsCode _
                                          , strFDENBUN_PRM1 _
                                          , strFDENBUN_PRM2 _
                                          )

                '===========================================
                '���̕����p�d���쐬
                '===========================================
                If blnCMD_IDErr = False Then
                    '(�����ID����̏ꍇ)
                    strWork01GetData = MID_SJIS(strGetData, 1, 3) & MID_SJIS(strWork01GetData, GET_BYTE_LENGTH_STRING(strWork02GetData) + 1)
                Else
                    '(�����ID�ُ�̏ꍇ)
                    '��ɂ������̏������s���Ηǂ���������Ȃ����A�d���̒��ɺ����ID�����R�����Ă��܂��ƁA����Ȑ؂����Ƃ��s���̂ŁA�������͂����܂Ŕ�펞�p

                    '���̺����ID������
                    Dim intAryPos(12) As Integer
                    intAryPos(0) = InStr(6, strWork01GetData, "A1")
                    intAryPos(1) = InStr(6, strWork01GetData, "A2")
                    intAryPos(2) = InStr(6, strWork01GetData, "A3")
                    intAryPos(3) = InStr(6, strWork01GetData, "A4")
                    intAryPos(4) = InStr(6, strWork01GetData, "C1")
                    intAryPos(5) = InStr(6, strWork01GetData, "C2")
                    intAryPos(6) = InStr(6, strWork01GetData, "C3")
                    intAryPos(7) = InStr(6, strWork01GetData, "C5")
                    intAryPos(8) = InStr(6, strWork01GetData, "C6")
                    intAryPos(9) = InStr(6, strWork01GetData, "C7")
                    intAryPos(10) = InStr(6, strWork01GetData, "C8")
                    intAryPos(11) = InStr(6, strWork01GetData, "D1")
                    intAryPos(12) = InStr(6, strWork01GetData, "D2")

                    '���̓d���̊J�n�ʒu���擾
                    Dim intPosNext As Integer = 0      '���̓d���̊J�n�ʒu
                    For Each intPos As Integer In intAryPos
                        '(ٰ��:�������Ă�������ID�̐�)

                        If intPos = 0 Then Continue For
                        If intPosNext = 0 Then
                            intPosNext = intPos
                        Else
                            If intPos < intPosNext Then
                                intPosNext = intPos
                            End If
                        End If

                    Next
                    If intPosNext = 0 Then Exit While

                    '���̓d�����擾
                    strWork01GetData = MID_SJIS(strGetData, 1, 3) & MID_SJIS(strWork01GetData, intPosNext)

                End If


            End While

            'Dim strFDENBUN_PRM1 As String = ""             '�d�����Ұ�1
            'Dim strFDENBUN_PRM2 As String = ""             '�d�����Ұ�2
            'Call AddDBRecvLIF_TRNS_RECV(FCOMMAND_ID_SOT _
            '                          , strGetData _
            '                          , FORMAT_MCV & strCMD_ID _
            '                          , FPROGRESS_SEND _
            '                          , strResponsCode _
            '                          , strFDENBUN_PRM1 _
            '                          , strFDENBUN_PRM2 _
            '                          )


            ''*****************************************************
            ''�yMCV�ʐM۸ށz             �ǉ�
            ''*****************************************************
            ''��M�d��۸�
            'Call AddDBRecvLog_LOG_MCV(strCMD_ID, _
            '                          strGetData, _
            '                          strResponsCode, _
            '                          strTRNS_SERIAL_NO_1, _
            '                          strPALLET_ID1 _
            '                          )
            ''�����d��۸�
            'Call AddDBSendResponsLog_LOG_MCV(FCOMMAND_ID_JMCV_RESPONS, _
            '                                 strResponsText, _
            '                                 strResponsCode, _
            '                                 "", _
            '                                 "" _
            '                                 )


            '*****************************************************
            '��M�pSeqNo    �X�V
            '*****************************************************
            If strResponsCode = FRES_CD_EQ_SMCV_OK Then
                Call SeqNoRecvUpdate()              '��M���ݽNo + 1
                ''mintRecvSEQNo = intSeqNo_Recv       '��M�������ݽNo�ɕύX
            End If


        Catch ex As Exception
            Me.ComError(ex)

        End Try
    End Sub
#End Region
#Region "  MCIA_100202  �رْʐM������M         ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �رْʐM������M
    ''' </summary>
    ''' <param name="strGetData">����Ɏ�M�ł����ް�</param>
    ''' <param name="strResponsCode">��������(�g�p���Ă��Ȃ�)</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_100202(ByVal strGetData As String _
                          , ByVal strResponsCode As String _
                          )
        Try

            '*****************************************************
            '�����׸�����
            '*****************************************************
            If mintResponsWait = FLAG_OFF Then
                '(�����׸� = OFF �̏ꍇ)
                Exit Sub
            End If


            '*****************************************************
            '�����d���L������
            '*****************************************************
            Select Case strGetData
                Case ""
                    '=========================================
                    '�����d���Ȃ�    (�E�o)
                    '=========================================
                    Call MCV_Respons_Nothing()
                    Exit Sub
                Case Else
                    '�������Ȃ�
            End Select


            '*****************************************************
            '�رْʐM   ��M�d������
            '*****************************************************
            Dim objTel As New clsTelegram(mstrTelConfigPath)
            Dim strRET_CD As String                             '��������
            objTel.FORMAT_ID = mstrONLINE_ID                    '̫�ϯĖ����    (���ɉ��ł��ǂ�)
            objTel.TELEGRAM_PARTITION = strGetData              '��������d�����
            objTel.PARTITION()                                  '�d������
            strRET_CD = TO_STRING(objTel.SELECT_HEADER("MCVID"))    '��������


            '*****************************************************
            '�y�ݔ��ʐM۸ށz��M۸ޒǉ�
            '*****************************************************
            Call AddDBRecvLog_LOG(FCOMMAND_ID_JMCV_RESPONS _
                                , strGetData _
                                , strResponsCode _
                                )


            '*****************************************************
            '����ɓd������M�o����������
            '*****************************************************
            If strResponsCode <> FRES_CD_EQ_SMCV_OK Then
                '==========================================
                '�����d���đ��M�v��   (�E�o)
                '==========================================
                Call MCV_Respons_Dust()

                '' '' ''Dim str777Text As String        '�đ��M�v��÷��
                '' '' ''str777Text = ""
                '' '' ''str777Text &= "777"             '�đ��M�v��÷��
                '' '' ''Call SendDataMCV(str777Text)

                Exit Sub
            End If


            '*****************************************************
            '���ݽNo    ����
            '*****************************************************
            If mobjEQSendTelBuff.FDENBUN <> MCV_ID_DIR_ONLINE _
               And mobjEQSendTelBuff.FDENBUN <> MCV_ID_DIR_OFFLINE Then

                Dim intSeqNo_Recv As Integer = TO_NUMBER(objTel.SELECT_HEADER("MCVSEQ_NO"))    '��M�������ݽNo
                Select Case intSeqNo_Recv
                    Case SeqNoMinus1(GetSYS_HEN(mFHENSU_IDSeqNoSend))
                        '�������Ȃ�

                    Case 0
                        '�������Ȃ�

                    Case 999
                        '�������Ȃ�

                    Case 777, 888
                        '=========================================
                        '�������� = �ُ�
                        '=========================================
                        Call MCIA_100011(strRET_CD)
                        Exit Sub
                        '' '' ''Case 0
                        '' '' ''    mintRecvSEQNo = 1

                    Case Else
                        '=========================================
                        '���ݽNo�ُ�
                        '=========================================
                        Call MCIA_100011(strRET_CD)
                        Exit Sub

                End Select
            End If


            '*****************************************************
            '��������       ����
            '*****************************************************
            Select Case strRET_CD
                Case FRES_CD_EQ_SMCV_OK
                    '' ''Case FRES_CD_EQ_MCV_OK, FRES_CD_EQ_MCV_ER_SEQNO, FRES_CD_EQ_MCV_ER_ALREADY
                    '=========================================
                    '�������� = ����
                    '=========================================
                    Call MCV_Respons_OK(strRET_CD)


                Case Else
                    '=========================================
                    '�������� = �ُ�
                    '=========================================
                    Call MCIA_100011(strRET_CD)


            End Select


        Catch ex As Exception
            Me.ComError(ex)

        End Try
    End Sub
#End Region

    '��������         ID����
#Region "  ����             ��M"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����zstrRET_CD      �F��M������������
    '�y�ߒl�z
    '*******************************************************************************************************************
    Private Sub MCV_Respons_OK(ByVal strRET_CD As String)

        '*****************************************************
        '�y�������䑗�M����̪���z   �X�V
        '*****************************************************
        If mobjEQSendTelBuff.FENTRY_NO <> "" Then
            Call UpdateSendFPROGRESS(FPROGRESS_SEND)    '�ʐM��ԕύX
            Call UpdateSendFRES_CD_EQ(strRET_CD)        '�������ޒǉ�
        End If


        '*****************************************************
        '�ʐM��Ԃ𑗐M�\��Ԃɂ���
        '*****************************************************
        mintResponsWait = FLAG_OFF                  '�����҂��׸�   ���
        mintSendCount = 0                           '�đ��M��
        mobjEQSendTelBuff.CLEAR_PROPERTY()          '�O�񑗐MDB���폜
        SetSYS_HEN(mFHENSU_IDAbnormal, FLAG_OFF)    '�ُ��׸�(True�̎��́A"000"�������M���Ȃ�)


    End Sub
#End Region
#Region "  �����Ȃ�         ��M"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z
    '�y�ߒl�z
    '*******************************************************************************************************************
    Private Sub MCV_Respons_Nothing()


        '*****************************************************
        '��ѱ������
        '*****************************************************
        If 0 < mintSendTimeout Then
            '(EQ�������đҋ@���Ԃ���Ă���Ă���ꍇ)

            Dim objDiff As TimeSpan = mdtmBeforeSendTime.AddMilliseconds(mintSendTimeout) - Now
            If 0 < objDiff.TotalMilliseconds Then
                Exit Sub
            End If

        End If


        '*****************************************************
        '�đ��M����
        '*****************************************************
        Call MCIA_100011("")


    End Sub
#End Region
#Region "  ���������d��     ��M"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z
    '�y�ߒl�z
    '*******************************************************************************************************************
    Private Sub MCV_Respons_Dust()

        '*****************************************************
        '�ޯ̧�Ɂu777�v��}�����āA�đ��M
        '*****************************************************
        mobjEQSendTelBuff.FCOMMAND_ID = MCV_ID_DIR_TEL_READ_ERR
        mobjEQSendTelBuff.FDENBUN = MCV_ID_DIR_TEL_READ_ERR

        Call MCIA_100011("")


    End Sub
#End Region
#Region "  ���ݽNo�ُ�      ��M"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����zstrRET_CD      �F��M������������
    '�y�ߒl�z
    '*******************************************************************************************************************
    Private Sub MCV_Respons_SEQNoError(ByVal strRET_CD As String)

        '*****************************************************
        '�y�������䑗�M����̪���z   �X�V
        '*****************************************************
        If mobjEQSendTelBuff.FENTRY_NO <> "" Then
            Call UpdateSendFPROGRESS(FPROGRESS_SNON)        '�ʐM��ԕύX
        End If


        '*****************************************************
        '�ʐM��Ԃ𑗐M�\��Ԃɂ���
        '*****************************************************
        mintResponsWait = FLAG_OFF                  '�����҂��׸�   ���
        mintSendCount = 0                           '�đ��M��
        SetSYS_HEN(mFHENSU_IDAbnormal, FLAG_OFF)    '�ُ��׸�(True�̎��́A"000"�������M���Ȃ�)
        mobjEQSendTelBuff.CLEAR_PROPERTY()          '�O�񑗐MDB���폜


        '*****************************************************
        '�ް��ݸ�m���d���𑗐M�ޯ̧�ɒǉ�
        '*****************************************************
        Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(mobjOwner, mobjDb, mobjDbLog)   '�������䑗�MIF�׽
        objTLIF_TRNS_SEND.FCOMMAND_ID = MCV_ID_DIR_ONLINE       '�����ID        :�ް��ݸ�m��
        objTLIF_TRNS_SEND.FDENBUN = MCV_ID_DIR_ONLINE           '�ʐM÷��
        objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SNON            '�ʐM���
        objTLIF_TRNS_SEND.FENTRY_DT = mdtmNow                   '�o�^����
        objTLIF_TRNS_SEND.FUPDATE_DT = mdtmNow                  '�X�V����
        objTLIF_TRNS_SEND.ADD_TLIF_TRNS_SEND_SEQ()              '�o�^

    End Sub
#End Region


#Region "  000 �ް��ݸ�m��              ��M    "
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z[ IN ]strGetData       �F����Ɏ�M�ł����ް�
    '        [ IN ]strResponsCode   �F��������
    '�y�ߒl�z
    '*******************************************************************************************************************
    Private Sub Receive000Process(ByVal strGetData As String, _
                                  ByVal strResponsCode As String)
        Try

            '*****************************************************
            '������
            '*****************************************************
            Call SetSYS_HEN(mFHENSU_IDSeqNoRecv, 1)
            mblnCutFlag = False


            '*****************************************************
            '�y���������M����̪���z   �ǉ�
            '*****************************************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)       '�������䑗�MIF�׽
            objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                       '�ݔ�ID
            objTLIF_TRNS_RECV.FCOMMAND_ID = FCOMMAND_ID_JMCV_000        '�����ID    :�ް��ݸ�ؒf
            objTLIF_TRNS_RECV.FTEXT_ID = FTEXT_ID_JMCV_000              '÷��ID
            objTLIF_TRNS_RECV.FDENBUN = strGetData                      '�ʐM÷��
            objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SEND                '�i�����
            objTLIF_TRNS_RECV.FRES_CD_EQ = FRES_CD_EQ_SMCV_OK           '�ݔ���������
            objTLIF_TRNS_RECV.FENTRY_DT = mdtmNow                       '�o�^����
            objTLIF_TRNS_RECV.FUPDATE_DT = mdtmNow                      '�X�V����
            objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()                  '�o�^


            '*****************************************************
            '�����d���쐬 & ���M
            '*****************************************************
            Dim strResponsText As String            '����÷��
            strResponsText = ""
            strResponsText &= MCV_ID_DIR_ONLINE     '�ް��ݸ�m��
            strResponsText &= FRES_CD_EQ_SMCV_OK     '��������
            Call SendResponsData(strResponsText)


            ''*****************************************************
            ''MCV�ʐM۸�                 ��M�d���ǉ�
            ''*****************************************************
            ''��M�d��۸�
            'Call AddDBRecvLog_LOG_MCV(MCV_ID_DIR_ONLINE, _
            '                          MCV_ID_DIR_ONLINE, _
            '                          strResponsCode _
            '                          )
            ''�����d��۸�
            'Call AddDBSendResponsLog_LOG_MCV(FCOMMAND_ID_JMCV_RESPONS, _
            '                                 strResponsText, _
            '                                 strResponsCode _
            '                                 )


        Catch ex As Exception
            Call AddToLog(MCIA_MSG_ERR_002 & "[" & strGetData & "]")
            Me.ComError(ex)
            strResponsCode = FRES_CD_EQ_SMCV_ER_FORMAT       '��������
            Dim strResponsText As String                    '����÷��
            strResponsText = ""
            strResponsText &= Mid(strGetData, 1, 3)         '���ݽ��
            strResponsText &= FRES_CD_EQ_SMCV_ER_FORMAT      '��������
            Call SendResponsData(strResponsText)

        End Try
    End Sub
#End Region
#Region "  999 �ް��ݸ�ؒf              ��M    "
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z[ IN ]strGetData       �F����Ɏ�M�ł����ް�
    '        [ IN ]strResponsCode   �F��������
    '�y�ߒl�z
    '*******************************************************************************************************************
    Private Sub Receive999Process(ByVal strGetData As String, _
                                  ByVal strResponsCode As String)
        Try

            '*****************************************************
            '������
            '*****************************************************
            Call SetSYS_HEN(mFHENSU_IDSeqNoRecv, 1)
            mblnCutFlag = True


            '*****************************************************
            '�y���������M����̪���z   �ǉ�
            '*****************************************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)       '�������䑗�MIF�׽
            objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                   '�ݔ�ID
            objTLIF_TRNS_RECV.FCOMMAND_ID = FCOMMAND_ID_JMCV_999    '�����ID    :�ް��ݸ�ؒf
            objTLIF_TRNS_RECV.FTEXT_ID = FTEXT_ID_JMCV_999          '÷��ID
            objTLIF_TRNS_RECV.FDENBUN = strGetData                  '�ʐM÷��
            objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SEND            '�ʐM���
            objTLIF_TRNS_RECV.FRES_CD_EQ = FRES_CD_EQ_SMCV_OK       '�ݔ���������
            objTLIF_TRNS_RECV.FENTRY_DT = mdtmNow                   '�o�^����
            objTLIF_TRNS_RECV.FUPDATE_DT = mdtmNow                  '�X�V����
            objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()              '�o�^


            '*****************************************************
            '�����d���쐬 & ���M
            '*****************************************************
            Dim strResponsText As String            '����÷��
            strResponsText = ""
            strResponsText &= MCV_ID_DIR_OFFLINE    '�ް��ݸ�m��
            strResponsText &= FRES_CD_EQ_SMCV_OK    '��������
            Call SendResponsData(strResponsText)


            ''*****************************************************
            ''MCV�ʐM۸�                 ��M�d���ǉ�
            ''*****************************************************
            ''��M�d��۸�
            'Call AddDBRecvLog_LOG_MCV(MCV_ID_DIR_OFFLINE, _
            '                          MCV_ID_DIR_OFFLINE, _
            '                          strResponsCode _
            '                          )
            ''�����d��۸�
            'Call AddDBSendResponsLog_LOG_MCV(FCOMMAND_ID_JMCV_RESPONS, _
            '                                 strResponsText, _
            '                                 strResponsCode _
            '                                 )


        Catch ex As Exception
            Call AddToLog(MCIA_MSG_ERR_002 & "[" & strGetData & "]")
            Me.ComError(ex)
            strResponsCode = FRES_CD_EQ_SMCV_ER_FORMAT      '��������
            Dim strResponsText As String                    '����÷��
            strResponsText = ""
            strResponsText &= Mid(strGetData, 1, 3)         '���ݽ��
            strResponsText &= FRES_CD_EQ_SMCV_ER_FORMAT     '��������
            Call SendResponsData(strResponsText)

        End Try
    End Sub
#End Region
#Region "  777 ���M��������M�װ        ��M    "
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z[ IN ]strGetData       �F����Ɏ�M�ł����ް�
    '        [ IN ]strResponsCode   �F��������
    '�y�ߒl�z
    '*******************************************************************************************************************
    Private Sub Receive777Process(ByVal strGetData As String, _
                                  ByVal strResponsCode As String)
        Try

            '*****************************************************
            '�����d���쐬 & ���M
            '*****************************************************
            Call SendResponsData(mobjEQSendResBuff.FDENBUN)


            ''*****************************************************
            ''MCV�ʐM۸�                 ��M�d���ǉ�
            ''*****************************************************
            ''��M�d��۸�
            'Call AddDBRecvLog_LOG_MCV(MCV_ID_DIR_TEL_READ_ERR, _
            '                          MCV_ID_DIR_TEL_READ_ERR, _
            '                          strResponsCode _
            '                          )
            ''�����d��۸�
            'Call AddDBSendResponsLog_LOG_MCV(FCOMMAND_ID_JMCV_RESPONS, _
            '                                 mobjEQSendResBuff.FDENBUN, _
            '                                 strResponsCode _
            '                                 )


        Catch ex As Exception
            Call AddToLog(MCIA_MSG_ERR_002 & "[" & strGetData & "]")
            Me.ComError(ex)
            strResponsCode = FRES_CD_EQ_SMCV_ER_FORMAT      '��������
            Dim strResponsText As String                    '����÷��
            strResponsText = ""
            strResponsText &= Mid(strGetData, 1, 3)         '���ݽ��
            strResponsText &= FRES_CD_EQ_SMCV_ER_FORMAT     '��������
            Call SendResponsData(strResponsText)

        End Try
    End Sub
#End Region
#Region "  888 ���������d����M         ��M    "
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z[ IN ]strGetData       �F����Ɏ�M�ł����ް�
    '        [ IN ]strResponsCode   �F��������
    '�y�ߒl�z
    '*******************************************************************************************************************
    Private Sub ReceiveDustProcess(ByVal strGetData As String, _
                                   ByVal strResponsCode As String)
        Try

            '*****************************************************
            '�����d�����M
            '*****************************************************
            Call SendResponsData(MCV_ID_DIR_RES_READ_ERR)


            ''*****************************************************
            ''MCV�ʐM۸�                 ��M�d���ǉ�
            ''*****************************************************
            ''��M�d��۸�
            'Call AddDBRecvLog_LOG_MCV(MCV_ID_DIR_RES_READ_ERR, _
            '                          strGetData, _
            '                          strResponsCode _
            '                          )
            ''�����d��۸�
            'Call AddDBSendResponsLog_LOG_MCV(FCOMMAND_ID_JMCV_RESPONS, _
            '                                 MCV_ID_DIR_RES_READ_ERR, _
            '                                 strResponsCode _
            '                                 )


        Catch ex As Exception
            Call AddToLog(MCIA_MSG_ERR_002 & "[" & strGetData & "]")
            Me.ComError(ex)
            strResponsCode = FRES_CD_EQ_SMCV_ER_FORMAT      '��������
            Dim strResponsText As String                    '����÷��
            strResponsText = ""
            strResponsText &= Mid(strGetData, 1, 3)         '���ݽ��
            strResponsText &= FRES_CD_EQ_SMCV_ER_FORMAT     '��������
            Call SendResponsData(strResponsText)

        End Try
    End Sub
#End Region
#Region "  XX  �s��ID�d����M           ��M    "
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z[ IN ]strGetData       �F����Ɏ�M�ł����ް�
    '        [ IN ]strResponsCode   �F��������
    '�y�ߒl�z
    '*******************************************************************************************************************
    Private Sub XXProcess(ByVal strGetData As String, _
                          ByVal strResponsCode As String)
        Try

            '*****************************************************
            '��M�d������
            '*****************************************************
            Dim objTel As New clsTelegram(mstrTelConfigPath)
            objTel.FORMAT_ID = FORMAT_MCV_A1                    '̫�ϯĖ����        (���ł��ǂ�)
            '' ''objTel.FORMAT_ID = MCV_ID_DIR_ONLINE                '̫�ϯĖ����        (���ł��ǂ�)
            objTel.TELEGRAM_PARTITION = strGetData              '��������d�����
            objTel.PARTITION()                                  '�d������


            '*****************************************************
            '�����d���쐬
            '*****************************************************
            Dim strResponsText As String            '����÷��
            strResponsCode = IIf(strResponsCode = FRES_CD_EQ_SMCV_OK, FRES_CD_EQ_SMCV_ER_ID, strResponsCode)
            strResponsText = ""
            strResponsText &= objTel.SELECT_HEADER("MCVSEQ_NO")  '���ݽNo
            strResponsText &= strResponsCode                         '��������


            '*****************************************************
            '�����d�����M
            '*****************************************************
            Call SendResponsData(strResponsText)


            ''*****************************************************
            ''MCV�ʐM۸�                 ��M�d���ǉ�
            ''*****************************************************
            ''��M�d��۸�
            'Call AddDBRecvLog_LOG_MCV(objTel.SELECT_HEADER("MCVID"), _
            '                          strGetData, _
            '                          strResponsCode _
            '                          )
            ''�����d��۸�
            'Call AddDBSendResponsLog_LOG_MCV(FCOMMAND_ID_JMCV_RESPONS, _
            '                                 strResponsText, _
            '                                 strResponsCode _
            '                                 )


        Catch ex As Exception
            Call AddToLog(MCIA_MSG_ERR_002 & "[" & strGetData & "]")
            Me.ComError(ex)
            strResponsCode = FRES_CD_EQ_SMCV_ER_FORMAT      '��������
            Dim strResponsText As String                    '����÷��
            strResponsText = ""
            strResponsText &= Mid(strGetData, 1, 3)         '���ݽ��
            strResponsText &= FRES_CD_EQ_SMCV_ER_FORMAT      '��������
            Call SendResponsData(strResponsText)

        End Try
    End Sub
#End Region




#Region "  �y�ݔ��ʐM۸ށz��M۸ޒǉ�     ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �y�ݔ��ʐM۸ށz��M۸ޒǉ�
    ''' </summary>
    ''' <param name="strFTEXT_ID">÷��ID</param>
    ''' <param name="strFDENBUN">�ʐM�d��</param>
    ''' <param name="strFRES_CD_EQ">�ݔ���������</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddDBRecvLog_LOG(ByVal strFTEXT_ID As String _
                              , ByVal strFDENBUN As String _
                              , ByVal strFRES_CD_EQ As String _
                                )

        '========================================
        'DB۸ޏo��
        '========================================
        Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)
        objTLOG_EQ.FLOG_NO = "1"                            '۸�No
        objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '�ݔ�ID
        objTLOG_EQ.FHASSEI_DT = Now                         '��������
        objTLOG_EQ.FDIRECTION = FDIRECTION_SRECV            '����
        objTLOG_EQ.FTEXT_ID = strFTEXT_ID                   '÷��ID
        objTLOG_EQ.FDENBUN = strFDENBUN                     '�ʐM÷��
        objTLOG_EQ.FRES_CD_EQ = strFRES_CD_EQ               '��������
        objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '�ǉ�


    End Sub
#End Region
#Region "  �y�������䑗�M����̪���z(�ʐM��� = �ʐM��)ں��ލX�V  ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �y�������䑗�M����̪���z(�ʐM��� = �ʐM��)ں��ލX�V
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub Update_INTCOMM_STS_ACT()
        Dim udtRet As RetCode       '�ߒl


        '*****************************************************
        '���M�ޯ̧����(�ʐM��� = �ʐM��)
        '*****************************************************
        Do
            '(ٰ�߁F(�ʐM��� = �ʐM��)��ں��ސ�)

            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(mobjOwner, mobjDb, mobjDbLog)
            objTLIF_TRNS_SEND.FEQ_ID = mstrFEQ_ID                               '�ݔ�ID
            udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_INTCOMM_STS_ACT()     '���M�ޯ̧����(�ʐM��� = �ʐM��)

            If udtRet = RetCode.OK Then
                '(�ʐM�J�n,�ʐM�I�����Ȃ� ���� �ʐM�ُ�łȂ��ꍇ)

                '====================================
                '�ʐM��� = �����ρ@�X�V
                '====================================
                objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SNON                 '�ʐM��� = �����{
                objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()                   '�X�V

                '====================================
                '۸ޏo��
                '====================================
                Dim strMessage As String = ""
                strMessage &= "���M����ں��ނ����݂����ׁA�đ��M���܂��B"
                strMessage &= "       �o�^No�F" & objTLIF_TRNS_SEND.FENTRY_NO
                strMessage &= "      �����ID�F" & objTLIF_TRNS_SEND.FCOMMAND_ID
                strMessage &= "     �ʐM÷�āF" & objTLIF_TRNS_SEND.FDENBUN
                Call AddToLog(strMessage)

            End If

        Loop While udtRet = RetCode.OK


    End Sub
#End Region
#Region "  �y�������䑗�M����̪���z�i����ԁ@      �X�V����(���M���p)"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �y�������䑗�M����̪���z�i����ԁ@      �X�V����(���M���p)
    ''' </summary>
    ''' <param name="intFPROGRESS">�ݒ肷��i�����</param>
    ''' <param name="strFRES_CD_EQ">�ݒ肷��ݔ���������</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub UpdateSendFPROGRESS(ByVal intFPROGRESS As Integer _
                                  , Optional ByVal strFRES_CD_EQ As String = Nothing _
                                   )
        Try

            '*****************************************************
            '�y�������䑗�M����̪���z   �X�V
            '*****************************************************
            If mobjEQSendTelBuff.FENTRY_NO <> "" And mobjEQSendTelBuff.FENTRY_NO <> FENTRY_NO_SMCI_MYSELF Then
                Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(mobjOwner, mobjDb, mobjDbLog)
                objTLIF_TRNS_SEND.FENTRY_NO = mobjEQSendTelBuff.FENTRY_NO      '�o�^No     ���
                objTLIF_TRNS_SEND.FEQ_ID = mobjEQSendTelBuff.FEQ_ID            '�ݔ�ID
                objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND(False)                     '���擾

                objTLIF_TRNS_SEND.FPROGRESS = intFPROGRESS      '�i�����
                objTLIF_TRNS_SEND.FRES_CD_EQ = strFRES_CD_EQ    '�ݔ���������
                objTLIF_TRNS_SEND.FUPDATE_DT = mdtmNow          '�X�V����
                objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()       '�X�V
            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  �y�������䑗�M����̪���z�ݔ���������    �X�V����(���M���p)"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �y�������䑗�M����̪���z�ݔ���������    �X�V����(���M���p)
    ''' </summary>
    ''' <param name="strFRES_CD_EQ">�ݒ肷��ݔ���������</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub UpdateSendFRES_CD_EQ(ByVal strFRES_CD_EQ As String)
        Try

            '*****************************************************
            '�y�������䑗�M����̪���z   �X�V
            '*****************************************************
            If mobjEQSendTelBuff.FENTRY_NO <> "" And mobjEQSendTelBuff.FENTRY_NO <> FENTRY_NO_SMCI_MYSELF Then
                Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(mobjOwner, mobjDb, mobjDbLog)
                objTLIF_TRNS_SEND.FENTRY_NO = mobjEQSendTelBuff.FENTRY_NO      '�o�^No     ���
                objTLIF_TRNS_SEND.FEQ_ID = mobjEQSendTelBuff.FEQ_ID            '�ݔ�ID
                objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND(False)                     '���擾

                objTLIF_TRNS_SEND.FRES_CD_EQ = strFRES_CD_EQ    '�ݔ���������
                objTLIF_TRNS_SEND.FUPDATE_DT = mdtmNow          '�X�V����
                objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()       '�X�V
            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  �y���������M����̪���z�ǉ�         ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �y���������M����̪���z�ǉ�
    ''' </summary>
    ''' <param name="strFCOMMAND_ID">�����ID</param>
    ''' <param name="strFDENBUN">�ʐM�d��</param>
    ''' <param name="strFTEXT_ID">÷��ID</param>
    ''' <param name="intFPROGRESS">�i�����</param>
    ''' <param name="intFRES_CD_EQ">�ݔ���������</param>
    ''' <param name="strFDENBUN_PRM1">�d�����Ұ�1</param>
    ''' <param name="strFDENBUN_PRM2">�d�����Ұ�2</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddDBRecvLIF_TRNS_RECV(ByVal strFCOMMAND_ID As String _
                                    , ByVal strFDENBUN As String _
                                    , ByVal strFTEXT_ID As String _
                                    , ByVal intFPROGRESS As String _
                                    , ByVal intFRES_CD_EQ As String _
                                    , ByVal strFDENBUN_PRM1 As String _
                                    , ByVal strFDENBUN_PRM2 As String _
                                      )

        '*****************************************************
        '�y���������M����̪���z         �ǉ�
        '*****************************************************
        Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)
        objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                   '�ݔ�ID
        objTLIF_TRNS_RECV.FCOMMAND_ID = strFCOMMAND_ID          '�����ID
        objTLIF_TRNS_RECV.FTEXT_ID = strFTEXT_ID                '÷��ID
        objTLIF_TRNS_RECV.FDENBUN_PRM1 = strFDENBUN_PRM1        '�d�����Ұ�1
        objTLIF_TRNS_RECV.FDENBUN_PRM2 = strFDENBUN_PRM2        '�d�����Ұ�2
        objTLIF_TRNS_RECV.FDENBUN = strFDENBUN                  '�ʐM÷��
        objTLIF_TRNS_RECV.FPROGRESS = intFPROGRESS              '�i�����
        objTLIF_TRNS_RECV.FRES_CD_EQ = intFRES_CD_EQ            '�ݔ���������
        objTLIF_TRNS_RECV.FENTRY_DT = mdtmNow                   '�o�^����
        objTLIF_TRNS_RECV.FUPDATE_DT = mdtmNow                  '�X�V����
        objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()              '�X�V
        mblnSockSend = True                                     '���đ��M�׸�


    End Sub
#End Region
#Region "  �d�����M�ޯ̧��޼ު�Ăɾ��           ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �d�����M�ޯ̧��޼ު�Ă��ް����
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">�������䑗�MIFð��ٸ׽</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub SetSendBuff(ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND)

        mobjEQSendTelBuff.CLEAR_PROPERTY()
        mobjEQSendTelBuff.FENTRY_NO = objTLIF_TRNS_SEND.FENTRY_NO                  '�o�^��
        mobjEQSendTelBuff.FEQ_ID = objTLIF_TRNS_SEND.FEQ_ID                        '�ݔ�ID
        mobjEQSendTelBuff.FCOMMAND_ID = objTLIF_TRNS_SEND.FCOMMAND_ID              '�����ID
        mobjEQSendTelBuff.FPALLET_ID = objTLIF_TRNS_SEND.FPALLET_ID                '��گ�ID
        mobjEQSendTelBuff.FTEXT_ID = objTLIF_TRNS_SEND.FTEXT_ID                    '÷��ID
        mobjEQSendTelBuff.FDENBUN_PRM1 = objTLIF_TRNS_SEND.FDENBUN_PRM1            '�d�����Ұ�1
        mobjEQSendTelBuff.FDENBUN_PRM2 = objTLIF_TRNS_SEND.FDENBUN_PRM2            '�d�����Ұ�2
        mobjEQSendTelBuff.FDENBUN_PRM3 = objTLIF_TRNS_SEND.FDENBUN_PRM3            '�d�����Ұ�3
        mobjEQSendTelBuff.FDENBUN_PRM4 = objTLIF_TRNS_SEND.FDENBUN_PRM4            '�d�����Ұ�4
        mobjEQSendTelBuff.FDENBUN_PRM5 = objTLIF_TRNS_SEND.FDENBUN_PRM5            '�d�����Ұ�5
        mobjEQSendTelBuff.FDENBUN_PRM6 = objTLIF_TRNS_SEND.FDENBUN_PRM6            '�d�����Ұ�6
        mobjEQSendTelBuff.FTRNS_SERIAL = objTLIF_TRNS_SEND.FTRNS_SERIAL            '�����ره�(MC��)
        mobjEQSendTelBuff.FPRIORITY = objTLIF_TRNS_SEND.FPRIORITY                  '�D������
        mobjEQSendTelBuff.FDENBUN = objTLIF_TRNS_SEND.FDENBUN                      '�ʐM�d��
        mobjEQSendTelBuff.FPROGRESS = objTLIF_TRNS_SEND.FPROGRESS                  '�i�����
        mobjEQSendTelBuff.FRES_CD_EQ = objTLIF_TRNS_SEND.FRES_CD_EQ                '�ݔ���������
        mobjEQSendTelBuff.FOFFLINE_FLAG = objTLIF_TRNS_SEND.FOFFLINE_FLAG          '��ײݑ��M�׸�
        mobjEQSendTelBuff.FENTRY_DT = objTLIF_TRNS_SEND.FENTRY_DT                  '�o�^����
        mobjEQSendTelBuff.FUPDATE_DT = objTLIF_TRNS_SEND.FUPDATE_DT                '�X�V����

    End Sub
#End Region
#Region "  �������ނ����킩�ُ킩���f               "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �������ނ����킩�ُ킩���f
    ''' </summary>
    ''' <param name="strRecvText">����Ɏ�M�ł����ް�</param>
    ''' <returns>���������MIFð��قɒǉ�����ݔ���������</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function GetFRES_CD_EQ(ByVal strRecvText As String) As String
        Dim strReturn As String = "0"


        ''*****************************************************
        ''��M�d������
        ''*****************************************************
        'Dim objTel As New clsTelegram(CONFIG_TELEGRAM_BZ)
        'objTel.FORMAT_ID = FORMAT_BZ_HOSTNZ                 '̫�ϯĖ����    (���ɉ��ł��ǂ�)
        'objTel.TELEGRAM_PARTITION = strRecvText             '��������d�����
        'objTel.PARTITION()                                  '�d������


        'Dim strFTEXT_ID As String = MakeFTEXT_ID(objTel)      '÷��ID
        'Select Case strFTEXT_ID
        '    Case FTEXT_ID_JBZ_HOSTNZ _
        '       , FTEXT_ID_JBZ_HOSTSK0 _
        '       , FTEXT_ID_JBZ_HOSTSYU _
        '       , FTEXT_ID_JBZ_HOSTZT
        '        '(�����d���̏ꍇ)


        '        strReturn = TO_STRING(objTel.SELECT_HEADER("BZERR_CD"))

        '        Return strReturn
        '    Case Else
        '        '(���肦�Ȃ����A�ꉞ)

        '        Return strReturn
        'End Select


        Return strReturn
    End Function
#End Region
#Region "  �ʐMΰ���        ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ʐMΰ���
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub CommunicationHold()

        '========================================
        '�ʐMΰ���
        '========================================
        mobjEQSendTelBuff.CLEAR_PROPERTY()         '�đ��M�p÷���ޯ̧
        mintResponsWait = FLAG_OFF                  '�����҂��׸�   ���
        mintSendCount = 0                           '�đ��M��

    End Sub
#End Region



    '***********************************************
    '���������������M����
#Region "  ID:01    ��ײݗv��           ���M"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ID:01    ��ײݗv�����M
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">�������䑗�MIFð��ٸ׽</param>
    ''' <param name="strTelegram">���M����d��</param>
    ''' <returns>����I���̗L��</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function ID01Process(ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND, _
                                 ByRef strTelegram As String _
                                 ) _
                                 As RetCode
        Try
            Dim udtRet As RetCode


            ''*****************************************************
            ''�����ID���
            ''*****************************************************
            'mobjEQSendTelBuff.LOG_FCOMMAND_ID = MCV_ID_DIR_ONLINE


            '*****************************************************
            '�d���쐬
            '*****************************************************
            strTelegram = ""
            strTelegram &= MCV_ID_DIR_ONLINE


            '*****************************************************
            '�F�X������
            '*****************************************************
            Call SetSYS_HEN(mFHENSU_IDSeqNoSend, 0)     '���M���ݽNo = 0


            Return udtRet
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
#Region "  ID:02    ��ײݗv��           ���M"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ID:02    ��ײݗv�����M
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">�������䑗�MIFð��ٸ׽</param>
    ''' <param name="strTelegram">���M����d��</param>
    ''' <returns>����I���̗L��</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function ID02Process(ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND, _
                                 ByRef strTelegram As String _
                                 ) _
                                 As RetCode
        Try
            Dim udtRet As RetCode


            ''*****************************************************
            ''�����ID���
            ''*****************************************************
            'mobjEQSendTelBuff.LOG_FCOMMAND_ID = MCV_ID_DIR_OFFLINE


            '*****************************************************
            '�d���쐬
            '*****************************************************
            strTelegram = ""
            strTelegram &= MCV_ID_DIR_OFFLINE


            '*****************************************************
            '�F�X������
            '*****************************************************
            Call SetSYS_HEN(mFHENSU_IDSeqNoSend, 1) '���ݽNo = 1


            Return udtRet
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
#Region "  ID:**    �d�����M            ���M"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ID:**    �d�����M
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">�������䑗�MIFð��ٸ׽</param>
    ''' <param name="strTelegram">���M����d��</param>
    ''' <returns>����I���̗L��</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function IDZZProcess(ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND, _
                                 ByRef strTelegram As String _
                                 ) _
                                 As RetCode
        Try


            '*****************************************************
            '�d���쐬
            '*****************************************************
            strTelegram = ""
            strTelegram &= ZERO_PAD(GetSYS_HEN(mFHENSU_IDSeqNoSend), 3)
            strTelegram &= MID_SJIS(objTLIF_TRNS_SEND.FDENBUN, 4)


            Return RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
    '���������������M����
    '***********************************************


End Class
