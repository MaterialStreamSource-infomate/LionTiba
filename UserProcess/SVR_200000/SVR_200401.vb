'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�݌�����ݽ
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_200401
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "

    '�d������p
    Private Const DSPTERM_ID As Integer = 0         '�[��ID
    Private Const DSPUSER_ID As Integer = 1         'հ�ްID
    Private Const DSPREASON As Integer = 2          '���R
    Private Const DSPDIR_KUBUN As Integer = 3       '�����敪
    Private Const DSPTRK_BUF_NO As Integer = 4      '�ޯ̧��
    Private Const DSPTRK_BUF_ARRAY As Integer = 5   '�ޯ̧�z��
    Private Const DSPREMOVE_KIND As Integer = 6     '�֎~�I�ݒ�
    Private Const DSPRAC_FORM As Integer = 7        '�I�`����
    Private Const DSPRES_KIND As Integer = 8        '�������
    Private Const DSPHINMEI_CD As Integer = 9       '�i������
    Private Const DSPLOT_NO As Integer = 10         'ۯć�
    Private Const DSPARRIVE_DT As Integer = 11      '�݌ɔ�������
    Private Const DSPIN_KUBUN As Integer = 12       '���ɋ敪
    Private Const DSPSEIHIN_KUBUN As Integer = 13   '���i�敪
    Private Const DSPZAIKO_KUBUN As Integer = 14    '�݌ɋ敪
    Private Const DSPHORYU_KUBUN As Integer = 15    '�ۗ��敪
    Private Const DSPST_FM As Integer = 16          '������ST�ׯ�ݸ��ޯ̧��
    Private Const DSPTR_VOL As Integer = 17         '�����Ǘ���
    Private Const DSPTR_RES_VOL As Integer = 18     '����������
    Private Const DSPPALLET_ID As Integer = 19      '��گ�ID
    Private Const DSPLOT_NO_STOCK As Integer = 20   '�݌�ۯć�
    Private Const DSPLABEL_ID As Integer = 21       '����ID
    Private Const DSPHASU_FLAG As Integer = 22      '�[���׸�
    Private Const DSPSYUKKA_TO_CD As Integer = 23   '�o�א溰��
    Private Const DSPSYUKKA_TO_NAME As Integer = 24 '�o�א於��
    Private Const DSPRAC_BUNRUI As Integer = 25     '�I����
    Private Const DSPBUF_IN_DT As Integer = 26      '�ޯ̧������
    '**********************************************************************************************
    '���������ьŗL
    Private Const XDSPTANA_BLOCK As Integer = 27            '�I��ۯ�
    Private Const XDSPTANA_BLOCK_DTL As Integer = 28        '�I��ۯ��ڍ�
    Private Const XDSPTANA_BLOCK_STS As Integer = 29        '�I��ۯ����
    Private Const XDSPPROD_LINE As Integer = 30             '���Yײ݇�
    Private Const XDSPKENSA_KUBUN As Integer = 31           '�����敪
    Private Const XDSPKENPIN_KUBUN As Integer = 32          '���i�敪
    Private Const XDSPMAKER_CD As Integer = 33              'Ұ�����
    Private Const XDSPRAC_IN_DT As Integer = 34             '���ɓ���
    '**********************************************************************************************
    '������2013/07/14 H.Okumura �݌Ɉڍs�Ŏg�p
    Private Const DSPUPDATE_DT As Integer = 35              '�X�V����
    '������
    '**********************************************************************************************


    '���������ьŗL
    '**********************************************************************************************

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
        Dim strDenbunDtl(0) As String          '�d������z��
        Dim strDenbunDtlName(0) As String      '�d�����𖼏̔z��
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
            '�݌�����ݽ
            '************************
            Select Case strDenbunDtl(DSPDIR_KUBUN)     '�����敪
                Case FORMAT_DSP_DSPDIR_KUBUN_INSERT
                    '(�ǉ�)
                    Call MenteStockADD(strDenbunDtl)


                Case FORMAT_DSP_DSPDIR_KUBUN_UPDATE _
                   , FORMAT_DSP_DSPDIR_KUBUN_INSERT_STOCK _
                   , FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK _
                   , FORMAT_DSP_DSPDIR_KUBUN_DELETE_STOCK
                    '(�X�V)
                    Call MenteStockUPDATE(strDenbunDtl)


                Case FORMAT_DSP_DSPDIR_KUBUN_DELETE
                    '(�폜)
                    Call MenteStockDELETE(strDenbunDtl)

            End Select


            '************************
            '���튮��
            '************************
            Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL, strDenbunDtl(DSPREASON))
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
            End If


            Select Case strDenbunDtl(DSPDIR_KUBUN)     '�����敪
                Case FORMAT_DSP_DSPDIR_KUBUN_INSERT
                    '(�ǉ��̏ꍇ)


                Case FORMAT_DSP_DSPDIR_KUBUN_UPDATE
                    '(�ύX�̏ꍇ)


                Case FORMAT_DSP_DSPDIR_KUBUN_DELETE
                    '(�폜�̏ꍇ)


            End Select


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region

#Region "  �ǉ�����ݽ                                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ǉ�����ݽ
    ''' </summary>
    ''' <param name="strDenbunDtl">�d�����e�\����</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MenteStockADD(ByVal strDenbunDtl() As String)
        Try
            Dim intRet As Integer                   '�߂�l
            Dim strMsg As String                    'ү����
            Dim dtmNow As Date = Now                '���ݓ���


            '************************
            '�ׯ�ݸ�Ͻ��̓���
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)         '�ׯ�ݸ�Ͻ��׽
            objTMST_TRK.FTRK_BUF_NO = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_NO))    '�ׯ�ݸ��ޯ̧No
            intRet = objTMST_TRK.GET_TMST_TRK(True)                             '����


            '************************
            '�ׯ�ݸ��ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF.FTRK_BUF_NO = objTMST_TRK.FTRK_BUF_NO                   '�ׯ�ݸ��ޯ̧No
            If TO_INTEGER(objTMST_TRK.FBUF_KIND) = FBUF_KIND_SASRS Then
                '(�q�ɂ̏ꍇ)
                objTPRG_TRK_BUF.FTRK_BUF_ARRAY = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_ARRAY))      '�ׯ�ݸޔz��No
                intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)                                 '����
                If TO_INTEGER(objTPRG_TRK_BUF.FRES_KIND) <> FRES_KIND_SAKI And TO_INTEGER(objTPRG_TRK_BUF.FRES_KIND) <> FRES_KIND_SZAIKO Then
                    '(��I�A�݌ɒI�ȊO�̏ꍇ)
                    strMsg = ERRMSG_DISP_TRK & "[�ޯ̧No:" & TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO) & "  ,�z��No:" & TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY) & "  ,�݌Ɉ������:" & TO_STRING(objTPRG_TRK_BUF.FRES_KIND) & "]"
                    Throw New System.Exception(strMsg)
                End If
            Else
                '(���u���n�̏ꍇ)
                intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_AKI_HIRA() '����
                If intRet = RetCode.NotFound Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[�ޯ̧No:" & TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO) & "]"
                    Throw New System.Exception(strMsg)
                End If
            End If


            '**************************************
            '۸ޗp��޼ު�č쐬
            '**************************************
            '�ׯ�ݸ��ޯ̧
            Dim objTPRG_TRK_BUF_Before As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF_Before.FTRK_BUF_NO = objTPRG_TRK_BUF.FTRK_BUF_NO            '�ׯ�ݸ��ޯ̧No
            objTPRG_TRK_BUF_Before.FTRK_BUF_ARRAY = objTPRG_TRK_BUF.FTRK_BUF_ARRAY      '�ׯ�ݸޔz��No
            intRet = objTPRG_TRK_BUF_Before.GET_TPRG_TRK_BUF(False)                     '����


            '************************
            '�݌ɏ��̓o�^
            '************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)                     '�݌ɏ��׽
            If strDenbunDtl(DSPPALLET_ID) <> DEFAULT_STRING Then
                objTRST_STOCK.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)                           '��گ�ID
            End If
            objTRST_STOCK.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                               '�i������
            objTRST_STOCK.FLOT_NO = strDenbunDtl(DSPLOT_NO)                                     'ۯć�
            objTRST_STOCK.FARRIVE_DT = TO_DATE_NULLABLE(strDenbunDtl(DSPARRIVE_DT))             '�݌ɔ�������
            objTRST_STOCK.FIN_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPIN_KUBUN))            '���ɋ敪
            objTRST_STOCK.FSEIHIN_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPSEIHIN_KUBUN))    '���i�敪
            objTRST_STOCK.FZAIKO_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPZAIKO_KUBUN))      '�݌ɋ敪
            objTRST_STOCK.FHORYU_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPHORYU_KUBUN))      '�ۗ��敪
            objTRST_STOCK.FST_FM = TO_INTEGER_NULLABLE(strDenbunDtl(DSPST_FM))                  '������ST�ׯ�ݸ��ޯ̧��
            objTRST_STOCK.FTR_VOL = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPTR_VOL))                '�����Ǘ���
            objTRST_STOCK.FTR_RES_VOL = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPTR_RES_VOL))        '����������
            '**********************************************************************************************
            '������2013/07/14 H.Okumura �݌Ɉڍs�Ŏg�p
            If strDenbunDtl(DSPUPDATE_DT) <> "" Then                                            '�X�V����
                objTRST_STOCK.FUPDATE_DT = strDenbunDtl(DSPUPDATE_DT)
            Else
                objTRST_STOCK.FUPDATE_DT = dtmNow
            End If
            '������
            '**********************************************************************************************
            objTRST_STOCK.FLABEL_ID = strDenbunDtl(DSPLABEL_ID)                                 '����ID
            objTRST_STOCK.FHASU_FLAG = TO_INTEGER_NULLABLE(strDenbunDtl(DSPHASU_FLAG))          '�[���׸�
            objTRST_STOCK.FSYUKKA_TO_CD = strDenbunDtl(DSPSYUKKA_TO_CD)                         '�o�א溰��
            objTRST_STOCK.FSYUKKA_TO_NAME = strDenbunDtl(DSPSYUKKA_TO_NAME)                     '�o�א於��
            '**********************************************************************************************
            '���������ьŗL
            objTRST_STOCK.XPROD_LINE = strDenbunDtl(XDSPPROD_LINE)                           '���Yײ݇�
            objTRST_STOCK.XKENSA_KUBUN = strDenbunDtl(XDSPKENSA_KUBUN)                       '�����敪
            objTRST_STOCK.XKENPIN_KUBUN = strDenbunDtl(XDSPKENPIN_KUBUN)                     '���i�敪
            objTRST_STOCK.XMAKER_CD = strDenbunDtl(XDSPMAKER_CD)                             'Ұ�����
            objTRST_STOCK.XRAC_IN_DT = TO_DATE(strDenbunDtl(XDSPRAC_IN_DT))                  '���ɓ���
            '���������ьŗL
            '**********************************************************************************************
            '**********************************************************************************************
            '������2013/08/01 H.Okumura �����ׯ�ݸ��ޯ̧��ǉ�
            If TO_INTEGER(objTMST_TRK.FBUF_KIND) = FBUF_KIND_SASRS Then
                '(�q�ɂ̏ꍇ)
                objTRST_STOCK.XTRK_BUF_NO_IN = strDenbunDtl(DSPTRK_BUF_NO)
                objTRST_STOCK.XTRK_BUF_ARRAY_IN = strDenbunDtl(DSPTRK_BUF_ARRAY)
            End If
            '������
            '**********************************************************************************************


            objTRST_STOCK.ADD_TRST_STOCK_ALL()                                                  '�o�^


            '************************
            '��Ǝ�ʂ��擾
            '************************
            Dim intFSAGYO_KIND = FSAGYOU_KIND_SSYSTEM_MENTE_NON


            '************************
            '�݌ɓo�^
            '************************
            Dim objSVR_100101 As New SVR_100101(Owner, ObjDb, ObjDbLog) '�݌ɓo�^�׽
            objSVR_100101.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF             '�ׯ�ݸ��ޯ̧
            objSVR_100101.FPALLET_ID = objTRST_STOCK.FPALLET_ID         '��گ�ID
            objSVR_100101.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK   '�݌�ۯć�
            objSVR_100101.FINOUT_STS = FINOUT_STS_SMENTE_ADD            'INOUT(����ݽ�o�^)
            objSVR_100101.FSAGYOU_KIND = intFSAGYO_KIND                 '��Ǝ��
            objSVR_100101.STOCK_ADD()                                   '�o�^


            '************************
            '�ׯ�ݸ��ޯ̧�̍X�V
            '************************
            If TO_INTEGER(objTMST_TRK.FBUF_KIND) = FBUF_KIND_SASRS Then
                '(�q�ɂ̏ꍇ)
                objTPRG_TRK_BUF.FREMOVE_KIND = TO_NUMBER(strDenbunDtl(DSPREMOVE_KIND))  '�֎~�I�ݒ�
                objTPRG_TRK_BUF.FRAC_FORM = TO_NUMBER(strDenbunDtl(DSPRAC_FORM))        '�I�`����
                objTPRG_TRK_BUF.FRAC_BUNRUI = strDenbunDtl(DSPRAC_BUNRUI)               '�I����
                '������������************************************************************************************************************
                'JobMate:A.Noto 2013/03/26 JOB�ŗL���ڒǉ�
                'objTPRG_TRK_BUF.FBUF_IN_DT = dtmNow                                                        '�ޯ̧������
                objTPRG_TRK_BUF.FBUF_IN_DT = TO_DATE_NULLABLE(strDenbunDtl(DSPBUF_IN_DT))                   '�ޯ̧������
                objTPRG_TRK_BUF.XTANA_BLOCK = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTANA_BLOCK))             '�I��ۯ�
                objTPRG_TRK_BUF.XTANA_BLOCK_DTL = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTANA_BLOCK_DTL))     '�I��ۯ��ڍ�
                objTPRG_TRK_BUF.XTANA_BLOCK_STS = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTANA_BLOCK_STS))     '�I��ۯ����
                '������������************************************************************************************************************
                objTPRG_TRK_BUF.UPDATE_TPRG_TRK_BUF()                                   '�X�V

                '������������************************************************************************************************************
                'JobMate:H.Okumura 2013/07/17 �I��ۯ��P�ʂōX�V(���g�p�I������)
                Dim strXTANA_BLOCK As String
                strXTANA_BLOCK = objTPRG_TRK_BUF.XTANA_BLOCK        '�I��ۯ�

                Dim strSQL As String
                Dim intRetSQL As Integer    'SQL���s�߂�l

                strSQL = ""
                strSQL &= vbCrLf & "UPDATE"
                strSQL &= vbCrLf & "      TPRG_TRK_BUF "
                strSQL &= vbCrLf & " SET "
                strSQL &= vbCrLf & "      FREMOVE_KIND = " & TO_NUMBER(strDenbunDtl(DSPREMOVE_KIND)) & " "
                strSQL &= vbCrLf & " WHERE"
                strSQL &= vbCrLf & "      XTANA_BLOCK = " & strXTANA_BLOCK & " "
                strSQL &= vbCrLf & "  AND FTRK_BUF_NO = " & objTPRG_TRK_BUF.FTRK_BUF_NO & " "
                If TO_NUMBER(strDenbunDtl(DSPREMOVE_KIND)) <> FREMOVE_KIND_SNON Then
                    strSQL &= vbCrLf & "  AND FREMOVE_KIND <> " & FREMOVE_KIND_SNON & " "               '���g�p�I������
                End If
                strSQL &= vbCrLf
                intRetSQL = ObjDb.Execute(strSQL)
                If intRetSQL = -1 Then
                    '(SQL�װ)
                    strSQL = Replace(strSQL, vbCrLf, "")
                    strMsg = ERRMSG_ERR_UPDATE & ObjDb.ErrMsg & "�y" & strSQL & "�z"
                    Throw New UserException(strMsg)
                End If
                If intRetSQL < 1 Then
                    strMsg = "ERRMSG_NOTFOUND_TPRG_TRK_BUF" & "[�ޯ̧��:" & objTPRG_TRK_BUF.FTRK_BUF_NO & "  ,�I��ۯ�:" & strXTANA_BLOCK & "]"
                    Throw New UserException(strMsg)
                End If
                '������������************************************************************************************************************


            End If

            '������������************************************************************************************************************
            'JobMate:A.Noto 2013/03/26 �ύX���𖢎g�p
            ''**************************************
            ''۸ޗp��޼ު�č쐬
            ''**************************************
            ''�݌ɏ��
            'Dim objTRST_STOCK_After As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            'objTRST_STOCK_After.FPALLET_ID = objTRST_STOCK.FPALLET_ID         '��گ�ID
            'objTRST_STOCK_After.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK   '�݌�ۯć�
            'intRet = objTRST_STOCK_After.GET_TRST_STOCK_ALL()                 '����
            'If intRet = RetCode.NotFound Then
            '    '(������Ȃ��ꍇ)
            '    strMsg = ERRMSG_NOTFOUND_TRST_STOCK & "[��گ�ID:" & objTRST_STOCK_After.FPALLET_ID & "][�݌�ۯć�" & objTRST_STOCK_After.FLOT_NO_STOCK & "]"
            '    Throw New UserException(strMsg)
            'End If

            ''�ׯ�ݸ��ޯ̧
            'Dim objTPRG_TRK_BUF_After As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            'objTPRG_TRK_BUF_After.FTRK_BUF_NO = objTPRG_TRK_BUF.FTRK_BUF_NO                 '�ׯ�ݸ��ޯ̧No
            'objTPRG_TRK_BUF_After.FTRK_BUF_ARRAY = objTPRG_TRK_BUF.FTRK_BUF_ARRAY           '�ׯ�ݸޔz��No
            'intRet = objTPRG_TRK_BUF_After.GET_TPRG_TRK_BUF(True)                           '����


            ''**************************************
            ''�ύX�����ڍגǉ�
            ''**************************************
            'Call Add_TEVD_TBLCHANGE_DTL_TRST_STOCK(strDenbunDtl _
            '                                     , MeSyoriID _
            '                                     , objTPRG_TRK_BUF_Before _
            '                                     , Nothing _
            '                                     , objTPRG_TRK_BUF_After _
            '                                     , objTRST_STOCK_After _
            '                                     )


            ''************************
            ''�݌ɍX�V�����̓o�^
            ''************************
            'Call ADD_STOCK_LOG(strDenbunDtl, objTRST_STOCK_After)
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
#Region "  �X�V����ݽ                                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �X�V����ݽ
    ''' </summary>
    ''' <param name="strDenbunDtl">�d�����e�\����</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MenteStockUPDATE(ByVal strDenbunDtl() As String)
        Try
            Dim intRet As Integer                   '�߂�l
            Dim strMsg As String                    'ү����


            '**************************************
            '۸ޗp��޼ު�č쐬
            '**************************************
            '�݌ɏ��
            Dim objTRST_STOCK_Before As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            If IsNull(strDenbunDtl(DSPPALLET_ID)) = False And IsNull(strDenbunDtl(DSPLOT_NO_STOCK)) = False Then
                '(��گ�ID�������Ă����ꍇ)
                objTRST_STOCK_Before.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)       '��گ�ID
                objTRST_STOCK_Before.FLOT_NO_STOCK = strDenbunDtl(DSPLOT_NO_STOCK) '�݌�ۯć�
                intRet = objTRST_STOCK_Before.GET_TRST_STOCK_ALL()                 '����
                If intRet = RetCode.NotFound Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_TRST_STOCK & "[��گ�ID:" & objTRST_STOCK_Before.FPALLET_ID & "][�݌�ۯć�" & objTRST_STOCK_Before.FLOT_NO_STOCK & "]"
                    Throw New UserException(strMsg)
                End If
            End If

            '�ׯ�ݸ��ޯ̧
            Dim objTPRG_TRK_BUF_Before As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF_Before.FTRK_BUF_NO = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_NO))         '�ׯ�ݸ��ޯ̧No
            objTPRG_TRK_BUF_Before.FTRK_BUF_ARRAY = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_ARRAY))   '�ׯ�ݸޔz��No
            intRet = objTPRG_TRK_BUF_Before.GET_TPRG_TRK_BUF(False)                             '����


            '************************
            '�ׯ�ݸ�Ͻ��̓���
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)         '�ׯ�ݸ�Ͻ��׽
            objTMST_TRK.FTRK_BUF_NO = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_NO))    '�ׯ�ݸ��ޯ̧No
            intRet = objTMST_TRK.GET_TMST_TRK(True)                             '����


            '************************
            '�ׯ�ݸ��ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)             '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF.FTRK_BUF_NO = objTMST_TRK.FTRK_BUF_NO                           '�ׯ�ݸ��ޯ̧No
            objTPRG_TRK_BUF.FTRK_BUF_ARRAY = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_ARRAY))      '�ׯ�ݸޔz��No
            intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)                                 '����
            If Not (TO_INTEGER(objTPRG_TRK_BUF.FRES_KIND) = FRES_KIND_SAKI Or _
                   TO_INTEGER(objTPRG_TRK_BUF.FRES_KIND) = FRES_KIND_SZAIKO) Then
                '(������Ԃ��󂩍݌ɈȊO�̏ꍇ)
                strMsg = ERRMSG_DISP_TRK & "[�ޯ̧No:" & TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO) & "  ,�z��No:" & TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY) & "  ,�݌Ɉ������:" & TO_STRING(objTPRG_TRK_BUF.FRES_KIND) & "]"
                Throw New System.Exception(strMsg)
            End If


            '************************
            '��Ǝ�ʂ��擾
            '************************
            Dim intFSAGYO_KIND = FSAGYOU_KIND_SSYSTEM_MENTE_NON


            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)            '�݌ɏ��׽
            If TO_INTEGER(strDenbunDtl(DSPDIR_KUBUN)) = FORMAT_DSP_DSPDIR_KUBUN_UPDATE Then
                '(�݌ɂ��X�V�̏ꍇ)


                '**********************************************************************************
                '���X�V�̏ꍇ
                '**********************************************************************************
                '=====================
                '�݌ɏ��̓���
                '=====================
                objTRST_STOCK.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)                      '��گ�ID
                objTRST_STOCK.FLOT_NO_STOCK = strDenbunDtl(DSPLOT_NO_STOCK)                '�݌�ۯć�
                intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)                         '����

                '=====================
                '�݌ɏ��1�̍X�V
                '=====================
                objTRST_STOCK.ARYME(0).FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                             '�i������
                objTRST_STOCK.ARYME(0).FLOT_NO = strDenbunDtl(DSPLOT_NO)                                   'ۯć�
                objTRST_STOCK.ARYME(0).FARRIVE_DT = TO_DATE_NULLABLE(strDenbunDtl(DSPARRIVE_DT))           '�݌ɔ�������
                objTRST_STOCK.ARYME(0).FIN_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPIN_KUBUN))          '���ɋ敪
                objTRST_STOCK.ARYME(0).FSEIHIN_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPSEIHIN_KUBUN))  '���i�敪
                objTRST_STOCK.ARYME(0).FZAIKO_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPZAIKO_KUBUN))    '�݌ɋ敪
                objTRST_STOCK.ARYME(0).FHORYU_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPHORYU_KUBUN))    '�ۗ��敪
                objTRST_STOCK.ARYME(0).FST_FM = TO_INTEGER_NULLABLE(strDenbunDtl(DSPST_FM))                '������ST�ׯ�ݸ��ޯ̧��
                objTRST_STOCK.ARYME(0).FTR_VOL = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPTR_VOL))              '�����Ǘ���
                objTRST_STOCK.ARYME(0).FTR_RES_VOL = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPTR_RES_VOL))      '����������
                objTRST_STOCK.ARYME(0).FUPDATE_DT = Now                                                    '�X�V����
                objTRST_STOCK.ARYME(0).FLABEL_ID = strDenbunDtl(DSPLABEL_ID)                               '����ID
                objTRST_STOCK.ARYME(0).FHASU_FLAG = TO_INTEGER_NULLABLE(strDenbunDtl(DSPHASU_FLAG))        '�[���׸�
                objTRST_STOCK.ARYME(0).FSYUKKA_TO_CD = strDenbunDtl(DSPSYUKKA_TO_CD)                       '�o�א溰��
                objTRST_STOCK.ARYME(0).FSYUKKA_TO_NAME = strDenbunDtl(DSPSYUKKA_TO_NAME)                   '�o�א於��
                '**********************************************************************************************
                '���������ьŗL
                objTRST_STOCK.ARYME(0).XPROD_LINE = strDenbunDtl(XDSPPROD_LINE)                             '���Yײ݇�
                objTRST_STOCK.ARYME(0).XKENSA_KUBUN = strDenbunDtl(XDSPKENSA_KUBUN)                         '�����敪
                objTRST_STOCK.ARYME(0).XKENPIN_KUBUN = strDenbunDtl(XDSPKENPIN_KUBUN)                       '���i�敪
                objTRST_STOCK.ARYME(0).XMAKER_CD = strDenbunDtl(XDSPMAKER_CD)                               'Ұ�����
                objTRST_STOCK.ARYME(0).XRAC_IN_DT = TO_DATE(strDenbunDtl(XDSPRAC_IN_DT))                    '���ɓ���
                '���������ьŗL
                '**********************************************************************************************
                objTRST_STOCK.ARYME(0).UPDATE_TRST_STOCK_ALL()                                               '�X�V


                '=====================
                '�݌ɍX�V
                '=====================
                Dim objSVR_100104 As New SVR_100104(Owner, ObjDb, ObjDbLog)     '�݌ɍX�V�׽
                objSVR_100104.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF                 '�ׯ�ݸ��ޯ̧��޼ު��
                objSVR_100104.OBJTRST_STOCK = objTRST_STOCK                     '�݌ɏ���޼ު��
                objSVR_100104.FINOUT_STS = FINOUT_STS_SMENTE_UPDATE              'IN/OUT
                objSVR_100104.FSAGYOU_KIND = intFSAGYO_KIND                     '��Ǝ��
                objSVR_100104.STOCK_UPDATE()                                    '�X�V


            ElseIf TO_INTEGER(strDenbunDtl(DSPDIR_KUBUN)) = FORMAT_DSP_DSPDIR_KUBUN_INSERT_STOCK Then
                '(���ǉ��̏ꍇ)


                '**********************************************************************************
                '���ǉ��̏ꍇ
                '**********************************************************************************
                '=====================
                '�݌ɏ��̓o�^
                '=====================
                objTRST_STOCK.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)                               '��گ�ID
                objTRST_STOCK.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                               '�i������
                objTRST_STOCK.FLOT_NO = strDenbunDtl(DSPLOT_NO)                                     'ۯć�
                objTRST_STOCK.FARRIVE_DT = TO_DATE_NULLABLE(strDenbunDtl(DSPARRIVE_DT))             '�݌ɔ�������
                objTRST_STOCK.FIN_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPIN_KUBUN))            '���ɋ敪
                objTRST_STOCK.FSEIHIN_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPSEIHIN_KUBUN))    '���i�敪
                objTRST_STOCK.FZAIKO_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPZAIKO_KUBUN))      '�݌ɋ敪
                objTRST_STOCK.FHORYU_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPHORYU_KUBUN))      '�ۗ��敪
                objTRST_STOCK.FST_FM = TO_INTEGER_NULLABLE(strDenbunDtl(DSPST_FM))                  '������ST�ׯ�ݸ��ޯ̧��
                objTRST_STOCK.FTR_VOL = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPTR_VOL))                '�����Ǘ���
                objTRST_STOCK.FTR_RES_VOL = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPTR_RES_VOL))        '����������
                objTRST_STOCK.FUPDATE_DT = Now                                                      '�X�V����
                objTRST_STOCK.FLABEL_ID = strDenbunDtl(DSPLABEL_ID)                                 '����ID
                objTRST_STOCK.FHASU_FLAG = TO_INTEGER_NULLABLE(strDenbunDtl(DSPHASU_FLAG))          '�[���׸�
                objTRST_STOCK.FSYUKKA_TO_CD = strDenbunDtl(DSPSYUKKA_TO_CD)                         '�o�א溰��
                objTRST_STOCK.FSYUKKA_TO_NAME = strDenbunDtl(DSPSYUKKA_TO_NAME)                     '�o�א於��
                '**********************************************************************************************
                '���������ьŗL
                objTRST_STOCK.XPROD_LINE = strDenbunDtl(XDSPPROD_LINE)                              '���Yײ݇�
                objTRST_STOCK.XKENSA_KUBUN = strDenbunDtl(XDSPKENSA_KUBUN)                          '�����敪
                objTRST_STOCK.XKENPIN_KUBUN = strDenbunDtl(XDSPKENPIN_KUBUN)                        '���i�敪
                objTRST_STOCK.XMAKER_CD = strDenbunDtl(XDSPMAKER_CD)                                'Ұ�����
                objTRST_STOCK.XRAC_IN_DT = TO_DATE(strDenbunDtl(XDSPRAC_IN_DT))                     '���ɓ���
                '���������ьŗL
                '**********************************************************************************************
                objTRST_STOCK.ADD_TRST_STOCK_ALL()                                                  '�o�^


                '=====================
                '�݌ɓo�^
                '=====================
                Dim objSVR_100101 As New SVR_100101(Owner, ObjDb, ObjDbLog) '�݌ɓo�^�׽
                objSVR_100101.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF             '�ׯ�ݸ��ޯ̧
                objSVR_100101.FPALLET_ID = objTRST_STOCK.FPALLET_ID         '��گ�ID
                objSVR_100101.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK   '�݌�ۯć�
                objSVR_100101.FINOUT_STS = FINOUT_STS_SMENTE_KOSOU_ADD       'INOUT
                objSVR_100101.FSAGYOU_KIND = intFSAGYO_KIND                 '��Ǝ��
                objSVR_100101.STOCK_ADD()                                   '�o�^


            ElseIf TO_INTEGER(strDenbunDtl(DSPDIR_KUBUN)) = FORMAT_DSP_DSPDIR_KUBUN_DELETE_STOCK Then
                '(���폜�̏ꍇ)


                '**********************************************************************************
                '���폜�̏ꍇ
                '**********************************************************************************
                '=====================
                '�݌ɍ폜
                '=====================
                Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '�݌ɍ폜�׽
                objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF             '�ׯ�ݸ��ޯ̧
                objSVR_100102.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)       '��گ�ID
                objSVR_100102.FLOT_NO_STOCK = strDenbunDtl(DSPLOT_NO_STOCK) '�݌�ۯć�
                objSVR_100102.FINOUT_STS = FINOUT_STS_SMENTE_KOSOU_DELETE    'INOUT
                objSVR_100102.FSAGYOU_KIND = intFSAGYO_KIND                 '��Ǝ��
                objSVR_100102.STOCK_DELETE()                                '�폜


                '===========================================================
                '�݌ɏ��̓���
                '�Ō�̌��́u�X�V�v�Ƃ��Ă͍폜�o���Ȃ��̂Ŵװ�Ƃ���
                '===========================================================
                objTRST_STOCK.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)                      '��گ�ID
                intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)                         '����


            ElseIf TO_INTEGER(strDenbunDtl(DSPDIR_KUBUN)) = FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK Then
                '(�����ʏ��X�V�̏ꍇ)


                '**********************************************************************************
                '�����ʏ��X�V�̏ꍇ
                '**********************************************************************************

                '=====================
                '�݌ɏ��̓���
                '=====================
                If IsNotNull(strDenbunDtl(DSPPALLET_ID)) Then
                    '(�݌ɏ����X�V����ꍇ)

                    objTRST_STOCK.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)                      '��گ�ID
                    intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(False)                        '����
                    If intRet = RetCode.OK Then
                        '(���������ꍇ)

                        '������������************************************************************************************************************
                        'Checked JobMate:K.Shimizu 2011/09/12 ���ʂŕύX��������͂Ȃ�

                        ''=====================
                        ''�݌ɏ��̍X�V
                        ''=====================
                        'For ii As Integer = LBound(objTRST_STOCK.ARYME) To UBound(objTRST_STOCK.ARYME)
                        '    '(ٰ��:����)

                        '    objTRST_STOCK.ARYME(ii).FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                             '�i������
                        '    objTRST_STOCK.ARYME(ii).FLOT_NO = strDenbunDtl(DSPLOT_NO)                                   'ۯć�
                        '    objTRST_STOCK.ARYME(ii).FSEIHIN_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPSEIHIN_KUBUN))  '���i�敪
                        '    objTRST_STOCK.ARYME(ii).FHORYU_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPHORYU_KUBUN))    '�ۗ��敪

                        '    objTRST_STOCK.ARYME(ii).UPDATE_TRST_STOCK()                                                 '�X�V

                        'Next

                        ''=====================
                        ''�݌ɍX�V
                        ''=====================
                        'Dim objSVR_100104 As New SVR_100104(Owner, ObjDb, ObjDbLog)     '�݌ɍX�V�׽
                        'objSVR_100104.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF                 '�ׯ�ݸ��ޯ̧��޼ު��
                        'objSVR_100104.OBJTRST_STOCK = objTRST_STOCK                     '�݌ɏ���޼ު��
                        'objSVR_100104.FINOUT_STS = FINOUT_STS_MENTE_UPDATE              'IN/OUT
                        ''������������************************************************************************************************************
                        ''JobMate:K.Shimizu 2011/09/09 �����ƕ�ނ�INOUT���т𕪂���
                        ''objSVR_100104.FSAGYOU_KIND = FSAGYOU_KIND_SYSTEM_MENTE          '��Ǝ��(���ѕێ�)
                        'objSVR_100104.FSAGYOU_KIND = intFSAGYO_KIND                     '��Ǝ��
                        ''������������************************************************************************************************************
                        'objSVR_100104.STOCK_UPDATE()                                    '�X�V


                        '������������************************************************************************************************************


                    End If
                End If

            End If

            '************************
            '�ׯ�ݸ��ޯ̧�̍X�V
            '************************

            If TO_INTEGER(objTMST_TRK.FBUF_KIND) = FBUF_KIND_SASRS Then
                '(�q�ɂ̏ꍇ)

                objTPRG_TRK_BUF.FREMOVE_KIND = TO_NUMBER(strDenbunDtl(DSPREMOVE_KIND))  '�֎~�I�ݒ�
                objTPRG_TRK_BUF.FRAC_FORM = TO_NUMBER(strDenbunDtl(DSPRAC_FORM))        '�I�`����
                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/04/25  �݌ɏ��
                objTPRG_TRK_BUF.FRAC_BUNRUI = strDenbunDtl(DSPRAC_BUNRUI)               '�I����
                '������������************************************************************************************************************
                '������������************************************************************************************************************
                'JobMate:A.Noto 2013/03/26 JOB�ŗL���ڒǉ�
                'objTPRG_TRK_BUF.FBUF_IN_DT = dtmNow                                                            '�ޯ̧������
                objTPRG_TRK_BUF.FBUF_IN_DT = TO_DATE_NULLABLE(strDenbunDtl(DSPBUF_IN_DT))                       '�ޯ̧������
                objTPRG_TRK_BUF.XTANA_BLOCK = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTANA_BLOCK))                 '�I��ۯ�
                objTPRG_TRK_BUF.XTANA_BLOCK_DTL = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTANA_BLOCK_DTL))         '�I��ۯ��ڍ�
                objTPRG_TRK_BUF.XTANA_BLOCK_STS = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTANA_BLOCK_STS))         '�I��ۯ����
                '������������************************************************************************************************************
                objTPRG_TRK_BUF.UPDATE_TPRG_TRK_BUF()                                   '�X�V

                '������������************************************************************************************************************
                'JobMate:H.Okumura 2013/07/17 �I��ۯ��P�ʂōX�V(���g�p�I������)
                Dim strXTANA_BLOCK As String
                strXTANA_BLOCK = objTPRG_TRK_BUF.XTANA_BLOCK        '�I��ۯ�

                Dim strSQL As String
                Dim intRetSQL As Integer    'SQL���s�߂�l

                strSQL = ""
                strSQL &= vbCrLf & "UPDATE"
                strSQL &= vbCrLf & "      TPRG_TRK_BUF "
                strSQL &= vbCrLf & " SET "
                strSQL &= vbCrLf & "      FREMOVE_KIND = " & TO_NUMBER(strDenbunDtl(DSPREMOVE_KIND)) & " "
                strSQL &= vbCrLf & " WHERE"
                strSQL &= vbCrLf & "      XTANA_BLOCK = " & strXTANA_BLOCK & " "
                strSQL &= vbCrLf & "  AND FTRK_BUF_NO = " & objTPRG_TRK_BUF.FTRK_BUF_NO & " "
                If TO_NUMBER(strDenbunDtl(DSPREMOVE_KIND)) <> FREMOVE_KIND_SNON Then
                    strSQL &= vbCrLf & "  AND FREMOVE_KIND <> " & FREMOVE_KIND_SNON & " "               '���g�p�I������
                End If
                strSQL &= vbCrLf
                intRetSQL = ObjDb.Execute(strSQL)
                If intRetSQL = -1 Then
                    '(SQL�װ)
                    strSQL = Replace(strSQL, vbCrLf, "")
                    strMsg = ERRMSG_ERR_UPDATE & ObjDb.ErrMsg & "�y" & strSQL & "�z"
                    Throw New UserException(strMsg)
                End If
                If intRetSQL < 1 Then
                    strMsg = "ERRMSG_NOTFOUND_TPRG_TRK_BUF" & "[�ޯ̧��:" & objTPRG_TRK_BUF.FTRK_BUF_NO & "  ,�I��ۯ�:" & strXTANA_BLOCK & "]"
                    Throw New UserException(strMsg)
                End If
                '������������************************************************************************************************************


            End If


            '������������************************************************************************************************************
            'JobMate:A.Noto 2013/03/26 �ύX���𖢎g�p
            ''**************************************
            ''۸ޗp��޼ު�č쐬
            ''**************************************
            ''�݌ɏ��
            'Dim objTRST_STOCK_After As TBL_TRST_STOCK = Nothing
            'Select Case TO_INTEGER(strDenbunDtl(DSPDIR_KUBUN))
            '    Case FORMAT_DSP_DSPDIR_KUBUN_UPDATE
            '        objTRST_STOCK_After = objTRST_STOCK.ARYME(0)
            '    Case FORMAT_DSP_DSPDIR_KUBUN_INSERT_STOCK
            '        objTRST_STOCK_After = objTRST_STOCK
            '    Case FORMAT_DSP_DSPDIR_KUBUN_DELETE_STOCK
            '        objTRST_STOCK_After = Nothing
            '    Case FORMAT_DSP_DSPDIR_KUBUN_UPDATE_STOCK
            '        objTRST_STOCK_After = Nothing
            'End Select

            ''�ׯ�ݸ��ޯ̧
            'Dim objTPRG_TRK_BUF_After As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            'objTPRG_TRK_BUF_After.FTRK_BUF_NO = strDenbunDtl(DSPTRK_BUF_NO)                     '�ׯ�ݸ��ޯ̧No
            'objTPRG_TRK_BUF_After.FTRK_BUF_ARRAY = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_ARRAY))    '�ׯ�ݸޔz��No
            'intRet = objTPRG_TRK_BUF_After.GET_TPRG_TRK_BUF(True)                               '����


            ''**************************************
            ''�ύX�����ڍגǉ�
            ''**************************************
            'Call Add_TEVD_TBLCHANGE_DTL_TRST_STOCK(strDenbunDtl _
            '                                     , MeSyoriID _
            '                                     , objTPRG_TRK_BUF_Before _
            '                                     , objTRST_STOCK_Before _
            '                                     , objTPRG_TRK_BUF_After _
            '                                     , objTRST_STOCK_After _
            '                                     )


            ''************************
            ''�݌ɍX�V�����̓o�^
            ''************************
            'If IsNull(objTRST_STOCK_After) = False Then
            '    '(�݌ɂ����݂����ꍇ)
            '    Call ADD_STOCK_LOG(strDenbunDtl, objTRST_STOCK_After)
            'End If
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
#Region "  �폜����ݽ                                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �폜����ݽ
    ''' </summary>
    ''' <param name="strDenbunDtl">�d�����e�\����</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MenteStockDELETE(ByVal strDenbunDtl() As String)
        Try
            Dim intRet As Integer                   '�߂�l
            Dim strMsg As String                    'ү����


            '**************************************
            '۸ޗp��޼ު�č쐬
            '**************************************
            '�݌ɏ��
            Dim objTRST_STOCK_Before As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            objTRST_STOCK_Before.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)       '��گ�ID
            intRet = objTRST_STOCK_Before.GET_TRST_STOCK_KONSAI(True)          '����

            '�ׯ�ݸ��ޯ̧
            Dim objTPRG_TRK_BUF_Before As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF_Before.FTRK_BUF_NO = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_NO))         '�ׯ�ݸ��ޯ̧No
            objTPRG_TRK_BUF_Before.FTRK_BUF_ARRAY = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_ARRAY))   '�ׯ�ݸޔz��No
            intRet = objTPRG_TRK_BUF_Before.GET_TPRG_TRK_BUF(False)                             '����


            '************************
            '�ׯ�ݸ��ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)         '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF.FTRK_BUF_NO = strDenbunDtl(DSPTRK_BUF_NO)                   '�ׯ�ݸ��ޯ̧No
            objTPRG_TRK_BUF.FTRK_BUF_ARRAY = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_ARRAY))  '�ׯ�ݸޔz��No
            intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)                             '����
            If TO_INTEGER(objTPRG_TRK_BUF.FRES_KIND) <> FRES_KIND_SZAIKO Then
                '(������Ԃ��݌ɈȊO�̏ꍇ)
                strMsg = ERRMSG_DISP_TRK & "[�ޯ̧No:" & TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO) & "  ,�z��No:" & TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_ARRAY) & "  ,�݌Ɉ������:" & TO_STRING(objTPRG_TRK_BUF.FRES_KIND) & "]"
                Throw New System.Exception(strMsg)
            End If


            '************************
            '�݌Ɉ������̍폜
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '�݌Ɉ������׽
            objTSTS_HIKIATE.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)             '��گ�ID
            objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()                        '�폜


            '************************
            '��Ǝ�ʂ��擾
            '************************
            Dim intFSAGYO_KIND = FSAGYOU_KIND_SSYSTEM_MENTE_NON


            '************************
            '�݌ɍ폜
            '************************
            Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '�݌ɍ폜�׽
            objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF             '�ׯ�ݸ��ޯ̧
            objSVR_100102.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)       '��گ�ID
            objSVR_100102.FINOUT_STS = FINOUT_STS_SMENTE_DELETE          'INOUT(����ݽ�폜)
            objSVR_100102.FSAGYOU_KIND = intFSAGYO_KIND                 '��Ǝ��
            objSVR_100102.STOCK_DELETE()                                '�폜


            '************************
            '�݌ɏ��̓���
            '************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '�݌ɏ��׽
            objTRST_STOCK.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)           '��گ�ID
            intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(False)             '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)

                '************************
                '�����ޯ̧�̉��
                '************************
                Dim objTPRG_TRK_BUF_CLEAR As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)   '�݌ɍ폜�׽
                objTPRG_TRK_BUF_CLEAR.FRSV_PALLET = strDenbunDtl(DSPPALLET_ID)              '��گ�ID
                objTPRG_TRK_BUF_CLEAR.CLEAR_TPRG_TRK_BUF_RSV_PC()                           '���

            End If


            '������������************************************************************************************************************
            'JobMate:A.Noto 2013/03/26 �ύX���𖢎g�p
            ''**************************************
            ''۸ޗp��޼ު�č쐬
            ''**************************************
            ''�ׯ�ݸ��ޯ̧
            'Dim objTPRG_TRK_BUF_After As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            'objTPRG_TRK_BUF_After.FTRK_BUF_NO = strDenbunDtl(DSPTRK_BUF_NO)                     '�ׯ�ݸ��ޯ̧No
            'objTPRG_TRK_BUF_After.FTRK_BUF_ARRAY = TO_NUMBER(strDenbunDtl(DSPTRK_BUF_ARRAY))    '�ׯ�ݸޔz��No
            'intRet = objTPRG_TRK_BUF_After.GET_TPRG_TRK_BUF(True)                               '����


            ''**************************************
            ''�ύX�����ڍגǉ�
            ''**************************************
            'For ii As Integer = LBound(objTRST_STOCK_Before.ARYME) To UBound(objTRST_STOCK_Before.ARYME)
            '    '(ٰ��:����)
            '    Call Add_TEVD_TBLCHANGE_DTL_TRST_STOCK(strDenbunDtl _
            '                                         , MeSyoriID _
            '                                         , objTPRG_TRK_BUF_Before _
            '                                         , objTRST_STOCK_Before.ARYME(ii) _
            '                                         , objTPRG_TRK_BUF_After _
            '                                         , Nothing _
            '                                         )
            'Next


            ''************************
            ''�݌ɍX�V�����̓o�^
            ''************************
            'For ii As Integer = LBound(objTRST_STOCK_Before.ARYME) To UBound(objTRST_STOCK_Before.ARYME)
            '    '(ٰ��:����)
            '    Call ADD_STOCK_LOG(strDenbunDtl, objTRST_STOCK_Before.ARYME(ii))
            'Next
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

#Region "  �݌ɍX�V�����̓o�^                                                                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �݌ɍX�V�����̓o�^
    ''' </summary>
    ''' <param name="strDenbunDtl">�d�����e�\����</param>
    ''' <param name="objTRST_STOCK"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ADD_STOCK_LOG(ByVal strDenbunDtl() As String, ByVal objTRST_STOCK As TBL_TRST_STOCK)
        Try
            '***********************
            '��Ǝ�ʂ̓���
            '***********************
            Dim intSAGYOU_KIND As Integer
            Select Case strDenbunDtl(DSPDIR_KUBUN)     '�����敪
                Case FORMAT_DSP_DSPDIR_KUBUN_INSERT
                    '(�ǉ�)
                    intSAGYOU_KIND = FSAGYOU_KIND_SSTOCK_ADD


                Case FORMAT_DSP_DSPDIR_KUBUN_UPDATE
                    '(�X�V)
                    intSAGYOU_KIND = FSAGYOU_KIND_SSTOCK_CHG


                Case FORMAT_DSP_DSPDIR_KUBUN_DELETE
                    '(�폜)
                    intSAGYOU_KIND = FSAGYOU_KIND_SSTOCK_DEL

            End Select


            '***********************
            '�[��Ͻ��̓���
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)               '�[��Ͻ�
            If IsNull(strDenbunDtl(DSPTERM_ID)) = False Then
                objTDSP_TERM.FTERM_ID = strDenbunDtl(DSPTERM_ID)              '�[��ID     ���
                Call objTDSP_TERM.GET_TDSP_TERM(False)                                  '����
            End If


            '***********************
            'հ�ްϽ��̓���
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)               'հ�ްϽ�
            If IsNull(strDenbunDtl(DSPUSER_ID)) = False Then
                objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)                          'հ�ްID
                Call objTMST_USER.GET_TMST_USER(False)                                  '����
            End If


            '************************
            '�������ׯ�ݸ�Ͻ��̓���
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)                 '�ׯ�ݸ��ޯ̧Ͻ��׽
            objTMST_TRK.FTRK_BUF_NO = TO_DECIMAL(strDenbunDtl(DSPTRK_BUF_NO))           '�ׯ�ݸ��ޯ̧No
            Call objTMST_TRK.GET_TMST_TRK(False)                                        '����


            '***********************
            '��Ǝ�ʖ�������̓���
            '***********************
            Dim objTMST_SAGYO As New TBL_TMST_SAGYO(Owner, ObjDb, ObjDbLog)             '��Ǝ�ʖ�������
            If IsNull(intSAGYOU_KIND) = False Then
                objTMST_SAGYO.FSAGYOU_KIND = intSAGYOU_KIND                             '��Ǝ��
                objTMST_SAGYO.FEQ_ID = FEQ_ID_SKOTEI                                    '�ݔ�ID
                Call objTMST_SAGYO.GET_TMST_SAGYO(False)                                '����
            End If


            '**************************************
            '�i��Ͻ��̓���
            '**************************************
            Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
            objTMST_ITEM.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                        '�i������
            Call objTMST_ITEM.GET_TMST_ITEM(False)                                      '����


            '************************
            '�݌ɍX�V�����̓o�^
            '************************
            Dim objTEVD_STOCK_LOG As New TBL_TEVD_STOCK_LOG(Owner, ObjDb, ObjDbLog)     '�݌ɍX�V����ð��ٸ׽
            objTEVD_STOCK_LOG.FENTRY_DT = Now                                           '�o�^����
            objTEVD_STOCK_LOG.FPALLET_ID = objTRST_STOCK.FPALLET_ID                     '��گ�ID
            objTEVD_STOCK_LOG.FTERM_ID = objTDSP_TERM.FTERM_ID                          '�[��ID
            objTEVD_STOCK_LOG.FTERM_NAME = objTDSP_TERM.FTERM_NAME                      '�[����
            objTEVD_STOCK_LOG.FUSER_ID = objTMST_USER.FUSER_ID                          'հ�ްID
            objTEVD_STOCK_LOG.FUSER_NAME = objTMST_USER.FUSER_NAME                      'հ�ް��
            objTEVD_STOCK_LOG.FPLACE_CD = objTMST_TRK.FPLACE_CD                         '�ۊǏꏊ����
            objTEVD_STOCK_LOG.FAREA_CD = objTMST_TRK.FAREA_CD                           '�ر
            objTEVD_STOCK_LOG.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD                      '�i������
            objTEVD_STOCK_LOG.FHINMEI = objTMST_ITEM.FHINMEI                            '�i��
            objTEVD_STOCK_LOG.FLOT_NO = strDenbunDtl(DSPLOT_NO)                         'ۯć�
            objTEVD_STOCK_LOG.FSAGYOU_KIND = objTMST_SAGYO.FSAGYOU_KIND                 '��Ǝ��
            objTEVD_STOCK_LOG.FNUM_IN_CASE = objTMST_ITEM.FNUM_IN_CASE                  '�������
            objTEVD_STOCK_LOG.FTANI = objTMST_ITEM.FTANI                                '�P��
            objTEVD_STOCK_LOG.FSEIHIN_KUBUN = TO_DECIMAL(strDenbunDtl(DSPSEIHIN_KUBUN)) '���i�敪
            objTEVD_STOCK_LOG.FZAIKO_KUBUN = TO_DECIMAL(strDenbunDtl(DSPZAIKO_KUBUN))   '�݌ɋ敪
            objTEVD_STOCK_LOG.FRECEIVEPAY_NUM = TO_DECIMAL(strDenbunDtl(DSPTR_VOL))     '�󕥐���
            objTEVD_STOCK_LOG.FZAIKO_NUM = TO_DECIMAL(strDenbunDtl(DSPTR_VOL))          '�݌ɐ���
            objTEVD_STOCK_LOG.FSAGYOU_CONTENT = objTMST_SAGYO.FSAGYOU_CONTENT           '��Ɠ��e
            objTEVD_STOCK_LOG.ADD_TEVD_STOCK_LOG_SEQ()


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
