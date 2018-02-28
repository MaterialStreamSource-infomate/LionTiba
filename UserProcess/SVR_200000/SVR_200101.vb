'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zү���ފm�F
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_200101
    Inherits clsTemplateServer

#Region "  �׽���������p�萔��`                                                                "

    '�d������p
    Private Const DSPTERM_ID As Integer = 0     '�[��ID
    Private Const DSPUSER_ID As Integer = 1     'հ�ްID
    Private Const DSPREASON As Integer = 2      '���R
    Private Const DSPLOG_NO As Integer = 3      '۸އ�
    Private Const DSPMSG_ID As Integer = 4      'ү����ID

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
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '���M�p�d��
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '��M�p�d��
        Dim strDenbunDtl(0) As String           '�d������z��
        Dim strDenbunDtlName(0) As String       '�d�����𖼏̔z��
        Dim strDenbunInfo As String = ""        '�d�����Ұ�۸ޗp������
        'Dim intRet As Integer                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            '************************
            '��������
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call CheckBeforeAct(strDenbunDtl)


            '************************
            'ү����۸ލX�V
            '************************
            Dim objTLOG_MESSAGE As New TBL_TLOG_MESSAGE(Owner, ObjDb, ObjDbLog) 'ү����۸�
            If Trim(strDenbunDtl(DSPLOG_NO)) <> CBO_ALL_VALUE Then
                objTLOG_MESSAGE.FLOG_NO = strDenbunDtl(DSPLOG_NO)               '۸އ�
            End If
            objTLOG_MESSAGE.FLOG_CHECK_DT = Now                                 '�m�F����
            objTLOG_MESSAGE.FUSER_ID = strDenbunDtl(DSPUSER_ID)                 'հ�ްID
            objTLOG_MESSAGE.UPDATE_TLOG_MESSAGE_CHECK()                         '�X�V


            '************************
            'ү���ފm�F���ꏈ��
            '************************
            Call Special(strDenbunDtl(DSPMSG_ID))


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
            If strDenbunDtl(DSPTERM_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[�[��ID]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPUSER_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[հ�ްID]"
                Throw New UserException(strMsg)
                'ElseIf strDenbunDtl(DSPLOG_NO) = DEFAULT_STRING Then
                '    strMsg = ERRMSG_DISP_SOCKET & "[۸އ�]"
                '    Throw New UserException(strMsg)
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
#Region "  ���ꏈ��                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��
    ''' </summary>
    ''' <param name="strMSG_ID">���ē��e</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Special(ByVal strMSG_ID As String)
        Try
            '' ''Dim intRet As RetCode                   '�߂�l
            '' ''Dim strMsg As String                    'ү����


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/09/05 �ُ��ޯčX�V


            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_J340011)                           '�N��


            '������������************************************************************************************************************


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
    '���������ьŗL
    '**********************************************************************************************

End Class
