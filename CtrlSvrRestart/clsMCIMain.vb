'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zMCIҲݸ׽(���ގ����ċN��)
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

    Private mstrBatchFilePath As String                    '���ލċN���ޯ�̧��

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
                Dim strSQL As String                'SQL��
                Dim objRow As DataRow               '1ں��ޕ����ް�
                Dim objDataSet As New DataSet       '�ް����
                Dim strDataSetName As String        '�ް���Ė�
                mdtmNow = Now


                '************************************************
                '۸ޏo��
                '************************************************
                Call AddToLog("�����B")


                '************************************************
                '���ѕϐ�           �擾
                '************************************************
                Dim intTimOut As Integer = 0
                Try
                    intTimOut = GetSYS_HEN(FHENSU_ID_SSJ000000_061)
                Catch ex As Exception
                    ComError(ex)
                End Try


                '************************************************
                '��ݻ޸���۸�       �擾
                '************************************************
                strSQL = ""
                strSQL &= vbCrLf & "SELECT "
                strSQL &= vbCrLf & "    MAX(FLAST_DT) FLAST_DT "
                strSQL &= vbCrLf & " FROM "
                strSQL &= vbCrLf & "    TPRG_TIMER "
                strSQL &= vbCrLf

                mobjDb.SQL = strSQL
                objDataSet.Clear()
                strDataSetName = "TPRG_TIMER"
                mobjDb.GetDataSet(strDataSetName, objDataSet)
                If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                    objRow = objDataSet.Tables(strDataSetName).Rows(0)


                    '************************************************
                    '��ѱ��         ����
                    '************************************************
                    Dim dtmFHASSEI_DT As Date = TO_DATE(objRow("FLAST_DT"))
                    If intTimOut < DateDiff(DateInterval.Second, dtmFHASSEI_DT, Now) Then
                        '(��ѱ�Ă����ꍇ)
                        Call Shell(mstrBatchFilePath)
                        Call AddToLog("���ލċN���ޯ�̧�ق����s���܂����B")
                        Call ErrorAdd(FMSG_ID_S9003, "")
                    Else
                        '(��ѱ�Ă��Ă��Ȃ��ꍇ)
                        'NOP
                    End If


                End If


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
        mobjASCII = New clsASCII()              'ASCII���ޕ����׽


        '*****************************************************
        'Confiģ�ُ��擾(�W������)
        '*****************************************************
        Dim objConfig As New clsConnectConfig(CONFIG_SVRRESTART)                                    'Confiģ�ِڑ��׽����

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

        mstrBatchFilePath = TO_STRING(objConfig.GET_INFO(GKEY_MCI_BATCH_FILE_PATH))             '���ލċN���ޯ�̧��

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


        Catch ex As Exception
            'NOP(���s���Ă����ɖ��Ȃ�)
        End Try
    End Sub
#End Region







End Class
