'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z���ђ萔�ύX
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_200601
    Inherits clsTemplateServer

#Region "  �׽���������p�萔��`                                                                "

    '�d������p
    Private Const DSPTERM_ID As Integer = 0             '�[��ID
    Private Const DSPUSER_ID As Integer = 1             'հ�ްID
    Private Const DSPREASON As Integer = 2              '���R
    Private Const DSPHENSU_ID As Integer = 3            '�ϐ�ID
    Private Const DSPHENSU_DATA As Integer = 4          '�ύX�ް�

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
        Dim intRet As RetCode                   '�߂�l
        'Dim strMsg As String                    'ү����
        Try


            '************************
            '��������
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call Check_BeforeAct(strDenbunDtl)


            '************************
            '���ѕϐ�����ݽ
            '************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog) '���ѕϐ��׽
            objTPRG_SYS_HEN.FHENSU_ID = strDenbunDtl(DSPHENSU_ID)               '�ϐ�ID
            intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                     '����
            objTPRG_SYS_HEN.OBJCHANGE_DATA = strDenbunDtl(DSPHENSU_DATA)        '�ύX�ް�
            objTPRG_SYS_HEN.UPDATE_TPRG_SYS_HEN_OBJ()                           '�X�V



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
    Private Sub Check_BeforeAct(ByVal strDenbunDtl() As String)
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
            ElseIf strDenbunDtl(DSPHENSU_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[�ϐ�ID]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPHENSU_DATA) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[�ύX�ް�]"
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
