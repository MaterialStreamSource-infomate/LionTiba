'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�����ݔ���M�Ǎ�����
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_020101
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �ݽ�׸�                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ݽ�׸�
    ''' </summary>
    ''' <param name="objOwner"></param>
    ''' <param name="objDb"></param>
    ''' <param name="objDbLog"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '�e�׽�̺ݽ�׸�������

    End Sub
#End Region
#Region "  Ҳݏ���                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Ҳݏ���
    ''' </summary>
    ''' <param name="strMSG_RECV">��M�d��</param>
    ''' <param name="strMSG_SEND">���M�d��</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim intRet As RetCode                   '�߂�l
        Dim strMsg As String                    'ү����
        Dim ii As Integer                       '����
        Try

            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 '���ѕϐ�


            '************************
            '���������
            '************************
            Call ProcessTimer01()


            '************************
            '���������MIF�Ǎ���
            '************************
            Dim objTLIF_TRNS_RECV_Array(0) As TBL_TLIF_TRNS_RECV        '���������MIF�׽
            intRet = Get_TrnsRecv(objTLIF_TRNS_RECV_Array)
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                Return RetCode.OK
            End If


            ''************************
            ''��������
            ''************************
            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            For ii = LBound(objTLIF_TRNS_RECV_Array) To UBound(objTLIF_TRNS_RECV_Array)
                '(ٰ��:�������w��)

                '************************
                '���������MIF�̓���
                '************************
                Dim objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV                 '���������MIF�׽
                objTLIF_TRNS_RECV = objTLIF_TRNS_RECV_Array(ii)

                Try

                    '******************************
                    '������������
                    '******************************
                    Dim objTMST_RES_CD_EQ As New TBL_TMST_RES_CD_EQ(Owner, ObjDb, ObjDbLog) '�������ޏ���Ͻ��׽
                    objTMST_RES_CD_EQ.FEQ_ID = objTLIF_TRNS_RECV.FEQ_ID                     '�ݔ�ID
                    objTMST_RES_CD_EQ.FDIRECTION = FDIRECTION_SRECV                         '����
                    If IsNull(objTLIF_TRNS_RECV.FRES_CD_EQ) = True Then
                        objTMST_RES_CD_EQ.FRES_CD_EQ = FRES_CD_EQ_SMCI_OK                   '�ݔ���������
                    Else
                        objTMST_RES_CD_EQ.FRES_CD_EQ = objTLIF_TRNS_RECV.FRES_CD_EQ         '�ݔ���������
                    End If
                    intRet = objTMST_RES_CD_EQ.GET_TMST_RES_CD_EQ(False)
                    If intRet = RetCode.OK Then
                        '(���������ꍇ)

                        '========================
                        'ү���ޏo��
                        '========================
                        If TO_INTEGER(objTMST_RES_CD_EQ.FMSG_FLAG) = FLAG_ON Then
                            '(ү����۸ޏo���׸ނ�ON�̏ꍇ)
                            Select Case objTLIF_TRNS_RECV.FEQ_ID
                                Case FEQ_ID_JSYS0000 : Call AddToMsgLog(Now, FMSG_ID_J6003, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "��������(MELSEC���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0001 : Call AddToMsgLog(Now, FMSG_ID_J6103, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "��������(SW01  ���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0002 : Call AddToMsgLog(Now, FMSG_ID_J6203, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "��������(SW02  ���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0003 : Call AddToMsgLog(Now, FMSG_ID_J6303, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "��������(SW03  ���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0004 : Call AddToMsgLog(Now, FMSG_ID_J6403, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "��������(SW04  ���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0005 : Call AddToMsgLog(Now, FMSG_ID_J6503, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "��������(SW05  ���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0006 : Call AddToMsgLog(Now, FMSG_ID_J6603, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "��������(SW04A ���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                    '������������************************************************************************************************************
                                    'JobMate:S.Ouchi 2015/06/25 CW6�ǉ��Ή� ������������
                                Case FEQ_ID_JSYS0007 : Call AddToMsgLog(Now, FMSG_ID_J6703, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "��������(SW06  ���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                    'JobMate:S.Ouchi 2015/06/25 CW6�ǉ��Ή� ������������
                                    '������������************************************************************************************************************
                            End Select
                        End If

                        '========================
                        '�ݔ��ؗ�
                        '========================
                        If TO_INTEGER(objTMST_RES_CD_EQ.FCUT_FLAG) = FLAG_ON Then
                            '(�ݔ��ؗ��׸ނ�ON�̏ꍇ)

                            '========================
                            '�ݔ��󋵂̍X�V
                            '========================
                            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     '�ݔ��󋵸׽
                            objTSTS_EQ_CTRL.FEQ_ID = objTLIF_TRNS_RECV.FEQ_ID                       '�ݔ�ID
                            intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(False)                        '����
                            If intRet = RetCode.NotFound Then
                                '(������Ȃ��ꍇ)
                                strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[�ݔ�ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]"
                                Throw New UserException(strMsg)
                            End If
                            objTSTS_EQ_CTRL.FEQ_CUT_STS = FLAG_ON           '�ؗ����
                            objTSTS_EQ_CTRL.FUPDATE_DT = Now                '�X�V����
                            objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()           '�X�V

                            '========================
                            '�������䑗�MIF�̍X�V
                            '========================
                            objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_STRY     '�i�����
                            objTLIF_TRNS_RECV.FRES_CD_EQ = DEFAULT_STRING   '�ݔ���������
                            objTLIF_TRNS_RECV.FUPDATE_DT = Now              '�X�V����
                            objTLIF_TRNS_RECV.UPDATE_TLIF_TRNS_RECV()       '�X�V

                        End If


                    Else
                        '(������Ȃ������ꍇ)

                        '========================
                        'ү���ޏo��
                        '========================
                        Select Case objTLIF_TRNS_RECV.FEQ_ID
                            Case FEQ_ID_JSYS0000 : Call AddToMsgLog(Now, FMSG_ID_J6003, "�ُ퉞�����ގ�M�B", "��������(MELSEC���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0001 : Call AddToMsgLog(Now, FMSG_ID_J6103, "�ُ퉞�����ގ�M�B", "��������(SW01  ���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0002 : Call AddToMsgLog(Now, FMSG_ID_J6203, "�ُ퉞�����ގ�M�B", "��������(SW02  ���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0003 : Call AddToMsgLog(Now, FMSG_ID_J6303, "�ُ퉞�����ގ�M�B", "��������(SW03  ���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0004 : Call AddToMsgLog(Now, FMSG_ID_J6403, "�ُ퉞�����ގ�M�B", "��������(SW04  ���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0005 : Call AddToMsgLog(Now, FMSG_ID_J6503, "�ُ퉞�����ގ�M�B", "��������(SW05  ���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0006 : Call AddToMsgLog(Now, FMSG_ID_J6603, "�ُ퉞�����ގ�M�B", "��������(SW04A ���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                '������������************************************************************************************************************
                                'JobMate:S.Ouchi 2015/06/25 CW6�ǉ��Ή� ������������
                            Case FEQ_ID_JSYS0007 : Call AddToMsgLog(Now, FMSG_ID_J6703, "�ُ퉞�����ގ�M�B", "��������(SW06 ���ý�):" & objTLIF_TRNS_RECV.FRES_CD_EQ)
                                'JobMate:S.Ouchi 2015/06/25 CW6�ǉ��Ή� ������������
                                '������������************************************************************************************************************
                        End Select


                        '========================
                        '�������䑗�MIF�̍폜
                        '========================
                        objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV()       '�폜

                    End If


                    '************************
                    '�d������
                    '************************
                    Dim objTelegram As clsTelegram                                              '��M�d������
                    objTelegram = Nothing
                    DenbunBunkai(objTLIF_TRNS_RECV, objTelegram)


                    '************************
                    '���������M�������s
                    '************************
                    Dim blnRetry As Boolean = False     '��ײ�׸�
                    Call Command_Junction(objTLIF_TRNS_RECV _
                                        , objTelegram _
                                        , blnRetry _
                                        )


                    '************************
                    '���������MIF�̍폜
                    '************************
                    If blnRetry = False Then
                        '(��ײ���Ȃ��ꍇ)
                        objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV()           '�폜
                    Else
                        '(��ײ����ꍇ)
                        ObjDb.RollBack()                                    '۰��ޯ�
                        ObjDb.BeginTrans()                                  '��ݻ޸��݊J�n
                    End If


                Catch ex As RollBackException
                    ObjDb.RollBack()                                    '۰��ޯ�
                    ObjDb.BeginTrans()                                  '��ݻ޸��݊J�n
                    objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV()           '�폜
                Catch ex As UserException
                    Call ComUser(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    '۰��ޯ�
                    ObjDb.BeginTrans()                                  '��ݻ޸��݊J�n
                    objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SERR_SVR     '�i�����(�ُ�)
                    objTLIF_TRNS_RECV.FUPDATE_DT = Now                  '�X�V����
                    objTLIF_TRNS_RECV.UPDATE_TLIF_TRNS_RECV()           '�X�V
                Catch ex As Exception
                    Call ComError(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    '۰��ޯ�
                    ObjDb.BeginTrans()                                  '��ݻ޸��݊J�n
                    objTLIF_TRNS_RECV.FPROGRESS = FPROGRESS_SERR_SVR     '�i�����(�ُ�)
                    objTLIF_TRNS_RECV.FUPDATE_DT = Now                  '�X�V����
                    objTLIF_TRNS_RECV.UPDATE_TLIF_TRNS_RECV()           '�X�V
                Finally
                    ObjDb.Commit()      '�Я�
                    ObjDb.BeginTrans()  '��ݻ޸��݊J�n
                End Try
            Next


            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S020151)                           '�N��


            ''************************
            ''���튮��
            ''************************
            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, KOTEI_TRNS_END_NORMAL)
            Return RetCode.OK

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        End Try
    End Function
#End Region
#Region "  ���������MIF�Ǎ���                                                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���������MIF�Ǎ���
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">�o�^No(�z��)</param>
    ''' <returns>OK/NotFound</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Get_TrnsRecv(ByRef objTLIF_TRNS_RECV() As TBL_TLIF_TRNS_RECV) As RetCode
        Try
            Dim strSQL As String                'SQL��
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim objRow As DataRow               '1ں��ޕ����ް�
            Dim ii As Integer                   '����


            '************************
            '���oSQL�쐬
            '************************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    FENTRY_NO "                 '�o�^No
            strSQL &= vbCrLf & "   ,FEQ_ID "                    '�ݔ�ID
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TLIF_TRNS_RECV "            '���������MIF
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FPROGRESS = '" & FPROGRESS_SEND & "'"    '�i�����(�����{)
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    FENTRY_NO"                  '�o�^No
            strSQL &= vbCrLf


            '************************
            '���o
            '************************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TLIF_TRNS_RECV"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For ii = 0 To objDataSet.Tables(strDataSetName).Rows.Count - 1
                    objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                    ReDim Preserve objTLIF_TRNS_RECV(ii)
                    objTLIF_TRNS_RECV(ii) = New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog)
                    objTLIF_TRNS_RECV(ii).FENTRY_NO = TO_STRING(objRow("FENTRY_NO"))    '�o�^No
                    objTLIF_TRNS_RECV(ii).FEQ_ID = TO_STRING(objRow("FEQ_ID"))          '�ݔ�ID
                    objTLIF_TRNS_RECV(ii).GET_TLIF_TRNS_RECV(False)                     '����
                Next
                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region

    '**********************************************************************************************
    '���������ьŗL

#Region "  �d����������                                                                         "
    ''' <summary>
    ''' �d����������
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">�d������̫�ϯ�</param>
    ''' <param name="objTelegram">��M�d����޼ު��</param>
    ''' <remarks></remarks>
    Private Sub DenbunBunkai(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                         , ByRef objTelegram As clsTelegram)
        'Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


        Catch ex As ContinueForException
            Throw New ContinueForException()
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ����ޕ��򏈗�                                                                        "
    '''**********************************************************************************************
    ''' <summary>
    ''' ����ޕ��򏈗�
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">�d������̫�ϯ�</param>
    ''' <param name="objTelegram">��M�d����޼ު��</param>
    ''' <param name="blnRetry">��ײ�׸�</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub Command_Junction(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                               , ByRef objTelegram As clsTelegram _
                               , ByRef blnRetry As Boolean _
                               )
        'Private Sub Command_Junction(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
        '                           , ByRef objTelegram As clsTelegram)


        Dim intRet As RetCode                   '�߂�l
        Dim strMsg As String                    'ү����
        Try
            Select Case objTLIF_TRNS_RECV.FCOMMAND_ID
                Case FCOMMAND_ID_SIN_END
                    '(���Ɋ���)
                    AddToLog("����t:���Ɋ���", "", LogType.INFO)

                    Dim objCommand As New SVR_010102(Owner, ObjDb, ObjDbLog)
                    objCommand.FPALLET_ID = objTLIF_TRNS_RECV.FPALLET_ID
                    objCommand.FINOUT_STS = FINOUT_STS_SIN_END
                    Call objCommand.ExecCmdFunction()
                    intRet = RetCode.OK


                Case FCOMMAND_ID_SOUT_END
                    '(�o�Ɋ���)
                    AddToLog("����t:�o�Ɋ���", "", LogType.INFO)

                    Dim objCommand As New SVR_010202(Owner, ObjDb, ObjDbLog)
                    objCommand.FPALLET_ID = objTLIF_TRNS_RECV.FPALLET_ID
                    objCommand.FINOUT_STS = FINOUT_STS_SOUT_END
                    Call objCommand.ExecCmdFunction()
                    intRet = RetCode.OK


                Case FCOMMAND_ID_SCUT_EQ
                    '(�ݔ��ؗ����v��)

                    Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     '�ݔ��󋵸׽
                    objTSTS_EQ_CTRL.FEQ_ID = objTLIF_TRNS_RECV.FDENBUN_PRM1                 '�ݔ�ID
                    objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(False)                                 '�擾
                    objTSTS_EQ_CTRL.FEQ_CUT_STS = FEQ_CUT_STS_SON                           '�ؗ����
                    objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()                                   '�X�V


                Case FCOMMAND_ID_SEVENT
                    '(����Ēʒm)

                    AddToLog("����t:����Ēʒm��t", "", LogType.INFO)
                    intRet = FCOMMAND_ID_EVENTProcess(objTLIF_TRNS_RECV)


                Case FCOMMAND_ID_SADD_MSG
                    AddToMsgLog(Now, objTLIF_TRNS_RECV.FDENBUN_PRM1, _
                                     objTLIF_TRNS_RECV.FDENBUN_PRM2, _
                                     objTLIF_TRNS_RECV.FDENBUN_PRM3, _
                                     objTLIF_TRNS_RECV.FDENBUN_PRM4, _
                                     objTLIF_TRNS_RECV.FDENBUN_PRM5, _
                                     objTLIF_TRNS_RECV.FDENBUN_PRM6)


                Case FCOMMAND_ID_SSQL
                    '(SQL���s)


                    'Case FCOMMAND_ID_JMCV_000
                    '    '(�ް��ݸ�m��_MCV)

                    '    intRet = MCVTelRecv000(objTLIF_TRNS_RECV)

                    'Case FCOMMAND_ID_JMCV_999
                    '    '(�ް��ݸ�ؒf_MCV)

                    '    intRet = MCVTelRecv999(objTLIF_TRNS_RECV)

                Case FCOMMAND_ID_SOT
                    '(���̑�)

                    Select Case objTLIF_TRNS_RECV.FEQ_ID
                        Case FEQ_ID_JSYS0101
                            '(SHIP����̓d���̏ꍇ)

                            Select Case objTLIF_TRNS_RECV.FTEXT_ID
                                Case FTEXT_ID_JR_CARD                       '�Ǎ�_����ذ�ޓǍ�
                                    intRet = CARTelRecvJR_CARD_SendRetTel(objTLIF_TRNS_RECV)
                                    intRet = CARTelRecvJR_CARD(objTLIF_TRNS_RECV)
                                Case Else
                                    '(�����ID���s���ȏꍇ)
                                    strMsg = ERRMSG_NOTFOUND_COMMAND_ID & "[�ݔ�ID:" & objTLIF_TRNS_RECV.FEQ_ID & "][�����ID:" & TO_STRING(objTLIF_TRNS_RECV.FCOMMAND_ID) & "][÷��ID:" & objTLIF_TRNS_RECV.FTEXT_ID & "]"
                                    AddToMsgLog(Now, FMSG_ID_S9001, strMsg)
                                    intRet = RetCode.NG

                            End Select

                        Case Else
                            '(�ݔ�ID���s���ȏꍇ)
                            strMsg = ERRMSG_NOTFOUND_COMMAND_ID & "[�ݔ�ID:" & objTLIF_TRNS_RECV.FEQ_ID & "][�����ID:" & TO_STRING(objTLIF_TRNS_RECV.FCOMMAND_ID) & "]"
                            AddToMsgLog(Now, FMSG_ID_S9001, strMsg)
                            intRet = RetCode.NG
                    End Select

                Case Else
                    '(�����ID���s���ȏꍇ)
                    strMsg = ERRMSG_NOTFOUND_COMMAND_ID & "[�ݔ�ID:" & objTLIF_TRNS_RECV.FEQ_ID & "][�����ID:" & TO_STRING(objTLIF_TRNS_RECV.FCOMMAND_ID) & "]"
                    AddToMsgLog(Now, FMSG_ID_S9001, strMsg)
                    intRet = RetCode.NG
            End Select


        Catch ex As ContinueForException
            Throw New ContinueForException()
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region

#Region "  ����Ēʒm����                                                                        "
    '''**********************************************************************************************
    ''' <summary>
    ''' ����Ēʒm����
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">���������MIFð��ٸ׽</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function FCOMMAND_ID_EVENTProcess(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV) As RetCode
        'Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '������Ǘ��׽


            '************************
            '�ݔ��󋵂̓���
            '************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID = objTLIF_TRNS_RECV.FDENBUN_PRM1
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()


            '************************
            '��������
            '************************
            If Not ( _
                       objTSTS_EQ_CTRL.XEVENT_LOG_KUBUN = XEVENT_LOG_KUBUN_TRK_RTN01 _
                    Or objTSTS_EQ_CTRL.XEVENT_LOG_KUBUN = XEVENT_LOG_KUBUN_TRK_RTN02 _
                    ) Then
                '(RTN�ׯ�ݸފ֌W����Ȃ��ꍇ)
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART & "����Ēʒm��M  [���Ұ�1:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "]" _
                                                                                                                  & "[���Ұ�2:" & objTLIF_TRNS_RECV.FDENBUN_PRM2 & "]" _
                                                                                                                  & "[���Ұ�3:" & objTLIF_TRNS_RECV.FDENBUN_PRM3 & "]" _
                                                                                                                  )
            End If


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/08/16 ���ꏈ��


            '**************************************
            '�o�ɔ�����������
            '**************************************
            Call HanteiOutTrnsEndLoader(objTSTS_EQ_CTRL, objTLIF_TRNS_RECV)


            '������������************************************************************************************************************


            '������������************************************************************************************************************
            'JobMate:YAMAMOTO 2017/08/11 1F��ޏo�ɑΉ� ������������
            'D43,D93���ɗv��OFF���m���ׯ�ݸމ��
            '****************************************************************************
            Call UpdateXSTS_ITF(objTLIF_TRNS_RECV, objTSTS_EQ_CTRL)
            '������������************************************************************************************************************


            '************************
            '�ݔ���Ԃ̍X�V
            '************************
            If Right(objTLIF_TRNS_RECV.FDENBUN_PRM1, 3) = "_IN" Then
                '������������************************************************************************************************************
                '2017/07/29 ���ꏈ���@infomate ���o��Ӱ�ޕҏW
                objTSTS_EQ_CTRL.FEQ_STS = IIf(objTLIF_TRNS_RECV.FDENBUN_PRM2 = "0", "1", "0")       '�ݔ����
                objTSTS_EQ_CTRL.FUPDATE_DT = Now                                '�X�V����
                objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()                           '�X�V
                '������������************************************************************************************************************
            Else
                objTSTS_EQ_CTRL.FEQ_STS = objTLIF_TRNS_RECV.FDENBUN_PRM2        '�ݔ����
                'objTSTS_EQ_CTRL.FEQ_STOP_CD = objTLIF_TRNS_RECV.FDENBUN_PRM3    '��~����
                objTSTS_EQ_CTRL.FUPDATE_DT = Now                                '�X�V����
                objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()                           '�X�V
            End If




            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/03/22 ���ꏈ��


            '**************************************
            '���Ɋ�������
            '**************************************
            Call HanteiInEnd(objTSTS_EQ_CTRL)


            '**************************************
            '�o�Ɋ�������
            '**************************************
            Call HanteiOutEnd(objTSTS_EQ_CTRL)


            '**************************************
            '�o�ɔ�����������
            '**************************************
            Call HanteiOutTrnsEnd(objTSTS_EQ_CTRL)


            '**************************************
            '�ύ���������
            '**************************************
            Call HanteiTumiEnd(objTSTS_EQ_CTRL)


            '**************************************
            '���ɔ������ׯ�ݸނ̉��
            '**************************************
            Call HanteiInTrnsKaihou(objTSTS_EQ_CTRL)


            '**************************************
            '�װ���ނ�ݔ��ُ�۸ނɓo�^
            '**************************************
            Call InsertTLOG_EQ_ERROR_ErrorCode(objTLIF_TRNS_RECV, objTSTS_EQ_CTRL)


            '****************************************************************************
            'D45�o�ɗv�������ޏo�ɐݒ���(D45)ð��قɍX�V
            '****************************************************************************
            Call UpdateXSTS_WRAPPING_MATERIAL_D45(objTLIF_TRNS_RECV, objTSTS_EQ_CTRL)

            '������������************************************************************************************************************
            'JobMate:YAMAMOTO 2017/04/11 1F��ޏo�ɑΉ� ������������
            '****************************************************************************
            '1F�o�ɗv�������ޏo�ɐݒ���(1F)ð��قɍX�V
            '****************************************************************************
            Call UpdateXSTS_WRAPPING_MATERIAL_1F(objTLIF_TRNS_RECV, objTSTS_EQ_CTRL)
            'JobMate:YAMAMOTO 2017/04/111F��ޏo�ɑΉ� ������������
            '������������************************************************************************************************************




            '****************************************************************************
            '�ׯ�۰��Ӱ��ظ��ď����A�ׯ�۰��Ӱ�ގ�M��������
            '****************************************************************************
            Call UpdateLoaderModeON(objTSTS_EQ_CTRL)
            Call UpdateLoaderModeOFF(objTSTS_EQ_CTRL)


            '**************************************
            '�v�����ؾ��
            '**************************************
            If Mid(objTSTS_EQ_CTRL.FEQ_ID, 1, 8) = "JOTHMFF_" Then
                '(MELSEC�̏ꍇ)
                objTSTS_EQ_CTRL.FEQ_REQ_STS = FEQ_REQ_STS_SOFF              '�v�����
                objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()                       '�X�V
            End If


            '������������************************************************************************************************************


            '������������************************************************************************************************************
            'JobMate:S.Ouchi 2015/07/15 CW6�ǉ��Ή� ������������
            If objTLIF_TRNS_RECV.FEQ_ID = FEQ_ID_JSYS0007 Then
                Call CW6_Status_Change(objTLIF_TRNS_RECV, objTSTS_EQ_CTRL)
            End If
            'JobMate:S.Ouchi 2015/07/15 CW6�ǉ��Ή� ������������
            '������������************************************************************************************************************


            Select Case objTSTS_EQ_CTRL.FEQ_ID
                Case FEQ_ID_JOTHY05_X048501 _
                   , FEQ_ID_JOTHY05_X048502 _
                   , FEQ_ID_JOTHY05_X048503 _
                   , FEQ_ID_JOTHY05_X048504 _
                   , FEQ_ID_JOTHY05_X048505 _
                   , FEQ_ID_JOTHY05_X048506 _
                   , FEQ_ID_JOTHY05_X048507 _
                   , FEQ_ID_JOTHY05_X048508 _
                   , FEQ_ID_JOTHY05_X048509 _
                   , FEQ_ID_JOTHY05_X048510 _
                   , FEQ_ID_JOTHY05_X048511 _
                   , FEQ_ID_JOTHY05_X048512 _
                   , FEQ_ID_JOTHY05_X048513 _
                   , FEQ_ID_JOTHY05_X048514
                Case Else
                    '(�܂��ݔ��ُ�۸ނ��o�͂��Ă��Ȃ��ꍇ)


                    '************************
                    '�ݔ���~�v��Ͻ��̓���
                    '************************
                    Dim intErrCount As Integer
                    Dim objTMST_EQ_ERROR_Now As New TBL_TMST_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '�ݔ���~�v��Ͻ�
                    objTMST_EQ_ERROR_Now.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '�ݔ�ID
                    objTMST_EQ_ERROR_Now.FEQ_STS = objTLIF_TRNS_RECV.FDENBUN_PRM2                   '�ݔ����
                    intErrCount = objTMST_EQ_ERROR_Now.GET_TMST_EQ_ERROR_COUNT()                    '����
                    If 1 <= intErrCount Then
                        '(�ُ� �̏ꍇ)

                        '====================
                        '�ݔ��ُ�۸ޓo�^
                        '====================
                        Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '�ݔ��ُ�۸�
                        objTLOG_EQ_ERROR.FHASSEI_DT = objTLIF_TRNS_RECV.FENTRY_DT                   '��������
                        objTLOG_EQ_ERROR.FHUKKI_DT = DEFAULT_DATE                                   '��������
                        objTLOG_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '�ݔ�ID
                        objTLOG_EQ_ERROR.FEQ_STS = objTLIF_TRNS_RECV.FDENBUN_PRM2                   '�ݔ����
                        objTLOG_EQ_ERROR.FEQ_STOP_CD = objTLIF_TRNS_RECV.FDENBUN_PRM3               '��~����
                        objTLOG_EQ_ERROR.ADD_TLOG_EQ_ERROR_SEQ()                                    '�o�^

                        '====================
                        'ү���ޗ�����������
                        '====================
                        Call AddToMsgLog(Now, FMSG_ID_S0104, "[�ݔ�����:" & objTSTS_EQ_CTRL.FEQ_NAME & "]")

                    Else
                        '(���� �̏ꍇ)

                        '====================
                        '�ݔ��ُ�۸ލX�V
                        '====================
                        Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '�ݔ��ُ�۸�
                        objTLOG_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '�ݔ�ID
                        objTLOG_EQ_ERROR.FHUKKI_DT = objTLIF_TRNS_RECV.FENTRY_DT                    '��������
                        objTLOG_EQ_ERROR.UPDATE_TLOG_EQ_ERROR_FEQ_ID()                              '�o�^

                    End If


            End Select


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/08/18 ���ꏈ��


            '**************************************
            '۰�وُ�����(JOTHMFF_D000104_12)�X�V
            '**************************************
            Call UpdateLocalErrLamp(objTSTS_EQ_CTRL)


            '������������************************************************************************************************************


            If Not ( _
                       objTSTS_EQ_CTRL.XEVENT_LOG_KUBUN = XEVENT_LOG_KUBUN_TRK_RTN01 _
                    Or objTSTS_EQ_CTRL.XEVENT_LOG_KUBUN = XEVENT_LOG_KUBUN_TRK_RTN02 _
                    ) Then
                '(RTN�ׯ�ݸފ֌W����Ȃ��ꍇ)


                '************************
                '�������N��
                '************************
                If Mid(objTSTS_EQ_CTRL.FEQ_ID_LOCAL, 1, 1) = "Y" Then
                    '(����PLC�̏ꍇ)
                    objTPRG_TIMER.KIDOU_ON(FSYORI_ID_J310101)       '�N��
                End If


                '************************
                '���튮��
                '************************
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL)


            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
            'Return RetCode.NG
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
            'Return RetCode.NG
        End Try
    End Function
#End Region
#Region "  �ėp���������(Ӱ�ސ؂�ւ���ѱ�ď���)                                               "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ėp���������(Ӱ�ސ؂�ւ���ѱ�ď���)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function ProcessTimer01() As RetCode
        Dim intRet As RetCode                   '�߂�l
        Dim strMsg As String                    'ү����
        Try


            '************************
            '�ݔ��󋵂̓���
            '************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            objTSTS_EQ_CTRL.FEQ_KUBUN = FEQ_KUBUN_SMOD                          '�ݔ��敪
            objTSTS_EQ_CTRL.FEQ_REQ_STS = FEQ_REQ_STS_SMODE_ON                  '�v�����
            intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL_ANY()                     '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                Return RetCode.OK
            End If


            For ii As Integer = LBound(objTSTS_EQ_CTRL.ARYME) To UBound(objTSTS_EQ_CTRL.ARYME)
                '(ٰ��:Ӱ�ސؑ֒���ں��ސ�)


                '************************
                '��ѱ������
                '************************
                Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)
                If CDate(objTSTS_EQ_CTRL.ARYME(ii).FUPDATE_DT).AddSeconds(objTPRG_SYS_HEN.SS000000_007) <= Now Then
                    '(��ѱ�Ă̏ꍇ)

                    '************************
                    '�ݔ��󋵂̍X�V
                    '************************
                    objTSTS_EQ_CTRL.ARYME(ii).FEQ_REQ_STS = FEQ_REQ_STS_SOFF   '�ݔ����
                    objTSTS_EQ_CTRL.ARYME(ii).FUPDATE_DT = Now                '�X�V����
                    objTSTS_EQ_CTRL.ARYME(ii).UPDATE_TSTS_EQ_CTRL()           '�X�V

                    '************************
                    'ү����۸ޒǉ�
                    '************************
                    strMsg = "Ӱ�ސ؂�ւ���ѱ��[�ð���:" & objTSTS_EQ_CTRL.ARYME(ii).FEQ_NAME & "]"
                    Select Case objTSTS_EQ_CTRL.ARYME(ii).FEQ_ID
                        'Case FEQ_ID_JMOD0165, FEQ_ID_JMOD0170, FEQ_ID_JMOD0184, FEQ_ID_JMOD0186 : Call AddToMsgLog(Now, FMSG_ID_J6303, strMsg)
                        Case Else : Call AddToMsgLog(Now, FMSG_ID_J6303, strMsg)
                    End Select

                End If

            Next


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Function
#End Region

    '�ڰݏ�ԍX�V
#Region "  �ڰݏ�ԍX�V����                                                                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ڰݏ�ԍX�V����
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">���������MIFð��ٸ׽</param>
    ''' <param name="objTPRG_TRK_BUF_RELAY">�ړ����ׯ�ݸ��ޯ̧</param>
    ''' <param name="strFCOMP_KUBUN">�ُ���</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateXSTS_CRANEProcess(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                                      , ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                                      , ByVal strFCOMP_KUBUN As String _
                                      )
        'Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try
            If IsNull(objTPRG_TRK_BUF_RELAY) Then Exit Sub


            '************************
            '�ݔ���       �擾
            '************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL, objTPRG_TRK_BUF_RELAY.FEQ_ID)


            '************************
            '�F�X����
            '************************
            Select Case strFCOMP_KUBUN
                Case FCOMP_KUBUN_SNIJUU
                    Call AddToMsgLog(Now, FMSG_ID_S0103, objTSTS_EQ_CTRL.FEQ_NAME)
                Case FCOMP_KUBUN_SKARA
                    Call AddToMsgLog(Now, FMSG_ID_S0105, objTSTS_EQ_CTRL.FEQ_NAME)
                    'Case Else
                    '    Exit Sub
            End Select


            '************************
            '�ڰݏ�ԍX�V
            '************************
            '�擾
            Dim objTSTS_CRANE As New TBL_TSTS_CRANE(Owner, ObjDb, ObjDbLog)
            objTSTS_CRANE.FEQ_ID = objTPRG_TRK_BUF_RELAY.FEQ_ID '�ݔ�ID
            objTSTS_CRANE.GET_TSTS_CRANE()                      '����
            '�X�V
            objTSTS_CRANE.FCOMP_KUBUN = TO_INTEGER_NULLABLE(strFCOMP_KUBUN)      '�����敪
            objTSTS_CRANE.FDENBUN = objTLIF_TRNS_RECV.FDENBUN       '�ʐM�d��
            objTSTS_CRANE.FUPDATE_DT = Now                          '�X�V����
            objTSTS_CRANE.UPDATE_TSTS_CRANE()                       '�X�V


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region


    '�ݔ��󋵁A�ݔ��ُ�۸ނ̍X�V
#Region "  �ݔ��󋵁A�ݔ��ُ�۸ނ̍X�V                                                          "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ݔ��󋵁A�ݔ��ُ�۸ނ̍X�V
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">���������MIFð��ٸ׽</param>
    ''' <param name="strFEQ_ID">�ݔ�ID</param>
    ''' <param name="strFEQ_STS">�ݔ����</param>
    ''' <param name="strFEQ_STOP_CD">��~�v������</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateTSTS_EQ_CTRL_TLOG_EQ_ERRORProcess(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                                                      , ByVal strFEQ_ID As String _
                                                      , ByVal strFEQ_STS As String _
                                                      , ByVal strFEQ_STOP_CD As String _
                                                        )
        'Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            '************************
            '�ݔ��󋵂̓���
            '************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID      '�ݔ�ID
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()      '�擾
            If TO_STRING(objTSTS_EQ_CTRL.FEQ_STS) = TO_STRING(strFEQ_STS) And TO_STRING(objTSTS_EQ_CTRL.FEQ_STOP_CD) = TO_STRING(strFEQ_STOP_CD) Then
                '(�ω����Ȃ��ꍇ)
                Exit Sub
            End If


            '************************
            '�ݔ���Ԃ̍X�V
            '************************
            objTSTS_EQ_CTRL.FEQ_STS = strFEQ_STS            '�ݔ����
            objTSTS_EQ_CTRL.FEQ_STOP_CD = strFEQ_STOP_CD    '��~�v������
            objTSTS_EQ_CTRL.FUPDATE_DT = Now                '�X�V����
            objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()           '�X�V


            '************************
            '�ݔ���~�v��Ͻ��̓���
            '************************
            Dim intErrCount As Integer
            Dim objTMST_EQ_STOP As New TBL_TMST_EQ_STOP(Owner, ObjDb, ObjDbLog)       '�ݔ���~�v��Ͻ�
            objTMST_EQ_STOP.FEQ_STOP_KUBUN = objTSTS_EQ_CTRL.FEQ_STOP_KUBUN           '�ݔ���~�v���敪
            objTMST_EQ_STOP.FEQ_STS = strFEQ_STS                                      '�ݔ����
            intErrCount = objTMST_EQ_STOP.GET_TMST_EQ_STOP_COUNT()                    '����
            If 1 <= intErrCount Then
                '(�ُ� �̏ꍇ)

                '====================
                '�ݔ��ُ�۸ޓo�^
                '====================
                Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '�ݔ��ُ�۸�
                objTLOG_EQ_ERROR.FHASSEI_DT = objTLIF_TRNS_RECV.FENTRY_DT                   '��������
                objTLOG_EQ_ERROR.FHUKKI_DT = DEFAULT_DATE                                   '��������
                objTLOG_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '�ݔ�ID
                objTLOG_EQ_ERROR.FEQ_STS = objTSTS_EQ_CTRL.FEQ_STS                          '�ݔ����
                objTLOG_EQ_ERROR.FEQ_STOP_CD = objTSTS_EQ_CTRL.FEQ_STOP_CD                  '��~�v������
                objTLOG_EQ_ERROR.ADD_TLOG_EQ_ERROR_SEQ()                                    '�o�^

                '====================
                'ү���ޗ�����������
                '====================
                Call AddToMsgLog(Now, FMSG_ID_S0104, "[�ݔ�����:" & objTSTS_EQ_CTRL.FEQ_NAME & "]")

            Else
                '(���� �̏ꍇ)

                '====================
                '�ݔ��ُ�۸ލX�V
                '====================
                Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '�ݔ��ُ�۸�
                objTLOG_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '�ݔ�ID
                objTLOG_EQ_ERROR.FHUKKI_DT = objTLIF_TRNS_RECV.FENTRY_DT                    '��������
                objTLOG_EQ_ERROR.UPDATE_TLOG_EQ_ERROR_FEQ_ID()                              '�o�^

            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region


    'PLC�n
#Region "  ���Ɋ�������                                                                         "
    '''**********************************************************************************************
    ''' <summary>
    ''' ���Ɋ�������
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub HanteiInEnd(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            '**************************************
            '����
            '**************************************
            If objTSTS_EQ_CTRL.FEQ_STS = FLAG_ON Then Exit Sub


            '**************************************
            '�ׯ�ݸ��ޯ̧Ͻ�        �擾
            '**************************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.XEQ_ID_IRI_YOUKYU = objTSTS_EQ_CTRL.FEQ_ID      '���I���ɗv���ݔ�ID
            intRet = objTMST_TRK.GET_TMST_TRK(False)                    '�擾
            If intRet = RetCode.OK Then
                '(�������� or ���Ɋ��� �̏ꍇ)


                '**************************************
                '�ׯ�ݸ��ޯ̧           �擾
                '**************************************
                Dim objTPRG_TRK_BUF_RELAY01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                Select Case objTMST_TRK.XLS_NO
                    Case XLS_NO_1F : objTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3101    '�ׯ�ݸ��ޯ̧��
                    Case XLS_NO_2F : objTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3102    '�ׯ�ݸ��ޯ̧��
                End Select
                objTPRG_TRK_BUF_RELAY01.FTR_FM = objTMST_TRK.FTRK_BUF_NO        '����FM�ׯ�ݸ��ޯ̧��
                intRet = objTPRG_TRK_BUF_RELAY01.GET_TPRG_TRK_BUF_FIFO()        '�擾
                If intRet = RetCode.OK Then
                    '(���������ꍇ)


                    '**************************************
                    '�����w��QUE        �擾
                    '**************************************
                    Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                    objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID       '��گ�ID
                    objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                                  '�擾


                    '**************************************
                    '���Ɋ���(1��گĖ�)
                    '**************************************
                    Dim objSVR_010102_01 As New SVR_010102(Owner, ObjDb, ObjDbLog)
                    objSVR_010102_01.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID   '��گ�ID
                    objSVR_010102_01.FINOUT_STS = FINOUT_STS_SIN_END                   'IN/OUT
                    Call objSVR_010102_01.ExecCmdFunction()


                    '**************************************
                    '���Ɋ���(2��گĖ�)
                    '**************************************
                    If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                        Dim objSVR_010102_02 As New SVR_010102(Owner, ObjDb, ObjDbLog)
                        objSVR_010102_02.FPALLET_ID = objTPLN_CARRY_QUE.XPALLET_ID_AITE    '��گ�ID
                        objSVR_010102_02.FINOUT_STS = FINOUT_STS_SIN_END                   'IN/OUT
                        Call objSVR_010102_02.ExecCmdFunction()
                    End If


                End If


            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  ���Ɋ�������_PLC�ׯ�ݸނ����������ް�ޮ�(���̂��A2013/09/22�ɋ}篑Ή����Ȃ��Ȃ��Ă��܂����B)         "
    ''''**********************************************************************************************
    '''' <summary>
    '''' ���Ɋ�������
    '''' </summary>
    '''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽</param>
    '''' <remarks></remarks>
    ''''**********************************************************************************************
    'Private Sub HanteiInEnd(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
    '    Dim intRet As RetCode                   '�߂�l
    '    'Dim strMsg As String                    'ү����
    '    Try


    '        ''**************************************
    '        ''����
    '        ''**************************************
    '        'If objTSTS_EQ_CTRL.FEQ_STS = FLAG_ON Then Exit Sub


    '        '**************************************
    '        '�ׯ�ݸ��ޯ̧Ͻ�        �擾
    '        '**************************************
    '        Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
    '        objTMST_TRK.XEQ_ID_IRI_YOUKYU = objTSTS_EQ_CTRL.FEQ_ID      '���I���ɗv���ݔ�ID
    '        intRet = objTMST_TRK.GET_TMST_TRK(False)                    '�擾
    '        If intRet <> RetCode.OK Then
    '            '(������Ȃ��ꍇ)
    '            objTMST_TRK.CLEAR_PROPERTY()
    '            objTMST_TRK.WHERE = "   AND ("                                                                          'PLC�ׯ�ݸޱ��ڽ01
    '            objTMST_TRK.WHERE &= "           INSTR( XADRS_PLCTRK05, '" & objTSTS_EQ_CTRL.FEQ_ID & "' ) > 0"         'PLC�ׯ�ݸޱ��ڽ01
    '            objTMST_TRK.WHERE &= "       OR  INSTR( XADRS_PLCTRK04, '" & objTSTS_EQ_CTRL.FEQ_ID & "' ) > 0"         'PLC�ׯ�ݸޱ��ڽ01
    '            objTMST_TRK.WHERE &= "       ) "                                                                        'PLC�ׯ�ݸޱ��ڽ01
    '            intRet = objTMST_TRK.GET_TMST_TRK(False)                    '�擾
    '        End If
    '        If intRet = RetCode.OK Then
    '            '(�������� or ���Ɋ��� �̏ꍇ)


    '            '**************************************
    '            '�ׯ�ݸ��ޯ̧(1PL��)        �擾
    '            '**************************************
    '            Dim objTPRG_TRK_BUF_RELAY01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '            Select Case objTMST_TRK.XLS_NO
    '                Case XLS_NO_1F : objTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3101    '�ׯ�ݸ��ޯ̧��
    '                Case XLS_NO_2F : objTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3102    '�ׯ�ݸ��ޯ̧��
    '            End Select
    '            objTPRG_TRK_BUF_RELAY01.FTR_FM = objTMST_TRK.FTRK_BUF_NO        '����FM�ׯ�ݸ��ޯ̧��
    '            intRet = objTPRG_TRK_BUF_RELAY01.GET_TPRG_TRK_BUF_FIFO()        '�擾
    '            If intRet = RetCode.OK Then
    '                '(���������ꍇ)


    '                '**************************************
    '                '�����w��QUE        �擾
    '                '**************************************
    '                Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
    '                objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID       '��گ�ID
    '                objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                                  '�擾


    '                '**************************************
    '                '�ׯ�ݸ��ޯ̧(1PL�ڑq�ɗ\��)    �擾
    '                '**************************************
    '                Dim objTPRG_TRK_BUF_ASRS01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '                objTPRG_TRK_BUF_ASRS01.FTRK_BUF_NO = FTRK_BUF_NO_J9000                      '�ׯ�ݸ��ޯ̧��
    '                objTPRG_TRK_BUF_ASRS01.FRSV_PALLET = objTPRG_TRK_BUF_RELAY01.FPALLET_ID     '��������گ�ID
    '                objTPRG_TRK_BUF_ASRS01.GET_TPRG_TRK_BUF()                                   '�擾


    '                '**************************************
    '                '�ׯ�ݸ��ޯ̧(2PL��)        �擾
    '                '**************************************
    '                Dim objTPRG_TRK_BUF_ASRS02 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '                If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
    '                    objTPRG_TRK_BUF_ASRS02.FTRK_BUF_NO = FTRK_BUF_NO_J9000                      '�ׯ�ݸ��ޯ̧��
    '                    objTPRG_TRK_BUF_ASRS02.FRSV_PALLET = objTPLN_CARRY_QUE.XPALLET_ID_AITE      '��������گ�ID
    '                    objTPRG_TRK_BUF_ASRS02.GET_TPRG_TRK_BUF()                                   '�擾
    '                End If


    '                '****************************************************************************
    '                'PLC�ׯ�ݸނ��疳���Ȃ���������
    '                '****************************************************************************
    '                '==============================================
    '                '�ݔ���(���Ɏw�����ڽ)    �擾
    '                '�ݔ���(PLC�ׯ�ݸ�01)     �擾
    '                '�ݔ���(PLC�ׯ�ݸ�02)     �擾
    '                '==============================================
    '                Dim strFEQ_ID_XADRS_IN() As String = Split(objTMST_TRK.XADRS_IN, ",")
    '                Dim strFEQ_ID_PLCTRK05() As String = Split(objTMST_TRK.XADRS_PLCTRK05, ",")
    '                Dim strFEQ_ID_PLCTRK04() As String = Split(objTMST_TRK.XADRS_PLCTRK04, ",")
    '                Dim objTSTS_EQ_CTRL_XADRS_IN(UBound(strFEQ_ID_XADRS_IN)) As TBL_TSTS_EQ_CTRL
    '                Dim objTSTS_EQ_CTRL_PLCTRK05(UBound(strFEQ_ID_PLCTRK05)) As TBL_TSTS_EQ_CTRL
    '                Dim objTSTS_EQ_CTRL_PLCTRK04(UBound(strFEQ_ID_PLCTRK04)) As TBL_TSTS_EQ_CTRL
    '                Dim strFEQ_STS_XADRS_IN(UBound(strFEQ_ID_XADRS_IN)) As String       '�ݔ����
    '                Dim strFEQ_STS_PLCTRK05(UBound(strFEQ_ID_PLCTRK05)) As String       '�ݔ����
    '                Dim strFEQ_STS_PLCTRK04(UBound(strFEQ_ID_PLCTRK04)) As String       '�ݔ����
    '                For ii As Integer = 0 To UBound(strFEQ_ID_XADRS_IN)
    '                    '(ٰ��:PLC�ׯ�ݸސ�)
    '                    objTSTS_EQ_CTRL_XADRS_IN(ii) = New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
    '                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_XADRS_IN(ii), strFEQ_ID_XADRS_IN(ii))
    '                    strFEQ_STS_XADRS_IN(ii) = objTSTS_EQ_CTRL_XADRS_IN(ii).FEQ_STS
    '                Next
    '                For ii As Integer = 0 To UBound(strFEQ_ID_PLCTRK05)
    '                    '(ٰ��:PLC�ׯ�ݸސ�)
    '                    objTSTS_EQ_CTRL_PLCTRK05(ii) = New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
    '                    objTSTS_EQ_CTRL_PLCTRK04(ii) = New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
    '                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_PLCTRK05(ii), strFEQ_ID_PLCTRK05(ii))
    '                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_PLCTRK04(ii), strFEQ_ID_PLCTRK04(ii))
    '                    strFEQ_STS_PLCTRK05(ii) = objTSTS_EQ_CTRL_PLCTRK05(ii).FEQ_STS
    '                    strFEQ_STS_PLCTRK04(ii) = objTSTS_EQ_CTRL_PLCTRK04(ii).FEQ_STS
    '                Next

    '                '==============================================
    '                '�ݔ���(���Ɏw�����ڽ)    ����
    '                '�ݔ���(PLC�ׯ�ݸ�01)     ����
    '                '�ݔ���(PLC�ׯ�ݸ�02)     ����
    '                '==============================================
    '                Dim intAryBunkai00() As Integer = Nothing     '�����ް�
    '                Dim intAryBunkai01() As Integer = Nothing     '�����ް�
    '                Dim intAryBunkai02() As Integer = Nothing     '�����ް�
    '                Call GetHansouSiziData(strFEQ_STS_XADRS_IN, intAryBunkai00)
    '                Call GetPLCRTNData(strFEQ_STS_PLCTRK05, intAryBunkai01)
    '                Call GetPLCRTNData(strFEQ_STS_PLCTRK04, intAryBunkai02)

    '                '==============================================
    '                '�ݔ���(���Ɏw�����ڽ)    ����
    '                '==============================================
    '                Dim blnTrkFound As Boolean = False
    '                If objTPRG_TRK_BUF_ASRS01.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai00(HansouSiziArray.Retu_01), intAryBunkai00(HansouSiziArray.Gouki_01), False) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_REN = intAryBunkai00(HansouSiziArray.Ren_01) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_DAN = intAryBunkai00(HansouSiziArray.Dan_01) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_EDA = intAryBunkai00(HansouSiziArray.DoubleReach_01) _
    '                   Then
    '                    '(��v�����ׯ�ݸނ����������ꍇ)
    '                    blnTrkFound = True
    '                End If
    '                If objTPRG_TRK_BUF_ASRS01.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai00(HansouSiziArray.Retu_02), intAryBunkai00(HansouSiziArray.Gouki_02), False) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_REN = intAryBunkai00(HansouSiziArray.Ren_02) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_DAN = intAryBunkai00(HansouSiziArray.Dan_02) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_EDA = intAryBunkai00(HansouSiziArray.DoubleReach_02) _
    '                   Then
    '                    '(��v�����ׯ�ݸނ����������ꍇ)
    '                    blnTrkFound = True
    '                End If
    '                If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
    '                    '(2PL�ڂ����݂��Ă���ꍇ)
    '                    If objTPRG_TRK_BUF_ASRS02.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai00(HansouSiziArray.Retu_01), intAryBunkai00(HansouSiziArray.Gouki_01), False) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_REN = intAryBunkai00(HansouSiziArray.Ren_01) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_DAN = intAryBunkai00(HansouSiziArray.Dan_01) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_EDA = intAryBunkai00(HansouSiziArray.DoubleReach_01) _
    '                       Then
    '                        '(��v�����ׯ�ݸނ����������ꍇ)
    '                        blnTrkFound = True
    '                    End If
    '                    If objTPRG_TRK_BUF_ASRS02.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai00(HansouSiziArray.Retu_02), intAryBunkai00(HansouSiziArray.Gouki_02), False) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_REN = intAryBunkai00(HansouSiziArray.Ren_02) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_DAN = intAryBunkai00(HansouSiziArray.Dan_02) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_EDA = intAryBunkai00(HansouSiziArray.DoubleReach_02) _
    '                       Then
    '                        '(��v�����ׯ�ݸނ����������ꍇ)
    '                        blnTrkFound = True
    '                    End If
    '                End If

    '                '==============================================
    '                '�ݔ���(PLC�ׯ�ݸ�)       ����
    '                '==============================================
    '                If objTPRG_TRK_BUF_ASRS01.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai01(RTNSiziArray.Retu), intAryBunkai01(RTNSiziArray.Gouki), False) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_REN = intAryBunkai01(RTNSiziArray.Ren) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_DAN = intAryBunkai01(RTNSiziArray.Dan) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_EDA = intAryBunkai01(RTNSiziArray.DoubleReach) _
    '                   Then
    '                    '(��v�����ׯ�ݸނ����������ꍇ)
    '                    blnTrkFound = True
    '                End If
    '                If objTPRG_TRK_BUF_ASRS01.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai02(RTNSiziArray.Retu), intAryBunkai02(RTNSiziArray.Gouki), False) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_REN = intAryBunkai02(RTNSiziArray.Ren) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_DAN = intAryBunkai02(RTNSiziArray.Dan) _
    '                   And objTPRG_TRK_BUF_ASRS01.FRAC_EDA = intAryBunkai02(RTNSiziArray.DoubleReach) _
    '                   Then
    '                    '(��v�����ׯ�ݸނ����������ꍇ)
    '                    blnTrkFound = True
    '                End If
    '                If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
    '                    '(2PL�ڂ����݂��Ă���ꍇ)
    '                    If objTPRG_TRK_BUF_ASRS02.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai01(RTNSiziArray.Retu), intAryBunkai01(RTNSiziArray.Gouki), False) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_REN = intAryBunkai01(RTNSiziArray.Ren) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_DAN = intAryBunkai01(RTNSiziArray.Dan) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_EDA = intAryBunkai01(RTNSiziArray.DoubleReach) _
    '                       Then
    '                        '(��v�����ׯ�ݸނ����������ꍇ)
    '                        blnTrkFound = True
    '                    End If
    '                    If objTPRG_TRK_BUF_ASRS02.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryBunkai02(RTNSiziArray.Retu), intAryBunkai02(RTNSiziArray.Gouki), False) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_REN = intAryBunkai02(RTNSiziArray.Ren) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_DAN = intAryBunkai02(RTNSiziArray.Dan) _
    '                       And objTPRG_TRK_BUF_ASRS02.FRAC_EDA = intAryBunkai02(RTNSiziArray.DoubleReach) _
    '                       Then
    '                        '(��v�����ׯ�ݸނ����������ꍇ)
    '                        blnTrkFound = True
    '                    End If
    '                End If


    '                If blnTrkFound = False Then
    '                    '(PLC���ɓ��ɒ��ׯ�ݸނ�������Ȃ�������)


    '                    '**************************************
    '                    '���Ɋ���(1��گĖ�)
    '                    '**************************************
    '                    Dim objSVR_010102_01 As New SVR_010102(Owner, ObjDb, ObjDbLog)
    '                    objSVR_010102_01.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID   '��گ�ID
    '                    objSVR_010102_01.FINOUT_STS = FINOUT_STS_SIN_END                   'IN/OUT
    '                    Call objSVR_010102_01.ExecCmdFunction()


    '                    '**************************************
    '                    '���Ɋ���(2��گĖ�)
    '                    '**************************************
    '                    If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
    '                        Dim objSVR_010102_02 As New SVR_010102(Owner, ObjDb, ObjDbLog)
    '                        objSVR_010102_02.FPALLET_ID = objTPLN_CARRY_QUE.XPALLET_ID_AITE    '��گ�ID
    '                        objSVR_010102_02.FINOUT_STS = FINOUT_STS_SIN_END                   'IN/OUT
    '                        Call objSVR_010102_02.ExecCmdFunction()
    '                    End If


    '                End If


    '            End If


    '        End If


    '    Catch ex As UserException
    '        Call ComUser(ex, MeSyoriID)
    '        Throw New UserException(ex.Message)
    '    Catch ex As Exception
    '        Call ComError(ex, MeSyoriID)
    '        Throw New Exception(ex.Message)
    '    End Try
    'End Sub
#End Region
#Region "  �o�Ɋ�������                                                                         "
    '''**********************************************************************************************
    ''' <summary>
    ''' �o�Ɋ�������
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub HanteiOutEnd(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            '**************************************
            '����
            '**************************************
            If objTSTS_EQ_CTRL.FEQ_STS = FLAG_OFF Then Exit Sub


            '**************************************
            '�ׯ�ݸ��ޯ̧Ͻ�        �擾
            '**************************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.XEQ_ID_OUT_BUF = objTSTS_EQ_CTRL.FEQ_ID         '�o�I�ޯ̧��ݔ�ID
            intRet = objTMST_TRK.GET_TMST_TRK(False)                    '�擾
            If intRet = RetCode.OK Then
                '(�o�Ɋ����̏ꍇ)


                '**************************************
                '�ׯ�ݸ��ޯ̧           �擾
                '**************************************
                Dim objTPRG_TRK_BUF_RELAY01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                Select Case objTMST_TRK.XLS_NO
                    Case XLS_NO_1F : objTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3201    '�ׯ�ݸ��ޯ̧��
                    Case XLS_NO_2F : objTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3202    '�ׯ�ݸ��ޯ̧��
                End Select
                objTPRG_TRK_BUF_RELAY01.FRSV_BUF_TO = objTMST_TRK.FTRK_BUF_NO   'TO�����ׯ�ݸ��ޯ̧��
                intRet = objTPRG_TRK_BUF_RELAY01.GET_TPRG_TRK_BUF_FIFO()        '�擾
                If intRet = RetCode.OK Then
                    '(���������ꍇ)


                    '**************************************
                    '�����w��QUE        �擾
                    '**************************************
                    Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                    objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID       '��گ�ID
                    objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                                  '�擾


                    '**************************************
                    '�o�Ɋ���(1��گĖ�)
                    '**************************************
                    Dim objSVR_010202_01 As New SVR_010202(Owner, ObjDb, ObjDbLog)
                    objSVR_010202_01.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID   '��گ�ID
                    objSVR_010202_01.FINOUT_STS = FINOUT_STS_SOUT_END                  'IN/OUT
                    Call objSVR_010202_01.ExecCmdFunction()


                    '**************************************
                    '�o�Ɋ���(2��گĖ�)
                    '**************************************
                    If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                        Dim objSVR_010202_02 As New SVR_010202(Owner, ObjDb, ObjDbLog)
                        objSVR_010202_02.FPALLET_ID = objTPLN_CARRY_QUE.XPALLET_ID_AITE    '��گ�ID
                        objSVR_010202_02.FINOUT_STS = FINOUT_STS_SOUT_END                  'IN/OUT
                        Call objSVR_010202_02.ExecCmdFunction()
                    End If


                End If


            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  �o�ɔ�����������                                                                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' �o�ɔ�����������
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub HanteiOutTrnsEnd(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            '**************************************
            '����
            '**************************************
            If objTSTS_EQ_CTRL.FEQ_STS = FLAG_OFF Then Exit Sub


            '****************************************************************************
            '****************************************************************************
            'ٰ��01
            '�o�ɐ�ST��
            '****************************************************************************
            '****************************************************************************
            '**************************************
            '�ׯ�ݸ��ޯ̧Ͻ�        �擾
            '**************************************
            Dim objAryTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objAryTMST_TRK.XEQ_ID_OUT_END = objTSTS_EQ_CTRL.FEQ_ID      '�o�Ɋ����ݔ�ID
            intRet = objAryTMST_TRK.GET_TMST_TRK_ANY                    '�擾
            If intRet = RetCode.OK Then
                '(�o�ɔ��������̏ꍇ)
                For Each objTMST_TRK As TBL_TMST_TRK In objAryTMST_TRK.ARYME
                    '(ٰ��:�Y�������ׯ�ݸ��ޯ̧��)


                    '****************************************************************************
                    '****************************************************************************
                    'ٰ��02
                    '�o�ɔ������ׯ�ݸސ�
                    '****************************************************************************
                    '****************************************************************************
                    '**************************************
                    '�ׯ�ݸ��ޯ̧(�o�ɔ�����)       �擾
                    '**************************************
                    Dim intCountEnd As Integer = 0
                    Dim objAryTPRG_TRK_BUF_RELAY01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    Select Case objTMST_TRK.XLS_NO
                        Case XLS_NO_1F : objAryTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3401    '�ׯ�ݸ��ޯ̧��
                        Case XLS_NO_2F : objAryTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3402    '�ׯ�ݸ��ޯ̧��
                    End Select
                    objAryTPRG_TRK_BUF_RELAY01.FTR_TO = objTMST_TRK.FTRK_BUF_NO        '����TO�ׯ�ݸ��ޯ̧��
                    intRet = objAryTPRG_TRK_BUF_RELAY01.GET_TPRG_TRK_BUF_FIFO(True)    '�擾
                    If intRet = RetCode.OK Then
                        '(���������ꍇ)
                        For Each objTPRG_TRK_BUF_RELAY01 As TBL_TPRG_TRK_BUF In objAryTPRG_TRK_BUF_RELAY01.ARYME
                            '(ٰ��:���������ׯ�ݸސ�)


                            '**************************************
                            '��������
                            '**************************************
                            Dim objSVR_010302_01 As New SVR_010302(Owner, ObjDb, ObjDbLog)
                            objSVR_010302_01.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID   '��گ�ID
                            objSVR_010302_01.FINOUT_STS = FINOUT_STS_SRELAY_END                'IN/OUT
                            Call objSVR_010302_01.ExecCmdFunction()


                            intCountEnd += 1
                        Next
                    End If


                    '**************************************
                    '�����\�萔         ���M
                    '�����\�萔��ؾ��
                    '�\�萔����
                    '**************************************
                    If IsNotNull(objTMST_TRK.XADRS_YOTEI01) Then
                        '(�\�萔������ꍇ)


                        '**************************************
                        '�\�萔����
                        '**************************************
                        If IsNull(objTMST_TRK.XADRS_YOTEI02) Then
                            '(�ׯ�۰�ނ���Ȃ��ꍇ)

                            '===================================
                            '�\�萔�擾
                            '===================================
                            Dim objTSTS_EQ_CTRL_YOTEI01 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_YOTEI01, objTMST_TRK.XADRS_YOTEI01)

                            '===================================
                            'ү����۸�      �o��
                            '===================================
                            If intCountEnd <> TO_INTEGER(objTSTS_EQ_CTRL_YOTEI01.FEQ_STS) Then
                                Call AddToMsgLog(Now, FMSG_ID_J4002, "�ׯ�ݸ��ް����m�F���āA�����������̑�����s���ĉ������B" _
                                                                   , "[�o�ɔ�����:" & objTMST_TRK.FBUF_NAME & "][�\�萔:" & objTSTS_EQ_CTRL_YOTEI01.FEQ_STS & "][�o�ɔ���������:" & intCountEnd & "]" _
                                                                   )
                            End If

                            '�f��������������������������������������������������������������������������
                            '�f2017/08/26 ���n�C���@���Z�����Ƃ��ɌÂ�DB�̒l���c�邽�ߎ��O��DB���X�V����
                            '' ���\�萔�N���A��DB���X�V����悤�ɕύX                                      
                            '�fD81-85�@�@2909 
                            '' D45  2037
                            '' C01-C04
                            'Dim blnReset As Boolean = False
                            'Select Case objTMST_TRK.FTRK_BUF_NO
                            '    Case 2909, 2908, 2907, 2906, 2905 '�fD81-85�@
                            '        blnReset = True
                            '    Case 2037   '' D45  2037
                            '        blnReset = True
                            '    Case 1171, 1172, 1173, 1174 '' C01-C04
                            '        blnReset = True
                            'End Select

                            'If blnReset Then
                            '    objTSTS_EQ_CTRL_YOTEI01.FEQ_STS = 0
                            '    objTSTS_EQ_CTRL_YOTEI01.UPDATE_TSTS_EQ_CTRL()
                            'End If
                            '�f������������������������������������������������������������������������������

                        End If



                        '**************************************
                        '�����\�萔         ���M
                        '�����\�萔��ؾ��
                        '**************************************
                        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                        objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         '�����ID
                        objSVR_190001.FPALLET_ID = ""                                   '��گ�ID
                        objSVR_190001.FTRNS_SERIAL = ""                                 '�����ره�
                        Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK.FTRK_BUF_NO _
                                                              , 0 _
                                                              , 0 _
                        )




                    End If


                    ' '' ''**************************************
                    ' '' ''�ׯ�ݸ��ޯ̧(��������o�ɒ�)   �擾
                    ' '' ''**************************************
                    '' ''Dim intCountOut As Integer = 0      '�܂��o�ɔ����������Ă��Ȃ��ׯ�ݸސ�
                    '' ''Dim objAryTPRG_TRK_BUF_RELAY02 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    '' ''objAryTPRG_TRK_BUF_RELAY02.FTR_TO = objTMST_TRK.FTRK_BUF_NO        '����TO�ׯ�ݸ��ޯ̧��
                    '' ''intRet = objAryTPRG_TRK_BUF_RELAY02.GET_TPRG_TRK_BUF_FIFO(True)    '�擾
                    '' ''If intRet = RetCode.OK Then
                    '' ''    '(���������ꍇ)
                    '' ''    For Each objTPRG_TRK_BUF_RELAY02 As TBL_TPRG_TRK_BUF In objAryTPRG_TRK_BUF_RELAY02.ARYME
                    '' ''        '(ٰ��:���������ׯ�ݸސ�)


                    '' ''        '**************************************
                    '' ''        '��������
                    '' ''        '**************************************
                    '' ''        Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                    '' ''        objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_RELAY02.FPALLET_ID   '��گ�ID
                    '' ''        intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)                '�擾
                    '' ''        If intRet = RetCode.OK Then
                    '' ''            '(���������ꍇ)
                    '' ''            If objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS <> FCARRYQUE_DIR_STS_JTAIKI Then
                    '' ''                '(�ҋ@��ԈȊO�̏ꍇ)
                    '' ''                intCountOut += 1
                    '' ''            End If
                    '' ''        End If


                    '' ''    Next
                    '' ''End If


                    ' '' ''**************************************
                    ' '' ''�����\�萔         ���M
                    ' '' ''**************************************
                    '' ''If 0 < intCountOut Then
                    '' ''    '(�o�ɔ����������Ă��Ȃ��ׯ�ݸނ��������ꍇ)
                    '' ''    If IsNotNull(objTMST_TRK.XADRS_YOTEI01) Then
                    '' ''        '(�\�萔������ꍇ)
                    '' ''        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                    '' ''        objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         '�����ID
                    '' ''        objSVR_190001.FPALLET_ID = ""                                   '��گ�ID
                    '' ''        objSVR_190001.FTRNS_SERIAL = ""                                 '�����ره�
                    '' ''        Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK.FTRK_BUF_NO _
                    '' ''                                              , 0 _
                    '' ''                                              , 0 _
                    '' ''                                              )
                    '' ''    End If
                    '' ''End If


                Next

            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  �o�ɔ�����������(�ׯ�۰�ޗp)                                                         "
    '''**********************************************************************************************
    ''' <summary>
    ''' �o�ɔ�����������(�ׯ�۰�ޗp)
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽</param>
    ''' <param name="objTLIF_TRNS_RECV">���������MIFð��ٸ׽</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub HanteiOutTrnsEndLoader(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL _
                                     , ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                                     )
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            '**************************************
            '����
            '**************************************
            If objTLIF_TRNS_RECV.FDENBUN_PRM2 = FLAG_OFF Then Exit Sub


            '**************************************
            '�o�ɔ���������         �擾
            '**************************************
            Dim intTrnsEndLoader As Integer = TO_INTEGER(objTLIF_TRNS_RECV.FDENBUN_PRM2) - TO_INTEGER(objTSTS_EQ_CTRL.FEQ_STS)
            If intTrnsEndLoader <= 0 Then Exit Sub


            '****************************************************************************
            '****************************************************************************
            'ٰ��01
            '�o�ɐ�ST��
            '****************************************************************************
            '****************************************************************************
            '**************************************
            '�ׯ�ݸ��ޯ̧Ͻ�        �擾
            '**************************************
            Dim objAryTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objAryTMST_TRK.XADRS_PALLET01 = objTSTS_EQ_CTRL.FEQ_ID      '��گĐ����ڽ01
            intRet = objAryTMST_TRK.GET_TMST_TRK_ANY                    '�擾
            If intRet <> RetCode.OK Then
                '(������Ȃ������ꍇ)
                objAryTMST_TRK.CLEAR_PROPERTY()
                objAryTMST_TRK.XADRS_PALLET02 = objTSTS_EQ_CTRL.FEQ_ID      '��گĐ����ڽ02
                intRet = objAryTMST_TRK.GET_TMST_TRK_ANY                    '�擾
                If intRet <> RetCode.OK Then
                    '(������Ȃ������ꍇ)
                    Exit Sub
                End If
            End If
            'If objAryTMST_TRK.ARYME.Length <= 1 Then Exit Sub
            If IsNull(objAryTMST_TRK.ARYME(0).XADRS_PALLET02) Then
                '(�ׯ�۰�ށAD41�AD42�ȊO�̏ꍇ)
                Exit Sub
            End If


            Dim intCountTrnsEndLoader As Integer = 0        '�o�ɔ��������̶���
            For Each objTMST_TRK As TBL_TMST_TRK In objAryTMST_TRK.ARYME
                '(ٰ��:�Y�������ׯ�ݸ��ޯ̧��)


                '****************************************************************************
                '****************************************************************************
                'ٰ��02
                '�o�ɔ������ׯ�ݸސ�
                '****************************************************************************
                '****************************************************************************
                '**************************************
                '�ׯ�ݸ��ޯ̧           �擾
                '**************************************
                Dim objAryTPRG_TRK_BUF_RELAY01 As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                Select Case objTMST_TRK.XLS_NO
                    Case XLS_NO_1F : objAryTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3401    '�ׯ�ݸ��ޯ̧��
                    Case XLS_NO_2F : objAryTPRG_TRK_BUF_RELAY01.FTRK_BUF_NO = FTRK_BUF_NO_J3402    '�ׯ�ݸ��ޯ̧��
                End Select
                objAryTPRG_TRK_BUF_RELAY01.FTR_TO = objTMST_TRK.FTRK_BUF_NO        '����TO�ׯ�ݸ��ޯ̧��
                intRet = objAryTPRG_TRK_BUF_RELAY01.GET_TPRG_TRK_BUF_FIFO(True)    '�擾
                If intRet = RetCode.OK Then
                    '(���������ꍇ)
                    For Each objTPRG_TRK_BUF_RELAY01 As TBL_TPRG_TRK_BUF In objAryTPRG_TRK_BUF_RELAY01.ARYME
                        '(ٰ��:���������ׯ�ݸސ�)


                        '**************************************
                        '��������
                        '**************************************
                        Dim objSVR_010302_01 As New SVR_010302(Owner, ObjDb, ObjDbLog)
                        objSVR_010302_01.FPALLET_ID = objTPRG_TRK_BUF_RELAY01.FPALLET_ID   '��گ�ID
                        objSVR_010302_01.FINOUT_STS = FINOUT_STS_SRELAY_END                'IN/OUT
                        Call objSVR_010302_01.ExecCmdFunction()


                        '**************************************
                        '�����������鶳��           ����
                        '**************************************
                        intCountTrnsEndLoader += 1
                        If intTrnsEndLoader <= intCountTrnsEndLoader Then Exit For


                    Next
                End If


                If intTrnsEndLoader <= intCountTrnsEndLoader Then Exit For
            Next


            '************************************************
            'ү����۸�              �ǉ�
            '************************************************
            If Not (intTrnsEndLoader <= intCountTrnsEndLoader) Then
                If objTSTS_EQ_CTRL.FEQ_ID = FEQ_ID_JOTHY04_X048405 Or objTSTS_EQ_CTRL.FEQ_ID = FEQ_ID_JOTHY04_X048406 Then
                    Dim strMsg01 As String
                    Dim strMsg02 As String
                    strMsg01 = "D41orD42�̏o�ɔ�����������M���܂������A�o�ɔ��������������ׯ�ݸނ�������܂���ł����B"
                    strMsg02 = "[�ݔ�����:" & objTSTS_EQ_CTRL.FEQ_NAME & "]"
                    strMsg02 &= "[�ݔ�ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]"
                    strMsg02 &= "[��گĐ�:" & objTLIF_TRNS_RECV.FDENBUN_PRM2 & "]"
                    Call AddToMsgLog(Now, FMSG_ID_J4001, strMsg01, strMsg02)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & strMsg01 & strMsg02)
                End If
            End If


            If Not (objTSTS_EQ_CTRL.FEQ_ID = FEQ_ID_JOTHY04_X048405 Or objTSTS_EQ_CTRL.FEQ_ID = FEQ_ID_JOTHY04_X048406) Then
                '(D41�AD42�ȊO�̏ꍇ)


                '************************************************
                '�ݔ���           �擾
                '************************************************
                Dim objTSTS_EQ_CTRL_YOTEI01 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                Dim objTSTS_EQ_CTRL_YOTEI02 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                Dim objTSTS_EQ_CTRL_PALLET01 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                Dim objTSTS_EQ_CTRL_PALLET02 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_YOTEI01, objAryTMST_TRK.ARYME(0).XADRS_YOTEI01)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_YOTEI02, objAryTMST_TRK.ARYME(0).XADRS_YOTEI02)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_PALLET01, objAryTMST_TRK.ARYME(0).XADRS_PALLET01)
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_PALLET02, objAryTMST_TRK.ARYME(0).XADRS_PALLET02)


                Dim intYoteiSum As Integer = TO_INTEGER(objTSTS_EQ_CTRL_YOTEI01.FEQ_STS) + TO_INTEGER(objTSTS_EQ_CTRL_YOTEI02.FEQ_STS)                          '�\�萔
                Dim intPalletSum As Integer = TO_INTEGER(objTSTS_EQ_CTRL_PALLET01.FEQ_STS) + TO_INTEGER(objTSTS_EQ_CTRL_PALLET02.FEQ_STS) + intTrnsEndLoader    '��گĐ����v
                If intYoteiSum <= intPalletSum Then
                    '(�S�Ă̔��������������ꍇ)


                    '**************************************
                    '�����\�萔         ���M
                    '�����\�萔��ؾ��
                    '**************************************
                    If IsNotNull(objAryTMST_TRK.ARYME(0).XADRS_YOTEI01) Then
                        '(�\�萔������ꍇ)
                        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                        objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         '�����ID
                        objSVR_190001.FPALLET_ID = ""                                   '��گ�ID
                        objSVR_190001.FTRNS_SERIAL = ""                                 '�����ره�
                        Call objSVR_190001.SendYasukawa_IDYotei(objAryTMST_TRK.ARYME(0).FTRK_BUF_NO _
                                                              , 0 _
                                                              , 0 _
                                                              )
                    End If


                End If


            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  �ύ���������                                                                         "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ύ���������
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub HanteiTumiEnd(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            '**************************************
            '����
            '**************************************
            If objTSTS_EQ_CTRL.FEQ_STS = FLAG_OFF Then Exit Sub


            '**************************************
            '�ׯ�ݸ��ޯ̧Ͻ�            �擾
            '**************************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.XEQ_ID_B_TUMIEND = objTSTS_EQ_CTRL.FEQ_ID       '�ݔ�ID
            intRet = objTMST_TRK.GET_TMST_TRK(False)                    '�擾
            If intRet <> RetCode.OK Then Exit Sub


            '**************************************
            '�o�׺���ԏ�              �擾
            '**************************************
            Dim objXSTS_CONVEYOR As New TBL_XSTS_CONVEYOR(Owner, ObjDb, ObjDbLog)
            objXSTS_CONVEYOR.XSTNO = objTMST_TRK.FTRK_BUF_NO        'STNo.
            objXSTS_CONVEYOR.GET_XSTS_CONVEYOR()                    '�擾


            '**************************************
            '�o���ް���               �擾
            '**************************************
            Dim blnTumiEnd As Boolean = False       '�ύ����������׸�
            Dim objAryXSTS_BERTH As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)
            objAryXSTS_BERTH.XBERTH_GROUP = objXSTS_CONVEYOR.XBERTH_GROUP   '�ް���ٰ��
            intRet = objAryXSTS_BERTH.GET_XSTS_BERTH_ANY()                  '�擾
            If intRet = RetCode.OK Then
                For Each objXSTS_BERTH As TBL_XSTS_BERTH In objAryXSTS_BERTH.ARYME
                    '(ٰ��:�擾����ں��ސ�)

                    If IsNotNull(objXSTS_BERTH.XSYUKKA_D) And IsNotNull(objXSTS_BERTH.XHENSEI_NO) Then
                        '(�o�ד��A�Ґ�������Ă���Ă���ꍇ)


                        '************************************************
                        '�o�׎w���ڍ�(�����p)           �擾
                        '�ύ������\�Ȍv�悩�ۂ�������
                        '************************************************
                        Dim blnXSYUKKA_STS_DTL_JALL As Boolean = False          '�S�i�o�ɔ���
                        Dim objAryXPLN_OUT_DTL_Check As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
                        objAryXPLN_OUT_DTL_Check.XSYUKKA_D = objXSTS_BERTH.XSYUKKA_D                '�o�ד�
                        objAryXPLN_OUT_DTL_Check.XHENSEI_NO_OYA = objXSTS_BERTH.XHENSEI_NO          '�e�Ґ�No.
                        intRet = objAryXPLN_OUT_DTL_Check.GET_XPLN_OUT_DTL_ANY()                    '�擾
                        If intRet <> RetCode.OK Then Throw New System.Exception(ERRMSG_NOTFOUND_XPLN_OUT & "[�o�ד�:" & objAryXPLN_OUT_DTL_Check.XSYUKKA_D & "][�e�Ґ�No.:" & objAryXPLN_OUT_DTL_Check.XHENSEI_NO_OYA & "]")
                        For ii As Integer = 0 To UBound(objAryXPLN_OUT_DTL_Check.ARYME)
                            '(ٰ��:�擾����ں��ސ�)

                            '=====================================
                            '�o�׏󋵏ڍ�       ����
                            '=====================================
                            If objAryXPLN_OUT_DTL_Check.ARYME(ii).XSYUKKA_STS_DTL <> XSYUKKA_STS_DTL_JALL Then
                                '(�o�׏󋵏ڍ� <> �o�ɍ� �̏ꍇ)
                                Exit For
                            End If
                            If UBound(objAryXPLN_OUT_DTL_Check.ARYME) <= ii Then
                                blnXSYUKKA_STS_DTL_JALL = True
                            End If

                        Next


                        If blnXSYUKKA_STS_DTL_JALL = True Then
                            '(�S�i�o�ɂ̏ꍇ)


                            '****************************************
                            '�ύ�����
                            '****************************************
                            Call TumikomiKanryou(objXSTS_BERTH.XBERTH_NO _
                                               , objXSTS_BERTH.XSYUKKA_D _
                                               , objXSTS_BERTH.XHENSEI_NO _
                                               )
                            blnTumiEnd = True


                        Else
                            '(�S�i�o�ɂ���Ȃ��ꍇ)

                            Call AddToMsgLog(Now, FMSG_ID_S9001, "�ύ��������݂���M���܂������A�S�i�o�Ɋ������Ă��Ȃ��ׁA�ύ����������͎��s���܂���ł����B�B[�ް���ٰ��:" & objAryXSTS_BERTH.XBERTH_GROUP & "]")

                        End If


                    End If

                Next
            End If
            If blnTumiEnd = False Then AddToMsgLog(Now, FMSG_ID_S9001, "�ύ��������݂���M���܂������A�ύ����������ް���������܂���ł����B[�ް���ٰ��:" & objAryXSTS_BERTH.XBERTH_GROUP & "]")


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  ���ɔ������ׯ�ݸނ̉��                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ���ɔ������ׯ�ݸނ̉��
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub HanteiInTrnsKaihou(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            '**************************************
            '����
            '**************************************
            If objTSTS_EQ_CTRL.FEQ_STS = FLAG_ON Then Exit Sub


            '**************************************
            '�ׯ�ݸ��ޯ̧Ͻ�        �擾
            '**************************************
            Dim strSQL As String = ""
            Dim objAryTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "    * "
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "    TMST_TRK "
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "        XEQ_ID_IN_FR   = '" & TO_STRING(objTSTS_EQ_CTRL.FEQ_ID) & "'"
            strSQL &= vbCrLf & "    OR  XEQ_ID_IN_BK   = '" & TO_STRING(objTSTS_EQ_CTRL.FEQ_ID) & "'"
            strSQL &= vbCrLf & "    OR  XEQ_ID_HASU_FR = '" & TO_STRING(objTSTS_EQ_CTRL.FEQ_ID) & "'"
            strSQL &= vbCrLf & "    OR  XEQ_ID_HASU_BK = '" & TO_STRING(objTSTS_EQ_CTRL.FEQ_ID) & "'"
            strSQL &= vbCrLf & "  "
            objAryTMST_TRK.USER_SQL = strSQL                     'SQL��
            intRet = objAryTMST_TRK.GET_TMST_TRK_USER()         '�擾
            If intRet = RetCode.OK Then
                '(���������ꍇ)
                If 1 < objAryTMST_TRK.ARYME.Length Then Throw New Exception("�擾����ں��ސ����s���B��`н���Ă��܂��B[�ݔ�ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]")
                For Each objTMST_TRK As TBL_TMST_TRK In objAryTMST_TRK.ARYME
                    '(ٰ��:1��)


                    '************************************************
                    '�ݔ���           �擾
                    '************************************************
                    Dim objTSTS_EQ_CTRL_IN_FR As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)           '���ɗv���O �ݔ�ID
                    Dim objTSTS_EQ_CTRL_IN_BK As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)           '���ɗv���� �ݔ�ID
                    Dim objTSTS_EQ_CTRL_HASU_FR As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)         '�[���O     �ݔ�ID
                    Dim objTSTS_EQ_CTRL_HASU_BK As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)         '�[����     �ݔ�ID
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IN_FR, objTMST_TRK.XEQ_ID_IN_FR)               '���ɗv���O �ݔ�ID
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IN_BK, objTMST_TRK.XEQ_ID_IN_BK)               '���ɗv���� �ݔ�ID
                    If IsNotNull(objTMST_TRK.XEQ_ID_HASU_FR) Then
                        Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_HASU_FR, objTMST_TRK.XEQ_ID_HASU_FR)       '�[���O     �ݔ�ID
                    Else
                        objTSTS_EQ_CTRL_HASU_FR.FEQ_STS = 0
                    End If
                    If IsNotNull(objTMST_TRK.XEQ_ID_HASU_BK) Then
                        Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_HASU_BK, objTMST_TRK.XEQ_ID_HASU_BK)       '�[����     �ݔ�ID
                    Else
                        objTSTS_EQ_CTRL_HASU_BK.FEQ_STS = 0
                    End If


                    '************************************************
                    '�ݔ����           ����
                    '************************************************
                    If Not ( _
                               objTSTS_EQ_CTRL_IN_FR.FEQ_STS = FEQ_STS_SAGC_ZAIKA_OF _
                           And objTSTS_EQ_CTRL_IN_BK.FEQ_STS = FEQ_STS_SAGC_ZAIKA_OF _
                           And objTSTS_EQ_CTRL_HASU_FR.FEQ_STS = FEQ_STS_SAGC_ZAIKA_OF _
                           And objTSTS_EQ_CTRL_HASU_BK.FEQ_STS = FEQ_STS_SAGC_ZAIKA_OF _
                           ) _
                        Then
                        '(�S�Ă̍ډׂ�OFF����Ă��Ȃ��ꍇ)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                         FLOG_DATA_TRN_SEND_NORMAL _
                                         & "�S�Ă̍ډׂ�OFF�łȂ��ׁA������ST�ׯ�ݸނ̉���͍s��Ȃ��B" _
                                         & "[�ݔ�ID(���ɗv���O):" & TO_STRING(objTSTS_EQ_CTRL_IN_FR.FEQ_ID) & "   �ݔ����:" & objTSTS_EQ_CTRL_IN_FR.FEQ_STS & "]" _
                                         & "[�ݔ�ID(���ɗv����):" & TO_STRING(objTSTS_EQ_CTRL_IN_BK.FEQ_ID) & "   �ݔ����:" & objTSTS_EQ_CTRL_IN_BK.FEQ_STS & "]" _
                                         & "[�ݔ�ID(�[���O):" & TO_STRING(objTSTS_EQ_CTRL_HASU_FR.FEQ_ID) & "   �ݔ����:" & objTSTS_EQ_CTRL_HASU_FR.FEQ_STS & "]" _
                                         & "[�ݔ�ID(�[����):" & TO_STRING(objTSTS_EQ_CTRL_HASU_BK.FEQ_ID) & "   �ݔ����:" & objTSTS_EQ_CTRL_HASU_BK.FEQ_STS & "]" _
                                         )
                        Continue For
                    End If

                    ''D43,D93�͉�����Ȃ��@@2017/08/02 @YAMAMOTO
                    If objTMST_TRK.FTRK_BUF_NO <> 2051 And objTMST_TRK.FTRK_BUF_NO <> 2901 Then

                        '**************************************
                        '�ׯ�ݸ��ޯ̧(FM)           ���
                        '**************************************
                        Dim objAryTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        strSQL = ""
                        strSQL &= vbCrLf & " SELECT "
                        strSQL &= vbCrLf & "    * "
                        strSQL &= vbCrLf & " FROM "
                        strSQL &= vbCrLf & "    TPRG_TRK_BUF "
                        strSQL &= vbCrLf & " WHERE "
                        strSQL &= vbCrLf & "        FRES_KIND = " & TO_STRING(FRES_KIND_SRSV_TRNS_IN)
                        strSQL &= vbCrLf & "    AND FTRK_BUF_NO = " & TO_STRING(objTMST_TRK.FTRK_BUF_NO)
                        strSQL &= vbCrLf & "    AND FRSV_PALLET IS NOT NULL "
                        strSQL &= vbCrLf & "  "
                        objAryTPRG_TRK_BUF_FM.USER_SQL = strSQL                     'SQL��
                        intRet = objAryTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF_USER()      '�擾
                        If intRet = RetCode.OK Then
                            For Each objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF In objAryTPRG_TRK_BUF_FM.ARYME
                                '(ٰ��:��������ׯ�ݸސ�)
                                objTPRG_TRK_BUF_FM.CLEAR_TPRG_TRK_BUF()      '���
                            Next
                        End If

                    End If
                Next
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  �װ���ނ�ݔ��ُ�۸ނɓo�^                                                           "
    '''**********************************************************************************************
    ''' <summary>
    ''' �װ���ނ�ݔ��ُ�۸ނɓo�^
    ''' �ޯĴװ�̐ݔ��ُ�۸ނ́A�ʉӏ��Œǉ����Ă���̂ŁA�ڰ̴݂װ���ނ݂̂�����œo�^
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">���������MIFð��ٸ׽</param>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub InsertTLOG_EQ_ERROR_ErrorCode(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                                            , ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL _
                                            )
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            '**************************************
            '�X�V����ݔ�ID(�ڰ�)       �擾
            '**************************************
            Dim strFEQ_ID As String = ""
            Select Case objTSTS_EQ_CTRL.FEQ_ID
                Case FEQ_ID_JOTHY05_X048501 : strFEQ_ID = FEQ_ID_JCRN0001
                Case FEQ_ID_JOTHY05_X048502 : strFEQ_ID = FEQ_ID_JCRN0002
                Case FEQ_ID_JOTHY05_X048503 : strFEQ_ID = FEQ_ID_JCRN0003
                Case FEQ_ID_JOTHY05_X048504 : strFEQ_ID = FEQ_ID_JCRN0004
                Case FEQ_ID_JOTHY05_X048505 : strFEQ_ID = FEQ_ID_JCRN0005
                Case FEQ_ID_JOTHY05_X048506 : strFEQ_ID = FEQ_ID_JCRN0006
                Case FEQ_ID_JOTHY05_X048507 : strFEQ_ID = FEQ_ID_JCRN0007
                Case FEQ_ID_JOTHY05_X048508 : strFEQ_ID = FEQ_ID_JCRN0008
                Case FEQ_ID_JOTHY05_X048509 : strFEQ_ID = FEQ_ID_JCRN0009
                Case FEQ_ID_JOTHY05_X048510 : strFEQ_ID = FEQ_ID_JCRN0010
                Case FEQ_ID_JOTHY05_X048511 : strFEQ_ID = FEQ_ID_JCRN0011
                Case FEQ_ID_JOTHY05_X048512 : strFEQ_ID = FEQ_ID_JCRN0012
                Case FEQ_ID_JOTHY05_X048513 : strFEQ_ID = FEQ_ID_JCRN0013
                Case FEQ_ID_JOTHY05_X048514 : strFEQ_ID = FEQ_ID_JCRN0014
                Case Else : Exit Sub
            End Select


            '************************
            'MDD�p�װ���ނɕϊ�
            '************************
            Dim strMDDErrCode As String = GetMDDErrCodeFromPLCErrCode(objTLIF_TRNS_RECV.FDENBUN_PRM2)


            '************************
            '�ݔ���~�v��Ͻ��̓���
            '************************
            Dim objTMST_EQ_ERROR As New TBL_TMST_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '�ݔ���~�v��Ͻ�
            objTMST_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '�ݔ�ID
            objTMST_EQ_ERROR.FEQ_STS = strMDDErrCode                                    '�ݔ����
            intRet = objTMST_EQ_ERROR.GET_TMST_EQ_ERROR(False)                          '����


            If objTSTS_EQ_CTRL.FEQ_STS <> 0 Then
                '(�ُ� �̏ꍇ)

                '====================
                '�ݔ��ُ�۸ޓo�^
                '====================
                Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '�ݔ��ُ�۸�
                objTLOG_EQ_ERROR.FHASSEI_DT = objTLIF_TRNS_RECV.FENTRY_DT                   '��������
                objTLOG_EQ_ERROR.FHUKKI_DT = DEFAULT_DATE                                   '��������
                objTLOG_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '�ݔ�ID
                objTLOG_EQ_ERROR.FEQ_STS = strMDDErrCode                                    '�ݔ����
                objTLOG_EQ_ERROR.FEQ_STOP_CD = objTLIF_TRNS_RECV.FDENBUN_PRM3               '��~����
                objTLOG_EQ_ERROR.ADD_TLOG_EQ_ERROR_SEQ()                                    '�o�^

                '====================
                '�ڰݏ��       �X�V
                '====================
                If IsNotNull(strFEQ_ID) Then Call Set_FEQ_STS(strFEQ_ID, FEQ_STS_JCRN_IJOU)

                '====================
                'ү���ޗ�����������
                '====================
                Call AddToMsgLog(Now, FMSG_ID_S0104, "[�ݔ�����:" & objTSTS_EQ_CTRL.FEQ_NAME & ":" & strMDDErrCode & "][�װ����:" & objTMST_EQ_ERROR.FEQ_STOP_NAME & "]")

            Else
                '(���� �̏ꍇ)

                '====================
                '�ݔ��ُ�۸ލX�V
                '====================
                Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '�ݔ��ُ�۸�
                objTLOG_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '�ݔ�ID
                objTLOG_EQ_ERROR.FHUKKI_DT = objTLIF_TRNS_RECV.FENTRY_DT                    '��������
                objTLOG_EQ_ERROR.UPDATE_TLOG_EQ_ERROR_FEQ_ID()                              '�o�^

                '====================
                '�ڰݏ��       �X�V
                '====================
                If IsNotNull(strFEQ_ID) Then Call Set_FEQ_STS(strFEQ_ID, FEQ_STS_JCRN_UNTEN)

            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  D45�o�ɗv�������ޏo�ɐݒ���(D45)ð��قɍX�V                                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' D45�o�ɗv�������ޏo�ɐݒ���(D45)ð��قɍX�V
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">���������MIFð��ٸ׽</param>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateXSTS_WRAPPING_MATERIAL_D45(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                                               , ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL _
                                               )
        'Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����


        '**************************************
        '����
        '**************************************
        Select Case objTSTS_EQ_CTRL.FEQ_ID
            Case FEQ_ID_JOTHY05_X049001 _
               , FEQ_ID_JOTHY05_X049002 _
               , FEQ_ID_JOTHY05_X049003 _
               , FEQ_ID_JOTHY05_X049004 _
               , FEQ_ID_JOTHY05_X049005 _
               , FEQ_ID_JOTHY05_X049006 _
               , FEQ_ID_JOTHY05_X049007 _
                '(�װ���ނ̏ꍇ)
                'NOP
            Case Else
                Exit Sub
        End Select


        '************************************************
        '��ޏo�ɐݒ���(D45)          �擾
        '************************************************
        Dim objXSTS_WRAPPING_MATERIAL_D45 As New TBL_XSTS_WRAPPING_MATERIAL_D45(Owner, ObjDb, ObjDbLog)
        objXSTS_WRAPPING_MATERIAL_D45.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID               '�ݔ�ID
        objXSTS_WRAPPING_MATERIAL_D45.GET_XSTS_WRAPPING_MATERIAL_D45()                '�擾


        '************************************************
        '��ޏo�ɐݒ���(D45)          �X�V
        '************************************************
        objXSTS_WRAPPING_MATERIAL_D45.XPLAN_NUM = objTSTS_EQ_CTRL.FEQ_STS       '�v�搔��
        'objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM = 0                           '���ѐ���
        objXSTS_WRAPPING_MATERIAL_D45.UPDATE_XSTS_WRAPPING_MATERIAL_D45()       '�X�V


    End Sub
#End Region

#Region "  1F�o�ɗv�������ޏo�ɐݒ���(1F)ð��قɍX�V                                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' 1F�o�ɗv�������ޏo�ɐݒ���(1F)ð��قɍX�V
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">���������MIFð��ٸ׽</param>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateXSTS_WRAPPING_MATERIAL_1F(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                                               , ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL _
                                               )
        'Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Dim intFlag As Integer = FLAG_OFF
        Dim strOUTOU_ID As String
        '**************************************
        '����
        '**************************************
        Select Case Mid(objTSTS_EQ_CTRL.FEQ_ID, 1, 16)
            Case "JOTHY03_X048291_", "JOTHY03_X048292_", "JOTHY04_X048291_", "JOTHY04_X048292_", "JOTHY06_X048291_", "JOTHY06_X048292_"
                strOUTOU_ID = Mid(objTSTS_EQ_CTRL.FEQ_ID, 1, 18)
                strOUTOU_ID = strOUTOU_ID.Replace("X04829", "X04849")
                '(�װ���ނ̏ꍇ)
                'NOP
            Case Else
                Exit Sub
        End Select


        '************************************************
        '��ޏo�ɐݒ���(1F)          �擾
        '************************************************
        Dim objXSTS_WRAPPING_MATERIAL_1F As New TBL_XSTS_WRAPPING_MATERIAL_1F(Owner, ObjDb, ObjDbLog)
        objXSTS_WRAPPING_MATERIAL_1F.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID               '�ݔ�ID
        objXSTS_WRAPPING_MATERIAL_1F.GET_XSTS_WRAPPING_MATERIAL_1F()                '�擾

        If objTLIF_TRNS_RECV.FDENBUN_PRM2 = FLAG_ON Then
            ''1.OFF��ON�̏ꍇ
            ''�E�v��ɏo��PL�ݒ薇�������Z����()
            objXSTS_WRAPPING_MATERIAL_1F.XPLAN_NUM = TO_INTEGER(objXSTS_WRAPPING_MATERIAL_1F.XPLAN_NUM) + TO_INTEGER(objXSTS_WRAPPING_MATERIAL_1F.XOUT_PALLET_NUM)       '�v�搔��
            objXSTS_WRAPPING_MATERIAL_1F.UPDATE_XSTS_WRAPPING_MATERIAL_1F()       '�X�V
            ''�E�ԓ��׸�ON()
            intFlag = FLAG_ON
            ''�EON�����׸ނ̐ݔ���Ԃ��X�V()
        Else
            ''�E�ԓ��׸�OFF()
            intFlag = FLAG_OFF
        End If

        '************************************************
        'PLC����ݽ
        '************************************************
        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
        Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(strOUTOU_ID, "JW_MAINTE_YOTEI", intFlag.ToString)
        

        ''�EON/OFF�����׸ނ̐ݔ���Ԃ��X�V()
        Dim objTSTS_EQ_CTRL2 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        objTSTS_EQ_CTRL2.FEQ_ID = strOUTOU_ID
        objTSTS_EQ_CTRL2.GET_TSTS_EQ_CTRL(False)
        '�X�V
        objTSTS_EQ_CTRL2.FEQ_STS = intFlag
        objTSTS_EQ_CTRL2.UPDATE_TSTS_EQ_CTRL()

    End Sub
#End Region

#Region "  D43,D93���ɗv��OFF���ׯ�ݸމ��                                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' D43,D93���ɗv��OFF���ׯ�ݸމ��
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">���������MIFð��ٸ׽</param>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateXSTS_ITF(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV _
                                               , ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL _
                                               )
        Dim intRet As Integer
        Dim intBufNo As Integer = 0
        Dim strSQL As String

        '**************************************
        '����
        '**************************************
        Select Case objTSTS_EQ_CTRL.FEQ_ID
            Case "JOTHMFF_D000003_04", "JOTHMFF_D000003_05"
                intBufNo = 2051
            Case "JOTHMFF_D000005_00", "JOTHMFF_D000005_01"
                intBufNo = 2901
            Case Else
                Exit Sub
        End Select

        If objTSTS_EQ_CTRL.FEQ_STS = FLAG_OFF Then Exit Sub

        If objTLIF_TRNS_RECV.FDENBUN_PRM2 = FLAG_ON Then Exit Sub

        '**************************************
        '�ׯ�ݸ��ޯ̧(FM)           ���
        '**************************************
        Dim objAryTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    * "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TPRG_TRK_BUF "
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        FRES_KIND = " & TO_STRING(FRES_KIND_SRSV_TRNS_IN)
        strSQL &= vbCrLf & "    AND FTRK_BUF_NO = " & TO_STRING(intBufNo)
        strSQL &= vbCrLf & "    AND FRSV_PALLET IS NOT NULL "
        strSQL &= vbCrLf & "  "
        objAryTPRG_TRK_BUF_FM.USER_SQL = strSQL                     'SQL��
        intRet = objAryTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF_USER()      '�擾
        If intRet = RetCode.OK Then
            For Each objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF In objAryTPRG_TRK_BUF_FM.ARYME
                '(ٰ��:��������ׯ�ݸސ�)
                objTPRG_TRK_BUF_FM.CLEAR_TPRG_TRK_BUF()      '���
            Next
        End If

    End Sub
#End Region

#Region "  ۰�وُ�����(JOTHMFF_D000104_12)�X�V                                                 "
    '''**********************************************************************************************
    ''' <summary>
    ''' ۰�وُ�����(JOTHMFF_D000104_12)�X�V
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateLocalErrLamp(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        'Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            '****************************************
            '�ݔ��ُ�۸�            �擾
            '****************************************
            Dim intCount As Integer = 0
            Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)
            objTLOG_EQ_ERROR.WHERE = "    AND FHUKKI_DT IS NULL "   '����
            intCount = objTLOG_EQ_ERROR.GET_TLOG_EQ_ERROR_COUNT()   '�����擾


            '****************************************
            '�ݔ��ُ�۸�            �擾
            '****************************************
            Dim objTSTS_EQ_CTRL_Lamp As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            objTSTS_EQ_CTRL_Lamp.FEQ_ID = FEQ_ID_JOTHMFF_D000104_12     '�ݔ�ID
            objTSTS_EQ_CTRL_Lamp.GET_TSTS_EQ_CTRL()                     '�擾


            '****************************************
            '۰�وُ�����(JOTHMFF_D000104_12)�X�V
            '****************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            If 0 = intCount Then
                '(�ُ�Ȃ��̏ꍇ)
                If objTSTS_EQ_CTRL_Lamp.FEQ_STS <> 0 Then
                    Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000104_12, FTEXT_ID_JW_ETC, 0)
                End If
            Else
                '(�ُ킠��̏ꍇ)
                If objTSTS_EQ_CTRL_Lamp.FEQ_STS <> 1 Then
                    Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000104_12, FTEXT_ID_JW_ETC, 1)
                End If
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  �ׯ�۰��Ӱ��ظ��ď���                                                                "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ׯ�۰��Ӱ��ظ��ď����A�ׯ�۰��Ӱ�ގ�M��������
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateLoaderModeON(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            '**************************************
            '����
            '**************************************
            If objTSTS_EQ_CTRL.FEQ_STS <> FLAG_ON Then Exit Sub


            '****************************************
            '����
            '****************************************
            Dim strAdrsMode As String = ""          '�������ڽ(Ӱ��)
            Dim strAdrsBit As String = ""           '�������ڽ(�ޯ�)
            Dim strFEQ_ID_Kidou01 As String = ""    '�ް��N�����ޯ�01
            Dim strFEQ_ID_Kidou02 As String = ""    '�ް��N�����ޯ�02
            Dim strFEQ_ID_Kidou03 As String = ""    '�ް��N�����ޯ�03
            Select Case objTSTS_EQ_CTRL.FEQ_ID
                Case FEQ_ID_JOTHMFF_D000032_07
                    '(۰��1���@�̏ꍇ)
                    strAdrsMode = FEQ_ID_JOTHMFF_D000105                '�������ڽ(Ӱ��)
                    strAdrsBit = FEQ_ID_JOTHMFF_D000105_07              '�������ڽ(�ޯ�)
                    strFEQ_ID_Kidou01 = FEQ_ID_JOTHMFF_D000025_15       '�ް��N�����ޯ�01
                    strFEQ_ID_Kidou02 = FEQ_ID_JOTHMFF_D000025_14       '�ް��N�����ޯ�02
                    strFEQ_ID_Kidou03 = FEQ_ID_JOTHMFF_D000025_13       '�ް��N�����ޯ�03
                Case FEQ_ID_JOTHMFF_D000032_06
                    '(۰��2���@�̏ꍇ)
                    strAdrsMode = FEQ_ID_JOTHMFF_D000106                '�������ڽ(Ӱ��)
                    strAdrsBit = FEQ_ID_JOTHMFF_D000106_07              '�������ڽ(�ޯ�)
                    strFEQ_ID_Kidou01 = FEQ_ID_JOTHMFF_D000025_12       '�ް��N�����ޯ�01
                    strFEQ_ID_Kidou02 = FEQ_ID_JOTHMFF_D000025_11       '�ް��N�����ޯ�02
                    strFEQ_ID_Kidou03 = FEQ_ID_JOTHMFF_D000025_10       '�ް��N�����ޯ�03
                Case Else : Exit Sub
            End Select


            '*************************************************
            '�ݔ���           �擾
            '*************************************************
            Dim objTSTS_EQ_CTRL_Kidou01 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     '�ް��N�����ޯ�01
            Dim objTSTS_EQ_CTRL_Kidou02 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     '�ް��N�����ޯ�02
            Dim objTSTS_EQ_CTRL_Kidou03 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     '�ް��N�����ޯ�03
            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_Kidou01, strFEQ_ID_Kidou01)
            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_Kidou02, strFEQ_ID_Kidou02)
            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_Kidou03, strFEQ_ID_Kidou03)


            '*************************************************
            '����
            '*************************************************
            Dim objTSTS_EQ_CTRL_KidouOn As TBL_TSTS_EQ_CTRL
            If TO_INTEGER(objTSTS_EQ_CTRL_Kidou01.FEQ_STS) + TO_INTEGER(objTSTS_EQ_CTRL_Kidou02.FEQ_STS) + TO_INTEGER(objTSTS_EQ_CTRL_Kidou03.FEQ_STS) = 1 Then
                '(�ǂꂩ1����ON�̏ꍇ)

                If TO_INTEGER(objTSTS_EQ_CTRL_Kidou01.FEQ_STS) = FLAG_ON Then
                    objTSTS_EQ_CTRL_KidouOn = objTSTS_EQ_CTRL_Kidou01
                ElseIf TO_INTEGER(objTSTS_EQ_CTRL_Kidou02.FEQ_STS) = FLAG_ON Then
                    objTSTS_EQ_CTRL_KidouOn = objTSTS_EQ_CTRL_Kidou02
                ElseIf TO_INTEGER(objTSTS_EQ_CTRL_Kidou03.FEQ_STS) = FLAG_ON Then
                    objTSTS_EQ_CTRL_KidouOn = objTSTS_EQ_CTRL_Kidou03
                Else
                    Throw New Exception("�ׯ�۰��Ӱ��ظ��Ă���M���܂������A�ް��N����ON���ް������݂��܂���B[" & objTSTS_EQ_CTRL.FEQ_NAME & "]")
                End If

            Else
                '(�ǂꂩ1����ON����Ȃ��ꍇ)

                Throw New Exception("�ׯ�۰��Ӱ��ظ��Ă���M���܂������A�ް��N����ON�����o���܂���B" _
                                  & "[" & objTSTS_EQ_CTRL.FEQ_NAME & "]" _
                                  & "[" & objTSTS_EQ_CTRL_Kidou01.FEQ_NAME & ":" & TO_STRING(objTSTS_EQ_CTRL_Kidou01.FEQ_STS) & "]" _
                                  & "[" & objTSTS_EQ_CTRL_Kidou02.FEQ_NAME & ":" & TO_STRING(objTSTS_EQ_CTRL_Kidou02.FEQ_STS) & "]" _
                                  & "[" & objTSTS_EQ_CTRL_Kidou03.FEQ_NAME & ":" & TO_STRING(objTSTS_EQ_CTRL_Kidou03.FEQ_STS) & "]" _
                                  )

            End If


            '*************************************************
            '�ް��̓���
            '*************************************************
            Dim strXBERTH_NO As String = ""
            Select Case objTSTS_EQ_CTRL_KidouOn.FEQ_ID
                Case FEQ_ID_JOTHMFF_D000025_15 : strXBERTH_NO = XBERTH_NO_JX01
                Case FEQ_ID_JOTHMFF_D000025_14 : strXBERTH_NO = XBERTH_NO_JX02
                Case FEQ_ID_JOTHMFF_D000025_13 : strXBERTH_NO = XBERTH_NO_JX03
                Case FEQ_ID_JOTHMFF_D000025_12 : strXBERTH_NO = XBERTH_NO_JX04
                Case FEQ_ID_JOTHMFF_D000025_11 : strXBERTH_NO = XBERTH_NO_JX05
                Case FEQ_ID_JOTHMFF_D000025_10 : strXBERTH_NO = XBERTH_NO_JX06
            End Select


            '*************************************************
            '�o���ް���       �擾
            '*************************************************
            Dim intXSYARYOU_NO As Nullable(Of Integer) = Nothing           '���q�ԍ�
            Dim objXSTS_BERTH As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)
            objXSTS_BERTH.XBERTH_NO = strXBERTH_NO  '�ް�No.
            objXSTS_BERTH.GET_XSTS_BERTH()          '�擾
            If IsNotNull(objXSTS_BERTH.XSYUKKA_D) And IsNotNull(objXSTS_BERTH.XHENSEI_NO) Then
                '(���q������t���Ă���ꍇ)


                '*************************************************
                '�o�׎w��               �擾
                '*************************************************
                Dim objAryXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
                objAryXPLN_OUT.XSYUKKA_D = objXSTS_BERTH.XSYUKKA_D          '�o�ד�
                objAryXPLN_OUT.XHENSEI_NO = objXSTS_BERTH.XHENSEI_NO        '�Ґ�No.
                intRet = objAryXPLN_OUT.GET_XPLN_OUT_ANY()                  '�擾
                If intRet = RetCode.OK Then
                    intXSYARYOU_NO = objAryXPLN_OUT.ARYME(0).XSYARYOU_NO    '���q�ԍ�       ���
                Else
                    Throw New Exception("�ׯ�۰��Ӱ��ظ��Ă���M���܂������A�o�׎w��������q�����o���܂���B[�o�ד�:" & Format(objXSTS_BERTH.XSYUKKA_D, DATE_FORMAT_02) & "][�Ґ���:" & objXSTS_BERTH.XHENSEI_NO & "]")
                End If


            Else
                '(���q������t���Ă��Ȃ��ꍇ)

                Throw New Exception("�ׯ�۰��Ӱ��ظ��Ă���M���܂������A�ް��N����ON���ް��Ɏ��q������t���Ă��܂���B" _
                                  & "[" & objXSTS_BERTH.XBERTH_NO & "]" _
                                  & "[" & objTSTS_EQ_CTRL_Kidou01.FEQ_NAME & ":" & TO_STRING(objTSTS_EQ_CTRL_Kidou01.FEQ_STS) & "]" _
                                  & "[" & objTSTS_EQ_CTRL_Kidou02.FEQ_NAME & ":" & TO_STRING(objTSTS_EQ_CTRL_Kidou02.FEQ_STS) & "]" _
                                  & "[" & objTSTS_EQ_CTRL_Kidou03.FEQ_NAME & ":" & TO_STRING(objTSTS_EQ_CTRL_Kidou03.FEQ_STS) & "]" _
                                  )

            End If


            '*************************************************
            '���qϽ�            �擾
            '*************************************************
            Dim objXMST_SYARYOU As New TBL_XMST_SYARYOU(Owner, ObjDb, ObjDbLog)
            objXMST_SYARYOU.XSYARYOU_NO = intXSYARYOU_NO        '���q�ԍ�
            objXMST_SYARYOU.GET_XMST_SYARYOU()                  '�擾
            If IsNotNull(objXMST_SYARYOU.XSYARYOU_MODE) Then
                '(�ް�����Ă���Ă����ꍇ)


                '****************************************
                'Melsec       ۰�ްӰ��     ����
                '****************************************
                Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                Call objSVR_190001.SendYasukawa_IDLoaderMode(TO_INTEGER(objXMST_SYARYOU.XSYARYOU_MODE), strAdrsMode, 0)
                Call objSVR_190001.SendYasukawa_IDLoaderMode(TO_INTEGER(objXMST_SYARYOU.XSYARYOU_MODE), strAdrsMode, 1)
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(strAdrsBit, FTEXT_ID_JW_ETC, FLAG_ON)


            Else
                '(�ް�����Ă���Ă��Ȃ��ꍇ)
                Throw New Exception("�ׯ�۰��Ӱ��ظ��Ă���M���܂������A�ׯ�������t���ĂȂ����A���qϽ���۰��Ӱ��(�߯�����)����`����Ă��܂���B[�ݔ�����:" & objTSTS_EQ_CTRL.FEQ_NAME & "][���q�ԍ�:" & TO_STRING(objXMST_SYARYOU.XSYARYOU_NO) & "]")
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  �ׯ�۰��Ӱ�ގ�M��������                                                             "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ׯ�۰��Ӱ��ظ��ď����A�ׯ�۰��Ӱ�ގ�M��������
    ''' </summary>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub UpdateLoaderModeOFF(ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        'Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            '**************************************
            '����
            '**************************************
            If objTSTS_EQ_CTRL.FEQ_STS <> FLAG_ON Then Exit Sub


            '****************************************
            '����
            '****************************************
            Dim strAdrsBit As String = ""           '�������ڽ(�ޯ�)
            Select Case objTSTS_EQ_CTRL.FEQ_ID
                Case FEQ_ID_JOTHMFF_D000032_15
                    '(۰��1���@�̏ꍇ)
                    strAdrsBit = FEQ_ID_JOTHMFF_D000105_07              '�������ڽ(�ޯ�)
                Case FEQ_ID_JOTHMFF_D000032_14
                    '(۰��2���@�̏ꍇ)
                    strAdrsBit = FEQ_ID_JOTHMFF_D000106_07              '�������ڽ(�ޯ�)
                Case Else : Exit Sub
            End Select


            '****************************************
            'Melsec       ۰�ްӰ��     �����׸�OFF
            '****************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(strAdrsBit, FTEXT_ID_JW_ETC, FLAG_OFF)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region



    '���q���۰׌n
#Region "  �Ǎ�_����ذ�ޓǍ�(�o�׎w���X�V)                                                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' �Ǎ�_����ذ�ޓǍ�
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">���������MIFð��ٸ׽</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function CARTelRecvJR_CARD(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV) As RetCode
        Dim intRet As RetCode                   '�߂�l


        '-------------------    
        '����
        '-------------------    
        If TO_STRING(objTLIF_TRNS_RECV.FDENBUN_PRM1) = "000000" Then Return RetCode.OK


        '-------------------    
        '�����ݒ�
        '-------------------    
        Dim strSQL As String                    'SQL��
        Dim objPLN_OUT_ARY As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)


        '-------------------    
        '(���qϽ�)
        '-------------------    
        Dim intRetCode_SYARYOU As RetCode                                   '�߂�l
        Dim objMST_SYARYOU As New TBL_XMST_SYARYOU(Owner, ObjDb, ObjDbLog)  '���qϽ��׽
        objMST_SYARYOU.XCARD_NO = objTLIF_TRNS_RECV.FDENBUN_PRM1            '���ޔԍ�
        intRetCode_SYARYOU = objMST_SYARYOU.GET_XMST_SYARYOU(False)         '�����ް��Ǎ�
        If intRetCode_SYARYOU = RetCode.NotFound Then
            Call AddToMsgLog(Now, FMSG_ID_J5003, "���qϽ��Y���ް����� ���އ�=[" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "]")
            Return RetCode.NG
        End If
        If TO_INTEGER(objMST_SYARYOU.XLOADER_POSSIBLE) <> FLAG_ON Then
            Call AddToMsgLog(Now, FMSG_ID_J5003, "۰�ނɑΉ����Ă��Ȃ����q��t���s���܂����B ���q�ԍ�=[" & TO_STRING(objMST_SYARYOU.XSYARYOU_NO) & "]")
            Return RetCode.NG
        End If


        If objTLIF_TRNS_RECV.FDENBUN_PRM2 = "01" Then
            '(���\��)


            '-------------------    
            '���\����(�����\�ް��L��)
            '-------------------
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XPLN_OUT"       '�o�׎w���ڍ�
            strSQL &= vbCrLf & " WHERE"
            '������������************************************************************************************************************
            'JobMate:S.Ouchi 2014/01/20 ۰���ް� ����ԗ�����������t�Ή�
            '' ''strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '���q�ԍ�
            '' ''strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS <= " & TO_STRING(XSYUKKA_STS_JOUT)             '�o�׏�(�o�ɍ�)
            '' ''strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS >= " & TO_STRING(XSYUKKA_STS_JNON)             '�o�׏�(��t��)
            strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '���q�ԍ�
            strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS <= " & TO_STRING(XSYUKKA_STS_JOUT)             '�o�׏�(�o�ɍ�)
            strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS >= " & TO_STRING(XSYUKKA_STS_JNON)             '�o�׏�(��t��)
            strSQL &= vbCrLf & "    AND(XPLN_OUT.XBERTH_NO IS NULL"
            strSQL &= vbCrLf & "     OR XPLN_OUT.XBERTH_NO IN ('" & XBERTH_NO_JX01 & "'," & _
                                                              "'" & XBERTH_NO_JX02 & "'," & _
                                                              "'" & XBERTH_NO_JX03 & "'," & _
                                                              "'" & XBERTH_NO_JX04 & "'," & _
                                                              "'" & XBERTH_NO_JX05 & "'," & _
                                                              "'" & XBERTH_NO_JX06 & "'))"                  '�ް���(۰���ް�)
            'JobMate:S.Ouchi 2014/01/20 ۰���ް� ����ԗ�����������t�Ή�
            '������������************************************************************************************************************
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D"                                                     '�o�ד�
            strSQL &= vbCrLf & "   ,XPLN_OUT.XUNKOU_NO"                                                     '�q�ɕʉ^�s��
            strSQL &= vbCrLf & "   ,XPLN_OUT.XHENSEI_NO"                                                    '�Ґ���
            strSQL &= vbCrLf & "   ,XPLN_OUT.XDENPYOU_NO"                                                   '�`�[��
            strSQL &= vbCrLf

            objPLN_OUT_ARY.USER_SQL = strSQL
            intRet = objPLN_OUT_ARY.GET_XPLN_OUT_USER()
            If intRet = RetCode.OK Then


                '******************************
                '�o�׏�����
                '******************************
                For Each objPLN_OUT As TBL_XPLN_OUT In objPLN_OUT_ARY.ARYME
                    If objPLN_OUT.XSYUKKA_STS <> XSYUKKA_STS_JNON Then
                        Call AddToMsgLog(Now, FMSG_ID_J5003, "���ɓ������q�ԍ��̏o�׎w�������s����Ă��܂��B[���q�ԍ�:" & TO_STRING(objMST_SYARYOU.XSYARYOU_NO) & "]")
                        Return RetCode.NG
                    End If
                Next


                '******************************
                '�o�׏󋵍X�V
                '******************************
                Dim dtmXSYUKKA_D As Nullable(Of Date)                                       '�o�ד�
                Dim strXHENSEI_NO As String = ""                                            '�Ґ���
                For Each objPLN_OUT As TBL_XPLN_OUT In objPLN_OUT_ARY.ARYME
                    If IsNull(dtmXSYUKKA_D) = True And strXHENSEI_NO = "" Then
                        dtmXSYUKKA_D = objPLN_OUT.XSYUKKA_D
                        strXHENSEI_NO = objPLN_OUT.XHENSEI_NO
                    Else
                        If dtmXSYUKKA_D <> objPLN_OUT.XSYUKKA_D Or _
                           strXHENSEI_NO <> objPLN_OUT.XHENSEI_NO Then
                            Exit For
                        End If
                    End If

                    '-------------------
                    '�o�׎w���X�V(��t��)
                    '-------------------
                    objPLN_OUT.XTUMI_HOUKOU = XTUMI_HOUKOU_JBACK                            '�ύ�����(���)
                    objPLN_OUT.XTUMI_HOUHOU = XTUMI_HOUHOU_JL                               '�ύ����@(۰�ސ�)
                    If objTLIF_TRNS_RECV.FDENBUN_PRM2 = CAR_SYUBETU_REQ Then
                        objPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JREQ                               '�o�׏�(��t��)
                    End If
                    objPLN_OUT.XSYARYOU_ENTRY_DT = Now                                      '���q��t����
                    objPLN_OUT.XSYUKKA_DIR_DT = Now                                         '�o�׎w������
                    objPLN_OUT.XHENSEI_NO_OYA = objPLN_OUT.XHENSEI_NO                       '�e�Ґ���
                    objPLN_OUT.UPDATE_XPLN_OUT()
                Next


            ElseIf intRet = RetCode.NotFound Then
                Call AddToMsgLog(Now, FMSG_ID_J5003, "�o�׎w�������݂��܂���B[���q�ԍ�:" & TO_STRING(objMST_SYARYOU.XSYARYOU_NO) & "]")
                Return RetCode.NG
            End If


        ElseIf objTLIF_TRNS_RECV.FDENBUN_PRM2 = "02" Then
            '(�o�\��)


            '--------------------------------------
            '--------------------------------------
            '�o�׎w���Ǎ�
            '--------------------------------------
            '--------------------------------------
            '-------------------    
            '�o�\����(�o�ɍ��ް��L��)
            '-------------------
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XPLN_OUT"       '�o�׎w���ڍ�
            strSQL &= vbCrLf & " WHERE"
            '������������************************************************************************************************************
            'JobMate:S.Ouchi 2014/01/20 ۰���ް� ����ԗ�����������t�Ή�
            '' ''strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '���q�ԍ�
            '' ''strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS = " & TO_STRING(XSYUKKA_STS_JOUT)              '�o�׏�(�o�ɍ�)
            strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '���q�ԍ�
            strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS = " & TO_STRING(XSYUKKA_STS_JOUT)              '�o�׏�(�o�ɍ�)
            strSQL &= vbCrLf & "    AND XPLN_OUT.XBERTH_NO IN ('" & XBERTH_NO_JX01 & "'," & _
                                                              "'" & XBERTH_NO_JX02 & "'," & _
                                                              "'" & XBERTH_NO_JX03 & "'," & _
                                                              "'" & XBERTH_NO_JX04 & "'," & _
                                                              "'" & XBERTH_NO_JX05 & "'," & _
                                                              "'" & XBERTH_NO_JX06 & "')"                   '�ް���(۰���ް�)
            'JobMate:S.Ouchi 2014/01/20 ۰���ް� ����ԗ�����������t�Ή�
            '������������************************************************************************************************************
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D"                                                     '�o�ד�
            strSQL &= vbCrLf & "   ,XPLN_OUT.XUNKOU_NO"                                                     '�q�ɕʉ^�s��
            strSQL &= vbCrLf & "   ,XPLN_OUT.XHENSEI_NO"                                                    '�Ґ���
            strSQL &= vbCrLf & "   ,XPLN_OUT.XDENPYOU_NO"                                                   '�`�[��
            strSQL &= vbCrLf

            objPLN_OUT_ARY.USER_SQL = strSQL
            intRet = objPLN_OUT_ARY.GET_XPLN_OUT_USER()
            If intRet = RetCode.OK Then
                For Each objPLN_OUT As TBL_XPLN_OUT In objPLN_OUT_ARY.ARYME
                    '****************************************
                    '�ύ�����
                    '****************************************
                    Call TumikomiKanryou(objPLN_OUT.XBERTH_NO _
                                       , objPLN_OUT.XSYUKKA_D _
                                       , objPLN_OUT.XHENSEI_NO_OYA _
                                       )
                    Exit For
                Next


                Return RetCode.OK
            End If


        End If


        Return RetCode.OK
    End Function
#End Region
#Region "  �Ǎ�_����ذ�ޓǍ�(�����d�����M)                                                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' �Ǎ�_����ذ�ޓǍ�(�����d�����M)
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">���������MIFð��ٸ׽</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function CARTelRecvJR_CARD_SendRetTel(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV) As RetCode
        Try

            'Dim intRet As RetCode                   '�߂�l


            '**************************************************
            '�����ݒ�
            '**************************************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)
            Dim strAryRecvText() As String = Split(objTLIF_TRNS_RECV.FDENBUN, "_")    '��M�d��
            Dim strSendText As String = ""                              '���M�d��


            '**************************************************
            '�����׸�               �쐬
            '**************************************************
            Dim strRetFlag As String = ""
            Select Case objTLIF_TRNS_RECV.FDENBUN_PRM2
                Case "01", "02", "04", "08", "10", "20", "40", "80"
                    '(���\��)
                    '(�ڎԎ�)
                    '(�o�\��)

                    strRetFlag = MakeReturnTelegramRetFlag(objTLIF_TRNS_RECV)

                Case Else
                    '(���̑��̏ꍇ)

                    Return ""

            End Select


            '**************************************************
            '���q���۰�   ����ذ�ޓǍ�����
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
            '���q���۰�   ����ذ�ޓǍ�����
            '**************************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            objSVR_190001.SendCar_IDJS_CARD01(strSendText)


            '**************************************************
            '����ذ�ޓǎ抮���ޯ�           ON
            '**************************************************
            If strRetFlag <> "_c5_c5" Then
                '(�װ�ȊO�̏ꍇ)
                Select Case objTLIF_TRNS_RECV.FDENBUN_PRM2
                    Case "01" : Call objSVR_190001.SendCar_IDJS_CARD02()
                    Case "04" : Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_15, FTEXT_ID_JW_ETC, FLAG_ON) ': Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_15, FTEXT_ID_JW_ETC, FLAG_ON)
                    Case "08" : Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_14, FTEXT_ID_JW_ETC, FLAG_ON) ': Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_14, FTEXT_ID_JW_ETC, FLAG_ON)
                    Case "10" : Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_13, FTEXT_ID_JW_ETC, FLAG_ON) ': Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_13, FTEXT_ID_JW_ETC, FLAG_ON)
                    Case "20" : Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_12, FTEXT_ID_JW_ETC, FLAG_ON) ': Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_12, FTEXT_ID_JW_ETC, FLAG_ON)
                    Case "40" : Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_11, FTEXT_ID_JW_ETC, FLAG_ON) ': Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_11, FTEXT_ID_JW_ETC, FLAG_ON)
                    Case "80" : Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000102_10, FTEXT_ID_JW_ETC, FLAG_ON) ': Call objSVR_190001.SendYasukawaMelsec_IDMainteBit(FEQ_ID_JOTHMFF_D000101_10, FTEXT_ID_JW_ETC, FLAG_ON)
                End Select
            End If


            Return RetCode.OK
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG
        End Try
    End Function
#End Region
#Region "  �Ǎ�_����ذ�ޓǍ�(�����d�����M)(��ފ֐�)                                             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �Ǎ�_����ذ�ޓǍ�(�����d�����M)(��ފ֐�)
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">���������MIFð��ٸ׽</param>
    ''' <returns>�����׸�</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function MakeReturnTelegramRetFlag(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV) As String
        Dim intRet As RetCode
        Dim strMsg As String = ""       'ү����



        '**************************************************
        '�����ݒ�
        '**************************************************
        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)
        Dim strRetFlag As String = "_c5_c5"         '�����׸�


        '**************************************************
        '���qϽ�                �擾
        '**************************************************
        Dim objMST_SYARYOU As New TBL_XMST_SYARYOU(Owner, ObjDb, ObjDbLog)
        objMST_SYARYOU.XCARD_NO = objTLIF_TRNS_RECV.FDENBUN_PRM1           '���އ�
        intRet = objMST_SYARYOU.GET_XMST_SYARYOU(False)     '�擾
        If intRet = RetCode.OK Then
            '(���������ꍇ)

            If TO_INTEGER(objMST_SYARYOU.XLOADER_POSSIBLE) = FLAG_ON Then
                '(۰�ޑΉ��̏ꍇ)


                '**************************************************
                '���\����(�����\�ް��L��)
                '**************************************************
                Dim strSQL As String                'SQL��
                Dim objAryXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
                '������������************************************************************************************************************
                'JobMate:S.Ouchi 2014/01/20 ۰���ް� ����ԗ�����������t�Ή�
                '' ''strSQL = ""
                '' ''strSQL &= vbCrLf & "SELECT"
                '' ''strSQL &= vbCrLf & "    *"
                '' ''strSQL &= vbCrLf & " FROM"
                '' ''strSQL &= vbCrLf & "    XPLN_OUT"       '�o�׎w���ڍ�
                '' ''strSQL &= vbCrLf & " WHERE"
                '' ''strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '���q�ԍ�
                '' ''strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS <= " & TO_STRING(XSYUKKA_STS_JOUT)             '�o�׏�(�o�ɍ�)
                '' ''strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS >= " & TO_STRING(XSYUKKA_STS_JNON)             '�o�׏�(��t��)
                '' ''strSQL &= vbCrLf & " ORDER BY"
                '' ''strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D"                                                     '�o�ד�
                '' ''strSQL &= vbCrLf & "   ,XPLN_OUT.XUNKOU_NO"                                                     '�q�ɕʉ^�s��
                '' ''strSQL &= vbCrLf & "   ,XPLN_OUT.XHENSEI_NO"                                                    '�Ґ���
                '' ''strSQL &= vbCrLf & "   ,XPLN_OUT.XDENPYOU_NO"                                                   '�`�[��
                '' ''strSQL &= vbCrLf
                strSQL = ""
                strSQL &= vbCrLf & "SELECT"
                strSQL &= vbCrLf & "    *"
                strSQL &= vbCrLf & " FROM"
                strSQL &= vbCrLf & "    XPLN_OUT"       '�o�׎w���ڍ�
                strSQL &= vbCrLf & " WHERE"
                If objTLIF_TRNS_RECV.FDENBUN_PRM2 = "01" Then
                    strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '���q�ԍ�
                    strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS <= " & TO_STRING(XSYUKKA_STS_JOUT)             '�o�׏�(�o�ɍ�)
                    strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS >= " & TO_STRING(XSYUKKA_STS_JNON)             '�o�׏�(��t��)
                    strSQL &= vbCrLf & "    AND(XPLN_OUT.XBERTH_NO IS NULL"
                    strSQL &= vbCrLf & "     OR XPLN_OUT.XBERTH_NO IN ('" & XBERTH_NO_JX01 & "'," & _
                                                                      "'" & XBERTH_NO_JX02 & "'," & _
                                                                      "'" & XBERTH_NO_JX03 & "'," & _
                                                                      "'" & XBERTH_NO_JX04 & "'," & _
                                                                      "'" & XBERTH_NO_JX05 & "'," & _
                                                                      "'" & XBERTH_NO_JX06 & "'))"                  '�ް���(۰���ް�)
                Else
                    strSQL &= vbCrLf & "        XPLN_OUT.XSYARYOU_NO = " & TO_STRING(objMST_SYARYOU.XSYARYOU_NO)    '���q�ԍ�
                    strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS <= " & TO_STRING(XSYUKKA_STS_JOUT)             '�o�׏�(�o�ɍ�)
                    strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS >= " & TO_STRING(XSYUKKA_STS_JNON)             '�o�׏�(��t��)
                    strSQL &= vbCrLf & "    AND XPLN_OUT.XBERTH_NO IN ('" & XBERTH_NO_JX01 & "'," & _
                                                                      "'" & XBERTH_NO_JX02 & "'," & _
                                                                      "'" & XBERTH_NO_JX03 & "'," & _
                                                                      "'" & XBERTH_NO_JX04 & "'," & _
                                                                      "'" & XBERTH_NO_JX05 & "'," & _
                                                                      "'" & XBERTH_NO_JX06 & "')"                   '�ް���(۰���ް�)
                End If
                strSQL &= vbCrLf & " ORDER BY"
                strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D"                                                     '�o�ד�
                strSQL &= vbCrLf & "   ,XPLN_OUT.XUNKOU_NO"                                                     '�q�ɕʉ^�s��
                strSQL &= vbCrLf & "   ,XPLN_OUT.XHENSEI_NO"                                                    '�Ґ���
                strSQL &= vbCrLf & "   ,XPLN_OUT.XDENPYOU_NO"                                                   '�`�[��
                strSQL &= vbCrLf
                'JobMate:S.Ouchi 2014/01/20 ۰���ް� ����ԗ�����������t�Ή�
                '������������************************************************************************************************************
                objAryXPLN_OUT.USER_SQL = strSQL
                intRet = objAryXPLN_OUT.GET_XPLN_OUT_USER()
                If intRet = RetCode.OK Then
                    '(���������ꍇ)


                    Select Case objTLIF_TRNS_RECV.FDENBUN_PRM2
                        Case "01"
                            '**************************************************
                            '(���\��)
                            '**************************************************
                            If XSYUKKA_STS_JNON = objAryXPLN_OUT.ARYME(0).XSYUKKA_STS Then
                                '(���\�O�̏ꍇ)
                                strRetFlag = "_f0_f1"
                            Else
                                '(���\�O����Ȃ��ꍇ)
                                strMsg = "���\�s�̐i���ׁ̈A���\�o���܂���B[���އ�:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "][�ް���:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][����ذ�ދ敪:" & objTLIF_TRNS_RECV.FDENBUN_PRM2 & "][�o�׏�:" & TO_STRING(objAryXPLN_OUT.ARYME(0).XSYUKKA_STS) & "]"
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
                                strMsg = "�o�\�s�̐i���ׁ̈A�o�\�o���܂���B[���އ�:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "][�ް���:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][����ذ�ދ敪:" & objTLIF_TRNS_RECV.FDENBUN_PRM2 & "][�o�׏�:" & TO_STRING(objAryXPLN_OUT.ARYME(0).XSYUKKA_STS) & "]"
                            End If


                        Case "04", "08", "10", "20", "40", "80"
                            '**************************************************
                            '(�ڎԎ�)
                            '**************************************************
                            '**************************************************
                            '�ް��̓���
                            '**************************************************
                            Dim strXBERTH_NO As String = ""
                            Select Case objTLIF_TRNS_RECV.FDENBUN_PRM2
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
                                    strMsg = "�ڎԕs�̐i���ׁ̈A�ڎԏo���܂���B[���އ�:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "][�ް���:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][����ذ�ދ敪:" & objTLIF_TRNS_RECV.FDENBUN_PRM2 & "][�o�׏�:" & TO_STRING(objAryXPLN_OUT.ARYME(0).XSYUKKA_STS) & "]"
                                End If
                            Else
                                '(�ް�������v���Ă��Ȃ��ꍇ)
                                strMsg = "�ް�������v���Ă��܂���B[���އ�:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "][�ް���:" & objAryXPLN_OUT.ARYME(0).XBERTH_NO & "][����ذ�ދ敪:" & objTLIF_TRNS_RECV.FDENBUN_PRM2 & "]"
                            End If


                    End Select


                Else
                    '(������Ȃ������ꍇ)
                    strMsg = "�o�׎w�������݂��܂���B[���އ�:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "]"
                End If


            Else
                '(۰�ޖ��Ή��̏ꍇ)
                strMsg = "۰�ނɑΉ����Ă��Ȃ����q��t���s���܂����B[���އ�:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "]"
            End If


        Else
            '(������Ȃ��ꍇ)
            strMsg = "���qϽ���������܂���B[���އ�:" & objTLIF_TRNS_RECV.FDENBUN_PRM1 & "]"
        End If
        If IsNotNull(strMsg) Then
            Call AddToMsgLog(Now, FMSG_ID_J5003, strMsg)
        End If


        '**************************************************
        '���M�d��               �ݒ�
        '**************************************************
        Return strRetFlag


    End Function
#End Region

    '������������************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/15 CW6�ǉ��Ή� ������������
#Region "  CW6�֘A�ݔ���ԍX�V���m����                                                          "
    ''' <summary>
    ''' CW6�֘A�ݔ���ԍX�V���m����
    ''' </summary>
    ''' <param name="objTLIF_TRNS_RECV">���������MIFð��ٸ׽</param>
    ''' <param name="objTSTS_EQ_CTRL">�ݔ���ð��ٸ׽</param>
    ''' <remarks></remarks>
    Private Sub CW6_Status_Change(ByVal objTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV, ByVal objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL)
        Try
            Dim intRet As RetCode
            Dim objXMST_DPL_PL As New TBL_XMST_DPL_PL(Owner, ObjDb, ObjDbLog)

            '************************************************************************
            '�N����Ԑݒ�
            '************************************************************************
            '************************************************
            '�N��ANS(D5514[Bit00]�`) �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_KIDO = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '�N��ANS(D5514[Bit00]�`) ��ԕω�����(�N����Ԑݒ�)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.KidouStatusCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '��ײ�ANS(D5514[Bit01]�`) �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_ONLN = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '��ײ�ANS(D5514[Bit01]�`) ��ԕω�����(�N����Ԑݒ�)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.KidouStatusCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '��ײ�ANS(D5514[Bit02]�`) �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_OFLN = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '��ײ�ANS(D5514[Bit02]�`) ��ԕω�����(�N����Ԑݒ�)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.KidouStatusCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '�ϕt����ݐݒ��v(D5514[Bit05]�`) �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_PLPT = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '�ϕt����ݐݒ��v(D5514[Bit05]�`) ��ԕω�����(�N����Ԑݒ�)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.KidouStatusCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '�N���\(D5514[Bit06]�`) �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_REDY = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '�N���\(D5514[Bit06]�`) ��ԕω�����(�N����Ԑݒ�)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.KidouStatusCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '�I���v��(D5514[Bit07]�`) �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_SYRY = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '�I���v��(D5514[Bit07]�`) ��ԕω�����(�N����Ԑݒ�)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.KidouStatusCheck(objXMST_DPL_PL)

                Exit Sub
            End If



            '************************************************************************
            '�ر���菈��
            '************************************************************************
            '************************************************
            '�ް��ر(D5500[Bit03]�`)    �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_STCL = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '�ް��ر(D5500[Bit03]�`) ��ԕω�����(�ر���菈��)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '���Y��گĐ�(D5063�`)       �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_PL = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '���Y��گĐ�(D5063�`) ��ԕω�����(�ر���菈��)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '�[���ް�(D5064�`)       �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_HASU = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '�[���ް�(D5064�`) ��ԕω�����(�ر���菈��)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '����َ���(��)(D5065�`) �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_TRBL_HH = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '����َ���(��)(D5065�`) ��ԕω�����(�ر���菈��)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '����َ���(��)(D5066�`) �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_TRBL_MM = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '����َ���(��)(D5066�`) ��ԕω�����(�ر���菈��)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '����َ���(�b)(D5067�`) �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_TRBL_SS = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '����َ���(�b)(D5067�`) ��ԕω�����(�ر���菈��)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '����ٌ���(D5068�`) �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_TRBL = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '����ٌ���(D5068�`) ��ԕω�����(�ر���菈��)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '�ϕt��(D5069�`) �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_COUNT = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '�ϕt��(D5069�`) ��ԕω�����(�ر���菈��)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '�^�]����(��)(D5201�`) �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_KADOU_HH = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '�^�]����(��)(D5201�`) ��ԕω�����(�ر���菈��)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '�^�]����(��)(D5202�`) �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_KADOU_MM = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '�^�]����(��)(D5202�`) ��ԕω�����(�ر���菈��)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

            '************************************************
            '�^�]����(�b)(D5203�`) �ݔ�ID����
            '************************************************
            objXMST_DPL_PL.CLEAR_PROPERTY()
            objXMST_DPL_PL.XDPL_PL_EQ_ID_KADOU_SS = objTSTS_EQ_CTRL.FEQ_ID
            intRet = objXMST_DPL_PL.GET_XMST_DPL_PL(False)
            If intRet = RetCode.OK Then
                '************************************************
                '�^�]����(�b)(D5203�`) ��ԕω�����(�ر���菈��)
                '************************************************
                Dim objCmd As New SVR_400901(Owner, ObjDb, ObjDbLog)
                Call objCmd.ClearCheck(objXMST_DPL_PL)

                Exit Sub
            End If

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region
    'JobMate:S.Ouchi 2015/07/15 CW6�ǉ��Ή� ������������
    '������������************************************************************************************************************

    '���������ьŗL
    '**********************************************************************************************



End Class
