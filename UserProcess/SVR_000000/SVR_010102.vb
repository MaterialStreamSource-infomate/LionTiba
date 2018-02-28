'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z���Ɋ�������
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_010102
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �׽�ϐ���`                                                                          "
    Private mFPALLET_ID As String                       '��گ�ID
    Private mFINOUT_STS As Nullable(Of Integer)         'IN/OUT
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


            '************************
            '���ɒ��ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)   '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = mFPALLET_ID                              '��گ�ID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                       '����


            '************************
            '�ð����ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)      '�ׯ�ݸ��ޯ̧�׽
            If IsNull(objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM) = False Then
                '(���������������Ă��Ȃ��ꍇ)
                objTPRG_TRK_BUF_ST.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM          '�ׯ�ݸ��ޯ̧��
                objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM     '�ׯ�ݸ��ޯ̧�z��
                intRet = objTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF(True)                          '����
            End If


            '************************
            '�q���ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO        '�ׯ�ݸ��ޯ̧��
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO   '�ׯ�ݸ��ޯ̧�z��
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                        '����


            '************************
            '�������ׯ�ݸ�Ͻ��̓���
            '************************
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
            End If


            '************************
            '�݌Ɉ������̓���
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '�݌Ɉ������׽
            objTSTS_HIKIATE.FPALLET_ID = mFPALLET_ID                            '��گ�ID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                    '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[��گ�ID:" & mFPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�݌Ɉړ�
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '�݌Ɉړ��׽
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY    '�ׯ�ݸ��ޯ̧(���ɒ��ޯ̧)
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_ASRS     '�ׯ�ݸ��ޯ̧(�q���ޯ̧)
            objSVR_100103.FPALLET_ID = mFPALLET_ID                      '��گ�ID
            objSVR_100103.FINOUT_STS = mFINOUT_STS                      'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '��Ǝ��
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '�������ر�׸�
            objSVR_100103.STOCK_TRNS()                                  '�ړ�


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
                objTEVD_STOCK_LOG.FDECIMAL_POINT = objTMST_ITEM.FDECIMAL_POINT              '�����_����
                objTEVD_STOCK_LOG.FSEIHIN_KUBUN = objTRST_STOCK.FSEIHIN_KUBUN               '���i�敪
                objTEVD_STOCK_LOG.FRECEIVEPAY_NUM = objTRST_STOCK.FTR_VOL                   '�󕥐���
                objTEVD_STOCK_LOG.FZAIKO_NUM = objTRST_STOCK.FTR_VOL                        '�݌ɐ���
                objTEVD_STOCK_LOG.FHORYU_KUBUN = objTRST_STOCK.FHORYU_KUBUN                 '�ۗ��敪
                objTEVD_STOCK_LOG.FSAGYOU_CONTENT = objTMST_SAGYO.FSAGYOU_CONTENT           '��Ɠ��e
                objTEVD_STOCK_LOG.ADD_TEVD_STOCK_LOG_SEQ()

                '************************
                '�݌ɏ��̍X�V
                '************************
                objTRST_STOCK.FTR_RES_VOL = 0           '����������
                objTRST_STOCK.FUPDATE_DT = Now          '�X�V����
                objTRST_STOCK.UPDATE_TRST_STOCK()       '�X�V



                '������������************************************************************************************************************
                '2017/07/29 BCR�X�V infomate
                '�X�V�^�C�~���O�ύX�̈׃R�����g�A�E�g

                'Try
                '    If objTSTS_HIKIATE.FSAGYOU_KIND = 81 Then
                '        Dim objXSTS_BCR As New TBL_XSTS_BCR(Owner, ObjDb, ObjDbLog)
                '        objXSTS_BCR.FTRK_BUF_NO = 2051
                '        objXSTS_BCR.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD
                '        objXSTS_BCR.GET_XSTS_BCR(False)

                '        objXSTS_BCR.XCOUNT_PL_IN = objXSTS_BCR.XCOUNT_PL_IN + 1
                '        objXSTS_BCR.XCOUNT_IN = objXSTS_BCR.XCOUNT_IN + objTMST_ITEM.FNUM_IN_PALLET
                '        objXSTS_BCR.UPDATE_XSTS_BCR()

                '    End If

                '    If objTSTS_HIKIATE.FSAGYOU_KIND = 82 Then
                '        Dim objXSTS_BCR As New TBL_XSTS_BCR(Owner, ObjDb, ObjDbLog)
                '        objXSTS_BCR.FTRK_BUF_NO = 2901
                '        objXSTS_BCR.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD
                '        objXSTS_BCR.GET_XSTS_BCR(False)

                '        objXSTS_BCR.XCOUNT_PL_IN = objXSTS_BCR.XCOUNT_PL_IN + 1
                '        objXSTS_BCR.XCOUNT_IN = objXSTS_BCR.XCOUNT_IN + objTMST_ITEM.FNUM_IN_PALLET
                '        objXSTS_BCR.UPDATE_XSTS_BCR()

                '    End If
                'Catch ex As Exception
                '    'NOP
                'End Try

                '������������************************************************************************************************************
            Next

     
            '**************************************
            '�ۊǏo�[�L�^�ǉ�
            '**************************************
            Call Add_TBL_TEVD_SUITOU(objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO _
                                   , DEFAULT_INTEGER _
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


            '************************
            '�ð����ޯ̧�̍X�V
            '************************
            If IsNull(objTPRG_TRK_BUF_ST.FTRK_BUF_NO) = False Then
                If mFPALLET_ID = objTPRG_TRK_BUF_ST.FRSV_PALLET Then
                    '(���������������Ă��Ȃ��ꍇ)
                    objTPRG_TRK_BUF_ST.CLEAR_TPRG_TRK_BUF()             '���
                End If
            End If


            '************************
            '�q���ޯ̧�̍X�V
            '************************
            objTPRG_TRK_BUF_ASRS.FRSV_PALLET = DEFAULT_STRING                   '��������گ�ID
            objTPRG_TRK_BUF_ASRS.FTR_FM = DEFAULT_INTEGER                       '����FM�ޯ̧��
            objTPRG_TRK_BUF_ASRS.FTR_TO = DEFAULT_INTEGER                       '����TO�ޯ̧��
            objTPRG_TRK_BUF_ASRS.FTR_IDOU = DEFAULT_INTEGER                     '����TO�ړ��ޯ̧��
            objTPRG_TRK_BUF_ASRS.FTRNS_FM = DEFAULT_STRING                      '�����w�ߗpFM
            objTPRG_TRK_BUF_ASRS.FTRNS_TO = DEFAULT_STRING                      '�����w�ߗpTO
            objTPRG_TRK_BUF_ASRS.FRSV_BUF_FM = DEFAULT_INTEGER                  'FM�����ޯ̧��
            objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_FM = DEFAULT_INTEGER                'FM�����z��
            objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO = DEFAULT_INTEGER                  'TO�����ޯ̧��
            objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO = DEFAULT_INTEGER                'TO�����z��
            objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_FM = DEFAULT_STRING              'FM�\�L�p���ڽ
            objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_TO = DEFAULT_STRING              'TO�\�L�p���ڽ
            objTPRG_TRK_BUF_ASRS.FDISPLOG_ADDRESS_FM = DEFAULT_STRING           'FM�\�L�p���ڽ_۸ޗp
            objTPRG_TRK_BUF_ASRS.FDISPLOG_ADDRESS_TO = DEFAULT_STRING           'TO�\�L�p���ڽ_۸ޗp
            objTPRG_TRK_BUF_ASRS.FBUF_IN_DT = Now                               '�ޯ̧������
            objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                          '�X�V


            '������������************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/01 ���Y���C���ʓ��Ɏ��тőq�ւ����ɂ͎��тɌv�コ���Ȃ�
            Dim objTSTS_HIKIATE_WK As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '�݌Ɉ������׽
            objTSTS_HIKIATE_WK.FPALLET_ID = mFPALLET_ID                            '��گ�ID
            objTSTS_HIKIATE_WK.GET_TSTS_HIKIATE_PALLET()                    '����
            'JobMate:S.Ouchi 2013/11/01 ���Y���C���ʓ��Ɏ��тőq�ւ����ɂ͎��тɌv�コ���Ȃ�
            '������������************************************************************************************************************


            '************************
            '�݌Ɉ������̍폜
            '************************
            objTSTS_HIKIATE = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)  '�݌Ɉ������׽
            objTSTS_HIKIATE.FPALLET_ID = mFPALLET_ID
            objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()       '�폜


            '************************
            '�����w��QUE�̍폜
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '�ݽ�ݽ��
            objTPLN_CARRY_QUE.FPALLET_ID = mFPALLET_ID                              '��گ�ID
            objTPLN_CARRY_QUE.DELETE_TPLN_CARRY_QUE_PALLET()                        '�폜


            '************************
            '�ري֘A�t���̍폜
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)   '�ري֘A�t���׽
            objTPRG_SERIAL.FPALLET_ID = mFPALLET_ID                             '��گ�ID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                 '�폜


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/04 ���ꏈ��


            '**************************************
            '���ꏈ��01(�I��ۯ���ԍX�V)
            '**************************************
            Call Special01(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_ST _
                         , objTPRG_TRK_BUF_ASRS _
                         , objTSTS_HIKIATE _
                         )


            '**************************************
            '���ꏈ��02(�݌ɏ��X�V)
            '**************************************
            Call Special02(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_ST _
                         , objTPRG_TRK_BUF_ASRS _
                         , objTSTS_HIKIATE _
                         )


            '**************************************
            '���ꏈ��21(�o���Y���яڍגǉ�)
            '**************************************
            '������������************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/01 ���Y���C���ʓ��Ɏ��тőq�ւ����ɂ͎��тɌv�コ���Ȃ�
            '' ''Call Special21(objTPRG_TRK_BUF_RELAY _
            '' ''             , objTPRG_TRK_BUF_ST _
            '' ''             , objTPRG_TRK_BUF_ASRS _
            '' ''             , objTSTS_HIKIATE _
            '' ''             )
            Call Special21(objTPRG_TRK_BUF_RELAY _
                         , objTPRG_TRK_BUF_ST _
                         , objTPRG_TRK_BUF_ASRS _
                         , objTSTS_HIKIATE_WK _
                         )
            'JobMate:S.Ouchi 2013/11/01 ���Y���C���ʓ��Ɏ��тőq�ւ����ɂ͎��тɌv�コ���Ȃ�
            '������������************************************************************************************************************


            '������������************************************************************************************************************


            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                           '�N��(���Ɏw��)

            '************************
            '���튮��
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL & "  [��گ�ID:" & mFPALLET_ID & "]")


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
#Region "  ���ꏈ��01(�I��ۯ���ԍX�V)                                                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��01(��ۯ���ԍX�V)
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


        '************************************************
        '�I��ۯ��̎擾
        '************************************************
        Dim intCount As Integer = 0                                             '��ۯ����̎�O�I�̍݌ɶ���
        Dim objTrkRelation() As TBL_TPRG_TRK_BUF = Nothing                      '�ׯ�ݸ��ޯ̧�׽
        Dim objStockFind As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)          '�݌ɏ��
        Dim objStockRelation() As TBL_TRST_STOCK = Nothing                      '�݌ɏ��
        Call GetTPRG_TRK_BUF_Relation(objTPRG_TRK_BUF_TO, objTrkRelation, objStockFind, objStockRelation)
        For ii As Integer = 0 To UBound(objStockRelation)
            '(ٰ��:�֌W�����ׯ�ݸސ�)

            If (objTrkRelation(ii).XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_MAE_EVN Or objTrkRelation(ii).XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_MAE_ODD) _
               And IsNotNull(objTrkRelation(ii).FPALLET_ID) _
               Then
                '(��O�I���݌ɂ����݂��Ă���ꍇ)
                intCount += 1
            End If

            If ii = UBound(objStockRelation) Then
                '(ٰ�ߍŏI�̏ꍇ)

                '************************************************
                '�I��ۯ���Ԃ̍X�V
                '************************************************
                If 1 <= intCount Then
                    '(��O�I�ɍ݌ɂ�1�ł����݂��Ă����ꍇ)
                    Call UpdateTPRG_TRK_BUF_Relation_XTANA_BLOCK_STS(objTPRG_TRK_BUF_TO, XTANA_BLOCK_STS_NON)
                End If


            End If

        Next


        Return intReturn
    End Function
#End Region
#Region "  ���ꏈ��02(�݌ɏ��X�V)                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ꏈ��02(�݌ɏ��X�V)
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
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '************************************************
        '�݌ɏ��           �擾
        '************************************************
        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
        objTRST_STOCK.FPALLET_ID = objTPRG_TRK_BUF_TO.FPALLET_ID
        objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)


        '************************************************
        '�݌ɏ��           �X�V
        '************************************************
        objTRST_STOCK.ARYME(0).XRAC_IN_DT = Now                                         '���ɓ���
        objTRST_STOCK.ARYME(0).XTRK_BUF_NO_IN = objTPRG_TRK_BUF_TO.FTRK_BUF_NO          '�����ׯ�ݸ��ޯ̧��
        objTRST_STOCK.ARYME(0).XTRK_BUF_ARRAY_IN = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY    '�����ׯ�ݸ��ޯ̧�z��
        objTRST_STOCK.ARYME(0).UPDATE_TRST_STOCK()                                      '�X�V


        '************************************************
        '�݌ɏ��           �����ׯ�ݸޏ��̍X�V
        '************************************************
        Call UpdateTRST_STOCK_InInfor(objTPRG_TRK_BUF_TO, objTRST_STOCK)


        Return intReturn
    End Function
#End Region

#Region "  ���ꏈ��21(�o���Y���яڍגǉ�)                                                       "
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
        Dim intReturn As RetCode = RetCode.OK
        Try


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
            '���Ɨ���                   �擾
            '************************************************
            Dim objXRST_SOUGYOU As New TBL_XRST_SOUGYOU(Owner, ObjDb, ObjDbLog)
            objXRST_SOUGYOU.GET_XRST_SOUGYOU_XRST_SOUGYOU_MAX()


            '*****************************************************
            '���Y���яڍ�               �ǉ�
            '*****************************************************
            Dim objXRST_PRODUCT_IN As New TBL_XRST_PRODUCT_IN(Owner, ObjDb, ObjDbLog)
            objXRST_PRODUCT_IN.XSOUGYOU_DT = objXRST_SOUGYOU.XSOUGYOU_DT                    '���Ɠ�
            objXRST_PRODUCT_IN.FPALLET_ID = objTRST_STOCK.ARYME(0).FPALLET_ID               '��گ�ID
            objXRST_PRODUCT_IN.FLOT_NO_STOCK = objTRST_STOCK.ARYME(0).FLOT_NO_STOCK         '�݌�ۯć�
            intRet = objXRST_PRODUCT_IN.GET_XRST_PRODUCT_IN(False)
            If intRet <> RetCode.OK Then

                '������������************************************************************************************************************
                '    JobMate:S.Ouchi 2013/11/01 ���Y���C���ʓ��Ɏ��тőq�ւ����ɂ͎��тɌv�コ���Ȃ�
                If TO_INTEGER(objTSTS_HIKIATE.FSAGYOU_KIND) <> FSAGYOU_KIND_J75 And _
                   TO_INTEGER(objTSTS_HIKIATE.FSAGYOU_KIND) <> FSAGYOU_KIND_J76 Then
                    'JobMate:S.Ouchi 2013/11/01 ���Y���C���ʓ��Ɏ��тőq�ւ����ɂ͎��тɌv�コ���Ȃ�
                    '������������************************************************************************************************************

                    '(�q�֓��ɈȊO�̏ꍇ)
                    objXRST_PRODUCT_IN.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND                  '��Ǝ��
                    objXRST_PRODUCT_IN.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD               '�i�ں���
                    objXRST_PRODUCT_IN.FLOT_NO = objTRST_STOCK.ARYME(0).FLOT_NO                     'ۯć�
                    objXRST_PRODUCT_IN.FARRIVE_DT = objTRST_STOCK.ARYME(0).FARRIVE_DT               '�݌ɔ�������
                    objXRST_PRODUCT_IN.FIN_KUBUN = objTRST_STOCK.ARYME(0).FIN_KUBUN                 '���ɋ敪
                    objXRST_PRODUCT_IN.FSEIHIN_KUBUN = objTRST_STOCK.ARYME(0).FSEIHIN_KUBUN         '���i�敪
                    objXRST_PRODUCT_IN.FZAIKO_KUBUN = objTRST_STOCK.ARYME(0).FZAIKO_KUBUN           '�݌ɋ敪
                    objXRST_PRODUCT_IN.FHORYU_KUBUN = objTRST_STOCK.ARYME(0).FHORYU_KUBUN           '�ۗ��敪
                    objXRST_PRODUCT_IN.FST_FM = objTRST_STOCK.ARYME(0).FST_FM                       '������ST�ׯ�ݸ��ޯ̧��
                    objXRST_PRODUCT_IN.FTR_VOL = objTRST_STOCK.ARYME(0).FTR_VOL                     '�����Ǘ���
                    objXRST_PRODUCT_IN.FHASU_FLAG = objTRST_STOCK.ARYME(0).FHASU_FLAG               '�[���׸�
                    objXRST_PRODUCT_IN.XPROD_LINE = objTRST_STOCK.ARYME(0).XPROD_LINE               '���Yײ݇�
                    objXRST_PRODUCT_IN.XKENSA_KUBUN = objTRST_STOCK.ARYME(0).XKENSA_KUBUN           '�����敪
                    objXRST_PRODUCT_IN.XKENPIN_KUBUN = objTRST_STOCK.ARYME(0).XKENPIN_KUBUN         '���i�敪
                    objXRST_PRODUCT_IN.XMAKER_CD = objTRST_STOCK.ARYME(0).XMAKER_CD                 'Ұ�-����
                    objXRST_PRODUCT_IN.XRAC_IN_DT = Now                                             '���ɓ���
                    objXRST_PRODUCT_IN.XTRK_BUF_NO_IN = objTPRG_TRK_BUF_TO.FTRK_BUF_NO              '�����ׯ�ݸ��ޯ̧��
                    objXRST_PRODUCT_IN.XTRK_BUF_ARRAY_IN = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY        '�����ׯ�ݸ��ޯ̧�z��
                    objXRST_PRODUCT_IN.ADD_XRST_PRODUCT_IN()                                        '�o�^

                    '������������************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/01 ���Y���C���ʓ��Ɏ��тőq�ւ����ɂ͎��тɌv�コ���Ȃ�
                End If
                '    JobMate:S.Ouchi 2013/11/01 ���Y���C���ʓ��Ɏ��тőq�ւ����ɂ͎��тɌv�コ���Ȃ�
                '������������************************************************************************************************************

            End If


            ' '' ''*****************************************************
            ' '' ''���Y���ɐݒ���           �ǉ�
            ' '' ''*****************************************************
            '' ''If IsNotNull(objTRST_STOCK.ARYME(0).FST_FM) Then
            '' ''    '(������ST�ׯ�ݸ��ޯ̧������Ă���Ă����ꍇ)

            '' ''    Dim objXSTS_PRODUCT_IN As New TBL_XSTS_PRODUCT_IN(Owner, ObjDb, ObjDbLog)
            '' ''    objXSTS_PRODUCT_IN.FTRK_BUF_NO = objTRST_STOCK.ARYME(0).FST_FM              '�ׯ�ݸ��ޯ̧��
            '' ''    objXSTS_PRODUCT_IN.XPROD_LINE = objTRST_STOCK.ARYME(0).XPROD_LINE           '���Yײ݇�
            '' ''    objXSTS_PRODUCT_IN.FHINMEI_CD = objTRST_STOCK.ARYME(0).FHINMEI_CD           '�i�ں���
            '' ''    objXSTS_PRODUCT_IN.FIN_KUBUN = objTRST_STOCK.ARYME(0).FIN_KUBUN             '���ɋ敪
            '' ''    objXSTS_PRODUCT_IN.FHORYU_KUBUN = objTRST_STOCK.ARYME(0).FHORYU_KUBUN       '�ۗ��敪
            '' ''    objXSTS_PRODUCT_IN.XKENSA_KUBUN = objTRST_STOCK.ARYME(0).XKENSA_KUBUN       '�����敪
            '' ''    objXSTS_PRODUCT_IN.XKENPIN_KUBUN = objTRST_STOCK.ARYME(0).XKENPIN_KUBUN     '���i�敪
            '' ''    objXSTS_PRODUCT_IN.XMAKER_CD = objTRST_STOCK.ARYME(0).XMAKER_CD             'Ұ�-����
            '' ''    intRet = objXSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN(False)                      '�擾
            '' ''    If intRet = RetCode.OK Then
            '' ''        '(���������ꍇ)

            '' ''        objXSTS_PRODUCT_IN.XRESULT_NUM = TO_INTEGER(objXSTS_PRODUCT_IN.XRESULT_NUM) + 1     '���ѐ���
            '' ''        objXSTS_PRODUCT_IN.UPDATE_XSTS_PRODUCT_IN()                                         '�X�V

            '' ''    End If

            '' ''End If


            Return intReturn
        Catch ex As Exception
            Call ComError(ex)
            Return RetCode.NG
        End Try
    End Function
#End Region
    '���������ьŗL
    '**********************************************************************************************

End Class
