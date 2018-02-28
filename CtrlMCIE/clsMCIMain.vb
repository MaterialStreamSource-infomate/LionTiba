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
    Private mobjSerial As clsSerial                     '�رْʐM��޼ު��
    Private mobjEQSendTelBuff As TBL_TLIF_TRNS_SEND     '�d�����M�ޯ̧
    'Private mobjEQSendResBuff As TBL_TLIF_TRNS_SEND    '�����d�����M�ޯ̧
    Private mobjGetTelegram As clsGetTelegram           '�d���p÷�Ď擾�׽

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

#End Region

    '***********************************************
    '����������������K�v
#Region "  ���ʕϐ�             "

    '==================================================
    '���ʵ�޼ު��
    '==================================================
    Private mobjOwner As Object                                 '��Ű��޼ު��
    'Private mobjDb As clsConn                                   '�׸ِڑ���޼ު��
    'Private mobjDbLog As clsConn                                '�׸ِڑ���޼ު��
    'Private mobjTPRG_SYS_HEN As TBL_TPRG_SYS_HEN                '���ѕϐ�
    'Private mobjSockSvr As clsSocketToServer                    '���ް�ֿ��đ��M�׽
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
            'mobjDb.BeginTrans()     '��ݻ޸��݊J�n
            Try
                'Dim strMsg As String                    'ү����


                '*****************************************************
                '�F�X������
                '*****************************************************
                mdtmNow = Now


                '*****************************************************
                'DB���M�ޯ̧���� & �d�����M     ����
                '*****************************************************
                Call MCIA_100001(True)


                '*****************************************************
                '�d����M�m�F
                '*****************************************************
                Dim strRecvText As String = ""          '��M�d��
                Call RecvDataEQ(strRecvText)


                ''*****************************************************
                ''�d����M       ����
                ''*****************************************************
                'Call MCIA_100002(strRecvText)


                '*****************************************************
                '���ނֿ��đ��M
                '*****************************************************
                Call MCI_000001()


            Catch ex As Exception
                Call ComError(ex)

            Finally
                'mobjDb.Commit()     '�Я�

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


            ''*****************************************************
            '' �׸ِڑ�
            ''*****************************************************
            'mobjDb = objDb
            'mobjDbLog = objDbLog


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


        ''*****************************************************
        '' �y���ѕϐ��z     �ڑ��׽�쐬
        ''*****************************************************
        'mobjTPRG_SYS_HEN = New TBL_TPRG_SYS_HEN(mobjOwner, mobjDb, mobjDbLog)


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
        Dim objConfig As New clsConnectConfig(CONFIG_MCIE)                              'Confiģ�ِڑ��׽����

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


        ''*****************************************************
        ''���ް���đ��M��޼ު��  ����
        ''*****************************************************
        'mobjSockSvr = New clsSocketToServer(mobjOwner)
        'mobjSockSvr.objOwner = mobjOwner                        '��Ű��޼ު��
        'mobjSockSvr.strTermID = mstrSvrSockSendTermID           '���ޒ[��ID
        'mobjSockSvr.strEmpCD = mstrSvrSockSendUserID            '����հ�ްID
        'mobjSockSvr.strAddress = mstrSvrSockSendAddress         '���ޑ��M����ڽ
        'mobjSockSvr.intPortNo = mintSvrSockSendPort             '���ޑ��M���߰�No
        'mobjSockSvr.intTimeout = mintSvrSockSendTimeOut         '���މ������đҋ@����
        'mobjSockSvr.strTelFilePath = CONFIG_TELEGRAM_DSP        '�ǂݍ��ޒ�`̧�ق��߽


        '**********************************************************************************************************************
        '���������ŗL����


        '*****************************************************
        '������ݒ�
        '*****************************************************
        mobjGetTelegram.strSTX = mobjASCII.strSTX
        mobjGetTelegram.strETX = mobjASCII.strETX


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


            ''***********************************
            ''���������MIF �ǉ�
            ''***********************************
            'Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)
            'objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                           '�ݔ�ID
            'objTLIF_TRNS_RECV.FCOMMAND_ID = FCOMMAND_ID_SADD_MSG             '�����ID
            'objTLIF_TRNS_RECV.FDENBUN_PRM1 = strFMSG_ID                     'ү����ID
            'objTLIF_TRNS_RECV.FDENBUN_PRM2 = strFMSG_PRM1                   '���Ұ�1
            'objTLIF_TRNS_RECV.FDENBUN_PRM3 = strFMSG_PRM2                   '���Ұ�2
            'objTLIF_TRNS_RECV.FDENBUN_PRM4 = strFMSG_PRM3                   '���Ұ�3
            'objTLIF_TRNS_RECV.FDENBUN_PRM5 = strFMSG_PRM4                   '���Ұ�4
            'objTLIF_TRNS_RECV.FDENBUN_PRM6 = strFMSG_PRM5                   '���Ұ�5
            'objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SEND                     '�i�����
            ' '' ''      objTLIF_TRNS_RECV.FRES_CD_EQ = FORMAT_PLC_RES_CD_OK             '�ݔ���������
            'objTLIF_TRNS_RECV.FENTRY_DT = Now                               '�o�^����
            'objTLIF_TRNS_RECV.FUPDATE_DT = Now                              '�X�V����
            'objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()                      '�ǉ�
            'mblnSockSend = True                                             '���đ��M�׸�


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


            ''***********************************
            ''���������MIF �ǉ�
            ''***********************************
            'Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)
            'objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                           '�ݔ�ID
            'objTLIF_TRNS_RECV.FCOMMAND_ID = FCOMMAND_ID_SCUT_EQ              '�����ID
            'objTLIF_TRNS_RECV.FDENBUN_PRM1 = mstrFEQ_ID                     'ү����ID
            'objTLIF_TRNS_RECV.FDENBUN_PRM2 = Nothing                        '���Ұ�1
            'objTLIF_TRNS_RECV.FDENBUN_PRM3 = Nothing                        '���Ұ�2
            'objTLIF_TRNS_RECV.FDENBUN_PRM4 = Nothing                        '���Ұ�3
            'objTLIF_TRNS_RECV.FDENBUN_PRM5 = Nothing                        '���Ұ�4
            'objTLIF_TRNS_RECV.FDENBUN_PRM6 = Nothing                        '���Ұ�5
            'objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SEND                     '�i�����
            ' '' ''      objTLIF_TRNS_RECV.FRES_CD_EQ = FORMAT_PLC_RES_CD_OK             '�ݔ���������
            'objTLIF_TRNS_RECV.FENTRY_DT = Now                               '�o�^����
            'objTLIF_TRNS_RECV.FUPDATE_DT = Now                              '�X�V����
            'objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()                      '�ǉ�
            'mblnSockSend = True                                             '���đ��M�׸�


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
                    'mobjDb.Commit()                                             '�Я�
                    'mobjDb.BeginTrans()                                         '��ݻ޸��݊J�n
                    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
                    objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S210001   '̫�ϯĖ����
                    'Call mobjSockSvr.SockSendServer(objTelegram)                '���đ��M
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
    ''' �ް����M
    ''' </summary>
    ''' <param name="strSendText">���M÷��</param>
    ''' <param name="objTLIF_TRNS_SEND">�������䑗�MIFð��ٸ׽</param>
    ''' <returns>����I���̗L��</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function SendDataEQ(ByVal strSendText As String _
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
            Dim blnSendSuccess As Boolean = False       '�d�����M�����׸�
            For II As Integer = 1 To mintSendRetry
                '(ٰ��:��ײ��)

                mobjSerial.bytSendText = mobjGetTelegram.MakeTelegramSTXETXBCC01(strSendText)

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

            '===========================================
            '÷��ID�擾
            '===========================================
            Dim strFTEXT_ID As String = ""
            strFTEXT_ID = MID_SJIS(strSendText, 1, 16)

            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
            If mobjEQSendTelBuff.FENTRY_NO <> FENTRY_NO_SMCI_MYSELF Then
                '������������************************************************************************************************************
                'Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)   '�ݔ��ʐM۸�
                'objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '�ݔ�ID
                'objTLOG_EQ.FHASSEI_DT = Now                         '��������
                'objTLOG_EQ.FDIRECTION = FDIRECTION_SSEND             '����
                'objTLOG_EQ.FTEXT_ID = objTLIF_TRNS_SEND.FTEXT_ID    '÷��ID
                'objTLOG_EQ.FTRNS_SERIAL = DEFAULT_STRING            '�����ره�
                'objTLOG_EQ.FPALLET_ID = DEFAULT_STRING              '��گ�ID
                'objTLOG_EQ.FDENBUN = strSendText                    '�ʐM�d��
                'objTLOG_EQ.FRES_CD_EQ = DEFAULT_STRING              '�ݔ���������
                'objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '�ǉ�
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
        '�d����M
        '****************************************
        mobjSerial.Receive()


        '****************************************
        '�d�������𒊏o & ��M�ޯ̧�X�V
        '****************************************
        If IsNotNull(mobjSerial.strRecvText) Then
            '(�d������M�����ꍇ)


            '****************************************
            '��M�ޯ̧�Ɍ���
            '****************************************
            If IsNull(mstrRecvTelBuff) Then
                mstrRecvTelBuff = mobjSerial.strRecvText
            Else
                mstrRecvTelBuff &= mobjSerial.strRecvText
            End If


            '****************************************
            '�d�������𒊏o & ��M�ޯ̧�X�V
            '****************************************
            Call AddToDebugLog(MCIA_MSG_011 & mobjASCII.GetLogString(mstrRecvTelBuff))
            mstrRecvTelBuff = ""
            'strRecvText = mobjGetTelegram.GetTelegramSTXETX(mstrRecvTelBuff)
            'If IsNotNull(strRecvText) Then
            '    Call AddToLog(MCIA_MSG_011 & strRecvText) '�d���擾۸ޏo��
            'End If

        End If


    End Sub
#End Region



    '*******************
    'Private
    '*******************
#Region "  MCIA_100001  DB���� & �d�����M       ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' DB���� �� �d�����M
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_100001(ByVal blnCheck As Boolean)
        'Private Sub MCIA_100001()
        'Try
        '    Dim udtRet As RetCode



        '    '*****************************************************
        '    '�����׸�����
        '    '*****************************************************
        '    If mintResponsWait = FLAG_ON Then
        '        '(�����׸� = ON �̏ꍇ)
        '        Exit Sub
        '    End If


        '    '������������************************************************************************************************************
        '    'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
        '    If blnCheck = True Then
        '        '������������************************************************************************************************************


        '        '*****************************************************
        '        '��ϰ����
        '        '*****************************************************
        '        Dim objDiff As TimeSpan = mdtmBeforeDBTime.AddMilliseconds(mintDBReadTimer) - Now
        '        If 0 < objDiff.TotalMilliseconds Then
        '            Exit Sub
        '        End If
        '        mdtmBeforeDBTime = Now


        '        '������������************************************************************************************************************
        '        'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
        '    End If
        '    '������������************************************************************************************************************


        '    '*****************************************************
        '    '�d�����M
        '    '*****************************************************
        '    If udtRet = RetCode.OK And strTelegram <> "" Then
        '        udtRet = SendDataEQ(strTelegram, objTLIF_TRNS_SEND)    '�d�����M
        '        mintSendCount = 1                                       '���M��(����)
        '    End If


        '    '*****************************************************
        '    '÷�đ��M���ʂɂ�菈���ύX
        '    '*****************************************************
        '    '����
        '    Select Case udtRet
        '        Case RetCode.OK
        '            '=========================================
        '            '����
        '            '=========================================
        '            Select Case objTLIF_TRNS_SEND.FTEXT_ID
        '                Case "xxxx" 
        '                    '(��������̏ꍇ)
        '                    Call UpdateSendFPROGRESS(FPROGRESS_SACT)             '�������䑗�M����̪��.�ʐM���      ���
        '                    'mblnSockSend = True                                 '���đ��M�׸�
        '                    mintResponsWait = FLAG_ON                           '�����҂��׸�                       ���
        '                Case Else
        '                    '(�����Ȃ��̏ꍇ)
        '                    Call UpdateSendFPROGRESS(FPROGRESS_SEND)             '�������䑗�M����̪��.�ʐM���      ���
        '                    mblnSockSend = True                                 '���đ��M�׸�
        '                    mintResponsWait = FLAG_OFF                          '�����҂��׸�                       ���
        '                    Call InitializeDBReadTimer()                        '������DB��������
        '            End Select

        '        Case Else
        '            '=========================================
        '            '�ُ�
        '            '=========================================
        '            Call UpdateSendFPROGRESS(FPROGRESS_SERR_MCI)         '�������䑗�M����̪��.�ʐM���      ���
        '            mintResponsWait = FLAG_OFF                          '�����҂��׸�                       ���
        '            '' ''Call SeqNoSendUpdate()                         '���ݽNo + 1                        ���
        '            Call mobjEQSendTelBuff.CLEAR_PROPERTY()            '���M�ޯ̧                          �폜

        '            '۸ޏo��
        '            Dim strMessage As String = ""
        '            strMessage &= "�װ�����������ׁA����ں��ނ̏����͎��s�o���܂���ł����B"
        '            strMessage &= "[�o�^��:" & objTLIF_TRNS_SEND.FENTRY_NO & "]"
        '            strMessage &= "[�ݔ�ID:" & objTLIF_TRNS_SEND.FEQ_ID & "]"
        '            strMessage &= "[�����ID:" & objTLIF_TRNS_SEND.FCOMMAND_ID & "]"
        '            strMessage &= "[���Ұ�1:" & objTLIF_TRNS_SEND.FDENBUN_PRM1 & "]"
        '            strMessage &= "[���Ұ�2:" & objTLIF_TRNS_SEND.FDENBUN_PRM2 & "]"
        '            strMessage &= "[���Ұ�3:" & objTLIF_TRNS_SEND.FDENBUN_PRM3 & "]"
        '            strMessage &= "[���Ұ�4:" & objTLIF_TRNS_SEND.FDENBUN_PRM4 & "]"
        '            strMessage &= "[���Ұ�5:" & objTLIF_TRNS_SEND.FDENBUN_PRM5 & "]"
        '            Call AddToLog(strMessage)

        '    End Select


        'Catch ex As Exception
        '    ComError(ex)

        'End Try
    End Sub
#End Region
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
            Dim objTel As New clsTelegram(CONFIG_TELEGRAM_BCR)
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

            'Call AddDBRecvLog_LOG(strFTEXT_ID _
            '                    , strRecvText _
            '                    , "" _
            '                    )

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


            ''*****************************************************
            ''�y�������䑗��M����̪���z   �ǉ�
            ''*****************************************************
            ''������������************************************************************************************************************
            ''SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
            'If blnLogAdd = True Then
            '    '������������************************************************************************************************************

            '    Call AddDBRecvLIF_TRNS_RECV(FCOMMAND_ID_SOT _
            '                                  , strRecvText _
            '                                  , strFTEXT_ID _
            '                                  , FPROGRESS_SEND _
            '                                  , intFRES_CD_EQ _
            '                                  , strFDENBUN_PRM1 _
            '                                  , strFDENBUN_PRM2 _
            '                                  )

            '    '������������************************************************************************************************************
            '    'SystemMate:N.Dounoshita 2012/05/08  ������₢���킹�̕W����
            'End If
            ''������������************************************************************************************************************


        Catch ex As Exception
            ComError(ex)

        End Try
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

            mstrRecvTelBuff = ""                    '��M�ޯ̧


            Return RetCode.OK
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


            ''*****************************************************
            ''ͯ�ޕ����쐬
            ''*****************************************************
            'Dim strHeader As String = ""
            'strHeader = GetSendHeaderText(objTLIF_TRNS_SEND)


            ''*****************************************************
            ''�d���쐬
            ''*****************************************************
            'strTelegram = ""
            'strTelegram &= strHeader
            'strTelegram &= TO_STRING(GetSYS_HEN(FHENSU_ID_MCIA_END_KUBUN))


            Return RetCode.OK
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
            strTelegram &= objTLIF_TRNS_SEND.FDENBUN


            Return RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
    '���������������M����
    '    '***********************************************


End Class
