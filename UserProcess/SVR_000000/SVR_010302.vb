'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z������������
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_010302
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

            '�ڰ�ID
            Dim strEQ_ID_CRANE_TO As String = FEQ_ID_SKOTEI

            '************************
            '�����w��QUE�̓���
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)         '�����w��QUE
            objTPLN_CARRY_QUE.FPALLET_ID = mFPALLET_ID                                      '��گ�ID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(True)                             '����


            '************************
            '�������ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)       '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = mFPALLET_ID                                  '��گ�ID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                           '����
            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/05/30 ���ꏈ��
            Dim intFTR_IDOU As Nullable(Of Integer) = objTPRG_TRK_BUF_RELAY.FTR_IDOU        '����TO�ړ��ׯ�ݸ��ޯ̧��
            '������������************************************************************************************************************


            '************************
            '�������ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)          '�ׯ�ݸ��ޯ̧�׽
            If TO_INTEGER(objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM) <> 0 And _
               TO_INTEGER(objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM) <> 0 Then
                objTPRG_TRK_BUF_FM.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM          '�ޯ̧��
                objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM     '�z��
                intRet = objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF(True)                          '����
            End If


            '************************
            '�������ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)      '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_TO.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO          '�ޯ̧��
            objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO     '�z��
            intRet = objTPRG_TRK_BUF_TO.GET_TPRG_TRK_BUF(True)                          '����
            If objTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SZAIKO Or _
               objTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Then
                If objTPRG_TRK_BUF_TO.FRSV_PALLET <> objTPRG_TRK_BUF_RELAY.FPALLET_ID Then
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_TO.FTRK_BUF_NO) & "  ,�ޯ̧�z��:" & TO_STRING(objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY) & "]"
                    Throw New UserException(strMsg)
                End If
            End If


            '************************
            '����ٰ�Ͻ��̓���
            '************************
            Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)     '����ٰ�Ͻ�
            objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_RELAY.FTR_FM                '���ޯ̧��
            objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_RELAY.FTR_TO                '���ޯ̧��
            objTMST_ROUTE.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                       '���ڰݐݔ�ID
            objTMST_ROUTE.FEQ_ID_CRANE_TO = objTPLN_CARRY_QUE.FEQ_ID            '��ڰݐݔ�ID
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
            Dim objSVR_100103_ST As New SVR_100103(Owner, ObjDb, ObjDbLog)      '�݌Ɉړ��׽
            objSVR_100103_ST.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY         '�ׯ�ݸ��ޯ̧(�������ޯ̧)
            objSVR_100103_ST.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_TO            '�ׯ�ݸ��ޯ̧(�������ޯ̧)
            objSVR_100103_ST.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID      '��گ�ID
            objSVR_100103_ST.FINOUT_STS = mFINOUT_STS                           'INOUT
            objSVR_100103_ST.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND        '��Ǝ��(�Č�����)
            objSVR_100103_ST.INTCLEAR_FM_FLAG = FLAG_OFF                        '�������ر�׸�
            objSVR_100103_ST.STOCK_TRNS()                                       '�ړ�


            '********************************
            '������/������/�������ޯ̧�̍X�V
            '********************************
            '
            '===========================
            '�������ޯ̧�̍X�V
            '===========================
            If TO_INTEGER(objTMST_ROUTE.FBUF_TO) = TO_INTEGER(objTMST_ROUTE.FBUF_NEXT) Or _
               TO_INTEGER(objTMST_ROUTE.FBUF_RELAY) = 0 Or _
               TO_INTEGER(objTMST_ROUTE.FBUF_NEXT) = 0 Then
                '(�ŏI�̏ꍇ)
                objTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SZAIKO                              '�������
                objTPRG_TRK_BUF_TO.FRSV_PALLET = DEFAULT_STRING                             '��������گ�ID
                objTPRG_TRK_BUF_TO.FTR_FM = DEFAULT_INTEGER                                 '����FM�ޯ̧��
                objTPRG_TRK_BUF_TO.FTR_TO = DEFAULT_INTEGER                                 '����TO�ޯ̧��
                objTPRG_TRK_BUF_TO.FTR_IDOU = DEFAULT_INTEGER                               '����TO�ړ��ޯ̧��
                objTPRG_TRK_BUF_TO.FTRNS_FM = DEFAULT_STRING                                '�����w�ߗpFM
                objTPRG_TRK_BUF_TO.FTRNS_TO = DEFAULT_STRING                                '�����w�ߗpTO
                objTPRG_TRK_BUF_TO.FRSV_BUF_FM = DEFAULT_INTEGER                            'FM�����ׯ�ݸއ�
                objTPRG_TRK_BUF_TO.FRSV_ARRAY_FM = DEFAULT_INTEGER                          'FM�����z��
                objTPRG_TRK_BUF_TO.FRSV_BUF_TO = DEFAULT_INTEGER                            'TO�����ׯ�ݸއ�
                objTPRG_TRK_BUF_TO.FRSV_ARRAY_TO = DEFAULT_INTEGER                          'TO�����z��
                objTPRG_TRK_BUF_TO.FDISP_ADDRESS_FM = DEFAULT_STRING                        'FM�\�L�p���ڽ
                objTPRG_TRK_BUF_TO.FDISP_ADDRESS_TO = DEFAULT_STRING                        'TO�\�L�p���ڽ
                objTPRG_TRK_BUF_TO.FBUF_IN_DT = Now                                         '�ޯ̧������
                objTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()                                    '�X�V

                '************************
                '�݌ɏ��̍X�V
                '************************
            Else
                '(���p�̏ꍇ)
                '************************
                '�������ڰݐݔ�ID�̓���
                '************************
                Dim intRSV_BUF_TO As Nullable(Of Integer) = DEFAULT_INTEGER                 'TO�����ׯ�ݸއ�
                Dim intRSV_ARRAY_TO As Nullable(Of Integer) = DEFAULT_INTEGER               'TO�����z��
                Dim strDISP_ADDRESS_TO As String = DEFAULT_STRING                           'TO�\�L�p���ڽ

                '************************
                '�ŏI���B�ޯ̧�̓���
                '************************
                Dim objTPRG_TRK_BUF_END As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     '�ׯ�ݸ��ޯ̧�׽
                objTPRG_TRK_BUF_END.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FTR_TO             '�����q���ޯ̧��
                objTPRG_TRK_BUF_END.FRSV_PALLET = mFPALLET_ID                              '��������گ�ID
                intRet = objTPRG_TRK_BUF_END.GET_TPRG_TRK_BUF_RSV_PALLET()
                If intRet = RetCode.OK Then
                    '************************
                    '�ŏI���B�ׯ�ݸ�Ͻ��̓���
                    '************************
                    Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)             '�ׯ�ݸ��ޯ̧Ͻ��׽
                    objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FTR_TO                  '�ׯ�ݸ��ޯ̧No
                    intRet = objTMST_TRK.GET_TMST_TRK(True)                                 '����

                    If TO_INTEGER(objTMST_TRK.FBUF_KIND) = FBUF_KIND_SASRS Then
                        '************************
                        '�ڰ�Ͻ��̓���
                        '************************
                        Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)     '�ڰ�Ͻ��׽
                        objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_END.FTRK_BUF_NO         '�ޯ̧��
                        objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_END.FRAC_RETU          '��
                        intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                           '����
                        If intRet = RetCode.NotFound Then
                            '(������Ȃ��ꍇ)
                            strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ޯ̧��:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,��:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                            Throw New UserException(strMsg)
                        End If

                        '�ڰݐݔ�ID�̓���
                        strEQ_ID_CRANE_TO = objTMST_CRANE.FEQ_ID
                    End If

                    intRSV_BUF_TO = objTPRG_TRK_BUF_END.FTRK_BUF_NO                         'TO�����ׯ�ݸއ�
                    intRSV_ARRAY_TO = objTPRG_TRK_BUF_END.FTRK_BUF_ARRAY                    'TO�����z��
                    strDISP_ADDRESS_TO = objTPRG_TRK_BUF_END.FDISP_ADDRESS                  'TO�\�L�p���ڽ
                End If


                '************************
                '����ٰ�Ͻ��̓���
                '************************
                Dim objTMST_ROUTE_NEXT As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)        '����ٰ�Ͻ�
                objTMST_ROUTE_NEXT.FBUF_FM = objTPRG_TRK_BUF_TO.FTRK_BUF_NO                 '���ޯ̧��
                objTMST_ROUTE_NEXT.FBUF_TO = objTPRG_TRK_BUF_RELAY.FTR_TO                   '���ޯ̧��
                objTMST_ROUTE_NEXT.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                          '���ڰݐݔ�ID
                objTMST_ROUTE_NEXT.FEQ_ID_CRANE_TO = strEQ_ID_CRANE_TO                      '��ڰݐݔ�ID
                intRet = objTMST_ROUTE_NEXT.GET_TMST_ROUTE(True)                            '����

                '�������
                Select Case TO_INTEGER(objTMST_ROUTE_NEXT.FCARRYQUE_KUBUN)
                    Case FCARRYQUE_KUBUN_SIN                                 '����
                        '�������
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '���o�\��

                        '�������敪
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SIN              '����

                        '�������N��
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '�N��(������������)

                    Case FCARRYQUE_KUBUN_SOUT                                '�o��
                        '�������
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '���o�\��

                        '�������敪
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SOUT             '�o��

                        '�������N��
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '�N��(������������)

                    Case FCARRYQUE_KUBUN_STANA_MOVE                          '�I�Ԕ���
                        '�������
                        intRES_KIND = FRES_KIND_SRSV_TRNS_OUT                                '���o�\��

                        '�������敪
                        intCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SIN              '����

                        '�������N��
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '�N��(������������)

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

                objTPRG_TRK_BUF_TO.FRSV_PALLET = objTPRG_TRK_BUF_TO.FPALLET_ID                  '��������گ�ID
                objTPRG_TRK_BUF_TO.FRES_KIND = intRES_KIND                                      '�������
                objTPRG_TRK_BUF_TO.FTR_FM = objTPRG_TRK_BUF_TO.FTRK_BUF_NO                      '����FM�ޯ̧��
                objTPRG_TRK_BUF_TO.FTR_TO = objTPRG_TRK_BUF_RELAY.FTR_TO                        '����TO�ޯ̧��
                objTPRG_TRK_BUF_TO.FTR_IDOU = DEFAULT_INTEGER                                   '����TO�ړ��ޯ̧��
                objTPRG_TRK_BUF_TO.FTRNS_FM = DEFAULT_STRING                                    '�����w�ߗpFM
                objTPRG_TRK_BUF_TO.FTRNS_TO = DEFAULT_STRING                                    '�����w�ߗpTO
                objTPRG_TRK_BUF_TO.FRSV_BUF_FM = objTPRG_TRK_BUF_TO.FTRK_BUF_NO                 'FM�����ׯ�ݸއ�
                objTPRG_TRK_BUF_TO.FRSV_ARRAY_FM = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY            'FM�����z��
                objTPRG_TRK_BUF_TO.FRSV_BUF_TO = intRSV_BUF_TO                                  'TO�����ׯ�ݸއ�
                objTPRG_TRK_BUF_TO.FRSV_ARRAY_TO = intRSV_ARRAY_TO                              'TO�����z��
                objTPRG_TRK_BUF_TO.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO    'FM�\�L�p���ڽ
                objTPRG_TRK_BUF_TO.FDISP_ADDRESS_TO = strDISP_ADDRESS_TO                        'TO�\�L�p���ڽ
                objTPRG_TRK_BUF_TO.FBUF_IN_DT = Now                                             '�ޯ̧������
                objTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()                                        '�X�V

            End If


            '===========================
            '�������ޯ̧�̍X�V
            '===========================
            If (objTPRG_TRK_BUF_FM Is Nothing) = False Then
                If objTPRG_TRK_BUF_FM.FRSV_PALLET = mFPALLET_ID Then
                    objTPRG_TRK_BUF_FM.CLEAR_TPRG_TRK_BUF()     '���
                End If
            End If

            '===========================
            '�������ޯ̧�̍X�V
            '===========================
            objTPRG_TRK_BUF_RELAY.CLEAR_TPRG_TRK_BUF()          '���


            '************************
            '�����w��QUE�̍폜
            '************************
            objTPLN_CARRY_QUE.DELETE_TPLN_CARRY_QUE_PALLET()                            '�폜

            '************************
            '�����w��QUE�̍ēo�^
            '(�����w���̂݁A���Ɏw���͓��Ɉ��������ɂĎ��s)
            '************************
            If intRES_KIND = FRES_KIND_SRSV_TRNS_OUT Then
                '************************
                '�D������
                '************************
                Dim intFPRIORITY As Integer                                             '�D������
                Dim objTMST_SAGYO As New TBL_TMST_SAGYO(Owner, ObjDb, ObjDbLog)         '��Ǝ�ʖ�������
                objTMST_SAGYO.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND               '��Ǝ��
                objTMST_SAGYO.FEQ_ID = FEQ_ID_SKOTEI                                    '�ݔ�ID
                objTMST_SAGYO.GET_TMST_SAGYO(False)                                     '�擾
                intFPRIORITY = TO_INTEGER(objTMST_SAGYO.FPRIORITY)
                If intFPRIORITY < FPRIORITY_SLOW Then intFPRIORITY = FPRIORITY_SLOW

                '************************
                '�����w��QUE�o�^
                '************************
                objTPLN_CARRY_QUE.FCARRYQUE_D = Now                                     '�����w����
                objTPLN_CARRY_QUE.FEQ_ID = strEQ_ID_CRANE_TO                            '�ݔ�ID
                objTPLN_CARRY_QUE.FPRIORITY = intFPRIORITY                              '��ײ��è�敪
                objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_TO.FPALLET_ID            '��گ�ID
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
            'JobMate:N.Dounoshita 2013/04/08 ���ꏈ��


            '****************************************************************************
            '���ꏈ��21(�o�׎w���A�o�׎w���ڍ�ð��ٍX�V)
            '****************************************************************************
            Call Special21(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_FM _
                         , objTPRG_TRK_BUF_TO _
                         , objTSTS_HIKIATE _
                         , objTPLN_CARRY_QUE _
                         )


            '****************************************************************************
            '���ꏈ��02(��ޏo�Ɏ��̎��ѐ��ʍX�V)
            '****************************************************************************
            Call Special02(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_FM _
                         , objTPRG_TRK_BUF_TO _
                         , objTSTS_HIKIATE _
                         , objTPLN_CARRY_QUE _
                         )


            '****************************************************************************
            '���ꏈ��01(�o�ɔ����������̍݌ɍ폜����)
            '****************************************************************************
            Call Special01(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_FM _
                         , objTPRG_TRK_BUF_TO _
                         , objTSTS_HIKIATE _
                         , objTPLN_CARRY_QUE _
                         , intFTR_IDOU _
                         )


            '������������************************************************************************************************************


            '************************
            '�������N��
            '************************
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '�N��
            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/06/18 ���ꏈ��
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_J310304)                            '�N��
            '������������************************************************************************************************************


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
#Region "  ���ꏈ��01(�o�ɔ����������̍݌ɍ폜����or���u�ړ�����)                                                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��01(�o�ɔ����������̍݌ɍ폜����)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">�������ׯ�ݸ�</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FM�ׯ�ݸ�</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TO�ׯ�ݸ�</param>
    ''' <param name="objTSTS_HIKIATE">�݌Ɉ������</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special01(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             , ByVal objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE _
                             , ByVal intFTR_IDOU As Nullable(Of Integer) _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        Dim strMsg As String
        Dim strMsg01 As String
        Dim strMsg02 As String
        Dim intReturn As RetCode = RetCode.OK


        '***********************************************
        '�ׯ�ݸ��ޯ̧Ͻ�(TO)
        '***********************************************
        Dim objTMST_TRK_TO As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        objTMST_TRK_TO.FTRK_BUF_NO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO    '�ׯ�ݸ��ޯ̧��
        objTMST_TRK_TO.GET_TMST_TRK()                                  '�擾
        If IsNotNull(objTMST_TRK_TO.XEQ_ID_OUT_END) Or objTMST_TRK_TO.FTRK_BUF_NO = FTRK_BUF_NO_J2062 Or objTMST_TRK_TO.FTRK_BUF_NO = FTRK_BUF_NO_J2061 Then
            '(�o�ɔ����������̏ꍇ)
            '(D41�AD42�́A��O�I�ɈႤ�����ŏo�ɔ����������s���Ă���̂ŁA����͕ʂɍs��)


            If IsNull(intFTR_IDOU) Then
                '(�ŏI�̏ꍇ)


                '*********************************************
                '�ׯ�ݸލ폜����
                '*********************************************
                Dim blnDelete As Boolean = False        '�ׯ�ݸލ폜�׸�
                Select Case objTSTS_HIKIATE.FSAGYOU_KIND
                    Case FSAGYOU_KIND_J55, FSAGYOU_KIND_J56, FSAGYOU_KIND_J57

                        '===================================
                        '�o�׎w���ڍ�
                        '===================================
                        Dim objXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
                        objXPLN_OUT_DTL.FPLAN_KEY = objTSTS_HIKIATE.FPLAN_KEY       '�v�淰
                        intRet = objXPLN_OUT_DTL.GET_XPLN_OUT_DTL(False)            '�擾
                        If intRet = RetCode.OK Then
                            '(���������ꍇ)
                            If objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JTUMI Then
                                '(�ύ��ς̏ꍇ)
                                blnDelete = True
                                strMsg01 = "�ύ����������ׯ�ݸނ��o�Ɋ������ꂽ�ׁA�����I���ׯ�ݸނ��폜���܂����B�݌�����ݽ�ŕ��u���݌ɂ����݌ɂƍ����悤�ɒ������ĉ������B"
                                strMsg02 = "[�i�ں���:" & objXPLN_OUT_DTL.FHINMEI_CD & "]"
                                strMsg02 &= "[�o�ד�:" & objXPLN_OUT_DTL.XSYUKKA_D & "]"
                                strMsg02 &= "[�Ґ���:" & objXPLN_OUT_DTL.XHENSEI_NO & "]"
                                strMsg02 &= "[�`�[��:" & objXPLN_OUT_DTL.XDENPYOU_NO & "]"
                                strMsg02 &= "[��گ�ID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                                Call AddToMsgLog(Now, FMSG_ID_J4001, strMsg01, strMsg02)
                                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & strMsg01 & strMsg02)
                            End If
                        Else
                            '(������Ȃ��ꍇ�ꍇ)
                            blnDelete = True
                        End If

                    Case Else
                        blnDelete = True
                End Select
                If blnDelete = True Then
                    '(�ׯ�ݸލ폜�̏ꍇ)


                    '************************************************************************
                    '�ׯ�ݸ�,�݌ɏ��,���̑���گĂɊ֌W������S�č폜
                    '************************************************************************
                    Call ClearDustProcess(objTPRG_TRK_BUF_TO.FPALLET_ID)


                    '************************
                    '�݌ɍ폜
                    '************************
                    Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '�݌ɍ폜�׽
                    objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF_TO          '�ׯ�ݸ��ޯ̧
                    objSVR_100102.FPALLET_ID = objTPRG_TRK_BUF_TO.FPALLET_ID    '��گ�ID
                    'objSVR_100102.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK   '�݌�ۯć�
                    objSVR_100102.FINOUT_STS = mFINOUT_STS                      'INOUT
                    objSVR_100102.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '��Ǝ��
                    objSVR_100102.STOCK_DELETE()                                '�폜


                End If


            Else
                '(�q�ւ��̏ꍇ)


                '************************************************
                '�݌ɏ��           �X�V
                '************************************************
                Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                objTRST_STOCK.FPALLET_ID = objTPRG_TRK_BUF_TO.FPALLET_ID    '��گ�ID
                objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)                   '�擾
                For ii As Integer = 0 To UBound(objTRST_STOCK.ARYME)
                    '(ٰ��:�݌�ۯć���)

                    If objTSTS_HIKIATE.FSAGYOU_KIND = FSAGYOU_KIND_J73 Or objTSTS_HIKIATE.FSAGYOU_KIND = FSAGYOU_KIND_J74 Then
                        '(�q�ւ̏ꍇ)
                        objTRST_STOCK.ARYME(ii).FTR_RES_VOL = 0                                                             '����������
                    Else
                        '(�o�ׂ̏ꍇ)
                        objTRST_STOCK.ARYME(ii).FTR_RES_VOL = objTRST_STOCK.ARYME(ii).FTR_VOL - objTSTS_HIKIATE.FTR_VOL     '����������
                    End If
                    objTRST_STOCK.ARYME(ii).FUPDATE_DT = Now            '�X�V����
                    objTRST_STOCK.ARYME(ii).UPDATE_TRST_STOCK_ALL()     '�X�V

                Next


                '************************************************
                '�ׯ�ݸ��ޯ̧(���u)         �擾
                '************************************************
                Dim objTPRG_TRK_BUF_HIRA As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_HIRA.FTRK_BUF_NO = intFTR_IDOU                  '�ׯ�ݸ��ޯ̧��
                intRet = objTPRG_TRK_BUF_HIRA.GET_TPRG_TRK_BUF_AKI_HIRA()       '�擾
                If intRet <> RetCode.OK Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_HIRA.FTRK_BUF_NO) & "]"
                    Throw New UserException(strMsg)
                End If


                '************************
                '�݌Ɉړ�
                '************************
                Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog)         '�݌Ɉړ��׽
                objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_TO               '�ׯ�ݸ��ޯ̧
                objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_HIRA             '�ׯ�ݸ��ޯ̧
                objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_TO.FPALLET_ID            '��گ�ID
                objSVR_100103.FINOUT_STS = mFINOUT_STS                              'INOUT
                objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND           '��Ǝ��
                objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                            '�������ر�׸�
                objSVR_100103.STOCK_TRNS()                                          '�ړ�


                '************************************************************************
                '�ׯ�ݸ�,�݌ɏ��,���̑���گĂɊ֌W������S�č폜
                '************************************************************************
                Call ClearDustProcess(objTPRG_TRK_BUF_HIRA.FPALLET_ID)


            End If


        End If


        Return intReturn
    End Function
#End Region
#Region "  ���ꏈ��02(��ޏo�Ɏ��A�ً}���ɐݒ莞�̎��ѐ��ʍX�V)                                                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��02(��ޏo�Ɏ��A�ً}���ɐݒ莞�̎��ѐ��ʍX�V)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">�������ׯ�ݸ�</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FM�ׯ�ݸ�</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TO�ׯ�ݸ�</param>
    ''' <param name="objTSTS_HIKIATE">�݌Ɉ������</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special02(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             , ByVal objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '***********************************************
        '�݌ɏ��                   �擾
        '***********************************************
        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
        objTRST_STOCK.FPALLET_ID = objTSTS_HIKIATE.FPALLET_ID   '��گ�ID
        objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)               '�擾


        ''***********************************************
        ''��ޏo�ɐݒ���           �擾
        ''***********************************************
        'Dim objXSTS_WRAPPING_MATERIAL As New TBL_XSTS_WRAPPING_MATERIAL(Owner, ObjDb, ObjDbLog)
        'objXSTS_WRAPPING_MATERIAL.FTRK_BUF_NO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO      '�ׯ�ݸ��ޯ̧��
        'intRet = objXSTS_WRAPPING_MATERIAL.GET_XSTS_WRAPPING_MATERIAL(False)        '�擾
        'If intRet = RetCode.OK Then
        '    '(���������ꍇ)


        '    '***********************************************
        '    '��ޏo�ɐݒ���           �X�V
        '    '***********************************************
        '    objXSTS_WRAPPING_MATERIAL.XRESULT_NUM = TO_INTEGER(objXSTS_WRAPPING_MATERIAL.XRESULT_NUM) + 1       '���ѐ���
        '    objXSTS_WRAPPING_MATERIAL.UPDATE_XSTS_WRAPPING_MATERIAL()       '�X�V


        'End If


        '***********************************************
        '��ޏo�ɐݒ���               �擾
        '***********************************************
        Dim objXSTS_WRAPPING_MATERIAL As New TBL_XSTS_WRAPPING_MATERIAL(Owner, ObjDb, ObjDbLog)
        objXSTS_WRAPPING_MATERIAL.FTRK_BUF_NO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO      '�ׯ�ݸ��ޯ̧��
        objXSTS_WRAPPING_MATERIAL.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD    '�i�ں���
        intRet = objXSTS_WRAPPING_MATERIAL.GET_XSTS_WRAPPING_MATERIAL(False)        '�擾
        If intRet = RetCode.OK Then
            '(���������ꍇ)
            If 0 <= objXSTS_WRAPPING_MATERIAL.XPLAN_NUM Then
                '(��PL�o�ɈȊO�̏ꍇ)


                '***********************************************
                '��ޏo�ɐݒ���               �X�V
                '***********************************************
                objXSTS_WRAPPING_MATERIAL.XRESULT_NUM = TO_INTEGER(objXSTS_WRAPPING_MATERIAL.XRESULT_NUM) + 1       '���ѐ���
                objXSTS_WRAPPING_MATERIAL.UPDATE_XSTS_WRAPPING_MATERIAL()                                           '�X�V

                '������������************************************************************************************************************
                'JobMate:S.Ouchi 2013/10/29 ��ޏo�ɓo�^ �v�斞������ү���ޏo��
                If objXSTS_WRAPPING_MATERIAL.XRESULT_NUM >= objXSTS_WRAPPING_MATERIAL.XPLAN_NUM Then
                    '************************************************
                    '�ׯ�ݸ��ޯ̧Ͻ�            �擾
                    '************************************************
                    Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                    objTMST_TRK.FTRK_BUF_NO = objXSTS_WRAPPING_MATERIAL.FTRK_BUF_NO '�ׯ�ݸ��ޯ̧��
                    objTMST_TRK.GET_TMST_TRK()                                      '�擾

                    Dim strMsg01 As String
                    strMsg01 = "�ð���:[" & objTMST_TRK.FBUF_NAME & "]"
                    Call AddToMsgLog(Now, FMSG_ID_J4003, strMsg01)
                End If
                'JobMate:S.Ouchi 2013/10/29 ��ޏo�ɓo�^ �v�斞������ү���ޏo��
                '������������************************************************************************************************************
            End If
        End If


        '��������������������������������������������������������������������������������������������������������������������������
        '�fD45�̔����������ꏈ���͕s�v�H
        '***********************************************
        '��ޏo�ɐݒ���(D45)          �擾
        '***********************************************
        ''Dim objXSTS_WRAPPING_MATERIAL_D45 As New TBL_XSTS_WRAPPING_MATERIAL_D45(Owner, ObjDb, ObjDbLog)
        ''objXSTS_WRAPPING_MATERIAL_D45.FPLAN_KEY = objTSTS_HIKIATE.FPLAN_KEY             '�v�淰
        ''intRet = objXSTS_WRAPPING_MATERIAL_D45.GET_XSTS_WRAPPING_MATERIAL_D45(False)    '�擾
        ''If intRet = RetCode.OK Then
        ''    '(���������ꍇ)


        ''    '***********************************************
        ''    '��ޏo�ɐݒ���(D45)          �X�V
        ''    '***********************************************
        ''    objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM = TO_INTEGER(objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM) + 1               '���ѐ���
        ''    objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM_SUM = TO_INTEGER(objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM_SUM) + 1       '���ѐ���(���v)
        ''    If objXSTS_WRAPPING_MATERIAL_D45.XPLAN_NUM <= objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM Then
        ''        '(�v�搔�� <= ���ѐ��� �̏ꍇ)

        ''        '======================================
        ''        '���ѐ���           ؾ��
        ''        '======================================
        ''        objXSTS_WRAPPING_MATERIAL_D45.XPLAN_NUM = 0             '�v�搔��
        ''        objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM = 0           '���ѐ���

        ''        '======================================
        ''        'D45���Yײ�XX�v������       ؾ��
        ''        '======================================
        ''        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
        ''        Call objSVR_190001.SendYasukawaMelsec_IDMainteWord(objXSTS_WRAPPING_MATERIAL_D45.FEQ_ID, FTEXT_ID_JW_ETC, 0)

        ''        '������������************************************************************************************************************
        ''        'JobMate:S.Ouchi 2013/12/02 ��ޏo�ɓo�^ �v�斞������ү���ޏo�� �폜
        ''        ' '' ''������������************************************************************************************************************
        ''        ' '' ''JobMate:S.Ouchi 2013/10/29 ��ޏo�ɓo�^ �v�斞������ү���ޏo��
        ''        ' '' ''************************************************
        ''        ' '' ''�ׯ�ݸ��ޯ̧Ͻ�            �擾
        ''        ' '' ''************************************************
        ''        '' ''Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        ''        '' ''objTMST_TRK.FTRK_BUF_NO = objXSTS_WRAPPING_MATERIAL_D45.FTRK_BUF_NO '�ׯ�ݸ��ޯ̧��
        ''        '' ''objTMST_TRK.GET_TMST_TRK()                                          '�擾

        ''        ' '' ''**************************************
        ''        ' '' ''��ޗ�Ұ�Ͻ��̍X�V
        ''        ' '' ''**************************************
        ''        '' ''Dim obj_XMST_PROD_LINE_D45 As New TBL_XMST_PROD_LINE_D45(Owner, ObjDb, ObjDbLog)
        ''        '' ''obj_XMST_PROD_LINE_D45.XPROD_LINE = objXSTS_WRAPPING_MATERIAL_D45.XPROD_LINE        '���Yײ݇�
        ''        '' ''obj_XMST_PROD_LINE_D45.GET_XMST_PROD_LINE_D45(False)

        ''        '' ''Dim strMsg01 As String
        ''        '' ''strMsg01 = "�ð���:[" & objTMST_TRK.FBUF_NAME & "]"
        ''        '' ''strMsg01 &= " ���Yײ�:[" & obj_XMST_PROD_LINE_D45.XPROD_LINE_NAME & "]"
        ''        '' ''Call AddToMsgLog(Now, FMSG_ID_J4003, strMsg01)
        ''        ' '' ''JobMate:S.Ouchi 2013/10/29 ��ޏo�ɓo�^ �v�斞������ү���ޏo��
        ''        ' '' ''������������************************************************************************************************************
        ''        'JobMate:S.Ouchi 2013/12/02 ��ޏo�ɓo�^ �v�斞������ү���ޏo�� �폜
        ''        '������������************************************************************************************************************
        ''    End If
        ''    objXSTS_WRAPPING_MATERIAL_D45.UPDATE_XSTS_WRAPPING_MATERIAL_D45()       '�X�V


        ''End If
        '��������������������������������������������������������������������������������������������������������������������������������������������

        '***********************************************
        '���Y���ɐݒ���           �擾
        '***********************************************
        Dim objXSTS_PRODUCT_IN As New TBL_XSTS_PRODUCT_IN(Owner, ObjDb, ObjDbLog)
        objXSTS_PRODUCT_IN.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO         '�ׯ�ݸ��ޯ̧��
        objXSTS_PRODUCT_IN.XKINKYU_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO      '�ً}���������ׯ�ݸ��ޯ̧��
        intRet = objXSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN(False)                  '�擾
        If intRet = RetCode.OK Then
            '(���������ꍇ)


            '***********************************************
            '���Y���ɐݒ���           �X�V
            '***********************************************
            objXSTS_PRODUCT_IN.XRESULT_NUM = TO_INTEGER(objXSTS_PRODUCT_IN.XRESULT_NUM) + 1        '���ѐ���
            '������������************************************************************************************************************
            'JobMate:S.Ouchi 2013/10/23 ���Y���Ɏ��э����ǉ�
            objXSTS_PRODUCT_IN.XRESULT_NUM_CASE = TO_INTEGER(objXSTS_PRODUCT_IN.XRESULT_NUM_CASE) + objTRST_STOCK.ARYME(0).FTR_VOL  '���ѐ���(����)
            'JobMate:S.Ouchi 2013/10/23 ���Y���Ɏ��э����ǉ�
            '������������************************************************************************************************************
            objXSTS_PRODUCT_IN.UPDATE_XSTS_PRODUCT_IN()         '�X�V


        End If


        '������������************************************************************************************************************
        'JobMate:YAMAMOTO 2017/04/11 1F��ޏo�ɑΉ� ������������
        '***********************************************
        '��ޏo�ɐݒ���(1F)          �擾
        '***********************************************
        Dim objXSTS_WRAPPING_MATERIAL_1F As New TBL_XSTS_WRAPPING_MATERIAL_1F(Owner, ObjDb, ObjDbLog)
        objXSTS_WRAPPING_MATERIAL_1F.FPLAN_KEY = objTSTS_HIKIATE.FPLAN_KEY             '�v�淰
        intRet = objXSTS_WRAPPING_MATERIAL_1F.GET_XSTS_WRAPPING_MATERIAL_1F(False)    '�擾
        If intRet = RetCode.OK Then
            '(���������ꍇ)


            '***********************************************
            '��ޏo�ɐݒ���(1F)          �X�V
            '***********************************************
            objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM = TO_INTEGER(objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM) + 1               '���ѐ���
            objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM_SUM = TO_INTEGER(objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM_SUM) + 1       '���ѐ���(���v)
            If objXSTS_WRAPPING_MATERIAL_1F.XPLAN_NUM <= objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM Then
                '(�v�搔�� <= ���ѐ��� �̏ꍇ)

                '======================================
                '���ѐ���           ؾ��
                '======================================
                objXSTS_WRAPPING_MATERIAL_1F.XPLAN_NUM = 0             '�v�搔��
                objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM = 0           '���ѐ���
                objXSTS_WRAPPING_MATERIAL_1F.FTR_RES_VOL = 0           '��������

                '======================================
                'D45���Yײ�XX�v������       ؾ��
                '======================================
                'Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                'Call objSVR_190001.SendYasukawaMelsec_IDMainteWord(objXSTS_WRAPPING_MATERIAL_1F.FEQ_ID, FTEXT_ID_JW_ETC, 0)

            End If
            objXSTS_WRAPPING_MATERIAL_1F.UPDATE_XSTS_WRAPPING_MATERIAL_1F()       '�X�V


        End If
        'JobMate:YAMAMOTO 2017/04/111F��ޏo�ɑΉ� ������������
        '������������************************************************************************************************************


        Return intReturn
    End Function
#End Region

#Region "  ���ꏈ��21(�o�׎w���A�o�׎w���ڍ׍X�V�B�o�Ɏ��яڍגǉ��B)                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��21(�o�׎w���A�o�׎w���ڍ�ð��ٍX�V)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">�������ׯ�ݸ�</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FM�ׯ�ݸ�</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TO�ׯ�ݸ�</param>
    ''' <param name="objTSTS_HIKIATE">�݌Ɉ������</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special21(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             , ByVal objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE _
                             ) _
                             As RetCode
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '************************
        '����
        '************************
        'NOP


        '************************************************
        '�݌ɏ��                   �擾
        '************************************************
        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
        objTRST_STOCK.FPALLET_ID = objTSTS_HIKIATE.FPALLET_ID           '��گ�ID
        objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)                       '�擾


        '************************************************
        '�݌ɏ��                   �擾
        '************************************************
        Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
        objTMST_ITEM.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD     '�i������
        objTMST_ITEM.GET_TMST_ITEM()                                    '�擾


        '*****************************************************
        '�o�׎w���A�o�׎w���ڍׁA�o�Ɏ��яڍ�  �̒ǉ��X�V
        '*****************************************************
        Call SyukkaHikiateHiraokiUpdate(objTRST_STOCK _
                                      , objTMST_ITEM _
                                      , objTSTS_HIKIATE.FPLAN_KEY _
                                      , objTSTS_HIKIATE.FTR_VOL _
                                      , TO_INTEGER(objTRST_STOCK.ARYME(0).XTRK_BUF_NO_IN) _
                                      , TO_INTEGER(objTRST_STOCK.ARYME(0).XTRK_BUF_ARRAY_IN) _
                                      , objTPRG_TRK_BUF_TO.FTRK_BUF_NO _
                                      , objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY _
                                      , False _
                                      )


        Return intReturn
    End Function
#End Region
    '���������ьŗL
    '**********************************************************************************************


End Class
