'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�����ݔ����M�Ǎ�����
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_020151
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �ݽ�׸�                                                                              "
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
        'Dim strMsg As String                    'ү����
        Dim ii As Integer                       '����
        Try
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 '���ѕϐ�


            '************************
            '�������䑗�MIF�Ǎ���
            '************************
            Dim strENTRY_NO(0) As String        '�o�^No
            Dim strEQ_ID(0) As String           '�ݔ�ID
            intRet = Get_TrnsSend(strENTRY_NO, strEQ_ID)
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                Return RetCode.OK
            End If


            ''************************
            ''��������
            ''************************
            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            For ii = LBound(strENTRY_NO) + 1 To UBound(strENTRY_NO)
                '(ٰ��:�������w��)

                '************************
                '�������䑗�MIF�̓���
                '************************
                Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '���������MIF�׽
                objTLIF_TRNS_SEND.FENTRY_NO = strENTRY_NO(ii)                           '�o�^No
                objTLIF_TRNS_SEND.FEQ_ID = strEQ_ID(ii)                                 '�ݔ�ID
                intRet = objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND(True)                     '����

                Try


                    '******************************
                    '������M�ɂ�镪�򏈗�
                    '******************************
                    Select Case objTLIF_TRNS_SEND.FCOMMAND_ID
                        Case FCOMMAND_ID_SONLINE
                            '(��ײݗv��)
                            AddToLog("����t:��ײݗv��������M", "", LogType.INFO)
                            If TO_INTEGER(objTLIF_TRNS_SEND.FRES_CD_EQ) = 0 Then
                                '(���퉞���̏ꍇ)
                                Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL, objTLIF_TRNS_SEND.FEQ_ID)
                                objTSTS_EQ_CTRL.FEQ_CUT_STS = FEQ_CUT_STS_SOFF          '�ؗ����
                                objTSTS_EQ_CTRL.FUPDATE_DT = Now                        '�X�V����
                                objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()                   '�X�V
                            End If
                        Case FCOMMAND_ID_SOFFLINE
                            '(��ײݗv��)
                            If TO_INTEGER(objTLIF_TRNS_SEND.FRES_CD_EQ) = 0 Then
                                '(���퉞���̏ꍇ)
                                AddToLog("����t:��ײݗv��������M", "", LogType.INFO)
                                Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL, objTLIF_TRNS_SEND.FEQ_ID)
                                objTSTS_EQ_CTRL.FEQ_CUT_STS = FEQ_CUT_STS_SON           '�ؗ����
                                objTSTS_EQ_CTRL.FUPDATE_DT = Now                        '�X�V����
                                objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()                   '�X�V
                            End If

                        Case Else

                            Select Case objTLIF_TRNS_SEND.FEQ_ID
                                Case FEQ_ID_JSYS0000
                                Case FEQ_ID_JSYS0001
                                Case FEQ_ID_JSYS0002
                                Case FEQ_ID_JSYS0003
                                Case FEQ_ID_JSYS0004
                                Case FEQ_ID_JSYS0005
                                Case FEQ_ID_JSYS0006
                            End Select


                    End Select


                    '******************************
                    '������������
                    '******************************
                    Dim objTMST_RES_CD_EQ As New TBL_TMST_RES_CD_EQ(Owner, ObjDb, ObjDbLog)     '�������ޏ���Ͻ��׽
                    objTMST_RES_CD_EQ.FEQ_ID = objTLIF_TRNS_SEND.FEQ_ID                         '�ݔ�ID
                    objTMST_RES_CD_EQ.FDIRECTION = FDIRECTION_SSEND                             '����
                    If IsNull(objTLIF_TRNS_SEND.FRES_CD_EQ) = True Then
                        objTMST_RES_CD_EQ.FRES_CD_EQ = FRES_CD_EQ_SMCI_OK                       '�ݔ���������
                    Else
                        objTMST_RES_CD_EQ.FRES_CD_EQ = objTLIF_TRNS_SEND.FRES_CD_EQ             '�ݔ���������
                    End If
                    intRet = objTMST_RES_CD_EQ.GET_TMST_RES_CD_EQ(False)
                    If intRet = RetCode.OK Then
                        '(���������ꍇ)

                        '========================
                        'ү���ޏo��
                        '========================
                        If TO_INTEGER(objTMST_RES_CD_EQ.FMSG_FLAG) = FLAG_ON Then
                            '(ү����۸ޏo���׸ނ�ON�̏ꍇ)
                            Select Case objTLIF_TRNS_SEND.FEQ_ID
                                Case FEQ_ID_JSYS0000 : Call AddToMsgLog(Now, FMSG_ID_J6003, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "��������(�ýā�MELSEC):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0001 : Call AddToMsgLog(Now, FMSG_ID_J6103, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "��������(�ýā�SW01  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0002 : Call AddToMsgLog(Now, FMSG_ID_J6203, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "��������(�ýā�SW02  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0003 : Call AddToMsgLog(Now, FMSG_ID_J6303, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "��������(�ýā�SW03  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0004 : Call AddToMsgLog(Now, FMSG_ID_J6403, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "��������(�ýā�SW04  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0005 : Call AddToMsgLog(Now, FMSG_ID_J6503, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "��������(�ýā�SW05  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                Case FEQ_ID_JSYS0006 : Call AddToMsgLog(Now, FMSG_ID_J6603, objTMST_RES_CD_EQ.FRES_CD_EQ_NAME, "��������(�ýā�SW04A ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
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
                            objTSTS_EQ_CTRL.FEQ_ID = objTLIF_TRNS_SEND.FEQ_ID                       '�ݔ�ID
                            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)          '����
                            objTSTS_EQ_CTRL.FEQ_CUT_STS = FLAG_ON           '�ؗ����
                            objTSTS_EQ_CTRL.FUPDATE_DT = Now                '�X�V����
                            objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()           '�X�V

                            '========================
                            '�������䑗�MIF�̍X�V
                            '========================
                            objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_STRY    '�i�����
                            objTLIF_TRNS_SEND.FRES_CD_EQ = DEFAULT_STRING   '�ݔ���������
                            objTLIF_TRNS_SEND.FUPDATE_DT = Now              '�X�V����
                            objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()       '�X�V

                        End If


                    Else
                        '(������Ȃ������ꍇ)

                        '========================
                        'ү���ޏo��
                        '========================
                        Select Case objTLIF_TRNS_SEND.FEQ_ID
                            '������������************************************************************************************************************
                            'SystemMate:N.Dounoshita 2011/11/22 ү���ނ�ύX
                            Case FEQ_ID_JSYS0000 : Call AddToMsgLog(Now, FMSG_ID_J6003, "�ُ퉞�����ޑ��M�B", "��������(�ýā�MELSEC):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0001 : Call AddToMsgLog(Now, FMSG_ID_J6103, "�ُ퉞�����ޑ��M�B", "��������(�ýā�SW01  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0002 : Call AddToMsgLog(Now, FMSG_ID_J6203, "�ُ퉞�����ޑ��M�B", "��������(�ýā�SW02  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0003 : Call AddToMsgLog(Now, FMSG_ID_J6303, "�ُ퉞�����ޑ��M�B", "��������(�ýā�SW03  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0004 : Call AddToMsgLog(Now, FMSG_ID_J6403, "�ُ퉞�����ޑ��M�B", "��������(�ýā�SW04  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0005 : Call AddToMsgLog(Now, FMSG_ID_J6503, "�ُ퉞�����ޑ��M�B", "��������(�ýā�SW05  ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                            Case FEQ_ID_JSYS0006 : Call AddToMsgLog(Now, FMSG_ID_J6603, "�ُ퉞�����ޑ��M�B", "��������(�ýā�SW04A ):" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                'Case FEQ_ID_SYS0001 : Call AddToMsgLog(Now, FMSG_ID_J6103, "�s���ȉ������ނ���M���܂����B", "��������:" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                'Case FEQ_ID_SYS0002 : Call AddToMsgLog(Now, FMSG_ID_J6203, "�s���ȉ������ނ���M���܂����B", "��������:" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                'Case FEQ_ID_SYS0003 : Call AddToMsgLog(Now, FMSG_ID_J6303, "�s���ȉ������ނ���M���܂����B", "��������:" & objTLIF_TRNS_SEND.FRES_CD_EQ)
                                '������������************************************************************************************************************
                        End Select


                        '������������************************************************************************************************************
                        'SystemMate:N.Dounoshita 2012/05/24  �������ނ��ُ�̎��́A�u�������ޕs������ײݐؑ��׸ށv�̔��肪�s����悤�ɏC��

                        If TO_DECIMAL(objTPRG_SYS_HEN.SS000000_020) = FLAG_ON Then

                            '========================
                            '�ݔ��󋵂̍X�V
                            '========================
                            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     '�ݔ��󋵸׽
                            objTSTS_EQ_CTRL.FEQ_ID = objTLIF_TRNS_SEND.FEQ_ID                       '�ݔ�ID
                            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                                      '����
                            objTSTS_EQ_CTRL.FEQ_CUT_STS = FLAG_ON           '�ؗ����
                            objTSTS_EQ_CTRL.FUPDATE_DT = Now                '�X�V����
                            objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()           '�X�V

                        End If

                        '������������************************************************************************************************************


                        '========================
                        '�������䑗�MIF�̍X�V
                        '========================
                        objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_STRY     '�i�����
                        objTLIF_TRNS_SEND.FRES_CD_EQ = DEFAULT_STRING   '�ݔ���������
                        objTLIF_TRNS_SEND.FUPDATE_DT = Now              '�X�V����
                        objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()       '�X�V


                    End If


                    '========================
                    '�ݔ��ؗ�
                    '========================
                    If TO_INTEGER(objTLIF_TRNS_SEND.FPROGRESS) = FPROGRESS_STIMEOUT Or _
                       TO_INTEGER(objTLIF_TRNS_SEND.FPROGRESS) = FPROGRESS_SERR_MCI Or _
                       TO_INTEGER(objTLIF_TRNS_SEND.FPROGRESS) = FPROGRESS_SERR_SVR _
                       Then
                        '(�ʐM�ُ�̏ꍇ)

                        Select Case objTLIF_TRNS_SEND.FEQ_ID
                            Case FEQ_ID_JSYS0000 : Call AddToMsgLog(Now, FMSG_ID_J6003, "�ʐM��۸��сA�������ͻ�����۾��Ŵװ���������܂����B")
                            Case FEQ_ID_JSYS0001 : Call AddToMsgLog(Now, FMSG_ID_J6103, "�ʐM��۸��сA�������ͻ�����۾��Ŵװ���������܂����B")
                            Case FEQ_ID_JSYS0002 : Call AddToMsgLog(Now, FMSG_ID_J6203, "�ʐM��۸��сA�������ͻ�����۾��Ŵװ���������܂����B")
                            Case FEQ_ID_JSYS0003 : Call AddToMsgLog(Now, FMSG_ID_J6303, "�ʐM��۸��сA�������ͻ�����۾��Ŵװ���������܂����B")
                            Case FEQ_ID_JSYS0004 : Call AddToMsgLog(Now, FMSG_ID_J6403, "�ʐM��۸��сA�������ͻ�����۾��Ŵװ���������܂����B")
                            Case FEQ_ID_JSYS0005 : Call AddToMsgLog(Now, FMSG_ID_J6503, "�ʐM��۸��сA�������ͻ�����۾��Ŵװ���������܂����B")
                            Case FEQ_ID_JSYS0006 : Call AddToMsgLog(Now, FMSG_ID_J6603, "�ʐM��۸��сA�������ͻ�����۾��Ŵװ���������܂����B")
                        End Select


                        If TO_DECIMAL(objTPRG_SYS_HEN.SS000000_016) = FLAG_ON Then

                            '========================
                            '�ݔ��󋵂̍X�V
                            '========================
                            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)     '�ݔ��󋵸׽
                            objTSTS_EQ_CTRL.FEQ_ID = objTLIF_TRNS_SEND.FEQ_ID                       '�ݔ�ID
                            intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)                         '����
                            objTSTS_EQ_CTRL.FEQ_CUT_STS = FLAG_ON           '�ؗ����
                            objTSTS_EQ_CTRL.FUPDATE_DT = Now                '�X�V����
                            objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()           '�X�V

                        End If

                        If TO_DECIMAL(objTPRG_SYS_HEN.SS000000_017) <> FLAG_ON Then
                            '========================
                            '�������䑗�MIF�̍X�V
                            '========================
                            objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_STRY     '�i�����
                            objTLIF_TRNS_SEND.FRES_CD_EQ = DEFAULT_STRING   '�ݔ���������
                            objTLIF_TRNS_SEND.FUPDATE_DT = Now              '�X�V����
                            objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()       '�X�V
                        End If

                    End If


                    '************************
                    '�������䑗�MIF�̍폜
                    '************************
                    If TO_INTEGER(objTLIF_TRNS_SEND.FPROGRESS) <> FPROGRESS_STRY Then
                        '(�i����Ԃ��đ��M�҂��ɂȂ��Ă��Ȃ��ꍇ)
                        objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND()       '�폜
                    End If


                Catch ex As UserException
                    Call ComUser(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    '۰��ޯ�
                    ObjDb.BeginTrans()                                  '��ݻ޸��݊J�n
                    objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SERR_SVR     '�i�����(�ُ�)
                    objTLIF_TRNS_SEND.FUPDATE_DT = Now                  '�X�V����
                    objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()           '�X�V
                Catch ex As Exception
                    Call ComError(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    '۰��ޯ�
                    ObjDb.BeginTrans()                                  '��ݻ޸��݊J�n
                    objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SERR_SVR     '�i�����(�ُ�)
                    objTLIF_TRNS_SEND.FUPDATE_DT = Now                  '�X�V����
                    objTLIF_TRNS_SEND.UPDATE_TLIF_TRNS_SEND()           '�X�V
                Finally
                    ObjDb.Commit()      '�Я�
                    ObjDb.BeginTrans()  '��ݻ޸��݊J�n
                End Try
            Next


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
#Region "  �������䑗�MIF�Ǎ���                                                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �������䑗�MIF�Ǎ���
    ''' </summary>
    ''' <param name="strEntry_no">�o�^No(�z��)</param>
    ''' <param name="strEQ_ID">�o�^No(�z��)</param>
    ''' <returns>OK/NotFound</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Get_TrnsSend(ByRef strEntry_no() As String, ByRef strEQ_ID() As String) As RetCode
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
            strSQL &= vbCrLf & "    FENTRY_NO"                  '�o�^No
            strSQL &= vbCrLf & "  , FEQ_ID"                     '�ݔ�ID
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TLIF_TRNS_SEND "            '�������䑗�MIF
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FPROGRESS <> " & FPROGRESS_SNON      '�i�����
            strSQL &= vbCrLf & "    AND FPROGRESS <> " & FPROGRESS_SACT      '�i�����
            strSQL &= vbCrLf & "    AND FPROGRESS <> " & FPROGRESS_STRY      '�i�����
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    FENTRY_NO"                  '�o�^No
            strSQL &= vbCrLf


            '************************
            '���o
            '************************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TLIF_TRNS_SEND"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For ii = 1 To objDataSet.Tables(strDataSetName).Rows.Count
                    objRow = objDataSet.Tables(strDataSetName).Rows(ii - 1)
                    ReDim Preserve strEntry_no(ii)
                    strEntry_no(ii) = TO_STRING(objRow("FENTRY_NO"))    '�o�^No
                    ReDim Preserve strEQ_ID(ii)
                    strEQ_ID(ii) = TO_STRING(objRow("FEQ_ID"))          '�ݔ�ID
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

    'MCV
#Region "  MCV�d�����M����  [ID:B7      (���o��Ӱ�ސؑ֎w��)]                                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' MCV�d�����M����  [ID:B7      (���o��Ӱ�ސؑ֎w��)]
    ''' </summary>
    ''' <param name="objTLIF_TRNS_SEND">�������䑗�MIFð��ٸ׽</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function MCVTelRecvB7(ByVal objTLIF_TRNS_SEND As TBL_TLIF_TRNS_SEND) As RetCode
        'Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            '************************
            '��������
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART & "[MCV][���o��Ӱ�ސؑ֎w��]  [���M�d��:" & objTLIF_TRNS_SEND.FDENBUN & "]")


            '*****************************************************
            '��M�d������
            '*****************************************************
            Dim objTel As New clsTelegram(CONFIG_TELEGRAM_MCV)
            objTel.FORMAT_ID = FORMAT_MCV_B7                        '̫�ϯĖ����
            objTel.TELEGRAM_PARTITION = objTLIF_TRNS_SEND.FDENBUN   '��������d�����
            objTel.PARTITION()                                      '�d������
            Dim strMCVPOINT_NO As String = Trim(objTel.SELECT_DATA("MCVPOINT_NO"))          '�߲�ć�
            Dim strMCVMODE_SIZI As String = Trim(objTel.SELECT_DATA("MCVMODE_SIZI"))        'Ӱ�ގw��


            '*****************************************************
            '�ݔ���       �擾
            '*****************************************************
            Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            objTSTS_EQ_CTRL.FEQ_ID_LOCAL = strMCVPOINT_NO       '۰�ِݔ�ID
            objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                  '�擾


            '*****************************************************
            '�v���׸�       �X�V
            '*****************************************************
            Call Set_FEQ_REQ_STS(objTSTS_EQ_CTRL.FEQ_ID, FEQ_REQ_STS_SOFF)                  '�v���׸�OFF


            '*****************************************************
            '�ݔ���������   �ݒ� 
            '*****************************************************
            Call Set_XSTS_EQ_CTRL_DTL_FRES_CD_EQ(objTSTS_EQ_CTRL.FEQ_ID, objTLIF_TRNS_SEND.FRES_CD_EQ)      '�ݔ��󋵏ڍ�     �ݔ��������ސݒ� 


            '************************
            '���튮��
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL)


            Return RetCode.OK
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region

    '���������ьŗL
    '**********************************************************************************************

End Class
