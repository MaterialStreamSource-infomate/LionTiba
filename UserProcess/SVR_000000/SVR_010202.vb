'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�o�Ɋ�������
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_010202
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �׽�ϐ���`                                                                          "
    Private mFPALLET_ID As String                 '��گ�ID
    Private mFINOUT_STS As Nullable(Of Integer)   'IN/OUT
#End Region
#Region "  �����è��`                                                                          "
    ''' =======================================
    ''' <summary>��گ�ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FPALLET_ID() As String
        Get
            Return mFPALLET_ID
        End Get
        Set(ByVal Value As String)
            mFPALLET_ID = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>IN/OUT</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FINOUT_STS() As Nullable(Of Integer)
        Get
            Return mFINOUT_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFINOUT_STS = Value
        End Set
    End Property
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
#Region "  Ҳݏ���(�֐�)                                                                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Ҳݏ���(�֐�)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ExecCmdFunction()

        Dim intRet As RetCode                   '�߂�l
        Dim strMsg As String                    'ү����
        Try
            '************************
            '��������
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            '***********************
            '�����è����
            '***********************
            If 1 <> 1 Then
            ElseIf IsNull(mFPALLET_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��گ�ID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFINOUT_STS) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[IN/OUT]"
                Throw New UserException(strMsg)
            End If


            '������Ǘ�
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)                 '������Ǘ��׽

            '�݌ɏ��
            Dim intRES_KIND As Integer

            '�������敪
            Dim intCARRYQUE_KUBUN As Integer

            '************************
            '�o�ɒ��ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)       '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = mFPALLET_ID                                  '��گ�ID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                           '����


            '************************
            '�q���ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    '�ׯ�ݸ��ޯ̧�׽
            If TO_INTEGER(objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM) <> 0 And _
               TO_INTEGER(objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM) <> 0 Then
                objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM        '�ޯ̧��
                objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM   '�z��
                intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                        '����
            End If


            '************************
            '�ð����ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)      '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_ST.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO          '�ޯ̧��
            objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO     '�z��
            intRet = objTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF(True)                          '����
            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2013/04/01  �݌��ׯ�ݸނ��X�V���Ă��܂��ׁA�C��

            If objTPRG_TRK_BUF_ST.FRES_KIND = FRES_KIND_SZAIKO Or IsNotNull(objTPRG_TRK_BUF_ST.FPALLET_ID) Then
                strMsg = ERRMSG_DISP_MENTE_FINISH_NOT_AKI & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_ST.FTRK_BUF_NO) & "  ,�ޯ̧�z��:" & TO_STRING(objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY) & "]"
                Throw New UserException(strMsg)
            End If
            'If objTPRG_TRK_BUF_ST.FRES_KIND = FRES_KIND_SZAIKO Then
            '    strMsg = ERRMSG_DISP_MENTE_FINISH_NOT_AKI & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_ST.FTRK_BUF_NO) & "  ,�ޯ̧�z��:" & TO_STRING(objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY) & "]"
            '    Throw New UserException(strMsg)
            'End If

            '������������************************************************************************************************************


            '************************
            '�������ׯ�ݸ�Ͻ��̓���
            '************************
            Dim strEQ_ID As String = FEQ_ID_SKOTEI
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)                 '�ׯ�ݸ��ޯ̧Ͻ��׽
            objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO                  '�ׯ�ݸ��ޯ̧No
            intRet = objTMST_TRK.GET_TMST_TRK(True)                                     '����

            If objTMST_TRK.FBUF_KIND = FBUF_KIND_SASRS Then
                '************************
                '�ڰ�Ͻ��̓���
                '************************
                Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog) '�ڰ�Ͻ��׽
                objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO    '�ޯ̧��
                objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU     '��
                intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                       '����
                If intRet = RetCode.NotFound Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ޯ̧��:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,��:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                    Throw New UserException(strMsg)
                End If
                strEQ_ID = objTMST_CRANE.FEQ_ID
            End If


            '************************
            '����ٰ�Ͻ��̓���
            '************************
            Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)     '����ٰ�Ͻ�
            objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_RELAY.FTR_FM                '���ޯ̧��
            objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_RELAY.FTR_TO                '���ޯ̧��
            objTMST_ROUTE.FEQ_ID_CRANE_FM = strEQ_ID                            '���ڰݐݔ�ID
            objTMST_ROUTE.FEQ_ID_CRANE_TO = FEQ_ID_SKOTEI                       '��ڰݐݔ�ID
            intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                         '����


            '************************
            '�݌Ɉ������̓���
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '�݌Ɉ������׽
            objTSTS_HIKIATE.FPALLET_ID = mFPALLET_ID                            '��گ�ID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                    '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[��گ�ID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�݌Ɉړ�
            '************************
            Dim objSVR_100103_ST As New SVR_100103(Owner, ObjDb, ObjDbLog) '�݌Ɉړ��׽
            objSVR_100103_ST.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY    '�ׯ�ݸ��ޯ̧(�o�ɒ��ޯ̧)
            objSVR_100103_ST.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_ST       '�ׯ�ݸ��ޯ̧(�ð����ޯ̧)
            objSVR_100103_ST.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID '��گ�ID
            objSVR_100103_ST.FINOUT_STS = mFINOUT_STS                      'INOUT
            objSVR_100103_ST.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '��Ǝ��(�Č�����)
            objSVR_100103_ST.INTCLEAR_FM_FLAG = FLAG_OFF                   '�������ر�׸�
            objSVR_100103_ST.STOCK_TRNS()                                  '�ړ�


            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/08/24  ����TO�ړ��ׯ�ݸ��ޯ̧���̗��p
            '************************
            '�ׯ�ݸޏ��ꕔ�L��
            '************************
            Dim intFTR_TO As Nullable(Of Integer) = objTPRG_TRK_BUF_ST.FTR_TO            '����TO�ׯ�ݸ��ޯ̧��
            Dim intFTR_IDOU As Nullable(Of Integer) = objTPRG_TRK_BUF_RELAY.FTR_IDOU     '����TO�ړ��ׯ�ݸ��ޯ̧��
            '������������************************************************************************************************************


            '***********************
            '�[��Ͻ��̓���
            '***********************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(Owner, ObjDb, ObjDbLog)               '�[��Ͻ�
            If IsNull(objTSTS_HIKIATE.FTERM_ID) = False Then
                objTDSP_TERM.FTERM_ID = objTSTS_HIKIATE.FTERM_ID                        '�[��ID
                Call objTDSP_TERM.GET_TDSP_TERM(False)                                  '����
            End If


            '***********************
            'հ�ްϽ��̓���
            '***********************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)               'հ�ްϽ�
            If IsNull(objTSTS_HIKIATE.FUSER_ID) = False Then
                objTMST_USER.FUSER_ID = objTSTS_HIKIATE.FUSER_ID                        'հ�ްID
                Call objTMST_USER.GET_TMST_USER(False)                                  '����
            End If


            '************************
            '�������ׯ�ݸ�Ͻ��̓���
            '************************
            objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO                  '�ׯ�ݸ��ޯ̧No
            Call objTMST_TRK.GET_TMST_TRK(False)                                        '����


            '***********************
            '��Ǝ�ʖ�������̓���
            '***********************
            Dim objTMST_SAGYO As New TBL_TMST_SAGYO(Owner, ObjDb, ObjDbLog)             '��Ǝ�ʖ�������
            If IsNull(objTSTS_HIKIATE.FSAGYOU_KIND) = False Then
                objTMST_SAGYO.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND               '��Ǝ��
                objTMST_SAGYO.FEQ_ID = FEQ_ID_SKOTEI                                    '�ݔ�ID
                Call objTMST_SAGYO.GET_TMST_SAGYO(False)                                '����
            End If


            '************************
            '�݌ɏ��̎擾
            '************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)             '�݌ɏ��׽
            Dim objTRST_STOCK_BASE As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)        '�݌ɏ��׽
            objTRST_STOCK_BASE.FPALLET_ID = mFPALLET_ID                                 '��گ�ID
            objTRST_STOCK_BASE.GET_TRST_STOCK_KONSAI(False)
            For Each objTRST_STOCK In objTRST_STOCK_BASE.ARYME
                '(ٰ��:���ڍ݌ɐ�)

                '**************************************
                '�i��Ͻ��̓���
                '**************************************
                Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                objTMST_ITEM.FHINMEI_CD = objTRST_STOCK.FHINMEI_CD                          '�i������
                Call objTMST_ITEM.GET_TMST_ITEM(False)                                      '����

                '************************
                '�݌ɍX�V�����̓o�^
                '************************
                Dim objTEVD_STOCK_LOG As New TBL_TEVD_STOCK_LOG(Owner, ObjDb, ObjDbLog)     '�݌ɍX�V����ð��ٸ׽
                objTEVD_STOCK_LOG.FENTRY_DT = Now                                           '�o�^����
                objTEVD_STOCK_LOG.FPALLET_ID = mFPALLET_ID                                  '��گ�ID
                objTEVD_STOCK_LOG.FTERM_ID = objTDSP_TERM.FTERM_ID                          '�[��ID
                objTEVD_STOCK_LOG.FTERM_NAME = objTDSP_TERM.FTERM_NAME                      '�[����
                objTEVD_STOCK_LOG.FUSER_ID = objTMST_USER.FUSER_ID                          'հ�ްID
                objTEVD_STOCK_LOG.FUSER_NAME = objTMST_USER.FUSER_NAME                      'հ�ް��
                objTEVD_STOCK_LOG.FPLACE_CD = objTMST_TRK.FPLACE_CD                         '�ۊǏꏊ����
                objTEVD_STOCK_LOG.FAREA_CD = objTMST_TRK.FAREA_CD                           '�ر
                objTEVD_STOCK_LOG.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD                      '�i������
                objTEVD_STOCK_LOG.FHINMEI = objTMST_ITEM.FHINMEI                            '�i��
                objTEVD_STOCK_LOG.FLOT_NO = objTRST_STOCK.FLOT_NO                           'ۯć�
                objTEVD_STOCK_LOG.FSAGYOU_KIND = objTMST_SAGYO.FSAGYOU_KIND                 '��Ǝ��
                objTEVD_STOCK_LOG.FNUM_IN_CASE = objTMST_ITEM.FNUM_IN_CASE                  '�������
                objTEVD_STOCK_LOG.FTANI = objTMST_ITEM.FTANI                                '�P��
                objTEVD_STOCK_LOG.FSEIHIN_KUBUN = objTRST_STOCK.FSEIHIN_KUBUN               '���i�敪
                objTEVD_STOCK_LOG.FRECEIVEPAY_NUM = objTRST_STOCK.FTR_VOL                   '�󕥐���
                objTEVD_STOCK_LOG.FZAIKO_NUM = objTRST_STOCK.FTR_VOL                        '�݌ɐ���
                objTEVD_STOCK_LOG.FSAGYOU_CONTENT = objTMST_SAGYO.FSAGYOU_CONTENT           '��Ɠ��e
                objTEVD_STOCK_LOG.ADD_TEVD_STOCK_LOG_SEQ()
            Next


            '**************************************
            '�ۊǏo�[�L�^�ǉ�
            '**************************************
            Call Add_TBL_TEVD_SUITOU(objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO _
                                   , objTPRG_TRK_BUF_ST.FTRK_BUF_NO _
                                   , objTSTS_HIKIATE.FSAGYOU_KIND _
                                   , objTSTS_HIKIATE.FTERM_ID _
                                   , objTSTS_HIKIATE.FUSER_ID _
                                   , DEFAULT_STRING _
                                   , DEFAULT_STRING _
                                   , objTRST_STOCK_BASE _
                                    )


            '**************************************
            '�z����
            '**************************************
            objTRST_STOCK_BASE.ARYME_CLEAR()


            '********************************
            '�q��/�o�ɒ�/�o�ɐ��ޯ̧�̍X�V
            '********************************

            '===========================
            '�o�ɐ��ޯ̧�̍X�V
            '===========================
            If TO_INTEGER(objTMST_ROUTE.FBUF_TO) = TO_INTEGER(objTMST_ROUTE.FBUF_NEXT) Or _
               TO_INTEGER(objTMST_ROUTE.FBUF_RELAY) = 0 Or _
               TO_INTEGER(objTMST_ROUTE.FBUF_NEXT) = 0 Then
                '(�ŏI�̏ꍇ)

                objTPRG_TRK_BUF_ST.FRES_KIND = FRES_KIND_SZAIKO                             '�������
                objTPRG_TRK_BUF_ST.FRSV_PALLET = DEFAULT_STRING                             '��������گ�ID
                objTPRG_TRK_BUF_ST.FTR_FM = DEFAULT_INTEGER                                 '����FM�ޯ̧��
                objTPRG_TRK_BUF_ST.FTR_TO = DEFAULT_INTEGER                                 '����TO�ޯ̧��
                objTPRG_TRK_BUF_ST.FTR_IDOU = DEFAULT_INTEGER                               '����TO�ړ��ޯ̧��
                objTPRG_TRK_BUF_ST.FTRNS_FM = DEFAULT_STRING                                '�����w�ߗpFM
                objTPRG_TRK_BUF_ST.FTRNS_TO = DEFAULT_STRING                                '�����w�ߗpTO
                objTPRG_TRK_BUF_ST.FRSV_BUF_FM = DEFAULT_INTEGER                            'FM�����ׯ�ݸއ�
                objTPRG_TRK_BUF_ST.FRSV_ARRAY_FM = DEFAULT_INTEGER                          'FM�����z��
                objTPRG_TRK_BUF_ST.FRSV_BUF_TO = DEFAULT_INTEGER                            'TO�����ׯ�ݸއ�
                objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO = DEFAULT_INTEGER                          'TO�����z��
                objTPRG_TRK_BUF_ST.FDISP_ADDRESS_FM = DEFAULT_STRING                        'FM�\�L�p���ڽ
                objTPRG_TRK_BUF_ST.FDISP_ADDRESS_TO = DEFAULT_STRING                        'TO�\�L�p���ڽ
                objTPRG_TRK_BUF_ST.FBUF_IN_DT = Now                                         '�ޯ̧������
                objTPRG_TRK_BUF_ST.UPDATE_TPRG_TRK_BUF()                                    '�X�V

            Else
                '(���p�̏ꍇ)

                '************************
                '����ٰ�Ͻ��̓���
                '************************
                Dim objTMST_ROUTE_NEXT As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)        '����ٰ�Ͻ�
                objTMST_ROUTE_NEXT.FBUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO                 '���ޯ̧��
                objTMST_ROUTE_NEXT.FBUF_TO = objTPRG_TRK_BUF_RELAY.FTR_TO                   '���ޯ̧��
                objTMST_ROUTE_NEXT.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                          '���ڰݐݔ�ID
                objTMST_ROUTE_NEXT.FEQ_ID_CRANE_TO = FEQ_ID_SKOTEI                          '��ڰݐݔ�ID
                intRet = objTMST_ROUTE_NEXT.GET_TMST_ROUTE(True)                            '����

                '�������
                Select Case TO_INTEGER(objTMST_ROUTE_NEXT.FCARRYQUE_KUBUN)
                    Case FCARRYQUE_KUBUN_SIN                                 '����
                        '�������
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '���o�\��

                        '�������敪
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SIN              '����

                        '�������N��
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '�N��(���Ɉ�������)

                    Case FCARRYQUE_KUBUN_SOUT                                '�o��
                        '�������
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '���o�\��

                        '�������敪
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SOUT             '�o��

                        '�������N��
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '�N��(���Ɉ�������)

                    Case FCARRYQUE_KUBUN_STANA_MOVE                          '�I�Ԕ���
                        '�������
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '���o�\��

                        '�������敪
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SIN              '����

                        '�������N��
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '�N��(���Ɉ�������)

                    Case FCARRYQUE_KUBUN_SMOVE                               '����
                        '�������
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '���o�\��

                        '�������敪
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SMOVE            '����

                        '�������N��
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '�N��(������������)

                    Case FCARRYQUE_KUBUN_SBUNKI                              '����
                        '�������
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '���o�\��

                        '�������敪
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SMOVE            '����

                        '�������N��
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '�N��(������������)

                    Case Else                                               '���̑�
                        '�������
                        intRES_KIND = FRES_KIND_SZAIKO                                       '�݌ɒI

                        '�������敪
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SMOVE            '����

                        '�������N��
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '�N��(������������)

                End Select

                objTPRG_TRK_BUF_ST.FRSV_PALLET = objTPRG_TRK_BUF_ST.FPALLET_ID                  '��������گ�ID
                objTPRG_TRK_BUF_ST.FRES_KIND = intRES_KIND                                      '�������
                objTPRG_TRK_BUF_ST.FTR_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO                      '����FM�ޯ̧��
                objTPRG_TRK_BUF_ST.FTR_TO = objTPRG_TRK_BUF_RELAY.FTR_TO                        '����TO�ޯ̧��
                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2013/06/04  �q�֏o�ɂŕK�v
                objTPRG_TRK_BUF_ST.FTR_IDOU = objTPRG_TRK_BUF_RELAY.FTR_IDOU                '����TO�ړ��ޯ̧��
                'objTPRG_TRK_BUF_ST.FTR_IDOU = DEFAULT_INTEGER                                   '����TO�ړ��ޯ̧��
                '������������************************************************************************************************************
                objTPRG_TRK_BUF_ST.FTRNS_FM = DEFAULT_STRING                                    '�����w�ߗpFM
                objTPRG_TRK_BUF_ST.FTRNS_TO = DEFAULT_STRING                                    '�����w�ߗpTO
                objTPRG_TRK_BUF_ST.FRSV_BUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO                 'FM�����ׯ�ݸއ�
                objTPRG_TRK_BUF_ST.FRSV_ARRAY_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY            'FM�����z��
                objTPRG_TRK_BUF_ST.FRSV_BUF_TO = DEFAULT_INTEGER                                'TO�����ׯ�ݸއ�
                objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO = DEFAULT_INTEGER                              'TO�����z��
                objTPRG_TRK_BUF_ST.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM    'FM�\�L�p���ڽ
                objTPRG_TRK_BUF_ST.FDISP_ADDRESS_TO = DEFAULT_STRING                            'TO�\�L�p���ڽ
                objTPRG_TRK_BUF_ST.FBUF_IN_DT = Now                                             '�ޯ̧������
                objTPRG_TRK_BUF_ST.UPDATE_TPRG_TRK_BUF()                                        '�X�V

            End If


            '************************
            '�݌ɍ폜����
            '************************
            If TO_INTEGER(objTMST_ROUTE.FBUF_NEXT) = 0 Then
                '(�����悪�폜�̏ꍇ)


                '������������************************************************************************************************************
                'Checked SystemMate:N.Dounoshita 2011/10/19 �ׯ�ݸލ폜�̕����K�����Ǝv����

                '************************
                '�ׯ�ݸލ폜
                '************************
                Dim objSVR_100302 As New SVR_100302(Owner, ObjDb, ObjDbLog)
                objSVR_100302.FTRK_BUF_NO = objTPRG_TRK_BUF_ST.FTRK_BUF_NO  '�ޯ̧��
                objSVR_100302.FPALLET_ID = mFPALLET_ID                      '��گ�ID
                objSVR_100302.FINOUT_STS = FINOUT_STS_STRK_DELETE            'IN/OUT
                objSVR_100302.FTERM_ID = FTERM_ID_SKOTEI                      '�[��ID
                objSVR_100302.FUSER_ID = FUSER_ID_SKOTEI                      'հ�ްID
                objSVR_100302.MENTE_DELETE()                                '�ׯ�ݸލ폜


                ''************************
                ''�݌ɍ폜
                ''************************
                'Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '�݌ɍ폜�׽
                'objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_ST          '�ׯ�ݸ��ޯ̧
                'objSVR_100102.FPALLET_ID = mFPALLET_ID                      '��گ�ID
                'objSVR_100102.FINOUT_STS = FINOUT_STS_STRK_DELETE            'INOUT
                'objSVR_100102.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '��Ǝ��
                'objSVR_100102.STOCK_DELETE()                                '�폜

                '������������************************************************************************************************************

            End If


            '������������************************************************************************************************************
            'Checked JobMate:N.Dounoshita 2011/09/23 ��گĕ��o���܂ō݌Ɉ�������ێ�����׺��ı��

            ' '' '' ''************************
            ' '' '' ''�݌Ɉ������̍폜
            ' '' '' ''************************
            '' '' ''If TO_INTEGER(objTPRG_TRK_BUF_ST.FTRK_BUF_NO) = TO_INTEGER(objTPRG_TRK_BUF_RELAY.FTR_TO) Then

            '' '' ''    '(�o�ɐ悪�ŏI�̏ꍇ)
            '' '' ''    objTSTS_HIKIATE = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)  '�݌Ɉ������׽
            '' '' ''    objTSTS_HIKIATE.FPALLET_ID = mFPALLET_ID
            '' '' ''    objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()       '�폜

            '' '' ''End If
            '������������************************************************************************************************************


            '===========================
            '�q���ޯ̧�̍X�V
            '===========================
            If TO_INTEGER(objTMST_SAGYO.FKEEP_RSVRAC_FLAG) = FLAG_OFF _
            Or TO_INTEGER(objTMST_ROUTE.FBUF_NEXT) = 0 _
            Then
                '(�I�\���ێ����Ȃ��ꍇ)


                If (objTPRG_TRK_BUF_ASRS Is Nothing) = False Then
                    If objTPRG_TRK_BUF_ASRS.FRSV_PALLET = mFPALLET_ID Then
                        objTPRG_TRK_BUF_ASRS.CLEAR_TPRG_TRK_BUF()   '���
                    End If
                End If


                '������������************************************************************************************************************
                'Checked SystemMate:N.Dounoshita 2011/09/23 �I�̗\��ێ�

            Else

                objTPRG_TRK_BUF_ST.FRSV_PALLET = objTPRG_TRK_BUF_RELAY.FRSV_PALLET                  '��������گ�ID
                objTPRG_TRK_BUF_ST.FTR_FM = objTPRG_TRK_BUF_RELAY.FTR_FM                            '����FM�ׯ�ݸ��ޯ̧��
                'objTPRG_TRK_BUF_ST.FTR_TO = objTPRG_TRK_BUF_RELAY.FTR_TO                            '����TO�ׯ�ݸ��ޯ̧��
                'objTPRG_TRK_BUF_ST.FTR_IDOU = objTPRG_TRK_BUF_RELAY.FTR_IDOU                        '����TO�ړ��ׯ�ݸ��ޯ̧��
                objTPRG_TRK_BUF_ST.FTRNS_FM = objTPRG_TRK_BUF_RELAY.FTRNS_FM                        '�����w�ߗpFM
                'objTPRG_TRK_BUF_ST.FTRNS_TO = objTPRG_TRK_BUF_RELAY.FTRNS_TO                        '�����w�ߗpTO
                objTPRG_TRK_BUF_ST.FRSV_BUF_FM = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM                  'FM�����ׯ�ݸ��ޯ̧��
                objTPRG_TRK_BUF_ST.FRSV_ARRAY_FM = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM              'FM�����ׯ�ݸ��ޯ̧�z��
                'objTPRG_TRK_BUF_ST.FRSV_BUF_TO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO                  'TO�����ׯ�ݸ��ޯ̧��
                'objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO              'TO�����ׯ�ݸ��ޯ̧�z��
                objTPRG_TRK_BUF_ST.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM        'FM�\�L�p���ڽ
                'objTPRG_TRK_BUF_ST.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO        'TO�\�L�p���ڽ
                objTPRG_TRK_BUF_ST.FDISPLOG_ADDRESS_FM = objTPRG_TRK_BUF_RELAY.FDISPLOG_ADDRESS_FM  'FM�\�L�p���ڽ_۸ޗp
                'objTPRG_TRK_BUF_ST.FDISPLOG_ADDRESS_TO = objTPRG_TRK_BUF_RELAY.FDISPLOG_ADDRESS_TO  'TO�\�L�p���ڽ_۸ޗp
                objTPRG_TRK_BUF_ST.UPDATE_TPRG_TRK_BUF()                                            '�X�V

                '������������************************************************************************************************************

            End If


            '===========================
            '�o�ɒ��ޯ̧�̍X�V
            '===========================
            objTPRG_TRK_BUF_RELAY.CLEAR_TPRG_TRK_BUF()      '���


            '************************
            '�����w��QUE�̍폜
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '�ݽ�ݽ��
            objTPLN_CARRY_QUE.FPALLET_ID = mFPALLET_ID                              '��گ�ID
            objTPLN_CARRY_QUE.DELETE_TPLN_CARRY_QUE_PALLET()                        '�폜

            '************************
            '�����w��QUE�̍ēo�^
            '(�����w���̂݁A���Ɏw���͓��Ɉ��������ɂĎ��s)
            '************************
            If intRES_KIND = FRES_KIND_SRSV_TRNS_OUT And _
               intCARRYQUE_KUBUN <> FCARRYQUE_KUBUN_SIN Then
                '************************
                '�D������
                '************************
                Dim intFPRIORITY As Integer                                             '�D������
                objTMST_SAGYO.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND               '��Ǝ��
                objTMST_SAGYO.FEQ_ID = FEQ_ID_SKOTEI                                    '�ݔ�ID
                objTMST_SAGYO.GET_TMST_SAGYO(False)                                     '�擾
                intFPRIORITY = TO_INTEGER(objTMST_SAGYO.FPRIORITY)
                If intFPRIORITY < FPRIORITY_SLOW Then intFPRIORITY = FPRIORITY_SLOW

                '************************
                '�����w��QUE�o�^
                '************************
                objTPLN_CARRY_QUE.FCARRYQUE_D = Now                                     '�����w����
                objTPLN_CARRY_QUE.FEQ_ID = FEQ_ID_SKOTEI                                '�ݔ�ID
                objTPLN_CARRY_QUE.FPRIORITY = FPRIORITY_SLOW                             '��ײ��è�敪
                objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID            '��گ�ID
                objTPLN_CARRY_QUE.FCARRYQUE_KUBUN = intCARRYQUE_KUBUN                   '�����敪
                objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON             '�����w����(���w��)
                objTPLN_CARRY_QUE.FENTRY_DT = Now                                       '�o�^����
                objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '�X�V����
                objTPLN_CARRY_QUE.ADD_TPLN_CARRY_QUE_ORDER()                            '�o�^
            End If


            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2011/10/05 ������ɂ��F�X����̂ō폜���Ȃ�

            '************************
            '�ري֘A�t���̍폜
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)   '�ري֘A�t���׽
            objTPRG_SERIAL.FPALLET_ID = mFPALLET_ID                             '��گ�ID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                 '�폜

            '������������************************************************************************************************************


            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/08/24  ����TO�ړ��ׯ�ݸ��ޯ̧���̗��p


            If intFTR_TO = objTPRG_TRK_BUF_ST.FTRK_BUF_NO _
               And IsNotNull(intFTR_IDOU) _
                Then
                '(����ɍs���悪�ݒ肳��Ă���ꍇ)


                '************************************************
                '�ׯ�ݸ��ޯ̧(������)       �擾
                '************************************************
                Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_TO.FTRK_BUF_NO = intFTR_IDOU                    '�ׯ�ݸ��ޯ̧��
                intRet = objTPRG_TRK_BUF_TO.GET_TPRG_TRK_BUF_AKI_HIRA()         '�擾
                If intRet <> RetCode.OK Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_TO.FTRK_BUF_NO) & "]"
                    Throw New UserException(strMsg)
                End If


                '************************
                '�݌Ɉړ�
                '************************
                Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '�݌Ɉړ��׽
                objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_ST       '�ׯ�ݸ��ޯ̧(FM)
                objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_TO       '�ׯ�ݸ��ޯ̧(TO)
                objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID    '��گ�ID
                objSVR_100103.FINOUT_STS = FINOUT_STS_SIN_UKETUKE           'INOUT
                objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '��Ǝ��
                objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '�������ر�׸�
                objSVR_100103.STOCK_TRNS()                                  '�ړ�


            End If


            '������������************************************************************************************************************


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2012/08/22 ���ꏈ��



            '������������************************************************************************************************************


            '************************
            '�������N��
            '************************
            objTPRG_TIMER.CLEAR_PROPERTY()
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '�N��


            '************************
            '���튮��
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & _
                                "  [��گ�ID:" & mFPALLET_ID & _
                                "]")


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '���������ьŗL

    '���������ьŗL
    '**********************************************************************************************

End Class
