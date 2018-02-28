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
Imports spi.WinSAM
Imports spi.WinSAM.Data
#End Region

Public Class clsMCIMainDummy

#Region "  ���ʕϐ�02           "

    Private mobjWinSAM As spi.WinSAM.WsNETAPI           'WsNETAPI�N���X
    'Private mobjSockListener As clsSocketListener       '����ؽŰ�׽
    'Private mobjSockClient As clsSocketClient           '���ĸײ��ĸ׽
    Private mobjMCIMain As CtrlMCIC.clsMCIMain          '�{���̒ʐM��۸��Ѹ׽
    Private mobjGetTelegram As clsGetTelegram           '�d���p÷�Ď擾�׽

    'AGC�ւ̿��ėp
    Private mstrAGCSockSendAddress As String        'AGC���M����ڽ
    Private mintAGCSockSendPort As Integer          'AGC���M���߰�No
    Private mintAGCSockSendTimeOut As Integer       'AGC�������đҋ@����
    Private mintAGCSockETXSendTimeOut As Integer    'AGC�����ETX���đ��M���� (ms)
    Private mintAGCSockETXRecvTimeOut As Integer    'AGC�����ETX���Ď�M���� (ms)
    'EQ����̿��ėp
    Private mintEQSockRecvPort As Integer          'EQ��M�߰�No
    'EQ�d����M�p
    Private mintEQTelegramInforStartPosition As Integer     '�u�������v�������Ă���ʒu
    Private mintEQTelegramInforLength As Integer            '�u�������v�̌���
    Private mintEQTelegramHeaderLength As Integer           'ͯ�ް�����̌���

    Private mintSendCount As Integer          '�đ��M��
    Private mdtmBeforeRecvTime As Date        '�O���M����
    Private mdtmBeforeSendTime As Date        '�O�񑗐M����
    Private mdtmBeforeETXSendTime As Date     '�O��ETX���M����
    Private mdtmBeforeETXRecvTime As Date     '�O��ETX��M����
    Private mbytRecvTelBuff() As Byte         '���Ď�M�ޯ̧
    Private mblnIsConnect As Boolean          '���Đڑ��׸�
    Private mintSockRecvMode As Integer         '���Ď�MӰ��

    '�����è
    Private mintSendSEQNo As Integer        '���MSEQ��
    Private mintRecvSEQNo As Integer        '��MSEQ��


    '==================================================
    '�Œ�l
    '==================================================
    Public Const MAX_LEN As Integer = 3000      'UST�̐ݒ��3000�ƂȂ��Ă���


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
    Private mintResetSleep As Integer               '�ʐMؾ�Ď��̽ذ�ߎ���(ms)  �A������ؾ�Ă��s��Ȃ���
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
            'mobjSockListener.intDebugFlag = Value
            'mobjSockClient.intDebugFlag = Value
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
                '���Ď�MӰ�ނ̐ؑ�
                '*****************************************************
                If mintSockRecvMode = SOCK_RECV_MODE_CLIENT Then
                    '(�ײ��Ď�MӰ�ނ̏ꍇ)
                    mintSockRecvMode = SOCK_RECV_MODE_LISTENER
                Else
                    '(ؽŰ��MӰ�ނ̏ꍇ)
                    mintSockRecvMode = SOCK_RECV_MODE_CLIENT
                End If


                '*****************************************************
                '�d����M
                '*****************************************************
                Dim strRecvText As String = ""          '��M�d��
                If mintSockRecvMode = SOCK_RECV_MODE_CLIENT Then
                    Call RecvDataVClient(strRecvText)
                Else
                    Call RecvDataVListener(strRecvText)
                End If


                '*****************************************************
                'ALC�d����M����
                '*****************************************************
                Call MCIA_900002(strRecvText)


            Catch ex As Exception
                Call ComError(ex)
                mblnIsConnect = False

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
            mbytRecvTelBuff = Nothing                           '���Ď�M�ޯ̧
            mdtmNow = Now
            mobjMCIMain = New CtrlMCIC.clsMCIMain(objOwner, objDb, objDbLog)    '�{���̒ʐM��۸��Ѹ׽

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
        '' ''mdtmBeforeETXSendTime = Now                     '�O��ETX���M����(�����l)
        mdtmBeforeETXRecvTime = Now.AddSeconds(5)       '�O��ETX��M����(5�b���Z)
        mobjASCII = New clsASCII()              'ASCII���ޕ����׽
        mblnIsConnect = True                    '���Đڑ��׸�
        mobjGetTelegram = New clsGetTelegram(mobjOwner) '�d���p÷�Ď擾�׽


        '*****************************************************
        'Confiģ�ُ��擾(�W������)
        '*****************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_MCIC_DUMMY)                                     'Confiģ�ِڑ��׽����

        '���ް���ėp
        mstrSvrSockSendAddress = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_ADDRESS))              '���ޑ��M����ڽ
        mintSvrSockSendPort = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_PORT))                    '���ޑ��M���߰�No
        mintSvrSockSendTimeOut = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_TIME_OUT))             '���މ������đҋ@����
        mstrSvrSockSendTermID = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_TERM_ID))               '���ޒ[��ID
        mstrSvrSockSendUserID = TO_STRING(objConfig.GET_INFO(GKEY_SOCK_SEND_USER_ID))               '����հ�ްID
        '���̑�
        mintDBReadTimer = TO_INTEGER(objConfig.GET_INFO(GKEY_MCI_DB_READ_TIMER))                    '���M�ޯ̧ð��ق������������
        mstrFEQ_ID = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FEQ_ID))                                 'MCI���
        mstrFMSG_ID_ERR_SYS = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FMSG_ID_ERR_SYS))               '���Ѵװ  ����ү����ID
        mstrFMSG_ID_ERR_USER = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FMSG_ID_ERR_USER))             'հ�ް�װ ����ү����ID
        mintResetSleep = TO_STRING(objConfig.GET_INFO(GKEY_MCI_SEND_SLEEP))                         '�ʐMؾ�Ď��̽ذ�ߎ���(ms)  �A������ؾ�Ă��s��Ȃ���


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
        'AGC�ւ̿��ėp
        mstrAGCSockSendAddress = TO_STRING(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_ADDRESS))                  'AGC���M����ڽ
        mintAGCSockSendPort = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_PORT))                       'AGC���M���߰�No
        mintAGCSockSendTimeOut = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_SOCK_SEND_TIME_OUT))                'AGC�������đҋ@����
        'EQ����̿��ėp
        mintEQSockRecvPort = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_SOCK_RECV_PORT))                       'EQ��M�߰�No
        'EQ�d����M�p
        mintEQTelegramInforStartPosition = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_TELEGRAM_INFOR_START_POSITION))        '�u�������v�������Ă���ʒu
        mintEQTelegramInforLength = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_TELEGRAM_INFOR_LENGTH))                       '�u�������v�̌���
        mintEQTelegramHeaderLength = TO_INTEGER(objConfig.GET_INFO(GKEY_EQ_TELEGRAM_HEADER_LENGTH))                     'ͯ�ް�����̌���


        '****************************************************
        'ؽŰ���ĒʐM�׽������
        '****************************************************
        'mobjSockListener = New clsSocketListener(mobjOwner)
        'mobjSockListener.intPortNo = mintAGCSockSendPort
        'mobjSockListener.intDebugFlag = mintDebugFlag


        '****************************************************
        '�ײ��Ŀ��ĒʐM�׽������
        '****************************************************
        'mobjSockClient = New clsSocketClient(mobjOwner)
        'mobjSockClient.strAddress = mstrAGCSockSendAddress
        'mobjSockClient.intPortNo = mintEQSockRecvPort
        'mobjSockClient.intDebugFlag = mintDebugFlag


        '****************************************************
        'WinSAM         ��`
        '****************************************************
        mobjWinSAM = New spi.WinSAM.WsNETAPI()
        Try
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

            Dim intWinRet As Integer                            'WinSAM�ߒl
            Dim strSock As New System.Text.StringBuilder(256)   '�߲�ߖ�
            Dim bytOpenMode As Byte = WsWSID.ASYOUT + WsWSID.SYNOUT     'Ӱ��
            intWinRet = mobjWinSAM.nsp_open(strSock.Append("\\.\pipe\link.sock"), bytOpenMode)
            If intWinRet <> WsWSRC.NORMAL Then     '// ���A���F����I��(0)�ȊO
                Call AddToLog("nsp_open �Ɏ��s���܂����BRC =" & Str(intWinRet) & " : �ڍ׃R�[�h =" + Str(mobjWinSAM.ns_GetLastError))
            Else
                Call AddToLog("nsp_open ���������܂����B")
            End If
        Catch ex As Exception
            Call ComError(ex)
        End Try


        '*****************************************************
        '������ݒ�
        '*****************************************************
        mobjGetTelegram.strSTX = mobjASCII.strSTX
        mobjGetTelegram.strETX = mobjASCII.strETX & mobjASCII.strCR


        '���������ŗL����
        '**********************************************************************************************************************


        '****************************************************
        '�ʐM�����
        '****************************************************
        Call Open()


        '*****************************************************
        ' ���Đڑ��ҋ@�ׂ̈���аٰ��
        '*****************************************************
        Dim dtmTemp As Date = Now
        While True
            If dtmTemp.AddSeconds(1) < Now Then
                Exit While
            End If
        End While


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

#Region "  �ʐM�����            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ʐM�����
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Open()
        'mobjSockListener.intPortNo = mintAGCSockSendPort         '�߰�No
        'mobjSockListener.Listen()                                '�ҋ@
    End Sub
#End Region
#Region "  �ʐM�۰��            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ʐM�۰��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Close()
        'mobjSockListener.Shutdown()
    End Sub
#End Region
#Region "  �ް����M(����ؽŰ)               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް����M
    ''' </summary>
    ''' <param name="strSendText">���M÷��</param>
    ''' <returns>����I���̗L��</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SendDataVListener(ByVal strSendText As String) As RetCode

        ''���đ��M
        'mobjSockListener.bytSendText = mobjGetTelegram.MakeTelegramDataLength101(strSendText, mintEQTelegramInforLength)
        'mobjSockListener.Send()

        ''۸ޏo��
        'Call AddToLog(MCIA_MSG_021 & strSendText)   '۸ޏo��
        'mdtmBeforeETXSendTime = Now

    End Function
#End Region
#Region "  �ް���M(����ؽŰ)               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���M
    ''' </summary>
    ''' <param name="strRecvText">��M÷��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub RecvDataVListener(ByRef strRecvText As String)


        ''****************************************
        ''���Ď�M
        ''****************************************
        'mobjSockListener.Receive()


        ''****************************************
        ''���Ď�M�ޯ̧�Ɍ���
        ''****************************************
        'If IsNull(mbytRecvTelBuff) Then
        '    mbytRecvTelBuff = mobjSockListener.bytRecvText
        'Else
        '    ReDim Preserve mbytRecvTelBuff(mbytRecvTelBuff.Length + TO_INTEGER(mobjSockListener.bytRecvText.Length) - 1)
        '    mobjSockListener.bytRecvText.CopyTo(mbytRecvTelBuff, mobjSockListener.bytRecvText.Length)
        'End If


        ''****************************************
        ''�d�������𒊏o & ���Ď�M�ޯ̧�X�V
        ''****************************************
        'If IsNotNull(mobjSockListener.strRecvText) Then
        '    '(�d������M�����ꍇ)

        '    strRecvText = mobjGetTelegram.GetTelegramDataLength101(mbytRecvTelBuff _
        '                                                         , mintEQTelegramInforLength _
        '                                                         )

        '    If IsNotNull(strRecvText) Then
        '        Call AddToLog(MCIA_MSG_011 & strRecvText) '�d���擾۸ޏo��
        '    End If

        'End If


    End Sub
#End Region
#Region "  �ް����M(���ĸײ���)             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް����M
    ''' </summary>
    ''' <param name="bytSendText">���M÷�Ă��޲Ĕz��</param>
    ''' <returns>����I���̗L��</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SendDataVClient(ByVal bytSendText() As Byte) As RetCode



        '// nsp_hout:�b�o�t(�z�X�g)�o�͏���
        '// �p�����[�^
        '//   destpid
        '//     [OUT]�f�[�^���o�͂��鑊���z�X�g���̂��w�肵�܂��B
        '//   originpid
        '//     [OUT] �o�̓f�[�^�̔��M���̖��O���w�肵�܂��B
        '//   wsoTermData
        '//     [OUT] WsNETTermData�N���X�B���M�f�[�^�[����ё��M�f�[�^�[�̓���
        '// �߂�l
        '//   ���g���C�ɂ��p���\�ȃG���[�ԍ�
        Dim intWinRet As Integer                                    'WinSAM�ߒl
        Dim destpid As New System.Text.StringBuilder(32)            '���̓p�C�v���ʖ�
        Dim originpid As New System.Text.StringBuilder(32)          '�����[����
        Dim objwsiData As New spi.WinSAM.Data.WsNETTermData(MAX_LEN)    '�擾�ް�
        objwsiData.Func = 0
        objwsiData.Control = 0
        objwsiData.ApLevel = 1
        objwsiData.ApLinkNo = 1
        objwsiData.Flow = 0
        objwsiData.Length = bytSendText.Length
        For ii As Integer = 0 To UBound(bytSendText)
            '(ٰ��:�ް�)
            objwsiData.Data(ii) = bytSendText(ii)
        Next
        intWinRet = mobjWinSAM.nsp_hout(destpid.Append("host"), originpid.Append("link"), objwsiData)
        If intWinRet = WsWSRC.NORMAL Then     '// ���A���F����I��(0)�ȊO
            '(����I���̏ꍇ)
            'NOP
        Else
            '(�ُ�I���̏ꍇ)
            Call AddToLog("nsp_hout �����Ɏ��s���܂����BRC =" + Str(intWinRet) + " : �ڍ׃R�[�h =" + Str(mobjWinSAM.ns_GetLastError))
        End If


        ''���đ��M
        'mobjSockClient.Connect()
        'mobjSockClient.bytSendText = bytSendText
        'mobjSockClient.Send()

        '۸ޏo��
        Call AddToLog(MCIA_MSG_021 & mobjASCII.GetLogString16(bytSendText))   '۸ޏo��
        mdtmBeforeETXSendTime = Now

    End Function
#End Region
#Region "  �ް���M(���ĸײ���)             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���M
    ''' </summary>
    ''' <param name="strRecvText">��M÷��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub RecvDataVClient(ByRef strRecvText As String)


        '****************************************
        '���Ď�M
        '****************************************
        Dim intWinRet As Integer                                    'WinSAM�ߒl
        Dim destpid As New System.Text.StringBuilder(32)            '���̓p�C�v���ʖ�
        Dim originpid As New System.Text.StringBuilder(32)          '�����[����
        Dim objwsiData As New spi.WinSAM.Data.WsNETTermData(MAX_LEN)    '�擾�ް�
        objwsiData.AutoComp = 1
        '// nsp_hinput:�z�X�g���͏������\�b�h
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
        intWinRet = mobjWinSAM.nsp_hinput(destpid, originpid, objwsiData, 2)



        ''****************************************
        ''���Ď�M�ޯ̧�Ɍ���
        ''****************************************
        'If IsNull(mbytRecvTelBuff) Then
        '    mbytRecvTelBuff = mobjSockClient.bytRecvText
        'Else
        '    ReDim Preserve mbytRecvTelBuff(mbytRecvTelBuff.Length + mobjSockClient.bytRecvText.Length - 1)
        '    mobjSockClient.bytRecvText.CopyTo(mbytRecvTelBuff, mobjSockClient.bytRecvText.Length)
        'End If


        '****************************************
        '�d�������𒊏o & ���Ď�M�ޯ̧�X�V
        '****************************************
        If intWinRet = WsWSRC.NORMAL Then           '// ���A���F����I��(0)
            '(�d������M�����ꍇ)

            For ii As Integer = 0 To objwsiData.Length - 1
                If ii = 0 Then
                    strRecvText = Change10To16(objwsiData.Data(ii), 2)
                Else
                    strRecvText &= "_"
                    strRecvText &= Change10To16(objwsiData.Data(ii), 2)
                End If
            Next
            'strRecvText = mobjGetTelegram.GetTelegramDataLength101(mbytRecvTelBuff _
            '                                                     , mintEQTelegramInforLength _
            '                                                     )

            If IsNotNull(strRecvText) Then
                Call AddToLog(MCIA_MSG_011 & strRecvText) '�d���擾۸ޏo��
                mbytRecvTelBuff = Nothing
            End If

        ElseIf intWinRet = WsWSRC.TIMEOUT Then  '// ���A���F�^�C���A�E�g(10)
            '(��ѱ�Ă̏ꍇ)
            'NOP
        Else
            '(���̑��̏ꍇ)
            Call AddToLog("nsp_hinput �����s���܂����BRC =" & Str(intWinRet) & " �ڍ׃R�[�h =" & Str(mobjWinSAM.ns_GetLastError))
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


            ''*****************************************************
            ''��M�d���L������
            ''*****************************************************
            'If strRecvText = "" Then Exit Sub
            'mdtmBeforeETXRecvTime = Now


            ''*****************************************************
            ''��M�d������
            ''*****************************************************
            'Dim objTel As New clsTelegram(CONFIG_TELEGRAM_BZ)
            'objTel.FORMAT_ID = FORMAT_BZ_HOSTNZ                 '̫�ϯĖ����    (���ɉ��ł��ǂ�)
            'objTel.TELEGRAM_PARTITION = strRecvText             '��������d�����
            'objTel.PARTITION()                                  '�d������


            'If gobjMCIToServer.chkResponseAuto.Checked = True Then
            '    '(���������̏ꍇ)


            '    Select Case FORMAT_BZ & Trim(objTel.SELECT_HEADER("BZMACHINE_NO")) & Trim(objTel.SELECT_HEADER("BZDATA_KIND_CD"))
            '        Case FORMAT_BZ_PR10NYU : Call SendResponseBZ_etc(strRecvText)       '���Ɏ���
            '        Case FORMAT_BZ_PR10SK0 : Call mobjSockClient.ShutDown()             '�o�Ɍv���̉���
            '        Case FORMAT_BZ_PR10SYU : Call SendResponseBZ_etc(strRecvText)       '�o�Ɏ���
            '        Case FORMAT_BZ_PR10ZT : Call SendResponseBZ_PR10ZT(strRecvText)     '�݌ɖ⍇��
            '    End Select


            'End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region



End Class
