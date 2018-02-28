'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�ׯ�ݸދ�������
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_200501
    Inherits clsTemplateServer

#Region "  �׽���������p�萔��`                                                                "

    '�d������p
    Private Const DSPTERM_ID As Integer = 0         '�[��ID
    Private Const DSPUSER_ID As Integer = 1         'հ�ްID
    Private Const DSPREASON As Integer = 2          '���R
    Private Const DSPTRK_BUF_NO As Integer = 3      '�ޯ̧��
    Private Const DSPTRK_BUF_ARRAY As Integer = 4   '�ޯ̧�z��
    Private Const DSPPALLET_ID As Integer = 5       '��گ�ID

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
#Region "  �\���̒�`                                                                           "
    ''' <summary>�d�����e</summary>
    Private Structure DENBUN_DTL
        Dim DSPTERM_ID As String            '�[��ID
        Dim DSPUSER_ID As String            'հ�ްID
        Dim DSPTRK_BUF_NO As String         '�ޯ̧��
        Dim DSPTRK_BUF_ARRAY As String      '�ޯ̧�z��
        Dim DSPPALLET_ID As String          '��گ�ID
    End Structure
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
        Dim strDenbunDtl(0) As String          '�d������z��
        Dim strDenbunDtlName(0) As String      '�d�����𖼏̔z��
        Dim strDenbunInfo As String = ""       '�d�����Ұ�۸ޗp������
        Dim intRet As Integer                  '�߂�l
        'Dim strMsg As String                   'ү����
        Try


            '************************
            '��������
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call CheckBeforeAct(strDenbunDtl)


            '������������************************************************************************************************************
            'JobmMate:N.Dounoshita 2013/04/02  �߱�����̏ꍇ�́A��������گĂ���������������B


            '************************
            '�����w��QUE    �擾
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '�ݽ�ݽ��
            objTPLN_CARRY_QUE.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)               '��گ�ID
            objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)                             '�擾


            Select Case TO_INTEGER(strDenbunDtl(DSPTRK_BUF_NO))
                Case FTRK_BUF_NO_J3401 _
                   , FTRK_BUF_NO_J3402
                    '(�o�ɔ������̏ꍇ)


                    '***********************************************
                    '�\�萔ϲŽ1
                    '***********************************************
                    Call UpdateYoteiNumMinus1(TO_INTEGER(strDenbunDtl(DSPTRK_BUF_NO)), strDenbunDtl(DSPPALLET_ID), IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE))


            End Select


            '������������************************************************************************************************************


            '************************
            '�ׯ�ݸ�Ͻ��̓���
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧Ͻ��׽
            objTMST_TRK.FTRK_BUF_NO = strDenbunDtl(DSPTRK_BUF_NO)       '�ׯ�ݸ��ޯ̧No
            intRet = objTMST_TRK.GET_TMST_TRK(True)                     '����


            '************************
            '�ׯ�ݸ��ޯ̧���̏�����
            '************************
            Dim intBufNo As Integer
            intBufNo = strDenbunDtl(DSPTRK_BUF_NO)

           
            '************************
            '�ׯ�ݸދ�������
            '************************
            Dim objSVR_100301 As New SVR_100301(Owner, ObjDb, ObjDbLog) '�ׯ�ݸދ��������׽
            objSVR_100301.FTRK_BUF_NO = intBufNo                        '�ޯ̧��
            objSVR_100301.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)       '��گ�ID
            objSVR_100301.MENTE_FINISH()                                '�ׯ�ݸދ�������


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/02  �߱�����̏ꍇ�́A��������گĂ���������������B


            If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                '(����������ꍇ)


                '************************
                '�ׯ�ݸ��ޯ̧       �擾
                '************************
                Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_RELAY.FPALLET_ID = objTPLN_CARRY_QUE.XPALLET_ID_AITE        '��گ�ID
                objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF()                                    '�擾
                If objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = intBufNo Then
                    '(�����ꏊ���ׯ�ݸނ������ꍇ)


                    '************************
                    '�ׯ�ݸދ�������
                    '************************
                    Dim objSVR_100301_Aite As New SVR_100301(Owner, ObjDb, ObjDbLog)    '�ׯ�ݸދ��������׽
                    objSVR_100301_Aite.FTRK_BUF_NO = intBufNo                           '�ޯ̧��
                    objSVR_100301_Aite.FPALLET_ID = objTPLN_CARRY_QUE.XPALLET_ID_AITE   '��گ�ID
                    objSVR_100301_Aite.MENTE_FINISH()                                   '�ׯ�ݸދ�������


                End If


            End If


            '������������************************************************************************************************************


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
            ElseIf strDenbunDtl(DSPTRK_BUF_NO) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[�ޯ̧��]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPTRK_BUF_ARRAY) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[�ޯ̧�z��]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPPALLET_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[��گ�ID]"
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
