'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z���Ɏw������
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_010101
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
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '�e�׽�̺ݽ�׸�������
    End Sub
#End Region
#Region "  Ҳݏ���(�֐�)                                                                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Ҳݏ���(�֐�)
    ''' </summary>
    ''' <returns>OK/NG</returns>
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


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/25 ���ꏈ��


            '**************************************
            '���ꏈ��02(��O�I�Ɖ��I�̓��ɗ\����֏���)
            '**************************************
            Call Special02()


            '������������************************************************************************************************************


            '************************
            '�ð����ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_ST.FPALLET_ID = mobjTPLN_CARRY_QUE.FPALLET_ID           '��گ�ID
            intRet = objTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF(True)                      '����


            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)        '�ׯ�ݸ��ޯ̧�׽
            Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)                 '����ٰ�Ͻ�
            Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)                 '�ڰ�Ͻ��׽

            If TO_INTEGER(objTPRG_TRK_BUF_ST.FRSV_BUF_TO) <> TO_INTEGER(DEFAULT_INTEGER) And _
               TO_INTEGER(objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO) <> TO_INTEGER(DEFAULT_INTEGER) Then
                '************************************************
                '�����悪��������Ă���ꍇ
                '************************************************
                '************************
                '�q���ޯ̧�̓���
                '************************
                objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_ST.FRSV_BUF_TO         '�ޯ̧��
                objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO    '�z��
                intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(False)                     '����
                If intRet = RetCode.NotFound Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO) & "  ,�z��:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY) & "]"
                    Throw New UserException(strMsg)
                End If

                '************************
                '�ڰ�Ͻ��̓���
                '************************
                objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO              '�ޯ̧��
                objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU               '��
                intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                                 '����
                If intRet = RetCode.NotFound Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ޯ̧��:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,��:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                    Throw New UserException(strMsg)
                End If

                '************************
                '����ٰ�Ͻ��̓���
                '************************
                objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO                  '���ޯ̧��      
                objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_ST.FTR_TO                       '���ޯ̧��
                objTMST_ROUTE.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                           '���ڰݐݔ�ID
                objTMST_ROUTE.FEQ_ID_CRANE_TO = objTMST_CRANE.FEQ_ID                    '��ڰݐݔ�ID
                intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                             '����

            Else
                '************************************************
                '�����悪��������Ă��Ȃ��ꍇ
                '************************************************
                '************************
                '����ٰ�Ͻ��̓���
                '************************
                objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO                  '���ޯ̧��      
                objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_ST.FTR_TO                       '���ޯ̧��
                objTMST_ROUTE.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                           '���ڰݐݔ�ID
                objTMST_ROUTE.FEQ_ID_CRANE_TO = FEQ_ID_SKOTEI                           '��ڰݐݔ�ID
                intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                             '����


                '************************
                '������ڰ�ID�擾
                '************************
                Dim strEQ_ID() As String                                            '�ڰ�ID
                intRet = objTMST_ROUTE.GET_TMST_ROUTE_CRANES()                      '�ڰ�ID�擾
                If intRet = RetCode.NotFound Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_TMST_ROUTE & "[���ޯ̧��:" & TO_STRING(objTMST_ROUTE.FBUF_FM) & "][���ڰݐݔ�ID:" & objTMST_ROUTE.FEQ_ID_CRANE_FM & "][���ޯ̧��:" & TO_STRING(objTMST_ROUTE.FBUF_TO) & "][��ڰݐݔ�ID:******]"
                    Throw New UserException(strMsg)
                End If
                ReDim Preserve strEQ_ID(UBound(objTMST_ROUTE.ARYME))
                For ii As Integer = LBound(objTMST_ROUTE.ARYME) To UBound(objTMST_ROUTE.ARYME)
                    strEQ_ID(ii) = objTMST_ROUTE.ARYME(ii).FEQ_ID_CRANE_TO
                Next
                objTMST_ROUTE.ARYME_CLEAR()

                '************************************************
                '�ړ���̈������K�v�ȏꍇ
                '************************************************

                '************************
                '�ړ����ޯ̧�̋�I����
                '************************
                Dim objSVR_100201 As New SVR_100201(Owner, ObjDb, ObjDbLog)         '��I�����׽
                objSVR_100201.FTRK_BUF_NO = objTPRG_TRK_BUF_ST.FTR_TO               '�ޯ̧��
                objSVR_100201.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID            '��گ�ID
                objSVR_100201.FEQ_ID_CRANE = strEQ_ID                               '�ڰ�ID
                intRet = objSVR_100201.FIND_TANA_AKI                                '����
                If intRet = RetCode.NotFound Then
                    '(������Ȃ��ꍇ)
                    Select Case objSVR_100201.FTRK_BUF_NO
                        Case FTRK_BUF_NO_J9000 : Call AddToMsgLog(Now, FMSG_ID_S0102)
                        Case Else : Call AddToMsgLog(Now, FMSG_ID_S0102)
                    End Select
                    Return RetCode.NotEnough
                End If

                objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objSVR_100201.FTRK_BUF_NO          '�ޯ̧��
                objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objSVR_100201.FTRK_BUF_ARRAY    '�z��
                intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(False)                 '����
                If intRet = RetCode.NotFound Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO) & "  ,�z��:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY) & "]"
                    Throw New UserException(strMsg)
                End If

                objTPRG_TRK_BUF_ST.FRSV_BUF_TO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO           'TO�����ׯ�ݸއ�
                objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY      'TO�����z��
                objTPRG_TRK_BUF_ST.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_ST.FDISP_ADDRESS      'FM�\�L�p���ڽ
                objTPRG_TRK_BUF_ST.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS    'TO�\�L�p���ڽ
                objTPRG_TRK_BUF_ST.FBUF_IN_DT = Now                                         '�ޯ̧������
                objTPRG_TRK_BUF_ST.UPDATE_TPRG_TRK_BUF()                                    '�X�V


                '************************
                '�q�ɂ̍X�V
                '************************
                objTPRG_TRK_BUF_ASRS.FRSV_PALLET = objTPRG_TRK_BUF_ST.FPALLET_ID            '��������گ�ID
                objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                     '������� = �����\��
                objTPRG_TRK_BUF_ASRS.FRSV_BUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO           'FM�����ׯ�ݸއ�
                objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY      'FM�����z��
                objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                                  '�X�V


                '************************
                '�ڰ�Ͻ��̓���
                '************************
                objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO                '�ޯ̧��
                objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU                 '��
                intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                                   '����
                If intRet = RetCode.NotFound Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ޯ̧��:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,��:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                    Throw New UserException(strMsg)
                End If

                '************************
                '����ٰ�Ͻ��̓���
                '************************
                objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO                  '���ޯ̧��      
                objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_ST.FTR_TO                       '���ޯ̧��
                objTMST_ROUTE.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                           '���ڰݐݔ�ID
                objTMST_ROUTE.FEQ_ID_CRANE_TO = objTMST_CRANE.FEQ_ID                    '��ڰݐݔ�ID
                intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                             '����

            End If


            '************************
            '�݌Ɉ������̓���
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '�݌Ɉ������׽
            objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID          '��گ�ID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                    '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[��گ�ID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
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
            If TO_INTEGER(objTMST_CRANE.FIN_MAX) > 0 Then
                If TO_INTEGER(objTMST_CRANE.FIN_MAX) <= mobjTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_SEND_COUNT_IN() Then
                    '========================
                    '�w�����M�҂����R�̓o�^
                    '========================
                    objTSTS_HIKIATE.FWAIT_REASON = "���ɋK�������ް  [�ޯ̧��" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "][�ݔ�ID" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                End If
            End If


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/25 ���ꏈ��


            '**************************************
            '���ꏈ��03(���Ɏw���̌����͈ꌏ�̂�)
            '**************************************
            intRet = Special03(Nothing _
                             , objTPRG_TRK_BUF_ST _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTSTS_HIKIATE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '**************************************
            '���ꏈ��04(�o�Ɏw������)
            '**************************************
            intRet = Special04(Nothing _
                             , objTPRG_TRK_BUF_ST _
                             , objTPRG_TRK_BUF_ASRS _
                             , objTSTS_HIKIATE _
                             )
            If intRet <> RetCode.OK Then
                Return RetCode.NotEnough
            End If


            '������������************************************************************************************************************


            '************************
            '����ٰ�Ͻ��̓���
            '************************
            objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO              '���ޯ̧��      
            objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO            '���ޯ̧��
            objTMST_ROUTE.FEQ_ID_CRANE_FM = FEQ_ID_SKOTEI                       '���ڰݐݔ�ID
            objTMST_ROUTE.FEQ_ID_CRANE_TO = objTMST_CRANE.FEQ_ID                '��ڰݐݔ�ID
            intRet = objTMST_ROUTE.GET_TMST_ROUTE(True)                         '����


            '************************
            'ٰĐݔ�����(From - To)
            '************************
            Dim objSVR_100203 As New SVR_100203(Owner, ObjDb, ObjDbLog)
            objSVR_100203.FBUF_FM = objTMST_ROUTE.FBUF_FM                   '���ׯ�ݸ��ޯ̧��
            objSVR_100203.FBUF_TO = objTMST_ROUTE.FBUF_TO                   '���ׯ�ݸ��ޯ̧��
            objSVR_100203.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM   '���ڰݐݔ�ID
            objSVR_100203.FEQ_ID_CRANE_TO = objTMST_ROUTE.FEQ_ID_CRANE_TO   '��ڰݐݔ�ID
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
            
            '************************
            '���ɒ��ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)       '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = objTMST_ROUTE.FBUF_RELAY                    '�ׯ�ݸ��ޯ̧No
            objTPRG_TRK_BUF_RELAY.FRSV_PALLET = objTPRG_TRK_BUF_ST.FPALLET_ID               '��������گ�ID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF_RSV_PALLET                      '����
            If intRet = RetCode.OK Then
                '(��Ɉ�������Ă���ꍇ)
            Else
                '(�V���Ɉ�������ꍇ)
                intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF_AKI_HIRA                    '����
                If intRet = RetCode.NotFound Then
                    '(������Ȃ��ꍇ)
                    '========================
                    '�w�����M�҂����R�̓o�^
                    '========================
                    objTSTS_HIKIATE.FWAIT_REASON = "�󂫑҂�  [�ޯ̧��" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "]"
                    objTSTS_HIKIATE.FUPDATE_DT = Now
                    objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

                    Return RetCode.NotEnough
                End If
            End If


            '************************
            '�݌Ɉړ�
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '�݌Ɉړ��׽
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_ST       '�ׯ�ݸ��ޯ̧(�ð����ޯ̧)
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_RELAY    '�ׯ�ݸ��ޯ̧(���ɒ��ޯ̧)
            objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_ST.FPALLET_ID    '��گ�ID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SIN_START             'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '��Ǝ��
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_OFF                   '�������ر�׸�
            objSVR_100103.STOCK_TRNS()                                  '�ړ�


            '************************
            '�ð���Ͻ��̓���
            '************************
            Dim blnMENTE_CANCEL_FLAG As Boolean = False
            Dim objTMST_ST As New TBL_TMST_ST(Owner, ObjDb, ObjDbLog)   '�ð���Ͻ��׽
            objTMST_ST.FTRK_BUF_NO = objTPRG_TRK_BUF_ST.FTRK_BUF_NO     '�ޯ̧��(�ð��݇�)
            intRet = objTMST_ST.GET_TMST_ST(False)                      '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                blnMENTE_CANCEL_FLAG = False
            Else
                If TO_INTEGER(objTMST_ST.FMENTE_CANCEL_FLAG) <> FLAG_OFF Then
                    blnMENTE_CANCEL_FLAG = True
                End If
            End If


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/03/22 ���ꏈ��


            '**************************************
            '���ꏈ��01(�߱�����҂�����)
            '**************************************
            Call Special01(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_ST _
                         , objTPRG_TRK_BUF_ASRS _
                         , objTSTS_HIKIATE _
                         )


            '������������************************************************************************************************************


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2012/04/24 ���Ɏw���𑗐M


            '************************************************
            '���Ɏw��
            '************************************************
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SIN                     '�����ID
            objSVR_190001.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID     '��گ�ID
            objSVR_190001.FTRNS_SERIAL = ""                                 '�����ره�
            Call objSVR_190001.SendYasukawa_IDIn(objTPRG_TRK_BUF_RELAY _
                                               , objTPRG_TRK_BUF_ST _
                                               , objTPRG_TRK_BUF_ASRS _
                                               , mobjTPLN_CARRY_QUE _
                                               , objTMST_ROUTE _
                                               )
            

            '������������************************************************************************************************************


            '****************************************
            '�ð���/���ɒ�/�q���ޯ̧�̍X�V
            '****************************************
            If blnMENTE_CANCEL_FLAG = False Then
                '(��ݾى��׸ނ�OFF�̏ꍇ)

                '========================
                '���ɒ��ޯ̧
                '========================
                objTPRG_TRK_BUF_RELAY.FRSV_PALLET = objTPRG_TRK_BUF_ST.FRSV_PALLET              '��������گ�ID
                objTPRG_TRK_BUF_RELAY.FRES_KIND = FRES_KIND_SZAIKO                               '�������
                objTPRG_TRK_BUF_RELAY.FTR_FM = objTPRG_TRK_BUF_ST.FTR_FM                        '����FM�ޯ̧��
                objTPRG_TRK_BUF_RELAY.FTR_TO = objTPRG_TRK_BUF_ST.FTR_TO                        '����TO�ޯ̧��
                objTPRG_TRK_BUF_RELAY.FTR_IDOU = objTPRG_TRK_BUF_ST.FTR_IDOU                    '����TO�ړ��ޯ̧��
                objTPRG_TRK_BUF_RELAY.FTRNS_FM = objTPRG_TRK_BUF_ST.FTRNS_FM                    '�����w�ߗpFM
                objTPRG_TRK_BUF_RELAY.FTRNS_TO = objTPRG_TRK_BUF_ST.FTRNS_TO                    '�����w�ߗpTO
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM = DEFAULT_INTEGER                             'FM�����ׯ�ݸއ�
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM = DEFAULT_INTEGER                           'FM�����z��
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO = objTPRG_TRK_BUF_ST.FRSV_BUF_TO              'TO�����ׯ�ݸއ�
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO          'TO�����z��
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_ST.FDISP_ADDRESS_FM    'FM�\�L�p���ڽ
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_RELAY.GET_ADDRESS_TO   'TO�\�L�p���ڽ
                objTPRG_TRK_BUF_RELAY.FBUF_IN_DT = Now                                          '�ޯ̧������
                objTPRG_TRK_BUF_RELAY.UPDATE_TPRG_TRK_BUF()                                     '�X�V

                '========================
                '�ð����ޯ̧
                '========================
                objTPRG_TRK_BUF_ST.CLEAR_TPRG_TRK_BUF()             '���


            Else
                '(��ݾى��׸ނ�ON�̏ꍇ)

                '========================
                '�ð����ޯ̧
                '========================
                objTPRG_TRK_BUF_ST.FRSV_PALLET = objTPRG_TRK_BUF_RELAY.FPALLET_ID               '��������گ�ID
                objTPRG_TRK_BUF_ST.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                           '������� = �����\��
                objTPRG_TRK_BUF_ST.FBUF_IN_DT = Now                                             '�ޯ̧������
                objTPRG_TRK_BUF_ST.UPDATE_TPRG_TRK_BUF()                                        '�X�V

                '========================
                '���ɒ��ޯ̧
                '========================
                objTPRG_TRK_BUF_RELAY.FRSV_PALLET = objTPRG_TRK_BUF_RELAY.FPALLET_ID            '��������گ�ID
                objTPRG_TRK_BUF_RELAY.FRES_KIND = FRES_KIND_SZAIKO                               '�������
                objTPRG_TRK_BUF_RELAY.FTR_FM = objTPRG_TRK_BUF_ST.FTR_FM                        '����FM�ޯ̧��
                objTPRG_TRK_BUF_RELAY.FTR_TO = objTPRG_TRK_BUF_ST.FTR_TO                        '����TO�ޯ̧��
                objTPRG_TRK_BUF_RELAY.FTR_IDOU = objTPRG_TRK_BUF_ST.FTR_IDOU                    '����TO�ړ��ޯ̧��
                objTPRG_TRK_BUF_RELAY.FTRNS_FM = objTPRG_TRK_BUF_ST.FTRNS_FM                    '�����w�ߗpFM
                objTPRG_TRK_BUF_RELAY.FTRNS_TO = objTPRG_TRK_BUF_ST.FTRNS_TO                    '�����w�ߗpTO
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_NO              'FM�����ׯ�ݸއ�
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM = objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY         'FM�����z��
                objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO = objTPRG_TRK_BUF_ST.FRSV_BUF_TO              'TO�����ׯ�ݸއ�
                objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO = objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO          'TO�����z��
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_ST.FDISP_ADDRESS_FM    'FM�\�L�p���ڽ
                objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_RELAY.GET_ADDRESS_TO   'TO�\�L�p���ڽ
                objTPRG_TRK_BUF_RELAY.FBUF_IN_DT = Now                                          '�ޯ̧������
                objTPRG_TRK_BUF_RELAY.UPDATE_TPRG_TRK_BUF()                                     '�X�V

            End If


            '========================
            '�w�����M�҂����R�̸ر
            '========================
            objTSTS_HIKIATE.FWAIT_REASON = DEFAULT_STRING
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()


            '************************
            '����I��
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & _
                                "  [��گ�ID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & _
                                "  ,������:" & objTPRG_TRK_BUF_ST.FDISP_ADDRESS & _
                                "  ,������:" & objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS & _
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
#Region "  ���ꏈ��01(�߱�����҂�����)                                                              "
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
        Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        If mobjTPLN_CARRY_QUE.XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA And IsNotNull(mobjTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
            '(�e�����߱�����̏ꍇ)


            '*************************************************
            'FM�ׯ�ݸ�(�߱�ׯ�ݸ�)       �擾
            '*************************************************
            Dim objTPRG_TRK_BUF_Aite_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF_Aite_FM.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO            '�ׯ�ݸ��ޯ̧��
            objTPRG_TRK_BUF_Aite_FM.FRSV_PALLET = mobjTPLN_CARRY_QUE.XPALLET_ID_AITE        '��������گ�ID
            intRet = objTPRG_TRK_BUF_Aite_FM.GET_TPRG_TRK_BUF_RSV_PALLET()                  '�擾
            If intRet <> RetCode.OK Then
                '(�߱�ׯ�ݸނ��܂�ST�ɓ������Ă��Ȃ��ꍇ)
                intReturn = RetCode.NG
            End If


        End If


        Return intReturn
    End Function
#End Region
#Region "  ���ꏈ��02(��O�I�Ɖ��I�̓��ɗ\����֏���)                                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��02(��O�I�Ɖ��I�̓��ɗ\����֏���)
    ''' ���I�̍݌ɂ���ɂ���O�ɁA��O�I�̍݌ɂ����������ꍇ�A��O�I�̍s��Ɖ��I�̍s���ς���B
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special02() As RetCode
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '************************
        '�ð����ޯ̧�̓���
        '************************
        Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  '�ׯ�ݸ��ޯ̧�׽
        objTPRG_TRK_BUF_FM.FPALLET_ID = mobjTPLN_CARRY_QUE.FPALLET_ID           '��گ�ID
        objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF()                                   '����


        '***********************************************
        '����
        '***********************************************
        If TO_INTEGER(objTPRG_TRK_BUF_FM.FRSV_BUF_TO) <> TO_INTEGER(DEFAULT_INTEGER) And _
           TO_INTEGER(objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO) <> TO_INTEGER(DEFAULT_INTEGER) Then
            '(�����悪��������Ă���ꍇ)


            '***********************************************
            '����
            '***********************************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FRSV_BUF_TO           '�ޯ̧��
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO      '�z��
            objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()                                     '����
            If objTPRG_TRK_BUF_ASRS.FRAC_EDA = FLAG_ON Then Return intReturn '���I�̏ꍇ�͉������Ȃ�


            '***********************************************
            '�֘A������ۯ��I�̎擾
            '***********************************************
            Dim objTrkRelation() As TBL_TPRG_TRK_BUF = Nothing                      '�ׯ�ݸ��ޯ̧�׽
            Dim objStockFind As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)          '�݌ɏ��
            Dim objStockRelation() As TBL_TRST_STOCK = Nothing                      '�݌ɏ��
            Call GetTPRG_TRK_BUF_Relation(objTPRG_TRK_BUF_ASRS, objTrkRelation, objStockFind, objStockRelation)


            '***********************************************
            '���I�ɗ\�񂪂������Ă��邩����
            '***********************************************
            If Not ( _
                      objTrkRelation(RelationArray.OKU_EVN).FRES_KIND = FRES_KIND_SRSV_TRNS_IN _
                   Or objTrkRelation(RelationArray.OKU_ODD).FRES_KIND = FRES_KIND_SRSV_TRNS_IN _
                   ) _
                   Then
                '(���I�ɓ��ɗ\�񂪂������Ă��Ȃ��ꍇ�́A�������Ȃ�)
                Return intReturn
            End If


            '***********************************************
            '���I�̗\�񂪓��Ɏw���ς�����
            '***********************************************
            If IsNotNull(objTrkRelation(RelationArray.OKU_EVN).FRSV_PALLET) Then
                Dim objTPRG_TRK_BUF_RELAY_Check As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_RELAY_Check.FPALLET_ID = objTrkRelation(RelationArray.OKU_EVN).FRSV_PALLET      '��گ�ID
                objTPRG_TRK_BUF_RELAY_Check.GET_TPRG_TRK_BUF()                                                  '�擾
                If objTPRG_TRK_BUF_RELAY_Check.FTRK_BUF_NO = FTRK_BUF_NO_J3101 _
                   Or objTPRG_TRK_BUF_RELAY_Check.FTRK_BUF_NO = FTRK_BUF_NO_J3102 _
                   Then
                    '(�w���ς݂̏ꍇ)
                    Return intReturn
                End If

            End If


            '**********************************************************************************************
            '**********************************************************************************************
            '��O�I�Ɖ��I�̓��ɗ\������
            '**********************************************************************************************
            '**********************************************************************************************
            '***********************************************
            '�����q���ׯ�ݸނ̉�������گ�ID�����
            '***********************************************
            Dim strTemp01 As String
            Dim strTemp02 As String
            '======================================
            '��������گ�ID
            '======================================
            strTemp01 = objTrkRelation(RelationArray.OKU_EVN).FRSV_PALLET                                           '(�ꎞ�ۊ�)��(��)
            strTemp02 = objTrkRelation(RelationArray.OKU_ODD).FRSV_PALLET                                           '(�ꎞ�ۊ�)��(��)
            objTrkRelation(RelationArray.OKU_EVN).FRSV_PALLET = objTrkRelation(RelationArray.MAE_EVN).FRSV_PALLET   '(��)��(��O)
            objTrkRelation(RelationArray.OKU_ODD).FRSV_PALLET = objTrkRelation(RelationArray.MAE_ODD).FRSV_PALLET   '(��)��(��O)
            objTrkRelation(RelationArray.MAE_EVN).FRSV_PALLET = strTemp01                                           '(��O)��(�ꎞ�ۊ�)
            objTrkRelation(RelationArray.MAE_ODD).FRSV_PALLET = strTemp02                                           '(��O)��(�ꎞ�ۊ�)

            '======================================
            '�������
            '======================================
            strTemp01 = objTrkRelation(RelationArray.OKU_EVN).FRES_KIND                                             '(�ꎞ�ۊ�)��(��)
            strTemp02 = objTrkRelation(RelationArray.OKU_ODD).FRES_KIND                                             '(�ꎞ�ۊ�)��(��)
            objTrkRelation(RelationArray.OKU_EVN).FRES_KIND = objTrkRelation(RelationArray.MAE_EVN).FRES_KIND       '(��)��(��O)
            objTrkRelation(RelationArray.OKU_ODD).FRES_KIND = objTrkRelation(RelationArray.MAE_ODD).FRES_KIND       '(��)��(��O)
            objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = strTemp01                                             '(��O)��(�ꎞ�ۊ�)
            objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = strTemp02                                             '(��O)��(�ꎞ�ۊ�)

            '======================================
            '�X�V
            '======================================
            objTrkRelation(RelationArray.OKU_EVN).UPDATE_TPRG_TRK_BUF() '�X�V
            objTrkRelation(RelationArray.OKU_ODD).UPDATE_TPRG_TRK_BUF() '�X�V
            objTrkRelation(RelationArray.MAE_EVN).UPDATE_TPRG_TRK_BUF() '�X�V
            objTrkRelation(RelationArray.MAE_ODD).UPDATE_TPRG_TRK_BUF() '�X�V

            '============================================================================
            '�݌ɏ��           �����ׯ�ݸޏ��̍X�V
            '============================================================================
            Call UpdateTRST_STOCK_InInfor(objTrkRelation(RelationArray.OKU_EVN), objStockRelation(RelationArray.MAE_EVN))
            Call UpdateTRST_STOCK_InInfor(objTrkRelation(RelationArray.OKU_ODD), objStockRelation(RelationArray.MAE_ODD))
            Call UpdateTRST_STOCK_InInfor(objTrkRelation(RelationArray.MAE_EVN), objStockRelation(RelationArray.OKU_EVN))
            Call UpdateTRST_STOCK_InInfor(objTrkRelation(RelationArray.MAE_ODD), objStockRelation(RelationArray.OKU_ODD))

            '======================================
            '۸ޏo��
            '======================================
            '��ݻ޸���۸�
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                   "��O�I���ɗ\��̍݌ɂ��A���I���ɗ\��̍݌ɂ�����ɓ��������ׁA��O�I�Ɖ��I�̗\������ւ���B" _
                 & "[�ΏےI1:" & objTrkRelation(RelationArray.OKU_EVN).FDISP_ADDRESS & "]" _
                 & "[�ΏےI2:" & objTrkRelation(RelationArray.OKU_ODD).FDISP_ADDRESS & "]" _
                 & "[�ΏےI3:" & objTrkRelation(RelationArray.MAE_EVN).FDISP_ADDRESS & "]" _
                 & "[�ΏےI4:" & objTrkRelation(RelationArray.MAE_ODD).FDISP_ADDRESS & "]" _
                 )
            'ү����۸ޏo��
            Call AddToMsgLog(Now, FMSG_ID_J4001 _
                           , "��O�I���ɗ\��̍݌ɂ��A���I���ɗ\��̍݌ɂ�����ɓ��������ׁA��O�I�Ɖ��I�̗\������ւ��܂����B" _
                           , "[�ΏےI1:" & objTrkRelation(RelationArray.OKU_EVN).FDISP_ADDRESS & "]" _
                           & "[�ΏےI2:" & objTrkRelation(RelationArray.OKU_ODD).FDISP_ADDRESS & "]" _
                           & "[�ΏےI3:" & objTrkRelation(RelationArray.MAE_EVN).FDISP_ADDRESS & "]" _
                           & "[�ΏےI4:" & objTrkRelation(RelationArray.MAE_ODD).FDISP_ADDRESS & "]" _
                           )


            '***********************************************
            '���ׯ�ݸނ��X�V
            '***********************************************
            For ii As Integer = 0 To UBound(objTrkRelation)
                '(ٰ��:�֌W�����ׯ�ݸސ�)
                If IsNull(objTrkRelation(ii).FRSV_PALLET) Then Continue For


                '***********************************************
                'ST�ׯ�ݸގ擾
                '***********************************************
                Dim objTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_ST.FPALLET_ID = objTrkRelation(ii).FRSV_PALLET          '��گ�ID
                objTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF()                                   '�擾


                '***********************************************
                'ST�ׯ�ݸލX�V
                '***********************************************
                Select Case objTPRG_TRK_BUF_ST.FTRK_BUF_NO
                    Case FTRK_BUF_NO_J1010 _
                       , FTRK_BUF_NO_J1013 _
                       , FTRK_BUF_NO_J1017 _
                       , FTRK_BUF_NO_J1021 _
                       , FTRK_BUF_NO_J1025 _
                       , FTRK_BUF_NO_J1029 _
                       , FTRK_BUF_NO_J1033 _
                       , FTRK_BUF_NO_J1037 _
                       , FTRK_BUF_NO_J1041 _
                       , FTRK_BUF_NO_J1045 _
                       , FTRK_BUF_NO_J1049 _
                       , FTRK_BUF_NO_J1053 _
                       , FTRK_BUF_NO_J1057 _
                       , FTRK_BUF_NO_J1061 _
                       , FTRK_BUF_NO_J2079 _
                       , FTRK_BUF_NO_J2081 _
                       , FTRK_BUF_NO_J2084 _
                       , FTRK_BUF_NO_J2087 _
                       , FTRK_BUF_NO_J2090 _
                       , FTRK_BUF_NO_J2093 _
                       , FTRK_BUF_NO_J2096 _
                       , FTRK_BUF_NO_J2099 _
                       , FTRK_BUF_NO_J2102 _
                       , FTRK_BUF_NO_J2105 _
                       , FTRK_BUF_NO_J2108 _
                       , FTRK_BUF_NO_J2111 _
                       , FTRK_BUF_NO_J2114 _
                       , FTRK_BUF_NO_J2117
                        '(���ɺ���Ԃ��ׯ�ݸނ����݂��Ă���ꍇ)
                        objTPRG_TRK_BUF_ST.FRSV_BUF_TO = objTrkRelation(ii).FTRK_BUF_NO                 'TO�����ׯ�ݸ��ޯ̧��
                        objTPRG_TRK_BUF_ST.FRSV_ARRAY_TO = objTrkRelation(ii).FTRK_BUF_ARRAY            'TO�����ׯ�ݸ��ޯ̧�z��
                        objTPRG_TRK_BUF_ST.FDISP_ADDRESS_TO = objTrkRelation(ii).FDISP_ADDRESS          'TO�\�L�p���ڽ
                        objTPRG_TRK_BUF_ST.UPDATE_TPRG_TRK_BUF()                                        '�X�V
                End Select


            Next


        Else
            '(�����悪��������Ă��Ȃ��ꍇ)
            Return intReturn
        End If


        Return intReturn
    End Function
#End Region
#Region "  ���ꏈ��03(���Ɏw���̌����͈ꌏ�̂�)                                                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��03(���Ɏw���̌����͈ꌏ�̂�)
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
        End If
        If 2 <= objAryTPLN_CARRY_QUE.ARYME.Length Then
            '(2���ȏ�̓��Ɏw��������ꍇ)

            objTSTS_HIKIATE.FWAIT_REASON = "�ڰ݂����ɒ�[" & TO_STRING(objAryTPLN_CARRY_QUE.ARYME.Length) & "��]�ׁ̈A���Ɋ����҂��B"
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

            Return RetCode.NotEnough
        End If


        '***********************************************
        '1���̓����ׯ�ݸނ��������ǂ���������
        '�����ׯ�ݸނ������������ꍇ��OK�Ƃ���
        '***********************************************
        If TO_STRING(objAryTPLN_CARRY_QUE.ARYME(0).XPALLET_ID_AITE) = mobjTPLN_CARRY_QUE.FPALLET_ID Then
            '(�����������������ꍇ)
            Return RetCode.OK
        Else
            '(��������������Ȃ��ꍇ)

            objTSTS_HIKIATE.FWAIT_REASON = "�ڰ݂����ɒ�(1��)�ׁ̈A���Ɋ����҂��B"
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

            Return RetCode.NotEnough
        End If


        Return intReturn
    End Function
#End Region
#Region "  ���ꏈ��04(�o�Ɏw������)                                                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��04(�o�Ɏw������)
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
        Else
            '(�o�Ɏw��������ꍇ)

            objTSTS_HIKIATE.FWAIT_REASON = "�ڰ݂��o�ɒ�(" & TO_STRING(objAryTPLN_CARRY_QUE.ARYME.Length) & "��)�ׁ̈A�o�Ɋ����҂��B"
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()

            Return RetCode.NotEnough
        End If


        Return intReturn
    End Function
#End Region
    '���������ьŗL
    '**********************************************************************************************

End Class
