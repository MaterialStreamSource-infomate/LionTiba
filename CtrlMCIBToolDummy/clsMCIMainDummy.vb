'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�ʐM��аҲݸ׽              (KSH�p���ޯ��°قł�)
' �y�쐬�z2006/05/30  SIT  Rev 0.00
'**********************************************************************************************

#Region "  Imports  "
Imports JOBCommon
Imports MateCommon.clsConst
Imports MateCommon
Imports UserProcess
#End Region

Public Class clsMCIMainDummy

#Region "  ���ʕϐ�02           "

    Private mobjSocket As clsSocketListener             '����ؽŰ�׽
    Private mobjMCIMain As CtrlMCIB.clsMCIMain          '�{���̒ʐM��۸��Ѹ׽
    Private mobjGetTelegram As clsGetTelegram           '�d���p÷�Ď擾�׽

    'AGC�ւ̿��ėp
    Private mstrAGCSockSendAddress As String        'AGC���M����ڽ
    Private mintAGCSockSendPort As Integer          'AGC���M���߰�No
    Private mintAGCSockSendTimeOut As Integer       'AGC�������đҋ@����
    Private mintAGCSockETXSendTimeOut As Integer    'AGC�����ETX���đ��M���� (ms)
    Private mintAGCSockETXRecvTimeOut As Integer    'AGC�����ETX���Ď�M���� (ms)

    Private mintSendCount As Integer          '�đ��M��
    Private mdtmBeforeRecvTime As Date        '�O���M����
    Private mdtmBeforeSendTime As Date        '�O�񑗐M����
    Private mdtmBeforeETXSendTime As Date     '�O��ETX���M����
    Private mdtmBeforeETXRecvTime As Date     '�O��ETX��M����
    Private mstrRecvTelBuff As String         '���Ď�M�ޯ̧
    Private mblnIsConnect As Boolean          '���Đڑ��׸�

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
            mobjSocket.intDebugFlag = Value
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
                Call RecvDataVAGC(strRecvText)


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
            mstrRecvTelBuff = ""                                '���Ď�M�ޯ̧
            mdtmNow = Now
            mobjMCIMain = New CtrlMCIB.clsMCIMain(objOwner, objDb, objDbLog)    '�{���̒ʐM��۸��Ѹ׽

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
        Dim objConfig As New clsConnectConfig(CONFIG_MCIB_DUMMY)                                     'Confiģ�ِڑ��׽����

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


        '****************************************************
        '�޲̸���ĒʐM�׽������
        '****************************************************
        mobjSocket = New clsSocketListener(mobjOwner)
        mobjSocket.intPortNo = mintAGCSockSendPort
        mobjSocket.intDebugFlag = mintDebugFlag


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
        mobjSocket.intPortNo = mintAGCSockSendPort         '�߰�No
        mobjSocket.Listen()                                '�ҋ@
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
        mobjSocket.Shutdown()
    End Sub
#End Region
#Region "  �ް����M             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް����M
    ''' </summary>
    ''' <param name="strSendText">���M÷��</param>
    ''' <returns>����I���̗L��</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SendDataVAGC(ByVal strSendText As String) As RetCode

        '���đ��M
        mobjSocket.strSendText = mobjGetTelegram.MakeTelegramSTXETX(strSendText)
        mobjSocket.Send()

        '۸ޏo��
        Call AddToLog(MCIA_MSG_021 & strSendText)   '۸ޏo��
        mdtmBeforeETXSendTime = Now

    End Function
#End Region
#Region "  �ް���M             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���M
    ''' </summary>
    ''' <param name="strRecvText">��M÷��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub RecvDataVAGC(ByRef strRecvText As String)


        '****************************************
        '���Ď�M
        '****************************************
        mobjSocket.Receive()



        '****************************************
        '���Ď�M�ޯ̧�Ɍ���
        '****************************************
        mstrRecvTelBuff &= mobjSocket.strRecvText


        '****************************************
        '�d�������𒊏o & ���Ď�M�ޯ̧�X�V
        '****************************************
        strRecvText = mobjGetTelegram.GetTelegramSTXETX(mstrRecvTelBuff)
        If IsNotNull(strRecvText) Then
            Call AddToLog(MCIA_MSG_011 & strRecvText) '�d���擾۸ޏo��
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
        'Try


        '    '*****************************************************
        '    '��M�d���L������
        '    '*****************************************************
        '    If strRecvText = "" Then Exit Sub
        '    mdtmBeforeETXRecvTime = Now


        '    '*****************************************************
        '    '��M�d������
        '    '*****************************************************
        '    Dim objTel As New clsTelegram(CONFIG_TELEGRAM_LC)
        '    objTel.FORMAT_ID = FORMAT_LC_01                     '̫�ϯĖ����    (���ɉ��ł��ǂ�)
        '    objTel.TELEGRAM_PARTITION = strRecvText             '��������d�����
        '    objTel.PARTITION()                                  '�d������


        '    If gobjMCIToServer.chkResponseAuto.Checked = True Then
        '        '(���������̏ꍇ)

        '        'If Mid(strRecvText, 1, 1) = LCCOMMAND_05 Then
        '        '    '(�⍇��ү���ނ̏ꍇ)

        '        '    Call SendResponseLC_05(strRecvText)

        '        'Else

        '        '    Select Case TO_STRING(Mid(strRecvText, 2, 1))
        '        '        Case LCCOMMAND_01 : Call SendResponseLC_etc(strRecvText)
        '        '        Case LCCOMMAND_02 : Call SendResponseLC_etc(strRecvText)
        '        '        Case LCCOMMAND_03 : Call SendResponseLC_etc(strRecvText)
        '        '        Case LCCOMMAND_04 : Call SendResponseLC_etc(strRecvText)
        '        '        Case LCCOMMAND_06 : Call SendResponseLC_etc(strRecvText)
        '        '        Case Else : Call SendResponseLC_etc(strRecvText)
        '        '    End Select

        '        'End If

        '        'If gobjMCIToServer.chkCraneStatusAutoUpdate.Checked = True Then
        '        '    '(�ڰݏ�Ԏ����X�V�̏ꍇ)
        '        '    Call CraneStatusAutoUpdate(strRecvText)
        '        'End If

        '    End If


        'Catch ex As Exception
        '    ComError(ex)

        'End Try
    End Sub
#End Region
#Region "  ID:05  �⍇��ү���ނɑ΂��鉞��                  "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ID:05  �⍇��ү���ނɑ΂��鉞��
    ''' </summary>
    ''' <param name="strRecvText">����Ɏ�M�ł����ް�</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub SendResponseLC_05(ByVal strRecvText As String)
        'Try


        '    '*************************************************
        '    '�d�����M
        '    '*************************************************
        '    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_LC)
        '    objTelegram.FORMAT_ID = FORMAT_LC_00            '̫�ϯĖ����

        '    objTelegram.SETIN_DATA("LCCRN01_RES", gobjMCIToServer.txtLCCRN01_RES.Text)                  '�ڰ�1����
        '    objTelegram.SETIN_DATA("LCCRN01_UNU", gobjMCIToServer.txtLCCRN01_UNU.Text)                  '�ڰ�1�ُ���
        '    objTelegram.SETIN_DATA("LCCRN02_RES", gobjMCIToServer.txtLCCRN02_RES.Text)                  '�ڰ�2����
        '    objTelegram.SETIN_DATA("LCCRN02_UNU", gobjMCIToServer.txtLCCRN02_UNU.Text)                  '�ڰ�2�ُ���
        '    objTelegram.SETIN_DATA("LCCRN03_RES", gobjMCIToServer.txtLCCRN03_RES.Text)                  '�ڰ�3����
        '    objTelegram.SETIN_DATA("LCCRN03_UNU", gobjMCIToServer.txtLCCRN03_UNU.Text)                  '�ڰ�3�ُ���
        '    objTelegram.SETIN_DATA("LCCRN0401_RES", gobjMCIToServer.txtLCCRN0401_RES.Text)              '�ڰ�4���1����
        '    objTelegram.SETIN_DATA("LCCRN0402_RES", gobjMCIToServer.txtLCCRN0402_RES.Text)              '�ڰ�4���2����
        '    objTelegram.SETIN_DATA("LCCRN0401_STATE", gobjMCIToServer.txtLCCRN0401_STATE.Text)          '�ڰ�4���1���
        '    objTelegram.SETIN_DATA("LCCRN0402_STATE", gobjMCIToServer.txtLCCRN0402_STATE.Text)          '�ڰ�4���2���

        '    objTelegram.MAKE_TELEGRAM()                             '�d���쐬
        '    Call SendDataVAGC(objTelegram.TELEGRAM_MAKED)           '���M�d��


        'Catch ex As Exception
        '    ComError(ex)

        'End Try
    End Sub
#End Region
#Region "  ID:etc ���̑��d���ɑ΂��鉞��                    "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ID:etx ���̑��d���ɑ΂��鉞��
    ''' </summary>
    ''' <param name="strRecvText">����Ɏ�M�ł����ް�</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub SendResponseLC_etc(ByVal strRecvText As String)
        'Try


        '    '*************************************************
        '    '�d�����M
        '    '*************************************************
        '    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_LC)
        '    objTelegram.FORMAT_ID = FORMAT_LC_00            '̫�ϯĖ����

        '    objTelegram.SETIN_DATA("LCCRN01_RES", gobjMCIToServer.txtLCCRN01_RES_02.Text)                  '�ڰ�1����
        '    objTelegram.SETIN_DATA("LCCRN01_UNU", gobjMCIToServer.txtLCCRN01_UNU_02.Text)                  '�ڰ�1�ُ���
        '    objTelegram.SETIN_DATA("LCCRN02_RES", gobjMCIToServer.txtLCCRN02_RES_02.Text)                  '�ڰ�2����
        '    objTelegram.SETIN_DATA("LCCRN02_UNU", gobjMCIToServer.txtLCCRN02_UNU_02.Text)                  '�ڰ�2�ُ���
        '    objTelegram.SETIN_DATA("LCCRN03_RES", gobjMCIToServer.txtLCCRN03_RES_02.Text)                  '�ڰ�3����
        '    objTelegram.SETIN_DATA("LCCRN03_UNU", gobjMCIToServer.txtLCCRN03_UNU_02.Text)                  '�ڰ�3�ُ���
        '    objTelegram.SETIN_DATA("LCCRN0401_RES", gobjMCIToServer.txtLCCRN0401_RES_02.Text)              '�ڰ�4���1����
        '    objTelegram.SETIN_DATA("LCCRN0402_RES", gobjMCIToServer.txtLCCRN0402_RES_02.Text)              '�ڰ�4���2����
        '    objTelegram.SETIN_DATA("LCCRN0401_STATE", gobjMCIToServer.txtLCCRN0401_STATE_02.Text)          '�ڰ�4���1���
        '    objTelegram.SETIN_DATA("LCCRN0402_STATE", gobjMCIToServer.txtLCCRN0402_STATE_02.Text)          '�ڰ�4���2���

        '    objTelegram.MAKE_TELEGRAM()                             '�d���쐬
        '    Call SendDataVAGC(objTelegram.TELEGRAM_MAKED)           '���M�d��


        'Catch ex As Exception
        '    ComError(ex)

        'End Try
    End Sub
#End Region


End Class
