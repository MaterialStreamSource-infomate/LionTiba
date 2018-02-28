'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zMCIҲݸ׽(Melsec�ʐM CW6)
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
    Private mobjMelsec As ComMelsec.clsMelsec           'Melsec�ʐM�׽
    Private mobjEQSendTelBuff As TBL_TLIF_TRNS_SEND     '�d�����M�ޯ̧
    'Private mobjEQSendResBuff As TBL_TLIF_TRNS_SEND    '�����d�����M�ޯ̧
    Private mobjGetTelegram As clsGetTelegram           '�d���p÷�Ď擾�׽
    Private mobjAryTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL     'MCI����ĒʒmϽ�


    '==================================================
    '�����ϐ�
    '==================================================
    'ڼ޽��֌W
    Private mintNRegD(REG_MAX) As Integer                   'Dڼ޽��l�z��
    Private mintBRegD(REG_MAX) As Integer                   'Dڼ޽��l�z��(�O��l)
    Private mintRegDBuff(REG_MAX) As Object                 'Dڼ޽��l�z��(�����ر�ޯ̧)
    Private mblnConnect As Boolean                          '�ڑ��׸�
    Private mblnOnline As Boolean                           '��ײ��׸�
    Private mdtmConnectBefore As Date                       '�ŏI�ڑ��m�F���t����
    Private mdtmBeforeOnline As Date                        '�O���ײ���������

    '���̑�
    Private mintSendCount As Integer            '�đ��M��
    Private mdtmBeforeRecvTime As Date          '�O���M����
    Private mdtmBeforeSendTime As Date          '�O�񑗐M����
    Private mstrRecvTelBuff As String           '��M�ޯ̧
    Private mintResponsWait As Integer          '�����҂��׸�
    Private mdtmBeforeConnTime As Date          '�O��ڑ�����
    'Private mblnConnect As Boolean              '���Đڑ��׸�

    Private Const REG_START As Integer = 0
    Private Const REG_MAX As Integer = REG_START + REG_COUNT_MAX
    Private Const REG_COUNT_MAX As Integer = 6523

    '==================================================
    'Config
    '==================================================
    'clsMelsec�p
    Private mintUNIT_NO As Integer                  '�ݔ��ԍ�
    Private mstrPROTOCOL_TYPE As String             '�ʐM���ĺق��w��
    Private mstrPORT_NUMBER As String               '�ƯĂƂ̐ڑ��߰Ĕԍ����w��
    Private mstrHOST As String                      '�ڑ�νĖ�(IP���ڽ)���w��
    Private mstrCPU_TIMEOUT As String               'CPU�Ď���ς��w��
    Private mstrTIMEOUT As String                   '��ѱ�Ēl���w��
    Private mstrSRC_NETWORK As String               '�v����ȯ�ܰ��ԍ����w��
    Private mintSRC_STATION As Integer              '�v����ǔԂ��w��
    '������������************************************************************************************************************
    'JobMate:S.Ouchi 2015/06/25 CW6�ǉ��Ή� ������������
    Private mintSRC_STATION_DB As Integer           '�v����ǔԂ��w��(DB)
    'JobMate:S.Ouchi 2015/06/25 CW6�ǉ��Ή� ������������
    '������������************************************************************************************************************
    Private mintLogWrite As String                  '۸ޏ�������(1:�L�A2:��)
    Private mintSockRetry As Integer                '��ײ��(��)

    '���̑�
    Private mintConnectTimer As Integer             '�Đڑ����� (ms)


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
            If IsNotNull(mobjMelsec) Then mobjMelsec.intDebugFlag = Value 'Melsec�ʐM�׽
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
                '��ײ�����
                '*****************************************************
                Call MCIA_200004()
                If mblnOnline = False Then Exit Sub


                '*****************************************************
                'ڼ޽��Ǎ�
                '*****************************************************
                Call UpdateReadArray()      '�Ǎ�ڼ޽��z��X�V
                If mblnConnect = False Then Exit Sub


                '*****************************************************
                '����Ēʒm����
                '*****************************************************
                Call MCIA_200001()


                '*****************************************************
                'ڼ޽��l�z��(�O��l)�ֺ�߰
                '*****************************************************
                Call CopyRegR()


                '*****************************************************
                'DB���M�ޯ̧���� & �d�����M     ����
                '*****************************************************
                Call MCIA_100001(True)
                'Call WriteArrayWrite()      '����ڼ޽��z�񏑍���


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
#Region "  Ҳݏ���_Backup       "
    ''''*******************************************************************************************************************
    '''' <summary>
    '''' Ҳݏ���
    '''' </summary>
    '''' <remarks></remarks>
    ''''*******************************************************************************************************************
    'Public Overridable Sub Main()
    '    Try
    '        mobjDb.BeginTrans()     '��ݻ޸��݊J�n
    '        Try
    '            'Dim strMsg As String                    'ү����


    '            '*****************************************************
    '            '�F�X������
    '            '*****************************************************
    '            mdtmNow = Now


    '            '*****************************************************
    '            'DB���M�ޯ̧���� & �d�����M     ����
    '            '*****************************************************
    '            Call MCIA_100001(True)


    '            '*****************************************************
    '            '�d����M�m�F
    '            '*****************************************************
    '            Dim strRecvText As String = ""          '��M�d��
    '            Call RecvDataEQ(strRecvText)


    '            ''*****************************************************
    '            ''�d����M       ����
    '            ''*****************************************************
    '            'Call MCIA_100002(strRecvText)


    '            '*****************************************************
    '            '���ނֿ��đ��M
    '            '*****************************************************
    '            Call MCI_000001()


    '        Catch ex As Exception
    '            Call ComError(ex)

    '        Finally
    '            mobjDb.Commit()     '�Я�

    '        End Try
    '    Catch ex As Exception
    '        Call ComError(ex)

    '    End Try
    'End Sub
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
        Dim intRet As RetCode


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
        Dim objConfig As New clsConnectConfig(CONFIG_MCIF)                              'Confiģ�ِڑ��׽����

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
        'Confiģ�ُ��擾(�ŗL����)
        '*****************************************************
        'clsMelsec�p
        mintUNIT_NO = TO_INTEGER(objConfig.GET_INFO(GKEY_MEL_UNIT_NO))                                  '�ݔ��ԍ�
        mstrPROTOCOL_TYPE = TO_STRING(objConfig.GET_INFO(GKEY_MEL_PROTOCOL_TYPE))                       '�ʐM���ĺق��w��
        mstrPORT_NUMBER = TO_STRING(objConfig.GET_INFO(GKEY_MEL_PORT_NUMBER))                           '�ƯĂƂ̐ڑ��߰Ĕԍ����w��
        mstrHOST = TO_STRING(objConfig.GET_INFO(GKEY_MEL_HOST))                                         '�ڑ�νĖ�(IP���ڽ)���w��
        mstrCPU_TIMEOUT = TO_STRING(objConfig.GET_INFO(GKEY_MEL_CPU_TIMEOUT))                           'CPU�Ď���ς��w��
        mstrTIMEOUT = TO_STRING(objConfig.GET_INFO(GKEY_MEL_TIMEOUT))                                   '��ѱ�Ēl���w��
        mstrSRC_NETWORK = TO_STRING(objConfig.GET_INFO(GKEY_MEL_SRC_NETWORK))                           '�v����ȯ�ܰ��ԍ����w��
        mintSRC_STATION = TO_INTEGER(objConfig.GET_INFO(GKEY_MEL_SRC_STATION))                          '�v����ǔԂ��w��
        '������������************************************************************************************************************
        'JobMate:S.Ouchi 2015/06/25 CW6�ǉ��Ή� ������������
        mintSRC_STATION_DB = TO_INTEGER(objConfig.GET_INFO(GKEY_MEL_SRC_STATION_DB))                    '�v����ǔԂ��w��(DB)
        'JobMate:S.Ouchi 2015/06/25 CW6�ǉ��Ή� ������������
        '������������************************************************************************************************************
        mintLogWrite = TO_INTEGER(objConfig.GET_INFO(GKEY_MEL_LOGWRITE))                                '۸ޏ�������(1:�L�A2:��)
        mintSockRetry = TO_INTEGER(objConfig.GET_INFO(GKEY_MEL_SOCKRETRY))                              '��ײ��(��)
        '���̑�
        mintConnectTimer = TO_INTEGER(objConfig.GET_INFO(GKEY_MCI_CONNECT_TIMER))       '�Đڑ����� (ms)


        '****************************************************
        '�ݔ���           �擾
        '****************************************************
        Dim strSQL As String = ""
        strSQL &= " SELECT "
        strSQL &= "    * "
        strSQL &= " FROM "
        strSQL &= "    TSTS_EQ_CTRL "
        strSQL &= " WHERE "
        '������������************************************************************************************************************
        'JobMate:S.Ouchi 2015/06/25 CW6�ǉ��Ή� ������������
        '' ''strSQL &= "       SUBSTR(FEQ_ID_LOCAL, 1, 3) = 'M" & Change10To16(mintSRC_STATION, 2).ToUpper & "' "
        strSQL &= "       SUBSTR(FEQ_ID_LOCAL, 1, 3) = 'M" & Change10To16(mintSRC_STATION_DB, 2).ToUpper & "' "
        'JobMate:S.Ouchi 2015/06/25 CW6�ǉ��Ή� ������������
        '������������************************************************************************************************************
        strSQL &= " ORDER BY "
        strSQL &= "    FEQ_ID_LOCAL "
        mobjAryTSTS_EQ_CTRL = New TBL_TSTS_EQ_CTRL(mobjOwner, mobjDb, mobjDbLog)
        mobjAryTSTS_EQ_CTRL.USER_SQL = strSQL
        intRet = mobjAryTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL_USER()
        If intRet <> RetCode.OK Then
            '(������Ȃ������ꍇ)
            Throw New Exception(ERRMSG_NOTFOUND_TSTS_EQ_CTRL)
        End If


        '****************************************************
        'Melsec�ʐM     �ڑ�
        '****************************************************
        Call Open()


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
    Public Sub AddToManyLog(ByVal strMsg_1 As String)

        If intDebugFlag = 1 Then
            mobjOwner.AddToManyLog(strMsg_1)
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


        '*****************************************************
        'Melsec�ʐM��޼ު��         ��ı���
        '*****************************************************
        If IsNull(mobjMelsec) = False Then
            mobjMelsec.Close()
            mobjMelsec = Nothing
        End If
        mobjMelsec = New ComMelsec.clsMelsec(mobjOwner)                 'Melsec�ʐM�׽
        mobjMelsec.strSockMelSendAddress = mstrHOST                     'PLC��IP���ڽ
        mobjMelsec.intSockMelSendPort = TO_INTEGER(mstrPORT_NUMBER)     'PLC���߰�No.
        mobjMelsec.intACPUTimer = TO_INTEGER(mstrCPU_TIMEOUT)           'CPU�Ď����(250ms�P��:���ǂ̂ƒʐM�̏ꍇ"0001"�`"0040"(0.25�b�`10�b))
        mobjMelsec.intDebugFlag = mintDebugFlag                         '���ޯ���׸�
        mobjMelsec.intSockRetry = mintSockRetry                         '��ײ��(��)
        mobjMelsec.intSockTimeOut = TO_INTEGER(mstrTIMEOUT)             '��ѱ�Ď���(�b)(����:1�`10�b�A����:1�`60�b)
        mobjMelsec.Open()                                               '�����


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
            'Melsec�ʐM��޼ު��         �۰��
            '****************************************************
            If IsNull(mobjMelsec) = False Then
                mobjMelsec.Close()
                mobjMelsec = Nothing
            End If


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




    End Sub
#End Region

#Region "  ڼ޽��Ǎ���(ܰ�ޒP��)"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ڼ޽��Ǎ��� AJ71E71(ܰ�ޒP��)
    ''' </summary>
    ''' <param name="intPlcNo">PC�ԍ�</param>
    ''' <param name="udtREG_TYPE">ڼ޽�����</param>
    ''' <param name="intAdrs">�擪ڼ޽�</param>
    ''' <param name="intSize">�Ǎ���ܰ�ސ�</param>
    ''' <param name="intData">�ް��l</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function AreaRead(ByVal intPlcNo As Integer _
                           , ByVal udtREG_TYPE As ComMelsec.clsMelsec.RegType _
                           , ByVal intAdrs As Integer _
                           , ByVal intSize As Integer _
                           , ByRef intData() As Integer _
                           ) _
                           As ComMelsec.clsMelsec.RetCode
        Dim intReturn As ComMelsec.clsMelsec.RetCode = ComMelsec.clsMelsec.RetCode.NG                   '�֐��ߒl


        '***************************************
        'ڼ޽��Ǎ�
        '***************************************
        intReturn = mobjMelsec.AreaReadAJ71E71(intPlcNo, udtREG_TYPE, intAdrs, intSize, intData)


        Return intReturn
    End Function
#End Region
#Region "  ڼ޽�������(ܰ�ޒP��)"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ڼ޽�������(ܰ�ޒP��)
    ''' </summary>
    ''' <param name="intPlcNo">PC�ԍ�</param>
    ''' <param name="udtREG_TYPE">ڼ޽�����</param>
    ''' <param name="intAdrs">�擪ڼ޽�</param>
    ''' <param name="intSize">������ܰ�ސ�</param>
    ''' <param name="intData">�ް��l</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function AreaWrite(ByVal intPlcNo As Integer _
                            , ByVal udtREG_TYPE As ComMelsec.clsMelsec.RegType _
                            , ByVal intAdrs As String _
                            , ByVal intSize As Integer _
                            , ByVal intData() As Integer _
                            ) _
                            As ComMelsec.clsMelsec.RetCode
        Dim intReturn As ComMelsec.clsMelsec.RetCode = ComMelsec.clsMelsec.RetCode.NG                   '�֐��ߒl


        '***************************************
        'ڼ޽�����
        '***************************************
        intReturn = mobjMelsec.AreaWriteAJ71E71(intPlcNo, udtREG_TYPE, intAdrs, intSize, intData)


        Return intReturn
    End Function
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
        Try
            Dim udtRet As RetCode



            '*****************************************************
            '�����׸�����
            '*****************************************************
            If mintResponsWait = FLAG_ON Then
                '(�����׸� = ON �̏ꍇ)
                Exit Sub
            End If


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
                udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_LATEST_ANY()      '���M�ޯ̧����
                'udtRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_LATEST()      '���M�ޯ̧����
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
            'Call SetSendBuff(objTLIF_TRNS_SEND)


            '*****************************************************
            'ID�ɂ���ĕ��� & ÷�đ��M
            '*****************************************************
            For ii As Integer = LBound(objTLIF_TRNS_SEND.ARYME) To UBound(objTLIF_TRNS_SEND.ARYME)
                '(ٰ��:�擾����ں��ތ���)


                Dim objTempTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND = objTLIF_TRNS_SEND.ARYME(ii)
                Dim strTelegram As String = ""          '���M�d��
                Call SetSendBuff(objTempTLIF_TRNS_SEND)
                Select Case objTempTLIF_TRNS_SEND.FCOMMAND_ID
                    Case FCOMMAND_ID_SONLINE             '��ײݗv��
                        udtRet = ID01Process(objTempTLIF_TRNS_SEND, strTelegram)

                    Case FCOMMAND_ID_SOFFLINE            '��ײݗv��
                        udtRet = ID02Process(objTempTLIF_TRNS_SEND, strTelegram)

                    Case FCOMMAND_ID_SWRITE_REG_WORD
                        '(ڼ��������v��(ܰ�ޑΉ�))
                        udtRet = ID0101Process(objTempTLIF_TRNS_SEND)

                    Case FCOMMAND_ID_SWRITE_REG_BIT
                        '(ڼ��������v��(�ޯđΉ�))
                        udtRet = ID0102Process(objTempTLIF_TRNS_SEND)

                    Case FCOMMAND_ID_JREAD_REG_ALL
                        '(ڼ����Ǎ��v��(�Sڼ޽�))
                        udtRet = ID0201Process(objTempTLIF_TRNS_SEND)

                    Case FCOMMAND_ID_SSQL                'SQL���s
                        udtRet = IDSQLProcess(objTempTLIF_TRNS_SEND)
                        Exit Sub

                    Case Else                           '���̑�
                        udtRet = IDZZProcess(objTempTLIF_TRNS_SEND, strTelegram)

                End Select


                '*****************************************************
                '�d�����M
                '*****************************************************
                If udtRet = RetCode.OK And strTelegram <> "" Then
                    udtRet = SendDataEQ(strTelegram, objTLIF_TRNS_SEND)    '�d�����M
                    mintSendCount = 1                                       '���M��(����)
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
                        Select Case objTempTLIF_TRNS_SEND.FTEXT_ID
                            Case "xxxx"
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
                        strMessage &= "[�o�^��:" & objTempTLIF_TRNS_SEND.FENTRY_NO & "]"
                        strMessage &= "[�ݔ�ID:" & objTempTLIF_TRNS_SEND.FEQ_ID & "]"
                        strMessage &= "[�����ID:" & objTempTLIF_TRNS_SEND.FCOMMAND_ID & "]"
                        strMessage &= "[���Ұ�1:" & objTempTLIF_TRNS_SEND.FDENBUN_PRM1 & "]"
                        strMessage &= "[���Ұ�2:" & objTempTLIF_TRNS_SEND.FDENBUN_PRM2 & "]"
                        strMessage &= "[���Ұ�3:" & objTempTLIF_TRNS_SEND.FDENBUN_PRM3 & "]"
                        strMessage &= "[���Ұ�4:" & objTempTLIF_TRNS_SEND.FDENBUN_PRM4 & "]"
                        strMessage &= "[���Ұ�5:" & objTempTLIF_TRNS_SEND.FDENBUN_PRM5 & "]"
                        Call AddToLog(strMessage)

                End Select


            Next


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
            Dim objTel As New clsTelegram(CONFIG_TELEGRAM_MCV)
            objTel.FORMAT_ID = FORMAT_MCV_000                   '̫�ϯĖ����    (���ɉ��ł��ǂ�)
            objTel.TELEGRAM_PARTITION = strRecvText             '��������d�����
            objTel.PARTITION()                                  '�d������


            '*****************************************************
            '�y�ݔ��ʐM۸ށz             �ǉ�
            '*****************************************************
            Dim strFTEXT_ID As String = ""                   '÷��ID
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

#Region "  MCIA_200001  ����Ēʒm               ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ����Ēʒm
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_200001()
        Try


            '*****************************************************
            '�ݔ��󋵍X�V01
            '*****************************************************
            For Each objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL In mobjAryTSTS_EQ_CTRL.ARYME
                '(ٰ��:��������ڼ޽���)
                Call InsertLIF_TRNS_RECV_FCOMMAND_ID_SEVENT(objTSTS_EQ_CTRL)
            Next


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  MCIA_200004  ��ײ�����               ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ��ײ�����
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub MCIA_200004()
        Try
            Dim blnOnlineBefore As Boolean = mblnOnline


            '*****************************************************
            '��ѱ������
            '*****************************************************
            '�������Ԃ�������
            Dim objDiff As TimeSpan = mdtmBeforeOnline.AddMilliseconds(mintDBReadTimer) - Now
            If 0 < objDiff.TotalMilliseconds Then
                Exit Sub
            End If
            mdtmBeforeOnline = Now


            '*****************************************************
            '�y�ݔ���ԁz   ��ײ݊m�F
            '*****************************************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(mobjOwner, mobjDb, mobjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID = mstrFEQ_ID                 '�ݔ�ID
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                  '�擾
            If TO_INTEGER(objTSTS_EQ_CTRL.FEQ_CUT_STS) = FLAG_OFF _
               And TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS) = FLAG_ON Then
                '(�uMCI�v = �u��ײ݁v�̏ꍇ)


                '*****************************************************
                '��ײ��׸ސݒ�
                '*****************************************************
                mblnOnline = True


                If blnOnlineBefore <> mblnOnline Then
                    '(�O��l�ƈ���Ă����ꍇ)


                    ''*****************************************************
                    ''�Đڑ�
                    ''*****************************************************
                    'Call ConnectRetry()


                    '*****************************************************
                    '�Ǎ�,����ڼ޽��z��X�V
                    '*****************************************************
                    Call UpdateReadArray()      '�Ǎ�ڼ޽��z��X�V
                    Call UpdateWriteArray()     '����ڼ޽��z��X�V
                    If mblnConnect = False Then
                        mblnOnline = False
                        Exit Sub
                    End If
                    mdtmEQ_SendTimer_Before = Now.AddMilliseconds(-mintEQ_SendTimer - 10000)  '��ϰ���肪����̂ŁA���̑Ή�


                    '*****************************************************
                    'ڼ޽��z�񏉊���
                    '*****************************************************
                    If mintDebugFlag = FLAG_OFF Then
                        For ii As Integer = REG_START To REG_MAX

                            '0��1�𔽓]������
                            Dim strTemp As String = Change10To2(mintNRegD(ii), 16)
                            strTemp = Replace(strTemp, "0", "X")
                            strTemp = Replace(strTemp, "1", "0")
                            strTemp = Replace(strTemp, "X", "1")
                            mintNRegD(ii) = Change2To10(strTemp)

                        Next
                    End If


                    '*****************************************************
                    'ڼ޽��z�񏉊���
                    '*****************************************************
                    For ii As Integer = LBound(mintBRegD) To UBound(mintBRegD)
                        mintBRegD(ii) = mintNRegD(ii)
                    Next


                End If


            Else
                '(�uMCI�v = �u��ײ݁v�̏ꍇ)


                '*****************************************************
                '��ײ��׸ސݒ�
                '*****************************************************
                mblnOnline = False


            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region


#Region "  ����Ēʒm                            ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ����Ēʒm
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">��������ݔ���ð��ٸ׽</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub InsertLIF_TRNS_RECV_FCOMMAND_ID_SEVENT(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Try
            If objTSTS_EQ_CTRL.XEVENT_FLAG = XEVENT_FLAG_JOFF Then Exit Sub
            Dim strAddress As String = objTSTS_EQ_CTRL.FEQ_ID_LOCAL
            Dim intRet As RetCode = RetCode.NG


            '****************************************************
            '�O��l�Ɠ����ꍇ��Exit
            '****************************************************
            If ReadRegister(strAddress, mintBRegD) = ReadRegister(strAddress, mintNRegD) Then Exit Sub


            '****************************************************
            '���������MIF�ǉ�
            '****************************************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(mobjOwner, mobjDb, mobjDbLog)
            objTLIF_TRNS_RECV.FEQ_ID = mstrFEQ_ID                           '�ݔ�ID
            objTLIF_TRNS_RECV.FCOMMAND_ID = FCOMMAND_ID_SEVENT              '�����ID
            objTLIF_TRNS_RECV.FDENBUN_PRM1 = objTSTS_EQ_CTRL.FEQ_ID         '����Ă̂������ݔ�ID
            objTLIF_TRNS_RECV.FDENBUN_PRM2 = ReadRegister(strAddress, mintNRegD)    '�l
            objTLIF_TRNS_RECV.FDENBUN_PRM3 = DEFAULT_STRING                         '�d�����Ұ�3
            objTLIF_TRNS_RECV.FDENBUN_PRM4 = DEFAULT_STRING                         '�d�����Ұ�4
            objTLIF_TRNS_RECV.FDENBUN_PRM5 = DEFAULT_STRING                         '�d�����Ұ�5
            objTLIF_TRNS_RECV.FDENBUN_PRM6 = DEFAULT_STRING                         '�d�����Ұ�6
            objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SEND                            '�i�����
            '' ''      objTLIF_TRNS_RECV.FRES_CD_EQ = FORMAT_PLC_RES_CD_OK             '�ݔ���������
            objTLIF_TRNS_RECV.FENTRY_DT = Now                                       '�o�^����
            objTLIF_TRNS_RECV.FUPDATE_DT = Now                                      '�X�V����
            objTLIF_TRNS_RECV.ADD_TLIF_TRNS_RECV_SEQ()                              '�ǉ�
            mblnSockSend = True                                                     '���đ��M�׸�


            '****************************************************
            '�ݔ��ʐM۸�        �ǉ�
            '****************************************************
            Call InsertTLOG_EQ02(objTSTS_EQ_CTRL)


            '****************************************************
            '۸ޏo��
            '****************************************************
            Call AddToLog(MCIC_MSG_1051 _
                          & "[�O��l" & strAddress & ":" & ReadRegister(strAddress, mintBRegD) & "]" _
                          & "[����l" & strAddress & ":" & ReadRegister(strAddress, mintNRegD) & "]" _
                          )


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region


#Region "  ڼ޽��z���ް��Ǎ���                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' ڼ޽��z���ް��Ǎ���
    ''' </summary>
    ''' <param name="strAddress">
    ''' ���ڽ�w��  [����:ASS_B999999_X]
    '''                  A     ��PLC�w�蕔       (Y:����PLC�@�@�@M:�O�HPLC)
    '''                  SS    ��PC�ԍ��w�蕔    (CW01:01�ACW02:02�ACW03:03�ACW04:04�ACW05:05�ACW04A:06�AMELSEC:FF)
    '''                  B     �����޲��敪      (����͖��g�p)
    '''                  999999�����ڽ�w�蕔     (40001�`105536)
    '''                  XX    ���ޯĎw�蕔      (10�i��)    ����߼�ݎw��
    ''' </param>
    ''' <param name="intRegD">
    ''' �ǂݍ��ޔz����w��
    ''' </param>
    ''' <returns>�Ǎ��ݒl</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function ReadRegister(ByVal strAddress As String _
                               , Optional ByVal intRegD() As Integer = Nothing _
                               ) As Integer
        Try
            Dim strMsg As String = ""


            '************************
            '�����ݒ�
            '************************
            If IsNull(intRegD) = True Then intRegD = mintNRegD


            '************************
            '�e�ݒ�l�̓���
            '************************
            Dim strPartRegType As String                            'ڼ޽��敪�w�蕔
            Dim intPartAddress As Nullable(Of Integer) = Nothing    '���ڽ�w�蕔
            Dim intPartBit As Nullable(Of Integer) = Nothing        '�ޯĎw�蕔
            strPartRegType = Mid(strAddress, 5, 1)
            intPartAddress = CInt(Mid(strAddress, 6, 6))
            If Len(strAddress) >= 12 Then
                '(�ޯĎw�肪����ꍇ)
                Try
                    intPartBit = CInt(Mid(strAddress, 13, 2))
                    'intPartBit = Convert.ToInt32(Mid(strAddress, 8, 1), 16)
                Catch ex As Exception
                    strMsg = "�������s���ł��B[�ޯĎw��l�ُ�  �ݔ�ID:" & strAddress & "]"
                    Throw New Exception(strMsg)
                End Try
            End If


            '************************
            '���O����
            '************************
            'If strPartRegType <> DEVICE_READ Then
            '    '(ڼ޽��敪�w�蕔���s���̏ꍇ)
            '    strMsg = "�������s���ł��B[ڼ޽��敪�w��ُ�  �ݔ�ID:" & strAddress & "]"
            '    Throw New Exception(strMsg)
            If IsNothing(intPartAddress) = True Then
                '(���ڽ�w�蕔���w�薳���̏ꍇ)
                strMsg = "�������s���ł��B[���ڽ�w�薳���ُ�  �ݔ�ID:" & strAddress & "]"
                Throw New Exception(strMsg)
            End If


            '************************
            '�z���ް������
            '************************
            Dim intGetData As Integer
            intGetData = intRegD(intPartAddress)


            '************************
            '�ޯ��ް������
            '************************
            If IsNothing(intPartBit) = False Then
                '(�ޯĎw�肪�L��ꍇ)
                Dim strTemp As String
                strTemp = Convert.ToString(intGetData, 2)
                If Len(strTemp) < 16 Then
                    Dim ii As Integer
                    For ii = 1 To 16 - Len(strTemp)
                        strTemp = "0" & strTemp
                    Next
                End If
                intGetData = Mid(strTemp, 16 - CInt(intPartBit), 1)
            End If


            Return intGetData

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function
#End Region
#Region "  ڼ޽��z���ް�������                      "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ڼ޽��z���ް�������
    ''' </summary>
    ''' <param name="strAddress">
    ''' ���ڽ�w��  [����:ASS_B999999_X]
    '''                  A     ��PLC�w�蕔       (Y:����PLC�@�@�@M:�O�HPLC)
    '''                  SS    ��PC�ԍ��w�蕔    (CW01:01�ACW02:02�ACW03:03�ACW04:04�ACW05:05�ACW04A:06�AMELSEC:FF)
    '''                  B     �����޲��敪      (����͖��g�p)
    '''                  999999�����ڽ�w�蕔     (40001�`105536)
    '''                  XX    ���ޯĎw�蕔      (10�i��)    ����߼�ݎw��
    ''' </param>
    ''' <param name="intWriteValue">�����ݒl</param>
    ''' <param name="strLogMsg">۸ޏo�͗pү����</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub WriteRegister(ByVal strAddress As String _
                           , ByVal intWriteValue As Integer _
                           , Optional ByVal strLogMsg As String = MCIC_MSG_1002 _
                           )
        Try
            Dim strMsg As String = ""


            '************************
            '�e�ݒ�l�̓���
            '************************
            Dim strPartRegType As String                            'ڼ޽��敪�w�蕔
            Dim intPartAddress As Nullable(Of Integer) = Nothing    '���ڽ�w�蕔
            Dim intPartBit As Nullable(Of Integer) = Nothing        '�ޯĎw�蕔
            strPartRegType = Mid(strAddress, 5, 1)
            intPartAddress = CInt(Mid(strAddress, 6, 6))
            If Len(strAddress) >= 12 Then
                '(�ޯĎw�肪����ꍇ)
                Try
                    intPartBit = CInt(Mid(strAddress, 13, 2))
                    'intPartBit = Convert.ToInt32(Mid(strAddress, 8, 1), 16)
                Catch ex As Exception
                    strMsg = "�������s���ł��B[�ޯĎw��l�ُ�  �ݔ�ID:" & strAddress & "]"
                    Throw New Exception(strMsg)
                End Try
            End If


            '************************
            '���O����
            '************************
            'If strPartRegType <> DEVICE_WRITE Then
            '    '(ڼ޽��敪�w�蕔���s���̏ꍇ)
            '    strMsg = "�������s���ł��B[ڼ޽��敪�w��ُ�  �ݔ�ID:" & strAddress & "]"
            '    Throw New Exception(strMsg)
            If IsNothing(intPartAddress) = True Then
                '(���ڽ�w�蕔���w�薳���̏ꍇ)
                strMsg = "�������s���ł��B[���ڽ�w�薳���ُ�  �ݔ�ID:" & strAddress & "]"
                Throw New Exception(strMsg)
            ElseIf CInt(intPartAddress) < 1 And 100 < CInt(intPartAddress) Then
                '(���ڽ�w�蕔���w�薳���̏ꍇ)
                strMsg = "�������s���ł��B[���ڽ�w�薳���ُ�  �ݔ�ID:" & strAddress & "]"
                Throw New Exception(strMsg)
            ElseIf IsNothing(intPartBit) = False Then
                '(�ޯĎw��L��̏ꍇ)
                If (CInt(intWriteValue) <> 0) And (CInt(intWriteValue) <> 1) Then
                    '(�ݒ�l���s���ȏꍇ)
                    strMsg = "�������s���ł��B[�ݒ�l�ُ�  �ݔ�ID:" & strAddress & "]"
                    Throw New Exception(strMsg)
                End If
            End If


            '************************
            '�l������
            '(�z��)
            '************************
            Dim intTemp01 As Integer = ReadRegister(strAddress)   '�ύX�O
            Dim intTemp02(0) As Integer                           '�ύX��
            If IsNothing(intPartBit) = True Then
                '(�����ݒ�̏ꍇ)
                intTemp02(0) = intWriteValue
            Else
                '(�ޯĐݒ�̏ꍇ)
                If intWriteValue = 1 Then
                    '(ON�ݒ�̏ꍇ)
                    intTemp02(0) = mintNRegD(CInt(intPartAddress)) Or 2 ^ CInt(intPartBit)
                Else
                    '(OFF�ݒ�̏ꍇ)
                    intTemp02(0) = mintNRegD(CInt(intPartAddress)) And Not (2 ^ CInt(intPartBit))
                End If
            End If
            mintNRegD(CInt(intPartAddress)) = intTemp02(0)
            'If IsNotNull(strLogMsg) Then
            '    If ReadRegister(strAddress) <> intTemp01 Then
            '        Call AddToLog(strLogMsg & "[���ڽ:" & strAddress & "][�l:" & CStr(intWriteValue) & "]")
            '    End If
            'End If


            '******************************************************************************
            'Melsec�Đڑ�
            '******************************************************************************
            If IsNull(mobjMelsec) = True Then
                Me.Open()
            End If


            '***************************************
            'ڼ޽�����
            '***************************************
            Dim intRetPLC As ComMelsec.clsMelsec.RetCode
            intRetPLC = mobjMelsec.AreaWriteAJ71E71(mintSRC_STATION, ComMelsec.clsMelsec.RegType.D, intPartAddress, intTemp02.Length, intTemp02)
            Call Me.Close()
            If intRetPLC <> ComMelsec.clsMelsec.RetCode.OK Then
                '(���s�����ꍇ)
                Throw New Exception(MCIC_MSG_1007 _
                                    & "[PC�ԍ�:" & TO_STRING(mintSRC_STATION) & "]" _
                                    & "[�J�nڼ޽�:" & TO_STRING(intPartAddress) & "]" _
                                    & "[�l:" & TO_STRING(intTemp02(0)) & "]" _
                                    )
            End If


            ''************************
            ''�l������
            ''(�z��)
            ''************************
            'Dim intTemp As Integer = ReadRegister(strAddress)   '�ꎞ�ۊ�
            'If IsNothing(intPartBit) = True Then
            '    '(�����ݒ�̏ꍇ)
            '    mintNRegD(CInt(intPartAddress)) = intWriteValue
            'Else
            '    '(�ޯĐݒ�̏ꍇ)
            '    If intWriteValue = 1 Then
            '        '(ON�ݒ�̏ꍇ)
            '        mintNRegD(CInt(intPartAddress)) = mintNRegD(CInt(intPartAddress)) Or 2 ^ CInt(intPartBit)
            '    Else
            '        '(OFF�ݒ�̏ꍇ)
            '        mintNRegD(CInt(intPartAddress)) = mintNRegD(CInt(intPartAddress)) And Not (2 ^ CInt(intPartBit))
            '    End If
            'End If
            'If IsNotNull(strLogMsg) Then
            '    If ReadRegister(strAddress) <> intTemp Then
            '        Call AddToLog(strLogMsg & "[���ڽ:" & strAddress & "][�l:" & CStr(intWriteValue) & "]")
            '    End If
            'End If


        Catch ex As Exception
            Call Me.Close()
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ڼ޽��z���߰                            "
    Private Sub CopyRegR()

        Call Array.Copy(mintNRegD, REG_START, mintBRegD, REG_START, REG_COUNT_MAX + 1)

    End Sub
#End Region
#Region "  �Ǎ�ڼ޽��z��X�V            (�ΏۂƂȂ�Sڼ޽�)     "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �Ǎ�ڼ޽��z��X�V            (�ΏۂƂȂ�Sڼ޽�)
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub UpdateReadArray()
        Try
            Dim intStartAdrs As Integer             '�Ǎ���ڼ޽��̊J�n�ʒu
            Dim intReadCount As Integer             '�Ǎ���ڼ޽���
            'Dim intRet As ComPLCYaskawa.clsPLC.RetCode      '�߂�l
            Dim objDiff As TimeSpan                 '���ԍ���


            '****************************************************
            '��ѱ������
            '****************************************************
            If mblnConnect = False Then
                '(�ڑ��װ�̏ꍇ)
                objDiff = mdtmConnectBefore.AddMilliseconds(mintConnectTimer) - Now
                If objDiff.TotalMilliseconds < 0 Then
                    '(�Đڑ���ѱ�Ă̏ꍇ)


                    ''*****************************************************
                    ''�Đڑ�����(�����̌��ʁA�s�v�Ɣ����������A�ꉞ��������)
                    ''*****************************************************
                    'Call ConnectRetry()
                    mdtmConnectBefore = Now
                    'If mblnConnect = False Then Exit Sub


                Else
                    '(�Đڑ���ѱ�Ă��Ă��Ȃ��ꍇ)
                    Exit Sub
                End If

            End If


            '*****************************************************
            '��ϰ����
            '*****************************************************
            objDiff = mdtmEQ_SendTimer_Before.AddMilliseconds(mintEQ_SendTimer) - Now
            If 0 < objDiff.TotalMilliseconds Then
                Exit Sub
            End If
            mdtmEQ_SendTimer_Before = Now


            '******************************************************************************
            'Melsec�Đڑ�
            '******************************************************************************
            If IsNull(mobjMelsec) = True Then
                Me.Open()
            End If


            '******************************************************************************
            'ڼ޽��Ǎ�
            '******************************************************************************
            '================================================
            '000901�`000914
            '================================================
            intStartAdrs = 901
            intReadCount = 14
            Call UpdateReadPartArray(intStartAdrs, intReadCount)

            '================================================
            '005061�`005200
            '================================================
            intStartAdrs = 5061
            intReadCount = 140
            Call UpdateReadPartArray(intStartAdrs, intReadCount)

            '================================================
            '005201�`005312
            '================================================
            intStartAdrs = 5201
            intReadCount = 112
            Call UpdateReadPartArray(intStartAdrs, intReadCount)

            '================================================
            '005500�`005527
            '================================================
            intStartAdrs = 5500
            intReadCount = 28
            Call UpdateReadPartArray(intStartAdrs, intReadCount)


            mblnConnect = True
        Catch ex As Exception
            mblnConnect = False
            Call ComError(ex)
            Call Me.Close()
        End Try
    End Sub
#End Region
#Region "  �Ǎ�ڼ޽��z��X�V            (�w�肵��ڼ޽�)         "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �Ǎ�ڼ޽��z��X�V            (�w�肵��ڼ޽�)
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub UpdateReadPartArray(ByVal intAdrs As Integer _
                                  , ByVal intSize As Integer _
                                  )
        Dim intTemp() As Integer = Nothing               'ڼ޽��l�ꎞ�ۊ�
        Dim intRet As ComMelsec.clsMelsec.RetCode        '�߂�l


        '***************************************
        'ڼ޽��Ǎ�
        '***************************************
        intRet = mobjMelsec.AreaReadAJ71E71(mintSRC_STATION, ComMelsec.clsMelsec.RegType.D, intAdrs, intSize, intTemp)        '�z��擾
        If intRet = ComMelsec.clsMelsec.RetCode.OK Then
            '(�����̏ꍇ)

            Call Array.Copy(intTemp, 0, mintNRegD, intAdrs, intTemp.Length)

            'For ii As Integer = LBound(objTemp) To UBound(objTemp)
            '    '(ٰ��:�Ǎ�ڼ޽��̐�)
            '    mintNRegD(intAdrs + ii) = objTemp(ii)
            'Next
        Else
            '(���s�̏ꍇ)
            Throw New Exception(MCIC_MSG_1001 _
                                & "[PC�ԍ�:" & TO_STRING(mintSRC_STATION) & "]" _
                                & "[�J�nڼ޽�:" & TO_STRING(intAdrs) & "]" _
                                & "[�擾��:" & TO_STRING(intSize) & "]" _
                                )
        End If


    End Sub
#End Region
#Region "  ����ڼ޽��z��X�V                        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ����ڼ޽��z��X�V
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub UpdateWriteArray()
        'Try
        '    Dim objTemp As Object = Nothing         'ڼ޽��l�ꎞ�ۊ�
        '    Dim blnRet As Boolean                   '�߂�l


        '    '***************************************
        '    'ڼ޽��Ǎ�
        '    '***************************************
        '    blnRet = mobjFAEngine.ReadVal(mstrTagPath02, objTemp)        '�z��擾
        '    If blnRet = True Then
        '        '(�����̏ꍇ)
        '        For ii As Integer = LBound(objTemp) To UBound(objTemp)
        '            '(ٰ��:�Ǎ�ڼ޽��̐�)
        '            mintNRegD(ii + REGR_ADRS_WRITE_HEAD) = objTemp(ii)
        '        Next
        '    Else
        '        '(���s�̏ꍇ)
        '        Throw New Exception(MCIC_MSG_1001 _
        '                            & "[FA-Engine�װ����:" & mobjFAEngine.ErrCode & "]" _
        '                            & "[FA-Engine�װү����:" & mobjFAEngine.ErrMessage & "]" _
        '                            )
        '    End If


        '    mblnConnect = True
        'Catch ex As Exception
        '    mblnConnect = False
        '    Call ComError(ex)
        'End Try
    End Sub
#End Region
#Region "  ����ڼ޽��z�񏑍���                      "
    ''''*******************************************************************************************************************
    '''' <summary>
    '''' ����ڼ޽��z�񏑍���
    '''' </summary>
    '''' <remarks></remarks>
    ''''*******************************************************************************************************************
    'Private Sub WriteArrayWrite()
    '    Try
    '        Dim objRegDWrite(REGR_ADRS_WRITE_LEN) As Object     '����ڼ޽��z��
    '        Dim blnRet As Boolean                               '�߂�l


    '        '************************
    '        '����ڼ޽��l�z��쐬(�z���߰)
    '        '************************
    '        Array.Copy(mintNRegD _
    '                 , REGR_ADRS_WRITE_HEAD _
    '                 , objRegDWrite _
    '                 , LBound(objRegDWrite) _
    '                 , REGR_ADRS_WRITE_LEN _
    '                 )


    '        Dim objDiff As TimeSpan = mdtmBeforeWrite.AddMilliseconds(mintConnectTimer) - Now
    '        If ArrayCompare(objRegDWrite, mintRegRBuff) = False _
    '           Or objDiff.TotalMilliseconds < 0 _
    '           Then
    '            '(�O�񏑍��z��ƈႤ�ꍇ�A�������͈�莞�Ԍo�߂����ꍇ)


    '            '***************************************
    '            'ڼ޽�����
    '            '***************************************
    '            blnRet = mobjFAEngine.WriteVal(mstrTagPath02, objRegDWrite)        '�z��擾
    '            mdtmBeforeWrite = Now
    '            If blnRet = True Then
    '                '(�����̏ꍇ)

    '                '�ޯ̧�ɺ�߰
    '                Array.Copy(mintNRegD _
    '                         , REGR_ADRS_WRITE_HEAD _
    '                         , mintRegRBuff _
    '                         , LBound(mintRegRBuff) _
    '                         , REGR_ADRS_WRITE_LEN _
    '                         )

    '            Else
    '                '(���s�̏ꍇ)
    '                Throw New Exception(MCIC_MSG_1007 _
    '                                    & "[FA-Engine�װ����:" & mobjFAEngine.ErrCode & "]" _
    '                                    & "[FA-Engine�װү����:" & mobjFAEngine.ErrMessage & "]" _
    '                                    )
    '            End If


    '        End If


    '    Catch ex As Exception
    '        mblnConnect = False
    '        Call ComError(ex)
    '    End Try
    'End Sub
#End Region


#Region "  �y�ݔ��ʐM۸ށz��M۸ޒǉ�     ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �y�ݔ��ʐM۸ށz��M۸ޒǉ�
    ''' </summary>
    ''' <param name="strFTEXT_ID">÷��ID</param>
    ''' <param name="strFDENBUN">�ʐM�d��</param>
    ''' <param name="strFRES_CD_EQ">�ݔ���������</param>
    ''' <param name="strXEQ_ID_WRITE">�ݔ�ID</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddDBRecvLog_LOG(ByVal strFTEXT_ID As String _
                              , ByVal strFDENBUN As String _
                              , ByVal strFRES_CD_EQ As String _
                              , Optional ByVal strXEQ_ID_WRITE As String = Nothing _
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
        objTLOG_EQ.XEQ_ID_WRITE = strXEQ_ID_WRITE           '�ݔ�ID
        objTLOG_EQ.ADD_TLOG_EQ_SEQ()                        '�ǉ�


    End Sub
#End Region
#Region "  �y�ݔ��ʐM۸ށz���M۸ޒǉ�     ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �y�ݔ��ʐM۸ށz���M۸ޒǉ�
    ''' </summary>
    ''' <param name="strFTEXT_ID">÷��ID</param>
    ''' <param name="strFDENBUN">�ʐM�d��</param>
    ''' <param name="strFRES_CD_EQ">�ݔ���������</param>
    ''' <param name="strXEQ_ID_WRITE">�ݔ�ID</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub AddDBSendLog_LOG(ByVal strFTEXT_ID As String _
                              , ByVal strFDENBUN As String _
                              , ByVal strFRES_CD_EQ As String _
                              , Optional ByVal strXEQ_ID_WRITE As String = Nothing _
                                )

        '========================================
        'DB۸ޏo��
        '========================================
        Dim objTLOG_EQ As New TBL_TLOG_EQ(mobjOwner, mobjDb, mobjDbLog)
        objTLOG_EQ.FLOG_NO = "1"                            '۸�No
        objTLOG_EQ.FEQ_ID = mstrFEQ_ID                      '�ݔ�ID
        objTLOG_EQ.FHASSEI_DT = mdtmNow                     '��������
        objTLOG_EQ.FDIRECTION = FDIRECTION_SSEND            '����
        objTLOG_EQ.FTEXT_ID = strFTEXT_ID                   '÷��ID
        objTLOG_EQ.FDENBUN = strFDENBUN                     '�ʐM÷��
        objTLOG_EQ.FRES_CD_EQ = strFRES_CD_EQ               '��������
        objTLOG_EQ.XEQ_ID_WRITE = strXEQ_ID_WRITE           '�ݔ�ID
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
#Region "  ID:0101      ڼ��������v��(ܰ�ޑΉ�)             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ڼ��������v��(ܰ�ޑΉ�)
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">���M�����ް�ð��ٵ�޼ު��</param>
    ''' <returns>����I���̗L��</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function ID0101Process(ByRef objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND) As RetCode
        Try
            '' ''Dim intRet As RetCode


            '*****************************************************
            '�ݔ���       �擾
            '*****************************************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(mobjOwner, mobjDb, mobjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID = objTLIF_TRNS_SEND.FDENBUN_PRM1     '�ݔ�ID
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                          '�擾


            '*****************************************************
            '�ޯď���(����)
            '*****************************************************
            Dim intPartAddress As Integer = CInt(Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 6, 6))       '���ڽ�w�蕔
            Dim strData() As String = Split(objTLIF_TRNS_SEND.FDENBUN_PRM2, ",")                '�����ް�
            Dim intData(UBound(strData)) As Integer                                             '�����ް�
            '�����ް��𐔒l�^�֕ϊ�
            For ii As Integer = 0 To UBound(strData)
                '(ٰ��:�������ް���)
                intData(ii) = TO_INTEGER(strData(ii))
            Next
            'Call Array.Copy(strData, 0, intData, 0, strData.Length)                             '�����ް��𐔒l�^�ɺ�߰


            '******************************************************************************
            'Melsec�Đڑ�
            '******************************************************************************
            If IsNull(mobjMelsec) = True Then
                Me.Open()
            End If


            '***************************************
            'ڼ޽�����
            '***************************************
            Dim intRetPLC As ComMelsec.clsMelsec.RetCode
            Call AddToLog(MCIC_MSG_1031 & "[�ݔ�ID:" & objTLIF_TRNS_SEND.FDENBUN_PRM1 & "][�l:" & CStr(objTLIF_TRNS_SEND.FDENBUN_PRM2) & "]")
            intRetPLC = mobjMelsec.AreaWriteAJ71E71(mintSRC_STATION, ComMelsec.clsMelsec.RegType.D, intPartAddress, intData.Length, intData)
            Call Me.Close()
            If intRetPLC <> ComMelsec.clsMelsec.RetCode.OK Then
                '(���s�����ꍇ)
                Throw New Exception(MCIC_MSG_1007 _
                                    & "[PC�ԍ�:" & TO_STRING(mintSRC_STATION) & "]" _
                                    & "[�J�nڼ޽�:" & TO_STRING(intPartAddress) & "]" _
                                    & "[�l:" & TO_STRING(objTLIF_TRNS_SEND.FDENBUN_PRM2) & "]" _
                                    )
            End If


            '*****************************************************
            '�������MIF�X�V
            '*****************************************************
            objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SEND                     '�i�����
            objTLIF_TRNS_SEND.FUPDATE_DT = Now                              '�X�V����
            objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()                       '�X�V


            '*****************************************************
            '�ݔ��ʐM۸�            �o��
            '*****************************************************
            Dim strAryFEQ_ID() As String = Split(objTLIF_TRNS_SEND.FDENBUN_PRM1, ",")
            Dim strAryData() As String = Split(objTLIF_TRNS_SEND.FDENBUN_PRM2, ",")
            Call InsertTLOG_EQ01(objTLIF_TRNS_SEND _
                               , strAryFEQ_ID _
                               , strAryData _
                               )


            Return RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
#Region "  ID:0102      ڼ��������v��(�ޯđΉ�)             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ڼ��������v��(�ޯđΉ�)
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">���M�����ް�ð��ٵ�޼ު��</param>
    ''' <returns>����I���̗L��</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function ID0102Process(ByRef objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND) As RetCode
        Try
            '' ''Dim intRet As RetCode


            '*****************************************************
            '�ݔ���       �擾
            '*****************************************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(mobjOwner, mobjDb, mobjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID = objTLIF_TRNS_SEND.FDENBUN_PRM1     '�ݔ�ID
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                          '�擾


            '*****************************************************
            '�ޯď���(���ۂ�ܰ�ނł����v)
            '*****************************************************
            Call WriteRegister(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, objTLIF_TRNS_SEND.FDENBUN_PRM2)
            Call AddToLog(MCIC_MSG_1031 & "[�ݔ�ID:" & objTLIF_TRNS_SEND.FDENBUN_PRM1 & "][�l:" & TO_STRING(objTLIF_TRNS_SEND.FDENBUN_PRM2) & "]")


            '*****************************************************
            '�������MIF�X�V
            '*****************************************************
            objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SEND                     '�i�����
            objTLIF_TRNS_SEND.FUPDATE_DT = Now                              '�X�V����
            objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()                       '�X�V


            '*****************************************************
            '�ݔ��ʐM۸�            �o��
            '*****************************************************
            Dim strAryFEQ_ID() As String = {TO_STRING(objTLIF_TRNS_SEND.FDENBUN_PRM1)}
            Dim strAryData() As String = {TO_STRING(objTLIF_TRNS_SEND.FDENBUN_PRM2)}
            Call InsertTLOG_EQ01(objTLIF_TRNS_SEND _
                               , strAryFEQ_ID _
                               , strAryData _
                               )


            Return RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
#Region "  ID:0201      ڼ����Ǎ��v��(�Sڼ޽�)              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ڼ����Ǎ��v��(�Sڼ޽�)
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">���M�����ް�ð��ٵ�޼ު��</param>
    ''' <returns>����I���̗L��</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function ID0201Process(ByRef objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND) As RetCode
        Try
            '' ''Dim intRet As RetCode


            '*****************************************************
            'ڼ޽��Ǎ�
            '*****************************************************
            mdtmEQ_SendTimer_Before = Now.AddMilliseconds(-mintEQ_SendTimer - 10000)  '��ϰ���肪����̂ŁA���̑Ή�
            Call UpdateReadArray()      '�Ǎ�ڼ޽��z��X�V


            Return RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG

        End Try
    End Function
#End Region
    '���������������M����
    '***********************************************

#Region "  �y�ݔ��ʐM۸ށz۸ޒǉ�(��������)             ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �y�ݔ��ʐM۸ށz۸ޒǉ�(��������)             ����
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">�������䑗�MIF</param>
    ''' <param name="strAryFEQ_ID">�ݔ�ID</param>
    ''' <param name="strAryData">�������ް�</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub InsertTLOG_EQ01(ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND _
                             , ByVal strAryFEQ_ID() As String _
                             , ByVal strAryData() As String _
                             )
        Dim strFDENBUN As String = ""           '�ʐM�d��


        '********************************************
        '�ݔ���           �擾
        '********************************************
        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(mobjOwner, mobjDb, mobjDbLog)
        objTSTS_EQ_CTRL.FEQ_ID = strAryFEQ_ID(0)            '�ݔ�ID
        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                  '�擾


        '********************************************
        '۸ޏo�͕�����      �쐬
        '********************************************
        Select Case objTLIF_TRNS_SEND.FTEXT_ID
            Case FTEXT_ID_JW_SYABAN
                '(�Ԕԕ\���̏ꍇ)

                strFDENBUN &= "[�Ԕԕ\��           :" & SPC_PAD_RIGHT_SJIS(TO_STRING(strAryData(0)), 5) & "]"

            Case FTEXT_ID_JW_HENSEI
                '(�Ґ����\���̏ꍇ)

                strFDENBUN &= "[�Ґ����\��         :" & SPC_PAD_RIGHT_SJIS(TO_STRING(strAryData(0)), 5) & "]"

            Case FTEXT_ID_JW_OUTEND
                '(�o�Ɋ������߂̏ꍇ)

                strFDENBUN &= "[�o�Ɋ�������       :" & SPC_PAD_RIGHT_SJIS(TO_STRING(strAryData(0)), 5) & "]"

            Case FTEXT_ID_JW_YOTEI
                '(�����\�萔�̏ꍇ)

                strFDENBUN &= "[" & ZERO_PAD_BACK(objTSTS_EQ_CTRL.FEQ_NAME, 20) & ":" & SPC_PAD_RIGHT_SJIS(TO_STRING(strAryData(0)), 5) & "]"

            Case FTEXT_ID_JW_ETC
                '(���̑��̏ꍇ)

                strFDENBUN &= "[����][" & objTSTS_EQ_CTRL.FEQ_NAME & ":" & SPC_PAD_RIGHT_SJIS(TO_STRING(strAryData(0)), 5) & "]"

            Case Else
                '(���̑�)
                strFDENBUN &= "÷��ID�������Ă��܂���B"

        End Select


        '********************************************
        '۸ޏo��
        '********************************************
        Call AddToLog(MCIC_MSG_1031 & strFDENBUN)


        '********************************************
        '�ݔ��ʐM۸�        �ǉ�
        '********************************************
        Call AddDBSendLog_LOG(objTLIF_TRNS_SEND.FTEXT_ID _
                            , strFDENBUN _
                            , "" _
                            , objTSTS_EQ_CTRL.FEQ_ID _
                            )


    End Sub
#End Region
#Region "  �y�ݔ��ʐM۸ށz۸ޒǉ�(����Ēʒm����)        ����"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �y�ݔ��ʐM۸ށz۸ޒǉ�(����Ēʒm����)        ����
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub InsertTLOG_EQ02(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Dim strFDENBUN As String = ""           '�ʐM�d��
        Dim strFTEXT_ID As String = ""


        '********************************************
        '۸ޏo�͕�����      �쐬
        '********************************************
        Select Case TO_INTEGER(objTSTS_EQ_CTRL.XEVENT_LOG_KUBUN)
            Case XEVENT_LOG_KUBUN_EVENT
                '(����Ēʒm۸ނ̏ꍇ)
                strFTEXT_ID = FTEXT_ID_JR_EVENT         '÷��ID

                '====================================================
                '�l��ݒ�
                '====================================================
                strFDENBUN &= "[�ݔ�����:" & objTSTS_EQ_CTRL.FEQ_NAME & "]"
                strFDENBUN &= "[�ݔ����:" & ReadRegister(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, mintNRegD) & "]"

                '====================================================
                '۸ޏo��
                '====================================================
                Call AddToLog(MCIC_MSG_1051 & strFDENBUN)

            Case Else
                '(���̑�)
                Exit Sub

        End Select


        '********************************************
        '�ݔ��ʐM۸�        �ǉ�
        '********************************************
        Call AddDBRecvLog_LOG(strFTEXT_ID _
                            , strFDENBUN _
                            , "" _
                            , objTSTS_EQ_CTRL.FEQ_ID _
                            )


    End Sub
#End Region


End Class
