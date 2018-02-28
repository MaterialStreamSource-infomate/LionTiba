'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�����w������
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_010301
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
#Region "  �����w��                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����w��
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecCmdFunction() As RetCode
        Dim intRet As RetCode                   '�߂�l
        Dim strMsg As String                    'ү����
        Try
            ' '' ''************************
            ' '' ''��������
            ' '' ''************************
            '' ''Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            '************************
            '�����w��QUE
            '************************
            If IsNull(mobjTPLN_CARRY_QUE) = True Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPLN_CARRY_QUE
                Throw New UserException(strMsg)
            End If


            '************************
            '�������ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)      '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_FM.FPALLET_ID = mobjTPLN_CARRY_QUE.FPALLET_ID               '��گ�ID
            intRet = objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF(True)                          '����


            '************************
            '�������ׯ�ݸ�Ͻ��̓���
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)                 '�ׯ�ݸ��ޯ̧Ͻ��׽
            objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO                    '�ׯ�ݸ��ޯ̧No
            intRet = objTMST_TRK.GET_TMST_TRK(True)                                     '����


            '************************
            '�������ڰݐݔ�ID�̓���
            '************************
            Dim strEQ_ID_CRANE_FM As String
            If TO_INTEGER(objTMST_TRK.FBUF_KIND) = FBUF_KIND_SASRS Then
                '************************
                '�ڰ�Ͻ��̓���
                '************************
                Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)         '�ڰ�Ͻ��׽
                objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO              '�ޯ̧��
                objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_FM.FRAC_RETU               '��
                intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                               '����
                If intRet = RetCode.NotFound Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ޯ̧��:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,��:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                    Throw New UserException(strMsg)
                End If

                '�ڰݐݔ�ID�̓���
                strEQ_ID_CRANE_FM = objTMST_CRANE.FEQ_ID
            Else
                '�ڰݐݔ�ID�̓���
                strEQ_ID_CRANE_FM = FEQ_ID_SKOTEI
            End If

            Dim strEQ_ID_CRANE_TO_WORK As String
            '************************
            '�ŏI���B�ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_END_WORK As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_END_WORK.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTR_TO                 '�ޯ̧��
            objTPRG_TRK_BUF_END_WORK.FRSV_PALLET = mobjTPLN_CARRY_QUE.FPALLET_ID                              '��������گ�ID
            intRet = objTPRG_TRK_BUF_END_WORK.GET_TPRG_TRK_BUF_RSV_PALLET()
            If intRet = RetCode.OK Then
                '(�ŏI�����ޯ̧�������Ă���Ă���ꍇ)

                '************************
                '�ڰ�Ͻ��̓���
                '************************
                Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)         '�ڰ�Ͻ��׽
                objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_END_WORK.FTRK_BUF_NO             '�ޯ̧��
                objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_END_WORK.FRAC_RETU              '��
                intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                               '����
                If intRet = RetCode.OK Then
                    '(�ڰ݂��������������ꍇ)
                    strEQ_ID_CRANE_TO_WORK = objTMST_CRANE.FEQ_ID
                Else
                    strEQ_ID_CRANE_TO_WORK = FEQ_ID_SKOTEI
                End If
                '�ڰݐݔ�ID�̓���
                strEQ_ID_CRANE_TO_WORK = objTMST_CRANE.FEQ_ID

            Else
                '(�ŏI�����ޯ̧�������Ă���Ă��Ȃ��ꍇ)
                strEQ_ID_CRANE_TO_WORK = FEQ_ID_SKOTEI
            End If


            '************************
            '����ٰ�Ͻ��̓���
            '************************
            Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)             '����ٰ�Ͻ�
            objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO                      '���ޯ̧��
            objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_FM.FTR_TO                           '���ޯ̧��
            objTMST_ROUTE.FEQ_ID_CRANE_FM = strEQ_ID_CRANE_FM                           '���ڰݐݔ�ID
            objTMST_ROUTE.FEQ_ID_CRANE_TO = strEQ_ID_CRANE_TO_WORK                      '��ڰݐݔ�ID
            intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                                 '����


            '************************
            '�݌Ɉ������̓���
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)         '�݌Ɉ������׽
            objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_FM.FPALLET_ID                  '��گ�ID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                            '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[��گ�ID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '��ٰĂ��ׯ�ݸ��ޯ̧����
            '************************
            Dim objSVR_100207 As New SVR_100207(Owner, ObjDb, ObjDbLog)                     '��ٰĂ��ׯ�ݸ��ޯ̧�����׽
            objSVR_100207.FPALLET_ID = objTPRG_TRK_BUF_FM.FPALLET_ID                        '��گ�ID
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
            Dim objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF                               '�ׯ�ݸ��ޯ̧�׽
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
                objSVR_100206.FPALLET_ID = objTPRG_TRK_BUF_FM.FPALLET_ID                '��گ�ID
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
            'JobMate:N.Dounoshita 2013/09/05 �ُ��ޯčX�V


            '****************************************************************************
            '���ꏈ��11(�߱���ɔ����̏ꍇ�A2�̋��ޯ̧���Ȃ��Ɣ����͍s��Ȃ�)
            '****************************************************************************
            intRet = Special11(objTPRG_TRK_BUF_RELAY _
                             , objTPRG_TRK_BUF_FM _
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
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog)                 '�݌Ɉړ��׽
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_FM                       '�ׯ�ݸ��ޯ̧
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_RELAY                    '�ׯ�ݸ��ޯ̧
            objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_FM.FPALLET_ID                    '��گ�ID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SRELAY_START                           'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND                   '��Ǝ��
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_OFF                                   '�������ر�׸�
            objSVR_100103.STOCK_TRNS()                                                  '�ړ�


            '************************
            '�ð���Ͻ��̓���
            '************************
            Dim blnMENTE_CANCEL_FLAG As Boolean = False
            Dim objTMST_ST As New TBL_TMST_ST(Owner, ObjDb, ObjDbLog)   '�ð���Ͻ��׽
            objTMST_ST.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO     '�ޯ̧��(�ð��݇�)
            intRet = objTMST_ST.GET_TMST_ST(False)                      '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                blnMENTE_CANCEL_FLAG = False
            Else
                If TO_INTEGER(objTMST_ST.FMENTE_CANCEL_FLAG) <> FLAG_OFF Then
                    blnMENTE_CANCEL_FLAG = True
                End If
            End If

            objTPRG_TRK_BUF_FM.FRSV_PALLET = mobjTPLN_CARRY_QUE.FPALLET_ID                  '��������گ�ID
           
            '===============================
            'TO�����L������
            '===============================
            If TO_INTEGER(objTMST_ROUTE.FRSV_BUF_TO_FLAG) = FRSV_BUF_TO_FLAG_SRSV Then
                '===============================
                '�������ޯ̧�̍X�V
                '===============================
                objTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT                               '�������
                objTPRG_TRK_BUF_TO.FBUF_IN_DT = Now                                                 '�ޯ̧������
                objTPRG_TRK_BUF_TO.FTR_FM = objTPRG_TRK_BUF_FM.FTR_FM                               '����FM�ޯ̧��
                objTPRG_TRK_BUF_TO.FTR_TO = objTPRG_TRK_BUF_FM.FTR_TO                               '����TO�ޯ̧��
                objTPRG_TRK_BUF_TO.FRSV_PALLET = objTPRG_TRK_BUF_FM.FRSV_PALLET                     '��������گ�ID
                objTPRG_TRK_BUF_TO.FRSV_BUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO                     'FM�����ׯ�ݸއ�
                objTPRG_TRK_BUF_TO.FRSV_ARRAY_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY                'FM�����z��
                objTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()                                            '�X�V


                '===============================
                'TO�����L�����u�L�v�̏ꍇ�A�SٰĂ̈������\����s��
                '===============================
                Call objSVR_100206.RSV_TMST_ROUTE_TO_END()                                      '�������\��
            End If




            '******************************************************
            '������/������/�������ޯ̧�̍X�V
            '******************************************************

            If blnMENTE_CANCEL_FLAG = False Then
                '(��ݾى��׸ނ�OFF�̏ꍇ)

                '===============================
                '�������ޯ̧�̍X�V
                '===============================
                objTPRG_TRK_BUF_RELAY.FRSV_PALLET = objTPRG_TRK_BUF_FM.FRSV_PALLET                  '��������گ�ID
                objTPRG_TRK_BUF_RELAY.FRES_KIND = FRES_KIND_SZAIKO                                   '�������
                objTPRG_TRK_BUF_RELAY.FTR_FM = objTPRG_TRK_BUF_FM.FTR_FM                            '����FM�ޯ̧��
                objTPRG_TRK_BUF_RELAY.FTR_TO = objTPRG_TRK_BUF_FM.FTR_TO                            '����TO�ޯ̧��
                objTPRG_TRK_BUF_RELAY.FTR_IDOU = objTPRG_TRK_BUF_FM.FTR_IDOU                        '����TO�ړ��ޯ̧��
                objTPRG_TRK_BUF_RELAY.FTRNS_FM = objTPRG_TRK_BUF_FM.FTRNS_ADDRESS                   '�����w�ߗpFM
                objTPRG_TRK_BUF_RELAY.FTRNS_TO = objTPRG_TRK_BUF_TO.FTRNS_ADDRESS                   '�����w�ߗpTO
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO                  'FM�����ׯ�ݸއ�
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY             'FM�����z��
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO                  'TO�����ׯ�ݸއ�
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY             'TO�����z��
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_FM.FDISP_ADDRESS_FM        'FM�\�L�p���ڽ
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_TO.FDISP_ADDRESS           'TO�\�L�p���ڽ
                objTPRG_TRK_BUF_RELAY.FBUF_IN_DT = Now                                              '�ޯ̧������
                objTPRG_TRK_BUF_RELAY.UPDATE_TPRG_TRK_BUF()                                         '�X�V


                '===============================
                '�������ޯ̧�̍X�V
                '===============================
                objTPRG_TRK_BUF_FM.CLEAR_TPRG_TRK_BUF()                                             '���


            Else
                '(��ݾى��׸ނ�ON�̏ꍇ)

                '===============================
                '�������ޯ̧�̍X�V
                '===============================
                objTPRG_TRK_BUF_FM.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                        '�������
                objTPRG_TRK_BUF_FM.FRSV_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO             'TO�����ׯ�ݸއ�
                objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY        'TO�����z��
                objTPRG_TRK_BUF_FM.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_FM.GET_ADDRESS_TO     'TO�\�L�p���ڽ
                objTPRG_TRK_BUF_FM.FBUF_IN_DT = Now                                         '�ޯ̧������
                objTPRG_TRK_BUF_FM.UPDATE_TPRG_TRK_BUF()                                    '�X�V


                '===============================
                '�������ޯ̧�̍X�V
                '===============================
                objTPRG_TRK_BUF_RELAY.FRSV_PALLET = objTPRG_TRK_BUF_FM.FRSV_PALLET                  '��������گ�ID
                objTPRG_TRK_BUF_RELAY.FRES_KIND = FRES_KIND_SZAIKO                                   '�������
                objTPRG_TRK_BUF_RELAY.FTR_FM = objTPRG_TRK_BUF_FM.FTR_FM                            '����FM�ޯ̧��
                objTPRG_TRK_BUF_RELAY.FTR_TO = objTPRG_TRK_BUF_FM.FTR_TO                            '����TO�ޯ̧��
                objTPRG_TRK_BUF_RELAY.FTR_IDOU = objTPRG_TRK_BUF_FM.FTR_IDOU                        '����TO�ړ��ޯ̧��
                objTPRG_TRK_BUF_RELAY.FTRNS_FM = objTPRG_TRK_BUF_FM.FTRNS_ADDRESS                   '�����w�ߗpFM
                objTPRG_TRK_BUF_RELAY.FTRNS_TO = objTPRG_TRK_BUF_TO.FTRNS_ADDRESS                   '�����w�ߗpTO
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO                  'FM�����ׯ�ݸއ�
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY             'FM�����z��
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO                  'TO�����ׯ�ݸއ�
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY             'TO�����z��
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_FM.FDISP_ADDRESS_FM        'FM�\�L�p���ڽ
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_TO.FDISP_ADDRESS           'TO�\�L�p���ڽ
                objTPRG_TRK_BUF_RELAY.FBUF_IN_DT = Now                                              '�ޯ̧������
                objTPRG_TRK_BUF_RELAY.UPDATE_TPRG_TRK_BUF()                                         '�X�V

            End If


            '************************
            '�����w��QUE�̍X�V
            '************************
            mobjTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND    '�����w����
            mobjTPLN_CARRY_QUE.FUPDATE_DT = Now                             '�X�V����
            mobjTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                      '�X�V


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2012/04/24 �����w���𑗐M


            '************************************************
            '���Y���ɐݒ���       ����(�ً}���ɂ��ۂ��̔��f)
            '************************************************
            Dim objXSTS_PRODUCT_IN As New TBL_XSTS_PRODUCT_IN(Owner, ObjDb, ObjDbLog)
            objXSTS_PRODUCT_IN.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO             '�ׯ�ݸ��ޯ̧��
            objXSTS_PRODUCT_IN.XKINKYU_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO          '�ً}���������ׯ�ݸ��ޯ̧��
            intRet = objXSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN(False)                      '�擾


            If TO_INTEGER(objTPRG_TRK_BUF_FM.FTR_TO) = FTRK_BUF_NO_J9000 Then
                '(�s�悪�����q�ɂ̏ꍇ)


                '************************************************
                '�����w��
                '************************************************
                Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         '�����ID
                objSVR_190001.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID     '��گ�ID
                objSVR_190001.FTRNS_SERIAL = ""                                 '�����ره�
                Call objSVR_190001.SendYasukawa_IDTrns(objTPRG_TRK_BUF_RELAY _
                                                     , objTPRG_TRK_BUF_FM _
                                                     , objTPRG_TRK_BUF_TO _
                                                     , mobjTPLN_CARRY_QUE _
                                                     , objTMST_ROUTE _
                                                     )


            ElseIf intRet = RetCode.OK Then
                '(�ً}���ɐݒ�̏ꍇ)


                '************************************************
                '�����w��
                '************************************************
                Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         '�����ID
                objSVR_190001.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID     '��گ�ID
                objSVR_190001.FTRNS_SERIAL = ""                                 '�����ره�
                Call objSVR_190001.SendYasukawa_IDKinkyuTrns(objTPRG_TRK_BUF_RELAY _
                                                           , objTPRG_TRK_BUF_FM _
                                                           , objTPRG_TRK_BUF_TO _
                                                           , mobjTPLN_CARRY_QUE _
                                                           , objTMST_ROUTE _
                                                           )


            End If


            '������������************************************************************************************************************


            '========================
            '�w�����M�҂����R�̸ر
            '========================
            objTSTS_HIKIATE.FWAIT_REASON = DEFAULT_STRING
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/03/22 ���ꏈ��


            ''**************************************
            ''���ꏈ��01(�v����ԍX�V)
            ''**************************************
            'Call Special01(objTPRG_TRK_BUF_RELAY _
            '             , objTPRG_TRK_BUF_FM _
            '             , objTPRG_TRK_BUF_TO _
            '             , objTSTS_HIKIATE _
            '             )


            '****************************************************************************
            '���ꏈ��02(���Y���ɐݒ��Ԃ̎��ѐ��ʶ��ı���)
            '****************************************************************************
            Call Special02(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_FM _
                         , objTPRG_TRK_BUF_TO _
                         , objTSTS_HIKIATE _
                         )


            '������������************************************************************************************************************


            '************************
            '���튮��
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & _
                                "  [��گ�ID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & _
                                "  ,������:" & objTPRG_TRK_BUF_FM.FDISP_ADDRESS & _
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
#Region "  ���ꏈ��01(�v����ԍX�V)                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��01(�߱�����҂�����)
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
                             ) _
                             As RetCode
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        ''************************************************
        ''�ׯ�ݸ��ޯ̧Ͻ�            �擾
        ''************************************************
        'Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        'objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO        '�ׯ�ݸ��ޯ̧��
        'objTMST_TRK.GET_TMST_TRK()                                      '�擾


        ''************************************************
        ''����
        ''************************************************
        'If IsNull(objTMST_TRK.XEQ_ID_IN_FR) Or IsNull(objTMST_TRK.XEQ_ID_IN_BK) Then
        '    Return RetCode.OK
        'End If


        ''************************************************
        ''�ݔ���                   �X�V
        ''************************************************
        'Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_IN_FR, FEQ_REQ_STS_JIN_TRNS_SIZI_ON)
        'Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_IN_BK, FEQ_REQ_STS_JIN_TRNS_SIZI_ON)
        'If IsNotNull(objTMST_TRK.XEQ_ID_HASU_FR) Then Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_HASU_FR, FEQ_REQ_STS_JIN_TRNS_SIZI_ON)
        'If IsNotNull(objTMST_TRK.XEQ_ID_HASU_BK) Then Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_HASU_BK, FEQ_REQ_STS_JIN_TRNS_SIZI_ON)


        Return intReturn
    End Function
#End Region
#Region "  ���ꏈ��02(���Y���ɐݒ��Ԃ̎��ѐ��ʶ��ı���)                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��02(���Y���ɐݒ��Ԃ̎��ѐ��ʶ��ı���)
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
                             ) _
                             As RetCode
        Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '************************************************
        '����
        '************************************************
        If TO_INTEGER(objTPRG_TRK_BUF_FM.FTR_TO) <> FTRK_BUF_NO_J9000 Then
            Return intReturn
        End If


        '************************************************
        '�݌ɏ��                   �擾
        '************************************************
        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
        objTRST_STOCK.FPALLET_ID = objTSTS_HIKIATE.FPALLET_ID           '��گ�ID
        objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)                       '�擾


        '*****************************************************
        '���Y���ɐݒ���           �ǉ�
        '*****************************************************
        If IsNotNull(objTRST_STOCK.ARYME(0).FST_FM) Then
            '(������ST�ׯ�ݸ��ޯ̧������Ă���Ă����ꍇ)

            Dim objXSTS_PRODUCT_IN As New TBL_XSTS_PRODUCT_IN(Owner, ObjDb, ObjDbLog)
            objXSTS_PRODUCT_IN.FTRK_BUF_NO = objTRST_STOCK.ARYME(0).FST_FM              '�ׯ�ݸ��ޯ̧��
            objXSTS_PRODUCT_IN.XPROD_LINE = objTRST_STOCK.ARYME(0).XPROD_LINE           '���Yײ݇�
            objXSTS_PRODUCT_IN.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD           '�i�ں���
            objXSTS_PRODUCT_IN.FIN_KUBUN = objTRST_STOCK.ARYME(0).FIN_KUBUN             '���ɋ敪
            objXSTS_PRODUCT_IN.FHORYU_KUBUN = objTRST_STOCK.ARYME(0).FHORYU_KUBUN       '�ۗ��敪
            objXSTS_PRODUCT_IN.XKENSA_KUBUN = objTRST_STOCK.ARYME(0).XKENSA_KUBUN       '�����敪
            objXSTS_PRODUCT_IN.XKENPIN_KUBUN = objTRST_STOCK.ARYME(0).XKENPIN_KUBUN     '���i�敪
            objXSTS_PRODUCT_IN.XMAKER_CD = objTRST_STOCK.ARYME(0).XMAKER_CD             'Ұ�-����
            intRet = objXSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN(False)                      '�擾
            If intRet = RetCode.OK Then
                '(���������ꍇ)

                objXSTS_PRODUCT_IN.XRESULT_NUM = TO_INTEGER(objXSTS_PRODUCT_IN.XRESULT_NUM) + 1     '���ѐ���
                '������������************************************************************************************************************
                'JobMate:S.Ouchi 2013/10/23 ���Y���Ɏ��э����ǉ�
                objXSTS_PRODUCT_IN.XRESULT_NUM_CASE = TO_INTEGER(objXSTS_PRODUCT_IN.XRESULT_NUM_CASE) + objTRST_STOCK.ARYME(0).FTR_VOL  '���ѐ���(����)
                'JobMate:S.Ouchi 2013/10/23 ���Y���Ɏ��э����ǉ�
                '������������************************************************************************************************************
                objXSTS_PRODUCT_IN.UPDATE_XSTS_PRODUCT_IN()                                         '�X�V

            End If

        End If


        Return intReturn
    End Function
#End Region

#Region "  ���ꏈ��11(�߱���ɔ����̏ꍇ�A2�̋��ޯ̧���Ȃ��Ɣ����͍s��Ȃ�)                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��11(�߱���ɔ����̏ꍇ�A2�̋��ޯ̧���Ȃ��Ɣ����͍s��Ȃ�)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">�������ׯ�ݸ�</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FM�ׯ�ݸ�</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TO�ׯ�ݸ�</param>
    ''' <param name="objTSTS_HIKIATE">�݌Ɉ������</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special11(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                             , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                             , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                             ) _
                             As RetCode
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '************************************************
        '����
        '************************************************
        'NOP


        '************************************************
        '�ׯ�ݸ��ޯ̧(TO)���ޯ̧��      �擾
        '************************************************
        Dim intCountAkiTo As Integer = 0        '�ׯ�ݸ��ޯ̧(TO)���ޯ̧��
        Dim objTPRG_TRK_BUF_CountTo As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        objTPRG_TRK_BUF_CountTo.FTRK_BUF_NO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO        '�ׯ�ݸ��ޯ̧��
        objTPRG_TRK_BUF_CountTo.WHERE = "   AND FRES_KIND = 0 AND FRSV_PALLET IS NULL AND FPALLET_ID IS NULL "        '���ޯ̧����
        intCountAkiTo = objTPRG_TRK_BUF_CountTo.GET_TPRG_TRK_BUF_COUNT()              '�擾


        '************************************************
        '
        '************************************************
        If intCountAkiTo <= 1 Then
            '(To�̋󂫂�1�ȉ������Ȃ��ꍇ)

            If IsNotNull(mobjTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                '(�߱�����̏ꍇ)

                If mobjTPLN_CARRY_QUE.XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA Then
                    '(�e�̏ꍇ)

                    objTSTS_HIKIATE.FWAIT_REASON = "�������ޯ̧�̋��ޯ̧�҂��B(�e)[������:" & objTPRG_TRK_BUF_TO.FDISP_ADDRESS & "][�ׯ�ݸ��ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_TO.FTRK_BUF_NO) & "]"
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                Else
                    '(�q�̏ꍇ)


                    '************************************************
                    '�ׯ�ݸ��ޯ̧(����)         �擾
                    '************************************************
                    Dim objTPRG_TRK_BUF_AITE As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    objTPRG_TRK_BUF_AITE.FPALLET_ID = mobjTPLN_CARRY_QUE.XPALLET_ID_AITE        '��گ�ID
                    objTPRG_TRK_BUF_AITE.GET_TPRG_TRK_BUF()                                     '�擾
                    If objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO <> objTPRG_TRK_BUF_AITE.FTRK_BUF_NO Then
                        '(�������܂�����������Ȃ������ꍇ)

                        objTSTS_HIKIATE.FWAIT_REASON = "�������ޯ̧�̋��ޯ̧�҂��B(�q)[������:" & objTPRG_TRK_BUF_TO.FDISP_ADDRESS & "][�ׯ�ݸ��ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_TO.FTRK_BUF_NO) & "]"
                        objTSTS_HIKIATE.FUPDATE_DT = Now
                        objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                        Return RetCode.NotEnough
                    End If


                End If

            End If

        End If


        Return intReturn
    End Function
#End Region

    '���������ьŗL
    '**********************************************************************************************

End Class
