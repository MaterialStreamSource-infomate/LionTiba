'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z���Ұ��ʒm
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_200001
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "

    '�d������p
    Private Const DSPTERM_ID As Integer = 0         '�[��ID
    Private Const DSPUSER_ID As Integer = 1         'հ�ްID
    Private Const DSPREASON As Integer = 2          '���R
    Private Const DSPPARA_ID As Integer = 3         '���Ұ�ID

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
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '���M�p�d��
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '��M�p�d��
        Dim strDenbunDtl(0) As String         '�d������z��
        Dim strDenbunDtlName(0) As String     '�d�����𖼏̔z��
        Dim strDenbunInfo As String = ""      '�d�����Ұ�۸ޗp������
        Dim intRet As Integer                 '�߂�l
        Dim strMsg As String                  'ү����
        Try


            '************************
            '��������
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call CheckBeforeAct(strDenbunDtl)


            '************************
            '���Ұ�ð��َ擾
            '************************
            Dim strSQL As String
            Dim objTPRG_PARAM_TBL As New TBL_TPRG_PARAM_TBL(Owner, ObjDb, ObjDbLog) '���Ұ�ð���
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "   * "
            strSQL &= vbCrLf & "FROM "
            strSQL &= vbCrLf & "   TPRG_PARAM_TBL "
            strSQL &= vbCrLf & "WHERE "
            strSQL &= vbCrLf & "       FPARA_ID = '" & strDenbunDtl(DSPPARA_ID) & "'"   '���Ұ�ID
            strSQL &= vbCrLf & "ORDER BY "
            strSQL &= vbCrLf & "   FPARA_EDA_NO "                                       '���Ұ��}��
            strSQL &= vbCrLf
            objTPRG_PARAM_TBL.USER_SQL = strSQL                  'SQL���ݒ�
            intRet = objTPRG_PARAM_TBL.GET_TPRG_PARAM_TBL_USER()    '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_PARAM_TBL
                strMsg &= "[���Ұ�ID:" & strDenbunDtl(DSPPARA_ID) & "]"
                Throw New UserException(strMsg)
            End If

        
           

            For ii As Integer = LBound(objTPRG_PARAM_TBL.ARYME) To UBound(objTPRG_PARAM_TBL.ARYME)
                '(�擾����ں��ސ�)

                Dim msgRecv As String = ""
                Dim msgSend As String = ""
                Try
                    Dim rtn As Integer = RetCode.OK
                    Dim rtn2 As Integer = RetCode.OK


                    '************************
                    'ү���ސݒ�
                    '************************
                    objTelegramRecvDSP.FORMAT_ID = "DSP_000000"                 '̫�ϯĖ����
                    objTelegramRecvDSP.TELEGRAM_PARTITION = objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA      '��������d�����
                    objTelegramRecvDSP.PARTITION()                              '�d������


                    '************************
                    '�����ID�̓���
                    '************************
                    Dim strCMD_ID As String
                    strCMD_ID = objTelegramRecvDSP.SELECT_HEADER("DSPCMD_ID")
                    strCMD_ID = Trim(strCMD_ID)


                    '************************
                    '����ޏ���
                    '************************
                    msgRecv = objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA
                    msgSend = objTPRG_PARAM_TBL.ARYME(ii).FRECV_DATA
                    Select Case strCMD_ID
                        Case FSYORI_ID_S201601
                            '�⍇���o��
                            '������������************************************************************************************************************
                            'SystemMate:N.Dounoshita 2013/04/01  �o�Ɏ��ɂ͗\�萔��ݒ肵�Ȃ���΂Ȃ�Ȃ��̂ŁA�S�Ă̏������������Ă���Я�or۰��ޯ�����
                            'Dim objCmd As New SVR_201601(Owner, ObjDb, ObjDbLog)
                            'rtn = objCmd.ExecCmd(msgRecv, msgSend)
                            '������������************************************************************************************************************


                            '������������************************************************************************************************************
                            'JobMate:N.Dounoshita 2012/04/24 ���Ұ��ʒm


                            'Case FSYORI_ID_J400501
                            '    '�q�ւ��o�^
                            '    Dim objCmd As New SVR_400501(Owner, ObjDb, ObjDbLog)
                            '    rtn = objCmd.ExecCmd(msgRecv, msgSend)


                            '������������************************************************************************************************************

                        Case Else

                    End Select

                    '************************
                    '�װ����
                    '************************
                    If rtn = RetCode.NG Or rtn2 = RetCode.NG Then
                        '(�ُ�I���̏ꍇ)
                        strMsg = ERRMSG_DISP_PARAM
                        Throw New UserException(strMsg)
                    End If


                Catch ex As UserException
                    Call ComUser(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    '۰��ޯ�
                    ObjDb.BeginTrans()                                  '��ݻ޸��݊J�n

                Catch ex As Exception
                    Call ComError(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    '۰��ޯ�
                    ObjDb.BeginTrans()                                  '��ݻ޸��݊J�n
                Finally
                    objTPRG_PARAM_TBL.ARYME(ii).FRECV_DATA = msgSend     '��M�d��
                    objTPRG_PARAM_TBL.ARYME(ii).FUPDATE_DT = Now         '�X�V����
                    objTPRG_PARAM_TBL.ARYME(ii).UPDATE_TPRG_PARAM_TBL()  '�X�V
                    ObjDb.Commit()      '�Я�
                    ObjDb.BeginTrans()  '��ݻ޸��݊J�n
                End Try
            Next
            objTPRG_PARAM_TBL.ARYME_CLEAR()

            '************************
            '���튮��
            '************************
            Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)


            Return RetCode.OK




        Catch ex As UserException
            Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ex.Message)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
            Call ComUser(ex, MeSyoriID)
            Return RetCode.NG
        Catch ex As Exception
            Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ERRMSG_DISP_ERR)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
            Call ComError(ex, MeSyoriID)
            Return RetCode.NG
        End Try
    End Function

#End Region
#Region "  ���O����                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���O����
    ''' </summary>
    ''' <param name="strDenbunDtl">�d�����e�\����</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub CheckBeforeAct(ByVal strDenbunDtl() As String)
        Try
            'Dim intRet As Integer                   '�߂�l
            Dim strMsg As String                    'ү����


            '************************
            '�l�R������
            '************************
            If 1 = 1 Then
            ElseIf strDenbunDtl(DSPTERM_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[�[��ID]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPUSER_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[հ�ްID]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPPARA_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[���Ұ�ID]"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '���������ьŗL

    '���������ьŗL
    '**********************************************************************************************

End Class
