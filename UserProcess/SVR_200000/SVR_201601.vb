'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�⍇���o��
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_201601
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "

    '�d������p
    Private Const DSPTERM_ID As Integer = 0         '�[��ID
    Private Const DSPUSER_ID As Integer = 1         'հ�ްID
    Private Const DSPREASON As Integer = 2          '���R
    Private Const DSPPALLET_ID As Integer = 3       '��گ�ID
    Private Const DSPST_OUT As Integer = 4          '�o�ɐ�ST
    Private Const XDSPPALLET_ID_KO As Integer = 5   '��گ�ID(�q)
    Private Const XDSPYOTEI_NUM As Integer = 6      '�\�萔
    Private Const XDSPYOTEI_EQ_ID As Integer = 7    '�\��ݔ�ID


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
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/04/01  �o�Ɏ��ɂ͗\�萔��ݒ肵�Ȃ���΂Ȃ�Ȃ��̂ŁA�S�Ă̏������������Ă���Я�or۰��ޯ�����
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
        Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����
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
            Dim objTPRG_PARAM_TBL As New TBL_TPRG_PARAM_TBL(Owner, ObjDb, ObjDbLog) '���Ұ�ð���
            objTPRG_PARAM_TBL.FPARA_ID = strDenbunDtl(DSPTERM_ID)       '���Ұ�ID
            intRet = objTPRG_PARAM_TBL.GET_TPRG_PARAM_TBL_FPARA_ID()    '����
            If intRet = RetCode.OK Then
                For ii As Integer = LBound(objTPRG_PARAM_TBL.ARYME) To UBound(objTPRG_PARAM_TBL.ARYME)
                    '(ٰ��:�擾����ں��ސ�)


                    Dim objTel As New clsTelegram(CONFIG_TELEGRAM_DSP)  '��M�p�d��
                    objTel.FORMAT_ID = MeDSPID                          '̫�ϯĖ����
                    objTel.TELEGRAM_PARTITION = objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA      '��������d�����
                    objTel.PARTITION()                                  '�d������


                    If IsNull(Trim(objTel.SELECT_DATA("XDSPYOTEI_NUM"))) And IsNull(Trim(objTel.SELECT_DATA("XDSPYOTEI_EQ_ID"))) Then
                        '(�\�萔�A�\��ݔ�ID���ݒ肳��Ă��Ȃ��ꍇ)


                        '************************
                        '�ׯ�ݸ��ޯ̧�̓���
                        '************************
                        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)         '�ׯ�ݸ��ޯ̧�׽
                        objTPRG_TRK_BUF.FPALLET_ID = Trim(objTel.SELECT_DATA("DSPPALLET_ID"))       '��گ�ID
                        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)                             '����
                        If intRet = RetCode.OK And objTPRG_TRK_BUF.FTRK_BUF_NO = FTRK_BUF_NO_J9000 Then
                            '(�o�Ɍ����A�����q�ɂ̏ꍇ)


                            '************************************************
                            'Ҳݏ���11(�o���ׯ�ݸލ쐬)
                            '************************************************
                            intRet = ExecCmd11(objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA, strMSG_SEND)


                        Else
                            '(�o�Ɍ����A�����q�ɈȊO�̏ꍇ)


                            '************************************************
                            'Ҳݏ���21(���u���݌ɍ폜)
                            '************************************************
                            intRet = ExecCmd21(objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA, strMSG_SEND)


                        End If


                    Else
                        '(�\�萔�ݒ�̏ꍇ)


                        '************************************************
                        'Ҳݏ���12(�\�萔�ݒ�)
                        '************************************************
                        intRet = ExecCmd12(objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA, strMSG_SEND)
                        

                    End If


                Next
            End If
            objTPRG_PARAM_TBL.ARYME_CLEAR()


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
#Region "  Ҳݏ���11(�o���ׯ�ݸލ쐬)                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Ҳݏ���11(�o���ׯ�ݸލ쐬)
    ''' </summary>
    ''' <param name="strMSG_RECV">��M�d��</param>
    ''' <param name="strMSG_SEND">���M�d��</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecCmd11(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '���M�p�d��
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '��M�p�d��
        Dim strDenbunDtl(0) As String         '�d������z��
        Dim strDenbunDtlName(0) As String     '�d�����𖼏̔z��
        Dim strDenbunInfo As String = ""      '�d�����Ұ�۸ޗp������
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����


        '************************
        '��������
        '************************
        Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
        Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
        Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
        Call CheckBeforeAct(strDenbunDtl)


        For ii As Integer = 1 To 2
            '(ٰ��:�߱����)


            '************************************
            '��Ǝ��       �ݒ�
            '************************************
            Dim intFSAGYOU_KIND As Integer          '��Ǝ��
            Dim intXOYAKO_KUBUN As Integer          '�e�q�敪
            Dim strFPALLET_ID As String = ""        '�o����گ�ID
            Dim strXPALLET_ID_AITE As String = ""   '������گ�ID
            If ii = 1 Then
                '(1PL�ڂ̏ꍇ)
                If IsNotNull(strDenbunDtl(XDSPPALLET_ID_KO)) Then
                    intFSAGYOU_KIND = FSAGYOU_KIND_J71                  '��Ǝ��
                Else
                    intFSAGYOU_KIND = FSAGYOU_KIND_J72                  '��Ǝ��
                End If
                intXOYAKO_KUBUN = XOYAKO_KUBUN_JOYA                     '�e�q�敪
                strFPALLET_ID = strDenbunDtl(DSPPALLET_ID)              '�o����گ�ID
                strXPALLET_ID_AITE = strDenbunDtl(XDSPPALLET_ID_KO)     '������گ�ID
            ElseIf ii = 2 Then
                '(2PL�ڂ̏ꍇ)
                If IsNotNull(strDenbunDtl(XDSPPALLET_ID_KO)) Then
                    '(�q�̏o�ɂ�����ꍇ)
                    intFSAGYOU_KIND = FSAGYOU_KIND_J71                      '��Ǝ��
                    intXOYAKO_KUBUN = XOYAKO_KUBUN_JKO                      '�e�q�敪
                    strFPALLET_ID = strDenbunDtl(XDSPPALLET_ID_KO)          '�o����گ�ID
                    strXPALLET_ID_AITE = strDenbunDtl(DSPPALLET_ID)         '������گ�ID
                Else
                    '(�q�̏o�ɂ��Ȃ��ꍇ)
                    Exit For
                End If
            End If


            '************************************
            '�o���ׯ�ݸޒ�`�׽(��گ�ID�w��)
            '************************************
            Dim objSVR_100501 As New SVR_100501(Owner, ObjDb, ObjDbLog)
            objSVR_100501.FTRK_BUF_NO_TO = TO_INTEGER(strDenbunDtl(DSPST_OUT))          '�ׯ�ݸ��ޯ̧��(�o�ɐ��ׯ�ݸ�)
            objSVR_100501.FPALLET_ID = strFPALLET_ID                                    '��گ�ID
            objSVR_100501.FSAGYOU_KIND = intFSAGYOU_KIND                                '��Ǝ��
            objSVR_100501.FTERM_ID = strDenbunDtl(DSPTERM_ID)                           '�[��ID
            objSVR_100501.FUSER_ID = strDenbunDtl(DSPUSER_ID)                           'հ�ްID
            objSVR_100501.UPDATE_OUT_BUF(FTR_VOL_SFULL)                                 '��`


            '************************
            '�����w��QUE�̓���
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)         '�����w��QUE
            objTPLN_CARRY_QUE.FPALLET_ID = strFPALLET_ID                                    '��گ�ID
            objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                                          '����


            '************************
            '�����w��QUE�̍X�V
            '************************
            objTPLN_CARRY_QUE.XOYAKO_KUBUN = intXOYAKO_KUBUN            '�e�q�敪
            objTPLN_CARRY_QUE.XPALLET_ID_AITE = strXPALLET_ID_AITE      '������گ�ID
            objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                   '�X�V


        Next


        '************************
        '���튮��
        '************************
        Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
        Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
        Return RetCode.OK


    End Function
#End Region
#Region "  Ҳݏ���12(�\�萔�ݒ�)                                                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Ҳݏ���12(�\�萔�ݒ�)
    ''' </summary>
    ''' <param name="strMSG_RECV">��M�d��</param>
    ''' <param name="strMSG_SEND">���M�d��</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecCmd12(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '���M�p�d��
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '��M�p�d��
        Dim strDenbunDtl(0) As String         '�d������z��
        Dim strDenbunDtlName(0) As String     '�d�����𖼏̔z��
        Dim strDenbunInfo As String = ""      '�d�����Ұ�۸ޗp������
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����


        '************************
        '��������
        '************************
        Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
        Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
        Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
        Call CheckBeforeAct(strDenbunDtl)


        '************************************
        '�ׯ�ݸނ̓���
        '************************************
        Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        objTMST_TRK.FTRK_BUF_NO = strDenbunDtl(DSPST_OUT)       '�o�ɐ�ST
        objTMST_TRK.GET_TMST_TRK()                              '����


        ''************************************************************************
        ''۰�ِݔ�ID           �� �ݔ�ID(���MPLC)          �ϊ�
        ''************************************************************************
        'Dim strFEQ_ID As String
        'strFEQ_ID = GetXEQ_ID_SendFromFEQ_ID_LOCAL(objTMST_TRK.XADRS_YOTEI)


        If IsNotNull(objTMST_TRK.XADRS_YOTEI01) Then
            '(�\�萔��ݒ肷��ꍇ)


            '************************************************
            '�\�萔                       �擾
            '************************************************
            Dim intYotei01 As Integer = 0
            Dim intYotei02 As Integer = 0
            Call GetYoteiNum(objTMST_TRK, intYotei01, intYotei02)
            'Call CheckYoteiPalletNum(objTMST_TRK)


            '************************************************
            '����         �����\�萔
            '************************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            'objSVR_190001.FEQ_ID = strFEQ_ID                                '�ݔ�ID
            objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         '�����ID
            objSVR_190001.FTRNS_SERIAL = ""                                 '�����ره�
            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK.FTRK_BUF_NO _
                                                  , intYotei01 + TO_INTEGER(strDenbunDtl(XDSPYOTEI_NUM)) _
                                                  )


        End If


        '************************
        '���튮��
        '************************
        Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
        Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
        Return RetCode.OK


    End Function
#End Region
#Region "  Ҳݏ���21(���u���݌ɍ폜)                                                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Ҳݏ���21(���u���݌ɍ폜)
    ''' </summary>
    ''' <param name="strMSG_RECV">��M�d��</param>
    ''' <param name="strMSG_SEND">���M�d��</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecCmd21(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '���M�p�d��
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '��M�p�d��
        Dim strDenbunDtl(0) As String         '�d������z��
        Dim strDenbunDtlName(0) As String     '�d�����𖼏̔z��
        Dim strDenbunInfo As String = ""      '�d�����Ұ�۸ޗp������
        'Dim intRet As RetCode                 '�߂�l
        'Dim strMsg As String                  'ү����


        '************************
        '��������
        '************************
        Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
        Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
        Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
        Call CheckBeforeAct(strDenbunDtl)


        '************************
        '���u���݌ɍ폜
        '************************
        Call DeleteHiraoki(strDenbunDtl(DSPPALLET_ID) _
                         , FINOUT_STS_SOUT_END _
                         , FSAGYOU_KIND_SSYSTEM_MENTE_NON _
                         )


        '************************
        '���튮��
        '************************
        Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
        Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
        Return RetCode.OK


    End Function
#End Region

#Region "  Ҳݏ���                                                                          _old"
    '''' *******************************************************************************************************************
    '''' <summary>
    '''' Ҳݏ���
    '''' </summary>
    '''' <param name="strMSG_RECV">��M�d��</param>
    '''' <param name="strMSG_SEND">���M�d��</param>
    '''' <returns>OK/NG</returns>
    '''' <remarks></remarks>
    '''' *******************************************************************************************************************
    'Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
    '    Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '���M�p�d��
    '    Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '��M�p�d��
    '    Dim strDenbunDtl(0) As String         '�d������z��
    '    Dim strDenbunDtlName(0) As String     '�d�����𖼏̔z��
    '    Dim strDenbunInfo As String = ""      '�d�����Ұ�۸ޗp������
    '    Dim intRet As RetCode                 '�߂�l
    '    Dim strMsg As String                  'ү����
    '    Try

    '        '************************
    '        '��������
    '        '************************
    '        Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
    '        Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
    '        Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
    '        Call CheckBeforeAct(strDenbunDtl)


    '        '************************************
    '        '�ׯ�ݸނ̓���
    '        '************************************
    '        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '        objTPRG_TRK_BUF.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)     '��گ�ID
    '        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)             '����


    '        '************************************
    '        '��Ǝ��       �ݒ�
    '        '************************************
    '        Dim intFSAGYOU_KIND As Integer          '��Ǝ��
    '        Select Case objTPRG_TRK_BUF.FTRK_BUF_NO
    '            Case FTRK_BUF_NO_J9000
    '                '(���i�����q�ɂ̖⍇���o�ɂ̏ꍇ)
    '                intFSAGYOU_KIND = FSAGYOU_KIND_STOI_OUT
    '            Case Else
    '                strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧��:" & objTPRG_TRK_BUF.FTRK_BUF_NO & "][��گ�ID:" & objTPRG_TRK_BUF.FPALLET_ID & "]"
    '                Throw New UserException(strMsg)
    '        End Select


    '        '************************************
    '        '�o���ׯ�ݸޒ�`�׽(��گ�ID�w��)
    '        '************************************
    '        Dim objSVR_100501 As New SVR_100501(Owner, ObjDb, ObjDbLog)
    '        objSVR_100501.FTRK_BUF_NO_TO = TO_INTEGER(strDenbunDtl(DSPST_OUT))          '�ׯ�ݸ��ޯ̧��(�o�ɐ��ׯ�ݸ�)
    '        objSVR_100501.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)                       '��گ�ID
    '        objSVR_100501.FSAGYOU_KIND = intFSAGYOU_KIND                                '��Ǝ��
    '        objSVR_100501.FTERM_ID = strDenbunDtl(DSPTERM_ID)                           '�[��ID
    '        objSVR_100501.FUSER_ID = strDenbunDtl(DSPUSER_ID)                           'հ�ްID
    '        objSVR_100501.UPDATE_OUT_BUF(FTR_VOL_SFULL)                                 '��`


    '        '************************
    '        '���튮��
    '        '************************
    '        Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
    '        Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
    '        Return RetCode.OK


    '    Catch ex As UserException
    '        Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ex.Message)
    '        Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
    '        Call ComUser(ex, MeSyoriID)
    '        Return RetCode.NG
    '    Catch ex As Exception
    '        Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ERRMSG_DISP_ERR)
    '        Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
    '        Call ComError(ex, MeSyoriID)
    '        Return RetCode.NG
    '    End Try
    'End Function

#End Region
    '������������************************************************************************************************************
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


End Class
