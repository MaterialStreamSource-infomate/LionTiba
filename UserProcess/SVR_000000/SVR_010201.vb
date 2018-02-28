'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�o�Ɏw������
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_010201
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �׽�ϐ���`                                                                          "
    Private mobjTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE            '�����w��QUE
#End Region
#Region "  �����è��`                                                                          "
    ''' =======================================
    ''' <summary>�����w��QUE</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property TPLN_CARRY_QUE() As TBL_TPLN_CARRY_QUE
        Get
            Return mobjTPLN_CARRY_QUE
        End Get
        Set(ByVal Value As TBL_TPLN_CARRY_QUE)
            mobjTPLN_CARRY_QUE = Value
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
#Region "  �\���̒�`                                                                           "

#End Region
#Region "  �o�Ɏw��                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �o�Ɏw��
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecCmdFunction() As RetCode
        Dim intRet As RetCode                   '�߂�l
        Dim strMsg As String                    'ү����
        Try
            ''************************
            ''��������
            ''************************
            'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            '************************
            '�����w��QUE
            '************************
            If IsNull(mobjTPLN_CARRY_QUE) = True Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPLN_CARRY_QUE
                Throw New UserException(strMsg)
            End If


            '************************
            '�q���ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)        '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_ASRS.FPALLET_ID = mobjTPLN_CARRY_QUE.FPALLET_ID                 '��گ�ID
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                            '����


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/03 ���ꏈ��


            '****************************************************************************
            '���ꏈ��12(�߱�����ŁA���ɏo�ɏ������s���Ă��邩�ۂ��̔��f)
            '****************************************************************************
            intRet = Special12(Nothing _
                             , objTPRG_TRK_BUF_ASRS _
                             , Nothing _
                             , Nothing _
                             , Nothing _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '������������************************************************************************************************************


            '************************
            '�݌Ɉ������̓���
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '�݌Ɉ������׽
            objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FPALLET_ID        '��گ�ID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                    '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[��گ�ID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�ڰ�Ͻ��̓���
            '************************
            Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)             '�ڰ�Ͻ��׽
            objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO                '�ޯ̧��
            objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU                 '��
            intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                                   '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ޯ̧��:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,��:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                Throw New UserException(strMsg)
            End If


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2012/08/24 ���ꏈ��


            '****************************************************************************
            '���ꏈ��11(�ڰݖ��Ɉꌏ�����o�Ɏw���𑗐M���Ȃ��悤�ɐ���)
            '****************************************************************************
            intRet = Special11(Nothing _
                             , objTPRG_TRK_BUF_ASRS _
                             , Nothing _
                             , objTSTS_HIKIATE _
                             , objTMST_CRANE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '������������************************************************************************************************************


            '************************
            '�ڰݖ��̎w����������
            '************************
            If TO_INTEGER(objTMST_CRANE.FINOUT_MAX) > 0 Then
                If TO_INTEGER(objTMST_CRANE.FINOUT_MAX) <= mobjTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_SEND_COUNT_BY_EQ_ID() Then
                    '========================
                    '�w�����M�҂����R�̓o�^
                    '========================
                    objTSTS_HIKIATE.FWAIT_REASON = "���o�ɋK�������ް  [�ޯ̧��" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "][�ݔ�ID" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                End If
            End If
            If TO_INTEGER(objTMST_CRANE.FINOUT_MAX) > 0 Then
                If TO_INTEGER(objTMST_CRANE.FOUT_MAX) <= mobjTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_SEND_COUNT_OUT() Then
                    '========================
                    '�w�����M�҂����R�̓o�^
                    '========================
                    objTSTS_HIKIATE.FWAIT_REASON = "�o�ɋK�������ް  [�ޯ̧��" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "][�ݔ�ID" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                End If
            End If


            '************************
            '�ڰݐݔ�ID�̓���
            '************************
            Dim strEQ_ID_CRANE_FM As String
            strEQ_ID_CRANE_FM = objTMST_CRANE.FEQ_ID


            '************************
            '����ٰ�Ͻ��̓���
            '************************
            Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)             '����ٰ�Ͻ�
            objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_ASRS.FTR_FM                         '���ޯ̧��
            objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_ASRS.FTR_TO                         '���ޯ̧��
            objTMST_ROUTE.FEQ_ID_CRANE_FM = strEQ_ID_CRANE_FM                           '���ڰݐݔ�ID
            objTMST_ROUTE.FEQ_ID_CRANE_TO = FEQ_ID_SKOTEI                               '��ڰݐݔ�ID
            objTMST_ROUTE.GET_TMST_ROUTE()                                              '����


            '************************
            '��ٰĂ��ׯ�ݸ��ޯ̧����
            '************************
            Dim objSVR_100207 As New SVR_100207(Owner, ObjDb, ObjDbLog)                     '��ٰĂ��ׯ�ݸ��ޯ̧�����׽
            objSVR_100207.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FPALLET_ID                      '��گ�ID
            objSVR_100207.FBUF_FM = objTMST_ROUTE.FBUF_FM                                   '���ޯ̧��
            objSVR_100207.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM                   '���ڰݐݔ�ID
            objSVR_100207.FBUF_TO = objTMST_ROUTE.FBUF_TO                                   '���ޯ̧��
            objSVR_100207.FEQ_ID_CRANE_TO = objTMST_ROUTE.FEQ_ID_CRANE_TO                   '��ڰݐݔ�ID
            intRet = objSVR_100207.GET_NEXT_TPRG_TRK_BUF                                    '��ٰĂ��ׯ�ݸ��ޯ̧����
            If intRet <> RetCode.OK Then
                '========================
                '�w�����M�҂����R�̓o�^
                '========================
                objTSTS_HIKIATE.FWAIT_REASON = objSVR_100207.FWAIT_REASON
                objTSTS_HIKIATE.FUPDATE_DT = Now
                objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                Return RetCode.NotEnough
            End If


            '************************
            '���p�ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)   '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RELAY = objSVR_100207.TPRG_TRK_BUF_RELAY


            '*****************************
            '�������ޯ̧�̓���
            '*****************************
            Dim objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF                                  '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_TO = objSVR_100207.TPRG_TRK_BUF_NEXT


            '************************
            'ٰĐݔ�����(From - To)
            '************************
            Dim objSVR_100203 As New SVR_100203(Owner, ObjDb, ObjDbLog)
            objSVR_100203.FBUF_FM = objTMST_ROUTE.FBUF_FM                               '���ׯ�ݸ��ޯ̧��
            objSVR_100203.FBUF_TO = objTMST_ROUTE.FBUF_TO                               '���ׯ�ݸ��ޯ̧��
            objSVR_100203.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM               '���ڰݐݔ�ID
            objSVR_100203.FEQ_ID_CRANE_TO = objTMST_ROUTE.FEQ_ID_CRANE_TO               '��ڰݐݔ�ID
            intRet = objSVR_100203.CHECK_ROUTE(objTSTS_HIKIATE)
            If intRet = RetCode.NG Then
                '(�װ�̏ꍇ)
                Return RetCode.NotEnough
            End If

            '************************
            'ٰĐݔ�����(From - Next)
            '************************
            If objTMST_ROUTE.FBUF_TO <> objTMST_ROUTE.FBUF_NEXT Then
                objSVR_100203 = New SVR_100203(Owner, ObjDb, ObjDbLog)
                objSVR_100203.FBUF_FM = objTMST_ROUTE.FBUF_FM                   '���ׯ�ݸ��ޯ̧��
                objSVR_100203.FBUF_TO = objTMST_ROUTE.FBUF_NEXT                 '���ׯ�ݸ��ޯ̧��
                objSVR_100203.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM   '���ڰݐݔ�ID
                objSVR_100203.FEQ_ID_CRANE_TO = FEQ_ID_SKOTEI                   '��ڰݐݔ�ID
                intRet = objSVR_100203.CHECK_ROUTE(objTSTS_HIKIATE)
                If intRet = RetCode.NG Then
                    '(�װ�̏ꍇ)
                    Return RetCode.NotEnough
                End If
            End If

            '===============================
            'TO�����L������
            '===============================
            Dim objSVR_100206 As New SVR_100206(Owner, ObjDb, ObjDbLog)                 '�SٰĂ̈����y�ї\��׽
            If TO_INTEGER(objTMST_ROUTE.FRSV_BUF_TO_FLAG) = FRSV_BUF_TO_FLAG_SRSV Then
                '===============================
                'TO�����L�����u�L�v�̏ꍇ�A�SٰĂ̈������\����s��
                '===============================
                objSVR_100206.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FPALLET_ID              '��گ�ID
                objSVR_100206.FBUF_FM = objTMST_ROUTE.FBUF_FM                           '���ޯ̧��
                objSVR_100206.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM           '���ڰݐݔ�ID
                objSVR_100206.FBUF_TO = objTMST_ROUTE.FBUF_TO                           '���ޯ̧��
                objSVR_100206.FEQ_ID_CRANE_TO = objTMST_ROUTE.FEQ_ID_CRANE_TO           '��ڰݐݔ�ID
                objSVR_100206.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT                        '�������
                intRet = objSVR_100206.FIND_TMST_ROUTE_TO_END                           '�SٰĂ̌���
                If intRet <> RetCode.OK Then
                    '(������Ȃ��ꍇ)
                    '========================
                    '�w�����M�҂����R�̓o�^
                    '========================
                    objTSTS_HIKIATE.FWAIT_REASON = objSVR_100206.FWAIT_REASON
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                End If
            End If


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/25 ���ꏈ��


            '**************************************
            '���ꏈ��06(�o�I�ޯ̧������)
            '**************************************
            intRet = Special06(objTPRG_TRK_BUF_RELAY _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTPRG_TRK_BUF_TO _
                             , objTSTS_HIKIATE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '**************************************
            '���ꏈ��03(�o�Ɏw���̌����͈ꌏ�̂�)
            '**************************************
            intRet = Special03(objTPRG_TRK_BUF_RELAY _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTPRG_TRK_BUF_TO _
                             , objTSTS_HIKIATE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '**************************************
            '���ꏈ��04(���Ɏw������)
            '**************************************
            intRet = Special04(objTPRG_TRK_BUF_RELAY _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTPRG_TRK_BUF_TO _
                             , objTSTS_HIKIATE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '**************************************
            '���ꏈ��05(��O�I����)
            '**************************************
            intRet = Special05(objTPRG_TRK_BUF_RELAY _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTPRG_TRK_BUF_TO _
                             , objTSTS_HIKIATE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '������������************************************************************************************************************


            '************************
            '�݌Ɉړ�
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '�݌Ɉړ��׽
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_ASRS     '�ׯ�ݸ��ޯ̧
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_RELAY    '�ׯ�ݸ��ޯ̧
            objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FPALLET_ID  '��گ�ID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SOUT_START             'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '��Ǝ��
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_OFF                   '�������ر�׸�
            objSVR_100103.STOCK_TRNS()                                  '�ړ�


            '******************************************************
            '�q��/�o�ɒ�/�o�ɐ��ޯ̧�̍X�V
            '******************************************************
            '===============================
            '�q���ޯ̧�̍X�V
            '===============================
            objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT                         '�������
            objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO               'TO�����ׯ�ݸއ�
            objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY          'TO�����z��
            objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_ASRS.GET_ADDRESS_TO     'TO�\�L�p���ڽ
            objTPRG_TRK_BUF_ASRS.FBUF_IN_DT = Now                                           '�ޯ̧������
            objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                                      '�X�V


            '===============================
            '�o�ɒ��ޯ̧�̍X�V
            '===============================
            objTPRG_TRK_BUF_RELAY.FRSV_PALLET = objTPRG_TRK_BUF_ASRS.FRSV_PALLET                '��������گ�ID
            objTPRG_TRK_BUF_RELAY.FRES_KIND = FRES_KIND_SZAIKO                                   '�������
            objTPRG_TRK_BUF_RELAY.FTR_FM = objTPRG_TRK_BUF_ASRS.FTR_FM                          '����FM�ޯ̧��
            objTPRG_TRK_BUF_RELAY.FTR_TO = objTPRG_TRK_BUF_ASRS.FTR_TO                          '����TO�ޯ̧��
            objTPRG_TRK_BUF_RELAY.FTR_IDOU = objTPRG_TRK_BUF_ASRS.FTR_IDOU                      '����TO�ړ��ޯ̧��
            objTPRG_TRK_BUF_RELAY.FTRNS_FM = objTPRG_TRK_BUF_ASRS.FTRNS_ADDRESS                 '�����w�ߗpFM
            objTPRG_TRK_BUF_RELAY.FTRNS_TO = objTPRG_TRK_BUF_TO.FTRNS_ADDRESS                   '�����w�ߗpTO
            objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM = objTPRG_TRK_BUF_ASRS.FRSV_BUF_FM                'FM�����ׯ�ݸއ�
            objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM = objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_FM            'FM�����z��
            objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO = objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO                'TO�����ׯ�ݸއ�
            objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO            'TO�����z��
            objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_FM      'FM�\�L�p���ڽ
            objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_RELAY.GET_ADDRESS_TO       'TO�\�L�p���ڽ
            objTPRG_TRK_BUF_RELAY.FBUF_IN_DT = Now                                              '�ޯ̧������
            objTPRG_TRK_BUF_RELAY.UPDATE_TPRG_TRK_BUF()                                         '�X�V

            '===============================
            'TO�����L������
            '===============================
            If TO_INTEGER(objTMST_ROUTE.FRSV_BUF_TO_FLAG) = FRSV_BUF_TO_FLAG_SRSV Then
                '===============================
                '�o�ɐ��ޯ̧�̍X�V
                '===============================
                objTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT                               '�������
                objTPRG_TRK_BUF_TO.FBUF_IN_DT = Now                                                 '�ޯ̧������
                objTPRG_TRK_BUF_TO.FRSV_PALLET = objTPRG_TRK_BUF_ASRS.FRSV_PALLET                   '��������گ�ID
                objTPRG_TRK_BUF_TO.FTR_FM = objTPRG_TRK_BUF_ASRS.FTR_FM                             '����FM�ޯ̧��
                objTPRG_TRK_BUF_TO.FTR_TO = objTPRG_TRK_BUF_ASRS.FTR_TO                             '����TO�ޯ̧��
                objTPRG_TRK_BUF_TO.FRSV_BUF_FM = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO                   'FM�����ׯ�ݸއ�
                objTPRG_TRK_BUF_TO.FRSV_ARRAY_FM = objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY              'FM�����z��
                objTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()                                            '�X�V


                '===============================
                'TO�����L�����u�L�v�̏ꍇ�A�SٰĂ̈������\����s��
                '===============================
                Call objSVR_100206.RSV_TMST_ROUTE_TO_END()                                      '�������\��
            End If


            '************************
            '�����w��QUE�̍X�V
            '************************
            mobjTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND    '�����w����
            mobjTPLN_CARRY_QUE.FUPDATE_DT = Now                             '�X�V����
            mobjTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                      '�X�V


            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/04/25  ��������o�^(�o�Ɏ��ѓ��ŕK�v)

            '************************************************
            '��گď��      �X�V
            '************************************************
            Dim objTRST_PALLET As New TBL_TRST_PALLET(Owner, ObjDb, ObjDbLog)
            objTRST_PALLET.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID     '��گ�ID
            objTRST_PALLET.GET_TRST_PALLET()
            objTRST_PALLET.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO           '�ׯ�ݸ��ޯ̧��
            objTRST_PALLET.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY     '�ׯ�ݸ��ޯ̧�z��
            objTRST_PALLET.UPDATE_TRST_PALLET()

            '������������************************************************************************************************************


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2012/04/24 �o�Ɏw���𑗐M


            '************************************************
            '�o�Ɏw��
            '************************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SOUT                    '�����ID
            objSVR_190001.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID     '��گ�ID
            objSVR_190001.FTRNS_SERIAL = ""                                 '�����ره�
            objSVR_190001.SendYasukawa_IDOut(objTPRG_TRK_BUF_RELAY _
                                           , objTPRG_TRK_BUF_ASRS _
                                           , objTPRG_TRK_BUF_TO _
                                           , objTSTS_HIKIATE _
                                           , mobjTPLN_CARRY_QUE _
                                           , objTMST_ROUTE _
                                           )


            '������������************************************************************************************************************


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/06/24 ���ꏈ��


            '************************************************
            '���ꏈ��21(�o�׎w���A�o�׎w���ڍ�ð��ٍX�V)
            '************************************************
            intRet = Special21(objTPRG_TRK_BUF_RELAY _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTPRG_TRK_BUF_TO _
                             , objTSTS_HIKIATE _
                             )


            '������������************************************************************************************************************


            '========================
            '�w�����M�҂����R�̸ر
            '========================
            objTSTS_HIKIATE.FWAIT_REASON = DEFAULT_STRING
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()


            '************************
            '���튮��
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & _
                                "  [��گ�ID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & _
                                "  ,������:" & objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS & _
                                "  ,������:" & objTPRG_TRK_BUF_TO.FDISP_ADDRESS & _
                                "]")


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/03 ���ꏈ��


            '****************************************************************************
            '���ꏈ��13(�߱�����ŁA�����̏o�Ɏw�����s��)
            '****************************************************************************
            intRet = Special13(objTPRG_TRK_BUF_RELAY _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTPRG_TRK_BUF_TO _
                             , objTSTS_HIKIATE _
                             , objTMST_CRANE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '������������************************************************************************************************************


            Return RetCode.OK
        Catch ex As ContinueForException
            Throw New ContinueForException()
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region

#Region "  �o�Ɏw��(�I�Ԕ���)                                                                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �o�Ɏw��(�I�Ԕ���)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecCmdFunction_Tana() As RetCode
        Dim intRet As RetCode                   '�߂�l
        Dim strMsg As String                    'ү����
        Try
            '************************
            '��������
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            '************************
            '�����w��QUE
            '************************
            If IsNull(mobjTPLN_CARRY_QUE) = True Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPLN_CARRY_QUE
                Throw New UserException(strMsg)
            End If


            '************************
            '�q���ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)        '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_ASRS.FPALLET_ID = mobjTPLN_CARRY_QUE.FPALLET_ID                 '��گ�ID
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                            '����


            '************************
            '�݌Ɉ������̓���
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '�݌Ɉ������׽
            objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FPALLET_ID        '��گ�ID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                    '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[��گ�ID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�ڰ�Ͻ��̓���
            '************************
            Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)             '�ڰ�Ͻ��׽
            objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO                '�ޯ̧��
            objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU                 '��
            intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                                   '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ޯ̧��:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,��:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�ڰݖ��̎w����������
            '************************
            If TO_INTEGER(objTMST_CRANE.FINOUT_MAX) > 0 Then
                If TO_INTEGER(objTMST_CRANE.FINOUT_MAX) <= mobjTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_SEND_COUNT_BY_EQ_ID() Then
                    '========================
                    '�w�����M�҂����R�̓o�^
                    '========================
                    objTSTS_HIKIATE.FWAIT_REASON = "���o�ɋK�������ް  [�ޯ̧��" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "][�ݔ�ID" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                End If
            End If
            If TO_INTEGER(objTMST_CRANE.FINOUT_MAX) > 0 Then
                If TO_INTEGER(objTMST_CRANE.FOUT_MAX) <= mobjTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_SEND_COUNT_OUT() Then
                    '========================
                    '�w�����M�҂����R�̓o�^
                    '========================
                    objTSTS_HIKIATE.FWAIT_REASON = "�o�ɋK�������ް  [�ޯ̧��" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "][�ݔ�ID" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                End If
            End If


            '************************
            '�ڰݐݔ�ID�̓���
            '************************
            Dim strEQ_ID_CRANE_FM As String
            strEQ_ID_CRANE_FM = objTMST_CRANE.FEQ_ID


            '************************
            '�ڰݐݔ�ID�̓���(������)
            '************************
            Dim objTPRG_TRK_BUF_Temp As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF_Temp.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO          '�ׯ�ݸ��ޯ̧��
            objTPRG_TRK_BUF_Temp.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO     '�ׯ�ݸ��ޯ̧�z��
            intRet = objTPRG_TRK_BUF_Temp.GET_TPRG_TRK_BUF(True)
            Dim objTMST_CRANE_TO As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)             '�ڰ�Ͻ��׽
            objTMST_CRANE_TO.FTRK_BUF_NO = objTPRG_TRK_BUF_Temp.FTRK_BUF_NO                '�ޯ̧��
            objTMST_CRANE_TO.INTCHECK_ROW = objTPRG_TRK_BUF_Temp.FRAC_RETU                 '��
            intRet = objTMST_CRANE_TO.GET_TMST_CRANE_ROW                                   '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ޯ̧��:" & TO_STRING(objTMST_CRANE_TO.FTRK_BUF_NO) & "  ,��:" & TO_STRING(objTMST_CRANE_TO.INTCHECK_ROW) & "]"
                Throw New UserException(strMsg)
            End If
            Dim strEQ_ID_CRANE_TO As String
            strEQ_ID_CRANE_TO = objTMST_CRANE_TO.FEQ_ID


            '************************
            '����ٰ�Ͻ��̓���
            '************************
            Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)             '����ٰ�Ͻ�
            objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_ASRS.FTR_FM                         '���ޯ̧��
            objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_ASRS.FTR_TO                         '���ޯ̧��
            objTMST_ROUTE.FEQ_ID_CRANE_FM = strEQ_ID_CRANE_FM                           '���ڰݐݔ�ID
            objTMST_ROUTE.FEQ_ID_CRANE_TO = strEQ_ID_CRANE_TO                           '��ڰݐݔ�ID
            intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                                 '����


            '************************
            '��ٰĂ��ׯ�ݸ��ޯ̧����
            '************************
            Dim objSVR_100207 As New SVR_100207(Owner, ObjDb, ObjDbLog)                     '��ٰĂ��ׯ�ݸ��ޯ̧�����׽
            objSVR_100207.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FPALLET_ID                      '��گ�ID
            objSVR_100207.FBUF_FM = objTMST_ROUTE.FBUF_FM                                   '���ޯ̧��
            objSVR_100207.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM                   '���ڰݐݔ�ID
            objSVR_100207.FBUF_TO = objTMST_ROUTE.FBUF_TO                                   '���ޯ̧��
            objSVR_100207.FEQ_ID_CRANE_TO = objTMST_ROUTE.FEQ_ID_CRANE_TO                   '��ڰݐݔ�ID
            intRet = objSVR_100207.GET_NEXT_TPRG_TRK_BUF                                    '��ٰĂ��ׯ�ݸ��ޯ̧����
            If intRet <> RetCode.OK Then
                '========================
                '�w�����M�҂����R�̓o�^
                '========================
                objTSTS_HIKIATE.FWAIT_REASON = objSVR_100207.FWAIT_REASON
                objTSTS_HIKIATE.FUPDATE_DT = Now
                objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                Return RetCode.NotEnough
            End If


            '************************
            '���p�ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)   '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RELAY = objSVR_100207.TPRG_TRK_BUF_RELAY


            '*****************************
            '�������ޯ̧�̓���
            '*****************************
            Dim objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF                                  '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_TO = objSVR_100207.TPRG_TRK_BUF_NEXT


            '************************
            'ٰĐݔ�����(From - To)
            '************************
            Dim objSVR_100203 As New SVR_100203(Owner, ObjDb, ObjDbLog)
            objSVR_100203.FBUF_FM = objTMST_ROUTE.FBUF_FM                               '���ׯ�ݸ��ޯ̧��
            objSVR_100203.FBUF_TO = objTMST_ROUTE.FBUF_TO                               '���ׯ�ݸ��ޯ̧��
            objSVR_100203.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM               '���ڰݐݔ�ID
            objSVR_100203.FEQ_ID_CRANE_TO = objTMST_ROUTE.FEQ_ID_CRANE_TO               '��ڰݐݔ�ID
            intRet = objSVR_100203.CHECK_ROUTE(objTSTS_HIKIATE)
            If intRet = RetCode.NG Then
                '(�װ�̏ꍇ)
                Return RetCode.NotEnough
            End If

            '************************
            'ٰĐݔ�����(From - Next)
            '************************
            If objTMST_ROUTE.FBUF_TO <> objTMST_ROUTE.FBUF_NEXT Then
                objSVR_100203 = New SVR_100203(Owner, ObjDb, ObjDbLog)
                objSVR_100203.FBUF_FM = objTMST_ROUTE.FBUF_FM                   '���ׯ�ݸ��ޯ̧��
                objSVR_100203.FBUF_TO = objTMST_ROUTE.FBUF_NEXT                 '���ׯ�ݸ��ޯ̧��
                objSVR_100203.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM   '���ڰݐݔ�ID
                objSVR_100203.FEQ_ID_CRANE_TO = FEQ_ID_SKOTEI                   '��ڰݐݔ�ID
                intRet = objSVR_100203.CHECK_ROUTE(objTSTS_HIKIATE)
                If intRet = RetCode.NG Then
                    '(�װ�̏ꍇ)
                    Return RetCode.NotEnough
                End If
            End If


            '===============================
            'TO�����L������
            '===============================
            Dim objSVR_100206 As New SVR_100206(Owner, ObjDb, ObjDbLog)                 '�SٰĂ̈����y�ї\��׽
            If TO_INTEGER(objTMST_ROUTE.FRSV_BUF_TO_FLAG) = FRSV_BUF_TO_FLAG_SRSV Then
                '===============================
                'TO�����L�����u�L�v�̏ꍇ�A�SٰĂ̈������\����s��
                '===============================
                objSVR_100206.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FRSV_PALLET             '��گ�ID
                objSVR_100206.FBUF_FM = objTMST_ROUTE.FBUF_FM                           '���ޯ̧��
                objSVR_100206.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM           '���ڰݐݔ�ID
                objSVR_100206.FBUF_TO = objTMST_ROUTE.FBUF_TO                           '���ޯ̧��
                objSVR_100206.FEQ_ID_CRANE_TO = objTMST_ROUTE.FEQ_ID_CRANE_TO           '��ڰݐݔ�ID
                objSVR_100206.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT                        '�������
                intRet = objSVR_100206.FIND_TMST_ROUTE_TO_END                           '�SٰĂ̌���
                If intRet <> RetCode.OK Then
                    '(������Ȃ��ꍇ)
                    '========================
                    '�w�����M�҂����R�̓o�^
                    '========================
                    objTSTS_HIKIATE.FWAIT_REASON = objSVR_100206.FWAIT_REASON
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                End If
            End If


            '************************
            '�݌Ɉړ�
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '�݌Ɉړ��׽
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_ASRS     '�ׯ�ݸ��ޯ̧
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_RELAY    '�ׯ�ݸ��ޯ̧
            objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FPALLET_ID  '��گ�ID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SSOUKO_START          'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '��Ǝ��
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_OFF                   '�������ر�׸�
            objSVR_100103.STOCK_TRNS()                                  '�ړ�


            '******************************************************
            '�q��/�o�ɒ�/�o�ɐ��ޯ̧�̍X�V
            '******************************************************
            '===============================
            '�q���ޯ̧�̍X�V
            '===============================
            objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT                         '�������
            objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO               'TO�����ׯ�ݸއ�
            objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY          'TO�����z��
            objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_ASRS.GET_ADDRESS_TO     'TO�\�L�p���ڽ
            objTPRG_TRK_BUF_ASRS.FBUF_IN_DT = Now                                           '�ޯ̧������
            objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                                      '�X�V


            '===============================
            '�o�ɒ��ޯ̧�̍X�V
            '===============================
            objTPRG_TRK_BUF_RELAY.FRSV_PALLET = objTPRG_TRK_BUF_ASRS.FRSV_PALLET                '��������گ�ID
            objTPRG_TRK_BUF_RELAY.FRES_KIND = FRES_KIND_SZAIKO                                   '�������
            objTPRG_TRK_BUF_RELAY.FTR_FM = objTPRG_TRK_BUF_ASRS.FTR_FM                          '����FM�ޯ̧��
            objTPRG_TRK_BUF_RELAY.FTR_TO = objTPRG_TRK_BUF_ASRS.FTR_TO                          '����TO�ޯ̧��
            objTPRG_TRK_BUF_RELAY.FTR_IDOU = objTPRG_TRK_BUF_ASRS.FTR_IDOU                      '����TO�ړ��ޯ̧��
            objTPRG_TRK_BUF_RELAY.FTRNS_FM = objTPRG_TRK_BUF_ASRS.FTRNS_ADDRESS                 '�����w�ߗpFM
            objTPRG_TRK_BUF_RELAY.FTRNS_TO = objTPRG_TRK_BUF_TO.FTRNS_ADDRESS                   '�����w�ߗpTO
            objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM = objTPRG_TRK_BUF_ASRS.FRSV_BUF_FM                'FM�����ׯ�ݸއ�
            objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM = objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_FM            'FM�����z��
            objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO = objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO                'TO�����ׯ�ݸއ�
            objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO            'TO�����z��
            objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_FM      'FM�\�L�p���ڽ
            objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_RELAY.GET_ADDRESS_TO       'TO�\�L�p���ڽ
            objTPRG_TRK_BUF_RELAY.FBUF_IN_DT = Now                                              '�ޯ̧������
            objTPRG_TRK_BUF_RELAY.UPDATE_TPRG_TRK_BUF()                                         '�X�V

            '===============================
            '�o�ɐ��ޯ̧�̍X�V
            '===============================
            objTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                                '�������
            objTPRG_TRK_BUF_TO.FBUF_IN_DT = Now                                                 '�ޯ̧������
            objTPRG_TRK_BUF_TO.FRSV_PALLET = objTPRG_TRK_BUF_ASRS.FRSV_PALLET                   '��������گ�ID
            objTPRG_TRK_BUF_TO.FTR_FM = objTPRG_TRK_BUF_ASRS.FTR_FM                             '����FM�ޯ̧��
            objTPRG_TRK_BUF_TO.FTR_TO = objTPRG_TRK_BUF_ASRS.FTR_TO                             '����TO�ޯ̧��
            objTPRG_TRK_BUF_TO.FRSV_BUF_FM = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO                   'FM�����ׯ�ݸއ�
            objTPRG_TRK_BUF_TO.FRSV_ARRAY_FM = objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY              'FM�����z��
            objTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()                                            '�X�V


            '===============================
            'TO�����L������
            '===============================
            If TO_INTEGER(objTMST_ROUTE.FRSV_BUF_TO_FLAG) = FRSV_BUF_TO_FLAG_SRSV Then
                '===============================
                'TO�����L�����u�L�v�̏ꍇ�A�SٰĂ̈������\����s��
                '===============================
                Call objSVR_100206.RSV_TMST_ROUTE_TO_END()                                      '�������\��
            End If


            '************************
            '�����w��QUE�̍X�V
            '************************
            mobjTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND    '�����w����
            mobjTPLN_CARRY_QUE.FUPDATE_DT = Now                             '�X�V����
            mobjTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                      '�X�V


            '========================
            '�w�����M�҂����R�̸ر
            '========================
            objTSTS_HIKIATE.FWAIT_REASON = DEFAULT_STRING
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()


            '************************
            '���튮��
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & _
                                "  [��گ�ID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & _
                                "  ,������:" & objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS & _
                                "  ,������:" & objTPRG_TRK_BUF_TO.FDISP_ADDRESS & _
                                "]")


            Return RetCode.OK
        Catch ex As ContinueForException
            Throw New ContinueForException()
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

#Region "  ���ꏈ��01(Ӱ������  [�o�Ɏw���p])                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��01(Ӱ������  [�o�Ɏw���p])
    ''' </summary>
    ''' <param name="objTSTS_HIKIATE">�݌Ɉ������</param>
    ''' <param name="objTPRG_TRK_BUF_ST">�ׯ�ݸ��ޯ̧(ST)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special01(ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             , ByVal objTPRG_TRK_BUF_ST As TBL_TPRG_TRK_BUF _
                             ) _
                             As RetCode


        '************************************************
        '�ݔ���(Ӱ��)     �擾
        '************************************************
        Dim strXEQ_ID_MOD As String = GetXEQ_ID_MODFromFTRK_BUF_NO(objTPRG_TRK_BUF_ST.FTRK_BUF_NO)

        If strXEQ_ID_MOD <> "" Then
            '(���o��Ӱ�ސؑ։\�ׯ�ݸނ̂Ƃ�)
            Dim objTSTS_EQ_CTRL_MOD As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            objTSTS_EQ_CTRL_MOD.FEQ_ID = strXEQ_ID_MOD          '�ݔ�ID
            objTSTS_EQ_CTRL_MOD.GET_TSTS_EQ_CTRL()              '�擾

            Select Case objTSTS_HIKIATE.FSAGYOU_KIND
                Case FSAGYOU_KIND_SOUT, FSAGYOU_KIND_STOI_OUT
                    '(�v��o�ɁA�⍇���o�ɂ̏ꍇ)
                    If objTSTS_EQ_CTRL_MOD.FEQ_STS <> FEQ_STS_SINOUTMODE_OUT Then
                        '(�o��Ӱ�ވȊO�̏ꍇ)

                        objTSTS_HIKIATE.FWAIT_REASON = "�o��Ӱ�ޑ҂�  [�ݔ�ID:" & objTSTS_EQ_CTRL_MOD.FEQ_ID & "]"
                        objTSTS_HIKIATE.FUPDATE_DT = Now
                        objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                        Return RetCode.NotEnough
                    End If
            End Select

        End If

        Return RetCode.OK
    End Function
#End Region
#Region "  ���ꏈ��03(�o�Ɏw���̌����͈ꌏ�̂�)                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��03(�o�Ɏw���̌����͈ꌏ�̂�)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special03(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '***********************************************
        '�o�Ɏw�����ׯ�ݸ�          ����
        '***********************************************
        Dim objAryTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
        objAryTPLN_CARRY_QUE.FEQ_ID = mobjTPLN_CARRY_QUE.FEQ_ID            '�ݔ�ID
        objAryTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND    '�����w����
        objAryTPLN_CARRY_QUE.FCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SOUT        '�w���敪
        intRet = objAryTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_ANY()             '�擾
        If intRet <> RetCode.OK Then
            '(�o�Ɏw�����Ȃ��ꍇ)
            Return RetCode.OK
        End If
        If 2 <= objAryTPLN_CARRY_QUE.ARYME.Length Then
            '(2���ȏ�̏o�Ɏw��������ꍇ)

            objTSTS_HIKIATE.FWAIT_REASON = "�ڰ݂��o�ɒ�[" & TO_STRING(objAryTPLN_CARRY_QUE.ARYME.Length) & "��]�ׁ̈A�o�Ɋ����҂��B"
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

            Return RetCode.NotEnough
        End If


        '***********************************************
        '1���̏o���ׯ�ݸނ��������ǂ���������
        '�o���ׯ�ݸނ������������ꍇ��OK�Ƃ���
        '***********************************************
        If TO_STRING(objAryTPLN_CARRY_QUE.ARYME(0).XPALLET_ID_AITE) = mobjTPLN_CARRY_QUE.FPALLET_ID Then
            '(�����������������ꍇ)
            Return RetCode.OK
        Else
            '(��������������Ȃ��ꍇ)

            objTSTS_HIKIATE.FWAIT_REASON = "�ڰ݂��o�ɒ�(1��)�ׁ̈A�o�Ɋ����҂��B"
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

            Return RetCode.NotEnough
        End If


        Return intReturn
    End Function
#End Region
#Region "  ���ꏈ��04(���Ɏw������)                                                                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��04(���Ɏw������)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special04(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '***********************************************
        '���Ɏw�����ׯ�ݸ�          ����
        '***********************************************
        Dim objAryTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
        objAryTPLN_CARRY_QUE.FEQ_ID = mobjTPLN_CARRY_QUE.FEQ_ID            '�ݔ�ID
        objAryTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND    '�����w����
        objAryTPLN_CARRY_QUE.FCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SIN         '�w���敪
        intRet = objAryTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_ANY()             '�擾
        If intRet <> RetCode.OK Then
            '(���Ɏw�����Ȃ��ꍇ)
            Return RetCode.OK
        Else
            '(���Ɏw��������ꍇ)

            objTSTS_HIKIATE.FWAIT_REASON = "�ڰ݂����ɒ�(" & TO_STRING(objAryTPLN_CARRY_QUE.ARYME.Length) & "��)�ׁ̈A���Ɋ����҂��B"
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

            Return RetCode.NotEnough
        End If


        Return intReturn
    End Function
#End Region
#Region "  ���ꏈ��05(��O�I����)                                                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��05(���Ɏw������)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special05(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '***********************************************
        '����
        '***********************************************
        If objTPRG_TRK_BUF_FM.FRAC_EDA = FLAG_OFF Then Return RetCode.OK


        '***********************************************
        '�֘A������ۯ��I�̎擾
        '***********************************************
        Dim objTrkRelation() As TBL_TPRG_TRK_BUF = Nothing                      '�ׯ�ݸ��ޯ̧�׽
        Dim objStockFind As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)          '�݌ɏ��
        Dim objStockRelation() As TBL_TRST_STOCK = Nothing                      '�݌ɏ��
        Call GetTPRG_TRK_BUF_Relation(objTPRG_TRK_BUF_FM, objTrkRelation, objStockFind, objStockRelation)


        '***********************************************
        '�O�I����
        '***********************************************
        If IsNull(objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID) And IsNull(objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID) Then
            '(�O�I�������Ƃ���I�������ꍇ)
            Return RetCode.OK
        End If


        '**********************************************************************************************
        '�����w��QUE            �X�V
        '�O�I�̗D����グ��
        '
        '�ڰ݂ɑ΂��Ĉ��̏o�Ɏw�������ײ���Ȃ��̂ŁA�O�I�������I�̕����D��x�������ƁA�i���ɏo�Ɏw�����o�Ȃ��Ȃ�̂ŁA���̑Ή�
        '**********************************************************************************************
        Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)
        '===================================
        '�O�I�       �X�V
        '===================================
        If IsNotNull(objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID) Then
            '(�݌ɂ����݂��Ă���ꍇ)

            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
            objTPLN_CARRY_QUE.FPALLET_ID = objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID     '��گ�ID
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON                        '�����w����
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)                                '�擾
            If intRet = RetCode.OK Then
                objTPLN_CARRY_QUE.FPRIORITY += 1                    '�D������
                objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()           '�X�V
                objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)           '�������N��
            End If

        End If

        '===================================
        '�O�I����       �X�V
        '===================================
        If IsNotNull(objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID) Then
            '(�݌ɂ����݂��Ă���ꍇ)

            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
            objTPLN_CARRY_QUE.FPALLET_ID = objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID     '��گ�ID
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON                        '�����w����
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)                                '�擾
            If intRet = RetCode.OK Then
                objTPLN_CARRY_QUE.FPRIORITY += 1                    '�D������
                objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()           '�X�V
                objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)           '�������N��
            End If

        End If



        '***********************************************
        '�w���҂����R           �X�V
        '***********************************************
        objTSTS_HIKIATE.FWAIT_REASON = "�O�I�̏o�ɑ҂�"
        objTSTS_HIKIATE.FUPDATE_DT = Now
        objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()


        Return RetCode.NotEnough
    End Function
#End Region
#Region "  ���ꏈ��06(�o�I�ޯ̧������)                                                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��06(�o�I�ޯ̧������)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special06(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             ) _
                             As RetCode
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK



        '**************************************
        '�ׯ�ݸ��ޯ̧Ͻ�        �擾
        '**************************************
        Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO    '�ׯ�ݸ��ޯ̧��
        objTMST_TRK.GET_TMST_TRK(False)                             '�擾
        If IsNull(objTMST_TRK.XEQ_ID_OUT_BUF) Then Return RetCode.OK


        '**************************************
        '�ݔ���(�o�I�ޯ̧��)      �擾
        '**************************************
        Dim objTSTS_EQ_CTRL_OUT_BUF As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
        objTSTS_EQ_CTRL_OUT_BUF.FEQ_ID = objTMST_TRK.XEQ_ID_OUT_BUF     '�ݔ�ID
        objTSTS_EQ_CTRL_OUT_BUF.GET_TSTS_EQ_CTRL()                      '�擾


        '**************************************
        '����
        '**************************************
        If TO_INTEGER(objTSTS_EQ_CTRL_OUT_BUF.FEQ_STS) = FLAG_ON Then
            '(�o�I�ޯ̧��ON�̏ꍇ)
            Return RetCode.OK
        Else
            objTSTS_HIKIATE.FWAIT_REASON = "�o�I�ޯ̧��҂�  [�ݔ�ID:" & objTSTS_EQ_CTRL_OUT_BUF.FEQ_ID & "]"
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

            Return RetCode.NotEnough
        End If


        Return RetCode.NotEnough
    End Function
#End Region


#Region "  ���ꏈ��11(�ڰݖ��Ɉꌏ�����o�Ɏw���𑗐M���Ȃ��悤�ɐ���)                                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��11(�ڰݖ��Ɉꌏ�����o�Ɏw���𑗐M���Ȃ��悤�ɐ���)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">�������ׯ�ݸ�</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FM�ׯ�ݸ�</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TO�ׯ�ݸ�</param>
    ''' <param name="objTSTS_HIKIATE">�݌Ɉ������</param>
    ''' <param name="objTMST_CRANE">�ڰ�Ͻ�</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special11(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             , ByVal objTMST_CRANE As TBL_TMST_CRANE _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String


        '************************************************
        '�����ݒ�
        '************************************************
        Dim intCount As Integer = 0     '�o�Ɏw�����Đ�


        '************************************************
        '�ׯ�ݸ��ޯ̧(�����p)       �擾
        '************************************************
        Dim objTPRG_TRK_BUF_ASRS_CHECK As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        objTPRG_TRK_BUF_ASRS_CHECK.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO     '�ׯ�ݸ��ޯ̧��
        objTPRG_TRK_BUF_ASRS_CHECK.objTMST_CRANE = objTMST_CRANE                    '�ڰ�Ͻ�
        intRet = objTPRG_TRK_BUF_ASRS_CHECK.GET_TPRG_TRK_BUF_RESERVE_RAC(True)      '�ׯ�ݸ��ޯ̧����  [���o�ɗ\��I]
        If intRet = RetCode.OK Then
            For ii As Integer = 0 To UBound(objTPRG_TRK_BUF_ASRS_CHECK.ARYME)
                '(ٰ��:���o�ɗ\��I��)

                If objTPRG_TRK_BUF_ASRS_CHECK.ARYME(ii).FRES_KIND = FRES_KIND_SRSV_TRNS_OUT Then
                    '(���o�\��̏ꍇ)

                    intCount += 1
                    If intCount = 2 Then
                        '(����2���o�ɂ��Ă����ꍇ)
                        objTSTS_HIKIATE.FWAIT_REASON = "�ڰ݂��o�ɒ��ׁ̈A�o�Ɋ����҂��B"
                        objTSTS_HIKIATE.FUPDATE_DT = Now
                        objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()
                        Return RetCode.NotEnough
                    End If

                End If

            Next
        End If


        Return RetCode.OK
    End Function
#End Region
#Region "  ���ꏈ��12(�߱�����ŁA���ɏo�ɏ������s���Ă��邩�ۂ��̔��f)                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��12(�߱�����ŁA���ɏo�ɏ������s���Ă��邩�ۂ��̔��f)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">�������ׯ�ݸ�</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FM�ׯ�ݸ�</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TO�ׯ�ݸ�</param>
    ''' <param name="objTSTS_HIKIATE">�݌Ɉ������</param>
    ''' <param name="objTMST_CRANE">�ڰ�Ͻ�</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special12(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             , ByVal objTMST_CRANE As TBL_TMST_CRANE _
                             ) _
                             As RetCode
        'Dim intRet As RetCode
        'Dim strMsg As String


        '************************************************
        '�����ݒ�
        '************************************************
        Dim intCount As Integer = 0     '�o�Ɏw�����Đ�


        '************************************************
        '�ׯ�ݸ��ޯ̧(�����p)       �擾
        '************************************************
        If objTPRG_TRK_BUF_FM.FTRK_BUF_NO <> FTRK_BUF_NO_J9000 Then
            Return RetCode.NotEnough
        End If


        Return RetCode.OK
    End Function
#End Region
#Region "  ���ꏈ��13(�߱�����ŁA�����̏o�Ɏw�����s��)                                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��13(�߱�����ŁA�����̏o�Ɏw�����s��)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">�������ׯ�ݸ�</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FM�ׯ�ݸ�</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TO�ׯ�ݸ�</param>
    ''' <param name="objTSTS_HIKIATE">�݌Ɉ������</param>
    ''' <param name="objTMST_CRANE">�ڰ�Ͻ�</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special13(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             , ByVal objTMST_CRANE As TBL_TMST_CRANE _
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String


        '************************
        '����
        '************************
        If IsNull(mobjTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
            '(�ݸ�ُo�ɂ̏ꍇ)
            Return RetCode.OK
        End If


        '************************************************
        '�ׯ�ݸ��ޯ̧(����)         �擾
        '************************************************
        Dim objTPRG_TRK_BUF_AITE As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        objTPRG_TRK_BUF_AITE.FPALLET_ID = mobjTPLN_CARRY_QUE.XPALLET_ID_AITE        '��گ�ID
        objTPRG_TRK_BUF_AITE.GET_TPRG_TRK_BUF()                                     '�擾
        If objTPRG_TRK_BUF_AITE.FTRK_BUF_NO <> objTPRG_TRK_BUF_FM.FTRK_BUF_NO Then
            '(�������گĂ������q�ɂɂ��Ȃ������ꍇ)
            Return RetCode.OK
        End If



        '************************
        '�����w��QUE�̓���
        '************************
        Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)         '�����w��QUE
        objTPLN_CARRY_QUE.FPALLET_ID = mobjTPLN_CARRY_QUE.XPALLET_ID_AITE               '��گ�ID
        objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                                          '����


        '************************
        '�o�Ɏw������
        '************************
        Dim objSVR_010201 As New SVR_010201(Owner, ObjDb, ObjDbLog) '�o�Ɏw���׽
        objSVR_010201.TPLN_CARRY_QUE = objTPLN_CARRY_QUE            '�����w��QUE
        intRet = objSVR_010201.ExecCmdFunction()
        If intRet = RetCode.OK Then
            '(�o�Ɏw�����ꂽ�ꍇ)


            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/08/15  �����񍐂���M���Ȃ��ꍇ�A�����Ŋ��������邪�A�����Ŋ���������Ɣ����w��QUE��ں��ނ��Ȃ��Ȃ�A�װ�ƂȂ�̂ł��̑΍�
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)
            If intRet = RetCode.OK Then
                '������������************************************************************************************************************
                objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND
                objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()
                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/08/15  �����񍐂���M���Ȃ��ꍇ�A�����Ŋ��������邪�A�����Ŋ���������Ɣ����w��QUE��ں��ނ��Ȃ��Ȃ�A�װ�ƂȂ�̂ł��̑΍�
            End If
            '������������************************************************************************************************************


        End If


        Return RetCode.OK
    End Function
#End Region

#Region "  ���ꏈ��21(�o�׎w���A�o�׎w���ڍ�ð��ٍX�V)                                                  "
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
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String


        '************************
        '����
        '************************
        'NOP


        '************************************************
        '�o�׎w���ڍ�                   �擾
        '************************************************
        Dim objXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
        objXPLN_OUT_DTL.FPLAN_KEY = objTSTS_HIKIATE.FPLAN_KEY       '�v�淰
        intRet = objXPLN_OUT_DTL.GET_XPLN_OUT_DTL(False)            '�擾
        If intRet <> RetCode.OK Then
            Return RetCode.OK
        End If


        '************************************************
        '�o�׎w��                       �擾
        '************************************************
        Dim objXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
        objXPLN_OUT.XSYUKKA_D = objXPLN_OUT_DTL.XSYUKKA_D           '�o�ד�
        objXPLN_OUT.XHENSEI_NO = objXPLN_OUT_DTL.XHENSEI_NO         '�Ґ�No.
        objXPLN_OUT.XDENPYOU_NO = objXPLN_OUT_DTL.XDENPYOU_NO       '�`�[No.
        objXPLN_OUT.GET_XPLN_OUT()                                  '�擾


        '************************************************
        '�o�׎w��                       �X�V
        '************************************************
        If objXPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JRSV Then
            objXPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JACT      '�o�׏�
            objXPLN_OUT.UPDATE_XPLN_OUT()                   '�X�V
        End If


        Return RetCode.OK
    End Function
#End Region
    '���������ьŗL
    '**********************************************************************************************

End Class
