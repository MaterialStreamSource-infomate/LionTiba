'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zMCIҲݸ׽(���q���۰גʐM)
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports  "
Imports JobCommon
Imports MateCommon.clsConst
Imports MateCommon
Imports UserProcess
Imports spi.WinSAM
Imports spi.WinSAM.Data
#End Region

Public Class clsMCIMain

#Region "  ���ʕϐ�02           "

    '==================================================
    '���ʵ�޼ު��
    '==================================================
    Private mobjWinSAM As spi.WinSAM.WsNETAPI           'WsNETAPI�N���X
    'Private mobjSockClient As clsSocketClient           '���ĒʐM�׽(�ײ���)
    'Private mobjSockListener As clsSocketListener       '���ĒʐM�׽(ؽŰ)
    Private mobjEQSendTelBuff As TBL_TLIF_TRNS_SEND    '�d�����M�ޯ̧
    'Private mobjEQSendResBuff As TBL_TLIF_TRNS_SEND    '�����d�����M�ޯ̧
    Private mobjGetTelegram As clsGetTelegram           '�d���p÷�Ď擾�׽

    '==================================================
    '�����ϐ�
    '==================================================
    'EQ�ւ̿��ėp
    Private mstrEQSockSendAddress As String        'EQ���M����ڽ
    Private mintEQSockSendPort As Integer          'EQ���M���߰�No
    Private mintEQSockSendTimeOut As Integer       'EQ�������đҋ@���� (ms)
    Private mintEQSockETXSendTimeOut As Integer    'EQ�����ETX���đ��M���� (ms)
    Private mintEQSockETXRecvTimeOut As Integer    'EQ�����ETX���Ď�M���� (ms)
    Private mintEQSockSendRetry As Integer         'EQ���M��ײ��(��)
    Private mintEQSockConnTimeOut As Integer       'EQ�ȸ��� ��ײ��ѱ��(ms)
    'EQ����̿��ėp
    Private mintEQSockRecvPort As Integer          'EQ��M�߰�No
    'EQ�d����M�p
    Private mintEQTelegramInforStartPosition As Integer     '�u�������v�������Ă���ʒu
    Private mintEQTelegramInforLength As Integer            '�u�������v�̌���
    Private mintEQTelegramHeaderLength As Integer           'ͯ�ް�����̌���

    'WinSAM�p
    Private mstrWinSAMOpenPipeName As String        '�����PIPE��
    Private mstrWinSAMSendTermName As String        '���M�[����


    '���̑�
    Private mintSendCount As Integer            '�đ��M��
    Private mdtmBeforeRecvTime As Date          '�O���M����
    Private mdtmBeforeSendTime As Date          '�O�񑗐M����
    Private mbytRecvTelBuffClient() As Byte     '���Ď�M�ޯ̧(�ײ���)
    Private mbytRecvTelBuffListener() As Byte   '���Ď�M�ޯ̧(ؽŰ)
    Private mintResponsWait As Integer          '�����҂��׸�
    Private mdtmBeforeConnTime As Date          '�O��ڑ�����
    'Private mblnConnect As Boolean              '���Đڑ��׸�
    'Private mintSockRecvMode As Integer         '���Ď�MӰ��


    '==================================================
    '�Œ�l
    '==================================================
    Public Const MAX_LEN As Integer = 3000      'UST�̐ݒ��3000�ƂȂ��Ă���


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
    Private mintSendSleep As Integer                '�ʐMؾ�Ď��̽ذ�ߎ���(ms)  �A������ؾ�Ă��s��Ȃ���
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
            'mobjSockClient.intDebugFlag = Value                   '���ĒʐM�׽
            'mobjSockListener.intDebugFlag = Value                 '���ĒʐM�׽
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
                'DB���M�ޯ̧���� & �d�����M     ����
                '*****************************************************
                Call MCIA_100001()


                '*****************************************************
                '�d����M�m�F
                '*****************************************************
                Dim strRecvText As String = ""          '��M�d��
                Dim strFDENBUN_PRM1 As String = Nothing '�d�����Ұ�1
                Dim strFDENBUN_PRM2 As String = Nothing '�d�����Ұ�2
                Call RecvDataEQLintener(strRecvText, strFDENBUN_PRM1, strFDENBUN_PRM2)


                '*****************************************************
                '�d����M       ����
                '*****************************************************
                Call MCIA_100002(strRecvText, strFDENBUN_PRM1, strFDENBUN_PRM2)


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
            mbytRecvTelBuffClient = Nothing                     '���Ď�M�ޯ̧(�ײ���)
            mbytRecvTelBuffListener = Nothing                   '���Ď�M�ޯ̧(ؽŰ)
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
        'mobjEQSendResBuff = New TBL_TLIF_TRNS_SEND(mobjOwner, Nothing, Nothing)    '�����d�����M�ޯ̧
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
        mintSendSleep = TO_STRING(objConfig.GET_INFO(GKEY_MCI_SEND_SLEEP))                          '�ʐMؾ�Ď��̽ذ�ߎ���(ms)  �A������ؾ�Ă��s��Ȃ���


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
        'EQ�ւ̿��ėp
        mstrEQSockSendAddress = TO_STRING(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_ADDRESS))                  'EQ���M����ڽ
        mintEQSockSendPort = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_PORT))                       'EQ���M���߰�No
        mintEQSockSendTimeOut = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_TIME_OUT))                'EQ�������đҋ@���� (ms)
        mintEQSockSendRetry = TO_STRING(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_RETRY))                      'EQ���M��ײ��(��)
        mintEQSockConnTimeOut = TO_STRING(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_CONN_TIME_OUT))            'EQ�ȸ��� ��ײ��ѱ��(ms)
        'EQ����̿��ėp
        mintEQSockRecvPort = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_SOCK_RECV_PORT))                       'EQ��M�߰�No
        'EQ�d����M�p
        mintEQTelegramInforStartPosition = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_TELEGRAM_INFOR_START_POSITION))        '�u�������v�������Ă���ʒu
        mintEQTelegramInforLength = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_TELEGRAM_INFOR_LENGTH))                       '�u�������v�̌���
        mintEQTelegramHeaderLength = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_TELEGRAM_HEADER_LENGTH))                     'ͯ�ް�����̌���
        'WinSAM�p
        mstrWinSAMOpenPipeName = TO_STRING(objConfig.GET_INFO(GKEY_WINSAM_OPEN_PIPE_NAME))        '�����PIPE��
        mstrWinSAMSendTermName = TO_STRING(objConfig.GET_INFO(GKEY_WINSAM_SEND_TERM_NAME))        '���M�[����


        '****************************************************
        '���ĵ�޼ު��   ���
        '****************************************************
        'mobjSockClient = New clsSocketClient(mobjOwner)
        'mobjSockListener = New clsSocketListener(mobjOwner)
        'mobjSockClient.strAddress = mstrEQSockSendAddress
        'mobjSockClient.intPortNo = mintEQSockSendPort
        'mobjSockClient.Connect()


        '****************************************************
        'WinSAM         ��`
        '****************************************************
        mobjWinSAM = New spi.WinSAM.WsNETAPI()
        Try
            Dim intWinRet As Integer                            'WinSAM�ߒl
            Dim strSock As New System.Text.StringBuilder(256)   '�߲�ߖ�
            Dim bytOpenMode As Byte = WsWSID.SYNOUT             'Ӱ��

            '// nsp_open:WinSAM�Ƃ̓��o�͂��J�n���܂��B
            '// �p�����[�^
            '//   inpath
            '//     WinSAM����̃f�[�^�[����M����p�C�v�����w�肵�܂��B
            '//     �����WinSAM�V�X�e����`�Ŏw�肵�� �u���͗p���O�t���p�C�v�v��
            '//     �񓯊��o�͂Ŏw�肵���u�񓯊�������M�p�C�v���v�Ɠ���łȂ���΂Ȃ�܂���B
            '//     �{�v���Z�X����M���s��Ȃ��i�o�͐�p�j�ꍇ�́Anull����͂��邱�Ƃ��ł��܂��B
            '//   mode
            '//     �o�̓��[�h��ݒ肵�܂��B�i�����l�FWsWSID.NONOUT,WsWSID.SYNOUT,WsWSID.ASYOUT)
            '// �߂�l
            '//   ���g���C�ɂ��p���\�ȃG���[�ԍ�
            intWinRet = mobjWinSAM.nsp_open(strSock.Append(mstrWinSAMOpenPipeName), bytOpenMode)
            If intWinRet <> WsWSRC.NORMAL Then     '// ���A���F����I��(0)�ȊO
                Call AddToLog("nsp_open �Ɏ��s���܂����BRC =" & Str(intWinRet) & " : �ڍ׃R�[�h =" + Str(mobjWinSAM.ns_GetLastError))
            Else
                Call AddToLog("nsp_open ���������܂����B")
            End If
        Catch ex As Exception
            Call ComError(ex)
        End Try


        '���������ŗL����
        '**********************************************************************************************************************


        '������������************************************************************************************************************
        'JobMate:N.Dounoshita 2012/06/27 ������ݸ۰�ޏ����ɂ��C��

        '****************************************************
        '�ʐM�����
        '****************************************************
        'Call OpenClient()
        'Call OpenListener()

        '������������************************************************************************************************************


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
#Region "  �ʐM�����(���ĸײ���)            "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ʐM�����
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub OpenClient()


        ''****************************************************
        ''���ĵ�޼ު��   ���
        ''****************************************************
        'mobjSockClient.strAddress = mstrEQSockSendAddress
        'mobjSockClient.intPortNo = mintEQSockSendPort
        'mobjSockClient.Connect()
        'If mobjSockClient.udtRet = clsSocketClient.RetCode.OK Then
        '    'mblnConnect = True
        '    Call AddToLog(MCIA_MSG_001)
        'Else
        '    'mblnConnect = False
        '    Call AddToLog(MCIA_MSG_003)
        '    Call ErrorAdd(mstrFMSG_ID_ERR_USER, ERR_MSG_01, MCIA_MSG_003)
        '    Call StopCommunication()
        'End If


    End Sub
#End Region
#Region "  �ʐM�۰��(���ĸײ���)            "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ʐM�۰��
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub CloseClient()
        Try


            ''****************************************************
            ''���ĵ�޼ު��   ���
            ''****************************************************
            'mobjSockClient.ShutDown()
            'Call AddToLog(MCIA_MSG_002)


            '****************************************************
            'WinSAM         �۰��
            '****************************************************
            '// nsp_close:WinSAM�Ƃ̓��o�͂��I�����܂��B
            '// �߂�l
            '//   ���g���C�ɂ��p���\�ȃG���[�ԍ�
            Dim intWinRet As Integer                                    'WinSAM�ߒl
            intWinRet = mobjWinSAM.nsp_close()
            If intWinRet = WsWSRC.NORMAL Then     '// ���A���F����I��(0)
                Call AddToLog("nsp_close ����������ɏI�����܂����B")
            Else
                Call AddToLog("nsp_close �G���[ RC =" & Str(intWinRet) & " : �ڍ׃R�[�h = " & Str(mobjWinSAM.ns_GetLastError))
            End If


        Catch ex As Exception
            'NOP(���s���Ă����ɖ��Ȃ�)
        End Try
    End Sub
#End Region
#Region "  �ʐM�����(����ؽŰ)              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ʐM�����
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub OpenListener()


        ''****************************************************
        ''���ĵ�޼ު��   ���
        ''****************************************************
        'mobjSockListener.intPortNo = mintEQSockRecvPort
        'mobjSockListener.Listen()
        'If mobjSockListener.udtRET = clsSocketListener.RetCode.OK Then
        '    'mblnConnect = True
        '    Call AddToLog(MCIA_MSG_006)
        'Else
        '    'mblnConnect = False
        '    Call AddToLog(MCIA_MSG_008)
        '    Call ErrorAdd(mstrFMSG_ID_ERR_USER, ERR_MSG_01, MCIA_MSG_008)
        '    Call StopCommunication()
        'End If


    End Sub
#End Region
#Region "  �ʐM�۰��(����ؽŰ)              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ʐM�۰��
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub CloseListener()
        Try


            ''****************************************************
            ''���ĵ�޼ު��   ���
            ''****************************************************
            'mobjSockListener.Shutdown()
            'Call AddToLog(MCIA_MSG_007)


        Catch ex As Exception
            'NOP(���s���Ă����ɖ��Ȃ�)
        End Try
    End Sub
#End Region

#Region "  �ް����M(���ĸײ���)             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ް����M(���ĸײ���)
    ''' </summary>
    ''' <param name="strSendText">���M÷��</param>
    ''' <param name="objTLIF_TRNS_SEND">�������䑗�MIFð��ٸ׽</param>
    ''' <returns>����I���̗L��</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function SendDataEQClient(ByVal strSendText As String _
                                   , ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND _
                                   ) As RetCode
        'Try
        '    Dim intRet As RetCode = RetCode.OK


        '    '*****************************************************
        '    '��M�ޯ̧������
        '    '*****************************************************
        '    mbytRecvTelBuffClient = Nothing         '���Ď�M�ޯ̧(�ײ���)


        '    '*****************************************************
        '    '�A�����đ��M�o���Ȃ���Sleep
        '    '*****************************************************
        '    If 0 < mintSendSleep Then
        '        '(�ذ�ߎ��Ԃ���Ă���Ă���ꍇ)

        '        Dim objDiff As TimeSpan = mdtmBeforeRecvTime.AddMilliseconds(mintSendSleep) - Now
        '        'Dim objDiff As TimeSpan = mdtmBeforeSendTime.AddMilliseconds(mintSendSleep) - Now
        '        If 0 < objDiff.TotalMilliseconds Then
        '            Call Threading.Thread.Sleep(objDiff.TotalMilliseconds)
        '        End If

        '    End If


        '    '*****************************************************
        '    '÷���ް����M
        '    '*****************************************************
        '    For II As Integer = 1 To mintEQSockSendRetry
        '        '(ٰ��:��ײ��)

        '        mobjSockClient.bytSendText = mobjGetTelegram.MakeTelegramDataLength101(strSendText, mintEQTelegramInforLength)

        '        Try
        '            mdtmBeforeSendTime = Now                                        '�O�񑗐M����   ���
        '            Call OpenClient()
        '            mobjSockClient.Send()
        '            If mobjSockClient.udtRet = clsSocketClient.RetCode.OK Then Exit For
        '        Catch ex As Exception
        '        End Try
        '    Next
        '    If mobjSockClient.udtRet = clsSocketClient.RetCode.OK Then
        '        '(���������ꍇ)
        '    Else
        '        '(���s�����ꍇ)
        '        Call AddToLog(MCIA_MSG_022 & strSendText)
        '        intRet = RetCode.NG
        '        Return intRet
        '    End If


        '    '*****************************************************
        '    '۸ޏo��
        '    '*****************************************************
        '    '===========================================
        '    '÷��۸ޒǉ�
        '    '===========================================
        '    Call AddToLog(MCIA_MSG_021 & strSendText)

        '    '===========================================
        '    '÷��ID�擾
        '    '===========================================
        '    Dim strFTEXT_ID As String = ""
        '    strFTEXT_ID = MID_SJIS(strSendText, 1, 16)

        '    '===========================================
        '    '�ݔ��ʐM۸ޒǉ�
        '    '===========================================
        '    Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)   '�ݔ��ʐM۸�
        '    objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '�ݔ�ID
        '    objTLOG_EQ.FHASSEI_DT = Now                         '��������
        '    objTLOG_EQ.FDIRECTION = FDIRECTION_SSEND             '����
        '    objTLOG_EQ.FTEXT_ID = objTLIF_TRNS_SEND.FTEXT_ID    '÷��ID
        '    objTLOG_EQ.FTRNS_SERIAL = DEFAULT_STRING            '�����ره�
        '    objTLOG_EQ.FPALLET_ID = DEFAULT_STRING              '��گ�ID
        '    objTLOG_EQ.FDENBUN = strSendText                    '�ʐM�d��
        '    objTLOG_EQ.FRES_CD_EQ = DEFAULT_STRING              '�ݔ���������
        '    objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '�ǉ�


        '    Return intRet
        'Catch ex As Exception
        '    Call ComError(ex)
        '    Return RetCode.NG

        'End Try
    End Function
#End Region
#Region "  �ް���M(���ĸײ���)             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ް���M(���ĸײ���)
    ''' </summary>
    ''' <param name="strRecvText">��M÷��</param>
    ''' <remarks>����I���̗L��</remarks>
    '''*******************************************************************************************************************
    Public Sub RecvDataEQClient(ByRef strRecvText As String)


        ''****************************************
        ''���Ď�M
        ''****************************************
        'If mobjSockClient.blnIsConnect = False Then Exit Sub
        'mobjSockClient.Receive()


        ''****************************************
        ''�d�������𒊏o & ���Ď�M�ޯ̧�X�V
        ''****************************************
        'If IsNotNull(mobjSockClient.bytRecvText) Then
        '    '(�d������M�����ꍇ)

        '    '****************************************
        '    '���Ď�M�ޯ̧�Ɍ���
        '    '****************************************
        '    If IsNull(mbytRecvTelBuffClient) Then
        '        mbytRecvTelBuffClient = mobjSockClient.bytRecvText
        '    Else
        '        ReDim Preserve mbytRecvTelBuffClient(mbytRecvTelBuffClient.Length + mobjSockClient.bytRecvText.Length - 1)
        '        mobjSockClient.bytRecvText.CopyTo(mbytRecvTelBuffClient, mbytRecvTelBuffClient.Length)
        '    End If


        '    '****************************************
        '    '�d�������𒊏o & ���Ď�M�ޯ̧�X�V
        '    '****************************************
        '    strRecvText = mobjGetTelegram.GetTelegramDataLength101(mbytRecvTelBuffClient _
        '                                                         , mintEQTelegramInforLength _
        '                                                         )
        '    If IsNotNull(strRecvText) Then
        '        Call AddToLog(MCIA_MSG_011 & strRecvText) '�d���擾۸ޏo��
        '    End If

        'End If


    End Sub
#End Region
#Region "  �ް����M(����ؽŰ)               "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ް����M(����ؽŰ)
    ''' </summary>
    ''' <param name="strSendText">���M÷��</param>
    ''' <returns>����I���̗L��</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function SendDataEQLintener(ByVal strSendText As String _
                                     , ByVal strFTEXT_ID As String _
                                     ) As RetCode
        Try
            Dim intRet As RetCode = RetCode.OK


            '*****************************************************
            '���M�d���޲Ĕz��쐬
            '*****************************************************
            Dim strArySendText() As String = Split(strSendText, "_")
            Dim bytArySendText(UBound(strArySendText)) As Byte
            For ii As Integer = 0 To UBound(strArySendText)
                bytArySendText(ii) = Change16To10(strArySendText(ii))
            Next


            '*****************************************************
            '÷���ް����M
            '*****************************************************
            Dim intWinRet As Integer                                    'WinSAM�ߒl
            Dim destpid As New System.Text.StringBuilder(32)            '���̓p�C�v���ʖ�
            Dim originpid As New System.Text.StringBuilder(32)          '�����[����
            Dim cpathname As New System.Text.StringBuilder(128)         '�����ް�����͂��閼�O�t���߲�ߖ���
            Dim objwsiData As New spi.WinSAM.Data.WsNETData(bytArySendText.Length)      '�擾�ް�
            objwsiData.Command = 0
            objwsiData.Control = 0
            objwsiData.Flow = 0
            objwsiData.Echo.Append("1111")
            objwsiData.Length = bytArySendText.Length
            For ii As Integer = 0 To UBound(bytArySendText)
                '(ٰ��:�ް�)
                objwsiData.Data(ii) = bytArySendText(ii)
            Next

            '// nsp_aout:�[���񓯊��o�͏���
            '// �p�����[�^
            '//   destpid
            '//     [IN] �f�[�^���o�͂��鑊���[�����̂��w�肵�܂��B
            '//   originpid
            '//     [IN] �o�̓f�[�^�̔��M���̖��O���w�肵�܂��B
            '//   oData
            '//     [IN] WsNETData�N���X�B���M�f�[�^�[����ё��M�f�[�^�[�̓���
            '//   compap
            '//     [IN] ����������M����p�C�v��
            '// �߂�l
            '//   [IN] ���g���C�ɂ��p���\�ȃG���[�ԍ�
            '//
            intWinRet = mobjWinSAM.nsp_sout(destpid.Append(mstrWinSAMSendTermName), originpid.Append("aaa"), objwsiData)
            'intWinRet = mobjWinSAM.nsp_aout(destpid.Append("term1"), originpid.Append("aaa"), objwsiData, cpathname)
            If intWinRet = WsWSRC.NORMAL Then     '// ���A���F����I��(0)�ȊO
                '(���튮��)
                If objwsiData.TosID <> 0 Then Call AddToLog("nsp_sout �����Ɏ��s���܂����BTosID =" & Str(objwsiData.TosID) & " : �ڍ׃R�[�h =" & Str(mobjWinSAM.ns_GetLastError))
                Dim bEtype As Byte
                Dim bEtos As Byte
                Dim nEno As Short
                mobjWinSAM.ns_GetErrInfo(bEtype, bEtos, nEno)
                Call AddToLog("�ڍ׃R�[�h ; Type = " & Change10To16(bEtype, 2) & " Tos = " & Change10To16(bEtos, 2) & " No = " & Str(nEno))
            Else
                '(�ُ튮��)
                Call AddToLog("nsp_sout �����Ɏ��s���܂����BRC =" & Str(intWinRet) & " : �ڍ׃R�[�h =" & Str(mobjWinSAM.ns_GetLastError))
            End If


            '*****************************************************
            '۸ޏo��
            '*****************************************************
            '===========================================
            '÷��۸ޒǉ�
            '===========================================
            Call AddToLog(MCIA_MSG_021 & strSendText)

            ''===========================================
            ''÷��ID�擾
            ''===========================================
            'Dim strFTEXT_ID As String = ""
            'strFTEXT_ID = FTEXT_ID_JS_CARD01

            '===========================================
            '�ݔ��ʐM۸ޒǉ�
            '===========================================
            Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)   '�ݔ��ʐM۸�
            objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '�ݔ�ID
            objTLOG_EQ.FHASSEI_DT = Now                         '��������
            objTLOG_EQ.FDIRECTION = FDIRECTION_SSEND            '����
            objTLOG_EQ.FTEXT_ID = strFTEXT_ID                   '÷��ID
            objTLOG_EQ.FTRNS_SERIAL = DEFAULT_STRING            '�����ره�
            objTLOG_EQ.FPALLET_ID = DEFAULT_STRING              '��گ�ID
            objTLOG_EQ.FDENBUN = strSendText                    '�ʐM�d��
            objTLOG_EQ.FRES_CD_EQ = DEFAULT_STRING              '�ݔ���������
            objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '�ǉ�


            Return intRet
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
#Region "  �ް����M(����ؽŰ)_Backup        "
    '''''''*******************************************************************************************************************
    ''''''' <summary>
    ''''''' �ް����M(����ؽŰ)
    ''''''' </summary>
    ''''''' <param name="strSendText">���M÷��</param>
    ''''''' <param name="objTLIF_TRNS_SEND">�������䑗�MIFð��ٸ׽</param>
    ''''''' <returns>����I���̗L��</returns>
    ''''''' <remarks></remarks>
    '''''''*******************************************************************************************************************
    '' ''Public Function SendDataEQLintener(ByVal strSendText As String _
    '' ''                                 , ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND _
    '' ''                                 ) As RetCode
    '' ''    'Try
    '' ''    '    Dim intRet As RetCode = RetCode.OK


    '' ''    '    '*****************************************************
    '' ''    '    '�A�����đ��M�o���Ȃ���Sleep
    '' ''    '    '*****************************************************
    '' ''    '    If 0 < mintSendSleep Then
    '' ''    '        '(�ذ�ߎ��Ԃ���Ă���Ă���ꍇ)

    '' ''    '        Dim objDiff As TimeSpan = mdtmBeforeRecvTime.AddMilliseconds(mintSendSleep) - Now
    '' ''    '        'Dim objDiff As TimeSpan = mdtmBeforeSendTime.AddMilliseconds(mintSendSleep) - Now
    '' ''    '        If 0 < objDiff.TotalMilliseconds Then
    '' ''    '            Call Threading.Thread.Sleep(objDiff.TotalMilliseconds)
    '' ''    '        End If

    '' ''    '    End If


    '' ''    '    '*****************************************************
    '' ''    '    '÷���ް����M
    '' ''    '    '*****************************************************
    '' ''    '    For II As Integer = 1 To mintEQSockSendRetry
    '' ''    '        '(ٰ��:��ײ��)

    '' ''    '        mobjSockListener.bytSendText = mobjGetTelegram.MakeTelegramDataLength101(strSendText, mintEQTelegramInforLength)

    '' ''    '        Try
    '' ''    '            mdtmBeforeSendTime = Now                                        '�O�񑗐M����   ���
    '' ''    '            mobjSockListener.Send()
    '' ''    '            If mobjSockListener.udtRET = clsSocketListener.RetCode.OK Then Exit For
    '' ''    '        Catch ex As Exception
    '' ''    '        End Try
    '' ''    '    Next
    '' ''    '    If mobjSockListener.udtRET = clsSocketListener.RetCode.OK Then
    '' ''    '        '(���������ꍇ)
    '' ''    '    Else
    '' ''    '        '(���s�����ꍇ)
    '' ''    '        Call AddToLog(MCIA_MSG_022 & strSendText)
    '' ''    '        intRet = RetCode.NG
    '' ''    '        Return intRet
    '' ''    '    End If


    '' ''    '    '*****************************************************
    '' ''    '    '۸ޏo��
    '' ''    '    '*****************************************************
    '' ''    '    '===========================================
    '' ''    '    '÷��۸ޒǉ�
    '' ''    '    '===========================================
    '' ''    '    Call AddToLog(MCIA_MSG_021 & strSendText)

    '' ''    '    '===========================================
    '' ''    '    '÷��ID�擾
    '' ''    '    '===========================================
    '' ''    '    Dim strFTEXT_ID As String = ""
    '' ''    '    strFTEXT_ID = MID_SJIS(strSendText, 1, 16)

    '' ''    '    '===========================================
    '' ''    '    '�ݔ��ʐM۸ޒǉ�
    '' ''    '    '===========================================
    '' ''    '    Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)   '�ݔ��ʐM۸�
    '' ''    '    objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '�ݔ�ID
    '' ''    '    objTLOG_EQ.FHASSEI_DT = Now                         '��������
    '' ''    '    objTLOG_EQ.FDIRECTION = FDIRECTION_SSEND             '����
    '' ''    '    objTLOG_EQ.FTEXT_ID = objTLIF_TRNS_SEND.FTEXT_ID    '÷��ID
    '' ''    '    objTLOG_EQ.FTRNS_SERIAL = DEFAULT_STRING            '�����ره�
    '' ''    '    objTLOG_EQ.FPALLET_ID = DEFAULT_STRING              '��گ�ID
    '' ''    '    objTLOG_EQ.FDENBUN = strSendText                    '�ʐM�d��
    '' ''    '    objTLOG_EQ.FRES_CD_EQ = DEFAULT_STRING              '�ݔ���������
    '' ''    '    objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '�ǉ�


    '' ''    '    Return intRet
    '' ''    'Catch ex As Exception
    '' ''    '    Call ComError(ex)
    '' ''    '    Return RetCode.NG

    '' ''    'End Try
    '' ''End Function
#End Region
#Region "  �ް���M(����ؽŰ)               "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ް���M(����ؽŰ)
    ''' </summary>
    ''' <param name="strRecvText">��M÷��</param>
    ''' <remarks>����I���̗L��</remarks>
    '''*******************************************************************************************************************
    Public Sub RecvDataEQLintener(ByRef strRecvText As String _
                                , ByRef strFDENBUN_PRM1 As String _
                                , ByRef strFDENBUN_PRM2 As String _
                                )


        '****************************************
        '���Ď�M
        '****************************************
        Dim intWinRet As Integer                                    'WinSAM�ߒl
        Dim destpid As New System.Text.StringBuilder(32)            '���̓p�C�v���ʖ�
        Dim originpid As New System.Text.StringBuilder(32)          '�����[����
        Dim objwsiData As New spi.WinSAM.Data.WsNETData(MAX_LEN)    '�擾�ް�

        '// nsp_input:�v���Z�X���[������̓��̓f�[�^�܂��́A�񓯊��o�͎���
        '// �o�͊����f�[�^��WinSAM����ǂݍ��ޏ����B
        '// �p�����[�^
        '//   destpid
        '//     [OUT]�f�[�^���o�͂��鑊���[�����̂��w�肵�܂��B
        '//   originpid
        '//     [OUT] �o�̓f�[�^�̔��M���̖��O���w�肵�܂��B
        '//   iData
        '//     [OUT] WsNETTermData�N���X�B��M�f�[�^�[����ю�M�f�[�^�[�̓���
        '//   WSec
        '//     �҂�����
        '// �߂�l
        '//   ���g���C�ɂ��p���\�ȃG���[�ԍ�
        intWinRet = mobjWinSAM.nsp_input(destpid, originpid, objwsiData, 1)


        '****************************************
        '�d�������𒊏o & ���Ď�M�ޯ̧�X�V
        '****************************************
        If intWinRet = WsWSRC.NORMAL Then
            '(�d������M�����ꍇ)

            If 0 < objwsiData.Length Then
                '(�ް�����M�����ꍇ)


                ''****************************************
                ''���Ď�M�ޯ̧�Ɍ���
                ''****************************************
                'If IsNull(mbytRecvTelBuffListener) Then
                '    mbytRecvTelBuffListener = mobjSockListener.bytRecvText
                'Else
                '    ReDim Preserve mbytRecvTelBuffListener(mbytRecvTelBuffListener.Length + mobjSockListener.bytRecvText.Length - 1)
                '    mobjSockListener.bytRecvText.CopyTo(mbytRecvTelBuffListener, mbytRecvTelBuffListener.Length - 1)
                'End If


                '****************************************
                '�d�������𒊏o & ���Ď�M�ޯ̧�X�V
                '****************************************
                Dim bytAryData(objwsiData.Length - 1) As Byte
                For ii As Integer = 0 To UBound(bytAryData)
                    bytAryData(ii) = objwsiData.Data(ii)
                Next
                strRecvText = mobjGetTelegram.GetTelegramDataLength101(bytAryData _
                                                                     , strFDENBUN_PRM1 _
                                                                     , strFDENBUN_PRM2 _
                                                                     )
                'strRecvText = mobjGetTelegram.GetTelegramDataLength101(mbytRecvTelBuffListener _
                '                                                     , strFDENBUN_PRM1 _
                '                                                     , strFDENBUN_PRM2 _
                '                                                     )
                If IsNotNull(strRecvText) Then
                    Call AddToLog(MCIA_MSG_011 & strRecvText) '�d���擾۸ޏo��
                End If


            Else
                '(�ް�����M���Ă��Ȃ��ꍇ)
                Call AddToLog("nsp_input�Ų���Ă���M���܂������A�ް��͎�M���܂���ł����B")
            End If

        ElseIf intWinRet = WsWSRC.TIMEOUT Then     '// ���A���F�^�C���A�E�g(10)
            '(��ѱ��)
            'NOP
        Else
            '(���̑�)
            Call AddToLog("nsp_input�����s���܂����BRC =" + Str(intWinRet) + " �ڍ׃R�[�h =" + Str(mobjWinSAM.ns_GetLastError))
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
    Private Sub MCIA_100001()
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
            '��ϰ����
            '*****************************************************
            Dim objDiff As TimeSpan = mdtmBeforeDBTime.AddMilliseconds(mintDBReadTimer) - Now
            If 0 < objDiff.TotalMilliseconds Then
                Exit Sub
            End If
            mdtmBeforeDBTime = Now


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
            '==========================================
            '�y�ݔ���ԁz   ��ײ݊m�F
            '==========================================
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(mobjOwner, mobjDb, mobjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID = mstrFEQ_ID                 'MCI�ȸ���
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(False)             '�擾
            If TO_INTEGER(objTSTS_EQ_CTRL.FEQ_CUT_STS) = FLAG_OFF _
               And TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS) = FEQ_STS_SMCI_ONLINE Then
                '(�uMCI�v = �u��ײ݁v�̏ꍇ)

                objTLIF_TRNS_SEND.FEQ_ID = mstrFEQ_ID
                udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_LATEST()      '���M�ޯ̧����
                If udtRet <> RetCode.OK Then
                    '(���M�ޯ̧���ް����Ȃ��ꍇ)
                    Exit Sub            '�E�o
                End If

            Else
                '(�uMCI�v = �u��ײ݁v�̏ꍇ)

                objTLIF_TRNS_SEND.FEQ_ID = mstrFEQ_ID
                udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_LATEST_FOFFLINE_FLAG()       '���M�ޯ̧����(��ײ��׸�=FLAG_ON�̂�)
                If udtRet <> RetCode.OK Then
                    '(���M�ޯ̧���ް����Ȃ��ꍇ)
                    Exit Sub            '�E�o
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
            If IsNotNull(strTelegram) Then
                udtRet = SendDataEQLintener(strTelegram, objTLIF_TRNS_SEND.FTEXT_ID)
            End If


            '*****************************************************
            '÷�đ��M���ʂɂ�菈���ύX
            '*****************************************************
            '����
            Select Case udtRet
                Case RetCode.OK
                    '=========================================
                    '����
                    '=========================================
                    Select Case objTLIF_TRNS_SEND.FTEXT_ID
                        Case "aa" _
                            '(��������̏ꍇ)
                            Call UpdateSendFPROGRESS(FPROGRESS_SACT)             '�������䑗�M����̪��.�ʐM���      ���
                            'mblnSockSend = True                                 '���đ��M�׸�
                            mintResponsWait = FLAG_ON                           '�����҂��׸�                       ���
                        Case Else
                            '(�����Ȃ��̏ꍇ)
                            Call UpdateSendFPROGRESS(FPROGRESS_SEND)             '�������䑗�M����̪��.�ʐM���      ���
                            mblnSockSend = True                                 '���đ��M�׸�
                            mintResponsWait = FLAG_OFF                          '�����҂��׸�                       ���
                            Call InitializeDBReadTimer()                        '������DB��������
                    End Select

                Case Else
                    '=========================================
                    '�ُ�
                    '=========================================
                    Call UpdateSendFPROGRESS(FPROGRESS_SERR_MCI)         '�������䑗�M����̪��.�ʐM���      ���
                    mintResponsWait = FLAG_OFF                          '�����҂��׸�                       ���
                    '' ''Call SeqNoSendUpdate()                         '���ݽNo + 1                        ���
                    Call mobjEQSendTelBuff.CLEAR_PROPERTY()            '���M�ޯ̧                          �폜

                    '۸ޏo��
                    Dim strMessage As String = ""
                    strMessage &= "�װ�����������ׁA����ں��ނ̏����͎��s�o���܂���ł����B"
                    strMessage &= "[�o�^��:" & objTLIF_TRNS_SEND.FENTRY_NO & "]"
                    strMessage &= "[�ݔ�ID:" & objTLIF_TRNS_SEND.FEQ_ID & "]"
                    strMessage &= "[�����ID:" & objTLIF_TRNS_SEND.FCOMMAND_ID & "]"
                    strMessage &= "[���Ұ�1:" & objTLIF_TRNS_SEND.FDENBUN_PRM1 & "]"
                    strMessage &= "[���Ұ�2:" & objTLIF_TRNS_SEND.FDENBUN_PRM2 & "]"
                    strMessage &= "[���Ұ�3:" & objTLIF_TRNS_SEND.FDENBUN_PRM3 & "]"
                    strMessage &= "[���Ұ�4:" & objTLIF_TRNS_SEND.FDENBUN_PRM4 & "]"
                    strMessage &= "[���Ұ�5:" & objTLIF_TRNS_SEND.FDENBUN_PRM5 & "]"
                    Call AddToLog(strMessage)

            End Select


        Catch ex As Exception
            ComError(ex)

        End Try
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
    Private Sub MCIA_100002(ByVal strRecvText As String _
                          , ByVal strFDENBUN_PRM1 As String _
                          , ByVal strFDENBUN_PRM2 As String _
                          )
        Try
            'Dim intRet As RetCode
            Dim strMsg As String = ""       'ү����
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(mobjOwner, mobjDb, mobjDbLog)


            '*****************************************************
            '��M�d���L������
            '*****************************************************
            If strRecvText = "" Then Exit Sub
            mdtmBeforeRecvTime = Now


            '*****************************************************
            '�y�ݔ��ʐM۸ށz             �ǉ�
            '*****************************************************
            Dim strFTEXT_ID As String = FTEXT_ID_JR_CARD      '÷��ID
            Call AddDBRecvLog_LOG(strFTEXT_ID _
                                , strRecvText _
                                , "" _
                                )


            '*****************************************************
            '�y�������䑗��M����̪���z   �ǉ�
            '*****************************************************
            Dim intFRES_CD_EQ As String = ""                    '���������MIFð��قɒǉ�����ݔ���������
            'Dim strFDENBUN_PRM1 As String = Nothing             '�d�����Ұ�1
            'Dim strFDENBUN_PRM2 As String = Nothing             '�d�����Ұ�2
            Call AddDBRecvLIF_TRNS_RECV(FCOMMAND_ID_SOT _
                                      , strRecvText _
                                      , strFTEXT_ID _
                                      , FPROGRESS_SEND _
                                      , intFRES_CD_EQ _
                                      , strFDENBUN_PRM1 _
                                      , strFDENBUN_PRM2 _
                                      )


            ' '' '' '' '' ''*******************************************************
            ' '' '' '' '' ''�ԐM�d��                       �쐬
            ' '' '' '' '' ''*******************************************************
            '' '' '' '' ''Dim strSendText As String = ""
            '' '' '' '' ''strSendText = MakeReturnTelegram(strRecvText _
            '' '' '' '' ''                               , strFDENBUN_PRM1 _
            '' '' '' '' ''                               , strFDENBUN_PRM2 _
            '' '' '' '' ''                               )
            ' '' '' '' '' ''Dim strAryRecvText() As String = Split(strRecvText, "_")
            ' '' '' '' '' ''Dim strSendText As String
            ' '' '' '' '' ''strSendText = objTPRG_SYS_HEN.SJ000000_031
            ' '' '' '' '' ''strSendText &= "_" & "f1"       '���亰��
            ' '' '' '' '' ''strSendText &= "_" & "f0"       '���亰��
            ' '' '' '' '' ''strSendText &= "_" & strAryRecvText(18)       '���ތ����@�敪
            ' '' '' '' '' ''strSendText &= "_" & strAryRecvText(19)       '���ތ����@�敪
            ' '' '' '' '' ''strSendText &= "_" & strAryRecvText(20)       '����ذ�ދ敪
            ' '' '' '' '' ''strSendText &= "_" & strAryRecvText(21)       '����ذ�ދ敪
            ' '' '' '' '' ''strSendText &= "_" & "f0"       '�����׸�
            ' '' '' '' '' ''strSendText &= "_" & "f1"       '�����׸�
            ' '' '' '' '' ''For ii As Integer = 1 To 56 : strSendText &= "_" & "40" : Next      '�\��
            ' '' '' '' '' ''strSendText &= "_" & "c6"       'BCC??
            ' '' '' '' '' ''strSendText &= "_" & "83"       'BCC??


            ' '' '' '' '' ''*******************************************************
            ' '' '' '' '' ''�ԐM
            ' '' '' '' '' ''*******************************************************
            '' '' '' '' ''If IsNotNull(strSendText) Then
            '' '' '' '' ''    intRet = SendDataEQLintener(strSendText)
            '' '' '' '' ''End If

            '' '' '' '' '' ''If strFDENBUN_PRM1 = CAR_SYUBETU_REQ Then
            '' '' '' '' '' ''    intRet = SendDataEQLintener(objTPRG_SYS_HEN.SJ000000_031)
            '' '' '' '' '' ''Else
            '' '' '' '' '' ''    intRet = SendDataEQLintener(objTPRG_SYS_HEN.SJ000000_032)
            '' '' '' '' '' ''End If


        Catch ex As Exception
            ComError(ex)

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
        objTLOG_EQ.FHASSEI_DT = mdtmNow                     '��������
        objTLOG_EQ.FDIRECTION = FDIRECTION_SRECV             '����
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



#Region "  �ԐM�d���쐬                                 "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ԐM�d���쐬
    ''' </summary>
    ''' <param name="strRecvText">����Ɏ�M�ł����ް�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function MakeReturnTelegram(ByVal strRecvText As String _
                                      , ByVal strFDENBUN_PRM1 As String _
                                      , ByVal strFDENBUN_PRM2 As String _
                                      ) _
                                      As String
        'Dim intRet As RetCode
        Dim strMsg As String = ""       'ү����


        '**************************************************
        '�����ݒ�
        '**************************************************
        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(mobjOwner, mobjDb, mobjDbLog)
        Dim strAryRecvText() As String = Split(strRecvText, "_")    '��M�d��
        Dim strSendText As String = ""                              '���M�d��


        '**************************************************
        '�����׸�               �쐬
        '**************************************************
        Dim strRetFlag As String = ""
        Select Case strFDENBUN_PRM2
            Case "01", "02", "04", "08", "10", "20", "40", "80"
                '(���\��)
                '(�ڎԎ�)
                '(�o�\��)

                strRetFlag = MakeReturnTelegramRetFlag(strRecvText, strFDENBUN_PRM1, strFDENBUN_PRM2)

            Case Else
                '(���̑��̏ꍇ)

                Return ""

        End Select


        '**************************************************
        '���M�d��               �쐬
        '**************************************************
        'strSendText = objTPRG_SYS_HEN.SJ000000_031
        'strSendText &= "_" & "00"       '??
        'strSendText &= "_" & "00"       '??
        strSendText = "f1"              '���亰��
        strSendText &= "_" & "f0"       '���亰��
        strSendText &= "_" & strAryRecvText(2)        '���ތ����@�敪
        strSendText &= "_" & strAryRecvText(3)        '���ތ����@�敪
        strSendText &= "_" & strAryRecvText(4)        '����ذ�ދ敪
        strSendText &= "_" & strAryRecvText(5)        '����ذ�ދ敪
        strSendText &= strRetFlag                     '�����׸�
        For ii As Integer = 1 To 56 : strSendText &= "_" & "40" : Next      '�\��
        'strSendText &= "_" & "c6"       'BCC??
        'strSendText &= "_" & "83"       'BCC??


        '**************************************************
        '���M�d��               �ݒ�
        '**************************************************
        Return strSendText


    End Function
#End Region
#Region "  �ԐM�d���쐬(�ڎԎ��̉����׸ލ쐬)           "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �ԐM�d���쐬(�ڎԎ��̉����׸ލ쐬)
    ''' </summary>
    ''' <param name="strRecvText">����Ɏ�M�ł����ް�</param>
    ''' <returns>�����׸�</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function MakeReturnTelegramRetFlag(ByVal strRecvText As String _
                                             , ByVal strFDENBUN_PRM1 As String _
                                             , ByVal strFDENBUN_PRM2 As String _
                                             ) _
                                             As String
        Dim intRet As RetCode
        Dim strMsg As String = ""       'ү����



        '**************************************************
        '�����ݒ�
        '**************************************************
        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(mobjOwner, mobjDb, mobjDbLog)
        Dim strRetFlag As String = "_c5_c5"         '�����׸�


        '**************************************************
        '���qϽ�                �擾
        '**************************************************
        Dim objMST_SYARYOU As New TBL_XMST_SYARYOU(mobjOwner, mobjDb, mobjDbLog)
        objMST_SYARYOU.XCARD_NO = strFDENBUN_PRM1           '���އ�
        intRet = objMST_SYARYOU.GET_XMST_SYARYOU(False)     '�擾
        If intRet = RetCode.OK Then
            '(���������ꍇ)

            If TO_INTEGER(objMST_SYARYOU.XLOADER_POSSIBLE) = FLAG_ON Then
                '(۰�ޑΉ��̏ꍇ)


                '**************************************************
                '���\����(�����\�ް��L��)
                '**************************************************
                Dim strSQL As String                'SQL��
                Dim objAryXPLN_OUT As New TBL_XPLN_OUT(mobjOwner, mobjDb, mobjDbLog)
                strSQL = ""
                strSQL &= vbCrLf & "SELECT"
                strSQL &= vbCrLf & "    *"
                strSQL &= vbCrLf & " FROM"
                strSQL &= vbCrLf & "    XPLN_OUT"       '�o�׎w���ڍ�
                strSQL &= vbCrLf & " WHERE"
                strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '���q�ԍ�
                strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS <= " & TO_STRING(XSYUKKA_STS_JOUT)             '�o�׏�(�o�ɍ�)
                strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS >= " & TO_STRING(XSYUKKA_STS_JNON)             '�o�׏�(��t��)
                strSQL &= vbCrLf & " ORDER BY"
                strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D"                                                     '�o�ד�
                strSQL &= vbCrLf & "   ,XPLN_OUT.XUNKOU_NO"                                                     '�q�ɕʉ^�s��
                strSQL &= vbCrLf & "   ,XPLN_OUT.XHENSEI_NO"                                                    '�Ґ���
                strSQL &= vbCrLf & "   ,XPLN_OUT.XDENPYOU_NO"                                                   '�`�[��
                strSQL &= vbCrLf
                objAryXPLN_OUT.USER_SQL = strSQL
                intRet = objAryXPLN_OUT.GET_XPLN_OUT_USER()
                If intRet = RetCode.OK Then
                    '(���������ꍇ)


                    Select Case strFDENBUN_PRM2
                        Case "01"
                            '**************************************************
                            '(���\��)
                            '**************************************************
                            If XSYUKKA_STS_JNON = objAryXPLN_OUT.ARYME(0).XSYUKKA_STS Then
                                '(���\�O�̏ꍇ)
                                strRetFlag = "_f0_f1"
                            Else
                                '(���\�O����Ȃ��ꍇ)
                                strMsg = "���\�s�̐i���ׁ̈A���\�o���܂���B[���އ�:" & strFDENBUN_PRM1 & "][�ް���:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][����ذ�ދ敪:" & strFDENBUN_PRM2 & "][�o�׏�:" & TO_STRING(objAryXPLN_OUT.ARYME(0).XSYUKKA_STS) & "]"
                            End If


                        Case "02"
                            '**************************************************
                            '(�o�\��)
                            '**************************************************
                            If XSYUKKA_STS_JREQ <= objAryXPLN_OUT.ARYME(0).XSYUKKA_STS And objAryXPLN_OUT.ARYME(0).XSYUKKA_STS <= XSYUKKA_STS_JOUT Then
                                '(�o�\�O�̏ꍇ)
                                strRetFlag = "_f0_f4"
                            Else
                                '(�o�\�O����Ȃ��ꍇ)
                                strMsg = "�o�\�s�̐i���ׁ̈A�o�\�o���܂���B[���އ�:" & strFDENBUN_PRM1 & "][�ް���:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][����ذ�ދ敪:" & strFDENBUN_PRM2 & "][�o�׏�:" & TO_STRING(objAryXPLN_OUT.ARYME(0).XSYUKKA_STS) & "]"
                            End If


                        Case "04", "08", "10", "20", "40", "80"
                            '**************************************************
                            '(�ڎԎ�)
                            '**************************************************
                            '**************************************************
                            '�ް��̓���
                            '**************************************************
                            Dim strXBERTH_NO As String = ""
                            Select Case strFDENBUN_PRM2
                                Case "04" : strXBERTH_NO = XBERTH_NO_JX01
                                Case "08" : strXBERTH_NO = XBERTH_NO_JX02
                                Case "10" : strXBERTH_NO = XBERTH_NO_JX03
                                Case "20" : strXBERTH_NO = XBERTH_NO_JX04
                                Case "40" : strXBERTH_NO = XBERTH_NO_JX05
                                Case "80" : strXBERTH_NO = XBERTH_NO_JX06
                            End Select


                            If objAryXPLN_OUT.ARYME(0).XBERTH_NO = strXBERTH_NO Then
                                '(�ް�������v���Ă���ꍇ)
                                If XSYUKKA_STS_JREQ <= objAryXPLN_OUT.ARYME(0).XSYUKKA_STS And objAryXPLN_OUT.ARYME(0).XSYUKKA_STS <= XSYUKKA_STS_JOUT Then
                                    '(����̏ꍇ)
                                    strRetFlag = "_f0_f5"
                                Else
                                    '(�ُ�̏ꍇ)
                                    strMsg = "�ڎԕs�̐i���ׁ̈A�ڎԏo���܂���B[���އ�:" & strFDENBUN_PRM1 & "][�ް���:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][����ذ�ދ敪:" & strFDENBUN_PRM2 & "][�o�׏�:" & TO_STRING(objAryXPLN_OUT.ARYME(0).XSYUKKA_STS) & "]"
                                End If
                            Else
                                '(�ް�������v���Ă��Ȃ��ꍇ)
                                strMsg = "�ް�������v���Ă��܂���B[���އ�:" & strFDENBUN_PRM1 & "][�ް���:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][����ذ�ދ敪:" & strFDENBUN_PRM2 & "]"
                            End If


                    End Select


                Else
                    '(������Ȃ������ꍇ)
                    strMsg = "�o�׎w�������݂��܂���B[���އ�:" & strFDENBUN_PRM1 & "]"
                End If


            Else
                '(۰�ޖ��Ή��̏ꍇ)
                strMsg = "۰�ނɑΉ����Ă��Ȃ����p��t���s���܂����B[���އ�:" & strFDENBUN_PRM1 & "]"
            End If


        Else
            '(������Ȃ��ꍇ)
            strMsg = "���qϽ���������܂���B[���އ�:" & strFDENBUN_PRM1 & "]"
        End If
        If IsNotNull(strMsg) Then
            Call ErrorAdd(mstrFMSG_ID_ERR_USER, strMsg)
        End If


        '**************************************************
        '���M�d��               �ݒ�
        '**************************************************
        Return strRetFlag


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

            mbytRecvTelBuffClient = Nothing                          '���Ď�M�ޯ̧(�ײ���)
            mbytRecvTelBuffListener = Nothing                        '���Ď�M�ޯ̧(ؽŰ)


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
